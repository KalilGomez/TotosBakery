namespace capaPresentacion
{
    partial class FormClientes
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
            DGVClientes = new DataGridView();
            BtnAgregar = new Button();
            BtnEditar = new Button();
            BtnEliminar = new Button();
            BtnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVClientes).BeginInit();
            SuspendLayout();
            // 
            // DGVClientes
            // 
            DGVClientes.BorderStyle = BorderStyle.Fixed3D;
            DGVClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVClientes.Location = new Point(14, 91);
            DGVClientes.Margin = new Padding(4, 3, 4, 3);
            DGVClientes.Name = "DGVClientes";
            DGVClientes.ScrollBars = ScrollBars.None;
            DGVClientes.Size = new Size(905, 246);
            DGVClientes.TabIndex = 0;
            // 
            // BtnAgregar
            // 
            BtnAgregar.Location = new Point(64, 372);
            BtnAgregar.Margin = new Padding(4, 3, 4, 3);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(113, 27);
            BtnAgregar.TabIndex = 1;
            BtnAgregar.Text = "Agregar Cliente";
            BtnAgregar.UseVisualStyleBackColor = true;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.Location = new Point(401, 370);
            BtnEditar.Margin = new Padding(4, 3, 4, 3);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(153, 27);
            BtnEditar.TabIndex = 2;
            BtnEditar.Text = "Editar cliente";
            BtnEditar.UseVisualStyleBackColor = true;
            BtnEditar.Click += BtnEditar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(755, 370);
            BtnEliminar.Margin = new Padding(4, 3, 4, 3);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(117, 27);
            BtnEliminar.TabIndex = 3;
            BtnEliminar.Text = "Eliminar cliente";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(832, 479);
            BtnSalir.Margin = new Padding(4, 3, 4, 3);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(88, 27);
            BtnSalir.TabIndex = 4;
            BtnSalir.Text = "Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += button4_Click;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(BtnSalir);
            Controls.Add(BtnEliminar);
            Controls.Add(BtnEditar);
            Controls.Add(BtnAgregar);
            Controls.Add(DGVClientes);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormClientes";
            Text = "Form3";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)DGVClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView DGVClientes;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
    }
}