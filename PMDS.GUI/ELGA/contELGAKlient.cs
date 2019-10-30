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
using QS2.Desktop.ControlManagment.ServiceReference_01;
using PMDS.Global.db.ERSystem;
using PMDS.DB;

namespace PMDS.GUI.ELGA
{


    public partial class contELGAKlient : UserControl
    {

        public ucKlient mainWindow = null;
        public bool IsInitialized = false;

        public Guid _IDKlient;
        public Guid _IDAufenthalt;
        public bool _IsNeuaufnahme = false;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public WCFServiceClient WCFServiceClient1 = new WCFServiceClient();
        public PMDSBusiness b = new PMDSBusiness();

        public frmELGAKlient mainWindowAufnahme = null;







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
                    this._IsNeuaufnahme = IsNeuaufnahme;

                    this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                    this.panelBottom.Visible = this._IsNeuaufnahme;
                    if (this._IsNeuaufnahme)
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
                this._IDKlient = IDKlient;
                this._IDAufenthalt = IDAufenthalt;

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rBenutzer = (from b in db.Benutzer
                                     where b.ID == ENV.USERID
                                     select new
                                     {
                                         b.ID,
                                         b.Nachname,
                                         b.Vorname,
                                         b.Benutzer1
                                     }).First();

                    PMDS.db.Entities.Patient rPatient = db.Patient.Where(o => o.ID == this._IDKlient).First();
                    PMDS.db.Entities.Aufenthalt rAufenthalt = db.Aufenthalt.Where(o => o.ID == this._IDAufenthalt).First();


                    if (rAufenthalt.ELGAKontaktbestätigungJN)
                    {
                        string sTxtKontaktbestätigung = QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum") + ": " + rAufenthalt.ELGAKontaktbestätigungDatum.Value.ToString("dd.MM.yyyy HH:mm:ss") + ", " + 
                                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer") + ": " + rAufenthalt.ELGAKontaktbestätigungUser.Trim() + 
                                                            " - " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung hergestellt!");
                        this.txtKontaktbestätigung.Text = sTxtKontaktbestätigung.Trim();

                        this.btnDoKontaktbestätigung.Enabled = false;
                        this.btnKoontaktbestätigungStorno.Enabled = true;
                    }
                    else
                    {
                        this.txtKontaktbestätigung.Text = "";
                        this.btnDoKontaktbestätigung.Enabled = true;
                        this.btnKoontaktbestätigungStorno.Enabled = false;
                    }


                    if (rAufenthalt.ELGASOOJN)
                    {
                        this.chkZustimmungSOO.Checked = true;
                        this.chkRechteBelehrt.Checked = true;
                        this.chkZustimmungSOO.Enabled = false;
                        this.chkRechteBelehrt.Enabled = false;
                        this.btnSetSOO.Enabled = false;
                    }
                    else
                    {
                        this.chkZustimmungSOO.Checked = false;
                        this.chkRechteBelehrt.Checked = false;
                        this.chkZustimmungSOO.Enabled = true;
                        this.chkRechteBelehrt.Enabled = true;
                        this.btnSetSOO.Enabled = true;
                    }
                }

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
                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }
                if (!ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, true))
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
                                       k.AuthUniversalID,
                                   }).First();
                    if (rKlinik.AuthUniversalID.Trim() == "")
                    {
                        throw new Exception("doKontaktbestätigung: rKlinik.AuthUniversalID='' not allowed!");
                    }

                    frmELGASearchPatient frmELGASearchPatient1 = new frmELGASearchPatient();
                    frmELGASearchPatient1.initControl(this._IDKlient, this._IDAufenthalt, true, rKlinik.AuthUniversalID.Trim());
                    frmELGASearchPatient1.ShowDialog();
                    if (!frmELGASearchPatient1.contELGASearchPatient1.abort)
                    {
                        bool bPatientLocalIDOK = false;
                        string ELGALocalIDStored = "";
                        if (frmELGASearchPatient1.contELGASearchPatient1._rSelRow.PatientLocalID.Trim() == "")
                        {
                            ELGAParOutDto parOut = this.WCFServiceClient1.ELGAUpdatePatient(frmELGASearchPatient1.contELGASearchPatient1._rSelRow.ID, this._IDAufenthalt.ToString().ToLower(), ELGABALeTypeUpdatePatients.CreateLocalPatientID);
                            if (parOut.bOKk__BackingField)
                            {
                                foreach (ELGAPidsDTO rPid in parOut.lPatientsk__BackingField[0].ELGAPidsk__BackingField)
                                {
                                    if (rPid.patientIDTypek__BackingField.ToLower() == ("PI").ToLower())
                                    {
                                        ELGALocalIDStored = rPid.IDELGAPatientsk__BackingField.Trim();
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
                                                 b.Nachname,
                                                 b.Vorname,
                                                 b.Benutzer1
                                             }).First();

                            var rPatient = (from p in db.Patient
                                            where p.ID == this._IDKlient
                                            select new
                                            {
                                                p.ID,
                                                p.Nachname,
                                                p.Vorname
                                            }).First();

                            //PMDS.db.Entities.Patient rPatientUpdate = db.Patient.Where(o => o.ID == this._IDKlient).First();
                            PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this._IDAufenthalt).First();

                            ELGAParOutDto parOutListContacts = this.WCFServiceClient1.ELGAQueryPatients(ELGALocalIDStored.Trim(), ELGABALeTypeQueryPatients.LocalID, true);
                            //parOutListContacts.lPatientsk__BackingField[0].IDk__BackingField

                            //ELGAParOutDto parOutListContacts = this.WCFServiceClient1.ELGAListContacts(ELGALocalIDStored);
                            //ELGAParOutDto parOutListContacts = this.WCFServiceClient1.ELGAInvalidateContact(rAufenthaltUpdate.ELGAKontaktbestätigungContactID.Trim());

                            ELGAParOutDto parOutContact = this.WCFServiceClient1.ELGAAddContactAdmission(ELGALocalIDStored);
                            if (!parOutContact.bOKk__BackingField)
                            {
                                throw new Exception("contELGAKlient.doKontaktbestätigung: parOutContact.bOK=false not allowed - Error WCF-Service ELGAAddContactAdmission!");
                            }

                            //rPatientUpdate.bPK = frmELGASearchPatient1.contELGASearchPatient1._rSelRow.IDElga;

                            rAufenthaltUpdate.ELGALocalID = ELGALocalIDStored.Trim();
                            rAufenthaltUpdate.ELGAKontaktbestätigungContactID = parOutContact.ContactIDk__BackingField.Trim();
                            rAufenthaltUpdate.ELGAKontaktbestätigungJN = true;
                            rAufenthaltUpdate.ELGAKontaktbestätigungDatum = DateTime.Now;
                            rAufenthaltUpdate.ELGAKontaktbestätigungUser = rBenutzer.Benutzer1.Trim();
                            rAufenthaltUpdate.ELGAKontaktbestätigungStornoDatum = null;
                            rAufenthaltUpdate.ELGAKontaktbestätigungStornoJN = false;
                            rAufenthaltUpdate.ELGAKontaktbestätigungStornoUser = "";

                            db.SaveChanges();


                            string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                            sProt = string.Format(sProt, rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim(), rBenutzer.Benutzer1.Trim());
                            ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung"), null,
                                                            ELGABusiness.eTypeProt.Kontaktbestätigung, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this._IDKlient, this._IDAufenthalt, sProt);

                            this.loadData(this._IDKlient, this._IDAufenthalt);
                        }
                        else
                        {
                            throw new Exception("contELGAKlient.doKontaktbestätigung: PatientLocalID not ok for IDKlient '" + this._IDKlient.ToString() + "'!");
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
                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //PMDS.db.Entities.Patient rPatientUpdate = db.Patient.Where(o => o.ID == this._IDKlient).First();
                    PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this._IDAufenthalt).First();

                    ELGAParOutDto parOutInvContact = this.WCFServiceClient1.ELGAInvalidateContact(rAufenthaltUpdate.ELGAKontaktbestätigungContactID.Trim());
                    if (!parOutInvContact.bOKk__BackingField)
                    {
                        throw new Exception("contELGAKlient.doKontaktbestätigungStorno: parOutInvContact.bOK=false not allowed - Error WCF-Service ELGAInvalidateContact!");
                    }

                    var rBenutzer = (from b in db.Benutzer
                                        where b.ID == ENV.USERID
                                        select new
                                        {
                                            b.ID,
                                            b.Nachname,
                                            b.Vorname,
                                            b.Benutzer1
                                        }).First();

                    var rPatient = (from p in db.Patient
                                    where p.ID == this._IDKlient
                                    select new
                                    {
                                        p.ID,
                                        p.Nachname,
                                        p.Vorname
                                    }).First();

                    rAufenthaltUpdate.ELGAKontaktbestätigungJN = false;
                    rAufenthaltUpdate.ELGAKontaktbestätigungDatum = null;
                    rAufenthaltUpdate.ELGAKontaktbestätigungUser = rBenutzer.Benutzer1.Trim();
                    rAufenthaltUpdate.ELGAKontaktbestätigungStornoDatum = DateTime.Now;
                    rAufenthaltUpdate.ELGAKontaktbestätigungStornoJN = true;
                    rAufenthaltUpdate.ELGAKontaktbestätigungStornoUser = rBenutzer.Benutzer1.Trim();

                    db.SaveChanges();


                    string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                    sProt = string.Format(sProt, rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim(), rBenutzer.Benutzer1.Trim());
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung"), null,
                                                    ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this._IDKlient, this._IDAufenthalt, sProt);

                    this.loadData(this._IDKlient, this._IDAufenthalt);
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
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient stimmt dem situativem Opt-Out zu: Bestätigung erforderlich!", "", MessageBoxButtons.OK);
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
                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }
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
                                         b.Nachname,
                                         b.Vorname,
                                         b.Benutzer1
                                     }).First();

                    PMDS.db.Entities.Patient rPatient = db.Patient.Where(o => o.ID == this._IDKlient).First();
                    PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this._IDAufenthalt).First();

                    rAufenthaltUpdate.ELGASOOJN = true;
                    DateTime dNow = DateTime.Now;
                    rAufenthaltUpdate.ELGASOOZeitpunkt = dNow;
                    rAufenthaltUpdate.ELGASSOODatum = dNow;
                    rAufenthaltUpdate.ELGASOOUser = rBenutzer.Benutzer1.Trim();
                    rAufenthaltUpdate.ELGASOOGrund = "";

                    db.SaveChanges();


                    string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO für Patient {0} von Benutzer {1} durchgeführt.");
                    sProt = string.Format(sProt, rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim(), rBenutzer.Benutzer1.Trim());
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO"), null,
                                                    ELGABusiness.eTypeProt.SOO, ELGABusiness.eELGAFunctions.none, "Aufenthalt", "", ENV.USERID, this._IDKlient, this._IDAufenthalt, sProt);

                    this.loadData(this._IDKlient, this._IDAufenthalt);
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
