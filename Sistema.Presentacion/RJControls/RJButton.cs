using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using FontAwesome.Sharp;
using RJCodeUI_M1.Utils;

namespace RJCodeUI_M1.RJControls
{
    public class RJButton : IconButton
    {
        ///<summary>
        /// ------ Esta clase hereda de la clase <see cref = "IconButton" /> de la biblioteca <see cref = "FontAwesome.Sharp" />
        /// Autor: mkoertgen
        /// GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        /// Paquete Nuget: https://www.nuget.org/packages/FontAwesome.Sharp
        /// Este botón implementa 4 propiedades de apariencia:
        /// -> Puede cambiar el estilo del botón a Glass o Solid (<see cref = "ControlStyle"/>).
        /// -> Puede cambiar el diseño del botón a Normal, Botón de icono, Metro, Confirmar, Cancelar o Eliminar (<see cref = "ButtonDesign" />).
        /// -> Puede establecer esquinas redondeadas, Propiedad: <see cref = "int BorderRadius"/>).
        /// -> Puede cambiar el tamaño de borde del botón, Propiedad: <see cref = "int BorderSize"/>).
        /// Tutorial guia: https://www.youtube.com/watch?v=u8SL5g9QGcI&t
        /// </summary>

        #region -> Campos

        private ControlStyle style = ControlStyle.Solid;//Obtiene o establece el estilo del botón (vidrio o sólido).
        private ButtonDesign design = ButtonDesign.Normal;//Obtiene o establece el diseño del botón (Normal, Botón de icono, Metro, Confirmar, Cancelar o Eliminar).
        private int borderRadius = 0;//Obtiene o establece el tamaño del radio del borde (esquinas redondeadas).
        private int borderSize = 0;//Obtiene o establece el tamaño del borde del botón.
        private Color skinBorderColor = UIAppearance.StyleColor;//Obtiene o establece el color del borde si el estilo es GLASS, o color de fondo si el estilo es SOLID;    
        private static readonly Color supernovaColor = UIAppearance.Style == UIStyle.Supernova ? RJColors.GetSupernovaColor() : Color.CornflowerBlue;//Establece y obtiene un color de supernova si el estilo es supernova
        #endregion

        #region -> Constructor

        public RJButton()
        {
            //Inicializar propiedades
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            //this.BackColor = UIAppearance.StyleColor;
            this.Flip = FlipOrientation.Normal;
            this.Font = new Font("Microsoft Sans Serif", UIAppearance.TextSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.White;
            this.IconSize = 24;
            this.IconColor = Color.White;
            this.Rotation = 0D;
            this.Size = new Size(170, 40);
            SetButtonDesign();
        }


        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el diseño del botón (Normal, Botón de icono, Metro, Confirmar, Cancelar o Eliminar)")]
        public ButtonDesign Design
        {
            get { return design; }
            set
            {
                design = value;
                if (design != ButtonDesign.Custom)//Si el diseño no es personalizado, 
                    SetButtonDesign();//Establecer el diseño especificado.
                //No es necesario llamar el metodo invalidate(), ya que al cambiar el color de fondo o texto el metodo se invoca automaticamente.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el estilo del botón (vidrio o sólido)")]
        public ControlStyle Style
        {
            get { return style; }
            set
            {
                style = value;//Asignar el valor especificado.
                SetButtonStyle();//Y establecer el estilo especificado.
                //No es necesario llamar el metodo invalidate(), ya que al cambiar el color de fondo o texto el metodo se invoca automaticamente.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del borde si el estilo es GLASS, o color de fondo si el estilo es SOLID")]
        public Color BorderColor
        {
            get { return skinBorderColor; }
            set
            {
                skinBorderColor = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el tamaño del borde del botón.")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el tamaño del radio del borde (esquinas redondeadas).")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
                }
            }
        }

        [DefaultValue(typeof(Color), "Color.Black")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        #endregion

        #region -> Métodos privados

        private void SetButtonStyle()
        {//Este método se encarga de establecer el estilo del botón.
            if (design != ButtonDesign.Custom)
            {
                if (style == ControlStyle.Solid)//Estilo Sólido
                {
                    this.BackColor = skinBorderColor;
                    this.ForeColor = Color.White;
                    this.IconColor = Color.White;
                }
                else//Estilo Vidrio.
                {
                    if (borderSize < 1) borderSize = 1;
                    this.ForeColor = skinBorderColor;
                    this.IconColor = skinBorderColor;
                    this.BackColor = Color.Empty;
                }
                //No es necesario llamar el metodo invalidate(), ya que al cambiar el color de fondo o texto el metodo se invoca automaticamente.
            }
        }

        private void SetButtonDesign()
        {//Este método se encarga de establecer el diseño del botón.
            switch (design)
            {
                case ButtonDesign.Normal: //Botón Normal (sin icono)
                    SetNormalButton();//Establecer las propiedades de un botón sin icono.
                    ApplyAppearanceSettings();//Obtener y establecer el color de borde o fondo de la configuración de apariencia.
                    break;

                case ButtonDesign.IconButton: //Botón Icono
                    SetIconButton();//Establecer las propiedades de un botón de icono.
                    //Si no tiene ícono o el ícono es para confirmar, cancelar o borrar, establecer un ícono predeterminado.
                    if (this.IconChar == FontAwesome.Sharp.IconChar.None || this.IconChar == FontAwesome.Sharp.IconChar.Check ||
                          this.IconChar == FontAwesome.Sharp.IconChar.TrashAlt || this.IconChar == FontAwesome.Sharp.IconChar.TimesCircle)
                        this.IconChar = FontAwesome.Sharp.IconChar.Magento;//Icono predeterminado.
                    ApplyAppearanceSettings();//Obtener y establecer el color de borde o fondo de la configuración de apariencia.
                    break;

                case ButtonDesign.Metro://Botón Metro
                    SetMetroButton();//Establecer las propiedades de un botón metro.
                    //Si no tiene ícono o el ícono es confirmar, cancelar o borrar, establecer un icono predeterminado.
                    if (this.IconChar == FontAwesome.Sharp.IconChar.None || this.IconChar == FontAwesome.Sharp.IconChar.Check ||
                         this.IconChar == FontAwesome.Sharp.IconChar.TrashAlt || this.IconChar == FontAwesome.Sharp.IconChar.TimesCircle)
                        this.IconChar = FontAwesome.Sharp.IconChar.Magento;//Icono predeterminado.
                    ApplyAppearanceSettings();//Obtener y establecer el color de borde o fondo de la configuración de apariencia.
                    break;

                case ButtonDesign.Confirm://Botón confirmar
                    SetIconButton();//Establecer las propiedades de un botón de icono.
                    this.IconChar = FontAwesome.Sharp.IconChar.Check;//Establecer icono de confirmar
                    this.Text = "Confirmar";//Establecer texto
                    skinBorderColor = RJColors.Confirm;//Color de borde o fondo.
                    break;

                case ButtonDesign.Delete://Botón borrar
                    SetIconButton();//Establecer las propiedades de un botón de icono.
                    this.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;//Establecer icono de eliminar
                    this.Text = "Eliminar";//Establecer texto 
                    skinBorderColor = RJColors.Delete;//Color de borde o fondo.
                    break;

                case ButtonDesign.Cancel://Botón cancelar
                    SetIconButton();//Establecer las propiedades de un botón de icono.
                    this.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;//Establecer icono de cancelar
                    this.Text = "Cancelar";//Establecer texto
                    skinBorderColor = RJColors.Cancel;//Color de borde o fondo.
                    break;
            }
            //if (design != ButtonDesign.Custom)
            SetButtonStyle();
        }
        private void SetNormalButton()
        {//Este método se encarga de establecer las propiedades de botón normal sin icono.

            this.TextImageRelation = TextImageRelation.Overlay;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.IconChar = FontAwesome.Sharp.IconChar.None;
            if (this.DesignMode)
                this.Size = new Size(160, 40);//Restablecer el tamaño especificado
        }
        private void SetIconButton()
        {//Este método se encarga de establecer las propiedades de botón de icono.

            this.TextAlign = ContentAlignment.MiddleRight;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            if (this.DesignMode)//Restablecer el tamaño especificado e icono solo en tiempo de diseño.
            {
                this.Size = new Size(160, 40);
                this.IconSize = 24;
            }
        }
        private void SetMetroButton()
        {//Este método se encarga de establecer las propiedades de botón metro.

            this.TextAlign = ContentAlignment.BottomCenter;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
            if (this.DesignMode)//Establecer el tamaño especificado e icono para metro (solo en tiempo de diseño)
            {
                this.Size = new Size(110, 110);
                this.IconSize = 50;
            }
        }
        private void ApplyAppearanceSettings()
        {//Este método se encarga de establecer el color de borde o fondo de la configuración de apariencia.
            if (design == ButtonDesign.Normal || design == ButtonDesign.IconButton || design == ButtonDesign.Metro)
            {
                if (UIAppearance.Style == UIStyle.Supernova) skinBorderColor = supernovaColor;
                else skinBorderColor = UIAppearance.StyleColor;
            }
            this.FlatAppearance.MouseOverBackColor = ColorEditor.Darken(this.BackColor, 12);
            this.FlatAppearance.MouseDownBackColor = ColorEditor.Darken(this.BackColor, 6);
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnPaint(PaintEventArgs pevent)
        {//Este método se encarga de establecer la region del boton y dibujar el borde.
            base.OnPaint(pevent);
            Graphics graph = pevent.Graphics;

            if (style == ControlStyle.Glass || design == ButtonDesign.Custom)//Estilo Glass
                //Aplicar esquinas redondeados a la región y suavizar + dibujar el borde.
                RoundedControl.RegionAndBorder(this, borderRadius, graph, skinBorderColor, borderSize);
            else //Estilo Solid
                //Aplicar esquinas redondeados a la región y suavizar el borde.
                RoundedControl.RegionAndSmoothed(this, borderRadius, graph);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Verificar el validar el radio. (El radío maximo es la mitad del valor del alto del control)
            int maxRadius = this.Height / 2;
            if (borderRadius > maxRadius)
                borderRadius = maxRadius;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();//Aplicar la configuracion de apariencia.
        }

        #endregion

    }
}

