using FontAwesome.Sharp;
using RJCodeUI_M1.Settings;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    class DropdownMenuRenderer : ToolStripProfessionalRenderer
    {
        /// <summary>
        /// Esta clase hereda la clase <see cref = "ToolStripProfessionalRenderer"/> que proporciona
        /// la funcionalidad de pintura para objetos <see cref ="ToolStrip" /> , aplicando una paleta personalizada y un
        /// estilo simplificado basado en una tabla de colores reemplazable llamada <see cref = "ProfessionalColorTable"/>.
        /// Recuerde que la clase ToolStripProfessionalRenderer llama a una instancia de la clase <see cref = "ProfessionalColorTable" />,
        /// En este caso, la clase <see cref ="DropdownMenuColors"/> hereda la clase ProfessionalColorTable.
        ///
        /// El parámetro <see cref = "bool menuButton" /> del constructor, simplemente establece si el menú desplegable se muestra desde el botón de menú del formulario principal o no.
        /// </summary>
        /// 

        //Definición de campo
        private Bitmap dropdownItemIcon;//Establece el icono de un elemento de menú desplegable.

        //Constructor 
        public DropdownMenuRenderer(bool menuButton)
            : base(new DropdownMenuColors(menuButton))
        ///Enviar el valor del botón de menú y enviar una instancia de la clase DropdownMenuColors personalizada(<"ProfessionalColorTable"/>)
        ///a la clase base <ToolStripProfessionalRenderer/>.
        { 
            dropdownItemIcon = IconChar.AngleRight.ToBitmap(UIAppearance.StyleColor, 25);//Establecer el icono para los elementos de menú desplegables.
        }

        //Anular el evento OnRenderArrow para dibujar el icono personalizado de un elemento de menú desplegable.
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)///Ocurre cuando se renderiza (Dibuja) la flecha de un <see cref = "ToolStripItem" /> desplegable.
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavizado

            Point point = new Point(e.ArrowRectangle.Location.X - 10, e.Item.Height / 2 - 7);//Establecer la ubicación del icono para dibujar
            var rectangle = new Rectangle(point, new Size(25, 25)); // Crear un objeto rectangulo.

            e.Graphics.DrawImage(dropdownItemIcon, rectangle);//Dibujar el icono en el elemento desplegable.
        }

    }


}

