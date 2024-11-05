using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;

namespace capaPresentacion
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Abrir el formulario hijo
            using (FormAgregarProducto formAgregar = new FormAgregarProducto())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Crear un nuevo producto con los datos del formulario hijo
                    int nuevoId = productos.Count + 1;
                    Producto nuevoProducto = new Producto(nuevoId, formAgregar.Nombre, formAgregar.Descripcion, formAgregar.Precio, formAgregar.Cantidad);
                    // Agregar el nuevo producto a la lista
                    productos.Add(nuevoProducto);

                    // Actualizar el DataGridView
                    DGVProductos.DataSource = null;
                    DGVProductos.DataSource = productos;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            productos.Add(new Producto(1, "Galleta", "Galletita tipo pepito", 52.5, 50));
            productos.Add(new Producto(2, "Pan", "Pan integral siempre vegano", 80, 20));
            productos.Add(new Producto(3, "Scon", "Scon 4 quesos SALADO", 4000, 6));
            DGVProductos.DataSource = productos;
            DGVProductos.Enabled = false;
            DGVProductos.ClearSelection();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            DGVProductos.Enabled = !DGVProductos.Enabled;

            if (DGVProductos.Enabled)
            {
                btnEditarProducto.Text = "Aceptar";
                // Otras acciones cuando se habilita la edición
            }
            else
            {
                btnEditarProducto.Text = "Editar cliente";
                DGVProductos.ClearSelection();
                // Otras acciones cuando se finaliza la edición
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            DGVProductos.Enabled = !DGVProductos.Enabled;

            if (DGVProductos.Enabled)
            {
                btnEliminarProducto.Text = "Aceptar";
                DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVProductos.MultiSelect = false;  // Solo permite seleccionar una fila a la vez
                DGVProductos.ClearSelection();

                // Otras acciones cuando se habilita la edición
            }
            else
            {
                btnEliminarProducto.Text = "Eliminar cliente";
                // Verifica si hay una fila seleccionada
                if (DGVProductos.SelectedRows.Count > 0)
                {
                    // Obtén el índice de la fila seleccionada
                    int rowIndex = DGVProductos.SelectedRows[0].Index;

                    // Elimina el objeto correspondiente de la fuente de datos
                    Producto productoAEliminar = productos[rowIndex];  // Obtén el objeto de la lista
                    productos.Remove(productoAEliminar);              // Elimínalo de la lista

                    // Vuelve a asignar la lista actualizada como fuente de datos del DataGridView
                    DGVProductos.DataSource = null;
                    DGVProductos.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                }
                DGVProductos.ClearSelection();
                // Otras acciones cuando se finaliza la edición
            }
        }
    }
}
