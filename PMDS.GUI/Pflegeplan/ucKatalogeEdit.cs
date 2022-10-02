using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using PMDS.BusinessLogic;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Pflegeplan;
using S2Extensions;

namespace PMDS.GUI
{

	public class ucKatalogeEdit : QS2.Desktop.ControlManagment.BaseControl
	{	
		          
		public event EventHandler Close;
		private PDx				_PDx;											// Objekt welches Kataloge zur Verfügung stellt
		private string			_SelectedGroup ="";								// Die aktuell ausgewählte Gruppe A/S/Z/M
		private Katalog			_Katalog = new Katalog('X');
		private Guid			AktID;
		private bool			_preventDataChanged = false;
		private char			_SelectedMod = 'e';
		private string			ASZMSingleForm;
		private string			ASZMOhneArtikel;
		private bool			_preventSelectionChanged = false;
		private bool			SaveInProgress = false;
        private KatalogEditModes _EditMode = KatalogEditModes.All;


        private bool            _ZuordnenOK = false;

        private bool _ContentChanged = false;
        private dsAbteilung dsAbteilung1;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private QS2.Desktop.ControlManagment.BaseLabel ASZLabel;
		private PMDS.GUI.BaseControls.ASZMCombo cbASZM;
		private PMDS.GUI.ucButton btnUndo;
        private PMDS.GUI.ucButton btnSave;
		private QS2.Desktop.ControlManagment.BasePanel pnLASZM;
        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
		private QS2.Desktop.ControlManagment.BasePanel pnlKatalog2;
		private PMDS.GUI.ucKatalog2 ucKatalog21;
		private QS2.Desktop.ControlManagment.BasePanel panelSpeichernRückgängig;
		private QS2.Desktop.ControlManagment.BasePanel pnlEintragZusatz;
        private PMDS.GUI.ucEintragZusatz ucEintragZusatz2;
        private QS2.Desktop.ControlManagment.BaseButton btnZusatzwerte;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayPanelHeader;
        private QS2.Desktop.ControlManagment.BasePanel panelHeader;
        private QS2.Desktop.ControlManagment.BaseButton btnÄthologien;
        private QS2.Desktop.ControlManagment.BaseButton btnMaßnahmen;
        private QS2.Desktop.ControlManagment.BaseButton btnZiele;
        private QS2.Desktop.ControlManagment.BaseButton btnSympthome;
        private ucButton btnAdd;
        private ucButton btnDelete;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsUnten;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayPanelASZM;
        private QS2.Desktop.ControlManagment.BaseButton btnZusatzwerte3;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsÄndern;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayPanelAuswahl;
        private QS2.Desktop.ControlManagment.BasePanel panelAuswahlOben;
        private QS2.Desktop.ControlManagment.BaseButton btnRessourcen;
        private UltraOptionSet optEntferntJNSearch;
        private System.ComponentModel.IContainer components;




        


		public ucKatalogeEdit()
		{
			InitializeComponent();

            this.cbASZM.AlleEinträge = true;
            this.cbASZM.dropDownStyle = DropDownStyle.DropDown;

            if (DesignMode) 
				return;
            
            try 
			{
				_PDx		= new PDx();
                this.optEntferntJNSearch.CheckedIndex = 1;
                this.readRightsEdit();

                this.cbASZM.setUI(true);
			}
			catch(Exception ex) 
			{
                throw new Exception(ex.ToString());
            }
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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

        public KatalogEditModes EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; PrepareForMode(); }
        }

        public Guid CURRENT_SELECTED
        {
            get
            {
                if (!_ZuordnenOK)
                    return Guid.Empty;

                return cbASZM.ID;
            }
        }

        private void PrepareForMode()
        {
            this.panelButtonsUnten.Visible              = EditMode == KatalogEditModes.All;
            pnlButtons.Visible          = EditMode != KatalogEditModes.All;
            
            this.uGridBagLayPanelAuswahl.Visible = EditMode != KatalogEditModes.All; 

                        _SelectedGroup              = EditMode.ToString();
            ASZLabel.Text               = ENV.String(_SelectedGroup  + "_Select");
            RefreshASZMCombo();
            Katalog2Fill();
            pnlKatalog2.Visible = false;
            
            if (EditMode != KatalogEditModes.All)
            {
                btnSave.Visible = true;
                btnZusatzwerte.Visible = false;
                btnZusatzwerte3.Visible = false;
                btnUndo.Text = "Abbrechen";
                btnUndo.TYPE = ucButton.ButtonType.Cancel;
                //ProcessAdd();
                ucKatalog21.FocusOnASZMText();
                pnlEintragZusatz.Visible = _SelectedGroup == "M";
                pnlButtons.Visible = true;
                panelSpeichernRückgängig.Visible = true;
                panelButtonsUnten.Visible = true;
                panelButtonsÄndern.Visible = false;
                this.uGridBagLayPanelAuswahl.Visible = false;
            }
        }
        
        
        public bool CONTENT_CHANGED
		{
			get 
			{
				return _ContentChanged;
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKatalogeEdit));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.dsAbteilung1 = new PMDS.Global.db.Patient.dsAbteilung();
            this.pnLASZM = new QS2.Desktop.ControlManagment.BasePanel();
            this.uGridBagLayPanelAuswahl = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelAuswahlOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.optEntferntJNSearch = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ASZLabel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbASZM = new PMDS.GUI.BaseControls.ASZMCombo();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.pnlKatalog2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlEintragZusatz = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucEintragZusatz2 = new PMDS.GUI.ucEintragZusatz();
            this.ucKatalog21 = new PMDS.GUI.ucKatalog2();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnZusatzwerte = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelSpeichernRückgängig = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.uGridBagLayPanelHeader = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelHeader = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnRessourcen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMaßnahmen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnZiele = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSympthome = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnÄthologien = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.panelButtonsUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonsÄndern = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnZusatzwerte3 = new QS2.Desktop.ControlManagment.BaseButton();
            this.uGridBagLayPanelASZM = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).BeginInit();
            this.pnLASZM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelAuswahl)).BeginInit();
            this.uGridBagLayPanelAuswahl.SuspendLayout();
            this.panelAuswahlOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optEntferntJNSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.pnlKatalog2.SuspendLayout();
            this.pnlEintragZusatz.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.panelSpeichernRückgängig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelHeader)).BeginInit();
            this.uGridBagLayPanelHeader.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelButtonsUnten.SuspendLayout();
            this.panelButtonsÄndern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelASZM)).BeginInit();
            this.uGridBagLayPanelASZM.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsAbteilung1
            // 
            this.dsAbteilung1.DataSetName = "dsAbteilung";
            this.dsAbteilung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsAbteilung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnLASZM
            // 
            this.pnLASZM.BackColor = System.Drawing.Color.Transparent;
            this.pnLASZM.Controls.Add(this.uGridBagLayPanelAuswahl);
            this.pnLASZM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLASZM.Location = new System.Drawing.Point(0, 0);
            this.pnLASZM.Name = "pnLASZM";
            this.pnLASZM.Size = new System.Drawing.Size(947, 40);
            this.pnLASZM.TabIndex = 6;
            // 
            // uGridBagLayPanelAuswahl
            // 
            this.uGridBagLayPanelAuswahl.Controls.Add(this.panelAuswahlOben);
            this.uGridBagLayPanelAuswahl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridBagLayPanelAuswahl.ExpandToFitHeight = true;
            this.uGridBagLayPanelAuswahl.ExpandToFitWidth = true;
            this.uGridBagLayPanelAuswahl.Location = new System.Drawing.Point(0, 0);
            this.uGridBagLayPanelAuswahl.Name = "uGridBagLayPanelAuswahl";
            this.uGridBagLayPanelAuswahl.Size = new System.Drawing.Size(947, 40);
            this.uGridBagLayPanelAuswahl.TabIndex = 21;
            this.uGridBagLayPanelAuswahl.Visible = false;
            // 
            // panelAuswahlOben
            // 
            this.panelAuswahlOben.BackColor = System.Drawing.Color.White;
            this.panelAuswahlOben.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAuswahlOben.Controls.Add(this.optEntferntJNSearch);
            this.panelAuswahlOben.Controls.Add(this.ASZLabel);
            this.panelAuswahlOben.Controls.Add(this.cbASZM);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            this.uGridBagLayPanelAuswahl.SetGridBagConstraint(this.panelAuswahlOben, gridBagConstraint1);
            this.panelAuswahlOben.Location = new System.Drawing.Point(5, 0);
            this.panelAuswahlOben.Name = "panelAuswahlOben";
            this.uGridBagLayPanelAuswahl.SetPreferredSize(this.panelAuswahlOben, new System.Drawing.Size(880, 31));
            this.panelAuswahlOben.Size = new System.Drawing.Size(937, 35);
            this.panelAuswahlOben.TabIndex = 20;
            // 
            // optEntferntJNSearch
            // 
            this.optEntferntJNSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optEntferntJNSearch.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optEntferntJNSearch.CheckedIndex = 1;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "Entfernt";
            valueListItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "Nicht Entfernt";
            valueListItem3.DataValue = -1;
            valueListItem3.DisplayText = "Alle";
            this.optEntferntJNSearch.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optEntferntJNSearch.Location = new System.Drawing.Point(670, 10);
            this.optEntferntJNSearch.Name = "optEntferntJNSearch";
            this.optEntferntJNSearch.Size = new System.Drawing.Size(267, 18);
            this.optEntferntJNSearch.TabIndex = 20;
            this.optEntferntJNSearch.Text = "Nicht Entfernt";
            this.optEntferntJNSearch.ValueChanged += new System.EventHandler(this.optEntferntJNSearch_ValueChanged);
            // 
            // ASZLabel
            // 
            appearance1.TextHAlignAsString = "Left";
            this.ASZLabel.Appearance = appearance1;
            this.ASZLabel.AutoSize = true;
            this.ASZLabel.Location = new System.Drawing.Point(7, 7);
            this.ASZLabel.Name = "ASZLabel";
            this.ASZLabel.Padding = new System.Drawing.Size(0, 4);
            this.ASZLabel.Size = new System.Drawing.Size(158, 22);
            this.ASZLabel.TabIndex = 3;
            this.ASZLabel.Text = "Ätiologie/Risikofaktoren Wahl :";
            // 
            // cbASZM
            // 
            this.cbASZM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbASZM.DISPLAY_TEXT = "GUI.SEARCH_MASSNAHME";
            this.cbASZM.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbASZM.GROUP = PMDS.Global.EintragGruppe.A;
            this.cbASZM.Location = new System.Drawing.Point(184, 7);
            this.cbASZM.MaxDropDownItems = 30;
            this.cbASZM.Name = "cbASZM";
            this.cbASZM.Size = new System.Drawing.Size(466, 21);
            this.cbASZM.TabIndex = 19;
            this.cbASZM.SelectionChanged += new System.EventHandler(this.cbASZM_SelectionChanged);
            this.cbASZM.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbASZM_BeforeDropDown);
            this.cbASZM.ValueChanged += new System.EventHandler(this.cbASZM_ValueChanged);
            this.cbASZM.Click += new System.EventHandler(this.cbASZM_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.panel3.Controls.Add(this.pnLASZM);
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.Insets.Bottom = 5;
            gridBagConstraint3.Insets.Left = 5;
            gridBagConstraint3.Insets.Right = 5;
            gridBagConstraint3.Insets.Top = 5;
            gridBagConstraint3.OriginX = 0;
            gridBagConstraint3.OriginY = 0;
            this.uGridBagLayPanelASZM.SetGridBagConstraint(this.panel3, gridBagConstraint3);
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.uGridBagLayPanelASZM.SetPreferredSize(this.panel3, new System.Drawing.Size(760, 577));
            this.panel3.Size = new System.Drawing.Size(947, 570);
            this.panel3.TabIndex = 8;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.pnlKatalog2);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(947, 530);
            this.ultraGridBagLayoutPanel1.TabIndex = 23;
            // 
            // pnlKatalog2
            // 
            this.pnlKatalog2.BackColor = System.Drawing.Color.White;
            this.pnlKatalog2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKatalog2.Controls.Add(this.pnlEintragZusatz);
            this.pnlKatalog2.Controls.Add(this.ucKatalog21);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.pnlKatalog2, gridBagConstraint2);
            this.pnlKatalog2.Location = new System.Drawing.Point(5, 5);
            this.pnlKatalog2.Name = "pnlKatalog2";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.pnlKatalog2, new System.Drawing.Size(580, 451));
            this.pnlKatalog2.Size = new System.Drawing.Size(937, 520);
            this.pnlKatalog2.TabIndex = 22;
            this.pnlKatalog2.Visible = false;
            // 
            // pnlEintragZusatz
            // 
            this.pnlEintragZusatz.Controls.Add(this.ucEintragZusatz2);
            this.pnlEintragZusatz.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEintragZusatz.Location = new System.Drawing.Point(0, 301);
            this.pnlEintragZusatz.Name = "pnlEintragZusatz";
            this.pnlEintragZusatz.Size = new System.Drawing.Size(935, 159);
            this.pnlEintragZusatz.TabIndex = 1;
            // 
            // ucEintragZusatz2
            // 
            this.ucEintragZusatz2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucEintragZusatz2.AutoScroll = true;
            this.ucEintragZusatz2.Location = new System.Drawing.Point(16, 0);
            this.ucEintragZusatz2.Name = "ucEintragZusatz2";
            this.ucEintragZusatz2.Size = new System.Drawing.Size(892, 156);
            this.ucEintragZusatz2.TabIndex = 0;
            this.ucEintragZusatz2.ValueChanged += new System.EventHandler(this.ucEintragZusatz2_ValueChanged);
            // 
            // ucKatalog21
            // 
            this.ucKatalog21.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucKatalog21.KATALOG = null;
            this.ucKatalog21.Location = new System.Drawing.Point(0, 0);
            this.ucKatalog21.Name = "ucKatalog21";
            this.ucKatalog21.Size = new System.Drawing.Size(935, 301);
            this.ucKatalog21.TabIndex = 0;
            this.ucKatalog21.ValueChanged += new System.EventHandler(this.ucKatalog21_ValueChanged);
            this.ucKatalog21.Load += new System.EventHandler(this.ucKatalog21_Load);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnZusatzwerte);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(122, 43);
            this.pnlButtons.TabIndex = 20;
            this.pnlButtons.Visible = false;
            // 
            // btnZusatzwerte
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnZusatzwerte.Appearance = appearance2;
            this.btnZusatzwerte.AutoWorkLayout = false;
            this.btnZusatzwerte.IsStandardControl = false;
            this.btnZusatzwerte.Location = new System.Drawing.Point(20, 4);
            this.btnZusatzwerte.Name = "btnZusatzwerte";
            this.btnZusatzwerte.Size = new System.Drawing.Size(97, 32);
            this.btnZusatzwerte.TabIndex = 1;
            this.btnZusatzwerte.Text = "Zusatzwerte";
            this.btnZusatzwerte.Click += new System.EventHandler(this.btnZusatzwerte_Click);
            // 
            // panelSpeichernRückgängig
            // 
            this.panelSpeichernRückgängig.Controls.Add(this.btnUndo);
            this.panelSpeichernRückgängig.Controls.Add(this.btnSave);
            this.panelSpeichernRückgängig.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSpeichernRückgängig.Location = new System.Drawing.Point(660, 0);
            this.panelSpeichernRückgängig.Name = "panelSpeichernRückgängig";
            this.panelSpeichernRückgängig.Size = new System.Drawing.Size(297, 43);
            this.panelSpeichernRückgängig.TabIndex = 23;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance3;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(78, 4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(95, 32);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance4;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(174, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // uGridBagLayPanelHeader
            // 
            this.uGridBagLayPanelHeader.Controls.Add(this.panelHeader);
            this.uGridBagLayPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.uGridBagLayPanelHeader.ExpandToFitHeight = true;
            this.uGridBagLayPanelHeader.ExpandToFitWidth = true;
            this.uGridBagLayPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.uGridBagLayPanelHeader.Name = "uGridBagLayPanelHeader";
            this.uGridBagLayPanelHeader.Size = new System.Drawing.Size(957, 51);
            this.uGridBagLayPanelHeader.TabIndex = 9;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Controls.Add(this.btnRessourcen);
            this.panelHeader.Controls.Add(this.btnMaßnahmen);
            this.panelHeader.Controls.Add(this.btnZiele);
            this.panelHeader.Controls.Add(this.btnSympthome);
            this.panelHeader.Controls.Add(this.btnÄthologien);
            gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint4.Insets.Bottom = 5;
            gridBagConstraint4.Insets.Left = 5;
            gridBagConstraint4.Insets.Right = 5;
            gridBagConstraint4.Insets.Top = 5;
            gridBagConstraint4.OriginX = 0;
            gridBagConstraint4.OriginY = 0;
            this.uGridBagLayPanelHeader.SetGridBagConstraint(this.panelHeader, gridBagConstraint4);
            this.panelHeader.Location = new System.Drawing.Point(5, 5);
            this.panelHeader.Name = "panelHeader";
            this.uGridBagLayPanelHeader.SetPreferredSize(this.panelHeader, new System.Drawing.Size(200, 100));
            this.panelHeader.Size = new System.Drawing.Size(947, 41);
            this.panelHeader.TabIndex = 0;
            // 
            // btnRessourcen
            // 
            this.btnRessourcen.AcceptsFocus = false;
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.FontData.SizeInPoints = 8F;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            appearance5.TextVAlignAsString = "Middle";
            this.btnRessourcen.Appearance = appearance5;
            this.btnRessourcen.AutoWorkLayout = false;
            this.btnRessourcen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnRessourcen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRessourcen.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRessourcen.IsStandardControl = false;
            this.btnRessourcen.Location = new System.Drawing.Point(489, 6);
            this.btnRessourcen.Name = "btnRessourcen";
            this.btnRessourcen.ShowFocusRect = false;
            this.btnRessourcen.ShowOutline = false;
            this.btnRessourcen.Size = new System.Drawing.Size(111, 28);
            this.btnRessourcen.TabIndex = 27;
            this.btnRessourcen.Tag = "R";
            this.btnRessourcen.Text = "Ressourcen";
            this.btnRessourcen.UseAppStyling = false;
            this.btnRessourcen.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnRessourcen.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnRessourcen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnRessourcen.Click += new System.EventHandler(this.btnRessourcen_Click);
            // 
            // btnMaßnahmen
            // 
            this.btnMaßnahmen.AcceptsFocus = false;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.FontData.SizeInPoints = 8F;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            appearance6.TextVAlignAsString = "Middle";
            this.btnMaßnahmen.Appearance = appearance6;
            this.btnMaßnahmen.AutoWorkLayout = false;
            this.btnMaßnahmen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnMaßnahmen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaßnahmen.ImageSize = new System.Drawing.Size(40, 40);
            this.btnMaßnahmen.IsStandardControl = false;
            this.btnMaßnahmen.Location = new System.Drawing.Point(723, 6);
            this.btnMaßnahmen.Name = "btnMaßnahmen";
            this.btnMaßnahmen.ShowFocusRect = false;
            this.btnMaßnahmen.ShowOutline = false;
            this.btnMaßnahmen.Size = new System.Drawing.Size(111, 28);
            this.btnMaßnahmen.TabIndex = 26;
            this.btnMaßnahmen.Tag = "M";
            this.btnMaßnahmen.Text = "Maßnahmen";
            this.btnMaßnahmen.UseAppStyling = false;
            this.btnMaßnahmen.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnMaßnahmen.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnMaßnahmen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnMaßnahmen.Click += new System.EventHandler(this.btnMaßnahmen_Click);
            // 
            // btnZiele
            // 
            this.btnZiele.AcceptsFocus = false;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.FontData.SizeInPoints = 8F;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            appearance7.TextVAlignAsString = "Middle";
            this.btnZiele.Appearance = appearance7;
            this.btnZiele.AutoWorkLayout = false;
            this.btnZiele.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnZiele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZiele.ImageSize = new System.Drawing.Size(40, 40);
            this.btnZiele.IsStandardControl = false;
            this.btnZiele.Location = new System.Drawing.Point(606, 6);
            this.btnZiele.Name = "btnZiele";
            this.btnZiele.ShowFocusRect = false;
            this.btnZiele.ShowOutline = false;
            this.btnZiele.Size = new System.Drawing.Size(111, 28);
            this.btnZiele.TabIndex = 25;
            this.btnZiele.Tag = "Z";
            this.btnZiele.Text = "Ziele";
            this.btnZiele.UseAppStyling = false;
            this.btnZiele.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnZiele.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnZiele.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnZiele.Click += new System.EventHandler(this.btnZiele_Click);
            // 
            // btnSympthome
            // 
            this.btnSympthome.AcceptsFocus = false;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.FontData.SizeInPoints = 8F;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            appearance8.TextVAlignAsString = "Middle";
            this.btnSympthome.Appearance = appearance8;
            this.btnSympthome.AutoWorkLayout = false;
            this.btnSympthome.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnSympthome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSympthome.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSympthome.IsStandardControl = false;
            this.btnSympthome.Location = new System.Drawing.Point(372, 6);
            this.btnSympthome.Name = "btnSympthome";
            this.btnSympthome.ShowFocusRect = false;
            this.btnSympthome.ShowOutline = false;
            this.btnSympthome.Size = new System.Drawing.Size(111, 28);
            this.btnSympthome.TabIndex = 24;
            this.btnSympthome.Tag = "S";
            this.btnSympthome.Text = "Symptome";
            this.btnSympthome.UseAppStyling = false;
            this.btnSympthome.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSympthome.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSympthome.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSympthome.Click += new System.EventHandler(this.btnSympthome_Click);
            // 
            // btnÄthologien
            // 
            this.btnÄthologien.AcceptsFocus = false;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.FontData.SizeInPoints = 8F;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            appearance9.TextVAlignAsString = "Middle";
            this.btnÄthologien.Appearance = appearance9;
            this.btnÄthologien.AutoWorkLayout = false;
            this.btnÄthologien.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnÄthologien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnÄthologien.ImageSize = new System.Drawing.Size(40, 40);
            this.btnÄthologien.IsStandardControl = false;
            this.btnÄthologien.Location = new System.Drawing.Point(6, 6);
            this.btnÄthologien.Name = "btnÄthologien";
            this.btnÄthologien.ShowFocusRect = false;
            this.btnÄthologien.ShowOutline = false;
            this.btnÄthologien.Size = new System.Drawing.Size(360, 28);
            this.btnÄthologien.TabIndex = 23;
            this.btnÄthologien.Tag = "A";
            this.btnÄthologien.Text = "Ätiololgien / Risikofaktoren /  Beeinflussende Faktoren";
            this.btnÄthologien.UseAppStyling = false;
            this.btnÄthologien.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnÄthologien.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnÄthologien.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnÄthologien.Click += new System.EventHandler(this.btnÄthologien_Click);
            // 
            // btnAdd
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance10;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(17, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.TabStop = false;
            this.btnAdd.Tag = "+";
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnDelete
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.Image = ((object)(resources.GetObject("appearance11.Image")));
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance11;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(113, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 32);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "-";
            this.btnDelete.Text = "Entfernen";
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelButtonsUnten
            // 
            this.panelButtonsUnten.Controls.Add(this.panelButtonsÄndern);
            this.panelButtonsUnten.Controls.Add(this.pnlButtons);
            this.panelButtonsUnten.Controls.Add(this.panelSpeichernRückgängig);
            this.panelButtonsUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsUnten.Location = new System.Drawing.Point(0, 631);
            this.panelButtonsUnten.Name = "panelButtonsUnten";
            this.panelButtonsUnten.Size = new System.Drawing.Size(957, 43);
            this.panelButtonsUnten.TabIndex = 12;
            // 
            // panelButtonsÄndern
            // 
            this.panelButtonsÄndern.Controls.Add(this.btnAdd);
            this.panelButtonsÄndern.Controls.Add(this.btnZusatzwerte3);
            this.panelButtonsÄndern.Controls.Add(this.btnDelete);
            this.panelButtonsÄndern.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelButtonsÄndern.Location = new System.Drawing.Point(122, 0);
            this.panelButtonsÄndern.Name = "panelButtonsÄndern";
            this.panelButtonsÄndern.Size = new System.Drawing.Size(316, 43);
            this.panelButtonsÄndern.TabIndex = 28;
            // 
            // btnZusatzwerte3
            // 
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnZusatzwerte3.Appearance = appearance12;
            this.btnZusatzwerte3.AutoWorkLayout = false;
            this.btnZusatzwerte3.IsStandardControl = false;
            this.btnZusatzwerte3.Location = new System.Drawing.Point(209, 4);
            this.btnZusatzwerte3.Name = "btnZusatzwerte3";
            this.btnZusatzwerte3.Size = new System.Drawing.Size(97, 32);
            this.btnZusatzwerte3.TabIndex = 27;
            this.btnZusatzwerte3.Text = "Zusatzwerte";
            this.btnZusatzwerte3.Click += new System.EventHandler(this.btnZusatzwerte3_Click);
            // 
            // uGridBagLayPanelASZM
            // 
            this.uGridBagLayPanelASZM.Controls.Add(this.panel3);
            this.uGridBagLayPanelASZM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridBagLayPanelASZM.ExpandToFitHeight = true;
            this.uGridBagLayPanelASZM.ExpandToFitWidth = true;
            this.uGridBagLayPanelASZM.Location = new System.Drawing.Point(0, 51);
            this.uGridBagLayPanelASZM.Name = "uGridBagLayPanelASZM";
            this.uGridBagLayPanelASZM.Size = new System.Drawing.Size(957, 580);
            this.uGridBagLayPanelASZM.TabIndex = 15;
            // 
            // ucKatalogeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.uGridBagLayPanelASZM);
            this.Controls.Add(this.panelButtonsUnten);
            this.Controls.Add(this.uGridBagLayPanelHeader);
            this.Name = "ucKatalogeEdit";
            this.Size = new System.Drawing.Size(957, 674);
            this.Tag = "Dontpatch";
            this.Load += new System.EventHandler(this.ucKatalogeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).EndInit();
            this.pnLASZM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelAuswahl)).EndInit();
            this.uGridBagLayPanelAuswahl.ResumeLayout(false);
            this.panelAuswahlOben.ResumeLayout(false);
            this.panelAuswahlOben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optEntferntJNSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.pnlKatalog2.ResumeLayout(false);
            this.pnlEintragZusatz.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.panelSpeichernRückgängig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelHeader)).EndInit();
            this.uGridBagLayPanelHeader.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelButtonsUnten.ResumeLayout(false);
            this.panelButtonsÄndern.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelASZM)).EndInit();
            this.uGridBagLayPanelASZM.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		
		private bool ProcessSave() 
		{
			SaveInProgress = true;
            this.ucKatalog21.AlleEinträge = true;

            bool bError = false;
			if(_SelectedGroup == "M" && _SelectedMod != 't')
				ucEintragZusatz2.ValidateFields(ref bError);

			if(bError)
			{
				SaveInProgress = false;
				return false;
			}
			else if( _SelectedMod == 'e' ||_SelectedMod == '+')
			{
				bError = !ucKatalog21.Save();   // Wenn Felder nicht ausgefüllt sind kann hier ein Fehler auftreten
				
				if(!bError)                     //erscheinen nur wenn speichern funktioniert hat
				{
					pnLASZM.Visible = true;
                    this.uGridBagLayPanelAuswahl.Visible = true;
					ShowButtons(false);
					_SelectedMod = 'e';
					RefreshASZMCombo();

                    if (_SelectedMod == '+')
						foreach(ValueListItem i in cbASZM.Items)
							if(i.DataValue.Equals((Guid)AktID))
							{
								_preventSelectionChanged = true;
								cbASZM.SelectedItem =i;
								_preventSelectionChanged = false;
								break;
							}
				}
			}
		    
			if(bError)
			{
				SaveInProgress = false;
				return false;
			}

			if(_SelectedGroup == "M" && _SelectedMod != 't') 
			{
				ucEintragZusatz2.Save();
			}
			_ContentChanged = false;			
			ShowButtons(false);

			if(_SelectedMod != 't')				// in TabellenAnsicht taucht immer wieder die pnLASZM auf
				RefreshASZMCombo();

			SaveInProgress = false;
//            this.btnDelete.Enabled = true;
			return true;
		}

		public void Save()
		{
			btnSave.Focus();
			ProcessSave();
		}


		private void btnSave_Click(object sender, System.EventArgs e)
		{
            if (btnSave.TYPE == ucButton.ButtonType.OK)     // Hier wären wir ja im Zuorden Modus
            {
                _ZuordnenOK = true;
                Closeuc();
                return;
            }

            btnDelete.Enabled = true;

            if (!ProcessSave())
                return;

            if (EditMode != KatalogEditModes.All)       // Im Hinzufügemodus spezielle Verarbeitung
            {
                btnUndo.Visible = true;
                btnSave.Visible = true;
                btnZusatzwerte.Visible = EditMode == KatalogEditModes.M;
                btnZusatzwerte3.Visible = EditMode == KatalogEditModes.M;
                btnSave.Text = "Fertig";
                btnSave.TYPE = ucButton.ButtonType.OK;
                pnLASZM.Visible = false;
            }

            if (this.btnMaßnahmen.Appearance.BorderColor == System.Drawing.Color.DarkRed)
            {
                this.btnZusatzwerte3.Visible  = true;
            }
		}
		
		private void Closeuc()
		{
			if(Close != null)
				Close(null,null);
		}	

		private void ProcessUndo() 
		{
			if(_SelectedMod == 'e'||_SelectedMod == '+')
				ucKatalog21.Undo();

			if(_SelectedMod == '+')
			{
				pnlKatalog2.Visible = false;
				pnLASZM.Visible = true;
                this.uGridBagLayPanelAuswahl.Visible = true;
			}

			if(_SelectedMod == 'e')
				pnlKatalog2.Visible = true;

			if(_SelectedMod == 't')
	
		
			if(_SelectedGroup =="M" && _SelectedMod != 't')
				ucEintragZusatz2.Read();
			
			if(_SelectedGroup =="M" && _SelectedMod == '+')

                this.btnDelete.Enabled = false;

            ucEintragZusatz2.Undo();

			ShowButtons(false);
			_ContentChanged = false;	
		}
		
		/// <summary>
		/// Rückgängig
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUndo_Click(object sender, System.EventArgs e)
		{
            if (EditMode != KatalogEditModes.All)
            {
                Closeuc();
                return;
            }
			ProcessUndo();
            this.ShowButtons(false );
		}
		
		
		private void cbAbteilung_ValueChanged(object sender, System.EventArgs e)
		{	
			
		}

		private void SwitchTE()	
		{
			_SelectedMod = 'e';

		}


        private void ProcessZusatzwerte()
        {
            frmMassnahmenZusatz frm = new frmMassnahmenZusatz();
            if (_SelectedMod == 'e') frm.MID = (Guid)cbASZM.SelectedItem.DataValue;
            frm.ShowDialog();
        }

        public void ProcessAdd()
        {
            SwitchTE();
            pnlKatalog2.Visible = true;
            _SelectedMod = '+';
            ShowButtons(true);
            AktID = AddOneASZM();
            RefreshASZMCombo();
            ucKatalog21.FocusOnASZMText();
            this.btnZusatzwerte.Visible = false;
            btnZusatzwerte3.Visible = false;

        }

        public void FocusOnASZMText()
        {
            pnlKatalog2.Focus();
            ucKatalog21.Focus();
            ucKatalog21.FocusOnASZMText();
            this.Refresh();
        }

		private void Delete()
		{			
			if(_SelectedMod == 'e'||_SelectedMod =='+') //aktuell sichtbar Einzelansicht
			{
				if(QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEASZM",ASZMSingleForm, cbASZM.SelectedItem.DisplayText), ENV.String("DIALOGTITLE_DELETEASZM",ASZMOhneArtikel), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true) != DialogResult.Yes)
				{ 					
					return;
				}


                //os 14-05-09
                //Prüfen ob ASZM zu einem Pflegeplan zugegeordnet ist - über PflegeplanPDx
                //PMDS.DB.DBPflegePlanPDx dbPflegeplanPDx = new DB.DBPflegePlanPDx();
                //dbPflegeplanPDx.GetPflegeplanPDxZuordnungen((Guid)cbASZM.Value);

                //if (dbPflegeplanPDx.PFLEGEPLANPDX.Rows.Count > 0)
                //{
                //    StringBuilder sb = new StringBuilder();

                //    sb.Append("\"" + cbASZM.Text + "\" ist bei mindestens einem Klienten im Pflegeplan zugeordnet.");
                //    sb.Append("\n\nDer Eintrag kann nicht entfernt werden.");

                //    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), Settings.String("DIALOGTITLE_DELETEASZM", ASZMOhneArtikel), MessageBoxButtons.OK, MessageBoxIcon.Information) != DialogResult.Yes)
                //    {
                //        return;
                //    }
                //}

                //os 14-05-09 - Prüfen ob ASZM zu einem Pflegeplan zugegeordnet ist
                PMDS.DB.DBPflegePlan dbPflegeplan = new DB.DBPflegePlan();
                dbPflegeplan.GetPflegeplanByIDEintrag((Guid)cbASZM.Value);

                int AnzPflegepläne = dbPflegeplan.PFLEGEPLAN_EINTRAEGE.Rows.Count;
                if (AnzPflegepläne > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("'" + cbASZM.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("' ist "));
                    sb.Append(AnzPflegepläne == 1 ? QS2.Desktop.ControlManagment.ControlManagment.getRes("einem Pflegeplaneintrag") : AnzPflegepläne.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Pflegeplaneinträgen"));
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" zugeordnet. \n\rDer Eintrag kann nicht entfernt werden."));

                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), ENV.String("DIALOGTITLE_DELETEASZM", ASZMOhneArtikel), MessageBoxButtons.OK, MessageBoxIcon.Information, true) != DialogResult.Yes)
                        return;
                }


                dsPDx.PDXDataTable listPdx = ucKatalog21.KATALOG.GetPDxZuordnungen((Guid)cbASZM.Value);  
                if (listPdx.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("'" + cbASZM.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("' ist im Katalog zu folgenden Pflegedefinitionen zugeordnet:"));

                    foreach (dsPDx.PDXRow r in listPdx)
                        sb.Append("\n\t- " + r.Klartext);

                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\nDer Eintrag kann erst gelöscht werden, wenn Sie alle Zuordnungen entfernt haben."));

                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), ENV.String("DIALOGTITLE_DELETEASZM", ASZMOhneArtikel), MessageBoxButtons.OK, MessageBoxIcon.Information, true) != DialogResult.Yes)
                        return;
                }

				ucKatalog21.DeleteCurrent();				
				_preventSelectionChanged = true;
				cbASZM.SelectedItem = null;
				_preventSelectionChanged = false;
				pnlKatalog2.Visible = false;
                btnDelete.Enabled = false;
                this.btnZusatzwerte3.Visible = false;
			}

			ShowButtons(false);
			RefreshASZMCombo();
	}

	
		private void cbASZM_SelectionChanged(object sender, System.EventArgs e)
		{
			if(SaveInProgress == false)
			{

                if (_SelectedMod != 't' && _preventDataChanged != true)
                {
                    EditOneASZM();
                }
                else if (_SelectedMod != 't' && _preventSelectionChanged != true)
                {
                    EditOneASZM();
                    ucEintragZusatz2.Enabled = true;
                }
			}
						
		}

		private void cbEintrag_SelectionChanged(object sender, System.EventArgs e)
		{	
						
		}
        
		private void EditOneASZM()
		{	
			_preventDataChanged = true;
            this.ucKatalog21.AlleEinträge = true;
			Katalog2Fill();   //ucKatalog2 - KATALOG mit A,S,Z oder M füllen
            //if (this.CURRENT_ID != Guid.Empty)         //&& ucKatalogTabelle1.VISIBLEROWCOUNT != 0
            //{
            //    cbASZM.RefreshList();
            //    for (int i = 0; i < cbASZM.Items.Count; i++)
            //    {
            //        if (cbASZM.Items[i].DataValue.Equals(this.CURRENT_ID))
            //        {
            //            _preventSelectionChanged = true;
            //            cbASZM.SelectedItem = cbASZM.Items[i];
            //            _preventSelectionChanged = false;
            //            break;
            //        }
            //    }

            //}
            //else pnlKatalog2.Visible = false;
           
            pnlKatalog2.Visible = false;
            //cbASZM.RefreshList();
            //for (int i = 0; i < cbASZM.Items.Count; i++)
            //{
            //        _preventSelectionChanged = true;
            //        cbASZM.SelectedItem = cbASZM.Items[i];
            //        _preventSelectionChanged = false;
            //        break;
            //}

            //pnlKatalog2.Visible = false;
            Application.DoEvents();

			if(cbASZM.SelectedItem != null)
				{
                   
					AktID = (Guid)cbASZM.SelectedItem.DataValue;					
					ucKatalog21.EditOneASZM(AktID);
					if(_SelectedGroup =="M")
					{
						ucEintragZusatz2.IDEINTRAG = AktID;
						ucEintragZusatz2.Read();
                        this.btnZusatzwerte.Visible = true;
                        btnZusatzwerte3.Visible = true;
					}
                    else
                    {
                        this.btnZusatzwerte.Visible = false;
                        btnZusatzwerte3.Visible = false;
                    }

					pnlKatalog2.Visible = true;
					_SelectedMod = 'e';		
					_preventDataChanged = false;
                    this.btnDelete.Enabled = true;
                    //if (this.btnMaßnahmen.Appearance.ForeColor != System.Drawing.Color.Black)  //Wahnsinn, die Steuerung an der Farbe aufzuhängen!!!!
                    //{
                    //    this.btnZusatzwerte.Visible = true;
                    //    btnZusatzwerte3.Visible = true;
                    //}
                    //else
                    //{
                    //    this.btnZusatzwerte.Visible = false;
                    //    btnZusatzwerte3.Visible = false;
                    //}
				}
						
			pnLASZM.Visible = true;
			
		}

		private Guid AddOneASZM()
		{
			_preventDataChanged = true;

			Katalog2Fill();
			AktID = ucKatalog21.AddNew();
            this.uGridBagLayPanelAuswahl.Visible = false;	
			pnLASZM.Visible = true;
            this.btnDelete.Enabled = false;

			if(_SelectedGroup =="M")
			{
				ucEintragZusatz2.IDEINTRAG = AktID;
				ucEintragZusatz2.Read();
				ucEintragZusatz2.Enabled = false;				
				btnSave.Visible = false;
			}
			ucKatalog21.FocusOnASZMText();

			_preventDataChanged = false;
						
			return AktID;

		}

		private void Katalog2Fill()
		{
			if(_SelectedGroup =="M")
			{
				ucKatalog21.KATALOG = _PDx.KATALOGE['M'];
				ASZMSingleForm = ENV.String("DIE")+" "+ENV.String("MSingle");
				ASZMOhneArtikel = ENV.String("MSingle");
			}
			if(_SelectedGroup =="S")
			{
				ASZMSingleForm = ENV.String("DAS")+" "+ENV.String("SSingle");
				ucKatalog21.KATALOG = _PDx.KATALOGE['S'];
				ASZMOhneArtikel = ENV.String("SSingle");
			}
            if (_SelectedGroup == "R")
            {
                ASZMSingleForm = ENV.String("DIE") + " " + ENV.String("RSingle");
                ucKatalog21.KATALOG = _PDx.KATALOGE['R'];
                ASZMOhneArtikel = ENV.String("RSingle");
            }
            if (_SelectedGroup == "Z")
			{
				ASZMSingleForm = ENV.String("DAS")+" "+ENV.String("ZSingle");
				ucKatalog21.KATALOG = _PDx.KATALOGE['Z'];
				ASZMOhneArtikel = ENV.String("ZSingle");
			}
			if(_SelectedGroup =="A")
			{
				ASZMSingleForm = ENV.String("DIE")+" "+ENV.String("ASingle");
				ucKatalog21.KATALOG = _PDx.KATALOGE['A'];
				ASZMOhneArtikel = ENV.String("ASingle");
			}
            if(_EditMode == KatalogEditModes.All)
			    pnlKatalog2.Visible = true;
			pnlKatalog2.Dock = DockStyle.Fill;		
			
		}

		private void ucKatalog21_ValueChanged(object sender, System.EventArgs e)
		{
			DataChanged();
			_preventDataChanged = false;
			ucEintragZusatz2.Enabled = true;   //beim hinzufügen von Maßnahmen disabled
		}

		private void DataChanged()
		{	
			if(_preventDataChanged == false)
			{
				ShowButtons(true);
			}

            if (EditMode != KatalogEditModes.All)           // nach speichern hat SpeichernButton den Typ OK
            {
                if (btnSave.TYPE == ucButton.ButtonType.OK)
                {
                    btnSave.TYPE = ucButton.ButtonType.Save;
                    btnSave.Text = "Speichern";
                }
            }
		}

		private void ShowButtons(bool show)
		{
			btnSave.Visible = show;
			btnUndo.Visible = show;
			_ContentChanged = show;
		}
		
		private void RefreshASZMCombo()
		{
          

            if (_SelectedGroup =="M")cbASZM.GROUP = EintragGruppe.M;			
			if(_SelectedGroup =="S")cbASZM.GROUP = EintragGruppe.S;
            if (_SelectedGroup == "R") cbASZM.GROUP = EintragGruppe.R;
            if (_SelectedGroup == "Z") cbASZM.GROUP = EintragGruppe.Z;				
			if(_SelectedGroup =="A") cbASZM.GROUP = EintragGruppe.A;
                        
            cbASZM.RefreshList(); // brauche ich wenn neue ASZM gespeichert und Gruppe nicht verändert wird
				 
			if(AktID != Guid.Empty)  //wenn speichern funktioniert hat und nicht abgebrochen wurde
				foreach(ValueListItem i in cbASZM.Items)
					if((Guid)i.DataValue == AktID)
					{
						_preventSelectionChanged = true;		
						cbASZM.SelectedItem = i;
						_preventSelectionChanged = false;
						break;
					}
		}

		private void ucKatalogTabelle1_ucKatalogTabelleSaved(object sender, EventArgs e)
		{
			ProcessSave(); 
		}

		private void ucKatalogTabelle1_ucKatalogTabelleUndo(object sender, EventArgs e)
		{
			ProcessUndo();
		}

		private void ucKatalogTabelle1_ValueChanged(object sender, EventArgs e)
		{			
			ShowButtons(true);
		}

		private void cbASZM_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(btnSave.Visible) 
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
                                                                                    ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);   
                if (res == DialogResult.Yes)
				{
					ProcessSave();
					e.Cancel = true;
				}
				if(res == DialogResult.No)
					ProcessUndo();

				if(res== DialogResult.Cancel)
					e.Cancel = true;

			}
		}

		private void cbASZM_Click(object sender, System.EventArgs e)
		{
			if(btnSave.Visible) 
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);   
                if (res == DialogResult.Yes)
					ProcessSave();
					
				if(res == DialogResult.No)
					ProcessUndo();
				
			}
		}

        private void ucKatalogeEdit_Load(object sender, EventArgs e)
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_äthologien );
            this.openASZM("A");
            this.clickASZM("AE");

            this.btnZusatzwerte.Visible = false;
            btnZusatzwerte3.Visible = false;

            if (EditMode != KatalogEditModes.All)
            {
               ucKatalog21.FocusOnASZMText();

                if (this.EditMode  == KatalogEditModes.A)
                {
                    this.openÄthiologie();
                    this.headerOnOFF(false);
                }
                else if (EditMode == KatalogEditModes.S)
                {
                    this.openSympthome();
                    this.headerOnOFF(false);
                }
                else if (EditMode == KatalogEditModes.R)
                {
                    this.openRessourcen();
                    this.headerOnOFF(false);
                }
                else if (EditMode == KatalogEditModes.Z)
                {
                    this.openZiele();
                    this.headerOnOFF(false);
                }
                else if (EditMode == KatalogEditModes.M)
                {
                    this.openMaßnahmen();
                    this.headerOnOFF(false);
                }
                ProcessAdd();
            }
            else
            {
                this.openÄthiologie();
            }
        }

        private void ucEintragZusatz2_ValueChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        private void btnZuordnen_Click(object sender, EventArgs e)
        {
            
        }

        private void btnZusatzwerte_Click(object sender, EventArgs e)
        {
            ProcessZusatzwerte();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnVerlassen_Click(object sender, EventArgs e)
        {
        }

        private void ucKatalog21_Load(object sender, EventArgs e)
        {

        }







        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ProcessAdd();
        }
       private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        private void btnÄthologien_Click(object sender, EventArgs e)
        {
            this.checkForEdit();
            this.openÄthiologie();
        }

        public void  checkForEdit()
        {
            if (btnSave.Visible)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                            MessageBoxButtons.YesNo , MessageBoxIcon.Question, true);   
                if (res == DialogResult.Yes)
                {
                    ProcessSave();
                }
                if (res == DialogResult.No)
                    ProcessUndo();
            }
        
        }

        private void btnSympthome_Click(object sender, EventArgs e)
        {
            this.checkForEdit();
            this.openSympthome();
         }
        
        private void btnZiele_Click(object sender, EventArgs e)
        {
            this.checkForEdit();
            this.openZiele();
        }
        
        private void btnRessourcen_Click(object sender, EventArgs e)
        {
            this.checkForEdit();
            this.openRessourcen();
        }
        
        private void btnMaßnahmen_Click(object sender, EventArgs e)
        {
            this.checkForEdit();
            this.openMaßnahmen();
        }


        public void openÄthiologie()
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_äthologien);
            this.openASZM("A");
            this.clickASZM("AE");
            this.btnZusatzwerte3.Visible = false;
        }
        public void openSympthome()
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_sympthome);
            this.openASZM("S");
            this.clickASZM("SE");
            this.btnZusatzwerte3.Visible = false;
        }
        public void openRessourcen()
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_ressourcen);
            this.openASZM("R");
            this.clickASZM("RE");
            this.btnZusatzwerte3.Visible = false;
        }
        public void openZiele()
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_ziele);
            this.openASZM("Z");
            this.clickASZM("ZE");
            this.btnZusatzwerte3.Visible = false;
        }
        public void openMaßnahmen()
        {
            this.setButtonsAktivDeaktiv(SiteEvents.aszm_maßnahmen);
            this.openASZM("M");
            this.clickASZM("ME");
            this.btnZusatzwerte3.Visible = false;

        }
        public void headerOnOFF(bool bOn)
        {
            this.uGridBagLayPanelHeader.Visible = bOn;
        }

        public void setButtonsAktivDeaktiv(SiteEvents aktivButton)
        {
            PMDS.Global.UIGlobal.setUIButton(this.btnÄthologien, aktivButton == SiteEvents.aszm_äthologien);
            PMDS.Global.UIGlobal.setUIButton(this.btnSympthome, aktivButton == SiteEvents.aszm_sympthome);
            PMDS.Global.UIGlobal.setUIButton(this.btnZiele, aktivButton == SiteEvents.aszm_ziele);
            PMDS.Global.UIGlobal.setUIButton(this.btnMaßnahmen, aktivButton == SiteEvents.aszm_maßnahmen);
            PMDS.Global.UIGlobal.setUIButton(this.btnRessourcen, aktivButton == SiteEvents.aszm_ressourcen);
        }

        private void openASZM(string key )
        {
            pnlKatalog2.Visible = false;
            _SelectedMod = 'e';
            this.cbASZM.EntferntJN = (int)this.optEntferntJNSearch.Value;

            _SelectedGroup = key;
             ASZLabel.Text = ENV.String(_SelectedGroup + "_Select");
                cbASZM.DISPLAY_TEXT = ENV.String(_SelectedGroup + "Single")+" " + ENV.String("SEARCH");
                cbASZM.GROUP = (EintragGruppe)Enum.Parse(typeof(EintragGruppe), _SelectedGroup);

            pnlEintragZusatz.Visible = _SelectedGroup == "M";

            pnLASZM.Visible = true;
            this.uGridBagLayPanelAuswahl.Visible = true;	
            _preventSelectionChanged = true;
            cbASZM.SelectedItem = null;
            _preventSelectionChanged = false;
            this.btnDelete.Enabled = false;
            this.btnZusatzwerte.Visible = false;
            btnZusatzwerte3.Visible = false;
        }

        public void setHeaderButtonsOnOFFxy(string key )
        {
            //if (this.btnÄthologien.Tag.ToString () == key.ToString ())
            //{
            //    this.btnÄthologien.Visible = true;
            //}
            //if (this.btnSympthome .Tag.ToString() == key.ToString())
            //{
            //    this.btnSympthome.Visible = true;
            //}
            //if (this.btnZiele .Tag.ToString() == key.ToString())
            //{
            //    this.btnZiele.Visible = true;
            //}
            //if (this.btnMaßnahmen .Tag.ToString() == key.ToString())
            //{
            //    this.btnMaßnahmen.Visible = true;
            //}

        
        }

        public void setEditButtonsOnOff(bool onOff, string key)
        {
            this.panelButtonsÄndern.Visible = onOff;

            if (onOff)
            {
                if (this.btnAdd.Tag.ToString() == key.ToString())
                {
                    this.btnAdd.Visible = true;
                }
                if (this.btnDelete.Tag.ToString() == key.ToString())
                {
                    this.btnDelete.Visible = true;
                }
                if (this.btnZusatzwerte.Tag.ToString() == key.ToString())
                {
                    this.btnZusatzwerte.Visible = true;
                    btnZusatzwerte3.Visible = true;
                }
            }
            else
            {
                this.btnAdd.Visible = false ;
                this.btnDelete.Visible = false;
                this.btnZusatzwerte.Visible = false;
                btnZusatzwerte3.Visible = false;
            }
        }

        private void btnZusatzwerte3_Click(object sender, EventArgs e)
        {
            ProcessZusatzwerte();
        }

        public void readRightsEdit()
         {
             this.panelButtonsÄndern.Visible = ENV.HasRight(UserRights.Stammdatenverwaltung); 
         }




         private void clickASZM(string key)
         {
             //if (key == "AL" || key == "SL" || key == "ZL" || key == "ML")		//alle Tabellenansichten
             //{
             //    pnlKatalog2.Visible = false;
             //    ShowButtons(false);
             //}

             if (key == "AE" || key == "SE" || key == "RE" || key == "ZE" || key  == "ME") //Einzelansicht
             {
                 pnlKatalog2.Visible = false;
                 SwitchTE();

                 pnLASZM.Visible = true;
                 this.uGridBagLayPanelAuswahl.Visible = true;
                 this.btnDelete.Enabled = false;
                 this.btnZusatzwerte.Visible = false;
                 btnZusatzwerte3.Visible = false;
                 EditOneASZM();
             }

             //if (key == "AL")																	 // Ätiologien Tabelleansicht
             //{
             //    Katalog k = new Katalog('A');
             //    k.Read();
             //    _preventSelectionChanged = true;
             //    cbASZM.SelectedItem = null;
             //    _preventSelectionChanged = false;
             //    pnLASZM.Visible = false;

             //    ShowButtons(false);

             //}

             //if (key == "SL")																	 // Symptome Tabelleansicht
             //{
             //    Katalog k = new Katalog('S');
             //    k.Read();
             //    _preventSelectionChanged = true;
             //    cbASZM.SelectedItem = null;
             //    _preventSelectionChanged = false;
             //    pnLASZM.Visible = false;

             //}

             //if (key == "ZL")																	 // Ziele Tabelleansicht
             //{
             //    Katalog k = new Katalog('Z');
             //    k.Read();
             //    _preventSelectionChanged = true;
             //    cbASZM.SelectedItem = null;
             //    _preventSelectionChanged = false;
             //    pnLASZM.Visible = false;

             //}

             //if (key == "ML")																	// // Maßnahmen Tabelleansicht
             //{
             //    Katalog k = new Katalog('M');
             //    k.Read();
             //    _preventSelectionChanged = true;
             //    cbASZM.SelectedItem = null;
             //    _preventSelectionChanged = false;
             //    pnLASZM.Visible = false;

             //}
         }

         private void cbASZM_ValueChanged(object sender, EventArgs e)
         {

         }

        private void optEntferntJNSearch_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.optEntferntJNSearch.Focused)
                {
                    this.checkForEdit();
                    this.cbASZM.AlwaysRefresh = true;
                    this.cbASZM.EntferntJN = (int)this.optEntferntJNSearch.Value;

                    if (_SelectedGroup == "M")
                    {
                        this.openMaßnahmen();
                    }
                    else if (_SelectedGroup == "S")
                    {
                        this.openSympthome();
                    }
                    else if(_SelectedGroup == "R")
                    {
                        this.openRessourcen();
                    }
                    else if(_SelectedGroup == "Z")
                    {
                        this.openZiele();
                    }
                    else if(_SelectedGroup == "A")
                    {
                        this.openÄthiologie();
                    }

                    this.cbASZM.AlwaysRefresh = false;
                }
                this.cbASZM.Text = "";
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.cbASZM.AlwaysRefresh = false;
                this.Cursor = Cursors.Default;
            }
        }

    }

}

