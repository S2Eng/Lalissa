using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using UWG = Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Global;

using System.Collections.Generic;

using System.Linq;
using System.Text;

using PMDS.DB;
using PMDS.GUI.Engines;






namespace PMDS.GUI
{
 

	public class ucTermineEx : ucTermine, ISave 
	{
        public System.Guid _idAbteilungxy;
        public System.Guid _idBereich;
        public System.Guid _idPatient;

        public TerminExSettings actualSettings = new TerminExSettings();
        public TerminExSettings _savedSettingsxy = new TerminExSettings();

        public ucSiteMapTermine ucSiteMapTermine1 = null;
        public ucMedikamenteMain ucMedikamenteStammdaten1 = null;
        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();

        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();

        public PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        public static PMDS.GUI.GUI.Main.frmDekurseListe frmDekurseListeDistinct = null;
        public PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();

        public Nullable<Guid> IDKlinikLast = null;
        public Nullable<Guid> IDAbteilungLast = null;





        public PMDS.Global.eUITypeTermine UITypeTermine = eUITypeTermine.None;
        public QS2.Desktop.ControlManagment.BasePanel panelTop;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitraum;
        public ucTerminTimePicker ucTerminTimePicker1;
        private QS2.Desktop.ControlManagment.BaseLabel lblFilter;
        public ucTerminFilterPicker ucTerminFilterPicker1;
        public PMDS.GUI.BaseControls.QuickFilterButtons quickFilterButtons1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel gridPanelGrid;
        private QS2.Desktop.ControlManagment.BasePanel panelFilter;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager layFilterObenRechts;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelTop;
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BaseButton btnAlleAuswählen;
        public QS2.Desktop.ControlManagment.BasePanel panelEinAusGesamt;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        public QS2.Desktop.ControlManagment.BasePanel panelLeisteQuickButtons;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid2;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid;
        public QS2.Desktop.ControlManagment.BasePanel pButtonsAll;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsIntervention;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsAlleKeine;
        private QS2.Desktop.ControlManagment.BasePanel pnlPrintTermine;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private ucButton btnPrintTermine;
        private QS2.Desktop.ControlManagment.BaseOptionSet uOptSetDruckauswahl;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerPrint;
        public QS2.Desktop.ControlManagment.BaseButton btnNeuLaden;
        public QS2.Desktop.ControlManagment.BaseButton btnFreierBericht;
        public QS2.Desktop.ControlManagment.BaseButton btnBedarfsmedikation;
        public QS2.Desktop.ControlManagment.BaseButton btnUngeplMaßnahmenRückemelden;
        public QS2.Desktop.ControlManagment.BaseButton btnSchnellrückmeldung;
        private QS2.Desktop.ControlManagment.BasePanel panelSondertermin;
        public QS2.Desktop.ControlManagment.BaseButton btnSonderterminBearbeiten;
        public QS2.Desktop.ControlManagment.BaseButton btnSonderterminLöschen;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerSondertermine;
        public QS2.Desktop.ControlManagment.BaseButton btnSonderterminErstellen;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsÜbergabe;
        public QS2.Desktop.ControlManagment.BaseButton btnFreierBericht2;
        public QS2.Desktop.ControlManagment.BaseButton btnSonderterminBeenden;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsStuhlDrucken;
        public QS2.Desktop.ControlManagment.BasePanel pButtonsAllDyn;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDrucken;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDekursEntwürfe;
        private QS2.Desktop.ControlManagment.BasePanel panelIButtonLeiste;
        private QS2.Desktop.ControlManagment.BasePanel panelSpace;
        private QS2.Desktop.ControlManagment.BasePanel panelSondertermine;
        private QS2.Desktop.ControlManagment.BasePanel panelFilterOben2;
        private QS2.Desktop.ControlManagment.BasePanel panelZeitraum;
        private QS2.Desktop.ControlManagment.BasePanel panelTopRight;
        public QS2.Desktop.ControlManagment.BasePanel panelStuhlbuttonsFläche;
        private QS2.Desktop.ControlManagment.BasePanel panelStuhlbuttonsLeer;
        private QS2.Desktop.ControlManagment.BasePanel panelQuickButtons5;
        public QS2.Desktop.ControlManagment.BasePanel panelStuhlbuttons;
        private QS2.Desktop.ControlManagment.BasePanel panelLeer2;
        public QS2.Desktop.ControlManagment.BasePanel panelLoading;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel gridBagDatenWerdenAktualisiert;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private QS2.Desktop.ControlManagment.BaseLabel lblDatenWerdenAktualisiert2;
        private QS2.Desktop.ControlManagment.BasePanel panelDatenWerdenAktualisiert;
        private QS2.Desktop.ControlManagment.BaseLabel lblDatenWerdenAktualisiert;
        public ImageList imageList1;
        public ContextMenuStrip contextMenuStripSys;
        private ToolStripMenuItem openSqlCommandToolStripMenuItem;
        private ToolStripMenuItem standardlayoutAnwendenToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem updateNächstesDatumToolStripMenuItem;
        private ToolStripMenuItem nufFürDieAbteilungToolStripMenuItem;
        private ToolStripMenuItem nurFürDenKlientenToolStripMenuItem;
        private ToolStripMenuItem gesamteDatenbankToolStripMenuItem;
        public QS2.Desktop.ControlManagment.BaseButton btnLesenÜbergabeDekurs;
        private Panel panelTextControl;
        private TXTextControl.TextControl textControl1;
        public QS2.Desktop.ControlManagment.BaseButton btnLesenInterventionen;
        public QS2.Desktop.ControlManagment.BaseButton btnPDxRückmelden;
        public QS2.Desktop.ControlManagment.BaseButton btnGegenzeichnen;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtSearchInGrid;
        private QS2.Desktop.ControlManagment.BaseLabel lblSearch;
        public QS2.Desktop.ControlManagment.BaseButton btnOpenBefundÜbergabe;
        public QS2.Desktop.ControlManagment.BaseButton btnOpenBefundIntervention;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownSondertermine;
        private QS2.Desktop.ControlManagment.BasePanel PanelDekursEntwürfe;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellen;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwürfeListe;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerDekursEntwürfe;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDekursEntwürfe2;
        public Infragistics.Win.Misc.UltraDropDownButton ultraDropDownButtonTermine;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellenAs;
        private System.ComponentModel.IContainer components = null;








		public ucTermineEx()
		{
            if (!ENV.AppRunning)
                return;

            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }
      

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

		#region Component Designer generated code


		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTermineEx));
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Interventionsliste neu laden", Infragistics.Win.ToolTipImage.Default, "Neu laden", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.Default, "Alle", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.quickFilterButtons1 = new PMDS.GUI.BaseControls.QuickFilterButtons();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtSearchInGrid = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSearch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelFilterOben2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelZeitraum = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucTerminTimePicker1 = new PMDS.GUI.ucTerminTimePicker();
            this.lblZeitraum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelFilter = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblFilter = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucTerminFilterPicker1 = new PMDS.GUI.ucTerminFilterPicker();
            this.panelTopRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnNeuLaden = new QS2.Desktop.ControlManagment.BaseButton();
            this.pnlPrintTermine = new QS2.Desktop.ControlManagment.BasePanel();
            this.uOptSetDruckauswahl = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnPrintTermine = new PMDS.GUI.ucButton(this.components);
            this.panelSondertermin = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSonderterminBeenden = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSonderterminErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSonderterminLöschen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSonderterminBearbeiten = new QS2.Desktop.ControlManagment.BaseButton();
            this.contextMenuStripSys = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.standardlayoutAnwendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openSqlCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateNächstesDatumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesamteDatenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nufFürDieAbteilungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurFürDenKlientenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridPanelGrid = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.layFilterObenRechts = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.panelEinAusGesamt = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelTextControl = new System.Windows.Forms.Panel();
            this.textControl1 = new TXTextControl.TextControl();
            this.ultraPopupControlContainerPrint = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.ultraGridBagLayoutPanelTop = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.btnAlleAuswählen = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelGrid2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelGrid = new QS2.Desktop.ControlManagment.BasePanel();
            this.PanelDekursEntwürfe = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDekursEntwurfErstellenAs = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDekursEntwurfErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDekursEntwürfeListe = new QS2.Desktop.ControlManagment.BaseButton();
            this.pButtonsAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelStuhlbuttonsFläche = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelStuhlbuttons = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelLeer2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelStuhlbuttonsLeer = new QS2.Desktop.ControlManagment.BasePanel();
            this.pButtonsAllDyn = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelQuickButtons5 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonsÜbergabe = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraDropDownButtonTermine = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainerSondertermine = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.uDropDownDekursEntwürfe2 = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainerDekursEntwürfe = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnOpenBefundÜbergabe = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnGegenzeichnen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnLesenÜbergabeDekurs = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnFreierBericht2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtonsIntervention = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnOpenBefundIntervention = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPDxRückmelden = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnLesenInterventionen = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelIButtonLeiste = new QS2.Desktop.ControlManagment.BasePanel();
            this.uDropDownSondertermine = new Infragistics.Win.Misc.UltraDropDownButton();
            this.panelSondertermine = new QS2.Desktop.ControlManagment.BasePanel();
            this.uDropDownDekursEntwürfe = new Infragistics.Win.Misc.UltraDropDownButton();
            this.btnFreierBericht = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUngeplMaßnahmenRückemelden = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnBedarfsmedikation = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelSpace = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSchnellrückmeldung = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtonsStuhlDrucken = new QS2.Desktop.ControlManagment.BasePanel();
            this.uDropDownDrucken = new Infragistics.Win.Misc.UltraDropDownButton();
            this.panelButtonsAlleKeine = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelLeisteQuickButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.lblDatenWerdenAktualisiert2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelLoading = new QS2.Desktop.ControlManagment.BasePanel();
            this.gridBagDatenWerdenAktualisiert = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelDatenWerdenAktualisiert = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblDatenWerdenAktualisiert = new QS2.Desktop.ControlManagment.BaseLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgTermine)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchInGrid)).BeginInit();
            this.panelFilterOben2.SuspendLayout();
            this.panelZeitraum.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.pnlPrintTermine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uOptSetDruckauswahl)).BeginInit();
            this.panelSondertermin.SuspendLayout();
            this.contextMenuStripSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPanelGrid)).BeginInit();
            this.gridPanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layFilterObenRechts)).BeginInit();
            this.panelEinAusGesamt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelTop)).BeginInit();
            this.ultraGridBagLayoutPanelTop.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelGrid2.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.PanelDekursEntwürfe.SuspendLayout();
            this.pButtonsAll.SuspendLayout();
            this.panelStuhlbuttonsFläche.SuspendLayout();
            this.pButtonsAllDyn.SuspendLayout();
            this.panelQuickButtons5.SuspendLayout();
            this.panelButtonsÜbergabe.SuspendLayout();
            this.panelButtonsIntervention.SuspendLayout();
            this.panelIButtonLeiste.SuspendLayout();
            this.panelSondertermine.SuspendLayout();
            this.panelButtonsStuhlDrucken.SuspendLayout();
            this.panelButtonsAlleKeine.SuspendLayout();
            this.panelLeisteQuickButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBagDatenWerdenAktualisiert)).BeginInit();
            this.gridBagDatenWerdenAktualisiert.SuspendLayout();
            this.panelDatenWerdenAktualisiert.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTermine
            // 
            this.dgTermine.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance1.BackColor = System.Drawing.Color.White;
            this.dgTermine.DisplayLayout.Appearance = appearance1;
            this.dgTermine.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgTermine.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.White;
            this.dgTermine.DisplayLayout.GroupByBox.Appearance = appearance2;
            this.dgTermine.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgTermine.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            appearance3.BackColor = System.Drawing.Color.White;
            this.dgTermine.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.dgTermine.DisplayLayout.MaxColScrollRegions = 1;
            this.dgTermine.DisplayLayout.MaxRowScrollRegions = 1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgTermine.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.LightGray;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.dgTermine.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.dgTermine.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.dgTermine.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgTermine.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgTermine.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgTermine.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            this.dgTermine.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgTermine.DisplayLayout.Override.CellAppearance = appearance7;
            this.dgTermine.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgTermine.DisplayLayout.Override.CellPadding = 0;
            this.dgTermine.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn;
            appearance8.BackColor = System.Drawing.SystemColors.Control;
            appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance8.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.BorderColor = System.Drawing.SystemColors.Window;
            this.dgTermine.DisplayLayout.Override.GroupByRowAppearance = appearance8;
            appearance9.TextHAlignAsString = "Left";
            this.dgTermine.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.dgTermine.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgTermine.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.dgTermine.DisplayLayout.Override.NullText = "";
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.White;
            this.dgTermine.DisplayLayout.Override.RowAlternateAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgTermine.DisplayLayout.Override.RowAppearance = appearance11;
            this.dgTermine.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgTermine.DisplayLayout.Override.RowSpacingAfter = 3;
            this.dgTermine.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance12.BackColor = System.Drawing.Color.LightGray;
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.dgTermine.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.dgTermine.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgTermine.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgTermine.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.dgTermine.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgTermine.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgTermine.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 3;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.gridPanelGrid.SetGridBagConstraint(this.dgTermine, gridBagConstraint1);
            this.dgTermine.Location = new System.Drawing.Point(5, 0);
            this.gridPanelGrid.SetPreferredSize(this.dgTermine, new System.Drawing.Size(315, 203));
            this.dgTermine.Size = new System.Drawing.Size(1118, 455);
            this.dgTermine.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.dgTermine.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgTermine_BeforeCellActivate);
            // 
            // quickFilterButtons1
            // 
            this.quickFilterButtons1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            this.ultraGridBagLayoutPanelTop.SetGridBagConstraint(this.quickFilterButtons1, gridBagConstraint2);
            this.quickFilterButtons1.Location = new System.Drawing.Point(0, 0);
            this.quickFilterButtons1.Name = "quickFilterButtons1";
            this.ultraGridBagLayoutPanelTop.SetPreferredSize(this.quickFilterButtons1, new System.Drawing.Size(114, 31));
            this.quickFilterButtons1.Size = new System.Drawing.Size(1123, 26);
            this.quickFilterButtons1.TabIndex = 41;
            this.quickFilterButtons1.QuickFilterButtonClick += new PMDS.GUI.BaseControls.QuickFilterButtonPressDelegate(this.quickFilterButtons1_QuickFilterButtonClick);
            this.quickFilterButtons1.VisibleChanged += new System.EventHandler(this.quickFilterButtons1_VisibleChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTop.Controls.Add(this.txtSearchInGrid);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.panelFilterOben2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1128, 39);
            this.panelTop.TabIndex = 38;
            // 
            // txtSearchInGrid
            // 
            this.txtSearchInGrid.Location = new System.Drawing.Point(120, 8);
            this.txtSearchInGrid.MaxLength = 50;
            this.txtSearchInGrid.Name = "txtSearchInGrid";
            this.txtSearchInGrid.Size = new System.Drawing.Size(176, 21);
            this.txtSearchInGrid.TabIndex = 0;
            this.txtSearchInGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchInGrid_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(3, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(120, 14);
            this.lblSearch.TabIndex = 92;
            this.lblSearch.Text = "Suche in der Liste [F3]";
            // 
            // panelFilterOben2
            // 
            this.panelFilterOben2.Controls.Add(this.panelZeitraum);
            this.panelFilterOben2.Controls.Add(this.panelFilter);
            this.panelFilterOben2.Controls.Add(this.panelTopRight);
            this.panelFilterOben2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFilterOben2.Location = new System.Drawing.Point(502, 0);
            this.panelFilterOben2.Name = "panelFilterOben2";
            this.panelFilterOben2.Size = new System.Drawing.Size(626, 39);
            this.panelFilterOben2.TabIndex = 52;
            // 
            // panelZeitraum
            // 
            this.panelZeitraum.Controls.Add(this.ucTerminTimePicker1);
            this.panelZeitraum.Controls.Add(this.lblZeitraum);
            this.panelZeitraum.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelZeitraum.Location = new System.Drawing.Point(6, 0);
            this.panelZeitraum.Name = "panelZeitraum";
            this.panelZeitraum.Size = new System.Drawing.Size(257, 39);
            this.panelZeitraum.TabIndex = 54;
            // 
            // ucTerminTimePicker1
            // 
            this.ucTerminTimePicker1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucTerminTimePicker1.Location = new System.Drawing.Point(64, 6);
            this.ucTerminTimePicker1.Mode = PMDS.GUI.EFilter.HEUTE;
            this.ucTerminTimePicker1.Name = "ucTerminTimePicker1";
            this.ucTerminTimePicker1.RangeFrom = new System.DateTime(2018, 1, 26, 0, 0, 0, 0);
            this.ucTerminTimePicker1.RangeTo = new System.DateTime(2018, 1, 26, 23, 59, 59, 0);
            this.ucTerminTimePicker1.Size = new System.Drawing.Size(189, 24);
            this.ucTerminTimePicker1.TabIndex = 39;
            // 
            // lblZeitraum
            // 
            appearance14.Image = "ICO_sachbearbeiterverwaltung.ico";
            appearance14.TextHAlignAsString = "Right";
            this.lblZeitraum.Appearance = appearance14;
            this.lblZeitraum.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeitraum.ImageSize = new System.Drawing.Size(12, 12);
            this.lblZeitraum.Location = new System.Drawing.Point(-2, 10);
            this.lblZeitraum.Name = "lblZeitraum";
            this.lblZeitraum.Size = new System.Drawing.Size(61, 16);
            this.lblZeitraum.TabIndex = 40;
            this.lblZeitraum.Text = "Zeitraum";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.Transparent;
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Controls.Add(this.ucTerminFilterPicker1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFilter.Location = new System.Drawing.Point(263, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(322, 39);
            this.panelFilter.TabIndex = 46;
            // 
            // lblFilter
            // 
            appearance15.TextHAlignAsString = "Right";
            this.lblFilter.Appearance = appearance15;
            this.lblFilter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ImageSize = new System.Drawing.Size(12, 12);
            this.lblFilter.Location = new System.Drawing.Point(-9, 10);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(48, 16);
            this.lblFilter.TabIndex = 42;
            this.lblFilter.Text = "Filter";
            // 
            // ucTerminFilterPicker1
            // 
            this.ucTerminFilterPicker1.Abzeichnen = -1;
            this.ucTerminFilterPicker1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucTerminFilterPicker1.Berufsstand = ((System.Collections.Generic.List<System.Guid>)(resources.GetObject("ucTerminFilterPicker1.Berufsstand")));
            this.ucTerminFilterPicker1.HerkunftPlanungsEintrag = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.HerkunftPlanungsEintrag")));
            this.ucTerminFilterPicker1.IDBezug = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucTerminFilterPicker1.IDMassnahme = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucTerminFilterPicker1.Location = new System.Drawing.Point(40, 6);
            this.ucTerminFilterPicker1.MASSNAHMEN = new System.Guid[0];
            this.ucTerminFilterPicker1.Name = "ucTerminFilterPicker1";
            this.ucTerminFilterPicker1.PlanungsEinträge = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.PlanungsEinträge")));
            this.ucTerminFilterPicker1.ShowBerufsstand = false;
            this.ucTerminFilterPicker1.ShowBezug = false;
            this.ucTerminFilterPicker1.ShowCC = -1;
            this.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag = false;
            this.ucTerminFilterPicker1.ShowPlanungsEinträgeJN = false;
            this.ucTerminFilterPicker1.ShowZeitbezugJN = false;
            this.ucTerminFilterPicker1.ShowZusatzwerte = false;
            this.ucTerminFilterPicker1.Size = new System.Drawing.Size(277, 25);
            this.ucTerminFilterPicker1.TabIndex = 41;
            this.ucTerminFilterPicker1.WichtigFür = ((System.Collections.Generic.List<System.Guid>)(resources.GetObject("ucTerminFilterPicker1.WichtigFür")));
            this.ucTerminFilterPicker1.WichtigFürJN = false;
            this.ucTerminFilterPicker1.ZeitbezugJNA = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.ZeitbezugJNA")));
            this.ucTerminFilterPicker1.Zusatzwerte = ((System.Collections.Generic.List<string>)(resources.GetObject("ucTerminFilterPicker1.Zusatzwerte")));
            // 
            // panelTopRight
            // 
            this.panelTopRight.Controls.Add(this.btnNeuLaden);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(585, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(41, 39);
            this.panelTopRight.TabIndex = 53;
            // 
            // btnNeuLaden
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnNeuLaden.Appearance = appearance16;
            this.btnNeuLaden.AutoWorkLayout = false;
            this.btnNeuLaden.IsStandardControl = false;
            this.btnNeuLaden.Location = new System.Drawing.Point(7, 6);
            this.btnNeuLaden.Name = "btnNeuLaden";
            this.btnNeuLaden.Size = new System.Drawing.Size(24, 24);
            this.btnNeuLaden.TabIndex = 49;
            ultraToolTipInfo2.ToolTipText = "Interventionsliste neu laden";
            ultraToolTipInfo2.ToolTipTitle = "Neu laden";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnNeuLaden, ultraToolTipInfo2);
            this.btnNeuLaden.Click += new System.EventHandler(this.btnNeuLaden_Click);
            // 
            // pnlPrintTermine
            // 
            this.pnlPrintTermine.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPrintTermine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintTermine.Controls.Add(this.uOptSetDruckauswahl);
            this.pnlPrintTermine.Controls.Add(this.ultraLabel2);
            this.pnlPrintTermine.Controls.Add(this.btnPrintTermine);
            this.pnlPrintTermine.Location = new System.Drawing.Point(19, 214);
            this.pnlPrintTermine.Name = "pnlPrintTermine";
            this.pnlPrintTermine.Size = new System.Drawing.Size(170, 123);
            this.pnlPrintTermine.TabIndex = 89;
            this.pnlPrintTermine.Visible = false;
            // 
            // uOptSetDruckauswahl
            // 
            this.uOptSetDruckauswahl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uOptSetDruckauswahl.CheckedIndex = 0;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "I";
            valueListItem1.DisplayText = "Interventionsliste";
            valueListItem2.DataValue = "INoVz";
            valueListItem2.DisplayText = "Interventionsliste (kurz)";
            valueListItem4.DataValue = "PS";
            valueListItem4.DisplayText = "Pflegestandard";
            valueListItem3.DataValue = "VO";
            valueListItem3.DisplayText = "Verordnungen";
            this.uOptSetDruckauswahl.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem4,
            valueListItem3});
            this.uOptSetDruckauswahl.Location = new System.Drawing.Point(6, 27);
            this.uOptSetDruckauswahl.Name = "uOptSetDruckauswahl";
            this.uOptSetDruckauswahl.Size = new System.Drawing.Size(159, 61);
            this.uOptSetDruckauswahl.TabIndex = 87;
            this.uOptSetDruckauswahl.Text = "Interventionsliste";
            this.uOptSetDruckauswahl.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraLabel2
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance22;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(7, 6);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(76, 14);
            this.ultraLabel2.TabIndex = 86;
            this.ultraLabel2.Text = "Ausdruck von:";
            // 
            // btnPrintTermine
            // 
            appearance23.BackColor = System.Drawing.Color.Transparent;
            appearance23.Image = ((object)(resources.GetObject("appearance23.Image")));
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextVAlignAsString = "Middle";
            this.btnPrintTermine.Appearance = appearance23;
            this.btnPrintTermine.AutoWorkLayout = false;
            this.btnPrintTermine.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrintTermine.DoOnClick = true;
            this.btnPrintTermine.IsStandardControl = true;
            this.btnPrintTermine.Location = new System.Drawing.Point(7, 91);
            this.btnPrintTermine.Name = "btnPrintTermine";
            this.btnPrintTermine.Size = new System.Drawing.Size(73, 26);
            this.btnPrintTermine.TabIndex = 6;
            this.btnPrintTermine.TabStop = false;
            this.btnPrintTermine.TYPE = PMDS.GUI.ucButton.ButtonType.Print;
            this.btnPrintTermine.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnPrintTermine.Click += new System.EventHandler(this.btnPrintTermine_Click);
            // 
            // panelSondertermin
            // 
            this.panelSondertermin.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSondertermin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSondertermin.Controls.Add(this.btnSonderterminBeenden);
            this.panelSondertermin.Controls.Add(this.btnSonderterminErstellen);
            this.panelSondertermin.Controls.Add(this.btnSonderterminLöschen);
            this.panelSondertermin.Controls.Add(this.btnSonderterminBearbeiten);
            this.panelSondertermin.Location = new System.Drawing.Point(14, 13);
            this.panelSondertermin.Name = "panelSondertermin";
            this.panelSondertermin.Size = new System.Drawing.Size(94, 104);
            this.panelSondertermin.TabIndex = 90;
            this.panelSondertermin.Visible = false;
            // 
            // btnSonderterminBeenden
            // 
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.btnSonderterminBeenden.Appearance = appearance18;
            this.btnSonderterminBeenden.AutoWorkLayout = false;
            this.btnSonderterminBeenden.IsStandardControl = false;
            this.btnSonderterminBeenden.Location = new System.Drawing.Point(4, 51);
            this.btnSonderterminBeenden.Name = "btnSonderterminBeenden";
            this.btnSonderterminBeenden.Size = new System.Drawing.Size(85, 24);
            this.btnSonderterminBeenden.TabIndex = 96;
            this.btnSonderterminBeenden.Text = "Beenden";
            this.btnSonderterminBeenden.Click += new System.EventHandler(this.btnSonderterminBeenden_Click);
            // 
            // btnSonderterminErstellen
            // 
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.btnSonderterminErstellen.Appearance = appearance19;
            this.btnSonderterminErstellen.AutoWorkLayout = false;
            this.btnSonderterminErstellen.IsStandardControl = false;
            this.btnSonderterminErstellen.Location = new System.Drawing.Point(4, 3);
            this.btnSonderterminErstellen.Name = "btnSonderterminErstellen";
            this.btnSonderterminErstellen.Size = new System.Drawing.Size(85, 24);
            this.btnSonderterminErstellen.TabIndex = 95;
            this.btnSonderterminErstellen.Text = "Erstellen";
            this.btnSonderterminErstellen.Click += new System.EventHandler(this.btnSonderterminErstellen_Click);
            // 
            // btnSonderterminLöschen
            // 
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.btnSonderterminLöschen.Appearance = appearance20;
            this.btnSonderterminLöschen.AutoWorkLayout = false;
            this.btnSonderterminLöschen.IsStandardControl = false;
            this.btnSonderterminLöschen.Location = new System.Drawing.Point(4, 75);
            this.btnSonderterminLöschen.Name = "btnSonderterminLöschen";
            this.btnSonderterminLöschen.Size = new System.Drawing.Size(85, 24);
            this.btnSonderterminLöschen.TabIndex = 91;
            this.btnSonderterminLöschen.Text = "Löschen";
            this.btnSonderterminLöschen.Click += new System.EventHandler(this.btnSonderterminLöschen_Click);
            // 
            // btnSonderterminBearbeiten
            // 
            appearance21.Image = ((object)(resources.GetObject("appearance21.Image")));
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance21.TextHAlignAsString = "Left";
            appearance21.TextVAlignAsString = "Middle";
            this.btnSonderterminBearbeiten.Appearance = appearance21;
            this.btnSonderterminBearbeiten.AutoWorkLayout = false;
            this.btnSonderterminBearbeiten.IsStandardControl = false;
            this.btnSonderterminBearbeiten.Location = new System.Drawing.Point(4, 27);
            this.btnSonderterminBearbeiten.Name = "btnSonderterminBearbeiten";
            this.btnSonderterminBearbeiten.Size = new System.Drawing.Size(85, 24);
            this.btnSonderterminBearbeiten.TabIndex = 93;
            this.btnSonderterminBearbeiten.Text = "Bearbeiten";
            this.btnSonderterminBearbeiten.Click += new System.EventHandler(this.btnSonderterminBearbeiten_Click);
            // 
            // contextMenuStripSys
            // 
            this.contextMenuStripSys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardlayoutAnwendenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openSqlCommandToolStripMenuItem,
            this.updateNächstesDatumToolStripMenuItem});
            this.contextMenuStripSys.Name = "contextMenuStripSys";
            this.contextMenuStripSys.Size = new System.Drawing.Size(351, 76);
            // 
            // standardlayoutAnwendenToolStripMenuItem
            // 
            this.standardlayoutAnwendenToolStripMenuItem.Name = "standardlayoutAnwendenToolStripMenuItem";
            this.standardlayoutAnwendenToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.standardlayoutAnwendenToolStripMenuItem.Text = "Refresh ohne Quickfilter (Standardlayout anwenden)";
            this.standardlayoutAnwendenToolStripMenuItem.Click += new System.EventHandler(this.standardlayoutAnwendenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(347, 6);
            // 
            // openSqlCommandToolStripMenuItem
            // 
            this.openSqlCommandToolStripMenuItem.Name = "openSqlCommandToolStripMenuItem";
            this.openSqlCommandToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.openSqlCommandToolStripMenuItem.Text = "Open Sql-Command";
            this.openSqlCommandToolStripMenuItem.Click += new System.EventHandler(this.openSqlCommandToolStripMenuItem_Click);
            // 
            // updateNächstesDatumToolStripMenuItem
            // 
            this.updateNächstesDatumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gesamteDatenbankToolStripMenuItem,
            this.nufFürDieAbteilungToolStripMenuItem,
            this.nurFürDenKlientenToolStripMenuItem});
            this.updateNächstesDatumToolStripMenuItem.Name = "updateNächstesDatumToolStripMenuItem";
            this.updateNächstesDatumToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.updateNächstesDatumToolStripMenuItem.Text = "Update nächstes Datum";
            // 
            // gesamteDatenbankToolStripMenuItem
            // 
            this.gesamteDatenbankToolStripMenuItem.Name = "gesamteDatenbankToolStripMenuItem";
            this.gesamteDatenbankToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gesamteDatenbankToolStripMenuItem.Text = "Gesamte Datenbank";
            this.gesamteDatenbankToolStripMenuItem.Click += new System.EventHandler(this.gesamteDatenbankToolStripMenuItem_Click);
            // 
            // nufFürDieAbteilungToolStripMenuItem
            // 
            this.nufFürDieAbteilungToolStripMenuItem.Name = "nufFürDieAbteilungToolStripMenuItem";
            this.nufFürDieAbteilungToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nufFürDieAbteilungToolStripMenuItem.Text = "Nur für die Abteilung";
            this.nufFürDieAbteilungToolStripMenuItem.Click += new System.EventHandler(this.nufFürDieAbteilungToolStripMenuItem_Click);
            // 
            // nurFürDenKlientenToolStripMenuItem
            // 
            this.nurFürDenKlientenToolStripMenuItem.Name = "nurFürDenKlientenToolStripMenuItem";
            this.nurFürDenKlientenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nurFürDenKlientenToolStripMenuItem.Text = "Nur für den Klienten";
            this.nurFürDenKlientenToolStripMenuItem.Click += new System.EventHandler(this.nurFürDenKlientenToolStripMenuItem_Click);
            // 
            // gridPanelGrid
            // 
            this.gridPanelGrid.BackColor = System.Drawing.Color.Gainsboro;
            this.gridPanelGrid.Controls.Add(this.dgTermine);
            this.gridPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanelGrid.ExpandToFitHeight = true;
            this.gridPanelGrid.ExpandToFitWidth = true;
            this.gridPanelGrid.Location = new System.Drawing.Point(0, 0);
            this.gridPanelGrid.Name = "gridPanelGrid";
            this.gridPanelGrid.Size = new System.Drawing.Size(1128, 458);
            this.gridPanelGrid.TabIndex = 49;
            // 
            // layFilterObenRechts
            // 
            this.layFilterObenRechts.ExpandToFitHeight = true;
            this.layFilterObenRechts.ExpandToFitWidth = true;
            // 
            // panelEinAusGesamt
            // 
            this.panelEinAusGesamt.BackColor = System.Drawing.Color.Transparent;
            this.panelEinAusGesamt.Controls.Add(this.panelTextControl);
            this.panelEinAusGesamt.Controls.Add(this.textControl1);
            this.panelEinAusGesamt.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEinAusGesamt.Location = new System.Drawing.Point(1094, 0);
            this.panelEinAusGesamt.Name = "panelEinAusGesamt";
            this.panelEinAusGesamt.Size = new System.Drawing.Size(34, 78);
            this.panelEinAusGesamt.TabIndex = 51;
            // 
            // panelTextControl
            // 
            this.panelTextControl.BackColor = System.Drawing.Color.Transparent;
            this.panelTextControl.Location = new System.Drawing.Point(17, 50);
            this.panelTextControl.Name = "panelTextControl";
            this.panelTextControl.Size = new System.Drawing.Size(46, 43);
            this.panelTextControl.TabIndex = 1;
            // 
            // textControl1
            // 
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(17, 50);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(38, 35);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            // 
            // ultraPopupControlContainerPrint
            // 
            this.ultraPopupControlContainerPrint.PopupControl = this.pnlPrintTermine;
            // 
            // ultraGridBagLayoutPanelTop
            // 
            this.ultraGridBagLayoutPanelTop.BackColor = System.Drawing.Color.Gainsboro;
            this.ultraGridBagLayoutPanelTop.Controls.Add(this.quickFilterButtons1);
            this.ultraGridBagLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelTop.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelTop.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelTop.Name = "ultraGridBagLayoutPanelTop";
            this.ultraGridBagLayoutPanelTop.Size = new System.Drawing.Size(1128, 26);
            this.ultraGridBagLayoutPanelTop.TabIndex = 54;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // btnAlleAuswählen
            // 
            this.btnAlleAuswählen.AcceptsFocus = false;
            appearance42.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance42.TextHAlignAsString = "Center";
            appearance42.TextVAlignAsString = "Middle";
            this.btnAlleAuswählen.Appearance = appearance42;
            this.btnAlleAuswählen.AutoWorkLayout = false;
            this.btnAlleAuswählen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAlleAuswählen.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAlleAuswählen.IsStandardControl = false;
            this.btnAlleAuswählen.Location = new System.Drawing.Point(5, 0);
            this.btnAlleAuswählen.Name = "btnAlleAuswählen";
            this.btnAlleAuswählen.Size = new System.Drawing.Size(46, 23);
            this.btnAlleAuswählen.TabIndex = 46;
            this.btnAlleAuswählen.Tag = "0";
            this.btnAlleAuswählen.Text = "Alle";
            ultraToolTipInfo1.ToolTipTextFormatted = "Alle/Keine Interventionen auswählen";
            ultraToolTipInfo1.ToolTipTitle = "Alle";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAlleAuswählen, ultraToolTipInfo1);
            this.btnAlleAuswählen.Click += new System.EventHandler(this.uButtonAlleAuswählen_Click);
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelGrid2);
            this.panelAll.Controls.Add(this.panelLeisteQuickButtons);
            this.panelAll.Controls.Add(this.panelTop);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1128, 601);
            this.panelAll.TabIndex = 60;
            // 
            // panelGrid2
            // 
            this.panelGrid2.Controls.Add(this.panelGrid);
            this.panelGrid2.Controls.Add(this.pButtonsAll);
            this.panelGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid2.Location = new System.Drawing.Point(0, 65);
            this.panelGrid2.Name = "panelGrid2";
            this.panelGrid2.Size = new System.Drawing.Size(1128, 536);
            this.panelGrid2.TabIndex = 65;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridPanelGrid);
            this.panelGrid.Controls.Add(this.panelSondertermin);
            this.panelGrid.Controls.Add(this.pnlPrintTermine);
            this.panelGrid.Controls.Add(this.PanelDekursEntwürfe);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1128, 458);
            this.panelGrid.TabIndex = 52;
            // 
            // PanelDekursEntwürfe
            // 
            this.PanelDekursEntwürfe.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelDekursEntwürfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellenAs);
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellen);
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwürfeListe);
            this.PanelDekursEntwürfe.Location = new System.Drawing.Point(14, 132);
            this.PanelDekursEntwürfe.Name = "PanelDekursEntwürfe";
            this.PanelDekursEntwürfe.Size = new System.Drawing.Size(103, 79);
            this.PanelDekursEntwürfe.TabIndex = 91;
            this.PanelDekursEntwürfe.Visible = false;
            // 
            // btnDekursEntwurfErstellenAs
            // 
            appearance24.Image = ((object)(resources.GetObject("appearance24.Image")));
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance24.TextHAlignAsString = "Left";
            appearance24.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellenAs.Appearance = appearance24;
            this.btnDekursEntwurfErstellenAs.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellenAs.IsStandardControl = false;
            this.btnDekursEntwurfErstellenAs.Location = new System.Drawing.Point(4, 27);
            this.btnDekursEntwurfErstellenAs.Name = "btnDekursEntwurfErstellenAs";
            this.btnDekursEntwurfErstellenAs.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellenAs.TabIndex = 96;
            this.btnDekursEntwurfErstellenAs.Text = "Erstellen als";
            this.btnDekursEntwurfErstellenAs.Click += new System.EventHandler(this.btnDekursEntwurfErstellenAs_Click);
            // 
            // btnDekursEntwurfErstellen
            // 
            appearance25.Image = ((object)(resources.GetObject("appearance25.Image")));
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance25.TextHAlignAsString = "Left";
            appearance25.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellen.Appearance = appearance25;
            this.btnDekursEntwurfErstellen.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellen.IsStandardControl = false;
            this.btnDekursEntwurfErstellen.Location = new System.Drawing.Point(4, 3);
            this.btnDekursEntwurfErstellen.Name = "btnDekursEntwurfErstellen";
            this.btnDekursEntwurfErstellen.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellen.TabIndex = 95;
            this.btnDekursEntwurfErstellen.Text = "Erstellen";
            this.btnDekursEntwurfErstellen.Click += new System.EventHandler(this.btnDekursEntwurfErstellen_Click);
            // 
            // btnDekursEntwürfeListe
            // 
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.btnDekursEntwürfeListe.Appearance = appearance26;
            this.btnDekursEntwürfeListe.AutoWorkLayout = false;
            this.btnDekursEntwürfeListe.IsStandardControl = false;
            this.btnDekursEntwürfeListe.Location = new System.Drawing.Point(4, 51);
            this.btnDekursEntwürfeListe.Name = "btnDekursEntwürfeListe";
            this.btnDekursEntwürfeListe.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwürfeListe.TabIndex = 93;
            this.btnDekursEntwürfeListe.Text = "Liste";
            this.btnDekursEntwürfeListe.Click += new System.EventHandler(this.btnDekursEntwürfeListe_Click);
            // 
            // pButtonsAll
            // 
            this.pButtonsAll.BackColor = System.Drawing.Color.Transparent;
            this.pButtonsAll.Controls.Add(this.panelStuhlbuttonsFläche);
            this.pButtonsAll.Controls.Add(this.panelStuhlbuttonsLeer);
            this.pButtonsAll.Controls.Add(this.pButtonsAllDyn);
            this.pButtonsAll.Controls.Add(this.panelButtonsAlleKeine);
            this.pButtonsAll.Controls.Add(this.panelEinAusGesamt);
            this.pButtonsAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsAll.Location = new System.Drawing.Point(0, 458);
            this.pButtonsAll.Name = "pButtonsAll";
            this.pButtonsAll.Size = new System.Drawing.Size(1128, 78);
            this.pButtonsAll.TabIndex = 51;
            // 
            // panelStuhlbuttonsFläche
            // 
            this.panelStuhlbuttonsFläche.BackColor = System.Drawing.Color.Transparent;
            this.panelStuhlbuttonsFläche.Controls.Add(this.panelStuhlbuttons);
            this.panelStuhlbuttonsFläche.Controls.Add(this.panelLeer2);
            this.panelStuhlbuttonsFläche.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStuhlbuttonsFläche.Location = new System.Drawing.Point(55, 50);
            this.panelStuhlbuttonsFläche.Name = "panelStuhlbuttonsFläche";
            this.panelStuhlbuttonsFläche.Size = new System.Drawing.Size(1039, 24);
            this.panelStuhlbuttonsFläche.TabIndex = 106;
            // 
            // panelStuhlbuttons
            // 
            this.panelStuhlbuttons.BackColor = System.Drawing.Color.Transparent;
            this.panelStuhlbuttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStuhlbuttons.Location = new System.Drawing.Point(154, 0);
            this.panelStuhlbuttons.Name = "panelStuhlbuttons";
            this.panelStuhlbuttons.Size = new System.Drawing.Size(885, 24);
            this.panelStuhlbuttons.TabIndex = 1;
            // 
            // panelLeer2
            // 
            this.panelLeer2.BackColor = System.Drawing.Color.Transparent;
            this.panelLeer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeer2.Location = new System.Drawing.Point(0, 0);
            this.panelLeer2.Name = "panelLeer2";
            this.panelLeer2.Size = new System.Drawing.Size(154, 24);
            this.panelLeer2.TabIndex = 0;
            // 
            // panelStuhlbuttonsLeer
            // 
            this.panelStuhlbuttonsLeer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStuhlbuttonsLeer.Location = new System.Drawing.Point(55, 47);
            this.panelStuhlbuttonsLeer.Name = "panelStuhlbuttonsLeer";
            this.panelStuhlbuttonsLeer.Size = new System.Drawing.Size(1039, 3);
            this.panelStuhlbuttonsLeer.TabIndex = 105;
            // 
            // pButtonsAllDyn
            // 
            this.pButtonsAllDyn.Controls.Add(this.panelQuickButtons5);
            this.pButtonsAllDyn.Controls.Add(this.panelButtonsStuhlDrucken);
            this.pButtonsAllDyn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButtonsAllDyn.Location = new System.Drawing.Point(55, 0);
            this.pButtonsAllDyn.Name = "pButtonsAllDyn";
            this.pButtonsAllDyn.Size = new System.Drawing.Size(1039, 47);
            this.pButtonsAllDyn.TabIndex = 101;
            // 
            // panelQuickButtons5
            // 
            this.panelQuickButtons5.Controls.Add(this.panelButtonsÜbergabe);
            this.panelQuickButtons5.Controls.Add(this.panelButtonsIntervention);
            this.panelQuickButtons5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuickButtons5.Location = new System.Drawing.Point(0, 0);
            this.panelQuickButtons5.Name = "panelQuickButtons5";
            this.panelQuickButtons5.Size = new System.Drawing.Size(954, 47);
            this.panelQuickButtons5.TabIndex = 101;
            // 
            // panelButtonsÜbergabe
            // 
            this.panelButtonsÜbergabe.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsÜbergabe.Controls.Add(this.ultraDropDownButtonTermine);
            this.panelButtonsÜbergabe.Controls.Add(this.uDropDownDekursEntwürfe2);
            this.panelButtonsÜbergabe.Controls.Add(this.btnOpenBefundÜbergabe);
            this.panelButtonsÜbergabe.Controls.Add(this.btnGegenzeichnen);
            this.panelButtonsÜbergabe.Controls.Add(this.btnLesenÜbergabeDekurs);
            this.panelButtonsÜbergabe.Controls.Add(this.btnFreierBericht2);
            this.panelButtonsÜbergabe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonsÜbergabe.Location = new System.Drawing.Point(0, 23);
            this.panelButtonsÜbergabe.Name = "panelButtonsÜbergabe";
            this.panelButtonsÜbergabe.Size = new System.Drawing.Size(954, 23);
            this.panelButtonsÜbergabe.TabIndex = 97;
            this.panelButtonsÜbergabe.Visible = false;
            // 
            // ultraDropDownButtonTermine
            // 
            appearance27.Image = ((object)(resources.GetObject("appearance27.Image")));
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.ultraDropDownButtonTermine.Appearance = appearance27;
            this.ultraDropDownButtonTermine.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraDropDownButtonTermine.Location = new System.Drawing.Point(222, 0);
            this.ultraDropDownButtonTermine.Name = "ultraDropDownButtonTermine";
            this.ultraDropDownButtonTermine.PopupItemKey = "panelSondertermin";
            this.ultraDropDownButtonTermine.PopupItemProvider = this.ultraPopupControlContainerSondertermine;
            this.ultraDropDownButtonTermine.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.ultraDropDownButtonTermine.Size = new System.Drawing.Size(88, 23);
            this.ultraDropDownButtonTermine.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.ultraDropDownButtonTermine.TabIndex = 113;
            this.ultraDropDownButtonTermine.Text = "Termine";
            this.ultraDropDownButtonTermine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraDropDownButtonTermine.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraDropDownButtonTermine.Click += new System.EventHandler(this.ultraDropDownButtonTermine_Click);
            // 
            // ultraPopupControlContainerSondertermine
            // 
            this.ultraPopupControlContainerSondertermine.PopupControl = this.panelSondertermin;
            // 
            // uDropDownDekursEntwürfe2
            // 
            appearance28.Image = ((object)(resources.GetObject("appearance28.Image")));
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownDekursEntwürfe2.Appearance = appearance28;
            this.uDropDownDekursEntwürfe2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uDropDownDekursEntwürfe2.Location = new System.Drawing.Point(99, 0);
            this.uDropDownDekursEntwürfe2.Name = "uDropDownDekursEntwürfe2";
            this.uDropDownDekursEntwürfe2.PopupItemKey = "PanelDekursEntwürfe";
            this.uDropDownDekursEntwürfe2.PopupItemProvider = this.ultraPopupControlContainerDekursEntwürfe;
            this.uDropDownDekursEntwürfe2.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDekursEntwürfe2.Size = new System.Drawing.Size(123, 23);
            this.uDropDownDekursEntwürfe2.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDekursEntwürfe2.TabIndex = 112;
            this.uDropDownDekursEntwürfe2.Text = "Dekurs Entwurf";
            this.uDropDownDekursEntwürfe2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDekursEntwürfe2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraPopupControlContainerDekursEntwürfe
            // 
            this.ultraPopupControlContainerDekursEntwürfe.PopupControl = this.PanelDekursEntwürfe;
            this.ultraPopupControlContainerDekursEntwürfe.Opened += new System.EventHandler(this.ultraPopupControlContainerDekursEntwürfe_Opened);
            // 
            // btnOpenBefundÜbergabe
            // 
            appearance29.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.btnOpenBefundÜbergabe.Appearance = appearance29;
            this.btnOpenBefundÜbergabe.AutoWorkLayout = false;
            this.btnOpenBefundÜbergabe.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenBefundÜbergabe.IsStandardControl = false;
            this.btnOpenBefundÜbergabe.Location = new System.Drawing.Point(757, 0);
            this.btnOpenBefundÜbergabe.Name = "btnOpenBefundÜbergabe";
            this.btnOpenBefundÜbergabe.Size = new System.Drawing.Size(50, 23);
            this.btnOpenBefundÜbergabe.TabIndex = 111;
            this.btnOpenBefundÜbergabe.Text = "Befund";
            this.btnOpenBefundÜbergabe.Visible = false;
            this.btnOpenBefundÜbergabe.Click += new System.EventHandler(this.btnOpenBefundÜbergabe_Click);
            // 
            // btnGegenzeichnen
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance30.TextHAlignAsString = "Left";
            appearance30.TextVAlignAsString = "Middle";
            this.btnGegenzeichnen.Appearance = appearance30;
            this.btnGegenzeichnen.AutoWorkLayout = false;
            this.btnGegenzeichnen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGegenzeichnen.IsStandardControl = false;
            this.btnGegenzeichnen.Location = new System.Drawing.Point(807, 0);
            this.btnGegenzeichnen.Name = "btnGegenzeichnen";
            this.btnGegenzeichnen.Size = new System.Drawing.Size(101, 23);
            this.btnGegenzeichnen.TabIndex = 110;
            this.btnGegenzeichnen.Text = "Gegenzeichnen";
            this.btnGegenzeichnen.Click += new System.EventHandler(this.btnGegenzeichnen_Click);
            // 
            // btnLesenÜbergabeDekurs
            // 
            appearance31.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance31.TextHAlignAsString = "Left";
            appearance31.TextVAlignAsString = "Middle";
            this.btnLesenÜbergabeDekurs.Appearance = appearance31;
            this.btnLesenÜbergabeDekurs.AutoWorkLayout = false;
            this.btnLesenÜbergabeDekurs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLesenÜbergabeDekurs.IsStandardControl = false;
            this.btnLesenÜbergabeDekurs.Location = new System.Drawing.Point(908, 0);
            this.btnLesenÜbergabeDekurs.Name = "btnLesenÜbergabeDekurs";
            this.btnLesenÜbergabeDekurs.Size = new System.Drawing.Size(46, 23);
            this.btnLesenÜbergabeDekurs.TabIndex = 94;
            this.btnLesenÜbergabeDekurs.Text = "Lesen";
            this.btnLesenÜbergabeDekurs.Click += new System.EventHandler(this.btnLesenÜbergabeDekurs_Click);
            // 
            // btnFreierBericht2
            // 
            appearance32.Image = ((object)(resources.GetObject("appearance32.Image")));
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.btnFreierBericht2.Appearance = appearance32;
            this.btnFreierBericht2.AutoWorkLayout = false;
            this.btnFreierBericht2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFreierBericht2.IsStandardControl = false;
            this.btnFreierBericht2.Location = new System.Drawing.Point(0, 0);
            this.btnFreierBericht2.Name = "btnFreierBericht2";
            this.btnFreierBericht2.Size = new System.Drawing.Size(99, 23);
            this.btnFreierBericht2.TabIndex = 62;
            this.btnFreierBericht2.Text = "Dekurs";
            this.btnFreierBericht2.Click += new System.EventHandler(this.btnFreierBericht2_Click);
            // 
            // panelButtonsIntervention
            // 
            this.panelButtonsIntervention.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsIntervention.Controls.Add(this.btnOpenBefundIntervention);
            this.panelButtonsIntervention.Controls.Add(this.btnPDxRückmelden);
            this.panelButtonsIntervention.Controls.Add(this.btnLesenInterventionen);
            this.panelButtonsIntervention.Controls.Add(this.panelIButtonLeiste);
            this.panelButtonsIntervention.Controls.Add(this.panelSpace);
            this.panelButtonsIntervention.Controls.Add(this.btnSchnellrückmeldung);
            this.panelButtonsIntervention.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonsIntervention.Location = new System.Drawing.Point(0, 0);
            this.panelButtonsIntervention.Name = "panelButtonsIntervention";
            this.panelButtonsIntervention.Size = new System.Drawing.Size(954, 23);
            this.panelButtonsIntervention.TabIndex = 54;
            // 
            // btnOpenBefundIntervention
            // 
            appearance33.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.btnOpenBefundIntervention.Appearance = appearance33;
            this.btnOpenBefundIntervention.AutoWorkLayout = false;
            this.btnOpenBefundIntervention.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenBefundIntervention.IsStandardControl = false;
            this.btnOpenBefundIntervention.Location = new System.Drawing.Point(757, 0);
            this.btnOpenBefundIntervention.Name = "btnOpenBefundIntervention";
            this.btnOpenBefundIntervention.Size = new System.Drawing.Size(50, 23);
            this.btnOpenBefundIntervention.TabIndex = 110;
            this.btnOpenBefundIntervention.Text = "Befund";
            this.btnOpenBefundIntervention.Visible = false;
            this.btnOpenBefundIntervention.Click += new System.EventHandler(this.btnOpenBefundIntervention_Click);
            // 
            // btnPDxRückmelden
            // 
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.btnPDxRückmelden.Appearance = appearance34;
            this.btnPDxRückmelden.AutoWorkLayout = false;
            this.btnPDxRückmelden.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPDxRückmelden.IsStandardControl = false;
            this.btnPDxRückmelden.Location = new System.Drawing.Point(807, 0);
            this.btnPDxRückmelden.Name = "btnPDxRückmelden";
            this.btnPDxRückmelden.Size = new System.Drawing.Size(101, 23);
            this.btnPDxRückmelden.TabIndex = 109;
            this.btnPDxRückmelden.Text = "PDx rückmelden";
            this.btnPDxRückmelden.Click += new System.EventHandler(this.btnPDxRückmelden_Click);
            // 
            // btnLesenInterventionen
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.btnLesenInterventionen.Appearance = appearance35;
            this.btnLesenInterventionen.AutoWorkLayout = false;
            this.btnLesenInterventionen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLesenInterventionen.IsStandardControl = false;
            this.btnLesenInterventionen.Location = new System.Drawing.Point(908, 0);
            this.btnLesenInterventionen.Name = "btnLesenInterventionen";
            this.btnLesenInterventionen.Size = new System.Drawing.Size(46, 23);
            this.btnLesenInterventionen.TabIndex = 108;
            this.btnLesenInterventionen.Text = "Lesen";
            this.btnLesenInterventionen.Visible = false;
            this.btnLesenInterventionen.Click += new System.EventHandler(this.btnLesenInterventionen_Click);
            // 
            // panelIButtonLeiste
            // 
            this.panelIButtonLeiste.BackColor = System.Drawing.Color.Transparent;
            this.panelIButtonLeiste.Controls.Add(this.uDropDownSondertermine);
            this.panelIButtonLeiste.Controls.Add(this.panelSondertermine);
            this.panelIButtonLeiste.Controls.Add(this.btnFreierBericht);
            this.panelIButtonLeiste.Controls.Add(this.btnUngeplMaßnahmenRückemelden);
            this.panelIButtonLeiste.Controls.Add(this.btnBedarfsmedikation);
            this.panelIButtonLeiste.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIButtonLeiste.Location = new System.Drawing.Point(143, 0);
            this.panelIButtonLeiste.Name = "panelIButtonLeiste";
            this.panelIButtonLeiste.Size = new System.Drawing.Size(553, 23);
            this.panelIButtonLeiste.TabIndex = 107;
            // 
            // uDropDownSondertermine
            // 
            appearance36.Image = ((object)(resources.GetObject("appearance36.Image")));
            appearance36.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownSondertermine.Appearance = appearance36;
            this.uDropDownSondertermine.Dock = System.Windows.Forms.DockStyle.Left;
            this.uDropDownSondertermine.Location = new System.Drawing.Point(467, 0);
            this.uDropDownSondertermine.Name = "uDropDownSondertermine";
            this.uDropDownSondertermine.PopupItemKey = "panelSondertermin";
            this.uDropDownSondertermine.PopupItemProvider = this.ultraPopupControlContainerSondertermine;
            this.uDropDownSondertermine.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownSondertermine.Size = new System.Drawing.Size(84, 23);
            this.uDropDownSondertermine.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownSondertermine.TabIndex = 106;
            this.uDropDownSondertermine.Text = "Termine";
            this.uDropDownSondertermine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownSondertermine.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panelSondertermine
            // 
            this.panelSondertermine.BackColor = System.Drawing.Color.Transparent;
            this.panelSondertermine.Controls.Add(this.uDropDownDekursEntwürfe);
            this.panelSondertermine.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSondertermine.Location = new System.Drawing.Point(343, 0);
            this.panelSondertermine.Name = "panelSondertermine";
            this.panelSondertermine.Size = new System.Drawing.Size(124, 23);
            this.panelSondertermine.TabIndex = 105;
            // 
            // uDropDownDekursEntwürfe
            // 
            appearance37.Image = ((object)(resources.GetObject("appearance37.Image")));
            appearance37.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownDekursEntwürfe.Appearance = appearance37;
            this.uDropDownDekursEntwürfe.Dock = System.Windows.Forms.DockStyle.Left;
            this.uDropDownDekursEntwürfe.Location = new System.Drawing.Point(0, 0);
            this.uDropDownDekursEntwürfe.Name = "uDropDownDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemKey = "PanelDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemProvider = this.ultraPopupControlContainerDekursEntwürfe;
            this.uDropDownDekursEntwürfe.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDekursEntwürfe.Size = new System.Drawing.Size(123, 23);
            this.uDropDownDekursEntwürfe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDekursEntwürfe.TabIndex = 90;
            this.uDropDownDekursEntwürfe.Text = "Dekurs Entwurf";
            this.uDropDownDekursEntwürfe.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDekursEntwürfe.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnFreierBericht
            // 
            appearance38.Image = ((object)(resources.GetObject("appearance38.Image")));
            appearance38.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance38.TextHAlignAsString = "Left";
            appearance38.TextVAlignAsString = "Middle";
            this.btnFreierBericht.Appearance = appearance38;
            this.btnFreierBericht.AutoWorkLayout = false;
            this.btnFreierBericht.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFreierBericht.IsStandardControl = false;
            this.btnFreierBericht.Location = new System.Drawing.Point(244, 0);
            this.btnFreierBericht.Name = "btnFreierBericht";
            this.btnFreierBericht.ShowFocusRect = false;
            this.btnFreierBericht.Size = new System.Drawing.Size(99, 23);
            this.btnFreierBericht.TabIndex = 56;
            this.btnFreierBericht.Text = "Dekurs";
            this.btnFreierBericht.Click += new System.EventHandler(this.btnFreierBericht_Click);
            // 
            // btnUngeplMaßnahmenRückemelden
            // 
            appearance39.Image = ((object)(resources.GetObject("appearance39.Image")));
            appearance39.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance39.TextHAlignAsString = "Left";
            appearance39.TextVAlignAsString = "Middle";
            this.btnUngeplMaßnahmenRückemelden.Appearance = appearance39;
            this.btnUngeplMaßnahmenRückemelden.AutoWorkLayout = false;
            this.btnUngeplMaßnahmenRückemelden.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUngeplMaßnahmenRückemelden.IsStandardControl = false;
            this.btnUngeplMaßnahmenRückemelden.Location = new System.Drawing.Point(125, 0);
            this.btnUngeplMaßnahmenRückemelden.Name = "btnUngeplMaßnahmenRückemelden";
            this.btnUngeplMaßnahmenRückemelden.Size = new System.Drawing.Size(119, 23);
            this.btnUngeplMaßnahmenRückemelden.TabIndex = 54;
            this.btnUngeplMaßnahmenRückemelden.Text = "Ungepl. M abz.";
            this.btnUngeplMaßnahmenRückemelden.Click += new System.EventHandler(this.btnUngeplMaßnahmenRückemelden_Click);
            // 
            // btnBedarfsmedikation
            // 
            appearance40.Image = ((object)(resources.GetObject("appearance40.Image")));
            appearance40.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance40.TextHAlignAsString = "Left";
            appearance40.TextVAlignAsString = "Middle";
            this.btnBedarfsmedikation.Appearance = appearance40;
            this.btnBedarfsmedikation.AutoWorkLayout = false;
            this.btnBedarfsmedikation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBedarfsmedikation.IsStandardControl = false;
            this.btnBedarfsmedikation.Location = new System.Drawing.Point(0, 0);
            this.btnBedarfsmedikation.Name = "btnBedarfsmedikation";
            this.btnBedarfsmedikation.Size = new System.Drawing.Size(125, 23);
            this.btnBedarfsmedikation.TabIndex = 55;
            this.btnBedarfsmedikation.Text = "Einzelverordnung";
            this.btnBedarfsmedikation.Click += new System.EventHandler(this.btnBedarfsmedikation_Click);
            // 
            // panelSpace
            // 
            this.panelSpace.BackColor = System.Drawing.Color.Transparent;
            this.panelSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSpace.Location = new System.Drawing.Point(134, 0);
            this.panelSpace.Name = "panelSpace";
            this.panelSpace.Size = new System.Drawing.Size(9, 23);
            this.panelSpace.TabIndex = 106;
            // 
            // btnSchnellrückmeldung
            // 
            appearance41.Image = ((object)(resources.GetObject("appearance41.Image")));
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance41.TextHAlignAsString = "Left";
            appearance41.TextVAlignAsString = "Middle";
            this.btnSchnellrückmeldung.Appearance = appearance41;
            this.btnSchnellrückmeldung.AutoWorkLayout = false;
            this.btnSchnellrückmeldung.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSchnellrückmeldung.IsStandardControl = false;
            this.btnSchnellrückmeldung.Location = new System.Drawing.Point(0, 0);
            this.btnSchnellrückmeldung.Name = "btnSchnellrückmeldung";
            this.btnSchnellrückmeldung.Size = new System.Drawing.Size(134, 23);
            this.btnSchnellrückmeldung.TabIndex = 53;
            this.btnSchnellrückmeldung.Text = "Schnell abzeichnen";
            this.btnSchnellrückmeldung.Click += new System.EventHandler(this.btnSchnellrückmeldung_Click);
            // 
            // panelButtonsStuhlDrucken
            // 
            this.panelButtonsStuhlDrucken.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsStuhlDrucken.Controls.Add(this.uDropDownDrucken);
            this.panelButtonsStuhlDrucken.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsStuhlDrucken.Location = new System.Drawing.Point(954, 0);
            this.panelButtonsStuhlDrucken.Name = "panelButtonsStuhlDrucken";
            this.panelButtonsStuhlDrucken.Size = new System.Drawing.Size(85, 47);
            this.panelButtonsStuhlDrucken.TabIndex = 100;
            // 
            // uDropDownDrucken
            // 
            this.uDropDownDrucken.Location = new System.Drawing.Point(1, 0);
            this.uDropDownDrucken.Name = "uDropDownDrucken";
            this.uDropDownDrucken.PopupItemKey = "pnlPrintStammDatenBlatt";
            this.uDropDownDrucken.PopupItemProvider = this.ultraPopupControlContainerPrint;
            this.uDropDownDrucken.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDrucken.Size = new System.Drawing.Size(67, 23);
            this.uDropDownDrucken.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDrucken.TabIndex = 91;
            this.uDropDownDrucken.Text = "Drucken";
            this.uDropDownDrucken.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDrucken.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDrucken.Click += new System.EventHandler(this.uDropDownDrucken_Click);
            // 
            // panelButtonsAlleKeine
            // 
            this.panelButtonsAlleKeine.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsAlleKeine.Controls.Add(this.btnAlleAuswählen);
            this.panelButtonsAlleKeine.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelButtonsAlleKeine.Location = new System.Drawing.Point(0, 0);
            this.panelButtonsAlleKeine.Name = "panelButtonsAlleKeine";
            this.panelButtonsAlleKeine.Size = new System.Drawing.Size(55, 78);
            this.panelButtonsAlleKeine.TabIndex = 53;
            // 
            // panelLeisteQuickButtons
            // 
            this.panelLeisteQuickButtons.Controls.Add(this.ultraGridBagLayoutPanelTop);
            this.panelLeisteQuickButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeisteQuickButtons.Location = new System.Drawing.Point(0, 39);
            this.panelLeisteQuickButtons.Name = "panelLeisteQuickButtons";
            this.panelLeisteQuickButtons.Size = new System.Drawing.Size(1128, 26);
            this.panelLeisteQuickButtons.TabIndex = 64;
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.ultraGridBagLayoutPanel2.TabIndex = 0;
            // 
            // lblDatenWerdenAktualisiert2
            // 
            appearance43.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance43.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance43.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance43.BackColorDisabled2 = System.Drawing.Color.WhiteSmoke;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Center";
            appearance43.TextVAlignAsString = "Middle";
            this.lblDatenWerdenAktualisiert2.Appearance = appearance43;
            this.lblDatenWerdenAktualisiert2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblDatenWerdenAktualisiert2.Location = new System.Drawing.Point(2, 2);
            this.lblDatenWerdenAktualisiert2.Name = "lblDatenWerdenAktualisiert2";
            this.lblDatenWerdenAktualisiert2.Size = new System.Drawing.Size(151, 30);
            this.lblDatenWerdenAktualisiert2.TabIndex = 40;
            this.lblDatenWerdenAktualisiert2.Text = "Daten werden aktualisiert. Bitte warten ...";
            // 
            // panelLoading
            // 
            this.panelLoading.BackColor = System.Drawing.Color.Gray;
            this.panelLoading.Controls.Add(this.gridBagDatenWerdenAktualisiert);
            this.panelLoading.Location = new System.Drawing.Point(422, 211);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(150, 37);
            this.panelLoading.TabIndex = 70;
            this.panelLoading.Visible = false;
            // 
            // gridBagDatenWerdenAktualisiert
            // 
            this.gridBagDatenWerdenAktualisiert.Controls.Add(this.panelDatenWerdenAktualisiert);
            this.gridBagDatenWerdenAktualisiert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBagDatenWerdenAktualisiert.ExpandToFitHeight = true;
            this.gridBagDatenWerdenAktualisiert.ExpandToFitWidth = true;
            this.gridBagDatenWerdenAktualisiert.Location = new System.Drawing.Point(0, 0);
            this.gridBagDatenWerdenAktualisiert.Name = "gridBagDatenWerdenAktualisiert";
            this.gridBagDatenWerdenAktualisiert.Size = new System.Drawing.Size(150, 37);
            this.gridBagDatenWerdenAktualisiert.TabIndex = 0;
            // 
            // panelDatenWerdenAktualisiert
            // 
            this.panelDatenWerdenAktualisiert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDatenWerdenAktualisiert.Controls.Add(this.lblDatenWerdenAktualisiert);
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.Insets.Bottom = 2;
            gridBagConstraint3.Insets.Left = 2;
            gridBagConstraint3.Insets.Right = 2;
            gridBagConstraint3.Insets.Top = 2;
            this.gridBagDatenWerdenAktualisiert.SetGridBagConstraint(this.panelDatenWerdenAktualisiert, gridBagConstraint3);
            this.panelDatenWerdenAktualisiert.Location = new System.Drawing.Point(2, 2);
            this.panelDatenWerdenAktualisiert.Name = "panelDatenWerdenAktualisiert";
            this.gridBagDatenWerdenAktualisiert.SetPreferredSize(this.panelDatenWerdenAktualisiert, new System.Drawing.Size(200, 100));
            this.panelDatenWerdenAktualisiert.Size = new System.Drawing.Size(146, 33);
            this.panelDatenWerdenAktualisiert.TabIndex = 0;
            // 
            // lblDatenWerdenAktualisiert
            // 
            appearance17.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance17.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance17.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance17.BackColorDisabled2 = System.Drawing.Color.WhiteSmoke;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Center";
            appearance17.TextVAlignAsString = "Middle";
            this.lblDatenWerdenAktualisiert.Appearance = appearance17;
            this.lblDatenWerdenAktualisiert.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblDatenWerdenAktualisiert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatenWerdenAktualisiert.Location = new System.Drawing.Point(0, 0);
            this.lblDatenWerdenAktualisiert.Name = "lblDatenWerdenAktualisiert";
            this.lblDatenWerdenAktualisiert.Size = new System.Drawing.Size(146, 33);
            this.lblDatenWerdenAktualisiert.TabIndex = 41;
            this.lblDatenWerdenAktualisiert.Text = "Daten werden aktualisiert. Bitte warten ...";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ucTermineEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.panelAll);
            this.Name = "ucTermineEx";
            this.Size = new System.Drawing.Size(1128, 601);
            this.Load += new System.EventHandler(this.ucTermineEx_Load);
            this.VisibleChanged += new System.EventHandler(this.ucTermineEx_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgTermine)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchInGrid)).EndInit();
            this.panelFilterOben2.ResumeLayout(false);
            this.panelZeitraum.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelTopRight.ResumeLayout(false);
            this.pnlPrintTermine.ResumeLayout(false);
            this.pnlPrintTermine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uOptSetDruckauswahl)).EndInit();
            this.panelSondertermin.ResumeLayout(false);
            this.contextMenuStripSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPanelGrid)).EndInit();
            this.gridPanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layFilterObenRechts)).EndInit();
            this.panelEinAusGesamt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelTop)).EndInit();
            this.ultraGridBagLayoutPanelTop.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelGrid2.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.PanelDekursEntwürfe.ResumeLayout(false);
            this.pButtonsAll.ResumeLayout(false);
            this.panelStuhlbuttonsFläche.ResumeLayout(false);
            this.pButtonsAllDyn.ResumeLayout(false);
            this.panelQuickButtons5.ResumeLayout(false);
            this.panelButtonsÜbergabe.ResumeLayout(false);
            this.panelButtonsIntervention.ResumeLayout(false);
            this.panelIButtonLeiste.ResumeLayout(false);
            this.panelSondertermine.ResumeLayout(false);
            this.panelButtonsStuhlDrucken.ResumeLayout(false);
            this.panelButtonsAlleKeine.ResumeLayout(false);
            this.panelLeisteQuickButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBagDatenWerdenAktualisiert)).EndInit();
            this.gridBagDatenWerdenAktualisiert.ResumeLayout(false);
            this.panelDatenWerdenAktualisiert.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion




        private void ucTermineEx_Load(object sender, EventArgs e)
        {

        }
        private void ucTermineEx_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //this.quickFilterButtons1.ReposButtons(this.Width); 
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        public void initControl()
        {
            try
            {
                base.MainWindow = this;
                this.standardlayoutAnwendenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, QS2.Resources.getRes.ePicTyp.ico);
                this.btnDekursEntwürfeListe.Appearance .Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, QS2.Resources.getRes.ePicTyp.ico); ;
                this.uDropDownDekursEntwürfe.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, QS2.Resources.getRes.ePicTyp.ico); ;
                this.uDropDownDekursEntwürfe2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, QS2.Resources.getRes.ePicTyp.ico); ;

                if (ENV.adminSecure || ENV.HasRight(UserRights.MenüStammdaten))
                {
                    this.updateNächstesDatumToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.updateNächstesDatumToolStripMenuItem.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.initControl: " + ex.ToString());
            }
        }

		public TerminExSettings getFilterSettingsFromUI()
		{
            try
            {
                TerminExSettings settings = new TerminExSettings();

                settings.Mode = ucTerminTimePicker1.Mode;
                settings.Fromxy = ucTerminTimePicker1.RangeFrom;
                settings.To = ucTerminTimePicker1.RangeTo;

                // FilterPicker
                settings.IDMassnahme = ucTerminFilterPicker1.IDMassnahme;

                settings.BezugJN = ucTerminFilterPicker1.ShowBezug;
                settings.IDBezug = ucTerminFilterPicker1.IDBezug;

                settings.Massnahmen = ucTerminFilterPicker1.MASSNAHMEN;

                settings.BerufsstandJN = ucTerminFilterPicker1.ShowBerufsstand;
                settings.Berufsstand = ucTerminFilterPicker1.Berufsstand;

                settings.WichtigFürJN = ucTerminFilterPicker1.WichtigFürJN;
                settings.WichtigFür = ucTerminFilterPicker1.WichtigFür;

                return settings;

            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.getFilterSettingsFromUI: " + ex.ToString());
            }
		}
        
        public bool IsChanged
        { 
            get
            { 
                return false;
            }
        }
        public bool Save()
        {
            return true;
        }
        public void Undo()
        {
        }
        public bool ValidateFields()
        {
            return true;
        }

        public void ClearMedizinischeButtons()
        {
            foreach (System.Windows.Forms.Control cont in panelStuhlbuttons.Controls)
                cont.Visible = false;
        }

        public void getSettingsFromQuickFilter(QuickFilterButton bQuick, TerminExSettings s,
                                                ref bool ManualParamtersFromUser)
        {
            try
            {
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)bQuick.Tag;

                if (!PMDS.Global.historie.HistorieOn)
                {
                }

                //140314 os: Zeitraum aus Filter nicht laden, wenn Zeitbereich manuell fixiert.
                s.ZeitraumFixierenJN = this.MainWindow.ucTerminTimePicker1.chkZeitraumFixierenJN.Checked;

                if (args.ZeitraumJN && !s.ZeitraumFixierenJN)
                {
                    s.ZeitraumJN = args.ZeitraumJN;

                    if (args.TageNachher == 0 && args.TageVorher == 0)
                    {
                        s.Mode = EFilter.HEUTE;
                    }
                    else
                    {
                        s.Mode = EFilter.INTERVALL;
                        s.Fromxy = DateTime.Now.AddDays(-args.TageVorher).Date;		// x tage vorher 00:00 uhr
                        s.To = DateTime.Now.AddDays(args.TageNachher).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    }
                    this.MainWindow.ucTerminTimePicker1.RecalcRange();
                    this.MainWindow.ucTerminFilterPicker1.RefreshGUI();
                }
                else
                {
                    s.ZeitraumJN = false; 
                }

                s.BezugJN = args.BezugspersonJN;
                s.IDBezug = args.IDBenutzer;

                s.Massnahmen = QuickFilterManager.GuidArrayFromString(args.Massnahmen);
                s.IDMassnahme = args.IDEintrag;

                s.Berufsstand = this.ucTerminFilterPicker1.setBerufsstandErstelltFromString(args.LstErstelltVonBerufgruppe.Trim());
                s.BerufsstandJN = s.Berufsstand.Count > 0 ? true : false;

                s.WichtigFür = this.ucTerminFilterPicker1.setWichtigFürFromString(args.LstWichtigFürBerufsgruppe.Trim());
                s.WichtigFürJN = s.WichtigFür.Count > 0 ? true : false;

                s.Planungstypen = this.ucTerminFilterPicker1.setPlanungsEinträgeFromString (args.LstPlanungseinträge.Trim());
                s.PlanungstypenJN = s.Planungstypen.Count > 0 ? true : false;

                s.Zusatzwerte = this.ucTerminFilterPicker1.setZusatzwerteFromString(args.LstZusatzwerte.Trim());
                s.ZusatzwerteJN = s.Zusatzwerte.Count > 0 ? true : false;

                s.Zeitbezug = this.ucTerminFilterPicker1.setZeitbezugJNAFromInt(args.lstZeitbezugxy.Trim());
                s.ZeitbezugJN = s.Zeitbezug.Count > 0 ? true : false;

                s.HerkunftPlanungsEintrag = this.ucTerminFilterPicker1.setZeitbezugJNAFromInt(args.lstHerkunftPlanungsEintrag.Trim());
                s.HerkunftPlanungsEintragJN = s.HerkunftPlanungsEintrag.Count > 0 ? true : false;

                s.ShowCC = args.ShowCC;
                s.Abzeichnen = args.Abzeichnen;
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.getSettingsFromQuickFilter: " + ex.ToString());
            }
        }
        public void ShowFilterSettingsInUI(TerminExSettings set, ref bool ManualParamtersFromUser)
        {
            try
            {
                if (set.ZeitraumJN)
                {
                    ucTerminTimePicker1.Mode = set.Mode;
                    ucTerminTimePicker1.RangeFrom = set.Fromxy;
                    ucTerminTimePicker1.RangeTo = set.To;
                }
                else
                {
                    string xy = "";
                }

                ucTerminFilterPicker1.MASSNAHMEN = set.Massnahmen;
                ucTerminFilterPicker1.IDMassnahme = set.IDMassnahme;

                ucTerminFilterPicker1.ShowBezug = set.BezugJN;
                ucTerminFilterPicker1.IDBezug = set.IDBezug;

                ucTerminFilterPicker1.ShowBerufsstand = set.BerufsstandJN;
                ucTerminFilterPicker1.Berufsstand = set.Berufsstand;

                ucTerminFilterPicker1.WichtigFürJN = set.WichtigFürJN;
                ucTerminFilterPicker1.WichtigFür = set.WichtigFür;

                ucTerminFilterPicker1.PlanungsEinträge = set.Planungstypen;
                ucTerminFilterPicker1.ShowPlanungsEinträgeJN = set.PlanungstypenJN;

                ucTerminFilterPicker1.Zusatzwerte = set.Zusatzwerte;
                ucTerminFilterPicker1.ShowZusatzwerte = set.ZusatzwerteJN;

                ucTerminFilterPicker1.ShowCC = set.ShowCC;
                ucTerminFilterPicker1.Abzeichnen = set.Abzeichnen;
                
                ucTerminFilterPicker1.ZeitbezugJNA = set.Zeitbezug;
                ucTerminFilterPicker1.ShowZeitbezugJN = set.ZeitbezugJN;

                ucTerminFilterPicker1.PlanungsEinträge = set.Planungstypen;
                ucTerminFilterPicker1.ShowPlanungsEinträgeJN = set.PlanungstypenJN;

                ucTerminFilterPicker1.HerkunftPlanungsEintrag = set.HerkunftPlanungsEintrag;
                ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag = set.HerkunftPlanungsEintragJN;

            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.ShowFilterSettingsInUI: " + ex.ToString());
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            this.ucTerminFilterPicker1.historieOnOff(bOn);
            this.ucTerminTimePicker1.historieOnOff(bOn);
        }

        public TerminExSettings loadZeitfiltersHistorieNachEntlassungxyxyxy(TerminExSettings s, bool onlyDatePatient)
        {
            try
            {
                if (!onlyDatePatient)
                {
                }

                Patient pat = new Patient(ENV.CurrentIDPatient);
                DateTime dTo = System.DateTime.Now;
                try
                {
                    dTo = new DateTime(((System.DateTime)pat.Aufenthalt.Entlassungszeitpunkt).Year,
                                        ((System.DateTime)pat.Aufenthalt.Entlassungszeitpunkt).Month,
                                        ((System.DateTime)pat.Aufenthalt.Entlassungszeitpunkt).Day, 23, 59, 59);
                    s.To = dTo;
                }
                catch (Exception ex)
                {
                    s.To = System.DateTime.Now;
                    //ENV.HandleException(ex);
                }
                DateTime dFrom = new DateTime(dTo.Year, dTo.Month, dTo.Day, 0, 0, 0);
                dFrom = dFrom.AddDays(-2);
                s.Fromxy = dFrom;
                s.Mode = EFilter.INTERVALL;
                //s.ZeitraumJN = false;

                return s;
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.loadZeitfiltersHistorieNachEntlassung: " + ex.ToString());
            }
        }
        public void SetSourceToGrid()
        {
            try
            {
                if (this._ds == null)
                {
                    this._ds = new Global.db.ERSystem.dsTermine();

                    if (this.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        this.dgTermine.DataSource = this._ds;
                        this.dgTermine.DataMember = this._ds.vInterventionen.TableName;
                        this.dgTermine.DataBind();
                    }
                    else if (this.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs ||
                            this.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Übergabe)
                    {
                        this.dgTermine.DataSource = this._ds;
                        this.dgTermine.DataMember = this._ds.vÜbergabe.TableName;
                        this.dgTermine.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.ClearGrid: " + ex.ToString());
            }
        }
      
        protected override void OnTerminSelected(EventArgs args)
        {
            base.OnTerminSelected(args);
        }

		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
		{
			get
			{
                if (ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    return this._idPatient;
                }
                else if (ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    if (this.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (CurTerminRowIntervention == null)
                            return System.Guid.Empty;
                        return CurTerminRowIntervention.IDKlient;
                    }
                    else
                    {
                        if (CurTerminRowÜbergabe == null)
                            return System.Guid.Empty;
                        return CurTerminRowÜbergabe.IDKlient;
                    }
                }
                return System.Guid.Empty;
			}
		}
		
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
		{
			get
			{
                if (ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    return ENV.IDAUFENTHALT ;
                }
                else if (ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (CurTerminRowIntervention == null)
                            return System.Guid.Empty;
                        return CurTerminRowIntervention.IDAufenthalt;
                    }
                    else
                    {
                        if (CurTerminRowÜbergabe == null)
                            return System.Guid.Empty;
                        return CurTerminRowÜbergabe.IDAufenthalt;
                    }
                }
                return System.Guid.Empty;
			}
		}

        private Guid CurrentIDLinkDokument
        {
            get
            {
                System.Guid IDAufenthaltTmp;
                System.Guid IDPflegeplanTmp = System.Guid.Empty;
                PMDS.BusinessLogic.PflegePlan p = null;
                if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (this.CheckPEHasIDPflegeplan(base.CurTerminRowIntervention, null))
                    {
                        if (CurTerminRowIntervention == null) return Guid.Empty;
                        IDAufenthaltTmp = CurTerminRowIntervention.IDAufenthalt;
                        IDPflegeplanTmp = CurTerminRowIntervention.IDPflegeplan;
                        p = new PMDS.BusinessLogic.PflegePlan(IDAufenthaltTmp);
                    }
                }
                else
                {
                    if (this.CheckPEHasIDPflegeplan(null, CurTerminRowÜbergabe))
                    {
                        if (CurTerminRowÜbergabe == null) return Guid.Empty;
                        IDAufenthaltTmp = CurTerminRowÜbergabe.IDAufenthalt;
                        IDPflegeplanTmp = (System.Guid)CurTerminRowÜbergabe.IDPflegeplan;
                        p = new PMDS.BusinessLogic.PflegePlan(IDAufenthaltTmp);
                    }
                }

                if (p != null)
                {
                    PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow row = p.ReadOnce(IDPflegeplanTmp);
                    if (row.IsIDLinkDokumentNull())
                    {
                        this.uDropDownDrucken.CloseUp();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zu dieser Intervention ist kein Pflegestandard hinterlegt!", "Pflegestandard drucken");
                        return Guid.Empty;
                    }
                    else
                    {
                        return row.IDLinkDokument;
                    } 
                }
                return System.Guid.Empty;
            }
        }
       
        public bool rowSelected(bool withMsgBox )
        {
            try
            {
                if (this.dgTermine.ActiveRow != null)
                {
                    return true;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Auswahl Termin");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.rowSelected: " + ex.ToString());
            }
        }
        public bool IsPatientSelected(bool withMsgBox)
        {
            try
            {
                if (this.IDPatient != null && this.IDPatient != System.Guid.Empty)
                {
                    return true;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Klienten ausgewählt!", "Auswahl");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucTermineEx.IsPatientSelected: " + ex.ToString());
            }
        }
        


        private void btnPrintTermine_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.uOptSetDruckauswahl.Value.ToString() == "I")
                {
                    this.PrintTermine(true);
                }
                else if (this.uOptSetDruckauswahl.Value.ToString() == "INoVz")
                {
                    this.PrintTermine(false);
                }
                else if (this.uOptSetDruckauswahl.Value.ToString() == "PS")
                {
                    if (!this.IsPatientSelected(true)) return;
                    if (!this.rowSelected(true)) return;

                    if (this.CurrentIDLinkDokument != null)
                    {
                        if (this.CurrentIDLinkDokument != Guid.Empty)
                        {
                            GuiAction.ShowLinkDokument(this.CurrentIDLinkDokument);
                        }
                    }      
                }
                else if (this.uOptSetDruckauswahl.Value.ToString() == "VO")
                {
                    if (!IsPatientSelected(true)) return;
                    if (!this.rowSelected(true)) return;

                    System.Guid IDPflegeplanTmp = System.Guid.Empty;
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (this.CheckPEHasIDPflegeplan(base.CurTerminRowIntervention, null))
                        {
                            if (!PMDS.Global.ENV.lic_VO)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Funktion noch nicht fertig! (In Entwicklung)", "", MessageBoxButtons.OK);
                                return;
                            }

                            PMDS.GUI.Verordnungen.frmVOErfassen frmVOErfassen1 = new Verordnungen.frmVOErfassen();
                            frmVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow, true, false, null);
                            frmVOErfassen1.ucVOErfassen1.search2(base.CurTerminRowIntervention.IDAufenthalt, base.CurTerminRowIntervention.IDPflegeplan, null, null);
                            frmVOErfassen1.ShowDialog(this);
                            if (!frmVOErfassen1.ucVOErfassen1.abort)
                            {
                                
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("btnPrintTermine_Click: Print Verordnungen not allowed for Übergabe!");
                    }

                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        private void btnNeuLaden_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.quickFilterButtons1.drawButtons(this.dgTermine, this, ref  this.UITypeTermine);
                bool LayoutFound = false;
                PMDS.Global.db.ERSystem.dsTermine ds = new Global.db.ERSystem.dsTermine();
                base.getTermine(this.MainWindow.UITypeTermine, ref LayoutFound, true);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSonderterminBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsPatientSelected(true)) return;
                if (!this.rowSelected(true)) return;

                //ID des Benutzer suchen, der den Termin angelegt hat und dessen Berufsgruppe prüfen
                Benutzer benErstellt = new Benutzer(CurTerminRowIntervention.IDBenutzer_Erstellt);
                if (PMDSBusiness1.UserCanSignInit(benErstellt.IDBerufsstand, null, null, null))
                {
                    System.Guid IDPflegeplanTmp = System.Guid.Empty;
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (this.CheckPEHasIDPflegeplan(base.CurTerminRowIntervention, null))
                        {
                            IDPflegeplanTmp = CurTerminRowIntervention.IDPflegeplan;
                            GuiAction.EditTermin(this.IDAufenthalt, IDPflegeplanTmp, true, (Form)GuiWorkflow.mainWindow, this.dgTermine.ActiveRow, this.imageList1.Images[2], this.ucSiteMapTermine1);
                        }
                    }
                    else
                    {
                        if (this.CheckPEHasIDPflegeplan(null, CurTerminRowÜbergabe))
                        {
                            IDPflegeplanTmp = (System.Guid)CurTerminRowÜbergabe.IDPflegeplan;
                            GuiAction.EditTermin(this.IDAufenthalt, IDPflegeplanTmp, true, (Form)GuiWorkflow.mainWindow, this.dgTermine.ActiveRow, this.imageList1.Images[2], this.ucSiteMapTermine1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public bool CheckPEHasIDPflegeplan(PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention,
                                           PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow rÜbergabe)
        {
            try
            {
                if (rIntervention != null)
                {
                    return true;
                }
                else if (rÜbergabe != null)
                {
                    if (rÜbergabe.IsIDPflegeplanNull())
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Markierte Zeile ist kein Pflegeplan!", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("CheckPEHasIDPflegeplan: rIntervention==null and rÜbergabe==null not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("CheckPEHasIDPflegeplan: " + ex.ToString());
            }
        }
      

        private void btnSonderterminLöschen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsPatientSelected(true)) return;
                if (!this.rowSelected(true)) return;

                //ID des Benutzer suchen, der den Termin angelegt hat und dessen Berufsgruppe prüfen
                Benutzer benErstellt = new Benutzer(CurTerminRowIntervention.IDBenutzer_Erstellt);
                if (PMDSBusiness1.UserCanSignInit(benErstellt.IDBerufsstand, null, null, null))
                {
                    System.Guid IDPflegeplanTmp = System.Guid.Empty;
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (this.CheckPEHasIDPflegeplan(base.CurTerminRowIntervention, null))
                        {
                            IDPflegeplanTmp = CurTerminRowIntervention.IDPflegeplan;
                            if (GuiAction.DeleteTermin(this.IDAufenthalt, IDPflegeplanTmp, true))
                            {
                                this.ucSiteMapTermine1.RefreshTermin(false);
                            }
                        }
                    }
                    else
                    {
                        if (this.CheckPEHasIDPflegeplan(null, CurTerminRowÜbergabe))
                        {
                            IDPflegeplanTmp = (System.Guid)CurTerminRowÜbergabe.IDPflegeplan;
                            if (GuiAction.DeleteTermin(this.IDAufenthalt, IDPflegeplanTmp, true))
                            {
                                this.ucSiteMapTermine1.RefreshTermin(false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSonderterminBeenden_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsPatientSelected(true)) return;
                if (!this.rowSelected(true)) return;

                //ID des Benutzer suchen, der den Termin angelegt hat und dessen Berufsgruppe prüfen
                Benutzer benErstellt = new Benutzer(CurTerminRowIntervention.IDBenutzer_Erstellt);
                if (PMDSBusiness1.UserCanSignInit(benErstellt.IDBerufsstand, null, null, null))
                {
                    System.Guid IDPflegeplanTmp = System.Guid.Empty;
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (this.CheckPEHasIDPflegeplan(base.CurTerminRowIntervention, null))
                        {
                            if (GuiAction.EndTermin(this.IDAufenthalt, base.CurTerminRowIntervention.IDPflegeplan, true))
                            {
                                this.ucSiteMapTermine1.RefreshTermin(false);
                            }
                        }
                    }
                    else
                    {
                        if (this.CheckPEHasIDPflegeplan(null, CurTerminRowÜbergabe))
                        {
                            if (GuiAction.EndTermin(this.IDAufenthalt, (System.Guid)base.CurTerminRowÜbergabe.IDPflegeplan, true))
                            {
                                this.ucSiteMapTermine1.RefreshTermin(false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSonderterminErstellen_Click(object sender, EventArgs e)
        {
           try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (this.UITypeTermine == eUITypeTermine.Dekurs && this.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    //Guid IDPatient = ENV.CurrentIDPatient;
                    //Guid IDAufenthalt = ENV.IDAUFENTHALT;
                    if (!this.IsPatientSelected(true)) return;
                    GuiAction.InsertTermin(this.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, this.ucSiteMapTermine1, null, null);
                }
                else
                {
                    if (!this.IsPatientSelected(true)) return;
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        GuiAction.InsertTermin(this.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, this.ucSiteMapTermine1, null, null);
                    }
                    else
                    {
                        GuiAction.InsertTermin(this.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, this.ucSiteMapTermine1, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSchnellrückmeldung_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();

                this.SELECTED_ROWS(ref lstInterventionen, ref lstÜbergabe);

                if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (lstInterventionen.Count == 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einträge ausgewählt!", "Schnellrückmeldung");
                        return;
                    }
                    else
                    {
                        bool SchnellrückmeldungAsProcessBack = false;
                        if (GuiAction.PatientRueckmeldungLine(lstInterventionen, ref this.ucSiteMapTermine1, ref SchnellrückmeldungAsProcessBack, this.Left, this.Top, this.Width, this.Height, this))
                        {
                            //this.btnAlleAuswählen.Tag = "0";
                            //this.btnAlleAuswählen.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                            //base.SetSelection(false);
                        }
                    }
                }
                else if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs ||
                            this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Übergabe)
                {
                    //lthxy
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnUngeplMaßnahmenRückemelden_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsPatientSelected(true)) return;
                if (GuiAction.PatientMassnahme(this.IDPatient, eDekursherkunft.UngeplanteMassnahmeRückmeldenAusIntervention, null, "Dekurs"))
                {
                    this.ucSiteMapTermine1.RefreshTermin(true);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnBedarfsmedikation_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsPatientSelected(true)) return;
                if (GuiAction.PatientMassnahme(this.IDPatient, true, eDekursherkunft.BedarfsmedikamentationAusIntervention, null, "Dekurs"))
                {
                    this.ucSiteMapTermine1.RefreshTermin(true);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default ;
            }
        }
        private void btnFreierBericht_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!this.IsPatientSelected(true)) return;
                this.doDekurs(PMDS.Global.eDekursherkunft.DekursAusIntervention, false, false, "");

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnFreierBericht2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.UITypeTermine == eUITypeTermine.Übergabe)
                {
                    this.doDekurs(PMDS.Global.eDekursherkunft.DekursAusÜbergabe, false, false, "");
                }
                else if (this.UITypeTermine == eUITypeTermine.Dekurs)
                {
                    this.doDekurs(PMDS.Global.eDekursherkunft.DekursAusMitBereich, false, false, "");
                }
                else 
                {
                    throw new Exception("btnFreierBericht2_Click: this.UITypeTermine '" + this.UITypeTermine .ToString() + "' not allowed!");
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void doDekurs(eDekursherkunft Dekursherkunft, bool IsEntwurf, bool ErstellenAs, string txtText)
        {
            try
            {
                if (this.UITypeTermine == eUITypeTermine.Dekurs && this.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    Guid IDpatient = this.IDPatient;
                    if (IDpatient == System.Guid.Empty)
                    {
                        return;
                    }
                    if (GuiAction.PatientVermerk(IDpatient, null, Dekursherkunft, txtText, false, IsEntwurf, null, !IsEntwurf, "Fct. ucTermineEx.doDekurs(Bereichsansicht)", ErstellenAs, ""))
                    {
                        if (!IsEntwurf)
                        {
                            this.ucSiteMapTermine1.RefreshTermin(true);
                        }
                    }
                }
                else
                {
                    if (!IsPatientSelected(true)) return;
                    if (GuiAction.PatientVermerk(this.IDPatient, null, Dekursherkunft, txtText, false, IsEntwurf, null, !IsEntwurf, "Fct. ucTermineEx.doDekurs(Einzelansicht)", ErstellenAs, ""))
                    {
                        this.ucSiteMapTermine1.RefreshTermin(true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doDekurs: " + ex.ToString());
            }
        }

        public void quickFilterButtons1_QuickFilterButtonClick(QuickFilterButton bQuick)
        {

        }

        private void uButtonAlleAuswählen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.btnAlleAuswählen.Tag.ToString() == "0")
                {
                    base.SetSelection(true);
                    this.btnAlleAuswählen.Tag = "1";
                    this.btnAlleAuswählen.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");
                }
                else if (this.btnAlleAuswählen.Tag.ToString() == "1")
                {
                    base.SetSelection(false);
                    this.btnAlleAuswählen.Tag = "0";
                    this.btnAlleAuswählen.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                }
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void SetControlNameGrid(ref PMDS.Global.eUITypeTermine UITypeTermine)
        {
            try
            {
                string NameDefaultLayout = "";
                string GridNamePrefix = "";
                if (this.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    GridNamePrefix = "Einzel";
                }
                else if (this.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    GridNamePrefix = "Bereich";
                }
                else
                {
                    throw new Exception("ucTermineEx.SetControlNameGrid: this.ucSiteMapTermine1._ansichtmodi '" + this.ucSiteMapTermine1._ansichtmodi.ToString() + "' not allowed!");
                }

                if (UITypeTermine == eUITypeTermine.Interventionen)
                {
                    this.dgTermine.Name = "gridIntervention" + GridNamePrefix;
                    NameDefaultLayout = "Intervention";
                }
                else if (UITypeTermine == eUITypeTermine.Übergabe)
                {
                    this.dgTermine.Name = "gridÜbergabe" + GridNamePrefix;
                    NameDefaultLayout = "Übergabe";
                }
                else if (UITypeTermine == eUITypeTermine.Dekurs)
                {
                    this.dgTermine.Name = "gridDekurs" + GridNamePrefix;
                    NameDefaultLayout = "Dekurs";
                }
                else
                {
                    throw new Exception("SetControlNameGrid: UITypeTermine '" + UITypeTermine.ToString() + "' not allowed!!");
                }
                
                QS2.Desktop.ControlManagment.BaseGrid baseGrid = (QS2.Desktop.ControlManagment.BaseGrid)this.dgTermine;
                string defaultLayoutName = "Standardfilter" + " " + NameDefaultLayout.Trim();
                baseGrid.doBaseElements1.runControlManagmentBaseGridManual(this.dgTermine, defaultLayoutName);

                baseGrid.doBaseElements1.InfoControl.SaveLastQuickfilter = true;
                baseGrid.doBaseElements1.InfoControl.dGetLastClickedQuickfilter += new QS2.Desktop.ControlManagment.doBaseElements.cInfoControl.GetLastClickedQuickfilter(this.MainWindow.ucSiteMapTermine1.getLastClickedQuickfilter);
                baseGrid.doBaseElements1.ControlManagment1.delOnSaveLayoutClick += new QS2.Desktop.ControlManagment.ControlManagment.onSaveLayoutClick(this.quickFilterButtons1.OnLayoutSaved);

            }
			catch(Exception ex )
			{
                throw new Exception("ucTermineEx.SetControlNameGrid: " + ex.ToString());
			}
        }

        private void quickFilterButtons1_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    if (this.quickFilterButtons1.RefreshButtons)
                    {
                        this.quickFilterButtons1.ReposButtons(ENV.LastSizeMainWindow.Width);
                        this.quickFilterButtons1.RefreshButtons = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void openSqlCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                frmProtokoll frm = new frmProtokoll();
                frm.calc = false;
                frm.ucProtokoll1.start(QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine - Sql-Command"), false, "", "", false, false);
                //frm.ucProtokoll1.showProtDetail(null, true);
                frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine - Sql-Command");
                frm.ucProtokoll1.txtProtokoll.Text = this._SqlCommand;
                frm.Show();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void standardlayoutAnwendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                bool LayoutFound = false;

                this.quickFilterButtons1.SetButtonClickedColor(System.Guid.NewGuid());
                
                this.MainWindow.quickFilterButtons1.QButtonClicked = null;
                this.getTermine(this.MainWindow.UITypeTermine, ref LayoutFound, false);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        private void uDropDownDrucken_Click(object sender, EventArgs e)
        {

        }
        public void updateNächstesDatum(PMDS.DB.PMDSBusiness.eModeUpdateNächstesDatum ModeUpdateNächstesDatum)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie diese Operation wirklich ausführen?", "'Nächstes-Datum' updaten für alle Interventionen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    int iCounter = 0;
                    string prot = "";
                    PMDS.Global.db.ERSystem.FrmStatusAndProtocoll frmStatus = new Global.db.ERSystem.FrmStatusAndProtocoll();

                    PMDSBusiness1.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb(ref iCounter, ref prot, frmStatus, ref ModeUpdateNächstesDatum, System.Guid.NewGuid());
                    //PMDS.Global.frmProtokoll frm = new frmProtokoll();
                    //frm.calc = false;
                    //frm.ucProtokoll1.start("Termine - Sql-Command", false, "", "", false, false);
                    //frm.Text = "Update Nächstes Datum";
                    //frm.ucProtokoll1.txtProtokoll.Text = prot;
                    //frm.Show();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void gesamteDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.updateNächstesDatum(DB.PMDSBusiness.eModeUpdateNächstesDatum.GesamteDatenbank);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void nufFürDieAbteilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.updateNächstesDatum(DB.PMDSBusiness.eModeUpdateNächstesDatum.Abteilung);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void nurFürDenKlientenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.updateNächstesDatum(DB.PMDSBusiness.eModeUpdateNächstesDatum.Klient);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void PDxRückmelden()
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                this.textControl1.Text = "";

                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();
                this.SELECTED_ROWS(ref lstInterventionen, ref lstÜbergabe);

                System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cPMDSList> lstPMDSListAufenthalt = new List<DB.PMDSBusiness.cPMDSList>();
                string sInitText = "PDx Rückmeldung:" + "\r\n";
                if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (lstInterventionen.Count > 0)
                    {
                        if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Einträge wirklich rückmelden?", "PDx rückmelden", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                            {
                                int iCounterAbgezeichnet = 0;
                                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rInterventionen in lstInterventionen)
                                {
                                    PMDS.DB.PMDSBusiness.cPMDSList PMDSEntryActAufenthalt = null;
                                    bool bEntryFound = false;
                                    PMDSBusiness1.SearchInPMDSList(ref lstPMDSListAufenthalt, ref PMDSEntryActAufenthalt, ref bEntryFound, rInterventionen.IDAufenthalt,
                                                                    ref sInitText);

                                    System.Collections.Generic.List<Guid> lstIDPdxUnique = new List<Guid>();
                                    this.getUniqueIDPDx(ref lstIDPdxUnique, rInterventionen.lstIDPDx.Trim(), db, rInterventionen, ref iCounterAbgezeichnet);
                                    foreach (Guid IDPDx in lstIDPdxUnique)
                                    {
                                        PMDS.db.Entities.PDX rPDX = this.PMDSBusiness1.getPDX(IDPDx, db);
                                        if (!PMDSEntryActAufenthalt.sText.Trim().ToLower().Contains(rPDX.Klartext.Trim().ToLower()))
                                        {
                                            PMDSEntryActAufenthalt.sText += "" + rPDX.Klartext.Trim() + "\r\n"; 
                                        }
                                    }
                                }
                                foreach (PMDS.DB.PMDSBusiness.cPMDSList PMDSEntryInListFound in lstPMDSListAufenthalt)
                                {
                                    PMDS.db.Entities.Benutzer rUsr = this.PMDSBusiness1.LogggedOnUser();
                                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.PMDSBusiness1.getAufenthalt(PMDSEntryInListFound.IDAufenthalt);
                                    PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.PMDSBusiness1.AddPflegeeintrag(db, PMDSEntryInListFound.sText.Trim(), DateTime.Now, null, rAufenthalt.IDBereich,
                                                                                PMDSEntryInListFound.IDAufenthalt, null, PflegeEintragTyp.MASSNAHME,
                                                                                null, rAufenthalt.IDAbteilung, "PDx Rückmeldung");
                                }

//                              rPflegeEintrag.PflegeplanText = "PDX Rückmeldung";
//                              rPflegeEintrag.Text = sText.Trim();

                                db.SaveChanges();
                                this.ucSiteMapTermine1.RefreshTermin(true);

                                if (ENV.adminSecure)
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterAbgezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" PDx-Einträge wurden rückgemeldet!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PDX Rückmeldung"), MessageBoxButtons.OK, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    throw new Exception("PDxRückmelden: this.MainWindow.UITypeTermine '" + this.MainWindow.UITypeTermine.ToString()+ "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PDxRückmelden: " + ex.ToString());
            }
        }
        public void getUniqueIDPDx(ref System.Collections.Generic.List<Guid> lstIDPdxUnique, string lstIDPDx,
                                    PMDS.db.Entities.ERModellPMDSEntities db,
                                    PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rInterventionen, ref int iCounterAbgezeichnet)
        {
            try
            {
                System.Collections.Generic.List<string> lstIDPDxNew = qs2.core.generic.readStrVariables(lstIDPDx.Trim());
                if (lstIDPDxNew.Count > 0)
                {
                    foreach (string sIDPDx in lstIDPDxNew)
                    {
                        bool IDPDxIsInList = false;
                        Guid gNewIDPDx = new Guid(sIDPDx.Trim());
                        foreach(Guid IDPDxInList in lstIDPdxUnique)
                        {
                            if (IDPDxInList.Equals(gNewIDPDx))
                            {
                                IDPDxIsInList = true;
                            }
                        }
                        if (!IDPDxIsInList)
                        {
                            lstIDPdxUnique.Add(gNewIDPDx);
                            //this.PMDSBusiness1.EndEintrag(rInterventionen.IDEintrag, db);
                            iCounterAbgezeichnet += 1;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("getUniqueIDPDx: " + ex.ToString());
            }
        }

        public void ReadInEditor()
        {
            try
            {
                byte[] b = null;
                string sLine = "____________________________________________________________________________________";
                this.textControl1.Text = "";

                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();
                this.SELECTED_ROWS(ref lstInterventionen, ref lstÜbergabe);

                this.textControl1.Text = "";
                this.doEditor1.showText(sLine.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref b, ref b);
                this.textControl1.ViewMode = TXTextControl.ViewMode.PageView;

                string LineRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControl1);
                string LinePlain = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControl1);

                if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (lstInterventionen.Count > 0)
                    {
                        QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                        frmEditor.fFelderEinAus = false;
                        frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                        frmEditor.ContTxtEditor1.LinealeOnOff(false);
                        frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.ReadAndSelect;
                        frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                        frmEditor.Show();
                        frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                        Application.DoEvents();

                        foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rInterventionen in lstInterventionen)
                        {
                            string infoRow = "";
                            infoRow = rInterventionen.Klient.Trim() + ", " + rInterventionen.Maßnahme.Trim() + "\r\n";

                            int Position1 = frmEditor.ContTxtEditor1.textControl1.InputPosition.TextPosition;
                            this.doEditor1.appendText2(infoRow.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                            this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                            frmEditor.ContTxtEditor1.textControl1.Select(Position1, frmEditor.ContTxtEditor1.textControl1.Text.Length - Position1);
                            frmEditor.ContTxtEditor1.textControl1.Selection.FontSize = 10 * 20;
                            frmEditor.ContTxtEditor1.textControl1.Selection.FontName = "Arial";
                            frmEditor.ContTxtEditor1.textControl1.Selection.ForeColor = System.Drawing.Color.RoyalBlue;
                            frmEditor.ContTxtEditor1.textControl1.Selection.Bold = true;

                            infoRow = "";
                            //infoRow = rÜbergabe.Zeitpunkt + "\r\n";        //.ToString("dd.mm.yyyy")
                            //infoRow += "\r\n";

                            int Position2 = frmEditor.ContTxtEditor1.textControl1.InputPosition.TextPosition;
                            this.doEditor1.appendText2(infoRow.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                            this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                            this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                            frmEditor.ContTxtEditor1.textControl1.Select(Position2, frmEditor.ContTxtEditor1.textControl1.Text.Length - Position2);
                            frmEditor.ContTxtEditor1.textControl1.Selection.FontSize = 9 * 20;
                            frmEditor.ContTxtEditor1.textControl1.Selection.FontName = "Arial";
                            frmEditor.ContTxtEditor1.textControl1.Selection.ForeColor = System.Drawing.Color.Black;
                            frmEditor.ContTxtEditor1.textControl1.Selection.Bold = false;

                            this.textControl1.Text = "";
                            //this.ReadInEditorDoLine("", "", ref infoRow, ref sLine, ref  frmEditor.ContTxtEditor1.textControl1,
                            //                        ref LineRtf, ref LinePlain);
                            this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                            this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);

                        }
                        frmEditor.ContTxtEditor1.LinealeOnOff(false);
                        frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen");
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (lstÜbergabe.Count > 0)
                    {
                        sLine = "";
                        LineRtf = "";
                        LinePlain = "";
                        QS2.Desktop.Txteditor.frmTxtEditorField frmEditor = null;
                        this.PMDSBusinessUI1.initFormDekurse(ref frmEditor, ref this.textControl1, ref sLine, ref LineRtf, ref LinePlain);

                        foreach (PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow rÜbergabe in lstÜbergabe)
                        {
                            string infoRow = rÜbergabe.Klient.Trim() + ", " + rÜbergabe.Maßnahme.Trim() + "\r\n";
                            this.PMDSBusinessUI1.printDekurse(ref frmEditor, ref this.textControl1, rÜbergabe.DekursRtf.Trim(), rÜbergabe.Dekurs.Trim(), rÜbergabe.Benutzer.Trim(),
                                                                rÜbergabe.Zusatzwerte.Trim(), rÜbergabe.Maßnahme.Trim(), rÜbergabe.Zeitpunkt.Trim(), 
                                                                ref infoRow, ref sLine, ref LineRtf, ref LinePlain);

                        }
                        //frmEditor.ContTxtEditor1.LinealeOnOff(false);
                        if (this.MainWindow.UITypeTermine == eUITypeTermine.Übergabe)
                        {
                            frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Übergaben");
                        }
                        else if (this.MainWindow.UITypeTermine == eUITypeTermine.Dekurs)
                        {
                            frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurse");
                        }

                        frmEditor.ContTXTField1.TXTControlField.Selection.Start = 0;
                        frmEditor.ContTXTField1.TXTControlField.Selection.Length = 0;
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ReadInEditor: " + ex.ToString());
            }
        }
        public void ReadInEditorDoLine(string txtRtf, string txtPlain,
                                        ref string InfoRow, ref string sLine, TXTextControl.TextControl textControl1,
                                        ref string LineRtf, ref string LinePlain)
        {
            try
            {

                //this.textControl1.Text = "";
                //this.doEditor1.showText(infoRow.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref b, ref b);
                //string InfoRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControl1);
                //string InfoPlain = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControl1);

                if (txtRtf.Trim() == "")
                {
                    if (txtPlain.Trim() != "")
                    {
                        //this.doEditor1.appendText2(InfoPlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                        //this.doEditor1.appendText2(LinePlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                    }
                }
                else
                {
                    //this.doEditor1.appendText2(InfoRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    try
                    {
                        this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.RichTextFormat); 
                    }
                    catch (Exception ex)
                    {
                        if (txtPlain.Trim() != "")
                        {
                            this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                        else
                        {
                            this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                    }
                    //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                    //this.doEditor1.appendText2(LineRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                }

                int Position2 = textControl1.InputPosition.TextPosition;
                this.doEditor1.appendText2(LinePlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                textControl1.Select(Position2, textControl1.Text.Length - Position2);
                textControl1.Selection.FontSize = 9 * 20;
                textControl1.Selection.FontName = "Arial";
                textControl1.Selection.ForeColor = System.Drawing.Color.Black;
                textControl1.Selection.Bold = false;

            }
            catch (Exception ex)
            {
                throw new Exception("doLineReadEditor: " + ex.ToString());
            }
        }

        public void Gegenzeichnen()
        {
            try
            {
                this.textControl1.Text = "";
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();
                this.SELECTED_ROWS(ref lstInterventionen, ref lstÜbergabe);

                if (this.MainWindow.UITypeTermine == eUITypeTermine.Übergabe || this.MainWindow.UITypeTermine == eUITypeTermine.Dekurs)
                {
                    if (lstÜbergabe.Count > 0)
                    {
                        if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich gegenzeichnen?", "Gegenzeichnen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int iCounterAbgezeichnet = 0;
                            this.PMDSBusiness1.Gegenzeichnen(lstÜbergabe, ref iCounterAbgezeichnet, true, ENV.HasRight(UserRights.AutomatischeArztabrechungseinträge));
                            this.ucSiteMapTermine1.RefreshTermin(true);

                            //if (ENV.adminSecure)
                            //{
                            //    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterAbgezeichnet.ToString() + " Einträge wurden gegengezeichnet!", "Gegenzeichnen", MessageBoxButtons.OK);
                            //}
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    throw new Exception("Gegenzeichnen: this.MainWindow.UITypeTermine '" + this.MainWindow.UITypeTermine .ToString () + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Gegenzeichnen: " + ex.ToString());
            }
        }
        public void doSearchInGrid()
        {
          try
          {
              this.funct1.clearAllFilter(this.dgTermine);
                if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    this.funct1.setFilter(this._ds.vInterventionen.MaßnahmeColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.Anmerkung_und_HinweisColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.LokalisierungColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.KlientColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.AbteilungColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.BereichColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.vonColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vInterventionen.Berufsstand_SollColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                            FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                }
                else
                {
                    this.funct1.setFilter(this._ds.vÜbergabe.KlientColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.MaßnahmeColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.DekursColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.ZusatzwerteColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.BenutzerColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.Berufsstand_IstColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.LokalisierungColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.AbteilungColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this._ds.vÜbergabe.BereichColumn.ColumnName, FilterLogicalOperator.Or, this.txtSearchInGrid.Text.Trim(),
                                        FilterComparisionOperator.Contains, this.dgTermine, this.dgTermine.DisplayLayout.Bands[0].Index);  

                }

          }
          catch (Exception ex)
          {
              throw new Exception("doSearchInGrid: " + ex.ToString());
          }
        }
        private void btnLesenInterventionen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ReadInEditor();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnLesenÜbergabeDekurs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ReadInEditor();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnPDxRückmelden_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.PDxRückmelden();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnGegenzeichnen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Gegenzeichnen();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtSearchInGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.KeyCode == Keys.F3)
                {
                    this.doSearchInGrid();
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOpenBefundIntervention_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.OpenBefund();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOpenBefundÜbergabe_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.OpenBefund();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void OpenBefund()
        {
            try
            {
                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (CurTerminRowIntervention != null)
                    {
                        EDIFact1.openBefund(CurTerminRowIntervention.IDBefund);
                    }
                }
                else
                {
                    if (CurTerminRowÜbergabe != null)
                    {
                        EDIFact1.openBefund(CurTerminRowÜbergabe.IDBefund);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("OpenBefund: " + ex.ToString());
            }
        }

        private void btnDekursEntwurfErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!this.IsPatientSelected(true)) return;
                
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();
                this.SELECTED_ROWS2(ref lstInterventionen, ref lstÜbergabe);

                string txtText = "";
                if (lstInterventionen.Count == 1)
                {
                    PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rvIntervention = lstInterventionen[0];
                    if (rvIntervention.TerminJN == 1)
                    {
                        txtText = rvIntervention.Anmerkung_und_Hinweis.Trim() + "\r\n";
                    }
                }

                //if (this.MainWindow.UITypeTermine == eUITypeTermine.Übergabe || this.MainWindow.UITypeTermine == eUITypeTermine.Dekurs)
                //{
                //}

                this.doDekurs(PMDS.Global.eDekursherkunft.DekursAusIntervention, true, false, txtText);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnDekursEntwürfeListe_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (ucTermineEx.frmDekurseListeDistinct == null)
                {
                    ucTermineEx.frmDekurseListeDistinct = new GUI.Main.frmDekurseListe();
                    ucTermineEx.frmDekurseListeDistinct.initControl(GUI.Main.ucDekurseListe.eTypeUI.All, null);
                }
                ucTermineEx.frmDekurseListeDistinct.ucDekurseListe1.loadData();
                ucTermineEx.frmDekurseListeDistinct.TopMost = true;
                ucTermineEx.frmDekurseListeDistinct.Show();
                ucTermineEx.frmDekurseListeDistinct.Visible = true;
                ucTermineEx.frmDekurseListeDistinct.TopMost = false;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ultraPopupControlContainerDekursEntwürfe_Opened(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.countAnzEntwürfe();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void countAnzEntwürfe()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = this.b.getPflegeEintragEntwürf(this.b.LogggedOnUser(db).ID, db);
                    this.btnDekursEntwürfeListe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste") + " (" + tPflegeEintragEntwurf.Count().ToString() + ")";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("countAnzEntwürfe: " + ex.ToString());
            }
        }

        private void btnDekursEntwurfErstellenAs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!this.IsPatientSelected(true)) return;

                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe = new List<Global.db.ERSystem.dsTermine.vÜbergabeRow>();
                this.SELECTED_ROWS2(ref lstInterventionen, ref lstÜbergabe);

                string txtText = "";
                if (lstInterventionen.Count == 1)
                {
                    PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rvIntervention = lstInterventionen[0];
                    if (rvIntervention.TerminJN == 1)
                    {
                        txtText = rvIntervention.Anmerkung_und_Hinweis.Trim() + "\r\n";
                    }
                }

                this.doDekurs(PMDS.Global.eDekursherkunft.DekursAusIntervention, true, true, txtText);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgTermine_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell && e.Cell.Row.IsGroupByRow)
                {

                }
                else
                {
                    e.Cell.Row.Selected = true;
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        private void ultraDropDownButtonTermine_Click(object sender, EventArgs e)
        {

        }
    }




    public class TerminExSettings
	{
        public bool ZeitraumJN = false;
        public EFilter Mode = EFilter.INTERVALL;
		public DateTime Fromxy	= DateTime.Now.Date;
		public DateTime To		= DateTime.Now.Date.AddDays(1);

		// FilterPicker
		public Guid IDMassnahme	= Guid.Empty;

        public bool BezugJN = false;
		public Guid IDBezug		= Guid.Empty;

		public Guid[] Massnahmen = {};
		public int	AbzeichnenJN	= -1;
        
        public bool BerufsstandJN = false;
        public List<Guid> Berufsstand =  new List<Guid>();

        public bool WichtigFürJN = false;
        public List<Guid> WichtigFür = new List<Guid>();

        public int ShowCC = -1;

        public bool PlanungstypenJN = false;
        public List<int> Planungstypen = new List<int>();

        public bool ZusatzwerteJN = false;
        public List<string> Zusatzwerte = new List<string>();

        public int Abzeichnen = -1;

        public bool ZeitbezugJN = false;
        public List<int> Zeitbezug = new List<int>();

        public bool HerkunftPlanungsEintragJN = false;
        public List<int> HerkunftPlanungsEintrag = new List<int>();

        public bool ZeitraumFixierenJN = false;


        public  TerminExSettings()
        {
            Fromxy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        }

	}
}
