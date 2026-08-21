using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJCodeUI_M1.RJControls
{
    public enum LabelStyle
    {//Define estilos de etiqueta que puede aplicar fuente, color y tamaño de fuente.

        Normal,//Estilo normal de texto para parrafos, el tamaño es definido por la configuracion de apariencia.
        Description,//Utilice este estilo para mostrar una descripcion de algo. El tamaño es pequeño, definido en la clase RJLabel.
        Subtitle,//Estilo Subtitulo.
        Title,//Estilo Título, el tamaño de fuente es grande, el color establecido es el color de estilo de la aplicacion.
        Title2,//Estilo Título 2, el tamaño de fuente es grande, el color establecido es el color de texto de la aplicacion.
        BarCaption, //Se utiliza para mostrar el título del formulario actual en la barra de título del formulario principal.
        BarText,//Se usa para mostrar texto en la barra de título del formulario principal (por ejemplo, nombre de usuario)
        Custom //Tamaño y fuente personalizable, sin embargo, el color del texto se establece por estilo.
    }
}
