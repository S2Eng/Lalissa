﻿using System;
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


namespace PMDS.GUI.ELGA.ManageSettings
{

    public partial class contELGASettings : UserControl
    {

        public List<ELGABusiness.ProtVar> lProt = new List<ELGABusiness.ProtVar>();
        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDSBusiness b = new PMDSBusiness();
        public qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

        public bool Isinitialized = false;

        public Nullable<Guid> _IDUser = System.Guid.Empty;
        public bool _IsNew = false;
        public bool _Editable = false;

      




        public contELGASettings()
        {
            InitializeComponent();
        }

        private void ContELGASettings_Load(object sender, EventArgs e)
        {

        }




        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._db = PMDSBusiness.getDBContext();
                    this.clearUI();

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this._IDUser = null;
                this._IsNew = false;

                this.txtELGAUser.Text = "";
                this.txtELGAPwd.Text = "";
                this.txtELGAPwdWdhlg.Text = "";
                this.chkELGAAutostartSession.Checked = false;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDUser, bool isNew, bool editable)
        {
            try
            {
                this._IDUser = IDUser;
                this._IsNew = isNew;
                this._Editable = editable;

                PMDS.db.Entities.Benutzer rUsr = this._db.Benutzer.Where(o => o.ID == this._IDUser.Value).First();

                this.txtELGAUser.Text = rUsr.ELGAUser.Trim();

                string ELGAPwdDecrypted = Encryption1.StringDecrypt(rUsr.ELGAPwd.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                this.txtELGAPwd.Text = ELGAPwdDecrypted;
                this.txtELGAPwd.Text = ELGAPwdDecrypted;
                this.chkELGAAutostartSession.Checked = rUsr.ELGAAutoLogin;

                lProt = new List<ELGABusiness.ProtVar>()
                        {
                            new ELGABusiness.ProtVar(){ Fld= "ELGAUser", oValOrig = rUsr.ELGAUser.Trim(), oValNew = "", Table = "Patient"  },
                            new ELGABusiness.ProtVar(){ Fld= "ELGAAutoLogin", oValOrig = rUsr.ELGAAutoLogin.ToString(), oValNew = "", Table = "Patient"  }
                        };

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.loadData: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtELGAUser, "");
                this.errorProvider1.SetError(this.txtELGAPwd, "");
                this.errorProvider1.SetError(this.txtELGAPwdWdhlg, "");

                if (this.txtELGAUser.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtELGAUser, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Benutzer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                if (!this.chkELGAAutostartSession.Checked)
                {
                    if (this.txtELGAPwd.Text.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        if (this.txtELGAPwd.Text.Trim().Length < 5)
                        {
                            this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Für das Passwort sind mindestens 5 Zeichen erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            if (txtELGAPwd.Text.Trim() != this.txtELGAPwdWdhlg.Text.Trim())
                            {
                                this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                                this.errorProvider1.SetError(this.txtELGAPwdWdhlg, "Error");
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Die beiden Passwort-Eingaben sind nicht gleich!", "", MessageBoxButtons.OK);
                                return false;
                            }
                            else
                            {
                                Global.PasswordScore pwdStrengthScore = PMDS.Global.Tools.CheckPasswordStrength(this.txtELGAPwd.Text.Trim());
                                bool compPasswords = true;
                                if (ENV.PasswordStrength >= PasswordScore.Strong)
                                {
                                    PMDS.db.Entities.Benutzer rUsr = this._db.Benutzer.Where(o => o.ID == this._IDUser.Value).First();
                                    compPasswords = PMDS.Global.Tools.ComparePasswords(rUsr.ELGAPwd.Trim(), this.txtELGAPwd.Text.Trim(), 6);
                                }
                                if (compPasswords == false)
                                {
                                    this.errorProvider1.SetError(this.txtELGAPwd, "Error");
                                    this.errorProvider1.SetError(this.txtELGAPwdWdhlg, "Error");
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Altes und neues Passwort sind zu ähnlich!", "", MessageBoxButtons.OK);
                                    return false;
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                PMDS.db.Entities.Benutzer rUsr = this._db.Benutzer.Where(o => o.ID == this._IDUser.Value).First();

                rUsr.ELGAUser = this.txtELGAUser.Text.Trim();
                if (!this.chkELGAAutostartSession.Checked)
                {
                    string ELGAPwdEncrypted = Encryption1.StringDecrypt(this.txtELGAPwd.Text.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                    rUsr.ELGAPwd = ELGAPwdEncrypted;
                }
                else
                {
                    rUsr.ELGAAutoLogin = this.chkELGAAutostartSession.Checked;
                    rUsr.ELGAPwd = "";
                }

                this._db.SaveChanges();

                var rP = lProt.Where(e => e.Fld == "ELGAUser").First();
                rP.oValNew = rUsr.ELGAUser;
                rP = lProt.Where(e => e.Fld == "ELGAAutoLogin").First();
                rP.oValNew = rUsr.ELGAAutoLogin.ToString();

                ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Benutzereinstellungen wurden geändert"), lProt, ELGABusiness.eTypeProt.UserSettingsChanged, ELGABusiness.eELGAFunctions.none, "Benutzer");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.saveData: " + ex.ToString());
            }
        }

    }

}

