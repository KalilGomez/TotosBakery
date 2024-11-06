﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
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
            using (FormAgregarProducto formAgregar = new FormAgregarProducto())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    Producto nuevoProducto = new Producto(id: 0, nombre: formAgregar.Nombre,
                        descripcion: formAgregar.Descripcion, precio: formAgregar.Precio, cantidad: formAgregar.Cantidad);

                    bool insertado = ConexionBdd.InsertarProducto(nuevoProducto); // Llamada estática

                    if (insertado)
                    {
                        MessageBox.Show("Cliente agregado correctamente.");
                        CargarProductos(); // Refrescar el DataGridView con la nueva lista de clientes
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el cliente.");
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarProductos()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    var productos = conexion.ObtenerProductos(); // Cargar clientes desde la base de datos
                    DGVProductos.DataSource = productos;
                    DGVProductos.Enabled = false;
                    DGVProductos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
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
            // Cambiar el estado del DataGridView para permitir la selección
            if (DGVProductos.Enabled == false)
            {
                DGVProductos.Enabled = true;
                btnAgregarProducto.Text = "Aceptar";
                DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVProductos.MultiSelect = false;
                DGVProductos.ClearSelection();
            }
            else
            {
                // Verificar si hay una fila seleccionada
                if (DGVProductos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del cliente seleccionado
                    int idCliente = Convert.ToInt32(DGVProductos.SelectedRows[0].Cells["Id"].Value);

                    // Confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        // Conexión a la base de datos y eliminación del cliente
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarCliente(idCliente))
                            {
                                MessageBox.Show("Producto eliminado correctamente.");
                                CargarProductos(); // Refrescar el DataGridView después de la eliminación
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar el Producto.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para eliminar.");
                }
                // Restablecer el estado del botón y del DataGridView
                DGVProductos.Enabled = false;
                btnEliminarProducto.Text = "Eliminar cliente";
                DGVProductos.ClearSelection();
            }
        }
    }
}
