namespace Sistema.Desinstalador
{
    partial class FrmDesinstalador
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
            this.btnDesinstalar = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.pnlTipoEquipo = new System.Windows.Forms.Panel();
            this.lblDetalleModo = new System.Windows.Forms.Label();
            this.lblModoDetectado = new System.Windows.Forms.Label();
            this.picModo = new FontAwesome.Sharp.IconPictureBox();
            this.lblDetalleProgreso = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.progressBarDesinstalacion = new System.Windows.Forms.ProgressBar();
            this.lblTituloConfirmacion = new System.Windows.Forms.Label();
            this.picTrash = new FontAwesome.Sharp.IconPictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlTipoEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picModo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrash)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(600, 75);
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(206, 21);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Desinstalador del Sistema";
            // 
            // picHeaderIcon
            // 
            this.picHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.picHeaderIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.picHeaderIcon.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
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
            this.pnlFooter.Controls.Add(this.btnDesinstalar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 360);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(600, 60);
            this.pnlFooter.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(340, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDesinstalar
            // 
            this.btnDesinstalar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesinstalar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDesinstalar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesinstalar.FlatAppearance.BorderSize = 0;
            this.btnDesinstalar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesinstalar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDesinstalar.ForeColor = System.Drawing.Color.White;
            this.btnDesinstalar.Location = new System.Drawing.Point(450, 14);
            this.btnDesinstalar.Name = "btnDesinstalar";
            this.btnDesinstalar.Size = new System.Drawing.Size(130, 34);
            this.btnDesinstalar.TabIndex = 0;
            this.btnDesinstalar.Text = "Desinstalar Ahora";
            this.btnDesinstalar.UseVisualStyleBackColor = false;
            this.btnDesinstalar.Click += new System.EventHandler(this.btnDesinstalar_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBody.Controls.Add(this.lblAdvertencia);
            this.pnlBody.Controls.Add(this.pnlTipoEquipo);
            this.pnlBody.Controls.Add(this.lblDetalleProgreso);
            this.pnlBody.Controls.Add(this.lblPorcentaje);
            this.pnlBody.Controls.Add(this.progressBarDesinstalacion);
            this.pnlBody.Controls.Add(this.lblTituloConfirmacion);
            this.pnlBody.Controls.Add(this.picTrash);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 75);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(25);
            this.pnlBody.Size = new System.Drawing.Size(600, 285);
            this.pnlBody.TabIndex = 2;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAdvertencia.Location = new System.Drawing.Point(100, 60);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(475, 45);
            this.lblAdvertencia.TabIndex = 6;
            this.lblAdvertencia.Text = "Esta acción eliminará completamente el Sistema de Asistencias ZKTeco de este equi" +
    "po, incluyendo sus accesos directos, configuraciones y librerías registradas.";
            // 
            // pnlTipoEquipo
            // 
            this.pnlTipoEquipo.BackColor = System.Drawing.Color.White;
            this.pnlTipoEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipoEquipo.Controls.Add(this.lblDetalleModo);
            this.pnlTipoEquipo.Controls.Add(this.lblModoDetectado);
            this.pnlTipoEquipo.Controls.Add(this.picModo);
            this.pnlTipoEquipo.Location = new System.Drawing.Point(25, 115);
            this.pnlTipoEquipo.Name = "pnlTipoEquipo";
            this.pnlTipoEquipo.Size = new System.Drawing.Size(550, 70);
            this.pnlTipoEquipo.TabIndex = 5;
            // 
            // lblDetalleModo
            // 
            this.lblDetalleModo.AutoSize = true;
            this.lblDetalleModo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalleModo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDetalleModo.Location = new System.Drawing.Point(60, 36);
            this.lblDetalleModo.Name = "lblDetalleModo";
            this.lblDetalleModo.Size = new System.Drawing.Size(342, 15);
            this.lblDetalleModo.TabIndex = 2;
            this.lblDetalleModo.Text = "Se eliminará la aplicación de escritorio y los accesos directos.";
            // 
            // lblModoDetectado
            // 
            this.lblModoDetectado.AutoSize = true;
            this.lblModoDetectado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblModoDetectado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblModoDetectado.Location = new System.Drawing.Point(60, 15);
            this.lblModoDetectado.Name = "lblModoDetectado";
            this.lblModoDetectado.Size = new System.Drawing.Size(227, 17);
            this.lblModoDetectado.TabIndex = 1;
            this.lblModoDetectado.Text = "Modo: Estación de Trabajo Cliente";
            // 
            // picModo
            // 
            this.picModo.BackColor = System.Drawing.Color.Transparent;
            this.picModo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.picModo.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.picModo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picModo.IconSize = 36;
            this.picModo.Location = new System.Drawing.Point(12, 16);
            this.picModo.Name = "picModo";
            this.picModo.Size = new System.Drawing.Size(36, 36);
            this.picModo.TabIndex = 0;
            this.picModo.TabStop = false;
            // 
            // lblDetalleProgreso
            // 
            this.lblDetalleProgreso.AutoSize = true;
            this.lblDetalleProgreso.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalleProgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDetalleProgreso.Location = new System.Drawing.Point(25, 245);
            this.lblDetalleProgreso.Name = "lblDetalleProgreso";
            this.lblDetalleProgreso.Size = new System.Drawing.Size(193, 15);
            this.lblDetalleProgreso.TabIndex = 4;
            this.lblDetalleProgreso.Text = "Haga clic en \'Desinstalar Ahora\'...";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblPorcentaje.Location = new System.Drawing.Point(475, 242);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(100, 20);
            this.lblPorcentaje.TabIndex = 3;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPorcentaje.Visible = false;
            // 
            // progressBarDesinstalacion
            // 
            this.progressBarDesinstalacion.Location = new System.Drawing.Point(25, 205);
            this.progressBarDesinstalacion.Name = "progressBarDesinstalacion";
            this.progressBarDesinstalacion.Size = new System.Drawing.Size(550, 26);
            this.progressBarDesinstalacion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarDesinstalacion.TabIndex = 2;
            // 
            // lblTituloConfirmacion
            // 
            this.lblTituloConfirmacion.AutoSize = true;
            this.lblTituloConfirmacion.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloConfirmacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloConfirmacion.Location = new System.Drawing.Point(100, 28);
            this.lblTituloConfirmacion.Name = "lblTituloConfirmacion";
            this.lblTituloConfirmacion.Size = new System.Drawing.Size(364, 21);
            this.lblTituloConfirmacion.TabIndex = 1;
            this.lblTituloConfirmacion.Text = "¿Desea desinstalar el Sistema de Asistencias?";
            // 
            // picTrash
            // 
            this.picTrash.BackColor = System.Drawing.Color.Transparent;
            this.picTrash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.picTrash.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.picTrash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picTrash.IconSize = 56;
            this.picTrash.Location = new System.Drawing.Point(25, 25);
            this.picTrash.Name = "picTrash";
            this.picTrash.Size = new System.Drawing.Size(56, 56);
            this.picTrash.TabIndex = 0;
            this.picTrash.TabStop = false;
            // 
            // FrmDesinstalador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDesinstalador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desinstalador - Hospital de El Progreso";
            this.Load += new System.EventHandler(this.FrmDesinstalador_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlTipoEquipo.ResumeLayout(false);
            this.pnlTipoEquipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picModo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private FontAwesome.Sharp.IconPictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnDesinstalar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlBody;
        private FontAwesome.Sharp.IconPictureBox picTrash;
        private System.Windows.Forms.Label lblTituloConfirmacion;
        private System.Windows.Forms.ProgressBar progressBarDesinstalacion;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblDetalleProgreso;
        private System.Windows.Forms.Panel pnlTipoEquipo;
        private FontAwesome.Sharp.IconPictureBox picModo;
        private System.Windows.Forms.Label lblModoDetectado;
        private System.Windows.Forms.Label lblDetalleModo;
        private System.Windows.Forms.Label lblAdvertencia;
    }
}
