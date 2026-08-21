namespace Sistema.Presentacion
{
    partial class FrmLogin
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
            this.dragControl1 = new RJCodeUI_M1.RJControls.RJDragControl(this.components);
            this.dragControl2 = new RJCodeUI_M1.RJControls.RJDragControl(this.components);
            this.icoBanner = new RJCodeUI_M1.RJControls.RJImageColorOverlay();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new FontAwesome.Sharp.IconPictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblCaption = new RJCodeUI_M1.RJControls.RJLabel();
            this.txtEmail = new RJCodeUI_M1.RJControls.RJTextBox();
            this.txtClave = new RJCodeUI_M1.RJControls.RJTextBox();
            this.btnIngresar = new RJCodeUI_M1.RJControls.RJButton();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblEstadoBD = new System.Windows.Forms.Label();
            this.icoUser = new FontAwesome.Sharp.IconPictureBox();
            this.icoLock = new FontAwesome.Sharp.IconPictureBox();
            this.icoBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoLock)).BeginInit();
            this.SuspendLayout();
            // 
            // dragControl1
            // 
            this.dragControl1.DragControl = this;
            // 
            // dragControl2
            // 
            this.dragControl2.DragControl = this.icoBanner;
            // 
            // icoBanner
            // 
            this.icoBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoBanner.Controls.Add(this.lblVersion);
            this.icoBanner.Controls.Add(this.lblDescription);
            this.icoBanner.Controls.Add(this.lblTitle);
            this.icoBanner.Controls.Add(this.picLogo);
            this.icoBanner.Controls.Add(this.lblWelcome);
            this.icoBanner.Customizable = false;
            this.icoBanner.Dock = System.Windows.Forms.DockStyle.Left;
            this.icoBanner.Image = null;
            this.icoBanner.Location = new System.Drawing.Point(0, 0);
            this.icoBanner.Name = "icoBanner";
            this.icoBanner.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoBanner.Size = new System.Drawing.Size(340, 460);
            this.icoBanner.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            this.lblVersion.Location = new System.Drawing.Point(15, 415);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(310, 35);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "\u00A9 " + System.DateTime.Now.Year.ToString() + " Hospital de El Progreso. Todos los derechos reservados.";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.lblDescription.Location = new System.Drawing.Point(25, 260);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(290, 80);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Plataforma Integral de Gestión de Asistencias, Turnos y Comunicación con Relojes Biométricos ZKTeco.";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 195);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 55);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "SISTEMA DE ASISTENCIAS ZKTECO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.ForeColor = System.Drawing.Color.White;
            this.picLogo.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.picLogo.IconColor = System.Drawing.Color.White;
            this.picLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picLogo.IconSize = 75;
            this.picLogo.Location = new System.Drawing.Point(132, 90);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(75, 75);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.lblWelcome.Location = new System.Drawing.Point(115, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(110, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "BIENVENIDO A";
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.lblCaption.LinkLabel = false;
            this.lblCaption.Location = new System.Drawing.Point(400, 50);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(150, 30);
            this.lblCaption.Style = RJCodeUI_M1.RJControls.LabelStyle.Title2;
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "Iniciar Sesión";
            // 
            // txtEmail
            // 
            this.txtEmail._Customizable = false;
            this.txtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.txtEmail.BorderRadius = 0;
            this.txtEmail.BorderSize = 2;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.Location = new System.Drawing.Point(440, 140);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.MultiLine = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(7);
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceHolderText = "Usuario o Correo";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.Size = new System.Drawing.Size(270, 34);
            this.txtEmail.Style = RJCodeUI_M1.RJControls.TextBoxStyle.MatteLine;
            this.txtEmail.TabIndex = 2;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // txtClave
            // 
            this.txtClave._Customizable = false;
            this.txtClave.BackColor = System.Drawing.SystemColors.Control;
            this.txtClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.txtClave.BorderRadius = 0;
            this.txtClave.BorderSize = 2;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtClave.Location = new System.Drawing.Point(440, 205);
            this.txtClave.MaxLength = 100;
            this.txtClave.MultiLine = false;
            this.txtClave.Name = "txtClave";
            this.txtClave.Padding = new System.Windows.Forms.Padding(7);
            this.txtClave.PasswordChar = true;
            this.txtClave.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtClave.PlaceHolderText = "Contraseña";
            this.txtClave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClave.Size = new System.Drawing.Size(270, 34);
            this.txtClave.Style = RJCodeUI_M1.RJControls.TextBoxStyle.MatteLine;
            this.txtClave.TabIndex = 3;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.btnIngresar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.btnIngresar.BorderRadius = 20;
            this.btnIngresar.BorderSize = 0;
            this.btnIngresar.Design = RJCodeUI_M1.RJControls.ButtonDesign.Custom;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnIngresar.IconColor = System.Drawing.Color.White;
            this.btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresar.IconSize = 22;
            this.btnIngresar.Location = new System.Drawing.Point(405, 290);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(305, 42);
            this.btnIngresar.Style = RJCodeUI_M1.RJControls.ControlStyle.Solid;
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "  Iniciar Sesión";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(405, 255);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(305, 25);
            this.lblMensaje.TabIndex = 5;
            this.lblMensaje.Text = "* Mensaje de validación";
            this.lblMensaje.Visible = false;
            // 
            // lblEstadoBD
            // 
            this.lblEstadoBD.AutoSize = true;
            this.lblEstadoBD.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoBD.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblEstadoBD.Location = new System.Drawing.Point(405, 425);
            this.lblEstadoBD.Name = "lblEstadoBD";
            this.lblEstadoBD.Size = new System.Drawing.Size(160, 15);
            this.lblEstadoBD.TabIndex = 6;
            this.lblEstadoBD.Text = "● BD Conectada (PostgreSQL)";
            // 
            // icoUser
            // 
            this.icoUser.BackColor = System.Drawing.Color.Transparent;
            this.icoUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.icoUser.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoUser.IconSize = 24;
            this.icoUser.Location = new System.Drawing.Point(405, 145);
            this.icoUser.Name = "icoUser";
            this.icoUser.Size = new System.Drawing.Size(24, 24);
            this.icoUser.TabIndex = 7;
            this.icoUser.TabStop = false;
            // 
            // icoLock
            // 
            this.icoLock.BackColor = System.Drawing.Color.Transparent;
            this.icoLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoLock.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.icoLock.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.icoLock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoLock.IconSize = 24;
            this.icoLock.Location = new System.Drawing.Point(405, 210);
            this.icoLock.Name = "icoLock";
            this.icoLock.Size = new System.Drawing.Size(24, 24);
            this.icoLock.TabIndex = 8;
            this.icoLock.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 460);
            this.Controls.Add(this.icoLock);
            this.Controls.Add(this.icoUser);
            this.Controls.Add(this.lblEstadoBD);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.icoBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión - Control de Asistencias";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.icoBanner.ResumeLayout(false);
            this.icoBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoLock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJCodeUI_M1.RJControls.RJImageColorOverlay icoBanner;
        private RJCodeUI_M1.RJControls.RJDragControl dragControl1;
        private RJCodeUI_M1.RJControls.RJDragControl dragControl2;
        private System.Windows.Forms.Label lblWelcome;
        private FontAwesome.Sharp.IconPictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVersion;
        private RJCodeUI_M1.RJControls.RJLabel lblCaption;
        private RJCodeUI_M1.RJControls.RJTextBox txtEmail;
        private RJCodeUI_M1.RJControls.RJTextBox txtClave;
        private RJCodeUI_M1.RJControls.RJButton btnIngresar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblEstadoBD;
        private FontAwesome.Sharp.IconPictureBox icoUser;
        private FontAwesome.Sharp.IconPictureBox icoLock;
    }
}
