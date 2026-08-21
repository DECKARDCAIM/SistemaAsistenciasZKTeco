using System;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;
using System.ComponentModel;

namespace RJCodeUI_M1.RJControls
{
    public class RJDropdownMenu : ContextMenuStrip
    {
        /// <summary>
        /// Esta clase hereda de la clase ContextMenuStrip.
        /// Para personalizar la apariencia de este control se usa las clases:
        /// <see cref="DropdownMenuColors"/> y <see cref="DropdownMenuRenderer"/>
        /// También le ayuda a posicionar el control de una manera más fácil gracias 
        /// a la enumeración <see cref="DropdownMenuPosition"/>.
        /// </summary>-.......
        /// 

        #region -> Campos
        private bool ownerIsMenuButton; //Establece u obtiene si el menú desplegable pertenece al boton de menú del menú lateral del formulario principal <see cref="RJMenuButton"/>
        private bool activeMenuItem;//Establece u obtiene si elemento de menú está activado (tiene un formulario asociado, un elemento de menú permanecerá resaltado cuando el formulario esté abierto)         
        private Bitmap menuItemIcon;//Establece u obtiene el ícono del elemento del menú, también establece la altura del elemento de menú.
        #endregion

        #region -> Constructores

        public RJDropdownMenu()
        {           
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Establecer fuente predeterminada          
        }
        //
        // Summary:
        //     Inicializa una nueva instancia de la clase RJDropdownMenu
        //     y lo asocia con el contenedor especificado.
        //
        // Parameters:
        //   container:
        //     Un componente que implementa System.ComponentModel.IContainer que es el contenedor
        //     del system.Windows.Forms.ContextMenuStrip.
        public RJDropdownMenu(IContainer container)//Este constructor se invoca automáticamente en el diseñador de formularios cuando el control se arrastra desde la caja de herramientas al formulario.
            : base(container)////Este constructor asegura que el objeto se elimine correctamente, ya que no es un elemento secundario del formulario.
        {            
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));//Establecer fuente predeterminada           
        }
        #endregion

        #region -> Propiedades
        [Browsable(false)]
        public bool OwnerIsMenuButton
        {//Establece u obtiene si el menú desplegable pertenece al boton de menú del menú lateral del formulario principal
            get { return ownerIsMenuButton; }
            set
            {
                ownerIsMenuButton = value;
                //Establecer el renderizador personalizado y enviar la propiedad ownerIsMenuButton al parámetro. (Solo en tiempo de ejecución)
                if (this.DesignMode == false)
                    this.Renderer = new DropdownMenuRenderer(ownerIsMenuButton);
            }
        }
        [Browsable(false)]
        public bool ActiveMenuItem
        {
            get { return activeMenuItem; }
            set { activeMenuItem = value; }
        }
        #endregion

        #region -> Métodos privados


        private void LoadItemAppearance()
        {
            Color menuItemTextColor;
            //Establecer color del texto
            if (UIAppearance.Theme == UITheme.Dark || ownerIsMenuButton == true)
                menuItemTextColor = RJColors.DarkTextColor;
            else menuItemTextColor = RJColors.LightTextColor;

            //- Establecer la altura del elemento de menú y el ancho de la columna izquierda del menú desplegable mediante la propiedad imagen del elemento del menú.
            if (OwnerIsMenuButton == true)//Si el propetario es un botón de menú.
                menuItemIcon = new Bitmap(25, 45);//Establecer 25 px de ancho y 45 px de ALTURA
            else //Caso contrario, valor por defecto y altura especificada.
                menuItemIcon = new Bitmap(22, 25);//Establecer 22 px de ancho y la altura especificada. 

            //- Establecer el color del texto de la configuración y ajustar la imagen del elemento de menú (icono)
            #region - Dropdown Menu Item Level 1 ---------------------------------------------
            foreach (ToolStripMenuItem menuItemL1 in this.Items)
            {
                if (activeMenuItem == false)//Establecer el color del texto cuando no tenga un elemento de menú activado, es decir, mantener el color resaltado que se establece en el boton de menú.
                    menuItemL1.ForeColor = menuItemTextColor;//Establecer el color del texto
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image == null)//Si no se establece ninguna imagen en el elemento del menú, establecer el mapa de bits sin imagen (menuItemIcon) para mantener la altura y el ancho definidos previamente.
                    menuItemL1.Image = menuItemIcon;//Establecer mapa de bits sin imagen
                else//Si se ha establecido una imagen en el elemento del menú, reajustar la imagen para mantener la altura y el ancho definidos previamente (Limitar el ancho de la columna izquierda y la altura del elemento del menú)
                    menuItemL1.Image = RedrawMenuItemIcon(menuItemL1.Image);//Volver a dibujar icono de elemento de menú
            #endregion ---------------------------------------------

                #region - Dropdown Menu Item Level 2 ---------------------------------------------
                foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                {
                    if (activeMenuItem == false)
                        menuItemL2.ForeColor = menuItemTextColor;
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image == null) menuItemL2.Image = menuItemIcon;
                    else menuItemL2.Image = RedrawMenuItemIcon(menuItemL2.Image);
                #endregion ---------------------------------------------

                    #region - Dropdown Menu Item Level 3 ---------------------------------------------
                    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems)
                    {
                        if (activeMenuItem == false)
                            menuItemL3.ForeColor = menuItemTextColor;
                        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItemL3.Image == null) menuItemL3.Image = menuItemIcon;
                        else menuItemL3.Image = RedrawMenuItemIcon(menuItemL3.Image);
                    #endregion ---------------------------------------------

                        #region - Dropdown Menu Item Level 4 ---------------------------------------------

                        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems)
                        {
                            if (activeMenuItem == false)
                                menuItemL4.ForeColor = menuItemTextColor;
                            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItemL4.Image == null) menuItemL4.Image = menuItemIcon;
                            else menuItemL4.Image = RedrawMenuItemIcon(menuItemL4.Image);

                        }
                        #endregion ---------------------------------------------
                    }
                }
            }
        }
        private Image RedrawMenuItemIcon(Image itemImage)
        {//este método cambiará el tamaño y centrará la imagen del elemento del menú

            var newItemIcon = new Bitmap(menuItemIcon.Width, menuItemIcon.Height);//Crear un nuevo mapa de bits con las dimensiones especificadas anteriormente.

            if (itemImage.Size.Width > newItemIcon.Size.Width)//si el tamaño de la imagen del elemento es mayor que la imagen del icono especificado
                itemImage = new Bitmap(itemImage, new Size(newItemIcon.Width - 1, newItemIcon.Width - 1));//Cambie el tamaño de la imagen restando 1 para aplicar relleno.

            //Obtener posición centrada
            int locX = (menuItemIcon.Width - itemImage.Width) / 2;
            int locY = (menuItemIcon.Height - itemImage.Height) / 2;

            using (Graphics graphic = Graphics.FromImage(newItemIcon))//dibujar la imagen redimensionada y centrada en el mapa de bits creado newItemIcon
            {
                graphic.DrawImage(itemImage, locX, locY);
            };
            return newItemIcon;//Devolver nuevo ícono del elemento del menú.
        }

        #endregion

        #region -> Métodos anulados

        public void Show(Control ownerControl, DropdownMenuPosition position)
        { //este método le ayuda a mostrar y colocar el menú desplegable más rápidamente

            LoadItemAppearance();//Aplicar la Configuración

            int x = 0;
            int y = 0;

            switch (position)
            {
                case DropdownMenuPosition.LeftTop:
                    x = 0 - this.Width;
                    y = 0;
                    break;
                case DropdownMenuPosition.LeftBottom:
                    x = 0;
                    y = ownerControl.Height;
                    break;
                case DropdownMenuPosition.TopRight:
                    x = ownerControl.Width;
                    y = 0;
                    break;
                case DropdownMenuPosition.BottomRight:
                    x = ownerControl.Width - this.Width;
                    y = ownerControl.Height;
                    break;

            }
            this.Show(ownerControl, x, y); //enviar valores para mostrar el menú desplegable
        }
        //Cargar la apariencia del elemento de menú en todos los metodos base de mostrar.
        public new void Show()
        {
            LoadItemAppearance();
            base.Show();
        }
        public new void Show(Point screenLocation)
        {
            LoadItemAppearance();
            base.Show(screenLocation);
        }
        public new void Show(int x, int y)
        {
            LoadItemAppearance();
            base.Show(x, y);
        }
        public new void Show(Point position, ToolStripDropDownDirection direction)
        {
            LoadItemAppearance();
            base.Show(position, direction);
        }
        public new void Show(Control ownerControl, Point position)
        {
            LoadItemAppearance();
            base.Show(ownerControl, position);
        }
        public new void Show(Control ownerControl, int x, int y)
        {
            LoadItemAppearance();
            base.Show(ownerControl, x, y);
        }
        public new void Show(Control ownerControl, Point position, ToolStripDropDownDirection direction)
        {
            LoadItemAppearance();
            base.Show(ownerControl, position, direction);
        }
        #endregion
    }
}
