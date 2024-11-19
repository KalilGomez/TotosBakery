namespace capaEntidades
{
    /// <summary>
    /// Representa a un cliente en el sistema.
    /// </summary>
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string mail;

        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Obtiene o establece el apellido del cliente.
        /// </summary>
        public string Apellido { get => apellido; set => apellido = value; }

        /// <summary>
        /// Obtiene o establece la dirección del cliente.
        /// </summary>
        public string Direccion { get => direccion; set => direccion = value; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del cliente.
        /// </summary>
        public string Telefono { get => telefono; set => telefono = value; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del cliente.
        /// </summary>
        public string Mail { get => mail; set => mail = value; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cliente"/> con valores especificados.
        /// </summary>
        /// <param name="id">El identificador único del cliente.</param>
        /// <param name="nombre">El nombre del cliente.</param>
        /// <param name="apellido">El apellido del cliente.</param>
        /// <param name="telefono">El número de teléfono del cliente.</param>
        /// <param name="mail">El correo electrónico del cliente.</param>
        /// <param name="direccion">La dirección del cliente.</param>
        public Cliente(int id, string nombre, string apellido, string telefono, string mail, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.mail = mail;
            this.direccion = direccion;
        }

        /// <summary>
        /// Inicializa una nueva instancia vacía de la clase <see cref="Cliente"/>.
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cliente"/> con un identificador especificado.
        /// </summary>
        /// <param name="idCliente">El identificador único del cliente.</param>
        public Cliente(int idCliente)
        {
            this.id = idCliente;
        }
    }
}
