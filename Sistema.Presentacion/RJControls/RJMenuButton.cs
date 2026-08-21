using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using FontAwesome.Sharp;
using RJCodeUI_M1.RJForms;

namespace RJCodeUI_M1.RJControls
{
    public class RJMenuButton : IconButton
    {
        /// <summary>
        ///------Esta clase hereda de la clase <see cref = "IconButton" /> de la biblioteca <see cref = "FontAwesome.Sharp" />
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp
        ///      
        /// Este es un control especial que solo está diseñado para ser utilizado en el menú lateral del formulario principal.
        /// Este control puede funcionar como un botón de menú normal o como un botón de menú desplegable, para esto necesitas
        /// agregar un menú desplegable (<ver cref = "RJDropdownMenu" />) en la propiedad <see cref = "DropdownMenu" />
        /// de este control y el evento de clic se creará automáticamente para mostrar el menú desplegable.
        /// Tiene 2 Métodos esenciales de apariencia :
        /// -> Como un botón de menú normal: permite asociar un formulario y el botón se activa / resalta
        /// hasta que se cierre el formulario <ver cref = "Activar (RJChildForm)" />
        /// -> Como botón de menú desplegable: permite asociar muchos formularios, el botón y el elemento del menú es
        /// activado / resaltado hasta que se cierren todos los formularios <ver cref = "Activate (RJChildForm, ToolStripMenuItem)" />
        /// Estos Métodos ayudan al usuario a identificar qué formularios están abiertos, funciona de manera similar a las pestañas.
        /// </summary>
        /// 

        #region -> Campos

        //Campos
        private string textLeftPadding;//Establece un relleno a la izquierda antes del texto para mantener un espacio considerable entre el icono y el texto
        private string tempText;//Establece o obtiene texto temporal en caso de que el menú lateral se colapse (el texto está vacío)
        private bool isDropdownMenu;//Establece o obtiene si el botón es un menú desplegable
        private int guestFormsCount;//Almacena la cantidad de formularios asociados que tiene el botón de menú (si el botón no es un menú desplegable solo tendrá un formulario asociado y si el botón es un menú desplegable tendrá 2 o más formularios asociados)
        private Color tempMenuItemTextColor;//Establece o obtiene el color del texto temporal del elemento del menú en caso de que esté activado / resaltado
        private Color supernovaColor = UIAppearance.Style == UIStyle.Supernova ? RJColors.GetSupernovaColor() : Color.CornflowerBlue;//Establece y obtiene el color de supernova si el estilo es supernova

        //Campos de controles
        private RJDropdownMenu dropdownMenu;//Establece u obtiene el menú desplegable
        private IconPictureBox pbDropdownArrowIcon;//Establece y obtiene el icono de ángulo desplegable en caso de que el botón muestre el menú desplegable      

        //Campos estáticos
        private static readonly Color deactivateItemsColor = Color.FromArgb(122, 119, 170);//Establece u obtiene el icono y el color del texto cuando el botón de menú está desactivado
        private static readonly Color activateForeColor = Color.FromArgb(206, 203, 226);//Establece u obtiene el color del texto cuando se activa el botón de menú.
        private static readonly Color activateBackColor = Color.FromArgb(58, 50, 97);//Establece u obtiene el color de fondo cuando se activa el botón de menú y se muestra el menú desplegable

        #endregion

        #region -> Constructor
        public RJMenuButton()
        {
            pbDropdownArrowIcon = new IconPictureBox();
            //inicializar propiedades y eventos
            this.Dock = DockStyle.Top;
            this.BackColor = RJColors.SideMenuColor;
            this.FlatAppearance.BorderSize= 0;
            this.FlatAppearance.MouseDownBackColor = RJColors.DarkItemBackground;
            this.FlatStyle = FlatStyle.Flat;
            this.Flip = FlipOrientation.Normal;
            this.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = deactivateItemsColor;
            this.IconChar =FontAwesome.Sharp. IconChar.DiceD6;
            this.IconColor = deactivateItemsColor;
            this.IconSize = 28;
            this.Rotation = 0D;
            this.Size = new Size(220, 55);
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Padding = new Padding(12, 0, 0, 0);
            this.SizeChanged += new EventHandler(WidthChanged);
            this.HandleCreated += new EventHandler(MB_HandleCreated);
        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (value != null)
                {
                    textLeftPadding = "   ";//Set the number of whitespace to simulate a padding to the left before the text
                    base.Text = textLeftPadding + value.Trim();//Set padding and concatenate text by trimming leading and trailing empty characters
                }
            }
        }

        [Browsable(false)]//Hide ContextMenuStrip property
        [ReadOnly(true)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get { return base.ContextMenuStrip; }
            set { }
        }

        [Category("RJ Code Advance")]///create a new property to associate a <see cref="RJDropdownMenu"/>
        [Description("Gets or sets the RJDropdownMenu associated with this control")]
        public RJDropdownMenu DropdownMenu
        {
            get
            {
                return dropdownMenu;//Return RJDropdownMenu
            }
            set
            {
                dropdownMenu = value;//Set value

                if (dropdownMenu != null)//if the value is not null (Its an object), Set as dropdown menu button
                {
                    isDropdownMenu = true;//Set menu button as dropdown menu
                    dropdownMenu.VisibleChanged += new EventHandler(DropdownMenu_VisibleChanged);//Subscribe RJDropdownMenu.VisibleChanged event
                    DrawDropdownArrowIcon(false);//Draw a dropdown angle icon
                    this.Click += new EventHandler(DropdownMenuButton_Click);//Subscribe click event (show dropdown menu)
                }
                else //if the value is null (Is none), Set normal menu button
                {
                    isDropdownMenu = false;// Set menu button as no dropdown menu
                    this.BackgroundImage = null;//Draw nothing
                }
            }
        }
        #endregion

        #region -> Métodos privados

        private void ActivateButton()
        {//Activar / resaltar el botón de menú

            if (guestFormsCount == 0)
            {//Si el botón aún no tiene un formulario asociado (Esta condición para no reactivar el botón 
                //cuando ya tiene un formulario asociado, por lo que el botón ya ha sido activado previamente)

                this.ForeColor = activateForeColor;//establecer el color del texto del botón de menú
                if (UIAppearance.Style == UIStyle.Supernova)
                    this.IconColor = supernovaColor;//Si el estilo es supernova, establecer el color del icono de un color supernova.
                else this.IconColor = UIAppearance.StyleColor;//Si se trata de cualquier otro tema, establecer el color del estilo como color del icono.
            }
        }
        private void DeactivateButton()
        {
            if (guestFormsCount == 0)//Desactivar el botón de menú siempre en cuando  no tenga un formulario asociado.
            {
                this.IconColor = deactivateItemsColor;
                this.ForeColor = deactivateItemsColor;
                if (this.Width > 100 && isDropdownMenu)//si el ancho es mayor que 100 (es decir, el menú lateral está expandido) y el botón de menú es un menú desplegable,
                    DrawDropdownArrowIcon(false);//Dibujar el icono de flecha contraído, es decir, no se muestra el menú desplegable.

            }
        }
        private void ShowDropdownMenu()
        {
            try //Mostrar el menú desplegable del botón
            {
                dropdownMenu.OwnerIsMenuButton = true; //Indicar al menú desplegable que su propietario es un botón de menú.
                if (this.Width > 100)//Si el menú lateral se expande, mostrar el menú desplegable en la parte inferior derecha del botón de menú.
                    dropdownMenu.Show(this, DropdownMenuPosition.BottomRight);
                else //Si el menú lateral está contraído, mostrar el menú desplegable en la parte superior derecha del botón de menú
                    dropdownMenu.Show(this, DropdownMenuPosition.TopRight);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Se ha producido un error\n" + ex.ToString());
            }
        }
        private void DrawDropdownArrowIcon(bool expandedMenu)
        {//Este método dibuja el ícono de flecha del botón del menú desplegable

            int iconSize = 25;//Definir un tamaño del icono establecido
            Color iconColor = this.IconColor;//Definir y establecer el color del icono.
            Bitmap arrowIcon;//Definir el mapa de bits para el icono de flecha

            pbDropdownArrowIcon.IconSize = iconSize;//Establecer tamaño de icono
            pbDropdownArrowIcon.IconColor = iconColor;//Establecer color de icono

            if (expandedMenu) pbDropdownArrowIcon.IconChar = FontAwesome.Sharp.IconChar.AngleDown;//Si el parámetro es un menú expandido, Establecer flecha hacia abajo como el ícono del menú desplegable
            else pbDropdownArrowIcon.IconChar = FontAwesome.Sharp.IconChar.AngleRight;//Si el parámetro no es un menú expandido, establecer flecha hacia la derecha como el ícono del menú desplegable

            arrowIcon = new Bitmap(this.Width, this.Height);//Inicializar el mapa de bits con el mismo tamaño que el botón de menú
            using (Graphics drawIcon = Graphics.FromImage(arrowIcon))//Crear un objeto gráfico a partir del mapa de bits
            {
                Point point = new Point((this.Width - iconSize) - 15, ((this.Height - iconSize) / 2) + 3);//Establecer la ubicación del icono de flecha (acoplado a la derecha y al centro)
                var rectangle = new Rectangle(point, new Size(iconSize, iconSize));//Crear un rectángulo con la ubicación especificada y el tamaño igual al tamaño del icono

                drawIcon.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavizado
                drawIcon.DrawImage(pbDropdownArrowIcon.Image, rectangle);//Dibuja el icono de flecha en la ubicación especificada en el mapa de bits
                this.BackgroundImage = arrowIcon; //Establecer el icono de flecha como fondo del menú del botón
            }
        }
        private void ActivateMenuItem(RJChildForm guestForm, ToolStripMenuItem menuItem)
        { //Activar / resaltar MenuItem

            Color iconColor;//Definir el color de icono
            tempMenuItemTextColor = menuItem.ForeColor;//Guardar el color de texto del elemento del menú.
            menuItem.ForeColor = activateForeColor;//Establecer el color de texto activo.
            dropdownMenu.ActiveMenuItem = true;//Indicar al menú desplegable que tiene un elemento activo.

            //Establecer color de icono de elemento de menú
            if (UIAppearance.Style == UIStyle.Supernova)
                iconColor = RJColors.GetSupernovaColor();
            else iconColor = UIAppearance.StyleColor;

            if (UIAppearance.FormIconActiveMenuItem)//Si la configuración está configurada para mostrar el icono de formulario en el elemento de menú activo
            {
                //Obtener y establecer el icono del formulario en el elemento del menú.
                Bitmap formIcon = guestForm.FormIcon.ToBitmap(iconColor, 25);
                menuItem.Image = formIcon;
            }
            else //Caso contrario establecer una forma simple (Punto circular) como icono del elemento del menú.
            {
                Bitmap iconShape = new Bitmap(14, 14); //Crear un objeto de mapa de bits con un tamaño de 14.

                using (Graphics graphics = Graphics.FromImage(iconShape))//Crear un objeto de grafico a partir del mapa de bits.
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;//Establecer el modo de suavizado.
                    using (Brush brush = new SolidBrush(iconColor))
                    {
                        graphics.FillEllipse(brush, 0, 0, 13, 13);//Dibujar un circulo perfecto.
                    }
                }
                menuItem.Image = iconShape;//Establecer el mapa de bits como icono del elemento del menú activo.
            }
        }
        private void DeactivateMenuItem(ToolStripMenuItem menuItem)
        {
            if (menuItem != null)//Desactivar el elemento de menú.
            {
                menuItem.Image = null;//Remover icono   
                menuItem.ForeColor = tempMenuItemTextColor;//Restaurar el color del texto original
                if (guestFormsCount == 0)//si el botón desplegable ya no tiene formularios asociados, 
                    dropdownMenu.ActiveMenuItem = false;//indicar al menú desplegable que ya no tiene un menú activo.
            }
        }
        #endregion

        #region -> Métodos públicos

        public void Activate(RJChildForm guestForm)
        {//-> Botón de menú normal
            ///<summary>
            ///Este método permite activar / resaltar el botón de menú desde el exterior, al mismo tiempo asociar 
            ///un formulario de invitado (el botón permanecerá activado cuando el formulario esté abierto o instanciado
            ///y una vez cerrado el formulario el botón se desactivará) Utilice este método cuando abre un formulario
            ///directamente desde el botón de menú (el botón no es un menú desplegable y solo tendrá un formulario asociado).
            /// </summary>
            ///
            ActivateButton();//Activar / resaltar el botón de menú
            guestForm.FormClosed += new FormClosedEventHandler(GuestForm_Closed);//Suscribir el evento cerrado del formulario , para desactivar el botón de menú.
            guestFormsCount = 1;//establecer formulario asociado a uno, esto es opcional ya que por defecto es 0, por lo tanto una vez cerrado el formulario se desactivará el botón.
        }
        public void Activate(RJChildForm guestForm, ToolStripMenuItem menuItem)
        {//-> Botón de menú desplegable
            ///<summary>
            ///Este método permite activar / resaltar el botón de menú y el elemento de menú remitente desde el exterior,
            ///al mismo tiempo asociar un formulario de invitado (el botón de menú permanecerá activado cuando el formulario 
            ///esté abierto o instanciado y una vez que el botón de menú no tenga formularios asociados, el botón se desactivará). 
            ///Utilice este método cuando el botón sea un menú desplegable y abra un formulario desde un elemento del menú desplegable
            ///(el botón de menú es un menú desplegable y puede tener muchos formularios asociados).
            /// </summary>
            ///
            ActivateButton();//Activar / resaltar el botón de menú      
            ActivateMenuItem(guestForm, menuItem);//Activar / resaltar el elemento del menú desplegable
            if (this.Width > 100)//si el ancho es mayor que 100, es decir, el menú lateral está expandido,
                DrawDropdownArrowIcon(false);// Dibujar el icono de flecha contraído, es decir, no se muestra el menú desplegable.

            guestForm.FormClosed += new FormClosedEventHandler((sender, e) => GuestForm_Closed(sender, e, menuItem));
            //Suscríbir al evento cerrado del formulario para desactivar el elemento del menú (pasar un parámetro adicional al evento usando delegado a través de expresiones lambda)
            //Más información: https://stackoverflow.com/a/34622752/12778930 

            guestFormsCount++;//Incrementar el contador de formularios asociadas en uno.
        }
        #endregion     

        #region -> Métodos de evento

        private void MB_HandleCreated(object sender, EventArgs e)
        {
            if (!this.DesignMode)//Ejecutar esto cuando no esté en modo de diseño.
                tempText = this.Text;// Guardar texto del Botón de menú
        }
        private void GuestForm_Closed(object sender, FormClosedEventArgs e)
        {
            ///ver método predecesor <ver cref = "Activate (RJChildForm guestForm)" />

            guestFormsCount = 0;//Establecer formulario asociado en 0
            DeactivateButton();//Desactivar botón de menú
        }
        private void GuestForm_Closed(object sender, FormClosedEventArgs e, ToolStripMenuItem menuItem)
        {
            ///ver método predecesor<see cref="Activate(RJChildForm guestForm, ToolStripMenuItem menuItem))"/>

            guestFormsCount--; //Cuando el formulario está cerrado, disminuyir el contador de formularios asociados en uno.
            DeactivateButton();//Desactivar botón de menú
            DeactivateMenuItem(menuItem);//Desactivar el elemento del menú desplegable.
        }
        private void DropdownMenuButton_Click(object sender, EventArgs e)
        {
            ShowDropdownMenu();
        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e)
        {
            //Este evento ocurre cuando el menú desplegable se muestra u oculta

            if (!DesignMode)//Ejecutar esto cuando no esté en modo de diseño.
            {
                if (dropdownMenu.Visible)//Si se mostró el menú desplegable
                {
                    ActivateButton();//Activar botón de menú
                    this.BackColor = activateBackColor;//Establecer color de fondo activo
                    if (this.Width > 100)//si el ancho es mayor que 100, es decir, el menú lateral está expandido,
                        DrawDropdownArrowIcon(true);//Dibujar icono de flecha expandido
                }
                else
                {//Si el menú desplegable se ha ocultado (Cerrar)              

                    DeactivateButton();//Desactivar botón de menú (También se encarga de dibujar el icono de flecha cuando el botón no tiene formularios asociados)
                    this.BackColor = RJColors.SideMenuColor;//Restaurar color de fondo
                    if (this.Width > 100 && guestFormsCount != 0)//Esta condición es para dibujar el icono de flecha cuando el botón tiene formularios asociados
                        DrawDropdownArrowIcon(false);// Dibujar el icono de flecha contraída.
                }
            }
        }
        private void WidthChanged(object sender, EventArgs e)
        {
            //este evento sucederá cuando el menú lateral esté contraído o expandido (el botón tiene la propiedad de acoplamiento en la parte superior (Dock=Top), no lo cambie)

            if (!this.DesignMode)//Ejecute esto cuando no esté en modo de diseño
            {
                if (this.Size.Width < 100) //Si el menú lateral está contraído
                {
                    this.Text = "";//Establecer texto vacío
                    if (isDropdownMenu)//Si el botón es del menú desplegable, eliminar el icono de flecha
                        this.BackgroundImage = null;
                }
                else //Si el menú lateral se expande
                {
                    this.Text = tempText;//Restablecer el texto del botón de menú.
                    if (isDropdownMenu)//Si el botón es un menú desplegable, dibujar el icono de flecha contraído.
                        DrawDropdownArrowIcon(false);
                }
            }
        }
        #endregion

    }
}