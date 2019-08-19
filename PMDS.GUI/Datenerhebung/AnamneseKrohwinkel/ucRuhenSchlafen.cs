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
    public partial class ucRuhenSchlafen : ucAnamneseModellgruppeBase
    {
        public ucRuhenSchlafen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.RuhenUndSchlafen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtSchlafenVonBis, "Text", "SchlafenVonBis"), 
                                                    new DataBindingHelper(opMittagsschlafJN, "Value", "MittagsschlafJN"),
                                                    new DataBindingHelper(opNachtsNachschauenJN, "Value", "NachtsNachschauenJN"),
                                                    new DataBindingHelper(txtSchlafBesonderheiten, "Text", "SchlafBesonderheiten"),
                                                    new DataBindingHelper(txtSchlafMedikamente, "Text", "SchlafMedikamente"),
                                                    new DataBindingHelper(txtSchlafGewohnheiten, "Text", "SchlafGewohnheiten"),
                                                    new DataBindingHelper(opHateinschlafDurchschlafstoerungen, "Value", "HateinschlafDurchschlafstoerungen"),
                                                    new DataBindingHelper(opHatPsychiKrankSchlafstoerungen, "Value", "HatPsychischeKrankheitsbedingteSchlafstoerungen"),
                                                    new DataBindingHelper(opHatGestoertenTagNachtrhytmus, "Value", "HatGestoertenTagNachtrhytmus")
                                                    });
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
