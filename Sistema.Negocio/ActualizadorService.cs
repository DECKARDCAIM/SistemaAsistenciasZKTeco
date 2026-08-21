using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class InfoVersion
    {
        public string VersionActual { get; set; }
        public string VersionNueva { get; set; }
        public bool HayActualizacion { get; set; }
        public string TituloRelease { get; set; }
        public string NotasVersion { get; set; }
        public string UrlDescarga { get; set; }
        public long TamanoBytes { get; set; }
        public string NombreArchivo { get; set; }
    }

    public class ProgresoDescarga
    {
        public long BytesRecibidos { get; set; }
        public long BytesTotales { get; set; }
        public int Porcentaje { get; set; }
        public double VelocidadMBs { get; set; }
    }

    public class ActualizadorService
    {
        private readonly string _repoOwner;
        private readonly string _repoName;

        public ActualizadorService(string repoOwner = null, string repoName = null)
        {
            // Leer de App.config o valores por defecto
            _repoOwner = repoOwner ?? ConfigurationManager.AppSettings["GitHub_RepoOwner"] ?? "HospitalElProgreso";
            _repoName = repoName ?? ConfigurationManager.AppSettings["GitHub_RepoName"] ?? "SistemaAsistenciasZKTeco";
        }

        public string ObtenerVersionActual()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }

        public async Task<InfoVersion> VerificarActualizacionAsync()
        {
            var info = new InfoVersion
            {
                VersionActual = ObtenerVersionActual(),
                HayActualizacion = false
            };

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string apiUrl = string.Format("https://api.github.com/repos/{0}/{1}/releases/latest", _repoOwner, _repoName);

                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "SistemaAsistenciasZKTeco-Updater");
                    client.Headers.Add("Accept", "application/vnd.github.v3+json");

                    string json = await client.DownloadStringTaskAsync(new Uri(apiUrl));

                    // Extraer tag_name (ej: "v1.0.1" o "1.0.1")
                    var matchTag = Regex.Match(json, "\"tag_name\"\\s*:\\s*\"([^\"]+)\"");
                    if (matchTag.Success)
                    {
                        string rawTag = matchTag.Groups[1].Value.TrimStart('v', 'V');
                        info.VersionNueva = rawTag;

                        // Extraer nombre de la release
                        var matchName = Regex.Match(json, "\"name\"\\s*:\\s*\"([^\"]+)\"");
                        info.TituloRelease = matchName.Success ? matchName.Groups[1].Value : "Actualización " + rawTag;

                        // Extraer notas de versión (body)
                        var matchBody = Regex.Match(json, "\"body\"\\s*:\\s*\"([^\"]*)\"");
                        if (matchBody.Success)
                        {
                            info.NotasVersion = Regex.Unescape(matchBody.Groups[1].Value);
                        }

                        // Extraer URL de descarga del asset (.zip o .exe)
                        var matchUrl = Regex.Match(json, "\"browser_download_url\"\\s*:\\s*\"([^\"]+\\.(zip|exe))\"");
                        if (matchUrl.Success)
                        {
                            info.UrlDescarga = matchUrl.Groups[1].Value;
                            info.NombreArchivo = Path.GetFileName(info.UrlDescarga);
                        }
                        else
                        {
                            // Si no hay asset zip adjunto, usar zipballUrl
                            var matchZipball = Regex.Match(json, "\"zipball_url\"\\s*:\\s*\"([^\"]+)\"");
                            if (matchZipball.Success)
                            {
                                info.UrlDescarga = matchZipball.Groups[1].Value;
                                info.NombreArchivo = string.Format("Update_v{0}.zip", rawTag);
                            }
                        }

                        // Comparar versiones
                        info.HayActualizacion = EsVersionSuperior(rawTag, info.VersionActual);
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response is HttpWebResponse resp && resp.StatusCode == HttpStatusCode.NotFound)
                {
                    // No hay releases publicadas aún
                    info.HayActualizacion = false;
                }
                else
                {
                    throw new Exception("No se pudo contactar al servidor de actualizaciones de GitHub: " + wex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar actualizaciones: " + ex.Message);
            }

            return info;
        }

        public async Task<string> DescargarActualizacionAsync(
            string urlDescarga, 
            string nombreArchivo, 
            IProgress<ProgresoDescarga> progreso, 
            CancellationToken ct)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "SistemaAsistencias_Updates");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            string destinoArchivo = Path.Combine(tempDir, nombreArchivo);
            if (File.Exists(destinoArchivo))
            {
                try { File.Delete(destinoArchivo); } catch { }
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var request = (HttpWebRequest)WebRequest.Create(urlDescarga);
            request.UserAgent = "SistemaAsistenciasZKTeco-Updater";
            request.Timeout = 60000;

            using (var response = await request.GetResponseAsync())
            using (var responseStream = response.GetResponseStream())
            using (var fileStream = new FileStream(destinoArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                long totalBytes = response.ContentLength;
                byte[] buffer = new byte[81920]; // 80 KB
                long bytesLeidosTotal = 0;
                int bytesLeidos;

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                while ((bytesLeidos = await responseStream.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
                {
                    if (ct.IsCancellationRequested)
                    {
                        fileStream.Close();
                        try { File.Delete(destinoArchivo); } catch { }
                        throw new OperationCanceledException();
                    }

                    await fileStream.WriteAsync(buffer, 0, bytesLeidos, ct);
                    bytesLeidosTotal += bytesLeidos;

                    double segundos = stopwatch.Elapsed.TotalSeconds;
                    double velocidadMBs = segundos > 0 ? (bytesLeidosTotal / (1024.0 * 1024.0)) / segundos : 0;
                    int pct = totalBytes > 0 ? (int)((bytesLeidosTotal / (double)totalBytes) * 100) : 50;

                    progreso?.Report(new ProgresoDescarga
                    {
                        BytesRecibidos = bytesLeidosTotal,
                        BytesTotales = totalBytes,
                        Porcentaje = Math.Min(pct, 100),
                        VelocidadMBs = velocidadMBs
                    });
                }
            }

            return destinoArchivo;
        }

        private bool EsVersionSuperior(string versionNuevaStr, string versionActualStr)
        {
            try
            {
                Version vNueva = NormalizarVersion(versionNuevaStr);
                Version vActual = NormalizarVersion(versionActualStr);
                return vNueva > vActual;
            }
            catch
            {
                return false;
            }
        }

        private Version NormalizarVersion(string vStr)
        {
            vStr = Regex.Replace(vStr, @"[^\d.]", "");
            string[] partes = vStr.Split('.');
            if (partes.Length == 1) return new Version(int.Parse(partes[0]), 0, 0, 0);
            if (partes.Length == 2) return new Version(int.Parse(partes[0]), int.Parse(partes[1]), 0, 0);
            if (partes.Length == 3) return new Version(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]), 0);
            return new Version(vStr);
        }
    }
}
