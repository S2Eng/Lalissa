using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;
using System.Threading;
using qs2.core.db.ERSystem;

namespace qs2.core
{


    public class logIn
    {
        public static bool DataThreadIsReady = false;
        public static string DbConnStrStayUI = "";

        public static bool doConnect2(bool loadAllRessources, bool DesignerMode, bool CheckVersionDB, string DbConnStrStayUI, bool IsPMDS, bool doNotDecryptPwd = false)
        {
            try
            {
                qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
                QS2.functions.vb.Encryption Encryption1 = new QS2.functions.vb.Encryption();
                if (!qs2.core.ENV.TrustedConnection)
                {
                    if (!doNotDecryptPwd)
                    {
                        ENV.pwdDbDecrypted = Encryption1.StringDecrypt(qs2.core.ENV.pwdDbEncrypted, QS2.functions.vb.Encryption.keyForEncryptingStrings);
                        ENV.connStr = ENV.connStr.Replace(qs2.core.ENV.pwdDbEncrypted, ENV.pwdDbDecrypted);
                    }
                }

                dbBase db = new dbBase();
                if (db.setConnectionDB2(DesignerMode, DbConnStrStayUI, "Connect"))
                {
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        qs2.core.db.ERSystem.businessFramework.InsertERConnections();      //Vor der ersten benutzung der app.config setzen!!
                    }
            
                    qs2.core.db.ERSystem.businessFramework b = new db.ERSystem.businessFramework();
                    string DBVersionFromDatabase = "";
                    string ReferenzExeVersion = "";
                    bool bDBVersionOk = false;

                    if (CheckVersionDB && System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        bDBVersionOk = b.checkDBVersion(ENV.AssemblyVersion, ref DBVersionFromDatabase);        //Exe-Version muss größer oder gleich DB-Version sein
                        ENV.DBVersionFromDatabase = DBVersionFromDatabase;

                        if (!bDBVersionOk)
                        {
                            qs2.core.generic.showMessageBox("Incompatible version with database: \r\n" +
                                                            "Minimal expected version: " + ENV.AssemblyVersion + "\r\n" +
                                                            "Your version: " + ENV.DBVersionFromDatabase, MessageBoxButtons.OK, "");
                            return false;
                        }

                        if (!String.IsNullOrWhiteSpace(ENV.MinDBVersion))                                       //DB-Version muss größer oder gleich der Minimalen DB-Version sein (wenn angegeben)
                        {
                            qs2.core.db.ERSystem.businessFramework frw = new db.ERSystem.businessFramework();
                            if (!frw.CompareVersionStrings(DBVersionFromDatabase, ENV.MinDBVersion))
                            {
                                qs2.core.generic.showMessageBox("Incompatible version with minimal database version: \r\n" +
                                                                "Minimal expected version: " + ENV.MinDBVersion + "\r\n" +
                                                                "Your version: " + ENV.DBVersionFromDatabase, MessageBoxButtons.OK, "");
                                return false;
                            }
                        }

                        if (!b.checkReferenzVersion(ENV.AssemblyVersion, ENV.ReferenceVersion, ref ReferenzExeVersion))
                            {
                                qs2.core.generic.showMessageBox("Incompatible version with reference version: \r\n" +
                                                                "Minimal expected version: " + ReferenzExeVersion + "\r\n" +
                                                                "Your version: " + ENV.DBVersionFromDatabase, MessageBoxButtons.OK, "");
                                return false;
                            }
                    }

                    if (loadAllRessources)
                    {
                        qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                        sqlAdmin1.initControl();
                        sqlAdmin1.getAllUsersWithRoles(ref sqlAdmin.dsAllAdmin, sqlAdmin.eTypAuswahlList.all);

                        qs2.core.vb.businessFramework b2 = new qs2.core.vb.businessFramework();
                        string loadENVFromAdjustmentStayType = "";
                        b2.loadENVFromAdjustmentStayType(ref loadENVFromAdjustmentStayType);
                       
                        if (!IsPMDS)
                        {
                            logIn.startThreadLoadAllData(DbConnStrStayUI);
                        }
                        else
                        {
                            logIn.startThreadLoadAllData(DbConnStrStayUI);
                        }
                    }

                    qs2.core.ENV.SystemIsInitialized = true;

                    QS2.Desktop.Txteditor.Settings.init(qs2.core.ENV.path_temp, qs2.core.ENV.path_log, true, qs2.core .ENV.adminSecure);
                    qs2.core.dbBase.checkConnectedOnDesignerDB();

                    return true;
                }
                else
                {
                    qs2.core.generic.showMessageBox("Could not connect to Database!", MessageBoxButtons.OK, "");
                    return false;
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("logIn.doConnect:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
         
        public static void startThreadLoadAllData(string DbConnStrStayUI)
        {
            logIn.DbConnStrStayUI = DbConnStrStayUI;
            ThreadStart job = new ThreadStart(logIn.ThreadLoadAllData);
            Thread thread = new Thread(job);
            thread.SetApartmentState (ApartmentState.STA);
            thread.Start();
        }

        public static void ThreadLoadAllData()
        {
            try
            {

                qs2.core.dbBase._IDThreadDBOperations = System.Threading.Thread.CurrentThread.ManagedThreadId;
                qs2.core.dbBase db = new qs2.core.dbBase();
                db.setConnectionDB2(false, logIn.DbConnStrStayUI, "ThreadLoadAllData");
                
                qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
                sqlLanguage1.loadAllRessources();
                
                qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                sqlAdmin1.initControl();
                sqlAdmin1.loadAll(false);              

                qs2.core.SysDB.sqlSysDB sqlColumns1 = new qs2.core.SysDB.sqlSysDB();
                sqlColumns1.initControl();               
                sqlColumns1.loadAllSysDatabase();
               
                logIn.DataThreadIsReady = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
