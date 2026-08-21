using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace RJCodeUI_M1.RJControls
{
    public class RJLabel : Label
    {
        #region -> Campos

        private LabelStyle style;//Obtiene o establece el estilo de etiqueta     
        private bool linkLabel;//Obtiene o establece si es una etiqueta de enlace (abrir un enlace en el navegador o formulario)
        private Color textColor;//Obtiene o establece el color de texto.
        #endregion

        #region -> Constructor
        public RJLabel()
        {
            this.ForeColor = UIAppearance.TextColor;//Establecer el color del texto del tema
            this.Font = new Font("Verdana", UIAppearance.TextSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Establecer fuente predeterminada
            style = LabelStyle.Normal;//Establecer estilo de etiqueta
            this.MouseEnter += new EventHandler(Label_MouseEnter);
            this.MouseLeave += new EventHandler(Label_MouseLeave);
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        public LabelStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                ApplyAppearanceSettings();//Aplicar tema cuando se establece el estilo de etiqueta
            }
        }

        [Category("RJ Code Advance")]
        public bool LinkLabel
        {//Obtiene o establece si la etiqueta es un enlace
            //(Si es verdadero, la etiqueta cambia el puntero y el color del texto cuando el mouse pasa sobre ella, consulte los Métodos de evento)
            get { return linkLabel; }
            set
            {
                linkLabel = value;
                if (linkLabel == true)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #region -> Métodos privados

        private void ApplyAppearanceSettings()
        {
            switch (style)
            {
                case LabelStyle.Normal: //Si el estilo es normal, establecer el color y el tamaño del texto establecido en la configuracion de apariencia.                
                    textColor = UIAppearance.TextColor;
                    this.ForeColor = textColor;
                    this.Font = new Font(this.Font.Name, UIAppearance.TextSize, this.Font.Style, this.Font.Unit);
                    break;

                case LabelStyle.Description: //Si el estilo es descripción
                    if (UIAppearance.Theme == Settings.UITheme.Dark) //Si el tema es de estilo oscuro, aclarar el color del texto
                        textColor = ColorEditor.Darken(UIAppearance.TextColor, 10);
                    else //Si el tema es de estilo claro, oscurecer el color del texto
                        textColor = ColorEditor.Lighten(UIAppearance.TextColor, 15);

                    this.ForeColor = textColor;
                    this.Font = new Font(this.Font.Name, 8F, this.Font.Style, this.Font.Unit);
                    break;

                case LabelStyle.Subtitle://Si el estilo es subtítulo, establecer el color establecido en el tema y un tamaño de 12.5F
                    if (UIAppearance.Theme == Settings.UITheme.Dark) //Si el tema es de estilo oscuro, aclarar el color del texto
                        textColor = ColorEditor.Lighten(UIAppearance.TextColor, 45);
                    else //Si el tema es de estilo claro, oscurecer el color del texto
                        textColor = ColorEditor.Darken(UIAppearance.TextColor, 20);

                    this.ForeColor = textColor;
                    this.Font = new Font(this.Font.Name, 12F, this.Font.Style, this.Font.Unit);
                    break;

                case LabelStyle.Title://Si el estilo es el título, establecer el color de estilo de la aplicación como color de texto o un tamaño de 16F.
                    textColor = UIAppearance.StyleColor;
                    this.ForeColor = textColor;
                    this.Font = new Font(this.Font.Name, 14F, this.Font.Style, this.Font.Unit);
                    break;

                case LabelStyle.Title2:
                    if (UIAppearance.Theme == Settings.UITheme.Dark) //Si el tema es de estilo oscuro, aclarar el color del texto
                        textColor = ColorEditor.Lighten(UIAppearance.TextColor, 50);
                    else //Si el tema es de estilo claro, oscurecer el color del texto
                        textColor = ColorEditor.Darken(UIAppearance.TextColor, 25);
                    this.ForeColor = textColor;
                    this.Font = new Font(this.Font.Name, 14F, this.Font.Style, this.Font.Unit);
                    break;

                case LabelStyle.BarCaption://Si el estilo es un título de la barra de título del formulario principal.
                    this.Font = new Font("Verdana", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    ColorTitleBar();
                    break;

                case LabelStyle.BarText://Si el estilo es un texto de la barra de título del formulario principal.
                    this.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    ColorTitleBar();
                    break;

                case LabelStyle.Custom://Tamaño y fuente personalizados, sin embargo, el color del texto se establece por el tema.
                    textColor = UIAppearance.TextColor;
                    this.ForeColor = textColor;
                    break;
            }
        }
        private void ColorTitleBar()
        {
            if (UIAppearance.Theme == UITheme.Light && UIAppearance.Style == UIStyle.Supernova)//Si el tema es claro y el estilo es supernova, oscurecer el color del texto
                this.ForeColor = ColorEditor.Darken(UIAppearance.TextColor, 25);
            else if (UIAppearance.Theme == UITheme.Dark && UIAppearance.Style == UIStyle.Supernova) //Si el tema esoscuro y el estilo es supernova, aclarar el color del texto
                this.ForeColor = ColorEditor.Lighten(UIAppearance.TextColor, 65);
            else //Si el estilo es cualquier otro, establecer el color blanco como color del texto.
                this.ForeColor = Color.WhiteSmoke;
        }
        #endregion 

        #region -> Métodos de evento

        private void Label_MouseEnter(object sender, EventArgs e)
        {//Si la etiqueta es de tipo enlace, cambiar el color del texto cuando el mouse pasa sobre ella.
            if (linkLabel == true)
                this.ForeColor = ColorEditor.Lighten(UIAppearance.StyleColor, 20);
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {//Si la etiqueta es de tipo enlace, restablecer el color del texto cuando el mouse sale del control.
            if (linkLabel == true)
                this.ForeColor = textColor;
        }
        #endregion
    }
}