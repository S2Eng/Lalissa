using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using qs2.design.auto.workflowAssist.autoForm;



namespace qs2.design.auto
{



    public class ownMCRelationship
    {

        public qs2.core.vb.sqlAdmin sqlAdmin1 = null;

        public qs2.core.vb.dsAdmin.tblRelationshipRow[] arrRelationships = null;
        public qs2.core.vb.dsAdmin.tblRelationshipRow[] arrRelationshipsAsChild = null;

        public enum eTypAssignments
        {
            AutoSaveToChapter = 45700,
            ProcGroup = 45701,
            ChapterDropDownList = 45702,
            ProcGroupDropDownList = 45703,
            Roles = 45704,
            MCParent = 45705,
            none = 45799
        }
        public enum eTypActionRelation
        {
            doRelation = 10,
            setDefaultValue = 11,
        }

        public bool _isInitialized = false;

        public class cLogicResult
        {
            public bool ValueOK = false;
            public string Condition = "";
            public string FldShort = "";
        }










        public bool getRelationsship(string FldShort, string Application)
        {
            if (ownMCCriteria.dsAdminWork == null)
            {
                ownMCCriteria.dsAdminWork = new core.vb.dsAdmin();  
            }
            ownMCCriteria.dsAdminWork.Clear();
            this.arrRelationships = this.sqlAdmin1.getRelationsship(ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelRelationship.idRam, FldShort, Application, "");
            return true;
        }

        public void initControl(string Application)
        {
            try
            {
                if (this._isInitialized)
                    return;

                this.sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                this.sqlAdmin1.initControl();

                this._isInitialized = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.initControl", "", false, true, Application,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public void calcRelationForAllParents(string FldShortParent, string ChapterParent, 
                                                string IDApplication, string IDParticipant,
                                                ref eTypAssignments typeRunning, ref bool GroupRelationsFound, 
                                                ref bool ReturnValue, ref int SubRelation)
        {
           try
           {
               foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelation in this.arrRelationships)
               {
                   if (rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroups.ToString().Trim().ToLower()) ||
                        rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroupsSetDefaultValue.ToString().Trim().ToLower()))
                   {
                       if (rRelation.IDKey.Trim().ToLower().Contains((qs2.core.Enums.eClassifications.Logic.ToString().Trim().ToLower())))
                        {
                            System.Collections.Generic.List<cLogicResult> lstResultGroups = new List<cLogicResult>();

                            System.Collections.Generic.List<string> lstVarClassification = qs2.core.generic.readStrVariables(rRelation.IDKey.Trim());
                            foreach (string defVarClassification in lstVarClassification)
                            {
                                qs2.core.Enums.cVariables cVariableNew = new qs2.core.Enums.cVariables();
                                qs2.core.vb.funct.getVariablesLefRightOfPoint(defVarClassification.Trim(), ref cVariableNew.definition, ref cVariableNew.value, "=");

                                ownMCCriteria.dsAdminWork.Clear();
                                qs2.core.vb.dsAdmin.tblRelationshipRow[] arrRelationsshipGroup = this.sqlAdmin1.getRelationsship(ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelRelationship.IDRamAllGroup,
                                                                                                    rRelation.FldShortParent.Trim(), rRelation.IDApplicationParent.Trim(), defVarClassification.Trim());
                                foreach(qs2.core.vb.dsAdmin.tblRelationshipRow rRelationFoundForGroup in arrRelationsshipGroup)
                                {
                                    System.Collections.Generic.List<string> lstValuesRelationToProve = qs2.core.generic.readStrVariables(rRelationFoundForGroup.Conditions.Trim());

                                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                                    System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                                    bool valueMultiControlOK = false;
                                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControlChild in lstOwnMultiControl1)
                                    {
                                        qs2.core.generic.retValue retValueChild = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                        foreach (string valueInRelation in lstValuesRelationToProve)
                                        {
                                            if (valueInRelation.Trim().ToLower().Equals(retValueChild.valueStr.Trim().ToLower()))
                                            {
                                                valueMultiControlOK = true;
                                            }
                                        }
                                    }

                                    cLogicResult NewLogicResult = new ownMCRelationship.cLogicResult();
                                    NewLogicResult.ValueOK = valueMultiControlOK;
                                    NewLogicResult.FldShort = rRelationFoundForGroup.FldShortParent.Trim();
                                    NewLogicResult.Condition = rRelationFoundForGroup.TypeSub.Trim();
                                    lstResultGroups.Add(NewLogicResult);

                                    GroupRelationsFound = true;
                                }
                            }
                            
                            if (GroupRelationsFound)
                            {
                                bool ResultTmp = false;
                                int iCounter = 0;
                                foreach (ownMCRelationship.cLogicResult LogicResult in lstResultGroups)
                                {
                                    if (LogicResult.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.or.Trim().ToLower()))
                                    {
                                        ResultTmp = ResultTmp || LogicResult.ValueOK;
                                    }
                                    else if (LogicResult.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.and.Trim().ToLower()))
                                    {
                                        if (iCounter == 0)
                                            ResultTmp = LogicResult.ValueOK;
                                        else
                                            ResultTmp = ResultTmp && LogicResult.ValueOK; 
                                    }
                                    iCounter += 1;
                                }
                                ReturnValue = ResultTmp;
                            }
                        }
                    }
               }
           }
           catch (Exception ex)
           {
               qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.calcRelationForAllParents", FldShortParent, false, true,
                                                               IDApplication,
                                                               qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
           }
        }

        public void doRelationship(string FldShortParent, string ChapterParent, ref  qs2.core.generic.retValue retValueParent,
                                        bool userChanged, int SubRelation, string IDApplication, string IDParticipant,
                                        ref eTypAssignments typeRunning, bool ProcGroupDeactivated)
        {
            try
            {
                if (this.arrRelationships == null)
                {
                    return;
                }
                if (this.arrRelationships.Length == 0)
                {
                    return;
                }

                qs2.core.vb.dsAdmin.tblRelationshipDataTable tblAllChildsDistinct = new qs2.core.vb.dsAdmin.tblRelationshipDataTable();
                tblAllChildsDistinct.Columns.Add(qs2.core.generic.columnNameValTxt, typeof(string));
                tblAllChildsDistinct.Columns.Add(qs2.core.generic.columnNameObject, typeof(bool));

                qs2.core.vb.dsAdmin.tblRelationshipDataTable tblRelationshipAllWithValue = new qs2.core.vb.dsAdmin.tblRelationshipDataTable();
                tblRelationshipAllWithValue.Columns.Add(qs2.core.generic.columnNameValTxt, typeof(string));
                tblRelationshipAllWithValue.Columns.Add(qs2.core.generic.columnChecked, typeof(string));

                if (this.arrRelationships.Length > 0)
                {
                    foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelation in this.arrRelationships)             //All Relations with Values in Conditions
                    {
                        if (!rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroups.ToString().Trim().ToLower()) &&
                            !rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroupsSetDefaultValue.ToString().Trim().ToLower()) &&
                            (rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.Visible.ToString().Trim().ToLower()) ||
                            rRelation.Type.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.Invisible.ToString().Trim().ToLower())))
                        {
                            qs2.core.vb.dsAdmin.tblRelationshipRow rNewRelChildFound = (qs2.core.vb.dsAdmin.tblRelationshipRow)tblRelationshipAllWithValue.NewRow();
                            rNewRelChildFound.ItemArray = rRelation.ItemArray;
                            tblRelationshipAllWithValue.Rows.Add(rNewRelChildFound);
                            rNewRelChildFound[qs2.core.generic.columnNameValTxt] = "";
                            rNewRelChildFound[qs2.core.generic.columnChecked] = "";

                            //Get all Childs Distinct for recursive Child-Relation-Call
                            qs2.core.vb.dsAdmin.tblRelationshipRow rNewRelChildDistinct = null;
                            if (!rRelation.IsFldShortChildNull())
                            {
                                qs2.core.vb.dsAdmin.tblRelationshipRow[] arrNewRelChild = (qs2.core.vb.dsAdmin.tblRelationshipRow[])tblAllChildsDistinct.Select(ownMCCriteria.dsAdminWork.tblRelationship.FldShortParentColumn.ColumnName + "='" + rRelation.FldShortChild + "'" + qs2.core.sqlTxt.and + ownMCCriteria.dsAdminWork.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + rRelation.IDApplicationParent + "'");
                                if (arrNewRelChild.Length == 0)
                                {
                                    rNewRelChildDistinct = this.addSubRelationRow(rRelation.FldShortChild, rRelation.IDApplicationParent,
                                                                                    ref tblAllChildsDistinct, rRelation.Type, rRelation.TypeSub,
                                                                                    IDApplication, IDParticipant);
                                    rNewRelChildDistinct[qs2.core.generic.columnNameObject] = false;
                                    rNewRelChildDistinct[qs2.core.generic.columnNameValTxt] = "";
                                }
                                else if (arrNewRelChild.Length == 1)
                                {
                                    rNewRelChildDistinct = arrNewRelChild[0];
                                }
                                else
                                {
                                    throw new Exception("doRelationship: More than one Relationsship-Child-Row found in Table 'tblRelationshipCopy' for Field '" + rRelation.FldShortChild + "'!");
                                }
                            }

                            bool ChildIsProcGrpButton = false;
                            string ValueEqualsParent = this.doRelationshipGetChild(ref FldShortParent, ref ChapterParent, ref retValueParent, rRelation, userChanged,
                                                                                    eTypActionRelation.doRelation,
                                                                                    IDApplication, IDParticipant,
                                                                                    ref typeRunning, ProcGroupDeactivated, ref ChildIsProcGrpButton);
                            if (ValueEqualsParent != null)
                            {
                                //ValueEqualsParentFound = true;
                                if (rNewRelChildDistinct != null)
                                {
                                    rNewRelChildDistinct[qs2.core.generic.columnNameObject] = true;
                                    rNewRelChildDistinct[qs2.core.generic.columnNameValTxt] = "1";
                                }
                                rNewRelChildFound[qs2.core.generic.columnNameValTxt] = "1";
                            }
                        }
                    }
                }
                foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelChild in tblAllChildsDistinct)
                {
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl = new List<multiControl.ownMultiControl>();
                    System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstOwnGroupBox = new List<multiControl.ownGroupBox>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControlRelationChild in lstOwnMultiControl)
                    {
                        if (ownControlRelationChild != null)
                        {
                            if (SubRelation > qs2.core.ui.maxSubrelations)
                                throw new Exception("doRelationship: More than " + qs2.core.ui.maxSubrelations.ToString() + " Subrelations in Criteria-Table defined! Please reduce!");

                            int SubRelationPlus = SubRelation + 1;
                            ownControlRelationChild.doRelationsship(ownControlRelationChild.isLoaded, userChanged, SubRelationPlus, typeRunning, ChapterParent, false);
                        }
                    }
                }

                bool GroupRelationsFound = false;
                bool ReturnValue = false;
                this.calcRelationForAllParents(FldShortParent, ChapterParent, IDApplication, IDParticipant, ref typeRunning,
                                                ref GroupRelationsFound, ref ReturnValue, ref SubRelation);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationship", FldShortParent, false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public qs2.core.vb.dsAdmin.tblRelationshipRow addSubRelationRow(string FldShortParent, string IDApplicationParent,
                                                                        ref qs2.core.vb.dsAdmin.tblRelationshipDataTable tblRelationshipChilds,
                                                                        string Type, string TypeSub, string IDApplication, string IDParticipant)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblRelationshipRow rNewRelChildFound = this.sqlAdmin1.getNewRowRelationsship(tblRelationshipChilds);
                rNewRelChildFound.IDGuid = System.Guid.NewGuid();
                rNewRelChildFound.FldShortParent = FldShortParent;
                rNewRelChildFound.IDApplicationParent = IDApplicationParent;
                rNewRelChildFound.SetFldShortChildNull();
                rNewRelChildFound.SetIDApplicationChildNull();
                rNewRelChildFound.Conditions = "";
                rNewRelChildFound.Type = Type;
                rNewRelChildFound.TypeSub = TypeSub;
                rNewRelChildFound.IDKey = "";
                return rNewRelChildFound;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.addSubRelationRow", FldShortParent, false, true,
                                                            IDApplication,
                                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }

        public string doRelationshipGetChild(ref string FldShortParent,
                                                ref string ChapterParent,
                                                ref  qs2.core.generic.retValue retValueParent,
                                                qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                                bool userChanged, eTypActionRelation typAction, string IDApplication, string IDParticipant,
                                                ref eTypAssignments typeRunning, bool ProcGroupDeactivated,
                                                ref bool ChildIsProcGrpButton)
        {
            try
            {
                if (!rRelation.IsFldShortChildNull())
                {
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                    System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                    string ValueEqualsParent = null;
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControlChild in lstOwnMultiControl1)
                    {
                        bool doActionForRelation = true;
                        if (rRelation.ConditionsSub.Trim() != "")
                        {
                            if (rRelation.ConditionsSub.Trim().ToLower().Contains(("ControlType=").Trim().ToLower()))
                            {
                                System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.ConditionsSub.Trim());
                                foreach (string condition in lstCondition)
                                {
                                    System.Collections.Generic.List<string> lstControlType = qs2.core.generic.getVarsBy(condition.Trim(), "=");
                                    if (!lstControlType[1].Trim().ToLower().Equals(ownControlChild.OwnControlType.ToString().Trim().ToLower()))
                                    {
                                        doActionForRelation = false;
                                    }
                                }
                            }
                        }

                        if (doActionForRelation)
                        {
                            if (typAction == eTypActionRelation.doRelation)
                            {
                                qs2.core.generic.retValue retValueChild = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                ValueEqualsParent = this.doRelationshipCheckValue(rRelation, ref FldShortParent, ref retValueParent, ownControlChild, ref retValueChild, userChanged,
                                                                                    IDApplication, IDParticipant, ref typeRunning);
                            }
                            else if (typAction == eTypActionRelation.setDefaultValue)
                            {
                                throw new Exception("typAction == eTypActionRelation.setDefaultValue not supported!");
                                //ownControlChild.ownMCCriteria1.setDefaultDBValue(ownControlChild, userChanged);
                            }
                        }

                    }
                    foreach (qs2.design.auto.multiControl.ownTab Tab in lstTab)
                    {
                        System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                        bool bValueIsOK = false;
                        foreach (string condition in lstCondition)
                        {
                            if (condition == retValueParent.valueStr)
                            {
                                ValueEqualsParent = retValueParent.valueStr;
                                bValueIsOK = true;
                            }
                        }
                        this.doRelationsshipTab(Tab, ref IDApplication, bValueIsOK, ref rRelation, true, ref ProcGroupDeactivated);
                    }
                    foreach (UltraTab TabPage in lstTabePageReturn)
                    {
                        System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                        bool bValueIsOK = false;
                        foreach (string condition in lstCondition)
                        {
                            if (condition == retValueParent.valueStr)
                            {
                                ValueEqualsParent = retValueParent.valueStr;
                                bValueIsOK = true;
                            }
                        }
                    }
                    foreach (qs2.design.auto.multiControl.ownGroupBox ownGroupBox in lstGroupBoxReturn)
                    {
                        System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                        bool bValueIsOK = false;
                        foreach (string condition in lstCondition)
                        {
                            if (condition == retValueParent.valueStr)
                            {
                                ValueEqualsParent = retValueParent.valueStr;
                                bValueIsOK = true;
                            }
                        }
                        this.doRelationsshipGroupBox(ownGroupBox, ref IDApplication, bValueIsOK, ref rRelation, true, true, ProcGroupDeactivated);
                        ownGroupBox.ownControlUI1.IsVisible_Criteriaxy = bValueIsOK;
                        ownGroupBox.Visible = bValueIsOK;
                    }
                    return ValueEqualsParent;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationshipGetChild", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }

        public void doRelationsshipTab(qs2.design.auto.multiControl.ownTab Tab, ref string IDApplication, 
                                            bool bValueIsOK,
                                            ref qs2.core.vb.dsAdmin.tblRelationshipRow rRelation, bool DoVisibleTabPage,
                                            ref bool ProcGroupDeactivated)
        {
            try
            {
               
                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString())
                {
                    if (DoVisibleTabPage)
                    {
                        Tab.ownControlUI1.IsVisible_RelationsshipMCParent = bValueIsOK;
                        Tab.Visible = bValueIsOK;
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationsshipTabPage", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void doRelationsshipGroupBox(qs2.design.auto.multiControl.ownGroupBox ownGroupBox, ref string IDApplication, 
                                            bool bValueIsOK,
                                            ref  qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                            bool doControlsGroupBox, bool DoVisibleGroupBox, bool ProcGroupDeactivated)
        {
            try
            {
                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString())
                {
                    if (DoVisibleGroupBox)
                    {
                        ownGroupBox.Visible = bValueIsOK;
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationsshipGroupBox", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public string doRelationshipCheckValue(qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                                ref string FldShortParent,
                                                ref  qs2.core.generic.retValue retValueParent,
                                                qs2.design.auto.multiControl.ownMultiControl ownControlChild,
                                                ref  qs2.core.generic.retValue retValueChild,
                                                bool userChanged, string IDApplication, string IDParticipant,
                                                ref eTypAssignments typeRunning)
        {
            try
            {
                System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                string ValueEqualsParent = null;
                foreach (string condition in lstCondition)
                {
                    if (condition == retValueParent.valueStr && ValueEqualsParent == null)
                    {
                        ValueEqualsParent = retValueParent.valueStr;
                    }
                }
                bool bValueIsOKForAllParents = true;
                this.doRelationshipCheckValueAllChilds(rRelation, ref FldShortParent, ref retValueParent, ownControlChild, ref retValueChild, userChanged,
                                                    IDApplication, IDParticipant, ref typeRunning, ref bValueIsOKForAllParents);
                this.doRelationshipChild(rRelation, ref FldShortParent, ref retValueParent, ref ownControlChild,
                                                    ref retValueChild, ref lstCondition, ref ValueEqualsParent, userChanged, IDApplication, IDParticipant,
                                                    ref typeRunning, ref bValueIsOKForAllParents);

                return ValueEqualsParent;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationshipChild", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        public void doRelationshipCheckValueAllChilds(qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                        ref string FldShortParent,
                                        ref  qs2.core.generic.retValue retValueParent,
                                        qs2.design.auto.multiControl.ownMultiControl ownControlChild,
                                        ref  qs2.core.generic.retValue retValueChild,
                                        bool userChanged, string IDApplication, string IDParticipant,
                                        ref eTypAssignments typeRunning, ref bool bValueIsOKForAllParents)
        {
            try
            {
                this.arrRelationshipsAsChild = this.sqlAdmin1.getRelationsship(ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelRelationship.idRamAllChild, rRelation.FldShortChild.Trim(), rRelation.IDApplicationParent, "");
                foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelChild in this.arrRelationshipsAsChild)
                {
                    if (!rRelChild.FldShortParent.Trim().ToLower().Equals((rRelation.FldShortParent.Trim().ToLower())) &&
                        !rRelChild.IDApplicationParent.Trim().ToLower().Equals((rRelation.IDApplicationParent.Trim().ToLower())))
                    {
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                        System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationshipCheckValueAllChilds", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void doRelationshipChild(qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                        ref string FldShortParent,
                                        ref qs2.core.generic.retValue retValueParent,
                                        ref qs2.design.auto.multiControl.ownMultiControl ownControlChild,
                                        ref qs2.core.generic.retValue retValueChild,
                                        ref System.Collections.Generic.List<string> lstCondition, ref string ValueEqualsParent,
                                        bool userChanged, string IDApplication, string IDParticipant,
                                        ref eTypAssignments typeRunning, ref bool bValueIsOKForAllParents)
        {
            try
            {
                if (rRelation.Conditions != "")
                {
                    if (ValueEqualsParent != null && bValueIsOKForAllParents)
                    {
                        if (ownControlChild._controlType == core.Enums.eControlType.Picture)
                        {
                            ownControlChild.Picture.Image = null;
                            if (ownMCRelationship.setPictureRessource(ownControlChild, rRelation.IDKey, IDParticipant, IDApplication.ToString()))
                            {
                                ownControlChild.ownMCUI1.IsVisible_RelationsshipMCParent = true;
                                return;
                            }
                        }
                        else
                        {
                            if (rRelation.TypeSub.Trim() == qs2.core.Enums.eConditionTyp.SelList.ToString())
                            {
                                if (ownControlChild._controlType == core.Enums.eControlType.ComboBox)
                                {
                                    qs2.core.generic.retValue retValueChildOrig = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                    ownControlChild.ownMCCriteria1.ownMCCombo1.loadCombo(ownControlChild, rRelation.IDKey, ownControlChild.ownMCCriteria1.CombinationComboBoxAsDropDown, ownControlChild.ownMCCriteria1.ownMCCombo1._ComboBoxCheckThreeStateBoxAsDropDown);
                                    if (userChanged)
                                    {
                                        this.setDefaultDBValue(ownControlChild, userChanged, IDApplication, true);
                                    }
                                    else
                                    {
                                        qs2.core.generic.retValue retValue1 = new core.generic.retValue();
                                        ownControlChild.ownMCDataBind1.setRowValue(ownControlChild, retValue1.valueObj, true);

                                    }
                                    ownControlChild.ComboBox.Refresh();
                                    bool bVisibleTemp = true;
                                    this.SetVisibleRelationsship(ref typeRunning, ref ownControlChild, ref IDApplication, ref bVisibleTemp);
                                }
                            }
                            else
                            {

                                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() || rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Invisible.ToString())
                                {
                                    bool bVisibleTemp = (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() ? true : false);
                                    this.SetVisibleRelationsship(ref typeRunning, ref ownControlChild, ref IDApplication, ref bVisibleTemp);

                                    if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Invisible.ToString())
                                    {
                                        this.setDefaultDBValue(ownControlChild, userChanged, IDApplication, true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSPuIm", false))
                        //{
                        //    string xy = "";
                        //}

                        bool bVisibleTemp = false;
                        this.SetVisibleRelationsship(ref typeRunning, ref ownControlChild, ref IDApplication, ref bVisibleTemp);
                        if (rRelation.TypeSub.Trim() == qs2.core.Enums.eConditionTyp.SelList.ToString() && !userChanged)
                        {
                            //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSAoIm", false))
                            //{
                            //    string xy = "";

                            //}
                            qs2.core.generic.retValue retValue1 = new core.generic.retValue();
                            ownControlChild.ownMCDataBind1.setRowValue(ownControlChild, retValue1.valueObj, true);
                        }
                        else
                        {
                            this.setDefaultDBValue(ownControlChild, userChanged, IDApplication, true);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationshipChild", "", false, true,
                                                                    IDApplication,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void SetVisibleRelationsship(ref eTypAssignments typeRunning, ref qs2.design.auto.multiControl.ownMultiControl ownControlChild,
                                            ref string IDApplication, ref bool bVisibleTemp)
        {
            try
            {
                if (typeRunning == eTypAssignments.MCParent)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipMCParent = bVisibleTemp;
                }
                else if (typeRunning == eTypAssignments.AutoSaveToChapter)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipElementChapter = bVisibleTemp;
                }
                else if (typeRunning == eTypAssignments.ProcGroup)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipElementProcGrp = bVisibleTemp;
                }
                else if (typeRunning == eTypAssignments.ChapterDropDownList)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipElementChapterDropDown = bVisibleTemp;
                }
                else if (typeRunning == eTypAssignments.ProcGroupDropDownList)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipElementProcGrpDropDown = bVisibleTemp;
                }
                else if (typeRunning == eTypAssignments.Roles)
                {
                    ownControlChild.ownMCUI1.IsVisible_RelationsshipRoles = bVisibleTemp;
                }
                else
                {
                    throw new Exception("ownMCRelationship.SetVisibleRelationsship: typeRunning '" + typeRunning.ToString() + "' not supported!");
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.SetVisibleRelationsship", "", false, true,
                                                                    IDApplication,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void setDefaultDBValue(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1,
                                            bool userChanged, string IDApplication, bool getSelectedText)
        {
            try
            {
                if (qs2.core.ENV.TypeSetDefaultDBValue == 5)
                {
                    return;
                }
                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1.OwnFldShort, "OP1CVStadClass", false))
                {
                    bool bStop = true;
                }

                if (ownMultiControl1.ownMCUI1.controlIsDbDataControl(ownMultiControl1))
                {
                    if (qs2.core.ENV.TypeSetDefaultDBValue == 0)
                    {
                        ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueObj, true);
                        //ownMultiControl1.ownMCValue1.setValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueStr);
                        if (getSelectedText)
                        {
                            ownMultiControl1.ownMCTxt1.getSelectedText(ownMultiControl1, ownMultiControl1.IsInDesignerModus);
                        }
                    }
                    else if (qs2.core.ENV.TypeSetDefaultDBValue == 1)
                    {
                        ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueObj, true);
                    }
                    else if (qs2.core.ENV.TypeSetDefaultDBValue == 2)
                    {
                        ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueObj, false);

                    }
                    else if (qs2.core.ENV.TypeSetDefaultDBValue == 3)
                    {
                        //string xy = "";
                    }
                }
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1._FldShort, "VSAoIm", false))
                //{
                //    string xy = "";
                //}
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.setDefaultDBValue", ownMultiControl1._FldShort, false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public static bool setPictureRessource(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, string IDResPicture, string IDParticipant,
                                    string IDApplication)
        {
            try
            {
                qs2.core.language.dsLanguage.RessourcenRow rResSel = qs2.core.language.sqlLanguage.getResRow(IDResPicture, core.Enums.eResourceType.PictureEnabled, IDParticipant, IDApplication);
                if (rResSel != null)
                {
                    if (!rResSel.IsfileBytesNull())
                    {
                        ownMultiControl1.Picture.Image = rResSel.fileBytes;
                        return true;
                    }
                    else
                    {
                        ownMultiControl1.Picture.Image = null;
                        return false;
                    }
                }
                else
                {
                    ownMultiControl1.Picture.Image = null;
                    return false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.setPictureRessource", ownMultiControl1._FldShort,
                                            false, true, IDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

    }

}
