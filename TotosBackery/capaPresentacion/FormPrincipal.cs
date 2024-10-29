using capaEntidades;
namespace capaPresentacion
{
    public partial class FormPrincipal : Form
    {
        private Usuario usuario;
        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            btnUsuarios.Enabled = false;
        }
        public void HabilitarBotonUsuarios()
        {
            if (usuario.Admin)
                btnUsuarios.Enabled = true;
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

        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}

