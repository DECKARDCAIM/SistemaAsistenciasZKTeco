using System;
using System.Data;
using Npgsql;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Departamento
    {
        private static bool _tablaVerificada = false;

        public static void GarantizarTabla()
        {
            if (_tablaVerificada) return;

            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string script = @"
                        CREATE TABLE IF NOT EXISTS personnel_department (
                            id SERIAL PRIMARY KEY,
                            dept_code VARCHAR(50) NOT NULL UNIQUE,
                            dept_name VARCHAR(100) NOT NULL,
                            is_default BOOLEAN NOT NULL DEFAULT FALSE,
                            company_id INTEGER NULL,
                            parent_dept_id INTEGER NULL
                        );

                        -- Insertar departamento General si la tabla está vacía
                        INSERT INTO personnel_department (dept_code, dept_name, is_default)
                        SELECT '01', 'General', TRUE
                        WHERE NOT EXISTS (SELECT 1 FROM personnel_department);
                    ";

                    using (NpgsqlCommand comando = new NpgsqlCommand(script, sqlCon))
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                _tablaVerificada = true;
            }
            catch
            {
                // Silencioso si no hay permisos DDL o si ya existe
            }
        }

        public DataTable Listar()
        {
            GarantizarTabla();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT d.id AS iddepartamento, 
                               d.dept_code AS codigo, 
                               d.dept_name AS nombre, 
                               d.parent_dept_id AS id_padre,
                               COALESCE(p.dept_name, '--- (Ninguno)') AS departamento_padre,
                               d.is_default AS es_predeterminado,
                               COUNT(e.id) AS total_empleados
                        FROM personnel_department d
                        LEFT JOIN personnel_department p ON d.parent_dept_id = p.id
                        LEFT JOIN personnel_employee e ON e.department_id = d.id AND COALESCE(e.deleted, false) = false
                        GROUP BY d.id, d.dept_code, d.dept_name, d.parent_dept_id, p.dept_name, d.is_default
                        ORDER BY d.id ASC";

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

        public DataTable Buscar(string valor)
        {
            GarantizarTabla();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT d.id AS iddepartamento, 
                               d.dept_code AS codigo, 
                               d.dept_name AS nombre, 
                               d.parent_dept_id AS id_padre,
                               COALESCE(p.dept_name, '--- (Ninguno)') AS departamento_padre,
                               d.is_default AS es_predeterminado,
                               COUNT(e.id) AS total_empleados
                        FROM personnel_department d
                        LEFT JOIN personnel_department p ON d.parent_dept_id = p.id
                        LEFT JOIN personnel_employee e ON e.department_id = d.id AND COALESCE(e.deleted, false) = false
                        WHERE (d.dept_code ILIKE @valor OR d.dept_name ILIKE @valor)
                        GROUP BY d.id, d.dept_code, d.dept_name, d.parent_dept_id, p.dept_name, d.is_default
                        ORDER BY d.dept_name ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@valor", "%" + valor + "%");
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
                throw new Exception("Error al buscar departamentos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Seleccionar(int idExcluir = 0)
        {
            GarantizarTabla();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id, 
                               (dept_code || ' - ' || dept_name) AS nombre_completo,
                               dept_name AS nombre 
                        FROM personnel_department 
                        WHERE (@idExcluir = 0 OR id <> @idExcluir)
                        ORDER BY dept_name ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@idExcluir", idExcluir);
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

        public bool Existe(string codigo, string nombre, int idExcluir = 0)
        {
            GarantizarTabla();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT COUNT(1) 
                        FROM personnel_department 
                        WHERE (LOWER(dept_code) = LOWER(@codigo) OR LOWER(dept_name) = LOWER(@nombre))
                          AND (@idExcluir = 0 OR id <> @idExcluir)";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@codigo", codigo.Trim());
                        comando.Parameters.AddWithValue("@nombre", nombre.Trim());
                        comando.Parameters.AddWithValue("@idExcluir", idExcluir);
                        sqlCon.Open();
                        long count = Convert.ToInt64(comando.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public string Insertar(Departamento obj)
        {
            GarantizarTabla();
            string rpta = "";
            try
            {
                if (Existe(obj.Codigo, obj.Nombre, 0))
                {
                    return "Ya existe un departamento con el mismo código o nombre.";
                }

                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        INSERT INTO personnel_department (dept_code, dept_name, is_default, company_id, parent_dept_id)
                        VALUES (@codigo, @nombre, @is_default, @company_id, @parent_dept_id)
                        RETURNING id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@codigo", obj.Codigo.Trim());
                        comando.Parameters.AddWithValue("@nombre", obj.Nombre.Trim());
                        comando.Parameters.AddWithValue("@is_default", obj.IsDefault);
                        comando.Parameters.AddWithValue("@company_id", (object)obj.CompanyId ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@parent_dept_id", (object)obj.ParentId ?? DBNull.Value);

                        sqlCon.Open();
                        int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                        obj.IdDepartamento = nuevoId;
                        rpta = "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string Actualizar(Departamento obj)
        {
            GarantizarTabla();
            string rpta = "";
            try
            {
                if (Existe(obj.Codigo, obj.Nombre, obj.IdDepartamento))
                {
                    return "Ya existe otro departamento con el mismo código o nombre.";
                }

                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        UPDATE personnel_department 
                        SET dept_code = @codigo, 
                            dept_name = @nombre, 
                            parent_dept_id = @parent_dept_id
                        WHERE id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", obj.IdDepartamento);
                        comando.Parameters.AddWithValue("@codigo", obj.Codigo.Trim());
                        comando.Parameters.AddWithValue("@nombre", obj.Nombre.Trim());
                        comando.Parameters.AddWithValue("@parent_dept_id", (object)obj.ParentId ?? DBNull.Value);

                        sqlCon.Open();
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró el registro para actualizar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string Eliminar(int id)
        {
            GarantizarTabla();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    // Verificar si tiene subdepartamentos
                    using (NpgsqlCommand checkSub = new NpgsqlCommand("SELECT COUNT(1) FROM personnel_department WHERE parent_dept_id = @id", sqlCon))
                    {
                        checkSub.Parameters.AddWithValue("@id", id);
                        long subCount = Convert.ToInt64(checkSub.ExecuteScalar());
                        if (subCount > 0)
                        {
                            return "No se puede eliminar el departamento porque tiene sub-departamentos subordinados asignados.";
                        }
                    }

                    // Reasignar empleados a NULL o departamento 1 antes de eliminar para no violar FK
                    using (NpgsqlCommand reassignEmp = new NpgsqlCommand("UPDATE personnel_employee SET department_id = NULL WHERE department_id = @id", sqlCon))
                    {
                        reassignEmp.Parameters.AddWithValue("@id", id);
                        reassignEmp.ExecuteNonQuery();
                    }

                    // Eliminar asignaciones de departamento en att_departmentschedule si existen
                    using (NpgsqlCommand delSched = new NpgsqlCommand("DELETE FROM att_departmentschedule WHERE department_id = @id", sqlCon))
                    {
                        delSched.Parameters.AddWithValue("@id", id);
                        delSched.ExecuteNonQuery();
                    }

                    // Eliminar departamento
                    using (NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM personnel_department WHERE id = @id", sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró el departamento a eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}

