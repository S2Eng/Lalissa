using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

                string logFile = Path.Combine(update.logPathUpdate,  "Launcher_" + System.Environment.MachineName + ".log");
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
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("PMDS Launcher - Exception: " + LogTxt, EventLogEntryType.Information, 101, 1);
            }
        }

    }

}
