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
    public partial class ucAktivitaetUndRuhePOP : ucAnamneseModellgruppeBase
    {
        public ucAktivitaetUndRuhePOP()
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
                                                    new DataBindingHelper(opMobilitaetBeeintraechtigtJN, "Value", "MobilitaetBeeintraechtigtJN"),
                                                    new DataBindingHelper(tbMobilitaetBeeintraechtigt, "Text", "MobilitaetBeeintraechtigt"),
                                                    new DataBindingHelper(dtpMobilitaetBeintraechtigtSeit, "Value", "MobilitaetBeeintraechtigtSeit"),
                                                    new DataBindingHelper(tbMobilitaetBeeintraechtigt, "Text", "BeobachtungenMobilitaetBeeintraechtigt"),
                                                    new DataBindingHelper(opBewegungImBett, "Value", "BewegungImBett"),
                                                    new DataBindingHelper(tbBewegungImBettBeschreibung, "Text", "BewegungImBettBeschreibung"),
                                                    new DataBindingHelper(opTransferBettAussehalb, "Value", "TransferBettAussehalb"),
                                                    new DataBindingHelper(tbTransferBettAussehalbBeschreibung, "Text", "TransferBettAussehalbBeschreibung"),
                                                    new DataBindingHelper(opMobilImRollstuhl, "Value", "MobilImRollstuhl"),
                                                    new DataBindingHelper(tbMobilImRollstuhlBeschreibung, "Text", "MobilImRollstuhlBeschreibung"),
                                                    new DataBindingHelper(opFortbewegungZuFuss, "Value", "FortbewegungZuFuss"),
                                                    new DataBindingHelper(tbFortbewegungZuFussBeschreibung, "Text", "FortbewegungZuFussBeschreibung"),
                                                    new DataBindingHelper(tbBeobachtungSichBewegen, "Text", "BeobachtungSichBewegen"),
                                                    new DataBindingHelper(opSelbstpflegedefizitJN, "Value", "SelbstpflegedefizitJN"),
                                                    new DataBindingHelper(opEssenTrinken, "Value", "EssenTrinken"),
                                                    new DataBindingHelper(tbEssenTrinkenBeschreibung, "Text", "EssenTrinkenBeschreibung"),
                                                    new DataBindingHelper(opKoerperpflege, "Value", "Koerperpflege"),
                                                    new DataBindingHelper(tbKoerperpflegeBeschreibung, "Text", "KoerperpflegeBeschreibung"),
                                                    new DataBindingHelper(opKleiden, "Value", "Kleiden"),
                                                    new DataBindingHelper(tbKleidenBeschreibung, "Text", "KleidenBeschreibung"),
                                                    new DataBindingHelper(opSelbstpflegeHarnTag, "Value", "SelbstpflegeHarnTag"),
                                                    new DataBindingHelper(opSelbstpflegeHarnNacht, "Value", "SelbstpflegeHarnNacht"),
                                                    new DataBindingHelper(opSelbstpflegeStuhlTag, "Value", "SelbstpflegeStuhlTag"),
                                                    new DataBindingHelper(opSelbstpflegeStuhlNacht, "Value", "SelbstpflegeStuhlNacht"),
                                                    new DataBindingHelper(tbSelbstpflegedefizitBeschreibung, "Text", "SelbstpflegedefizitBeschreibung"),
                                                    new DataBindingHelper(opSelbstorganisationJN, "Value", "SelbstorganisationJN"),
                                                    new DataBindingHelper(opSelbstorganisation, "Value", "Selbstorganisation"),
                                                    new DataBindingHelper(tbSelbstorganisationBeschreibung, "Text", "SelbstorganisationtBeschreibung"),                                                    
                                                    new DataBindingHelper(opBeschaeftigung, "Value", "Beschaeftigung"),
                                                    new DataBindingHelper(tbBeschaeftigungBeschreibung, "Text", "BeschaeftigungBeschreibung"),
                                                    new DataBindingHelper(opHaushalt, "Value", "Haushalt"),
                                                    new DataBindingHelper(tbHaushaltBeschreibung, "Text", "HaushaltBeschreibung"),
                                                    new DataBindingHelper(opFreizeit, "Value", "Freizeit"),
                                                    new DataBindingHelper(tbFreizeitBeschreibung, "Text", "FreizeitBeschreibung"),
                                                    new DataBindingHelper(tbSelbstpflegedefizitGewohnheiten, "Text", "SelbstpflegedefizitGewohnheiten"),
                                                    new DataBindingHelper(tbBeobachtungenSelbstpflegedefizit, "Text", "BeobachtungenSelbstpflegedefizit"),
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

        private void dtpMobilitaetBeintraechtigtSeit_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
