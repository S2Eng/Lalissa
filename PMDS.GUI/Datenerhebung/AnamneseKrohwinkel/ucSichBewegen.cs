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
    public partial class ucSichBewegen : ucAnamneseModellgruppeBase
    {
        public ucSichBewegen()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)KrohwinkelModellgruppen.SichBewegen;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }
        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opKannSelbstBewegenJN, "Value", "KannSelbstBewegenJN"), 
                                                    new DataBindingHelper(opGehentJN, "Value", "GehentJN"),
                                                    new DataBindingHelper(opStehenJN, "Value", "StehenJN"),
                                                    new DataBindingHelper(opSitzenJN, "Value", "SitzenJN"),
                                                    new DataBindingHelper(opTreppenSteigenJN, "Value", "TreppenSteigenJN"),
                                                    new DataBindingHelper(opLaufenJN, "Value", "LaufenJN"),
                                                    new DataBindingHelper(opHinsetzenJN, "Value", "HinsetzenJN"),
                                                    new DataBindingHelper(opHinlegen, "Value", "HinlegenJN"),
                                                    new DataBindingHelper(opHilfsmittelBenutzenJN, "Value", "HilfsmittelBenutzenJN"),
                                                    new DataBindingHelper(opSpatzierenGehenJN, "Value", "SpatzierenGehenJN"),
                                                    new DataBindingHelper(txtWannWieOftSpatzieren, "Text", "WannWieOftSpatzieren"),
                                                    new DataBindingHelper(opKoerperlicheaktivitaetenJN, "Value", "KoerperlicheaktivitaetenJN"),
                                                    new DataBindingHelper(txtAktivitaetenBeschreibung, "Text", "AktivitaetenBeschreibung"),
                                                    new DataBindingHelper(opKontrakturenvorhandenJN, "Value", "KontrakturenvorhandenJN"),
                                                    new DataBindingHelper(cbSpitzfussstellungJN, "Checked", "SpitzfussstellungJN"),
                                                    new DataBindingHelper(cbMaxGebEllenbogenJN, "Checked", "MaxGebEllenbogenJN"),
                                                    new DataBindingHelper(cbKniegelenkJN, "Checked", "KniegelenkJN"),
                                                    new DataBindingHelper(cbGefausteteHandJN, "Checked", "GefausteteHandJN"),
                                                    new DataBindingHelper(txtKontrakturenBeschreibung, "Text", "KontrakturenBeschreibung"),
                                                    new DataBindingHelper(opDekubitusVorhandenJN, "Value", "DekubitusVorhandenJN"),
                                                    new DataBindingHelper(txtDekubitusBeschreibung, "Text", "DekubitusBeschreibung"),
                                                    new DataBindingHelper(opSturtzgefahrJN, "Value", "SturtzgefahrJN"),
                                                    new DataBindingHelper(opBewegungseinschraenkung, "Value", "Bewegungseinschraenkung"),
                                                    new DataBindingHelper(opKannNichtAlleinGehen, "Value", "KannNichtAlleinGehen"),
                                                    new DataBindingHelper(opLageImBettVeraendern, "Value", "KannNichtAlleinLageImBettVeraendern"),
                                                    new DataBindingHelper(opIstBettlaegerig, "Value", "IstBettlaegerig"),
                                                    new DataBindingHelper(opTransferAufstehenHinlegen, "Value", "TransferAufstehenHinlegen")
                                                    });
            BindData();
        }
        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
