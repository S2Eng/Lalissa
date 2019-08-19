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


    public partial class ucBiographie : ucAnamneseModellgruppeBase
    {
        public ucBiographie()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.Biographie;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtBiographie, "Text", "Biographie"),
                                                    new DataBindingHelper(opUnbewaeltigtenLebenserfahrungen, "Value", "UnbewaeltigtenLebenserfahrungen"),
                                                    new DataBindingHelper(txtVermisstBeschreibung, "Text", "VermisstBeschreibung"),
                                                    new DataBindingHelper(opVermisst, "Value", "Vermisst"),
                                                    new DataBindingHelper(txtSorgeUm, "Text", "SorgeUm"),
                                                    new DataBindingHelper(opHatSorge, "Value", "HatSorge")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
