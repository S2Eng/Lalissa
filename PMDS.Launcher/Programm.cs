using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Launcher
{


    public static class Program
    {


        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new frmLauncher2());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - Launcher.Program.Main: " + ex.ToString(), "PMDS - Launcher");
            }
        }

    }

}