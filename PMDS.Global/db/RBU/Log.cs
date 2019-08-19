using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;




namespace RBU
{
    
    public enum LogDestinations
    {
        Console = 0,
        EventLog,
        File
    }

    public enum LogLevels
    {
        Errors = 0,
        Messages,
        Debug
    }

    
    public class Log
    {
        private static RBU.Log m_internlog;

        private static string _sBevoreExceptionString = "\r\n----------------Exception Trace--------------------------------\r\n";
        private int m_iRolloverLimit = 500000;
        private LogDestinations m_destination;
        private string m_sLogFile;
        private string m_sEventLog;
        private LogLevels m_Level;
        private Mutex m_mutex;
        private string m_sUser;                       
        private RBU.ConfigFile m_ConfigFile;                   
        private RBU.ConfigFile m_ConfigFileUser;               
        private string m_sHelpFile;
        private DateTime m_dtValidTO;
        private string m_sLicenceKey;                     
        private string m_sUDF;                           
        private int m_iMainWindow_X_pos;         
        private int m_iMainWindow_Y_pos;             

        public static event LogWriterDelegate LogInfo;        
        public static event LogWriterFormatedDelegate LogInfoFormatted; 







        public static RBU.Log LOG
        {
            get
            {
                return m_internlog;
            }
        }


        public int ROLLOVERLIMIT
        {
            get
            {
                return m_iRolloverLimit;
            }
            set
            {
                m_iRolloverLimit = value;
            }
        }

        public static void RegisterStandardLog(LogDestinations dest, string sDest)
        {
            m_internlog = new Log(dest);
            m_internlog.LogFile = sDest;
            m_internlog.EventLog = sDest;
            LogInfo += new LogWriterDelegate(m_internlog.Write);
        }

        public static void WriteError(string sMessage, params object[] sParams)
        {
            OnLogInfo(LogLevels.Errors, sMessage, sParams);
        }

        public static void WriteError(string sMessage)
        {
            OnLogInfo(LogLevels.Errors, sMessage, null);
        }

        public static void WriteError(string sMessage, bool bShow)
        {
            if (bShow)
                WriteErrorAndShow(sMessage);
            else
                WriteError(sMessage);
        }

        public static void WriteDebug(string sMessage, params object[] sParams)
        {
            OnLogInfo(LogLevels.Debug, sMessage, sParams);
        }

        public static void WriteDebug(string sMessage)
        {
            OnLogInfo(LogLevels.Debug, sMessage, null);
        }

        public static void WriteErrorAndShow(string sMessage, bool bUseParams, params object[] sParams)
        {
            if (sParams != null)
                MessageBox.Show(string.Format(sMessage, sParams));
            else
                MessageBox.Show(sMessage);

            OnLogInfo(LogLevels.Errors, sMessage, sParams);
        }

        public static void WriteErrorAndShow(string sMessage)
        {
            WriteErrorAndShow(sMessage, true, null);
        }

        protected static void OnLogInfo(LogLevels level, string sMessage, params object[] sParams)
        {
            if (LogInfo != null)
                LogInfo(level, sMessage, sParams);
            if (LogInfoFormatted != null)
            {
                if (sParams != null)
                    LogInfoFormatted(level, GetLevelDateStringFromLogLevel(level) + string.Format(sMessage, sParams));
                else
                    LogInfoFormatted(level, GetLevelDateStringFromLogLevel(level) + sMessage);
            }

        }

        public Log(LogDestinations dest)
        {
            m_destination = dest;
            m_Level = LogLevels.Debug;
            m_mutex = new Mutex();
            m_sLogFile = "";
            m_sEventLog = "";
            m_sUser = "";
            m_dtValidTO = new DateTime(1900, 1, 1, 0, 0, 0);          
            m_sLicenceKey = "";
            m_sUDF = "                    ";
            m_iMainWindow_X_pos = 0;
            m_iMainWindow_Y_pos = 0;
        }

        public string LogFile
        {
            get
            {
                return m_sLogFile;
            }
            set
            {
                m_sLogFile = value;
            }
        }

        public string HELPFILE
        {
            get
            {
                return m_sHelpFile;
            }
            set
            {
                m_sHelpFile = value;
            }
        }

        public RBU.ConfigFile ConfigFile
        {
            get
            {
                return m_ConfigFile;
            }
            set
            {
                m_ConfigFile = value;
            }
        }

        public RBU.ConfigFile ConfigFileUser
        {
            get
            {
                return m_ConfigFileUser;
            }
            set
            {
                m_ConfigFileUser = value;
            }
        }

        public LogLevels Level
        {
            get
            {
                return m_Level;
            }
            set
            {
                m_Level = value;
            }
        }
        public string EventLog
        {
            get
            {
                return m_sEventLog;
            }
            set
            {
                m_sEventLog = value;
            }
        }

        public LogDestinations Destination
        {
            get
            {
                return m_destination;
            }
            set
            {
                m_destination = value;
            }
        }

        private void RolloverFile(FileInfo info)
        {
            string sNewFile = DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString();
            sNewFile = sNewFile.Replace(':', '_');
            sNewFile = sNewFile.Replace(' ', '_');
            sNewFile = info.FullName + sNewFile + info.Extension;
            System.IO.File.Move(info.FullName, sNewFile);
        }

        private static string GetLevelDateStringFromLogLevel(LogLevels level)
        {
            StringBuilder sb = new StringBuilder();
            switch (level)
            {
                case LogLevels.Errors:
                    sb.Append("E:> ");
                    sb.Append(DateTime.Now.ToString());
                    sb.Append(" - ");
                    break;
                case LogLevels.Messages:
                    sb.Append("M:> ");
                    sb.Append(DateTime.Now.ToString());
                    sb.Append(" - ");
                    break;
                case LogLevels.Debug:
                    sb.Append("D:> ");
                    sb.Append(DateTime.Now.ToString());
                    sb.Append(" - ");
                    break;
            }
            return sb.ToString();
        }

        public void Write(LogLevels level, string sMessage, params object[] sParams)
        {
            if (level > m_Level)            
                return;

            object[] sPar;
            if (sParams == null)
            {
                sPar = new object[0];
            }
            else
            {
                sPar = sParams;
            }

            StreamWriter writer = null;
            System.Diagnostics.EventLog log = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetLevelDateStringFromLogLevel(level));     
                sb.Append(sMessage);
                sMessage = sb.ToString();

                if (sPar.Length > 0)
                {
                    sMessage = string.Format(sMessage, sPar);
                }

                sMessage = sMessage.Replace("\r", "{{{\\r}}}");
                sMessage = sMessage.Replace("\n", "{{{\\n}}}");

                m_mutex.WaitOne();                          
                switch (m_destination)
                {
                    case LogDestinations.Console:
                        if (level <= m_Level)
                            Console.WriteLine(sMessage);
                        break;

                    case LogDestinations.File:
                        FileInfo info = new FileInfo(m_sLogFile);
                        if (info.Exists)
                        {
                            if (info.Length > m_iRolloverLimit)
                                RolloverFile(info);
                        }
                        if (info.FullName.Trim().Length == 0)
                        {
                            MessageBox.Show("RBU.Log::Write() - Es wurde kein Dateiname für die LOG Datei angegeben - LOG kann nicht geschrieben werden");
                            return;
                        }
                        writer = new StreamWriter(info.FullName, true);
                        writer.WriteLine(sMessage);
                        writer.Close();
                        break;

                    case LogDestinations.EventLog:
                        if (!System.Diagnostics.EventLog.SourceExists(m_sEventLog))
                        {
                            System.Diagnostics.EventLog.CreateEventSource(m_sEventLog, m_sEventLog);
                        }

                        //log = new System.Diagnostics.EventLog(m_sEventLog);
                        //log.Source = m_sEventLog;
                        EventLogEntryType etype = EventLogEntryType.Error;
                        switch (level)
                        {
                            case LogLevels.Errors:
                                etype = EventLogEntryType.Error;
                                break;
                            case LogLevels.Messages:
                                etype = EventLogEntryType.Information;
                                break;
                            case LogLevels.Debug:
                                etype = EventLogEntryType.Information;
                                break;
                        }

                        System.Diagnostics.EventLog.WriteEntry(m_sEventLog, sMessage, etype);
                        //log.WriteEntry(sMessage, etype);
                        //log.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (m_destination == LogDestinations.Console)
                        Console.WriteLine("Log.Write() Error :" + ex.ToString());
                    System.Diagnostics.EventLog elog = new System.Diagnostics.EventLog("Application");
                    elog.Source = "RBU.Log.Write";
                    elog.WriteEntry("Log.Write() Error :" + ex.ToString(), EventLogEntryType.Error);
                    elog.Close();
                    if (writer != null)
                        writer.Close();
                    if (log != null)
                        log.Close();
                }
                catch
                {
                }
            }
            finally
            {
                m_mutex.ReleaseMutex();                  
            }
        }

    }
    
    public delegate void LogWriterDelegate(LogLevels level, string sMessage, params object[] oParams);
    public delegate void LogWriterFormatedDelegate(LogLevels level, string sMessage);

}
