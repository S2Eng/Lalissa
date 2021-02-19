using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucASZMTransfer2 : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
    {
        public event EventHandler ASZMValueChanged;
        private bool _valueChangeEnabled = true;
        private ASZMSelectionArgs _arg;
        private int _pnlStartZeitenHeight;
        private int _pnlStartDatumHeight;
        private bool _isChanged = false;
        private ZeitbereichSerien _zeitbereichSerien;
        private dsZeitbereichSerien.ZeitbereichSerienDataTable _zeitbereichSerienDT;
        private Massnahmenserien _massnahmenserien;
        private dsMassnahmenserien.MassnahmenserienDataTable _massnahmenserienDT;
        private bool _EditMode = true;
        private PflegePlanModi _PflegePlanMode = PflegePlanModi.PflegePlan;
        //Neu nach 26.08.2008 MDA
        private PMDS.BusinessLogic.PflegePlan _PflegePlan = new PMDS.BusinessLogic.PflegePlan(false);
        private dsPflegePlan.PflegePlanRow _PRow = null;
        public PMDS.GUI.ucPflegeplan2 mainWindow = null;







        public ucASZMTransfer2()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning) return;

            _zeitbereichSerien = new ZeitbereichSerien();
            _massnahmenserien = new Massnahmenserien();

            cbZeitbereich.RefreshList(true, true);                // Initialisieren
            cbZeitbereich.IDZeitbereich = Guid.Empty;
            cbZeitbereichSerie.RefreshList(true);
            _pnlStartZeitenHeight = pnlStartZeitpunkte.Height;
            _pnlStartDatumHeight = pnlStartDatum.Height;
            InitGridZeitpunkte();

            this.ucPflegePlanSingleEdit21.mainWindow = this;
        }
        //Neu nach 09.10.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZusatzGruppe ZusatzGruppe
        {
            get { return ucPflegePlanSingleEdit21.ZusatzGruppe; }
            set { ucPflegePlanSingleEdit21.ZusatzGruppe = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModi PflegePlanMode
        {
            get { return _PflegePlanMode; }
            set 
            { 
                _PflegePlanMode = value;
                ucPflegePlanSingleEdit21.PflegePlanMode = value;
            }
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
                    _massnahmenserien.Read();
                    _massnahmenserienDT = _massnahmenserien.Serien;
                    _zeitbereichSerienDT = _zeitbereichSerien.Read();
                    //Neu nach 26.08.2008 MDA
                    if (_arg.IDPflegePlan != null && _arg.IDPflegePlan != Guid.Empty)
                        _PRow = _PflegePlan.ReadOnce(_arg.IDPflegePlan);
                    else
                        _PRow = null;
                    SetReadOnly(_arg.ErledigtJN);
                    UpdateGUI();
                    ShowHideFields();
                    _valueChangeEnabled = true;
                    if (PMDS.Global.historie.HistorieOn) this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                    
                }

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Zeitpunkte als DateTimeArray
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private DateTime[] ZEITPUNKTE
        {
            get
            {
                ArrayList al = new ArrayList();
                foreach (UltraGridRow r in dgZP.Rows)
                {
                    r.Update();
                    if (r.Cells["Zeitpunkt"].Value == DBNull.Value)
                    {
                        //r.Delete();

                    }
                }
                //dgZP.Refresh();

                foreach (UltraGridRow r in dgZP.Rows)
                {
                    r.Update();
                    if (r.Cells["Zeitpunkt"].Value != DBNull.Value)
                        al.Add((DateTime)r.Cells["Zeitpunkt"].Value);
                }
                int iCouter = dgZP.Rows.Count;
                return (DateTime[])al.ToArray(typeof(DateTime));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Zeitbereiche als GuidArray
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Guid[] ZEITBEREICHE
        {
            get
            {
                ArrayList al = new ArrayList();

                foreach (UltraGridRow r in dgZP.Rows)
                {
                    r.Update();
                    if (r.Cells["IDZeitbereich"].Value != DBNull.Value && (Guid)r.Cells["IDZeitbereich"].Value != Guid.Empty)
                        al.Add((Guid)r.Cells["IDZeitbereich"].Value);
                }

                return (Guid[])al.ToArray(typeof(Guid));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Zeitpunkte und Anmerkung als ASZMSelectionArgsInfo Array
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string[] ANMERKUNG
        {
            get
            {
                ArrayList al = new ArrayList();
                string anmerk;
                foreach (UltraGridRow r in dgZP.Rows)
                {
                    r.Update();
                    if (r.Cells["Zeitpunkt"].Value != DBNull.Value || (r.Cells["IDZeitbereich"].Value != DBNull.Value && (Guid)r.Cells["IDZeitbereich"].Value != Guid.Empty))
                    {
                        anmerk = "";
                        if (r.Cells["Anmerkung"].Value != DBNull.Value)
                            anmerk = r.Cells["Anmerkung"].Value.ToString().Trim();

                        al.Add(anmerk);
                    }
                }


                return (string[])al.ToArray(typeof(string));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn Daten dur Benuter geändert sind sonst false zurück 
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ISCHANGED
        {
            get { return _isChanged; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Editmode setzen/zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private void SetReadOnly(bool readOnly)
        {
            cbMohneZeitbezug.Enabled = !readOnly;
            dtpStart.ReadOnly = readOnly;
            tbUhrzeit.ReadOnly = readOnly;
            cbZeitbereichSerie.ReadOnly = readOnly;
            dgZP.DisplayLayout.Bands[0].Override.CellClickAction = readOnly ? CellClickAction.RowSelect : CellClickAction.Default;

            foreach (UltraGridColumn c in dgZP.DisplayLayout.Bands[0].Columns)
            {
                c.CellActivation = _arg.ErledigtJN ? Activation.NoEdit : Activation.AllowEdit;
            }


            if (_arg.ErledigtJN)
                dgZP.DisplayLayout.Bands[0].Override.RowAppearance.ForeColor = ENVCOLOR.EINTRAG_ENDED_FORE_COLOR;
            else
                dgZP.DisplayLayout.Bands[0].Override.RowAppearance.ResetForeColor();
            
        }

        private void InitErrorProvider()
        {
            errorProvider1.SetError(tbUhrzeit, "");
            errorProvider1.SetError(cbZeitbereich, "");
        }

        private void InitGridZeitpunkte()
        {
            dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.Clear();
            int idx = 0;
            dsPflegePlanZeitpunkte.PflegePlanZeitpunkteRow row;
            while (idx < 8)  //Gernot%%
            {
                row = dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AddPflegePlanZeitpunkteRow(Guid.Empty, DateTime.Now,Guid.Empty, "");
                row.SetZeitpunktNull();
                row.SetAnmerkungNull();
                row.SetIDZeitbereichNull();
                idx++;
            }

            dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AcceptChanges();
            dgZP.DataSource = dsPflegePlanZeitpunkte1;
        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            this.dgZP.DisplayLayout.Bands[0].Columns[this.dsPflegePlanZeitpunkte1 .PflegePlanZeitpunkte.ZeitpunktColumn .ColumnName].Format = "HH:mm";
            this.dgZP.DisplayLayout.Bands[0].Columns[this.dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.ZeitpunktColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Time;
            //this.dgZP.DisplayLayout.Bands[0].Columns[this.dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.ZeitpunktColumn.ColumnName].MaskInput = "HH:mm";

            MarkdtpStart();
            _isChanged = false;
            InitErrorProvider();
            InitGridZeitpunkte();
            
            cbZeitbereichSerie.RefreshList(true);
            //cbZeitbereichSerie.Value = null;
            
            ucPflegePlanSingleEdit21.PFLEGEPLANROW = GetPflegePlanRow();
            cbMohneZeitbezug.Checked = ucPflegePlanSingleEdit21.PFLEGEPLANROW.OhneZeitBezug;

            //Anderung nach 22.09.2008
            if (!_arg.ErledigtJN)
            {
                cbMohneZeitbezug.Enabled = true;
                //cbMohneZeitbezug immer Enabled nur bei Neue Einträge
               // if (_PRow != null)
                 //   cbMohneZeitbezug.Enabled = !_PRow.OhneZeitBezug;
            }
            dtpStart.Value = DateTime.Now.Date;

            if (_arg.StartDatum != new DateTime(1900, 1, 1))
            {
                dtpStart.Value = _arg.StartDatum.Date;
                tbUhrzeit.Value = _arg.StartDatum;
            }

            this.ucPflegePlanSingleEdit21.IDPflegeplan = null;
            this.mainWindow.btnVerordnungen2.Visible = false;

            cbZeitbereichSerie.Value = Guid.Empty;
            bool equals;
            if (_arg.UNTERTAEGIG != null && _arg.UNTERTAEGIG.Length > 0)
            {
                if (_arg.ANMERKUNG == null)
                    _arg.ANMERKUNG = new string[_arg.UNTERTAEGIG.Length];
                int idx = 0;
                dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.Clear();
                dsPflegePlanZeitpunkte.PflegePlanZeitpunkteRow row;
                foreach (DateTime t in _arg.UNTERTAEGIG)
                {
                    row = dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AddPflegePlanZeitpunkteRow(_arg.IDPflegePlan, t, _arg.IDZeitbereich, _arg.ANMERKUNG[idx]);
                    //this.ucPflegePlanSingleEdit21.ucVOErfassen1.search(null, row.IDpflegePlan, null);
                    this.ucPflegePlanSingleEdit21.IDPflegeplan = row.IDpflegePlan;
                    this.mainWindow.btnVerordnungen2.Visible = true;
                    if (!PMDS.Global.ENV.lic_VO)
                    {
                        this.mainWindow.btnVerordnungen2.Visible = false;
                    }
                    idx++;
                }

                while (idx < 8)//Gernot%%
                {
                    row = dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AddPflegePlanZeitpunkteRow(Guid.Empty, DateTime.Now, Guid.Empty, "");
                    row.SetZeitpunktNull();
                    row.SetAnmerkungNull();
                    idx++;
                }

                dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AcceptChanges();
                dgZP.DataSource = dsPflegePlanZeitpunkte1;

                Massnahmenserien s = Massnahmenserien.Default();
                DateTime[] dt;

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
                        cbZeitbereichSerie.Value = r.ID;
                        break;
                    }
                }

            }
            else if (_arg.ZEITBEREICH != null && _arg.ZEITBEREICH.Length > 0)
            {
                if (_arg.ANMERKUNG == null)
                    _arg.ANMERKUNG = new string[_arg.ZEITBEREICH.Length];
                int idx = 0;
                dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.Clear();
                dsPflegePlanZeitpunkte.PflegePlanZeitpunkteRow row;
                foreach (Guid id in _arg.ZEITBEREICH)
                {
                    row = dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AddPflegePlanZeitpunkteRow(_arg.IDPflegePlan, DateTime.Now, id, _arg.ANMERKUNG[idx]);
                    row.SetZeitpunktNull();
                    idx++;
                }
                this.mainWindow.btnVerordnungen2.Visible = true;

                while (idx < 8)//Gernot%%
                {
                    row = dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AddPflegePlanZeitpunkteRow(Guid.Empty, DateTime.Now, Guid.Empty, "");
                    row.SetZeitpunktNull();
                    row.SetAnmerkungNull();
                    idx++;
                }

                dsPflegePlanZeitpunkte1.PflegePlanZeitpunkte.AcceptChanges();
                dgZP.DataSource = dsPflegePlanZeitpunkte1;
                //cbZeitbereichSerie.Value = null;

                dgZP.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
                dgZP.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

                Guid[] zeitbereiche;

                foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in _zeitbereichSerienDT)
                {
                    zeitbereiche = _zeitbereichSerien.GetPoints(_zeitbereichSerienDT, r.ID);
                    equals = false;
                    if (zeitbereiche.Length == _arg.ZEITBEREICH.Length)
                    {
                        equals = true;

                        for (int i = 0; i < zeitbereiche.Length; i++)
                        {
                            //Nur nach Time vergleichen
                            if (zeitbereiche[i] != _arg.ZEITBEREICH[i])
                            {
                                equals = false;
                                break;
                            }
                        }
                    }

                    if (equals)
                    {
                        cbZeitbereichSerie.Value = r.ID;
                        break;
                    }
                }
            }
            ShowHideFields(); //Gernot%%
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            try
            {
                _isChanged = false;

                ucPflegePlanSingleEdit21.AcceptChanges();

                DateTime start = Convert.ToDateTime(dtpStart.Value);

                if (ZEITPUNKTE.Length > 0)
                {
                    _arg.StartDatum = start;
                    _arg.UNTERTAEGIG = ZEITPUNKTE;
                }
                else
                    _arg.UNTERTAEGIG = null;

                if (ZEITBEREICHE.Length > 0)
                {
                    _arg.StartDatum = start;
                    _arg.ZEITBEREICH = ZEITBEREICHE;
                }
                else
                {
                    _arg.ZEITBEREICH = null;
                }

                if (ANMERKUNG.Length > 0)
                    _arg.ANMERKUNG = ANMERKUNG;
                else
                    _arg.ANMERKUNG = null;

                //Neu nach 25.01.2008
                if (cbZeitbereichSerie.Visible && cbZeitbereichSerie.Value != null && cbZeitbereichSerie.Value != DBNull.Value)
                    _arg.UntertaegigBenutzerdefiniertJN = (Guid)cbZeitbereichSerie.Value == Guid.Empty ? true : false;// signalisiert eine Benutzerdefinierte Eingabe


                if (!ASZMTransfer.IsUntertaegig(_arg))
                {
                    if (tbUhrzeit.Value != null)
                        _arg.StartDatum = start.Date + new TimeSpan(0, tbUhrzeit.DateTime.Hour, tbUhrzeit.DateTime.Minute, 0, 0);
                    else
                        _arg.StartDatum = start;
                }

                //Zeitbezug
                _arg.OhneZeitBezug = ucPflegePlanSingleEdit21.PFLEGEPLANROW.OhneZeitBezug;

                if (_arg.OhneZeitBezug)
                {
                    _arg.UNTERTAEGIG = null;
                    _arg.ZEITBEREICH = null;
                }
            
                _arg.Dauer = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Dauer;
                _arg.EinmaligJN = ucPflegePlanSingleEdit21.PFLEGEPLANROW.EinmaligJN;
                _arg.EvalTage = ucPflegePlanSingleEdit21.PFLEGEPLANROW.EvalTage;
                _arg.IDBerufsstand = ucPflegePlanSingleEdit21.PFLEGEPLANROW.IDBerufsstand;
                _arg.SpenderAbgabgeJN = ucPflegePlanSingleEdit21.PFLEGEPLANROW.SpenderAbgabeJN;

                if (!ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsIDEintragNull())
                    _arg.IDEintrag = ucPflegePlanSingleEdit21.PFLEGEPLANROW.IDEintrag;
                else
                    _arg.IDEintrag = Guid.Empty;


                _arg.Intervall = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Intervall;
                _arg.IntervallTyp = ucPflegePlanSingleEdit21.PFLEGEPLANROW.IntervallTyp;
            
                if (!ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsLokalisierungNull())
                    _arg.Lokalisierung = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Lokalisierung.Trim();
                else
                    _arg.Lokalisierung = "";


                _arg.LokalisierungJN = ucPflegePlanSingleEdit21.PFLEGEPLANROW.LokalisierungJN;

                if (!ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsLokalisierungSeiteNull())
                    _arg.LokalisierungSeite = ucPflegePlanSingleEdit21.PFLEGEPLANROW.LokalisierungSeite.Trim();
                else
                    _arg.LokalisierungSeite = "";

                _arg.ParalellJN = ucPflegePlanSingleEdit21.PFLEGEPLANROW.ParalellJN;
                _arg.Text = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Text;

                _arg.Warnhinweis = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Warnhinweis;
                if (!ASZMTransfer.IsUntertaegig(_arg))
                {
                    if (ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsAnmerkungNull())
                    {
                        _arg.Anmerkung = "";
                    }
                    else
                    {
                        _arg.Anmerkung = ucPflegePlanSingleEdit21.PFLEGEPLANROW.Anmerkung.Trim();
                    }
                }
            
                _arg.WochenTage = ucPflegePlanSingleEdit21.PFLEGEPLANROW.WochenTage;
                _arg.EintragGruppe = PDx.GetEintragGruppeFromChar(ucPflegePlanSingleEdit21.PFLEGEPLANROW.EintragGruppe[0]);
                _arg.ISPDX = ucPflegePlanSingleEdit21.PFLEGEPLANROW.PDXJN;
                _arg.RMOptionalJN = ucPflegePlanSingleEdit21.PFLEGEPLANROW.RMOptionalJN;
            
                if (!ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsIDLinkDokumentNull())
                    _arg.IDLinkDokument = ucPflegePlanSingleEdit21.PFLEGEPLANROW.IDLinkDokument;
                else
                    _arg.IDLinkDokument = Guid.Empty;

                if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
                {
                    if (!ucPflegePlanSingleEdit21.PFLEGEPLANROW.IsNaechsteEvaluierungNull() && ucPflegePlanSingleEdit21.PFLEGEPLANROW.NaechsteEvaluierung > new DateTime(1900, 1, 1))
                        _arg.EvalStartDatum = ucPflegePlanSingleEdit21.PFLEGEPLANROW.NaechsteEvaluierung;
                    else
                        _arg.EvalStartDatum = new DateTime(1900, 1, 1);

                    _arg.EvalBemerkung = ucPflegePlanSingleEdit21.PFLEGEPLANROW.NaechsteEvaluierungBemerkung;
                }
                else
                {
                    _arg.EvalStartDatum = new DateTime(1900, 1, 1);
                    _arg.EvalBemerkung = "";
                }

                _arg.EintragFlag    = ucPflegePlanSingleEdit21.PFLEGEPLANROW.EintragFlag;
                ShowHideFields();
                //this.ucPflegePlanSingleEdit21.ucVOErfassen1.saveData();
                
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateDATA: " + ex.ToString());
            }
        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {

            bool bError = false;
            InitErrorProvider();

            if(cbMohneZeitbezug.Checked)
                return !bError;

            if (ASZMTransfer.IsUntertaegig(_arg) || (_PRow != null && _PRow.UntertaegigeJN))
            {
                if (ZEITPUNKTE.Length == 0 && ZEITBEREICHE.Length == 0) //Untertägig und kein Zeitpunkte und kein Zeitbereiche
                {
                    DataRowView v = (DataRowView)dgZP.Rows[0].ListObject;
                    dsPflegePlanZeitpunkte.PflegePlanZeitpunkteRow r = (dsPflegePlanZeitpunkte.PflegePlanZeitpunkteRow)v.Row;
                    r.SetColumnError(dgZP.Rows[0].Cells[1].Column.Index, ENV.String("ERROR_MISSING_ZEITPUNKT"));
                    
                    bError = true;
                }
            }
            else if (tbUhrzeit.Value == null && (_arg.EintragGruppe == EintragGruppe.M || _arg.EintragGruppe == EintragGruppe.T))
            {
                errorProvider1.SetError(tbUhrzeit, ENV.String("ERROR_MISSING_ZEITPUNKT"));
                bError = true;
            }

            if (bError)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSING_ZEITPUNKT"), true);

            if (!bError)
                bError = !ucPflegePlanSingleEdit21.ValidateFields();

            return !bError;

        }

        private void ShowHideFields()
        {
            pnlStartDatum.Height = _pnlStartDatumHeight;
           
            int h = 0;
            if (_arg.EintragGruppe == EintragGruppe.M || _arg.EintragGruppe == EintragGruppe.T)
            {
                pnlStartDatum.Visible = true;

                if (cbMohneZeitbezug.Checked)
                {
                    this.mainWindow.btnVerordnungen2.Visible = true;
                    pnlStartZeitpunkte.Visible = false;
                    cbZeitbereichSerie.Visible = false;
                    this.ucPflegePlanSingleEdit21._showPnlAnm = true;
                }                  
                else
                {
                    pnlStartZeitpunkte.Visible = true;
                    cbZeitbereichSerie.Visible = true;
                    this.ucPflegePlanSingleEdit21._showPnlAnm = false;
                }
                this.ucPflegePlanSingleEdit21.RecalcHeight();


                pnlUhrzeit.Visible = false;     //Relikt aus alten Zeiten


                if (!pnlStartZeitpunkte.Visible)
                    pnlStartDatum.Height -= _pnlStartZeitenHeight;
                h += pnlStartDatum.Height;
            }

            else 
            {
                pnlStartDatum.Visible = false;
            }

            ucPflegePlanSingleEdit21.Height += 100;
            Height = h + ucPflegePlanSingleEdit21.Height;
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
            r.ErledigtJN = _arg.ErledigtJN;
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
            r.Anmerkung = _arg.Anmerkung;
            r.WochenTage = _arg.WochenTage;
            r.EintragGruppe = _arg.EintragGruppe.ToString();
            r.PDXJN = _arg.ISPDX;
            r.RMOptionalJN = _arg.RMOptionalJN;
             
            if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
            {
                if (_arg.EvalStartDatum.Year != 1900)
                    r.NaechsteEvaluierung = _arg.EvalStartDatum;
                else
                    r.SetNaechsteEvaluierungNull();
                
                
                r.NaechsteEvaluierungBemerkung = _arg.EvalBemerkung;
            }
            else
            {
                r.NaechsteEvaluierungBemerkung = "";
                r.SetNaechsteEvaluierungNull();
            }

            r.UntertaegigeJN =  ASZMTransfer.IsUntertaegig(_arg) || (_PRow != null && _PRow.UntertaegigeJN);

            if (_arg.IDUntertaegigGruppe == Guid.Empty)				// Untertägigkeits zusammengehörigkeit von Maßnahmen
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

            r.OhneZeitBezug = _arg.OhneZeitBezug;

            if (_arg.IDZeitbereich != Guid.Empty)
                r.IDZeitbereich = _arg.IDZeitbereich;
            else
                r.SetIDZeitbereichNull();
            r.ZuErledigenBis = _arg.ZuErledigenBis;
            r.EintragFlag   = _arg.EintragFlag;

            r.SetIDDekursNull();
            r.PrivatJN = false;
            r.SetIDExternNull();
            r.SetNächstesDatumNull();
            r.lstIDPDx = "";
            r.lstPDxBezeichnung = "";
            r.SetIDBefundNull();

            return r;
        }

        /// <summary>
        /// Startzeitpunkte löschen
        /// </summary>
        private void ClearStartzeitpunkte()
        {
            dgZP.BeginUpdate();
            foreach (UltraGridRow r in dgZP.Rows)
            {
                r.Cells["Zeitpunkt"].Value = DBNull.Value;
                r.Cells["Anmerkung"].Value = DBNull.Value;
                r.Cells["IDZeitbereich"].Value = Guid.Empty;
                r.Update();
            }
            dgZP.EndUpdate();
        }

        public void InitColumn(UltraGridCell cell)
        {
            if (cell.Column.Key == "Anmerkung")
                return;

            _valueChangeEnabled = false;
            dgZP.BeginUpdate();
            foreach (UltraGridRow r in dgZP.Rows)
            {
                if (cell.Column.Key == "Zeitpunkt")
                    r.Cells["IDZeitbereich"].Value = Guid.Empty;
                else if (cell.Column.Key == "IDZeitbereich")
                    r.Cells["Zeitpunkt"].Value = DBNull.Value;
                if (r != cell.Row)
                    r.Update();
            }
            dgZP.EndUpdate();
            _valueChangeEnabled = true;
        }

        private void ucASZMTransfer2_Load(object sender, EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning) return;

           // cbZeitbereichSerie.Location = pnlUhrzeit.Location;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            _isChanged = true;
            if (_valueChangeEnabled && ASZMValueChanged != null)
            {
                ASZMValueChanged(sender, e);
                MarkdtpStart();
                
            }
            else
            {
                this.dtpStart.Appearance.BackColor = System.Drawing.Color.Transparent;
            }

        }

        private void dgZP_CellChange(object sender, CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (!_valueChangeEnabled) return;
            _isChanged = true;
            InitColumn(e.Cell);

            if (_valueChangeEnabled && ASZMValueChanged != null)
            {
                MarkdtpStart();
                ASZMValueChanged(sender, e);
            }
        }

        private void osZeit_ValueChanged(object sender, EventArgs e)
        {
            if(_valueChangeEnabled)
                ShowHideFields();
        }


        private void MarkdtpStart()   //os 2013-10-12
        {
            if (this.dtpStart.DateTime.Date < DateTime.Now.Date)
            {
                this.dtpStart.Appearance.BackColor = System.Drawing.Color.Red;   
            }
            else
            {
                this.dtpStart.Appearance.BackColor = System.Drawing.Color.Transparent;  
            }
        }


        private void cbZeitbereichSerie_ValueChanged(object sender, EventArgs e)
        {
            if (cbZeitbereichSerie.Focused)
            {

                if (DesignMode || !ENV.AppRunning) return;
                if (_valueChangeEnabled)
                {
                    if (cbZeitbereichSerie.Value == null)
                        return;

                    MarkdtpStart();

                    ClearStartzeitpunkte();

                    int iCount = 0;
                    dgZP.BeginUpdate();
                    if (cbZeitbereichSerie.IsZeitbereichSerie)
                    {
                        foreach (Guid id in _zeitbereichSerien.GetPoints(_zeitbereichSerienDT, cbZeitbereichSerie.ID))
                        {
                            if (iCount > 7)//Gernot%%
                                break;

                            dgZP.Rows[iCount].Cells["IDZeitbereich"].Value = id;
                            dgZP.Rows[iCount].Cells["Anmerkung"].Value = DBNull.Value;
                            dgZP.Rows[iCount].Cells["Zeitpunkt"].Value = DBNull.Value;
                            dgZP.Rows[iCount].Update();
                            iCount++;
                        }
                    }
                    else if (cbZeitbereichSerie.ID != Guid.Empty)
                    {
                        List<Guid> list = new List<Guid>();
                        dsMassnahmenserien.MassnahmenserienRow r = _massnahmenserienDT.FindByID(cbZeitbereichSerie.ID);
                        if (r != null)
                        {
                            list.Add(r.ID);
                        }

                        DateTime[] adt;
                        foreach (Guid id in list)
                        {
                            adt = _massnahmenserien.GetPoints(id);

                            foreach (DateTime t in adt)
                            {
                                if (iCount > 7)//Gernot%%
                                    break;

                                dgZP.Rows[iCount].Cells["Zeitpunkt"].Value = t;
                                dgZP.Rows[iCount].Cells["Anmerkung"].Value = DBNull.Value;
                                dgZP.Rows[iCount].Cells["IDZeitbereich"].Value = Guid.Empty;
                                dgZP.Rows[iCount].Update();
                                iCount++;
                            }
                        }
                    }

                    while (iCount < 8)//Gernot%%
                    {
                        dgZP.Rows[iCount].Cells["Zeitpunkt"].Value = DBNull.Value;
                        dgZP.Rows[iCount].Cells["Anmerkung"].Value = DBNull.Value;
                        dgZP.Rows[iCount].Cells["IDZeitbereich"].Value = Guid.Empty;
                        dgZP.Rows[iCount].Update();
                        iCount++;
                    }
                                       
                    dgZP.EndUpdate();
                    _isChanged = true;
                    if (ASZMValueChanged != null)
                        ASZMValueChanged(sender, e);
                }
            }

        }


        private void ucPflegePlanSingleEdit21_Load(object sender, EventArgs e)
        {

        }
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this.grbStartdatum, bOn);
            ucPflegePlanSingleEdit21.setControlsAktivDisable(bOn);

            if (bOn )
            {
                this.dgZP.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

            }
            else
            {
                this.dgZP.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
            }
        }

        private void dgZP_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
            {
                e.Cancel = true;
            }
        }

        private void cbZeitbereichSerie_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void dtpStart_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbMohneZeitbezug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMohneZeitbezug.Focused)
            {
                if (PMDS.Global.historie.HistorieOn) return;
                if (DesignMode || !ENV.AppRunning) return;

                if (_valueChangeEnabled)
                {
                    _isChanged = true;
                    MarkdtpStart();
                    ucPflegePlanSingleEdit21.MassnahmeOhneZeitbezug = cbMohneZeitbezug.Checked;
                    ShowHideFields();
                    if (ASZMValueChanged != null)
                        ASZMValueChanged(sender, e);
                }
            }
        }

        private void dgZP_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = false;
        }

        private void pnlStartDatum_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
