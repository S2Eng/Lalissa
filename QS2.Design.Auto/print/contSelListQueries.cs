using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolTip;
using qs2.core;
using qs2.core.language;
using qs2.core.license;
using qs2.core.vb;
using qs2.design.auto.multiControl;
using qs2.design.auto.print;
using QS2.Resources;
using qs2.sitemap.vb;

namespace qs2.ui.print
{
    public partial class contSelListQueries : UserControl
    {
        public bool _allNotPrivateFromOtherUsersxy;

        public int _IDSelListQueryReportMain = -999;

        public infoQry _InfoQryMain;
        public bool _IsSubQueriesFromMainControl;
        public bool _SubQueries;
        public string Application = "";

        public dsAdmin dsAdminTmp3 = new dsAdmin();

        public int IDSelListMainControl = -999;

        public infoQry infoQryMain = null;
        public infoReport infoReportMain = null;

        public contQryAdmin mainWindowQueryManage;
        public contQryRunPar mainWindowQueryPar;
        public bool noSelection = false;
        public string Participant = "";
        public dsAdmin.tblSelListEntriesRow rSelListEntryToLoad;
        public sqlAdmin sqlAdminTmp3 = new sqlAdmin();
        public Enums.eTypeQuery typeQuery = new Enums.eTypeQuery();


        public contSelListQueries()
        {
            InitializeComponent();
        }


        public void initControl(string defaultApplication, bool smallGrid, bool showClearButton, bool hideColIDRes,
            bool ShowButtonSubQueries, bool showSubQueryAssignmentAllQueries, bool IsSubQueriesFromMainControl)
        {
            try
            {
                sqlAdmin1.initControl();

                loadRes(smallGrid, hideColIDRes);

                _IsSubQueriesFromMainControl = IsSubQueriesFromMainControl;
                btnClearSelection.Visible = showClearButton;
                btnRefreshQuery.Visible = !showClearButton;

                if (!ShowButtonSubQueries) btnSubQueries.Visible = ShowButtonSubQueries;

                btnSubQueriesAll.Appearance.Image = getRes.getImage(getRes.PMDS_Abrechnung.ico_Tagsatzliste, 32, 32);

                var toolTipInfo = new UltraToolTipInfo();
                toolTipInfo.ToolTipText = sqlLanguage.getRes("AssignSubqueries");
                toolTipInfo.ToolTipTitle = "";
                UltraToolTipManager1.SetUltraToolTip(btnSubQueriesAll, toolTipInfo);

                sqlAdminTmp3.initControl();

                if (showSubQueryAssignmentAllQueries)
                    btnSubQueriesAll.Visible = actUsr.checkRights(Enums.eRights.rightManageQueries, false);
                else
                    btnSubQueriesAll.Visible = false;
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes(bool smallGrid, bool hideColIDRes)
        {
            try
            {
                sqlAdmin1.initControl();

                btnRefreshQuery.initControl();

                foreach (var col in cboQuerySelect.DisplayLayout.Bands[0].Columns) col.Hidden = true;

                cboQuerySelect.DisplayLayout.Bands[0].Columns[generic.columnNameText].Hidden = false;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName]
                    .Hidden = false;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.PrivateColumn.ColumnName]
                    .Hidden = false;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[generic.columnNameText].Width = 400;

                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName]
                    .Hidden = false;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TableColumn.ColumnName]
                    .Hidden = false;

                if (actUsr.IsAdminSecureOrSupervisor())
                {
                    cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDColumn.ColumnName]
                        .Hidden = false;
                    cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDColumn.ColumnName]
                        .Width = 100;
                    cboQuerySelect.DisplayLayout.Bands[0]
                        .Columns[dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = false;
                }

                cboQuerySelect.DisplayLayout.Bands[0]
                    .Columns[dsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName].Hidden = true;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName]
                    .Hidden = true;

                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("TypeQuery");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TypeQryColumn.ColumnName]
                    .Width = 90;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TableColumn.ColumnName].Header
                    .Caption = sqlLanguage.getRes("Table");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TableColumn.ColumnName].Width =
                    200;

                cboQuerySelect.DisplayLayout.Bands[0].Columns[generic.columnNameText].Header.Caption =
                    sqlLanguage.getRes("Query"); //"Translation"
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Ressource");

                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Key");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName]
                    .Width = 200;

                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.CreatedColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Created");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("User");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.PrivateColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Private");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Typ");
                cboQuerySelect.DisplayMember = generic.columnNameText;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName]
                    .Header.Caption = sqlLanguage.getRes("Published");
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName]
                    .Width = 200;
                cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.PublishedColumn.ColumnName]
                    .Hidden = false;

                //if (hideColIDRes)
                //    this.cboQuerySelect.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = true;

                if (smallGrid)
                {
                    cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.CreatedColumn.ColumnName]
                        .Hidden = true;
                    cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName]
                        .Hidden = true;
                    cboQuerySelect.DisplayLayout.Bands[0].Columns[dsAdmin1.tblSelListEntries.TypeStrColumn.ColumnName]
                        .Hidden = true;
                }

                btnRefreshQuery.OwnTooltipText = sqlLanguage.getRes("Refresh");
                refreshToolStripMenuItem.Text = sqlLanguage.getRes("Refresh");
                btnClearSelection.OwnTooltipText = sqlLanguage.getRes("ClearSelection");

                refreshToolStripMenuItem.Image = getRes.getImage(getRes.Allgemein.ico_Aktualisieren, 32, 32);
                btnSubQueries.Appearance.Image = getRes.getImage(getRes.PMDS_Intervention.ico_FreierBericht, 32, 32);

                var toolTipInfo = new UltraToolTipInfo();
                toolTipInfo.ToolTipText = sqlLanguage.getRes("SubQueries");
                toolTipInfo.ToolTipTitle = "";
                UltraToolTipManager1.SetUltraToolTip(btnSubQueries, toolTipInfo);
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadQueries(dsAdmin.tblSelListEntriesRow rSelListAdded, string actuellApplication,
            string actuellParticipant,
            infoQry InfoQryMain, bool allNotPrivateFromOtherUsers, int IDSelListQueryReportMain,
            bool SubQueries)
        {
            try
            {
                _allNotPrivateFromOtherUsersxy = allNotPrivateFromOtherUsers;
                _IDSelListQueryReportMain = IDSelListQueryReportMain;
                _SubQueries = SubQueries;

                _InfoQryMain = InfoQryMain;
                Application = actuellApplication;
                Participant = actuellParticipant;

                var Parameters = new sqlAdmin.ParametersSelListEntries();
                dsAdmin1.tblSelListEntries.Rows.Clear();
                dsAdmin1.tblSelListEntriesObj.Rows.Clear();
                if (SubQueries)
                {
                    sqlAdmin1.getSelListEntrysObj(IDSelListQueryReportMain, sqlAdmin.eDbTypAuswObj.SubSelList,
                        "Queries", dsAdmin1, sqlAdmin.eTypAuswahlObj.sellist, actuellApplication);
                    sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", Participant, Application, ref dsAdmin1,
                        sqlAdmin.eTypAuswahlList.group);
                }
                else
                {
                    if (typeQuery == Enums.eTypeQuery.Admin)
                        sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", Participant, Application, ref dsAdmin1,
                            sqlAdmin.eTypAuswahlList.group);
                    else if (typeQuery == Enums.eTypeQuery.User)
                        sqlAdmin1.getSelListEntrys(ref Parameters, "Queries", Participant, Application, ref dsAdmin1,
                            sqlAdmin.eTypAuswahlList.groupTypEnumUserName, typeQuery.ToString(), -999, "", -999, "", "",
                            allNotPrivateFromOtherUsers);
                }

                cboQuerySelect.Refresh();
                //bool toEditMode = false;

                var lstToRemove = new List<dsAdmin.tblSelListEntriesRow>();
                dsAdmin.tblSelListEntriesRow rFirstSelList = null;
                UltraGridRow rowGridFirstSelList = null;
                foreach (var rowGridSelList in cboQuerySelect.Rows)
                {
                    var v = (DataRowView) rowGridSelList.ListObject;
                    var rSelList = (dsAdmin.tblSelListEntriesRow) v.Row;

                    var resFoundLevel = sqlLanguage.getRes(rSelList.IDRessource, Participant, Application, false);
                    if (resFoundLevel.Trim() != "")
                        rowGridSelList.Cells[generic.columnNameText].Value = resFoundLevel;
                    else
                        rowGridSelList.Cells[generic.columnNameText].Value = rSelList.IDRessource;

                    var HasUserHasRight = true;
                    if (rSelList.TypeStr.Trim().ToLower().Equals("User".Trim().ToLower()) && !rSelList.Published)
                        if (!rSelList.CreatedUser.Trim().ToLower().Equals(actUsr.rUsr.UserName.Trim().ToLower()))
                        {
                            HasUserHasRight = false;
                            dsAdminTmp3.Clear();
                            sqlAdminTmp3.getSelListEntrysObj(actUsr.rUsr.ID, sqlAdmin.eDbTypAuswObj.UserQueries,
                                sqlAdmin.eDbTypAuswObj.UserQueries.ToString(), dsAdminTmp3,
                                sqlAdmin.eTypAuswahlObj.IDSelListEntryIDObject, "", rSelList.ID);
                            if (dsAdminTmp3.tblSelListEntriesObj.Rows.Count > 0) HasUserHasRight = true;
                        }

                    var bIDParticipant = false;
                    if (rSelList.IDParticipant.Trim() == "" || rSelList.IDParticipant.Trim().ToLower()
                            .Equals(doLicense.eApp.ALL.ToString().Trim().ToLower()) ||
                        rSelList.IDParticipant.Trim().ToLower()
                            .Equals(doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                        bIDParticipant = true;

                    if (actUsr.IsAdminSecureOrSupervisor()) bIDParticipant = true;

                    if (SubQueries)
                    {
                        var bOk = false;
                        foreach (var rObj in dsAdmin1.tblSelListEntriesObj)
                            if (rObj.IDSelListEntry.Equals(rSelList.ID))
                                bOk = true;
                        if (!bOk || !HasUserHasRight || !bIDParticipant) lstToRemove.Add(rSelList);
                    }
                    else
                    {
                        var bOk = false;
                        if (!rSelList._Private)
                        {
                            bOk = true;
                        }
                        else
                        {
                            if (rSelList.CreatedUser.Trim().ToLower().Equals(actUsr.rUsr.UserName.Trim().ToLower()))
                                bOk = true;
                        }

                        if (actUsr.IsAdminSecureOrSupervisor() && typeQuery == Enums.eTypeQuery.Admin) bOk = true;

                        if (bOk && HasUserHasRight && bIDParticipant)
                        {
                            if (InfoQryMain != null)
                                if (!(InfoQryMain.rSelListQry.Classification != "" && rSelList.Classification != ""))
                                    rowGridSelList.Hidden = true;

                            if (rSelListAdded != null)
                            {
                                if (rSelListAdded.RowState != DataRowState.Detached &&
                                    rSelListAdded.RowState != DataRowState.Deleted &&
                                    rSelListAdded.ID.Equals(rSelList.ID))
                                {
                                    rFirstSelList = rSelListAdded;
                                    rowGridFirstSelList = rowGridSelList;
                                }
                            }
                            else
                            {
                                if (rFirstSelList == null && rSelListEntryToLoad == null)
                                {
                                    rFirstSelList = rSelList;
                                    rowGridFirstSelList = rowGridSelList;
                                }
                                else if (rFirstSelList == null && rSelListEntryToLoad != null)
                                {
                                    if (rSelListEntryToLoad.ID.Equals(rSelList.ID))
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

                foreach (var rSelList in lstToRemove) rSelList.Delete();
                dsAdmin1.AcceptChanges();
                cboQuerySelect.Refresh();

                var lstToDelete = new List<dsAdmin.tblSelListEntriesRow>();
                foreach (var rSelList1 in dsAdmin1.tblSelListEntries)
                {
                    var CounterExists = 0;
                    foreach (var rSelList2 in dsAdmin1.tblSelListEntries)
                        if (rSelList2.ID.Equals(rSelList1.ID))
                            CounterExists += 1;
                    if (CounterExists > 1) lstToDelete.Add(rSelList1);
                }

                foreach (var rSelListToDelete in lstToDelete) rSelListToDelete.Delete();
                dsAdmin1.AcceptChanges();
                cboQuerySelect.Refresh();

                //this.cboQuerySelect.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Width = this.cboQuerySelect.Size.Width - 150;
                cboQuerySelect.DisplayLayout.Bands[0].SortedColumns.Clear();
                cboQuerySelect.DisplayLayout.Bands[0].SortedColumns.Add(generic.columnNameText, false);

                if (!noSelection && rFirstSelList != null)
                {
                    //UltraGridRow  RowGridFound  = this.cboQuerySelect.Rows.GetRowWithListIndex(this.dsAdmin1.tblSelListEntries.Rows.IndexOf(rFirstSelList));
                    cboQuerySelect.ActiveRow = rowGridFirstSelList;
                    if (mainWindowQueryManage != null)
                        mainWindowQueryManage.loadQueriesDef(rFirstSelList);
                }
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }


        private void contSelListQueries_Load(object sender, EventArgs e)
        {
        }

        private void btnRefreshQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                refreshCbo();
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void refreshCbo()
        {
            try
            {
                if (mainWindowQueryManage != null)
                {
                    mainWindowQueryManage.contFields.clear();
                    mainWindowQueryManage.contConditions.clear();
                }

                loadQueries(null, Application, Participant, _InfoQryMain, _allNotPrivateFromOtherUsersxy,
                    _IDSelListQueryReportMain, _SubQueries);
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public dsAdmin.tblSelListEntriesRow getSelectedQuery(bool messageBox)
        {
            try
            {
                if (cboQuerySelect.ActiveRow != null)
                {
                    var v = (DataRowView) cboQuerySelect.ActiveRow.ListObject;
                    var rSelectedSelList = (dsAdmin.tblSelListEntriesRow) v.Row;
                    return rSelectedSelList;
                }

                if (messageBox)
                    generic.showMessageBox(sqlLanguage.getRes("NoQuerySelected") + "!", MessageBoxButtons.OK, "");
                return null;
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void cboQuerySelect_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (cboQuerySelect.Focused)
                {
                    var rSelectedSelList = getSelectedQuery(false);
                    if (rSelectedSelList != null)
                    {
                        var protocollForAdmin = "";
                        var ProtocolWindow = false;

                        var counterPar = 0;
                        if (mainWindowQueryManage != null)
                            mainWindowQueryManage.loadQueryDefValueChange("loadQuery", ref protocollForAdmin,
                                ref ProtocolWindow);
                        else if (mainWindowQueryPar != null)
                            mainWindowQueryPar.doSubParameters(rSelectedSelList, ref protocollForAdmin,
                                ref ProtocolWindow, ref counterPar);

                        if (protocollForAdmin.Trim() != "") ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                }
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                clearSelection();
                if (mainWindowQueryPar != null)
                    mainWindowQueryPar.clearControlsSubQuery();
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void clearSelection()
        {
            try
            {
                cboQuerySelect.Value = null;
                cboQuerySelect.SelectedRow = null;
                cboQuerySelect.ActiveRow = null;
                cboQuerySelect.Refresh();
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void clearData()
        {
            try
            {
                dsAdmin1.tblSelListEntries.Rows.Clear();
                cboQuerySelect.Refresh();
                clearSelection();
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                refreshCbo();
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public List<dsAdmin.tblSelListEntriesRow> getAllQueries()
        {
            try
            {
                var lstSelLists = new List<dsAdmin.tblSelListEntriesRow>();
                foreach (var rowGridSelList in cboQuerySelect.Rows)
                {
                    var v = (DataRowView) rowGridSelList.ListObject;
                    var rSelList = (dsAdmin.tblSelListEntriesRow) v.Row;
                    lstSelLists.Add(rSelList);
                }

                return lstSelLists;
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void btnSubQueries_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (_IsSubQueriesFromMainControl)
                {
                    openSubQueries(IDSelListMainControl);
                }
                else
                {
                    var rSelectedSelList = getSelectedQuery(true);
                    if (rSelectedSelList != null) openSubQueries(rSelectedSelList.ID);
                }
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void openSubQueries(int IDSelList)
        {
            try
            {
                var SublistToLoad = "Queries";
                var lstClassification = new ArrayList();

                var frmSelLists = new frmSelListsObj();
                frmSelLists.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = IDSelList;
                frmSelLists.ContSelListsObj1.grpToLoad = SublistToLoad;

                frmSelLists.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList;
                frmSelLists.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList;

                var sTxtTitleTranslated = sqlLanguage.getRes("SubQueries");
                frmSelLists.loadData(lstClassification, AutoFitStyle.ExtendLastColumn,
                    contSelListsObj.eTypUI.SaveSubQueries, true,
                    Application, Participant, SublistToLoad, sTxtTitleTranslated);
                frmSelLists.ShowDialog(this);
                if (frmSelLists.savedClicked)
                    if (_IsSubQueriesFromMainControl)
                        loadQueries(null, Application, Participant, _InfoQryMain, _allNotPrivateFromOtherUsersxy,
                            _IDSelListQueryReportMain, _SubQueries);
            }
            catch (Exception ex)
            {
                throw new Exception("openSubQueries: " + ex);
            }
        }

        private void btnSubQueriesAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var frmAllQueriesEditSmall1 = new frmAllQueriesEditSmall();
                frmAllQueriesEditSmall1.defaultApplication = Application.Trim();
                frmAllQueriesEditSmall1.IDParticipant = doLicense.rParticipant.IDParticipant.Trim();
                frmAllQueriesEditSmall1.initControl();
                frmAllQueriesEditSmall1.ShowDialog(this);
            }
            catch (Exception ex)
            {
                generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}