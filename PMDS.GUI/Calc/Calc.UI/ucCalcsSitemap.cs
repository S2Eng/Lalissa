using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;
using Infragistics.Win.Misc;
using PMDS.Global;
using PMDS.UI .Sitemap ;
using PMDS.Global.db.Patient;
using PMDS.Calc.Logic;
using System.Linq;
using PMDS.DB;
using S2Extensions;
using Infragistics.Documents.Excel;
using System.Collections;
using System.Globalization;

namespace PMDS.Calc.UI
{
    public class ucCalcsSitemap : QS2.Desktop.ControlManagment.BaseControl
    {
        public PMDS.UI.Sitemap.UIFct sitemap;
        public PMDS.Calc.UI.ucCalcs form;
        public PMDS.Calc.Logic.calculation calculation;
        public PMDS.Calc.Logic.doBill doBill;
        public PMDS.Calc.Logic.doRollung doRollung;

        public bool _freigeben;

        public PMDS.Calc.Logic.print print;

        public PMDS.Calc.Logic.Sql sql;
        public PMDS.Calc.Logic.doSr doSr;
        public PMDS.Calc.Logic.doDepotgeld doDepot;
        
        public string  IDKost = "";
        public bool isLoaded;
        public QS2.Desktop.Txteditor.doEditor doEditor;
        public PMDS.Calc.Logic.calcBase calcBase;
        public PMDS.Calc.Logic.dbBill dbBill;
        public PMDS.Calc.Logic.booking booking;

        public eTyp typ = new eTyp();
        public enum eTyp
        {
            calc = 0,
            sr = 1 ,
            depotgeld = 2,
            buchhaltung = 20
        }

        public void initControl(PMDS.Calc.UI.ucCalcs cont, bool doDeleg, eTyp typ, bool initEnv)
        {
            try
            {
                if (this.isLoaded) return;

                this.typ = typ;
                
                this.calcBase = new PMDS.Calc.Logic.calcBase();
                this.dbBill = new PMDS.Calc.Logic.dbBill();
                this.doEditor = new QS2.Desktop.Txteditor.doEditor();
                this.form = cont;
                this.sql = new PMDS.Calc.Logic.Sql();
                this.doSr = new PMDS.Calc.Logic.doSr();
                this.doDepot = new PMDS.Calc.Logic.doDepotgeld();
                this.booking = new PMDS.Calc.Logic.booking();
                this.doRollung = new PMDS.Calc.Logic.doRollung();
                
                this.sitemap = new UIFct();
                if (this.typ == eTyp.depotgeld  )
                    this.form.panelHistorie2.Visible = false;

                this.calculation = new PMDS.Calc.Logic.calculation();
                this.doBill = new doBill();

                if (initEnv)
                {
                    List<string> RechErwAbwesenheitListe = new List<string>();
                    if (PMDS.Global.ENV.RechErwAbwesenheit == 2 || PMDS.Global.ENV.RechErwAbwesenheit == 3)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            RechErwAbwesenheitListe = (from a in db.AuswahlListe
                                                       where a.IDAuswahlListeGruppe.Equals("KEA")
                                                       select a.Bezeichnung).ToList();
                        }
                    }

                    this.calculation.Init(RBU.DataBase.CONNECTION, PMDS.Global.ENV.KuerzungGrundleistungLetzterTag,
                                PMDS.Global.ENV.ReportPath,
                                PMDS.Global.ENV.bookingJN,
                                PMDS.Global.ENV.RechnungKopfzeileEin,
                                PMDS.Global.ENV.RechFloskel,
                                PMDS.Global.ENV.ZAHLUNG_TAGE,
                                this.sitemap.usr.FullName,
                                ENV.USERID.ToString(),
                                PMDS.Global.ENV.GSBGTxt,
                                PMDS.Global.ENV.TransferTxt,
                                PMDS.Global.ENV.DepotgeldKontoTxt,
                                PMDS.Global.ENV.typRechNr,
                                PMDS.Global.ENV.pathConfig,
                                PMDS.Global.ENV.TageOhneKuerzungGrundleistung,
                                PMDS.Global.ENV.KuerzungGrundleistungLetzterTag,
                                PMDS.Global.ENV.RechErwAbwesenheit,
                                RechErwAbwesenheitListe,
                                PMDS.Global.ENV.SrErwAbwesenheit,
                                PMDS.Global.ENV.ZahlKondBankeinzug, PMDS.Global.ENV.ZahlKondErlagschein,
                                PMDS.Global.ENV.ZahlKondÜberweisung, PMDS.Global.ENV.ZahlKondBar, ENV.ZahlKondFSW, ENV.AbwesenheitenAnzeigen, 
                                ENV.RechTitelDepotGeld,
                                ENV.RechnungBankdaten);
                }

                this.print = new PMDS.Calc.Logic.print();

                PMDS.Calc.Logic.bill bill = new PMDS.Calc.Logic.bill();
                cont.uiSiteMapForm = this;
                if (doDeleg) PMDS.Global.ENV.selKlienten += new PMDS.Global.selKlientenDelegate(this.setFilterKlienten);
                cont.initControl();
                ENV.evklinikChanged += new klinikChanged(this.klinikChanged);

                this.isLoaded = true;
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
            this.clearCalcs();
        }

        public void clearCalcs()
        {
            try
            {
                this.form.dbPMDS1.Clear();
                this.form.uGridAbrech2.Refresh();

                this.setUI((UltraGrid)this.form.uGridAbrech2);
                //this.gridToStorno(status == PMDS.Calc.Logic.eBillStatus.storniert, ref  this.form.dbPMDS1, ref this.form.uGridAbrech2);
                this.form.uGridAbrech2.Selected.Rows.Clear();
                this.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.form.butAlleKeine, false, (UltraGrid)this.form.uGridAbrech2, "", false);
                this.sitemap.anz = this.form.dbPMDS1.bills.Rows.Count;
                this.form.lblCount.Text = this.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Rechnungen gefunden!"));
                
                this.form.uGridAbrech2.ActiveRow = null;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void loadCalcs(ref PMDS.Calc.Logic.dbPMDS db, DateTime von, DateTime bis, Nullable<DateTime> vonRechDatum, Nullable<DateTime> bisRechDatum,
                                UltraGrid grid, UltraButton butAlleKeine,
                                ref QS2.Desktop.ControlManagment.BaseLabel lblCount, PMDS.Calc.Logic.eBillTyp rechTyp, 
                                PMDS.Calc.Logic.eBillStatus status, bool showStornierte, bool showExportierte,
                                PMDS.Calc.Logic.eBillStatus BillStatusFreigegeben,
                                string RechNr, PMDS.Calc.Logic.CalcUIMode ActUIMode)
        { 
            try
            {
                db.Clear();
                int iOffene = 0;
                int iFreigegebene = 0;

                if (this.typ == eTyp.calc)
                {
                    this.calculation.Load(ref this.sitemap.listID, von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, false, ENV.IDKlinik, showStornierte, showExportierte, RechNr, ref iOffene, ref iFreigegebene, ActUIMode);
                    this.showAnzButtonsCalc(ref db, von, bis, vonRechDatum, bisRechDatum, grid, butAlleKeine, ref lblCount, rechTyp, status, showStornierte, showExportierte, BillStatusFreigegeben);
                    this.form.btnVorschau.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorschau") + "" + " (" + iOffene.ToString() + ")";
                    this.form.btnFreigeben.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Freigegeben") + "" + " (" + iFreigegebene.ToString() + ")";
                }
                else if (this.typ == eTyp.depotgeld)
                {
                    this.calculation.Load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, true, ENV.IDKlinik, showStornierte, showExportierte, RechNr);
                }
                else if (this.typ == eTyp.sr)
                {
                    this.calculation.Load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, false, ENV.IDKlinik, showStornierte, showExportierte, RechNr);
                    this.showAnzButtonsCalc(ref db, von, bis, vonRechDatum, bisRechDatum, grid, butAlleKeine, ref lblCount, rechTyp, status, showStornierte, showExportierte, BillStatusFreigegeben);
                }
                else if (this.typ == eTyp.buchhaltung)
                {
                    this.calculation.Load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, true, ENV.IDKlinik, showStornierte, showExportierte, RechNr);
                }
                    
                grid.Refresh();

                //Spalte Rechnungsempfänger im Grid füllen
                using (PMDS.db.Entities.ERModellPMDSEntities dbKost = PMDSBusiness.getDBContext())
                {
                    foreach (dbPMDS.billsRow bill in db.bills.OrderBy(b => b.RechNr))
                    {
                        Guid IDKost = new Guid(bill.IDKost);
                        var rKost = (from k in dbKost.Kostentraeger
                                        join ksub in dbKost.Kostentraeger on k.ID equals ksub.IDKostentraegerSub into ks
                                        from ksub in ks.DefaultIfEmpty()
                                        where k.ID == IDKost
                                        select new
                                        {
                                            IDKlinik = k.ID,
                                            IDKostentragerSub = k.IDKostentraegerSub,
                                            Rechnungsempfaenger = k.Rechnungsempfaenger.Trim()
                                        }).FirstOrDefault();

                        UltraGridBand band = grid.DisplayLayout.Bands[0];
                        foreach (UltraGridRow row in band.GetRowEnumerator(GridRowType.DataRow))
                        {
                            if (row.Cells["IDKost"].Value.sEquals(IDKost))
                            {
                                if (rKost != null)
                                {
                                    row.Cells["Re-Empfänger"].Value = rKost.Rechnungsempfaenger;
                                }
                            }
                        }
                    }
                }

                this.setUI(grid);
                this.gridToStorno(status == PMDS.Calc.Logic.eBillStatus.storniert || showStornierte, ref db, ref grid );
                grid.Selected.Rows.Clear();
                this.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)butAlleKeine, false, (UltraGrid)grid, "", false);
                this.sitemap.anz = db.bills.Rows.Count;
                lblCount.Text = this.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Rechnungen gefunden!"));
                if (grid.Rows.Count > 0) 
                { 
                    grid.DisplayLayout.Rows[0].ExpandAll();
                    grid.ActiveRow = grid.Rows[0];
                }
                grid.ActiveRow = null;
                    
                    
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        public void showAnzButtonsCalc(ref PMDS.Calc.Logic.dbPMDS db, DateTime von, DateTime bis, Nullable<DateTime> vonRechDatum, Nullable<DateTime> bisRechDatum,
                                        UltraGrid grid, UltraButton butAlleKeine,
                                        ref QS2.Desktop.ControlManagment.BaseLabel lblCount, PMDS.Calc.Logic.eBillTyp rechTyp,
                                        PMDS.Calc.Logic.eBillStatus status, bool showFreigegebenAndStorniert, bool showExportierte,
                                        PMDS.Calc.Logic.eBillStatus BillStatusFreigegeben)
        {
            try
            {
                UltraButton btnOffene = null;
                UltraButton btnFreigegebene = null;

                PMDS.Calc.Logic.dbPMDS dbSelect = null;
                PMDS.Calc.Logic.dbPMDS dbVorschau = new dbPMDS();
                PMDS.Calc.Logic.dbPMDS dbFreigegeben = new dbPMDS();
                bool showFreigegebenAndStorniert2 = showFreigegebenAndStorniert;
                PMDS.Calc.Logic.eBillStatus status2;

                if (status == eBillStatus.offen)
                {
                    status2 = BillStatusFreigegeben;
                    dbVorschau = db;
                    dbSelect = dbFreigegeben;
                    btnOffene = this.form.btnVorschau;
                    btnFreigegebene = this.form.btnFreigeben;
                }
                else
                {
                    status2 = eBillStatus.offen;
                    dbFreigegeben = db;
                    dbSelect = dbVorschau;
                    btnOffene = this.form.btnVorschau;
                    btnFreigegebene = this.form.btnFreigeben;
                    showFreigegebenAndStorniert2 = false;
                }

                calculation calculation2 = new calculation();
                if (this.typ == eTyp.calc)
                {
                    //calculation2.Load(ref this.sitemap.listID, von, bis, vonRechDatum, bisRechDatum, ref dbSelect, rechTyp, status2, false, Settings.IDKlinik, showFreigegebenAndStorniert2, showExportierte, "");
                    if (status == eBillStatus.offen)
                    {
                        dbFreigegeben = dbSelect;
                    }
                    else
                    {
                        dbVorschau = dbSelect;
                    }
                }
                else if (this.typ == eTyp.sr)
                {
                    this.calculation.Load(von, bis, vonRechDatum, bisRechDatum, ref dbSelect, rechTyp, status2, false, ENV.IDKlinik, showFreigegebenAndStorniert2, showExportierte, "");
                    if (status == eBillStatus.offen)
                    {
                        dbFreigegeben = dbSelect;
                    }
                    else
                    {
                        dbVorschau = dbSelect;
                    }
                }
          
                btnOffene.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorschau") + "" + " (" + dbVorschau.bills.Count.ToString() + ")";
                btnFreigegebene.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Freigegeben") + "" + " (" + dbFreigegeben.bills.Count.ToString() + ")";
            }
            catch (Exception ex)
            {
                throw new Exception("showAnzButtonsCalc: " + ex.ToString());
            }
            finally
            {
            }
        }

        public void gridToStorno(bool on, ref PMDS.Calc.Logic.dbPMDS db, ref UltraGrid grid)
        {
            try
            {
                if (on)
                {
                    foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, false))
                    {
                        if (!this.sitemap.IsInExpandedGroup(r))
                            continue;

                        PMDS.Calc.Logic.dbPMDS.billsRow rDS = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)r.ListObject).Row;
                        PMDS.Calc.Logic.dbBill dbBill = this.dbBill.getDbBill(rDS.dbBill);
                        PMDS.Calc.Logic.dbBill.fieldsRow rField = this.dbBill.getID(dbBill, PMDS.Calc.Logic.dbBill.idStornoRechNr);
                        if (rField != null) r.Cells["RechNrStorno"].Value = rField.txt;

                        //var rBillHeader = db.billHeader.Where(b => b.ID == rDS.IDAbrechnung).First();
                        //dbCalc dbCalc = this.doBill.getDBCalc(rBillHeader.dbCalc);
                        //dbCalc.MonateRow rMonat = this.dbBill.getRechDatum(dbCalc);
                        //r.Cells["RechDatum"].Value = rMonat.RechDatum.Date;
                    }

                    //foreach (PMDS.Calc.Logic.dbPMDS.billsRow rBill in db.bills)
                    //{
                    //}
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void setUI(UltraGrid grid)
        {
            if (grid.DisplayLayout.Bands[0].SortedColumns.Count > 0 ) return;
            grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            if (this.typ == ucCalcsSitemap.eTyp.calc )
            {
                grid.DisplayLayout.Bands[0].SortedColumns.Add("KlientName", false);
                grid.DisplayLayout.Bands[0].SortedColumns.Add("datum", false);
            }
            else 
            {
                grid.DisplayLayout.Bands[0].SortedColumns.Add("KostenträgerName", false);
                grid.DisplayLayout.Bands[0].SortedColumns.Add("KlientName", false);
                grid.DisplayLayout.Bands[0].SortedColumns.Add("datum", false);
            }
        }
        public PMDS.Calc.Logic.eBillStatus getStatus(object sValCboBillStatus)
        {
            PMDS.Calc.Logic.eBillStatus status = new PMDS.Calc.Logic.eBillStatus();
           
            if (this._freigeben)
                if (sValCboBillStatus != null && sValCboBillStatus.sEquals("s"))
                    status = PMDS.Calc.Logic.eBillStatus.storniert;
                else
                    status = PMDS.Calc.Logic.eBillStatus.freigegeben;
            else
                status = PMDS.Calc.Logic.eBillStatus.offen;
            return status;
        }
        public PMDS.Calc.Logic.eBillStatus getStatus2(object sValCboBillStatus)
        {
            PMDS.Calc.Logic.eBillStatus status = new PMDS.Calc.Logic.eBillStatus();

            if (sValCboBillStatus != null && sValCboBillStatus.sEquals("s"))
                status = PMDS.Calc.Logic.eBillStatus.storniert;
            else
                status = PMDS.Calc.Logic.eBillStatus.freigegeben;

            return status;
        }

        public bool setFilterKlienten(PMDS.Global.eSendMain typ, List<string> filterString, bool suche, object obj    )
        {
            this.sitemap.listID.Clear();
            List < Guid > Klienten = new List<Guid>();
            foreach (string sKlient in filterString)
                this.sitemap.listID.Add(sKlient);
            this.form.loadCalcs();
            return true;
        }
        
        public void doSR(DateTime monat , DateTime rechDatum, ref System.Collections.Generic.List<Logic.doSr.cPatients> lstSelPatients)
        {
            try
            {
                this.print.loadTempStream(PMDS.Calc.Logic.bill.rechnungRTF);
                this.doSr.run(this.IDKost, monat, rechDatum, this.form.editor, PMDS.Global.ENV.IDKlinik, ref lstSelPatients);
                this.form.loadCalcs();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public bool validSR(bool info)
        {
            if (String.IsNullOrWhiteSpace(this.IDKost))
            {
                if (info) { QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!", "Sammelabrechnung starten"); }
                return false;
            }
            return true;
        }

     

        public void doAction22(eAction typ, string txtQuestion, string txtInfo,  UltraGrid grid,
                                  ref QS2.Desktop.ControlManagment.BaseLabel lblCount, PMDS.Calc.Logic.eModify typModify, 
                                  bool msgBox, Nullable<DateTime> datStornodatum, Nullable<DateTime> rechDatum, bool RollungFreigegebenJN)
        {
            try
            {
                string sProt = "";

                List<UltraGridRow> arrSelected = new List<UltraGridRow>();
                List<PMDS.Calc.Logic.dbPMDS.billsRow> arrBillRows = new List<PMDS.Calc.Logic.dbPMDS.billsRow>();
                Infragistics.Win.UltraWinGrid.UltraGridRow rSelRow = null;
                DialogResult res = DialogResult.No;
                if (typ == eAction.stornieren)
                {
                    res = DialogResult.Yes;
                    this.sitemap.doAction22(typ, "", "", txtInfo, grid, ref lblCount, ref arrSelected, false);
                }
                else if (typ == eAction.fswsFTPOnly)
                {
                    res = DialogResult.Yes;
                }
                else
                {
                    res = this.sitemap.doAction22(typ, txtQuestion, "", txtInfo, grid, ref lblCount, ref arrSelected, msgBox);
                }

                if (res == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        db.Configuration.LazyLoadingEnabled = false;

                        int anzDel = 0;
                        if (typ == eAction.freigeben || typ == eAction.stornieren || typ == eAction.fsw || typ == eAction.fswreset || typ == eAction.fswNoUpload || typ == eAction.fswsFTPOnly || typ == eAction.rollen || typ == eAction.fswXlsVorschau)
                        {
                            List<String> listIDBills = new List<String>();
                            foreach (UltraGridRow rToDel in arrSelected)
                            {
                                PMDS.Calc.Logic.dbPMDS.billsRow r = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)rToDel.ListObject).Row;
                                if (r.Typ == (int)eBillTyp.Rechnung ||      //FSW-ZAUF prüfen?
                                    (r.Typ == (int)eBillTyp.Beilage && r.IDSR.Length == 0) || 
                                    r.Typ == (int)eBillTyp.Sammelrechnung || 
                                    r.Typ == (int)eBillTyp.FreieRechnung
                                    )
                                {
                                    listIDBills.Add(r.ID);
                                }
                            }

                            /* os, 5.8.2018
                               Hier Suche nach letzte Rechnungen für andere Kostenträgern des Klienten im Monat 
                               Rechnungen zu listIDBills hinzufügen
                               Andere Kostenträger auch rollen - Fehler bei Rollung für 2. Kostenträger korrigieren
                               
                            Test für Janisch Paula, März 2018
                            listIDBills.Add("4566bbcc-1be6-456e-bcbb-40ec1883eb67");
                             */

                            if (typ == eAction.rollen)
                            {
                                System.Collections.Generic.List<calculation.cBill> listIDDoStorno = new List<calculation.cBill>();
                                if (this.typ == ucCalcsSitemap.eTyp.calc)
                                {
                                    db.Configuration.LazyLoadingEnabled = false;
                                    using (PMDS.Calc.Logic.Sql sqlCheck = new PMDS.Calc.Logic.Sql())
                                    {
                                        //this.doBill.doAction(listIDBills, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, ref this.form.editor, "f", PMDS.Global.Settings.IDKlinik, true, ref listIDDoStorno);
                                        foreach (string IDBillStr in listIDBills)
                                        {
                                            Guid IDBillToCheck = new Guid(IDBillStr.Trim());
                                            PMDS.db.Entities.bills rBill2 = db.bills.Where(b => b.ID == IDBillStr).First();
                                            IQueryable<PMDS.db.Entities.bills> tBills = null;
                                            if (this.typ == ucCalcsSitemap.eTyp.calc)
                                            {
                                                Guid chkGuid = Guid.Empty;
                                                if (rBill2.Typ == (int)eBillTyp.Rechnung)
                                                {
                                                    if (RollungFreigegebenJN)       //Standard - Rollung gegen freigegbene Rechnungen
                                                    {
                                                        tBills = db.bills.Where(b => b.datum == rBill2.datum &&
                                                                                b.Typ != 3 &&
                                                                                b.IDKlient == rBill2.IDKlient &&
                                                                                b.Typ == (int)eBillTyp.Rechnung &&
                                                                                b.Freigegeben == true &&
                                                                                b.Status == (int)eBillStatus.freigegeben //&&
                                                                                //b.IDSR.Length == 0
                                                                                ).OrderByDescending(p => p.ErstellAm);
                                                    }
                                                    else
                                                    {                                 //Sonderfall - Rollung gegen nicht freigegebene Rechnungnen
                                                        tBills = db.bills.Where(b => b.datum == rBill2.datum &&
                                                                                b.Typ != 3 &&
                                                                                b.IDKlient == rBill2.IDKlient &&
                                                                                b.Typ == (int)eBillTyp.Rechnung &&
                                                                                b.Freigegeben == false &&
                                                                                b.Status == (int)eBillStatus.offen &&
                                                                                b.IDSR.Length == 0 &&
                                                                                b.ID.ToString() != IDBillStr                        //nicht gegen sich selbst rollen!
                                                                                ).OrderByDescending(p => p.ErstellAm);
                                                    }
                                                }
                                                else if (rBill2.Typ == (int)eBillTyp.Beilage)
                                                {
                                                    tBills = db.bills.Where(b => b.datum == rBill2.datum && b.Typ != 3 && b.IDKlient == rBill2.IDKlient && ((b.Typ == (int)eBillTyp.Beilage && b.Freigegeben == false && b.Status == 0 && b.IDSR.Length != 0))).OrderByDescending(p => p.ErstellAm);
                                                }
                                                else if (rBill2.Typ == (int)eBillTyp.FreieRechnung)
                                                {
                                                    tBills = db.bills.Where(b => b.datum == rBill2.datum && b.Typ != 3 && b.IDKlient == rBill2.IDKlient && ((b.Typ == (int)eBillTyp.FreieRechnung && b.Freigegeben == true && b.Status == 0 && b.IDSR.Length != 0))).OrderByDescending(p => p.ErstellAm);
                                                }
                                            }
                                            //else if (this.typ == ucCalcsSitemap.eTyp.sr)
                                            //{
                                            //    tBills = db.bills.Where(b => b.datum == rBill2.datum && b.Freigegeben == true && b.Status == 1 && b.Typ == 3);
                                            //}

                                            foreach (PMDS.db.Entities.bills rBill in tBills)
                                            {
                                                dbPMDS.billsRow rBillToStorno = sqlCheck.readBill(rBill.ID);
                                                //if (rBillToStorno.IDBillStorno.Trim() != "")
                                                //{
                                                calculation.cBill newBillToStorno = new calculation.cBill();
                                                newBillToStorno.rBillToStorno = rBillToStorno;
                                                newBillToStorno.IDBillNew = IDBillStr;
                                                listIDDoStorno.Add(newBillToStorno);

                                                break;
                                                //}
                                            }
                                        }
                                    }

                                    if (listIDDoStorno.Count > 0)
                                    {
                                        using (PMDS.GUI.Calc.Calc.UI.frmMsgBoxWithGrid frmMsgBoxWithGrid1 = new GUI.Calc.Calc.UI.frmMsgBoxWithGrid())
                                        {
                                            frmMsgBoxWithGrid1.initControl(GUI.Calc.Calc.UI.frmMsgBoxWithGrid.eTypeUI.CalcCheckDoStorno, ref listIDDoStorno);
                                            frmMsgBoxWithGrid1.ShowDialog(this);
                                            if (!frmMsgBoxWithGrid1.abort)
                                            {
                                                System.Collections.Generic.List<string> lstBillsToDelete = new List<string>();
                                                foreach (calculation.cBill cBill in frmMsgBoxWithGrid1._listBillsSelected)
                                                {
                                                    //if (cBill.rBillToStorno.IDBillStorno.Trim() != "")
                                                    //{
                                                    //    throw new Exception("ucCalcsSitemap.doAction22: rBillToStorno.IDBillStorno.Trim()!='' '" + cBill.rBillToStorno.ID.Trim() + "' not allowed!");
                                                    //}

                                                    if (this.typ == ucCalcsSitemap.eTyp.calc)
                                                    {
                                                        PMDS.db.Entities.bills rBillNew = db.bills.Where(b => b.ID == cBill.IDBillNew).First();
                                                        //PMDS.db.Entities.billHeader rBillHeaderNew = db.billHeader.Where(b => b.ID == rBillNew.IDAbrechnung).First();
                                                        //dbCalc dbCalcFoundNew = this.doBill.getDBCalc(rBillHeaderNew.dbCalc);

                                                        if (cBill.rBillToStorno.Typ == (int)eBillTyp.Rechnung)
                                                        {
                                                            dbCalc dbCalcFoundNew = null;   //this.doBill.getDBCalc(rBillHeaderNew.dbCalc);
                                                            string IDBillGeneratedBack = "";
                                                            if (cBill.rBillToStorno.betrag != 0)
                                                            {
                                                                this.doBill.doStornoBill(cBill.rBillToStorno, cBill.rBillToStorno.IDAbrechnung, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, ref this.form.editor, rechDatum.Value.Date, ref IDBillGeneratedBack, db, dbCalcFoundNew);

                                                                PMDS.db.Entities.bills rBill33 = db.bills.Where(b => b.ID == cBill.IDBillNew).First();
                                                                PMDS.db.Entities.bills rBillNewSaved = db.bills.Where(b => b.ID == IDBillGeneratedBack).First();
                                                                if (rBillNewSaved.betrag + rBill33.betrag == 0)
                                                                {
                                                                    lstBillsToDelete.Add(rBillNewSaved.ID);
                                                                    lstBillsToDelete.Add(rBill33.ID);
                                                                }
                                                                rBill33.IDBillsGerollt = cBill.rBillToStorno.ID;        //os 2021-03-30: Rechnung merken, die gerollt wurde (als Kennzeichen für FSW, dass es sich um eine zusätzliche Rechnung handelt) 
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                        if (rBillNew.Typ == (int)eBillTyp.Beilage && cBill.rBillToStorno.Typ == (int)eBillTyp.Beilage)
                                                        {
                                                            this.doRollung.run(cBill.rBillToStorno, rBillNew, ref this.form.editor, db);
                                                            System.GC.Collect();
                                                        }
                                                    }
                                                    else if (this.typ == ucCalcsSitemap.eTyp.sr)
                                                    {
                                                        //PMDS.db.Entities.billHeader rBillHeaderToStorno = db.billHeader.Where(b => b.ID == rBillToStorno.IDAbrechnung).First();
                                                        //dbCalc dbCalcFoundNew = this.doBill.getDBCalc(rBillHeaderToStorno.dbCalc);
                                                        //this.doSr.doRollung(rBillToStorno, ref dbCalcFoundNew);
                                                    }
                                                }

                                                foreach (string IDBillToDelete in lstBillsToDelete)
                                                {
                                                    IQueryable<PMDS.db.Entities.bills> tBillsStornoReset = db.bills.Where(b => b.IDBillStorno.Contains(IDBillToDelete));
                                                    foreach (PMDS.db.Entities.bills rBillStornoReset in tBillsStornoReset)
                                                    {
                                                        rBillStornoReset.IDBillStorno = "";
                                                        rBillStornoReset.RollungAnz = 0;
                                                    }
                                                    PMDS.db.Entities.bills rBillToDelete = db.bills.Where(b => b.ID == IDBillToDelete).First();
                                                    db.bills.Remove(rBillToDelete);
                                                    db.SaveChanges();
                                                }
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Msg Keine Rechnungen zum Rollen gefunden
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine rollbaren Rechunngen gefunden.", "", MessageBoxButtons.OK);
                                        return;
                                    }

                                    //Storno aller freigegebenen Rechnungen (wenn Kostenträger gewechselt wurde, würden die Originalrechnugnen nicht storniert)
                                    foreach (string IDBillStr in listIDBills)
                                    {
                                        IQueryable<PMDS.db.Entities.bills> tBillGrid = db.bills.Where(b => b.ID == IDBillStr);
                                        if (tBillGrid.Count() == 1)
                                        {
                                            PMDS.db.Entities.bills rBillGrid = tBillGrid.First();
                                            IQueryable<PMDS.db.Entities.bills> tBillsStornoRech = db.bills.Where(b => b.datum == rBillGrid.datum &&
                                                                                                                    b.Typ != 3 &&
                                                                                                                    b.IDKlient == rBillGrid.IDKlient &&
                                                                                                                    (b.Typ == (int)eBillTyp.Rechnung &&
                                                                                                                    b.Freigegeben == true &&
                                                                                                                    b.Status == 1 &&
                                                                                                                    b.IDSR.Length == 0 &&
                                                                                                                    b.IDBillStorno.Trim().Length == 0
                                                                                                                    )
                                                                                                                ).OrderByDescending(p => p.ErstellAm);
                                            System.Collections.Generic.List<PMDS.db.Entities.bills> tBillsToDo = new List<db.Entities.bills>();
                                            foreach (PMDS.db.Entities.bills rBillToStorno in tBillsStornoRech)
                                            {
                                                tBillsToDo.Add(rBillToStorno);
                                            }
                                            foreach (PMDS.db.Entities.bills rBillToStorno in tBillsToDo)
                                            {
                                                //PMDS.db.Entities.billHeader rBillHeaderStorno = db.billHeader.Where(b => b.ID == rBillToStorno.IDAbrechnung).First();
                                                dbCalc dbCalcFoundStorno = null;            //this.doBill.getDBCalc(rBillHeaderStorno.dbCalc);
                                                using (Sql SqlUpdate = new Sql())
                                                {
                                                    dbPMDS.billsRow rBillToStornoDs = SqlUpdate.readBill(rBillToStorno.ID);
                                                    string IDBillGeneratedBack = "";
                                                    this.doBill.doStornoBill(rBillToStornoDs, rBillToStorno.IDAbrechnung, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, ref this.form.editor, rechDatum.Value.Date, ref IDBillGeneratedBack, db, dbCalcFoundStorno);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (this.typ == ucCalcsSitemap.eTyp.buchhaltung || this.typ == ucCalcsSitemap.eTyp.depotgeld)
                                {
                                    throw new Exception("ucCalcsSitemap.doAction22: this.typ for eTyp.buchhaltung and eTyp.depotgeld not allowed!");
                                }                                
                            }

                            else if (typ == eAction.freigeben)
                            {
                                this.calculation.freigeben(listIDBills, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, this.form.editor, PMDS.Global.ENV.IDKlinik, null);
                            }

                            else if (typ == eAction.fsw)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, FSWAbrechnung.eAction.fsw);
                            }

                            else if (typ == eAction.fswXlsVorschau)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, FSWAbrechnung.eAction.fswXlsVorschau);
                            }

                            else if (typ == eAction.fswNoUpload)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, FSWAbrechnung.eAction.fswNoUpload);
                            }

                            else if (typ == eAction.fswreset)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, FSWAbrechnung.eAction.fswreset);
                            }
                            else if (typ == eAction.fswsFTPOnly)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, FSWAbrechnung.eAction.fswsFTPOnly);
                            }

                            else if (typ == eAction.stornieren)
                            {
                                foreach (string IDBillStr in listIDBills)
                                {
                                    PMDS.db.Entities.bills rBill2 = db.bills.Where(b => b.ID == IDBillStr).First();
                                    if (String.IsNullOrWhiteSpace(rBill2.IDBillStorno))
                                    {
                                        this.calculation.stornieren(listIDBills, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, this.form.editor, PMDS.Global.ENV.IDKlinik, datStornodatum, null);
                                    }
                                    else
                                    {
                                        sProt += QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung") + " "  + rBill2.RechNr.Trim() + "\r\n";
                                    }
                                }
                            }

                            System.GC.Collect();
                            this.form.loadCalcs();
                            return;
                        }
                        Admin.frmMainCalc.editorTmp.Text = "";
                        string IDBillStrTmp = "";
                        foreach (UltraGridRow rToDel in arrSelected)
                        {
                            PMDS.Calc.Logic.dbPMDS.billsRow r = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)rToDel.ListObject).Row;
                            IDBillStrTmp = r.ID;

                            if (typ == eAction.delete)
                            {
                                var tBills = (from b in db.bills
                                           join bh in db.billHeader on b.IDAbrechnung equals bh.ID
                                           where bh.ID == r.IDAbrechnung && b.Freigegeben == true
                                           select new
                                           {
                                               Freigegeben = b.Freigegeben,
                                               ID = b.ID,
                                               KostenträgerName = b.KostenträgerName
                                           });

                                if (!PMDS.Global.ENV.adminSecure && tBills.Count() > 0)
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde bereits mindestens eine Rechnung freigegeben. Die Vorschau kann nicht gelöscht werden!", "", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    this.calculation.delete(r.IDAbrechnung, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, this.typ == ucCalcsSitemap.eTyp.depotgeld ? true : false, PMDS.Global.ENV.IDKlinik);
                                    rToDel.Delete(false);
                                    anzDel += 1;
                                }
                            }
                            else if (typ == eAction.printBill)
                            {
                                arrBillRows.Add(r);
                                if (rSelRow == null) rSelRow = rToDel;
                            }
                            else if (typ == eAction.einzahlungBuchen)
                            {
                                PMDS.Calc.Logic.calcData calcData = new PMDS.Calc.Logic.calcData();
                                this.booking.saveBooking(PMDS.Calc.Logic.eKonto.Zahlungen, PMDS.Calc.Logic.eKonto.Kundenforderungen,
                                                       DateTime.Now, QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlösbuchung"),
                                                        System.Convert.ToDecimal(r.betrag), -1, r.RechNr , r.IDKlient , r.IDKost ,
                                                        ref calcData, true, PMDS.Calc.Logic.eCalcRun.month, PMDS.Global.ENV.IDKlinik); 
                            }
                            else if (typ == eAction.SperreRollungLöschen)
                            {
                                if (r.Typ == (int)eBillTyp.Rechnung)
                                {
                                    this.sql.updateBillSet_IDBillStorno(r.ID, "");
                                }
                            }                         
                        }

                        if (arrSelected.Count != 1)
                        {
                            IDBillStrTmp = "";
                        }
                    
                        //this.sitemap.anz -= anzDel;
                        //this.sitemap.setUIAnzahl(ref lblCount, "Keine Rechnungen gefunden!");
                        if (typ == eAction.printBill)
                        {
                            this.print.printBills(arrBillRows, this.form.editor, QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Rechnung/en"), arrBillRows.Count == 1 ? this : null, (object)rSelRow, typModify, ENV.TextKlientenInfo,
                                                    Admin.frmMainCalc.editorTmp, IDBillStrTmp, (this.typ == eTyp.depotgeld ? true : false));
                        }                       
                        else
                            this.form.loadCalcs();

                        if (!String.IsNullOrWhiteSpace(txtInfo)) 
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtInfo, QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en"), true);
                    }
                }

                if (!String.IsNullOrWhiteSpace(sProt))
                {
                    sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende bereits stornierte Rechnungen können nicht erneut storniert werden:") + "\r\n" + "\r\n" + sProt.Trim();
                    qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                    frmProt.initControl();
                    frmProt.Show();
                    frmProt.ContProtocol1.setText(sProt);
                    frmProt.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Warnung für Rechnungsstorno");
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                System.GC.Collect();
            }
        }

        public void saveRTF( string  rtf,   Infragistics.Win.UltraWinGrid.UltraGridRow selRow )
        {
            try
            {
                PMDS.Calc.Logic.Sql sql = new PMDS.Calc.Logic.Sql();
                sql.saveRechnung (selRow.Cells["ID"].Value.ToString (), rtf);
                selRow.Cells["Rechnung"].Value = rtf;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Rechnungsänderung wurde in PMDS gesichert!", "Rechnung sichern");
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        public void PflegestufenlisteXLS(DateTime month)
        {
            try
            {
                //Excel erstellen und öffnen
                Infragistics.Documents.Excel.Workbook wb = new Infragistics.Documents.Excel.Workbook(WorkbookFormat.Excel2007);
                Infragistics.Documents.Excel.Worksheet ws = wb.Worksheets.Add("FiBU Pflegestufenübersicht");
                ws.Rows[0].Cells[0].Value = "Familienname";
                ws.Rows[0].Cells[1].Value = "Vorname";
                ws.Rows[0].Cells[2].Value = "Abteilung";
                ws.Rows[0].Cells[3].Value = "Bereich";
                ws.Rows[0].Cells[4].Value = "Pflegestufe";
                ws.Rows[0].Cells[5].Value = "von";
                ws.Rows[0].Cells[6].Value = "bis";
                ws.Rows[0].Cells[7].Value = "FiBu";

                ws.Columns[0].Width = 7000;
                ws.Columns[0].CellFormat.WrapText = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                ws.Columns[1].Width = 4000;
                ws.Columns[2].Width = 7000;
                ws.Columns[3].Width = 4000;
                ws.Columns[4].Width = 14000;
                ws.Columns[5].Width = 3000;
                ws.Columns[6].Width = 3000;
                ws.Columns[7].Width = 3000;

                for (int c = 0; c <= 7; c++)
                {
                    ws.Rows[0].Cells[c].CellFormat.Fill = CellFill.CreateSolidFill(System.Drawing.Color.LightSalmon);
                    ws.Rows[0].Cells[c].CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin;
                    ws.Rows[0].Cells[c].CellFormat.RightBorderStyle = CellBorderLineStyle.Thin;
                }

                int z = 0;
                var dec = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                var thousend = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
                var curency = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                string EuroString = "#" + thousend + "##0" + dec + "00 [$€-x-euro2]; -#" + thousend + "##" + dec +
                                    "00 [$€-x-euro2]; 0,00 [$€-x-euro2]";


                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //Sort list ascending
                    System.Collections.ArrayList listIDSort = new ArrayList();
                    for (int i = this.sitemap.listID.Count - 1; i >= 0; i--)
                    {
                        listIDSort.Add(this.sitemap.listID[i]);
                    }

                    foreach (var IDKlient in listIDSort)
                    {
                        //Klient lesen (Vorname, Nachname, Abteilung, Bereich, )
                        Guid gIDKlient = new Guid(IDKlient.ToString());
                        DateTime dtCheckVon = month.AddMonths(1).AddSeconds(-1);
                        var rAufenthalt = (from a in db.vAufenthaltsliste
                                           where a.IDPatient == gIDKlient
                                           select new
                                           {
                                               Nachname = a.Nachname,
                                               Vorname = a.Vorname,
                                               Abteilung = a.Abteilung,
                                               Bereich = a.Bereich
                                           }).FirstOrDefault();

                        //Pflegegeldstufenbezeichnung, Ab-Datum, Bis-Datum, FiBu-Konto  lesen
                        var rLeistungsplan = (from lp in db.PatientLeistungsplan
                                              join lk in db.Leistungskatalog on lp.IDLeistungskatalog equals lk.ID
                                              where lp.IDPatient == gIDKlient &&
                                                  lk.enumLeistungsgruppe == 1 &&
                                                  lp.GueltigAb <= dtCheckVon &&
                                                  (lp.GueltigBis == null || lp.GueltigBis > month)
                                              select new
                                              {
                                                  PS = lk.Bezeichnung,
                                                  von = lp.GueltigAb,
                                                  bis = lp.GueltigBis,
                                                  FiBu = lk.FIBUKonto
                                              }).FirstOrDefault();

                        if (rLeistungsplan != null)
                        {
                            z++;
                            ws.Rows[z].Cells[0].Value = rAufenthalt.Nachname;
                            ws.Rows[z].Cells[1].Value = rAufenthalt.Vorname;
                            ws.Rows[z].Cells[2].Value = rAufenthalt.Abteilung;
                            ws.Rows[z].Cells[3].Value = rAufenthalt.Bereich;
                            ws.Rows[z].Cells[4].Value = rLeistungsplan.PS ?? "k.A.";
                            ws.Rows[z].Cells[5].Value = (object)rLeistungsplan.von ?? "k.A.";
                            ws.Rows[z].Cells[6].Value = (object)rLeistungsplan.bis ?? "laufend";
                            ws.Rows[z].Cells[7].Value = rLeistungsplan.FiBu ?? "k.A.";
                        }
                    }

                    string xlsWorking = System.IO.Path.Combine(ENV.FSW_EZAUF, "FiBu_Pflegestufenübersicht_" + month.ToString("yyMM_") + Guid.NewGuid().ToString("D") + ".xlsx");
                    wb.Save(xlsWorking);
                    if (System.IO.File.Exists(xlsWorking))
                    {
                        if (generic.IsExcelInstalled())
                        {
                            System.Diagnostics.Process.Start(xlsWorking);
                            return;
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(
                                "Datei wurde gespeichert (" + xlsWorking +
                                "), kann aber nicht geöffnet werden, weil Excel nicht installiert ist.", "Hinweis",
                                System.Windows.Forms.MessageBoxButtons.OK);
                            return;
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

            }
        }
    }
}
