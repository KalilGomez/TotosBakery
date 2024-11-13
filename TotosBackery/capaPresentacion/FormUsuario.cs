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
    }
}
