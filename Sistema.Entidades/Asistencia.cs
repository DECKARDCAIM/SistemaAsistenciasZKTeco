using System;

namespace Sistema.Entidades
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int? IdEmpleado { get; set; }
        public string CodigoBiometrico { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaHora { get; set; }
        public int TipoMarcacion { get; set; } // 0: Entrada, 1: Salida, 2: Salida a Colación, 3: Entrada de Colación, etc.
        public string DescripcionTipoMarcacion
        {
            get
            {
                switch (TipoMarcacion)
                {
                    case 0: return "Entrada";
                    case 1: return "Salida";
                    case 2: return "Salida a Refrigerio";
                    case 3: return "Regreso de Refrigerio";
                    case 4: return "HE Entrada";
                    case 5: return "HE Salida";
                    default: return $"Otro ({TipoMarcacion})";
                }
            }
        }
        public int MetodoVerificacion { get; set; } // 1: Huella, 2: Clave, 3: Tarjeta RFID, 4: Rostro, 15: Palma, etc.
        public string DescripcionMetodoVerificacion
        {
            get
            {
                switch (MetodoVerificacion)
                {
                    case 1: return "Huella Dactilar";
                    case 2: return "Contraseña";
                    case 3: return "Tarjeta RFID";
                    case 4: return "Rostro";
                    case 15: return "Palma";
                    default: return $"Otro ({MetodoVerificacion})";
                }
            }
        }
        public int? IdBiometrico { get; set; }
        public string NombreBiometrico { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
