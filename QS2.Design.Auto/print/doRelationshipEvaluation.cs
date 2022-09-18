using qs2.design.auto.multiControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qs2.design.auto.print
{
        

    public class doRelationshipEvaluation
    {

        public qs2.core.vb.dsAdmin dsAdminTmp = null;
        public qs2.core.vb.sqlAdmin sqlAdminTmp = null;
        public static qs2.ui.print.contQryRunPar contQryRunPar = null;

        public class MCControlsFound
        {
            public qs2.design.auto.multiControl.ownMultiControl ownMultiControl = null;

        }






        public void run(string ColumnName, ref qs2.design.auto.multiControl.ownMultiControl ownControlParent, qs2.design.auto.multiControl.ownMultiControl ownControlChild, qs2.core.vb.dsAdmin.tblQueriesDefRow rQry)
        {
            try
            {
                qs2.ui.drawMulticontrol drawMulticontrol1 = new qs2.ui.drawMulticontrol();

                if (this.dsAdminTmp == null)
                {
                    this.dsAdminTmp = new core.vb.dsAdmin();
                }
                if (this.sqlAdminTmp == null)
                {
                    this.sqlAdminTmp = new core.vb.sqlAdmin();
                    sqlAdminTmp.initControl();
                }
                this.dsAdminTmp.Clear();
                string IDApplicationParent = "";
                qs2.core.vb.dsAdmin.tblCriteriaRow rCriteriaParent = this.getCriteria(ColumnName.Trim(), ref IDApplicationParent);
                if (rCriteriaParent == null)
                {
                    return;
                }
                qs2.core.vb.dsAdmin.tblRelationshipRow[] arrRelationships = this.sqlAdminTmp.getRelationsship(ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelRelationship.idRam, ColumnName.Trim(), IDApplicationParent.Trim(), "");
                if (arrRelationships.Length == 0)
                {
                    return;
                }

                System.Collections.Generic.List<MCControlsFound> lstMCControlsChild = new List<MCControlsFound>();
                if (ownControlChild == null)
                {
                    if (doRelationshipEvaluation.contQryRunPar != null)
                    {
                        this.searchMultiControls(ColumnName, ref ownControlParent, ref lstMCControlsChild);
                    }
                }
                else
                {
                    MCControlsFound NewMCControlsFound = new MCControlsFound();
                    NewMCControlsFound.ownMultiControl = ownControlChild;
                    lstMCControlsChild.Add(NewMCControlsFound);
                }


                //bool ConditionFound = false;
                foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelation in arrRelationships)
                {
                    if (!rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroups.ToString().Trim().ToLower()) &&
                            (rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.Visible.ToString().Trim().ToLower()) ||
                            rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.Invisible.ToString().Trim().ToLower())))
                    {
                        if (!rRelation.IsFldShortChildNull())
                        {
                            if (rRelation.TypeSub.Trim() == qs2.core.Enums.eConditionTyp.SelList.ToString() && rRelation.Conditions != "")
                            {
                                bool ClearComboChilds = false;
                                qs2.core.generic.retValue retValueParent = new core.generic.retValue();
                                if (ownControlParent.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                                {
                                    qs2.core.generic.retValue retValueDropDown = new core.generic.retValue();
                                    retValueDropDown = ownControlParent.ownMCValue1.getValue(ownControlParent, false);
                                    System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(retValueDropDown.valueStr.Trim());
                                    if (lstCondition.Count == 1)
                                    {
                                        string condition = lstCondition[0];
                                        retValueParent.valueStr = condition.Trim();
                                    }
                                    else
                                    {
                                        ClearComboChilds = true;
                                    }
                                }
                                else
                                {
                                    retValueParent = ownControlParent.ownMCValue1.getValue(ownControlParent, false);
                                }
                                if (retValueParent.valueStr.Trim() == "")
                                {
                                    ClearComboChilds = true;
                                }

                                foreach (MCControlsFound MCControlsFound in lstMCControlsChild)
                                {
                                    if (MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria != null && 
                                        MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria.FldShort.Trim().ToLower().Equals(rRelation.FldShortChild.Trim().ToLower()) &&
                                        MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria.IDApplication.Trim().ToLower().Equals(rRelation.IDApplicationChild.Trim().ToLower()))
                                    {
                                        if (ClearComboChilds)
                                        {
                                            ownMCEvents.lockValueChanged = true;
                                            MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1.clearCombo(MCControlsFound.ownMultiControl);
                                            ownMCEvents.lockValueChanged = false;
                                        }
                                    }
                                }

                                foreach (MCControlsFound MCControlsFound in lstMCControlsChild)
                                {
                                    if (retValueParent.valueStr.Trim() != "")
                                    {
                                        if (MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria != null && 
                                            MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria.FldShort.Trim().ToLower().Equals(rRelation.FldShortChild.Trim().ToLower()) &&
                                            MCControlsFound.ownMultiControl.ownMCCriteria1.rCriteria.IDApplication.Trim().ToLower().Equals(rRelation.IDApplicationChild.Trim().ToLower()))
                                        {
                                            //qs2.core.generic.retValue retValueChild = new qs2.core.generic.retValue();
                                            //retValueChild = MCControlsFound.ownMultiControl.ownMCValue1.getValue(MCControlsFound.ownMultiControl, false);
                                            ////if (retValueChild.valueObj != null)
                                            ////{
                                            System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                                            foreach (string condition in lstCondition)
                                            {
                                                if (retValueParent.valueStr.Trim() != "" && condition == retValueParent.valueStr)
                                                {
                                                    ownMCEvents.lockValueChanged = true;
                                                    MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1.loadCombo(MCControlsFound.ownMultiControl, rRelation.IDKey.Trim(),
                                                                                                                        MCControlsFound.ownMultiControl.ownMCCriteria1.CombinationComboBoxAsDropDown,
                                                                                                                        MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1._ComboBoxCheckThreeStateBoxAsDropDown);
                                                    MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1.IsVariableSelListFromRelationForCombObox = true;
                                                    MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1.IDGroupStrForComboBox = rRelation.IDKey.Trim();
                                                    //ConditionFound = true;
                                                    ownMCEvents.lockValueChanged = false;

                                                    if (rQry != null)
                                                    {
                                                        string ValueTxtTmp = rQry.ValueMin;
                                                        drawMulticontrol1.checkForSpecialDefinitionsMinValue(ref rQry, ref ValueTxtTmp, true);
                                                        if (ValueTxtTmp.Trim() != "" && !MCControlsFound.ownMultiControl.ownMCCriteria1.ownMCCombo1.SelectionComboBoxCanNotCleared)
                                                        {
                                                            MCControlsFound.ownMultiControl.ownMCValue1.setValue(MCControlsFound.ownMultiControl, ValueTxtTmp);
                                                        }
                                                    }
                                                    //}
                                                }
                                            //if (retValueParent.valueStr.Trim() != "" && !ConditionFound)
                                            //{
                                            //    string xy = "";
                                            //}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ownMCEvents.lockValueChanged = false;
                throw new Exception("doRelationshipEvaluation.run: " + ex.ToString());
            }
            finally
            {
                ownMCEvents.lockValueChanged = false;
            }
        }
        public void searchMultiControls(string ColumnName, ref qs2.design.auto.multiControl.ownMultiControl ownControlParent,
                                        ref System.Collections.Generic.List<MCControlsFound> lstMCControlsChild)
        {
            try
            {
                foreach (Control ContChild in doRelationshipEvaluation.contQryRunPar.panelParameters.Controls)
                {
                    if (ContChild.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMCChild = (qs2.design.auto.multiControl.ownMultiControl)ContChild;
                        if (ownMCChild.Visible)
                        {
                            if (!ownMCChild.isParameterHeader)
                            {
                                if (ownMCChild.OwnControlType == core.Enums.eControlType.ComboBox ||
                                    ownMCChild.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                                {
                                    string IDApplicationChild = "";
                                    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteriaChild = this.getCriteria(ownMCChild.OwnFldShort.Trim(), ref IDApplicationChild);
                                    if (rCriteriaChild == null)
                                    {
                                        return;
                                    }
                                    ownMCChild.ownMCCriteria1.rCriteria = rCriteriaChild;

                                    MCControlsFound NewMCControlsFound = new MCControlsFound();
                                    NewMCControlsFound.ownMultiControl = ownMCChild;
                                    lstMCControlsChild.Add(NewMCControlsFound);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doRelationshipEvaluation.searchMultiControls: " + ex.ToString());
            }
        }

        public qs2.core.vb.dsAdmin.tblCriteriaRow getCriteria(string ColumnName, ref string IDApplicationParent)
        {
            try
            {
                IDApplicationParent = qs2.core.license.doLicense.rApplication.IDApplication.Trim();
                qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteria = null;
                arrCriteria = ownMCCriteria.sqlAdminWork.getCriterias(qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, ColumnName.Trim(), IDApplicationParent.Trim(),
                                                                false, false, false, "", "", false);
                if (arrCriteria.Length == 0)
                {
                    IDApplicationParent = core.license.doLicense.eApp.ALL.ToString();
                    arrCriteria = ownMCCriteria.sqlAdminWork.getCriterias(qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, ColumnName.Trim(), IDApplicationParent.Trim(),
                                                                false, false, false, "", "", false);
                }

                if (arrCriteria.Length == 0)
                {
                    return null;
                }
                if (arrCriteria.Length > 1)
                {
                    throw new Exception("getCriteria: arrCriteria.Length > 1 not allowed for ColumnName '" + ColumnName.Trim() + "'!");
                }

                return arrCriteria[0];

            }
            catch (Exception ex)
            {
                throw new Exception("doRelationshipEvaluation.getCriteria: " + ex.ToString());
            }
        }


    }
}
