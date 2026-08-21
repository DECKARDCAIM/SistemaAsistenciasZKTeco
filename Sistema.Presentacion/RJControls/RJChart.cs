using RJCodeUI_M1.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace RJCodeUI_M1.RJControls
{
    public class RJChart : Chart
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "Chart"/>.
        /// Este control simplemente establece los colores de la configuración de apariencia.
        /// </summary>
        /// 

        #region -> Constructor
        public RJChart()
        {
            
        }
        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {
            this.BackColor = UIAppearance.ItemBackgroundColor;//Establecer color de fondo

            foreach (var serie in this.Series) //Establecer la apariencia de las series
            {
                if (serie.ChartType == SeriesChartType.Doughnut || serie.ChartType == SeriesChartType.Pie)
                {
                    serie.LabelForeColor = Color.White;
                    serie.BorderWidth = 1;
                    serie.BorderColor = UIAppearance.ItemBackgroundColor;
                }
                else
                {
                    serie.LabelForeColor = UIAppearance.TextColor;
                }
            }
            foreach (var chartArea in this.ChartAreas)//Establecer la apariencia para las áreas del gráfico
            {
                chartArea.BackColor = UIAppearance.ItemBackgroundColor;//Establecer el color de fondo del área del gráfico
                //Eje X del gráfico de áreas
                chartArea.AxisX.LabelStyle.ForeColor = UIAppearance.TextColor;//Color de texto
                chartArea.AxisX.LineColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 30);//Color de linea
                chartArea.AxisX.LineWidth = 2;//Ancho de la linea
                chartArea.AxisX.MajorTickMark.LineColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 30);//Color de línea de marca de graduación principal
                chartArea.AxisX.MajorTickMark.LineWidth = 2;//Ancho de línea de la marca de graduación principal
                chartArea.AxisX.MajorGrid.LineColor = UIAppearance.ItemBackgroundColor;//Color de la línea de cuadrícula principal
                chartArea.AxisX.MinorGrid.LineColor = UIAppearance.ActiveBackgroundColor;//Color de línea de cuadrícula menor

                //Eje Y del gráfico de áreas
                chartArea.AxisY.LabelStyle.ForeColor = UIAppearance.TextColor;//Color de texto
                chartArea.AxisY.LineColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 30);//Color de linea
                chartArea.AxisY.LineWidth = 2;//Ancho de la linea
                chartArea.AxisY.MajorTickMark.LineColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 30);//Color de línea de marca de graduación principal
                chartArea.AxisY.MajorTickMark.LineWidth = 2;//Ancho de línea de la marca de graduación principal
                chartArea.AxisY.MajorGrid.LineColor = UIAppearance.ActiveBackgroundColor;//Color de la línea de cuadrícula principal
                chartArea.AxisY.MinorGrid.LineColor = UIAppearance.ActiveBackgroundColor;//Color de línea de cuadrícula menor

            }
            foreach (var legend in this.Legends) //Establecer colores para leyendas
            {
                legend.BackColor = UIAppearance.ItemBackgroundColor;
                legend.ForeColor = UIAppearance.TextColor;
                legend.Font = new Font(legend.Font.FontFamily, 8.5F);
            }
            foreach (var title in this.Titles) //Establecer colores para títulos
            {
                if (UIAppearance.Theme == UITheme.Dark)
                    title.ForeColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 30);
                else title.ForeColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 10);
                title.Font = new Font("Verdana", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                title.Alignment = ContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region -> Métodos anulados
        protected override void OnHandleCreated(EventArgs e)
        {   // Anular el evento OnHandleCreated, ocurre cuando se crea un identificador,
            // este evento es el que más se parece al evento de carga.

            base.OnHandleCreated(e);
            ApplyAppearanceSettings();//Aplicar configuraciones de apariencia
        }
        #endregion
    }
}
