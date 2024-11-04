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
        bool estaConectado;
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
            // Establecer fondo del formulario
            this.BackColor = Color.FromArgb(240, 240, 240); // Gris claro

            // Establecer estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(0, 123, 255); // Azul
                    button.ForeColor = Color.White; // Texto blanco
                    button.FlatStyle = FlatStyle.Flat; // Estilo plano
                    button.Font = new Font("Arial", 10); // Fuente
                }
                // Establecer estilo para TextBoxes
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White; // Fondo blanco
                    textBox.ForeColor = Color.FromArgb(51, 51, 51); // Texto gris oscuro
                    textBox.Font = new Font("Arial", 10); // Fuente
                }
                // Establecer estilo para labels
                else if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(51, 51, 51); // Texto gris oscuro
                    label.Font = new Font("Arial", 10); // Fuente
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
                    if (usuarioEncontrado.Admin==1)
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
