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
            btnUsuarios.Enabled = false;
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
