using System;
using System.IO;
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
            fileCheckAndRun();
        }

        //Check files needed (Weather and Login Data) are available and runs the program if they are
        private static void fileCheckAndRun()
        {
            if (File.Exists(@"../../WeatherData.txt") && File.Exists(@"../../LoginDetails.txt"))
            {
                Weather.populateArrayLists();
                Application.Run(new Login());
            }
            else
            {
                MessageBox.Show("One or more files required for the program to run are missing. Please make sure the WeatherData.txt and LoginDetails.txt files are in the project folder (The same folder as the source files) and try again.");
            }
        }
    }
}