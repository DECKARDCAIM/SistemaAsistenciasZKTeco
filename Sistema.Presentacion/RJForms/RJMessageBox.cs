using RJCodeUI_M1.RJForms.Private;
using System.Windows.Forms;

namespace RJCodeUI_M1
{
    public abstract class RJMessageBox
    {
        /// <summary>
        /// En esta clase abstracta, simplemente se implementa Métodos estáticos para mostrar el formulario de cuadro de mensaje personalizado (<see cref = "RJMessageForm" />) y devolver un DialogResult.
        /// Intenté integrar la mayoría de los Métodos show del clásico cuadro de mensajes (<see cref = "MessageBox.Show" />) que tiene 21 sobrecargas de este método.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=net-5.0"/>
        /// Mas información acerca de la propiedad DialogResult.
        /// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.button.dialogresult?view=net-5.0
        /// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.dialogresult?view=net-5.0
        /// </summary>      
        /// <returns>DialogResult</returns>

        public static DialogResult Show(string text)
        {// Muestra un cuadro de mensaje con el texto especificado

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.         
            using (var msgForm = new RJMessageForm(text,//Establecer mensaje de texto para mostrar
               "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))//Establecer otros valores predeterminados
            {
                result = msgForm.ShowDialog();//Mostrar como formulario modal 
            }
            return result;//Retornar Dialog Result
        }
        public static DialogResult Show(string text, string caption)
        {//Muestra un cuadro de mensaje con el texto y título especificados.

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.  
            using (var msgForm = new RJMessageForm(text, caption,//Establecer mensaje de texto y título para mostrar
                           MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))//Establecer otros valores predeterminados
            {
                result = msgForm.ShowDialog();//Mostrar como formulario modal           
            }
            return result;//Retornar Dialog Result  
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {//Muestra un cuadro de mensaje con texto, título y botones especificados

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.  
            using (var msgForm = new RJMessageForm(text, caption, buttons,//Establecer mensajes de texto, título y botones para mostrar
                                             MessageBoxIcon.None, MessageBoxDefaultButton.Button1))//Establecer otros valores predeterminados
            {
                result = msgForm.ShowDialog();//Mostrar como formulario modal
            }
            return result;//Retornar Dialog Result  
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {//Muestra un cuadro de mensaje con texto, título, botones e íconos especificados

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.  
            using (var msgForm = new RJMessageForm(text, caption, buttons, icon,//Establecer mensaje de texto, título, botones e íconos para mostrar
                                               MessageBoxDefaultButton.Button1))//Establecer otros valores predeterminados
            {               
                result = msgForm.ShowDialog(); //Mostrar como formulario modal 
            }
            
            return result;//Retornar Dialog Result  
        }
       
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {//Muestra un cuadro de mensaje con el texto, título, botones, icono y botón predeterminado especificados.

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.  
            using (var msgForm = new RJMessageForm(text, caption, buttons, icon, defaultButton))//Establecer mensaje de texto, título, botones, icono y botón predeterminado para mostrar
            {
                result = msgForm.ShowDialog();//Mostrar como formulario modal           
            }
            return result;//Retornar Dialog Result  
        }
        public static DialogResult Show(IWin32Window owner, string text)
        {//Muestra un cuadro de mensaje delante del objeto especificado y con el texto especificado

            DialogResult result; //Obtiene o establece el resultado del cuadro de diálogo del formulario.

            // Instanciar al formulario RJMessageForm utilizando USING para desechar el formulario correctamente cuando haya terminado su propósito.  
            using (var msgForm = new RJMessageForm(text,
                /*->Valores predeterminados:*/"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                result = msgForm.ShowDialog(owner);
            }
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            DialogResult result;

            using (var msgForm = new RJMessageForm(text, caption,
                /*->Valores predeterminados:*/ MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                result = msgForm.ShowDialog(owner);
            }
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;

            using (var msgForm = new RJMessageForm(text, caption, buttons,
                /*->Valores predeterminados:*/ MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                result = msgForm.ShowDialog(owner);
            }
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;

            using (var msgForm = new RJMessageForm(text, caption, buttons, icon,
                /*->Valores predeterminados:*/MessageBoxDefaultButton.Button1))
            {
                result = msgForm.ShowDialog(owner);
            }
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;

            using (var msgForm = new RJMessageForm(text, caption, buttons, icon, defaultButton))
            {
                result = msgForm.ShowDialog(owner);
            }
            return result;
        }

    }
}
