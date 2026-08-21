using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJCodeUI_M1.RJControls
{
    public enum ControlStyle
    {
        Glass, //El color de fondo del control es transparente y con un borde de color, en este estilo puede cambiar el tamaño del borde.
        Solid, //El color de fondo del control es un color sólido sin borde, este estilo le permite aplicar esquinas redondeadas al control,
        //para ello utiliza la clase RoundedCorner de las utilidades.
    }
}
