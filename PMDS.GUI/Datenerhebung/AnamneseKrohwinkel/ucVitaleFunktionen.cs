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
    public partial class ucVitaleFunktionen : ucAnamneseModellgruppeBase
    {
        public ucVitaleFunktionen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.VitaleFunktionenAufrechterhalten;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opBlutdruckZuckerRegelmaessigGemessenJN, "Value", "BlutdruckZuckerRegelmaessigGemessenJN"), 
                                                    new DataBindingHelper(opKompressionsstruempfeJN, "Value", "KompressionsstruempfeJN"),
                                                    new DataBindingHelper(opZimmertemperatur, "Value", "Zimmertemperatur"),
                                                    new DataBindingHelper(opMedikamenteRegelmaessigJN, "Value", "MedikamenteRegelmaessigJN"),
                                                    new DataBindingHelper(txtMedikamente, "Text", "Medikamente"),
                                                    new DataBindingHelper(opErhoehteErnidriegteBlutdruck, "Value", "ErhoehteErnidriegteBlutdruck"),
                                                    new DataBindingHelper(opDurchblutungsstoerungen, "Value", "Durchblutungsstoerungen"),
                                                    new DataBindingHelper(opFriertLeicht, "Value", "FriertLeicht"),
                                                    new DataBindingHelper(opDiabetesUnterUeberZucker, "Value", "DiabetesUnterUeberZucker"),
                                                    new DataBindingHelper(opSauerstoffmangel, "Value", "Sauerstoffmangel"),
                                                    new DataBindingHelper(opBronchialsekretSchlechtAbhusten, "Value", "BronchialsekretSchlechtAbhusten"),
                                                    new DataBindingHelper(opStarkeAuswurf, "Value", "StarkeAuswurf"),
                                                    new DataBindingHelper(opAtemnotleichterAnstrengung, "Value", "AtemnotleichterAnstrengung"),
                                                    new DataBindingHelper(opHilfeMedikamentenversorgung, "Value", "HilfeMedikamentenversorgung")
                                                    });

            BindData();
        }
        
        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
