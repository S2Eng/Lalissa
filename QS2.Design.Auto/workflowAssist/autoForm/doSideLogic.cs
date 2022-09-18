using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTabControl;



namespace qs2.design.auto.workflowAssist.autoForm
{



    public class doSideLogic
    {

        public qs2.core.vb.sqlAdmin sqlAdminWork = null;
        public qs2.core.vb.dsAdmin dsAdminWork = null;

        public bool isLoaded = false;

        

        public void initControl()
        {
            try
            {
                if (this.isLoaded)
                    return;

                this.dsAdminWork = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork = new qs2.core.vb.sqlAdmin();
                this.sqlAdminWork.initControl();

                this.isLoaded = true;

            }
            catch (Exception ex)
            {
                throw new Exception("doSideLogic.doSideLogic: " + ex.ToString());
            }
        }

        public void runxy(qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck,
                        int IDSelListCkicked, object oValueParent, string Application, string Participant,
                        ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                        qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI)
        {
            try
            {
                this.dsAdminWork.Clear();
                qs2.core.vb.dsAdmin.tblSideLogicRow[] arrSideLogic = (qs2.core.vb.dsAdmin.tblSideLogicRow[])this.sqlAdminWork.getSideLogic( qs2.core.vb.sqlAdmin.dsAllAdmin, core.vb.sqlAdmin.eTypeSideLogic.IDSelList, IDSelListCkicked, "", "");
                foreach (qs2.core.vb.dsAdmin.tblSideLogicRow rSideLogicFound in arrSideLogic)
                {
                    if (rSideLogicFound.Action.Trim().ToLower().Equals(("Relationship").Trim().ToLower()))
                    {
                        if (rSideLogicFound.FldShort.Trim() != "" && rSideLogicFound.IDApplication.Trim() != "")
                        {
                            ownMCRelationship MCRelationship = new ownMCRelationship();
                            MCRelationship.initControl(Application);
                            MCRelationship.getRelationsship(rSideLogicFound.FldShort, Application);

                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl = new List<multiControl.ownMultiControl>();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                            System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstOwnGroupBox = new List<multiControl.ownGroupBox>();
                            qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rSideLogicFound.FldShort, rSideLogicFound.IDApplication.Trim(),
                                                                                ref parentAutoUI, rSideLogicFound.Chapter.Trim(),
                                                                                ref lstOwnMultiControl, ref lstTabePageReturn, ref lstTab, ref lstOwnGroupBox);  // OMC.IDApplication.Check

                            qs2.core.generic.retValue cValueParent = new qs2.core.generic.retValue();      //this.ownMCDataBind1.getValueFromRow(ownMultiControl1);
                            if (oValueParent.GetType().Name.Trim().ToLower().Equals(("Boolean").Trim().ToLower()))
                            {
                                bool bValueTmp = System.Convert.ToBoolean(oValueParent);
                                cValueParent.valueObj = bValueTmp;
                                if (bValueTmp)
                                {
                                    cValueParent.valueStr = "1";
                                }
                                else
                                {
                                    cValueParent.valueStr = "0";
                                }
                                //cValueParent.valueSql = chr(34) + cValueParent.valueStr + chr(34)
                            }
                            else  //else if (oValueParent.GetType().Name.Trim().ToLower().Equals(("string").Trim().ToLower()))
                            {
                                cValueParent.valueObj = System.Convert.ToString(oValueParent);
                                cValueParent.valueStr = System.Convert.ToString(oValueParent);
                            }

                            foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControlFound in lstOwnMultiControl)
                            {
                                int SubRelation = 0;
                                MCRelationship.doRelationship(rSideLogicFound.FldShort, rSideLogicFound.Chapter, ref cValueParent, true, SubRelation,
                                                                                    Application, Participant,
                                                                                    ref dataStay,
                                                                                    ref parentAutoUI, ref TypAssignmentToCheck, false);
                            }
                        }
                        else
                        {
                            throw new Exception("doSideLogic.run: rSideLogicFound.FldShort.Trim() == '' or rSideLogicFound.IDApplication.Trim() == '' for IDSelListEntry='" + IDSelListCkicked .ToString () +  "'!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doSideLogic.doSideLogic: " + ex.ToString());
            }
        }

    }
}
