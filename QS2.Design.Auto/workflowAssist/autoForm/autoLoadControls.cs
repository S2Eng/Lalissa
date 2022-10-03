using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using qs2.core.vb;
using qs2.design.auto.workflowAssist.autoForm;



namespace qs2.design.auto.workflowAssist.autoForm
{



    public class autoLoadControls
    {
        
        public bool IsIntitialized = false;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public bool checkRightLicenseChapter(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntriesChapter)
        {
            try
            {
                bool rigthOK = false;
                if (rSelEntriesChapter.Classification.Trim() != "")
                {
                    bool LicenseKeyYesFound = false;
                    System.Collections.Generic.List<string> lstLicenseKeys = qs2.core.generic.readStrVariables(rSelEntriesChapter.Classification.Trim());
                    foreach (string LicensekeyFound in lstLicenseKeys)
                    {
                        string Var = "";
                        string VarValue = "";
                        qs2.core.generic.readVariableAndValue(LicensekeyFound, ref Var, ref VarValue);
                        qs2.core.Enums.cLicense LicenseFoundForSession = qs2.core.license.doLicense.GetLicense(VarValue.Trim());
                        if (LicenseFoundForSession != null)
                        {
                            if (LicenseFoundForSession.bValue == true && !LicenseKeyYesFound)
                            {
                                rigthOK = true;
                                LicenseKeyYesFound = true;
                            }
                        }
                    }
                }
                else
                {
                    rigthOK = true;
                }

                if (!rigthOK)
                {
                    bool bStop = true;
                }
                return rigthOK;
            }
            catch (Exception ex)
            {
                throw new Exception("autoLoadControls.checkRightLicenseChapter: " + ex.ToString());
            }
        }

    }

}
