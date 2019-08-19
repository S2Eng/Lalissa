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

    public partial class ucVOErfassenDetail : UserControl
    {
        public Nullable<Guid> _IDVO = null;

        public Nullable<Guid> _IDAufenthalt = null;
        public Nullable<Guid> _IDPflegeplan = null;
        public Nullable<Guid> _IDMedDaten2 = null;
        public Nullable<Guid> _IDWundeKopf = null;
        public PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI _TypeUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI();
        public bool _IsNew = false;
        public bool _WithPatientSelektor = false;
        public bool _Einzelansicht = false;

        public PMDS.db.Entities.VO _rVo = null;
        public PMDS.db.Entities.VO_MedizinischeDaten _rVO_MedizinischeDaten = null;
        public PMDS.db.Entities.VO_PflegeplanPDX _rVO_PflegeplanPDX = null;
        public PMDS.db.Entities.VO_Wunde _rVO_Wunde = null;

        public bool _bEditable = true;
        public bool abort = true;
        public frmVOErfassenDetail mainWindow = null;

        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
     








        public ucVOErfassenDetail()
        {
            InitializeComponent();
        }

        private void ucVOErfassenDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI TypeUI, bool IsNew, Nullable<Guid> IDVO, Nullable<Guid> IDAufenthalt, Nullable<Guid> IDPflegeplan, 
                                Nullable<Guid> IDMedDaten, Nullable<Guid> IDWundeKopf, bool WithPatientSelektor, bool Einzelansicht, Nullable<Guid> TypDefault)
        {
            try
            {
                this._IsNew = IsNew;
                this._IDVO = IDVO;
                this._IDAufenthalt = IDAufenthalt;
                this._IDPflegeplan = IDPflegeplan;
                this._IDMedDaten2 = IDMedDaten;
                this._IDWundeKopf = IDWundeKopf;
                this._TypeUI = TypeUI;
                this._WithPatientSelektor = WithPatientSelektor;
                this._Einzelansicht = Einzelansicht;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnSearchMedikmanete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                this.btnSave.Visible = this._bEditable;
                this.btnAbort.Visible = this._bEditable;

                if (this._WithPatientSelektor && this._IsNew)
                {
                    this.dropDownPatienten.Visible = true;
                    this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                    bool IsSearch = true;
                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1._SingleSelect = true;
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients, IsSearch, isTxtTemplate, this.dropDownPatienten);
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatientenBenutzer1;
                    this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    bool IDFoundInTree2 = false;
                    this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(System.Guid.Empty, System.Guid.Empty, false, null, true, VB.contPlanungData.eTypeUI.PlansAll, ref IDFoundInTree2);
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    if (this._Einzelansicht && this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        if (ENV.CurrentIDPatient != System.Guid.Empty)
                        {
                            bool IDFoundInTree3 = false;
                            this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(ENV.CurrentIDPatient, ref IDFoundInTree3);
                            this.contSelectPatientenBenutzer1.setLabelCount2();
                        }
                    }
                }
                else
                {
                    this.dropDownPatienten.Visible = true;
                    this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                    bool IsSearch = true;
                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1._SingleSelect = true;
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients, IsSearch, isTxtTemplate, this.dropDownPatienten);
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatientenBenutzer1;
                    this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    bool IDFoundInTree2 = false;
                    this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(System.Guid.Empty, System.Guid.Empty, false, null, true, VB.contPlanungData.eTypeUI.PlansAll, ref IDFoundInTree2);
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    if (this._Einzelansicht && this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        if (ENV.CurrentIDPatient != System.Guid.Empty)
                        {
                            bool IDFoundInTree3 = false;
                            this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(ENV.CurrentIDPatient, ref IDFoundInTree3);
                            this.contSelectPatientenBenutzer1.setLabelCount2();
                        }
                    }
                }

                this.SelListChanged("", null, null);

                this._db = PMDSBusiness.getDBContext();
                this.clearUI();

                //PMDSBusinessUI.dSelListChanged += new PMDSBusinessUI.SelListChanged(this.SelListChanged);

                this.loadData(TypDefault);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.initControl: " + ex.ToString());
            }
        }
        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.PMDSBusinessUI2.loadSelList("VOT", this.cboTyp, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheit, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("LFT", this.cboLieferant, null, null, ref lstEmpty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.SelListChanged: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.udteVerordnetAb.Value = DateTime.Now.Date;
                this.udteVerordnetBis.Value = null;
                this.cboTyp.Value = null;
                this.cboEinheit.Value = null;
                this.numMenge.Value = 0;
                this.txtBestätigtVon.Text = "";
                this.txtHinweis.Text = "";
                this.cboLieferant.Value = null;
                this.txtHinweisLieferant.Text = "";
                this.txtAnmerkung.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.clearUI: " + ex.ToString());
            }
        }

        public void setPatientenpicker(Guid IDPatient)
        {
            try
            {
                if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                {
                    bool IDFoundInTree3 = false;
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(IDPatient, ref IDFoundInTree3);
                    this.contSelectPatientenBenutzer1.setLabelCount2();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setPatientenpicker: " + ex.ToString());
            }
        }

        public void loadData(Nullable<Guid> TypDefault)
        {
            try
            {
                this.clearUI();
                DateTime dNow = DateTime.Now;

                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(this._db);

                if (this._IsNew)
                {
                    this._rVo = PMDS.Global.db.ERSystem.EFEntities.newVO(this._db);
                    this._rVo.ID = System.Guid.NewGuid();
                    if (this._TypeUI != PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        this._rVo.IDAufenthalt = this._IDAufenthalt.Value;
                    }
                    this._rVo.DatumVerordnetAb = dNow.Date;
                    this.udteVerordnetAb.Value = dNow.Date;
                    this._rVo.DatumVerordnetBis = null;
                    this.udteVerordnetBis.Value = null;
                    this.txtMedikament.Tag = null;

                    this._rVo.DatumErstellt = dNow;
                    this._rVo.DatumGeaendert = dNow;
                    this._rVo.IDBenutzerErstellt = rBenutzer.ID;
                    this._rVo.IDBenutzerGeaendert = rBenutzer.ID;
                    this._rVo.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    this._rVo.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                    if (TypDefault != null)
                    {
                        this._rVo.Typ = TypDefault.Value;
                        this.cboTyp.Value = this._rVo.Typ;
                    }

                    this._db.VO.Add(this._rVo);

                    if (this._IDMedDaten2 != null)
                    {
                        this._rVO_MedizinischeDaten = PMDS.Global.db.ERSystem.EFEntities.newVO_MedizinischeDaten(this._db);
                        this._rVO_MedizinischeDaten.ID = System.Guid.NewGuid();
                        this._rVO_MedizinischeDaten.IDVerordnung = this._rVo.ID;
                        this._rVO_MedizinischeDaten.IDMedizinischeDaten = this._IDMedDaten2.Value;
                        this._rVO_MedizinischeDaten.DatumErstellt = dNow;
                        this._rVO_MedizinischeDaten.DatumGeaendert = dNow;
                        this._rVO_MedizinischeDaten.IDBenutzerErstellt = rBenutzer.ID;
                        this._rVO_MedizinischeDaten.IDBenutzerGeaendert = rBenutzer.ID;
                        this._rVO_MedizinischeDaten.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        this._rVO_MedizinischeDaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                        this._db.VO_MedizinischeDaten.Add(this._rVO_MedizinischeDaten);
                    }
                    if (this._IDPflegeplan != null)
                    {
                        IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDx = this._db.PflegePlanPDx.Where(o => o.IDPflegePlan == this._IDPflegeplan);
                        PflegePlanPDx rPflegePlanPDx = tPflegePlanPDx.First();

                        this._rVO_PflegeplanPDX = PMDS.Global.db.ERSystem.EFEntities.newVO_PflegeplanPDX(this._db);
                        this._rVO_PflegeplanPDX.ID = System.Guid.NewGuid();
                        this._rVO_PflegeplanPDX.IDVerordnung = this._rVo.ID;
                        if (rPflegePlanPDx.IDUntertaegigeGruppe == null)
                        {
                            throw new Exception("ucVOErfassenDetail.loadData: rPflegePlanPDx.IDUntertaegigeGruppe == null for IDPflegeplan '" + this._IDPflegeplan.ToString() + "'!");
                        }
                        this._rVO_PflegeplanPDX.IDUntertaegigeGruppe = rPflegePlanPDx.IDUntertaegigeGruppe.Value;
                        this._rVO_PflegeplanPDX.DatumEsrstellt = dNow;
                        this._rVO_PflegeplanPDX.DatumGeaendert = dNow;
                        this._rVO_PflegeplanPDX.IDBenutzerErstellt = rBenutzer.ID;
                        this._rVO_PflegeplanPDX.IDBenutzerGeaendert = rBenutzer.ID;
                        this._rVO_PflegeplanPDX.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        this._rVO_PflegeplanPDX.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                        this._db.VO_PflegeplanPDX.Add(this._rVO_PflegeplanPDX);
                    }
                    if (this._IDWundeKopf != null)
                    {
                        this._rVO_Wunde = PMDS.Global.db.ERSystem.EFEntities.newVO_Wunde(this._db);
                        this._rVO_Wunde.ID = System.Guid.NewGuid();
                        this._rVO_Wunde.IDVerordnung = this._rVo.ID;
                        this._rVO_Wunde.IDWundeKopf = this._IDWundeKopf.Value;
                        this._rVO_Wunde.DatumErstellt = dNow;
                        this._rVO_Wunde.DatumGeaendert = dNow;
                        this._rVO_Wunde.IDBenutzerErstellt = rBenutzer.ID;
                        this._rVO_Wunde.IDBenutzerGeaendert = rBenutzer.ID;
                        this._rVO_Wunde.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        this._rVO_Wunde.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    
                        this._db.VO_Wunde.Add(this._rVO_Wunde);
                    }
                }
                else
                {
                    IQueryable<PMDS.db.Entities.VO> tVO = this._db.VO.Where(o => o.ID == this._IDVO);
                    this._rVo = tVO.First();
                    IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == this._rVo.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                    this.txtMedikament.Tag = this._rVo.IDMedikament;
                    this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();

                    this._rVo.DatumGeaendert = dNow;
                    this._rVo.IDBenutzerGeaendert = rBenutzer.ID;
                    this._rVo.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                    IQueryable<PMDS.db.Entities.VO_MedizinischeDaten> tVO_MedizinischeDaten = this._db.VO_MedizinischeDaten.Where(o => o.IDVerordnung == this._rVo.ID);
                    foreach (PMDS.db.Entities.VO_MedizinischeDaten rVO_MedizinischeDaten in tVO_MedizinischeDaten)
                    {
                        rVO_MedizinischeDaten.DatumGeaendert = dNow;
                        rVO_MedizinischeDaten.IDBenutzerGeaendert = rBenutzer.ID;
                        rVO_MedizinischeDaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    }

                    IQueryable<PMDS.db.Entities.VO_PflegeplanPDX> tVO_PflegeplanPDX = this._db.VO_PflegeplanPDX.Where(o => o.IDVerordnung == this._rVo.ID);
                    foreach (PMDS.db.Entities.VO_PflegeplanPDX rVO_PflegeplanPDX in tVO_PflegeplanPDX)
                    {
                        rVO_PflegeplanPDX.DatumGeaendert = dNow;
                        rVO_PflegeplanPDX.IDBenutzerGeaendert = rBenutzer.ID;
                        rVO_PflegeplanPDX.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    }
                }

                this.udteVerordnetAb.Value = this._rVo.DatumVerordnetAb;
                if (this._rVo.DatumVerordnetBis != null)
                {
                    this.udteVerordnetBis.Value = this._rVo.DatumVerordnetBis.Value;
                }

                if (!this._IsNew)
                {
                    this.cboTyp.Value = this._rVo.Typ;
                }
                this.numMenge.Value = this._rVo.Menge;
                this.cboEinheit.Text = this._rVo.Einheit.Trim();
                this.txtBestätigtVon.Text = this._rVo.BestaetigtVon.Trim();
                this.txtHinweis.Text = this._rVo.Hinweis.Trim();

                if (this._rVo.Lieferant != null)
                {
                    this.cboLieferant.Value = this._rVo.Lieferant;
                }
                else
                {
                    this.cboLieferant.Value = null;
                }
                this.txtHinweisLieferant.Text = this._rVo.HinweisLieferant.Trim();
                this.txtAnmerkung.Text = this._rVo.Anmerkung.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.dropDownPatienten, "");
                this.errorProvider1.SetError(this.txtMedikament, "");
                this.errorProvider1.SetError(this.udteVerordnetAb, "");
                this.errorProvider1.SetError(this.udteVerordnetBis, "");
                this.errorProvider1.SetError(this.cboTyp, "");
                this.errorProvider1.SetError(this.cboLieferant, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.clearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                if (this._WithPatientSelektor && this._IsNew)
                {
                    List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();
                    if (lstPatients.Count == 0)
                    {
                        this.errorProvider1.SetError(this.dropDownPatienten, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (lstPatients.Count > 1)
                    {
                        throw new Exception("validateData: lstPatients.Count>1 not allowed!");
                    }
                }

                if (this.txtMedikament.Tag == null)
                {
                    this.errorProvider1.SetError(this.txtMedikament, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Verordnung ausgewählt!", "", MessageBoxButtons.OK);
                    return false;
                }

                if (this.udteVerordnetAb.Value == null)
                {
                    this.errorProvider1.SetError(this.udteVerordnetAb, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Verordnet ab: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                //if (this.udteVerordnetBis.Value == null)
                //{
                //    this.errorProvider1.SetError(this.udteVerordnetBis, "Error");
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Verordnet bis: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                //    return false;
                //}

                if (this.cboLieferant.Value != null)
                {
                    if (this.cboLieferant.Value.GetType() != typeof(Guid))
                    {
                        this.errorProvider1.SetError(this.cboLieferant, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lieferant: Falsche Eingabe!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                if (this.cboTyp.Value == null)
                {
                    this.errorProvider1.SetError(this.cboTyp, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    if (this.cboTyp.Value.GetType() != typeof(Guid))
                    {
                        this.errorProvider1.SetError(this.cboTyp, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.validateData: " + ex.ToString());
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

                this._rVo.DatumVerordnetAb = this.udteVerordnetAb.DateTime.Date;
                if (this.udteVerordnetBis.Value != null)
                {
                    this._rVo.DatumVerordnetBis = this.udteVerordnetBis.DateTime.Date;
                }
                else
                {
                    this._rVo.DatumVerordnetBis = null;
                }
                
                this._rVo.Typ = (Guid)this.cboTyp.Value;
                this._rVo.Menge = (double)this.numMenge.Value;
                this._rVo.Einheit = this.cboEinheit.Text.Trim();
                this._rVo.BestaetigtVon = this.txtBestätigtVon.Text.Trim();
                this._rVo.Hinweis = this.txtHinweis.Text.Trim();

                if (this.cboLieferant.Value != null)
                {
                    this._rVo.Lieferant = (Guid)this.cboLieferant.Value;
                }
                else
                {
                    this._rVo.Lieferant = null;
                }
                this._rVo.HinweisLieferant = this.txtHinweisLieferant.Text.Trim();
                this._rVo.Anmerkung = this.txtAnmerkung.Text.Trim();

                if (this._IsNew && this._WithPatientSelektor)
                {
                    List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();
                    if (lstPatients.Count != 1)
                    {
                        throw new Exception("ucVOErfassenDetail.saveData: lstPatients.Count != 1 not allowed!");
                    }
                    Guid IDPatientTmp = lstPatients[0];
                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(IDPatientTmp,false, this._db);
                    this._rVo.IDAufenthalt = rAufenthalt.ID;
                }
                this._db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.saveData: " + ex.ToString());
            }
        }

        public void searchMedikament()
        {
            try
            {
                PMDS.GUI.Medikament.frmSearchMedikamente frm = new Medikament.frmSearchMedikamente();
                frm.initControl();
                frm.ShowDialog(this);
                if (!frm.contSearchMedikamente1.abort)
                {
                    this._rVo.IDMedikament = frm.contSearchMedikamente1.rSelMedikament.ID;
                    this.txtMedikament .Tag = frm.contSearchMedikamente1.rSelMedikament.ID;
                    this.txtMedikament.Text = frm.contSearchMedikamente1.rSelMedikament.Bezeichnung.Trim();
                    this.cboEinheit.Text = frm.contSearchMedikamente1.rSelMedikament.Packungseinheit;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassenDetail.searchMedikament: " + ex.ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == this._rVo.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                    string sBisTmp = "";
                    if (this._rVo.DatumVerordnetBis != null)
                    {
                        sBisTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis") + ":" + this._rVo.DatumVerordnetBis.Value.ToString("dd.MM.yyyy") + "\r\n";
                    }
                    string TxtDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung") + ":" + rMedikament.Bezeichnung.Trim() + "\r\n" +
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Ab") + ":" + this._rVo.DatumVerordnetAb.ToString("dd.MM.yyyy") + "\r\n" + sBisTmp;

                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAufenthalt(this._rVo.IDAufenthalt, this._db);
                    this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung"), TxtDekurs, false, rAufenthalt.IDPatient.Value, PflegeEintragTyp.Verordnungen, rAufenthalt.ID);

                    this.abort = false;
                    if (this.mainWindow != null)
                    {
                        this.mainWindow.Close();
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

        private void btnSearchMedikmanete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchMedikament();

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

        private void cboTyp_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("VOT");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("VOT", this.cboTyp, null, this.cboTyp.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("VOT", this.cboTyp, null);
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

        private void cboEinheitBestellung_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                //{
                    frmAuswahl frm = new frmAuswahl("MEH");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheit, null, this.cboEinheit.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("MEH", this.cboEinheit, null);
                //}

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

        private void cboLieferant_EditorButtonClick(object sender, EditorButtonEventArgs e)
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

    }
}
