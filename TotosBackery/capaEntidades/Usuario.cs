using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa a un usuario en el sistema.
    /// </summary>
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string user;
        private string contraseña;
        private bool admin;

        /// <summary>
        /// Obtiene o establece el identificador único del usuario.
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string Apellido { get => apellido; set => apellido = value; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario (nombre de usuario).
        /// </summary>
        public string User { get => user; set => user = value; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Contraseña { get => contraseña; set => contraseña = value; }

        /// <summary>
        /// Obtiene o establece si el usuario tiene privilegios de administrador.
        /// </summary>
        public bool Admin { get => admin; set => admin = value; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/> con valores especificados.
        /// </summary>
        /// <param name="id">El identificador único del usuario.</param>
        /// <param name="nombre">El nombre del usuario.</param>
        /// <param name="apellido">El apellido del usuario.</param>
        /// <param name="user">El nombre de usuario.</param>
        /// <param name="contraseña">La contraseña del usuario.</param>
        /// <param name="admin">El valor que indica si el usuario tiene privilegios de administrador.</param>
        public Usuario(int id, string nombre, string apellido, string user, string contraseña, bool admin)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.user = user;
            this.contraseña = contraseña;
            this.admin = admin;
        }

        /// <summary>
        /// Inicializa una nueva instancia vacía de la clase <see cref="Usuario"/>.
        /// </summary>
        public Usuario() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/> con la contraseña especificada.
        /// </summary>
        /// <param name="contraseña">La contraseña del usuario.</param>
        public Usuario(string contraseña)
        {
            this.contraseña = contraseña;
        }
    }
}
