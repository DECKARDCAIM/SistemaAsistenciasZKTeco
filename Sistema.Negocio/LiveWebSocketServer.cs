using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    /// <summary>
    /// Servidor WebSocket ligero basado en HttpListener de .NET Framework.
    /// Emite los marcajes en tiempo real a clientes Web, Dashboards o aplicaciones remotas.
    /// </summary>
    public class LiveWebSocketServer
    {
        private static readonly Lazy<LiveWebSocketServer> _instance = new Lazy<LiveWebSocketServer>(() => new LiveWebSocketServer());
        public static LiveWebSocketServer Instancia => _instance.Value;

        private HttpListener _listener;
        private readonly ConcurrentDictionary<Guid, WebSocket> _clientes = new ConcurrentDictionary<Guid, WebSocket>();
        private CancellationTokenSource _cts;
        private bool _estaCorriendo = false;
        private int _puerto = 8181;

        public bool EstaCorriendo => _estaCorriendo;

        private LiveWebSocketServer() { }

        public void Iniciar(int puerto = 8181)
        {
            if (_estaCorriendo) return;
            _puerto = puerto;

            try
            {
                _cts = new CancellationTokenSource();
                _listener = new HttpListener();
                _listener.Prefixes.Add(string.Format("http://*:{0}/asistencias/", _puerto));
                _listener.Start();
                _estaCorriendo = true;

                // Conectar al evento de marcación del listener en vivo
                ZKTecoLiveListener.Instancia.OnMarcacionRecibida += TransmitirMarcacion;

                Task.Run(() => EscucharPeticionesAsync(_cts.Token));
            }
            catch
            {
                // Si falta permiso de URL ACL para *, intentar con localhost
                try
                {
                    _listener = new HttpListener();
                    _listener.Prefixes.Add(string.Format("http://localhost:{0}/asistencias/", _puerto));
                    _listener.Start();
                    _estaCorriendo = true;
                    ZKTecoLiveListener.Instancia.OnMarcacionRecibida += TransmitirMarcacion;
                    Task.Run(() => EscucharPeticionesAsync(_cts.Token));
                }
                catch { }
            }
        }

        public void Detener()
        {
            if (!_estaCorriendo) return;
            _estaCorriendo = false;
            ZKTecoLiveListener.Instancia.OnMarcacionRecibida -= TransmitirMarcacion;

            _cts?.Cancel();
            try
            {
                _listener?.Stop();
                _listener?.Close();
            }
            catch { }

            foreach (var kvp in _clientes)
            {
                try
                {
                    kvp.Value.Dispose();
                }
                catch { }
            }
            _clientes.Clear();
        }

        private async Task EscucharPeticionesAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && _listener != null && _listener.IsListening)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        ProcesarConexionWebSocket(context);
                    }
                    else
                    {
                        // Responder información de estado en HTTP simple
                        string jsonInfo = string.Format(
                            "{{\"estado\":\"Servidor WebSocket Activo\",\"servicio\":\"Hospital de El Progreso - ZKTeco Live Hub\",\"clientes_conectados\":{0},\"hora_servidor\":\"{1}\"}}",
                            _clientes.Count, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        byte[] response = Encoding.UTF8.GetBytes(jsonInfo);
                        context.Response.ContentType = "application/json";
                        context.Response.ContentLength64 = response.Length;
                        await context.Response.OutputStream.WriteAsync(response, 0, response.Length);
                        context.Response.OutputStream.Close();
                    }
                }
                catch
                {
                    if (ct.IsCancellationRequested) break;
                }
            }
        }

        private async void ProcesarConexionWebSocket(HttpListenerContext context)
        {
            try
            {
                var wsContext = await context.AcceptWebSocketAsync(null);
                var socket = wsContext.WebSocket;
                Guid id = Guid.NewGuid();
                _clientes.TryAdd(id, socket);

                // Enviar mensaje de bienvenida
                string jsonWelcome = string.Format(
                    "{{\"tipo\":\"CONEXION_ESTABLECIDA\",\"mensaje\":\"Conectado al Hub en Tiempo Real ZKTeco\",\"cliente_id\":\"{0}\",\"fecha\":\"{1}\"}}",
                    id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                byte[] welcome = Encoding.UTF8.GetBytes(jsonWelcome);
                await socket.SendAsync(new ArraySegment<byte>(welcome), WebSocketMessageType.Text, true, CancellationToken.None);

                byte[] buffer = new byte[1024];
                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cerrado", CancellationToken.None);
                    }
                }

                _clientes.TryRemove(id, out _);
            }
            catch
            { }
        }

        public void TransmitirMarcacion(EventoMarcacion evt)
        {
            if (!_estaCorriendo || _clientes.IsEmpty) return;

            string json = string.Format(
                "{{\"tipo\":\"NUEVA_MARCACION\",\"codigo\":\"{0}\",\"empleado\":\"{1}\",\"fecha_hora\":\"{2}\",\"tipo_marcacion\":\"{3}\",\"metodo\":\"{4}\",\"reloj\":\"{5}\",\"id_reloj\":{6}}}",
                EscapeJson(evt.CodigoBiometrico),
                EscapeJson(evt.NombreEmpleado ?? ""),
                evt.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"),
                EscapeJson(evt.TipoTexto ?? ""),
                EscapeJson(evt.MetodoTexto ?? ""),
                EscapeJson(evt.NombreBiometrico ?? ""),
                evt.IdBiometrico.HasValue ? evt.IdBiometrico.Value.ToString() : "null"
            );

            byte[] data = Encoding.UTF8.GetBytes(json);

            foreach (var kvp in _clientes)
            {
                if (kvp.Value.State == WebSocketState.Open)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            await kvp.Value.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                        catch
                        {
                            _clientes.TryRemove(kvp.Key, out _);
                        }
                    });
                }
            }
        }

        private static string EscapeJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "");
        }
    }
}
