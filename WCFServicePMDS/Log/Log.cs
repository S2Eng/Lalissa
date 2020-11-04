using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    public class Log
    {


        public static void write(string LogTxt, bool isException, int lfdNrFilename)
        {
            try
            {
                if (!System.IO.Directory.Exists(ENV.ENVWcf.LogPath))
                {
                    System.IO.Directory.CreateDirectory(ENV.ENVWcf.LogPath);
                }
                string sFileNr = "";
                if (lfdNrFilename > 0)
                {
                    sFileNr = "_" + lfdNrFilename.ToString();
                }

                string logFile = ENV.ENVWcf.LogPath + "\\PMDSWCFService_" + System.Environment.MachineName + "" + sFileNr + ".log";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
                {
                    string sTitle = "";
                    if (isException)
                    {
                        sTitle = "Exception";
                    }
                    else
                    {
                        sTitle = "Info";
                    }
                    string txtFile = DateTime.Now.ToString() + " - " + sTitle + ", Version: " + WCFServicePMDS.ENV.VersionNr.ToString() + "" + "\r\n" + LogTxt + "\r\n" + "\r\n";
                    file.WriteLine(txtFile);
                }

                System.GC.Collect();

                //if (!System.IO.File.Exists(logFile))
                //{
                //    System.IO.File.Create(logFile);
                //}

                //System.GC.Collect();
                //txt = "\r\n" + "\r\n" + txt + "\r\n" + "\r\n";
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true);
                //sw.Write(txt);
                //sw.Flush();
                //sw.Close();
                //System.GC.Collect();

            }
            catch (UnauthorizedAccessException ex)
            {
                if (lfdNrFilename <= 3)
                {
                    lfdNrFilename += 1;
                    generic.waitMS(100);
                    Log.write(LogTxt, isException, lfdNrFilename);
                }
                else
                {
                    string sExcept = "WCFService.log.writeLog: " + ex.ToString();
                    Log.saveWindowsLog(sExcept);
                    //throw new Exception(sExcept);
                }
            }
            catch (Exception ex)
            {
                string sExcept = "WCFService.log.writeLog: " + ex.ToString();
                Log.saveWindowsLog(sExcept);
                //throw new Exception(sExcept);
            }
        }

        public static void writeOld(string LogTxt, bool IsExcept)
        {
            try
            {
                string LogFile = Path.Combine(ENV.ENVWcf.LogPath, "BlisterService_" + DateTime.Now.ToString("yyyyMMdd") + ".log");

                if (!System.IO.Directory.Exists(ENV.ENVWcf.LogPath))
                {
                    System.IO.Directory.CreateDirectory(ENV.ENVWcf.LogPath);
                }
                if (!System.IO.File.Exists(LogFile))
                {
                    System.IO.File.Create(LogFile).Dispose();
                }

                string logTxtTmp = "";
                if (IsExcept)
                {
                    logTxtTmp = DateTime.Now.ToString() + " - " + "Exception!" + "\r\n" + LogTxt + "\r\n" + "\r\n";
                }
                else
                {
                    logTxtTmp = DateTime.Now.ToString() + ": " + LogTxt + "\r\n";
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter(LogFile, true);
                sw.Write(logTxtTmp);
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {
                Log.saveWindowsLog(LogTxt);
            }
        }

        public static void saveWindowsLog(string LogTxt)
        {
            System.Diagnostics.EventLog objEventLog = new System.Diagnostics.EventLog();
            objEventLog.Source = "Application";
            objEventLog.WriteEntry("PMDS.WindowsService Error: " + LogTxt.Trim(), System.Diagnostics.EventLogEntryType.Error);
        }

    }

}
