using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.DB;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;


namespace PMDS.GUI.Kostentraeger
{
    public partial class ucKostentraegerKlientEditSingle : UserControl
    {
        public frmKostentraegerKlientEditSingle mainWindow { get; set; }
        public bool FSWMode { get; set; }
        public bool abort { get; set; } = true;

        private Guid _IDPatient;
        private Nullable<Guid> _IDKostenträger;
        private Nullable<Guid> _IDPatientKostenträger;

        private PMDS.db.Entities.Kostentraeger _rKostenträger;
        private PMDS.db.Entities.PatientKostentraeger _rPatientKostentraeger;

        private bool _isNew;
        private  bool IsInitialized;
        private eTypeUI _TypeUI;
        private bool _EVMode;

        private PMDS.db.Entities.ERModellPMDSEntities _db;
        private PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        private PMDSBusinessUI b3 = new PMDSBusinessUI();
        private PMDS.UI.Sitemap.UIFct UIFct1 = new PMDS.UI.Sitemap.UIFct();

        private string tmpCompany = "";

        public enum eTypeUI
        {
            Klient = 0,
            Kostenträger = 1
        }

        public bool _abortNoAufenthalt;


        public ucKostentraegerKlientEditSingle()
        {
            InitializeComponent();
        }
        private void ucKostentraegerKlientEditSingle_Load(object sender, EventArgs e)
        {

        }

        public void initControl(eTypeUI TypeUI)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._TypeUI = TypeUI;

                    this.mainWindow.AcceptButton = this.btnSave;
                    this.mainWindow.CancelButton = this.btnAbort;

                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                    this._db = PMDSBusiness.getDBContext();
                    this.b3.getAllUsersCbo(this.cboIDBenutzer, this._db);
                    this.b3.getAllKostentraegerCbo(this.cboIDKostentraegerSub, this._db, true);
                    this.UIFct1.fillEnumBillTyp(this.cboRechnungTyp, false, false);
                    this.b3.loadZahlartCbo(this.cboZahlart);
                    this.b3.loadRechnungsdruckTypCbo(this.cboRechnungsdruckTyp1);

                    this.clearUI();
                    this.setUI();

                    this.IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtKostentraeger.Text = "";
                this.txtBank.Text = "";
                this.txtKontonr.Text = "";
                this.txtBLZ.Text = "";
                this.txtFIBUKonto.Text = "";
                this.cboZahlart.Value = null;
                this.chkErlagscheingebuehrJN.Checked = false;
                this.numErlagscheingebuehr.Value = 0;

                this.udteGueltigAb.Value = null;
                this.udteGueltigBis.Value = null;
                this.udteErfasstAm.Value = null;
                this.cboIDBenutzer.Value = null;
                this.cboIDKostentraegerSub.Value = null;
                this.cboEnumKostentraegerart.Value = null;
                this.chkBetragErrechnetJN.Checked = false;
                this.numBetrag.Value = 0;
                this.chkVorauszahlungJN.Checked = false;
                this.chkRechnungJN.Checked = false;
                this.cboRechnungTyp.Value = null;
                this.cboRechnungsdruckTyp1.Value = null;

                this.txtAnrede.Text = "";
                this.txtStrasse.Text = "";
                this.txtPLZ.Text = "";
                this.txtOrt.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.clearUI: " + ex.ToString());
            }
        }
        public void setUI()
        {
            try
            {

                this.chkVorauszahlungJN.Visible = false;

                if (this._TypeUI == eTypeUI.Klient)
                {
                    this.txtBank.ReadOnly = false;
                    this.txtKontonr.ReadOnly = false;
                    this.txtBLZ.ReadOnly = false;
                    this.txtFIBUKonto.ReadOnly = false;
                    this.cboZahlart.ReadOnly = false;
                }
                else if (this._TypeUI == eTypeUI.Kostenträger)
                {
                    this.txtBank.ReadOnly = true;
                    this.txtKontonr.ReadOnly = true;
                    this.txtBLZ.ReadOnly = true;
                    this.txtFIBUKonto.ReadOnly = true;
                    this.cboZahlart.ReadOnly = true;
                }
                else
                {
                    throw new Exception("setUI: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                }

                this.udteGueltigAb.ReadOnly = false;
                this.udteGueltigBis.ReadOnly = false;
                this.udteErfasstAm.ReadOnly = false;
                this.udteErfasstAm.Enabled = false;
                this.cboIDBenutzer.ReadOnly = true;
                this.cboIDKostentraegerSub.ReadOnly = false;
                this.cboEnumKostentraegerart.ReadOnly = false;
                this.chkBetragErrechnetJN.Enabled = true;
                this.numBetrag.ReadOnly = false;
                this.chkRechnungJN.Enabled = true;
                this.cboRechnungTyp.ReadOnly = true;
                this.cboRechnungsdruckTyp1.ReadOnly = false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.setUI: " + ex.ToString());
            }
        }

        public bool loadData(Guid IDPatient, Nullable<Guid> IDKostenträger, Nullable<Guid> IDPatientKostenträger, bool isNew, bool FSWMode, bool EVMode)
        {
            try
            {
                this._IDPatient = IDPatient;
                this._IDPatientKostenträger = IDPatientKostenträger;
                this._IDKostenträger = IDKostenträger;
                this._isNew = isNew;
                this.FSWMode = FSWMode;
                this._EVMode = EVMode;

                DateTime dNow = DateTime.Now;
                PMDS.db.Entities.Patient rPatient = this.b.getPatient(IDPatient, this._db);
                PMDS.db.Entities.Aufenthalt rAufenthaltAct = this.b.getAktuellerAufenthaltPatient(IDPatient, true, this._db);
                if (this._isNew &&  rAufenthaltAct == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für Klienten ohne aktuellen Aufenthalt ist diese Funktion nicht möglich. Bitte legen Sie einen Kostenträger an und ordnen Sie den Klienten zu.", "", MessageBoxButtons.OK);
                    this.mainWindow.Close();
                    this._abortNoAufenthalt = true;
                    return false;
                }

                bool WohnungAbgemeldetJNTmp = false;
                if (rPatient.WohnungAbgemeldetJN != null && rPatient.WohnungAbgemeldetJN.Value)
                {
                    WohnungAbgemeldetJNTmp = true;
                }

                PMDS.db.Entities.Adresse rAdresse = null;
                if (!WohnungAbgemeldetJNTmp)
                {
                    if (rPatient.IDAdresse != null)
                    {
                        rAdresse = this.b.getAdresse(rPatient.IDAdresse.Value, this._db);
                    }
                    else if (rPatient.IDAdresseSub != null)
                    {
                        rAdresse = this.b.getAdresse(rPatient.IDAdresseSub.Value, this._db);
                    }
                    if (rAdresse == null)
                    {
                        PMDS.db.Entities.Klinik rKlinik = this.b.getKlinik(ENV.IDKlinik, this._db);
                        if (rKlinik.IDAdresse != null)
                        {
                            rAdresse = this.b.getAdresse(rKlinik.IDAdresse.Value, this._db);
                        }
                    }
                }
                else
                {
                    PMDS.db.Entities.Klinik rKlinik = this.b.getKlinik(ENV.IDKlinik, this._db);
                    if (rKlinik.IDAdresse != null)
                    {
                        rAdresse = this.b.getAdresse(rKlinik.IDAdresse.Value, this._db);
                    }
                }

                if (isNew)
                {                    
                    this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, true, false, false, this._db);

                    //Klient selbst als Kostenträger
                    this._rKostenträger = PMDS.Global.db.ERSystem.EFEntities.newKostentraeger(this._db);
                    this._rPatientKostentraeger = PMDS.Global.db.ERSystem.EFEntities.newPatientKostentraeger(this._db);

                    this._rKostenträger.ID = System.Guid.NewGuid();
                    this._rKostenträger.Anrede = rPatient.Titel.Trim();
                    this._rKostenträger.Name = rPatient.Nachname.Trim();
                    this._rKostenträger.Vorname = rPatient.Vorname.Trim();
                    this.txtKostentraeger.Text = (this._rKostenträger.Anrede + " " + this._rKostenträger.Name + " " + this._rKostenträger.Vorname).Trim();
                    this._rKostenträger.FIBUKonto = rPatient.Klientennummer == null ? "" : rPatient.Klientennummer.Trim();
                    this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.Überweisung;
                    this._rKostenträger.PatientbezogenJN = true;
                    this._rKostenträger.IDPatient = this._IDPatient;
                    this._rKostenträger.IDKlinik = ENV.IDKlinik;
                    this._rKostenträger.PLZ = rAdresse.Plz.Trim();
                    this._rKostenträger.Ort = rAdresse.Ort.Trim();
                    this._rKostenträger.Strasse = rAdresse.Strasse.Trim();
                    this._rKostenträger.IDPatientIstZahler = null;
                    this._rKostenträger.GSBG = 0;
                    this._rKostenträger.ErlagscheingebuehrJN = false;
                    this._rKostenträger.Betrag = 0;

                    this._rPatientKostentraeger.ID = System.Guid.NewGuid();
                    this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Alles;
                    this._rPatientKostentraeger.GueltigAb = rAufenthaltAct.Aufnahmezeitpunkt.Value.Date;
                    this._rPatientKostentraeger.BetragErrechnetJN = true;
                    this._rPatientKostentraeger.RechnungJN = true;
                    this._rPatientKostentraeger.RechnungTyp = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
                    this._rPatientKostentraeger.RechnungsdruckTyp = (int)PMDS.Global.RechnungsdruckTyp.NurZahler;
                    this._rPatientKostentraeger.Betrag = 0;
                    this._rPatientKostentraeger.IDPatient = this._IDPatient;
                    this._rPatientKostentraeger.IDKostentraeger = this._rKostenträger.ID;
                    this._rPatientKostentraeger.ErfasstAm = dNow;
                    this._rPatientKostentraeger.IDBenutzer = ENV.USERID;
                    this._rPatientKostentraeger.IDPatientIstZahler = rPatient.ID;

                   if (FSWMode)    //Kostenträger = Klient mit Forderungsabtretung an FSW. 2021-10-11: wird nicht mehr verwendet
                    {
                        this._rKostenträger.GSBG = ENV.FSW_Prozent;
                        this._rKostenträger.PatientbezogenJN = false;
                        this._rKostenträger.IDKostentraegerSub = ENV.FSW_IDIntern;
                        this._rKostenträger.Rechnungsempfaenger = "(FSW)";
                        this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Grundkosten;
                        this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.FSW;
                        this._rPatientKostentraeger.IDPatientIstZahler = null;
                    }

                    else if (EVMode)     //Kostenträger ist Erwachsenenvertreter
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            var lEV = (from rSach in db.Sachwalter
                                       join rAdd in db.Adresse on rSach.IDAdresse equals rAdd.ID
                                       join rKon in db.Kontakt on rSach.IDKontakt equals rKon.ID
                                       where rSach.IDPatient == this._IDPatient && rSach.Von != null && !String.IsNullOrEmpty(rKon.Zusatz3)
                                       select new { Nachname = rSach.Nachname.Trim(),
                                           Vorname = rSach.Vorname.Trim(),
                                           Titel = rSach.Titel.Trim(),
                                           PLZ = rAdd.Plz.Trim(),
                                           Ort = rAdd.Ort.Trim(),
                                           Strasse = rAdd.Strasse.Trim(),
                                           GueltigAb = rSach.Von,
                                           Belange = rSach.Belange.Trim(),
                                           Gericht = rSach.Gericht.Trim(),
                                           FiBu = rKon.Zusatz3.Trim(),
                                           Anrede = rSach.Titel.Trim(),
                                           Company = rKon.Zusatz1.ToString().Trim()
                                       }).ToList();
                            if (lEV.Count == 1)
                            {
                                this._rKostenträger.Anrede = lEV.First().Titel;
                                this._rKostenträger.Name = lEV.First().Nachname;
                                this._rKostenträger.Vorname = lEV.First().Vorname;
                                this.txtKostentraeger.Text = (this._rKostenträger.Vorname + " " + this._rKostenträger.Name).Trim();
                                this._rKostenträger.FIBUKonto = lEV.First().FiBu;
                                this._rKostenträger.PatientbezogenJN = true;
                                this._rKostenträger.IDPatient = this._IDPatient;
                                this._rKostenträger.IDKlinik = ENV.IDKlinik;
                                this._rKostenträger.PLZ = lEV.First().PLZ.Trim();
                                this._rKostenträger.Ort = lEV.First().Ort.Trim();
                                this._rKostenträger.Strasse = lEV.First().Strasse.Trim();
                                this._rKostenträger.IDPatientIstZahler = null;
                                this._rKostenträger.GSBG = 0;
                                this._rKostenträger.IDKostentraegerSub = null;
                                tmpCompany = lEV.First().Company;

                                string sPatName = (rPatient.Titel + " " + rPatient.Vorname.Trim() + " " + rPatient.Nachname.Trim()).Trim();
                                //this._rKostenträger.Rechnungsempfaenger = "(Erwachsenenvertreter für " + sPatName + ")";

                                this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Alles;
                                this._rPatientKostentraeger.RechnungTyp = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
                                this._rPatientKostentraeger.ID = System.Guid.NewGuid();
                                this._rPatientKostentraeger.GueltigAb = (DateTime)lEV.First().GueltigAb;
                                this._rPatientKostentraeger.BetragErrechnetJN = true;
                                this._rPatientKostentraeger.RechnungJN = true;
                                this._rPatientKostentraeger.Betrag = 0;
                                this._rPatientKostentraeger.IDPatient = this._IDPatient;
                                this._rPatientKostentraeger.IDKostentraeger = this._rKostenträger.ID;
                                this._rPatientKostentraeger.ErfasstAm = dNow;
                                this._rPatientKostentraeger.IDBenutzer = ENV.USERID;
                                this._rPatientKostentraeger.IDPatientIstZahler = null;

                                //if (ENV.FSW_IDIntern != Guid.Empty)   //automatische Forderungsabtretung an FSW, wenn FSW-ID angegeben ist
                                //{
                                //    this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Grundkosten;
                                //    this._rKostenträger.PatientbezogenJN = false;
                                //    this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.FSW;
                                //    this._rKostenträger.GSBG = ENV.FSW_Prozent;
                                //    this._rKostenträger.Rechnungsempfaenger = "(Fond Soziales Wien)";
                                //    this._rKostenträger.IDKostentraegerSub = ENV.FSW_IDIntern;
                                //}
                                //else
                                //{
                                //    this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.Überweisung;
                                //    this._rKostenträger.Rechnungsempfaenger = "";
                                //}
                                this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.Überweisung;
                            }
                            else
                            {
                                string sMessage = "";
                                if (lEV.Count == 0)
                                    sMessage = "Es wurde kein Erwachsenenvertreter mit befülltem Gültig-Ab und FiBu-Konto gefunden.";
                                else
                                    sMessage = "Es wurden " + lEV.Count.ToString() +  "Erwachsenenvertreter mit befülltem Gültig-Ab und FiBu-Konto gefunden.";
                                sMessage += "\nDie Funktion kann nicht fortgesetzt werden.";
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMessage);
                                this._db.Dispose();
                                return false;
                            }
                        }
                    }

                    this._db.Kostentraeger.Add(this._rKostenträger);
                    this._db.PatientKostentraeger.Add(this._rPatientKostentraeger);
                }
                else
                {
                    var rKostenträger = (from pk in this._db.PatientKostentraeger
                                            join k in this._db.Kostentraeger on pk.IDKostentraeger equals k.ID
                                            where pk.ID == IDPatientKostenträger && pk.IDPatient == IDPatient
                                            select new
                                            {
                                                k.ID,                                                
                                                k.Name,
                                                k.Vorname,
                                                pk.IDPatientIstZahler,
                                                IDPatientKostenträger = pk.ID,
                                                pk.IDPatient,
                                                k.TransferleistungJN,
                                                k.PatientbezogenJN,
                                                k.IDKostentraegerSub,
                                                k.GSBG,
                                                k.Rechnungsempfaenger,
                                                k.Betrag,
                                                k.FIBUKonto
                                            }).First();

                    tmpCompany = "";
                    string[] arr = rKostenträger.Rechnungsempfaenger.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2 && generic.sEquals(arr[0], "(EV", Enums.eCompareMode.StartsWith))   //Erwachsenenvertreter bei Company: Company einlesen
                    {
                        tmpCompany = arr[1].Trim();                            
                    }

                    this._EVMode = generic.sEquals(rKostenträger.Rechnungsempfaenger, "(EV", Enums.eCompareMode.StartsWith);


                    this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, false, rKostenträger.TransferleistungJN, rKostenträger.PatientbezogenJN, this._db);

                    IQueryable<PMDS.db.Entities.Kostentraeger> tKostentraeger = this._db.Kostentraeger.Where(b => b.ID == IDKostenträger);
                    this._rKostenträger = tKostentraeger.First();                

                    IQueryable < PMDS.db.Entities.PatientKostentraeger > tPatientKostentraeger = this._db.PatientKostentraeger.Where(b => b.ID == IDPatientKostenträger);
                    this._rPatientKostentraeger = tPatientKostentraeger.First();
                }

                //Controls füllen und setzen
                this.txtAnrede.Text = _rKostenträger.Anrede.Trim();
                this.txtKostentraeger.Text = _rKostenträger.Vorname + " " + _rKostenträger.Name;
                this.txtBank.Text = this._rKostenträger.Bank.Trim();
                this.txtKontonr.Text = this._rKostenträger.Kontonr.Trim();
                this.txtBLZ.Text = this._rKostenträger.BLZ.Trim();
                this.txtFIBUKonto.Text = this._rKostenträger.FIBUKonto.Trim();
                this.txtPLZ.Text = this._rKostenträger.PLZ.Trim();
                this.txtOrt.Text = this._rKostenträger.Ort.Trim();
                this.txtStrasse.Text = this._rKostenträger.Strasse.Trim();
                this.cboZahlart.Value = this._rKostenträger.Zahlart ??  null;
                this.cboRechnungsdruckTyp1.Value = this._rPatientKostentraeger.RechnungsdruckTyp;

                this.chkErlagscheingebuehrJN.Checked = this._rKostenträger.ErlagscheingebuehrJN;
                this.numErlagscheingebuehr.Value = this._rKostenträger.Betrag;
                this.setUIErlagscheingebührJN();

                if (this._rPatientKostentraeger.GueltigAb != null)
                    this.udteGueltigAb.DateTime = this._rPatientKostentraeger.GueltigAb.Date;
                else
                    this.udteGueltigAb.Value = null;

                if (this._rPatientKostentraeger.GueltigBis != null)
                    this.udteGueltigBis.DateTime = this._rPatientKostentraeger.GueltigBis.Value.Date;
                else
                    this.udteGueltigBis.Value = null;

                if (this._rPatientKostentraeger.ErfasstAm != null)
                    this.udteErfasstAm.DateTime = this._rPatientKostentraeger.ErfasstAm.Value.Date;
                else
                    this.udteErfasstAm.Value = null;

                this.cboIDBenutzer.Value = this._rPatientKostentraeger.IDBenutzer;
                this.cboEnumKostentraegerart.Value = this._rPatientKostentraeger.enumKostentraegerart;

                if (this._rPatientKostentraeger.Kostentraeger != null)
                    this.cboIDKostentraegerSub.Value = this._rPatientKostentraeger.Kostentraeger.IDKostentraegerSub;
                else if (FSWMode)
                {
                    this.cboIDKostentraegerSub.Value = ENV.FSW_IDIntern;
                    this.cboEnumKostentraegerart.Value = (int)Kostentraegerart.Grundkosten;
                }
                //else if (EVMode && ENV.FSW_IDIntern != Guid.Empty)
                //{
                //    this.cboIDKostentraegerSub.Value = ENV.FSW_IDIntern;
                //    this.cboEnumKostentraegerart.Value = (int)Kostentraegerart.Grundkosten;
                //}

                this.chkBetragErrechnetJN.Checked = this._rPatientKostentraeger.BetragErrechnetJN;
                
                if (this._rPatientKostentraeger.Betrag != null)
                    this.numBetrag.Value = this._rPatientKostentraeger.Betrag.Value;
                else
                    this.numBetrag.Value = 0;

                this.chkVorauszahlungJN.Checked = this._rPatientKostentraeger.VorauszahlungJN;
                this.chkRechnungJN.Checked = this._rPatientKostentraeger.RechnungJN;
                this.cboRechnungTyp.Value = this._rPatientKostentraeger.RechnungTyp;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.loadData: " + ex.ToString());
            }
        }

        public void setUIErlagscheingebührJN()
        {
            try
            {
                this.chkErlagscheingebuehrJN.Visible = (int)this.cboZahlart.Value == (int)PMDS.Calc.Logic.eZahlart.Erlagschein;

                if (!this.chkErlagscheingebuehrJN.Visible)
                {
                    this.chkErlagscheingebuehrJN.Checked = false;
                }
                this.chkErlagscheingebuehrJN_CheckedChanged(this, new EventArgs());                
            }
            catch (Exception ex)
            {
                throw new Exception("setUIErlagscheingebührJN.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.txtBank, "");
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.clearErrorProvider: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                if (this.udteGueltigAb.Value == null)
                {
                    this.errorProvider1.SetError(this.udteGueltigAb, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.udteGueltigAb.Focus();
                    return false;
                }
                if (String.IsNullOrWhiteSpace(this.txtFIBUKonto.Text))
                {
                    this.errorProvider1.SetError(this.txtFIBUKonto, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("FIBU: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.txtFIBUKonto.Focus();
                    return false;
                }

                if (String.IsNullOrWhiteSpace(this.txtPLZ.Text))
                {
                    this.errorProvider1.SetError(this.txtPLZ, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("PLZ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.txtPLZ.Focus();
                    return false;
                }
         
                if (String.IsNullOrWhiteSpace(this.txtOrt.Text))
                {
                    this.errorProvider1.SetError(this.txtOrt, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.txtOrt.Focus();
                    return false;
                }
                
                if (String.IsNullOrWhiteSpace(this.txtStrasse.Text))
                {
                    this.errorProvider1.SetError(this.txtStrasse, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Strasse: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.txtStrasse.Focus();
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    Guid IDKostenträgerNot = System.Guid.NewGuid();
                    if (this._rKostenträger.ID != null)
                    {
                        IDKostenträgerNot = this._rKostenträger.ID;
                    }
                    string FIBUCheck = this.txtFIBUKonto.Text.Trim();

                    var tKostentraeger = (from k in db.Kostentraeger
                               where k.ID != IDKostenträgerNot && k.FIBUKonto == FIBUCheck
                                          select new
                               {
                                    ID = k.ID,
                                    Name = k.Name,
                                   FIBUKonto = k.FIBUKonto
                               });

                    if (tKostentraeger.Any())
                    {
                        this.errorProvider1.SetError(this.txtFIBUKonto, "Error");
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("FIBU existiert bereits!\nWollen Sie den Datensatz trotzdem speichern?", "", MessageBoxButtons.OKCancel);
                        this.txtFIBUKonto.Focus();

                        if (res == DialogResult.OK)
                            return true;
                        else
                            return false;
                    }

                    //Prüfen, ob Rechnungsdrucktyp pro Kostenträger zu Klient eindeutig ist.
                    var lRechnungsdrucktypenAll = (from pk in db.PatientKostentraeger
                             where pk.IDKostentraeger == this._rKostenträger.ID && pk.IDPatient == this._rPatientKostentraeger.IDPatient                             
                             select new
                             {
                                 pk.RechnungsdruckTyp
                             }).ToList();
                    var lRechnungsdrucktypen = lRechnungsdrucktypenAll.GroupBy(test => test.RechnungsdruckTyp).Select(grp => grp.First()).ToList();  //Distinct RechnungsdruckTyp

                    if (lRechnungsdrucktypen.Count != 0)
                    {
                        if (lRechnungsdrucktypen.Count > 1)
                        {
                            this.errorProvider1.SetError(this.cboRechnungTyp, "Error");
                            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden unterschiedliche Rechnungsdrucktypen gefunden.\nBitte korrigieren Sie die Einträge, damit ein einheitlicher Rechnungsdrucktyp gewährleistet ist.\n\nWollen Sie den Datensatz trotzdem speichern?\nDies würde zu fehlenden oder zu vielen Rechnungen im Rechnungsversandmodus führen!", "", MessageBoxButtons.OKCancel);
                            this.cboRechnungsdruckTyp1.Focus();

                            if (res == DialogResult.OK)
                                return true;
                            else
                                return false;
                        }

                        else if (lRechnungsdrucktypen.Count == 1 && lRechnungsdrucktypen.First().RechnungsdruckTyp != (int)this.cboRechnungsdruckTyp1.Value)
                        {
                            this.errorProvider1.SetError(this.cboRechnungsdruckTyp1, "Error");
                            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der angegebene Rechnungsdrucktyp unterscheidet sich von den bisher zugeordneten. Wollen Sie den Datensatz trotzdem speichern?\n\nDies würde zu fehlenden oder zu vielen Rechnungen im Rechnungsversandmodus führen!", "", MessageBoxButtons.OKCancel);
                            this.cboRechnungsdruckTyp1.Focus();

                            if (res == DialogResult.OK)
                                return true;
                            else
                                return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.validateData: " + ex.ToString());
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

                //Rechnungsempfänger festlegen                 
                if (!this._EVMode)  //Klient = Zahler
                {
                    if ((int)cboZahlart.Value == (int)PMDS.Calc.Logic.eZahlart.FSW)
                    {
                        this._rKostenträger.Rechnungsempfaenger = "(FSW)";
                    }
                    else
                    {
                        this._rKostenträger.Rechnungsempfaenger = "";
                    }
                }
                else    //Erwachsenenvertreter ist Zahler
                {
                    string tmpRechnungsempfänger = "";
                    if (!String.IsNullOrWhiteSpace(tmpCompany))
                    {
                        tmpRechnungsempfänger = " | " + tmpCompany;
                    }

                    string tmpFSW = "(EV)";

                    if ((int)cboZahlart.Value == (int)PMDS.Calc.Logic.eZahlart.FSW)
                    {
                        tmpFSW = "(EV->FSW)";
                    }
                    this._rKostenträger.Rechnungsempfaenger = (tmpFSW + tmpRechnungsempfänger).Substring(0,Math.Min(50, (tmpFSW + tmpRechnungsempfänger).Length));  //Feldlänge max. 50 Zeichen in DB
                }

                this._rKostenträger.Anrede = this.txtAnrede.Text.Trim();
                this._rKostenträger.Bank = this.txtBank.Text.Trim();
                this._rKostenträger.Kontonr =  this.txtKontonr.Text.Trim();
                this._rKostenträger.BLZ = this.txtBLZ.Text.Trim();
                this._rKostenträger.FIBUKonto = this.txtFIBUKonto.Text.Trim();
                this._rKostenträger.PLZ = this.txtPLZ.Text.Trim();
                this._rKostenträger.Ort = this.txtOrt.Text.Trim();
                this._rKostenträger.Strasse = this.txtStrasse.Text.Trim();

                this._rKostenträger.Zahlart = (int)this.cboZahlart.Value;
                this._rKostenträger.ErlagscheingebuehrJN = this.chkErlagscheingebuehrJN.Checked;
                this._rKostenträger.Betrag = Convert.ToDouble(this.numErlagscheingebuehr.Value);

                this._rPatientKostentraeger.GueltigAb = this.udteGueltigAb.DateTime.Date;
                if (this.udteGueltigBis.Value != null)
                {
                    this._rPatientKostentraeger.GueltigBis = this.udteGueltigBis.DateTime.Date;
                }
                else
                {
                    this._rPatientKostentraeger.GueltigBis = null;
                }
                this._rPatientKostentraeger.ErfasstAm = this.udteErfasstAm.DateTime;
                this._rPatientKostentraeger.IDBenutzer = (Guid)this.cboIDBenutzer.Value;
                this._rPatientKostentraeger.enumKostentraegerart = (int)this.cboEnumKostentraegerart.Value;
                this._rPatientKostentraeger.BetragErrechnetJN = this.chkBetragErrechnetJN.Checked;
                this._rPatientKostentraeger.Betrag = (decimal)this.numBetrag.Value;
                this._rPatientKostentraeger.VorauszahlungJN = this.chkVorauszahlungJN.Checked;
                this._rPatientKostentraeger.RechnungJN = this.chkRechnungJN.Checked;
                this._rPatientKostentraeger.RechnungTyp = (int)this.cboRechnungTyp.Value;
                this._rPatientKostentraeger.RechnungsdruckTyp = (int)this.cboRechnungsdruckTyp1.Value;

                this._db.SaveChanges();

                if (this._rPatientKostentraeger.Kostentraeger != null)
                {
                    if (this.cboIDKostentraegerSub.Value == null)
                        this._rPatientKostentraeger.Kostentraeger.IDKostentraegerSub = null;
                    else
                    {
                        if (Guid.TryParse(this.cboIDKostentraegerSub.Value.ToString(), out Guid guidID))
                        {
                            this._rPatientKostentraeger.Kostentraeger.IDKostentraegerSub = (Guid)this.cboIDKostentraegerSub.Value;
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Der Kostenträger " + this.cboIDKostentraegerSub.Value + " exisitiert nicht.", System.Windows.Forms.MessageBoxButtons.OK, "Fehlerhafte Eingabe");
                            return false;
                        }
                    }
                }
                this._db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.saveData: " + ex.ToString());
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.abort = true;
                this.mainWindow.Close();

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
                    this.abort = false;
                    this.mainWindow.Close();
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

        private void cboZahlart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboZahlart.Focused)
                {

                    if (ENV.FSW_IDIntern != Guid.Empty)
                    {
                        if ((int)cboZahlart.Value == (int)PMDS.Calc.Logic.eZahlart.FSW)
                        {
                            this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, false, false, false, this._db);

                            this._rKostenträger.GSBG = ENV.FSW_Prozent;
                            //this._rKostenträger.PatientbezogenJN = false;
                            this._rKostenträger.PatientbezogenJN = true;
                            this._rKostenträger.TransferleistungJN = false;
                            this._rKostenträger.IDKostentraegerSub = ENV.FSW_IDIntern;
                            this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Grundkosten;
                            this._rPatientKostentraeger.IDPatientIstZahler = null;
                        }
                        else
                        {
                            if (_rPatientKostentraeger.enumKostentraegerart == (int)Kostentraegerart.Transferleistung)
                            {
                                //Transferkostenträger
                                this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, false, true, false, this._db);
                                this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Transferleistung;
                                this._rKostenträger.PatientbezogenJN = false;
                                this._rKostenträger.TransferleistungJN = true;
                            }
                            else
                            {
                                //Klientenbezogener Kostenträger
                                //IDSub = null
                                this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, false, false, true, this._db);
                                this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Alles;
                                this._rKostenträger.PatientbezogenJN = true;
                                this._rKostenträger.TransferleistungJN = false;
                            }

                            this._rKostenträger.GSBG = 0;
                            this._rKostenträger.IDKostentraegerSub = null;
                            this._rKostenträger.Rechnungsempfaenger = "";
                            this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.Überweisung;
                            this._rPatientKostentraeger.IDPatientIstZahler = null;
                        }

                        this.cboEnumKostentraegerart.Value = this._rPatientKostentraeger.enumKostentraegerart;
                        this.cboIDKostentraegerSub.Value = this._rKostenträger.IDKostentraegerSub;
                    }
                    this.setUIErlagscheingebührJN();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void panelKostenträger_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkVorauszahlungJN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkErlagscheingebuehrJN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkErlagscheingebuehrJN.Checked)
            {
                this.numErlagscheingebuehr.Visible = true;
                this.lblErlagscheingebuehr.Visible = true;
                this.numErlagscheingebuehr.Value = _rKostenträger.Betrag;                
            }
            else
            {
                this.numErlagscheingebuehr.Visible = false;
                this.numErlagscheingebuehr.Visible = this.numErlagscheingebuehr.Visible;
                this.numErlagscheingebuehr.Value = 0;
                this.lblErlagscheingebuehr.Visible = false;
            }
        }

        private void chkBetragErrechnetJN_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkBetragErrechnetJN.Checked)
            {
                this.lblRestzahlerBetrag.Visible = true;
                this.numBetrag.Visible = true;
            }
            else
            {
                this.lblRestzahlerBetrag.Visible = false;
                this.numBetrag.Visible = false;
                this.numBetrag.Value = 0;
            }
        }
    }
}

