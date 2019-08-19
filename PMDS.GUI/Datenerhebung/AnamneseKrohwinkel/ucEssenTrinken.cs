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

    public partial class ucEssenTrinken : ucAnamneseModellgruppeBase
    {


        public ucEssenTrinken()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.EssenUndTrinken;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtSpeisenGetraenke, "Text", "SpeisenGetraenke"),
                                                    new DataBindingHelper(txtSpeisenGetraenkeAblehnen, "Text", "SpeisenGetraenkeAblehnen"),
                                                    new DataBindingHelper(txtAnzahlLiterTrinken, "Value", "AnzahlLiterTrinken"),
                                                    new DataBindingHelper(opMahlzeitInDerGemeinschaftJN, "Value", "MahlzeitInDerGemeinschaftJN"),
                                                    new DataBindingHelper(txtFruehstueckSpaetFruehEinnehmen, "Text", "FruehstueckSpaetFruehEinnehmen"),
                                                    new DataBindingHelper(txtDiatSchonkostSondenernaehrung, "Text", "DiatSchonkostSondenernaehrung"),
                                                    new DataBindingHelper(txtAnzahlMalzeiten, "Value", "AnzahlMalzeiten"),
                                                    new DataBindingHelper(opNotwendigkeitEsssenTrinken, "Value", "NotwendigkeitEsssenTrinken"),
                                                    new DataBindingHelper(opNotwendigkeitDiaet, "Value", "NotwendigkeitDiaet"),
                                                    new DataBindingHelper(opKauSchluckstoerungen, "Value", "KauSchluckstoerungen"),
                                                    new DataBindingHelper(opIsstSehrlangsamm, "Value", "IsstSehrlangsamm"),
                                                    new DataBindingHelper(opNahrungMundgerechtZubereiten, "Value", "NahrungMundgerechtZubereiten"),
                                                    new DataBindingHelper(opMahlzeiteinnahmeHilfestellung, "Value", "MahlzeiteinnahmeHilfestellung"),
                                                    new DataBindingHelper(opSondePEGKomplett, "Value", "SondePEGKomplett"),
                                                    new DataBindingHelper(opSondenErnaehrung, "Value", "SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme"),
                                                    new DataBindingHelper(opUnterstFluessAufnahme, "Value", "UnterstuezungUeberwachungFluessigkeitsaufnahme"),
                                                    new DataBindingHelper(opHaufigErbrechen, "Value", "HaufigErbrechen")
                                                    });
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
