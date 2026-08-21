using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Horario
    {
        public DataTable ListarTurnos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT s.id AS idturno, 
                               s.alias AS nombre_turno, 
                               s.cycle_unit, 
                               s.shift_cycle, 
                               s.work_weekend,
                               COUNT(DISTINCT sch.employee_id) AS total_empleados_asignados
                        FROM att_attshift s
                        LEFT JOIN att_attschedule sch ON s.id = sch.shift_id
                        GROUP BY s.id, s.alias, s.cycle_unit, s.shift_cycle, s.work_weekend
                        ORDER BY s.id ASC";

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
                throw new Exception("Error al listar turnos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable SeleccionarTurnos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "SELECT id AS idturno, alias AS nombre FROM att_attshift ORDER BY alias ASC";
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
                throw new Exception("Error al seleccionar turnos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable ListarIntervalos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idintervalo, 
                               alias AS nombre, 
                               in_time AS hora_entrada, 
                               in_ahead_margin AS margen_antes_entrada, 
                               in_above_margin AS margen_despues_entrada, 
                               work_time_duration AS duracion_minutos
                        FROM att_timeinterval
                        ORDER BY id ASC";

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
                throw new Exception("Error al listar intervalos de horario: " + ex.Message);
            }
            return tabla;
        }

        public DataTable ListarHorariosEmpleados()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT s.id, 
                               e.emp_code::text AS codigo_empleado, 
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_empleado,
                               COALESCE(d.dept_name, 'General') AS departamento,
                               sh.alias AS turno,
                               s.start_date AS fecha_inicio, 
                               s.end_date AS fecha_fin
                        FROM att_attschedule s
                        INNER JOIN personnel_employee e ON s.employee_id = e.id
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        INNER JOIN att_attshift sh ON s.shift_id = sh.id
                        ORDER BY e.emp_code ASC";

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
                throw new Exception("Error al listar horarios de empleados: " + ex.Message);
            }
            return tabla;
        }
    }
}
