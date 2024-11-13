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
            //Bitmap imagen = new Bitmap(Application.StartupPath + @"\imagenes\login.jpg");
            //this.BackgroundImage = imagen;
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormClosed += FormLogin_FormClosed;
        }
        private void EstablecerEstilo()
        {
            // Establecer fondo del formulario a un color gris
            this.BackColor = ColorTranslator.FromHtml("#808080");

            // Panel azul a la izquierda
            Panel panelIzquierdo = new Panel
            {
                BackColor = ColorTranslator.FromHtml("#0073E6"),
                Dock = DockStyle.Left,
                Width = 150 // Ajusta este valor según sea necesario
            };
            this.Controls.Add(panelIzquierdo);

            // Estilo para los labels (Título, Usuario, Contraseña)
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.White;
                    label.Font = new Font("Segoe UI Light", 10);
                    if (label.Text.Equals("LOGIN", StringComparison.OrdinalIgnoreCase))
                    {
                        label.Font = new Font("Segoe UI Light", 20, FontStyle.Regular); // Título más grande
                    }
                }
            }

            // Estilo para los TextBoxes y líneas debajo
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.BackColor = ColorTranslator.FromHtml("#808080");
                    textBox.ForeColor = Color.White;
                    textBox.Font = new Font("Segoe UI", 10);

                    // Línea debajo del TextBox
                    Panel linea = new Panel
                    {
                        BackColor = Color.White,
                        Height = 1,
                        Width = textBox.Width,
                        Location = new Point(textBox.Left, textBox.Bottom + 1) // Posición ajustada
                    };
                    this.Controls.Add(linea);
                    linea.BringToFront();
                }
            }

            // Estilo para el botón "Iniciar Sesión"
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorTranslator.FromHtml("#333333");
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 0;
                }
            }

            // Estilo para el LinkLabel "Olvidé la contraseña"
            foreach (Control control in this.Controls)
            {
                if (control is LinkLabel linkLabel)
                {
                    linkLabel.LinkColor = ColorTranslator.FromHtml("#808080");
                    linkLabel.Font = new Font("Segoe UI", 8, FontStyle.Underline);
                    linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
                }
            }
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
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
            Form formResetPassword = new FormResetPwd();
            formResetPassword.Show();
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
        private bool ValidarCampos()
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
