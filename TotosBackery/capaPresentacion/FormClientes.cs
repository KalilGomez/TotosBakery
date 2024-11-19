using System;
using System.Collections.Generic;
using System.Windows.Forms;
using capaDatos;
using capaEntidades;
using capaNegocio;

namespace capaPresentacion
{
    public partial class FormClientes : Form
    {
        /// <summary>
        /// Constructor de la clase FormClientes.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormClientes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador de evento para la carga del formulario de clientes.
        /// Llama al método CargarClientes para cargar los datos de clientes.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormClientes_Load(object sender, EventArgs e)
        {
            // Cargar los datos de clientes
            CargarClientes();
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
        /// Carga los datos de clientes desde la base de datos y los muestra en un DataGridView.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                // Crear una nueva conexión a la base de datos
                using (var conexion = new ConexionBdd())
                {
                    // Obtener la lista de clientes desde la base de datos
                    var clientes = conexion.ObtenerClientes();
                    // Asignar los datos al DataGridView
                    DGVClientes.DataSource = clientes;
                    // Deshabilitar la edición en el DataGridView
                    DGVClientes.Enabled = false;
                    // Limpiar la selección en el DataGridView
                    DGVClientes.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Agregar.
        /// Abre el formulario para agregar un nuevo cliente y, si los datos son válidos, inserta el nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para agregar un nuevo cliente
            using (FormAgregarCliente formAgregar = new FormAgregarCliente())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Validar que el nombre y apellido solo contengan letras
                        if (!LogicaNegocio.ValidarSoloLetas(formAgregar.Nombre, formAgregar.Apellido))
                        {
                            MessageBox.Show("Error en el nombre o apellido. Solo se permiten letras.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validar que el teléfono contenga solo dígitos numéricos
                        if (!LogicaNegocio.ValidarTelefonoEsEntero(formAgregar.Telefono))
                        {
                            MessageBox.Show("Error en el teléfono. Debe contener dígitos numéricos.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validar que el correo electrónico tenga un formato válido
                        if (!LogicaNegocio.ValidarCorreo(formAgregar.Mail))
                        {
                            MessageBox.Show("Error en el correo electrónico. Formato inválido.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Crear una nueva instancia de Cliente con los datos ingresados
                        Cliente nuevoCliente = new Cliente(
                            id: 0,
                            nombre: formAgregar.Nombre,
                            apellido: formAgregar.Apellido,
                            telefono: formAgregar.Telefono,
                            mail: formAgregar.Mail,
                            direccion: formAgregar.Direccion
                        );

                        // Insertar el nuevo cliente en la base de datos
                        bool insertado = ConexionBdd.InsertarCliente(nuevoCliente);
                        if (insertado)
                        {
                            MessageBox.Show("Cliente agregado correctamente.");
                            // Recargar los datos de clientes
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el cliente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Se produjo un error inesperado: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Editar.
        /// Permite la edición de los datos de clientes en el DataGridView y guarda los cambios al confirmar la edición.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Habilitar edición en el DataGridView si está deshabilitado
            if (!DGVClientes.Enabled)
            {
                DGVClientes.Enabled = true;
                BtnEditar.Text = "Guardar cambios";
            }
            else
            {
                try
                {
                    if (DGVClientes.CurrentRow != null)
                    {
                        try
                        {
                            // Crear una nueva instancia de Cliente con los datos actualizados
                            Cliente clienteActualizado = new Cliente
                            {
                                Id = Convert.ToInt32(DGVClientes.CurrentRow.Cells["Id"].Value),
                                Nombre = DGVClientes.CurrentRow.Cells["Nombre"].Value.ToString(),
                                Apellido = DGVClientes.CurrentRow.Cells["Apellido"].Value.ToString(),
                                Telefono = DGVClientes.CurrentRow.Cells["Telefono"].Value.ToString(),
                                Mail = DGVClientes.CurrentRow.Cells["Mail"].Value.ToString(),
                                Direccion = DGVClientes.CurrentRow.Cells["Direccion"].Value.ToString()
                            };

                            // Validar que el nombre y apellido solo contengan letras
                            if (!LogicaNegocio.ValidarSoloLetas(clienteActualizado.Nombre, clienteActualizado.Apellido))
                            {
                                MessageBox.Show("Error en el nombre o apellido. Solo se permiten letras.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Validar que el teléfono contenga solo dígitos numéricos
                            if (!LogicaNegocio.ValidarTelefonoEsEntero(clienteActualizado.Telefono))
                            {
                                MessageBox.Show("Error en el teléfono. Debe contener dígitos numéricos.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Validar que el correo electrónico tenga un formato válido
                            if (!LogicaNegocio.ValidarCorreo(clienteActualizado.Mail))
                            {
                                MessageBox.Show("Error en el correo electrónico. Formato inválido.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Actualizar los datos del cliente en la base de datos
                            using (var conexion = new ConexionBdd())
                            {
                                if (conexion.ActualizarCliente(clienteActualizado))
                                {
                                    MessageBox.Show("Cliente actualizado correctamente", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Refrescar el DataGridView
                                    CargarClientes();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar el cliente", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Se produjo un error inesperado: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Deshabilitar edición en el DataGridView y cambiar el texto del botón
                    DGVClientes.Enabled = false;
                    BtnEditar.Text = "Editar cliente";
                    DGVClientes.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Eliminar.
        /// Permite la selección de un cliente en el DataGridView para eliminarlo, 
        /// y realiza la eliminación si se confirma la acción.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Cambiar el estado del DataGridView para permitir la selección
            if (DGVClientes.Enabled == false)
            {
                DGVClientes.Enabled = true;
                BtnEliminar.Text = "Aceptar";
                DGVClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVClientes.MultiSelect = false;
                DGVClientes.ClearSelection();
            }
            else
            {
                if (DGVClientes.SelectedRows.Count > 0)
                {
                    int idCliente = Convert.ToInt32(DGVClientes.SelectedRows[0].Cells["Id"].Value);

                    // Confirmar la eliminación del cliente
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        // Eliminar el cliente seleccionado
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarCliente(idCliente))
                            {
                                MessageBox.Show("Cliente eliminado correctamente.");
                                CargarClientes(); // Refrescar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar el cliente.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para eliminar.");
                }
                // Cambiar el estado del DataGridView para deshabilitar la selección
                DGVClientes.Enabled = false;
                BtnEliminar.Text = "Eliminar cliente";
                DGVClientes.ClearSelection();
            }
        }
    }
}

