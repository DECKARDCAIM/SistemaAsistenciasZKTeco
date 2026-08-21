using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.ComponentModel;
using FontAwesome.Sharp;
using RJCodeUI_M1.RJControls;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace RJCodeUI_M1.RJForms
{
    public class RJMainForm : RJBaseForm
    {
        /// Esta clase hereda de la clase <see cref = "RJBaseForm" />
        ///
        /// <resumen>
        /// En esta clase, se establece una ventana sin bordes y se agrega una barra de título personalizada,
        /// un menú lateral y un área de cliente usando paneles, establece un método para 
        /// abrir los formularios secundarios dentro del área del cliente (escritorio), además
        /// para agregar funciones de captura de pantalla, imprimir y mover el formulario secundario a una nueva ventana.
        /// Además de agregar los botones para maximizar, minimizar, cerrar y el menú desplegable para la
        /// lista de opciones en el formulario.
        ///</summary>

        #region -> Campos

        /// Campos      
        private IContainer components = null; //Contenedor de componentes que no son secundarios del formulario. 
        ///Permite que todos los componentes agregados se eliminen con el método Dispose por el contenedor de componentes.
        ///<see cref="protected override void Dispose(bool disposing)"/>
        private RJChildForm activeChildForm; // Establece u obtiene el formulario secundario actualmente activo en el panel del escritorio
        private List<RJChildForm> listChildForms; // Almacena formularios secundarios que se han abierto y están activos en segundo plano (los formularios están ocultos)
        private bool deactivateFormEvent;
        /// Controles    
        protected Panel pnlSideMenu; // Menú lateral
        protected Panel pnlSideMenuHeader; // Encabezado del menú lateral
        protected Panel pnlTitleBar; // Barra de título
        protected Panel pnlDesktop; // Escritorio de la aplicación (Área del cliente: contenedor de formulario secundario) este panel solo almacenará y mostrará un formulario secundario. Los otros formularios secundarios desactivados se almacenan en la lista genérica de formularios.
        protected Panel pnlDesktopHeader; // encabezado del escritorio

        internal RJDropdownMenu dmFormOptions; // Menú desplegable de las opciones del formulario(es componente, el constructor acepta un parámetro de tipo IContainer)

        private RJLabel lblCaption; // Título del formulario

        private Panel pnlSide;//Panel lateral
        private Panel pnlMarker; // Marcador de formulario secundario actual, coloca un marcador en el botón de menú para indicar cuál es el formulario actual / activo en el escritorio de la aplicación
        private RJMenuIcon biSideMenuButton; // Botón de menú lateral
        private RJMenuIcon biFormIcon; // Botón de icono de formulario
        private IconButton btnMoveNewWindow; // Mover el formulario secundario a una nueva ventana
        private IconButton btnScreenshot; // Captura de pantalla del formulario
        private IconButton btnPrint; // imprimir formulario secundario
        private IconButton btnHelp; // Ayuda del formulario secundario
        private RJDragControl dragControl; // Control de arrastre de formulario, (es componente, el constructor acepta un parámetro de tipo IContainer)
        private IconMenuItem miCloseChildForms; // elemento de menú Cerrar todos los formularios secundarios
        private ToolTip toolTip; // Muestra una breve descripción de un control (es un componente, el constructor acepta un parámetro de tipo IContainer)     

        ///<Note>:ICON MENU ITEM and ICON BUTTON es proporcionado por la librería <see cref="FontAwesome.Sharp"/>.
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp </Note> 
        #endregion

        #region -> Constructor

        /// Constructor      
        public RJMainForm()
        {
            RJColors.colorIndex = 0;//Restablecer el índice de color de superonva
            InitializeItems();
            listChildForms = new List<RJChildForm>();//Inicializar lista genérica
        }

        /// Inicializar componentes
        private void InitializeItems()
        {
            /// Inicializar los componentes (instanciación de objetos) para el diseño del formulario:
            /// agregar la barra de título, menú lateral, botones para opciones de formulario, maximizar, minimizars, menú desplegable de opciones de usuario
            /// y el área de cliente (Escritorio) del formulario
            /// 
            components = new System.ComponentModel.Container();//inicializar contenedor

            #region -Instanciación de controles

            pnlSideMenu = new Panel();
            pnlSideMenuHeader = new Panel();
            pnlTitleBar = new Panel();
            pnlDesktop = new Panel();
            pnlDesktopHeader = new Panel();
            pnlMarker = new Panel();
            pnlSide = new Panel();
            btnMoveNewWindow = new FontAwesome.Sharp.IconButton();///(FontAwesome.Sharp library)
            btnScreenshot = new FontAwesome.Sharp.IconButton();
            btnPrint = new FontAwesome.Sharp.IconButton();
            btnHelp = new FontAwesome.Sharp.IconButton();
            biSideMenuButton = new RJMenuIcon();
            biFormIcon = new RJMenuIcon();
            lblCaption = new RJLabel();
            dmFormOptions = new RJDropdownMenu(components);//Agregar al contenedor de componentes
            miCloseChildForms = new FontAwesome.Sharp.IconMenuItem();///(FontAwesome.Sharp library)
            toolTip = new ToolTip(components);//Agregar al contenedor de componentes
            dragControl = new RJDragControl(pnlTitleBar, this, components);///Control de arrastre, Agregar al contenedor de componentes
            //Suspend layout           
            #endregion

            #region -Menú lateral del formulario
            //
            //  Panel: Panel lateral del formulario
            //
            pnlSide.Name = "pnlSide";
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Size = new Size(220, 610);
            pnlSide.Controls.Add(pnlSideMenu);
            pnlSide.Controls.Add(pnlSideMenuHeader);
            //
            //  Panel: Menú lateral   
            //
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Padding = new Padding(0, 65, 0, 0);
            pnlSideMenu.BackColor = RJColors.SideMenuColor;
            pnlSideMenu.Dock = DockStyle.Fill;
            pnlSideMenu.Location = new Point(0, 60);
            pnlSideMenu.Size = new Size(220, 550);
            pnlSideMenu.Controls.Add(pnlMarker);//Agregar control

            // 
            // Panel: Cabecera del Menú lateral
            //
            pnlSideMenuHeader.Name = "pnlSideMenuHeader";
            pnlSideMenuHeader.Controls.Add(biSideMenuButton);//Agregar control
            pnlSideMenuHeader.Size = new Size(220, 60);
            pnlSideMenuHeader.Dock = DockStyle.Top;
            pnlSideMenuHeader.Location = new Point(0, 0);
            // 
            // RJ BarIcon: Botón de menú lateral
            // 
            biSideMenuButton.Name = "biSideMenuButton";
            biSideMenuButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            biSideMenuButton.Customizable = true;
            biSideMenuButton.IconColor = Color.White;
            biSideMenuButton.BackColor = Color.Transparent;
            biSideMenuButton.Cursor = Cursors.Hand;
            biSideMenuButton.IconChar = FontAwesome.Sharp.IconChar.Bars;///(FontAwesome.Sharp library)
            biSideMenuButton.IconSize = 25;
            biSideMenuButton.Location = new Point(175, 20);
            biSideMenuButton.Size = new System.Drawing.Size(25, 25);
            biSideMenuButton.Click += new System.EventHandler(SideMenuButton_Click);//Suscribir evento.
            //
            // Panel: Marcador de formulario secundario
            //
            pnlMarker.Name = "pnlChildFormMarker";
            pnlMarker.Size = new Size(4, 55);
            pnlMarker.Location = new Point(0, 60);
            pnlMarker.Visible = false;
            #endregion

            #region -Barra de título del formulario
            //
            //  Panel: Barra de título
            //
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.BackColor = UIAppearance.StyleColor;
            pnlTitleBar.Size = new Size(960, 60);
            pnlTitleBar.Location = new Point(220, 0);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Controls.Add(lblCaption);//Agregar controles
            pnlTitleBar.Controls.Add(biFormIcon);
            pnlTitleBar.Controls.Add(this.btnMinimize);
            pnlTitleBar.Controls.Add(this.btnMaximize);
            pnlTitleBar.Controls.Add(this.btnClose);
            // 
            // Label: Título del formulario
            // 
            lblCaption.Name = "lblCaption";
            lblCaption.AutoSize = true;
            lblCaption.Style = LabelStyle.BarCaption;
            lblCaption.Location = new Point(46, 20);
            lblCaption.TextAlign = ContentAlignment.MiddleLeft;
            lblCaption.Text = "Inicio";
            //
            // Button: Botones de la caja de control
            //            
            this.btnClose.Size = new Size(35, 20);
            this.btnClose.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            this.btnMaximize.Size = new Size(35, 20);
            this.btnMaximize.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            this.btnMinimize.Size = new Size(35, 20);
            this.btnMinimize.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            // 
            // Bar Icon: Icono de formulario activo
            // 
            biFormIcon.Name = "biFormIcon";
            biFormIcon.BackColor = Color.Transparent;
            biFormIcon.Cursor = Cursors.Hand;
            biFormIcon.IconChar = FontAwesome.Sharp.IconChar.Home;///(FontAwesome.Sharp library)
            biFormIcon.IconSize = 25;
            biFormIcon.Location = new Point(19, 20);
            biFormIcon.Size = new Size(25, 25);
            biFormIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            biFormIcon.Click += new System.EventHandler(this.FormIcon_Click);//Eventos
            biFormIcon.MouseEnter += new System.EventHandler(this.FormIcon_MouseHover);
            biFormIcon.MouseLeave += new System.EventHandler(this.FormIcon_MouseLeave);
            #endregion

            #region -Opciones de formulario
            //
            // Icon MenuItem: Cerrar formularios secundarios (FontAwesome.Sharp library)
            //
            miCloseChildForms.Name = "miCloseChildForms";
            miCloseChildForms.Text = "Cerrar form. secundarios";
            miCloseChildForms.IconSize = 24;
            miCloseChildForms.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            miCloseChildForms.IconColor = RJColors.FantasyColorScheme4;
            miCloseChildForms.Click += new System.EventHandler(CloseAllChildForms_Click);//Event
            //
            //  DropdownMenu: Opciones de formulario -------------
            //
            dmFormOptions.Name = "dmFormOptions";
            dmFormOptions.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dmFormOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            miSnapLeft,//Snap Window Left
            miSnapRight,//Snap Window Right
            miExitSnap,//Exit Snap Window
            miCloseChildForms});
            dmFormOptions.OwnerIsMenuButton = false;
            #endregion

            #region -Encabezado de escritorio (opciones de formulario secundario)
            // 
            //  Panel: Encabezado de escritorio  -------------
            //
            pnlDesktopHeader.Name = "pnlDesktopHeader";
            pnlDesktopHeader.BackColor = RJColors.LightBackground;
            pnlDesktopHeader.Dock = DockStyle.Top;
            pnlDesktopHeader.Location = new Point(220, 60);
            pnlDesktopHeader.Size = new Size(960, 25);
            pnlDesktopHeader.Padding = new Padding(14, 0, 0, 0);
            pnlDesktopHeader.Controls.Add(btnHelp);//Agregar controles
            pnlDesktopHeader.Controls.Add(btnMoveNewWindow);
            pnlDesktopHeader.Controls.Add(btnScreenshot);
            pnlDesktopHeader.Controls.Add(btnPrint);
            // 
            // Icon Button: Imprimir formulario (Control de la librería FontAwesome.Sharp)
            // 
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.IconSize = 20;
            btnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnPrint.IconColor = RJColors.FantasyColorScheme1;
            btnPrint.Location = new Point(0, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(35, 25);
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Visible = false;
            btnPrint.Click += new EventHandler(Print_Click);
            // 
            // Icon Button: Captura de pantalla (Control de la librería FontAwesome.Sharp)
            // 
            btnScreenshot.Dock = DockStyle.Left;
            btnScreenshot.FlatAppearance.BorderSize = 0;
            btnScreenshot.FlatStyle = FlatStyle.Flat;
            btnScreenshot.IconSize = 20;
            btnScreenshot.IconChar = FontAwesome.Sharp.IconChar.Camera;
            btnScreenshot.IconColor = RJColors.FantasyColorScheme2;
            btnScreenshot.Location = new Point(0, 0);
            btnScreenshot.Name = "btnScreenShoot";
            btnScreenshot.Size = new Size(35, 25);
            btnScreenshot.UseVisualStyleBackColor = true;
            btnScreenshot.Cursor = Cursors.Hand;
            btnScreenshot.Visible = false;
            btnScreenshot.Click += new EventHandler(Screenshot_Click);
            // 
            // Icon Button: Mover formulario secundario a nueva ventana(Control de la librería FontAwesome.Sharp)
            // 
            btnMoveNewWindow.Name = "btnOpenNewWindow";
            btnMoveNewWindow.Dock = DockStyle.Left;
            btnMoveNewWindow.FlatAppearance.BorderSize = 0;
            btnMoveNewWindow.FlatStyle = FlatStyle.Flat;
            btnMoveNewWindow.IconSize = 20;
            btnMoveNewWindow.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMoveNewWindow.IconColor = RJColors.FantasyColorScheme3;
            btnMoveNewWindow.Location = new Point(15, 0);
            btnMoveNewWindow.Size = new Size(35, 25);
            btnMoveNewWindow.UseVisualStyleBackColor = true;
            btnMoveNewWindow.Cursor = Cursors.Hand;
            btnMoveNewWindow.Visible = false;
            btnMoveNewWindow.Click += new EventHandler(MoveNewWindow_Click);//Event
            // 
            // Icon Button: Ayuda de usuario (Control de la librería FontAwesome.Sharp)
            // 
            btnHelp.Dock = DockStyle.Left;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.IconSize = 20;
            btnHelp.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            btnHelp.IconColor = RJColors.FantasyColorScheme4;
            btnHelp.Location = new Point(0, 0);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(35, 25);
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Cursor = Cursors.Hand;
            btnHelp.Visible = false;
            btnHelp.Click += new EventHandler(ChilFormHelp_Click);
            #endregion

            #region -Escritorio (área Cliente - Contenedor de formulario secundario)
            //
            //  Panel: Escritorio
            //
            pnlDesktop.Name = "pnlDesktop";
            pnlDesktop.BackColor = RJColors.LightBackground;
            pnlDesktop.Dock = DockStyle.Fill;
            pnlDesktop.Location = new Point(220, 85);
            pnlDesktop.Size = new Size(960, 525);
            #endregion

            #region -Others
            //
            // ToolTip
            //   
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.BackColor = Color.FromArgb(236, 82, 99);
            toolTip.ForeColor = Color.White;
            toolTip.OwnerDraw = true;
            toolTip.Draw += new DrawToolTipEventHandler(ToolTip_Draw);
            toolTip.SetToolTip(btnPrint, "Imprimir contenido de formulario");
            toolTip.SetToolTip(btnScreenshot, "Tomar captura de pantalla");
            toolTip.SetToolTip(btnMoveNewWindow, "Mover formulario a una nueva ventana");
            toolTip.SetToolTip(btnHelp, "Mensaje de ayuda");
            #endregion

            #region -RJ Main Form Properties
            //
            //RJMainForm
            //
            deactivateFormEvent = true;
            this.Resizable = true;
            this.PrimaryForm = true;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;//Formulario sin bordes    
            this.MinimumSize = new Size(650, 400);//Tamaño mínimo del formulario 
            this.Controls.Add(pnlDesktop);//Agregar controles
            this.Controls.Add(pnlDesktopHeader);
            this.Controls.Add(pnlTitleBar);
            this.Controls.Add(pnlSide);
            this.Deactivate += new EventHandler(Form_Deactivated);//suscribirse al evento Desactivado para cambiar / opacar el color de la barra de título
            this.Activated += new EventHandler(Form_Activated);//Suscribirse al evento Activado para recuperar el color de la barra de título.

            #endregion
        }
        #endregion

        #region -> Propiedades

        public new Size ClientSize
        {//Ocultar el tamaño del cliente para que el tamaño predeterminado surta efecto en los formularios derivados
            get { return base.ClientSize; }
            set { }
        }
        protected override Size DefaultSize
        {//Tamaño predeterminado del formulario
            get { return new Size(1180, 610); }
        }
        #endregion

        #region -> Métodos protegidos

        ///Abrir formulario secundario
        protected void OpenChildForm<childForm>(Func<childForm> _delegate) where childForm : RJChildForm
        {
            /// Método genérico con un parámetro de delegado genérico (Func <TResult>) donde el tipo de datos es RJChildForm.
            /// Este método PERMITE abrir formularios CON o SIN parámetros dentro del panel escritorio. En muchas ocasiones,
            /// en los tutoriales de youtube se utilizaron Métodos similares a este. Sin embargo, simplemente permitía abrir formularios
            /// SIN parámetros (por ejemplo, <ver cref = "new MyForm ()" />)
            /// y fue imposible abrir un formulario CON parámetros( por ejemplo, <see cref="new MyForm (user:'John', mail:'john@gmail.com')"/>
            /// por lo que este método soluciona este defecto gracias al delegado genérico(Func <TResult>)       

            RJChildForm form = Application.OpenForms.OfType<childForm>().FirstOrDefault();//Comprobar si el formulario secundario ya está abierto

            #region - Mostrar formulario secundario como una nueva instancia

            if (form == null)//Si no hay ningún resultado, el formulario no está abierto, entonces crear la instancia y mostrarla en el panel escritorio
            {
                deactivateFormEvent = false;//No desactivar formulario cuando se abre el formulario secundario

                form = _delegate();// Ejecutar al delegado               
                form.IsChildForm = true;//Establecer formulario como formulario secundario     
                form.TopLevel = false;//Indicar que el formulario no es de nivel superior     
                form.Dock = DockStyle.Fill; //Establecer el estilo de muelle en lleno (Rellenar el panel escritorio)          
                form.MarkerPosition = 0;//Establecer la Posición del marcador en cero, porque el formulario no se abre desde un botón de menú.

                CleanDesktop(); //Eliminar el formulario secundario actual del panel escritorio
                // Si la opción de múltiples formularios secundarios está deshabilitada, solo permitir abrir un único formulario dentro del panel escritorio, entonces cerrar definitivamente el anterior.
                if (UIAppearance.MultiChildForms == false) CloseActiveChildForm();//Cerrar formulario secundario actual: esto no afecta si el formulario secundario está abierto en una nueva ventana.

                listChildForms.Add(form);//Agregar formulario secundario a la lista de formularios
                pnlDesktop.Controls.Add(form);//Agregar formulario secundario al panel escritorio
                pnlDesktop.Tag = form;//Almacenar el formulario 

                form.Show();//Mostrar el formulario 
                form.BringToFront();// Traer al frente
                form.Focus();//Enfocar el formulario

                activeChildForm = form;//establecer FORM como formulario secundario activo

                SetChildFormItems();//-> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal

                deactivateFormEvent = true;//Restablecer valor
            }
            #endregion

            #region - Volver a mostrar formulario existente o formulario secundario
            else //Si el formulario ya está abierto, muestrar el formulario nuevamente
            {
                if (form.IsChildForm && form != activeChildForm)
                {//si el formulario es un formulario secundario y el formulario es diferente del formulario secundario activo, volver a agregarlo al panel y establecer como formulario secundario activo

                    CleanDesktop(); // Eliminar el formulario secundario actual del panel escritorio
                    pnlDesktop.Controls.Add(form); // agregar formulario secundario al panel escritorio
                    pnlDesktop.Tag = form; // Almacenar el formulario
                    activeChildForm = form; // establecer FORM como formulario secundario activo
                    SetChildFormItems(); // -> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
                }

                if (form.WindowState == FormWindowState.Minimized)
                    form.WindowState = FormWindowState.Normal;
                form.Show();//mostrar el formulario en el panel escritorio o afuera en una nueva ventana si el formulario NO ES UN FORMULARIO Secundario
                form.BringToFront();//Trae el formulario al frente
                form.Focus();//Enfocar formualario
            }
            #endregion

            ///<Note>
            /// Puede usar el delegado Func <TResult> con Métodos anónimos o expresión lambda,
            /// por ejemplo, podemos llamar a este método de la siguiente manera: Supongamos que estamos en el método de evento clic de algún botón.
            /// Con método anónimo:
            ///     <see cref="OpenChildForm( delegate () { return new MyForm('MyParameter'); });"/>    
            /// Con expresión lambda
            ///     <see cref="OpenChildForm( () => new MyForm('id', 'username'));"/>
            /// </Note>

        }//Aquí los principales comentarios
        protected void OpenChildForm<childForm>(Func<childForm> _delegate, object senderMenuButton) where childForm : RJChildForm
        {  ///Método genérico con un parámetro de delegado genérico (Func <TResult>) y un parámetro de botón de menú donde el tipo de datos es RJChildForm.

            if (senderMenuButton == null || senderMenuButton.GetType() != typeof(RJMenuButton))//Comprueba si el objeto es válido
            {
                RJMessageBox.Show("Envíe un objeto válido, no se permiten valores nulos");
                return;
            }
            RJMenuButton menuButton = (RJMenuButton)senderMenuButton;
            RJChildForm form = Application.OpenForms.OfType<childForm>().FirstOrDefault();//Comprobar si el formulario secundario ya está abierto

            #region - Mostrar formulario secundario como una nueva instancia
            if (form == null)//Si no hay ningún resultado, el formulario no está abierto, entonces crear la instancia y mostrarla en el panel escritorio
            {
                deactivateFormEvent = false;//No desactivar formulario cuando se abre el formulario secundario

                form = _delegate();// Ejecutar al delegado    
                form.IsChildForm = true;
                form.TopLevel = false;//Indicar que el formulario no es de nivel superior       
                form.Dock = DockStyle.Fill;
                form.MarkerPosition = menuButton.Location.Y;//Establecer la posición del marcador   

                CleanDesktop(); //eliminar el formulario secundario actual del panel escritorio
                if (UIAppearance.MultiChildForms == false) CloseActiveChildForm();//Cerrar el formulario secundario actual si la opción de varios formularios secundarios está deshabilitada: esto no afecta si el formulario secundario está abierto en una nueva ventana.

                listChildForms.Add(form);//agregar formulario secundario a la lista de formularios
                pnlDesktop.Controls.Add(form);//agregar formulario secundario al panel del escritorio
                pnlDesktop.Tag = form;

                form.Show();
                form.BringToFront();
                form.Focus();

                activeChildForm = form;//establecer FORM como formulario secundario activo

                SetChildFormItems();//-> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
                menuButton.Activate(form); //->Activar el botón de menú y asociar el formulario para que el botón permanezca resaltado cuando el formulario esté instanciado.

                deactivateFormEvent = true;//Restablecer valor
            }
            #endregion

            #region - Volver a mostrar formulario existente o formulario secundario
            else //Si el formulario ya está abierto, mostrar el formulario nuevamente
            {
                if (form.IsChildForm && form != activeChildForm)
                {//si el formulario es un formulario secundario y el formulario es diferente del formulario secundario activo, volver a agregarlo al panel y establecer como formulario secundario activo

                    CleanDesktop(); // Eliminar el formulario secundario actual del panel  escritorio
                    pnlDesktop.Controls.Add(form); // agregar formulario secundario al panel escritorio
                    pnlDesktop.Tag = form;
                    activeChildForm = form; // establecer FORM como formulario secundario activo
                    SetChildFormItems(); // -> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
                }

                if (form.WindowState == FormWindowState.Minimized)
                    form.WindowState = FormWindowState.Normal;
                form.Show();//muestre el formulario en el panel del escritorio o afuera en una nueva ventana si el formulario NO ES UN FORMULARIO secundario
                form.BringToFront();
                form.Focus();

            }
            #endregion
        }
        protected void OpenChildForm<childForm>(Func<childForm> _delegate, object senderMenuItem, RJMenuButton ownerMenuButton) where childForm : RJChildForm
        { ///Método genérico con parámetro Delegado genérico (Func <TResult>), Botón de menú y elemento de menú donde el tipo de datos es RJChildForm.

            if (ownerMenuButton == null || senderMenuItem == null || senderMenuItem.GetType() != typeof(ToolStripMenuItem))//validar parámetros
            {
                RJMessageBox.Show("Envíe un objeto válido, no se permiten valores nulos");
                return;
            }

            RJChildForm form = Application.OpenForms.OfType<childForm>().FirstOrDefault();//Comprobar si el formulario secundario ya está abierto

            #region - Mostrar formulario secundario como una nueva instancia
            if (form == null)//Si no hay ningún resultado, el formulario no está abierto, entonces crear la instancia y mostrarla en el panel escritorio
            {
                deactivateFormEvent = false;//No desactivar formulario cuando se abre el formulario secundario

                form = _delegate();// Ejecutar al delegado
                form.IsChildForm = true;
                form.TopLevel = false;//Indicar que el formulario no es de nivel superior     
                form.Dock = DockStyle.Fill;
                form.MarkerPosition = ownerMenuButton.Location.Y;//Establecer la posición del marcador  

                CleanDesktop();//Eliminar el formulario secundario actual del panel escritorio
                if (UIAppearance.MultiChildForms == false) CloseActiveChildForm();// Cerrar el formulario secundario actual si la opción de varios formularios secundarios está deshabilitada: esto no afecta si el formulario secundario está abierto en una nueva ventana.

                listChildForms.Add(form);//agregar FORM a la lista de formularios
                pnlDesktop.Controls.Add(form);//agregar FORM al panel escritorio
                pnlDesktop.Tag = form;

                form.Show(); //mostrar en el panel escritorio  
                form.BringToFront();
                form.Focus();

                activeChildForm = form;//establecer FORM como formulario secundario activo

                SetChildFormItems();//-> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
                ownerMenuButton.Activate(form, (ToolStripMenuItem)senderMenuItem); //-> Activar el botón de menú y asociar
                // un formulario para que el botón permanezca resaltado hasta que todos los formularios sean cerrados.
                // Se Puede tener muchos formularios asociados ya que el botón de menú muestra un menú desplegable.
                // Activar también el elemento de menú y asociarlo al formulario para que el elemento de menú permanezca
                // resaltado cuando el formulario está instanciado.

                deactivateFormEvent = true;//Restablecer valor
            }
            #endregion

            #region - Volver a mostrar formulario existente o formulario secundario
            else //Si el formulario ya está abierto, mostrar el formulario nuevamente
            {
                if (form.IsChildForm && form != activeChildForm)
                {//Si el formulario es un formulario secundario y el formulario es diferente del formulario secundario activo, volver a agregarlo al panel y establcer como formulario secundario activo.

                    CleanDesktop();//Eliminar el formulario secundario actual del panel del escritorio
                    pnlDesktop.Controls.Add(form);//agregar FORM al panel escritorio
                    pnlDesktop.Tag = form;
                    activeChildForm = form;//establecer FORM como formulario secundario activo
                    SetChildFormItems();//-> Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
                }

                if (form.WindowState == FormWindowState.Minimized)
                    form.WindowState = FormWindowState.Normal;
                form.Show();//muestre el formulario en el panel del escritorio o afuera en una nueva ventana si el formulario NO ES UN FORMULARIO secundario.
                form.BringToFront();
                form.Focus();

            }
            #endregion
        }
        #endregion

        #region -> Métodos privados
        ///Cargar parámetros de diseño       
        private void SetChildFormItems()
        {
            //Cuando se muestra un formulario secundario en el escritorio, establecer el título, el icono, el marcador y las opciones del formulario secundario en el diseño del formulario principal

            biFormIcon.IconChar = activeChildForm.FormIcon;//Establecer icono de formulario
            lblCaption.Text = activeChildForm.Text;//Establecer título de formulario
            pnlDesktopHeader.BackColor = UIAppearance.ItemBackgroundColor;//Establecer color de fondo del encabezado del escritorio

            // Mostrar los botones de opción del formulario secundario
            btnHelp.Visible = true;
            btnMoveNewWindow.Visible = true;
            btnScreenshot.Visible = true;
            btnPrint.Visible = true;

            /// Establecer marcador de formulario secundario, siempre que el campo ChildFormMarker de UIAppearance esté establecido en verdadero
            /// y el campo MarkerPosition del formulario activo tiene un valor distinto de 0 (en este caso, Cero
            /// es igual que no se establece la posición para el marcador porque el formulario no se abrió desde
            /// un botón de menú) ver método <see cref="OpenChildForm<childForm>(Func<childForm> _delegate)"/>.
            if (UIAppearance.ChildFormMarker == true && activeChildForm.MarkerPosition != 0)
            {
                pnlMarker.Location = new Point(0, activeChildForm.MarkerPosition);
                pnlMarker.Visible = true;
            }
        }
        private void ResetToDefaults()
        {
            //Restablecer el formulario principal a los valores predeterminados

            activeChildForm = null; //Establecer el campo del formulario secundario actual en nulo
            lblCaption.Text = "Inicio";
            biFormIcon.IconChar = IconChar.Home;
            pnlMarker.Visible = false;//Ocultar marcador de formulario secundario
            pnlDesktopHeader.BackColor = UIAppearance.BackgroundColor;
            btnPrint.Visible = false;//Ocultar botones de opción del formulario secundario
            btnScreenshot.Visible = false;
            btnMoveNewWindow.Visible = false;
            btnHelp.Visible = false;
        }
        private void UpdateFormLayout()
        {//Este método es responsable  de actualizar el formulario principal con los parametros adecuados,
            //ya sea restablecer los valores pretederminados o mostrar un formulario secundario anterior si es el caso.

            var childForm = listChildForms.LastOrDefault();//Verificar y obtener el último formulario secundario (anterior) en la lista de formularios
            if (childForm == null) //Si no hay ningún resultado, no hay ninguna instancia en la lista de formularios secundarios.
            {
                ResetToDefaults(); //Restablecer el formulario principal a los valores predeterminados
            }
            else//si hay un formulario secundario instanciado en la lista, agregarlo de nuevo al panel escritorio, establecerlo como un formulario secundario activo y mostrarlo.
            {

                activeChildForm = childForm;//Establecer formulario como formulario secundario actual (formulario anterior)
                pnlDesktop.Controls.Add(childForm);//Agregar al panel escritorio
                pnlDesktop.Tag = childForm;//Almacenar el formulario

                childForm.Show();//Mostrar formulario secundario
                childForm.BringToFront();

                SetChildFormItems();//Establecer el título, el icono y las opciones del formulario secundario en el diseño del formulario principal
            }
        }
        private void CleanDesktop()
        {//Limpiar panel de escritorio

            if (activeChildForm != null)
            {
                activeChildForm.Hide();
                pnlDesktop.Controls.Remove(activeChildForm);
            }
            /* Este método oculta y elimina el formulario secundario activo del panel escritorio,
             * por lo que solo habrá un formulario secundario abierto dentro del panel del escritorio,
             * ya que agregar un formulario nuevo elimina el formulario anterior y agrega el nuevo
             * formulario (Revise el método OpenChildForm).
             * Los formularios secundarios inactivos se almacenan en una lista genérica.

             * Creé estos Métodos para deshacerme de las dudas ya que muchos piensan (incluido yo mismo) que
             * tener 20 o 50 formularios agregados dentro del escritorio afecta el rendimiento,
             * bueno, no me di cuenta de eso. De hecho, es posible agregar 10 mil controles dinámicamente
             * en una forma mostrada y no hay límite si se agrega desde el constructor del formulario, 
             * para experimentar, agregué 100 mil etiquetas y 10 mil paneles con color aunque tardó más
             * de 10 minutos en mostrar (pc : 8 ram, cpu SixCore 3,50 GHz)
              y no hay ningún problema de rendimiento (consumió 20mb ram) y desplazarse por el formulario funciona bien.

             * Por lo tanto, si estos Métodos parecen muy tediosos o difíciles de entender, puede utilizar 
             * los Métodos para abrir un formulario secundario dentro del panel de Proyectos 
             * anteriores (tutoriales) que se muestran en YouTube, donde los formularios secundarios
             * se almacenan dentro del escritorio, se superponen uno tras otro y se muestra uno (form.bringtofront ();).

             * Sin embargo, todavía no me parece apropiado agregar tantos formularios dentro de un panel 
             * considerando que un formulario predeterminado es de nivel superior y no me gusta la idea
             * de tener tantos controles en un panel (controles de formulario secundario ).

             * Como resultado, preferí almacenar los formularios secundarios en una lista genérica y 
             * agregar y mostrar solo un formulario en el panel escritorio :) */
        }
        private void ApplyAppearanceSettings()
        {//Aplicar configuraciones de apariencia         
            pnlDesktop.BackColor = UIAppearance.BackgroundColor;//Establecer color de fondo
            pnlDesktopHeader.BackColor = UIAppearance.BackgroundColor; // Establecer el color de fondo del encabezado del escritorio
            this.BorderColor = UIAppearance.FormBorderColor; // Establecer el color del borde
            this.BorderSize = UIAppearance.FormBorderSize; // Establecer el ancho del borde del formulario

            if (UIAppearance.Style == UIStyle.Supernova)//Si el estilo es supernova
            {
                pnlTitleBar.BackColor = ColorEditor.Darken(UIAppearance.BackgroundColor, 7);//Establecer color de fondo de la barra de título
                pnlSideMenuHeader.BackColor = RJColors.SideMenuColor;//Establecer color de fondo del encabezado del menú lateral
                pnlMarker.BackColor = Color.CornflowerBlue;//Establecer el color del marcador
            }
            else //Cualquier estilo que no sea supernova
            {
                pnlTitleBar.BackColor = UIAppearance.PrimaryStyleColor;//Establecer color de fondo de la barra de título
                pnlSideMenuHeader.BackColor = ColorEditor.Darken(UIAppearance.PrimaryStyleColor, 6);//Establecer color de fondo del encabezado del menú lateral
                pnlMarker.BackColor = UIAppearance.StyleColor;//Establecer el color del marcador                
            }
        }

        /// Opciones de formulario secundario
        private void MoveFormNewWindow()
        {//Mover el formulario secundario activo a una ventana nueva

            if (activeChildForm != null)
            {
                listChildForms.Remove(activeChildForm);//Eliminar el formulario secundario actual de la lista de formularios.
                pnlDesktop.Controls.Remove(activeChildForm); // Eliminar el formulario secundario actual del panel escritorio.
                activeChildForm.IsChildForm = false; // Establecer el formulario como un formulario normal (tiene una barra de título y cambia de tamaño)
                activeChildForm.TopLevel = true; // Establecer el formulario como nivel superior
                activeChildForm.Dock = DockStyle.None;

                UpdateFormLayout();//Actualizar formualario principal.

            }
        }
        private void CloseActiveChildForm()
        {//Cerrar formulario secundario activo

            if (activeChildForm != null)
            {
                listChildForms.Remove(activeChildForm);//Eliminar el formulario secundario actual de la lista de formularios.
                pnlDesktop.Controls.Remove(activeChildForm);// Eliminar el formulario secundario actual del panel escritorio.
                activeChildForm.Close();//Cerrar formualario secundario actual.               
            }
        }
        private void CloseAllChildForm()
        {//Cerrar todos los formularios secundarios

            var childForms = Application.OpenForms.OfType<RJChildForm>().FirstOrDefault();// Comprobar si hay un formulario secundario abierto. 

            if (childForms != null)//Si hay algún formulario abierto, cerrar todos los formularios excepto este (this) formulario y el formulario primario de la aplicación (por ejemplo, formulario de inicio de sesión)
            {
                Application.OpenForms.Cast<Form>().Except(new Form[] { this }).ToList().ForEach(x => x.Close());
                listChildForms.Clear();//Vaciar todos los elementos de la lista de formularios.
                pnlMarker.Visible = false;
                ResetToDefaults();
            }
            else //si no hay formularios abiertos, mostrar mensaje
            {
                RJMessageBox.Show("No hay ningún formulario secundario abierto", "Mensaje");
            }

        }
        private void Screenshot()
        {//Tomar captura de pantalla del formulario

            string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);//Directorio de guardado predeterminado (imágenes)
            var saveScreenshot = new SaveFileDialog();//Instanciar objeto SaveFileDialog
            //Filtrar archivos de imagen
            saveScreenshot.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP IMAGE|*.bmp" +
                                    "|Image Files|*.png;*.jpg;*.BMP;*.gif " +
                                    "|All Files|*.*";
            saveScreenshot.DefaultExt = "png"; //Establecer extension preterminada.
            saveScreenshot.AddExtension = true;
            saveScreenshot.FileName = "RJCode #" + Path.GetRandomFileName(); //Sugerir un nombre aleateario.
            saveScreenshot.InitialDirectory = initialDirectory;//Indicar el directorio predeterminado/inicial.



            // Tomar la captura de pantalla desde la esquina superior izquierda a la esquina inferior derecha
            Bitmap bmpScreenshot = new Bitmap(this.Size.Width, this.Size.Height, PixelFormat.Format32bppArgb); //Establecer el objeto de mapa de bits al tamaño del formulario principal
            Graphics graphic = Graphics.FromImage(bmpScreenshot);//Crear un objeto gráfico a partir del mapa de bits
            graphic.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);//Tomar la captura de pantalla solo la región del formulario principal (this.size)

            if (saveScreenshot.ShowDialog() == DialogResult.OK)//Si el usuario hace clic en el botón Guardar.
            {
                bmpScreenshot.Save(saveScreenshot.FileName);//Guardar la captura de pantalla en la ruta y el nombre de archivo elegidos por el usuario.
                Process.Start(saveScreenshot.FileName);//Mostrar la captura de pantalla en la aplicación de visor de imágenes predeterminada del sistema operativo.
            }
        }
        private void PrintCurrentChildForm()
        {//Imprimir formulario secundario actual

            //Captura de pantalla del panel de escritorio
            Bitmap bmpScreenshot = new Bitmap(pnlDesktop.Width, pnlDesktop.Height, PixelFormat.Format32bppArgb);//Establecer el objeto de mapa de bits al tamaño del panel escritorio.
            var screenPoint = this.PointToScreen(pnlDesktop.Location);//Calcula la ubicación del punto de la pantalla en las coordenadas del panel  escritorio.
            Graphics graphic = Graphics.FromImage(bmpScreenshot);//Crea un objeto gráfico a partir del mapa de bits.
            graphic.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, pnlDesktop.Size);//Tomar la captura de pantalla solo la región del panel escritorio.

            var printForm = new RJPrintForm(bmpScreenshot, activeChildForm.Caption);//Abrir el formulario de impresión y enviar la captura de pantalla y el título del formulario.
            printForm.ShowDialog();//Mostrar como ventana modal.
        }

        #endregion

        #region -> Anulaciones

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ApplyAppearanceSettings();
            pnlMarker.BringToFront();//Establecer marcado en primer plano
            //Ubicación de la caja de control
            btnClose.Location = new Point(this.pnlTitleBar.Width - btnClose.Width, 0);
            btnMaximize.Location = new Point(btnClose.Location.X - btnMaximize.Width, 0);
            btnMinimize.Location = new Point(btnMaximize.Location.X - btnMinimize.Width, 0);
        }
        #endregion

        #region -> Métodos de evento

        private void SideMenuButton_Click(object sender, EventArgs e)
        {

            if (this.pnlSide.Width == 220)//Contraer menú lateral
            {
                this.pnlSide.Width = 65;
                foreach (Control control in this.pnlSideMenuHeader.Controls)//Ocultar cualquier control de encabezado excepto el botón de menú lateral
                {
                    if (control != biSideMenuButton)
                    {
                        control.Visible = false;
                    }
                }

            }
            else //Expandir el menú lateral
            {
                this.pnlSide.Width = 220;
                foreach (Control control in this.pnlSideMenuHeader.Controls)//Mostrar cualquier control de encabezado
                {
                    if (control != biSideMenuButton)
                    {
                        control.Visible = true;
                    }
                }
            }
        }

        private void FormIcon_Click(object sender, EventArgs e)
        {
            CloseActiveChildForm();//Cerrar el formulario secundario actual del escritorio del panel
            UpdateFormLayout();//Actualizar formulario principal
        }
        private void FormIcon_MouseHover(object sender, EventArgs e)
        {//cuando el usuario pasa el mouse sobre el ícono del formulario, cambiar el ícono para cerrar.

            if (this.activeChildForm != null)
            {
                this.biFormIcon.IconChar = IconChar.TimesCircle;//Close icon
            }
        }
        private void FormIcon_MouseLeave(object sender, EventArgs e)
        {//cuando el puntero del mouse sale del ícono del formulario, restablecer el ícono del formulario actual

            if (this.activeChildForm != null)
            {
                this.biFormIcon.IconChar = activeChildForm.FormIcon;
            }
        }

        private void CloseAllChildForms_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();//Cerrar todos los formularios secundarios
        }
        private void MoveNewWindow_Click(object sender, EventArgs e)
        {
            MoveFormNewWindow();//Mover formulario secundario a una nueva ventana  
        }
        private void ChilFormHelp_Click(object sender, EventArgs e)
        {//Mostrar mensaje de ayuda del formulario secundario

            if (activeChildForm.HelpMessage == "" || activeChildForm.HelpMessage == null)//Sin mensaje
                RJMessageBox.Show("No se ha agregado ningún mensaje de ayuda para este formulario", "Mensaje");
            else//Mostrar mensaje de ayuda
                RJMessageBox.Show(activeChildForm.HelpMessage, "Ayuda");
        }
        private void Screenshot_Click(object sender, EventArgs e)
        {
            Screenshot();
        }
        private void Print_Click(object sender, EventArgs e)
        {
            PrintCurrentChildForm();
        }

        private void Form_Deactivated(object sender, EventArgs e)
        {//Cuando el formulario entra en modo desactivado (pierde el foco), cambia el color de la barra de título.
            if (deactivateFormEvent == true)
            {
                this.BorderColor = RJColors.DefaultFormBorderColor;//Establecer el color del borde
                if (UIAppearance.Style != UIStyle.Supernova)//Si el estilo no es supernova, cambiar el color de la barra de título
                {

                    pnlTitleBar.BackColor = UIAppearance.DeactiveFormColor;//Establecer color de fondo de la barra de título.
                    pnlSideMenuHeader.BackColor = ColorEditor.Darken(UIAppearance.DeactiveFormColor, 6);//Establecer color de fondo del encabezado del menú lateral.           
                    pnlTitleBar.Update();//Forzar el dibujo de la barra de título para evitar el parpadeo cuando se cambia el color de fondo.                 

                }
            }
        }
        private void Form_Activated(object sender, EventArgs e)
        {//Cuando el formulario entra en modo activado (recupera el foco, volver a mostrar el formulario),
            //Volver a establecer el color normal de la barra de título.

            this.BorderColor = UIAppearance.FormBorderColor;//Establecer el color del borde
            if (UIAppearance.Style != UIStyle.Supernova)
            {
                pnlTitleBar.BackColor = UIAppearance.PrimaryStyleColor;//Establecer color de fondo de la barra de título.
                pnlSideMenuHeader.BackColor = ColorEditor.Darken(UIAppearance.PrimaryStyleColor, 6);//Establecer color de fondo del encabezado del menú lateral.                         
                pnlTitleBar.Update();    //Forzar el dibujo de la barra de título para evitar el parpadeo cuando se cambia el color de fondo.              
            }

        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {//Draw the code provided in the properties
            e.DrawBackground();//Color de fondo
            e.DrawText();//Texto
            //e.DrawBorder();//Border
        }
        #endregion
    }
}