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
            if (!ValidarPrecio()) return;
            if (!ValidarCantidad()) return;

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
            if (!ValidarPrecio()) return;
            if (!ValidarCantidad()) return;
            Nombre = txtNombre.Text;
            Descripcion = txtDescripcion.Text;
            Precio = int.Parse(txtPrecio.Text);
            Cantidad = int.Parse(txtCantidad.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarPrecio()
        {
            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("El precio ingresado no es válido. Debe ser un número.");
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor que cero.");
                return false;
            }

            return true;
        }
        private bool ValidarCantidad()
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad ingresada no es válida. Debe ser un número entero.");
                return false;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor que cero.");
                return false;
            }

            return true;
        }

    }
}
