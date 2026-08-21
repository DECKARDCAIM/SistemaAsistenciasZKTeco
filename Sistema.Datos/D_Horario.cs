using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Horario
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
                        -- 1. Tabla de Intervalos de Horario
                        CREATE TABLE IF NOT EXISTS att_timeinterval (
                            id SERIAL PRIMARY KEY,
                            alias VARCHAR(50) NOT NULL,
                            use_mode SMALLINT NOT NULL DEFAULT 1,
                            in_time TIME NOT NULL,
                            in_ahead_margin INTEGER NOT NULL DEFAULT 60,
                            in_above_margin INTEGER NOT NULL DEFAULT 120,
                            out_ahead_margin INTEGER NOT NULL DEFAULT 60,
                            out_above_margin INTEGER NOT NULL DEFAULT 120,
                            duration INTEGER NOT NULL DEFAULT 480,
                            in_required SMALLINT NOT NULL DEFAULT 1,
                            out_required SMALLINT NOT NULL DEFAULT 1,
                            allow_late INTEGER NOT NULL DEFAULT 5,
                            allow_leave_early INTEGER NOT NULL DEFAULT 5,
                            work_day DOUBLE PRECISION NOT NULL DEFAULT 1.0,
                            early_in SMALLINT NOT NULL DEFAULT 0,
                            min_early_in INTEGER NOT NULL DEFAULT 0,
                            late_out SMALLINT NOT NULL DEFAULT 0,
                            min_late_out INTEGER NOT NULL DEFAULT 0,
                            overtime_lv SMALLINT NOT NULL DEFAULT 0,
                            overtime_lv1 SMALLINT NOT NULL DEFAULT 0,
                            overtime_lv2 SMALLINT NOT NULL DEFAULT 0,
                            overtime_lv3 SMALLINT NOT NULL DEFAULT 0,
                            multiple_punch SMALLINT NOT NULL DEFAULT 0,
                            available_interval_type SMALLINT NOT NULL DEFAULT 0,
                            available_interval INTEGER NOT NULL DEFAULT 0,
                            work_time_duration INTEGER NOT NULL DEFAULT 480,
                            func_key SMALLINT NOT NULL DEFAULT 0,
                            work_type SMALLINT NOT NULL DEFAULT 0,
                            day_change TIME NOT NULL DEFAULT '00:00:00',
                            use_24_mode SMALLINT NOT NULL DEFAULT 0,
                            change_time TIMESTAMP WITH TIME ZONE NULL,
                            change_user VARCHAR(150) NULL,
                            company_id INTEGER NULL,
                            create_time TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
                            create_user VARCHAR(150) NULL,
                            status SMALLINT NOT NULL DEFAULT 1
                        );

                        -- 2. Tabla de Turnos
                        CREATE TABLE IF NOT EXISTS att_attshift (
                            id SERIAL PRIMARY KEY,
                            alias VARCHAR(50) NOT NULL,
                            cycle_unit SMALLINT NOT NULL DEFAULT 1, -- 1=Semanal, 0=Diario
                            shift_cycle INTEGER NOT NULL DEFAULT 1,
                            work_weekend BOOLEAN NOT NULL DEFAULT FALSE,
                            weekend_type SMALLINT NOT NULL DEFAULT 0,
                            work_day_off BOOLEAN NOT NULL DEFAULT FALSE,
                            day_off_type SMALLINT NOT NULL DEFAULT 0,
                            auto_shift BOOLEAN NOT NULL DEFAULT FALSE,
                            change_time TIMESTAMP WITH TIME ZONE NULL,
                            change_user VARCHAR(150) NULL,
                            company_id INTEGER NULL,
                            create_time TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
                            create_user VARCHAR(150) NULL,
                            status SMALLINT NOT NULL DEFAULT 1
                        );

                        -- 3. Tabla de Detalles de Turno (días de la semana)
                        CREATE TABLE IF NOT EXISTS att_shiftdetail (
                            id SERIAL PRIMARY KEY,
                            in_time TIME NOT NULL,
                            out_time TIME NOT NULL,
                            day_index INTEGER NOT NULL, -- 0=Lun, 1=Mar, 2=Mie, 3=Jue, 4=Vie, 5=Sab, 6=Dom
                            shift_id INTEGER NOT NULL,
                            time_interval_id INTEGER NULL,
                            CONSTRAINT fk_shiftdetail_shift FOREIGN KEY (shift_id) REFERENCES att_attshift(id) ON DELETE CASCADE
                        );

                        -- 4. Asignación de Horario por Empleado
                        CREATE TABLE IF NOT EXISTS att_attschedule (
                            id SERIAL PRIMARY KEY,
                            start_date DATE NOT NULL,
                            end_date DATE NOT NULL,
                            employee_id INTEGER NOT NULL,
                            shift_id INTEGER NOT NULL,
                            CONSTRAINT fk_schedule_employee FOREIGN KEY (employee_id) REFERENCES personnel_employee(id) ON DELETE CASCADE,
                            CONSTRAINT fk_schedule_shift FOREIGN KEY (shift_id) REFERENCES att_attshift(id) ON DELETE CASCADE
                        );

                        -- 5. Asignación de Horario por Departamento
                        CREATE TABLE IF NOT EXISTS att_departmentschedule (
                            id SERIAL PRIMARY KEY,
                            create_time TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
                            create_user VARCHAR(150) NULL,
                            change_time TIMESTAMP WITH TIME ZONE NULL,
                            change_user VARCHAR(150) NULL,
                            status SMALLINT NOT NULL DEFAULT 1,
                            start_date DATE NOT NULL,
                            end_date DATE NOT NULL,
                            department_id INTEGER NOT NULL,
                            shift_id INTEGER NOT NULL,
                            CONSTRAINT fk_deptschedule_dept FOREIGN KEY (department_id) REFERENCES personnel_department(id) ON DELETE CASCADE,
                            CONSTRAINT fk_deptschedule_shift FOREIGN KEY (shift_id) REFERENCES att_attshift(id) ON DELETE CASCADE
                        );

                        -- Intervalo por defecto si la tabla está vacía
                        INSERT INTO att_timeinterval (alias, in_time, duration, work_time_duration, allow_late, allow_leave_early, in_ahead_margin, in_above_margin, out_ahead_margin, out_above_margin)
                        SELECT 'Horario Regular 08:00 - 17:00', '08:00:00', 480, 480, 5, 5, 60, 120, 60, 120
                        WHERE NOT EXISTS (SELECT 1 FROM att_timeinterval);

                        -- Turno por defecto si la tabla está vacía
                        DO $$
                        DECLARE
                            v_shift_id INT;
                            v_interval_id INT;
                        BEGIN
                            IF NOT EXISTS (SELECT 1 FROM att_attshift) THEN
                                INSERT INTO att_attshift (alias, cycle_unit, shift_cycle, work_weekend, status)
                                VALUES ('Turno Lunes a Viernes 08:00-17:00', 1, 1, FALSE, 1)
                                RETURNING id INTO v_shift_id;

                                SELECT id INTO v_interval_id FROM att_timeinterval LIMIT 1;

                                IF v_shift_id IS NOT NULL AND v_interval_id IS NOT NULL THEN
                                    -- Insertar días Lunes a Viernes (0 a 4)
                                    FOR d IN 0..4 LOOP
                                        INSERT INTO att_shiftdetail (in_time, out_time, day_index, shift_id, time_interval_id)
                                        VALUES ('08:00:00', '17:00:00', d, v_shift_id, v_interval_id);
                                    END LOOP;
                                END IF;
                            END IF;
                        END $$;
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

        #region =================== 1. INTERVALOS DE HORARIO (att_timeinterval) ===================

        public DataTable ListarIntervalos()
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idintervalo, 
                               alias AS nombre, 
                               in_time AS hora_entrada, 
                               (in_time + (duration || ' minutes')::interval)::time AS hora_salida,
                               allow_late AS tolerancia_entrada_min, 
                               allow_leave_early AS tolerancia_salida_min, 
                               in_ahead_margin AS margen_antes_entrada, 
                               in_above_margin AS margen_despues_entrada, 
                               out_ahead_margin AS margen_antes_salida, 
                               out_above_margin AS margen_despues_salida, 
                               duration AS duracion_minutos,
                               ROUND((duration / 60.0)::numeric, 2) AS duracion_horas,
                               work_day AS dias_computados,
                               in_required AS entrada_obligatoria,
                               out_required AS salida_obligatoria,
                               status AS estado
                        FROM att_timeinterval
                        WHERE COALESCE(status, 0) != -1
                        ORDER BY in_time ASC, id ASC";

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

        public DataTable BuscarIntervalos(string valor)
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idintervalo, 
                               alias AS nombre, 
                               in_time AS hora_entrada, 
                               (in_time + (duration || ' minutes')::interval)::time AS hora_salida,
                               allow_late AS tolerancia_entrada_min, 
                               allow_leave_early AS tolerancia_salida_min, 
                               in_ahead_margin AS margen_antes_entrada, 
                               in_above_margin AS margen_despues_entrada, 
                               out_ahead_margin AS margen_antes_salida, 
                               out_above_margin AS margen_despues_salida, 
                               duration AS duracion_minutos,
                               ROUND((duration / 60.0)::numeric, 2) AS duracion_horas,
                               work_day AS dias_computados,
                               in_required AS entrada_obligatoria,
                               out_required AS salida_obligatoria,
                               status AS estado
                        FROM att_timeinterval
                        WHERE COALESCE(status, 0) != -1 AND alias ILIKE @valor
                        ORDER BY in_time ASC, id ASC";

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
                throw new Exception("Error al buscar intervalos de horario: " + ex.Message);
            }
            return tabla;
        }

        public DataTable SeleccionarIntervalos()
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT id AS idintervalo, 
                               (alias || ' (' || in_time::text || ' - ' || (in_time + (duration || ' minutes')::interval)::time::text || ')') AS nombre_completo,
                               alias AS nombre,
                               in_time AS hora_entrada,
                               (in_time + (duration || ' minutes')::interval)::time AS hora_salida,
                               duration
                        FROM att_timeinterval
                        WHERE COALESCE(status, 0) != -1
                        ORDER BY in_time ASC, alias ASC";

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
                throw new Exception("Error al seleccionar intervalos: " + ex.Message);
            }
            return tabla;
        }

        public string InsertarIntervalo(IntervaloHorario obj)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    // Calcular duración en minutos entre entrada y salida
                    TimeSpan entrada = obj.InTime;
                    TimeSpan salida = obj.OutTime;
                    int duracionMin = (int)(salida >= entrada ? (salida - entrada).TotalMinutes : (TimeSpan.FromHours(24) - entrada + salida).TotalMinutes);
                    if (duracionMin <= 0) duracionMin = 480;

                    string consulta = @"
                        INSERT INTO att_timeinterval (
                            alias, in_time, duration, work_time_duration, 
                            allow_late, allow_leave_early, 
                            in_ahead_margin, in_above_margin, 
                            out_ahead_margin, out_above_margin, 
                            work_day, in_required, out_required, status
                        )
                        VALUES (
                            @alias, @in_time, @duration, @work_time_duration,
                            @allow_late, @allow_leave_early,
                            @in_ahead_margin, @in_above_margin,
                            @out_ahead_margin, @out_above_margin,
                            @work_day, @in_required, @out_required, 1
                        )
                        RETURNING id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@alias", obj.Alias.Trim());
                        comando.Parameters.AddWithValue("@in_time", obj.InTime);
                        comando.Parameters.AddWithValue("@duration", duracionMin);
                        comando.Parameters.AddWithValue("@work_time_duration", duracionMin);
                        comando.Parameters.AddWithValue("@allow_late", obj.AllowLate);
                        comando.Parameters.AddWithValue("@allow_leave_early", obj.AllowLeaveEarly);
                        comando.Parameters.AddWithValue("@in_ahead_margin", obj.InAheadMargin);
                        comando.Parameters.AddWithValue("@in_above_margin", obj.InAboveMargin);
                        comando.Parameters.AddWithValue("@out_ahead_margin", obj.OutAheadMargin);
                        comando.Parameters.AddWithValue("@out_above_margin", obj.OutAboveMargin);
                        comando.Parameters.AddWithValue("@work_day", obj.WorkDay);
                        comando.Parameters.AddWithValue("@in_required", obj.InRequired);
                        comando.Parameters.AddWithValue("@out_required", obj.OutRequired);

                        sqlCon.Open();
                        obj.IdIntervalo = Convert.ToInt32(comando.ExecuteScalar());
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

        public string ActualizarIntervalo(IntervaloHorario obj)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    TimeSpan entrada = obj.InTime;
                    TimeSpan salida = obj.OutTime;
                    int duracionMin = (int)(salida >= entrada ? (salida - entrada).TotalMinutes : (TimeSpan.FromHours(24) - entrada + salida).TotalMinutes);
                    if (duracionMin <= 0) duracionMin = 480;

                    string consulta = @"
                        UPDATE att_timeinterval 
                        SET alias = @alias, 
                            in_time = @in_time, 
                            duration = @duration, 
                            work_time_duration = @work_time_duration,
                            allow_late = @allow_late, 
                            allow_leave_early = @allow_leave_early, 
                            in_ahead_margin = @in_ahead_margin, 
                            in_above_margin = @in_above_margin, 
                            out_ahead_margin = @out_ahead_margin, 
                            out_above_margin = @out_above_margin,
                            work_day = @work_day,
                            in_required = @in_required,
                            out_required = @out_required,
                            change_time = NOW()
                        WHERE id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", obj.IdIntervalo);
                        comando.Parameters.AddWithValue("@alias", obj.Alias.Trim());
                        comando.Parameters.AddWithValue("@in_time", obj.InTime);
                        comando.Parameters.AddWithValue("@duration", duracionMin);
                        comando.Parameters.AddWithValue("@work_time_duration", duracionMin);
                        comando.Parameters.AddWithValue("@allow_late", obj.AllowLate);
                        comando.Parameters.AddWithValue("@allow_leave_early", obj.AllowLeaveEarly);
                        comando.Parameters.AddWithValue("@in_ahead_margin", obj.InAheadMargin);
                        comando.Parameters.AddWithValue("@in_above_margin", obj.InAboveMargin);
                        comando.Parameters.AddWithValue("@out_ahead_margin", obj.OutAheadMargin);
                        comando.Parameters.AddWithValue("@out_above_margin", obj.OutAboveMargin);
                        comando.Parameters.AddWithValue("@work_day", obj.WorkDay);
                        comando.Parameters.AddWithValue("@in_required", obj.InRequired);
                        comando.Parameters.AddWithValue("@out_required", obj.OutRequired);

                        sqlCon.Open();
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró el intervalo a actualizar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string EliminarIntervalo(int id)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    // Verificar si está en uso por algún turno
                    using (NpgsqlCommand check = new NpgsqlCommand("SELECT COUNT(1) FROM att_shiftdetail WHERE time_interval_id = @id", sqlCon))
                    {
                        check.Parameters.AddWithValue("@id", id);
                        long count = Convert.ToInt64(check.ExecuteScalar());
                        if (count > 0)
                        {
                            return "No se puede eliminar el intervalo porque está configurado en uno o más turnos de trabajo.";
                        }
                    }

                    using (NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM att_timeinterval WHERE id = @id", sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró el intervalo a eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        #endregion

        #region =================== 2. TURNOS DE TRABAJO (att_attshift & att_shiftdetail) ===================

        public DataTable ListarTurnos()
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT s.id AS idturno, 
                               s.alias AS nombre_turno, 
                               s.cycle_unit AS unidad_ciclo, 
                               s.shift_cycle AS ciclo, 
                               s.work_weekend AS trabaja_fin_semana,
                               COUNT(DISTINCT sch.employee_id) AS total_empleados_asignados,
                               COUNT(DISTINCT dsch.department_id) AS total_departamentos_asignados
                        FROM att_attshift s
                        LEFT JOIN att_attschedule sch ON s.id = sch.shift_id
                        LEFT JOIN att_departmentschedule dsch ON s.id = dsch.shift_id
                        WHERE COALESCE(s.status, 0) != -1
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

        public DataTable BuscarTurnos(string valor)
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT s.id AS idturno, 
                               s.alias AS nombre_turno, 
                               s.cycle_unit AS unidad_ciclo, 
                               s.shift_cycle AS ciclo, 
                               s.work_weekend AS trabaja_fin_semana,
                               COUNT(DISTINCT sch.employee_id) AS total_empleados_asignados,
                               COUNT(DISTINCT dsch.department_id) AS total_departamentos_asignados
                        FROM att_attshift s
                        LEFT JOIN att_attschedule sch ON s.id = sch.shift_id
                        LEFT JOIN att_departmentschedule dsch ON s.id = dsch.shift_id
                        WHERE COALESCE(s.status, 0) != -1 AND s.alias ILIKE @valor
                        GROUP BY s.id, s.alias, s.cycle_unit, s.shift_cycle, s.work_weekend
                        ORDER BY s.id ASC";

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
                throw new Exception("Error al buscar turnos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable SeleccionarTurnos()
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "SELECT id AS idturno, alias AS nombre, (alias || ' (Turno)') AS nombre_completo FROM att_attshift WHERE COALESCE(status, 0) != -1 ORDER BY alias ASC";
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

        public DataTable ObtenerDetallesTurno(int idTurno)
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT sd.id AS iddetalle,
                               sd.shift_id,
                               sd.day_index,
                               CASE sd.day_index
                                   WHEN 0 THEN 'Lunes'
                                   WHEN 1 THEN 'Martes'
                                   WHEN 2 THEN 'Miércoles'
                                   WHEN 3 THEN 'Jueves'
                                   WHEN 4 THEN 'Viernes'
                                   WHEN 5 THEN 'Sábado'
                                   WHEN 6 THEN 'Domingo'
                                   ELSE 'Día ' || sd.day_index
                               END AS dia_nombre,
                               sd.time_interval_id,
                               COALESCE(ti.alias, 'Descanso / Libre') AS intervalo_alias,
                               sd.in_time AS hora_entrada,
                               sd.out_time AS hora_salida
                        FROM att_shiftdetail sd
                        LEFT JOIN att_timeinterval ti ON sd.time_interval_id = ti.id
                        WHERE sd.shift_id = @shift_id
                        ORDER BY sd.day_index ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@shift_id", idTurno);
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
                throw new Exception("Error al obtener detalles del turno: " + ex.Message);
            }
            return tabla;
        }

        public string GuardarTurnoConDetalles(Turno turno, List<DetalleTurno> detalles)
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
                        int shiftId = turno.IdTurno;

                        if (shiftId <= 0)
                        {
                            // Inserción de Turno
                            string sqlShift = @"
                                INSERT INTO att_attshift (alias, cycle_unit, shift_cycle, work_weekend, status, create_time)
                                VALUES (@alias, @cycle_unit, @shift_cycle, @work_weekend, 1, NOW())
                                RETURNING id";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlShift, sqlCon, trans))
                            {
                                cmd.Parameters.AddWithValue("@alias", turno.Alias.Trim());
                                cmd.Parameters.AddWithValue("@cycle_unit", turno.CycleUnit);
                                cmd.Parameters.AddWithValue("@shift_cycle", turno.ShiftCycle);
                                cmd.Parameters.AddWithValue("@work_weekend", turno.WorkWeekend);
                                shiftId = Convert.ToInt32(cmd.ExecuteScalar());
                                turno.IdTurno = shiftId;
                            }
                        }
                        else
                        {
                            // Actualización de Turno
                            string sqlUpdateShift = @"
                                UPDATE att_attshift 
                                SET alias = @alias, 
                                    cycle_unit = @cycle_unit, 
                                    shift_cycle = @shift_cycle, 
                                    work_weekend = @work_weekend,
                                    change_time = NOW()
                                WHERE id = @id";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlUpdateShift, sqlCon, trans))
                            {
                                cmd.Parameters.AddWithValue("@id", shiftId);
                                cmd.Parameters.AddWithValue("@alias", turno.Alias.Trim());
                                cmd.Parameters.AddWithValue("@cycle_unit", turno.CycleUnit);
                                cmd.Parameters.AddWithValue("@shift_cycle", turno.ShiftCycle);
                                cmd.Parameters.AddWithValue("@work_weekend", turno.WorkWeekend);
                                cmd.ExecuteNonQuery();
                            }

                            // Eliminar detalles previos para reinsertar
                            using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_shiftdetail WHERE shift_id = @shift_id", sqlCon, trans))
                            {
                                cmdDel.Parameters.AddWithValue("@shift_id", shiftId);
                                cmdDel.ExecuteNonQuery();
                            }
                        }

                        // Insertar detalles de cada día
                        if (detalles != null && detalles.Count > 0)
                        {
                            string sqlDetail = @"
                                INSERT INTO att_shiftdetail (shift_id, time_interval_id, day_index, in_time, out_time)
                                VALUES (@shift_id, @time_interval_id, @day_index, @in_time, @out_time)";

                            foreach (var d in detalles)
                            {
                                if (d.TimeIntervalId.HasValue && d.TimeIntervalId.Value > 0)
                                {
                                    using (NpgsqlCommand cmdDetail = new NpgsqlCommand(sqlDetail, sqlCon, trans))
                                    {
                                        cmdDetail.Parameters.AddWithValue("@shift_id", shiftId);
                                        cmdDetail.Parameters.AddWithValue("@time_interval_id", d.TimeIntervalId.Value);
                                        cmdDetail.Parameters.AddWithValue("@day_index", d.DayIndex);
                                        cmdDetail.Parameters.AddWithValue("@in_time", d.InTime);
                                        cmdDetail.Parameters.AddWithValue("@out_time", d.OutTime);
                                        cmdDetail.ExecuteNonQuery();
                                    }
                                }
                            }
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

        public string EliminarTurno(int idTurno)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    // Verificar asignaciones
                    using (NpgsqlCommand check = new NpgsqlCommand("SELECT COUNT(1) FROM att_attschedule WHERE shift_id = @id", sqlCon))
                    {
                        check.Parameters.AddWithValue("@id", idTurno);
                        long count = Convert.ToInt64(check.ExecuteScalar());
                        if (count > 0)
                        {
                            return "No se puede eliminar el turno porque tiene empleados asignados activamente.";
                        }
                    }

                    // Eliminar detalles y turno
                    using (NpgsqlCommand cmdDelDet = new NpgsqlCommand("DELETE FROM att_shiftdetail WHERE shift_id = @id", sqlCon))
                    {
                        cmdDelDet.Parameters.AddWithValue("@id", idTurno);
                        cmdDelDet.ExecuteNonQuery();
                    }

                    using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_attshift WHERE id = @id", sqlCon))
                    {
                        cmdDel.Parameters.AddWithValue("@id", idTurno);
                        int filas = cmdDel.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró el turno a eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        #endregion

        #region =================== 3. ASIGNACIONES DE HORARIOS (att_attschedule & att_departmentschedule) ===================

        public DataTable ListarHorariosEmpleados()
        {
            return BuscarHorariosEmpleados("", 0, 0);
        }

        public DataTable BuscarHorariosEmpleados(string valor, int idDept = 0, int idTurno = 0)
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT s.id AS idasignacion, 
                               e.id AS idempleado,
                               e.emp_code::text AS codigo_empleado, 
                               (COALESCE(e.first_name, '') || ' ' || COALESCE(e.last_name, '')) AS nombre_empleado,
                               e.department_id AS iddepartamento,
                               COALESCE(d.dept_name, 'General') AS departamento,
                               s.shift_id AS idturno,
                               COALESCE(sh.alias, '--- Sin Horario Asignado ---') AS turno,
                               s.start_date AS fecha_inicio, 
                               s.end_date AS fecha_fin
                        FROM personnel_employee e
                        LEFT JOIN (
                            SELECT DISTINCT ON (employee_id) id, employee_id, shift_id, start_date, end_date
                            FROM att_attschedule
                            ORDER BY employee_id, start_date DESC, id DESC
                        ) s ON e.id = s.employee_id
                        LEFT JOIN personnel_department d ON e.department_id = d.id
                        LEFT JOIN att_attshift sh ON s.shift_id = sh.id
                        WHERE COALESCE(e.deleted, false) = false
                          AND (@valor = '' OR e.emp_code::text ILIKE @valor OR e.first_name ILIKE @valor OR e.last_name ILIKE @valor)
                          AND (@idDept = 0 OR e.department_id = @idDept)
                          AND (@idTurno = 0 OR s.shift_id = @idTurno)
                        ORDER BY e.emp_code ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@valor", string.IsNullOrWhiteSpace(valor) ? "" : "%" + valor.Trim() + "%");
                        comando.Parameters.AddWithValue("@idDept", idDept);
                        comando.Parameters.AddWithValue("@idTurno", idTurno);
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
                throw new Exception("Error al buscar horarios de empleados: " + ex.Message);
            }
            return tabla;
        }

        public string AsignarHorarioEmpleado(int idEmpleado, int idTurno, DateTime fechaInicio, DateTime fechaFin)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();

                    // Eliminar o ajustar asignaciones existentes para este empleado
                    using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_attschedule WHERE employee_id = @emp_id", sqlCon))
                    {
                        cmdDel.Parameters.AddWithValue("@emp_id", idEmpleado);
                        cmdDel.ExecuteNonQuery();
                    }

                    string consulta = @"
                        INSERT INTO att_attschedule (employee_id, shift_id, start_date, end_date)
                        VALUES (@employee_id, @shift_id, @start_date, @end_date)
                        RETURNING id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@employee_id", idEmpleado);
                        comando.Parameters.AddWithValue("@shift_id", idTurno);
                        comando.Parameters.AddWithValue("@start_date", fechaInicio.Date);
                        comando.Parameters.AddWithValue("@end_date", fechaFin.Date);

                        comando.ExecuteScalar();
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

        public string AsignarHorarioMasivo(List<int> idsEmpleados, int idTurno, DateTime fechaInicio, DateTime fechaFin)
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
                        foreach (int empId in idsEmpleados)
                        {
                            using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_attschedule WHERE employee_id = @emp_id", sqlCon, trans))
                            {
                                cmdDel.Parameters.AddWithValue("@emp_id", empId);
                                cmdDel.ExecuteNonQuery();
                            }

                            string consulta = @"
                                INSERT INTO att_attschedule (employee_id, shift_id, start_date, end_date)
                                VALUES (@employee_id, @shift_id, @start_date, @end_date)";

                            using (NpgsqlCommand cmdIns = new NpgsqlCommand(consulta, sqlCon, trans))
                            {
                                cmdIns.Parameters.AddWithValue("@employee_id", empId);
                                cmdIns.Parameters.AddWithValue("@shift_id", idTurno);
                                cmdIns.Parameters.AddWithValue("@start_date", fechaInicio.Date);
                                cmdIns.Parameters.AddWithValue("@end_date", fechaFin.Date);
                                cmdIns.ExecuteNonQuery();
                            }
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

        public string EliminarAsignacionEmpleado(int idAsignacion)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "DELETE FROM att_attschedule WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", idAsignacion);
                        sqlCon.Open();
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró la asignación a eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public DataTable ListarAsignacionesDepartamentos(string valor = "")
        {
            GarantizarTablas();
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT ds.id AS idasignacion_dept,
                               d.id AS iddepartamento,
                               d.dept_code AS codigo_departamento,
                               d.dept_name AS departamento,
                               s.id AS idturno,
                               COALESCE(s.alias, '--- Sin Horario Asignado ---') AS turno,
                               ds.start_date AS fecha_inicio,
                               ds.end_date AS fecha_fin,
                               COUNT(e.id) AS total_empleados
                        FROM personnel_department d
                        LEFT JOIN (
                            SELECT DISTINCT ON (department_id) id, department_id, shift_id, start_date, end_date
                            FROM att_departmentschedule
                            ORDER BY department_id, start_date DESC, id DESC
                        ) ds ON d.id = ds.department_id
                        LEFT JOIN att_attshift s ON ds.shift_id = s.id
                        LEFT JOIN personnel_employee e ON e.department_id = d.id AND COALESCE(e.deleted, false) = false
                        WHERE (@valor = '' OR d.dept_name ILIKE @valor OR d.dept_code ILIKE @valor)
                        GROUP BY ds.id, d.id, d.dept_code, d.dept_name, s.id, s.alias, ds.start_date, ds.end_date
                        ORDER BY d.dept_name ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@valor", string.IsNullOrWhiteSpace(valor) ? "" : "%" + valor.Trim() + "%");
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
                throw new Exception("Error al listar asignaciones por departamento: " + ex.Message);
            }
            return tabla;
        }

        public string DesasignarTurnoEmpleado(int idEmpleado)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();
                    using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_attschedule WHERE employee_id = @emp_id", sqlCon))
                    {
                        cmdDel.Parameters.AddWithValue("@emp_id", idEmpleado);
                        cmdDel.ExecuteNonQuery();
                    }
                    rpta = "OK";
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string DesasignarTurnoDepartamento(int idDepartamento)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    sqlCon.Open();
                    using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_departmentschedule WHERE department_id = @dept_id", sqlCon))
                    {
                        cmdDel.Parameters.AddWithValue("@dept_id", idDepartamento);
                        cmdDel.ExecuteNonQuery();
                    }
                    rpta = "OK";
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string AsignarHorarioDepartamento(int idDepartamento, int idTurno, DateTime fechaInicio, DateTime fechaFin, bool sincronizarEmpleados = true)
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
                        // 1. Eliminar asignación previa del departamento
                        using (NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM att_departmentschedule WHERE department_id = @dept_id", sqlCon, trans))
                        {
                            cmdDel.Parameters.AddWithValue("@dept_id", idDepartamento);
                            cmdDel.ExecuteNonQuery();
                        }

                        // 2. Insertar nueva asignación departamental
                        string sqlInsDept = @"
                            INSERT INTO att_departmentschedule (department_id, shift_id, start_date, end_date, status, create_time)
                            VALUES (@department_id, @shift_id, @start_date, @end_date, 1, NOW())";

                        using (NpgsqlCommand cmdIns = new NpgsqlCommand(sqlInsDept, sqlCon, trans))
                        {
                            cmdIns.Parameters.AddWithValue("@department_id", idDepartamento);
                            cmdIns.Parameters.AddWithValue("@shift_id", idTurno);
                            cmdIns.Parameters.AddWithValue("@start_date", fechaInicio.Date);
                            cmdIns.Parameters.AddWithValue("@end_date", fechaFin.Date);
                            cmdIns.ExecuteNonQuery();
                        }

                        // 3. Si se solicita sincronizar empleados del departamento
                        if (sincronizarEmpleados)
                        {
                            string sqlSync = @"
                                -- Eliminar asignaciones previas de los empleados de este departamento
                                DELETE FROM att_attschedule 
                                WHERE employee_id IN (
                                    SELECT id FROM personnel_employee 
                                    WHERE department_id = @department_id AND COALESCE(deleted, false) = false
                                );

                                -- Insertar nueva asignación para todos los empleados de este departamento
                                INSERT INTO att_attschedule (employee_id, shift_id, start_date, end_date)
                                SELECT id, @shift_id, @start_date, @end_date
                                FROM personnel_employee
                                WHERE department_id = @department_id AND COALESCE(deleted, false) = false;";

                            using (NpgsqlCommand cmdSync = new NpgsqlCommand(sqlSync, sqlCon, trans))
                            {
                                cmdSync.Parameters.AddWithValue("@department_id", idDepartamento);
                                cmdSync.Parameters.AddWithValue("@shift_id", idTurno);
                                cmdSync.Parameters.AddWithValue("@start_date", fechaInicio.Date);
                                cmdSync.Parameters.AddWithValue("@end_date", fechaFin.Date);
                                cmdSync.ExecuteNonQuery();
                            }
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

        public string EliminarAsignacionDepartamento(int idAsignacion)
        {
            GarantizarTablas();
            string rpta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "DELETE FROM att_departmentschedule WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.AddWithValue("@id", idAsignacion);
                        sqlCon.Open();
                        int filas = comando.ExecuteNonQuery();
                        rpta = filas > 0 ? "OK" : "No se encontró la asignación departamental a eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        #endregion
    }
}

