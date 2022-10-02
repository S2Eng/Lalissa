using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using QS2.Resources;
using S2Extensions;


namespace qs2.ui.print
{


    public partial class contTable : UserControl
    {

        //public System.Data.DataSet dsQryResult;
        public frmTable mainWindow;
        public qs2.print.genReport genReport1 = new qs2.print.genReport();
        public string Sql = "";
        public System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
        public string AllParametersAsTxtFromSqlCommand = "";

        public System.Data.DataSet actuellDs = null;

        public qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
        public qs2.core.vb.dsAdmin dsAdmin1 = new qs2.core.vb.dsAdmin();
        public core.vb.dsAdmin dsAdminTemp = new core.vb.dsAdmin();

        public compLayout  compLayout1 = new compLayout();
        public string LayoutKey = "";

        public string TitleDocument = "";
        public string DescriptionDocument = "DescriptionDocument";


        public eTypeUI _typeUI = new eTypeUI();
        public enum eTypeUI
        {
            Query = 0,
            History = 1,
            Protocoll = 2
        }

        public qs2.ui.print.infoQry infoQryRunPar = null;
        public bool noChart = false;

        public qs2.design.auto.print.translateQuery translateQuery1 = new qs2.design.auto.print.translateQuery();
        public qs2.core.ui ui1 = new core.ui();

        public bool doTranslateQuery = true;
        public bool doUnvisibleGuid = false;


        public string Protocoll = "";
        public string ProtocollTitle = "";
        public string ProtocollText = "";
        public int ProtocollCounter = 0;

        public bool ResultQryIsTranslated = false;
        public DataTable dtReturnTranslated = null;

        public System.Collections.Generic.Dictionary<string, string> lstColsTable = new Dictionary<string, string>();
        public string IDApplicationTmp = "";
        public string IDParticipantTmp = "";

        //public bool right_QueryReportOwn = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightQueryReportOwn, false)










        public contTable()
        {
            InitializeComponent();
        }

        private void contTable_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool selectDatasets, eTypeUI typeUI, bool FilterOnOff)
        {
            try
            {
                if (this.mainWindow != null)
                {
                    this.mainWindow.CancelButton = this.btnClose;
                }
                
                this._typeUI = typeUI;
                this.compLayout1.initControl();

                qs2.core.vb.funct.setStyleGrid(ref this.ultraGrid1, false,  true);
                this.doRes(selectDatasets);

                if (actUsr.rUsr.isAdmin || qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.layoutManagerToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.layoutManagerToolStripMenuItem.Visible = false;
                }

                this.chkShowAllRows.Checked = qs2.core.ENV.ShowAllRowsQueryResult;
                this.showAllRowsToolStripMenuItem.Checked = qs2.core.ENV.ShowAllRowsQueryResult;
                this.setUI();

                if (this.isChart())
                {
                    this.tabMain.SelectedTab = this.tabMain.Tabs["Chart"];
                }
                else
                {
                    this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                }

                this.chkFilter.Checked = FilterOnOff;
                qs2.core.vb.funct.setFilterGrid(this.ultraGrid1, FilterOnOff);
                this.panelSearch.Visible = (this._typeUI == eTypeUI.Protocoll ? true : false);

                if (this._typeUI == eTypeUI.Protocoll)
                {
                    this.udteFrom.DateTime = DateTime.Now.AddMonths(-2);
                    this.udteTo.Value = null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadProtocoll(Nullable<DateTime> from, Nullable<DateTime> To, string txt)
        {
            try
            {
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name);
                sqlProtocoll sqlProtocollWork = new sqlProtocoll();
                dsProtocol dsProtocollWork = new dsProtocol();
                sqlProtocollWork.initControl();
                string SqlCommand = "";

                sqlProtocollWork.getProtocol(System.Guid.NewGuid(), ref dsProtocollWork, sqlProtocoll.eSelProtocoll.All, "", System.Guid.Empty, 
                                            qs2.core.generic.idMinus, "", "", from, To, txt, ref SqlCommand, true);

                string protocol = "";
                this.doTable(this.mainWindow.defaultTableNameDataMember, dsProtocollWork, ref protocol, false );
                this.Sql = SqlCommand;

                string sFrom = from != null ? "  from=" + from.Value.Date.ToString("d", ci) : "";
                string sTo = To != null ? sTo = "  to=" + To.Value.Date.ToString("d", ci) : "";
                string sTxt = !String.IsNullOrWhiteSpace(txt) ? sTxt = "  text=" + txt.Trim() : "";
                string sProtocol = sFrom + "" + sTo + "" + sTxt;

                if (!String.IsNullOrWhiteSpace(sProtocol))
                {
                    sProtocol = "Parameters: " + sProtocol;
                }

                using (core.vb.Protocol Protocol1 = new core.vb.Protocol())
                {
                    Protocol1.save2(core.vb.Protocol.eTypeProtocoll.SearchProtocoll, System.Guid.Empty, -999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), qs2.core.license.doLicense.rApplication.IDApplication.Trim(), "", sProtocol.Trim(), core.vb.Protocol.eActionProtocol.None, "", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadProtocoll: " + ex.ToString());
            }
        }
   
        public void setUI()
        {
            try
            {
                if (this._typeUI == eTypeUI.History)
                {
                    this.chkShowAllRows.Checked = true;
                    this.chkShowAllRows.Visible = false;
                    this.layoutManagerToolStripMenuItem.Visible = false;
                    this.openGeneratedSqlStatementToolStripMenuItem.Visible = false;
                    this.openProtocolToolStripMenuItem.Visible = true;
                    this.toolStripSpace04.Visible = true;
                    this.toolStripSpace02.Visible = false;
                }
                else
                {
                    this.openProtocolToolStripMenuItem.Visible = false;
                    this.toolStripSpace04.Visible = false;
                }
                this.chkShowAllRows.Visible = false;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doRes(bool selectDatasets)
        {
            try
            {
                this.grpExport.Text = qs2.core.language.sqlLanguage.getRes("Export");

                this.ultraGrid1.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ...";
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
                //this.btnExportExcel.Text = qs2.core.language.sqlLanguage.getRes("Excel");
                this.btnExportExcel.OwnTooltipText  = qs2.core.language.sqlLanguage.getRes("ExportAsExcel");
                //this.btnExportExcel.Appearance.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_excel, 32, 32 );
                this.chkFilter.Text = qs2.core.language.sqlLanguage.getRes("Filter");

                this.btnExportWord.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ExportAsWord");

                this.btnExportCSV.Text = qs2.core.language.sqlLanguage.getRes("CSV");
                this.btnExportCSV.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ExportCSVFile");

                //this.btnExportPDF.Text = qs2.core.language.sqlLanguage.getRes("PDF");
                this.btnExportPDF.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ExportAsPdf");

                this.btnExportXML.Text = qs2.core.language.sqlLanguage.getRes("XML");
                this.btnExportXML.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ExportXMLFile");

                this.copyColumnToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("CopyValue");

                this.openGeneratedSqlStatementToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenGeneratedSqlStatement");
                this.layoutManagerToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("LayoutManager");

                this.groupByToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("GroupBy");
                
                this.lblDatasets.Text = qs2.core.language.sqlLanguage.getRes("Datasets");
                this.lblTables.Text = qs2.core.language.sqlLanguage.getRes("Tables");

                this.chkShowAllRows.Text = qs2.core.language.sqlLanguage.getRes("ShowAllRows");
                this.shoqAllColumnsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ShowAllColumns");
                this.markSameEntriesWithColorToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("MarkSameEntriesWithAColor");
                this.openProtocolToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenProtocol");
                this.showAllRowsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ShowAllRows");

                this.lblFrom.Text = qs2.core.language.sqlLanguage.getRes("From3");
                this.lblTo.Text = qs2.core.language.sqlLanguage.getRes("To4");

                if (selectDatasets)
                {
                    //this.panelTop.Visible = false;
                    this.panelDatasets.Visible = true;
                    this.openGeneratedSqlStatementToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.panelDatasets.Visible = false;
                }

                this.btnExportPDF.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32);
                this.layoutManagerToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                this.openProtocolToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.btnExportExcel.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                this.btnExportWord.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                this.btnExportPDF.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                this.btnExportXML.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;
                this.btnExportCSV.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;

                //this.btnExportXML.Appearance.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_xml , getRes.ePicTyp.png);
                this.btnExportExcel.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Excel, 32, 32);
                this.btnExportWord.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Winword, 32, 32);
                this.btnExportPDF.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32);
                //this.btnExportCSV.Appearance.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_csv, getRes.ePicTyp.png);
                this.btnSearch.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void clearUI()
        {
            try
            {
                DataSet dsNew = new DataSet();
                this.ultraGrid1.DataSource = dsNew;
                this.ultraGrid1.DataMember = "";
                this.ultraGrid1.DataBind();

                this.ultraGrid1.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("clearUI: " + ex.ToString());
            }
        }

        public void doTable(string tableNameDataMember, System.Data.DataSet ds, ref string protocol, bool IsQueryResultTable)
        {
            try
            {
                if (this.mainWindow != null)
                {
                    this.LayoutKey = "Query " + this.mainWindow.IDApplication + "" + this.mainWindow.IDRessourceTitle;
                }
                else
                {
                    this.LayoutKey = "QueryQs2";
                }

                if (this.doTranslateQuery && IsQueryResultTable)
                {
                    DataTable dtReturn = null;
                    if (!this.ResultQryIsTranslated)
                    {
                        string IDAppliactionTmp = "";
                        if (this.mainWindow != null)
                        {
                            IDAppliactionTmp = this.mainWindow.IDApplication;
                        }
                        else
                        {
                            IDAppliactionTmp = IDApplicationTmp.Trim();
                        }
                        dtReturn = this.translateQuery1.translateSelList(ds.Tables[tableNameDataMember], null, IDAppliactionTmp, ref protocol, false);
                        if (dtReturn == null)
                        {
                            return;
                        }
                        this.ResultQryIsTranslated = true;
                        this.dtReturnTranslated = dtReturn;
                    }
                    else
                    {
                        dtReturn = new DataTable();
                        dtReturn = this.dtReturnTranslated.Copy();
                    }
                    //this.translateQuery1.translateColumnsTRANS(dtReturn, null, this.mainWindow.IDApplication);
                    //ds.Tables.Remove(tableNameDataMember);
                    //ds.Tables.Add(dtReturn);

                    DataSet dsNew = new DataSet();
                    dsNew.DataSetName = ds.DataSetName;
                    foreach (DataTable dtExist in ds.Tables)
                    {
                        if (tableNameDataMember.Trim().ToLower().Equals(dtExist.TableName.Trim().ToLower()))
                        {
                            dsNew.Tables.Add(dtReturn);
                            //string TableNameTmpToCheck = dtExist.TableName.Substring(3, (dtExist.TableName.Length - 3));
                            //if (!dsNew.Tables.Contains(TableNameTmpToCheck))
                            //{
                            //    dsNew.Tables.Add(dtReturn);
                            //}
                        }
                        else
                        {
                            DataTable dtNew = new DataTable();
                            dtNew = dtExist.Copy();
                            dsNew.Tables.Add(dtNew);
                        }
                    }

                    this.infoQryRunPar.dsQryResult = dsNew;
                    //this.ultraGrid1.DataSource = dtReturn;
                    this.ultraGrid1.DataSource = dsNew;
                    this.ultraGrid1.DataMember = tableNameDataMember;
                    this.actuellDs = dsNew;
                }
                else
                {
                    this.ultraGrid1.DataSource = ds;
                    this.ultraGrid1.DataMember = tableNameDataMember;
                    this.actuellDs = ds;
                }

                this.ultraGrid1.DataBind();
                
                this.ultraGrid1.Refresh();
                Application.DoEvents();

                this.sortGrid();
                this.ultraGrid1.Refresh();
                Application.DoEvents();
                
                //this.doDistinctGrid(qs2.core.Settings.ShowAllRowsQueryResult);
                this.ultraGrid1.Refresh();
                Application.DoEvents();
                
                this.doColUnvisibleGrid(this.doUnvisibleGuid);
                this.ultraGrid1.Refresh();
                Application.DoEvents();

                bool selectDatasets = false;
                if (this.mainWindow != null)
                {
                    this.IDApplicationTmp = this.mainWindow.IDApplication;
                    this.IDParticipantTmp = this.mainWindow.IDParticipant;
                    selectDatasets = this.mainWindow.selectDatasets;
                }
                
                this.lstColsTable.Clear();
                if (this.doTranslateQuery && IsQueryResultTable)
                {
                    if (!selectDatasets)
                    {
                        foreach (DataTable table in this.actuellDs.Tables)
                        {
                            foreach (DataColumn col in table.Columns)
                            {
                                string txtToTranslate = col.ColumnName;
                                if (txtToTranslate.Trim().Contains(qs2.core.generic.prefixColAutoTranslate))
                                {
                                    txtToTranslate = txtToTranslate.Substring(qs2.core.generic.prefixColAutoTranslate.Length, txtToTranslate.Length - qs2.core.generic.prefixColAutoTranslate.Length);
                                }
                                string resFound = qs2.core.language.sqlLanguage.getRes(txtToTranslate, this.IDParticipantTmp, this.IDApplicationTmp, true, true);
                                if (resFound.Trim() != "")
                                {
                                    //if (resFound.Trim().Contains(qs2.core.generic.prefixColAutoTranslate))
                                    //{
                                    //    string xy = "";
                                    //}
                                    col.Caption = resFound;
                                    if (!this.lstColsTable.ContainsKey(txtToTranslate.Trim()))
                                    {
                                        this.lstColsTable.Add(txtToTranslate.Trim(), resFound.Trim());
                                    }
                                }
                                else
                                {
                                    //if (col.Caption.Contains(qs2.core.generic.prefixColAutoTranslate))
                                    //{
                                    //    string xy = "";
                                    //}
                                    string resFoundAllApp = qs2.core.language.sqlLanguage.getResAllProdukts(txtToTranslate, this.IDParticipantTmp, this.IDApplicationTmp, false);
                                    if (resFoundAllApp.Trim() != "")
                                    {
                                        col.Caption = resFoundAllApp;
                                        if (!this.lstColsTable.ContainsKey(txtToTranslate.Trim()))
                                        {
                                            this.lstColsTable.Add(txtToTranslate.Trim(), resFoundAllApp.Trim());
                                        }
                                    }
                                    else
                                    {
                                        col.Caption = txtToTranslate;
                                        if (!this.lstColsTable.ContainsKey(txtToTranslate.Trim()))
                                        {
                                            this.lstColsTable.Add(txtToTranslate.Trim(), txtToTranslate.Trim());
                                        }
                                    }
                                }
                            }
                        }
                    } 
                }

                this.ultraGrid1.Refresh();
                bool LayoutFound = false;
                this.compLayout1.doLayoutGrid(this.ultraGrid1, this.LayoutKey, null, ref LayoutFound, true, false, false);
                this.setTitleGrid();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

       
        public bool isChart()
        {
            if (this.infoQryRunPar == null)
            {
                return false;
            }
            {
                if (this.infoQryRunPar.rSelListQry == null)
                {
                    return false;
                }

                if (this.infoQryRunPar.rSelListQry.IDRessource.Trim().ToLower().EndsWith(("KaplanMeier").Trim().ToLower()))
                {
                    return true;
                }
                {
                    return false;
                }
            }
        }

        public void fillComboDatasets(System.Collections.ArrayList lstDatasets)
        {
            try
            {
                this.cboDatasets.Items.Clear();
                this.cboListTables.Items.Clear();
                foreach (System.Data.DataSet ds in lstDatasets)
                {
                    Infragistics.Win.ValueListItem itm = this.cboDatasets.Items.Add(System.Guid.NewGuid().ToString(), ds.DataSetName);
                    itm.Tag = ds;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void fillComboTables(System.Data.DataSet ds)
        {
            try
            {
                this.cboListTables.Items.Clear();

                this.ultraGrid1.DataSource = null;
                this.ultraGrid1.DataMember = "";
                this.ultraGrid1.DataBind();

                foreach (System.Data.DataTable dt in ds.Tables)
                {
                    Infragistics.Win.ValueListItem itm = this.cboListTables.Items.Add(System.Guid.NewGuid().ToString(), dt.TableName);
                    itm.Tag = dt;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public bool openStay(ref System.Data.DataRow rSelRow, ref UltraGridRow selRowGrid, bool showMsgBox)
        {
            try
            {
                foreach (DataColumn rSelCol in rSelRow.Table.Columns)
                {
                    if (rSelCol.DataType.Equals(typeof(System.Guid)) && rSelRow[rSelCol.ColumnName.Trim()].ToString() != "")
                    {
                        qs2.core.db.ERSystem.businessFramework b = new core.db.ERSystem.businessFramework();
                        PMDS.db.Entities.tblStay rStay = b.checkIsStay((Guid)rSelRow[rSelCol.ColumnName.Trim()]);
                        if (rStay != null)
                        {
                            qs2.core.ENV.cParsCalMainFunction pars = new qs2.core.ENV.cParsCalMainFunction();
                            pars.IDGuidStay = rStay.IDGuid;
                            pars.IDApplication = rStay.IDApplication.Trim();
                            pars.StayTyp = (qs2.core .Enums.eStayTyp)rStay.StayTyp;
                            pars.newStay = false;
                            pars.OpenFromEvaluation = true;
                            qs2.core.ENV.CallFunctionMain(core.ENV.eTypeFunction.loadStay, pars);
                            return true;
                        }
                    }
                }

                if (showMsgBox)
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoStayInfoFoundInQuery") + "!", MessageBoxButtons.OK, "");
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("contTable.openStay: " + ex.ToString());
            }
        }

        public void setTitleGrid()
        {
            try
            {
                string IDRes = "Result";
                //string sCount = " (" + ds.Tables[tableNameDataMember].Rows.Count.ToString() + ")";
                string sCount = " (" + this.ultraGrid1.Rows.VisibleRowCount.ToString() + ")";
                string resFound = qs2.core.language.sqlLanguage.getRes(IDRes);
                if (resFound.Trim() != "")
                    this.ultraGrid1.Text = resFound + sCount;
                else
                    this.ultraGrid1.Text = IDRes + sCount;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.Close();

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
        

        private void ultraGrid1_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {

        }
        private void ultraGrid1_AfterRowActivate(object sender, EventArgs e)
        {

        }
        private void ultraGrid1_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            try
            {
                if (e.Row.IsFilterRow)
                    e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                else
                {
                    e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                this.setTitleGrid();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

        }

        private void ultraGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (this.ui1.evDoubleClickOK(ref sender, ref e, ref this.ultraGrid1))
                {
                    UltraGridRow selRowGrid = null;
                    System.Data.DataRow rSelRow = this.getSelectedRow(true, selRowGrid);
                    if (rSelRow != null)
                    {
                        this.openStay(ref rSelRow, ref selRowGrid, false);
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

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.chkFilter.Focused)
                    qs2.core.vb.funct.setFilterGrid(this.ultraGrid1, this.chkFilter.Checked);

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
        private void copyColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.ultraGrid1.ActiveCell != null)
                {
                    Clipboard.SetDataObject(this.ultraGrid1.ActiveCell.Value.ToString());
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


        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.ultraGrid1, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.excel, null, "", "", this.lstColsTable);

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
        private void btnExportWord_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.ultraGrid1, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.word, null, this.TitleDocument.Trim(), this.DescriptionDocument.Trim(), this.lstColsTable);

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
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.ultraGrid1, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.csv, this.actuellDs, "", "", this.lstColsTable);

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
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.ultraGrid1, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.pdf, null, "", "", this.lstColsTable);

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
        private void btnExportXML_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.ultraGrid1, Environment.SpecialFolder.Desktop, sitemap.export.eTypExport.xml, this.actuellDs, "", "", this.lstColsTable);

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

        private void openGeneratedSqlStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string title = this.mainWindow.IDRessourceTitle + ": " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak;
                string parameters = this.genReport1.getParametersStr(this.parameters);
                parameters += "\r\n" + "Parameters direct from SqlCommand:" + "\r\n" + this.AllParametersAsTxtFromSqlCommand;
                this.genReport1.openSQLStatment(title + this.Sql + parameters, "Sql");
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

        private void cboQueries_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboDatasets.Focused)
                {
                    if (this.cboDatasets.SelectedItem != null)
                    {
                        System.Data.DataSet ds = (System.Data.DataSet)this.cboDatasets.SelectedItem.Tag;
                        this.fillComboTables(ds);
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

        private void cboListTables_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string protocol = "";
                if (this.cboListTables.Focused)
                {
                    if (this.cboListTables.SelectedItem != null)
                    {
                        System.Data.DataTable dt = (System.Data.DataTable)this.cboListTables.SelectedItem.Tag;
                        System.Data.DataSet ds = (System.Data.DataSet)this.cboDatasets.SelectedItem.Tag;
                        bool bTranslateTable = false;
                        if (dt.TableName.Trim().ToLower().StartsWith(("Qry").Trim().ToLower()))
                        {
                            bTranslateTable = true;
                        }
                        this.doTable(dt.TableName, ds, ref protocol, bTranslateTable);
                    }
                }

                if (protocol.Trim() != "")
                {
                    frmProtocol frmProt = new frmProtocol();
                    frmProt.initControl();
                    frmProt.Text = "Info: Problems with Query";
                    qs2.core.ENV.lstOpendChildForms.Add(frmProt);
                    frmProt.Show();
                    frmProt.ContProtocol1.setText(protocol.Trim());
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
        

        public void sortGrid()
        {
            try
            {
                this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Clear();
                for (int iCounter = 0; iCounter <= 30; iCounter++)
                {
                    if (iCounter <= this.ultraGrid1.DisplayLayout.Bands[0].Columns.Count - 1)
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridColumn gridCol = this.ultraGrid1.DisplayLayout.Bands[0].Columns[iCounter];
                        this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(gridCol.Key, false); 
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doDistinctGrid(bool bSameRowsVisible)
        {
            try
            {
                this.translateQuery1.lstUnvisibleRows.Clear();
                UltraGridRow lastGridRow = null;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.ultraGrid1.Rows)
                {
                    bool sameDatasInRow = true;

                    DataRowView v = (DataRowView)gridRow.ListObject;
                    DataRow r = (DataRow)v.Row;
                    if (lastGridRow != null)
                    {
                        foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
                        {
                            if (gridRow.Cells[col.Key].Value.ToString() != lastGridRow.Cells[col.Key].Value.ToString())
                            {
                                sameDatasInRow = false;
                            }
                        }
                        if (sameDatasInRow)
                        {
                            this.translateQuery1.lstUnvisibleRows.Add(gridRow);
                        }
                    }

                    lastGridRow = gridRow;
                    sameDatasInRow = true;
                }

                this.setSameRowsVisibleUnvisible(bSameRowsVisible);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setSameRowsVisibleUnvisible(bool bSameRowsVisible)
        {
            foreach (UltraGridRow gridRow in this.translateQuery1.lstUnvisibleRows)
            {
                gridRow.Hidden = !bSameRowsVisible;
                //gridRow.Delete();
            }
        }
        private void ultraGrid1_Click(object sender, EventArgs e)
        {
            if (this.ui1.evClickOK(ref sender, ref e, ref this.ultraGrid1))
            {
                //UltraGridRow selRowGrid = null;
                //System.Data.DataRow rSelRow = this.getSelectedRow(true, selRowGrid);
                //if (rSelRow != null)
                //{
                //}
            }
        }

        public void doColUnvisibleGrid(bool doUnvisibleGuid)
        {
            try
            {
                //this.lstUnvisibleCols.Clear();
                foreach (UltraGridColumn gridCol in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
                {
                    if (doUnvisibleGuid)
                    {
                        if (gridCol.DataType.Equals((typeof(System.Guid))))
                        {
                            this.translateQuery1.lstUnvisibleCols.Add(gridCol.ToString());
                        }
                    }
                    if (gridCol.DataType.Equals((typeof(System.DateTime))))
                    {
                        this.ultraGrid1.DisplayLayout.Bands[0].Columns[gridCol.Key].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                    }
                }

                this.setColsVisibleUnvisible(false);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doColUnvisibleObjects()
        {
            try
            {
                System.Collections.Generic.List<string> lstUnvisibleCols = new System.Collections.Generic.List<string>();

                qs2.core.vb.businessFramework b = new businessFramework();
                dsAdmin.tblSelListEntriesRow[] arrSelListObjFieldInDB = null;
                b.getAllObjectFieldsInProductStay(ref arrSelListObjFieldInDB, false, this.IDApplicationTmp);

                foreach (UltraGridColumn gridCol in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
                {
                    string ColNameTmp = "";
                    if (gridCol.ToString().Trim().ToLower().StartsWith(qs2.core.generic.prefixColAutoTranslate.Trim().ToLower()))
                    {
                        ColNameTmp = gridCol.ToString().Trim().Substring(qs2.core.generic.prefixColAutoTranslate.Trim().Length, gridCol.ToString().Length - qs2.core.generic.prefixColAutoTranslate.Trim().Length);
                    }
                    else
                    {
                        ColNameTmp = gridCol.ToString();
                    }
                    var arrObjectFieldSelList = from rObjectFieldSelList in arrSelListObjFieldInDB.AsEnumerable()
                                                where rObjectFieldSelList.FldShortColumn == ColNameTmp.Trim()
                                                select rObjectFieldSelList;

                    if (arrObjectFieldSelList.Count() > 0)
                    {
                        this.ultraGrid1.DisplayLayout.Bands[0].Columns[gridCol.ToString().Trim()].Hidden = true;
                        //foreach (dsAdmin.tblSelListEntriesRow rQryCondition in arrObjectFieldSelList)
                        //{
                        //}
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("doColUnvisibleObjects: " + ex.ToString());
            }
        }

        public void setColsVisibleUnvisible(bool bOn)
        {
            foreach (string columnName in this.translateQuery1.lstUnvisibleCols)
            {
                if (this.ultraGrid1.DisplayLayout.Bands[0].Columns.Exists(columnName))
                {
                    this.ultraGrid1.DisplayLayout.Bands[0].Columns[columnName].Hidden = !bOn;
                }
                //gridRow.Delete();
            }
        }
        private void ultraGrid1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setTitleGrid();
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
        private void shoqAllColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setColsVisibleUnvisible(this.shoqAllColumnsToolStripMenuItem.Checked);
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

        private void markSameEntriesWithColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.core.vb.funct.setStyleGrid(ref this.ultraGrid1, this.markSameEntriesWithColorToolStripMenuItem.Checked, true);
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

        private void chkShowAllRows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkShowAllRows.Focused)
                {
                    this.setSameRowsVisibleUnvisible(this.chkShowAllRows.Checked);
                    this.setTitleGrid(); 
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

        private void openProtocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.actuellDs.Tables[0].Columns.Contains("Protocol"))
                {
                    UltraGridRow selRowGrid = null;
                    System.Data.DataRow rSelRow = this.getSelectedRow(true, selRowGrid);
                    if (rSelRow != null)
                    {
                        string protocolToShow = rSelRow["Protocol"].ToString();
                        frmProtocol frmProtokoll1 = new frmProtocol();
                        frmProtokoll1.initControl();
                        if (this.actuellDs.Tables[0].Columns.Contains("Info"))
                        {
                            frmProtokoll1.Text = qs2.core.language.sqlLanguage.getRes("Protocol") + " " + rSelRow["Info"].ToString();
                        }
                        qs2.core.ENV.lstOpendChildForms.Add(frmProtokoll1);
                        frmProtokoll1.ShowDialog();
                        frmProtokoll1.ContProtocol1.setText(protocolToShow.Trim());
                    }
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoProtocolExists"), MessageBoxButtons.OK, "");
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

        public System.Data.DataRow getSelectedRow(bool msgBox, UltraGridRow selRowGrid)
        {
            try
            {
                if (this.ultraGrid1.ActiveRow != null)
                {
                    if (this.ultraGrid1.ActiveRow.IsGroupByRow || this.ultraGrid1.ActiveRow.IsFilterRow)
                    {
                        if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.ultraGrid1.ActiveRow.ListObject;
                        System.Data.DataRow rSelRow = (System.Data.DataRow)v.Row;
                        selRowGrid = this.ultraGrid1.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void lblProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                frmProtocol frmProtocol1 = new frmProtocol();
                frmProtocol1.initControl();
                frmProtocol1.Text = this.ProtocollTitle;
                qs2.core.ENV.lstOpendChildForms.Add(frmProtocol1);
                frmProtocol1.Show();
                frmProtocol1.ContProtocol1.setText(this.ProtocollText);

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


        public void openLayoutManager()
        {
            try
            {
                qs2.core.vb.frmLayoutManager frmLayoutManager1 = new qs2.core.vb.frmLayoutManager();
                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1._LayoutKey = this.LayoutKey;
                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.gridUIToSave = this.ultraGrid1;
                frmLayoutManager1.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = cLayoutManager.eTypLayoutGrid.onlyFirstBand;
                frmLayoutManager1.initControl("", false, "", qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() );
                frmLayoutManager1.ContLayoutGrid1.loadData(this.LayoutKey.Trim(), this.LayoutKey.Trim(), true, true, true);
                qs2.core.ENV.lstOpendChildForms.Add(frmLayoutManager1);
                frmLayoutManager1.Show();
                //if (!frmLayoutManager1.ContLayoutGrid1.layoutDeleted)
                //{
                //    this.compLayout1.doLayoutGrid(this.ultraGrid1, this.LayoutKey, null);
                //}
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void layoutManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openLayoutManager();
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

        private void groupByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.groupByToolStripMenuItem.Checked)
                {
                    this.ultraGrid1.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
                }
                else
                {
                    this.ultraGrid1.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;
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

        private void showAllRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setSameRowsVisibleUnvisible(this.showAllRowsToolStripMenuItem.Checked);
                this.setTitleGrid();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadProtocoll((Nullable<DateTime>)this.udteFrom.Value, (Nullable<DateTime>)this.udteTo.Value, this.txtText.Text.Trim());

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
