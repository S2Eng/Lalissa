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
    public partial class ucKommunizieren : ucAnamneseModellgruppeBase
    {
        public ucKommunizieren()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.Kommunizieren;

            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opBrilleJN, "Value", "BrilleJN"), 
                                                    new DataBindingHelper(opHoergeraetJN, "Value", "HoergeraetJN"),
                                                    new DataBindingHelper(opKannMitteilenJN, "Value", "KannMitteilenJN"),
                                                    new DataBindingHelper(txtWuensche, "Text", "Wuensche"),
                                                    new DataBindingHelper(opSchwerhoerigTaubStummBlind, "Value", "SchwerhoerigTaubStummBlind"),
                                                    new DataBindingHelper(opHoergeraetNichtHandhaben, "Value", "HoergeraetNichtHandhaben"),
                                                    new DataBindingHelper(opSprachstoerungen, "Value", "Sprachstoerungen"),
                                                    new DataBindingHelper(opSichtfeldeinschraenkungen, "Value", "Sichtfeldeinschraenkungen"),
                                                    new DataBindingHelper(opIstZeitloertlSituativZurPersonNichtOrientiert, "Value", "IstZeitloertlSituativZurPersonNichtOrientiert")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
