using RJCodeUI_M1.Settings;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    public class RJCircularPictureBox : PictureBox
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "PictureBox" />
        /// Este control personalizado crea un cuadro de imagen circular, donde permite cambiar el tamaño de borde,
        /// color del borde, estilo de linea, estilo de tapa, activar color degradado del borde, 
        /// y finalmente establecer el angulo del degradado.
        /// Tutorial guía: https://youtu.be/54347QjDisA
        /// </summary>
        /// 

        #region -> Campos
        private int borderSize = 2; //Obtiene o estable el tamaño de borde
        private Color borderColor = Color.RoyalBlue; //Obtiene o estable el color del borde.
        private Color borderColor2 = Color.HotPink; //Obtiene o estable el segundo color del borde para aplicar un color degradado.
        private DashStyle borderLineStyle = DashStyle.Solid; //Obtiene o estable el estilo de linea del borde.
        private DashCap borderCapStyle = DashCap.Flat; //Obtiene o estable el estilo de tapa del borde en el estilo entrecortado(Dash).
        private bool gradientColor = false;//Obtiene o estable si el color del borde es degradado.
        private float gradientAngle = 50F; //Obtiene o estable el angulo del degradado.
        private bool customizable = true; //Obtiene o estable si el color del borde es personalizable, o el color es igual al color establecido en la configuracion de apariencia.
        #endregion

        #region -> Constructor
        public RJCircularPictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region -> Propiedades
        [Category("RJ Code Advance")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor2
        {
            get { return borderColor2; }
            set
            {
                borderColor2 = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashStyle BorderLineStyle
        {
            get { return borderLineStyle; }
            set
            {
                borderLineStyle = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashCap BorderCapStyle
        {
            get { return borderCapStyle; }
            set
            {
                borderCapStyle = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool GradientColor
        {
            get { return gradientColor; }
            set
            {
                gradientColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                this.Invalidate();
            }
        }
        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {
            if (customizable == false)//Si no es personalizable, aplicar la configuración de color de la apariencia.
            {
                borderColor = UIAppearance.StyleColor;
                borderColor2 = UIAppearance.PrimaryStyleColor;
            }
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();//Aplicar la configuración de apariencia de la interfaz de usuario
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Establecer un mismo valor para el ancho y alto del tamaño para que el control tenga una forma circular perfecta.
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //Campos
            var graph = pe.Graphics;//Objeto de graficos.
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);//Rectángulo para las dimensiones del suavizado de contorno y region redondeado del control.
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize); //Rectángulo para las dimensiones del borde.
            var rectBorderSmooth = RectangleF.Inflate(rectBorder, 0.5F, 0.5F);
            var smoothSize = borderSize > 0 ? borderSize : 1; //Tamaño de suavizado, Si el tamaño de borde es mayor a 0, el tamaño de suavizado es igual al tamaño del borde, caso contrario, el valor es 1.
            using (var pathRegion = new GraphicsPath())//Objeto de ruta de gráficos para la region del control.
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))//Objeto bolígrafo para dibujar el suavizado de contorno.
            using (var penBorder = new Pen(borderColor, borderSize)) //Objeto bolígrafo para dibujar el borde del control.
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavizado del objeto de gráficos.
                penBorder.DashStyle = borderLineStyle; //Establecer el estilo de linea del borde.
                penBorder.DashCap = borderCapStyle; //Establecer el estilo de tapa de la linea (Guion o Punto).
                pathRegion.AddEllipse(rectContourSmooth); //Agregar una elipse en la ruta de la region con las dimensiones del rectangulo definido anteriormente.
                //Establecer la region redondeada del control.
                this.Region = new Region(pathRegion);

                //Dibujo
                graph.DrawEllipse(penSmooth, rectContourSmooth);//Dibujar el suavizado de contorno.
                if (borderSize > 0) 
                {
                    graph.DrawEllipse(penSmooth, rectBorderSmooth);//Dibujar el suavizado del borde
                    if (gradientColor)//Dibujar el borde de color degradado.
                    {
                        using (var bGradientColor = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle))
                        {
                            penBorder.Brush = bGradientColor;
                            graph.DrawEllipse(penBorder, rectBorder);
                        }
                    }
                    //Dibujar el borde de color solido, un solo color.
                    else graph.DrawEllipse(penBorder, rectBorder);
                }
            }
        }
        #endregion
    }
}
