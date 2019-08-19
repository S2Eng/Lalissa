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
    public partial class ucSozialeBereiche : ucAnamneseModellgruppeBase
    {
        public ucSozialeBereiche()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.SozialeBereicheDesLebensSichern;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(txtKontakte, "Text", "Kontakte"), 
                                                    new DataBindingHelper(txtKeinekontakte, "Text", "Keinekontakte"),
                                                    new DataBindingHelper(txtZeitKeineBesuche, "Text", "ZeitKeineBesuche"),
                                                    new DataBindingHelper(txtAndereKontakte, "Text", "AndereKontakte"),
                                                    new DataBindingHelper(opKontakteSelbsstaendigHerstellenJN, "Value", "KontakteSelbsstaendigHerstellenJN"),
                                                    new DataBindingHelper(opBewohnerBenoetigtAktivierung, "Value", "BewohnerBenoetigtAktivierung"),
                                                    new DataBindingHelper(opHilfeBeiDerKontakpflege, "Value", "HilfeBeiDerKontakpflege"),
                                                    new DataBindingHelper(opInBetreuungImHausIntegrieren, "Value", "InBetreuungImHausIntegrieren")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
