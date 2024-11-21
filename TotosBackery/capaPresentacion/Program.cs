namespace capaPresentacion
{
    /// <summary>
    /// Clase que contiene el punto de entrada principal para la aplicaci�n.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n.
        /// Este m�todo se encarga de inicializar la configuraci�n de la aplicaci�n
        /// y de iniciar el formulario principal de la misma, en este caso, el formulario de inicio de sesi�n.
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