using Infragistics.Win.UltraWinToolbars;
using qs2.core.vb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace qs2.ui
{


    public class mainApps
    {

        public static qs2.ui.pint.contQryRun contQueriesRun;
        public static qs2.ui.pint.contQryRun contReportsRun;
        public static qs2.ui.pint.contQryRun contDocumentsRun;
        public static qs2.ui.print.contQryAdmin contQryAdminUsr;
        public static qs2.core.vb.contLayoutManager contLayoutGrid;


        public static void CallFunctionMain(qs2.core.ENV.eTypeFunction TypeFunction, qs2.core.ENV.cParsCalMainFunction pars)
        {
            try
            {
                 if (TypeFunction == core.ENV.eTypeFunction.doColorManagment)
                {
                    qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new design.auto.workflowAssist.autoForm.AutoControlsUI();
                    AutoControlsUI1.run2((System.Windows.Forms.Control)pars.UICoontrol, pars.UIComponents);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("contMain.CallFunctionMain:" + ex.ToString());
            }
            finally
            {

            }
        }

    }
}
