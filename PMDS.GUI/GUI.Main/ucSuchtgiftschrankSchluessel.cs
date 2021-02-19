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
using Infragistics.Win.UltraWinTree;

namespace PMDS.GUI.GUI.Main
{
    

    public partial class ucSuchtgiftschrankSchlüssel : UserControl
    {
        public Guid IDBenutzerLoggedIn;

        public frmSuchtgiftschrankSchlüssel mainWindow = null;
        public bool abort = true;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;






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

                this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                bool isTxtTemplate = false;
                this.contSelectPatientenBenutzer1._SingleSelect = true;
                this.contSelectPatientenBenutzer1.setSelectededTxt_Name = false;
                this.contSelectPatientenBenutzer1.SendEventPatientUsersWhenSelectChanged = true;
                this.contSelectPatientenBenutzer1.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Übernehmer");
                this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Users, false, isTxtTemplate, this.dropDownPatienten);
                this.uPopUpContUsers.PopupControl = this.contSelectPatientenBenutzer1;
                this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContUsers;
                this.dropDownPatienten.PopupItem = this.uPopUpContUsers;
                this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
                this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = false;
                this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                this.contSelectPatientenBenutzer1._TypePatientenUserPickerChanged = eTypePatientenUserPickerChanged.none;
                ENV.delPatientenUersPickerValueChanged += new dPatientenUersPickerValueChanged(this.PatientenUersPickerValueChanged);


                this.clearData();

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.initControl: " + ex.ToString());
            }
        }

        public void PatientenUersPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, System.Collections.Generic.List<Guid> lstSelectedUsersPatients, UltraTreeNode treeNodeKlinik,
                                                    eTypePatientenUserPickerChanged TypePatientenUserPickerChanged)
        {
            try
            {
                if (TypePatientenUserPickerChanged == this.contSelectPatientenBenutzer1._TypePatientenUserPickerChanged)
                {
                    Nullable<Guid> IDÜbernehmerTmp = null;
                    if (this.validateDataÜbernehmer(ref IDÜbernehmerTmp, false))
                    {                        //this.contSelectPatientenBenutzer1.setLabelCount2();
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            var rBenutzer = (from b in db.Benutzer
                                             where b.ID == IDÜbernehmerTmp.Value
                                             select new
                                             {
                                                 ID = b.ID,
                                                 Nachname = b.Nachname,
                                                 Vorname = b.Vorname,
                                                 Benutzer1 = b.Benutzer1
                                             }).First();
                            this.dropDownPatienten.Text = rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " (" + rBenutzer.Benutzer1.Trim() + ")"; ;
                        }

                        this.cboKlinik.Value = null;
                        this.cboAbteilung.Value = null;
                        this.loadKliniken(IDÜbernehmerTmp.Value);
                    }
                    else
                    {
                        this.cboKlinik.Value = null;
                        this.cboAbteilung.Value = null;
                        this.dropDownPatienten.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Übernehmer");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.PatientenUersPickerValueChanged: " + ex.ToString());
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
                    this.IDBenutzerLoggedIn = rUsrLoggedOn.ID;
                    this.txtÜbergeber.Text = rUsrLoggedOn.Benutzer1.Trim();
                }

                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
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

                Nullable<Guid> IDÜbernehmerTmp = null;
                if (!this.validateDataÜbernehmer(ref IDÜbernehmerTmp, true))
                {
                    return false;
                }

                if (this.cboAbteilung.Value == null || this.cboAbteilung.Value.GetType() != typeof(Guid))
                {
                    this.errorProvider1.SetError(this.cboAbteilung, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Auswahl erforderlich!", "", MessageBoxButtons.OK);
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
                    PMDS.BusinessLogic.Benutzer User = new PMDS.BusinessLogic.Benutzer(IDÜbernehmerTmp.Value);
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
        public bool validateDataÜbernehmer(ref Nullable<Guid> IDÜbernehmerBack, bool WithMsgBox)
        {
            try
            {
                List<Guid> lstUsers = this.contSelectPatientenBenutzer1.getList();
                if (lstUsers.Count() == 0)
                {
                    if (WithMsgBox)
                    {
                        this.errorProvider1.SetError(this.contSelectPatientenBenutzer1, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    }
                    return false;
                }
                else if (lstUsers.Count() > 1)
                {
                    throw new Exception("ucSuchtgiftschrankSchlüssel.validateData: lstUsers.Count() > 1 not allowed!");
                }
                Guid IDÜbernehmerTmp = lstUsers[0];
                IDÜbernehmerBack = IDÜbernehmerTmp;


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.validateDataÜbernehmer: " + ex.ToString());
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

                List<Guid> lstUsers = this.contSelectPatientenBenutzer1.getList();
                Guid IDÜbernehmerTmp = lstUsers[0];

                PMDS.BusinessLogic.Benutzer User = new PMDS.BusinessLogic.Benutzer(IDÜbernehmerTmp);
                rNew.UserÜbernehmer = User.BenutzerName.Trim();
                if (PMDS.Global.ENV.IDAnmeldungen != null)
                {
                    PMDS.db .Entities.Anmeldungen rAnmeldung = this.b.getAnmeldung(PMDS.Global.ENV.IDAnmeldungen.Value);
                    rNew.UserÜbergeberPool = rAnmeldung.LogInNameFrei.Trim();
                }

                if (User.IsGeneric)
                {
                    PMDS.GUI.GUI.Main.frmLogInAnonym frm = new GUI.Main.frmLogInAnonym();
                    frm.initControl();
                    PMDS.Global.UIGlobal.infoStart.Close();
                    frm.ShowDialog();
                    if (!frm.ucLogInAnonym1.abort)
                    {
                        rNew.UserÜbernehmerPool = frm.ucLogInAnonym1.txtName.Text.Trim();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    rNew.UserÜbernehmerPool = rNew.UserÜbergeberPool;



                rNew.IDAbteilung = (Guid)this.cboAbteilung.Value;
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


        public void loadKliniken(Guid IDÜbernehmer)
        {
            try
            {
                Nullable<Guid> IDÜbernehmerTmp = null;
                if (!this.validateDataÜbernehmer(ref IDÜbernehmerTmp, true))
                {
                    return;
                }

                this.cboKlinik.Items.Clear();
                this.cboAbteilung.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Klinik> tKliniken = this.b.loadAllKliniken(db);
                    foreach (Klinik rKlinik in tKliniken)
                    {
                        if (this.b.loadBenutzerEinrichtungForUsers(rKlinik.ID, this.IDBenutzerLoggedIn, IDÜbernehmerTmp.Value,  db))
                        {
                            Infragistics.Win.ValueListItem itm = this.cboKlinik.Items.Add(rKlinik.ID, rKlinik.Bezeichnung.Trim());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.loadKliniken: " + ex.ToString());
            }
        }
        public void loadAbteilungen(Guid IDKlinik)
        {
            try
            {
                this.cboAbteilung.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Abteilung> tAbteilung = this.b.getAllAbteilungen(IDKlinik, db);
                    foreach (Abteilung rAbteilung in tAbteilung)
                    {
                        Nullable<Guid> IDÜbernehmerTmp = null;
                        if (!this.validateDataÜbernehmer(ref IDÜbernehmerTmp, false))
                        {
                            throw new Exception("ucSuchtgiftschrankSchlüssel.loadAbteilungen: IDÜbernehmerTmp==null not allowed!");
                        }

                        if (this.b.loadBenutzerAbteilungForUsers(rAbteilung.ID, this.IDBenutzerLoggedIn, IDÜbernehmerTmp.Value, db))
                        {
                            Infragistics.Win.ValueListItem itm = this.cboAbteilung.Items.Add(rAbteilung.ID, rAbteilung.Bezeichnung.Trim());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSuchtgiftschrankSchlüssel.loadAbteilungen: " + ex.ToString());
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

        private void cboKlinik_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboKlinik.Focused)
                {
                    if (this.cboKlinik.Value != null)
                    {
                        if (this.cboKlinik.Value.GetType() == typeof(Guid))
                        {
                            this.loadAbteilungen((Guid)this.cboKlinik.Value);
                        }    
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void txtÜbernehmerPassword_KeyDown(object sender, KeyEventArgs e)
        {
            PMDS.Global.generic.TogglePassword(sender);
        }
    }

}
