namespace capaPresentacion
{
    partial class FormResetPwd
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
            components = new System.ComponentModel.Container();
            lblResetUser = new Label();
            txtUsuario = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnEnviarReset = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblResetUser
            // 
            lblResetUser.AutoSize = true;
            lblResetUser.Location = new Point(115, 83);
            lblResetUser.Margin = new Padding(4, 0, 4, 0);
            lblResetUser.Name = "lblResetUser";
            lblResetUser.Size = new Size(102, 15);
            lblResetUser.TabIndex = 0;
            lblResetUser.Text = "Ingrese su usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(246, 75);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(116, 23);
            txtUsuario.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnEnviarReset
            // 
            btnEnviarReset.Location = new Point(115, 137);
            btnEnviarReset.Margin = new Padding(4, 3, 4, 3);
            btnEnviarReset.Name = "btnEnviarReset";
            btnEnviarReset.Size = new Size(88, 27);
            btnEnviarReset.TabIndex = 3;
            btnEnviarReset.Text = "Aceptar";
            btnEnviarReset.UseVisualStyleBackColor = true;
            btnEnviarReset.Click += btnEnviarReset_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(278, 137);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Volver";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += button1_Click;
            // 
            // FormResetPwd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(btnSalir);
            Controls.Add(btnEnviarReset);
            Controls.Add(txtUsuario);
            Controls.Add(lblResetUser);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormResetPwd";
            Text = "FormResetPwd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblResetUser;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnEnviarReset;
        private Button btnSalir;
        private Label lblReset;
    }
}