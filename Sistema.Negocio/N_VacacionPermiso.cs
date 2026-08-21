using System;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_VacacionPermiso
    {
        public static DataTable Listar()
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.Listar();
        }

        public static DataTable ListarCategorias()
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.ListarCategorias();
        }

        public static DataTable Buscar(string valor, int idDept, int idCategoria, DateTime? desde, DateTime? hasta, int estadoAuditoria)
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.Buscar(valor, idDept, idCategoria, desde, hasta, estadoAuditoria);
        }

        public static string Insertar(int idEmpleado, int idCategoria, DateTime fechaInicio, DateTime fechaFin, 
                                      string motivo, string auditor, string motivoAuditoria, short estado = 2, string adjunto = "")
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            VacacionPermiso obj = new VacacionPermiso
            {
                IdEmpleado = idEmpleado,
                IdCategoria = idCategoria,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                MotivoSolicitud = motivo,
                FechaSolicitud = DateTime.Now,
                Aprobador = auditor,
                MotivoAuditoria = motivoAuditoria,
                FechaAuditoria = DateTime.Now,
                EstadoAuditoria = estado,
                Adjunto = adjunto
            };
            return datos.Insertar(obj);
        }

        public static string Actualizar(int id, int idEmpleado, int idCategoria, DateTime fechaInicio, DateTime fechaFin, 
                                        string motivo, string auditor, string motivoAuditoria, short estado = 2, string adjunto = "")
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            VacacionPermiso obj = new VacacionPermiso
            {
                Id = id,
                IdEmpleado = idEmpleado,
                IdCategoria = idCategoria,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                MotivoSolicitud = motivo,
                Aprobador = auditor,
                MotivoAuditoria = motivoAuditoria,
                FechaAuditoria = DateTime.Now,
                EstadoAuditoria = estado,
                Adjunto = adjunto
            };
            return datos.Actualizar(obj);
        }

        public static string Eliminar(int id)
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.Eliminar(id);
        }

        public static string Aprobar(int id, string auditor, string motivo = "Aprobado por RRHH.")
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.CambiarEstado(id, 2, auditor, motivo);
        }

        public static string Rechazar(int id, string auditor, string motivo = "Rechazado por RRHH.")
        {
            D_VacacionPermiso datos = new D_VacacionPermiso();
            return datos.CambiarEstado(id, 3, auditor, motivo);
        }
    }
}
