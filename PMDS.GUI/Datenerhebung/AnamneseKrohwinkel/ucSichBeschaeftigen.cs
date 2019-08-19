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
    public partial class ucSichBeschaeftigen : ucAnamneseModellgruppeBase
    {
        public ucSichBeschaeftigen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.SichBeschaeftigen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtBeruf, "Text", "Beruf"), 
                                                    new DataBindingHelper(txtGerneBeschaeftigtMit, "Text", "GerneBeschaeftigtMit"),
                                                    new DataBindingHelper(txtTagsablauf, "Text", "Tagsablauf"),
                                                    new DataBindingHelper(opTagesablaufsgestaltungHilfeJN, "Value", "TagesablaufsgestaltungHilfeJN"),
                                                    new DataBindingHelper(txtTagesablaufsgestaltungHilfe, "Text", "TagesablaufsgestaltungHilfe"),
                                                    new DataBindingHelper(opTagesablaufNachFrueherenGewohnheiten, "Value", "TagesablaufNachFrueherenGewohnheiten"),
                                                    new DataBindingHelper(opZeitpunktAufstehenBettGehenAbstimmen, "Value", "ZeitpunktAufstehenBettGehenAbstimmen"),
                                                    new DataBindingHelper(opIntegrationInTaeglicheAblaufe, "Value", "IntegrationInTaeglicheAblaufe")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
