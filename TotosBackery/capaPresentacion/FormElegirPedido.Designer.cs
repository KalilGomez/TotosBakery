namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario para elegir un pedido.
    /// </summary>
    partial class FormElegirPedido
    {
        /// <summary>
        /// Requerido para admitir el diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">
        /// Valor <c>true</c> si los recursos administrados deben ser descartados; 
        /// <c>false</c> en caso contrario.
        /// </param>
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
        /// Método requerido para soporte del diseñador. 
        /// No modifiques el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblElegirPedido = new System.Windows.Forms.Label();
            this.txtElegirPedido = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarTodos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblElegirPedido
            // 
            this.lblElegirPedido.AutoSize = true;
            this.lblElegirPedido.Location = new System.Drawing.Point(68, 93);
            this.lblElegirPedido.Name = "lblElegirPedido";
            this.lblElegirPedido.Size = new System.Drawing.Size(158, 15);
            this.lblElegirPedido.TabIndex = 0;
            this.lblElegirPedido.Text = "Ingrese el numero de pedido";
            // 
            // txtElegirPedido
            // 
            this.txtElegirPedido.Location = new System.Drawing.Point(276, 90);
            this.txtElegirPedido.Name = "txtElegirPedido";
            this.txtElegirPedido.Size = new System.Drawing.Size(100, 23);
            this.txtElegirPedido.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(276, 265);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(400, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.Location = new System.Drawing.Point(443, 90);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Size = new System.Drawing.Size(90, 23);
            this.btnBuscarTodos.TabIndex = 4;
            this.btnBuscarTodos.Text = "Buscar todos";
            this.btnBuscarTodos.UseVisualStyleBackColor = true;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // FormElegirPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarTodos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtElegirPedido);
            this.Controls.Add(this.lblElegirPedido);
            this.Name = "FormElegirPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormElegirPedido";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        /// Etiqueta que indica al usuario ingresar el número de pedido.
        /// </summary>
        private System.Windows.Forms.Label lblElegirPedido;

        /// <summary>
        /// Campo de texto donde el usuario ingresa el número de pedido.
        /// </summary>
        private System.Windows.Forms.TextBox txtElegirPedido;

        /// <summary>
        /// Botón para aceptar la selección del pedido.
        /// </summary>
        private System.Windows.Forms.Button btnAceptar;

        /// <summary>
        /// Botón para cancelar la operación y cerrar el formulario.
        /// </summary>
        private System.Windows.Forms.Button btnCancelar;

        /// <summary>
        /// Botón para buscar todos los pedidos disponibles.
        /// </summary>
        private System.Windows.Forms.Button btnBuscarTodos;
    }
}