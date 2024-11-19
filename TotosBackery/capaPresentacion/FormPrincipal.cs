using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;

namespace capaPresentacion
{
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// Constructor de la clase FormPrincipal.
        /// Inicializa los componentes, configura el formulario sin bordes y aplica el estilo.
        /// También deshabilita el botón de usuarios al inicio.
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarFormularioSinBordes();
            EstablecerEstilo();
            btnUsuarios.Enabled = false;
        }

        /// <summary>
        /// Punto para almacenar la última posición del cursor, utilizado para mover el formulario.
        /// </summary>
        private Point lastPoint;

        /// <summary>
        /// Aplica estilo al formulario, ajustando su tamaño, posición y color de fondo.
        /// Recorre los controles existentes y aplica estilos específicos a los botones.
        /// </summary>
        private void EstablecerEstilo()
        {
            // Configuración base del formulario
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#FFF0F5");

            // Recorrer los controles existentes y aplicar estilos
            foreach (Control control in this.Controls)
            {
                // Aplicar estilos según el tipo de control
                switch (control)
                {
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                }
            }
        }

        /// <summary>
        /// Aplica estilo a un botón, ajustando su apariencia y eventos de hover.
        /// Se enfoca en botones con los textos "Clientes", "Productos", "Usuarios", "Pedidos" y "cerrar sesion".
        /// </summary>
        /// <param name="button">El botón al que se aplicarán los estilos.</param>
        private void EstilizarBoton(Button button)
        {
            // Verificar si el texto del botón contiene "Clientes", "Productos", "Usuarios" o "Pedidos"
            if (new[] { "Clientes", "Productos", "Usuarios", "Pedidos" }
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

            // Verificar si el texto del botón contiene "cerrar sesion"
            if (button.Text.Contains("cerrar sesion", StringComparison.OrdinalIgnoreCase))
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

        /// <summary>
        /// Configura el formulario para que no tenga bordes y agrega botones personalizados para cerrar y minimizar.
        /// También permite que el formulario se pueda mover arrastrándolo.
        /// </summary>
        private void ConfigurarFormularioSinBordes()
        {
            // Configuración básica del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Agregar botón de cerrar
            Button btnCerrar = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(this.Width - 30, 5),
                Text = "×",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            // Agregar botón minimizar
            Button btnMinimizar = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(this.Width - 55, 5),
                Text = "―",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.Controls.Add(btnMinimizar);

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

        /// <summary>
        /// Habilita el botón de usuarios, permitiendo su uso.
        /// </summary>
        public void HabilitarBotonUsuarios()
        {
            // Habilitar el botón de usuarios
            btnUsuarios.Enabled = true;
        }

        /// <summary>
        /// Manejador de evento para el pintado del botón.
        /// Dibuja un borde blanco alrededor del botón.
        /// </summary>
        /// <param name="sender">El botón que envía el evento.</param>
        /// <param name="e">Los datos del evento de dibujo.</param>
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

        /// <summary>
        /// Manejador de evento para el clic del botón de clientes.
        /// Crea una nueva instancia del formulario de clientes y la muestra.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de clientes
            Form formClientes = new FormClientes();
            // Mostrar el formulario de clientes
            formClientes.Show();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de productos.
        /// Crea una nueva instancia del formulario de productos y la muestra.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de productos
            Form formProductos = new FormProductos();
            // Mostrar el formulario de productos
            formProductos.Show();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de pedidos.
        /// Crea una nueva instancia del formulario de pedidos y la muestra.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de pedidos
            Form formPedidos = new FormPedidos();
            // Mostrar el formulario de pedidos
            formPedidos.Show();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de usuarios.
        /// Crea una nueva instancia del formulario de usuario y la muestra.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de usuario
            FormUsuario formUsuario = new FormUsuario();
            // Mostrar el formulario de usuario
            formUsuario.Show();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de cerrar sesión.
        /// Oculta el formulario actual, muestra el formulario de inicio de sesión y cierra el formulario principal después.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual
            this.Hide();

            // Crear y mostrar el formulario de inicio de sesión
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();

            // Después de cerrar el formulario de inicio de sesión, cerrar el formulario principal
            this.Close();
        }

        /// <summary>
        /// Manejador de evento para el cierre del formulario principal.
        /// Cierra la aplicación si no hay otros formularios abiertos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Verificar si no está dispuesto y si solo hay un formulario abierto en la aplicación
            if (!IsDisposed && Application.OpenForms.Count == 1)
            {
                // Cerrar la aplicación
                Application.Exit();
            }
        }

    }
}
