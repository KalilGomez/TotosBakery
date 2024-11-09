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
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEditarProducto = new System.Windows.Forms.Button();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPedido
            // 
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(40, 104);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new System.Drawing.Size(732, 249);
            this.dgvPedido.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(67, 399);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(97, 23);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar pedido";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // btnEditarProducto
            // 
            this.btnEditarProducto.Location = new System.Drawing.Point(253, 399);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new System.Drawing.Size(107, 23);
            this.btnEditarProducto.TabIndex = 2;
            this.btnEditarProducto.Text = "Editar pedido";
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Click += new System.EventHandler(this.btnEditarProducto_Click);
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.Location = new System.Drawing.Point(495, 399);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(109, 23);
            this.btnCancelarPedido.TabIndex = 3;
            this.btnCancelarPedido.Text = "Cancelar pedido";
            this.btnCancelarPedido.UseVisualStyleBackColor = true;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(713, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCancelarPedido);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvPedido);
            this.Name = "FormPedidos";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.Button button4;
    }
}