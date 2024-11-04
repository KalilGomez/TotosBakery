using capaEntidades;
using MySql.Data.MySqlClient;
namespace capaDatos
{
    public class ConexionBdd:IDisposable
    {
        public void Dispose()
        {
            // Libera recursos, cierra conexiones, etc.
            // Por ejemplo, si tienes un objeto de conexión, podrías cerrarlo aquí
        }
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
            string queryUsuarios = @"select usuario, contraseña, esadmin from usuario";

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
                                    Usuario usuario = new Usuario(
                                        reader["Usuario"].ToString(),
                                        reader["Contraseña"].ToString(),
                                        Convert.ToInt32(reader["EsAdmin"])
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
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string queryClientes = @"select * from cliente";
            using (MySqlConnection conexion = GetConnection())
            {
                if (conexion != null)
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(queryClientes, conexion))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Cliente cliente = new Cliente(
                                        Convert.ToInt32(reader["id_cliente"]),
                                        reader["nombre"].ToString(),
                                        reader["apellido"].ToString(),
                                        reader["telefono"].ToString(),
                                        reader["mail"].ToString(),
                                        reader["direccion"].ToString()
                                    );
                                    clientes.Add(cliente);
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error al obtener clientes: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return clientes;
        }
        public static bool InsertarCliente(Cliente cliente)
        {
            string queryIClientes = "INSERT INTO cliente (nombre, apellido, telefono, mail, direccion) VALUES (@nombre, @apellido, @telefono, @mail, @direccion)";
            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(queryIClientes, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);             
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se insertó correctamente
                }
            }
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = @"UPDATE cliente 
                           SET nombre = @nombre, apellido = @apellido, telefono = @telefono, mail = @mail, direccion = @direccion WHERE id_cliente = @id_cliente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", cliente.Id);
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                        cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                        // Agrega los demás parámetros según tu estructura
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar el error como prefieras
                throw new Exception($"Error al actualizar cliente: {ex.Message}");
            }
        }
    }
}
