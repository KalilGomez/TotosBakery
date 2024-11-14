namespace capaPresentacion
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIniciarSesion = new Button();
            btnRstPwd = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkMagenta;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(354, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(141, 30);
            label1.TabIndex = 0;
            label1.Text = "BIENVENIDO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 107);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 141);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(385, 104);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(116, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(385, 141);
            txtContraseña.Margin = new Padding(4, 3, 4, 3);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(116, 23);
            txtContraseña.TabIndex = 4;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.Salmon;
            btnIniciarSesion.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.Location = new Point(320, 195);
            btnIniciarSesion.Margin = new Padding(4, 3, 4, 3);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(209, 59);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnRstPwd
            // 
            btnRstPwd.Location = new Point(371, 272);
            btnRstPwd.Margin = new Padding(4, 3, 4, 3);
            btnRstPwd.Name = "btnRstPwd";
            btnRstPwd.Size = new Size(124, 22);
            btnRstPwd.TabIndex = 6;
            btnRstPwd.TabStop = true;
            btnRstPwd.Text = "Olvide la contraseña";
            btnRstPwd.Click += btnRstPwd_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnIniciarSesion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(933, 519);
            Controls.Add(btnRstPwd);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormLogin";
            Text = "Form1";
            FormClosed += FormLogin_FormClosed;
            KeyDown += FormLogin_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.LinkLabel btnRstPwd;
    }
}

