using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJCodeUI_M1.RJControls
{
  public enum ButtonDesign
    {
        Normal,//El botón tiene un diseño común y plano, por defecto el color de apariencia es el mismo color que el color de estilo de aplicación establecido por la configuración de apariencia.
        IconButton,//El botón tiene un icono y un diseño plano, por defecto el color de apariencia es el mismo color que el color de estilo de aplicación establecido por la configuración de apariencia.
        Metro,//El botón tiene un diseño similar a los botones del menú de inicio de Windows 8, por defecto el color de apariencia es el mismo color que el color del estilo de la aplicación establecido por la configuración de apariencia.
        Confirm,//El botón tiene un diseño plano y de icono, el color de apariencia es verde, establecido en la lista de colores RJColors.
        Cancel,//El botón tiene un diseño plano y de icono, el color de apariencia es gris oscuro, establecido en la lista de colores RJColors.
        Delete,//El botón tiene un diseño plano y de icono, el color de apariencia es rojo, establecido en la lista de colores RJColors.
        Custom//El botón tiene un icono y diseño plano o normal, según su diseño anterior.
        //En este modo no se aplica la configuración de apariencia de la aplicación, puedes personalizar tanto el diseño como los colores del botón.
    }
}
