namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario de gestión de usuarios, incluyendo las funcionalidades
    /// de agregar, editar, eliminar usuarios y mostrar la lista de usuarios en un DataGridView.
    /// </summary>
    partial class FormUsuario
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
            this.btnAgregar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.dgvUsuario = new DataGridView();
            this.btnSalir = new Button();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            /// <summary>
            /// Configura el botón "Agregar" que permite agregar un nuevo usuario al sistema.
            /// </summary>
            this.btnAgregar.Location = new Point(188, 480);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(88, 27);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            /// <summary>
            /// Configura el botón "Editar" que permite editar un usuario seleccionado.
            /// </summary>
            this.btnEditar.Location = new Point(336, 480);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new Size(88, 27);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            /// <summary>
            /// Configura el botón "Eliminar" que permite eliminar un usuario seleccionado del sistema.
            /// </summary>
            this.btnEliminar.Location = new Point(472, 480);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(88, 27);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);
            // 
            // dgvUsuario
            // 
            /// <summary>
            /// Configura el DataGridView para mostrar la lista de usuarios en el sistema.
            /// </summary>
            this.dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Location = new Point(26, 110);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.Size = new Size(883, 249);
            this.dgvUsuario.TabIndex = 3;
            // 
            // btnSalir
            // 
            /// <summary>
            /// Configura el botón "Salir" que cierra el formulario de gestión de usuarios.
            /// </summary>
            this.btnSalir.Location = new Point(615, 480);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(88, 27);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new EventHandler(this.btnSalir_Click);
            // 
            // FormUsuario
            // 
            /// <summary>
            /// Configuración general del formulario de gestión de usuarios, incluyendo los controles y eventos asociados.
            /// </summary>
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(933, 519);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "FormUsuario";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new EventHandler(this.FormUsuario_Load);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Botón para agregar un nuevo usuario.
        /// </summary>
        private Button btnAgregar;

        /// <summary>
        /// Botón para editar un usuario seleccionado.
        /// </summary>
        private Button btnEditar;

        /// <summary>
        /// Botón para eliminar un usuario seleccionado.
        /// </summary>
        private Button btnEliminar;

        /// <summary>
        /// DataGridView para mostrar la lista de usuarios en el sistema.
        /// </summary>
        private DataGridView dgvUsuario;

        /// <summary>
        /// Botón para cerrar el formulario de gestión de usuarios.
        /// </summary>
        private Button btnSalir;
    }
}