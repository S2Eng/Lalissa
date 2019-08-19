using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Launcher
{

    public class log
    {


        public static void writeLog(string txt, bool isException)
        {
            try
            {
                if (!System.IO.Directory.Exists(update.logPathUpdate))
                {
                    System.IO.Directory.CreateDirectory(update.logPathUpdate);
                }

                string logFile = update.logPathUpdate + "\\Launcher_" + System.Environment.MachineName + ".log";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
                {
                    if (isException)
                    {
                        file.WriteLine(DateTime.Now.ToString() + " - " + "Exception: " + txt + "\r\n" + "\r\n");
                    }
                    else
                    {
                        file.WriteLine(DateTime.Now.ToString() + " - " + "Info: " + txt + "\r\n" + "\r\n");
                    }
                }

                update.runGarbColl();

                //if (!System.IO.File.Exists(logFile))
                //{
                //    System.IO.File.Create(logFile);
                //}

                //txt = "\r\n" + "\r\n" + txt + "\r\n" + "\r\n";
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true);
                //sw.Write(txt);
                //sw.Flush();
                //sw.Close();
            }
            catch (Exception ex)
            {
                string sExcept = "log.writeLog: " + ex.ToString();
                writeEventLog(sExcept);
                throw new Exception(sExcept);
            }
        }

        public static void writeEventLog(string LogTxt)
        {
            //string LogName = System.Windows.Forms.Application.ProductName;
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("PMDS Launcher - Exception: " + LogTxt, EventLogEntryType.Information, 101, 1);
            }
        }

    }

}
