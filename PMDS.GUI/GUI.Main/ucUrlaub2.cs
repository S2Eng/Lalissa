using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.DB;
using PMDS.Global;
using PMDS.db.Entities;
using System.Linq;


namespace PMDS.GUI.GUI.Main
{


    public partial class ucUrlaub2 : UserControl
    {
        public Guid _IDPatient;
        public Aufenthalt rAufenthaltAct = null;
        public Patient rPatient = null;
        public UrlaubVerlauf rUrlaubVerlauf = null;

        public PMDSBusiness b = new PMDSBusiness();
        public bool IsAbwesend = false;
        public PMDS.db.Entities.ERModellPMDSEntities db2 = null;

        public frmUrlaub2 mainWindow = null;
        public bool abort = true;
        public bool restartFrm = false;

        





        public ucUrlaub2()
        {
            InitializeComponent();
        }

        private void ucUrlaub2_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Guid IDPatient)
        {
            try
            {
                this._IDPatient = IDPatient;
                this.db2 = PMDSBusiness.getDBContext();

                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

            }
            catch (Exception ex)
            {
                throw new Exception("initControl" + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                //191224
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rPatName = (from p in db.Patient
                                        where p.ID == this._IDPatient
                                    select new
                                            {p.Nachname, p.Vorname}
                                        ).First();

                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(this.IDPATIENT, db);
                    this.labInfo.Text = System.String.Format(labInfo.Text, rPatName.Nachname.Trim() + " " + rPatName.Vorname.Trim());
                }
                //this.rPatient = this.b.getPatient(this._IDPatient, this.db2);
                //this.labInfo.Text = System.String.Format(labInfo.Text, this.rPatient.Nachname.Trim() + " " + this.rPatient.Vorname.Trim());

                this.rAufenthaltAct = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, this.db2);
                this.IsAbwesend = this.b.KlientIsAbwesend(this.db2, rAufenthaltAct.ID);
                this.rUrlaubVerlauf = this.b.getOffenenUrlaub(this.db2, rAufenthaltAct.ID);


                if (this.rAufenthaltAct.IDUrlaub == null && this.IsAbwesend)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rAufenthaltAct.IDUrlaub == null && this.IsAbwesend not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.rAufenthaltAct.IDUrlaub != null && !this.IsAbwesend)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rAufenthaltAct.IDUrlaub != null && !this.IsAbwesend not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.rUrlaubVerlauf != null && !this.IsAbwesend)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rUrlaubVerlauf != null && !this.IsAbwesend not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.rUrlaubVerlauf == null && this.IsAbwesend)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rUrlaubVerlauf == null && this.IsAbwesend not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.rUrlaubVerlauf != null && this.rAufenthaltAct.IDUrlaub == null)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rUrlaubVerlauf != null && this.rAufenthaltAct.IDUrlaub == null not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.rUrlaubVerlauf == null && this.rAufenthaltAct.IDUrlaub != null)
                {
                    throw new Exception("ucUrlaub2.loadData: this.rUrlaubVerlauf == null && this.rAufenthaltAct.IDUrlaub != null not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (this.IsAbwesend && this.rAufenthaltAct.IDUrlaub == null)
                {
                    throw new Exception("ucUrlaub2.loadData: this.IsAbwesend && this.rAufenthaltAct.IDUrlaub == null not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }
                if (!this.IsAbwesend && this.rAufenthaltAct.IDUrlaub != null)
                {
                    throw new Exception("ucUrlaub2.loadData: !this.IsAbwesend && this.rAufenthaltAct.IDUrlaub != null not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }

                //if (IsAbwesend) 
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Abwesend' geändert.", "Hinweis");
                //    this.mainWindow.Close();
                //}
                //else if (!IsAbwesend) 
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Anwesend' geändert.", "Hinweis");
                //    this.mainWindow.Close();
                //}

                if (this.IsAbwesend)
                {
                    this.dtpBeginn.Value = this.rUrlaubVerlauf.StartDatum;
                    this.dtpEnde.Value = null;
                    this.txtUrlaub.Text = this.rUrlaubVerlauf.Text;

                    this.dtpBeginn.Enabled = false;
                    this.dtpEnde.Enabled = true;
                    this.txtUrlaub.Enabled = false;
                }
                else
                {
                    this.dtpBeginn.Value = null;
                    this.dtpEnde.Value = null;
                    this.txtUrlaub.Text = "";

                    this.dtpBeginn.Enabled = true;
                    this.dtpEnde.Enabled = false;
                    this.txtUrlaub.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucUrlaub2.loadData:" + ex.ToString());
            }
        }

        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.dtpBeginn, "");
                this.errorProvider1.SetError(this.dtpEnde, "");
                this.errorProvider1.SetError(this.txtUrlaub, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucUrlaub2.ClearErrorProvider: " + ex.ToString());
            }
        }
        public bool ValidateFields()
        {
            try
            {
                this.ClearErrorProvider();
                
                if (this.IsAbwesend)
                {
                    if (this.dtpEnde.Value == null)
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Endedatum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.dtpEnde.DateTime > DateTime.Now)
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Endedatum darf nicht in der Zukunft liegen!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
                else
                {
                    if (this.dtpBeginn.Value == null)
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beginndatum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.txtUrlaub.Text == null || this.txtUrlaub.Text == "")
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beschreibung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                return true;
                                

                //bool bError = false;
                //bool bInfo = true;

                //if (dtpBeginn.Enabled)
                //{
                //    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                //    bool DatOK = b.checkDateRückmeldung(dtpBeginn.DateTime, PflegeEintragTyp.NONE);
                //    if (!DatOK)
                //    {
                //        bError = true;
                //    }
                //}

                //if (dtpEnde.Enabled)
                //{
                //    GuiUtil.ValidateField(dtpEnde, (dtpBeginn.DateTime <= dtpEnde.DateTime),
                //        ENV.String("GUI.E_NO_FUTURE_DATE"), ref bError, bInfo, errorProvider1);
                //}

                //if (txtUrlaub.Enabled)
                //{
                //    GuiUtil.ValidateField(txtUrlaub, (txtUrlaub.Text.Length > 0),
                //        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                //}

                //return !bError;

            }
            catch (Exception ex)
            {
                throw new Exception("ucUrlaub2.ValidateFields" + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                if (!this.ValidateFields())
                {
                    return false;
                }

                if (!this.checkUrlaubStatusOK(this.IsAbwesend))
                {
                    return false;
                }

                DateTime dNow = DateTime.Now;
                if (this.IsAbwesend)
                {
                    this.rUrlaubVerlauf.EndeDatum = this.dtpEnde.DateTime;
                    this.rUrlaubVerlauf.DatumGeaendert = dNow;
                    this.rAufenthaltAct.IDUrlaub = null;
                    
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness(); 
                    string sText = "Abwesenheitsende " + this.rUrlaubVerlauf.Text.Trim();
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.AbwesenheitsEnde(this._IDPatient, this.rAufenthaltAct.ID, 
                                                                                                this.rUrlaubVerlauf.EndeDatum.Value, ENV.IDKlinik, sText);
                    //_patient.Aufenthalt.Write();
                }
                else
                {
                    UrlaubVerlauf newUrlaubVerlauf = new UrlaubVerlauf();

                    newUrlaubVerlauf.ID = System.Guid.NewGuid();
                    newUrlaubVerlauf.IDAufenthalt = this.rAufenthaltAct.ID;
                    newUrlaubVerlauf.StartDatum = this.dtpBeginn.DateTime;
                    newUrlaubVerlauf.Text = this.txtUrlaub.Text;
                    newUrlaubVerlauf.EndeDatum = null;
                    newUrlaubVerlauf.IDBenutzer_Erstellt = ENV.USERID;
                    newUrlaubVerlauf.IDBenutzer_Geaendert = ENV.USERID;
                    newUrlaubVerlauf.DatumErstellt = dNow;
                    newUrlaubVerlauf.DatumGeaendert = dNow;
                    this.db2.UrlaubVerlauf.Add(newUrlaubVerlauf);

                    this.rAufenthaltAct.IDUrlaub = newUrlaubVerlauf.ID;

                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness(); 
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(this._IDPatient, this.rAufenthaltAct.ID, newUrlaubVerlauf.StartDatum.Value, ENV.IDKlinik);

                    PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                    PMDSBusiness1.AddPflegeeintrag(db, QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsbeginn ") + newUrlaubVerlauf.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Alle Maßnahmen werden unterbrochen."),
                                                    newUrlaubVerlauf.StartDatum.Value, null, this.rAufenthaltAct.IDBereich,
                                                    this.rAufenthaltAct.ID, null, PflegeEintragTyp.PLANUNG,
                                                    null, this.rAufenthaltAct.IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung"));

                    this.rAufenthaltAct.AbwesenheitBeendet = false;

                    //db.SaveChanges();
                    //_patient.Aufenthalt.Write();
                }

                this.db2.SaveChanges();
                PMDS.DB.PMDSBusinessComm.newMessageToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll, this.db2);

                return true;


                //if (!ucUrlaub1.ValidateFields())
                //    return;

                //ucUrlaub1.UpdateDATA();

                //// ende datum für Rückmeldungen ermitteln
                //UrlaubVerlauf u = ucUrlaub1.Urlaub;
                //string text = (u.IsOpenUrlaub ? "" : u.Text);
                //DateTime dtEnd = (u.IsOpenUrlaub ? u.StartDatum : (DateTime)u.EndeDatum);

                //bool IsAbwesend = false;
                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                //{
                //    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                //    IsAbwesend = b.KlientIsAbwesend(db, _patient.Aufenthalt.ID);
                //}

                //if (u.IsOpenUrlaub && !IsAbwesend)
                //{
                //    Guid idAuf = _patient.Aufenthalt.ID;
                //    DateTime DatBeginnUrlaub = this.ucUrlaub1.dtpBeginn.DateTime;
                //    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();   //lthok
                //    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(_patient.ID, idAuf, DatBeginnUrlaub, ENV.IDKlinik);

                //    PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                //    PMDSBusiness1.AddPflegeeintrag(db, "Abwesenheitsbeginn " + u.Text + " - Alle Maßnahmen werden unterbrochen.", DatBeginnUrlaub,
                //        null, _patient.Aufenthalt.IDBereich,
                //        _patient.Aufenthalt.ID, null, PflegeEintragTyp.PLANUNG,
                //        null, _patient.Aufenthalt.IDAbteilung, "Planungsänderung");
                //    db.SaveChanges();

                //    _patient.Aufenthalt.Write();
                //}
                //else if (!u.IsOpenUrlaub && IsAbwesend)
                //{
                //    Guid idAuf = _patient.Aufenthalt.ID;
                //    DateTime DatBeginnUrlaub = this.ucUrlaub1.dtpBeginn.DateTime;
                //    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();   //lthok
                //    string sText = "Abwesenheitsende " + u.Text;
                //    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.AbwesenheitsEnde(_patient.ID, idAuf, dtEnd, ENV.IDKlinik, sText);
                //    _patient.Aufenthalt.Write();
                //}
                //else if (u.IsOpenUrlaub && IsAbwesend)         //Klient ist bereits abwesend, kann nicht nocheinmal abwesend gemacht werden
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Abwesend' geändert.", "Hinweis");
                //}
                //else if (!u.IsOpenUrlaub && !IsAbwesend)         //Klient ist bereits abwesend, kann nicht nocheinmal abwesend gemacht werden
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Anwesend' geändert.", "Hinweis");
                //}
                //else         //Irregulärer Zustand
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten kann nicht festgestellt werden. Bitte schließen Sie das Fenster und probieren Sie es nocheinmal", "Hinweis");
                //}

                //_bCanclose = true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucUrlaub2.saveData" + ex.ToString());
            }
        }

        public bool checkUrlaubStatusOK(bool IsAbwesend)
        {
            try
            {
                bool PatientHasNoAktAufenthalt = false;
                PMDS.db.Entities.UrlaubVerlauf rUrlaubVerlaufLast = null;
                bool IsAbwesendDB = this.b.PatientIstAbwesend(this._IDPatient, this.db2, ref PatientHasNoAktAufenthalt, ref rUrlaubVerlaufLast);
                if (IsAbwesend)
                {
                    if (!IsAbwesendDB)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abwesenheit des Klienten kann nicht beendet werden, da die Abwesenheit bereits beendet wurde!", "PMDS", MessageBoxButtons.OK);
                        this.mainWindow.Close();
                        this.restartFrm = true;
                        return false;
                    }
                }
                else
                {
                    if (IsAbwesendDB)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient kann nicht auf Abwesend gesetzt werden, da er bereits abwesend ist!", "PMDS", MessageBoxButtons.OK);
                        this.mainWindow.Close();
                        this.restartFrm = true;
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucUrlaub2.checkUrlaubStatusOK" + ex.ToString());
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

    }

}
