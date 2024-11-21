namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario de pedidos.
    /// </summary>
    partial class FormPedidos
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
            this.dgvPedido = new DataGridView();
            this.btnAgregarProducto = new Button();
            this.btnEditarProducto = new Button();
            this.btnBuscarPedido = new Button();
            this.button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvPedido).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPedido
            // 
            /// <summary>
            /// Configuración del control DataGridView para mostrar los pedidos.
            /// </summary>
            this.dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new Point(47, 120);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new Size(854, 287);
            this.dgvPedido.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            /// <summary>
            /// Configuración del botón para agregar un nuevo producto al pedido.
            /// </summary>
            this.btnAgregarProducto.Location = new Point(130, 480);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new Size(88, 27);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new EventHandler(this.btnAgregarPedido_Click);
            // 
            // btnEditarProducto
            // 
            /// <summary>
            /// Configuración del botón para editar un producto en el pedido.
            /// </summary>
            this.btnEditarProducto.Location = new Point(326, 480);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new Size(88, 27);
            this.btnEditarProducto.TabIndex = 2;
            this.btnEditarProducto.Text = "Editar";
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Click += new EventHandler(this.btnEditarProducto_Click);
            // 
            // btnBuscarPedido
            // 
            /// <summary>
            /// Configuración del botón para buscar un pedido.
            /// </summary>
            this.btnBuscarPedido.Location = new Point(517, 480);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new Size(88, 27);
            this.btnBuscarPedido.TabIndex = 3;
            this.btnBuscarPedido.Text = "Buscar";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new EventHandler(this.btnBuscarPedido_Click);
            // 
            // button4
            // 
            /// <summary>
            /// Configuración del botón para salir del formulario de pedidos.
            /// </summary>
            this.button4.Location = new Point(700, 480);
            this.button4.Name = "button4";
            this.button4.Size = new Size(88, 27);
            this.button4.TabIndex = 4;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            // 
            // FormPedidos
            // 
            /// <summary>
            /// Configuración del formulario de pedidos, que incluye la configuración de controles.
            /// </summary>
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(933, 519);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvPedido);
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "FormPedidos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pedidos";
            this.Load += new EventHandler(this.FormPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)this.dgvPedido).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// DataGridView que muestra la lista de pedidos en el formulario.
        /// </summary>
        private DataGridView dgvPedido;

        /// <summary>
        /// Botón que permite agregar un producto al pedido.
        /// </summary>
        private Button btnAgregarProducto;

        /// <summary>
        /// Botón que permite editar un producto en el pedido.
        /// </summary>
        private Button btnEditarProducto;

        /// <summary>
        /// Botón que permite buscar un pedido en el sistema.
        /// </summary>
        private Button btnBuscarPedido;

        /// <summary>
        /// Botón que cierra el formulario de pedidos.
        /// </summary>
        private Button button4;
    }
}