namespace Sistema.Presentacion
{
    partial class FrmUsuarios
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
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPageListado = new System.Windows.Forms.TabPage();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.tabPageMantenimiento = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.lblNumDoc = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabPageAdminsBio = new System.Windows.Forms.TabPage();
            this.lblBannerAdminsBio = new System.Windows.Forms.Label();
            this.btnRefrescarAdminsBio = new System.Windows.Forms.Button();
            this.btnConsultarRelojDirecto = new System.Windows.Forms.Button();
            this.btnExportarAdminsBio = new System.Windows.Forms.Button();
            this.dgvAdminsBio = new System.Windows.Forms.DataGridView();
            this.btnOtorgarAdminBio = new System.Windows.Forms.Button();
            this.btnRevocarAdminBio = new System.Windows.Forms.Button();
            this.lblTotalAdminsBio = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnIrAdminsBio = new System.Windows.Forms.Button();
            this.btnVolverDeAdminsBio = new System.Windows.Forms.Button();
            this.tabPrincipal.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPageMantenimiento.SuspendLayout();
            this.tabPageAdminsBio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminsBio)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPageListado);
            this.tabPrincipal.Controls.Add(this.tabPageMantenimiento);
            this.tabPrincipal.Controls.Add(this.tabPageAdminsBio);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(950, 630);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabPageListado
            // 
            this.tabPageListado.Controls.Add(this.btnExportar);
            this.tabPageListado.Controls.Add(this.btnIrAdminsBio);
            this.tabPageListado.Controls.Add(this.btnDesactivar);
            this.tabPageListado.Controls.Add(this.btnActivar);
            this.tabPageListado.Controls.Add(this.btnEliminar);
            this.tabPageListado.Controls.Add(this.lblTotal);
            this.tabPageListado.Controls.Add(this.dgvListado);
            this.tabPageListado.Controls.Add(this.btnNuevo);
            this.tabPageListado.Controls.Add(this.btnBuscar);
            this.tabPageListado.Controls.Add(this.txtBuscar);
            this.tabPageListado.Controls.Add(this.lblBuscar);
            this.tabPageListado.Location = new System.Drawing.Point(4, 25);
            this.tabPageListado.Name = "tabPageListado";
            this.tabPageListado.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageListado.Size = new System.Drawing.Size(942, 601);
            this.tabPageListado.TabIndex = 0;
            this.tabPageListado.Text = "Listado de Usuarios";
            // 
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDesactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            this.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(235, 555);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(110, 32);
            this.btnDesactivar.TabIndex = 8;
            this.btnDesactivar.Text = "⛔ Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Location = new System.Drawing.Point(125, 555);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(100, 32);
            this.btnActivar.TabIndex = 7;
            this.btnActivar.Text = "✔️ Activar";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(15, 555);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 32);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblTotal.Location = new System.Drawing.Point(675, 560);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(250, 23);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total de registros: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(15, 60);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(910, 480);
            this.dgvListado.TabIndex = 4;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(370, 14);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 32);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnIrAdminsBio
            // 
            this.btnIrAdminsBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnIrAdminsBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIrAdminsBio.FlatAppearance.BorderSize = 0;
            this.btnIrAdminsBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrAdminsBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIrAdminsBio.ForeColor = System.Drawing.Color.White;
            this.btnIrAdminsBio.Location = new System.Drawing.Point(478, 14);
            this.btnIrAdminsBio.Name = "btnIrAdminsBio";
            this.btnIrAdminsBio.Size = new System.Drawing.Size(185, 32);
            this.btnIrAdminsBio.TabIndex = 9;
            this.btnIrAdminsBio.Text = "👑 Admins Biométricos";
            this.btnIrAdminsBio.UseVisualStyleBackColor = false;
            this.btnIrAdminsBio.Click += new System.EventHandler(this.btnIrAdminsBio_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(670, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 32);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "📊 Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(265, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 32);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(75, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(180, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(15, 22);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(53, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // tabPageMantenimiento
            // 
            this.tabPageMantenimiento.BackColor = System.Drawing.Color.White;
            this.tabPageMantenimiento.Controls.Add(this.btnCancelar);
            this.tabPageMantenimiento.Controls.Add(this.btnGuardar);
            this.tabPageMantenimiento.Controls.Add(this.txtClave);
            this.tabPageMantenimiento.Controls.Add(this.lblClave);
            this.tabPageMantenimiento.Controls.Add(this.txtEmail);
            this.tabPageMantenimiento.Controls.Add(this.lblEmail);
            this.tabPageMantenimiento.Controls.Add(this.txtTelefono);
            this.tabPageMantenimiento.Controls.Add(this.lblTelefono);
            this.tabPageMantenimiento.Controls.Add(this.txtDireccion);
            this.tabPageMantenimiento.Controls.Add(this.lblDireccion);
            this.tabPageMantenimiento.Controls.Add(this.txtNumDocumento);
            this.tabPageMantenimiento.Controls.Add(this.lblNumDoc);
            this.tabPageMantenimiento.Controls.Add(this.cboTipoDocumento);
            this.tabPageMantenimiento.Controls.Add(this.lblTipoDoc);
            this.tabPageMantenimiento.Controls.Add(this.txtNombre);
            this.tabPageMantenimiento.Controls.Add(this.lblNombre);
            this.tabPageMantenimiento.Controls.Add(this.cboRol);
            this.tabPageMantenimiento.Controls.Add(this.lblRol);
            this.tabPageMantenimiento.Controls.Add(this.txtId);
            this.tabPageMantenimiento.Location = new System.Drawing.Point(4, 25);
            this.tabPageMantenimiento.Name = "tabPageMantenimiento";
            this.tabPageMantenimiento.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageMantenimiento.Size = new System.Drawing.Size(942, 601);
            this.tabPageMantenimiento.TabIndex = 1;
            this.tabPageMantenimiento.Text = "Mantenimiento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelar.Location = new System.Drawing.Point(670, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 45);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(490, 350);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(170, 45);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClave.Location = new System.Drawing.Point(490, 205);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(350, 25);
            this.txtClave.TabIndex = 16;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClave.Location = new System.Drawing.Point(487, 182);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(173, 17);
            this.lblClave.TabIndex = 15;
            this.lblClave.Text = "Contraseña de Acceso (*):";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(490, 135);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(350, 25);
            this.txtEmail.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(487, 112);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(142, 17);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Correo Electrónico (*):";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(490, 65);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(350, 25);
            this.txtTelefono.TabIndex = 12;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(487, 42);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 17);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccion.Location = new System.Drawing.Point(50, 275);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(350, 25);
            this.txtDireccion.TabIndex = 10;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.Location = new System.Drawing.Point(47, 252);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(70, 17);
            this.lblDireccion.TabIndex = 9;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumDocumento.Location = new System.Drawing.Point(200, 205);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(200, 25);
            this.txtNumDocumento.TabIndex = 8;
            // 
            // lblNumDoc
            // 
            this.lblNumDoc.AutoSize = true;
            this.lblNumDoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumDoc.Location = new System.Drawing.Point(197, 182);
            this.lblNumDoc.Name = "lblNumDoc";
            this.lblNumDoc.Size = new System.Drawing.Size(103, 17);
            this.lblNumDoc.TabIndex = 7;
            this.lblNumDoc.Text = "N° Documento:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Items.AddRange(new object[] {
            "DNI",
            "RUT",
            "CÉDULA",
            "PASAPORTE"});
            this.cboTipoDocumento.Location = new System.Drawing.Point(50, 205);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(130, 25);
            this.cboTipoDocumento.TabIndex = 6;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTipoDoc.Location = new System.Drawing.Point(47, 182);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(70, 17);
            this.lblTipoDoc.TabIndex = 5;
            this.lblTipoDoc.Text = "Tipo Doc.:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(50, 135);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(350, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(47, 112);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(147, 17);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre Completo (*):";
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(50, 65);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(350, 25);
            this.cboRol.TabIndex = 2;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRol.Location = new System.Drawing.Point(47, 42);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(52, 17);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Rol (*):";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(310, 35);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(90, 24);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // tabPageAdminsBio
            // 
            this.tabPageAdminsBio.BackColor = System.Drawing.Color.White;
            this.tabPageAdminsBio.Controls.Add(this.btnVolverDeAdminsBio);
            this.tabPageAdminsBio.Controls.Add(this.btnExportarAdminsBio);
            this.tabPageAdminsBio.Controls.Add(this.btnRevocarAdminBio);
            this.tabPageAdminsBio.Controls.Add(this.btnOtorgarAdminBio);
            this.tabPageAdminsBio.Controls.Add(this.btnConsultarRelojDirecto);
            this.tabPageAdminsBio.Controls.Add(this.btnRefrescarAdminsBio);
            this.tabPageAdminsBio.Controls.Add(this.lblBannerAdminsBio);
            this.tabPageAdminsBio.Controls.Add(this.lblTotalAdminsBio);
            this.tabPageAdminsBio.Controls.Add(this.dgvAdminsBio);
            this.tabPageAdminsBio.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdminsBio.Name = "tabPageAdminsBio";
            this.tabPageAdminsBio.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageAdminsBio.Size = new System.Drawing.Size(942, 601);
            this.tabPageAdminsBio.TabIndex = 2;
            this.tabPageAdminsBio.Text = "🛡️ Admins de Biométrico";
            // 
            // btnVolverDeAdminsBio
            // 
            this.btnVolverDeAdminsBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnVolverDeAdminsBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverDeAdminsBio.FlatAppearance.BorderSize = 0;
            this.btnVolverDeAdminsBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverDeAdminsBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVolverDeAdminsBio.ForeColor = System.Drawing.Color.White;
            this.btnVolverDeAdminsBio.Location = new System.Drawing.Point(15, 14);
            this.btnVolverDeAdminsBio.Name = "btnVolverDeAdminsBio";
            this.btnVolverDeAdminsBio.Size = new System.Drawing.Size(100, 32);
            this.btnVolverDeAdminsBio.TabIndex = 6;
            this.btnVolverDeAdminsBio.Text = "⬅️ Volver";
            this.btnVolverDeAdminsBio.UseVisualStyleBackColor = false;
            this.btnVolverDeAdminsBio.Click += new System.EventHandler(this.btnVolverDeAdminsBio_Click);
            // 
            // lblBannerAdminsBio
            // 
            this.lblBannerAdminsBio.AutoSize = true;
            this.lblBannerAdminsBio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBannerAdminsBio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.lblBannerAdminsBio.Location = new System.Drawing.Point(125, 19);
            this.lblBannerAdminsBio.Name = "lblBannerAdminsBio";
            this.lblBannerAdminsBio.Size = new System.Drawing.Size(340, 19);
            this.lblBannerAdminsBio.TabIndex = 0;
            this.lblBannerAdminsBio.Text = "👥 Personal Administrador en Relojes Biométricos";
            // 
            // btnRefrescarAdminsBio
            // 
            this.btnRefrescarAdminsBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // btnRefrescarAdminsBio
            // 
            this.btnRefrescarAdminsBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescarAdminsBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRefrescarAdminsBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescarAdminsBio.FlatAppearance.BorderSize = 0;
            this.btnRefrescarAdminsBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarAdminsBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescarAdminsBio.ForeColor = System.Drawing.Color.White;
            this.btnRefrescarAdminsBio.Location = new System.Drawing.Point(515, 14);
            this.btnRefrescarAdminsBio.Name = "btnRefrescarAdminsBio";
            this.btnRefrescarAdminsBio.Size = new System.Drawing.Size(115, 32);
            this.btnRefrescarAdminsBio.TabIndex = 1;
            this.btnRefrescarAdminsBio.Text = "🔄 Refrescar";
            this.btnRefrescarAdminsBio.UseVisualStyleBackColor = false;
            this.btnRefrescarAdminsBio.Click += new System.EventHandler(this.btnRefrescarAdminsBio_Click);
            // 
            // btnConsultarRelojDirecto
            // 
            this.btnConsultarRelojDirecto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarRelojDirecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnConsultarRelojDirecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarRelojDirecto.FlatAppearance.BorderSize = 0;
            this.btnConsultarRelojDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarRelojDirecto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultarRelojDirecto.ForeColor = System.Drawing.Color.White;
            this.btnConsultarRelojDirecto.Location = new System.Drawing.Point(640, 14);
            this.btnConsultarRelojDirecto.Name = "btnConsultarRelojDirecto";
            this.btnConsultarRelojDirecto.Size = new System.Drawing.Size(160, 32);
            this.btnConsultarRelojDirecto.TabIndex = 2;
            this.btnConsultarRelojDirecto.Text = "📡 Leer Reloj Físico";
            this.btnConsultarRelojDirecto.UseVisualStyleBackColor = false;
            this.btnConsultarRelojDirecto.Click += new System.EventHandler(this.btnConsultarRelojDirecto_Click);
            // 
            // btnExportarAdminsBio
            // 
            this.btnExportarAdminsBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAdminsBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExportarAdminsBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarAdminsBio.FlatAppearance.BorderSize = 0;
            this.btnExportarAdminsBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarAdminsBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarAdminsBio.ForeColor = System.Drawing.Color.White;
            this.btnExportarAdminsBio.Location = new System.Drawing.Point(810, 14);
            this.btnExportarAdminsBio.Name = "btnExportarAdminsBio";
            this.btnExportarAdminsBio.Size = new System.Drawing.Size(115, 32);
            this.btnExportarAdminsBio.TabIndex = 3;
            this.btnExportarAdminsBio.Text = "📊 Exportar";
            this.btnExportarAdminsBio.UseVisualStyleBackColor = false;
            this.btnExportarAdminsBio.Click += new System.EventHandler(this.btnExportarAdminsBio_Click);
            // 
            // dgvAdminsBio
            // 
            this.dgvAdminsBio.AllowUserToAddRows = false;
            this.dgvAdminsBio.AllowUserToDeleteRows = false;
            this.dgvAdminsBio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdminsBio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdminsBio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvAdminsBio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdminsBio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminsBio.Location = new System.Drawing.Point(15, 55);
            this.dgvAdminsBio.Name = "dgvAdminsBio";
            this.dgvAdminsBio.ReadOnly = true;
            this.dgvAdminsBio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdminsBio.Size = new System.Drawing.Size(910, 485);
            this.dgvAdminsBio.TabIndex = 4;
            // 
            // btnOtorgarAdminBio
            // 
            this.btnOtorgarAdminBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOtorgarAdminBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnOtorgarAdminBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtorgarAdminBio.FlatAppearance.BorderSize = 0;
            this.btnOtorgarAdminBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtorgarAdminBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOtorgarAdminBio.ForeColor = System.Drawing.Color.White;
            this.btnOtorgarAdminBio.Location = new System.Drawing.Point(15, 555);
            this.btnOtorgarAdminBio.Name = "btnOtorgarAdminBio";
            this.btnOtorgarAdminBio.Size = new System.Drawing.Size(215, 32);
            this.btnOtorgarAdminBio.TabIndex = 5;
            this.btnOtorgarAdminBio.Text = "⭐ Otorgar Rol Administrador";
            this.btnOtorgarAdminBio.UseVisualStyleBackColor = false;
            this.btnOtorgarAdminBio.Click += new System.EventHandler(this.btnOtorgarAdminBio_Click);
            // 
            // btnRevocarAdminBio
            // 
            this.btnRevocarAdminBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRevocarAdminBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRevocarAdminBio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevocarAdminBio.FlatAppearance.BorderSize = 0;
            this.btnRevocarAdminBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevocarAdminBio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevocarAdminBio.ForeColor = System.Drawing.Color.White;
            this.btnRevocarAdminBio.Location = new System.Drawing.Point(240, 555);
            this.btnRevocarAdminBio.Name = "btnRevocarAdminBio";
            this.btnRevocarAdminBio.Size = new System.Drawing.Size(200, 32);
            this.btnRevocarAdminBio.TabIndex = 6;
            this.btnRevocarAdminBio.Text = "🔻 Revocar Acceso Admin";
            this.btnRevocarAdminBio.UseVisualStyleBackColor = false;
            this.btnRevocarAdminBio.Click += new System.EventHandler(this.btnRevocarAdminBio_Click);
            // 
            // lblTotalAdminsBio
            // 
            this.lblTotalAdminsBio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAdminsBio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalAdminsBio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblTotalAdminsBio.Location = new System.Drawing.Point(675, 560);
            this.lblTotalAdminsBio.Name = "lblTotalAdminsBio";
            this.lblTotalAdminsBio.Size = new System.Drawing.Size(250, 23);
            this.lblTotalAdminsBio.TabIndex = 7;
            this.lblTotalAdminsBio.Text = "Total de Administradores: 0";
            this.lblTotalAdminsBio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios del Sistema";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            this.tabPageListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPageMantenimiento.ResumeLayout(false);
            this.tabPageMantenimiento.PerformLayout();
            this.tabPageAdminsBio.ResumeLayout(false);
            this.tabPageAdminsBio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminsBio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.TabPage tabPageMantenimiento;
        private System.Windows.Forms.TabPage tabPageAdminsBio;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblBannerAdminsBio;
        private System.Windows.Forms.Button btnRefrescarAdminsBio;
        private System.Windows.Forms.Button btnConsultarRelojDirecto;
        private System.Windows.Forms.Button btnExportarAdminsBio;
        private System.Windows.Forms.DataGridView dgvAdminsBio;
        private System.Windows.Forms.Button btnOtorgarAdminBio;
        private System.Windows.Forms.Button btnRevocarAdminBio;
        private System.Windows.Forms.Label lblTotalAdminsBio;
        private System.Windows.Forms.Button btnIrAdminsBio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVolverDeAdminsBio;
    }
}
