using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    public class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private double precio;
        private int cantidad;

        /// <summary>
        /// Obtiene o establece el identificador único del producto.
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string Descripcion { get => descripcion; set => descripcion = value; }

        /// <summary>
        /// Obtiene o establece el precio del producto.
        /// </summary>
        public double Precio { get => precio; set => precio = value; }

        /// <summary>
        /// Obtiene o establece la cantidad disponible del producto.
        /// </summary>
        public int Cantidad { get => cantidad; set => cantidad = value; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Producto"/> con los valores especificados.
        /// </summary>
        /// <param name="id">El identificador único del producto.</param>
        /// <param name="nombre">El nombre del producto.</param>
        /// <param name="descripcion">La descripción del producto.</param>
        /// <param name="precio">El precio del producto.</param>
        /// <param name="cantidad">La cantidad disponible del producto.</param>
        public Producto(int id, string nombre, string descripcion, double precio, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        /// <summary>
        /// Inicializa una nueva instancia vacía de la clase <see cref="Producto"/>.
        /// </summary>
        public Producto() { }
    }
}
