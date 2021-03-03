using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using Infragistics.Win.UltraWinToolTip;
using PMDS.DB;
using PMDS.GUI.BaseControls;
using PMDS.GUI.Klient;
using System.Drawing.Imaging;
using System.Security.Permissions;
using System.Security;
using System.Linq;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI
{

    public partial class ucKlientStammdaten : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {

        private bool _valueChangeEnabled = true;
        private KlientDetails _klient;
        private string _imageName = "";
        public event EventHandler ValueChanged;
        public event EventHandler VersDatenChanged;
        //Neu nach 27.04.2007 MDA
        private bool _readOnly = false;


        public bool _mainSystem = false;
        public bool _isAbrechnung = false;
        public bool _isBewerberJN = false;

        private bool _lockValueChanges = false;

        //public ucAbrechAufenthKlient ucAbrechnung1xy;
        public ucKlient MainWindow = null;

        public string InfoPatientenverfügung = "";

        public static System.Collections.Generic.List<cKontakteChanged> lstKontakteChanged = new List<cKontakteChanged>();
        public class cKontakteChanged
        {
            public Guid IDPatient = System.Guid.Empty;
            public string title = "";
            public string txt = "";
        }

        PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        public bool datRezGebBefAbChanged = false;
        public bool KlientUIEventsLocked = true;
        public StringBuilder sbChanges = new StringBuilder();

        public System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl> lstÄrzteMehrfachauswahl = new List<PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl>();

        public PMDS.GUI.Klient.ucKlientStammdatenDokumente ucKlientStammdatenDokumente1 = null;


        private Image _Image = null;
        private Bitmap _Bitmap = null;

        public bool AufenthaltIsInitialized = false;
        public PMDS.Global.db.ERSystem.ELGABusiness bELGA = new Global.db.ERSystem.ELGABusiness();

        private string _DNRAnmerkung = "";



        public ucKlientStammdaten()
        {
            InitializeComponent();
        }


        public void initControl (bool mainSystem, bool isBewerberJN , bool isAbrechnung)
        {
            if (!AufenthaltIsInitialized)
            {
                this.ucAbrechAufenthKlient1 = new ucAbrechAufenthKlient();
                this.ucAbrechAufenthKlient1.Dock = DockStyle.Fill;
                this.ucAbrechAufenthKlient1.ValueChanged += new System.EventHandler(this.ValueChanged);
                this.panelAufenthalt.Controls.Add(this.ucAbrechAufenthKlient1);
          

                this.ucBewerbungsdaten1 = new ucBewerbungsdaten();
                this.ucBewerbungsdaten1.Dock = DockStyle.Fill;
                this.ucBewerbungsdaten1.ValueChanged += new System.EventHandler(this.ValueChanged);
                this.panelBewerbungdsdaten.Controls.Add(this.ucBewerbungsdaten1);

                AufenthaltIsInitialized = true;
            }


            this.ucAbrechAufenthKlient1.MainWindow = this;

            this._isAbrechnung = isAbrechnung;
            this._isBewerberJN = isBewerberJN;
            this._mainSystem = mainSystem;
            this.initAufenthalt();

            this.btnUpdateArzt.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);
            this.btnUpdateSachw.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);
            this.btnOpenPicture.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);

            this.cboSprachenMulti.initControl("SPA");
            this.cboSprachenMulti.loadData();
            this.chkDatenschutz.CheckedChanged += new System.EventHandler(this.OnValueChanged);

            this.initKlientenstammdatenDokumente();
            this.ucVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten, true, false, null);

            this.tabStammdaten.Tabs["VOErfassen"].Visible = PMDS.Global.ENV.lic_VO;

            bELGA.init();
            this.setTabELGAOnIff();
            this.contELGAKlient1.initControl(false);
        }

        public void setTabELGAOnIff(bool bAbgemeldet = false)
        {
            if (bAbgemeldet || !ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAAktionen, false))
            {
                this.tabStammdaten.Tabs["ELGA"].Visible = false;
            }
            else
            {
                this.tabStammdaten.Tabs["ELGA"].Visible = !this._isBewerberJN &&
                                                            !this._isAbrechnung &&
                                                            ENV.lic_ELGA && 
                                                            this._mainSystem &&
                                                            ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAAktionen, false);
            }
        }

        public void initKlientenstammdatenDokumente()
        {
            try
            {
                this.ucKlientStammdatenDokumente1 = new PMDS.GUI.Klient.ucKlientStammdatenDokumente();
                this.ucKlientStammdatenDokumente1.Dock = DockStyle.Fill;
                this.panelDokumente.Controls.Add(this.ucKlientStammdatenDokumente1);

            }
            catch (Exception ex)
            {
                throw new Exception("initKlientenstammdatenDokumente: " + ex.ToString());
            }
        }

        private void initAufenthalt()
        {
            if (this._mainSystem || this._isBewerberJN)
            {
                this.ucAbrechAufenthKlient1.initControl(false, this._mainSystem, this._isBewerberJN);

            }
            else
                this.tabStammdaten.Tabs["Aufenthalt"].Visible = false;

            if (this._isAbrechnung || this._isBewerberJN)
            {

                this.panelAufenthaltsdaten2.Visible = false;
                this.txtGewicht.Visible = false;
                this.lblGewicht.Visible = false;
                this.txtBesonderheit2.Visible = false;
                this.lblBesonderheit.Visible = false;
            }
            else
            {
                this.txtBesonderheit2.Visible = ENV.HasRight(UserRights.Dienstübergabe);
                this.lblBesonderheit.Visible = ENV.HasRight(UserRights.Dienstübergabe);
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if(_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                //this.initAufenthalt();

                this.KlientUIEventsLocked = true;
                if (_isAbrechnung) this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn );
                _valueChangeEnabled = false;
                _klient = value;
                ucKontaktPersonen1.Klient = value;
                ucBewerbungsdaten1.Klient = value;

                if (ucAbrechAufenthKlient1 != null) ucAbrechAufenthKlient1.Klient = value;
                
                InitFields();
                UpdateGUI();
                HideOrShowControls();
                _valueChangeEnabled = true;
                this.KlientUIEventsLocked = false;
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            if (ucAbrechAufenthKlient1 != null) this.ucAbrechAufenthKlient1.setControlsAktivDisable2(bOn);
           
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxOben, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAllgemein1, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxPersonebescheibung, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAdressdaten, bOn);

            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAngehörige, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxÄrtze, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxSachverwalter, bOn);

            //PMDS.GUI.BaseControls.historie.OnOffControls(this , bOn);
            this.ucBewerbungsdaten1 .setControlsAktivDisable(bOn);


            //if (this.MainWindow != null)
            //{
            //    if (this.MainWindow.bewerberbeuanlage)
            //    {
            //        this.btnOpenPicture.Visible = false;
            //    }
            //    else
            //    {
            //        this.btnOpenPicture.Visible = !bOn;
            //    }
            //}
            //else
            //{
            //    this.btnOpenPicture.Visible = !bOn;
            //}

            this.ucKontaktPersonen1.panelButtonsKP2.Visible = true;
            this.panelButtons1.Visible = true;
            this.panelButtons2.Visible = true;


            this.btnUpdateAerzte.Visible = !bOn;
            this.btnDelAerzte.Visible = !bOn;
            this.btnUpdateArzt.Visible = !bOn;

            this.btnAddSachw.Visible = !bOn;
            this.btnDelSachwalter.Visible = !bOn;
            this.btnUpdateSachw.Visible = !bOn;

            this.ucKontaktPersonen1.btnAddKP.Visible = !bOn;
            this.ucKontaktPersonen1.btnDelKP.Visible = !bOn;
            this.ucKontaktPersonen1.btnUpdateKP.Visible = !bOn;

            if (PMDS.Global.historie.HistorieOn)
            {
                this.btnUpdateArzt.Visible = true;
                this.btnUpdateSachw.Visible = true;
                this.ucKontaktPersonen1.btnUpdateKP.Visible = true;
            }

        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Name des Bilds setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImageName
        {
            get
            {
                return _imageName;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name");

                _imageName = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        public void resetColor()
        {
            GuiUtil.resetColor2(cmbSexus);
            GuiUtil.resetColor2(cmbAnrede);
            GuiUtil.resetColor2(cmbAkdGrad);
            GuiUtil.resetColor2(cmbFAM);
            GuiUtil.resetColor2(cmbStaatsB);
            GuiUtil.resetColor2(cmbKonfession);
            GuiUtil.resetColor2(cmbAugenFarbe);
            GuiUtil.resetColor2(cmbHaarFarbe);
            GuiUtil.resetColor2(cmbstatur);
            GuiUtil.resetColor2(txtLand);
            GuiUtil.resetColor2(txtLandNWS);
            GuiUtil.resetColor2(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboEinrichtungen);
            GuiUtil.resetColor2(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cmbKlasse);

            GuiUtil.resetColor2(txtNachname);
            GuiUtil.resetColor2(txtVorname);
            GuiUtil.resetColor2(cmbSexus);
            GuiUtil.resetColor2(gebDatum);
            GuiUtil.resetColor2(cmbBenutzer);
            GuiUtil.resetColor2(txtFallzahl);
            GuiUtil.resetColor2(txtGroesse);
            GuiUtil.resetColor2(txtGewicht);
            GuiUtil.resetColor2(intAmputation_Prozent);

            GuiUtil.resetColor2(datRezGebBef_RegoAb);
            GuiUtil.resetColor2(datRezGebBef_RegoBis);
            GuiUtil.resetColor2(datRezGebBef_BefristetAb);
            GuiUtil.resetColor2(datRezGebBef_BefristetBis);
            GuiUtil.resetColor2(cboRezGebBef_WiderrufGrund);
        }

        public void UpdateGUI()
        {
            this._lockValueChanges = true;
            this.datRezGebBefAbChanged = false;
            this.sbChanges = new StringBuilder();

            this.lstÄrzteMehrfachauswahl = new List<PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl>();
            this.resetColor();

            //----------------------------------------------------
            //              Persönliche Daten
            //----------------------------------------------------
            txtNachname.Text = Klient.Nachname;
            txtVorname.Text = Klient.Vorname;
            cmbAkdGrad.Text = Klient.Titel;
            cmbAnrede.Text = Klient.Anrede;
            txtFallzahl.Text = (Klient.Aufenthalt != null) ? Klient.Aufenthalt.Fallnummer.ToString() : "";
            txtgruppenkennzahl.Text = (Klient.Aufenthalt != null) ? Klient.Aufenthalt.Gruppenkennzahl : "";
            txtKliNr.Text = Klient.Klientennummer;

            if (Klient.AufenthaltZusatz.Count > 0)
                txtZimmerNr.Text = Klient.AufenthaltZusatz[0].Zimmernummer.Trim();
            gebDatum.Value = Klient.Geburtsdatum;
            txtGebName.Text = Klient.LedigerName;
            cmbSexus.Text = Klient.Sexus;
            txtGebOrt.Text = Klient.Geburtsort;
            cmbFAM.Text = Klient.Familienstand;
            cmbStaatsB.Text = Klient.Staatsb;
            cmbKonfession.Text = Klient.Konfision;
            txtBeruf.Text = Klient.ErlernterBeruf;
            
            //Personenbeschreibung
            txtGroesse.Text = Klient.Groesse != 0 ? Klient.Groesse.ToString() : "";
            txtGewicht.Text = (Klient.Aufenthalt != null && Klient.Aufenthalt.Gewicht != 0) ? Klient.Aufenthalt.Gewicht.ToString() : "";
            cmbAugenFarbe.Text = Klient.Augenfarbe;
            cmbHaarFarbe.Text = Klient.Haarfarbe;
            
            cmbstatur.Text = Klient.Statur;
            Namenstag.Value = Klient.Namenstag;
            txtKosename.Text = Klient.Kosename;
            txtBesKennz.Text = Klient.BesondereAeusserlicheKennzeichen;
            txtInitialBer.Text = Klient.Initialberuehrung;
            txtKennwort.Text = Klient.Kennwort;
            this.chkVerstorben.Checked = Klient.Verstorben;
            this.dteTodeszeitpunkt.Value = Klient.Todeszeitpunkt;
            this.chkDNR.Checked = Klient.DNR;

           
            //----------------------------------------------------
            //              Adressdaten
            //----------------------------------------------------
            InitBenutzer();

            txtStrasse.Text = Klient.Adresse.Strasse;
            txtPLZ.Text = Klient.Adresse.Plz;
            txtOrt.Text = Klient.Adresse.Ort;
            txtLand.Text = Klient.Adresse.LandKZ;
            WohnungAb.Checked = Klient.WohnungAbgemeldetJN;
            lift.Checked = Klient.LiftJN;
            txtTelefon.Text = Klient.Kontakt.Tel;
            txtMobil.Text = Klient.Kontakt.Mobil;
            txtFax.Text = Klient.Kontakt.Fax;
            txtEmail.Text = Klient.Kontakt.Email;
            txtWohnsituation.Text = Klient.Wohnsituation;
            txtZustgStelle.Text = Klient.Zustaendigestelle;
            txtKlingeln.Text = Klient.Klingeln;
            txtHaustier.Text = Klient.Haustier;
            this.chkMilieubetreuung.Checked = Klient.Milieubetreuung;
            this.chkKZUeberlebender.Checked = Klient.KZUeberlebender;
            this.chkAnatomie.Checked = Klient.Anatomie;
            this.txtBesonderheit2.Text = Klient.Besonderheit.Trim();

            lbleMailKlient.Text = Klient.Kontakt.Email;
            lblMobilTelNrKlient.Text = Klient.Kontakt.Mobil;

            //lthPatientAdresseSub
            this.txtStrasseNWS.Text = "";
            this.txtPLZNWS.Text = "";
            this.txtOrtNWS.Text = "";
            this.txtLandNWS.Text = "";
            this.txtLandNWS.Value = null;

            this.txtTelefonNWS.Text = "";
            this.txtMobilNWS.Text = "";
            this.txtFaxNWS.Text = "";
            this.txtEmailNWS.Text = "";

            if (Klient.IDAdresseSub != null)
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdresse = this.b.getAdresse(Klient.IDAdresseSub.Value, db);

                    this.txtStrasseNWS.Text = rAdresse.Strasse.Trim();
                    this.txtPLZNWS.Text = rAdresse.Plz.Trim();
                    this.txtOrtNWS.Text = rAdresse.Ort.Trim();
                    this.txtLandNWS.Text = rAdresse.LandKZ.Trim();
                }
            }
            if (Klient.IDKontaktSub != null)
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Kontakt rKontakt = this.b.getKontakt(Klient.IDKontaktSub.Value, db);

                    this.txtTelefonNWS.Text = rKontakt.Tel.Trim();
                    this.txtMobilNWS.Text = rKontakt.Mobil.Trim();
                    this.txtFaxNWS.Text = rKontakt.Fax.Trim();
                    this.txtEmailNWS.Text = rKontakt.Email.Trim();
                }
            }

            this.cbRezeptGeb.Checked = Klient.RezeptGebuehrbefreiungJN;
            this.chkRezGebBef_RegoJN.Checked = false;
            this.datRezGebBef_RegoAb.Value = null;
            this.datRezGebBef_RegoBis.Value = null;
            this.datRezGebBef_BefristetBis.Value = null;
            this.chkRezGebBef_UnbefristetJN.Checked = false;
            this.chkRezGebBef_BefristetJN.Checked = false;
            this.datRezGebBef_BefristetAb.Value = null;
            this.datRezGebBef_BefristetBis.Value = null;
            this.chkRezGebBef_WiderrufJN.Checked = false;
            this.cboRezGebBef_WiderrufGrund.Text = "";
            this.cboRezGebBef_WiderrufGrund.Value = null;
            this.chkRezGebBef_SachwalterJN.Checked = false;
            this.editorRezGebBef_Anmerkung.Text = "";
            this.chkDatenschutz.Checked = false;
            this.chkDatenschutz.Visible = true;
            this.txtInfoDienstuebergabe.Text = "";
            this.txtSofortmassnahmen.Text = "";

            this.chkAbwesenheitBeendet.Checked = false;
            this.chkAbwesenheitBeendet.Visible = false;      
            this.btnAbwesenheitsendeBestätigen.Visible = false;
            this.btnAbwesenheitsendeBestätigen.Enabled =  ENV.HasRight(UserRights.AbwesenheitBeendetÄnderbar);
            this.chkPalliativ.Checked = false;
            this.intAmputation_Prozent.Value = 0;

            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text = "";
            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Value = null;
            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Text = "";
            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Value = null;
            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtSozVersMitversichertBei.Text = "";

            this.cboTitelPost.Text = "";
            this.txtbPK.Text = "";
            this.txtDNRAnmerkung.Text = "";
            this._DNRAnmerkung = "";
            this.chkELGAAbgemeldet.Checked = false;

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                if (this.b.checkPatientExists(Klient.ID, db))
                {
                    //os191224
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == Klient.ID
                                    select new
                                    { p.Nachname, p.Vorname,
                                        p.lstSprachen,
                                        p.RezGebBef_RegoJN,
                                        p.RezGebBef_RegoAb,
                                        p.RezGebBef_RegoBis,
                                        p.RezGebBef_UnbefristetJN,
                                        p.RezGebBef_BefristetJN,
                                        p.RezGebBef_BefristetAb,
                                        p.RezGebBef_BefristetBis,
                                        p.RezGebBef_WiderrufJN,
                                        p.RezGebBef_WiderrufGrund,
                                        p.RezGebBef_SachwalterJN,
                                        p.RezGebBef_Anmerkung,
                                        p.DNR,
                                        p.DNRAnmerkung,
                                        p.Palliativ,
                                        p.Datenschutz,
                                        p.Amputation_Prozent,
                                        p.SozVersStatus,
                                        p.SozVersMitversichertBei,
                                        p.SozVersLeerGrund,
                                        p.TitelPost,
                                        p.ELGAAbgemeldet,                                        
                                        p.bPK
                                    }
                                   ).First();

                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(Klient.ID, db);
                    this.cboSprachenMulti.setSelectedRows(rPatInfo.lstSprachen.Trim());
                    
                    this.chkRezGebBef_RegoJN.Checked = rPatInfo.RezGebBef_RegoJN;
                    if (rPatInfo.RezGebBef_RegoAb != null)
                    {
                        this.datRezGebBef_RegoAb.Value = rPatInfo.RezGebBef_RegoAb.Value;
                    }
                    if (rPatInfo.RezGebBef_RegoBis != null)
                    {
                        this.datRezGebBef_RegoBis.Value = rPatInfo.RezGebBef_RegoBis.Value;
                    }
                    this.chkRezGebBef_UnbefristetJN.Checked = rPatInfo.RezGebBef_UnbefristetJN;
                    this.chkRezGebBef_BefristetJN.Checked = rPatInfo.RezGebBef_BefristetJN;
                    if (rPatInfo.RezGebBef_BefristetAb != null)
                    {
                        this.datRezGebBef_BefristetAb.Value = rPatInfo.RezGebBef_BefristetAb.Value;
                    }
                    if (rPatInfo.RezGebBef_BefristetBis != null)
                    {
                        this.datRezGebBef_BefristetBis.Value = rPatInfo.RezGebBef_BefristetBis.Value;
                    }
                    this.chkRezGebBef_WiderrufJN.Checked = rPatInfo.RezGebBef_WiderrufJN;
                    this.cboRezGebBef_WiderrufGrund.Text = rPatInfo.RezGebBef_WiderrufGrund;
                    this.chkRezGebBef_SachwalterJN.Checked = rPatInfo.RezGebBef_SachwalterJN;
                    this.editorRezGebBef_Anmerkung.Text = rPatInfo.RezGebBef_Anmerkung;
                    this.chkDatenschutz.Checked = rPatInfo.Datenschutz;
                    this.chkPalliativ.Checked = rPatInfo.Palliativ;
                    this.intAmputation_Prozent.Value = rPatInfo.Amputation_Prozent;

                    this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text = rPatInfo.SozVersStatus;
                    this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Text = rPatInfo.SozVersLeerGrund;
                    this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtSozVersMitversichertBei.Text = rPatInfo.SozVersMitversichertBei;

                    this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.setUIVersNr(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtVersNr.Text.Trim());
                    this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.setUIMitversichertBei(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text.Trim());

                    this.cboTitelPost.Text = rPatInfo.TitelPost;
                    this.txtbPK.Text = rPatInfo.bPK;
                    this.txtDNRAnmerkung.Text = rPatInfo.DNRAnmerkung;
                    this._DNRAnmerkung = rPatInfo.DNRAnmerkung;
                    if (rPatInfo.ELGAAbgemeldet != null)
                    {
                        this.chkELGAAbgemeldet.Checked = rPatInfo.ELGAAbgemeldet.Value;
                        this.setTabELGAOnIff();
                    } 
                    else
                    {
                        this.setTabELGAOnIff();
                    }

                }

                if (b.checkAufenthaltExists(Klient.Aufenthalt.ID, db))
                {
                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAufenthalt(Klient.Aufenthalt.ID, db);
                    this.chkAbwesenheitBeendet.Checked = rAufenthalt.AbwesenheitBeendet;
                    this.txtInfoDienstuebergabe.Text = rAufenthalt.InfoDienstuebergabe;

                    bool PatHasNoAktAufenthalt = false;
                    PMDS.db.Entities.UrlaubVerlauf rUrlaubVerlaufLast = null;
                    if (!this.b.PatientIstAbwesend(this.Klient.ID, db, ref PatHasNoAktAufenthalt, ref rUrlaubVerlaufLast))
                    {
                        if (rAufenthalt.AbwesenheitBeendet)
                        {
                            this.btnAbwesenheitsendeBestätigen.Visible = true;
                        }
                    }

                    this.txtSofortmassnahmen.Text = rAufenthalt.SofortMassnahmen.Trim();
                }

            }
          
            //----------------------------------------------------
            //              Ärzte
            //----------------------------------------------------
            //this.gridAerzte.DataSource = Klient.KLIENT_AERZTE;
            this.gridAerzte.DataSource = Klient.CLASS_AERZTE.PATIENTAERZTE;
            KlientGuiAction.RefreshListPatientAerzte(gridAerzte, Klient);
            //----------------------------------------------------
            //              Sachwalter
            //----------------------------------------------------
            
            this.UpdateGridSachwalter();
            this.loadPatientenverfügung();
            this._lockValueChanges = false;

            this.panelVerstorben.Visible = PMDS.Global.historie.HistorieOn;

            this.ucVOErfassen1.search2(this.Klient.Aufenthalt.ID, null, null, null);
            if (!this._isBewerberJN && !this._isAbrechnung && PMDS.Global.ENV.lic_ELGA && this._mainSystem)
            {
                this.contELGAKlient1.loadData(Klient.ID, Klient.IDAuenthalt);
            }

        }
        public void UpdateGridSachwalter()
        {
            this.gridSachwalter.DataSource = Klient.KLIENT_SACHWALTER;
            this.gridSachwalter.UpdateData();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridSachwalter in this.gridSachwalter.Rows)
            {
                DataRowView v = (DataRowView)rGridSachwalter.ListObject;
                dsKlientSachwalter.SachwalterRow rSachwalter = (dsKlientSachwalter.SachwalterRow)v.Row;
                Sachwalter Sachwalter = new Sachwalter(rSachwalter.ID);
                rGridSachwalter.Cells["TelAdresse"].Value = Sachwalter.Kontakt.Tel + " / " + Sachwalter.Adresse.Ort + " " + Sachwalter.Adresse.Plz + " " + Sachwalter.Adresse.Strasse;
                rGridSachwalter.Cells["EMail"].Value = Sachwalter.Kontakt.Email.Trim();
            }
            this.gridSachwalter.Refresh();

            this._lockValueChanges = false;
        }

        public void loadPatientenverfügung()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //os191224
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == this.Klient.ID
                                    select new
                                    { p.Nachname, p.Vorname,
                                        p.PatientenverfuegungJN,
                                        p.PatientverfuegungDatum,
                                        p.PatientenverfuegungBeachtlichJN,
                                        p.PatientverfuegungAnmerkung
                                    }
                                   );
                    //PMDSBusiness b = new PMDSBusiness();
                    //PMDS.db.Entities.Patient rPatient = null;
                    //if (this._isBewerberJN)
                    //{
                    //    rPatient = b.getPatient2(this.Klient.ID, db);
                    //}
                    //else
                    //{
                    //    rPatient = b.getPatient(this.Klient.ID, db);
                    //}

                    if (rPatInfo.Count() == 1)
                    {
                        if (rPatInfo.First().PatientenverfuegungJN != null && rPatInfo.First().PatientenverfuegungJN.Value == true)
                        {
                            this.InfoPatientenverfügung = "";
                            if (rPatInfo.First().PatientverfuegungDatum != null)
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum") + ":" + rPatInfo.First().PatientverfuegungDatum.Value.ToString("dd.MM.yyyy");
                            }

                            if (rPatInfo.First().PatientenverfuegungBeachtlichJN != null && rPatInfo.First().PatientenverfuegungBeachtlichJN.Value == true)
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Beachtlich");
                            }
                            else
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verbindlich");
                            }

                            if (rPatInfo.First().PatientverfuegungAnmerkung != null && rPatInfo.First().PatientverfuegungAnmerkung.Trim() != "")
                            {
                                this.InfoPatientenverfügung += "\r\n" + "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anmerkung") + ":" + "\r\n" + rPatInfo.First().PatientverfuegungAnmerkung.Trim();
                            }

                            this.lblPatientenverfügung.Visible = true;
                        }
                        else
                        {
                            this.InfoPatientenverfügung = "";
                            this.lblPatientenverfügung.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadPatientenverfügung: " + ex.ToString());
            }
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {

            string sJa = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
            string sNein = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");
            sbChanges.Clear();
            //----------------------------------------------------
            //              Persönliche Daten
            //----------------------------------------------------
            if (txtNachname.Text.Trim() != Klient.Nachname)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ") + Klient.Nachname + " -> " + txtNachname.Text.Trim());
            }
            Klient.Nachname = txtNachname.Text.Trim();

            if (txtVorname.Text.Trim() != Klient.Vorname)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ") + Klient.Vorname + " -> " + txtVorname.Text.Trim());
            }
            Klient.Vorname = txtVorname.Text.Trim();

            if (cmbAkdGrad.Text.Trim() != Klient.Titel)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ") + Klient.Titel + " -> " + cmbAkdGrad.Text.Trim());
            }
            Klient.Titel = cmbAkdGrad.Text.Trim();

            if (Klient.Aufenthalt != null)
            {
                if(Klient.Aufenthalt.Fallnummer.ToString() != txtFallzahl.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Fallnummer: ") + Klient.Aufenthalt.Fallnummer.ToString() + " -> " + txtFallzahl.Text.Trim());
                }
                Klient.Aufenthalt.Fallnummer = Convert.ToDouble(txtFallzahl.Text.Trim());
            }

            if (Klient.Aufenthalt != null)
            {
                if (Klient.Aufenthalt.Gruppenkennzahl != txtgruppenkennzahl.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Gruppenkennzahl: ") + Klient.Aufenthalt.Gruppenkennzahl + " -> " + txtgruppenkennzahl.Text.Trim());
                }
                Klient.Aufenthalt.Gruppenkennzahl = txtgruppenkennzahl.Text.Trim();
            }

            if (Klient.Klientennummer != txtKliNr.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientennummer: ") + Klient.Klientennummer + " -> " + txtKliNr.Text.Trim());
            }
            Klient.Klientennummer = txtKliNr.Text.Trim();

            if (Klient.AufenthaltZusatz.Count > 0)
            {
                if (Klient.AufenthaltZusatz[0].Zimmernummer != txtZimmerNr.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zimmernummer: ") + Klient.AufenthaltZusatz[0].Zimmernummer + " -> " + txtZimmerNr.Text.Trim());
                }
                Klient.AufenthaltZusatz[0].Zimmernummer = txtZimmerNr.Text.Trim();
            }

            if (Klient.Geburtsdatum != gebDatum.Value)
            {
                string strGeburtsdatum = "";
                if (Klient.Geburtsdatum != null)
                    strGeburtsdatum = ((DateTime)Klient.Geburtsdatum).ToString("dd.MM.yyyy");

                string strGeburtsdatumNeu = "";
                if (gebDatum.Value != null)
                    strGeburtsdatumNeu = ((DateTime)gebDatum.Value).ToString("dd.MM.yyyy");
                if (strGeburtsdatum != strGeburtsdatumNeu)
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsdatum: ") + strGeburtsdatum + " -> " + strGeburtsdatumNeu);
                }
                Klient.Geburtsdatum = gebDatum.Value;
            }

            if (Klient.LedigerName != txtGebName.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsname: ") + Klient.LedigerName + " -> " + txtGebName.Text.Trim());
            }
            Klient.LedigerName = txtGebName.Text.Trim();

            if (Klient.Sexus != cmbSexus.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geschlecht: ") + Klient.Sexus + " -> " + cmbSexus.Text.Trim());
            }
            Klient.Sexus = cmbSexus.Text.Trim();

            if (Klient.Geburtsort != txtGebOrt.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsort: ") + Klient.Geburtsort + " -> " + txtGebOrt.Text.Trim());
            }
            Klient.Geburtsort = txtGebOrt.Text.Trim();

            if (Klient.Familienstand != cmbFAM.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Familienstand: ") + Klient.Familienstand + " -> " + cmbFAM.Text.Trim());
            }
            Klient.Familienstand = cmbFAM.Text.Trim();

            if (Klient.Staatsb != cmbStaatsB.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsbürgerschaft: ") + Klient.Staatsb + " -> " + cmbStaatsB.Text.Trim());
            }
            Klient.Staatsb = cmbStaatsB.Text.Trim();

            if (Klient.Konfision != cmbKonfession.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfession: ") + Klient.Konfision + " -> " + cmbKonfession.Text.Trim());
            }
            Klient.Konfision = cmbKonfession.Text.Trim();

            if (Klient.ErlernterBeruf != txtBeruf.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlernter Beruf: ") + Klient.ErlernterBeruf + " -> " + txtBeruf.Text.Trim());
            }
            Klient.ErlernterBeruf = txtBeruf.Text.Trim();

            if (Klient.Verstorben != chkVerstorben.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verstorben: ") + (Klient.Verstorben ? sJa : sNein) + " -> " + (chkVerstorben.Checked ? sJa : sNein));
            }
            Klient.Verstorben = chkVerstorben.Checked;

            Klient.RezeptGebuehrbefreiungJN = cbRezeptGeb.Checked;

            if (Klient.Todeszeitpunkt == System.Convert.DBNull)
            {

            }

            if (Klient.Todeszeitpunkt != dteTodeszeitpunkt.Value)
            {
                string strTodeszeitpunkt = "";
                if (Klient.Todeszeitpunkt != null)
                    strTodeszeitpunkt = ((DateTime)Klient.Todeszeitpunkt).ToString("dd.MM.yyyy");

                string strTodeszeitpunktNeu = "";
                if (dteTodeszeitpunkt.Value != null)
                    strTodeszeitpunktNeu = ((DateTime)dteTodeszeitpunkt.Value).ToString("dd.MM.yyyy");
                if (strTodeszeitpunkt != strTodeszeitpunktNeu)
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Todeszeitpunkt: ") + strTodeszeitpunkt + " -> " + strTodeszeitpunktNeu);
                }
                Klient.Todeszeitpunkt = dteTodeszeitpunkt.Value;
            }

            if (Klient.DNR != chkDNR.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR: ") + (Klient.DNR ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja"): QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein")) + " -> " + (chkDNR.Checked ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein")));
            }
            Klient.DNR = chkDNR.Checked;

            //Personenbeschreibung
            if (!String.IsNullOrWhiteSpace(txtGroesse.Text.Trim()))
            {
                if (Klient.Groesse != Convert.ToInt32(txtGroesse.Text.Trim()))
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Größe: ") + Klient.Groesse.ToString() + " -> " + txtGroesse.Text.Trim());
                }
                Klient.Groesse = Convert.ToInt32(txtGroesse.Text.Trim());
            }

            if (!String.IsNullOrWhiteSpace(txtGewicht.Text.Trim()) && Klient.Aufenthalt != null)
            {
                if (Klient.Aufenthalt.Gewicht != Convert.ToDouble(txtGewicht.Text.Trim()))
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Gewicht: ") + Klient.Aufenthalt.Gewicht.ToString() + " -> " + txtGewicht.Text.Trim());
                }
                Klient.Aufenthalt.Gewicht = Convert.ToDouble(txtGewicht.Text.Trim());
            }

            if (Klient.Augenfarbe != cmbAugenFarbe.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Augenfarbe: ") + Klient.Augenfarbe + " -> " + cmbAugenFarbe.Text.Trim());
            }
            Klient.Augenfarbe = cmbAugenFarbe.Text.Trim();

            if (Klient.Haarfarbe != cmbHaarFarbe.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Haarfarbe: ") + Klient.Haarfarbe + " -> " + cmbHaarFarbe.Text.Trim());
            }
            Klient.Haarfarbe = cmbHaarFarbe.Text.Trim();

            //Klient.Foto2 = SetFoto();

            if (Klient.Statur != cmbstatur.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Statur: ") + Klient.Statur + " -> " + cmbstatur.Text.Trim());
            }
            Klient.Statur = cmbstatur.Text.Trim();

            if (Klient.Namenstag != Namenstag.Value)
            {
                string strNamenstag = "";
                if (Klient.Namenstag != null)
                    strNamenstag = ((DateTime)Klient.Namenstag).ToString("dd.MM.");

                string strNamenstagNeu = "";
                if (Namenstag.Value != null)
                    strNamenstagNeu = ((DateTime)Namenstag.Value).ToString("dd.MM.");
                if (strNamenstag != strNamenstagNeu)
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Namenstag: ") + strNamenstag + " -> " + strNamenstagNeu);
                }
                Klient.Namenstag = Namenstag.Value;
            }

            if (Klient.Kosename != txtKosename.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kosename: ") + Klient.Kosename + " -> " + txtKosename.Text.Trim());
            }
            Klient.Kosename = txtKosename.Text.Trim();

            if (Klient.BesondereAeusserlicheKennzeichen != txtBesKennz.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Bes. Kennzeichen: ") + Klient.BesondereAeusserlicheKennzeichen + " -> " + txtBesKennz.Text.Trim());
            }
            Klient.BesondereAeusserlicheKennzeichen = txtBesKennz.Text.Trim();

            if (Klient.Initialberuehrung != txtInitialBer.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Initialberührung: ") + Klient.Initialberuehrung + " -> " + txtInitialBer.Text.Trim());
            }
            Klient.Initialberuehrung = txtInitialBer.Text.Trim();

            if (Klient.Kennwort != txtKennwort.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kennwort: ") + Klient.Kennwort + " -> " + txtKennwort.Text.Trim());
            }
            Klient.Kennwort = txtKennwort.Text.Trim();

            if (Klient.Milieubetreuung != chkMilieubetreuung.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Milieubetreuung: ") + (Klient.Milieubetreuung ? sJa : sNein) + " -> " + (chkMilieubetreuung.Checked ? sJa : sNein));
            }
            Klient.Milieubetreuung = chkMilieubetreuung.Checked;

            if (Klient.KZUeberlebender != chkKZUeberlebender.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("KZ-Überlebender: ") + (Klient.KZUeberlebender ? sJa : sNein) + " -> " + (chkKZUeberlebender.Checked ? sJa : sNein));
            }
            Klient.KZUeberlebender = chkKZUeberlebender.Checked;

            if (Klient.Anatomie != chkAnatomie.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anatomie: ") + (Klient.Anatomie ? sJa : sNein) + " -> " + (chkAnatomie.Checked ? sJa :sNein));
            }
            Klient.Anatomie = chkAnatomie.Checked;

            if (Klient.Besonderheit != txtBesonderheit2.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen zur Übergabe wurden geändert."));
                //sbChanges.Append("\r\n" + "Besonderheit: " + txtBesonderheit2.Text.Trim());
            }
            Klient.Besonderheit = this.txtBesonderheit2.Text.Trim();

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                if (this.b.checkPatientExists(Klient.ID, db))
                {
                    //os191224
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == Klient.ID
                                    select new
                                    { p.Nachname, 
                                        p.Vorname,
                                        p.SozVersLeerGrund,
                                        p.KrankenKasse,
                                        p.SozVersStatus,
                                        p.SozVersMitversichertBei,
                                        p.Privatversicherung,
                                        p.PrivPolNr,
                                        p.Klasse,
                                        p.bPK,
                                        p.ELGAAbgemeldet
                                    }
                                   ).First();
                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(Klient.ID, db);

                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtVersNr.Text != Klient.VersicherungsNr)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Nr: ") + Klient.VersicherungsNr + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtVersNr.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Text != rPatInfo.SozVersLeerGrund)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Nr leer weil : ") + rPatInfo.SozVersLeerGrund.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboEinrichtungen.Text != rPatInfo.KrankenKasse)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Krankenkasse: ") + rPatInfo.KrankenKasse.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboEinrichtungen.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text != rPatInfo.SozVersStatus)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Status: ") + rPatInfo.SozVersStatus.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtSozVersMitversichertBei.Text != rPatInfo.SozVersMitversichertBei)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Mitversichert bei: ") + rPatInfo.SozVersMitversichertBei.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtSozVersMitversichertBei.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtPrivatVers.Text != rPatInfo.Privatversicherung)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzvers.: ") + rPatInfo.Privatversicherung.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtPrivatVers.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cmbKlasse.Text != rPatInfo.Klasse)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Klasse: ") + rPatInfo.Klasse.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cmbKlasse.Text.Trim());
                    }
                    if (this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtPolzNr.Text != rPatInfo.PrivPolNr)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Pol.Nr.: ") + rPatInfo.PrivPolNr.Trim() + " -> " + this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtPolzNr.Text.Trim());
                    }
                    if (txtbPK.Text != rPatInfo.bPK)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("bPK: ") + rPatInfo.bPK + " -> " + txtbPK.Text.Trim());
                    }
                    if (chkELGAAbgemeldet.Checked != rPatInfo.ELGAAbgemeldet)
                    {
                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA abgemeldet: ") + (rPatInfo.ELGAAbgemeldet ?? false ? sJa : sNein) + " -> " + (chkELGAAbgemeldet.Checked ? sJa : sNein));
                    }
                }
            }

            //----------------------------------------------------
            //              Kontakte
            //----------------------------------------------------
            //ucKontaktPersonen1.UpdateDATA();

            //----------------------------------------------------
            //              Adress- und Bewerbungsdaten
            //----------------------------------------------------
            Klient.IDBenutzer = cmbBenutzer.Value;
            Klient.Adresse.Strasse = txtStrasse.Text.Trim();
            Klient.Adresse.Plz = txtPLZ.Text.Trim();
            Klient.Adresse.Ort = txtOrt.Text.Trim();
            Klient.Adresse.LandKZ = txtLand.Text.Trim();
            Klient.WohnungAbgemeldetJN = WohnungAb.Checked;
            Klient.LiftJN = lift.Checked;
            Klient.Kontakt.Tel = txtTelefon.Text.Trim();
            Klient.Kontakt.Mobil = txtMobil.Text.Trim();
            Klient.Kontakt.Fax = txtFax.Text.Trim();
            Klient.Kontakt.Email = txtEmail.Text.Trim();
            Klient.Wohnsituation = txtWohnsituation.Text.Trim();
            Klient.Zustaendigestelle = txtZustgStelle.Text.Trim();
            Klient.Klingeln = txtKlingeln.Text.Trim();
            Klient.Haustier = txtHaustier.Text.Trim();
            Klient.Anrede = this.cmbAnrede.Text;

            //lthPatientAdresseSub
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                if (Klient.IDAdresseSub == null)
                {
                    PMDS.db.Entities.Adresse newAdresseSub = Global.db.ERSystem.EFEntities.newAdresse(db);
                    newAdresseSub.ID = System.Guid.NewGuid();
                    Klient.IDAdresseSub = newAdresseSub.ID;
                    db.Adresse.Add(newAdresseSub);
                    db.SaveChanges();
                }

                PMDS.db.Entities.Adresse rAdresseSub = this.b.getAdresse(Klient.IDAdresseSub.Value, db);

                rAdresseSub.Strasse = this.txtStrasseNWS.Text.Trim();
                rAdresseSub.Plz = this.txtPLZNWS.Text.Trim();
                rAdresseSub.Ort = this.txtOrtNWS.Text.Trim();
                rAdresseSub.LandKZ = this.txtLandNWS.Text.Trim();

                db.SaveChanges();

                if (Klient.IDKontaktSub == null)
                {
                    PMDS.db.Entities.Kontakt newKontaktSub = Global.db.ERSystem.EFEntities.newKontakt(db);
                    newKontaktSub.ID = System.Guid.NewGuid();
                    Klient.IDKontaktSub = newKontaktSub.ID;
                    db.Kontakt.Add(newKontaktSub);
                    db.SaveChanges();
                }

                PMDS.db.Entities.Kontakt rKontaktSub = this.b.getKontakt(Klient.IDKontaktSub.Value, db);

                rKontaktSub.Tel = this.txtTelefonNWS.Text.Trim();
                rKontaktSub.Mobil = this.txtMobilNWS.Text.Trim();
                rKontaktSub.Fax = this.txtFaxNWS.Text.Trim();
                rKontaktSub.Email = this.txtEmailNWS.Text.Trim();

                //if (this.b.checkPatientExists(Klient.ID, db))
                //{
                //    PMDS.db.Entities.Patient rPatient = this.b.getPatient(Klient.ID, db);
                //    rPatient.lstSprachen = this.cboSprachenMulti.getSelectedRows();
                //}
                
                db.SaveChanges();
            }

            ucBewerbungsdaten1.UpdateDATA();

            if (ucAbrechAufenthKlient1 != null)
                ucAbrechAufenthKlient1.UpdateDATA();

            //this.loadPatientenverfügung();
        }
        public bool SaveER(ref bool writeDekursSprachenChanged, ref bool abweseneheitBeendetChanged, Guid IDAufenthaltAct, ref string txtSprachenGeändert)
        {
            try
            {

                string sJa = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
                string sNein = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (this.b.checkPatientExists(Klient.ID, db))
                    {
                        PMDS.db.Entities.Patient rPatient = this.b.getPatient(Klient.ID, db);

                        if (rPatient.Datenschutz != this.chkDatenschutz.Checked)
                        {
                            string sDatenschutzOld = (rPatient.Datenschutz == true ?  sJa : sNein);
                            string sDatenschutzNew = (this.chkDatenschutz.Checked == true ? sJa : sNein);
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenschutz: ") + sDatenschutzOld.Trim() + " -> " + sDatenschutzNew.Trim());
                        }

                        if (this.chkDatenschutz.Checked && rPatient.Foto != null)     //Datenschutz aktiviert, Foto vorhanden
                        {
                            if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datenschutz aktiviert und Foto ist bereits vorhanden.\n\rSoll das Foto gelöscht werden?", "Hinweis", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                rPatient.Foto = null;
                                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Foto wurde wegen Datenschutz gelöscht"));
                            }
                            else
                            {
                                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Foto wurde trotz Frage nicht gelöscht"));
                            }
                        }
                        if (rPatient.Palliativ != this.chkPalliativ.Checked)
                        {
                            string sPalliativOld = (rPatient.Palliativ == true ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein"));
                            string sPalliativNew = (this.chkPalliativ.Checked == true ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein"));
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Palliativ: ") + sPalliativOld.Trim() + " -> " + sPalliativNew.Trim());
                        }

                        if (rPatient.Amputation_Prozent != (int)this.intAmputation_Prozent.Value)
                        {
                            string sAmputationOld = rPatient.Amputation_Prozent.ToString();
                            string sAmputationNew = this.intAmputation_Prozent.Value.ToString();
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Amputation: ") + sAmputationOld.Trim() + " -> " + sAmputationNew.Trim());
                        }


                        if (!String.IsNullOrWhiteSpace(this.ucAbrechAufenthKlient1.cmbBetreuungsstufe.Text))
                        {
                            rPatient.Betreuungsstufe = this.ucAbrechAufenthKlient1.cmbBetreuungsstufe.Text;
                        }
                        else
                        {
                            rPatient.Betreuungsstufe = "";
                        }
                        if (this.ucAbrechAufenthKlient1.udteBetreuungsstufeAb.Value != null)
                        {
                            rPatient.BetreuungsstufeAb = this.ucAbrechAufenthKlient1.udteBetreuungsstufeAb.DateTime;
                        }
                        else
                        {
                            rPatient.BetreuungsstufeAb = null;
                        }
                        if (this.ucAbrechAufenthKlient1.udteBetreuungsstufBis.Value != null)
                        {
                            rPatient.BetreuungsstufeBis = this.ucAbrechAufenthKlient1.udteBetreuungsstufBis.DateTime;
                        }
                        else
                        {
                            rPatient.BetreuungsstufeBis = null;
                        }

                        string lstSprachenTmp = rPatient.lstSprachen.Trim();
                        //PMDS.db.Entities.Patient rPatient = this.b.getPatient(ucKlient1.Klient.ID, db);
                        rPatient.lstSprachen = this.cboSprachenMulti.getSelectedRows();
                        if (!PMDS.Global.generic.sEquals(lstSprachenTmp, rPatient.lstSprachen))                         {
                            writeDekursSprachenChanged = true;
                            txtSprachenGeändert = "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Sprache") + ": " + lstSprachenTmp + " -> " +  rPatient.lstSprachen.Trim() + "";
                        }

                        rPatient.RezGebBef_RegoJN = this.chkRezGebBef_RegoJN.Checked;
                        if (this.datRezGebBef_RegoAb.Value != null)
                        {
                            rPatient.RezGebBef_RegoAb = this.datRezGebBef_RegoAb.DateTime.Date;
                        }
                        else
                        {
                            rPatient.RezGebBef_RegoAb = null;
                        }

                        if (this.datRezGebBef_RegoBis.Value != null)
                        {
                            rPatient.RezGebBef_RegoBis = this.datRezGebBef_RegoBis.DateTime.Date;
                        }
                        else
                        {
                            rPatient.RezGebBef_RegoBis = null;
                        }
                        rPatient.RezGebBef_UnbefristetJN = this.chkRezGebBef_UnbefristetJN.Checked;
                        rPatient.RezGebBef_BefristetJN = this.chkRezGebBef_BefristetJN.Checked;
                        if (this.datRezGebBef_BefristetAb.Value != null)
                        {
                            rPatient.RezGebBef_BefristetAb = this.datRezGebBef_BefristetAb.DateTime.Date;
                        }
                        else
                        {
                            rPatient.RezGebBef_BefristetAb = null;
                        }
                        if (this.datRezGebBef_BefristetBis.Value != null)
                        {
                            rPatient.RezGebBef_BefristetBis = this.datRezGebBef_BefristetBis.DateTime.Date;
                        }
                        else
                        {
                            rPatient.RezGebBef_BefristetBis = null;
                        }
                        rPatient.RezGebBef_WiderrufJN = this.chkRezGebBef_WiderrufJN.Checked;
                        rPatient.RezGebBef_WiderrufGrund = this.cboRezGebBef_WiderrufGrund.Text;
                        rPatient.RezGebBef_SachwalterJN = this.chkRezGebBef_SachwalterJN.Checked;
                        rPatient.RezGebBef_Anmerkung = this.editorRezGebBef_Anmerkung.Text.Trim();
                        rPatient.Datenschutz = this.chkDatenschutz.Checked;
                        rPatient.Palliativ = this.chkPalliativ.Checked;
                        rPatient.Amputation_Prozent = (int)this.intAmputation_Prozent.Value;
                        rPatient.TageAbweseneheitOhneKuerzung = (int)this.ucAbrechAufenthKlient1.numTageAbweseneheitOhneKuerzung.Value;

                        ucVersichrungsdaten VersDaten = this.ucAbrechAufenthKlient1.ucVersichrungsdaten12;
                        rPatient.SozVersStatus = VersDaten.cboSozVersStatus.Text.Trim();
                        rPatient.SozVersLeerGrund = VersDaten.cboSozVersLeerGrund.Text.Trim();
                        rPatient.SozVersMitversichertBei = VersDaten.txtSozVersMitversichertBei.Text.Trim();
                        rPatient.ELGAAbgemeldet = this.chkELGAAbgemeldet.Checked;

                        if (!String.IsNullOrWhiteSpace(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtVersNr.Text))
                        {
                            rPatient.SozVersLeerGrund = "";
                            this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersLeerGrund.Text = "";
                            if (!generic.sEquals(this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.cboSozVersStatus.Text, "mitversichert"))
                            {
                                rPatient.SozVersMitversichertBei = "";
                                this.ucAbrechAufenthKlient1.ucVersichrungsdaten12.txtSozVersMitversichertBei.Text = "";
                            }
                        }
                        else
                        {
                            //rPatient.SozVersStatus = "";
                            //this.ucAbrechAufenthKlient1.ucVersichrungsdaten1.cboSozVersStatus.Text = "";
                            rPatient.SozVersMitversichertBei = "";
                            VersDaten.txtSozVersMitversichertBei.Text = "";
                            rPatient.Klasse = "";
                            VersDaten.cmbKlasse.Text = "";
                        }

                        if (rPatient.TitelPost.Trim() != this.cboTitelPost.Text.Trim())
                        {
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel nachgestellt: ") + rPatient.TitelPost + " -> " + this.cboTitelPost.Text);
                            rPatient.TitelPost = this.cboTitelPost.Text.Trim();
                        }

                        if (rPatient.DNRAnmerkung.Trim() != this.txtDNRAnmerkung.Text.Trim())
                        {
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR/Palliativ Anmerkung: ") + rPatient.DNRAnmerkung + " -> " + this.txtDNRAnmerkung.Text);
                            rPatient.DNRAnmerkung = this.txtDNRAnmerkung.Text.Trim();
                        }


                        if (rPatient.bPK.Trim() != this.txtbPK.Text.Trim())
                        {
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereichsspez. Personenkennz.: ") + rPatient.bPK + " -> " + this.txtbPK.Text);
                            rPatient.bPK = this.txtbPK.Text.Trim();
                        }

                        db.SaveChanges();   
                    }

                    if (b.checkAufenthaltExists(IDAufenthaltAct, db))
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAufenthalt(IDAufenthaltAct, db);
                        bool bAbwesenheitBeendetTmp = rAufenthalt.AbwesenheitBeendet;
                        rAufenthalt.AbwesenheitBeendet = this.chkAbwesenheitBeendet.Checked;
                        if (bAbwesenheitBeendetTmp && !rAufenthalt.AbwesenheitBeendet)
                        {
                            abweseneheitBeendetChanged = true;
                        }

                        if (rAufenthalt.SofortMassnahmen.Trim() != this.txtSofortmassnahmen.Text.Trim())
                        {
                            sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Wichtige Informationen: ") + rAufenthalt.SofortMassnahmen.Trim() + " -> " + this.txtSofortmassnahmen.Text.Trim());
                        }
                        rAufenthalt.SofortMassnahmen = this.txtSofortmassnahmen.Text.Trim();
                  
                        db.SaveChanges();
                    }

                    if (PMDS.Global.historie.HistorieOn)
                    {
                        bool bKlientEntlassungszeitpunktÄndern = ENV.HasRight(UserRights.KlientEntlassungszeitpunktÄndern);
                        if (bKlientEntlassungszeitpunktÄndern || PMDS.Global.ENV.adminSecure)
                        {
                            if (this.ucAbrechAufenthKlient1.IDAufenthaltEntlassen != null && this.ucAbrechAufenthKlient1.dtpEntlassungszeitpunkt != null)
                            {
                                Guid IDAufenthaltEntlassen;
                                using (ucAbrechAufenthKlient ucAbrechLocal = new ucAbrechAufenthKlient())
                                {
                                    ucAbrechLocal.IDAufenthaltEntlassen = ucAbrechLocal.IDAufenthaltEntlassen.Value;
                                }
                                PMDS.db.Entities.Aufenthalt rAufenthaltEntlassen = this.b.getAufenthalt(this.ucAbrechAufenthKlient1.IDAufenthaltEntlassen.Value, db);
                                if(rAufenthaltEntlassen.Aufnahmezeitpunkt <= this.ucAbrechAufenthKlient1.dtpEntlassungszeitpunkt.DateTime)
                                {
                                    rAufenthaltEntlassen.Entlassungszeitpunkt = this.ucAbrechAufenthKlient1.dtpEntlassungszeitpunkt.DateTime;

                                    if (rAufenthaltEntlassen.Entlassungszeitpunkt != this.ucAbrechAufenthKlient1.dEntlassungszeitpunktOrig)
                                    {
                                        db.SaveChanges();
                                        sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassungszeitpunkt: ") + this.ucAbrechAufenthKlient1.dEntlassungszeitpunktOrig.Value.ToString("dd.MM.yyyy HH:mm") + " -> " + rAufenthaltEntlassen.Entlassungszeitpunkt.Value.ToString("dd.MM.yyyy HH:mm"));
                                    }

                                }
                                else
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Entlassungszeitpunkt darf nicht vor dem Aufnahmezeitpunkt liegen.", "PMDS", MessageBoxButtons.OK);
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
                throw new Exception("ucKlientStammdaten.SaveER: " + ex.ToString());
            }
        }

        public void Write()
        {
            this.Klient.Write(this._mainSystem, this._isAbrechnung, this._isBewerberJN);
        }



        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;


            // txtNachname
            bool isWrong = false;
            GuiUtil.ValidateField(txtNachname, (txtNachname.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1, ref isWrong);

            // txtVorname
            isWrong = false;
            GuiUtil.ValidateField(txtVorname, (txtVorname.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1, ref isWrong);

            // cmbSexus
            isWrong = false;
            GuiUtil.ValidateField(cmbSexus, (cmbSexus.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1, ref isWrong);

            // dtpGebDatum
            isWrong = false;
            GuiUtil.ValidateField(gebDatum, (gebDatum.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1, ref isWrong);

            if (this.cmbBenutzer.Value != null && !this.cmbBenutzer.Value.GetType().Equals(typeof(Guid)))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Erstkontakt: Falsche Auswahl!", "", MessageBoxButtons.OK);
                GuiUtil.setColorCbo(cmbBenutzer);
                bError = true;
            }

            // Erstkontakt
            //GuiUtil.ValidateField(cmbBenutzer, (cmbBenutzer.Text.Length > 0),
            //    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (txtFallzahl.Text.Trim() != "")
            {
                isWrong = false;
                GuiUtil.ValidateField(txtFallzahl, KlientGuiAction.IsDouble(txtFallzahl.Text.Trim()),
                            ENV.String("GUI.E_FLOAT_OUTOFRANGE", double.MinValue, double.MaxValue), ref bError, bInfo, errorProvider1, ref isWrong);
            }

            //Grösse
            if (txtGroesse.Text.Trim() != "")
            {
                isWrong = false;
                GuiUtil.ValidateField(txtGroesse, KlientGuiAction.IsInteger(txtGroesse.Text.Trim()),
                            ENV.String("GUI.E_FLOAT_OUTOFRANGE", int.MinValue, int.MaxValue), ref bError, bInfo, errorProvider1, ref isWrong);
            }

            //Gewicht
            if (txtGewicht.Text.Trim() != "")
            {
                isWrong = false;
                GuiUtil.ValidateField(txtGewicht, KlientGuiAction.IsDouble(txtGewicht.Text.Trim()),
                            ENV.String("GUI.E_FLOAT_OUTOFRANGE", double.MinValue, double.MaxValue), ref bError, bInfo, errorProvider1, ref isWrong);
            }

            if (!bError)
                if (ucAbrechAufenthKlient1 != null)
                    bError = !this.ucAbrechAufenthKlient1.ValidateFields();


            if (this.chkDNR.Checked && this.chkPalliativ.Checked)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es kann nur DNR oder Palliativ ausgewählt werden!", "", MessageBoxButtons.OK);
                bError = true;
            }
            if ((int)this.intAmputation_Prozent.Value > 60 || (int)this.intAmputation_Prozent.Value < 0)
            {
                if (isWrong)
                {
                    GuiUtil.setColorTxt2(intAmputation_Prozent);
                }
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Amputation muss zwischen 0 und 60 Prozent liegen!", "", MessageBoxButtons.OK);
                bError = true;
            }

            //if (this.cmbSexus.SelectedItem == null)
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Geschlecht: Auswahl erforderlich!", "", MessageBoxButtons.OK);
            //    this.cmbSexus.Focus();
            //    bError = true;
            //}
            //if (this.cmbFAM.SelectedItem == null && this.cmbFAM.Text.Trim() != "")
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fam.Stand: Auswahl erforderlich!", "", MessageBoxButtons.OK);
            //    this.cmbFAM.Focus();
            //    bError = true;
            //}
            //if (this.cmbKonfession.SelectedItem == null && this.cmbKonfession.Text.Trim() != "")
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Konfession: Auswahl erforderlich!", "", MessageBoxButtons.OK);
            //    this.cmbKonfession.Focus();
            //    bError = true;
            //}

            string MsgTxt2 = "";
            bool cbSexusOK = PMDSBusinessUI.checkCboBox(this.cmbSexus, QS2.Desktop.ControlManagment.ControlManagment.getRes("Geschlecht"), true, ref MsgTxt2, true);
            bool cbAnredeOK = PMDSBusinessUI.checkCboBox(this.cmbAnrede, QS2.Desktop.ControlManagment.ControlManagment.getRes("Anrede"), true, ref MsgTxt2, true);
            bool cbAkdGradOK = PMDSBusinessUI.checkCboBox(this.cmbAkdGrad, QS2.Desktop.ControlManagment.ControlManagment.getRes("Akad.Grad"), true, ref MsgTxt2, true);
            bool cbFAMOK = PMDSBusinessUI.checkCboBox(this.cmbFAM, QS2.Desktop.ControlManagment.ControlManagment.getRes("Fam.Stand"), true, ref MsgTxt2, true);
            bool cbStaatsBOK = PMDSBusinessUI.checkCboBox(this.cmbStaatsB, QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsbg."), true, ref MsgTxt2, true);
            bool cbKonfessionOK = PMDSBusinessUI.checkCboBox(this.cmbKonfession, QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfession"), true, ref MsgTxt2, true);
            bool cbAugenFarbeOK = PMDSBusinessUI.checkCboBox(this.cmbAugenFarbe, QS2.Desktop.ControlManagment.ControlManagment.getRes("Augenfarbe"), true, ref MsgTxt2, true);
            bool cbHaarFarbeOK = PMDSBusinessUI.checkCboBox(this.cmbHaarFarbe, QS2.Desktop.ControlManagment.ControlManagment.getRes("Haarfarbe"), true, ref MsgTxt2, true);
            bool cbStaturOK = PMDSBusinessUI.checkCboBox(this.cmbstatur, QS2.Desktop.ControlManagment.ControlManagment.getRes("Statur"), true, ref MsgTxt2, true);
            if (!cbSexusOK || !cbAnredeOK || !cbAkdGradOK || !cbFAMOK || !cbStaatsBOK || !cbKonfessionOK || !cbAugenFarbeOK || !cbHaarFarbeOK || !cbStaturOK)
            {
                bError = true;
                this.tabStammdaten.SelectedTab = this.tabStammdaten.Tabs["PersoenlicheDaten"];
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }
            
            bool cbLandOK = PMDSBusinessUI.checkCboBox(this.txtLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land Hauptwohnsitz"), true, ref MsgTxt2, true);
            bool cbLandNWSOK = PMDSBusinessUI.checkCboBox(this.txtLandNWS, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land Nebenwohnsitz"), true, ref MsgTxt2, true);
            if (!cbLandOK || !cbLandNWSOK)
            {
                bError = true;
                this.tabStammdaten.SelectedTab = this.tabStammdaten.Tabs["Wohnsituation"];
                if (!cbLandOK)
                {
                    this.ultraTabControlMainAdresse.SelectedTab = this.tabStammdaten.Tabs[0];
                    this.txtLand.Focus();
                }
                if (!cbLandNWSOK)
                {
                    this.ultraTabControlMainAdresse.SelectedTab = this.tabStammdaten.Tabs[1];
                    this.txtLandNWS.Focus();
                }
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            if (PMDS.Global.ENV.lic_ELGA && !this._isBewerberJN && !this._isAbrechnung && this._mainSystem)
            {
                this.contELGAKlient1.validateData();
            }

            return !bError;
        }



        //Errorprovider initialisieren
        private void InitFields()
        {
            errorProvider1.SetError(txtNachname, "");
            errorProvider1.SetError(txtVorname, "");
            errorProvider1.SetError(cmbSexus, "");
            errorProvider1.SetError(gebDatum, "");
            errorProvider1.SetError(cmbBenutzer, "");
            errorProvider1.SetError(txtFallzahl, "");
            errorProvider1.SetError(txtGroesse, "");
            errorProvider1.SetError(txtGewicht, "");
        }


        //Änderung nach 27.04.2007 MDA
        private void SetReadOnly()
        {
            foreach (UltraTab t in tabStammdaten.Tabs)
            {
                foreach (Control c in t.TabPage.Controls)
                {
                    SetReadOnly(c);
                }
            }
            if (!ReadOnly)
                RequiredFields();

        }

        //Neu nach 27.04.2007 MDA
        private void SetReadOnly(Control c)
        {
            if (c is Label || c is Infragistics.Win.Misc.UltraLabel || c is UltraPictureBox)
                return;

            if (c is UltraGrid)
            {
                if (c.Name == "gridAerzte")
                    ((UltraGrid)c).DisplayLayout.Override.CellClickAction = ReadOnly ? CellClickAction.RowSelect : CellClickAction.Default;
                return;
            }

            System.Reflection.PropertyInfo info = null;

            info = c.GetType().GetProperty("ReadOnly");

            if (info != null)
                info.SetValue(c, ReadOnly, null);
            else if(!c.HasChildren)
                c.Enabled = !ReadOnly;

            foreach (Control control in c.Controls)
            {
                SetReadOnly(control);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(txtNachname);
            GuiUtil.ValidateRequired(txtVorname);
            GuiUtil.ValidateRequired(cmbSexus);
            GuiUtil.ValidateRequired(gebDatum);
            //GuiUtil.ValidateRequired(cmbBenutzer);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liste alle Benutzer setzen
        /// Aktueller Benutzer auswählen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitBenutzer()
        {
            cmbBenutzer.Items.Clear();
            
            foreach (DataRow r in Benutzer.All().Rows)
                cmbBenutzer.Items.Add(r["ID"], (string)r["TEXT"]);

            cmbBenutzer.Value = Klient.IDBenutzer;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Aufenthalt-Aerzte Rows ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsPatientAerzte.PatientAerzteRow[] CurrentAerzteSelectedRows()
        {
            dsPatientAerzte.PatientAerzteRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in gridAerzte.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsPatientAerzte.PatientAerzteRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsPatientAerzte.PatientAerzteRow)v.Row;
                    i++;
                }

            }
            else if (UltraGridTools.CurrentSelectedRow(gridAerzte) != null)
            {
                list = new dsPatientAerzte.PatientAerzteRow[1];
                list[0] = (dsPatientAerzte.PatientAerzteRow)UltraGridTools.CurrentSelectedRow(gridAerzte);
            }

            return list;
        }

        private dsAerzte.AerzteRow CurrentArzt()
        {
            dsPatientAerzte.PatientAerzteRow row = (dsPatientAerzte.PatientAerzteRow)UltraGridTools.CurrentSelectedRow(gridAerzte);
            if (row == null)
                return null;

            foreach (dsAerzte.AerzteRow r in Klient.CLASS_AERZTE.AERZTE.Aerzte)
            {
                if (r.ID == row.IDAerzte) return r;
            }

            return null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Sachwalter Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsKlientSachwalter.SachwalterRow CurrentSachwalterRow
        {
            get
            {
                return (dsKlientSachwalter.SachwalterRow)UltraGridTools.CurrentSelectedRow(gridSachwalter);
            }
        }

        //Neu nach 13.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Zuordnungen Aerzte-Aufenthal ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private bool UpdateAerzteAufenthalt()
        {
            frmAerzteEdit frm = new frmAerzteEdit();
            frm.ShowAuswahlColumn = true;
            frm.Aerzte = Klient.CLASS_AERZTE.GetPatientAerzte();
            frm.SaveChanges = false;
            frm.CLASS_AERZTE = Klient.CLASS_AERZTE;
            frm.CanModify = false;
            DialogResult res = frm.ShowDialog();
            
            if (res != DialogResult.OK)
                return false;

            //KlientGuiAction.AddPatientAerzte(frm.Aerzte, Klient);

            DialogResult resDoppelterArzt;

            if (frm.CurrentArztRow != null)
            {
                foreach(Guid ArztID in frm.Aerzte)
                {
                    if (frm.CurrentArztRow.ID == ArztID)
                    {
                         resDoppelterArzt = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der gewählte Arzt ist dem Bewohner bereits zugeordnet, wollen sie ihn trotzdem zuordnen ?" ,
                               "Dieser Arzt ist bereits zugeordnet",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
                       
                        if (resDoppelterArzt == DialogResult.No)
                        {
                            
                            return false;
                        }
                        //if (resDoppelterArzt == DialogResult.Yes)
                        //{
                            
                        //    return;
                        //
                    }                  
                }

                dsPatientAerzte.PatientAerzteRow  rNewPatientÄrzte = Klient.CLASS_AERZTE.NewPatientAerzte(frm.CurrentArztRow.ID);
                KlientGuiAction.RefreshListPatientAerzte(gridAerzte, Klient);

                //HL_AddPE_KontaktPatient_06
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt hinzugefügt für Patient {0}");
                string txt = "";
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdress = b.getCheckAdresse(frm.CurrentArztRow.IDAdresse, db);
                    PMDS.db.Entities.Kontakt rKontakt = b.getCheckKontakt(frm.CurrentArztRow.IDKontakt, db);
                    txt += "Name: " + frm.CurrentArztRow.Nachname.Trim() + " " + frm.CurrentArztRow.Vorname.Trim() + "\r\n";
                    if (rAdress != null)
                    {
                        txt += "Adress: " + rAdress.Plz.Trim() + " " + rAdress.Ort.Trim() + ", " + rAdress.Strasse.Trim() + "\r\n";
                    }
                    if (rKontakt != null)
                    {
                        txt += "E-Mail: " + rKontakt.Email.Trim();
                    }
                    KlientGuiAction.addKontakteChanged2(title, txt, Klient.IDPatient);
                }

                KlientGuiAction KlientGuiAction1 = new KlientGuiAction();
                KlientGuiAction1.doUIDienstübergabe(ref frm.lstPatienteSelected2, ref this.lstÄrzteMehrfachauswahl, frm.CurrentArztRow.ID, rNewPatientÄrzte, this.gridAerzte);
                return true;
            }
            
            return false;
        }

        private bool UpdateArzt()
        {
            dsAerzte.AerzteRow row = CurrentArzt();

            if (row == null)
                return false;

            frmArzt frm = new frmArzt();
            frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
            frm.Arzt = Klient.CLASS_AERZTE.GetArzt(row.ID);
            frm.AerzteRow = row;
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                //HL_AddPE_KontaktPatient_07
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt geändert für Patient {0}");
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdress = b.getAdresse(row.IDAdresse, db);
                    PMDS.db.Entities.Kontakt rKontakt = b.getKontakt(row.IDKontakt, db);
                    //txt += "Name: " + row.Nachname.Trim() + " " + row.Vorname.Trim() + "\r\n";
                    //txt += "Adress: " + rAdress.Plz.Trim() + " " + rAdress.Ort.Trim() + ", " + rAdress.Strasse.Trim() + "\r\n";
                    //txt += "E-Mail: " + rKontakt.Email.Trim();

                    string txtDekurs = PMDSBusinessUI.getDekursAerzte(row, frm.Arzt.Adresse, frm.Arzt.Kontakt);
                    KlientGuiAction.addKontakteChanged2(title, txtDekurs, Klient.IDPatient);
                }
                KlientGuiAction.RefreshListPatientAerzte(gridAerzte, Klient);
                return true;
            }

            return false;
        }
         
        private void UpdateSachwalter(object sender, EventArgs e, UltraGrid grid)
        {
            if (CurrentSachwalterRow != null)
            {
                bool change = KlientGuiAction.UpdateSachwalter(CurrentSachwalterRow, Klient, grid);
                if (change)
                {
                    ValueChanged(sender, e);
                }
                    
            }
        }

        //private Image GetFoto(byte[] buffer)
        //{
        //    if (buffer != null && buffer.Length != 0)
        //        return BUtil.ImageFromArray(buffer, true);
        //    else
        //        return null;
        //}

        public dsPatientAerzte.PatientAerzteRow getSelectedRowÄrtze(bool msgBox)
        {
            try
            {
                if (this.gridAerzte.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.gridAerzte.ActiveRow.ListObject;
                    dsPatientAerzte.PatientAerzteRow rSelRow = (dsPatientAerzte.PatientAerzteRow)v.Row;
                    return rSelRow;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.getSelectedRow: " + ex.ToString());
            }
        }
        private void HideOrShowControls()
        {
            if (!this._isAbrechnung && !this._isBewerberJN)
            {
                txtFallzahl.Visible = Klient.Aufenthalt != null;
                lblFallzahl.Visible = Klient.Aufenthalt != null;
                lblGruppenKz.Visible = Klient.Aufenthalt != null;
                txtgruppenkennzahl.Visible = Klient.Aufenthalt != null;
                lblGewicht.Visible = Klient.Aufenthalt != null;
                txtGewicht.Visible = Klient.Aufenthalt != null;
                lblKlientNr.Visible = Klient.Aufenthalt != null;
                lblZimNr.Visible = Klient.Aufenthalt != null;
                txtKliNr.Visible = Klient.Aufenthalt != null;
                txtZimmerNr.Visible = Klient.Aufenthalt != null;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges) return;
            //if (PMDS.Global.historie.HistorieOn) return;

            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Versicherungsdaten Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnVersDatenChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (VersDatenChanged != null))
                VersDatenChanged(sender, args);
        }

        private void btnUpdateAerzte_Click(object sender, EventArgs e)
        {
            if (UpdateAerzteAufenthalt() && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnAddSachw_Click(object sender, EventArgs e)
        {
            bool change = KlientGuiAction.UpdateSachwalter(null, Klient, this.gridSachwalter);
            if (change)
                ValueChanged(sender, e);
        }

        private void btnDelSachw_Click(object sender, EventArgs e)
        {
            if (KlientGuiAction.DeleteAllSelectedSachwalter(gridSachwalter, _klient) && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void gridAerzte_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            //if (PMDS.Global.historie.HistorieOn) return;

            //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            if (ReadOnly) return;
            if (UpdateArzt() && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void gridSachwalter_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            //if (PMDS.Global.historie.HistorieOn) return;

            //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            if (!ReadOnly)
                UpdateSachwalter(sender, e, this.gridSachwalter);
        }


        private void btnUpdateSachw_Click(object sender, EventArgs e)
        {
            UpdateSachwalter(sender, e, this.gridSachwalter);
        }

        private void gridAerzte_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (KlientGuiAction.DeletePatientAerzteZuordnungen(CurrentAerzteSelectedRows()) && ValueChanged != null) 
                    ValueChanged(sender, e);
            }
        }

        private void gridSachwalter_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren)
            {
                if (KlientGuiAction.DeleteAllSelectedSachwalter(gridSachwalter, _klient) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void btnDelAerzte_Click(object sender, EventArgs e)
        {
            if (KlientGuiAction.DeletePatientAerzteZuordnungen(CurrentAerzteSelectedRows()) && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void gridAerzte_CellChange(object sender, CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnUpdateArzt_Click(object sender, EventArgs e)
        {
            if (UpdateArzt() && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void ucKontaktPersonen1_Load(object sender, EventArgs e)
        {

        }


        private void ucAbrechAufenthKlient1_VisibleChanged(object sender, EventArgs e)
        {
            this.ucAbrechAufenthKlient1.initControl(false, this._mainSystem, this._isBewerberJN);
        }

        private void ucAbrechAufenthKlient1_ValueChanged(object sender, EventArgs e)
        {
            this.ValueChanged(sender, e);
        }

        private void ultraTabPageControl2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void lblPatientenverfügung_MouseHover(object sender, EventArgs e)
        {
            try
            {
                //UltraToolTipInfo info = new UltraToolTipInfo();
                //info.ToolTipText = ENV.String("aaa bbbb cccc");
                //info.ToolTipText = "xx dd ff";
                //this.ultraToolTipManager1.SetUltraToolTip(this.lblPatientenverfügung, info);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        private void lblPatientenverfügung_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (this.InfoPatientenverfügung.Trim() != "")
                {
                    UltraToolTipInfo info = new UltraToolTipInfo();
                    //info.ToolTipTitle = this.InfoPatientenverfügung.Trim();
                    info.ToolTipText = this.InfoPatientenverfügung.Trim();
                    this.ultraToolTipManager1.SetUltraToolTip(this.lblPatientenverfügung, info);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void lblPatientenverfügung_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                UltraToolTipInfo info = new UltraToolTipInfo();
                this.ultraToolTipManager1.SetUltraToolTip(this.lblPatientenverfügung, null);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void zusammenführenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                dsPatientAerzte.PatientAerzteRow rSelÄrzte = this.getSelectedRowÄrtze(true);
                //if (rSelÄrzte != null)
                //{
                //    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //    {
                //        if (b.ÄrzteZusammenführen(rSelÄrzte.ID, rSelÄrzte.IDPatient, db))
                //        {
                //            KlientGuiAction.RefreshListPatientAerzte(gridAerzte, Klient);
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void datRezGebBef_RegoAb_MouseEnter(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void datRezGebBef_RegoAb_MouseLeave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void datRezGebBef_RegoAb_Enter(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void datRezGebBef_RegoAb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.datRezGebBef_RegoAb.Focused)
                if (!this.KlientUIEventsLocked)
                {
                    this.datRezGebBefAbChanged = true;
                    this.OnValueChanged(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void datRezGebBef_RegoAb_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!this.KlientUIEventsLocked)
                {
                    this.checkFieldDatRezGebBefRegoBis(sender, e, true);
                    this.datRezGebBefAbChanged = false;
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public void checkFieldDatRezGebBefRegoBis(object sender, EventArgs e, bool doOnvalueChanged)
        {
            try
            {
                if (this.datRezGebBef_RegoAb.Value != null || this.datRezGebBef_RegoBis.Value != null)
                {
                    this.cbRezeptGeb.Checked = true;
                }

                //if (this.datRezGebBefAbChanged && this.datRezGebBef_RegoAb.Value != null && this.datRezGebBef_RegoBis.Value != null)
                if (this.datRezGebBefAbChanged)
                {
                    if (this.datRezGebBef_RegoAb.Value != null)
                    {
                        DateTime RezGebBefAbTmp = this.datRezGebBef_RegoAb.DateTime.Date;
                        DateTime datEndYear = new DateTime(RezGebBefAbTmp.Year, 12, 31, 0, 0, 0);
                        this.datRezGebBef_RegoBis.DateTime = datEndYear;
                    }

                    if (doOnvalueChanged)
                        this.OnValueChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("checkFieldDatRezGebBefRegoBis: " + ex.ToString());
            }
        }

        private void chkRezGebBef_UnbefristetJN_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRezGebBef_UnbefristetJN.Focused)
                {
                    if (this.chkRezGebBef_UnbefristetJN.Checked)
                    {
                        this.cbRezeptGeb.Checked = true;

                        this.chkRezGebBef_RegoJN.Checked = false;
                        this.chkRezGebBef_BefristetJN.Checked = false;
                        this.chkRezGebBef_WiderrufJN.Checked = false;
                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void chkRezGebBef_BefristetJN_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRezGebBef_BefristetJN.Focused)
                {
                    if (this.chkRezGebBef_BefristetJN.Checked)
                    {
                        this.cbRezeptGeb.Checked = true;

                        this.chkRezGebBef_RegoJN.Checked = false;
                        this.chkRezGebBef_UnbefristetJN.Checked = false;
                        this.chkRezGebBef_WiderrufJN.Checked = false;
                        this.OnValueChanged(sender, e);
                    }
                    if (!this.chkRezGebBef_BefristetJN.Checked)
                    {
                        this.datRezGebBef_BefristetBis.Value = null;
                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void chkRezGebBef_WiderrufJN_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRezGebBef_WiderrufJN.Focused)
                {
                    if (this.chkRezGebBef_WiderrufJN.Checked)
                    {
                        this.cbRezeptGeb.Checked = true;

                        this.chkRezGebBef_RegoJN.Checked = false;
                        this.chkRezGebBef_UnbefristetJN.Checked = false;
                        this.chkRezGebBef_BefristetJN.Checked = false;
                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void cbRezeptGeb_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbRezeptGeb.Focused)
                {
                    if (!this.cbRezeptGeb.Checked)
                    {
                        this.chkRezGebBef_RegoJN.Checked = false;
                        this.datRezGebBef_RegoAb.Value = null;
                        this.datRezGebBef_RegoBis.Value = null;
                        this.chkRezGebBef_UnbefristetJN.Checked = false;
                        this.chkRezGebBef_BefristetJN.Checked = false;
                        this.datRezGebBef_BefristetAb.Value = null;
                        this.datRezGebBef_BefristetBis.Value = null;
                        this.chkRezGebBef_WiderrufJN.Checked = false;
                        this.cboRezGebBef_WiderrufGrund.Text = "";
                        this.cboRezGebBef_WiderrufGrund.Value = null;
                        this.chkRezGebBef_SachwalterJN.Checked = false;

                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void datRezGebBef_BefristetBis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.KlientUIEventsLocked)
                {
                    if (this.datRezGebBef_BefristetBis.Value == null)
                    {
                        this.chkRezGebBef_BefristetJN.Checked = false;
                    }
                    this.ValueChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void chkRezGebBef_SachwalterJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRezGebBef_SachwalterJN.Focused)
                {
                    if (this.chkRezGebBef_SachwalterJN.Checked)
                    {
                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void chkRezGebBef_RegoJN_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRezGebBef_RegoJN.Focused)
                {
                    if (this.chkRezGebBef_RegoJN.Checked)
                    {
                        this.cbRezeptGeb.Checked = true;

                        this.chkRezGebBef_UnbefristetJN.Checked = false;
                        this.chkRezGebBef_BefristetJN.Checked = false;
                        this.chkRezGebBef_WiderrufJN.Checked = false;

                        this.OnValueChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void datRezGebBef_BefristetAb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.KlientUIEventsLocked)
                {
                    if (this.datRezGebBef_BefristetAb.Value == null)
                    {
                        this.chkRezGebBef_BefristetJN.Checked = false;
                    }
                    this.ValueChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnAbwesenheitsendeBestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.MainWindow.writeDekursAbwesenheitsende(this.Klient.Aufenthalt.ID))
                {
                    this.btnAbwesenheitsendeBestätigen.Visible = false;
                    if (GuiWorkflow.HeaderMain != null)
                    {
                        GuiWorkflow.HeaderMain.ucMedizinDaten1.Refresh(this.Klient.ID, false);
                    }
                  
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chkDNR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkDNR.Focused)
                {
                    bool bPalliativStatusOrig = this.chkPalliativ.Checked;
                    bool bDNRStatusOrig = !this.chkDNR.Checked;

                    if (ENV.HasRight(UserRights.DNR_Palliativ))
                    {
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den DNR-Status wirklich ändern?", "ACHTUNG!", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            if (this.chkPalliativ.Checked == true && this.chkDNR.Checked == true)
                                this.chkPalliativ.Checked = false;
                        }
                        else
                        {
                            this.chkDNR.Checked = bDNRStatusOrig;
                            this.chkPalliativ.Checked = bPalliativStatusOrig;
                        }
                        OnValueChanged(sender, e);
                    }
                    else
                    {
                        //CheckBox zurücksetzen
                        this.chkDNR.Checked = bDNRStatusOrig;
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, dieses Feld zu bearbeiten.");
                    }
                }
                Application.DoEvents();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void chkPalliativ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPalliativ.Focused)
                {
                    bool bPalliativStatusOrig = !this.chkPalliativ.Checked;
                    bool bDNRStatusOrig = this.chkDNR.Checked;

                    if (ENV.HasRight(UserRights.DNR_Palliativ))
                    {

                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Palliativ-Status wirklich ändern?", "ACHTUNG!", MessageBoxButtons.YesNoCancel);
                        if (res == DialogResult.Yes)
                        {
                            if (this.chkPalliativ.Checked == true && this.chkDNR.Checked == true)
                                this.chkDNR.Checked = false;
                        }
                        else
                        {
                            this.chkDNR.Checked = bDNRStatusOrig;
                            this.chkPalliativ.Checked = bPalliativStatusOrig;
                        }
                        OnValueChanged(sender, e);
                    }
                    else
                    {
                        //CheckBox zurücksetzen
                        this.chkPalliativ.Checked = bPalliativStatusOrig;
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, dieses Feld zu bearbeiten.");
                    }
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void lblZimNr_Click(object sender, EventArgs e)
        {

        }

        private void lblFallzahl_Click(object sender, EventArgs e)
        {

        }

        private void txtFallzahl_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
        {

        }

        private void panelAufenthaltsdaten2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpenPicture_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (!this.b.checkPatientExists(Klient.ID, db))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie müssen speichern, bevor Sie ein Bild hinzufügen können!", "Hinweis", MessageBoxButtons.OK);
                    }
                    else
                    {
                        frmKlientFoto frmKlientFoto1 = new frmKlientFoto();
                        frmKlientFoto1.initControl(Klient.ID, this._isBewerberJN);
                        frmKlientFoto1.ShowDialog(this);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ChkELGAAbgemeldet_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkELGAAbgemeldet.Focused)
                {
                    this.setTabELGAOnIff(this.chkELGAAbgemeldet.Checked);

                    object send = null;
                    EventArgs arg = new EventArgs();
                    this.OnValueChanged(send, arg);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtDNRAnmerkung_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtDNRAnmerkung.Focused)
            {
                if (this.txtDNRAnmerkung.Text.Trim() != this._DNRAnmerkung)
                {
                    if (!ENV.HasRight(UserRights.DNR_Palliativ))
                    {
                        //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, dieses Feld zu bearbeiten.");
                        this.txtDNRAnmerkung.Text = this._DNRAnmerkung;                       
                    }
                    else
                    {
                        this._DNRAnmerkung = this.txtDNRAnmerkung.Text;
                        OnValueChanged(sender, e);
                    }
                }
            }
        }

        private void baseLabel4_Click(object sender, EventArgs e)
        {

        }

        private void chkELGAAbgemeldet_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.chkELGAAbgemeldet.Focused)
                {
                    bool bELGAABgemeldetStatusOrig = this.chkELGAAbgemeldet.Checked;

                    if (ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAAktionen, true))
                    {
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den ELGA-Status wirklich ändern?", "ELGA", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            this.chkELGAAbgemeldet.Checked = !bELGAABgemeldetStatusOrig;
                        }
                        else
                        {
                            this.chkELGAAbgemeldet.Checked = bELGAABgemeldetStatusOrig;
                        }
                        OnValueChanged(sender, e);
                    }
                    else
                    {
                        //CheckBox zurücksetzen
                        this.chkDNR.Checked = bELGAABgemeldetStatusOrig;
                    }
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnELGAKontakDelegation_Click(object sender, EventArgs e)
        {

            if (ENV.lic_ELGA &&
                    ELGABusiness.checkELGASessionActive(false) &&
                    bELGA.ELGAIsActive(ENV.CurrentIDPatient, ENV.IDAUFENTHALT, false) &&
                    ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAKontaktdelegation, false))
            {
                if (KlientGuiAction.ELGAKontaktDelegation(CurrentAerzteSelectedRows(), _klient) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
            else
            {
                using (PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox())
                {
                    string sMsg = "Kontaktdelegation ist nicht möglich:\n\r";
                    sMsg += !ENV.lic_ELGA ? "Keine ELGA-Lizenz.\n\r" : "";
                    sMsg += !ENV.lic_ELGA ? "Keine ELGA-Sitzung aktiv.\n\r" : "";
                    sMsg += !bELGA.ELGAIsActive(ENV.CurrentIDPatient, ENV.IDAUFENTHALT, false) ? "Patient hat keine Kontaktbestätigung, ist von ELGA abgemeldet oder hat SOO erklärt.\n\r" : "";
                    sMsg += ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAKontaktdelegation, false) ? "Sie haben kein Recht für Kontaktdelegation.\n\r" : "";

                    frmMessageBox1.ShowAbort = false;

                    frmMessageBox1.initControl("Kontaktdelegation ist nicht möglich (z.B. keine Lizenz, keine aktive ELGA-Sitzung, Klient ist abgemeldet, SOO, kein Recht für Delegation ");
                    frmMessageBox1.ShowDialog();
                }
            }
        }
    }
}

