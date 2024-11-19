using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa un pedido realizado por un cliente en el sistema.
    /// </summary>
    public class Pedido
    {
        private int id;
        private string estado;
        private string met_pago;
        private DateTime fecha;
        private string direccion;
        private int clienteid;

        /// <summary>
        /// Obtiene o establece el identificador único del pedido.
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtiene o establece el estado del pedido.
        /// </summary>
        public string Estado { get => estado; set => estado = value; }

        /// <summary>
        /// Obtiene o establece el método de pago del pedido.
        /// </summary>
        public string Met_pago { get => met_pago; set => met_pago = value; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se realizó el pedido.
        /// </summary>
        public DateTime Fecha { get => fecha; set => fecha = value; }

        /// <summary>
        /// Obtiene o establece la dirección de entrega del pedido.
        /// </summary>
        public string Direccion { get => direccion; set => direccion = value; }

        /// <summary>
        /// Obtiene o establece el identificador del cliente que realizó el pedido.
        /// </summary>
        public int Clienteid { get => clienteid; set => clienteid = value; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pedido"/> con valores especificados.
        /// </summary>
        /// <param name="id">El identificador único del pedido.</param>
        /// <param name="estado">El estado actual del pedido.</param>
        /// <param name="met_pago">El método de pago seleccionado para el pedido.</param>
        /// <param name="fecha">La fecha en la que se realizó el pedido.</param>
        /// <param name="direccion">La dirección de entrega del pedido.</param>
        /// <param name="clienteid">El identificador del cliente que realizó el pedido.</param>
        public Pedido(int id, string estado, string met_pago, DateTime fecha, string direccion, int clienteid)
        {
            this.id = id;
            this.estado = estado;
            this.met_pago = met_pago;
            this.fecha = fecha;
            this.direccion = direccion;
            this.Clienteid = clienteid;
        }

        /// <summary>
        /// Inicializa una nueva instancia vacía de la clase <see cref="Pedido"/>.
        /// </summary>
        public Pedido() { }
    }
}
    
