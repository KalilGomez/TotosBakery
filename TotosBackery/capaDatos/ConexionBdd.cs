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
            string queryUsuarios = @"SELECT ID_usuario, Nombre, Apellido, Usuario, Contraseña, EsAdmin FROM Usuario";

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
                                        id: Convert.ToInt32(reader["ID_usuario"]),
                                        nombre: reader["Nombre"].ToString(),
                                        apellido: reader["Apellido"].ToString(),
                                        user: reader["Usuario"].ToString(),
                                        contraseña: reader["Contraseña"].ToString(),
                                        admin: Convert.ToBoolean(reader["EsAdmin"])
                                    );
                                    usuarios.Add(usuario);
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                        throw; // Es importante relanzar la excepción para que el método que llama sepa que hubo un error
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
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            string queryProductos = @"select * from producto";
            using (MySqlConnection conexion = GetConnection())
            {
                if (conexion != null)
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(queryProductos, conexion))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Producto producto = new Producto(
                                        Convert.ToInt32(reader["id_producto"]),
                                        reader["nombre"].ToString(),
                                        reader["descripcion"].ToString(),
                                        Convert.ToDouble(reader["precio"]),
                                        Convert.ToInt32(reader["cantidad"])
                                        
                                    );
                                    productos.Add(producto);
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
            return productos;
        }
        public List<Pedido> ObtenerPedidos(int numeroPedido)
        {
            string query = "SELECT * FROM Pedido WHERE id_pedido = @numero_pedido";
            List<Pedido> pedidos = new List<Pedido>();
            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@numero_pedido", numeroPedido);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["id_pedido"]),
                                Estado = reader["estado"].ToString(),
                                Met_pago = reader["metodo_pago"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha_pedido"]),
                                Direccion = reader["direccion_pedido"].ToString(),
                                Clienteid = Convert.ToInt32(reader["id_cliente"])
                            };
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            return pedidos;
        }
        public List<Pedido> ObtenerTodosPedidos()
        {
            string query = "SELECT * FROM Pedido";
            List<Pedido> pedidos = new List<Pedido>();
            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["id_pedido"]),
                                Estado = reader["estado"].ToString(),
                                Met_pago = reader["metodo_pago"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha_pedido"]),
                                Direccion = reader["direccion_pedido"].ToString(),
                                Clienteid = Convert.ToInt32(reader["id_cliente"])
                            };
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            return pedidos;
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
        public static bool InsertarProducto(Producto producto)
        {
            string queryIClientes = "INSERT INTO producto (nombre, descripcion, cantidad, precio) VALUES (@nombre, @descripcion, @cantidad, @precio)";
            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(queryIClientes, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se insertó correctamente
                }
            }
        }
        public bool InsertarPedido(Pedido pedido)
        {
            string query = @"INSERT INTO Pedido (Estado, Metodo_pago, Fecha_pedido, Direccion_pedido, ID_cliente)
                     VALUES (@Estado, @Metodo_pago, @Fecha_pedido, @Direccion_pedido, @ID_cliente)";

            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                    cmd.Parameters.AddWithValue("@Metodo_pago", pedido.Met_pago);
                    cmd.Parameters.AddWithValue("@Fecha_pedido", pedido.Fecha);
                    cmd.Parameters.AddWithValue("@Direccion_pedido", pedido.Direccion);
                    cmd.Parameters.AddWithValue("@ID_cliente", pedido.Clienteid); // Aquí solo pasas el ID
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public static bool InsertarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (nombre, apellido, usuario, contraseña, esadmin) VALUES (@nombre, @apellido, @usuario, @contraseña, @esadmin)";
            using (MySqlConnection conexion = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@usuario", usuario.User);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@esadmin", usuario.Admin);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {
                        // Aquí podrías manejar el error o lanzarlo hacia arriba
                        throw;
                    }
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
        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = @"UPDATE producto 
                           SET nombre = @nombre, descripcion = @descripcion, cantidad = @cantidad, precio = @precio WHERE id_producto = @id_producto";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                        cmd.Parameters.AddWithValue("@precio", producto.Precio);
                        // Agrega los demás parámetros según tu estructura
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar el error como prefieras
                throw new Exception($"Error al actualizar producto: {ex.Message}");
            }
        }
        public bool ActualizarPedido(Pedido pedido)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = @"UPDATE Pedido
                   SET Estado = @Estado,
                       Metodo_pago = @MetPago,
                       Fecha_pedido = @Fecha,
                       Direccion_pedido = @Direccion,
                       ID_cliente = @ClienteId
                   WHERE ID_pedido = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Id", pedido.Id);
                        cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                        cmd.Parameters.AddWithValue("@MetPago", pedido.Met_pago);
                        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                        cmd.Parameters.AddWithValue("@Direccion", pedido.Direccion);
                        cmd.Parameters.AddWithValue("@ClienteId", pedido.Clienteid);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Es mejor loguear el error o manejarlo de alguna manera
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = @"UPDATE usuario
                   SET nombre = @nombre,
                       apellido = @apellido,
                       usuario = @usuario,
                       contraseña = @contraseña,
                       esadmin = @esadmin
                   WHERE ID_usuario = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@usuario", usuario.User);
                        cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                        cmd.Parameters.AddWithValue("@esadmin", usuario.Admin);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Es mejor loguear el error o manejarlo de alguna manera
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool EliminarCliente(int idCliente)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = "DELETE FROM cliente WHERE id_cliente = @id_cliente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0; // Retorna true si se eliminó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar el error como prefieras
                throw new Exception($"Error al eliminar cliente: {ex.Message}");
            }
        }
        public bool EliminarProducto(int idProducto)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = "DELETE FROM producto WHERE id_producto = @id_producto";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_producto", idProducto);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0; // Retorna true si se eliminó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar el error como prefieras
                throw new Exception($"Error al eliminar producto: {ex.Message}");
            }
        }
        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = "DELETE FROM usuario WHERE id_usuario = @id_usuario";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0; // Retorna true si se eliminó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar el error como prefieras
                throw new Exception($"Error al eliminar usuario: {ex.Message}");
            }
        }
        public static bool ResetearContraseña(string usuario)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    string query = @"UPDATE usuario
                             SET contraseña = @contraseña
                             WHERE usuario = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@contraseña", "1");
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o manejarlo según necesites
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
