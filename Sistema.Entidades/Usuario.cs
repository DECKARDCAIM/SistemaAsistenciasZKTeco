using System;

namespace Sistema.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public bool EsSuperUsuario { get; set; }
        public bool EsStaff { get; set; }
        public DateTime? UltimoLogin { get; set; }
    }
}
