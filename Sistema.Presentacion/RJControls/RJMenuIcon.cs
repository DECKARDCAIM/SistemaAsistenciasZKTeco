using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;


namespace RJCodeUI_M1.RJControls
{
    public class RJMenuIcon : IconPictureBox
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "IconPictureBox" /> de la biblioteca <see cref = "FontAwesome.Sharp" />
        ///      Autor: mkoertgen
        ///      GitHub: https://github.com/awesome-inc/FontAwesome.Sharp
        ///      Nuget Package: https://www.nuget.org/packages/FontAwesome.Sharp
        /// Este es un control especial que está diseñado principalmente para ser utilizado en la barra de título del formulario principal,
        /// sin embargo, puede deshabilitar eso estableciendo la propiedad BackIcon en verdadero (el color del icono es igual al color del texto)
        /// Este control puede funcionar como un botón normal o como un botón de menú desplegable, para esto necesita agregar
        /// un menú desplegable (<ver cref = "RJDropdownMenu" />) desde las propiedades de este control (<ver cref = "DropdownMenu" />)
        /// y el evento clic se creará automáticamente para mostrar el menú desplegable.
        /// Puede cambiar el color de apariencia, pero debe establecer la propiedad Customizable en TRUE.
        /// </summary>

        #region -> Campos
        //Campos
        private Color supernovaColor;//Establece un color para el estilo supernova
        private Color tempColor;//Establece un color temporal para el icono      
        private int tempSize;//Establece un tamaño temporal para el icono      
        private bool dropdownMenuIsDisplayed;//Establece si el control muestra un menú desplegable
        private bool customizable;//Establece si el control se puede personalizar independientemente del estilo establecido
        private bool backIcon;//Obtiene o establece si el control es un icono que se puede usar en el área de cliente de cualquier formulario.

        //Campos de tipo control
        private RJDropdownMenu dropdownMenu;//Establece u obtiene el menú desplegable.
        #endregion

        #region -> Constructor

        public RJMenuIcon()
        {
            this.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.IconColor = Color.Crimson;
            this.IconSize = 25;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Cursor = Cursors.Hand;
            this.HandleCreated += new EventHandler(BarIcon_Load);//Aplicar la configuración cuando se activa el evento HandleCreated.
            this.MouseEnter += new EventHandler(BarIcon_MouseEnter);//Ocurre cuando el mouse pasa sobre el control.
            this.MouseLeave += new EventHandler(BarIcon_MouseLeave);//Ocurre cuando el mouse deja el control.
        }
        #endregion

        #region -> Propiedades

        [Browsable(false)]//Ocultar propiedad ContextMenuStrip
        [ReadOnly(true)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get { return base.ContextMenuStrip; }
            set { }
        }
        [Category("RJ Code Advance")]///crear una nueva propiedad para asociar un <see cref="RJDropdownMenu"/>
        [Description("Gets or sets the RJDropdownMenu associated with this control")]
        public RJDropdownMenu DropdownMenu
        {
            get
            {
                return dropdownMenu;//Devolver RJDropdownMenu
            }
            set
            {
                dropdownMenu = value;//Establecer valor
                if (dropdownMenu != null)
                {
                    dropdownMenu.VisibleChanged += new EventHandler(DropdownMenu_VisibleChanged);//Subscribir el evento RJDropdownMenu.VisibleChanged.
                    this.Click += new EventHandler(Show_DropdownMenu);//Subscribir el evento click para mostrar el menú desplegable.               
                }
            }
        }
        [Category("RJ Code Advance")]
        public bool BackIcon
        {//Establece u obtiene si el control es un icono de menú en la barra de título del formulario principal (Falso),
            //o es un icono de menú en cualquier área de cliente del formulario (Verdadero).
            get { return backIcon; }
            set
            {
                backIcon = value;
                if (this.DesignMode)
                    ApplyAppearanceSettings();
            }
        }

        [Category("RJ Code Advance")]
        public bool Customizable
        {//Establece si el control se puede personalizar independientemente del estilo establecido
            get { return customizable; }
            set { customizable = value; }
        }
        #endregion

        #region -> Métodos privados

        private void ShowDropdownMenu()
        {
            try //Mostrar el menú desplegable
            {
                dropdownMenu.Show(this, DropdownMenuPosition.BottomRight);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Se ha producido un error\n" + ex.ToString());
            }
        }
        private void ApplyAppearanceSettings()
        {

            if (customizable == false)//Aplicar la configuración siempre que no sea personalizable
            {

                if (backIcon == true)//Icono de menú en cualquier fondo de un formulario.
                {
                    this.IconColor = UIAppearance.TextColor;
                }
                else //Icono de menú en la barra de título del formulario principal
                {
                    if (UIAppearance.Theme == UITheme.Dark && UIAppearance.Style == UIStyle.Supernova)//si el tema es oscuro y el estilo es supernova, el color del icono será el mismo color que el texto de párrafo normal
                        this.IconColor = ColorEditor.Lighten(UIAppearance.TextColor, 65);
                    else if (UIAppearance.Theme == UITheme.Light && UIAppearance.Style == UIStyle.Supernova)//si el tema es claro y el estilo es supernova, el color del icono será el mismo color que el texto de párrafo normal
                        this.IconColor = ColorEditor.Darken(UIAppearance.TextColor, 25);
                    else//si el estilo es otro, el color del icono será blanco
                        this.IconColor = Color.WhiteSmoke;
                }
            }
        }
        #endregion

        #region -> Métodos de evento

        private void BarIcon_Load(object sender, EventArgs e)
        {//Aplicar la configuración cuando se activa el evento HandleCreated

            ApplyAppearanceSettings();
            if (UIAppearance.Style == UIStyle.Supernova)//si el estilo es supernova obtener un color
                supernovaColor = RJColors.GetSupernovaColor();
        }
        private void BarIcon_MouseEnter(object sender, EventArgs e)
        {//Cuando el mouse pasa sobre el control, agrandar el tamaño del ícono y si el estilo es supernova, cambiar el color del ícono.

            tempSize = this.IconSize;//Guardar tamaño original
            this.IconSize = this.IconSize + 2;//Establecer nuevo tamaño de icono
            if (UIAppearance.Style == UIStyle.Supernova)
            {
                tempColor = this.IconColor;//Guardar el color original
                this.IconColor = supernovaColor;//Establecer color de supernova
            }
        }
        private void BarIcon_MouseLeave(object sender, EventArgs e)
        {//Cuando el mouse deja el control

            if (!dropdownMenuIsDisplayed)//Restablecer los valores originales siempre que el menú desplegable no esté abierto
            {
                this.IconSize = tempSize;
                if (UIAppearance.Style == UIStyle.Supernova)
                    this.IconColor = tempColor;
                ///<Note>esto es para mantener el icono de la barra activado (resaltado) cuando se muestra el menú desplegable</Note>
            }
        }
        private void Show_DropdownMenu(object sender, EventArgs e)
        {
            ShowDropdownMenu();
        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)//Ejecute esto cuando no esté en modo de diseño
            {
                if (dropdownMenu.Visible)//Si se mostró el menú desplegable
                    dropdownMenuIsDisplayed = true;//Establecer verdadero

                else//Si el menú desplegable se ha ocultado (Cerrado)
                {
                    dropdownMenuIsDisplayed = false;//Establecer falso
                    //Restablecer valores originales                  
                    this.IconSize = tempSize;
                    if (UIAppearance.Style == UIStyle.Supernova)
                        this.IconColor = tempColor;
                }
            }
        }
        #endregion
    }
}
