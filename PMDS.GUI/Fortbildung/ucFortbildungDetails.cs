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


    public partial class ucFortbildungDetails : UserControl
    {

        public Nullable<Guid> _IDFortbildung = null;
        public Guid _IDVeranstalter;
        
        public bool _IsNew = false;
        public eTypeFortbildungenUI _TypeFortbildungenUI;

        public tblFortbildungen rFortbildungen = null;
        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        public bool Isinitialized = false;

        public ucFortbildungenMain mainWindow = null;
        public bool _OnlyRead = true;








        public ucFortbildungDetails()
        {
            InitializeComponent();
        }

        private void ucFortbildungDetails_Load(object sender, EventArgs e)
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
                    this.clearUI();
                    this.panelBottom.Visible = false;

                    this.ucDokumente1.initControl();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungDetails.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtBezeichnung.Text = "";
                this.uceBeginn.Value = null;
                this.uceEnde.Value = null;
                this.iAnzahlStunden.Value = -1;
                this.iAnzahlFreiePlätze.Value = -1;
                this.txtZertifikat.Text = "";
                this.txtVortragender.Text = "";
                this.txtVeranstaltungsort.Text = "";
                this.txtVoraussetzungen.Text = "";
                this.txtBeschreibung.Text = "";

                this.ucDokumente1.clearUI();
                this.ucDokumente1.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungDetails.clearUI: " + ex.ToString());
            }
        }

        public void loadData(Nullable<Guid> IDFortbildung, Guid IDVeranstalter, bool IsNew, eTypeFortbildungenUI TypeFortbildungenUI, bool OnlyRead)
        {
            try
            {
                this._IDFortbildung = IDFortbildung;
                this._IDVeranstalter = IDVeranstalter;
                this._IsNew = IsNew;
                this._TypeFortbildungenUI = TypeFortbildungenUI;
                this._OnlyRead = OnlyRead;
                this.panelBottom.Visible = !this._OnlyRead;

                this.clearUI();
                if (IsNew)
                {
                    this.rFortbildungen = new tblFortbildungen();
                    this.b.newRowFortbildungen(ref this.rFortbildungen);
                    this.rFortbildungen.IDVeranstalter = this._IDVeranstalter;
                    this._IDFortbildung = this.rFortbildungen.ID;
                    this._db.tblFortbildungen.Add(this.rFortbildungen);
                    this.ucDokumente1.Visible = false;
                }
                else
                {
                    System.Linq.IQueryable<tblFortbildungen> tFortbildungen = this._db.tblFortbildungen.Where(p => p.ID == (Guid)this._IDFortbildung);
                    this.rFortbildungen = tFortbildungen.First();
                    this.ucDokumente1.Visible = true;
                }

                this.txtBezeichnung.Text = this.rFortbildungen.Bezeichnung.Trim();
                this.uceBeginn.Value = this.rFortbildungen.Beginn;
                this.uceEnde.Value = this.rFortbildungen.Ende;
                this.iAnzahlStunden.Value = this.rFortbildungen.AnzahlStunden;
                this.iAnzahlFreiePlätze.Value = this.rFortbildungen.AnzahlFreiePlätze;
                this.txtZertifikat.Text = this.rFortbildungen.Zertifikat.Trim();
                this.txtVortragender.Text = this.rFortbildungen.Vortragender.Trim();
                this.txtVeranstaltungsort.Text = this.rFortbildungen.Veranstaltungsort.Trim();
                this.txtVoraussetzungen.Text = this.rFortbildungen.Voraussetzungen.Trim();
                this.txtBeschreibung.Text = this.rFortbildungen.Beschreibung.Trim();

                this.ucDokumente1.loadDokumente2(this._IDFortbildung);

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungDetails.loadData: " + ex.ToString());
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
                throw new Exception("ucFortbildungDetails.ClearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
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
                throw new Exception("ucFortbildungDetails.validateData: " + ex.ToString());
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

                this.rFortbildungen.Bezeichnung = this.txtBezeichnung.Text.Trim();
                if (this.uceBeginn.Value != null)
                {
                    this.rFortbildungen.Beginn = this.uceBeginn.DateTime;
                }
                else
                {
                    this.rFortbildungen.Beginn = null;
                }
                
                if (this.uceEnde.Value != null)
                {
                    this.rFortbildungen.Ende = this.uceEnde.DateTime;
                }
                else
                {
                    this.rFortbildungen.Ende = null;
                }
                
                this.rFortbildungen.AnzahlStunden = (int)this.iAnzahlStunden.Value;
                this.rFortbildungen.AnzahlFreiePlätze = (int)this.iAnzahlFreiePlätze.Value;
                this.rFortbildungen.Zertifikat = this.txtZertifikat.Text.Trim();
                this.rFortbildungen.Vortragender = this.txtVortragender.Text.Trim();
                this.rFortbildungen.Veranstaltungsort = this.txtVeranstaltungsort.Text.Trim();
                this.rFortbildungen.Voraussetzungen = this.txtVoraussetzungen.Text.Trim();
                this.rFortbildungen.Beschreibung = this.txtBeschreibung.Text.Trim();

                this._db.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.b.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungDetails.saveData: " + ex.ToString());
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
                        this.mainWindow.mainWindow.ucFortbildungenList1.loadData(this.mainWindow.mainWindow.ucFortbildungenList1._IDVeranstalter, this.mainWindow.mainWindow.ucFortbildungenList1._IDBenutzer, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this.rFortbildungen.ID);
                    }
                    else
                    {
                        UltraGridRow rGridSel = null;
                        tblFortbildungen rSelFortbildung = this.mainWindow.mainWindow.ucFortbildungenList1.getSelectedRow(false, ref rGridSel);
                        if (rSelFortbildung != null)
                        {
                            rSelFortbildung.Bezeichnung = this.rFortbildungen.Bezeichnung;
                            this.mainWindow.mainWindow.ucFortbildungenList1.gridFortbildungen.Refresh();
                        }
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
