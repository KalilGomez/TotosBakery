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
        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string Usuario { get; private set; }

        /// <summary>
        /// Constructor de la clase FormResetPwd.
        /// Inicializa los componentes, establece el estilo y configura el formulario sin bordes.
        /// </summary>
        public FormResetPwd()
        {
            InitializeComponent();
            EstablecerEstilo();
            ConfigurarFormularioSinBordes();
        }

        /// <summary>
        /// Punto para almacenar la última posición del cursor, utilizado para mover el formulario.
        /// </summary>
        private Point lastPoint;

        /// <summary>
        /// Aplica estilo al formulario, ajustando su tamaño, posición y color de fondo.
        /// Recorre los controles existentes y aplica estilos específicos según su tipo.
        /// </summary>
        private void EstablecerEstilo()
        {
            // Configuración base del formulario
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

        /// <summary>
        /// Aplica estilo a un TextBox, eliminando el borde, ajustando el color de fondo y la fuente.
        /// También agrega una línea debajo del TextBox para un estilo visual mejorado.
        /// </summary>
        /// <param name="textBox">El TextBox al que se aplicarán los estilos.</param>
        private void EstilizarTextBox(TextBox textBox)
        {
            // Eliminar el borde del TextBox
            textBox.BorderStyle = BorderStyle.None;
            // Establecer el color de fondo del TextBox
            textBox.BackColor = ColorTranslator.FromHtml("#FFF0F5");
            // Establecer la fuente del TextBox
            textBox.Font = new Font("Segoe UI", 10);

            // Crear o encontrar la línea debajo del TextBox
            string lineaName = "linea_" + textBox.Name;
            Panel linea = this.Controls.OfType<Panel>()
                             .FirstOrDefault(p => p.Name == lineaName);

            // Si no se encuentra una línea existente, crear una nueva
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
            // Traer la línea al frente
            linea.BringToFront();
        }

        /// <summary>
        /// Aplica estilo a un Button, ajustando su apariencia y eventos de hover.
        /// Se enfoca en botones con los textos "Aceptar" o "volver".
        /// </summary>
        /// <param name="button">El Button al que se aplicarán los estilos.</param>
        private void EstilizarBoton(Button button)
        {
            // Verificar si el texto del botón contiene "Aceptar", sin importar mayúsculas/minúsculas
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
                button.Paint += Button_Paint;
            }
            // Verificar si el texto del botón contiene "volver", sin importar mayúsculas/minúsculas
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
        }

        /// <summary>
        /// Aplica estilo a un Label, ajustando la fuente y el color del texto.
        /// Se enfoca en etiquetas que contienen el texto "Resetear".
        /// </summary>
        /// <param name="label">El Label al que se aplicarán los estilos.</param>
        private void EstilizarLabel(Label label)
        {
            // Verificar si el texto de la etiqueta contiene "Resetear", sin importar mayúsculas/minúsculas
            if (label.Text.Contains("Resetear", StringComparison.OrdinalIgnoreCase))
            {
                // Configurar la fuente y el estilo de la etiqueta
                label.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                // Establecer el color del texto de la etiqueta
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                // Configurar la fuente de la etiqueta
                label.Font = new Font("Segoe UI", 10);
                // Establecer el color del texto de la etiqueta
                label.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        /// <summary>
        /// Configura el formulario para que no tenga bordes y agrega botones personalizados para cerrar y minimizar.
        /// También permite que el formulario se pueda mover arrastrándolo.
        /// </summary>
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

        /// <summary>
        /// Manejador de evento para el pintado del botón.
        /// Dibuja un borde blanco alrededor del botón.
        /// </summary>
        /// <param name="sender">El botón que envía el evento.</param>
        /// <param name="e">Los datos del evento de dibujo.</param>
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Dibujar borde blanco
                Pen pen = new Pen(Color.White, 1); // Color blanco y grosor 2
                Rectangle rect = btn.ClientRectangle;
                rect.Width -= 1; // Ajustar ancho del rectángulo
                rect.Height -= 1; // Ajustar alto del rectángulo
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de enviar reseteo.
        /// Guarda el nombre de usuario y cierra el formulario con un resultado de diálogo OK.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEnviarReset_Click(object sender, EventArgs e)
        {
            // Guardar el nombre de usuario
            Usuario = txtUsuario.Text;
            // Establecer el resultado del diálogo como OK
            this.DialogResult = DialogResult.OK;
            // Cerrar el formulario
            this.Close();
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de cerrar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            this.Close();
        }

    }
}
