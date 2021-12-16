using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;
using PMDSClient.Sitemap;
using PMDS.Global.db.ERSystem;
using PMDS.DB;
using WCFServicePMDS.BAL2.ELGABAL;
using System.Globalization;
using S2Extensions;

namespace PMDS.GUI.ELGA
{
    public partial class contELGAKlient : UserControl
    {
        public ucKlient mainWindow { get; set; }
        public bool IsInitialized { get; set; }

        public Guid IDKlient { get; set; }
        public Guid IDAufenthalt { get; set; }
        public bool IsNeuaufnahme { get; set; }

        public UIGlobal UIGlobal1 { get; set; } = new UIGlobal();
        public WCFServiceClient WCFServiceClient1 { get; set; } = new WCFServiceClient();
        public PMDSBusiness b { get; set; } = new PMDSBusiness();

        public frmELGAKlient mainWindowAufnahme { get; set; }

        private CultureInfo ci = new CultureInfo("de-DE");

        public contELGAKlient()
        {
            InitializeComponent();
        }
        private void contELGAKlient_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool IsNeuaufnahme)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.IsNeuaufnahme = IsNeuaufnahme;

                    this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                    this.panelBottom.Visible = this.IsNeuaufnahme;
                    if (this.IsNeuaufnahme)
                    {
                        this.mainWindowAufnahme.AcceptButton = this.btnOK;
                        this.mainWindowAufnahme.CancelButton = this.btnOK;
                    }
                    this.IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.initControl: " + ex.ToString());
            }
        }

        public void loadData(Guid IDKlient, Guid IDAufenthalt)
        {
            try
            {
                this.IDKlient = IDKlient;
                this.IDAufenthalt = IDAufenthalt;

                ELGABusiness elga = new ELGABusiness();
                ELGABusiness.KlientDTO ELGAKlient = elga.GetELGAKlientByIDAufenthalt(IDAufenthalt);

                this.btnDoKontaktbestätigung.Enabled = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, false) &&
                    !ELGAKlient.ELGAKontaktbestätigungJN &&
                    !ELGAKlient.ELGASOOJN &&
                    !ELGAKlient.ELGAAbgemeldetJN &&
                    ELGABusiness.checkELGASessionActive(false);

                this.btnKoontaktbestätigungStorno.Enabled = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, false) &&
                    ELGAKlient.ELGAKontaktbestätigungJN &&
                    !ELGAKlient.ELGAAbgemeldetJN &&
                    ELGABusiness.checkELGASessionActive(false);

                this.grpSOO.Enabled = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGASituativesOptOut, false) &&
                    ELGAKlient.ELGAKontaktbestätigungJN &&
                    !ELGAKlient.ELGASOOJN &&
                    !ELGAKlient.ELGAAbgemeldetJN &&
                    ELGABusiness.checkELGASessionActive(false);

                this.chkZustimmungSOO.Checked = ELGAKlient.ELGASOOJN;
                this.chkRechteBelehrt.Checked = ELGAKlient.ELGASOOJN;
                this.chkZustimmungSOO.Enabled = !ELGAKlient.ELGASOOJN;
                this.chkRechteBelehrt.Enabled = !ELGAKlient.ELGASOOJN;



                this.txtKontaktbestätigung.Text = ELGAKlient.ELGAKontaktbestätigungJN ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum") + ": " +
                                            ELGAKlient.ELGAKontaktbestätigungDatum.ToString("dd.MM.yyyy HH:mm:ss", ci) + ", " + 
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer") + ": " + ELGAKlient.ELGAKontaktbestätigungUser.Trim() + 
                                            " - " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung hergestellt!").Trim() : "";
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.loadData: " + ex.ToString());
            }
        }

        public void doKontaktbestätigung()
        {
            try
            {
                ELGABusiness elga = new ELGABusiness();
                ELGABusiness.KlientDTO ELGAKlient = elga.GetELGAKlientByIDAufenthalt(IDAufenthalt);
                if (!ELGABusiness.checkELGASessionActive(true) || !ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, true))
                {
                    return;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rKlinik = (from k in db.Klinik
                                   where k.ID == ENV.IDKlinik
                                   select new
                                   {
                                       k.ID,
                                       k.ELGA_OID,
                                       AuthUniversalID = k.AuthUniversalID.Trim(),
                                   }).First();
                    if (String.IsNullOrWhiteSpace(rKlinik.AuthUniversalID))
                    {
                        throw new Exception("doKontaktbestätigung: rKlinik.AuthUniversalID='' not allowed!");
                    }

                    using (frmELGASearchPatient frmELGASearchPatient1 = new frmELGASearchPatient())
                    {
                        frmELGASearchPatient1.initControl(this.IDKlient, this.IDAufenthalt, true, rKlinik.AuthUniversalID);
                        frmELGASearchPatient1.ShowDialog();
                        if (!frmELGASearchPatient1.contELGASearchPatient1.abort)
                        {
                            bool bPatientLocalIDOK = false;
                            string ELGALocalIDStored = "";
                            if (String.IsNullOrWhiteSpace(frmELGASearchPatient1.contELGASearchPatient1._rSelRow.PatientLocalID.Trim()))
                            {
                                ELGAParOutDto parOut = this.WCFServiceClient1.ELGAInsertPatient(frmELGASearchPatient1.contELGASearchPatient1._rSelRow.ID,
                                                        "S2Int." + System.Guid.NewGuid().ToString(), 
                                                        rKlinik.AuthUniversalID.Trim(), 
                                                        WCFServicePMDS.ELGABAL.eTypeUpdatePatients.CreateLocalPatientID);
                                if (parOut.bOK)
                                {
                                    foreach (ELGAPidsDTO rPid in parOut.lPatients[0].ELGAPids)
                                    {
                                        if (rPid.patientIDType.sEquals("PI") && rPid.authUniversalID.sEquals(rKlinik.AuthUniversalID))
                                        {
                                            ELGALocalIDStored = rPid.patientID.Trim();
                                            bPatientLocalIDOK = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ELGALocalIDStored = frmELGASearchPatient1.contELGASearchPatient1._rSelRow.PatientLocalID.Trim();
                                bPatientLocalIDOK = true;
                            }

                            if (bPatientLocalIDOK)
                            {
                                var rBenutzer = (from b in db.Benutzer
                                                 where b.ID == ENV.USERID
                                                 select new
                                                 {
                                                     b.ID,
                                                     Nachname =  b.Nachname.Trim(),
                                                     Vorname = b.Vorname.Trim(),
                                                     Benutzer1 = b.Benutzer1.Trim()
                                                 }).First();

                                var rPatient = (from p in db.Patient
                                                where p.ID == this.IDKlient
                                                select new
                                                {
                                                    p.ID,
                                                    Nachname = p.Nachname.Trim(),
                                                    Vorname = p.Vorname.Trim()
                                                }).First();

                                PMDS.db.Entities.Patient rPatientUpdate = db.Patient.Where(o => o.ID == this.IDKlient).First();
                                PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this.IDAufenthalt).First();

                                //ELGAParOutDto parOutListContacts = this.WCFServiceClient1.ELGAListContacts(ELGALocalIDStored);
                                //ELGAParOutDto parOutListContacts = this.WCFServiceClient1.ELGAInvalidateContact(rAufenthaltUpdate.ELGAKontaktbestätigungContactID.Trim());

                                string sProtAttention = "";
                                if (!rPatientUpdate.Nachname.sEquals(frmELGASearchPatient1.contELGASearchPatient1._rSelRow.NachnameFirma))
                                {
                                    sProtAttention += "\n\r" + QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} stimmt nicht überein: ELGA = {1}, PMDS = {2}!");
                                    sProtAttention = string.Format(ci, sProtAttention, new List<string> { "Familienname", frmELGASearchPatient1.contELGASearchPatient1._rSelRow.NachnameFirma, rPatientUpdate.Nachname }.ToArray());
                                }

                                if (!rPatientUpdate.Vorname.sEquals(frmELGASearchPatient1.contELGASearchPatient1._rSelRow.Vorname))
                                {
                                    sProtAttention += "\n\r" + QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} stimmt nicht überein: ELGA = {1}, PMDS = {2}!");
                                    sProtAttention = string.Format(ci, sProtAttention, new List<string> { "Vorname", frmELGASearchPatient1.contELGASearchPatient1._rSelRow.Vorname, rPatientUpdate.Vorname }.ToArray());
                                }


                                if (!String.IsNullOrWhiteSpace(sProtAttention))
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsche Daten für Kontaktbestätigung:" + sProtAttention, "ELGA", MessageBoxButtons.OK);
                                    return;
                                }


                                ELGAParOutDto parOutContact = this.WCFServiceClient1.ELGAAddContactAdmission(ELGALocalIDStored);
                                if (!parOutContact.bOK)
                                {
                                    throw new Exception("contELGAKlient.doKontaktbestätigung: parOutContact.bOK=false not allowed - Error WCF-Service ELGAAddContactAdmission!");
                                }

                                string[] sPar = new string[] { rPatient.Nachname + " " + rPatient.Vorname, rBenutzer.Benutzer1 };
                                if (parOutContact.ContactExists)
                                {
                                    ELGAParOutDto parOutContactDischarge = this.WCFServiceClient1.ELGAAddContactDischarge(ELGALocalIDStored);
                                    string sProtStorno = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung-Storno für Patient {0} von Benutzer {1} durchgeführt.");
                                    sProtStorno = string.Format(ci, sProtStorno, sPar);
                                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung Storno"), null,
                                                                    ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProtStorno);

                                    parOutContact = this.WCFServiceClient1.ELGAAddContactAdmission(ELGALocalIDStored);
                                    if (!parOutContact.bOK)
                                    {
                                        string sProtText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler bei Kontaktbestätigung: " + parOutContact.Errors);
                                        sProtText = string.Format(ci, sProtText, sPar);
                                        ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung"), null,
                                                                        ELGABusiness.eTypeProt.Kontaktbestätigung, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProtText);
                                    }
                                }

                                rPatientUpdate.bPK = frmELGASearchPatient1.contELGASearchPatient1._rSelRow.bPK;
                                //rPatientUpdate.Nachname = frmELGASearchPatient1.contELGASearchPatient1._rSelRow.NachnameFirma;
                                //rPatientUpdate.Vorname = frmELGASearchPatient1.contELGASearchPatient1._rSelRow.Vorname;
                                rAufenthaltUpdate.ELGALocalID = ELGALocalIDStored.Trim();
                                rAufenthaltUpdate.ELGAKontaktbestätigungContactID = parOutContact.ContactID.Trim();
                                rAufenthaltUpdate.ELGAKontaktbestätigungJN = true;
                                rAufenthaltUpdate.ELGAKontaktbestätigungDatum = DateTime.Now;
                                rAufenthaltUpdate.ELGAKontaktbestätigungUser = rBenutzer.Benutzer1;
                                rAufenthaltUpdate.ELGAKontaktbestätigungStornoDatum = null;
                                rAufenthaltUpdate.ELGAKontaktbestätigungStornoJN = false;
                                rAufenthaltUpdate.ELGAKontaktbestätigungStornoUser = "";
                                db.SaveChanges();

                                string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                                sProt = string.Format(ci, sProt, sPar);
                                ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung"), null,
                                                                ELGABusiness.eTypeProt.Kontaktbestätigung, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProt);

                                this.loadData(this.IDKlient, this.IDAufenthalt);
                            }
                            else
                            {
                                throw new Exception("contELGAKlient.doKontaktbestätigung: PatientLocalID not ok for IDKlient '" + this.IDKlient.ToString() + "'!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.doKontaktbestätigung: " + ex.ToString());
            }
        }
       
        public void doKontaktbestätigungStorno()
        {
            try
            {
                ELGABusiness elga = new ELGABusiness();
                ELGABusiness.KlientDTO ELGAKlient = elga.GetELGAKlientByIDAufenthalt(IDAufenthalt);
                ELGABusiness.BenutzerDTOS1 ELGAUser = elga.getELGASettingsForUser(ENV.USERID);

                if (!ELGABusiness.checkELGASessionActive(true) ||
                        !ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, true) ||
                        !ELGAKlient.ELGAKontaktbestätigungJN)
                {
                    return;
                }

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("de-DE");
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this.IDAufenthalt).First();

                    //os: gehört hier nicht invalidateContact her? Frage an W. Wiecenec vom 1.3.2021
                    //ELGAParOutDto parOutInvContact = this.WCFServiceClient1.ELGAAddContactDischarge(rAufenthaltUpdate.ELGALocalID.Trim());
                    ELGAParOutDto parOutInvContact = this.WCFServiceClient1.ELGAInvalidateContact(rAufenthaltUpdate.ELGALocalID.Trim(), rAufenthaltUpdate.ELGAKontaktbestätigungContactID.Trim());

                    if (!parOutInvContact.bOK)
                    {
                        string sProtText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler bei Storno Kontaktbestätigung für Patient {0} durch Benutzer {1}: {2}");
                        string[] sParText = new string[] { ELGAKlient.Nachname + " " + ELGAKlient.Vorname, ELGAUser.Benutzer1, parOutInvContact.MessageException };
                        sProtText = string.Format(culture, sProtText, sParText);
                        ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung"), null,
                                                        ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProtText);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sProtText, "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        rAufenthaltUpdate.ELGAKontaktbestätigungJN = false;
                        rAufenthaltUpdate.ELGAKontaktbestätigungDatum = null;
                        rAufenthaltUpdate.ELGAKontaktbestätigungUser = ELGAUser.Benutzer1;
                        rAufenthaltUpdate.ELGAKontaktbestätigungStornoDatum = DateTime.Now;
                        rAufenthaltUpdate.ELGAKontaktbestätigungStornoJN = true;
                        rAufenthaltUpdate.ELGAKontaktbestätigungStornoUser = ELGAUser.Benutzer1;

                        rAufenthaltUpdate.ELGASOOJN = false;
                        rAufenthaltUpdate.ELGASOOZeitpunkt = null;
                        rAufenthaltUpdate.ELGASSOODatum = null;
                        rAufenthaltUpdate.ELGASOOUser = "";
                        rAufenthaltUpdate.ELGASOOGrund = "";
                        db.SaveChanges();

                        string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                        string[] sPar = new string[] { ELGAKlient.Nachname + " " + ELGAKlient.Vorname, ELGAUser.Benutzer1 };
                        sProt = string.Format(culture, sProt, sPar);
                        ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung"), null,
                                                        ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProt);

                        this.loadData(this.IDKlient, this.IDAufenthalt);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Kontakt wurde storniert!", "", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.doKontaktbestätigungStorno: " + ex.ToString());
            }
        }

        public bool validateDataSOO()
        {
            try
            {
                this.errorProvider1.SetError(this.chkZustimmungSOO, "");
                this.errorProvider1.SetError(this.chkRechteBelehrt, "");

                if (!this.chkRechteBelehrt.Checked)
                {
                    this.errorProvider1.SetError(this.chkRechteBelehrt, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient wurde über seine Rechte belehrt: Bestätigung erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                if (!this.chkZustimmungSOO.Checked)
                {
                    this.errorProvider1.SetError(this.chkZustimmungSOO, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient stimmt dem situativen Opt-Out zu: Bestätigung erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.validateDataSOO: " + ex.ToString());
            }
        }
        public void doSSO()
        {
            try
            {
                ELGABusiness elga = new ELGABusiness();
                if (!elga.ELGAIsActive(IDKlient, IDAufenthalt, true))
                {
                    return;
                }

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Situative Opt-Out wirklich durchführen? Die Aktion kann nicht mehr rückgängig gemacht werden!", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!this.validateDataSOO())
                    {
                        return;
                    }

                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rBenutzer = (from b in db.Benutzer
                                         where b.ID == ENV.USERID
                                         select new
                                         {
                                             b.ID,
                                             Nachname = b.Nachname.Trim(),
                                             Vorname = b.Vorname.Trim(),
                                             Benutzer1 =b.Benutzer1.Trim()
                                         }).First();

                        PMDS.db.Entities.Patient rPatient = db.Patient.Where(o => o.ID == this.IDKlient).First();
                        PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this.IDAufenthalt).First();

                        rAufenthaltUpdate.ELGASOOJN = true;
                        DateTime dNow = DateTime.Now;
                        rAufenthaltUpdate.ELGASOOZeitpunkt = dNow;
                        rAufenthaltUpdate.ELGASSOODatum = dNow;
                        rAufenthaltUpdate.ELGASOOUser = rBenutzer.Benutzer1;
                        rAufenthaltUpdate.ELGASOOGrund = "";
                        db.SaveChanges();

                        string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO für Patient {0} von Benutzer {1} durchgeführt.");
                        string[] sPar = new string[] { rPatient.Nachname + " " + rPatient.Vorname, rBenutzer.Benutzer1 };
                        sProt = string.Format(ci, sProt, sPar);
                        ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO"), null,
                                                        ELGABusiness.eTypeProt.SOO, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this.IDKlient, this.IDAufenthalt, sProt);

                        this.loadData(this.IDKlient, this.IDAufenthalt);

                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das situative Opt-Out wurde durchgeführt!", "", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.doSSO: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.validateData: " + ex.ToString());
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.saveData: " + ex.ToString());
            }
        }

        private void BtnDoKontaktbestätigung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doKontaktbestätigung();
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

        private void BtnKoontaktbestätigungStorno_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doKontaktbestätigungStorno();
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
        private void BtnSetSOO_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doSSO();
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
                this.mainWindowAufnahme.Close();
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
