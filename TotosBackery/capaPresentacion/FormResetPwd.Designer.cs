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
            lblResetUser = new Label();
            txtUsuario = new TextBox();
            btnEnviarReset = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblResetUser
            // 
            lblResetUser.AutoSize = true;
            lblResetUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResetUser.Location = new Point(140, 84);
            lblResetUser.Margin = new Padding(4, 0, 4, 0);
            lblResetUser.Name = "lblResetUser";
            lblResetUser.Size = new Size(53, 17);
            lblResetUser.TabIndex = 0;
            lblResetUser.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(201, 78);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(116, 23);
            txtUsuario.TabIndex = 1;
            // 
            // btnEnviarReset
            // 
            btnEnviarReset.Location = new Point(115, 158);
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
            btnSalir.Location = new Point(263, 158);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
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
        private System.Windows.Forms.Button btnEnviarReset;
        private Button btnSalir;
    }
}