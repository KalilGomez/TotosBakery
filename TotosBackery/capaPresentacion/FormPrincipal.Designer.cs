namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario principal de la aplicación.
    /// </summary>
    partial class FormPrincipal
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
            this.btnClientes = new Button();
            this.BtnProductos = new Button();
            this.BtnPedidos = new Button();
            this.BtnCerrarSesion = new Button();
            this.btnUsuarios = new Button();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            /// <summary>
            /// Configuración del botón que permite acceder a la gestión de clientes.
            /// </summary>
            this.btnClientes.Location = new Point(0, 41);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new Size(250, 100);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new EventHandler(this.btnClientes_Click);
            // 
            // BtnProductos
            // 
            /// <summary>
            /// Configuración del botón que permite acceder a la gestión de productos.
            /// </summary>
            this.BtnProductos.Location = new Point(250, 41);
            this.BtnProductos.Name = "BtnProductos";
            this.BtnProductos.Size = new Size(250, 100);
            this.BtnProductos.TabIndex = 1;
            this.BtnProductos.Text = "Productos";
            this.BtnProductos.UseVisualStyleBackColor = false;
            this.BtnProductos.Click += new EventHandler(this.button1_Click);
            // 
            // BtnPedidos
            // 
            /// <summary>
            /// Configuración del botón que permite acceder a la gestión de pedidos.
            /// </summary>
            this.BtnPedidos.Location = new Point(0, 141);
            this.BtnPedidos.Name = "BtnPedidos";
            this.BtnPedidos.Size = new Size(250, 100);
            this.BtnPedidos.TabIndex = 2;
            this.BtnPedidos.Text = "Pedidos";
            this.BtnPedidos.UseVisualStyleBackColor = false;
            this.BtnPedidos.Click += new EventHandler(this.button2_Click);
            // 
            // BtnCerrarSesion
            // 
            /// <summary>
            /// Configuración del botón para cerrar sesión en la aplicación.
            /// </summary>
            this.BtnCerrarSesion.Location = new Point(192, 261);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new Size(108, 27);
            this.BtnCerrarSesion.TabIndex = 3;
            this.BtnCerrarSesion.Text = "Cerrar sesión";
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new EventHandler(this.BtnCerrarSesion_Click);
            // 
            // btnUsuarios
            // 
            /// <summary>
            /// Configuración del botón que permite acceder a la gestión de usuarios.
            /// </summary>
            this.btnUsuarios.Location = new Point(250, 141);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new Size(250, 100);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new EventHandler(this.btnUsuarios_Click);
            // 
            // FormPrincipal
            // 
            /// <summary>
            /// Configuración del formulario principal de la aplicación, que incluye la configuración de los controles.
            /// </summary>
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 300);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.BtnPedidos);
            this.Controls.Add(this.BtnProductos);
            this.Controls.Add(this.btnClientes);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "FormPrincipal";
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Principal";
            this.FormClosed += new FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Botón que permite acceder a la gestión de clientes.
        /// </summary>
        private Button btnClientes;

        /// <summary>
        /// Botón que permite acceder a la gestión de productos.
        /// </summary>
        private Button BtnProductos;

        /// <summary>
        /// Botón que permite acceder a la gestión de pedidos.
        /// </summary>
        private Button BtnPedidos;

        /// <summary>
        /// Botón que permite cerrar sesión en la aplicación.
        /// </summary>
        private Button BtnCerrarSesion;

        /// <summary>
        /// Botón que permite acceder a la gestión de usuarios.
        /// </summary>
        private Button btnUsuarios;
    }
}