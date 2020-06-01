using System;
using System.Windows.Forms;

namespace Task2_19003041_PROG6211
{
    internal static class WeatherForecaster
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Weather.populateArrayLists();
            Application.Run(new Login());
        }
    }
}