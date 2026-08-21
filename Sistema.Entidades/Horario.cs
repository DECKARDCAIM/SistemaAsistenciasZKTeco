using System;

namespace Sistema.Entidades
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Nombre { get; set; }
        public int CycleUnit { get; set; }
        public int ShiftCycle { get; set; }
        public bool WorkWeekend { get; set; }
    }

    public class IntervaloHorario
    {
        public int IdIntervalo { get; set; }
        public string Nombre { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int ToleranciaEntradaMin { get; set; }
        public int ToleranciaSalidaMin { get; set; }
        public double DuracionHoras { get; set; }
    }

    public class HorarioEmpleado
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int IdTurno { get; set; }
        public string NombreTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
