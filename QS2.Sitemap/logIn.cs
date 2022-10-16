using System;
using System.Windows.Forms;
using System.Threading;

namespace qs2.core
{
    public class logIn
    {

        private static string DbConnStr = "";

        public static bool doConnect2()
        {
            try
            {
                dbBase db = new dbBase();
                if (db.setConnectionDB2(DbConnStr, "Connect"))
                {
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        qs2.core.db.ERSystem.businessFramework.InsertERConnections();      //Vor der ersten benutzung der app.config setzen!!
                    }

                    logIn.LoadAllData(DbConnStr);

                    qs2.core.ENV.SystemIsInitialized = true;
                    QS2.Desktop.Txteditor.Settings.init(qs2.core.ENV.PathTemp, qs2.core.ENV.PathLog, true, qs2.core.ENV.AdminSecure);
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
         
        private static void LoadAllData(string DbConnStr)
        {
            try
            {
                logIn.DbConnStr = DbConnStr;
                qs2.core.dbBase db = new qs2.core.dbBase();
                db.setConnectionDB2(logIn.DbConnStr, "LoadAllData");
                
                qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
                sqlLanguage1.loadAllRessources();
                
                qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                sqlAdmin1.initControl();
                sqlAdmin1.loadAll(false);              

                qs2.core.SysDB.sqlSysDB sqlColumns1 = new qs2.core.SysDB.sqlSysDB();
                sqlColumns1.initControl();               
                sqlColumns1.loadAllSysDatabase();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
