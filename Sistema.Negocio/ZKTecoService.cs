using System;
using System.Collections.Generic;
using Sistema.Entidades;
using zkemkeeper;

namespace Sistema.Negocio
{
    public class ZKTecoService : IDisposable
    {
        private CZKEMClass _zkem;
        private bool _isConnected = false;
        private int _machineNumber = 1;

        public bool IsConnected => _isConnected;
        public int MachineNumber
        {
            get => _machineNumber;
            set => _machineNumber = value;
        }

        public delegate void MarcacionRealTimeHandler(string enrollNumber, int verifyMode, int inOutMode, int year, int month, int day, int hour, int minute, int second, int workCode);
        public event MarcacionRealTimeHandler OnMarcacionRecibida;

        public delegate void DispositivoDesconectadoHandler();
        public event DispositivoDesconectadoHandler OnDispositivoDesconectado;

        public ZKTecoService()
        {
            try
            {
                _zkem = new CZKEMClass();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar el SDK de ZKTeco (ActiveX CZKEMClass). Asegúrese de compilar en x86 y tener las DLLs del SDK en la ruta de ejecución: " + ex.Message);
            }
        }

        #region Conexión y Desconexión

        public bool Conectar(string ip, out string mensaje)
        {
            return Conectar(ip, 4370, 0, out mensaje);
        }

        public bool Conectar(string ip, int puerto, int commKey, out string mensaje)
        {
            mensaje = "";
            try
            {
                if (_isConnected)
                {
                    Desconectar();
                }

                if (puerto <= 0) puerto = 4370;

                if (!string.IsNullOrWhiteSpace(ip) && ip.Contains("/"))
                {
                    ip = ip.Split('/')[0].Trim();
                }

                if (commKey > 0)
                {
                    _zkem.SetCommPassword(commKey);
                }

                _isConnected = _zkem.Connect_Net(ip.Trim(), puerto);

                if (_isConnected)
                {
                    if (_zkem.RegEvent(_machineNumber, 65535))
                    {
                        _zkem.OnAttTransactionEx += Zkem_OnAttTransactionEx;
                        _zkem.OnDisConnected += Zkem_OnDisConnected;
                    }

                    mensaje = $"Conectado exitosamente al biométrico en {ip}:{puerto}";
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = $"No se pudo conectar al biométrico. Código de error SDK: {errorCode} - {ObtenerDescripcionError(errorCode)}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _isConnected = false;
                mensaje = "Excepción al conectar: " + ex.Message;
                return false;
            }
        }

        public void Desconectar()
        {
            try
            {
                if (_isConnected && _zkem != null)
                {
                    _zkem.Disconnect();
                    _isConnected = false;
                }
            }
            catch
            {
                _isConnected = false;
            }
        }

        private void Zkem_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            OnMarcacionRecibida?.Invoke(EnrollNumber, VerifyMethod, AttState, Year, Month, Day, Hour, Minute, Second, WorkCode);
        }

        private void Zkem_OnDisConnected()
        {
            _isConnected = false;
            OnDispositivoDesconectado?.Invoke();
        }

        #endregion

        #region Información del Dispositivo

        public Dictionary<string, string> ObtenerInformacionDispositivo()
        {
            var info = new Dictionary<string, string>();
            if (!_isConnected) return info;

            try
            {
                string sn = "";
                _zkem.GetSerialNumber(_machineNumber, out sn);
                info["NumeroSerie"] = sn;

                string versionFirmware = "";
                _zkem.GetFirmwareVersion(_machineNumber, ref versionFirmware);
                info["Firmware"] = versionFirmware;

                string productCode = "";
                _zkem.GetProductCode(_machineNumber, out productCode);
                info["Modelo"] = productCode;

                string mac = "";
                _zkem.GetDeviceMAC(_machineNumber, ref mac);
                info["MAC"] = mac;

                string platform = "";
                _zkem.GetPlatform(_machineNumber, ref platform);
                info["Plataforma"] = platform;

                int adminCount = 0, userCount = 0, fpCount = 0, pwCount = 0, recordCount = 0;
                _zkem.GetDeviceStatus(_machineNumber, 1, ref adminCount);
                _zkem.GetDeviceStatus(_machineNumber, 2, ref userCount);
                _zkem.GetDeviceStatus(_machineNumber, 3, ref fpCount);
                _zkem.GetDeviceStatus(_machineNumber, 4, ref pwCount);
                _zkem.GetDeviceStatus(_machineNumber, 6, ref recordCount);

                info["CantidadUsuarios"] = userCount.ToString();
                info["CantidadAdministradores"] = adminCount.ToString();
                info["CantidadHuellas"] = fpCount.ToString();
                info["CantidadLogs"] = recordCount.ToString();
            }
            catch (Exception ex)
            {
                info["Error"] = ex.Message;
            }

            return info;
        }

        public bool SincronizarHoraDispositivo(out string mensaje)
        {
            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return false;
            }

            try
            {
                if (_zkem.SetDeviceTime(_machineNumber))
                {
                    _zkem.RefreshData(_machineNumber);
                    mensaje = "Hora del biométrico sincronizada con éxito a " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = "Error al sincronizar hora. Código SDK: " + errorCode;
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al sincronizar hora: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region Gestión de Usuarios / Empleados

        public List<Empleado> DescargarUsuarios(out string mensaje)
        {
            var lista = new List<Empleado>();
            mensaje = "";

            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return lista;
            }

            try
            {
                _zkem.EnableDevice(_machineNumber, false);

                if (_zkem.ReadAllUserID(_machineNumber))
                {
                    string enrollNumber = "";
                    string name = "";
                    string password = "";
                    int privilege = 0;
                    bool enabled = false;

                    while (_zkem.SSR_GetAllUserInfo(_machineNumber, out enrollNumber, out name, out password, out privilege, out enabled))
                    {
                        string cardNumber = "";
                        _zkem.GetStrCardNumber(out cardNumber);

                        lista.Add(new Empleado
                        {
                            CodigoBiometrico = enrollNumber,
                            Nombre = string.IsNullOrWhiteSpace(name) ? "Usuario " + enrollNumber : name.Trim(),
                            PasswordBiometrico = password,
                            Privilegio = privilege,
                            Habilitado = enabled,
                            TarjetaRFID = cardNumber,
                            FechaRegistro = DateTime.Now
                        });
                    }

                    mensaje = $"Se descargaron {lista.Count} usuarios desde el biométrico.";
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = "Error al leer usuarios del biométrico. Código SDK: " + errorCode;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al descargar usuarios: " + ex.Message;
            }
            finally
            {
                _zkem.EnableDevice(_machineNumber, true);
            }

            return lista;
        }

        public bool SubirUsuario(string codigoBiometrico, string nombre, string password, int privilegio, bool habilitado, string tarjetaRFID, out string mensaje)
        {
            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return false;
            }

            try
            {
                _zkem.EnableDevice(_machineNumber, false);

                if (!string.IsNullOrWhiteSpace(tarjetaRFID))
                {
                    _zkem.SetStrCardNumber(tarjetaRFID.Trim());
                }

                if (_zkem.SSR_SetUserInfo(_machineNumber, codigoBiometrico.Trim(), nombre.Trim(), password ?? "", privilegio, habilitado))
                {
                    _zkem.RefreshData(_machineNumber);
                    mensaje = "Usuario sincronizado correctamente en el dispositivo biométrico.";
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = $"Error al enviar usuario al biométrico. Código SDK: {errorCode} - {ObtenerDescripcionError(errorCode)}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al subir usuario: " + ex.Message;
                return false;
            }
            finally
            {
                _zkem.EnableDevice(_machineNumber, true);
            }
        }

        public bool EliminarUsuario(string codigoBiometrico, out string mensaje)
        {
            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return false;
            }

            try
            {
                _zkem.EnableDevice(_machineNumber, false);

                if (_zkem.SSR_DeleteEnrollDataExt(_machineNumber, codigoBiometrico.Trim(), 12))
                {
                    _zkem.RefreshData(_machineNumber);
                    mensaje = "Usuario y credenciales eliminados con éxito del biométrico.";
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = "Error al eliminar usuario. Código SDK: " + errorCode;
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al eliminar usuario: " + ex.Message;
                return false;
            }
            finally
            {
                _zkem.EnableDevice(_machineNumber, true);
            }
        }

        #endregion

        #region Descarga y Gestión de Asistencias (Logs)

        public List<Asistencia> DescargarMarcaciones(int? idBiometrico, string nombreBiometrico, DateTime? fechaDesde, out string mensaje)
        {
            return DescargarMarcacionesConProgreso(idBiometrico, nombreBiometrico, fechaDesde, null, System.Threading.CancellationToken.None, out mensaje);
        }

        public List<Asistencia> DescargarMarcacionesConProgreso(
            int? idBiometrico, 
            string nombreBiometrico, 
            DateTime? fechaDesde, 
            IProgress<ProgresoSync> progreso, 
            System.Threading.CancellationToken ct, 
            out string mensaje)
        {
            var lista = new List<Asistencia>();
            mensaje = "";

            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return lista;
            }

            try
            {
                int totalEnReloj = 0;
                _zkem.GetDeviceStatus(_machineNumber, 6, ref totalEnReloj);

                progreso?.Report(new ProgresoSync
                {
                    Porcentaje = 5,
                    Fase = "Leyendo del Reloj Biométrico",
                    RegistrosActuales = 0,
                    RegistrosTotales = totalEnReloj,
                    NombreBiometrico = nombreBiometrico,
                    Estado = string.Format("Conectado. Memoria del reloj: {0:N0} marcaciones registradas.", totalEnReloj)
                });

                _zkem.EnableDevice(_machineNumber, false);

                bool leido = false;
                if (fechaDesde.HasValue)
                {
                    DateTime dt = fechaDesde.Value;
                    leido = _zkem.ReadLastestLogData(_machineNumber, 1, dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                }

                if (!leido)
                {
                    leido = _zkem.ReadGeneralLogData(_machineNumber);
                }

                if (leido)
                {
                    string enrollNumber = "";
                    int verifyMode = 0;
                    int inOutMode = 0;
                    int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
                    int workCode = 0;
                    int contador = 0;

                    while (_zkem.SSR_GetGeneralLogData(_machineNumber, out enrollNumber, out verifyMode, out inOutMode, out year, out month, out day, out hour, out minute, out second, ref workCode))
                    {
                        if (ct.IsCancellationRequested) break;

                        contador++;
                        DateTime fechaHora;
                        try
                        {
                            fechaHora = new DateTime(year, month, day, hour, minute, second);
                        }
                        catch
                        {
                            continue;
                        }

                        if (fechaDesde.HasValue && fechaHora <= fechaDesde.Value)
                        {
                            continue;
                        }

                        lista.Add(new Asistencia
                        {
                            CodigoBiometrico = enrollNumber,
                            FechaHora = fechaHora,
                            TipoMarcacion = inOutMode,
                            MetodoVerificacion = verifyMode,
                            IdBiometrico = idBiometrico,
                            NombreBiometrico = nombreBiometrico,
                            FechaRegistro = DateTime.Now
                        });

                        int reportInterval = totalEnReloj > 500 ? (totalEnReloj / 100) : 5;
                        if (contador % reportInterval == 0 || contador == totalEnReloj)
                        {
                            int pct = totalEnReloj > 0 ? (5 + (int)((contador / (double)totalEnReloj) * 45)) : 25;
                            progreso?.Report(new ProgresoSync
                            {
                                Porcentaje = Math.Min(pct, 50),
                                Fase = "Leyendo del Reloj Biométrico",
                                RegistrosActuales = contador,
                                RegistrosTotales = totalEnReloj > 0 ? totalEnReloj : contador,
                                NombreBiometrico = nombreBiometrico,
                                Estado = string.Format("Leyendo del reloj: {0:N0} de {1:N0} marcaciones...", contador, totalEnReloj > 0 ? totalEnReloj : contador)
                            });
                        }
                    }

                    mensaje = string.Format("Se leyeron {0:N0} registros de marcación desde el biométrico.", lista.Count);
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    if (errorCode == 0)
                    {
                        mensaje = "No hay nuevos registros de asistencia en el biométrico.";
                    }
                    else
                    {
                        mensaje = string.Format("Error al leer marcaciones. Código SDK: {0} - {1}", errorCode, ObtenerDescripcionError(errorCode));
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al descargar marcaciones: " + ex.Message;
            }
            finally
            {
                _zkem.EnableDevice(_machineNumber, true);
            }

            return lista;
        }

        public List<Asistencia> DescargarMarcaciones(int? idBiometrico, string nombreBiometrico, out string mensaje)
        {
            return DescargarMarcaciones(idBiometrico, nombreBiometrico, null, out mensaje);
        }

        public bool LimpiarMarcaciones(out string mensaje)
        {
            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return false;
            }

            try
            {
                _zkem.EnableDevice(_machineNumber, false);

                if (_zkem.ClearGLog(_machineNumber))
                {
                    _zkem.RefreshData(_machineNumber);
                    mensaje = "Registros de marcaciones borrados con éxito del biométrico.";
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = "Error al borrar registros. Código SDK: " + errorCode;
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al borrar marcaciones: " + ex.Message;
                return false;
            }
            finally
            {
                _zkem.EnableDevice(_machineNumber, true);
            }
        }

        #endregion

        #region Comandos de Control

        public bool ReiniciarDispositivo(out string mensaje)
        {
            if (!_isConnected)
            {
                mensaje = "El dispositivo no está conectado.";
                return false;
            }

            try
            {
                if (_zkem.RestartDevice(_machineNumber))
                {
                    _isConnected = false;
                    mensaje = "Comando de reinicio enviado exitosamente al biométrico.";
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    _zkem.GetLastError(ref errorCode);
                    mensaje = "Error al reiniciar el biométrico. Código SDK: " + errorCode;
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Excepción al reiniciar dispositivo: " + ex.Message;
                return false;
            }
        }

        public bool EmitirPitido(int delayMs = 100)
        {
            if (!_isConnected) return false;
            try
            {
                return _zkem.Beep(delayMs);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Utilidades y Códigos de Error

        private string ObtenerDescripcionError(int errorCode)
        {
            switch (errorCode)
            {
                case 1: return "Operación exitosa";
                case 0: return "Operación fallida / Sin respuesta";
                case -1: return "Error en la librería SDK o argumentos inválidos";
                case -2: return "Dispositivo ocupado o no responde";
                case -3: return "Error de memoria en el dispositivo";
                case -4: return "Longitud de datos inválida";
                case -5: return "Comando no soportado por este modelo";
                case -100: return "No conectado al dispositivo";
                default: return "Error no documentado en el SDK";
            }
        }

        public void Dispose()
        {
            Desconectar();
            _zkem = null;
        }

        #endregion
    }
}
