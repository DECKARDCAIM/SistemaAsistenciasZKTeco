using System;

namespace Sistema.Entidades
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? ParentId { get; set; }
    }
}
