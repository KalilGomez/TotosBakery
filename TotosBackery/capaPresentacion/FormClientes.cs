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
            dataGridView.AutoSize=true;
            dataGridView.BackgroundColor = ColorTranslator.FromHtml("#FFF0F5");
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.GridColor = ColorTranslator.FromHtml("#F5F5F5");
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.ReadOnly = true;

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





        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarFormularioSinBordes();
            EstablecerEstilo();
            CargarClientes(); // Cargar los clientes al iniciar el formulario
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

