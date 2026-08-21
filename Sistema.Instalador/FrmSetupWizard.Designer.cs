namespace Sistema.Instalador
{
    partial class FrmSetupWizard
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.picHeaderIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.pnlContenedorPasos = new System.Windows.Forms.Panel();
            this.pnlPaso1_Bienvenida = new System.Windows.Forms.Panel();
            this.lblDescBienvenida = new System.Windows.Forms.Label();
            this.lblTituloBienvenida = new System.Windows.Forms.Label();
            this.picBienvenida = new FontAwesome.Sharp.IconPictureBox();
            this.pnlPaso2_Prerrequisitos = new System.Windows.Forms.Panel();
            this.pnlCardSDK = new System.Windows.Forms.Panel();
            this.lblSdkDesc = new System.Windows.Forms.Label();
            this.lblSdkStatus = new System.Windows.Forms.Label();
            this.lblSdkTitle = new System.Windows.Forms.Label();
            this.picSdk = new FontAwesome.Sharp.IconPictureBox();
            this.pnlCardVC = new System.Windows.Forms.Panel();
            this.btnInstalarVC = new System.Windows.Forms.Button();
            this.lblVcDesc = new System.Windows.Forms.Label();
            this.lblVcStatus = new System.Windows.Forms.Label();
            this.lblVcTitle = new System.Windows.Forms.Label();
            this.picVC = new FontAwesome.Sharp.IconPictureBox();
            this.pnlCardNet = new System.Windows.Forms.Panel();
            this.btnInstalarNet = new System.Windows.Forms.Button();
            this.lblNetDesc = new System.Windows.Forms.Label();
            this.lblNetStatus = new System.Windows.Forms.Label();
            this.lblNetTitle = new System.Windows.Forms.Label();
            this.picNet = new FontAwesome.Sharp.IconPictureBox();
            this.lblTituloPrerrequisitos = new System.Windows.Forms.Label();
            this.pnlPaso3_Opciones = new System.Windows.Forms.Panel();
            this.chkServicioWindows = new System.Windows.Forms.CheckBox();
            this.chkMenuInicio = new System.Windows.Forms.CheckBox();
            this.chkEscritorio = new System.Windows.Forms.CheckBox();
            this.lblTituloAccesos = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtRutaDestino = new System.Windows.Forms.TextBox();
            this.lblTituloRuta = new System.Windows.Forms.Label();
            this.pnlPaso4_Progreso = new System.Windows.Forms.Panel();
            this.lblDetalleProgreso = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.progressBarInstalacion = new System.Windows.Forms.ProgressBar();
            this.lblTituloProgreso = new System.Windows.Forms.Label();
            this.pnlPaso5_Finalizado = new System.Windows.Forms.Panel();
            this.chkEjecutarApp = new System.Windows.Forms.CheckBox();
            this.lblDescFinal = new System.Windows.Forms.Label();
            this.lblTituloFinal = new System.Windows.Forms.Label();
            this.picFinal = new FontAwesome.Sharp.IconPictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlContenedorPasos.SuspendLayout();
            this.pnlPaso1_Bienvenida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBienvenida)).BeginInit();
            this.pnlPaso2_Prerrequisitos.SuspendLayout();
            this.pnlCardSDK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSdk)).BeginInit();
            this.pnlCardVC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVC)).BeginInit();
            this.pnlCardNet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNet)).BeginInit();
            this.pnlPaso3_Opciones.SuspendLayout();
            this.pnlPaso4_Progreso.SuspendLayout();
            this.pnlPaso5_Finalizado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.picHeaderIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(75, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(325, 15);
            this.lblHeaderSub.TabIndex = 2;
            this.lblHeaderSub.Text = "Hospital de El Progreso • Control de Asistencias y Biométricos";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(75, 16);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(286, 21);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Asistente de Instalación del Sistema";
            // 
            // picHeaderIcon
            // 
            this.picHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.picHeaderIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picHeaderIcon.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.picHeaderIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picHeaderIcon.IconSize = 44;
            this.picHeaderIcon.Location = new System.Drawing.Point(18, 16);
            this.picHeaderIcon.Name = "picHeaderIcon";
            this.picHeaderIcon.Size = new System.Drawing.Size(44, 44);
            this.picHeaderIcon.TabIndex = 0;
            this.picHeaderIcon.TabStop = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnAtras);
            this.pnlFooter.Controls.Add(this.btnSiguiente);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 425);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(650, 60);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(20, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnAtras.Location = new System.Drawing.Point(395, 14);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(110, 34);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "< Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(515, 14);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(120, 34);
            this.btnSiguiente.TabIndex = 0;
            this.btnSiguiente.Text = "Siguiente >";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // pnlContenedorPasos
            // 
            this.pnlContenedorPasos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlContenedorPasos.Controls.Add(this.pnlPaso1_Bienvenida);
            this.pnlContenedorPasos.Controls.Add(this.pnlPaso2_Prerrequisitos);
            this.pnlContenedorPasos.Controls.Add(this.pnlPaso3_Opciones);
            this.pnlContenedorPasos.Controls.Add(this.pnlPaso4_Progreso);
            this.pnlContenedorPasos.Controls.Add(this.pnlPaso5_Finalizado);
            this.pnlContenedorPasos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPasos.Location = new System.Drawing.Point(0, 75);
            this.pnlContenedorPasos.Name = "pnlContenedorPasos";
            this.pnlContenedorPasos.Size = new System.Drawing.Size(650, 350);
            this.pnlContenedorPasos.TabIndex = 2;
            // 
            // pnlPaso1_Bienvenida
            // 
            this.pnlPaso1_Bienvenida.Controls.Add(this.lblDescBienvenida);
            this.pnlPaso1_Bienvenida.Controls.Add(this.lblTituloBienvenida);
            this.pnlPaso1_Bienvenida.Controls.Add(this.picBienvenida);
            this.pnlPaso1_Bienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso1_Bienvenida.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso1_Bienvenida.Name = "pnlPaso1_Bienvenida";
            this.pnlPaso1_Bienvenida.Padding = new System.Windows.Forms.Padding(30);
            this.pnlPaso1_Bienvenida.Size = new System.Drawing.Size(650, 350);
            this.pnlPaso1_Bienvenida.TabIndex = 0;
            // 
            // lblDescBienvenida
            // 
            this.lblDescBienvenida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescBienvenida.Location = new System.Drawing.Point(140, 75);
            this.lblDescBienvenida.Name = "lblDescBienvenida";
            this.lblDescBienvenida.Size = new System.Drawing.Size(470, 200);
            this.lblDescBienvenida.TabIndex = 2;
            this.lblDescBienvenida.Text = "Este asistente instalará el Sistema de Control de Asistencias y Monitoreo Biomét" +
    "rico ZKTeco en su computadora.\r\n\r\nEl instalador configurará automáticamente:\r\n•" +
    " Aplicación de escritorio y componentes de interfaz moderna.\r\n• Librerías SDK COM nativas de ZKTeco en Windows.\r\n• Acceso a base de datos PostgreSQL y aceleración por caché Redis.\r\n• Opción para Servicio de Windows en segundo plano 24/7.\r\n\r\nHaga clic en \'Siguiente\' para verificar los prerrequisitos del sistema.";
            // 
            // lblTituloBienvenida
            // 
            this.lblTituloBienvenida.AutoSize = true;
            this.lblTituloBienvenida.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloBienvenida.Location = new System.Drawing.Point(140, 30);
            this.lblTituloBienvenida.Name = "lblTituloBienvenida";
            this.lblTituloBienvenida.Size = new System.Drawing.Size(358, 25);
            this.lblTituloBienvenida.TabIndex = 1;
            this.lblTituloBienvenida.Text = "Bienvenido al Asistente de Instalación";
            // 
            // picBienvenida
            // 
            this.picBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.picBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picBienvenida.IconChar = FontAwesome.Sharp.IconChar.HospitalUser;
            this.picBienvenida.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picBienvenida.IconSize = 85;
            this.picBienvenida.Location = new System.Drawing.Point(30, 30);
            this.picBienvenida.Name = "picBienvenida";
            this.picBienvenida.Size = new System.Drawing.Size(85, 85);
            this.picBienvenida.TabIndex = 0;
            this.picBienvenida.TabStop = false;
            // 
            // pnlPaso2_Prerrequisitos
            // 
            this.pnlPaso2_Prerrequisitos.Controls.Add(this.pnlCardSDK);
            this.pnlPaso2_Prerrequisitos.Controls.Add(this.pnlCardVC);
            this.pnlPaso2_Prerrequisitos.Controls.Add(this.pnlCardNet);
            this.pnlPaso2_Prerrequisitos.Controls.Add(this.lblTituloPrerrequisitos);
            this.pnlPaso2_Prerrequisitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso2_Prerrequisitos.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso2_Prerrequisitos.Name = "pnlPaso2_Prerrequisitos";
            this.pnlPaso2_Prerrequisitos.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlPaso2_Prerrequisitos.Size = new System.Drawing.Size(650, 350);
            this.pnlPaso2_Prerrequisitos.TabIndex = 1;
            // 
            // pnlCardSDK
            // 
            this.pnlCardSDK.BackColor = System.Drawing.Color.White;
            this.pnlCardSDK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSDK.Controls.Add(this.lblSdkDesc);
            this.pnlCardSDK.Controls.Add(this.lblSdkStatus);
            this.pnlCardSDK.Controls.Add(this.lblSdkTitle);
            this.pnlCardSDK.Controls.Add(this.picSdk);
            this.pnlCardSDK.Location = new System.Drawing.Point(25, 225);
            this.pnlCardSDK.Name = "pnlCardSDK";
            this.pnlCardSDK.Size = new System.Drawing.Size(600, 75);
            this.pnlCardSDK.TabIndex = 3;
            // 
            // lblSdkDesc
            // 
            this.lblSdkDesc.AutoSize = true;
            this.lblSdkDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSdkDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSdkDesc.Location = new System.Drawing.Point(65, 38);
            this.lblSdkDesc.Name = "lblSdkDesc";
            this.lblSdkDesc.Size = new System.Drawing.Size(325, 15);
            this.lblSdkDesc.TabIndex = 3;
            this.lblSdkDesc.Text = "Librerías COM nativas de comunicación TCP/IP con relojes";
            // 
            // lblSdkStatus
            // 
            this.lblSdkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSdkStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSdkStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblSdkStatus.Location = new System.Drawing.Point(440, 15);
            this.lblSdkStatus.Name = "lblSdkStatus";
            this.lblSdkStatus.Size = new System.Drawing.Size(145, 45);
            this.lblSdkStatus.TabIndex = 2;
            this.lblSdkStatus.Text = "✓ Listo para registrar";
            this.lblSdkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSdkTitle
            // 
            this.lblSdkTitle.AutoSize = true;
            this.lblSdkTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSdkTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSdkTitle.Location = new System.Drawing.Point(65, 16);
            this.lblSdkTitle.Name = "lblSdkTitle";
            this.lblSdkTitle.Size = new System.Drawing.Size(262, 17);
            this.lblSdkTitle.TabIndex = 1;
            this.lblSdkTitle.Text = "ZKTeco Standalone SDK (zkemkeeper.dll)";
            // 
            // picSdk
            // 
            this.picSdk.BackColor = System.Drawing.Color.Transparent;
            this.picSdk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.picSdk.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.picSdk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picSdk.IconSize = 38;
            this.picSdk.Location = new System.Drawing.Point(15, 18);
            this.picSdk.Name = "picSdk";
            this.picSdk.Size = new System.Drawing.Size(38, 38);
            this.picSdk.TabIndex = 0;
            this.picSdk.TabStop = false;
            // 
            // pnlCardVC
            // 
            this.pnlCardVC.BackColor = System.Drawing.Color.White;
            this.pnlCardVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardVC.Controls.Add(this.btnInstalarVC);
            this.pnlCardVC.Controls.Add(this.lblVcDesc);
            this.pnlCardVC.Controls.Add(this.lblVcStatus);
            this.pnlCardVC.Controls.Add(this.lblVcTitle);
            this.pnlCardVC.Controls.Add(this.picVC);
            this.pnlCardVC.Location = new System.Drawing.Point(25, 135);
            this.pnlCardVC.Name = "pnlCardVC";
            this.pnlCardVC.Size = new System.Drawing.Size(600, 75);
            this.pnlCardVC.TabIndex = 2;
            // 
            // btnInstalarVC
            // 
            this.btnInstalarVC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstalarVC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnInstalarVC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstalarVC.FlatAppearance.BorderSize = 0;
            this.btnInstalarVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstalarVC.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnInstalarVC.ForeColor = System.Drawing.Color.White;
            this.btnInstalarVC.Location = new System.Drawing.Point(500, 24);
            this.btnInstalarVC.Name = "btnInstalarVC";
            this.btnInstalarVC.Size = new System.Drawing.Size(85, 26);
            this.btnInstalarVC.TabIndex = 4;
            this.btnInstalarVC.Text = "Instalar";
            this.btnInstalarVC.UseVisualStyleBackColor = false;
            this.btnInstalarVC.Visible = false;
            this.btnInstalarVC.Click += new System.EventHandler(this.btnInstalarVC_Click);
            // 
            // lblVcDesc
            // 
            this.lblVcDesc.AutoSize = true;
            this.lblVcDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVcDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVcDesc.Location = new System.Drawing.Point(65, 38);
            this.lblVcDesc.Name = "lblVcDesc";
            this.lblVcDesc.Size = new System.Drawing.Size(262, 15);
            this.lblVcDesc.TabIndex = 3;
            this.lblVcDesc.Text = "Requerido para la ejecución del motor biométrico";
            // 
            // lblVcStatus
            // 
            this.lblVcStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVcStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVcStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblVcStatus.Location = new System.Drawing.Point(380, 15);
            this.lblVcStatus.Name = "lblVcStatus";
            this.lblVcStatus.Size = new System.Drawing.Size(110, 45);
            this.lblVcStatus.TabIndex = 2;
            this.lblVcStatus.Text = "✓ Instalado";
            this.lblVcStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVcTitle
            // 
            this.lblVcTitle.AutoSize = true;
            this.lblVcTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVcTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblVcTitle.Location = new System.Drawing.Point(65, 16);
            this.lblVcTitle.Name = "lblVcTitle";
            this.lblVcTitle.Size = new System.Drawing.Size(273, 17);
            this.lblVcTitle.TabIndex = 1;
            this.lblVcTitle.Text = "Visual C++ 2015-2022 Redistributable (x86)";
            // 
            // picVC
            // 
            this.picVC.BackColor = System.Drawing.Color.Transparent;
            this.picVC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.picVC.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.picVC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picVC.IconSize = 38;
            this.picVC.Location = new System.Drawing.Point(15, 18);
            this.picVC.Name = "picVC";
            this.picVC.Size = new System.Drawing.Size(38, 38);
            this.picVC.TabIndex = 0;
            this.picVC.TabStop = false;
            // 
            // pnlCardNet
            // 
            this.pnlCardNet.BackColor = System.Drawing.Color.White;
            this.pnlCardNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardNet.Controls.Add(this.btnInstalarNet);
            this.pnlCardNet.Controls.Add(this.lblNetDesc);
            this.pnlCardNet.Controls.Add(this.lblNetStatus);
            this.pnlCardNet.Controls.Add(this.lblNetTitle);
            this.pnlCardNet.Controls.Add(this.picNet);
            this.pnlCardNet.Location = new System.Drawing.Point(25, 45);
            this.pnlCardNet.Name = "pnlCardNet";
            this.pnlCardNet.Size = new System.Drawing.Size(600, 75);
            this.pnlCardNet.TabIndex = 1;
            // 
            // btnInstalarNet
            // 
            this.btnInstalarNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstalarNet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnInstalarNet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstalarNet.FlatAppearance.BorderSize = 0;
            this.btnInstalarNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstalarNet.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnInstalarNet.ForeColor = System.Drawing.Color.White;
            this.btnInstalarNet.Location = new System.Drawing.Point(500, 24);
            this.btnInstalarNet.Name = "btnInstalarNet";
            this.btnInstalarNet.Size = new System.Drawing.Size(85, 26);
            this.btnInstalarNet.TabIndex = 4;
            this.btnInstalarNet.Text = "Descargar";
            this.btnInstalarNet.UseVisualStyleBackColor = false;
            this.btnInstalarNet.Visible = false;
            this.btnInstalarNet.Click += new System.EventHandler(this.btnInstalarNet_Click);
            // 
            // lblNetDesc
            // 
            this.lblNetDesc.AutoSize = true;
            this.lblNetDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNetDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNetDesc.Location = new System.Drawing.Point(65, 38);
            this.lblNetDesc.Name = "lblNetDesc";
            this.lblNetDesc.Size = new System.Drawing.Size(298, 15);
            this.lblNetDesc.TabIndex = 3;
            this.lblNetDesc.Text = "Entorno de ejecución de la aplicación y servicios .NET";
            // 
            // lblNetStatus
            // 
            this.lblNetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNetStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblNetStatus.Location = new System.Drawing.Point(380, 15);
            this.lblNetStatus.Name = "lblNetStatus";
            this.lblNetStatus.Size = new System.Drawing.Size(110, 45);
            this.lblNetStatus.TabIndex = 2;
            this.lblNetStatus.Text = "✓ Instalado";
            this.lblNetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetTitle
            // 
            this.lblNetTitle.AutoSize = true;
            this.lblNetTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNetTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNetTitle.Location = new System.Drawing.Point(65, 16);
            this.lblNetTitle.Name = "lblNetTitle";
            this.lblNetTitle.Size = new System.Drawing.Size(262, 17);
            this.lblNetTitle.TabIndex = 1;
            this.lblNetTitle.Text = "Microsoft .NET Framework 4.8 o superior";
            // 
            // picNet
            // 
            this.picNet.BackColor = System.Drawing.Color.Transparent;
            this.picNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.picNet.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.picNet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picNet.IconSize = 38;
            this.picNet.Location = new System.Drawing.Point(15, 18);
            this.picNet.Name = "picNet";
            this.picNet.Size = new System.Drawing.Size(38, 38);
            this.picNet.TabIndex = 0;
            this.picNet.TabStop = false;
            // 
            // lblTituloPrerrequisitos
            // 
            this.lblTituloPrerrequisitos.AutoSize = true;
            this.lblTituloPrerrequisitos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrerrequisitos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloPrerrequisitos.Location = new System.Drawing.Point(25, 15);
            this.lblTituloPrerrequisitos.Name = "lblTituloPrerrequisitos";
            this.lblTituloPrerrequisitos.Size = new System.Drawing.Size(277, 20);
            this.lblTituloPrerrequisitos.TabIndex = 0;
            this.lblTituloPrerrequisitos.Text = "Diagnóstico de Componentes del Sistema";
            // 
            // pnlPaso3_Opciones
            // 
            this.pnlPaso3_Opciones.Controls.Add(this.chkServicioWindows);
            this.pnlPaso3_Opciones.Controls.Add(this.chkMenuInicio);
            this.pnlPaso3_Opciones.Controls.Add(this.chkEscritorio);
            this.pnlPaso3_Opciones.Controls.Add(this.lblTituloAccesos);
            this.pnlPaso3_Opciones.Controls.Add(this.btnExaminar);
            this.pnlPaso3_Opciones.Controls.Add(this.txtRutaDestino);
            this.pnlPaso3_Opciones.Controls.Add(this.lblTituloRuta);
            this.pnlPaso3_Opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso3_Opciones.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso3_Opciones.Name = "pnlPaso3_Opciones";
            this.pnlPaso3_Opciones.Padding = new System.Windows.Forms.Padding(30);
            this.pnlPaso3_Opciones.Size = new System.Drawing.Size(650, 350);
            this.pnlPaso3_Opciones.TabIndex = 2;
            // 
            // chkServicioWindows
            // 
            this.chkServicioWindows.AutoSize = true;
            this.chkServicioWindows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkServicioWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(214)))));
            this.chkServicioWindows.Location = new System.Drawing.Point(30, 255);
            this.chkServicioWindows.Name = "chkServicioWindows";
            this.chkServicioWindows.Size = new System.Drawing.Size(475, 19);
            this.chkServicioWindows.TabIndex = 6;
            this.chkServicioWindows.Text = "Instalar y activar el Servicio de Windows 24/7 en segundo plano (Para Servidores)" +
    "";
            this.chkServicioWindows.UseVisualStyleBackColor = true;
            // 
            // chkMenuInicio
            // 
            this.chkMenuInicio.AutoSize = true;
            this.chkMenuInicio.Checked = true;
            this.chkMenuInicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMenuInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMenuInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkMenuInicio.Location = new System.Drawing.Point(30, 215);
            this.chkMenuInicio.Name = "chkMenuInicio";
            this.chkMenuInicio.Size = new System.Drawing.Size(228, 19);
            this.chkMenuInicio.TabIndex = 5;
            this.chkMenuInicio.Text = "Crear acceso directo en el Menú Inicio";
            this.chkMenuInicio.UseVisualStyleBackColor = true;
            // 
            // chkEscritorio
            // 
            this.chkEscritorio.AutoSize = true;
            this.chkEscritorio.Checked = true;
            this.chkEscritorio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEscritorio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkEscritorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkEscritorio.Location = new System.Drawing.Point(30, 185);
            this.chkEscritorio.Name = "chkEscritorio";
            this.chkEscritorio.Size = new System.Drawing.Size(225, 19);
            this.chkEscritorio.TabIndex = 4;
            this.chkEscritorio.Text = "Crear acceso directo en el Escritorio";
            this.chkEscritorio.UseVisualStyleBackColor = true;
            // 
            // lblTituloAccesos
            // 
            this.lblTituloAccesos.AutoSize = true;
            this.lblTituloAccesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloAccesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloAccesos.Location = new System.Drawing.Point(30, 145);
            this.lblTituloAccesos.Name = "lblTituloAccesos";
            this.lblTituloAccesos.Size = new System.Drawing.Size(169, 19);
            this.lblTituloAccesos.TabIndex = 3;
            this.lblTituloAccesos.Text = "Opciones de Instalación:";
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnExaminar.Location = new System.Drawing.Point(510, 68);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(100, 30);
            this.btnExaminar.TabIndex = 2;
            this.btnExaminar.Text = "Examinar...";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRutaDestino
            // 
            this.txtRutaDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRutaDestino.Location = new System.Drawing.Point(30, 71);
            this.txtRutaDestino.Name = "txtRutaDestino";
            this.txtRutaDestino.Size = new System.Drawing.Size(465, 24);
            this.txtRutaDestino.TabIndex = 1;
            this.txtRutaDestino.Text = "C:\\Program Files (x86)\\Hospital El Progreso\\Sistema de Asistencias ZKTeco";
            // 
            // lblTituloRuta
            // 
            this.lblTituloRuta.AutoSize = true;
            this.lblTituloRuta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloRuta.Location = new System.Drawing.Point(30, 35);
            this.lblTituloRuta.Name = "lblTituloRuta";
            this.lblTituloRuta.Size = new System.Drawing.Size(155, 19);
            this.lblTituloRuta.TabIndex = 0;
            this.lblTituloRuta.Text = "Carpeta de Instalación:";
            // 
            // pnlPaso4_Progreso
            // 
            this.pnlPaso4_Progreso.Controls.Add(this.lblDetalleProgreso);
            this.pnlPaso4_Progreso.Controls.Add(this.lblPorcentaje);
            this.pnlPaso4_Progreso.Controls.Add(this.progressBarInstalacion);
            this.pnlPaso4_Progreso.Controls.Add(this.lblTituloProgreso);
            this.pnlPaso4_Progreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso4_Progreso.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso4_Progreso.Name = "pnlPaso4_Progreso";
            this.pnlPaso4_Progreso.Padding = new System.Windows.Forms.Padding(35);
            this.pnlPaso4_Progreso.Size = new System.Drawing.Size(650, 350);
            this.pnlPaso4_Progreso.TabIndex = 3;
            // 
            // lblDetalleProgreso
            // 
            this.lblDetalleProgreso.AutoSize = true;
            this.lblDetalleProgreso.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalleProgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDetalleProgreso.Location = new System.Drawing.Point(35, 185);
            this.lblDetalleProgreso.Name = "lblDetalleProgreso";
            this.lblDetalleProgreso.Size = new System.Drawing.Size(127, 15);
            this.lblDetalleProgreso.TabIndex = 3;
            this.lblDetalleProgreso.Text = "Iniciando instalación...";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.lblPorcentaje.Location = new System.Drawing.Point(505, 90);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(100, 25);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBarInstalacion
            // 
            this.progressBarInstalacion.Location = new System.Drawing.Point(35, 130);
            this.progressBarInstalacion.Name = "progressBarInstalacion";
            this.progressBarInstalacion.Size = new System.Drawing.Size(570, 32);
            this.progressBarInstalacion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarInstalacion.TabIndex = 1;
            // 
            // lblTituloProgreso
            // 
            this.lblTituloProgreso.AutoSize = true;
            this.lblTituloProgreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloProgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloProgreso.Location = new System.Drawing.Point(35, 90);
            this.lblTituloProgreso.Name = "lblTituloProgreso";
            this.lblTituloProgreso.Size = new System.Drawing.Size(287, 21);
            this.lblTituloProgreso.TabIndex = 0;
            this.lblTituloProgreso.Text = "Instalando componentes del sistema...";
            // 
            // pnlPaso5_Finalizado
            // 
            this.pnlPaso5_Finalizado.Controls.Add(this.chkEjecutarApp);
            this.pnlPaso5_Finalizado.Controls.Add(this.lblDescFinal);
            this.pnlPaso5_Finalizado.Controls.Add(this.lblTituloFinal);
            this.pnlPaso5_Finalizado.Controls.Add(this.picFinal);
            this.pnlPaso5_Finalizado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso5_Finalizado.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso5_Finalizado.Name = "pnlPaso5_Finalizado";
            this.pnlPaso5_Finalizado.Padding = new System.Windows.Forms.Padding(30);
            this.pnlPaso5_Finalizado.Size = new System.Drawing.Size(650, 350);
            this.pnlPaso5_Finalizado.TabIndex = 4;
            // 
            // chkEjecutarApp
            // 
            this.chkEjecutarApp.AutoSize = true;
            this.chkEjecutarApp.Checked = true;
            this.chkEjecutarApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEjecutarApp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkEjecutarApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.chkEjecutarApp.Location = new System.Drawing.Point(140, 200);
            this.chkEjecutarApp.Name = "chkEjecutarApp";
            this.chkEjecutarApp.Size = new System.Drawing.Size(358, 23);
            this.chkEjecutarApp.TabIndex = 3;
            this.chkEjecutarApp.Text = "Iniciar el Sistema de Asistencias ZKTeco ahora";
            this.chkEjecutarApp.UseVisualStyleBackColor = true;
            // 
            // lblDescFinal
            // 
            this.lblDescFinal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescFinal.Location = new System.Drawing.Point(140, 85);
            this.lblDescFinal.Name = "lblDescFinal";
            this.lblDescFinal.Size = new System.Drawing.Size(470, 95);
            this.lblDescFinal.TabIndex = 2;
            this.lblDescFinal.Text = "El Sistema de Control de Asistencias ZKTeco se ha instalado exitosamente en este " +
    "equipo.\r\n\r\nSe registraron todas las librerías necesarias y se crearon los acceso" +
    "s directos en su Escritorio y Menú Inicio.";
            // 
            // lblTituloFinal
            // 
            this.lblTituloFinal.AutoSize = true;
            this.lblTituloFinal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTituloFinal.Location = new System.Drawing.Point(140, 40);
            this.lblTituloFinal.Name = "lblTituloFinal";
            this.lblTituloFinal.Size = new System.Drawing.Size(342, 25);
            this.lblTituloFinal.TabIndex = 1;
            this.lblTituloFinal.Text = "¡Instalación Completada con Éxito!";
            // 
            // picFinal
            // 
            this.picFinal.BackColor = System.Drawing.Color.Transparent;
            this.picFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.picFinal.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.picFinal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picFinal.IconSize = 85;
            this.picFinal.Location = new System.Drawing.Point(30, 40);
            this.picFinal.Name = "picFinal";
            this.picFinal.Size = new System.Drawing.Size(85, 85);
            this.picFinal.TabIndex = 0;
            this.picFinal.TabStop = false;
            // 
            // FrmSetupWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 485);
            this.Controls.Add(this.pnlContenedorPasos);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmSetupWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalador - Sistema de Asistencias ZKTeco";
            this.Load += new System.EventHandler(this.FrmSetupWizard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlContenedorPasos.ResumeLayout(false);
            this.pnlPaso1_Bienvenida.ResumeLayout(false);
            this.pnlPaso1_Bienvenida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBienvenida)).EndInit();
            this.pnlPaso2_Prerrequisitos.ResumeLayout(false);
            this.pnlPaso2_Prerrequisitos.PerformLayout();
            this.pnlCardSDK.ResumeLayout(false);
            this.pnlCardSDK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSdk)).EndInit();
            this.pnlCardVC.ResumeLayout(false);
            this.pnlCardVC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVC)).EndInit();
            this.pnlCardNet.ResumeLayout(false);
            this.pnlCardNet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNet)).EndInit();
            this.pnlPaso3_Opciones.ResumeLayout(false);
            this.pnlPaso3_Opciones.PerformLayout();
            this.pnlPaso4_Progreso.ResumeLayout(false);
            this.pnlPaso4_Progreso.PerformLayout();
            this.pnlPaso5_Finalizado.ResumeLayout(false);
            this.pnlPaso5_Finalizado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private FontAwesome.Sharp.IconPictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlContenedorPasos;
        private System.Windows.Forms.Panel pnlPaso1_Bienvenida;
        private FontAwesome.Sharp.IconPictureBox picBienvenida;
        private System.Windows.Forms.Label lblTituloBienvenida;
        private System.Windows.Forms.Label lblDescBienvenida;
        private System.Windows.Forms.Panel pnlPaso2_Prerrequisitos;
        private System.Windows.Forms.Label lblTituloPrerrequisitos;
        private System.Windows.Forms.Panel pnlCardNet;
        private FontAwesome.Sharp.IconPictureBox picNet;
        private System.Windows.Forms.Label lblNetTitle;
        private System.Windows.Forms.Label lblNetDesc;
        private System.Windows.Forms.Label lblNetStatus;
        private System.Windows.Forms.Button btnInstalarNet;
        private System.Windows.Forms.Panel pnlCardVC;
        private System.Windows.Forms.Button btnInstalarVC;
        private System.Windows.Forms.Label lblVcDesc;
        private System.Windows.Forms.Label lblVcStatus;
        private System.Windows.Forms.Label lblVcTitle;
        private FontAwesome.Sharp.IconPictureBox picVC;
        private System.Windows.Forms.Panel pnlCardSDK;
        private System.Windows.Forms.Label lblSdkDesc;
        private System.Windows.Forms.Label lblSdkStatus;
        private System.Windows.Forms.Label lblSdkTitle;
        private FontAwesome.Sharp.IconPictureBox picSdk;
        private System.Windows.Forms.Panel pnlPaso3_Opciones;
        private System.Windows.Forms.Label lblTituloRuta;
        private System.Windows.Forms.TextBox txtRutaDestino;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Label lblTituloAccesos;
        private System.Windows.Forms.CheckBox chkEscritorio;
        private System.Windows.Forms.CheckBox chkMenuInicio;
        private System.Windows.Forms.CheckBox chkServicioWindows;
        private System.Windows.Forms.Panel pnlPaso4_Progreso;
        private System.Windows.Forms.Label lblTituloProgreso;
        private System.Windows.Forms.ProgressBar progressBarInstalacion;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblDetalleProgreso;
        private System.Windows.Forms.Panel pnlPaso5_Finalizado;
        private FontAwesome.Sharp.IconPictureBox picFinal;
        private System.Windows.Forms.Label lblTituloFinal;
        private System.Windows.Forms.Label lblDescFinal;
        private System.Windows.Forms.CheckBox chkEjecutarApp;
    }
}
