using System;

namespace Sistema.Entidades
{
    public class EventoMarcacion
    {
        public string CodigoBiometrico { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaHora { get; set; }
        public int TipoMarcacion { get; set; }
        public int MetodoVerificacion { get; set; }
        public int? IdBiometrico { get; set; }
        public string NombreBiometrico { get; set; }
        public string TipoTexto { get; set; }
        public string MetodoTexto { get; set; }
        public DateTime FechaRecibido { get; set; }

        public EventoMarcacion()
        {
            FechaRecibido = DateTime.Now;
        }

        public string ObtenerDescripcionTipo()
        {
            switch (TipoMarcacion)
            {
                case 0: return "Entrada";
                case 1: return "Salida";
                case 2: return "Salida a Almuerzo";
                case 3: return "Regreso de Almuerzo";
                case 4: return "Entrada Extra";
                case 5: return "Salida Extra";
                default: return "Marcación (" + TipoMarcacion + ")";
            }
        }

        public string ObtenerDescripcionMetodo()
        {
            switch (MetodoVerificacion)
            {
                case 1: return "Huella Dactilar";
                case 2: return "Contraseña";
                case 3: return "Tarjeta RFID";
                case 4: return "Reconocimiento Facial";
                case 15: return "Rostro";
                default: return "Biométrico (" + MetodoVerificacion + ")";
            }
        }
    }
}
