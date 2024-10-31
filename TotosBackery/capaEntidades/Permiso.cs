using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Permiso
    {
        private int idPermiso;
        private Usuario oIdUsuario;

        public int IdPermiso { get => idPermiso; set => idPermiso = value; }
        public Usuario OIdUsuario { get => oIdUsuario; set => oIdUsuario = value; }
    }
}
