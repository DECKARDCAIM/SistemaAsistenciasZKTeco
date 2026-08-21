using System;
using System.Collections.Generic;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Horario
    {
        #region =================== 1. INTERVALOS DE HORARIO ===================

        public static DataTable ListarIntervalos()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarIntervalos();
        }

        public static DataTable BuscarIntervalos(string valor)
        {
            D_Horario datos = new D_Horario();
            return datos.BuscarIntervalos(valor);
        }

        public static DataTable SeleccionarIntervalos()
        {
            D_Horario datos = new D_Horario();
            return datos.SeleccionarIntervalos();
        }

        public static string InsertarIntervalo(string alias, TimeSpan inTime, TimeSpan outTime, int allowLate = 5, int allowLeaveEarly = 5, int inAheadMargin = 60, int inAboveMargin = 120, int outAheadMargin = 60, int outAboveMargin = 120, double workDay = 1.0, int inRequired = 1, int outRequired = 1)
        {
            if (string.IsNullOrWhiteSpace(alias))
                return "El nombre / alias del intervalo de horario es obligatorio.";

            D_Horario datos = new D_Horario();
            IntervaloHorario obj = new IntervaloHorario
            {
                Alias = alias.Trim(),
                InTime = inTime,
                OutTime = outTime,
                AllowLate = allowLate,
                AllowLeaveEarly = allowLeaveEarly,
                InAheadMargin = inAheadMargin,
                InAboveMargin = inAboveMargin,
                OutAheadMargin = outAheadMargin,
                OutAboveMargin = outAboveMargin,
                WorkDay = workDay,
                InRequired = inRequired,
                OutRequired = outRequired
            };
            return datos.InsertarIntervalo(obj);
        }

        public static string ActualizarIntervalo(int id, string alias, TimeSpan inTime, TimeSpan outTime, int allowLate = 5, int allowLeaveEarly = 5, int inAheadMargin = 60, int inAboveMargin = 120, int outAheadMargin = 60, int outAboveMargin = 120, double workDay = 1.0, int inRequired = 1, int outRequired = 1)
        {
            if (id <= 0)
                return "Identificador de intervalo inválido.";

            if (string.IsNullOrWhiteSpace(alias))
                return "El nombre / alias del intervalo de horario es obligatorio.";

            D_Horario datos = new D_Horario();
            IntervaloHorario obj = new IntervaloHorario
            {
                IdIntervalo = id,
                Alias = alias.Trim(),
                InTime = inTime,
                OutTime = outTime,
                AllowLate = allowLate,
                AllowLeaveEarly = allowLeaveEarly,
                InAheadMargin = inAheadMargin,
                InAboveMargin = inAboveMargin,
                OutAheadMargin = outAheadMargin,
                OutAboveMargin = outAboveMargin,
                WorkDay = workDay,
                InRequired = inRequired,
                OutRequired = outRequired
            };
            return datos.ActualizarIntervalo(obj);
        }

        public static string EliminarIntervalo(int id)
        {
            if (id <= 0)
                return "Identificador de intervalo inválido.";

            D_Horario datos = new D_Horario();
            return datos.EliminarIntervalo(id);
        }

        #endregion

        #region =================== 2. TURNOS DE TRABAJO ===================

        public static DataTable ListarTurnos()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarTurnos();
        }

        public static DataTable BuscarTurnos(string valor)
        {
            D_Horario datos = new D_Horario();
            return datos.BuscarTurnos(valor);
        }

        public static DataTable SeleccionarTurnos()
        {
            D_Horario datos = new D_Horario();
            return datos.SeleccionarTurnos();
        }

        public static DataTable ObtenerDetallesTurno(int idTurno)
        {
            if (idTurno <= 0)
                return new DataTable();

            D_Horario datos = new D_Horario();
            return datos.ObtenerDetallesTurno(idTurno);
        }

        public static string GuardarTurnoConDetalles(int idTurno, string alias, bool trabajaFinSemana, List<DetalleTurno> detalles)
        {
            if (string.IsNullOrWhiteSpace(alias))
                return "El nombre del turno es obligatorio.";

            if (detalles == null || detalles.Count == 0)
                return "Debe configurar los días del turno.";

            Turno turno = new Turno
            {
                IdTurno = idTurno,
                Alias = alias.Trim(),
                CycleUnit = 1, // Semanal
                ShiftCycle = 1,
                WorkWeekend = trabajaFinSemana
            };

            D_Horario datos = new D_Horario();
            return datos.GuardarTurnoConDetalles(turno, detalles);
        }

        public static string EliminarTurno(int idTurno)
        {
            if (idTurno <= 0)
                return "Identificador de turno inválido.";

            D_Horario datos = new D_Horario();
            return datos.EliminarTurno(idTurno);
        }

        #endregion

        #region =================== 3. ASIGNACIONES DE HORARIOS ===================

        public static DataTable ListarHorariosEmpleados()
        {
            D_Horario datos = new D_Horario();
            return datos.ListarHorariosEmpleados();
        }

        public static DataTable BuscarHorariosEmpleados(string valor, int idDept = 0, int idTurno = 0)
        {
            D_Horario datos = new D_Horario();
            return datos.BuscarHorariosEmpleados(valor, idDept, idTurno);
        }

        public static string AsignarHorarioEmpleado(int idEmpleado, int idTurno, DateTime fechaInicio, DateTime fechaFin)
        {
            if (idEmpleado <= 0)
                return "Seleccione un empleado válido.";

            if (idTurno <= 0)
                return "Seleccione un turno válido.";

            if (fechaFin < fechaInicio)
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";

            D_Horario datos = new D_Horario();
            return datos.AsignarHorarioEmpleado(idEmpleado, idTurno, fechaInicio, fechaFin);
        }

        public static string AsignarHorarioMasivo(List<int> idsEmpleados, int idTurno, DateTime fechaInicio, DateTime fechaFin)
        {
            if (idsEmpleados == null || idsEmpleados.Count == 0)
                return "Debe seleccionar al menos un empleado para la asignación masiva.";

            if (idTurno <= 0)
                return "Seleccione un turno válido.";

            if (fechaFin < fechaInicio)
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";

            D_Horario datos = new D_Horario();
            return datos.AsignarHorarioMasivo(idsEmpleados, idTurno, fechaInicio, fechaFin);
        }

        public static string AsignarTurnoMasivoEmpleados(List<int> idsEmpleados, int idTurno, DateTime fechaInicio, DateTime fechaFin)
        {
            return AsignarHorarioMasivo(idsEmpleados, idTurno, fechaInicio, fechaFin);
        }

        public static string DesasignarTurnoEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                return "Identificador de empleado inválido.";

            D_Horario datos = new D_Horario();
            return datos.DesasignarTurnoEmpleado(idEmpleado);
        }

        public static string EliminarAsignacionEmpleado(int idAsignacion)
        {
            if (idAsignacion <= 0)
                return "Identificador de asignación inválido.";

            D_Horario datos = new D_Horario();
            return datos.EliminarAsignacionEmpleado(idAsignacion);
        }

        public static DataTable ListarAsignacionesDepartamentos(string valor = "")
        {
            D_Horario datos = new D_Horario();
            return datos.ListarAsignacionesDepartamentos(valor);
        }

        public static string AsignarHorarioDepartamento(int idDepartamento, int idTurno, DateTime fechaInicio, DateTime fechaFin, bool sincronizarEmpleados = true)
        {
            if (idDepartamento <= 0)
                return "Seleccione un departamento válido.";

            if (idTurno <= 0)
                return "Seleccione un turno válido.";

            if (fechaFin < fechaInicio)
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";

            D_Horario datos = new D_Horario();
            return datos.AsignarHorarioDepartamento(idDepartamento, idTurno, fechaInicio, fechaFin, sincronizarEmpleados);
        }

        public static string AsignarTurnoDepartamento(int idDepartamento, int idTurno, DateTime fechaInicio, DateTime fechaFin, bool sincronizarEmpleados = true)
        {
            return AsignarHorarioDepartamento(idDepartamento, idTurno, fechaInicio, fechaFin, sincronizarEmpleados);
        }

        public static string DesasignarTurnoDepartamento(int idDepartamento)
        {
            if (idDepartamento <= 0)
                return "Identificador de departamento inválido.";

            D_Horario datos = new D_Horario();
            return datos.DesasignarTurnoDepartamento(idDepartamento);
        }

        public static string EliminarAsignacionDepartamento(int idAsignacion)
        {
            if (idAsignacion <= 0)
                return "Identificador de asignación departamental inválido.";

            D_Horario datos = new D_Horario();
            return datos.EliminarAsignacionDepartamento(idAsignacion);
        }

        #endregion
    }
}

