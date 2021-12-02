using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{
    public partial class ucRezeptEintrag : QS2.Desktop.ControlManagment.BaseControl
    {

        private DateTime dtStartAction;
        private PMDS.BusinessLogic.Medikament _medikament = new PMDS.BusinessLogic.Medikament();
        private dsRezeptEintrag.RezeptEintragRow _RezeptEintrag;
        private DateTime _ausstellungsDatum = DateTime.MinValue;
        private bool _ValueChangedEnabled = true;
        private bool _bHerrichtenBedarf;
        private BearbeitungsModus _bearbeitungsmodus = BearbeitungsModus.neu;
        
        private dsRezeptEintrag.RezeptEintragRow _newRezeptEintrag;          // != null ==> nachfolgeprozess muss den neuen Eintrag nehmen und verarbeiten
        
        private bool _UpdateGuiInProgress;
        private object temp_dtpAbgebenVon_Value;

        private PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();
        public bool bIsStorno { get; set; }

        private DateTime dtFrom;
        private DateTime dtBis;
        private DateTime dtInfinity = new DateTime(3000, 1, 1, 23, 59, 59);

        public ucRezeptEintrag()
        {
            InitializeComponent();

            RequiredFields();
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (generic.sEquals(ENV.MedikamenteImportType, "service"))
                    {
                        this.cbPackungsEinheit.Group = "AEH";
                    }
                }

                if (ENV.RezeptUseTimeOfDay)
                {
                    dtpAbgebenVon.MaskInput = "dd.mm.yyyy hh:mm:ss";
                    dtpAbgebenVon.Size = new Size(145, 21);
                    dtStartAction = DateTime.Now;
                    dtFrom = DateTime.Now;
                    lblTagesbeginn.Visible = false;

                    dtpAbgebenBis.MaskInput = "dd.mm.yyyy hh:mm:ss";
                    dtpAbgebenBis.Size = new Size(145, 21);
                    lblTagesende.Visible = false;
                }
                else
                {
                    dtpAbgebenVon.MaskInput = "dd.mm.yyyy";
                    dtpAbgebenVon.Size = new Size(90, 21);
                    dtStartAction = DateTime.Now.Date;
                    dtFrom = DateTime.Now.Date;
                    lblTagesbeginn.Visible = true;

                    dtpAbgebenBis.MaskInput = "dd.mm.yyyy";
                    dtpAbgebenBis.Size = new Size(90, 21);
                    lblTagesende.Visible = false;
                }

                this.cbImportant._SupressLevelHierarchie = PMDSBusinessUI.SupressLevelHierarchieActiveInUI;
                this.cbImportant.Group = "BER";
                this.cbImportant.RefreshList();

                PMDS.BusinessLogic.Medikament _medikament = new PMDS.BusinessLogic.Medikament();
                //InitCmbMedikament(true);
                this.txtMedikament.Text = "";
                cmbHerrichten.Text = "";
                cmbVerabreichungsart.Text = "";
                zp0.Visible = false;
                cbBis.Checked = false;

                //os191220
                dtpAbgebenVon.DateTime = dtFrom;

                this.PMDSBusinessUI1.loadCboPackungsanzahl((Infragistics.Win.UltraWinEditors.UltraComboEditor)this.cbPackungsanzahl, null);
            }

            this.btnSearchMedikament.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Legt den Bearbeitungsmodus fest
        /// </summary>
        //----------------------------------------------------------------------------
        public BearbeitungsModus EintragBearbeitungsmodus
        {
            get { return _bearbeitungsmodus; }
            set { _bearbeitungsmodus = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn != null ==> es fand eine Änderung statt bei der der alte Eintrag 
        /// unverändert bleibt (nur das bis Datum wird gesetzt) und der neue in dieser Eigenschaft verspeichert wird
        /// Das tritt bei Änderung der Medikation auf
        /// </summary>
        //----------------------------------------------------------------------------
        public dsRezeptEintrag.RezeptEintragRow NewRezeptEintrag
        {
            get { return _newRezeptEintrag; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsRezeptEintrag.RezeptEintragRow RezeptEintrag
        {
            get { return _RezeptEintrag; }
            set
            {
                _RezeptEintrag = value;
                ucStandardZeiten1.RezeptEintrag = value;
                _ValueChangedEnabled = false;
                UpdateGUI();
                _ValueChangedEnabled = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Rezept Ausstellungsdatum setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Ausstellungsdatum
        {
            get { return _ausstellungsDatum; }
            set { _ausstellungsDatum = value; }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateGUI()
        {
            if (RezeptEintrag == null)
                return;
            
            InitAerzte();
            this.InitAerzteAbgesetzt();

            if (_bearbeitungsmodus == BearbeitungsModus.neu)
            {
                userCombo1.Value = ENV.USERID;
                cbBis.Checked = false;
                cbBis_CheckedChanged(this, EventArgs.Empty);
                return;
            }

            _UpdateGuiInProgress = true;

            this.txtMedikament.Enabled = false;
            userCombo1.Value = RezeptEintrag.IDBenutzer_Geaendert == Guid.Empty ? ENV.USERID : RezeptEintrag.IDBenutzer_Geaendert;
            txtRezeptDaten.Text = RezeptEintrag.Rezeptdaten;
            this.txtMedikament.Tag  = RezeptEintrag.IDMedikament;
            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            if (RezeptEintrag.IDMedikament != Guid.Empty)
            {
                this.btnSearchMedikament.Visible = false;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Medikament rMedikament = PMDSBusiness1.GetMedikament(db, RezeptEintrag.IDMedikament);
                    this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();
                    this.pnlPackungBeschreibung.Enabled = !rMedikament.Importiert;
                }
            }
            else
            {
                this.btnSearchMedikament.Visible = true;
                this.txtMedikament.Text = "";
            }

            dtpAbgebenVon.Value = RezeptEintrag.AbzugebenVon; 
            temp_dtpAbgebenVon_Value = RezeptEintrag.AbzugebenVon;
            cmbApplikationsform.Text = RezeptEintrag.Applikationsform.Trim();
            txtPackGr.Value = RezeptEintrag.IsPackunggroesseNull() ? (object)DBNull.Value : (object)RezeptEintrag.Packunggroesse;
            cbPackungsEinheit.Text = RezeptEintrag.Packungeinheit.Trim();
            opWiederholungstyp.CheckedIndex = RezeptEintrag.Wiederholungstyp;
            ucWochenTage21.WOCHENTAGE = RezeptEintrag.Wochentage;
            opWiederholungstyp.Items[0].DisplayText = getWiederholungstypText();
            txtWiedWertAlle.Text = "";
            txtWiedWertJeden.Text = "";
            cmbEinheit.Text = RezeptEintrag.Einheit.Trim();
            cbBeaufsichtigungJN.Checked = RezeptEintrag.BeaufsichtigungJN;
            this.chkHAGPflichtigJN.Checked = RezeptEintrag.HAGPflichtigJN;

            txtAnmerkung.Text = RezeptEintrag.Bemerkung.Trim();

            cbBis.Checked = (RezeptEintrag.AbzugebenBis < dtInfinity);
            //os191220
            if (ENV.RezeptUseTimeOfDay)
                dtpAbgebenBis.Value = RezeptEintrag.AbzugebenBis;
            else
                dtpAbgebenBis.Value = RezeptEintrag.AbzugebenBis.Date.Add(new TimeSpan(23, 59, 59));
            
            dtpAbgebenBis.Visible = cbBis.Checked;
            lblTagesende.Visible = cbBis.Checked && !ENV.RezeptUseTimeOfDay;

            if (RezeptEintrag.Wiederholungstyp == (int)medWiederholungstypen.alle_x_Tage_Wochen)
            {
                txtWiedWertAlle.Value = RezeptEintrag.Wiederholungswert;
                opWiedheinheit.Value = RezeptEintrag.Wiederholungseinheit;
            }
            else if (RezeptEintrag.Wiederholungstyp == (int)medWiederholungstypen.jeden_xten_desMonat)
            {
                txtWiedWertJeden.Value = RezeptEintrag.Wiederholungswert;
            }
            else if (RezeptEintrag.Wiederholungstyp == (int)medWiederholungstypen.taeglich && RezeptEintrag.Wochentage == 0)
            {
                ucWochenTage21.WOCHENTAGE = 127;
            }

            bool bzp0 = RezeptEintrag.ZP0 != 0;
            zp0.Value = bzp0 ? (object)(RezeptEintrag.ZP0) : (object)(DBNull.Value);
            zp0.Visible = bzp0;
            cbNuechtern.Checked = bzp0;

            zp1.Value = RezeptEintrag.ZP1 != 0 ? (object)RezeptEintrag.ZP1 : (object)DBNull.Value;
            zp2.Value = RezeptEintrag.ZP2 != 0 ? (object)RezeptEintrag.ZP2 : (object)DBNull.Value;
            zp3.Value = RezeptEintrag.ZP3 != 0 ? (object)RezeptEintrag.ZP3 : (object)DBNull.Value;
            zp4.Value = RezeptEintrag.ZP4 != 0 ? (object)RezeptEintrag.ZP4 : (object)DBNull.Value;

            if (RezeptEintrag.IDMedikament != Guid.Empty)
            {
                cmbHerrichten.SelectedIndex = RezeptEintrag.Herrichten;
                cmbVerabreichungsart.SelectedIndex = RezeptEintrag.Verabreichungsart;
            }

            cbPackungsanzahl.Value = RezeptEintrag.Packungsanzahl;
            this.InitAerzteAbgesetzt();

            _UpdateGuiInProgress = false;
        }

        private void InitAerzte()
        {
            try
            {
                Aufenthalt a = new Aufenthalt(RezeptEintrag.IDAufenthalt);
                ucPatientAerzte1.IDPatient = a.IDPatient;

                if (RezeptEintrag.IDAerzte != Guid.Empty)
                {
                    bool bArztFound = false;
                    foreach (Infragistics.Win.ValueListItem itm in ucPatientAerzte1.cmbArzt.Items)
                    {
                        if (itm.DataValue.Equals(RezeptEintrag.IDAerzte))
                        {
                            bArztFound = true;
                        }
                    }
                    if (!bArztFound)
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Aerzte rAerzte = PMDSBusiness1.getArzt(RezeptEintrag.IDAerzte, db);
                            ucPatientAerzte1.cmbArzt.Items.Add(rAerzte.ID, rAerzte.Nachname.Trim() + " " + rAerzte.Vorname.Trim());
                        }
                    }
                }

                ucPatientAerzte1.SelctedIDAerzte = RezeptEintrag.IDAerzte;
                if (RezeptEintrag.IDAerzte == Guid.Empty)
                {
                    PMDS.db.Entities.Benutzer rUsr = null;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    rUsr = PMDSBusiness1.LogggedOnUser();
                    dsGUIDListe ds = new PMDS.BusinessLogic.Aerzte().ALLAKTIVEPATIENTHAUSAERZTEBYPatient(a.IDPatient);
                    foreach (dsGUIDListe.IDListeRow r in ds.IDListe)
                    {
                        Guid IDArztFound = ((Guid)r["ID"]);
                        if (IDArztFound == rUsr.IDArzt)
                        {
                            this.ucPatientAerzte1.SelctedIDAerzte = IDArztFound;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("InitAerzte: " + ex.ToString());
            }
        }

        private void InitAerzteAbgesetzt()
        {
            PMDS.GUI.ucSiteMapPMDS ucSiteMapPMDS1 = new ucSiteMapPMDS();
            this.cboAerzteAbgesetzt.Items.Clear();
            ucSiteMapPMDS1.getAllÄrzte((Infragistics.Win.UltraWinEditors.UltraComboEditor)this.cboAerzteAbgesetzt, true, ENV.CurrentIDPatient);
            if (this.RezeptEintrag.AbzugebenBis.Year != 3000)
            {
                this.cboAerzteAbgesetzt.Visible = true;
                this.lblArztAbgesetzt.Visible = true;
                if (RezeptEintrag.IsIDArztAbgesetztNull())
                {
                    this.cboAerzteAbgesetzt.Value = null;
                }
                else
                {
                    this.cboAerzteAbgesetzt.Value = RezeptEintrag.IDArztAbgesetzt;  
                }
            }
            else
            {
                this.cboAerzteAbgesetzt.Visible = false;
                this.lblArztAbgesetzt.Visible = false;
                this.cboAerzteAbgesetzt.Value = null;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn sich was geändert hat
        /// Eine Änderung hat ein absetzen des alten und ein beginnen einer neuen 
        /// Medikation zur Folge
        /// </summary>
        //----------------------------------------------------------------------------
        private bool DetailsChanged
        {
           
            get
            {
                //if (RezeptEintrag.RowState == DataRowState.Added)
                //    return false;

                double dzp0; if (zp0.Value == DBNull.Value) dzp0 = 0; else dzp0 = Convert.ToDouble(zp0.Value);
                double dzp1; if (zp1.Value == DBNull.Value) dzp1 = 0; else dzp1 = Convert.ToDouble(zp1.Value);
                double dzp2; if (zp2.Value == DBNull.Value) dzp2 = 0; else dzp2 = Convert.ToDouble(zp2.Value);
                double dzp3; if (zp3.Value == DBNull.Value) dzp3 = 0; else dzp3 = Convert.ToDouble(zp3.Value);
                double dzp4; if (zp4.Value == DBNull.Value) dzp4 = 0; else dzp4 = Convert.ToDouble(zp4.Value);
                double dwiederholwert; if (txtWiedWertAlle.Value == DBNull.Value) dwiederholwert = 0; else dwiederholwert = Convert.ToDouble(txtWiedWertAlle.Value);

                bool bIDArztAbgesetztChanged = false;
                if (RezeptEintrag.IsIDArztAbgesetztNull())
                {
                    if (this.cboAerzteAbgesetzt.Value != null)
                    {
                        bIDArztAbgesetztChanged = true; 
                    }
                }
                else
                {
                    if (this.cboAerzteAbgesetzt.Value != null)
                    {
                        if (RezeptEintrag.IDArztAbgesetzt != (Guid)this.cboAerzteAbgesetzt.Value)
                        {
                            bIDArztAbgesetztChanged = true;
                        }
                    }
                }
                
                bool bRezeptDetailschanged =
                (
                    //os191202
                    RezeptEintrag.AbzugebenVon != dtpAbgebenVon.DateTime ||  // {{{Eng}}} 7.7.2009
                    //RezeptEintrag.AbzugebenVon != dtpAbgebenVon.DateTime.Date ||  // {{{Eng}}} 7.7.2009
                    //RezeptEintrag.AbzugebenBis != dtpAbgebenBis.DateTime.Date ||   // {{{Eng}}} 7.7.2009
                    RezeptEintrag.Wochentage != ucWochenTage21.WOCHENTAGE ||
                    RezeptEintrag.Applikationsform.Trim() != cmbApplikationsform.Text ||
                    RezeptEintrag.Wiederholungstyp != (int)opWiederholungstyp.Value ||
                    RezeptEintrag.Wiederholungswert != dwiederholwert ||
                    RezeptEintrag.Wiederholungseinheit != (int)opWiedheinheit.Value ||
                    
                    RezeptEintrag.BeaufsichtigungJN != cbBeaufsichtigungJN.Checked ||
                    RezeptEintrag.HAGPflichtigJN != chkHAGPflichtigJN.Checked ||
                    RezeptEintrag.ZP0 != dzp0 ||
                    RezeptEintrag.ZP1 != dzp1 ||
                    RezeptEintrag.ZP2 != dzp2 ||
                    RezeptEintrag.ZP3 != dzp3 ||
                    RezeptEintrag.ZP4 != dzp4 ||
                    RezeptEintrag.IDAerzte != ucPatientAerzte1.SelctedIDAerzte ||
                    bIDArztAbgesetztChanged ||
                    //Zusätzliche Prüfung ab 27.7.2018
                    RezeptEintrag.Herrichten != cmbHerrichten.SelectedIndex ||
                    RezeptEintrag.Verabreichungsart != cmbVerabreichungsart.SelectedIndex ||
                    RezeptEintrag.Bemerkung.Trim() != txtAnmerkung.Text.Trim() ||
                    RezeptEintrag.Rezeptdaten.Trim() != txtRezeptDaten.Text.Trim()
                    //chkGegenzeichnen
                 );
                 
                return bRezeptDetailschanged;

            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn sich was geändert hat
        /// </summary>
        //----------------------------------------------------------------------------
        private bool BedarfChange
        {
            get
            {
                bool bbeiBedarfNeuerDatensatz;
                if (
                    ((int)cmbHerrichten.Value != (int)medHerrichten.beiBedarf && (int)RezeptEintrag.Herrichten == (int)medHerrichten.beiBedarf)
                    || ((int)cmbHerrichten.Value == (int)medHerrichten.beiBedarf && (int)RezeptEintrag.Herrichten != (int)medHerrichten.beiBedarf)
                    )
                    bbeiBedarfNeuerDatensatz = true;
                else bbeiBedarfNeuerDatensatz = false;

                return bbeiBedarfNeuerDatensatz;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI nach Daten übertragen
        /// herrichten Änderung bewirkt keinen neuen Datensatz, außer wenn von Bedarfsmedikation auf normale gewechselt wird oder umgekehrt
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateDATA()
        {
            dsRezeptEintrag.RezeptEintragRow rToUpdate = RezeptEintrag;
            //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(EintragBearbeitungsmodus.ToString());
            if ((!(EintragBearbeitungsmodus == BearbeitungsModus.neu)) && (BedarfChange || DetailsChanged))         // einen neuen DS erzeugen und das alte bis Datum setzen
            {
                if (this.cbBis.Checked)         //Beim Absetzen den bestehenden Datensatz verändern
                {
                    //os191220
                    if (ENV.RezeptUseTimeOfDay)
                        RezeptEintrag.AbzugebenBis = dtpAbgebenBis.DateTime;
                    else
                        RezeptEintrag.AbzugebenBis = dtpAbgebenBis.DateTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    RezeptEintrag.IDArztAbgesetzt = this.ucPatientAerzte1.SelctedIDAerzte;
                    RezeptEintrag.DatumGeaendert = DateTime.Now;
                    RezeptEintrag.IDBenutzer_Geaendert = ENV.USERID;
                }
                else                            //Bei Änderung der Dosierung neuen Datensatz anlegen und bestehenden beenden.
                {
                    using (dsRezeptEintrag.RezeptEintragDataTable dt = new dsRezeptEintrag.RezeptEintragDataTable())
                    {
                        _newRezeptEintrag = (dsRezeptEintrag.RezeptEintragRow)dt.Rows.Add(RezeptEintrag.ItemArray);
                    }
                    rToUpdate = _newRezeptEintrag;
                    _newRezeptEintrag.ID = Guid.NewGuid();

                    //os191220
                    //Das bis Datum des alten Datensatzes manipulieren
                    if (ENV.RezeptUseTimeOfDay)
                    {
                        if (RezeptEintrag.AbzugebenVon > dtpAbgebenVon.DateTime)
                            RezeptEintrag.AbzugebenBis = dtpAbgebenVon.DateTime.Date;
                        else
                            RezeptEintrag.AbzugebenBis = dtpAbgebenVon.DateTime;
                    }
                    else
                    {
                        if (RezeptEintrag.AbzugebenVon > dtpAbgebenVon.DateTime.Date.AddDays(-1))
                            RezeptEintrag.AbzugebenBis = dtpAbgebenVon.DateTime.Date;
                        else
                            RezeptEintrag.AbzugebenBis = dtpAbgebenVon.DateTime.Date.AddSeconds(-1);                        
                    }

                    RezeptEintrag.IDArztAbgesetzt = this.ucPatientAerzte1.SelctedIDAerzte;
                    RezeptEintrag.DatumGeaendert = DateTime.Now;
                    RezeptEintrag.IDBenutzer_Geaendert = ENV.USERID;

                    // damit nicht der alte überschrieben wird
                    ucStandardZeiten1.BkeepStandardzeiten = true;
                    ucStandardZeiten1.RezeptEintrag = _newRezeptEintrag;
                }


            }

            TransferDataToRow(rToUpdate);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ransferiert die GUI Daten in die Row
        /// </summary>
        //----------------------------------------------------------------------------
        private void TransferDataToRow(dsRezeptEintrag.RezeptEintragRow row)
        {
            //os191220
            //TimeSpan ts = new TimeSpan(23,59,59);
            //row.AbzugebenBis = dtpAbgebenBis.DateTime.Date.Add(ts);

            //row.AbzugebenBis = dtpAbgebenBis.DateTime.Date;

            row.IDMedikament = (Guid)this.txtMedikament.Tag;

            //os191202
            row.AbzugebenVon = dtpAbgebenVon.DateTime;
            row.AbzugebenBis = dtpAbgebenBis.DateTime;
            row.Applikationsform = cmbApplikationsform.Text.Trim();
            row.Packungeinheit = cbPackungsEinheit.Text;
            row.Wochentage = ucWochenTage21.WOCHENTAGE;
            row.Einheit = cmbEinheit.Text.Trim();
            row.BeaufsichtigungJN = cbBeaufsichtigungJN.Checked;
            row.HAGPflichtigJN = this.chkHAGPflichtigJN.Checked;
            row.Herrichten = (int)cmbHerrichten.Value;
            row.Verabreichungsart = (int)cmbVerabreichungsart.Value;
            row.Bemerkung = txtAnmerkung.Text.Trim();
            row.Rezeptdaten = txtRezeptDaten.Text.Trim();
            row.IDAerzte = ucPatientAerzte1.SelctedIDAerzte;
            if (this.cboAerzteAbgesetzt.Value != null)
            {
                row.IDArztAbgesetzt = (Guid)this.cboAerzteAbgesetzt.Value;
            }
            else
            {
                row.SetIDArztAbgesetztNull();
            }

            row.IDBenutzer_Geaendert = (Guid)userCombo1.Value;
            if (EintragBearbeitungsmodus == BearbeitungsModus.neu)
                row.IDBenutzer_Erstellt = (Guid)userCombo1.Value;

            if (txtPackGr.Value != DBNull.Value)
                row.Packunggroesse = Convert.ToDouble(txtPackGr.Value);
            else
                row.SetPackunggroesseNull();

            if (opWiederholungstyp.Value != null)
            {
                row.Wiederholungstyp = (int)opWiederholungstyp.Value;

                if ((int)opWiederholungstyp.Value == (int)medWiederholungstypen.alle_x_Tage_Wochen)
                    row.Wiederholungswert = Convert.ToDouble(txtWiedWertAlle.Value);
                if ((int)opWiederholungstyp.Value == (int)medWiederholungstypen.jeden_xten_desMonat)
                    row.Wiederholungswert = Convert.ToDouble(txtWiedWertJeden.Value);

                if ((int)opWiederholungstyp.Value == (int)medWiederholungstypen.alle_x_Tage_Wochen)
                    row.Wiederholungseinheit = (int)opWiedheinheit.Value;
                else
                    row.Wiederholungseinheit = 0;
            }

            ucStandardZeiten1.UpdateDATA();

            row.ZP0 = zp0.Value != DBNull.Value ? Convert.ToDouble(zp0.Value) : 0.0;
            row.ZP1 = zp1.Value != DBNull.Value ? Convert.ToDouble(zp1.Value) : 0.0;
            row.ZP2 = zp2.Value != DBNull.Value ? Convert.ToDouble(zp2.Value) : 0.0;
            row.ZP3 = zp3.Value != DBNull.Value ? Convert.ToDouble(zp3.Value) : 0.0;
            row.ZP4 = zp4.Value != DBNull.Value ? Convert.ToDouble(zp4.Value) : 0.0;

            if (cmbHerrichten.Value != DBNull.Value && (int)cmbHerrichten.Value == (int)medHerrichten.beiBedarf)
                row.BedarfsMedikationJN = true;
            else
                row.BedarfsMedikationJN = false;

            row.DosierungASString = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow(row);
            if (cbPackungsanzahl.Value != null)
            {
                row.Packungsanzahl = (int)cbPackungsanzahl.Value;
            }
            else
            {
                row.Packungsanzahl = 0;
            }

            row.DatumGeaendert = DateTime.Now;
            row.IDBenutzer_Geaendert = ENV.USERID;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;
            this.errorProvider1.SetError(this.cmbApplikationsform, "");

            bIsStorno = false;
            bool bRechtStorno = ENV.adminSecure || (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.RezepteintragLöschen) && ENV.lic_RezepteintragStorno);

            int diff = (int) (this.RezeptEintrag.AbzugebenVon - dtpAbgebenBis.DateTime).TotalSeconds;
            //TimeSpan diff = this.RezeptEintrag.AbzugebenVon - dtpAbgebenBis.DateTime.Date.AddDays(1).AddSeconds(-1);
            //this.cmbApplikationsform.Appearance.BackColor = Color.White;

            if (this.txtMedikament.Tag == null)
            {
                string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament: Auswahl erforderlich!"); 
                this.errorProvider1.SetError(this.txtMedikament, sText);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                return false;
            }

            if ((System.Guid)this.txtMedikament.Tag == System.Guid.Empty)
            {
                string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament: Auswahl erforderlich!");
                this.errorProvider1.SetError(this.txtMedikament, sText);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                return false;
            }


            //os191202
            if (this.EintragBearbeitungsmodus == BearbeitungsModus.edit)
            {
                if (dtpAbgebenVon.Value == null)
                {
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Von-Datum darf nicht leer sein.");
                    this.errorProvider1.SetError(this.dtpAbgebenVon, sText);
                    return false;
                }

                if (dtpAbgebenBis.Value == null)
                {
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis-Datum darf nicht leer sein.");
                    this.errorProvider1.SetError(this.dtpAbgebenBis, sText);
                    return false;
                }

                dsRezeptEintrag.RezeptEintragRow r = RezeptEintrag;
                if (dtpAbgebenVon.Value != null && diff == 1 && bRechtStorno)
                {
                        bIsStorno = true;
                }
                else if ((int)((DateTime)dtpAbgebenVon.Value - dtStartAction).TotalSeconds < 0 && r.AbzugebenVon != (DateTime)dtpAbgebenVon.Value)
                {
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Ändern (von-Datum) nicht erlaubt.");
                    this.errorProvider1.SetError(this.dtpAbgebenVon, sText);
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                    return false;
                }
                else if ((int)((DateTime)dtpAbgebenBis.Value - dtStartAction).TotalSeconds < 0 && r.AbzugebenBis != (DateTime)dtpAbgebenBis.Value && r.AbzugebenBis != new DateTime(3000,1,1,23,59,59))
                {
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Ändern (bis-Datum) nicht erlaubt.");
                    this.errorProvider1.SetError(this.dtpAbgebenBis, sText);
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (this.EintragBearbeitungsmodus == BearbeitungsModus.neu)
            {
                dsRezeptEintrag.RezeptEintragRow r = RezeptEintrag;
                if ((int)((DateTime)dtpAbgebenVon.Value - dtStartAction).TotalSeconds < (ENV.RezeptModifyTime * -1))
                {
                    string sText = "";
                    if (ENV.RezeptModifyTime == 0)
                    {
                        sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Anordnen (von-Datum) nicht erlaubt.");
                    }
                    else                    
                    {
                        string sMinDate = dtStartAction.AddSeconds(ENV.RezeptModifyTime * -1).ToString("dd.MM.yyyy HH:mm.ss");
                        sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Anordnen (von-Datum) nur bis {0} erlaubt.");
                        sText = string.Format(sText, sMinDate);
                    }

                    this.errorProvider1.SetError(this.dtpAbgebenVon, sText);
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                    return false;
                }
            }

            /*
            if (this.EintragBearbeitungsmodus == BearbeitungsModus.edit)
            {
                if (dtpAbgebenVon.Value != null && diff == 1)
                {

                    if (bRechtStorno && diff == 1 )
                    {
                        _bIsStorno = true;
                    }
                    else
                    {
                        string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren nicht erlaubt. Bitte beenden Sie die Anordnung und legen Sie eine neue an."); ;
                        this.errorProvider1.SetError(this.dtpAbgebenVon, sText);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "PMDS", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            */

            if (this.cmbApplikationsform.Value == null)
            {
                string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Applikationsform: Auswahl erforderlich!"); 
                this.errorProvider1.SetError(this.cmbApplikationsform, sText);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(Text, "PMDS", MessageBoxButtons.OK);
                return false;
            }            

            if (!bIsStorno)
            {
                //os191220
                GuiUtil.ValidateField(dtpAbgebenBis, (((DateTime)dtpAbgebenBis.Value) >= ((DateTime)dtpAbgebenVon.Value)),
                     ENV.String("GUI.E_REZEPTE_ABG_BIS"), ref bError, bInfo, errorProvider1);
                //GuiUtil.ValidateField(dtpAbgebenBis, (((DateTime)dtpAbgebenBis.Value).Date >= ((DateTime)dtpAbgebenVon.Value).Date),
                //     ENV.String("GUI.E_REZEPTE_ABG_BIS"), ref bError, bInfo, errorProvider1);
            }
            else
            {
                string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei Storno ist eine Anmerkung erforderlich!");
                PMDS.GUI.BaseControls.frmTextInput frm = new BaseControls.frmTextInput();
                frm.Text = sText;
                frm.txtText.Text = "";
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
                string sReason = frm.txtText.Text.Trim();

                if (sReason == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei Storno ist eine Anmerkung erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    if (this.txtAnmerkung.Text.Trim() != "")
                        this.txtAnmerkung.Text += "\r\n";
                    this.txtAnmerkung.Text += sReason;
                }
            }

            //Wiederholungstyp
            if (opWiederholungstyp.Value != null)
            {
                switch ((int)opWiederholungstyp.Value)
                {
                    case 1:
                        GuiUtil.ValidateField(txtWiedWertAlle, txtWiedWertAlle.Text.Trim().Length > 0,
                                              ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                        GuiUtil.ValidateField(opWiedheinheit, opWiedheinheit.Value != null,
                                              ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                        break;
                    case 2:
                        GuiUtil.ValidateField(txtWiedWertJeden, txtWiedWertJeden.Text.Trim().Length > 0,
                                              ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                        break;
                }
            }

            //Wochentage{{{eng}}}
            /*if (cbNurAm.Checked)
            {
                GuiUtil.ValidateField(ucWochenTage21, ucWochenTage21.WOCHENTAGE > 0,
                                      "Wochentage auswählen.", ref bError, bInfo, errorProvider1);
            }*/

            //Bei Bedarfsmedikation braucht nicht normal validiert zu werden
            if (!_bHerrichtenBedarf)
            {
                //Standardzeiten
                if (!bError)
                    bError = !ucStandardZeiten1.ValidateFields();

                // mindestens 1 ZP0 ... ZP4 muss einen Wert haben
                bool bZOK = false;

                if (zp0.Text.Trim().Length > 0 || zp1.Text.Trim().Length > 0 || zp2.Text.Trim().Length > 0 ||
                    zp3.Text.Trim().Length > 0 || zp4.Text.Trim().Length > 0
                    )
                    bZOK = true;

                if (!bZOK)
                {
                    GuiUtil.ValidateField(zp0, bZOK, ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo, errorProvider1);
                    GuiUtil.ValidateField(zp1, bZOK, ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo, errorProvider1);
                    GuiUtil.ValidateField(zp2, bZOK, ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo, errorProvider1);
                    GuiUtil.ValidateField(zp3, bZOK, ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo, errorProvider1);
                    GuiUtil.ValidateField(zp4, bZOK, ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo, errorProvider1);
                }
            }
            else
            {
                GuiUtil.ValidateField(txtAnmerkung, txtAnmerkung.Text.Trim().Length > 0,
                                 ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }


            //Zusammenhang Sonderzeiten,Dosierung  wird auch bein Bedarfsmedikation berüchsichtigt
            if (!bError)
            {
                int[] Dosierung = { zp0.Text.Trim().Length, zp1.Text.Trim().Length, zp2.Text.Trim().Length, zp3.Text.Trim().Length, zp4.Text.Trim().Length };
                bError = !ucStandardZeiten1.ValidateFields(Dosierung);
            }


            //Einheit
            GuiUtil.ValidateField(cmbEinheit, cmbEinheit.Text.Trim().Length > 0,
                                  ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //Verabreichungsart
            GuiUtil.ValidateField(cmbVerabreichungsart, cmbVerabreichungsart.Text.Trim().Length > 0,
                                 ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //Herrichten
            GuiUtil.ValidateField(cmbHerrichten, cmbHerrichten.Text.Trim().Length > 0,
                                 ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            
            //Applikationsform
            //GuiUtil.ValidateField(cmbApplikationsform, cmbApplikationsform.Text.Trim().Length > 0,
            //                     ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            GuiUtil.ValidateField(ucPatientAerzte1.cmbArzt, ucPatientAerzte1.cmbArzt.Text.Trim().Length > 0,
                                 ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            string MsgTxt2 = "";
            bool cbApplikationsformOK = PMDSBusinessUI.checkCboBox(this.cmbApplikationsform, QS2.Desktop.ControlManagment.ControlManagment.getRes("Applikationsform"), true, ref MsgTxt2, true);
            bool cbPackungseinheitOK = PMDSBusinessUI.checkCboBox(this.cbPackungsEinheit, QS2.Desktop.ControlManagment.ControlManagment.getRes("Packungseinheit"), true, ref MsgTxt2, true);
            bool cbEinheitOK = PMDSBusinessUI.checkCboBox(this.cmbEinheit, QS2.Desktop.ControlManagment.ControlManagment.getRes("Einheit"), true, ref MsgTxt2, true);
            if (!cbApplikationsformOK || !cbPackungseinheitOK || !cbEinheitOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
                return !bError;
            }

            if (!this.cbBis.Checked)
            {
                if (temp_dtpAbgebenVon_Value != null && DetailsChanged && (DateTime)temp_dtpAbgebenVon_Value == (DateTime)dtpAbgebenVon.Value)
                {


                    //Hinweise zur Änderung für den Anwender
                    int iAbgegeben = 0;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        iAbgegeben = db.MedikationAbgabe.Where(ma => ma.IDRezeptEintrag == _RezeptEintrag.ID).Count();
                    }

                    string sInfo1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte kontrollieren sie das Datum, ab dem die Änderung gelten soll!") + "\r\n\r\n";

                    string sInfo2 = "";
                    if (!_RezeptEintrag.IsZeitpunktBlisterlisteNull())
                        sInfo2 += string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag ist auf einer Blisterliste vom {0} enthalten."), _RezeptEintrag.ZeitpunktBlisterliste.ToShortDateString()) + "\r\n";

                    if (!_RezeptEintrag.IsZuletztBestelltAmNull())
                        sInfo2 += string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag wurde zuletzt am {0} bestellt."), _RezeptEintrag.ZuletztBestelltAm.ToShortDateString()) + "\r\n"; 

                    if (iAbgegeben != 0)
                        sInfo2 += string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden bereits {0} Einzel-Verabreichungen gemeldet."), iAbgegeben.ToString()) + "\r\n";

                    bool bWarning = false;
                    if (sInfo2 != "")
                    {
                        sInfo2 += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte beachten Sie, dass Sie bei einer rückwirkenden Änderung des Datums die Datenkontinuität zerstören werden!");
                        bWarning = true;
                    }
                    else if (dtpAbgebenVon.DateTime < DateTime.Now.Date)
                    {
                        sInfo2 += QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wird nicht empfohlen, Daten rückwirkend zu verändern!");
                        bWarning = true;
                    }
                    sInfo2 += "\r\n\r\n";

                    if (bWarning)
                        //os191220
                        sInfo2 += string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie das Datum {0} trotzdem beibehalten?"), ((DateTime)dtpAbgebenVon.Value));
                        //sInfo2 += string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie das Datum {0} trotzdem beibehalten?"), ((DateTime)dtpAbgebenVon.Value).Date.ToShortDateString());

   
                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sInfo2, sInfo1, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        bError = true;
                    }
                }
            }


            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(dtpAbgebenVon);
            GuiUtil.ValidateRequired(zp0);
            GuiUtil.ValidateRequired(zp1);
            GuiUtil.ValidateRequired(zp2);
            GuiUtil.ValidateRequired(zp3);
            GuiUtil.ValidateRequired(zp4);
            GuiUtil.ValidateRequired(cmbEinheit);
            GuiUtil.ValidateRequired(txtWiedWertAlle);
            GuiUtil.ValidateRequired(txtWiedWertJeden);
            GuiUtil.ValidateRequired(cmbVerabreichungsart);
            GuiUtil.ValidateRequired(cmbHerrichten);
            GuiUtil.ValidateRequired(ucPatientAerzte1.cmbArzt);
            GuiUtil.ValidateRequired(cmbApplikationsform);
        }

        public void InitCmbMedikament(System.Guid IDMed)
        {
            if (_medikament == null)
                return;

            int AktuMedikamente = -1;
            if (this.EintragBearbeitungsmodus == BearbeitungsModus.neu)
            {
                AktuMedikamente = 1;
            }
            else
            {
                AktuMedikamente = -1;
            }
            using (PMDS.DB.DBMedikament m = new PMDS.DB.DBMedikament())
            {
                m.LoadAllMedikamente(false);
                dsMedikament.MedikamentSmallRow[] arrMed = m.GetMedikamente(AktuMedikamente, IDMed);
                arrMed.CopyToDataTable(this.dsMedikament1.MedikamentSmall, LoadOption.Upsert);
            }            
        }
        
        private void opWiederholungstyp_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)opWiederholungstyp.Value)
            {
                case (int)medWiederholungstypen.taeglich:
                    txtWiedWertAlle.Enabled = false;
                    opWiedheinheit.Enabled = false;
                    txtWiedWertJeden.Enabled = false;
                    ucWochenTage21.Enabled = true;
                    ucWochenTage21.WOCHENTAGE = 127;
                    txtWiedWertJeden.Text = "";
                    txtWiedWertJeden.Value = System.DBNull.Value;
                    txtWiedWertAlle.Text = "";
                    txtWiedWertAlle.Value = System.DBNull.Value;
                    errorProvider1.Clear();
                    break;

                case (int)medWiederholungstypen.alle_x_Tage_Wochen:
                    txtWiedWertAlle.Enabled = true;
                    opWiedheinheit.Enabled = true;
                    opWiedheinheit.Value = 0;
                    txtWiedWertAlle.Focus();
                    txtWiedWertJeden.Enabled = false;

                    if ((int) this.opWiedheinheit.Value == 1)
                    {
                        ucWochenTage21.Enabled = true;
                        ucWochenTage21.WOCHENTAGE = 127;
                    }
                    else
                    {
                        ucWochenTage21.Enabled = false;
                        ucWochenTage21.WOCHENTAGE = 0;
                    }
                    txtWiedWertJeden.Text = "";
                    txtWiedWertJeden.Value = System.DBNull.Value;
                    errorProvider1.Clear();
                    break;

                case (int)medWiederholungstypen.jeden_xten_desMonat:
                    txtWiedWertAlle.Enabled = false;
                    opWiedheinheit.Enabled = false;
                    txtWiedWertJeden.Enabled = true;
                    txtWiedWertJeden.Focus();
                    ucWochenTage21.Enabled = false;
                    ucWochenTage21.WOCHENTAGE = 0;
                    txtWiedWertAlle.Text = "";
                    txtWiedWertAlle.Value = System.DBNull.Value;
                    errorProvider1.Clear();
                    break;
            }
            opWiederholungstyp.Items[0].DisplayText = getWiederholungstypText(); 

        }

        public void UpdateDataForMedikament(System.Guid IDMedikament)
        {
            try
            {
                if (!_ValueChangedEnabled)
                    return;

                //TO DO: Medikamentdaten Standardmäßig übernehmen
                //Medikament med = new Medikament();
                if (IDMedikament != null)
                {
                    try
                    {
                        dsMedikament.MedikamentDataTable t = _medikament.ReadMedikament(IDMedikament);
                        this.txtMedikament.Text = ((dsMedikament.MedikamentRow)t.Rows[0]).Bezeichnung.Trim();

                        if (!((dsMedikament.MedikamentRow)t.Rows[0]).IsApplikationsformNull())
                            cmbApplikationsform.Text = ((dsMedikament.MedikamentRow)t.Rows[0]).Applikationsform.Trim();

                        if (!((dsMedikament.MedikamentRow)t.Rows[0]).IsVerabreichungsartNull())
                        {
                            if (ENV.MedVerabreichenDefault != -1)
                                cmbVerabreichungsart.Value = ENV.MedVerabreichenDefault;
                            else
                                cmbVerabreichungsart.Value = ((dsMedikament.MedikamentRow)t.Rows[0]).Verabreichungsart;
                        }
                        else cmbVerabreichungsart.Text = "";

                        if (!((dsMedikament.MedikamentRow)t.Rows[0]).IsHerrichtenNull())
                            cmbHerrichten.Value = ((dsMedikament.MedikamentRow)t.Rows[0]).Herrichten;
                        else cmbHerrichten.Text = "";

                        if (!((dsMedikament.MedikamentRow)t.Rows[0]).IsEinheitNull())
                            cmbEinheit.Text = ((dsMedikament.MedikamentRow)t.Rows[0]).Packungseinheit.Trim();



                        txtPackGr.Value = ((dsMedikament.MedikamentRow)t.Rows[0]).Packungsgroesse;

                        cbPackungsanzahl.Value = (((dsMedikament.MedikamentRow)t.Rows[0]).Packungsanzahl == 0 ? 1 : ((dsMedikament.MedikamentRow)t.Rows[0]).Packungsanzahl);
                        cbPackungsEinheit.Text = ((dsMedikament.MedikamentRow)t.Rows[0]).Packungseinheit.Trim();

                        txtRezeptDaten.Text = (((dsMedikament.MedikamentRow)t.Rows[0]).Lagervorschrift + "\n" + ((dsMedikament.MedikamentRow)t.Rows[0]).LangText).Trim();
                        txtAnmerkung.Text = "";

                        errorProvider1.Clear();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("UpdateDataForMedikament: " + ex.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UpdateDataForMedikament: " + ex.ToString());
            }
        }

        private void cbBeaufsichtigungJN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbNuechtern_CheckedChanged(object sender, EventArgs e)
        {
            zp0.Visible = cbNuechtern.Checked;
            zp1.Visible = !cbNuechtern.Checked;
            zp2.Visible = !cbNuechtern.Checked;
            zp3.Visible = !cbNuechtern.Checked;
            zp4.Visible = !cbNuechtern.Checked;

            ucStandardZeiten1.Enabled = !cbNuechtern.Checked;
            ucStandardZeiten1.setStandardZeitenCheckbox(cbNuechtern.Checked);

            if (cbNuechtern.Checked)
            {
                zp1.Text = ""; zp2.Text = ""; zp3.Text = ""; zp4.Text = "";
            }
            else zp0.Text = "";
        }

        private void cmbHerrichten_ValueChanged(object sender, EventArgs e)
        {
            if ((medHerrichten)cmbHerrichten.Value == medHerrichten.beiBedarf)
            {
                _bHerrichtenBedarf = true;
                zp0.Appearance.BackColor = Color.White;
                zp1.Appearance.BackColor = Color.White;
                zp2.Appearance.BackColor = Color.White;
                zp3.Appearance.BackColor = Color.White;
                zp4.Appearance.BackColor = Color.White;
                ucStandardZeiten1.setZeitenBackcolor(Color.White);
            }

            else
            {
                _bHerrichtenBedarf = false;
                txtAnmerkung.Appearance.BackColor = Color.White;
            }

        }

        private void cbBis_CheckedChanged(object sender, EventArgs e)
        {
            if (_UpdateGuiInProgress)
                return;
            dtpAbgebenBis.Visible = cbBis.Checked;
            lblTagesende.Visible = cbBis.Checked && !ENV.RezeptUseTimeOfDay;
            if (ENV.RezeptUseTimeOfDay)
                dtpAbgebenBis.DateTime = cbBis.Checked ? DateTime.Now : dtInfinity;
            else
                dtpAbgebenBis.DateTime = cbBis.Checked ? DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59) : dtInfinity;


            this.cboAerzteAbgesetzt.Visible = cbBis.Checked;
            this.lblArztAbgesetzt.Visible = cbBis.Checked;
            if (this.cbBis.Checked)
            {
                PMDS.db.Entities.Benutzer rUsr = null;
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                rUsr = PMDSBusiness1.LogggedOnUser();
                if (rUsr.IDArzt != null)
                {
                    this.cboAerzteAbgesetzt.Value = (Guid)rUsr.IDArzt;
                }
                else
                {
                    this.cboAerzteAbgesetzt.Value = null;
                }
                //if (this.EintragBearbeitungsmodus == BearbeitungsModus.neu)
            }
            else
            {
                this.cboAerzteAbgesetzt.Value = null;
            }
        }

        private void btnSearchMedikament_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.GUI.Medikament.frmSearchMedikamente frm = new Medikament.frmSearchMedikamente();
                frm.initControl();
                frm.ShowDialog(this);
                if (!frm.contSearchMedikamente1.abort)
                {
                    this.txtMedikament.Tag = frm.contSearchMedikamente1.rSelMedikament.ID;
                    this.UpdateDataForMedikament(frm.contSearchMedikamente1.rSelMedikament.ID);
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

        private void opWiedheinheit_ValueChanged(object sender, EventArgs e)
        {
            if ((medWiederholungseinheiten)opWiedheinheit.Value == medWiederholungseinheiten.Wochen)
            {
                ucWochenTage21.Enabled = true;
                if (ucWochenTage21.WOCHENTAGE == 0)
                    ucWochenTage21.WOCHENTAGE = 127;
            }
            //else if ((medWiederholungseinheiten)opWiedheinheit.Value == medWiederholungseinheiten.tage)
            //{
            //    ucWochenTage21.Enabled = true;
            //    if (ucWochenTage21.WOCHENTAGE == 0)
            //        ucWochenTage21.WOCHENTAGE = 127;
            //}
            else
            {
                ucWochenTage21.Enabled = false;
                ucWochenTage21.WOCHENTAGE = 0;
            }
        }

        private void ucWochenTage21_ValueChanged(object sender, EventArgs e)
        {
            opWiederholungstyp.Items[0].DisplayText = getWiederholungstypText();
        }

        private string getWiederholungstypText() 
        {
            switch ((int)opWiederholungstyp.Value)
            {
                case (int)medWiederholungstypen.taeglich:
                    if (ucWochenTage21.WOCHENTAGE != 127)
                        return "nur am";
                    else
                        return "täglich";

                default:
                    return "täglich";

            }

        }

        private void dtpAbgebenVon_ValueChanged(object sender, EventArgs e)
        {
            if (!ENV.RezeptUseTimeOfDay)
            {
                //Uhrzeit nicht erlauben
                //dtpAbgebenVon.Value = dtpAbgebenVon.DateTime.Date;
            }
        }

        private void dtpAbgebenBis_ValueChanged(object sender, EventArgs e)
        {
            if (!ENV.RezeptUseTimeOfDay && dtpAbgebenBis.DateTime != dtInfinity)
            {
                //Uhrzeit nicht erlauben
                //dtpAbgebenBis.Value = dtpAbgebenBis .DateTime.Date;
            }

        }
    }
}
