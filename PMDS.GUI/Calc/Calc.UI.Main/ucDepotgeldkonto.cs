using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinEditors;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.Print;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.DB.Patient;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global;




namespace PMDS.GUI
{


    public partial class ucDepotgeldkonto : QS2.Desktop.ControlManagment.BaseControl
    {

        private Depotgeldkonto _depotgeldkonto;
        private dsPatientZusaätzlicheDatenByID.PatientRow rZusätz;
        public System.Guid IDKlient;


        public PMDS.UI.Sitemap.UIFct sitemap;
        public event EventHandler ValueChanged;
        private Patient pat = new Patient();
        private bool abgerechEdit = false;

        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
        private PMDS.Calc.Logic.doDepotgeld doDepot;





        public ucDepotgeldkonto()
        {
            InitializeComponent();
            initControl();
        }
        public void  initControl()
        {
            if (DesignMode)
                return;

            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();

            this.doDepot = new PMDS.Calc.Logic.doDepotgeld();
            this.sitemap = new PMDS.UI.Sitemap.UIFct();
            _depotgeldkonto = new Depotgeldkonto();
            gridTaschengeld.DataSource = _depotgeldkonto.TASCHENGELD;
            dtpVon1.DateTime  = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpBis1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            InitTimeContextMenu();
            
        }
        private void InitTimeContextMenu()
        {
            this.sitemap.initTimeContextMenu();
            foreach (MenuItem item in this.sitemap.timemenu.MenuItems)
            {
                item.Click += new EventHandler(Timeitem_Click);
            }
        }
        

        
        public void  loadData()
        {
            this.abgerechEdit = false;
            this.checkVonBis();
            this._depotgeldkonto.Read(this.IDKlient, dtpVon1.DateTime, dtpBis1.DateTime, ENV.IDKlinik);
            this.gridTaschengeld.Refresh();

            this.rZusätz = this.pat.getPatDatenZusätzlich(this.IDKlient);
            this.tbTaschengeldSollstand.Value = this.rZusätz.Sollstand;
            this.tbTaschengeldMinSaldo.Value = this.rZusätz.minSaldo;
            this.gridTaschengeld.DisplayLayout.Bands[0].Columns["Datum"].SortIndicator = SortIndicator.Descending ;

            this.sitemap.anz = _depotgeldkonto.TASCHENGELD.Taschengeld.Rows.Count;
            lblCount.Text = this.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Einträge gefunden!"));
            
            this.gridTaschengeld.Selected.Rows.Clear();
            if (gridTaschengeld.Rows.Count > 0)
            {
                this.gridTaschengeld.DisplayLayout.Rows[0].ExpandAll();
                this.gridTaschengeld.ActiveRow = gridTaschengeld.Rows[0];
            }
            this.gridTaschengeld.ActiveRow = null;

            this.RefreshList(this.cboGrund, "GRD");
            this.RefreshList(this.cboLieferant, "LFT");

            double  sumSoll = 0;
            double sumHaben = 0;

            foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(this.gridTaschengeld, false))
            {
                dsTaschengeld.TaschengeldRow rowData = (PMDS.Global.db.Global.ds_abrechnung.dsTaschengeld.TaschengeldRow)((System.Data.DataRowView)r.ListObject).Row;
                if(!rowData.IsEinzahlungNull()) sumSoll += rowData.Einzahlung;
                if (!rowData.IsAuszahlungNull()) sumHaben += rowData.Auszahlung;
            }

            //double saldo = sumSoll - sumHaben;
            //this.lblSaldo.Text = "Saldo: " + saldo.ToString("###,###,##0.00") + " €";
            this.readGesamtsaldo();
        }

        public void checkVonBis()
        {
            if (dtpVon1.DateTime == null)     
                dtpVon1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            else
                dtpVon1.DateTime = new DateTime(dtpVon1.DateTime.Year, dtpVon1.DateTime.Month, dtpVon1.DateTime.Day, 0, 0, 0);

            if (dtpBis1.DateTime == null)             
                dtpBis1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),23,59,59);
            else
                dtpBis1.DateTime = new DateTime(dtpBis1.DateTime.Year, dtpBis1.DateTime.Month, dtpBis1.DateTime.Day, 23, 59, 59);
        }

        public void readGesamtsaldo()
        {
            DateTime datBis = new DateTime(2999, 12, 31);
            Decimal  sum = 0;
            sum = this.doDepot.readDepotgeldSum(this.IDKlient.ToString(), PMDS.Calc.Logic.eZahlEA.Einzahlung, datBis, true, PMDS.Global.ENV.IDKlinik) - this.doDepot.readDepotgeldSum(this.IDKlient.ToString(), PMDS.Calc.Logic.eZahlEA.Auszahlung, datBis, true, PMDS.Global.ENV.IDKlinik);
            sum += (this.doDepot.readDepotgeldSum(this.IDKlient.ToString(), PMDS.Calc.Logic.eZahlEA.Einzahlung, datBis, false, PMDS.Global.ENV.IDKlinik) - this.doDepot.readDepotgeldSum(this.IDKlient.ToString(), PMDS.Calc.Logic.eZahlEA.Auszahlung, datBis, false, PMDS.Global.ENV.IDKlinik));
            this.lblSaldo.Tag = sum;
            this.lblSaldo.Text = "Gesamtsaldo: " + sum.ToString("###,###,##0.00") + " €";
        }
        public bool ReadOnly
        {
            get { return false ; }
            set
            {
            }
        }

        public void setControlsAktivDisablexy(bool bOn)
        {
            //PMDS.GUI.BaseControls.historie.OnOffControls(this.pnlErfassungSaldo , bOn);
            //panelButtonsPlusMinus.Visible = !bOn;
            //if (bOn) 
            //    this.gridTaschengeld.DisplayLayout.Override.AllowAddNew = AllowAddNew.No  ;
            //else
            //    this.gridTaschengeld.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnTopWithTabRepeat;

        }
        private void RefreshList(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, string Group)
        {
            try
            {
                //lst.ValueListItems.Clear();
                //foreach (dsAuswahlGruppe.AuswahlListeRow r in new AuswahlGruppe(Group).AuswahlListe)
                //    lst.ValueListItems.Add(r.Bezeichnung.Trim(), r.Bezeichnung.Trim());

                cbo.Items.Clear();
                foreach (dsAuswahlGruppe.AuswahlListeRow r in new AuswahlGruppe(Group).AuswahlListe)
                    cbo.Items.Add(r.Bezeichnung.Trim(), r.Bezeichnung.Trim());

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        public dsTaschengeld.TaschengeldRow CurrentTaschengeldRow
        {
            get
            {
                return (dsTaschengeld.TaschengeldRow)UltraGridTools.CurrentSelectedRow(gridTaschengeld);
            }
        }
  
        public bool ValidateFields()
        {
            bool err = false;
            foreach (UltraGridRow r in gridTaschengeld.Rows)
            {
                if (r.IsFilteredOut) continue;
                err = !ValidateDataRowCells(r);
                if (err) break;
            }

            return !err;
        }

        public void Write()
        {
            if (!ValidateFields()) return;
            this.gridTaschengeld.UpdateData();
            _depotgeldkonto.Write();

            if (this.tbTaschengeldSollstand.Value == System.DBNull.Value) this.tbTaschengeldSollstand.Value = 0;
            if (this.tbTaschengeldMinSaldo.Value == System.DBNull.Value) this.tbTaschengeldMinSaldo.Value = 0;
            this.pat.updatePatient(this.IDKlient,  System.Convert.ToDecimal ( this.tbTaschengeldSollstand.Value), 
                                System.Convert.ToDecimal (this.tbTaschengeldMinSaldo.Value));

            this.readGesamtsaldo();
        }
        private UltraGridRow GetUltraGridRow(Guid id)
        {
            foreach (UltraGridRow r in gridTaschengeld.Rows)
            {
                if((Guid)r.Cells["ID"].Value == id)
                    return r;
            }
            return null;
        }
        private void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            PMDS.Global.timehelper h = (PMDS.Global.timehelper)item.Tag;
            this.dtpVon1.DateTime = h._from;
            this.dtpBis1.DateTime = h._to;
            this.loadData();
        }
        private bool NewTaschengeld()
        {
            try
            {
                dsTaschengeld.TaschengeldRow r = _depotgeldkonto.New(this.IDKlient, DateTime.Now,ENV.IDKlinik);
                UltraGridRow row = GetUltraGridRow(r.ID);
                row.Selected = true;
                r.IDKlinik = ENV.IDKlinik;

                //row.Cells["Bemerkung"].Value = "";

                row.Cells["ID"].Value = Guid.NewGuid();
                row.Cells["IDPatient"].Value = this.IDKlient;
                row.Cells["IDBenutzerdurchgefuehrt"].Value = ENV.USERID;
                row.Cells["Datum"].Value = DateTime.Now;
                row.Cells["Bemerkung"].Value = "";
                row.Cells["AbgerechnetJN"].Value = false;

                gridTaschengeld.ActiveRow = row;
                gridTaschengeld.ActiveCell = row.Cells["Datum"];

                return true;
            }
            catch(Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        private bool DeleteTaschengeld()
        {
            dsTaschengeld.TaschengeldRow row = CurrentTaschengeldRow;
            if (row == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!", "Eintrag löschen", MessageBoxButtons.OK);
                return false ;
            }

            DialogResult res;
            res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    row.Delete();
                    return true;
                }
            }
            return false;
        }

        private bool ValidateDataRowCells(UltraGridRow row)
        {
            if (row == null || row.ListObject == null)
                return true;

            bool error = false;

            if ((bool)row.Cells["AbgerechnetJN"].Value && !this.abgerechEdit) return !error;

            DataRow r = ((DataRowView)row.ListObject).Row;

            if (r.RowState == DataRowState.Unchanged) return !error;

            r.SetColumnError(r.Table.Columns["Datum"], "");
            r.SetColumnError(r.Table.Columns["Grund"], "");
            r.SetColumnError(r.Table.Columns["Einzahlung"], "");
            r.SetColumnError(r.Table.Columns["Auszahlung"], "");

            string sError = "";
            
            if (row.Cells["Datum"].Value == DBNull.Value)
            {
                error = true;
                sError = "Das Datum darf nicht leer sein.";
            }
            else
            {
                DateTime datum = Convert.ToDateTime(row.Cells["Datum"].Value);
                DateTime from = new DateTime(1900, 1, 1);
                DateTime to = new DateTime(1900, 1, 1);
                to = new DateTime(to.Year, to.Month, DateTime.DaysInMonth(to.Year, to.Month), 23, 59, 59);
            }

            if (error)
            {
                r.SetColumnError(r.Table.Columns["Datum"], sError);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
            }
            
            //Grund
            if (!error && row.Cells["Grund"].Value == DBNull.Value)
            {
                error = true;
                sError = "Grund eingeben.";
                r.SetColumnError(r.Table.Columns["Grund"], sError);
                r.SetColumnError(r.Table.Columns["Grund"], sError);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
            }
            //Einzahlung und Auszahlung prüfen
            if (!error && (row.Cells["Einzahlung"].Value == DBNull.Value && row.Cells["Auszahlung"].Value == DBNull.Value ||
                row.Cells["Einzahlung"].Value != DBNull.Value && row.Cells["Auszahlung"].Value != DBNull.Value
                ))
            {
                error = true;
                sError = "Einzahlung oder Auszahlung eingeben.";
                r.SetColumnError(r.Table.Columns["Einzahlung"], sError);
                r.SetColumnError(r.Table.Columns["Auszahlung"], sError);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
            }

            return !error;
        }

        private void Preview()
        {
            try
            {
                DateTime from = new DateTime(dtpVon1.DateTime.Year, dtpVon1.DateTime.Month, dtpVon1.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(dtpBis1.DateTime.Year, dtpBis1.DateTime.Month, dtpBis1.DateTime.Day, 23, 59, 59);
                dsPrintTaschengeld ds = _depotgeldkonto.GetPrintableDataset(this.IDKlient, from, to, ENV.IDKlinik);
                PMDS.Print.frmPrintPreview.PreviewTaschengeld(ds, (decimal)this.lblSaldo.Tag);
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }
        private void PreviewBeleg(System.Guid IDKlinik)
        {
            if (gridTaschengeld.ActiveRow == null || gridTaschengeld.ActiveRow.ListObject == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!", "Beleg drucken", MessageBoxButtons.OK);
                return;
            }
            dsTaschengeld.TaschengeldRow r = (dsTaschengeld.TaschengeldRow)((DataRowView)gridTaschengeld.ActiveRow.ListObject).Row;
            PMDS.Calc.Logic.doDepotgeld doDepot = new  PMDS.Calc.Logic.doDepotgeld ();
            
            decimal betrag = 0;
            PMDS.Calc.Logic.eZahlEA typZahl = new PMDS.Calc.Logic.eZahlEA();
            if (!r.IsAuszahlungNull())
            {
                betrag = System.Convert.ToDecimal(r.Auszahlung);
                typZahl = PMDS.Calc.Logic.eZahlEA.Auszahlung;
            }
            else if (!r.IsEinzahlungNull())
            {
                betrag = System.Convert.ToDecimal(r.Einzahlung);
                typZahl = PMDS.Calc.Logic.eZahlEA.Einzahlung;
            }

            doDepot.printEinzelbeleg(this.IDKlient.ToString(), betrag, r.Datum.Date , typZahl, IDKlinik );
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NewTaschengeld() && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DeleteTaschengeld() && ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
        }

        private void gridTaschengeld_AfterRowActivate(object sender, EventArgs e)
        {
        }

        private void gridTaschengeld_CellChange(object sender, CellEventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void gridTaschengeld_AfterRowUpdate(object sender, RowEventArgs e)
        {

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
             this.Cursor = Cursors.WaitCursor;
             this.loadData();
            this.Cursor = Cursors.Default;
        }

        private void gridTaschengeld_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
   
        }

        private void gridTaschengeld_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "AbgerechnetJN" && !this.abgerechEdit)
            {
                e.Cell.Activation = Activation.NoEdit;
            }
            if (e.Cell.Column.ToString() == "IDKlinik")
            {
                e.Cell.Activation = Activation.NoEdit;
            } 
        }

        private void tbTaschengeldSollstand_ValueChanged(object sender, EventArgs e)
        {
            if (tbTaschengeldSollstand.Focused || this.tbTaschengeldMinSaldo .Focused )
            {
                if (ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void abgerechneteBelegeEditierbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PMDS.Calc.Logic.print print  = new PMDS.Calc.Logic.print();
            if (print.checkPwd()) this.abgerechEdit = true;
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Preview();
            this.Cursor = Cursors.Default;
        }

        private void btnPrintBeleg2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PreviewBeleg(ENV.IDKlinik);
            this.Cursor = Cursors.Default;
        }

        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            this.sitemap.timemenu.Show(this, new Point(this.grpSuche.Left + btnTimes.Left, this.grpSuche.Top + btnTimes.Top + btnTimes.Height));
        }

        private void dtpVon1_Enter(object sender, EventArgs e)
        {
            dtpVon1.SelectAll();
        }

        private void dtpBis1_Enter(object sender, EventArgs e)
        {
            dtpBis1.SelectAll();
        }

        private void gridTaschengeld_BeforeRowActivate(object sender, RowEventArgs e)
        {
            if ((bool)e.Row.Cells["AbgerechnetJN"].Value == true && !this.abgerechEdit )
                e.Row.Activation = Activation.NoEdit;
            else
                e.Row.Activation = Activation.AllowEdit;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.export.exportGrid(this.gridTaschengeld, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");
        }


        private void stammdatGrund()
        {
            frmAuswahl frm = new frmAuswahl("GRD");
            frm.ShowDialog();
            RefreshList( this.cboGrund,  "GRD");
        }
        private void stammdatLieferant()
        {
            frmAuswahl frm = new frmAuswahl("LFT");
            frm.ShowDialog();
            RefreshList(this.cboLieferant , "LFT");
        }


        private void cboGrund_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            this.stammdatGrund();
        }
        private void cboLieferant_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            this.stammdatLieferant();
        }

        private void gridTaschengeld_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (gridTaschengeld.Focused)
                e.Cancel = true;
        }

       
   }
 
}
