using capaEntidades;
using capaDatos;

namespace capaNegocio

{
    public class LogicaNegocio
    {
        /// <summary>
        /// Valida un usuario buscando en la base de datos por nombre de usuario y contraseña.
        /// </summary>
        /// <param name="username">El nombre de usuario a validar.</param>
        /// <param name="password">La contraseña del usuario a validar.</param>
        /// <returns>El usuario que coincide con el nombre de usuario y la contraseña, o null si no se encuentra.</returns>
        /// <exception cref="Exception">Lanzada si ocurre un error al validar el usuario.</exception>
        public static Usuario ValidarUsuarioContraseña(string username, string password)
        {
            try
            {
                List<Usuario> usuarios = ConexionBdd.ObtenerUsuarios();
                // Busca el primer usuario que coincida con el nombre de usuario y la contraseña
                return usuarios.FirstOrDefault(u => u.User == username && u.Contraseña == password);
            }
            catch (Exception ex)
            {
                // Se lanza una excepción personalizada en caso de error
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }

        /// <summary>
        /// Valida un usuario buscando en la base de datos por nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario a validar.</param>
        /// <returns>El usuario que coincide con el nombre de usuario, o null si no se encuentra.</returns>
        /// <exception cref="Exception">Lanzada si ocurre un error al validar el usuario.</exception>
        public static Usuario ValidarUsuario(string username)
        {
            try
            {
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

        /// <summary>
        /// Valida que el nombre y el apellido solo contengan letras y espacios.
        /// </summary>
        /// <param name="nombre">El nombre a validar.</param>
        /// <param name="apellido">El apellido a validar.</param>
        /// <returns>true si ambos son válidos, de lo contrario, false.</returns>
        public static bool ValidarSoloLetas(string nombre, string apellido)
        {
            if (!nombre.All(c => Char.IsLetter(c) || c == ' '))
            {
                return false;
            }

            if (!apellido.All(c => Char.IsLetter(c) || c == ' '))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que el teléfono contenga solo dígitos numéricos.
        /// </summary>
        /// <param name="telefono">El teléfono a validar.</param>
        /// <returns>true si el teléfono es válido, de lo contrario, false.</returns>
        public static bool ValidarTelefonoEsEntero(string telefono)
        {
            // Intentamos convertir el teléfono a un int
            if (!int.TryParse(telefono, out _))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida que el correo contenga el símbolo "@".
        /// </summary>
        /// <param name="correo">El correo a validar.</param>
        /// <returns>true si el correo es válido, de lo contrario, false.</returns>
        public static bool ValidarCorreo(string correo)
        {
            // Verifica si el correo contiene el símbolo "@"
            if (!correo.Contains("@"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida que la fecha no sea anterior a la fecha actual.
        /// </summary>
        /// <param name="dateTime">La fecha a validar.</param>
        /// <returns>true si la fecha es válida, de lo contrario, false.</returns>
        public static bool ValidarFechaAntigua(DateTime dateTime)
        {
            if (dateTime.Date < DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida que el precio sea un número mayor que 0.
        /// </summary>
        /// <param name="precioTexto">El precio a validar.</param>
        /// <returns>true si el precio es válido, de lo contrario, false.</returns>
        public static bool ValidarPrecio(string precioTexto)
        {
            return double.TryParse(precioTexto, out double precio) && precio > 0;
        }

        /// <summary>
        /// Valida que la cantidad sea un número entero mayor que 0.
        /// </summary>
        /// <param name="cantidadTexto">La cantidad a validar.</param>
        /// <returns>true si la cantidad es válida, de lo contrario, false.</returns>
        public static bool ValidarCantidad(string cantidadTexto)
        {
            return int.TryParse(cantidadTexto, out int cantidad) && cantidad > 0;
        }

        /// <summary>
        /// Valida que el nombre no esté vacío y solo contenga letras y espacios.
        /// </summary>
        /// <param name="nombre">El nombre a validar.</param>
        /// <returns>true si el nombre es válido, de lo contrario, false.</returns>
        public static bool ValidarNombre(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   nombre.All(c => Char.IsLetter(c) || c == ' ');
        }
    }
}
