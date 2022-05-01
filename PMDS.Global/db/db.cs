using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;




namespace PMDS.Data.Global
{


    public class db

    {

        public static Guid IDGuidCheckConn = System.Guid.NewGuid();
        public static int iCounterExceptNetwork = 0;
        public static int iInfoMemoryToHighShown = 0;
        public static int iInfoMemoryToHighIntervallClick = -1;








        public static void checkConnectionAndNetworkTimerxyxyxy()
        {
            string IPAdress = "";
            DateTime dNow = DateTime.Now;
            try
            {
                System.Net.IPAddress[] localIPs = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
                if (localIPs.Length > 1)
                {
                    IPAdress = localIPs[1].ToString();
                }
                //string txtLogCheck = dNow.ToString() + " - Check Networkconnection for MachineName " + System.Environment.MachineName.Trim() + " - IPAdress:" + IPAdress + "";
                //db.writeLog(txtLogCheck);

                if (RBU.DataBase.CONNECTION.State != System.Data.ConnectionState.Open)
                {
                    string txtLog = dNow.ToString() + " checkConnectionAndNetworkTimer: Error - RBU.DataBase.CONNECTION.State is not Open(State=" + RBU.DataBase.CONNECTION.State.ToString() + ")";
                    db.writeLogxy(txtLog);
                }

                db.checkMemorySizeAppClientxyxy(IPAdress);

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                System.Data.DataTable dt = new System.Data.DataTable();
                da.SelectCommand = cmd;
                OleDbConnection conn = new OleDbConnection(RBU.DataBase.CONNECTION.ConnectionString);
                da.SelectCommand.Connection = conn;
                cmd.CommandText = "SELECT Top 1 Bezeichnung from Recht";

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    System.Data.DataRow r = dt.Rows[0];
                    if (r[0] != null)
                    {
                        string retValue = r[0].ToString().Trim();
                    }
                }

            }
            catch (OleDbException e)
            {
                string errorMessages = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    errorMessages += "Index #" + i + "\n" +
                                     "Message: " + e.Errors[i].Message + "\n" +
                                     "NativeError: " + e.Errors[i].NativeError + "\n" +
                                     "Source: " + e.Errors[i].Source + "\n" +
                                     "SQLState: " + e.Errors[i].SQLState + "\n";
                }

                string txtLog = dNow.ToString() + " - OleDbException " + db.iCounterExceptNetwork.ToString() + ": " + System.Environment.MachineName.Trim() + ", IPAdress:" + IPAdress + " - checkConnectionAndNetwork: OLEDB-Error - OleDB-Test-Select Error" + "\r\n" + "\r\n" + errorMessages + "\r\n" + "\r\n" + e.ToString();
                db.writeLogxy(txtLog);

                db.iCounterExceptNetwork += 1;
                if (db.iCounterExceptNetwork <= 1)
                {
                    qs2.core.generic.WaitMilli(200);
                    db.checkConnectionAndNetworkTimerxyxyxy();
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("db.checkConnectionAndNetwork: " + ex.ToString());
                string txtLog = dNow.ToString() + " - Exception " + iCounterExceptNetwork.ToString() + ": " + System.Environment.MachineName.Trim() + ", IPAdress:" + IPAdress +  " - checkConnectionAndNetwork: Error - OleDB-Test-Select Error" + "\r\n" + "\r\n" + ex.ToString();
                db.writeLogxy(txtLog);

                //db.iCounterExceptNetwork += 1;
                //if (db.iCounterExceptNetwork <= 1)
                //{
                //    qs2.core.generic.WaitMilli(200);
                //    db.checkConnectionAndNetwork();
                //}
            }
        }

        public static void checkMemorySizeAppClientxyxy(string IPAdress)
        {
            try
            {
                //int MaxSizeMemory = 7000;
                //System.Diagnostics.Process loProcess = System.Diagnostics.Process.GetCurrentProcess();
                //long lnValue = loProcess.WorkingSet;
                //long MemorySize = loProcess.WorkingSet;
                //System.Windows.Forms.MessageBox.Show("MemorySize: " + MemorySize.ToString());

                int MaxSizeMemory1 = 800000;
                int MaxSizeMemory2 = 1000000;
                int MaxSizeMemory3 = 1150000;
                //long memoryUsedByApp = GC.GetTotalMemory(true);

                System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
                int memoryUsedByApp = 0;            // memsize in Megabyte
                PerformanceCounter PC = new PerformanceCounter();
                PC.CategoryName = "Process";
                PC.CounterName = "Working Set - Private";
                PC.InstanceName = proc.ProcessName;
                memoryUsedByApp = Convert.ToInt32(PC.NextValue()) / (int)(1024);
                PC.Close();
                PC.Dispose();

                if (memoryUsedByApp > MaxSizeMemory1)
                {
                    string RamUsedMB = (memoryUsedByApp / 1000).ToString();
                    string txtLog = DateTime.Now.ToString() + " - Ram consumption exceeded - Memory used by App: " + RamUsedMB + " MB - " + System.Environment.MachineName.Trim() + ", IPAdress:" + IPAdress + " - checkConnectionAndNetwork: Error - OleDB-Test-Select Error" + "\r\n";
                    db.writeLogxy(txtLog);
                    //GC.Collect();

                    //GC.WaitForPendingFinalizers();
                    //if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    //{
                    //    //SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
                    //}
                }

            }
            catch (Exception ex)
            {
                string txtLog = DateTime.Now.ToString() + " Warning - Get memory not running on machine: " + System.Environment.MachineName.Trim() + ", IPAdress:" + IPAdress + "" + "\r\n";
                db.writeLogxy(txtLog);
            }
        }

        public static void writeLogxy(string txt)
        {
            try
            {
                if (!System.IO.Directory.Exists(PMDS.Global.ENV.LOGPATH))
                {
                    System.IO.Directory.CreateDirectory(PMDS.Global.ENV.LOGPATH);
                }

                string logFile = PMDS.Global.ENV.LOGPATH + "\\CheckDatabaseNetwork_" + System.Environment.MachineName + db.IDGuidCheckConn.ToString() + ".log";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
                {
                    file.WriteLine(txt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("db.writeLog: " + ex.ToString());
            }
        }

        public static void initRow(System.Data.DataRow r, System.Guid id, bool doID)
        {
            foreach (System.Data.DataColumn col in r.Table.Columns)
            {
                if (col.ColumnName.Equals("ID"))
                {
                    r["ID"] = id;
                }
                else
                {
                    PMDS.Data.Global.db.initColumnManuell(r, col);
                }
            }
        }


        public static void initColumnManuell(System.Data.DataRow r, System.Data.DataColumn col)
        {
            if (col.DataType.FullName.ToString().Equals(typeof(System.Boolean).FullName))
            {
                r[col.ColumnName] = false;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.String).FullName))
            {
                r[col.ColumnName] = "";
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.Double).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Decimal).FullName))
            {
                r[col.ColumnName] = 0;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.Int32).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Int16).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Int64).FullName))
            {
                r[col.ColumnName] = 0;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.DateTime).FullName))
            {
                try
                {
                    r[col.ColumnName] = System.DBNull.Value;
                }
                catch 
                {
                    r[col.ColumnName] = System.DateTime.Now;
                }
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.Guid).FullName))
            {
                try
                {
                    r[col.ColumnName] = System.DBNull.Value;
                }
                catch
                {
                    r[col.ColumnName] = System.Guid.Empty;
                }
            }

        }
    }
}
