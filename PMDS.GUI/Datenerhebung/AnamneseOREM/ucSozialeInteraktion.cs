using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;

namespace PMDS.GUI
{
    public partial class ucSozialeInteraktion : ucAnamneseModellgruppeBase
    {
        public ucSozialeInteraktion()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.AlleinseinUndSozialeInteraktion;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opKommunikationProblemeJN, "Value", "KommunikationProblemeJN"), 
                                                    new DataBindingHelper(tbKommunikationProbleme, "Text", "KommunikationProbleme"),
                                                    new DataBindingHelper(tbKommunikationSelbsthilfe, "Text", "KommunikationSelbsthilfe"),
                                                    new DataBindingHelper(tbBeobachtungenKommunikationProbleme, "Text", "BeobachtungenKommunikationProbleme"),
                                                    new DataBindingHelper(tbFamBeziehSozialeSituation, "Text", "FamBeziehSozialeSituation"),
                                                    new DataBindingHelper(opFamBeziehSozialeProblemeJN, "Value", "FamBeziehSozialeProblemeJN"),
                                                    new DataBindingHelper(tbFamBeziehSozialeProbleme, "Text", "FamBeziehSozialeProbleme"),
                                                    new DataBindingHelper(tbBezugsperson, "Text", "Bezugsperson"),
                                                    new DataBindingHelper(opAbhaengigePersonenJN, "Value", "AbhaengigePersonenJN"),
                                                    new DataBindingHelper(tbAbhaengigePersonen, "Text", "AbhaengigePersonen"),
                                                    new DataBindingHelper(opZuHauseAllesRegelnKoennenJN, "Value", "ZuHauseAllesRegelnKoennenJN"),
                                                    new DataBindingHelper(tbZuHauseNichtRegelnKoennen, "Text", "ZuHauseNichtRegelnKoennen"),
                                                    new DataBindingHelper(tbBesuchswuensche, "Text", "Besuchswuensche"),
                                                    new DataBindingHelper(tbSituationsauswirkung, "Text", "Situationsauswirkung"),
                                                    new DataBindingHelper(tbBeobachtungenSozialesituation, "Text", "BeobachtungenSozialesituation"),
                                                    new DataBindingHelper(opHinweiseKoerpPsychGewalteinwirkungenJN, "Value", "HinweiseKoerpPsychGewalteinwirkungenJN"),
                                                    new DataBindingHelper(tbHinweiseKoerpPsychGewalteinwirkungen, "Text", "HinweiseKoerpPsychGewalteinwirkungen"),
                                                    new DataBindingHelper(tbEinschneidendeLebenssituationsveraenderungen, "Text", "EinschneidendeLebenssituationsveraenderungen"),
                                                    new DataBindingHelper(tbSuizidversuche, "Text", "Suizidversuche"),
                                                    new DataBindingHelper(tbBeobachtungenGewalteinwirkungen, "Text", "BeobachtungenGewalteinwirkungen"),
                                                    new DataBindingHelper(tbSexualitaet, "Text", "Sexualitaet"),
                                                    new DataBindingHelper(tbBeobachtungenSexualitaet, "Text", "BeobachtungenSexualitaet")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
