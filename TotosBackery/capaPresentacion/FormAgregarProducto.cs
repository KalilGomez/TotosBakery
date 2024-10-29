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
    public partial class FormAgregarProducto : Form
    {
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public double Precio { get; private set; }
        public int Cantidad { get; private set; }
        public FormAgregarProducto()
        {
            InitializeComponent();
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            Nombre = txtNombre.Text;
            Descripcion = txtDescripcion.Text;
            Precio = double.Parse(txtPrecio.Text);
            Cantidad = int.Parse(txtCantidad.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            Nombre = txtNombre.Text;
            Descripcion = txtDescripcion.Text;
            Precio = int.Parse(txtPrecio.Text);
            Cantidad = int.Parse(txtCantidad.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
