using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Sistema.Desinstalador
{
    public partial class FrmDesinstalador : Form
    {
        private bool _esServidor = false;
        private string _appDir;

        public FrmDesinstalador()
        {
            InitializeComponent();
            _appDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            try
            {
                string icoPath = Path.Combine(_appDir, "app.ico");
                if (File.Exists(icoPath)) this.Icon = new Icon(icoPath);
                else this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch { }
        }

        private void FrmDesinstalador_Load(object sender, EventArgs e)
        {
            DetectarModoEquipo();
        }

        private void DetectarModoEquipo()
        {
            try
            {
                using (var sc = new ServiceController("ZKTecoHospitalElProgresoService"))
                {
                    var status = sc.Status;
                    _esServidor = true;
                }
            }
            catch
            {
                _esServidor = false;
            }

            if (_esServidor)
            {
                lblModoDetectado.Text = "Modo: Servidor Principal Detectado";
                lblModoDetectado.ForeColor = Color.FromArgb(180, 40, 50);
                lblDetalleModo.Text = "Se detendrán y eliminarán los Servicios de Windows 24/7 y la aplicación.";
                picModo.IconChar = FontAwesome.Sharp.IconChar.Server;
                picModo.ForeColor = Color.FromArgb(180, 40, 50);
            }
            else
            {
                lblModoDetectado.Text = "Modo: Estación de Trabajo Cliente";
                lblModoDetectado.ForeColor = Color.FromArgb(0, 150, 214);
                lblDetalleModo.Text = "Se eliminará la aplicación de escritorio y los accesos directos.";
                picModo.IconChar = FontAwesome.Sharp.IconChar.Desktop;
                picModo.ForeColor = Color.FromArgb(0, 150, 214);
            }
        }

        private async void btnDesinstalar_Click(object sender, EventArgs e)
        {
            string msg = _esServidor
                ? "¿Está completamente seguro de desinstalar el sistema y el Servicio de Windows 24/7 de este SERVIDOR?"
                : "¿Está seguro que desea desinstalar el Sistema de Asistencias de este equipo?";

            if (MessageBox.Show(msg, "Confirmar Desinstalación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            btnDesinstalar.Enabled = false;
            btnCancelar.Enabled = false;
            progressBarDesinstalacion.Visible = true;
            lblPorcentaje.Visible = true;

            await Task.Run(() =>
            {
                // 1. Cerrar Procesos
                ReportarProgreso(10, "Cerrando procesos en ejecución...");
                CerrarProcesoSilencioso("Sistema.Presentacion");
                CerrarProcesoSilencioso("Sistema.ServicioWindows");
                CerrarProcesoSilencioso("Actualizador");

                // 2. Si es Servidor, Detener y Eliminar Servicio
                if (_esServidor)
                {
                    ReportarProgreso(30, "Deteniendo y eliminando Servicio de Windows ZKTecoHospitalElProgresoService...");
                    EjecutarComando("sc.exe", "stop ZKTecoHospitalElProgresoService");
                    System.Threading.Thread.Sleep(2000);
                    EjecutarComando("sc.exe", "delete ZKTecoHospitalElProgresoService");
                    System.Threading.Thread.Sleep(1000);
                }

                // 3. Desregistrar DLL COM
                ReportarProgreso(50, "Desregistrando librerías biométricas en Windows...");
                string zkemDll = Path.Combine(_appDir, "zkemkeeper.dll");
                if (File.Exists(zkemDll))
                {
                    EjecutarComando("regsvr32.exe", string.Format("/u /s \"{0}\"", zkemDll));
                }

                // 4. Eliminar Accesos Directos
                ReportarProgreso(65, "Eliminando accesos directos...");
                EliminarArchivoSilencioso(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sistema de Asistencias ZKTeco.lnk"));
                
                string menuDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), "Hospital de El Progreso");
                if (Directory.Exists(menuDir))
                {
                    try { Directory.Delete(menuDir, true); } catch { }
                }

                // 5. Eliminar Registro de Desinstalación de Windows (Panel de Control)
                ReportarProgreso(80, "Eliminando registro en Aplicaciones de Windows...");
                EliminarRegistroDesinstalacion();

                // 6. Eliminar Archivos del Directorio
                ReportarProgreso(95, "Limpiando archivos de instalación...");
                LimpiarDirectorioApp();

                ReportarProgreso(100, "¡Desinstalación completada con éxito!");
            });

            await Task.Delay(800);

            // Preguntar si desea reiniciar el equipo
            var resReinicio = MessageBox.Show(
                "El Sistema de Asistencias ZKTeco se ha desinstalado exitosamente.\n\n¿Desea reiniciar el equipo ahora para completar la limpieza del sistema operativo?",
                "Desinstalación Completa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resReinicio == DialogResult.Yes)
            {
                // Programar reinicio en 5 segundos
                EjecutarComando("shutdown.exe", "/r /t 5 /c \"Reinicio programado tras desinstalacion de Sistema de Asistencias ZKTeco\"");
            }

            // Auto-eliminación del desinstalador al salir
            AutoEliminarYSalir();
        }

        private void EliminarRegistroDesinstalacion()
        {
            string[] subKeys = new string[]
            {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\SistemaAsistenciasZKTeco",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\SistemaAsistenciasZKTeco"
            };

            foreach (string subKey in subKeys)
            {
                try
                {
                    Registry.LocalMachine.DeleteSubKeyTree(subKey, false);
                }
                catch { }
            }
        }

        private void LimpiarDirectorioApp()
        {
            try
            {
                string uninstallerExe = Application.ExecutablePath;
                foreach (string file in Directory.GetFiles(_appDir, "*.*", SearchOption.AllDirectories))
                {
                    if (string.Equals(file, uninstallerExe, StringComparison.OrdinalIgnoreCase))
                        continue;

                    try { File.Delete(file); } catch { }
                }

                foreach (string dir in Directory.GetDirectories(_appDir))
                {
                    try { Directory.Delete(dir, true); } catch { }
                }
            }
            catch { }
        }

        private void AutoEliminarYSalir()
        {
            try
            {
                // Ejecutar script cmd temporal para borrar el exe del desinstalador y la carpeta
                string cmd = string.Format("/c ping 127.0.0.1 -n 3 > nul & rmdir /s /q \"{0}\"", _appDir);
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = cmd,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                });
            }
            catch { }

            Application.Exit();
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

        private void EliminarArchivoSilencioso(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
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

        private void ReportarProgreso(int porcentaje, string detalle)
        {
            if (this.IsDisposed) return;
            this.BeginInvoke(new Action(() =>
            {
                progressBarDesinstalacion.Value = Math.Max(0, Math.Min(100, porcentaje));
                lblPorcentaje.Text = porcentaje + "%";
                lblDetalleProgreso.Text = detalle;
            }));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
