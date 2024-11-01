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
using capaDatos;

namespace capaPresentacion
{
    public partial class FormLogin : Form
    {
        Usuario usuarioAdmin = new Usuario("Administrador", "Administrador", "Administrador", "Administrador", true);
        bool estaConectado;
        public FormLogin()
        {
            InitializeComponent();
            //Bitmap imagen = new Bitmap(Application.StartupPath + @"\imagenes\login.jpg");
            //this.BackgroundImage = imagen;
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormClosed += FormLogin_FormClosed;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Error de ingreso", MessageBoxButtons.OK);
                    return;
                }

                if (txtUsuario.Text == "Administrador" && txtContraseña.Text == "Administrador")
                {
                    this.Hide();
                    FormPrincipal formPrincipal = new FormPrincipal(usuarioAdmin);
                    formPrincipal.HabilitarBotonUsuarios();
                    formPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña inválido, intente nuevamente", "Error al iniciar sesión", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción inesperada
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool estaConectado = ConexionBdd.Conectar();
            if (estaConectado)
                MessageBox.Show("conexion ok");
            else
                MessageBox.Show("Error de conexion");
        }
    }
}
