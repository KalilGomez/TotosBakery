namespace capaPresentacion
{
    partial class FormProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGVProductos = new DataGridView();
            btnAgregarProducto = new Button();
            btnEditarProducto = new Button();
            btnEliminarProducto = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVProductos).BeginInit();
            SuspendLayout();
            // 
            // DGVProductos
            // 
            DGVProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVProductos.Location = new Point(18, 102);
            DGVProductos.Margin = new Padding(4, 3, 4, 3);
            DGVProductos.Name = "DGVProductos";
            DGVProductos.Size = new Size(902, 282);
            DGVProductos.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(169, 480);
            btnAgregarProducto.Margin = new Padding(4, 3, 4, 3);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(88, 27);
            btnAgregarProducto.TabIndex = 1;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.Location = new Point(335, 480);
            btnEditarProducto.Margin = new Padding(4, 3, 4, 3);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(88, 27);
            btnEditarProducto.TabIndex = 2;
            btnEditarProducto.Text = "Editar producto";
            btnEditarProducto.UseVisualStyleBackColor = true;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Location = new Point(505, 480);
            btnEliminarProducto.Margin = new Padding(4, 3, 4, 3);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(88, 27);
            btnEliminarProducto.TabIndex = 3;
            btnEliminarProducto.Text = "Eliminar producto";
            btnEliminarProducto.UseVisualStyleBackColor = true;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(675, 480);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarProducto);
            Controls.Add(btnEditarProducto);
            Controls.Add(btnAgregarProducto);
            Controls.Add(DGVProductos);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)DGVProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnSalir;
    }
}