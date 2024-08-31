using Gmap.Controllers;

namespace Gmap
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
            /*ApplicationConfiguration.Initialize();
            Application.Run(new Main());*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main mainForm = new Main();
            MainController controller = new MainController(mainForm.GMapControl);
            Application.Run(mainForm);
        }
    }
}