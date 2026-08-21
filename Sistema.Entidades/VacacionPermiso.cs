using System;

namespace Sistema.Entidades
{
    public class CategoriaPermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double UnidadMinima { get; set; }
        public short Unidad { get; set; }
        public string SimboloReporte { get; set; }
        public short TipoCategoria { get; set; }
    }

    public class VacacionPermiso
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdCategoria { get; set; }
        public string CategoriaPermiso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string MotivoSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string MotivoAuditoria { get; set; }
        public DateTime? FechaAuditoria { get; set; }
        public string Aprobador { get; set; }
        public short EstadoAuditoria { get; set; } // 1 = Aprobado, 0 = Pendiente, 2 = Rechazado
        public short NumeroVacacion { get; set; }
        public string Adjunto { get; set; }
    }
}
