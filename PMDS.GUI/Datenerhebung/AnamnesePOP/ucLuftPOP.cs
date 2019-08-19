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
    public partial class ucLuftPOP : ucAnamneseModellgruppeBase
    {
        public ucLuftPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)POPModellgruppen.Luft;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opRaucherJN, "Value", "RaucherJN"), 
                                                    new DataBindingHelper(opAtemProblemeJN, "Value", "AtemProblemeJN"),
                                                    new DataBindingHelper(tbAtemProbleme, "Text", "AtemProbleme"),
                                                    new DataBindingHelper(dtpAtemProblemeSeit, "Value", "AtemProblemeSeit"),
                                                    new DataBindingHelper(opAtemProblemeAuftretung, "Value", "AtemProblemeAuftretung"),
                                                    //new DataBindingHelper(tbSonstigeAtemProblemeAuftretung, "Text", "SonstigeAtemProblemeAuftretung"),
                                                    new DataBindingHelper(tbAtemProblemeHilfeMassnahmenHilfsMittel, "Text", "AtemProblemeHilfeMassnahmenHilfsMittel"),
                                                    new DataBindingHelper(opTracheostoma, "Value", "Tracheostoma"),
                                                    new DataBindingHelper(tbTracheostomaBeschreibung, "Text", "TracheostomaBeschreibung"),
                                                    new DataBindingHelper(tbBeobachtungenAtemProbleme, "Text", "BeobachtungenAtemProbleme")
                                                    });
            
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
