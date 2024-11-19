namespace capaPresentacion
{
    /// <summary>
    /// Clase parcial que representa el formulario para restablecer la contraseña de un usuario.
    /// </summary>
    partial class FormResetPwd
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
            this.lblResetUser = new Label();
            this.txtUsuario = new TextBox();
            this.btnEnviarReset = new Button();
            this.btnSalir = new Button();
            this.SuspendLayout();
            // 
            // lblResetUser
            // 
            /// <summary>
            /// Configuración de la etiqueta que indica el campo para ingresar el nombre de usuario.
            /// </summary>
            this.lblResetUser.AutoSize = true;
            this.lblResetUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblResetUser.Location = new Point(140, 84);
            this.lblResetUser.Name = "lblResetUser";
            this.lblResetUser.Size = new Size(53, 17);
            this.lblResetUser.TabIndex = 0;
            this.lblResetUser.Text = "Usuario";
            // 
            // txtUsuario
            // 
            /// <summary>
            /// Configuración del campo de texto para ingresar el nombre de usuario.
            /// </summary>
            this.txtUsuario.Location = new Point(201, 78);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new Size(116, 23);
            this.txtUsuario.TabIndex = 1;
            // 
            // btnEnviarReset
            // 
            /// <summary>
            /// Configuración del botón que envía la solicitud de restablecimiento de contraseña.
            /// </summary>
            this.btnEnviarReset.Location = new Point(115, 158);
            this.btnEnviarReset.Name = "btnEnviarReset";
            this.btnEnviarReset.Size = new Size(88, 27);
            this.btnEnviarReset.TabIndex = 3;
            this.btnEnviarReset.Text = "Aceptar";
            this.btnEnviarReset.UseVisualStyleBackColor = true;
            this.btnEnviarReset.Click += new EventHandler(this.btnEnviarReset_Click);
            // 
            // btnSalir
            // 
            /// <summary>
            /// Configuración del botón que permite volver al formulario anterior sin realizar cambios.
            /// </summary>
            this.btnSalir.Location = new Point(263, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(88, 27);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Volver";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new EventHandler(this.button1_Click);
            // 
            // FormResetPwd
            // 
            /// <summary>
            /// Configuración general del formulario de restablecimiento de contraseña, que incluye los controles visuales.
            /// </summary>
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(484, 261);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEnviarReset);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblResetUser);
            this.Name = "FormResetPwd";
            this.Text = "Restablecer Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        /// Etiqueta que indica el campo para ingresar el nombre de usuario.
        /// </summary>
        private Label lblResetUser;

        /// <summary>
        /// Campo de texto para ingresar el nombre de usuario.
        /// </summary>
        private TextBox txtUsuario;

        /// <summary>
        /// Botón para enviar la solicitud de restablecimiento de la contraseña.
        /// </summary>
        private Button btnEnviarReset;

        /// <summary>
        /// Botón para cerrar o salir del formulario sin realizar cambios.
        /// </summary>
        private Button btnSalir;
    }
}