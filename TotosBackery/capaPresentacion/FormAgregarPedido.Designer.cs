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
            txtDir = new TextBox();
            lblMetPag = new Label();
            lblFecha = new Label();
            lblDirec = new Label();
            BtnCancelar = new Button();
            BtnAceptar = new Button();
            lblCliente = new Label();
            cboxCliente = new ComboBox();
            cboxMetPag = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnAvanzado = new Button();
            SuspendLayout();
            // 
            // txtDir
            // 
            txtDir.Location = new Point(478, 138);
            txtDir.Margin = new Padding(4, 3, 4, 3);
            txtDir.Name = "txtDir";
            txtDir.Size = new Size(116, 23);
            txtDir.TabIndex = 19;
            // 
            // lblMetPag
            // 
            lblMetPag.AutoSize = true;
            lblMetPag.Location = new Point(366, 212);
            lblMetPag.Margin = new Padding(4, 0, 4, 0);
            lblMetPag.Name = "lblMetPag";
            lblMetPag.Size = new Size(95, 15);
            lblMetPag.TabIndex = 16;
            lblMetPag.Text = "Metodo de pago";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(366, 179);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 15;
            lblFecha.Text = "Fecha";
            // 
            // lblDirec
            // 
            lblDirec.AutoSize = true;
            lblDirec.Location = new Point(366, 147);
            lblDirec.Margin = new Padding(4, 0, 4, 0);
            lblDirec.Name = "lblDirec";
            lblDirec.Size = new Size(57, 15);
            lblDirec.TabIndex = 14;
            lblDirec.Text = "Direccion";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(610, 373);
            BtnCancelar.Margin = new Padding(4, 3, 4, 3);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(88, 27);
            BtnCancelar.TabIndex = 13;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnAceptar
            // 
            BtnAceptar.Location = new Point(443, 373);
            BtnAceptar.Margin = new Padding(4, 3, 4, 3);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(88, 27);
            BtnAceptar.TabIndex = 12;
            BtnAceptar.Text = "Aceptar";
            BtnAceptar.UseVisualStyleBackColor = true;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(366, 105);
            lblCliente.Margin = new Padding(4, 0, 4, 0);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 20;
            lblCliente.Text = "Cliente";
            // 
            // cboxCliente
            // 
            cboxCliente.FormattingEnabled = true;
            cboxCliente.Location = new Point(478, 96);
            cboxCliente.Margin = new Padding(4, 3, 4, 3);
            cboxCliente.Name = "cboxCliente";
            cboxCliente.Size = new Size(140, 23);
            cboxCliente.TabIndex = 21;
            // 
            // cboxMetPag
            // 
            cboxMetPag.FormattingEnabled = true;
            cboxMetPag.Location = new Point(478, 209);
            cboxMetPag.Margin = new Padding(4, 3, 4, 3);
            cboxMetPag.Name = "cboxMetPag";
            cboxMetPag.Size = new Size(140, 23);
            cboxMetPag.TabIndex = 22;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(478, 172);
            dtpFecha.Margin = new Padding(4, 3, 4, 3);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(233, 23);
            dtpFecha.TabIndex = 23;
            // 
            // btnAvanzado
            // 
            btnAvanzado.Location = new Point(700, 93);
            btnAvanzado.Margin = new Padding(4, 3, 4, 3);
            btnAvanzado.Name = "btnAvanzado";
            btnAvanzado.Size = new Size(88, 27);
            btnAvanzado.TabIndex = 24;
            btnAvanzado.Text = "Avanzado";
            btnAvanzado.UseVisualStyleBackColor = true;
            // 
            // FormAgregarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnAvanzado);
            Controls.Add(dtpFecha);
            Controls.Add(cboxMetPag);
            Controls.Add(cboxCliente);
            Controls.Add(lblCliente);
            Controls.Add(txtDir);
            Controls.Add(lblMetPag);
            Controls.Add(lblFecha);
            Controls.Add(lblDirec);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnAceptar);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormAgregarPedido";
            Text = "FormAgregarPedido";
            Load += FormAgregarPedido_Load;
            ResumeLayout(false);
            PerformLayout();
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