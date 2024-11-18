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
        private Point lastPoint;
        private void EstablecerEstilo()
        {
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#FFF0F5");
            foreach (Control control in this.Controls)
            {
                switch (control)
                {
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                    case DataGridView dgv:
                        EstilizarDataGridView(dgv);
                        break;
                }
            }
        }
        private void EstilizarBoton(Button button)
        {

            if (new[] { "agregar", "editar", "eliminar" }
            .Any(keyword => button.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;


                // Eventos hover
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#E30B5C");
                };
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                };
                button.Paint += Button_Paint;
            }
            if (button.Text.Contains("salir", StringComparison.OrdinalIgnoreCase))
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = ColorTranslator.FromHtml("#F08080");
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;


                // Eventos hover
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#DC143C");
                };
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#F08080");
                };
                button.Paint += Button_Paint;
            }
        }
        private void ConfigurarFormularioSinBordes()
        {
            // Configuración básica del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnCerrar = new Button
            {
                Size = new Size(25, 25),
                Text = "×",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            // Crear y configurar botón de minimizar
            Button btnMinimizar = new Button
            {
                Size = new Size(25, 25),
                Text = "―",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.Controls.Add(btnMinimizar);

            // Ajustar botones en eventos relevantes
            this.Load += (s, e) =>
            {
                AjustarBotones(btnCerrar, 0); // Botón de cerrar: sin desplazamiento adicional
                AjustarBotones(btnMinimizar, btnCerrar.Width + 5); // Botón de minimizar: a la izquierda del de cerrar
            };

            this.Resize += (s, e) =>
            {
                AjustarBotones(btnCerrar, 0);
                AjustarBotones(btnMinimizar, btnCerrar.Width + 5);
            };

            // Eventos para mover el formulario
            this.MouseDown += (s, e) =>
            {
                lastPoint = new Point(e.X, e.Y);
            };

            this.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - lastPoint.X;
                    this.Top += e.Y - lastPoint.Y;
                }
            };

            // Efectos hover para los botones
            btnCerrar.MouseEnter += (s, e) => btnCerrar.ForeColor = Color.Red;
            btnCerrar.MouseLeave += (s, e) => btnCerrar.ForeColor = Color.DimGray;

            btnMinimizar.MouseEnter += (s, e) => btnMinimizar.ForeColor = Color.Gray;
            btnMinimizar.MouseLeave += (s, e) => btnMinimizar.ForeColor = Color.DimGray;
        }
        void AjustarBotones(Button button, int offset)
        {
            int margen = 5; // Espacio entre botones
            button.Location = new Point(this.ClientSize.Width - button.Width - margen - offset, margen);
        }
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Dibujar borde blanco
                Pen pen = new Pen(Color.White, 1); // Color blanco y grosor 2
                Rectangle rect = btn.ClientRectangle;
                rect.Width -= 1; // Ajustar ancho del rectángulo
                rect.Height -= 1; // Ajustar alto del rectángulo
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void EstilizarDataGridView(DataGridView dataGridView)
        {
            // Estilo general del DataGridView
            dataGridView.AutoSize = true;
            dataGridView.BackgroundColor = ColorTranslator.FromHtml("#FFF0F5");
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.GridColor = ColorTranslator.FromHtml("#F5F5F5");
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.ReadOnly = true;
            dataGridView.Columns["Contraseña"].Visible = false;

            // Configuración del encabezado de columna
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = ColorTranslator.FromHtml("#333333"),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView.EnableHeadersVisualStyles = false;

            // Configuración de las filas
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = ColorTranslator.FromHtml("#FFFFFF"),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = ColorTranslator.FromHtml("#E30B5C"),
                SelectionForeColor = Color.White
            };
            dataGridView.DefaultCellStyle = rowStyle;

            // Alternar colores en filas
            dataGridView.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D3D3D3");
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#BBBBBB");

            // Configuración de bordes y líneas
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Ajustar las columnas al tamaño del contenido
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Quitar los encabezados de las filas (opcional)
            dataGridView.RowHeadersVisible = false;

            // Estilo del borde de selección
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.AllowUserToAddRows = false;
        }




        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            EstablecerEstilo();
            ConfigurarFormularioSinBordes();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
