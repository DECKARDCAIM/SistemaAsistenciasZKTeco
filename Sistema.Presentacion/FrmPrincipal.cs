using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;
using RJCodeUI_M1.RJForms;
using RJCodeUI_M1.RJControls;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace Sistema.Presentacion
{
    public partial class FrmPrincipal : RJBaseForm
    {
        private Usuario _usuarioActual;
        private Form _formularioActivo = null;
        private RJMenuButton _botonActivo = null;
        private readonly Dictionary<string, Form> _cachedForms = new Dictionary<string, Form>();

        public FrmPrincipal()
        {
            InitializeComponent();
            AddControlBox();
            CargarIconoApp();
            InicializarVistasPrecargadas();
            AplicarTema();
            IniciarServiciosEnVivo();
        }

        public FrmPrincipal(Usuario usuario) : this()
        {
            _usuarioActual = usuario;
        }

        private void CargarIconoApp()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string icoPath = Path.Combine(baseDir, "app.ico");
                if (File.Exists(icoPath))
                {
                    this.Icon = new Icon(icoPath);
                    return;
                }

                this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch { }
        }

        private void ActualizarLogoInstitucional(bool esOscuro)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string logoFile = "Logotipo-White.png";
                string logoPath = Path.Combine(baseDir, "Logotipos", logoFile);
                if (!File.Exists(logoPath))
                    logoPath = Path.Combine(baseDir, "Resources", logoFile);
                if (!File.Exists(logoPath))
                    logoPath = Path.Combine(baseDir, @"..\..\Resources", logoFile);
                if (!File.Exists(logoPath))
                    logoPath = Path.Combine(baseDir, @"..\..\Logotipos", logoFile);

                if (File.Exists(logoPath))
                {
                    if (pbLogoInstitucional.Image != null)
                    {
                        var old = pbLogoInstitucional.Image;
                        pbLogoInstitucional.Image = null;
                        old.Dispose();
                    }
                    using (var stream = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
                    {
                        pbLogoInstitucional.Image = Image.FromStream(stream);
                    }
                    pbLogoInstitucional.Visible = true;
                    pbLogoInstitucional.Dock = DockStyle.Fill;
                    pbLogoInstitucional.Padding = new Padding(18, 14, 18, 14);
                    pbLogoInstitucional.SizeMode = PictureBoxSizeMode.Zoom;
                    pbLogoInstitucional.BringToFront();

                    lblLogoTitle.Visible = false;
                    lblLogoSubtitle.Visible = false;
                    picSideLogo.Visible = false;
                }
                else
                {
                    pbLogoInstitucional.Visible = false;
                    picSideLogo.Visible = true;
                    lblLogoTitle.Text = "Sistema ZKTECO";
                    lblLogoTitle.Visible = true;
                    lblLogoSubtitle.Text = "Control de Asistencias";
                    lblLogoSubtitle.Visible = true;
                }
            }
            catch { }
        }

        private void InicializarVistasPrecargadas()
        {
            try
            {
                _cachedForms["Dashboard"] = new FrmDashboard();
                _cachedForms["Empleados"] = new FrmEmpleados();
                _cachedForms["Departamentos"] = new FrmDepartamentos();
                _cachedForms["Horarios"] = new FrmHorarios();
                _cachedForms["AsignacionHorarios"] = new FrmAsignacionHorarios();
                _cachedForms["VacacionesPermisos"] = new FrmVacacionesPermisos();
                _cachedForms["Biometricos"] = new FrmBiometricos();
                _cachedForms["Asistencias"] = new FrmAsistencias();
                _cachedForms["Usuarios"] = new FrmUsuarios();
                _cachedForms["Settings"] = new RJSettingsForm();

                foreach (var kvp in _cachedForms)
                {
                    Form f = kvp.Value;
                    f.TopLevel = false;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.Dock = DockStyle.Fill;
                    if (f is RJCodeUI_M1.RJForms.RJChildForm childForm)
                    {
                        childForm.IsChildForm = true;
                    }
                    f.Visible = false;
                    pnlContenedor.Controls.Add(f);
                }
            }
            catch { }
        }

        private void AddControlBox()
        {
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Controls.Add(this.btnMaximize);
            this.pnlTitleBar.Controls.Add(this.btnMinimize);
            this.pnlTitleBar.Controls.Add(this.btnInfoSistema);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnInfoSistema.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnClose.Height = 35;
            this.btnClose.Width = 42;
            this.btnMaximize.Height = 35;
            this.btnMaximize.Width = 42;
            this.btnMinimize.Height = 35;
            this.btnMinimize.Width = 42;

            this.btnInfoSistema.Height = 35;
            this.btnInfoSistema.Width = 38;
            this.btnInfoSistema.IconSize = 18;
            this.btnInfoSistema.SizeMode = PictureBoxSizeMode.CenterImage;

            this.btnClose.Location = new Point(this.pnlTitleBar.Width - btnClose.Width, 0);
            this.btnMaximize.Location = new Point(this.btnClose.Location.X - btnMaximize.Width, 0);
            this.btnMinimize.Location = new Point(this.btnMaximize.Location.X - btnMinimize.Width, 0);
            this.btnInfoSistema.Location = new Point(this.btnMinimize.Location.X - btnInfoSistema.Width, 0);

            this.btnInfoSistema.MouseEnter += (s, e) =>
            {
                bool dark = RJCodeUI_M1.Settings.UIAppearance.Theme == RJCodeUI_M1.Settings.UITheme.Dark;
                this.btnInfoSistema.BackColor = dark ? Color.FromArgb(45, 52, 80) : Color.FromArgb(230, 235, 245);
                this.btnInfoSistema.IconColor = dark ? Color.White : Color.FromArgb(40, 53, 147);
            };
            this.btnInfoSistema.MouseLeave += (s, e) =>
            {
                bool dark = RJCodeUI_M1.Settings.UIAppearance.Theme == RJCodeUI_M1.Settings.UITheme.Dark;
                this.btnInfoSistema.BackColor = Color.Transparent;
                this.btnInfoSistema.IconColor = dark ? Color.FromArgb(160, 175, 200) : Color.FromArgb(100, 116, 139);
            };

            this.btnClose.BringToFront();
            this.btnMaximize.BringToFront();
            this.btnMinimize.BringToFront();
            this.btnInfoSistema.BringToFront();
        }

        public void AplicarTema()
        {
            this.PrimaryForm = true;
            this.Resizable = true;

            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            Color colorFondo = esOscuro ? Color.FromArgb(18, 22, 38) : Color.FromArgb(245, 247, 251);
            this.BackColor = colorFondo;
            pnlContenedor.BackColor = colorFondo;

            if (esOscuro)
            {
                pnlSideMenu.BackColor = Color.FromArgb(18, 22, 38);
                pnlSideMenuHeader.BackColor = Color.FromArgb(13, 16, 30);
                pnlTitleBar.BackColor = Color.FromArgb(25, 30, 50);
                lblTituloSeccion.ForeColor = Color.White;
                lblUsuarioNombre.ForeColor = Color.White;
                lblUsuarioRol.ForeColor = Color.FromArgb(160, 175, 200);
                lblReloj.ForeColor = Color.FromArgb(160, 175, 200);

                this.btnClose.Image = RJCodeUI_M1.Properties.Resources.CloseWhite;
                this.btnMaximize.Image = RJCodeUI_M1.Properties.Resources.MaximizeWhite;
                this.btnMinimize.Image = RJCodeUI_M1.Properties.Resources.MinimizeWhite;
            }
            else
            {
                pnlSideMenu.BackColor = Color.FromArgb(24, 30, 54);
                pnlSideMenuHeader.BackColor = Color.FromArgb(18, 23, 42);
                pnlTitleBar.BackColor = Color.White;
                lblTituloSeccion.ForeColor = Color.FromArgb(30, 41, 59);
                lblUsuarioNombre.ForeColor = Color.FromArgb(30, 41, 59);
                lblUsuarioRol.ForeColor = Color.Gray;
                lblReloj.ForeColor = Color.FromArgb(100, 116, 139);

                this.btnClose.Image = RJCodeUI_M1.Properties.Resources.CloseDark;
                this.btnMaximize.Image = RJCodeUI_M1.Properties.Resources.MaximizeDark;
                this.btnMinimize.Image = RJCodeUI_M1.Properties.Resources.MinimizeDark;
            }

            ActualizarLogoInstitucional(esOscuro);

            Color colorPrimario = UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(0, 180, 216);
            pbPerfil.BorderColor = colorPrimario;
            btnInfoSistema.IconColor = esOscuro ? Color.FromArgb(160, 175, 200) : Color.FromArgb(100, 116, 139);

            if (_botonActivo != null)
            {
                ActivarBoton(_botonActivo);
            }
            else
            {
                ResetearBotones();
            }

            foreach (var kvp in _cachedForms)
            {
                Form f = kvp.Value;
                if (f != null && !f.IsDisposed)
                {
                    if (f is FrmDashboard dash)
                    {
                        dash.AplicarTema();
                    }
                    else
                    {
                        Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(f);
                    }
                }
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                lblUsuarioNombre.Text = _usuarioActual.Nombre;
                lblUsuarioRol.Text = $"Rol: {_usuarioActual.NombreRol}";

                if (_usuarioActual.NombreRol.Equals("Operador", StringComparison.OrdinalIgnoreCase))
                {
                    btnNavUsuarios.Visible = false;
                }
            }

            ActualizarReloj();
            ActivarBoton(btnNavDashboard);
            AbrirFormularioEnContenedor("Dashboard", () => new FrmDashboard(), "Panel Principal / Resumen");
        }

        public void AbrirFormularioEnContenedor(string key, Func<Form> factory, string tituloSeccion)
        {
            lblTituloSeccion.Text = tituloSeccion;

            if (_formularioActivo != null)
            {
                _formularioActivo.Visible = false;
            }

            if (!_cachedForms.TryGetValue(key, out Form form) || form == null || form.IsDisposed)
            {
                form = factory();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                if (form is RJCodeUI_M1.RJForms.RJChildForm childForm)
                {
                    childForm.IsChildForm = true;
                }
                _cachedForms[key] = form;
                pnlContenedor.Controls.Add(form);
            }

            _formularioActivo = form;
            form.BringToFront();
            form.Visible = true;
            form.Show();

            if (form is FrmDashboard dash)
            {
                dash.AplicarTema();
            }
            else
            {
                Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(form);
            }
        }

        public void AbrirFormularioEnContenedor(Form formularioHijo, string tituloSeccion)
        {
            string key = formularioHijo.GetType().Name;
            AbrirFormularioEnContenedor(key, () => formularioHijo, tituloSeccion);
        }

        private void ActivarBoton(RJMenuButton botonNav)
        {
            if (botonNav == null) return;

            ResetearBotones();
            _botonActivo = botonNav;

            Color colorPrimario = UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(0, 180, 216);
            Color colorFondoBoton = (UIAppearance.Theme == UITheme.Dark) ? Color.FromArgb(30, 36, 62) : Color.FromArgb(35, 42, 75);

            botonNav.BackColor = colorFondoBoton;
            botonNav.ForeColor = Color.White;
            botonNav.IconColor = colorPrimario;
            botonNav.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void ResetearBotones()
        {
            Color colorInactivo = (UIAppearance.Theme == UITheme.Dark) ? Color.FromArgb(18, 22, 38) : Color.FromArgb(24, 30, 54);
            Color textoInactivo = Color.FromArgb(200, 210, 235);
            Font fuenteNormal = new Font("Segoe UI", 10F, FontStyle.Regular);

            btnNavDashboard.BackColor = colorInactivo;
            btnNavDashboard.ForeColor = textoInactivo;
            btnNavDashboard.IconColor = Color.FromArgb(0, 180, 216);
            btnNavDashboard.Font = fuenteNormal;

            btnNavEmpleados.BackColor = colorInactivo;
            btnNavEmpleados.ForeColor = textoInactivo;
            btnNavEmpleados.IconColor = Color.FromArgb(66, 165, 245);
            btnNavEmpleados.Font = fuenteNormal;

            btnNavDepartamentos.BackColor = colorInactivo;
            btnNavDepartamentos.ForeColor = textoInactivo;
            btnNavDepartamentos.IconColor = Color.FromArgb(78, 205, 196);
            btnNavDepartamentos.Font = fuenteNormal;

            btnNavHorarios.BackColor = colorInactivo;
            btnNavHorarios.ForeColor = textoInactivo;
            btnNavHorarios.IconColor = Color.FromArgb(255, 193, 7);
            btnNavHorarios.Font = fuenteNormal;

            btnNavAsignacionHorarios.BackColor = colorInactivo;
            btnNavAsignacionHorarios.ForeColor = textoInactivo;
            btnNavAsignacionHorarios.IconColor = Color.FromArgb(255, 112, 67);
            btnNavAsignacionHorarios.Font = fuenteNormal;

            btnNavVacaciones.BackColor = colorInactivo;
            btnNavVacaciones.ForeColor = textoInactivo;
            btnNavVacaciones.IconColor = Color.FromArgb(240, 98, 146);
            btnNavVacaciones.Font = fuenteNormal;

            btnNavBiometricos.BackColor = colorInactivo;
            btnNavBiometricos.ForeColor = textoInactivo;
            btnNavBiometricos.IconColor = Color.FromArgb(0, 180, 216);
            btnNavBiometricos.Font = fuenteNormal;

            btnNavAsistencias.BackColor = colorInactivo;
            btnNavAsistencias.ForeColor = textoInactivo;
            btnNavAsistencias.IconColor = Color.FromArgb(102, 187, 106);
            btnNavAsistencias.Font = fuenteNormal;

            btnNavUsuarios.BackColor = colorInactivo;
            btnNavUsuarios.ForeColor = textoInactivo;
            btnNavUsuarios.IconColor = Color.FromArgb(255, 167, 38);
            btnNavUsuarios.Font = fuenteNormal;

            btnNavTema.BackColor = colorInactivo;
            btnNavTema.ForeColor = textoInactivo;
            btnNavTema.IconColor = Color.FromArgb(171, 71, 188);
            btnNavTema.Font = fuenteNormal;

            btnNavSalir.BackColor = colorInactivo;
            btnNavSalir.ForeColor = textoInactivo;
            btnNavSalir.IconColor = Color.FromArgb(239, 83, 80);
            btnNavSalir.Font = fuenteNormal;
            btnNavSalir.FlatAppearance.MouseOverBackColor = (UIAppearance.Theme == UITheme.Dark ? Color.FromArgb(30, 36, 62) : Color.FromArgb(35, 42, 75));
            btnNavSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 40, 50);
        }

        private void btnInfoSistema_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmInfoSistema())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavDashboard);
            AbrirFormularioEnContenedor("Dashboard", () => new FrmDashboard(), "Panel Principal / Resumen");
        }

        private void btnNavEmpleados_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavEmpleados);
            AbrirFormularioEnContenedor("Empleados", () => new FrmEmpleados(), "Gestión de Empleados");
        }

        private void btnNavDepartamentos_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavDepartamentos);
            AbrirFormularioEnContenedor("Departamentos", () => new FrmDepartamentos(), "Gestión de Departamentos");
        }

        private void btnNavHorarios_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavHorarios);
            AbrirFormularioEnContenedor("Horarios", () => new FrmHorarios(), "Creación y Configuración de Horarios");
        }

        private void btnNavAsignacionHorarios_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavAsignacionHorarios);
            AbrirFormularioEnContenedor("AsignacionHorarios", () => new FrmAsignacionHorarios(), "Asignación de Turnos");
        }

        private void btnNavVacaciones_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavVacaciones);
            AbrirFormularioEnContenedor("VacacionesPermisos", () => new FrmVacacionesPermisos(), "Gestión de Vacaciones y Permisos");
        }

        private void btnNavBiometricos_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavBiometricos);
            AbrirFormularioEnContenedor("Biometricos", () => new FrmBiometricos(), "Gestión de Biométricos ZKTeco");
        }

        private void btnNavAsistencias_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavAsistencias);
            AbrirFormularioEnContenedor("Asistencias", () => new FrmAsistencias(), "Marcaciones y Asistencias");
        }

        private void btnNavUsuarios_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavUsuarios);
            AbrirFormularioEnContenedor("Usuarios", () => new FrmUsuarios(), "Usuarios del Sistema");
        }

        private void btnNavTema_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnNavTema);
            AbrirFormularioEnContenedor("Settings", () => new RJSettingsForm(), "Configuración de Apariencia y Tema");
        }

        public bool CerrarSesionSolicitado { get; private set; } = false;

        private void btnNavSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?", "Cerrar Sesión",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CerrarSesionSolicitado = true;
                this.Close();
            }
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }

        private void ActualizarReloj()
        {
            lblReloj.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  hh:mm:ss tt");
        }

        private void IniciarServiciosEnVivo()
        {
            try
            {
                // Iniciar escucha en tiempo real de todos los relojes configurados
                ZKTecoLiveListener.Instancia.Iniciar();

                // Iniciar servidor WebSocket para emisión en vivo a dashboards/clientes
                LiveWebSocketServer.Instancia.Iniciar(8181);

                // Manejador para refresco dinámico de vistas
                ZKTecoLiveListener.Instancia.OnMarcacionRecibida += (evt) =>
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            // Si el dashboard está activo, actualizar
                            if (_formularioActivo is FrmDashboard dash)
                            {
                                dash.CargarResumen();
                            }
                        }));
                    }
                };
            }
            catch { }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ZKTecoLiveListener.Instancia.Detener();
                LiveWebSocketServer.Instancia.Detener();
            }
            catch { }

            if (!CerrarSesionSolicitado)
            {
                Application.Exit();
            }
        }
    }
}
