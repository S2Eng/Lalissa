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
using PMDS.Datenerhebung2.AnamnesePOP;

namespace PMDS.GUI
{
    public partial class ucAbwendenVonGefahrenPOP : ucAnamneseModellgruppeBase
    {
        public ucAbwendenVonGefahrenPOP()
        {
            InitializeComponent();
            ucAnamnesePDX1.Modellgruppe = (int)OremModellgruppen.AbwendenVonGefahren;
            AddControlsToDataBindings();
            PDXControl = ucAnamnesePDX1;
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(opInfektionsgefahrJN, "Value", "InfektionsgefahrJN"), 
                                                    new DataBindingHelper(tbInfektionsgefahr, "Text", "Infektionsgefahr"),
                                                    //new DataBindingHelper(opKoerperTempGefaehrdungJN, "Value", "KoerperTempGefaehrdungJN"), 
                                                    new DataBindingHelper(opKoerperTempVeraenderung, "Value", "KoerperTempVeraenderung"), 
                                                    new DataBindingHelper(tbKoerperTemp, "Value", "KoerperTemp"),
                                                    new DataBindingHelper(dtKoerperTempVeraenderungSeit, "Value", "KoerperTempVeraenderungSeit"),
                                                    new DataBindingHelper(tbBeobachtungenKoerperTemp, "Text", "BeobachtungenKoerperTemp"),
                                                    new DataBindingHelper(opVorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN, "Value", "VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN"), 
                                                    new DataBindingHelper(tbBeobachtungenVorVerletzugen, "Text", "BeobachtungenVorVerletzugen"),
                                                    new DataBindingHelper(opFluessigkeitenNahrungAspirationsrisikoJN, "Value", "FluessigkeitenNahrungAspirationsrisikoJN"),
                                                    new DataBindingHelper(tbBeobachtungenAspirationsrisiko, "Text", "BeobachtungenAspirationsrisiko"),
                                                    new DataBindingHelper(opBlutzirkulationStoerungenJN, "Value", "BlutzirkulationStoerungenJN"),
                                                    new DataBindingHelper(tbBlutzirkulationStoerungen, "Text", "BlutzirkulationStoerungen"),
                                                    new DataBindingHelper(tbBeobachtungenBlutzirkulation, "Text", "BeobachtungenBlutzirkulation"),
                                                    new DataBindingHelper(opSchmerzenJN, "Value", "SchmerzenJN"),
                                                    new DataBindingHelper(tbSchmerzenLokalisation, "Text", "SchmerzenLokalisation"),
                                                    new DataBindingHelper(dtpSchmerzenSeit, "Value", "SchmerzenSeit"),
                                                    new DataBindingHelper(tbSchmerzenHaeufigkeit, "Text", "SchmerzenHaeufigkeit"),
                                                    new DataBindingHelper(tbSchmerzenArt, "Text", "SchmerzenArt"),
                                                    new DataBindingHelper(tbSchmerzenIntensitaet, "Value", "SchmerzenIntensitaet"),
                                                    new DataBindingHelper(tbSchmerzenAustrahlung, "Text", "SchmerzenAustrahlung"),
                                                    new DataBindingHelper(tbSchmerzausloesendeFaktoren, "Text", "SchmerzausloesendeFaktoren"),
                                                    new DataBindingHelper(tbSchmerzverstaerkendeFaktoren, "Text", "SchmerzverstaerkendeFaktoren"),
                                                    new DataBindingHelper(tbSchmerzlinderndeFaktoren, "Text", "SchmerzlinderndeFaktoren"),
                                                    new DataBindingHelper(tbBeobachtungenSchmerzen, "Text", "BeobachtungenSchmerzen")
                                                    });

            BindData();
        }







        public override void BindData()
        {
            base.BindData();

            if (AnamneseRow != null)
            {
                PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow r = (PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow)AnamneseRow;

                opKoerperTempVeraenderung.Value = r.KoerperTempVeraenderung;

                switch (r.KoerperTempVeraenderung)
                {
                    case 0:    //Keine Veränderung
                        tbKoerperTemp.Value = 0;
                        break;
                    default:
                        tbKoerperTemp.Value = r.KoerperTemp;
                        break;
                }

                //if (!r.IsKoerperTempVeraenderungSeitNull())
                //{
                //    switch (r.KoerperTempVeraenderung)
                //    {
                //        case 0:
                //            dtKoerperTempVeraenderungSeit.Value = null;
                //            break;
                //        default:
                //            dtKoerperTempVeraenderungSeit.Value = r.KoerperTempVeraenderungSeit;
                //            break;
                //    }
                //}
                //else
                //{
                //    dtKoerperTempVeraenderungSeit.Value = null;
                //}
            }
            
        }

        public override void EndCurrentEdits()
        {
            base.EndCurrentEdits();

            if (AnamneseRow != null)
            {
                PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow r = (PMDS.GUI.Datenerhebung.AnamnesePOP.dsAnamnesePOP.Anamnese_POPRow)AnamneseRow;

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ErrorProvider initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitErrorProvider()
        {
            errorProvider1.SetError(dtKoerperTempVeraenderungSeit, "");
            errorProvider1.SetError(dtpSchmerzenSeit, "");
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public override bool ValidateFields()
        {
            bool bError = false, tabSelected = false;
            string error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen.");
            InitErrorProvider();

            if (dtKoerperTempVeraenderungSeit.Value != null && ((DateTime)dtKoerperTempVeraenderungSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtKoerperTempVeraenderungSeit, error);
            }

            if (bError)
            {
                tabAbwendenVonGefahren.SelectedTab = tabAbwendenVonGefahren.Tabs[0];
                tabSelected = true;
            }

            if (dtpSchmerzenSeit.Value != null && ((DateTime)dtpSchmerzenSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpSchmerzenSeit, error);
            }

            if (bError && !tabSelected)
                tabAbwendenVonGefahren.SelectedTab = tabAbwendenVonGefahren.Tabs[3];

            if (bError)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(error);
            
            return !bError;
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }

        private void opKoerperTempVeraenderung_ValueChanged(object sender, EventArgs e)
        {
            if (opKoerperTempVeraenderung.Value != null)
            {
                if (opKoerperTempVeraenderung.Value.Equals(0))
                {
                    dtKoerperTempVeraenderungSeit.Value = null;
                    tbKoerperTemp.Value = 0;
                }
            }

            OnValueChanged(sender, e);
        }

        
    }
}
