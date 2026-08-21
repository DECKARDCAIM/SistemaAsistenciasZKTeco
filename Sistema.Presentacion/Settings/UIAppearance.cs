using System;
using System.Drawing;

namespace RJCodeUI_M1.Settings
{
    public struct UIAppearance
    {
        //Configuración de apariencia de la interfaz de usuario (configuración predeterminada)
        internal static UITheme Theme = UITheme.Light;//Establece u obtiene el tema, ya sea oscuro o claro.
        internal static UIStyle Style = UIStyle.Neptune;//Establece o consigue el estilo
        internal static Color PrimaryStyleColor = RJColors.Neptune; //Establece u obtiene el color de estilo de la barra de título del formulario
        internal static Color StyleColor = RJColors.Neptune; //Establece u obtiene el color de estilo de los botones, cuadros combinados, selectores de fecha y hora, vistas de cuadrículas de datos, casillas de verificación, botones de radio y otros (el color es un poco más opaco que el campo PrimaryStyleColor - Ver Clase SettingsManager)
        internal static Color BackgroundColor = RJColors.LightBackground;//Establece u obtiene el color de fondo de los formularios
        internal static Color ItemBackgroundColor = RJColors.LightItemBackground;
        internal static Color ActiveBackgroundColor = RJColors.LightActiveBackground;
        internal static Color PrimaryTextColor = RJColors.LightTextColor;//Establece u obtiene el color del texto de los cuadros de texto, cuadro combinado, selector de fecha y hora (el color está un poco más resaltado que el campo Color del texto; consulte la clase SettingsManager)
        internal static Color TextColor = RJColors.LightTextColor;//Establece u obtiene el color del texto de la etiqueta, el botón de opción y otros, también se aplica al texto y al control BarIcon en la barra de título del formulario principal en el estilo supernova.
        internal static Color FormBorderColor = RJColors.Neptune;//Establece u obtiene el color del borde del formulario    
        internal static Color DeactiveFormColor = Color.FromArgb(76, 70, 116);//Establece u obtiene el color de la barra de título cuando el formulario está desactivado.

        internal static int FormBorderSize = 1;//Establece el ancho del borde del formulario      
        internal static bool ChildFormMarker = true;//Establece o obtiene si el marcador de formulario secundario se mostrará en el botón de menú del menú lateral del formulario principal
        internal static bool FormIconActiveMenuItem = false; //Establece u obtiene si el icono de formulario se mostrará en un elemento de menú activo
        internal static bool MultiChildForms = true;//Establece o obtiene si el usuario puede abrir varios formularios secundarios dentro del panel escritorio o simplemente puede abrir un formulario único (cerrar el anterior y abrir el nuevo formulario)
        internal static string TextFamilyName = "Verdana";
        internal static float TextSize = 9.5F;//Establece un tamaño de fuente predeterminado, se aplica a la mayoría de los controles personalizados en el momento del diseño,       
        // sin embargo, se puede cambiar más tarde desde las propiedades del control
        // a menos que haya una restricción sobre un control específico.      
    }
}
