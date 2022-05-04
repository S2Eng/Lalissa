using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;
using Infragistics.Win.Misc;
using PMDS.Global;
using PMDS.UI.Sitemap;

using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI
{
    
    public partial class ucDepotgeldCalc : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.UI.Sitemap.UIFct sitemap;
        public PMDS.Calc.Logic.print print;
        public PMDS.Calc.Logic.Sql sql;
        public PMDS.Calc.Logic.doDepotgeld doDepot;
        public PMDS.Calc.Logic.calcBase calcBase;
        public DB.DBPatient dbPatient;

        public bool isLoaded = false;

        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();




        public ucDepotgeldCalc()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }
        public void initControl()
        {
            try
            {
                if (this.isLoaded) return;

                this.ucKlinikDropDown1.initControl();
                this.ucKlinikDropDown1.loadComboAllKliniken();

                this.print = new PMDS.Calc.Logic.print();
                this.sql = new PMDS.Calc.Logic.Sql();
                this.doDepot = new PMDS.Calc.Logic.doDepotgeld();
                this.sitemap = new UIFct();
                this.calcBase = new PMDS.Calc.Logic.calcBase();
                this.dbPatient = new DB.DBPatient();
                
                this.textControl1.Top = -100;
                this.textControl1.Left = -100;
                this.textControl1.Height = 80;
                this.textControl1.Width = 80;

                this.dtRechDatum.Value = DateTime.Now;
                this.dtAbrechnenBis.Value = DateTime.Now;           //this.calcBase.monatsende(DateTime.Now);

                this.loadData(false);

                PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);
                this.isLoaded = true;
                this.txtSucheKlient.Focus();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {
            this.clearData();
        }
        public void clearData()
        {
            try
            {
                this.sitemap.clearAllFiltersGrid(this.uGridAbrech);
                
                this.dsKlientenSelAbrechDepot1.Klienten.Rows.Clear();
                this.uGridAbrech.Refresh();
                this.sitemap.anz = this.dsKlientenSelAbrechDepot1.Klienten.Rows.Count;
                this.lblCount.Text = this.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Klienten gefunden!"));
                this.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, false, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech, "Auswahl", true);
               
                this.btnEinzAusz.Enabled = false;
                this.btnKostenträgerZuord.Enabled = false;
                this.uGridAbrech.Selected.Rows.Clear();
                this.uGridAbrech.ActiveRow = null;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void loadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                this.loadData((string)this.uOptSetKlienten.Value == "P" ? false : true);
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        public void loadData(bool entlassene)
        {
            try
            {
                this.sitemap.clearAllFiltersGrid(this.uGridAbrech);
                this.search(this.txtSucheKlient.Text.Trim());
                Cursor = Cursors.WaitCursor;
                this.dsKlientenSelAbrechDepot1.Klienten.Rows.Clear();
                dsPatientStation.PatientDataTable t = PMDS.GUI.GuiUtil.GetKlientenforCurrentSelectionAbrech(entlassene, PMDS.Global.ENV.IDKlinik); 
                dsPatientStation.PatientRow[] rows = (dsPatientStation.PatientRow[])t.Select("", "Name asc ");

                if (!entlassene)
                {
                    this.BackColor = System.Drawing.Color.WhiteSmoke;
                     this.uOptSetKlienten.Appearance.ForeColor = System.Drawing.Color.Black;
                    this.lblHistorie.Visible = false;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.DarkGray;
                    this.uOptSetKlienten.Appearance.ForeColor = System.Drawing.Color.White;
                    this.lblHistorie.Visible = true;
                }
                Application.DoEvents();

                foreach (dsPatientStation.PatientRow r in rows)
                {
                    if (r.IDKlinik.Equals(ENV.IDKlinik))
                    {
                        dsKlientenSelAbrechDepot.KlientenRow[] rCheck = (dsKlientenSelAbrechDepot.KlientenRow[])this.dsKlientenSelAbrechDepot1.Klienten.Select("ID='" + r.ID.ToString() + "'", "");
                        if (rCheck.Length == 0)
                        {
                            dsPatientZusaätzlicheDatenByID.PatientRow rZusatz = this.dbPatient.getPatDatenZusätzlich(r.ID);
                            dsKlientenSelAbrechDepot.KlientenRow rNew = (dsKlientenSelAbrechDepot.KlientenRow)this.dsKlientenSelAbrechDepot1.Klienten.NewRow();
                            rNew.ID = r.ID;
                            rNew.Auswahl = false;
                            rNew.Name = r.Name;

                            rNew.Sollstand = rZusatz.Sollstand;
                            rNew.MinSaldo = rZusatz.minSaldo;
                            rNew.AlterSaldo = this.doDepot.readDepotgeldSum(rNew.ID.ToString(), PMDS.Calc.Logic.eZahlEA.Einzahlung, this.dtAbrechnenBis.DateTime, true, PMDS.Global.ENV.IDKlinik) - this.doDepot.readDepotgeldSum(rNew.ID.ToString(), PMDS.Calc.Logic.eZahlEA.Auszahlung, this.dtAbrechnenBis.DateTime, true, PMDS.Global.ENV.IDKlinik);
                            rNew.NeuerSaldo = rNew.AlterSaldo + (this.doDepot.readDepotgeldSum(rNew.ID.ToString(), PMDS.Calc.Logic.eZahlEA.Einzahlung, this.dtAbrechnenBis.DateTime, false, PMDS.Global.ENV.IDKlinik) - this.doDepot.readDepotgeldSum(rNew.ID.ToString(), PMDS.Calc.Logic.eZahlEA.Auszahlung, this.dtAbrechnenBis.DateTime, false, PMDS.Global.ENV.IDKlinik));
                            rNew.Zahlungsbetrag = rNew.NeuerSaldo < rNew.Sollstand ? rNew.Sollstand - rNew.NeuerSaldo: 0;

                            if (rNew.NeuerSaldo < rNew.MinSaldo)
                            {
                                rNew.WarnungMinStand = true;
                            }
                            else
                                rNew.WarnungMinStand = false;
                                                       
                            if (r.IsIDKlinikNull())
                            {
                                throw new Exception("ucDepotgeldCalc.loadData: r.IsIDKlinikNull() for IDPatient '" + r.ID.ToString() + "'!");
                            }
                            if (r.IDKlinik != ENV.IDKlinik)
                            {
                                throw new Exception("ucDepotgeldCalc.loadData: r.IDKlinik != ENV.IDKlinik for IDPatient '" + r.ID.ToString() + "'!");
                            }
                            rNew.IDKlinik = r.IDKlinik;

                            this.dsKlientenSelAbrechDepot1.Klienten.Rows.Add(rNew);
                        }
                    }
                }
                this.uGridAbrech.Refresh();
                this.sitemap.anz = this.dsKlientenSelAbrechDepot1.Klienten.Rows.Count;
                this.lblCount.Text = this.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Klienten gefunden!"));
                this.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, false, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech, "Auswahl", true);
                this.uGridAbrech.DisplayLayout.Bands[0].Columns[this.dsKlientenSelAbrechDepot1.Klienten.NeuerSaldoColumn.ColumnName].Header.Caption = "NeuerSaldo per " + this.dtAbrechnenBis.DateTime.ToString("dd.MM.yyyy");

                this.btnEinzAusz.Enabled = false;
                this.btnKostenträgerZuord.Enabled = false;
                this.uGridAbrech.Selected.Rows.Clear();
                this.uGridAbrech.ActiveRow = null;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public System.Collections.ArrayList  IDKlienten()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (dsKlientenSelAbrechDepot.KlientenRow  r in this.dsKlientenSelAbrechDepot1.Klienten)
                if (r.Auswahl)
                    list.Add(r.ID.ToString());

            return list;
        }
  
        public void search(string txt )
        {
            try
            {
                if (txt == "")
                    this.sitemap.clearAllFiltersGrid(this.uGridAbrech);
                else
                {
                    List<string> filter = new List<string>();
                    filter.Add(txt);
                    this.sitemap.setFilterGrid(filter, this.uGridAbrech, "Name", FilterLogicalOperator.Or, FilterComparisionOperator.Custom);
                }

            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }       

        private void butAbrechnen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.sitemap.checkUIDateAbrech(this.dtAbrechnenBis,  this.dtRechDatum)) return;
                if (!this.sitemap.validAuswahl(true, this.klienten())) return;
                this.sitemap.listID = this.IDKlienten();

                PMDS.Global.frmProtokoll frmProtokoll = new PMDS.Global.frmProtokoll();
                frmProtokoll.initControl(this.dtAbrechnenBis.DateTime, this.dtAbrechnenBis.DateTime,
                         this.dtRechDatum.DateTime, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech, (Infragistics.Win.Misc.UltraButton)this.butAlleKeine,
                         ref this.lblCount, PMDS.Calc.Logic.eCalcRun.all, this.textControl1, null, "D", ref  this.sitemap.listID);
                frmProtokoll.ShowDialog(this);
                this.loadData();
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
       
        public System.Collections.ArrayList klienten()
        {
            System.Collections.ArrayList ret = new System.Collections.ArrayList();
            foreach (dsKlientenSelAbrechDepot.KlientenRow r in this.dsKlientenSelAbrechDepot1.Klienten)
            {
                if (r.Auswahl) ret.Add(r.ID.ToString());
            }
            return ret;
        }
        private void butAlleKeine_Click(object sender, EventArgs e)
        {
            this.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, !(bool)this.butAlleKeine.Tag, (UltraGrid)this.uGridAbrech, "Auswahl", true);
        }

        private void uOptSetKlienten_ValueChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void uGridAbrech_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "Auswahl")
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            this.btnEinzAusz.Enabled = true;
            this.btnKostenträgerZuord.Enabled = true;
        }

        private void txtSucheKlient_Enter(object sender, EventArgs e)
        {
            this.txtSucheKlient.SelectAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                this.loadData();
        }

        private void dtAbrechnenBis_Leave(object sender, EventArgs e)
        {
            if (this.dtAbrechnenBis.Focused)
            {
                if (dtAbrechnenBis.Value == null) dtAbrechnenBis.DateTime = DateTime.Now;
                this.loadData();
            }
        }

        private void dtRechDatum_Leave(object sender, EventArgs e)
        {
            if (this.dtRechDatum.Focused)
            {
                if (dtRechDatum.Value == null) dtRechDatum.DateTime = DateTime.Now;
            }
        }

        private void txtSucheKlient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void dtAbrechnenBis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void btnEinzAusz_Click(object sender, EventArgs e)
        {
            this.openEinAusz(true);
        }

        public  void openEinAusz(bool withMsg)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.selected(true))
                {
                    PMDS.Calc.UI.Admin.frmDepotgeldKlient frmDepot = new PMDS.Calc.UI.Admin.frmDepotgeldKlient();
                    frmDepot.initControl();
                    frmDepot.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeld für ") + (string)this.uGridAbrech.ActiveRow.Cells["Name"].Value;
                    frmDepot.ucDepotgeldKlient1.IDPatient = (System.Guid)this.uGridAbrech.ActiveRow.Cells["ID"].Value;
                    frmDepot.ShowDialog();
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
        public bool selected(bool withMsg)
        {
            string txt1 = "Es wurde kein Klient ausgewählt!";
            string txt2 = "Depotgeld";

            if (this.uGridAbrech.ActiveRow == null)
            {
                if (withMsg) QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt1, txt2, MessageBoxButtons.OK);
                return false;
            }
            if (this.uGridAbrech.ActiveRow.IsGroupByRow) return false;
            if (this.uGridAbrech.ActiveRow.Cells["ID"].Value != System.DBNull.Value)
            {
                return true;
            }
            else
            {
                if (withMsg) QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt1, txt2, MessageBoxButtons.OK);
                return false;
            }
         }
        private void btnKostenträgerZuord_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.selected(true))
                {
                    PMDS.Klient.frmDepotgeldKost frm = new PMDS.Klient.frmDepotgeldKost();
                    frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeld - Kostenträgerzuordnung für ") + (string)this.uGridAbrech.ActiveRow.Cells["Name"].Value;
                    frm.initControl();
                    frm.ucTaschengeldKostentraeger1.IDKlient = (System.Guid)this.uGridAbrech.ActiveRow.Cells["ID"].Value;
                    frm.ucTaschengeldKostentraeger1.loadData();

                    frm.ShowDialog();
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.export.exportGrid(this.uGridAbrech, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");
        }

        private void uGridAbrech_BeforeRowRegionScroll(object sender, BeforeRowRegionScrollEventArgs e)
        {
            this.sitemap.evBeforeRowRegionScrollAuto(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech);
        }
        private void uGridAbrech_DoubleClick(object sender, EventArgs e)
        {
            if (this.sitemap.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech))
                this.openEinAusz(false);
        }

        private void ucKlinikDropDown1_Load(object sender, EventArgs e)
        {

        }
    }
}
