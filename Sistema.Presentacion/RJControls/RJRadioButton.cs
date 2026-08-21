using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;

namespace RJCodeUI_M1.RJControls
{
    public class RJRadioButton : RadioButton
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "RadioButton" />.
        /// este control anula completamente el evento de pintura y se dibuja un nuevo diseño
        /// de botón de radio con los colores asignados en la configuración de apariencia. 
        /// 
        /// Los dibujos ocurren en el siguiente orden:
        ///     1.- Se dibuja el fondo de la superficie de control.
        ///     2.- Se dibuja el texto.
        ///     3.- Se dibuja el borde del botón de radio.
        ///     4.- Se dibuja el fondo del botón de radio.
        ///     5.- Se dibuja la marca de verificación del botón de radio.
        ///Tutorial guia: https://www.youtube.com/watch?v=SAA5qDoiL4M
        /// </summary>
        /// 

        #region -> Campos
        private Color checkedColor = UIAppearance.StyleColor; //Obtiene o establece el color del estado marcado.
        private Color unCheckedColor = RJColors.Cancel;//Obtiene o establece el color del estado desmarcado.
        private Color fillColor = UIAppearance.ItemBackgroundColor;//Obtiene o establece el color de relleno circular del radio button.
        private bool customizable = false;//Obtiene o establece si los colores del control es personalizable.
        #endregion

        #region -> Propiedades
        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores del control es personalizable.")]
        public bool Customizable
        {
            get { return customizable; }
            set
            {
                customizable = value;
                if (this.DesignMode)
                {
                    ApplyApperanceSettings();
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores del control es personalizable.")]
        public Color CheckedColor
        {
            get { return checkedColor; }
            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores del control es personalizable.")]
        public Color UnCheckedColor
        {
            get { return unCheckedColor; }
            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region -> Constructor
        public RJRadioButton()
        {
            this.MinimumSize = new Size(0, 21);
            this.Font = new Font("Verdana", UIAppearance.TextSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Cursor = Cursors.Hand;
            //Establecer un Padding de 10 hacia la izquierda para aumentar el ancho del control, para que el icono y el texto encajen y se muestren por completo.
            this.Padding = new Padding(10, 0, 0, 0);
        }
        #endregion

        #region -> Métodos privados
        private void ApplyApperanceSettings()
        {
            if (customizable == false)
            {
                checkedColor = UIAppearance.StyleColor;
                unCheckedColor = RJColors.Cancel;
                this.ForeColor = UIAppearance.TextColor;
                if (UIAppearance.Theme == UITheme.Light)
                    fillColor = Utils.ColorEditor.Lighten(UIAppearance.BackgroundColor, 15);
                else fillColor = Utils.ColorEditor.Darken(UIAppearance.BackgroundColor, 3);
            }           
        }
        #endregion

        #region -> Métodos anulados
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyApperanceSettings();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {//Este método se encarga de anular completamente la pintura y dibujar un nuevo control con un apariencia personalizada.

            //Campos
            Graphics graphics = pevent.Graphics;//Objeto de graficos.                 
            int rbSize = 18;//Tamaño del radio button.
            int rbCheckSize = 12;//Tamaño del icono de marcado del radio button.
            Rectangle rectRadioButton = new Rectangle()//Dimensiones del radio button.
            {
                X = 1,
                Y = (this.Height - rbSize) / 2, //Centrado
                Width = rbSize,
                Height = rbSize
            };
            Rectangle rectRbCheck = new Rectangle()//Dimensiones del icono de marcado del radio button.
            {
                X = rectRadioButton.X + ((rectRadioButton.Width - rbCheckSize) / 2), //Centrado
                Y = (this.Height - rbCheckSize) / 2, //Centrado
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            if (customizable && this.Parent != null)//Establecer el color de fondo si el control es personalizable.
            {
                if (UIAppearance.Theme == UITheme.Light)
                    fillColor = Utils.ColorEditor.Lighten(this.Parent.BackColor, 10);
                else fillColor = Utils.ColorEditor.Darken(this.Parent.BackColor, 3);
            }

            //Drawing
            using (Pen penRbBorder = new Pen(checkedColor, 1.5F))//Boligrafo para dibujar el borde.
            using (SolidBrush brushRbFill = new SolidBrush(fillColor))//Pincel para dibujar el relleno circular.
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))//Pincel para dibujar el icono de marcado.
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))//Pincel para dibujar el texto.
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavisado.

                //Dibujar la superficie del control
                Color bgColor = (this.BackColor.A == 0 || this.BackColor == Color.Transparent)
                    ? (this.Parent != null ? this.Parent.BackColor : UIAppearance.BackgroundColor)
                    : this.BackColor;
                graphics.Clear(bgColor);
                //Dibujar el radio button
                if (this.Checked)//Estado marcado
                {
                    graphics.FillEllipse(brushRbFill, rectRadioButton);//Relleno circular del radio button
                    graphics.DrawEllipse(penRbBorder, rectRadioButton);//Borde circular del radio button
                    graphics.FillEllipse(brushRbCheck, rectRbCheck); //Marcado circular del radio button
                }
                else //Estado desmarcado
                {
                    penRbBorder.Color = unCheckedColor;//Cambiar el color del boligrafo
                    graphics.FillEllipse(brushRbFill, rectRadioButton);//Relleno circular del radio button
                    graphics.DrawEllipse(penRbBorder, rectRadioButton); //Borde circular del radio button
                }
                //Dibujar el texto
                graphics.DrawString(this.Text, this.Font, brushText,
                    rbSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Centrado
            }
        }
        #endregion
    }
}
