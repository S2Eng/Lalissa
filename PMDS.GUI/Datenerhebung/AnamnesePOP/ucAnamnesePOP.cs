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
using PMDS.Datenerhebung2.AnamnesePOP;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucAnamnesePOP : ucAnamneseBase
    {
        
        public ucAnamnesePOP()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;

            Modell = PflegeModelle.POP;
            EntyText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach POP");

            AnamneseObject = new AnamnesePOP();
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
                ucPersoenlicheDatenPOP1.Klient = new KlientDetails(value, ENV.IDAUFENTHALT);
                base.IDPatient = value;
            }
        }

        private void AddModellgruppenControls()
        {
            ListModellgruppenControl.Clear();
            ListModellgruppenControl.AddRange(new ucAnamneseModellgruppeBase[]{ucPersoenlicheDatenPOP1, ucLuftPOP1, ucWasserPOP1, ucNahrungPOP1, ucAusscheidungPOP1,
                                                                               ucAktivitaetUndRuhePOP1, ucSozialeInteraktionPOP1, ucAbwendenVonGefahrenPOP1,
                                                                               ucPersonIntegritaetPOP1, ucSozialesUmfeldPOP1});
        }


        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public override void UpdateDATA()
        {
            PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow r = (PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow)AnamneseRow;
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
                bError = !ucLuftPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[1];
            }

            if (!bError)
            {
                bError = !ucWasserPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[2];
            }

            if (!bError)
            {
                bError = !ucNahrungPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[3];
            }

            if (!bError)
            {
                bError = !ucAusscheidungPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[4];
            }

            if (!bError)
            {
                bError = !ucAktivitaetUndRuhePOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[5];
            }

            if (!bError)
            {
                bError = !ucSozialeInteraktionPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[6];
            }

            if (!bError)
            {
                bError = !ucAbwendenVonGefahrenPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[7];
            }

            if (!bError)
            {
                bError = !ucPersonIntegritaetPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[8];
            }

            if (!bError)
            {
                bError = !ucSozialesUmfeldPOP1.ValidateFields();
                if (bError)
                    tabAnamnesePOP.SelectedTab = tabAnamnesePOP.Tabs[9];
            }
            return !bError;
        }

        private void ucAnamnesePOP_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            _loaded = true;
            _dataChanged = false;

            foreach (UltraTab tab in tabAnamnesePOP.Tabs)
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

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void ucPersoenlicheDatenPOP1_Load(object sender, EventArgs e)
        {

        }

        private void dtpErstelltAm_ValueChanged(object sender, EventArgs e)
        {
            this.ucPersoenlicheDatenPOP1.Datum = dtpErstelltAm.DateTime;
        }
    }
}
