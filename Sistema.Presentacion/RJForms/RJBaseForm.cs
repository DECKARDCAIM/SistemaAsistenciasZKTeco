using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using RJCodeUI_M1.RJControls;
using RJCodeUI_M1.Settings;
using System.ComponentModel;

namespace RJCodeUI_M1.RJForms
{
    public class RJBaseForm : Form
    {
        /// Esta clase hereda de la clase <see cref = "Form" /> de la biblioteca <see cref = "System.Windows.Forms" />
        ///
        /// <summary>
        /// Un formulario sin bordes pierde la funcionalidad de cambiar el tamaño, snap windows, maximizar-restaurar
        /// y minimizar desde la barra de tareas, entonces en esta clase estas funcionalidades serán re-implementadas anulando
        /// el procesamiento de mensajes de Windows, Métodos de creación de parámetros a nivel del sistema operativo
        /// y agregando los botones y Métodos necesarios.
        ///</summary>

        #region -> Campos

        /// Campos
        private IContainer components = null; //Contenedor de componentes que no son elementos secundarios del formulario. 
        ///Permite que todos los componentes agregados se eliminen con el método Dispose por el contenedor de componentes
        ///<see cref="protected override void Dispose(bool disposing)"/>

        private bool isPrimaryForm; //Obtiene o establece si es un formulario primario: es un formulario base para todos los formularios de la aplicacíon(por ejemplo, formulario de inicio de sesión y formulario principal)
        private bool isResizable = true;//Obtiene o establece si el formulario es redimensionable desde los bordes del formulario
        private bool minimizeButton = true;//Obtiene o establece si el boton de minimizar se muestra.
        private bool maximizeButton = true;//Obtiene o establece si el boton de maximizar se muestra.
        private bool isMaximized;//Obtener o establecer si el formulario está maximizado: Es un interruptor para detener los ciclos de ejecución de código en el evento de cambio de tamaño   
        private bool snapWindow;//Obtiene o establece si se activa winsnap del formulario (esta es una imitación simple de la función de ajuste aerodinámico de la ventana-  window aero snap )
        private Size tempSize;//Obtiene o establece el tamaño temporal del formulario para restaurar el tamaño después de haber activado WinSnap       
        private Point tempLocation;//Obtiene o establece la ubicación temporal del formulario para restaurar el tamaño después de haber activado WinSnap
        private int borderSize;//Obtiene o establece el ancho del borde del formulario
        private Color borderColor;//Obtiene o establece el color del borde del formulario  
        //Controles privados
        private Timer timerFadeIn;//Se usa para mostrar el formulario gradualmente-> Efecto fundido

        /// Constantes             
        private const int resizeAreaSize = 10; //Determina el tamaño del área de cambio de tamaño del formulario.
        private const int WS_MINIMIZEBOX = 0x20000;//Métodos nativos: representa un estilo de ventana que tiene un botón de minimizar
        private const int WM_NCHITTEST = 0x0084;//Win32, Notificación de entrada del mouse: determina qué parte de la ventana corresponde a un punto, permite cambiar el tamaño del formulario.

        #endregion

        #region -> Constructor

        /// Constructor
        public RJBaseForm()
        {
            /* Inicializar los componentes para el diseño del formulario*/
            components = new System.ComponentModel.Container();//inicializar contenedor

            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            miSnapLeft = new FontAwesome.Sharp.IconMenuItem();
            miSnapRight = new FontAwesome.Sharp.IconMenuItem();
            miExitSnap = new FontAwesome.Sharp.IconMenuItem();
            timerFadeIn = new Timer(components);//Agregar al contenedor de componentes

            #region -Control Box Buttons
            // 
            // Button: Cerrar
            //           
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.CloseWhite;
            btnClose.Location = new Point(175, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 40);
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(Close_Click);
            btnClose.MouseEnter += new EventHandler(btnClose_MouseEnter);
            btnClose.MouseLeave += new EventHandler(btnClose_MouseLeave);
            // 
            // Button: Maximizar
            // 
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Image = Properties.Resources.MaximizeWhite;
            btnMaximize.Location = new Point(140, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(35, 40);
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += new System.EventHandler(MaximizeRestore_Click);
            btnMaximize.MouseEnter += new EventHandler(btnMaximize_MouseEnter);
            btnMaximize.MouseLeave += new EventHandler(btnMaximize_MouseLeave);
            // 
            // Button: Minimizar
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Image = Properties.Resources.MinimizeWhite;
            btnMinimize.Location = new Point(105, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(35, 40);
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += new System.EventHandler(Minimize_Click);
            btnMinimize.MouseEnter += new EventHandler(btnMinimize_MouseEnter);
            btnMinimize.MouseLeave += new EventHandler(btnMinimize_MouseLeave);
            #endregion

            #region -Snap Window
            // 
            // MenuItem: Acoplar hacia la izquierda (FontAwesome.Sharp library)
            //            
            miSnapLeft.Name = "miSnapLeft";
            miSnapLeft.Text = "Acoplar a la izquierda";
            miSnapLeft.IconSize = 21;
            miSnapLeft.IconChar = IconChar.SignInAlt;
            miSnapLeft.Rotation = -180;
            miSnapLeft.IconColor = RJColors.FantasyColorScheme1;
            miSnapLeft.Click += new System.EventHandler(SnapWindowLeft_Click);
            // 
            // MenuItem: Acoplar hacia la Derecha (FontAwesome.Sharp library)
            // 
            miSnapRight.Name = "miSnapRight";
            miSnapRight.Text = "Acoplar a la derecha";
            miSnapRight.IconSize = 21;
            miSnapRight.IconChar = IconChar.SignInAlt;
            miSnapRight.IconColor = RJColors.FantasyColorScheme2;
            miSnapRight.Click += new System.EventHandler(SnapWindowRight_Click);
            // 
            // MenuItem: Salir de Window Snap (FontAwesome.Sharp library)
            // 
            miExitSnap.Name = "miExitSnap";
            miExitSnap.Text = "Salir acople";
            miExitSnap.IconSize = 21;
            miExitSnap.IconChar = IconChar.CropAlt;
            miExitSnap.IconColor = RJColors.FantasyColorScheme3;
            miExitSnap.Click += new System.EventHandler(ExitSnapWindow_Click);
            #endregion

            #region -Others
            //Timer
            timerFadeIn.Interval = 30;
            timerFadeIn.Tick += new System.EventHandler(this.timerFadeIn_Tick);
            #endregion
            //
            //RJBaseForm
            //            
            this.Font = new Font("Microsoft Sans Serif", UIAppearance.TextSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Fuente predeterminada                    
            this.Resize += new EventHandler(Form_Resize);//Evento cuando se cambia el tamaño del formulario
        }

        #endregion

        #region -> Propiedades
        /// Controles       
        protected Button btnMinimize { get; private set; }//Botón minimizar
        protected Button btnMaximize { get; private set; }//Botón de maximizar
        protected Button btnClose { get; private set; }//Botón cerrar       
        protected IconMenuItem miSnapLeft { get; private set; }///Elemento de menú acoplar a la izquierda [ Note:> ICON MENU ITEM es proporcionado por la librería <see cref="FontAwesome.Sharp"/> ]
        protected IconMenuItem miSnapRight { get; private set; }//Elemento de menú acoplar a la derecha   [ Autor: mkoertgen, GitHub: https://github.com/awesome-inc/FontAwesome.Sharp  ]   
        protected IconMenuItem miExitSnap { get; private set; }//Elemento de menú desacoplar o restaurar tamaño de ventana. 

        ///Valores
        [Browsable(false)]
        protected bool PrimaryForm
        {//Obtiene o establece si es un formulario primario: es un formulario base para todos los formularios de la aplicación (por ejemplo, formulario de inicio de sesión y formulario principal)   

            get { return isPrimaryForm; }
            set { isPrimaryForm = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si el formulario es redimensionable")]
        [DefaultValue(true)]
        public bool Resizable
        {//Obtiene o establece si el formulario es redimensionable (consulte el método WndProc(ref Message message) )
            get { return isResizable; }
            set { isResizable = value; }
        }

        /// Diseño    
        [Category("RJ Code Advance")]
        [Description("Oculta o muestra el botón de minimizar")]
        [DefaultValue(true)]
        public bool DisplayMinimizeButton
        {
            get { return minimizeButton; }
            set
            {
                minimizeButton = value;
                btnMinimize.Visible = minimizeButton;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Oculta o muestra el botón de maximizar")]
        [DefaultValue(true)]
        public bool DisplayMaximizeButton
        {
            get { return maximizeButton; }
            set
            {
                maximizeButton = value;
                btnMaximize.Visible = maximizeButton;
            }
        }

        [Browsable(false)]
        public int BorderSize
        {//Obtiene o establece el ancho del borde del formulario

            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);//El ancho del borde del formulario será definido por la propiedad Padding
            }
        }

        [Browsable(false)]
        public Color BorderColor
        {//Obtiene o establece el color del borde del formulario

            get { return borderColor; }
            set
            {
                borderColor = value;
                this.BackColor = value;//El color del borde del formulario estará determinado por la propiedad BackColor
            }
        }
        [Browsable(false)]//Ocultar propiedad de color de fondo
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

        protected override CreateParams CreateParams
        {//Anular la propiedad de los parámetros de creación de formularios
            get
            {
                CreateParams param = base.CreateParams;
                param.Style |= WS_MINIMIZEBOX; //Establece un cuadro de minimizar en el estilo de la ventana / Permitirá minimizar el formulario desde el icono de la barra de tareas
                return param;
            }
        }

        #endregion

        #region -> Métodos privados

        private void SetMaximizeRestoreIcon()
        {
            if (UIAppearance.Theme == UITheme.Light)
            {
                if (this.WindowState == FormWindowState.Normal)
                    btnMaximize.Image = Properties.Resources.MaximizeDark;
                else
                    btnMaximize.Image = Properties.Resources.RestoreDark;
            }
            else
            {
                if (this.WindowState == FormWindowState.Normal)
                    btnMaximize.Image = Properties.Resources.MaximizeWhite;
                else
                    btnMaximize.Image = Properties.Resources.RestoreWhite;
            }
        }

        private void FadeInEffect()
        {//Efecto de fundido de entrada-> El formulario aparece gradualmente
            this.Opacity = 0.0;
            timerFadeIn.Start();
        }
        private void ApplyAppearanceSettings()
        {
            if (UIAppearance.Theme == UITheme.Light)
            {
                this.btnClose.Image = Properties.Resources.CloseDark;
                this.btnMaximize.Image = (this.WindowState == FormWindowState.Normal) ? Properties.Resources.MaximizeDark : Properties.Resources.RestoreDark;
                this.btnMinimize.Image = Properties.Resources.MinimizeDark;
            }
            else
            {
                this.btnClose.Image = Properties.Resources.CloseWhite;
                this.btnMaximize.Image = (this.WindowState == FormWindowState.Normal) ? Properties.Resources.MaximizeWhite : Properties.Resources.RestoreWhite;
                this.btnMinimize.Image = Properties.Resources.MinimizeWhite;
            }
        }

        #endregion

        #region -> Métodos protegidos
   
        protected virtual void CloseWindow()
        {
            if (isPrimaryForm)//Si es un formulario principal (por ejemplo, MainForm o formulario de inicio de sesión) Cerrar completamente la aplicación.
            {
                var result = RJMessageBox.Show("Estas seguro de salir de la aplicación?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    Application.Exit();//Termina todos los bucles de mensajes y cierra todas las ventanas
            }
            else//Si es un formulario secundario
                this.Close();//Cerrar formulario actual
        }
        protected void MinimizeWindow()
        {//minimizar el formulario
            this.WindowState = FormWindowState.Minimized;
        }
        protected void MaximizeWindow()
        {//Maximizar o restaurar el formulario a su tamaño normal

            if (this.WindowState == FormWindowState.Normal)//Maximizar el formulario
            {
                ///<Note>:Al maximizar un formulario sin bordes, cubre toda la pantalla ocultando la barra de tareas,
                ///para ello debes especificar un tamaño máximo:</Note>               
                this.MaximumSize = Screen.FromHandle(this.Handle).WorkingArea.Size;//Establecer el tamaño del área del escritorio como el tamaño máximo del formulario
                this.WindowState = FormWindowState.Maximized;
                BorderSize = 0;//Eliminar borde en estado maximizado
                isMaximized = true;//Establecer estado maximizado

                if (snapWindow == true)//Si Snap Window está activado, establecemos su tamaño normal.
                {
                    this.Size = tempSize;
                    snapWindow = false;
                }
            }
            else//Restaurar el formulario
            {
                this.WindowState = FormWindowState.Normal;
            }
            SetMaximizeRestoreIcon();//Actualizar icono del botón.
        }
        protected void SnapWindowLeft()
        {/*Acoplar el formulario a la izquierda del escritorio: Ancho = La mitad del ancho del área del escritorio, Alto = Alto del área del escritorio */

            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;

            var screen = Screen.FromHandle(this.Handle);//Obtiene la pantalla del sistema actual donde se encuentra el formulario
            var desktopArea = screen.WorkingArea.Size;//Obtiene el área de trabajo de la pantalla (excluir la barra de tareas)
            var newSize = new Size(desktopArea.Width / 2, desktopArea.Height);/* Establecer el tamaño del formulario:
                                                                                 Ancho = la mitad del ancho del área del escritorio,
                                                                                 Alto = alto del área del escritorio */
            if (this.Size != newSize)//guardar el tamaño actual del formulario para que se pueda restablecer cuando salga del modo snap
                tempSize = this.Size;
            if (snapWindow == false)
                tempLocation = this.Location;

            this.Size = newSize;//Establece el nuevo tamaño del formulario
            this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);/*Establecer la ubicación del formulario (coordenadas Y y X de los límites de la pantalla)
                                                                          Acoplar el formulario a la IZQUIERDA del escritorio*/
            snapWindow = true;//Establecer estado snap
        }
        protected void SnapWindowRight()
        {/*Acoplar el formulario a la derecha del escritorio: Ancho = La mitad del ancho del área del escritorio, Alto = Alto del área del escritorio */

            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;

            var screen = Screen.FromHandle(this.Handle);
            var desktopArea = screen.WorkingArea.Size;
            var newSize = new Size(desktopArea.Width / 2, desktopArea.Height);

            if (this.Size != newSize)
                tempSize = this.Size;
            if (snapWindow == false)
                tempLocation = this.Location;

            this.Size = newSize;
            this.Location = new Point(
                screen.Bounds.X + desktopArea.Width / 2, screen.Bounds.Y);/* Establecer la ubicación del formulario (Coordenada X = punto medio del área del escritorio)
                                                                             Acoplar el formulario a la DERECHA del escritorio */
            snapWindow = true;
        }
        protected void ExitSnapWindow()
        {//Restaura el tamaño del formulario después de acoplar la ventana

            if (snapWindow == true)
            {
                this.Size = tempSize;
                this.Location = tempLocation;
                snapWindow = false;
            }
        }



        #endregion

        #region -> Anulaciones

        protected override void WndProc(ref Message message)
        {//Función WindowProc: anulación del procesamiento de mensajes de Windows / nivel de sistema operativo

            // Valores de Redimensionamiento/WM_NCHITTEST
            const int HTCLIENT = 1; // Representa el área del cliente de la ventana
            const int HTLEFT = 10; // Borde izquierdo de una ventana, permite redimensionar horizontalmente a la izquierda
            const int HTRIGHT = 11; // Borde derecho de una ventana, permite redimensionar horizontalmente a la derecha
            const int HTTOP = 12; // Borde superior horizontal de una ventana, permite cambiar el tamaño verticalmente hacia arriba
            const int HTTOPLEFT = 13; // Esquina superior izquierda del borde de una ventana, permite cambiar el tamaño en diagonal hacia la izquierda
            const int HTTOPRIGHT = 14; // Esquina superior derecha del borde de una ventana, permite cambiar el tamaño en diagonal hacia la derecha
            const int HTBOTTOM = 15; // Borde inferior horizontal de una ventana, permite cambiar el tamaño verticalmente hacia abajo
            const int HTBOTTOMLEFT = 16; // Esquina inferior izquierda del borde de una ventana, permite cambiar el tamaño en diagonal hacia la izquierda
            const int HTBOTTOMRIGHT = 17; // Esquina inferior derecha del borde de una ventana, permite cambiar el tamaño en diagonal hacia la derecha
            ///<Doc> Más información: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (isResizable) /* Permitir el cambio de tamaño del formulario siempre que sea redimensionable desde los bordes*/
            {
                switch (message.Msg)
                {
                    case WM_NCHITTEST: //Si el mensaje de Windows es WM_NCHITTEST
                        base.WndProc(ref message);
                        if (this.WindowState == FormWindowState.Normal)//Cambiar el tamaño del formulario si está en estado normal
                        {
                            if ((int)message.Result == HTCLIENT)//Si el resultado del mensaje (puntero del mouse) está en el área del cliente de la ventana
                            {
                                Point screenPoint = new Point(message.LParam.ToInt32()); //Obtiene las coordenadas del punto de la pantalla (coordenadas X & Y del puntero)
                                Point clientPoint = this.PointToClient(screenPoint); //Calcula la ubicación del punto de la pantalla en las coordenadas del cliente                          

                                if (clientPoint.Y <= resizeAreaSize)//Si el puntero está en la parte superior del formulario (dentro del área de cambio de tamaño, coordenada X)
                                {
                                    if (clientPoint.X <= resizeAreaSize) //Si el puntero está en la coordenada X = 0 o menos que el área de cambio de tamaño (X = 10) en
                                        message.Result = (IntPtr)HTTOPLEFT; //Cambiar el tamaño en diagonal hacia la izquierda
                                    else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//Si el puntero está en la coordenada X = 11 o menos que el ancho del formulario (X = Form.Width-resizeArea)
                                        message.Result = (IntPtr)HTTOP; // Cambiar el tamaño verticalmente hacia arriba
                                    else //Cambiar el tamaño en diagonal hacia la derecha
                                        message.Result = (IntPtr)HTTOPRIGHT;
                                }
                                else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //Si el puntero está dentro del formulario en la coordenada Y (descontando el tamaño del área de cambio de tamaño)
                                {
                                    if (clientPoint.X <= resizeAreaSize)//Cambiar el tamaño horizontalmente a la izquierda
                                        message.Result = (IntPtr)HTLEFT;
                                    else if (clientPoint.X > (this.Width - resizeAreaSize))//Cambiar el tamaño horizontalmente a la derecha
                                        message.Result = (IntPtr)HTRIGHT;
                                }
                                else
                                {
                                    if (clientPoint.X <= resizeAreaSize)//Cambiar el tamaño en diagonal hacia la izquierda
                                        message.Result = (IntPtr)HTBOTTOMLEFT;
                                    else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) // Cambiar el tamaño verticalmente hacia abajo
                                        message.Result = (IntPtr)HTBOTTOM;
                                    else //Cambiar el tamaño en diagonal hacia la derecha
                                        message.Result = (IntPtr)HTBOTTOMRIGHT;
                                }
                            }
                        }
                        return;
                }
            }
            base.WndProc(ref message);
        }

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
            ApplyAppearanceSettings();//Aplicar configuraciones

            if (this.TopLevel == true) //(ToLevel = false, significa que el formulario es un control, la propiedad de opacidad no tiene efecto)
            {
                FadeInEffect();//Muestrar el formulario gradualmente
            }
        }
        #endregion

        #region -> Métodos de evento

        private void timerFadeIn_Tick(object sender, EventArgs e)
        {//Timer -> Efecto de aparición gradual

            if (this.Opacity < 1) this.Opacity += 0.1;//Aumenta la opacidad en 0.01
            else timerFadeIn.Stop();//Detenga el temporizador cuando la opacidad del formulario sea 1.
        }

        private void Close_Click(object sender, EventArgs e) { CloseWindow(); }
        private void Minimize_Click(object sender, EventArgs e) { MinimizeWindow(); }
        private void MaximizeRestore_Click(object sender, EventArgs e) { MaximizeWindow(); }
        private void SnapWindowLeft_Click(object sender, EventArgs e) { SnapWindowLeft(); }
        private void SnapWindowRight_Click(object sender, EventArgs e) { SnapWindowRight(); }
        private void ExitSnapWindow_Click(object sender, EventArgs e) { ExitSnapWindow(); }
        private void Form_Resize(object sender, EventArgs e)
        {
            // Establecer Ancho de borde del formulario y actualizar el botón de maximizado cuando el formulario se restaura a su tamaño normal y el interruptor isMaximized está activo
            if (this.WindowState == FormWindowState.Normal && isMaximized == true)
            {
                isMaximized = false;
                BorderSize = UIAppearance.FormBorderSize;
                SetMaximizeRestoreIcon();
            }
            /// <Nota> Si la variable isMaximized no existiera,
            /// el código anterior siempre se ejecutará cuando el formulario cambie de tamaño,
            /// ubicación o arrastrado punto por punto, que podría ralentizarse un poco.
            /// Entonces, con la condición anterior, el fragmento de código solo se ejecutará una vez </Note>
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = (UIAppearance.Theme == UITheme.Light) ? Color.FromArgb(220, 225, 235) : Color.FromArgb(45, 52, 75);
            if (UIAppearance.Theme == UITheme.Dark)
                btnMinimize.Image = Properties.Resources.MinimizeWhite;
        }
        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.Image = (UIAppearance.Theme == UITheme.Light) ? Properties.Resources.MinimizeDark : Properties.Resources.MinimizeWhite;
        }
        private void btnMaximize_MouseEnter(object sender, EventArgs e)
        {
            btnMaximize.BackColor = (UIAppearance.Theme == UITheme.Light) ? Color.FromArgb(220, 225, 235) : Color.FromArgb(45, 52, 75);
            if (UIAppearance.Theme == UITheme.Dark)
                btnMaximize.Image = (this.WindowState == FormWindowState.Normal) ? Properties.Resources.MaximizeWhite : Properties.Resources.RestoreWhite;
        }
        private void btnMaximize_MouseLeave(object sender, EventArgs e)
        {
            btnMaximize.BackColor = Color.Transparent;
            SetMaximizeRestoreIcon();
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.Image = Properties.Resources.CloseWhite;
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.Image = (UIAppearance.Theme == UITheme.Light) ? Properties.Resources.CloseDark : Properties.Resources.CloseWhite;
        }

        #endregion
    }
}

