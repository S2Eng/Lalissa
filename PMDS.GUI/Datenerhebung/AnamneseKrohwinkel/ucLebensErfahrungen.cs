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
    public partial class ucLebensErfahrungen : ucAnamneseModellgruppeBase
    {
        public ucLebensErfahrungen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.MitExistentiellenErfahrungenDesLebensUmgehen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }
        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtSterbephaseBetreuung, "Text", "SterbephaseBetreuung"), 
                                                    new DataBindingHelper(txtVersorger, "Text", "Versorger"),
                                                    new DataBindingHelper(opKannKrankheitBehinderungNichtAkzeptieren, "Value", "KannKrankheitBehinderungNichtAkzeptieren"),
                                                    new DataBindingHelper(txtLeidetAnVerlustVon, "Text", "LeidetAnVerlustVon"),
                                                    new DataBindingHelper(opLeidetAnVerlust, "Value", "LeidetAnVerlust"),
                                                    new DataBindingHelper(txtIstMisstraurischGegen, "Text", "IstMisstraurischGegen"),
                                                    new DataBindingHelper(opIstMisstraurisch, "Value", "IstMisstraurisch"),
                                                    new DataBindingHelper(txtSchmerzen, "Text", "Schmerzen"),
                                                    new DataBindingHelper(opHatSchmerzen, "Value", "HatSchmerzen"),
                                                    new DataBindingHelper(txtAngstVon, "Text", "AngstVon"),
                                                    new DataBindingHelper(opHatAngst, "Value", "HatAngst")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
