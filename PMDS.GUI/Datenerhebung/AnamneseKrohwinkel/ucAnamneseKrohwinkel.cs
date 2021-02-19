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
    public partial class ucAnamneseKrohwinkel : ucAnamneseBase
    {
        public ucAnamneseKrohwinkel()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;

            Modell = PflegeModelle.Krohwinkel;
            EntyText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach Krohwinkel (AEDL)");
            AnamneseObject = new AnamneseKrohwinkel();
            AddModellgruppenControls();

            
        }
        
        private void AddModellgruppenControls()
        {
            ListModellgruppenControl.Clear();
            ListModellgruppenControl.AddRange(new ucAnamneseModellgruppeBase[]{ucKommunizieren1, ucSichBewegen1, ucVitaleFunktionen1,
                                                                                ucSichPflegen1, ucEssenTrinken1, ucAusscheiden1,
                                                                                ucSichKleiden1, ucRuhenSchlafen1, ucSichBeschaeftigen1,
                                                                                ucSichAlsManFrauFuehlen1, ucUmgebung1, ucSozialeBereiche1,
                                                                                ucLebensErfahrungen1, ucBiographie1});
        }

        private void ucAnamneseKrohwinkel2_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

             _loaded = true;
            _dataChanged = false;

            foreach (UltraTab tab in tabKrohwinkel.Tabs)
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

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        public void setControlsAktivDisable(bool bOn)
        {
            panelButtonOben.Visible = !bOn;
            panelButtonUnten.Visible = !bOn;
        }
    }
}
