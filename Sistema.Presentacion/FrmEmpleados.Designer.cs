namespace Sistema.Presentacion
{
    partial class FrmEmpleados
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnSubirBiometrico = new System.Windows.Forms.Button();
            this.btnDescargarBiometrico = new System.Windows.Forms.Button();
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
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.cboPrivilegio = new System.Windows.Forms.ComboBox();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.txtPasswordBio = new System.Windows.Forms.TextBox();
            this.lblPasswordBio = new System.Windows.Forms.Label();
            this.txtTarjetaRFID = new System.Windows.Forms.TextBox();
            this.lblTarjetaRFID = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.lblNumDocumento = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCodigoBiometrico = new System.Windows.Forms.TextBox();
            this.lblCodigoBio = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabPrincipal.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPageMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPageListado);
            this.tabPrincipal.Controls.Add(this.tabPageMantenimiento);
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
            this.tabPageListado.BackColor = System.Drawing.Color.White;
            this.tabPageListado.Controls.Add(this.btnExportar);
            this.tabPageListado.Controls.Add(this.btnSubirBiometrico);
            this.tabPageListado.Controls.Add(this.btnDescargarBiometrico);
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
            this.tabPageListado.Text = "Listado de Empleados";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(415, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 32);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "📊 Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSubirBiometrico
            // 
            this.btnSubirBiometrico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirBiometrico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSubirBiometrico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirBiometrico.FlatAppearance.BorderSize = 0;
            this.btnSubirBiometrico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirBiometrico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubirBiometrico.ForeColor = System.Drawing.Color.White;
            this.btnSubirBiometrico.Location = new System.Drawing.Point(760, 14);
            this.btnSubirBiometrico.Name = "btnSubirBiometrico";
            this.btnSubirBiometrico.Size = new System.Drawing.Size(165, 32);
            this.btnSubirBiometrico.TabIndex = 10;
            this.btnSubirBiometrico.Text = "📤 Subir a Biométricos";
            this.btnSubirBiometrico.UseVisualStyleBackColor = false;
            this.btnSubirBiometrico.Click += new System.EventHandler(this.btnSubirBiometrico_Click);
            // 
            // btnDescargarBiometrico
            // 
            this.btnDescargarBiometrico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarBiometrico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnDescargarBiometrico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarBiometrico.FlatAppearance.BorderSize = 0;
            this.btnDescargarBiometrico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarBiometrico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarBiometrico.ForeColor = System.Drawing.Color.White;
            this.btnDescargarBiometrico.Location = new System.Drawing.Point(575, 14);
            this.btnDescargarBiometrico.Name = "btnDescargarBiometrico";
            this.btnDescargarBiometrico.Size = new System.Drawing.Size(175, 32);
            this.btnDescargarBiometrico.TabIndex = 9;
            this.btnDescargarBiometrico.Text = "📥 Bajar de Biométricos";
            this.btnDescargarBiometrico.UseVisualStyleBackColor = false;
            this.btnDescargarBiometrico.Click += new System.EventHandler(this.btnDescargarBiometrico_Click);
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
            this.tabPageMantenimiento.Controls.Add(this.chkHabilitado);
            this.tabPageMantenimiento.Controls.Add(this.cboPrivilegio);
            this.tabPageMantenimiento.Controls.Add(this.lblPrivilegio);
            this.tabPageMantenimiento.Controls.Add(this.txtPasswordBio);
            this.tabPageMantenimiento.Controls.Add(this.lblPasswordBio);
            this.tabPageMantenimiento.Controls.Add(this.txtTarjetaRFID);
            this.tabPageMantenimiento.Controls.Add(this.lblTarjetaRFID);
            this.tabPageMantenimiento.Controls.Add(this.txtCargo);
            this.tabPageMantenimiento.Controls.Add(this.lblCargo);
            this.tabPageMantenimiento.Controls.Add(this.txtDepartamento);
            this.tabPageMantenimiento.Controls.Add(this.lblDepartamento);
            this.tabPageMantenimiento.Controls.Add(this.txtTelefono);
            this.tabPageMantenimiento.Controls.Add(this.lblTelefono);
            this.tabPageMantenimiento.Controls.Add(this.txtEmail);
            this.tabPageMantenimiento.Controls.Add(this.lblEmail);
            this.tabPageMantenimiento.Controls.Add(this.txtNumDocumento);
            this.tabPageMantenimiento.Controls.Add(this.lblNumDocumento);
            this.tabPageMantenimiento.Controls.Add(this.txtApellido);
            this.tabPageMantenimiento.Controls.Add(this.lblApellido);
            this.tabPageMantenimiento.Controls.Add(this.txtNombre);
            this.tabPageMantenimiento.Controls.Add(this.lblNombre);
            this.tabPageMantenimiento.Controls.Add(this.txtCodigoBiometrico);
            this.tabPageMantenimiento.Controls.Add(this.lblCodigoBio);
            this.tabPageMantenimiento.Controls.Add(this.txtId);
            this.tabPageMantenimiento.Location = new System.Drawing.Point(4, 25);
            this.tabPageMantenimiento.Name = "tabPageMantenimiento";
            this.tabPageMantenimiento.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageMantenimiento.Size = new System.Drawing.Size(942, 601);
            this.tabPageMantenimiento.TabIndex = 1;
            this.tabPageMantenimiento.Text = "Mantenimiento";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Checked = true;
            this.chkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkHabilitado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.chkHabilitado.Location = new System.Drawing.Point(490, 335);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(185, 23);
            this.chkHabilitado.TabIndex = 23;
            this.chkHabilitado.Text = "Habilitado en Biométrico";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // cboPrivilegio
            // 
            this.cboPrivilegio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrivilegio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPrivilegio.FormattingEnabled = true;
            this.cboPrivilegio.Items.AddRange(new object[] {
            "0 - Usuario Normal",
            "3 - Administrador"});
            this.cboPrivilegio.Location = new System.Drawing.Point(490, 275);
            this.cboPrivilegio.Name = "cboPrivilegio";
            this.cboPrivilegio.Size = new System.Drawing.Size(350, 25);
            this.cboPrivilegio.TabIndex = 22;
            // 
            // lblPrivilegio
            // 
            this.lblPrivilegio.AutoSize = true;
            this.lblPrivilegio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrivilegio.Location = new System.Drawing.Point(487, 252);
            this.lblPrivilegio.Name = "lblPrivilegio";
            this.lblPrivilegio.Size = new System.Drawing.Size(147, 17);
            this.lblPrivilegio.TabIndex = 21;
            this.lblPrivilegio.Text = "Privilegio en Biométrico:";
            // 
            // txtPasswordBio
            // 
            this.txtPasswordBio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordBio.Location = new System.Drawing.Point(490, 205);
            this.txtPasswordBio.Name = "txtPasswordBio";
            this.txtPasswordBio.Size = new System.Drawing.Size(350, 25);
            this.txtPasswordBio.TabIndex = 20;
            // 
            // lblPasswordBio
            // 
            this.lblPasswordBio.AutoSize = true;
            this.lblPasswordBio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPasswordBio.Location = new System.Drawing.Point(487, 182);
            this.lblPasswordBio.Name = "lblPasswordBio";
            this.lblPasswordBio.Size = new System.Drawing.Size(183, 17);
            this.lblPasswordBio.TabIndex = 19;
            this.lblPasswordBio.Text = "Contraseña Biométrico (PIN):";
            // 
            // txtTarjetaRFID
            // 
            this.txtTarjetaRFID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTarjetaRFID.Location = new System.Drawing.Point(490, 135);
            this.txtTarjetaRFID.Name = "txtTarjetaRFID";
            this.txtTarjetaRFID.Size = new System.Drawing.Size(350, 25);
            this.txtTarjetaRFID.TabIndex = 18;
            // 
            // lblTarjetaRFID
            // 
            this.lblTarjetaRFID.AutoSize = true;
            this.lblTarjetaRFID.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTarjetaRFID.Location = new System.Drawing.Point(487, 112);
            this.lblTarjetaRFID.Name = "lblTarjetaRFID";
            this.lblTarjetaRFID.Size = new System.Drawing.Size(155, 17);
            this.lblTarjetaRFID.TabIndex = 17;
            this.lblTarjetaRFID.Text = "N° Tarjeta RFID / Proxim:";
            // 
            // txtCargo
            // 
            this.txtCargo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCargo.Location = new System.Drawing.Point(490, 65);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(350, 25);
            this.txtCargo.TabIndex = 16;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCargo.Location = new System.Drawing.Point(487, 42);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(48, 17);
            this.lblCargo.TabIndex = 15;
            this.lblCargo.Text = "Cargo:";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartamento.Location = new System.Drawing.Point(50, 465);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(350, 25);
            this.txtDepartamento.TabIndex = 14;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDepartamento.Location = new System.Drawing.Point(47, 442);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(100, 17);
            this.lblDepartamento.TabIndex = 13;
            this.lblDepartamento.Text = "Departamento:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(50, 395);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(350, 25);
            this.txtTelefono.TabIndex = 12;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(47, 372);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 17);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(50, 325);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(350, 25);
            this.txtEmail.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(47, 302);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumDocumento.Location = new System.Drawing.Point(50, 255);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(350, 25);
            this.txtNumDocumento.TabIndex = 8;
            // 
            // lblNumDocumento
            // 
            this.lblNumDocumento.AutoSize = true;
            this.lblNumDocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumDocumento.Location = new System.Drawing.Point(47, 232);
            this.lblNumDocumento.Name = "lblNumDocumento";
            this.lblNumDocumento.Size = new System.Drawing.Size(133, 17);
            this.lblNumDocumento.TabIndex = 7;
            this.lblNumDocumento.Text = "N° Documento / DNI:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(50, 185);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(350, 25);
            this.txtApellido.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApellido.Location = new System.Drawing.Point(47, 162);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(70, 17);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(50, 115);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(350, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(47, 92);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(76, 17);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre (*):";
            // 
            // txtCodigoBiometrico
            // 
            this.txtCodigoBiometrico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigoBiometrico.Location = new System.Drawing.Point(50, 45);
            this.txtCodigoBiometrico.Name = "txtCodigoBiometrico";
            this.txtCodigoBiometrico.Size = new System.Drawing.Size(200, 25);
            this.txtCodigoBiometrico.TabIndex = 2;
            // 
            // lblCodigoBio
            // 
            this.lblCodigoBio.AutoSize = true;
            this.lblCodigoBio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCodigoBio.Location = new System.Drawing.Point(47, 22);
            this.lblCodigoBio.Name = "lblCodigoBio";
            this.lblCodigoBio.Size = new System.Drawing.Size(248, 17);
            this.lblCodigoBio.TabIndex = 1;
            this.lblCodigoBio.Text = "Código Biométrico (Enroll Number) (*):";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(310, 45);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(90, 24);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelar.Location = new System.Drawing.Point(670, 445);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 45);
            this.btnCancelar.TabIndex = 25;
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
            this.btnGuardar.Location = new System.Drawing.Point(490, 445);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(170, 45);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmpleados";
            this.Text = "Gestión de Empleados";
            this.Load += new System.EventHandler(this.FrmEmpleados_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            this.tabPageListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPageMantenimiento.ResumeLayout(false);
            this.tabPageMantenimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.TabPage tabPageMantenimiento;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDescargarBiometrico;
        private System.Windows.Forms.Button btnSubirBiometrico;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtCodigoBiometrico;
        private System.Windows.Forms.Label lblCodigoBio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.Label lblNumDocumento;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtTarjetaRFID;
        private System.Windows.Forms.Label lblTarjetaRFID;
        private System.Windows.Forms.TextBox txtPasswordBio;
        private System.Windows.Forms.Label lblPasswordBio;
        private System.Windows.Forms.ComboBox cboPrivilegio;
        private System.Windows.Forms.Label lblPrivilegio;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
