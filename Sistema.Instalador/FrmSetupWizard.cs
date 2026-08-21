using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Sistema.Instalador
{
    public partial class FrmSetupWizard : Form
    {
        private int _pasoActual = 1;
        private bool _net48Instalado = false;
        private bool _vcInstalado = false;
        private string _rutaInstalacion = @"C:\Program Files (x86)\Hospital El Progreso\Sistema de Asistencias ZKTeco";

        public FrmSetupWizard()
        {
            InitializeComponent();
            txtRutaDestino.Text = _rutaInstalacion;
            try
            {
                string icoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.ico");
                if (File.Exists(icoPath)) this.Icon = new Icon(icoPath);
                else this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch { }
        }

        private void FrmSetupWizard_Load(object sender, EventArgs e)
        {
            MostrarPaso(1);
            VerificarPrerrequisitos();
        }

        private void MostrarPaso(int paso)
        {
            _pasoActual = paso;

            pnlPaso1_Bienvenida.Visible = (paso == 1);
            pnlPaso2_Prerrequisitos.Visible = (paso == 2);
            pnlPaso3_Opciones.Visible = (paso == 3);
            pnlPaso4_Progreso.Visible = (paso == 4);
            pnlPaso5_Finalizado.Visible = (paso == 5);

            btnAtras.Visible = (paso > 1 && paso < 4);
            btnCancelar.Visible = (paso < 4);

            if (paso == 1)
            {
                btnSiguiente.Text = "Siguiente >";
                btnSiguiente.BackColor = Color.FromArgb(0, 180, 216);
            }
            else if (paso == 2)
            {
                btnSiguiente.Text = "Siguiente >";
            }
            else if (paso == 3)
            {
                btnSiguiente.Text = "Instalar Ahora";
                btnSiguiente.BackColor = Color.FromArgb(16, 185, 129);
            }
            else if (paso == 4)
            {
                btnSiguiente.Visible = false;
                btnAtras.Visible = false;
                btnCancelar.Visible = false;
            }
            else if (paso == 5)
            {
                btnSiguiente.Visible = true;
                btnSiguiente.Text = "Finalizar";
                btnSiguiente.BackColor = Color.FromArgb(16, 185, 129);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_pasoActual == 1)
            {
                MostrarPaso(2);
            }
            else if (_pasoActual == 2)
            {
                MostrarPaso(3);
            }
            else if (_pasoActual == 3)
            {
                _rutaInstalacion = txtRutaDestino.Text.Trim();
                MostrarPaso(4);
                EjecutarInstalacionAsync();
            }
            else if (_pasoActual == 5)
            {
                if (chkEjecutarApp.Checked)
                {
                    string targetExe = Path.Combine(_rutaInstalacion, "Sistema.Presentacion.exe");
                    if (File.Exists(targetExe))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = targetExe,
                            WorkingDirectory = _rutaInstalacion
                        });
                    }
                }
                Application.Exit();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (_pasoActual > 1 && _pasoActual < 4)
            {
                MostrarPaso(_pasoActual - 1);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la instalación del sistema?", "Cancelar Instalación",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta de destino para el Sistema de Asistencias:";
                fbd.SelectedPath = txtRutaDestino.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaDestino.Text = fbd.SelectedPath;
                }
            }
        }

        #region Diagnóstico de Prerrequisitos

        private void VerificarPrerrequisitos()
        {
            // 1. Verificar .NET Framework 4.8
            try
            {
                using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"))
                {
                    if (ndpKey != null && ndpKey.GetValue("Release") != null)
                    {
                        int releaseKey = (int)ndpKey.GetValue("Release");
                        _net48Instalado = (releaseKey >= 528040);
                    }
                }
            }
            catch { _net48Instalado = false; }

            if (_net48Instalado)
            {
                lblNetStatus.Text = "✓ Instalado";
                lblNetStatus.ForeColor = Color.FromArgb(16, 185, 129);
                picNet.ForeColor = Color.FromArgb(16, 185, 129);
                btnInstalarNet.Visible = false;
            }
            else
            {
                lblNetStatus.Text = "✗ No detectado";
                lblNetStatus.ForeColor = Color.FromArgb(239, 68, 68);
                picNet.ForeColor = Color.FromArgb(239, 68, 68);
                btnInstalarNet.Visible = true;
            }

            // 2. Verificar Visual C++ 2015-2022 (x86)
            try
            {
                using (RegistryKey vcKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\14.0\VC\Runtimes\X86") ??
                                         Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\X86"))
                {
                    if (vcKey != null && vcKey.GetValue("Installed") != null)
                    {
                        _vcInstalado = Convert.ToInt32(vcKey.GetValue("Installed")) == 1;
                    }
                }
            }
            catch { _vcInstalado = false; }

            if (_vcInstalado)
            {
                lblVcStatus.Text = "✓ Instalado";
                lblVcStatus.ForeColor = Color.FromArgb(16, 185, 129);
                picVC.ForeColor = Color.FromArgb(16, 185, 129);
                btnInstalarVC.Visible = false;
            }
            else
            {
                lblVcStatus.Text = "✗ Faltante (Requerido)";
                lblVcStatus.ForeColor = Color.FromArgb(245, 158, 11);
                picVC.ForeColor = Color.FromArgb(245, 158, 11);
                btnInstalarVC.Visible = true;
            }
        }

        private void btnInstalarNet_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://go.microsoft.com/fwlink/?linkid=2088631");
            }
            catch { }
        }

        private async void btnInstalarVC_Click(object sender, EventArgs e)
        {
            btnInstalarVC.Enabled = false;
            btnInstalarVC.Text = "Instalando...";

            await Task.Run(() =>
            {
                try
                {
                    string tempFile = Path.Combine(Path.GetTempPath(), "vc_redist.x86.exe");
                    using (var wc = new System.Net.WebClient())
                    {
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                        wc.DownloadFile("https://aka.ms/vs/17/release/vc_redist.x86.exe", tempFile);
                    }

                    var psi = new ProcessStartInfo
                    {
                        FileName = tempFile,
                        Arguments = "/install /quiet /norestart",
                        UseShellExecute = true,
                        Verb = "runas"
                    };
                    var p = Process.Start(psi);
                    p.WaitForExit(60000);
                }
                catch { }
            });

            VerificarPrerrequisitos();
            btnInstalarVC.Enabled = true;
        }

        #endregion

        #region Proceso de Instalación

        private string ObtenerDirectorioOrigen()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidatos = new string[]
            {
                Path.Combine(baseDir, "ArchivosApp"),
                Path.Combine(baseDir, @"..\Sistema.Presentacion\bin\x86\Debug"),
                Path.Combine(baseDir, @"..\Sistema.Presentacion\bin\x86\Release"),
                Path.Combine(baseDir, @"..\..\Sistema.Presentacion\bin\x86\Debug"),
                Path.Combine(baseDir, @"..\..\Sistema.Presentacion\bin\x86\Release"),
                Path.Combine(baseDir, @"Sistema.Presentacion\bin\x86\Debug"),
                baseDir
            };

            foreach (string dir in candidatos)
            {
                if (Directory.Exists(dir) && File.Exists(Path.Combine(dir, "Sistema.Presentacion.exe")))
                {
                    return Path.GetFullPath(dir);
                }
            }

            // Buscar en carpeta superior si existe
            try
            {
                string parentDir = Directory.GetParent(baseDir)?.FullName;
                if (!string.IsNullOrEmpty(parentDir))
                {
                    string cand = Path.Combine(parentDir, @"Sistema.Presentacion\bin\x86\Debug");
                    if (Directory.Exists(cand) && File.Exists(Path.Combine(cand, "Sistema.Presentacion.exe")))
                        return Path.GetFullPath(cand);
                }
            }
            catch { }

            return baseDir;
        }

        private async void EjecutarInstalacionAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    string sourceDir = ObtenerDirectorioOrigen();

                    // Cerrar instancias previas si están abiertas
                    CerrarProcesoSilencioso("Sistema.Presentacion");
                    CerrarProcesoSilencioso("Sistema.ServicioWindows");
                    CerrarProcesoSilencioso("Actualizador");

                    ReportarProgreso(5, "Preparando directorio de instalación en: " + _rutaInstalacion);
                    if (!Directory.Exists(_rutaInstalacion))
                    {
                        Directory.CreateDirectory(_rutaInstalacion);
                    }

                    // 1. Copiar Archivos Binarios y DLLs
                    ReportarProgreso(15, "Copiando ejecutables y librerías del sistema...");
                    if (Directory.Exists(sourceDir))
                    {
                        CopiarArchivosConProgreso(sourceDir, _rutaInstalacion, 15, 65);
                    }

                    // Verificar que el ejecutable principal existe
                    string targetExe = Path.Combine(_rutaInstalacion, "Sistema.Presentacion.exe");
                    if (!File.Exists(targetExe))
                    {
                        throw new FileNotFoundException("No se encontró Sistema.Presentacion.exe en la carpeta origen: " + sourceDir);
                    }

                    // 2. Copiar SDK ZKTeco si falta en destino
                    ReportarProgreso(68, "Verificando SDK nativo ZKTeco...");
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string[] sdkDirs = new string[]
                    {
                        Path.Combine(baseDir, "SDK"),
                        Path.Combine(baseDir, @"..\SDK"),
                        Path.Combine(baseDir, @"..\..\SDK")
                    };

                    foreach (string sdkDir in sdkDirs)
                    {
                        if (Directory.Exists(sdkDir))
                        {
                            foreach (string file in Directory.GetFiles(sdkDir))
                            {
                                string destFile = Path.Combine(_rutaInstalacion, Path.GetFileName(file));
                                if (!File.Exists(destFile))
                                    File.Copy(file, destFile, true);
                            }
                            break;
                        }
                    }

                    // 3. Copiar Recursos y Logotipos
                    ReportarProgreso(75, "Copiando recursos institucionales y plantillas...");
                    string[] logoDirs = new string[]
                    {
                        Path.Combine(baseDir, "Logotipos"),
                        Path.Combine(baseDir, @"..\Logotipos"),
                        Path.Combine(baseDir, @"..\..\Logotipos")
                    };
                    foreach (string logoDir in logoDirs)
                    {
                        if (Directory.Exists(logoDir))
                        {
                            string destLogo = Path.Combine(_rutaInstalacion, "Logotipos");
                            if (!Directory.Exists(destLogo)) Directory.CreateDirectory(destLogo);
                            foreach (string file in Directory.GetFiles(logoDir))
                            {
                                File.Copy(file, Path.Combine(destLogo, Path.GetFileName(file)), true);
                            }
                            break;
                        }
                    }

                    // 4. Registrar Librería COM zkemkeeper.dll en Windows
                    ReportarProgreso(82, "Registrando librerías biométricas COM en Windows...");
                    string zkemDll = Path.Combine(_rutaInstalacion, "zkemkeeper.dll");
                    if (File.Exists(zkemDll))
                    {
                        EjecutarComando("regsvr32.exe", string.Format("/s \"{0}\"", zkemDll));
                    }

                    // 5. Crear Accesos Directos
                    ReportarProgreso(88, "Creando accesos directos...");

                    if (chkEscritorio.Checked)
                    {
                        CrearAccesoDirecto(
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sistema de Asistencias ZKTeco.lnk"),
                            targetExe,
                            _rutaInstalacion,
                            "Sistema de Asistencias y Control Biométrico - Hospital de El Progreso"
                        );
                    }

                    if (chkMenuInicio.Checked)
                    {
                        string menuFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), "Hospital de El Progreso");
                        if (!Directory.Exists(menuFolder)) Directory.CreateDirectory(menuFolder);
                        CrearAccesoDirecto(
                            Path.Combine(menuFolder, "Sistema de Asistencias ZKTeco.lnk"),
                            targetExe,
                            _rutaInstalacion,
                            "Sistema de Asistencias y Control Biométrico - Hospital de El Progreso"
                        );
                    }

                    // 6. Registrar en Windows "Aplicaciones y características" (Panel de Control)
                    ReportarProgreso(91, "Registrando en Aplicaciones y características de Windows...");
                    RegistrarDesinstaladorWindows(_rutaInstalacion);

                    // 7. Instalar Servicio de Windows 24/7 si se solicitó
                    if (chkServicioWindows.Checked)
                    {
                        ReportarProgreso(94, "Configurando Servicio de Windows 24/7 en segundo plano...");
                        string serviceExe = Path.Combine(_rutaInstalacion, "Sistema.ServicioWindows.exe");
                        if (File.Exists(serviceExe))
                        {
                            // Detener y eliminar servicio previo si existía
                            EjecutarComando("sc.exe", "stop ZKTecoHospitalElProgresoService");
                            System.Threading.Thread.Sleep(1000);
                            EjecutarComando("sc.exe", "delete ZKTecoHospitalElProgresoService");
                            System.Threading.Thread.Sleep(1000);

                            // Crear y arrancar servicio
                            string createArgs = string.Format("create ZKTecoHospitalElProgresoService binPath= \"\\\"{0}\\\"\" start= auto DisplayName= \"Servicio de Asistencias ZKTeco - Hospital de El Progreso\"", serviceExe);
                            EjecutarComando("sc.exe", createArgs);
                            EjecutarComando("sc.exe", "description ZKTecoHospitalElProgresoService \"Monitorea y sincroniza 24/7 los relojes biometricos ZKTeco con PostgreSQL y Redis para el Hospital de El Progreso.\"");
                            EjecutarComando("sc.exe", "start ZKTecoHospitalElProgresoService");
                        }
                    }

                    ReportarProgreso(100, "¡Instalación completada exitosamente!");
                });

                await Task.Delay(600);
                MostrarPaso(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la instalación:\n\n" + ex.Message, "Error de Instalación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarPaso(3);
            }
        }

        private void CerrarProcesoSilencioso(string processName)
        {
            try
            {
                foreach (var p in Process.GetProcessesByName(processName))
                {
                    p.Kill();
                    p.WaitForExit(3000);
                }
            }
            catch { }
        }

        private void EjecutarComando(string fileName, string args)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                var proc = Process.Start(psi);
                proc?.WaitForExit(10000);
            }
            catch { }
        }

        private void CopiarArchivosConProgreso(string source, string dest, int pctInicio, int pctFin)
        {
            string[] files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);
            int total = files.Length;
            int contador = 0;

            foreach (string file in files)
            {
                string rel = file.Substring(source.Length).TrimStart('\\', '/');
                string destFile = Path.Combine(dest, rel);
                string destFolder = Path.GetDirectoryName(destFile);

                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                int reintentos = 5;
                while (reintentos > 0)
                {
                    try
                    {
                        if (File.Exists(destFile))
                        {
                            File.SetAttributes(destFile, FileAttributes.Normal);
                        }
                        File.Copy(file, destFile, true);
                        break;
                    }
                    catch (IOException)
                    {
                        reintentos--;
                        CerrarProcesoSilencioso("Actualizador");
                        CerrarProcesoSilencioso("Sistema.Presentacion");
                        CerrarProcesoSilencioso("Sistema.ServicioWindows");
                        CerrarProcesoSilencioso("Desinstalador");
                        System.Threading.Thread.Sleep(600);

                        if (reintentos == 0)
                        {
                            try
                            {
                                File.Delete(destFile);
                                File.Copy(file, destFile, true);
                            }
                            catch { }
                        }
                    }
                }

                contador++;

                int pct = pctInicio + (int)((contador / (double)Math.Max(1, total)) * (pctFin - pctInicio));
                ReportarProgreso(pct, "Copiando: " + Path.GetFileName(file));
            }
        }

        private void ReportarProgreso(int porcentaje, string detalle)
        {
            if (this.IsDisposed) return;
            this.BeginInvoke(new Action(() =>
            {
                progressBarInstalacion.Value = Math.Max(0, Math.Min(100, porcentaje));
                lblPorcentaje.Text = porcentaje + "%";
                lblDetalleProgreso.Text = detalle;
            }));
        }

        private void CrearAccesoDirecto(string rutaLnk, string targetPath, string workingDir, string descripcion)
        {
            try
            {
                if (File.Exists(rutaLnk))
                {
                    try { File.Delete(rutaLnk); } catch { }
                }

                Type shellType = Type.GetTypeFromProgID("WScript.Shell");
                dynamic shell = Activator.CreateInstance(shellType);
                dynamic shortcut = shell.CreateShortcut(rutaLnk);
                shortcut.TargetPath = targetPath;
                shortcut.WorkingDirectory = workingDir;
                string iconFile = Path.Combine(workingDir, "app.ico");
                if (File.Exists(iconFile))
                {
                    shortcut.IconLocation = iconFile + ",0";
                }
                else
                {
                    shortcut.IconLocation = targetPath + ",0";
                }
                shortcut.Description = descripcion;
                shortcut.Save();
                Marshal.FinalReleaseComObject(shortcut);
                Marshal.FinalReleaseComObject(shell);
            }
            catch { }
        }

        private void RegistrarDesinstaladorWindows(string rutaInstalacion)
        {
            string[] baseKeys = new string[]
            {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\SistemaAsistenciasZKTeco",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\SistemaAsistenciasZKTeco"
            };

            string uninstallerPath = Path.Combine(rutaInstalacion, "Desinstalador.exe");
            string mainExePath = Path.Combine(rutaInstalacion, "Sistema.Presentacion.exe");
            string icoPath = Path.Combine(rutaInstalacion, "app.ico");
            string displayIcon = File.Exists(icoPath) ? icoPath + ",0" : string.Format("\"{0}\",0", mainExePath);

            foreach (string subKey in baseKeys)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(subKey))
                    {
                        if (key != null)
                        {
                            key.SetValue("DisplayName", "Sistema de Asistencias ZKTeco - Hospital de El Progreso");
                            key.SetValue("DisplayVersion", "1.0.1");
                            key.SetValue("Publisher", "Hospital de El Progreso");
                            key.SetValue("InstallLocation", rutaInstalacion);
                            key.SetValue("UninstallString", string.Format("\"{0}\"", uninstallerPath));
                            key.SetValue("QuietUninstallString", string.Format("\"{0}\" /quiet", uninstallerPath));
                            key.SetValue("DisplayIcon", displayIcon);
                            key.SetValue("EstimatedSize", 45000, RegistryValueKind.DWord);
                            key.SetValue("NoModify", 1, RegistryValueKind.DWord);
                            key.SetValue("NoRepair", 1, RegistryValueKind.DWord);
                        }
                    }
                }
                catch { }
            }
        }

        #endregion
    }
}
