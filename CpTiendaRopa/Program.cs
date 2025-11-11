namespace CpTiendaRopa
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar DPI Awareness para mejor renderizado
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmAutenticacion()); // Iniciar con el Login
        }
    }
}