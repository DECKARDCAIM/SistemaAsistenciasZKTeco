using System;
using System.Data;
using Npgsql;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_VacacionPermiso
    {
        private static bool _tablasVerificadas = false;

        public static void GarantizarTablas()
        {
            if (_tablasVerificadas) return;

            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string script = @"
                        CREATE TABLE IF NOT EXISTS att_leavecategory (
                            id SERIAL PRIMARY KEY,
                            category_name VARCHAR(100) NOT NULL,
                            minimum_unit DOUBLE PRECISION NOT NULL DEFAULT 1.0,
                            unit SMALLINT NOT NULL DEFAULT 2,
                            round_off SMALLINT NOT NULL DEFAULT 1,
                            report_symbol VARCHAR(10) NOT NULL,
                            leave_category_type SMALLINT NOT NULL DEFAULT 0
                        );

                        CREATE TABLE IF NOT EXISTS workflow_abstractexception (
                            id SERIAL PRIMARY KEY,
                            audit_status SMALLINT NOT NULL DEFAULT 1,
                            revoke_reason TEXT NULL
                        );

                        CREATE TABLE IF NOT EXISTS att_leave (
                            abstractexception_ptr_id INTEGER PRIMARY KEY REFERENCES workflow_abstractexception(id) ON DELETE CASCADE,
                            start_time TIMESTAMP WITH TIME ZONE NOT NULL,
                            end_time TIMESTAMP WITH TIME ZONE NOT NULL,
                            type SMALLINT NOT NULL DEFAULT 1,
                            apply_reason TEXT NULL,
                            apply_time TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW(),
                            audit_reason TEXT NULL,
                            audit_time TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW(),
                            approval_level SMALLINT NOT NULL DEFAULT 1,
                            audit_user_id INTEGER NULL,
                            approver VARCHAR(100) NULL,
                            vacation_number SMALLINT NOT NULL DEFAULT 0,
                            category_id INTEGER NOT NULL REFERENCES att_leavecategory(id),
                            employee_id INTEGER NOT NULL REFERENCES personnel_employee(id),
                            attachment VARCHAR(200) NULL DEFAULT ''
                        );

                        -- Insertar categorías predeterminadas si está vacía
                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 1, 'Permiso por enfermedad', 1.0, 2, 1, 'SL', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 1);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 2, 'Permiso Ocasional', 0.5, 2, 1, 'CAL', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 2);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 3, 'Permiso de Maternidad', 0.5, 2, 1, 'ML', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 3);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 4, 'Permiso Compasivo', 1.0, 2, 1, 'COL', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 4);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 5, 'Permiso Especial', 1.0, 2, 1, 'AL', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 5);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 6, 'Viaje de Negocios', 1.0, 2, 1, 'BT', 0
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 6);

                        INSERT INTO att_leavecategory (id, category_name, minimum_unit, unit, round_off, report_symbol, leave_category_type)
                        SELECT 7, 'Vacaciones', 1.0, 3, 1, 'VA', 3
                        WHERE NOT EXISTS (SELECT 1 FROM att_leavecategory WHERE id = 7);
                    ";

                    using (NpgsqlCommand comando = new NpgsqlCommand(script, sqlCon))
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                _tablasVerificadas = true;
            }
            catch
            {
            }
        }

        public DataTable ListarCategorias()
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idcategoria, 
                               category_name AS nombre, 
                               report_symbol AS simbolo, 
                               leave_category_type AS tipo,
                               (report_symbol || ' - ' || category_name) AS nombre_completo
                        FROM att_leavecategory
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
                throw new Exception("Error al listar categorías de permisos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Listar()
        {
            return Buscar("", 0, 0, null, null, -1);
        }

        public DataTable Buscar(string valor, int idDept, int idCategoria, DateTime? desde, DateTime? hasta, int estadoAuditoria)
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT l.abstractexception_ptr_id AS idsolicitud,
                               l.employee_id AS idempleado,
                               e.emp_code::text AS codigo_empleado,
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_empleado,
                               e.department_id AS iddepartamento,
                               COALESCE(d.dept_name, 'General') AS departamento,
                               l.category_id AS idcategoria,
                               c.category_name AS tipo_permiso,
                               c.report_symbol AS simbolo_permiso,
                               l.start_time AS fecha_inicio,
                               l.end_time AS fecha_fin,
                               ROUND(EXTRACT(EPOCH FROM (l.end_time - l.start_time)) / 86400.0, 1) AS dias_solicitados,
                               l.apply_reason AS motivo_solicitud,
                               l.apply_time AS fecha_solicitud,
                               l.audit_reason AS motivo_auditoria,
                               l.audit_time AS fecha_auditoria,
                               COALESCE(l.approver, 'admin') AS aprobador,
                               COALESCE(wa.audit_status, 2) AS estado_auditoria,
                               CASE COALESCE(wa.audit_status, 2)
                                   WHEN 2 THEN 'Aprobado'
                                   WHEN 1 THEN 'Pendiente'
                                   WHEN 3 THEN 'Rechazado'
                                   WHEN 0 THEN 'Rechazado'
                                   ELSE 'Aprobado'
                               END AS estado_descripcion,
                               l.vacation_number AS es_vacaciones,
                               COALESCE(l.attachment, '') AS adjunto
                        FROM att_leave l
                        INNER JOIN personnel_employee e ON l.employee_id = e.id
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        INNER JOIN att_leavecategory c ON l.category_id = c.id
                        LEFT JOIN workflow_abstractexception wa ON l.abstractexception_ptr_id = wa.id
                        WHERE COALESCE(e.deleted, false) = false
                          AND (@valor = '' OR e.emp_code::text ILIKE @valor OR e.first_name ILIKE @valor OR e.last_name ILIKE @valor OR l.apply_reason ILIKE @valor)
                          AND (@idDept = 0 OR e.department_id = @idDept)
                          AND (@idCategoria = 0 OR l.category_id = @idCategoria)
                          AND (@desde IS NULL OR l.start_time >= @desde)
                          AND (@hasta IS NULL OR l.end_time <= @hasta)
                          AND (@estado = -1 OR COALESCE(wa.audit_status, 2) = @estado)
                        ORDER BY l.start_time DESC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@valor", string.IsNullOrWhiteSpace(valor) ? "" : "%" + valor.Trim() + "%");
                        comando.Parameters.AddWithValue("@idDept", idDept);
                        comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                        comando.Parameters.AddWithValue("@desde", desde.HasValue ? (object)desde.Value.Date : DBNull.Value);
                        comando.Parameters.AddWithValue("@hasta", hasta.HasValue ? (object)hasta.Value.Date.AddDays(1).AddSeconds(-1) : DBNull.Value);
                        comando.Parameters.AddWithValue("@estado", estadoAuditoria);

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
                throw new Exception("Error al consultar vacaciones y permisos: " + ex.Message);
            }
            return tabla;
        }

        public string Insertar(VacacionPermiso obj)
        {
            GarantizarTablas();
            string rpta = "";
            using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
            {
                sqlCon.Open();
                using (NpgsqlTransaction trans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar en workflow_abstractexception
                        string sqlParent = @"
                            INSERT INTO workflow_abstractexception (audit_status, revoke_reason)
                            VALUES (@audit_status, NULL)
                            RETURNING id";

                        int nuevoId;
                        using (NpgsqlCommand cmdParent = new NpgsqlCommand(sqlParent, sqlCon, trans))
                        {
                            cmdParent.Parameters.AddWithValue("@audit_status", obj.EstadoAuditoria);
                            nuevoId = Convert.ToInt32(cmdParent.ExecuteScalar());
                        }

                        // 2. Insertar en att_leave
                        string sqlChild = @"
                            INSERT INTO att_leave (
                                abstractexception_ptr_id, start_time, end_time, type, 
                                apply_reason, apply_time, audit_reason, audit_time, 
                                approval_level, audit_user_id, approver, vacation_number, 
                                category_id, employee_id, attachment
                            ) VALUES (
                                @id, @start_time, @end_time, 1, 
                                @apply_reason, @apply_time, @audit_reason, @audit_time, 
                                1, NULL, @approver, @vacation_number, 
                                @category_id, @employee_id, @attachment
                            )";

                        using (NpgsqlCommand cmdChild = new NpgsqlCommand(sqlChild, sqlCon, trans))
                        {
                            cmdChild.Parameters.AddWithValue("@id", nuevoId);
                            cmdChild.Parameters.AddWithValue("@start_time", obj.FechaInicio);
                            cmdChild.Parameters.AddWithValue("@end_time", obj.FechaFin);
                            cmdChild.Parameters.AddWithValue("@apply_reason", string.IsNullOrWhiteSpace(obj.MotivoSolicitud) ? (object)DBNull.Value : obj.MotivoSolicitud.Trim());
                            cmdChild.Parameters.AddWithValue("@apply_time", obj.FechaSolicitud != DateTime.MinValue ? obj.FechaSolicitud : DateTime.Now);
                            cmdChild.Parameters.AddWithValue("@audit_reason", string.IsNullOrWhiteSpace(obj.MotivoAuditoria) ? "Aprobado por RRHH." : obj.MotivoAuditoria.Trim());
                            cmdChild.Parameters.AddWithValue("@audit_time", obj.FechaAuditoria.HasValue ? (object)obj.FechaAuditoria.Value : DateTime.Now);
                            cmdChild.Parameters.AddWithValue("@approver", string.IsNullOrWhiteSpace(obj.Aprobador) ? "admin" : obj.Aprobador.Trim());
                            cmdChild.Parameters.AddWithValue("@vacation_number", obj.IdCategoria == 7 ? 1 : 0);
                            cmdChild.Parameters.AddWithValue("@category_id", obj.IdCategoria);
                            cmdChild.Parameters.AddWithValue("@employee_id", obj.IdEmpleado);
                            cmdChild.Parameters.AddWithValue("@attachment", string.IsNullOrWhiteSpace(obj.Adjunto) ? "" : obj.Adjunto.Trim());

                            cmdChild.ExecuteNonQuery();
                        }

                        trans.Commit();
                        rpta = "OK";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        rpta = ex.Message;
                    }
                }
            }
            return rpta;
        }

        public string Actualizar(VacacionPermiso obj)
        {
            GarantizarTablas();
            string rpta = "";
            using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
            {
                sqlCon.Open();
                using (NpgsqlTransaction trans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        // 1. Actualizar workflow_abstractexception
                        string sqlParent = "UPDATE workflow_abstractexception SET audit_status = @audit_status WHERE id = @id";
                        using (NpgsqlCommand cmdParent = new NpgsqlCommand(sqlParent, sqlCon, trans))
                        {
                            cmdParent.Parameters.AddWithValue("@id", obj.Id);
                            cmdParent.Parameters.AddWithValue("@audit_status", obj.EstadoAuditoria);
                            cmdParent.ExecuteNonQuery();
                        }

                        // 2. Actualizar att_leave
                        string sqlChild = @"
                            UPDATE att_leave SET
                                start_time = @start_time,
                                end_time = @end_time,
                                apply_reason = @apply_reason,
                                audit_reason = @audit_reason,
                                audit_time = @audit_time,
                                approver = @approver,
                                vacation_number = @vacation_number,
                                category_id = @category_id,
                                employee_id = @employee_id,
                                attachment = @attachment
                            WHERE abstractexception_ptr_id = @id";

                        using (NpgsqlCommand cmdChild = new NpgsqlCommand(sqlChild, sqlCon, trans))
                        {
                            cmdChild.Parameters.AddWithValue("@id", obj.Id);
                            cmdChild.Parameters.AddWithValue("@start_time", obj.FechaInicio);
                            cmdChild.Parameters.AddWithValue("@end_time", obj.FechaFin);
                            cmdChild.Parameters.AddWithValue("@apply_reason", string.IsNullOrWhiteSpace(obj.MotivoSolicitud) ? (object)DBNull.Value : obj.MotivoSolicitud.Trim());
                            cmdChild.Parameters.AddWithValue("@audit_reason", string.IsNullOrWhiteSpace(obj.MotivoAuditoria) ? "Aprobado por RRHH." : obj.MotivoAuditoria.Trim());
                            cmdChild.Parameters.AddWithValue("@audit_time", obj.FechaAuditoria.HasValue ? (object)obj.FechaAuditoria.Value : DateTime.Now);
                            cmdChild.Parameters.AddWithValue("@approver", string.IsNullOrWhiteSpace(obj.Aprobador) ? "admin" : obj.Aprobador.Trim());
                            cmdChild.Parameters.AddWithValue("@vacation_number", obj.IdCategoria == 7 ? 1 : 0);
                            cmdChild.Parameters.AddWithValue("@category_id", obj.IdCategoria);
                            cmdChild.Parameters.AddWithValue("@employee_id", obj.IdEmpleado);
                            cmdChild.Parameters.AddWithValue("@attachment", string.IsNullOrWhiteSpace(obj.Adjunto) ? "" : obj.Adjunto.Trim());

                            cmdChild.ExecuteNonQuery();
                        }

                        trans.Commit();
                        rpta = "OK";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        rpta = ex.Message;
                    }
                }
            }
            return rpta;
        }

        public string Eliminar(int id)
        {
            GarantizarTablas();
            string rpta = "";
            using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
            {
                sqlCon.Open();
                using (NpgsqlTransaction trans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        using (NpgsqlCommand cmdChild = new NpgsqlCommand("DELETE FROM att_leave WHERE abstractexception_ptr_id = @id", sqlCon, trans))
                        {
                            cmdChild.Parameters.AddWithValue("@id", id);
                            cmdChild.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmdParent = new NpgsqlCommand("DELETE FROM workflow_abstractexception WHERE id = @id", sqlCon, trans))
                        {
                            cmdParent.Parameters.AddWithValue("@id", id);
                            cmdParent.ExecuteNonQuery();
                        }

                        trans.Commit();
                        rpta = "OK";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        rpta = ex.Message;
                    }
                }
            }
            return rpta;
        }

        public string CambiarEstado(int id, short estado, string auditor, string motivo)
        {
            GarantizarTablas();
            string rpta = "";
            using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
            {
                sqlCon.Open();
                using (NpgsqlTransaction trans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        using (NpgsqlCommand cmdParent = new NpgsqlCommand("UPDATE workflow_abstractexception SET audit_status = @status WHERE id = @id", sqlCon, trans))
                        {
                            cmdParent.Parameters.AddWithValue("@id", id);
                            cmdParent.Parameters.AddWithValue("@status", estado);
                            cmdParent.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmdChild = new NpgsqlCommand("UPDATE att_leave SET audit_reason = @motivo, approver = @auditor, audit_time = NOW() WHERE abstractexception_ptr_id = @id", sqlCon, trans))
                        {
                            cmdChild.Parameters.AddWithValue("@id", id);
                            cmdChild.Parameters.AddWithValue("@motivo", motivo);
                            cmdChild.Parameters.AddWithValue("@auditor", auditor);
                            cmdChild.ExecuteNonQuery();
                        }

                        trans.Commit();
                        rpta = "OK";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        rpta = ex.Message;
                    }
                }
            }
            return rpta;
        }
    }
}
