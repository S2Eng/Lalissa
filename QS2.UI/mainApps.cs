using Infragistics.Win.UltraWinToolbars;
using qs2.core.vb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static qs2.ui.contMain;

namespace qs2.ui
{


    public class mainApps
    {

        public static qs2.ui.pint.contQryRun contQueriesRun;
        public static qs2.ui.pint.contQryRun contReportsRun;
        public static qs2.ui.pint.contQryRun contDocumentsRun;
        public static qs2.ui.print.contQryAdmin contQryAdminUsr;
        public static qs2.core.vb.contLayoutManager contLayoutGrid;

        public static contMain mainUI = null;

        public static void CallFunctionMain(qs2.core.ENV.eTypeFunction TypeFunction, qs2.core.ENV.cParsCalMainFunction pars)
        {
            try
            {
                if (TypeFunction == core.ENV.eTypeFunction.loadManageQueryuser)
                {
                    mainApps.mainUI.doControl(qs2.core.ENV.eTypApp.contQuerysUser, "", "", "");
                    mainApps.mainUI.mainWindow.LockToolbar = true;
                    mainApps.mainUI.mainWindow.LockToolbar = false;
                }
                else if (TypeFunction == core.ENV.eTypeFunction.doColorManagment)
                {
                    qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new design.auto.workflowAssist.autoForm.AutoControlsUI();
                    AutoControlsUI1.run2((System.Windows.Forms.Control)pars.UICoontrol, pars.UIComponents);
                }
            }
            catch (Exception ex)
            {
                if (mainApps.mainUI != null)
                {
                    mainApps.mainUI.mainWindow.LockToolbar = false;
                }
                throw new Exception("contMain.CallFunctionMain:" + ex.ToString());
            }
            finally
            {
                if (mainApps.mainUI != null)
                {
                    mainApps.mainUI.mainWindow.LockToolbar = false;
                }
            }
        }

    }
}
