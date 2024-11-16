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
        private Usuario usuario;
        public FormPrincipal()
        {
            InitializeComponent();
            EstablecerEstilo();
            btnUsuarios.Enabled = false;
        }
        private void EstablecerEstilo()
        {
            // Configuración base del formulario
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Panel izquierdo violeta (ya existente, solo actualizamos el estilo)
            Panel panelIzquierdo = this.Controls.OfType<Panel>().FirstOrDefault();
            if (panelIzquierdo == null)
            {
                panelIzquierdo = new Panel();
                this.Controls.Add(panelIzquierdo);
            }
            panelIzquierdo.Size = new Size(250, 400);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.BackColor = ColorTranslator.FromHtml("#d6c99a");

            // Recorrer los controles existentes y aplicar estilos
            foreach (Control control in this.Controls)
            {
                // Excluir el panel izquierdo del procesamiento
                if (control == panelIzquierdo) continue;

                // Aplicar estilos según el tipo de control
                switch (control)
                {
                    case TextBox txt:
                        EstilizarTextBox(txt);
                        break;
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                    case LinkLabel link:
                        EstilizarLink(link);
                        break;
                    case Label lbl:
                        EstilizarLabel(lbl);
                        break;
                    case CheckBox chk:
                        EstilizarCheckBox(chk);
                        break;
                }
            }
        }
        private void EstilizarTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.White;
            textBox.Font = new Font("Segoe UI", 10);

            // Crear o encontrar la línea debajo del TextBox
            string lineaName = "linea_" + textBox.Name;
            Panel linea = this.Controls.OfType<Panel>()
                             .FirstOrDefault(p => p.Name == lineaName);

            if (linea == null)
            {
                linea = new Panel
                {
                    Name = lineaName,
                    Size = new Size(textBox.Width, 1),
                    Location = new Point(textBox.Left, textBox.Bottom + 1),
                    BackColor = ColorTranslator.FromHtml("#d6c99a")
                };
                this.Controls.Add(linea);
            }
            linea.BringToFront();
        }
        private void EstilizarBoton(Button button)
        {
            if (button.Text.Contains("sesión", StringComparison.OrdinalIgnoreCase))
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = ColorTranslator.FromHtml("#e9b79f");
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;

                // Eventos hover
                button.MouseEnter += (s, e) => {
                    button.BackColor = ColorTranslator.FromHtml("#e9b79f"); // Violeta más oscuro
                };
                button.MouseLeave += (s, e) => {
                    button.BackColor = ColorTranslator.FromHtml("#e6a7a2");
                };
            }
            else if (button.Text.Equals("Register", StringComparison.OrdinalIgnoreCase))
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.ForeColor = Color.FromArgb(149, 117, 205);
                button.Font = new Font("Segoe UI", 10);
                button.FlatAppearance.BorderColor = Color.FromArgb(149, 117, 205);
                button.FlatAppearance.BorderSize = 1;
                button.Cursor = Cursors.Hand;

                // Eventos hover
                button.MouseEnter += (s, e) => {
                    button.BackColor = Color.FromArgb(149, 117, 205);
                    button.ForeColor = Color.White;
                };
                button.MouseLeave += (s, e) => {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.FromArgb(149, 117, 205);
                };
            }
        }
        private void EstilizarLink(LinkLabel link)
        {
            link.LinkColor = Color.Red;
            link.ActiveLinkColor = Color.FromArgb(129, 97, 185);
            link.Font = new Font("Segoe UI", 9);
            link.LinkBehavior = LinkBehavior.HoverUnderline;
        }
        private void EstilizarLabel(Label label)
        {
            if (label.Text.Contains("BIENVENIDO", StringComparison.OrdinalIgnoreCase))
            {
                label.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                label.Font = new Font("Segoe UI", 10);
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }
        private void EstilizarCheckBox(CheckBox checkBox)
        {
            checkBox.ForeColor = Color.FromArgb(64, 64, 64);
            checkBox.Font = new Font("Segoe UI", 9);
        }
        public void HabilitarBotonUsuarios()
        {
            btnUsuarios.Enabled = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form formClientes= new FormClientes();
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
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
