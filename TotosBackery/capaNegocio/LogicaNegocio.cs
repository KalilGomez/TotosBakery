using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class LogicaNegocio
    {
        public static Usuario ValidarUsuario(string username, string password)
        {
            try
            {
                List<Usuario> usuarios = ConexionBdd.ObtenerUsuarios();
                return usuarios.FirstOrDefault(u =>
                    u.User == username &&
                    u.Contraseña == password
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }
    }
}
