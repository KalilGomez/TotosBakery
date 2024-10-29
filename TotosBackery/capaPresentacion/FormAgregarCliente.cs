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
    public partial class FormAgregarCliente : Form
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        public string Mail { get; private set; }
        public FormAgregarCliente()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Direccion = txtDireccion.Text;
            Telefono = txtTelefono.Text;
            Mail = txtMail.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}