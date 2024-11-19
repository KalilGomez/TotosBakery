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
        /// <summary>
        /// Obtiene o establece el número del pedido.
        /// </summary>
        public int NumeroPedido { get; private set; }

        /// <summary>
        /// Constructor de la clase FormElegirPedido.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormElegirPedido()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obtiene el ID del pedido ingresado en el campo de texto.
        /// </summary>
        public int PedidoId
        {
            get
            {
                int pedidoId;
                int.TryParse(txtElegirPedido.Text, out pedidoId);
                return pedidoId;
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Aceptar.
        /// Valida que el campo de texto del ID de pedido no esté vacío,
        /// establece el resultado del diálogo como OK y cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoNoVacio()) { return; }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Buscar Todos.
        /// Llama al método CargarTodosPedidos del formulario propietario,
        /// establece el resultado del diálogo como Cancel y cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            FormPedidos formPedidos = (FormPedidos)this.Owner;
            formPedidos.CargarTodosPedidos();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Valida que el campo de texto del ID de pedido no esté vacío.
        /// Muestra un mensaje de advertencia si el campo está vacío.
        /// </summary>
        /// <returns>Devuelve true si el campo está lleno, de lo contrario, devuelve false.</returns>
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
