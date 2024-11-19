using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa la información de un cliente para agregar un pedido.
    /// </summary>
    public class ClienteAgregarPedido
    {
        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del cliente.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene el nombre completo del cliente, que incluye el identificador, nombre y apellido.
        /// </summary>
        public string NombreCompleto
        {
            get { return $"[{Id}] - {Nombre} {Apellido}"; }
        }
    }
}

