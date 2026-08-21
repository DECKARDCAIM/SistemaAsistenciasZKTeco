namespace Sistema.Presentacion
{
    partial class FrmDepartamentos
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
            this.pnlTopListado = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.pnlBottomListado = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tabPageMantenimiento = new System.Windows.Forms.TabPage();
            this.pnlMantenimiento = new System.Windows.Forms.Panel();
            this.lblTituloMant = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDeptoPadre = new System.Windows.Forms.Label();
            this.cboDeptoPadre = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabPrincipal.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            this.pnlTopListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.pnlBottomListado.SuspendLayout();
            this.tabPageMantenimiento.SuspendLayout();
            this.pnlMantenimiento.SuspendLayout();
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
            this.tabPageListado.Controls.Add(this.pnlBottomListado);
            this.tabPageListado.Controls.Add(this.pnlTopListado);
            this.tabPageListado.Location = new System.Drawing.Point(4, 25);
            this.tabPageListado.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageListado.Name = "tabPageListado";
            this.tabPageListado.Padding = new System.Windows.Forms.Padding(12);
            this.tabPageListado.Size = new System.Drawing.Size(1000, 659);
            this.tabPageListado.TabIndex = 0;
            this.tabPageListado.Text = "Listado de Departamentos";
            // 
            // pnlTopListado
            // 
            this.pnlTopListado.Controls.Add(this.btnExportar);
            this.pnlTopListado.Controls.Add(this.btnEliminar);
            this.pnlTopListado.Controls.Add(this.btnEditar);
            this.pnlTopListado.Controls.Add(this.btnNuevo);
            this.pnlTopListado.Controls.Add(this.btnBuscar);
            this.pnlTopListado.Controls.Add(this.txtBuscar);
            this.pnlTopListado.Controls.Add(this.lblBuscar);
            this.pnlTopListado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopListado.Location = new System.Drawing.Point(15, 15);
            this.pnlTopListado.Name = "pnlTopListado";
            this.pnlTopListado.Size = new System.Drawing.Size(922, 55);
            this.pnlTopListado.TabIndex = 0;
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
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
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
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(510, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(95, 30);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(612, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(95, 30);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(714, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 30);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(816, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(105, 30);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "📊 Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(15, 70);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(922, 491);
            this.dgvListado.TabIndex = 1;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // pnlBottomListado
            // 
            this.pnlBottomListado.Controls.Add(this.lblTotal);
            this.pnlBottomListado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomListado.Location = new System.Drawing.Point(15, 561);
            this.pnlBottomListado.Name = "pnlBottomListado";
            this.pnlBottomListado.Size = new System.Drawing.Size(922, 35);
            this.pnlBottomListado.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTotal.Location = new System.Drawing.Point(0, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(107, 15);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // tabPageMantenimiento
            // 
            this.tabPageMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(38)))));
            this.tabPageMantenimiento.Controls.Add(this.pnlMantenimiento);
            this.tabPageMantenimiento.Location = new System.Drawing.Point(4, 25);
            this.tabPageMantenimiento.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageMantenimiento.Name = "tabPageMantenimiento";
            this.tabPageMantenimiento.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageMantenimiento.Size = new System.Drawing.Size(1000, 659);
            this.tabPageMantenimiento.TabIndex = 1;
            this.tabPageMantenimiento.Text = "Mantenimiento";
            // 
            // pnlMantenimiento
            // 
            this.pnlMantenimiento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMantenimiento.Controls.Add(this.btnCancelar);
            this.pnlMantenimiento.Controls.Add(this.btnGuardar);
            this.pnlMantenimiento.Controls.Add(this.cboDeptoPadre);
            this.pnlMantenimiento.Controls.Add(this.lblDeptoPadre);
            this.pnlMantenimiento.Controls.Add(this.txtNombre);
            this.pnlMantenimiento.Controls.Add(this.lblNombre);
            this.pnlMantenimiento.Controls.Add(this.txtCodigo);
            this.pnlMantenimiento.Controls.Add(this.lblCodigo);
            this.pnlMantenimiento.Controls.Add(this.txtId);
            this.pnlMantenimiento.Controls.Add(this.lblTituloMant);
            this.pnlMantenimiento.Location = new System.Drawing.Point(180, 40);
            this.pnlMantenimiento.Name = "pnlMantenimiento";
            this.pnlMantenimiento.Size = new System.Drawing.Size(580, 420);
            this.pnlMantenimiento.TabIndex = 0;
            // 
            // lblTituloMant
            // 
            this.lblTituloMant.AutoSize = true;
            this.lblTituloMant.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloMant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloMant.Location = new System.Drawing.Point(30, 20);
            this.lblTituloMant.Name = "lblTituloMant";
            this.lblTituloMant.Size = new System.Drawing.Size(268, 25);
            this.lblTituloMant.TabIndex = 0;
            this.lblTituloMant.Text = "Información del Departamento";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(450, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 24);
            this.txtId.TabIndex = 1;
            this.txtId.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(35, 75);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(186, 17);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código del Departamento (*):";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(35, 100);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(510, 25);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(35, 145);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(192, 17);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre del Departamento (*):";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(35, 170);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(510, 25);
            this.txtNombre.TabIndex = 5;
            // 
            // lblDeptoPadre
            // 
            this.lblDeptoPadre.AutoSize = true;
            this.lblDeptoPadre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptoPadre.Location = new System.Drawing.Point(35, 215);
            this.lblDeptoPadre.Name = "lblDeptoPadre";
            this.lblDeptoPadre.Size = new System.Drawing.Size(262, 17);
            this.lblDeptoPadre.TabIndex = 6;
            this.lblDeptoPadre.Text = "Departamento Superior / Padre (Opcional):";
            // 
            // cboDeptoPadre
            // 
            this.cboDeptoPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptoPadre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDeptoPadre.FormattingEnabled = true;
            this.cboDeptoPadre.Location = new System.Drawing.Point(35, 240);
            this.cboDeptoPadre.Name = "cboDeptoPadre";
            this.cboDeptoPadre.Size = new System.Drawing.Size(510, 25);
            this.cboDeptoPadre.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(280, 310);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(420, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 38);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmDepartamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 640);
            this.pnlClientArea.Controls.Add(this.tabPrincipal);
            this.Name = "FrmDepartamentos";
            this.Text = "Gestión de Departamentos";
            this.Load += new System.EventHandler(this.FrmDepartamentos_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            this.pnlTopListado.ResumeLayout(false);
            this.pnlTopListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.pnlBottomListado.ResumeLayout(false);
            this.pnlBottomListado.PerformLayout();
            this.tabPageMantenimiento.ResumeLayout(false);
            this.pnlMantenimiento.ResumeLayout(false);
            this.pnlMantenimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.Panel pnlTopListado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel pnlBottomListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TabPage tabPageMantenimiento;
        private System.Windows.Forms.Panel pnlMantenimiento;
        private System.Windows.Forms.Label lblTituloMant;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDeptoPadre;
        private System.Windows.Forms.ComboBox cboDeptoPadre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
