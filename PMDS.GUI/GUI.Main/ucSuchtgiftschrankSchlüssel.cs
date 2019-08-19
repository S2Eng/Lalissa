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


namespace PMDS.GUI.GUI.Main
{
    

    public partial class ucSuchtgiftschrankSchlüssel : UserControl
    {
        public frmSuchtgiftschrankSchlüssel mainWindow = null;
        public bool abort = true;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();





        public ucSuchtgiftschrankSchlüssel()
        {
            InitializeComponent();
        }


        private void ucSuchtgiftschrankSchlüssel_Load(object sender, EventArgs e)
        {

        }




        public void initControl()
        {
            try
            {
                this.mainWindow.AcceptButton = this.btnOK;
                this.mainWindow.CancelButton = this.btnAbort;

                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.sqlManange1.initControl();
                this.clearData();
                this.loadUsers();

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.initControl: " + ex.ToString());
            }
        }

        public void loadUsers()
        {
            try
            {
                this.cboÜbernehmer.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db);
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {
                        this.cboÜbernehmer.Items.Add(rBenutzer.ID, rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.loadUsers: " + ex.ToString());
            }
        }

        public void clearData()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.sqlManange1.getSuchtgiftschrankSchlüssel(this.dsKlientenliste1, System.Guid.NewGuid().ToString(), "");

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rUsrLoggedOn = this.b.LogggedOnUser();
                    this.txtÜbergeber.Text = rUsrLoggedOn.Benutzer1.Trim();
                }

                this.cboÜbernehmer.Value = null;
                this.txtÜbernehmerPassword.Text = "";
                this.uceAm.Value = DateTime.Now;
                this.txtAnmerkung.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.clearData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                if (this.txtÜbergeber.Text.Trim() == "")
                {
                    throw new Exception("validateData: this.txtÜbergeber.Text.Trim()='' not allowed!");
                }

                if (this.cboÜbernehmer.Value == null)
                {
                    this.errorProvider1.SetError(this.cboÜbernehmer, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                if (this.txtÜbernehmerPassword.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtÜbernehmerPassword, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer Password: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    bool bInfo = false;
                    bool bError = false;
                    PMDS.BusinessLogic.Benutzer User = new PMDS.BusinessLogic.Benutzer((Guid)this.cboÜbernehmer.Value);
                    GuiUtil.ValidateField(this.txtÜbernehmerPassword, User.HasPasswort(this.txtÜbernehmerPassword.Text),
                                            ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
                    if (bError)
				    {
                        this.errorProvider1.SetError(this.txtÜbernehmerPassword, "Error");
                        //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer-Passwort ist falsch!", "", MessageBoxButtons.OK);
                        return false;
                    }

                }

                if (this.uceAm.Value == null)
                {
                    this.errorProvider1.SetError(this.uceAm, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Am: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }


                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.validateData: " + ex.ToString());
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

                PMDS.Global.db.ERSystem.dsKlientenliste.tblSuchtgiftschrankSchlüsselRow rNew = this.sqlManange1.getNewSuchtgiftschrankSchlüssel(ref this.dsKlientenliste1);
                rNew.UserÜbergeber = this.txtÜbergeber.Text.Trim();

                PMDS.BusinessLogic.Benutzer User = new PMDS.BusinessLogic.Benutzer((Guid)this.cboÜbernehmer.Value);
                rNew.UserÜbernehmer = User.BenutzerName.Trim();
                if (PMDS.Global.ENV.IDAnmeldungen != null)
                {
                    PMDS.db .Entities.Anmeldungen rAnmeldung = this.b.getAnmeldung(PMDS.Global.ENV.IDAnmeldungen.Value);
                    rNew.UserÜbernehmerPool = rAnmeldung.LogInNameFrei.Trim();
                }

                rNew.Am = this.uceAm.DateTime;
                rNew.Anmerkung = this.txtAnmerkung.Text.Trim();
                this.sqlManange1.daSuchtgiftschrankSchlüssel.Update(this.dsKlientenliste1.tblSuchtgiftschrankSchlüssel);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Schlüsselübergabe wurde gespeichert!", "", MessageBoxButtons.OK);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.saveData: " + ex.ToString());
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
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
