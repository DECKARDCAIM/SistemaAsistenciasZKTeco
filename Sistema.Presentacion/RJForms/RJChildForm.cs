using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Drawing;
using FontAwesome.Sharp;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;
using RJCodeUI_M1.RJControls;

namespace RJCodeUI_M1.RJForms
{
    public class RJChildForm : RJBaseForm
    {
        /// Esta clase hereda de la clase <see cref = "RJBaseForm" />
        ///
        /// <summary>
        /// En esta clase, se establece un tamaño predeterminado del formulario, elimina el borde del formulario,
        /// y se agrega una barra de título personalizada y un área de cliente usando paneles, así como agregar los botones
        /// para maximizar, minimizar, cerrar y el menú desplegable para la lista de opciones
        /// del formulario. (SnapWindow izquierda-derecha, Ayuda).
        /// El tamaño del formulario predeterminado es igual al tamaño del panel escritorio del formulario principal,
        /// puede cambiar eso estableciendo la propiedad _DesktopPanelSize en false.
        ///</summary>

        #region -> Campos

        /// Campos     
        private IContainer components = null; //Contenedor de componentes para los que no son elementos secundarios del formulario.
        /// Permite que todos los componentes agregados sean eliminados con el método Dispose por el contenedor de componentes
        ///<see cref="protected override void Dispose(bool disposing)"/>
        private bool isChildForm; // Obtiene o establece si es un formulario hijo
        private int markerPosition; // Obtiene o establece la ubicación del marcador del botón del menú del formulario
        private string helpMessage; // Obtiene o establece el mensaje de ayuda del formulario para el usuario
        private IconChar formIcon; // Obtiene o establece el icono de formulario
        private bool disableFormOptions; // Deshabilita o habilita el menú desplegable de las Opciones de formulario de Windows
        private bool desktopPanelSize; // Obtiene o establece si el tamaño del formulario es igual al tamaño del panel del escritorio o si se puede personalizar desde la propiedad de tamaño del cuadro de propiedades del diseñador (el valor predeterminado es verdadero)
        private Color supernovaColor = UIAppearance.Style == UIStyle.Supernova ? RJColors.GetSupernovaColor() : Color.CornflowerBlue;

        /// Controles  
        protected Panel pnlClientArea;
        private Panel pnlTitleBar;//Establece la barra de título del formulario
        private Label lblCaption;//Establece el título de formulario
        private RJDragControl dragControl;//Establece el control de arrastre del formulario (es un componente, el constructor acepta un parámetro de tipo IContainer)
        private IconButton btnFormIcon;//Establece el botón de icono de formulario
        private RJDropdownMenu dmFormOptions;//Establece el menú desplegable de las opciones de formulario de Windows (es un componente, el constructor acepta un parámetro de tipo IContainer)
        private IconMenuItem miHelp;//Establece el elemento del menú de ayuda.


        ///<Note>:ICON MENU ITEM, ICON BUTTON e ICON CHAR es proporcionado por lo librería <see cref="FontAwesome.Sharp"/>.
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp </Note>
        #endregion

        #region -> Constructor

        /// Constructor
        public RJChildForm()
        {
            InitializeItems();
        }

        /// Inicializar componente
        private void InitializeItems()
        {
            //Inicializar los componentes para el diseño del formulario: agregar la barra de título, botones para maximizar, minimizar,
            // menú desplegable de opciones de formulario y el área de cliente del formulario * /
            components = new System.ComponentModel.Container();//inicializar contenedor

            #region -Instanciación de controles

            pnlClientArea = new Panel();
            pnlTitleBar = new Panel();
            lblCaption = new Label();
            dragControl = new RJDragControl(pnlTitleBar, this, components);//Control de arrastre, agregar al contenedor de componentes
            dmFormOptions = new RJDropdownMenu(components);//Agregar al contenedor de componentes
            btnFormIcon = new FontAwesome.Sharp.IconButton();
            miHelp = new FontAwesome.Sharp.IconMenuItem();

            pnlTitleBar.SuspendLayout();
            #endregion

            #region -Barra de título del formulario
            //
            //  Panel: Form Title Bar 
            //           
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Size = new Size(960, 40);
            pnlTitleBar.Controls.Add(btnFormIcon);//Agregar controles 
            pnlTitleBar.Controls.Add(lblCaption);
            pnlTitleBar.Controls.Add(this.btnMinimize);
            pnlTitleBar.Controls.Add(this.btnMaximize);
            pnlTitleBar.Controls.Add(this.btnClose);
            // 
            // Icon Button: Icono del formulario (FontAwesome.Sharp library)
            //            
            btnFormIcon.Name = "btnIcon";
            btnFormIcon.Cursor = Cursors.Hand;
            btnFormIcon.FlatStyle = FlatStyle.Flat;
            btnFormIcon.FlatAppearance.BorderSize = 0;
            btnFormIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            btnFormIcon.IconChar = FontAwesome.Sharp.IconChar.Folder;
            btnFormIcon.IconColor = Color.WhiteSmoke;
            btnFormIcon.IconSize = 25;
            btnFormIcon.Rotation = 0D;
            btnFormIcon.Location = new Point(0, 0);
            btnFormIcon.Size = new Size(40, 40);
            btnFormIcon.UseVisualStyleBackColor = false;//Eventos            
            btnFormIcon.MouseEnter += new System.EventHandler(FormIcon_MouseEnter);
            btnFormIcon.MouseLeave += new System.EventHandler(FormIcon_MouseLeave);
            btnFormIcon.Click += new System.EventHandler(FormIcon_Click);
            FormIcon = IconChar.Folder;
            // 
            // Label: Título del formulario
            // 
            lblCaption.Name = "lblCaption";
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblCaption.ForeColor = Color.WhiteSmoke;
            lblCaption.Location = new Point(40, 10);
            //
            // Button: Botones de la caja de control
            // 
            this.btnClose.Dock = DockStyle.Right;
            this.btnMaximize.Dock = DockStyle.Right;
            this.btnMinimize.Dock = DockStyle.Right;

            #endregion

            #region -Opciones de formulario
            // 
            // Icon MenuItem: Ayuda (FontAwesome.Sharp library)
            // 
            miHelp.Name = "miHelp";
            miHelp.Text = "Ayuda";
            miHelp.IconSize = 21;
            miHelp.IconChar = IconChar.Question;
            miHelp.IconColor = RJColors.FantasyColorScheme4;
            miHelp.Click += new System.EventHandler(HelpMessage_Click);
            //        
            //  DropdownMenu: Opciones de formulario
            //
            dmFormOptions.Name = "dmFormOptions";
            dmFormOptions.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dmFormOptions.Items.AddRange(new ToolStripItem[] {//Agregar elementos del menú desplegable
            miSnapLeft,//Snap Window Left
            miSnapRight,//Snap Window Right
            miExitSnap,//Exit Snap Window
            miHelp});
            dmFormOptions.OwnerIsMenuButton = false;
            dmFormOptions.VisibleChanged += new EventHandler(FormOptions_VisibleChanged);

            #endregion

            #region -Area de cliente del formualario

            // Panel: Area de cliente (Form Body)                      
            pnlClientArea.Dock = DockStyle.Fill;
            pnlClientArea.Location = new Point(0, 40);
            pnlClientArea.Name = "pnlClientArea";
            pnlClientArea.Size = new Size(960, 485);
            pnlClientArea.AutoScroll = true;
            #endregion

            #region -RJ Child Form Properties
            //
            // RJChildForm          
            //
            this.Name = "RJChildForm";
            this.Text = "RJ Child form";
            this.Controls.Add(pnlClientArea);
            this.Controls.Add(pnlTitleBar);
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;//Desactivar el modo de escala automática para mantener el tamaño del formulario establecido en la propiedad DefaultSize
            this.FormBorderStyle = FormBorderStyle.None;//Formulario sin bordes   
            this.MinimumSize = new Size(300, 180);//Tamaño mínimo del formulario
            this.DoubleBuffered = true;
            this.Resize += new System.EventHandler(Form_Resize);
            this.Deactivate += new EventHandler(Form_Deactivated);//suscribir evento deshabilitado para cambiar / opacar el color de la barra de título
            this.Activated += new EventHandler(Form_Activated);//Subscribir evento Activado para recuperar el color de la barra de titulo  
            desktopPanelSize = true;//Establecer como valor predeterminado. 
            pnlTitleBar.PerformLayout();
            pnlTitleBar.ResumeLayout();
            #endregion
        }

        #endregion

        #region -> Propiedades

        //Valor
        [Browsable(false)]
        public bool IsChildForm
        { //Obtiene o establece si es un formulario hijo
            get { return isChildForm; }
            set
            {
                isChildForm = value;
                if (isChildForm == true) //Si el formulario es un formulario hijo, establecer como formulario NO redimensionable.
                    this.Resizable = false;
                else//Caso contrario, establecer como formulario redimensionable. 
                    this.Resizable = true;
                ApplyApperanceSettings();//Volver a aplicar la configuración cuando esta propiedad cambie.
            }
        }

        [Category("RJ Code Advance")]
        public bool _DesktopPanelSize
        {
            // Obtiene o establece si el tamaño del formulario es igual al tamaño del panel escritorio del formulario principal
            // o se puede personalizar desde la propiedad de tamaño del cuadro de propiedades del diseñador.
            get { return desktopPanelSize; }
            set
            {
                desktopPanelSize = value;//Establecer valor
                if (value == true)//Si el valor es verdadero, establecer el tamaño del panel escritorio como el tamaño del formulario + la altura de la barra de título
                {
                    this.Size = new Size(960, 560);
                }
            }
            /* Nota> No cambie el nombre, al menos el subguión (_). Las propiedades se ejecutan en
              orden alfabético, por lo que esta propiedad debe ejecutarse antes que la propiedad ClientSize. */
        }

        [Category("RJ Code Advance")]
        public bool DisableFormOptions
        {//Deshabilitar el menú desplegable de Opciones de formulario
            get
            {
                return disableFormOptions;
            }

            set
            {
                disableFormOptions = value;
                if (value == true)
                {
                    btnFormIcon.Cursor = Cursors.Arrow;
                    btnFormIcon.FlatAppearance.MouseOverBackColor = UIAppearance.StyleColor;
                    btnFormIcon.FlatAppearance.MouseDownBackColor = UIAppearance.StyleColor;
                }
            }
        }

        [Browsable(false)]
        public int MarkerPosition
        {//Obtiene o establece la ubicación del marcador del botón menú del formulario principal
            get { return markerPosition; }
            set { markerPosition = value; }
        }

        // Design
        public new Size ClientSize
        {
            // Ocultar el tamaño del cliente para que el tamaño predeterminado (Tamaño del panel de escritorio del formulario principal) surta efecto en los formularios derivados
            // Puede deshabilitarlo estableciendo la propiedad _DesktopPanelSize en false
            get { return base.ClientSize; }
            set
            {
                if (desktopPanelSize == false)
                {//Si el campo desktopPanelSize es falso, establecer el valor como tamaño del formulario
                    base.ClientSize = value;
                }
                else
                {
                    // De lo contrario, mantener el tamaño predeterminado establecido
                }
            }
        }
        protected override Size DefaultSize
        {//Formulario tamaño predeterminado
            get { return new Size(960, 560); }
            /// <Nota> El tamaño predeterminado del formulario debe ser igual al tamaño del panel escritorio del formulario principal + Barra de título de altura (40)
            /// esto para evitar problemas con la ubicación y visualización de los controles cuando se muestra el formulario en el panel escritorio.
            /// Además de tener un diseño exacto y elegante
            /// donde puede tener más control sobre las propiedades de anclaje y acoplamiento del control </note>
        }
        public override string Text
        {//Anular propiedad de texto para ampliar funcionalidad.
            get { return base.Text; }
            set
            {
                base.Text = value;
                lblCaption.Text = value;//Establecer título de formulario
            }
        }

        [Category("RJ Code Advance")]
        [TypeConverter(typeof(FontAwesome.Sharp.IconConverter))]
        public IconChar FormIcon
        {//Obtener o establecer el icono de formulario
            get { return formIcon; }
            set
            {
                formIcon = value;
                btnFormIcon.IconChar = formIcon;
            }
        }

        [Category("RJ Code Advance")]
        public string Caption
        {//Obtener o establecer el Título del formulario
            get { return this.Text; }
            set
            {
                this.Text = value;
                lblCaption.Text = value;//Establecer título de formulario
            }
        }

        [Category("RJ Code Advance")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string HelpMessage
        {//mensaje de ayuda del formulario para el usuario
            get { return helpMessage; }
            set
            {
                helpMessage = value;
            }
        }
        #endregion

        #region  -> Métodos privados

        private void ApplyApperanceSettings()
        {//Aplicar la configuración del tema

            this.pnlClientArea.BackColor = UIAppearance.BackgroundColor;//Establecer el color de fondo del formulario

            if (IsChildForm)//Si es un formulario hijo. Es decir se muestra en el panel del escritorio del formulario principal.
            {
                pnlTitleBar.Visible = false;//Ocultar barra de título           
                this.BorderSize = 0;//Eliminar borde de formulario                         
            }
            else // No es un formulario hijo, es decir, se muestra fuera del panel de escritorio del formulario principal
            {// El formulario tiene la barra de título y el borde
                if (!this.DesignMode)
                    this.CenterToScreen();//Centrar ventana
                if (UIAppearance.Style == UIStyle.Supernova)
                {
                    pnlTitleBar.BackColor = RJColors.DarkItemBackground;
                    btnFormIcon.IconColor = supernovaColor;
                }
                else
                {
                    pnlTitleBar.BackColor = UIAppearance.PrimaryStyleColor;//establecer color de fondo de la barra de título
                    btnFormIcon.IconColor = Color.WhiteSmoke;
                }
                pnlTitleBar.Visible = true; // Mostrar la barra de título
                lblCaption.Text = this.Text; // Establecer título del formulario
                btnFormIcon.IconChar = FormIcon; // Establecer icono de formulario               
                this.BorderSize = UIAppearance.FormBorderSize; // El ancho del borde del formulario será igual al borde de la configuración del usuario
                this.BorderColor = UIAppearance.FormBorderColor; // Establecer el color del borde del formulario

            }
        }
        #endregion

        #region -> Anulaciones
        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">verdadero si los recursos gestionados deben eliminarse; de lo contrario, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();//Desechar los componentes
            }
            base.Dispose(disposing);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (isChildForm == false)//Si la propiedad IsChildform es TRUE, el metodo ApplyApperanceSettings es llamado ahí, por lo que no es necesario volver a llamarlo.
                ApplyApperanceSettings();//Aplicar la configuración de apariencia en el evento load.
        }
        #endregion

        #region -> Métodos de evento

        private void FormIcon_MouseEnter(object sender, EventArgs e)
        {   // Si el puntero del mouse se desplaza sobre el botón del icono del formulario, cambiar el icono del formulario a lista de opciones
            // siempre y cuando el menú desplegable de opciones del formulario no esté deshabilitado y el menú desplegable de opciones no se haya mostrado
            if (disableFormOptions == false)
            {
                if (dmFormOptions.Visible == false)
                    btnFormIcon.IconChar = IconChar.ListUl;//Icono de lista de opciones
            }
        }
        private void FormIcon_MouseLeave(object sender, EventArgs e)
        {  // Si el puntero del mouse deja el botón del icono de formulario, volver a establecer el icono de formulario.
            // siempre y cuando el menú desplegable de opciones del formulario no esté deshabilitado y no se haya mostrado
            if (disableFormOptions == false)
            {
                if (dmFormOptions.Visible == false)
                    btnFormIcon.IconChar = FormIcon;//Icono del formulario
            }
        }
        private void FormIcon_Click(object sender, EventArgs e)
        {// si se hace clic en el icono del formulario y el menú desplegable de opciones del formulario no está deshabilitado
            // Mostrar el Menú desplegable de la lista de opciones del formulario 
            if (disableFormOptions == false)
                this.dmFormOptions.Show(pnlTitleBar, DropdownMenuPosition.LeftBottom);//Mostrar en la parte inferior izquierda del formulario
        }
        private void FormOptions_VisibleChanged(object sender, EventArgs e)
        {//Cuando el menú desplegable de opciones de formulario se muestra o cierra

            if (dmFormOptions.Visible == true)//Si menú está mostrado
            {//mantener el botón resaltado y establecer el icono en la lista de opciones              
                btnFormIcon.BackColor = ColorEditor.Darken(btnFormIcon.BackColor, 15);
                btnFormIcon.FlatAppearance.MouseOverBackColor = btnFormIcon.BackColor;
                btnFormIcon.IconChar = IconChar.ListUl;//Icono de lista de opciones
            }
            else //Si el menú esta oculto
            {//Devolver el color y el icono predeterminados
                if (UIAppearance.Style == UIStyle.Supernova)
                    btnFormIcon.BackColor = RJColors.DarkItemBackground;
                else btnFormIcon.BackColor = UIAppearance.PrimaryStyleColor;
                btnFormIcon.IconChar = FormIcon;//Icono de formulario
            }
        }
        private void HelpMessage_Click(object sender, EventArgs e)
        {//Mostrar el mensaje de ayuda del formulario
            if (helpMessage == "" || helpMessage == null)
                RJMessageBox.Show("No se ha agregado ningún mensaje de ayuda para este formulario", "Mensaje");
            else
                RJMessageBox.Show(helpMessage, "Ayuda rapida");
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.DesignMode)//Only in design mode
            {
                if (desktopPanelSize)//si el campo desktopPanelSize es verdadero, simplemente permitir cambiar la altura del formulario, el ancho debe mantenerse igual al ancho del panel escritorio
                    this.Size = new Size(960, this.Size.Height);
            }
            /// <Nota> Si el formulario está en modo de diseño, no será posible cambiar el ancho del formulario
            /// para tener siempre el mismo ancho que el panel escritorio del formulario principal,
            /// esto para tener un diseño exacto y elegante.
            /// Sin embargo, si es posible cambiar la altura del formulario y desplazarse hacia abajo
            /// Si no está de acuerdo con esto, puede eliminar este código </Note>
        }
        private void Form_Deactivated(object sender, EventArgs e)
        {//Cuando el formulario entra en modo desactivado (pierde el foco), cambiar/opacar el color de la barra de título.
            pnlTitleBar.SuspendLayout();
            pnlTitleBar.BackColor = UIAppearance.DeactiveFormColor;//Establecer color de fondo de la barra de título 
            this.BorderColor = RJColors.DefaultFormBorderColor;//Establecer el color del borde

            if (UIAppearance.Style == UIStyle.Supernova)//Si el estilo es supernova, cambie el color del icono a blanco
                btnFormIcon.IconColor = Color.WhiteSmoke;
            pnlTitleBar.ResumeLayout();
            pnlTitleBar.Update();//Forzar el dibujo de la barra de título para evitar el parpadeo cuando se cambia el color de fondo.

        }
        private void Form_Activated(object sender, EventArgs e)
        {// Cuando el formulario entra en modo activado (recupera el foco - el formulario se vuelve a mostrar),
            //Restablecer el color de la barra de título y borde del formulario.
            if (UIAppearance.Style == UIStyle.Supernova)
            {
                pnlTitleBar.BackColor = RJColors.DarkItemBackground;//Establecer color de fondo de la barra de título    
                btnFormIcon.IconColor = supernovaColor;//Set icon colorEstablecer color de icono
            }
            else pnlTitleBar.BackColor = UIAppearance.PrimaryStyleColor;//Establecer color de fondo de la barra de título 

            this.BorderColor = UIAppearance.FormBorderColor;//Establecer el color del borde

            pnlTitleBar.Update();//Forzar el dibujo de la barra de título para evitar el parpadeo cuando se cambia el color de fondo.
        }
        #endregion


    }
}
