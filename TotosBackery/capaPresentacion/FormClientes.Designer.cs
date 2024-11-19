namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario de gestión de clientes.
    /// </summary>
    partial class FormClientes
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
            this.DGVClientes = new System.Windows.Forms.DataGridView();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.DGVClientes).BeginInit();
            this.SuspendLayout();
            // 
            // DGVClientes
            // 
            this.DGVClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClientes.Location = new System.Drawing.Point(14, 91);
            this.DGVClientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVClientes.Name = "DGVClientes";
            this.DGVClientes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGVClientes.Size = new System.Drawing.Size(905, 246);
            this.DGVClientes.TabIndex = 0;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(166, 480);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(88, 27);
            this.BtnAgregar.TabIndex = 1;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(338, 480);
            this.BtnEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(88, 27);
            this.BtnEditar.TabIndex = 2;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(535, 480);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(88, 27);
            this.BtnEliminar.TabIndex = 3;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(701, 480);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(88, 27);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.DGVClientes);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            ((System.ComponentModel.ISupportInitialize)this.DGVClientes).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Control DataGridView para mostrar la lista de clientes.
        /// </summary>
        private System.Windows.Forms.DataGridView DGVClientes;

        /// <summary>
        /// Botón para agregar un nuevo cliente.
        /// </summary>
        private System.Windows.Forms.Button BtnAgregar;

        /// <summary>
        /// Botón para editar un cliente seleccionado.
        /// </summary>
        private System.Windows.Forms.Button BtnEditar;

        /// <summary>
        /// Botón para eliminar un cliente seleccionado.
        /// </summary>
        private System.Windows.Forms.Button BtnEliminar;

        /// <summary>
        /// Botón para salir del formulario.
        /// </summary>
        private System.Windows.Forms.Button BtnSalir;
    }
}