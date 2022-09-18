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
        public qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1 = new qs2.design.auto.workflowAssist.autoForm.autoUI();

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

                this.autoUI1.initialize(Application);

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
                                                ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                                                ref qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                                ref eTypAssignments typeRunning, ref bool GroupRelationsFound, 
                                                ref bool ReturnValue, ref int SubRelation)
        {
           try
           {
               //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShortParent, "opCab", false))
               //{
               //    string xy = "";
               //}
               //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShortParent, "OpValve", false))
               //{
               //    string xy = "";
               //}
               //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShortParent, "opTavi", false))
               //{
               //    string xy = "";
               //}
               
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
                                    qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rRelationFoundForGroup.FldShortParent.Trim(), IDApplication,
                                                                                                ref parentAutoUI, "",
                                                                                                ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);
                                    bool valueMultiControlOK = false;
                                    if (lstOwnMultiControl1.Count == 0)
                                    {
                                        qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rRelationFoundForGroup.FldShortParent.Trim(), qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                                                                ref parentAutoUI, "",
                                                                                                ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);
                                    }
                                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControlChild in lstOwnMultiControl1)
                                    {
                                        if (!ownControlChild.ownMCCriteria1._isInitializedCriteria)
                                        {
                                            this.autoUI1.initMulticontrol(ownControlChild, ref dataStay);
                                            //this.autoUI1.multicontrolFillData(ref dataStay, ownControlChild);
                                        }
                                        if (ownControlChild.ownMCDataBind1.Binding1 == null)
                                        {
                                            this.autoUI1.multicontrolFillData(ref dataStay, ownControlChild);
                                        }
                                        qs2.core.generic.retValue retValueChild = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                        foreach (string valueInRelation in lstValuesRelationToProve)
                                        {
                                            if (valueInRelation.Trim().ToLower().Equals(retValueChild.valueStr.Trim().ToLower()))
                                            {
                                                valueMultiControlOK = true;
                                            }
                                        }
                                    }
                                    
                                    foreach(qs2.sitemap.workflowAssist.contListAssistentElem ProcGroupFound in parentAutoUI.contListProdGroups.panelButtons.ClientArea.Controls)
                                    {
                                        if (ProcGroupFound.cListAssistentElem.rSelEntries.FldShortColumn.Trim().ToLower().Equals(rRelationFoundForGroup.FldShortParent.Trim().ToLower()))
                                        {
                                            foreach (string valueInRelation in lstValuesRelationToProve)
                                            {
                                                string sValueProcGroup = "";
                                                if (ProcGroupFound.isOn)
                                                    sValueProcGroup = "1";
                                                else
                                                    sValueProcGroup = "0";
                                                if (sValueProcGroup.Trim().ToLower().Equals(valueInRelation.Trim().ToLower()))
                                                {
                                                    valueMultiControlOK = true;
                                                }
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
                                this.doVisibleOnOffForGroupRelations(rRelation.FldShortChild.Trim(), rRelation.IDApplicationChild.Trim(), ref parentAutoUI,
                                                                        ref dataStay, ReturnValue, rRelation.Type.Trim(), ref SubRelation, ref typeRunning);

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
        public void doVisibleOnOffForGroupRelations(string FldShort, string IDApplication, ref qs2.sitemap.workflowAssist.form.contAutoUI contAutoUI,
                                                    ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, bool bValueOnOff,
                                                    string ConditionTyp, ref int SubRelation, ref eTypAssignments typeRunning)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow[] arrAutoUIRow = (qs2.core.vb.dsAdmin.dbAutoUIRow[])contAutoUI.dsAdmin1.dbAutoUI.Select(contAutoUI.dsAdmin1.dbAutoUI.FldShortColumn.ColumnName + "='" + FldShort.Trim() + "' ");
                foreach (qs2.core.vb.dsAdmin.dbAutoUIRow rCont in arrAutoUIRow)
                {
                    if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)rCont.control;
                        if (!ownMultiControlFound.ownMCCriteria1._isInitializedCriteria)
                        {
                            this.autoUI1.initMulticontrol(ownMultiControlFound, ref dataStay);
                            //this.autoUI1.multicontrolFillData(ref dataStay, ownMultiControlFound);
                        }
                        if (ownMultiControlFound.ownMCDataBind1.Binding1 == null)
                        {
                            this.autoUI1.multicontrolFillData(ref dataStay, ownMultiControlFound);
                        }

                        ownMultiControlFound.ownMCUI1.IsVisible_RelationsshipGroups = bValueOnOff;
                        ownMultiControlFound.setVisible();
                        
                        if (ConditionTyp.Trim().ToLower().Contains(qs2.core.Enums.eConditionTyp.VisibleGroupsSetDefaultValue.ToString().Trim().ToLower()) && !ownMultiControlFound.ownMCUI1.IsVisible_RelationsshipGroups)
                        {
                            this.setDefaultDBValue(ownMultiControlFound, false, ownMultiControlFound.ownMCCriteria1.Application.Trim(), true);
                        }
                        if (SubRelation > qs2.core.ui.maxSubrelations)
                            throw new Exception("doVisibleOnOffForGroupRelations: More than " + qs2.core.ui.maxSubrelations.ToString() + " Subrelations in Criteria-Table defined! Please reduce!");

                        int SubRelationPlus = SubRelation + 1;
                        string sChapterparent = "";
                        if (ownMultiControlFound.rAutoUI != null)
                        {
                            sChapterparent = ownMultiControlFound.rAutoUI.Chapter;
                        }
                        ownMultiControlFound.doRelationsship(ownMultiControlFound.isLoaded, false, SubRelationPlus, typeRunning, sChapterparent, false);
                    }
                    else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                    {
                        qs2.design.auto.multiControl.ownGroupBox ownGroupBoxFound = (qs2.design.auto.multiControl.ownGroupBox)rCont.control;
                        ownGroupBoxFound.ownControlUI1.IsVisible_RelationsshipGroups = bValueOnOff;
                        ownGroupBoxFound.doVisible2();
                    }
                    else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    {
                        qs2.design.auto.multiControl.ownTab ownTabFound = (qs2.design.auto.multiControl.ownTab)rCont.control;
                        ownTabFound.ownControlUI1.IsVisible_RelationsshipGroups = bValueOnOff;
                        bool bIsVisible = false;
                        ownTabFound.doVisible2(ref bIsVisible);
                    }
                    else if (rCont.control.GetType().Equals(typeof(UltraTab)))
                    {
                        UltraTab ownTabFound = (UltraTab)rCont.control;
                        workflowAssist.autoForm.cTabTag TabTag = (workflowAssist.autoForm.cTabTag)ownTabFound.Tag;
                        TabTag.ownMCUI1.IsVisible_RelationsshipGroups = bValueOnOff;
                        bool bVisibleCriteria = autoUI.doVisibleTabPage(TabTag.ownMCUI1);

                        bool VisibleSumTabePage = bVisibleCriteria && TabTag.ownMCUI1.IsVisible_RelationsshipGroups;
                        //bool VisibleSumTabePage = bValueOnOff;
                        ownTabFound.Visible = VisibleSumTabePage;
                        //ownTabFound.TabControl.Tabs[ownTabFound.Key].Visible = VisibleSumTabePage;
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

        public void doRelationship(string FldShortParent, string ChapterParent, ref  qs2.core.generic.retValue retValueParent,
                                        bool userChanged, int SubRelation, string IDApplication, string IDParticipant,
                                        ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                                        ref qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
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
                                                                                    ref dataStay, ref parentAutoUI,
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
                    qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rRelChild.FldShortParent, rRelChild.IDApplicationParent, ref parentAutoUI, "",
                                                                                ref lstOwnMultiControl, ref lstTabePageReturn, ref lstTab, ref lstOwnGroupBox);
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
                this.calcRelationForAllParents(FldShortParent, ChapterParent, IDApplication, IDParticipant, ref dataStay, ref parentAutoUI, ref typeRunning,
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
                                                ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                                                ref qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
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
                    qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rRelation.FldShortChild, IDApplication,
                                                                                                    ref parentAutoUI, "",
                                                                                                    ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);  // OMC.IDApplication.Check
                    string ValueEqualsParent = null;
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControlChild in lstOwnMultiControl1)
                    {
                        //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild.OwnFldShort, " VCardTx", false))
                        //{
                        //    string xy = "";
                        //}

                        if (!ownControlChild.ownMCCriteria1._isInitializedCriteria)
                        {
                            this.autoUI1.initMulticontrol(ownControlChild, ref dataStay);
                            //this.autoUI1.multicontrolFillData(ref dataStay, ownControlChild);
                        }
                        if (ownControlChild.ownMCDataBind1.Binding1 == null)
                        {
                            this.autoUI1.multicontrolFillData(ref dataStay, ownControlChild); 
                        }

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
                        this.doRelationsshipTab(Tab, ref IDApplication, ref parentAutoUI, ref dataStay, bValueIsOK, ref rRelation, true, ref ProcGroupDeactivated);
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
                        this.doRelationsshipTabPage(TabPage, ref IDApplication, ref parentAutoUI, ref dataStay, bValueIsOK, ref rRelation, true, ref ProcGroupDeactivated);
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
                        this.doRelationsshipGroupBox(ownGroupBox, ref IDApplication, ref parentAutoUI, ref dataStay, bValueIsOK, ref rRelation, true, true, ProcGroupDeactivated);
                        ownGroupBox.ownControlUI1.IsVisible_Criteriaxy = bValueIsOK;
                        ownGroupBox.Visible = bValueIsOK;
                        if (ProcGroupDeactivated && !bValueIsOK)
                        {
                            //string protocollForAdmin = "";
                            //bool ProtocolWindow = false;
                            //System.Collections.Generic.List<string> lstElementsActive = new List<string>();
                            //qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = eTypAssignments.none;
                            //design.auto.workflowAssist.autoForm.doAutoControls.eRetDoControls RetDoControls = new design.auto.workflowAssist.autoForm.doAutoControls.eRetDoControls();
                            //core.vb.dsAdmin.tblStayAdditionsDataTable tStayAdditionsCopy = new core.vb.dsAdmin.tblStayAdditionsDataTable();

                            //ownGroupBox.parentAutoUI.doAutoControls.doControlChapters("", design.auto.workflowAssist.autoForm.doAutoControls.eTypActivityControl.ResetToDefaultValuesParentGuid, false, "", "",
                            //                                    ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck,
                            //                                    ref ownGroupBox.parentAutoUI.contAutoProtokoll1, ref ownGroupBox.parentAutoUI.dsAdmin1, ref ownGroupBox.parentAutoUI.autoUI1,
                            //                                    ref ownGroupBox.parentAutoUI.dataStay, ref ownGroupBox.parentAutoUI.autoPrint,
                            //                                    ref RetDoControls, ref ownGroupBox.parentAutoUI._runAsSystemuser, ref ownGroupBox.parentAutoUI._runAsUser, ref tStayAdditionsCopy, ownGroupBox.ID);

                        }
                        //ownGroupBox.doVisible();
                    }

                    foreach (sitemap.workflowAssist.contListAssistentElem btnProcGrp in parentAutoUI.contListProdGroups.panelButtons.ClientArea.Controls)
                    {
                        if (btnProcGrp.cListAssistentElem.rSelEntries.FldShortColumn.Trim().ToLower().Equals(rRelation.FldShortChild.Trim().ToLower()))
                        {
                            object sender = (object)btnProcGrp;
                            EventArgs evArg = new EventArgs();
                            string protocollForAdmin = "";
                            bool ProtocolWindow = false;
                            System.Collections.Generic.List<string> lstElementsActive = new List<string>();
                            //qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = qs2.design.auto.ownMCRelationship.eTypAssignments.none;

                            System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rRelation.Conditions);
                            bool bValueEqualsParent = false;
                            ChildIsProcGrpButton = true;
                            foreach (string condition in lstCondition)
                            {
                                if (condition == retValueParent.valueStr && ValueEqualsParent == null)
                                {
                                    btnProcGrp.Visible = true;
                                    //btnProcGrp.btnElementClick(sender, evArg, true, true, false, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck, false);
                                    //btnProcGrp.doRelationsship(false);
                                    btnProcGrp.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, btnProcGrp.cListAssistentElem.IDSelEntry, btnProcGrp.isOn);

                                    ValueEqualsParent = retValueParent.valueStr;
                                    bValueEqualsParent = true;
                                }
                            }
                            if (!bValueEqualsParent)
                            {
                                btnProcGrp.Visible = false;
                                //btnProcGrp.btnElementClick(sender, evArg, false, true, false, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck, false);
                                //btnProcGrp.doRelationsship(false);
                                btnProcGrp.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, btnProcGrp.cListAssistentElem.IDSelEntry, btnProcGrp.isOn);
                            }

                            if (protocollForAdmin != "")
                            {
                                qs2.core.Protocol.doExcept(protocollForAdmin, "ownMCRelationship.doRelationshipGetChild", btnProcGrp.cListAssistentElem.rSelEntries.FldShortColumn.Trim(), false, true,
                                                                                IDApplication, qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                            }
                        }
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

        public void doRelationsshipTab(qs2.design.auto.multiControl.ownTab Tab, ref string IDApplication, ref qs2.sitemap.workflowAssist.form.contAutoUI contAutoUI,
                                            ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, bool bValueIsOK,
                                            ref qs2.core.vb.dsAdmin.tblRelationshipRow rRelation, bool DoVisibleTabPage,
                                            ref bool ProcGroupDeactivated)
        {
            try
            {
               
                qs2.core.vb.dsAdmin.dbAutoUIRow[] arrAutoUIRow = (qs2.core.vb.dsAdmin.dbAutoUIRow[])contAutoUI.dsAdmin1.dbAutoUI.Select(contAutoUI.dsAdmin1.dbAutoUI.FldShortTabPageParentColumn.ColumnName + "='" + Tab.OwnFldShort.Trim() + "' ");
                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString())
                {
                    if (DoVisibleTabPage)
                    {
                        Tab.ownControlUI1.IsVisible_RelationsshipMCParent = bValueIsOK;
                        Tab.Visible = bValueIsOK;
                    }
                    if (!bValueIsOK)
                    {
                        foreach (qs2.core.vb.dsAdmin.dbAutoUIRow rCont in arrAutoUIRow)
                        {
                            if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                            {
                            }
                        }
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

        public void doRelationsshipTabPage(UltraTab TabePage, ref string IDApplication, ref qs2.sitemap.workflowAssist.form.contAutoUI contAutoUI,
                                            ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, bool bValueIsOK,
                                            ref  qs2.core.vb.dsAdmin.tblRelationshipRow rRelation, bool DoVisibleTabPage,
                                            ref bool ProcGroupDeactivated)
        {
            try
            {
                qs2.design.auto.workflowAssist.autoForm.cTabTag cTabTag = (qs2.design.auto.workflowAssist.autoForm.cTabTag)TabePage.Tag;
                qs2.core.vb.dsAdmin.dbAutoUIRow[] arrAutoUIRow = (qs2.core.vb.dsAdmin.dbAutoUIRow[])contAutoUI.dsAdmin1.dbAutoUI.Select(contAutoUI.dsAdmin1.dbAutoUI.FldShortTabPageParentColumn.ColumnName + "='" + cTabTag.IDOwnStrTabPage.Trim() + "' ");
                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString())
                {
                    if (DoVisibleTabPage)
                    {
                        qs2.design.auto.workflowAssist.autoForm.cTabTag TabTag = (qs2.design.auto.workflowAssist.autoForm.cTabTag)TabePage.Tag;
                        if (TabTag.ownMCUI1.IsVisible_Criteriaxy && TabTag.ownMCUI1.IsVisible_LicenseKey)
                        {
                            autoUI.doVisibleTabPage(TabTag.ownMCUI1);
                            TabePage.Visible = bValueIsOK;
                            if (bValueIsOK)
                            {
                                TabePage.TabControl.SelectedTab = TabePage;
                                TabePage.TabControl.ActiveTab = TabePage;
                                //Application.DoEvents();
                            }
                            else
                            {

                            }
                        }
                    }
                    if (!bValueIsOK)
                    {
                        foreach (qs2.core.vb.dsAdmin.dbAutoUIRow rCont in arrAutoUIRow)
                        {
                            if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                            {
                                qs2.design.auto.multiControl.ownMultiControl ownMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)rCont.control;

                                bool bMCIsVisibleInOhterChapter = this.checkMCExistsMoreAndVisible(ownMultiControlFound);
                                if (!bMCIsVisibleInOhterChapter)
                                {
                                    this.setDefaultDBValue(ownMultiControlFound, false, IDApplication, true);
                                }
                                ownMultiControlFound.doRelationsship(ownMultiControlFound.isLoaded, true, 0, design.auto.ownMCRelationship.eTypAssignments.MCParent,
                                                                        ownMultiControlFound.rAutoUI.Chapter, false);
                            }
                            else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                            {
                                qs2.design.auto.multiControl.ownGroupBox ownGroupBoxFound = (qs2.design.auto.multiControl.ownGroupBox)rCont.control;
                                if (!ownGroupBoxFound.ownControlCriteria1._isInitializedCriteria)
                                {
                                }
                                this.doRelationsshipGroupBox(ownGroupBoxFound, ref IDApplication, ref contAutoUI, ref dataStay, bValueIsOK, ref rRelation, false, false, ProcGroupDeactivated);
                                
                            }
                            else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                            {
                                qs2.design.auto.multiControl.ownTab ownTabFound = (qs2.design.auto.multiControl.ownTab)rCont.control;
                                foreach (UltraTab contTabPageSub in ownTabFound.Tabs)
                                {
                                    this.doRelationsshipTabPage(contTabPageSub, ref IDApplication, ref contAutoUI, ref dataStay, bValueIsOK, ref rRelation, false, ref ProcGroupDeactivated);
                                }
                            }
                        }
                    }
                }

                //if (TabePage.TabControl.SelectedTab == null)
                //{
                //    foreach (UltraTab TabePageFound in TabePage.TabControl.Tabs)
                //    {
                //        if (TabePageFound.Visible)
                //        {
                //            TabePage.TabControl.ActiveTab = TabePageFound;
                //            TabePage.TabControl.SelectedTab = TabePageFound;
                //            Application.DoEvents();
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.doRelationsshipTabPage", "", false, true,
                                                                IDApplication,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void doRelationsshipGroupBox(qs2.design.auto.multiControl.ownGroupBox ownGroupBox, ref string IDApplication, ref qs2.sitemap.workflowAssist.form.contAutoUI contAutoUI,
                                            ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, bool bValueIsOK,
                                            ref  qs2.core.vb.dsAdmin.tblRelationshipRow rRelation,
                                            bool doControlsGroupBox, bool DoVisibleGroupBox, bool ProcGroupDeactivated)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow[] arrAutoUIRow = (qs2.core.vb.dsAdmin.dbAutoUIRow[])contAutoUI.dsAdmin1.dbAutoUI.Select(contAutoUI.dsAdmin1.dbAutoUI.FldShortGroupBoxParentColumn.ColumnName + "='" + ownGroupBox._FldShort.Trim() + "' ");
                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString())
                {
                    if (!bValueIsOK)
                    {
                        foreach (qs2.core.vb.dsAdmin.dbAutoUIRow rCont in arrAutoUIRow)
                        {
                            if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                            {
                                qs2.design.auto.multiControl.ownMultiControl ownMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)rCont.control;

                                bool bMCIsVisibleInOhterChapter = this.checkMCExistsMoreAndVisible(ownMultiControlFound);
                                if (!bMCIsVisibleInOhterChapter)
                                {
                                    this.setDefaultDBValue(ownMultiControlFound, false, IDApplication, true);
                                }
                            }
                            else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                            {
                                qs2.design.auto.multiControl.ownGroupBox ownGroupBoxFound = (qs2.design.auto.multiControl.ownGroupBox)rCont.control;
                                if (!ownGroupBoxFound.ownControlCriteria1._isInitializedCriteria)
                                {
                                }
                                if (doControlsGroupBox)
                                {
                                    this.doRelationsshipGroupBox(ownGroupBoxFound, ref IDApplication, ref contAutoUI, ref dataStay, bValueIsOK, ref rRelation, false, DoVisibleGroupBox, ProcGroupDeactivated);
                                }
                            }
                            else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                            {
                                qs2.design.auto.multiControl.ownTab ownTabFound = (qs2.design.auto.multiControl.ownTab)rCont.control;
                                foreach (UltraTab contTabPage in ownTabFound.Tabs)
                                {
                                    this.doRelationsshipTabPage(contTabPage, ref IDApplication, ref contAutoUI, ref dataStay, bValueIsOK, ref rRelation, false, ref ProcGroupDeactivated);
                                }
                            }
                        }
                    }
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

        public bool checkMCExistsMoreAndVisible(qs2.design.auto.multiControl.ownMultiControl MCToCheck)
        {
            try
            {
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                qs2.design.auto.workflowAssist.autoForm.autoUI.getMultiControl(MCToCheck.OwnFldShort.Trim(),
                                                                                MCToCheck.ownMCCriteria1.Application.Trim(),
                                                                                ref MCToCheck.parentAutoUI.dsAdmin1, "", ref lstMultiControl,
                                                                                ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);
                bool bMCIsVisibleInOhterChapter = false;
                if (lstMultiControl.Count > 1)
                {
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 in lstMultiControl)
                    {
                        if (!ownMultiControl1.ownMCCriteria1._isInitializedCriteria)
                        {
                            this.autoUI1.initMulticontrol(ownMultiControl1, ref ownMultiControl1.parentAutoUI.dataStay);
                            this.autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
                        }
                        if (ownMultiControl1.ownMCDataBind1.Binding1 == null)
                        {
                            autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
                        }

                        bool bIsVisible = ownMultiControl1.getVisiblebyOrder();
                        if (bIsVisible)
                        {
                            bMCIsVisibleInOhterChapter = true;
                        }
                    }
                }
            
                return bMCIsVisibleInOhterChapter;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCRelationship.checkMCExistsMoreAndVisible", "", false, true,
                                                                MCToCheck.ownMCCriteria1.Application.Trim(),
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
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
                        qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rRelation.FldShortParent, IDApplication,
                                                                                    ref ownControlChild.parentAutoUI, "",
                                                                                    ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);

                        foreach (qs2.design.auto.multiControl.ownMultiControl multiControlFound in lstOwnMultiControl1)
                        {
                            if (!multiControlFound.ownMCCriteria1._isInitializedCriteria)
                            {
                                this.autoUI1.initMulticontrol(multiControlFound, ref multiControlFound.parentAutoUI.dataStay);
                            }
                            if (multiControlFound.ownMCDataBind1.Binding1 == null)
                            {
                                this.autoUI1.multicontrolFillData(ref multiControlFound.parentAutoUI.dataStay, multiControlFound);
                            }
                            qs2.core.generic.retValue retValueParentFound = multiControlFound.ownMCDataBind1.getValueFromRow(multiControlFound);
                            System.Collections.Generic.List<string> lstConditionParent = qs2.core.generic.readStrVariables(rRelChild.Conditions);
                            foreach (string condition in lstConditionParent)
                            {
                                if (condition != retValueParentFound.valueStr)
                                {
                                    bValueIsOKForAllParents = false;
                                }
                            }
                        }
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
                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSPuIm", false))
                    //{
                    //    string xy = "";
                    //}

                    if (ValueEqualsParent != null && bValueIsOKForAllParents)
                    {
                        if (ownControlChild._controlType == core.Enums.eControlType.Picture)
                        {
                            ownControlChild.Picture.Image = null;
                            if (ownMCRelationship.setPictureRessource(ownControlChild, rRelation.IDKey, IDParticipant, IDApplication.ToString()))
                            {
                                ownControlChild.ownMCUI1.IsVisible_RelationsshipMCParent = true;
                                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShortParent, "OpSuCoCranNL", false))
                                //{
                                //    string xy = "";
                                //}
                                //ownControlChild.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            if (rRelation.TypeSub.Trim() == qs2.core.Enums.eConditionTyp.SelList.ToString())
                            {
                                if (ownControlChild._controlType == core.Enums.eControlType.ComboBox)
                                {
                                    //if (ownControlChild._controlType == core.Enums.eControlType.ComboBox)
                                    //{
                                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSAoIm", false))
                                    //{
                                    //    string xy = "";
                                    //}
                                    qs2.core.generic.retValue retValueChildOrig = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                    ownControlChild.ownMCCriteria1.ownMCCombo1.loadCombo(ownControlChild, rRelation.IDKey, ownControlChild.ownMCCriteria1.CombinationComboBoxAsDropDown, ownControlChild.ownMCCriteria1.ownMCCombo1._ComboBoxCheckThreeStateBoxAsDropDown);
                                    if (userChanged)
                                    {
                                        //qs2.core.generic.retValue ret = qs2.core.dbBase.getDefaultDBValue(ref ownControlChild.ownMCCriteria1.rColSys, true);
                                        this.setDefaultDBValue(ownControlChild, userChanged, IDApplication, true);
                                    }
                                    else
                                    {
                                        //ownControlChild.ownControlDataBind1.BindControlToData(ownControlChild, false, ownControlChild.ownControlDataBind1.dataStay);
                                        //qs2.core.generic.retValue retValue1 = ownControlChild.ownMCDataBind1.getValueFromRow(ownControlChild);
                                        //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSAoIm", false))
                                        //{
                                        //    string xy = "";
                                        //}
                                        //ownControlChild.ownMCDataBind1.setRowValue(ownControlChild, retValueChildOrig.valueObj, true);
                                        qs2.core.generic.retValue retValue1 = new core.generic.retValue();
                                        retValue1.valueObj = ownControlChild.parentAutoUI.dataStay.coreStaysProductsOrig.getField(ownControlChild.OwnFldShort.Trim());
                                        ownControlChild.ownMCDataBind1.setRowValue(ownControlChild, retValue1.valueObj, true);

                                    }
                                    ownControlChild.ComboBox.Refresh();
                                    bool bVisibleTemp = true;
                                    this.SetVisibleRelationsship(ref typeRunning, ref ownControlChild, ref IDApplication, ref bVisibleTemp);
                                }
                            }
                            else
                            {
                                //if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() || rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Invisible.ToString())
                                //{
                                //    ownControlChild.ownMCUI1.controlIsVisibleRelationsship = (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() ? true : false);
                                //}

                                if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() || rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Invisible.ToString())
                                {
                                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControlChild._FldShort, "VSPuIm", false))
                                    //{
                                    //    string xy = "";
                                    //}

                                    bool bVisibleTemp = (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Visible.ToString() ? true : false);
                                    this.SetVisibleRelationsship(ref typeRunning, ref ownControlChild, ref IDApplication, ref bVisibleTemp);

                                    if (rRelation.Type.Trim() == qs2.core.Enums.eConditionTyp.Invisible.ToString())
                                    {
                                        this.setDefaultDBValue(ownControlChild, userChanged, IDApplication, true);
                                    }
                                    //qs2.core.Protocol.doMonitoring("ownMCCriteria.doRelationshipChild", qs2.core.ENV.TagForMonitoring.Trim(), 
                                    //                                ownControlChild.ownMCUI1.controlIsVisibleRelationsship, null, "", IDApplication.ToString(),
                                    //                                core.Protocol.eTypeError.Info);
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
                            retValue1.valueObj = ownControlChild.parentAutoUI.dataStay.coreStaysProductsOrig.getField(ownControlChild.OwnFldShort.Trim());
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
                if (!ownMultiControl1.ownMCCriteria1._isInitializedCriteria)
                {
                    this.autoUI1.initMulticontrol(ownMultiControl1, ref ownMultiControl1.parentAutoUI.dataStay);
                    //this.autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
                }
                if (ownMultiControl1.ownMCDataBind1.Binding1 == null)
                {
                    //if (qs2.core.ENV.TypeSetDefaultDBValue == 0 || qs2.core.ENV.TypeSetDefaultDBValue == 1)
                    //{
                        this.autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);  
                    //}
                }
                if (ownMultiControl1.ownMCUI1.controlIsDbDataControl(ownMultiControl1))
                {
                    if (qs2.core.ENV.TypeSetDefaultDBValue == 0)
                    {
                        ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueObj, true);
                        //ownMultiControl1.ownMCValue1.setValue(ownMultiControl1, ownMultiControl1.ownMCCriteria1.defaultDBValue.valueStr);
                        ownMultiControl1.Refresh();
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
