using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class ClienteAgregarPedido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string NombreCompleto
        {
            get { return $"[{Id}] - {Nombre} {Apellido}"; }
        }
    }
}
