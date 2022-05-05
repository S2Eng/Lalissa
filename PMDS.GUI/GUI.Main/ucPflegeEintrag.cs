//----------------------------------------------------------------------------
/// <summary>
///	ucPflegeEintrag.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.DB;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PMDS.GUI
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// UserControl zum Bearbeitung eines PflegeEintrags
    /// </summary>
    //----------------------------------------------------------------------------
    public class ucPflegeEintrag : QS2.Desktop.ControlManagment.BaseControl, IUCBase, IReadOnly
    {
        private bool _valueChangeEnabled = true;
        private PflegeEintrag _eintrag;
        private Color _ReadonlyColor = Color.LightGray;
        private bool _RMOptional = false;
        private bool _Medikation = false;
        private bool _MedikamentListInit = false;
        private bool _TestBedarfsMEmpty = false;
        private List<string> _alValues;                              // speichert die ursprünglichen Zusatzwerte als Stringliste
        public bool _editinprogress = false;

        public bool IsIntialized = false;
        public bool IsNew = false;
        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();

        public bool _IsMedikation = false;
        public bool _IsDekurs = false;
        public bool _IsBefund = false;
        public bool HistorischerModus = ENV.FullEditMode;

        public Infragistics.Win.Misc.UltraButton btnDelete = null;

        public PMDS.Global.eDekursherkunft _Dekursherkunft = eDekursherkunft.none;
        public Nullable<Guid> IDEintragFromQuickbutton = null;


        public frmPatientRueckmeldung frmPatientRueckmeldung1 = null;
        public bool IsDekursEntwurf = false;
        public Nullable<Guid> IDPflegeeintragEntwurf = null;
        public Nullable<Guid> IDFuerUserErstellt = null;
        public Nullable<Guid> IDPatientEntwurf = null;
        public string DekursTextRtfTemplate = "";

        public frmPatientVermerk frmPatientVermerkMainWindow = null;
        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();






        protected System.Windows.Forms.ErrorProvider errorProvider1;
        public PMDS.GUI.ucZusatzWert ucZusatzWert1;
        protected QS2.Desktop.ControlManagment.BaseLabel lblWichtigFür;
        protected PMDS.GUI.BaseControls.AuswahlGruppeCombo cbImportant;
        protected QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        protected BaseControls.MassnahmenCombo cbMassnahme;
        protected QS2.Desktop.ControlManagment.BaseLabel lblZeitpunktDerDurchführung;
        protected QS2.Desktop.ControlManagment.BaseLabel labMassnahme;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkDone;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpZeitpunkt;
        protected QS2.Desktop.ControlManagment.BaseLabel lblDauer;
        protected QS2.Desktop.ControlManagment.BaseMaskEdit txtIstDauer;
        protected PMDS.GUI.BaseControls.BedarfsMedikamentCombo cbBedarfsMedikament;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMedikation;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMin;
        public BaseControls.AuswahlGruppeComboMulti auswahlGruppeComboMulti1;
        private IContainer components;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkAlsDekursKopieren;
        protected Panel panelTxtControl;
        private TXTextControl.TextControl textControlOriginal;
        protected QS2.Desktop.ControlManagment.BaseLabel lblZusatzwerte;
        private TXTextControl.TextControl textControChanges;
        private TXTextControl.TextControl textControSave;
        private TXTextControl.TextControl textControlLineBreak;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkGegenzeichnen;
        protected Panel panelBeschreibungTXTEditor;

        public event EventHandler ValueChanged;

        public Nullable<Guid> IDExtern = null;

        public QS2.Desktop.Txteditor.contTXTField contTXTFieldBeschreibung = null;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtBeschreibungLine;

        public bool _IsSchnellrückmeldung = false;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegestufeneinschaetzung;
        private BaseControls.PflegestufenEinschaetzung cbPflegestufenEinschaetzung;
        public bool _OhneZeitbezug = false;











        public ucPflegeEintrag()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;

            if (!DesignMode)
            {
                if (!ENV.AppRunning)
                    return;
                InitSubComponent();

                New();   //??????????
                _ReadonlyColor = this.BackColor;
            }

        }

        public void initControl(bool IsDekurs, bool IsSchnellrückmeldung, bool IsBefund, PMDS.Global.eDekursherkunft Dekursherkunft)
        {
            try
            {
                if (!this.IsIntialized)
                {
                    this._Dekursherkunft = Dekursherkunft;
                    this._IsSchnellrückmeldung = IsSchnellrückmeldung;
                    this._IsBefund = IsBefund;

                    this.loadBeschreibung();

                    this._IsDekurs = IsDekurs;
                    this.auswahlGruppeComboMulti1.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, true, -1, 0, true);

                    if (_IsMedikation)      //Einzelfallmedikation
                    {
                        setWichtigFuerDefaults(eDekursDefaults.Einzelfallmedikation.ToString(), false);  
                    }

                    if (this._IsDekurs)
                    {
                        this.ucZusatzWert1.Left = this.ucZusatzWert1.Left + this.ucZusatzWert1.Width;
                        this.ucZusatzWert1.Width = 0;
                        this.panelBeschreibungTXTEditor.Width = this.panelBeschreibungTXTEditor.Left + this.ucZusatzWert1.Left - 14;
                        this.lblZusatzwerte.Visible = false;

                        if (ENV.lic_PflegestufenEinschätzung)
                        {
                            this.lblPflegestufeneinschaetzung.Top = auswahlGruppeComboMulti1.Top + auswahlGruppeComboMulti1.Top;
                            this.cbPflegestufenEinschaetzung.Top = lblPflegestufeneinschaetzung.Top;
                            cbPflegestufenEinschaetzung.RefreshList();
                            cbPflegestufenEinschaetzung.PSEKlasse = cbPflegestufenEinschaetzung.strDefault;

                            this.lblAnmerkung.Top = lblPflegestufeneinschaetzung.Top + lblPflegestufeneinschaetzung.Height + 5;
                            this.chkGegenzeichnen.Top = this.lblAnmerkung.Top;
                        }
                        else
                        {
                            this.lblPflegestufeneinschaetzung.Visible = false;
                            this.cbPflegestufenEinschaetzung.Visible = false;
                            this.lblAnmerkung.Top = auswahlGruppeComboMulti1.Top + auswahlGruppeComboMulti1.Top;
                            this.chkGegenzeichnen.Top = this.lblAnmerkung.Top;
                        }

                        this.panelBeschreibungTXTEditor.Top = lblAnmerkung.Top + lblAnmerkung.Height + 5;
                        this.panelBeschreibungTXTEditor.Height = this.Height - panelBeschreibungTXTEditor.Top;


                        //Defaultwerte setzen - wenn erforderlich
                        if (this._Dekursherkunft == eDekursherkunft.DekursAusMitBereich)
                            setWichtigFuerDefaults(eDekursDefaults.DekursMVB.ToString(), false);    //DekursMVB = Dekurs aus mitverantwortlichem Bereich
                        else if (this._Dekursherkunft == eDekursherkunft.DekursAusIntervention)
                            setWichtigFuerDefaults( eDekursDefaults.DekursIntervention.ToString(), false);    //DekursMVB = Dekurs aus mitverantwortlichem Bereich
                        else if (this._Dekursherkunft == eDekursherkunft.DekursAusMedDiagnosenPatient)
                            setWichtigFuerDefaults(eDekursDefaults.DekursMedDiag.ToString(), false);    //DekursMVB = Dekurs aus mitverantwortlichem Bereich
                        else if (this._Dekursherkunft == eDekursherkunft.DekursAusÜbergabe)
                            setWichtigFuerDefaults(eDekursDefaults.DekursÜbergabe.ToString(), false);    //DekursMVB = Dekurs aus mitverantwortlichem Bereich
                    }
                    else
                    {
                        this.lblPflegestufeneinschaetzung.Visible = false;
                        this.cbPflegestufenEinschaetzung.Visible = false;
                    }

                    this.IsIntialized = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.initCOntrol: " + e.ToString());
            }
        }


        public void setWichtigFuerDefaults(string setBereich, bool reset )
        {
            try
            {
                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                    
                if (reset)          //Auswahl löschen
                {
                    this.auswahlGruppeComboMulti1.setSelected(lstGuid, lstIntSelected, lstStrSelected);
                    return;
                }

                //Wenn noch nichts gewählt ist, Defaults setzen
                auswahlGruppeComboMulti1.getSelected(ref lstGuid, ref lstIntSelected, ref lstStrSelected);                    
                if (lstGuid.Count == 0)      
                {
                    System.Collections.Generic.List<Guid> lstWichtigFuer = PMDS.Global.Tools.GetWichtigFuerDefaults(setBereich);
                    foreach (Guid IDWichtig in lstWichtigFuer)
                    {
                        lstGuid.Add(IDWichtig);
                        this.auswahlGruppeComboMulti1.setSelected(lstGuid, lstIntSelected, lstStrSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("setWichtigFuerDefaults: " + ex.ToString());
            }
        }


        public void loadBeschreibung()
        {
            try
            {
                if (!this._IsSchnellrückmeldung)
                {
                    this.panelBeschreibungTXTEditor.Controls.Clear();
                    this.txtBeschreibungLine.Visible = false;
                    
                    this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
                    this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.FloatingText, true, true, false, false, true, false);
                    this.contTXTFieldBeschreibung.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChanged);
                    this.contTXTFieldBeschreibung.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChangedBeschreibungTxtControl);
                    this.contTXTFieldBeschreibung.delOnKeyUp += new QS2.Desktop.Txteditor.contTXTField.onKeyUp(this.BeschreibungKeyUp);
                    
                    this.contTXTFieldBeschreibung.Dock = DockStyle.Fill;
                    this.panelBeschreibungTXTEditor.Controls.Add(contTXTFieldBeschreibung);
                    //this.contTXTFieldBeschreibung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BeschreibungKeyUp);
                    //this.contTXTFieldBeschreibung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMassnahme_KeyPress);
                }
                else
                {
                    //this.txtBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
                    //this.txtBeschreibung.Appearance.BackColor = System.Drawing.Color.Red;
                    //this.txtBeschreibung.Dock = DockStyle.Fill;
                    //this.panelBeschreibungTXTEditor.Controls.Add(txtBeschreibung);
                    this.txtBeschreibungLine.Visible = true;
                    this.panelBeschreibungTXTEditor.Controls.Clear();
                    this.panelBeschreibungTXTEditor.Visible = false;
                }

            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.LoadTXTEditorBeschreibung: " + e.ToString());
            }
        }

        public void setUIPanelBeschreibungSchnellRückmeldung()
        {
            this.panelBeschreibungTXTEditor.Left = auswahlGruppeComboMulti1.Left;
            this.panelBeschreibungTXTEditor.Top = auswahlGruppeComboMulti1.Top;
            this.panelBeschreibungTXTEditor.Visible = true;
            this.txtBeschreibungLine.Visible = true;
        }
        public bool Medikation
        {
            get { return _Medikation; }
            set
            {
                if (value)
                    PrepareForMedikation(value, true, true, true);
            }
        }

        private void PrepareForMedikation(bool bMedikation, bool SetValidateRequired, bool bRMOptional, bool MedikationMListOnly)
        {
            _Medikation = bMedikation;
            RM_OPTIONAL = bRMOptional;
            _TestBedarfsMEmpty = SetValidateRequired;

            if (!_MedikamentListInit && bMedikation) //??????????
                cbBedarfsMedikament.RefreshList(Eintrag.IDAufenthalt);
            _MedikamentListInit = true;

            if (MedikationMListOnly)
                cbMassnahme.RefreshListMedikationOnly();

            if (SetValidateRequired)
                GuiUtil.ValidateRequired(cbBedarfsMedikament);

            ShowHideMedikation();
        }

        private void ShowHideMedikation()
        {
            cbBedarfsMedikament.Visible = _Medikation;
            lblMedikation.Visible = _Medikation;
        }

        public bool RM_OPTIONAL
        {
            set { _RMOptional = value; }
            get { return _RMOptional; }
        }

        private bool TXTBESCHREIBUNG_OPTIONAL
        {
            get { return RM_OPTIONAL; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblWichtigFür = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblZeitpunktDerDurchführung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.labMassnahme = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkDone = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.dtpZeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblDauer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtIstDauer = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblMedikation = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.lblMin = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkAlsDekursKopieren = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.textControlOriginal = new TXTextControl.TextControl();
            this.panelTxtControl = new System.Windows.Forms.Panel();
            this.textControSave = new TXTextControl.TextControl();
            this.textControChanges = new TXTextControl.TextControl();
            this.textControlLineBreak = new TXTextControl.TextControl();
            this.lblZusatzwerte = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkGegenzeichnen = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelBeschreibungTXTEditor = new System.Windows.Forms.Panel();
            this.txtBeschreibungLine = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbMassnahme = new PMDS.GUI.BaseControls.MassnahmenCombo();
            this.cbBedarfsMedikament = new PMDS.GUI.BaseControls.BedarfsMedikamentCombo();
            this.auswahlGruppeComboMulti1 = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.ucZusatzWert1 = new PMDS.GUI.ucZusatzWert();
            this.cbImportant = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblPflegestufeneinschaetzung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbPflegestufenEinschaetzung = new PMDS.GUI.BaseControls.PflegestufenEinschaetzung();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).BeginInit();
            this.panelTxtControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblWichtigFür
            // 
            this.lblWichtigFür.AutoSize = true;
            this.lblWichtigFür.Location = new System.Drawing.Point(17, 41);
            this.lblWichtigFür.Margin = new System.Windows.Forms.Padding(4);
            this.lblWichtigFür.Name = "lblWichtigFür";
            this.lblWichtigFür.Size = new System.Drawing.Size(70, 17);
            this.lblWichtigFür.TabIndex = 17;
            this.lblWichtigFür.Text = "Wichtig für";
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(17, 189);
            this.lblAnmerkung.Margin = new System.Windows.Forms.Padding(4);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(209, 17);
            this.lblAnmerkung.TabIndex = 23;
            this.lblAnmerkung.Text = "Dekurs (Strg-F3 = Textbausteine)";
            // 
            // lblZeitpunktDerDurchführung
            // 
            this.lblZeitpunktDerDurchführung.AutoSize = true;
            this.lblZeitpunktDerDurchführung.Location = new System.Drawing.Point(17, 12);
            this.lblZeitpunktDerDurchführung.Margin = new System.Windows.Forms.Padding(4);
            this.lblZeitpunktDerDurchführung.Name = "lblZeitpunktDerDurchführung";
            this.lblZeitpunktDerDurchführung.Size = new System.Drawing.Size(172, 17);
            this.lblZeitpunktDerDurchführung.TabIndex = 14;
            this.lblZeitpunktDerDurchführung.Text = "Zeitpunkt der Durchführung";
            // 
            // labMassnahme
            // 
            this.labMassnahme.AutoSize = true;
            this.labMassnahme.Location = new System.Drawing.Point(17, 101);
            this.labMassnahme.Margin = new System.Windows.Forms.Padding(4);
            this.labMassnahme.Name = "labMassnahme";
            this.labMassnahme.Size = new System.Drawing.Size(74, 17);
            this.labMassnahme.TabIndex = 21;
            this.labMassnahme.Text = "Maßnahme";
            // 
            // chkDone
            // 
            this.chkDone.Location = new System.Drawing.Point(399, 9);
            this.chkDone.Margin = new System.Windows.Forms.Padding(4);
            this.chkDone.Name = "chkDone";
            this.chkDone.Size = new System.Drawing.Size(128, 25);
            this.chkDone.TabIndex = 1;
            this.chkDone.Text = "Durchgeführt";
            this.chkDone.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // dtpZeitpunkt
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.dtpZeitpunkt.Appearance = appearance1;
            this.dtpZeitpunkt.BackColor = System.Drawing.Color.White;
            this.dtpZeitpunkt.FormatString = "";
            this.dtpZeitpunkt.Location = new System.Drawing.Point(220, 9);
            this.dtpZeitpunkt.Margin = new System.Windows.Forms.Padding(4);
            this.dtpZeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpZeitpunkt.Name = "dtpZeitpunkt";
            this.dtpZeitpunkt.ownFormat = "";
            this.dtpZeitpunkt.ownMaskInput = "";
            this.dtpZeitpunkt.Size = new System.Drawing.Size(171, 24);
            this.dtpZeitpunkt.TabIndex = 0;
            this.dtpZeitpunkt.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.dtpZeitpunkt.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dtpZeitpunkt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblDauer
            // 
            this.lblDauer.AutoSize = true;
            this.lblDauer.Location = new System.Drawing.Point(535, 12);
            this.lblDauer.Margin = new System.Windows.Forms.Padding(4);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(42, 17);
            this.lblDauer.TabIndex = 19;
            this.lblDauer.Text = "Dauer";
            // 
            // txtIstDauer
            // 
            this.txtIstDauer.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtIstDauer.InputMask = "999";
            this.txtIstDauer.Location = new System.Drawing.Point(645, 9);
            this.txtIstDauer.Margin = new System.Windows.Forms.Padding(4);
            this.txtIstDauer.Name = "txtIstDauer";
            this.txtIstDauer.NonAutoSizeHeight = 20;
            this.txtIstDauer.Size = new System.Drawing.Size(53, 23);
            this.txtIstDauer.TabIndex = 2;
            this.txtIstDauer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblMedikation
            // 
            this.lblMedikation.AutoSize = true;
            this.lblMedikation.Location = new System.Drawing.Point(17, 74);
            this.lblMedikation.Margin = new System.Windows.Forms.Padding(4);
            this.lblMedikation.Name = "lblMedikation";
            this.lblMedikation.Size = new System.Drawing.Size(80, 17);
            this.lblMedikation.TabIndex = 34;
            this.lblMedikation.Text = "Medikament";
            this.lblMedikation.Visible = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(707, 12);
            this.lblMin.Margin = new System.Windows.Forms.Padding(4);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(27, 17);
            this.lblMin.TabIndex = 35;
            this.lblMin.Text = "min";
            // 
            // chkAlsDekursKopieren
            // 
            this.chkAlsDekursKopieren.Enabled = false;
            this.chkAlsDekursKopieren.Location = new System.Drawing.Point(220, 124);
            this.chkAlsDekursKopieren.Margin = new System.Windows.Forms.Padding(4);
            this.chkAlsDekursKopieren.Name = "chkAlsDekursKopieren";
            this.chkAlsDekursKopieren.Size = new System.Drawing.Size(159, 22);
            this.chkAlsDekursKopieren.TabIndex = 7;
            this.chkAlsDekursKopieren.Text = "Als Dekurs kopieren";
            this.chkAlsDekursKopieren.Visible = false;
            this.chkAlsDekursKopieren.CheckedChanged += new System.EventHandler(this.chkAlsDekursKopieren_CheckedChanged);
            // 
            // textControlOriginal
            // 
            this.textControlOriginal.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlOriginal.Location = new System.Drawing.Point(517, 7);
            this.textControlOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.textControlOriginal.Name = "textControlOriginal";
            this.textControlOriginal.Size = new System.Drawing.Size(61, 43);
            this.textControlOriginal.TabIndex = 38;
            this.textControlOriginal.UserNames = null;
            this.textControlOriginal.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // panelTxtControl
            // 
            this.panelTxtControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTxtControl.BackColor = System.Drawing.Color.Transparent;
            this.panelTxtControl.Controls.Add(this.textControSave);
            this.panelTxtControl.Controls.Add(this.textControChanges);
            this.panelTxtControl.Controls.Add(this.textControlLineBreak);
            this.panelTxtControl.Controls.Add(this.textControlOriginal);
            this.panelTxtControl.Location = new System.Drawing.Point(220, 583);
            this.panelTxtControl.Margin = new System.Windows.Forms.Padding(4);
            this.panelTxtControl.Name = "panelTxtControl";
            this.panelTxtControl.Size = new System.Drawing.Size(38, 22);
            this.panelTxtControl.TabIndex = 39;
            // 
            // textControSave
            // 
            this.textControSave.Font = new System.Drawing.Font("Arial", 10F);
            this.textControSave.Location = new System.Drawing.Point(587, 4);
            this.textControSave.Margin = new System.Windows.Forms.Padding(4);
            this.textControSave.Name = "textControSave";
            this.textControSave.Size = new System.Drawing.Size(61, 43);
            this.textControSave.TabIndex = 42;
            this.textControSave.UserNames = null;
            this.textControSave.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControChanges
            // 
            this.textControChanges.Font = new System.Drawing.Font("Arial", 10F);
            this.textControChanges.Location = new System.Drawing.Point(656, 6);
            this.textControChanges.Margin = new System.Windows.Forms.Padding(4);
            this.textControChanges.Name = "textControChanges";
            this.textControChanges.Size = new System.Drawing.Size(61, 43);
            this.textControChanges.TabIndex = 41;
            this.textControChanges.UserNames = null;
            this.textControChanges.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControlLineBreak
            // 
            this.textControlLineBreak.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlLineBreak.Location = new System.Drawing.Point(725, 4);
            this.textControlLineBreak.Margin = new System.Windows.Forms.Padding(4);
            this.textControlLineBreak.Name = "textControlLineBreak";
            this.textControlLineBreak.Size = new System.Drawing.Size(61, 43);
            this.textControlLineBreak.TabIndex = 43;
            this.textControlLineBreak.UserNames = null;
            this.textControlLineBreak.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // lblZusatzwerte
            // 
            this.lblZusatzwerte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZusatzwerte.AutoSize = true;
            this.lblZusatzwerte.Location = new System.Drawing.Point(459, 189);
            this.lblZusatzwerte.Margin = new System.Windows.Forms.Padding(4);
            this.lblZusatzwerte.Name = "lblZusatzwerte";
            this.lblZusatzwerte.Size = new System.Drawing.Size(80, 17);
            this.lblZusatzwerte.TabIndex = 40;
            this.lblZusatzwerte.Text = "Zusatzwerte";
            // 
            // chkGegenzeichnen
            // 
            this.chkGegenzeichnen.Location = new System.Drawing.Point(398, 124);
            this.chkGegenzeichnen.Margin = new System.Windows.Forms.Padding(4);
            this.chkGegenzeichnen.Name = "chkGegenzeichnen";
            this.chkGegenzeichnen.Size = new System.Drawing.Size(206, 22);
            this.chkGegenzeichnen.TabIndex = 8;
            this.chkGegenzeichnen.Text = "Gegenzeichnen erforderlich";
            this.chkGegenzeichnen.CheckedChanged += new System.EventHandler(this.chkZurKenntnissnahme_CheckedChanged);
            // 
            // panelBeschreibungTXTEditor
            // 
            this.panelBeschreibungTXTEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBeschreibungTXTEditor.BackColor = System.Drawing.Color.Transparent;
            this.panelBeschreibungTXTEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBeschreibungTXTEditor.Location = new System.Drawing.Point(9, 215);
            this.panelBeschreibungTXTEditor.Margin = new System.Windows.Forms.Padding(4);
            this.panelBeschreibungTXTEditor.Name = "panelBeschreibungTXTEditor";
            this.panelBeschreibungTXTEditor.Size = new System.Drawing.Size(443, 390);
            this.panelBeschreibungTXTEditor.TabIndex = 45;
            // 
            // txtBeschreibungLine
            // 
            this.txtBeschreibungLine.AcceptsReturn = true;
            this.txtBeschreibungLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeschreibungLine.Location = new System.Drawing.Point(47, 250);
            this.txtBeschreibungLine.Margin = new System.Windows.Forms.Padding(4);
            this.txtBeschreibungLine.Name = "txtBeschreibungLine";
            this.txtBeschreibungLine.Size = new System.Drawing.Size(81, 24);
            this.txtBeschreibungLine.TabIndex = 48;
            this.txtBeschreibungLine.Visible = false;
            // 
            // cbMassnahme
            // 
            this.cbMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMassnahme.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMassnahme.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbMassnahme.Location = new System.Drawing.Point(220, 97);
            this.cbMassnahme.Margin = new System.Windows.Forms.Padding(4);
            this.cbMassnahme.Name = "cbMassnahme";
            this.cbMassnahme.Size = new System.Drawing.Size(625, 24);
            this.cbMassnahme.TabIndex = 6;
            this.cbMassnahme.ValueChanged += new System.EventHandler(this.cbMassnahme_ValueChanged);
            // 
            // cbBedarfsMedikament
            // 
            this.cbBedarfsMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBedarfsMedikament.Location = new System.Drawing.Point(220, 69);
            this.cbBedarfsMedikament.Margin = new System.Windows.Forms.Padding(4);
            this.cbBedarfsMedikament.MaxDropDownItems = 30;
            this.cbBedarfsMedikament.Name = "cbBedarfsMedikament";
            this.cbBedarfsMedikament.Size = new System.Drawing.Size(625, 24);
            this.cbBedarfsMedikament.TabIndex = 5;
            this.cbBedarfsMedikament.Visible = false;
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auswahlGruppeComboMulti1.BackColor = System.Drawing.Color.Transparent;
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(220, 36);
            this.auswahlGruppeComboMulti1.Margin = new System.Windows.Forms.Padding(4);
            this.auswahlGruppeComboMulti1.Name = "auswahlGruppeComboMulti1";
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(625, 28);
            this.auswahlGruppeComboMulti1.TabIndex = 4;
            this.auswahlGruppeComboMulti1.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatzWert1.BackColor = System.Drawing.Color.Transparent;
            this.ucZusatzWert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucZusatzWert1.IgnoreNotOptional = false;
            this.ucZusatzWert1.IZusatz = null;
            this.ucZusatzWert1.Location = new System.Drawing.Point(459, 215);
            this.ucZusatzWert1.Margin = new System.Windows.Forms.Padding(5);
            this.ucZusatzWert1.Name = "ucZusatzWert1";
            this.ucZusatzWert1.ReadOnly = false;
            this.ucZusatzWert1.Size = new System.Drawing.Size(425, 387);
            this.ucZusatzWert1.TabIndex = 9;
            this.ucZusatzWert1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbImportant
            // 
            this.cbImportant.AddEmptyEntry = false;
            this.cbImportant.AutoOpenCBO = false;
            this.cbImportant.BerufsstandGruppeJNA = -1;
            this.cbImportant.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbImportant.ExactMatch = false;
            this.cbImportant.Group = "BER";
            this.cbImportant.ID_PEP = -1;
            this.cbImportant.IgnoreUnterdruecken = true;
            this.cbImportant.Location = new System.Drawing.Point(95, 37);
            this.cbImportant.Margin = new System.Windows.Forms.Padding(4);
            this.cbImportant.Name = "cbImportant";
            this.cbImportant.PflichtJN = false;
            this.cbImportant.SelectDistinct = false;
            this.cbImportant.ShowAddButton = true;
            this.cbImportant.Size = new System.Drawing.Size(76, 24);
            this.cbImportant.sys = false;
            this.cbImportant.TabIndex = 3;
            this.cbImportant.Visible = false;
            this.cbImportant.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPflegestufeneinschaetzung
            // 
            this.lblPflegestufeneinschaetzung.Location = new System.Drawing.Point(17, 153);
            this.lblPflegestufeneinschaetzung.Name = "lblPflegestufeneinschaetzung";
            this.lblPflegestufeneinschaetzung.Padding = new System.Drawing.Size(0, 4);
            this.lblPflegestufeneinschaetzung.Size = new System.Drawing.Size(172, 23);
            this.lblPflegestufeneinschaetzung.TabIndex = 134;
            this.lblPflegestufeneinschaetzung.Text = "PSE-Kriterium";
            // 
            // cbPflegestufenEinschaetzung
            // 
            this.cbPflegestufenEinschaetzung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPflegestufenEinschaetzung.Location = new System.Drawing.Point(220, 153);
            this.cbPflegestufenEinschaetzung.Name = "cbPflegestufenEinschaetzung";
            this.cbPflegestufenEinschaetzung.PSEKlasse = "";
            this.cbPflegestufenEinschaetzung.Size = new System.Drawing.Size(625, 24);
            this.cbPflegestufenEinschaetzung.strDefault = null;
            this.cbPflegestufenEinschaetzung.TabIndex = 133;
            // 
            // ucPflegeEintrag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.panelTxtControl);
            this.Controls.Add(this.lblPflegestufeneinschaetzung);
            this.Controls.Add(this.cbPflegestufenEinschaetzung);
            this.Controls.Add(this.panelBeschreibungTXTEditor);
            this.Controls.Add(this.txtBeschreibungLine);
            this.Controls.Add(this.cbMassnahme);
            this.Controls.Add(this.chkGegenzeichnen);
            this.Controls.Add(this.cbBedarfsMedikament);
            this.Controls.Add(this.auswahlGruppeComboMulti1);
            this.Controls.Add(this.lblZusatzwerte);
            this.Controls.Add(this.ucZusatzWert1);
            this.Controls.Add(this.lblZeitpunktDerDurchführung);
            this.Controls.Add(this.chkAlsDekursKopieren);
            this.Controls.Add(this.lblAnmerkung);
            this.Controls.Add(this.labMassnahme);
            this.Controls.Add(this.cbImportant);
            this.Controls.Add(this.lblWichtigFür);
            this.Controls.Add(this.chkDone);
            this.Controls.Add(this.dtpZeitpunkt);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblDauer);
            this.Controls.Add(this.txtIstDauer);
            this.Controls.Add(this.lblMedikation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucPflegeEintrag";
            this.Size = new System.Drawing.Size(893, 609);
            this.Load += new System.EventHandler(this.ucPflegeEintrag_Load);
            this.VisibleChanged += new System.EventHandler(this.ucPflegeEintrag_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).EndInit();
            this.panelTxtControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected virtual void InitSubComponent()
        {
            // keine Operationen notwendig
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegeEintrag Eintrag
        {
            get
            {
                return _eintrag;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Eintrag");

                _valueChangeEnabled = false;
                _eintrag = value;
                //UpdateGUI();
                _valueChangeEnabled = true;
            }
        }

        public void valueChanged()
        {
            object o = new object();
            EventArgs ev = new EventArgs();
            this.OnValueChanged(o, ev);
        }
        public void valueChangedBeschreibungTxtControl()
        {
            if (this.chkAlsDekursKopieren.Visible)
            {
                if (!String.IsNullOrWhiteSpace(this.contTXTFieldBeschreibung.TXTControlField.Text))
                {
                    this.chkAlsDekursKopieren.Checked = true;
                    setWichtigFuerDefaults(eDekursDefaults.Intervention.ToString(), false);   
                }
                else
                {
                    this.chkAlsDekursKopieren.Checked = false;
                    setWichtigFuerDefaults(eDekursDefaults.Intervention.ToString(), true);    
                }
            }
            else
            {
                
            }
        }
        public void SetZeitpunktDerRueckmeldungAufHeute()
        {
            DateTime dt = dtpZeitpunkt.DateTime;
            dtpZeitpunkt.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dt.Hour, dt.Minute, dt.Second);
            if (dtpZeitpunkt.DateTime > DateTime.Now && dtpZeitpunkt.DateTime.Date == DateTime.Now.Date)		// am selben Tag aber später ==> suggerieren das es jetzt für später gemacht wird
                dtpZeitpunkt.DateTime = DateTime.Now;
        }
        public void SetZeitpunktDerRueckmeldungAufJetzt()
        {
            dtpZeitpunkt.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public virtual void UpdateGUI()
        {
            if (this.IsDekursEntwurf && this.IDPflegeeintragEntwurf != null)
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDSBusiness PMDSBusiness2 = new PMDSBusiness();

                    IQueryable<PMDS.db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(pe => pe.ID == this.IDPflegeeintragEntwurf.Value);
                    PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurf = tPflegeEintragEntwurf.First();

                    PMDS.db.Entities.Aufenthalt rAufenthalt = PMDSBusiness2.getAufenthalt(rPflegeEintragEntwurf.IDAufenthalt, db);
                    //os191224
                    Guid IDPatient = new Guid(rAufenthalt.IDPatient.Value.ToString());
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == IDPatient
                                    select new
                                    { p.Nachname, p.Vorname }
                                   ).First();
                    //PMDS.db.Entities.Patient rPatient = PMDSBusiness2.getPatient(rAufenthalt.IDPatient.Value, db);
                    
                    this.IDPatientEntwurf = IDPatient;
                    if (rPflegeEintragEntwurf.FuerUserErstellt != null)
                    {
                        this.IDFuerUserErstellt = rPflegeEintragEntwurf.FuerUserErstellt.Value;
                    }

                    this.Eintrag.ID = rPflegeEintragEntwurf.ID;
                    this.Eintrag.IDAufenthalt = rPflegeEintragEntwurf.IDAufenthalt;

                    this.frmPatientVermerkMainWindow.labInfo.Text = "Dekurs für {0}";
                    this.frmPatientVermerkMainWindow.labInfo.Text = string.Format(this.frmPatientVermerkMainWindow.labInfo.Text, rPatInfo.Vorname.Trim() + " " + rPatInfo.Nachname.Trim());
                    if (IDFuerUserErstellt != null)
                    {
                        PMDS.db.Entities.Benutzer rBenutzerFür = PMDSBusiness2.getUser(IDFuerUserErstellt.Value, db);
                        this.frmPatientVermerkMainWindow.labInfo.Text += " (Erstellt für: " + rBenutzerFür.Nachname.Trim() + " " + rBenutzerFür.Vorname.Trim() + ")";
                    }

                    if (rPflegeEintragEntwurf.IDPflegePlan != null)
                    {
                        this.Eintrag.IDPflegePlan = rPflegeEintragEntwurf.IDPflegePlan.Value;
                    }
                    if (rPflegeEintragEntwurf.IDEintrag != null)
                    {
                        this.Eintrag.IDEintrag = rPflegeEintragEntwurf.IDEintrag.Value;
                    }
                    if (rPflegeEintragEntwurf.IDExtern != null)
                    {
                        this.Eintrag.IDExtern = rPflegeEintragEntwurf.IDExtern.Value;
                    }
                    this.Eintrag.IDBenutzer = rPflegeEintragEntwurf.IDBenutzer.Value;
                    if (rPflegeEintragEntwurf.IDBerufsstand != null)
                    {
                        this.Eintrag.IDBerufsstand = rPflegeEintragEntwurf.IDBerufsstand.Value;
                    }
                    if (rPflegeEintragEntwurf.DatumErstellt != null)
                    {
                        this.Eintrag.DatumErstellt = rPflegeEintragEntwurf.DatumErstellt.Value;
                    }

                    rPflegeEintragEntwurf.Zeitpunkt = DateTime.Now;
                    this.Eintrag.Zeitpunkt = rPflegeEintragEntwurf.Zeitpunkt.Value;
                    //if (rPflegeEintragEntwurf.Zeitpunkt != null)
                    //{
                    //    this.Eintrag.Zeitpunkt = rPflegeEintragEntwurf.Zeitpunkt.Value;
                    //}

                    this.Eintrag.LogInNameFrei = rPflegeEintragEntwurf.LogInNameFrei;
                    if (rPflegeEintragEntwurf.IDBefund != null)
                    {
                        this.Eintrag.IDBefund = rPflegeEintragEntwurf.IDBefund.Value;
                    }
                    this.Eintrag.PflegeplanText = rPflegeEintragEntwurf.PflegeplanText;
                    this.Eintrag.Text = rPflegeEintragEntwurf.Text;
                    this.Eintrag.TextRtf = rPflegeEintragEntwurf.TextRtf;
                    if (rPflegeEintragEntwurf.IstDauer != null)
                    {
                        this.Eintrag.IstDauer = rPflegeEintragEntwurf.IstDauer.Value;
                    }
                    if (rPflegeEintragEntwurf.DurchgefuehrtJN != null)
                    {
                        this.Eintrag.DurchgefuehrtJN = rPflegeEintragEntwurf.DurchgefuehrtJN.Value;
                    }
                    if (rPflegeEintragEntwurf.EintragsTyp != null)
                    {
                        this.Eintrag.EintragsTyp = PMDS.Global.Enums.searchEnumPflegeEintragTyp(rPflegeEintragEntwurf.EintragsTyp.Value);
                    }
                    if (rPflegeEintragEntwurf.Wichtig != null && rPflegeEintragEntwurf.Wichtig.Value != -1)
                    {
                        this.Eintrag.Wichtig = PMDS.Global.Enums.searchEnumPflegeEintragWichtig(rPflegeEintragEntwurf.Wichtig.Value);
                    }
                    if (rPflegeEintragEntwurf.IDWichtig != null)
                    {
                        this.Eintrag.IDWichtig = rPflegeEintragEntwurf.IDWichtig.Value;
                    }
                    this.Eintrag.Dekursherkunft = PMDS.Global.Enums.searchEnumDekursherkunft(rPflegeEintragEntwurf.Dekursherkunft);
                    this.Eintrag.AbzeichnenJN = rPflegeEintragEntwurf.AbzeichnenJN;
                    this.Eintrag.HAGPflichtigJN = rPflegeEintragEntwurf.HAGPflichtigJN;
                    if (rPflegeEintragEntwurf.IDEvaluierung != null)
                    {
                        this.Eintrag.IDEvaluierung = rPflegeEintragEntwurf.IDEvaluierung.Value;
                    }
                    if (rPflegeEintragEntwurf.EvalStatus != null && rPflegeEintragEntwurf.EvalStatus.Value != -1)
                    {
                        this.Eintrag.EvalStatus = PMDS.Global.Enums.searchEnumZielEvaluierungsStatus(rPflegeEintragEntwurf.EvalStatus.Value);
                    }

                    
                    System.Collections.Generic.List<Guid> lstBerufsgruppeSelected = new List<Guid>();
                    System.Collections.Generic.List<string> lstStrBerufsgruppe = qs2.core.generic.readStrVariables(rPflegeEintragEntwurf.lstSelectedCC.Trim());
                    foreach (string sIDBerufsgruppe in lstStrBerufsgruppe)
                    {
                        lstBerufsgruppeSelected.Add(new System.Guid(sIDBerufsgruppe.Trim()));
                    }

                    System.Collections.Generic.List<int> lstInt = new List<int>();
                    System.Collections.Generic.List<string> lstString = new List<string>();
                    this.auswahlGruppeComboMulti1.clearSelectedNodes();
                    this.auswahlGruppeComboMulti1.setSelected(lstBerufsgruppeSelected, lstInt, lstString);

                    this.frmPatientVermerkMainWindow.lstPatienteSelected2.Clear();

                    PMDS.Global.UIGlobal UIGlobal1 = new UIGlobal();
                    UIGlobal1.removeDoubledPatients(this.frmPatientVermerkMainWindow.lstPatienteSelected2);
                }
            }

            this.textControlOriginal.Text = "";
            this.textControChanges.Text = "";

            this.ucZusatzWert1.IDAufenthalt = Eintrag.IDAufenthalt;
            this.ucZusatzWert1.IZusatz = (IZusatz)Eintrag;

            //Bei Befund im Einzelrückmeldungsmodus: jedenfalls aktuelle Uhrzeit vorschlagen
            if (!(this._IsBefund && !this._IsSchnellrückmeldung) && !this._OhneZeitbezug)
            {
                if (ENV.ToleranzIntervall > 0)
                {
                    if (Eintrag.Zeitpunkt.AddHours(ENV.ToleranzIntervall) < DateTime.Now)  //Geplanter Zeitpunkt liegt außerhalb des Toleranzintervalls -> Zeitpunkt der Durchführung auf jetzt setzen
                        this.dtpZeitpunkt.Value = DateTime.Now;
                    else
                        this.dtpZeitpunkt.Value = Eintrag.Zeitpunkt;
                }
                else
                    this.dtpZeitpunkt.Value = Eintrag.Zeitpunkt;
            }
            else
            {
                this.dtpZeitpunkt.Value = DateTime.Now;
            }

            this.chkDone.Checked = Eintrag.DurchgefuehrtJN;
            this.txtIstDauer.Value = Eintrag.IstDauer.ToString();

            byte[] b = null;
            if (!this._IsSchnellrückmeldung)
            {
                if (String.IsNullOrWhiteSpace(Eintrag.TextRtf))
                {
                    this.contTXTFieldBeschreibung.showText(Eintrag.Text, TXTextControl.StreamType.PlainText);
                    this.doEditor1.showText(Eintrag.Text, TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                                                this.textControlOriginal, ref b, ref b);
                }
                else
                {
                    this.contTXTFieldBeschreibung.showText(Eintrag.TextRtf, TXTextControl.StreamType.RichTextFormat);
                    this.doEditor1.showText(Eintrag.TextRtf, TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                                this.textControlOriginal, ref b, ref b);
                }
            }
            else
            {
                this.txtBeschreibungLine.Text = Eintrag.Text.Trim();
                this.setUIPanelBeschreibungSchnellRückmeldung();
            }

            this.cbImportant.ID = Eintrag.IDWichtig;
            if (!this._IsSchnellrückmeldung)
                this.cbMassnahme.ID = Eintrag.IDEintrag;

            this.chkGegenzeichnen.Checked = Eintrag.AbzeichnenJN;

            this.UpdateMode();
            this.CheckZusatzVisibility();
            if (Eintrag.IDEintrag != Guid.Empty)
                this.CheckBedarfsMedikation();


            if (!this._IsSchnellrückmeldung)
            {
                this.contTXTFieldBeschreibung.bReadOnly = this.ReadOnly;
            }
            else
            {
                this.txtBeschreibungLine.ReadOnly = this.ReadOnly;
            }

            if (this.IDEintragFromQuickbutton != null && this.cbMassnahme.Visible)
            {
                this.SelectEintragAuto();
            }

            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            bool UserCanEdit = PMDSBusiness1.UserCanEdit(Eintrag.IDBenutzer, Eintrag.EintragsTyp);

            if (this.frmPatientRueckmeldung1 != null)
            {
                this.frmPatientRueckmeldung1.SetbtnEditVisible(ReadOnly && UserCanEdit);
                this.frmPatientRueckmeldung1.AlignButtons();
            }

            if (UserCanEdit)
            {
                this.HistorischerModus = (Eintrag.DatumErstellt.Date.AddDays(1) < DateTime.Now) || !ENV.FullEditMode;   //Wenn Eintrag älter als 24 Stunden ist oder FullEditMode NICHT erlaubt ist -> immer Historischer Modus 
                if (this.btnDelete != null)
                {
                    this.btnDelete.Visible = false;
                }
            }

            else
            {
                if (this.btnDelete != null)
                {
                    this.btnDelete.Visible = false;
                }
            }

            if (this.IsDekursEntwurf && !String.IsNullOrWhiteSpace(this.DekursTextRtfTemplate))
            {
                byte[] bDek = null;
                this.contTXTFieldBeschreibung.showText(this.DekursTextRtfTemplate, TXTextControl.StreamType.RichTextFormat);
                this.textControlOriginal.Text = "";
            }

        }
        public virtual void saveGUIEntwurf(ref PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurf,
                                           ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2,
                                           PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                rPflegeEintragEntwurf.IDAufenthalt = this.Eintrag.IDAufenthalt;
                if (this.Eintrag.IDPflegePlan != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDPflegePlan = this.Eintrag.IDPflegePlan;
                }
                else
                {
                    rPflegeEintragEntwurf.IDPflegePlan = null;
                }
                if (this.Eintrag.IDEintrag != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDEintrag = this.Eintrag.IDEintrag;
                }
                else
                {
                    rPflegeEintragEntwurf.IDEintrag = null;
                }
                if (this.Eintrag.IDExtern != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDExtern = this.Eintrag.IDExtern;
                }
                else
                {
                    rPflegeEintragEntwurf.IDExtern = null;
                }
                rPflegeEintragEntwurf.IDBenutzer = this.Eintrag.IDBenutzer;
                if (this.Eintrag.IDBerufsstand != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDBerufsstand = this.Eintrag.IDBerufsstand;
                }
                else
                {
                    rPflegeEintragEntwurf.IDBerufsstand = null;
                }
                if (rPflegeEintragEntwurf.FuerUserErstellt != null)
                {
                    PMDS.db.Entities.Benutzer rBenutzerEntwurf = this.PMDSBusiness1.getUser(rPflegeEintragEntwurf.FuerUserErstellt.Value, db);
                    if (rBenutzerEntwurf.IDBerufsstand != null)
                    {
                        rPflegeEintragEntwurf.IDBerufsstand = rBenutzerEntwurf.IDBerufsstand.Value;
                    }
                    else
                    {
                        rPflegeEintragEntwurf.IDBerufsstand = System.Guid.Empty;
                    }

                }
                rPflegeEintragEntwurf.DatumErstellt = this.Eintrag.DatumErstellt;
                rPflegeEintragEntwurf.Zeitpunkt = this.Eintrag.Zeitpunkt;
                rPflegeEintragEntwurf.LogInNameFrei = this.Eintrag.LogInNameFrei;
                rPflegeEintragEntwurf.PflegeplanText = this.Eintrag.PflegeplanText;
                rPflegeEintragEntwurf.Text = this.Eintrag.Text;
                rPflegeEintragEntwurf.TextRtf = this.Eintrag.TextRtf;
                rPflegeEintragEntwurf.IstDauer = this.Eintrag.IstDauer;
                rPflegeEintragEntwurf.DurchgefuehrtJN = this.Eintrag.DurchgefuehrtJN;
                rPflegeEintragEntwurf.EintragsTyp = (int)this.Eintrag.EintragsTyp;
                rPflegeEintragEntwurf.Wichtig = (int)this.Eintrag.Wichtig;
                if (this.Eintrag.IDWichtig != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDWichtig = this.Eintrag.IDWichtig;
                }
                else
                {
                    rPflegeEintragEntwurf.IDWichtig = null;
                }
                rPflegeEintragEntwurf.Dekursherkunft = (int)this.Eintrag.Dekursherkunft;
                rPflegeEintragEntwurf.AbzeichnenJN = this.Eintrag.AbzeichnenJN;
                rPflegeEintragEntwurf.HAGPflichtigJN = this.Eintrag.HAGPflichtigJN;
                if (this.Eintrag.IDEvaluierung != Guid.Empty)
                {
                    rPflegeEintragEntwurf.IDEvaluierung = this.Eintrag.IDEvaluierung;
                }
                else
                {
                    rPflegeEintragEntwurf.IDEvaluierung = null;
                }
                if ((int)this.Eintrag.EvalStatus != -1)
                {
                    rPflegeEintragEntwurf.EvalStatus = (int)this.Eintrag.EvalStatus;
                }

                rPflegeEintragEntwurf.lstSelectedCC = "";
                System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
                this.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);
                foreach (Guid IDBerufsgruppe in lstSelectedCC)
                {
                    rPflegeEintragEntwurf.lstSelectedCC += IDBerufsgruppe.ToString() + ";";
                }

                rPflegeEintragEntwurf.lstSelectedPatient = "";
            }
            catch (Exception ex)
            {
                throw new Exception("ucPflegeeintrag.saveGUIEntwurf: " + ex.ToString());
            }
        }

        public void SelectEintragAuto()
        {
            foreach (Infragistics.Win.ValueListItem itm in this.cbMassnahme.Items)
            {
                if (this.IDEintragFromQuickbutton.Equals(((Guid)itm.DataValue)))
                {
                    this.cbMassnahme.SelectedItem = itm;
                    return;
                }
            }
            throw new Exception("SelectEintragAuto: IDEintragFromQuickbutton '" + IDEintragFromQuickbutton.ToString() + "' not found!");
        }

        private void CheckZusatzVisibility()
        {
            if (!ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                ucZusatzWert1.Visible = false;
            else
                ucZusatzWert1.Visible = true;
        }

        protected virtual void UpdateMode()
        {
            bool bIsMassnahme = Eintrag.IsPflegePlan();
            bool bIsUnexpMassnahme = Eintrag.IsUnexpMassnahme() && !_Medikation;
            bool bIsEvaluierung = Eintrag.IsEvaluierung();
            bool bIsTermin = Eintrag.IsTermin();
            bool bIsMedi = Eintrag.IsMedikament();
            bool bIsDekurs = Eintrag.IsDekurs();
            bool bIsEinzelverordnung = Eintrag.IsUnexpMassnahme() && _Medikation;

            chkDone.Enabled = bIsMassnahme || bIsTermin || bIsMedi;
            chkDone.Visible = chkDone.Enabled;
            cbMassnahme.Enabled = bIsUnexpMassnahme || bIsEinzelverordnung;
            cbMassnahme.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsEinzelverordnung;
            labMassnahme.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsEinzelverordnung;
            dtpZeitpunkt.Enabled = bIsMassnahme || bIsUnexpMassnahme || bIsTermin || bIsEinzelverordnung;
            this.lblZusatzwerte.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsTermin;
            ucZusatzWert1.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsTermin;
            chkAlsDekursKopieren.Visible = (bIsMassnahme || (bIsUnexpMassnahme && !_Medikation) || bIsTermin || bIsMedi) && ENV.UseDekursKopieren;     //Nicht bei: Einzelverordnung und bei Dekursen
            lblWichtigFür.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsTermin || bIsMedi || bIsDekurs || bIsEinzelverordnung;   //WichtigFür
            lblAnmerkung.Visible = bIsMassnahme || bIsUnexpMassnahme || bIsTermin || bIsMedi || bIsDekurs || bIsEinzelverordnung;       //Anmerkung

            chkGegenzeichnen.Visible = true;
            if (bIsEinzelverordnung)
            {
                chkGegenzeichnen.Checked = true;                                //Einzelverordnungen müssen immer gegengezeichnet werden

                Nullable<Guid> IDBerufsstandDefault = null;                     //Default für Berufsstand
                IDBerufsstandDefault = DBUtil.getIDBerufsstand(PMDS.Global.eBerufsstand.Arzt);
                if (IDBerufsstandDefault != null)
                    cbImportant.ID = (Guid)IDBerufsstandDefault;
            }

            if (!ENV.AppRunning)
                return;
        }

        public void UpdateDATA()
        {
            if (ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                ucZusatzWert1.UpdateDATA();

            bool bTextChanged = false;
            string rtfTextChanged = "";
            string PlainTextChanged = "";
            if (_editinprogress)                             // Änderungsverarbeitung
            {
                bTextChanged = this.getTextChanges();
                if (bTextChanged)
                {
                    rtfTextChanged = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControChanges);
                    PlainTextChanged = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControChanges);
                }
            }

            Eintrag.LogInNameFrei = ENV.LoginInNameFrei;
            Eintrag.Zeitpunkt = (DateTime)dtpZeitpunkt.Value;
            Eintrag.DurchgefuehrtJN = chkDone.Checked;            
            Eintrag.IstDauer = (txtIstDauer != null ? Convert.ToInt32(txtIstDauer.Value) : 0);

            //Eintrag.Text                = _Medikation && cbBedarfsMedikament.Text.Trim().Length > 0 ? "Einzelverschreibung: " + cbBedarfsMedikament.Text.Remove(cbBedarfsMedikament.Text.IndexOf(";")) + Environment.NewLine + txtBeschreibung.Text : txtBeschreibung.Text;
            //Eintrag.IDWichtig = cbImportant.ID;           //Eintrag wird nicht mehr als "Wichtig Für" gekennzeichnet : os 160422
            if (!this._IsSchnellrückmeldung)
                Eintrag.IDEintrag = cbMassnahme.ID;

            if (this.IDExtern != null)
            {
                Eintrag.IDExtern = (Guid)this.IDExtern;
            }
            else
            {
                Eintrag.IDExtern = System.Guid.Empty;
            }

            Eintrag.Dekursherkunft = this._Dekursherkunft;
            Eintrag.AbzeichnenJN = this.chkGegenzeichnen.Checked;
            
            if (!this._IsSchnellrückmeldung)
            {
                if (_editinprogress)
                {
                    if (this.HistorischerModus)
                    {
                        string sLine = "------------------- Historie --------------------------------------------";
                        this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                        this.doEditor1.appendText2(sLine, this.textControlLineBreak, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                        string txtBreakNewLineBreak = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlLineBreak);

                        string txtBeschreibungRtfNew = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                        string txtBeschreibungPlainNew = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);
                        string txtBeschreibungRtfOrig = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlOriginal);
                        string txtBeschreibungPlainOrig = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControlOriginal);

                        this.doEditor1.appendText2(txtBeschreibungRtfNew.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        if (bTextChanged)
                        {
                            this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                            this.doEditor1.appendText2(rtfTextChanged.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                            //this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                            this.doEditor1.appendText2(txtBeschreibungRtfOrig, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        }
                        else
                        {
                            this.doEditor1.appendText2(txtBeschreibungRtfOrig, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        }

                        string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                        string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);
                        Eintrag.Text = txtBeschreibungPlainTmp;
                        Eintrag.TextRtf = txtBeschreibungPlainRtf;
                    }
                    else
                    {
                        string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                        string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);
                        Eintrag.Text = txtBeschreibungPlainTmp;
                        Eintrag.TextRtf = txtBeschreibungPlainRtf;
                    }
                }
                else
                {
                    string sTxtMedikament = "";
                    if (this.cbBedarfsMedikament.Value != null)
                    {
                        sTxtMedikament = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ") + this.cbBedarfsMedikament.Text.Trim();
                    }

                    this.textControSave.Text = "";
                    if (!String.IsNullOrWhiteSpace(sTxtMedikament))
                    {
                        this.doEditor1.appendText2(sTxtMedikament.Trim(), this.textControSave, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.insertLinebreakxy(this.textControSave);
                        this.doEditor1.insertLinebreakxy(this.textControSave);
                    }

                    string txtBeschreibungPlainRtfTmp = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                    this.doEditor1.appendText2(txtBeschreibungPlainRtfTmp.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                    string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);
                    Eintrag.Text = txtBeschreibungPlainTmp;
                    Eintrag.TextRtf = txtBeschreibungPlainRtf;
                }
            }
            else
            {
                string sTxtMedikament = "";
                //if (this.cbBedarfsMedikament.Value != null)
                //{
                //    sTxtMedikament = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ") + this.cbBedarfsMedikament.Text.Trim() + "\r\n" + "\r\n";
                //}
                Eintrag.Text = (!String.IsNullOrWhiteSpace(sTxtMedikament) ? sTxtMedikament : "") + this.txtBeschreibungLine.Text.Trim();
            }

            if (Eintrag.EintragsTyp == PflegeEintragTyp.UNEXP_MASSNAHME)
            {
                string sText = this.cbMassnahme.Text.Trim();
                Eintrag.PflegeplanText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungeplante Maßnahme: ") + sText;
            }

            if (Eintrag.EintragsTyp == PflegeEintragTyp.DEKURS && ENV.lic_PflegestufenEinschätzung)
            {
                Eintrag.PSEKlasse = this.cbPflegestufenEinschaetzung.PSEKlasse;
            }
        }

        public void RequiredFields()
        {
            if (ReadOnly)				// keine markierung bei Readonly
                return;

            GuiUtil.ValidateRequired(dtpZeitpunkt);
            GuiUtil.ValidateRequired(cbMassnahme);

            if (ENV.lic_PflegestufenEinschätzung)
            {
                GuiUtil.ValidateRequired(txtIstDauer);
            }
            else
            {
                txtIstDauer.Appearance.BackColor = ENVCOLOR.EINTRAG_CURRENT_BACK_COLOR;
            }

            if (!TXTBESCHREIBUNG_OPTIONAL)
            {
                GuiUtil.ValidateRequired(txtBeschreibungLine);

            }
            else
            {
                txtBeschreibungLine.Appearance.BackColor = ENVCOLOR.EINTRAG_CURRENT_BACK_COLOR;
            }
        }
        public void ClearErrorProvider()
        {
            this.errorProvider1.SetError(txtBeschreibungLine, "");
            this.errorProvider1.SetError(dtpZeitpunkt, "");
            this.errorProvider1.SetError(txtIstDauer, "");
        }
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
            System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
            this.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);

            if (this.cbImportant.SelectedIndex > -1 || lstSelectedCC.Count > 0)  //WichtigFür oder WichtigFuerCC gewählt, dann muss auch ein Dekurs eingetragen sein
            {
                 bError = CheckDekursText();
            }

            if (this._IsSchnellrückmeldung)
            {

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.PflegePlan rPflegePlan = db.PflegePlan.Where(pe => pe.ID == this.Eintrag.IDPflegePlan).First();
                    if ((rPflegePlan.RMOptionalJN && !String.IsNullOrWhiteSpace(this.txtBeschreibungLine.Text)) || !rPflegePlan.RMOptionalJN)
                    {
                        if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkTxtRegex(this.txtBeschreibungLine.Text, false))
                        {
                            this.errorProvider1.SetError(this.txtBeschreibungLine, "Error");
                            bError = true;
                        }
                    }
                }
            }

            // dtpZeitpunkt
            if (dtpZeitpunkt.Enabled)
            {
                //if (dtpZeitpunkt.DateTime > DateTime.Now || DBNull.Value.Equals (  dtpZeitpunkt.DateTime    )  )
                //{ dtpZeitpunkt.DateTime = DateTime.Now; }

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                bool DatOK = b.checkDateRückmeldung(dtpZeitpunkt.DateTime, Eintrag.EintragsTyp);
                if (!DatOK)
                {
                    return false;
                }

                //GuiUtil.ValidateField(dtpZeitpunkt, (dtpZeitpunkt.Text.Length > 0),
                //    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);


                //GuiUtil.ValidateField(dtpZeitpunkt, dtpZeitpunkt.DateTime <= DateTime.Now,
                //    ENV.String("GUI.E_NO_FUTURE_ZEITPUNKT"), ref bError, bInfo, errorProvider1);
            }

            // txtIstDauer
            GuiUtil.ValidateField(txtIstDauer, (txtIstDauer.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // cbMassnahme
            if (cbMassnahme.Enabled)
            {
                GuiUtil.ValidateField(cbMassnahme, (cbMassnahme.Value != null),
                    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            if (!TXTBESCHREIBUNG_OPTIONAL || !chkDone.Checked)
            {
                bError = CheckDekursText();
            }

            if (_TestBedarfsMEmpty)
            {
                GuiUtil.ValidateField(cbBedarfsMedikament, (cbBedarfsMedikament.Text.Trim().Length > 0),
                    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            // Zusatzwerte überprüfen
            if (!bError && !ucZusatzWert1.ValidateFields() && chkDone.Checked)
                bError = true;


            return !bError;
        }


        public bool New()
        {
            PflegeEintrag obj = new PflegeEintrag();

            obj.IDAufenthalt = IDAufenthalt;
            obj.IDBenutzer = ENV.USERID;

            Eintrag = obj;
            return true;
        }
        public void Read(object id)
        {
            PflegeEintrag obj = new PflegeEintrag((Guid)id);
            Eintrag = obj;
        }

        public void Read()
        {
            Eintrag.Read();
            Eintrag = Eintrag;
        }

        public void Write()
        {

            Eintrag.Write();
            if (ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                ucZusatzWert1.Write();
            _editinprogress = false;
        }

        public void Delete()
        {
            Eintrag.Delete();
            ucZusatzWert1.Delete();
            New();
        }

        private void cbMassnahme_ValueChanged(object sender, System.EventArgs e)
        {
            //            if (cbMassnahme.Focused) //??????????
            //            {
            if (Eintrag.IsUnexpMassnahme())
            {
                PflegeEintrag tempPE = new PflegeEintrag();
                tempPE.ID = Eintrag.ID;
                tempPE.EintragsTyp = Eintrag.EintragsTyp;

                if (cbMassnahme.Value == null)
                    tempPE.IDEintrag = Guid.Empty;
                else
                    tempPE.IDEintrag = (Guid)cbMassnahme.Value;

                ucZusatzWert1.IZusatz = (IZusatz)tempPE;
                CheckZusatzVisibility();
            }

            if (cbMassnahme.ID != System.Guid.Empty)
                CheckBedarfsMedikation();

            OnValueChanged(sender, e);
            //            }
        }

        private void CheckBedarfsMedikation()
        {
            if (cbMassnahme.ID != System.Guid.Empty)
            {
                bool bMed = DBUtil.GetEintrag(cbMassnahme.ID).BedarfsMedikationJN;
                PrepareForMedikation(bMed, _TestBedarfsMEmpty, RM_OPTIONAL, false);
            }
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
            ucZusatzWert1.IgnoreNotOptional = !chkDone.Checked;
        }

        private void ucPflegeEintrag_Load(object sender, System.EventArgs e)
        {
        }

        private Guid _aufenthalt = Guid.Empty;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
        {
            get { return _aufenthalt; }
            set { _aufenthalt = value; }
        }

        #region IUCBase Members

        DataTable IUCBase.All()
        {
            return PflegeEintrag.ByAufenthalt(IDAufenthalt);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IBusinessBase IUCBase.Object
        {
            get { return Eintrag; }
            set { Eintrag = (PflegeEintrag)value; }
        }

        #endregion

        public bool ReadOnly
        {
            get
            {
                return dtpZeitpunkt.ReadOnly;
            }
            set
            {
                if (!DesignMode)
                {
                    dtpZeitpunkt.ReadOnly = value;
                    txtIstDauer.ReadOnly = value;
                    cbMassnahme.ReadOnly = value;
                    if (!this._IsSchnellrückmeldung)
                    {
                        if (this.contTXTFieldBeschreibung != null)
                        {
                            this.contTXTFieldBeschreibung.bReadOnly = value;
                        }
                    }
                    else
                    {
                        this.txtBeschreibungLine.ReadOnly = value;
                    }

                    chkDone.Enabled = !value;
                    cbImportant.Enabled = !value;
                    ucZusatzWert1.ReadOnly = value;

                    if (value == true)
                    {
                        //this.contTXTFieldBeschreibung.BackColor = _ReadonlyColor;
                        dtpZeitpunkt.Appearance.BackColor = _ReadonlyColor;
                        cbMassnahme.Appearance.BackColor = _ReadonlyColor;
                        txtIstDauer.Appearance.BackColor = _ReadonlyColor;
                        cbImportant.Appearance.BackColor = _ReadonlyColor;
                    }
                    else
                    {
                        //this.contTXTFieldBeschreibung.ResetBackColor();
                        dtpZeitpunkt.Appearance.ResetBackColor();
                        cbMassnahme.Appearance.ResetBackColor();
                        txtIstDauer.Appearance.ResetBackColor();
                        cbImportant.Appearance.ResetBackColor();
                    }
                }

            }
        }

        public void PrepareForEdit2()
        {
            ReadOnly = false;
            _editinprogress = true;
            _alValues = ucZusatzWert1.GetWertBezeichnung();
            if (this.HistorischerModus)
            {
                if (!this._IsSchnellrückmeldung)
                {
                    this.contTXTFieldBeschreibung.TXTControlField.Text = "";
                }
                else
                {
                    this.txtBeschreibungLine.Text = "";
                }
            }
            else
            {

            }
        }

        private bool CheckDekursText()
        {
            if (!this._IsSchnellrückmeldung)
            {
                string txtBeschreibungPlainTmp = this.contTXTFieldBeschreibung.getText(TXTextControl.StringStreamType.PlainText);
                if (String.IsNullOrWhiteSpace(txtBeschreibungPlainTmp))
                {
                    string txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie einen Dekurs ein.");
                    if (!chkDone.Checked)
                        txt += QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\n (Die Maßnahme wurde nicht durchgeführt)");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "", MessageBoxButtons.OK, true);
                    return true;
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.txtBeschreibungLine.Text))
                {
                    this.errorProvider1.SetError(this.txtBeschreibungLine, "Error");
                    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beschreibung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                    return true;
                }
            }
            return false;
        }

        private bool getTextChanges()
        {
            this.textControChanges.Text = "";
            StringBuilder sb = new StringBuilder();

            string sOldUser = new Benutzer(Eintrag.IDBenutzer).FullName;
            string sNewUer = new Benutzer(ENV.USERID).FullName;

            if (Eintrag.Zeitpunkt != dtpZeitpunkt.DateTime)
            {
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt: "));
                
                sb.Append(Eintrag.Zeitpunkt.ToShortDateString() + " " + Eintrag.Zeitpunkt.ToShortTimeString());
            }

            if (Eintrag.DurchgefuehrtJN != chkDone.Checked)
            {
                if (sb.Length > 0) sb.Append(Environment.NewLine);
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Durchgeführt: "));
                sb.Append(Eintrag.DurchgefuehrtJN ? "J" : "N");
            }

            if (Eintrag.IstDauer != Convert.ToInt32(txtIstDauer.Value))
            {
                if (sb.Length > 0) sb.Append(Environment.NewLine);
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dauer: "));
                
                sb.Append(Eintrag.IstDauer.ToString());
            }

            if (_alValues.Count > 0)
            {
                if (sb.Length > 0) sb.Append(Environment.NewLine);
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzwerte vor der Änderung:"));
                
                foreach (string s in _alValues)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(s);
                }
            }

            if (sb.Length == 0)
                return false;

            StringBuilder sbv = new StringBuilder();
            sbv.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Werte vom Benutzer "));
            sbv.Append(sOldUser);
            sbv.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurden durch "));
            sbv.Append(sNewUer);
            sbv.Append(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes(" am {0} um {1} ersetzt.\r\n"), DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
            
            sbv.Append(sb.ToString());

            byte[] b = null;
            this.doEditor1.showText(sbv.ToString(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControChanges, ref b, ref b);
            return true;
        }

        private void cbBedarfsMedikament_TextChanged(object sender, EventArgs e)
        {
            UltraToolTipInfo i = new UltraToolTipInfo();
            i.ToolTipText = "";

            try
            {
                if (cbBedarfsMedikament.SelectedItem == null)
                    return;

                string sText = cbBedarfsMedikament.SelectedItem.Tag.ToString().Trim();
                if (sText.Length == 0)
                    return;

                i.ToolTipText = sText;
            }
            finally
            {
                ultraToolTipManager1.SetUltraToolTip(cbBedarfsMedikament, i);

                if (i.ToolTipText.Length > 0)
                    ultraToolTipManager1.ShowToolTip(cbBedarfsMedikament, PointToScreen(new Point(cbBedarfsMedikament.Left, cbBedarfsMedikament.Top)));
            }
        }

        private void ucDateSelect1_delRefresh(DateTime dat)
        {
            if (dat != null)
            {
                this.dtpZeitpunkt.DateTime = dat;
            }
        }

        private void ucDateSelect1_Load(object sender, EventArgs e)
        {

        }

        private void ucPflegeEintrag_VisibleChanged(object sender, EventArgs e)
        {
            try
            {                
                if (this.Visible && this.Eintrag != null)
                {
                    if (!this._IsSchnellrückmeldung)
                    {
                        this.ClearErrorProvider();
                        this.UpdateGUI();
                        this.RequiredFields();
                        if (!this._IsSchnellrückmeldung)
                        {
                            this.contTXTFieldBeschreibung.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        private void chkAlsDekursKopieren_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAlsDekursKopieren.Focused)
            {
                this.valueChanged();
            }
        }
        private void chkZurKenntnissnahme_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkGegenzeichnen.Focused)
            {
                this.valueChanged();
            }
        }

        public void clickLoadTextbausteine(bool IsSchnellrückmeldung)
        {
            try
            {
                PMDS.GUI.GUI.Main.frmTextbausteinAuswahl frmTextbausteinAuswahl1 = new GUI.Main.frmTextbausteinAuswahl();
                frmTextbausteinAuswahl1.initControl();
                frmTextbausteinAuswahl1.ShowDialog(this);
                if (!frmTextbausteinAuswahl1.abort)
                {
                    if (IsSchnellrückmeldung)
                    {
                        this.txtBeschreibungLine.Text = this.txtBeschreibungLine.Text.Insert(this.txtBeschreibungLine.SelectionStart, frmTextbausteinAuswahl1.TextbausteinAsPlainText);
                    }
                    else
                    {
                        this.contTXTFieldBeschreibung.TXTControlField.Selection.Text = frmTextbausteinAuswahl1.TextbausteinAsPlainText;
                    }
                    
                    if (PMDS.Global.ENV.UseDekursKopieren)
                    {
                        this.chkAlsDekursKopieren.Checked = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadTextbausteine: " + ex.ToString());
            }
        }

        private void BeschreibungKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F3)
                {
                    this.clickLoadTextbausteine(false);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
