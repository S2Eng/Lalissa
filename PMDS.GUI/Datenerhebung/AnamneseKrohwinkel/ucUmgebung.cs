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
    public partial class ucUmgebung : ucAnamneseModellgruppeBase
    {
        public ucUmgebung()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.FuerEineSichereUmgebungSorgen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opHilfsmittelZurMobilitaetJN, "Value", "HilfsmittelZurMobilitaetJN"), 
                                                    new DataBindingHelper(opBettgitterJN, "Value", "BettgitterJN"),
                                                    new DataBindingHelper(txtZimmerVerschlossen, "Text", "ZimmerVerschlossen"),
                                                    new DataBindingHelper(opHilfeHerbeirufenJN, "Value", "HilfeHerbeirufenJN"),
                                                    new DataBindingHelper(opOhneHilfeZurechtJN, "Value", "OhneHilfeZurechtJN"),
                                                    new DataBindingHelper(opKannGefahrenNichtEinschaetzen, "Value", "KannGefahrenNichtEinschaetzen"),
                                                    new DataBindingHelper(opInDerEinrichtungVerirrn, "Value", "InDerEinrichtungVerirrn"),
                                                    new DataBindingHelper(opSicherheit, "Value", "Sicherheit"),
                                                    new DataBindingHelper(opMedikamenteneinnahmeUeberwachen, "Value", "MedikamenteneinnahmeUeberwachen")
                                                    });

            
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
