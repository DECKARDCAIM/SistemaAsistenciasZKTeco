using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
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
        public string CommitSha { get; set; }
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

        public string ObtenerCommitActual()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "last_commit.txt");
                if (File.Exists(path))
                {
                    string sha = File.ReadAllText(path).Trim();
                    if (!string.IsNullOrEmpty(sha))
                    {
                        return sha;
                    }
                }
            }
            catch { }

            // Fallback a version de ensamblado
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }

        public async Task<InfoVersion> VerificarActualizacionAsync()
        {
            string commitActual = ObtenerCommitActual();
            var info = new InfoVersion
            {
                VersionActual = commitActual.Length > 7 ? commitActual.Substring(0, 7) : commitActual,
                CommitSha = commitActual,
                HayActualizacion = false
            };

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string apiUrl = string.Format("https://api.github.com/repos/{0}/{1}/commits/master", _repoOwner, _repoName);

                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "SistemaAsistenciasZKTeco-Updater");
                    client.Headers.Add("Accept", "application/vnd.github.v3+json");

                    string json = await client.DownloadStringTaskAsync(new Uri(apiUrl));

                    // Extraer SHA del commit
                    var matchSha = Regex.Match(json, "\"sha\"\\s*:\\s*\"([a-f0-9]{40})\"");
                    if (matchSha.Success)
                    {
                        string shaRemoto = matchSha.Groups[1].Value;
                        string shortSha = shaRemoto.Substring(0, 7);
                        info.CommitSha = shaRemoto;
                        info.VersionNueva = shortSha;

                        // Extraer mensaje del commit
                        var matchMsg = Regex.Match(json, "\"message\"\\s*:\\s*\"([^\"]+)\"");
                        string mensaje = matchMsg.Success ? Regex.Unescape(matchMsg.Groups[1].Value) : "Actualización de la rama master";

                        // Extraer fecha
                        var matchDate = Regex.Match(json, "\"date\"\\s*:\\s*\"([^\"]+)\"");
                        string fecha = matchDate.Success ? matchDate.Groups[1].Value : "";

                        info.TituloRelease = string.Format("Últimos cambios en master ({0})", shortSha);
                        info.NotasVersion = string.Format("Commit: {0}\nFecha: {1}\n\nCambios:\n{2}", shortSha, fecha, mensaje);
                        info.UrlDescarga = string.Format("https://github.com/{0}/{1}/raw/master/Instalador/Update_latest.zip", _repoOwner, _repoName);
                        info.NombreArchivo = "Update_latest.zip";

                        // Si el commit local es diferente del remoto, hay actualización
                        if (!string.Equals(commitActual, shaRemoto, StringComparison.OrdinalIgnoreCase) &&
                            !string.Equals(info.VersionActual, shortSha, StringComparison.OrdinalIgnoreCase))
                        {
                            info.HayActualizacion = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la rama master en GitHub: " + ex.Message);
            }

            return info;
        }

        public async Task<string> DescargarActualizacionAsync(InfoVersion info, IProgress<ProgresoDescarga> progreso = null)
        {
            if (string.IsNullOrEmpty(info.UrlDescarga))
                throw new InvalidOperationException("No se proporcionó una URL de descarga válida.");

            string tempDir = Path.Combine(Path.GetTempPath(), "SistemaAsistencias_Updates");
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            string targetFile = Path.Combine(tempDir, info.NombreArchivo ?? "Update_latest.zip");
            if (File.Exists(targetFile))
                File.Delete(targetFile);

            var stopwatch = Stopwatch.StartNew();
            long totalBytes = -1;

            var request = (HttpWebRequest)WebRequest.Create(info.UrlDescarga);
            request.UserAgent = "SistemaAsistenciasZKTeco-Updater";
            request.AllowAutoRedirect = true;

            using (var response = await request.GetResponseAsync())
            {
                totalBytes = response.ContentLength;

                using (var stream = response.GetResponseStream())
                using (var fileStream = new FileStream(targetFile, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    byte[] buffer = new byte[8192];
                    long totalRead = 0;
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
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

        public void EjecutarActualizador(string rutaZip, string commitSha = "")
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
                Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\" {3} \"{4}\"", rutaZip, appDir, mainExe, currentPid, commitSha),
                UseShellExecute = true,
                Verb = "runas"
            };

            Process.Start(psi);
        }
    }
}
