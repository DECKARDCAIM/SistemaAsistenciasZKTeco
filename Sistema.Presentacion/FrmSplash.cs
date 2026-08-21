using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Datos;

namespace Sistema.Presentacion
{
    public partial class FrmSplash : Form
    {
        private int _progreso = 0;
        private bool _conexionProbada = false;
        private bool _conexionExitosa = false;
        private string _mensajeConexion = "";

        public FrmSplash()
        {
            InitializeComponent();
            CargarIcono();
            AplicarTema();
            CargarLogotipoInstitucional();
        }

        private void CargarIcono()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string icoPath = System.IO.Path.Combine(baseDir, "app.ico");
                if (System.IO.File.Exists(icoPath))
                {
                    this.Icon = new System.Drawing.Icon(icoPath);
                    this.ShowIcon = true;
                    return;
                }
                this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                this.ShowIcon = true;
            }
            catch { }
        }

        private void AplicarTema()
        {
            try
            {
                bool esOscuro = RJCodeUI_M1.Settings.UIAppearance.Theme == RJCodeUI_M1.Settings.UITheme.Dark;
                System.Drawing.Color colorPrimario = RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor != System.Drawing.Color.Empty 
                    ? RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor 
                    : System.Drawing.Color.FromArgb(40, 53, 147);
                System.Drawing.Color colorEstilo = RJCodeUI_M1.Settings.UIAppearance.StyleColor != System.Drawing.Color.Empty 
                    ? RJCodeUI_M1.Settings.UIAppearance.StyleColor 
                    : System.Drawing.Color.FromArgb(40, 53, 147);

                if (esOscuro)
                {
                    pnlMain.BackColor = System.Drawing.Color.FromArgb(20, 24, 40);
                    lblTitle.ForeColor = System.Drawing.Color.White;
                    lblSubtitle.ForeColor = colorPrimario;
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 190, 220);
                    lblVersion.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
                    progressBar.ChannelColor = System.Drawing.Color.FromArgb(32, 38, 60);
                    progressBar.SliderColor = colorPrimario;
                }
                else
                {
                    pnlMain.BackColor = colorEstilo;
                    lblTitle.ForeColor = System.Drawing.Color.White;
                    lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(220, 235, 255);
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 220, 245);
                    lblVersion.ForeColor = System.Drawing.Color.FromArgb(180, 200, 235);
                    progressBar.ChannelColor = System.Drawing.Color.FromArgb(30, 0, 0, 0);
                    progressBar.SliderColor = System.Drawing.Color.White;
                }
            }
            catch { }
        }

        private void CargarLogotipoInstitucional()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] rutas = new string[]
                {
                    System.IO.Path.Combine(baseDir, "Logotipos", "Logotipo-White.png"),
                    System.IO.Path.Combine(baseDir, @"..\..\..\Logotipos\Logotipo-White.png"),
                    System.IO.Path.Combine(baseDir, "Logotipo-White.png")
                };
                foreach (string r in rutas)
                {
                    if (System.IO.File.Exists(r))
                    {
                        picLogo.Image = System.Drawing.Image.FromFile(System.IO.Path.GetFullPath(r));
                        return;
                    }
                }
            }
            catch { }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timerProgress.Start();
            Task.Run(() =>
            {
                _conexionExitosa = Conexion.ProbarConexion(out _mensajeConexion);
                _conexionProbada = true;
            });
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            _progreso += 2;

            if (_progreso <= 25)
            {
                lblStatus.Text = "Iniciando componentes y librerías visuales...";
            }
            else if (_progreso <= 60)
            {
                lblStatus.Text = "Verificando conexión con base de datos PostgreSQL...";
            }
            else if (_progreso <= 85)
            {
                lblStatus.Text = "Cargando servicios de comunicación biométrica ZKTeco...";
            }
            else if (_progreso < 100)
            {
                lblStatus.Text = "Preparando módulos del sistema...";
            }

            if (_progreso >= 70 && !_conexionProbada)
            {
                _progreso = 70;
            }

            if (_progreso >= 100)
            {
                timerProgress.Stop();
                progressBar.Value = 100;
                lblStatus.Text = "¡Listo para iniciar!";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                progressBar.Value = _progreso;
            }
        }
    }
}
