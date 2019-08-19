using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    public partial class ucASZMTransfer : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
    {
        public event EventHandler ASZMValueChanged;
        private bool _valueChangeEnabled = true;
        private ASZMSelectionArgs _arg;
        private UltraDateTimeEditor[] _adt;

        public ucASZMTransfer()
        {
            InitializeComponent();

            ArrayList al = new ArrayList();
            al.Add(zp0);
            al.Add(zp1);
            al.Add(zp2);
            al.Add(zp3);
            al.Add(zp4);
            al.Add(zp5);
            al.Add(zp6);
            _adt = (UltraDateTimeEditor[])al.ToArray(typeof(UltraDateTimeEditor));
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMSelectionArgs ARG
        {
            get { return _arg; }
            set
            {
                _arg = value;
                if (_arg != null)
                {
                    _valueChangeEnabled = false;
                    UpdateGUI();
                    ShowHideFields();
                    _valueChangeEnabled = true;
                }

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Zeitpunkte als DateTimeArray
        /// </summary>
        //----------------------------------------------------------------------------
        private DateTime[] ZEITPUNKTE
        {
            get
            {
                ArrayList al = new ArrayList();
                if (zp0.Value != null) al.Add(zp0.DateTime);
                if (zp1.Value != null) al.Add(zp1.DateTime);
                if (zp2.Value != null) al.Add(zp2.DateTime);
                if (zp3.Value != null) al.Add(zp3.DateTime);
                if (zp4.Value != null) al.Add(zp4.DateTime);
                if (zp5.Value != null) al.Add(zp5.DateTime);
                if (zp6.Value != null) al.Add(zp6.DateTime);
                return (DateTime[])al.ToArray(typeof(DateTime));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Löscht den Inhalt der ZP0 - ZP6
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearMassnahmenSerienValues()
        {
            foreach (UltraDateTimeEditor e in _adt)
                e.Value = null;
        }

        private void InitErrorProvider()
        {
            errorProvider1.SetError(zp6, "");
            errorProvider1.SetError(tbUhrzeit, "");
        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            InitErrorProvider();
            
            cbSerie.RefreshList();
            cbSerie.Value = null;
            ucPflegePlanSingleEdit1.PFLEGEPLANROW = GetPflegePlanRow();

            zp0.Value = null;
            zp1.Value = null;
            zp2.Value = null;
            zp3.Value = null;
            zp4.Value = null;
            zp5.Value = null;
            zp6.Value = null;
            dtpStart.Value = DateTime.Now;

            if (_arg.StartDatum != new DateTime(1900, 1, 1))
            {
                dtpStart.Value = _arg.StartDatum;
                tbUhrzeit.Value = _arg.StartDatum;
            }

            if (_arg.UNTERTAEGIG != null && _arg.UNTERTAEGIG.Length > 0)
            {
                int idx = 0;

                foreach (DateTime t in _arg.UNTERTAEGIG)
                {
                    if (idx < _arg.UNTERTAEGIG.Length)
                    {
                        switch (idx)
                        {
                            case 0:
                                zp0.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 1:
                                zp1.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 2:
                                zp2.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 3:
                                zp3.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 4:
                                zp4.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 5:
                                zp5.Value = _arg.UNTERTAEGIG[idx];
                                break;
                            case 6:
                                zp6.Value = _arg.UNTERTAEGIG[idx];
                                break;
                        }

                        idx++;
                    }
                }

                cbSerie.Value = null;

                Massnahmenserien s = Massnahmenserien.Default();
                DateTime[] dt;
                bool equals;
                foreach (dsMassnahmenserien.MassnahmenserienRow r in s.Serien)
                {
                    dt = s.GetPoints(r.ID);
                    equals = false;
                    if (dt.Length == _arg.UNTERTAEGIG.Length)
                    {
                        equals = true;

                        for (int i = 0; i < dt.Length; i++)
                        {
                            //Nur nach Time vergleichen
                            if (dt[i].TimeOfDay != _arg.UNTERTAEGIG[i].TimeOfDay)
                            {
                                equals = false;
                                break;
                            }
                        }
                    }

                    if (equals)
                    {
                        cbSerie.Value = r.ID;
                        break;
                    }
                }
                
            }
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            if (ucPflegePlanSingleEdit1.IsOriginalModified())
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("PP_ORIGINAL_TEXT_CHANGED"),
                                                                                                ENV.String("DIALOGTITLE_PP_ORIGINAL_TEXT_CHANGED"),
                                                                                                MessageBoxButtons.YesNoCancel,
                                                                                                MessageBoxIcon.Question, true);
                if (res == DialogResult.Yes)
                {
                    ucPflegePlanSingleEdit1.AcceptChanges();
                }
            }
            else
            {
                ucPflegePlanSingleEdit1.AcceptChanges();
            }

            ucPflegePlanSingleEdit1.AcceptChanges();

            DateTime start = Convert.ToDateTime(dtpStart.Value);
            
            if (ASZMTransfer.IsUntertaegig(_arg))
            {
                _arg.StartDatum = start;
                _arg.UNTERTAEGIG = ZEITPUNKTE;
            }
            else
            {
                if (tbUhrzeit.Value != null)
                    _arg.StartDatum = start.Date + new TimeSpan(0, tbUhrzeit.DateTime.Hour, tbUhrzeit.DateTime.Minute, 0, 0);
                else
                    _arg.StartDatum = start;
            }

            
            _arg.Dauer = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Dauer;
            _arg.EinmaligJN = ucPflegePlanSingleEdit1.PFLEGEPLANROW.EinmaligJN;
            _arg.EvalTage = ucPflegePlanSingleEdit1.PFLEGEPLANROW.EvalTage;
            _arg.IDBerufsstand = ucPflegePlanSingleEdit1.PFLEGEPLANROW.IDBerufsstand;
            _arg.SpenderAbgabgeJN = ucPflegePlanSingleEdit1.PFLEGEPLANROW.SpenderAbgabeJN;

            if (!ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsIDEintragNull())
                _arg.IDEintrag = ucPflegePlanSingleEdit1.PFLEGEPLANROW.IDEintrag;
            else
                _arg.IDEintrag = Guid.Empty;


            _arg.Intervall = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Intervall;
            _arg.IntervallTyp = ucPflegePlanSingleEdit1.PFLEGEPLANROW.IntervallTyp;
            
            if (!ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsLokalisierungNull())
                _arg.Lokalisierung = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Lokalisierung.Trim();
            else
                _arg.Lokalisierung = "";


            _arg.LokalisierungJN = ucPflegePlanSingleEdit1.PFLEGEPLANROW.LokalisierungJN;

            if (!ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsLokalisierungSeiteNull())
                _arg.LokalisierungSeite = ucPflegePlanSingleEdit1.PFLEGEPLANROW.LokalisierungSeite.Trim();
            else
                _arg.LokalisierungSeite = "";

            _arg.ParalellJN = ucPflegePlanSingleEdit1.PFLEGEPLANROW.ParalellJN;
            _arg.Text = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Text;
            _arg.Warnhinweis = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Warnhinweis;

            if (ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsAnmerkungNull())
            {
                _arg.Anmerkung = "";
            }
            else
            {
                _arg.Anmerkung = ucPflegePlanSingleEdit1.PFLEGEPLANROW.Anmerkung.Trim();
            }
            _arg.WochenTage = ucPflegePlanSingleEdit1.PFLEGEPLANROW.WochenTage;
            _arg.EintragGruppe = PDx.GetEintragGruppeFromChar(ucPflegePlanSingleEdit1.PFLEGEPLANROW.EintragGruppe[0]);
            _arg.ISPDX = ucPflegePlanSingleEdit1.PFLEGEPLANROW.PDXJN;
            _arg.RMOptionalJN = ucPflegePlanSingleEdit1.PFLEGEPLANROW.RMOptionalJN;
            
            if (!ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsIDLinkDokumentNull())
                _arg.IDLinkDokument = ucPflegePlanSingleEdit1.PFLEGEPLANROW.IDLinkDokument;
            else
                _arg.IDLinkDokument = Guid.Empty;

            if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
            {
                if (ucPflegePlanSingleEdit1.PFLEGEPLANROW.NaechsteEvaluierung > new DateTime(1900, 1, 1))
                    _arg.EvalStartDatum = ucPflegePlanSingleEdit1.PFLEGEPLANROW.NaechsteEvaluierung;
                else
                    _arg.EvalStartDatum = new DateTime(1900, 1, 1);

                _arg.EvalBemerkung = ucPflegePlanSingleEdit1.PFLEGEPLANROW.NaechsteEvaluierungBemerkung;
            }
            else
            {
                _arg.EvalStartDatum = new DateTime(1900, 1, 1);
                _arg.EvalBemerkung = "";
            }
        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            bool bError = false;
            InitErrorProvider();

            if (ASZMTransfer.IsUntertaegig(_arg))
            {
                if (ZEITPUNKTE.Length == 0)
                {
                    errorProvider1.SetError(zp6, ENV.String("ERROR_MISSING_ZEITPUNKT"));
                    bError = true;
                }
            }
            else if (tbUhrzeit.Value == null && (_arg.EintragGruppe == EintragGruppe.M || _arg.EintragGruppe == EintragGruppe.T))
            {
                errorProvider1.SetError(tbUhrzeit, ENV.String("ERROR_MISSING_ZEITPUNKT"));
                bError = true;
            }

            if (bError)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), true);

            return !bError;

        }

        private void ShowHideFields()
        {
            pnlStartDatum.Visible = false;
            int h = 0;
            if (_arg.EintragGruppe == EintragGruppe.M || _arg.EintragGruppe == EintragGruppe.T)
            {
                pnlStartDatum.Visible = true;
                pnlStartZeitpunkte.Visible = ASZMTransfer.IsUntertaegig(_arg);
                pnlUhrzeit.Visible = !ASZMTransfer.IsUntertaegig(_arg);

                if (ASZMTransfer.IsUntertaegig(_arg))
                {
                    grbStartdatum.Height = dtpStart.Top + dtpStart.Height + pnlStartZeitpunkte.Height + 10;
                }
                else
                {
                    grbStartdatum.Height = dtpStart.Top + dtpStart.Height + 5;
                }
                pnlStartDatum.Height = grbStartdatum.Top + grbStartdatum.Height + 2;
                h += pnlStartDatum.Height;
            }

            Height = h + ucPflegePlanSingleEdit1.Height + 20;
        }

        private dsPflegePlan.PflegePlanRow GetPflegePlanRow()
        {
            dsPflegePlan ds = new dsPflegePlan();
            dsPflegePlan.PflegePlanRow r = ds.PflegePlan.NewPflegePlanRow();

            r.ID = Guid.NewGuid();
            r.DatumErstellt = DateTime.Now;
            r.DatumGeaendert = DateTime.Now;
            r.Dauer = _arg.Dauer;
            r.EinmaligJN = _arg.EinmaligJN;
            r.SetEndeDatumNull();
            r.ErledigtGrund = "";
            r.ErledigtJN = false;
            r.EvalTage = _arg.EvalTage;
            r.GeloeschtJN = false;
            r.IDAufenthalt = ENV.IDAUFENTHALT;
            r.IDBenutzer_Erstellt = ENV.USERID;
            r.IDBenutzer_Geaendert = ENV.USERID;
            r.IDBerufsstand = _arg.IDBerufsstand;
            r.SpenderAbgabeJN = _arg.SpenderAbgabgeJN;

            if (_arg.IDEintrag == Guid.Empty)
                r.SetIDEintragNull();
            else
                r.IDEintrag = _arg.IDEintrag;

            r.Intervall = _arg.Intervall;
            r.IntervallTyp = _arg.IntervallTyp;
            r.SetLetzteEvaluierungNull();
            r.SetLetztesDatumNull();
            if (_arg.Lokalisierung != null)
                r.Lokalisierung = _arg.Lokalisierung.Trim();
            else
                r.Lokalisierung = "";

            r.LokalisierungJN = _arg.LokalisierungJN;

            if (_arg.LokalisierungSeite != null)
                r.LokalisierungSeite = _arg.LokalisierungSeite.Trim();
            else
                r.LokalisierungSeite = "";

            r.OriginalJN = true;							// Am begimm immer unverändert
            r.ParalellJN = _arg.ParalellJN;
            r.StartDatum = _arg.StartDatum;
            r.Text = _arg.Text;
            r.Warnhinweis = _arg.Warnhinweis;

            if (_arg.Anmerkung == null)
            {
                r.Anmerkung = "";
            }
            else
            {
                r.Anmerkung = _arg.Anmerkung;
            }

            r.WochenTage = _arg.WochenTage;
            r.EintragGruppe = _arg.EintragGruppe.ToString();
            r.PDXJN = _arg.ISPDX;
            r.RMOptionalJN = _arg.RMOptionalJN;
            r.OhneZeitBezug = false;

            if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
            {
                if (_arg.EvalStartDatum.Year != 1900)
                    r.NaechsteEvaluierung = _arg.EvalStartDatum;
                else
                    r.NaechsteEvaluierung = DateTime.Now;
                
                
                r.NaechsteEvaluierungBemerkung = _arg.EvalBemerkung;
            }
            else
            {
                r.NaechsteEvaluierungBemerkung = "";
                r.SetNaechsteEvaluierungNull();
            }

            r.UntertaegigeJN =  ASZMTransfer.IsUntertaegig(_arg);

            if (_arg.IDUntertaegigGruppe == Guid.Empty)				// UNtertägigkeitsz zusammengehörigkeit von Maßnahmen
            {
                r.SetIDUntertaegigeGruppeNull();
            }
            else
            {
                r.IDUntertaegigeGruppe = _arg.IDUntertaegigGruppe;
            }

            if (_arg.IDLinkDokument == Guid.Empty)
                r.SetIDLinkDokumentNull();
            else
                r.IDLinkDokument = _arg.IDLinkDokument;

            r.SetIDDekursNull();
            r.PrivatJN = false;
            r.SetIDExternNull();
            r.lstIDPDx = "";
            r.lstPDxBezeichnung = "";
            r.SetIDBefundNull();

            return r;
        }

        private void cbSerie_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled)
            {
                ClearMassnahmenSerienValues();
                if (cbSerie.Value == null)
                    return;

                Massnahmenserien s = new Massnahmenserien();
                s.Read();

                DateTime[] adt = s.GetPoints(cbSerie.ID);

                int iCount = 0;
                foreach (DateTime t in adt)
                {
                    if (iCount > 6)
                        break;
                    _adt[iCount].DateTime = t;
                    iCount++;
                }

                if (ASZMValueChanged != null)
                {
                    UpdateDATA();
                    ASZMValueChanged(sender, e);
                }
            }
        }
    }
}
