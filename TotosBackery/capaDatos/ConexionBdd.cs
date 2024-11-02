using capaEntidades;
using MySql.Data.MySqlClient;
using System;
namespace capaDatos
{
    public class ConexionBdd
    {
        private static string connectionString = "server=localhost;database=totosBackery;uid=root;pwd=";
        private static MySqlConnection GetConnection()
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }
        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string queryUsuarios = @"SELECT 
                                Usuario.Usuario AS NombreUsuario, 
                                Usuario.Contraseña, 
                                CASE 
                                    WHEN Permiso.ID_permiso IS NULL THEN 2
                                    ELSE Permiso.ID_permiso 
                                END AS Permiso
                            FROM 
                                Usuario 
                            LEFT JOIN 
                                Permiso ON Usuario.ID_usuario = Permiso.ID_usuario;";

            using (MySqlConnection conexion = GetConnection())
            {
                if (conexion != null)
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(queryUsuarios, conexion))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int permisoValue = Convert.ToInt32(reader["ID_Permiso"]);
                                    Usuario usuario = new Usuario(
                                        reader["Usuario"].ToString(),
                                        reader["Contraseña"].ToString(),
                                        permisoValue == 1
                                    );
                                    usuarios.Add(usuario);
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return usuarios;
        }
    }
}
