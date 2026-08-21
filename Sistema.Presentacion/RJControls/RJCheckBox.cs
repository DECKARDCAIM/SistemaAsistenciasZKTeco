using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using System.Drawing.Drawing2D;

namespace RJCodeUI_M1.RJControls
{
    public class RJCheckBox : CheckBox
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "CheckBox" />
        /// Puede cambiar el estilo del botón a vidrioso o sólido (<see cref = "ControlStyle Style" />).
        /// Además de poder personalizar los colores del fondo, borde, icono, etc.
        /// siempre que la propiedad personalizable se establezca en true.
        /// Tutorial guia: https://www.youtube.com/watch?v=SAA5qDoiL4M 
        /// </summary>       
        /// 

        #region -> Campos

        private bool customizable = false;//Obtiene o establece si el control es personalizable.
        private ControlStyle style = ControlStyle.Glass;//Obtiene o establece el estilo CheckBox (Glass o Solid).      
        private int borderSize = 1;//Obtiene  o establece el tamaño de borde.
        private Color borderColor = UIAppearance.StyleColor; //Obtiene o establece el color de borde.
        private IconPictureBox CheckIcon;//Obtiene o establece el icono de casilla de verificación marcado.

        ///<Note>:ICON PICTURE BOX es proporcionado por la libreria <see cref = "FontAwesome.Sharp" />
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp </Note>
        #endregion

        #region -> Constructor

        public RJCheckBox()
        {
            CheckIcon = new IconPictureBox();//Inicializar icono de verificación.
            CheckIcon.IconChar = IconChar.Check;//Establecer icono.
            CheckIcon.IconSize = 19;
            CheckIcon.IconColor = UIAppearance.StyleColor;
            this.Cursor = Cursors.Hand;
            this.Checked = true;
            this.Font = new Font(UIAppearance.TextFamilyName, UIAppearance.TextSize);
            this.ForeColor = UIAppearance.TextColor;
            this.MinimumSize = new Size(0, 21);
            //Establecer un Padding de 10 hacia la izquierda para aumentar el ancho del control, para que el icono y el texto encajen y se muestren por completo.
            this.Padding = new Padding(10, 0, 0, 0);
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Obtiene o Establece el estilo CheckBox (Glass o Solid)")]
        public ControlStyle Style
        {
            get { return style; }
            set
            {
                style = value;//Establecer valor
                this.Image = null;//Eliminar icono de verificación (cuando cambia el estilo, la imagen de checkIcon cambia, luego la imagen es obsoleta, vea los códigos del siguiente método)
                ApplyAppearanceSettings();//Actualiza o aplica la configuración de apariencia.
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el ancho del borde")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value > 0)//El valor debe ser mayor a 0.
                    borderSize = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene a establece si la casilla de verificación está marcada")]
        public bool Check
        {
            get { return this.Checked; }
            set { this.Checked = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores de apariencia del control son personalizables, de lo contrario, el color de apariencia se establece segun la configuración de apariencia.")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del borde.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del icono de verificación.")]
        public Color IconColor
        {
            get { return CheckIcon.IconColor; }
            set
            {
                CheckIcon.IconColor = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        #endregion

        #region -> Métodos privados

        private void ApplyAppearanceSettings()
        {//Aplicar la configuración de apariencia siempre que la propiedad personalizable esté establecida en falso.
            if (customizable == false)
            {
                borderColor = UIAppearance.StyleColor;
                this.ForeColor = UIAppearance.TextColor;
                if (style == ControlStyle.Solid)
                    IconColor = Color.White;
                else
                    IconColor = UIAppearance.StyleColor;
            }
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnPaint(PaintEventArgs pevent)
        {//Este método se encarga de anular completamente la pintura y dibujar un nuevo control con un apariencia personalizada.

            //Campos
            Graphics graphics = pevent.Graphics; //Objeto de graficos.         
            int cbSize = 18; //Tamaño de la casilla de verificación.
            int checkIconSize = CheckIcon.IconSize;//Tamaño del icono de la casilla de verificación.
            Rectangle rectCheckBox = new Rectangle()//Dimensiones de la casilla de verificación.
            {
                X = 1,
                Y = (this.Height - cbSize) / 2, //Centrado
                Width = cbSize,
                Height = cbSize
            };
            Rectangle rectCheckIcon = new Rectangle()//Dimensiones del icono de la casilla de verificación.
            {
                X = rectCheckBox.X + ((rectCheckBox.Width - checkIconSize) / 2) + 1, //Centrado
                Y = ((this.Height - checkIconSize) / 2) + 2, //Centrado
                Width = checkIconSize,
                Height = checkIconSize
            };

            //Dibujo
            using (Pen penRbBorder = new Pen(borderColor, borderSize))//Boligrafo para dibujar el borde.
            using (SolidBrush brushRbFill = new SolidBrush(borderColor))//Pincel para dibujar el relleno de la casilla.
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))//Pincel para dibujar el texto.
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavisado.
                //Dibujar la superficie del control
                graphics.Clear(this.BackColor);
                //Dibujar la casilla de verificación
                if (this.Checked)//Estado marcado.
                {
                    if (style == ControlStyle.Solid)
                        graphics.FillRectangle(brushRbFill, rectCheckBox);//Relleno de la casilla
                    graphics.DrawRectangle(penRbBorder, rectCheckBox);//Borde de la casilla
                    graphics.DrawImage(CheckIcon.Image, rectCheckIcon);//Icono de la casilla
                }
                else//Estado no marcado.
                {
                    graphics.DrawRectangle(penRbBorder, rectCheckBox);//Borde de la casilla                 
                }
                //Dibujar el texto
                graphics.DrawString(this.Text, this.Font, brushText,
                    cbSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Centrado
            }
        }

        #endregion  

    }
}
