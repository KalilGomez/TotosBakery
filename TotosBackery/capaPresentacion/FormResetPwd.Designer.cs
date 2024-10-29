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
            this.components = new System.ComponentModel.Container();
            this.lblResetUser = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEnviarReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResetUser
            // 
            this.lblResetUser.AutoSize = true;
            this.lblResetUser.Location = new System.Drawing.Point(220, 50);
            this.lblResetUser.Name = "lblResetUser";
            this.lblResetUser.Size = new System.Drawing.Size(93, 13);
            this.lblResetUser.TabIndex = 0;
            this.lblResetUser.Text = "Ingrese su usuario";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(345, 43);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnEnviarReset
            // 
            this.btnEnviarReset.Location = new System.Drawing.Point(485, 46);
            this.btnEnviarReset.Name = "btnEnviarReset";
            this.btnEnviarReset.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarReset.TabIndex = 3;
            this.btnEnviarReset.Text = "Enviar";
            this.btnEnviarReset.UseVisualStyleBackColor = true;
            this.btnEnviarReset.Click += new System.EventHandler(this.btnEnviarReset_Click);
            // 
            // FormResetPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnviarReset);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblResetUser);
            this.Name = "FormResetPwd";
            this.Text = "FormResetPwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResetUser;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnEnviarReset;
    }
}