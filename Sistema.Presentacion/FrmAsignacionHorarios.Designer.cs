namespace Sistema.Presentacion
{
    partial class FrmAsignacionHorarios
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
            this.tabListadoEmp = new System.Windows.Forms.TabPage();
            this.dgvAsignacionesEmp = new System.Windows.Forms.DataGridView();
            this.pnlBottomEmp = new System.Windows.Forms.Panel();
            this.lblTotalEmp = new System.Windows.Forms.Label();
            this.pnlTopEmp = new System.Windows.Forms.Panel();
            this.btnVistaDept1 = new System.Windows.Forms.Button();
            this.btnExportarEmp = new System.Windows.Forms.Button();
            this.btnQuitarTurnoEmp = new System.Windows.Forms.Button();
            this.btnAsignarEmp = new System.Windows.Forms.Button();
            this.cboFiltroTurno = new System.Windows.Forms.ComboBox();
            this.lblFiltroTurno = new System.Windows.Forms.Label();
            this.cboFiltroDept = new System.Windows.Forms.ComboBox();
            this.lblFiltroDept = new System.Windows.Forms.Label();
            this.btnBuscarEmp = new System.Windows.Forms.Button();
            this.txtBuscarEmp = new System.Windows.Forms.TextBox();
            this.lblBuscarEmp = new System.Windows.Forms.Label();
            this.tabMantEmp = new System.Windows.Forms.TabPage();
            this.pnlMantEmp = new System.Windows.Forms.Panel();
            this.lblInfoSeleccionados = new System.Windows.Forms.Label();
            this.btnCancelarMantEmp = new System.Windows.Forms.Button();
            this.btnQuitarMantEmp = new System.Windows.Forms.Button();
            this.btnGuardarMantEmp = new System.Windows.Forms.Button();
            this.lblHastaMantEmp = new System.Windows.Forms.Label();
            this.dtpHastaMantEmp = new System.Windows.Forms.DateTimePicker();
            this.lblDesdeMantEmp = new System.Windows.Forms.Label();
            this.dtpDesdeMantEmp = new System.Windows.Forms.DateTimePicker();
            this.cboTurnoMantEmp = new System.Windows.Forms.ComboBox();
            this.lblTurnoMantEmp = new System.Windows.Forms.Label();
            this.lblEmpleadoInfo = new System.Windows.Forms.Label();
            this.lblTituloMantEmp = new System.Windows.Forms.Label();
            this.tabListadoDept = new System.Windows.Forms.TabPage();
            this.dgvAsignacionesDept = new System.Windows.Forms.DataGridView();
            this.pnlBottomDept = new System.Windows.Forms.Panel();
            this.lblTotalDept = new System.Windows.Forms.Label();
            this.pnlTopDept = new System.Windows.Forms.Panel();
            this.btnVistaEmp2 = new System.Windows.Forms.Button();
            this.btnExportarDept = new System.Windows.Forms.Button();
            this.btnQuitarTurnoDept = new System.Windows.Forms.Button();
            this.btnAsignarDept = new System.Windows.Forms.Button();
            this.btnBuscarDept = new System.Windows.Forms.Button();
            this.txtBuscarDept = new System.Windows.Forms.TextBox();
            this.lblBuscarDept = new System.Windows.Forms.Label();
            this.tabMantDept = new System.Windows.Forms.TabPage();
            this.pnlMantDept = new System.Windows.Forms.Panel();
            this.chkSincronizarEmp = new System.Windows.Forms.CheckBox();
            this.btnCancelarMantDept = new System.Windows.Forms.Button();
            this.btnQuitarMantDept = new System.Windows.Forms.Button();
            this.btnGuardarMantDept = new System.Windows.Forms.Button();
            this.lblHastaMantDept = new System.Windows.Forms.Label();
            this.dtpHastaMantDept = new System.Windows.Forms.DateTimePicker();
            this.lblDesdeMantDept = new System.Windows.Forms.Label();
            this.dtpDesdeMantDept = new System.Windows.Forms.DateTimePicker();
            this.cboTurnoMantDept = new System.Windows.Forms.ComboBox();
            this.lblTurnoMantDept = new System.Windows.Forms.Label();
            this.lblDeptoInfo = new System.Windows.Forms.Label();
            this.lblTituloMantDept = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabListadoEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesEmp)).BeginInit();
            this.pnlBottomEmp.SuspendLayout();
            this.pnlTopEmp.SuspendLayout();
            this.tabMantEmp.SuspendLayout();
            this.pnlMantEmp.SuspendLayout();
            this.tabListadoDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesDept)).BeginInit();
            this.pnlBottomDept.SuspendLayout();
            this.pnlTopDept.SuspendLayout();
            this.tabMantDept.SuspendLayout();
            this.pnlMantDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPrincipal.Controls.Add(this.tabListadoEmp);
            this.tabPrincipal.Controls.Add(this.tabMantEmp);
            this.tabPrincipal.Controls.Add(this.tabListadoDept);
            this.tabPrincipal.Controls.Add(this.tabMantDept);
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabPrincipal.Location = new System.Drawing.Point(-6, -6);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1012, 692);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabListadoEmp
            // 
            this.tabListadoEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabListadoEmp.Controls.Add(this.dgvAsignacionesEmp);
            this.tabListadoEmp.Controls.Add(this.pnlBottomEmp);
            this.tabListadoEmp.Controls.Add(this.pnlTopEmp);
            this.tabListadoEmp.Location = new System.Drawing.Point(4, 25);
            this.tabListadoEmp.Margin = new System.Windows.Forms.Padding(0);
            this.tabListadoEmp.Name = "tabListadoEmp";
            this.tabListadoEmp.Padding = new System.Windows.Forms.Padding(12);
            this.tabListadoEmp.Size = new System.Drawing.Size(1000, 659);
            this.tabListadoEmp.TabIndex = 0;
            this.tabListadoEmp.Text = "Listado Empleados";
            // 
            // dgvAsignacionesEmp
            // 
            this.dgvAsignacionesEmp.AllowUserToAddRows = false;
            this.dgvAsignacionesEmp.AllowUserToDeleteRows = false;
            this.dgvAsignacionesEmp.AllowUserToOrderColumns = true;
            this.dgvAsignacionesEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsignacionesEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacionesEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignacionesEmp.Location = new System.Drawing.Point(12, 64);
            this.dgvAsignacionesEmp.MultiSelect = false;
            this.dgvAsignacionesEmp.Name = "dgvAsignacionesEmp";
            this.dgvAsignacionesEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacionesEmp.Size = new System.Drawing.Size(976, 553);
            this.dgvAsignacionesEmp.TabIndex = 1;
            this.dgvAsignacionesEmp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacionesEmp_CellDoubleClick);
            // 
            // pnlBottomEmp
            // 
            this.pnlBottomEmp.Controls.Add(this.lblTotalEmp);
            this.pnlBottomEmp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomEmp.Location = new System.Drawing.Point(12, 617);
            this.pnlBottomEmp.Name = "pnlBottomEmp";
            this.pnlBottomEmp.Size = new System.Drawing.Size(976, 30);
            this.pnlBottomEmp.TabIndex = 2;
            // 
            // lblTotalEmp
            // 
            this.lblTotalEmp.AutoSize = true;
            this.lblTotalEmp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalEmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblTotalEmp.Location = new System.Drawing.Point(0, 8);
            this.lblTotalEmp.Name = "lblTotalEmp";
            this.lblTotalEmp.Size = new System.Drawing.Size(120, 15);
            this.lblTotalEmp.TabIndex = 0;
            this.lblTotalEmp.Text = "Total de empleados: 0";
            // 
            // pnlTopEmp
            // 
            this.pnlTopEmp.Controls.Add(this.btnVistaDept1);
            this.pnlTopEmp.Controls.Add(this.btnExportarEmp);
            this.pnlTopEmp.Controls.Add(this.btnQuitarTurnoEmp);
            this.pnlTopEmp.Controls.Add(this.btnAsignarEmp);
            this.pnlTopEmp.Controls.Add(this.cboFiltroTurno);
            this.pnlTopEmp.Controls.Add(this.lblFiltroTurno);
            this.pnlTopEmp.Controls.Add(this.cboFiltroDept);
            this.pnlTopEmp.Controls.Add(this.lblFiltroDept);
            this.pnlTopEmp.Controls.Add(this.btnBuscarEmp);
            this.pnlTopEmp.Controls.Add(this.txtBuscarEmp);
            this.pnlTopEmp.Controls.Add(this.lblBuscarEmp);
            this.pnlTopEmp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopEmp.Location = new System.Drawing.Point(12, 12);
            this.pnlTopEmp.Name = "pnlTopEmp";
            this.pnlTopEmp.Size = new System.Drawing.Size(976, 52);
            this.pnlTopEmp.TabIndex = 0;
            // 
            // lblBuscarEmp
            // 
            this.lblBuscarEmp.AutoSize = true;
            this.lblBuscarEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscarEmp.ForeColor = System.Drawing.Color.White;
            this.lblBuscarEmp.Location = new System.Drawing.Point(0, 16);
            this.lblBuscarEmp.Name = "lblBuscarEmp";
            this.lblBuscarEmp.Size = new System.Drawing.Size(53, 17);
            this.lblBuscarEmp.TabIndex = 0;
            this.lblBuscarEmp.Text = "Buscar:";
            // 
            // txtBuscarEmp
            // 
            this.txtBuscarEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarEmp.Location = new System.Drawing.Point(58, 13);
            this.txtBuscarEmp.Name = "txtBuscarEmp";
            this.txtBuscarEmp.Size = new System.Drawing.Size(130, 24);
            this.txtBuscarEmp.TabIndex = 1;
            this.txtBuscarEmp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarEmp_KeyDown);
            // 
            // btnBuscarEmp
            // 
            this.btnBuscarEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnBuscarEmp.FlatAppearance.BorderSize = 0;
            this.btnBuscarEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscarEmp.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEmp.Location = new System.Drawing.Point(194, 11);
            this.btnBuscarEmp.Name = "btnBuscarEmp";
            this.btnBuscarEmp.Size = new System.Drawing.Size(75, 28);
            this.btnBuscarEmp.TabIndex = 2;
            this.btnBuscarEmp.Text = "🔍 Buscar";
            this.btnBuscarEmp.UseVisualStyleBackColor = false;
            this.btnBuscarEmp.Click += new System.EventHandler(this.btnBuscarEmp_Click);
            // 
            // lblFiltroDept
            // 
            this.lblFiltroDept.AutoSize = true;
            this.lblFiltroDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblFiltroDept.Location = new System.Drawing.Point(272, 16);
            this.lblFiltroDept.Name = "lblFiltroDept";
            this.lblFiltroDept.Size = new System.Drawing.Size(49, 17);
            this.lblFiltroDept.TabIndex = 3;
            this.lblFiltroDept.Text = "Depto:";
            // 
            // cboFiltroDept
            // 
            this.cboFiltroDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroDept.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFiltroDept.FormattingEnabled = true;
            this.cboFiltroDept.Location = new System.Drawing.Point(324, 13);
            this.cboFiltroDept.Name = "cboFiltroDept";
            this.cboFiltroDept.Size = new System.Drawing.Size(130, 24);
            this.cboFiltroDept.TabIndex = 4;
            this.cboFiltroDept.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // lblFiltroTurno
            // 
            this.lblFiltroTurno.AutoSize = true;
            this.lblFiltroTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblFiltroTurno.Location = new System.Drawing.Point(460, 16);
            this.lblFiltroTurno.Name = "lblFiltroTurno";
            this.lblFiltroTurno.Size = new System.Drawing.Size(49, 17);
            this.lblFiltroTurno.TabIndex = 5;
            this.lblFiltroTurno.Text = "Turno:";
            // 
            // cboFiltroTurno
            // 
            this.cboFiltroTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFiltroTurno.FormattingEnabled = true;
            this.cboFiltroTurno.Location = new System.Drawing.Point(512, 13);
            this.cboFiltroTurno.Name = "cboFiltroTurno";
            this.cboFiltroTurno.Size = new System.Drawing.Size(120, 24);
            this.cboFiltroTurno.TabIndex = 6;
            this.cboFiltroTurno.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // btnVistaDept1
            // 
            this.btnVistaDept1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVistaDept1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnVistaDept1.FlatAppearance.BorderSize = 0;
            this.btnVistaDept1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaDept1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVistaDept1.ForeColor = System.Drawing.Color.White;
            this.btnVistaDept1.Location = new System.Drawing.Point(490, 16);
            this.btnVistaDept1.Name = "btnVistaDept1";
            this.btnVistaDept1.Size = new System.Drawing.Size(165, 30);
            this.btnVistaDept1.TabIndex = 7;
            this.btnVistaDept1.Text = "🏢 Por Departamento";
            this.btnVistaDept1.UseVisualStyleBackColor = false;
            this.btnVistaDept1.Click += new System.EventHandler(this.btnSwitchToDept_Click);
            // 
            // btnAsignarEmp
            // 
            this.btnAsignarEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAsignarEmp.FlatAppearance.BorderSize = 0;
            this.btnAsignarEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarEmp.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEmp.Location = new System.Drawing.Point(662, 16);
            this.btnAsignarEmp.Name = "btnAsignarEmp";
            this.btnAsignarEmp.Size = new System.Drawing.Size(115, 30);
            this.btnAsignarEmp.TabIndex = 8;
            this.btnAsignarEmp.Text = "✏️ Asignar Turno";
            this.btnAsignarEmp.UseVisualStyleBackColor = false;
            this.btnAsignarEmp.Click += new System.EventHandler(this.btnAsignarEmp_Click);
            // 
            // btnQuitarTurnoEmp
            // 
            this.btnQuitarTurnoEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarTurnoEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnQuitarTurnoEmp.FlatAppearance.BorderSize = 0;
            this.btnQuitarTurnoEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarTurnoEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarTurnoEmp.ForeColor = System.Drawing.Color.White;
            this.btnQuitarTurnoEmp.Location = new System.Drawing.Point(784, 16);
            this.btnQuitarTurnoEmp.Name = "btnQuitarTurnoEmp";
            this.btnQuitarTurnoEmp.Size = new System.Drawing.Size(100, 30);
            this.btnQuitarTurnoEmp.TabIndex = 9;
            this.btnQuitarTurnoEmp.Text = "❌ Quitar Turno";
            this.btnQuitarTurnoEmp.UseVisualStyleBackColor = false;
            this.btnQuitarTurnoEmp.Click += new System.EventHandler(this.btnQuitarTurnoEmp_Click);
            // 
            // btnExportarEmp
            // 
            this.btnExportarEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnExportarEmp.FlatAppearance.BorderSize = 0;
            this.btnExportarEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarEmp.ForeColor = System.Drawing.Color.White;
            this.btnExportarEmp.Location = new System.Drawing.Point(890, 16);
            this.btnExportarEmp.Name = "btnExportarEmp";
            this.btnExportarEmp.Size = new System.Drawing.Size(86, 30);
            this.btnExportarEmp.TabIndex = 10;
            this.btnExportarEmp.Text = "📊 Exportar";
            this.btnExportarEmp.UseVisualStyleBackColor = false;
            this.btnExportarEmp.Click += new System.EventHandler(this.btnExportarEmp_Click);
            // 
            // tabMantEmp
            // 
            this.tabMantEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabMantEmp.Controls.Add(this.pnlMantEmp);
            this.tabMantEmp.Location = new System.Drawing.Point(4, 25);
            this.tabMantEmp.Margin = new System.Windows.Forms.Padding(0);
            this.tabMantEmp.Name = "tabMantEmp";
            this.tabMantEmp.Padding = new System.Windows.Forms.Padding(12);
            this.tabMantEmp.Size = new System.Drawing.Size(1000, 659);
            this.tabMantEmp.TabIndex = 1;
            this.tabMantEmp.Text = "Mantenimiento Empleados";
            // 
            // pnlMantEmp
            // 
            this.pnlMantEmp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMantEmp.Controls.Add(this.lblInfoSeleccionados);
            this.pnlMantEmp.Controls.Add(this.btnCancelarMantEmp);
            this.pnlMantEmp.Controls.Add(this.btnQuitarMantEmp);
            this.pnlMantEmp.Controls.Add(this.btnGuardarMantEmp);
            this.pnlMantEmp.Controls.Add(this.lblHastaMantEmp);
            this.pnlMantEmp.Controls.Add(this.dtpHastaMantEmp);
            this.pnlMantEmp.Controls.Add(this.lblDesdeMantEmp);
            this.pnlMantEmp.Controls.Add(this.dtpDesdeMantEmp);
            this.pnlMantEmp.Controls.Add(this.cboTurnoMantEmp);
            this.pnlMantEmp.Controls.Add(this.lblTurnoMantEmp);
            this.pnlMantEmp.Controls.Add(this.lblEmpleadoInfo);
            this.pnlMantEmp.Controls.Add(this.lblTituloMantEmp);
            this.pnlMantEmp.Location = new System.Drawing.Point(146, 30);
            this.pnlMantEmp.Name = "pnlMantEmp";
            this.pnlMantEmp.Size = new System.Drawing.Size(700, 480);
            this.pnlMantEmp.TabIndex = 0;
            // 
            // lblInfoSeleccionados
            // 
            this.lblInfoSeleccionados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblInfoSeleccionados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfoSeleccionados.Location = new System.Drawing.Point(50, 115);
            this.lblInfoSeleccionados.Name = "lblInfoSeleccionados";
            this.lblInfoSeleccionados.Size = new System.Drawing.Size(600, 35);
            this.lblInfoSeleccionados.TabIndex = 2;
            this.lblInfoSeleccionados.Text = "Seleccione el turno y el periodo de vigencia aplicable.";
            // 
            // btnCancelarMantEmp
            // 
            this.btnCancelarMantEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelarMantEmp.FlatAppearance.BorderSize = 0;
            this.btnCancelarMantEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarMantEmp.ForeColor = System.Drawing.Color.White;
            this.btnCancelarMantEmp.Location = new System.Drawing.Point(490, 390);
            this.btnCancelarMantEmp.Name = "btnCancelarMantEmp";
            this.btnCancelarMantEmp.Size = new System.Drawing.Size(150, 40);
            this.btnCancelarMantEmp.TabIndex = 11;
            this.btnCancelarMantEmp.Text = "Cancelar";
            this.btnCancelarMantEmp.UseVisualStyleBackColor = false;
            this.btnCancelarMantEmp.Click += new System.EventHandler(this.btnCancelarMantEmp_Click);
            // 
            // btnQuitarMantEmp
            // 
            this.btnQuitarMantEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnQuitarMantEmp.FlatAppearance.BorderSize = 0;
            this.btnQuitarMantEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarMantEmp.ForeColor = System.Drawing.Color.White;
            this.btnQuitarMantEmp.Location = new System.Drawing.Point(290, 390);
            this.btnQuitarMantEmp.Name = "btnQuitarMantEmp";
            this.btnQuitarMantEmp.Size = new System.Drawing.Size(170, 40);
            this.btnQuitarMantEmp.TabIndex = 10;
            this.btnQuitarMantEmp.Text = "❌ Quitar Turno";
            this.btnQuitarMantEmp.UseVisualStyleBackColor = false;
            this.btnQuitarMantEmp.Click += new System.EventHandler(this.btnQuitarMantEmp_Click);
            // 
            // btnGuardarMantEmp
            // 
            this.btnGuardarMantEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardarMantEmp.FlatAppearance.BorderSize = 0;
            this.btnGuardarMantEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMantEmp.ForeColor = System.Drawing.Color.White;
            this.btnGuardarMantEmp.Location = new System.Drawing.Point(50, 390);
            this.btnGuardarMantEmp.Name = "btnGuardarMantEmp";
            this.btnGuardarMantEmp.Size = new System.Drawing.Size(210, 40);
            this.btnGuardarMantEmp.TabIndex = 9;
            this.btnGuardarMantEmp.Text = "✓ Guardar Asignación";
            this.btnGuardarMantEmp.UseVisualStyleBackColor = false;
            this.btnGuardarMantEmp.Click += new System.EventHandler(this.btnGuardarMantEmp_Click);
            // 
            // lblHastaMantEmp
            // 
            this.lblHastaMantEmp.AutoSize = true;
            this.lblHastaMantEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHastaMantEmp.Location = new System.Drawing.Point(380, 270);
            this.lblHastaMantEmp.Name = "lblHastaMantEmp";
            this.lblHastaMantEmp.Size = new System.Drawing.Size(121, 17);
            this.lblHastaMantEmp.TabIndex = 7;
            this.lblHastaMantEmp.Text = "Fecha de Fin (*):";
            // 
            // dtpHastaMantEmp
            // 
            this.dtpHastaMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHastaMantEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaMantEmp.Location = new System.Drawing.Point(380, 295);
            this.dtpHastaMantEmp.Name = "dtpHastaMantEmp";
            this.dtpHastaMantEmp.Size = new System.Drawing.Size(260, 25);
            this.dtpHastaMantEmp.TabIndex = 8;
            // 
            // lblDesdeMantEmp
            // 
            this.lblDesdeMantEmp.AutoSize = true;
            this.lblDesdeMantEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDesdeMantEmp.Location = new System.Drawing.Point(50, 270);
            this.lblDesdeMantEmp.Name = "lblDesdeMantEmp";
            this.lblDesdeMantEmp.Size = new System.Drawing.Size(138, 17);
            this.lblDesdeMantEmp.TabIndex = 5;
            this.lblDesdeMantEmp.Text = "Fecha de Inicio (*):";
            // 
            // dtpDesdeMantEmp
            // 
            this.dtpDesdeMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesdeMantEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeMantEmp.Location = new System.Drawing.Point(50, 295);
            this.dtpDesdeMantEmp.Name = "dtpDesdeMantEmp";
            this.dtpDesdeMantEmp.Size = new System.Drawing.Size(280, 25);
            this.dtpDesdeMantEmp.TabIndex = 6;
            // 
            // cboTurnoMantEmp
            // 
            this.cboTurnoMantEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoMantEmp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTurnoMantEmp.FormattingEnabled = true;
            this.cboTurnoMantEmp.Location = new System.Drawing.Point(50, 205);
            this.cboTurnoMantEmp.Name = "cboTurnoMantEmp";
            this.cboTurnoMantEmp.Size = new System.Drawing.Size(590, 25);
            this.cboTurnoMantEmp.TabIndex = 4;
            // 
            // lblTurnoMantEmp
            // 
            this.lblTurnoMantEmp.AutoSize = true;
            this.lblTurnoMantEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTurnoMantEmp.Location = new System.Drawing.Point(50, 180);
            this.lblTurnoMantEmp.Name = "lblTurnoMantEmp";
            this.lblTurnoMantEmp.Size = new System.Drawing.Size(149, 17);
            this.lblTurnoMantEmp.TabIndex = 3;
            this.lblTurnoMantEmp.Text = "Turno de Destino (*):";
            // 
            // lblEmpleadoInfo
            // 
            this.lblEmpleadoInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmpleadoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblEmpleadoInfo.Location = new System.Drawing.Point(50, 75);
            this.lblEmpleadoInfo.Name = "lblEmpleadoInfo";
            this.lblEmpleadoInfo.Size = new System.Drawing.Size(600, 30);
            this.lblEmpleadoInfo.TabIndex = 1;
            this.lblEmpleadoInfo.Text = "Empleado seleccionado";
            // 
            // lblTituloMantEmp
            // 
            this.lblTituloMantEmp.AutoSize = true;
            this.lblTituloMantEmp.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloMantEmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloMantEmp.Location = new System.Drawing.Point(45, 30);
            this.lblTituloMantEmp.Name = "lblTituloMantEmp";
            this.lblTituloMantEmp.Size = new System.Drawing.Size(325, 25);
            this.lblTituloMantEmp.TabIndex = 0;
            this.lblTituloMantEmp.Text = "Asignación de Turno por Empleado";
            // 
            // tabListadoDept
            // 
            this.tabListadoDept.BackColor = System.Drawing.Color.White;
            this.tabListadoDept.Controls.Add(this.dgvAsignacionesDept);
            this.tabListadoDept.Controls.Add(this.pnlBottomDept);
            // 
            // tabListadoDept
            // 
            this.tabListadoDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabListadoDept.Controls.Add(this.dgvAsignacionesDept);
            this.tabListadoDept.Controls.Add(this.pnlBottomDept);
            this.tabListadoDept.Controls.Add(this.pnlTopDept);
            this.tabListadoDept.Location = new System.Drawing.Point(4, 25);
            this.tabListadoDept.Margin = new System.Windows.Forms.Padding(0);
            this.tabListadoDept.Name = "tabListadoDept";
            this.tabListadoDept.Padding = new System.Windows.Forms.Padding(12);
            this.tabListadoDept.Size = new System.Drawing.Size(1000, 659);
            this.tabListadoDept.TabIndex = 2;
            this.tabListadoDept.Text = "Listado Departamentos";
            // 
            // dgvAsignacionesDept
            // 
            this.dgvAsignacionesDept.AllowUserToAddRows = false;
            this.dgvAsignacionesDept.AllowUserToDeleteRows = false;
            this.dgvAsignacionesDept.AllowUserToOrderColumns = true;
            this.dgvAsignacionesDept.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsignacionesDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacionesDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignacionesDept.Location = new System.Drawing.Point(12, 64);
            this.dgvAsignacionesDept.MultiSelect = false;
            this.dgvAsignacionesDept.Name = "dgvAsignacionesDept";
            this.dgvAsignacionesDept.ReadOnly = true;
            this.dgvAsignacionesDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacionesDept.Size = new System.Drawing.Size(976, 553);
            this.dgvAsignacionesDept.TabIndex = 1;
            this.dgvAsignacionesDept.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacionesDept_CellDoubleClick);
            // 
            // pnlBottomDept
            // 
            this.pnlBottomDept.Controls.Add(this.lblTotalDept);
            this.pnlBottomDept.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomDept.Location = new System.Drawing.Point(12, 617);
            this.pnlBottomDept.Name = "pnlBottomDept";
            this.pnlBottomDept.Size = new System.Drawing.Size(976, 30);
            this.pnlBottomDept.TabIndex = 2;
            // 
            // lblTotalDept
            // 
            this.lblTotalDept.AutoSize = true;
            this.lblTotalDept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblTotalDept.Location = new System.Drawing.Point(0, 8);
            this.lblTotalDept.Name = "lblTotalDept";
            this.lblTotalDept.Size = new System.Drawing.Size(130, 15);
            this.lblTotalDept.TabIndex = 0;
            this.lblTotalDept.Text = "Total departamentos: 0";
            // 
            // pnlTopDept
            // 
            this.pnlTopDept.Controls.Add(this.btnVistaEmp2);
            this.pnlTopDept.Controls.Add(this.btnExportarDept);
            this.pnlTopDept.Controls.Add(this.btnQuitarTurnoDept);
            this.pnlTopDept.Controls.Add(this.btnAsignarDept);
            this.pnlTopDept.Controls.Add(this.btnBuscarDept);
            this.pnlTopDept.Controls.Add(this.txtBuscarDept);
            this.pnlTopDept.Controls.Add(this.lblBuscarDept);
            this.pnlTopDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopDept.Location = new System.Drawing.Point(12, 12);
            this.pnlTopDept.Name = "pnlTopDept";
            this.pnlTopDept.Size = new System.Drawing.Size(976, 52);
            this.pnlTopDept.TabIndex = 0;
            // 
            // lblBuscarDept
            // 
            this.lblBuscarDept.AutoSize = true;
            this.lblBuscarDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscarDept.ForeColor = System.Drawing.Color.White;
            this.lblBuscarDept.Location = new System.Drawing.Point(0, 16);
            this.lblBuscarDept.Name = "lblBuscarDept";
            this.lblBuscarDept.Size = new System.Drawing.Size(53, 17);
            this.lblBuscarDept.TabIndex = 0;
            this.lblBuscarDept.Text = "Buscar:";
            // 
            // txtBuscarDept
            // 
            this.txtBuscarDept.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarDept.Location = new System.Drawing.Point(58, 13);
            this.txtBuscarDept.Name = "txtBuscarDept";
            this.txtBuscarDept.Size = new System.Drawing.Size(220, 24);
            this.txtBuscarDept.TabIndex = 1;
            this.txtBuscarDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDept_KeyDown);
            // 
            // btnBuscarDept
            // 
            this.btnBuscarDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnBuscarDept.FlatAppearance.BorderSize = 0;
            this.btnBuscarDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscarDept.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDept.Location = new System.Drawing.Point(286, 10);
            this.btnBuscarDept.Name = "btnBuscarDept";
            this.btnBuscarDept.Size = new System.Drawing.Size(88, 30);
            this.btnBuscarDept.TabIndex = 2;
            this.btnBuscarDept.Text = "🔍 Buscar";
            this.btnBuscarDept.UseVisualStyleBackColor = false;
            this.btnBuscarDept.Click += new System.EventHandler(this.btnBuscarDept_Click);
            // 
            // btnVistaEmp2
            // 
            this.btnVistaEmp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVistaEmp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.btnVistaEmp2.FlatAppearance.BorderSize = 0;
            this.btnVistaEmp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaEmp2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVistaEmp2.ForeColor = System.Drawing.Color.White;
            this.btnVistaEmp2.Location = new System.Drawing.Point(500, 16);
            this.btnVistaEmp2.Name = "btnVistaEmp2";
            this.btnVistaEmp2.Size = new System.Drawing.Size(155, 30);
            this.btnVistaEmp2.TabIndex = 3;
            this.btnVistaEmp2.Text = "👤 Por Empleados";
            this.btnVistaEmp2.UseVisualStyleBackColor = false;
            this.btnVistaEmp2.Click += new System.EventHandler(this.btnSwitchToEmp_Click);
            // 
            // btnAsignarDept
            // 
            this.btnAsignarDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAsignarDept.FlatAppearance.BorderSize = 0;
            this.btnAsignarDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarDept.ForeColor = System.Drawing.Color.White;
            this.btnAsignarDept.Location = new System.Drawing.Point(662, 16);
            this.btnAsignarDept.Name = "btnAsignarDept";
            this.btnAsignarDept.Size = new System.Drawing.Size(115, 30);
            this.btnAsignarDept.TabIndex = 4;
            this.btnAsignarDept.Text = "✏️ Asignar Turno";
            this.btnAsignarDept.UseVisualStyleBackColor = false;
            this.btnAsignarDept.Click += new System.EventHandler(this.btnAsignarDept_Click);
            // 
            // btnQuitarTurnoDept
            // 
            this.btnQuitarTurnoDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarTurnoDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnQuitarTurnoDept.FlatAppearance.BorderSize = 0;
            this.btnQuitarTurnoDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarTurnoDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarTurnoDept.ForeColor = System.Drawing.Color.White;
            this.btnQuitarTurnoDept.Location = new System.Drawing.Point(784, 16);
            this.btnQuitarTurnoDept.Name = "btnQuitarTurnoDept";
            this.btnQuitarTurnoDept.Size = new System.Drawing.Size(100, 30);
            this.btnQuitarTurnoDept.TabIndex = 5;
            this.btnQuitarTurnoDept.Text = "❌ Quitar Turno";
            this.btnQuitarTurnoDept.UseVisualStyleBackColor = false;
            this.btnQuitarTurnoDept.Click += new System.EventHandler(this.btnQuitarTurnoDept_Click);
            // 
            // btnExportarDept
            // 
            this.btnExportarDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnExportarDept.FlatAppearance.BorderSize = 0;
            this.btnExportarDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarDept.ForeColor = System.Drawing.Color.White;
            this.btnExportarDept.Location = new System.Drawing.Point(890, 16);
            this.btnExportarDept.Name = "btnExportarDept";
            this.btnExportarDept.Size = new System.Drawing.Size(86, 30);
            this.btnExportarDept.TabIndex = 6;
            this.btnExportarDept.Text = "📊 Exportar";
            this.btnExportarDept.UseVisualStyleBackColor = false;
            this.btnExportarDept.Click += new System.EventHandler(this.btnExportarDept_Click);
            // 
            // tabMantDept
            // 
            this.tabMantDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabMantDept.Controls.Add(this.pnlMantDept);
            this.tabMantDept.Location = new System.Drawing.Point(4, 25);
            this.tabMantDept.Margin = new System.Windows.Forms.Padding(0);
            this.tabMantDept.Name = "tabMantDept";
            this.tabMantDept.Padding = new System.Windows.Forms.Padding(12);
            this.tabMantDept.Size = new System.Drawing.Size(1000, 659);
            this.tabMantDept.TabIndex = 3;
            this.tabMantDept.Text = "Mantenimiento Departamentos";
            // 
            // pnlMantDept
            // 
            this.pnlMantDept.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMantDept.Controls.Add(this.chkSincronizarEmp);
            this.pnlMantDept.Controls.Add(this.btnCancelarMantDept);
            this.pnlMantDept.Controls.Add(this.btnQuitarMantDept);
            this.pnlMantDept.Controls.Add(this.btnGuardarMantDept);
            this.pnlMantDept.Controls.Add(this.lblHastaMantDept);
            this.pnlMantDept.Controls.Add(this.dtpHastaMantDept);
            this.pnlMantDept.Controls.Add(this.lblDesdeMantDept);
            this.pnlMantDept.Controls.Add(this.dtpDesdeMantDept);
            this.pnlMantDept.Controls.Add(this.cboTurnoMantDept);
            this.pnlMantDept.Controls.Add(this.lblTurnoMantDept);
            this.pnlMantDept.Controls.Add(this.lblDeptoInfo);
            this.pnlMantDept.Controls.Add(this.lblTituloMantDept);
            this.pnlMantDept.Location = new System.Drawing.Point(146, 30);
            this.pnlMantDept.Name = "pnlMantDept";
            this.pnlMantDept.Size = new System.Drawing.Size(700, 490);
            this.pnlMantDept.TabIndex = 0;
            // 
            // chkSincronizarEmp
            // 
            this.chkSincronizarEmp.AutoSize = true;
            this.chkSincronizarEmp.Checked = true;
            this.chkSincronizarEmp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSincronizarEmp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkSincronizarEmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.chkSincronizarEmp.Location = new System.Drawing.Point(50, 345);
            this.chkSincronizarEmp.Name = "chkSincronizarEmp";
            this.chkSincronizarEmp.Size = new System.Drawing.Size(496, 21);
            this.chkSincronizarEmp.TabIndex = 9;
            this.chkSincronizarEmp.Text = "Aplicar y sincronizar este turno a todos los empleados de este departamento";
            this.chkSincronizarEmp.UseVisualStyleBackColor = true;
            // 
            // btnCancelarMantDept
            // 
            this.btnCancelarMantDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelarMantDept.FlatAppearance.BorderSize = 0;
            this.btnCancelarMantDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarMantDept.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarMantDept.ForeColor = System.Drawing.Color.White;
            this.btnCancelarMantDept.Location = new System.Drawing.Point(490, 400);
            this.btnCancelarMantDept.Name = "btnCancelarMantDept";
            this.btnCancelarMantDept.Size = new System.Drawing.Size(150, 40);
            this.btnCancelarMantDept.TabIndex = 12;
            this.btnCancelarMantDept.Text = "Cancelar";
            this.btnCancelarMantDept.UseVisualStyleBackColor = false;
            this.btnCancelarMantDept.Click += new System.EventHandler(this.btnCancelarMantDept_Click);
            // 
            // btnQuitarMantDept
            // 
            this.btnQuitarMantDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnQuitarMantDept.FlatAppearance.BorderSize = 0;
            this.btnQuitarMantDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarMantDept.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarMantDept.ForeColor = System.Drawing.Color.White;
            this.btnQuitarMantDept.Location = new System.Drawing.Point(290, 400);
            this.btnQuitarMantDept.Name = "btnQuitarMantDept";
            this.btnQuitarMantDept.Size = new System.Drawing.Size(170, 40);
            this.btnQuitarMantDept.TabIndex = 11;
            this.btnQuitarMantDept.Text = "❌ Quitar Turno";
            this.btnQuitarMantDept.UseVisualStyleBackColor = false;
            this.btnQuitarMantDept.Click += new System.EventHandler(this.btnQuitarMantDept_Click);
            // 
            // btnGuardarMantDept
            // 
            this.btnGuardarMantDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardarMantDept.FlatAppearance.BorderSize = 0;
            this.btnGuardarMantDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarMantDept.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMantDept.ForeColor = System.Drawing.Color.White;
            this.btnGuardarMantDept.Location = new System.Drawing.Point(50, 400);
            this.btnGuardarMantDept.Name = "btnGuardarMantDept";
            this.btnGuardarMantDept.Size = new System.Drawing.Size(210, 40);
            this.btnGuardarMantDept.TabIndex = 10;
            this.btnGuardarMantDept.Text = "✓ Guardar Asignación";
            this.btnGuardarMantDept.UseVisualStyleBackColor = false;
            this.btnGuardarMantDept.Click += new System.EventHandler(this.btnGuardarMantDept_Click);
            // 
            // lblHastaMantDept
            // 
            this.lblHastaMantDept.AutoSize = true;
            this.lblHastaMantDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHastaMantDept.Location = new System.Drawing.Point(380, 260);
            this.lblHastaMantDept.Name = "lblHastaMantDept";
            this.lblHastaMantDept.Size = new System.Drawing.Size(121, 17);
            this.lblHastaMantDept.TabIndex = 7;
            this.lblHastaMantDept.Text = "Fecha de Fin (*):";
            // 
            // dtpHastaMantDept
            // 
            this.dtpHastaMantDept.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHastaMantDept.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaMantDept.Location = new System.Drawing.Point(380, 285);
            this.dtpHastaMantDept.Name = "dtpHastaMantDept";
            this.dtpHastaMantDept.Size = new System.Drawing.Size(260, 25);
            this.dtpHastaMantDept.TabIndex = 8;
            // 
            // lblDesdeMantDept
            // 
            this.lblDesdeMantDept.AutoSize = true;
            this.lblDesdeMantDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDesdeMantDept.Location = new System.Drawing.Point(50, 260);
            this.lblDesdeMantDept.Name = "lblDesdeMantDept";
            this.lblDesdeMantDept.Size = new System.Drawing.Size(138, 17);
            this.lblDesdeMantDept.TabIndex = 5;
            this.lblDesdeMantDept.Text = "Fecha de Inicio (*):";
            // 
            // dtpDesdeMantDept
            // 
            this.dtpDesdeMantDept.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesdeMantDept.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeMantDept.Location = new System.Drawing.Point(50, 285);
            this.dtpDesdeMantDept.Name = "dtpDesdeMantDept";
            this.dtpDesdeMantDept.Size = new System.Drawing.Size(280, 25);
            this.dtpDesdeMantDept.TabIndex = 6;
            // 
            // cboTurnoMantDept
            // 
            this.cboTurnoMantDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoMantDept.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTurnoMantDept.FormattingEnabled = true;
            this.cboTurnoMantDept.Location = new System.Drawing.Point(50, 195);
            this.cboTurnoMantDept.Name = "cboTurnoMantDept";
            this.cboTurnoMantDept.Size = new System.Drawing.Size(590, 25);
            this.cboTurnoMantDept.TabIndex = 4;
            // 
            // lblTurnoMantDept
            // 
            this.lblTurnoMantDept.AutoSize = true;
            this.lblTurnoMantDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTurnoMantDept.Location = new System.Drawing.Point(50, 170);
            this.lblTurnoMantDept.Name = "lblTurnoMantDept";
            this.lblTurnoMantDept.Size = new System.Drawing.Size(149, 17);
            this.lblTurnoMantDept.TabIndex = 3;
            this.lblTurnoMantDept.Text = "Turno de Destino (*):";
            // 
            // lblDeptoInfo
            // 
            this.lblDeptoInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDeptoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblDeptoInfo.Location = new System.Drawing.Point(50, 75);
            this.lblDeptoInfo.Name = "lblDeptoInfo";
            this.lblDeptoInfo.Size = new System.Drawing.Size(600, 30);
            this.lblDeptoInfo.TabIndex = 1;
            this.lblDeptoInfo.Text = "Departamento seleccionado";
            // 
            // lblTituloMantDept
            // 
            this.lblTituloMantDept.AutoSize = true;
            this.lblTituloMantDept.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloMantDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloMantDept.Location = new System.Drawing.Point(45, 30);
            this.lblTituloMantDept.Name = "lblTituloMantDept";
            this.lblTituloMantDept.Size = new System.Drawing.Size(359, 25);
            this.lblTituloMantDept.TabIndex = 0;
            this.lblTituloMantDept.Text = "Asignación de Turno por Departamento";
            // 
            // FrmAsignacionHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.Name = "FrmAsignacionHorarios";
            this.Text = "Asignación de Turnos";
            this.Load += new System.EventHandler(this.FrmAsignacionHorarios_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabListadoEmp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesEmp)).EndInit();
            this.pnlBottomEmp.ResumeLayout(false);
            this.pnlBottomEmp.PerformLayout();
            this.pnlTopEmp.ResumeLayout(false);
            this.pnlTopEmp.PerformLayout();
            this.tabMantEmp.ResumeLayout(false);
            this.pnlMantEmp.ResumeLayout(false);
            this.pnlMantEmp.PerformLayout();
            this.tabListadoDept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesDept)).EndInit();
            this.pnlBottomDept.ResumeLayout(false);
            this.pnlBottomDept.PerformLayout();
            this.pnlTopDept.ResumeLayout(false);
            this.pnlTopDept.PerformLayout();
            this.tabMantDept.ResumeLayout(false);
            this.pnlMantDept.ResumeLayout(false);
            this.pnlMantDept.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabListadoEmp;
        private System.Windows.Forms.Panel pnlTopEmp;
        private System.Windows.Forms.Button btnVistaDept1;
        private System.Windows.Forms.Label lblBuscarEmp;
        private System.Windows.Forms.TextBox txtBuscarEmp;
        private System.Windows.Forms.Button btnBuscarEmp;
        private System.Windows.Forms.Label lblFiltroDept;
        private System.Windows.Forms.ComboBox cboFiltroDept;
        private System.Windows.Forms.Label lblFiltroTurno;
        private System.Windows.Forms.ComboBox cboFiltroTurno;
        private System.Windows.Forms.Button btnAsignarEmp;
        private System.Windows.Forms.Button btnQuitarTurnoEmp;
        private System.Windows.Forms.Button btnExportarEmp;
        private System.Windows.Forms.DataGridView dgvAsignacionesEmp;
        private System.Windows.Forms.Panel pnlBottomEmp;
        private System.Windows.Forms.Label lblTotalEmp;
        private System.Windows.Forms.TabPage tabMantEmp;
        private System.Windows.Forms.Panel pnlMantEmp;
        private System.Windows.Forms.Label lblTituloMantEmp;
        private System.Windows.Forms.Label lblEmpleadoInfo;
        private System.Windows.Forms.Label lblInfoSeleccionados;
        private System.Windows.Forms.Label lblTurnoMantEmp;
        private System.Windows.Forms.ComboBox cboTurnoMantEmp;
        private System.Windows.Forms.Label lblDesdeMantEmp;
        private System.Windows.Forms.DateTimePicker dtpDesdeMantEmp;
        private System.Windows.Forms.Label lblHastaMantEmp;
        private System.Windows.Forms.DateTimePicker dtpHastaMantEmp;
        private System.Windows.Forms.Button btnGuardarMantEmp;
        private System.Windows.Forms.Button btnQuitarMantEmp;
        private System.Windows.Forms.Button btnCancelarMantEmp;
        private System.Windows.Forms.TabPage tabListadoDept;
        private System.Windows.Forms.Panel pnlTopDept;
        private System.Windows.Forms.Button btnVistaEmp2;
        private System.Windows.Forms.Label lblBuscarDept;
        private System.Windows.Forms.TextBox txtBuscarDept;
        private System.Windows.Forms.Button btnBuscarDept;
        private System.Windows.Forms.Button btnAsignarDept;
        private System.Windows.Forms.Button btnQuitarTurnoDept;
        private System.Windows.Forms.Button btnExportarDept;
        private System.Windows.Forms.DataGridView dgvAsignacionesDept;
        private System.Windows.Forms.Panel pnlBottomDept;
        private System.Windows.Forms.Label lblTotalDept;
        private System.Windows.Forms.TabPage tabMantDept;
        private System.Windows.Forms.Panel pnlMantDept;
        private System.Windows.Forms.Label lblTituloMantDept;
        private System.Windows.Forms.Label lblDeptoInfo;
        private System.Windows.Forms.Label lblTurnoMantDept;
        private System.Windows.Forms.ComboBox cboTurnoMantDept;
        private System.Windows.Forms.Label lblDesdeMantDept;
        private System.Windows.Forms.DateTimePicker dtpDesdeMantDept;
        private System.Windows.Forms.Label lblHastaMantDept;
        private System.Windows.Forms.DateTimePicker dtpHastaMantDept;
        private System.Windows.Forms.CheckBox chkSincronizarEmp;
        private System.Windows.Forms.Button btnGuardarMantDept;
        private System.Windows.Forms.Button btnQuitarMantDept;
        private System.Windows.Forms.Button btnCancelarMantDept;
    }
}
