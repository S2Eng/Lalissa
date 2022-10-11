using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using qs2.core.vb;
using System.Data;

namespace qs2.ui
{


    public class drawMulticontrol
    {
        
        public sqlAdmin sqlAdmin1;
        public dsAdmin dsAdmin1;

        //public qs2.core.generic generic1 { get; set; } = new qs2.core.generic();
        public qs2.sitemap.print.genSql genSql1 = new qs2.sitemap.print.genSql();

        




        public void initControl()
        {
            try
            {
                this.sqlAdmin1 = new sqlAdmin();
                this.sqlAdmin1.initControl();
                this.dsAdmin1 = new dsAdmin();

                this.genSql1.initControl();
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.initControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void setMultiControl2(qs2.design.auto.multiControl.ownMultiControl multiControl, string IDApplication, string IDParticipant,
                                        ref string protocollForAdmin, ref bool protocolWindow, string OwnFldShort, bool bCriteriaForAllproducts,
                                        string ComboAsDropDownCondition)
        {
            try
            {
                qs2.core.Protocol.alwaysShowExceptionMulticontrol = true;
                qs2.design.auto.multiControl.ownMCGeneric.loadRessourceThreeStateButtons();

                multiControl.IsEvaluation = true;
                multiControl.Visible = true;
                multiControl.ownMCCriteria1._isInitializedCriteria = false;
                multiControl._txtIsLoaded = false;
                multiControl.doControlIsDone = false;
                multiControl.ownMCTxt1.toolTipIsInitialized = false;
                multiControl.ownMCFormat1.formatInitialized = false;
                multiControl.ownMCDataBind1.TypeBinding = design.auto.multiControl.ownMCDataBind.dTypeBinding.noBinding;
                multiControl.infragLabelRight.Text = "";
                multiControl.ownMCCriteria1.ownMCCombo1.ComboBoxIsInitialized = false;
                multiControl.ownMCCriteria1._isInitializedGetData = false;
                multiControl.countButtonsRigth = 1;
                multiControl.panelButtonsOnOff.Width = 20;

                multiControl.ownMCCriteria1.Application = IDApplication;
                multiControl.ownMCCriteria1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                multiControl.ownMCCriteria1.CombinationComboBoxAsDropDown = ComboAsDropDownCondition.Trim();
                multiControl.ownMCCriteria1.ownMCCombo1.ComboBoxIsObjectComboBoxForUserAdministration = true;
                multiControl._controlType = core.Enums.eControlType.ComboBoxAsDropDown;
                multiControl.OwnFldShort = OwnFldShort;
                multiControl.ownMCCriteria1.initControl();
                multiControl.setControl(true);
                multiControl.setEditable(true, false);

                bool ProtocollWindow = false;
                multiControl.ownMCCriteria1.initControl();
                multiControl.ownMCCriteria1.ownMCCombo1.TypeComboBox = qs2.core.Enums.cVariablesValues.Roles;
                multiControl.ownMCCriteria1.getData((System.Windows.Forms.Control)multiControl, OwnFldShort.Trim(), multiControl.OwnControlType, multiControl.ComboBox,
                                                    ref multiControl.ownMCUI1, null, ref protocollForAdmin, ref ProtocollWindow, bCriteriaForAllproducts, false, true);

                multiControl.panelButtons.Controls.Clear();
                System.Windows.Forms.Control contMC = multiControl.ownMCUI1.doButtonControls(design.auto.multiControl.ownMCEvents.eTypButtonControl.Clear, null, "",
                                                        qs2.core.language.sqlLanguage.getRes("DeleteSelection"), multiControl);
                multiControl.ownMCUI1.doCheckBoxAdd(multiControl);

                multiControl.Visible = true;

            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.setMultiControl2:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
   
        public void setMultiControl(qs2.design.auto.multiControl.ownMultiControl multiControl, qs2.core.vb.dsAdmin.tblQueriesDefRow rQry,
                            dsAdmin.tblSelListEntriesRow rSelectedSelList, qs2.core.Enums.eTypQueryDef typQueryDef,
                            string IDApplication, string IDParticipant, bool translateLabel, bool editable, string subCondition,
                            bool addAdditionalLabel, string IDResAdditionalLabel, System.Windows.Forms.Control cont, 
                            ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                qs2.core.Protocol.alwaysShowExceptionMulticontrol = true;
                qs2.design.auto.multiControl.ownMCGeneric.loadRessourceThreeStateButtons();

                multiControl.hasINCondition = false;
                bool hasINConditionTmp = false;
                if (rQry.Condition.Trim().ToLower().Equals(("IN").Trim().ToLower()) || rQry.Condition.Trim().ToLower().Equals(("NOT IN").Trim().ToLower()))
                {
                    hasINConditionTmp = true;
                }

                this.clearMCControls(multiControl);

                multiControl.IsEvaluation = true;
                multiControl.Visible = true;
                multiControl.ownMCCriteria1._isInitializedCriteria = false;
                multiControl._txtIsLoaded = false;
                multiControl.doControlIsDone = false;
                multiControl.ownMCTxt1.toolTipIsInitialized = false;
                multiControl.ownMCFormat1.formatInitialized = false;
                multiControl.ownMCDataBind1.TypeBinding = design.auto.multiControl.ownMCDataBind.dTypeBinding.noBinding;
                multiControl.infragLabelRight.Text = "";
                multiControl.ownMCCriteria1.ownMCCombo1.ComboBoxIsInitialized = false;
                multiControl.ownMCCriteria1._isInitializedGetData = false;
                //multiControl.panelButtons.Controls.Clear();
                multiControl.countButtonsRigth = 1;
                multiControl.panelButtonsOnOff.Width = 20;
                

                multiControl.ownMCCriteria1.Application = IDApplication;   // OMC.IDApplication.Check
                multiControl.ownMCCriteria1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                bool ControlWasCheckBox = false;
                multiControl.ownMCCriteria1.CombinationComboBoxAsDropDown = rQry.ComboAsDropDownCondition.Trim();

                bool ComboBoxCheckThreeStateBoxAsDropDown = false;
                core.Enums.eControlType PrevControlType = core.Enums.eControlType.Label;
                if (!rQry.IsCriteriaFldShortNull() && !rQry.IsSQLServerField && (typQueryDef == core.Enums.eTypQueryDef.WhereConditions || (typQueryDef == core.Enums.eTypQueryDef.InputParameters)))
                {
                    string prot = "";
                    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = this.genSql1.getCriteria(rQry.CriteriaFldShort , rQry.CriteriaApplication, ref prot);
                    if (rCriteria != null)
                    {
                        if (rCriteria.IDApplication == qs2.core.license.doLicense.eApp.ALL.ToString())
                        {
                            multiControl.OwnFieldForALLProducts = true;
                            multiControl.ownMCCriteria1.Application = rCriteria.IDApplication;
                        }
                        else
                        {
                            multiControl.OwnFieldForALLProducts = false;
                        }
                        qs2.core.Enums.eControlType controlType = qs2.core.generic.searchEnumControlType(rCriteria.ControlType);
                        PrevControlType = controlType;
                        if (controlType == core.Enums.eControlType.CheckBox ||
                                controlType == core.Enums.eControlType.CheckBoxNoDb ||
                                controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                        {
                            if (controlType == core.Enums.eControlType.CheckBox ||
                                controlType == core.Enums.eControlType.CheckBoxNoDb)
                            {
                                ControlWasCheckBox = true;
                            }
                            controlType = core.Enums.eControlType.ComboBoxCheckThreeStateBox;
                            if (rQry.ComboAsDropDown)
                            {
                                ComboBoxCheckThreeStateBoxAsDropDown = true;
                                controlType = core.Enums.eControlType.ComboBoxAsDropDown;
                            }
                            multiControl._controlType = controlType;
                        }
                        else if (!hasINConditionTmp && (controlType == core.Enums.eControlType.ComboBox ||
                                 controlType == core.Enums.eControlType.ComboBoxNoDb))
                        {
                            if (rQry.ComboAsDropDown)
                            {
                                controlType = core.Enums.eControlType.ComboBoxAsDropDown;
                            }
                            multiControl._controlType = controlType;
                        }
                        else
                        {
                            multiControl._controlType = controlType;
                            if (hasINConditionTmp &&
                                (multiControl._controlType == core.Enums.eControlType.Textfield || multiControl._controlType == core.Enums.eControlType.TextfieldMulti ||
                                    multiControl._controlType == core.Enums.eControlType.Integer || multiControl._controlType == core.Enums.eControlType.Numeric ||
                                    multiControl._controlType == core.Enums.eControlType.ComboBox ||
                                    multiControl._controlType == core.Enums.eControlType.Date || multiControl._controlType == core.Enums.eControlType.DateTime ||
                                    multiControl._controlType == core.Enums.eControlType.Time))
                            {
                                multiControl.hasINCondition = true;
                                multiControl.INCondition = rQry.Condition.Trim();
                                multiControl.controlTypeINCondition = multiControl.OwnControlType;
                                multiControl.OwnControlType = core.Enums.eControlType.Textfield;
                            }
                        }

                        //if (controlType == core.Enums.eControlType.CheckBox ||
                        //    controlType == core.Enums.eControlType.CheckBoxNoDb)
                        //{
                        //    controlType = core.Enums.eControlType.ThreeStateCheckBox;
                        //}
                        multiControl.OwnFldShort = rQry.CriteriaFldShort;

                        //multiControl.ownMCTxt1.setToolTipFormatForDbControl(multiControl);
                        
                        multiControl.setControl(true);
                        //newElement.OwnFldShort = (!rQry.Label.Trim().Equals("") ? rQry.Label.Trim() : rQry.QueryFldShort);
                        multiControl.ownMCCriteria1.ownMCCombo1.PrevControlType = PrevControlType;
                        multiControl.ownMCCriteria1.getData(multiControl, rQry.CriteriaFldShort, controlType, multiControl.ComboBox, 
                                                            ref multiControl.ownMCUI1, multiControl, ref protocollForAdmin,
                                                            ref protocolWindow, multiControl.OwnFieldForALLProducts, ControlWasCheckBox, ComboBoxCheckThreeStateBoxAsDropDown);
                        if (translateLabel)
                        {
                            multiControl.ownMCTxt1.doText(multiControl, true, false);
                        }
                        
                        if (translateLabel)
                            this.translateLabel(rQry.Label, ref multiControl, IDApplication, IDParticipant, true);
                        //if (addAdditionalLabel)
                        //    this.translateAdditionalLabel(IDResAdditionalLabel, ref multiControl);

                        //newElement.doActionControl(design.auto.multiControl.ownMultiControl.eTypActionControl.setEditableAndFocus);

                        if (multiControl.hasINCondition)
                        {
                            multiControl.ownMCFormat1.formatInitialized = true;
                            multiControl.panelButtons.Controls.Clear();
                            System.Windows.Forms.Control contMC = multiControl.ownMCUI1.doButtonControls(design.auto.multiControl.ownMCEvents.eTypButtonControl.addSelList, null, "",
                                                                                        qs2.core.language.sqlLanguage.getRes("InputINKlausel"), multiControl);
                        }
                        else
                        {
                            multiControl.ownMCFormat1.formatInitialized = false;
                            multiControl.ownMCFormat1.setFormatFromDb(multiControl, true, false);
                        }
                        //multiControl.Visible = true;

                        multiControl.ownMCUI1.IsVisible_Criteriaxy = true;
                        multiControl.ownMCUI1.IsVisible_RelationsshipMCParent = true;
                        multiControl.setVisible();
                    }
                }
                else if ((typQueryDef == core.Enums.eTypQueryDef.InputParameters || typQueryDef == core.Enums.eTypQueryDef.WhereConditions) && rQry.IsCriteriaFldShortNull())
                {
                    qs2.core.Enums.eControlType controlType = qs2.core.generic.searchEnumControlType(rQry.ControlType);
                    Infragistics.Win.UltraWinEditors.NumericType NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
                    if (controlType == core.Enums.eControlType.Integer)
                    {
                        controlType = core.Enums.eControlType.Numeric;
                        NumericType = Infragistics.Win.UltraWinEditors.NumericType.Integer;
                    }
                    PrevControlType = controlType;

                    if (controlType == core.Enums.eControlType.CheckBox ||
                        controlType == core.Enums.eControlType.CheckBoxNoDb ||
                        controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                        controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                    {
                        if (controlType == core.Enums.eControlType.CheckBox ||
                            controlType == core.Enums.eControlType.CheckBoxNoDb)
                        {
                            ControlWasCheckBox = true;
                        }
                        controlType = core.Enums.eControlType.ComboBoxCheckThreeStateBox;
                        if (rQry.ComboAsDropDown)
                        {
                            ComboBoxCheckThreeStateBoxAsDropDown = true;
                            controlType = core.Enums.eControlType.ComboBoxAsDropDown;
                        }
                        multiControl._controlType = controlType;
                    }
                    else if (controlType == core.Enums.eControlType.ComboBox ||
                            controlType == core.Enums.eControlType.ComboBoxNoDb)
                    {
                        if (rQry.ComboAsDropDown)
                        {
                            controlType = core.Enums.eControlType.ComboBoxAsDropDown;
                        }                        
                        multiControl._controlType = controlType;
                    }
                    else
                    {
                        multiControl._controlType = controlType;
                    }

                    multiControl._controlType = controlType;
                    if (hasINConditionTmp &&
                        (multiControl._controlType == core.Enums.eControlType.Textfield || multiControl._controlType == core.Enums.eControlType.TextfieldMulti ||
                            multiControl._controlType == core.Enums.eControlType.Integer || multiControl._controlType == core.Enums.eControlType.Numeric ||
                            multiControl._controlType == core.Enums.eControlType.ComboBox ||
                            multiControl._controlType == core.Enums.eControlType.Date || multiControl._controlType == core.Enums.eControlType.DateTime ||
                            multiControl._controlType == core.Enums.eControlType.Time))
                    {
                        multiControl.hasINCondition = true;
                        multiControl.INCondition = rQry.Condition.Trim();
                        multiControl.controlTypeINCondition = multiControl.OwnControlType;
                        multiControl.OwnControlType = core.Enums.eControlType.Textfield;
                        controlType = multiControl.OwnControlType;
                    }

                    multiControl.OwnFldShort = rQry.QryColumn;
                    multiControl.ownMCCriteria1.initControl();
                    multiControl.setControl(true);
                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    if (controlType == core.Enums.eControlType.ComboBox || 
                        controlType == core.Enums.eControlType.ComboBoxNoDb ||
                        controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                    {
                        if (rQry.IsSQLServerField)
                        {
                            dsAdmin.tblCriteriaRow rCriteria = this.CheckIfCriteria(rQry.QryColumn, rQry.QryTable, IDApplication, IDParticipant, rQry.QryColumn);
                            if (rCriteria != null)
                            {
                                this.loadComboBox(multiControl, rQry, rCriteria, typQueryDef, IDApplication, IDParticipant, ref protocollForAdmin, ref protocolWindow, ComboBoxCheckThreeStateBoxAsDropDown, PrevControlType);
                            }
                            else
                            {
                                string IDApplicationAll = qs2.core.license.doLicense.eApp.ALL.ToString();
                                rCriteria = this.CheckIfCriteria(rQry.QryColumn, rQry.QryTable, IDApplicationAll, IDParticipant, rQry.QryColumn);
                                if (rCriteria != null)
                                {
                                    this.loadComboBox(multiControl, rQry, rCriteria, typQueryDef, IDApplicationAll, IDParticipant, ref protocollForAdmin, ref protocolWindow, ComboBoxCheckThreeStateBoxAsDropDown, PrevControlType);
                                }
                                else
                                {
                                    qs2.core.Enums.eControlType typeInteger = qs2.core.Enums.eControlType.Integer;
                                    multiControl._controlType = typeInteger;
                                    multiControl.setControl(true);
                                }
                            }
                        }
                        else
                        {
                            multiControl.ownMCCriteria1.ownMCCombo1.loadCombo(multiControl, rQry.Label, multiControl.ownMCCriteria1.CombinationComboBoxAsDropDown, ComboBoxCheckThreeStateBoxAsDropDown);
                        }
                    }
                    else if (controlType == core.Enums.eControlType.ComboBox)
                    {
                        
                    }

                    multiControl.Visible = true;
                    if (translateLabel)
                    {
                        if (!string.IsNullOrWhiteSpace(rQry.QryColumn))
                            this.translateLabel(rQry.QryColumn, ref multiControl, IDApplication, IDParticipant, true);
                        
                        if (!string.IsNullOrWhiteSpace(rQry.Label))
                            this.translateLabel(rQry.Label, ref multiControl, IDApplication, IDParticipant, true);  
                    }
                    if (controlType != core.Enums.eControlType.ComboBox &&
                        controlType != core.Enums.eControlType.ComboBoxNoDb)
                    {
                        multiControl.ownMCFormat1.setFormatNoCriteria(multiControl, NumericType);
                    }

                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    {
                        string txtToolTip = qs2.core.language.sqlLanguage.getRes("IsParameter");
                        if (rQry.FunctionPar)
                            txtToolTip += " (" + qs2.core.language.sqlLanguage.getRes("Function") + ")";
                        multiControl.ownMCInfo1.doToolTipxy(multiControl.infragLabelLeft, qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, cont, false, IDApplication, multiControl.OwnFieldForALLProducts);
                    }

                    if (multiControl.hasINCondition)
                    {
                        multiControl.ownMCFormat1.formatInitialized = true;
                        multiControl.panelButtons.Controls.Clear();
                        System.Windows.Forms.Control contMC = multiControl.ownMCUI1.doButtonControls(design.auto.multiControl.ownMCEvents.eTypButtonControl.addSelList, null, "",
                                                                                    qs2.core.language.sqlLanguage.getRes("InputINKlausel"), multiControl);
                    }
                }

                string ValueToSet = rQry.ValueMin;
                if (addAdditionalLabel && subCondition.Trim() != "")
                    ValueToSet = rQry.Max;

                string ValueTxtTmp = "";
                if (subCondition.Trim() == "")
                {
                    ValueTxtTmp = rQry.ValueMin;
                    this.checkForSpecialDefinitionsMinValue(ref rQry, ref ValueTxtTmp, true);
                }
                else
                {
                    ValueTxtTmp = rQry.Max;
                    this.checkForSpecialDefinitionsMaxValue(ref rQry, ref ValueTxtTmp, false);
                }

                if (multiControl.OwnControlType == core.Enums.eControlType.ComboBox ||
                    multiControl.OwnControlType == core.Enums.eControlType.ComboBoxNoDb ||
                    multiControl.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    bool right_QueryReportOthers = true;
                    bool right_QueryReportOwnPlusAssistenz = true;

                    if (right_QueryReportOthers)
                    {
                        multiControl.panelButtons.Controls.Clear();
                        System.Windows.Forms.Control contMC = multiControl.ownMCUI1.doButtonControls(design.auto.multiControl.ownMCEvents.eTypButtonControl.Clear, null, "",
                                                                qs2.core.language.sqlLanguage.getRes("DeleteSelection"), multiControl);

                    }
                    else if (right_QueryReportOwnPlusAssistenz)
                    {
                        multiControl.ownMCUI1.doCheckBoxAdd(multiControl);
                    }
                    else
                    {
                        multiControl.panelButtons.Controls.Clear();
                    }
                }
                else if (multiControl.OwnControlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    multiControl.ownMCCriteria1.ownMCCombo1.loadComboThreeStateCheckBox(multiControl, ControlWasCheckBox, false);
                }

                if (!multiControl.ownMCCriteria1.ownMCCombo1.SelectionComboBoxCanNotCleared)
                {
                    multiControl.ownMCValue1.clearValue(multiControl, true, true);
                }
              
                if (ValueTxtTmp.Trim() != "" && !multiControl.ownMCCriteria1.ownMCCombo1.SelectionComboBoxCanNotCleared)
                {
                    multiControl.ownMCValue1.setValue(multiControl, ValueTxtTmp);
                }
                else
                {
                    
                }
                multiControl.setEditable(editable, false);
                //multiControl.setLabels(false);

                if (multiControl.OwnControlType == core.Enums.eControlType.ComboBox ||
                    multiControl.OwnControlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    multiControl.ownMCTxt1.getSelectedText(multiControl, multiControl.IsInDesignerModus);
                }
                else
                {

                }

                if (multiControl.OwnControlType == core.Enums.eControlType.ComboBox ||
                    multiControl.OwnControlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    
                }
                else
                {

                }

                multiControl.Visible = true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.setMultiControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void clearMCControls(qs2.design.auto.multiControl.ownMultiControl multiControl)
        {
            try
            {
                if (multiControl.ComboBox != null)
                {
                    multiControl.ComboBox.Items.Clear();
                    multiControl.ComboBox.Value = null;
                }
                if (multiControl.DropDown != null)
                {
                    multiControl.DropDown = new Infragistics.Win.Misc.UltraDropDownButton();
                    if (multiControl.ControlForDropDown != null)
                    {
                        multiControl.ControlForDropDown.clearData();
                    }
                }
                if (multiControl.Textfield != null)
                {
                    multiControl.Textfield.Text = "";
                }
                if (multiControl.TextfieldMulti != null)
                {
                    multiControl.TextfieldMulti.Text = "";
                }
                if (multiControl.Numeric != null)
                {
                    multiControl.Numeric.Value = -1;
                }
                if (multiControl.Date != null)
                {
                    multiControl.Date.Value = null;
                }
                if (multiControl.DateTime != null)
                {
                    multiControl.DateTime.Value = null;
                }
                if (multiControl.Time != null)
                {
                    multiControl.Time.Value = null;
                }

                multiControl.OwnFldShort = "";
                multiControl.ownMCCriteria1.Application = "";

            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.clearMCControls:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


        public bool checkIfDateTimeControl(ref qs2.core.vb.dsAdmin.tblQueriesDefRow rQry)
        {
            if (rQry.ControlType.Trim().ToLower().Equals(qs2.core.Enums.eControlType.Date.ToString().Trim().ToLower()) ||
                rQry.ControlType.Trim().ToLower().Equals(qs2.core.Enums.eControlType.DateTime.ToString().Trim().ToLower()) ||
                rQry.ControlType.Trim().ToLower().Equals(qs2.core.Enums.eControlType.Time.ToString().Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void checkForSpecialDefinitionsMinValue(ref qs2.core.vb.dsAdmin.tblQueriesDefRow rQry, ref string ValueToSet, bool IsValueFrom)
        {
            try
            {
                if (rQry.SpecialDefinition.Trim() != "")
                {
                    qs2.core.generic.retValue retValue1 = new qs2.core.generic.retValue();
                    DateTime dNowNoTime = DateTime.Now.Date;
                    DateTime dNowTimeEndOfDay = new DateTime(dNowNoTime.Year, dNowNoTime.Month, dNowNoTime.Day, 23, 59, 59);

                    if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.Today.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dNowNoTime.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.TodayMinus6Months.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = dNowNoTime.AddMonths(-6);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dDateToSet.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.BeginningOfTheYear.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, 1, 1, 0, 0, 0);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dDateToSet.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.BeginningOfTheMonth.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, dNowNoTime.Month, 1, 0, 0, 0);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dDateToSet.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.BeginningOfThePreviousYear.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, 1, 1, 0, 0, 0);
                        dDateToSet = dDateToSet.AddYears(-1);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dDateToSet.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinition.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMinValue.DateToToday30DaysAgo.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = dNowNoTime.AddDays(-30);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.Date, dDateToSet.Date, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.checkForSpecialDefinitionsMinValue:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void checkForSpecialDefinitionsMaxValue(ref qs2.core.vb.dsAdmin.tblQueriesDefRow rQry, ref string ValueToSet, bool IsValueFrom)
        {
            try
            {
                if (rQry.SpecialDefinitionMax.Trim() != "")
                {
                    qs2.core.generic.retValue retValue1 = new qs2.core.generic.retValue();
                    DateTime dNowNoTime = DateTime.Now.Date;
                    DateTime dNowTimeEndOfDay = new DateTime(dNowNoTime.Year, dNowNoTime.Month, dNowNoTime.Day, 23, 59, 59);

                    if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.Today.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dNowTimeEndOfDay, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.EndOfTheYear.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, 12, 31, 23, 59, 59);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dDateToSet, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.EndOfThePreviousYear.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, 12, 31, 23, 59, 59);
                        dDateToSet = dDateToSet.AddYears(-1);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dDateToSet, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.EndOfThePreviousYear.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, 12, 31, 23, 59, 59);
                        dDateToSet = dDateToSet.AddYears(-1);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dDateToSet, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.TodayMinus30Days.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, dNowNoTime.Month, dNowNoTime.Day, 23, 59, 59).AddDays(-30);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dDateToSet, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }
                    else if (rQry.SpecialDefinitionMax.Trim().ToLower().Equals(qs2.core.Enums.eSpecialDefinitionsMaxValue.EndOfThePreviousMonth.ToString().Trim().ToLower()) && this.checkIfDateTimeControl(ref rQry))
                    {
                        DateTime dDateToSet = new DateTime(dNowNoTime.Year, dNowNoTime.Month, DateTime.DaysInMonth(dNowNoTime.Year, dNowNoTime.Month), 23, 59, 59);
                        dDateToSet = dDateToSet.AddMonths(-1);
                        retValue1 = qs2.core.generic.getValue(core.Enums.eControlType.DateTime, dDateToSet, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        ValueToSet = retValue1.valueStr;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.checkForSpecialDefinitionsMaxValue:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateLabel(string Label, ref qs2.design.auto.multiControl.ownMultiControl multiControl, string IDApplication, string IDParticipant, bool CheckLabelForQuery)
        {
            try
            {
                if (!Label.Trim().Equals(""))
                {
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    string idResFound = qs2.core.language.sqlLanguage.getRes(Label.Trim(), core.Enums.eResourceType.Label, IDParticipant, IDApplication, ref  rLangFoundReturn, true, true, core.language.sqlLanguage.eLanguage.NoText, CheckLabelForQuery);
                    if (idResFound.Trim() == "")
                    {
                        multiControl.infragLabelLeft.Text = Label.Trim();
                        multiControl.ownMCTxt1.TextTranslated = multiControl.infragLabelLeft.Text;
                    }
                    else
                    {
                        multiControl.infragLabelLeft.Text = idResFound;
                        multiControl.ownMCTxt1.TextTranslated = multiControl.infragLabelLeft.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.translateLabel:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateAdditionalLabel(string IDResAdditional, ref qs2.design.auto.multiControl.ownMultiControl multiControl, bool CheckLabelForQuery)
        {
            try
            {
                string idResAdditionalFound = qs2.core.language.sqlLanguage.getRes(IDResAdditional.Trim(), true, CheckLabelForQuery);
                if (idResAdditionalFound.Trim() == "")
                    multiControl.infragLabelLeft.Text += " " + IDResAdditional.Trim();
                else
                    multiControl.infragLabelLeft.Text += " " + idResAdditionalFound;
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.translateAdditionalLabel:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public core.Enums.eControlType getControlTypeFromSQLServer(string typeSQLServer, string IDApplication,string IDParticipant, string column, string table,
                                                                    ref dsAdmin.tblCriteriaRow rCriteriaBack)
        {
            try
            {
                core.Enums.eControlType typeRet = new core.Enums.eControlType();
                typeRet = core.Enums.eControlType.Textfield;

                //SelListsTables
                if (typeSQLServer.Equals(qs2.core.dbBase.DBTypeSqlServer.nvarchar.ToString()) || typeSQLServer.Equals(qs2.core.dbBase.DBTypeSqlServer.uniqueidentifier.ToString()))
                {
                    dsAdmin.tblCriteriaRow rCriteria = this.CheckIfCriteria(column, table, IDApplication, IDParticipant, column);
                    if (rCriteria != null)
                    {
                        typeRet = qs2.core.generic.searchEnumControlType(rCriteria.ControlType);
                        rCriteriaBack = rCriteria;
                    }
                    else
                    {
                        rCriteria = this.CheckIfCriteria(column, table, qs2.core.license.doLicense.eApp.ALL.ToString(), IDParticipant, column);
                        if (rCriteria != null)
                        {
                            typeRet = qs2.core.generic.searchEnumControlType(rCriteria.ControlType);
                            rCriteriaBack = rCriteria;
                        }
                        else
                        {
                            typeRet = qs2.core.Enums.eControlType.Textfield;
                        }
                    }
                }
                else if (typeSQLServer.Equals("int"))
                {
                    dsAdmin.tblCriteriaRow rCriteria = this.CheckIfCriteria(column, table, IDApplication, IDParticipant, column);
                    if (rCriteria != null)
                    {
                        typeRet = qs2.core.generic.searchEnumControlType(rCriteria.ControlType);
                        rCriteriaBack = rCriteria;
                    }
                    else
                    {
                        rCriteria = this.CheckIfCriteria(column, table, qs2.core.license.doLicense.eApp.ALL.ToString(), IDParticipant, column);
                        if (rCriteria != null)
                        {
                            typeRet = qs2.core.generic.searchEnumControlType(rCriteria.ControlType);
                            rCriteriaBack = rCriteria;
                        }
                        else
                        {
                            typeRet = qs2.core.Enums.eControlType.Integer;
                        }
                    }
                }
                else if (typeSQLServer.Equals(qs2.core.dbBase.DBTypeSqlServer.bit.ToString()))
                {
                    typeRet = qs2.core.Enums.eControlType.CheckBox;
                }
                else if (typeSQLServer.Equals(qs2.core.dbBase.DBTypeSqlServer.datetime.ToString()))
                {
                    typeRet = qs2.core.Enums.eControlType.DateTime;
                }
                else if (typeSQLServer.Equals("float"))
                {
                    typeRet = qs2.core.Enums.eControlType.Numeric;
                }
                else if (typeSQLServer.Equals("decimal"))
                {
                    typeRet = qs2.core.Enums.eControlType.Numeric;
                }
                else if (typeSQLServer.Equals(qs2.core.dbBase.DBTypeSqlServer.numeric.ToString()))
                {
                    typeRet = qs2.core.Enums.eControlType.Numeric;
                }

                return typeRet;
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.getControlTypeFromSQLServer:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return qs2.core.Enums.eControlType.Textfield;
            }
        }

        public dsAdmin.tblSelListEntriesRow getIDGroup_ColumnsSelListxyxy(string column, string table, string IDApplication, string IDParticipant, string IDGroupToSearch)
        {
            try
            {
                    //dsAdmin ds = new dsAdmin();
                    //sqlAdmin sqlAdmin1 = new sqlAdmin();
                    //sqlAdmin1.initControl();
                    dsAdmin dsAdminGetType = new dsAdmin();
                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    Parameters.doExecptIfNotFound = false;
                    this.sqlAdmin1.getSelListEntrys(ref Parameters, column, IDParticipant, IDApplication, ref dsAdminGetType, sqlAdmin.eTypAuswahlList.column, "", 0, "", 0, column, table);
                    if (dsAdminGetType.tblSelListEntries.Rows.Count > 0)
                    {
                        dsAdmin.tblSelListEntriesRow rSelListEntry = (dsAdmin.tblSelListEntriesRow)dsAdminGetType.tblSelListEntries.Rows[0];
                        return rSelListEntry;
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.getIDGroup_ColumnsSelList:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }
        public dsAdmin.tblSelListGroupRow CheckIfIDGroup(string column, string table, 
                                                            string IDApplication, string IDParticipant, 
                                                            string IDGroupToSearch)
        {
            try
            {
                dsAdmin dsAdminGetType = new dsAdmin();
                dsAdmin.tblSelListGroupRow rSelListGroupRow = this.sqlAdmin1.getSelListGroupRow(column, IDParticipant, IDApplication);
                return rSelListGroupRow;
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.CheckIfIDGroup:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }
        public qs2.core.vb.dsAdmin.tblCriteriaRow CheckIfCriteria(string column, string table,
                                                    string IDApplication, string IDParticipant,
                                                    string FldShort)
        {
            try
            {
                string IDApplicationTmp;
                qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteria = null;
                qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = null;
                dsAdmin dsAdminToCheck = new dsAdmin();

                IDApplicationTmp = IDApplication;
                arrCriteria = this.sqlAdmin1.getCriterias(dsAdminToCheck, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, IDApplicationTmp, false, false, false, "", "", false);
                if (arrCriteria.Length == 1)
                {
                    rCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteria[0];
                    return rCriteria;
                }
                else if (arrCriteria.Length == 0)
                {
                    IDApplicationTmp = core.license.doLicense.eApp.ALL.ToString();
                    arrCriteria = this.sqlAdmin1.getCriterias(dsAdminToCheck, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, IDApplicationTmp, false, false, false, "", "", false);
                    if (arrCriteria.Length == 1)
                    {
                        rCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteria[0];
                        return rCriteria;
                    }
                    else if (arrCriteria.Length == 0)
                    {
                        return null;
                    }
                    else if (arrCriteria.Length > 1)
                    {
                        throw new Exception("drawMulticontrol.CheckIfCriteria: arrCriteria.Length > 1 for FldShort '" + FldShort + "' and IDApplication '" + IDApplicationTmp + "' !");
                        //return null;
                    }
                }
                else if (arrCriteria.Length > 1)
                {
                    throw new Exception("drawMulticontrol.CheckIfCriteria: arrCriteria.Length > 1 for FldShort '" + FldShort + "' and IDApplication '" + IDApplicationTmp + "' !");
                    //return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.CheckIfCriteria:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }

        public bool loadComboBox(qs2.design.auto.multiControl.ownMultiControl multiControl, qs2.core.vb.dsAdmin.tblQueriesDefRow rQry,
                                    dsAdmin.tblCriteriaRow rCriteria, qs2.core.Enums.eTypQueryDef typQueryDef,
                                    string IDApplication, string IDParticipant,
                                    ref string protocollForAdmin, ref bool protocolWindow, bool ComboBoxCheckThreeStateBoxAsDropDown,
                                    core.Enums.eControlType PrevControlType)
        {
            try
            {
                string IDGroupToLoad = rCriteria.FldShort.Trim();
                if (rCriteria.AliasFldShort.Trim() != "")
                {
                    IDGroupToLoad = rCriteria.AliasFldShort.Trim(); 
                }
                if (ComboBoxCheckThreeStateBoxAsDropDown)
                {
                    IDGroupToLoad = "ComboBoxCheckThreeStateBox";
                }

                bool bCriteriaForAllproducts = false;
                if (rCriteria.IDApplication.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()))
                {
                    bCriteriaForAllproducts = true;
                }

                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                multiControl.ownMCCriteria1.CombinationComboBoxAsDropDown = rQry.ComboAsDropDownCondition.Trim();

                dsAdmin.tblSelListGroupRow rGroup = this.sqlAdmin1.getSelListGroupRow_ParticAppl(ref Parameters, IDGroupToLoad, IDParticipant, IDApplication, false);
                core.Enums.eControlType ControlTypeToLoad = core.Enums.eControlType.ComboBox;
                if (rQry.ComboAsDropDown)
                {
                    ControlTypeToLoad = core.Enums.eControlType.ComboBoxAsDropDown;
                }
                if (rGroup != null)
                {
                    bool ProtocollWindow = false;
                    multiControl.ownMCCriteria1.initControl();
                    multiControl.ownMCCriteria1.Application = IDApplication;
                    multiControl.ownMCCriteria1.ownMCCombo1.PrevControlType = PrevControlType;
                    multiControl.OwnFieldForALLProducts = false;
                    multiControl.ownMCCriteria1.getData((System.Windows.Forms.Control)multiControl, rCriteria.FldShort.Trim(), ControlTypeToLoad, multiControl.ComboBox,
                                                        ref multiControl.ownMCUI1, null, ref protocollForAdmin, ref ProtocollWindow, bCriteriaForAllproducts, false, ComboBoxCheckThreeStateBoxAsDropDown);
                    return true;
                }
                else
                {
                    Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    rGroup = this.sqlAdmin1.getSelListGroupRow_ParticAppl(ref Parameters, IDGroupToLoad, IDParticipant, qs2.core.license.doLicense.eApp.ALL.ToString(), false);
                    if (rGroup != null)
                    {
                        bool ProtocollWindow = false;
                        multiControl.ownMCCriteria1.initControl();
                        multiControl.ownMCCriteria1.Application = IDApplication;
                        multiControl.ownMCCriteria1.ownMCCombo1.PrevControlType = PrevControlType;
                        multiControl.OwnFieldForALLProducts = true;
                        multiControl.ownMCCriteria1.getData((System.Windows.Forms.Control)multiControl, rCriteria.FldShort.Trim(), ControlTypeToLoad, multiControl.ComboBox,
                                                            ref multiControl.ownMCUI1, null, ref protocollForAdmin, ref ProtocollWindow, bCriteriaForAllproducts, false, ComboBoxCheckThreeStateBoxAsDropDown);
                        //multiControl.ownMCCriteria1.ownMCCombo1.initCombo(multiControl);
                        //multiControl.ownMCCriteria1.ownMCCombo1.loadCombo(multiControl, "", multiControl.ownMCCriteria1.CombinationComboBoxAsDropDown);
                        //multiControl.ownMCCriteria1.ownMCCombo1.loadComboSelList(multiControl, rGroup.IDGroupStr, rGroup, false);

                        return true;
                    }
                    else
                    {
                        if (rQry.QryColumn.Trim().ToLower().Equals(("Surgeon").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Surg_Assist1").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Surg_Assist2").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Surg_Partim").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Surg_Reop").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Surg_Assumption").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Perfusionist").Trim().ToLower()) ||
                            rQry.QryColumn.Trim().ToLower().Equals(("Perfusionist_Assist1").Trim().ToLower()))
                        {
                            bool ProtocollWindow = false;
                            multiControl.ownMCCriteria1.initControl();
                            multiControl.ownMCCriteria1.ownMCCombo1.PrevControlType = PrevControlType;
                            multiControl.ownMCCriteria1.ownMCCombo1.TypeComboBox = qs2.core.Enums.cVariablesValues.Roles;
                            multiControl.ownMCCriteria1.getData((System.Windows.Forms.Control)multiControl, rCriteria.FldShort.Trim(), multiControl.OwnControlType, multiControl.ComboBox,
                                                                ref multiControl.ownMCUI1, null, ref protocollForAdmin, ref ProtocollWindow, bCriteriaForAllproducts, false, ComboBoxCheckThreeStateBoxAsDropDown);
                            //multiControl.ownMCCriteria1.ownMCCombo1.initCombo(multiControl);
                            ////multiControl.ownMCCriteria1.ownMCCombo1.initCombo(multiControl);
                            //multiControl.ownMCCriteria1.ownMCCombo1.loadCombo(multiControl, "");
                            //multiControl.ownMCCriteria1.ownMCCombo1.loadComboSelList(multiControl, rGroup.IDGroupStr, rGroup, false);
                            return true; 
                        }
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("drawMulticontrol.loadComboBox:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


    }
}
