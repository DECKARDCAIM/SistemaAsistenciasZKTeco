using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Empleado
    {
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT e.id AS idempleado, 
                               e.emp_code::text AS codigo_biometrico, 
                               e.first_name AS nombre, 
                               COALESCE(e.last_name, '') AS apellido, 
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_completo,
                               COALESCE(e.national_num, '') AS num_documento, 
                               COALESCE(e.email, '') AS email, 
                               COALESCE(NULLIF(e.mobile, ''), COALESCE(e.contact_tel, '')) AS telefono, 
                               e.department_id,
                               COALESCE(d.dept_name, 'General') AS departamento, 
                               e.position_id,
                               COALESCE(p.position_name, 'General') AS cargo, 
                               COALESCE(e.card_no, '') AS tarjeta_rfid, 
                               COALESCE(e.device_password, '') AS password_biometrico, 
                               COALESCE(e.dev_privilege, 0) AS privilegio, 
                               (COALESCE(e.enable_att, true) AND COALESCE(e.is_active, true)) AS habilitado, 
                               COALESCE(e.hire_date::timestamp, e.create_time, NOW()) AS fecha_registro,
                               s.shift_id AS turnoid,
                               COALESCE(sh.alias, 'Sin Turno') AS turno
                        FROM personnel_employee e 
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN personnel_position p ON e.position_id = p.id
                        LEFT JOIN LATERAL (
                            SELECT shift_id 
                            FROM att_attschedule 
                            WHERE employee_id = e.id 
                            ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        WHERE COALESCE(e.deleted, false) = false
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
                throw new Exception("Error al listar empleados: " + ex.Message);
            }
            return tabla;
        }

        public DataTable SeleccionarActivos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idempleado, 
                               (COALESCE(first_name, '') || ' ' || COALESCE(last_name, '')) AS nombre_completo
                        FROM personnel_employee
                        WHERE COALESCE(deleted, false) = false 
                          AND COALESCE(is_active, true) = true 
                          AND COALESCE(enable_att, true) = true
                        ORDER BY first_name ASC";

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
                throw new Exception("Error al seleccionar empleados activos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Buscar(string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT e.id AS idempleado, 
                               e.emp_code::text AS codigo_biometrico, 
                               e.first_name AS nombre, 
                               COALESCE(e.last_name, '') AS apellido, 
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_completo,
                               COALESCE(e.national_num, '') AS num_documento, 
                               COALESCE(e.email, '') AS email, 
                               COALESCE(NULLIF(e.mobile, ''), COALESCE(e.contact_tel, '')) AS telefono, 
                               e.department_id,
                               COALESCE(d.dept_name, 'General') AS departamento, 
                               e.position_id,
                               COALESCE(p.position_name, 'General') AS cargo, 
                               COALESCE(e.card_no, '') AS tarjeta_rfid, 
                               COALESCE(e.device_password, '') AS password_biometrico, 
                               COALESCE(e.dev_privilege, 0) AS privilegio, 
                               (COALESCE(e.enable_att, true) AND COALESCE(e.is_active, true)) AS habilitado, 
                               COALESCE(e.hire_date::timestamp, e.create_time, NOW()) AS fecha_registro,
                               s.shift_id AS turnoid,
                               COALESCE(sh.alias, 'Sin Turno') AS turno
                        FROM personnel_employee e 
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN personnel_position p ON e.position_id = p.id
                        LEFT JOIN LATERAL (
                            SELECT shift_id 
                            FROM att_attschedule 
                            WHERE employee_id = e.id 
                            ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        WHERE COALESCE(e.deleted, false) = false
                          AND (e.first_name ILIKE '%' || @valor || '%' 
                               OR e.last_name ILIKE '%' || @valor || '%' 
                               OR e.emp_code::text ILIKE '%' || @valor || '%' 
                               OR e.national_num ILIKE '%' || @valor || '%'
                               OR d.dept_name ILIKE '%' || @valor || '%')
                        ORDER BY e.emp_code ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@valor", NpgsqlDbType.Varchar, 100).Value = valor.Trim();
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
                throw new Exception("Error al buscar empleados: " + ex.Message);
            }
            return tabla;
        }

        public Empleado ObtenerPorId(int id)
        {
            Empleado emp = null;
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT e.id AS idempleado, 
                               e.emp_code::text AS codigo_biometrico, 
                               e.first_name AS nombre, 
                               COALESCE(e.last_name, '') AS apellido, 
                               COALESCE(e.national_num, '') AS num_documento, 
                               COALESCE(e.email, '') AS email, 
                               COALESCE(NULLIF(e.mobile, ''), COALESCE(e.contact_tel, '')) AS telefono, 
                               e.department_id,
                               COALESCE(d.dept_name, 'General') AS departamento, 
                               e.position_id,
                               COALESCE(p.position_name, 'General') AS cargo, 
                               COALESCE(e.card_no, '') AS tarjeta_rfid, 
                               COALESCE(e.device_password, '') AS password_biometrico, 
                               COALESCE(e.dev_privilege, 0) AS privilegio, 
                               (COALESCE(e.enable_att, true) AND COALESCE(e.is_active, true)) AS habilitado, 
                               COALESCE(e.hire_date::timestamp, e.create_time, NOW()) AS fecha_registro,
                               s.shift_id AS turnoid,
                               COALESCE(sh.alias, 'Sin Turno') AS turno
                        FROM personnel_employee e 
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN personnel_position p ON e.position_id = p.id
                        LEFT JOIN LATERAL (
                            SELECT shift_id 
                            FROM att_attschedule 
                            WHERE employee_id = e.id 
                            ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        WHERE e.id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                emp = new Empleado
                                {
                                    IdEmpleado = Convert.ToInt32(dr["idempleado"]),
                                    CodigoBiometrico = Convert.ToString(dr["codigo_biometrico"]),
                                    Nombre = Convert.ToString(dr["nombre"]),
                                    Apellido = Convert.ToString(dr["apellido"]),
                                    NumDocumento = Convert.ToString(dr["num_documento"]),
                                    Email = Convert.ToString(dr["email"]),
                                    Telefono = Convert.ToString(dr["telefono"]),
                                    DepartamentoId = dr["department_id"] != DBNull.Value ? (int?)Convert.ToInt32(dr["department_id"]) : null,
                                    Departamento = Convert.ToString(dr["departamento"]),
                                    CargoId = dr["position_id"] != DBNull.Value ? (int?)Convert.ToInt32(dr["position_id"]) : null,
                                    Cargo = Convert.ToString(dr["cargo"]),
                                    TurnoId = dr["turnoid"] != DBNull.Value ? (int?)Convert.ToInt32(dr["turnoid"]) : null,
                                    Turno = Convert.ToString(dr["turno"]),
                                    TarjetaRFID = Convert.ToString(dr["tarjeta_rfid"]),
                                    PasswordBiometrico = Convert.ToString(dr["password_biometrico"]),
                                    Privilegio = Convert.ToInt32(dr["privilegio"]),
                                    Habilitado = Convert.ToBoolean(dr["habilitado"]),
                                    FechaRegistro = Convert.ToDateTime(dr["fecha_registro"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleado: " + ex.Message);
            }
            return emp;
        }

        public Empleado ObtenerPorCodigo(string codigoBiometrico)
        {
            Empleado emp = null;
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT e.id AS idempleado, 
                               e.emp_code::text AS codigo_biometrico, 
                               e.first_name AS nombre, 
                               COALESCE(e.last_name, '') AS apellido, 
                               COALESCE(e.national_num, '') AS num_documento, 
                               COALESCE(e.email, '') AS email, 
                               COALESCE(NULLIF(e.mobile, ''), COALESCE(e.contact_tel, '')) AS telefono, 
                               e.department_id,
                               COALESCE(d.dept_name, 'General') AS departamento, 
                               e.position_id,
                               COALESCE(p.position_name, 'General') AS cargo, 
                               COALESCE(e.card_no, '') AS tarjeta_rfid, 
                               COALESCE(e.device_password, '') AS password_biometrico, 
                               COALESCE(e.dev_privilege, 0) AS privilegio, 
                               (COALESCE(e.enable_att, true) AND COALESCE(e.is_active, true)) AS habilitado, 
                               COALESCE(e.hire_date::timestamp, e.create_time, NOW()) AS fecha_registro,
                               s.shift_id AS turnoid,
                               COALESCE(sh.alias, 'Sin Turno') AS turno
                        FROM personnel_employee e 
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN personnel_position p ON e.position_id = p.id
                        LEFT JOIN LATERAL (
                            SELECT shift_id 
                            FROM att_attschedule 
                            WHERE employee_id = e.id 
                            ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        WHERE e.emp_code::text = @codigo";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = codigoBiometrico.Trim();
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                emp = new Empleado
                                {
                                    IdEmpleado = Convert.ToInt32(dr["idempleado"]),
                                    CodigoBiometrico = Convert.ToString(dr["codigo_biometrico"]),
                                    Nombre = Convert.ToString(dr["nombre"]),
                                    Apellido = Convert.ToString(dr["apellido"]),
                                    NumDocumento = Convert.ToString(dr["num_documento"]),
                                    Email = Convert.ToString(dr["email"]),
                                    Telefono = Convert.ToString(dr["telefono"]),
                                    DepartamentoId = dr["department_id"] != DBNull.Value ? (int?)Convert.ToInt32(dr["department_id"]) : null,
                                    Departamento = Convert.ToString(dr["departamento"]),
                                    CargoId = dr["position_id"] != DBNull.Value ? (int?)Convert.ToInt32(dr["position_id"]) : null,
                                    Cargo = Convert.ToString(dr["cargo"]),
                                    TurnoId = dr["turnoid"] != DBNull.Value ? (int?)Convert.ToInt32(dr["turnoid"]) : null,
                                    Turno = Convert.ToString(dr["turno"]),
                                    TarjetaRFID = Convert.ToString(dr["tarjeta_rfid"]),
                                    PasswordBiometrico = Convert.ToString(dr["password_biometrico"]),
                                    Privilegio = Convert.ToInt32(dr["privilegio"]),
                                    Habilitado = Convert.ToBoolean(dr["habilitado"]),
                                    FechaRegistro = Convert.ToDateTime(dr["fecha_registro"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleado: " + ex.Message);
            }
            return emp;
        }

        public string Insertar(Empleado obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    string checkSql = "SELECT id, deleted FROM personnel_employee WHERE emp_code::text = @codigo LIMIT 1";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, sqlCon))
                    {
                        checkCmd.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        using (var dr = checkCmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int existingId = Convert.ToInt32(dr["id"]);
                                bool isDeleted = Convert.ToBoolean(dr["deleted"]);
                                if (!isDeleted)
                                {
                                    return "Ya existe un empleado activo con el código biométrico ingresado.";
                                }
                                else
                                {
                                    dr.Close();
                                    obj.IdEmpleado = existingId;
                                    return Actualizar(obj);
                                }
                            }
                        }
                    }

                    int deptId = obj.DepartamentoId ?? 1;

                    string insertSql = @"
                        INSERT INTO personnel_employee (
                            emp_code, first_name, last_name, national_num, email, mobile, 
                            department_id, position_id, card_no, device_password, dev_privilege, 
                            status, is_admin, enable_att, enable_payroll, enable_overtime, enable_holiday, 
                            deleted, is_active, hire_date, create_time
                        ) VALUES (
                            @codigo::bigint, @nombre, @apellido, @documento, @email, @telefono, 
                            @deptId, @posId, @tarjeta, @password, @privilegio, 
                            0, false, @habilitado, true, false, true, 
                            false, @habilitado, NOW()::date, NOW()
                        ) RETURNING id;";

                    int nuevoEmpId = 0;
                    using (NpgsqlCommand comando = new NpgsqlCommand(insertSql, sqlCon))
                    {
                        comando.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = obj.Nombre.Trim();
                        comando.Parameters.Add("@apellido", NpgsqlDbType.Varchar, 100).Value = (object)obj.Apellido ?? DBNull.Value;
                        comando.Parameters.Add("@documento", NpgsqlDbType.Varchar, 50).Value = (object)obj.NumDocumento ?? DBNull.Value;
                        comando.Parameters.Add("@email", NpgsqlDbType.Varchar, 100).Value = (object)obj.Email ?? DBNull.Value;
                        comando.Parameters.Add("@telefono", NpgsqlDbType.Varchar, 50).Value = (object)obj.Telefono ?? DBNull.Value;
                        comando.Parameters.Add("@deptId", NpgsqlDbType.Integer).Value = deptId;
                        comando.Parameters.Add("@posId", NpgsqlDbType.Integer).Value = obj.CargoId.HasValue ? (object)obj.CargoId.Value : DBNull.Value;
                        comando.Parameters.Add("@tarjeta", NpgsqlDbType.Varchar, 50).Value = (object)obj.TarjetaRFID ?? DBNull.Value;
                        comando.Parameters.Add("@password", NpgsqlDbType.Varchar, 50).Value = (object)obj.PasswordBiometrico ?? DBNull.Value;
                        comando.Parameters.Add("@privilegio", NpgsqlDbType.Integer).Value = obj.Privilegio;
                        comando.Parameters.Add("@habilitado", NpgsqlDbType.Boolean).Value = obj.Habilitado;

                        nuevoEmpId = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    if (obj.TurnoId.HasValue && obj.TurnoId.Value > 0 && nuevoEmpId > 0)
                    {
                        string schedSql = @"
                            INSERT INTO att_attschedule (employee_id, shift_id, start_date, end_date)
                            VALUES (@empId, @shiftId, '2020-01-01', '2035-12-31');";
                        using (NpgsqlCommand schedCmd = new NpgsqlCommand(schedSql, sqlCon))
                        {
                            schedCmd.Parameters.Add("@empId", NpgsqlDbType.Integer).Value = nuevoEmpId;
                            schedCmd.Parameters.Add("@shiftId", NpgsqlDbType.Integer).Value = obj.TurnoId.Value;
                            schedCmd.ExecuteNonQuery();
                        }
                    }

                    respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Actualizar(Empleado obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    string updateSql = @"
                        UPDATE personnel_employee 
                        SET emp_code = @codigo::bigint, first_name = @nombre, last_name = @apellido, 
                            national_num = @documento, email = @email, mobile = @telefono, 
                            department_id = COALESCE(@deptId, department_id), 
                            position_id = @posId, 
                            card_no = @tarjeta, 
                            device_password = @password, dev_privilege = @privilegio, 
                            enable_att = @habilitado, is_active = @habilitado, deleted = false,
                            change_time = NOW()
                        WHERE id = @idempleado";

                    using (NpgsqlCommand comando = new NpgsqlCommand(updateSql, sqlCon))
                    {
                        comando.Parameters.Add("@idempleado", NpgsqlDbType.Integer).Value = obj.IdEmpleado;
                        comando.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = obj.Nombre.Trim();
                        comando.Parameters.Add("@apellido", NpgsqlDbType.Varchar, 100).Value = (object)obj.Apellido ?? DBNull.Value;
                        comando.Parameters.Add("@documento", NpgsqlDbType.Varchar, 50).Value = (object)obj.NumDocumento ?? DBNull.Value;
                        comando.Parameters.Add("@email", NpgsqlDbType.Varchar, 100).Value = (object)obj.Email ?? DBNull.Value;
                        comando.Parameters.Add("@telefono", NpgsqlDbType.Varchar, 50).Value = (object)obj.Telefono ?? DBNull.Value;
                        comando.Parameters.Add("@deptId", NpgsqlDbType.Integer).Value = obj.DepartamentoId.HasValue ? (object)obj.DepartamentoId.Value : DBNull.Value;
                        comando.Parameters.Add("@posId", NpgsqlDbType.Integer).Value = obj.CargoId.HasValue ? (object)obj.CargoId.Value : DBNull.Value;
                        comando.Parameters.Add("@tarjeta", NpgsqlDbType.Varchar, 50).Value = (object)obj.TarjetaRFID ?? DBNull.Value;
                        comando.Parameters.Add("@password", NpgsqlDbType.Varchar, 50).Value = (object)obj.PasswordBiometrico ?? DBNull.Value;
                        comando.Parameters.Add("@privilegio", NpgsqlDbType.Integer).Value = obj.Privilegio;
                        comando.Parameters.Add("@habilitado", NpgsqlDbType.Boolean).Value = obj.Habilitado;

                        comando.ExecuteNonQuery();
                    }

                    if (obj.TurnoId.HasValue && obj.TurnoId.Value > 0)
                    {
                        string upsertSchedSql = @"
                            UPDATE att_attschedule 
                            SET shift_id = @shiftId 
                            WHERE id = (SELECT id FROM att_attschedule WHERE employee_id = @empId ORDER BY id DESC LIMIT 1);
                            
                            INSERT INTO att_attschedule (employee_id, shift_id, start_date, end_date)
                            SELECT @empId, @shiftId, '2020-01-01', '2035-12-31'
                            WHERE NOT EXISTS (SELECT 1 FROM att_attschedule WHERE employee_id = @empId);";

                        using (NpgsqlCommand schedCmd = new NpgsqlCommand(upsertSchedSql, sqlCon))
                        {
                            schedCmd.Parameters.Add("@empId", NpgsqlDbType.Integer).Value = obj.IdEmpleado;
                            schedCmd.Parameters.Add("@shiftId", NpgsqlDbType.Integer).Value = obj.TurnoId.Value;
                            schedCmd.ExecuteNonQuery();
                        }
                    }

                    respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string GuardarOActualizarDesdeBiometrico(string codigo, string nombre, string password, int privilegio, bool habilitado, string tarjeta)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();
                    string checkSql = "SELECT id FROM personnel_employee WHERE emp_code::text = @codigo LIMIT 1";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, sqlCon))
                    {
                        checkCmd.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = codigo.Trim();
                        object res = checkCmd.ExecuteScalar();

                        if (res != null)
                        {
                            int empId = Convert.ToInt32(res);
                            string updateSql = @"
                                UPDATE personnel_employee 
                                SET first_name = CASE WHEN COALESCE(@nombre, '') <> '' THEN @nombre ELSE first_name END,
                                    device_password = @password,
                                    dev_privilege = @privilegio,
                                    enable_att = @habilitado,
                                    is_active = @habilitado,
                                    deleted = false,
                                    card_no = CASE WHEN COALESCE(@tarjeta, '') <> '' THEN @tarjeta ELSE card_no END,
                                    change_time = NOW()
                                WHERE id = @empId";

                            using (NpgsqlCommand updateCmd = new NpgsqlCommand(updateSql, sqlCon))
                            {
                                updateCmd.Parameters.Add("@empId", NpgsqlDbType.Integer).Value = empId;
                                updateCmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = string.IsNullOrWhiteSpace(nombre) ? (object)DBNull.Value : nombre.Trim();
                                updateCmd.Parameters.Add("@password", NpgsqlDbType.Varchar, 50).Value = string.IsNullOrWhiteSpace(password) ? (object)DBNull.Value : password.Trim();
                                updateCmd.Parameters.Add("@privilegio", NpgsqlDbType.Integer).Value = privilegio;
                                updateCmd.Parameters.Add("@habilitado", NpgsqlDbType.Boolean).Value = habilitado;
                                updateCmd.Parameters.Add("@tarjeta", NpgsqlDbType.Varchar, 50).Value = string.IsNullOrWhiteSpace(tarjeta) ? (object)DBNull.Value : tarjeta.Trim();

                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertSql = @"
                                INSERT INTO personnel_employee (
                                    emp_code, first_name, last_name, department_id, device_password, 
                                    dev_privilege, status, is_admin, enable_att, enable_payroll, 
                                    enable_overtime, enable_holiday, deleted, is_active, card_no, 
                                    hire_date, create_time
                                ) VALUES (
                                    @codigo::bigint, COALESCE(NULLIF(@nombre, ''), 'Empleado ' || @codigo), '', 1, @password, 
                                    @privilegio, 0, false, @habilitado, true, 
                                    false, true, false, @habilitado, @tarjeta, 
                                    NOW()::date, NOW()
                                )";

                            using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertSql, sqlCon))
                            {
                                insertCmd.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = codigo.Trim();
                                insertCmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = string.IsNullOrWhiteSpace(nombre) ? (object)DBNull.Value : nombre.Trim();
                                insertCmd.Parameters.Add("@password", NpgsqlDbType.Varchar, 50).Value = string.IsNullOrWhiteSpace(password) ? (object)DBNull.Value : password.Trim();
                                insertCmd.Parameters.Add("@privilegio", NpgsqlDbType.Integer).Value = privilegio;
                                insertCmd.Parameters.Add("@habilitado", NpgsqlDbType.Boolean).Value = habilitado;
                                insertCmd.Parameters.Add("@tarjeta", NpgsqlDbType.Varchar, 50).Value = string.IsNullOrWhiteSpace(tarjeta) ? (object)DBNull.Value : tarjeta.Trim();

                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Eliminar(int id)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE personnel_employee SET is_active = false, enable_att = false, deleted = true WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el empleado.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Activar(int id)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE personnel_employee SET is_active = true, enable_att = true, deleted = false WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el empleado.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Desactivar(int id)
        {
            return Eliminar(id);
        }

        public DataTable ListarAdministradoresBiometricos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT e.id AS idempleado, 
                               e.emp_code::text AS codigo_biometrico,
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_completo,
                               COALESCE(d.dept_name, 'General') AS departamento,
                               COALESCE(pos.position_name, 'General') AS cargo,
                               CASE 
                                   WHEN COALESCE(e.dev_privilege, 0) = 3 THEN 'Super Administrador'
                                   WHEN COALESCE(e.dev_privilege, 0) = 14 THEN 'Administrador'
                                   WHEN COALESCE(e.dev_privilege, 0) > 0 THEN 'Administrador (Nivel ' || e.dev_privilege || ')'
                                   WHEN COALESCE(e.is_admin, false) = true THEN 'Super Administrador'
                                   WHEN e.emp_code IN (99999, 888, 3054, 305150715) THEN 'Admin Especial'
                                   ELSE 'Administrador'
                               END AS privilegio_texto,
                               COALESCE(e.dev_privilege, 3) AS privilegio,
                               CASE WHEN e.device_password IS NOT NULL AND e.device_password <> '' THEN 'Sí' ELSE 'No' END AS tiene_clave,
                               COALESCE(e.card_no, '0') AS tarjeta_rfid,
                               CASE WHEN COALESCE(e.is_active, true) THEN 'Activo' ELSE 'Inactivo' END AS estado
                        FROM personnel_employee e
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN personnel_position pos ON e.position_id = pos.id
                        WHERE COALESCE(e.dev_privilege, 0) > 0 
                           OR COALESCE(e.is_admin, false) = true 
                           OR e.emp_code IN (99999, 888, 3054, 305150715)
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
                throw new Exception("Error al listar administradores biométricos: " + ex.Message);
            }
            return tabla;
        }

        public string ActualizarPrivilegioBiometrico(int idEmpleado, int nuevoPrivilegio)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE personnel_employee SET dev_privilege = @priv, is_admin = (@priv = 3) WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@priv", NpgsqlDbType.Integer).Value = nuevoPrivilegio;
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = idEmpleado;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el privilegio.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
    }
}
