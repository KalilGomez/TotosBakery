using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using capaEntidades;
using capaNegocio;

namespace capaPresentacion
{
    public partial class FormLogin : Form
    {
        /// <summary>
        /// Constructor de la clase FormLogin.
        /// Inicializa los componentes, establece el estilo y configura el formulario sin bordes.
        /// También suscribe el evento FormClosed.
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
            EstablecerEstilo();
            ConfigurarFormularioSinBordes();
            this.FormClosed += FormLogin_FormClosed;
        }

        /// <summary>
        /// Punto para almacenar la última posición del cursor, utilizado para mover el formulario.
        /// </summary>
        private Point lastPoint;

        /// <summary>
        /// Método para establecer el estilo del formulario.
        /// Configura el tamaño, la posición, el fondo y los estilos de los controles del formulario.
        /// </summary>
        private void EstablecerEstilo()
        {
            // Configuración base del formulario
            this.Size = new Size(800, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#FFF0F5");

            // Panel izquierdo
            Panel panelIzquierdo = this.Controls.OfType<Panel>().FirstOrDefault();
            if (panelIzquierdo == null)
            {
                panelIzquierdo = new Panel();
                this.Controls.Add(panelIzquierdo);
            }
            panelIzquierdo.Size = new Size(250, 400);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.BackColor = Color.White;

            // Mover el PictureBox al panel izquierdo
            PictureBox pictureBox = this.Controls.OfType<PictureBox>().FirstOrDefault();
            if (pictureBox != null)
            {
                // Remover el PictureBox de los controles del formulario
                this.Controls.Remove(pictureBox);
                // Agregarlo al panel izquierdo
                panelIzquierdo.Controls.Add(pictureBox);
                pictureBox.BackColor = Color.White;
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                // Centrar el PictureBox en el panel
                pictureBox.Location = new Point(
                    (panelIzquierdo.Width - pictureBox.Width) / 2,
                    (panelIzquierdo.Height - pictureBox.Height) / 1 + 40  // Dividir por 3 para colocarlo más arriba
                );
            }

            // Recorrer los controles existentes y aplicar estilos
            foreach (Control control in this.Controls)
            {
                if (control == panelIzquierdo) continue;

                switch (control)
                {
                    case TextBox txt:
                        EstilizarTextBox(txt);
                        break;
                    case Button btn:
                        EstilizarBoton(btn);
                        break;
                    case LinkLabel link:
                        EstilizarLink(link);
                        break;
                    case Label lbl:
                        EstilizarLabel(lbl);
                        break;
                    case CheckBox chk:
                        EstilizarCheckBox(chk);
                        break;
                }
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
        /// Aplica estilo a un TextBox, eliminando el borde, ajustando el color de fondo y la fuente.
        /// También agrega una línea debajo del TextBox.
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
        /// Aplica estilo a un botón, configurando su apariencia y eventos de hover.
        /// Se enfoca en botones con el texto "iniciar sesión".
        /// </summary>
        /// <param name="button">El botón al que se aplicarán los estilos.</param>
        private void EstilizarBoton(Button button)
        {
            // Verificar si el texto del botón contiene "iniciar sesión", sin importar mayúsculas/minúsculas
            if (button.Text.Contains("iniciar sesión", StringComparison.OrdinalIgnoreCase))
            {
                // Configurar el estilo plano del botón
                button.FlatStyle = FlatStyle.Flat;
                // Establecer el color de fondo del botón
                button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                // Establecer el color del texto del botón
                button.ForeColor = Color.White;
                // Establecer la fuente del botón
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                // Quitar el borde del botón
                button.FlatAppearance.BorderSize = 0;
                // Cambiar el cursor a una mano cuando esté sobre el botón
                button.Cursor = Cursors.Hand;

                // Eventos hover para cambiar el color de fondo del botón
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#E30B5C");
                };
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                };
            }
        }

        /// <summary>
        /// Aplica estilo a un LinkLabel, configurando el color del enlace, el color del enlace activo,
        /// la fuente y el comportamiento del enlace cuando se pasa el cursor sobre él.
        /// </summary>
        /// <param name="link">El LinkLabel al que se aplicarán los estilos.</param>
        private void EstilizarLink(LinkLabel link)
        {
            // Establecer el color del enlace
            link.LinkColor = Color.Red;
            // Establecer el color del enlace activo
            link.ActiveLinkColor = Color.FromArgb(129, 97, 185);
            // Establecer la fuente del LinkLabel
            link.Font = new Font("Segoe UI", 9);
            // Establecer el comportamiento del enlace cuando se pasa el cursor sobre él
            link.LinkBehavior = LinkBehavior.HoverUnderline;
        }

        /// <summary>
        /// Aplica estilo a un Label, ajustando la fuente y el color del texto.
        /// Se enfoca en etiquetas que contienen el texto "BIENVENIDO".
        /// </summary>
        /// <param name="label">El Label al que se aplicarán los estilos.</param>
        private void EstilizarLabel(Label label)
        {
            // Verificar si el texto de la etiqueta contiene "BIENVENIDO", sin importar mayúsculas/minúsculas
            if (label.Text.Contains("BIENVENIDO", StringComparison.OrdinalIgnoreCase))
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
        /// Aplica estilo a un CheckBox, ajustando el color del texto y la fuente.
        /// </summary>
        /// <param name="checkBox">El CheckBox al que se aplicarán los estilos.</param>
        private void EstilizarCheckBox(CheckBox checkBox)
        {
            // Establecer el color del texto del CheckBox
            checkBox.ForeColor = Color.FromArgb(64, 64, 64);
            // Establecer la fuente del CheckBox
            checkBox.Font = new Font("Segoe UI", 9);
        }

        /// <summary>
        /// Manejador de evento para el clic del botón Iniciar Sesión.
        /// Valida los campos, verifica las credenciales del usuario y procede según el resultado.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (!ValidarCamposVacios())
            {
                return;
            }
            try
            {
                // Validar usuario y contraseña
                Usuario usuarioEncontrado = LogicaNegocio.ValidarUsuarioContraseña(txtUsuario.Text, txtContraseña.Text);

                if (usuarioEncontrado != null)
                {
                    // Ocultar el formulario de login
                    this.Hide();
                    FormPrincipal formPrincipal = new FormPrincipal();

                    // Habilitar botón de usuarios si el usuario es administrador
                    if (usuarioEncontrado.Admin == true)
                    {
                        formPrincipal.HabilitarBotonUsuarios();
                    }
                    // Mostrar el formulario principal
                    formPrincipal.Show();
                }
                else
                {
                    // Mostrar mensaje de error si las credenciales son inválidas
                    MessageBox.Show("Usuario y/o contraseña inválido, intente nuevamente",
                                   "Error al iniciar sesión",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    // Limpiar y enfocar el campo de contraseña
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el clic del botón de resetear contraseña.
        /// Muestra un formulario para ingresar el usuario y, si es válido, intenta resetear la contraseña.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnRstPwd_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual
            this.Hide();
            string usuario = "";

            // Mostrar el formulario de reseteo de contraseña
            using (FormResetPwd formReset = new FormResetPwd())
            {
                if (formReset.ShowDialog() == DialogResult.OK)
                {
                    usuario = formReset.Usuario;

                    // Validar que el campo de usuario no esté vacío
                    if (!ValidarCamposVacios2(usuario))
                    {
                        this.Show();
                        return;
                    }

                    try
                    {
                        // Validar la existencia del usuario
                        Usuario usuarioEncontrado = LogicaNegocio.ValidarUsuario(usuario);

                        if (usuarioEncontrado == null)
                        {
                            MessageBox.Show("El usuario no existe. Por favor, verifique el nombre de usuario.",
                                            "Usuario no encontrado",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            this.Show();
                            return;
                        }

                        // Si el usuario existe, intentar resetear la contraseña
                        bool reset = ConexionBdd.ResetearContraseña(usuario);

                        if (reset)
                        {
                            MessageBox.Show("Contraseña reseteada correctamente.",
                                            "Éxito",
                                            MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo resetear la contraseña. Intente nuevamente.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error en caso de excepción
                        MessageBox.Show($"Error al intentar resetear la contraseña: {ex.Message}",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }

            // Mostrar el formulario actual nuevamente
            this.Show();
        }

        /// <summary>
        /// Manejador de evento para la pulsación de teclas en el formulario de inicio de sesión.
        /// Si la tecla presionada es Enter, simula el clic del botón de iniciar sesión.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Simular el clic del botón de iniciar sesión
                btnIniciarSesion.PerformClick(); // Simula el clic del botón
            }
        }

        /// <summary>
        /// Manejador de evento para el cierre del formulario de inicio de sesión.
        /// Cierra la aplicación cuando el formulario se cierra.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cierra la aplicación
            Application.Exit();
        }

        /// <summary>
        /// Valida que los campos de usuario y contraseña no estén vacíos.
        /// Muestra mensajes de advertencia si alguno de los campos está vacío y enfoca el campo correspondiente.
        /// </summary>
        /// <returns>Devuelve true si ambos campos no están vacíos, de lo contrario, devuelve false.</returns>
        private bool ValidarCamposVacios()
        {
            // Verificar si el campo de usuario está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un usuario",
                               "Campo requerido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            // Verificar si el campo de contraseña está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña",
                               "Campo requerido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }

            // Si ambos campos están completos, devolver true
            return true;
        }

        /// <summary>
        /// Valida que el campo de usuario no esté vacío.
        /// Muestra un mensaje de advertencia si el campo está vacío y enfoca el campo correspondiente.
        /// </summary>
        /// <param name="usuario">El nombre de usuario a validar.</param>
        /// <returns>Devuelve true si el campo de usuario no está vacío, de lo contrario, devuelve false.</returns>
        private bool ValidarCamposVacios2(string usuario)
        {
            // Verificar si el campo de usuario está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Debe ingresar un usuario",
                               "Campo requerido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            // Si el campo de usuario no está vacío, devolver true
            return true;
        }

    }
}
