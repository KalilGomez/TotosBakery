using capaEntidades;
using MySql.Data.MySqlClient;
namespace capaDatos
{
    /// <summary>
    /// Clase responsable de gestionar la conexión y las operaciones con la base de datos.
    /// </summary>
    
    public class ConexionBdd:IDisposable
    {/// <summary>
     /// Libera los recursos utilizados por la instancia actual de <see cref="ConexionBdd"/>.
     /// </summary>
     /// <remarks>
     /// Este método implementa la interfaz <see cref="IDisposable"/> y debe ser utilizado 
     /// para liberar cualquier recurso no administrado, como conexiones a bases de datos o archivos.
     /// </remarks>
     /// 
        public void Dispose()
        {   // Este es el lugar para liberar recursos, cerrar conexiones a bases de datos, etc.
            // Ejemplo: si tienes un objeto de conexión, ciérralo aquí para liberar los recursos.
            // conexión?.Close();
        }

        // Cadena de conexión a la base de datos.
        private static string connectionString = "server=localhost;database=totosBackery;uid=root;pwd=";
        /// <summary>
        /// Obtiene una conexión abierta a la base de datos.
        /// </summary>
        /// <returns>
        /// Una instancia de <see cref="MySqlConnection"/> que representa la conexión a la base de datos abierta.
        /// Si ocurre un error al intentar abrir la conexión, retorna <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Este método establece una conexión con la base de datos utilizando la cadena de conexión configurada.
        /// Si la conexión no puede establecerse, se captura una excepción <see cref="MySqlException"/>.
        /// </remarks>

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
                // En caso de error en la conexión, mostramos un mensaje en la consola.
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Usuario"/> que representan a los usuarios registrados en la base de datos.
        /// </returns>
        /// <remarks>
        /// Este método recupera todos los usuarios almacenados en la base de datos, realizando una consulta SQL
        /// para obtener la información necesaria.
        /// </remarks>
        /// 
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
        /// <summary>
        /// Obtiene la lista de clientes almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Cliente"/> que representan a los clientes registrados en la base de datos.
        /// Si ocurre un error durante la consulta, se retorna una lista vacía.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para obtener todos los clientes de la tabla "cliente".
        /// Utiliza un <see cref="MySqlDataReader"/> para leer los datos de la base de datos y crear una lista de objetos <see cref="Cliente"/>.
        /// En caso de error durante la ejecución de la consulta, se captura una excepción <see cref="MySqlException"/> y se muestra el mensaje de error.
        /// </remarks>

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string queryClientes = @"select * from cliente"; // Consulta SQL para obtener todos los clientes.

            // Establecemos la conexión a la base de datos.
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
                                    clientes.Add(cliente); // Agregamos el cliente a la lista.
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error al obtener clientes: " + ex.Message);// Si ocurre un error en la ejecución de la consulta, lo mostramos en la consola
                    }
                    finally
                    {
                        conexion.Close();// Aseguramos que la conexión se cierre después de la ejecución.

                    }
                }
            }
            return clientes;// Devolvemos la lista de clientes obtenida.
        }

        /// <summary>
        /// Obtiene la lista de productos almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Producto"/> que representan los productos registrados en la base de datos.
        /// Si ocurre un error durante la consulta, se retorna una lista vacía.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para obtener todos los productos de la tabla "producto".
        /// Utiliza un <see cref="MySqlDataReader"/> para leer los datos de la base de datos y crear una lista de objetos <see cref="Producto"/>.
        /// En caso de error durante la ejecución de la consulta, se captura una excepción <see cref="MySqlException"/> y se muestra el mensaje de error.
        /// </remarks>

        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            string queryProductos = @"select * from producto";
            using (MySqlConnection conexion = GetConnection())
            {
                // Establecemos la conexión a la base de datos.
                if (conexion != null) // Verificamos si la conexión fue exitosa.
                {
                    try
                    {
                        // Ejecutamos el comando SQL utilizando la conexión abierta.
                        using (MySqlCommand command = new MySqlCommand(queryProductos, conexion))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader()) // Leemos los resultados de la consulta.
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
                                    productos.Add(producto); // Agregamos el producto a la lista.
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // Si ocurre un error en la ejecución de la consulta, lo mostramos en la consola.
                        Console.WriteLine("Error al obtener clientes: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close(); // Aseguramos que la conexión se cierre después de la ejecución.
                    }
                }
            }
            return productos; // Devolvemos la lista de productos obtenida.

        }
        /// <summary>
        /// Obtiene la lista de pedidos de la base de datos filtrada por un número de pedido específico.
        /// </summary>
        /// <param name="numeroPedido">
        /// El identificador del pedido para filtrar la consulta.
        /// </param>
        /// <returns>
        /// Una lista de objetos <see cref="Pedido"/> que representan los pedidos encontrados con el número de pedido especificado.
        /// Si no se encuentran pedidos para el número dado, se retorna una lista vacía.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para obtener los pedidos que coincidan con el número de pedido proporcionado.
        /// Utiliza un <see cref="MySqlDataReader"/> para leer los datos de la base de datos y crear objetos <see cref="Pedido"/>.
        /// La consulta está parametrizada para prevenir inyecciones SQL.
        /// </remarks> 
        public List<Pedido> ObtenerPedidos(int numeroPedido)
        {
            string query = "SELECT * FROM Pedido WHERE id_pedido = @numero_pedido"; // Consulta SQL con parámetro para filtrar por id_pedido.

            List<Pedido> pedidos = new List<Pedido>(); // Lista donde se almacenarán los pedidos obtenidos.
            using (MySqlConnection conexion = GetConnection())
            {
                // Preparamos el comando SQL con el parámetro del número de pedido.
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Agregamos el valor del parámetro @numero_pedido para prevenir inyecciones SQL.
                    command.Parameters.AddWithValue("@numero_pedido", numeroPedido);

                    // Ejecutamos la consulta y obtenemos los resultados.
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Recorremos los resultados obtenidos.
                        while (reader.Read())
                        {
                            // Creamos un objeto Pedido con los datos obtenidos del reader.
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["id_pedido"]),
                                Estado = reader["estado"].ToString(),
                                Met_pago = reader["metodo_pago"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha_pedido"]),
                                Direccion = reader["direccion_pedido"].ToString(),
                                Clienteid = Convert.ToInt32(reader["id_cliente"])
                            };
                            pedidos.Add(pedido); // Agregamos el pedido a la lista.
                        }
                    }
                }
            }
            return pedidos; // Retornamos la lista de pedidos obtenidos.
        }

        /// <summary>
        /// Obtiene todos los pedidos almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Pedido"/> que representan todos los pedidos registrados en la base de datos.
        /// Si no se encuentran pedidos, se retorna una lista vacía.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para obtener todos los registros de la tabla "Pedido".
        /// Utiliza un <see cref="MySqlDataReader"/> para leer los datos de la base de datos y crear una lista de objetos <see cref="Pedido"/>.
        /// </remarks>
        
        public List<Pedido> ObtenerTodosPedidos()
        {
            // Definimos la consulta SQL que obtiene todos los registros de la tabla 'Pedido'.
            string query = "SELECT * FROM Pedido";

            // Creamos una lista vacía para almacenar los pedidos obtenidos de la base de datos.
            List<Pedido> pedidos = new List<Pedido>();

            // Establecemos la conexión con la base de datos utilizando el método GetConnection().
            using (MySqlConnection conexion = GetConnection())
            {
                // Verificamos que la conexión se haya establecido correctamente antes de ejecutar el comando.
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Ejecutamos el comando y obtenemos un lector de datos para leer las filas de la consulta.
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Mientras haya filas disponibles en el lector, las vamos procesando una a una.
                        while (reader.Read())
                        {
                            // Creamos un objeto Pedido por cada fila del resultado.
                            Pedido pedido = new Pedido
                            {
                                // Asignamos los valores de las columnas a las propiedades del objeto Pedido.
                                Id = Convert.ToInt32(reader["id_pedido"]),
                                Estado = reader["estado"].ToString(),
                                Met_pago = reader["metodo_pago"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha_pedido"]),
                                Direccion = reader["direccion_pedido"].ToString(),
                                Clienteid = Convert.ToInt32(reader["id_cliente"])
                            };
                            // Agregamos el pedido a la lista de pedidos.
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            // Devolvemos la lista de pedidos obtenida.
            return pedidos;
        }
        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para insertar un nuevo cliente en la tabla `cliente` de la base de datos.
        /// Los valores del cliente se proporcionan como parámetros y se pasan al comando SQL utilizando parámetros de la consulta.
        /// Si la operación de inserción es exitosa, devuelve `true`; de lo contrario, devuelve `false`.
        /// </remarks>
        /// <param name="cliente">
        /// Un objeto de tipo <see cref="Cliente"/> que contiene la información del cliente a insertar.
        /// </param
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
        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para insertar un nuevo producto en la tabla `producto` de la base de datos.
        /// Los valores del producto se proporcionan como parámetros y se pasan al comando SQL utilizando parámetros de la consulta.
        /// Si la operación de inserción es exitosa, devuelve `true`; de lo contrario, devuelve `false`.
        /// </remarks>
        /// <param name="producto">
        /// Un objeto de tipo <see cref="Producto"/> que contiene la información del producto a insertar.
        /// </param>
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

        /// <summary>
        /// Inserta un nuevo pedido en la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para insertar un nuevo pedido en la tabla `Pedido` de la base de datos.
        /// Los valores del pedido se proporcionan como parámetros y se pasan al comando SQL utilizando parámetros de la consulta.
        /// Si la operación de inserción es exitosa, devuelve `true`; de lo contrario, devuelve `false`.
        /// </remarks>
        /// <param name="pedido">
        /// Un objeto de tipo <see cref="Pedido"/> que contiene la información del pedido a insertar.
        /// </param>
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
        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">
        /// Un objeto <see cref="Usuario"/> que contiene la información del usuario a insertar.
        /// </param>
        /// <returns>
        /// <c>true</c> si el usuario fue insertado correctamente, <c>false</c> si no se realizó la inserción correctamente.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para insertar un nuevo registro en la tabla "usuario".
        /// Utiliza parámetros para evitar inyecciones SQL y asegura que los datos del usuario sean correctamente insertados.
        /// Si ocurre un error durante la ejecución de la consulta, se captura la excepción y se relanza para ser manejada por el llamador.
        /// </remarks>
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
        /// <summary>
        /// Actualiza la información de un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">
        /// Un objeto <see cref="Cliente"/> que contiene los nuevos valores para actualizar el cliente en la base de datos.
        /// </param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa (al menos una fila fue modificada), <c>false</c> si no se realizó ninguna modificación.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para actualizar los datos del cliente en la tabla "cliente".
        /// Utiliza parámetros SQL para prevenir inyecciones de código malicioso y asegura que solo se actualicen los datos del cliente especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error es capturado y lanzado como una nueva excepción.
        /// </remarks>

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
        /// <summary>
        /// Actualiza la información de un producto en la base de datos.
        /// </summary>
        /// <param name="producto">
        /// Un objeto <see cref="Producto"/> que contiene los nuevos valores para actualizar el producto en la base de datos.
        /// </param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa (al menos una fila fue modificada), <c>false</c> si no se realizó ninguna modificación.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para actualizar los datos del producto en la tabla "producto".
        /// Utiliza parámetros SQL para evitar inyecciones de código malicioso y asegura que solo se actualicen los datos del producto especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error es capturado y lanzado como una nueva excepción con un mensaje claro.
        /// </remarks>
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
        /// <summary>
        /// Actualiza la información de un pedido en la base de datos.
        /// </summary>
        /// <param name="pedido">
        /// Un objeto <see cref="Pedido"/> que contiene los nuevos valores para actualizar el pedido en la base de datos.
        /// </param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa (al menos una fila fue modificada), <c>false</c> si no se realizó ninguna modificación.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para actualizar los datos de un pedido en la tabla "Pedido".
        /// Utiliza parámetros SQL para evitar inyecciones de código malicioso y asegura que solo se actualicen los datos del pedido especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error es capturado y mostrado en la consola.
        /// </remarks>
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
        /// <summary>
        /// Actualiza la información de un usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">
        /// Un objeto <see cref="Usuario"/> que contiene los nuevos valores para actualizar el usuario en la base de datos.
        /// </param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa (al menos una fila fue modificada), <c>false</c> si no se realizó ninguna modificación.
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para actualizar los datos de un usuario en la tabla "usuario".
        /// Utiliza parámetros SQL para evitar inyecciones de código malicioso y asegura que solo se actualicen los datos del usuario especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error es capturado y mostrado en la consola.
        /// </remarks>
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
        /// <summary>
        /// Elimina un cliente de la base de datos usando su identificador.
        /// </summary>
        /// <param name="idCliente">
        /// El identificador único del cliente que se desea eliminar.
        /// </param>
        /// <returns>
        /// <c>true</c> si la eliminación fue exitosa (al menos una fila fue afectada), 
        /// <c>false</c> si no se eliminó ningún cliente (por ejemplo, si no existe un cliente con ese ID).
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para eliminar un cliente de la tabla "cliente".
        /// Utiliza un parámetro SQL para evitar inyecciones de código malicioso y asegurar que solo se elimine el cliente especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error se captura y se lanza una excepción personalizada.
        /// </remarks>
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
        /// <summary>
        /// Elimina un producto de la base de datos utilizando su identificador.
        /// </summary>
        /// <param name="idProducto">
        /// El identificador único del producto que se desea eliminar.
        /// </param>
        /// <returns>
        /// <c>true</c> si la eliminación fue exitosa (al menos una fila fue afectada), 
        /// <c>false</c> si no se eliminó ningún producto (por ejemplo, si no existe un producto con ese ID).
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para eliminar un producto de la tabla "producto".
        /// Utiliza un parámetro SQL para evitar inyecciones de código malicioso y asegura que solo se elimine el producto especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error se captura y se lanza una excepción personalizada.
        /// </remarks>

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
        /// <summary>
        /// Elimina un usuario de la base de datos utilizando su identificador.
        /// </summary>
        /// <param name="idUsuario">
        /// El identificador único del usuario que se desea eliminar.
        /// </param>
        /// <returns>
        /// <c>true</c> si la eliminación fue exitosa (al menos una fila fue afectada), 
        /// <c>false</c> si no se eliminó ningún usuario (por ejemplo, si no existe un usuario con ese ID).
        /// </returns>
        /// <remarks>
        /// Este método ejecuta una consulta SQL para eliminar un usuario de la tabla "usuario".
        /// Utiliza un parámetro SQL para evitar inyecciones de código malicioso y asegura que solo se elimine el usuario especificado.
        /// Si ocurre un error durante la ejecución de la consulta, el error se captura y se lanza una excepción personalizada.
        /// </remarks>
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
        /// <summary>
        /// Resetea la contraseña de un usuario especificado a un valor predeterminado (en este caso, "1").
        /// </summary>
        /// <param name="usuario">
        /// El nombre de usuario cuyo valor de contraseña será reseteado.
        /// </param>
        /// <returns>
        /// <c>true</c> si la operación fue exitosa (es decir, la contraseña fue actualizada correctamente), 
        /// <c>false</c> si no se pudo realizar el cambio (por ejemplo, si el usuario no existe).
        /// </returns>
        /// <remarks>
        /// Este método ejecutaa una consulta SQL para actualizar la contraseña de un usuario en la tabla "usuario".
        /// La contraseña es reemplazada por el valor "1" como medida de restablecimiento. 
        /// Se utiliza un parámetro SQL para evitar inyecciones de código malicioso.
        /// Si ocurre un error durante la ejecución de la consulta, el error se captura y se muestra un mensaje de error.
        /// </remarks>
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
