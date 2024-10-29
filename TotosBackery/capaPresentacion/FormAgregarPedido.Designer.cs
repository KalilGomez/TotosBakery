namespace capaPresentacion
{
    partial class FormAgregarPedido
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
            this.txtDir = new System.Windows.Forms.TextBox();
            this.lblMetPag = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDirec = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboxCliente = new System.Windows.Forms.ComboBox();
            this.cboxMetPag = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAvanzado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(410, 120);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 20);
            this.txtDir.TabIndex = 19;
            // 
            // lblMetPag
            // 
            this.lblMetPag.AutoSize = true;
            this.lblMetPag.Location = new System.Drawing.Point(314, 184);
            this.lblMetPag.Name = "lblMetPag";
            this.lblMetPag.Size = new System.Drawing.Size(85, 13);
            this.lblMetPag.TabIndex = 16;
            this.lblMetPag.Text = "Metodo de pago";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(314, 155);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha";
            // 
            // lblDirec
            // 
            this.lblDirec.AutoSize = true;
            this.lblDirec.Location = new System.Drawing.Point(314, 127);
            this.lblDirec.Name = "lblDirec";
            this.lblDirec.Size = new System.Drawing.Size(52, 13);
            this.lblDirec.TabIndex = 14;
            this.lblDirec.Text = "Direccion";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(523, 323);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(380, 323);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(314, 91);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 20;
            this.lblCliente.Text = "Cliente";
            // 
            // cboxCliente
            // 
            this.cboxCliente.FormattingEnabled = true;
            this.cboxCliente.Location = new System.Drawing.Point(410, 83);
            this.cboxCliente.Name = "cboxCliente";
            this.cboxCliente.Size = new System.Drawing.Size(121, 21);
            this.cboxCliente.TabIndex = 21;
            // 
            // cboxMetPag
            // 
            this.cboxMetPag.FormattingEnabled = true;
            this.cboxMetPag.Location = new System.Drawing.Point(410, 181);
            this.cboxMetPag.Name = "cboxMetPag";
            this.cboxMetPag.Size = new System.Drawing.Size(121, 21);
            this.cboxMetPag.TabIndex = 22;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(410, 149);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // btnAvanzado
            // 
            this.btnAvanzado.Location = new System.Drawing.Point(600, 81);
            this.btnAvanzado.Name = "btnAvanzado";
            this.btnAvanzado.Size = new System.Drawing.Size(75, 23);
            this.btnAvanzado.TabIndex = 24;
            this.btnAvanzado.Text = "Avanzado";
            this.btnAvanzado.UseVisualStyleBackColor = true;
            // 
            // FormAgregarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAvanzado);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cboxMetPag);
            this.Controls.Add(this.cboxCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.lblMetPag);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblDirec);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Name = "FormAgregarPedido";
            this.Text = "FormAgregarPedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label lblMetPag;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDirec;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboxCliente;
        private System.Windows.Forms.ComboBox cboxMetPag;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnAvanzado;
    }
}