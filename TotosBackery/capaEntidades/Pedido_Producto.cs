using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa la relación entre un pedido y un producto.
    /// </summary>
    public class Pedido_Producto
    {
        private Pedido oPedido;
        private Producto oProducto;

        /// <summary>
        /// Obtiene o establece el pedido asociado.
        /// </summary>
        public Pedido OPedido { get => oPedido; set => oPedido = value; }

        /// <summary>
        /// Obtiene o establece el producto asociado al pedido.
        /// </summary>
        public Producto OProducto { get => oProducto; set => oProducto = value; }
    }
}

