using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Biometrico
    {
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT t.id AS idbiometrico, 
                               COALESCE(t.alias, t.sn) AS nombre, 
                               HOST(t.ip_address) AS direccion_ip, 
                               4370 AS puerto, 
                               0 AS comm_key, 
                               COALESCE(a.area_name, 'Área General') AS ubicacion, 
                               COALESCE(t.terminal_name, 'ZKTeco') AS modelo, 
                               t.sn AS numero_serie, 
                               CASE WHEN t.state = 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado_conexion, 
                               t.last_activity AS ultima_sincronizacion, 
                               (t.status != 0) AS activo,
                               t.user_count AS total_usuarios,
                               t.transaction_count AS total_marcaciones,
                               t.fp_count AS total_huellas
                        FROM iclock_terminal t 
                        LEFT JOIN personnel_area a ON t.area_id = a.id
                        ORDER BY t.id ASC";

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
                throw new Exception("Error al listar biométricos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Buscar(string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT t.id AS idbiometrico, 
                               COALESCE(t.alias, t.sn) AS nombre, 
                               HOST(t.ip_address) AS direccion_ip, 
                               4370 AS puerto, 
                               0 AS comm_key, 
                               COALESCE(a.area_name, 'Área General') AS ubicacion, 
                               COALESCE(t.terminal_name, 'ZKTeco') AS modelo, 
                               t.sn AS numero_serie, 
                               CASE WHEN t.state = 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado_conexion, 
                               t.last_activity AS ultima_sincronizacion, 
                               (t.status != 0) AS activo,
                               t.user_count AS total_usuarios,
                               t.transaction_count AS total_marcaciones,
                               t.fp_count AS total_huellas
                        FROM iclock_terminal t 
                        LEFT JOIN personnel_area a ON t.area_id = a.id
                        WHERE t.alias ILIKE '%' || @valor || '%' 
                           OR t.sn ILIKE '%' || @valor || '%' 
                           OR HOST(t.ip_address) ILIKE '%' || @valor || '%' 
                           OR a.area_name ILIKE '%' || @valor || '%'
                        ORDER BY t.id ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@valor", NpgsqlDbType.Varchar, 100).Value = valor.Trim();
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
                throw new Exception("Error al buscar biométricos: " + ex.Message);
            }
            return tabla;
        }

        public List<Biometrico> ListarActivos()
        {
            List<Biometrico> lista = new List<Biometrico>();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT t.id AS idbiometrico, 
                               COALESCE(t.alias, t.sn) AS nombre, 
                               HOST(t.ip_address) AS direccion_ip, 
                               4370 AS puerto, 
                               0 AS comm_key, 
                               COALESCE(a.area_name, 'Área General') AS ubicacion, 
                               COALESCE(t.terminal_name, 'ZKTeco') AS modelo, 
                               t.sn AS numero_serie, 
                               CASE WHEN t.state = 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado_conexion, 
                               t.last_activity AS ultima_sincronizacion, 
                               (t.status != 0) AS activo
                        FROM iclock_terminal t 
                        LEFT JOIN personnel_area a ON t.area_id = a.id
                        WHERE t.status != 0 
                        ORDER BY t.id ASC";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Biometrico
                                {
                                    IdBiometrico = Convert.ToInt32(dr["idbiometrico"]),
                                    Nombre = Convert.ToString(dr["nombre"]),
                                    DireccionIP = dr["direccion_ip"] != DBNull.Value ? Convert.ToString(dr["direccion_ip"]).Split('/')[0].Trim() : "",
                                    Puerto = 4370,
                                    CommKey = 0,
                                    Ubicacion = dr["ubicacion"] != DBNull.Value ? Convert.ToString(dr["ubicacion"]) : "",
                                    Modelo = dr["modelo"] != DBNull.Value ? Convert.ToString(dr["modelo"]) : "",
                                    NumeroSerie = dr["numero_serie"] != DBNull.Value ? Convert.ToString(dr["numero_serie"]) : "",
                                    EstadoConexion = Convert.ToString(dr["estado_conexion"]),
                                    UltimaSincronizacion = dr["ultima_sincronizacion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["ultima_sincronizacion"]) : null,
                                    Activo = Convert.ToBoolean(dr["activo"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar biométricos activos: " + ex.Message);
            }
            return lista;
        }

        public Biometrico ObtenerPorId(int id)
        {
            Biometrico bio = null;
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT t.id AS idbiometrico, 
                               COALESCE(t.alias, t.sn) AS nombre, 
                               HOST(t.ip_address) AS direccion_ip, 
                               4370 AS puerto, 
                               0 AS comm_key, 
                               COALESCE(a.area_name, 'Área General') AS ubicacion, 
                               COALESCE(t.terminal_name, 'ZKTeco') AS modelo, 
                               t.sn AS numero_serie, 
                               CASE WHEN t.state = 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado_conexion, 
                               t.last_activity AS ultima_sincronizacion, 
                               (t.status != 0) AS activo
                        FROM iclock_terminal t 
                        LEFT JOIN personnel_area a ON t.area_id = a.id
                        WHERE t.id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                bio = new Biometrico
                                {
                                    IdBiometrico = Convert.ToInt32(dr["idbiometrico"]),
                                    Nombre = Convert.ToString(dr["nombre"]),
                                    DireccionIP = dr["direccion_ip"] != DBNull.Value ? Convert.ToString(dr["direccion_ip"]).Split('/')[0].Trim() : "",
                                    Puerto = 4370,
                                    CommKey = 0,
                                    Ubicacion = dr["ubicacion"] != DBNull.Value ? Convert.ToString(dr["ubicacion"]) : "",
                                    Modelo = dr["modelo"] != DBNull.Value ? Convert.ToString(dr["modelo"]) : "",
                                    NumeroSerie = dr["numero_serie"] != DBNull.Value ? Convert.ToString(dr["numero_serie"]) : "",
                                    EstadoConexion = Convert.ToString(dr["estado_conexion"]),
                                    UltimaSincronizacion = dr["ultima_sincronizacion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["ultima_sincronizacion"]) : null,
                                    Activo = Convert.ToBoolean(dr["activo"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener biométrico: " + ex.Message);
            }
            return bio;
        }

        public string Insertar(Biometrico obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string sn = string.IsNullOrWhiteSpace(obj.NumeroSerie) ? ("DEV" + DateTime.Now.Ticks.ToString().Substring(10)) : obj.NumeroSerie.Trim();
                    string cleanIp = string.IsNullOrWhiteSpace(obj.DireccionIP) ? "127.0.0.1" : obj.DireccionIP.Split('/')[0].Trim();

                    string checkSql = "SELECT COUNT(*) FROM iclock_terminal WHERE sn = @sn";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, sqlCon))
                    {
                        checkCmd.Parameters.Add("@sn", NpgsqlDbType.Varchar, 50).Value = sn;
                        sqlCon.Open();
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            return "Ya existe un dispositivo registrado con el número de serie ingresado.";
                        }
                    }

                    string insertSql = @"
                        INSERT INTO iclock_terminal (
                            sn, alias, ip_address, terminal_name, state, status, area_id, 
                            product_type, is_attendance, is_tft, create_time
                        ) VALUES (
                            @sn, @nombre, @ip::inet, @modelo, 0, @status, 1, 
                            1, 1, true, NOW()
                        )";

                    using (NpgsqlCommand comando = new NpgsqlCommand(insertSql, sqlCon))
                    {
                        comando.Parameters.Add("@sn", NpgsqlDbType.Varchar, 50).Value = sn;
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = obj.Nombre.Trim();
                        comando.Parameters.Add("@ip", NpgsqlDbType.Varchar, 50).Value = cleanIp;
                        comando.Parameters.Add("@modelo", NpgsqlDbType.Varchar, 100).Value = (object)obj.Modelo ?? "ZKTeco";
                        comando.Parameters.Add("@status", NpgsqlDbType.Smallint).Value = obj.Activo ? (short)1 : (short)0;

                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar el dispositivo biométrico.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Actualizar(Biometrico obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string cleanIp = string.IsNullOrWhiteSpace(obj.DireccionIP) ? "127.0.0.1" : obj.DireccionIP.Split('/')[0].Trim();

                    string updateSql = @"
                        UPDATE iclock_terminal 
                        SET alias = @nombre, 
                            ip_address = @ip::inet, 
                            terminal_name = @modelo, 
                            sn = @sn, 
                            status = @status, 
                            change_time = NOW()
                        WHERE id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(updateSql, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = obj.IdBiometrico;
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 100).Value = obj.Nombre.Trim();
                        comando.Parameters.Add("@ip", NpgsqlDbType.Varchar, 50).Value = cleanIp;
                        comando.Parameters.Add("@modelo", NpgsqlDbType.Varchar, 100).Value = (object)obj.Modelo ?? "ZKTeco";
                        comando.Parameters.Add("@sn", NpgsqlDbType.Varchar, 50).Value = obj.NumeroSerie.Trim();
                        comando.Parameters.Add("@status", NpgsqlDbType.Smallint).Value = obj.Activo ? (short)1 : (short)0;

                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el dispositivo biométrico.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string ActualizarEstado(int id, string estado, DateTime? ultimaSync = null, string modelo = null, string numeroSerie = null, int? usuarios = null, int? logs = null, int? huellas = null)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    int stateVal = (estado == "Conectado" || estado == "1") ? 1 : 0;
                    string updateSql = @"
                        UPDATE iclock_terminal 
                        SET state = @state,
                            last_activity = COALESCE(@ultimaSync, NOW())" +
                            (!string.IsNullOrWhiteSpace(modelo) ? ", terminal_name = @modelo" : "") +
                            (!string.IsNullOrWhiteSpace(numeroSerie) ? ", sn = @numeroSerie" : "") +
                            (usuarios.HasValue ? ", user_count = @userCount" : "") +
                            (logs.HasValue ? ", transaction_count = @logCount" : "") +
                            (huellas.HasValue ? ", fp_count = @fpCount" : "") + @"
                        WHERE id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(updateSql, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        comando.Parameters.Add("@state", NpgsqlDbType.Integer).Value = stateVal;
                        comando.Parameters.Add("@ultimaSync", NpgsqlDbType.Timestamp).Value = ultimaSync.HasValue ? (object)ultimaSync.Value : DBNull.Value;
                        if (!string.IsNullOrWhiteSpace(modelo))
                        {
                            comando.Parameters.Add("@modelo", NpgsqlDbType.Varchar, 100).Value = modelo;
                        }
                        if (!string.IsNullOrWhiteSpace(numeroSerie))
                        {
                            comando.Parameters.Add("@numeroSerie", NpgsqlDbType.Varchar, 100).Value = numeroSerie;
                        }
                        if (usuarios.HasValue)
                        {
                            comando.Parameters.Add("@userCount", NpgsqlDbType.Integer).Value = usuarios.Value;
                        }
                        if (logs.HasValue)
                        {
                            comando.Parameters.Add("@logCount", NpgsqlDbType.Integer).Value = logs.Value;
                        }
                        if (huellas.HasValue)
                        {
                            comando.Parameters.Add("@fpCount", NpgsqlDbType.Integer).Value = huellas.Value;
                        }

                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el estado.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Eliminar(int id)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE iclock_terminal SET status = 0, state = 0 WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el biométrico.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
    }
}
