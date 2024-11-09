using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using capaEntidades;

namespace capaPresentacion
{
    //ver de agregar un combobox para el estado del pedido!
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }
        public void CargarPedidos(Cliente cliente)
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    // Cargar los pedidos específicos de un cliente desde la base de datos
                    List<Pedido> pedidos = conexion.ObtenerPedidos(cliente.Id);

                    // Actualizar el DataGridView con los pedidos obtenidos
                    dgvPedido.DataSource = null;
                    dgvPedido.DataSource = pedidos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            // Abrir el formulario hijo
            using (FormAgregarPedido formAgregar = new FormAgregarPedido())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Crear un nuevo cliente con los datos del formulario hijo
                    //int nuevoId = pedidos.Count + 1;
                    string nuevoPed = "Nuevo";
                    
                    // Agregar el nuevo cliente a la lista


                    // Actualizar el DataGridView
                    dgvPedido.DataSource = null;
                    //dgvPedido.DataSource = pedidos;
                }
            }
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(1); // Crea el objeto Cliente con sus propiedades
            CargarPedidos(cliente);

            dgvPedido.Enabled = false;
            dgvPedido.ClearSelection();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            dgvPedido.Enabled = !dgvPedido.Enabled;

            if (dgvPedido.Enabled)
            {
                btnEditarProducto.Text = "Aceptar";
                // Otras acciones cuando se habilita la edición
            }
            else
            {
                btnEditarProducto.Text = "Editar cliente";
                dgvPedido.ClearSelection();
                // Otras acciones cuando se finaliza la edición
            }
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            //cambiar para que el estado se haga en editar directamente
        }
    }
}
