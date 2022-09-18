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
using System.Threading;
using S2Extensions;

namespace qs2.sitemap.workflowAssist.form
{

   

    public partial class contAutoUI : UserControl
    {

        public frmAutoUI parentFormAutoUI;
        public license _license;

        public qs2.design.auto.workflowAssist.autoForm.autoLoadControls autoLoadControls = null;
        public qs2.design.auto.workflowAssist.autoForm.doAutoControls doAutoControls = null;

        public qs2.core.vb.dsObjects.tblStayRow rStayRead;
        public qs2.design.auto.workflowAssist.autoForm.dataStay dataStay;
        public static bool LoadingStayData = false;

        public bool _PatientVisible = false;
        //public qs2.sitemap.vb.contObject contObject1 = null;
        
        public event EventHandler ownSaveClicked;
        public event EventHandler ownEditClicked;
        public event EventHandler ownCancelClicked;
        public event EventHandler ownCloseClicked;
        
        public static string tabNameProtokoll = "protokoll";
        public qs2.core.Enums.eStayTyp loadedStayTyp;

        public qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1 = null;

        //public qs2.core.vb.contProtocol contProtocolToBind = null;
        public qs2.design.auto.workflowAssist.autoForm.doSideLogic doSideLogic1 = null;

        public enum eTypeActionService
        {
            CheckAllCriteriasAssignedToChapters = 0,
            GenPrintDll = 1
        }

        public bool AllControlsDone = false;
        public bool GenAutoPrintDllDone = false;
        public string protocolldoActionAllControls = "";
        public bool _ShowAllStayTypes = false;

        public bool IsInitialized = false;

        public businessFramework buisLogAdminWork = new businessFramework();
        public bool _runAsSystemuser = false;
        public int _runAsUser = -999;
        public bool IsFirstLoad = true;

        public bool resetOpenModeOnClose = true;

        public System.Collections.Generic.SortedDictionary<int, qs2.design.auto.workflowAssist.assist.cListAssistentElem> lstAllChapters = new SortedDictionary<int, design.auto.workflowAssist.assist.cListAssistentElem>();
        public System.Collections.Generic.SortedDictionary<int, string> lstAllChaptersActive = new SortedDictionary<int, string>();

        public System.Collections.Generic.List<string> lstChaptersClickedFromUser = new List<string>();

        public static bool _isNew2 = false;
        public bool _OpendFromEvaluation = false;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public qs2.ui.print.frmQryRunReport frmQryRunReport1 = null;











        public contAutoUI()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            this.initOwn();
        }


        public void initOwn()
        {
        }
        private void contWorkAuto_Load(object sender, EventArgs e)
        {
        }

        public void initControl(qs2.core.Enums.eStayTyp StayTyp, bool showAllStayTypes)
        {
            try
            {
                this.loadedStayTyp = StayTyp;

                if (this.IsInitialized)
                {
                    return;
                }

                this.panelChapterWhite.BringToFront();
                this.parentFormAutoUI.contAutoUI = this;

                this.OwnFreeTopVisible = false;
                this.OwnFreeBelowVisible = false;
                this.OwnFreeTopLeftVisible = true;
                this.OwnFreeTopRigthVisible = false;

                this.autoUI1.initialize(this.OwnLicense.OwnApplication .ToString());
                this.autoLoadControls = new qs2.design.auto.workflowAssist.autoForm.autoLoadControls();
                this.doAutoControls = new qs2.design.auto.workflowAssist.autoForm.doAutoControls();

                if (qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2 == null)
                {
                    qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2 = new qs2.core.vb.contProtocol();
                    qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2.TypeProtocolWindow = contProtocol.eTypeProtocolWindow.protocol;
                    qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2.initControl();
                    qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2.lblTitleError.Visible = true;
                    qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2.pictureBoxError.Visible = true;
                }
                this.dropDownErrors.Appearance.ForeColor = Color.Red;

                Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popUpContToolErrors = (Infragistics.Win.UltraWinToolbars.PopupControlContainerTool)this.toolBarDropDown.Tools["PopupControlProtocol"];
                popUpContToolErrors.Control = qs2.design.auto.multiControl.ownMCInfo.contTotalProtocol2;
                this.dropDownErrors.PopupItem = (Infragistics.Win.IPopupItem)this.toolBarDropDown.Tools["PopupControlProtocol"];

                this.timerCheckProtocol.Enabled = true;
                this.timerCheckProtocol.Start();
                this.dropDownErrors.Visible = false;
                
                qs2.sitemap.workflowAssist.form.contAutoUI.LoadingStayData = true;

                this.dropDownAssigns.PopupItem = (Infragistics.Win.IPopupItem)this.toolBarDropDown.Tools["popUpDropDown"];

                this.loadRes();

                this.sqlAdmin1.initControl();

                this.tabPages.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

                this.initTabs();

                this.contListProdGroups.autoUI = this;
                this.contListChapters.autoUI = this;
                this.contListProdGroups.assistentChapters = this.contListChapters;

                this.FreeTopRigth.Visible = false;
                this.lblInfoProcGroups.Visible = false;
                this.lblInfoProcGroups.Text = qs2.core.language.sqlLanguage.getRes("PleaseSelectAtLeastOneProcedure") + "!";

                this.contAutoProtokoll1.mainWindowxy = this;
                this.contAutoProtokoll1.initControl();
                this.contListProdGroups.initControl(true);
                this.contListChapters.initControl(false);

                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.toolBarDropDown.Tools["btnGeneratePrintStayDll"].SharedProps.Visible = true;
                    this.toolBarDropDown.Tools["btnInfoMonitoring"].SharedProps.Visible = true;
                    this.toolBarDropDown.Tools["btnCheckAllCriteriasAssignedToChapters"].SharedProps.Visible = true;
                    this.toolBarDropDown.Tools["btnOpenSqlProductStays"].SharedProps.Visible = true;
                    cboPrintDocuments.Visible = true;
                }
                else
                {
                    this.toolBarDropDown.Tools["btnGeneratePrintStayDll"].SharedProps.Visible = false;
                    this.toolBarDropDown.Tools["btnInfoMonitoring"].SharedProps.Visible = false;
                    this.toolBarDropDown.Tools["btnCheckAllCriteriasAssignedToChapters"].SharedProps.Visible = false;
                    this.toolBarDropDown.Tools["btnOpenSqlProductStays"].SharedProps.Visible = false;
                    cboPrintDocuments.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightPrintDocuments, false) && 
                        qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS).bValue) || 
                        qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS_VALID_DATE).dValue > DateTime.Now;
                }

                //this.contListProdGroups.buildList(qs2.core.Enums.eTypList.PROCGRP, typ);
                //this.contListChapters.buildList(qs2.core.Enums.eTypList.CHAPTERS, typ);

                qs2.core.vb.sqlObjects.loadAllData();

                this.contListProdGroups.buildList(qs2.core.Enums.eTypList.PROCGRP, true, this.OwnLicense.OwnApplication.ToString(), this.OwnLicense.OwnParticipant, showAllStayTypes);
                this.contListChapters.buildList(qs2.core.Enums.eTypList.CHAPTERS, false, this.OwnLicense.OwnApplication.ToString(), this.OwnLicense.OwnParticipant, showAllStayTypes);

                this.initTabs22();

                this.dataStay = new qs2.design.auto.workflowAssist.autoForm.dataStay();
                //this.autoUI1.getAllCriteriasLoadImmediatelyxy(ref this.dataStay, this.OwnLicense.OwnApplication.ToString());

                this.doSideLogic1 = new qs2.design.auto.workflowAssist.autoForm.doSideLogic();
                this.doSideLogic1.initControl();

                this.dataStay.initDataStay(this._license.OwnApplication.ToString());
                this.dataStay.coreStaysProducts.initControl(this._license.OwnApplication.ToString());
                this.dataStay.coreStaysProductsProtocol.initControl(this._license.OwnApplication.ToString());

                this.ColorSchemas1.setAppearanceTab(this.tabControlAll, ColorSchemas.eTypeUIStayTab.MainTab, false);
                this.ColorSchemas1.setAppearancePanel(this.FreeTopLeft, ColorSchemas.eTypeUIPanel.PanelStayTopLeft, false);
                this.ColorSchemas1.setAppearancePanel(this.FreeTop, ColorSchemas.eTypeUIPanel.PanelStayTop, false);
                this.ColorSchemas1.setAppearancePanel(this.FreeTopRigth, ColorSchemas.eTypeUIPanel.PanelStayTopRight, false);
                this.ColorSchemas1.setAppearancePanel(this.PanelButtons, ColorSchemas.eTypeUIPanel.PanelStayButtons, false);
                this.ColorSchemas1.setAppearancePanel(this.ultraPanelButtons, ColorSchemas.eTypeUIPanel.PanelStayButtons, false);

                //this.ColorSchemas1.setAppearanceButton(this.btnCancel, ColorSchemas.eTypeButton.StayBottom, false);
                //this.ColorSchemas1.setAppearanceButton(this.btnSave, ColorSchemas.eTypeButton.StayBottom, false);
                //this.ColorSchemas1.setAppearanceButton(this.btnEdit, ColorSchemas.eTypeButton.StayBottom, false);
                //this.ColorSchemas1.setAppearanceButton(this.btnPrint, ColorSchemas.eTypeButton.StayBottom, false);

                this.ColorSchemas1.setAppearanceComboBoxAsDropDown(this.dropDownAssigns, false);
                this.ColorSchemas1.setAppearanceComboBoxAsDropDown(this.dropDownErrors, false);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnCopy, core.ui.eButtonType.StayBottom);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnCheck, core.ui.eButtonType.StayBottom);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnClose, core.ui.eButtonType.StayBottom);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnProtocol,core.ui.eButtonType.StayBottom);

                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnHistorie"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnCheckAllCriteriasAssignedToChapters"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnInfoMonitoring"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnGeneratePrintStayDll"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnOpenSqlProductStays"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnPrintEntrySheet"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnExportIDStayGuid"]);
                this.ColorSchemas1.setAppearanceButtonToolbox(this.toolBarDropDown.Tools["btnImportIDStayGuid"]);

                this.IsInitialized = true;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.initControl", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
            finally
            {
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
        }


        public void loadRes()
        {
            try
            {
                this.btnPrint.initControl();
                this.btnCopy.initControl();
                this.btnCancel.initControl();
                this.btnClose.initControl();
                this.btnEdit.initControl();
                this.btnSave.initControl();

                this.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel");
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
                this.btnEdit.Text = qs2.core.language.sqlLanguage.getRes("Edit");
                this.btnProtocol.Text = qs2.core.language.sqlLanguage.getRes("Protokoll");
                this.btnSave.Text = qs2.core.language.sqlLanguage.getRes("Save");
                this.btnPrint.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("Print");
                this.btnCheck.Text = qs2.core.language.sqlLanguage.getRes("Check2");

                this.btnCopy.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32);
                this.dropDownAssigns.Text = qs2.core.language.sqlLanguage.getRes("Others2");

                this.toolBarDropDown.Tools["btnCheckAllCriteriasAssignedToChapters"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("CheckAllCriteriasAssignedToChapters");
                this.toolBarDropDown.Tools["btnOpenSqlProductStays"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("btnOpenSqlProductStays");


                this.toolBarDropDown.Tools["btnPrintEntrySheet"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("PrintEntrySheet");
                this.toolBarDropDown.Tools["btnPrintEntrySheet"].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rigthProtocoll, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();

                this.toolBarDropDown.Tools["btnHistorie"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("History");
                this.toolBarDropDown.Tools["btnHistorie"].SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table , 32, 32);
                this.toolBarDropDown.Tools["btnHistorie"].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rigthProtocoll, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();

                this.toolBarDropDown.Tools["btnExportIDStayGuid"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ExportIDStayGuid");
                this.toolBarDropDown.Tools["btnExportIDStayGuid"].SharedProps.Visible = true;

                this.toolBarDropDown.Tools["btnImportIDStayGuid"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ImportIDStayGuid");
                this.toolBarDropDown.Tools["btnImportIDStayGuid"].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageKeyValues, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();


                //this.toolBarDropDown.Tools["btnGeneratePrintStayDll"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("");
                //this.toolBarDropDown.Tools["btnInfoMonitoring"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("");

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadRes", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void loadControls(UltraTabControl tabsParent, 
                                    Infragistics.Win.Misc.UltraPanel freeTop,
                                    Infragistics.Win.Misc.UltraPanel freeTopLeft, Infragistics.Win.Misc.UltraPanel freeTopRigth,
                                    Infragistics.Win.Misc.UltraPanel freeBelow, ref int typeLoading, ref string protocollForAdmin, ref bool ProtocolWindow)
        {
            try
            {

                this.autoLoadControls.startxy(tabsParent, this.FreeTop, this.FreeTopLeft, this.FreeTopRigth, this.FreeBelow,
                                                   ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref autoUI1, ref this.dsAdmin1,
                                                   this.OwnLicense.OwnApplication.ToString(), this.OwnLicense.OwnParticipant,
                                                   this);

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadControls", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
            finally
            {
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
        }
        public void initTabs()
        {
            try
            {
                foreach (UltraTab tab in this.tabPages.Tabs)
                {
                    cTabTag cTg = new cTabTag();
                    cTg.IDOwnStr = tab.Text;
                    if (tab.Tag == null) tab.Tag = "0";
                    cTg.text = "";
                    //cTg.element = this.contListChapters.getElement(this.rStay, cTg.IDOwnStr);
                    tab.Tag = cTg;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.initTabs", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void initTabs22()
        {
            try
            {
                foreach (UltraTab tab in this.tabPages.Tabs)
                {
                    cTabTag cTg = (cTabTag)tab.Tag;
                    if (!cTg.IDOwnStr.Trim().ToLower().Equals(("protokoll").Trim().ToLower()))
                    {
                        cTg.element = this.contListChapters.getElement(this.rStayRead, cTg.IDOwnStr);
                        if (cTg.element != null)
                        {
                            cTg.IDSelListChapter = cTg.element.cListAssistentElem.element.selListEntryID;
                        }
                        else
                        {
                            //string xy = "";
                            //throw new Exception("cTg.element == null for Chapter '" + cTg.IDOwnStr + "'!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.initTabs2", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void translateTab(string IDOwnStr, string IDRes)
        {
            try
            {
                foreach (UltraTab tab in this.tabPages.Tabs)
                {
                    cTabTag cTg;
                    cTg = (cTabTag)tab.Tag;
                    if (cTg.IDOwnStr.Trim() == IDOwnStr)
                    {
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        tab.Text = qs2.core.language.sqlLanguage.getRes(IDRes, core.Enums.eResourceType.Label, this._license.OwnParticipant.ToString(), this._license.OwnApplication.ToString(), ref  rLangFoundReturn).Trim();
                        cTg.text = tab.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.translateTab", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void resetGroups(ref string protocollForAdmin, ref  bool ProtocolWindow,
                                            ref System.Collections.Generic.List<string> lstElementsActive,
                                            ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck,
                                            ref qs2.core.Enums.eStayTyp StayTyp, bool runAsSystemuser, int UserIDSystemuser)
        {
            try
            {
                //qs2.core.ui.addWatch("resetGroups contListProdGroups.refresControl", true);
                this.lstAllChaptersActive.Clear();
                this.contListProdGroups.refresControl(core.Enums.eTypList.PROCGRP, this._ShowAllStayTypes, this.loadedStayTyp, runAsSystemuser, UserIDSystemuser);
                //qs2.core.ui.addWatch("resetGroups contListChapters.refresControl", true);
                this.contListChapters.refresControl(core.Enums.eTypList.CHAPTERS, this._ShowAllStayTypes, this.loadedStayTyp, runAsSystemuser, UserIDSystemuser);

                if (this.parentFormAutoUI.WasVisibleFirst)
                {
                    //qs2.core.ui.addWatch("resetGroups loadFirstChapter", true);
                    //this.loadFirstChapter(ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, ref TypAssignmentToCheck,
                    //                    ref StayTyp, runAsSystemuser, UserIDSystemuser);
                }
                //qs2.core.ui.addWatch("resetGroups finished", true);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.resetGroups", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
            }
        }

        public void loadFirstChapter(ref string protocollForAdmin, ref  bool ProtocolWindow,
                                    ref System.Collections.Generic.List<string> lstElementsActive,
                                    ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck,
                                    ref qs2.core.Enums.eStayTyp StayTyp, bool runAsSystemuser, int UserIDSystemuser)
        {
            try
            {
                string IDOwnStrReturn = "";
                contListAssistentElem firstElement = this.contListChapters.getFirstElement2(ref this.loadedStayTyp, this._ShowAllStayTypes, true, ref IDOwnStrReturn);
                if (firstElement != null)
                {
                    this.contListChapters.elementClick2(firstElement, true, true, true, ref protocollForAdmin, ref ProtocolWindow,
                                    ref lstElementsActive, ref TypAssignmentToCheck, false, runAsSystemuser, UserIDSystemuser, false, false, true);
                    this.contListChapters.deactivateAllButtons(this.contListChapters);
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktivElement(firstElement, core.ui.eButtonType.Chapter);
                }
                else
                {
                    foreach (KeyValuePair<int, qs2.design.auto.workflowAssist.assist.cListAssistentElem> chapter in this.lstAllChapters)
                    {
                        if (StayTyp == core.Enums.eStayTyp.Stay && IDOwnStrReturn.Trim() == "")
                        {
                            if (!chapter.Value.rSelEntries.IDOwnStr.Trim().ToLower().Contains(("FUP").Trim().ToLower()))
                            {
                                IDOwnStrReturn = chapter.Value.rSelEntries.IDOwnStr.Trim();
                            }
                        }
                        else if (StayTyp == core.Enums.eStayTyp.FollowUp && IDOwnStrReturn.Trim() == "")
                        {
                            if (chapter.Value.rSelEntries.IDOwnStr.Trim().ToLower().Contains(("FUP").Trim().ToLower()))
                            {
                                IDOwnStrReturn = chapter.Value.rSelEntries.IDOwnStr.Trim();
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadFirstChapter", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void loadPatient()
        {
            try
            {
                //if (this.contObject1 != null)
                //{
                //    throw new Exception("loadPatient: contObject1 not allowed in Product-Stay! Please remove it!");

                //    //this.contObject1.sqlObjects1 = this.dataStay.sqlObjects1;
                //    //this.contObject1.DsObjects1 = this.dataStay.dsObject;
                //    //this.contObject1.loadData(System.Guid.Empty, true, this.rStay.IDPatient);
                //}
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadPatient", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public void loadCboDocuments()
        {
            try
            {
                qs2.design.auto.ui b = new qs2.design.auto.ui();
                b.LoadDocuments(ref this.cboPrintDocuments, this.rStayRead.IDApplication, this.rStayRead.IDParticipant, qs2.core.vb.actUsr.rUsr.ID);

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadCboDocuments", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void writeProtokoll(bool writeProtocoll)
        {
            if (writeProtocoll)
            {

                using (qs2.core.vb.Protocol Protocol1 = new core.vb.Protocol())
                {
                    string sProt = "Stay opend'!" + qs2.core.generic.lineBreak +
                                    "MedRecNr: " + rStayRead.MedRecN.Trim() + "" + qs2.core.generic.lineBreak +
                                    "Stay-ID: " + rStayRead.ID.ToString().Trim() + "" + qs2.core.generic.lineBreak +
                                    "Application: " + rStayRead.IDApplication.Trim() + "" + qs2.core.generic.lineBreak +
                                    "Participant: " + this.rStayRead.IDParticipant.Trim() + "";

                    Protocol1.save2(core.vb.Protocol.eTypeProtocoll.StayOpen, this.rStayRead.PatIDGuid, this.rStayRead.ID, this.rStayRead.IDParticipant.Trim(),
                                    this.rStayRead.IDApplication.Trim(), "", sProt.Trim(), core.vb.Protocol.eActionProtocol.None, this.dataStay.rPatient.NameCombination.Trim(), this.rStayRead.MedRecN.Trim());
                }
                //qs2.core.ui.addWatch("loadData after Protocol1.save", true);
            }
        }

        public void loadDataAsThread()
        {
            try
            {
                this.dataStay.dataLoadedPerThread = false;
                rParam px = new rParam();
                px.App = this._license.OwnApplication.ToString();
                px.r = this.rStayRead;
                Thread threadOrig = new Thread(() => this.dataStay.thLoad(px));
                threadOrig.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("loadDataAsThread: " + ex.ToString());
            }
        }

        public void setProcGroupsChaptersEditable(bool isEditable)
        {
            this.contListProdGroups.setElementsEditable(isEditable);
            this.contListChapters.setElementsEditable(isEditable);
        }        

        public void setButtonProtocolCaption()
        {
            if (this.contAutoProtokoll1.gridProtocoll.Rows.Count > 0)
            {
                this.btnProtocol.Visible = true;
                this.btnProtocol.Text = qs2.core.language.sqlLanguage.getRes("Protokoll") + " (" + this.contAutoProtokoll1.gridProtocoll.Rows.Count.ToString() + ")";
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnProtocol, core.ui.eButtonType.StayBottom);
            }
            else
            {
                this.btnProtocol.Text = qs2.core.language.sqlLanguage.getRes("Protokoll");
                this.btnProtocol.Visible = true;
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnProtocol, core.ui.eButtonType.StayBottom);
            }
        }

        public qs2.core.Enums.cDoProdukt doProductDelegate(qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship, core.Enums.eDoProduktMode DoProduktMode,
                                                            qs2.design.auto.multiControl.ownMultiControl ownMultiControlParent,
                                                            ref System.Collections.Generic.List<qs2.core.generic.retValue> ProcGroups,
                                                            ref qs2.core.Enums.eCalcMode CalcMode, 
                                                            ref dsAdmin.tblStayAdditionsDataTable tStayAdditions, ref string sProtocol)
        {
            try
            {
                qs2.core.Enums.cDoProdukt retDoProdukt = new core.Enums.cDoProdukt();

                System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh = new System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh>();
                System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions = new System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow>();
                qs2.core.vb.dsAdmin.protokollDataTable tProtocollToAdd = new qs2.core.vb.dsAdmin.protokollDataTable();

                dsObjects.tblStayRow rStayProd = dataStay.dsObject.tblStay[0];
                this.autoUI1.doProduktDelegate(DoProduktMode, rRelationsship, this.loadedStayTyp, this._license.OwnApplication, rStayProd,
                                                                                        this.dataStay.rPatient, this.dataStay, arrStayAdditions, ref lstControlsFormRefresh,
                                                                                        ref tProtocollToAdd, this.contAutoProtokoll1.dsAdminFields.protokoll,
                                                                                        ref ProcGroups, ref CalcMode, ref tStayAdditions,
                                                                                        ref retDoProdukt, ref sProtocol);

                if (tProtocollToAdd.Rows.Count > 0)
                {
                    this.contAutoProtokoll1.dsAdminFunctions.protokoll.Rows.Clear();
                    foreach (dsAdmin.protokollRow rProtToAdd in tProtocollToAdd.Rows)
                    {
                        string sChapter = "";
                        string TextControl = rProtToAdd.TextControl;
                        qs2.core.vb.dsAdmin.dbAutoUIRow rowAutoUI = null;
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                        System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstOwnGroupBox = new List<qs2.design.auto.multiControl.ownGroupBox>();
                        qs2.design.auto.workflowAssist.autoForm.autoUI.getMultiControl(rProtToAdd.TextControl,
                                                                                            this._license.OwnApplication.ToString(),
                                                                                            ref this.dsAdmin1, "",
                                                                                            ref lstMultiControl, ref lstTabePageReturn, ref lstTab, ref lstOwnGroupBox);
                        if (lstMultiControl.Count > 0)
                        {
                            foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControlFound in lstMultiControl)
                            {
                                TextControl = ownMultiControlFound.ownMCTxt1.TextTranslated;
                                rowAutoUI = ownMultiControlFound.rAutoUI;
                                if (ownMultiControlFound.ownMCCriteria1.tagTab != null)
                                {
                                    sChapter = ownMultiControlFound.ownMCCriteria1.tagTab.text.Trim();          //ownMultiControlFound.rAutoUI.Chapter; 
                                    if (!String.IsNullOrWhiteSpace(sChapter))
                                        break;
                                }
                            }
                        }
                        this.contAutoProtokoll1.addRow(sChapter, TextControl, rProtToAdd.TextMessage, rowAutoUI, QS2.Resources.getRes.ePicture.ico_modifyQuery, false, false, true, rProtToAdd.supress);
                    }
                    tProtocollToAdd.Rows.Clear();
                }

                foreach (qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh itmRefresh in lstControlsFormRefresh)
                {

                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                    System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                    qs2.design.auto.workflowAssist.autoForm.autoUI.getMultiControl(itmRefresh.multiControlToRefresh,
                                                                                    this._license.OwnApplication.ToString(),
                                                                                    ref this.dsAdmin1, "", ref lstMultiControl, 
                                                                                    ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);

                    foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 in lstMultiControl)
                    {

                        if ((ownMultiControlParent == null) ||  (ownMultiControlParent != null && ownMultiControlParent.OwnFldShort != ownMultiControl1.OwnFldShort))
                        {
                            if (!ownMultiControl1.ownMCCriteria1._isInitializedCriteria)
                            {
                                this.autoUI1.initMulticontrol(ownMultiControl1, ref this.dataStay);
                                this.autoUI1.multicontrolFillData(ref dataStay, ownMultiControl1);
                            }
                            if (ownMultiControl1.ownMCDataBind1.Binding1 == null)
                            {
                                autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
                            }

                            if (ownMultiControl1.ownMCUI1.lstColors != null && ownMultiControl1.ownMCUI1.lstColors.Count > 0)
                            {
                                ownMultiControl1.ownMCUI1.setColorsFromClassification(ownMultiControl1);
                            }

                            ownMultiControl1.ownMCDataBind1.BindControlToData(ownMultiControl1, false, this.dataStay, true);
                            if (itmRefresh.RunRelationship)
                            {
                                ownMultiControl1.doRelationsship(true, true, 0, design.auto.ownMCRelationship.eTypAssignments.MCParent,
                                                                        ownMultiControl1.rAutoUI.Chapter, false);
                            }
                        }
                    }
                }
                return retDoProdukt;
            }

            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.doProductDelegate", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.core.Enums.cDoProdukt retDoProdukt = new core.Enums.cDoProdukt();
                retDoProdukt.bOK = true;
                return retDoProdukt;
            }
        }
         
        public string getIDOwnStrActiveTab()
        {
            try
            {
                if (this.tabPages.ActiveTab != null)
                {
                    cTabTag cTg;
                    cTg = (cTabTag)this.tabPages.ActiveTab.Tag;
                    return cTg.IDOwnStr;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("contAutoUI.getIDOwnStrActiveTab: " + ex.ToString());
                //return "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ownCloseClicked != null)
                    this.ownCloseClicked(this, e);

                this.closeControlxy();

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
        public void closeControlxy()
        {
            this.parentFormAutoUI.Close();
        }




        public license OwnLicense
        {
            get
            {
                return this._license;
            }
            set
            {
                this._license = value;
                this.contListProdGroups.license1  = this._license;
                this.contListChapters.license1 = this._license;
            }
        }

        public bool OwnFreeTopVisible
        {
            get
            {
                return this.FreeTop .Visible ;
            }
            set
            {
                this.FreeTop.Visible = value;
            }
        }

        public bool OwnFreeTopLeftVisible
        {
            get
            {
                return this.FreeTopLeft.Visible;
            }
            set
            {
                this.FreeTopLeft.Visible = value;
            }
        }

        public bool OwnFreeTopRigthVisible
        {
            get
            {
                return this.FreeTopRigth.Visible;
            }
            set
            {
                this.FreeTopRigth.Visible = value;
            }
        }

        public bool OwnFreeBelowVisible
        {
            get
            {
                return this.FreeBelow.Visible;
            }
            set
            {
                this.FreeBelow.Visible = value;
            }
        }
        
        private void tabPages_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //}
            //catch (Exception ex)
            //{
            //    qs2.core.generic.getExep(ex.ToString(), ex.Message);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
        private void tabPages_VisibleChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //}
            //catch (Exception ex)
            //{
            //    qs2.core.generic.getExep(ex.ToString(), ex.Message);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        private void contAutoUI_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnChangeHistorieStay_LabelCLicked(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openHistory();
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
        public void openHistory()
        {
            try
            {
                dsProtocol dsProtocolRead = new dsProtocol();
                qs2.core.vb.sqlProtocoll sqlProtocollRead = new qs2.core.vb.sqlProtocoll();
                sqlProtocollRead.initControl();
                string SqlCommand = "";
                sqlProtocollRead.getProtocol(System.Guid.Empty, ref dsProtocolRead, sqlProtocoll.eSelProtocoll.IDStay, "", System.Guid.Empty, 
                                            this.rStayRead.ID, this.rStayRead.IDParticipant, "", null , null, "", ref SqlCommand, true);

                string sAdmDt = "";
                if (!this.rStayRead.IsAdmitDtNull())
                {
                    sAdmDt = " (" + this.rStayRead.AdmitDt.ToString("dd.MM.yyyy") + ")"; ;
                }
                string sAdditionalText = this.rStayRead.MedRecN + sAdmDt;
                qs2.design.auto.ui.openTableViewer(dsProtocolRead, "ChangeHistoryStay", sAdditionalText, this.OwnLicense.OwnParticipant, this.OwnLicense.OwnApplication.ToString(),
                                                    dsProtocolRead.Protocol.TableName, qs2.ui.print.contTable.eTypeUI.History, false);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        private void timerCheckProtocol_Tick(object sender, EventArgs e)
        {
            try
            {
                //System.Windows.Forms.Application.DoEvents();
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
                if (qs2.core.Protocol.nrOfError > 0)
                {
                    this.dropDownErrors.Visible = true;
                    this.dropDownErrors.Text = "Errors: " + qs2.core.Protocol.nrOfError.ToString() + "";
                }
                else
                {
                    this.dropDownErrors.Visible = false;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void lblErrors_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(true);
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

        public void infoMonitoring()
        {
            try
            {
                qs2.core.vb.frmProtocol frmMonitoring1 = new qs2.core.vb.frmProtocol();
                frmMonitoring1.ContProtocol1.TypeProtocolWindow = contProtocol.eTypeProtocolWindow.monitoring;
                frmMonitoring1.initControl();

                frmMonitoring1.ContProtocol1.lblMonitoring.Visible = true;
                frmMonitoring1.ContProtocol1.lblTitleError.Visible = false;
                frmMonitoring1.ContProtocol1.pictureBoxError.Visible = false;
                frmMonitoring1.Text = "Info Monitoring";
                qs2.core.ENV.lstOpendChildForms.Add(frmMonitoring1);
                frmMonitoring1.Show();
                frmMonitoring1.ContProtocol1.setText(qs2.core.Protocol.MonitoringOutput.Trim());
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRunQuery(int IDSelList, ref string protocollForAdmin, ref bool ProtocolWindow)
        {
            try
            {
                if (this.frmQryRunReport1 == null)
                {
                    this.frmQryRunReport1 = new qs2.ui.print.frmQryRunReport();
                    qs2.core.ENV.lstOpendChildForms.Add(this.frmQryRunReport1);
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    var tSelListObjQry = (from s in db.tblSelListEntries
                                        join sobj in db.tblSelListEntriesObj on s.ID equals sobj.IDSelListEntrySublist
                                        where s.ID == IDSelList && sobj.typIDGroup == "Queries"
                                select new
                                {
                                    sobj.IDSelListEntry
                                });
                    var rSelListQry = tSelListObjQry.First();
                    
                    dsAdmin dsAdminTmp1 = new dsAdmin();
                    sqlAdmin sqAdminTmp1 = new sqlAdmin();
                    sqAdminTmp1.initControl();

                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesDocu = sqAdminTmp1.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), this.rStayRead.IDApplication, ref dsAdminTmp1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDRam, "", -1, "", rSelListQry.IDSelListEntry);
                    dsAdmin.tblSelListEntriesRow rSeListDocu = arrSelListEntriesDocu[0];

                    dsAdmin dsAdminTmp2 = new dsAdmin();
                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters2 = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesReport = sqAdminTmp1.getSelListEntrys(ref Parameters2, "", qs2.core.license.doLicense.eApp.ALL.ToString(), this.rStayRead.IDApplication, ref dsAdminTmp2, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDRam, "", -1, "", IDSelList);
                    dsAdmin.tblSelListEntriesRow rSeListReport = arrSelListEntriesReport[0];

                    this.frmQryRunReport1.Visible = false;
                    this.frmQryRunReport1.Top = -300;
                    this.frmQryRunReport1.Left = -300;
                    this.frmQryRunReport1.Height = 30;
                    this.frmQryRunReport1.Width = 30;
                    this.frmQryRunReport1.ShowInTaskbar = false;
                    this.frmQryRunReport1.contQryRunReport1.typRunQuery = qs2.core.Enums.eTypRunQuery.DocumentGroups;
                    this.frmQryRunReport1.contQryRunReport1.rowGridSelList = null;
                    this.frmQryRunReport1.initControl(this.rStayRead.IDApplication, this.rStayRead.IDParticipant);
                    this.frmQryRunReport1.loadRes();
                    this.frmQryRunReport1.loadTitleWindow(rSeListDocu.IDRessource);
                    this.frmQryRunReport1.contQryRunReport1.isStayReport = true;
                    this.frmQryRunReport1.contQryRunReport1.IDGuid = this.rStayRead.IDGuid;
                    this.frmQryRunReport1.run(null, rSeListDocu, this.rStayRead.IDApplication, this.rStayRead.IDParticipant, ref protocollForAdmin, ref ProtocolWindow);
                    this.frmQryRunReport1.contQryRunReport1.infoReport.rSelListReport = rSeListReport;
                    this.frmQryRunReport1.Show();
                    this.frmQryRunReport1.Visible = false;

                    bool viewIsFunction = false;
                    System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                    this.frmQryRunReport1.contQryRunReport1.doReportQuery(false, this.frmQryRunReport1.contQryRunReport1.chkDoQueryReportExtern.Checked, ref viewIsFunction,
                                                                                ref lstParForExternFct, false, this.frmQryRunReport1.contQryRunReport1.chkFRDesignMode.Checked,
                                                                                this.frmQryRunReport1.contQryRunReport1.chkOLAP.Checked);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void contAutoProtokoll1_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeHistorieStay_Load(object sender, EventArgs e)
        {

        }

        private void cboPrintDocuments_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void dropDownAssigns_Click(object sender, EventArgs e)
        {

        }
    }
}
