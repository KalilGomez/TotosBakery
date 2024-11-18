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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            try
            {
                var clientes = ConexionBdd.ObtenerUsuarios(); // Cargar clientes desde la base de datos
                dgvUsuario.DataSource = clientes;
                dgvUsuario.Enabled = false;
                dgvUsuario.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FormAgregarUsuario formAgregar = new FormAgregarUsuario())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Validación básica
                        if (string.IsNullOrWhiteSpace(formAgregar.Nombre) ||
                            string.IsNullOrWhiteSpace(formAgregar.Apellido) ||
                            string.IsNullOrWhiteSpace(formAgregar.Usuario) ||
                            string.IsNullOrWhiteSpace(formAgregar.Contraseña))
                        {
                            MessageBox.Show("Todos los campos son obligatorios.",
                                          "Error de validación",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }

                        Usuario nuevoUsuario = new Usuario(
                            id: 0,  // El ID probablemente se genera en la base de datos
                            nombre: formAgregar.Nombre.Trim(),
                            apellido: formAgregar.Apellido.Trim(),
                            user: formAgregar.Usuario.Trim(),
                            contraseña: formAgregar.Contraseña,
                            Convert.ToBoolean(formAgregar.Admin)
                        );

                        // Pasamos el nuevoUsuario como parámetro
                        bool insertado = ConexionBdd.InsertarUsuario(nuevoUsuario);

                        if (insertado)
                        {
                            MessageBox.Show("Usuario agregado correctamente.",
                                          "Éxito",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                            CargarUsuarios(); // Refrescar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el usuario.",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!dgvUsuario.Enabled)
            {
                dgvUsuario.Enabled = true;
                btnEditar.Text = "Guardar cambios";
            }
            else
            {
                try
                {
                    if (dgvUsuario.CurrentRow != null)
                    {
                        Usuario usuarioActualizado = new Usuario
                        {
                            Id = Convert.ToInt32(dgvUsuario.CurrentRow.Cells["Id"].Value),
                            Nombre = dgvUsuario.CurrentRow.Cells["Nombre"].Value.ToString(),
                            Apellido = dgvUsuario.CurrentRow.Cells["Apellido"].Value.ToString(),
                            User = dgvUsuario.CurrentRow.Cells["user"].Value.ToString(),
                            Contraseña = dgvUsuario.CurrentRow.Cells["Contraseña"].Value.ToString(),
                            Admin = Convert.ToBoolean(dgvUsuario.CurrentRow.Cells["admin"].Value)
                        };
                        if (!ValidarCamposNoVacios(usuarioActualizado))
                        {
                            return; // Si alguna validación falla, no continuar con la actualización
                        }

                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.ActualizarUsuario(usuarioActualizado))
                            {
                                MessageBox.Show("Usuario actualizado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarUsuarios(); // Refrescar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el usuario", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    dgvUsuario.Enabled = false;
                    btnEditar.Text = "Editar cliente";
                    dgvUsuario.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Cambiar el estado del DataGridView para permitir la selección
            if (dgvUsuario.Enabled == false)
            {
                dgvUsuario.Enabled = true;
                btnEliminar.Text = "Aceptar";
                dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsuario.MultiSelect = false;
                dgvUsuario.ClearSelection();
            }
            else
            {
                // Verificar si hay una fila seleccionada
                if (dgvUsuario.SelectedRows.Count > 0)
                {
                    // Obtener el ID del cliente seleccionado
                    int idUsuario = Convert.ToInt32(dgvUsuario.SelectedRows[0].Cells["Id"].Value);

                    // Confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        // Conexión a la base de datos y eliminación del cliente
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarUsuario(idUsuario))
                            {
                                MessageBox.Show("Cliente eliminado correctamente.");
                                CargarUsuarios(); // Refrescar el DataGridView después de la eliminación
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
                dgvUsuario.Enabled = false;
                btnEliminar.Text = "Eliminar cliente";
                dgvUsuario.ClearSelection();
            }
        }
        private bool ValidarCamposNoVacios(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre) ||
                string.IsNullOrWhiteSpace(usuario.Apellido) ||
                string.IsNullOrWhiteSpace(usuario.User) ||
                string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
