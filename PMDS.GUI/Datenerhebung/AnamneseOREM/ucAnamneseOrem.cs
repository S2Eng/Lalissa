using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinTabControl;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Klient;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucAnamneseOrem : ucAnamneseBase
    {
        
        public ucAnamneseOrem()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;

            Modell = PflegeModelle.Orem;
            EntyText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach OREM");

            AnamneseObject = new AnamneseOREM();
            AddModellgruppenControls();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Guid IDPatient
        {
            get { return base.IDPatient; }
            set
            {
                ucPersoenlicheDaten1.Klient = new KlientDetails(value, ENV.IDAUFENTHALT);
                base.IDPatient = value;
            }
        }

        private void AddModellgruppenControls()
        {
            ListModellgruppenControl.Clear();
            ListModellgruppenControl.AddRange(new ucAnamneseModellgruppeBase[]{ucPersoenlicheDaten1, ucLuft1, ucWasser1, ucNahrung1, ucAusscheidung1,
                                                                               ucAktivitaetUndRuhe1, ucSozialeInteraktion1, ucAbwendenVonGefahren1,
                                                                               ucPersonIntegritaet1});
        }


        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public override void UpdateDATA()
        {
            dsAnamneseOrem.Anamnese_OremRow r = (dsAnamneseOrem.Anamnese_OremRow)AnamneseRow;
            r.ErstelltAm = (DateTime)dtpErstelltAm.Value;
            r.IDBenutzerErstellt = new Guid(cmbPfleger.Value.ToString());
            base.UpdateDATA();
        }


        //
        //prüft ob alle Eingaben richtig sind.
        public override bool ValidateFields()
        {
            bool bError = !base.ValidateFields();

            if (!bError)
            {
                bError = !ucLuft1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[1];
            }

            if (!bError)
            {
                bError = !ucWasser1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[2];
            }

            if (!bError)
            {
                bError = !ucNahrung1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[3];
            }

            if (!bError)
            {
                bError = !ucAusscheidung1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[4];
            }

            if (!bError)
            {
                bError = !ucAktivitaetUndRuhe1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[5];
            }

            if (!bError)
            {
                bError = !ucSozialeInteraktion1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[6];
            }

            if (!bError)
            {
                bError = !ucAbwendenVonGefahren1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[7];
            }

            if (!bError)
            {
                bError = !ucPersonIntegritaet1.ValidateFields();
                if (bError)
                    tabAnamneseOrem.SelectedTab = tabAnamneseOrem.Tabs[8];
            }

            return !bError;
        }

        private void ucAnamneseOrem_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            _loaded = true;
            _dataChanged = false;

            foreach (UltraTab tab in tabAnamneseOrem.Tabs)
            {
                foreach (dsPflegemodelle.PflegemodelleRow r in (dsPflegemodelle.PflegemodelleDataTable)AnamneseObject.Pflegemodelle)
                {
                    if (tab.Tag != null && r.Modellgruppe == (int)tab.Tag)
                    {
                        tab.Text = r.Reihenfolge + ". " + r.ModellgruppeKlartext;
                        break;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void Control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }


        public void setControlsAktivDisable(bool bOn)
        {
            panelButtonOben.Visible = !bOn;
            panelButtonUnten.Visible = !bOn;
        }

    }
}
