using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Pedido_Producto
    {
        private Pedido oPedido;
        private Producto oProducto;

        public Pedido OPedido { get => oPedido; set => oPedido = value; }
        public Producto OProducto { get => oProducto; set => oProducto = value; }
    }
}
