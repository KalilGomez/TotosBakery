using capaDatos;
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
        /// <summary>
        /// Obtiene o establece el cliente del pedido.
        /// </summary>
        public string Cliente { get; private set; }

        /// <summary>
        /// Obtiene o establece la dirección del pedido.
        /// </summary>
        public string Direccion { get; private set; }

        /// <summary>
        /// Obtiene o establece la fecha del pedido.
        /// </summary>
        public DateTime Fecha { get; private set; }

        /// <summary>
        /// Obtiene o establece el método de pago del pedido.
        /// </summary>
        public string MetPag { get; private set; }

        /// <summary>
        /// Constructor de la clase FormAgregarPedido.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormAgregarPedido()
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

        /// <summary>
        /// Manejador de evento para la carga del formulario de agregar pedido.
        /// Llama a los métodos para cargar los clientes y los métodos de pago.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormAgregarPedido_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarMetodosDePago();
        }

        /// <summary>
        /// Carga la lista de clientes desde la base de datos y los muestra en un ComboBox.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    var clientes = conexion.ObtenerClientes();

                    var clientesParaComboBox = clientes.Select(c => new
                    {
                        Id = c.Id,
                        NombreCompleto = $"[{c.Id}] - {c.Nombre} {c.Apellido}"
                    }).ToList();

                    cboxCliente.DataSource = clientesParaComboBox;
                    cboxCliente.DisplayMember = "NombreCompleto";
                    cboxCliente.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los métodos de pago en el ComboBox.
        /// </summary>
        private void CargarMetodosDePago()
        {
            cboxMetPag.Items.Add("Efectivo");
            cboxMetPag.Items.Add("Transferencia");
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Cancelar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Obtiene el ID del cliente seleccionado en el ComboBox.
        /// </summary>
        public int ClienteId
        {
            get { return (int)cboxCliente.SelectedValue; }
        }

        /// <summary>
        /// Valida que los campos de texto, combo box y date time picker no estén vacíos.
        /// Muestra un mensaje de advertencia si algún campo está vacío.
        /// </summary>
        /// <param name="a">El ComboBox del cliente.</param>
        /// <param name="b">El campo de texto de la dirección.</param>
        /// <param name="c">El DateTimePicker de la fecha.</param>
        /// <param name="d">El ComboBox del método de pago.</param>
        /// <returns>Devuelve true si todos los campos están llenos, de lo contrario, devuelve false.</returns>
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
