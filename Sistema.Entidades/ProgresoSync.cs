using System;

namespace Sistema.Entidades
{
    public class ProgresoSync
    {
        public int Porcentaje { get; set; }
        public string Fase { get; set; }
        public string Estado { get; set; }
        public int RegistrosActuales { get; set; }
        public int RegistrosTotales { get; set; }
        public int RegistrosNuevos { get; set; }
        public int RegistrosDuplicados { get; set; }
        public string NombreBiometrico { get; set; }
        public bool EsCompletado { get; set; }
        public bool EsError { get; set; }
        public string MensajeError { get; set; }

        public ProgresoSync()
        {
            Porcentaje = 0;
            Fase = "Iniciando";
            Estado = "Preparando conexión...";
        }
    }
}
