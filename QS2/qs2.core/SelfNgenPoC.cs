using System;
using System.Diagnostics;
using System.Linq;



namespace qs2.core
{

    public class SelfNgenPoC
    {




        public static void start(bool install)
        {
            try
            {
                /*
                    * Check whether the app has been NGen'd with code adapted from
                    * http://stackoverflow.com/a/20593260/1810429, which also outlines
                    * an alternative approach - by running...
                    *     ngen.exe display <assemblyPath>
                    * ...and checking the result - 0 if the app is already NGen'd and
                    * -1 if it is not.
                    */

                Process process = Process.GetCurrentProcess();

                ProcessModule[] modules = new ProcessModule[process.Modules.Count];
                process.Modules.CopyTo(modules, 0);

                var niQuery =
                    from m in modules
                    where m.FileName.Contains(@"\" + process.ProcessName + ".ni")
                    select m.FileName;
                bool ni = niQuery.Count() > 0 ? true : false;

                if (ni)
                {
                    //System.Windows.Forms.MessageBox.Show("Native Image: " + niQuery.ElementAt(0));
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("IL Image: " + process.MainModule.FileName);
                }

                if (!ni)
                {
                    //Console.WriteLine("The app is not NGen'd.");
                    //Console.WriteLine("NGen'ing the app...");

                    var assemblyPath = process.MainModule.FileName;

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                    startInfo.FileName = winDir + @"\Microsoft.NET\Framework\v4.0.30319\ngen.exe";

                    string sType = "";
                    if (install)
                    {
                        sType = "install";
                    }
                    else
                    {
                        sType = "uninstall";
                    }

                    startInfo.Arguments = sType + " \"" + assemblyPath + "\"";

                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = false;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    try
                    {
                        using (Process exeProcess = Process.Start(startInfo))
                        {
                            exeProcess.WaitForExit();
                            System.Windows.Forms.MessageBox.Show("Sucessfull done!");
                        }
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("SelfNgenPoC.start: " + ex2.ToString());
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("The app is already NGen'd.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("SelfNgenPoC.start: " + ex.ToString());
            }
        }
    }

}