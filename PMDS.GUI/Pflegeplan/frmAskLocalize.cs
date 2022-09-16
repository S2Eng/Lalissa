//----------------------------------------------------------------------------
/// <summary>
///	frmAskLocalize.cs - Abfrage der Lokalisierung
/// Erstellt am:	14.10.2004
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using PMDS.Global;
using Infragistics.Shared;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;
using PMDS.GUI.BaseControls;
using PMDS.BusinessLogic;

namespace PMDS.GUI
{
	public class frmAskLocalize : frmBase
	{

		private ASZMSelectionArgs[]			_sa;
		private UltraDateTimeEditor[]		_adt;

		private bool _bCanClose			= true;
		private bool _bOKClicked		= false;
		private bool _bLocalize			= false; 
		private bool _UntertaegigJN		= false;

		private PMDS.GUI.ucButton btnOK;
		private PMDS.GUI.ucButton btnCancel;
		private QS2.Desktop.ControlManagment.BaseLabel lblKörperteilPatient;
		private QS2.Desktop.ControlManagment.BaseLabel lblSeitePatient;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbArea;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbSide;
		private QS2.Desktop.ControlManagment.BaseLableWin lblASZMLokalisierungNichtNotwendig;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbM;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseLabel lblStartdatum;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpStart;
		private QS2.Desktop.ControlManagment.BaseLableWin lblASZMWerdenÜbertragen;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
		private PMDS.GUI.BaseControls.PDXTreeView pdxTreeView1;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbASZM;
		private QS2.Desktop.ControlManagment.BaseLabel lblStartzeitpunkt;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp0;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp1;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp2;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp3;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp6;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp5;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp4;
		private QS2.Desktop.ControlManagment.BasePanel pnlStartZeitpunkte;
		private PMDS.GUI.BaseControls.MassnahmenSerienCombo cbSerie;
		private System.ComponentModel.IContainer components;

		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// Übergeben werden die Texte der zu lokalisierenden Maßnahmen
		/// </summary>
		//----------------------------------------------------------------------------
		public frmAskLocalize(string[] saLocalize, ASZMSelectionArgs[] aa, string sAdditionalHeaderText, bool bLokalisiert, string sLokalisierung, string sLokalisierungSeite)
		{
			_sa = aa;
			InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            FillTree();
			
			if(sAdditionalHeaderText.Length > 0)
				labInfo.Text += sAdditionalHeaderText;

			if(saLocalize.Length > 0 || bLokalisiert)
				_bLocalize = true;

			if(!_bLocalize)
			{
				cbArea.Enabled = false;
				cbSide.Enabled = false;
			}

			StringBuilder sb = new StringBuilder();
			foreach(string s in saLocalize) 
			{
				sb.Append(s);
				sb.Append("\r\n");
			}
			tbM.Text = sb.ToString();

			cbArea.Text = "";				// Default wird null geliefert .....
			cbSide.Text = "";

			if(bLokalisiert) 
			{
				cbArea.Text = sLokalisierung;
				cbSide.Text = sLokalisierungSeite;
			}

			cbSerie.RefreshList();

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
		///	Löscht den Inhalt der ZP0 - ZP6
		/// </summary>
		//----------------------------------------------------------------------------
		private void ClearMassnahmenSerienValues()
		{
			foreach(UltraDateTimeEditor e in _adt)
				e.Value = null;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	Tree darstellen
		/// </summary>
		//----------------------------------------------------------------------------
		private void FillTree()
		{
			if(cbASZM.Checked)
				pdxTreeView1.FillTree(_sa, PDXTreeView.Groupby.ASZM);
			else
				pdxTreeView1.FillTree(_sa, PDXTreeView.Groupby.PDx);
		}
		
		//----------------------------------------------------------------------------
		/// <summary>
		///Liefert den ausgweählten Körperteil
		/// </summary>
		//----------------------------------------------------------------------------
		public string KOERPERTEIL
		{
			get 
			{
				return cbArea.Text;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// True wenn die Untertägigkeitszeitpunkte abgefragt werden sollen
		/// </summary>
		//----------------------------------------------------------------------------
		public bool UntertaegigJN
		{
			get
			{
				return _UntertaegigJN;
			}
			set 
			{
				_UntertaegigJN = value;
				pnlStartZeitpunkte.Visible = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zeitpunkte als DateTimeArray
		/// </summary>
		//----------------------------------------------------------------------------
		public DateTime[] ZEITPUNKTE 
		{
			get 
			{
				ArrayList al = new ArrayList();
				if(zp0.Value != null) al.Add(zp0.DateTime);
				if(zp1.Value != null) al.Add(zp1.DateTime);
				if(zp2.Value != null) al.Add(zp2.DateTime);
				if(zp3.Value != null) al.Add(zp3.DateTime);
				if(zp4.Value != null) al.Add(zp4.DateTime);
				if(zp5.Value != null) al.Add(zp5.DateTime);
				if(zp6.Value != null) al.Add(zp6.DateTime);
				return (DateTime[])al.ToArray(typeof(DateTime));
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die ausgewählte Seite
		/// </summary>
		//----------------------------------------------------------------------------
		public string SEITE
		{
			get 
			{
				return cbSide.Text;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert das ausgewählte Startdatum
		/// </summary>
		//----------------------------------------------------------------------------
		public DateTime STARTDATUM 
		{
			get 
			{
				return dtpStart.DateTime;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskLocalize));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.lblKörperteilPatient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblSeitePatient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbArea = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbSide = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblASZMLokalisierungNichtNotwendig = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbM = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStartdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpStart = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblASZMWerdenÜbertragen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.pdxTreeView1 = new PMDS.GUI.BaseControls.PDXTreeView();
            this.cbASZM = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblStartzeitpunkt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.zp0 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp1 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp2 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp3 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp6 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp5 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp4 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pnlStartZeitpunkte = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbSerie = new PMDS.GUI.BaseControls.MassnahmenSerienCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp4)).BeginInit();
            this.pnlStartZeitpunkte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(656, 48);
            this.labInfo.TabIndex = 3;
            this.labInfo.Text = "Lokalisierung und oder Startdatum angeben";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(600, 624);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance3;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(504, 624);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblKörperteilPatient
            // 
            this.lblKörperteilPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKörperteilPatient.Location = new System.Drawing.Point(16, 384);
            this.lblKörperteilPatient.Name = "lblKörperteilPatient";
            this.lblKörperteilPatient.Size = new System.Drawing.Size(216, 16);
            this.lblKörperteilPatient.TabIndex = 7;
            this.lblKörperteilPatient.Text = "Körperteil des Patienten";
            // 
            // lblSeitePatient
            // 
            this.lblSeitePatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSeitePatient.Location = new System.Drawing.Point(16, 424);
            this.lblSeitePatient.Name = "lblSeitePatient";
            this.lblSeitePatient.Size = new System.Drawing.Size(216, 16);
            this.lblSeitePatient.TabIndex = 9;
            this.lblSeitePatient.Text = "Seite (die des Patienten)";
            // 
            // cbArea
            // 
            this.cbArea.AddEmptyEntry = false;
            this.cbArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbArea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbArea.BerufsstandGruppeJNA = -1;
            this.cbArea.Group = "LOA";
            this.cbArea.ID_PEP = -1;
            this.cbArea.Location = new System.Drawing.Point(16, 400);
            this.cbArea.MaxLength = 50;
            this.cbArea.Name = "cbArea";
            this.cbArea.ShowAddButton = true;
            this.cbArea.Size = new System.Drawing.Size(176, 21);
            this.cbArea.TabIndex = 2;
            // 
            // cbSide
            // 
            this.cbSide.AddEmptyEntry = false;
            this.cbSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSide.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbSide.BerufsstandGruppeJNA = -1;
            this.cbSide.Group = "LOS";
            this.cbSide.ID_PEP = -1;
            this.cbSide.Location = new System.Drawing.Point(16, 440);
            this.cbSide.MaxLength = 50;
            this.cbSide.Name = "cbSide";
            this.cbSide.ShowAddButton = true;
            this.cbSide.Size = new System.Drawing.Size(176, 21);
            this.cbSide.TabIndex = 3;
            // 
            // lblASZMLokalisierungNichtNotwendig
            // 
            this.lblASZMLokalisierungNichtNotwendig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblASZMLokalisierungNichtNotwendig.Location = new System.Drawing.Point(16, 480);
            this.lblASZMLokalisierungNichtNotwendig.Name = "lblASZMLokalisierungNichtNotwendig";
            this.lblASZMLokalisierungNichtNotwendig.Size = new System.Drawing.Size(440, 16);
            this.lblASZMLokalisierungNichtNotwendig.TabIndex = 10;
            this.lblASZMLokalisierungNichtNotwendig.Text = "Für folgende ASZM ist es notwendig zusätzlich eine Lokalisierung anzugeben";
            // 
            // tbM
            // 
            this.tbM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbM.Location = new System.Drawing.Point(16, 496);
            this.tbM.Multiline = true;
            this.tbM.Name = "tbM";
            this.tbM.ReadOnly = true;
            this.tbM.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbM.Size = new System.Drawing.Size(632, 120);
            this.tbM.TabIndex = 4;
            this.tbM.WordWrap = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.Location = new System.Drawing.Point(16, 56);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(64, 16);
            this.lblStartdatum.TabIndex = 12;
            this.lblStartdatum.Text = "Startdatum";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(16, 72);
            this.dtpStart.MaskInput = "dd.mm.yyyy  hh:mm";
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(128, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // lblASZMWerdenÜbertragen
            // 
            this.lblASZMWerdenÜbertragen.Location = new System.Drawing.Point(16, 104);
            this.lblASZMWerdenÜbertragen.Name = "lblASZMWerdenÜbertragen";
            this.lblASZMWerdenÜbertragen.Size = new System.Drawing.Size(400, 16);
            this.lblASZMWerdenÜbertragen.TabIndex = 15;
            this.lblASZMWerdenÜbertragen.Text = "Folgende ASZM werden mit dem angegebenen Startdatum übertragen";
            // 
            // pdxTreeView1
            // 
            this.pdxTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdxTreeView1.Location = new System.Drawing.Point(16, 120);
            this.pdxTreeView1.Name = "pdxTreeView1";
            this.pdxTreeView1.Size = new System.Drawing.Size(632, 256);
            this.pdxTreeView1.TabIndex = 1;
            // 
            // cbASZM
            // 
            this.cbASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbASZM.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbASZM.Location = new System.Drawing.Point(472, 96);
            this.cbASZM.Name = "cbASZM";
            this.cbASZM.Size = new System.Drawing.Size(176, 20);
            this.cbASZM.TabIndex = 1;
            this.cbASZM.Text = "Ansicht nach ASZM gruppiert";
            this.cbASZM.CheckedChanged += new System.EventHandler(this.cbASZM_CheckedChanged);
            // 
            // lblStartzeitpunkt
            // 
            this.lblStartzeitpunkt.Location = new System.Drawing.Point(0, 0);
            this.lblStartzeitpunkt.Name = "lblStartzeitpunkt";
            this.lblStartzeitpunkt.Size = new System.Drawing.Size(416, 16);
            this.lblStartzeitpunkt.TabIndex = 1;
            this.lblStartzeitpunkt.Text = "Startzeitpunkte für benutzerdefinierte untertägige Maßnahmenserien (hh:mm)";
            // 
            // zp0
            // 
            this.zp0.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp0.Location = new System.Drawing.Point(0, 16);
            this.zp0.MaskInput = "hh:mm";
            this.zp0.Name = "zp0";
            this.zp0.Size = new System.Drawing.Size(40, 21);
            this.zp0.TabIndex = 0;
            this.zp0.Value = null;
            // 
            // zp1
            // 
            this.zp1.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp1.Location = new System.Drawing.Point(48, 16);
            this.zp1.MaskInput = "hh:mm";
            this.zp1.Name = "zp1";
            this.zp1.Size = new System.Drawing.Size(40, 21);
            this.zp1.TabIndex = 2;
            this.zp1.Value = null;
            // 
            // zp2
            // 
            this.zp2.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp2.Location = new System.Drawing.Point(96, 16);
            this.zp2.MaskInput = "hh:mm";
            this.zp2.Name = "zp2";
            this.zp2.Size = new System.Drawing.Size(40, 21);
            this.zp2.TabIndex = 3;
            this.zp2.Value = null;
            // 
            // zp3
            // 
            this.zp3.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp3.Location = new System.Drawing.Point(144, 16);
            this.zp3.MaskInput = "hh:mm";
            this.zp3.Name = "zp3";
            this.zp3.Size = new System.Drawing.Size(40, 21);
            this.zp3.TabIndex = 4;
            this.zp3.Value = null;
            // 
            // zp6
            // 
            this.zp6.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp6.Location = new System.Drawing.Point(288, 16);
            this.zp6.MaskInput = "hh:mm";
            this.zp6.Name = "zp6";
            this.zp6.Size = new System.Drawing.Size(40, 21);
            this.zp6.TabIndex = 7;
            this.zp6.Value = null;
            // 
            // zp5
            // 
            this.zp5.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp5.Location = new System.Drawing.Point(240, 16);
            this.zp5.MaskInput = "hh:mm";
            this.zp5.Name = "zp5";
            this.zp5.Size = new System.Drawing.Size(40, 21);
            this.zp5.TabIndex = 6;
            this.zp5.Value = null;
            // 
            // zp4
            // 
            this.zp4.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp4.Location = new System.Drawing.Point(192, 16);
            this.zp4.MaskInput = "hh:mm";
            this.zp4.Name = "zp4";
            this.zp4.Size = new System.Drawing.Size(40, 21);
            this.zp4.TabIndex = 5;
            this.zp4.Value = null;
            // 
            // pnlStartZeitpunkte
            // 
            this.pnlStartZeitpunkte.Controls.Add(this.cbSerie);
            this.pnlStartZeitpunkte.Controls.Add(this.zp3);
            this.pnlStartZeitpunkte.Controls.Add(this.zp1);
            this.pnlStartZeitpunkte.Controls.Add(this.zp4);
            this.pnlStartZeitpunkte.Controls.Add(this.zp6);
            this.pnlStartZeitpunkte.Controls.Add(this.zp5);
            this.pnlStartZeitpunkte.Controls.Add(this.zp2);
            this.pnlStartZeitpunkte.Controls.Add(this.lblStartzeitpunkt);
            this.pnlStartZeitpunkte.Controls.Add(this.zp0);
            this.pnlStartZeitpunkte.Location = new System.Drawing.Point(160, 56);
            this.pnlStartZeitpunkte.Name = "pnlStartZeitpunkte";
            this.pnlStartZeitpunkte.Size = new System.Drawing.Size(488, 40);
            this.pnlStartZeitpunkte.TabIndex = 24;
            this.pnlStartZeitpunkte.Visible = false;
            // 
            // cbSerie
            // 
            this.cbSerie.DISPLAY_TEXT = "";
            this.cbSerie.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbSerie.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbSerie.Location = new System.Drawing.Point(336, 16);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.Size = new System.Drawing.Size(144, 21);
            this.cbSerie.TabIndex = 8;
            this.cbSerie.ValueChanged += new System.EventHandler(this.cbSerie_ValueChanged);
            // 
            // frmAskLocalize
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(656, 662);
            this.Controls.Add(this.pnlStartZeitpunkte);
            this.Controls.Add(this.cbASZM);
            this.Controls.Add(this.pdxTreeView1);
            this.Controls.Add(this.lblASZMWerdenÜbertragen);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.tbM);
            this.Controls.Add(this.lblASZMLokalisierungNichtNotwendig);
            this.Controls.Add(this.cbSide);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.lblSeitePatient);
            this.Controls.Add(this.lblKörperteilPatient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 696);
            this.Name = "frmAskLocalize";
            this.ShowInTaskbar = false;
            this.Text = "Startdatum und Lokalisierung angeben";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAskLocalize_Closing);
            this.Load += new System.EventHandler(this.frmAskLocalize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp4)).EndInit();
            this.pnlStartZeitpunkte.ResumeLayout(false);
            this.pnlStartZeitpunkte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAskLocalize_Load(object sender, System.EventArgs e)
		{
			if(DesignMode)
				return;
			cbArea.Group = "LOA";
			cbSide.Group = "LOS";
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Closing
		/// </summary>
		//----------------------------------------------------------------------------
		private void frmAskLocalize_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(_bOKClicked)
				e.Cancel = !_bCanClose;
			_bOKClicked = false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Eingabefelder dürfen nicht leer sein
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			bool bError = false;

			if(UntertaegigJN)					// Bei Untertägig muss zumindest eines ausgefüllt sein
			{
				if(ZEITPUNKTE.Length == 0) 
				{
					errorProvider1.SetError(zp6, ENV.String("ERROR_MISSING_ZEITPUNKT"));
					bError = true;
				}
				else
					errorProvider1.SetError(zp6, "");
			}


			if(_bLocalize)
			{

				if(cbArea.Text.Trim().Length == 0) 
				{
					errorProvider1.SetError(cbArea, ENV.String("ERROR_MISSING_KOERPERTEIL"));
					bError = true;
				}
				else
					errorProvider1.SetError(cbArea, "");

				if(cbSide.Text.Trim().Length == 0) 
				{
					errorProvider1.SetError(cbSide, ENV.String("ERROR_MISSING_SEITE"));
					bError = true;
				}
				else
					errorProvider1.SetError(cbSide, "");

			}

			_bCanClose = !bError;
			if(bError)
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), true);
			_bOKClicked = true;

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abbruch
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_bCanClose = true;
		}

		private void cbASZM_CheckedChanged(object sender, System.EventArgs e)
		{
			FillTree();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Eine bestimmte Serie vorbelegen
		/// </summary>
		//----------------------------------------------------------------------------
		private void cbSerie_ValueChanged(object sender, System.EventArgs e)
		{
			ClearMassnahmenSerienValues();
			if(cbSerie.Value == null)
				return;

			Massnahmenserien s = new Massnahmenserien();
			s.Read();

			DateTime[] adt =  s.GetPoints(cbSerie.ID);

			int iCount = 0;
			foreach(DateTime t in adt)
			{
				if(iCount > 6)
					break;
				_adt[iCount].DateTime = t;
				iCount++;
			}
			

		}
	}
}

