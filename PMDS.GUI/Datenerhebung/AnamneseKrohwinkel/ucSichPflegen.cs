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
    public partial class ucSichPflegen : ucAnamneseModellgruppeBase
    {
        public ucSichPflegen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.SichPflegen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtWieHandhabenMitDuschenBaden, "Text", "WieHandhabenMitDuschenBaden"), 
                                                    new DataBindingHelper(txtKoerperpflegemittel, "Text", "Koerperpflegemittel"), 
                                                    new DataBindingHelper(txtKoerperpflegemittelVersorger, "Text", "KoerperpflegemittelVersorger"), 
                                                    new DataBindingHelper(txtRasieren, "Text", "Rasieren"),
                                                    new DataBindingHelper(txtHaarpflege, "Text", "Haarpflege"),
                                                    new DataBindingHelper(opZahnFusspflegeHilfeJN, "Value", "ZahnFusspflegeHilfeJN"),
                                                    new DataBindingHelper(opSchminkenJN, "Value", "SchminkenJN"),
                                                    new DataBindingHelper(opHilfebWaschenDuschenBaden, "Value", "HilfebWaschenDuschenBaden"),
                                                    new DataBindingHelper(opHilfebHaareOberUnterkoerper, "Value", "HilfebHaareOberUnterkoerper"),
                                                    new DataBindingHelper(opHilfebRasur, "Value", "HilfebRasur"),
                                                    new DataBindingHelper(opHilfebFussFingernagelpflege, "Value", "HilfebFussFingernagelpflege"),
                                                    new DataBindingHelper(opHilfebIntimpflege, "Value", "HilfebIntimpflege"),
                                                    new DataBindingHelper(opHilfebHautGesichtspflege, "Value", "HilfebHautGesichtspflege"),
                                                    new DataBindingHelper(opHilfebOhrenNasenAugenpflege, "Value", "HilfebOhrenNasenAugenpflege"),
                                                    new DataBindingHelper(opHilfebMundZahnpflege, "Value", "HilfebMundZahnpflege"),
                                                    new DataBindingHelper(opHilfebHautdefekte, "Value", "HilfebHautdefekte"),
                                                    new DataBindingHelper(opStarkschwitzen, "Value", "Starkschwitzen")
                                                    });
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
