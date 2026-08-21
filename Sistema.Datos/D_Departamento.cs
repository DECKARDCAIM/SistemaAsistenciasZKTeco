using System;
using System.Data;
using Npgsql;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Departamento
    {
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "SELECT id, dept_code AS codigo, dept_name AS nombre FROM personnel_department ORDER BY id ASC";
                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            tabla.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar departamentos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Seleccionar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "SELECT id, dept_name AS nombre FROM personnel_department ORDER BY dept_name ASC";
                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            tabla.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar departamentos: " + ex.Message);
            }
            return tabla;
        }
    }
}
