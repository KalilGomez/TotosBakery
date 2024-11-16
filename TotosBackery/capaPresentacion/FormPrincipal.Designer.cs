namespace capaPresentacion
{
    partial class FormPrincipal
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
            btnClientes = new Button();
            BtnProductos = new Button();
            BtnPedidos = new Button();
            BtnCerrarSesion = new Button();
            btnUsuarios = new Button();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(128, 173);
            btnClientes.Margin = new Padding(4, 3, 4, 3);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(88, 27);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // BtnProductos
            // 
            BtnProductos.Location = new Point(312, 173);
            BtnProductos.Margin = new Padding(4, 3, 4, 3);
            BtnProductos.Name = "BtnProductos";
            BtnProductos.Size = new Size(88, 27);
            BtnProductos.TabIndex = 1;
            BtnProductos.Text = "Productos";
            BtnProductos.UseVisualStyleBackColor = true;
            BtnProductos.Click += button1_Click;
            // 
            // BtnPedidos
            // 
            BtnPedidos.Location = new Point(534, 173);
            BtnPedidos.Margin = new Padding(4, 3, 4, 3);
            BtnPedidos.Name = "BtnPedidos";
            BtnPedidos.Size = new Size(88, 27);
            BtnPedidos.TabIndex = 2;
            BtnPedidos.Text = "Pedidos";
            BtnPedidos.UseVisualStyleBackColor = true;
            BtnPedidos.Click += button2_Click;
            // 
            // BtnCerrarSesion
            // 
            BtnCerrarSesion.Location = new Point(814, 479);
            BtnCerrarSesion.Margin = new Padding(4, 3, 4, 3);
            BtnCerrarSesion.Name = "BtnCerrarSesion";
            BtnCerrarSesion.Size = new Size(105, 27);
            BtnCerrarSesion.TabIndex = 3;
            BtnCerrarSesion.Text = "Cerrar sesion";
            BtnCerrarSesion.UseVisualStyleBackColor = true;
            BtnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(789, 173);
            btnUsuarios.Margin = new Padding(4, 3, 4, 3);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(88, 27);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnUsuarios);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(BtnPedidos);
            Controls.Add(BtnProductos);
            Controls.Add(btnClientes);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.Manual;
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button BtnProductos;
        private System.Windows.Forms.Button BtnPedidos;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Button btnUsuarios;
    }
}