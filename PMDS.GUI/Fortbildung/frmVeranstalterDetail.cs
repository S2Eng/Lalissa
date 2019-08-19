using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;





namespace PMDS.GUI.Fortbildung
{


    public partial class frmVeranstalterDetail : Form
    {

        public bool _IsNew = false;
        public Nullable<Guid> _IDVeranstalter;
        public bool abort = true;
                
        public tblVeranstalter rVeranstalter = null;
        public Adresse rAdresse = null;
        public Kontakt rKontakt = null;
        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        public bool Isinitialized = false;







        public frmVeranstalterDetail()
        {
            InitializeComponent();
        }

        private void frmVeranstalterDetail_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);

                    this.AcceptButton = this.btnOK;
                    this.CancelButton = this.btnAbort;

                    this._db = PMDSBusiness.getDBContext();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.frmVeranstalterDetail: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtBezeichnung.Text = "";

                this.txtStrasse.Text = "";
                this.cboLand.Text = "";
                this.txtPLZ.Text = "";
                this.txtOrt.Text = "";
                this.txtRegion.Text = "";

                this.txtTelefon.Text = "";
                this.txtFax.Text = "";
                this.txtMobil.Text = "";
                this.txtAndere.Text = "";
                this.txtEMail.Text = "";
                this.txtAnsprechpartner.Text = "";
                this.txtZusatz1.Text = "";
                this.txtZusatz2.Text = "";
                this.txtZusatz3.Text = "";

                this.txtBeschreibung.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDVeranstalter, bool IsNew)
        {
            try
            {
                this._IDVeranstalter = IDVeranstalter;
                this._IsNew = IsNew;
                this.clearUI();

                if (this._IsNew)
                {
                    this.rVeranstalter = new tblVeranstalter();
                    this.b.newRowVeranstalter(ref this.rVeranstalter);
                    this._IDVeranstalter = this.rVeranstalter.ID;

                    this.rAdresse = new Adresse();
                    this.b.newRowAdresse(ref this.rAdresse);
                    this.rVeranstalter.IDAdresse = this.rAdresse.ID;
                    this._db.Adresse.Add(this.rAdresse);

                    this.rKontakt = new Kontakt();
                    this.b.newRowKontakt(ref this.rKontakt);
                    this.rVeranstalter.IDKontakt = this.rKontakt.ID;
                    this._db.Kontakt.Add(this.rKontakt);

                    this._db.tblVeranstalter.Add(this.rVeranstalter);
                }
                else
                {
                    System.Linq.IQueryable<tblVeranstalter> tVeranstalter = this._db.tblVeranstalter.Where(p => p.ID == (Guid)this._IDVeranstalter);
                    this.rVeranstalter = tVeranstalter.First();

                    System.Linq.IQueryable<Adresse> tAdresse = this._db.Adresse.Where(p => p.ID == this.rVeranstalter.IDAdresse);
                    this.rAdresse = tAdresse.First();

                    System.Linq.IQueryable<Kontakt> tKontakt = this._db.Kontakt.Where(p => p.ID == this.rVeranstalter.IDKontakt);
                    this.rKontakt = tKontakt.First();
                }

                this.txtBezeichnung.Text = this.rVeranstalter.Bezeichnung.Trim();

                this.txtStrasse.Text = this.rAdresse.Strasse.Trim();
                this.cboLand.Text = this.rAdresse.LandKZ.Trim();
                this.txtPLZ.Text = this.rAdresse.Plz.Trim();
                this.txtOrt.Text = this.rAdresse.Ort.Trim();
                this.txtRegion.Text = this.rAdresse.Region.Trim();

                this.txtTelefon.Text = this.rKontakt.Tel.Trim();
                this.txtFax.Text = this.rKontakt.Fax.Trim();
                this.txtMobil.Text = this.rKontakt.Mobil.Trim();
                this.txtAndere.Text = this.rKontakt.Andere.Trim();
                this.txtEMail.Text = this.rKontakt.Email.Trim();
                this.txtAnsprechpartner.Text = this.rKontakt.Ansprechpartner.Trim();
                this.txtZusatz1.Text = this.rKontakt.Zusatz1.Trim();
                this.txtZusatz2.Text = this.rKontakt.Zusatz2.Trim();
                this.txtZusatz3.Text = this.rKontakt.Zusatz3.Trim();

                this.txtBeschreibung.Text = this.rVeranstalter.Beschreibung.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.loadData: " + ex.ToString());
            }
        }

        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.txtBezeichnung, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.ClearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                string MsgTxt2 = "";
                bool cbLandKZOK = PMDSBusinessUI.checkCboBox(this.cboLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt2);
                if (!cbLandKZOK)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
                    cboLand.Focus();
                    return false;
                }

                if (this.txtBezeichnung.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtBezeichnung, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.validateData: " + ex.ToString());
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

                this.rVeranstalter.Bezeichnung = this.txtBezeichnung.Text.Trim();

                this.rAdresse.Strasse = this.txtStrasse.Text.Trim();
                this.rAdresse.LandKZ = this.cboLand.Text.Trim();
                this.rAdresse.Plz = this.txtPLZ.Text.Trim();
                this.rAdresse.Ort = this.txtOrt.Text.Trim();
                this.rAdresse.Region = this.txtRegion.Text.Trim();

                this.rKontakt.Tel = this.txtTelefon.Text.Trim();
                this.rKontakt.Fax = this.txtFax.Text.Trim();
                this.rKontakt.Mobil = this.txtMobil.Text.Trim();
                this.rKontakt.Andere = this.txtAndere.Text.Trim();
                this.rKontakt.Email = this.txtEMail.Text.Trim();
                this.rKontakt.Ansprechpartner = this.txtAnsprechpartner.Text.Trim();
                this.rKontakt.Zusatz1 = this.txtZusatz1.Text.Trim();
                this.rKontakt.Zusatz2 = this.txtZusatz2.Text.Trim();
                this.rKontakt.Zusatz3 = this.txtZusatz3.Text.Trim();

                this.rVeranstalter.Beschreibung = this.txtBeschreibung.Text.Trim();

                this._db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.saveData: " + ex.ToString());
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
                    this.Close();
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
                this.Close();
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
