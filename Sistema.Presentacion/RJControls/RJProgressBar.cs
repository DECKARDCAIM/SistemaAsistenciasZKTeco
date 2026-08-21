using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using RJCodeUI_M1.Settings;

namespace RJCodeUI_M1.RJControls
{
    public class RJProgressBar : ProgressBar
    {
        // Tutorial guía: https://youtu.be/Sj_b3yOUQDk

        #region -> Campos
        //-> Apariencia
        private Color channelColor = Color.LightSteelBlue; //Obtiene o estable el color del canal.
        private Color sliderColor = Color.RoyalBlue; //Obtiene o establece el color del deslizador o indicador.
        private Color foreBackColor = Color.RoyalBlue; //Obtiene o estable el color de fondo del texto del valor.
        private int channelHeight = 6; //Obtiene o estable la altura del canal.
        private int sliderHeight = 6;//Obtiene o estable la altura del deslizador.
        private TextPosition showValue = TextPosition.Right; //Obtiene o estable la posición del texto del valor.
        private string symbolBefore = ""; //Obtiene o estable un simbolo o texto antes del texto del valor.
        private string symbolAfter = "";//Obtiene o estable un simbolo o texto despues del texto del valor.
        private bool showMaximun = false;//Obtiene o estable si se muestra el valor máximo.

        //-> Otros
        private bool paintedBack = false;//Obtiene o estable si color de fondo ha sido pintado.
        private bool stopPainting = false;//Obtiene o estable si la pintura debe dejar de pintar.
        private bool customizable = true;//Obtiene o estable si los colores es personalizable, o establecido por la configuración de apariencia.
        #endregion

        #region -> Constructor
        public RJProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        public bool Customizable
        {
            get { return customizable; }
            set
            {
                customizable = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color ChannelColor
        {
            get { return channelColor; }
            set
            {
                channelColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color SliderColor
        {
            get { return sliderColor; }
            set
            {
                sliderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color ForeBackColor
        {
            get { return foreBackColor; }
            set
            {
                foreBackColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int ChannelHeight
        {
            get { return channelHeight; }
            set
            {
                channelHeight = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int SliderHeight
        {
            get { return sliderHeight; }
            set
            {
                sliderHeight = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public TextPosition ShowValue
        {
            get { return showValue; }
            set
            {
                showValue = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public string SymbolBefore
        {
            get { return symbolBefore; }
            set
            {
                symbolBefore = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public string SymbolAfter
        {
            get { return symbolAfter; }
            set
            {
                symbolAfter = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool ShowMaximun
        {
            get { return showMaximun; }
            set
            {
                showMaximun = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
            this.Parent.Paint += new PaintEventHandler(ParentContainer_RePaint);
        }

        private void ParentContainer_RePaint(object sender, PaintEventArgs e)
        {
            //Si el contenedor (Formulario o control) del control se vuelve a pintar, 
            //por ejemplo, cuando se desplaza el formulario (Scroll), reiniciar la pintura del control.
            stopPainting = false;
            paintedBack = false;
        }

        //-> Pintar el fondo y canal del control.
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting == false)
            {
                if (paintedBack == false)
                {
                    //Campos
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, ChannelHeight);
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        if (channelHeight >= sliderHeight)
                            rectChannel.Y = this.Height - channelHeight;
                        else rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);

                        //Pintura
                        graph.Clear(this.Parent.BackColor);//Pintar la superficie/fondo del control
                        graph.FillRectangle(brushChannel, rectChannel);//pintar el canal del control

                        //Parar de pintar el fondo y canal, con esta condicion el fondo y canal solo se pinta una vez, eso para evitar el parpadeo.
                        if (this.DesignMode == false)
                            paintedBack = true;
                    }
                }
                //Reiniciar la pintura del fondo y canal, siempre en cuando que el valor llegue al valor máximo o mínimo.
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                    paintedBack = false;
            }
        }
        //-> Pintar el deslizador o indicador.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (stopPainting == false)
            {
                //Campos
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                        rectSlider.Y = this.Height - sliderHeight;
                    else rectSlider.Y = this.Height - ((sliderHeight + channelHeight) / 2);

                    //Pintura
                    if (sliderWidth > 1) //Pintar el deslizador
                        graph.FillRectangle(brushSlider, rectSlider);
                    if (showValue != TextPosition.None) //Dibujar el texto del valor.
                        DrawValueText(graph, sliderWidth, rectSlider);
                }
            }
            if (this.Value == this.Maximum) stopPainting = true;//Parar de pintar si el valor llega la valor máximo
            else stopPainting = false; //Caso contrario, seguir pintando.

        }

        #endregion

        #region -> Métodos privados

        //-> Pintar el texto del valor.
        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlider)
        {
            //Campos
            string text = symbolBefore + this.Value.ToString() + symbolAfter;
            if (showMaximun) text = text + "/" + symbolBefore + this.Maximum.ToString() + symbolAfter;
            var textSize = TextRenderer.MeasureText(text, this.Font);
            var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);
            using (var brushText = new SolidBrush(this.ForeColor))
            using (var brushTextBack = new SolidBrush(foreBackColor))
            using (var textFormat = new StringFormat())
            {
                switch (showValue)
                {
                    case TextPosition.Left:
                        rectText.X = 0;
                        textFormat.Alignment = StringAlignment.Near;
                        break;

                    case TextPosition.Right:
                        rectText.X = this.Width - textSize.Width;
                        textFormat.Alignment = StringAlignment.Far;
                        break;

                    case TextPosition.Center:
                        rectText.X = (this.Width - textSize.Width) / 2;
                        textFormat.Alignment = StringAlignment.Center;
                        break;

                    case TextPosition.Sliding:
                        rectText.X = sliderWidth - textSize.Width;
                        textFormat.Alignment = StringAlignment.Center;
                        //Limpiar la superfice anterior del texto.
                        using (var brushClear = new SolidBrush(this.Parent.BackColor))
                        {
                            var rect = rectSlider;
                            rect.Y = rectText.Y;
                            rect.Height = rectText.Height;
                            graph.FillRectangle(brushClear, rect);
                        }
                        break;
                }
                //Pintura
                graph.FillRectangle(brushTextBack, rectText);//Pintar el fondo del texto.
                graph.DrawString(text, this.Font, brushText, rectText, textFormat); //Dibujar el texto.
            }
        }

        private void ApplyAppearanceSettings()
        {
            if (customizable == false)//Si no es personalizable, aplicar la configuración de color de la apariencia.
            {
                foreBackColor = UIAppearance.StyleColor;
                sliderColor = UIAppearance.StyleColor;
                if (UIAppearance.Theme == UITheme.Dark)
                    channelColor = Utils.ColorEditor.Lighten(UIAppearance.ItemBackgroundColor, 5);
                else channelColor = Utils.ColorEditor.Darken(UIAppearance.BackgroundColor, 15);
            }
        }
        #endregion
    }
}
