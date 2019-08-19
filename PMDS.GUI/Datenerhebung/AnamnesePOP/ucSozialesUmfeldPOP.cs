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
    public partial class ucSozialesUmfeldPOP : ucAnamneseModellgruppeBase
    {
        public ucSozialesUmfeldPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)POPModellgruppen.SozialesUmfeld;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(tbVerwandschaftsverhältnis, "Text", "Verwandschaftsverhältnis"), 
                                                    new DataBindingHelper(tbWeitereBeteiligte, "Text", "WeitereBeteiligte"),
                                                    new DataBindingHelper(tbBelastendeFaktoren, "Text", "BelastendeFaktoren"),
                                                    new DataBindingHelper(tbBeobachtungenAngehoerige, "Text", "BeobachtungenAngehoerige"),
                                                    new DataBindingHelper(tbFamilieZusammensetzung, "Text", "FamilieZusammensetzung"),
                                                    new DataBindingHelper(tbFamilieBeeintraechtigungen, "Text", "FamilieBeeintraechtigungen"),
                                                    new DataBindingHelper(tbBeobachtungenFamilieBeeintraechtigungen, "Text", "BeobachtungenFamilieBeeintraechtigungen"),
                                                    new DataBindingHelper(tbFamilieBereitschaft, "Text", "FamilieBereitschaft"),
                                                    new DataBindingHelper(tbBeobachtungenFamilieBereitschaft, "Text", "BeobachtungenFamilieBereitschaft")
                                                    });

            
            
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }




    }
}
