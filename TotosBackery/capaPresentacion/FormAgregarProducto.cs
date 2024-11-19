using capaNegocio;
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
        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string Descripcion { get; private set; }

        /// <summary>
        /// Obtiene o establece el precio del producto.
        /// </summary>
        public double Precio { get; private set; }

        /// <summary>
        /// Obtiene o establece la cantidad del producto.
        /// </summary>
        public int Cantidad { get; private set; }

        /// <summary>
        /// Constructor de la clase FormAgregarProducto.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormAgregarProducto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Aceptar.
        /// Valida los campos ingresados y, si son correctos, asigna los valores a las propiedades correspondientes
        /// y cierra el formulario con un resultado de diálogo OK.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposNoVacios(txtNombre, txtDescripcion, txtPrecio, txtCantidad))
                {
                    return;
                }

                string nombreTemp = txtNombre.Text.Trim();
                string precioTemp = txtPrecio.Text.Trim();
                string cantidadTemp = txtCantidad.Text.Trim();

                if (!LogicaNegocio.ValidarNombre(nombreTemp))
                {
                    MessageBox.Show("Error en el nombre del producto. Solo se permiten letras.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }

                if (!LogicaNegocio.ValidarPrecio(precioTemp))
                {
                    MessageBox.Show("El precio debe ser un número mayor que 0.",
                        "Validación de precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                if (!LogicaNegocio.ValidarCantidad(cantidadTemp))
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor que 0.",
                        "Validación de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                Nombre = nombreTemp;
                Descripcion = txtDescripcion.Text.Trim();
                Precio = double.Parse(precioTemp);
                Cantidad = int.Parse(cantidadTemp);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el producto: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida que los campos de texto no estén vacíos.
        /// Muestra un mensaje de advertencia si algún campo está vacío.
        /// </summary>
        /// <param name="a">El campo de texto del nombre.</param>
        /// <param name="b">El campo de texto de la descripción.</param>
        /// <param name="c">El campo de texto del precio.</param>
        /// <param name="d">El campo de texto de la cantidad.</param>
        /// <returns>Devuelve true si todos los campos están llenos, de lo contrario, devuelve false.</returns>
        private bool ValidarCamposNoVacios(TextBox a, TextBox b, TextBox c, TextBox d)
        {
            if (string.IsNullOrWhiteSpace(a.Text) ||
                string.IsNullOrWhiteSpace(b.Text) ||
                string.IsNullOrWhiteSpace(c.Text) ||
                string.IsNullOrWhiteSpace(d.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }
    }
}
