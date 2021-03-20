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

namespace PMDS.Calc.UI
{

    public class ucCalcsSitemap : QS2.Desktop.ControlManagment.BaseControl
    {
        public PMDS.UI.Sitemap.UIFct sitemap;
        public PMDS.Calc.UI.ucCalcs form;
        public PMDS.Calc.Logic.calculation calculation;
        public PMDS.Calc.Logic.doBill doBill;
        public PMDS.Calc.Logic.doRollung doRollung;

        public bool _freigeben = false;

        public PMDS.Calc.Logic.print print;

        public PMDS.Calc.Logic.Sql sql;
        public PMDS.Calc.Logic.doSr doSr;
        public PMDS.Calc.Logic.doDepotgeld doDepot;
        
        public string  IDKost = "";
        public bool isLoaded = false;
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
                    this.calculation.init(RBU.DataBase.CONNECTION, PMDS.Global.ENV.KuerzungGrundleistungLetzterTag,
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
                                PMDS.Global.ENV.RechErwAbwesenheit, PMDS.Global.ENV.SrErwAbwesenheit,
                                PMDS.Global.ENV.ZahlKondBankeinzug, PMDS.Global.ENV.ZahlKondErlagschein,
                                PMDS.Global.ENV.ZahlKondÜberweisung, PMDS.Global.ENV.ZahlKondBar, ENV.AbwesenheitenAnzeigen, ENV.RechTitelDepotGeld);
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
                                PMDS.Calc.Logic.eBillStatus status, bool showFreigegebenAndStorniert, bool showExportierte,
                                PMDS.Calc.Logic.eBillStatus BillStatusFreigegeben)
        { 
              try
              {
                    db.Clear();
                    
                    
                    if (this.typ == eTyp.calc)
                    {
                        this.calculation.load(ref this.sitemap.listID, von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, false, ENV.IDKlinik, showFreigegebenAndStorniert, showExportierte);
                        this.showAnzButtonsCalc(ref db, von, bis, vonRechDatum, bisRechDatum, grid, butAlleKeine, ref lblCount, rechTyp, status, showFreigegebenAndStorniert, showExportierte, BillStatusFreigegeben);
                    }
                    else if (this.typ == eTyp.depotgeld)
                    {
                        this.calculation.load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, true, ENV.IDKlinik, showFreigegebenAndStorniert, showExportierte);
                    }
                    else if (this.typ == eTyp.sr)
                    {
                        this.calculation.load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, false, ENV.IDKlinik, showFreigegebenAndStorniert, showExportierte);
                        this.showAnzButtonsCalc(ref db, von, bis, vonRechDatum, bisRechDatum, grid, butAlleKeine, ref lblCount, rechTyp, status, showFreigegebenAndStorniert, showExportierte, BillStatusFreigegeben);
                    }
                    else if (this.typ == eTyp.buchhaltung)
                    {
                        this.calculation.load(von, bis, vonRechDatum, bisRechDatum, ref db, rechTyp, status, true, ENV.IDKlinik, showFreigegebenAndStorniert, showExportierte);
                    }

                    grid.Refresh();
                  
                    this.setUI(grid);
                    this.gridToStorno(status == PMDS.Calc.Logic.eBillStatus.storniert || showFreigegebenAndStorniert, ref db, ref grid );
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
                    calculation2.load(ref this.sitemap.listID, von, bis, vonRechDatum, bisRechDatum, ref dbSelect, rechTyp, status2, false, ENV.IDKlinik, showFreigegebenAndStorniert2, showExportierte);
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
                    this.calculation.load(von, bis, vonRechDatum, bisRechDatum, ref dbSelect, rechTyp, status2, false, ENV.IDKlinik, showFreigegebenAndStorniert2, showExportierte);
                    if (status == eBillStatus.offen)
                    {
                        dbFreigegeben = dbSelect;
                    }
                    else
                    {
                        dbVorschau = dbSelect;
                    }
                }
          
                btnOffene.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorschau") + "" + " (" + dbVorschau.bills.Count().ToString() + ")";
                btnFreigegebene.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Freigegeben") + "" + " (" + dbFreigegeben.bills.Count().ToString() + ")";
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
                if (sValCboBillStatus != null && sValCboBillStatus.ToString().Trim().ToLower().Equals(("s").Trim().ToLower()))
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

            if (sValCboBillStatus != null && sValCboBillStatus.ToString().Trim().ToLower().Equals(("s").Trim().ToLower()))
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
            if (this.IDKost == "" )
            {
                if (info) { QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!", "Sammelabrechnung starten"); }
                return false;
            }
            return true;
        }

     

        public void doAction22(eAction typ, string txtQuestion, string txtInfo,  UltraGrid grid,
                                  ref QS2.Desktop.ControlManagment.BaseLabel lblCount, PMDS.Calc.Logic.eModify typModify, 
                                  bool msgBox, Nullable<DateTime> datStornodatum, Nullable<DateTime> rechDatum, bool RollungJN)
        {
            try
            {
                PMDS.Calc.Logic.Sql sqlCheck = new PMDS.Calc.Logic.Sql();
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
                else
                {
                    res = this.sitemap.doAction22(typ, txtQuestion, QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en"), txtInfo, grid, ref lblCount, ref arrSelected, msgBox);
                }

                if (res == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        db.Configuration.LazyLoadingEnabled = false;

                        int anzDel = 0;
                        if (typ == eAction.freigeben || typ == eAction.stornieren || typ == eAction.fsw || typ == eAction.fswreset)
                        {
                            List<String> listIDBills = new List<String>();
                            foreach (UltraGridRow rToDel in arrSelected)
                            {
                                PMDS.Calc.Logic.dbPMDS.billsRow r = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)rToDel.ListObject).Row;
                                if (r.Typ == (int)eBillTyp.Rechnung || (r.Typ == (int)eBillTyp.Beilage && r.IDSR == "") || r.Typ == (int)eBillTyp.Sammelrechnung || r.Typ == (int)eBillTyp.FreieRechnung)
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

                            if (typ == eAction.freigeben)
                            {
                                if (RollungJN)
                                {
                                    System.Collections.Generic.List<calculation.cBill> listIDDoStorno = new List<calculation.cBill>();
                                    if (this.typ == ucCalcsSitemap.eTyp.calc && RollungJN)
                                    {
                                        db.Configuration.LazyLoadingEnabled = false;

                                        //this.doBill.doAction(listIDBills, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, ref this.form.editor, "f", PMDS.Global.ENV.IDKlinik, true, ref listIDDoStorno);
                                        foreach (string IDBillStr in listIDBills)
                                        {
                                            Guid IDBillToCheck = new Guid(IDBillStr.Trim());
                                            PMDS.db.Entities.bills rBill2 = db.bills.Where(b => b.ID == IDBillStr).First();
                                            IQueryable<PMDS.db.Entities.bills> tBills = null;
                                            if (this.typ == ucCalcsSitemap.eTyp.calc)
                                            {
                                                if (rBill2.Typ == (int)eBillTyp.Rechnung)
                                                {
                                                    tBills = db.bills.Where(b => b.datum == rBill2.datum && b.Typ != 3 && b.IDKlient == rBill2.IDKlient && ((b.Typ == (int)eBillTyp.Rechnung && b.Freigegeben == true && b.Status == 1 && b.IDSR == ""))).OrderByDescending(p => p.ErstellAm);
                                                }
                                                else if (rBill2.Typ == (int)eBillTyp.Beilage)
                                                {
                                                    tBills = db.bills.Where(b => b.datum == rBill2.datum && b.Typ != 3 && b.IDKlient == rBill2.IDKlient && ((b.Typ == (int)eBillTyp.Beilage && b.Freigegeben == false && b.Status == 0 && b.IDSR != ""))).OrderByDescending(p => p.ErstellAm);
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

                                        if (listIDDoStorno.Count > 0)
                                        {
                                            PMDS.GUI.Calc.Calc.UI.frmMsgBoxWithGrid frmMsgBoxWithGrid1 = new GUI.Calc.Calc.UI.frmMsgBoxWithGrid();
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
                                                                System.GC.Collect();
                                                            }
                                                            else
                                                            {
                                                                bool bBetragIsNull = true;
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

                                        //Storno aller freigegebenen Rechnungen (wenn Kostenträger gewechselt wurde, würden die Originalrechnugnen nicht storniert)
                                        foreach (string IDBillStr in listIDBills)
                                        {
                                            IQueryable<PMDS.db.Entities.bills> tBillGrid = db.bills.Where(b => b.ID == IDBillStr);
                                            if (tBillGrid.Count() == 1)
                                            {
                                                PMDS.db.Entities.bills rBillGrid = tBillGrid.First();
                                                IQueryable<PMDS.db.Entities.bills> tBillsStornoRech = db.bills.Where(b => b.datum == rBillGrid.datum && b.Typ != 3 && b.IDKlient == rBillGrid.IDKlient && ((b.Typ == (int)eBillTyp.Rechnung && b.Freigegeben == true && b.Status == 1 && b.IDSR == "" && b.IDBillStorno.Trim() == ""))).OrderByDescending(p => p.ErstellAm);
                                                System.Collections.Generic.List<PMDS.db.Entities.bills> tBillsToDo = new List<db.Entities.bills>();
                                                foreach (PMDS.db.Entities.bills rBillToStorno in tBillsStornoRech)
                                                {
                                                    tBillsToDo.Add(rBillToStorno);
                                                }
                                                foreach (PMDS.db.Entities.bills rBillToStorno in tBillsToDo)
                                                {
                                                    //PMDS.db.Entities.billHeader rBillHeaderStorno = db.billHeader.Where(b => b.ID == rBillToStorno.IDAbrechnung).First();
                                                    dbCalc dbCalcFoundStorno = null;            //this.doBill.getDBCalc(rBillHeaderStorno.dbCalc);
                                                    dbPMDS dbPMDSUpdate = new dbPMDS();
                                                    Sql SqlUpdate = new Sql();
                                                    dbPMDS.billsRow rBillToStornoDs = SqlUpdate.readBill(rBillToStorno.ID);
                                                    string IDBillGeneratedBack = "";
                                                    this.doBill.doStornoBill(rBillToStornoDs, rBillToStorno.IDAbrechnung, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, ref this.form.editor, rechDatum.Value.Date, ref IDBillGeneratedBack, db, dbCalcFoundStorno);
                                                }
                                            }
                                        }
                                    }
                                    else if (this.typ == ucCalcsSitemap.eTyp.buchhaltung || this.typ == ucCalcsSitemap.eTyp.depotgeld)
                                    {
                                        throw new Exception("ucCalcsSitemap.doAction22: this.typ for eTyp.buchhaltung and eTyp.depotgeld not allowed!");
                                    }
                                }

                                if (!RollungJN)
                                {
                                    this.calculation.freigeben(listIDBills, this.typ == ucCalcsSitemap.eTyp.sr ? true : false, this.form.editor, PMDS.Global.ENV.IDKlinik, null);
                                }
                            }
                            else if (typ == eAction.fsw)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, false);
                            }
                            else if (typ == eAction.fswreset)
                            {
                                PMDS.Global.FSWAbrechnung FSWAbrechnung = new FSWAbrechnung();
                                FSWAbrechnung.GenerateFSWStructure(ENV.IDKlinik, listIDBills, true);
                            }
                            else if (typ == eAction.stornieren)
                            {
                                foreach (string IDBillStr in listIDBills)
                                {
                                    PMDS.db.Entities.bills rBill2 = db.bills.Where(b => b.ID == IDBillStr).First();
                                    if (String.IsNullOrWhiteSpace(rBill2.IDBillStorno))
                                    {
                                        //PMDS.db.Entities.billHeader rBillHeaderToStorno = db.billHeader.Where(b => b.ID == rBill2.IDAbrechnung).First();
                                        //dbCalc dbCalcFoundNew = this.doBill.getDBCalc(rBillHeaderToStorno.dbCalc);
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
                            this.print.printSites(arrBillRows, this.form.editor, QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Rechnung/en"), arrBillRows.Count == 1 ? this : null, (object)rSelRow, typModify,
                                                    Admin.frmMainCalc.editorTmp, IDBillStrTmp, (this.typ == eTyp.depotgeld ? true : false));
                        }
                       
                        else
                            this.form.loadCalcs();
                        if ( txtInfo != "") QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtInfo, QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en"), true);
                    }
                }

                if (sProt.Trim() != "")
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
                PMDS.Calc .Logic .Sql sql = new PMDS.Calc .Logic .Sql ();
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
    
    }
}
