using capaEntidades;
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
        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Obtiene o establece el apellido del cliente.
        /// </summary>
        public string Apellido { get; private set; }

        /// <summary>
        /// Obtiene o establece la dirección del cliente.
        /// </summary>
        public string Direccion { get; private set; }

        /// <summary>
        /// Obtiene o establece el teléfono del cliente.
        /// </summary>
        public string Telefono { get; private set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del cliente.
        /// </summary>
        public string Mail { get; private set; }

        /// <summary>
        /// Constructor de la clase FormAgregarCliente.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormAgregarCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Aceptar.
        /// Asigna los valores ingresados en los campos de texto a las propiedades correspondientes,
        /// valida que los campos no estén vacíos y cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Telefono = txtTelefono.Text;
            Mail = txtMail.Text;
            Direccion = txtDireccion.Text;
            ValidarCamposNoVacios(txtNombre, txtApellido, txtTelefono, txtMail, txtDireccion);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Valida que los campos de texto no estén vacíos.
        /// Muestra un mensaje de advertencia si algún campo está vacío.
        /// </summary>
        /// <param name="a">El campo de texto del nombre.</param>
        /// <param name="b">El campo de texto del apellido.</param>
        /// <param name="c">El campo de texto del teléfono.</param>
        /// <param name="d">El campo de texto del correo electrónico.</param>
        /// <param name="e">El campo de texto de la dirección.</param>
        /// <returns>Devuelve true si todos los campos están llenos, de lo contrario, devuelve false.</returns>
        private bool ValidarCamposNoVacios(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e)
        {
            if (string.IsNullOrWhiteSpace(a.Text) ||
                string.IsNullOrWhiteSpace(b.Text) ||
                string.IsNullOrWhiteSpace(c.Text) ||
                string.IsNullOrWhiteSpace(d.Text) ||
                string.IsNullOrWhiteSpace(e.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }

    }
}