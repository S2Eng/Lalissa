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
        public static bool IsInitialized = false;

        public bool LogIn(string path_config, string configFile, string Application, string Srv, string DB, string Usr, string Pwd, bool IsTrustedConnection, string PathLog)
        {
            try
            {
                if (RunFromPMDS.IsInitialized)
                {
                    return true;
                }

                sqlAdmin.dsAllAdmin = new dsAdmin();
                qs2.core.ENV.alwaysNewConnection = false;
                qs2.core.ENV.StaysAsExternProcess2 = false;

                qs2.core.ENV.path_config = path_config;
                qs2.core.ENV.configFile = configFile;

                qs2.core.generic.evdoLog += new qs2.core.generic.doLog(qs2.ui.Logging.Log.doLog);
                qs2.core.ENV.fileConfig = System.IO.Path.Combine(qs2.core.ENV.path_config, qs2.core.ENV.configFile);
                if (!System.IO.File.Exists(qs2.core.ENV.fileConfig))
                    throw new Exception("RunFromPMDS.LogIn: Config-File '" + qs2.core.ENV.fileConfig + "' does not exist!");

                qs2.core.ENV.readConfig(qs2.core.ENV.fileConfig, false);
                qs2.core.ENV.path_log = PathLog;

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
                    qs2.core.ENV.autoLogInPwdDecrypted = Pwd;
                    qs2.core.ENV.pwdDbDecrypted = Pwd;
                }

                qs2.core.ENV.connStr = sb.ConnectionString;
                qs2.core.ENV.readPathes(false, false, true);

                qs2.core.vb.ui.loadStyleInfrag(true, "Light", "Run from PMDS");
                qs2.core.ENV.ReadConnInfoDb();

                if (qs2.core.license.doLicense.AutoLoadParticipantAndApplication())
                {
                    if (qs2.core.logIn.doConnect2(true, false, false, "", true, true))
                    {
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.initColorSchemas();
                        qs2.core.ENV.alwaysNewConnection = false;
                        qs2.core.ENV.StaysAsExternProcess2 = false;
                        qs2.core.vb.sqlObjects sqlObjects1 = new sqlObjects();
                        sqlObjects1.initControl();
                        Guid IDGuidObjBack = System.Guid.Empty;

                        sqlObjects sqlObjectsAutoLogIn = new sqlObjects();
                        sqlObjectsAutoLogIn.initControl();
                        dsObjects.tblObjectRow rObjAutoLogIn = sqlObjectsAutoLogIn.getObjectRow(-99, sqlObjects.eTypSelObj.UserName, sqlObjects.eTypObj.IsUser, "", "Supervisor");
                        actUsr.loadActUsr(rObjAutoLogIn.ID, false);
                        qs2.design.auto.ownMCCriteria.initSharedDataSets(false);
                        RunFromPMDS.IsInitialized = true;
                        return true;
                    }
                    else
                    {
                        throw new Exception("RunFromPMDS.LogIn: LogIn-Error!");
                    }
                }
                else
                {
                    throw new Exception("RunFromPMDS.LogIn: Error load Participant and Application! (Function AutoLoadParticipantAndApplication)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RunFromPMDS.LogIn: " + ex.ToString());
            }
        }
    }
}
