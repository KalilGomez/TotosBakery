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
        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarFormularioSinBordes();
            EstablecerEstilo();
            btnUsuarios.Enabled = false;
        }
        private Point lastPoint;
        private void EstablecerEstilo()
        {
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#FFF0F5");
            foreach (Control control in this.Controls)
            {
                switch (control)
                {
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                }
            }
        }
        private void EstilizarBoton(Button button)
        {
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
        }
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
        public void HabilitarBotonUsuarios()
        {
            btnUsuarios.Enabled = true;
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




        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form formClientes = new FormClientes();
            formClientes.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form formProductos = new FormProductos();
            formProductos.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form formPedidos = new FormPedidos();
            formPedidos.Show();
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.Show();
        }
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Hide current form
            this.Hide();

            // Create and show login form
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();

            // After login form is closed, close the main form
            this.Close();
        }
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Remove the recursive call to BtnCerrarSesion_Click
            if (!IsDisposed && Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }
    }
}
