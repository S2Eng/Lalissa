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
    public partial class ucSichAlsManFrauFuehlen : ucAnamneseModellgruppeBase
    {
        public ucSichAlsManFrauFuehlen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.SichAlsMannFrauFuehlen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtMaennlicheWeiblichePflegeperson, "Text", "MaennlicheWeiblichePflegeperson"), 
                                                    new DataBindingHelper(txtMakeUpSchmuck, "Text", "MakeUpSchmuck"),
                                                    new DataBindingHelper(txtHaarBarttracht, "Text", "HaarBarttracht"),
                                                    new DataBindingHelper(opSchagefuehlIntimepflegeBeruecksichtigen, "Value", "SchagefuehlIntimepflegeBeruecksichtigen"),
                                                    new DataBindingHelper(opMaennlicheWeiblicheBestimmtePflegeperson, "Value", "WuenschtMaennlicheWeiblicheBestimmtePflegeperson"),
                                                    new DataBindingHelper(opKannFrisurNichtSelbstHerrichten, "Value", "KannFrisurNichtSelbstHerrichten"),
                                                    new DataBindingHelper(opKannSchmuckNichtSelbstAnlegen, "Value", "KannSchmuckNichtSelbstAnlegen")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
