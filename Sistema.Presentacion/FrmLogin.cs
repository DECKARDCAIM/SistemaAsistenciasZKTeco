using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Datos;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmLogin : RJCodeUI_M1.RJForms.RJBaseForm
    {
        public Usuario UsuarioAutenticado { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            AddControlBox();
            ApplyCustomAppearance();
            CargarIconoApp();
            CargarLogotipoInstitucional();
        }

        private void CargarIconoApp()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] rutasPosibles = new string[]
                {
                    System.IO.Path.Combine(baseDir, "app.ico"),
                    System.IO.Path.Combine(baseDir, "Logotipos", "app.ico"),
                    System.IO.Path.Combine(baseDir, @"..\..\..\Logotipos\app.ico")
                };

                foreach (string ruta in rutasPosibles)
                {
                    if (System.IO.File.Exists(ruta))
                    {
                        this.Icon = new Icon(ruta);
                        this.ShowIcon = true;
                        return;
                    }
                }

                this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                this.ShowIcon = true;
            }
            catch { }
        }

        private void CargarLogotipoInstitucional()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] rutasPosibles = new string[]
                {
                    System.IO.Path.Combine(baseDir, "Logotipos", "Logotipo-White.png"),
                    System.IO.Path.Combine(baseDir, @"..\..\..\Logotipos\Logotipo-White.png"),
                    System.IO.Path.Combine(baseDir, "Logotipo-White.png")
                };

                foreach (string ruta in rutasPosibles)
                {
                    if (System.IO.File.Exists(ruta))
                    {
                        picLogo.Image = Image.FromFile(System.IO.Path.GetFullPath(ruta));
                        return;
                    }
                }

                // Fallback: usar icono del ejecutable como imagen
                picLogo.IconChar = FontAwesome.Sharp.IconChar.HospitalUser;
                picLogo.IconColor = Color.White;
                picLogo.IconSize = 80;
            }
            catch { }
        }

        private void AddControlBox()
        {
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.btnClose.Height = 28;
            this.btnClose.Width = 38;
            this.btnClose.Location = new Point(this.Width - btnClose.Width, 0);

            this.btnMinimize.Height = 28;
            this.btnMinimize.Width = 38;
            this.btnMinimize.Location = new Point(this.btnClose.Location.X - btnMinimize.Width, 0);
            
            this.btnClose.BringToFront();
            this.btnMinimize.BringToFront();
        }

        private void ApplyCustomAppearance()
        {
            this.PrimaryForm = true;
            this.Resizable = false;
            this.BorderSize = RJCodeUI_M1.Settings.UIAppearance.FormBorderSize > 0 ? RJCodeUI_M1.Settings.UIAppearance.FormBorderSize : 1;

            bool esOscuro = RJCodeUI_M1.Settings.UIAppearance.Theme == RJCodeUI_M1.Settings.UITheme.Dark;
            Color colorPrimario = RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor != Color.Empty 
                ? RJCodeUI_M1.Settings.UIAppearance.PrimaryStyleColor 
                : Color.FromArgb(40, 53, 147);
            Color colorEstilo = RJCodeUI_M1.Settings.UIAppearance.StyleColor != Color.Empty 
                ? RJCodeUI_M1.Settings.UIAppearance.StyleColor 
                : Color.FromArgb(40, 53, 147);

            this.BorderColor = colorPrimario;

            if (esOscuro)
            {
                this.BackColor = Color.FromArgb(24, 28, 45);
                lblCaption.ForeColor = Color.White;
                icoBanner.BackColor = Color.FromArgb(18, 22, 38);
                icoBanner.OverlayColor = Color.FromArgb(18, 22, 38);

                txtEmail.BackColor = Color.FromArgb(32, 38, 60);
                txtEmail.ForeColor = Color.White;
                txtEmail.BorderColor = colorPrimario;

                txtClave.BackColor = Color.FromArgb(32, 38, 60);
                txtClave.ForeColor = Color.White;
                txtClave.BorderColor = colorPrimario;

                btnIngresar.BackColor = colorPrimario;
                btnIngresar.BorderColor = colorPrimario;

                icoUser.IconColor = colorPrimario;
                icoLock.IconColor = colorPrimario;

                this.btnClose.Image = RJCodeUI_M1.Properties.Resources.CloseWhite;
                this.btnMinimize.Image = RJCodeUI_M1.Properties.Resources.MinimizeWhite;
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 247, 251);
                lblCaption.ForeColor = colorPrimario;
                icoBanner.BackColor = colorEstilo;
                icoBanner.OverlayColor = colorEstilo;

                txtEmail.BackColor = Color.White;
                txtEmail.ForeColor = Color.FromArgb(30, 41, 59);
                txtEmail.BorderColor = colorPrimario;

                txtClave.BackColor = Color.White;
                txtClave.ForeColor = Color.FromArgb(30, 41, 59);
                txtClave.BorderColor = colorPrimario;

                btnIngresar.BackColor = colorPrimario;
                btnIngresar.BorderColor = colorPrimario;

                icoUser.IconColor = colorPrimario;
                icoLock.IconColor = colorPrimario;

                this.btnClose.Image = RJCodeUI_M1.Properties.Resources.CloseDark;
                this.btnMinimize.Image = RJCodeUI_M1.Properties.Resources.MinimizeDark;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            VerificarConexionBD();
            txtEmail.Focus();
        }

        private void VerificarConexionBD()
        {
            string mensaje;
            if (Conexion.ProbarConexion(out mensaje))
            {
                lblEstadoBD.Text = "● BD Conectada (PostgreSQL)";
                lblEstadoBD.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblEstadoBD.Text = "● BD Desconectada";
                lblEstadoBD.ForeColor = Color.Crimson;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            string usuarioOCorreo = txtEmail.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuarioOCorreo))
            {
                MostrarMensajeError("* Ingrese su usuario o correo electrónico");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                MostrarMensajeError("* Ingrese su contraseña");
                txtClave.Focus();
                return;
            }

            try
            {
                Usuario user = N_Usuario.Login(usuarioOCorreo, clave);
                if (user != null)
                {
                    if (!user.Estado)
                    {
                        MostrarMensajeError("* Usuario inactivo. Contacte al administrador.");
                        return;
                    }

                    UsuarioAutenticado = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarMensajeError("* Credenciales incorrectas. Verifique los datos.");
                    txtClave.Text = "";
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError("* Error de BD: " + ex.Message);
            }
        }

        private void MostrarMensajeError(string texto)
        {
            lblMensaje.Text = texto;
            lblMensaje.Visible = true;
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                this.BeginInvoke(new Action(() => btnIngresar.PerformClick()));
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtClave.Focus();
            }
        }
    }
}
