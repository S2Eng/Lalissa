using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;
using QS2.Resources;
using static qs2.core.vb.businessFramework;

namespace qs2.ui.pint
{



    public partial class contQryRun : UserControl
    {
        
        public bool isLoaded = false;
        public string defaultApplication = "";
        public string IDParticipant = "";
        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();

        public int ImageSizeWidth = 128;
        public int ImageSizeHeigth = 128;
        public int ButtonWidth = 145;
        private int ButtonHeigth = 190;
        private int ButtonHeigthSmall = 50;

        public qs2.core.Enums.eTypRunQuery typRunQuery = new qs2.core.Enums.eTypRunQuery();
        public dsAdmin dsAdmin2 = new dsAdmin();

        public drawReportGroups drawReportGroups1 = new drawReportGroups();
        public static bool lockRefreshButton = false;

        public bool IsInFront = false;
        public qs2.ui.print.frmQryRunReport frmQryRunReport1 = null;

        public bool firstLoadGroupsIsDone = false;

        public class cButton
        {
            public dsAdmin.tblSelListEntriesObjRow rObj = null;
            public dsAdmin.tblSelListEntriesRow rSelListEntryFound = null;
            public dsAdmin.tblSelListEntriesRow rSelListEntrySubListFound = null;
            public string TranslatedTxt = "";
        }

        public qs2.core.db.ERSystem.businessFramework b2 = new core.db.ERSystem.businessFramework();
        public qs2.core.vb.businessFramework b = new businessFramework();

        public qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new design.auto.workflowAssist.autoForm.AutoControlsUI();
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new design.auto.workflowAssist.autoForm.ColorSchemas();

        public Panel actGroupPanel = null;
        public Infragistics.Win.Misc.UltraButton actGroupButt = null;
        public bool FirstVisibleDone = false;


        public enum eTypActionReports
        {
            Visible = 0,
            buttInaktive = 1
        }

        public class tgReportButton
        {
            public System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow> rSelListsQry = new System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow>();
            //public System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow> rSelListGroups = new System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow>();
            public dsAdmin.tblSelListEntriesRow rSelListGroup = null;
          
            public System.Collections.Generic.List<dsAdmin.tblSelListEntriesObjRow> rSelListObjs = new System.Collections.Generic.List<dsAdmin.tblSelListEntriesObjRow>();
            public dsAdmin.tblSelListEntriesRow rSelListsReports = null;
        }
        
        public enum eTypToolbar
        {
            ReportGroups = 0,
            Reports = 1,
            Queries = 2,
            QueryGroups = 3,
            btnManageQueries = 4,
            btnAssignSubqueries = 5,
            DocumentGroups = 6,
            Documents = 7
        }

        public dsAdmin dsAdminTmp3 = new dsAdmin();
        public sqlAdmin sqlAdminTmp3 = new sqlAdmin();

        public System.Collections.Generic.List<cSelListAndObj> lstRolesForUserActive = new System.Collections.Generic.List<cSelListAndObj>();









        public contQryRun()
        {
            InitializeComponent();
        }

        private void contQueryRun_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string TmpApplication, bool showCmbApplication)
        {
            try
            {
                if (this.isLoaded) return;

                this.defaultApplication = TmpApplication;

                this.sqlAdmin1.initControl();
                this.loadRes();
                bool onlyLicensedProducts = true;
                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    onlyLicensedProducts = false;
                }
                this.comboApplication1.initControlxy(false, onlyLicensedProducts, false);
                this.comboApplication1.setApplication(this.defaultApplication);
                this.comboApplication1.Visible = showCmbApplication;

                if (this.IsInFront)
                {
                    this.ImageSizeWidth = 60;
                    this.ImageSizeHeigth = 35;
                    this.ButtonWidth = 145;
                    this.ButtonHeigth = 110;
                }
                else
                {

                }

                this.contQryRunPar1.typRunQuery = this.typRunQuery;
                this.contQryRunPar1.initControl(defaultApplication, this.IDParticipant);

                //this.loadGroups(this.defaultApplication);

                if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups || this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                {
                    this.panelTopLeft.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageQueries, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageQueries, false);
                }
                else if (this.typRunQuery == core.Enums.eTypRunQuery.DocumentGroups)
                {
                    this.panelTopLeft.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageQueries, false) || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor();
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightEditDocuments, false);
                }

                if ( qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Reports.ToString()].SharedProps.Visible = true;
                }
                else
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Reports.ToString()].SharedProps.Visible = false;
                }


                if (qs2.core.license.doLicense.rApplication.IDApplication.Trim().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.btnManageQueries.ToString()].SharedProps.Visible = false;
                }

                this.sqlAdminTmp3.initControl();
                b.getAllRolesForUser(actUsr.rUsr.ID, ref lstRolesForUserActive, false);

                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                throw new Exception("initControl: " + ex.ToString());
            }
        }
        public void loadRes()
        {
            try
            {
                this.btnRefresh.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("Refresh");

                this.toolbarsManagerAdmin.Tools[eTypToolbar.btnManageQueries.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ManageQueries");                
                this.toolbarsManagerAdmin.Tools[eTypToolbar.Reports.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes(eTypToolbar.Reports.ToString());
                this.toolbarsManagerAdmin.Tools[eTypToolbar.Documents.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Documents");

                if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Visible = false;
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes(eTypToolbar.QueryGroups.ToString());
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Reports.ToString()].SharedProps.Visible = false;
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Documents.ToString()].SharedProps.Visible = false;
                }
                else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups)
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes(eTypToolbar.ReportGroups.ToString());
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Documents.ToString()].SharedProps.Visible = false;
                }
                else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.DocumentGroups)
                {
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Visible = false;
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Reports.ToString()].SharedProps.Visible = false;

                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightEditDocuments, false);
                    this.toolbarsManagerAdmin.Tools[eTypToolbar.ReportGroups.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes(eTypToolbar.DocumentGroups.ToString());

                    this.toolbarsManagerAdmin.Tools[eTypToolbar.Documents.ToString()].SharedProps.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightEditDocuments, false);
                }

                this.toolbarsManagerAdmin.Tools[eTypToolbar.btnAssignSubqueries.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("AssignSubqueries");
                this.toolbarsManagerAdmin.Tools[eTypToolbar.btnAssignSubqueries.ToString()].SharedProps.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("loadRes: " + ex.ToString());
            }

        }
        
        public void refreshControl()
        {
            try
            {
                //if (qs2.ui.print.contQryAdmin.dataChanged)
                //{
                //    this.loadGroups();
                //    qs2.ui.print.contQryAdmin.dataChanged = false;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("refreshControl: " + ex.ToString());
            }
        }

        public void loadGroups(string Application)
        {
            try
            {
                this.firstLoadGroupsIsDone = true;
                this.defaultApplication = Application;

                this.dsAdmin1.tblSelListEntries.Rows.Clear();
                this.doTabsUI(false, eTypActionReports.Visible);

                this.contQryRunPar1.popUpService.SharedProps.Visible = false;
                this.contQryRunPar1.popUpQueries.SharedProps.Visible = false;
                this.contQryRunPar1.setVisibleMultiControls(false);

                this.contQryRunPar1.contSelListQueries1.clearData();
                this.contQryRunPar1.setUIQuery(false);
                //this.contQryRunPar1.panelNoQuery.Visible = false;
                
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                this.sqlAdmin1.getSelListEntrys(ref Parameters, this.typRunQuery.ToString(), this.IDParticipant, this.getSelectedApplication(), ref this.dsAdmin1, sqlAdmin.eTypAuswahlList.groupParticipantOwnOrAll);
                if (!this.dsAdmin1.tblSelListEntries.Columns.Contains(qs2.core.generic.columnParameterLabelTranslated))
                {
                    this.dsAdmin1.tblSelListEntries.Columns.Add(qs2.core.generic.columnParameterLabelTranslated, typeof(string));
                }

                foreach (dsAdmin.tblSelListEntriesRow rSelListGroup in this.dsAdmin1.tblSelListEntries)
                {
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    string resFoundLevel = qs2.core.language.sqlLanguage.getRes(rSelListGroup.IDRessource, core.Enums.eResourceType.Label, this.IDParticipant, this.getSelectedApplication(), ref  rLangFoundReturn);
                    if (resFoundLevel.Trim() == "")
                        rSelListGroup[qs2.core.generic.columnParameterLabelTranslated] = rSelListGroup.IDRessource;
                    else
                        rSelListGroup[qs2.core.generic.columnParameterLabelTranslated] = resFoundLevel;
                }

                foreach(Infragistics.Win.Misc.UltraButton btn in this.panelGroups.Controls)
                {
                    btn.Visible = false;
                }
                foreach (Panel pnl in this.panelTabs2.Controls)
                {
                    pnl.Visible = false;
                }
                this.actGroupButt = null;
                this.actGroupPanel = null;

                int HeigtButtonsTotal = 0;
                int diffTop = 2;
                int lastTop = 0;
                int diffRigth = 3;
                int lastRight = 0;
                int nrGrp = 0;
                lastTop = diffTop;

                Infragistics.Win.Misc.UltraButton prevBtnGroup = null;
                qs2.sitemap.workflowAssist.contListAssistentElem firstReportButt = null;
                dsAdmin.tblSelListEntriesRow[] arrSelListGroup = (dsAdmin.tblSelListEntriesRow[])this.dsAdmin1.tblSelListEntries.Select("", qs2.core.generic.columnParameterLabelTranslated + " asc");
                foreach (dsAdmin.tblSelListEntriesRow rSelListGroup in arrSelListGroup)
                {
                    Infragistics.Win.Misc.UltraButton newBtnGroup = null;
                    Panel newPnlGroup = null;

                    if (this.panelGroups.Controls.Count >= (nrGrp + 1))
                    {
                        newBtnGroup = (Infragistics.Win.Misc.UltraButton)this.panelGroups.Controls[nrGrp];
                        newPnlGroup = (Panel)this.panelTabs2.Controls[nrGrp];
                    }
                    else
                    {
                        newBtnGroup = new Infragistics.Win.Misc.UltraButton();
                        newBtnGroup.AutoSize = true;
                        newBtnGroup.BackColor = Color.Transparent;
                        this.panelGroups.Controls.Add(newBtnGroup);
                        newBtnGroup.Click += new System.EventHandler(this.clickGroupButton);

                        newPnlGroup = new Panel();
                        newPnlGroup.Dock = DockStyle.Fill;
                        newPnlGroup.BackColor = Color.Transparent;
                        this.panelTabs2.Controls.Add(newPnlGroup);
                        newPnlGroup.SizeChanged += new System.EventHandler(this.PanelGroups_SizeChanged);
                    }


                    Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
                    appearance1.FontData.SizeInPoints = 10F;
                    newBtnGroup.Appearance =  appearance1;

                    newBtnGroup.Text = rSelListGroup[qs2.core.generic.columnParameterLabelTranslated].ToString();
                    newBtnGroup.Name = rSelListGroup.IDRessource + nrGrp.ToString();

                    if ((lastRight + diffRigth + newBtnGroup.Width) > this.panelGroups.Width)
                    {
                        lastRight = 0;
                        lastTop += newBtnGroup.Height + diffTop;
                    }

                    newBtnGroup.Left = lastRight + diffRigth;
                    newBtnGroup.Top = lastTop;
                    newBtnGroup.Tag = rSelListGroup;
                    newBtnGroup.Visible = true;

                    lastRight = newBtnGroup.Left + newBtnGroup.Width;
                    HeigtButtonsTotal = lastTop + newBtnGroup.Height + diffTop;

                    newPnlGroup.Visible = false;
                    newPnlGroup.Tag = rSelListGroup;
                    newPnlGroup.Name = rSelListGroup.IDRessource + nrGrp.ToString();

                    if (this.actGroupButt == null)
                    {
                        this.actGroupButt = newBtnGroup;
                        this.actGroupPanel = newPnlGroup;
                    }
                    this.loadButtons(rSelListGroup, newBtnGroup, newPnlGroup, ref firstReportButt);
                    nrGrp += 1;
                    
                    this.resizeReportButt(newPnlGroup);
                    prevBtnGroup = newBtnGroup;
                }
                this.splitContainer1.SplitterDistance = HeigtButtonsTotal;

                //System.Windows.Forms.Application.DoEvents();
                this.setColorButtonGroupsInaktive();
                this.setColorQueryPanels();

                if (this.actGroupPanel != null)
                {
                    this.actGroupPanel.Visible = true;
                }
                this.doTabsUI(false, eTypActionReports.buttInaktive);

            }
            catch (Exception ex)
            {
                throw new Exception("loadGroups: " + ex.ToString());
            }
        }
        private void clickGroupButton(object sender, EventArgs e)
        {
            try
            {
                Infragistics.Win.Misc.UltraButton btnClicked = (Infragistics.Win.Misc.UltraButton)sender;
                this.actGroupButt = btnClicked;
                this.setColorButtonGroupsInaktive();
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.actGroupButt, core.ui.eButtonType.QueryGroups);
                
                this.actGroupPanel = null;
                foreach (Panel actPnl in this.panelTabs2.Controls)
                {
                    if (actPnl.Name.Trim().ToLower().Equals(btnClicked.Name.Trim().ToLower()))
                    {
                        actPnl.Visible = true;
                        this.actGroupPanel = actPnl;
                    }
                    else
                    {
                        actPnl.Visible = false;
                    }
                }

                this.setColorQueryButtonsInactive(this.actGroupPanel);
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRun.clickGroupButton: " + ex.ToString());
            }
        }

        public void setColorQueryPanels()
        {
            try
            {
                foreach (Panel pnlButtons in this.panelTabs2.Controls)
                {
                    this.ColorSchemas1.setAppearancePanelWin(pnlButtons, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUIPanelWin.PanelQueries, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setColorQueryPanels: " + ex.ToString());
            }
        }

   
        public void loadButtons(dsAdmin.tblSelListEntriesRow rSelListGroup, Infragistics.Win.Misc.UltraButton newBtnGroup,
                                Panel newPnlGroup, ref qs2.sitemap.workflowAssist.contListAssistentElem firstReportButt)
        {
            try
            {
                qs2.design.auto.ui ui1 = new design.auto.ui();
                SortedDictionary<string, cButton> dictButtons = new SortedDictionary<string, cButton>();
                ui1.loadButtons(rSelListGroup, newPnlGroup, this.typRunQuery, ref this.sqlAdmin1, ref this.dsAdmin1, 
                                this.getSelectedApplication(), this.IDParticipant, ref this.b2, ref this.b, ref dictButtons, false, ref lstRolesForUserActive);

                System.Drawing.Size sizeButton = new System.Drawing.Size(this.ImageSizeWidth, this.ImageSizeHeigth);
                int nr = 0;
                foreach (KeyValuePair<string, cButton> KeyValuePairButton in dictButtons)
                {
                    cButton ButtonAct = KeyValuePairButton.Value;
                    qs2.sitemap.workflowAssist.contListAssistentElem contReportButt;
                    tgReportButton tgButt;

                    if (newPnlGroup.Controls.Count >= (nr + 1))
                    {
                        contReportButt = (qs2.sitemap.workflowAssist.contListAssistentElem)newPnlGroup.Controls[nr];
                        contReportButt.Visible = true;
                        tgButt = (tgReportButton)contReportButt.Tag;
                    }
                    else
                    {  
                        contReportButt = new qs2.sitemap.workflowAssist.contListAssistentElem();
                        contReportButt.cListAssistentElem.IsQuerySystem = true;
                        contReportButt.cListAssistentElem.IDSelEntry = KeyValuePairButton.Value.rSelListEntryFound.ID;
                        contReportButt.cListAssistentElem.sqlTable = KeyValuePairButton.Value.rSelListEntryFound._Table;
                        contReportButt.cListAssistentElem.sqlColumn = KeyValuePairButton.Value.rSelListEntryFound.FldShortColumn;
                        contReportButt.InitControl(core.Enums.eTypList.CHAPTERS, this.getSelectedApplication(), this.IDParticipant, -999, false,"");

                        if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups)
                        {
                            contReportButt.ContextMenuStrip = null;
                        }
                        else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                        {
                            contReportButt.ContextMenuStrip = contReportButt.contextMenuStripQueriesReports;
                            contReportButt.dDoActionEvaluation += new qs2.sitemap.workflowAssist.contListAssistentElem.delDoActionEvaluation(this.doContextMenüButton);
                        }
                       
                        //TabControl.Controls.Add(contReportButt);
                        newPnlGroup.Controls.Add(contReportButt);
                        contReportButt.btnOK.Visible = false;
                        contReportButt.Width = this.ButtonWidth;
                        if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.DocumentGroups)
                        {
                            contReportButt.Height = this.ButtonHeigthSmall;
                            contReportButt.btnElement.Appearance.TextVAlign = VAlign.Middle;
                        }
                        else
                            contReportButt.Height = this.ButtonHeigth;

                        contReportButt.btnOK.Tag = "QS2";

                        //contReportButt.SetUI(true);
                        //contReportButt.btnElementxyxy.Visible = true;
                        contReportButt.btnElement.ImageSize = sizeButton;
                        contReportButt.ownClick2 += new EventHandler(this.btnReportClick);

                        tgButt = new tgReportButton();
                        contReportButt.Tag = tgButt;
                    }

                    contReportButt.cListAssistentElem.ID = System.Guid.NewGuid();
                    contReportButt.isOn = true;

                    if (this.IsInFront)
                    {
                        contReportButt.btnElement.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.queryDefault, getRes.ePicTyp.jpg);
                    }
                    else
                    {
                        byte[] picFound = null;
                        if (this.setPictureRessource(KeyValuePairButton.Value.rSelListEntryFound.IDRessource.Trim(), qs2.core.license.doLicense.eApp.ALL.ToString(), this.getSelectedApplication(), ref picFound))
                        {
                            System.IO.MemoryStream memStream = new System.IO.MemoryStream(picFound);
                            contReportButt.btnElement.Appearance.Image = System.Drawing.Image.FromStream(memStream);
                        }
                        else
                        {
                            System.Drawing.Image img = qs2.core.language.sqlLanguage.getPicture(KeyValuePairButton.Value.rSelListEntryFound.IDRessource, core.Enums.eResourceType.PictureEnabled, this.IDParticipant, this.getSelectedApplication());
                            if (img != null)
                            {
                                contReportButt.btnElement.Appearance.Image = img;
                            }
                            else
                            {
                                if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups)
                                    contReportButt.btnElement.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.reportDefault, getRes.ePicTyp.jpg);
                                else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                                    contReportButt.btnElement.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.queryDefault, getRes.ePicTyp.jpg);
                            }
                        }
                    }
                    contReportButt.btnElement.Text = ButtonAct.TranslatedTxt.Trim();

                    tgButt.rSelListsQry.Clear();
                    tgButt.rSelListGroup = rSelListGroup;
                    tgButt.rSelListObjs.Clear();
                    tgButt.rSelListsReports = null;

                    if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups || this.typRunQuery == qs2.core.Enums.eTypRunQuery.DocumentGroups)
                    {
                        this.drawReportGroups1.loadButtonDataReports(contReportButt, KeyValuePairButton.Value.rSelListEntryFound, this.getSelectedApplication());
                    }
                    else
                    {
                        tgButt.rSelListsQry.Add(KeyValuePairButton.Value.rSelListEntryFound);
                        tgButt.rSelListObjs.Add(KeyValuePairButton.Value.rObj);
                        tgButt.rSelListsReports = null;
                    }

                    nr += 1;
                    if (firstReportButt == null) firstReportButt = contReportButt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadButtons: " + ex.ToString());
            }
        }
        
        public void doContextMenüButton(string type, int IDSelListEntry, string Application, string QueryName)
        {
            try
            {
                qs2.sitemap.vb.frmUserSelList frmUserSelList1 = new qs2.sitemap.vb.frmUserSelList();
                string TitleWindow = qs2.core.language.sqlLanguage.getRes("RightsQueries") + " - " + QueryName;
                frmUserSelList1.initControl(IDSelListEntry, Application.Trim(), QueryName, TitleWindow);
                frmUserSelList1.ShowDialog(this);
                if (!frmUserSelList1.ContUserSelList1.abort)
                {
                    this.refreshData();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doContextMenüButton: " + ex.ToString());
            }
        }
        public void setColorButtonGroupsInaktive()
        {
            try
            {
                foreach (Infragistics.Win.Misc.UltraButton btnGrp in this.panelGroups.Controls)
                {
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(btnGrp, core.ui.eButtonType.QueryGroups);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setColorButtonGroupsInaktive: " + ex.ToString());
            }
        }
        public void setColorQueryButtonsInactive(Panel pnl)
        {
            try
            {
                foreach (qs2.sitemap.workflowAssist.contListAssistentElem contListElem in pnl.Controls)
                {
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(contListElem, core.ui.eButtonType.Queries);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setColorQueryButtonsInactive: " + ex.ToString());
            }
        }

        public bool setPictureRessource(string IDResPicture, string IDParticipant,
                                                string IDApplication, ref byte[] picToSet)
        {
            try
            {
                qs2.core.language.dsLanguage.RessourcenRow rResSel = qs2.core.language.sqlLanguage.getResRow(IDResPicture, core.Enums.eResourceType.PictureEnabled, IDParticipant, IDApplication);
                if (rResSel != null)
                {
                    if (!rResSel.IsfileBytesNull())
                    {
                        picToSet = rResSel.fileBytes;
                        return true;
                    }
                    else
                    {
                        picToSet = null;
                        return false;
                    }
                }
                else
                {
                    picToSet = null;
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setPictureRessource: " + ex.ToString());
            }
        }


        private void btnReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!qs2.ui.print.contQryRunPar.lockClickQueryReportButtons)
                {
                    qs2.ui.print.contQryRunPar.lockClickQueryReportButtons = true;

                    qs2.core.vb.frmActivity.ShowSplashScreen(qs2.core.language.sqlLanguage.getRes("QueryLoading"), frmActivity.eTypeUI.Main);


                    qs2.sitemap.workflowAssist.contListAssistentElem reportButt = (qs2.sitemap.workflowAssist.contListAssistentElem)sender;
                    tgReportButton tgButt = (tgReportButton)reportButt.Tag;

                    this.doTabsUI(false, eTypActionReports.buttInaktive);
                    qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktivElement(reportButt, core.ui.eButtonType.Queries);

                    string protocollForAdmin = "";
                    bool ProtocolWindow = false;

                    this.loadQryRepPar(reportButt, tgButt, ref protocollForAdmin, ref ProtocolWindow);
                    if (protocollForAdmin.Trim() != "")
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                    qs2.core.vb.frmActivity.CloseSplashScreen();
                    qs2.ui.print.contQryRunPar.lockClickQueryReportButtons = false;
                }

            }
            catch (Exception ex)
            {
                qs2.ui.print.contQryRunPar.lockClickQueryReportButtons = false;
                qs2.core.vb.frmActivity.CloseSplashScreen();
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void loadQryRepPar(qs2.sitemap.workflowAssist.contListAssistentElem reportButt, tgReportButton tgButt,
                                    ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                qs2.ui.print.infoReport infoReportNew = new qs2.ui.print.infoReport();
                infoReportNew.rSelListReport = tgButt.rSelListsReports;
                infoReportNew.Application = this.getSelectedApplication();
                infoReportNew.Participant = this.IDParticipant;
                infoReportNew.reportButt = reportButt;

                print.contQryRunPar contQryRunPar1Actuell = null;
                if (this.IsInFront)
                {
                    if (this.frmQryRunReport1 == null)
                    {
                        this.frmQryRunReport1 = new qs2.ui.print.frmQryRunReport();
                        this.frmQryRunReport1.contQryRunReport1.translateTitle("InputParameters");
                    }

                    this.frmQryRunReport1.Visible = true;
                    this.frmQryRunReport1.contQryRunReport1.typRunQuery = this.typRunQuery;
                    //this.frmQryRunReport1.contQryRunReport1.rowGridSelList = this.contSelListQueries2.cboQuerySelect.ActiveRow;
                    this.frmQryRunReport1.initControl(this.getSelectedApplication(), this.IDParticipant);
                    contQryRunPar1Actuell = this.frmQryRunReport1.contQryRunReport1;
                }
                else
                {
                    contQryRunPar1Actuell = this.contQryRunPar1;
                }

                contQryRunPar1Actuell.clearData();
                contQryRunPar1Actuell.setVisibleMultiControls(false);
                contQryRunPar1Actuell.resetDrawParameters();
                contQryRunPar1Actuell.infoReport = infoReportNew;

                int counterPar = 0;
                dsAdmin.tblSelListEntriesRow rQryFirst = null;
                if (tgButt.rSelListsQry.Count > 0)
                {
                    int actNr = 0;
                    foreach (dsAdmin.tblSelListEntriesRow rQry in tgButt.rSelListsQry)
                    {
                        if (actNr < 1)     //lthxy
                        {
                            if (rQryFirst == null)
                            {
                                rQryFirst = rQry;
                            }
                            qs2.ui.print.infoQry infoQryRunParNew = contQryRunPar1Actuell.getNewInfoQryRunPar(actNr, false);

                            infoQryRunParNew.rSelListQry = rQry;
                            infoQryRunParNew.rSelListReport = tgButt.rSelListsReports;
                            infoQryRunParNew.Participant = this.IDParticipant;
                            infoQryRunParNew.Application = this.getSelectedApplication();

                            if (infoQryRunParNew.rSelListQry != null)
                            {
                                this.drawReportGroups1.getQryObjForReport(ref infoQryRunParNew, ref tgButt);
                                System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                                contQryRunPar1Actuell.drawParameters2(reportButt.btnElement.Text, infoQryRunParNew, infoReportNew, true, false, false, ref protocollForAdmin, ref protocolWindow, ref counterPar, false, ref lstAllMCs);
                                contQryRunPar1Actuell.checkMCForParent(ref lstAllMCs);
                            }
                            else
                            {
                                contQryRunPar1Actuell.setUIQuery(false);
                            }

                            actNr += 1;
                        }
                    }
                }
               else
                {
                    //this.contQryRunReport1.clearData();
                    contQryRunPar1Actuell.setUIQuery(false);
                }

                if (this.IsInFront)
                {
                    if (this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                    {
                        if (rQryFirst != null)
                        {
                            this.frmQryRunReport1.loadTitleWindow(rQryFirst.IDRessource);  
                        }
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups)
                    {
                        this.frmQryRunReport1.loadTitleWindow(infoReportNew.rSelListReport.IDRessource);
                    }

                    if (counterPar > 0)
                    {
                        //this.frmQryRunReport1.run(null, rSelectedSelList, this.getSelectedApplication(), this.IDParticipant, ref protocollForAdmin, ref ProtocolWindow);
                        this.frmQryRunReport1.Visible = true;
                        this.frmQryRunReport1.Show();
                       
                    }
                    else
                    {
                        this.frmQryRunReport1.Visible = false;
                        bool viewIsFunction = false;
                        System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                        //this.frmQryRunReport1.contQryRunReport1.doReportQuery(false, this.frmQryRunReport1.contQryRunReport1.chkDoQueryReportExtern.Checked,
                        //                                                        ref viewIsFunction, ref lstParForExternFct, false, false, false);
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadQryRepPar: " + ex.ToString());
            }
        }
    
        public void loadQryRepPar_orig(qs2.sitemap.workflowAssist.contListAssistentElem reportButt, tgReportButton tgButt,
                               ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                this.contQryRunPar1.clearData();

                qs2.ui.print.infoReport infoReportNew = new qs2.ui.print.infoReport();
                infoReportNew.rSelListReport = tgButt.rSelListsReports;
                infoReportNew.Application = this.getSelectedApplication();
                infoReportNew.Participant = this.IDParticipant;
                infoReportNew.reportButt = reportButt;

                this.contQryRunPar1.setVisibleMultiControls(false);
                this.contQryRunPar1.resetDrawParameters();

                this.contQryRunPar1.infoReport = infoReportNew;

                //frmQryRunReport1.contQryRunReport1.rowGridSelList = this.cboQuerySelect.ActiveRow;
                if (tgButt.rSelListsQry.Count > 0)
                {
                    //this.contQryRunReport1.clearData();

                    //qs2.ui.print.infoReport infoReportNew = new qs2.ui.print.infoReport();
                    //infoReportNew.rSelListReport = tgButt.rSelListsReports;
                    //infoReportNew.Application = this.getSelectedApplication();
                    //infoReportNew.Participant = this.IDParticipant;
                    //infoReportNew.reportButt = reportButt;

                    //this.contQryRunReport1.setVisibleMultiControls(false);
                    //this.contQryRunReport1.resetDrawParameters();

                    int counterPar = 0;
                    int actNr = 0;
                    foreach (dsAdmin.tblSelListEntriesRow rQry in tgButt.rSelListsQry)
                    {
                        qs2.ui.print.infoQry infoQryRunParNew = this.contQryRunPar1.getNewInfoQryRunPar(actNr, false);

                        infoQryRunParNew.rSelListQry = rQry;
                        infoQryRunParNew.rSelListReport = tgButt.rSelListsReports;
                        infoQryRunParNew.Participant = this.IDParticipant;
                        infoQryRunParNew.Application = this.getSelectedApplication();

                        if (infoQryRunParNew.rSelListQry != null)
                        {
                            this.drawReportGroups1.getQryObjForReport(ref infoQryRunParNew, ref tgButt);
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                            this.contQryRunPar1.drawParameters2(reportButt.btnElement.Text, infoQryRunParNew, infoReportNew, true, false, false, ref protocollForAdmin, ref protocolWindow, ref counterPar, false, ref lstAllMCs);
                            this.contQryRunPar1.checkMCForParent(ref lstAllMCs);
                        }
                        else
                            this.contQryRunPar1.setUIQuery(false);

                        actNr += 1;
                    }

                }
                else
                {
                    //this.contQryRunReport1.clearData();
                    this.contQryRunPar1.setUIQuery(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadQryRepPar_orig: " + ex.ToString());
            }
        }


        public void doTabsUI(bool bValue, eTypActionReports typ)
        {
            try
            {
                foreach (Panel pnlGroups in this.panelTabs2.Controls)
                {
                    if (typ == eTypActionReports.Visible)
                    {
                        pnlGroups.Visible = bValue;
                        this.doReportButtUI(bValue, typ, pnlGroups);
                    }
                    else if (typ == eTypActionReports.buttInaktive)
                    {
                        this.doReportButtUI(bValue, typ, pnlGroups);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doTabsUI: " + ex.ToString());
            }
        }
        public void doReportButtUI(bool bValue, eTypActionReports typ, Panel pnlGroups)
        {
            try
            {
                foreach (qs2.sitemap.workflowAssist.contListAssistentElem contReportButt in pnlGroups.Controls)
                {
                    if (typ == eTypActionReports.Visible)
                    {
                        contReportButt.Visible = bValue;
                        contReportButt.isOn = bValue;
                    }
                    else if (typ == eTypActionReports.buttInaktive)
                    {
                        qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(contReportButt, core.ui.eButtonType.Queries);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doReportButtUI: " + ex.ToString());
            }
        }

        public void resizeReportButt(Panel GroupPanel)
        {
            try
            {
                Application.DoEvents();
                
                int left = 6;
                int top = 6;
                int maxWith = 0;
                foreach (qs2.sitemap.workflowAssist.contListAssistentElem reportButt in GroupPanel.Controls)
                {
                    reportButt.Top = top;
                    reportButt.Left = left;

                    int newLeft = left + this.ButtonWidth + 6;
                    if ((newLeft + this.ButtonWidth + 6) < (GroupPanel.Width + 8))
                    {
                        left = newLeft;
                    }
                    else
                    {
                        maxWith = (newLeft);
                        left = 6;
                        top = reportButt.Top + reportButt.Height + 6;
                    }
                }

                System.Drawing.Size sizeScroll;
                sizeScroll = new System.Drawing.Size(maxWith + 6, 0);
                GroupPanel.AutoScrollMinSize = sizeScroll;

            }
            catch (Exception ex)
            {
                throw new Exception("resizeReportButt: " + ex.ToString());
            }
        }

        public string getSelectedApplication()
        {
            try
            {
                return this.defaultApplication;
                //return this.comboApplication1.getSelectedApplication().ToString();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return "";
            }
        }

        private void contQryRun_Resize(object sender, EventArgs e)
        {

        }

        private void PanelGroups_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //this.doTabsUI(true, eTypActionReports.resizeReportButt);
                if (this.actGroupPanel != null)
                    this.resizeReportButt(this.actGroupPanel);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.refreshData();

            }
            catch (Exception ex)
            {
                contQryRun.lockRefreshButton = false;
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void refreshData()
        {
            try
            {
                if (contQryRun.lockRefreshButton)
                    return;

                this.contQryRunPar1.grpQueryParameter.Visible = true;

                this.loadGroups(this.defaultApplication);
                if (this.actGroupButt != null)
                {
                    if (this.actGroupPanel != null)
                        this.resizeReportButt(this.actGroupPanel);

                    //Application.DoEvents();
                    //contQryRun.lockRefreshButton = true;
                    ////btnRefresh_Click(sender, e);
                    contQryRun.lockRefreshButton = false;
                }

                //this.setColorQueryPanels();

            }
            catch (Exception ex)
            {
                contQryRun.lockRefreshButton = false;
                throw new Exception ("refreshData: " + ex.ToString());
            }
        }

        private void toolbarsManagerAdmin_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string excepStr = "toolbarsManagerAdmin_ToolClick: toolbars-Key ist wrong in Query- or Report-System";
                if (e.Tool.Key.Equals(eTypToolbar.ReportGroups.ToString()))
                {
                    if (this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.QueryGroups);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.ReportGroups);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.DocumentGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.DocumentGroups);
                    }
                    else
                        throw new Exception(excepStr);
                }
                else if (e.Tool.Key.Equals(eTypToolbar.Reports.ToString()))
                {
                    if (this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Queries);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Reports);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.DocumentGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Documents);
                    }
                    else
                        throw new Exception(excepStr);
                }
                else if (e.Tool.Key.Equals(eTypToolbar.Documents.ToString()))
                {
                    if (this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Queries);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Reports);
                    }
                    else if (this.typRunQuery == core.Enums.eTypRunQuery.DocumentGroups)
                    {
                        this.openManageGroupsReports(eTypToolbar.Documents);
                    }
                    else
                        throw new Exception(excepStr);
                }

                else if (e.Tool.Key.Equals(eTypToolbar.btnManageQueries.ToString()))
                {
                    qs2.core.ENV.cParsCalMainFunction pars = new qs2.core.ENV.cParsCalMainFunction();
                    qs2.core.ENV.CallFunctionMain(core.ENV.eTypeFunction.loadManageQueryuser, pars);
                }   
                else if (e.Tool.Key.Equals(eTypToolbar.btnAssignSubqueries.ToString()))
                {
                    qs2.design.auto.print.frmAllQueriesEditSmall frmAllQueriesEditSmall1 = new design.auto.print.frmAllQueriesEditSmall();
                    frmAllQueriesEditSmall1.initControl();
                    frmAllQueriesEditSmall1.ShowDialog(this);
                }   
                else
                    throw new Exception(excepStr);
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

        public void openManageGroupsReports(eTypToolbar typ)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
            
                qs2.sitemap.vb.frmSelLists frmSelListAdd = new qs2.sitemap.vb.frmSelLists();
                frmSelListAdd.ContSelList1.defaultApplication = this.getSelectedApplication();
                frmSelListAdd.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                frmSelListAdd.ContSelList1.doAutoRessource = true;
                frmSelListAdd._OnlyOwnSelListsEditable = true;
                frmSelListAdd._OnlyUserSelListsEditable = false;
                frmSelListAdd.ContSelList1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();

                if (typ == eTypToolbar.ReportGroups)
                {

                }
                else if (typ == eTypToolbar.Reports)
                {

                }

                frmSelListAdd.ContSelList1.IDGruppeStr = typ.ToString();
                frmSelListAdd.TypeStr = qs2.core.Enums.eTypeQuery.User.ToString();
                frmSelListAdd.typeUI = sitemap.vb.frmSelLists.eTypeUI.manageQueryGroups;
                frmSelListAdd._Private = false;
                frmSelListAdd.ContSelList1.btnUserRights.Visible = true;
                frmSelListAdd.ShowDialog(this);
                if (frmSelListAdd.ContSelList1.savedClicked)
                {
                    this.loadGroups(this.defaultApplication);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("openManageGroupsReports: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comboApplication1_evOnChange(string selectedApplication)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.defaultApplication = selectedApplication;
                System.Collections.Generic.List<string> lstApplicationsLicensed = new List<string>();
                bool ApplicationFound = false;
                qs2.core.license.doLicense.selApplication(this.defaultApplication.Trim(), ref lstApplicationsLicensed, ref ApplicationFound);
                this.loadGroups(selectedApplication);
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


        private void contQryRun_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (this.Visible)
                {
                    this.doVisible();
                    //this.firstLoadGroupsIsDone = false;
                    this.AutoControlsUI1.run2(this, this.components);

                    if (!this.FirstVisibleDone)
                    {
                       
                        this.setColorButtonGroupsInaktive();
                        if (this.actGroupPanel != null)
                        {
                            this.setColorQueryButtonsInactive(this.actGroupPanel);
                            qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.actGroupButt, core.ui.eButtonType.QueryGroups);
                        }

                    }
                    this.FirstVisibleDone = true;
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

        public void doVisible()
        {
            try
            {
                if (!this.firstLoadGroupsIsDone)
                {
                    this.loadGroups(this.defaultApplication);
                    Application.DoEvents();
                }

                if (this.Visible)
                {
                    if (this.defaultApplication.Trim() != "")
                    {
                        System.Collections.Generic.List<string> lstApplicationsLicensed = new List<string>();
                        bool ApplicationFound = false;
                        qs2.core.license.doLicense.selApplication(this.defaultApplication.Trim(), ref lstApplicationsLicensed, ref ApplicationFound);
                    }
                }

                //if (qs2.ui.print.contQryAdmin.dataChanged)
                //{
                //    this.loadGroups(this.defaultApplication);
                //    qs2.ui.print.contQryAdmin.dataChanged = false;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("doVisible: " + ex.ToString());
            }
            finally
            {
            }
        }

        private void contextMenuStripGroups_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
