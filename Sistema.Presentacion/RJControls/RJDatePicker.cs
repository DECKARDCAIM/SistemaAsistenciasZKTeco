using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using System.Drawing.Drawing2D;

namespace RJCodeUI_M1.RJControls
{
    [DefaultEvent("OnValueChanged")]//Evento predeterminado al hacer doble clic en el control en el diseñador
    public class RJDatePicker : UserControl
    {
        /// <summary>
        /// Esta clase hereda la clase <see cref = "UserControl" />.
        /// Este control expone la mayoría de las propiedades y eventos esenciales más utilizados de
        /// un DateTimePicker normal, puede agregar las funcionalidades que probablemente necesite y que falten aquí.
        /// Por otro lado, puede cambiar el estilo a sólido o vidrio, también personalizar el menú desplegable,
        /// icono del calendario, color del borde y radio del borde (esquinas redondeadas solo afectan al estilo sólido).
        /// Tutorial guia: https://www.youtube.com/watch?v=IJM9SIX0pIs&t=1s (Custom data picker - No UserControl)
        /// Tutorial guia 2: https://www.youtube.com/watch?v=CkpUQYzYCC8&t=24s (Custon text box - UserControl)
        /// </summary>
        /// 

        #region -> Campos

        //Campos
        private int borderRadius;//Obtiene o establece el tamaño del radio del borde (esquinas redondeadas).
        private int borderSize = 1;//Obtiene o establece el tamaño del borde
        private ControlStyle style;//Obtiene o establece el estilo de control (Glass o Solid).
        private Color backgroundColor;//Obtiene o estable el Color de fondo.
        private Color borderColor;//Obtiene o estable el Color de borde.
        private Color iconColor;//Obtiene o estable el Color de icono.
        private bool customizable;//Obtiene o estable si los colores de apariencia del control es personalizable.
        private bool isDroppedDown = false;//Obtiene o establece si el calendario desplegable está abierto.
        //Controles
        private Label dateText;//Obtiene o estable la Etiqueta del DateTimePicker (para mostrar el texto de fecha del DateTimePicker).
        private IconButton btnIcon;//Obtiene o estable el Icono de calendario desplegable (botón para mostrar el calendario).
        private DateTimePicker datePicker;//Obtiene o estable el Selector de fecha (no es visible, pero puede mostrar el calendario desplegable).

        ///<Note>:ICON BUTTON es proporcionado por la librería <see cref="FontAwesome.Sharp"/>.
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp </Note>
        #endregion

        #region -> Eventos

        [Category("RJ Code Advance")]
        public event EventHandler OnValueChanged;//Evento predeterminado del control.
        #endregion

        #region -> Constructor

        public RJDatePicker()
        {
            dateText = new Label();
            datePicker = new DateTimePicker();
            btnIcon = new IconButton();
            this.SuspendLayout();

            // 
            // IconButton: Dropdown Calendar Icon
            //             
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.Flip = FlipOrientation.Normal;
            btnIcon.IconChar = IconChar.CalendarAlt;//Establecer icono de calendario.
            btnIcon.IconColor = Color.White;
            btnIcon.IconSize = 22;
            btnIcon.Location = new Point(189, 1);
            btnIcon.Name = "dropdownArrowIcon";
            btnIcon.Rotation = 0D;
            btnIcon.Size = new Size(30, 30);
            btnIcon.UseVisualStyleBackColor = false;
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(ButtonIcon_Click);//Subscribir al evento click (Para mostrar el calendario)

            // 
            // Label: Date Text (Representa la parte visual de DateTimePicker, muestra el texto de la fecha y RELLENA el control de usuario)
            //           
            dateText.Dock = DockStyle.Fill;//Establecer relleno como estilo de muelle
            dateText.FlatStyle = FlatStyle.Flat;
            dateText.Font = new Font("Microsoft Sans Serif", 10F);
            dateText.ForeColor = Color.Gray;
            dateText.ImageAlign = ContentAlignment.MiddleLeft;
            dateText.Location = new Point(1, 1);
            dateText.Name = "dateText";
            dateText.Padding = new Padding(8, 0, 0, 0);
            dateText.Controls.Add(btnIcon);//Agregar el boton de icono a la etiqueta.
            dateText.TextAlign = ContentAlignment.MiddleLeft;

            /*Como la etiqueta(dateText) representa la parte visual del ComboBox y ocupa la mayor parte del control de usuario,
             Es necesario adjuntar los eventos que ocurre en la etiqueta (dateText) a los eventos del control de usuario (RJDatePicker),
             Es decir, por ejemplo en el evento Clic, cuando se hace clic en la etiqueta, tambien se debe ejecutar el evento clic del control de usuario (RJDatePicker).
             Ver la definicion de los metodos de evento para entender mejor.*/
            dateText.Click += new EventHandler(RJDatePicker_Click);
            dateText.KeyDown += new KeyEventHandler(RJDatePicker_KeyDown);
            dateText.KeyPress += new KeyPressEventHandler(RJDatePicker_KeyPress);
            dateText.KeyUp += new KeyEventHandler(RJDatePicker_KeyUp);
            dateText.MouseEnter += new EventHandler(RJDatePicker_MouseEnter);
            //Puede adjuntar los eventos que desee, si no existe, puede crearlo como lo hizo con el evento OnValueChanged.
            
            // 
            // DateTimePicker: Date Picker
            // 
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(100, 20);
            datePicker.Location = new Point(2, 2);
            datePicker.DropDownAlign = LeftRightAlignment.Right;
            datePicker.CloseUp += new EventHandler(DatePicker_CloseUp);//Subscribirse al evento CloseUp (Sucede cuando el calendario se oculta/cierra)
            datePicker.ValueChanged += new EventHandler(DatePicker_ValueChanged);//Suscribir el evento ValueChanged del control y adjuntarlo al evento OnValueChanged definido previamente (consulte la definición del método).

            // 
            // User control: RJDatePicker
            //
            //Add controls
            this.Controls.Add(dateText);//Rellena todo el control de usuario (muestra el texto del selector de fecha)          
            this.Controls.Add(datePicker);//Está en el fondo, detrás de la etiqueta (no es visible, pero muestra el calendario desplegable).
            //Este orden es importante, los últimos controles se agregan primero (de abajo hacia arriba)

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.MediumSlateBlue;
            this.MinimumSize = new Size(120, 25);
            this.Padding = new Padding(1);
            this.Size = new Size(260, 32);
            BorderSize = borderSize;//Establecer tamaño de borde para aplicar los ajustes necesarios.
            this.ResumeLayout(false);

        }
        #endregion

        #region -> Propiedades

        #region - Propiedades de diseño

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el estilo (vidrio o sólido)")]
        public ControlStyle Style
        {
            get { return style; }
            set
            {
                style = value;//Establecer valor.            
                BorderRadius = borderRadius;//Actualizar el radio del borde.
                if (this.DesignMode)
                    ApplyAppearanceSettings();//actualizar la configuración de apariencia-> vista previa de los cambios en el modo de diseño.
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene si el control es personalizable")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u establece el color del borde")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate(); //Dibujar el borde (Redibujar el control)    
            }
        }
        [Category("RJ Code Advance")]
        [Description("Obtiene u establece el tamaño del borde")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Padding = new Padding(borderSize + 1);//Establecer la propiedad Padding para aplicar un espacio y dibujar el borde.
                    SetDatePickerLocation();//Actualizar la ubicación del combobox.
                    this.Invalidate();//Dibujar el borde (Redibujar el control)
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el radio del borde")]
        [DefaultValue(0)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    SetDatePickerLocation();//Actualizar la ubicación del combobox.
                    this.Invalidate();//Dibujar el borde y radio (Redibujar el control)
                }
            }
        }


        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de fondo.")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                backgroundColor = value;
                dateText.BackColor = backgroundColor;
                btnIcon.BackColor = backgroundColor;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece o ubtiene el color de icono.")]
        public Color IconColor
        {
            get { return btnIcon.IconColor; }
            set
            {
                iconColor = value;
                btnIcon.IconColor = iconColor;
            }
        }

        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                dateText.ForeColor = value;
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece la fuente")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                dateText.Font = value;               
            }
        }
        #endregion

        #region - Propiedades funcionales

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el formato de la fecha y la hora que se muestran en el control")]
        public DateTimePickerFormat Format
        {
            get { return datePicker.Format; }
            set
            {
                datePicker.Format = value;
                dateText.Text = datePicker.Text;//Actualizar texto de fecha
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece la cadena de formato de fecha / hora personalizada")]
        public string CustomFormat
        {
            get { return datePicker.CustomFormat; }
            set
            {
                datePicker.CustomFormat = value;
                dateText.Text = datePicker.Text;//Actualizar texto de fecha
            }

        }
        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el valor de fecha / hora asignado al control")]
        public DateTime Value
        {
            get { return datePicker.Value; }
            set
            {
                datePicker.Value = value;
                dateText.Text = datePicker.Text;//Actualizar texto de fecha
            }
        }

        [Browsable(false)]//Propiedad no visible en el cuadro de propiedadades
        public new string Text//Anular la propiedad de texto del control del usuario
        {
            get { return datePicker.Text; }//Retornar el texto del selector de fecha.

        }
        #endregion

        #endregion

        #region -> Métodos privados

        private void ApplyAppearanceSettings()
        {//Aplicar configuración de apariencia
            if (customizable == false)
            {
                switch (style)
                {
                    case ControlStyle.Solid://Estilo sólido.  
                        BorderColor = UIAppearance.StyleColor;
                        BorderSize = 0;
                        dateText.ForeColor = Color.White;
                        btnIcon.IconColor = Color.White;
                        this.BackColor = UIAppearance.StyleColor;
                        break;
                    case ControlStyle.Glass://Estilo vidrio.

                        btnIcon.IconColor = UIAppearance.StyleColor;
                        dateText.ForeColor = UIAppearance.PrimaryTextColor;
                        this.BackColor = UIAppearance.BackgroundColor;

                        if (UIAppearance.Theme == UITheme.Dark)
                            BorderColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 10);
                        else BorderColor = UIAppearance.TextColor;
                        break;
                }
            }
        }

        private void SetDatePickerLocation()
        {//Se encarga de ubicar el datePicker en la esquina inferior derecha.
            if (borderRadius > 2)
                datePicker.Location = new Point(this.Width - datePicker.Width - this.Padding.Right - (borderRadius / 2) - 2, dateText.Bottom - datePicker.Height);
            else
                datePicker.Location = new Point(this.Width - datePicker.Width - this.Padding.Right, dateText.Bottom - datePicker.Height);
        }
        #endregion

        #region -> Métodos de evento

        //-> Evento predeterminado
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {//Adjuntar el evento predeterminado creado OnValueChanged del control de usuario (RJDatePicker) 
            //al evento principal ValueChanged del selector de fecha (datePicker).       

            if (OnValueChanged != null)
                OnValueChanged.Invoke(sender, e);

            dateText.Text = datePicker.Text;//Cuando se seleccione una fecha del calendario desplegable, actualizar el texto de la etiqueta.
        }

        //-> Acciones de los componentes
        private void ButtonIcon_Click(object sender, EventArgs e)
        {//Cuando se hace clic en el botón del icono calendario, se mostrará el calenderio desplegable

            isDroppedDown = true;
            this.datePicker.Select();//Por precaución, el selector de fecha debe estar enfocado antes, a veces ocurren algunos problemas.
            SendKeys.Send("%{DOWN}");//Este control no tiene la propiedad DroppedDown para mostrar el calendario.
            //por lo tanto, usaremos las teclas de acceso directo del sistema operativo para mostrar el calendario: se presiona la tecla Alt + flecha hacia abajo
            //Tecla Alt=%
            //Tecla flecha abajo= DOWN
            //Entonces enviamos pulsaciones de teclas cuando se hace clic en el icono de calendario.
            if (customizable)
            {
                switch (style)//Aplicar un resaltado al botón de icono
                {
                    case ControlStyle.Solid:
                        btnIcon.BackColor = Utils.ColorEditor.Darken(backgroundColor, 10);
                        btnIcon.IconColor = Color.White;
                        break;
                    case ControlStyle.Glass:
                        btnIcon.BackColor = borderColor;
                        btnIcon.IconColor = Color.White;
                        BorderColor = borderColor;
                        break;
                }
            }
            else
            {
                switch (style)//Aplicar un resaltado al botón de icono 
                {
                    case ControlStyle.Solid:
                        btnIcon.BackColor = Utils.ColorEditor.Darken(UIAppearance.StyleColor, 10);
                        btnIcon.IconColor = Color.White;
                        break;
                    case ControlStyle.Glass:
                        btnIcon.BackColor = UIAppearance.StyleColor;
                        btnIcon.IconColor = Color.White;
                        BorderColor = UIAppearance.StyleColor;
                        break;
                }
            }
        }
        private void DatePicker_CloseUp(object sender, EventArgs e)
        {//Ocurre cuando el calendario desplegable se cierra
            isDroppedDown = false;
            if (customizable)
            { //Desactivar el resaltado del boton de icono.

                btnIcon.BackColor = backgroundColor;
                btnIcon.IconColor = iconColor;
                BorderColor = borderColor;
            }
            else
            {
                ApplyAppearanceSettings();//Refrescar la apariencia para desactivar el resaltado del boton de icono.
            }
        }

        //-> Adjuntar eventos: Label -> UserControl
        private void RJDatePicker_Click(object sender, EventArgs e)
        { //Adjuntar el evento clic del control de usuario(RJComboBox) a este evento clic de la etiqueta(dateText).
            this.OnClick(e);
            /* Este método de evento está suscrito al evento de clic de la etiqueta (recuerde que la etiqueta representa
             la mayor parte del control de usuario), por lo que cuando se hace clic en la etiqueta, 
             se ejecturá el evento clic del control de usuario.
             Este escenario es el mismo que al evento predeterminado OnValueChanged creado. */
        }
        private void RJDatePicker_MouseEnter(object sender, EventArgs e) //Adjunte los otros eventos de la misma manera.
        {
            this.OnMouseEnter(e);
        }
        private void RJDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }
        private void RJDatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        private void RJDatePicker_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }
        //Puedes seguir agregando los eventos que necesitas
        #endregion

        #region -> Métodos anulados
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Evento Load 
            dateText.Text = datePicker.Text;//Actualizar el texto del control de usuario.

            this.Visible = false;//Ocultar el control mientras se aplica la configuración de apariencia, esto evita el parpadeo al mostrar el formulario.
            ApplyAppearanceSettings(); //Aplicar la configuración de apariencia de la interfaz de usuario
            SetDatePickerLocation();//Actualizar la ubicacion de datePicker
            this.Visible = true;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetDatePickerLocation();//Actualizar la ubicacion de datePicker
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Estilo GLASS 
            if (style == ControlStyle.Glass)
            {
                //Aplicar esquinas redondeados(Si es el caso)  a la region + suavizado + dibujo de borde  del control de usuario.
                Utils.RoundedControl.RegionAndBorder(this, borderRadius, graph, borderColor, borderSize);
                if (borderRadius > 1)//Si el radio es mayor a 1, aplicar esquinas redondeados a la etiqueta.
                {
                    Utils.RoundedControl.RegionOnly(dateText, borderRadius - borderSize);
                    if (isDroppedDown == true)//Si la lista desplegable está abierto, dibujar un relleno en la zona del boton para eliminar superficie visible del fondo, puedes comentar el codigo para entender a lo que me refiero.
                    {
                        using (SolidBrush brush = new SolidBrush(borderColor))
                        {
                            graph.SmoothingMode = SmoothingMode.AntiAlias;
                            var rect = new Rectangle(btnIcon.Left + 5, btnIcon.Top + 0, btnIcon.Width, this.Height);
                            GraphicsPath path = Utils.RoundedControl.GetRoundedGPath(rect, borderRadius - borderSize);
                            graph.FillPath(new SolidBrush(borderColor), path);
                        }
                    }
                }
            }
            //Estilo SOLID
            else
            {
                //Simplemente aplicar esquinas redondeados(Si es el caso)  a la region + suavizado del control de usuario. 
                Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, graph);
                if (borderRadius > 1)//Si el radio es mayor a 1, aplicar esquinas redondeados a la etiqueta.
                    Utils.RoundedControl.RegionOnly(dateText, borderRadius - borderSize);
            }
        }

        #endregion

    }
}