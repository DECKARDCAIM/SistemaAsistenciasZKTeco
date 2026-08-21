using System;
using System.Data;

namespace Sistema.Datos
{
    public class D_Rol
    {
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idrol", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("descripcion", typeof(string));
            tabla.Columns.Add("estado", typeof(bool));

            tabla.Rows.Add(1, "Administrador", "Acceso total al sistema y configuración", true);
            tabla.Rows.Add(2, "Supervisor", "Gestión de empleados, biométricos y asistencias", true);
            tabla.Rows.Add(3, "Operador", "Consulta y reportes de asistencias", true);

            return tabla;
        }

        public DataTable Seleccionar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idrol", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));

            tabla.Rows.Add(1, "Administrador");
            tabla.Rows.Add(2, "Supervisor");
            tabla.Rows.Add(3, "Operador");

            return tabla;
        }
    }
}
