namespace capaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            // Inicializa la configuraci�n de la aplicaci�n. 
            // Esto puede incluir ajustes de DPI alto, fuentes predeterminadas, etc.
           
            ApplicationConfiguration.Initialize();

            // Inicia y muestra el formulario principal de la aplicaci�n.
            // En este caso, se trata del formulario de inicio de sesi�n.

            Application.Run(new FormLogin());
        }
    }
}