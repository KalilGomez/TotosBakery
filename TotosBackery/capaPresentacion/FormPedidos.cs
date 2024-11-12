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
        private bool omitirBusqueda;
        public FormPedidos(bool omitirBusqueda = false)
        {
            InitializeComponent();
            this.omitirBusqueda = omitirBusqueda;
        }
        public FormPedidos()
        {
            InitializeComponent();

        }
        public void CargarPedidos(int pedido)
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    // Cargar los pedidos específicos de un cliente desde la base de datos
                    List<Pedido> pedidos = conexion.ObtenerPedidos(pedido);

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
        public void CargarTodosPedidos()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    List<Pedido> pedidos = conexion.ObtenerTodosPedidos();
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
            using (FormAgregarPedido formAgregar = new FormAgregarPedido())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Crear un nuevo objeto Pedido con los datos del formulario hijo
                    Pedido nuevoPedido = new Pedido
                    {
                        Estado = "Pendiente",  // O el valor que desees asignar por defecto
                        Met_pago = formAgregar.MetPag,
                        Fecha = formAgregar.Fecha,
                        Direccion = formAgregar.Direccion,
                        Clienteid = formAgregar.ClienteId
                    };

                    // Insertar el nuevo pedido en la base de datos
                    ConexionBdd conexion = new ConexionBdd();
                    if (conexion.InsertarPedido(nuevoPedido))
                    {
                        // Actualizar DataGridView con el nuevo pedido del cliente
                        CargarPedidos(nuevoPedido.Clienteid);
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FormPedidos_Load(object sender, EventArgs e)
        {
            if (!omitirBusqueda)
            {
                BuscarPedido();
            }
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
        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            BuscarPedido();
        }
        private void BuscarPedido()
        {
            using (FormElegirPedido formElegirPedido = new FormElegirPedido())
            {
                formElegirPedido.Owner = this;
                if (formElegirPedido.ShowDialog() == DialogResult.OK)
                {
                    int pedidoId = formElegirPedido.PedidoId;
                    if (pedidoId > 0)
                    {
                        // Llama al método para cargar el pedido automáticamente
                        CargarPedidos(pedidoId);
                    }
                    else
                    {
                        MessageBox.Show("ID de pedido inválido.");
                    }
                }
                dgvPedido.Enabled = false;
                dgvPedido.ClearSelection();
            }
        }
    }
}
