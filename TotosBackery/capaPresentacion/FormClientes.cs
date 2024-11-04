using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;

namespace capaPresentacion
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            clientes.Add(new Cliente(1, "kalil", "Gomez", "Alsina 326", "1234", "a@a.com"));
            clientes.Add(new Cliente(2, "Cosme", "Fulanito", "Crespo 223", "2345", "b@b.com"));
            clientes.Add(new Cliente(3, "Elena", "No", "Belgrano 56", "0098", "c@c.com"));
            DGVClientes.DataSource = clientes;
            DGVClientes.Enabled = false;
            DGVClientes.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir el formulario hijo
            using (FormAgregarCliente formAgregar = new FormAgregarCliente())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Crear un nuevo cliente con los datos del formulario hijo
                    int nuevoId = clientes.Count + 1;
                    Cliente nuevoCliente = new Cliente(nuevoId, formAgregar.Nombre, formAgregar.Apellido, formAgregar.Direccion, formAgregar.Telefono, formAgregar.Mail);
                    // Agregar el nuevo cliente a la lista
                    clientes.Add(nuevoCliente);

                    // Actualizar el DataGridView
                    DGVClientes.DataSource = null;
                    DGVClientes.DataSource = clientes;
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DGVClientes.Enabled = !DGVClientes.Enabled;

            if (DGVClientes.Enabled)
            {
                BtnEditar.Text = "Aceptar";
                // Otras acciones cuando se habilita la edición
            }
            else
            {
                BtnEditar.Text = "Editar cliente";
                DGVClientes.ClearSelection();
                // Otras acciones cuando se finaliza la edición
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DGVClientes.Enabled = !DGVClientes.Enabled;

            if (DGVClientes.Enabled)
            {
                BtnEliminar.Text = "Aceptar";
                DGVClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVClientes.MultiSelect = false;  // Solo permite seleccionar una fila a la vez
                DGVClientes.ClearSelection();

                // Otras acciones cuando se habilita la edición
            }
            else
            {
                BtnEliminar.Text = "Eliminar cliente";
                // Verifica si hay una fila seleccionada
                if (DGVClientes.SelectedRows.Count > 0)
                {
                    // Obtén el índice de la fila seleccionada
                    int rowIndex = DGVClientes.SelectedRows[0].Index;

                    // Elimina el objeto correspondiente de la fuente de datos
                    Cliente clienteAEliminar = clientes[rowIndex];  // Obtén el objeto de la lista
                    clientes.Remove(clienteAEliminar);              // Elimínalo de la lista

                    // Vuelve a asignar la lista actualizada como fuente de datos del DataGridView
                    DGVClientes.DataSource = null;
                    DGVClientes.DataSource = clientes;
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                }
                DGVClientes.ClearSelection();
                // Otras acciones cuando se finaliza la edición
            }
        }
    }
}
