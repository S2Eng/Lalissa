using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.DB;
using PMDS.GUI.VB;
using S2Extensions;
using System.Diagnostics;

namespace PMDS.GUI.Klient
{

    public partial class contPatientDelete : UserControl
    {
        public Guid _IDPatient;
        public bool lastEntlassungszeitpunktOK = false;

        public bool abort = true;
        public bool IsInitialized = false;

        public frmPatientDelete MainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();






        public contPatientDelete()
        {
            InitializeComponent();
        }

        private void contPatientDelete_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Guid IDPatient)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    if (IDPatient == System.Guid.Empty)
                    {
                        throw new Exception("contPatientDelete.saveData: IDPatient==System.Guid.Empty not allowed!");
                    }

                    this._IDPatient = IDPatient;

                    this.MainWindow.AcceptButton = this.btnDelete;
                    this.MainWindow.CancelButton = this.btnAbort;

                    this.btnDelete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                    this.loadData();

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientDelete.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.btnDelete.Enabled = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == this._IDPatient
                                    select new
                                    { p.ID, p.Nachname, p.Vorname }
                                       ).First();

                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(this._IDPatient, db);
                    this.lblInfoPatientname.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient") + ": " + rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim();

                    PMDS.db.Entities.Aufenthalt rActAufenthalt = this.b.getAktuellerAufenthaltPatient(rPatInfo.ID, true, db);
                    DateTime datFor10Years = DateTime.Now.Date.AddYears(-10);
                    PMDS.db.Entities.Aufenthalt rAufenthaltLastEntlassen = this.b.getLastAufenthaltEntlassen2(this._IDPatient, db);
                    if (rActAufenthalt != null)
                    {
                        this.txtIDPatient.Visible = false;
                        this.lblIDPatient.Visible = false;
                        this.lblIDPatientInfo.Visible = false;
                        this.lastEntlassungszeitpunktOK = false;
                        this.lblWarning.Visible = true;
                        this.lblInfoLetztesEntlassungsdatum.Visible = false;
                        //this.lblInfoLetztesEntlassungsdatum.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Entlassungsdatum") + ": " + QS2.Desktop.ControlManagment.ControlManagment.getRes("keines");
                        this.lblWarning.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten mit aktuellem Aufenthalt können nicht gelöscht werden. Bitte beenden Sie den ausgewählten Aufenthalt.");
                        this.btnDelete.Enabled = false;
                    }
                    else
                    {
                        this.lblIDPatientInfo.Visible = true;
                        if (rAufenthaltLastEntlassen == null)
                        {
                            this.lastEntlassungszeitpunktOK = true;
                            this.lblWarning.Visible = true;
                            this.lblInfoLetztesEntlassungsdatum.Visible = true;
                            this.lblInfoLetztesEntlassungsdatum.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Entlassungsdatum") + ": " + QS2.Desktop.ControlManagment.ControlManagment.getRes("keines");
                            this.lblWarning.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung: Das letzte Entlassungsdatum des Patienten liegt weniger als 10 Jahre zurück!");
                            this.btnDelete.Enabled = true;
                        }
                        else if (rAufenthaltLastEntlassen != null && rAufenthaltLastEntlassen.Entlassungszeitpunkt.Value.Date > datFor10Years)
                        {
                            this.lastEntlassungszeitpunktOK = true;
                            this.lblWarning.Visible = true;
                            this.lblInfoLetztesEntlassungsdatum.Visible = true;
                            this.lblInfoLetztesEntlassungsdatum.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Entlassungsdatum") + ": " + rAufenthaltLastEntlassen.Entlassungszeitpunkt.Value.Date.ToString("dd.MM.yyy");
                            this.lblWarning.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung: Das letzte Entlassungsdatum des Patienten liegt weniger als 10 Jahre zurück!");
                            this.btnDelete.Enabled = true;
                        }
                        else
                        {
                            this.lblInfoLetztesEntlassungsdatum.Visible = true;
                            this.lblInfoLetztesEntlassungsdatum.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Entlassungsdatum") + ": " + rAufenthaltLastEntlassen.Entlassungszeitpunkt.Value.Date.ToString("dd.MM.yyy");
                            this.lastEntlassungszeitpunktOK = true;
                            this.lblWarning.Visible = false;
                            this.btnDelete.Enabled = true;
                        }

                        this.lblIDPatientInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("ID-Patient") + ": " + rPatInfo.ID.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientDelete.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.txtIDPatient, "");

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientDelete.clearErrorProvider: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                if (!this.txtIDPatient.Text.sEquals(this._IDPatient))
                {
                    this.errorProvider1.SetError(this.txtIDPatient, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die eingegebene ID-Patient ist falsch!", "", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contPatientDelete.validateData: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            frmDatenExport frmExport = null;
            try
            {
                if (!this.lastEntlassungszeitpunktOK)
                {
                    throw new Exception("contPatientDelete.saveData: lastEntlassungszeitpunktOK=false not allowed for IDPatient '" + this._IDPatient.ToString() + "'!");
                }

                if (!this.validateData())
                {
                    return false;
                }

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Patienten und alle seine Aufenthalte wirklich löschen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        //os191224
                        var rPatInfo = (from p in db.Patient
                                        where p.ID == this._IDPatient
                                        select new
                                        { p.Nachname, p.Vorname }
                                           ).First();
                        //PMDS.db.Entities.Patient rPatient = this.b.getPatient(this._IDPatient, db);

                        if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Patientendaten als PDF gesichert werden?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            frmExport = new frmDatenExport();
                            frmExport.Init(this._IDPatient, PMDS.Global.ENV.IDKlinik, PMDS.Global.ENV.eKlientenberichtTyp.full, Global.ENV.eDatenexportTyp.alle);
                            if (frmExport.bInit)
                            {
                                frmExport.ShowDialog();
                                if (!String.IsNullOrWhiteSpace(frmExport.FileNamePDFDocument))
                                {
                                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das generierte PDF-Dokument mit den Patientendaten öffnen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        ProcessStartInfo psi = new ProcessStartInfo
                                        {
                                            FileName = frmExport.FileNamePDFDocument,
                                            UseShellExecute = true
                                        };
                                        Process.Start(psi);
                                    }
                                }
                                else
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abbruch Patient löschen!" + "\r\n" + "Klientenbericht konnte nicht erfolgreich erstellt!", "PMDS", MessageBoxButtons.OK);
                                    return false;
                                }
                            }
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datenarchivierung kann nicht initialisert werden." + "\r\n" + "Klientenbericht konnte nicht erfolgreich erstellt!", "PMDS", MessageBoxButtons.OK);
                                return false;
                            }
                        }

                        this.b.sys_deletePatient(this._IDPatient, db);
                        string protTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient und Aufenthalte löschen");
                        string protTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient {0} wurde gelöscht");
                        protTxt = string.Format(protTxt, rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim());
                        this.b.saveProtocol(db, protTitle, protTxt);

                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Patient wurde erfolgreich gelöscht!", "PMDS", MessageBoxButtons.OK);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contPatientDelete.saveData: " + ex.ToString());
            }
            finally
            {
                frmExport?.Dispose();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.MainWindow.Close();
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
                this.MainWindow.Close();

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
