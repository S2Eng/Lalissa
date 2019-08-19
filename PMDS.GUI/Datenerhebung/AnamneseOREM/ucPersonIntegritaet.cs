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
    public partial class ucPersonIntegritaet : ucAnamneseModellgruppeBase
    {
        public ucPersonIntegritaet()
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
                                                    new DataBindingHelper(opAngehoerigeBetreuungskonzeptMiteinbeziehenJN, "Value", "AngehoerigeBetreuungskonzeptMiteinbeziehenJN"),
                                                    new DataBindingHelper(tbBetreuungskonseptAngaben, "Text", "BetreuungskonseptAngaben"),
                                                    new DataBindingHelper(opFaehigkeitEntscheidungenZuTreffenJN, "Value", "FaehigkeitEntscheidungenZuTreffenJN"),
                                                    new DataBindingHelper(tbFaehigkeitEntscheidungenZuTreffenAngaben, "Text", "FaehigkeitEntscheidungenZuTreffenAngaben"),
                                                    new DataBindingHelper(opFaehigkeitLebensanforderungenBegegnenZuKoennenJN, "Value", "FaehigkeitLebensanforderungenBegegnenZuKoennenJN"),
                                                    new DataBindingHelper(tbBeobachtungenLebensanforderungen, "Text", "BeobachtungenLebensanforderungen"),
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
                                                    new DataBindingHelper(tbAeusserungenVonVerzweiflungVeraenderteLebensenergien, "Text", "AeusserungenVonVerzweiflungVeraenderteLebensenergien"),
                                                    new DataBindingHelper(tbBeobachtungenVeraenderteLebensenergien, "Text", "BeobachtungenVeraenderteLebensenergien"),
                                                    new DataBindingHelper(opKannInfoZurSituationUmsetzenJN, "Value", "KannInfoZurSituationUmsetzenJN"),
                                                    new DataBindingHelper(tbBeobachtungenInfoZurSituationUmsetzen, "Text", "BeobachtungenInfoZurSituationUmsetzen"),
                                                    new DataBindingHelper(opFaehigkeitGedankenRichtigZuVerarbeitenJN, "Value", "FaehigkeitGedankenRichtigZuVerarbeitenJN"),
                                                    new DataBindingHelper(tbBeobachtungenGedankenRichtigZuVerarbeiten, "Text", "BeobachtungenGedankenRichtigZuVerarbeiten"),
                                                    new DataBindingHelper(opBemerkbareTrauerreaktionJN, "Value", "BemerkbareTrauerreaktionJN"),
                                                    new DataBindingHelper(tbBemerkbareTrauerreaktion, "Text", "BemerkbareTrauerreaktion"),
                                                    new DataBindingHelper(opHinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN, "Value", "HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN"),
                                                    new DataBindingHelper(tbHinweiseVermehrteBeschaeftigung, "Text", "HinweiseVermehrteBeschaeftigung"),
                                                    new DataBindingHelper(opAngstzustaendeJN, "Value", "AngstzustaendeJN"),
                                                    new DataBindingHelper(tbAngstzustaende, "Text", "Angstzustaende"),
                                                    new DataBindingHelper(opSituationVorDerSichFuerchtenJN, "Value", "SituationVorDerSichFuerchtenJN"),
                                                    new DataBindingHelper(tbSituationVorDerSichFuerchten, "Text", "SituationVorDerSichFuerchten"),
                                                    new DataBindingHelper(tbPflegendenAngehoerigeProbleme, "Text", "PflegendenAngehoerigeProbleme")
                                                    });

            BindData();
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
