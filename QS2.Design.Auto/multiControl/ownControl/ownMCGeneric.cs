using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTabControl;



namespace qs2.design.auto.multiControl
{



    public class ownMCGeneric
    {

        public static qs2.design.auto.print.translateQuery cLstYesNo = null;
        public static System.Collections.Specialized.ListDictionary lstYesNo = null;






        public static void loadRessourceThreeStateButtons()
        {
            try
            {
                if (ownMCGeneric.cLstYesNo == null)
                {
                    ownMCGeneric.cLstYesNo = new print.translateQuery();
                    ownMCGeneric.lstYesNo = ownMCGeneric.cLstYesNo.getRessourceThreeStateButtons();
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCGeneric.loadRessourceThreeStateButtons", "", false, true, "",
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public static bool getMulticontrol(string FldSHort, string Application,
                                            ref qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                            string Chapter,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControlReturn,
                                            ref System.Collections.Generic.List<UltraTab> lstTabPageReturn, ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn, bool doNotDataBinding = false)
        {
            try
            {
                return qs2.design.auto.workflowAssist.autoForm.autoUI.getMultiControl(FldSHort, Application, ref parentAutoUI.dsAdmin1,
                                                                                        Chapter,
                                                                                        ref lstMultiControlReturn,
                                                                                        ref lstTabPageReturn, ref lstTab, ref lstGroupBoxReturn, doNotDataBinding);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCGeneric.getMulticontrol", FldSHort, false, true,
                                                                Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public static int getTabOrder(ref int origOrderLine, ref int origOrderControl)
        {
            string sNewOrderLine = "";
            if (origOrderLine < 10)
            {
                sNewOrderLine = "10" + origOrderLine.ToString();
            }
            else if (origOrderLine < 100)
            {
                sNewOrderLine = "1" + origOrderLine.ToString();
            }
            else
            {
                throw new Exception("ownMCGeneric.getLineOrder: origOrderLine > 100!");
            }

            string sNewOrderControl = "";
            if (origOrderControl < 10)
            {
                sNewOrderControl = "10" + origOrderControl.ToString();
            }
            else if (origOrderControl < 100)
            {
                sNewOrderControl = "1" + origOrderControl.ToString();
            }
            else
            {
                throw new Exception("ownMCGeneric.getLineOrder: origOrderControl > 100!");
            }

            string sNewOrder = sNewOrderLine + sNewOrderControl;
            int newOrder = System.Convert.ToInt32(sNewOrder, System.Globalization.CultureInfo.InvariantCulture);
            return newOrder;
        }

    }

}
