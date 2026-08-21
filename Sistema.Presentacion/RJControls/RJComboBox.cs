using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using RJCodeUI_M1.Settings;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace RJCodeUI_M1.RJControls
{
    [DefaultEvent("OnSelectedIndexChanged")] //Evento predeterminado al hacer doble clic en el control en el diseñador.
    public class RJComboBox : UserControl
    {
        /// <summary>
        /// Esta clase hereda la clase <see cref = "UserControl" />.
        /// Este control expone la mayoría de las propiedades y eventos esenciales más utilizados de
        /// un cuadro combinado normal, puede agregar las funcionalidades que probablemente necesite y que falten aquí.
        /// Por otro lado, puede cambiar el estilo a sólido o vidrio, también personalizar el menú desplegable
        /// icono de flecha, color del borde, tamaño de borde y radio de borde.      
        /// Tutorial guia: https://youtu.be/5V6ZD2mAUw8 (Custom ComboBox - UserControl)
        /// </summary>

        #region -> Campos
        //Campos
        private ControlStyle style;//Estilo (sólido o vidrio)
        private Color backgroundColor;//Obtiene o establece el color de fondo.
        private Color iconColor;//Obtiene o establece el el color de icono.
        private Color borderColor;//Obtiene o establece el color de borde.
        private int borderSize = 1;//Obtiene o establece el tamaño de borde.
        private int borderRadius = 0;//Obtiene o establece el radio de borde.
        private bool customizable;//Obtiene o establece si el control es personalizable.
        //Controles
        private ComboBox comboList;//Obtiene o establece el Cuadro combinado (no es visible, pero puede mostrar la lista desplegable)
        private IconButton btnIcon;//Obtiene o establece el Icono de flecha desplegable (botón para mostrar la lista desplegable)
        private Label label;//Obtiene o establece la Etiqueta(para mostrar el texto del cuadro combinado)

        ///<Note>:ICON BUTTON es proporcionado por la librería <see cref = "FontAwesome.Sharp" />
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp </Note>
        #endregion

        #region -> Eventos

        [Category("RJ Code Advance")]
        public event EventHandler OnSelectedIndexChanged;//Evento principal del cuadro combinado

        #endregion

        #region -> Constructor

        public RJComboBox()
        {
            comboList = new ComboBox();
            btnIcon = new IconButton();
            label = new Label();

            this.SuspendLayout();
            // 
            // ComboBox: Lista combinada
            //           
            comboList.Font = new Font("Microsoft Sans Serif", 9.5F);
            comboList.FormattingEnabled = true;
            comboList.Size = new Size(170, 21);
            comboList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Suscribir el evento SelectedIndexChanged del control y adjuntarlo al evento predeterminado OnSelectedIndexChanged definido previamente (consulte la definición del método).
            comboList.DropDownClosed += new EventHandler(ComboBox_DropDownClosed);
            comboList.TextChanged += new EventHandler(ComboBox_TextChanged);
            // 
            // IconButton: Dropdown Arrow Icon
            // 
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Dock = DockStyle.Right;
            btnIcon.BackColor = Color.WhiteSmoke;
            btnIcon.IconChar = IconChar.AngleDown;//Establecer icono de flecha desplegable
            btnIcon.IconColor = Color.MediumSlateBlue;
            btnIcon.IconSize = 22;
            btnIcon.Location = new Point(169, 1);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(BtnIcon_Click);//Suscribir al evento BtnIcon.Click ( Para Mostrar lista desplegable del cuadro combinado)
            // 
            // Label: ComboBox Label (Es la parte visual, cara o supericie de RJComboBox, muestra el texto y rellena el control de usuario.)
            // 
            label.BackColor = Color.WhiteSmoke;
            label.Dock = DockStyle.Fill;//Establecer relleno
            label.Location = new Point(1, 1);
            label.Padding = new Padding(8, 0, 0, 0);
            label.Size = new Size(168, 30);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "";
            label.Controls.Add(btnIcon);//Agregar el boton de icono a la etiqueta.
            label.Font = new Font(UIAppearance.TextFamilyName, UIAppearance.TextSize);//Font

            /*Como la etiqueta es la superfice de RJComboBox y ocupa la mayor parte del control de usuario,
            Es necesario adjuntar los eventos que ocurre en la etiqueta (label) a los eventos del control de usuario (RJComboBox),
            Es decir, por ejemplo en el evento Clic, cuando se hace clic en la etiqueta, tambien se debe ejecutar el evento clic del control de usuario (RJComboBox).
            Ver la definicion de los metodos de evento para entender mejor.*/
            label.Click += new EventHandler(RJComboBox_Click);
            label.KeyDown += new KeyEventHandler(RJComboBox_KeyDown);
            label.KeyPress += new KeyPressEventHandler(RJComboBox_KeyPress);
            label.KeyUp += new KeyEventHandler(RJComboBox_KeyUp);
            label.MouseEnter += new EventHandler(RJComboBox_MouseEnter);
            //Puedes adjuntar los eventos que desee, si no existe, puede crearlo se hizo con el evento OnSelectedIndexChanged.

            // 
            // User control: RJComboBox
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.MediumSlateBlue;
            BorderSize = borderSize;//Establecer tamaño de borde para aplicar los ajustes necesarios.
            this.Size = new Size(200, 32);
            //Agregar los controles
            this.Controls.Add(label);//Rellena el espacio restante (muestra el texto del cuadro combinado)         
            this.Controls.Add(comboList);//Está en el fondo, detrás de la etiqueta (no es visible, pero muestra la lista desplegable).
            //Este orden es importante, los últimos controles se agregan primero (de abajo hacia arriba).
            this.ResumeLayout(false);
            SetComboComponentLocation();
        }
        #endregion

        #region -> Propiedades

        #region - Propiedades de apariencia

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el estilo (vidrio o sólido)")]
        public ControlStyle Style
        {
            get { return style; }
            set
            {
                style = value;//Establecer el valor
                //Actualizar la configuración de apariencia-> vista previa de los cambios en el modo de diseño.
                if (this.DesignMode) ApplyAppearanceSettings();
            }
        }
        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece si el control es personalizable")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }


        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de fondo")]
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
                label.BackColor = backgroundColor;
                btnIcon.BackColor = backgroundColor;
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de borde")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate(); //Dibujar el borde (Redibujar el control)    
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el tamaño de borde")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Padding = new Padding(borderSize + 1);//Establecer la propiedad Padding para aplicar un espacio y dibujar el borde.
                    SetComboComponentLocation();//Actualizar la ubicación del combobox.
                    this.Invalidate();//Dibujar el borde (Redibujar el control)
                }
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el radio de borde")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    SetComboComponentLocation();//Actualizar la ubicación del combobox.
                    this.Invalidate();//Dibujar el borde y radio (Redibujar el control)
                }
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de icono")]
        public Color IconColor
        {
            get { return btnIcon.IconColor; }
            set
            {
                iconColor = value;
                btnIcon.IconColor = iconColor;
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el estilo desplegable")]
        public ComboBoxStyle DropDownStyle
        {
            get { return comboList.DropDownStyle; }
            set
            {
                comboList.DropDownStyle = value;
                if (comboList.DropDownStyle == ComboBoxStyle.Simple)
                    btnIcon.Visible = false;
                else
                    btnIcon.Visible = true;
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de fondo de la lista desplegable")]
        public Color DropDownBackColor
        {
            get { return comboList.BackColor; }
            set { comboList.BackColor = value; }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de texto de la lista desplegable")]
        public Color DropDownTextColor
        {
            get { return comboList.ForeColor; }
            set { comboList.ForeColor = value; }
        }


        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el color de texto del combo")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                label.ForeColor = value;
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
                label.Font = value;
            }
        }

        [Category("RJ Code - Appearance")]
        [Description("Obtiene o establece el texto")]
        public string Texts
        {
            get { return label.Text; }
            set
            {
                label.Text = value;
            }
        }

        #endregion

        #region - Propiedades funcionales

        [Category("RJ Code - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        [Description("Obtiene un objeto que representa la colección de elementos contenidos en este ComboBox")]
        public ComboBox.ObjectCollection Items
        {
            get { return comboList.Items; }
            /*
             Esta propiedad expone toda la funcionalidad de la propiedad ITEMS del combobox normal (ComboBox.ObjectCollection),
             como agregar una colección de cadenas del diseñador, utilizando los Métodos Items.Add, Items.AddRange, Items.Remove, 
             Items.Count, etc.
             En resumen, esta propiedad le permite obtener una referencia a la lista de elementos que están almacenados actualmente
             en el ComboBox. Con esta referencia, puede agregar elementos, eliminar elementos, y obtener un recuento de los elementos
             de la colección.
             Más información:
             https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.items?view=net-5.0#System_Windows_Forms_ComboBox_Items
             */
        }

        [Category("RJ Code - Data")]
        [AttributeProvider(typeof(IListSource))]//Fuente de lista
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Obtiene o establece la fuente de datos de este ComboBox.")]
        public object DataSource
        {
            get { return comboList.DataSource; }
            set { comboList.DataSource = value; }
        }

        [Category("RJ Code - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design")]
        [Description("Obtiene o establece la propiedad que se mostrará para este ListControl. (Heredado de ListControl)")]
        public string DisplayMember
        {
            get { return comboList.DisplayMember; }
            set { comboList.DisplayMember = value; }
        }

        [Category("RJ Code - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        [Description("Obtiene o establece la ruta de la propiedad que se usará como valor real para los elementos en ListControl. (Heredado de ListControl)")]
        public string ValueMember
        {
            get { return comboList.ValueMember; }
            set { comboList.ValueMember = value; }
        }

        [Browsable(false)]//Propiedad no visible en el cuadro de propiedad
        [Description("Obtiene o establece el índice que especifica el elemento seleccionado actualmente.")]
        public int SelectedIndex
        {
            get { return comboList.SelectedIndex; }
            set
            {
                if (value >= 0)
                {
                    comboList.SelectedIndex = value;
                }
            }
        }

        [Browsable(false)] //Propiedad no visible en el cuadro de propiedad    
        public object SelectedValue
        {
            get { return this.comboList.SelectedValue; }
        }


        [Browsable(false)]//Propiedad no visible en el cuadro de propiedad     
        public object SelectedItem
        {
            get { return this.comboList.SelectedItem; }
        }

        //Combo Box Auto complete
        [Browsable(true)]
        [Category("RJ Code - Data AC")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return comboList.AutoCompleteCustomSource; }
            set { comboList.AutoCompleteCustomSource = value; }
        }

        [Browsable(true)]
        [Category("RJ Code - Data AC")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return comboList.AutoCompleteMode; }
            set { comboList.AutoCompleteMode = value; }
        }

        [Browsable(true)]
        [Category("RJ Code - Data AC")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return comboList.AutoCompleteSource; }
            set { comboList.AutoCompleteSource = value; }
        }
        //Puede agregar más propiedades del cuadro combinado normal si lo necesita
        #endregion

        #region - Propiedades anulados
        public new string Text
        {//Anular la propiedad de texto del control de usuario y establecer u obtener el texto de la etiqueta del cuadro combinado.
            get { return label.Text; }
            set
            {
                label.Text = value;
            }
        }
        #endregion
        #endregion

        #region -> Métodos privados

        private void ApplyAppearanceSettings()
        {//Aplicar la configuración de apariencia           

            if (customizable == false)
            {
                comboList.ForeColor = UIAppearance.TextColor;
                comboList.BackColor = UIAppearance.ItemBackgroundColor;

                switch (style)
                {
                    case ControlStyle.Solid: //Estilo sólido
                        BorderColor = UIAppearance.StyleColor;
                        BorderSize = 0;
                        label.ForeColor = Color.White;
                        btnIcon.IconColor = Color.White;
                        this.BackColor = UIAppearance.StyleColor;
                        break;

                    case ControlStyle.Glass: //Estilo vidrio

                        btnIcon.IconColor = UIAppearance.StyleColor;
                        label.ForeColor = UIAppearance.PrimaryTextColor;
                        this.BackColor = UIAppearance.BackgroundColor;

                        if (UIAppearance.Theme == UITheme.Dark)
                            BorderColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 10);
                        else BorderColor = UIAppearance.TextColor;
                        break;
                }
            }
        }
        private void SetComboComponentLocation()
        {
            //Actualizar el tamaño y ubicacion del ComboBox
            comboList.Width = label.Width - btnIcon.Width;
            if (borderRadius > 2)
                comboList.Location = new Point(this.Width - comboList.Width - this.Padding.Right - (borderRadius / 2) - 2, label.Bottom - comboList.Height);
            else
                comboList.Location = new Point(this.Width - comboList.Width - this.Padding.Right, label.Bottom - comboList.Height);
        }
        #endregion

        #region -> Métodos públicos

        public void Clear()
        {//Limpiar control
            this.label.Text = "";
            this.comboList.Items.Clear();
        }
        #endregion

        #region -> Métodos de evento

        //-> Evento predeterminado
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {//Adjuntar el evento predeterminado OnSelectedIndexChanged del control de usuario (RJComboBox)
            //al evento SelectedIndexChanged del ComboBox (comboList).
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(comboList, e);
            //Cuando se selecciona un elemento o cambia el texto de la lista desplegable, actualizar el texto de la etiqueta.
            label.Text = comboList.Text;
        }

        //-> Actiones de los componentes
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            label.Text = comboList.Text;
            //Cuando se selecciona un elemento o cambia el texto de la lista desplegable, actualizar el texto de la etiqueta.
        }
        private void BtnIcon_Click(object sender, EventArgs e)
        {//Cuando se hace clic en el botón del icono de flecha desplegable, mostrar el cuadro combinado desplegable.

            comboList.Select();//Por precaución, el combobox debe estar enfocado antes, a veces ocurren algunos problemas.
            comboList.DroppedDown = true;//Establecer la propiedad DroppedDown en true para mostrar la lista desplegable.
            if (customizable)//Si es personalizable
            {
                switch (style)//Aplicar un resaltado al botón de icono de flecha desplegable.
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
            else //Si no es personalizable
            {
                switch (style)//Aplicar un resaltado al botón de icono de flecha desplegable.
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
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {//Sucede cuando se cierra la lista desplegable

            if (customizable)
            {
                //Desactivar el resaltado del boton de icono desplegable.
                btnIcon.BackColor = backgroundColor;
                btnIcon.IconColor = iconColor;
                BorderColor = borderColor;
            }
            else
            {
                ApplyAppearanceSettings();//Refrescar la apariencia para desactivar el resaltado del boton de icono desplegable.
            }

        }

        private void RJComboBox_Click(object sender, EventArgs e)
        {//Adjuntar el evento clic del control de usuario(RJComboBox) en este evento clic de la etiqueta(dateText).
            this.OnClick(e);
            comboList.Select();
            if (DropDownStyle == ComboBoxStyle.DropDownList)//Cuando el estilo es DropDownList, la lista desplegable se debe abrir al hacer clic en cualquier parte del control (De la misma manera como ocurre en un ComboBox tradicional).
                comboList.DroppedDown = true;//Establecer la propiedad DroppedDown en true para mostrar la lista desplegable.
            /* Este método de evento está suscrito al evento de clic de la etiqueta (recuerde que la etiqueta representa
             la mayor parte del control de usuario), por lo que cuando se hace clic en la etiqueta, 
             se ejecturá el evento clic del control de usuario.
             Este escenario es el mismo que al evento predeterminado OnSelectedIndexChanged creado. */
        }

        //-> Adjuntar eventos: Label -> UserControl
        private void RJComboBox_MouseEnter(object sender, EventArgs e) //Adjunte los otros eventos necesarios de la misma manera.
        {
            this.OnMouseEnter(e);
        }
        private void RJComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }
        private void RJComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        private void RJComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }
        //Puedes seguir agregando los eventos que necesitas
        #endregion

        #region -> Metodos anulados

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetComboComponentLocation();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Evento Load
            this.Visible = false;//Ocultar el control mientras se aplica la configuración de apariencia, esto evita el parpadeo al mostrar el formulario.
            ApplyAppearanceSettings(); //Aplicar la configuración de apariencia de la interfaz de usuario
            this.Visible = true;
            SetComboComponentLocation();
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
                    Utils.RoundedControl.RegionOnly(label, borderRadius - borderSize);
                    if (comboList.DroppedDown == true)//Si la lista desplegable está abierto, dibujar un relleno en la zona del boton para eliminar superficie visible del fondo, puedes comentar el codigo para entender a lo que me refiero.
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
                    Utils.RoundedControl.RegionOnly(label, borderRadius - borderSize);
            }
        }
        #endregion

    }
}
