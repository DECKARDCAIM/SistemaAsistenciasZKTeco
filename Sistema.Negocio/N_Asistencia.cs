using System;
using System.Collections.Generic;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Asistencia
    {
        public static DataTable GenerarReporteConsolidado(DateTime fechaInicio, DateTime fechaFin, int? idDepartamento = null, int? idEmpleado = null, int? idTurno = null, string buscarTexto = null)
        {
            D_Asistencia datos = new D_Asistencia();
            return datos.GenerarReporteConsolidado(fechaInicio, fechaFin, idDepartamento, idEmpleado, idTurno, buscarTexto);
        }

        public static DataTable Listar(DateTime? fechaInicio, DateTime? fechaFin, int? idEmpleado, int? idBiometrico, int? idDepartamento, int? idTurno, string buscarTexto)
        {
            D_Asistencia datos = new D_Asistencia();
            return datos.Listar(fechaInicio, fechaFin, idEmpleado, idBiometrico, idDepartamento, idTurno, buscarTexto);
        }

        public static string Insertar(string codigoBiometrico, string nombreEmpleado, DateTime fechaHora, int tipoMarcacion, int metodoVerificacion, int? idBiometrico, string nombreBiometrico)
        {
            if (string.IsNullOrWhiteSpace(codigoBiometrico)) return "El código del empleado es obligatorio.";

            D_Asistencia datos = new D_Asistencia();
            Asistencia asis = new Asistencia
            {
                CodigoBiometrico = codigoBiometrico.Trim(),
                NombreEmpleado = nombreEmpleado?.Trim(),
                FechaHora = fechaHora,
                TipoMarcacion = tipoMarcacion,
                MetodoVerificacion = metodoVerificacion,
                IdBiometrico = idBiometrico,
                NombreBiometrico = nombreBiometrico?.Trim()
            };
            return datos.Insertar(asis);
        }

        public static int GuardarMarcacionesMasivas(List<Asistencia> lista, int? idBiometrico, string nombreBiometrico)
        {
            if (lista == null || lista.Count == 0) return 0;
            D_Asistencia datos = new D_Asistencia();
            return datos.InsertarMasivo(lista, idBiometrico, nombreBiometrico);
        }

        public static int GuardarMarcacionesMasivasConProgreso(List<Asistencia> lista, int? idBiometrico, string nombreBiometrico, IProgress<ProgresoSync> progreso, System.Threading.CancellationToken ct)
        {
            if (lista == null || lista.Count == 0) return 0;
            D_Asistencia datos = new D_Asistencia();
            return datos.InsertarMasivoConProgreso(lista, idBiometrico, nombreBiometrico, progreso, ct);
        }

        public static int EliminarMarcacionesFuturas(DateTime desde)
        {
            D_Asistencia datos = new D_Asistencia();
            return datos.EliminarMarcacionesFuturas(desde);
        }

        public static DataSet ObtenerEstadisticasDashboard()
        {
            D_Asistencia datos = new D_Asistencia();
            return datos.ObtenerEstadisticasDashboard();
        }
    }
}
