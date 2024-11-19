using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa un permiso asignado a un usuario en el sistema.
    /// </summary>
    public class Permiso
    {
        private int idPermiso;
        private Usuario oIdUsuario;

        /// <summary>
        /// Obtiene o establece el identificador único del permiso.
        /// </summary>
        public int IdPermiso { get => idPermiso; set => idPermiso = value; }

        /// <summary>
        /// Obtiene o establece el usuario asociado al permiso.
        /// </summary>
        public Usuario OIdUsuario { get => oIdUsuario; set => oIdUsuario = value; }
    }
}
    
