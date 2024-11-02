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
    public partial class FormUsuario : Form
    {
        List<Usuario> usuario=new List<Usuario>();
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = usuario;
            dgvUsuario.Enabled = false;
            dgvUsuario.ClearSelection();
        }
    }
}
