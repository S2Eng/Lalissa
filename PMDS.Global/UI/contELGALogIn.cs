using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.DB;
using PMDS.Global;

namespace PMDS.GUI.ELGA
{

    public partial class contELGALogIn : UserControl
    {

        public bool abort = true;
        public frmELGALogIn mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDSBusiness b = new PMDSBusiness();
        qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

        private bool PasswortExpired;


        public contELGALogIn()
        {
            InitializeComponent();
        }

        private void contLogIn_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.mainWindow.AcceptButton = this.btnELGALogIn;
                    this.mainWindow.CancelButton = this.btnAbort;

                    //Prüfen, ob Passwort abgelaufen ist.
                    int PwdRemainingDays = 90 - (int)(DateTime.Now - (DateTime)ENV.ActiveUser.ELGAPwdLastChange).TotalDays;
                    this.lblELGAValidDays.Text = "Passwort ändern in ";
                    if (PwdRemainingDays == 1)
                        this.lblELGAValidDays.Text += "einem Tag!";
                    else if (PwdRemainingDays == 0)
                        this.lblELGAValidDays.Text = "Passwort heute ändern!";
                    else if (PwdRemainingDays > 1)
                        this.lblELGAValidDays.Text += PwdRemainingDays.ToString() + " Tagen.";
                    else
                    {
                        this.lblELGAValidDays.Text = "Passwort abgelaufen!";
                        PasswortExpired = true;
                        this.btnELGALogIn.Visible = false;
                    }

                    this.btnELGALogIn.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGALogIn.initControl: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtELGAUser, "");
                this.errorProvider1.SetError(this.txtELGAPwd, "");

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (String.IsNullOrWhiteSpace(this.txtELGAUser.Text))
                    {
                        this.errorProvider1.SetError(this.txtELGAUser, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Benutzer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (String.IsNullOrWhiteSpace(this.txtELGAPwd.Text))
                    {
                        this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        var rUsr = (from b in db.Benutzer
                                    where b.ID == ENV.USERID
                                    select new
                                    {
                                        ID = b.ID,
                                        ELGAUser = b.ELGAUser,
                                        ELGAPwd = b.ELGAPwd,
                                        ELGAAutoLogin = b.ELGAAutoLogin
                                    }).First();

                        if (this.txtELGAUser.Text.Trim() != rUsr.ELGAUser.Trim())
                        {
                            this.errorProvider1.SetError(this.txtELGAUser, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Benutzer ist falsch!", "", MessageBoxButtons.OK);
                            return false;
                        }

                        string ELGAPwdDecrypted = Encryption1.StringDecrypt(rUsr.ELGAPwd, qs2.license.core.Encryption.keyForEncryptingStrings);
                        if (this.txtELGAPwd.Text.Trim() != ELGAPwdDecrypted.Trim())
                        {
                            this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort ist falsch!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGALogIn.validateData: " + ex.ToString());
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
                throw new Exception("contELGALogIn.saveData: " + ex.ToString());
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

        private void lblELGAValidDays_Click(object sender, EventArgs e)
        {
            if (PasswortExpired)
            {

            }
        }
    }
}
