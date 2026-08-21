using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;

namespace RJCodeUI_M1.RJControls
{
    [DefaultEvent("onTextChanged")]//Evento predeterminado al hacer doble clic en el control de usuario en el diseñador del formulario.
    public class RJTextBox : UserControl
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "UserControl" />
        /// Este cuadro de texto personalizado le permite cambiar 2 estilos principales, con un
        /// borde a su alrededor o borde único en la parte inferior (subrayado).
        /// También permite agregar una marca de agua (Placeholder-marcador de posición) y configurar si
        /// es un campo de contraseña. Además de personalizar el color del borde, radio de borde,
        /// tamaño de borde, color de fondo, color del texto y color del texto del marcador de posición,
        /// entre otros.
        /// Tutorial guia (Parte 1): https://youtu.be/CkpUQYzYCC8
        /// Tutorial guia (Parte 2): https://youtu.be/3wP6QqjiCCo
        /// </summary>
        /// 

        #region -> Campos
        //Campos
        private TextBoxStyle style;//Obtiene o establece el estilo del cuadro de texto (MatteBorder, FlaringBorder, MatteLine o FlaringLine)
        private Color placeHolderColor;//Obtiene o establece el color del texto del marcador de posición      
        private Color borderColor;//Obtiene o establece el color de borde.
        private Color borderFocusColor = Color.Black;//Obtiene o estable el color de borde en estado enfocado
        private int borderSize = 2;//Obtiene o establece el ancho del borde.
        private int borderRadius = 0; //Obtiene o establece el radio de borde.
        private int maxLength = 32767; //Obtiene o establece el numero maximo de caracteres del text box.  
        private string placeHolderText;//Obtiene o establece el texto del marcador de posición.       
        private bool isPlaceHolder;//Obtiene o establece si el cuadro de texto está en estado de marcador de posición.
        private bool isPasswordChar;//Obtiene o establece si es un carácter de contraseña o un campo de contraseña.
        private bool customizable; //Obtiene o establece si los colores del control son personalizables o están asignados según la configuración de apariencia
        private static int padFactor = 7;//Establece el valor para el relleno (Padding: Top | Bottom)
        //Controles   
        private TextBox textBox;//Establece u obtiene el cuadro de texto
        #endregion

        #region -> Eventos

        [Category("RJ Code Advance")]
        public event EventHandler onTextChanged;//Evento predeterminado de RJTextBox
        #endregion

        #region -> Constructor
        public RJTextBox()
        {
            this.DoubleBuffered = true;
            //Inicializar objetos      
            textBox = new TextBox();
            this.SuspendLayout();
            //
            // TextBox: (Ocupa la mayor parte del control de usuario de RJTextBox)
            //
            textBox.Location = new Point(2, 3);
            textBox.Dock = DockStyle.Fill;//LLENAR el control backBox
            textBox.BackColor = UIAppearance.BackgroundColor;
            textBox.BorderStyle = BorderStyle.None;//Remove border        
            textBox.Size = new System.Drawing.Size(230, 16);
            textBox.Enter += new EventHandler(TextBox_Enter);//Suscribir al evento Enter de TextBox para resaltar y eliminar el marcador de posición si es el caso.
            textBox.Leave += new EventHandler(TextBox_Leave);//suscribir al evento Leave de TextBox para quitar el resaltado y restablecer el marcador de posición si es el caso.

            textBox.TextChanged += new EventHandler(TextBox_TextChanged);//Suscribir al evento TextChanged del control y adjuntarlo al evento predeterminado OnTextChanged definido previamente (consulte la definición del método).

            /*El control textBox ocupa la mayor parte del control de usuario, por lo tanto,
                Es necesario adjuntar los eventos que ocurre en el cuadro de texto (textBox) a los eventos del control de usuario (RJTextBox),
                Es decir, por ejemplo en el evento Clic, cuando se hace clic en el cuadro de texto, tambien se debe ejecutar el evento clic del control de usuario (RJTextBox).
                Ver la definicion de los metodos de evento para entender mejor.*/
            textBox.Click += new EventHandler(RJTextBox_Click);
            textBox.KeyDown += new KeyEventHandler(RJTextBox_KeyDown);
            textBox.KeyPress += new KeyPressEventHandler(RJTextBox_KeyPress);
            textBox.KeyUp += new KeyEventHandler(RJTextBox_KeyUp);
            textBox.MouseEnter += new EventHandler(RJTextBox_MouseEnter);
            //Puede adjuntar los eventos que desee, si no existe, puede crearlo como lo hizo con el evento onTextChanged

            //
            // UserControl: RJTextBox
            //
            this.Controls.Add(textBox);//Agregar el control textBox   

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = UIAppearance.StyleColor;
            this.Padding = new Padding(10, padFactor, 10, padFactor);
            this.Size = new System.Drawing.Size(250, 32);
            this.Font = new Font(UIAppearance.TextFamilyName, UIAppearance.TextSize);
            this.ForeColor = UIAppearance.TextColor;
            this.ResumeLayout(false);
        }

        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el estilo del texto")]
        public TextBoxStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                if (this.DesignMode)//Vista previa de cambios en modo de diseño
                {
                    ApplyAppearanceSettings();
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores del control son personalizables o están asignados según la configuración de apariencia")]
        public bool _Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color de fondo")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                this.textBox.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del borde")]
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
        [Description("Obtiene o establece el color del borde en estado enfocado")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el ancho del borde")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value > 0 || value < 5)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el radio de las esquinas del control")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del texto")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si es un carácter de contraseña o un campo de contraseña")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                if (!isPlaceHolder && textBox != null && !textBox.IsDisposed)
                {
                    if (textBox.UseSystemPasswordChar != value)
                        textBox.UseSystemPasswordChar = value;
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si es multilínea")]
        public bool MultiLine
        {
            get { return this.textBox.Multiline; }
            set { this.textBox.Multiline = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el color del texto del marcador de posición")]
        public Color PlaceHolderColor
        {
            get { return placeHolderColor; }
            set
            {
                placeHolderColor = value;
                if (isPlaceHolder)
                    textBox.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el texto del marcador de posición")]
        public string PlaceHolderText
        {
            get { return placeHolderText; }
            set
            {

                placeHolderText = value;//Establecer el valor al campo marcador de posición.
                textBox.Text = "";//Establecer Texto en blanco en el cuadro de texto
                SetPlaceholder();//Establecer el marcador de posición al cuadro de texto.
            }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(32767)]
        [Description("Obtiene o establece el numero maximo de caracteres del text box.")]
        public int MaxLength
        {
            get { return maxLength; }
            set
            {
                maxLength = value;
                textBox.MaxLength = maxLength;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece la fuente")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();//Establecer una altura adecuada del control del usuario y textBox. 
            }
        }

        [Description("Obtiene o establece el texto del cuadro de texto")]
        public new string Text
        {
            get
            {
                if (isPlaceHolder) return ""; //Si el cuadro de texto es un marcador de posición, Devolver una cadena vacía
                else return textBox.Text;  //Caso contrario devolver el texto
            }
            set
            {
                RemovePlaceHolder();//Quitar marcador de posición si es el caso.
                textBox.Text = value; //Establecer valor.
                SetPlaceholder();//Establecer marcador de posición si es el caso.
            }
        }

        [Localizable(true)]
        [Category("RJ Code Advance")]
        [Description("Obtiene o establece las barras de desplazamiento - solo debe ser usando cuando sea multilinea")]
        public ScrollBars ScrollBars
        {
            get { return textBox.ScrollBars; }
            set { textBox.ScrollBars = value; }
        }

        [Browsable(false)]
        [Description("Anular la propiedad Padding para establecer un valor unico")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = new Padding(10, padFactor, 10, padFactor); }
        }

        #endregion

        #region -> Métodos privados

        private void SetPlaceholder()
        {//Establecer marcador de posición en el cuadro de texto siempre que el cuadro de texto esté vacío o sea nulo.
            if (this.DesignMode || this.IsDisposed || this.Disposing) return;
            Form parentForm = this.FindForm();
            if (parentForm != null && (parentForm.IsDisposed || parentForm.Disposing || parentForm.DialogResult != DialogResult.None)) return;
            if (textBox == null || textBox.IsDisposed || textBox.Disposing) return;

            if (string.IsNullOrWhiteSpace(textBox.Text) && string.IsNullOrWhiteSpace(placeHolderText) == false)
            {
                isPlaceHolder = true;//Establecer el cuadro de texto en el estado de marcador de posición.
                textBox.Text = placeHolderText;//Establezca el texto del marcador de posición como texto del cuadro de texto.
                textBox.ForeColor = placeHolderColor;//Establecer el color del texto del marcador de posición.
                if (isPasswordChar && textBox.UseSystemPasswordChar)
                    textBox.UseSystemPasswordChar = false;
            }
            else
            {
                isPlaceHolder = false;
                textBox.ForeColor = this.ForeColor;
                if (isPasswordChar && !textBox.UseSystemPasswordChar && !string.IsNullOrWhiteSpace(textBox.Text) && textBox.Text != placeHolderText)
                    textBox.UseSystemPasswordChar = true;
            }
        }
        private void RemovePlaceHolder()
        {//Este metodo se encarga de eliminar el marcador de posicion.          
            if (this.DesignMode || this.IsDisposed || this.Disposing) return;
            Form parentForm = this.FindForm();
            if (parentForm != null && (parentForm.IsDisposed || parentForm.Disposing || parentForm.DialogResult != DialogResult.None)) return;
            if (textBox == null || textBox.IsDisposed || textBox.Disposing) return;

            if (isPlaceHolder && string.IsNullOrWhiteSpace(placeHolderText) == false)
            {
                isPlaceHolder = false;//eliminar el estado del marcador de posición del cuadro de texto
                textBox.Text = "";//Texto vacío
                if (customizable)//Si es personalizable, establecer el color del texto especificado
                    textBox.ForeColor = this.ForeColor;
                else textBox.ForeColor = UIAppearance.PrimaryTextColor;//De lo contrario, establecer el color del texto especificado en la configuración de apariencia           

                if (isPasswordChar && !textBox.UseSystemPasswordChar)
                    textBox.UseSystemPasswordChar = true;
            }
        }

        private void UpdateControlHeight()
        {//Este método se encarga de establecer un alto adecuado para el control de usuario (RJTextBox) y cuadro de texto (textBox),
            //Esto para visualizar completamente el texto y tener un alto considerable en el control de usuario.
            if (MultiLine == false)//Solo actualizar el alto cuando el cuadro de texto No sea multilinea.
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;//Obtener el alto del texto y sumar 1.
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, txtHeight);//Establecer el alto mínimo del cuadro de texto.
                textBox.Multiline = false;

                this.Height = textBox.Height + (padFactor * 2);//Establecer el alto del control de usuario.
            }
        }

        private void ValidateControlRadius()
        {//Este metodo valida si el radio tiene un valor maximo permitido. El radio maximo es la mitad del alto del control de usuario.
            int maxRadius = this.Height / 2;
            if (borderRadius > maxRadius)
                borderRadius = maxRadius;
        }

        private void ApplyAppearanceSettings()
        {
            if (customizable == false)
            {

                BackColor = UIAppearance.BackgroundColor;
                this.ForeColor = UIAppearance.PrimaryTextColor;
                BorderFocusColor = Utils.ColorEditor.Lighten(UIAppearance.StyleColor, 15);
                if (UIAppearance.Theme == UITheme.Dark)
                    PlaceHolderColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 5);
                else PlaceHolderColor = Color.DarkGray;


                if (style == TextBoxStyle.MatteBorder || style == TextBoxStyle.MatteLine)
                {
                    if (UIAppearance.Theme == UITheme.Dark)
                        BorderColor = Utils.ColorEditor.Darken(UIAppearance.TextColor, 10);//Establecer el color del borde
                    else BorderColor = UIAppearance.TextColor;
                }
                else
                {
                    BorderColor = UIAppearance.StyleColor;
                }
            }
        }
        #endregion

        #region -> Métodos públicos

        public void Clear()
        {
            Text = string.Empty;
        }
        #endregion

        #region -> Métodos de evento

        //-> Evento predeterminado
        private void TextBox_TextChanged(object sender, EventArgs e)
        {//Adjuntar el evento predeterminado onTextChanged del control de usuario (RJTextBox)
            //al evento TextChanged del cuadro de texto (textBox).
            if (onTextChanged != null)
                onTextChanged.Invoke(sender, e);

        }

        //-> Acciones de los componentes
        private void TextBox_Enter(object sender, EventArgs e)
        {            //cuando el cursor ingresa en el cuadro de texto, eliminar el marcador de posición si es el caso 
            //y resaltar el borde
            if (this.IsDisposed || this.Disposing) return;
            Form f = this.FindForm();
            if (f != null && (f.IsDisposed || f.Disposing || f.DialogResult != DialogResult.None)) return;

            this.Invalidate();
            RemovePlaceHolder();
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            //cuando el cursor sale del cuadro de texto, restablecer el marcador de posición si es el caso y restablecer el color del borde
            if (this.IsDisposed || this.Disposing) return;
            Form f = this.FindForm();
            if (f != null && (f.IsDisposed || f.Disposing || f.DialogResult != DialogResult.None)) return;

            this.Invalidate();
            SetPlaceholder();
        }

        //-> Adjuntar eventos: TextBox -> UserControl
        private void RJTextBox_Click(object sender, EventArgs e)
        {//Adjuntar el evento clic del control de usuario(RJTextBox) en este evento clic del cuadro de texto(textBox).
            this.OnClick(e);
            /* Este método de evento está suscrito al evento de clic del cuadro de texto, recuerde que representa
       la mayor parte del control de usuario, por lo que cuando se hace clic en el cuadro de texto, 
       se ejecturá el evento clic del control de usuario.
       Este escenario es el mismo que al evento predeterminado onTextChanged creado. */
        }
        private void RJTextBox_MouseEnter(object sender, EventArgs e) //Adjunte los otros eventos de la misma manera
        {
            this.OnMouseEnter(e);
        }
        private void RJTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }
        private void RJTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        private void RJTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }
        //Puedes seguir agregando los eventos que necesitas
        #endregion

        #region -> Métodos anulados

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            Color currentBorderColor;
            //Establecer el color de borde actual, es decir color de borde enfocado o no. 
            if (textBox.Focused)
                currentBorderColor = borderFocusColor;
            else currentBorderColor = borderColor;

            //Dibujar borde rectangular en el estilo MatteBorder o FlaringBorder
            if (style == TextBoxStyle.MatteBorder || style == TextBoxStyle.FlaringBorder)
            {
                //-> Aplicar esquinas redondeados al control de usuario-> REGION + SUAVIZADO + BORDE
                Utils.RoundedControl.RegionAndBorder(this, borderRadius, graph, currentBorderColor, borderSize);

                //-> Aplicar esquinas redondeados al cuadro de texto-> SOLO REGION
                if (borderRadius > 15)//El borde de radio debe ser mayor a 15, porque si es menor no es necesario aplicar una region redondeada.
                {
                    if (!MultiLine) //Si no es multilinea el radio de borde es igual al doble del tamaño de borde
                        Utils.RoundedControl.RegionOnly(textBox, borderSize * 2);
                    else //Caso contrario, el radio de borde es al valor establecido menos
                        Utils.RoundedControl.RegionOnly(textBox, borderRadius - (borderSize * 2));
                }
            }
            //Dibujar borde subrayado en el estilo MatteLine o FlaringLine
            else
            {
                using (Pen penBorder = new Pen(currentBorderColor, borderSize))
                {
                    //-> Aplicar esquinas redondeados al control de usuario-> REGION + SUAVIZADO
                    Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, graph);
                    //Dibujar una linea en la parte inferior sin suavizado.
                    graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    graph.DrawLine(penBorder, 0, this.Height - 1F, this.Width, this.Height - 1F);
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyAppearanceSettings();
            UpdateControlHeight();
            ValidateControlRadius();
        }
        #endregion

    }
}
