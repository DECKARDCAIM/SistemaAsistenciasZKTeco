using System;

namespace Sistema.Entidades
{
    public class Biometrico
    {
        public int IdBiometrico { get; set; }
        public string Nombre { get; set; }
        public string DireccionIP { get; set; }
        public int Puerto { get; set; } = 4370;
        public int CommKey { get; set; } = 0; // Clave de comunicación
        public string Ubicacion { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public string EstadoConexion { get; set; } = "Desconectado";
        public DateTime? UltimaSincronizacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
