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
        public FormResetPwd()
        {
            InitializeComponent();
        }

        private void btnEnviarReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La contraseña fue cambiada a: 1234", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
