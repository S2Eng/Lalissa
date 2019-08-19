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
    public partial class ucAbwendenVonGefahren : ucAnamneseModellgruppeBase
    {
        public ucAbwendenVonGefahren()
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
                                                    new DataBindingHelper(opKoerperTempGefaehrdungJN, "Value", "KoerperTempGefaehrdungJN"), 
                                                    new DataBindingHelper(opKoerperTempVeraendertJN, "Value", "KoerperTempVeraendertJN"), 
                                                    new DataBindingHelper(opKoerperTempVeraenderung, "Value", "KoerperTempVeraenderung"), 
                                                    new DataBindingHelper(tbBeobachtungenKoerperTemp, "Text", "BeobachtungenKoerperTemp"),
                                                    new DataBindingHelper(opVorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN, "Value", "VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN"), 
                                                    new DataBindingHelper(tbBeobachtungenVorVerletzugen, "Text", "BeobachtungenVorVerletzugen"),
                                                    new DataBindingHelper(opErstickenErhoehtesRisikoJN, "Value", "ErstickenErhoehtesRisikoJN"),
                                                    new DataBindingHelper(tbBeobachtungenErsticken, "Text", "BeobachtungenErsticken"),
                                                    new DataBindingHelper(opFluessigkeitenNahrungAspirationsrisikoJN, "Value", "FluessigkeitenNahrungAspirationsrisikoJN"),
                                                    new DataBindingHelper(tbBeobachtungenAspirationsrisiko, "Text", "BeobachtungenAspirationsrisiko"),
                                                    new DataBindingHelper(opKannBehandlungsprogrammAkzeptierenJN, "Value", "KannBehandlungsprogrammAkzeptierenJN"),
                                                    new DataBindingHelper(tbBeobachtungenBehandlungsprogramm, "Text", "BeobachtungenBehandlungsprogramm"),
                                                    new DataBindingHelper(opErkenntGesungheitsfoerdendeMassnahmenJN, "Value", "ErkenntGesungheitsfoerdendeMassnahmenJN"),
                                                    new DataBindingHelper(tbGesungheitsfoerdendeMassnahmen, "Text", "GesungheitsfoerdendeMassnahmen"),
                                                    new DataBindingHelper(tbBeobachtungenGesungheitsfoerdendeMassnahmen, "Text", "BeobachtungenGesungheitsfoerdendeMassnahmen"),
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
                dsAnamneseOrem.Anamnese_OremRow r = (dsAnamneseOrem.Anamnese_OremRow)AnamneseRow;

                if (!r.IsKoerperTempVeraenderungNull())
                {
                    opKoerperTempVeraenderung.Value = r.KoerperTempVeraenderung;

                    if (!r.IsKoerperTempNull())
                    {
                        switch (r.KoerperTempVeraenderung)
                        {
                            case 0:
                                tbKoerperTempErhoeht.Value = r.KoerperTemp;
                                tbKoerperTempErniedrigt.Value = null;
                                break;
                            case 1:
                                tbKoerperTempErhoeht.Value = null;
                                tbKoerperTempErniedrigt.Value = r.KoerperTemp;
                                break;
                        }
                    }
                    else
                    {
                        tbKoerperTempErhoeht.Value = null;
                        tbKoerperTempErniedrigt.Value = null;
                    }

                    if (!r.IsKoerperTempVeraenderungSeitNull())
                    {
                        switch (r.KoerperTempVeraenderung)
                        {
                            case 0:
                                dtErhKoerpTempVeraenSeit.Value = r.KoerperTempVeraenderungSeit;
                                dtpdtErniedKoerpTempVeraenSeit.Value = null;
                                break;
                            case 1:
                                dtErhKoerpTempVeraenSeit.Value = null;
                                dtpdtErniedKoerpTempVeraenSeit.Value = r.KoerperTempVeraenderungSeit;
                                break;
                        }
                    }
                    else
                    {
                        dtErhKoerpTempVeraenSeit.Value = null;
                        dtpdtErniedKoerpTempVeraenSeit.Value = null;
                    }
                }
                else
                {
                    opKoerperTempVeraenderung.Value = null;
                    tbKoerperTempErhoeht.Value = null;
                    tbKoerperTempErniedrigt.Value = null;
                    dtErhKoerpTempVeraenSeit.Value = null;
                    dtpdtErniedKoerpTempVeraenSeit.Value = null;
                }
            }
        }

        public override void EndCurrentEdits()
        {
            base.EndCurrentEdits();

            if (AnamneseRow != null)
            {
                dsAnamneseOrem.Anamnese_OremRow r = (dsAnamneseOrem.Anamnese_OremRow)AnamneseRow;

                if (opKoerperTempVeraenderung.Value != null)
                {
                    r.KoerperTempVeraenderung = (int)opKoerperTempVeraenderung.Value;

                    if ((int)opKoerperTempVeraenderung.Value == 0)
                    {
                        if (tbKoerperTempErhoeht.Text.Trim().Length > 0)
                            r.KoerperTemp = Convert.ToDouble(tbKoerperTempErhoeht.Value);
                        else
                            r.SetKoerperTempNull();

                        if (dtErhKoerpTempVeraenSeit.Text.Trim().Length > 0)
                            r.KoerperTempVeraenderungSeit = Convert.ToDateTime(dtErhKoerpTempVeraenSeit.Value);
                        else
                            r.SetKoerperTempVeraenderungSeitNull();
                    }
                    else
                    {
                        if (tbKoerperTempErniedrigt.Text.Trim().Length > 0)
                            r.KoerperTemp = Convert.ToDouble(tbKoerperTempErniedrigt.Value);
                        else
                            r.SetKoerperTempNull();

                        if (dtpdtErniedKoerpTempVeraenSeit.Text.Trim().Length > 0)
                            r.KoerperTempVeraenderungSeit = Convert.ToDateTime(dtpdtErniedKoerpTempVeraenSeit.Value);
                        else
                            r.SetKoerperTempVeraenderungSeitNull();
                    }
                }
                else
                {
                    r.SetKoerperTempVeraenderungNull();
                    r.SetKoerperTempNull();
                    r.SetKoerperTempVeraenderungSeitNull();
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ErrorProvider initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitErrorProvider()
        {
            errorProvider1.SetError(dtErhKoerpTempVeraenSeit, "");
            errorProvider1.SetError(dtpdtErniedKoerpTempVeraenSeit, "");
            errorProvider1.SetError(dtpSchmerzenSeit, "");
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public override bool ValidateFields()
        {
            bool bError = false, tabSelected = false;
            
            string error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen.");
            InitErrorProvider();

            if (dtErhKoerpTempVeraenSeit.Value != null && ((DateTime)dtErhKoerpTempVeraenSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtErhKoerpTempVeraenSeit, error);
            }

            if (dtpdtErniedKoerpTempVeraenSeit.Value != null && ((DateTime)dtpdtErniedKoerpTempVeraenSeit.Value) > DateTime.Now)
            {
                bError = true;
                errorProvider1.SetError(dtpdtErniedKoerpTempVeraenSeit, error);
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

        private void opKoerperTempVeraendertJN_ValueChanged(object sender, EventArgs e)
        {
            bool readOnly;

            if (ReadOnly)
                readOnly = ReadOnly;
            else
                readOnly = !Convert.ToBoolean(opKoerperTempVeraendertJN.Value);

            opKoerperTempVeraenderung.Enabled = !readOnly;

            if (readOnly)
            {
                tbKoerperTempErhoeht.ReadOnly = readOnly;
                dtErhKoerpTempVeraenSeit.ReadOnly = readOnly;
                tbKoerperTempErniedrigt.ReadOnly = readOnly;
                dtpdtErniedKoerpTempVeraenSeit.ReadOnly = readOnly;
            }
            else if(opKoerperTempVeraenderung.Value != null)
            {
                if ((int)opKoerperTempVeraenderung.Value == 0)
                {
                    tbKoerperTempErhoeht.ReadOnly = false;
                    dtErhKoerpTempVeraenSeit.ReadOnly = false;
                    tbKoerperTempErniedrigt.ReadOnly = true;
                    dtpdtErniedKoerpTempVeraenSeit.ReadOnly = true;
                }
                else
                {
                    tbKoerperTempErhoeht.ReadOnly = true;
                    dtErhKoerpTempVeraenSeit.ReadOnly = true;
                    tbKoerperTempErniedrigt.ReadOnly = false;
                    dtpdtErniedKoerpTempVeraenSeit.ReadOnly = false;
                }
            }
            OnValueChanged(sender, e);
        }

        private void opKoerperTempVeraenderung_ValueChanged(object sender, EventArgs e)
        {
            if (opKoerperTempVeraenderung.Value == null)
            {
                tbKoerperTempErhoeht.ReadOnly = true;
                dtErhKoerpTempVeraenSeit.ReadOnly = true;
                tbKoerperTempErniedrigt.ReadOnly = true;
                dtpdtErniedKoerpTempVeraenSeit.ReadOnly = true;

                tbKoerperTempErhoeht.Value = null;
                dtErhKoerpTempVeraenSeit.Value = null;
                tbKoerperTempErniedrigt.Value = null;
                dtpdtErniedKoerpTempVeraenSeit.Value = null;
            }
            else if ((int)opKoerperTempVeraenderung.Value == 0)
            {
                tbKoerperTempErhoeht.ReadOnly = ReadOnly;
                dtErhKoerpTempVeraenSeit.ReadOnly = ReadOnly;

                tbKoerperTempErniedrigt.ReadOnly = true;
                dtpdtErniedKoerpTempVeraenSeit.ReadOnly = true;
                
                
                tbKoerperTempErniedrigt.Value = null;
                dtpdtErniedKoerpTempVeraenSeit.Value = null;
            }
            else
            {
                tbKoerperTempErhoeht.ReadOnly = true;
                dtErhKoerpTempVeraenSeit.ReadOnly = true;
                tbKoerperTempErhoeht.Value = null;
                dtErhKoerpTempVeraenSeit.Value = null;
                tbKoerperTempErniedrigt.ReadOnly = ReadOnly;
                dtpdtErniedKoerpTempVeraenSeit.ReadOnly = ReadOnly;
            }

            OnValueChanged(sender, e);
        }
    }
}
