using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class FormResetPwd : Form
    {
        public string Usuario { get; private set; }
        public FormResetPwd()
        {
            InitializeComponent();
            EstablecerEstilo();
            ConfigurarFormularioSinBordes();

        }
        private Point lastPoint;
        private void EstablecerEstilo()
        {
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#FFF0F5");
            // Recorrer los controles existentes y aplicar estilos
            foreach (Control control in this.Controls)
            {
                // Aplicar estilos según el tipo de control
                switch (control)
                {
                    case TextBox txt:
                        EstilizarTextBox(txt);
                        break;
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                    case Label lbl:
                        EstilizarLabel(lbl);
                        break;
                }
            }
        }
        private void EstilizarTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = ColorTranslator.FromHtml("#FFF0F5");
            textBox.Font = new Font("Segoe UI", 10);

            // Crear o encontrar la línea debajo del TextBox
            string lineaName = "linea_" + textBox.Name;
            Panel linea = this.Controls.OfType<Panel>()
                             .FirstOrDefault(p => p.Name == lineaName);

            if (linea == null)
            {
                linea = new Panel
                {
                    Name = lineaName,
                    Size = new Size(textBox.Width, 2),
                    Location = new Point(textBox.Left, textBox.Bottom + 1),
                    BackColor = ColorTranslator.FromHtml("#000000")
                };
                this.Controls.Add(linea);
            }
            linea.BringToFront();
        }
        private void EstilizarBoton(Button button)
        {
            if (button.Text.IndexOf("Aceptar", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;


                // Eventos hover
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#E30B5C");
                };
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                };
            }
            else if (button.Text.IndexOf("volver", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;


                // Eventos hover
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#E30B5C");
                };
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                };
            }
            else
            {
                // Estilo por defecto para otros botones
                button.FlatStyle = FlatStyle.Standard;
                button.BackColor = SystemColors.Control;
                button.ForeColor = SystemColors.ControlText;
                button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                button.FlatAppearance.BorderSize = 1;
                button.Cursor = Cursors.Hand;
            }
            //if (new[] { "volver", "aceptar" }
            //.Any(keyword => button.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            //{
            //    // Configuración para botones "volver" y "aceptar"
            //}
            //if (button.Text.IndexOf("volver", StringComparison.OrdinalIgnoreCase) >= 0 ||
            //button.Text.IndexOf("aceptar", StringComparison.OrdinalIgnoreCase) >= 0)
            //{
            //    // Configuración para botones "volver" y "aceptar"
            //}

        }
        private void EstilizarLabel(Label label)
        {
            if (label.Text.Contains("Resetear", StringComparison.OrdinalIgnoreCase))
            {
                label.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                label.Font = new Font("Segoe UI", 10);
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }
        private void ConfigurarFormularioSinBordes()
        {
            // Configuración básica del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Agregar botón de cerrar
            Button btnCerrar = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(this.Width - 30, 5),
                Text = "×",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            // Agregar botón minimizar
            Button btnMinimizar = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(this.Width - 55, 5),
                Text = "―",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.Controls.Add(btnMinimizar);

            // Eventos para mover el formulario
            this.MouseDown += (s, e) =>
            {
                lastPoint = new Point(e.X, e.Y);
            };

            this.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - lastPoint.X;
                    this.Top += e.Y - lastPoint.Y;
                }
            };

            // Efectos hover para los botones
            btnCerrar.MouseEnter += (s, e) => btnCerrar.ForeColor = Color.Red;
            btnCerrar.MouseLeave += (s, e) => btnCerrar.ForeColor = Color.DimGray;

            btnMinimizar.MouseEnter += (s, e) => btnMinimizar.ForeColor = Color.Gray;
            btnMinimizar.MouseLeave += (s, e) => btnMinimizar.ForeColor = Color.DimGray;
        }


        private void btnEnviarReset_Click(object sender, EventArgs e)
        {
            Usuario = txtUsuario.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
