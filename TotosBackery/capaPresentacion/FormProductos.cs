using System;
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
using capaNegocio;

namespace capaPresentacion
{
    public partial class FormProductos : Form
    {
        /// <summary>
        /// Constructor de la clase FormProductos.
        /// Inicializa los componentes del formulario.
        /// </summary>
        public FormProductos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Agregar Producto.
        /// Abre el formulario para agregar un nuevo producto y, si los datos son válidos, inserta el nuevo producto en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            using (FormAgregarProducto formAgregar = new FormAgregarProducto())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    // Crear una nueva instancia de Producto con los datos ingresados
                    Producto nuevoProducto = new Producto(id: 0, nombre: formAgregar.Nombre,
                        descripcion: formAgregar.Descripcion, precio: formAgregar.Precio, cantidad: formAgregar.Cantidad);

                    // Insertar el nuevo producto en la base de datos (llamada estática)
                    bool insertado = ConexionBdd.InsertarProducto(nuevoProducto);

                    if (insertado)
                    {
                        MessageBox.Show("Producto agregado correctamente.");
                        // Refrescar el DataGridView con la nueva lista de productos
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el producto.");
                    }
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Salir.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            this.Close();
        }

        /// <summary>
        /// Manejador de evento para la carga del formulario de productos.
        /// Carga la lista de productos.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormProductos_Load(object sender, EventArgs e)
        {
            // Cargar la lista de productos
            CargarProductos();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Editar Producto.
        /// Permite la edición de los datos del producto en el DataGridView y guarda los cambios al confirmar la edición.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            // Habilitar edición en el DataGridView si está deshabilitado
            if (!DGVProductos.Enabled)
            {
                DGVProductos.Enabled = true;
                btnEditarProducto.Text = "Guardar cambios";
            }
            else
            {
                try
                {
                    if (DGVProductos.CurrentRow != null)
                    {
                        // Crear una nueva instancia de Producto con los datos actualizados
                        Producto productoActualizado = new Producto
                        {
                            Id = Convert.ToInt32(DGVProductos.CurrentRow.Cells["Id"].Value),
                            Nombre = DGVProductos.CurrentRow.Cells["Nombre"].Value.ToString(),
                            Descripcion = DGVProductos.CurrentRow.Cells["Descripcion"].Value.ToString(),
                            Precio = Convert.ToDouble(DGVProductos.CurrentRow.Cells["Precio"].Value),
                            Cantidad = Convert.ToInt32(DGVProductos.CurrentRow.Cells["Cantidad"].Value)
                        };

                        // Validar nombre
                        if (!LogicaNegocio.ValidarNombre(productoActualizado.Nombre))
                        {
                            MessageBox.Show("Error en el nombre del producto. Solo se permiten letras.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validar precio
                        if (!LogicaNegocio.ValidarPrecio(productoActualizado.Precio.ToString()))
                        {
                            MessageBox.Show("El precio debe ser un número mayor que 0.",
                                "Validación de precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validar cantidad
                        if (!LogicaNegocio.ValidarCantidad(productoActualizado.Cantidad.ToString()))
                        {
                            MessageBox.Show("La cantidad debe ser un número entero mayor que 0.",
                                "Validación de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Actualizar los datos del producto en la base de datos
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.ActualizarProducto(productoActualizado))
                            {
                                MessageBox.Show("Producto actualizado correctamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Refrescar el DataGridView con la nueva lista de productos
                                CargarProductos();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el producto", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Deshabilitar edición en el DataGridView y cambiar el texto del botón
                    DGVProductos.Enabled = false;
                    btnEditarProducto.Text = "Editar producto";
                    DGVProductos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Eliminar Producto.
        /// Permite la selección de un producto en el DataGridView para eliminarlo, 
        /// y realiza la eliminación si se confirma la acción.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            // Cambiar el estado del DataGridView para permitir la selección
            if (DGVProductos.Enabled == false)
            {
                DGVProductos.Enabled = true;
                btnEliminarProducto.Text = "Aceptar";
                DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVProductos.MultiSelect = false;
                DGVProductos.ClearSelection();
            }
            else
            {
                // Verificar si hay una fila seleccionada
                if (DGVProductos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del producto seleccionado
                    int idProducto = Convert.ToInt32(DGVProductos.SelectedRows[0].Cells["Id"].Value);

                    // Confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        // Conexión a la base de datos y eliminación del producto
                        using (var conexion = new ConexionBdd())
                        {
                            if (conexion.EliminarProducto(idProducto))
                            {
                                MessageBox.Show("Producto eliminado correctamente.");
                                // Refrescar el DataGridView después de la eliminación
                                CargarProductos();
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar el producto.");
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
                btnEliminarProducto.Text = "Eliminar producto";
                DGVProductos.ClearSelection();
            }
        }

        /// <summary>
        /// Carga los productos desde la base de datos y los muestra en un DataGridView.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                using (var conexion = new ConexionBdd())
                {
                    // Cargar productos desde la base de datos
                    var productos = conexion.ObtenerProductos();
                    // Asignar los datos al DataGridView
                    DGVProductos.DataSource = productos;
                    // Deshabilitar la edición en el DataGridView
                    DGVProductos.Enabled = false;
                    // Limpiar la selección en el DataGridView
                    DGVProductos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
