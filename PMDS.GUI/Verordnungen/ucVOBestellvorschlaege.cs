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
using System.Data.OleDb;
using PMDS.GUI.VB;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOBestellvorschlaege : UserControl
    {
      
        public frmVOMain mainWindowVerwaltung = null;
        public bool _Einzelansicht = false;

        public ucVOBestellvorschlaegeDetail.eTypeUI _TypeUI = new ucVOBestellvorschlaegeDetail.eTypeUI();

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();

        public string colSelect = "Select";
        public string colKlient = "Klient";
        public string colMedikament = "Medikament";
        public string colMedikamentGeliefert = "MedikamentGeliefert";
        public string colDatumNächsterAnspruch = "DatumNächsterAnspruch";
        public string colTyp = "Typ";
        public string colLieferantBeschreibung = "LieferantBeschreibung";
        public string colAbteilung = "Abteilung";
        public string colBereich = "Bereich";
        public string colVO_Hinweis = "VO_Hinweis";
        public string colVO_BestaetigtVon = "VO_BestaetigtVon";
        




        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;
        public PMDS.GUI.VB.PMDSBusinessVB bVB = new VB.PMDSBusinessVB();

        public contSelectSelList contSelectSelListTyp = new contSelectSelList();
        public List<PMDS.db.Entities.AuswahlListe> lstLieferanten = null;








        public ucVOBestellvorschlaege()
        {
            InitializeComponent();
        }

        private void ucVOBestelldaten_Load(object sender, EventArgs e)
        {

        }

        public void initControl(ucVOBestellvorschlaegeDetail.eTypeUI TypeUI, bool Einzelansicht)
        {
            try
            {
                this._Einzelansicht = Einzelansicht;
                this._TypeUI = TypeUI;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.gridVOErfBestell.UpdateMode = UpdateMode.OnCellChangeOrLostFocus;
                this.gridVOErfBestell.UpdateData();

                this.sqlVO1.initControl();
                this.sqlManange1.initControl();

                if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                {
                    this.gridVOErfBestell.Name = "gridBestellvorschläge";
                    this.btnDel.Visible = false;
                    this.btnSave.Visible = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.colMedikamentGeliefert.Trim()].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.IDMedikamentGeliefertColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.DatumLieferungColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.MengeLieferungColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.EinheitLieferungColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.StatusColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.AnmerkungColumn.ColumnName].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.BemerkungLieferungColumn.ColumnName].Hidden = true;
                    this.lblStatus.Visible = false;
                    this.cboStatus.Visible = false;
                    this.lieferungBestätigenToolStripMenuItem.Visible = false;
                    this.toolStripMenuItemSpace01.Visible = false;
                    this.btnPrint.Visible = false;
                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                {
                    this.gridVOErfBestell.Name = "gridLieferungen";
                    this.btnDel.Visible = true;
                    this.btnSave.Visible = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.colDatumNächsterAnspruch.Trim()].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.colMedikamentGeliefert.Trim()].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.IDMedikamentGeliefertColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.DatumLieferungColumn.ColumnName].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.MengeLieferungColumn.ColumnName].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.EinheitLieferungColumn.ColumnName].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.StatusColumn.ColumnName].Hidden = false;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.AnmerkungColumn.ColumnName].Hidden = true;
                    this.gridVOErfBestell.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestellpostitionen.BemerkungLieferungColumn.ColumnName].Hidden = false;
                    this.lblStatus.Visible = true;
                    this.cboStatus.Visible = true;
                    this.lieferungBestätigenToolStripMenuItem.Visible = true;
                    this.toolStripMenuItemSpace01.Visible = true;
                    this.btnPrint.Visible = true;
                }

                this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                bool isTxtTemplate = false;
                this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients, false, isTxtTemplate, this.dropDownPatienten);
                this.uPopUpContPatienten.PopupControl = this.contSelectPatientenBenutzer1;
                this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContPatienten;
                this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = true;
                this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                if (this._Einzelansicht)
                {
                    if (ENV.CurrentIDPatient != System.Guid.Empty)
                    {
                        bool IDFoundInTree3 = false;
                        this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(ENV.CurrentIDPatient, ref IDFoundInTree3);
                        this.contSelectPatientenBenutzer1.setLabelCount2();
                    }
                }

                this.SelListChanged("", null, null);

                //this.contSelectSelListTyp.MainPlanSearch = this;
                this.contSelectSelListTyp.initControl("VOT", true, false, this.dropDownTyp, true, "Typ", "Typ wählen");
                this.uPopupContTyp.PopupControl = this.contSelectSelListTyp;
                this.dropDownTyp.PopupItem = this.uPopupContTyp;
                this.contSelectSelListTyp.popupContMainSearch = this.uPopupContTyp;

                PMDSBusinessUI.dSelListChanged += new PMDSBusinessUI.SelListChanged(this.SelListChanged);

                this.clearUI();
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.initControl: " + ex.ToString());
            }
        }

        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.b2.loadSelList("VOT", null, this.gridVOErfBestell.DisplayLayout.ValueLists["Typ"], null, ref lstEmpty);

                this.lstLieferanten = new List<AuswahlListe>();
                this.b2.loadSelList("LFT", null, this.gridVOErfBestell.DisplayLayout.ValueLists["Lieferant"], null, ref this.lstLieferanten);
                this.b2.loadSelList("BSS", this.cboStatus, this.gridVOErfBestell.DisplayLayout.ValueLists["Status"], null, ref lstEmpty);
                this.b2.loadSelList("MEH", null, this.gridVOErfBestell.DisplayLayout.ValueLists["Einheit"], null, ref lstEmpty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.SelListChanged: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.udteVerordnetAb.Value = DateTime.Now.Date.AddDays(-1);
                this.udteVerordnetBis.Value = DateTime.Now.Date.AddDays(2);

                this.contSelectSelListTyp.setSelectionOnOff(false);
                this.contSelectPatientenBenutzer1.loadDataAbtBereiche();

                this.dsVO1.Clear();
                this.gridVOErfBestell.Refresh();

                this.lblFound.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.clearUI: " + ex.ToString());
            }
        }
        public void search()
        {
            try
            {
                this.dsVO1.Clear();
                DateTime dNow = DateTime.Now;
                this.lblFound.Text = "";

                Nullable<DateTime> dFrom = null;
                if (this.udteVerordnetAb.Value != null)
                {
                    dFrom = this.udteVerordnetAb.DateTime.Date;
                }

                Nullable<DateTime> dTo = null;
                if (this.udteVerordnetBis.Value != null)
                {
                    dTo = this.udteVerordnetBis.DateTime.Date;
                }

                System.Collections.Generic.List<Guid> lstSelectedTyp = new List<Guid>();
                this.contSelectSelListTyp.getSelectedIDs(ref lstSelectedTyp);

                Nullable<Guid> gStatus = null;
                if (this.cboStatus.Value != null)
                {
                    if (this.cboStatus.Value.GetType() == typeof(Guid))
                    {
                        gStatus = (Guid)this.cboStatus.Value;
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status: Falsche Eingabe!", "", MessageBoxButtons.OK);
                        return;
                    }

                }
                List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();
                string sWherePatients = "";
                if (lstPatients.Count > 0)
                {
                    string sWherePatientsTmp = "";
                    foreach (Guid IDPatient in lstPatients)
                    {
                        sWherePatientsTmp += (sWherePatientsTmp.Trim() == "" ? "" : " or ") + " Aufenthalt.IDPatient='" + IDPatient.ToString() + "' ";
                    }
                    if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                    {
                        sWherePatients = " VO_Bestelldaten.IDVerordnung IN (Select VO.ID from VO where VO.IDAufenthalt IN (Select Aufenthalt.ID from Aufenthalt where Entlassungszeitpunkt is null and (" + sWherePatientsTmp + ")))";
                    }
                    else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                    {
                        sWherePatients = " VO_Bestellpostitionen.IDBestelldaten_VO IN (Select VO_Bestelldaten.ID from VO_Bestelldaten, VO where VO_Bestelldaten.IDVerordnung=VO.ID and VO.ID IN (Select VO.ID from VO where VO.IDAufenthalt IN (Select Aufenthalt.ID from Aufenthalt where Entlassungszeitpunkt is null and (" + sWherePatientsTmp + "))))";
                    }
                }

                if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                {
                    this.sqlVO1.getVO_Bestellpostitionen(System.Guid.NewGuid(), sqlVO.eSelVO_Bestellpostitionen.ID, ref this.dsVO1, "", null, null, null, null, ref lstSelectedTyp);
                    this.sqlVO1.getVO_Bestelldaten(null, sqlVO.eSelVO_Bestelldaten.Bestellvorschläge, ref this.dsVO1, sWherePatients, dFrom, dTo, null, "", false, null, ref lstSelectedTyp);

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        db.Configuration.LazyLoadingEnabled = false;
                        PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                        foreach (dsVO.VO_BestelldatenRow rVO_BestelldatenAct in this.dsVO1.VO_Bestelldaten)
                        {
                            bool AddBestellvorschlag = true;
                            if (rVO_BestelldatenAct.IsGueltigBisNull())
                            {
                                AddBestellvorschlag = true;
                            }
                            else
                            {
                                if ((!rVO_BestelldatenAct.IsGueltigBisNull() && !rVO_BestelldatenAct.IsDatumNaechsterAnspruchNull()) && rVO_BestelldatenAct.DatumNaechsterAnspruch.Date > rVO_BestelldatenAct.GueltigBis.Date)
                                {
                                    AddBestellvorschlag = false;
                                }
                            }
                            
                            var rAufenthalt = (from vo_bd in db.VO_Bestelldaten
                                       join vo in db.VO on vo_bd.IDVerordnung equals vo.ID
                                       join a in db.Aufenthalt on vo.IDAufenthalt equals a.ID
                                       where vo_bd.IDVerordnung == rVO_BestelldatenAct.IDVerordnung
                                       select new
                                           {
                                               IDAufenthalt = a.ID,
                                               Entlassungszeitpunkt = a.Entlassungszeitpunkt
                                           }).First();
                            
                            if (AddBestellvorschlag && rAufenthalt.Entlassungszeitpunkt == null)
                            {
                                var tVO_Bestellpostitionen = (from bp in db.VO_Bestellpostitionen
                                                               where bp.IDBestelldaten_VO == rVO_BestelldatenAct.ID && bp.DatumBestellungPlan == rVO_BestelldatenAct.DatumNaechsterAnspruch
                                                                    select new
                                                                   {
                                                                        IDAbteilung = bp.ID,
                                                                        DatumBestellung = bp.DatumBestellung
                                                                    });

                                if (tVO_Bestellpostitionen.Count() == 0)
                                {
                                    dsVO.VO_BestellpostitionenRow rNewVO_Bestellpostitionen = this.sqlVO1.getNewRowVO_Bestellpostitionen(ref this.dsVO1);
                                    rNewVO_Bestellpostitionen.ID = System.Guid.NewGuid();
                                    rNewVO_Bestellpostitionen.IDBestelldaten_VO = rVO_BestelldatenAct.ID;
                                    rNewVO_Bestellpostitionen.IDMedikament = rVO_BestelldatenAct.IDMedikament;
                                    rNewVO_Bestellpostitionen.IDMedikamentGeliefert = rVO_BestelldatenAct.IDMedikament;
                                    rNewVO_Bestellpostitionen.DatumBestellung = rVO_BestelldatenAct.DatumNaechsterAnspruch.Date;
                                    rNewVO_Bestellpostitionen.MengeBestellung = rVO_BestelldatenAct.Menge;
                                    rNewVO_Bestellpostitionen.EinheitBestellung = rVO_BestelldatenAct.Einheit;
                                    rNewVO_Bestellpostitionen.Anmerkung = rVO_BestelldatenAct.Anmerkung;
                                    rNewVO_Bestellpostitionen.Status = PMDSBusiness.IDVOStatusBestellt;
                                    if (!rVO_BestelldatenAct.IsLieferantNull())
                                    {
                                        rNewVO_Bestellpostitionen.Lieferant = rVO_BestelldatenAct.Lieferant;
                                    }
                                    else
                                    {
                                        //rNewVO_Bestellpostitionen.SetLieferantNull();              //lthxy
                                    }
                                    rNewVO_Bestellpostitionen.HinweisLieferant = rVO_BestelldatenAct.HinweisLieferant;

                                    rNewVO_Bestellpostitionen.DatumErstellt = dNow;
                                    rNewVO_Bestellpostitionen.DatumGeaendert = dNow;
                                    rNewVO_Bestellpostitionen.IDBenutzerErstellt = rBenutzer.ID;
                                    rNewVO_Bestellpostitionen.IDBenutzerGeaendert = rBenutzer.ID;
                                    rNewVO_Bestellpostitionen.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                                    rNewVO_Bestellpostitionen.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();
                                }
                            }
                        }
                        this.gridVOErfBestell.Refresh();

                        string sWhereIDVO = "";
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        OleDbCommand cmd = new OleDbCommand();
                        Global.db.ERSystem.sqlVO sqlVOHelp = new sqlVO();
                        sqlVOHelp.initControl();
                        dsVO dsVOHelp = new dsVO();
                        int iInserted = 0;
                        bool doValidateBestellvorschläge = false;
                        bool bError = false;
                        string ErrorTxt = "";
                        dsVO dsVoPrint = new dsVO();
                        foreach (UltraGridRow rGrid in this.gridVOErfBestell.Rows)
                        {
                            if (rGrid.IsGroupByRow)
                            {
                                this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                            }
                            else
                            {
                                this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                            }
                        }
                    }

                    this.gridVOErfBestell.Refresh();
                    this.gridVOErfBestell.UpdateData();
                    this.gridVOErfBestell.Rows.ExpandAll(true);
                    this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsVO1.VO_Bestellpostitionen.Rows.Count.ToString();

                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Clear();
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colKlient.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colMedikament.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colTyp.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO_Bestellpostitionen.DatumBestellungColumn.ColumnName, false);
                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                {
                    this.sqlVO1.getVO_Bestellpostitionen(null, sqlVO.eSelVO_Bestellpostitionen.Search, ref this.dsVO1, sWherePatients, dFrom, dTo, null, gStatus, ref lstSelectedTyp);

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                        string sWhereIDVO = "";
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        OleDbCommand cmd = new OleDbCommand();
                        Global.db.ERSystem.sqlVO sqlVOHelp = new sqlVO();
                        dsVO dsVOHelp = new dsVO();
                        int iInserted = 0;
                        bool doValidateBestellvorschläge = false;
                        bool bError = false;
                        string ErrorTxt = "";
                        dsVO dsVoPrint = new dsVO();
                        foreach (UltraGridRow rGrid in this.gridVOErfBestell.Rows)
                        {
                            if (rGrid.IsGroupByRow)
                            {
                                this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                            }
                            else
                            {
                                this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                            }
                        }
                    }
                    this.gridVOErfBestell.Refresh();
                    this.gridVOErfBestell.UpdateData();
                    this.gridVOErfBestell.Rows.ExpandAll(true);
                    this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsVO1.VO_Bestellpostitionen.Rows.Count.ToString();

                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Clear();
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colKlient.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colMedikament.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.colTyp.Trim(), true);
                    //this.gridVOErfBestell.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO_Bestellpostitionen.DatumBestellungColumn.ColumnName, false);
                }
                else
                {
                    throw new Exception("ucVOBestellvorschlaege.search: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.search: " + ex.ToString());
            }
        }
        public void showGrid_rek(UltraGridRow rFoundInGridParent, ref DataTable dt, ref string sWhereIDVO, bool IsFirstBand, PMDS.db.Entities.ERModellPMDSEntities db, 
                                DateTime dNow, Benutzer rBenutzer, ref OleDbDataAdapter da, ref OleDbCommand cmd, bool bSaveBestellvorschläge, ref Global.db.ERSystem.sqlVO sqlVOHelp, ref dsVO dsVOHelp,
                                ref int iInserted, ref bool bError, ref string ErrorTxt, bool doValidateBestellvorschläge, ref dsVO dsVoPrint, bool doSelectAllNone, bool bOn, bool LieferungBestätigen)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, ref dt, ref sWhereIDVO, IsFirstBand, db, dNow, rBenutzer, ref da, ref cmd, bSaveBestellvorschläge, ref sqlVOHelp, ref dsVOHelp, 
                                                ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, doSelectAllNone, bOn, LieferungBestätigen);
                        }
                        else
                        {
                            this.showGridRow(rFoundInGrid, ref dt, ref sWhereIDVO, IsFirstBand, db, dNow, rBenutzer, ref da, ref cmd, bSaveBestellvorschläge, ref sqlVOHelp, ref dsVOHelp, 
                                                ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, doSelectAllNone, bOn, LieferungBestätigen);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.showGrid_rek: " + ex.ToString());
            }
        }
        public void showGridRow(UltraGridRow rFoundInGrid, ref DataTable dt, ref string sWhereIDVO, bool IsFirstBand, PMDS.db.Entities.ERModellPMDSEntities db, 
                                DateTime dNow, Benutzer rBenutzer, ref OleDbDataAdapter da, ref OleDbCommand cmd, bool bSaveBestellvorschläge, ref Global.db.ERSystem.sqlVO sqlVOHelp, ref dsVO dsVOHelp,
                                ref int iInserted, ref bool bError, ref string ErrorTxt, bool doValidateBestellvorschläge, ref dsVO dsVoPrint, bool doSelectAllNone, bool bOn, bool LieferungBestätigen)
        {
            try
            {
                if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge && !bSaveBestellvorschläge && !doValidateBestellvorschläge &&!doSelectAllNone && !LieferungBestätigen)       //show Bestellvorschläge
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    Nullable<Guid> IDAufenthaltTmp = null;
                    Nullable<Guid> IDMedikamentTmp = null;
                    Nullable<Guid> Typ = null;
                    this.b3.getBestelldatenVO_IDs(ref dt, rVO_BestellpostitionenAct.IDBestelldaten_VO, ref IDAufenthaltTmp, ref IDMedikamentTmp, ref Typ, ref da, ref cmd);
                    rFoundInGrid.Cells[this.colTyp.Trim()].Value = Typ;

                    Guid IDPatient = this.b3.getIDPatientForAufenthalt(ref dt, IDAufenthaltTmp.Value, ref da, ref cmd);
                    string Krankenkasse = "";
                    string VersicherungsNr = "";
                    rFoundInGrid.Cells[this.colKlient.Trim()].Value = this.b3.getPatientenData(ref dt, IDPatient, ref da, ref cmd, ref Krankenkasse, ref VersicherungsNr);
                    rFoundInGrid.Cells[this.colMedikament.Trim()].Value = this.b3.getMedikamentName(ref dt, IDMedikamentTmp.Value, ref da, ref cmd);
                    rFoundInGrid.Cells[this.colMedikamentGeliefert.Trim()].Value = this.b3.getMedikamentName(ref dt, IDMedikamentTmp.Value, ref da, ref cmd);
                    if (!rVO_BestellpostitionenAct.IsLieferantNull())
                    {
                        var tLieferantFound = lstLieferanten.Where(o => o.ID == rVO_BestellpostitionenAct.Lieferant);
                        if (tLieferantFound.Count() > 0)
                        {
                            rFoundInGrid.Cells[this.colLieferantBeschreibung.Trim()].Value = lstLieferanten.Where(o => o.ID == rVO_BestellpostitionenAct.Lieferant).First().Beschreibung.Trim();
                        }
                    }

                    var tAbteil = (from a2 in db.Aufenthalt
                                      join abt in db.Abteilung on a2.IDAbteilung equals abt.ID
                                   where a2.ID == IDAufenthaltTmp.Value
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
                                    where a2.ID == IDAufenthaltTmp.Value
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

                    var tVO = (from vo3 in db.VO
                                   join bd3 in db.VO_Bestelldaten on vo3.ID equals bd3.IDVerordnung
                                   where bd3.ID == rVO_BestellpostitionenAct.IDBestelldaten_VO
                                   select new
                                   {
                                       BestaetigtVon = vo3.BestaetigtVon,
                                       Hinweis = vo3.Hinweis
                                   });
                    if (tVO.Count() >= 1)
                    {
                        var rVO = tVO.First();
                        rFoundInGrid.Cells[this.colVO_BestaetigtVon.Trim()].Value = rVO.BestaetigtVon.Trim();
                        rFoundInGrid.Cells[this.colVO_Hinweis.Trim()].Value = rVO.Hinweis.Trim();
                    }

                    System.Collections.Generic.List<Guid> lstTyp = new List<Guid>();
                    dsVOHelp.Clear();
                    sqlVOHelp.getVO_Bestelldaten(rVO_BestellpostitionenAct.IDBestelldaten_VO, sqlVO.eSelVO_Bestelldaten.ID, ref dsVOHelp, "", null, null, null, "", false, null, ref lstTyp);
                    dsVO.VO_BestelldatenRow rVO_BestelldatenInDB = (dsVO.VO_BestelldatenRow)dsVOHelp.VO_Bestelldaten.Rows[0];
                    
                    List<PMDS.GUI.VB.General.cSerientermine> lstDatumNächsterAnspruch = new List<VB.General.cSerientermine>();
                    DateTime dSerienterminEndetAm = new DateTime(3000, 1, 1, 0, 0, 0);
                    DateTime dGueltigAbTmp = rVO_BestellpostitionenAct.DatumBestellung.AddDays(1).Date;

                    if (dGueltigAbTmp.Date < dNow.Date)
                        dGueltigAbTmp = dNow;      

                    Nullable<int> WiedWertJedenTmp = null;
                    if (!rVO_BestelldatenInDB.IsWiedWertJedenNull())
                    {
                        WiedWertJedenTmp = rVO_BestelldatenInDB.WiedWertJeden;
                    }
                    Nullable<int> nTenMonatTmp = null;
                    if (!rVO_BestelldatenInDB.IsnTenMonatNull())
                    {
                        nTenMonatTmp = rVO_BestelldatenInDB.nTenMonat;
                    }
                    
                    this.bVB.genVODatumNaechsterAnspruch(dNow, dGueltigAbTmp, rVO_BestelldatenInDB.GueltigAb.Date, rVO_BestelldatenInDB.SerienterminType, WiedWertJedenTmp, rVO_BestelldatenInDB.TagWochenMonat,
                                                            nTenMonatTmp, rVO_BestelldatenInDB.Wochentage, ref lstDatumNächsterAnspruch, dSerienterminEndetAm);

                    if (lstDatumNächsterAnspruch.Count != 1)
                    {
                        throw new Exception("ucVOBestellvorschlaege.showGridRow: lstDatumNächsterAnspruch.Count != 1 not allowed for IDVOBestelldaten '" + rVO_BestelldatenInDB.ID.ToString() + "'!");
                    }

                    bool AddBestellvorschlag = true;
                    if ((!rVO_BestelldatenInDB.IsGueltigBisNull()) && lstDatumNächsterAnspruch[0].dFrom.Date > rVO_BestelldatenInDB.GueltigBis.Date)
                    {
                        rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value = rVO_BestellpostitionenAct.DatumBestellung.Date;
                        rVO_BestellpostitionenAct.DatumBestellungPlan = rVO_BestelldatenInDB.DatumNaechsterAnspruch.Date;
                        AddBestellvorschlag = false;
                    }
                    else if (rVO_BestelldatenInDB.IsGueltigBisNull())
                    {
                        AddBestellvorschlag = true;
                    }
                    if (AddBestellvorschlag)
                    {
                        rVO_BestellpostitionenAct.DatumBestellungPlan = rVO_BestelldatenInDB.DatumNaechsterAnspruch.Date;
                        rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value = lstDatumNächsterAnspruch[0].dFrom.Date;
                    }

                    //sWhereIDVO += (sWhereIDVO.Trim() == "" ? "" : " or ") + " IDVerordnung='" + rVOBestelldatenAct.ID.ToString() + "'";
                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge && bSaveBestellvorschläge && !doValidateBestellvorschläge && !doSelectAllNone && !LieferungBestätigen)      //save Bestellvorschläge
                {
                    System.Collections.Generic.List<Guid> lstTyp = new List<Guid>();
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    if ((bool)rFoundInGrid.Cells[this.colSelect.Trim()].Value == true)
                    {
                        bool Dauerbestellung = false;
                        this.b3.get_BestelldatenFields(ref dt, rVO_BestellpostitionenAct.IDBestelldaten_VO, ref da, ref cmd, ref Dauerbestellung);

                        if (!Dauerbestellung)
                        {
                            dsVOHelp.Clear();
                            sqlVOHelp.getVO_Bestellpostitionen(System.Guid.NewGuid(), sqlVO.eSelVO_Bestellpostitionen.ID, ref dsVOHelp, "", null, null, null, null, ref lstTyp);
                            dsVO.VO_BestellpostitionenRow rNewVO_Bestellpositionen = (dsVO.VO_BestellpostitionenRow)sqlVOHelp.getNewRowVO_Bestellpostitionen(ref dsVOHelp);
                            rNewVO_Bestellpositionen.ItemArray = rVO_BestellpostitionenAct.ItemArray;
                            rNewVO_Bestellpositionen.DatumBestellung = dNow.Date;
                            sqlVOHelp.daVO_Bestellpostitionen.Update(dsVOHelp.VO_Bestellpostitionen);

                            dsVO.VO_BestellpostitionenRow rNewVO_BestellpositionenForPrint = (dsVO.VO_BestellpostitionenRow)sqlVOHelp.getNewRowVO_Bestellpostitionen(ref dsVoPrint);
                            rNewVO_BestellpositionenForPrint.ItemArray = rNewVO_Bestellpositionen.ItemArray;
                        }

                        dsVOHelp.Clear();
                        sqlVOHelp.getVO_Bestelldaten(rVO_BestellpostitionenAct.IDBestelldaten_VO, sqlVO.eSelVO_Bestelldaten.ID, ref dsVOHelp, "", null, null, null, "", false, null, ref lstTyp);
                        dsVO.VO_BestelldatenRow rVO_BestelldatenInDB = (dsVO.VO_BestelldatenRow)dsVOHelp.VO_Bestelldaten.Rows[0];
                        rVO_BestelldatenInDB.DatumNaechsterAnspruch = ((DateTime)rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value).Date;
                        sqlVOHelp.daVO_Bestelldaten.Update(dsVOHelp.VO_Bestelldaten);

                        iInserted += 1;
                    }

                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge && !bSaveBestellvorschläge && doValidateBestellvorschläge && !doSelectAllNone && !LieferungBestätigen)      // validate Bestellvorschläge
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    if ((bool)rFoundInGrid.Cells[this.colSelect.Trim()].Value == true)
                    {
                        if ((object)rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value == System.DBNull.Value)
                        {
                            ErrorTxt += QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum nächster Anspruch muss angegeben werden!") + "\r\n";
                        }
                    }

                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge && !bSaveBestellvorschläge && !doValidateBestellvorschläge && doSelectAllNone && !LieferungBestätigen)      // select all/none
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    rFoundInGrid.Cells[this.colSelect.Trim()].Value = bOn;

                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung && !bSaveBestellvorschläge && !doValidateBestellvorschläge && doSelectAllNone && !LieferungBestätigen)      // select all/none
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    rFoundInGrid.Cells[this.colSelect.Trim()].Value = bOn;

                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung && !bSaveBestellvorschläge && !doValidateBestellvorschläge && !doSelectAllNone && !LieferungBestätigen)     // show Grid Lieferungen
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    Nullable<Guid> IDAufenthaltTmp = null;
                    Nullable<Guid> Typ = null;
                    this.b3.getBestellpostitionenVO_IDs(ref dt, rVO_BestellpostitionenAct.ID, ref IDAufenthaltTmp, ref Typ, ref da, ref cmd);
                    rFoundInGrid.Cells[this.colTyp.Trim()].Value = Typ;
                    Guid IDPatient = this.b3.getIDPatientForAufenthalt(ref dt, IDAufenthaltTmp.Value, ref da, ref cmd);
                    string Krankenkasse = "";
                    string VersicherungsNr = "";
                    rFoundInGrid.Cells[this.colKlient.Trim()].Value = this.b3.getPatientenData(ref dt, IDPatient, ref da, ref cmd, ref Krankenkasse, ref VersicherungsNr);
                    rFoundInGrid.Cells[this.colMedikament.Trim()].Value = this.b3.getMedikamentName(ref dt, rVO_BestellpostitionenAct.IDMedikament, ref da, ref cmd);
                    rFoundInGrid.Cells[this.colMedikamentGeliefert.Trim()].Value = this.b3.getMedikamentName(ref dt, rVO_BestellpostitionenAct.IDMedikamentGeliefert, ref da, ref cmd);
                    if (!rVO_BestellpostitionenAct.IsLieferantNull())
                    {
                        var tLieferantFound = lstLieferanten.Where(o => o.ID == rVO_BestellpostitionenAct.Lieferant);
                        if (tLieferantFound.Count() > 0)
                        {
                            rFoundInGrid.Cells[this.colLieferantBeschreibung.Trim()].Value = lstLieferanten.Where(o => o.ID == rVO_BestellpostitionenAct.Lieferant).First().Beschreibung.Trim();
                        }
                    }

                    var tAbteil = (from a2 in db.Aufenthalt
                                   join abt in db.Abteilung on a2.IDAbteilung equals abt.ID
                                   where a2.ID == IDAufenthaltTmp.Value
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
                                    where a2.ID == IDAufenthaltTmp.Value
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

                    var tVO = (from vo3 in db.VO
                               join bd3 in db.VO_Bestelldaten on vo3.ID equals bd3.IDVerordnung
                               where bd3.ID == rVO_BestellpostitionenAct.IDBestelldaten_VO
                               select new
                               {
                                   BestaetigtVon = vo3.BestaetigtVon,
                                   Hinweis = vo3.Hinweis
                               });
                    if (tVO.Count() >= 1)
                    {
                        var rVO = tVO.First();
                        rFoundInGrid.Cells[this.colVO_BestaetigtVon.Trim()].Value = rVO.BestaetigtVon.Trim();
                        rFoundInGrid.Cells[this.colVO_Hinweis.Trim()].Value = rVO.Hinweis.Trim();
                    }

                    var rVO_Bestelldaten = (from bd in db.VO_Bestelldaten
                                                   where bd.ID == rVO_BestellpostitionenAct.IDBestelldaten_VO
                                                    select new
                                                   {
                                                        ID = bd.ID,
                                                        DatumNaechsterAnspruch = bd.DatumNaechsterAnspruch
                                                   }).First();
                    if (rVO_Bestelldaten.DatumNaechsterAnspruch != null)
                        rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value = rVO_Bestelldaten.DatumNaechsterAnspruch.Value.Date;
                    else
                        rFoundInGrid.Cells[this.colDatumNächsterAnspruch.Trim()].Value = null;
                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung && !bSaveBestellvorschläge && !doValidateBestellvorschläge && !doSelectAllNone && LieferungBestätigen)      // Lieferungen bestätigen
                {
                    System.Collections.Generic.List<Guid> lstTyp = new List<Guid>();
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VO_BestellpostitionenRow rVO_BestellpostitionenAct = (dsVO.VO_BestellpostitionenRow)v.Row;

                    if ((bool)rFoundInGrid.Cells[this.colSelect.Trim()].Value == true)
                    {
                        dsVOHelp.Clear();
                        sqlVOHelp.getVO_Bestellpostitionen(rVO_BestellpostitionenAct.ID, sqlVO.eSelVO_Bestellpostitionen.ID, ref dsVOHelp, "", null, null, null, null, ref lstTyp);
                        dsVO.VO_BestellpostitionenRow rVO_BestellpositionenInDB = (dsVO.VO_BestellpostitionenRow)dsVOHelp.VO_Bestellpostitionen.Rows[0];
                        rVO_BestellpositionenInDB.DatumLieferung = DateTime.Now.Date;
                        rVO_BestellpositionenInDB.EinheitLieferung = rVO_BestellpositionenInDB.EinheitBestellung;
                        rVO_BestellpositionenInDB.MengeLieferung = rVO_BestellpositionenInDB.MengeBestellung;
                        rVO_BestellpositionenInDB.Status = PMDSBusiness.IDVOStatusGeliefert;

                        rVO_BestellpositionenInDB.DatumGeaendert = dNow;
                        rVO_BestellpositionenInDB.IDBenutzerGeaendert = rBenutzer.ID;
                        rVO_BestellpositionenInDB.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                        sqlVOHelp.daVO_Bestellpostitionen.Update(dsVOHelp.VO_Bestellpostitionen);
                        iInserted += 1;
                    }

                }
                else
                {
                    throw new Exception("ucVOBestellvorschlaege.showGridRow: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.showGridRow: " + ex.ToString());
            }   
        }

        public bool validateData(ref DateTime dNow)
        {
            try
            {
                string ErrorTxt = "";
                int iInserted = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                    string sWhereIDVO = "";
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    OleDbCommand cmd = new OleDbCommand();
                    Global.db.ERSystem.sqlVO sqlVOHelp = new sqlVO();
                    dsVO dsVOHelp = new dsVO();
                    bool doValidateBestellvorschläge = true;
                    bool bError = false;
               
                    dsVO dsVoPrint = new dsVO();
                    foreach (UltraGridRow rGrid in this.gridVOErfBestell.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                        }
                        else
                        {
                            this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, false);
                        }
                    }
                }

                if (ErrorTxt.Trim() != "")
                {
                    string sTxtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Daten richtig ausfüllen!");
                    sTxtMsgBox += "\r\n" + "\r\n" + ErrorTxt;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTxtMsgBox, "", MessageBoxButtons.OK, true);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.validateData: " + ex.ToString());
            }
        }
        public bool saveData(bool LieferungBestätigen)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                if (!LieferungBestätigen)
                {
                    if (!this.validateData(ref dNow))
                    {
                        return false;
                    }
                }

                DialogResult res = DialogResult.Yes;
                //if (!LieferungBestätigen)
                //{
                //    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Bestellvorschläge wirklich speichern?", "", MessageBoxButtons.YesNo);
                //}
                //else
                //{
                //    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie für die ausgewählten Bestellungen die Lieferungen wirklich bestätigen?", "", MessageBoxButtons.YesNo);
                //}
                if (res == DialogResult.Yes)
                {
                    bool SaveBestellvorschläge = false;
                    this.gridVOErfBestell.UpdateData();
                    if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                    {
                        SaveBestellvorschläge = true;
                    }
                    dsVO dsVoPrint = new dsVO();
                    int iInserted = 0;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                        string sWhereIDVO = "";
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        OleDbCommand cmd = new OleDbCommand();
                        Global.db.ERSystem.sqlVO sqlVOHelp = new sqlVO();
                        sqlVOHelp.initControl();
                        dsVO dsVOHelp = new dsVO();
                        bool doValidateBestellvorschläge = false;
                        bool bError = false;
                        string ErrorTxt = "";
                        foreach (UltraGridRow rGrid in this.gridVOErfBestell.Rows)
                        {
                            if (rGrid.IsGroupByRow)
                            {
                                this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, SaveBestellvorschläge, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, LieferungBestätigen);
                            }
                            else
                            {
                                this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, SaveBestellvorschläge, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, false, false, LieferungBestätigen);
                            }
                        }
                    }           

                    if (!LieferungBestätigen)
                    {
                        if (ENV.adminSecure)
                        {
                            string sTxtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellungen wurden gespeichert!");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iInserted.ToString() + " " + sTxtMsgBox, "", MessageBoxButtons.OK);
                        }

                        DialogResult res2 = DialogResult.Yes;
                        if (ENV.adminSecure)
                        {
                            res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die gespeicherten Bestellvorschläge drucken?", "", MessageBoxButtons.YesNo);
                        }
                        if (res2 == DialogResult.Yes)
                        {
                            this.print(false, ref dsVoPrint, true);
                        }

                    }
                    else
                    {
                        //string sTxtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Lieferungen wurden gespeichert!");
                        //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iInserted.ToString() + " " + sTxtMsgBox, "", MessageBoxButtons.OK);
                    }

                    this.search();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.saveData: " + ex.ToString());
            }
        }

        public void OpenVO_Bestellpostitionen(dsVO.VO_BestellpostitionenRow rVO_Bestellpostitionen, ref UltraGridRow rGridSelBestellposition)
        {
            try
            {
                this.gridVOErfBestell.UpdateData();
                Nullable<DateTime> NächsterAnspruchTmp = null;
                if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                {
                    NächsterAnspruchTmp = ((DateTime)rGridSelBestellposition.Cells[this.colDatumNächsterAnspruch].Value).Date;
                }

                frmVOBestellvorschlaegeDetail frmVOBestellvorschlaegeDetail1 = new frmVOBestellvorschlaegeDetail();
                if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                {
                    frmVOBestellvorschlaegeDetail1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge, null, rVO_Bestellpostitionen, false, null, NächsterAnspruchTmp);
                }
                else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                {
                    frmVOBestellvorschlaegeDetail1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung, rVO_Bestellpostitionen.ID, rVO_Bestellpostitionen, false, null, null);
                }
                frmVOBestellvorschlaegeDetail1.ShowDialog(this);
                if (!frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1.abort)
                {
                    if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                    {
                        if (frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1.udteDatumNaechsterAnspruch.Value != null)
                        {
                            rGridSelBestellposition.Cells[this.colDatumNächsterAnspruch].Value = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1.udteDatumNaechsterAnspruch.DateTime.Date;
                        }
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        OleDbCommand cmd = new OleDbCommand();
                        DataTable dt = new DataTable();
                        rVO_Bestellpostitionen.IDMedikament = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.IDMedikament;
                        rVO_Bestellpostitionen.IDMedikamentGeliefert = rVO_Bestellpostitionen.IDMedikament;
                        rGridSelBestellposition.Cells[this.colMedikament.Trim()].Value = this.b3.getMedikamentName(ref dt, frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.IDMedikament, ref da, ref cmd);
                        rGridSelBestellposition.Cells[this.colMedikamentGeliefert.Trim()].Value = rGridSelBestellposition.Cells[this.colMedikament.Trim()].Value;

                        rVO_Bestellpostitionen.DatumBestellung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.DatumBestellung.Date;
                        rVO_Bestellpostitionen.MengeBestellung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.MengeBestellung;
                        rVO_Bestellpostitionen.EinheitBestellung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.EinheitBestellung;
                        if (!frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.IsLieferantNull())
                        {
                            rVO_Bestellpostitionen.Lieferant = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.Lieferant;
                        }
                        else
                        {
                            rVO_Bestellpostitionen.SetLieferantNull();
                        }
                        rVO_Bestellpostitionen.HinweisLieferant = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.HinweisLieferant;
                        rVO_Bestellpostitionen.Anmerkung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.Anmerkung;

                        this.gridVOErfBestell.UpdateData();
                        rGridSelBestellposition.Refresh();
                        this.gridVOErfBestell.Refresh();
                        //this.search();
                    }
                    else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        OleDbCommand cmd = new OleDbCommand();
                        DataTable dt = new DataTable();
                        rVO_Bestellpostitionen.IDMedikamentGeliefert = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.IDMedikamentGeliefert;
                        rGridSelBestellposition.Cells[this.colMedikamentGeliefert.Trim()].Value = this.b3.getMedikamentName(ref dt, frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenDS.IDMedikamentGeliefert, ref da, ref cmd);

                        if (frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.DatumLieferung != null)
                        {
                            rVO_Bestellpostitionen.DatumLieferung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.DatumLieferung.Value;
                        }
                        else
                        {
                            rVO_Bestellpostitionen.SetDatumLieferungNull();
                        }
                        rVO_Bestellpostitionen.EinheitLieferung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.EinheitLieferung;
                        rVO_Bestellpostitionen.MengeLieferung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.MengeLieferung;
                        rVO_Bestellpostitionen.Status = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.Status;
                        rVO_Bestellpostitionen.BemerkungLieferung = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.BemerkungLieferung;
                        rVO_Bestellpostitionen.UserChanged = frmVOBestellvorschlaegeDetail1.ucVOBestellvorschlaegeDetail1._rVO_BestellpostitionenEF.UserChanged;

                        this.gridVOErfBestell.UpdateData();
                        rGridSelBestellposition.Refresh();
                        this.gridVOErfBestell.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.OpenVO_Bestellpostitionen: " + ex.ToString());
            }
        }

        public bool deleteRows()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridVOErfBestell, lstSelectedRows, false);
                if (lstSelectedRows.Count > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        string sMsgBoxInfoDelete = "";

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                        {
                            DataRowView v = (DataRowView)rGrid.ListObject;
                            dsVO.VO_BestellpostitionenRow rSelRow = (dsVO.VO_BestellpostitionenRow)v.Row;

                            sMsgBoxInfoDelete = this.b2.checkDeleteVO_Bestelldaten(rSelRow.ID, true);
                        }

                        if (sMsgBoxInfoDelete.Trim() != "")
                        {
                            string sMsgBox = "";        //QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Beziehungen zu den gewählten Zeilen gefunden!");
                            string sMsgBox2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sätze trotzdem löschen?");
                            sMsgBoxInfoDelete = sMsgBox + "\r\n" + sMsgBoxInfoDelete + "\r\n" + sMsgBox2;

                            PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox();
                            frmMessageBox1.initControl(sMsgBoxInfoDelete);
                            frmMessageBox1.ShowDialog(this);
                            if (frmMessageBox1.abort)
                            {
                                return false;
                            }
                        }

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                dsVO.VO_BestellpostitionenRow rSelRow = (dsVO.VO_BestellpostitionenRow)v.Row;

                                this.sqlVO1.delete_IDVO_Bestellposition(rSelRow.ID);
                            }

                            if (sMsgBoxInfoDelete.Trim() != "")
                            {
                                this.b.saveProtocol(db, "Delete Verordnungen", sMsgBoxInfoDelete);
                            }
                        }

                        this.search();
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
                throw new Exception("ucVOBestellvorschlaege.delete: " + ex.ToString());
            }
        }
        public bool print(bool exportDS, ref dsVO dsVoPrint, bool SaveClicked)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                    Nullable<DateTime> dFrom = null;
                    if (this.udteVerordnetAb.Value != null)
                    {
                        dFrom = this.udteVerordnetAb.DateTime.Date;
                    }

                    Nullable<DateTime> dTo = null;
                    if (this.udteVerordnetBis.Value != null)
                    {
                        dTo = this.udteVerordnetBis.DateTime.Date;
                    }

                    System.Collections.Generic.List<string> lstSelectedTyp = new List<string>();
                    string lTyp = this.contSelectSelListTyp.getSelectedData2(ref lstSelectedTyp);

                    dsVO dsVPToPrint = null;
                    bool IsLieferung = false;
                    if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                    {
                        IsLieferung = false;
                        if (SaveClicked)
                        {
                            dsVPToPrint = dsVoPrint;
                        }
                        else
                        {
                            dsVPToPrint = this.dsVO1;
                        }
                    }
                    else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                    {
                        IsLieferung = true;
                        dsVPToPrint = this.dsVO1;
                    }

                    string lstIDs = "";
                    foreach (dsVO.VO_BestellpostitionenRow rVOBestellpostitionen in dsVPToPrint.VO_Bestellpostitionen)
                    {
                        lstIDs += rVOBestellpostitionen.ID.ToString() + ";";
                    }

                    dsVO dsVPToPrint2 = new dsVO();
                    dsVPToPrint2 = (dsVO)dsVPToPrint.Copy();
                    dsVPToPrint2.VO_Bestellpostitionen.Columns.Add("LieferantBeschreibung", typeof(string));
                    foreach (dsVO.VO_BestellpostitionenRow rVOBestellpositionToPrint in dsVPToPrint2.VO_Bestellpostitionen)
                    {
                        rVOBestellpositionToPrint["LieferantBeschreibung"] = "";
                        if (!rVOBestellpositionToPrint.IsLieferantNull())
                        {
                            var tLieferantFound = lstLieferanten.Where(o => o.ID == rVOBestellpositionToPrint.Lieferant);
                            if (tLieferantFound.Count() > 0)
                            {
                                rVOBestellpositionToPrint["LieferantBeschreibung"] = lstLieferanten.Where(o => o.ID == rVOBestellpositionToPrint.Lieferant).First().Beschreibung.Trim();
                            }
                        }
                    }

                    PMDS.Print.ReportManager.PrintVOBestellvorschlägeLieferungen(dsVPToPrint2, ENV.IDKlinik, ENV.CurrentIDAbteilung, dFrom, dTo, lTyp, ENV.LoginInNameFrei.Trim(), exportDS, IsLieferung, lstIDs);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.print: " + ex.ToString());
            }
        }

        public dsVO.VO_BestellpostitionenRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridVOErfBestell.ActiveRow != null)
                {
                    if (this.gridVOErfBestell.ActiveRow.IsGroupByRow || this.gridVOErfBestell.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridVOErfBestell.ActiveRow.ListObject;
                        dsVO.VO_BestellpostitionenRow rSelRow = (dsVO.VO_BestellpostitionenRow)v.Row;
                        gridRow = this.gridVOErfBestell.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.getSelectedRow: " + ex.ToString());
            }
        }
        public void selectAllNone(bool bOn)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                dsVO dsVoPrint = new dsVO();
                int iInserted = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                    string sWhereIDVO = "";
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    OleDbCommand cmd = new OleDbCommand();
                    Global.db.ERSystem.sqlVO sqlVOHelp = new sqlVO();
                    dsVO dsVOHelp = new dsVO();
                    bool doValidateBestellvorschläge = false;
                    bool bError = false;
                    string ErrorTxt = "";
                    foreach (UltraGridRow rGrid in this.gridVOErfBestell.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, true, bOn, false);
                        }
                        else
                        {
                            this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, db, dNow, rBenutzer, ref da, ref cmd, false, ref sqlVOHelp, ref dsVOHelp, ref iInserted, ref bError, ref ErrorTxt, doValidateBestellvorschläge, ref dsVoPrint, true , bOn, false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaege.selectAllNone: " + ex.ToString());
            }
        }


        private void gridVOErfBestell_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge)
                    {
                        if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colSelect.Trim().ToLower()) || e.Cell.Column.ToString().Trim().ToLower().Equals(this.colDatumNächsterAnspruch.Trim().ToLower()))
                        {
                            e.Cell.Activation = Activation.AllowEdit;
                        }
                        else
                        {
                            e.Cell.Activation = Activation.NoEdit;
                            e.Cell.Row.Selected = true;
                        }
                    }
                    else if (this._TypeUI == ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung)
                    {
                        if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colSelect.Trim().ToLower()))
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

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                //this.gridVOErfBestell.UpdateData();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
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
        private void gridVOErfBestell_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOErfBestell))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOErfBestell))
                {
                    this.gridVOErfBestell.UpdateData();
                    UltraGridRow rGridSel = null;
                    dsVO.VO_BestellpostitionenRow rVO_Bestellpostitionen = this.getSelectedRow(false, ref rGridSel);
                    if (rVO_Bestellpostitionen != null)
                    {
                        this.OpenVO_Bestellpostitionen(rVO_Bestellpostitionen, ref rGridSel);
                    }
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
                this.search();

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
                if (this.saveData(false))
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

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(true);

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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(false);

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



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dsVO dsVoPrint = new dsVO();
                this.print(false, ref dsVoPrint, false);

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
                this.deleteRows();

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
        private void exportDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dsVO dsVoPrint = new dsVO();
                this.print(true, ref dsVoPrint, false);

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

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.buildUI1.setFilterGridKomplex((Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOErfBestell, this.filterToolStripMenuItem.Checked, true, false);

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

        private void lieferungBestätigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData(true))
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

        private void cboStatus_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("BSS");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.b2.loadSelList("BSS", this.cboStatus, null, this.cboStatus.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("BSS", this.cboStatus, null);
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
