using System;

namespace Sistema.Entidades
{
    public class IntervaloHorario
    {
        public int IdIntervalo { get; set; }
        public string Alias { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public int InAheadMargin { get; set; } = 60; // Minutos antes de in_time permitidos para marcar
        public int InAboveMargin { get; set; } = 120; // Minutos después de in_time permitidos para marcar
        public int OutAheadMargin { get; set; } = 60; // Minutos antes de out_time permitidos
        public int OutAboveMargin { get; set; } = 120; // Minutos después de out_time permitidos
        public int AllowLate { get; set; } = 5; // Tolerancia de tardanza en minutos
        public int AllowLeaveEarly { get; set; } = 5; // Tolerancia de salida temprana en minutos
        public double WorkDay { get; set; } = 1.0; // Días laborados computados
        public int Duration { get; set; } = 480; // Duración en minutos
        public int InRequired { get; set; } = 1; // 1 = Obligatorio marcar entrada
        public int OutRequired { get; set; } = 1; // 1 = Obligatorio marcar salida
        public int Status { get; set; } = 1;

        // Propiedades de conveniencia para UI
        public string Nombre => Alias;
        public TimeSpan HoraEntrada => InTime;
        public TimeSpan HoraSalida => OutTime;
        public double DuracionHoras => Math.Round(Duration / 60.0, 2);
    }

    public class Turno
    {
        public int IdTurno { get; set; }
        public string Alias { get; set; }
        public int CycleUnit { get; set; } = 1; // 1 = Semanal, 0 = Diario, 2 = Mensual
        public int ShiftCycle { get; set; } = 1; // 1 ciclo semanal
        public bool WorkWeekend { get; set; } = false;
        public int WeekendType { get; set; } = 0;
        public bool WorkDayOff { get; set; } = false;
        public int DayOffType { get; set; } = 0;
        public bool AutoShift { get; set; } = false;
        public int Status { get; set; } = 1;
        public int TotalEmpleadosAsignados { get; set; }

        // Propiedad de conveniencia para UI
        public string Nombre => Alias;
    }

    public class DetalleTurno
    {
        public int IdDetalle { get; set; }
        public int ShiftId { get; set; }
        public int? TimeIntervalId { get; set; }
        public int DayIndex { get; set; } // 0 = Lunes, 1 = Martes, 2 = Miércoles, 3 = Jueves, 4 = Viernes, 5 = Sábado, 6 = Domingo
        public string DiaNombre { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public string IntervaloAlias { get; set; }
        public bool EsDescanso => !TimeIntervalId.HasValue || TimeIntervalId.Value <= 0;
    }

    public class AsignacionHorarioEmpleado
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int? DepartmentId { get; set; }
        public string Departamento { get; set; }
        public int ShiftId { get; set; }
        public string NombreTurno { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class AsignacionHorarioDepartamento
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string CodigoDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int ShiftId { get; set; }
        public string NombreTurno { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; } = 1;
        public int TotalEmpleadosAfectados { get; set; }
    }
}

