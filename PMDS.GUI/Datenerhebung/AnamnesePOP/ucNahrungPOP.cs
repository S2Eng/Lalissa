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
    public partial class ucNahrungPOP : ucAnamneseModellgruppeBase
    {
        public ucNahrungPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.Nahrung;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opErnaehrungProblemeJN, "Value", "ErnaehrungProblemeJN"), 
                                                    new DataBindingHelper(tbErnaehrungProbleme, "Text", "ErnaehrungProbleme"),
                                                    new DataBindingHelper(dtpErnaehrungProblemeSeit, "Value", "ErnaehrungProblemeSeit"),
                                                    new DataBindingHelper(tbDiaet, "Text", "Diaet"),
                                                    new DataBindingHelper(dtpDiaetSeit, "Value", "DiaetSeit"),
                                                    new DataBindingHelper(tbEssgewohnheiten, "Text", "Essgewohnheiten"),
                                                    new DataBindingHelper(tbZahnKieferzustand, "Text", "ZahnKieferzustand"),
                                                    new DataBindingHelper(opErnaehrungParenteralEnteral, "Value", "ErnaehrungParenteralEnteral"),
                                                    new DataBindingHelper(tbErnaehrungArt, "Text", "ErnaehrungArt"),
                                                    new DataBindingHelper(dtpGelegtAm, "Value", "GelegtAm"),
                                                    new DataBindingHelper(tbKauSchluckVerhalten, "Text", "KauSchluckVerhalten"),                                                    new DataBindingHelper(tbStillgewohnheiten, "Text", "Stillgewohnheiten"),
                                                    new DataBindingHelper(tbBeobachtungErnaehrungProbleme, "Text", "BeobachtungErnaehrungProbleme")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
