using System;
using System.Configuration;
using Npgsql;

namespace Sistema.Datos
{
    public class Conexion
    {
        private static string _cadenaConexionPersonalizada;

        public static string CadenaConexion
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_cadenaConexionPersonalizada))
                {
                    return _cadenaConexionPersonalizada;
                }

                try
                {
                    var conSetting = ConfigurationManager.ConnectionStrings["CadenaConexion"];
                    if (conSetting != null && !string.IsNullOrWhiteSpace(conSetting.ConnectionString))
                    {
                        return conSetting.ConnectionString;
                    }
                }
                catch
                {
                }

                return "Host=localhost; Port=5432; Database=Biotime; Username=postgres; Password=callofduty1;";
            }
            set
            {
                _cadenaConexionPersonalizada = value;
            }
        }

        public static NpgsqlConnection CrearConexion()
        {
            return new NpgsqlConnection(CadenaConexion);
        }

        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();
                    mensaje = "Conexión a la base de datos PostgreSQL establecida correctamente.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error de conexión: " + ex.Message;
                return false;
            }
        }
    }
}