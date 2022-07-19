using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Global;
using PMDS.Calc.Logic;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Windows.Forms;
using PMDS.GUI.BaseControls;
using Infragistics.Win.Misc;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Specialized;
using CrystalDecisions.Shared;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

using System.Linq;

namespace PMDS.UI.Sitemap
{
    public class UIFct
    {
        public PMDS.Calc.Logic.Sql sqlCalcLogic;
        public PMDS.Calc.Logic.dbBill dbBill;
        public ContextMenu timemenu = null;
        public int  anz = 0;
        public PMDS.BusinessLogic.Benutzer usr;
        public System.Collections.ArrayList listID;

        private Infragistics.Win.UIElementButtonStyle _styleButt;

        public UIFct()
        {
            if (ENV.AppRunning)
            {
                this.listID = new System.Collections.ArrayList();
                this.usr = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
                this.sqlCalcLogic = new PMDS.Calc.Logic.Sql();
                this.dbBill = new PMDS.Calc.Logic.dbBill();

                this._styleButt = new Infragistics.Win.UIElementButtonStyle();
                this._styleButt = Infragistics.Win.UIElementButtonStyle.Flat;
            }
            else
            {
                string xy = "";
            }
        }


       public void openProt(ref PMDS.Calc.Logic.dbPMDS.billsRow rDS)
        {
            try
            {
                PMDS.Calc.Logic.dbPMDS db = new PMDS.Calc.Logic.dbPMDS();
                //PMDS.Calc.Logic.dbBill dbBill = new PMDS.Calc.Logic.dbBill();
                       
                clTagInfoLog tgProt = new clTagInfoLog();

                this.sqlCalcLogic.readBillHeader(rDS.IDAbrechnung.ToString(), ref db, PMDS.Global.ENV.IDKlinik);
                //dbCalc = this.dbBill.getDbBill(rDS.dbBill);

                PMDS.Calc.Logic.dbPMDS.billHeaderRow rAbrech = (PMDS.Calc.Logic.dbPMDS.billHeaderRow)db.billHeader.Rows[0];
                tgProt.typ = clTagInfoLog.eNodeTyp.IDKlient;
                tgProt.protDetail = rAbrech.protokoll;
                tgProt.tabLog = rAbrech.dbCalc ;
                tgProt.tabLogFields = rDS.dbBill;

                frmProtokoll frmProtokoll = new frmProtokoll();
                frmProtokoll.calc = false;
                frmProtokoll.ucProtokoll1.start("", true, "", "", false, false);
                frmProtokoll.ucProtokoll1.showProtDetail(tgProt, true);
                frmProtokoll.Show();
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        
        }

       public static void getAllPatientsFromAllKliniken(UltraGrid g, string sBoundGridColumn)
       {
           try
           {
               Infragistics.Win.ValueListsCollection vlc = g.DisplayLayout.ValueLists;
               Infragistics.Win.ValueList vl = null;
                if (vlc.Exists("PAT"))
                    vl = vlc["PAT"];
                else
                {
                    vl = vlc.Add("PAT");

                    PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
                    dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
                    dt = sitemap.loadAllKlientenProdHistAllKliniken(true);
                    foreach (dsPatientStation.PatientRow rPatient in dt.Rows)
                    {
                        vl.ValueListItems.Add(rPatient.ID, rPatient.Name);
                    }

                    UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
                    c.ValueList = vl;
                    c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                }
           }
           catch (Exception ex)
           {
               ENV.HandleException(ex);
           }
       }

       public bool checkUIDateAbrech(QS2.Desktop.ControlManagment.BaseDateTimeEditor AbrechMonat,
                                QS2.Desktop.ControlManagment.BaseDateTimeEditor RechDatum)
        {
            if (AbrechMonat.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Abrechnungsmonat ausgewählt!", "Abrechnen");
                return false;
            }
            if (RechDatum.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Rechnungsdatum ausgewählt!", "Abrechnen");
                return false;
            }
            return true;
        }
        public void alleKeineButtonGrid(UltraButton b, bool alle, UltraGrid g, string colName, bool auswahl)
        {
            if (alle)
            {
                b.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");

                if (!auswahl)
                    this.setSelectedForGroup((UltraGrid)g, true, true);
                else
                    this.setAuswahlForGroup((UltraGrid)g, true, true, colName);
            }
            else
            {
                b.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                if (!auswahl)
                    this.setSelectedForGroup(g, false, true);
                else
                    this.setAuswahlForGroup(g, false, true, colName);
            }
            b.Tag = (bool)alle;
            g.ActiveRow = null;
        }
        public void setSelectedForGroup(UltraGrid g, bool bSelect, bool bUseChildBands)
        {
            foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(g, false))
            {
                if (!this.IsInExpandedGroup(r))
                    continue;
                r.Selected = bSelect;
            //    PMDS.Calc.Logic.dbPMDS.RechnungenRow rSel = (PMDS.Calc.Logic.dbPMDS.RechnungenRow)((System.Data.DataRowView)r.ListObject).Row;
            }
        }
        public void setAuswahlForGroup(UltraGrid g, bool bSelect, bool bUseChildBands, string  colName )
        {
            foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(g, false))
            {
                if (!this.IsInExpandedGroup(r))
                    continue;
                r.Cells[colName].Value = bSelect; ;
                //    PMDS.Calc.Logic.dbPMDS.RechnungenRow rSel = (PMDS.Calc.Logic.dbPMDS.RechnungenRow)((System.Data.DataRowView)r.ListObject).Row;
            }
        }
        public bool IsInExpandedGroup(UltraGridRow r)
        {
            if (r.ParentRow == null)			// keine Gruppierung ==> soll markiert werden
                return true;

            return r.ParentRow.IsExpanded;
        }

        public void openBillTemp(string file, bool pwdJN)
        {
            PMDS.Calc.Logic.print print = new PMDS.Calc.Logic.print();
            print.loadTempStream(file);
            print.openTemp(file, pwdJN);
        }


        public  void initTimeContextMenu()
        {
            timemenu = new ContextMenu();
            DateTime dt = DateTime.Now;

            PMDS.Calc.Logic.calcBase calcBase = new PMDS.Calc.Logic.calcBase();

            DateTime daAktuell = new DateTime(dt.Year, dt.Month, 1);
            MenuItem item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Übernächstes Monat"));
            daAktuell = daAktuell.AddMonths(2);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächstes Monat"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Aktuelles Monat"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddMonths(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vormonat"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddMonths(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 2 Monaten"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddMonths(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 3 Monaten"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddMonths(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 4 Monaten"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddMonths(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 5 Monaten"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddYears(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor einem halbem Jahr"));
            daAktuell = daAktuell.AddMonths(-1);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            dt = DateTime.Now.AddYears(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Jahr"));
            daAktuell = daAktuell.AddMonths(-6);
            item.Tag = new PMDS.Global.timehelper(daAktuell, calcBase.monatsende(daAktuell));

            daAktuell = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dtBis = calcBase.monatsende(daAktuell);
            DateTime dtVon = daAktuell.AddYears(-1);
            dtVon = new DateTime(dtVon.Year, dtVon.Month, 1);

            dt = DateTime.Now.AddYears(-1);
            item = timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das gesamte letzte Jahr"));
            daAktuell = daAktuell.AddMonths(-6);
            item.Tag = new PMDS.Global.timehelper(dtVon, dtBis);
          
        }


        public string setUIAnzahl(string noFound)
        {
            if (this.anz > 0)
                return QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.anz.ToString();
            else
                return noFound ;
        }

        public bool question2(string txt, string title)
        {
            if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, title, MessageBoxButtons.YesNo, true) == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public DialogResult doAction22(eAction typ, string txtQuestion, string txtHeader, string txtInfo, UltraGrid grid,
                          ref QS2.Desktop.ControlManagment.BaseLabel lblCount, ref List<UltraGridRow> arrSelected, bool  msgBox)
        {
            try
            {
                foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, true  ))
                {
                    if (!this.IsInExpandedGroup(r))
                        continue;
                    arrSelected.Add(r);
                    //if (r.Selected) { arrSelected.Add(r); }
                }

                if (arrSelected.Count > 0)
                {
                    DialogResult res = DialogResult.Yes;
                    if (txtQuestion != "")
                        res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtQuestion, txtHeader, MessageBoxButtons.YesNo, true);
                    return res;
                }
                else
                {
                    if (msgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!");
                    return DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return DialogResult.No;
            }
        }


        public void addID(System.Guid IDToAdd)
        {
            bool bFound = false;
            int anz = 0;
            foreach (string id in this.listID)
            {
                anz += 1;
                if (id.Equals(IDToAdd))
                {
                    bFound = true;
                    return;
                }
            }
            if (!bFound)
            {
                this.listID.Add(IDToAdd.ToString());
                //this.form.loadCalcs();
            }
        }
        public void removeID(System.Guid IDToAdd)
        {
            foreach (string id in this.listID)
            {
                if (id == IDToAdd.ToString())
                {
                    this.listID.Remove(id);
                    //this.form.loadCalcs();
                    return;
                }
            }
        }
        public void clearAllIDs()
        {
            this.listID.Clear();
        }

        public bool validAuswahl(bool info, System.Collections.ArrayList list)
        {
            int anz = 0;
            foreach (string IDklient in list) anz += 1;
            if (anz == 0)
            {
                if (info) { QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klienten ausgewählt!", "Abrechnung starten"); }
                return false;
            }
            return true;
        }

        public System.Collections.Generic.List<string> loadAllKlientenProdHistLst(bool all, System.Guid IDKlinik)
        {
            dsPatientStation.PatientDataTable tRet = new dsPatientStation.PatientDataTable();
            System.Collections.Generic.List<string> lstKlienten = new System.Collections.Generic.List<string>();
            dsPatientStation.PatientDataTable tKl = this.loadAllKlientenProdHist(all, IDKlinik, tRet);
            foreach (dsPatientStation.PatientRow rAct in tKl.Rows)
                       lstKlienten.Add(rAct.ID.ToString());
            return lstKlienten;
        }
        public dsPatientStation.PatientDataTable loadAllKlientenProdHist(bool all, System.Guid IDKlinik, dsPatientStation.PatientDataTable tRet, bool CboNoKlinikName = false)
        {
             dsKlinik.KlinikDataTable tAllKliniken = new  dsKlinik.KlinikDataTable();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(IDKlinik, true);

            if (!tRet.Columns.Contains("Klinik"))
            {
                tRet.Columns.Add("Klinik", typeof(string));
            }

            dsPatientStation.PatientDataTable tActuell = PMDS.GUI.GuiUtil.GetKlientenforCurrentSelectionAbrech(false, IDKlinik);
            if (all)
            {
                dsPatientStation.PatientDataTable tHistorie = PMDS.GUI.GuiUtil.GetKlientenforCurrentSelectionAbrech(true, IDKlinik);
                foreach (dsPatientStation.PatientRow rHist in tHistorie.Rows)
                {
                    bool found = false;
                    foreach (dsPatientStation.PatientRow rAct in tActuell.Rows)
                        if (rHist.ID.ToString() == rAct.ID.ToString()) found = true;

                    if (!found)
                    {
                        dsPatientStation.PatientRow rNew = (dsPatientStation.PatientRow)tActuell.NewRow();
                        rNew.ItemArray = rHist.ItemArray;
                        //rNew.ID  = rHist.ID;
                        //rNew.Name = rHist.Name;
                        tActuell.Rows.Add(rNew);
                    }
                }
            }
            dsPatientStation.PatientRow[] arrPat = (dsPatientStation.PatientRow[])tActuell.Select("", "Name asc");
            foreach (dsPatientStation.PatientRow rPat in arrPat)
            {
                dsPatientStation.PatientRow rNew = (dsPatientStation.PatientRow)tRet.NewRow();
                rNew.ItemArray = rPat.ItemArray;
                //rNew["IDKlinik"] = rKlinik.ID;
                rNew["Klinik"] = rKlinik.Bezeichnung.Trim();
                if (CboNoKlinikName)
                {
                    rNew.Name =  rNew.Name.Trim();
                }
                else
                {
                    rNew.Name = rKlinik.Bezeichnung.Trim() + " - " + rNew.Name.Trim();
                }
                tRet.Rows.Add(rNew);
            }
            return tRet;
        }
        public dsPatientStation.PatientDataTable loadAllKlientenProdHistAllKliniken(bool all)
        {
            dsPatientStation.PatientDataTable tRet = new dsPatientStation.PatientDataTable();

            dsKlinik.KlinikDataTable tAllKliniken = new dsKlinik.KlinikDataTable();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            DBKlinik1.loadAllKliniken(tAllKliniken);          

            foreach (dsKlinik.KlinikRow rKlinik in tAllKliniken.Rows)
            {
                this.loadAllKlientenProdHist(all, rKlinik.ID, tRet);
            }
            return tRet; 
        }
        public PMDS.Calc.Logic.dbPMDS.billsRow CurActiveRow(bool info, ref UltraGrid grid)
        {
            PMDS.Calc.Logic.dbPMDS.billsRow  rSel = (PMDS.Calc.Logic.dbPMDS.billsRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(grid);
            if (rSel == null)
            {
                if (info) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abrechnung ausgewählt!", "Auswahl Abrechnung");
            }
            return rSel;
        }


        public void loadKost(Infragistics .Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor  cbo, 
                                System.Guid IDKlinik)
        {
            valList.ValueListItems.Clear();
            cbo.Items.Clear();

            PMDS.DB.Global.DBKostentraeger db = new PMDS.DB.Global.DBKostentraeger();
            PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerDataTable dt;

            valList.ValueListItems.Add("" , "");
            Infragistics.Win.ValueListItem itm = cbo.Items.Add("", "");
            
            string txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient ist Kostenträger");
            Infragistics.Win.ValueListItem valItmKlKost = valList.ValueListItems.Add(PMDS.Calc.Logic.kostenträger.IDKostKlient, txt);
            valItmKlKost.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True;
            //valItmKlKost.Appearance.ForeColor  = System.Drawing.Color.RoyalBlue;
            Infragistics.Win.ValueListItem itmKlKost = cbo.Items.Add(PMDS.Calc.Logic.kostenträger.IDKostKlient, txt);
            itmKlKost.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True;
            //itmKlKost.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;

            dt = db.GetKostentraeger(true, true, true, false, System.Guid.Empty);
            foreach (PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow r in dt.Rows)
            {
                bool KlinikOK = false;
                if (r.IsIDKlinikNull())
                {
                    KlinikOK = true;
                }
                else
                {
                    if (r.IDKlinik.Equals(IDKlinik))
                    {
                        KlinikOK = true;
                    }
                }
                if (KlinikOK)
                {
                    string typKost = "";
                    if (r.TransferleistungJN)
                        typKost = "  [T]";
                    //else if (r.PatientbezogenJN)
                    //    typKost = "  [K]";
                    //else if (!r.TransferleistungJN && !r.PatientbezogenJN)
                    //    typKost = "  [A]";

                    string nameKost = r.Name + (r.Vorname == "" ? "" : " " + r.Vorname) + (r.Anrede == "" ? "" : " ," + r.Anrede) + typKost;

                    valList.ValueListItems.Add(r.ID.ToString().ToLower(), nameKost);
                    Infragistics.Win.ValueListItem itmAct = cbo.Items.Add(r.ID.ToString().ToLower(), nameKost); 
                }
            }
            cbo.SelectedItem = itm;
        }

        public void loadKlienten(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor  cbo, System.Guid IDKlinik, bool CboNoKlinikName)
        {
            valList.ValueListItems.Clear();
            cbo.Items.Clear();

            PMDS.DB.DBPatient db = new PMDS.DB.DBPatient();

            valList.ValueListItems.Add("", "");
            Infragistics.Win.ValueListItem itm = cbo.Items.Add("", "");

            //System.Guid[] arrGuid = null;
            //dt = db.GetPatienten("", false, arrGuid, System.Guid.Empty, new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));

            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
            dt = this.loadAllKlientenProdHist(true, IDKlinik, dt, CboNoKlinikName);
            foreach (dsPatientStation.PatientRow r in dt.Rows)
            {
                valList.ValueListItems.Add(r.ID.ToString().ToLower(), r.Name);
                cbo.Items.Add(r.ID.ToString().ToLower(), r.Name);
            }
            cbo.SelectedItem = itm;
        }
    
        public void loadValueListYear(Infragistics.Win.ValueList valList )
        {
            valList.ValueListItems.Clear();
            for (int i = 2009; i <= 2100; i++)
            {
                valList.ValueListItems.Add(i, i.ToString ());
            }
        }

        public void aktivateButton(List<cButt> buttons, int aktiv )
        {
            foreach (cButt itm in buttons)
            {
                if (itm.nr == aktiv )
                    itm.on = true;
                else
                    itm.on = false;
            }
            this.setUIButtons(buttons);
        }

        public void setUIButtons (List<cButt >  buttons )
        {
            foreach (cButt itm in buttons)
            {
                PMDS.Global.UIGlobal.setUIButton(itm.butt, itm.on);
            }
        }

        public void setStatusbar (ref Infragistics.Win.UltraWinStatusBar.UltraStatusBar statBar, bool  showDB  )
        {
            statBar.Panels[0].Text = ENV.String("GUI.STATUS_USER", this.usr.FullName);
            //statBar.Panels[1].Text = ENV.String("GUI.STATUS_ABT", PMDS.GUI.GuiUtil.Abteilung());
            if (showDB)
            {
                //this.lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                statBar.Panels[1].Text = PMDS.Global.ENV.String("GUI.STATUS_DB", PMDS.Global.ENV.getPmdsDB);
            }
        }

        public void printCR( List<cParCR> par , string reportName ,  System.Data.DataSet  db )
        {
            try
            {
                ReportDocument report = new ReportDocument();
                string sFile = System.IO.Path.Combine(ENV.ReportPath, reportName);
                report.Load(sFile);

                //report.SetDataSource(db);c
                PMDS.Print.CR.ReportManager.setDataSource(db, sFile, report);

                foreach (cParCR itm in par)
                {
                    report.SetParameterValue(itm.id, itm.value );
                }

                PMDS.Print.CR.frmPrintPreview frm = new PMDS.Print.CR.frmPrintPreview(report);
                frm.Show();
                return;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        public  void evBeforeRowRegionScrollAuto(ref object sender, ref BeforeRowRegionScrollEventArgs e, UltraGrid grid )
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    e.Cancel = true;
        }
        public bool evClickOK(ref object sender, ref EventArgs e, ref UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evDoubleClickOK(ref object sender, ref EventArgs e, UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;
            
            return false;
        }
        public bool evClickOKTree(ref object sender, ref EventArgs e, ref  Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.UIElement.LastElementEntered != null)

                if (tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))
                    //tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement) &&
                    return true;

            return false;
        }
        public bool evClickOKTreeMouse(ref object sender, ref MouseEventArgs e, ref  Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.UIElement.LastElementEntered != null)

                if (tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))
                    //tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement) &&
                    return true;

            return false;
        }
        public void fillEnumBillTyp(Infragistics.Win.ValueList valueList, bool all)
        {
            Infragistics.Win.ValueListItem itm = null;

            if (all)
            {
                valueList.ValueListItems.Clear();
                foreach (int val in Enum.GetValues(typeof(PMDS.Calc.Logic.eBillTyp)))
                {
                    valueList.ValueListItems.Add(val, Enum.GetName(typeof(PMDS.Calc.Logic.eBillTyp), val));
                }
            }
            else
            {
                valueList.ValueListItems.Clear();
                
                itm = valueList.ValueListItems.Add((int)PMDS.Calc.Logic.eBillTyp.Rechnung, PMDS.Calc.Logic.eBillTyp.Rechnung.ToString());          
                itm = valueList.ValueListItems.Add((int)PMDS.Calc.Logic.eBillTyp.Beilage, PMDS.Calc.Logic.eBillTyp.Beilage.ToString());
                itm = valueList.ValueListItems.Add((int)PMDS.Calc.Logic.eBillTyp.Zahlungsbestätigung, PMDS.Calc.Logic.eBillTyp.Zahlungsbestätigung.ToString());
            }
        }

        public void fillEnumDruckTyp(Infragistics.Win.ValueList valueList)
        {
            Infragistics.Win.ValueListItem itm = null;
            valueList.ValueListItems.Clear();
            itm = valueList.ValueListItems.Add((int)RechnungsdruckTyp.NurZahler, generic.GetEnumDescription(RechnungsdruckTyp.NurZahler));
            itm = valueList.ValueListItems.Add((int)RechnungsdruckTyp.KeinRechnungsdruck, generic.GetEnumDescription(RechnungsdruckTyp.KeinRechnungsdruck));
            itm = valueList.ValueListItems.Add((int)RechnungsdruckTyp.NurKopieKontakte, generic.GetEnumDescription(RechnungsdruckTyp.NurKopieKontakte));
            itm = valueList.ValueListItems.Add((int)RechnungsdruckTyp.ZahlerUndKopieKontakte, generic.GetEnumDescription(RechnungsdruckTyp.ZahlerUndKopieKontakte));
        }

        public void fillIDKostentraegerSub(Infragistics.Win.ValueList valueList)
        {
            Infragistics.Win.ValueListItem itm = null;
            valueList.ValueListItems.Clear();

            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                var KostentraegerSub = (from k in db.Kostentraeger
                                        //where k.ID == IDKostentraegerSub
                                        select new { k.ID, k.Name, k.Vorname, k.FIBUKonto }).FirstOrDefault();

                if (KostentraegerSub != null)
                {
                    itm = valueList.ValueListItems.Add(KostentraegerSub.ID, (KostentraegerSub.Name + " " + KostentraegerSub.Vorname).Trim() + " (" + KostentraegerSub.FIBUKonto + ")");
                }
            }
        }


        public void fillEnumBillTyp(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, bool all, bool srJN)
        {
            Infragistics.Win.ValueListItem itm = null;

            if (all)
            {
                cbo.Items.Clear();
                foreach (int val in Enum.GetValues(typeof(PMDS.Calc.Logic.eBillTyp)))
                {
                    if ((PMDS.Calc.Logic.eBillTyp)val != eBillTyp.Depotgeld && (PMDS.Calc.Logic.eBillTyp)val != eBillTyp.Sammelrechnung && (PMDS.Calc.Logic.eBillTyp)val != eBillTyp.KeineRechnung)
                        cbo.Items.Add(val, Enum.GetName(typeof(PMDS.Calc.Logic.eBillTyp), val));
                    if ((srJN && (PMDS.Calc.Logic.eBillTyp)val == eBillTyp.Sammelrechnung))
                        cbo.Items.Add(val, Enum.GetName(typeof(PMDS.Calc.Logic.eBillTyp), val));
                }
            }
            else
            {
                cbo.Items.Clear();
                itm = cbo.Items.Add((int)PMDS.Calc.Logic.eBillTyp.Rechnung, PMDS.Calc.Logic.eBillTyp.Rechnung.ToString());
                itm = cbo.Items.Add((int)PMDS.Calc.Logic.eBillTyp.Beilage, PMDS.Calc.Logic.eBillTyp.Beilage.ToString());
                itm = cbo.Items.Add((int)PMDS.Calc.Logic.eBillTyp.Zahlungsbestätigung, PMDS.Calc.Logic.eBillTyp.Zahlungsbestätigung.ToString());
            }
        }

        public void fillEnumKonto(Infragistics.Win.ValueList valueList)
        {
            valueList.ValueListItems.Clear();
            foreach (int val in Enum.GetValues(typeof(PMDS.Calc.Logic.eKonto)))
            {
                string str = Enum.GetName(typeof(PMDS.Calc.Logic.eKonto), val);
                valueList.ValueListItems.Add(str, str);
            }
        }
        public void fillEnumKonto(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            cbo.Items.Clear();
            foreach (int val in Enum.GetValues(typeof(PMDS.Calc.Logic.eKonto)))
            {
                string str = Enum.GetName(typeof(PMDS.Calc.Logic.eKonto), val);
                cbo.Items.Add(str, str);
            }
        }


        public void clearAllFiltersGrid(UltraGrid grid)
        {
            foreach (UltraGridBand band in grid.DisplayLayout.Bands)
            {
                foreach (ColumnFilter colFilter in band.ColumnFilters)
                {
                    foreach (FilterCondition cond in colFilter.FilterConditions)
                    {
                        colFilter.ClearFilterConditions();
                    }
                }
            }
        }
        public void activateRow(ref  UltraGrid grid, string  col, string  idToActivate)
        {
             foreach (UltraGridRow rSearch in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, false))
            {
                if (rSearch.IsGroupByRow) continue;
                if ((string)rSearch.Cells[col].Value == idToActivate)
                {
                    grid.ActiveRow = rSearch;
                    return;
                }
            }
        }
        public void setFilterGrid(List<string> filterString, UltraGrid grid, string column, FilterLogicalOperator operat, FilterComparisionOperator compare)
        {
                this.clearAllFiltersGrid(grid);
                foreach (UltraGridBand band in grid.DisplayLayout.Bands)
                {
                    band.ColumnFilters[column].LogicalOperator = operat;
                    foreach (string filter in filterString)
                    {
                        band.ColumnFilters[column].FilterConditions.Add( FilterComparisionOperator.Contains, filter);
                    }
                }
                grid.Refresh();
        }

        public bool checkCombo(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, bool pflicht, bool msgBox )
        {
            if (cbo.Value == null && pflicht)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Auswahl erforderlich!", "Auswahl Suche", MessageBoxButtons.OK);
                cbo.Focus();
                return false;
            }
            bool found = false;
            foreach (Infragistics.Win.ValueListItem itm in cbo.Items)
            {
                if (!found)
                    if (cbo.Value.ToString() == itm.DataValue.ToString())
                        found = true;
            }

            if (found)
                return true;
            else
            {
                if (pflicht && !found && msgBox)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Auswahl erforderlich", "", MessageBoxButtons.OK);
                    cbo.Focus();
                    return false;
                }
                else if (pflicht && !found && !msgBox)
                    return false;
            }
            return false;
        }

        public void refreshAuswahlGrp(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, string Group)
        {
            try
            {
                cbo.Items.Clear();
                foreach ( dsAuswahlGruppe.AuswahlListeRow r in new PMDS.BusinessLogic.AuswahlGruppe(Group).AuswahlListe)
                    cbo.Items.Add(r.Bezeichnung.Trim(), r.Bezeichnung.Trim());
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
            }
        }
        public void openFormAuswahlGrp(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, string grp)
        {
            PMDS.GUI.frmAuswahl frm = new PMDS.GUI.frmAuswahl(grp);
            frm.ShowDialog();
            this.refreshAuswahlGrp(cbo, grp);
        }
        public void infoRuntimStatusbar(ref Infragistics.Win.UltraWinStatusBar.UltraStatusBar statusBar)
        {
            try
            {
                statusBar.Panels["Config"].ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Aktuelle Config-Datei: ") + PMDS.Global.ENV.sConfigFile + "\r\n";
                statusBar.Panels["Config"].ToolTipText += QS2.Desktop.ControlManagment.ControlManagment.getRes("Installationsordner: ") + Application.StartupPath + "\r\n";
                statusBar.Panels["Config"].ToolTipText += QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechner: ") + Environment.MachineName + "\r\n";
                statusBar.Panels["Config"].ToolTipText += PMDS.Global.ENV.getPmdsVersion() + "\r\n";
                statusBar.Panels["Config"].ToolTipText += PMDS.Global.ENV.getPmdsDBVersion() + "\r\n";
                statusBar.Panels["Config"].ToolTipText += PMDS.Global.ENV.getPmdsDB;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
        }



        public void doRuntimStatusbar(string key)
        {
            try
            {
                if (PMDS.Global.ENV.adminSecure)
                {
                    if (key == "Config")
                    {
                        PMDS.GUI.VB.clFolder clFold = new PMDS.GUI.VB.clFolder();
                        clFold.runShell("notepad.exe " + PMDS.Global.ENV.sConfigFile + "");
                    }
                    else if (key == "Laden")
                        this.loadConfig();
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public void loadConfig()
        {
            try
            {
                PMDS.Global.ENV.Init(true);
                this.initCalc();
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
        }
        public void initCalc()
        {
            try
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

                calculation calc = new calculation();
                calc.Init(RBU.DataBase.CONNECTION, PMDS.Global.ENV.KuerzungGrundleistungLetzterTag,
                                                PMDS.Global.ENV.ReportPath,
                                                PMDS.Global.ENV.bookingJN, 
                                                PMDS.Global.ENV.RechnungKopfzeileEin,
                                                PMDS.Global.ENV.RechFloskel, 
                                                PMDS.Global.ENV.ZAHLUNG_TAGE,
                                                this.usr.FullName, 
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
                                                PMDS.Global.ENV.ZahlKondBankeinzug, PMDS.Global.ENV.ZahlKondErlagschein, PMDS.Global.ENV.ZahlKondÜberweisung, PMDS.Global.ENV.ZahlKondBar, 
                                                PMDS.Global.ENV.ZahlKondFSW, 
                                                PMDS.Global.ENV.AbwesenheitenAnzeigen, 
                                                ENV.RechTitelDepotGeld,
                                                PMDS.Global.ENV.RechnungBankdaten);
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
        }
    }

    public class cButt
    {
        public UltraButton butt;
        public bool on = false;
        public int nr = -1;
    }
    public class cParCR
    {
        public string id = "";
        public object value = new object() ;
    }
}