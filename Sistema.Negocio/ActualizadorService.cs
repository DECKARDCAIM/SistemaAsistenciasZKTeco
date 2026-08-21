using System;
using System.Configuration;
using System.Diagnostics;
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
        public string TituloRelease { get; set; }
        public string NotasVersion { get; set; }
        public string UrlDescarga { get; set; }
        public bool HayActualizacion { get; set; }
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
            _repoOwner = repoOwner ?? ConfigurationManager.AppSettings["GitHub_RepoOwner"] ?? "DECKARDCAIM";
            _repoName = repoName ?? ConfigurationManager.AppSettings["GitHub_RepoName"] ?? "SistemaAsistenciasZKTeco";
        }

        public string ObtenerVersionActual()
        {
            try
            {
                // 1. Intentar leer version.json local
                string localJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
                if (File.Exists(localJsonPath))
                {
                    string localContent = File.ReadAllText(localJsonPath);
                    var match = Regex.Match(localContent, "\"version\"\\s*:\\s*\"([^\"]+)\"");
                    if (match.Success)
                    {
                        return match.Groups[1].Value.TrimStart('v', 'V');
                    }
                }
            }
            catch { }

            // 2. Fallback a version del ensamblado
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }

        public async Task<InfoVersion> VerificarActualizacionAsync()
        {
            string versionLocal = ObtenerVersionActual();
            var info = new InfoVersion
            {
                VersionActual = versionLocal,
                HayActualizacion = false
            };

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                
                string json = null;

                // 1. Intentar API directa de GitHub (sin cache CDN, tiempo real)
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Encoding = System.Text.Encoding.UTF8;
                        client.Headers.Add("User-Agent", "SistemaAsistenciasZKTeco-Updater");
                        client.Headers.Add("Accept", "application/vnd.github.v3.raw");
                        client.Headers.Add("Cache-Control", "no-cache");
                        string apiUrl = string.Format("https://api.github.com/repos/{0}/{1}/contents/version.json", _repoOwner, _repoName);
                        json = await client.DownloadStringTaskAsync(new Uri(apiUrl));
                    }
                }
                catch { }

                // 2. Fallbacks directos por raw URL
                if (string.IsNullOrEmpty(json))
                {
                    string[] urlsManifest = new string[]
                    {
                        string.Format("https://raw.githubusercontent.com/{0}/{1}/master/version.json", _repoOwner, _repoName),
                        string.Format("https://github.com/{0}/{1}/raw/master/version.json", _repoOwner, _repoName)
                    };

                    using (var client = new WebClient())
                    {
                        client.Encoding = System.Text.Encoding.UTF8;
                        client.Headers.Add("User-Agent", "SistemaAsistenciasZKTeco-Updater");
                        client.Headers.Add("Cache-Control", "no-cache");

                        foreach (string url in urlsManifest)
                        {
                            try
                            {
                                json = await client.DownloadStringTaskAsync(new Uri(url + "?t=" + DateTime.UtcNow.Ticks));
                                if (!string.IsNullOrEmpty(json)) break;
                            }
                            catch { }
                        }
                    }
                }

                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("No se pudo obtener la información de versiones desde GitHub. Verifique su conexión a Internet.");
                }

                // Extraer campos de version.json
                var matchVer = Regex.Match(json, "\"version\"\\s*:\\s*\"([^\"]+)\"");
                if (matchVer.Success)
                {
                    string rawVer = matchVer.Groups[1].Value.TrimStart('v', 'V');
                    info.VersionNueva = rawVer;

                    var matchTitulo = Regex.Match(json, "\"titulo\"\\s*:\\s*\"([^\"]+)\"");
                    info.TituloRelease = matchTitulo.Success ? matchTitulo.Groups[1].Value : "Actualización v" + rawVer;

                    var matchNotas = Regex.Match(json, "\"notas\"\\s*:\\s*\"([^\"]*)\"");
                    info.NotasVersion = matchNotas.Success ? Regex.Unescape(matchNotas.Groups[1].Value) : "";

                    var matchUrl = Regex.Match(json, "\"url_descarga\"\\s*:\\s*\"([^\"]+)\"");
                    info.UrlDescarga = matchUrl.Success ? matchUrl.Groups[1].Value : string.Format("https://raw.githubusercontent.com/{0}/{1}/master/Instalador/Update_latest.zip", _repoOwner, _repoName);

                    var matchArch = Regex.Match(json, "\"archivo\"\\s*:\\s*\"([^\"]+)\"");
                    info.NombreArchivo = matchArch.Success ? matchArch.Groups[1].Value : "Update_latest.zip";

                    // Comparar versiones
                    info.HayActualizacion = EsVersionSuperior(rawVer, versionLocal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar actualizaciones: " + ex.Message);
            }

            return info;
        }

        private bool EsVersionSuperior(string versionNueva, string versionActual)
        {
            try
            {
                Version vNueva = NormalizarVersion(versionNueva);
                Version vActual = NormalizarVersion(versionActual);
                return vNueva > vActual;
            }
            catch
            {
                return !string.Equals(versionNueva, versionActual, StringComparison.OrdinalIgnoreCase);
            }
        }

        private Version NormalizarVersion(string vStr)
        {
            if (string.IsNullOrEmpty(vStr)) return new Version(1, 0, 0);
            string[] partes = vStr.Split('.');
            int major = partes.Length > 0 && int.TryParse(partes[0], out int mj) ? mj : 1;
            int minor = partes.Length > 1 && int.TryParse(partes[1], out int mn) ? mn : 0;
            int build = partes.Length > 2 && int.TryParse(partes[2], out int b) ? b : 0;
            return new Version(major, minor, build);
        }

        public Task<string> DescargarActualizacionAsync(InfoVersion info, IProgress<ProgresoDescarga> progreso = null)
        {
            return DescargarActualizacionAsync(info.UrlDescarga, info.NombreArchivo ?? "Update_latest.zip", progreso, CancellationToken.None);
        }

        public async Task<string> DescargarActualizacionAsync(string urlDescarga, string nombreArchivo, IProgress<ProgresoDescarga> progreso, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlDescarga))
                throw new InvalidOperationException("No se proporcionó una URL de descarga válida.");

            string tempDir = Path.Combine(Path.GetTempPath(), "SistemaAsistencias_Updates");
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            string targetFile = Path.Combine(tempDir, nombreArchivo ?? "Update_latest.zip");
            if (File.Exists(targetFile))
                File.Delete(targetFile);

            var stopwatch = Stopwatch.StartNew();
            long totalBytes = -1;

            var request = (HttpWebRequest)WebRequest.Create(urlDescarga);
            request.UserAgent = "SistemaAsistenciasZKTeco-Updater";
            request.AllowAutoRedirect = true;

            using (cancellationToken.Register(() => request.Abort(), false))
            using (var response = await request.GetResponseAsync())
            {
                totalBytes = response.ContentLength;

                using (var stream = response.GetResponseStream())
                using (var fileStream = new FileStream(targetFile, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    byte[] buffer = new byte[8192];
                    long totalRead = 0;
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                        totalRead += bytesRead;

                        if (progreso != null)
                        {
                            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                            double speedMBs = elapsedSeconds > 0 ? (totalRead / (1024.0 * 1024.0)) / elapsedSeconds : 0;
                            int pct = totalBytes > 0 ? (int)((totalRead * 100) / totalBytes) : 0;

                            progreso.Report(new ProgresoDescarga
                            {
                                BytesRecibidos = totalRead,
                                BytesTotales = totalBytes,
                                Porcentaje = pct,
                                VelocidadMBs = Math.Round(speedMBs, 2)
                            });
                        }
                    }
                }
            }

            return targetFile;
        }

        public void EjecutarActualizador(string rutaZip)
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string actualizadorExe = Path.Combine(appDir, "Actualizador.exe");

            if (!File.Exists(actualizadorExe))
                throw new FileNotFoundException("No se encontró el ejecutable del actualizador en: " + actualizadorExe);

            int currentPid = Process.GetCurrentProcess().Id;
            string mainExe = Assembly.GetEntryAssembly()?.Location ?? Path.Combine(appDir, "Sistema.Presentacion.exe");

            var psi = new ProcessStartInfo
            {
                FileName = actualizadorExe,
                Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\" {3}", rutaZip, appDir, mainExe, currentPid),
                UseShellExecute = true,
                Verb = "runas"
            };

            Process.Start(psi);
        }
    }
}
