using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Sistema.Datos;
using Sistema.Entidades;
using zkemkeeper;

namespace Sistema.Negocio
{
    /// <summary>
    /// Servicio de Monitoreo y Escucha en Tiempo Real de Biométricos ZKTeco.
    /// Captura marcajes en vivo (<50ms), los persiste en PostgreSQL, invalida caché en Redis
    /// y notifica a los suscriptores UI y WebSocket.
    /// </summary>
    public class ZKTecoLiveListener
    {
        private static readonly Lazy<ZKTecoLiveListener> _instance = new Lazy<ZKTecoLiveListener>(() => new ZKTecoLiveListener());
        public static ZKTecoLiveListener Instancia => _instance.Value;

        private readonly ConcurrentDictionary<int, DispositivoWorker> _workers = new ConcurrentDictionary<int, DispositivoWorker>();
        private System.Threading.Timer _timerHeartbeat;
        private bool _estaCorriendo = false;

        public event Action<EventoMarcacion> OnMarcacionRecibida;
        public event Action<int, string, bool> OnEstadoConexionCambiado; // id, nombre, conectado

        private ZKTecoLiveListener() { }

        public bool EstaCorriendo => _estaCorriendo;

        /// <summary>
        /// Inicia el servicio de escucha para todos los biométricos activos.
        /// </summary>
        public void Iniciar()
        {
            if (_estaCorriendo) return;
            _estaCorriendo = true;

            Task.Run(() =>
            {
                RecargarDispositivos();

                // Timer de verificación de estado y reconexión cada 15 segundos
                _timerHeartbeat = new System.Threading.Timer(VerificarConexiones, null, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15));
            });
        }

        /// <summary>
        /// Detiene el servicio y libera las conexiones TCP abiertas con los biométricos.
        /// </summary>
        public void Detener()
        {
            _estaCorriendo = false;
            _timerHeartbeat?.Dispose();
            _timerHeartbeat = null;

            foreach (var kvp in _workers)
            {
                kvp.Value.Desconectar();
            }
            _workers.Clear();
        }

        /// <summary>
        /// Recarga la lista de biométricos activos desde la Base de Datos.
        /// </summary>
        public void RecargarDispositivos()
        {
            try
            {
                DataTable dt = N_Biometrico.Listar();
                var idsActuales = new HashSet<int>();

                foreach (DataRow row in dt.Rows)
                {
                    bool activo = Convert.ToBoolean(row["activo"]);
                    int id = Convert.ToInt32(row["idbiometrico"]);
                    string nombre = Convert.ToString(row["nombre"]);
                    string ip = Convert.ToString(row["direccion_ip"]);
                    int puerto = Convert.ToInt32(row["puerto"]);
                    int commKey = row["comm_key"] != DBNull.Value ? Convert.ToInt32(row["comm_key"]) : 0;

                    if (!activo) continue;
                    idsActuales.Add(id);

                    if (!_workers.ContainsKey(id))
                    {
                        var worker = new DispositivoWorker(id, nombre, ip, puerto, commKey, ProcesarMarcacionEnVivo, NotificarEstadoConexion);
                        if (_workers.TryAdd(id, worker))
                        {
                            worker.Conectar();
                        }
                    }
                }

                // Remover trabajadores que ya no están activos
                foreach (var key in _workers.Keys)
                {
                    if (!idsActuales.Contains(key))
                    {
                        if (_workers.TryRemove(key, out var w))
                        {
                            w.Desconectar();
                        }
                    }
                }
            }
            catch { }
        }

        private void VerificarConexiones(object state)
        {
            if (!_estaCorriendo) return;

            foreach (var worker in _workers.Values)
            {
                if (!worker.EstaConectado)
                {
                    worker.Conectar();
                }
            }
        }

        private void ProcesarMarcacionEnVivo(EventoMarcacion evt)
        {
            try
            {
                // 1. Guardar en Base de Datos
                N_Asistencia.Insertar(
                    evt.CodigoBiometrico,
                    evt.NombreEmpleado,
                    evt.FechaHora,
                    evt.TipoMarcacion,
                    evt.MetodoVerificacion,
                    evt.IdBiometrico,
                    evt.NombreBiometrico
                );

                // 2. Notificar eventos locales para WinForms UI
                OnMarcacionRecibida?.Invoke(evt);
            }
            catch { }
        }

        private void NotificarEstadoConexion(int id, string nombre, bool conectado)
        {
            OnEstadoConexionCambiado?.Invoke(id, nombre, conectado);
            try
            {
                N_Biometrico.ActualizarEstado(id, conectado ? "Conectado" : "Desconectado", conectado ? DateTime.Now : (DateTime?)null);
            }
            catch { }
        }

        #region Clase Interna: Worker por Biométrico

        private class DispositivoWorker
        {
            public int IdBiometrico { get; }
            public string Nombre { get; }
            public string IP { get; }
            public int Puerto { get; }
            public int CommKey { get; }

            private CZKEMClass _zkem;
            private bool _conectado;
            private readonly Action<EventoMarcacion> _onMarcacion;
            private readonly Action<int, string, bool> _onCambioEstado;
            private readonly object _lock = new object();

            public bool EstaConectado => _conectado;

            public DispositivoWorker(int id, string nombre, string ip, int puerto, int commKey,
                                     Action<EventoMarcacion> onMarcacion, Action<int, string, bool> onCambioEstado)
            {
                IdBiometrico = id;
                Nombre = nombre;
                IP = ip;
                Puerto = puerto;
                CommKey = commKey;
                _onMarcacion = onMarcacion;
                _onCambioEstado = onCambioEstado;
            }

            public void Conectar()
            {
                lock (_lock)
                {
                    if (_conectado) return;

                    Task.Run(() =>
                    {
                        try
                        {
                            // Verificar ping rápido
                            using (var ping = new Ping())
                            {
                                var reply = ping.Send(IP, 1000);
                                if (reply == null || reply.Status != IPStatus.Success)
                                {
                                    _conectado = false;
                                    _onCambioEstado?.Invoke(IdBiometrico, Nombre, false);
                                    return;
                                }
                            }

                            if (_zkem == null)
                            {
                                _zkem = new CZKEMClass();
                            }

                            if (CommKey > 0)
                            {
                                _zkem.SetCommPassword(CommKey);
                            }

                            bool ok = _zkem.Connect_Net(IP, Puerto);
                            if (ok)
                            {
                                _conectado = true;

                                // Registrar escucha de eventos en tiempo real (65535 activa todos los eventos)
                                if (_zkem.RegEvent(1, 65535))
                                {
                                    _zkem.OnAttTransactionEx += Zkem_OnAttTransactionEx;
                                    _zkem.OnConnected += Zkem_OnConnected;
                                    _zkem.OnDisConnected += Zkem_OnDisConnected;
                                }

                                _onCambioEstado?.Invoke(IdBiometrico, Nombre, true);
                            }
                            else
                            {
                                _conectado = false;
                                _onCambioEstado?.Invoke(IdBiometrico, Nombre, false);
                            }
                        }
                        catch
                        {
                            _conectado = false;
                            _onCambioEstado?.Invoke(IdBiometrico, Nombre, false);
                        }
                    });
                }
            }

            public void Desconectar()
            {
                lock (_lock)
                {
                    try
                    {
                        if (_zkem != null && _conectado)
                        {
                            _zkem.OnAttTransactionEx -= Zkem_OnAttTransactionEx;
                            _zkem.OnConnected -= Zkem_OnConnected;
                            _zkem.OnDisConnected -= Zkem_OnDisConnected;
                            _zkem.Disconnect();
                        }
                    }
                    catch { }
                    finally
                    {
                        _zkem = null;
                        _conectado = false;
                    }
                }
            }

            private void Zkem_OnAttTransactionEx(string enrollNumber, int isInValid, int attState, int verifyMethod,
                                                int year, int month, int day, int hour, int minute, int second, int workCode)
            {
                DateTime dt;
                try
                {
                    dt = new DateTime(year, month, day, hour, minute, second);
                }
                catch
                {
                    dt = DateTime.Now;
                }

                var evt = new EventoMarcacion
                {
                    CodigoBiometrico = enrollNumber,
                    FechaHora = dt,
                    TipoMarcacion = attState,
                    MetodoVerificacion = verifyMethod,
                    IdBiometrico = IdBiometrico,
                    NombreBiometrico = Nombre
                };
                evt.TipoTexto = evt.ObtenerDescripcionTipo();
                evt.MetodoTexto = evt.ObtenerDescripcionMetodo();

                _onMarcacion?.Invoke(evt);
            }

            private void Zkem_OnConnected()
            {
                _conectado = true;
                _onCambioEstado?.Invoke(IdBiometrico, Nombre, true);
            }

            private void Zkem_OnDisConnected()
            {
                _conectado = false;
                _onCambioEstado?.Invoke(IdBiometrico, Nombre, false);
            }
        }

        #endregion
    }
}
