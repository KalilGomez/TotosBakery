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
    public partial class FormUsuario : Form
    {
        /// <summary>
        /// Constructor de la clase FormUsuario.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador de evento para la carga del formulario de usuarios.
        /// Llama al método CargarUsuarios para cargar los datos de usuarios.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        /// <summary>
        /// Carga los datos de usuarios desde la base de datos y los muestra en un DataGridView.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                // Obtener la lista de usuarios desde la base de datos
                var clientes = ConexionBdd.ObtenerUsuarios();
                // Asignar los datos al DataGridView
                dgvUsuario.DataSource = clientes;
                // Deshabilitar la edición en el DataGridView
                dgvUsuario.Enabled = false;
                // Limpiar la selección en el DataGridView
                dgvUsuario.ClearSelection();
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
        /// Abre el formulario para agregar un nuevo usuario y, si los datos son válidos, inserta el nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FormAgregarUsuario formAgregar = new FormAgregarUsuario())
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

                        // Crear una nueva instancia de Usuario con los datos ingresados
                        Usuario nuevoUsuario = new Usuario(
                            id: 0,  // El ID probablemente se genera en la base de datos
                            nombre: formAgregar.Nombre.Trim(),
                            apellido: formAgregar.Apellido.Trim(),
                            user: formAgregar.Usuario.Trim(),
                            contraseña: formAgregar.Contraseña,
                            Convert.ToBoolean(formAgregar.Admin)
                        );

                        // Pasar el nuevoUsuario como parámetro
                        bool insertado = ConexionBdd.InsertarUsuario(nuevoUsuario);

                        if (insertado)
                        {
                            MessageBox.Show("Usuario agregado correctamente.",
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refrescar el DataGridView
                            CargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el usuario.",
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Editar.
        /// Permite la edición de los datos del usuario en el DataGridView y guarda los cambios al confirmar la edición.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Habilitar edición en el DataGridView si está deshabilitado
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
                        // Crear una nueva instancia de Usuario con los datos actualizados
                        Usuario usuarioActualizado = new Usuario
                        {
                            Id = Convert.ToInt32(dgvUsuario.CurrentRow.Cells["Id"].Value),
                            Nombre = dgvUsuario.CurrentRow.Cells["Nombre"].Value.ToString(),
                            Apellido = dgvUsuario.CurrentRow.Cells["Apellido"].Value.ToString(),
                            User = dgvUsuario.CurrentRow.Cells["user"].Value.ToString(),
                            Contraseña = dgvUsuario.CurrentRow.Cells["Contraseña"].Value.ToString(),
                            Admin = Convert.ToBoolean(dgvUsuario.CurrentRow.Cells["admin"].Value)
                        };

                        // Validar que el nombre y apellido solo contengan letras
                        if (!LogicaNegocio.ValidarSoloLetas(usuarioActualizado.Nombre, usuarioActualizado.Apellido))
                        {
                            MessageBox.Show("Error en el nombre o apellido. Solo se permiten letras.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Actualizar los datos del usuario en la base de datos
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.ActualizarUsuario(usuarioActualizado))
                            {
                                MessageBox.Show("Usuario actualizado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Refrescar el DataGridView
                                CargarUsuarios();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el usuario", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Deshabilitar edición en el DataGridView y cambiar el texto del botón
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

        /// <summary>
        /// Manejador de evento para el clic del botón Eliminar.
        /// Permite la selección de un usuario en el DataGridView para eliminarlo, 
        /// y realiza la eliminación si se confirma la acción.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
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
                if (dgvUsuario.SelectedRows.Count > 0)
                {
                    int idUsuario = Convert.ToInt32(dgvUsuario.SelectedRows[0].Cells["Id"].Value);

                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarUsuario(idUsuario))
                            {
                                MessageBox.Show("Cliente eliminado correctamente.");
                                // Refrescar el DataGridView después de la eliminación
                                CargarUsuarios();
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
                dgvUsuario.Enabled = false;
                btnEliminar.Text = "Eliminar cliente";
                dgvUsuario.ClearSelection();
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Salir.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
