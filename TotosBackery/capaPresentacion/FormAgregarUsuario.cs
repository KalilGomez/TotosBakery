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
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Usuario { get; private set; }
        public string Contraseña { get; private set; }
        public bool Admin { get; private set; }
        public FormAgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposVacios()) {  return; }
            if (!ValidarNombreApellido()) {  return; }

            Nombre=txtNombre.Text;
            Apellido=txtApellido.Text;
            Usuario=txtUsuario.Text;
            Contraseña=txtContraseña.Text;
            Admin=chkAdmin.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }
        private bool ValidarNombreApellido()
        {
            if (!txtNombre.Text.All(c => Char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.");
                return false;
            }

            if (!txtApellido.Text.All(c => Char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El apellido solo puede contener letras y espacios.");
                return false;
            }
            return true;
        }

    }
}
