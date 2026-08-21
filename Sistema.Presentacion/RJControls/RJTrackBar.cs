using RJCodeUI_M1.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    class RJTrackBar : TrackBar
    {
        ///<summary>
        /// Esta clase hereda de la clase <see cref = "TrackBar" />.
        /// El evento OnPaint se anula para dibujar el canal y el control deslizante de la barra de seguimiento.
        /// Basado en el ejemplo de Hans Passant: https://stackoverflow.com/a/2714457/12778930     
        ///</summary>

        #region -> Campos

        private bool customizable;//Obtiene o establece si el color de control es personalizable o los colores están establecidos por la configuración de apariencia
        private bool showValue;//Obtiene o establece si se muestra el valor actual de la barra de seguimiento
        private Color channelColor;//Obtiene o establece el color del canal de la barra de seguimiento
        private Color sliderColor;//Obtiene o establece el color del control deslizante de la barra de seguimiento
        private Color textColor;//Obtiene o establece el color del texto de la barra de seguimiento.

        private int trackerValue;
        private Font textFont;
        // Mensajes de ventana
        private const int WM_USER = 0x0400;//Se usa para definir mensajes privados para su uso por clases de ventanas privadas, generalmente de la forma WM_USER + X, como la siguiente.
        // TrackBar messages
        private const int TBM_GETCHANNELRECT = WM_USER + 26;//Este mensaje recupera el tamaño y la posición del rectángulo delimitador del control deslizante en una barra de seguimiento.
        private const int TBM_GETTHUMBRECT = WM_USER + 25;//Este mensaje recupera el tamaño y la posición del rectángulo delimitador del control deslizante en una barra de seguimiento.
        // RECT structure
        private struct RECT { public int Left, Top, Right, Bottom; }//La estructura RECT define las coordenadas de las esquinas superior izquierda e inferior derecha de un rectángulo.

        #endregion

        #region -> Constructor

        public RJTrackBar()
        {
            SetStyle(ControlStyles.UserPaint, true);//Establecer el estilo de control UserPaint en verdadero para que el control se pinte a sí mismo en lugar del sistema operativo.
            //Initialize objects
            textFont = new Font("Verdana", 8F, FontStyle.Regular);       
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        public bool Customizable
        {//Obtiene o establece si el color de control es personalizable o los colores están establecidos por la configuración de apariencia
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        public Color ChannelColor
        {//Obtiene o establece el color del canal de la barra de seguimiento
            get { return channelColor; }
            set
            {
                channelColor = value;
                if (this.DesignMode)//Vista previa de los cambios en el modo de diseño
                    this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color SliderColor
        {//Obtiene o establece el color del control deslizante de la barra de seguimiento
            get { return sliderColor; }
            set
            {
                sliderColor = value;
                if (this.DesignMode)//Vista previa de los cambios en el modo de diseño
                    this.Update();
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {//Obtiene o establece el color del texto de la etiqueta de valor.
            get { return textColor; }
            set
            {
                textColor = value;
                if (this.DesignMode)//Vista previa de los cambios en el modo de diseño
                    this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool ShowValue
        {//Obtiene o establece si se muestra la etiqueta de valor.
            get { return showValue; }
            set
            {
                showValue = value;
                if (this.DesignMode)//Vista previa de los cambios en el modo de diseño
                    this.Invalidate();
            }
        }
        #endregion

        #region -> Métodos externos
        ///<summary>
        /// El método <SendMessage (IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam) /> es una función externa del usuario
        /// de la biblioteca user32.dll, este método Envía el mensaje especificado a una ventana o ventanas.
        /// La función SendMessage llama al procedimiento de ventana para la ventana especificada y no regresa hasta que la ventana
        /// procedimiento ha procesado el mensaje.
        /// <param name = "hWnd"> Un identificador de la ventana cuyo procedimiento de ventana recibirá el mensaje </param>
        /// <param name = "wMsg"> El mensaje que se enviará </param>
        /// <param name = "wParam"> Información adicional específica del mensaje: debe ser cero </param>
        /// <param name = "lParam"> Información adicional específica del mensaje: ref RECT> Puntero a una estructura RECT.
        /// El mensaje llena esta estructura con el rectángulo delimitador del control deslizante de la barra de seguimiento en las coordenadas del cliente
        /// de la ventana de la barra de seguimiento </param>
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageRect(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);
        #endregion

        #region -> Métodos privados

        private Rectangle GetSlider()
        {//Obtener el tamaño y la posición del control deslizante
            RECT rect = new RECT();
            SendMessageRect(this.Handle, TBM_GETTHUMBRECT, IntPtr.Zero, ref rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

        }
        private Rectangle GetChannel()
        {//Obtener el tamaño y la posición del canal

            RECT rect = new RECT();
            SendMessageRect(this.Handle, TBM_GETCHANNELRECT, IntPtr.Zero, ref rect);
            if (this.Orientation == Orientation.Horizontal)//Horizontal Orientation
                return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top + 3);
            else //Vertical Orientation
                return new Rectangle(rect.Left, rect.Top, rect.Bottom - rect.Top + 3, rect.Right - rect.Left);

        }
        private void ApplyAppearanceSettings()
        {
            //Cargar configuración de apariencia
            if (customizable == false)
            {
                if (UIAppearance.Theme == UITheme.Light)
                {
                    channelColor = Color.LightGray;
                    sliderColor = UIAppearance.StyleColor;
                    textColor = Utils.ColorEditor.Lighten(UIAppearance.TextColor, 25);
                }
                else
                {
                    channelColor = RJColors.DefaultFormBorderColor;
                    sliderColor = UIAppearance.StyleColor;
                    textColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 7);
                }
            }       
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnHandleCreated(EventArgs e)
        {//Este evento es equivalente al evento de carga
            base.OnHandleCreated(e);

            trackerValue = this.Value;//Establecer valor actual
            ApplyAppearanceSettings();//Cargar configuración de apariencia
        }
        protected override void OnValueChanged(EventArgs e)
        {//Este evento ocurre cuando el valor de la barra de seguimiento cambia
            base.OnValueChanged(e);

            trackerValue = this.Value;//Establecer valor actual
            this.Invalidate(false);//Redibujar control (invocar el evento Paint)
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var channel = GetChannel();//Obtener el tamaño y la posición del canal
            var slider = GetSlider();//Obtener el tamaño y la posición del control deslizante 
            using (Graphics graph = e.Graphics)
            using (SolidBrush brushChannel = new SolidBrush(channelColor))
            using (SolidBrush brushSlider = new SolidBrush(sliderColor))
            using (SolidBrush brushText = new SolidBrush(textColor))
            {
                graph.FillRectangle(brushChannel, channel);//Dibujar el canal de la barra de seguimiento con el color especificado y el tamaño y la posición obtenidos.
                graph.FillRectangle(brushSlider, slider);//Dibujar el control deslizante de la barra de seguimiento con el color especificado y el tamaño y la posición obtenidos.                    

                if (showValue)//Dibujar el texto con el valor actual de la barra de seguimiento
                {
                    if (this.Orientation == Orientation.Horizontal) //Horizontal Orientation
                    {
                        if (trackerValue >= 100)
                            graph.DrawString(trackerValue.ToString(), textFont, brushText, slider.Left - 6, 21);
                        else
                            graph.DrawString(trackerValue.ToString(), textFont, brushText, slider.Left, 21);
                    }
                    else //Vertical Orientation
                    {
                        graph.DrawString(trackerValue.ToString(), textFont, brushText, 21, slider.Top);
                        //this.Value.ToString () no funcionará en este escenario, por lo tanto, se crea el campo trackerValue.
                    }
                }
            }
            /* Nota: Si no desea dibujar el texto, no es necesario llamar al método Invalidate () en el evento ValueChanged */
        }
        #endregion

    }
}

