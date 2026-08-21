using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Asistencia
    {
        public DataTable GenerarReporteConsolidado(DateTime fechaInicio, DateTime fechaFin, int? idDepartamento = null, int? idEmpleado = null, int? idTurno = null, string buscarTexto = null)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        WITH dates AS (
                            SELECT generate_series(@inicio::date, @fin::date, '1 day'::interval)::date AS fecha
                        ),
                        emp_dates AS (
                            SELECT 
                                e.id AS idempleado,
                                e.emp_code::text AS emp_code,
                                e.first_name,
                                e.last_name,
                                e.department_id,
                                d.fecha
                            FROM personnel_employee e
                            CROSS JOIN dates d
                            WHERE COALESCE(e.deleted, false) = false 
                              AND COALESCE(e.is_active, true) = true 
                              AND COALESCE(e.enable_att, true) = true
                        ),
                        daily_punches AS (
                            SELECT 
                                t.emp_code,
                                t.punch_time::date AS fecha,
                                t.punch_time,
                                t.punch_state,
                                ROW_NUMBER() OVER (PARTITION BY t.emp_code, t.punch_time::date ORDER BY t.punch_time ASC) AS punch_order_asc,
                                ROW_NUMBER() OVER (PARTITION BY t.emp_code, t.punch_time::date ORDER BY t.punch_time DESC) AS punch_order_desc,
                                COUNT(*) OVER (PARTITION BY t.emp_code, t.punch_time::date) AS total_punches
                            FROM iclock_transaction t
                            WHERE t.punch_time >= @inicio AND t.punch_time <= @fin
                        ),
                        aggregated AS (
                            SELECT 
                                dp.emp_code,
                                dp.fecha,
                                dp.total_punches,
                                -- Entrada: Primera marcación del día
                                MIN(CASE WHEN dp.punch_order_asc = 1 THEN dp.punch_time END) AS entrada,

                                -- Salida Almuerzo:
                                -- Si hay 2 marcaciones y la 2da es antes de las 14:00, es salida a almuerzo.
                                -- Si hay 3 marcaciones y la 2da es antes de las 14:00, es salida a almuerzo.
                                -- Si hay >= 4 marcaciones, es la 2da marcación.
                                MIN(CASE 
                                    WHEN dp.punch_state = '2' THEN dp.punch_time
                                    WHEN dp.total_punches = 2 AND dp.punch_order_asc = 2 AND dp.punch_time::time < '14:00:00'::time THEN dp.punch_time
                                    WHEN dp.total_punches = 3 AND dp.punch_order_asc = 2 AND dp.punch_time::time < '14:00:00'::time THEN dp.punch_time
                                    WHEN dp.total_punches >= 4 AND dp.punch_order_asc = 2 THEN dp.punch_time
                                    ELSE NULL 
                                END) AS salida_almuerzo,

                                -- Regreso Almuerzo:
                                -- Si hay 3 marcaciones y la 3ra es antes de las 14:30, es regreso de almuerzo.
                                -- Si hay >= 4 marcaciones, es la 3ra marcación (cuando no es la última).
                                MIN(CASE 
                                    WHEN dp.punch_state = '3' THEN dp.punch_time
                                    WHEN dp.total_punches = 3 AND dp.punch_order_asc = 3 AND dp.punch_time::time < '14:30:00'::time THEN dp.punch_time
                                    WHEN dp.total_punches >= 4 AND dp.punch_order_asc = 3 AND dp.punch_order_desc > 1 THEN dp.punch_time
                                    ELSE NULL 
                                END) AS regreso_almuerzo,

                                -- Salida Final:
                                -- Si hay 2 marcaciones y la 2da es >= 14:00 (fin de jornada), es salida.
                                -- Si hay 3 marcaciones y la 3ra es >= 14:00 (fin de jornada), es salida.
                                -- Si hay >= 4 marcaciones, es la última marcación (desc = 1) cuando es >= 14:00.
                                MIN(CASE 
                                    WHEN dp.punch_state = '1' THEN dp.punch_time
                                    WHEN dp.total_punches = 2 AND dp.punch_order_desc = 1 AND dp.punch_time::time >= '14:00:00'::time THEN dp.punch_time
                                    WHEN dp.total_punches = 3 AND dp.punch_order_desc = 1 AND dp.punch_time::time >= '14:00:00'::time THEN dp.punch_time
                                    WHEN dp.total_punches >= 4 AND dp.punch_order_desc = 1 AND dp.punch_time::time >= '14:00:00'::time THEN dp.punch_time 
                                    ELSE NULL 
                                END) AS salida
                            FROM daily_punches dp
                            GROUP BY dp.emp_code, dp.fecha, dp.total_punches
                        )
                        SELECT 
                            ed.idempleado,
                            ed.emp_code AS codigo_empleado,
                            (COALESCE(ed.first_name, '') || ' ' || COALESCE(ed.last_name, '')) AS empleado,
                            COALESCE(dept.dept_name, 'General') AS departamento,
                            ed.department_id,
                            COALESCE(sh.alias, 'Sin Turno') AS turno,
                            s.shift_id AS turnoid,
                            ed.fecha,
                            COALESCE(TO_CHAR(a.entrada, 'HH24:MI:SS'), '--') AS hora_entrada,
                            COALESCE(TO_CHAR(a.salida_almuerzo, 'HH24:MI:SS'), '--') AS salida_almuerzo,
                            COALESCE(TO_CHAR(a.regreso_almuerzo, 'HH24:MI:SS'), '--') AS regreso_almuerzo,
                            COALESCE(TO_CHAR(a.salida, 'HH24:MI:SS'), '--') AS hora_salida,
                            COALESCE(a.total_punches, 0) AS total_marcaciones,
                            CASE 
                                WHEN a.entrada IS NOT NULL AND a.salida IS NOT NULL THEN
                                    TO_CHAR(
                                        (a.salida - a.entrada) - 
                                        COALESCE(CASE WHEN a.salida_almuerzo IS NOT NULL AND a.regreso_almuerzo IS NOT NULL THEN (a.regreso_almuerzo - a.salida_almuerzo) ELSE interval '0' END, interval '0'),
                                        'HH24:MI'
                                    )
                                ELSE '--'
                            END AS horas_trabajadas,
                            CASE 
                                WHEN lv.category_name IS NOT NULL THEN 
                                    CASE 
                                        WHEN lv.category_name ILIKE '%vacacion%' THEN '🌴 Vacaciones'
                                        ELSE '📋 Permiso: ' || lv.category_name
                                    END
                                WHEN a.entrada IS NULL THEN 'No Marcó'
                                WHEN COALESCE(ti.in_time, sd.in_time) IS NOT NULL 
                                     AND COALESCE(ti.in_time, sd.in_time) > '00:00:00'::time
                                     AND a.entrada::time > (COALESCE(ti.in_time, sd.in_time) + interval '15 minutes') THEN
                                    CASE 
                                        WHEN a.salida IS NOT NULL THEN 
                                            'Tardanza (' || FLOOR(EXTRACT(EPOCH FROM (a.entrada::time - COALESCE(ti.in_time, sd.in_time))) / 60)::text || ' min)'
                                        WHEN a.regreso_almuerzo IS NOT NULL THEN 
                                            'Tardanza (' || FLOOR(EXTRACT(EPOCH FROM (a.entrada::time - COALESCE(ti.in_time, sd.in_time))) / 60)::text || ' min) - En Turno'
                                        WHEN a.salida_almuerzo IS NOT NULL THEN 
                                            'Tardanza (' || FLOOR(EXTRACT(EPOCH FROM (a.entrada::time - COALESCE(ti.in_time, sd.in_time))) / 60)::text || ' min) - En Almuerzo'
                                        ELSE 
                                            'Tardanza (' || FLOOR(EXTRACT(EPOCH FROM (a.entrada::time - COALESCE(ti.in_time, sd.in_time))) / 60)::text || ' min) - En Turno'
                                    END
                                WHEN a.salida IS NOT NULL THEN 'Completo'
                                WHEN a.regreso_almuerzo IS NOT NULL THEN 'En Turno (Regreso Almuerzo)'
                                WHEN a.salida_almuerzo IS NOT NULL THEN 'En Almuerzo'
                                WHEN a.entrada IS NOT NULL THEN 'En Turno'
                                ELSE 'Incompleto'
                            END AS estado
                        FROM emp_dates ed
                        LEFT JOIN aggregated a ON ed.emp_code = a.emp_code AND ed.fecha = a.fecha
                        LEFT JOIN personnel_department dept ON ed.department_id = dept.id
                        LEFT JOIN LATERAL (
                            SELECT l.abstractexception_ptr_id, c.category_name, c.report_symbol
                            FROM att_leave l
                            INNER JOIN att_leavecategory c ON l.category_id = c.id
                            LEFT JOIN workflow_abstractexception wa ON l.abstractexception_ptr_id = wa.id
                            WHERE l.employee_id = ed.idempleado
                              AND COALESCE(wa.audit_status, 2) = 2
                              AND ed.fecha >= l.start_time::date 
                              AND ed.fecha <= l.end_time::date
                            LIMIT 1
                        ) lv ON true
                        LEFT JOIN LATERAL (
                            SELECT shift_id FROM att_attschedule WHERE employee_id = ed.idempleado ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        LEFT JOIN LATERAL (
                            SELECT in_time, time_interval_id FROM att_shiftdetail WHERE shift_id = s.shift_id AND in_time > '00:00:00'::time ORDER BY id ASC LIMIT 1
                        ) sd ON true
                        LEFT JOIN att_timeinterval ti ON sd.time_interval_id = ti.id
                        WHERE 1=1";

                    if (idDepartamento.HasValue && idDepartamento.Value > 0)
                        consulta += " AND ed.department_id = @idDept";
                    if (idEmpleado.HasValue && idEmpleado.Value > 0)
                        consulta += " AND ed.idempleado = @idEmp";
                    if (idTurno.HasValue && idTurno.Value > 0)
                        consulta += " AND s.shift_id = @idTurno";
                    if (!string.IsNullOrWhiteSpace(buscarTexto))
                        consulta += " AND (ed.emp_code ILIKE '%' || @buscar || '%' OR ed.first_name ILIKE '%' || @buscar || '%' OR ed.last_name ILIKE '%' || @buscar || '%' OR dept.dept_name ILIKE '%' || @buscar || '%')";

                    consulta += " ORDER BY ed.fecha DESC, dept.dept_name ASC, ed.emp_code ASC LIMIT 5000";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@inicio", NpgsqlDbType.Timestamp).Value = fechaInicio.Date;
                        comando.Parameters.Add("@fin", NpgsqlDbType.Timestamp).Value = fechaFin;

                        if (idDepartamento.HasValue && idDepartamento.Value > 0)
                            comando.Parameters.Add("@idDept", NpgsqlDbType.Integer).Value = idDepartamento.Value;
                        if (idEmpleado.HasValue && idEmpleado.Value > 0)
                            comando.Parameters.Add("@idEmp", NpgsqlDbType.Integer).Value = idEmpleado.Value;
                        if (idTurno.HasValue && idTurno.Value > 0)
                            comando.Parameters.Add("@idTurno", NpgsqlDbType.Integer).Value = idTurno.Value;
                        if (!string.IsNullOrWhiteSpace(buscarTexto))
                            comando.Parameters.Add("@buscar", NpgsqlDbType.Varchar, 100).Value = buscarTexto.Trim();

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
                throw new Exception("Error al generar reporte consolidado de asistencias: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Listar(DateTime? fechaInicio = null, DateTime? fechaFin = null, int? idEmpleado = null, int? idBiometrico = null, int? idDepartamento = null, int? idTurno = null, string buscarTexto = null)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT t.id AS idasistencia, 
                               t.emp_id AS idempleado, 
                               t.emp_code AS codigo_biometrico, 
                               COALESCE(NULLIF(TRIM(COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')), ''), 'Empleado ' || t.emp_code) AS empleado,
                               COALESCE(d.dept_name, 'General') AS departamento,
                               COALESCE(sh.alias, 'Sin Turno') AS turno,
                               t.punch_time AS fecha_hora, 
                               COALESCE(NULLIF(t.punch_state, '')::integer, 0) AS tipo_marcacion, 
                               CASE COALESCE(NULLIF(t.punch_state, '')::integer, 0)
                                    WHEN 0 THEN 'Entrada'
                                    WHEN 1 THEN 'Salida'
                                    WHEN 2 THEN 'Salida a Refrigerio'
                                    WHEN 3 THEN 'Regreso de Refrigerio'
                                    WHEN 4 THEN 'HE Entrada'
                                    WHEN 5 THEN 'HE Salida'
                                    ELSE 'Otro (' || t.punch_state || ')'
                               END AS tipo_descripcion,
                               COALESCE(t.verify_type, 1) AS metodo_verificacion, 
                               CASE COALESCE(t.verify_type, 1)
                                    WHEN 1 THEN 'Huella Dactilar'
                                    WHEN 2 THEN 'Contraseña'
                                    WHEN 3 THEN 'Tarjeta RFID'
                                    WHEN 4 THEN 'Rostro'
                                    WHEN 15 THEN 'Palma'
                                    ELSE 'Otro (' || t.verify_type || ')'
                               END AS metodo_descripcion,
                               t.terminal_id AS idbiometrico, 
                               COALESCE(t.terminal_alias, COALESCE(term.alias, 'Reloj ZKTeco')) AS biometrico, 
                               COALESCE(t.upload_time, t.punch_time) AS fecha_registro
                        FROM iclock_transaction t
                        INNER JOIN personnel_employee e ON t.emp_code = e.emp_code::text 
                            AND COALESCE(e.deleted, false) = false 
                            AND COALESCE(e.is_active, true) = true 
                            AND COALESCE(e.enable_att, true) = true
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN LATERAL (
                            SELECT shift_id FROM att_attschedule WHERE employee_id = e.id ORDER BY id DESC LIMIT 1
                        ) s ON true
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        LEFT JOIN iclock_terminal term ON t.terminal_id = term.id
                        WHERE 1=1";

                    if (fechaInicio.HasValue)
                        consulta += " AND t.punch_time >= @inicio";
                    if (fechaFin.HasValue)
                        consulta += " AND t.punch_time <= @fin";
                    if (idEmpleado.HasValue && idEmpleado.Value > 0)
                        consulta += " AND (t.emp_id = @idEmp OR e.id = @idEmp)";
                    if (idBiometrico.HasValue && idBiometrico.Value > 0)
                        consulta += " AND t.terminal_id = @idBio";
                    if (idDepartamento.HasValue && idDepartamento.Value > 0)
                        consulta += " AND e.department_id = @idDept";
                    if (idTurno.HasValue && idTurno.Value > 0)
                        consulta += " AND s.shift_id = @idTurno";
                    if (!string.IsNullOrWhiteSpace(buscarTexto))
                        consulta += " AND (t.emp_code ILIKE '%' || @buscar || '%' OR e.first_name ILIKE '%' || @buscar || '%' OR e.last_name ILIKE '%' || @buscar || '%' OR d.dept_name ILIKE '%' || @buscar || '%')";

                    consulta += " ORDER BY t.punch_time DESC LIMIT 2000";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        if (fechaInicio.HasValue)
                            comando.Parameters.Add("@inicio", NpgsqlDbType.Timestamp).Value = fechaInicio.Value;
                        if (fechaFin.HasValue)
                            comando.Parameters.Add("@fin", NpgsqlDbType.Timestamp).Value = fechaFin.Value;
                        if (idEmpleado.HasValue && idEmpleado.Value > 0)
                            comando.Parameters.Add("@idEmp", NpgsqlDbType.Integer).Value = idEmpleado.Value;
                        if (idBiometrico.HasValue && idBiometrico.Value > 0)
                            comando.Parameters.Add("@idBio", NpgsqlDbType.Integer).Value = idBiometrico.Value;
                        if (idDepartamento.HasValue && idDepartamento.Value > 0)
                            comando.Parameters.Add("@idDept", NpgsqlDbType.Integer).Value = idDepartamento.Value;
                        if (idTurno.HasValue && idTurno.Value > 0)
                            comando.Parameters.Add("@idTurno", NpgsqlDbType.Integer).Value = idTurno.Value;
                        if (!string.IsNullOrWhiteSpace(buscarTexto))
                            comando.Parameters.Add("@buscar", NpgsqlDbType.Varchar, 100).Value = buscarTexto.Trim();

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
                throw new Exception("Error al listar asistencias: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Buscar(string valor, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return Listar(fechaInicio, fechaFin, null, null, null, null, valor);
        }

        public string Insertar(Asistencia obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    string checkSql = "SELECT COUNT(*) FROM iclock_transaction WHERE emp_code = @codigo AND punch_time = @fecha";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, sqlCon))
                    {
                        checkCmd.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        checkCmd.Parameters.Add("@fecha", NpgsqlDbType.Timestamp).Value = obj.FechaHora;
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            return "OK";
                        }
                    }

                    int? empId = null;
                    string findEmp = "SELECT id FROM personnel_employee WHERE emp_code::text = @codigo LIMIT 1";
                    using (NpgsqlCommand findCmd = new NpgsqlCommand(findEmp, sqlCon))
                    {
                        findCmd.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        object res = findCmd.ExecuteScalar();
                        if (res != null) empId = Convert.ToInt32(res);
                    }

                    string insertSql = @"
                        INSERT INTO iclock_transaction (
                            emp_code, punch_time, punch_state, verify_type, 
                            terminal_id, terminal_alias, upload_time, emp_id
                        ) VALUES (
                            @codigo, @fecha, @tipo::text, @metodo, 
                            @termId, @termAlias, NOW(), @empId
                        )";

                    using (NpgsqlCommand comando = new NpgsqlCommand(insertSql, sqlCon))
                    {
                        comando.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = obj.CodigoBiometrico.Trim();
                        comando.Parameters.Add("@fecha", NpgsqlDbType.Timestamp).Value = obj.FechaHora;
                        comando.Parameters.Add("@tipo", NpgsqlDbType.Varchar, 10).Value = obj.TipoMarcacion.ToString();
                        comando.Parameters.Add("@metodo", NpgsqlDbType.Integer).Value = obj.MetodoVerificacion;
                        comando.Parameters.Add("@termId", NpgsqlDbType.Integer).Value = obj.IdBiometrico.HasValue ? (object)obj.IdBiometrico.Value : DBNull.Value;
                        comando.Parameters.Add("@termAlias", NpgsqlDbType.Varchar, 100).Value = (object)obj.NombreBiometrico ?? DBNull.Value;
                        comando.Parameters.Add("@empId", NpgsqlDbType.Integer).Value = empId.HasValue ? (object)empId.Value : DBNull.Value;

                        int r = comando.ExecuteNonQuery();
                        if (r == 1)
                        {
                            respuesta = "OK";
                            RedisCacheService.Instancia.InvalidarPrefijo("asistencias");
                            RedisCacheService.Instancia.InvalidarPrefijo("dashboard");
                            RedisCacheService.Instancia.Publicar("asistencias:live", new
                            {
                                emp_code = obj.CodigoBiometrico,
                                fecha_hora = obj.FechaHora,
                                tipo = obj.TipoMarcacion,
                                metodo = obj.MetodoVerificacion,
                                reloj = obj.NombreBiometrico,
                                id_reloj = obj.IdBiometrico
                            });
                        }
                        else
                        {
                            respuesta = "No se pudo insertar la marcación.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public int InsertarMasivo(List<Asistencia> listaAsistencias, int? idBiometrico = null, string nombreBiometrico = null)
        {
            return InsertarMasivoConProgreso(listaAsistencias, idBiometrico, nombreBiometrico, null, System.Threading.CancellationToken.None);
        }

        public int InsertarMasivoConProgreso(List<Asistencia> listaAsistencias, int? idBiometrico, string nombreBiometrico, IProgress<ProgresoSync> progreso, System.Threading.CancellationToken ct)
        {
            if (listaAsistencias == null || listaAsistencias.Count == 0) return 0;

            int insertados = 0;
            int total = listaAsistencias.Count;
            int batchSize = 1000;

            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    string sql = @"
                        INSERT INTO iclock_transaction (
                            emp_code, punch_time, punch_state, verify_type, 
                            terminal_id, terminal_alias, upload_time, emp_id
                        ) 
                        SELECT @codigo, @fecha, @tipo::text, @metodo, 
                               @termId, @termAlias, NOW(), 
                               (SELECT id FROM personnel_employee WHERE emp_code::text = @codigo LIMIT 1)
                        WHERE NOT EXISTS (
                            SELECT 1 FROM iclock_transaction 
                            WHERE emp_code = @codigo AND punch_time = @fecha
                        )";

                    for (int i = 0; i < total; i += batchSize)
                    {
                        if (ct.IsCancellationRequested) break;

                        int countInBatch = Math.Min(batchSize, total - i);
                        using (NpgsqlTransaction trans = sqlCon.BeginTransaction())
                        {
                            try
                            {
                                for (int j = 0; j < countInBatch; j++)
                                {
                                    var item = listaAsistencias[i + j];
                                    using (NpgsqlCommand comando = new NpgsqlCommand(sql, sqlCon, trans))
                                    {
                                        int? termId = item.IdBiometrico ?? idBiometrico;
                                        string termAlias = item.NombreBiometrico ?? nombreBiometrico;

                                        comando.Parameters.Add("@codigo", NpgsqlDbType.Varchar, 50).Value = item.CodigoBiometrico.Trim();
                                        comando.Parameters.Add("@fecha", NpgsqlDbType.Timestamp).Value = item.FechaHora;
                                        comando.Parameters.Add("@tipo", NpgsqlDbType.Varchar, 10).Value = item.TipoMarcacion.ToString();
                                        comando.Parameters.Add("@metodo", NpgsqlDbType.Integer).Value = item.MetodoVerificacion;
                                        comando.Parameters.Add("@termId", NpgsqlDbType.Integer).Value = termId.HasValue ? (object)termId.Value : DBNull.Value;
                                        comando.Parameters.Add("@termAlias", NpgsqlDbType.Varchar, 100).Value = (object)termAlias ?? DBNull.Value;

                                        int r = comando.ExecuteNonQuery();
                                        if (r > 0) insertados++;
                                    }
                                }
                                trans.Commit();
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }

                        int procesados = Math.Min(i + countInBatch, total);
                        int pct = 50 + (int)((procesados / (double)total) * 50);
                        progreso?.Report(new ProgresoSync
                        {
                            Porcentaje = pct,
                            Fase = "Guardando en Base de Datos",
                            RegistrosActuales = procesados,
                            RegistrosTotales = total,
                            RegistrosNuevos = insertados,
                            RegistrosDuplicados = procesados - insertados,
                            NombreBiometrico = nombreBiometrico,
                            Estado = string.Format("Guardando en BD: {0:N0} de {1:N0} (Nuevos: {2:N0} | Existentes: {3:N0})", 
                                procesados, total, insertados, procesados - insertados)
                        });
                    }

                    RedisCacheService.Instancia.InvalidarPrefijo("asistencias");
                    RedisCacheService.Instancia.InvalidarPrefijo("dashboard");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar marcaciones masivas: " + ex.Message);
            }
            return insertados;
        }

        public int EliminarMarcacionesFuturas(DateTime desde)
        {
            int eliminados = 0;
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string sql = "DELETE FROM iclock_transaction WHERE punch_time >= @desde";
                    using (NpgsqlCommand comando = new NpgsqlCommand(sql, sqlCon))
                    {
                        comando.Parameters.Add("@desde", NpgsqlDbType.Timestamp).Value = desde;
                        sqlCon.Open();
                        eliminados = comando.ExecuteNonQuery();
                    }
                    RedisCacheService.Instancia.InvalidarPrefijo("asistencias");
                    RedisCacheService.Instancia.InvalidarPrefijo("dashboard");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar marcaciones: " + ex.Message);
            }
            return eliminados;
        }

        public DataSet ObtenerEstadisticasDashboard()
        {
            DataSet ds = new DataSet();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    string sqlPorDept = @"
                        SELECT COALESCE(d.dept_name, 'Sin Departamento') AS departamento,
                               COUNT(DISTINCT e.id) AS total_empleados,
                               COUNT(t.id) AS marcaciones_mes
                        FROM personnel_department d
                        LEFT JOIN personnel_employee e ON e.department_id = d.id 
                            AND COALESCE(e.deleted, false) = false 
                            AND COALESCE(e.is_active, true) = true 
                            AND COALESCE(e.enable_att, true) = true
                        LEFT JOIN iclock_transaction t ON t.emp_code = e.emp_code::text
                            AND t.punch_time >= date_trunc('month', CURRENT_DATE)
                            AND t.punch_time <= CURRENT_DATE + interval '1 day' - interval '1 second'
                        WHERE (e.id IS NOT NULL OR d.id IS NOT NULL)
                        GROUP BY d.dept_name
                        ORDER BY total_empleados DESC
                        LIMIT 10";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlPorDept, sqlCon))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable("PorDepartamento");
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                    }

                    string sqlPorDia = @"
                        SELECT TO_CHAR(punch_time, 'YYYY-MM-DD') AS dia,
                               COUNT(*) AS total
                        FROM iclock_transaction
                        WHERE punch_time >= CURRENT_DATE - interval '7 days'
                          AND punch_time <= CURRENT_DATE + interval '1 day' - interval '1 second'
                        GROUP BY TO_CHAR(punch_time, 'YYYY-MM-DD')
                        ORDER BY dia ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlPorDia, sqlCon))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable("PorDia");
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                    }

                    string sqlPorBiometrico = @"
                        SELECT COALESCE(t.terminal_alias, COALESCE(term.alias, 'Biométrico ' || t.terminal_id::text)) AS biometrico,
                               COUNT(*) AS total_marcaciones
                        FROM iclock_transaction t
                        LEFT JOIN iclock_terminal term ON t.terminal_id = term.id
                        WHERE t.punch_time >= date_trunc('month', CURRENT_DATE)
                          AND t.punch_time <= CURRENT_DATE + interval '1 day' - interval '1 second'
                        GROUP BY t.terminal_alias, term.alias, t.terminal_id
                        ORDER BY total_marcaciones DESC";

                    using (NpgsqlCommand cmd2 = new NpgsqlCommand(sqlPorBiometrico, sqlCon))
                    {
                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable("PorBiometrico");
                        da2.Fill(dt2);
                        ds.Tables.Add(dt2);
                    }

                    string sqlPorHora = @"
                        SELECT TO_CHAR(punch_time, 'HH24:00') AS hora,
                               COUNT(*) AS total
                        FROM iclock_transaction
                        WHERE punch_time::date = CURRENT_DATE
                        GROUP BY TO_CHAR(punch_time, 'HH24:00')
                        ORDER BY hora ASC";

                    using (NpgsqlCommand cmd3 = new NpgsqlCommand(sqlPorHora, sqlCon))
                    {
                        NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(cmd3);
                        DataTable dt3 = new DataTable("PorHora");
                        da3.Fill(dt3);
                        ds.Tables.Add(dt3);
                    }

                    string sqlResumen = @"
                        SELECT
                            (SELECT COUNT(*) FROM personnel_employee WHERE COALESCE(deleted, false) = false AND COALESCE(is_active, true) = true AND COALESCE(enable_att, true) = true) AS total_empleados,
                            (SELECT COUNT(*) FROM iclock_terminal WHERE status != 0) AS total_biometricos,
                            (SELECT COUNT(*) FROM iclock_transaction
                                WHERE punch_time::date = CURRENT_DATE) AS marcaciones_hoy,
                            (SELECT COUNT(*) FROM iclock_transaction
                                WHERE punch_time >= date_trunc('month', CURRENT_DATE)
                                  AND punch_time <= CURRENT_DATE + interval '1 day' - interval '1 second') AS marcaciones_mes,
                            (SELECT COUNT(*) FROM iclock_transaction
                                WHERE punch_time::date = CURRENT_DATE - 1) AS marcaciones_ayer";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlResumen, sqlCon))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable("Resumen");
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas: " + ex.Message);
            }
            return ds;
        }
    }
}
