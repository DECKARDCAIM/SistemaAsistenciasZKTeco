using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class D_Usuario
    {
        public Usuario ObtenerPorUsernameOEmail(string identifier)
        {
            Usuario usuario = null;
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT u.id, u.username, u.first_name, u.last_name, u.email, u.password, 
                               u.is_active, u.is_staff, u.is_superuser, u.last_login,
                               CASE 
                                    WHEN u.is_superuser THEN 1 
                                    WHEN u.is_staff THEN 2 
                                    ELSE 3 
                               END AS idrol,
                               CASE 
                                    WHEN u.is_superuser THEN 'Administrador' 
                                    WHEN u.is_staff THEN 'Supervisor' 
                                    ELSE 'Usuario' 
                               END AS rol
                        FROM auth_user u 
                        WHERE (LOWER(u.username) = LOWER(@ident) OR LOWER(u.email) = LOWER(@ident))";

                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@ident", NpgsqlDbType.Varchar, 150).Value = identifier.Trim();
                        sqlCon.Open();

                        using (NpgsqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string fName = dr["first_name"] != DBNull.Value ? Convert.ToString(dr["first_name"]) : "";
                                string lName = dr["last_name"] != DBNull.Value ? Convert.ToString(dr["last_name"]) : "";
                                string displayName = $"{fName} {lName}".Trim();
                                if (string.IsNullOrWhiteSpace(displayName))
                                {
                                    displayName = Convert.ToString(dr["username"]);
                                }

                                usuario = new Usuario
                                {
                                    IdUsuario = Convert.ToInt32(dr["id"]),
                                    Username = Convert.ToString(dr["username"]),
                                    IdRol = Convert.ToInt32(dr["idrol"]),
                                    NombreRol = Convert.ToString(dr["rol"]),
                                    Nombre = displayName,
                                    Apellido = lName,
                                    Email = dr["email"] != DBNull.Value ? Convert.ToString(dr["email"]) : "",
                                    Clave = Convert.ToString(dr["password"]),
                                    Estado = Convert.ToBoolean(dr["is_active"]),
                                    EsStaff = Convert.ToBoolean(dr["is_staff"]),
                                    EsSuperUsuario = Convert.ToBoolean(dr["is_superuser"]),
                                    UltimoLogin = dr["last_login"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["last_login"]) : null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario en base de datos: " + ex.Message);
            }
            return usuario;
        }

        public void RegistrarLogin(int idUsuario)
        {
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = "UPDATE auth_user SET last_login = NOW() WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(consulta, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = idUsuario;
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string consulta = @"
                        SELECT u.id AS idusuario, u.username, 
                               CASE WHEN u.is_superuser THEN 1 WHEN u.is_staff THEN 2 ELSE 3 END AS idrol,
                               CASE WHEN u.is_superuser THEN 'Administrador' WHEN u.is_staff THEN 'Supervisor' ELSE 'Usuario' END AS rol,
                               COALESCE(NULLIF((COALESCE(u.first_name, '') || ' ' || COALESCE(u.last_name, '')), ' '), u.username) AS nombre,
                               u.email, u.is_active AS estado, u.last_login AS ultimo_login
                        FROM auth_user u 
                        ORDER BY u.id ASC";

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
                throw new Exception("Error al listar usuarios: " + ex.Message);
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
                        SELECT u.id AS idusuario, u.username, 
                               CASE WHEN u.is_superuser THEN 1 WHEN u.is_staff THEN 2 ELSE 3 END AS idrol,
                               CASE WHEN u.is_superuser THEN 'Administrador' WHEN u.is_staff THEN 'Supervisor' ELSE 'Usuario' END AS rol,
                               COALESCE(NULLIF((COALESCE(u.first_name, '') || ' ' || COALESCE(u.last_name, '')), ' '), u.username) AS nombre,
                               u.email, u.is_active AS estado, u.last_login AS ultimo_login
                        FROM auth_user u 
                        WHERE u.username ILIKE '%' || @valor || '%' 
                           OR u.email ILIKE '%' || @valor || '%' 
                           OR u.first_name ILIKE '%' || @valor || '%' 
                           OR u.last_name ILIKE '%' || @valor || '%'
                        ORDER BY u.id ASC";

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
                throw new Exception("Error al buscar usuarios: " + ex.Message);
            }
            return tabla;
        }

        public string Insertar(Usuario obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string username = string.IsNullOrWhiteSpace(obj.Username) ? obj.Email.Split('@')[0] : obj.Username.Trim();

                    string checkSql = "SELECT COUNT(*) FROM auth_user WHERE LOWER(username) = LOWER(@user) OR (email <> '' AND LOWER(email) = LOWER(@email))";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, sqlCon))
                    {
                        checkCmd.Parameters.Add("@user", NpgsqlDbType.Varchar, 150).Value = username;
                        checkCmd.Parameters.Add("@email", NpgsqlDbType.Varchar, 254).Value = obj.Email.Trim();
                        sqlCon.Open();
                        int existe = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existe > 0)
                        {
                            return "Ya existe un usuario con el nombre de usuario o correo electrónico especificado.";
                        }
                    }

                    bool esSuperUser = obj.IdRol == 1 || obj.EsSuperUsuario;
                    bool esStaff = obj.IdRol <= 2 || obj.EsStaff;

                    string insertSql = @"
                        INSERT INTO auth_user (username, first_name, last_name, email, password, is_active, is_staff, is_superuser, date_joined)
                        VALUES (@username, @nombre, @apellido, @email, @clave, @estado, @is_staff, @is_superuser, NOW())";

                    using (NpgsqlCommand comando = new NpgsqlCommand(insertSql, sqlCon))
                    {
                        comando.Parameters.Add("@username", NpgsqlDbType.Varchar, 150).Value = username;
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 150).Value = (object)obj.Nombre ?? DBNull.Value;
                        comando.Parameters.Add("@apellido", NpgsqlDbType.Varchar, 150).Value = (object)obj.Apellido ?? DBNull.Value;
                        comando.Parameters.Add("@email", NpgsqlDbType.Varchar, 254).Value = obj.Email.Trim();
                        comando.Parameters.Add("@clave", NpgsqlDbType.Varchar, 128).Value = obj.Clave.Trim();
                        comando.Parameters.Add("@estado", NpgsqlDbType.Boolean).Value = obj.Estado;
                        comando.Parameters.Add("@is_staff", NpgsqlDbType.Boolean).Value = esStaff;
                        comando.Parameters.Add("@is_superuser", NpgsqlDbType.Boolean).Value = esSuperUser;

                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Actualizar(Usuario obj)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    bool esSuperUser = obj.IdRol == 1 || obj.EsSuperUsuario;
                    bool esStaff = obj.IdRol <= 2 || obj.EsStaff;

                    string updateSql = @"
                        UPDATE auth_user 
                        SET first_name = @nombre, last_name = @apellido, email = @email,
                            is_staff = @is_staff, is_superuser = @is_superuser, is_active = @estado" +
                            (string.IsNullOrWhiteSpace(obj.Clave) ? "" : ", password = @clave") + @"
                        WHERE id = @id";

                    using (NpgsqlCommand comando = new NpgsqlCommand(updateSql, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = obj.IdUsuario;
                        comando.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 150).Value = (object)obj.Nombre ?? DBNull.Value;
                        comando.Parameters.Add("@apellido", NpgsqlDbType.Varchar, 150).Value = (object)obj.Apellido ?? DBNull.Value;
                        comando.Parameters.Add("@email", NpgsqlDbType.Varchar, 254).Value = obj.Email.Trim();
                        comando.Parameters.Add("@estado", NpgsqlDbType.Boolean).Value = obj.Estado;
                        comando.Parameters.Add("@is_staff", NpgsqlDbType.Boolean).Value = esStaff;
                        comando.Parameters.Add("@is_superuser", NpgsqlDbType.Boolean).Value = esSuperUser;
                        if (!string.IsNullOrWhiteSpace(obj.Clave))
                        {
                            comando.Parameters.Add("@clave", NpgsqlDbType.Varchar, 128).Value = obj.Clave.Trim();
                        }

                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el usuario.";
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
                    string query = "DELETE FROM auth_user WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el usuario.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Activar(int id)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE auth_user SET is_active = true WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el usuario.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Desactivar(int id)
        {
            string respuesta = "";
            try
            {
                using (NpgsqlConnection sqlCon = Conexion.CrearConexion())
                {
                    string query = "UPDATE auth_user SET is_active = false WHERE id = @id";
                    using (NpgsqlCommand comando = new NpgsqlCommand(query, sqlCon))
                    {
                        comando.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                        sqlCon.Open();
                        respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el usuario.";
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
