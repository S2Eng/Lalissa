using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data;
using RBU;
using PMDS.Global;
using System.Windows.Forms;

namespace RBU
{

    public class DataBase
    {
        public static OleDbConnection m_conn;            
        private static System.Data.SqlClient.SqlConnection m_connSqlClient;
        private static int m_iOpen = 0;

        public static string m_Database;
        public static string m_sUser;
        public static bool IsTrusted;
        public static string m_sPassword;
        public static string m_sPassword_Encrypted;
        private static string m_sDSN = "";                      
        private static int m_iDSN = 1;                        
        private static int m_iCommandTimeOut = 240;

        public static string Srv = "";
        public static int WaitMSException = 300;
        public static int iTryConnect = 0;

        public static string ConnStr = "";








        static DataBase()
        {
            m_conn = new OleDbConnection();
        }








        public static int COMMANDTIMEOUT
        {
            get
            {
                return m_iCommandTimeOut;
            }
            set
            {
                m_iCommandTimeOut = value;
            }
        }

        public static OleDbConnection CONNECTION
        {
            get
            {
                return m_conn;
            }
            set
            {
                m_conn = value;
            }
        }
        public static System.Data.SqlClient.SqlConnection CONNECTIONSqlClient
        {
            get
            {
                return DataBase.m_connSqlClient;
            }
            set
            {
                DataBase.m_connSqlClient = value;
            }
        }

        public static string DSNMAIN
        {
            get
            {
                return m_sDSN;
            }
            set
            {
                m_sDSN = value;
            }
        }

        public static void SetUserAndPassword(string sUser, string sPassword, string sPassword_Encrypted)
        {
            m_sUser = sUser;
            m_sPassword = sPassword;
            m_sPassword_Encrypted = sPassword_Encrypted;
        }

        public static void Open()
        {
            string sInfoExcept = "";
            string sDSN = "";
            try
            {
                if (m_iOpen > 0)
                {
                    m_iOpen++;
                    return;
                }


                string sValue;
                if (m_iDSN < 2)
                    sValue = "DSNMain";
                else
                    sValue = string.Format("DSNMain{0}", m_iDSN);

                string sUser = "";
                string sPWD = "";

                if (Log.LOG != null && Log.LOG.ConfigFile != null)
                {
                    sDSN = Log.LOG.ConfigFile.GetStringValue(sValue);                    

                    sUser = Log.LOG.ConfigFile.GetStringValue("USER");            
                    sPWD = Log.LOG.ConfigFile.GetStringValue("PWD");                  
                }

                if (sUser.Length > 0)
                    Log.WriteDebug("Using Default User from ConfigFile {0}", sUser);
                if (sPWD.Length > 0)
                    Log.WriteDebug("Using Default Password from ConfigFile {0}", sPWD);

                if (sUser.Length == 0)                                                  
                    sUser = m_sUser;
                if (sPWD.Length == 0)                                                   
                    sPWD = m_sPassword;

                if (m_sDSN.Length > 0)                                            
                    sDSN = m_sDSN;

                sDSN = sDSN.Replace("{{{HIDDENUSER}}}", sUser);                         
                sDSN = sDSN.Replace("{{{HIDDENPASSWORD}}}", sPWD);
                if (m_sPassword_Encrypted != "")
                    sDSN = sDSN.Replace(m_sPassword_Encrypted, sPWD);
             
                m_conn.ConnectionString = sDSN;
                RBU.DataBase.ConnStr = m_conn.ConnectionString;
                sInfoExcept = m_conn.ConnectionString;
                m_conn.Open();
                m_Database = m_conn.Database;

                RBU.DataBase.Srv = m_conn.DataSource;

                System.Data.SqlClient.SqlConnectionStringBuilder SqlConnectionStringBuilder1 = new System.Data.SqlClient.SqlConnectionStringBuilder();
                SqlConnectionStringBuilder1.DataSource = m_conn.DataSource;
                SqlConnectionStringBuilder1.InitialCatalog = m_conn.Database;
                SqlConnectionStringBuilder1.MultipleActiveResultSets = true;
                if (String.IsNullOrWhiteSpace(m_sUser))
                {
                    SqlConnectionStringBuilder1.IntegratedSecurity = true;
                    DataBase.IsTrusted = true;
                }
                else
                {
                    SqlConnectionStringBuilder1.UserID = m_sUser;
                    SqlConnectionStringBuilder1.Password = m_sPassword;
                    SqlConnectionStringBuilder1.IntegratedSecurity = false;
                    SqlConnectionStringBuilder1.PersistSecurityInfo = true;
                }

                DataBase.m_connSqlClient = new System.Data.SqlClient.SqlConnection();
                DataBase.m_connSqlClient.ConnectionString = SqlConnectionStringBuilder1.ConnectionString;
                DataBase.m_connSqlClient.Open();

                Log.WriteDebug("Database successfully opened: {0}", m_conn.ConnectionString);
                m_iOpen++;

                DataBase.iTryConnect = 0;
            }
            catch (Exception ex)
            {
                if (DataBase.iTryConnect <= 5)
                {
                    DataBase.iTryConnect += 1;
                    Exception exTmp = new Exception("RBU.Connect: " + DataBase.iTryConnect.ToString() + "nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "RBU.Connect() ", false);
                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                    DataBase.Open();
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.Connect: 3rd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "RBU.Connect() ", false);
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        DataBase.Open();
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.Connect: 4th try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "RBU.Connect() ", false);
                            qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                            DataBase.Open();
                        }
                        catch (Exception ex3)
                        {
                            throw new Exception("RBU.Connect: " + "\r\n" + ex.ToString() + "\r\n" + "DataBase::Open() Error - DSN:" + sDSN, ex);
                        }
                    }
                }
                else
                {
                    throw new Exception("RBU.Connect: " + "\r\n" + ex.ToString() + "\r\n" + "DataBase::Open() Error - DSN:" + sDSN, ex);
                }
            }
        }

        public static int Fill(OleDbDataAdapter da, System.Data.DataSet ds)
        {
            string sInfoExcept = "";
            try
            {
                SetConnection(da);
                if (da.SelectCommand != null)
                {
                    sInfoExcept = da.SelectCommand.CommandText;
                }
                int i = da.Fill(ds);
                return i;
            }
            catch (System.Data.ConstraintException ex)
            {
                throw new Exception("RBU.Fill (DataSet): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
            }
            catch (System.Data.DataException ex)
            {
                throw new Exception("RBU.Fill (DataSet): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()))
                {
                    Exception exTmp = new Exception("RBU.Fill (DataSet): 2'nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "ExceptionDBNetLibNextCall", false);
                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                    SetConnection(da);
                    int i2 = RBU.DataBase.Fill(da, ds);
                    return i2;
                    /*
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.Fill (DataSet): 3'nd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        SetConnection(da);
                        int i3 = RBU.DataBase.Fill(da, ds);
                        return i3;
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.Fill (DataSet): 4'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "ExceptionDBNetLibNextCall", false);
                            qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                            SetConnection(da);
                            int i4 = RBU.DataBase.Fill(da, ds);
                            return i4;
                        }
                        catch (Exception ex3)
                        {
                            PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                            throw new Exception("RBU.Fill (DataSet): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                    */
                }
                else
                {
                    PMDS.Global.ENV.checkExceptionDBNetLib(ex.ToString());
                    throw new Exception("RBU.Fill (DataSet): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public static int Fill(OleDbDataAdapter da, System.Data.DataTable dt)
        {
            string sInfoExcept = "";
            try
            {
                SetConnection(da);
                if (da.SelectCommand != null)
                {
                    sInfoExcept = da.SelectCommand.CommandText;
                }
                int i = da.Fill(dt);
                return i;
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()) || PMDS.Global.ENV.checkExceptionAbfragetimeout(ex.ToString()))
                {
                    Exception exTmp = new Exception("RBU.Fill (DataTable): 2'nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "ExceptionDBNetLibNextCall", false);
                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                    SetConnection(da);
                    int i2 = RBU.DataBase.Fill(da, dt);
                    return i2;

                    /*
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.Fill (DataTable): 3'nd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        SetConnection(da);
                        int i3 = RBU.DataBase.Fill(da, dt);
                        return i3;
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.Fill (DataTable): 4'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "ExceptionDBNetLibNextCall", false);
                            qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                            SetConnection(da);
                            int i4 = RBU.DataBase.Fill(da, dt);
                            return i4;
                        }
                        catch (Exception ex3)
                        {
                            PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                            throw new Exception("RBU.Fill (DataTable): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                    */
                }
                else
                {
                    PMDS.Global.ENV.checkExceptionDBNetLib(ex.ToString());
                    throw new Exception("RBU.Fill (DataTable): " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public static int Update(OleDbDataAdapter da, System.Data.DataSet ds)
        {
            string sInfoExcept = "";
            try
            {
                SetConnection(da);
                if (da.UpdateCommand != null)
                {
                    da.UpdateCommand.CommandTimeout = RBU.DataBase.m_iCommandTimeOut;
                    sInfoExcept = da.UpdateCommand.CommandText;
                }
                int i = da.Update(ds);
                return i;
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()) || PMDS.Global.ENV.checkExceptionAbfragetimeout(ex.ToString()))
                {
                    Exception exTmp = new Exception("RBU.Update: 2'nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "ExceptionDBNetLibNextCall", false);
                    qs2.core.generic.WaitMilli(1000);
                    SetConnection(da);
                    int i2 = da.Update(ds);
                    return i2;
                    /*
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.Update: 3'nd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        qs2.core.generic.WaitMilli(1000);
                        SetConnection(da);
                        int i3 = da.Update(ds);
                        return i3;
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.Update: 4'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "ExceptionDBNetLibNextCall", false);
                            qs2.core.generic.WaitMilli(1000);
                            SetConnection(da);
                            int i4 = da.Update(ds);
                            return i4;
                        }
                        catch (Exception ex3)
                        {
                            PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                            throw new Exception("RBU.Update: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                    */
                }
                else
                {
                    PMDS.Global.ENV.checkExceptionDBNetLib(ex.ToString());
                    throw new Exception("RBU.Update: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public static int Update(OleDbDataAdapter da, System.Data.DataTable dt)
        {
            string sInfoExcept = "";
            try
            {
                DateTime t = DateTime.Now;
                SetConnection(da);
                if (da.UpdateCommand != null)
                {
                    da.UpdateCommand.CommandTimeout = RBU.DataBase.m_iCommandTimeOut;
                    sInfoExcept = da.UpdateCommand.CommandText;
                }
                int i = da.Update(dt);
                return i;
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()) || PMDS.Global.ENV.checkExceptionAbfragetimeout(ex.ToString()))
                {
                    Exception exTmp = new Exception("RBU.Update: 2'nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "ExceptionDBNetLibNextCall", false);
                    qs2.core.generic.WaitMilli(1000);
                    SetConnection(da);
                    int i2 = da.Update(dt);
                    return i2;
                    /*
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.Update: 3'nd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        qs2.core.generic.WaitMilli(1000);
                        SetConnection(da);
                        int i3 = da.Update(dt);
                        return i3;
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.Update: 4'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "ExceptionDBNetLibNextCall", false);
                            qs2.core.generic.WaitMilli(1000);
                            SetConnection(da);
                            int i4 = da.Update(dt);
                            return i4;
                        }
                        catch (Exception ex3)
                        {
                            PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                            throw new Exception("RBU.Update: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                    */
                }
                else
                {
                    PMDS.Global.ENV.checkExceptionDBNetLib(ex.ToString());
                    throw new Exception("RBU.Update: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }


        public static int EcecuteNonQuery(OleDbCommand cmd)
        {
            string sInfoExcept = "";
            try
            {
                sInfoExcept = cmd.CommandText;
                int i = 0;
                cmd.Connection = m_conn;
                cmd.CommandTimeout = RBU.DataBase.m_iCommandTimeOut;
                i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()) || PMDS.Global.ENV.checkExceptionAbfragetimeout(ex.ToString()))
                {
                    Exception exTmp = new Exception("RBU.EcecuteNonQuery: 2'nd try" + "\r\n" + sInfoExcept + "\r\n");
                    //ENV.HandleException(exTmp, "ExceptionDBNetLibNextCall", false);
                    qs2.core.generic.WaitMilli(1000);
                    int i2 = cmd.ExecuteNonQuery();
                    return i2;
                    /*
                    try
                    {
                        Exception exTmp2 = new Exception("RBU.EcecuteNonQuery: 3'nd try" + "\r\n" + sInfoExcept + "\r\n");
                        //ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        qs2.core.generic.WaitMilli(1000);
                        int i3 = cmd.ExecuteNonQuery();
                        return i3;
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Exception exTmp3 = new Exception("RBU.EcecuteNonQuery: 4'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp3, "ExceptionDBNetLibNextCall", false);
                            qs2.core.generic.WaitMilli(1000);
                            int i4 = cmd.ExecuteNonQuery();
                            return i4;
                        }
                        catch (Exception ex3)
                        {
                            PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                            throw new Exception("RBU.EcecuteNonQuery: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                    */
                }
                else
                {
                    PMDS.Global.ENV.checkExceptionDBNetLib(ex.ToString());
                    throw new Exception("RBU.EcecuteNonQuery: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        private static void SetConnection(OleDbDataAdapter da)
        {
            string sInfoExcept = "";
            try
            {
                if (da.SelectCommand != null)
                {
                    sInfoExcept = da.SelectCommand.CommandText;
                    da.SelectCommand.Connection = m_conn;
                    da.SelectCommand.CommandTimeout = m_iCommandTimeOut;
                }
                if (da.InsertCommand != null)
                {
                    da.InsertCommand.Connection = m_conn; da.InsertCommand.CommandTimeout = m_iCommandTimeOut;
                }
                if (da.UpdateCommand != null)
                {
                    da.UpdateCommand.Connection = m_conn; da.UpdateCommand.CommandTimeout = m_iCommandTimeOut;
                }
                if (da.DeleteCommand != null)
                {
                    da.DeleteCommand.Connection = m_conn; da.DeleteCommand.CommandTimeout = m_iCommandTimeOut;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("RBU.SetConnection: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
            }
        }

   }


}
