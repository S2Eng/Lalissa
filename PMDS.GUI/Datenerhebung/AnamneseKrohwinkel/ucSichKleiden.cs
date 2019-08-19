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
    public partial class ucSichKleiden : ucAnamneseModellgruppeBase
    {
        public ucSichKleiden()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.Sichkleiden;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtKleidung, "Text", "Kleidung"), 
                                                    new DataBindingHelper(txtWaeschewechsel, "Text", "Waeschewechsel"),
                                                    new DataBindingHelper(opkleiderauswahlHilfe, "Value", "KleiderauswahlHilfe"),
                                                    new DataBindingHelper(opOefterAusziehen, "Value", "WegenDesoriontiertheitOefterAusziehen"),
                                                    new DataBindingHelper(opAngemesseneKleidung, "Value", "FehlendeEinsichtFuerAngemesseneKleidung"),
                                                    new DataBindingHelper(opWaeschewechsel, "Value", "FehlendeEinsichtFuerNotwendigeWaeschewechsel"),
                                                    new DataBindingHelper(opVerschluesseNichtHandhaben, "Value", "KannVerschluesseNichtHandhaben"),
                                                    new DataBindingHelper(opKleidungUeberKopfAusziehen, "Value", "KannNichtKleidungUeberKopfAusziehen"),
                                                    new DataBindingHelper(opKleidungUeberFusseAnziehen, "Value", "KannNichtKleidungUeberFusseAnziehen")
                                                    });

            
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
