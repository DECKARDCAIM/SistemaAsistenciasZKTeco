using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    /// <summary>
    /// Servicio de Caché Inteligente y Mensajería Pub/Sub con soporte para Redis (RESP)
    /// y respaldo automático en memoria (In-Memory Fallback) si Redis no está disponible.
    /// </summary>
    public class RedisCacheService
    {
        private static readonly Lazy<RedisCacheService> _instance = new Lazy<RedisCacheService>(() => new RedisCacheService());
        public static RedisCacheService Instancia => _instance.Value;

        private readonly string _redisHost;
        private readonly int _redisPort;
        private bool _redisDisponible = false;
        private readonly object _lock = new object();

        // Almacenamiento en memoria para Fallback
        private readonly ConcurrentDictionary<string, CacheEntry> _memCache = new ConcurrentDictionary<string, CacheEntry>();
        private readonly ConcurrentDictionary<string, List<Action<string>>> _localSubscribers = new ConcurrentDictionary<string, List<Action<string>>>();

        private class CacheEntry
        {
            public string JsonData { get; set; }
            public DateTime Expira { get; set; }
            public bool HaExpirado => DateTime.Now > Expira;
        }

        private RedisCacheService()
        {
            _redisHost = ConfigurationManager.AppSettings["RedisHost"] ?? "127.0.0.1";
            if (!int.TryParse(ConfigurationManager.AppSettings["RedisPort"], out _redisPort))
            {
                _redisPort = 6379;
            }

            // Probar conexión inicial con Redis en segundo plano
            Task.Run(() => ProbarConexionRedis());
        }

        public bool EsRedisActivo => _redisDisponible;

        private void ProbarConexionRedis()
        {
            try
            {
                using (var tcp = new TcpClient())
                {
                    var result = tcp.BeginConnect(_redisHost, _redisPort, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(1500, true);
                    if (success && tcp.Connected)
                    {
                        using (var stream = tcp.GetStream())
                        {
                            byte[] cmd = Encoding.UTF8.GetBytes("*1\r\n$4\r\nPING\r\n");
                            stream.Write(cmd, 0, cmd.Length);
                            stream.ReadTimeout = 1500;
                            byte[] buffer = new byte[64];
                            int read = stream.Read(buffer, 0, buffer.Length);
                            string resp = Encoding.UTF8.GetString(buffer, 0, read);
                            _redisDisponible = resp.Contains("PONG");
                        }
                    }
                    else
                    {
                        _redisDisponible = false;
                    }
                }
            }
            catch
            {
                _redisDisponible = false;
            }
        }

        #region Métodos de Caché (Get / Set / Invalidate)

        /// <summary>
        /// Obtiene un elemento en caché o lo genera mediante la función factory.
        /// </summary>
        public T GetOrSet<T>(string key, Func<T> factory, TimeSpan? ttl = null)
        {
            TimeSpan tiempoVida = ttl ?? TimeSpan.FromHours(12);

            // 1. Intentar obtener de Redis si está disponible
            if (_redisDisponible)
            {
                try
                {
                    string redisValue = EjecutarComandoRedisString($"GET {key}");
                    if (!string.IsNullOrEmpty(redisValue) && redisValue != "nil")
                    {
                        return JsonSerializer.Deserialize<T>(redisValue);
                    }
                }
                catch
                {
                    _redisDisponible = false;
                }
            }

            // 2. Intentar obtener de caché local
            if (_memCache.TryGetValue(key, out var entry) && !entry.HaExpirado)
            {
                try
                {
                    return JsonSerializer.Deserialize<T>(entry.JsonData);
                }
                catch { }
            }

            // 3. Si no existe, invocar la función de base de datos
            T valor = factory();
            if (valor != null)
            {
                Set(key, valor, tiempoVida);
            }
            return valor;
        }

        /// <summary>
        /// Guarda un valor serializado en caché con tiempo de expiración.
        /// </summary>
        public void Set<T>(string key, T valor, TimeSpan? ttl = null)
        {
            if (valor == null) return;
            TimeSpan tiempoVida = ttl ?? TimeSpan.FromHours(12);
            string json = JsonSerializer.Serialize(valor);

            // Guardar en memoria
            _memCache[key] = new CacheEntry
            {
                JsonData = json,
                Expira = DateTime.Now.Add(tiempoVida)
            };

            // Guardar en Redis si está activo
            if (_redisDisponible)
            {
                try
                {
                    int segundos = (int)tiempoVida.TotalSeconds;
                    EjecutarComandoRedis($"SETEX {key} {segundos} {json}");
                }
                catch
                {
                    _redisDisponible = false;
                }
            }
        }

        /// <summary>
        /// Invalida una o varias llaves de caché por prefijo o coincidencia.
        /// </summary>
        public void InvalidarPrefijo(string prefijo)
        {
            // Limpiar memoria
            var keysAEliminar = new List<string>();
            foreach (var k in _memCache.Keys)
            {
                if (k.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
                {
                    keysAEliminar.Add(k);
                }
            }
            foreach (var k in keysAEliminar)
            {
                _memCache.TryRemove(k, out _);
            }

            // Limpiar en Redis
            if (_redisDisponible)
            {
                try
                {
                    EjecutarComandoRedis($"EVAL \"for _,k in ipairs(redis.call('keys','{prefijo}*')) do redis.call('del',k) end\" 0");
                }
                catch
                {
                    _redisDisponible = false;
                }
            }
        }

        #endregion

        #region Pub / Sub (Tiempo Real)

        /// <summary>
        /// Publica un evento en el canal Redis y en los suscriptores locales.
        /// </summary>
        public void Publicar(string canal, object payload)
        {
            string json = payload is string str ? str : JsonSerializer.Serialize(payload);

            // 1. Notificar suscriptores locales
            if (_localSubscribers.TryGetValue(canal, out var lista))
            {
                lock (lista)
                {
                    foreach (var accion in lista)
                    {
                        try
                        {
                            accion(json);
                        }
                        catch { }
                    }
                }
            }

            // 2. Publicar en Redis Pub/Sub
            if (_redisDisponible)
            {
                try
                {
                    EjecutarComandoRedis($"PUBLISH {canal} {json}");
                }
                catch
                {
                    _redisDisponible = false;
                }
            }
        }

        /// <summary>
        /// Se suscribe a un canal de eventos en tiempo real.
        /// </summary>
        public void Suscribir(string canal, Action<string> onMensaje)
        {
            var lista = _localSubscribers.GetOrAdd(canal, _ => new List<Action<string>>());
            lock (lista)
            {
                if (!lista.Contains(onMensaje))
                {
                    lista.Add(onMensaje);
                }
            }
        }

        #endregion

        #region Comunicación Directa Redis (Protocolo RESP)

        private void EjecutarComandoRedis(string rawCommand)
        {
            using (var tcp = new TcpClient())
            {
                tcp.Connect(_redisHost, _redisPort);
                using (var stream = tcp.GetStream())
                {
                    string[] parts = rawCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder resp = new StringBuilder();
                    resp.AppendFormat("*{0}\r\n", parts.Length);
                    foreach (var p in parts)
                    {
                        byte[] pBytes = Encoding.UTF8.GetBytes(p);
                        resp.AppendFormat("${0}\r\n{1}\r\n", pBytes.Length, p);
                    }
                    byte[] data = Encoding.UTF8.GetBytes(resp.ToString());
                    stream.Write(data, 0, data.Length);
                }
            }
        }

        private string EjecutarComandoRedisString(string rawCommand)
        {
            using (var tcp = new TcpClient())
            {
                tcp.SendTimeout = 1500;
                tcp.ReceiveTimeout = 1500;
                tcp.Connect(_redisHost, _redisPort);
                using (var stream = tcp.GetStream())
                {
                    string[] parts = rawCommand.Split(new[] { ' ' }, 2);
                    StringBuilder resp = new StringBuilder();
                    resp.AppendFormat("*{0}\r\n", parts.Length);
                    foreach (var p in parts)
                    {
                        byte[] pBytes = Encoding.UTF8.GetBytes(p);
                        resp.AppendFormat("${0}\r\n{1}\r\n", pBytes.Length, p);
                    }
                    byte[] data = Encoding.UTF8.GetBytes(resp.ToString());
                    stream.Write(data, 0, data.Length);

                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string firstLine = reader.ReadLine();
                        if (string.IsNullOrEmpty(firstLine) || firstLine.StartsWith("$-1")) return null;
                        if (firstLine.StartsWith("$"))
                        {
                            return reader.ReadLine();
                        }
                        if (firstLine.StartsWith("+"))
                        {
                            return firstLine.Substring(1);
                        }
                        return null;
                    }
                }
            }
        }

        #endregion
    }
}
