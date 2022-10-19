using System;
using System.Windows.Forms;
using System.Threading;

namespace qs2.core
{
    public class logIn
    {
        public static bool doConnect2()
        {
            try
            {
                dbBase db = new dbBase();
                if (db.setConnectionDB2())
                {
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        qs2.core.db.ERSystem.businessFramework.WriteERConnectionStringSqlDb();      //Vor der ersten benutzung der app.config setzen!!
                    }

                    qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
                    sqlLanguage1.loadAllRessources();

                    qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                    sqlAdmin1.initControl();
                    sqlAdmin1.loadAll(false);

                    qs2.core.SysDB.sqlSysDB sqlColumns1 = new qs2.core.SysDB.sqlSysDB();
                    sqlColumns1.initControl();
                    sqlColumns1.loadAllSysDatabase();

                    qs2.core.ENV.SystemIsInitialized = true;
                    QS2.Desktop.Txteditor.Settings.init(qs2.core.ENV.PathTemp, qs2.core.ENV.PathLog, true, qs2.core.ENV.AdminSecure);
                    return true;
                }

                qs2.core.generic.showMessageBox("Could not connect to Database!", MessageBoxButtons.OK, "");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("logIn.doConnect:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
    }
}
