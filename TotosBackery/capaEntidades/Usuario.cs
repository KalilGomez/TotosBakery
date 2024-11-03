using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Usuario
    {
        private int id;
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

        public Usuario(string user, string contraseña)
        {
            this.user = user;
            this.contraseña = contraseña;
        }
    }
}
