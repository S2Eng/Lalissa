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
using PMDS.Global.db.ERSystem;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOBestellvorschlaegeDetail : UserControl
    {
        public Nullable<Guid> _IDVOBestellpostitionen = null;
        public VO_Bestellpostitionen _rVO_BestellpostitionenEF = null;
        public dsVO.VO_BestellpostitionenRow _rVO_BestellpostitionenDS = null;
        public bool _IsNew = false;
        public Nullable<Guid> _IDVO_Bestelldaten = null;

        public eTypeUI _TypeUI = new ucVOBestellvorschlaegeDetail.eTypeUI();
        public bool abort = true;
        public frmVOBestellvorschlaegeDetail mainWindow = null;
      
        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;

        public enum eTypeUI
        {
            Bestellvorschläge = 0,
            Lieferung = 1
        }

        public Nullable<DateTime> _DatumNächsterAnspruch = null;








        public ucVOBestellvorschlaegeDetail()
        {
            InitializeComponent();
        }

        private void ucVOBestelldatenDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(eTypeUI TypeUI, Nullable<Guid> IDVOBestellpostitionen, dsVO.VO_BestellpostitionenRow rVO_Bestellpostitionen, bool IsNew, Nullable<Guid> IDVO_Bestelldaten, Nullable<DateTime> DatumNächsterAnspruch)
        {
            try
            {
                this._IDVOBestellpostitionen = IDVOBestellpostitionen;
                this._TypeUI = TypeUI;
                this._rVO_BestellpostitionenDS = rVO_Bestellpostitionen;
                this._IsNew = IsNew;
                this._IDVO_Bestelldaten = IDVO_Bestelldaten;
                this._DatumNächsterAnspruch = DatumNächsterAnspruch;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnSearchMedikmanete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.btnSearchMedikmaneteGeliefert.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                if (this._TypeUI == eTypeUI.Bestellvorschläge)
                {
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellvorschlag Detail");
                }
                else if (this._TypeUI == eTypeUI.Lieferung )
                {
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Lieferung erfassen");
                }

                this.SelListChanged("", null, null);

                this._db = PMDSBusiness.getDBContext();
                this.setUI();
                this.clearUI();
                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.initControl: " + ex.ToString());
            }
        }

        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheitBestellung, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheitLieferung, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("LFT", this.cboLieferant, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("BSS", this.cboStatus, null, null, ref lstEmpty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.SelListChanged: " + ex.ToString());
            }
        }

        public void setUI()
        {
            try
            {
                if (this._TypeUI == eTypeUI.Bestellvorschläge)
                {
                    this.btnSearchMedikmanete.Visible = true;
                    this.txtMedikament.Enabled = true;
                    this.udteDatumBestellung.Enabled = true;

                    this.numMengeBestellung.Enabled = true;
                    this.cboEinheitBestellung.Enabled = true;
                    this.cboLieferant.Enabled = true;
                    this.txtHinweisLieferant.Enabled = true;
                    this.txtAnmerkung.Enabled = true;
                    this.lblDatumNächsterAnspruch.Enabled = true;
                    this.udteDatumNaechsterAnspruch.Enabled = true;
                    this.lblDatumNächsterAnspruch.Visible = true;
                    this.udteDatumNaechsterAnspruch.Visible = true;

                    this.lblMedikamentGeliefert.Visible = false;
                    this.txtMedikamentGeliefert.Visible = false;
                    this.btnSearchMedikmaneteGeliefert.Visible = false;
                    this.lblEinheitLieferung.Visible = false;
                    this.lblStatus.Visible = false;
                    this.cboStatus.Visible = false;
                    this.lblDatumLieferung.Visible = false;
                    this.udteDatumLieferung.Visible = false;
                    this.lblMengeLieferung.Visible = false;
                    this.inumMengeLieferung.Visible = false;
                    this.cboEinheitLieferung.Visible = false;
                    this.lblBemerkungLieferung.Visible = false;
                    this.txtBemerkungLieferung.Visible = false;

                    this.mainWindow.Width = 490;
                }
                else if (this._TypeUI == eTypeUI.Lieferung)
                {
                    this.btnSearchMedikmanete.Visible = false;
                    this.txtMedikament.Enabled = false;
                    this.udteDatumBestellung.Enabled = false;

                    this.numMengeBestellung.Enabled = false;
                    this.cboEinheitBestellung.Enabled = false;
                    this.cboLieferant.Enabled = false;
                    this.txtHinweisLieferant.Enabled = false;
                    this.txtAnmerkung.Enabled = false;
                    this.lblDatumNächsterAnspruch.Visible = false;
                    this.udteDatumNaechsterAnspruch.Visible = false;

                    this.mainWindow.Width = 988;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.setUI: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtMedikament.Text = "";
                this.txtMedikament.Tag = null;
                this.udteDatumBestellung.Value = null;

                this.numMengeBestellung.Value = 0;
                this.cboEinheitBestellung.Value = null;
                this.cboLieferant.Value = null;
                this.txtHinweisLieferant.Text = "";
                this.txtAnmerkung.Text = "";

                this.udteDatumLieferung.Value = null;
                this.inumMengeLieferung.Value = 0;
                this.cboEinheitLieferung.Value = "";
                this.txtBemerkungLieferung.Text = "";

                this.udteDatumNaechsterAnspruch.Value = null;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.clearUI: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clearUI();
                DateTime dNow = DateTime.Now;

                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(this._db);

                if (this._TypeUI == eTypeUI.Bestellvorschläge)
                {
                    IQueryable<PMDS.db.Entities.VO_Bestelldaten> tVO_Bestelldaten = this._db.VO_Bestelldaten.Where(o => o.ID == this._rVO_BestellpostitionenDS.IDBestelldaten_VO);
                    VO_Bestelldaten rVO_Bestelldaten = tVO_Bestelldaten.First();

                    IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == rVO_Bestelldaten.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                    this.txtMedikament.Tag = rMedikament.ID;
                    this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();

                    this.udteDatumBestellung.DateTime = this._rVO_BestellpostitionenDS.DatumBestellung;
                    this.numMengeBestellung.Value = this._rVO_BestellpostitionenDS.MengeBestellung;
                    this.cboEinheitBestellung.Text = this._rVO_BestellpostitionenDS.EinheitBestellung;
                    if (!this._rVO_BestellpostitionenDS.IsLieferantNull())
                    {
                        this.cboLieferant.Value = this._rVO_BestellpostitionenDS.Lieferant;
                    }
                    else
                    {
                        this.cboLieferant.Value = null;
                    }
                    this.txtHinweisLieferant.Text = this._rVO_BestellpostitionenDS.HinweisLieferant;
                    this.txtAnmerkung.Text = this._rVO_BestellpostitionenDS.Anmerkung;
                    if (this._DatumNächsterAnspruch != null)
                    {
                        this.udteDatumNaechsterAnspruch.DateTime = this._DatumNächsterAnspruch.Value.Date;
                    }
                }
                else if (this._TypeUI == eTypeUI.Lieferung)
                {
                    if (this._IsNew)
                    {
                        throw new Exception("ucVOBestellvorschlaegeDetail.loadData: _IsNew=1 not allowed!");

                        /*
                        this._rVO_BestellpostitionenEF = PMDS.Global.db.ERSystem.EFEntities.newVO_Bestellpostitionen(this._db);
                        this._rVO_BestellpostitionenEF.ID = System.Guid.NewGuid();
                        this._rVO_BestellpostitionenEF.IDBestelldaten_VO = this._IDVO_Bestelldaten.Value;
                        this._rVO_BestellpostitionenEF.DatumLieferung = dNow.Date;
                        this.udteDatumLieferung.Value = dNow.Date;

                        //IQueryable<PMDS.db.Entities.VO> tVO = this._db.VO.Where(o => o.ID == this._IDVO);
                        //PMDS.db.Entities.VO rVO = tVO.First();
                        //IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == rVO.IDMedikament);
                        //PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                        //this.txtMedikament.Tag = rMedikament.ID;
                        //this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();

                        this._rVO_BestellpostitionenEF.DatumErstellt = dNow;
                        this._rVO_BestellpostitionenEF.DatumGeaendert = dNow;
                        this._rVO_BestellpostitionenEF.IDBenutzerErstellt = rBenutzer.ID;
                        this._rVO_BestellpostitionenEF.IDBenutzerGeaendert = rBenutzer.ID;
                        this._rVO_BestellpostitionenEF.LoginNameFreiErstellt = PMDS.Global.Settings.LoginInNameFrei.Trim();
                        this._rVO_BestellpostitionenEF.LoginNameFreiGeaendert = PMDS.Global.Settings.LoginInNameFrei.Trim();

                        this._db.VO_Bestellpostitionen.Add(this._rVO_BestellpostitionenEF);
                        */
                    }
                    else
                    {
                        IQueryable<PMDS.db.Entities.VO_Bestellpostitionen> tVO_Bestellpostitionen = this._db.VO_Bestellpostitionen.Where(o => o.ID == this._IDVOBestellpostitionen);
                        this._rVO_BestellpostitionenEF = tVO_Bestellpostitionen.First();
                        IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == this._rVO_BestellpostitionenEF.IDMedikament);
                        PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                        this.txtMedikament.Tag = rMedikament.ID;
                        this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();

                        IQueryable<PMDS.db.Entities.Medikament> tMedikamentGeliefert = this._db.Medikament.Where(o => o.ID == this._rVO_BestellpostitionenEF.IDMedikamentGeliefert);
                        PMDS.db.Entities.Medikament rMedikamentGeliefert = tMedikamentGeliefert.First();
                        this.txtMedikamentGeliefert.Tag = rMedikamentGeliefert.ID;
                        this.txtMedikamentGeliefert.Text = rMedikamentGeliefert.Bezeichnung.Trim();

                        this._rVO_BestellpostitionenEF.DatumGeaendert = dNow;
                        this._rVO_BestellpostitionenEF.IDBenutzerGeaendert = rBenutzer.ID;
                        this._rVO_BestellpostitionenEF.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        if (!this._rVO_BestellpostitionenEF.UserChanged)
                        {
                            this._rVO_BestellpostitionenEF.MengeLieferung = this._rVO_BestellpostitionenEF.MengeBestellung;
                            this._rVO_BestellpostitionenEF.EinheitLieferung = this._rVO_BestellpostitionenEF.EinheitBestellung;
                            this._rVO_BestellpostitionenEF.Status = PMDSBusiness.IDVOStatusGeliefert;
                        }
                    }

                    this.udteDatumBestellung.Value = this._rVO_BestellpostitionenEF.DatumBestellung.Date;
                    this.numMengeBestellung.Value = this._rVO_BestellpostitionenEF.MengeBestellung;
                    this.cboEinheitBestellung.Value = this._rVO_BestellpostitionenEF.EinheitBestellung;
                    if (this._rVO_BestellpostitionenEF.Lieferant != null)
                    {
                        this.cboLieferant.Value = this._rVO_BestellpostitionenEF.Lieferant;
                    }
                    else
                    {
                        this.cboLieferant.Value = null;
                    }
                    this.txtHinweisLieferant.Text = this._rVO_BestellpostitionenEF.HinweisLieferant.Trim();
                    this.txtAnmerkung.Text = this._rVO_BestellpostitionenEF.Anmerkung.Trim();
                    
                    this.udteDatumLieferung.Value = this._rVO_BestellpostitionenEF.DatumLieferung;
                    this.inumMengeLieferung.Value = this._rVO_BestellpostitionenEF.MengeLieferung;
                    this.cboEinheitLieferung.Value = this._rVO_BestellpostitionenEF.EinheitLieferung;
                    this.cboStatus.Value = this._rVO_BestellpostitionenEF.Status;
                    this.txtBemerkungLieferung.Text = this._rVO_BestellpostitionenEF.BemerkungLieferung.Trim();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.udteDatumBestellung, "");
                this.errorProvider1.SetError(this.udteDatumLieferung, "");
                this.errorProvider1.SetError(this.inumMengeLieferung, "");
                this.errorProvider1.SetError(this.cboEinheitLieferung, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.clearErrorProvider: " + ex.ToString());
            }
        }
        

        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                if (this._TypeUI == eTypeUI.Bestellvorschläge)
                {
                    if (this.udteDatumBestellung.Value == null)
                    {
                        this.errorProvider1.SetError(this.udteDatumBestellung, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datumn Bestellung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
                else if (this._TypeUI == eTypeUI.Lieferung)
                {
                    if (this.udteDatumLieferung.Value == null)
                    {
                        this.errorProvider1.SetError(this.udteDatumLieferung, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datumn Lieferung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.inumMengeLieferung.Value == null)
                    {
                        this.errorProvider1.SetError(this.inumMengeLieferung, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Menge Lieferung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.cboStatus.Value == null)
                    {
                        this.errorProvider1.SetError(this.cboStatus, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        if (this.cboStatus.Value.GetType() != typeof(Guid))
                        {
                            this.errorProvider1.SetError(this.cboStatus, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.validateData: " + ex.ToString());
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

                if (this._TypeUI == eTypeUI.Bestellvorschläge)
                {
                    this._rVO_BestellpostitionenDS.IDMedikament = (Guid)this.txtMedikament.Tag;
                    this._rVO_BestellpostitionenDS.IDMedikamentGeliefert = this._rVO_BestellpostitionenDS.IDMedikament;
                    this._rVO_BestellpostitionenDS.DatumBestellung = this.udteDatumBestellung.DateTime.Date;
                    this._rVO_BestellpostitionenDS.MengeBestellung = (double)this.numMengeBestellung.Value;
                    this._rVO_BestellpostitionenDS.EinheitBestellung = this.cboEinheitBestellung.Text;
                    if (this.cboLieferant.Value != null)
                    {
                        this._rVO_BestellpostitionenDS.Lieferant = (Guid)this.cboLieferant.Value;
                    }
                    else
                    {
                        this._rVO_BestellpostitionenDS.SetLieferantNull();
                    }
                    this._rVO_BestellpostitionenDS.HinweisLieferant = this.txtHinweisLieferant.Text.Trim();
                    this._rVO_BestellpostitionenDS.Anmerkung = this.txtAnmerkung.Text.Trim();

                }
                else if (this._TypeUI == eTypeUI.Lieferung)
                {
                    //this._rVO_BestellpostitionenEF.DatumBestellung = this.udteDatumBestellung.DateTime.Date;
                    //this._rVO_BestellpostitionenEF.MengeBestellung = (double)this.numMengeBestellung.Value;
                    //this._rVO_BestellpostitionenEF.EinheitBestellung = this.cboEinheitBestellung.Value.ToString();
                    //this._rVO_BestellpostitionenEF.Lieferant = (Guid)this.cboLieferant.Value;
                    //this._rVO_BestellpostitionenEF.HinweisLieferant = this.txtHinweisLieferant.Text.Trim();
                    //this._rVO_BestellpostitionenEF.Anmerkung = this.txtAnmerkung.Text.Trim();

                    this._rVO_BestellpostitionenDS.IDMedikamentGeliefert = (Guid)this.txtMedikamentGeliefert.Tag;
                    this._rVO_BestellpostitionenEF.DatumLieferung = this.udteDatumLieferung.DateTime.Date;
                    this._rVO_BestellpostitionenEF.MengeLieferung = (double)this.inumMengeLieferung.Value;
                    this._rVO_BestellpostitionenEF.EinheitLieferung = this.cboEinheitLieferung.Text.Trim();
                    this._rVO_BestellpostitionenEF.BemerkungLieferung = this.txtBemerkungLieferung.Text.Trim();
                    this._rVO_BestellpostitionenEF.Status = (Guid)this.cboStatus.Value;
                    this._rVO_BestellpostitionenEF.UserChanged = true;

                    this._db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.saveData: " + ex.ToString());
            }
        }

        public void searchMedikament(bool searchMedikamentLieferung)
        {
            try
            {
                PMDS.GUI.Medikament.frmSearchMedikamente frm = new Medikament.frmSearchMedikamente();
                frm.initControl();
                frm.ShowDialog(this);
                if (!frm.contSearchMedikamente1.abort)
                {
                    if (!searchMedikamentLieferung)
                    {
                        this._rVO_BestellpostitionenDS.IDMedikamentGeliefert = frm.contSearchMedikamente1.rSelMedikament.ID;
                        this.txtMedikament.Tag = frm.contSearchMedikamente1.rSelMedikament.ID;
                        this.txtMedikament.Text = frm.contSearchMedikamente1.rSelMedikament.Bezeichnung.Trim();
                        this.cboEinheitLieferung.Text = frm.contSearchMedikamente1.rSelMedikament.Packungseinheit;
                    }
                    else
                    {
                        this._rVO_BestellpostitionenEF.IDMedikamentGeliefert = frm.contSearchMedikamente1.rSelMedikament.ID;
                        this.txtMedikamentGeliefert.Tag = frm.contSearchMedikamente1.rSelMedikament.ID;
                        this.txtMedikamentGeliefert.Text = frm.contSearchMedikamente1.rSelMedikament.Bezeichnung.Trim();
                        this.cboEinheitLieferung.Text = frm.contSearchMedikamente1.rSelMedikament.Packungseinheit;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.searchMedikament: " + ex.ToString());
            }
        }

        public void resizeControl()
        {
            try
            {
                this.txtMedikamentGeliefert.Width = this.Width - this.txtMedikamentGeliefert.Left - this.btnSearchMedikmaneteGeliefert.Width - 8;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellvorschlaegeDetail.resizeControl: " + ex.ToString());
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

        private void cboEinheitBestellung_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("MEH");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheitBestellung, null, this.cboEinheitBestellung.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("MEH", this.cboEinheitBestellung, null);
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
        private void cboLieferant_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("LFT");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("LFT", this.cboLieferant, null, this.cboLieferant.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("LFT", this.cboLieferant, null);
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
        private void cboEinheitLieferung_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("MEH");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheitLieferung, null, this.cboEinheitLieferung.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("MEH", this.cboEinheitLieferung, null);
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
        private void cboStatus_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("BSS");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("BSS", this.cboStatus, null, this.cboStatus.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("BSS", this.cboStatus, null);
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
        private void btnSearchMedikmanete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchMedikament(true);

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
        private void btnSearchMedikmanete_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchMedikament(false);

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

        private void ucVOBestellvorschlaegeDetail_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void ucVOBestellvorschlaegeDetail_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.resizeControl();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
