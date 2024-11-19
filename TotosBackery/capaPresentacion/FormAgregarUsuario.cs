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
    public partial class FormAgregarUsuario : Form
    {
        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string Apellido { get; private set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string Usuario { get; private set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Contraseña { get; private set; }

        /// <summary>
        /// Indica si el usuario tiene privilegios de administrador.
        /// </summary>
        public bool Admin { get; private set; }

        /// <summary>
        /// Constructor de la clase FormAgregarUsuario.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormAgregarUsuario()
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Usuario = txtUsuario.Text;
            Contraseña = txtContraseña.Text;
            Admin = chkAdmin.Checked;
            if (ValidarCamposNoVacios(txtNombre, txtApellido, txtUsuario, txtContraseña))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Valida que los campos de texto no estén vacíos.
        /// Muestra un mensaje de advertencia si algún campo está vacío.
        /// </summary>
        /// <param name="a">El campo de texto del nombre.</param>
        /// <param name="b">El campo de texto del apellido.</param>
        /// <param name="c">El campo de texto del usuario.</param>
        /// <param name="d">El campo de texto de la contraseña.</param>
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
