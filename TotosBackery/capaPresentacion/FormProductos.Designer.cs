namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario para la gestión de productos.
    /// </summary>
    partial class FormProductos
    {
        /// <summary>
        /// Variable del diseñador requerida para la gestión de los componentes.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Libera los recursos que se están utilizando.
        /// </summary>
        /// <param name="disposing">Indica si los recursos administrados deben ser descartados (true) o no (false).</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para soporte del diseñador. No modifiques el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGVProductos = new DataGridView();
            this.btnAgregarProducto = new Button();
            this.btnEditarProducto = new Button();
            this.btnEliminarProducto = new Button();
            this.btnSalir = new Button();
            this.SuspendLayout();
            // 
            // DGVProductos
            // 
            /// <summary>
            /// Configuración del DataGridView que muestra la lista de productos.
            /// </summary>
            this.DGVProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductos.Location = new Point(18, 102);
            this.DGVProductos.Name = "DGVProductos";
            this.DGVProductos.Size = new Size(902, 282);
            this.DGVProductos.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            /// <summary>
            /// Configuración del botón que permite agregar un nuevo producto.
            /// </summary>
            this.btnAgregarProducto.Location = new Point(169, 480);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new Size(88, 27);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnEditarProducto
            // 
            /// <summary>
            /// Configuración del botón que permite editar un producto seleccionado.
            /// </summary>
            this.btnEditarProducto.Location = new Point(335, 480);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new Size(88, 27);
            this.btnEditarProducto.TabIndex = 2;
            this.btnEditarProducto.Text = "Editar producto";
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Click += new EventHandler(this.btnEditarProducto_Click);
            // 
            // btnEliminarProducto
            // 
            /// <summary>
            /// Configuración del botón que permite eliminar un producto seleccionado.
            /// </summary>
            this.btnEliminarProducto.Location = new Point(505, 480);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new Size(88, 27);
            this.btnEliminarProducto.TabIndex = 3;
            this.btnEliminarProducto.Text = "Eliminar producto";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnSalir
            // 
            /// <summary>
            /// Configuración del botón que permite salir del formulario de productos.
            /// </summary>
            this.btnSalir.Location = new Point(675, 480);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(88, 27);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new EventHandler(this.btnSalir_Click);
            // 
            // FormProductos
            // 
            /// <summary>
            /// Configuración del formulario para la gestión de productos, que incluye la configuración de los controles.
            /// </summary>
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(933, 519);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.DGVProductos);
            this.Name = "FormProductos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Formulario de Productos";
            this.Load += new EventHandler(this.FormProductos_Load);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// DataGridView que muestra la lista de productos.
        /// </summary>
        private DataGridView DGVProductos;

        /// <summary>
        /// Botón que permite agregar un nuevo producto.
        /// </summary>
        private Button btnAgregarProducto;

        /// <summary>
        /// Botón que permite editar un producto seleccionado.
        /// </summary>
        private Button btnEditarProducto;

        /// <summary>
        /// Botón que permite eliminar un producto seleccionado.
        /// </summary>
        private Button btnEliminarProducto;

        /// <summary>
        /// Botón que permite salir del formulario de productos.
        /// </summary>
        private Button btnSalir;
    }
}