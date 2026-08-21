using System;

namespace Sistema.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string CodigoBiometrico { get; set; } // emp_code en BioTime / EnrollNumber en ZKTeco
        public string Nombre { get; set; } // first_name
        public string Apellido { get; set; } // last_name
        public string NombreCompleto => string.IsNullOrWhiteSpace(Apellido) ? Nombre : $"{Nombre} {Apellido}".Trim();
        public string NumDocumento { get; set; } // national_num
        public string Email { get; set; }
        public string Telefono { get; set; } // mobile / contact_tel
        public int? DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public int? CargoId { get; set; }
        public string Cargo { get; set; }
        public int? TurnoId { get; set; }
        public string Turno { get; set; } // Nombre del turno asignado en att_attshift
        public string HorarioDetalle { get; set; } // Horario de entrada - salida
        public string TarjetaRFID { get; set; } // card_no en BioTime / CardNumber en ZKTeco
        public string PasswordBiometrico { get; set; } // device_password en BioTime
        public int Privilegio { get; set; } // dev_privilege (0: Normal, 14: Administrador)
        public bool Habilitado { get; set; } // enable_att && is_active
        public DateTime FechaRegistro { get; set; } // hire_date / create_time
    }
}
