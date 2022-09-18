using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using qs2.core;

namespace qs2.design.auto.multiControl
{


    public class ownMCEvents
    {

        public event EventHandler valueChanged;
        public event EventHandler ownClickButton;
        public bool valueDateTimeIsChanging = false;

        public qs2.design.auto.multiControl.ownMultiControl ownControl1 = null;
        public static qs2.design.auto.multiControl.ownMultiControl LastMCDateTimeFocused = null;

        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();

        public event System.Data.DataColumnChangeEventHandler evDataColumnChanged;

        public event doPicture evDoPicture;
        public qs2.core.vb.dsAdmin dsEventsRegistered = null;
        public delegate void doPicture(qs2.design.auto.multiControl.ownMultiControl ownMultiControlCalled);

        public bool lockFocus = false;

        public static bool lockValueChanged = false;

        public static System.Collections.Generic.List<core.ui.cHelpData> lLastMCFocused5 { get; set; } = new List<core.ui.cHelpData>();











        public enum eTypButtonControl
        {
            Help = 0,
            addSelList = 1,
            Search = 2,
            Clear = 3,
            CheckBox = 4
        }

        public void ThreeStateCheckBoxAfterCheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //this.ownControl1.ownControlDataBind1.setRowValue(this.ownControl1, this.ownControl1.ThreeStateCheckBox.OwnCheckStateInt);
                this.ControlValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ThreeStateCheckBoxAfterCheckStateChanged", tempFldShort, false, true,
                                            tempIDApplication, qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void ControlValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lockFocus)
                {
                    return;
                }

                Control cont = (Control)sender;
                try
                {
                    //cont.Cursor = Cursors.WaitCursor;
                    if (cont.Focused)
                    {
                        //if (this.ownControl1._isEnabled)
                        //{
                        this.ControlValueChangedDo(sender, e);
                        //}
                        //else
                        //{
                        //}
                    }
                }
                catch (Exception ex)
                {
                    string tempFldShort = "";
                    string tempIDApplication = "";
                    if (this.ownControl1 != null)
                    {
                        tempFldShort = this.ownControl1._FldShort;
                        tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                    }
                    qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlValueChanged", tempFldShort, false, true, tempIDApplication,
                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                }
                finally
                {
                    //cont.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlValueChanged", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void ControlValueChangedDo(object sender, EventArgs e)
        {
            Control cont = (Control)sender;

            if (ownMCEvents.lockValueChanged)
            {
                return;
            }

            this.doValueChanged(cont);
            
            this.runPictures();
            this.ownControl1.ownMCTxt1.getSelectedText(this.ownControl1, this.ownControl1.IsInDesignerModus);
            if (this.ownControl1.IsEvaluation)
            {
                qs2.design.auto.print.doRelationshipEvaluation doRelationshipEvaluation1 = new print.doRelationshipEvaluation();
                doRelationshipEvaluation1.run(ownControl1.OwnFldShort.Trim(), ref this.ownControl1, null, null);
            }

            if (this.valueChanged != null)
                this.valueChanged(this.ownControl1, e);

            if (this.ownControl1.MCValueChanged != null)
                this.ownControl1.MCValueChanged.Invoke();

        }
        public void runPictures()
        {
            try
            {
                if (this.evDoPicture != null)
                    this.evDoPicture.Invoke(this.ownControl1);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.runPictures", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public void doValueChanged(Control cont)
        {
            try
            {
                if (this.lockFocus)
                {
                    return;
                }

                if (this.ownControl1.IsEvaluation)
                {
                    //qs2.design.auto.print.doRelationshipEvaluation doRelationshipEvaluation1 = new print.doRelationshipEvaluation();
                    //doRelationshipEvaluation1.run(ownControl1.OwnFldShort.Trim(), ref this.ownControl1);
                }
                else
                {
                    if (this.ownControl1.ownMCCriteria1.rCriteria != null && this.ownControl1.ownMCDataBind1.TypeBinding != ownMCDataBind.dTypeBinding.noBinding)
                    {
                        if (!ownControl1.ownMCDataBind1.isDoingWriteValueFromControlToBindingRow)
                        {
                            //setBindingContext   lthxy
                            qs2.core.generic.retValue retValueBevorChange = this.ownControl1.ownMCDataBind1.getValueFromRow(this.ownControl1);
                            if (ownControl1._controlType != core.Enums.eControlType.DateTime &&
                                    ownControl1._controlType != core.Enums.eControlType.Date &&
                                     ownControl1._controlType != core.Enums.eControlType.Time &&
                                    ownControl1._controlType != core.Enums.eControlType.Time)
                            {
                                this.ownControl1.ownMCDataBind1.writeValueFromControlToBindingRow(this.ownControl1);
                            }
                            //if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox &&
                            //     ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox)
                            //{
                            //    int iValue = ownControl1.ThreeStateCheckBox.OwnCheckStateInt;
                            //    this.ownControl1.ownMCDataBind1.setRowValue(this.ownControl1, iValue, false);
                            //    this.ownControl1.ownMCDataBind1.writeValueFromControlToBindingRow(this.ownControl1);
                            //}

                            qs2.core.generic.retValue retValueAfterChange = this.ownControl1.ownMCDataBind1.getValueFromRow(this.ownControl1);
                            this.ownControl1.doRelationsship(true, true, 0, ownMCRelationship.eTypAssignments.MCParent, this.ownControl1.rAutoUI.Chapter, false);
                        }

                        if (this.ownControl1.ownMCUI1.lstColors != null && this.ownControl1.ownMCUI1.lstColors.Count > 0)
                        {
                            this.ownControl1.ownMCUI1.setColorsFromClassification(this.ownControl1);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.doValueChanged", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void ControlLeaveDateTime(object sender, EventArgs e)
        {
            try
            {
                Control cont = (Control)sender;
                try
                {
                    //cont.Cursor = Cursors.WaitCursor;
                    
                    if (this.ownControl1.ownMCCriteria1.rCriteria != null && this.ownControl1.ownMCDataBind1.TypeBinding != ownMCDataBind.dTypeBinding.noBinding)
                    {
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor infragDateTime = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)sender;

                        if ((this.ownControl1.OwnFldShort.Trim().ToLower().Equals(("SurgDtStart").Trim().ToLower()) ||
                            this.ownControl1.OwnFldShort.Trim().ToLower().Equals(("SurgDtEnd").Trim().ToLower())) && this.ownControl1.Date != null)
                        {
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                            System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                            qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(this.ownControl1.OwnFldShort.Trim(), this.ownControl1.ownMCCriteria1.Application.Trim(),
                                                                                        ref this.ownControl1.parentAutoUI, "",
                                                                                        ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn, true);
                            bool valueMultiControlOK = false;
                            if (lstOwnMultiControl1.Count > 0)
                            {
                                foreach (qs2.design.auto.multiControl.ownMultiControl ownControlFound in lstOwnMultiControl1)
                                {
                                    if (ownControlFound.Time != null)
                                    {
                                        this.ownControl1.ownMCDataBind1.BindControlDateTimeNew(ownControlFound, infragDateTime);
                                    }
                                }
                            }
                        }

                        this.ownControl1.ownMCDataBind1.BindControlDateTimeNew(this.ownControl1, infragDateTime);
                        this.ControlValueChanged(sender, e);
                        ownMCEvents.LastMCDateTimeFocused = null;
                    }

                    this.ownControl1.ownMCTxt1.getSelectedText(this.ownControl1, this.ownControl1.IsInDesignerModus);

                    if (this.valueChanged != null)
                        this.valueChanged(this.ownControl1, e);
                }
                catch (Exception ex)
                {
                    qs2.core.generic.getExep(ex.ToString(), ex.Message);
                    //cont.Cursor = Cursors.Default;
                }
                finally
                {
                    //cont.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlLeaveDateTime", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void ControlLeave(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            try
            {
                //cont.FindForm().Cursor = Cursors.WaitCursor;
                string sMessage = "";
                if (!ownControl1.IsEvaluation)
                {
                    ownControl1.ownMCDataBind1.setRowAndMC(ref ownControl1, ownMCDataBind.eTypeSetDataAndMC.SurgDtEnd, false);
                    if (!ownControl1.ownMCFormat1.checkInput(this.ownControl1, ref sMessage, true))
                    {

                        //return;
                    }
                    if (!ownControl1.checkValueComboBox(true))
                    {
                        return;
                    }
                }
                else
                {
                    if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                      ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb ||
                      ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                    {
                        if (!ownControl1.checkValueComboBox(true))
                        {
                            return;
                        }
                    }
                }

                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                ownControl1.ownMCTxt1.doFocus(ownControl1, false);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlLeave", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                //cont.FindForm().Cursor = Cursors.Default;
            }
        }

        public void ControlBeforeCheckStateChanged(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Control cont = (Control)sender;
            try
            {
                //cont.Cursor = Cursors.WaitCursor;
                if (cont.Focused)
                {
                    if (!this.ownControl1._isEnabled)
                        e.Cancel = true;
                    else
                    {
                        //string xy = "";
                    }
                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlBeforeCheckStateChanged", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                //cont.Cursor = Cursors.Default;
            }
        }
        public void ControlEnter(object sender, EventArgs e)
        {
            try
            {
                if (this.lockFocus)
                {
                    return;
                }

                if (this.ownControl1._control.Focused)
                {
                    qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();

                    ownControl1.doActionControl(ownMultiControl.eTypActionControl.selectAll, ref calculatedFormatTmp, false);
                    ownControl1.ownMCTxt1.doFocus(ownControl1, true);
                    this.ownControl1.doActionControl(ownMultiControl.eTypActionControl.SetFocus, ref calculatedFormatTmp, false);
                    ownControl1.ownMCDataBind1.setRowAndMC(ref ownControl1, ownMCDataBind.eTypeSetDataAndMC.SurgDtEnd, true);

                    if (ownControl1.OwnControlType == core.Enums.eControlType.Date ||
                        ownControl1.OwnControlType == core.Enums.eControlType.DateTime ||
                        ownControl1.OwnControlType == core.Enums.eControlType.Time)
                    {
                        ownMCEvents.LastMCDateTimeFocused = ownControl1;
                    }

                    ownControl1.doActionControl(ownMultiControl.eTypActionControl.NoticeValueBeforeChangedFromUser, ref calculatedFormatTmp, false);

                    //if (ownControl1.OwnFldShort.Trim().ToLower().Equals(("SurgDtStart").Trim().ToLower()) ||
                    //    ownControl1.OwnFldShort.Trim().ToLower().Equals(("SurgDtEnd").Trim().ToLower()))
                    //{
                    //    if (ownControl1.DateTime.Value != null)
                    //    {
                    //        DateTime SurgDtTmp = ownControl1.DateTime.DateTime;
                    //        if (SurgDtTmp.Hour == 0 && SurgDtTmp.Minute == 0 && SurgDtTmp.Second == 0)
                    //        {
                    //            ownControl1.DateTime.SelectionStart = 0;
                    //            ownControl1.DateTime.SelectionLength = 10;
                    //        }
                    //        if (SurgDtTmp.Year != 0 && SurgDtTmp.Month != 0 && SurgDtTmp.Day != 0)
                    //        {
                    //            ownControl1.DateTime.SelectionStart = 0;
                    //            ownControl1.DateTime.SelectionLength = 10;
                    //        }

                    //    }
                    //}

                    //qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                    //ownControl1.ownMCTxt1.doFocus(ownControl1, true);
                    //qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.Chapter;
                    //bool ProtocolWindow = true;
                    //System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                    //ownControl1.parentAutoUI.doAutoControls.doControlChapters("", workflowAssist.autoForm.doAutoControls.eTypActivityControl.ClearFocus, false, "", ownControl1.ownMCCriteria1.Application,
                    //                                                    ref ownControl1.ownMCCriteria1.IDParticipant, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck, 
                    //                                                    ref ownControl1.parentAutoUI.contAutoProtokoll1, ref ownControl1.parentAutoUI.dsAdmin1, 
                    //                                                    ref ownControl1.parentAutoUI.autoUI1, 
                    //                                                    ref ownControl1.parentAutoUI.dataStay, 
                    //                                                    ref ownControl1.parentAutoUI.autoPrint, false);  
                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlEnter", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void GotFocus(object sender, EventArgs e)
        {
            try
            {
                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();

                ownControl1.doActionControl(ownMultiControl.eTypActionControl.selectAll, ref calculatedFormatTmp, false);
                ownControl1.ownMCTxt1.doFocus(ownControl1, true);
                ownControl1.ownMCDataBind1.setRowAndMC(ref ownControl1, ownMCDataBind.eTypeSetDataAndMC.SurgDtEnd, true);

                //qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                //ownControl1.ownMCTxt1.doFocus(ownControl1, true);
                //qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.Chapter;
                //bool ProtocolWindow = true;
                //System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                //ownControl1.parentAutoUI.doAutoControls.doControlChapters("", workflowAssist.autoForm.doAutoControls.eTypActivityControl.ClearFocus, false, "", ownControl1.ownMCCriteria1.Application,
                //                                                    ref ownControl1.ownMCCriteria1.IDParticipant, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck, 
                //                                                    ref ownControl1.parentAutoUI.contAutoProtokoll1, ref ownControl1.parentAutoUI.dsAdmin1, 
                //                                                    ref ownControl1.parentAutoUI.autoUI1, 
                //                                                    ref ownControl1.parentAutoUI.dataStay, 
                //                                                    ref ownControl1.parentAutoUI.autoPrint, false);  

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.GotFocus", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void MouseHover(object sender, EventArgs e)
        {
            try
            {
                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                ownControl1.ownMCTxt1.doFocus(ownControl1, true);
                if (!this.ownControl1.IsEvaluation)
                    this.CheckMouseHoverLeaveContr(sender, e, true, this.ownControl1.OwnFldShort, this.ownControl1.ownMCCriteria1.Application, false);

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.MouseHover", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void CheckMouseHoverLeaveContr(object sender, EventArgs e, bool enter, string fldshort, string app, bool IsProChapterButton)
        {
            try
            {
                if (sender is Infragistics.Win.UltraWinEditors.UltraComboEditor || sender is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                    sender is Infragistics.Win.UltraWinEditors.UltraCheckEditor || sender is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ||
                    sender is Infragistics.Win.UltraWinEditors.UltraNumericEditor || sender is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                    sender is Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor || sender is sitemap.ownControls.inherit_Infrag.InfragCheckBox ||
                    sender is Infragistics.Win.Misc.UltraDropDownButton || sender is Infragistics.Win.Misc.UltraLabel ||
                    sender is Infragistics.Win.Misc.UltraPanel || sender is Infragistics.Win.Misc.UltraButton)
                {
                    if (IsProChapterButton || (this.ownControl1.parentAutoUI != null && this.ownControl1.parentAutoUI.IsInitialized))
                    {
                        if (enter)
                        {
                            var rRes = (from r in qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen
                                        where r.IDRes == fldshort && r.IDApplication == app && r.Type == "Help" && r.IDLanguageUser == "ALL" && r.IDParticipant == "ALL"
                                        select new { r.IDRes, r.German, r.English }).FirstOrDefault();
                            if (sender is Infragistics.Win.Misc.UltraLabel)
                            {
                                if (rRes != null)
                                    ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                                else
                                    ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                            }

                            //qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.Clear();
                            //qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.Add(new core.ui.cHelpData() { FldHort = fldshort, IDApplication = app, HasRes = (rRes != null ? true : false) });

                            var rLastSelected = (from l in qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5
                                                 where l.IDApplication == app
                                                 select new { l.FldHort, l.IDApplication }).FirstOrDefault();
                            if (rLastSelected == null)
                            {
                                qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.Add(new core.ui.cHelpData() { FldHort = fldshort, IDApplication = app, HasRes = (rRes != null ? true : false) });
                            }
                            else
                            {
                                qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.First().FldHort = fldshort;
                                qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.First().HasRes = (rRes != null ? true : false);
                            }
                        }
                        else
                        {
                            if (sender is Infragistics.Win.Misc.UltraLabel)
                            {
                                ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                            }
                            
                            var rLastSelected = (from l in qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5
                                                 where l.IDApplication == app
                                                 select new { l.IDApplication }).FirstOrDefault();
                            if (rLastSelected != null)
                            {
                                qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.Clear();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.CheckMouseHoverLeaveContr", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.ownControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                    this.ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    this.ownControl1.ComboBox.SelectAll();
                    this.ownControl1.ComboBox.DropDown();
                }

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.MouseDown", tempFldShort, false, true, tempIDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        
        public void LostFocus(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            try
            {
                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                ownControl1.ownMCTxt1.doFocus(ownControl1, false);
                if (!this.ownControl1.IsEvaluation)
                    this.CheckMouseHoverLeaveContr(sender, e, false, this.ownControl1.OwnFldShort, this.ownControl1.ownMCCriteria1.Application, false);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ControlLeave", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                //cont.FindForm().Cursor = Cursors.Default;
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            Control cont = (Control)sender;
            try
            {
                //if (ownControl1.OwnFldShort.Trim().ToLower().Equals(("Surgeon").Trim().ToLower()))
                //{
                //    string xy = "";
                //}

                if (e.KeyCode == Keys.Delete)
                {
                    //this.lockFocus = true;
                    //ownControl1.ownMCTxt1.doFocus(ownControl1, false);
                    if (ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.Roles)
                    {
                        ////ownControl1.ownMCValue1.clearValue(ownControl1, true);
                        //ownControl1.ComboBox.Text = "";
                        //ownControl1.ComboBox.Value = -1;
                        //ownControl1.ownMCDataBind1.setRowValue(ownControl1, -1, true);
                    }
                    else
                    {
                        //string xy = "";
                    }
                }

            }
            catch (Exception ex)
            {
                this.lockFocus = false;
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.KeyPress", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                this.lockFocus = false;
                //cont.FindForm().Cursor = Cursors.Default;
            }
        }
        public void KeyPress(object sender, KeyPressEventArgs e)
        {
            Control cont = (Control)sender;
            try
            {
                //if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                //{
                    //qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)cont;
                    if (this.ownControl1.OwnControlType == core.Enums.eControlType.Textfield || this.ownControl1.OwnControlType == core.Enums.eControlType.TextfieldMulti)
                    {
                        //Prüfen, ob Text 
                        if (e.KeyChar == System.Convert.ToChar("'"))
                        {
                            e.Handled = true;
                        }

                        //if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                        //{
                        //    //ownControl1.ownMCTxt1.doFocus(ownControl1, false);
                        //    //if (ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.Roles)
                        //    //{
                        //    //    string xy = "";
                        //    //}
                        //}
                    }
                //}
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.KeyPress", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                //cont.FindForm().Cursor = Cursors.Default;
            }
        }

        public void popupContainer_Opened(object sender, System.EventArgs e)
        {
            try
            {
                //Control cont = (Control)sender;
                //UltraPopupControlContainer PopupControlContainer = (UltraPopupControlContainer)sender;

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.popupContainer_Opened", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void CheckedChanged(object sender, EventArgs e)
        {

        }
        public void doOwnClickButton(object sender, EventArgs e)
        {
            try
            {
                if (this.ownClickButton != null)
                    this.ownClickButton(this, e);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.doOwnClickButton", tempFldShort, false, true, tempIDApplication,
                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Infragistics.Win.Misc.UltraButton button = (Infragistics.Win.Misc.UltraButton)sender;

                if (this.ownControl1.hasINCondition && button.Name == eTypButtonControl.addSelList.ToString())
                {
                    qs2.design.auto.print.frmInputText frmInputText1 = new print.frmInputText();
                    frmInputText1.initControl();
                    frmInputText1.loadData(this.ownControl1.Textfield.Text.Trim(), this.ownControl1.controlTypeINCondition);
                    frmInputText1.ShowDialog();
                    if (!frmInputText1.abort)
                    {
                        string sTxtInputedUser = frmInputText1.txtText.Text.Trim();
                        string sSeparator = "";
                        string sINKlausel = "";
                        if (this.ownControl1.controlTypeINCondition == core.Enums.eControlType.Textfield || this.ownControl1.controlTypeINCondition == core.Enums.eControlType.TextfieldMulti ||
                            this.ownControl1.controlTypeINCondition == core.Enums.eControlType.DateTime || this.ownControl1.controlTypeINCondition == core.Enums.eControlType.Date ||
                            this.ownControl1.controlTypeINCondition == core.Enums.eControlType.Time)
                        {
                            sSeparator = "'";
                        }
                        else if (this.ownControl1.controlTypeINCondition == core.Enums.eControlType.Integer || this.ownControl1.controlTypeINCondition == core.Enums.eControlType.Numeric ||
                                this.ownControl1.controlTypeINCondition == core.Enums.eControlType.ComboBox)
                        {
                            sSeparator = "";
                        }
                        else
                        {
                            throw new Exception("ButtonClick: this.ownControl1.controlTypeINCondition '" + this.ownControl1.controlTypeINCondition.ToString() + "' not allowed!");
                        }

                        string[] lines = sTxtInputedUser.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        if (lines.Length > 0)
                        {
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].Trim() != "")
                                {
                                    string Signed = "";
                                    if (i < (lines.Count() - 1))
                                    {
                                        Signed = ",";
                                    }
                                    sINKlausel += sSeparator.Trim() + lines[i].Trim() + sSeparator.Trim() + Signed;
                                }
                            }
                            if (sINKlausel.Trim() != "")
                            {
                                sINKlausel = "(" + sINKlausel + ")";
                            }
                        }

                        this.ownControl1.Textfield.Text = sINKlausel.Trim();
                        EventArgs ev = new EventArgs();
                        this.ownControl1.ownMCEvents1.ControlValueChangedDo(this.ownControl1, ev);
                    }
                }
                else
                {
                    if (button.Name == eTypButtonControl.Help.ToString())
                    {
                        this.Info(sender, e);
                    }
                    else if (button.Name == eTypButtonControl.addSelList.ToString())
                    {
                        string IDGroupStrToCall = (this.ownControl1.ownMCCriteria1.rCriteria.AliasFldShort.Trim() == "" ? this.ownControl1.ownMCCriteria1.rCriteria.FldShort : this.ownControl1.ownMCCriteria1.rCriteria.AliasFldShort);
                        if (this.ownControl1.ownMCInfo1.showInfoSelList(this.ownControl1, IDGroupStrToCall, this.ownControl1.ownMCCriteria1.Application, this.ownControl1.ownMCCriteria1.IDParticipant, true, this.ownControl1, this.ownControl1.OwnFieldForALLProducts, false, true)) 
                        {
                            ownMCCriteria.sqlAdminWork.ReloadSelListEntriesGrp(IDGroupStrToCall.Trim(), this.ownControl1.ownMCCriteria1.Application.Trim(), this.ownControl1.ownMCCriteria1.IDParticipant.Trim());

                            qs2.core.generic.retValue retValue1 = this.ownControl1.ownMCDataBind1.getValueFromRow(this.ownControl1);
                            this.ownControl1.ownMCCriteria1.ownMCCombo1.loadCombo(this.ownControl1, "", this.ownControl1.ownMCCriteria1.CombinationComboBoxAsDropDown, this.ownControl1.ownMCCriteria1.ownMCCombo1._ComboBoxCheckThreeStateBoxAsDropDown);
                            this.ownControl1.ownMCDataBind1.setRowValue(this.ownControl1, retValue1.valueObj, true);
                        }
                    }
                    else if (button.Name == eTypButtonControl.Clear.ToString())
                    {
                        if (this.ownControl1.IsEvaluation &&
                            (this.ownControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                            this.ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb))
                        {
                            this.ownControl1.ComboBox.Value = null;
                            this.ownControl1.ownMCEvents1.ControlValueChangedDo(sender, e);
                        }
                        else
                        {
                            this.clear(true);
                        }
                    }
                    else if (button.Name == eTypButtonControl.Search.ToString())
                    {

                    }

                    this.ownControl1.ownMCEvents1.doOwnClickButton(sender, e);
                }

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.ButtonClick", tempFldShort, false, true, tempIDApplication,
                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void Info(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripDropDownItem Itm = (System.Windows.Forms.ToolStripDropDownItem)sender;
            qs2.core.language.dsLanguage.RessourcenRow rRessource = (qs2.core.language.dsLanguage.RessourcenRow)Itm.Tag;
            string pictureToOpen = this.funct1.saveFileFromBytes(qs2.core.ENV.path_temp, qs2.core.language.sqlLanguage.getRes("HelpForField") + " " + this.ownControl1._FldShort, rRessource.fileType, rRessource.fileBytes);
            this.funct1.openFile(pictureToOpen, rRessource.fileType, false);
        }
        public void clear(bool AllToNull)
        {
            this.ownControl1.ownMCValue1.clearValue(this.ownControl1, AllToNull, true);
            object sendControl = new object();
            sendControl = this;
            EventArgs evArg = new EventArgs();

            Control cont = (Control)this.ownControl1;
            this.ownControl1.ownMCEvents1.ControlValueChangedDo(cont, evArg);
        }

        public void registerRowColumnChangedxyxyxy(bool register, qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                if (register)
                    this.evDataColumnChanged += new System.Data.DataColumnChangeEventHandler(ownMultiControl1.ownMCEvents1.RowColumnChangedxy);
                else
                    this.evDataColumnChanged -= new System.Data.DataColumnChangeEventHandler(ownMultiControl1.ownMCEvents1.RowColumnChangedxy);
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.registerRowColumnChangedxyxy", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void RowColumnChangedxy(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            //if (!this.ownControl1.parentAutoUI.dataStay.doEventRowColumnChanged) return;

            try
            {
                if (this.ownControl1.ownMCCriteria1.rCriteria != null)
                {
                    if (ownControl1.ownMCUI1.controlIsDbDataControl(ownControl1))
                    {

                        if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                            ownControl1._controlType == core.Enums.eControlType.Date ||
                            ownControl1._controlType == core.Enums.eControlType.Time)
                        {
                            ownControl1.ownMCDataBind1.BindControlToData(ownControl1, false, ownControl1.parentAutoUI.dataStay, true);
                        }
                        else
                        {
                            ownControl1.ownMCDataBind1.readValueFromBindingRowToControl(this.ownControl1, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownControl1 != null)
                {
                    tempFldShort = this.ownControl1._FldShort;
                    tempIDApplication = this.ownControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCEvents.RowColumnChangedxy", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

    }

}
