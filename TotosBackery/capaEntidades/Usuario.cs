using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    internal class Usuario
    {
        private int id;
        private static int idCont = 0;
        private string nombre;
        private string apellido;
        private string user;
        private string contraseña;
        private bool admin;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string User { get => user; set => user = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public bool Admin { get => admin; set => admin = value; }

        public Usuario(string nombre, string apellido, string user, string contraseña, bool admin)
        {
            this.id = ++idCont;
            this.nombre = nombre;
            this.apellido = apellido;
            this.user = user;
            this.contraseña = contraseña;
            this.admin = admin;
        }
    }
}
