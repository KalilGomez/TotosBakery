namespace capaPresentacion
{
    /// <summary>
    /// Representa la clase parcial <c>FormAgregarPedido</c>, que gestiona la interfaz de usuario
    /// para agregar un nuevo pedido en la aplicación.
    /// </summary>
    partial class FormAgregarPedido
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
        /// Caja de texto para ingresar la dirección del pedido.
        /// </summary>
        private System.Windows.Forms.TextBox txtDir;

        /// <summary>
        /// Etiqueta que indica el campo para seleccionar el método de pago.
        /// </summary>
        private System.Windows.Forms.Label lblMetPag;

        /// <summary>
        /// Etiqueta que indica el campo para seleccionar la fecha del pedido.
        /// </summary>
        private System.Windows.Forms.Label lblFecha;

        /// <summary>
        /// Etiqueta que indica el campo para ingresar la dirección del cliente.
        /// </summary>
        private System.Windows.Forms.Label lblDirec;

        /// <summary>
        /// Botón para cancelar la operación de agregar un pedido.
        /// </summary>
        private System.Windows.Forms.Button BtnCancelar;

        /// <summary>
        /// Botón para confirmar y aceptar el pedido.
        /// </summary>
        private System.Windows.Forms.Button BtnAceptar;

        /// <summary>
        /// Etiqueta que indica el campo para seleccionar un cliente.
        /// </summary>
        private System.Windows.Forms.Label lblCliente;

        /// <summary>
        /// Lista desplegable para seleccionar el cliente relacionado con el pedido.
        /// </summary>
        private System.Windows.Forms.ComboBox cboxCliente;

        /// <summary>
        /// Lista desplegable para seleccionar el método de pago.
        /// </summary>
        private System.Windows.Forms.ComboBox cboxMetPag;

        /// <summary>
        /// Selector de fecha para especificar la fecha del pedido.
        /// </summary>
        private System.Windows.Forms.DateTimePicker dtpFecha;

        /// <summary>
        /// Botón para acceder a opciones avanzadas relacionadas con el pedido.
        /// </summary>
        private System.Windows.Forms.Button btnAvanzado;
    }
}
