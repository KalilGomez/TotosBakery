﻿using capaDatos;
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
                Cliente = cboxCliente.ToString();
                Direccion = txtDir.Text;
                Fecha = dtpFecha.Value;
                MetPag = cboxMetPag.ToString();
                if (ValidarCamposNoVacios(cboxCliente, txtDir, dtpFecha, cboxMetPag))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private void FormAgregarPedido_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarMetodosDePago();
        }
        private void CargarClientes()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    var clientes = conexion.ObtenerClientes();

                    // Proyectar los datos en un nuevo formato específico para el ComboBox
                    var clientesParaComboBox = clientes.Select(c => new
                    {
                        Id = c.Id,
                        NombreCompleto = $"[{c.Id}] - {c.Nombre} {c.Apellido}"
                    }).ToList();

                    cboxCliente.DataSource = clientesParaComboBox;
                    cboxCliente.DisplayMember = "NombreCompleto"; // Muestra id - nombre apellido
                    cboxCliente.ValueMember = "Id"; // Asigna el ID como valor seleccionado
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMetodosDePago()
        {
            cboxMetPag.Items.Add("Efectivo");
            cboxMetPag.Items.Add("Transferencia");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int ClienteId
        {
            get { return (int)cboxCliente.SelectedValue; } // Obtiene el ID del cliente seleccionado
        }
        private bool ValidarCamposNoVacios(ComboBox a, TextBox b, DateTimePicker c, ComboBox d)
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
