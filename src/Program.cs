using Piksel.Dearchiver.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piksel.Dearchiver
{
    static class Program
    {
        internal const string ProgID = "Dearchiver.zip.1";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            try
            {
                if (!Properties.Settings.Default.Upgraded)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.Upgraded = true;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show($"Error upgrading settings:\n{x.GetType().Name}: {x.Message}\n\nSettings may not be saved correctly.", 
                    "Dearchiver settings", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (argv.Length > 0)
            {
                Application.Run(new FormMain());
            }
            else
            {
                Application.Run(new FormInstall());
            }
        }

        internal static void OpenArchive(string file)
        {
            Process.Start(Process.GetCurrentProcess().MainModule.FileName, file);
        }
    }
}
