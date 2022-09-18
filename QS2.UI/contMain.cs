using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using System.Diagnostics;
using System.Resources;




namespace qs2.ui
{


    public partial class contMain  : UserControl 
    {



        public enum eStatusBar
        {
            user = 33800,
            sys = 33801,
            protocol = 33802,
            Monitoring = 33803,
            Warning = 33804,
            AutoLock = 33805
        }

        public delDoMainFct onDoMainFct;
        public delegate bool delDoMainFct(eTypDoMainFct typ);
        public enum eTypDoMainFct
        {
            close = 0,
            openModulCommunication = 1,
        }

        public frmMain mainWindow = null;
        public bool AskForCloseApp = true;
        public businessFramework buisLogAdmin1 = new businessFramework();
        public static DateTime lastActivityUser = DateTime.Now;
        public static bool AppIsLocked = false;

        public contMain()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void initControl(string MedRecNrAutoStart, string ParticipantAutoStart, string ApplicationAutoStart)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                qs2.design.auto.ownMCCriteria.initSharedDataSets(true);

                qs2.core.ENV.MainForm = this.mainWindow;
                this.contMainTop1.mainWindow = this;
                this.contMainTop1.initControl();

                this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                this.doPicMainTab();
                this.mainWindow.ultraToolbarsManagerMain.Ribbon.Caption = qs2.core.language.sqlLanguage.getRes("QS2");  // + " - " + qs2.core.language.sqlLanguage.getRes(qs2.core.license.doLicense.rApplication.IDApplication);

                this.ultraStatusBar1.Panels[eStatusBar.user.ToString()].Text = qs2.core.language.sqlLanguage.getRes("User") + ": " + qs2.core.vb.actUsr.rUsr.UserName;
                //this.ultraStatusBar1.Panels[eStatusBar.user.ToString()].Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_User, 32, 32 );
                this.ultraStatusBar1.Panels[eStatusBar.user.ToString()].Tag = qs2.core.vb.actUsr.rUsr;
                this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Text = qs2.core.language.sqlLanguage.getRes("Protocol");

                this.copyWatchToClipboardToolStripMenuItem.Text = "Open watch-protocol";

                if (qs2.core.vb.actUsr.loggedInAsWindowsUser)
                {
                    this.ultraStatusBar1.Panels[eStatusBar.user.ToString()].ToolTipText = qs2.core.language.sqlLanguage.getRes("loggedInAsWindowsUser") + qs2.core.generic.lineBreak +
                                                                                          qs2.core.language.sqlLanguage.getRes("UserWindows") + ": " + qs2.core.vb.actUsr.rUsr.UserNameDomain + qs2.core.generic.lineBreak +
                                                                                          qs2.core.language.sqlLanguage.getRes("Domain") + ": " + qs2.core.ENV.Domäne;
                }

                if (qs2.core.vb.actUsr.rUsr.isAdmin || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.buildNativeImagesToolStripMenuItem.Visible = true;
                    this.uninstallNativeImagesToolStripMenuItem.Visible = true;

                    this.styleAppToolStripMenuItem.Visible = true;
                    this.ultraStatusBar1.Panels[eStatusBar.sys.ToString()].Text = "              " + "Info";

                    this.ultraStatusBar1.Panels[eStatusBar.sys.ToString()].ToolTipText = qs2.core.language.sqlLanguage.getRes("Participant") + ": " + qs2.core.license.doLicense.rParticipant.IDParticipant + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("VersionQS2") + ": " + qs2.core.ENV.AssemblyVersion + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("VersionDB") + ": " + qs2.core.ENV.DBVersionFromDatabase  + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("Path") + ": " + qs2.core.ENV.path_bin + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("Database") + ": " + qs2.core.ENV.Database + " (" + qs2.core.language.sqlLanguage.getRes("Trusted") + ":" + (qs2.core.ENV.TrustedConnection ? "1" : "0") + ")" + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("ServerDatabase") + ": " + qs2.core.ENV.Server + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("typeLoading") + ": " + qs2.core.ENV.typeLoading.ToString() + qs2.core.generic.lineBreak +
                                                                                            qs2.core.language.sqlLanguage.getRes("ActiveLanguage") + ": " + qs2.core.language.sqlLanguage.getRes(qs2.core.ENV.language.ToString());

                    if (qs2.core.ENV.IsHeadquarter)
                    {
                        this.ultraStatusBar1.Panels[eStatusBar.sys.ToString()].ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("IsHeadquarter");
                    }

                    if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        if (qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev)
                        {
                            //this.contMainTop1.BackColor = System.Drawing.Color.Yellow;
                            this.contMainTop1.lblInfoQS2_Dev.Visible = true;
                        }
                        else
                        {
                            this.contMainTop1.lblInfoQS2_Dev.Visible = false;
                        }
                    }
                }
                else
                {
                    this.buildNativeImagesToolStripMenuItem.Visible = false;
                    this.uninstallNativeImagesToolStripMenuItem.Visible = false;

                    this.ultraStatusBar1.Panels[eStatusBar.user.ToString()].Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Text;
                    this.ultraStatusBar1.Panels[eStatusBar.sys.ToString()].Visible = false;
                    this.styleAppToolStripMenuItem.Visible = false;
                }
                if (qs2.core.ENV.protocolAllTranslationErrors)
                {
                    this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Visible = false;    
                    this.timerCheckProtocol.Enabled = true;
                    this.timerCheckProtocol.Start();
                }
                else
                {
                    this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Visible = false;
                    this.timerCheckProtocol.Enabled = false;
                    this.timerCheckProtocol.Stop();
                }

                if (qs2.core.ENV.monitoring)
                {
                    this.ultraStatusBar1.Panels[eStatusBar.Monitoring.ToString()].Visible = false;
                    this.timerMonitoring.Enabled = true;
                    this.timerMonitoring.Start();
                }
                else
                {
                    this.ultraStatusBar1.Panels[eStatusBar.Monitoring.ToString()].Visible = false;
                    this.timerMonitoring.Enabled = false;
                    this.timerMonitoring.Stop();
                }
                this.loadRes();
                this.readRights();
                this.doAutoStart(MedRecNrAutoStart, ParticipantAutoStart, ApplicationAutoStart);
                this.loadAllAddIns();
                this.buisLogAdmin1.AutoDelete();

                qs2.ui.mainApps.mainUI = this;
                qs2.core.ENV.eCallFunctionMain += new core.ENV.dCallFunctionMain(mainApps.CallFunctionMain);

                if (qs2.core.ENV.LockAfterMinutesInactivity > 0)
                {
                    contMain.lastActivityUser = DateTime.Now;
                    this.timerLockAutomatically.Enabled = true;
                    this.timerLockAutomatically.Start();
                }
                else
                {
                    this.timerLockAutomatically.Enabled = false;
                    this.timerLockAutomatically.Stop();
                }
            }
            catch (Exception ex)
            {
                this.ResumeLayout();
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

     
        public void doAutoStart(string MedRecNrAutoStart, string ParticipantAutoStart, string ApplicationAutoStart)
        {
            bool bSearchWasRun = false;
            bool bQueriesWasRun = false;

            object oAppToStart = actUsr.adjustRead(qs2.core.vb.actUsr.rUsr.UserName, sqlAdmin.eAdjust.applicationAutoStart, sqlAdmin.eTypSelAdjust.forUsr, "");
            if (oAppToStart != null)
            {
                if (oAppToStart.ToString() == qs2.core.Enums.eApplicationAutoStart.UserDefinedQueries.ToString())
                {
                    if (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueries, false))
                    {
                        this.doControl(core.ENV.eTypApp.contQuerysRun, "", "", "");
                        bQueriesWasRun = true;
                    }
                    else
                    {
                        this.doControl(core.ENV.eTypApp.contSearch, MedRecNrAutoStart, ParticipantAutoStart, ApplicationAutoStart);
                        bSearchWasRun = true;
                    }
                }
            }
            else
            {
                this.doControl(core.ENV.eTypApp.contSearch, MedRecNrAutoStart, ParticipantAutoStart, ApplicationAutoStart);
                bSearchWasRun = true;
            }

            if (bSearchWasRun)
            {
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.contMainTop1.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnDocuments, core.ui.eButtonType.Main);
            }
            else if (bQueriesWasRun)
            {
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.contMainTop1.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.contMainTop1.btnDocuments, core.ui.eButtonType.Main);
            }

        }
        public bool loadAllAddIns()
        {
            try
            {
                qs2.core.vb.dsAddIn dsAddInFound = new qs2.core.vb.dsAddIn ();
                qs2.core.vb.AddIn AddIn1 = new qs2.core.vb.AddIn();
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }

        public void loadRes()
        {
            try
            {
                this.mainWindow.ultraToolbarsManagerMain.Ribbon.TabItemToolbar.NonInheritedTools[0].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("About");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ManageUsers");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoLicense.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("InfoLicense");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRessourcen.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("RessourcenManager");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("CriteriasManager");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRelations.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Relations");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAdjustments.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Adjustments");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAddIns.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("AddInManager");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSelLists.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("SelectionLists");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contManageUserQueries.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("QueriesUser");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerQuerysAdmin.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("QuerysAdmin");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSysDatabase.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("infoFieldSQLServer");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerManagementProducts.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ManagementProducts");
               
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contTexteditor.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Texteditor");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnProtocoll.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Protocol");

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctNewLogOn.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("NewLogIn");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctChangePassword.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ChangePassword");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctLock.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("LockApplication");
                
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fktClose.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Close");

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.poUpOthers.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Others2");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnMergingPatients.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("MergingPatients");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnMergeUserAccounts.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("MergeUserAccounts");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnInsertSelListFromClipboard.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("InsertSelListFromClipboard");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnRunQueryFromClipboard.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("RunQueryFromClipboard");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnProtocolStays.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ProtocolStays");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnEditCriteriaDefaultValues.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("btnEditCriteriaDefaultValues");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnCopyStays.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("CopyStays");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnDeletePatients.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("DeletePatients");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnDeleteStays.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("DeleteStays");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnCopyStaysParticipant.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("CopyStaysParticipant");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnImportHelpFromExcel.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ImportHelpFromExcel");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnNewProduct.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("NewProduct");

                this.buildNativeImagesToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("buildNativeImages");
                this.uninstallNativeImagesToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("uninstallNativeImages");

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnManageDeathStatus.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ManageDeathStatus");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnImportStays.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ImportStays");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnExportCriteriasToExcel.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ExportCriteriasToExcel");
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnAdjustmentQTHDb.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("AdjustmentQTHDb");

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void readRights()
        {
            try
            {
                if (!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueries, false))
                {
                    this.contMainTop1.btnQueries.Visible = false;
                }

                if (!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightReports, false))
                {
                    this.contMainTop1.btnReports.Visible = false;
                }

                if ((!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightPrintDocuments, false) && 
                    !qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightEditDocuments, false)) ||
                    !qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS).bValue)
                {
                    this.contMainTop1.btnDocuments.Visible = qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS_VALID_DATE).dValue > DateTime.Now ? true : false;
                }

                if (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageUsers, false))
                {
                    this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = true;
                }
                else
                {
                    this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = true;
                }

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageUsers, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() || qs2.core.vb.actUsr.IsSuperadmin());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAddIns.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAdjustments.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSettings, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoLicense.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightLicenseInformation, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerManagementProducts.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightServicesAndInterfaces, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSelLists.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSelectLists, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contManageUserQueries.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueries, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()); ;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerQuerysAdmin.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRessourcen.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageResources, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageCriterias, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRelations.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageRelationships, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSysDatabase.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightInformationSQLColumns, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contTexteditor.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightTextEditor, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnProtocoll.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rigthProtocoll, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerLogManager.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightLogManager, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctLock.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightLockApplication, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctChangePassword.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightChangePassword, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctNewLogOn.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightLoginNewUser, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.poUpOthers.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSettings, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnAdjustmentQTHDb.ToString()].SharedProps.Visible = string.Equals(qs2.core.license.doLicense.rApplication.IDApplication.Trim(), qs2.core.license.doLicense.eApp.QTH.ToString(), StringComparison.InvariantCultureIgnoreCase) && qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageQueries, false);

                if (qs2.core.vb.actUsr.rUsr.isAdmin && !qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = true;
                }
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnDeletePatients.ToString()].SharedProps.Visible = (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightDeletePatient, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor());
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnCopyStaysParticipant.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnImportHelpFromExcel.ToString()].SharedProps.Visible = true;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnImportHelpFromExcel.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnNewProduct.ToString()].SharedProps.Visible = qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void doPicMainTab()
        {
            try
            {
                this.mainWindow.Icon = getRes.getIcon(QS2.Resources.getRes.Launcher.ico_QS2 , 32, 32);

                this.contMainTop1.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32);
                this.contMainTop1.btnQueries.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Evaluierung, 32, 32);
                this.contMainTop1.btnReports.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Uebergabe, 32, 32);
                this.contMainTop1.btnDocuments.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Planung, 32, 32);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doSupervisor(bool bOn)
        {
            try
            {
                this.contMainTop1.btnQueries.Visible = bOn;
                this.contMainTop1.btnReports.Visible = bOn;
                this.contMainTop1.btnDocuments.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = bOn;

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAddIns.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerAdjustments.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoLicense.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerManagementProducts.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSelLists.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contManageUserQueries.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerQuerysAdmin.ToString()].SharedProps.Visible = bOn;

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRessourcen.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerRelations.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerSysDatabase.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contTexteditor.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.btnProtocoll.ToString()].SharedProps.Visible = bOn;

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.QS2PopUpContainerLogManager.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctLock.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctChangePassword.ToString()].SharedProps.Visible = bOn;
                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.fctNewLogOn.ToString()].SharedProps.Visible = bOn;

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.poUpOthers.ToString()].SharedProps.Visible = bOn;

                this.mainWindow.ultraToolbarsManagerMain.Tools[qs2.core.ENV.eTypApp.contInfoUsers.ToString()].SharedProps.Visible = bOn;

                if (bOn)
                {
                    sqlObjects sqlObjectsAutoLogIn = new sqlObjects();
                    sqlObjectsAutoLogIn.initControl();
                    dsObjects.tblObjectRow rObjAutoLogIn = sqlObjectsAutoLogIn.getObjectRow(-99, sqlObjects.eTypSelObj.UserName, sqlObjects.eTypObj.IsUser, "", qs2.core.vb.sqlObjects.userName_Supervisor.Trim());
                    if (rObjAutoLogIn != null)
                    {
                        qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                        string PasswordDBDecrypted = (String.IsNullOrWhiteSpace(rObjAutoLogIn.Password) ? "" : Encryption1.StringDecrypt(rObjAutoLogIn.Password, qs2.license.core.Encryption.keyForEncryptingStrings));
                    }
                    else
                    {
                        qs2.core.generic.showMessageBox("Can not LogIn as Supervisor! Supervisor not found in DB!", System.Windows.Forms.MessageBoxButtons.OK, "Error");
                    } 
                }

                if (qs2.ui.mainApps.contQueriesRun != null)
                {
                    qs2.ui.mainApps.contQueriesRun.contQryRunPar1.ultraToolbarsManager1.Visible = bOn;
                }
                if (qs2.ui.mainApps.contReportsRun != null)
                {
                    qs2.ui.mainApps.contReportsRun.contQryRunPar1.ultraToolbarsManager1.Visible = bOn;
                }
                if (qs2.ui.mainApps.contDocumentsRun != null)
                {
                    qs2.ui.mainApps.contDocumentsRun.contQryRunPar1.ultraToolbarsManager1.Visible = bOn;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doSupervisor: " + ex.ToString());
            }
        }

        public  void ultraToolbarsManagerMainToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if ((e.Tool.GetType().Equals(typeof(Infragistics.Win.UltraWinToolbars.ButtonTool))) ||  (e.Tool.GetType().Equals(typeof(Infragistics.Win.UltraWinToolbars.StateButtonTool ))))
                {
                    this.searchToolClicked(e.Tool.Key);
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

        public void searchToolClicked(string key)
        {
            //qs2.core.ui.unvisibleAllTabs(this.tabMain);
            foreach (int val in Enum.GetValues(typeof(qs2.core.ENV.eTypApp)))
            {
                if (key == Enum.GetName(typeof(qs2.core.ENV.eTypApp), val))
                {
                    qs2.core.ENV.eTypApp typFound = new qs2.core.ENV.eTypApp();
                    typFound = (qs2.core.ENV.eTypApp)val;
                    this.doControl(typFound, "", "", "");
                }
            }
        }

        public void doControl(qs2.core.ENV.eTypApp typFound, string MedRecNrAutoStart, string ParticipantAutoStart, string ApplicationAutoStart)
        {
            try
            {
                if (typFound == qs2.core.ENV.eTypApp.contQuerysRun)
                {
                    if (qs2.ui.mainApps.contQueriesRun == null)
                    {
                        qs2.ui.mainApps.contQueriesRun = new qs2.ui.pint.contQryRun();
                        this.setControlToTab(typFound, qs2.ui.mainApps.contQueriesRun);
                        qs2.ui.mainApps.contQueriesRun.typRunQuery = qs2.core.Enums.eTypRunQuery.QueryGroups;
                        qs2.ui.mainApps.contQueriesRun.defaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        qs2.ui.mainApps.contQueriesRun.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        qs2.ui.mainApps.contQueriesRun.initControl(qs2.core.license.doLicense.rApplication.IDApplication.ToString(), true);
                    }
                    qs2.ui.mainApps.contQueriesRun.refreshControl();
                    qs2.core.ui.setTabVisible(this.tabMain, typFound.ToString());
                }
                else if (typFound == qs2.core.ENV.eTypApp.contQuerysUser)
                {
                    if (qs2.ui.mainApps.contQryAdminUsr == null)
                    {
                        qs2.ui.mainApps.contQryAdminUsr = new qs2.ui.print.contQryAdmin();
                        this.setControlToTab(typFound, qs2.ui.mainApps.contQryAdminUsr);
                        qs2.ui.mainApps.contQryAdminUsr.typeQuery = core.Enums.eTypeQuery.User;
                        qs2.ui.mainApps.contQryAdminUsr.DefaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        qs2.ui.mainApps.contQryAdminUsr.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        qs2.ui.mainApps.contQryAdminUsr.initControl(qs2.ui.mainApps.contQryAdminUsr.DefaultApplication);
                        qs2.ui.mainApps.contQryAdminUsr.loadQueries(null,true, true);
                    }
                    qs2.ui.mainApps.contQryAdminUsr.refreshControl();
                    qs2.core.ui.setTabVisible(this.tabMain, typFound.ToString());
                } 
            }
             catch (Exception ex)
             {
                 throw new Exception("contMain.doControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
             }
        }

        public   void setControlToTab(qs2.core.ENV.eTypApp typFound,  Control  cont )
        {
            this.tabMain.Tabs[typFound.ToString()].TabPage.Controls.Add(cont);
            cont.Dock = DockStyle.Fill;
            cont.BackColor = System.Drawing.Color.Transparent;
        }

        private void ultraStatusBar1_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.ultraToolbarsManagerMain.Ribbon.ApplicationMenu.CloseUp();
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

        public bool mainFormClosing()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.AskForCloseApp)
                {
                    if (!qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("CloseApplication") + "?", MessageBoxButtons.YesNo, "") == System.Windows.Forms.DialogResult.No)
                        {
                            return false;
                        }
                    }
                    qs2.core.vb.frmActivity.ShowSplashScreen(qs2.core.language.sqlLanguage.getRes("ClosingApp"), frmActivity.eTypeUI.Main);
                    System.Collections.Generic.List<Form> lstFormsToDispose = new List<Form>();
                    foreach (Form frm in qs2.core.ENV.lstOpendChildForms)
                    {
                        if (frm != null)
                        {
                            frm.Close();
                            lstFormsToDispose.Add(frm);
                            Application.DoEvents();
                        }
                    }
                    foreach (Form frm in lstFormsToDispose)
                    {
                        frm.Dispose();
                        Application.DoEvents();
                    }

                    qs2.core.vb.funct.clearDirTemp();
                }
                else
                {
                    qs2.core.vb.frmActivity.ShowSplashScreen(qs2.core.language.sqlLanguage.getRes("ClosingApp"), frmActivity.eTypeUI.Main);
                }

                using (qs2.core.vb.Protocol Protocol1 = new core.vb.Protocol())
                {
                    string sProt = "User '" + qs2.core.vb.actUsr.rUsr.UserShort + "' logged out at '" + DateTime.Now.ToString() + "'!" + qs2.core.generic.lineBreak +
                                    "Application: " + qs2.core.license.doLicense.rApplication.IDApplication.Trim() + "" + qs2.core.generic.lineBreak +
                                    "Participant: " + qs2.core.license.doLicense.rParticipant.IDParticipant.Trim() + "" + qs2.core.generic.lineBreak +
                                    "Computer-Name: " + Environment.MachineName.Trim() +
                                    "Windows-User: " + Environment.UserDomainName + @"\" + Environment.UserName.Trim();
                    Protocol1.WriteEventLog(sProt);
                    Protocol1.save2(core.vb.Protocol.eTypeProtocoll.LoggedOut, System.Guid.Empty, -999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(),
                                    qs2.core.license.doLicense.rApplication.IDApplication.Trim(), "", sProt.Trim(), core.vb.Protocol.eActionProtocol.None, "", "");
                }

                qs2.core.threadStayUI.QS2ClosedByUser = true;
                qs2.core.vb.frmActivity.CloseSplashScreen();
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.vb.frmActivity.CloseSplashScreen();
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

         private void timerCheckProtocol_Tick(object sender, EventArgs e)
         {
             try
             {
                 if (qs2.core.Protocol.nrOfError > 0)
                 {
                     this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Visible = true;
                     this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Text = qs2.core.language.sqlLanguage.getRes("Protocol") + "  (" + qs2.core.Protocol.nrOfError.ToString() + ") ";
                 }
                 else
                 {
                     this.ultraStatusBar1.Panels[eStatusBar.protocol.ToString()].Visible = false;
                 }
             }
             catch (Exception ex)
             {
                 qs2.core.generic.getExep(ex.ToString(), ex.Message);
             }
         }
            
         private void styleAppToolStripMenuItem_Click(object sender, EventArgs e)
         {
             try
             {
                this.mainWindow.appStylistRuntime1.ShowRuntimeApplicationStylingEditor(this.mainWindow, "AppStylist Run-time");

             }
             catch (Exception ex)
             {
                 qs2.core.generic.getExep(ex.ToString(), ex.Message);
             }
         }

         private void logInAsSupervisorToolStripMenuItem_Click(object sender, EventArgs e)
         {
             try
             {
                this.Cursor = Cursors.WaitCursor;
                qs2.design.auto.ui.RestartAs("Supervisor", -999, "", "", "", "QS2", -1, "");

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


         private void buildNativeImagesToolStripMenuItem_Click(object sender, EventArgs e)
         {
             try
             {
                 this.Cursor = Cursors.WaitCursor;
                 qs2.core.SelfNgenPoC.start(true);
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
         private void uninstallNativeImagesToolStripMenuItem_Click(object sender, EventArgs e)
         {
             try
             {
                 this.Cursor = Cursors.WaitCursor;
                 qs2.core.SelfNgenPoC.start(false);
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
            
         private void contMainTop1_Load(object sender, EventArgs e)
         {
         }

         private void logInAsSupervisorWithoutNewStartToolStripMenuItem_Click(object sender, EventArgs e)
         {
             try
             {
                 this.Cursor = Cursors.WaitCursor;

                 qs2.ui.vb.frmLockApplication frmLockApplication1 = new vb.frmLockApplication();
                 frmLockApplication1.checkSupervisorPwd = true;
                 frmLockApplication1.ShowDialog(this);
                 if (frmLockApplication1.PwdOK)
                 {
                     this.doSupervisor(true);
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

        private void contMain_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void copyWatchToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.core.vb.ui.getWatchProtokoll();

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
    }
}
