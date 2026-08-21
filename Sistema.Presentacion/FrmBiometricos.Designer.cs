namespace Sistema.Presentacion
{
    partial class FrmBiometricos
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnSubirTodosEmpleados = new System.Windows.Forms.Button();
            this.btnDescargarMarcaciones = new System.Windows.Forms.Button();
            this.btnDescargarUsuarios = new System.Windows.Forms.Button();
            this.btnSyncHora = new System.Windows.Forms.Button();
            this.btnProbarConexion = new System.Windows.Forms.Button();
            this.lblAcciones = new System.Windows.Forms.Label();
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
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.lblNumeroSerie = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtCommKey = new System.Windows.Forms.TextBox();
            this.lblCommKey = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.txtDireccionIP = new System.Windows.Forms.TextBox();
            this.lblDireccionIP = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabPrincipal.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPageMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPrincipal.Controls.Add(this.tabPageListado);
            this.tabPrincipal.Controls.Add(this.tabPageMantenimiento);
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabPrincipal.Location = new System.Drawing.Point(-6, -6);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1012, 692);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabPageListado
            // 
            // tabPageListado
            // 
            this.tabPageListado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabPageListado.Controls.Add(this.dgvListado);
            this.tabPageListado.Controls.Add(this.pnlAcciones);
            this.tabPageListado.Controls.Add(this.pnlTop);
            this.tabPageListado.Location = new System.Drawing.Point(4, 25);
            this.tabPageListado.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageListado.Name = "tabPageListado";
            this.tabPageListado.Padding = new System.Windows.Forms.Padding(12);
            this.tabPageListado.Size = new System.Drawing.Size(1000, 659);
            this.tabPageListado.TabIndex = 0;
            this.tabPageListado.Text = "Dispositivos Biométricos";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBuscar);
            this.pnlTop.Controls.Add(this.txtBuscar);
            this.pnlTop.Controls.Add(this.btnBuscar);
            this.pnlTop.Controls.Add(this.btnNuevo);
            this.pnlTop.Controls.Add(this.btnEliminar);
            this.pnlTop.Controls.Add(this.lblTotal);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(976, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(0, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(53, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(58, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(286, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(530, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(640, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblTotal.Location = new System.Drawing.Point(750, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(220, 23);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total de registros: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(12, 110);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(976, 537);
            this.dgvListado.TabIndex = 1;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.Transparent;
            this.pnlAcciones.Controls.Add(this.btnDescargarMarcaciones);
            this.pnlAcciones.Controls.Add(this.btnProbarConexion);
            this.pnlAcciones.Controls.Add(this.btnSyncHora);
            this.pnlAcciones.Controls.Add(this.btnDescargarUsuarios);
            this.pnlAcciones.Controls.Add(this.btnSubirTodosEmpleados);
            this.pnlAcciones.Controls.Add(this.btnReiniciar);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcciones.Location = new System.Drawing.Point(12, 62);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(976, 46);
            this.pnlAcciones.TabIndex = 2;
            // 
            // btnDescargarMarcaciones
            // 
            this.btnDescargarMarcaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDescargarMarcaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarMarcaciones.FlatAppearance.BorderSize = 0;
            this.btnDescargarMarcaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarMarcaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarMarcaciones.ForeColor = System.Drawing.Color.White;
            this.btnDescargarMarcaciones.Location = new System.Drawing.Point(0, 6);
            this.btnDescargarMarcaciones.Name = "btnDescargarMarcaciones";
            this.btnDescargarMarcaciones.Size = new System.Drawing.Size(230, 32);
            this.btnDescargarMarcaciones.TabIndex = 0;
            this.btnDescargarMarcaciones.Text = "📥 Sincronizar Marcaciones (Todos)";
            this.btnDescargarMarcaciones.UseVisualStyleBackColor = false;
            this.btnDescargarMarcaciones.Click += new System.EventHandler(this.btnDescargarMarcaciones_Click);
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnProbarConexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProbarConexion.FlatAppearance.BorderSize = 0;
            this.btnProbarConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarConexion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProbarConexion.ForeColor = System.Drawing.Color.White;
            this.btnProbarConexion.Location = new System.Drawing.Point(238, 6);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.Size = new System.Drawing.Size(130, 32);
            this.btnProbarConexion.TabIndex = 1;
            this.btnProbarConexion.Text = "⚡ Probar Conexión";
            this.btnProbarConexion.UseVisualStyleBackColor = false;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // btnSyncHora
            // 
            this.btnSyncHora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnSyncHora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyncHora.FlatAppearance.BorderSize = 0;
            this.btnSyncHora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncHora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSyncHora.ForeColor = System.Drawing.Color.White;
            this.btnSyncHora.Location = new System.Drawing.Point(376, 6);
            this.btnSyncHora.Name = "btnSyncHora";
            this.btnSyncHora.Size = new System.Drawing.Size(135, 32);
            this.btnSyncHora.TabIndex = 2;
            this.btnSyncHora.Text = "⏰ Sincronizar Hora";
            this.btnSyncHora.UseVisualStyleBackColor = false;
            this.btnSyncHora.Click += new System.EventHandler(this.btnSyncHora_Click);
            // 
            // btnDescargarUsuarios
            // 
            this.btnDescargarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.btnDescargarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnDescargarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnDescargarUsuarios.Location = new System.Drawing.Point(519, 6);
            this.btnDescargarUsuarios.Name = "btnDescargarUsuarios";
            this.btnDescargarUsuarios.Size = new System.Drawing.Size(145, 32);
            this.btnDescargarUsuarios.TabIndex = 3;
            this.btnDescargarUsuarios.Text = "📥 Descargar Usuarios";
            this.btnDescargarUsuarios.UseVisualStyleBackColor = false;
            this.btnDescargarUsuarios.Click += new System.EventHandler(this.btnDescargarUsuarios_Click);
            // 
            // btnSubirTodosEmpleados
            // 
            this.btnSubirTodosEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnSubirTodosEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirTodosEmpleados.FlatAppearance.BorderSize = 0;
            this.btnSubirTodosEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirTodosEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubirTodosEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnSubirTodosEmpleados.Location = new System.Drawing.Point(672, 6);
            this.btnSubirTodosEmpleados.Name = "btnSubirTodosEmpleados";
            this.btnSubirTodosEmpleados.Size = new System.Drawing.Size(140, 32);
            this.btnSubirTodosEmpleados.TabIndex = 4;
            this.btnSubirTodosEmpleados.Text = "📤 Subir Empleados";
            this.btnSubirTodosEmpleados.UseVisualStyleBackColor = false;
            this.btnSubirTodosEmpleados.Click += new System.EventHandler(this.btnSubirTodosEmpleados_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnReiniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Location = new System.Drawing.Point(820, 6);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(135, 32);
            this.btnReiniciar.TabIndex = 5;
            this.btnReiniciar.Text = "🔄 Reiniciar Reloj";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // tabPageMantenimiento
            // 
            this.tabPageMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabPageMantenimiento.Controls.Add(this.btnCancelar);
            this.tabPageMantenimiento.Controls.Add(this.btnGuardar);
            this.tabPageMantenimiento.Controls.Add(this.chkActivo);
            this.tabPageMantenimiento.Controls.Add(this.txtNumeroSerie);
            this.tabPageMantenimiento.Controls.Add(this.lblNumeroSerie);
            this.tabPageMantenimiento.Controls.Add(this.txtModelo);
            this.tabPageMantenimiento.Controls.Add(this.lblModelo);
            this.tabPageMantenimiento.Controls.Add(this.txtUbicacion);
            this.tabPageMantenimiento.Controls.Add(this.lblUbicacion);
            this.tabPageMantenimiento.Controls.Add(this.txtCommKey);
            this.tabPageMantenimiento.Controls.Add(this.lblCommKey);
            this.tabPageMantenimiento.Controls.Add(this.txtPuerto);
            this.tabPageMantenimiento.Controls.Add(this.lblPuerto);
            this.tabPageMantenimiento.Controls.Add(this.txtDireccionIP);
            this.tabPageMantenimiento.Controls.Add(this.lblDireccionIP);
            this.tabPageMantenimiento.Controls.Add(this.txtNombre);
            this.tabPageMantenimiento.Controls.Add(this.lblNombre);
            this.tabPageMantenimiento.Controls.Add(this.txtId);
            this.tabPageMantenimiento.Location = new System.Drawing.Point(4, 25);
            this.tabPageMantenimiento.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageMantenimiento.Name = "tabPageMantenimiento";
            this.tabPageMantenimiento.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageMantenimiento.Size = new System.Drawing.Size(1000, 659);
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
            this.btnCancelar.TabIndex = 17;
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
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.chkActivo.Location = new System.Drawing.Point(490, 275);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(157, 23);
            this.chkActivo.TabIndex = 15;
            this.chkActivo.Text = "Dispositivo Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumeroSerie.Location = new System.Drawing.Point(490, 205);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(350, 25);
            this.txtNumeroSerie.TabIndex = 14;
            // 
            // lblNumeroSerie
            // 
            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumeroSerie.Location = new System.Drawing.Point(487, 182);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.Size = new System.Drawing.Size(117, 17);
            this.lblNumeroSerie.TabIndex = 13;
            this.lblNumeroSerie.Text = "Número de Serie:";
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModelo.Location = new System.Drawing.Point(490, 135);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(350, 25);
            this.txtModelo.TabIndex = 12;
            this.txtModelo.Text = "ZKTeco MB20 / K40";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblModelo.Location = new System.Drawing.Point(487, 112);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(59, 17);
            this.lblModelo.TabIndex = 11;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUbicacion.Location = new System.Drawing.Point(490, 65);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(350, 25);
            this.txtUbicacion.TabIndex = 10;
            this.txtUbicacion.Text = "Recepción / Puerta Principal";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUbicacion.Location = new System.Drawing.Point(487, 42);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(73, 17);
            this.lblUbicacion.TabIndex = 9;
            this.lblUbicacion.Text = "Ubicación:";
            // 
            // txtCommKey
            // 
            this.txtCommKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCommKey.Location = new System.Drawing.Point(50, 275);
            this.txtCommKey.Name = "txtCommKey";
            this.txtCommKey.Size = new System.Drawing.Size(350, 25);
            this.txtCommKey.TabIndex = 8;
            this.txtCommKey.Text = "0";
            // 
            // lblCommKey
            // 
            this.lblCommKey.AutoSize = true;
            this.lblCommKey.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCommKey.Location = new System.Drawing.Point(47, 252);
            this.lblCommKey.Name = "lblCommKey";
            this.lblCommKey.Size = new System.Drawing.Size(251, 17);
            this.lblCommKey.TabIndex = 7;
            this.lblCommKey.Text = "Clave de Comunicación (CommKey):";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPuerto.Location = new System.Drawing.Point(50, 205);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(350, 25);
            this.txtPuerto.TabIndex = 6;
            this.txtPuerto.Text = "4370";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPuerto.Location = new System.Drawing.Point(47, 182);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(161, 17);
            this.lblPuerto.TabIndex = 5;
            this.lblPuerto.Text = "Puerto TCP (Defecto: 4370):";
            // 
            // txtDireccionIP
            // 
            this.txtDireccionIP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccionIP.Location = new System.Drawing.Point(50, 135);
            this.txtDireccionIP.Name = "txtDireccionIP";
            this.txtDireccionIP.Size = new System.Drawing.Size(350, 25);
            this.txtDireccionIP.TabIndex = 4;
            this.txtDireccionIP.Text = "192.168.1.201";
            // 
            // lblDireccionIP
            // 
            this.lblDireccionIP.AutoSize = true;
            this.lblDireccionIP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDireccionIP.Location = new System.Drawing.Point(47, 112);
            this.lblDireccionIP.Name = "lblDireccionIP";
            this.lblDireccionIP.Size = new System.Drawing.Size(149, 17);
            this.lblDireccionIP.TabIndex = 3;
            this.lblDireccionIP.Text = "Dirección IP (Red) (*):";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(50, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(350, 25);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Text = "Biométrico Entrada";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(47, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(161, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Identificador (*):";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(230, 40);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(90, 24);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // FrmBiometricos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBiometricos";
            this.Text = "Gestión de Biométricos ZKTeco";
            this.Load += new System.EventHandler(this.FrmBiometricos_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            this.tabPageListado.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPageMantenimiento.ResumeLayout(false);
            this.tabPageMantenimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.TabPage tabPageMantenimiento;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblAcciones;
        private System.Windows.Forms.Button btnProbarConexion;
        private System.Windows.Forms.Button btnSyncHora;
        private System.Windows.Forms.Button btnDescargarUsuarios;
        private System.Windows.Forms.Button btnDescargarMarcaciones;
        private System.Windows.Forms.Button btnSubirTodosEmpleados;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDireccionIP;
        private System.Windows.Forms.Label lblDireccionIP;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox txtCommKey;
        private System.Windows.Forms.Label lblCommKey;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label lblNumeroSerie;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
