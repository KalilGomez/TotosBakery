namespace capaPresentacion
{
    partial class FormElegirPedido
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
            lblElegirPedido = new Label();
            txtElegirPedido = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnBuscarTodos = new Button();
            SuspendLayout();
            // 
            // lblElegirPedido
            // 
            lblElegirPedido.AutoSize = true;
            lblElegirPedido.Location = new Point(68, 93);
            lblElegirPedido.Name = "lblElegirPedido";
            lblElegirPedido.Size = new Size(158, 15);
            lblElegirPedido.TabIndex = 0;
            lblElegirPedido.Text = "Ingrese el numero de pedido";
            // 
            // txtElegirPedido
            // 
            txtElegirPedido.Location = new Point(276, 90);
            txtElegirPedido.Name = "txtElegirPedido";
            txtElegirPedido.Size = new Size(100, 23);
            txtElegirPedido.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(276, 265);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(400, 265);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTodos
            // 
            btnBuscarTodos.Location = new Point(443, 90);
            btnBuscarTodos.Name = "btnBuscarTodos";
            btnBuscarTodos.Size = new Size(90, 23);
            btnBuscarTodos.TabIndex = 4;
            btnBuscarTodos.Text = "Buscar todos";
            btnBuscarTodos.UseVisualStyleBackColor = true;
            btnBuscarTodos.Click += btnBuscarTodos_Click;
            // 
            // FormElegirPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscarTodos);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtElegirPedido);
            Controls.Add(lblElegirPedido);
            Name = "FormElegirPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormElegirPedido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblElegirPedido;
        private TextBox txtElegirPedido;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnBuscarTodos;
    }
}