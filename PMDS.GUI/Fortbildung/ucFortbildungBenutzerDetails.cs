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

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;





namespace PMDS.GUI.Fortbildung
{


    public partial class ucFortbildungBenutzerDetails : UserControl
    {

        public Nullable<Guid> _IDFortbildungBenutzer = null;
        public Nullable<Guid> _IDFortbildung = null;
        public Nullable<Guid> _IDBenutzer = null;

        public bool _IsNew = false;
        public eTypeFortbildungenUI _TypeFortbildungenUI;

        public tblFortbildungBenutzer rFortbildungBenutzer = null;
        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        public bool Isinitialized = false;

        public ucFortbildungenMain mainWindow = null;
        public bool _OnlyRead = true;







        public ucFortbildungBenutzerDetails()
        {
            InitializeComponent();
        }

        private void ucFortbildungBenutzerDetails_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                    this._db = PMDSBusiness.getDBContext();

                    this.ucDokumente1.initControl();

                    this.clearUI2();
                    this.panelBottom.Visible = false;

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.initControl: " + ex.ToString());
            }
        }
        public void clearUI2()
        {
            try
            {
                this.uceAnmeldedatum.Value = null;
                this.optErfolg.Value = -1;
                this.uceAbgeschlossenAm.Value = null;
                this.uceZuErneuernAm.Value = null;
                this.cboStatus.Value = "Undefiniert";
                this.txtAnmerkung.Text = "";

                this.ucDokumente1.clearUI();

                this.lblDokumente.Visible = false;
                this.ucDokumente1.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDFortbildungBenutzer, Guid IDFortbildung, Guid IDBenutzer, bool IsNew, eTypeFortbildungenUI TypeFortbildungenUI, bool OnlyRead)
        {
            try
            {
                this._IDFortbildungBenutzer = IDFortbildungBenutzer;
                this._IDFortbildung = IDFortbildung;
                this._IDBenutzer = IDBenutzer;

                this._IsNew = IsNew;
                this._TypeFortbildungenUI = TypeFortbildungenUI;
                this._OnlyRead = OnlyRead;
                this.panelBottom.Visible = true;    //!this._OnlyRead;

                this.clearUI2();
                if (IsNew)
                {
                    this.rFortbildungBenutzer = new tblFortbildungBenutzer();
                    this.b.newRowFortbildungBenutzer(ref this.rFortbildungBenutzer);
                    this.rFortbildungBenutzer.IDBenutzer = (Guid)this._IDBenutzer;
                    this.rFortbildungBenutzer.IDFortbildung = (Guid)this._IDFortbildung;
                    this._IDFortbildungBenutzer = this.rFortbildungBenutzer.ID;
                    this._db.tblFortbildungBenutzer.Add(this.rFortbildungBenutzer);

                    this.lblDokumente.Visible = false;
                    this.ucDokumente1.Visible = false;
                }
                else
                {
                    System.Linq.IQueryable<tblFortbildungBenutzer> tFortbildungBenutzer = this._db.tblFortbildungBenutzer.Where(p => p.ID == (Guid)this._IDFortbildungBenutzer);
                    this.rFortbildungBenutzer = tFortbildungBenutzer.First();

                    this.lblDokumente.Visible = true;
                    this.ucDokumente1.Visible = true;
                }

                this.uceAnmeldedatum.Value = this.rFortbildungBenutzer.Anmeldedatum;
                this.optErfolg.Value = this.rFortbildungBenutzer.Erfolg;
                this.uceAbgeschlossenAm.Value = this.rFortbildungBenutzer.AbgeschlossenAm;
                this.uceZuErneuernAm.Value = this.rFortbildungBenutzer.ZuErneuernAm;
                this.cboStatus.Value = this.rFortbildungBenutzer.Status.Trim();
                this.txtAnmerkung.Text = this.rFortbildungBenutzer.Anmerkung.Trim();

                this.ucDokumente1.loadDokumente2(this._IDFortbildungBenutzer);

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.loadData: " + ex.ToString());
            }
        }

        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.uceAnmeldedatum, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.ClearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.ClearErrorProvider();

                if (this.uceAnmeldedatum.Value == null)
                {
                    this.errorProvider1.SetError(this.uceAnmeldedatum, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Anmeldedatum: Angabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.validateData: " + ex.ToString());
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

                if (this.uceAnmeldedatum.Value != null)
                {
                    this.rFortbildungBenutzer.Anmeldedatum = this.uceAnmeldedatum.DateTime;
                }
                else
                {
                    this.rFortbildungBenutzer.Anmeldedatum = null;
                }
                this.rFortbildungBenutzer.Erfolg = (int)this.optErfolg.Value;
                if (this.uceAbgeschlossenAm.Value != null)
                {
                    this.rFortbildungBenutzer.AbgeschlossenAm = this.uceAbgeschlossenAm.DateTime;
                }
                else
                {
                    this.rFortbildungBenutzer.AbgeschlossenAm = null;
                }
                if (this.uceZuErneuernAm.Value != null)
                {
                    this.rFortbildungBenutzer.ZuErneuernAm = this.uceZuErneuernAm.DateTime;
                }
                else
                {
                    this.rFortbildungBenutzer.ZuErneuernAm = null;
                }

                if (this.cboStatus.Value != null)
                {
                    this.rFortbildungBenutzer.Status = this.cboStatus.Value.ToString().Trim();
                }
                else
                {
                    this.rFortbildungBenutzer.Status = "";
                }
                this.rFortbildungBenutzer.Anmerkung = this.txtAnmerkung.Text.Trim();

                this._db.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.b.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerDetails.saveData: " + ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    if (this._IsNew)
                    {
                        this.mainWindow.mainWindow.ucFortbildungenList1.loadData(this.mainWindow.mainWindow.ucFortbildungenList1._IDVeranstalter, this.mainWindow.mainWindow.ucFortbildungenList1._IDBenutzer, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this.rFortbildungBenutzer.IDFortbildung);
                        this.mainWindow.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerList1.selectItem(this.rFortbildungBenutzer.ID);
                    }
                    else
                    {
                        //UltraGridRow rGridSel = null;
                        //tblFortbildungen rSelFortbildung = this.mainWindow.mainWindow.ucFortbildungenList1.getSelectedRow(false, ref rGridSel);
                        //if (rSelFortbildung != null)
                        //{
                        //    //rSelFortbildung.Bezeichnung = this.rFortbildungBenutzer.Bezeichnung;
                        //    //this.mainWindow.mainWindow.ucFortbildungenList1.gridFortbildungen.Refresh();
                        //}
                    }
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
    }
}
