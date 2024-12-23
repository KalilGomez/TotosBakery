﻿using System;
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
            Nombre=txtNombre.Text;
            Apellido=txtApellido.Text;
            Usuario=txtUsuario.Text;
            Contraseña=txtContraseña.Text;
            Admin=chkAdmin.Checked;
            if (ValidarCamposNoVacios(txtNombre, txtApellido, txtUsuario, txtContraseña))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
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
