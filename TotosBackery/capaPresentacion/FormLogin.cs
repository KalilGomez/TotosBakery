using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using capaEntidades;
using capaNegocio;

namespace capaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            EstablecerEstilo();
            ConfigurarFormularioSinBordes();
            /*
              #f4c1a4 | #e9b79f | #e6a7a2 | #f2e9ba | #d6c99a
             */
            this.FormClosed += FormLogin_FormClosed;
        }
        private void EstablecerEstilo()
        {
            // Configuración base del formulario
            this.Size = new Size(800, 400);
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
        private Point lastPoint;

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



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposVacios())
            {
                return;
            }

            try
            {
                Usuario usuarioEncontrado = LogicaNegocio.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);

                if (usuarioEncontrado != null)
                {
                    this.Hide();
                    FormPrincipal formPrincipal = new FormPrincipal();
                    if (usuarioEncontrado.Admin==true)
                    {
                        formPrincipal.HabilitarBotonUsuarios();
                    }
                    formPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña inválido, intente nuevamente",
                                   "Error al iniciar sesión",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
        private void btnRstPwd_Click(object sender, EventArgs e)
        {
            string usuario = "";
            using (FormResetPwd formReset = new FormResetPwd())
            {
                if (formReset.ShowDialog() == DialogResult.OK)
                {
                    usuario = formReset.Usuario;
                    if (!string.IsNullOrEmpty(usuario))
                    {
                        bool reset = ConexionBdd.ResetearContraseña(usuario);
                        if (reset)
                        {
                            MessageBox.Show("La contraseña ha sido restablecida exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo restablecer la contraseña. Verifique el nombre de usuario.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario no válido.");
                    }
                }
            }
        }
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciarSesion.PerformClick(); // Simula el clic del botón
            }
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un usuario",
                               "Campo requerido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña",
                               "Campo requerido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }
            return true;
        }
    }
}
