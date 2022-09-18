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
using Infragistics.Win;





namespace  qs2.ui.print
{



    public partial class contSelListQueries : UserControl
    {
        public string Application = "";
        public string Participant = "";

        public qs2.ui.print.infoQry infoQryMain = null;
        public qs2.ui.print.infoReport infoReportMain = null;
        public qs2.core.Enums.eTypeQuery typeQuery = new qs2.core.Enums.eTypeQuery();
        public dsAdmin.tblSelListEntriesRow rSelListEntryToLoad;

        public qs2.ui.print.contQryAdmin mainWindowQueryManage;
        public qs2.ui.print.contQryRunPar mainWindowQueryPar;
        public bool noSelection = false;

        public qs2.ui.print.infoQry _InfoQryMain = null;
        public bool _allNotPrivateFromOtherUsersxy = false;

        public int _IDSelListQueryReportMain = -999;
        public bool _SubQueries = false;

        public int IDSelListMainControl = -999;
        public bool _IsSubQueriesFromMainControl = false;

        public dsAdmin dsAdminTmp3 = new dsAdmin();
        public sqlAdmin sqlAdminTmp3 = new sqlAdmin();











        public contSelListQueries()
        {
            InitializeComponent();
        }


        public void initControl(string defaultApplication, bool smallGrid, bool showClearButton, bool hideColIDRes,
                                bool ShowButtonSubQueries, bool showSubQueryAssignmentAllQueries, bool IsSubQueriesFromMainControl)
        {
            try
            {
                this.sqlAdmin1.initControl();

                this.loadRes(smallGrid, hideColIDRes);

                this._IsSubQueriesFromMainControl = IsSubQueriesFromMainControl;
                this.btnClearSelection.Visible = showClearButton;
                this.btnRefreshQuery.Visible = !showClearButton;

                if (!ShowButtonSubQueries)
                {
                    this.btnSubQueries.Visible = ShowButtonSubQueries;
                }

                this.btnSubQueriesAll.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Abrechnung.ico_Tagsatzliste, 32, 32);

                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                toolTipInfo.ToolTipText = qs2.core.language.sqlLanguage.getRes("AssignSubqueries");
                toolTipInfo.ToolTipTitle = "";
                this.UltraToolTipManager1.SetUltraToolTip(this.btnSubQueriesAll, toolTipInfo);

                sqlAdminTmp3.initControl();

                if (showSubQueryAssignmentAllQueries)
                {
                    this.btnSubQueriesAll.Visible = qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightManageQueries, false);
                }
                else
                {
                    this.btnSubQueriesAll.Visible = false;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadRes(bool smallGrid, bool hideColIDRes)
        {
            try
            {
                this.sqlAdmin1.initControl();
                
                this.btnRefreshQuery.initControl();

                foreach( Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.cboQuerySelect.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = false;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName].Hidden = false;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PrivateColumn.ColumnName].Hidden = false;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Width = 400;

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName].Hidden = false;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TableColumn.ColumnName].Hidden = false;

                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDColumn.ColumnName].Hidden = false;
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDColumn.ColumnName].Width = 100;
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = false;
                }

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName].Hidden = true;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Hidden = true;

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeQuery");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName].Width = 90;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TableColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Table");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TableColumn.ColumnName].Width = 200;

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Query");           //"Translation"
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Ressource");
                
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Width = 200;

                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.CreatedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Created");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("User");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PrivateColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Private");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");
                this.cboQuerySelect.DisplayMember = qs2.core.generic.columnNameText;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Published");
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName].Width = 200;
                this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName].Hidden = false;

                //if (hideColIDRes)
                //    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = true;

                if (smallGrid)
                {
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.CreatedColumn.ColumnName].Hidden = true;
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Hidden = true;
                    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName].Hidden = true;
                }

               this.btnRefreshQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("Refresh");
               this.refreshToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Refresh");
               this.btnClearSelection.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ClearSelection");

               this.refreshToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren , 32, 32 );
               this.btnSubQueries.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Intervention.ico_FreierBericht, 32, 32);

               Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
               toolTipInfo.ToolTipText = qs2.core.language.sqlLanguage.getRes("SubQueries");
               toolTipInfo.ToolTipTitle = "";
               this.UltraToolTipManager1.SetUltraToolTip(this.btnSubQueries, toolTipInfo);

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadQueries(dsAdmin.tblSelListEntriesRow rSelListAdded, string actuellApplication, string actuellParticipant,
                                qs2.ui.print.infoQry InfoQryMain, bool allNotPrivateFromOtherUsers, int IDSelListQueryReportMain,
                                bool SubQueries)
        {
            try
            {
                this._allNotPrivateFromOtherUsersxy = allNotPrivateFromOtherUsers;
                this._IDSelListQueryReportMain = IDSelListQueryReportMain;
                this._SubQueries = SubQueries;

                this._InfoQryMain = InfoQryMain;
                this.Application = actuellApplication;
                this.Participant = actuellParticipant;

                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                this.dsAdmin1.tblSelListEntries.Rows.Clear();
                this.dsAdmin1.tblSelListEntriesObj.Rows.Clear();
                if (SubQueries)
                {
                    this.sqlAdmin1.getSelListEntrysObj(IDSelListQueryReportMain, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "Queries", this.dsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.sellist, actuellApplication);
                    this.sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", this.Participant, this.Application, ref this.dsAdmin1, sqlAdmin.eTypAuswahlList.group);
                }
                else
                {
                    if (this.typeQuery == core.Enums.eTypeQuery.Admin)
                    {
                        this.sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", this.Participant, this.Application, ref this.dsAdmin1, sqlAdmin.eTypAuswahlList.group);
                    }
                    else if (this.typeQuery == core.Enums.eTypeQuery.User)
                    {
                        this.sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", this.Participant, this.Application, ref this.dsAdmin1, sqlAdmin.eTypAuswahlList.groupTypEnumUserName, this.typeQuery.ToString(), -999, "", -999, "", "", allNotPrivateFromOtherUsers);
                    }
                }

                this.cboQuerySelect.Refresh();
                //bool toEditMode = false;

                System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow> lstToRemove = new List<dsAdmin.tblSelListEntriesRow>();
                dsAdmin.tblSelListEntriesRow rFirstSelList = null;
                UltraGridRow rowGridFirstSelList = null;
                foreach (UltraGridRow rowGridSelList in this.cboQuerySelect.Rows)
                {
                    DataRowView v = (DataRowView)rowGridSelList.ListObject;
                    dsAdmin.tblSelListEntriesRow rSelList = (dsAdmin.tblSelListEntriesRow)v.Row;

                    string resFoundLevel = qs2.core.language.sqlLanguage.getRes(rSelList.IDRessource, this.Participant, this.Application, false);
                    if (resFoundLevel.Trim() != "")
                        rowGridSelList.Cells[qs2.core.generic.columnNameText].Value = resFoundLevel;
                    else
                        rowGridSelList.Cells[qs2.core.generic.columnNameText].Value = rSelList.IDRessource;

                    bool HasUserHasRight = true;
                    if (rSelList.TypeStr.Trim().ToLower().Equals(("User").Trim().ToLower()) && !rSelList.Published)
                    {
                        if (!rSelList.CreatedUser.Trim().ToLower().Equals(actUsr.rUsr.UserName.Trim().ToLower()))
                        {
                            HasUserHasRight = false;
                            this.dsAdminTmp3.Clear();
                            this.sqlAdminTmp3.getSelListEntrysObj(actUsr.rUsr.ID, core.vb.sqlAdmin.eDbTypAuswObj.UserQueries, core.vb.sqlAdmin.eDbTypAuswObj.UserQueries.ToString(), this.dsAdminTmp3, core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntryIDObject, "", rSelList.ID);
                            if (this.dsAdminTmp3.tblSelListEntriesObj.Rows.Count > 0)
                            {
                                HasUserHasRight = true;
                            }
                        }
                    }

                    bool bIDParticipant = false;
                    //if (this.typeQuery == core.Enums.eTypeQuery.User)
                    //{
                        if (rSelList.IDParticipant.Trim() == "" || rSelList.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()) ||
                            rSelList.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                        {
                            bIDParticipant = true;
                        }
                    //}

                    if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        bIDParticipant = true;
                    }

                    if (SubQueries)
                    {
                        bool bOk = false;
                        foreach (dsAdmin.tblSelListEntriesObjRow rObj in this.dsAdmin1.tblSelListEntriesObj)
                        {
                            if (rObj.IDSelListEntry.Equals(rSelList.ID))
                            {
                                bOk = true;
                            }
                        }
                        if (!bOk || !HasUserHasRight || !bIDParticipant)
                        {
                            lstToRemove.Add(rSelList);
                        }
                    }
                    else
                    {
                        bool bOk = false;
                        if (!rSelList._Private)
                        {
                            bOk = true;
                        }
                        else
                        {
                            if (rSelList.CreatedUser.Trim().ToLower().Equals(qs2.core.vb.actUsr.rUsr.UserName.Trim().ToLower()))
                            {
                                bOk = true;
                            }
                        }
                        if (actUsr.IsAdminSecureOrSupervisor() && this.typeQuery == core.Enums.eTypeQuery.Admin)
                        {
                            bOk = true;
                        }
                        if (bOk && HasUserHasRight && bIDParticipant)
                        {
                            //rSelList.TypeStr = qs2.core.language.sqlLanguage.getRes(rSelList.TypeStr);
                            //OnlySubQueries with same Type as MainQuery
                            if (InfoQryMain != null)
                            {
                                bool bShowAsSubQuery = false;
                                qs2.sitemap.print.print print1 = new qs2.sitemap.print.print();
                                qs2.core.Enums.eStayTyp StayTypeMainQuery = print1.getTypeQuery(InfoQryMain.rSelListQry.Classification.Trim());
                                qs2.core.Enums.eStayTyp StayTypeSubQuery = print1.getTypeQuery(rSelList.Classification.Trim());

                                if (StayTypeSubQuery == StayTypeMainQuery &&
                                    InfoQryMain.rSelListQry.Classification != "" &&
                                    rSelList.Classification != "")
                                {
                                    bShowAsSubQuery = true;
                                }

                                if (!bShowAsSubQuery)
                                {
                                    rowGridSelList.Hidden = true;
                                }
                                else
                                {
                                    //string xy = "";
                                }
                            }


                            if (rSelListAdded != null)
                            {
                                if (rSelListAdded.RowState != DataRowState.Detached && rSelListAdded.RowState != DataRowState.Deleted && rSelListAdded.ID.Equals(rSelList.ID))
                                {
                                    rFirstSelList = rSelListAdded;
                                    rowGridFirstSelList = rowGridSelList;
                                    //toEditMode = true;
                                }
                            }
                            else
                            {
                                if (rFirstSelList == null && this.rSelListEntryToLoad == null)
                                {
                                    rFirstSelList = rSelList;
                                    rowGridFirstSelList = rowGridSelList;
                                }
                                else if (rFirstSelList == null && this.rSelListEntryToLoad != null)
                                {
                                    if (this.rSelListEntryToLoad.ID.Equals(rSelList.ID))
                                    {
                                        rFirstSelList = rSelList;
                                        rowGridFirstSelList = rowGridSelList;
                                    }
                                }
                            }
                        }
                        else
                        {
                            lstToRemove.Add(rSelList);
                        } 
                    }
                }

                foreach (dsAdmin.tblSelListEntriesRow rSelList in lstToRemove)
                {
                    rSelList.Delete();
                }
                this.dsAdmin1.AcceptChanges();
                this.cboQuerySelect.Refresh();

                System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow> lstToDelete = new List<dsAdmin.tblSelListEntriesRow>();
                foreach (dsAdmin.tblSelListEntriesRow rSelList1 in this.dsAdmin1.tblSelListEntries)
                {
                    int CounterExists = 0;
                    foreach (dsAdmin.tblSelListEntriesRow rSelList2 in this.dsAdmin1.tblSelListEntries)
                    {
                        if (rSelList2.ID.Equals(rSelList1.ID))
                        {
                            CounterExists += 1;
                        }
                    }
                    if (CounterExists > 1)
                    {
                        lstToDelete.Add(rSelList1);
                    }
                }
                foreach (dsAdmin.tblSelListEntriesRow rSelListToDelete in lstToDelete)
                {
                    rSelListToDelete.Delete();
                }
                this.dsAdmin1.AcceptChanges();
                this.cboQuerySelect.Refresh();

                //this.cboQuerySelect.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Width = this.cboQuerySelect.Size.Width - 150;
                this.cboQuerySelect.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.cboQuerySelect.DisplayLayout.Bands[0].SortedColumns.Add(qs2.core.generic.columnNameText, false);

                if (!this.noSelection && rFirstSelList != null)
                {
                    //UltraGridRow  RowGridFound  = this.cboQuerySelect.Rows.GetRowWithListIndex(this.dsAdmin1.tblSelListEntries.Rows.IndexOf(rFirstSelList));
                    this.cboQuerySelect.ActiveRow = rowGridFirstSelList;
                    if (this.mainWindowQueryManage != null)
                        this.mainWindowQueryManage.loadQueriesDef(rFirstSelList);
                }
                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }




        private void contSelListQueries_Load(object sender, EventArgs e)
        {

        }

        private void btnRefreshQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.refreshCbo();
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
        public void refreshCbo()
        {
            try
            {

                if (this.mainWindowQueryManage != null)
                {
                    this.mainWindowQueryManage.contFields.clear();
                    this.mainWindowQueryManage.contInputParemeters.clear();
                    this.mainWindowQueryManage.contConditions.clear();
                    this.mainWindowQueryManage.contJoins.clear();
                }

                this.loadQueries(null, this.Application, this.Participant, this._InfoQryMain, this._allNotPrivateFromOtherUsersxy, this._IDSelListQueryReportMain, this._SubQueries);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public dsAdmin.tblSelListEntriesRow getSelectedQuery(bool messageBox)
        {
            try
            {
                if (this.cboQuerySelect.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.cboQuerySelect.ActiveRow.ListObject;
                    dsAdmin.tblSelListEntriesRow rSelectedSelList = (dsAdmin.tblSelListEntriesRow)v.Row;
                    return rSelectedSelList;
                }
                else
                {
                    if (messageBox)
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoQuerySelected") + "!", MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void cboQuerySelect_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.cboQuerySelect.Focused)
                {
                    dsAdmin.tblSelListEntriesRow rSelectedSelList = this.getSelectedQuery(false);
                    if (rSelectedSelList != null)
                    {
                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;

                        int counterPar = 0;
                        if (this.mainWindowQueryManage != null)
                        {
                            this.mainWindowQueryManage.loadQueryDefValueChange("loadQuery", ref protocollForAdmin, ref ProtocolWindow);
                        }
                        else if (this.mainWindowQueryPar != null)
                        {
                            this.mainWindowQueryPar.doSubParameters(rSelectedSelList, ref protocollForAdmin, ref ProtocolWindow, ref counterPar);
                        }

                        if (protocollForAdmin.Trim() != "")
                        {
                            qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
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

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.clearSelection();
                if (this.mainWindowQueryPar != null)
                    this.mainWindowQueryPar.clearControlsSubQuery();
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

        public void clearSelection()
        {
            try
            {
                this.cboQuerySelect.Value = null;
                this.cboQuerySelect.SelectedRow = null;
                this.cboQuerySelect.ActiveRow = null;
                this.cboQuerySelect.Refresh();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void clearData()
        {
            try
            {
                this.dsAdmin1.tblSelListEntries.Rows.Clear();
                this.cboQuerySelect.Refresh();
                this.clearSelection();
                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.refreshCbo();
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

        public System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> getAllQueries()
        {
            try
            {
                System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstSelLists = new System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow>();
                foreach (UltraGridRow rowGridSelList in this.cboQuerySelect.Rows)
                {
                    DataRowView v = (DataRowView)rowGridSelList.ListObject;
                    dsAdmin.tblSelListEntriesRow rSelList = (dsAdmin.tblSelListEntriesRow)v.Row;
                    lstSelLists.Add(rSelList);
                }

                return lstSelLists;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void btnSubQueries_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                    if (this._IsSubQueriesFromMainControl)
                    {
                        this.openSubQueries(this.IDSelListMainControl);
                    }
                    else
                    {
                        dsAdmin.tblSelListEntriesRow rSelectedSelList = this.getSelectedQuery(true);
                        if (rSelectedSelList != null)
                        {
                            this.openSubQueries(rSelectedSelList.ID);
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

        public void openSubQueries(int IDSelList)
        {
            try
            {
                string SublistToLoad = "Queries";
                System.Collections.ArrayList lstClassification = new System.Collections.ArrayList();

                qs2.sitemap.vb.frmSelListsObj frmSelLists = new qs2.sitemap.vb.frmSelListsObj();
                frmSelLists.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = IDSelList;
                frmSelLists.ContSelListsObj1.grpToLoad = SublistToLoad;

                frmSelLists.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList;
                frmSelLists.ContSelListsObj1.typ = sitemap.vb.contSelListsObj.eTyp.saveForSelList;

                string sTxtTitleTranslated = qs2.core.language.sqlLanguage.getRes("SubQueries");
                frmSelLists.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, sitemap.vb.contSelListsObj.eTypUI.SaveSubQueries, true,
                                            Application, Participant, SublistToLoad, sTxtTitleTranslated);
                frmSelLists.ShowDialog(this);
                if (frmSelLists.savedClicked)
                {
                    if (this._IsSubQueriesFromMainControl)
                    {
                        this.loadQueries(null, this.Application, this.Participant, this._InfoQryMain, this._allNotPrivateFromOtherUsersxy, this._IDSelListQueryReportMain, this._SubQueries);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception ("openSubQueries: " + ex.ToString());
            }
        }

        private void btnSubQueriesAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.design.auto.print.frmAllQueriesEditSmall frmAllQueriesEditSmall1 = new design.auto.print.frmAllQueriesEditSmall();
                frmAllQueriesEditSmall1.defaultApplication = this.Application.Trim();
                frmAllQueriesEditSmall1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim();
                frmAllQueriesEditSmall1.initControl();
                frmAllQueriesEditSmall1.ShowDialog(this);

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
