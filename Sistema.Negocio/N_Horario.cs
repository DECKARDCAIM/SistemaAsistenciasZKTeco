using System;
using System.Data;
using Sistema.Datos;

namespace Sistema.Negocio
{
    public class N_Departamento
    {
        public static DataTable Listar()
        {
            D_Departamento datos = new D_Departamento();
            return datos.Listar();
        }

        public static DataTable Seleccionar()
        {
            D_Departamento datos = new D_Departamento();
            return datos.Seleccionar();
        }
    }

    public class N_Horario
    {
        public static DataTable ListarTurnos()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarTurnos();
        }

        public static DataTable SeleccionarTurnos()
        {
            D_Horario datos = new D_Horario();
            return datos.SeleccionarTurnos();
        }

        public static DataTable ListarIntervalos()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarIntervalos();
        }

        public static DataTable ListarHorariosEmpleados()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarHorariosEmpleados();
        }
    }
}
