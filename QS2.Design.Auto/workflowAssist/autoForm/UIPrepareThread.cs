using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;



namespace qs2.design.auto.workflowAssist.autoForm
{

    public class UIPrepareThread
    {
                    
        public static Dictionary<string, CriteriaThread> dicProducts = new Dictionary<string, CriteriaThread>();

        public class CriteriaThread
        {
            public ownMCCriteria crit = null;
            public qs2.design.auto.multiControl.ownMCUI ownMCUi = null;
            public string txtTranslated = "";
            public string txtTranslatedLabelRight = "";

        }






        public void startThread()
        {
            try
            {
                //ThreadStart job = new ThreadStart(this.run);
                //Thread thread = new Thread(job);
                //thread.ApartmentState = ApartmentState.STA;

                //thread.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("UIPrepareThread.startThread: " + ex.ToString());
            }
        }
        public void run()
        {
            try
            {
                foreach (qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria in qs2.core.vb.sqlAdmin.dsAllAdmin.tblCriteria)
                {
                    CriteriaThread newCriteria = new CriteriaThread();
                    newCriteria.crit = new ownMCCriteria();
                    newCriteria.ownMCUi = new multiControl.ownMCUI();
                    //string protocollForAdmin = "";
                    //bool ProtocolWindow = false;
                    //bool OwnFieldForALLProducts = false;
                    //if (rCriteria.IDApplication.Trim().ToLower().Equals(("all")))
                    //{
                    //    OwnFieldForALLProducts = true;
                    //}
                    qs2.core.Enums.eControlType controlType = qs2.core.generic.searchEnumControlType(rCriteria.ControlType.Trim());
                    //newCriteria.crit.getData(null, rCriteria.FldShort.Trim(), controlType,
                    //                    null, ref newCriteria.ownMCUi, null,
                    //                    ref protocollForAdmin, ref ProtocolWindow, OwnFieldForALLProducts, false, false);

                    //newCriteria.txtTranslated = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort.Trim());

                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    newCriteria.txtTranslated = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort.Trim(), core.Enums.eResourceType.Label,
                                                                 qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), 
                                                                 rCriteria.IDApplication, ref rLangFoundReturn, true, true, 
                                                                 core.language.sqlLanguage.eLanguage.NoText, false).Trim() + " ";
                    if (newCriteria.txtTranslated.Trim() == "")
                    {
                        newCriteria.txtTranslated = rCriteria.FldShort.Trim();
                    }

                    newCriteria.txtTranslatedLabelRight = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort.Trim(),
                                                core.Enums.eResourceType.LabelRight,
                                                qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(),
                                                rCriteria.IDApplication, ref rLangFoundReturn,
                                                true, true, core.language.sqlLanguage.eLanguage.NoText, false).Trim();

                    UIPrepareThread.dicProducts.Add(rCriteria.FldShort.Trim(), newCriteria);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UIPrepareThread.run: " + ex.ToString());
            }
        }

    }
}
