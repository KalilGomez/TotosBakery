using capaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class FormElegirPedido : Form
    {
        public int NumeroPedido { get; private set; }
        public FormElegirPedido()
        {
            InitializeComponent();
        }
        public int PedidoId
        {
            get
            {
                int pedidoId;
                int.TryParse(txtElegirPedido.Text, out pedidoId); // Captura el ID del pedido ingresado
                return pedidoId;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoNoVacio()) {return;}

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            FormPedidos formPedidos = (FormPedidos)this.Owner;  // Usa el Owner que ya estableciste
            formPedidos.CargarTodosPedidos();  // Carga todos los pedidos en el formulario padre
            this.DialogResult = DialogResult.Cancel;  // Establece el DialogResult
            this.Close();  // Cierra el formulario actual
        }

        private bool ValidarCampoNoVacio()
        {
            if (string.IsNullOrWhiteSpace(txtElegirPedido.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de pedido.");
                return false;
            }
            return true;
        }

    }
}
