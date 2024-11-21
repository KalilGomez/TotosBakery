namespace capaPresentacion
{
    /// <summary>
    /// Representa la clase parcial <c>FormAgregarCliente</c>, utilizada para gestionar la interfaz de usuario
    /// para agregar un nuevo cliente en la aplicación.
    /// </summary>
    partial class FormAgregarCliente
    {
        /// <summary>
        /// Contenedor necesario para gestionar los componentes del diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Libera los recursos no administrados y, opcionalmente, los administrados utilizados por el formulario.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> para liberar tanto recursos administrados como no administrados; 
        /// <see langword="false"/> para liberar solo recursos no administrados.
        /// </param>
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
        /// Método requerido para el soporte del Diseñador de Windows Forms.
        /// No modifique el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            // Aquí se inicializan y configuran los controles del formulario.
        }

        #endregion

        /// <summary>
        /// Botón para confirmar y aceptar los datos del nuevo cliente.
        /// </summary>
        private System.Windows.Forms.Button BtnAceptar;

        /// <summary>
        /// Botón para cancelar la operación de agregar un nuevo cliente.
        /// </summary>
        private System.Windows.Forms.Button BtnCancelar;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar el nombre del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblNombre;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar el apellido del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblApellido;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar la dirección del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblDireccion;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar el teléfono del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblTelefono;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar el correo electrónico del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblMail;

        /// <summary>
        /// Caja de texto para ingresar el nombre del cliente.
        /// </summary>
        private System.Windows.Forms.TextBox txtNombre;

        /// <summary>
        /// Caja de texto para ingresar el correo electrónico del cliente.
        /// </summary>
        private System.Windows.Forms.TextBox txtMail;

        /// <summary>
        /// Caja de texto para ingresar el número de teléfono del cliente.
        /// </summary>
        private System.Windows.Forms.TextBox txtTelefono;

        /// <summary>
        /// Caja de texto para ingresar la dirección del cliente.
        /// </summary>
        private System.Windows.Forms.TextBox txtDireccion;

        /// <summary>
        /// Caja de texto para ingresar el apellido del cliente.
        /// </summary>
        private System.Windows.Forms.TextBox txtApellido;
    }
}
