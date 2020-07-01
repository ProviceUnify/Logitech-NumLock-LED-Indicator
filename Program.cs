using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace LogiNumLockLEDIndicator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ConfigurationManager.AppSettings["delay"] == null)
            {
                Thread.Sleep(10000);
                MessageBox.Show("Error: \"Logitech NumLock LED Indicator.exe.config\" not found or content invalid. Used default delay in 10s.", "app.config not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["delay"]));
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
