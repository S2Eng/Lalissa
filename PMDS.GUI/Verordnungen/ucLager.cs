using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Global.db.ERSystem;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinToolTip;
using System.Data.OleDb;
using PMDS.GUI.VB;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucLager : UserControl
    {

        public Nullable<Guid> _IDVO = null;
        public string _sZustand = "";

        public bool abort = true;
        public bool IsInitialized = false;

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            IDVO = 0,
            All = 1
        }

        public ucVOErfassen mainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();

        public string colKlient = "Klient";
        public string colAnmerkung = "Anmerkung";
        public string colAbteilung = "Abteilung";
        public string colBereich = "Bereich";








        public ucLager()
        {
            InitializeComponent();
        }

        private void ucLager_Load(object sender, EventArgs e)
        {

        }

        public void initControl(eTypeUI TypeUI)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                if (!this.IsInitialized)
                {
                    this._TypeUI = TypeUI;

                    this.btnAddVO.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                    this.sqlVO1.InitControl();
                    this.sqlManange1.initControl();

                    this.SelListChanged("", null, null);

                    if (this._TypeUI == eTypeUI.IDVO)
                    {
                        this.panelBottom.Visible = true;
                        this.panelTop.Visible = true;
                        this.panelTop.Height = 34;
                        this.btnAddVO.Visible = true;
                        this.btnDel.Visible = true;
                        this.grpSearch.Visible = false;

                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.DatumErstelltColumn.ColumnName].Header.VisiblePosition = 0;
                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.SeriennummerColumn.ColumnName].Header.VisiblePosition = 1;
                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.ZustandColumn.ColumnName].Header.VisiblePosition = 2;

                    }
                    else if (this._TypeUI == eTypeUI.All)
                    {
                        this.panelBottom.Visible = true;
                        this.panelTop.Visible = true;
                        this.btnAddVO.Visible = false;
                        this.btnDel.Visible = true;
                        this.grpSearch.Visible = true;

                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.DatumErstelltColumn.ColumnName].Header.VisiblePosition = 0;
                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.SeriennummerColumn.ColumnName].Header.VisiblePosition = 1;
                        this.gridVOLager.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Lager.ZustandColumn.ColumnName].Header.VisiblePosition = 2;
                    }
                    else
                    {
                        throw new Exception("ucLager.initControl: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                    }

                    this.clearUI();

                    PMDSBusinessUI.dSelListChanged += new PMDSBusinessUI.SelListChanged(this.SelListChanged);

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.initControl: " + ex.ToString());
            }
        }

        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.PMDSBusinessUI2.loadSelList("LAZ", null, this.gridVOLager.DisplayLayout.ValueLists["Zustand"], null, ref lstEmpty, true);
                List<PMDS.db.Entities.AuswahlListe> lstEmpty2 = null;
                this.PMDSBusinessUI2.loadSelList("LAZ", this.cboZustand, null, null, ref lstEmpty2, true);

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.SelListChanged: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                if (this._TypeUI == eTypeUI.IDVO)
                {
                    this.udteFrom.Value = null;
                    this.udteTo.Value = null;
                }
                else if (this._TypeUI == eTypeUI.All)
                {
                    this.udteFrom.Value = DateTime.Now.AddMonths(-6);
                    this.udteTo.Value = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.clearUI: " + ex.ToString());
            }
        }
        public void clearUIGrid()
        {
            try
            {
                this.dsVO1.Clear();
                this.gridVOLager.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.clearUIGrid: " + ex.ToString());
            }
        }

        public void loadData(Nullable<Guid> IDVO, string sZustand)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                this._IDVO = IDVO;
                this._sZustand = sZustand;
                this.clearUIGrid();

                if (this._TypeUI == eTypeUI.IDVO)
                {
                    this.sqlVO1.GetVOLager(this._IDVO.Value, sqlVO.ESelVOLager.IDVO, this.dsVO1, null, null, sZustand, "");
                    this.gridVOLager.Refresh();
                }
                else if (this._TypeUI == eTypeUI.All)
                {
                    string sSeriennummer = "";
                    if (this.txtSeriennummer.Text.Trim() != "")
                    {
                        sSeriennummer = this.txtSeriennummer.Text.Trim();
                    }
                    string sZustand2 = "";
                    if (this.cboZustand.Text.ToString().Trim() != "")
                    {
                        sZustand2 = this.cboZustand.Text.Trim();
                    }

                    Nullable<DateTime> dFrom = null;
                    if (this.udteFrom.Value != null)
                    {
                        dFrom = this.udteFrom.DateTime.Date;
                    }
                    Nullable<DateTime> dTo = null;
                    if (this.udteTo.Value != null)
                    {
                        dTo = this.udteTo.DateTime.Date;
                    }

                    this.sqlVO1.GetVOLager(this._IDVO, sqlVO.ESelVOLager.All, this.dsVO1, dFrom, dTo, sZustand2, sSeriennummer);
                    this.gridVOLager.Refresh();
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    foreach (UltraGridRow rGrid in this.gridVOLager.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, db);
                        }
                        else
                        {
                            this.showGridRow(rGrid, db);
                        }
                    }
                }

                //this.gridVOLager.DisplayLayout.Bands[0].SortedColumns.Clear();
                //this.gridVOLager.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VOLager.DatumErstelltColumn.ColumnName, true);
                //this.gridVOLager.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VOLager.LoginNameFreiErstelltColumn.ColumnName, false);

                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsVO1.VO_Lager.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.loadData: " + ex.ToString());
            }
        }

        public void showGrid_rek(UltraGridRow rFoundInGridParent, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, db);
                        }
                        else
                        {
                            this.showGridRow(rFoundInGrid, db);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.showGrid_rek: " + ex.ToString());
            }
        }
        public void showGridRow(UltraGridRow rFoundInGrid, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                dsVO.VO_LagerRow rVO_Lager = (dsVO.VO_LagerRow)v.Row;

                var tLagDetail = (from lag in db.VO_Lager
                           join vo in db.VO on lag.IDVO equals vo.ID
                           join a in db.Aufenthalt on vo.IDAufenthalt equals a.ID
                           join pat in db.Patient on a.IDPatient equals pat.ID
                           where lag.ID == rVO_Lager.ID
                           select new
                           {
                               IDLager = lag.ID,
                               IDKlient = pat.ID,
                               Anmerkung = vo.Anmerkung,
                               Nachname = pat.Nachname,
                               Vorname = pat.Vorname,
                               IDAufenthalt = vo.IDAufenthalt
                           });
                if (tLagDetail.Count() >= 1)
                {
                    var rLagDetail = tLagDetail.First();
                    rFoundInGrid.Cells[this.colAnmerkung.Trim()].Value = rLagDetail.Anmerkung.Trim();
                    rFoundInGrid.Cells[this.colKlient.Trim()].Value = rLagDetail.Nachname.Trim() + " " + rLagDetail.Vorname.Trim();

                    var tAbteil = (from a2 in db.Aufenthalt
                                   join abt in db.Abteilung on a2.IDAbteilung equals abt.ID
                                   where a2.ID == rLagDetail.IDAufenthalt
                                   select new
                                   {
                                       IDAbteilung = abt.ID,
                                       Abteilung = abt.Bezeichnung
                                   });
                    if (tAbteil.Count() >= 1)
                    {
                        var rAbteil = tAbteil.First();
                        rFoundInGrid.Cells[this.colAbteilung.Trim()].Value = rAbteil.Abteilung.Trim();
                    }

                    var tBereich = (from a2 in db.Aufenthalt
                                   join ber in db.Bereich on a2.IDBereich equals ber.ID
                                   where a2.ID == rLagDetail.IDAufenthalt 
                                   select new
                                   {
                                       IDBereich = ber.ID,
                                       Bereich = ber.Bezeichnung
                                   });
                    if (tBereich.Count() >= 1)
                    {
                        var rBereich = tBereich.First();
                        rFoundInGrid.Cells[this.colBereich.Trim()].Value = rBereich.Bereich.Trim();
                    }
                }



            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.showGridRow: " + ex.ToString());
            }
        }




        public bool getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsVO.VO_LagerRow rVO)
        {
            try
            {
                if (this.gridVOLager.ActiveRow != null)
                {
                    if (this.gridVOLager.ActiveRow.IsGroupByRow || this.gridVOLager.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridVOLager.ActiveRow.ListObject;
                        dsVO.VO_LagerRow rSelRow = (dsVO.VO_LagerRow)v.Row;
                        gridRow = this.gridVOLager.ActiveRow;
                        rVO = rSelRow;
                        return true;
                    }

                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.getSelectedRow: " + ex.ToString());
            }
        }


        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.gridVOLager, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.clearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridVOLager.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsVO.VO_LagerRow rSelRow = (dsVO.VO_LagerRow)v.Row;

                    if (rSelRow.RowState != DataRowState.Deleted)
                    {
                        if (rSelRow.Seriennummer.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.gridVOLager, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lager Seriennummer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                        if (rSelRow.Zustand.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.gridVOLager, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lager Zustand: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }

                this.sqlVO1.da_VOLager.Update(this.dsVO1.VO_Lager);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.loadData: " + ex.ToString());
            }
        }



        public bool addRow()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                    DateTime dNow = DateTime.Now;

                    dsVO.VO_LagerRow rNew = this.sqlVO1.GetNewRowVOLager(ref this.dsVO1);
                    rNew.Seriennummer = "";
                    rNew.Zustand = "";
                    rNew.IDVO = this._IDVO.Value;
                    rNew.DatumErstellt = dNow;
                    rNew.DatumGeaendert = dNow;
                    rNew.IDBenutzerErstellt = rBenutzer.ID;
                    rNew.IDBenutzerGeaendert = rBenutzer.ID;
                    rNew.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    rNew.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                    this.gridVOLager.Refresh();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.addRow: " + ex.ToString());
            }
        }
        public bool delRows()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridVOLager, lstSelectedRows, true);
                if (lstSelectedRows.Count > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                dsVO.VO_LagerRow rSelRow = (dsVO.VO_LagerRow)v.Row;

                                this.sqlVO1.DeleteVOLager(rSelRow.ID);
                            }

                            this.loadData(this._IDVO, this._sZustand);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucLager.delRows: " + ex.ToString());
            }
        }



        private void gridVOLager_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsVO1.VO_Lager.SeriennummerColumn.ColumnName.Trim().ToLower()) || (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsVO1.VO_Lager.ZustandColumn.ColumnName.Trim().ToLower())))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOLager_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOLager_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOLager))
                {
                    UltraGridRow rGridSel = null;
                    dsVO.VO_LagerRow rVOLager = null;
                    bool RowSelected = this.getSelectedRow(false, ref rGridSel, ref rVOLager);
                    if (RowSelected)
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOLager_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOLager))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData(this._IDVO, this._sZustand);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {

                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAddVO_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRow();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.delRows();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboZustand_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("LAZ");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("LAZ", this.cboZustand, null, this.cboZustand.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("LAZ", this.cboZustand, null);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
