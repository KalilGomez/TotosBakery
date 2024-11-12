namespace capaPresentacion
{
    partial class FormPedidos
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
            dgvPedido = new DataGridView();
            btnAgregarProducto = new Button();
            btnEditarProducto = new Button();
            btnBuscarPedido = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            SuspendLayout();
            // 
            // dgvPedido
            // 
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Location = new Point(47, 120);
            dgvPedido.Margin = new Padding(4, 3, 4, 3);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.Size = new Size(854, 287);
            dgvPedido.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(78, 460);
            btnAgregarProducto.Margin = new Padding(4, 3, 4, 3);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(113, 27);
            btnAgregarProducto.TabIndex = 1;
            btnAgregarProducto.Text = "Agregar pedido";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarPedido_Click;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.Location = new Point(295, 460);
            btnEditarProducto.Margin = new Padding(4, 3, 4, 3);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(125, 27);
            btnEditarProducto.TabIndex = 2;
            btnEditarProducto.Text = "Editar pedido";
            btnEditarProducto.UseVisualStyleBackColor = true;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // btnBuscarPedido
            // 
            btnBuscarPedido.Location = new Point(578, 460);
            btnBuscarPedido.Margin = new Padding(4, 3, 4, 3);
            btnBuscarPedido.Name = "btnBuscarPedido";
            btnBuscarPedido.Size = new Size(127, 27);
            btnBuscarPedido.TabIndex = 3;
            btnBuscarPedido.Text = "Buscar pedido";
            btnBuscarPedido.UseVisualStyleBackColor = true;
            btnBuscarPedido.Click += btnBuscarPedido_Click;
            // 
            // button4
            // 
            button4.Location = new Point(832, 479);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(88, 27);
            button4.TabIndex = 4;
            button4.Text = "Salir";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FormPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(button4);
            Controls.Add(btnBuscarPedido);
            Controls.Add(btnEditarProducto);
            Controls.Add(btnAgregarProducto);
            Controls.Add(dgvPedido);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPedidos";
            Text = "Form5";
            Load += FormPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Button button4;
    }
}