namespace Sistema.Presentacion
{
    partial class FrmActualizacion
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
            this.pnlNovedades = new System.Windows.Forms.Panel();
            this.txtNovedades = new System.Windows.Forms.TextBox();
            this.lblTituloNovedades = new System.Windows.Forms.Label();
            this.pnlVersionInfo = new System.Windows.Forms.Panel();
            this.lblReleaseTitle = new System.Windows.Forms.Label();
            this.lblBadgeNueva = new System.Windows.Forms.Label();
            this.lblVersionNueva = new System.Windows.Forms.Label();
            this.lblVersionActual = new System.Windows.Forms.Label();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.progressBarDescarga = new System.Windows.Forms.ProgressBar();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlCuerpo.SuspendLayout();
            this.pnlNovedades.SuspendLayout();
            this.pnlVersionInfo.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(580, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(70, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Hospital de El Progreso • Control de Versiones y Despliegue";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(70, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 21);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nueva Actualización Disponible";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.picIcon.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
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
            this.pnlCuerpo.Controls.Add(this.pnlNovedades);
            this.pnlCuerpo.Controls.Add(this.pnlVersionInfo);
            this.pnlCuerpo.Controls.Add(this.lblVelocidad);
            this.pnlCuerpo.Controls.Add(this.lblPorcentaje);
            this.pnlCuerpo.Controls.Add(this.lblEstado);
            this.pnlCuerpo.Controls.Add(this.progressBarDescarga);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 70);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCuerpo.Size = new System.Drawing.Size(580, 310);
            this.pnlCuerpo.TabIndex = 1;
            // 
            // pnlNovedades
            // 
            this.pnlNovedades.BackColor = System.Drawing.Color.White;
            this.pnlNovedades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNovedades.Controls.Add(this.txtNovedades);
            this.pnlNovedades.Controls.Add(this.lblTituloNovedades);
            this.pnlNovedades.Location = new System.Drawing.Point(20, 85);
            this.pnlNovedades.Name = "pnlNovedades";
            this.pnlNovedades.Padding = new System.Windows.Forms.Padding(10);
            this.pnlNovedades.Size = new System.Drawing.Size(540, 130);
            this.pnlNovedades.TabIndex = 5;
            // 
            // txtNovedades
            // 
            this.txtNovedades.BackColor = System.Drawing.Color.White;
            this.txtNovedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNovedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNovedades.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNovedades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtNovedades.Location = new System.Drawing.Point(10, 30);
            this.txtNovedades.Multiline = true;
            this.txtNovedades.Name = "txtNovedades";
            this.txtNovedades.ReadOnly = true;
            this.txtNovedades.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNovedades.Size = new System.Drawing.Size(518, 88);
            this.txtNovedades.TabIndex = 1;
            // 
            // lblTituloNovedades
            // 
            this.lblTituloNovedades.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloNovedades.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloNovedades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloNovedades.Location = new System.Drawing.Point(10, 10);
            this.lblTituloNovedades.Name = "lblTituloNovedades";
            this.lblTituloNovedades.Size = new System.Drawing.Size(518, 20);
            this.lblTituloNovedades.TabIndex = 0;
            this.lblTituloNovedades.Text = "Novedades y Mejoras:";
            // 
            // pnlVersionInfo
            // 
            this.pnlVersionInfo.BackColor = System.Drawing.Color.White;
            this.pnlVersionInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVersionInfo.Controls.Add(this.lblReleaseTitle);
            this.pnlVersionInfo.Controls.Add(this.lblBadgeNueva);
            this.pnlVersionInfo.Controls.Add(this.lblVersionNueva);
            this.pnlVersionInfo.Controls.Add(this.lblVersionActual);
            this.pnlVersionInfo.Location = new System.Drawing.Point(20, 15);
            this.pnlVersionInfo.Name = "pnlVersionInfo";
            this.pnlVersionInfo.Size = new System.Drawing.Size(540, 60);
            this.pnlVersionInfo.TabIndex = 4;
            // 
            // lblReleaseTitle
            // 
            this.lblReleaseTitle.AutoSize = true;
            this.lblReleaseTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblReleaseTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReleaseTitle.Location = new System.Drawing.Point(15, 34);
            this.lblReleaseTitle.Name = "lblReleaseTitle";
            this.lblReleaseTitle.Size = new System.Drawing.Size(99, 15);
            this.lblReleaseTitle.TabIndex = 3;
            this.lblReleaseTitle.Text = "Título del Release";
            // 
            // lblBadgeNueva
            // 
            this.lblBadgeNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeNueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblBadgeNueva.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBadgeNueva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.lblBadgeNueva.Location = new System.Drawing.Point(445, 12);
            this.lblBadgeNueva.Name = "lblBadgeNueva";
            this.lblBadgeNueva.Size = new System.Drawing.Size(80, 22);
            this.lblBadgeNueva.TabIndex = 2;
            this.lblBadgeNueva.Text = "DISPONIBLE";
            this.lblBadgeNueva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersionNueva
            // 
            this.lblVersionNueva.AutoSize = true;
            this.lblVersionNueva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersionNueva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblVersionNueva.Location = new System.Drawing.Point(180, 12);
            this.lblVersionNueva.Name = "lblVersionNueva";
            this.lblVersionNueva.Size = new System.Drawing.Size(129, 19);
            this.lblVersionNueva.TabIndex = 1;
            this.lblVersionNueva.Text = "Nueva: v1.0.1";
            // 
            // lblVersionActual
            // 
            this.lblVersionActual.AutoSize = true;
            this.lblVersionActual.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVersionActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblVersionActual.Location = new System.Drawing.Point(15, 13);
            this.lblVersionActual.Name = "lblVersionActual";
            this.lblVersionActual.Size = new System.Drawing.Size(134, 17);
            this.lblVersionActual.TabIndex = 0;
            this.lblVersionActual.Text = "Instalada: v1.0.0";
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVelocidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVelocidad.Location = new System.Drawing.Point(20, 285);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(0, 13);
            this.lblVelocidad.TabIndex = 3;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblPorcentaje.Location = new System.Drawing.Point(460, 222);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(100, 20);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPorcentaje.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblEstado.Location = new System.Drawing.Point(20, 225);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(262, 15);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Listo para iniciar la actualización automática.";
            // 
            // progressBarDescarga
            // 
            this.progressBarDescarga.Location = new System.Drawing.Point(20, 250);
            this.progressBarDescarga.Name = "progressBarDescarga";
            this.progressBarDescarga.Size = new System.Drawing.Size(540, 25);
            this.progressBarDescarga.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarDescarga.TabIndex = 0;
            this.progressBarDescarga.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnActualizar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 380);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(580, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(295, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(425, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(135, 36);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar Ahora";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmActualizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 440);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmActualizacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualización del Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmActualizacion_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlNovedades.ResumeLayout(false);
            this.pnlNovedades.PerformLayout();
            this.pnlVersionInfo.ResumeLayout(false);
            this.pnlVersionInfo.PerformLayout();
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
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar progressBarDescarga;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Panel pnlVersionInfo;
        private System.Windows.Forms.Label lblVersionActual;
        private System.Windows.Forms.Label lblVersionNueva;
        private System.Windows.Forms.Label lblBadgeNueva;
        private System.Windows.Forms.Label lblReleaseTitle;
        private System.Windows.Forms.Panel pnlNovedades;
        private System.Windows.Forms.Label lblTituloNovedades;
        private System.Windows.Forms.TextBox txtNovedades;
    }
}
