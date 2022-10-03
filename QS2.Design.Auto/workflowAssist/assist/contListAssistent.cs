using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using qs2.sitemap.workflowAssist.form;
using qs2.core.vb;
using S2Extensions;

namespace qs2.sitemap.workflowAssist
{


    public partial class contListAssistent : UserControl
    {

        public license license1;
        public qs2.sitemap.ui ui1 = new qs2.sitemap.ui();
        public string IDRessourceTitle = "ProcedureGroups";

        public int distanceProcGrp = 7;
        public int distanceChapters = 2;

        public bool multiselectionJN = false;
        public bool ButtonOKVisible = true;
        public contListAssistent assistentChapters;

        public qs2.core.Enums.eTypList TypList;
        public bool _ShowAllStayTypes = false;
        
        public ImageList ImgListEnabled = new ImageList();
        public ImageList ImgListDisabled = new ImageList();
        public ImageList ImgListMouseOver = new ImageList();

        public qs2.core.vb.businessFramework b = new qs2.core.vb.businessFramework();
        public bool RightChaptersIsDone = false;
        
        public qs2.design.auto.workflowAssist.autoForm.autoLoadControls autoLoadControls1 = new design.auto.workflowAssist.autoForm.autoLoadControls();

        public bool IsInitialized = false;
        public bool IsInitialized2 = false;

        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public contListAssistent()
        {
            InitializeComponent();
        }


        public void buildList(qs2.core.Enums.eTypList TypList,  bool clearDB,
                              string Application, string Participant, bool showAllStayTypes)
        {
            try
            {
                if (IsInitialized)
                    return;

                this.TypList = TypList;
                System.Drawing.Size sizeButton = new System.Drawing.Size(qs2.core.ENV.ButtProcGrpImageSizeWidth, qs2.core.ENV.ButtProcGrpImageSizeHeigth);
                this.ImgListEnabled.ImageSize = sizeButton;
                this.ImgListDisabled.ImageSize = sizeButton;
                this.ImgListMouseOver.ImageSize = sizeButton;

                if (TypList == core.Enums.eTypList.PROCGRP)
                {
                    ColorSchemas1.setAppearanceTab(this.ultraTabControlList, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUIStayTab.ProcGrp, false);
                    ColorSchemas1.setAppearancePanel(this.panelButtons, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUIPanel.PanelStayProcGrp, false);
                }
                else if (TypList == core.Enums.eTypList.CHAPTERS)
                {
                    ColorSchemas1.setAppearanceTab(this.ultraTabControlList, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUIStayTab.Chapters, false);
                    ColorSchemas1.setAppearancePanel(this.panelButtons, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUIPanel.PanelStayChapter, false);
                }

                if (clearDB)
                {
                    this.panelButtons.ClientArea.Controls.Clear();
                }
                this.dsAdmin1.tblSelListEntries.Clear();
                                
                int lastLeftTop = 3;
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();

                this.sqlAdmin1.getSelListEntrys(ref Parameters, TypList.ToString() + qs2.core.generic.getStayTypeInt(qs2.core.Enums.eStayTyp.Stay).ToString(), this.license1.OwnParticipant, this.license1.OwnApplication.ToString(), ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.group);
                this.sqlAdmin1.getSelListEntrys(ref Parameters, TypList.ToString() + qs2.core.generic.getStayTypeInt(qs2.core.Enums.eStayTyp.FollowUp).ToString(), this.license1.OwnParticipant, this.license1.OwnApplication.ToString(), ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.group);

                qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries = (qs2.core.vb.dsAdmin.tblSelListEntriesRow[])this.dsAdmin1.tblSelListEntries.Select("", this.dsAdmin1.tblSelListEntries.sortColumn.ColumnName);
                int counter = 0;
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntries in arrSelListEntries)
                {
                    bool rigthOK = false;
                    qs2.core.vb.dsAdmin dsAdminCriteria = new core.vb.dsAdmin();
                    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = null;
                    qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriterias = this.sqlAdmin1.getCriterias(dsAdminCriteria, core.vb.sqlAdmin.eTypSelCriteria.idRam, rSelEntries.FldShortColumn.Trim(),
                                                                                                    Application, false, false, false, "", "", false);
                    if (arrCriterias.Length > 1)
                    {
                        throw new Exception("buildList: arrCriterias.Length > 1 for ProcGroup '" + rSelEntries.FldShortColumn.Trim() + "'!");
                    }
                    if (arrCriterias.Length == 1)
                    {
                        rCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriterias[0];
                    }
                    if (TypList == core.Enums.eTypList.PROCGRP)
                    {
                        if (rCriteria != null)
                        {
                            if (!String.IsNullOrWhiteSpace(rCriteria.LicenseKey))
                            {
                                bool LicenseKeyYesFound = false;
                                System.Collections.Generic.List<string> lstLicenseKeys = qs2.core.generic.readStrVariables(rCriteria.LicenseKey.Trim());
                                foreach (string LicensekeyFound in lstLicenseKeys)
                                {
                                    qs2.core.Enums.cLicense LicenseFoundForSession = qs2.core.license.doLicense.GetLicense(LicensekeyFound.Trim());
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
                                rigthOK = false; 
                            }
                        }
                        else
                        {
                            throw new Exception("buildList: rCriteria != null for ProcGroup '" + rSelEntries.FldShortColumn.Trim() + "'!");
                        }
                    }
                    else if (TypList == core.Enums.eTypList.CHAPTERS)
                    {
                        rigthOK = this.autoLoadControls1.checkRightLicenseChapter(rSelEntries);
                    }
                    else
                    {
                        throw new Exception("buildList: TypList '" + TypList.ToString()  + "' not allowed!");
                    }

                    if (qs2.core.ENV.developModus)
                    {
                        rigthOK = true; 
                    }

                    if (qs2.core.ENV.developModus)
                    {
                        rigthOK = true;
                    }

                    if (rigthOK)
                    {
                        counter += 1;

                        contListAssistentElem contButtAssistentElem1 = new contListAssistentElem();
                        contButtAssistentElem1.cListAssistentElem.ListMain = this;
                        contButtAssistentElem1.cListAssistentElem.rSelEntries = rSelEntries;
                        contButtAssistentElem1.cListAssistentElem.IDSelEntry = rSelEntries.ID;
                        contButtAssistentElem1.cListAssistentElem.sqlTable = rSelEntries._Table;
                        contButtAssistentElem1.cListAssistentElem.sqlColumn = rSelEntries.FldShortColumn;
                        contButtAssistentElem1.cListAssistentElem.IDApplication = Application;

                        qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = this.sqlAdmin1.getSelListGroup(ref dsAdmin1, core.vb.sqlAdmin.eTypSelGruppen.IDRam, "", Participant, Application, rSelEntries.IDGroup, "");
                        if (arrGrp.Length != 1)
                        {
                            throw new Exception("contListAssistent.buildList: arrGrp.Length != 1 for IDGroup '" + rSelEntries.IDGroup.ToString() + "'!");
                        }
                        contButtAssistentElem1.cListAssistentElem.IDGroupStr = arrGrp[0].IDGroupStr;
                        contButtAssistentElem1.InitControl(TypList, Application, Participant, rSelEntries.ID, true, "Procedures");

                        if (TypList == core.Enums.eTypList.CHAPTERS)
                        {
                            contButtAssistentElem1.panelBottom.Height = 0;
                            contButtAssistentElem1.panelBottom.Visible = false;
                            contButtAssistentElem1.Height = qs2.core.ENV.ButtChapterHeigth;
                            contButtAssistentElem1.Top = lastLeftTop;
                        }
                        else
                        {
                            contButtAssistentElem1.btnOK.Visible = false;
                            contButtAssistentElem1.btnOK.Height = 0;
                            if (Application.ToString().Trim().Equals(qs2.core.license.doLicense.eApp.VASCULAR.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                contButtAssistentElem1.panelBottom.Visible = true;
                            }
                            else
                            {
                                contButtAssistentElem1.panelBottom.Height = 0;
                                contButtAssistentElem1.panelBottom.Visible = false;
                            }
                            contButtAssistentElem1.Height = this.panelButtons.Height - 30;
                            contButtAssistentElem1.Top = (this.panelButtons.Height - contButtAssistentElem1.Height) / 2;
                        }
                        
                        contButtAssistentElem1.Width = (TypList == core.Enums.eTypList.PROCGRP ? qs2.core.ENV.ButtProcGrpWidth : this.panelButtons.Width);
                        contButtAssistentElem1.Left = (TypList == core.Enums.eTypList.PROCGRP ? lastLeftTop : this.panelButtons.Left);
                        contButtAssistentElem1.btnElement.ImageSize = sizeButton;
                        contButtAssistentElem1.cListAssistentElem.assistent = this;

                        if (TypList == core.Enums.eTypList.PROCGRP)
                            contButtAssistentElem1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                            | System.Windows.Forms.AnchorStyles.Left))));
                        else if (TypList == core.Enums.eTypList.CHAPTERS)
                        {
                            contButtAssistentElem1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                                                            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                            contButtAssistentElem1.btnElement.Appearance.TextHAlign = HAlign.Left;
                        }

                        this.panelButtons.ClientArea.Controls.Add(contButtAssistentElem1);

                        lastLeftTop += (TypList == core.Enums.eTypList.PROCGRP ? contButtAssistentElem1.Width + this.distanceProcGrp : contButtAssistentElem1.Height + this.distanceChapters);

                        bool pictureJN = false;
                        System.Drawing.Image img = qs2.core.language.sqlLanguage.getPicture(rSelEntries.IDRessource, core.Enums.eResourceType.PictureDisabled, this.license1.OwnParticipant.ToString(), this.license1.OwnApplication.ToString());
                        if (img != null)
                        {
                            contButtAssistentElem1.cListAssistentElem.picDisabled = img;
                            pictureJN = true;
                        }
                        img = qs2.core.language.sqlLanguage.getPicture(rSelEntries.IDRessource, core.Enums.eResourceType.PictureEnabled, this.license1.OwnParticipant.ToString(), this.license1.OwnApplication.ToString());
                        if (img != null)
                        {
                            contButtAssistentElem1.cListAssistentElem.picEnabled = img;
                            pictureJN = true;
                        }
                        img = qs2.core.language.sqlLanguage.getPicture(rSelEntries.IDRessource, core.Enums.eResourceType.PictureMouseOver, this.license1.OwnParticipant.ToString(), this.license1.OwnApplication.ToString());
                        if (img != null)
                        {
                            contButtAssistentElem1.btnElement.HotTrackAppearance.Image = img;
                            contButtAssistentElem1.cListAssistentElem.picMouseOver = img;
                            contButtAssistentElem1.btnElement.HotTrackAppearance.Image = this.ImgListMouseOver.Images[0];
                            pictureJN = true;
                        }
                        if (!pictureJN)
                            contButtAssistentElem1.btnElement.Appearance.TextVAlign = VAlign.Middle;

                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        contButtAssistentElem1.btnElement.Text = qs2.core.language.sqlLanguage.getRes(rSelEntries.IDRessource, core.Enums.eResourceType.Label, this.license1.OwnParticipant.ToString(), this.license1.OwnApplication.ToString(), ref  rLangFoundReturn).Trim();
                        contButtAssistentElem1.cListAssistentElem.TxtButton = contButtAssistentElem1.btnElement.Text.Trim();
                        contButtAssistentElem1.cListAssistentElem.element.nr = counter;
                        contButtAssistentElem1.cListAssistentElem.element.selListEntryID = rSelEntries.ID;
                        contButtAssistentElem1.cListAssistentElem.element.selListEntryIDOwnStr = rSelEntries.IDOwnStr;
                        contButtAssistentElem1.cListAssistentElem.element.TypList = TypList;

                        contButtAssistentElem1.Visible = true;
                        contButtAssistentElem1.isOn = false;
                        if (arrCriterias.Length == 1)
                        {
                            contButtAssistentElem1.cListAssistentElem.rCriteria = arrCriterias[0];
                            contButtAssistentElem1.cListAssistentElem.ownMCRelationship = new design.auto.ownMCRelationship();
                            contButtAssistentElem1.cListAssistentElem.ownMCRelationship.initControl(Application);
                            contButtAssistentElem1.cListAssistentElem.ownMCRelationship.getRelationsship(rSelEntries.FldShortColumn.Trim(), Application);

                        }
                        this.CheckElementClassification(rSelEntries, ref contButtAssistentElem1);


                                       

                        object sender = new object();
                        EventArgs evArg = new EventArgs();

                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();

                    }
                }

                System.Drawing.Size sizeScroll;
                if (TypList == core.Enums.eTypList.PROCGRP)
                {
                    sizeScroll = new System.Drawing.Size(lastLeftTop - qs2.core.ENV.ButtProcGrpWidth - this.distanceProcGrp, 0);
                    this.panelButtons.AutoScrollMinSize = sizeScroll;
                }

                IsInitialized = true;
            }
            catch (Exception ex)
            {
                throw new Exception("bulidList: " + ex.ToString());
            }
        }

        public void CheckElementClassification(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntries,ref  contListAssistentElem contButtAssistentElem1)
        {
            try
            {
                System.Collections.Generic.List<string> lstVarClassification = qs2.core.generic.readStrVariables(rSelEntries.Classification.Trim());
                foreach (string defVarClassification in lstVarClassification)
                {
                    qs2.core.Enums.cVariables cVariableNew = new qs2.core.Enums.cVariables();
                    qs2.core.vb.funct.getVariablesLefRightOfPoint(defVarClassification, ref cVariableNew.definition, ref cVariableNew.value, "=");
                    if (cVariableNew.definition.sEquals(qs2.core.Enums.cVariablesDefinition.Visible))
                    {
                        if (cVariableNew.value.sEquals("0"))
                        {
                            contButtAssistentElem1.cListAssistentElem.IsVisibleClassificationSelList = false;
                        }
                        else if (cVariableNew.value.sEquals("1"))
                        {
                            contButtAssistentElem1.cListAssistentElem.IsVisibleClassificationSelList = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void refresControl(qs2.core.Enums.eTypList TypList, bool ShowAllStayTypes, qs2.core.Enums.eStayTyp StayTypLoaded,
                                    bool runAsSystemuser, int UserIDSystemuser)
        {
            try
            {
                this._ShowAllStayTypes = ShowAllStayTypes;
                if (!qs2.core.ENV.developModus)
                {
                    this._ShowAllStayTypes = false;
                    ShowAllStayTypes = false;
                }

                if (TypList == core.Enums.eTypList.CHAPTERS)
                {
                    this.resetAllElements(false, TypList, ShowAllStayTypes, StayTypLoaded, runAsSystemuser, UserIDSystemuser);
                    this.repositonAllElements(TypList, ShowAllStayTypes, this);
                }
                else if (TypList == core.Enums.eTypList.PROCGRP)
                {
                    this.resetAllElements(true, TypList, ShowAllStayTypes, StayTypLoaded, runAsSystemuser, UserIDSystemuser);
                    this.repositonAllElements(TypList, ShowAllStayTypes, this);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                
            }
        }

        public void loadDropDownProcGroups(qs2.core.vb.dsObjects.tblStayRow rStay, string Application)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.loadDropDownProcGroups(rStay, Application);
            }  
        }
        public void doRelationsship()
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.doRelationsship(false);
            }
        }
        public void saveDropDownProcGroups(qs2.core.vb.dsObjects.tblStayRow rStay, string Application)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.saveDropDownProcGroups(rStay, Application);
            }
        }
        public void resetDropDownProcGroupsMain(System.Guid IDElementClicked, ref string ColumnNameClicked)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.resetDropDownProcGroupsMain(IDElementClicked, ref ColumnNameClicked);
            }
        }
        public void doAllAssignmentsDropDown(qs2.core.vb.dsObjects.tblStayRow rStay, string Application,  ref string protocollForAdmin, ref bool ProtocolWindow)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.doAllAssignmentsDropDown(rStay, Application, ref protocollForAdmin, ref ProtocolWindow);
            }
        }

        public void setElementsEditable(bool isEditable)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.lockUnlock(isEditable);
            }
        }

        public void elementClick2(contListAssistentElem ListAssistentElem, bool isOn, bool doChapters, bool reduceCounterForChapter,
                                    ref string protocollForAdmin, ref bool ProtocolWindow,
                                    ref System.Collections.Generic.List<string> lstElementsActive,
                                    ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck,
                                    bool setActive, bool runAsSystemuser, int UserIDSystemuser, bool ButtonClickedByUser, bool loadSelectedChapters,
                                    bool callReposition)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ListAssistentElem.cListAssistentElem.element.TypList == core.Enums.eTypList.PROCGRP)
                {
                    if (!isOn)
                    {
                        ListAssistentElem.isOn = false;
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(ListAssistentElem, core.ui.eButtonType.Procedure);
                    }
                    else
                    {
                        ListAssistentElem.isOn = true;
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktivElement(ListAssistentElem, core.ui.eButtonType.Procedure);
                    }
                    int IDSelProcGroup = qs2.core.generic.idMinus;

                    if (doChapters)
                    {
                        System.Collections.Generic.List<qs2.design.auto.workflowAssist.assist.cListAssistentElem> lstButtonsActivated = new List<design.auto.workflowAssist.assist.cListAssistentElem>();
                        System.Collections.Generic.List<qs2.design.auto.workflowAssist.assist.cListAssistentElem> lstButtonsDeaktivated = new List<design.auto.workflowAssist.assist.cListAssistentElem>();

                        System.Collections.Generic.List<string> lstButtonsActivatedBefore = new List<string>();
                        System.Collections.Generic.SortedDictionary<int, string> lstAllChaptersBeforeActive = new SortedDictionary<int, string>();

                        if (callReposition)
                        {
                            this.repositonAllElements(core.Enums.eTypList.CHAPTERS, this._ShowAllStayTypes, this.assistentChapters);
                        }
                    }
                }
                else if (ListAssistentElem.cListAssistentElem.element.TypList == core.Enums.eTypList.CHAPTERS)
                {
                    ListAssistentElem.cListAssistentElem.assistent.deactivateAllButtons(ListAssistentElem.cListAssistentElem.assistent);
                    if (setActive)
                    {
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktivElement(ListAssistentElem, core.ui.eButtonType.Chapter);
                        ListAssistentElem.isOn = true;
                    }
                    else
                    {
                        throw new Exception("this.autoUI = null");
                    }
                }
            }

            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void doAllAssignments(ref string protocollForAdmin, ref bool ProtocolWindow,
                                        bool enabled, qs2.core.Enums.eTypList TypList)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                this.doAssignments(ref protocollForAdmin, ref ProtocolWindow, element.cListAssistentElem.IDSelEntry, element.isOn);
            }
        }

        public void doAssignments(ref string protocollForAdmin, ref bool ProtocolWindow, int IDSelListCkicked, bool bOn)
        {
            try
            {
                System.Collections.Generic.List<string> lstProcGroupsActive = new System.Collections.Generic.List<string>();
                this.getActiveElements(this, ref lstProcGroupsActive);

                design.auto.ownMCRelationship.eTypAssignments TypAssignments = new design.auto.ownMCRelationship.eTypAssignments();
                if (this.TypList == core.Enums.eTypList.PROCGRP)
                {
                    TypAssignments = design.auto.ownMCRelationship.eTypAssignments.ProcGroup;
                }
                else if (this.TypList == core.Enums.eTypList.CHAPTERS)
                {
                    TypAssignments = design.auto.ownMCRelationship.eTypAssignments.AutoSaveToChapter;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doAllAssignmentsDropDown(ref string protocollForAdmin, ref bool ProtocolWindow,
                                bool enabled, qs2.core.Enums.eTypList TypList,
                                qs2.core.vb.dsObjects.tblStayRow rStay, string Application)
        {
            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                element.doAllAssignmentsDropDown(rStay, Application, ref protocollForAdmin, ref ProtocolWindow);
            }
        }

        public void doAssignmentsDropDown(ref string protocollForAdmin, ref bool ProtocolWindow, int IDSelListCkicked, bool bOn)
        {
            try
            {
                System.Collections.Generic.List<string> lstProcGroupsActive = new System.Collections.Generic.List<string>();
                this.getActiveElements(this, ref lstProcGroupsActive);

                design.auto.ownMCRelationship.eTypAssignments TypAssignments = new design.auto.ownMCRelationship.eTypAssignments();
                if (this.TypList == core.Enums.eTypList.PROCGRP)
                {
                    TypAssignments = design.auto.ownMCRelationship.eTypAssignments.ProcGroupDropDownList;
                }
                else if (this.TypList == core.Enums.eTypList.CHAPTERS)
                {
                    TypAssignments = design.auto.ownMCRelationship.eTypAssignments.ChapterDropDownList;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void resetAllElements(bool enabled, qs2.core.Enums.eTypList TypList, bool ShowAllStayTypes, qs2.core.Enums.eStayTyp StayTypLoaded,
                                            bool runAsSystemuser, int UserIDSystemuser)
        {

            this.panelButtons.AutoScroll = false;
            this.panelButtons.Refresh();
            this.panelButtons.AutoScroll = true;

            foreach (contListAssistentElem element in this.panelButtons.ClientArea.Controls)
            {
                if (TypList == core.Enums.eTypList.PROCGRP)
                {
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(element, core.ui.eButtonType.Procedure);
                }
                else if (TypList == core.Enums.eTypList.CHAPTERS)
                {
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(element, core.ui.eButtonType.Chapter);
                }
            
                element.Enabled = enabled;
                element.cListAssistentElem.counterActivated = 0;
                element.isOn = false;
                element.cListAssistentElem.isOKOn = false;

                if (ShowAllStayTypes)
                {
                    element.cListAssistentElem.IsVisibleForStayType = true; 
                }
                else if (!element.cListAssistentElem.IsVisibleClassificationSelList)
                {
                    element.cListAssistentElem.IsVisibleForStayType = false;
                }
                else
                {
                    if (TypList == core.Enums.eTypList.PROCGRP)
                    {
                        string OwnApplicationTmp = "";

                        if (runAsSystemuser)
                        {
                            element.cListAssistentElem.IsVisibleForSystemuser = b.checkRigthButtons(element.cListAssistentElem.rSelEntries.ID, UserIDSystemuser );
                        }
                        else
                        {
                            element.cListAssistentElem.IsVisibleForSystemuser = b.checkRigthButtons(element.cListAssistentElem.rSelEntries.ID, qs2.core.vb.actUsr.rUsr.ID );
                        }
                        element.Visible = element.cListAssistentElem.IsVisibleForSystemuser;

                        if (StayTypLoaded == core.Enums.eStayTyp.Stay && element.cListAssistentElem.IDGroupStr.sEquals("ProcGrp0"))
                        {
                            element.cListAssistentElem.IsVisibleForStayType = true;
                        }
                        else if (StayTypLoaded == core.Enums.eStayTyp.FollowUp && element.cListAssistentElem.IDGroupStr.sEquals("ProcGrp1"))
                        {
                            element.cListAssistentElem.IsVisibleForStayType = true;
                        }
                        else
                        {
                            element.cListAssistentElem.IsVisibleForStayType = false;
                        }
                    }
                    else if (TypList == core.Enums.eTypList.CHAPTERS)
                    {
                        if (StayTypLoaded == core.Enums.eStayTyp.Stay && element.cListAssistentElem.IDGroupStr.sEquals("Chapters0"))
                        {
                            element.cListAssistentElem.IsVisibleForStayType = true;
                        }
                        else if (StayTypLoaded == core.Enums.eStayTyp.FollowUp && element.cListAssistentElem.IDGroupStr.sEquals("Chapters1"))
                        {
                            element.cListAssistentElem.IsVisibleForStayType = true;
                        }
                        else
                        {
                            element.cListAssistentElem.IsVisibleForStayType = true;
                        }
                    }
                }
            }
       } 

        public void repositonAllElements(qs2.core.Enums.eTypList TypList, bool ShowAllStayTypes, contListAssistent ListAssistentAct)
        {
            try
            {
                contListAssistentElem elementLastVisible = null;

                foreach (contListAssistentElem element in ListAssistentAct.panelButtons.ClientArea.Controls)
                {
                    if (TypList == core.Enums.eTypList.PROCGRP)
                    {
                        bool bVisible = true;
                        if (!element.cListAssistentElem.IsVisibleForStayType || !element.cListAssistentElem.IsVisibleClassificationSelList || !element.cListAssistentElem.IsVisibleForSystemuser || !element.cListAssistentElem.IsVisibleForSystemuser)
                        {
                            bVisible = false;
                        }

                        if (!bVisible)
                        {
                            element.Width = 0;
                        }
                        else
                        {
                            element.Width = qs2.core.ENV.ButtProcGrpWidth;
                            if (elementLastVisible != null)
                            {
                                element.Left = elementLastVisible.Left + elementLastVisible.Width + this.distanceProcGrp;
                            }
                            else
                            {
                                element.Left = this.distanceProcGrp;
                            }
                            elementLastVisible = element;
                        }
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("repositonAllElements: " + ex.ToString());
            }
        }
        
        public void deactivateAllButtons(contListAssistent assistent)
        {
            foreach (contListAssistentElem chapter in assistent.panelButtons.ClientArea.Controls)
            {
                chapter.isOn = false;
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(chapter, core.ui.eButtonType.Chapter);
            }
        }
        public void getActiveElements(contListAssistent assistent, ref System.Collections.Generic.List<string> lstProcGroupsActive)
        {
            foreach (contListAssistentElem ProcGroup in assistent.panelButtons.ClientArea.Controls)
            {
                if (ProcGroup.isOn)
                {
                    lstProcGroupsActive.Add(ProcGroup.cListAssistentElem.element.selListEntryIDOwnStr);
                }
            }
        }
    }
}
