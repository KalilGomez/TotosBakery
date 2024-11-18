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
    }
}
