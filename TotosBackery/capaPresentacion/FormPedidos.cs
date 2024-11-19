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
using capaNegocio;

namespace capaPresentacion
{
    public partial class FormPedidos : Form
    {
        /// <summary>
        /// Indica si se debe omitir la búsqueda de pedidos.
        /// </summary>
        private bool omitirBusqueda;

        /// <summary>
        /// Constructor de la clase FormPedidos con un parámetro opcional para omitir la búsqueda.
        /// Inicializa los componentes del formulario y establece la variable omitirBusqueda.
        /// </summary>
        /// <param name="omitirBusqueda">Indica si se debe omitir la búsqueda de pedidos.</param>
        public FormPedidos(bool omitirBusqueda = false)
        {
            InitializeComponent();
            this.omitirBusqueda = omitirBusqueda;
        }

        /// <summary>
        /// Constructor de la clase FormPedidos.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormPedidos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los pedidos específicos de un cliente desde la base de datos y los muestra en un DataGridView.
        /// </summary>
        /// <param name="pedido">El ID del cliente cuyos pedidos se deben cargar.</param>
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
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga todos los pedidos desde la base de datos y los muestra en un DataGridView.
        /// </summary>
        public void CargarTodosPedidos()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    // Cargar todos los pedidos desde la base de datos
                    List<Pedido> pedidos = conexion.ObtenerTodosPedidos();

                    // Actualizar el DataGridView con los pedidos obtenidos
                    dgvPedido.DataSource = null;
                    dgvPedido.DataSource = pedidos;
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón cerrar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            this.Close();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Agregar Pedido.
        /// Abre el formulario para agregar un nuevo pedido y, si los datos son válidos, inserta el nuevo pedido en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            using (FormAgregarPedido formAgregar = new FormAgregarPedido())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Validar que la fecha no sea anterior al día de hoy
                    if (!LogicaNegocio.ValidarFechaAntigua(formAgregar.Fecha))
                    {
                        MessageBox.Show("Error en la fecha. No se puede ingresar una fecha anterior al día de hoy.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear una nueva instancia de Pedido con los datos ingresados
                    Pedido nuevoPedido = new Pedido
                    {
                        Estado = "Pendiente",
                        Met_pago = formAgregar.MetPag,
                        Fecha = formAgregar.Fecha,
                        Direccion = formAgregar.Direccion,
                        Clienteid = formAgregar.ClienteId
                    };

                    // Insertar el nuevo pedido en la base de datos
                    ConexionBdd conexion = new ConexionBdd();
                    if (conexion.InsertarPedido(nuevoPedido))
                    {
                        CargarTodosPedidos();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Manejador de evento para la carga del formulario de pedidos.
        /// Realiza la búsqueda de pedidos si no se omite la búsqueda y deshabilita el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <summary>
        /// Manejador de evento para la carga del formulario de pedidos.
        /// Realiza la búsqueda de pedidos si no se omite la búsqueda y deshabilita el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormPedidos_Load(object sender, EventArgs e)
        {
            if (!omitirBusqueda)
            {
                // Buscar pedido si no se omite la búsqueda
                BuscarPedido();
            }
            // Deshabilitar el DataGridView y limpiar la selección
            dgvPedido.Enabled = false;
            dgvPedido.ClearSelection();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Editar Producto.
        /// Permite la edición de los datos del pedido en el DataGridView y guarda los cambios al confirmar la edición.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            // Habilitar edición en el DataGridView si está deshabilitado
            if (!dgvPedido.Enabled)
            {
                dgvPedido.Enabled = true;
                btnEditarProducto.Text = "Guardar cambios";
            }
            else
            {
                try
                {
                    if (dgvPedido.CurrentRow != null)
                    {
                        // Crear una nueva instancia de Pedido con los datos actualizados
                        Pedido pedidoActualizado = new Pedido
                        {
                            Id = Convert.ToInt32(dgvPedido.CurrentRow.Cells["Id"].Value),
                            Estado = dgvPedido.CurrentRow.Cells["Estado"].Value.ToString(),
                            Met_pago = dgvPedido.CurrentRow.Cells["Met_pago"].Value.ToString(),
                            Fecha = Convert.ToDateTime(dgvPedido.CurrentRow.Cells["Fecha"].Value),
                            Direccion = dgvPedido.CurrentRow.Cells["Direccion"].Value.ToString(),
                            Clienteid = Convert.ToInt32(dgvPedido.CurrentRow.Cells["Clienteid"].Value)
                        };

                        // Validar que la fecha no sea anterior al día de hoy
                        if (!LogicaNegocio.ValidarFechaAntigua(pedidoActualizado.Fecha))
                        {
                            MessageBox.Show("Error en la fecha. No se puede ingresar una fecha anterior al día de hoy.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Actualizar los datos del pedido en la base de datos
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.ActualizarPedido(pedidoActualizado))
                            {
                                MessageBox.Show("Pedido actualizado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Recargar los pedidos del cliente actual
                                CargarPedidos(pedidoActualizado.Clienteid);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el pedido", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    // Deshabilitar edición en el DataGridView y cambiar el texto del botón
                    dgvPedido.Enabled = false;
                    btnEditarProducto.Text = "Editar pedido";
                    dgvPedido.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Buscar Pedido.
        /// Llama al método BuscarPedido para buscar un pedido específico.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            BuscarPedido();
        }

        /// <summary>
        /// Busca un pedido específico abriendo un formulario de selección de pedido.
        /// Carga el pedido seleccionado en el DataGridView.
        /// </summary>
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
