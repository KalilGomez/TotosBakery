namespace capaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            // Inicializa la configuración de la aplicación. 
            // Esto puede incluir ajustes de DPI alto, fuentes predeterminadas, etc.
           
            ApplicationConfiguration.Initialize();

            // Inicia y muestra el formulario principal de la aplicación.
            // En este caso, se trata del formulario de inicio de sesión.

            Application.Run(new FormLogin());
        }
    }
}