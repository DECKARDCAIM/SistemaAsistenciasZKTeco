namespace Sistema.Presentacion
{
    partial class FrmProgresoSync
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblStatDuplicados = new System.Windows.Forms.Label();
            this.lblValDuplicados = new System.Windows.Forms.Label();
            this.lblStatNuevos = new System.Windows.Forms.Label();
            this.lblValNuevos = new System.Windows.Forms.Label();
            this.lblStatLeidos = new System.Windows.Forms.Label();
            this.lblValLeidos = new System.Windows.Forms.Label();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblValTotal = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblFase = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.progressBarSync = new System.Windows.Forms.ProgressBar();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlCuerpo.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.picIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(70, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(315, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Descarga de registros y persistencia en Base de Datos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(70, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(282, 21);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Sincronización en Tiempo Real";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.picIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picIcon.IconSize = 40;
            this.picIcon.Location = new System.Drawing.Point(18, 15);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(40, 40);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlCuerpo.Controls.Add(this.pnlStats);
            this.pnlCuerpo.Controls.Add(this.lblDetalle);
            this.pnlCuerpo.Controls.Add(this.lblFase);
            this.pnlCuerpo.Controls.Add(this.lblPorcentaje);
            this.pnlCuerpo.Controls.Add(this.progressBarSync);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 70);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(25);
            this.pnlCuerpo.Size = new System.Drawing.Size(560, 240);
            this.pnlCuerpo.TabIndex = 1;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblStatDuplicados);
            this.pnlStats.Controls.Add(this.lblValDuplicados);
            this.pnlStats.Controls.Add(this.lblStatNuevos);
            this.pnlStats.Controls.Add(this.lblValNuevos);
            this.pnlStats.Controls.Add(this.lblStatLeidos);
            this.pnlStats.Controls.Add(this.lblValLeidos);
            this.pnlStats.Controls.Add(this.lblStatTotal);
            this.pnlStats.Controls.Add(this.lblValTotal);
            this.pnlStats.Location = new System.Drawing.Point(25, 130);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(510, 75);
            this.pnlStats.TabIndex = 4;
            // 
            // lblStatDuplicados
            // 
            this.lblStatDuplicados.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblStatDuplicados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatDuplicados.Location = new System.Drawing.Point(380, 42);
            this.lblStatDuplicados.Name = "lblStatDuplicados";
            this.lblStatDuplicados.Size = new System.Drawing.Size(120, 18);
            this.lblStatDuplicados.TabIndex = 7;
            this.lblStatDuplicados.Text = "YA EXISTENTES";
            this.lblStatDuplicados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValDuplicados
            // 
            this.lblValDuplicados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValDuplicados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblValDuplicados.Location = new System.Drawing.Point(380, 14);
            this.lblValDuplicados.Name = "lblValDuplicados";
            this.lblValDuplicados.Size = new System.Drawing.Size(120, 24);
            this.lblValDuplicados.TabIndex = 6;
            this.lblValDuplicados.Text = "0";
            this.lblValDuplicados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatNuevos
            // 
            this.lblStatNuevos.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblStatNuevos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblStatNuevos.Location = new System.Drawing.Point(255, 42);
            this.lblStatNuevos.Name = "lblStatNuevos";
            this.lblStatNuevos.Size = new System.Drawing.Size(120, 18);
            this.lblStatNuevos.TabIndex = 5;
            this.lblStatNuevos.Text = "NUEVOS EN BD";
            this.lblStatNuevos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValNuevos
            // 
            this.lblValNuevos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValNuevos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblValNuevos.Location = new System.Drawing.Point(255, 14);
            this.lblValNuevos.Name = "lblValNuevos";
            this.lblValNuevos.Size = new System.Drawing.Size(120, 24);
            this.lblValNuevos.TabIndex = 4;
            this.lblValNuevos.Text = "0";
            this.lblValNuevos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatLeidos
            // 
            this.lblStatLeidos.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblStatLeidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblStatLeidos.Location = new System.Drawing.Point(130, 42);
            this.lblStatLeidos.Name = "lblStatLeidos";
            this.lblStatLeidos.Size = new System.Drawing.Size(120, 18);
            this.lblStatLeidos.TabIndex = 3;
            this.lblStatLeidos.Text = "LEÍDOS";
            this.lblStatLeidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValLeidos
            // 
            this.lblValLeidos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValLeidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblValLeidos.Location = new System.Drawing.Point(130, 14);
            this.lblValLeidos.Name = "lblValLeidos";
            this.lblValLeidos.Size = new System.Drawing.Size(120, 24);
            this.lblValLeidos.TabIndex = 2;
            this.lblValLeidos.Text = "0";
            this.lblValLeidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStatTotal.Location = new System.Drawing.Point(5, 42);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Size = new System.Drawing.Size(120, 18);
            this.lblStatTotal.TabIndex = 1;
            this.lblStatTotal.Text = "EN RELOJ";
            this.lblStatTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValTotal
            // 
            this.lblValTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblValTotal.Location = new System.Drawing.Point(5, 14);
            this.lblValTotal.Name = "lblValTotal";
            this.lblValTotal.Size = new System.Drawing.Size(120, 24);
            this.lblValTotal.TabIndex = 0;
            this.lblValTotal.Text = "0";
            this.lblValTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDetalle.Location = new System.Drawing.Point(25, 95);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(134, 15);
            this.lblDetalle.TabIndex = 3;
            this.lblDetalle.Text = "Iniciando comunicación...";
            // 
            // lblFase
            // 
            this.lblFase.AutoSize = true;
            this.lblFase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblFase.Location = new System.Drawing.Point(25, 20);
            this.lblFase.Name = "lblFase";
            this.lblFase.Size = new System.Drawing.Size(236, 17);
            this.lblFase.TabIndex = 2;
            this.lblFase.Text = "Conectando al Biométrico ZKTeco...";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(214)))));
            this.lblPorcentaje.Location = new System.Drawing.Point(440, 14);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(95, 25);
            this.lblPorcentaje.TabIndex = 1;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBarSync
            // 
            this.progressBarSync.Location = new System.Drawing.Point(25, 50);
            this.progressBarSync.Name = "progressBarSync";
            this.progressBarSync.Size = new System.Drawing.Size(510, 32);
            this.progressBarSync.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarSync.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 310);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(560, 55);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(435, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmProgresoSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 365);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProgresoSync";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sincronizando Reloj Biométrico...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProgresoSync_FormClosing);
            this.Shown += new System.EventHandler(this.FrmProgresoSync_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private FontAwesome.Sharp.IconPictureBox picIcon;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar progressBarSync;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblFase;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblValTotal;
        private System.Windows.Forms.Label lblStatDuplicados;
        private System.Windows.Forms.Label lblValDuplicados;
        private System.Windows.Forms.Label lblStatNuevos;
        private System.Windows.Forms.Label lblValNuevos;
        private System.Windows.Forms.Label lblStatLeidos;
        private System.Windows.Forms.Label lblValLeidos;
    }
}
