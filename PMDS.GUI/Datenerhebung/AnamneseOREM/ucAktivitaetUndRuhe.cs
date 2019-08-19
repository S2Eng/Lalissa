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
    public partial class ucAktivitaetUndRuhe : ucAnamneseModellgruppeBase
    {
        public ucAktivitaetUndRuhe()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.AktivitaetUndRuhe;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opSichBewegenProblemeJN, "Value", "SichBewegenProblemeJN"), 
                                                    new DataBindingHelper(tbSichBewegenProbleme, "Text", "SichBewegenProbleme"),
                                                    new DataBindingHelper(dtpSichBewegenProblemeSeit, "Value", "SichBewegenProblemeSeit"),
                                                    new DataBindingHelper(tbBeobachtungenSichBewegen, "Text", "BeobachtungenSichBewegen"),
                                                    new DataBindingHelper(opBewegungImBett, "Value", "BewegungImBett"),
                                                    new DataBindingHelper(tbBewegungImBettBeschreibung, "Text", "BewegungImBettBeschreibung"),
                                                    new DataBindingHelper(opTransferBettAussehalb, "Value", "TransferBettAussehalb"),
                                                    new DataBindingHelper(tbTransferBettAussehalbBeschreibung, "Text", "TransferBettAussehalbBeschreibung"),
                                                    new DataBindingHelper(opMobilImRollstuhl, "Value", "MobilImRollstuhl"),
                                                    new DataBindingHelper(tbMobilImRollstuhlBeschreibung, "Text", "MobilImRollstuhlBeschreibung"),
                                                    new DataBindingHelper(opFortbewegungZuFuss, "Value", "FortbewegungZuFuss"),
                                                    new DataBindingHelper(tbFortbewegungZuFussBeschreibung, "Text", "FortbewegungZuFussBeschreibung"),
                                                    new DataBindingHelper(tbBeobachtungSichBewegen, "Text", "BeobachtungSichBewegen"),
                                                    //new DataBindingHelper(tbRueckenmarklaesionProbleme, "Text", "RueckenmarklaesionProbleme"),
                                                    new DataBindingHelper(opEssenTrinken, "Value", "EssenTrinken"),
                                                    new DataBindingHelper(tbEssenTrinkenBeschreibung, "Text", "EssenTrinkenBeschreibung"),
                                                    new DataBindingHelper(opKoerperpflage, "Value", "Koerperpflage"),
                                                    new DataBindingHelper(tbKoerperpflageBeschreibung, "Text", "KoerperpflageBeschreibung"),
                                                    new DataBindingHelper(opKleiden, "Value", "Kleiden"),
                                                    new DataBindingHelper(tbKleidenBeschreibung, "Text", "KleidenBeschreibung"),
                                                    new DataBindingHelper(opSelbstpflageHarnTag, "Value", "SelbstpflageHarnTag"),
                                                    new DataBindingHelper(opSelbstpflageHarnNacht, "Value", "SelbstpflageHarnNacht"),
                                                    new DataBindingHelper(opSelbstpflageStuhlTag, "Value", "SelbstpflageStuhlTag"),
                                                    new DataBindingHelper(opSelbstpflageStuhlNacht, "Value", "SelbstpflageStuhlNacht"),
                                                    new DataBindingHelper(tbSelbstpflagedefizitBeschreibung, "Text", "SelbstpflagedefizitBeschreibung"),
                                                    new DataBindingHelper(opHaushalt, "Value", "Haushalt"),
                                                    new DataBindingHelper(tbHaushaltBeschreibung, "Text", "HaushaltBeschreibung"),
                                                    new DataBindingHelper(opFreizeit, "Value", "Freizeit"),
                                                    new DataBindingHelper(tbFreizeitBerschreibung, "Text", "FreizeitBerschreibung"),
                                                    new DataBindingHelper(tbSelbstpflagedefizitGewohnheiten, "Text", "SelbstpflagedefizitGewohnheiten"),
                                                    new DataBindingHelper(tbBeobachtungenSelbstpflagedefizit, "Text", "BeobachtungenSelbstpflagedefizit"),
                                                    new DataBindingHelper(opSchlafproblemeJN, "Value", "SchlafproblemeJN"),
                                                    new DataBindingHelper(tbSchlafprobleme, "Text", "Schlafprobleme"),
                                                    new DataBindingHelper(dtpSchlafproblemeSeit, "Value", "SchlafproblemeSeit"),
                                                    new DataBindingHelper(tbBeobachtungenSchlafprobleme, "Text", "BeobachtungenSchlafprobleme")
                                                    });
            BindData();
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// ErrorProvider initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitErrorProvider()
        {
            errorProvider1.SetError(dtpSchlafproblemeSeit, "");
            errorProvider1.SetError(dtpSichBewegenProblemeSeit, "");
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public override bool ValidateFields()
        {
            bool bError = false, tabSelected = false;
            string error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen.");
            InitErrorProvider();

            if (dtpSichBewegenProblemeSeit.Value != null && ((DateTime)dtpSichBewegenProblemeSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpSichBewegenProblemeSeit, error);
            }

            if (bError)
            {
                tabAktivitaet.SelectedTab = tabAktivitaet.Tabs[0];
                tabSelected = true;
            }

            if (dtpSchlafproblemeSeit.Value != null && ((DateTime)dtpSchlafproblemeSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpSchlafproblemeSeit, error);
            }

            if(bError && ! tabSelected)
                tabAktivitaet.SelectedTab = tabAktivitaet.Tabs[2];

            if (bError)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(error);
            return !bError;
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
