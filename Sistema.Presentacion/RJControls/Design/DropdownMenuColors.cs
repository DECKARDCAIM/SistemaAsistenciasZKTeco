using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace RJCodeUI_M1.RJControls
{
    class DropdownMenuColors : ProfessionalColorTable
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "ProfessionalColorTable"/> que proporciona los colores utilizados para los elementos de visualización de Microsoft Office.
        /// También tenga en cuenta que la clase <see cref = "ToolStripProfessionalRenderer"/> llama a una instancia de esta clase
        /// en este caso la clase derivada <see cref = "DropdownMenuRenderer"/> que hereda esta clase.
        /// </summary> 

        //Campos
        private Color dropdownMenuBackground;//Establece el color de fondo del menú desplegable.
        private Color dropdownMenuBorder;//Establece el color del borde del menú desplegable.
        private Color leftColumnGradientBegin;//Establece el color de inicio de la columna izquierda del menú desplegable.
        private Color leftColumnGradientMiddle;//Establece el color medio de la columna izquierda del menú desplegable.
        private Color leftColumnGradientEnd;//Establece el color final de la columna izquierda del menú desplegable.
        private Color menuItemSelected;//Establece el color de fondo del elemento de menú seleccionado o cuando el mouse se desplaza sobre él.
        private Color menuItemBorder;//Establece el color del borde del elemento del menú.


        //Constructor
        public DropdownMenuColors(bool menuButtonOwner)
        {
            if (UIAppearance.Theme == UITheme.Dark || menuButtonOwner == true)//Si el tema es oscuro, o el menú desplegable se muestra desde el botón de menú, establecer los siguientes colores.
            {
                dropdownMenuBackground = RJColors.DarkItemBackground;
                dropdownMenuBorder = ColorEditor.Darken(RJColors.DarkItemBackground, 10);
                menuItemBorder = RJColors.DarkActiveBackground;
                menuItemSelected = RJColors.DarkActiveBackground;
                leftColumnGradientBegin = ColorEditor.Darken(RJColors.DarkItemBackground, 4);
                leftColumnGradientMiddle = ColorEditor.Darken(RJColors.DarkItemBackground, 4);
                leftColumnGradientEnd = ColorEditor.Darken(RJColors.DarkItemBackground, 4);
            }
            else //Si el tema es claro, establecer los siguientes colores
            {
                dropdownMenuBackground = RJColors.LightItemBackground;
                dropdownMenuBorder = ColorEditor.Darken(UIAppearance.BackgroundColor, 10);
                menuItemBorder = RJColors.LightActiveBackground;
                menuItemSelected = RJColors.LightActiveBackground;
                leftColumnGradientBegin = ColorEditor.Darken(RJColors.LightItemBackground, 4);
                leftColumnGradientMiddle = ColorEditor.Darken(RJColors.LightItemBackground, 4);
                leftColumnGradientEnd = ColorEditor.Darken(RJColors.LightItemBackground, 4);
            }
        }
        //Anular los Métodos de color del diseño principal del menú desplegable y devolver las nuevas propiedades de color
        public override Color ToolStripDropDownBackground { get { return dropdownMenuBackground; } }///Obtiene el color de fondo del menu desplegable. <see cref = "ToolStripDropDown"/>
        public override Color MenuBorder { get { return dropdownMenuBorder; } }///Obtiene el color de borde del menu desplegable. <see cref="MenuStrip"/>
        public override Color MenuItemBorder { get { return menuItemBorder; } }///Obtiene el color de borde del elemento de menú. <see cref="ToolStripMenuItem"/> 
        public override Color MenuItemSelected { get { return menuItemSelected; } }///Obtiene el color de fondo del elemento de menú cuando es seleccionado. <see cref="ToolStripMenuItem"/>      
        public override Color ImageMarginGradientBegin { get { return leftColumnGradientBegin; } }///Obtiene el color inicial del degradado utilizado en el margen de la imagen de un <see cref="ToolStripDropDown"/> 
        public override Color ImageMarginGradientMiddle { get { return leftColumnGradientMiddle; } }///Obtiene el color medio del degradado utilizado en el margen de la imagen de un <see cref="ToolStripDropDown"/> 
        public override Color ImageMarginGradientEnd { get { return leftColumnGradientEnd; } }///Obtiene el color final del degradado utilizado en el margen de la imagen de un <see cref="ToolStripDropDown"/> 

    }
}
