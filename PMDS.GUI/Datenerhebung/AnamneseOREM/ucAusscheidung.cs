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
    public partial class ucAusscheidung : ucAnamneseModellgruppeBase
    {
        public ucAusscheidung()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.Ausscheidung;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opStuhlgangProblemeJN, "Value", "StuhlgangProblemeJN"), 
                                                    new DataBindingHelper(tbStuhlgangProbleme, "Text", "StuhlgangProbleme"),
                                                    new DataBindingHelper(dtpStuhlgangProblemeSeit, "Value", "StuhlgangProblemeSeit"),
                                                    new DataBindingHelper(dtpLetzterStuhlAm, "Value", "LetzterStuhlAm"),
                                                    new DataBindingHelper(tbStuhlgangAuffaelligkeitenVeraenderungBezHaeufigkeit, "Text", "StuhlgangAuffaelligkeitenVeraenderungBezHaeufigkeit"),
                                                    new DataBindingHelper(tbStuhlgangAuffaelligkeitenVeraenderungBezMenge, "Text", "StuhlgangAuffaelligkeitenVeraenderungBezMenge"),
                                                    new DataBindingHelper(tbStuhlgangAuffaelligkeitenVeraenderungBezFarbe, "Text", "StuhlgangAuffaelligkeitenVeraenderungBezFarbe"),
                                                    new DataBindingHelper(tbStuhlgangAuffaelligkeitenVeraenderungBezGeruch, "Text", "StuhlgangAuffaelligkeitenVeraenderungBezGeruch"),
                                                    new DataBindingHelper(tbStuhlgangAuffaelligkeitenVeraenderungBezKonsistenz, "Text", "StuhlgangAuffaelligkeitenVeraenderungBezKonsistenz"),
                                                    new DataBindingHelper(tbAbfuehrhilfen, "Text", "Abfuehrhilfen"),
                                                    new DataBindingHelper(tbKuenstlicheAusgang, "Text", "KuenstlicheAusgang"),
                                                    new DataBindingHelper(dtpKuenstlicheAusgangSeit, "Value", "KuenstlicheAusgangSeit"),
                                                    new DataBindingHelper(tbStuhlgangBesondereGewohnheiten, "Text", "StuhlgangBesondereGewohnheiten"),
                                                    new DataBindingHelper(tbBeobachtungenStuhlgangProbleme, "Text", "BeobachtungenStuhlgangProbleme"),
                                                    new DataBindingHelper(opUrinausscheidungProblemeJN, "Value", "UrinausscheidungProblemeJN"),
                                                    new DataBindingHelper(tbUrinausscheidungProbleme, "Text", "UrinausscheidungProbleme"),
                                                    new DataBindingHelper(dtpUrinausscheidungProblemeSeit, "Value", "UrinausscheidungProblemeSeit"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueber, "Value", "UrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueber"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueberZeitabstand, "Value", "UrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueberZeitabstand"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachts, "Value", "UrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachts"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachtsZeitabstand, "Value", "UrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachtsZeitabstand"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezMenge, "Text", "UrinAuffaelligkeitenVeraenderungBezMenge"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezFarbe, "Text", "UrinAuffaelligkeitenVeraenderungBezFarbe"),
                                                    new DataBindingHelper(tbUrinAuffaelligkeitenVeraenderungBezGeruch, "Text", "UrinAuffaelligkeitenVeraenderungBezGeruch"),
                                                    new DataBindingHelper(tbHarnableitungssystemArt, "Text", "HarnableitungssystemArt"),
                                                    new DataBindingHelper(dtpHarnableitungssystemGelegtAm, "Value", "HarnableitungssystemGelegtAm"),
                                                    new DataBindingHelper(tbHarnableitungssystemGrosse, "Value", "HarnableitungssystemGrosse"),
                                                    new DataBindingHelper(tbBeobachtungenUrinausscheidungProbleme, "Text", "BeobachtungenUrinausscheidungProbleme"),
                                                    new DataBindingHelper(opHautProblemeJN, "Value", "HautProblemeJN"),
                                                    new DataBindingHelper(tbHautProbleme, "Text", "HautProbleme"),
                                                    new DataBindingHelper(opAussclagartigeHautveraendJN, "Value", "AussclagartigeHautveraendJN"),
                                                    new DataBindingHelper(tbAussclagartigeHautveraendIn, "Text", "AussclagartigeHautveraendIn"),
                                                    new DataBindingHelper(tbAussclagartigeHautveraend, "Text", "AussclagartigeHautveraend"),
                                                    new DataBindingHelper(opIntertrigoJN, "Value", "IntertrigoJN"),
                                                    new DataBindingHelper(tbIntertrigoIn, "Text", "IntertrigoIn"),
                                                    new DataBindingHelper(tbIntertrigo, "Text", "Intertrigo"),
                                                    new DataBindingHelper(opHaematomaPetechienBlutungenJN, "Value", "HaematomaPetechienBlutungenJN"),
                                                    new DataBindingHelper(tbHaematomaPetechienBlutungenIN, "Text", "HaematomaPetechienBlutungenIN"),
                                                    new DataBindingHelper(tbHaematomaPetechienBlutungen, "Text", "HaematomaPetechienBlutungen"),
                                                    new DataBindingHelper(opAnderWundenHautlaesionenJN, "Value", "AnderWundenHautlaesionenJN"),
                                                    new DataBindingHelper(tbAnderWundenHautlaesionenIn, "Text", "AnderWundenHautlaesionenIn"),
                                                    new DataBindingHelper(tbAnderWundenHautlaesionen, "Text", "AnderWundenHautlaesionen"),
                                                    new DataBindingHelper(tbDecubitus, "Text", "Decubitus"),
                                                    new DataBindingHelper(opSchweisssekretion, "Value", "Schweisssekretion"),
                                                    new DataBindingHelper(opSchweissHaeufigkeit, "Value", "SchweissHaeufigkeit"),
                                                    new DataBindingHelper(tbSchweissBesonderheiten, "Text", "SchweissBesonderheiten"),
                                                    new DataBindingHelper(tbBeobachtungenAusscheidung, "Text", "BeobachtungenAusscheidung")
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
            errorProvider1.SetError(dtpHarnableitungssystemGelegtAm, "");
            errorProvider1.SetError(dtpKuenstlicheAusgangSeit, "");
            errorProvider1.SetError(dtpLetzterStuhlAm, "");
            errorProvider1.SetError(dtpStuhlgangProblemeSeit, "");
            errorProvider1.SetError(dtpUrinausscheidungProblemeSeit, "");
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public override bool ValidateFields()
        {
            bool bError = false, tabSelected = false;
            string error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen.");
            InitErrorProvider();

            if (dtpStuhlgangProblemeSeit.Value != null && ((DateTime)dtpStuhlgangProblemeSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpStuhlgangProblemeSeit, error);
            }

            if (dtpLetzterStuhlAm.Value != null && ((DateTime)dtpLetzterStuhlAm.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpLetzterStuhlAm, error);
            }

            if (dtpKuenstlicheAusgangSeit.Value != null && ((DateTime)dtpKuenstlicheAusgangSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpKuenstlicheAusgangSeit, error);
            }

            //Fehler: Erste Tab selektieren
            if (bError)
            {
                tabAusscheidungen.SelectedTab = tabAusscheidungen.Tabs[0];
                tabSelected = true;
            }

            if (dtpUrinausscheidungProblemeSeit.Value != null && ((DateTime)dtpUrinausscheidungProblemeSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpUrinausscheidungProblemeSeit, error);
            }

            if (dtpHarnableitungssystemGelegtAm.Value != null && ((DateTime)dtpHarnableitungssystemGelegtAm.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpHarnableitungssystemGelegtAm, error);
            }

            //Fehler und kein Tab wurde selektiert dann Zweite Tab selectieren
            if (bError && !tabSelected)
            {
                tabAusscheidungen.SelectedTab = tabAusscheidungen.Tabs[1];
            }

            if (bError)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(error);
            
            return !bError;
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
