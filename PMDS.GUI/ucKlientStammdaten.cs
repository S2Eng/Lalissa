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


        private bool _mainSystem = false;
        private bool _isAbrechnung = false;
        private bool _isBewerberJN = false;

        private bool _lockValueChanges = false;

        //public ucAbrechAufenthKlient ucAbrechnung1xy;
        public ucKlient MainWindow = null;

        public string InfoPatientenverfügung = "";

        public static System.Collections.Generic.List<cKontakteChanged> lstKontakteChanged = new List<cKontakteChanged>();
        public class cKontakteChanged
        {
            public string title = "";
            public string txt = "";
        }

        PMDS.DB.PMDSBusiness b = new PMDSBusiness();







        public ucKlientStammdaten()
        {
            InitializeComponent();
        }


        public void initControl (bool mainSystem, bool isBewerberJN , bool isAbrechnung)
        {
            this.ucAbrechAufenthKlient1.MainWindow = this;

            this._isAbrechnung = isAbrechnung;
            this._isBewerberJN = isBewerberJN;
            this._mainSystem = mainSystem;
            this.initAufenthalt();

            this.btnUpdateArzt.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);
            this.btnUpdateSachw.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);

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
                this.panelAufenthaltsdaten.Visible = false;
                this.panelAufenthaltsdaten2.Visible = false;
                this.txtGewicht.Visible = false;
                this.lblGewicht.Visible = false;
                this.txtBesonderheit.Visible = false;
                this.lblBesonderheit.Visible = false;
            }
            else
            {
                this.txtBesonderheit.Visible = ENV.HasRight(UserRights.Dienstübergabe);
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
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            if (ucAbrechAufenthKlient1 != null) this.ucAbrechAufenthKlient1.setControlsAktivDisable(bOn);
           
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxOben, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAllgemein1, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxPersonebescheibung, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAdressdaten, bOn);

            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxAngehörige, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxÄrtze, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxSachverwalter, bOn);

           // PMDS.GUI.BaseControls.historie.OnOffControls(this , bOn);
            
            this.ucBewerbungsdaten1 .setControlsAktivDisable(bOn);

            this.panelButtons.Visible = !bOn;
            this.btnPicSave.Visible = !bOn;
            this.btnPicClear .Visible = !bOn;
            this.btnPicLoad.Visible = !bOn;

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
        /// Image setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Image
        {
            get
            {
                return (Image)foto.Image;
            }

            set
            {
                if (value != null)
                {
                    foto.Image = value;
                    if (!ReadOnly)
                    {
                        btnPicClear.Enabled = true;
                        btnPicSave.Enabled = true;
                        btnMagnify.Enabled = true;
                    }
                }
                else
                {
                    foto.Image = foto.DefaultImage;
                    btnPicClear.Enabled = false;
                    btnPicSave.Enabled = false;
                    btnMagnify.Enabled = false;
                }
            }
        }


        //Neu nach 27.04.2007
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

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            this._lockValueChanges = true;

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
            Image = GetFoto(Klient.Foto);
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
            this.txtBesonderheit.Text = Klient.Besonderheit.Trim();

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
        }
        public void UpdateGridSachwalter()
        {
            this.gridSachwalter.DataSource = Klient.KLIENT_SACHWALTER;
            this.gridSachwalter.UpdateData();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridSachwalter in this.gridSachwalter.Rows)
            {
                DataRowView v = (DataRowView)rGridSachwalter.ListObject;
                PMDS.Klient.dsKlientSachwalter.SachwalterRow rSachwalter = (PMDS.Klient.dsKlientSachwalter.SachwalterRow)v.Row;
                Sachwalter Sachwalter = new Sachwalter(rSachwalter.ID);
                rGridSachwalter.Cells["TelAdresse"].Value = Sachwalter.Kontakt.Tel + " / " + Sachwalter.Adresse.Ort + " " + Sachwalter.Adresse.Plz + " " + Sachwalter.Adresse.Strasse;
                
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
                    PMDSBusiness b = new PMDSBusiness();
                    PMDS.db.Entities.Patient rPatient = null;
                    if (this._isBewerberJN)
                    {
                        rPatient = b.getPatient2(this.Klient.ID, db);
                    }
                    else
                    {
                        rPatient = b.getPatient(this.Klient.ID, db);
                    }
                    
                    if (rPatient != null)
                    {
                        if (rPatient.PatientenverfuegungJN != null && rPatient.PatientenverfuegungJN.Value == true)
                        {
                            this.InfoPatientenverfügung = "";
                            if (rPatient.PatientverfuegungDatum != null)
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum") + ":" + rPatient.PatientverfuegungDatum.Value.ToString("dd.MM.yyyy");
                            }

                            if (rPatient.PatientenverfuegungBeachtlichJN != null && rPatient.PatientenverfuegungBeachtlichJN.Value == true)
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Beachtlich");
                            }
                            else
                            {
                                this.InfoPatientenverfügung += (this.InfoPatientenverfügung.Trim() == "" ? "" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verbindlich");
                            }

                            if (rPatient.PatientverfuegungAnmerkung != null && rPatient.PatientverfuegungAnmerkung.Trim() != "")
                            {
                                this.InfoPatientenverfügung += "\r\n" + "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anmerkung") + ":" + "\r\n" + rPatient.PatientverfuegungAnmerkung.Trim();
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

            StringBuilder sbChanges = new StringBuilder();

            //----------------------------------------------------
            //              Persönliche Daten
            //----------------------------------------------------
            if (txtNachname.Text.Trim() != Klient.Nachname)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ") + Klient.Nachname + " -> " + txtNachname.Text.Trim());
                Klient.Nachname = txtNachname.Text.Trim();
            }

            if (txtVorname.Text.Trim() != Klient.Vorname)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ") + Klient.Vorname + " -> " + txtVorname.Text.Trim());
                Klient.Vorname = txtVorname.Text.Trim();
            }

            if (cmbAkdGrad.Text.Trim() != Klient.Titel)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ") + Klient.Titel + " -> " + cmbAkdGrad.Text.Trim());
                Klient.Titel = cmbAkdGrad.Text.Trim();
            }

            if (Klient.Aufenthalt != null)
            {
                if(Klient.Aufenthalt.Fallnummer.ToString() != txtFallzahl.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Fallnummer: ") + Klient.Aufenthalt.Fallnummer.ToString() + " -> " + txtFallzahl.Text.Trim());
                    Klient.Aufenthalt.Fallnummer = Convert.ToDouble(txtFallzahl.Text.Trim());
                }
            }

            if (Klient.Aufenthalt != null)
                if(Klient.Aufenthalt.Gruppenkennzahl != txtgruppenkennzahl.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Gruppenkennzahl: ") + Klient.Aufenthalt.Gruppenkennzahl + " -> " + txtgruppenkennzahl.Text.Trim());
                    Klient.Aufenthalt.Gruppenkennzahl = txtgruppenkennzahl.Text.Trim();
                }

            if(Klient.Klientennummer != txtKliNr.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientennummer: ") + Klient.Klientennummer + " -> " + txtKliNr.Text.Trim());
                Klient.Klientennummer = txtKliNr.Text.Trim();
            }


            if (Klient.AufenthaltZusatz.Count > 0)
                if (Klient.AufenthaltZusatz[0].Zimmernummer != txtZimmerNr.Text.Trim())
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Zimmernummer: ") + Klient.AufenthaltZusatz[0].Zimmernummer + " -> " + txtZimmerNr.Text.Trim());
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
                    Klient.Geburtsdatum = gebDatum.Value;
                }
            }

            if(Klient.LedigerName != txtGebName.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsname: ") + Klient.LedigerName + " -> " + txtGebName.Text.Trim());
                Klient.LedigerName = txtGebName.Text.Trim();
            }

            if(Klient.Sexus != cmbSexus.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geschlecht: ") + Klient.Sexus + " -> " + cmbSexus.Text.Trim());
                Klient.Sexus = cmbSexus.Text.Trim();
            }

            if(Klient.Geburtsort != txtGebOrt.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsort: ") + Klient.Geburtsort + " -> " + txtGebOrt.Text.Trim());
                Klient.Geburtsort = txtGebOrt.Text.Trim();
            }

            if (Klient.Familienstand != cmbFAM.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Familienstand: ") + Klient.Familienstand + " -> " + cmbFAM.Text.Trim());
                Klient.Familienstand = cmbFAM.Text.Trim();
            }

            if (Klient.Staatsb != cmbStaatsB.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsbürgerschaft: ") + Klient.Staatsb + " -> " + cmbStaatsB.Text.Trim());
                Klient.Staatsb = cmbStaatsB.Text.Trim();
            }

            if (Klient.Konfision != cmbKonfession.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfession: ") + Klient.Konfision + " -> " + cmbKonfession.Text.Trim());
                Klient.Konfision = cmbKonfession.Text.Trim();
            }

            if (Klient.ErlernterBeruf != txtBeruf.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlernter Beruf: ") + Klient.ErlernterBeruf + " -> " + txtBeruf.Text.Trim());
                Klient.ErlernterBeruf = txtBeruf.Text.Trim();
            }

            if (Klient.Verstorben != chkVerstorben.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Verstorben: ") + (Klient.Verstorben ? sJa : sNein) + " -> " + (chkVerstorben.Checked ? sJa : sNein));
                Klient.Verstorben = chkVerstorben.Checked;
            }

            if (Klient.Todeszeitpunkt != dteTodeszeitpunkt.Value)
            {
                string strTodeszeitpunkt = "";
                if (Klient.Todeszeitpunkt != null)
                    strTodeszeitpunkt = ((DateTime)Klient.Todeszeitpunkt).ToString("dd.MM.yyyy");

                string strTodeszeitpunktNeu = "";
                if (Klient.Todeszeitpunkt != null)
                    strTodeszeitpunktNeu = ((DateTime)dteTodeszeitpunkt.Value).ToString("dd.MM.yyyy");
                if (strTodeszeitpunkt != strTodeszeitpunktNeu)
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Todeszeitpunkt: ") + strTodeszeitpunkt + " -> " + strTodeszeitpunktNeu);
                    Klient.Todeszeitpunkt = dteTodeszeitpunkt.Value;
                }
            }

            if (Klient.DNR != chkDNR.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR: ") + (Klient.DNR ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja"): QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein")) + " -> " + (chkDNR.Checked ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein")));
                Klient.DNR = chkDNR.Checked;
            }

            //Personenbeschreibung
            if (txtGroesse.Text.Trim() != "")
                if(Klient.Groesse != Convert.ToInt32(txtGroesse.Text.Trim()))
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Größe: ") + Klient.Groesse.ToString() + " -> " + txtGroesse.Text.Trim());
                    Klient.Groesse = Convert.ToInt32(txtGroesse.Text.Trim());
                }

            if (txtGewicht.Text.Trim() != "" && Klient.Aufenthalt != null)
                if (Klient.Aufenthalt.Gewicht != Convert.ToDouble(txtGewicht.Text.Trim()))
                {
                    sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Gewicht: ") + Klient.Aufenthalt.Gewicht.ToString() + " -> " + txtGewicht.Text.Trim());
                    Klient.Aufenthalt.Gewicht = Convert.ToDouble(txtGewicht.Text.Trim());
                }

            if (Klient.Augenfarbe != cmbAugenFarbe.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Größe: ") + Klient.Augenfarbe + " -> " + cmbAugenFarbe.Text.Trim());
                Klient.Augenfarbe = cmbAugenFarbe.Text.Trim();
            }

            if (Klient.Haarfarbe != cmbHaarFarbe.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Haarfarbe: ") + Klient.Haarfarbe + " -> " + cmbHaarFarbe.Text.Trim());
                Klient.Haarfarbe = cmbHaarFarbe.Text.Trim();
            }

            Klient.Foto = SetFoto();

            if (Klient.Statur != cmbstatur.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Statur: ") + Klient.Statur + " -> " + cmbstatur.Text.Trim());
                Klient.Statur = cmbstatur.Text.Trim();
            }

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
                    Klient.Namenstag = Namenstag.Value;
                }
            }


            if (Klient.Kosename != txtKosename.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kosename: ") + Klient.Kosename + " -> " + txtKosename.Text.Trim());
                Klient.Kosename = txtKosename.Text.Trim();
            }

            if (Klient.BesondereAeusserlicheKennzeichen != txtBesKennz.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Bes. Kennzeichen: ") + Klient.BesondereAeusserlicheKennzeichen + " -> " + txtBesKennz.Text.Trim());
                Klient.BesondereAeusserlicheKennzeichen = txtBesKennz.Text.Trim();
            }

            if (Klient.Initialberuehrung != txtInitialBer.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Initialberührung: ") + Klient.Initialberuehrung + " -> " + txtInitialBer.Text.Trim());
                Klient.Initialberuehrung = txtInitialBer.Text.Trim();
            }

            if(Klient.Kennwort != txtKennwort.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Kennwort: ") + Klient.Kennwort + " -> " + txtKennwort.Text.Trim());
                Klient.Kennwort = txtKennwort.Text.Trim();
            }
            
            if (Klient.Milieubetreuung != chkMilieubetreuung.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Milieubetreuung: ") + (Klient.Milieubetreuung ? sJa : sNein) + " -> " + (chkMilieubetreuung.Checked ? sJa : sNein));
                Klient.Milieubetreuung = chkMilieubetreuung.Checked;
            }

            if (Klient.KZUeberlebender != chkKZUeberlebender.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("KZ-Überlebender: ") + (Klient.KZUeberlebender ? sJa : sNein) + " -> " + (chkKZUeberlebender.Checked ? sJa : sNein));
                Klient.KZUeberlebender = chkKZUeberlebender.Checked;
            }

            if (Klient.Anatomie != chkAnatomie.Checked)
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anatomie: ") + (Klient.Anatomie ? sJa : sNein) + " -> " + (chkAnatomie.Checked ? sJa :sNein));
                Klient.Anatomie = chkAnatomie.Checked;
            }

            if (Klient.Besonderheit != txtBesonderheit.Text.Trim())
            {
                sbChanges.Append("\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen zur Übergabe wurden geändert."));
//                sbChanges.Append("\r\n" + "Besonderheit: " + txtBesonderheit.Text.Trim());
                Klient.Besonderheit = this.txtBesonderheit.Text.Trim();
            }

            //------------------- Pflegeeinträge schreiben
            if (sbChanges.ToString().Trim() != "")
            {
                if (Klient.Aufenthalt.IDAbteilung != Guid.Empty && Klient.Aufenthalt.IDBereich != Guid.Empty)
                    WriteDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientendaten wurden editiert.") + "\n\r" + sbChanges.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"));
            }

            //----------------------------------------------------
            //              Kontakte
            //----------------------------------------------------
            ucKontaktPersonen1.UpdateDATA();

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

                db.SaveChanges();
            }


            ucBewerbungsdaten1.UpdateDATA();

            if (ucAbrechAufenthKlient1 != null)
                ucAbrechAufenthKlient1.UpdateDATA();

            //this.loadPatientenverfügung();
        }
        public void Write()
        {
            this.Klient.Write(this._mainSystem, this._isAbrechnung, this._isBewerberJN);
        }
        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // txtNachname
            GuiUtil.ValidateField(txtNachname, (txtNachname.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // txtVorname
            GuiUtil.ValidateField(txtVorname, (txtVorname.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // cmbSexus
            GuiUtil.ValidateField(cmbSexus, (cmbSexus.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // dtpGebDatum
            GuiUtil.ValidateField(gebDatum, (gebDatum.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // Erstkontakt
            //GuiUtil.ValidateField(cmbBenutzer, (cmbBenutzer.Text.Length > 0),
            //    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (txtFallzahl.Text.Trim() != "")
            {
                GuiUtil.ValidateField(txtFallzahl, KlientGuiAction.IsDouble(txtFallzahl.Text.Trim()),
                    ENV.String("GUI.E_FLOAT_OUTOFRANGE", double.MinValue, double.MaxValue), ref bError, bInfo, errorProvider1);
            }

            //Grösse
            if (txtGroesse.Text.Trim() != "")
            {
                GuiUtil.ValidateField(txtGroesse, KlientGuiAction.IsInteger(txtGroesse.Text.Trim()),
                    ENV.String("GUI.E_FLOAT_OUTOFRANGE", int.MinValue, int.MaxValue), ref bError, bInfo, errorProvider1);
            }

            //Gewicht
            if (txtGewicht.Text.Trim() != "")
            {
                GuiUtil.ValidateField(txtGewicht, KlientGuiAction.IsDouble(txtGewicht.Text.Trim()),
                    ENV.String("GUI.E_FLOAT_OUTOFRANGE", double.MinValue, double.MaxValue), ref bError, bInfo, errorProvider1);
            }

            if (!bError)
                if (ucAbrechAufenthKlient1 != null)
                    bError = !this.ucAbrechAufenthKlient1.ValidateFields();

            return !bError;
        }

        //Errorprovider initialisieren
        private void InitFields()
        {
            errorProvider1.SetError(txtNachname, "");
            errorProvider1.SetError(txtVorname, "");
            errorProvider1.SetError(cmbSexus, "");
            errorProvider1.SetError(gebDatum, "");
            //errorProvider1.SetError(cmbBenutzer, "");
            errorProvider1.SetError(txtFallzahl, "");
            errorProvider1.SetError(txtGroesse, "");
            errorProvider1.SetError(txtGewicht, "");
        }


        private void WriteDekurs(string sText, string PflegeplanText)
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db, sText, DateTime.Now, null, Klient.Aufenthalt.IDBereich,
                                                            Klient.Aufenthalt.ID, null, PflegeEintragTyp.DEKURS,
                                                            Klient.Aufenthalt.IDAbteilung, null, PflegeplanText);
                db.SaveChanges();
            }

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

                Klient.CLASS_AERZTE.NewPatientAerzte(frm.CurrentArztRow.ID);
                KlientGuiAction.RefreshListPatientAerzte(gridAerzte, Klient);

                //HL_AddPE_KontaktPatient_06
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Contact added for patient {0}");
                string txt = "";
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdress = b.getAdresse(frm.CurrentArztRow.IDAdresse, db);
                    PMDS.db.Entities.Kontakt rKontakt = b.getKontakt(frm.CurrentArztRow.IDKontakt, db);
                    txt += "Name: " + frm.CurrentArztRow.Nachname.Trim() + " " + frm.CurrentArztRow.Vorname.Trim() + "\r\n";
                    txt += "Adress: " + rAdress.Plz.Trim() + " " + rAdress.Ort.Trim() + ", " + rAdress.Strasse.Trim() + "\r\n";
                    txt += "E-Mail: " + rKontakt.Email.Trim();
                    KlientGuiAction.addKontakteChanged(title, txt);
                }

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
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Contact changed for patient {0}");
                string txt = "";
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Adresse rAdress = b.getAdresse(row.IDAdresse, db);
                    PMDS.db.Entities.Kontakt rKontakt = b.getKontakt(row.IDKontakt, db);
                    txt += "Name: " + row.Nachname.Trim() + " " + row.Vorname.Trim() + "\r\n";
                    txt += "Adress: " + rAdress.Plz.Trim() + " " + rAdress.Ort.Trim() + ", " + rAdress.Strasse.Trim() + "\r\n";
                    txt += "E-Mail: " + rKontakt.Email.Trim();
                    KlientGuiAction.addKontakteChanged(title, txt);
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

        private Image GetFoto(byte[] buffer)
        {
            if (buffer != null && buffer.Length != 0)
                return BUtil.ImageFromArray(buffer);
            else
                return null;
        }

        private byte[] SetFoto()
        {
            if (foto.Image != null)
            {
                return BUtil.ImageToArray((Image)foto.Image);
            }
            return null;
        }

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
            if (PMDS.Global.historie.HistorieOn) return;

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

        private void btnPicLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ImageName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(Directory.GetParent(openFileDialog1.FileName).FullName.ToString());
                Image = Image.FromFile(openFileDialog1.FileName);
                ImageName = openFileDialog1.FileName;

                this.MainWindow.PictureHasChanged = true;
            }
        }

        private void btnPicSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = ImageName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image.Save(saveFileDialog1.FileName);
                ValueChanged(sender, e);
            }
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

        private void btnPicClear2_Click(object sender, EventArgs e)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sind Sie sicher, dass Sie das Bild löschen wollen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ImageName = "";
                    Image = null;
                    this.MainWindow.PictureHasChanged = true;
                }

            }
            catch(Exception ex)
            {
                ENV.HandleException(ex);
            }
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

        private void btnMagnify_Click(object sender, EventArgs e)
        {
           try
            {
                PMDS.Global.UI.frmPictureViewer frm = new PMDS.Global.UI.frmPictureViewer();
                frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bild von ") + Klient.Nachname + " " + Klient.Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(", geb. am ") + string.Format("{0:d}", Klient.Geburtsdatum);
                MemoryStream ms = new MemoryStream(Klient.Foto);
                Image returnImage = Image.FromStream(ms);
                frm.pictureBox1.Image = returnImage;
                frm.Show(this);


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
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

    }

}
