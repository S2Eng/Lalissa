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
using System.Linq;
using PMDS.Global;


namespace PMDS.GUI.Kostentraeger
{   
    public partial class ucKostentraegerKlientEditSingle : UserControl
    {
        public Guid _IDPatient;
        public Nullable<Guid> _IDKostenträger;
        public Nullable<Guid> _IDPatientKostenträger;

        public PMDS.db.Entities.Kostentraeger _rKostenträger;
        public PMDS.db.Entities.PatientKostentraeger _rPatientKostentraeger;

        public bool _isNew;

        public bool abort = true;
        public bool IsInitialized;
        public eTypeUI _TypeUI;

        public frmKostentraegerKlientEditSingle mainWindow;
        public PMDS.db.Entities.ERModellPMDSEntities _db;

        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b3 = new PMDSBusinessUI();
        public PMDS.UI.Sitemap.UIFct UIFct1 = new PMDS.UI.Sitemap.UIFct();

        public bool FSWMode { get; set; }

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
                this.txtBank.Text = "";
                this.txtKontonr.Text = "";
                this.txtBLZ.Text = "";
                this.txtFIBUKonto.Text = "";
                this.cboZahlart.Value = null;
                this.chkErlagscheingebuehrJN.Checked = false;

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
                if (this._TypeUI == eTypeUI.Klient)
                {
                    this.txtBank.ReadOnly = false;
                    this.txtKontonr.ReadOnly = false;
                    this.txtBLZ.ReadOnly = false;
                    this.txtFIBUKonto.ReadOnly = false;
                    this.cboZahlart.ReadOnly = false;
                    this.chkErlagscheingebuehrJN.Enabled = false;
                }
                else if (this._TypeUI == eTypeUI.Klient)
                {
                    this.txtBank.ReadOnly = true;
                    this.txtKontonr.ReadOnly = true;
                    this.txtBLZ.ReadOnly = true;
                    this.txtFIBUKonto.ReadOnly = true;
                    this.cboZahlart.ReadOnly = true;
                    this.chkErlagscheingebuehrJN.Enabled = false;
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
                this.chkBetragErrechnetJN.Enabled = false;
                this.numBetrag.ReadOnly = false;
                this.chkVorauszahlungJN.Enabled = false;
                this.chkRechnungJN.Enabled = false;
                this.cboRechnungTyp.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKostentraegerKlientEditSingle.setUI: " + ex.ToString());
            }
        }

        public void loadData(Guid IDPatient, Nullable<Guid> IDKostenträger, Nullable<Guid> IDPatientKostenträger, bool isNew, bool FSWMode)
        {
            try
            {
                this._IDPatient = IDPatient;
                this._IDPatientKostenträger = IDPatientKostenträger;
                this._IDKostenträger = IDKostenträger;
                this._isNew = isNew;
                this.FSWMode = FSWMode;

                DateTime dNow = DateTime.Now;
                PMDS.db.Entities.Patient rPatient = this.b.getPatient(IDPatient, this._db);
                PMDS.db.Entities.Aufenthalt rAufenthaltAct = this.b.getAktuellerAufenthaltPatient(IDPatient, true, this._db);
                if (this._isNew &&  rAufenthaltAct == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für Klienten ohne aktuellen Aufenthalt ist diese Funktion nicht möglich. Bitte legen Sie einen Kostenträger an und ordnen Sie den Klienten zu.", "", MessageBoxButtons.OK);
                    this.mainWindow.Close();
                    this._abortNoAufenthalt = true;
                    return;
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

                //this.cboIDKostentraegerSub.Enabled = !isNew;

                if (isNew)
                {                    
                    this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, true, false, false, this._db);

                    this._rKostenträger = PMDS.Global.db.ERSystem.EFEntities.newKostentraeger(this._db);
                    this._rPatientKostentraeger = PMDS.Global.db.ERSystem.EFEntities.newPatientKostentraeger(this._db);

                    this._rKostenträger.ID = System.Guid.NewGuid();
                    this._rKostenträger.Name = (rPatient.Titel + " " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + " " + rPatient.TitelPost).Trim();
                    this._rKostenträger.FIBUKonto = rPatient.Klientennummer == null ? "" : rPatient.Klientennummer.Trim();
                    this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.Überweisung;
                    this._rKostenträger.PatientbezogenJN = !FSWMode;            
                    this._rKostenträger.IDPatient = this._IDPatient;
                    this._rKostenträger.IDKlinik = ENV.IDKlinik;
                    this._rKostenträger.PLZ = rAdresse.Plz.Trim();
                    this._rKostenträger.Ort = rAdresse.Ort.Trim();
                    this._rKostenträger.Strasse = rAdresse.Strasse.Trim();
                    this._rKostenträger.IDPatientIstZahler = null;
                    this._rKostenträger.GSBG = 0;

                    this._rPatientKostentraeger.ID = System.Guid.NewGuid();
                    this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Alles;
                    this._rPatientKostentraeger.GueltigAb = rAufenthaltAct.Aufnahmezeitpunkt.Value.Date;
                    this._rPatientKostentraeger.BetragErrechnetJN = true;
                    this._rPatientKostentraeger.RechnungJN = true;
                    this._rPatientKostentraeger.RechnungTyp = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
                    this._rPatientKostentraeger.Betrag = 0;
                    this._rPatientKostentraeger.IDPatient = this._IDPatient;
                    this._rPatientKostentraeger.IDKostentraeger = this._rKostenträger.ID;
                    this._rPatientKostentraeger.ErfasstAm = dNow;
                    this._rPatientKostentraeger.IDBenutzer = ENV.USERID;
                    this._rPatientKostentraeger.IDPatientIstZahler = rPatient.ID;

                    if (FSWMode)
                    {
                        this._rKostenträger.GSBG = ENV.FSW_Prozent;
                        this._rKostenträger.Name = "FSW für " + this._rKostenträger.Name;
                        this._rKostenträger.IDKostentraegerSub = ENV.FSW_IDIntern;
                        this._rKostenträger.Rechnungsempfaenger = "Fond Soziales Wien";
                        this._rPatientKostentraeger.enumKostentraegerart = (int)Kostentraegerart.Grundkosten;
                        this._rKostenträger.Zahlart = (int)PMDS.Calc.Logic.eZahlart.FSW;
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
                                                pk.IDPatientIstZahler,
                                                IDPatientKostenträger = pk.ID,
                                                pk.IDPatient,
                                                k.TransferleistungJN,
                                                k.PatientbezogenJN,
                                                k.IDKostentraegerSub,
                                                k.GSBG,
                                                k.Rechnungsempfaenger,
                                                k.Betrag
                                            }).First();

                    this.b3.InitListKostentraegerart(this.cboEnumKostentraegerart, false, rKostenträger.TransferleistungJN, rKostenträger.PatientbezogenJN, this._db);

                    IQueryable<PMDS.db.Entities.Kostentraeger> tKostentraeger = this._db.Kostentraeger.Where(b => b.ID == IDKostenträger);
                    this._rKostenträger = tKostentraeger.First();                

                    IQueryable < PMDS.db.Entities.PatientKostentraeger > tPatientKostentraeger = this._db.PatientKostentraeger.Where(b => b.ID == IDPatientKostenträger);
                    this._rPatientKostentraeger = tPatientKostentraeger.First();
                }                

                this.txtBank.Text = this._rKostenträger.Bank.Trim();
                this.txtKontonr.Text = this._rKostenträger.Kontonr.Trim();
                this.txtBLZ.Text = this._rKostenträger.BLZ.Trim();
                this.txtFIBUKonto.Text = this._rKostenträger.FIBUKonto.Trim();
                this.txtPLZ.Text = this._rKostenträger.PLZ.Trim();
                this.txtOrt.Text = this._rKostenträger.Ort.Trim();
                this.txtStrasse.Text = this._rKostenträger.Strasse.Trim();
                this.cboZahlart.Value = this._rKostenträger.Zahlart ??  null;
                this.chkErlagscheingebuehrJN.Checked = this._rKostenträger.ErlagscheingebuehrJN;

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
                
                if (this._rPatientKostentraeger.Kostentraeger != null)
                    this.cboIDKostentraegerSub.Value = this._rPatientKostentraeger.Kostentraeger.IDKostentraegerSub;
                else if (FSWMode)
                    this.cboIDKostentraegerSub.Value = ENV.FSW_IDIntern;

                this.cboEnumKostentraegerart.Value = this._rPatientKostentraeger.enumKostentraegerart;
                this.chkBetragErrechnetJN.Checked = this._rPatientKostentraeger.BetragErrechnetJN;
                
                if (this._rPatientKostentraeger.Betrag != null)
                    this.numBetrag.Value = this._rPatientKostentraeger.Betrag.Value;
                else
                    this.numBetrag.Value = 0;

                this.chkVorauszahlungJN.Checked = this._rPatientKostentraeger.VorauszahlungJN;
                this.chkRechnungJN.Checked = this._rPatientKostentraeger.RechnungJN;
                this.cboRechnungTyp.Value = this._rPatientKostentraeger.RechnungTyp;
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
                this.chkErlagscheingebuehrJN.Checked = this.cboZahlart.Value.Equals((int)PMDS.Calc.Logic.eZahlart.Erlagschein);
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

                    if (tKostentraeger.Count() > 0)
                    {
                        this.errorProvider1.SetError(this.txtFIBUKonto, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("FIBU existiert bereits!", "", MessageBoxButtons.OK);
                        this.txtFIBUKonto.Focus();
                        return false;
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

                this._rKostenträger.Bank = this.txtBank.Text.Trim();
                this._rKostenträger.Kontonr =  this.txtKontonr.Text.Trim();
                this._rKostenträger.BLZ = this.txtBLZ.Text.Trim();
                this._rKostenträger.FIBUKonto = this.txtFIBUKonto.Text.Trim();
                this._rKostenträger.PLZ = this.txtPLZ.Text.Trim();
                this._rKostenträger.Ort = this.txtOrt.Text.Trim();
                this._rKostenträger.Strasse = this.txtStrasse.Text.Trim();

                this._rKostenträger.Zahlart = (int)this.cboZahlart.Value;
                this._rKostenträger.ErlagscheingebuehrJN = this.chkErlagscheingebuehrJN.Checked;

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
                this._rPatientKostentraeger.Betrag = this.numBetrag.Value;
                this._rPatientKostentraeger.VorauszahlungJN = this.chkVorauszahlungJN.Checked;
                this._rPatientKostentraeger.RechnungJN = this.chkRechnungJN.Checked;
                this._rPatientKostentraeger.RechnungTyp = (int)this.cboRechnungTyp.Value;

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
                    this.setUIErlagscheingebührJN();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}

