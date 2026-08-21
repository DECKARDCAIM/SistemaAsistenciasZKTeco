using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    public class RJDragControl : Component
    {
        /// <summary>
        /// Esta clase hereda de la clase de <see cref="Componente"/> , Un componente es la clase base para todos los componentes
        /// en Common Language Runtime que clasifica por referencia. En este caso, se trata básicamente de
        /// convertir esta clase en un control sin diseño (componente)
        ///
        /// El método <ReleaseCapture () /> es una función externa de la biblioteca user.32, este método libera la captura
        /// del mouse de una ventana en el hilo actual y restaura el procesamiento de entrada normal del mouse.
        ///
        /// El método <SendMessage (....) /> es una función externa de la biblioteca user.32, este método envía el
        /// mensaje a una ventana o ventanas. La función SendMessage llama al procedimiento de ventana para la
        /// ventana especificada y no regresa hasta que el procedimiento de ventana haya procesado el mensaje.
        /// <param name="hWnd">Un identificador de la ventana cuyo procedimiento de ventana recibirá el mensaje</param>
        /// <param name="wMsg">El mensaje a enviar</param>
        /// <param name="wParam">Información adicional específica del mensaje.</param>
        /// <param name="lParam">Información adicional específica del mensaje.</param>
        /// 
        /// Para los 2 Métodos anteriores es necesario importar la biblioteca <user32.DLL /> de código no administrado
        /// a través de los servicios de Interop <ver cref = "using System.Runtime.InteropServices;" />
        /// <see cref="DllImportAttribute"/>([DllImport("dll name")]), Indica que el método atribuido está expuesto por
        /// una biblioteca de vínculos dinámicos (DLL) no administrada como un punto de entrada estático
        /// </summary>
        /// 

        #region -> Campos

        private Control dragControl;//Obtiene o establece el control responsable de arrastrar el formulario
        private Form targetForm;//Obtiene o establece el formulario objetivo para arrastrar
        #endregion

        #region -> Constructores

        public RJDragControl()
        {
            //Constructor sin parámetros  
        }
        public RJDragControl(IContainer container) //Este constructor se invoca automáticamente en el diseñador de formularios cuando el control se arrastra desde la caja de herramientas al formulario.
        {
            //Inicializa una nueva instancia y la asocia con el contenedor especificado.
            //Este constructor asegura que el objeto se elimine correctamente, ya que no es un elemento secundario del formulario.
            container.Add((IComponent)this);           
        }
        public RJDragControl(Control _dragControl, Form _targetForm)
        {
            targetForm = _targetForm;
            dragControl = _dragControl;
            dragControl.MouseDown += new MouseEventHandler(Control_MouseDown);//Asociar el evento MouseDown: ocurre cuando se mantiene presionado el botón del mouse en el control de arrastre
        }
        public RJDragControl(Control _dragControl, Form _targetForm, IContainer container)
        {   //Inicializa una nueva instancia y la asocia con el contenedor especificado.
            //Este constructor asegura que el objeto se elimine correctamente, ya que no es un elemento secundario del formulario.
            container.Add((IComponent)this); 
           
            targetForm = _targetForm;
            dragControl = _dragControl;
            dragControl.MouseDown += new MouseEventHandler(Control_MouseDown);//Asociar el evento MouseDown: ocurre cuando se mantiene presionado el botón del mouse en el control de arrastre.
        }
      
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Set the control responsible for dragging the form")]
        public Control DragControl
        {
            get { return dragControl; }
            set
            {
                dragControl = value;//Establecer el control de arrastre
                if (dragControl != null)
                {
                    dragControl.HandleCreated += new EventHandler(Control_Created);//Asociar el evento HandleCreate: ocurre cuando el control se muestra por primera vez en su contenedor (formulario, panel, etc.)
                    dragControl.MouseDown += new MouseEventHandler(Control_MouseDown);//Asociar el evento MouseDown: ocurre cuando se mantiene presionado el botón del mouse en el control de arrastre
                }
            }
        }
        #endregion

        #region -> Importar Métodos externos

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region -> Métodos de evento

        private void Control_Created(object sender, EventArgs e)
        {
            //Ocurre cuando el control se muestra por primera vez en su contenedor (formulario, panel, etc.)
            if (!this.DesignMode)
                targetForm = dragControl.FindForm();//Econtrar el formulario al que pertenece el control y establecer como el formulario objetivo para arrastrar
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            //Ocurre cuando el botón del mouse se mantiene presionado en el control y al moverlo arrastrará el formulario

            ReleaseCapture();//Libera la captura del mouse desde una ventana           
            SendMessage(targetForm.Handle, 0x112, 0xf012, 0);//Enviar mensaje a la ventana
            /// <param value="targetForm.Handle">enviar el controlador de formulario de destino para arrastrar</param>
            /// <param value="0x112">Enviar WM_SYSCOMMAND como mensaje</param>
            /// <param value="0xf012">Enviar un clic falso en la barra de título (Hacer clic en la barra de título genera 0xF012)</param>
        }
        #endregion

    }
}
