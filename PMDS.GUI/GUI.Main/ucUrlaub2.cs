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
using Infragistics.Win.UltraWinSpellChecker;


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

        public void initControl(Guid IDPatient)
        {
            try
            {
                this._IDPatient = IDPatient;
                this.db2 = PMDSBusiness.getDBContext();

                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.pnlSTAMP.Visible = PMDS.Global.ENV.lic_STAMP;
                this.pnlBeschreibung.Visible = !PMDS.Global.ENV.lic_STAMP;

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
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rPatName = (from p in db.Patient
                                        where p.ID == this._IDPatient
                                    select new
                                            {p.Nachname, p.Vorname}
                                        ).First();

                    this.labInfo.Text = System.String.Format(labInfo.Text, rPatName.Nachname.Trim() + " " + rPatName.Vorname.Trim());
                }

                this.rAufenthaltAct = this.b.getAufenthalt(ENV.IDAUFENTHALT);

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

                if (this.IsAbwesend)
                {
                    this.dtpBeginn.Value = this.rUrlaubVerlauf.StartDatum;
                    this.dtpEnde.Value = null;
                    this.txtUrlaub.Text = this.rUrlaubVerlauf.Text;
                    this.auswahlSTAMP_Awesenheitsgrund.Text = rUrlaubVerlauf.STAMP_Abwesenheitsgrund;

                    this.dtpBeginn.Enabled = false;
                    this.dtpEnde.Enabled = true;
                    this.txtUrlaub.Enabled = false;
                    this.pnlSTAMP.Enabled = false;
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
                string ErrMsg = "";
                bool bOk = true;

                if (this.IsAbwesend)
                {
                    if (this.dtpEnde.Value == null)
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        ErrMsg += "Endedatum: Eingabe erforderlich.\n";
                        bOk = false;
                    }

                    if (this.dtpEnde.DateTime > DateTime.Now)
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        ErrMsg += "Endedatum darf nicht in der Zukunft liegen.\n";
                        bOk = false;
                    }
                }
                else
                {
                    if (this.dtpBeginn.Value == null)
                    {
                        this.errorProvider1.SetError(this.dtpBeginn, "Error");
                        ErrMsg += "Beginndatum: Eingabe erforderlich!\n";
                        bOk = false;
                    }

                    if (!ENV.lic_STAMP && String.IsNullOrWhiteSpace(this.txtUrlaub.Text))
                    {
                        this.errorProvider1.SetError(this.dtpEnde, "Error");
                        ErrMsg += "Beschreibung: Eingabe erforderlich!";
                        bOk = false;
                    }

                    if (ENV.lic_STAMP && String.IsNullOrWhiteSpace(this.auswahlSTAMP_Awesenheitsgrund.Text))
                    {
                        this.errorProvider1.SetError(this.auswahlSTAMP_Awesenheitsgrund, "Error");
                        ErrMsg += "Grund (STAMP): Eingabe erforderlich!";
                        bOk = false;
                    }
                }

                if (!bOk)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ErrMsg, "", MessageBoxButtons.OK);
                }
                return bOk;
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
                //Prüfen, ob es eine offene Abwesenheit gibt
                using (PMDS.db.Entities.ERModellPMDSEntities dbCheckStatus = PMDSBusiness.getDBContext())
                {
                    if ((from uv in dbCheckStatus.UrlaubVerlauf
                            where uv.IDAufenthalt == rAufenthaltAct.ID && uv.EndeDatum == null
                            select uv).Any())
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Abwesenheitsstatus hat sich geändert.\nEs kann aktuell keine erneute Abwesenheit erfasst werden.", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                if (!this.ValidateFields())
                {
                    return false;
                }
               
                DateTime dNow = DateTime.Now;
                if (this.IsAbwesend)
                {
                    this.rUrlaubVerlauf.EndeDatum = this.dtpEnde.DateTime;
                    this.rUrlaubVerlauf.DatumGeaendert = dNow;
                    this.rAufenthaltAct.IDUrlaub = null;
                    this.rUrlaubVerlauf.STAMP_Abwesenheitsgrund = this.auswahlSTAMP_Awesenheitsgrund.Text;
                    
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness(); 
                    string sText = "Abwesenheitsende " + this.rUrlaubVerlauf.Text.Trim();
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.AbwesenheitsEnde(this._IDPatient, this.rAufenthaltAct.ID, 
                                                                                                this.rUrlaubVerlauf.EndeDatum.Value, ENV.IDKlinik, sText);
                }
                else
                {
                    UrlaubVerlauf newUrlaubVerlauf = new UrlaubVerlauf();

                    newUrlaubVerlauf.ID = System.Guid.NewGuid();
                    newUrlaubVerlauf.IDAufenthalt = this.rAufenthaltAct.ID;
                    newUrlaubVerlauf.StartDatum = this.dtpBeginn.DateTime;
                    newUrlaubVerlauf.EndeDatum = null;
                    newUrlaubVerlauf.IDBenutzer_Erstellt = ENV.USERID;
                    newUrlaubVerlauf.IDBenutzer_Geaendert = ENV.USERID;
                    newUrlaubVerlauf.DatumErstellt = dNow;
                    newUrlaubVerlauf.DatumGeaendert = dNow;

                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();

                    if (ENV.lic_STAMP)
                    {
                        newUrlaubVerlauf.STAMP_Abwesenheitsgrund = auswahlSTAMP_Awesenheitsgrund.Text;
                        newUrlaubVerlauf.Text = auswahlSTAMP_Awesenheitsgrund.Text;
                    }
                    else
                    {
                        newUrlaubVerlauf.Text = this.txtUrlaub.Text;
                    }

                    this.db2.UrlaubVerlauf.Add(newUrlaubVerlauf);

                    this.rAufenthaltAct.IDUrlaub = newUrlaubVerlauf.ID;

                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(this._IDPatient, this.rAufenthaltAct.ID, newUrlaubVerlauf.StartDatum.Value, ENV.IDKlinik);


                    PMDSBusiness1.AddPflegeeintrag(db, QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsbeginn ") + newUrlaubVerlauf.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Alle Maßnahmen werden unterbrochen."),
                                                    newUrlaubVerlauf.StartDatum.Value, null, this.rAufenthaltAct.IDBereich,
                                                    this.rAufenthaltAct.ID, null, PflegeEintragTyp.PLANUNG,
                                                    null, this.rAufenthaltAct.IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung"));

                    this.rAufenthaltAct.AbwesenheitBeendet = false;
                    if (this.rAufenthaltAct.IDUrlaub != null)
                    {
                        PMDSBusiness1.UpdateAufenthaltSetIDUrlaub(rAufenthaltAct.ID, (Guid)rAufenthaltAct.IDUrlaub);
                    }
                }

                this.db2.SaveChanges();
                PMDS.DB.PMDSBusinessComm.newCommAsyncToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll, this.db2);

                return true;                
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

        private void auswahlSTAMP_Awesenheitsgrund_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
