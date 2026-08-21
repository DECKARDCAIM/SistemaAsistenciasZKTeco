using System;
using System.Collections.Generic;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Empleado
    {
        public static DataTable Listar()
        {
            D_Empleado datos = new D_Empleado();
            return datos.Listar();
        }

        public static DataTable SeleccionarActivos()
        {
            D_Empleado datos = new D_Empleado();
            return datos.SeleccionarActivos();
        }

        public static DataTable Buscar(string valor)
        {
            D_Empleado datos = new D_Empleado();
            return datos.Buscar(valor);
        }

        public static Empleado ObtenerPorCodigo(string codigoBiometrico)
        {
            D_Empleado datos = new D_Empleado();
            return datos.ObtenerPorCodigo(codigoBiometrico);
        }

        public static string Insertar(string codigoBiometrico, string nombre, string apellido, string numDocumento, 
                                     string email, string telefono, int? departamentoId, int? cargoId, int? turnoId,
                                     string tarjetaRFID, string passwordBiometrico, int privilegio, bool habilitado)
        {
            if (string.IsNullOrWhiteSpace(codigoBiometrico)) return "El código biométrico (Enroll Number) es obligatorio.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre del empleado es obligatorio.";

            D_Empleado datos = new D_Empleado();
            Empleado emp = new Empleado
            {
                CodigoBiometrico = codigoBiometrico.Trim(),
                Nombre = nombre.Trim(),
                Apellido = apellido?.Trim(),
                NumDocumento = numDocumento?.Trim(),
                Email = email?.Trim(),
                Telefono = telefono?.Trim(),
                DepartamentoId = departamentoId,
                CargoId = cargoId,
                TurnoId = turnoId,
                TarjetaRFID = tarjetaRFID?.Trim(),
                PasswordBiometrico = passwordBiometrico?.Trim(),
                Privilegio = privilegio,
                Habilitado = habilitado
            };
            return datos.Insertar(emp);
        }

        public static string Insertar(string codigoBiometrico, string nombre, string apellido, string numDocumento, 
                                     string email, string telefono, string departamento, string cargo, 
                                     string tarjetaRFID, string passwordBiometrico, int privilegio, bool habilitado)
        {
            return Insertar(codigoBiometrico, nombre, apellido, numDocumento, email, telefono, null, null, null, tarjetaRFID, passwordBiometrico, privilegio, habilitado);
        }

        public static string Actualizar(int idEmpleado, string codigoBiometrico, string nombre, string apellido, 
                                        string numDocumento, string email, string telefono, int? departamentoId, int? cargoId, int? turnoId,
                                        string tarjetaRFID, string passwordBiometrico, int privilegio, bool habilitado)
        {
            if (idEmpleado <= 0) return "ID de empleado inválido.";
            if (string.IsNullOrWhiteSpace(codigoBiometrico)) return "El código biométrico es obligatorio.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre del empleado es obligatorio.";

            D_Empleado datos = new D_Empleado();
            Empleado emp = new Empleado
            {
                IdEmpleado = idEmpleado,
                CodigoBiometrico = codigoBiometrico.Trim(),
                Nombre = nombre.Trim(),
                Apellido = apellido?.Trim(),
                NumDocumento = numDocumento?.Trim(),
                Email = email?.Trim(),
                Telefono = telefono?.Trim(),
                DepartamentoId = departamentoId,
                CargoId = cargoId,
                TurnoId = turnoId,
                TarjetaRFID = tarjetaRFID?.Trim(),
                PasswordBiometrico = passwordBiometrico?.Trim(),
                Privilegio = privilegio,
                Habilitado = habilitado
            };
            return datos.Actualizar(emp);
        }

        public static string Actualizar(int idEmpleado, string codigoBiometrico, string nombre, string apellido, 
                                        string numDocumento, string email, string telefono, string departamento, 
                                        string cargo, string tarjetaRFID, string passwordBiometrico, int privilegio, bool habilitado)
        {
            return Actualizar(idEmpleado, codigoBiometrico, nombre, apellido, numDocumento, email, telefono, null, null, null, tarjetaRFID, passwordBiometrico, privilegio, habilitado);
        }

        public static string GuardarOActualizarDesdeBiometrico(string codigo, string nombre, string password, int privilegio, bool habilitado, string tarjeta)
        {
            D_Empleado datos = new D_Empleado();
            return datos.GuardarOActualizarDesdeBiometrico(codigo, nombre, password, privilegio, habilitado, tarjeta);
        }

        public static int SincronizarListaDesdeBiometrico(List<Empleado> empleadosBiometrico)
        {
            if (empleadosBiometrico == null || empleadosBiometrico.Count == 0) return 0;
            int guardados = 0;
            D_Empleado datos = new D_Empleado();

            foreach (var emp in empleadosBiometrico)
            {
                string res = datos.GuardarOActualizarDesdeBiometrico(emp.CodigoBiometrico, emp.Nombre, emp.PasswordBiometrico, emp.Privilegio, emp.Habilitado, emp.TarjetaRFID);
                if (res == "OK") guardados++;
            }
            return guardados;
        }

        public static string Eliminar(int id)
        {
            D_Empleado datos = new D_Empleado();
            return datos.Eliminar(id);
        }

        public static string Activar(int id)
        {
            D_Empleado datos = new D_Empleado();
            return datos.Activar(id);
        }

        public static string Desactivar(int id)
        {
            D_Empleado datos = new D_Empleado();
            return datos.Desactivar(id);
        }

        public static DataTable ListarAdministradoresBiometricos()
        {
            D_Empleado datos = new D_Empleado();
            return datos.ListarAdministradoresBiometricos();
        }

        public static string ActualizarPrivilegioBiometrico(int idEmpleado, int nuevoPrivilegio)
        {
            D_Empleado datos = new D_Empleado();
            return datos.ActualizarPrivilegioBiometrico(idEmpleado, nuevoPrivilegio);
        }
    }
}
