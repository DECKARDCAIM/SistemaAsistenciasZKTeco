using System;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Usuario
    {
        public static Usuario Login(string usuarioOCorreo, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuarioOCorreo)) throw new ArgumentException("Debe ingresar el usuario o correo electrónico.");
            if (string.IsNullOrWhiteSpace(clave)) throw new ArgumentException("Debe ingresar la contraseña.");

            D_Usuario datos = new D_Usuario();
            Usuario usuario = datos.ObtenerPorUsernameOEmail(usuarioOCorreo.Trim());

            if (usuario == null)
            {
                return null;
            }

            if (!usuario.Estado)
            {
                throw new Exception("El usuario se encuentra inactivo en el sistema.");
            }

            if (!PasswordHasher.VerifyPassword(clave.Trim(), usuario.Clave))
            {
                return null;
            }

            datos.RegistrarLogin(usuario.IdUsuario);

            return usuario;
        }

        public static DataTable Listar()
        {
            D_Usuario datos = new D_Usuario();
            return datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            D_Usuario datos = new D_Usuario();
            return datos.Buscar(valor);
        }

        public static string Insertar(int idRol, string username, string nombre, string apellido, string email, string clave, bool estado = true)
        {
            if (idRol <= 0) return "Debe seleccionar un rol válido.";
            if (string.IsNullOrWhiteSpace(username)) return "El nombre de usuario es obligatorio.";
            if (string.IsNullOrWhiteSpace(email)) return "El correo electrónico es obligatorio.";
            if (string.IsNullOrWhiteSpace(clave)) return "La clave es obligatoria.";

            string claveHashed = PasswordHasher.HashPassword(clave.Trim());

            D_Usuario datos = new D_Usuario();
            Usuario obj = new Usuario
            {
                IdRol = idRol,
                Username = username.Trim(),
                Nombre = nombre?.Trim(),
                Apellido = apellido?.Trim(),
                Email = email.Trim(),
                Clave = claveHashed,
                Estado = estado,
                EsSuperUsuario = idRol == 1,
                EsStaff = idRol <= 2
            };
            return datos.Insertar(obj);
        }

        public static string Insertar(int idRol, string nombre, string tipoDoc, string numDoc, string direccion, string telefono, string email, string clave)
        {
            string username = email.Contains("@") ? email.Split('@')[0] : nombre.ToLower().Replace(" ", "");
            return Insertar(idRol, username, nombre, "", email, clave, true);
        }

        public static string Actualizar(int idUsuario, int idRol, string username, string nombre, string apellido, string email, string clave, bool estado = true)
        {
            if (idUsuario <= 0) return "ID de usuario inválido.";
            if (idRol <= 0) return "Debe seleccionar un rol válido.";
            if (string.IsNullOrWhiteSpace(email)) return "El correo electrónico es obligatorio.";

            string claveHashed = null;
            if (!string.IsNullOrWhiteSpace(clave))
            {
                claveHashed = PasswordHasher.HashPassword(clave.Trim());
            }

            D_Usuario datos = new D_Usuario();
            Usuario obj = new Usuario
            {
                IdUsuario = idUsuario,
                IdRol = idRol,
                Username = username?.Trim(),
                Nombre = nombre?.Trim(),
                Apellido = apellido?.Trim(),
                Email = email.Trim(),
                Clave = claveHashed,
                Estado = estado,
                EsSuperUsuario = idRol == 1,
                EsStaff = idRol <= 2
            };
            return datos.Actualizar(obj);
        }

        public static string Actualizar(int idUsuario, int idRol, string nombre, string tipoDoc, string numDoc, string direccion, string telefono, string email, string clave)
        {
            string username = email.Contains("@") ? email.Split('@')[0] : nombre.ToLower().Replace(" ", "");
            return Actualizar(idUsuario, idRol, username, nombre, "", email, clave, true);
        }

        public static string Eliminar(int id)
        {
            D_Usuario datos = new D_Usuario();
            return datos.Eliminar(id);
        }

        public static string Activar(int id)
        {
            D_Usuario datos = new D_Usuario();
            return datos.Activar(id);
        }

        public static string Desactivar(int id)
        {
            D_Usuario datos = new D_Usuario();
            return datos.Desactivar(id);
        }
    }
}
