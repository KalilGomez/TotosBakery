namespace capaEntidades
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string mail;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }

        public Cliente(int id, string nombre, string apellido, string telefono, string mail, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.mail = mail;
            this.direccion = direccion;
        }
        public Cliente() { }
    }
}
