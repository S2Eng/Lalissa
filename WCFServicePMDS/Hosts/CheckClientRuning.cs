using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WCFServicePMDS.Hosts
{

    public class CheckClientRunning
    {

        public static Thread threadCheckClient = null;



        public bool start()
        {
            try
            {
                Thread ActionThread = new Thread(new ParameterizedThreadStart(tCheckClient));
                ActionThread.Start(new { ENV.CurrentProcessId });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("CheckClientRunning.start: " + ex.ToString());
            }
        }

        public void tCheckClient(object pars)
        {
            try
            {
                dynamic p = pars;
                int procID = p.CurrentProcessId;

                bool bEnd = false;
                while (!bEnd)
                {
                    Thread.Sleep(60 * 1000);
                    bool bFoundClient = false;

                    Process[] pr = Process.GetProcessesByName("PMDS.Main");
                    foreach (Process prs in pr)
                    {
                        if (prs.Id == procID)
                            bFoundClient = true;
                    }
                    if (!bFoundClient)
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                }

            }
            catch (Exception ex)
            {
                this.WriteLog(ex.ToString());
                throw new Exception("CheckClientRunning.tCheckClient: " + ex.ToString());
            }
        }


        public void WriteLog(string except)
        {
            string logName = "Application";
            System.Diagnostics.EventLog objEventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists(logName))
            {
                System.Diagnostics.EventLog.CreateEventSource(logName, "");
            }

            objEventLog.Source = logName;
            objEventLog.WriteEntry(except, System.Diagnostics.EventLogEntryType.Error, 3400);
        }

    }

}


