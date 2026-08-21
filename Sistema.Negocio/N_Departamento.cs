using System;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Departamento
    {
        public static DataTable Listar()
        {
            D_Departamento datos = new D_Departamento();
            return datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            D_Departamento datos = new D_Departamento();
            return datos.Buscar(valor);
        }

        public static DataTable Seleccionar(int idExcluir = 0)
        {
            D_Departamento datos = new D_Departamento();
            return datos.Seleccionar(idExcluir);
        }

        public static string Insertar(string codigo, string nombre, int? parentId = null, bool isDefault = false, int? companyId = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "El código del departamento es obligatorio.";

            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            D_Departamento datos = new D_Departamento();
            Departamento obj = new Departamento
            {
                Codigo = codigo.Trim(),
                Nombre = nombre.Trim(),
                ParentId = parentId,
                IsDefault = isDefault,
                CompanyId = companyId
            };
            return datos.Insertar(obj);
        }

        public static string Actualizar(int id, string codigo, string nombre, int? parentId = null)
        {
            if (id <= 0)
                return "Identificador de departamento inválido.";

            if (string.IsNullOrWhiteSpace(codigo))
                return "El código del departamento es obligatorio.";

            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            if (parentId.HasValue && parentId.Value == id)
                return "Un departamento no puede ser su propio departamento superior/padre.";

            D_Departamento datos = new D_Departamento();
            Departamento obj = new Departamento
            {
                IdDepartamento = id,
                Codigo = codigo.Trim(),
                Nombre = nombre.Trim(),
                ParentId = parentId
            };
            return datos.Actualizar(obj);
        }

        public static string Eliminar(int id)
        {
            if (id <= 0)
                return "Identificador de departamento inválido.";

            D_Departamento datos = new D_Departamento();
            return datos.Eliminar(id);
        }
    }
}
