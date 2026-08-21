namespace Sistema.Presentacion
{
    partial class FrmDashboard
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
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardEmpleados = new System.Windows.Forms.Panel();
            this.lblCantEmpleados = new System.Windows.Forms.Label();
            this.lblTituloCard1 = new System.Windows.Forms.Label();
            this.pnlCardBiometricos = new System.Windows.Forms.Panel();
            this.lblCantBiometricos = new System.Windows.Forms.Label();
            this.lblTituloCard2 = new System.Windows.Forms.Label();
            this.pnlCardMarcaciones = new System.Windows.Forms.Panel();
            this.lblCantMarcacionesHoy = new System.Windows.Forms.Label();
            this.lblVariacionHoy = new System.Windows.Forms.Label();
            this.lblTituloCard3 = new System.Windows.Forms.Label();
            this.pnlCardMes = new System.Windows.Forms.Panel();
            this.lblCantMarcacionesMes = new System.Windows.Forms.Label();
            this.lblTituloCard4 = new System.Windows.Forms.Label();
            this.tlpGraficas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGraficaDias = new System.Windows.Forms.Panel();
            this.pnlGraficaHora = new System.Windows.Forms.Panel();
            this.pnlGraficaDept = new System.Windows.Forms.Panel();
            this.pnlGraficaBio = new System.Windows.Forms.Panel();
            this.tlpCards.SuspendLayout();
            this.pnlCardEmpleados.SuspendLayout();
            this.pnlCardBiometricos.SuspendLayout();
            this.pnlCardMarcaciones.SuspendLayout();
            this.pnlCardMes.SuspendLayout();
            this.tlpGraficas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 4;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.Controls.Add(this.pnlCardEmpleados, 0, 0);
            this.tlpCards.Controls.Add(this.pnlCardBiometricos, 1, 0);
            this.tlpCards.Controls.Add(this.pnlCardMarcaciones, 2, 0);
            this.tlpCards.Controls.Add(this.pnlCardMes, 3, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCards.Location = new System.Drawing.Point(0, 0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(960, 105);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlCardEmpleados
            // 
            this.pnlCardEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pnlCardEmpleados.Controls.Add(this.lblCantEmpleados);
            this.pnlCardEmpleados.Controls.Add(this.lblTituloCard1);
            this.pnlCardEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardEmpleados.Location = new System.Drawing.Point(14, 14);
            this.pnlCardEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardEmpleados.Name = "pnlCardEmpleados";
            this.pnlCardEmpleados.Size = new System.Drawing.Size(227, 82);
            this.pnlCardEmpleados.TabIndex = 0;
            // 
            // lblCantEmpleados
            // 
            this.lblCantEmpleados.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCantEmpleados.ForeColor = System.Drawing.Color.White;
            this.lblCantEmpleados.Location = new System.Drawing.Point(8, 30);
            this.lblCantEmpleados.Name = "lblCantEmpleados";
            this.lblCantEmpleados.Size = new System.Drawing.Size(210, 45);
            this.lblCantEmpleados.TabIndex = 1;
            this.lblCantEmpleados.Text = "–";
            // 
            // lblTituloCard1
            // 
            this.lblTituloCard1.AutoSize = true;
            this.lblTituloCard1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblTituloCard1.Location = new System.Drawing.Point(8, 8);
            this.lblTituloCard1.Name = "lblTituloCard1";
            this.lblTituloCard1.Size = new System.Drawing.Size(95, 15);
            this.lblTituloCard1.TabIndex = 0;
            this.lblTituloCard1.Text = "👥 EMPLEADOS";
            // 
            // pnlCardBiometricos
            // 
            this.pnlCardBiometricos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.pnlCardBiometricos.Controls.Add(this.lblCantBiometricos);
            this.pnlCardBiometricos.Controls.Add(this.lblTituloCard2);
            this.pnlCardBiometricos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBiometricos.Location = new System.Drawing.Point(249, 14);
            this.pnlCardBiometricos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardBiometricos.Name = "pnlCardBiometricos";
            this.pnlCardBiometricos.Size = new System.Drawing.Size(227, 82);
            this.pnlCardBiometricos.TabIndex = 1;
            // 
            // lblCantBiometricos
            // 
            this.lblCantBiometricos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCantBiometricos.ForeColor = System.Drawing.Color.White;
            this.lblCantBiometricos.Location = new System.Drawing.Point(8, 30);
            this.lblCantBiometricos.Name = "lblCantBiometricos";
            this.lblCantBiometricos.Size = new System.Drawing.Size(210, 45);
            this.lblCantBiometricos.TabIndex = 1;
            this.lblCantBiometricos.Text = "–";
            // 
            // lblTituloCard2
            // 
            this.lblTituloCard2.AutoSize = true;
            this.lblTituloCard2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblTituloCard2.Location = new System.Drawing.Point(8, 8);
            this.lblTituloCard2.Name = "lblTituloCard2";
            this.lblTituloCard2.Size = new System.Drawing.Size(107, 15);
            this.lblTituloCard2.TabIndex = 0;
            this.lblTituloCard2.Text = "📟 BIOMÉTRICOS";
            // 
            // pnlCardMarcaciones
            // 
            this.pnlCardMarcaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlCardMarcaciones.Controls.Add(this.lblCantMarcacionesHoy);
            this.pnlCardMarcaciones.Controls.Add(this.lblVariacionHoy);
            this.pnlCardMarcaciones.Controls.Add(this.lblTituloCard3);
            this.pnlCardMarcaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardMarcaciones.Location = new System.Drawing.Point(484, 14);
            this.pnlCardMarcaciones.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardMarcaciones.Name = "pnlCardMarcaciones";
            this.pnlCardMarcaciones.Size = new System.Drawing.Size(227, 82);
            this.pnlCardMarcaciones.TabIndex = 2;
            // 
            // lblCantMarcacionesHoy
            // 
            this.lblCantMarcacionesHoy.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCantMarcacionesHoy.ForeColor = System.Drawing.Color.White;
            this.lblCantMarcacionesHoy.Location = new System.Drawing.Point(8, 25);
            this.lblCantMarcacionesHoy.Name = "lblCantMarcacionesHoy";
            this.lblCantMarcacionesHoy.Size = new System.Drawing.Size(120, 40);
            this.lblCantMarcacionesHoy.TabIndex = 1;
            this.lblCantMarcacionesHoy.Text = "–";
            // 
            // lblVariacionHoy
            // 
            this.lblVariacionHoy.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblVariacionHoy.ForeColor = System.Drawing.Color.White;
            this.lblVariacionHoy.Location = new System.Drawing.Point(8, 62);
            this.lblVariacionHoy.Name = "lblVariacionHoy";
            this.lblVariacionHoy.Size = new System.Drawing.Size(200, 16);
            this.lblVariacionHoy.TabIndex = 2;
            this.lblVariacionHoy.Text = "";
            // 
            // lblTituloCard3
            // 
            this.lblTituloCard3.AutoSize = true;
            this.lblTituloCard3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.lblTituloCard3.Location = new System.Drawing.Point(8, 8);
            this.lblTituloCard3.Name = "lblTituloCard3";
            this.lblTituloCard3.Size = new System.Drawing.Size(135, 15);
            this.lblTituloCard3.TabIndex = 0;
            this.lblTituloCard3.Text = "🕒 MARCACIONES HOY";
            // 
            // pnlCardMes
            // 
            this.pnlCardMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.pnlCardMes.Controls.Add(this.lblCantMarcacionesMes);
            this.pnlCardMes.Controls.Add(this.lblTituloCard4);
            this.pnlCardMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardMes.Location = new System.Drawing.Point(719, 14);
            this.pnlCardMes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardMes.Name = "pnlCardMes";
            this.pnlCardMes.Size = new System.Drawing.Size(227, 82);
            this.pnlCardMes.TabIndex = 3;
            // 
            // lblCantMarcacionesMes
            // 
            this.lblCantMarcacionesMes.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCantMarcacionesMes.ForeColor = System.Drawing.Color.White;
            this.lblCantMarcacionesMes.Location = new System.Drawing.Point(8, 30);
            this.lblCantMarcacionesMes.Name = "lblCantMarcacionesMes";
            this.lblCantMarcacionesMes.Size = new System.Drawing.Size(210, 45);
            this.lblCantMarcacionesMes.TabIndex = 1;
            this.lblCantMarcacionesMes.Text = "–";
            // 
            // lblTituloCard4
            // 
            this.lblTituloCard4.AutoSize = true;
            this.lblTituloCard4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblTituloCard4.Location = new System.Drawing.Point(8, 8);
            this.lblTituloCard4.Name = "lblTituloCard4";
            this.lblTituloCard4.Size = new System.Drawing.Size(120, 15);
            this.lblTituloCard4.TabIndex = 0;
            this.lblTituloCard4.Text = "📅 TOTAL ESTE MES";
            // 
            // tlpGraficas
            // 
            this.tlpGraficas.ColumnCount = 2;
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.Controls.Add(this.pnlGraficaDias, 0, 0);
            this.tlpGraficas.Controls.Add(this.pnlGraficaHora, 1, 0);
            this.tlpGraficas.Controls.Add(this.pnlGraficaDept, 0, 1);
            this.tlpGraficas.Controls.Add(this.pnlGraficaBio, 1, 1);
            this.tlpGraficas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficas.Location = new System.Drawing.Point(0, 105);
            this.tlpGraficas.Name = "tlpGraficas";
            this.tlpGraficas.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.tlpGraficas.RowCount = 2;
            this.tlpGraficas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.Size = new System.Drawing.Size(960, 575);
            this.tlpGraficas.TabIndex = 1;
            // 
            // pnlGraficaDias
            // 
            this.pnlGraficaDias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlGraficaDias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficaDias.Location = new System.Drawing.Point(14, 9);
            this.pnlGraficaDias.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGraficaDias.Name = "pnlGraficaDias";
            this.pnlGraficaDias.Size = new System.Drawing.Size(462, 272);
            this.pnlGraficaDias.TabIndex = 0;
            this.pnlGraficaDias.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraficaDias_Paint);
            // 
            // pnlGraficaHora
            // 
            this.pnlGraficaHora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlGraficaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficaHora.Location = new System.Drawing.Point(484, 9);
            this.pnlGraficaHora.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGraficaHora.Name = "pnlGraficaHora";
            this.pnlGraficaHora.Size = new System.Drawing.Size(462, 272);
            this.pnlGraficaHora.TabIndex = 1;
            this.pnlGraficaHora.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraficaHora_Paint);
            // 
            // pnlGraficaDept
            // 
            this.pnlGraficaDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlGraficaDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficaDept.Location = new System.Drawing.Point(14, 289);
            this.pnlGraficaDept.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGraficaDept.Name = "pnlGraficaDept";
            this.pnlGraficaDept.Size = new System.Drawing.Size(462, 272);
            this.pnlGraficaDept.TabIndex = 2;
            this.pnlGraficaDept.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraficaDept_Paint);
            // 
            // pnlGraficaBio
            // 
            this.pnlGraficaBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlGraficaBio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficaBio.Location = new System.Drawing.Point(484, 289);
            this.pnlGraficaBio.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGraficaBio.Name = "pnlGraficaBio";
            this.pnlGraficaBio.Size = new System.Drawing.Size(462, 272);
            this.pnlGraficaBio.TabIndex = 3;
            this.pnlGraficaBio.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraficaBio_Paint);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.pnlClientArea.Controls.Add(this.tlpGraficas);
            this.pnlClientArea.Controls.Add(this.tlpCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDashboard";
            this.Text = "Panel Principal / Resumen";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.tlpCards.ResumeLayout(false);
            this.pnlCardEmpleados.ResumeLayout(false);
            this.pnlCardEmpleados.PerformLayout();
            this.pnlCardBiometricos.ResumeLayout(false);
            this.pnlCardBiometricos.PerformLayout();
            this.pnlCardMarcaciones.ResumeLayout(false);
            this.pnlCardMarcaciones.PerformLayout();
            this.pnlCardMes.ResumeLayout(false);
            this.pnlCardMes.PerformLayout();
            this.tlpGraficas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel pnlCardEmpleados;
        private System.Windows.Forms.Label lblCantEmpleados;
        private System.Windows.Forms.Label lblTituloCard1;
        private System.Windows.Forms.Panel pnlCardBiometricos;
        private System.Windows.Forms.Label lblCantBiometricos;
        private System.Windows.Forms.Label lblTituloCard2;
        private System.Windows.Forms.Panel pnlCardMarcaciones;
        private System.Windows.Forms.Label lblCantMarcacionesHoy;
        private System.Windows.Forms.Label lblVariacionHoy;
        private System.Windows.Forms.Label lblTituloCard3;
        private System.Windows.Forms.Panel pnlCardMes;
        private System.Windows.Forms.Label lblCantMarcacionesMes;
        private System.Windows.Forms.Label lblTituloCard4;
        private System.Windows.Forms.TableLayoutPanel tlpGraficas;
        private System.Windows.Forms.Panel pnlGraficaDias;
        private System.Windows.Forms.Panel pnlGraficaHora;
        private System.Windows.Forms.Panel pnlGraficaDept;
        private System.Windows.Forms.Panel pnlGraficaBio;
    }
}
