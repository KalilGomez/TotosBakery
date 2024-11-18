using System;
using System.Collections.Generic;
using System.Windows.Forms;
using capaDatos;
using capaEntidades;

namespace capaPresentacion
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarClientes()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    var clientes = conexion.ObtenerClientes(); // Cargar clientes desde la base de datos
                    DGVClientes.DataSource = clientes;
                    DGVClientes.Enabled = false;
                    DGVClientes.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            using (FormAgregarCliente formAgregar = new FormAgregarCliente())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    Cliente nuevoCliente = new Cliente(id: 0, nombre: formAgregar.Nombre,
                        apellido: formAgregar.Apellido, telefono: formAgregar.Telefono, mail: formAgregar.Mail, direccion: formAgregar.Direccion);

                    bool insertado = ConexionBdd.InsertarCliente(nuevoCliente); // Llamada estática

                    if (insertado)
                    {
                        MessageBox.Show("Cliente agregado correctamente.");
                        CargarClientes(); // Refrescar el DataGridView con la nueva lista de clientes
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el cliente.");
                    }
                }
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
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
                        Cliente clienteActualizado = new Cliente
                        {
                            Id = Convert.ToInt32(DGVClientes.CurrentRow.Cells["Id"].Value),
                            Nombre = DGVClientes.CurrentRow.Cells["Nombre"].Value.ToString(),
                            Apellido = DGVClientes.CurrentRow.Cells["Apellido"].Value.ToString(),
                            Telefono = DGVClientes.CurrentRow.Cells["Telefono"].Value.ToString(),
                            Mail = DGVClientes.CurrentRow.Cells["Mail"].Value.ToString(),
                            Direccion = DGVClientes.CurrentRow.Cells["Direccion"].Value.ToString()
                        };

                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.ActualizarCliente(clienteActualizado))
                            {
                                MessageBox.Show("Cliente actualizado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarClientes(); // Refrescar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el cliente", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

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
                // Verificar si hay una fila seleccionada
                if (DGVClientes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del cliente seleccionado
                    int idCliente = Convert.ToInt32(DGVClientes.SelectedRows[0].Cells["Id"].Value);

                    // Confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        // Conexión a la base de datos y eliminación del cliente
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarCliente(idCliente))
                            {
                                MessageBox.Show("Cliente eliminado correctamente.");
                                CargarClientes(); // Refrescar el DataGridView después de la eliminación
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
                // Restablecer el estado del botón y del DataGridView
                DGVClientes.Enabled = false;
                BtnEliminar.Text = "Eliminar cliente";
                DGVClientes.ClearSelection();
            }
        }

    }
}

