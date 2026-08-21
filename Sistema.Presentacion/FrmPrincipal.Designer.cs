namespace Sistema.Presentacion
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnNavSalir = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavTema = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavUsuarios = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavAsistencias = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavBiometricos = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavEmpleados = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.btnNavDashboard = new RJCodeUI_M1.RJControls.RJMenuButton();
            this.pnlSideMenuHeader = new System.Windows.Forms.Panel();
            this.lblLogoSubtitle = new System.Windows.Forms.Label();
            this.lblLogoTitle = new System.Windows.Forms.Label();
            this.picSideLogo = new FontAwesome.Sharp.IconPictureBox();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnInfoSistema = new FontAwesome.Sharp.IconPictureBox();
            this.lblUsuarioRol = new System.Windows.Forms.Label();
            this.lblUsuarioNombre = new System.Windows.Forms.Label();
            this.pbPerfil = new RJCodeUI_M1.RJControls.RJCircularPictureBox();
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.timerReloj = new System.Windows.Forms.Timer(this.components);
            this.dragControlTitleBar = new RJCodeUI_M1.RJControls.RJDragControl(this.components);
            this.dragControlSideHeader = new RJCodeUI_M1.RJControls.RJDragControl(this.components);
            this.pnlSideMenu.SuspendLayout();
            this.pnlSideMenuHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSideLogo)).BeginInit();
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInfoSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlSideMenu.Controls.Add(this.btnNavSalir);
            this.pnlSideMenu.Controls.Add(this.btnNavTema);
            this.pnlSideMenu.Controls.Add(this.btnNavUsuarios);
            this.pnlSideMenu.Controls.Add(this.btnNavAsistencias);
            this.pnlSideMenu.Controls.Add(this.btnNavBiometricos);
            this.pnlSideMenu.Controls.Add(this.btnNavEmpleados);
            this.pnlSideMenu.Controls.Add(this.btnNavDashboard);
            this.pnlSideMenu.Controls.Add(this.pnlSideMenuHeader);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(235, 760);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // btnNavSalir
            // 
            this.btnNavSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNavSalir.FlatAppearance.BorderSize = 0;
            this.btnNavSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnNavSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(80)))));
            this.btnNavSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavSalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnNavSalir.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.btnNavSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavSalir.IconSize = 24;
            this.btnNavSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSalir.Location = new System.Drawing.Point(0, 710);
            this.btnNavSalir.Name = "btnNavSalir";
            this.btnNavSalir.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavSalir.Size = new System.Drawing.Size(235, 50);
            this.btnNavSalir.TabIndex = 7;
            this.btnNavSalir.Text = "   Cerrar Sesión";
            this.btnNavSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavSalir.UseVisualStyleBackColor = false;
            this.btnNavSalir.Click += new System.EventHandler(this.btnNavSalir_Click);
            // 
            // btnNavTema
            // 
            this.btnNavTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavTema.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavTema.FlatAppearance.BorderSize = 0;
            this.btnNavTema.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavTema.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavTema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavTema.IconChar = FontAwesome.Sharp.IconChar.Palette;
            this.btnNavTema.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(71)))), ((int)(((byte)(188)))));
            this.btnNavTema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavTema.IconSize = 24;
            this.btnNavTema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTema.Location = new System.Drawing.Point(0, 325);
            this.btnNavTema.Name = "btnNavTema";
            this.btnNavTema.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavTema.Size = new System.Drawing.Size(235, 50);
            this.btnNavTema.TabIndex = 6;
            this.btnNavTema.Text = "   Tema / Apariencia";
            this.btnNavTema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavTema.UseVisualStyleBackColor = false;
            this.btnNavTema.Click += new System.EventHandler(this.btnNavTema_Click);
            // 
            // btnNavUsuarios
            // 
            this.btnNavUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavUsuarios.FlatAppearance.BorderSize = 0;
            this.btnNavUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            this.btnNavUsuarios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.btnNavUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavUsuarios.IconSize = 24;
            this.btnNavUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsuarios.Location = new System.Drawing.Point(0, 275);
            this.btnNavUsuarios.Name = "btnNavUsuarios";
            this.btnNavUsuarios.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavUsuarios.Size = new System.Drawing.Size(235, 50);
            this.btnNavUsuarios.TabIndex = 5;
            this.btnNavUsuarios.Text = "   Usuarios del Sistema";
            this.btnNavUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavUsuarios.UseVisualStyleBackColor = false;
            this.btnNavUsuarios.Click += new System.EventHandler(this.btnNavUsuarios_Click);
            // 
            // btnNavAsistencias
            // 
            this.btnNavAsistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavAsistencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavAsistencias.FlatAppearance.BorderSize = 0;
            this.btnNavAsistencias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavAsistencias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavAsistencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAsistencias.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAsistencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavAsistencias.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnNavAsistencias.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnNavAsistencias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavAsistencias.IconSize = 24;
            this.btnNavAsistencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAsistencias.Location = new System.Drawing.Point(0, 225);
            this.btnNavAsistencias.Name = "btnNavAsistencias";
            this.btnNavAsistencias.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavAsistencias.Size = new System.Drawing.Size(235, 50);
            this.btnNavAsistencias.TabIndex = 4;
            this.btnNavAsistencias.Text = "   Marcaciones / Asist.";
            this.btnNavAsistencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAsistencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavAsistencias.UseVisualStyleBackColor = false;
            this.btnNavAsistencias.Click += new System.EventHandler(this.btnNavAsistencias_Click);
            // 
            // btnNavBiometricos
            // 
            this.btnNavBiometricos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavBiometricos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavBiometricos.FlatAppearance.BorderSize = 0;
            this.btnNavBiometricos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavBiometricos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavBiometricos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBiometricos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavBiometricos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavBiometricos.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.btnNavBiometricos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnNavBiometricos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavBiometricos.IconSize = 24;
            this.btnNavBiometricos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBiometricos.Location = new System.Drawing.Point(0, 175);
            this.btnNavBiometricos.Name = "btnNavBiometricos";
            this.btnNavBiometricos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavBiometricos.Size = new System.Drawing.Size(235, 50);
            this.btnNavBiometricos.TabIndex = 3;
            this.btnNavBiometricos.Text = "   Biométricos ZKTeco";
            this.btnNavBiometricos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBiometricos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavBiometricos.UseVisualStyleBackColor = false;
            this.btnNavBiometricos.Click += new System.EventHandler(this.btnNavBiometricos_Click);
            // 
            // btnNavEmpleados
            // 
            this.btnNavEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnNavEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavEmpleados.FlatAppearance.BorderSize = 0;
            this.btnNavEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEmpleados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.btnNavEmpleados.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnNavEmpleados.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.btnNavEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavEmpleados.IconSize = 24;
            this.btnNavEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEmpleados.Location = new System.Drawing.Point(0, 125);
            this.btnNavEmpleados.Name = "btnNavEmpleados";
            this.btnNavEmpleados.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavEmpleados.Size = new System.Drawing.Size(235, 50);
            this.btnNavEmpleados.TabIndex = 2;
            this.btnNavEmpleados.Text = "   Empleados";
            this.btnNavEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavEmpleados.UseVisualStyleBackColor = false;
            this.btnNavEmpleados.Click += new System.EventHandler(this.btnNavEmpleados_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.btnNavDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnNavDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavDashboard.IconSize = 24;
            this.btnNavDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 75);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(235, 50);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "   Panel Principal";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // pnlSideMenuHeader
            this.pbLogoInstitucional = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoInstitucional)).BeginInit();
            this.pnlSideMenuHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSideMenuHeader.Controls.Add(this.pbLogoInstitucional);
            this.pnlSideMenuHeader.Controls.Add(this.lblLogoSubtitle);
            this.pnlSideMenuHeader.Controls.Add(this.lblLogoTitle);
            this.pnlSideMenuHeader.Controls.Add(this.picSideLogo);
            this.pnlSideMenuHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSideMenuHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenuHeader.Name = "pnlSideMenuHeader";
            this.pnlSideMenuHeader.Size = new System.Drawing.Size(235, 75);
            this.pnlSideMenuHeader.TabIndex = 0;
            // 
            // pbLogoInstitucional
            // 
            this.pbLogoInstitucional.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoInstitucional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogoInstitucional.Location = new System.Drawing.Point(0, 0);
            this.pbLogoInstitucional.Name = "pbLogoInstitucional";
            this.pbLogoInstitucional.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pbLogoInstitucional.Size = new System.Drawing.Size(235, 75);
            this.pbLogoInstitucional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoInstitucional.TabIndex = 3;
            this.pbLogoInstitucional.TabStop = false;
            // 
            // lblLogoSubtitle
            // 
            this.lblLogoSubtitle.AutoSize = true;
            this.lblLogoSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblLogoSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.lblLogoSubtitle.Location = new System.Drawing.Point(70, 42);
            this.lblLogoSubtitle.Name = "lblLogoSubtitle";
            this.lblLogoSubtitle.Size = new System.Drawing.Size(83, 12);
            this.lblLogoSubtitle.TabIndex = 2;
            this.lblLogoSubtitle.Text = "ZKTECO SYSTEM";
            // 
            // lblLogoTitle
            // 
            this.lblLogoTitle.AutoSize = true;
            this.lblLogoTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblLogoTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogoTitle.Location = new System.Drawing.Point(70, 20);
            this.lblLogoTitle.Name = "lblLogoTitle";
            this.lblLogoTitle.Size = new System.Drawing.Size(111, 21);
            this.lblLogoTitle.TabIndex = 1;
            this.lblLogoTitle.Text = "ASISTENCIAS";
            // 
            // picSideLogo
            // 
            this.picSideLogo.BackColor = System.Drawing.Color.Transparent;
            this.picSideLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picSideLogo.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.picSideLogo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picSideLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picSideLogo.IconSize = 42;
            this.picSideLogo.Location = new System.Drawing.Point(15, 18);
            this.picSideLogo.Name = "picSideLogo";
            this.picSideLogo.Size = new System.Drawing.Size(45, 42);
            this.picSideLogo.TabIndex = 0;
            this.picSideLogo.TabStop = false;
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.White;
            this.pnlTitleBar.Controls.Add(this.btnInfoSistema);
            this.pnlTitleBar.Controls.Add(this.lblUsuarioRol);
            this.pnlTitleBar.Controls.Add(this.lblUsuarioNombre);
            this.pnlTitleBar.Controls.Add(this.pbPerfil);
            this.pnlTitleBar.Controls.Add(this.lblReloj);
            this.pnlTitleBar.Controls.Add(this.lblTituloSeccion);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(235, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1045, 60);
            this.pnlTitleBar.TabIndex = 1;
            // 
            // btnInfoSistema
            // 
            this.btnInfoSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfoSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnInfoSistema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfoSistema.ForeColor = System.Drawing.Color.Gray;
            this.btnInfoSistema.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.btnInfoSistema.IconColor = System.Drawing.Color.Gray;
            this.btnInfoSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfoSistema.IconSize = 18;
            this.btnInfoSistema.Location = new System.Drawing.Point(880, 0);
            this.btnInfoSistema.Name = "btnInfoSistema";
            this.btnInfoSistema.Size = new System.Drawing.Size(38, 35);
            this.btnInfoSistema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnInfoSistema.TabIndex = 5;
            this.btnInfoSistema.TabStop = false;
            this.btnInfoSistema.Click += new System.EventHandler(this.btnInfoSistema_Click);
            // 
            // lblUsuarioRol
            // 
            this.lblUsuarioRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioRol.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUsuarioRol.ForeColor = System.Drawing.Color.Gray;
            this.lblUsuarioRol.Location = new System.Drawing.Point(710, 32);
            this.lblUsuarioRol.Name = "lblUsuarioRol";
            this.lblUsuarioRol.Size = new System.Drawing.Size(160, 15);
            this.lblUsuarioRol.TabIndex = 4;
            this.lblUsuarioRol.Text = "Rol: Administrador";
            this.lblUsuarioRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuarioNombre
            // 
            this.lblUsuarioNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblUsuarioNombre.Location = new System.Drawing.Point(710, 12);
            this.lblUsuarioNombre.Name = "lblUsuarioNombre";
            this.lblUsuarioNombre.Size = new System.Drawing.Size(160, 20);
            this.lblUsuarioNombre.TabIndex = 3;
            this.lblUsuarioNombre.Text = "Administrador";
            this.lblUsuarioNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbPerfil
            // 
            this.pbPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPerfil.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pbPerfil.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.pbPerfil.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.pbPerfil.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pbPerfil.BorderSize = 2;
            this.pbPerfil.GradientAngle = 50F;
            this.pbPerfil.Image = global::RJCodeUI_M1.Properties.Resources.userProfile;
            this.pbPerfil.Location = new System.Drawing.Point(880, 10);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(40, 40);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPerfil.TabIndex = 2;
            this.pbPerfil.TabStop = false;
            // 
            // lblReloj
            // 
            this.lblReloj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReloj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReloj.Location = new System.Drawing.Point(340, 20);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(350, 20);
            this.lblReloj.TabIndex = 1;
            this.lblReloj.Text = "--";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloSeccion.Location = new System.Drawing.Point(20, 19);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(201, 21);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "Panel Principal / Resumen";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(235, 60);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1045, 700);
            this.pnlContenedor.TabIndex = 2;
            // 
            // timerReloj
            // 
            this.timerReloj.Enabled = true;
            this.timerReloj.Interval = 1000;
            this.timerReloj.Tick += new System.EventHandler(this.timerReloj_Tick);
            // 
            // dragControlTitleBar
            // 
            this.dragControlTitleBar.DragControl = this.pnlTitleBar;
            // 
            // dragControlSideHeader
            // 
            this.dragControlSideHeader.DragControl = this.pnlSideMenuHeader;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Control de Asistencias - ZKTeco Enterprise";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlSideMenuHeader.ResumeLayout(false);
            this.pnlSideMenuHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSideLogo)).EndInit();
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlSideMenuHeader;
        private System.Windows.Forms.PictureBox pbLogoInstitucional;
        private FontAwesome.Sharp.IconPictureBox picSideLogo;
        private System.Windows.Forms.Label lblLogoTitle;
        private System.Windows.Forms.Label lblLogoSubtitle;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavDashboard;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavEmpleados;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavBiometricos;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavAsistencias;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavUsuarios;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavTema;
        private RJCodeUI_M1.RJControls.RJMenuButton btnNavSalir;
        private System.Windows.Forms.Panel pnlTitleBar;
        private FontAwesome.Sharp.IconPictureBox btnInfoSistema;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Label lblReloj;
        private RJCodeUI_M1.RJControls.RJCircularPictureBox pbPerfil;
        private System.Windows.Forms.Label lblUsuarioNombre;
        private System.Windows.Forms.Label lblUsuarioRol;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Timer timerReloj;
        private RJCodeUI_M1.RJControls.RJDragControl dragControlTitleBar;
        private RJCodeUI_M1.RJControls.RJDragControl dragControlSideHeader;
    }
}
