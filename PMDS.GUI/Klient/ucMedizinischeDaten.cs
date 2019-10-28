using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using System.Linq;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI
{
    public partial class ucMedizinischeDaten : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private bool _valueChangeEnabled = true;
        private KlientDetails _klient;
        public event EventHandler ValueChanged;
        public event MedizinischeDatenStateChangedDelegate MedizinischerStateChanged;
        //Neu nach 27.04.2007 MDA
        private bool _readOnly = false;

        //Neu nach 05.06.2007 MDA
        MedizinischeDatenLayout _medVerwaltung = new MedizinischeDatenLayout();

        public static Nullable<Guid> IDMedDatenNew = null;
        public ucKlient mainWindow = null;

        public bool IsInitialized = false;

        public ELGABusiness bELGA = new ELGABusiness();







        public ucMedizinischeDaten()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;
            
            InitializeGridLayout();

            ENV.MedizinischeDatenLayoutChanged += new MedizinischeDatenLayoutChangedDelegate(ENV_MedizinischeDatenLayoutChanged);
        }

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
                if (_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                _valueChangeEnabled = false;
                _klient = value;
                UpdateGUI();                    //os-Performance 12 Sek
                _valueChangeEnabled = true;

            }
        }

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

        public void initControlxz()
        {
            if (!this.IsInitialized)
            {

                IsInitialized = true;
            }
        }

        public void UpdateGUI()
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                if (this.bELGA.ELGAIsActive(ENV.CurrentIDPatient, ENV.IDAUFENTHALT, false))
                {
                    ucBefunde.btnSearchELGADocuments.Visible = true;
                }
                else
                {
                    ucBefunde.btnSearchELGADocuments.Visible = false;
                }

                this.initControlxz();

                tbBlutgruppe.Text = Klient.BlutGruppe;
                tbRhesusfaktur.Text = Klient.Rhesusfaktor;

                ucKostform.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.KOSTFORM, db);
                ucInfektionen.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.INFEKTIONEN, db); 
                ucDiabetes.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.DIABETES, db); 
                ucAntikoagolation.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.ANTIKOAGOLATION, db);  
                ucAllergien.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.ALLERGIEN, db);  
                ucUnvertraeglichkeiten.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.UNVERTRAEGLICHKEITEN, db);  
                ucMedDiagnosen.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.DIAGNOSEN, db);  
                ucMedDauerDiagnosen.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.DAUERDIAGNOSEN, db); 
                ucImplentateProthesen.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.IMPLENTATE, db); 
                ucKatheder.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.KATHEDER, db);  
                ucImpfungen.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.IMPFUNGEN, db);  
                ucSuchtmittel.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.SUCHTMITTEL, db);  
                ucSonstige.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.SONSTIGE, db);  
                ucNuechtern.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.NUECHTERN, db); 
                ucBefunde.loadMEDIZINISCHEDATEN(Klient.MEDIZINISCHE_DATEN.Befunde, db);      //os-Performance   8 Sekunden

            }

        }

        public void UpdateMehrfachauswahlPatienten()
        {
            try
            {
                this.ucKostform.UpdateMehrfachauswahlPatienten();
                this.ucInfektionen.UpdateMehrfachauswahlPatienten();
                this.ucDiabetes.UpdateMehrfachauswahlPatienten();
                this.ucAntikoagolation.UpdateMehrfachauswahlPatienten();
                this.ucAllergien.UpdateMehrfachauswahlPatienten();
                this.ucUnvertraeglichkeiten.UpdateMehrfachauswahlPatienten();
                this.ucMedDiagnosen.UpdateMehrfachauswahlPatienten();
                this.ucMedDauerDiagnosen.UpdateMehrfachauswahlPatienten();
                this.ucImplentateProthesen.UpdateMehrfachauswahlPatienten();

                this.ucKatheder.UpdateMehrfachauswahlPatienten();
                this.ucImpfungen.UpdateMehrfachauswahlPatienten();
                this.ucSuchtmittel.UpdateMehrfachauswahlPatienten();
                this.ucSonstige.UpdateMehrfachauswahlPatienten();
                this.ucNuechtern.UpdateMehrfachauswahlPatienten();
                this.ucBefunde.UpdateMehrfachauswahlPatienten();

            }
            catch (Exception ex)
            {
                throw new Exception("UpdateMehrfachauswahlPatienten: " + ex.ToString());
            }  
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            Klient.BlutGruppe = tbBlutgruppe.Text.Trim();
            Klient.Rhesusfaktor = tbRhesusfaktur.Text.Trim();
        }

        public bool ValidateFields()
        {
            return true;
        }

        private PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow GetMedizinischeDatenLayoutRow(MedizinischerTyp medTyp)
        {
            foreach (PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow r in _medVerwaltung.ALL.MedizinischeDatenLayout)
            {
                if (r.MedizinischerTyp == (int)medTyp)
                    return r;
            }

            return null;
        }

        private Guid Einschalten(MedDatenArgs args, Guid IDMedDatenNew, bool SetRowUnmodified)
        {
            try
            {
                Klient.MEDIZINISCHE_DATEN.New((MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), args.MedTyp.ToString(), true),
                            args.Von, args.Bis, args.Beschreibung, args.Bemerkung, args.Beendigungsgrund,
                                      args.LetzteVersorgung, args.NaechsteVersorgung, args.Modell, args.Handling,
                                      args.Therapie, args.ICDCode, args.AufnahmeDiagnoseJN, args.AntikoaguliertJN, args.Typ, args.Anzahl, 
                                      args.NuechternJN, args.Groesse, IDMedDatenNew, "", SetRowUnmodified);
                return IDMedDatenNew;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return System.Guid.Empty;
            }
        }

        private bool Ausschalten(MedDatenArgs args)
        {
            try
            {
                Klient.MEDIZINISCHE_DATEN.CloseMedDaten(args.ID, (MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), args.MedTyp.ToString(), true),
                                    args.Bis, args.Beendigungsgrund);
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        private bool UpdateDaten(MedDatenArgs args)
        {
            try
            {
                Klient.MEDIZINISCHE_DATEN.UpdateMedDatenRow(args.ID, (MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), args.MedTyp.ToString(), true),
                                                                args.Von, args.Bis, args.Beschreibung, args.Bemerkung, args.Beendigungsgrund,
                                                                args.LetzteVersorgung, args.NaechsteVersorgung, args.Modell, args.Handling,
                                                                args.Therapie, args.ICDCode, args.AufnahmeDiagnoseJN, args.AntikoaguliertJN, args.Typ, args.Anzahl, args.NuechternJN, args.Groesse, args._lstRezepteinträge, args._NumberRezepteinträge);
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        private bool DeleteDaten(MedDatenArgs[] args)
        {
            if (args.Length > 0 && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                try
                {
                    Klient.MEDIZINISCHE_DATEN.Delete(args);
                    return true;
                }
                catch (Exception e)
                {
                    ENV.HandleException(e);
                    return false;
                }
            }
            
            return false;
        }

        private void SetReadOnly()
        {
            tbBlutgruppe.ReadOnly = ReadOnly;
            tbRhesusfaktur.ReadOnly = ReadOnly;

            foreach (Control c in Controls)
                SetReadOnly(c);
        }

        private void SetReadOnly(Control c)
        {
            if (c is ucMedTypDaten)
            {
                ucMedTypDaten uc = (ucMedTypDaten)c;
                uc.ReadOnly = ReadOnly;
            }
            else
                foreach (Control cc in c.Controls)
                    SetReadOnly(cc);
        }

        private void InitializeGridFromControl(Control c)
        {
            if (c is ucMedTypDaten)
            {
                ucMedTypDaten uc = (ucMedTypDaten)c;
                uc.MedizinischeDatenLayoutRow = GetMedizinischeDatenLayoutRow((MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), uc.Tag.ToString(), true));
            }
            else
                foreach (Control cc in c.Controls)
                    InitializeGridFromControl(cc);
        }
        
        public void setControlsAktivDisable(bool bOn)
        {

            PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
            this.ucKostform.setControlsAktivDisable(bOn);
            this.ucInfektionen.setControlsAktivDisable(bOn);
            this.ucDiabetes.setControlsAktivDisable(bOn);
            this.ucAntikoagolation.setControlsAktivDisable(bOn);
            this.ucAllergien.setControlsAktivDisable(bOn);
            this.ucUnvertraeglichkeiten.setControlsAktivDisable(bOn);

            this.ucMedDiagnosen.setControlsAktivDisable(bOn);
            this.ucMedDauerDiagnosen.setControlsAktivDisable(bOn);
            this.ucImplentateProthesen.setControlsAktivDisable(bOn);
            this.ucKatheder.setControlsAktivDisable(bOn);
            this.ucImpfungen.setControlsAktivDisable(bOn);
            this.ucSuchtmittel.setControlsAktivDisable(bOn);

            this.ucNuechtern.setControlsAktivDisable(bOn);
            this.ucSonstige.setControlsAktivDisable(bOn);
            this.ucBefunde.setControlsAktivDisable(bOn);
        }
        private void InitializeGridLayout()
        {
            _medVerwaltung.Read();

            foreach (Control c in Controls)
            {
                if (c is ucMedTypDaten)
                {
                    ucMedTypDaten uc = (ucMedTypDaten)c;
                    uc.MedizinischeDatenLayoutRow = GetMedizinischeDatenLayoutRow((MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), uc.Tag.ToString(), true));
                }
                else
                    InitializeGridFromControl(c);
            }
        }

        #region Events
        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        private void ENV_MedizinischeDatenLayoutChanged()
        {
            InitializeGridLayout();
        }

        private void uc_AddMedizinischeDaten(MedDatenArgs args)
        {
            bool SetRowUnmodified = false;
            Guid IDMedDatenNew = System.Guid.NewGuid();
            if (ucMedizinischeDaten.IDMedDatenNew != null)
            {
                IDMedDatenNew = ucMedizinischeDaten.IDMedDatenNew.Value;
                SetRowUnmodified = true;
            }
            Einschalten(args, IDMedDatenNew, SetRowUnmodified);

            if (ucMedizinischeDaten.IDMedDatenNew == null)
            {
                if (ValueChanged != null)
                    ValueChanged(this, null);
                if (MedizinischerStateChanged != null)
                    MedizinischerStateChanged(args.MedTyp);
            }
        }

        private void uc_EndMedizinischeDaten(MedDatenArgs args)
        {
            if (Ausschalten(args))
            {
                if (ValueChanged != null)
                    ValueChanged(this, null);
                if (MedizinischerStateChanged != null)
                    MedizinischerStateChanged(args.MedTyp);
            }
        }

        private void uc_DeleteMedizinischeDaten(MedDatenArgs[] args)
        {
            if (DeleteDaten(args))
            {
                //if (ValueChanged != null)
                //    ValueChanged(this, null);
                //if (MedizinischerStateChanged != null)
                //    MedizinischerStateChanged((int)MedizinischerTyp.Nuechtern);
            }
        }

        private void uc_UpdateMedizinischeDaten(MedDatenArgs args)
        {
            if (UpdateDaten(args))
            {
                if (ValueChanged != null)
                    ValueChanged(this, null);
                if (MedizinischerStateChanged != null)
                    MedizinischerStateChanged(args.MedTyp);
            }
        }

        private void uc_MedizinischerStateChanged(int iMedizinischerTyp)
        {
            if (MedizinischerStateChanged != null)
                MedizinischerStateChanged(iMedizinischerTyp);
        }
        #endregion

        private void ucMedizinischeDaten_Load(object sender, EventArgs e)
        {

        }

    }
}