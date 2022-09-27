using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;



namespace qs2.ui
{


    public class RunFromOtherSystem
    {

        public static bool IsInitialized = false;




        public bool LogIn(string path_config, string configFile, string Application, string Srv, string DB, string Usr, string Pwd, bool IsTrustedConnection, string PathLog)
        {
            try
            {
                if (RunFromOtherSystem.IsInitialized)
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
                    throw new Exception("RunFromOtherSystem.LogIn: Config-File '" + qs2.core.ENV.fileConfig + "' does not exist!");

                qs2.core.ENV.readConfig(qs2.core.ENV.fileConfig, false);
                qs2.core.ENV.path_log = PathLog;
                if (IsTrustedConnection)
                {
                    qs2.core.ENV.connStr = "Data Source=" + Srv.Trim() + "; Initial Catalog=" + DB.Trim() + "; Trusted_Connection=Yes; MultipleActiveResultSets=true;";
                }
                else
                {
                    qs2.core.ENV.connStr = "Data Source=" + Srv.Trim() + "; Initial Catalog=" + DB.Trim() + "; User ID=" + Usr.Trim() + "; Password=" + Pwd.Trim() + "; Trusted_Connection=No; MultipleActiveResultSets=true;";
                    qs2.core.ENV.autoLogInPwdDecrypted = Pwd.Trim();
                    qs2.core.ENV.pwdDbDecrypted = Pwd.Trim();
                }
                qs2.core.ENV.readPathes(false, false, true);

                qs2.core.vb.ui.loadStyleInfrag(true, "Light", "run from other System");
                qs2.core.ENV.readConnInfoDB();
                    
                if (qs2.core.license.doLicense.autoLoadParticipantAndApplication(Application))
                {
                    if (qs2.core.logIn.doConnect2(true, false, false, "", true, true))
                    {
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.initColorSchemas();
                        qs2.core.ENV.alwaysNewConnection = false;
                        qs2.core.ENV.StaysAsExternProcess2 = false;
                        
                        qs2.core.threadStayUI.StayUIIsinitialized = true;
                        qs2.core.vb.sqlObjects sqlObjects1 = new sqlObjects(); 
                        sqlObjects1.initControl();
                        Guid IDGuidObjBack = System.Guid.Empty;
                        int IDObjectBack = -1;

                        sqlObjects sqlObjectsAutoLogIn = new sqlObjects();
                        sqlObjectsAutoLogIn.initControl();
                        dsObjects.tblObjectRow rObjAutoLogIn = sqlObjectsAutoLogIn.getObjectRow(-99, sqlObjects.eTypSelObj.UserName, sqlObjects.eTypObj.IsUser, "", "Supervisor");
                        actUsr.loadActUsr(rObjAutoLogIn.ID, false);
                        qs2.design.auto.ownMCCriteria.initSharedDataSets(false);
                        RunFromOtherSystem.IsInitialized = true;
                        return true;
                    }
                    else
                    {
                        throw new Exception("RunFromOtherSystem.LogIn: LogIn-Error!"); 
                    }
                }
                else
                {
                    throw new Exception("RunFromOtherSystem.LogIn: Error load Participant and Application! (Function autoLoadParticipantAndApplication)"); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RunFromOtherSystem.LogIn: " + ex.ToString());
            }
        }


        public static bool checkLicensexyx()
        {
            if (qs2.core.ENV.NoQS2LicenceNecessary)
            {
                return true;
            }
            else
            {
                string path_configTemp = qs2.core.ENV.path_config;
                string ComputerName = qs2.core.vb.funct.getComputerName();
                if (!qs2.license.core.License.checkLicenseFile(ref path_configTemp, ref qs2.core.ENV.Product, ref ComputerName))
                {
                    ComputerName = "All";
                    if (!qs2.license.core.License.checkLicenseFile(ref path_configTemp, ref qs2.core.ENV.Product, ref ComputerName))
                    {
                        if (MessageBox.Show("Application is not licensed! \r\n" +
                                            "Would you like to start the License-Manager?", "QS2", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "QS2.UnlockApp.exe");
                        }
                        return false;
                    }
                }

                return true;
            }
        }
    }



}
