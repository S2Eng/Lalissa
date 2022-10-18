using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;

namespace qs2.ui
{
    public class RunFromPMDS

    {
        private static bool IsInitialized;

        public bool LogIn(string configFile, string Srv, string DB, string Usr, string Pwd, bool IsTrustedConnection, string PathLog)
        {
            try
            {
                if (IsInitialized)
                {
                    return true;
                }

                sqlAdmin.dsAllAdmin = new dsAdmin();

                qs2.core.ENV.PathConfig = System.IO.Path.GetDirectoryName(configFile);
                qs2.core.ENV.configFile = System.IO.Path.GetFileName(configFile);

                qs2.core.generic.evdoLog += new qs2.core.generic.doLog(qs2.ui.Logging.Log.doLog);
                if (!System.IO.File.Exists(configFile))
                    throw new Exception("RunFromPMDS.LogIn: Config-File '" + configFile + "' does not exist!");

                qs2.core.ENV.readConfig(configFile, false);
                qs2.core.ENV.PathLog = PathLog;

                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
                {
                    DataSource = Srv,
                    InitialCatalog = DB,
                    MultipleActiveResultSets = true
                };

                if (IsTrustedConnection)
                {
                    sb.IntegratedSecurity = true;
                }
                else
                {
                    sb.IntegratedSecurity = false;
                    sb.UserID = Usr;
                    sb.Password = Pwd;
                    qs2.core.ENV.PwdDbDecrypted = Pwd;
                }

                qs2.core.ENV.connStr = sb.ConnectionString;
                qs2.core.ENV.readPathes(false, false, true);
                qs2.core.ENV.ReadConnInfoDb();
                qs2.core.vb.ui.loadStyleInfrag();
                
                qs2.core.license.doLicense.SetLicensePMDS();
                if (qs2.core.logIn.doConnect2())
                {
                    qs2.core.vb.sqlObjects sqlObjects1 = new sqlObjects();
                    sqlObjects1.initControl();

                    sqlObjects sqlObjectsAutoLogIn = new sqlObjects();
                    sqlObjectsAutoLogIn.initControl();
                    dsObjects.tblObjectRow rObjAutoLogIn = sqlObjectsAutoLogIn.getObjectRow(-99, sqlObjects.eTypSelObj.UserName, sqlObjects.eTypObj.IsUser, "", "Supervisor");
                    actUsr.loadActUsr(rObjAutoLogIn.ID, false);
                    qs2.design.auto.ownMCCriteria.initSharedDataSets();
                    RunFromPMDS.IsInitialized = true;
                    return true;
                }
                else
                {
                    throw new Exception("RunFromPMDS.LogIn: LogIn-Error!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RunFromPMDS.LogIn: " + ex.ToString());
            }
        }
    }
}
