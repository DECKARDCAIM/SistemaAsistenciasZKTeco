using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmInfoSistema : Form
    {
        public FrmInfoSistema()
        {
            InitializeComponent();
            CargarIcono();
            AplicarTema();
            CargarDatos();
        }

        private void CargarIcono()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string icoPath = Path.Combine(baseDir, "app.ico");
                if (File.Exists(icoPath))
                {
                    this.Icon = new Icon(icoPath);
                }
                else
                {
                    this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                }
            }
            catch { }
        }

        private void AplicarTema()
        {
            try
            {
                bool esOscuro = RJCodeUI_M1.Settings.UIAppearance.Theme == RJCodeUI_M1.Settings.UITheme.Dark;
                Color colorPrimario = RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor != Color.Empty
                    ? RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor
                    : Color.FromArgb(40, 53, 147);
                Color colorEstilo = RJCodeUI_M1.Settings.UIAppearance.StyleColor != Color.Empty
                    ? RJCodeUI_M1.Settings.UIAppearance.StyleColor
                    : Color.FromArgb(40, 53, 147);

                if (esOscuro)
                {
                    this.BackColor = Color.FromArgb(24, 28, 45);
                    pnlHeader.BackColor = Color.FromArgb(18, 22, 38);
                    pnlCard1.BackColor = Color.FromArgb(32, 38, 60);
                    pnlCard2.BackColor = Color.FromArgb(32, 38, 60);
                    pnlCard3.BackColor = Color.FromArgb(32, 38, 60);
                    pnlCard4.BackColor = Color.FromArgb(32, 38, 60);
                    lblAppTitle.ForeColor = Color.White;
                    lblSubtitle.ForeColor = Color.FromArgb(144, 202, 249);
                    lblTechHeader.ForeColor = Color.FromArgb(180, 190, 220);
                }
                else
                {
                    this.BackColor = Color.FromArgb(245, 247, 251);
                    pnlHeader.BackColor = colorEstilo;
                    pnlCard1.BackColor = Color.White;
                    pnlCard2.BackColor = Color.White;
                    pnlCard3.BackColor = Color.White;
                    pnlCard4.BackColor = Color.White;
                    lblAppTitle.ForeColor = Color.White;
                    lblSubtitle.ForeColor = Color.FromArgb(220, 235, 255);
                    lblTechHeader.ForeColor = Color.FromArgb(70, 80, 100);
                }

                btnCerrar.BackColor = colorPrimario;
                btnCerrar.ForeColor = Color.White;
            }
            catch { }
        }

        private void CargarDatos()
        {
            try
            {
                var actualizador = new ActualizadorService();
                string version = actualizador.ObtenerVersionActual();
                lblVersion.Text = "Versión instalada: v" + version;

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] rutas = new string[]
                {
                    Path.Combine(baseDir, "Logotipos", "Logotipo-White.png"),
                    Path.Combine(baseDir, @"..\..\..\Logotipos\Logotipo-White.png"),
                    Path.Combine(baseDir, "Logotipo-White.png")
                };

                foreach (string r in rutas)
                {
                    if (File.Exists(r))
                    {
                        pbLogo.Image = Image.FromFile(Path.GetFullPath(r));
                        break;
                    }
                }
            }
            catch { }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
