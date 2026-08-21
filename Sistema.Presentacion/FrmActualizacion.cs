using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmActualizacion : Form
    {
        private readonly InfoVersion _info;
        private CancellationTokenSource _cts;
        private bool _descargando = false;

        public FrmActualizacion(InfoVersion info)
        {
            InitializeComponent();
            _info = info;
            _cts = new CancellationTokenSource();

            CargarDatos();
        }

        private void CargarDatos()
        {
            lblVersionActual.Text = string.Format("Instalada: v{0}", _info.VersionActual);
            lblVersionNueva.Text = string.Format("Nueva: v{0}", _info.VersionNueva);
            lblReleaseTitle.Text = _info.TituloRelease ?? ("Versión " + _info.VersionNueva);

            txtNovedades.Text = !string.IsNullOrWhiteSpace(_info.NotasVersion) 
                ? _info.NotasVersion.Replace("\r\n", "\n").Replace("\n", Environment.NewLine)
                : "• Correcciones de estabilidad y mejoras de rendimiento.\n• Actualización recomendada para el Hospital de El Progreso.";
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_descargando) return;

            if (string.IsNullOrEmpty(_info.UrlDescarga))
            {
                MessageBox.Show("No se encontró el paquete de instalación para esta versión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _descargando = true;
            btnActualizar.Enabled = false;
            btnCancelar.Text = "Cancelar Descarga";

            progressBarDescarga.Visible = true;
            lblPorcentaje.Visible = true;
            lblEstado.Text = "Iniciando descarga del paquete de actualización...";

            var progreso = new Progress<ProgresoDescarga>(ActualizarProgreso);

            try
            {
                var actualizadorService = new ActualizadorService();
                string zipDescargado = await actualizadorService.DescargarActualizacionAsync(
                    _info.UrlDescarga,
                    _info.NombreArchivo ?? ("Update_v" + _info.VersionNueva + ".zip"),
                    progreso,
                    _cts.Token
                );

                lblEstado.Text = "Descarga completada. Preparando instalación segura con punto de restauración...";
                lblEstado.ForeColor = Color.FromArgb(16, 185, 129);
                progressBarDescarga.Value = 100;
                lblPorcentaje.Text = "100%";

                await Task.Delay(1000);

                // Localizar el ejecutable del Actualizador
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string actualizadorExe = Path.Combine(appDir, "Actualizador.exe");

                if (!File.Exists(actualizadorExe))
                {
                    // Buscar en carpetas de compilación o relativas si estamos en debug
                    string altPath = Path.Combine(appDir, @"..\..\..\Sistema.Actualizador\bin\x86\Debug\Actualizador.exe");
                    if (File.Exists(altPath))
                    {
                        actualizadorExe = Path.GetFullPath(altPath);
                    }
                }

                if (!File.Exists(actualizadorExe))
                {
                    MessageBox.Show(
                        string.Format("El paquete fue descargado en:\n{0}\n\nNo se encontró 'Actualizador.exe' para aplicar los cambios automáticamente. Puede descomprimir el archivo manualmente.", zipDescargado),
                        "Actualizador no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Iniciar proceso de actualización atómica independiente
                string argumentos = string.Format("--target \"{0}\" --package \"{1}\" --exe \"Sistema.Presentacion.exe\" --pid {2}",
                    appDir.TrimEnd('\\'), zipDescargado, Process.GetCurrentProcess().Id);

                Process.Start(new ProcessStartInfo
                {
                    FileName = actualizadorExe,
                    Arguments = argumentos,
                    UseShellExecute = true,
                    WorkingDirectory = appDir
                });

                // Cerrar la aplicación actual para permitir el reemplazo de archivos
                Application.Exit();
            }
            catch (OperationCanceledException)
            {
                lblEstado.Text = "Descarga cancelada por el usuario.";
                lblEstado.ForeColor = Color.FromArgb(239, 68, 68);
                btnActualizar.Enabled = true;
                btnCancelar.Text = "Cerrar";
                _descargando = false;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error en la descarga: " + ex.Message;
                lblEstado.ForeColor = Color.FromArgb(239, 68, 68);
                btnActualizar.Enabled = true;
                btnCancelar.Text = "Cerrar";
                _descargando = false;
                MessageBox.Show("Error durante la actualización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarProgreso(ProgresoDescarga p)
        {
            if (this.IsDisposed) return;

            progressBarDescarga.Value = Math.Max(0, Math.Min(100, p.Porcentaje));
            lblPorcentaje.Text = p.Porcentaje + "%";

            double mbRecibidos = p.BytesRecibidos / (1024.0 * 1024.0);
            double mbTotales = p.BytesTotales / (1024.0 * 1024.0);

            if (p.BytesTotales > 0)
            {
                lblEstado.Text = string.Format("Descargando: {0:F1} MB de {1:F1} MB ({2:F1} MB/s)...",
                    mbRecibidos, mbTotales, p.VelocidadMBs);
            }
            else
            {
                lblEstado.Text = string.Format("Descargando: {0:F1} MB ({1:F1} MB/s)...",
                    mbRecibidos, p.VelocidadMBs);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_descargando)
            {
                if (MessageBox.Show("¿Desea cancelar la descarga de la actualización?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cts?.Cancel();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void FrmActualizacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_descargando && !_cts.IsCancellationRequested)
            {
                _cts?.Cancel();
            }
        }
    }
}
