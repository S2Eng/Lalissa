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
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI.ELGA
{

    public partial class contELGAChangePassword : UserControl
    {
        public bool abort = true;
        public frmELGAChangePassword mainWindow = null;
        public bool IsInitialized = false;

        public PMDSBusiness b = new PMDSBusiness();
        public qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();




        public contELGAChangePassword()
        {
            InitializeComponent();
        }

        private void ContELGAChangePassword_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAChangePassword.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAChangePassword.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtELGAPwdOld, "");
                this.errorProvider1.SetError(this.txtELGAPwdNew, "");
                this.errorProvider1.SetError(this.txtELGAPwdNewWdhlg, "");

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rUsr = (from b in db.Benutzer
                                where b.ID == ENV.USERID
                                select new
                                {
                                    ID = b.ID,
                                    ELGAPwd = b.ELGAPwd,
                                    ELGAAutoLogin = b.ELGAAutoLogin
                                }).First();

                    if (rUsr.ELGAAutoLogin)
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdOld, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Benutzer kann kein Passwort erfasst werden, da die Anmeldung des Benutzers in ELGA automatisch erfolgt!", "", MessageBoxButtons.OK);
                        return false;
                    }

                    if (this.txtELGAPwdOld.Text.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdOld, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Altes Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        string ELGAPwdDecrypted = Encryption1.StringDecrypt(rUsr.ELGAPwd, qs2.license.core.Encryption.keyForEncryptingStrings);
                        if (this.txtELGAPwdOld.Text.Trim() != ELGAPwdDecrypted.Trim())
                        {
                            this.errorProvider1.SetError(this.txtELGAPwdOld, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Altes Passwort ist falsch!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }

                    if (this.txtELGAPwdNew.Text.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdNew, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.txtELGAPwdNew.Text.Trim().Length < 5)
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdNew, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Das neue Passwort muss mindestens 5 Zeichen lang sein!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.txtELGAPwdNewWdhlg.Text.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdNewWdhlg, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort Wiederholung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }

                    Global.PasswordScore pwdStrengthScore = PMDS.Global.Tools.CheckPasswordStrength(this.txtELGAPwdNew.Text.Trim());
                    bool compPasswords = true;
                    if (ENV.PasswordStrength >= PasswordScore.Strong)
                    {
                        compPasswords = PMDS.Global.Tools.ComparePasswords(rUsr.ELGAPwd.Trim(), this.txtELGAPwdNew.Text.Trim(), 6);
                    }
                    if (compPasswords == false)
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdNew, "Error");
                        this.errorProvider1.SetError(this.txtELGAPwdOld, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Altes und neues Passwort sind zu ähnlich!", "", MessageBoxButtons.OK);
                        return false;
                    }

                    if (this.txtELGAPwdNew.Text.Trim() != this.txtELGAPwdNewWdhlg.Text.Trim())
                    {
                        this.errorProvider1.SetError(this.txtELGAPwdNew, "Error");
                        this.errorProvider1.SetError(this.txtELGAPwdNewWdhlg, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Die beiden Passwort-Eingaben stimmen nicht überein!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAChangePassword.validateData: " + ex.ToString());
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

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rUsr = db.Benutzer.Where(o => o.ID == ENV.USERID).First();

                    string ELGAPwdEncrypted = Encryption1.StringDecrypt(this.txtELGAPwdNew.Text.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                    rUsr.ELGAPwd = ELGAPwdEncrypted;
                    db.SaveChanges();

                    string sProt = "User " + b.getUserName(ENV.USERID) + " has changed password.";
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort wurde geändert"), null, ELGABusiness.eTypeProt.NewPassword, ELGABusiness.eELGAFunctions.none, "");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGALcontELGAChangePasswordogIn.saveData: " + ex.ToString());
            }
        }


        private void BtnELGALogIn_Click(object sender, EventArgs e)
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
        private void BtnAbort_Click(object sender, EventArgs e)
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
