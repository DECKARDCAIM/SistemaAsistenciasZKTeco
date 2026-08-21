using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sistema.Negocio;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace Sistema.Presentacion
{
    public partial class FrmDashboard : RJCodeUI_M1.RJForms.RJChildForm
    {
        private DataSet _dsEstadisticas;

        public FrmDashboard()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.ChartPie;
            this.Text = "Panel Principal / Resumen";
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            try
            {
                var flags = System.Reflection.BindingFlags.SetProperty |
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic;

                typeof(Panel).InvokeMember("DoubleBuffered", flags, null, pnlGraficaDias, new object[] { true });
                typeof(Panel).InvokeMember("DoubleBuffered", flags, null, pnlGraficaHora, new object[] { true });
                typeof(Panel).InvokeMember("DoubleBuffered", flags, null, pnlGraficaDept, new object[] { true });
                typeof(Panel).InvokeMember("DoubleBuffered", flags, null, pnlGraficaBio, new object[] { true });
            }
            catch { }

            pnlGraficaDias.Resize += (s, e) => pnlGraficaDias.Invalidate();
            pnlGraficaHora.Resize += (s, e) => pnlGraficaHora.Invalidate();
            pnlGraficaDept.Resize += (s, e) => pnlGraficaDept.Invalidate();
            pnlGraficaBio.Resize += (s, e) => pnlGraficaBio.Invalidate();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarResumen();
        }

        public void AplicarTema()
        {
            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            Color colorFondo = esOscuro ? Color.FromArgb(18, 22, 38) : Color.FromArgb(245, 247, 251);
            this.BackColor = colorFondo;
            this.pnlClientArea.BackColor = colorFondo;

            Color colorFondoPaneles = esOscuro ? Color.FromArgb(24, 28, 45) : Color.White;
            pnlGraficaDias.BackColor = colorFondoPaneles;
            pnlGraficaHora.BackColor = colorFondoPaneles;
            pnlGraficaDept.BackColor = colorFondoPaneles;
            pnlGraficaBio.BackColor = colorFondoPaneles;

            RedibujarGraficas();
        }

        public void CargarResumen()
        {
            try
            {
                _dsEstadisticas = N_Asistencia.ObtenerEstadisticasDashboard();

                ActualizarKPIs();
                RedibujarGraficas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del resumen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarKPIs()
        {
            if (_dsEstadisticas == null || !_dsEstadisticas.Tables.Contains("Resumen") || _dsEstadisticas.Tables["Resumen"].Rows.Count == 0)
                return;

            DataRow r = _dsEstadisticas.Tables["Resumen"].Rows[0];

            lblCantEmpleados.Text = r["total_empleados"].ToString();
            lblCantBiometricos.Text = r["total_biometricos"].ToString();
            lblCantMarcacionesHoy.Text = r["marcaciones_hoy"].ToString();
            lblCantMarcacionesMes.Text = r["marcaciones_mes"].ToString();

            long hoy = Convert.ToInt64(r["marcaciones_hoy"]);
            long ayer = Convert.ToInt64(r["marcaciones_ayer"]);

            if (ayer > 0)
            {
                double variacion = ((double)(hoy - ayer) / ayer) * 100;
                string signo = variacion >= 0 ? "▲" : "▼";
                lblVariacionHoy.Text = $"{signo} {Math.Abs(variacion):F0}% vs ayer";
                lblVariacionHoy.ForeColor = variacion >= 0 ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);
            }
            else
            {
                lblVariacionHoy.Text = ayer == 0 && hoy > 0 ? "▲ Nuevo día" : "Sin datos de ayer";
                lblVariacionHoy.ForeColor = Color.WhiteSmoke;
            }
        }

        private void RedibujarGraficas()
        {
            pnlGraficaDias?.Invalidate();
            pnlGraficaHora?.Invalidate();
            pnlGraficaDept?.Invalidate();
            pnlGraficaBio?.Invalidate();
        }

        // Gráfica 1 (Top-Left): Marcaciones por Día (Últimos 7 días)
        private void pnlGraficaDias_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_dsEstadisticas == null || !_dsEstadisticas.Tables.Contains("PorDia") || _dsEstadisticas.Tables["PorDia"].Rows.Count == 0)
            {
                DibujarSinDatos(g, panel, "Marcaciones últimos 7 días");
                return;
            }

            DataTable dt = _dsEstadisticas.Tables["PorDia"];
            Color colorPrimario = UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(52, 152, 219);
            Color colorSecundario = ColorEditor.Darken(colorPrimario, 15);

            DibujarGraficaBarras(g, panel, dt, "dia", "total",
                "Marcaciones por Día (Últimos 7 días)",
                colorPrimario,
                colorSecundario,
                formatearEje: (val) => DateTime.TryParse(val, out DateTime dt2) ? dt2.ToString("dd/MM") : val);
        }

        // Gráfica 2 (Top-Right): Picos de Marcaciones por Hora de Hoy
        private void pnlGraficaHora_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_dsEstadisticas == null || !_dsEstadisticas.Tables.Contains("PorHora") || _dsEstadisticas.Tables["PorHora"].Rows.Count == 0)
            {
                DibujarSinDatos(g, panel, "Picos de Marcaciones Hoy (por Hora)");
                return;
            }

            DataTable dt = _dsEstadisticas.Tables["PorHora"];
            Color colorBarra = Color.FromArgb(243, 156, 18);
            Color colorBarraOscuro = Color.FromArgb(211, 84, 0);

            DibujarGraficaBarras(g, panel, dt, "hora", "total",
                "Picos de Marcaciones Hoy (por Hora)",
                colorBarra,
                colorBarraOscuro);
        }

        // Gráfica 3 (Bottom-Left): Empleados por Departamento
        private void pnlGraficaDept_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_dsEstadisticas == null || !_dsEstadisticas.Tables.Contains("PorDepartamento") || _dsEstadisticas.Tables["PorDepartamento"].Rows.Count == 0)
            {
                DibujarSinDatos(g, panel, "Empleados por Departamento");
                return;
            }

            DataTable dt = _dsEstadisticas.Tables["PorDepartamento"];
            Color[] colores = {
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(142, 68, 173),
                Color.FromArgb(52, 73, 94),
                Color.FromArgb(44, 62, 80),
                Color.FromArgb(22, 160, 133),
                Color.FromArgb(39, 174, 96),
                Color.FromArgb(230, 126, 34),
                Color.FromArgb(192, 57, 43),
                Color.FromArgb(41, 128, 185),
                Color.FromArgb(52, 152, 219)
            };

            DibujarGraficaBarrasHorizontales(g, panel, dt, "departamento", "total_empleados",
                "Empleados por Departamento", colores);
        }

        // Gráfica 4 (Bottom-Right): Marcaciones por Biométrico / Dispositivo
        private void pnlGraficaBio_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_dsEstadisticas == null || !_dsEstadisticas.Tables.Contains("PorBiometrico") || _dsEstadisticas.Tables["PorBiometrico"].Rows.Count == 0)
            {
                DibujarSinDatos(g, panel, "Marcaciones por Biométrico (Este Mes)");
                return;
            }

            DataTable dt = _dsEstadisticas.Tables["PorBiometrico"];
            Color[] coloresBio = {
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(26, 188, 156),
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(241, 196, 15)
            };

            DibujarGraficaBarrasHorizontales(g, panel, dt, "biometrico", "total_marcaciones",
                "Marcaciones por Biométrico (Este Mes)", coloresBio);
        }

        private void DibujarGraficaBarras(Graphics g, Panel panel, DataTable dt,
            string colEje, string colValor, string titulo,
            Color colorBarra, Color colorBarraOscuro,
            Func<string, string> formatearEje = null)
        {
            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            int W = panel.Width;
            int H = panel.Height;
            int marginLeft = 45;
            int marginRight = 15;
            int marginTop = 35;
            int marginBottom = 40;

            Color fondoPanel = esOscuro ? Color.FromArgb(24, 28, 45) : Color.White;
            Color colorTitulo = esOscuro ? Color.White : Color.FromArgb(30, 41, 59);
            Color colorEje = esOscuro ? Color.FromArgb(160, 175, 200) : Color.FromArgb(100, 116, 139);
            Color colorLineas = esOscuro ? Color.FromArgb(60, 60, 80) : Color.FromArgb(226, 232, 240);
            Color colorTextoVal = esOscuro ? Color.White : Color.FromArgb(30, 41, 59);

            g.Clear(fondoPanel);

            if (!esOscuro)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, W - 1, H - 1);
                }
            }

            using (Font fTitulo = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (Font fEje = new Font("Segoe UI", 7.5f))
            using (Font fValor = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            using (SolidBrush brushTitulo = new SolidBrush(colorTitulo))
            using (SolidBrush brushEje = new SolidBrush(colorEje))
            using (SolidBrush brushValor = new SolidBrush(colorTextoVal))
            {
                g.DrawString(titulo, fTitulo, brushTitulo, marginLeft, 10);

                int rows = dt.Rows.Count;
                if (rows == 0) return;

                long maxVal = 1;
                foreach (DataRow row in dt.Rows)
                    if (Convert.ToInt64(row[colValor]) > maxVal) maxVal = Convert.ToInt64(row[colValor]);

                int chartW = W - marginLeft - marginRight;
                int chartH = H - marginTop - marginBottom;
                if (chartW <= 0 || chartH <= 0) return;

                int barWidth = Math.Max(8, chartW / rows - 8);

                using (Pen gridPen = new Pen(colorLineas, 1f) { DashStyle = DashStyle.Dot })
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        int y = marginTop + (int)(chartH * i / 3.0);
                        g.DrawLine(gridPen, marginLeft, y, W - marginRight, y);
                        long label = maxVal - (maxVal * i / 3);
                        g.DrawString(label.ToString(), fEje, brushEje, 5, y - 6);
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    long val = Convert.ToInt64(dt.Rows[i][colValor]);
                    string eje = dt.Rows[i][colEje].ToString();
                    if (formatearEje != null) eje = formatearEje(eje);

                    int barH = maxVal > 0 ? (int)(chartH * val / (double)maxVal) : 0;
                    int x = marginLeft + i * (chartW / rows) + (chartW / rows - barWidth) / 2;
                    int y = marginTop + chartH - barH;

                    using (LinearGradientBrush brGrad = new LinearGradientBrush(
                        new Rectangle(x, y, barWidth, Math.Max(barH, 1) + 1),
                        colorBarra, colorBarraOscuro, LinearGradientMode.Vertical))
                    {
                        if (barH > 0)
                        {
                            g.FillRectangle(brGrad, x, y, barWidth, barH);
                            g.DrawRectangle(new Pen(ColorEditor.Darken(colorBarra, 10), 1), x, y, barWidth, barH);
                        }
                    }

                    if (val > 0)
                        g.DrawString(val.ToString(), fValor, brushValor, x + barWidth / 2 - 6, y - 14);

                    g.TranslateTransform(x + barWidth / 2, H - marginBottom + 4);
                    g.RotateTransform(-30);
                    g.DrawString(eje, fEje, brushEje, 0, 0);
                    g.ResetTransform();
                }
            }
        }

        private void DibujarGraficaBarrasHorizontales(Graphics g, Panel panel, DataTable dt,
            string colEje, string colValor, string titulo, Color[] colores)
        {
            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            int W = panel.Width;
            int H = panel.Height;
            int marginLeft = 125;
            int marginRight = 45;
            int marginTop = 35;
            int marginBottom = 10;

            Color fondoPanel = esOscuro ? Color.FromArgb(24, 28, 45) : Color.White;
            Color colorTitulo = esOscuro ? Color.White : Color.FromArgb(30, 41, 59);
            Color colorEje = esOscuro ? Color.FromArgb(200, 210, 235) : Color.FromArgb(51, 65, 85);
            Color colorTextoVal = esOscuro ? Color.White : Color.FromArgb(30, 41, 59);

            g.Clear(fondoPanel);

            if (!esOscuro)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, W - 1, H - 1);
                }
            }

            using (Font fTitulo = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (Font fEje = new Font("Segoe UI", 7.5f))
            using (Font fValor = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            using (SolidBrush brushTitulo = new SolidBrush(colorTitulo))
            using (SolidBrush brushEje = new SolidBrush(colorEje))
            using (SolidBrush brushValor = new SolidBrush(colorTextoVal))
            {
                g.DrawString(titulo, fTitulo, brushTitulo, 10, 10);

                int rows = Math.Min(dt.Rows.Count, 6);
                if (rows == 0) return;

                long maxVal = 1;
                for (int i = 0; i < rows; i++)
                    if (Convert.ToInt64(dt.Rows[i][colValor]) > maxVal) maxVal = Convert.ToInt64(dt.Rows[i][colValor]);

                int chartW = W - marginLeft - marginRight;
                int chartH = H - marginTop - marginBottom;
                if (chartW <= 0 || chartH <= 0) return;

                int barHeight = Math.Max(6, chartH / rows - 6);

                for (int i = 0; i < rows; i++)
                {
                    long val = Convert.ToInt64(dt.Rows[i][colValor]);
                    string eje = dt.Rows[i][colEje].ToString();
                    if (eje.Length > 16) eje = eje.Substring(0, 14) + "..";

                    int y = marginTop + i * (chartH / rows) + (chartH / rows - barHeight) / 2;
                    int barW = maxVal > 0 ? (int)(chartW * val / (double)maxVal) : 0;

                    g.DrawString(eje, fEje, brushEje, 8, y + barHeight / 2 - 6);

                    Color c = colores[i % colores.Length];
                    using (LinearGradientBrush br = new LinearGradientBrush(
                        new Rectangle(marginLeft, y, Math.Max(barW, 1), barHeight),
                        c, ColorEditor.Darken(c, 15), LinearGradientMode.Horizontal))
                    {
                        if (barW > 0)
                            g.FillRectangle(br, marginLeft, y, barW, barHeight);
                    }

                    g.DrawString(val.ToString(), fValor, brushValor, marginLeft + barW + 6, y + barHeight / 2 - 6);
                }
            }
        }

        private void DibujarSinDatos(Graphics g, Panel panel, string titulo)
        {
            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            Color fondoPanel = esOscuro ? Color.FromArgb(24, 28, 45) : Color.White;
            Color colorTitulo = esOscuro ? Color.White : Color.FromArgb(30, 41, 59);

            g.Clear(fondoPanel);
            using (Font f = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(colorTitulo))
                g.DrawString(titulo, f, b, 10, 10);

            using (Font f2 = new Font("Segoe UI", 8f))
            using (SolidBrush b2 = new SolidBrush(Color.Gray))
                g.DrawString("Sin datos disponibles para el período.", f2, b2,
                    panel.Width / 2 - 80, panel.Height / 2 - 8);
        }
    }
}
