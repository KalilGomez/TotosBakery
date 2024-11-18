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
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))

            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            if (!ValidarSoloLetas(txtNombre.Text,txtApellido.Text)) 
            {
                return;
            }
            if (!ValidarTelefonoEsEntero(txtTelefono.Text))
            {
                return;
            }
            if (!ValidarCorreo(txtMail.Text))
            {
                return;  
            }
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Telefono = txtTelefono.Text;
            Mail = txtMail.Text;
            Direccion = txtDireccion.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        // Validar nombre y apellido solo se permiten letras
        private bool ValidarSoloLetas(string nombre, string apellido)
        {
            if (!nombre.All(c => Char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo puede contener letras.");
                return false;
            }

            if (!apellido.All(c => Char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El apellido solo puede contener letras.");
                return false;
            }

            return true;
        }
        private bool ValidarTelefonoEsEntero(string telefono)
        {
            // Intentamos convertir el teléfono a un int
            if (!int.TryParse(telefono, out _))
            {
                MessageBox.Show("El teléfono debe ser un número entero.");
                return false;
            }

            // Verificar que el teléfono tenga una longitud específica (por ejemplo, 10 dígitos)
            if (telefono.Length != 10)
            {
                MessageBox.Show("El teléfono debe contener 10 dígitos.");
                return false;
            }

            return true;
        }

        // Método para validar si el correo electrónico contiene el símbolo "@"
        private bool ValidarCorreo(string correo)
        {
            // Verifica si el correo contiene el símbolo "@"
            if (!correo.Contains("@"))
            {
                MessageBox.Show("El correo electrónico debe contener el símbolo '@'.");
                return false;
            }
            return true;  // Si contiene "@", retorna verdadero
        }




    }
}