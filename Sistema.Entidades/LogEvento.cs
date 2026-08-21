using System;

namespace Sistema.Entidades
{
    public class LogEvento
    {
        public int IdLog { get; set; }
        public DateTime FechaHora { get; set; }
        public string Tipo { get; set; } // INFO, ERROR, WARNING, SYNC
        public string Modulo { get; set; }
        public string Mensaje { get; set; }
    }

    public class RespuestaOperacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public static RespuestaOperacion Ok(string mensaje = "Operación realizada con éxito", object datos = null)
        {
            return new RespuestaOperacion { Exito = true, Mensaje = mensaje, Datos = datos };
        }

        public static RespuestaOperacion Error(string mensaje, object datos = null)
        {
            return new RespuestaOperacion { Exito = false, Mensaje = mensaje, Datos = datos };
        }
    }
}
