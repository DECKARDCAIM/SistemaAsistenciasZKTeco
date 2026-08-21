using System;

namespace Sistema.Entidades
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? ParentId { get; set; }
        public string ParentNombre { get; set; }
        public int TotalEmpleados { get; set; }
        public bool IsDefault { get; set; }
        public int? CompanyId { get; set; }
    }
}

