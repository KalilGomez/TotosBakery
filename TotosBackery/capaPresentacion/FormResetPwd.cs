using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class FormResetPwd : Form
    {
        public string Usuario { get; private set; }
        public FormResetPwd()
        {
            InitializeComponent();
        }

        private void btnEnviarReset_Click(object sender, EventArgs e)
        {
            Usuario = txtUsuario.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
