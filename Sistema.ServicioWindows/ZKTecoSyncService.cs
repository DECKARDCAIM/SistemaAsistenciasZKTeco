using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.ServicioWindows
{
    public partial class ZKTecoSyncService : ServiceBase
    {
        private System.Threading.Timer _timerBarrido;
        private bool _estaEnProcesoBarrido = false;
        private readonly object _lockBarrido = new object();
        private const string EventSource = "ZKTecoAsistenciasHospital";
        private const string EventLogName = "Application";

        public ZKTecoSyncService()
        {
            InitializeComponent();
            ConfigurarEventLog();
        }

        private void ConfigurarEventLog()
        {
            try
            {
                if (!EventLog.SourceExists(EventSource))
                {
                    EventLog.CreateEventSource(EventSource, EventLogName);
                }
            }
            catch { }
        }

        private void RegistrarLog(string mensaje, EventLogEntryType tipo = EventLogEntryType.Information)
        {
            try
            {
                EventLog.WriteEntry(EventSource, mensaje, tipo);
            }
            catch { }
            Console.WriteLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss}] [{1}] {2}", DateTime.Now, tipo, mensaje));
        }

        protected override void OnStart(string[] args)
        {
            IniciarServicio();
        }

        public void IniciarServicio()
        {
            try
            {
                RegistrarLog("Iniciando Servicio de Sincronización ZKTeco - Hospital de El Progreso...");

                // 1. Iniciar Escucha de Eventos Push en Tiempo Real (<50ms)
                ZKTecoLiveListener.Instancia.Iniciar();
                ZKTecoLiveListener.Instancia.OnMarcacionRecibida += (evt) =>
                {
                    RegistrarLog(string.Format("Marcación en vivo recibida: Empleado {0} ({1}) en {2}",
                        evt.CodigoBiometrico, evt.NombreEmpleado, evt.NombreBiometrico));
                };

                // 2. Iniciar Servidor WebSocket (ws://localhost:8181/asistencias/)
                LiveWebSocketServer.Instancia.Iniciar(8181);

                // 3. Iniciar Barrido Periódico Preventivo (cada 10 minutos)
                // Realiza reconciliación, inserción con deduplicación y borrado seguro del reloj.
                _timerBarrido = new System.Threading.Timer(EjecutarBarridoPreventivo, null, TimeSpan.FromSeconds(30), TimeSpan.FromMinutes(10));

                RegistrarLog("Servicio iniciado correctamente. Monitoreando biométricos 24/7 y WebSocket en puerto 8181.");
            }
            catch (Exception ex)
            {
                RegistrarLog("Error al iniciar el servicio: " + ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            DetenerServicio();
        }

        public void DetenerServicio()
        {
            try
            {
                RegistrarLog("Deteniendo Servicio de Sincronización ZKTeco...");
                _timerBarrido?.Dispose();
                _timerBarrido = null;

                ZKTecoLiveListener.Instancia.Detener();
                LiveWebSocketServer.Instancia.Detener();

                RegistrarLog("Servicio detenido correctamente.");
            }
            catch (Exception ex)
            {
                RegistrarLog("Error al detener el servicio: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void EjecutarBarridoPreventivo(object state)
        {
            if (_estaEnProcesoBarrido) return;

            lock (_lockBarrido)
            {
                if (_estaEnProcesoBarrido) return;
                _estaEnProcesoBarrido = true;
            }

            Task.Run(() =>
            {
                try
                {
                    List<Biometrico> biometricos = N_Biometrico.ListarActivos();
                    if (biometricos == null || biometricos.Count == 0) return;

                    foreach (var bio in biometricos)
                    {
                        ProcesarSincronizacionYLimpiezaBiometrico(bio);
                    }
                }
                catch (Exception ex)
                {
                    RegistrarLog("Excepción en barrido preventivo: " + ex.Message, EventLogEntryType.Warning);
                }
                finally
                {
                    _estaEnProcesoBarrido = false;
                }
            });
        }

        private void ProcesarSincronizacionYLimpiezaBiometrico(Biometrico bio)
        {
            try
            {
                using (var service = new ZKTecoService())
                {
                    if (!service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out string msgConexion))
                    {
                        N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Desconectado");
                        return;
                    }

                    // 1. Descargar registros pendientes del reloj
                    List<Asistencia> marcaciones = service.DescargarMarcaciones(bio.IdBiometrico, bio.Nombre, null, out string msgDescarga);
                    int totalLeidos = marcaciones != null ? marcaciones.Count : 0;

                    if (totalLeidos > 0)
                    {
                        // 2. Guardar en PostgreSQL con deduplicación segura
                        int nuevosGuardados = N_Asistencia.GuardarMarcacionesMasivas(marcaciones, bio.IdBiometrico, bio.Nombre);
                        int duplicados = totalLeidos - nuevosGuardados;

                        // 3. SEGURIDAD: Solo si todos los registros ya residen en PostgreSQL, vaciamos la memoria del reloj
                        if (nuevosGuardados + duplicados == totalLeidos)
                        {
                            if (service.LimpiarMarcaciones(out string msgLimpieza))
                            {
                                RegistrarLog(string.Format(
                                    "Biométrico [{0}]: Sincronización completa. Leídos: {1}, Nuevos: {2}, Existentes: {3}. Memoria del reloj liberada.",
                                    bio.Nombre, totalLeidos, nuevosGuardados, duplicados));

                                // Actualizar contador en BD a 0
                                N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now, logs: 0);
                            }
                            else
                            {
                                RegistrarLog(string.Format("Biométrico [{0}]: Se guardó en BD pero falló al limpiar reloj: {1}", bio.Nombre, msgLimpieza), EventLogEntryType.Warning);
                                N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now);
                            }
                        }
                        else
                        {
                            RegistrarLog(string.Format("Biométrico [{0}]: No se purgó el reloj porque la verificación de registros no coincidió.", bio.Nombre), EventLogEntryType.Warning);
                        }
                    }
                    else
                    {
                        N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now, logs: 0);
                    }

                    service.Desconectar();
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(string.Format("Error al procesar biométrico [{0}]: {1}", bio.Nombre, ex.Message), EventLogEntryType.Warning);
            }
        }
    }
}
