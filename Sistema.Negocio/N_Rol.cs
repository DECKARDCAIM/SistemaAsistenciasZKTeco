using System.Data;
using Sistema.Datos;

namespace Sistema.Negocio
{
    public class N_Rol
    {
        public static DataTable Listar()
        {
            D_Rol datos = new D_Rol();
            return datos.Listar();
        }

        public static DataTable Seleccionar()
        {
            D_Rol datos = new D_Rol();
            return datos.Seleccionar();
        }
    }
}
