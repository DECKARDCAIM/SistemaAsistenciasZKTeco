namespace Sistema.Presentacion
{
    partial class FrmInfoSistema
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblEstadoActualizado = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblDbTitle = new System.Windows.Forms.Label();
            this.lblDbDesc = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblRedisTitle = new System.Windows.Forms.Label();
            this.lblRedisDesc = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblZkTitle = new System.Windows.Forms.Label();
            this.lblZkDesc = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblLicTitle = new System.Windows.Forms.Label();
            this.lblLicDesc = new System.Windows.Forms.Label();
            this.lblTechHeader = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.pnlHeader.Controls.Add(this.pbLogo);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(460, 140);
            this.pnlHeader.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Location = new System.Drawing.Point(90, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(280, 65);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(10, 80);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(440, 25);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "SISTEMA DE ASISTENCIAS ZKTECO";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(10, 108);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(440, 20);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Hospital de El Progreso - Control Biométrico de Asistencias";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblVersion.Location = new System.Drawing.Point(20, 155);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(420, 22);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Versión instalada: v0.0.1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoActualizado
            // 
            this.lblEstadoActualizado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblEstadoActualizado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoActualizado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoActualizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblEstadoActualizado.Location = new System.Drawing.Point(70, 185);
            this.lblEstadoActualizado.Name = "lblEstadoActualizado";
            this.lblEstadoActualizado.Size = new System.Drawing.Size(320, 26);
            this.lblEstadoActualizado.TabIndex = 2;
            this.lblEstadoActualizado.Text = "✓  Sistema Actualizado y Operativo";
            this.lblEstadoActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblDbTitle);
            this.pnlCard1.Controls.Add(this.lblDbDesc);
            this.pnlCard1.Location = new System.Drawing.Point(25, 230);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(195, 55);
            this.pnlCard1.TabIndex = 3;
            // 
            // lblDbTitle
            // 
            this.lblDbTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.lblDbTitle.Location = new System.Drawing.Point(8, 6);
            this.lblDbTitle.Name = "lblDbTitle";
            this.lblDbTitle.Size = new System.Drawing.Size(175, 18);
            this.lblDbTitle.TabIndex = 0;
            this.lblDbTitle.Text = "Base de Datos";
            // 
            // lblDbDesc
            // 
            this.lblDbDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDbDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDbDesc.Location = new System.Drawing.Point(8, 25);
            this.lblDbDesc.Name = "lblDbDesc";
            this.lblDbDesc.Size = new System.Drawing.Size(175, 20);
            this.lblDbDesc.TabIndex = 1;
            this.lblDbDesc.Text = "PostgreSQL (Conectado)";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblRedisTitle);
            this.pnlCard2.Controls.Add(this.lblRedisDesc);
            this.pnlCard2.Location = new System.Drawing.Point(240, 230);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(195, 55);
            this.pnlCard2.TabIndex = 4;
            // 
            // lblRedisTitle
            // 
            this.lblRedisTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRedisTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblRedisTitle.Location = new System.Drawing.Point(8, 6);
            this.lblRedisTitle.Name = "lblRedisTitle";
            this.lblRedisTitle.Size = new System.Drawing.Size(175, 18);
            this.lblRedisTitle.TabIndex = 0;
            this.lblRedisTitle.Text = "Capa de Caché";
            // 
            // lblRedisDesc
            // 
            this.lblRedisDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRedisDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblRedisDesc.Location = new System.Drawing.Point(8, 25);
            this.lblRedisDesc.Name = "lblRedisDesc";
            this.lblRedisDesc.Size = new System.Drawing.Size(175, 20);
            this.lblRedisDesc.TabIndex = 1;
            this.lblRedisDesc.Text = "Redis Cache (En vivo)";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblZkTitle);
            this.pnlCard3.Controls.Add(this.lblZkDesc);
            this.pnlCard3.Location = new System.Drawing.Point(25, 295);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(195, 55);
            this.pnlCard3.TabIndex = 5;
            // 
            // lblZkTitle
            // 
            this.lblZkTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblZkTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.lblZkTitle.Location = new System.Drawing.Point(8, 6);
            this.lblZkTitle.Name = "lblZkTitle";
            this.lblZkTitle.Size = new System.Drawing.Size(175, 18);
            this.lblZkTitle.TabIndex = 0;
            this.lblZkTitle.Text = "Biométricos";
            // 
            // lblZkDesc
            // 
            this.lblZkDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblZkDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblZkDesc.Location = new System.Drawing.Point(8, 25);
            this.lblZkDesc.Name = "lblZkDesc";
            this.lblZkDesc.Size = new System.Drawing.Size(175, 20);
            this.lblZkDesc.TabIndex = 1;
            this.lblZkDesc.Text = "ZKTeco SDK Standalone";
            // 
            // pnlCard4
            // 
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblLicTitle);
            this.pnlCard4.Controls.Add(this.lblLicDesc);
            this.pnlCard4.Location = new System.Drawing.Point(240, 295);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(195, 55);
            this.pnlCard4.TabIndex = 6;
            // 
            // lblLicTitle
            // 
            this.lblLicTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLicTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            this.lblLicTitle.Location = new System.Drawing.Point(8, 6);
            this.lblLicTitle.Name = "lblLicTitle";
            this.lblLicTitle.Size = new System.Drawing.Size(175, 18);
            this.lblLicTitle.TabIndex = 0;
            this.lblLicTitle.Text = "Institución";
            // 
            // lblLicDesc
            // 
            this.lblLicDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLicDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblLicDesc.Location = new System.Drawing.Point(8, 25);
            this.lblLicDesc.Name = "lblLicDesc";
            this.lblLicDesc.Size = new System.Drawing.Size(175, 20);
            this.lblLicDesc.TabIndex = 1;
            this.lblLicDesc.Text = "MSPAS - Guatemala";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(165, 370);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 35);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Aceptar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmInfoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(460, 420);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.lblEstadoActualizado);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInfoSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Información del Sistema";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblEstadoActualizado;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblDbTitle;
        private System.Windows.Forms.Label lblDbDesc;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblRedisTitle;
        private System.Windows.Forms.Label lblRedisDesc;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblZkTitle;
        private System.Windows.Forms.Label lblZkDesc;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblLicTitle;
        private System.Windows.Forms.Label lblLicDesc;
        private System.Windows.Forms.Label lblTechHeader;
        private System.Windows.Forms.Button btnCerrar;
    }
}
