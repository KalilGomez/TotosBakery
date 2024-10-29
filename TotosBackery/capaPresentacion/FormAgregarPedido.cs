using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class FormAgregarPedido : Form
    {
        public string Cliente { get; private set; }
        public string Direccion { get; private set; }
        public DateTime Fecha { get; private set; }
        public string MetPag { get; private set; }
        public FormAgregarPedido()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(cboxCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtDir.Text) ||
                    string.IsNullOrWhiteSpace(dtpFecha.Text) ||
                    string.IsNullOrWhiteSpace(cboxMetPag.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                Cliente = cboxCliente.ToString();
                Direccion = txtDir.Text;
                Fecha = dtpFecha.Value;
                MetPag = cboxMetPag.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
