namespace Sistema.Presentacion
{
    partial class FrmVacacionesPermisos
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblResumenStats = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.lblDepto = new System.Windows.Forms.Label();
            this.cboFiltroDepto = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.tabPageMantenimiento = new System.Windows.Forms.TabPage();
            this.pnlMant = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblEstadoMant = new System.Windows.Forms.Label();
            this.cboEstadoMant = new System.Windows.Forms.ComboBox();
            this.txtAprobador = new System.Windows.Forms.TextBox();
            this.lblAprobador = new System.Windows.Forms.Label();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboCategoriaMant = new System.Windows.Forms.ComboBox();
            this.lblCategoriaMant = new System.Windows.Forms.Label();
            this.cboEmpleadoMant = new System.Windows.Forms.ComboBox();
            this.lblEmpleadoMant = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblTituloMant = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.tabPageMantenimiento.SuspendLayout();
            this.pnlMant.SuspendLayout();
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
            this.tabPageListado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabPageListado.Controls.Add(this.dgvListado);
            this.tabPageListado.Controls.Add(this.pnlBottom);
            this.tabPageListado.Controls.Add(this.pnlFiltros);
            this.tabPageListado.Location = new System.Drawing.Point(4, 25);
            this.tabPageListado.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageListado.Name = "tabPageListado";
            this.tabPageListado.Padding = new System.Windows.Forms.Padding(12);
            this.tabPageListado.Size = new System.Drawing.Size(1000, 659);
            this.tabPageListado.TabIndex = 0;
            this.tabPageListado.Text = "Listado de Vacaciones y Permisos";
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(10, 115);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(972, 486);
            this.dgvListado.TabIndex = 1;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblResumenStats);
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 601);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(972, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblResumenStats
            // 
            this.lblResumenStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResumenStats.AutoSize = true;
            this.lblResumenStats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblResumenStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblResumenStats.Location = new System.Drawing.Point(10, 12);
            this.lblResumenStats.Name = "lblResumenStats";
            this.lblResumenStats.Size = new System.Drawing.Size(0, 15);
            this.lblResumenStats.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblTotal.Location = new System.Drawing.Point(620, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(340, 20);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total de registros: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.btnEliminar);
            this.pnlFiltros.Controls.Add(this.btnAprobar);
            this.pnlFiltros.Controls.Add(this.btnEditar);
            this.pnlFiltros.Controls.Add(this.btnNuevo);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cboFiltroEstado);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblCategoria);
            this.pnlFiltros.Controls.Add(this.cboFiltroCategoria);
            this.pnlFiltros.Controls.Add(this.lblDepto);
            this.pnlFiltros.Controls.Add(this.cboFiltroDepto);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(10, 10);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(972, 105);
            this.pnlFiltros.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(860, 60);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 32);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "📊 Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(760, 60);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 32);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAprobar.FlatAppearance.BorderSize = 0;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Location = new System.Drawing.Point(650, 60);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(100, 32);
            this.btnAprobar.TabIndex = 15;
            this.btnAprobar.Text = "✓ Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(550, 60);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 32);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(440, 60);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 32);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "+ Nueva";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(340, 60);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 32);
            this.btnFiltrar.TabIndex = 12;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(820, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(46, 15);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // cboFiltroEstado
            // 
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroEstado.FormattingEnabled = true;
            this.cboFiltroEstado.Location = new System.Drawing.Point(820, 28);
            this.cboFiltroEstado.Name = "cboFiltroEstado";
            this.cboFiltroEstado.Size = new System.Drawing.Size(140, 23);
            this.cboFiltroEstado.TabIndex = 11;
            this.cboFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cboFiltros_SelectedIndexChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.White;
            this.lblHasta.Location = new System.Drawing.Point(175, 62);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(41, 15);
            this.lblHasta.TabIndex = 8;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(220, 58);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 23);
            this.dtpHasta.TabIndex = 9;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.White;
            this.lblDesde.Location = new System.Drawing.Point(10, 62);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(44, 15);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 58);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(105, 23);
            this.dtpDesde.TabIndex = 7;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(590, 10);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(95, 15);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Tipo / Categoría:";
            // 
            // cboFiltroCategoria
            // 
            this.cboFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroCategoria.FormattingEnabled = true;
            this.cboFiltroCategoria.Location = new System.Drawing.Point(590, 28);
            this.cboFiltroCategoria.Name = "cboFiltroCategoria";
            this.cboFiltroCategoria.Size = new System.Drawing.Size(220, 23);
            this.cboFiltroCategoria.TabIndex = 5;
            this.cboFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cboFiltros_SelectedIndexChanged);
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDepto.ForeColor = System.Drawing.Color.White;
            this.lblDepto.Location = new System.Drawing.Point(340, 10);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(91, 15);
            this.lblDepto.TabIndex = 2;
            this.lblDepto.Text = "Departamento:";
            // 
            // cboFiltroDepto
            // 
            this.cboFiltroDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroDepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroDepto.FormattingEnabled = true;
            this.cboFiltroDepto.Location = new System.Drawing.Point(340, 28);
            this.cboFiltroDepto.Name = "cboFiltroDepto";
            this.cboFiltroDepto.Size = new System.Drawing.Size(240, 23);
            this.cboFiltroDepto.TabIndex = 3;
            this.cboFiltroDepto.SelectedIndexChanged += new System.EventHandler(this.cboFiltros_SelectedIndexChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(10, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(53, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(10, 28);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(315, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // tabPageMantenimiento
            // 
            this.tabPageMantenimiento.AutoScroll = true;
            this.tabPageMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabPageMantenimiento.Controls.Add(this.pnlMant);
            this.tabPageMantenimiento.Location = new System.Drawing.Point(4, 25);
            this.tabPageMantenimiento.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageMantenimiento.Name = "tabPageMantenimiento";
            this.tabPageMantenimiento.Padding = new System.Windows.Forms.Padding(12);
            this.tabPageMantenimiento.Size = new System.Drawing.Size(1000, 659);
            this.tabPageMantenimiento.TabIndex = 1;
            this.tabPageMantenimiento.Text = "Mantenimiento / Solicitud";
            // 
            // pnlMant
            // 
            this.pnlMant.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMant.Controls.Add(this.btnCancelar);
            this.pnlMant.Controls.Add(this.btnGuardar);
            this.pnlMant.Controls.Add(this.lblEstadoMant);
            this.pnlMant.Controls.Add(this.cboEstadoMant);
            this.pnlMant.Controls.Add(this.txtAprobador);
            this.pnlMant.Controls.Add(this.lblAprobador);
            this.pnlMant.Controls.Add(this.txtResolucion);
            this.pnlMant.Controls.Add(this.lblResolucion);
            this.pnlMant.Controls.Add(this.txtMotivo);
            this.pnlMant.Controls.Add(this.lblMotivo);
            this.pnlMant.Controls.Add(this.lblFechaFin);
            this.pnlMant.Controls.Add(this.dtpFechaFin);
            this.pnlMant.Controls.Add(this.lblFechaInicio);
            this.pnlMant.Controls.Add(this.dtpFechaInicio);
            this.pnlMant.Controls.Add(this.cboCategoriaMant);
            this.pnlMant.Controls.Add(this.lblCategoriaMant);
            this.pnlMant.Controls.Add(this.cboEmpleadoMant);
            this.pnlMant.Controls.Add(this.lblEmpleadoMant);
            this.pnlMant.Controls.Add(this.txtId);
            this.pnlMant.Controls.Add(this.lblTituloMant);
            this.pnlMant.Location = new System.Drawing.Point(145, 20);
            this.pnlMant.Name = "pnlMant";
            this.pnlMant.Size = new System.Drawing.Size(700, 580);
            this.pnlMant.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(490, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 38);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(320, 520);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 38);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblEstadoMant
            // 
            this.lblEstadoMant.AutoSize = true;
            this.lblEstadoMant.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEstadoMant.Location = new System.Drawing.Point(380, 440);
            this.lblEstadoMant.Name = "lblEstadoMant";
            this.lblEstadoMant.Size = new System.Drawing.Size(142, 17);
            this.lblEstadoMant.TabIndex = 16;
            this.lblEstadoMant.Text = "Estado de Aprobación:";
            // 
            // cboEstadoMant
            // 
            this.cboEstadoMant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoMant.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoMant.FormattingEnabled = true;
            this.cboEstadoMant.Location = new System.Drawing.Point(380, 465);
            this.cboEstadoMant.Name = "cboEstadoMant";
            this.cboEstadoMant.Size = new System.Drawing.Size(260, 24);
            this.cboEstadoMant.TabIndex = 17;
            // 
            // txtAprobador
            // 
            this.txtAprobador.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAprobador.Location = new System.Drawing.Point(50, 465);
            this.txtAprobador.Name = "txtAprobador";
            this.txtAprobador.Size = new System.Drawing.Size(280, 24);
            this.txtAprobador.TabIndex = 15;
            this.txtAprobador.Text = "admin";
            // 
            // lblAprobador
            // 
            this.lblAprobador.AutoSize = true;
            this.lblAprobador.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAprobador.Location = new System.Drawing.Point(50, 440);
            this.lblAprobador.Name = "lblAprobador";
            this.lblAprobador.Size = new System.Drawing.Size(139, 17);
            this.lblAprobador.TabIndex = 14;
            this.lblAprobador.Text = "Auditor / Aprobador:";
            // 
            // txtResolucion
            // 
            this.txtResolucion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtResolucion.Location = new System.Drawing.Point(50, 365);
            this.txtResolucion.Multiline = true;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResolucion.Size = new System.Drawing.Size(590, 55);
            this.txtResolucion.TabIndex = 13;
            this.txtResolucion.Text = "Aprobado por RRHH.";
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResolucion.Location = new System.Drawing.Point(50, 340);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(236, 17);
            this.lblResolucion.TabIndex = 12;
            this.lblResolucion.Text = "Notas de Aprobación / Resolución (*):";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMotivo.Location = new System.Drawing.Point(50, 260);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(590, 60);
            this.txtMotivo.TabIndex = 11;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMotivo.Location = new System.Drawing.Point(50, 235);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(217, 17);
            this.lblMotivo.TabIndex = 10;
            this.lblMotivo.Text = "Motivo / Justificación Solicitud (*):";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(380, 165);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(126, 17);
            this.lblFechaFin.TabIndex = 8;
            this.lblFechaFin.Text = "Fecha y Hora Fin (*):";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(380, 190);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(260, 24);
            this.dtpFechaFin.TabIndex = 9;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(50, 165);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(141, 17);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha y Hora Inicio (*):";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(50, 190);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(280, 24);
            this.dtpFechaInicio.TabIndex = 7;
            // 
            // cboCategoriaMant
            // 
            this.cboCategoriaMant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoriaMant.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCategoriaMant.FormattingEnabled = true;
            this.cboCategoriaMant.Location = new System.Drawing.Point(380, 115);
            this.cboCategoriaMant.Name = "cboCategoriaMant";
            this.cboCategoriaMant.Size = new System.Drawing.Size(260, 24);
            this.cboCategoriaMant.TabIndex = 5;
            // 
            // lblCategoriaMant
            // 
            this.lblCategoriaMant.AutoSize = true;
            this.lblCategoriaMant.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoriaMant.Location = new System.Drawing.Point(380, 90);
            this.lblCategoriaMant.Name = "lblCategoriaMant";
            this.lblCategoriaMant.Size = new System.Drawing.Size(193, 17);
            this.lblCategoriaMant.TabIndex = 4;
            this.lblCategoriaMant.Text = "Tipo de Permiso / Vacación (*):";
            // 
            // cboEmpleadoMant
            // 
            this.cboEmpleadoMant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleadoMant.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEmpleadoMant.FormattingEnabled = true;
            this.cboEmpleadoMant.Location = new System.Drawing.Point(50, 115);
            this.cboEmpleadoMant.Name = "cboEmpleadoMant";
            this.cboEmpleadoMant.Size = new System.Drawing.Size(280, 24);
            this.cboEmpleadoMant.TabIndex = 3;
            // 
            // lblEmpleadoMant
            // 
            this.lblEmpleadoMant.AutoSize = true;
            this.lblEmpleadoMant.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpleadoMant.Location = new System.Drawing.Point(50, 90);
            this.lblEmpleadoMant.Name = "lblEmpleadoMant";
            this.lblEmpleadoMant.Size = new System.Drawing.Size(91, 17);
            this.lblEmpleadoMant.TabIndex = 2;
            this.lblEmpleadoMant.Text = "Empleado (*):";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(540, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 24);
            this.txtId.TabIndex = 1;
            this.txtId.Visible = false;
            // 
            // lblTituloMant
            // 
            this.lblTituloMant.AutoSize = true;
            this.lblTituloMant.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloMant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloMant.Location = new System.Drawing.Point(45, 25);
            this.lblTituloMant.Name = "lblTituloMant";
            this.lblTituloMant.Size = new System.Drawing.Size(306, 25);
            this.lblTituloMant.TabIndex = 0;
            this.lblTituloMant.Text = "Registro de Vacaciones o Permisos";
            // 
            // FrmVacacionesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.Name = "FrmVacacionesPermisos";
            this.Text = "Gestión de Vacaciones y Permisos";
            this.Load += new System.EventHandler(this.FrmVacacionesPermisos_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.tabPageMantenimiento.ResumeLayout(false);
            this.pnlMant.ResumeLayout(false);
            this.pnlMant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.ComboBox cboFiltroDepto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboFiltroCategoria;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblResumenStats;
        private System.Windows.Forms.TabPage tabPageMantenimiento;
        private System.Windows.Forms.Panel pnlMant;
        private System.Windows.Forms.Label lblTituloMant;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblEmpleadoMant;
        private System.Windows.Forms.ComboBox cboEmpleadoMant;
        private System.Windows.Forms.Label lblCategoriaMant;
        private System.Windows.Forms.ComboBox cboCategoriaMant;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblAprobador;
        private System.Windows.Forms.TextBox txtAprobador;
        private System.Windows.Forms.Label lblEstadoMant;
        private System.Windows.Forms.ComboBox cboEstadoMant;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
