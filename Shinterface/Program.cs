using System.Windows.Forms.VisualStyles;

namespace Shinterface
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetColorMode(SystemColorMode.Dark);
            
            Application.Run(new Form1());
        }
    }
}