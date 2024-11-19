using capaEntidades;
using capaDatos;

namespace capaNegocio

{
    /// <summary>
    /// Proporciona métodos de lógica de negocio relacionados con los usuarios.
    /// </summary>
    /// 
    public class LogicaNegocio
    {
        /// <summary>
        /// Valida las credenciales de un usuario comparando el nombre de usuario y la contraseña.
        /// </summary>
        /// <param name="username">El nombre de usuario que se va a validar.</param>
        /// <param name="password">La contraseña del usuario que se va a validar.</param>
        /// <returns>
        /// Un objeto <see cref="Usuario"/> si las credenciales son válidas; de lo contrario, <c>null</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Se lanza cuando ocurre un error al intentar obtener o validar los usuarios desde la base de datos.
        /// </exception>
        /// <remarks>
        /// Este método busca en la lista de usuarios si existe un usuario cuyo nombre de usuario y contraseña coincidan con los proporcionados.
        /// </remarks>

        public static Usuario ValidarUsuarioContraseña(string username, string password)
        {
            try
            {   // Se obtiene la lista de usuarios desde la base de datos
                List<Usuario> usuarios = ConexionBdd.ObtenerUsuarios();
                // Busca el primer usuario que coincida con el nombre de usuario y la contraseña
                return usuarios.FirstOrDefault (u => u.User == username && u.Contraseña == password);
            }
            catch (Exception ex)
            {
                // Se lanza una excepción personalizada en caso de error
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }
        /// <summary>
        /// Verifica si existe un usuario con el nombre de usuario especificado, sin comprobar la contraseña.
        /// </summary>
        /// <param name="username">El nombre de usuario que se va a verificar.</param>
        /// <returns>
        /// Un objeto <see cref="Usuario"/> si el usuario existe; de lo contrario, <c>null</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Se lanza cuando ocurre un error al intentar obtener o validar los usuarios desde la base de datos.
        /// </exception>
        /// <remarks>
        /// Este método se utiliza cuando solo es necesario verificar si un usuario con ese nombre ya existe, sin necesidad de comprobar la contraseña.
        /// </remarks>

        public static Usuario ValidarUsuario(string username)
        {
            try
            {
                // Se obtiene la lista de usuarios desde la base de datos
                List<Usuario> usuarios = ConexionBdd.ObtenerUsuarios();
                // Busca el primer usuario que coincida con el nombre de usuario
                return usuarios.FirstOrDefault(u => u.User == username);
            }
            catch (Exception ex)
            {
                // Se lanza una excepción personalizada en caso de error
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }
        //private bool ValidarSoloLetas(string nombre, string apellido)
        //{
        //    if (!nombre.All(c => Char.IsLetter(c) || c == ' '))
        //    {
        //        MessageBox.Show("El nombre solo puede contener letras.");
        //        return false;
        //    }

        //    if (!apellido.All(c => Char.IsLetter(c) || c == ' '))
        //    {
        //        MessageBox.Show("El apellido solo puede contener letras.");
        //        return false;
        //    }

        //    return true;
        //}
        //private bool ValidarTelefonoEsEntero(string telefono)
        //{
        //    // Intentamos convertir el teléfono a un int
        //    if (!int.TryParse(telefono, out _))
        //    {
        //        MessageBox.Show("El teléfono debe ser un número entero.");
        //        return false;
        //    }

        //    // Verificar que el teléfono tenga una longitud específica (por ejemplo, 10 dígitos)
        //    if (telefono.Length != 10)
        //    {
        //        MessageBox.Show("El teléfono debe contener 10 dígitos.");
        //        return false;
        //    }

        //    return true;
        //}

        //// Método para validar si el correo electrónico contiene el símbolo "@"
        //private bool ValidarCorreo(string correo)
        //{
        //    // Verifica si el correo contiene el símbolo "@"
        //    if (!correo.Contains("@"))
        //    {
        //        MessageBox.Show("El correo electrónico debe contener el símbolo '@'.");
        //        return false;
        //    }
        //    return true;  // Si contiene "@", retorna verdadero
        //}
        //private bool ValidarSeleccionCliente()
        //{
        //    if (cboxCliente.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Por favor, seleccione un cliente.");
        //        return false;
        //    }
        //    return true;
        //}
        //private bool ValidarFechaAntigua()
        //{
        //    if (dtpFecha.Value.Date < DateTime.Now.Date)
        //    {
        //        MessageBox.Show("La fecha no puede ser pasada.");
        //        return false;
        //    }
        //    return true;
        //}
        //private bool ValidarPrecio()
        //{
        //    if (!double.TryParse(txtPrecio.Text, out double precio))
        //    {
        //        MessageBox.Show("El precio ingresado no es válido. Debe ser un número.");
        //        return false;
        //    }

        //    if (precio <= 0)
        //    {
        //        MessageBox.Show("El precio debe ser un número mayor que cero.");
        //        return false;
        //    }

        //    return true;
        //}
        //private bool ValidarCantidad()
        //{
        //    if (!int.TryParse(txtCantidad.Text, out int cantidad))
        //    {
        //        MessageBox.Show("La cantidad ingresada no es válida. Debe ser un número entero.");
        //        return false;
        //    }

        //    if (cantidad <= 0)
        //    {
        //        MessageBox.Show("La cantidad debe ser un número mayor que cero.");
        //        return false;
        //    }

        //    return true;
        //}
        //private bool ValidarNombreApellido()
        //{
        //    if (!txtNombre.Text.All(c => Char.IsLetter(c) || c == ' '))
        //    {
        //        MessageBox.Show("El nombre solo puede contener letras y espacios.");
        //        return false;
        //    }

        //    if (!txtApellido.Text.All(c => Char.IsLetter(c) || c == ' '))
        //    {
        //        MessageBox.Show("El apellido solo puede contener letras y espacios.");
        //        return false;
        //    }
        //    return true;
        //}
        //// Método para verificar si el correo contiene el símbolo "@"
        //private bool ValidarCorreoConArroba(string mail)
        //{
        //    if (!mail.Contains("@"))
        //    {
        //        MessageBox.Show("El correo electrónico debe contener el símbolo '@'.");
        //        return false;  // Si no contiene "@", devuelve false
        //    }
        //    return true; // Si contiene "@", devuelve true
        //}
        //private bool ValidarCamposNoVacios(Pedido pedido)
        //{
        //    if (string.IsNullOrWhiteSpace(pedido.Estado) ||
        //        string.IsNullOrWhiteSpace(pedido.Met_pago) ||
        //        string.IsNullOrWhiteSpace(pedido.Direccion))
        //    {
        //        MessageBox.Show("Por favor, complete todos los campos.");
        //        return false;
        //    }
        //    return true;
        //}
        //// Método para validar el formato de la fecha (no puede ser futura)
        //private bool ValidarFechaValida(DateTime fecha)
        //{
        //    if (fecha < DateTime.Now)
        //    {
        //        MessageBox.Show("La fecha no puede ser en antigua a la actual.");
        //        return false;
        //    }
        //    return true;
        //}
        //private bool ValidarPrecioPositivo(double precio)
        //{
        //    if (precio <= 0)
        //    {
        //        MessageBox.Show("El precio debe ser mayor que 0.", "Validación",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    return true;
        //}

        //private bool ValidarCantidadPositiva(int cantidad)
        //{
        //    if (cantidad <= 0)
        //    {
        //        MessageBox.Show("La cantidad debe ser mayor que 0.", "Validación",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
