using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;
using qs2.ui.pint;
using QS2.Resources;



namespace qs2.ui.print
{


    public partial class contQryRunPar : UserControl
    {

        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public qs2.print.genReport genReport1 = new qs2.print.genReport();
        
        public frmQryRunReport mainWindow;
        public Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpService;
        public Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpQueries;

        public UltraGridRow rowGridSelList;
        public qs2.core.Enums.eTypRunQuery typRunQuery = new qs2.core.Enums.eTypRunQuery();

        public qs2.ui.print.infoReport infoReport = new qs2.ui.print.infoReport();
        public System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQry = new System.Collections.Generic.List<qs2.ui.print.infoQry>();
        public System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunning = new System.Collections.Generic.List<qs2.ui.print.infoQry>();
        
        public drawMulticontrol drawMulticontrol1 = new drawMulticontrol();
        public bool isLoaded = false;


        public int  MultiControlNrToLoad = 1;
        public int lastTopMultiControl = 0;
        public int lastTopMultiControlBevorSubQuery = 0;

        public int elementHeigth = 22;

        public enum eTypToolbar
        {
            EditQuery= 0,
            SaveXSD = 1,
            GenSqlAndOpen = 2
        }

        public enum eActionElement
        {
            getTranslatedText = 0
        }
        public enum eActionType
        {
            NormalRows = 0,
            BeetweenRows = 1,
            DeleteRows = 2,
            GetSqlWhere = 3,
            WriteSqlWhere = 4
        }
        public static bool lockClickQueryReportButtons = false;
        public bool right_QueryReportOwn = false;
        public qs2.design.auto.print.doRelationshipEvaluation doRelationshipEvaluation1 = new qs2.design.auto.print.doRelationshipEvaluation();

        public bool isStayReport = false;
        public Nullable<Guid> IDGuid = null;

        public delegate void eMCValueChanged2();
        public eMCValueChanged2 MCValueChanged2;











        public contQryRunPar()
        {
            InitializeComponent();
        }

        private void contQryRunPar_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string defaultApplication, string defaultParticipant)
        {
            try
            {
                if (this.isLoaded) return;

                this.contSelListQueries1.mainWindowQueryPar = this;
                this.contSelListQueries1.noSelection = true;
                this.contSelListQueries1.Participant = defaultParticipant;
                this.contSelListQueries1.typeQuery = core.Enums.eTypeQuery.User;
                this.contSelListQueries1.initControl(defaultApplication, true, true,true, true, false, true);

                this.popUpService = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.ultraToolbarsManager1.Tools["popUpService"];
                this.popUpQueries = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.ultraToolbarsManager1.Tools["popUpQueries"];
                this.popUpService.SharedProps.Visible = false;
                this.popUpQueries.SharedProps.Visible = false;

                this.popUpService.SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.ePicture.ico_service, 32, 32);       
                this.genReport1.initControl();
                this.sqlAdmin1.initControl();
                this.btnRunReport.initControl();

                this.drawMulticontrol1.initControl();
                this.loadRes();
                this.setUIQuery(false);
                this.panelParameters.Visible = false;


                if (!qs2.core.vb.actUsr.rUsr.isAdmin && !qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.popUpService.SharedProps.Visible = false;
                    this.menuStripManageQuerySubSelect.Visible = false;
                    this.panelService.Visible = false;
                }
                else
                {
                    this.panelService.Visible = true;
                }
                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.ultraToolbarsManager1.Visible = true;
                }
                else
                {
                    this.ultraToolbarsManager1.Visible = false;
                }

                this.right_QueryReportOwn = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueryReportOwn, false);
                if (!qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.openResultsInTableToolStripMenuItem.Visible = false;
                    //this.generateSqlCommandForCommandLineToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.generateSqlCommandForCommandLineToolStripMenuItem.Visible = true;
                    this.panelService.Visible = true;
                    right_QueryReportOwn = true;
                }

                this.contSelListQueries1._IsSubQueriesFromMainControl = true;
                this.grpQueryParameter.Visible = false;

                this.isLoaded = true;

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.initControl: " + ex.ToString());
            }
        }
        public void loadRes()
        {
            try
            {

                if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                {
                    this.btnRunReport.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
                    this.btnRunReport.Text = qs2.core.language.sqlLanguage.getRes("RunQuery");
                    this.ultraToolbarsManager1.Tools["btnManageQueries"].SharedProps.Visible = false;
                    this.openResultsInTableToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("RunQuery") + " " + qs2.core.language.sqlLanguage.getRes("TableViewer");
                    this.generateSqlCommandForCommandLineToolStripMenuItem.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueryReportOthers, false);
                }
                else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups)
                {
                    this.btnRunReport.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken , 32, 32);
                    this.btnRunReport.Text = qs2.core.language.sqlLanguage.getRes("RunReport");
                    this.openResultsInTableToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("RunReport") + " " + qs2.core.language.sqlLanguage.getRes("TableViewer");
                    this.generateSqlCommandForCommandLineToolStripMenuItem.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueryReportOthers, false);
                }

                else if (this.typRunQuery == qs2.core.Enums.eTypRunQuery.DocumentGroups)
                {
                    this.btnRunReport.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
                    this.btnRunReport.Text = qs2.core.language.sqlLanguage.getRes("RunDocument");
                    this.openResultsInTableToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("RunDocument") + " " + qs2.core.language.sqlLanguage.getRes("TableViewer");
                    this.generateSqlCommandForCommandLineToolStripMenuItem.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueryReportOthers, false);
                }

                this.generateSqlCommandForCommandLineToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("GenerateSqlCommandForCommandLine");
                
                this.ultraToolbarsManager1.Tools["btnManageQueries"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("ManageQueries");
                this.ultraToolbarsManager1.Tools["btnInfoQueries"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("InfoQueries");
                this.popUpService.SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Service");
                this.popUpQueries.SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("AdministrateQueries");
                this.popUpQueries.SharedProps.AppearancesSmall.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_Queries, 32, 32);
                this.popUpService.SharedProps.AppearancesSmall.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_service, 32, 32);

                //this.grpQueryParameter.Text = qs2.core.language.sqlLanguage.getRes("NoQueriesDefined") + "!";
                //this.lblNoQueriesDefined.Visible = false;


                this.lblQuerySub.Text = qs2.core.language.sqlLanguage.getRes("SubQuery");
                this.historyToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("History");
                this.historyToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.ultraToolbarsManager1.Tools["openReportDirectory"].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("openReportDirectory");
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.loadRes: " + ex.ToString());
            }
        }

        public void clearData()
        {
            try
            {
                this.lstInfoQryRunning.Clear();
                this.infoReport = new qs2.ui.print.infoReport();
                this.popUpQueries.Tools.Clear();
                this.popUpQueries.SharedProps.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.clearData: " + ex.ToString());
            }
        }

        public void resetDrawParameters()
        {
            try
            {
                this.MultiControlNrToLoad = 1;
                this.lastTopMultiControl = 0;
                this.lastTopMultiControlBevorSubQuery = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.resetDrawParameters: " + ex.ToString());
            }
        }

        public void drawParameters2(string Title, qs2.ui.print.infoQry InfoQryRunPar, qs2.ui.print.infoReport infoReport1,
                                    bool addInfoQryRunParToList, bool onlyWhereClausel, bool resetTop, ref string protocollForAdmin, ref bool protocolWindow,
                                    ref int counterPar, bool IsSubQuery, ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs)
        {
            try
            {
                this.grpQueryParameter.Visible = true;
                Application.DoEvents();

                this.contSelListQueries1.IDSelListMainControl = InfoQryRunPar.rSelListQry.ID;
                this.SuspendLayout();

                this.panelParameters.AutoScrollPosition = new Point(0);

                this.panelParameters.Visible = false;

                if (addInfoQryRunParToList)
                    this.lstInfoQryRunning.Add(InfoQryRunPar);

                //if (resetTop)
                //    this.lastTopMultiControl = lastTopMultiControlBevorSubQuery;

                int countMultiControls = 0;

                if (!IsSubQuery)
                {
                    this.contSelListQueries1.infoQryMain = InfoQryRunPar;
                    this.contSelListQueries1.infoReportMain = infoReport1;
                }
                else
                {
                    //string xy = "";
                }

                if (!onlyWhereClausel)
                {
                    this.popUpService.SharedProps.Visible = true;

                    Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpQuery = this.addQueryPopUpToToolbar(InfoQryRunPar.rSelListQry.IDRessource);
                    this.addQueryInfoToToolbar(InfoQryRunPar, eTypToolbar.EditQuery, "EditQuery", true, popUpQuery);
                    this.addQueryInfoToToolbar(InfoQryRunPar, eTypToolbar.SaveXSD, "SaveResultQueriesAsXml", false, popUpQuery);
                    this.addQueryInfoToToolbar(InfoQryRunPar, eTypToolbar.GenSqlAndOpen, "GenerateSqlStatement", false, popUpQuery);

                    this.setUIQuery(true);

                    if (!onlyWhereClausel)
                        this.grpQueryParameter.Text = Title;

                    this.infoReport = infoReport1;

                    //int nrToLoad = 1;
                    //int lastTop = 0;

                    this.sqlAdmin1.getQueriesDef(InfoQryRunPar.rSelListQry.ID, InfoQryRunPar.dsFieldsUI, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.SelectFields, qs2.core.license.doLicense.eApp.ALL.ToString(), InfoQryRunPar.Application);
                    this.sqlAdmin1.getQueriesDef(InfoQryRunPar.rSelListQry.ID, InfoQryRunPar.dsJoinsUI, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.Joins, qs2.core.license.doLicense.eApp.ALL.ToString(), InfoQryRunPar.Application);
                }

                // Where-Clauses
                this.sqlAdmin1.getQueriesDef(InfoQryRunPar.rSelListQry.ID, InfoQryRunPar.dsConditionsUI, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.WhereConditions, qs2.core.license.doLicense.eApp.ALL.ToString(), InfoQryRunPar.Application);
                if (this.isStayReport)
                {
                    System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lQueryDefsDel = new List<dsAdmin.tblQueriesDefRow>();
                    foreach (var rQueryDef in InfoQryRunPar.dsConditionsUI.tblQueriesDef)
                    {
                        if (string.Equals(rQueryDef.Typ, "WhereConditions", StringComparison.InvariantCultureIgnoreCase) ||
                            string.Equals(rQueryDef.Typ, "InputParameters", StringComparison.InvariantCultureIgnoreCase))
                        {
                            lQueryDefsDel.Add(rQueryDef);
                        }
                    }
                    foreach (var rQueryDef in lQueryDefsDel)
                    {
                        rQueryDef.Delete();
                    }
                    InfoQryRunPar.dsConditionsUI.tblQueriesDef.AcceptChanges();

                    //dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(InfoQryRunPar.dsConditionsUI.tblQueriesDef, InfoQryRunPar.Application.Trim(), "",
                    //                                   "", "", "", InfoQryRunPar.rSelListQry.ID, core.Enums.eControlType.Integer);
                    //rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                    //rNewQryDefCondition.CombinationEnd = "";
                    //rNewQryDefCondition.Sort = 0;
                    //rNewQryDefCondition.QryTable = InfoQryRunPar.rSelListQry._Table;
                    //rNewQryDefCondition.freeSql = " where IDGuid='" + this.IDGuid.Value.ToString() + "' ";
                    //rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = true;
                    //rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                }

                if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups || this.typRunQuery == core.Enums.eTypRunQuery.DocumentGroups)
                {
                    qs2.design.auto.multiControl.ownMultiControl multiControlHeaderQry = this.addParameter(null, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.WhereConditions, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, qs2.core.sqlTxt.equals, false, "", true, false, InfoQryRunPar.isSubQuery, false, ref protocollForAdmin, ref protocolWindow, ref InfoQryRunPar.IDQueryGroup, ref counterPar, ref lstAllMCs);
                }

                if (!resetTop)
                {
                }
                
                if (this.right_QueryReportOwn && !IsSubQuery)
                {
                    System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblQueriesDefRow> lstObjectParsAdded = new List<dsAdmin.tblQueriesDefRow>();
                    int iCounterAdded = 0;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObjFirst = null;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObjLast = null;
                    if (!this.isStayReport)
                    {
                        this.autoAddParObjects(InfoQryRunPar, "Surgeon", 200, ref iCounterAdded, ref rNewParObjLast, ref rNewParObjFirst, ref lstObjectParsAdded);
                        this.autoAddParObjects(InfoQryRunPar, "Perfusionist", 201, ref iCounterAdded, ref rNewParObjLast, ref rNewParObjFirst, ref lstObjectParsAdded);
                    }
                    if (lstObjectParsAdded.Count > 1)
                    {
                        rNewParObjLast = null;
                        int counterParAdded = 0;
                        foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObj in lstObjectParsAdded)
                        {
                            rNewParObj.Combination = (counterParAdded == 0 ? " and (" : " or ");
                            rNewParObjLast = rNewParObj;
                            counterParAdded += 1;
                        }
                        rNewParObjLast.CombinationEnd = " ) ";
                    }
                    //if (rNewParObjFirst != null && rNewParObjLast != null && iCounterAdded > 1)
                    //{
                    //    rNewParObjLast.CombinationEnd = " ) ";
                    //}
                }

                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in InfoQryRunPar.dsConditionsUI.tblQueriesDef)
                {
                    if (rQry.UserInput)
                    {
                        bool addAdditionalMultiControl = false;
                        if (rQry.Condition.Trim() == qs2.core.sqlTxt.between.Trim() || rQry.Condition.Trim() == qs2.core.sqlTxt.notBetween.Trim())
                            addAdditionalMultiControl = true;

                        qs2.design.auto.multiControl.ownMultiControl ownMultiControlParent = this.addParameter(rQry, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.WhereConditions, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref  this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, "", addAdditionalMultiControl, "From2", false, false, InfoQryRunPar.isSubQuery, true, ref protocollForAdmin, ref protocolWindow, ref InfoQryRunPar.IDQueryGroup, ref counterPar, ref lstAllMCs);
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControlChild = null;
                        countMultiControls += 1;
                        if (addAdditionalMultiControl)
                        {
                            ownMultiControlChild = this.addParameter(rQry, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.WhereConditions, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, qs2.core.sqlTxt.between, true, "To", false, false, InfoQryRunPar.isSubQuery, true, ref protocollForAdmin, ref protocolWindow, ref InfoQryRunPar.IDQueryGroup, ref counterPar, ref lstAllMCs);
                            ownMultiControlChild.IsBetweenControlSecondValue = true;
                            ownMultiControlParent.ownMultiControlChild = ownMultiControlChild;
                            countMultiControls += 1;
                        }
                    }
                }

                // Input-Clausel
                this.sqlAdmin1.getQueriesDef(InfoQryRunPar.rSelListQry.ID, InfoQryRunPar.dsParFctUI, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.InputParameters, qs2.core.license.doLicense.eApp.ALL.ToString(), InfoQryRunPar.Application);
                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in InfoQryRunPar.dsParFctUI.tblQueriesDef)
                {
                    if (rQry.UserInput && rQry.FunctionPar)
                    {
                        this.addParameter(rQry, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.InputParameters, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref  this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, "", false, "", false, false, InfoQryRunPar.isSubQuery, true, ref protocollForAdmin, ref protocolWindow, ref InfoQryRunPar.IDQueryGroup, ref counterPar, ref lstAllMCs);
                    }
                }

                if (!onlyWhereClausel)
                {
                    //if (countMultiControls == 0)
                    //    multiControlHeaderQry.Visible = false;
                    if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups || InfoQryRunPar.rSelListQry.IDRessource.Trim().ToLower().EndsWith(("KaplanMeier").Trim().ToLower()))
                    {
                        this.sqlAdmin1.getQueriesDef(InfoQryRunPar.rSelListQry.ID, InfoQryRunPar.dsInputFieldsUI, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.InputParameters, qs2.core.license.doLicense.eApp.ALL.ToString(), InfoQryRunPar.Application);
                        countMultiControls = 0;
                        //qs2.design.auto.multiControl.ownMultiControl multiControlParameters = this.addParameter(null, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.WhereConditions, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, qs2.core.sqlTxt.equals, false, "", true, true);

                        foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in InfoQryRunPar.dsInputFieldsUI.tblQueriesDef)
                        {
                            if (rQry.UserInput && !rQry.FunctionPar)
                            {
                                this.addParameter(rQry, InfoQryRunPar.rSelListQry, core.Enums.eTypQueryDef.InputParameters, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref  this.MultiControlNrToLoad, ref this.lastTopMultiControl, ref elementHeigth, "", false, "", false, false, InfoQryRunPar.isSubQuery, true, ref protocollForAdmin, ref protocolWindow, ref InfoQryRunPar.IDQueryGroup, ref counterPar, ref lstAllMCs);
                                countMultiControls += 1;
                            }
                        }

                        //if (countMultiControls == 0)
                        //    multiControlParameters.Visible = false;
                    }
                }

                this.panelParameters.AutoScroll = true;
                System.Drawing.Size sizeScroll = new System.Drawing.Size(0, this.lastTopMultiControl + elementHeigth + 5);
                this.panelParameters.AutoScrollMinSize = sizeScroll;
                //this.panelAdd.SetAutoScrollMargin(sizeScroll.Width, sizeScroll.Height );

                if (!onlyWhereClausel)
                {
                    this.contSelListQueries1.clearSelection();
                    this.contSelListQueries1.loadQueries(null, InfoQryRunPar.Application, InfoQryRunPar.Participant, InfoQryRunPar, true, InfoQryRunPar.rSelListQry.ID, true);

                    if (!IsSubQuery)
                        this.lastTopMultiControlBevorSubQuery = this.lastTopMultiControl;
                }

                this.setVisibleUsedMultiControls(true);

            }
            catch (Exception ex)
            {
                this.panelParameters.Visible = true;
                this.ResumeLayout();
                throw new Exception("contQryRunPar.drawParameters: " + ex.ToString());
            }
            finally
            {
                this.panelParameters.Visible = true;
                this.ResumeLayout();
            }
        }
        public void checkMCForParent(ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs)
        {
            try
            {
                qs2.design.auto.multiControl.ownMultiControl mcParent = null;
                foreach (qs2.design.auto.multiControl.ownMultiControl mcAct in lstAllMCs)
                {
                    if (mcParent != null)
                    {
                        this.doRelationshipEvaluation1.run(mcParent.OwnFldShort.Trim(), ref mcParent, mcAct, mcAct.rQry);
                    }
                    mcParent = mcAct;
                }

            }
            catch (Exception ex)
            {
                this.panelParameters.Visible = true;
                this.ResumeLayout();
                throw new Exception("contQryRunPar.checkMCForParent: " + ex.ToString());
            }
            finally
            {
                this.ResumeLayout();
            }
        }


        public void autoAddParObjects(qs2.ui.print.infoQry InfoQryRunPar, string QryColumn, int Sort, ref int counterParAdded,
                                        ref qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObjLast, ref qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObjFirst,
                                        ref System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblQueriesDefRow> lstObjectParsAdded)
        {
            try
            {
                if (InfoQryRunPar.rSelListQry._Table.Trim() != "")
                {
                    qs2.print.doParameterForQuery doParameterForQuery1 = new qs2.print.doParameterForQuery();
                    string TableNameTmp = InfoQryRunPar.rSelListQry._Table.Trim().Substring(4, InfoQryRunPar.rSelListQry._Table.Trim().Length - 4);
                    if (qs2.core.dbBase.viewIsFunction2(TableNameTmp.Trim()))
                    {
                        TableNameTmp = "v" + TableNameTmp.Trim();
                    }

                    if (doParameterForQuery1.ColumnExistsInTable(TableNameTmp.Trim(), QryColumn.Trim()))
                    {
                        bool containsQryColumn = false;
                        //foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in InfoQryRunPar.dsConditionsUI.tblQueriesDef)
                        //{
                        //    if (rQry.QryColumn.Trim().ToLower().Equals(QryColumn.Trim().ToLower()))
                        //    {
                        //        containsQryColumn = true;
                        //    }
                        //}
                        if (!containsQryColumn)
                        {
                            bool RoleOK = false;
                            qs2.core.vb.businessFramework b = new businessFramework();
                            RoleOK = b.checkRolesUser(true, InfoQryRunPar.Application.Trim(), QryColumn, InfoQryRunPar.rSelListQry._Table.Trim());

                            //if (qs2.core.Settings.ControlOpenStayType == 0)
                            //{
                            //    RoleOK = b.checkRolesUser(false, InfoQryRunPar.Application.Trim(), QryColumn, InfoQryRunPar.rSelListQry._Table.Trim());
                            //}
                            //else
                            //{
                            //    RoleOK = b.checkRolesUser(true, InfoQryRunPar.Application.Trim(), QryColumn, InfoQryRunPar.rSelListQry._Table.Trim());
                            //}
                            if (RoleOK)
                            {
                                qs2.core.vb.dsAdmin.tblQueriesDefRow rNewParObj = this.sqlAdmin1.addRowQueriesDef(InfoQryRunPar.dsConditionsUI.tblQueriesDef);
                                rNewParObj.IsSQLServerField = false;
                                rNewParObj.CriteriaFldShort = QryColumn.Trim();
                                rNewParObj.QryColumn = QryColumn.Trim();
                                rNewParObj.ComboAsDropDown = true;
                                rNewParObj.ComboAsDropDownCondition = " or ";
                                rNewParObj.Combination = (counterParAdded == 0 ? " and " : " or "); 
                                rNewParObj.QryTable = InfoQryRunPar.rSelListQry._Table.Trim();
                                rNewParObj.UserInput = true;
                                rNewParObj.ControlType = core.Enums.eControlType.ComboBox.ToString();
                                rNewParObj.Condition = " = ";
                                rNewParObj.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                                rNewParObj.CriteriaApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                                rNewParObj.ApplicationOwn = InfoQryRunPar.Application.Trim();
                                rNewParObj.Typ = core.Enums.eTypQueryDef.WhereConditions.ToString();
                                rNewParObj.Sort = Sort;

                                if (rNewParObjFirst != null)
                                {
                                    rNewParObjFirst = rNewParObj;
                                }
                                rNewParObjLast = rNewParObj;
                                lstObjectParsAdded.Add(rNewParObj);

                                counterParAdded += 1;
                            }
                        }
                    }
                    else
                    {
                        //bool NotExistsInTable = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("autoAddParObjects: " + ex.ToString());
            }
        }
        public void doSubParameters(dsAdmin.tblSelListEntriesRow rSelectedSelList, ref string protocollForAdmin, ref bool protocolWindow,
                                    ref int counterPar)
        {
            try
            {
                //this.clearControlsSubQuery();
                qs2.core.vb.frmActivity.ShowSplashScreen(qs2.core.language.sqlLanguage.getRes("QueryLoading"), frmActivity.eTypeUI.Main);

                qs2.ui.print.infoQry infoQryRunParNew = this.getNewInfoQryRunPar(-1, true);
                infoQryRunParNew.dsQryResult.DataSetName = "SubQuery " + rSelectedSelList.IDRessource + " {" + System.Guid.NewGuid().ToString() + "}";
                infoQryRunParNew.rSelListQry = rSelectedSelList;
                infoQryRunParNew.rSelListReport = this.infoReport.rSelListReport;
                infoQryRunParNew.Participant = this.infoReport.Participant;
                infoQryRunParNew.Application = this.infoReport.Application;
                infoQryRunParNew.isSubQuery = true;

                //this.drawReportGroups1.getQryObjForReport(ref infoQryRunParNew, ref tgButt);
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                this.drawParameters2("", infoQryRunParNew, this.infoReport, true, true, true, ref protocollForAdmin, ref protocolWindow, ref counterPar, true, ref lstAllMCs);
                this.checkMCForParent(ref lstAllMCs);

            }
            catch (Exception ex)
            {
                qs2.core.vb.frmActivity.CloseSplashScreen();
                throw new Exception("contQryRunPar.doSubParameters: " + ex.ToString());
            }
            finally 
            {
                qs2.core.vb.frmActivity.CloseSplashScreen();
            }
        }


        public void clearControlsSubQuery()
        {
            try
            {
                foreach (Control contFound in this.panelParameters.Controls)
                {
                    if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ElementMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)contFound;
                        if (ElementMultiControlFound.isSubQuery)
                        {
                            ElementMultiControlFound.Visible = false;
                            ElementMultiControlFound.IsInUseInparameterList = false;
                        }
                            
                    }
                    else if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        qs2.design.auto.multiControl.ownMultiGridSelList ElementMultiSelListControlFound = (qs2.design.auto.multiControl.ownMultiGridSelList)contFound;
                        if (ElementMultiSelListControlFound.isSubQuery)
                        {
                            ElementMultiSelListControlFound.Visible = false;
                            ElementMultiSelListControlFound.IsInUseInparameterList = false;
                        }  
                    }
                }

                System.Collections.ArrayList arrToDelete = new System.Collections.ArrayList();
                foreach (qs2.ui.print.infoQry infoQryRunPar in this.lstInfoQryRunning)
                {
                    if (infoQryRunPar.isSubQuery)
                        arrToDelete.Add(infoQryRunPar);
                }
                foreach (qs2.ui.print.infoQry InfoQryRunParToDelete in arrToDelete)
                {
                    this.lstInfoQryRunning.Remove(InfoQryRunParToDelete);
                }

                this.lastTopMultiControl = this.lastTopMultiControlBevorSubQuery;
                this.panelParameters.AutoScrollPosition = new Point(0);

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.clearControlsSubQuery: " + ex.ToString());
            }
        }

        public void setVisibleMultiControls(bool visible)
        {
            try
            {
                foreach (Control contFound in this.panelParameters.Controls)
                {
                    if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ElementMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)contFound;
                        ElementMultiControlFound.Visible = visible;
                        ElementMultiControlFound.IsInUseInparameterList = false;
                    }
                    else if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        qs2.design.auto.multiControl.ownMultiGridSelList ElementMultiSelListControlFound = (qs2.design.auto.multiControl.ownMultiGridSelList)contFound;
                        ElementMultiSelListControlFound.Visible = visible;
                        ElementMultiSelListControlFound.IsInUseInparameterList = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.setVisibleMultiControls: " + ex.ToString());
            }
        }
        public void setVisibleUsedMultiControls(bool visible)
        {
            try
            {
                foreach (Control contFound in this.panelParameters.Controls)
                {
                    //if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    //{
                    //    qs2.design.auto.multiControl.ownMultiControl ElementMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)contFound;
                    //    if (ElementMultiControlFound.IsInUseInparameterList)
                    //    {
                    //        ElementMultiControlFound.Visible = visible;
                    //    }
                    //}
                    //else if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    //{
                    //    qs2.design.auto.multiControl.ownMultiGridSelList ElementMultiSelListControlFound = (qs2.design.auto.multiControl.ownMultiGridSelList)contFound;
                    //    if (ElementMultiSelListControlFound.IsInUseInparameterList)
                    //    {
                    //        ElementMultiSelListControlFound.IsVisibleControl = true;
                    //        ElementMultiSelListControlFound.ownControlUI1.IsVisible_Criteria = true;
                    //        ElementMultiSelListControlFound.IsVisibleControlAssignmentChapters = true;
                    //        ElementMultiSelListControlFound.Visible = visible;
                    //        ElementMultiSelListControlFound.doVisible();
                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.setVisibleUsedMultiControls: " + ex.ToString());
            }
        }

        public void setDelegateMCs()
        {
            try
            {
                foreach (Control contFound in this.panelParameters.Controls)
                {
                    if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ElementMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)contFound;
                        ElementMultiControlFound.MCValueChanged = new design.auto.multiControl.ownMultiControl.eMCValueChanged(this.DoMCValueChanged);

                    }
                    else if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.setDelegateMCs: " + ex.ToString());
            }
        }
        public void DoMCValueChanged()
        {
            if (this.MCValueChanged2 != null)
            {
                this.MCValueChanged2.Invoke();
            }
        }

        public void setUIQuery(bool queriesFound)
        {
            this.panelBottom.Visible = queriesFound;
            if (queriesFound)
            {
                this.grpQueryParameter.Visible = true;
                Application.DoEvents();

                this.grpQueryParameter.Text = qs2.core.language.sqlLanguage.getRes("NoQueriesDefined") + "!";
//                this.panelNoQuery.Height = 41;
            }
            else
            {
//                this.panelNoQuery.Height = 0;
            }

            //this.panelParameters.Visible = queriesFounded;
        }

        public void translateTitle(string IDResTitle)
        {
            try
            {
                string IDResFound = qs2.core.language.sqlLanguage.getRes(IDResTitle);
                if (IDResFound.Trim() != "")
                    this.grpQueryParameter.Text = IDResFound;
                else
                    this.grpQueryParameter.Text = IDResTitle;

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.translateTitle: " + ex.ToString());
            }
        }
        public qs2.design.auto.multiControl.ownMultiControl addParameter(qs2.core.vb.dsAdmin.tblQueriesDefRow rQry, dsAdmin.tblSelListEntriesRow rSelectedSelList, 
                                qs2.core.Enums.eTypQueryDef typQueryDef, string IDApplication, string IDParticipant,
                                ref int nrToLoad, ref int lastTop, ref int elementHeigth, string subCondition, bool addAdditionalLabel, 
                                string IDResAdditionalLabel, bool headerQry, bool headerParameters, bool isSubQuery, 
                                bool showCondition, ref string protocollForAdmin, ref bool protocolWindow, 
                                ref System.Guid IDQueryGroup,
                                ref int counterPar, ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs)
        {
            try
            {
                bool IsMultiGrid = false;

                if (rQry != null)
                {
                    if (rQry.ControlType.Trim().ToLower() == core.Enums.eControlType.GridMultiSelect.ToString().Trim().ToLower() &&
                        rQry.QryColumn.Trim().ToLower().Equals(("gridConFactors").Trim().ToLower()))
                    {
                        IsMultiGrid = true;
                    }
                }

                //if (!IDApplication.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.CARDIAC.ToString().Trim().ToLower()))
                //{
                //    throw new Exception("addParameterControls:  IDApplication only allowed for Cardiac!");
                //}

                qs2.design.auto.multiControl.ownMultiControl newElement = null;
                qs2.design.auto.multiControl.ownMultiGridSelList newElementMultiGridSelList = null;
                this.getNextMultiControlFromPanel(ref nrToLoad, ref IsMultiGrid, ref newElement, ref newElementMultiGridSelList, ref IDApplication);
                if (IsMultiGrid)
                {
                    newElementMultiGridSelList.Top = lastTop + 4;
                }
                else
                {
                    newElement.Top = lastTop + 4;
                }

                if (!headerQry)
                {
                    if (IsMultiGrid)
                    {
                        newElementMultiGridSelList.OwnOrderLineNr = nrToLoad;
                        newElementMultiGridSelList.TabIndex = nrToLoad;
                        newElementMultiGridSelList.rQry = rQry;
                        newElementMultiGridSelList.rSelListQry = rSelectedSelList;
                        newElementMultiGridSelList.IDGroupReport = IDQueryGroup;
                        newElementMultiGridSelList.isSubQuery = isSubQuery;
                        //newElementMultiGridSelList.Height = 400;
                        counterPar += 1;
                    }
                    else
                    {
                        newElement.infragLabelLeft.Appearance.ForeColor = System.Drawing.Color.Black;
                        newElement.infragLabelLeft.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                        newElement.msPanelControls3.Visible = true;

                        newElement.OwnOrderLineNr = 1;
                        newElement.OwnOrderControlNr = nrToLoad;
                        newElement.rQry = rQry;
                        newElement.rSelListQry = rSelectedSelList;
                        newElement.isSubQuery = isSubQuery;
                        newElement.IDGroupReport = IDQueryGroup;

                        newElement.OwnLevelLeftWidth = 250;
                        newElement.ownMCTxt1.SelectedText = "";
                        newElement.ownMCTxt1.TextTranslated = "";
                        newElement.ownMCTxt1.TextCombinationTranslated = "";

                        this.drawMulticontrol1.setMultiControl(newElement, rQry, rSelectedSelList, typQueryDef, IDApplication, IDParticipant,
                                                                true, true, subCondition, addAdditionalLabel, IDResAdditionalLabel,
                                                                this, ref protocollForAdmin, ref protocolWindow);
                        lstAllMCs.Add(newElement);

                        string sCombination = "";
                        string sCombinationEnd = "";                //IDResAdditionalLabel
                        string sCondition = "";

                        if (rQry.Combination.Trim() != "")
                        {
                            sCombination = rQry.Combination.Trim() + " ";
                        }
                        if (rQry.CombinationEnd.Trim() != "")
                        {
                            sCombinationEnd = " " + rQry.CombinationEnd.Trim();
                        }

                        this.translateSubstring(ref qs2.core.sqlTxt.and, ref sCombination);
                        this.translateSubstring(ref qs2.core.sqlTxt.and, ref sCombinationEnd);

                        this.translateSubstring(ref qs2.core.sqlTxt.or, ref sCombination);
                        this.translateSubstring(ref qs2.core.sqlTxt.or, ref sCombinationEnd);

                        this.translateSubstring(ref qs2.core.sqlTxt.like, ref sCombination);
                        this.translateSubstring(ref qs2.core.sqlTxt.like, ref sCombinationEnd);

                        if (counterPar > 0)
                        {
                            newElement.ownMCTxt1.TextCombinationTranslated = "" + sCombination.Trim() + "";
                        }
                        newElement.ownMCTxt1.TextCombinationEndTranslated = "" + sCombinationEnd.Trim() + "";

                        if (rQry.Condition.Trim() != "")
                        {
                            sCondition = rQry.Condition.Trim();
                        }

                        string IDResAdditionalLabelTranslated = qs2.core.language.sqlLanguage.getRes(IDResAdditionalLabel);
                        if (IDResAdditionalLabelTranslated.Trim() == "")
                        {
                            IDResAdditionalLabelTranslated = IDResAdditionalLabel.Trim();
                        }
                        string placeComb1 = "";
                        if (newElement.ownMCTxt1.TextCombinationTranslated.Trim() != "")
                        {
                            placeComb1 = " ";
                        }
                        if (rQry.Condition.Trim() == qs2.core.sqlTxt.between.Trim().ToString())
                        {
                            string place2 = "";
                            if (IDResAdditionalLabelTranslated.Trim() != "")
                            {
                                place2 = " ";
                            }
                            newElement.infragLabelLeft.Text = newElement.ownMCTxt1.TextCombinationTranslated + placeComb1 + newElement.infragLabelLeft.Text + place2 + IDResAdditionalLabelTranslated + "";
                        }
                        else
                        {
                            string placeCond = "";
                            if (sCondition.Trim() != "")
                            {
                                placeCond = " ";
                            }
                            newElement.infragLabelLeft.Text = newElement.ownMCTxt1.TextCombinationTranslated + placeComb1 + newElement.infragLabelLeft.Text + placeCond + sCondition + "";
                        }

                        newElement.infragLabelRight.Text = newElement.ownMCTxt1.TextCombinationEndTranslated;

                        //newElement.infragLabelLeft.Text = sCombination + sCondition + newElement.infragLabelLeft.Text + sCombinationEnd;

                        newElement.OwnOrderLineNr = nrToLoad;
                        newElement.TabIndex = nrToLoad;

                        //if (newElement.OwnControlType.Trim().ToLower() == core.Enums.eControlType.ComboBox.ToString().Trim().ToLower())
                        //{
                        //    if (newElement.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.design.auto.ownMCCriteria.cVariablesValues.Roles)
                        //    {
                        //        if (newElement.ComboBox.Rows.Count > 0)
                        //        {
                        //            newElement.ComboBox.SelectedRow = newElement.ComboBox.Rows[0];
                        //        }
                        //    }
                        //}

                        counterPar += 1;
                    }
                }
                else
                {
                    newElement.isSubQuery = isSubQuery;
                    newElement.rSelListQry = rSelectedSelList;
                    newElement.Visible = true;
                    newElement._controlType = core.Enums.eControlType.Label;
                    newElement.isParameterHeader = true;

                    newElement.ownMCCriteria1.Application = IDApplication;   // OMC.IDApplication.Check
                    newElement.ownMCCriteria1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();      //IDParticipant;

                    string IDResToTranslate = "";
                    if (!headerParameters)
                    {
                        newElement.OwnFldShort = rSelectedSelList.IDRessource;
                    }
                    else
                    {
                        newElement.OwnFldShort = "Parameters";
                    }
                    IDResToTranslate = newElement.OwnFldShort;

                    newElement.ownMCTxt1.SelectedText = "";
                    newElement.ownMCTxt1.TextTranslated = "";

                    newElement.ownMCCriteria1.initControl();
                    newElement._OwnLevelLeftVisible = true;
                    newElement.setControl(false);
                    this.drawMulticontrol1.translateLabel(IDResToTranslate, ref newElement, IDApplication, qs2.core.license.doLicense.eApp.ALL.ToString(), true);
                    newElement.ownMCTxt1.TextTranslated = newElement.infragLabelLeft.Text;
                    newElement.msPanelControls3.Visible = false;

                    newElement.TabStop = false;
                    newElement.infragLabelLeft.UseAppStyling = false;
                    newElement.infragLabelRight.Visible = false;
                    newElement.infragLabelRight.Text = "";
                }

                if (IsMultiGrid)
                {
                    nrToLoad += 1;
                    lastTop = newElementMultiGridSelList.Top + newElementMultiGridSelList.Height;
                }
                else
                {
                    nrToLoad += 1;
                    lastTop = newElement.Top + newElement.Height;
                }

                return newElement;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.addParameter: " + ex.ToString());
                //return null;
            }
        }

        public bool getNextMultiControlFromPanel(ref int nrToLoad, ref bool SearchForGrid,
                                                    ref qs2.design.auto.multiControl.ownMultiControl newElementMultiControl,
                                                    ref qs2.design.auto.multiControl.ownMultiGridSelList newElementMultiControlSelList,
                                                    ref string IDApplication)
        {
            try
            {
                bool ControlFound = false;
                foreach(Control cont in this.panelParameters.Controls)
                {
                    if (!SearchForGrid && cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ElementMultiControlFound = (qs2.design.auto.multiControl.ownMultiControl)cont;
                        if (!ElementMultiControlFound.IsInUseInparameterList)
                        {
                            newElementMultiControl = ElementMultiControlFound;
                            newElementMultiControl.IsInUseInparameterList = true;
                            newElementMultiControl.Visible = true;
                            newElementMultiControl.IsBetweenControlSecondValue = false;
                            ControlFound = true;
                            return true;
                        }
                    }
                    else if (SearchForGrid && cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        qs2.design.auto.multiControl.ownMultiGridSelList ElementMultiSelListControlFound = (qs2.design.auto.multiControl.ownMultiGridSelList)cont;
                        if (!ElementMultiSelListControlFound.IsInUseInparameterList)
                        {
                            newElementMultiControlSelList = ElementMultiSelListControlFound;
                            newElementMultiControlSelList.IsInUseInparameterList = true;
                            
                            newElementMultiControlSelList.IsVisibleControl = true;
                            newElementMultiControlSelList.ownControlUI1.IsVisible_Criteriaxy = true;
                            newElementMultiControlSelList.IsVisibleControlAssignmentChapters = true;
                            newElementMultiControlSelList.Visible = true;
                            newElementMultiControlSelList.doVisible();
                            newElementMultiControlSelList.clearUI();

                            ControlFound = true;
                            return true;
                        }
                    }
                }

                if (!ControlFound && !SearchForGrid)
                {
                    newElementMultiControl = new qs2.design.auto.multiControl.ownMultiControl();
                    newElementMultiControl.Visible = true;

                    newElementMultiControl.placeFix = true;
                    newElementMultiControl.Left = 15;
                    newElementMultiControl.Width = 510;

                    newElementMultiControl.Height = elementHeigth;
                    newElementMultiControl.OwnLevelLeftVisible = true;
                    newElementMultiControl.OwnLevelLeftWidth = 250;
                    newElementMultiControl.OwnLevelRightVisible = true;
                    newElementMultiControl.OwnLevelTopVisible = false;
                    newElementMultiControl.OwnLevelLeftOrientationHoriz = Infragistics.Win.HAlign.Left;
                    newElementMultiControl.IsInUseInparameterList = true;
                    newElementMultiControl.IsBetweenControlSecondValue = false;

                    this.panelParameters.Controls.Add(newElementMultiControl);
                    return true;
                }
                else if (!ControlFound && SearchForGrid)
                {
                    newElementMultiControlSelList = new design.auto.multiControl.ownMultiGridSelList();
                    newElementMultiControlSelList.Visible = true;

                    newElementMultiControlSelList.ownMCCriteria1.Application = IDApplication;
                    newElementMultiControlSelList.ownMCCriteria1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                    newElementMultiControlSelList.IsQueryControl = true;
                    newElementMultiControlSelList._typMultiControl = sqlAdmin.eTypStayAdditions.multiSelLists;
                    newElementMultiControlSelList.OwnFldShortTitle = "gridConFactors";

                    string[] fldShorts = new string[4];
                    fldShorts[0] = "Cardiac_conFactorClass";
                    fldShorts[1] = "Cardiac_conFactorGroup";
                    fldShorts[2] = "Cardiac_conFactorSubGroup";
                    fldShorts[3] = "Cardiac_conFactor";

                    newElementMultiControlSelList._FldShort = fldShorts;
                    newElementMultiControlSelList.doText();
                    newElementMultiControlSelList.initControl();

                    newElementMultiControlSelList.setEditable(true);
                    newElementMultiControlSelList.IsInUseInparameterList = true;
                    newElementMultiControlSelList.Height = 400;
                    newElementMultiControlSelList.Left = this.panelParameters.Left;
                    newElementMultiControlSelList.Width = this.panelParameters.Width - 20;

                    newElementMultiControlSelList.IsVisibleControl = true;
                    newElementMultiControlSelList.ownControlUI1.IsVisible_Criteriaxy = true;
                    newElementMultiControlSelList.IsVisibleControlAssignmentChapters = true;
                    newElementMultiControlSelList.Visible = true;
                    newElementMultiControlSelList.doVisible();

                    this.panelParameters.Controls.Add(newElementMultiControlSelList);
                    newElementMultiControlSelList.Top = 0;

                    Application.DoEvents();
                    return true;
                }

                throw new Exception("getNextMultiControlFromPanel: No Control found or added to this.panelParameters.Controls!");
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.getNextMultiControlFromPanel: " + ex.ToString());
            }
        }

        public void translateSubstring(ref string StrToTranslate, ref string StrToSearch)
        {
            try
            {
                if (StrToSearch.Trim().Contains(StrToTranslate.Trim()))
                {
                    string sTranslated = qs2.core.language.sqlLanguage.getRes(StrToTranslate).Trim();
                    if (sTranslated.Trim() != "")
                    {
                        StrToSearch = StrToSearch.Replace(StrToTranslate.Trim(), sTranslated.Trim());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.translateSubstring: " + ex.ToString());
            }
        }
      
        public void openSQLStatment(qs2.ui.print.infoQry infoQryRunPar)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string title = "Sql";
                if (this.mainWindow != null)
                    title = this.mainWindow.Text;

                string parameters = this.genReport1.getParametersStr(infoQryRunPar.parametersSql);
                this.genReport1.openSQLStatment(infoQryRunPar.Sql + parameters, title);
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

        public void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool viewIsFunction = false;
                System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                this.doReportQuery(false, ref viewIsFunction, ref lstParForExternFct, false);
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

        public bool doReportQuery(bool datasetViewer, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct, 
                                    bool SqlForAdmin, bool getWhereSql = false)
        {
            try
            {
                string sqlTotal3 = "";

                bool abortSql = false;
                bool bDoActionMulticontrols = true;
                string WhereClauselForSimpleFunctions = "";
                string SqlWhereInfoTotal = "";
                this.infoReport.newRun();
                foreach (qs2.ui.print.infoQry infoQryRunPar in this.lstInfoQryRunning)
                {
                    if (!infoQryRunPar.isSubQuery)
                    {
                        infoQryRunPar.newRun();

                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids = new List<design.auto.multiControl.ownMultiGridSelList>();
                        this.runInfoSubQuery(infoQryRunPar, ref lstMultiControl, ref lstReturnMultiGrids);

                        bool BracketsOK = false;
                        string WhereClauselForSimpleFunctionsTmp = "";
                        infoQryRunPar.isStayReport = this.isStayReport;
                        infoQryRunPar.IDGuid = this.IDGuid;
                        this.genReport1.runQueryReport2(true, lstMultiControl, ref lstReturnMultiGrids, this.typRunQuery, infoQryRunPar,
                                                        ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref lstParForExternFct, SqlForAdmin, true, ref BracketsOK);
                        SqlWhereInfoTotal += " " + infoQryRunPar.SqlWhereInfo + "\r\n";
                        WhereClauselForSimpleFunctions += " " + WhereClauselForSimpleFunctionsTmp;
                        sqlTotal3 += infoQryRunPar.sqlForAdmin.Trim() + "\r\n" + "\r\n";

                        if (typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups && !getWhereSql)
                        {
                            if (infoQryRunPar.abortSql)
                            {
                                abortSql = true;
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRight"), MessageBoxButtons.OK, "");
                            }
                            else
                            {
                                this.genReport1.openQuery(typRunQuery, infoQryRunPar, datasetViewer, ref viewIsFunction, ref lstParForExternFct, SqlForAdmin);
                            }
                            int countQryRunPar = 0;
                            foreach (qs2.ui.print.infoQry infoQryRunParCheck in this.lstInfoQryRunning)
                                if (!infoQryRunParCheck.isSubQuery)
                                    countQryRunPar += 1;

                            if (countQryRunPar > 1)
                            {
                                throw new Exception("doReportQuery: this.lstInfoQryRunPar for the Query has more then 1 Items!");
                            }

                            this.genReport1.saveProtocol(infoQryRunPar.rSelListQry.IDRessource, this.grpQueryParameter.Text.Trim(), Protocol.eTypeProtocoll.RunQuery, infoReport, infoQryRunPar.sqlForAdmin.Trim(), core.Enums.eTypRunQuery.QueryGroups);
                        }
                        else
                        {
                            if (infoQryRunPar.abortSql)
                            {
                                abortSql = true;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.doReportQuery: " + ex.ToString());
            }
        }

        public void runInfoSubQuery(qs2.ui.print.infoQry infoQryRunPar, ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                    ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids)
        {
            try
            {
                System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunParSub = this.getQryRunPar(true);
                if (infoQryRunPar.typSubreport == core.Enums.eTypSubReport.MainReport)
                {
                    infoQryRunPar.lstInfoQryRunParSub = lstInfoQryRunParSub;
                    foreach (qs2.ui.print.infoQry infoQryRunParSub in this.lstInfoQryRunning)
                    {
                        infoQryRunParSub.newRun();
                        infoQryRunParSub.dsQryResult.DataSetName = "Subquery " + infoQryRunParSub.rSelListQry.IDRessource + " {" + System.Guid.NewGuid().ToString() + "}"; ;
                        this.getLstMultiControlForQuery(infoQryRunParSub.rSelListQry, ref lstMultiControl, ref lstReturnMultiGrids, ref infoQryRunParSub.IDQueryGroup);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.runInfoSubQuery: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<qs2.ui.print.infoQry> getQryRunPar(bool isSubQuery)
        {
            try
            {
                System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunParSub = new System.Collections.Generic.List<qs2.ui.print.infoQry>();
                foreach (qs2.ui.print.infoQry infoQryRunPar in this.lstInfoQryRunning)
                {
                    if (infoQryRunPar.isSubQuery == isSubQuery)
                    {
                        lstInfoQryRunParSub.Add(infoQryRunPar);
                    }
                }
                return lstInfoQryRunParSub;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.getQryRunPar: " + ex.ToString());
                //return null;
            }
        }

        public void getLstMultiControlForQuery(dsAdmin.tblSelListEntriesRow rSelListQry, 
                                                ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstReturn,
                                                ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids,
                                                ref System.Guid IDGroup)
        {
            try
            {
                //lstReturn.Clear();
                foreach (Control cont in this.panelParameters.Controls)
                {
                    if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl multiControl = (qs2.design.auto.multiControl.ownMultiControl)cont;
                        if (multiControl._controlType != core.Enums.eControlType.Label)
                        {
                            if (cont.Visible)
                            {
                                if (multiControl.rSelListQry.ID.Equals(rSelListQry.ID) && multiControl.IDGroupReport.Equals(IDGroup))
                                {
                                    lstReturn.Add(multiControl);
                                }
                            }
                        }
                    }
                    else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        qs2.design.auto.multiControl.ownMultiGridSelList multiControlGrid = (qs2.design.auto.multiControl.ownMultiGridSelList)cont;
                        if (cont.Visible)
                        {
                            if (multiControlGrid.rSelListQry.ID.Equals(rSelListQry.ID) && multiControlGrid.IDGroupReport.Equals(IDGroup))
                            {
                                lstReturnMultiGrids.Add(multiControlGrid);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryRunPar.getLstMultiControlForQuery: " + ex.ToString());
            }
        }
        public void generateSqlSatementAndOpen(dsAdmin.tblSelListEntriesRow rSelListEntry, ref bool viewIsFunction)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string WhereClauselForSimpleFunctions = "";

                this.infoReport.newRun();
                foreach (qs2.ui.print.infoQry infoQryRunPar in this.lstInfoQryRunning)
                {
                    if (!infoQryRunPar.isSubQuery)
                    {
                        if (infoQryRunPar.rSelListQry.ID.Equals(rSelListEntry.ID))
                        {
                            infoQryRunPar.newRun();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstMultiControlMultiGrid = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList>();

                            this.runInfoSubQuery(infoQryRunPar, ref lstMultiControl, ref lstMultiControlMultiGrid);
                            System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                            bool noParticipant = this.genReport1.noParticipant(infoQryRunPar.rSelListQry.Classification.Trim());
                            bool BracketsOK = false;
                            infoQryRunPar.isStayReport = this.isStayReport;
                            infoQryRunPar.IDGuid = this.IDGuid;
                            this.genReport1.generateSql2(true, lstMultiControl, lstMultiControlMultiGrid, infoQryRunPar, this.typRunQuery, false,
                                                        ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref lstParForExternFct, ref noParticipant, false, true, ref BracketsOK, ref infoQryRunPar.SqlWhereAdmin);
                     
                            if (!BracketsOK)
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("QueryClampsNotOK"), MessageBoxButtons.OK, "");

                            this.openSQLStatment(infoQryRunPar);
                        }
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

        public void infoQueries()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //this.genReport1.infoQueries((this.rSelListQry != null ? this.rSelListQry.IDRessource : ""), qs2.core.language.sqlLanguage.getRes("Queries"));
       
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

        private void saveQueriesAsXML(dsAdmin.tblSelListEntriesRow rSelListEntry, ref bool viewIsFunction)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string WhereClauselForSimpleFunctions = "";
                this.infoReport.newRun();
                foreach (qs2.ui.print.infoQry infoQryRunPar in this.lstInfoQryRunning)
                {
                    if (infoQryRunPar.rSelListQry.ID.Equals(rSelListEntry.ID) && !infoQryRunPar.isSubQuery)
                    {
                        infoQryRunPar.newRun();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstMultiControlMultiGrid = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList>();

                        this.runInfoSubQuery(infoQryRunPar, ref lstMultiControl, ref lstMultiControlMultiGrid);
                        System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                        bool noParticipant = this.genReport1.noParticipant(infoQryRunPar.rSelListQry.Classification.Trim());
                        bool ClampsOK = false;
                        infoQryRunPar.isStayReport = this.isStayReport;
                        infoQryRunPar.IDGuid = this.IDGuid;
                        this.genReport1.generateSql2(true, lstMultiControl, lstMultiControlMultiGrid, infoQryRunPar, this.typRunQuery, true,
                                                        ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref lstParForExternFct, ref noParticipant, false, true, ref ClampsOK, ref infoQryRunPar.SqlWhereAdmin);

                        if (!ClampsOK)
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("QueryClampsNotOK"), MessageBoxButtons.OK, "");
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

        public Infragistics.Win.UltraWinToolbars.PopupMenuTool addQueryPopUpToToolbar(string IDResQuery)
        {
            try
            {
                System.Guid ID = System.Guid.NewGuid();
                Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpQuery = new Infragistics.Win.UltraWinToolbars.PopupMenuTool(ID.ToString());
                this.ultraToolbarsManager1.Tools.Add(popUpQuery);
                this.popUpQueries.Tools.AddTool(ID.ToString());

                string IDResFound = qs2.core.language.sqlLanguage.getRes(IDResQuery);
                if (IDResFound.Trim() != "")
                    popUpQuery.SharedProps.Caption = IDResFound;
                else
                    popUpQuery.SharedProps.Caption = IDResQuery;

                return popUpQuery;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        public void addQueryInfoToToolbar(qs2.ui.print.infoQry InfoQryRunPar, eTypToolbar typ, string IDRes, bool IsFirstInGroup,
                                            Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpQuery)
        {
            try
            {
                string keyButt = typ.ToString() + System.Guid.NewGuid().ToString();
                Infragistics.Win.UltraWinToolbars.ButtonTool newToolbarButton = new Infragistics.Win.UltraWinToolbars.ButtonTool(keyButt);
                this.ultraToolbarsManager1.Tools.Add(newToolbarButton);
                
                popUpQuery.Tools.AddTool(keyButt);
                //this.popUpQueries.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { newToolbarButton });

                newToolbarButton.Tag = InfoQryRunPar;
                this.ultraToolbarsManager1.Tools[keyButt].Tag = InfoQryRunPar;

                //Infragistics.Win.UltraWinToolbars.ToolBase ToolBase1 = (Infragistics.Win.UltraWinToolbars.ToolBase)newToolbarButton;
                //ToolBase1.InstanceProps.IsFirstInGroup = IsFirstInGroup;

                newToolbarButton.SharedProps.Caption = qs2.core.language.sqlLanguage.getRes(IDRes);

                //string txtCaption = qs2.core.language.sqlLanguage.getRes(IDRes);
                //string IDResFound = qs2.core.language.sqlLanguage.getRes(InfoQryRunPar.rSelListQry.IDRessource);
                //string keyRes = " (" + InfoQryRunPar.rSelListQry.IDRessource + ")";
                //if (IDResFound.Trim() != "")
                //    newToolbarButton.SharedProps.Caption = IDResFound + keyRes + ": " + txtCaption;
                //else
                //    newToolbarButton.SharedProps.Caption = InfoQryRunPar.rSelListQry.IDRessource + keyRes + ": " + txtCaption;

            }
            catch (Exception ex)
            {
                throw new Exception("addQueryInfoToToolbar: " + ex.ToString());
            }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string protocollForAdmin = "";
                bool protocolWindow = true;

                if (e.Tool.Key.Equals("btnManageQueries"))
                {
                    this.openManageQueriesForReport(this.infoReport.rSelListReport, this.infoReport.Application, this.infoReport.Participant, ref protocollForAdmin, ref protocolWindow );

                    // else if (e.Tool.Key == "btnInfoQueries")
                    //{
                    //    this.infoQueries();
                    //}
                }
                else if (e.Tool.Key.Equals("openReportDirectory"))
                {
                    qs2.core.generic.openWindowsExplorer(qs2.core.ENV.path_reports + "\\" + this.infoReport.Application);
                }                   
                else if(e.Tool.Key.Substring(0, 9).Equals(eTypToolbar.EditQuery.ToString()))
                {
                    qs2.ui.print.infoQry InfoQryRunPar = (qs2.ui.print.infoQry)this.ultraToolbarsManager1.Tools[e.Tool.Key].Tag;
                    this.openQryManager(InfoQryRunPar.rSelListQry, InfoQryRunPar.Application, InfoQryRunPar.Participant, ref protocollForAdmin, ref protocolWindow);
                }
                else if (e.Tool.Key.Substring(0, 7).Equals(eTypToolbar.SaveXSD.ToString()))
                {
                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tAllParametersForReport = new qs2.core.vb.dsAdmin.tblQueriesDefDataTable();
                    qs2.ui.print.infoQry InfoQryRunPar = (qs2.ui.print.infoQry)this.ultraToolbarsManager1.Tools[e.Tool.Key].Tag;
                    bool viewIsFunction = false;
                    this.saveQueriesAsXML(InfoQryRunPar.rSelListQry, ref viewIsFunction);
                }
                else if (e.Tool.Key.Substring(0, 13).Equals(eTypToolbar.GenSqlAndOpen.ToString()))
                {
                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tAllParametersForReport = new qs2.core.vb.dsAdmin.tblQueriesDefDataTable();
                    qs2.ui.print.infoQry InfoQryRunPar = (qs2.ui.print.infoQry)this.ultraToolbarsManager1.Tools[e.Tool.Key].Tag;
                    bool viewIsFunction = false;
                    this.generateSqlSatementAndOpen(InfoQryRunPar.rSelListQry, ref viewIsFunction);
                }

                if (protocollForAdmin.Trim() != "")
                {
                    qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
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
        public void openQryManager(dsAdmin.tblSelListEntriesRow rSelListQry, string Application, string Participant,
                                    ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.ui.print.frmQryAdmin frmQryAdmin = new qs2.ui.print.frmQryAdmin();
                frmQryAdmin.contQryAdmin1.contSelListQueries.rSelListEntryToLoad = rSelListQry;
                frmQryAdmin.contQryAdmin1.typeQuery = core.Enums.eTypeQuery.Admin;
                frmQryAdmin.contQryAdmin1.DefaultApplication = Application;
                frmQryAdmin.contQryAdmin1.IDParticipant = Participant;
                frmQryAdmin.ShowDialog();
                if (frmQryAdmin.contQryAdmin1.saveIsClicked)
                    this.refreshQueryReport(ref protocollForAdmin, ref protocolWindow);
            }
            catch (Exception ex)
            {
                throw new Exception("openQryManager: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void openManageQueriesForReport(dsAdmin.tblSelListEntriesRow rSelListReport, string Application, string Participant,
                                                 ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                System.Collections.ArrayList lstClassification = new System.Collections.ArrayList();

                string SublistToLoad = "Queries";
                qs2.sitemap.vb.frmSelListsObj frmSelLists = new qs2.sitemap.vb.frmSelListsObj();
                frmSelLists.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelListReport.ID;
                frmSelLists.ContSelListsObj1.grpToLoad = SublistToLoad;

                lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString());
                lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString());
                lstClassification.Add("");

                frmSelLists.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList;
                frmSelLists.ContSelListsObj1.typ = sitemap.vb.contSelListsObj.eTyp.saveForSelList;

                frmSelLists.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, sitemap.vb.contSelListsObj.eTypUI.normal, true,
                                         Application, Participant, SublistToLoad, rSelListReport.IDRessource);
                frmSelLists.ShowDialog(this);
                if (frmSelLists.savedClicked)
                {
                    qs2.ui.drawReportGroups drawReportGroups1 = new qs2.ui.drawReportGroups();
                    drawReportGroups1.loadButtonDataReports(this.infoReport.reportButt, this.infoReport.rSelListReport, this.infoReport.Application);

                    this.lstInfoQryRunning.Clear();
                    this.popUpQueries.Tools.Clear();
                    this.popUpQueries.SharedProps.Visible = true;

                    qs2.ui.pint.contQryRun.tgReportButton tgButt = ( qs2.ui.pint.contQryRun.tgReportButton)this.infoReport.reportButt.Tag;
                    this.infoReport.newRun();
                    this.setVisibleMultiControls(false);
                    this.resetDrawParameters();

                    int counterPar = 0;
                    foreach (dsAdmin.tblSelListEntriesRow rQry in tgButt.rSelListsQry)
                    {
                        qs2.ui.print.infoQry infoQryRunParNew = new qs2.ui.print.infoQry();
                        infoQryRunParNew.rSelListQry = rQry;
                        drawReportGroups1.getQryObjForReport(ref infoQryRunParNew, ref tgButt);
                        infoQryRunParNew.rSelListReport = tgButt.rSelListsReports;
                        infoQryRunParNew.Participant = this.infoReport.Participant;
                        infoQryRunParNew.Application = this.infoReport.Application;

                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                        this.drawParameters2(this.grpQueryParameter.Text, infoQryRunParNew, this.infoReport, true, false, false, ref protocollForAdmin, ref protocolWindow, ref counterPar, false, ref lstAllMCs);
                        this.checkMCForParent(ref lstAllMCs);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("openManageQueriesForReport: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void refreshQueryReport(ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.popUpQueries.Tools.Clear();
                this.popUpQueries.SharedProps.Visible = true;

                this.infoReport.newRun();
                this.setVisibleMultiControls(false);
                this.resetDrawParameters();

                int counterPar = 0;
                foreach (qs2.ui.print.infoQry infoQry1 in this.lstInfoQryRunning)
                {
                    infoQry1.clearDatasets();

                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                    this.drawParameters2(this.grpQueryParameter.Text, infoQry1, this.infoReport, false, false, false, ref protocollForAdmin, ref protocolWindow, ref counterPar, false, ref lstAllMCs);
                    this.checkMCForParent(ref lstAllMCs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("refreshQueryReport: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void manageQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.contSelListQueries1.cboQuerySelect.ActiveRow != null)
                {
                    string protocollForAdmin = "";
                    bool protocolWindow = true;

                    dsAdmin.tblSelListEntriesRow rSelListEntry = this.contSelListQueries1.getSelectedQuery(false);
                    this.openQryManager(rSelListEntry, this.contSelListQueries1.Application, this.contSelListQueries1.Participant, ref protocollForAdmin, ref protocolWindow);

                    if (protocollForAdmin.Trim() != "")
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
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

        private void openResultsInTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool viewIsFunction = false;
                System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                this.doReportQuery(true, ref viewIsFunction, ref lstParForExternFct, false);
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

        public qs2.ui.print.infoQry getNewInfoQryRunPar(int actNr, bool addQryAtEnd)
        {
            try
            {
                qs2.ui.print.infoQry infoQryRunParNew = null;
                if (addQryAtEnd)
                {
                    infoQryRunParNew = new qs2.ui.print.infoQry();
                    this.lstInfoQry.Add(infoQryRunParNew);
                }
                else
                {
                    if (this.lstInfoQry.Count > actNr)
                    {
                        infoQryRunParNew = this.lstInfoQry[actNr];
                        infoQryRunParNew.clearAll();
                    }
                    else
                    {
                        infoQryRunParNew = new qs2.ui.print.infoQry();
                        this.lstInfoQry.Add(infoQryRunParNew);
                    }
                }
                
                return infoQryRunParNew;
            }
            catch (Exception ex)
            {
                throw new Exception("getNewInfoQryRunPar: " + ex.ToString());
                //return null;
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //string Info = "Title: " + this.lblTitle.Text.Trim() + "\r\n" + 
                //                "Type: " + this.typRunQuery.ToString() + "\r\n" +
                //                ":" + "";
                string Info = "";
                string IDRessourceTitle = "";
                sqlProtocoll.eSelProtocoll typeSelect = new sqlProtocoll.eSelProtocoll();
                if (this.typRunQuery == core.Enums.eTypRunQuery.QueryGroups)
                {
                    typeSelect = sqlProtocoll.eSelProtocoll.RunQuery;
                    IDRessourceTitle = qs2.core.language.sqlLanguage.getRes("ExecutingQuery");
                }
                else if (this.typRunQuery == core.Enums.eTypRunQuery.ReportGroups)
                {
                      typeSelect = sqlProtocoll.eSelProtocoll.RunReport;
                      IDRessourceTitle = qs2.core.language.sqlLanguage.getRes("OpenReport");
                }
                this.genReport1.showProtocol(Info, infoReport, typeSelect, IDRessourceTitle);
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

        private void contQryRunPar_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {

                }
               
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void generateSqlCommandForCommandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool viewIsFunction = false;
                System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct = new List<core.vb.QS2Service1.cSqlParameter>();
                this.doReportQuery(true, ref viewIsFunction, ref lstParForExternFct, false);

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

        private void panelParameters_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    qs2.design.auto.print.doRelationshipEvaluation.contQryRunPar = this;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
