using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Data.Global;

namespace PMDS.Calc.UI.Admin
{
    public partial class ucManFreiBuch : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler ValueChanged;

        private readonly PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
        private bool _manBuchungenChanged = false;
        private bool _loaded = false;
        private System.Guid _IDPatient;
        private PMDS.DB.Global.DBManBuchungen _db = new PMDS.DB.Global.DBManBuchungen();
        public PMDS.Calc.Logic.eCalcRun typ = new PMDS.Calc.Logic.eCalcRun();
        private Infragistics.Win.UltraWinGrid.UltraGridCell cellPrev;
        private int DefaultRowHeight = 30;      //Standard aus ISL wird bei Freier Buchung nicht erkannt???, deshalb Höhe für 10 Punkt-Schrift setzen

        public ucManFreiBuch()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            if (_loaded) return;

            if (typ == PMDS.Calc.Logic.eCalcRun.manBill )
            {
                btnRechnungDrucken.Visible = false;
                this.grdManBuchungen3.DisplayLayout.ValueLists[0].ValueListItems.Add((int)PMDS.Global.AbrechnungsGruppe.Grundleistung, PMDS.Global.AbrechnungsGruppe.Grundleistung.ToString ());
                this.grdManBuchungen3.DisplayLayout.ValueLists[0].ValueListItems.Add((int)PMDS.Global.AbrechnungsGruppe.PeriodischeLeistung, PMDS.Global.AbrechnungsGruppe.PeriodischeLeistung.ToString ());
                //this.grdManBuchungen3.DisplayLayout.ValueLists[0].ValueListItems.Add((int)PMDS.Global.AbrechnungsGruppe.Sonderleistung, PMDS.Global.AbrechnungsGruppe.Sonderleistung.ToString ());
            }
            else if (typ == PMDS.Calc.Logic.eCalcRun.freeBill )
            {
                btnRechnungDrucken.Visible = false;
            }

            sitemap.fillEnumBillTyp(this.grdManBuchungen3.DisplayLayout.ValueLists["eBillTyp"], false);

            this.grdManBuchungen3.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;

            this.udteVon.Value = null;
            this.udteBis.Value = null;

            _loaded = true;
        }
        
        private void ucLeistungen_Resize(object sender, EventArgs e)
        {

        }
        
        public bool Save()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.grdManBuchungen3.UpdateData();
                this.grdManBuchungen3.ActiveRow = null;

                if (this.ValidateFields())
                {
                    this.grdManBuchungen3.UpdateData();
                    this._db.Update(this.dsManBuch1);
                    _manBuchungenChanged = false;
                    this.Cursor = Cursors.Default;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex); 
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public bool IsChanged { get { return _manBuchungenChanged; } }

        public bool ValidateFields()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in this.grdManBuchungen3.Rows)
            {
                DataRowView v = (DataRowView)r.ListObject;
                dsManBuch.manBuchRow rDS = (dsManBuch.manBuchRow)v.Row;
                //PMDS.Data.Global.dsManBuch.manBuchDataTable dt = (PMDS.Data.Global.dsManBuch.manBuchDataTable)rDS.Table;
                rDS.SetColumnError(r.Cells["betrag"].Column.Index, "");
                rDS.SetColumnError(r.Cells["buchText"].Column.Index, "");
                rDS.SetColumnError(r.Cells["IDRef"].Column.Index, "");

                if ((decimal )r.Cells["betrag"].Value == 0)
                {
                    rDS.SetColumnError(r.Cells["betrag"].Column.Index, QS2.Desktop.ControlManagment.ControlManagment.getRes("Betrag darf nicht null sein!"));
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Betrag darf nicht null sein!", "Betrag", MessageBoxButtons.OK);
                    r.Selected = true;
                    return false;
                }
                if ((string)r.Cells["buchText"].Value == "")
                {
                    
                    rDS.SetColumnError(r.Cells["buchText"].Column.Index, QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungstext muß angegeben werden!"));
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungstext muß angegeben werden!", "Buchungstext", MessageBoxButtons.OK);
                    r.Selected = true;
                    r.Activate();
                    r.Activated = true;
                    return false;
                }
                if (this.typ == PMDS.Calc.Logic.eCalcRun.freeBill  && (string)r.Cells["IDRef"].Value.ToString() == "")
                {
                    
                    rDS.SetColumnError(r.Cells["IDRef"].Column.Index, QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger muß angegeben werden!"));
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger muß angegeben werden!", "Kostenträger", MessageBoxButtons.OK);
                    r.Selected = true;
                    r.Activate();
                    r.Activated = true;
                    return false;
                }
                r.Cells["brutto"].Value = (decimal)r.Cells["betrag"].Value * (((decimal)r.Cells["MwSt"].Value / 100) + 1);
            }

            return true;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                this.loadData();
            }
        }


        private void loadData()
        {
            this.Cursor = Cursors.WaitCursor;

            this.loadKostenträger();
            this.sitemap.refreshAuswahlGrp(this.cboBezeichnungstexte, "BUT");

            this.dsManBuch1.manBuch.Rows.Clear();

            this._db.allManBuchungen(this.dsManBuch1, _IDPatient, (object)udteVon.Value, (object)udteBis.Value, this.cbAbgerechnet.Checked, this.typ, " ORDER BY datum asc, am asc ", ENV.IDKlinik);
            this.grdManBuchungen3.DisplayLayout.Override.DefaultRowHeight = DefaultRowHeight;
            this.grdManBuchungen3.Refresh();
           
            _manBuchungenChanged = false;

            if (typ == PMDS.Calc.Logic.eCalcRun.manBill )
            {
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["IDRef"].Hidden = true;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["abrechGruppe"].Hidden = false;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["RechnungTyp"].Hidden = true;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["typ"].Hidden = false;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["ReNr"].Hidden = true;
            }
            else if (typ == PMDS.Calc.Logic.eCalcRun.freeBill )
            {
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["IDRef"].Hidden = false;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["abrechGruppe"].Hidden = true;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["RechnungTyp"].Hidden = true;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["typ"].Hidden = false;
                this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["ReNr"].Hidden = true;
            }

            this.grdManBuchungen3.DisplayLayout.Bands[0].Columns["typ"].Hidden = true;

            //foreach (PMDS.Data.Global.dsManBuch.manBuchRow  r  in this.dsManBuch1.manBuch)
            //{
            //    string Zeitraumdetail = (string)r.Zeitraumdetail;
            //    if (Zeitraumdetail.Substring(0, 4) == "[MB]")
            //    {
            //        r.Zeitraumdetail = Zeitraumdetail.Substring (4, Zeitraumdetail.Length - 4);
            //    }
            //}

            if (this.dsManBuch1.manBuch.Rows.Count > 0)
            {
                this.grdManBuchungen3.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Manuelle Buchungen (") + this.dsManBuch1.manBuch.Rows.Count.ToString() + ")";
                //this.grdManBuchungen2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True ;
                this.grdManBuchungen3.DisplayLayout.Rows[0].ExpandAll();
                this.grdManBuchungen3.ActiveRow = this.grdManBuchungen3.Rows[0];
            }
            else
            {
                this.grdManBuchungen3.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Manuelle Buchungen");
                //this.grdManBuchungen2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            }

            btnDel.Enabled = false;
            this.grdManBuchungen3.Selected.Rows.Clear();

            this.grdManBuchungen3.ActiveRow = null;
            _manBuchungenChanged = false;
            //this.dsManBuch1.WriteXmlSchema("C:\\dsManBuch1.xsd");
    
            this.Cursor = Cursors.Default ;
        }
        private void loadKostenträger()
        {
            this.grdManBuchungen3.DisplayLayout.ValueLists[1].ValueListItems.Clear();
            PMDS.Data.Global.dsAlleKostFürKlient dsKost = this._db.allKostFürPatient(this.IDPatient);
            foreach ( dsAlleKostFürKlient.PatientKostentraegerRow  r in dsKost.PatientKostentraeger.Rows  )
            {
                bool found = false;
                foreach (Infragistics.Win.ValueListItem itm in this.grdManBuchungen3.DisplayLayout.ValueLists[1].ValueListItems)
                    if ((System.Guid)itm.DataValue == r.IDKostenträger)
                        found = true;
                if (!found) 
                    this.grdManBuchungen3.DisplayLayout.ValueLists[1].ValueListItems.Add(r.IDKostenträger, r.Kostenträger);
            }
          }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            dsManBuch.manBuchRow r = (dsManBuch.manBuchRow)this.dsManBuch1.manBuch.NewRow();
            r.ID = System.Guid.NewGuid();
            r.IDKlinik = ENV.IDKlinik;
            r.betrag = 0;
            r.MwSt = 0;
            r.brutto = 0;
            r.datum = System.DateTime.Now.Date;
            r.Zeitraumdetail = "";
            r.SetabgerechAmNull();
            r.SetIDRefNull();
            r.am = System.DateTime.Now ;
            r.buchText = "";
            r.abgerechJN = false;
            r.IDKlient = this._IDPatient;
            r.typ = (int )this.typ;
            r.RechnungTyp = (int )PMDS.Calc.Logic.eBillTyp.Rechnung;
            r.ReNr = "";
            r.FIBUKonto = "";

            if (typ == PMDS.Calc.Logic.eCalcRun.manBill )
            {
                r.abrechGruppe = (int)PMDS.Global.AbrechnungsGruppe.Grundleistung;
                r.gruppeTxt = PMDS.Global.AbrechnungsGruppe.Grundleistung.ToString();
            }
            else if (typ == PMDS.Calc.Logic.eCalcRun.freeBill )
            {
                r.abrechGruppe  = -1;
                r.gruppeTxt = "";
                r.gruppeTxt = "";
            }

            PMDS.BusinessLogic.Benutzer ben = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
            r.erfasst =    ben.FullName ;
            this.dsManBuch1.manBuch.Rows.Add(r);

            if (ValueChanged != null)
                ValueChanged(this, null);
            _manBuchungenChanged = true;

            //this.grdManBuchungen2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rSearch in this.grdManBuchungen3.Rows)
            {
                if ((string)rSearch.Cells["ID"].Value.ToString() == r.ID.ToString())
                    this.grdManBuchungen3.ActiveRow = rSearch;
            }

            this.Cursor = Cursors.Default ;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.grdManBuchungen3.ActiveRow != null)
            {
                //if ((bool)this.grdManBuchungen3.ActiveRow.Cells["abgerechJN"].Value == true)
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchung kann nicht gelöscht werden, da bereits abgerechnet!", "Buchung löschen", MessageBoxButtons.OK);
                //    this.Cursor = Cursors.Default;
                //    return;
                //}

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die man. Buchung wirklich löschen?", "Buchung löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.grdManBuchungen3.ActiveRow.Delete(false);
                    if (ValueChanged != null)
                        ValueChanged(this, null);
                    btnDel.Enabled = false;
                    _manBuchungenChanged = true;
                    //this._db.Update(this.dsManBuch1);
                }
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Buchung ausgewählt!", "Buchung löschen", MessageBoxButtons.OK );
            }


            this.Cursor = Cursors.Default;
        }


 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PMDS.BusinessLogic.Patient   p = new PMDS.BusinessLogic.Patient(this._IDPatient );
            PMDS.Print.frmPrintPreview.PreviewManBuchungen(this.dsManBuch1, p.Vorname + " " + p.Nachname, this.typ);
        }
        private void cbAbgerechnet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAbgerechnet.Focused)
                this.loadData();
        }

        
        private void udteVon_ValueChanged(object sender, EventArgs e)
        {

        }
        private void udteVon_Leave(object sender, EventArgs e)
        {
            if (udteVon.Focused)
                this.loadData();
        }

        private void udteBis_ValueChanged(object sender, EventArgs e)
        {

        }
        private void udteBis_Leave(object sender, EventArgs e)
        {
            if (udteBis.Focused)
                this.loadData();
        }

        private void udteVon_AfterEditorButtonCloseUp(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

        }

        private void udteBis_AfterEditorButtonCloseUp(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

        }

        private void udteBis_AfterCloseUp(object sender, EventArgs e)
        {
            if (udteBis.Focused)
                this.loadData();
        }

        private void udteVon_AfterCloseUp(object sender, EventArgs e)
        {
            if (udteVon.Focused)
                this.loadData();
        }


        public void calcCells( Infragistics.Win.UltraWinGrid.UltraGridCell  cell)
        {
            try
            {
                if (cell.Column.ToString() == "abrechGruppe")
                {
                    if (cell.Value != null)
                    {
                        //if (!this.updateGridData()) return;
                        if ((int)cell.Value == (int)PMDS.Global.AbrechnungsGruppe.Grundleistung)
                            cell.Row.Cells["gruppeTxt"].Value = QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung");
                        else if ((int)cell.Value == (int)PMDS.Global.AbrechnungsGruppe.PeriodischeLeistung)
                            cell.Row.Cells["gruppeTxt"].Value = QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung");
                        else if ((int)cell.Value == (int)PMDS.Global.AbrechnungsGruppe.Sonderleistung)
                            cell.Row.Cells["gruppeTxt"].Value = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung");
                    }
                }
                if (cell.Column.ToString() == "IDRef")
                {
                    if (cell.Value != null)
                    {
                        if ( cell.Value != System.DBNull.Value   )
                        {
                            if (typ == PMDS.Calc.Logic.eCalcRun.freeBill )
                            {
                                PMDS.DB.Global.KostentraegerInfo info = new PMDS.DB.Global.KostentraegerInfo((System.Guid)cell.Value);
                                cell.Row.Cells["gruppeTxt"].Value = info.INFO.Name;
                            }
                        }
                    }
                }

                if (cell.Row.Cells["betrag"].Value == null) return ;

                    //if (!this.updateGridData()) return;
                    if (cell.Column.ToString() == "betrag" || cell.Column.ToString() == "MwSt")
                    {
                        this.grdManBuchungen3.UpdateData();
                        cell.Row.Cells["brutto"].Value = (decimal)cell.Row.Cells["betrag"].Value * (((decimal)cell.Row.Cells["MwSt"].Value / 100) + 1);
                    }
                    if (cell.Column.ToString() == "brutto")
                    {
                        //this.grdManBuchungen2.UpdateData();
                        cell.Row.Cells["betrag"].Value = (decimal)cell.Row.Cells["brutto"].Value / (((decimal)cell.Row.Cells["MwSt"].Value / 100) + 1);
                    }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
       
        }
    
        private bool  updateGridData()
        {
            try
            {
                this.grdManBuchungen3.UpdateData();
                return true;
            }
            catch
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehlerhafte Eingabe!", "Eingabe", MessageBoxButtons.OK);
                return false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void panelOben_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRechnungDrucken_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default ;
            }
        }        

        private void grdManBuchungen3_AfterRowActivate(object sender, EventArgs e)
        {
            btnDel.Enabled = true;
        }

        private void grdManBuchungen3_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "erfasst" || e.Cell.Column.ToString() == "am" || e.Cell.Column.ToString() == "abgerechAm" || e.Cell.Column.ToString() == "abgerechJN")
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            if (cellPrev != null) this.calcCells(cellPrev);
            cellPrev = e.Cell;
        }

        private void grdManBuchungen3_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if ((bool)e.Row.Cells["abgerechJN"].Value == (bool)true)
            {
                e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            //this.calcCells(e.Row)
        }

        private void grdManBuchungen2_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void grdManBuchungen3_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString() == "abrechGruppe")
                {
                    if (!this.updateGridData()) return;
                    if ((int)e.Cell.Value == (int)PMDS.Global.AbrechnungsGruppe.Grundleistung)
                        e.Cell.Row.Cells["gruppeTxt"].Value = "Grundleistung";
                    else if ((int)e.Cell.Value == (int)PMDS.Global.AbrechnungsGruppe.PeriodischeLeistung)
                        e.Cell.Row.Cells["gruppeTxt"].Value = "Periodische Leistung";
                    //else if ((int)e.Cell.Value == (int)PMDS.Global.AbrechnungsGruppe.Sonderleistung)
                    //    e.Cell.Row.Cells["gruppeTxt"].Value = "Sonderleistung";
                }
                if (e.Cell.Column.ToString() == "IDRef")
                {
                    if (e.Cell.Value != null)
                    {
                        if (typ == PMDS.Calc.Logic.eCalcRun.freeBill )
                        {
                            if (!this.updateGridData()) return;
                            if ( e.Cell.Value != System.DBNull.Value  )
                            {
                                PMDS.DB.Global.KostentraegerInfo info = new PMDS.DB.Global.KostentraegerInfo((System.Guid)e.Cell.Value);
                                e.Cell.Row.Cells["gruppeTxt"].Value = info.INFO.Name;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                if (ValueChanged != null)
                    ValueChanged(this, null);
                _manBuchungenChanged = true;
            }
        }

        private void grdManBuchungen3_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            try
            {
                if (e.DataErrorInfo.Cell.Column.ToString() == "datum")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datum: Falsche Eingabe!", "Datum", MessageBoxButtons.OK);
                    e.Cancel = true;
                }
                if (e.DataErrorInfo.Cell.Column.ToString() == "brutto" || e.DataErrorInfo.Cell.Column.ToString() == "betrag" ||
                            e.DataErrorInfo.Cell.Column.ToString() == "Mwst")
                {
                    e.DataErrorInfo.Cell.Value = 0;
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {

            }
        }

        private void cboBezeichnungstexte_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            this.sitemap.openFormAuswahlGrp(this.cboBezeichnungstexte, "BUT");
        }

        private void grdManBuchungen3_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            if (grdManBuchungen3.Focused)
                e.Cancel = true;
        }

        private void grdManBuchungen3_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           // this.grdManBuchungen3.DisplayLayout.Override.RowAppearance.FontData.SizeInPoints = 12;
           // Application.DoEvents();
        }
    }
}
