using RJCodeUI_M1.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    public class RJToggleButton : CheckBox
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "CheckBox" />.
        /// Este control anula completamente el evento de pintura y se dibuja un nuevo diseño 
        /// del control ToggleButton con los colores asignados en la configuración de apariencia, permite
        /// cambiar el estilo a sólido o vidrio.
        ///
        /// Los dibujos ocurren en el siguiente orden:
        /// 1.- Se dibuja el fondo de la superficie de control.
        /// 2.- Se dibuja el borde (estilo vidrio) o fondo (estilo sólido) del botón de alternancia.
        /// 3.- Se tira de la palanca del botón de palanca (ON u OFF).
        /// 4.- Se dibuja el texto.
        ///
        /// Expone todas las funcionalidades (propiedades, Métodos y eventos del control checkbox)
        /// y se agregan nuevas propiedades para personalizar el control de la palanca de activación.
        /// Tutorial guia: https://www.youtube.com/watch?v=m7Iv6xfjnuw&t
        /// </summary>
        /// 

        #region -> Campos

        private ControlStyle style;//Obtiene o establece el estilo CheckBox (Glass o Solid)

        private Color onBackBorderColor = Color.MediumSlateBlue;//Obtiene o establece el color de fondo o borde en el estado activado.
        private Color onToggleColor = Color.White;//Obtiene o establece el color de alternancia en el estado activado.
        private Color onTextColor = Color.White;//Obtiene o establece el color del texto en el estado activado.
        private string onText;//Obtiene o establece el texto en estado activado.

        private Color offBackBorderColor = Color.LightGray;//Obtiene o establece el color de fondo o borde en el estado desactivado.
        private Color offToggleColor = Color.Gray;//Obtiene o establece el color de alternancia en el estado desactivado.
        private Color offTextColor = Color.Gray;//Obtiene o establece el color del texto en estado desactivado.
        private string offText;//Obtiene o establece el texto en estado desactivado.

        private bool customizable;//Obtiene o establece si el color de control es personalizable o los colores están establecidos según la configuración de apariencia

        #endregion

        #region -> Constructor

        public RJToggleButton()
        {
            this.MinimumSize = new Size(50, 25);
            Activated = true;//Establecer valor inicial    
            Style = ControlStyle.Glass;
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        public string ON_Text
        {//Obtiene o establece el texto para el estado activado
            get { return onText; }
            set
            {
                onText = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))               
            }
        }

        [Category("RJ Code Advance")]
        public string OFF_Text
        {//Obtiene o establece el texto para el estado desactivado
            get { return offText; }
            set
            {
                offText = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))    
            }
        }

        [Category("RJ Code Advance")]
        public ControlStyle Style
        { //Establece u obtiene el estilo del botón de alternancia (vidrio o sólido)
            get { return style; }
            set
            {
                style = value;//Establecer valor           
                ApplyAppearanceSettings();//Actualizar la configuración de apariencia.
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))  

            }
        }

        [Category("RJ Code Advance")]
        public bool Activated
        {// establece u obtiene si el botón de alternancia está activado o desactivado.
            // este valor está determinado por la propiedad marcada de la casilla de verificación
            // ya que ambos tienen un solo valor: Checked o UnChecked - ON u OFF = verdadero o falso.
            get { return this.Checked; }
            set
            {
                this.Checked = value;
            }
        }

        [Category("RJ Code Advance")]
        public bool Customizable
        {//Obtiene o establece si el color de control es personalizable o los colores están establecidos por la configuración de apariencia
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        public Color ON_BackBorderColor
        {//Obtiene o establece el color de fondo o borde del estado activado.
            get { return onBackBorderColor; }
            set
            {
                onBackBorderColor = value;
                this.Invalidate();//(See OnPaint(PaintEventArgs e) method)
            }
        }

        [Category("RJ Code Advance")]
        public Color ON_ToggleColor
        {//Obtiene o establece el color de alternancia para el estado activado.
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))   
            }
        }

        [Category("RJ Code Advance")]
        public Color ON_TextColor
        {//Obtiene o establece el color del texto del estado activado.
            get { return onTextColor; }
            set
            {
                onTextColor = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))   
            }
        }

        [Category("RJ Code Advance")]
        public Color OFF_BackBorderColor
        {//Obtiene o establece el color de fondo o del borde para el estado desactivado.
            get { return offBackBorderColor; }
            set
            {
                offBackBorderColor = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))   
            }
        }

        [Category("RJ Code Advance")]
        public Color OFF_ToggleColor
        {//Obtiene o establece el color de alternancia para el estado desactivado.
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))   
            }
        }

        [Category("RJ Code Advance")]
        public Color OFF_TextColor
        {//Obtiene o establece el color del texto para el estado desactivado.
            get { return offTextColor; }
            set
            {
                offTextColor = value;
                this.Invalidate();//Redibujar el control (Consulte el método OnPaint(PaintEventArgs e))   
            }
        }

        [Category("RJ Code Advance")]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        public override string Text
        {//Anular propiedad de texto
            get { return base.Text; }
            set { base.Text = "#"; }
        }

        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {//Aplicar la configuración de apariencia siempre que no sea personalizable

            if (customizable == false)
            {

                if (UIAppearance.Theme == UITheme.Light) //Establecer colores de tema LIGHT
                {
                    if (style == ControlStyle.Solid)//Estilo sólido.
                    {
                        onBackBorderColor = UIAppearance.StyleColor;
                        onToggleColor = Color.White;
                        onTextColor = Color.WhiteSmoke;

                        offBackBorderColor = Color.LightGray;
                        offToggleColor = Color.White;
                        offTextColor = Color.Gray;
                    }
                    else //Estilo vidrio
                    {

                        onBackBorderColor = UIAppearance.StyleColor;
                        onToggleColor = UIAppearance.StyleColor;

                        onTextColor = UIAppearance.TextColor;

                        offBackBorderColor = Color.FromArgb(171, 171, 171);
                        offToggleColor = Color.FromArgb(171, 171, 171);
                        offTextColor = Color.Gray;
                    }

                }
                else //Establecer colores de tema OSCURO
                {

                    onBackBorderColor = UIAppearance.StyleColor;

                    if (style == ControlStyle.Solid)
                    {
                        onToggleColor = RJColors.DarkItemBackground;
                        onTextColor = Color.Gainsboro;
                    }
                    else
                    {
                        onToggleColor = UIAppearance.StyleColor;
                        onTextColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 20);
                    }

                    offBackBorderColor = RJColors.DarkActiveBackground;
                    offToggleColor = Color.FromArgb(110, 104, 153);
                    offTextColor = UIAppearance.TextColor;
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect)
        {//Este método se encarga de hacer la ruta de la figura del ToggleButton.
            int arcSize = rect.Height;//Tamaño del arco.
            Rectangle leftArc = new Rectangle(rect.X, rect.Y, arcSize, arcSize);//Arco izquierdo
            Rectangle rightArc = new Rectangle(rect.Width - arcSize, rect.Y, arcSize, arcSize); //Arco derecho

            GraphicsPath path = new GraphicsPath();//Objeto GraphicsPath
            path.StartFigure();//Empezar la figura
            path.AddArc(leftArc, 90, 180); //Agregar el arco izquierdo en el angulo 90 grados con un recorrido de 180 grados.
            path.AddArc(rightArc, 270, 180);//Agregar el arco derecho en el angulo 270 grados con un recorrido de 180 grados.
            path.CloseFigure();//Finalizar la figura

            return path;//Retornar la ruta de la figura.
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnPaint(PaintEventArgs pevent)
        {//Este metodo anula completamente la pintura y se vuelve a dibujar un nuevo diseño y apariencia del control.

            //CAMPOS
            Graphics graph = pevent.Graphics;   //Objeto de graficos       
            Rectangle tbRect = Rectangle.Inflate(this.ClientRectangle, -2, -2); //Dimensiones para el toggle button.
            float toggleSize = tbRect.Height - 4.8F;//Tamaño de la palanca.
            RectangleF rectOffToggle = new RectangleF()//Dimensiones para la palanca en estado apagado.
            {
                X = tbRect.X + ((tbRect.Height - toggleSize) / 2),
                Y = tbRect.Y + ((tbRect.Height - toggleSize) / 2),
                Width = toggleSize,
                Height = toggleSize
            };
            RectangleF rectOnToggle = new RectangleF()//Dimensiones para la palanca en estado encendido.
            {
                X = tbRect.Width - toggleSize - ((tbRect.Height - toggleSize) / 2),
                Y = tbRect.Y + ((tbRect.Height - toggleSize) / 2),
                Width = toggleSize,
                Height = toggleSize
            };

            //DIBUJO
            using (GraphicsPath path = GetFigurePath(tbRect))//Obtener la ruta de la figura
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavizado.

                //Dibujar la superfice
                graph.Clear(this.Parent.BackColor);

                //Dibujar el toggle button en estado encendido.
                if (this.Checked) //ON
                {
                    //Dibujar el fondo del toggle button
                    if (style == ControlStyle.Solid)
                        graph.FillPath(new SolidBrush(onBackBorderColor), path);
                    else graph.DrawPath(new Pen(onBackBorderColor, 2), path);
                    //Dibujar la palanca
                    graph.FillEllipse(new SolidBrush(onToggleColor), rectOnToggle);
                    //Dibujar el texto - Centrado
                    if (onText != "" || onText != null)
                        graph.DrawString(onText, this.Font, new SolidBrush(onTextColor),
                        ((tbRect.Right - TextRenderer.MeasureText(onText, this.Font).Width) / 2) - (toggleSize / 2),
                          ((this.Height - TextRenderer.MeasureText(onText, this.Font).Height) / 2));
                }
                //Dibujar el toggle button en estado apagado.
                else //OFF
                {
                    //Dibujar el fondo del toggle button
                    if (style == ControlStyle.Solid)
                        graph.FillPath(new SolidBrush(offBackBorderColor), path);
                    else pevent.Graphics.DrawPath(new Pen(offBackBorderColor, 2), path);
                    //Dibujar la palanca
                    graph.FillEllipse(new SolidBrush(offToggleColor), rectOffToggle);
                    //Dibujar el texto - Centrado
                    if (offText != "" || offText != null)
                        graph.DrawString(offText, this.Font, new SolidBrush(offTextColor),
                          ((tbRect.Right - TextRenderer.MeasureText(onText, this.Font).Width) / 2) + (toggleSize / 2),
                          ((this.Height - TextRenderer.MeasureText(onText, this.Font).Height) / 2));

                }
            }
        }
        #endregion

    }
}
