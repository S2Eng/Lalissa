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
    public partial class ucWasserPOP : ucAnamneseModellgruppeBase
    {
        public ucWasserPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)POPModellgruppen.Wasser;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opFluessigkeitsproblemeJN, "Value", "FluessigkeitsproblemeJN"), 
                                                    new DataBindingHelper(tbFluessigkeitsprobleme, "Text", "Fluessigkeitsprobleme"),
                                                    new DataBindingHelper(dtpFluessigkeitsproblemeSeit, "Value", "FluessigkeitsproblemeSeit"),
                                                    new DataBindingHelper(opDurstgefuehl, "Value", "Durstgefuehl"),
                                                    new DataBindingHelper(tbTrinkmenge, "Value", "Trinkmenge"),
                                                    new DataBindingHelper(tbZungeAussehen, "Text", "ZungeAussehen"),
                                                    new DataBindingHelper(tbTrinkhilfen, "Text", "Trinkhilfen"),
                                                    new DataBindingHelper(tbHautturgor, "Text", "Hautturgor"),
                                                    new DataBindingHelper(tbOedeme, "Text", "Oedeme"),
                                                    new DataBindingHelper(tbBeobachtungFluessigkeitsprobleme, "Text", "BeobachtungFluessigkeitsprobleme")
                                                    });

            
            
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
