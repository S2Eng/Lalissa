using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Print;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.Patient;
using PMDS.DB;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI.Medikament
{
    
    public partial class ucMed4Bestellen : UserControl, PMDS.Global.ISave
    {

        public bool _DataChanged = false;
        public bool _isInitialized = false;

        public enum eTypActionGrid
        {
            DeleteSelectedRows = 0,
            SelectAllNone = 1,
            LoadData = 0
        }

        public enum eTypSaveMedikamente
        {
            RezeptAnfordern = 0,
            MedikamenteBestellen = 1
        }

        public ucMedikamenteMain ucMedikamenteStammdatenMain = null;

        PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();
        public PMDSBusiness b = new PMDSBusiness();
        public string colHerrichtenTxt = "HerrichtenTxt";


        private class PatientDelegation
        {
            public Guid ID { get; set; }
            public Guid IDAuenthalt { get; set; }
            public string Name { get; set; }
            public bool ELGASOO { get; set; }
            public bool ELGAAktiv { get; set; }
            public bool ELGAAbgemeldet { get; set; }
        }

        private class ArztDelegation
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public bool HasOID { get; set; }
            public List<PatientDelegation> PatientenDelegation { get; set; }
        }

        public ucMed4Bestellen()
        {
            InitializeComponent();
        }

        private void ucMedikamenteBestellen_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this._isInitialized)
                {
                    DB.DBKlinik DBKlinik1 = new DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(ENV.IDKlinik, true);
                    this.cboAbteilung.rKlinik = rKlinik;
                    this.cboAbteilung.RefreshList();

                    if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                    }
                    else
                    {
                    }

                    this.btnRezepteanforderungsliste.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnRezepteDrucken.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnMedikamentenbestellliste.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, QS2.Resources.getRes.ePicTyp.ico);

                    QS2.Desktop.ControlManagment.BaseGrid grdTmp = (QS2.Desktop.ControlManagment.BaseGrid)this.gridMedikamenteBestellen;
                    string defaultLayoutName = "Medikamente bestellen";
                    grdTmp.doBaseElements1.runControlManagmentBaseGridManual(this.gridMedikamenteBestellen, defaultLayoutName);

                    this.btnMedikamenteBestellen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnRezepteAnfordern.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, QS2.Resources.getRes.ePicTyp.ico);
                   
                    ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);

                    this.SelectAllNone(0, false);
                    this.PMDSBusinessUI1.loadCboPackungsanzahl(null, this.gridMedikamenteBestellen.DisplayLayout.ValueLists["Packungsanzahl"].ValueListItems);
                    this.gridMedikamenteBestellen.DisplayLayout.Bands[0].Columns["Packungsanzahl"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                    this.btnRezepteanforderungsliste.Visible = true;
                    this.btnRezepteDrucken.Visible = (ENV.RezeptDruck == 0 ? false : true);
                    this.btnMedikamentenbestellliste.Visible = true;

                    this.UIOnOff();
                    this.ClearUI(true, false, false, true, false);

                    this._isInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.initControl: " + ex.ToString());
            }
        }
        public void UIOnOff()
        {
            try
            {
                if (ENV.RezeptBestellModus == 1 || ENV.RezeptBestellModus == 0)
                {
                    this.grpMedikamentBestellt.Visible = false;
                    this.lblOffeneBestellungen.Visible = false;
                    this.lblBestellteMedikamente.Visible = false;
                    this.btnMedikamenteBestellen.Visible = false;

                    this.panelWorkflowButtons.Left = this.grpMedikamentBestellt.Left;
                }
                
                if (ENV.RezeptBestellModus == 2 || ENV.RezeptBestellModus == 0)
                {
                    this.grpRezeptAngefordert.Visible = false;
                    this.lblOffeneAnforderungen.Visible = false;
                    this.lblAngeforderteRezepte.Visible = false;
                    this.btnRezepteAnfordern.Visible = false;

                    this.panelWorkflowButtons.Left = this.grpMedikamentBestellt.Left;
                    this.grpMedikamentBestellt.Left = this.grpRezeptAngefordert.Left;
                }

                //Druckbuttons ein- oder ausblenden
                this.btnMedikamentenbestellliste.Visible = false;
                this.btnRezepteDrucken.Visible = false;
                this.btnRezepteanforderungsliste.Visible = false;

                if (ENV.HasRight(UserRights.MedikamentenbestellisteDrucken))
                {

                    if (ENV.RezeptDruck == 1 || ENV.RezeptDruck == 4 || ENV.RezeptDruck == -1)
                    {
                        this.btnRezepteanforderungsliste.Visible = true;
                    }

                    if (ENV.RezeptDruck == 2 || ENV.RezeptDruck == 5 || ENV.RezeptDruck == -1)
                    {
                        this.btnMedikamentenbestellliste.Visible = true;
                    }

                    if (ENV.RezeptDruck == 3 || ENV.RezeptDruck == 4 || ENV.RezeptDruck == 5 || ENV.RezeptDruck == -1)
                    {
                        this.btnRezepteDrucken.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.UIOnOff: " + ex.ToString());
            }
        }

        public void ClearUI(bool OffeneAnforderungen, bool AngeforderteRezepte, bool OffeneBestellungen, bool ClearAllData,
                            bool BestellteMedikamente)
        {
            try
            {
                if (ClearAllData)
                {
                    this.datRezeptAngefordertFrom.Value = null;
                    DateTime dNow = DateTime.Now;
                    DateTime dToTmp = new DateTime(dNow.Year, dNow.Month, dNow.Day, 0, 0, 0);
                    this.datRezeptAngefordertTo.Value = null;

                    this.datRezeptanforderungFrom.Value = null;
                    this.datRezeptanforderungTo.Value = null;  // dNow;

                    this.datRezeptanforderungFrom.Value = null;
                    this.datRezeptanforderungTo.Value = null;

                    this.datMedikamentBestelltFrom.Value = null;
                    this.datMedikamentBestelltTo.Value = null;

                    this.cboAbteilung.Value = null;
                    this.optDringend.Value = -1;

                    this.optGedrucktJN.Value = 0;
                }

                if (OffeneAnforderungen)
                {
                    this.optRezeptAngefordertJN.Value = 0;
                    this.optBestellt.Value = 0;
                }
                else if (AngeforderteRezepte)
                {
                    this.optRezeptAngefordertJN.Value = 1;
                    this.optBestellt.Value = -1;
                }
                else if (OffeneBestellungen)
                {
                    this.optRezeptAngefordertJN.Value = -1;
                    this.optBestellt.Value = 0;
                }
                else if (BestellteMedikamente)
                {
                    this.optRezeptAngefordertJN.Value = -1;
                    this.optBestellt.Value = 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.ClearUI: " + ex.ToString());
            }
        }
        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }
        public void RefreshControl()
        {
            try
            {
                if (Visible)
                {
                    this.LoadData();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.RefreshControl: " + ex.ToString());
            }
        }

        public void LoadData()
        {
            try
            {
                this.btnMedikamenteBestellen.Enabled = false;
                this.btnRezepteAnfordern.Enabled = false;
                this.btnUndo.Enabled = false;
                this.btnAbort.Enabled = false;
                this.btnSave.Enabled = false;

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    IQueryable<PMDS.db.Entities.vRezeptBestellung2> tRezeptBest = null;
                    PMDSBusiness1.searchMedikamenteBestellt(db, ref tRezeptBest,
                                                            (Nullable<DateTime>)this.datRezeptanforderungFrom.Value, (Nullable<DateTime>)this.datRezeptanforderungTo.Value,
                                                            (Nullable<DateTime>)this.datRezeptAngefordertFrom.Value, (Nullable<DateTime>)this.datRezeptAngefordertTo.Value,
                                                            (Nullable<DateTime>)this.datMedikamentBestelltFrom.Value, (Nullable<DateTime>)this.datMedikamentBestelltTo.Value, 
                                                            (Nullable<Guid>)this.cboAbteilung.Value,
                                                            (int)this.optDringend.Value, (int)this.optBestellt.Value,(int)this.optRezeptAngefordertJN.Value,
                                                            PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl, PMDS.Global.ENV.CurrentIDPatient, PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten, (int)this.optGedrucktJN.Value);

                    this.gridMedikamenteBestellen.DataSource = System.Linq.Enumerable.ToList(tRezeptBest);
                    this.gridMedikamenteBestellen.DataBind();

                    foreach (UltraGridRow rGrid in this.gridMedikamenteBestellen.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.doActionGridLoad_rek(eTypActionGrid.LoadData, rGrid, db);
                        }
                        else
                        {
                            this.doActionGridLoadRow(eTypActionGrid.LoadData, rGrid, db);
                        }
                    }
                    
                    qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                    compLayout1.initControl();
                    bool LayoutFound = false;
                    compLayout1.doLayoutGrid(this.gridMedikamenteBestellen, this.gridMedikamenteBestellen.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.gridMedikamenteBestellen);

                    this.SelectAllNone(0, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.LoadData: " + ex.ToString());
            }
        }
        public void doActionGridLoad_rek(eTypActionGrid TypActionGrid, UltraGridRow rFoundParent, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.doActionGridLoad_rek(TypActionGrid, rFoundInGrid, db);
                        }
                        else
                        {
                            this.doActionGridLoadRow(TypActionGrid, rFoundInGrid, db);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.doActionGrid_rek: " + ex.ToString());
            }
        }
        public void doActionGridLoadRow(eTypActionGrid TypActionGrid, UltraGridRow rFoundInGrid, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.vRezeptBestellung2 rvRezeptBestellung = (PMDS.db.Entities.vRezeptBestellung2)rFoundInGrid.ListObject;
                rFoundInGrid.Cells[this.colHerrichtenTxt.Trim()].Value = PMDS.GUI.PMDSBusinessUI.getTxtHerrichten(rvRezeptBestellung.Herrichten);

                //var rRezeptEintrag = (from r in db.RezeptEintrag
                //                      where r.ID == rvRezeptBestellung.IDRezeptEintrag
                //                      select new
                //                      {
                //                          ID = r.ID,
                //                          AbzugebenBis = r.AbzugebenBis
                //                      }).First();

                //if (rRezeptEintrag.AbzugebenBis != null)
                //{

                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.doActionGridLoadRow: " + ex.ToString());
            }
        }


        public bool ValidateData()
        {
            try
            {


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.ValidateData: " + ex.ToString());
            }
        }
        public bool SaveData(bool Order, eTypSaveMedikamente TypSaveMedikamente)
        {
            try
            {
                if (this.ValidateData())
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                    int iCountToSave = 0;
                    List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestGrid = (List<PMDS.db.Entities.vRezeptBestellung2>)this.gridMedikamenteBestellen.DataSource;
                    List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected = new List<db.Entities.vRezeptBestellung2>();
                    List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                    this.doActionGrid(ref lstData, eTypActionGrid.DeleteSelectedRows, ref tRezepteBestSelected, false);

                    if (tRezepteBestSelected.Count > 0)
                    {
                        int iCounterDeleted = 0;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            if (PMDSBusiness1.saveMedikamenteBestellt(tRezepteBestSelected, 
                                                                        (TypSaveMedikamente == eTypSaveMedikamente.RezeptAnfordern?true:false),
                                                                        (TypSaveMedikamente == eTypSaveMedikamente.MedikamenteBestellen?true:false),
                                                                        db, true, ref iCountToSave, Order))
                            {
                                return true;
                            }
                        }
                        this.LoadData();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Medikamente wurden bestellt!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellung Medikamente"), MessageBoxButtons.OK, true);
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Medikamente ausgewählt!", "Bestellung Medikamente", MessageBoxButtons.OK);
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.SaveData: " + ex.ToString());
            }
        }

        public bool SaveDataGrid()
        {
            try
            {
                //if (this.ValidateData())
                //{
                    foreach (UltraGridRow gridRow in this.gridMedikamenteBestellen.Rows)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.vRezeptBestellung2 rvRezeptBestellungGrid = (PMDS.db.Entities.vRezeptBestellung2)gridRow.ListObject;
                        
                            IQueryable<PMDS.db.Entities.RezeptBestellungPos> tRezeptBestPos = db.RezeptBestellungPos.Where(rb => rb.ID == rvRezeptBestellungGrid.rbp_ID);
                            if (tRezeptBestPos.Count() != 1)
                            {
                                throw new Exception("SaveDataGrid: tRezeptBestPos.Count()!=0 not allowed for RezeptBestellungPos.ID '" + rvRezeptBestellungGrid.rbp_ID.ToString() + "'!");
                            }

                            PMDS.db.Entities.RezeptBestellungPos rRezeptBestPos = tRezeptBestPos.First();

                            rRezeptBestPos.Packungsanzahl = rvRezeptBestellungGrid.Packungsanzahl;
                            db.SaveChanges();
                        }
                    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.SaveDataGrid: " + ex.ToString());
            }
        }
        public bool Save()
        {
            try
            {
                //return this.SaveData(true);

                return true;    //lth223
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.Save: " + ex.ToString());
            }
        }
        public void Undo()
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.Undo: " + ex.ToString());
            }
        }
        public bool ValidateFields()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.ValidateFields: " + ex.ToString());
            }
        }

        public bool IsChanged
        { 
            get 
            { 
                return _DataChanged;
            }
        }

        public void DeleteRows()
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die markierten Bestellungen wirklich löschen?", "Bestellung Medikamente löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                    List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected = new List<db.Entities.vRezeptBestellung2>();
                    this.doActionGrid(ref lstData, eTypActionGrid.DeleteSelectedRows, ref tRezepteBestSelected, false);

                    if (lstData.Count > 0)
                    {
                        int iCounterDeleted = 0;
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        PMDSBusiness1.DeleteBestellungen(ref lstData, ref iCounterDeleted);

                        this.LoadData();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bestellung/en wurde/n gelöscht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellung Medikamente löschen"), MessageBoxButtons.OK, true);
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Bestellungen zum Löschen ausgewählt!", "Bestellung Medikamente löschen", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.DeleteRows: " + ex.ToString());
            }
        }

        public bool PrintBestellung(PMDS.Print.frmPrintPreview.eTypReportMedikamenteBestellen TypActionPrint)
        {
            try
            {
                bool bCreateELGAKontaktDelegation = false;
                string sMsgBox = "";
                if (ENV.lic_ELGA && TypActionPrint == frmPrintPreview.eTypReportMedikamenteBestellen.Rezeptanforderungsliste)
                {
                    if (!PMDS.Global.db.ERSystem.ELGABusiness.checkELGASessionActive(false))
                    {
                        sMsgBox = "Keine aktive ELGA-Sitzung. Wollen Sie die Rezeptanforderung ohne Kontaktdelegation erstellen?";
                    }
                    else if (PMDS.Global.db.ERSystem.ELGABusiness.checkELGASessionActive(false) &&
                            ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, false))
                    {
                        sMsgBox = "Sie haben kein Recht für die ELGA-Kontaktdelegation. Wollen Sie die Rezeptanforderung trotzdem erstellen?";
                    }
                    else
                        bCreateELGAKontaktDelegation = true;

                    if (!bCreateELGAKontaktDelegation)
                    {
                        using (PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox())
                        {
                            frmMessageBox1.initControl(sMsgBox);
                            frmMessageBox1.ShowDialog(this);
                            if (frmMessageBox1.abort)
                            {
                                return false;
                            }
                        }
                    }
                }

                List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected = new List<db.Entities.vRezeptBestellung2>();
                this.doActionGrid(ref lstData, eTypActionGrid.DeleteSelectedRows, ref tRezepteBestSelected, false);

                if (lstData.Count > 0)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    DataTable tBestellungMedikamente = PMDS.DB.BusinessHelp.ToDataTable(tRezepteBestSelected);

                    frmPrintPreview frmPrintPreview1 = null;
                    frmPrintPreview.PrintBestellungMedikamente(tBestellungMedikamente,
                                                                (Nullable<DateTime>)this.datRezeptAngefordertFrom.Value, (Nullable<DateTime>)this.datRezeptAngefordertTo.Value,
                                                                ENV.IDKlinik, (this.cboAbteilung.Value == null ? Guid.Empty : (Guid)this.cboAbteilung.Value),
                                                                out frmPrintPreview1, TypActionPrint);
                    PMDSBusiness1.UpdateMedikamenteAsGedruckt(tRezepteBestSelected);
                    this.LoadData();

                    if (bCreateELGAKontaktDelegation)
                    {
                        string sResultOk = "Ergebnis für Kontaktdelagation wegen Rezeptanforderung\n\r\n\r";
                        string sResultNotOk = "";

                        ELGABusiness ELGABusiness = new ELGABusiness();
                        List<ArztDelegation> AerzteMitOID = new List<ArztDelegation>();

                        foreach (PMDS.db.Entities.vRezeptBestellung2 r in tRezepteBestSelected)
                        {
                            if (!AerzteMitOID.Any(a => a.ID == (Guid)r.IDAerzte))
                            {
                                ArztDelegation a = new ArztDelegation
                                {
                                    ID = (Guid)r.IDAerzte,
                                    Name = r.Arzt,
                                    HasOID = String.IsNullOrWhiteSpace(((Guid)r.IDAerzte).ToString()),
                                    PatientenDelegation = new List<PatientDelegation>()
                                };
                                AerzteMitOID.Add(a);
                            }
                            ArztDelegation ArztDel = AerzteMitOID.Where(a => a.ID == (Guid)r.IDAerzte).First();

                            if (!ArztDel.PatientenDelegation.Any(p => p.ID == (Guid)r.IDPatient))
                            {
                                ELGABusiness elga = new ELGABusiness();
                                ELGABusiness.KlientDTO ELGAKlient = elga.GetELGAKlientByIDAufenthalt((Guid)r.IDAufenthalt);

                                PatientDelegation pD = new PatientDelegation();
                                pD.ID = (Guid)ELGAKlient.IDKlient;
                                pD.Name = ELGAKlient.Vorname + " " + ELGAKlient.Nachname;
                                pD.IDAuenthalt = ELGAKlient.IDAufenthalt;
                                pD.ELGASOO = ELGAKlient.ELGASOOJN;
                                pD.ELGAAktiv = !String.IsNullOrWhiteSpace(ELGAKlient.ELGALocalID);

                                ArztDel.PatientenDelegation.Add(pD);
                            }
                        }

                        foreach (ArztDelegation Arzt in AerzteMitOID)
                        {
                            if (Arzt.HasOID)
                            {
                                sResultOk += "\n\rKontaktdelegationen für Arzt " + Arzt.Name + "\n\r";
                                foreach (PatientDelegation Patient in Arzt.PatientenDelegation)
                                {
                                    if (Patient.ELGAAktiv && !Patient.ELGASOO && !Patient.ELGAAbgemeldet)
                                    {
                                        WCFServicePMDS.BAL2.ELGABAL.ELGAParOutDto retDto = ELGABusiness.DelegateContact(Patient.IDAuenthalt, Arzt.ID);
                                        if (retDto.bOK)
                                        {
                                            sResultOk += "Erfolgreich für " + Patient.Name + ".\n\r";
                                        }
                                        else
                                        {
                                            sResultOk += "Unerwarteter Fehler für " + Patient.Name + ":" + retDto.MessageException + ".\n\r";
                                        }
                                    }
                                    else
                                    {
                                        sResultOk += "Keine Deleagtion für " + Patient.Name + " wegen ";
                                        if (Patient.ELGAAbgemeldet)
                                            sResultOk += "Abmeldung von ELGA.\n\r";
                                        else if (!Patient.ELGAAktiv)
                                            sResultOk += "fehlender Kontaktbestätigung.\n\r";
                                        else if (Patient.ELGASOO)
                                            sResultOk += "situativem Opt-Out (SOO).\n\r";
                                    }
                                }
                            }
                            else
                            {
                                sResultNotOk += "Keine Delegation für Arzt " + Arzt.Name + "möglich, weil keine OID zugeordnet wurde.\n\r";
                                sResultNotOk += "Folgende Patienten sind betroffen:\n\r";
                                foreach (PatientDelegation Patient in Arzt.PatientenDelegation)
                                {
                                    sResultNotOk += Patient.Name + "\n\r";
                                }
                            }

                            using (PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox())
                            {
                                frmMessageBox1.ShowAbort = false;
                                frmMessageBox1.initControl(sResultOk + "\n\r" + sResultNotOk);
                                frmMessageBox1.ShowDialog(this);
                            }
                        }
                    }
                    frmPrintPreview1.Show();

                    return true;
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Medikamente zum Drucken ausgewählt!", "Medikamente Drucken", MessageBoxButtons.OK);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.PrintBestellung: " + ex.ToString());
            }
        }
 
        public void doActionGrid(ref List<PMDS.DB.PMDSBusiness.cField> lstData, eTypActionGrid TypActionGrid,
                                ref List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected, bool bPar)
        {
            try
            {
                foreach (UltraGridRow rFoundInGrid in this.gridMedikamenteBestellen.Rows)
                {

                    if (rFoundInGrid.IsGroupByRow)
                    {
                        if (rFoundInGrid.Expanded == true)
                            this.doActionGrid_rek(ref lstData, rFoundInGrid, TypActionGrid, ref tRezepteBestSelected, bPar);
                    }
                    else
                    {
                        this.doActionGridGetRow(ref lstData, TypActionGrid, rFoundInGrid, ref tRezepteBestSelected, bPar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.doActionGrid: " + ex.ToString());
            }
        }
        public void doActionGrid_rek(ref List<PMDS.DB.PMDSBusiness.cField> lstData, UltraGridRow rFoundInGridParent,
                                            eTypActionGrid TypActionGrid,
                                            ref List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected, bool bPar)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.doActionGrid_rek(ref lstData, rFoundInGrid, TypActionGrid, ref tRezepteBestSelected, bPar);
                        }
                        else
                        {
                            this.doActionGridGetRow(ref lstData, TypActionGrid, rFoundInGrid, ref tRezepteBestSelected, bPar);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.doActionGrid_rek: " + ex.ToString());
            }
        }
        public void doActionGridGetRow(ref List<PMDS.DB.PMDSBusiness.cField> lstData, eTypActionGrid TypActionGrid,
                                        UltraGridRow rFoundInGrid,
                                        ref List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected, bool bPar)
        {
            try
            {
                if (TypActionGrid == eTypActionGrid.DeleteSelectedRows)
                {
                    if (((bool)rFoundInGrid.Cells["Select"].Value))
                    {
                        PMDS.db.Entities.vRezeptBestellung2 rvRezeptBestellungSelected = (PMDS.db.Entities.vRezeptBestellung2)rFoundInGrid.ListObject;

                        PMDS.DB.PMDSBusiness.cField cNewField = new DB.PMDSBusiness.cField();
                        cNewField.ID = rvRezeptBestellungSelected.rbp_ID;
                        lstData.Add(cNewField);

                        if (tRezepteBestSelected != null)
                        {
                            tRezepteBestSelected.Add(rvRezeptBestellungSelected);
                        }
                    }
                }
                else if (TypActionGrid == eTypActionGrid.SelectAllNone)
                {
                    rFoundInGrid.Cells["Select"].Value = bPar;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteBestellen.doActionGridGetRow: " + ex.ToString());
            }
        }
        public void SelectAllNone(int iAll, bool EditOn)
        {
            try
            {
                if (iAll == 1)
                {
                    this.lblAllNone.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");
                    this.lblAllNone.Tag = 1;
                    
                    List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                    List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected = new List<db.Entities.vRezeptBestellung2>();
                    this.doActionGrid(ref lstData, eTypActionGrid.SelectAllNone, ref tRezepteBestSelected, true);
                }
                else
                {
                    this.lblAllNone.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                    this.lblAllNone.Tag = 0;
                    
                    List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                    List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected = new List<db.Entities.vRezeptBestellung2>();
                    this.doActionGrid(ref lstData, eTypActionGrid.SelectAllNone, ref tRezepteBestSelected, false);
                }

                if (EditOn)
                {
                    this.btnMedikamenteBestellen.Enabled = true;
                    this.btnRezepteAnfordern.Enabled = true;
                    this.btnUndo.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void gridMedikamenteBestellen_AfterCellActivate(object sender, EventArgs e)
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
                this.Cursor = Cursors.Default;
            }
        }
        private void gridMedikamenteBestellen_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().Equals("Select", StringComparison.CurrentCultureIgnoreCase) ||
                        e.Cell.Column.ToString().Trim().Equals("Packungsanzahl", StringComparison.CurrentCultureIgnoreCase))
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                    else
                    {
                         e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 
                    }
                    if (PMDS.Global.ENV.adminSecure)
                    {
                        if (e.Cell.Column.ToString().Trim().Equals("GedrucktJN", StringComparison.CurrentCultureIgnoreCase) ||
                            e.Cell.Column.ToString().Trim().Equals("DatumBestellt", StringComparison.CurrentCultureIgnoreCase) ||
                            e.Cell.Column.ToString().Trim().Equals("Packungsanzahl", StringComparison.CurrentCultureIgnoreCase))
                        {
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
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
                this.Cursor = Cursors.Default;
            }
        }
        private void gridMedikamenteBestellen_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.btnMedikamenteBestellen.Enabled = true;
                this.btnRezepteAnfordern.Enabled = true;
                this.btnUndo.Enabled = true;
                this.btnAbort.Enabled = true;
                this.btnSave.Enabled = true;

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
        private void gridMedikamenteBestellen_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
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
                this.Cursor = Cursors.Default;
            }
        }
        private void gridMedikamenteBestellen_Click(object sender, EventArgs e)
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
                this.Cursor = Cursors.Default;
            }
        }
        private void gridMedikamenteBestellen_DoubleClick(object sender, EventArgs e)
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
                this.Cursor = Cursors.Default;
            }
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.LoadData();
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.LoadData();
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


        private void cboAbteilung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboAbteilung.Focused)
                {
                    this.LoadData();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void optBestellt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optBestellt.Focused)
                {
                    this.LoadData();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void optDringend_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optDringend.Focused)
                {
                    this.LoadData();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }



        private void btnClearAbteilung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.cboAbteilung.Value = null;
                this.LoadData();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.DeleteRows();
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
        
        private void lblAllNone_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (((int)this.lblAllNone.Tag) == 1)
                {
                    this.SelectAllNone(0, true);
                }
                else
                {
                    this.SelectAllNone(1, true);
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

        private void optRezeptAngefordertJN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optRezeptAngefordertJN.Focused)
                {
                    this.LoadData();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnRezepteanforderungsliste_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.PrintBestellung(PMDS.Print.frmPrintPreview.eTypReportMedikamenteBestellen.Rezeptanforderungsliste);
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
        private void btnRezepteDrucken_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.PrintBestellung(PMDS.Print.frmPrintPreview.eTypReportMedikamenteBestellen.RezeptDrucken);
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
        private void btnMedikamentenbestellliste_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.PrintBestellung(PMDS.Print.frmPrintPreview.eTypReportMedikamenteBestellen.Medikamentenbestellliste);
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

        private void btnRezepteAnfordern_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.SaveData(true, eTypSaveMedikamente.RezeptAnfordern))
                {
                    this.LoadData();
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
        private void btnMedikamenteBestellen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.SaveData(true, eTypSaveMedikamente.MedikamenteBestellen))
                {
                    this.LoadData();
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

        private void datRezeptanforderung_Leave(object sender, EventArgs e)
        {
            QS2.Desktop.ControlManagment.BaseDateTimeEditor datObj = (QS2.Desktop.ControlManagment.BaseDateTimeEditor)sender;
            if (datObj.Focused)
            {
                this.LoadData();
            }
        }

        private void lblOffeneAnforderungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ClearUI(true, false, false, false, false);
                this.LoadData();
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
        private void lblAngeforderteRezepte_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ClearUI(false, true, false,false, false);
                this.LoadData();
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
        private void lblOffeneBestellungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ClearUI(false, false, true, false, false);
                this.LoadData();
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
        private void lblBestellteMedikamente_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ClearUI(false, false, false, false, true);
                this.LoadData();
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

        private void optGedrucktJN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optGedrucktJN.Focused)
                {
                    this.LoadData();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.LoadData();
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

                if (this.SaveDataGrid())
                {
                    this.btnSave.Enabled = false;
                    this.btnAbort.Enabled = false;
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

        private void btnTerminErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl)
                {
                    if (PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Count != 1)
                    {
                        throw new Exception("btnTerminErstellen_Click: PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Count!=1 not allowed!");
                    }
                    Guid IDAufenthaltAct = PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt[0];
                    GuiAction.InsertTermin(IDAufenthaltAct, false, (Form)GuiWorkflow.mainWindow, null, null, null);
                }
                else
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    PMDS.db.Entities.vRezeptBestellung2 rSelRow = this.getSelectedRow(true, ref gridRow);
                    if (rSelRow != null)
                    {
                        GuiAction.InsertTermin(rSelRow.IDAufenthalt.Value, false, (Form)GuiWorkflow.mainWindow, null, null, null);
                    }
                }
   
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public PMDS.db.Entities.vRezeptBestellung2 getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridMedikamenteBestellen.ActiveRow != null)
                {
                    if (this.gridMedikamenteBestellen.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        PMDS.db.Entities.vRezeptBestellung2 rSelRow = (PMDS.db.Entities.vRezeptBestellung2)this.gridMedikamenteBestellen.ActiveRow.ListObject;
                        //PMDS.db.Entities.vRezeptBestellun rSelRow = (PMDS.db.Entities.vRezeptBestellung2)v.Row;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed4Bestellen.getSelectedRow: " + ex.ToString());
            }
        }

    }
}
