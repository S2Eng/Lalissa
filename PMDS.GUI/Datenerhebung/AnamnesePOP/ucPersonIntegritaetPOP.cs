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
    public partial class ucPersonIntegritaetPOP : ucAnamneseModellgruppeBase
    {
        public ucPersonIntegritaetPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.IntegritaetDerPerson;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opFaehigkeitGesundheitszustandUmzugehenJN, "Value", "FaehigkeitGesundheitszustandUmzugehenJN"), 
                                                    new DataBindingHelper(tbFaehigkeitGesundheitszustandAngaben, "Text", "FaehigkeitGesundheitszustandAngaben"),
                                                    new DataBindingHelper(tbBeobachtungenFaehigkeitGesundheitszustand, "Text", "BeobachtungenFaehigkeitGesundheitszustand"),                                                 
                                                    new DataBindingHelper(opFaehigkeitVorhandeneRessourcenZuErkennenJN, "Value", "FaehigkeitVorhandeneRessourcenZuErkennenJN"),
                                                    new DataBindingHelper(tbBeobachtungenFaehigkeitVorhandeneRessourcen, "Text", "BeobachtungenFaehigkeitVorhandeneRessourcen"),                                                  
                                                    new DataBindingHelper(opKannBehandlungsprogrammAkzeptierenJN, "Value", "KannBehandlungsprogrammAkzeptierenJN"),
                                                    new DataBindingHelper(tbBeobachtungenBehandlungsprogramm, "Text", "BeobachtungenBehandlungsprogramm"),                                                  
                                                    new DataBindingHelper(opErkenntGesungheitsfoerdendeMassnahmenJN, "Value", "ErkenntGesungheitsfoerdendeMassnahmenJN"),
                                                    new DataBindingHelper(tbGesungheitsfoerdendeMassnahmen, "Text", "GesungheitsfoerdendeMassnahmen"),                                                    new DataBindingHelper(tbBeobachtungenGesungheitsfoerdendeMassnahmen, "Text", "BeobachtungenGesungheitsfoerdendeMassnahmen"),                                                    
                                                    new DataBindingHelper(opFaehigkeitEntscheidungenZuTreffenJN, "Value", "FaehigkeitEntscheidungenZuTreffenJN"),
                                                    new DataBindingHelper(tbFaehigkeitEntscheidungenZuTreffenAngaben, "Text", "FaehigkeitEntscheidungenZuTreffenAngaben"),
                                                    new DataBindingHelper(opFaehigkeitLebensanforderungenBegegnenZuKoennenJN, "Value", "FaehigkeitLebensanforderungenBegegnenZuKoennenJN"),
                                                    new DataBindingHelper(tbBeobachtungenLebensanforderungen, "Text", "BeobachtungenLebensanforderungen"),
                                                    new DataBindingHelper(opAeusserungenVonVerzweiflungVeraenderteLebensenergienJN, "Value", "AeusserungenVonVerzweiflungVeraenderteLebensenergienJN"),
                                                    new DataBindingHelper(tbAeusserungenVonVerzweiflungVeraenderteLebensenergien, "Text", "AeusserungenVonVerzweiflungVeraenderteLebensenergien"),
                                                    new DataBindingHelper(tbBeobachtungenVeraenderteLebensenergien, "Text", "BeobachtungenVeraenderteLebensenergien"),
                                                    new DataBindingHelper(opMoeglichkeitUmgebungsveraenderungAnzupassenJN, "Value", "MoeglichkeitUmgebungsveraenderungAnzupassenJN"),
                                                    new DataBindingHelper(tbBeobachtungenUmgebungsveraenderung, "Text", "BeobachtungenUmgebungsveraenderung"),
                                                    new DataBindingHelper(opEigeneKoerperAkzeptanzJN, "Value", "EigeneKoerperAkzeptanzJN"),
                                                    new DataBindingHelper(tbEigeneKoerperAkzeptanzAngaben, "Text", "EigeneKoerperAkzeptanzAngaben"),
                                                    new DataBindingHelper(opEigenPersonFaehigkeitenWertschaetzungen, "Value", "EigenPersonFaehigkeitenWertschaetzungen"),
                                                    new DataBindingHelper(tbBeobachtungenEigenPersonFaehigkeitenWertschaetzungen, "Text", "BeobachtungenEigenPersonFaehigkeitenWertschaetzungen"),
                                                    new DataBindingHelper(tbUmfeldRealitaetsbezug, "Text", "UmfeldRealitaetsbezug"),
                                                    new DataBindingHelper(opSinneswahrnehmungUngestoertJN, "Value", "SinneswahrnehmungUngestoertJN"),
                                                    new DataBindingHelper(tbSinneswahrnehmung, "Text", "Sinneswahrnehmung"),
                                                    new DataBindingHelper(tbSinneswahrnehmungSonstigeAngaben, "Text", "SinneswahrnehmungSonstigeAngaben"),
                                                    new DataBindingHelper(opKannInfoZurSituationUmsetzenJN, "Value", "KannInfoZurSituationUmsetzenJN"),
                                                    new DataBindingHelper(tbBeobachtungenInfoZurSituationUmsetzen, "Text", "BeobachtungenInfoZurSituationUmsetzen"),
                                                    new DataBindingHelper(opFaehigkeitGedankenRichtigZuVerarbeitenJN, "Value", "FaehigkeitGedankenRichtigZuVerarbeitenJN"),
                                                    new DataBindingHelper(tbBeobachtungenGedankenRichtigZuVerarbeiten, "Text", "BeobachtungenGedankenRichtigZuVerarbeiten"),
                                                    new DataBindingHelper(tbSubjektivesSinneerlebenAngaben, "Text", "SubjektivesSinneerlebenAngaben"),
                                                    new DataBindingHelper(tbBeobachtungenSubjektivesSinneerleben, "Text", "BeobachtungenSubjektivesSinneerleben"),
                                                    new DataBindingHelper(opBemerkbareTrauerreaktionJN, "Value", "BemerkbareTrauerreaktionJN"),
                                                    new DataBindingHelper(tbBemerkbareTrauerreaktion, "Text", "BemerkbareTrauerreaktion"),
                                                    new DataBindingHelper(dtpBemerkbareTrauerreaktionSeit, "Value", "BemerkbareTrauerreaktionSeit"),
                                                    new DataBindingHelper(opHinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN, "Value", "HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN"),
                                                    new DataBindingHelper(tbHinweiseVermehrteBeschaeftigung, "Text", "HinweiseVermehrteBeschaeftigung"),
                                                    new DataBindingHelper(opAngstzustaendeJN, "Value", "AngstzustaendeJN"),
                                                    new DataBindingHelper(tbAngstzustaende, "Text", "Angstzustaende"),
                                                    new DataBindingHelper(opSituationVorDerSichFuerchtenJN, "Value", "SituationVorDerSichFuerchtenJN"),
                                                    new DataBindingHelper(tbSituationVorDerSichFuerchten, "Text", "SituationVorDerSichFuerchten"),
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }

    }
}
