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

    public partial class ucAusscheiden : ucAnamneseModellgruppeBase
    {


        public ucAusscheiden()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.Ausscheiden;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opKannBlaseDarmKontrollierenJN, "Value", "KannBlaseDarmKontrollierenJN"),
                                                    new DataBindingHelper(txtZeitenToiletteAufsuchen, "Text", "ZeitenToiletteAufsuchen"),
                                                    new DataBindingHelper(opToilettengangHilfeJN, "Value", "ToilettengangHilfeJN"),
                                                    new DataBindingHelper(txtToilettenHilfsmittel, "Text", "ToilettenHilfsmittel"),
                                                    new DataBindingHelper(txtMedikamenteBlasenDarmfunktion, "Text", "MedikamenteBlasenDarmfunktion"),
                                                    new DataBindingHelper(opIstZeitweiseUrinStuhlinkontinent, "Value", "IstZeitweiseUrinStuhlinkontinent"),
                                                    new DataBindingHelper(cmbZeitlUrinStuhlKrankheit, "Value", "ZeitlUrinStuhlKrankheit"),
                                                    new DataBindingHelper(cmbUrinStuhlKrankheit, "Value", "UrinStuhlKrankheit"),
                                                    new DataBindingHelper(opVerstopfungenDurchfaellen, "Value", "VerstopfungenDurchfaellen"),
                                                    new DataBindingHelper(cmbZeitlVerstopfungDurchfallKrakheit, "Value", "ZeitlVerstopfungDurchfallKrakheit"),
                                                    new DataBindingHelper(cmbVerstopfungDurchfallKrakheit, "Value", "VerstopfungDurchfallKrakheit"),
                                                    new DataBindingHelper(opDauerSuprapubischenkatheter, "Value", "DauerSuprapubischenkatheter"),
                                                    new DataBindingHelper(opNeigtZuInfektionen, "Value", "NeigtZuInfektionen"),
                                                    new DataBindingHelper(opHatAnusPraeter, "Value", "HatAnusPraeter"),
                                                    new DataBindingHelper(opToiletteNichtSelbstaendigBenutzen, "Value", "KannToiletteNichtSelbstaendigBenutzen"),
                                                    new DataBindingHelper(opUnterstuetzungEinnahmeAbfuehrmittel, "Value", "UnterstuetzungEinnahmeAbfuehrmittel")
                                                    });
            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
