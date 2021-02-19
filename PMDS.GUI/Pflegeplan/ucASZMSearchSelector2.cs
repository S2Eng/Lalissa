using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using PMDS.Data.Global;
using PMDS.GUI.BaseControls;
using PMDS.Data.Patient;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{

	public class ucASZMSearchSelector2 : QS2.Desktop.ControlManagment.BaseControl
	{

        private PMDS.BusinessLogic.PflegePlan _PflegePlan; //Neu nach 07.05.2007 MDA
        private bool                    _RefreshFromAnanemnese = false;
        private bool                    _ASZSearch = false;
        private PDxSelectionArgs[]        _pdxSeArgs;
        private PDx						_PDx;
        private PDXAnamnese             _pdxAnamnese;

		private bool                    _updateinprogress = false;
		private Katalog					_Katalog = new Katalog('X');
		private Guid                    _SelectedPDX = Guid.Empty;
        private string                  _abteilungText = ""; //Neu nach 16.05.2007: Abteilungsbezeichnung

        public event ASZMSelectedDelegate ASZMSelected;
        private dsPDxEintrag dsPDxEintragGenerell;
        private dsPDxEintrag dsPDxEintragSpecific;
        private dsIDTextBezeichnung dsPdxBezeichnung;
        private QS2.Desktop.ControlManagment.BasePanel pnlTop;
        private QS2.Desktop.ControlManagment.BaseTabControl tabTop10;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private QS2.Desktop.ControlManagment.BaseLabel lblAllgeFavoriten;
        private UltraCombo cbTop10Allgemein;
        private QS2.Desktop.ControlManagment.BaseLabel lblFavoriten;
        private UltraCombo cbTop10;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin groupBox1;
        private QS2.Desktop.ControlManagment.BaseOptionSet osSearchIn;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbSearch;
        private QS2.Desktop.ControlManagment.BaseOptionSet osVerknuepfung;
        private Splitter splitter1;
        private QS2.Desktop.ControlManagment.BaseTabControl tabASZM;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpFilter;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbA;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbS;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbZ;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbM;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private ucASZMSelectorTreeView tvGenerell;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectNo;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectAll;
        private QS2.Desktop.ControlManagment.BaseButton btnTransferDefault;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private ucASZMSelectorTreeView tvSpecific;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectNoSpecific;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectAllSpecific;
        private QS2.Desktop.ControlManagment.BaseButton btnTransferSpecific;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegeamnesen;
        private UltraCombo cbAnamnesen;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private QS2.Desktop.ControlManagment.BaseLableWin lblAndereAuswahlTreffen;
        private QS2.Desktop.ControlManagment.BaseLableWin lblKeineEinträgeGefunden;
        private QS2.Desktop.ControlManagment.BaseLabel lblLegende;
        private UltraPictureBox pbHaken;
        private QS2.Desktop.ControlManagment.BasePanel pnlLegende;
        private QS2.Desktop.ControlManagment.BaseButton btnAddMissingASZM;
        private IContainer components;

        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucASZMSearchSelector2()
		{
			InitializeComponent();
			if(System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
				return;

            InitializeComboBoxDesigns();
            ShowHideTabs();
        }

        //Neu nach 07.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegePlan auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.BusinessLogic.PflegePlan PflegePlan
        {
            get { return _PflegePlan; }
            set 
            { 
                _PflegePlan = value;
                tvGenerell.PflegePlan = value;
                tvSpecific.PflegePlan = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ASZSearch
        {
            get { return _ASZSearch; }
            set{_ASZSearch = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs[] PDX_SELARGS
        {
            get { return _pdxSeArgs; }
            set { _pdxSeArgs = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das aussehen der Comboboxen initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitializeComboBoxDesigns()
        {
            UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("IDTextBezeichnung", -1);
            ultraGridBand1.Columns.Add(ultraGridColumn1);
            ultraGridBand1.Columns.Add(ultraGridColumn2);
            ultraGridBand1.Columns.Add(ultraGridColumn3);
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Hidden = true;
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            cbTop10.DisplayLayout.BandsSerializer.Add(ultraGridBand1);

            UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            UltraGridBand ultraGridBand11 = new Infragistics.Win.UltraWinGrid.UltraGridBand("IDTextBezeichnung", -1);
            ultraGridBand11.Columns.Add(ultraGridColumn11);
            ultraGridBand11.Columns.Add(ultraGridColumn12);
            ultraGridBand11.Columns.Add(ultraGridColumn13);
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Hidden = true;
            ultraGridBand11.ColHeadersVisible = false;
            ultraGridBand11.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            cbTop10Allgemein.DisplayLayout.BandsSerializer.Add(ultraGridBand11);

            UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            UltraGridBand ultraGridBand111 = new Infragistics.Win.UltraWinGrid.UltraGridBand("IDTextBezeichnung", -1);
            ultraGridBand111.Columns.Add(ultraGridColumn111);
            ultraGridBand111.Columns.Add(ultraGridColumn112);
            ultraGridBand111.Columns.Add(ultraGridColumn113);
            ultraGridColumn112.Hidden = true;
            ultraGridColumn113.Hidden = true;
            ultraGridBand111.ColHeadersVisible = false;
            ultraGridBand111.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            cbAnamnesen.DisplayLayout.BandsSerializer.Add(ultraGridBand111);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Dialog so preparieren dass schnell nach einer Massnahme gesucht werden kann
        /// </summary>
        //----------------------------------------------------------------------------
        public void SwitchToMassnahmeSearch()
        {
            _updateinprogress = true;
            tabTop10.SelectedTab = tabTop10.Tabs[1];
            cbA.Checked = false;
            cbS.Checked = false;
            cbZ.Checked = false;
            cbM.Checked = true;
            SetFocusToSearch();
            osSearchIn.CheckedIndex = 1;        // zugeordnete ASZM
            
            _updateinprogress = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Dialog so preparieren dass schnell nach einer ASZ gesucht werden kann
        /// </summary>
        //----------------------------------------------------------------------------
        public void SwitchToASZSearch()
        {
            _updateinprogress = true;
            tabTop10.SelectedTab = tabTop10.Tabs[1];
            cbA.Checked = true;
            cbS.Checked = true;
            cbZ.Checked = true;
            cbM.Checked = false;
            SetFocusToSearch();
            osSearchIn.CheckedIndex = 1;        // zugeordnete ASZM
            _updateinprogress = false;
        }

        public void SetFocusToSearch()
        {

            tabTop10.Focus();
            ultraTabPageControl3.Focus();
            tbSearch.Focus();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktualisiert den INhalt der Combo
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshTop10Combo() 
		{
            //cbTop10.DataSource = _PDx.GetAllPDxGruppeFromAbteilung(EnvPflegePlan.CurrentKlientenAbteilung, PFLEGEPLANMODUS == PflegePlanModus.Normal);
            //cbTop10Allgemein.DataSource = _PDx.GetAllPDxGruppeFromAbteilung(Guid.Empty,PFLEGEPLANMODUS == PflegePlanModus.Normal);        // Generelle Abteilung

            //cbAnamnesen.DataSource = _pdxAnamnese.GetAllAnamnesen(ENV.CurrentIDPatient);
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktualisiert die PDx Liste gemäß der Top10 auswahl
		/// Dabei werden alle gefundenen PDX markiert und damit alle ASZM zu allen Pdx
		/// dargestellt.
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshPDxList()
		{
            List<PDxSelectionArgs> listSpecific = new List<PDxSelectionArgs>();
            List<PDxSelectionArgs> listGenerell = new List<PDxSelectionArgs>();
            
            InsertListPDX(listSpecific, listGenerell);

            tvSpecific.ListIDPDX = null;
            tvSpecific.PDX_SELARGS = listSpecific.ToArray();
            tvSpecific.SelectAllTreeNodes(false);

            tvGenerell.ListIDPDX = null;
            tvGenerell.PDX_SELARGS = listGenerell.ToArray();
            tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());//Neu nach 18.05.2007 MDA
            tvGenerell.SelectAllTreeNodes(false);

            ShowHideTabs();
        }

        private void InsertListPDX(List<PDxSelectionArgs> listSpecific, List<PDxSelectionArgs> listGenerell)
        {
            PDxSelectionArgs specificPdxArg, generellPdxArg;

            foreach (dsIDTextBezeichnung._TableRow r in dsPdxBezeichnung._Table)
            {
                specificPdxArg = new PDxSelectionArgs();
                specificPdxArg.IDPDX = r.ID;
                specificPdxArg.ARGS = GetASZMArgs(r.ID, EnvPflegePlan.CurrentKlientenAbteilung, false);
                listSpecific.Add(specificPdxArg);

                generellPdxArg = new PDxSelectionArgs();
                generellPdxArg.IDPDX = r.ID;
                generellPdxArg.ARGS = GetASZMArgs(r.ID, Guid.Empty, true);
                listGenerell.Add(generellPdxArg);
            }

            SetLokalisierung(listSpecific);
            SetLokalisierung(listGenerell);
        }

        private void SetLokalisierung(List<PDxSelectionArgs> list)
        {
            if (PDX_SELARGS != null)
            {
                foreach (PDxSelectionArgs pdxARG in PDX_SELARGS)
                {
                    foreach (PDxSelectionArgs pdx in list)
                    {
                        if (pdxARG.IDPDX == pdx.IDPDX)
                        {
                            if (pdxARG.Lokalisierung != null)
                            {
                                pdx.LokalisierungJN = pdxARG.LokalisierungJN;
                                pdx.Lokalisierung = pdxARG.Lokalisierung;
                            }

                            if (pdxARG.LokalisierungSeite != null)
                                pdx.LokalisierungSeite = pdxARG.LokalisierungSeite;

                            if (pdx.ARGS != null)
                            {
                                foreach (ASZMSelectionArgs args in pdx.ARGS)
                                {
                                    if (pdxARG.Lokalisierung != null)
                                    {
                                        args.LokalisierungJN = pdxARG.LokalisierungJN;
                                        args.Lokalisierung = pdxARG.Lokalisierung;
                                    }

                                    if (pdxARG.LokalisierungSeite != null)
                                        args.LokalisierungSeite = pdxARG.LokalisierungSeite;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Gibt alle ASZM's die zu eine bestimmte PDx gehören
        /// </summary>
        //----------------------------------------------------------------------------
        private ASZMSelectionArgs[] GetASZMArgs(Guid idPdx, Guid idAbteilung, bool bGeneral)
        {
            ASZMSelectionArgs[] args = null;
            ArrayList list = new ArrayList();
            dsPDxEintrag.PDXEintragDataTable t1 = _PDx.GetZuordnungen(idPdx, idAbteilung);
            ASZMSelectionArgs arg;

            //neu nach 25.06.2007 MDA
            Eintrag eint = new Eintrag();
            dsEintrag.EintragDataTable eintragDataTable;

            foreach (dsPDxEintrag.PDXEintragRow r in t1)
            {
                //neu nach 25.06.2007 MDA: Entfernte Einträge nicht anzeigen.
                eintragDataTable = eint.Read(r.IDEintrag);
                if (eintragDataTable.Count > 0)
                {
                    if (eintragDataTable[0].EntferntJN)
                        continue;
                }

                arg = new ASZMSelectionArgs();
                arg.IDEintrag = r.IDEintrag;

                if (!r.IsIDAbteilungNull())
                    arg.IDAbteilung = r.IDAbteilung;
                else
                    arg.IDAbteilung = EnvPflegePlan.CurrentKlientenAbteilung; // Für den Fall das Einträge gesucht werden default mäßig mit der gewählten Abteilung die Zusatzwerte holen

                if (!r.IsIDPDXNull())
                    arg.IDPDX = r.IDPDX;
                else
                    arg.IDPDX = Guid.Empty;

                arg.IDPDXEintrag = r.ID;

                if (!r.IsIDLinkDokumentNull())
                    arg.IDLinkDokument = r.IDLinkDokument;
                else
                    arg.IDLinkDokument = Guid.Empty;

                arg.Text            =  r.IsTextNull()           ? "" : r.Text;
                arg.Klartext        =  r.IsKlartextNull()       ? "" : r.Klartext;
                arg.Sicht           =  r.IsSichtNull()          ? "" : r.Sicht;
                arg.Warnhinweis     =  r.IsWarnhinweisNull()    ? "" : r.Warnhinweis;

                arg.EintragGruppe   = PDx.GetEintragGruppeFromChar(r.EintragGruppe[0]);
                arg.LokalisierungJN = false;							// Default für ASZ

                if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
                    AddZusatzInfoToM(arg);
                list.Add(arg);
            }
            args = (ASZMSelectionArgs[])list.ToArray(typeof(ASZMSelectionArgs));

            return args;
        }
        
        #region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucASZMSearchSelector2));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblPflegeamnesen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbAnamnesen = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblAllgeFavoriten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbTop10Allgemein = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblFavoriten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbTop10 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.groupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.osSearchIn = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.osVerknuepfung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tvSpecific = new PMDS.GUI.BaseControls.ucASZMSelectorTreeView();
            this.btnSelectNoSpecific = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSelectAllSpecific = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnTransferSpecific = new QS2.Desktop.ControlManagment.BaseButton();
            this.pnlLegende = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblLegende = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pbHaken = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.grpFilter = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.cbA = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbS = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbZ = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbM = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tvGenerell = new PMDS.GUI.BaseControls.ucASZMSelectorTreeView();
            this.btnSelectNo = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSelectAll = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnTransferDefault = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblAndereAuswahlTreffen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblKeineEinträgeGefunden = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dsPDxEintragSpecific = new dsPDxEintrag();
            this.dsPDxEintragGenerell = new dsPDxEintrag();
            this.dsPdxBezeichnung = new dsIDTextBezeichnung();
            this.pnlTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.tabTop10 = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabASZM = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnAddMissingASZM = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnamnesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10Allgemein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osSearchIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osVerknuepfung)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.pnlLegende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilter)).BeginInit();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbM)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragSpecific)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragGenerell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPdxBezeichnung)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTop10)).BeginInit();
            this.tabTop10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabASZM)).BeginInit();
            this.tabASZM.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.lblPflegeamnesen);
            this.ultraTabPageControl3.Controls.Add(this.cbAnamnesen);
            this.ultraTabPageControl3.Controls.Add(this.lblAllgeFavoriten);
            this.ultraTabPageControl3.Controls.Add(this.cbTop10Allgemein);
            this.ultraTabPageControl3.Controls.Add(this.lblFavoriten);
            this.ultraTabPageControl3.Controls.Add(this.cbTop10);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(2, 24);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(740, 70);
            // 
            // lblPflegeamnesen
            // 
            this.lblPflegeamnesen.Location = new System.Drawing.Point(465, 9);
            this.lblPflegeamnesen.Name = "lblPflegeamnesen";
            this.lblPflegeamnesen.Size = new System.Drawing.Size(118, 15);
            this.lblPflegeamnesen.TabIndex = 13;
            this.lblPflegeamnesen.Text = "Pflegeanamnesen";
            // 
            // cbAnamnesen
            // 
            this.cbAnamnesen.DisplayMember = "Text";
            this.cbAnamnesen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbAnamnesen.Location = new System.Drawing.Point(465, 24);
            this.cbAnamnesen.Name = "cbAnamnesen";
            this.cbAnamnesen.Size = new System.Drawing.Size(222, 22);
            this.cbAnamnesen.TabIndex = 2;
            this.cbAnamnesen.ValueMember = "ID";
            this.cbAnamnesen.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbAnamnesen.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            this.cbAnamnesen.ValueChanged += new System.EventHandler(this.cbTop10_AfterCloseUp);
            // 
            // lblAllgeFavoriten
            // 
            this.lblAllgeFavoriten.Location = new System.Drawing.Point(237, 9);
            this.lblAllgeFavoriten.Name = "lblAllgeFavoriten";
            this.lblAllgeFavoriten.Size = new System.Drawing.Size(118, 15);
            this.lblAllgeFavoriten.TabIndex = 11;
            this.lblAllgeFavoriten.Text = "Allgemeine Favoriten";
            // 
            // cbTop10Allgemein
            // 
            this.cbTop10Allgemein.DisplayMember = "Text";
            this.cbTop10Allgemein.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbTop10Allgemein.Location = new System.Drawing.Point(237, 24);
            this.cbTop10Allgemein.Name = "cbTop10Allgemein";
            this.cbTop10Allgemein.Size = new System.Drawing.Size(222, 22);
            this.cbTop10Allgemein.TabIndex = 1;
            this.cbTop10Allgemein.ValueMember = "ID";
            this.cbTop10Allgemein.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbTop10Allgemein.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            this.cbTop10Allgemein.ValueChanged += new System.EventHandler(this.cbTop10_AfterCloseUp);
            // 
            // lblFavoriten
            // 
            this.lblFavoriten.Location = new System.Drawing.Point(8, 9);
            this.lblFavoriten.Name = "lblFavoriten";
            this.lblFavoriten.Size = new System.Drawing.Size(222, 15);
            this.lblFavoriten.TabIndex = 9;
            this.lblFavoriten.Text = "Wählen Sie die Favoriten für {0} aus";
            // 
            // cbTop10
            // 
            this.cbTop10.DisplayMember = "Text";
            this.cbTop10.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbTop10.Location = new System.Drawing.Point(8, 24);
            this.cbTop10.Name = "cbTop10";
            this.cbTop10.Size = new System.Drawing.Size(222, 22);
            this.cbTop10.TabIndex = 0;
            this.cbTop10.ValueMember = "ID";
            this.cbTop10.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbTop10.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            this.cbTop10.ValueChanged += new System.EventHandler(this.cbTop10_AfterCloseUp);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.groupBox1);
            this.ultraTabPageControl4.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl4.Controls.Add(this.tbSearch);
            this.ultraTabPageControl4.Controls.Add(this.osVerknuepfung);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(740, 70);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.osSearchIn);
            this.groupBox1.Location = new System.Drawing.Point(504, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wo wollen Sie suchen";
            // 
            // osSearchIn
            // 
            this.osSearchIn.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osSearchIn.CheckedIndex = 0;
            this.osSearchIn.ItemOrigin = new System.Drawing.Point(1, 1);
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "Pflegediagnosen";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "zugeordnete ASRZM";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "ASRZM Eintrag";
            this.osSearchIn.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.osSearchIn.ItemSpacingVertical = 6;
            this.osSearchIn.Location = new System.Drawing.Point(8, 16);
            this.osSearchIn.Name = "osSearchIn";
            this.osSearchIn.Size = new System.Drawing.Size(118, 40);
            this.osSearchIn.TabIndex = 2;
            this.osSearchIn.Text = "Pflegediagnosen";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(8, 8);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(312, 16);
            this.ultraLabel1.TabIndex = 8;
            this.ultraLabel1.Text = "Suchmuster - drücken Sie ENTER um die Suche zu starten";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(8, 24);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(488, 21);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.WordWrap = false;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // osVerknuepfung
            // 
            this.osVerknuepfung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osVerknuepfung.CheckedIndex = 0;
            this.osVerknuepfung.ItemOrigin = new System.Drawing.Point(1, 1);
            valueListItem4.DataValue = "Default Item";
            valueListItem4.DisplayText = "Und";
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "Oder Verknüpfung";
            this.osVerknuepfung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.osVerknuepfung.ItemSpacingVertical = 6;
            this.osVerknuepfung.Location = new System.Drawing.Point(336, 0);
            this.osVerknuepfung.Name = "osVerknuepfung";
            this.osVerknuepfung.Size = new System.Drawing.Size(160, 24);
            this.osVerknuepfung.TabIndex = 1;
            this.osVerknuepfung.Text = "Und";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.tvSpecific);
            this.ultraTabPageControl2.Controls.Add(this.btnSelectNoSpecific);
            this.ultraTabPageControl2.Controls.Add(this.btnSelectAllSpecific);
            this.ultraTabPageControl2.Controls.Add(this.btnTransferSpecific);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(740, 475);
            this.ultraTabPageControl2.Tag = "Dontpatch";
            // 
            // tvSpecific
            // 
            this.tvSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSpecific.Location = new System.Drawing.Point(3, 3);
            this.tvSpecific.Name = "tvSpecific";
            this.tvSpecific.Size = new System.Drawing.Size(734, 383);
            this.tvSpecific.TabIndex = 3;
            this.tvSpecific.TreeviewAfterNodeSelectEventHandler += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tvSpecific_TreeviewAfterNodeSelectEventHandler);
            // 
            // btnSelectNoSpecific
            // 
            this.btnSelectNoSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNoSpecific.AutoWorkLayout = false;
            this.btnSelectNoSpecific.IsStandardControl = false;
            this.btnSelectNoSpecific.Location = new System.Drawing.Point(3, 446);
            this.btnSelectNoSpecific.Name = "btnSelectNoSpecific";
            this.btnSelectNoSpecific.Size = new System.Drawing.Size(112, 24);
            this.btnSelectNoSpecific.TabIndex = 5;
            this.btnSelectNoSpecific.Text = "Keine auswählen";
            this.btnSelectNoSpecific.Click += new System.EventHandler(this.btnSelectNoSpecific_Click);
            // 
            // btnSelectAllSpecific
            // 
            this.btnSelectAllSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAllSpecific.AutoWorkLayout = false;
            this.btnSelectAllSpecific.IsStandardControl = false;
            this.btnSelectAllSpecific.Location = new System.Drawing.Point(3, 422);
            this.btnSelectAllSpecific.Name = "btnSelectAllSpecific";
            this.btnSelectAllSpecific.Size = new System.Drawing.Size(112, 24);
            this.btnSelectAllSpecific.TabIndex = 4;
            this.btnSelectAllSpecific.Text = "Alle auswählen";
            this.btnSelectAllSpecific.Click += new System.EventHandler(this.btnSelectAllSpecific_Click);
            // 
            // btnTransferSpecific
            // 
            this.btnTransferSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransferSpecific.AutoWorkLayout = false;
            this.btnTransferSpecific.IsStandardControl = false;
            this.btnTransferSpecific.Location = new System.Drawing.Point(335, 429);
            this.btnTransferSpecific.Name = "btnTransferSpecific";
            this.btnTransferSpecific.Size = new System.Drawing.Size(124, 40);
            this.btnTransferSpecific.TabIndex = 10;
            this.btnTransferSpecific.Text = "Auswahl bearbeiten";
            this.btnTransferSpecific.Click += new System.EventHandler(this.btnTransferSpecific_Click);
            // 
            // pnlLegende
            // 
            this.pnlLegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLegende.Controls.Add(this.lblLegende);
            this.pnlLegende.Controls.Add(this.pbHaken);
            this.pnlLegende.Location = new System.Drawing.Point(3, 388);
            this.pnlLegende.Name = "pnlLegende";
            this.pnlLegende.Size = new System.Drawing.Size(682, 20);
            this.pnlLegende.TabIndex = 9;
            // 
            // lblLegende
            // 
            this.lblLegende.AutoSize = true;
            this.lblLegende.Location = new System.Drawing.Point(18, 4);
            this.lblLegende.Name = "lblLegende";
            this.lblLegende.Size = new System.Drawing.Size(499, 14);
            this.lblLegende.TabIndex = 8;
            this.lblLegende.Text = "Bereits im Pflegeplan enthaltene Pflegedefinitionen, Ätiologien, Symptome, Ziele " +
    "und Maßnahmen.";
            // 
            // pbHaken
            // 
            this.pbHaken.AutoSize = true;
            this.pbHaken.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbHaken.Image = ((object)(resources.GetObject("pbHaken.Image")));
            this.pbHaken.Location = new System.Drawing.Point(5, 4);
            this.pbHaken.Name = "pbHaken";
            this.pbHaken.Size = new System.Drawing.Size(12, 12);
            this.pbHaken.TabIndex = 7;
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpFilter.Controls.Add(this.cbA);
            this.grpFilter.Controls.Add(this.cbS);
            this.grpFilter.Controls.Add(this.cbZ);
            this.grpFilter.Controls.Add(this.cbM);
            this.grpFilter.Location = new System.Drawing.Point(122, 416);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(207, 54);
            this.grpFilter.TabIndex = 6;
            this.grpFilter.Text = "Filter";
            // 
            // cbA
            // 
            this.cbA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbA.Checked = true;
            this.cbA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbA.Location = new System.Drawing.Point(18, 13);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(82, 20);
            this.cbA.TabIndex = 6;
            this.cbA.Text = "Ätiologien / Risikofaktoren";
            this.cbA.CheckedValueChanged += new System.EventHandler(this.cbFilter_CheckedValueChanged);
            // 
            // cbS
            // 
            this.cbS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbS.Checked = true;
            this.cbS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbS.Location = new System.Drawing.Point(107, 13);
            this.cbS.Name = "cbS";
            this.cbS.Size = new System.Drawing.Size(78, 20);
            this.cbS.TabIndex = 7;
            this.cbS.Text = "Symptome";
            this.cbS.CheckedValueChanged += new System.EventHandler(this.cbFilter_CheckedValueChanged);
            // 
            // cbZ
            // 
            this.cbZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbZ.Checked = true;
            this.cbZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbZ.Location = new System.Drawing.Point(18, 31);
            this.cbZ.Name = "cbZ";
            this.cbZ.Size = new System.Drawing.Size(54, 20);
            this.cbZ.TabIndex = 8;
            this.cbZ.Text = "Ziele";
            this.cbZ.CheckedValueChanged += new System.EventHandler(this.cbFilter_CheckedValueChanged);
            // 
            // cbM
            // 
            this.cbM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbM.Checked = true;
            this.cbM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbM.Location = new System.Drawing.Point(107, 30);
            this.cbM.Name = "cbM";
            this.cbM.Size = new System.Drawing.Size(89, 20);
            this.cbM.TabIndex = 9;
            this.cbM.Text = "Maßnahmen";
            this.cbM.CheckedValueChanged += new System.EventHandler(this.cbFilter_CheckedValueChanged);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.tvGenerell);
            this.ultraTabPageControl1.Controls.Add(this.btnSelectNo);
            this.ultraTabPageControl1.Controls.Add(this.btnSelectAll);
            this.ultraTabPageControl1.Controls.Add(this.btnTransferDefault);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(740, 475);
            // 
            // tvGenerell
            // 
            this.tvGenerell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvGenerell.Location = new System.Drawing.Point(3, 2);
            this.tvGenerell.Name = "tvGenerell";
            this.tvGenerell.Size = new System.Drawing.Size(734, 384);
            this.tvGenerell.TabIndex = 3;
            this.tvGenerell.TreeviewAfterNodeSelectEventHandler += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tvGenerell_TreeviewAfterNodeSelectEventHandler);
            // 
            // btnSelectNo
            // 
            this.btnSelectNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNo.AutoWorkLayout = false;
            this.btnSelectNo.IsStandardControl = false;
            this.btnSelectNo.Location = new System.Drawing.Point(3, 446);
            this.btnSelectNo.Name = "btnSelectNo";
            this.btnSelectNo.Size = new System.Drawing.Size(112, 24);
            this.btnSelectNo.TabIndex = 5;
            this.btnSelectNo.Text = "Keine auswählen";
            this.btnSelectNo.Click += new System.EventHandler(this.btnSelectNo_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.AutoWorkLayout = false;
            this.btnSelectAll.IsStandardControl = false;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 422);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(112, 24);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "Alle auswählen";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnTransferDefault
            // 
            this.btnTransferDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransferDefault.AutoWorkLayout = false;
            this.btnTransferDefault.IsStandardControl = false;
            this.btnTransferDefault.Location = new System.Drawing.Point(335, 429);
            this.btnTransferDefault.Name = "btnTransferDefault";
            this.btnTransferDefault.Size = new System.Drawing.Size(124, 40);
            this.btnTransferDefault.TabIndex = 10;
            this.btnTransferDefault.Text = "Auswahl bearbeiten";
            this.btnTransferDefault.Click += new System.EventHandler(this.btnTransferDefault_Click);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.lblAndereAuswahlTreffen);
            this.ultraTabPageControl5.Controls.Add(this.lblKeineEinträgeGefunden);
            this.ultraTabPageControl5.Controls.Add(this.pnlLegende);
            this.ultraTabPageControl5.Controls.Add(this.grpFilter);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(2, 24);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(740, 475);
            // 
            // lblAndereAuswahlTreffen
            // 
            this.lblAndereAuswahlTreffen.AutoSize = true;
            this.lblAndereAuswahlTreffen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAndereAuswahlTreffen.ForeColor = System.Drawing.Color.Blue;
            this.lblAndereAuswahlTreffen.Location = new System.Drawing.Point(56, 77);
            this.lblAndereAuswahlTreffen.Name = "lblAndereAuswahlTreffen";
            this.lblAndereAuswahlTreffen.Size = new System.Drawing.Size(239, 20);
            this.lblAndereAuswahlTreffen.TabIndex = 8;
            this.lblAndereAuswahlTreffen.Text = "Treffen Sie eine andere Auswahl";
            // 
            // lblKeineEinträgeGefunden
            // 
            this.lblKeineEinträgeGefunden.AutoSize = true;
            this.lblKeineEinträgeGefunden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeineEinträgeGefunden.ForeColor = System.Drawing.Color.Blue;
            this.lblKeineEinträgeGefunden.Location = new System.Drawing.Point(56, 38);
            this.lblKeineEinträgeGefunden.Name = "lblKeineEinträgeGefunden";
            this.lblKeineEinträgeGefunden.Size = new System.Drawing.Size(262, 20);
            this.lblKeineEinträgeGefunden.TabIndex = 7;
            this.lblKeineEinträgeGefunden.Text = "Es wurden keine Einträge gefunden";
            // 
            // dsPDxEintragSpecific
            // 
            this.dsPDxEintragSpecific.DataSetName = "dsPDxEintrag";
            this.dsPDxEintragSpecific.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintragSpecific.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPDxEintragGenerell
            // 
            this.dsPDxEintragGenerell.DataSetName = "dsPDxEintrag";
            this.dsPDxEintragGenerell.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintragGenerell.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPdxBezeichnung
            // 
            this.dsPdxBezeichnung.DataSetName = "dsIDTextBezeichnung";
            this.dsPdxBezeichnung.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPdxBezeichnung.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tabTop10);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(744, 96);
            this.pnlTop.TabIndex = 11;
            // 
            // tabTop10
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.ForeColor = System.Drawing.Color.Blue;
            this.tabTop10.ActiveTabAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.Gainsboro;
            appearance2.ForeColor = System.Drawing.Color.Gray;
            this.tabTop10.Appearance = appearance2;
            this.tabTop10.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabTop10.Controls.Add(this.ultraTabPageControl3);
            this.tabTop10.Controls.Add(this.ultraTabPageControl4);
            this.tabTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTop10.Location = new System.Drawing.Point(0, 0);
            this.tabTop10.Name = "tabTop10";
            this.tabTop10.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabTop10.Size = new System.Drawing.Size(744, 96);
            this.tabTop10.TabIndex = 0;
            ultraTab1.Key = "Top10";
            ultraTab1.TabPage = this.ultraTabPageControl3;
            ultraTab1.Text = "Favoriten";
            ultraTab2.Key = "Suchen";
            ultraTab2.TabPage = this.ultraTabPageControl4;
            ultraTab2.Text = "Suchen";
            this.tabTop10.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.tabTop10.TabStop = false;
            this.tabTop10.Tag = "Dontpatch";
            this.tabTop10.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(740, 70);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 96);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(744, 3);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // tabASZM
            // 
            appearance3.ForeColor = System.Drawing.Color.Blue;
            this.tabASZM.ActiveTabAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Gainsboro;
            appearance4.ForeColor = System.Drawing.Color.Gray;
            this.tabASZM.Appearance = appearance4;
            this.tabASZM.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabASZM.Controls.Add(this.ultraTabPageControl1);
            this.tabASZM.Controls.Add(this.ultraTabPageControl2);
            this.tabASZM.Controls.Add(this.ultraTabPageControl5);
            this.tabASZM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabASZM.Location = new System.Drawing.Point(0, 99);
            this.tabASZM.Name = "tabASZM";
            appearance5.BackColor = System.Drawing.Color.Gainsboro;
            this.tabASZM.SelectedTabAppearance = appearance5;
            this.tabASZM.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.pnlLegende,
            this.grpFilter});
            this.tabASZM.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabASZM.Size = new System.Drawing.Size(744, 501);
            this.tabASZM.TabIndex = 14;
            ultraTab3.Key = "Abteilung";
            ultraTab3.TabPage = this.ultraTabPageControl2;
            ultraTab3.Tag = "Abteilung: {0} ({1} Elemente)";
            ultraTab3.Text = "Abteilung: {0}";
            ultraTab4.Key = "Generell";
            ultraTab4.TabPage = this.ultraTabPageControl1;
            ultraTab4.Tag = "Für alle Abteilungen ({0} Elemente)";
            ultraTab4.Text = "Für alle Abteilungen";
            ultraTab5.Key = "keine";
            ultraTab5.TabPage = this.ultraTabPageControl5;
            ultraTab5.Text = "Keine Einträge gefunden";
            this.tabASZM.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab4,
            ultraTab5});
            this.tabASZM.Tag = "";
            this.tabASZM.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tabASZM.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.tabASZM_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.pnlLegende);
            this.ultraTabSharedControlsPage1.Controls.Add(this.grpFilter);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(740, 475);
            // 
            // btnAddMissingASZM
            // 
            this.btnAddMissingASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMissingASZM.AutoWorkLayout = false;
            this.btnAddMissingASZM.Enabled = false;
            this.btnAddMissingASZM.IsStandardControl = false;
            this.btnAddMissingASZM.Location = new System.Drawing.Point(707, 100);
            this.btnAddMissingASZM.Name = "btnAddMissingASZM";
            this.btnAddMissingASZM.Size = new System.Drawing.Size(33, 20);
            this.btnAddMissingASZM.TabIndex = 15;
            this.btnAddMissingASZM.Text = "+";
            this.btnAddMissingASZM.Click += new System.EventHandler(this.btnAddMissingASZM_Click);
            // 
            // ucASZMSearchSelector2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnAddMissingASZM);
            this.Controls.Add(this.tabASZM);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucASZMSearchSelector2";
            this.Size = new System.Drawing.Size(744, 600);
            this.Load += new System.EventHandler(this.ucASZMSearchSelector2_Load);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnamnesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10Allgemein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.osSearchIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osVerknuepfung)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.pnlLegende.ResumeLayout(false);
            this.pnlLegende.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilter)).EndInit();
            this.grpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbM)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragSpecific)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragGenerell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPdxBezeichnung)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabTop10)).EndInit();
            this.tabTop10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabASZM)).EndInit();
            this.tabASZM.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Load
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucASZMSearchSelector2_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
					return;
                //Neu nach 16.05.2007 MDA
                Abteilung abteilung = new Abteilung();
                _abteilungText = abteilung.GetAbteilungstext(EnvPflegePlan.CurrentKlientenAbteilung);
                lblFavoriten.Text = string.Format(lblFavoriten.Text, _abteilungText);
                
				_PDx = new PDx();
                _pdxAnamnese = new PDXAnamnese();
                _pdxAnamnese.Read();
				cbTop10.DisplayLayout.Bands[0].ColHeadersVisible	= false;
				cbTop10.DisplayLayout.Bands[0].RowLayoutStyle	= RowLayoutStyle.ColumnLayout;
                cbTop10Allgemein.DisplayLayout.Bands[0].ColHeadersVisible    = false;
                cbTop10Allgemein.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.ColumnLayout;

                cbAnamnesen.DisplayLayout.Bands[0].ColHeadersVisible = false;
                cbAnamnesen.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
				
                RefreshTop10Combo();

                if (PDX_SELARGS != null)
                {
                    pnlTop.Visible = false;
                    btnAddMissingASZM.Top = 2;
                    splitter1.Visible = false;

                    if (ASZSearch)
                        SwitchToASZSearch();
                    else
                        SwitchToMassnahmeSearch();

                    osSearchIn.CheckedIndex = 0;

                    if(PDX_SELARGS.Length == 1)
                        tbSearch.Text = PDX_SELARGS[0].Text;

                    RefreshASZMToPDXSELARGS();
                    tvSpecific.ExpendAllTreeNodes();
                    tvGenerell.ExpendAllTreeNodes();

                    
                }
                else
				    UpdateFilters();

			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Größenanpassung der Combo
		/// </summary>
		//----------------------------------------------------------------------------
		private void cbTop10_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{
            UltraCombo c = (UltraCombo)sender;
			c.DisplayLayout.Bands[0].Columns[c.DisplayMember].Width = c.Width;
			c.DisplayLayout.Bands[0].ColHeadersVisible	= false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Hier werden alle ASZM geladen welche zu den ausgewählten PDx gehören
		/// und zwar generell und abteilungsspezifisch
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertEintraege(dsPDxEintrag.PDXEintragDataTable dest, dsPDxEintrag.PDXEintragDataTable source) 
		{
			foreach(dsPDxEintrag.PDXEintragRow r in source.Rows)		// Jeden Eintrag der Quelle in das Ziel hinzufügen
				dest.Rows.Add( r.ItemArray);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Suchmodus: Hier müssen alle ASZM dargestellt werden welche das kriterim 
		/// erfüllen (Je nach Modus auch die PDx)
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshASZMSearch() 
		{
			if(SEARCHIN_PDX)										// In den PDx suchen
			{
                dsPdxBezeichnung.Clear();
                dsPdxBezeichnung = _PDx.GetPDxFromSearchText(tbSearch.Text.Trim(), SEARCH_CONDITION);
				RefreshPDxList();
			}
			else													
			{
                dsPDxEintrag.PDXEintragDataTable t = null;
                dsPDxEintrag.PDXEintragDataTable t1 = null;

				if (SEARCHIN_PDXEINTRÄGE)							// In den PDxEinträgen suchen
                {
                    dsPDxEintragGenerell.Clear();
                    dsPDxEintragSpecific.Clear();
                    t = _PDx.GetPDxEintragFromSearchText(tbSearch.Text.Trim(), SEARCH_CONDITION, Guid.Empty); // Suche über generelle Abteilungen in der PDXEintragszuordnung
                    InsertEintraege(dsPDxEintragGenerell.PDXEintrag, t);
                    t1 = _PDx.GetPDxEintragFromSearchText(tbSearch.Text.Trim(), SEARCH_CONDITION, EnvPflegePlan.CurrentKlientenAbteilung); // Suche über spezielle Abteilungen in der PDXEintragszuordnung
                    InsertEintraege(dsPDxEintragSpecific.PDXEintrag, t1);
                }
                else												// In den Einträgen ohne PDX zugehörigkeit suchen
                {
                    dsPDxEintragGenerell.Clear();
                    dsPDxEintragSpecific.Clear();
                    t = _PDx.GetEintragFromSearchText(tbSearch.Text.Trim(), SEARCH_CONDITION, true); // Suche in den Einträgen (IDAbteilung wird als GUID.Empty belegt)
                    InsertEintraege(dsPDxEintragGenerell.PDXEintrag, t);
                    t1 = _PDx.GetEintragFromSearchText(tbSearch.Text.Trim(), SEARCH_CONDITION, false); // Suche in den Einträgen
                    InsertEintraege(dsPDxEintragSpecific.PDXEintrag, t1);

                }

                tvSpecific.ListIDPDX = null;
                tvGenerell.ListIDPDX = null;

                if(t1 != null)
                    tvSpecific.PDX_SELARGS = GetListPDx(t1);
                tvSpecific.SelectAllTreeNodes(false);
                
                if (t != null)
                    tvGenerell.PDX_SELARGS = GetListPDx(t);

                tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());//Neu nach 18.05.2007 MDA
                tvGenerell.SelectAllTreeNodes(false);
            }

            ShowHideTabs();
     	}

        private void RefreshASZMToPDXSELARGS()
        {
            List<PDxSelectionArgs> listSearchSpecific = new List<PDxSelectionArgs>();
            List<PDxSelectionArgs> listSearchGenerell = new List<PDxSelectionArgs>();

            List<Guid> listIDPDX = new List<Guid>();

            foreach (PDxSelectionArgs pdxARG in PDX_SELARGS)
            {
                listIDPDX.Add(pdxARG.IDPDX);

                dsPdxBezeichnung.Clear();
                dsPdxBezeichnung = _PDx.GetPDxFromSearchText(pdxARG.Klartext.Trim(), SEARCH_CONDITION);

                InsertListPDX(listSearchSpecific, listSearchGenerell);
            }

            tvSpecific.ListIDPDX = listIDPDX;
            tvSpecific.PDX_SELARGS = listSearchSpecific.ToArray();
            tvSpecific.ExpendAllTreeNodes();

            tvGenerell.ListIDPDX = listIDPDX;
            tvGenerell.PDX_SELARGS = listSearchGenerell.ToArray();
            tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());//Neu nach 18.05.2007 MDA
            tvGenerell.ExpendAllTreeNodes();

            UpdateFilters();
            ShowHideTabs();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liste Von PDxSelectionArgs aus eine PDXEintragDataTable zurück geben
        /// </summary>
        //----------------------------------------------------------------------------
        private PDxSelectionArgs[] GetListPDx(dsPDxEintrag.PDXEintragDataTable table)
        {
            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            List<ASZMSelectionArgs> listArgs;
            PDxSelectionArgs pdx;

            
            bool found;
            foreach (dsPDxEintrag.PDXEintragRow r in table)
            {
                pdx = new PDxSelectionArgs();
                pdx.IDPDX = r.IDPDX;
                found = false;

                foreach (PDxSelectionArgs pdxArg in list)
                {
                    if (pdx.IDPDX == pdxArg.IDPDX)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    list.Add(pdx);
            }

            ASZMSelectionArgs arg;
            foreach (PDxSelectionArgs pdxArg in list)
            {
                listArgs = new List<ASZMSelectionArgs>();

                foreach (dsPDxEintrag.PDXEintragRow r in table)
                {
                    if (pdxArg.IDPDX == r.IDPDX)
                    {
                        arg = GetASZMSelectionArg(r);
                        arg.LokalisierungJN = false;							// Default für ASZ
                        listArgs.Add(arg);
                    }
                }

                pdxArg.ARGS = listArgs.ToArray();
            }
            SetLokalisierung(list);
            return list.ToArray();
        }

        private ASZMSelectionArgs GetASZMSelectionArg(dsPDxEintrag.PDXEintragRow r)
        {
            ASZMSelectionArgs arg = new ASZMSelectionArgs();
            arg.IDEintrag = r.IDEintrag;

            if (!r.IsIDAbteilungNull())
                arg.IDAbteilung = r.IDAbteilung;
            else
                arg.IDAbteilung = EnvPflegePlan.CurrentKlientenAbteilung; // Für den Fall das Einträge gesucht werden default mäßig mit der gewählten Abteilung die Zusatzwerte holen

            if (!r.IsIDPDXNull())
                arg.IDPDX = r.IDPDX;
            else
                arg.IDPDX = Guid.Empty;

            arg.IDPDXEintrag = r.ID;

            if (!r.IsIDLinkDokumentNull())
                arg.IDLinkDokument = r.IDLinkDokument;
            else
                arg.IDLinkDokument = Guid.Empty;

            arg.Text = r.Text;
            arg.Klartext = r.Klartext;
            arg.Sicht = r.Sicht;
            arg.Warnhinweis = r.Warnhinweis;
            arg.EintragGruppe = PDx.GetEintragGruppeFromChar(r.EintragGruppe[0]);
            
            if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
            {
                AddZusatzInfoToM(arg);
            }

            return arg;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die ausgewählte Suchverknüpfing
		/// </summary>
		//----------------------------------------------------------------------------
		private SearchCondition SEARCH_CONDITION 
		{
			get 
			{
				if(osVerknuepfung.CheckedIndex == 0)
					return SearchCondition.AND;
				else
					return SearchCondition.OR;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert True wenn PDX Suche ausgewählt ist
		/// </summary>
		//----------------------------------------------------------------------------
		private bool SEARCHIN_PDX 
		{
			get 
			{
				if(osSearchIn.CheckedIndex == 0)
					return true;
				else
					return false;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert True wenn PDX Suche ausgewählt ist
		/// </summary>
		//----------------------------------------------------------------------------
		private bool SEARCHIN_PDXEINTRÄGE 
		{
			get 
			{
				if(osSearchIn.CheckedIndex == 1)
					return true;
				else
					return false;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Reiter Text entsprechend gefundener Elemente anpassen
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshTabText() 
		{
            //Änderung nach 16.05.2007 MDA: Abteilungsbezeichnung im Tab anzeigen
            tabASZM.Tabs["Abteilung"].Text = string.Format((string)tabASZM.Tabs["Abteilung"].Tag, _abteilungText, tvSpecific.GetTreeNodesCount());
            tabASZM.Tabs["Generell"].Text = string.Format((string)tabASZM.Tabs["Generell"].Tag, tvGenerell.GetTreeNodesCount());
      	}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktualsieren der ASZM Einträge
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshASZM() 
		{
			try 
			{
                _RefreshFromAnanemnese = false;
				this.Cursor = Cursors.WaitCursor;
				
                if (tabTop10.SelectedTab.Key == "Top10")
                {
                    dsPdxBezeichnung.Clear();
                    dsPdxBezeichnung = _PDx.GetPDxFromPDxGruppeID(_SelectedPDX);
                    RefreshPDxList();
                }
                else
                    RefreshASZMSearch();						// Textsuche

                UpdateFilters();
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}
		}

        //----------------------------------------------------------------------------
        //13.04.2007 MDA
        /// <summary>
        /// Aktualsieren der ASZM Einträge aus eine Pflegeanamnese
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshASZMFromAnamnese()
        {
            try
            {
                _RefreshFromAnanemnese = true;
                this.Cursor = Cursors.WaitCursor;

                if (cbAnamnesen.ActiveRow != null)
                {
                    Guid idAnamnese = (Guid)cbAnamnesen.ActiveRow.Cells["ID"].Value;
                    string[] names  = Enum.GetNames(typeof(PflegeModelle));

                    string modell = "";

                    foreach (string name in names)
                    {
                        if (cbAnamnesen.ActiveRow.Cells["TEXT"].Value.ToString().ToUpper().Contains(name.ToUpper()))
                        {
                            modell = name;
                            break;
                        }
                    }

                    dsPDXAnamnese.PDXAnamneseRow[] rows = (dsPDXAnamnese.PDXAnamneseRow[])_pdxAnamnese.PDXAnamneseDataTable.Select("IDAnamnese" + modell + "='" + idAnamnese + "'");
                    dsPDx.PDXRow _PDXRow;

                    List<PDxSelectionArgs> listSearchSpecific = new List<PDxSelectionArgs>();
                    List<PDxSelectionArgs> listSearchGenerell = new List<PDxSelectionArgs>();

                    List<Guid> listIDPDX = new List<Guid>();

                    foreach (dsPDXAnamnese.PDXAnamneseRow r in rows)
                    {
                        listIDPDX.Add(r.IDPDX);
                        _PDXRow = _PDx.ReadOne(r.IDPDX);

                        dsPdxBezeichnung.Clear();

                        //Änderung nach 05.05.2007 MDA: PDx nach ID (Eindeutig) suchen
                        dsPdxBezeichnung = _PDx.GetPDxByID(_PDXRow.ID);
                        
                        InsertListPDX(listSearchSpecific, listSearchGenerell);
                    }

                    //Neu Nach 14.05.2007 MDA: Ressource zu ASZMSelectionArg hinzufügen
                    AddRessourceToASZMSelectionArg(listSearchSpecific, rows);
                    AddRessourceToASZMSelectionArg(listSearchGenerell, rows);

                    tvSpecific.ListIDPDX = listIDPDX;
                    tvSpecific.PDX_SELARGS = listSearchSpecific.ToArray();
                    
                    tvGenerell.ListIDPDX = listIDPDX;
                    tvGenerell.PDX_SELARGS = listSearchGenerell.ToArray();

                    //Neu nach 16.05.2007 MDA: Alle Abteilungsspecefische Pflegedefinitionen aus der Generellen Pflegedefinitionen entfernen.
                    tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());
                    
                    UpdateFilters();
                    dsPdxBezeichnung.Clear();

                }
            }
            finally
            {
                ShowHideTabs();
                this.Cursor = Cursors.Arrow;
            }
        }

        //Neu Nach 14.05.2007 MDA: Ressource zu ASZMSelectionArg hinzufügen
        private void AddRessourceToASZMSelectionArg(List<PDxSelectionArgs> listPDxSelectionArgs, dsPDXAnamnese.PDXAnamneseRow[] PDXAnamneseRows)
        {
            //Nur wenn eine Pflegeanamnese ausgewählt wurde.
            if (!_RefreshFromAnanemnese)
                return;

            foreach (PDxSelectionArgs PDxArg in listPDxSelectionArgs)
            {
                foreach (dsPDXAnamnese.PDXAnamneseRow r in PDXAnamneseRows)
                {
                    if (r.IDPDX == PDxArg.IDPDX)
                    {
                        if(!r.IsResourceklientNull())
                            PDxArg.Resourceklient = r.Resourceklient;

                        foreach (ASZMSelectionArgs arg in PDxArg.ARGS)
                        {
                            arg.Resourceklient = PDxArg.Resourceklient;
                        }
                        break;
                    }
                }
            }
        }

		private void cbTop10_AfterCloseUp(object sender, System.EventArgs e)
		{
            UltraCombo c = (UltraCombo)sender;

            if (c.Equals(cbTop10Allgemein) || c.Equals(cbAnamnesen))
                tabASZM.SelectedTab = tabASZM.Tabs["Generell"];
            else
                tabASZM.SelectedTab = tabASZM.Tabs["Abteilung"];

            if(c.ActiveRow == null)
				return;

            try 
			{
                if (!c.Equals(cbAnamnesen))
                {
                    _SelectedPDX = (Guid)c.ActiveRow.Cells["ID"].Value;
                    RefreshASZM();
                }
                else
                {
                    RefreshASZMFromAnamnese();
                }
			}
			finally
			{
				
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert true wenn irgend eine Zeile der Datengrids zur Auswahl markiert ist
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ISAnySelected
		{
			get 
			{
                if (IsSelected(tvGenerell))
                    return true;

                if (IsSelected(tvSpecific))
                    return true;

				return false;
			}
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert true wenn irgend eine Zeile der Datengrids markiert ist
		/// </summary>
		//----------------------------------------------------------------------------
		private bool IsSelected(ucASZMSelectorTreeView tv)
		{
            if (tv.GetASZMSelectionArgs().Length > 0)
                return true;
			
			return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Stößt für jeden Eintrag die ASZMSelected funktion an
		/// </summary>
		//----------------------------------------------------------------------------
		private void TransferASZM(ucASZMSelectorTreeView tv, int iRecursiveCount) 
		{
            ASZMSelectionArgs[] aszmsa = tv.GetASZMSelectionArgs();
            
            ASZMSelected(aszmsa, (iRecursiveCount > 0), false, "", "");									// Der eigentliche Aufruf

            //Liste ASZM Aktualisieren um neue ASZMSelectionArgs zu erzeugen
            //und im TreeView anzeigen.

            if (PDX_SELARGS != null)
                RefreshASZMToPDXSELARGS();
            else if(_RefreshFromAnanemnese)
                RefreshASZMFromAnamnese();
            else
                RefreshASZM();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Füllt bei einem ASZMSelectionArgs die Maßnahmen Zusatzwerte auf
		/// </summary>
		//----------------------------------------------------------------------------
		private void AddZusatzInfoToM(ASZMSelectionArgs args) 
		{
			if(args.EintragGruppe == EintragGruppe.M)					// Nur zu den Maßnahmen gibts Zusatzinfos
			{
				EintragZusatz ez = new EintragZusatz();

				dsEintragZusatz.EintragZusatzRow rz;
				rz =  ez.Read(args.IDEintrag, args.IDAbteilung);		// Den zugehörigen ZusatzEinrag lesen mit der richtigen Abteilung
				if(rz == null)
					rz =  ez.Read(args.IDEintrag, Guid.Empty);			// Wenn keine Abteilung gefungen wurde dann mit der default lesen gehen

				if(rz == null)
					throw new Exception(string.Format("Application Error: Cannot found EintragZusatz for IDEintrag {0} - IDAbteilung {1}", args.IDEintrag.ToString(), args.IDAbteilung.ToString()));

				args.Dauer				= rz.Dauer;
				args.EinmaligJN 		= rz.EinmaligJN;
				args.Intervall			= rz.Intervall;
				args.EvalTage			= rz.EvalTage;
				args.IDBerufsstand		= rz.IDBerufsstand;
				args.IntervallTyp		= rz.IntervallTyp;
				args.LokalisierungJN	= rz.LokalisierungJN;
				args.ParalellJN			= rz.ParalellJN;
				args.WochenTage			= rz.WochenTage;
				args.RMOptionalJN		= rz.RMOptionalJN;

				if(!rz.IsIDMassnahmenserienNull()) 
				{
					args.UntertaegigBenutzerdefiniertJN =  rz.IDMassnahmenserien == Guid.Empty ? true : false;			// signalisiert eine Benutzerdefinierte Eingabe
					if(args.UntertaegigBenutzerdefiniertJN == false)
						args.UNTERTAEGIG					= GetUnterttaegigPoints(rz.IDMassnahmenserien);				// Die einzelnen Pinkte verspeichern
				}
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zeitpunkte für die Maßnahmenserie
		/// </summary>
		//----------------------------------------------------------------------------
		private DateTime[] GetUnterttaegigPoints(Guid IDMassnahmenserien)
		{
			Massnahmenserien s = Massnahmenserien.Default();
			return s.GetPoints(IDMassnahmenserien);	
		}


        //----------------------------------------------------------------------------
		/// <summary>
		/// Die Ausgewählten PDx sollen mit der generellen PDx Zuordnung übertragen 
		/// werden
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnTransferDefault_Click(object sender, System.EventArgs e)
		{
			if(ASZMSelected == null)
				return;
			
            TransferASZM(tvGenerell, 0);
			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Ausgewählten PDx sollen mit der Abteilungsspezifischen PDx Zuordnung übertragen 
		/// werden
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnTransferSpecific_Click(object sender, System.EventArgs e)
		{
			if(ASZMSelected == null)
				return;
			
            TransferASZM(tvSpecific, 0);
		}

		
		private void tbSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Return && tbSearch.Text.Trim() != "")
				RefreshASZM();
		}

        //----------------------------------------------------------------------------
		/// <summary>
		/// ASZM Filter aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void cbFilter_CheckedValueChanged(object sender, System.EventArgs e)
		{
            if (_updateinprogress)
                return;
			UpdateFilters();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ASZM Filter entsprechende den Checkboxen setzen
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateFilters()
		{
			HideOrShowEintragGruppe("A", !cbA.Checked);
            HideOrShowEintragGruppe("S", !cbS.Checked);
            HideOrShowEintragGruppe("Z", !cbZ.Checked);
            HideOrShowEintragGruppe("M", !cbM.Checked);

           	RefreshTabText();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ASZM Filter setzen
		/// </summary>
		//----------------------------------------------------------------------------
		private void HideOrShowEintragGruppe(string group, bool hide)
		{
            tvSpecific.HideOrShowEintragGruppe(group, hide);
            tvGenerell.HideOrShowEintragGruppe(group, hide);
        }

		private void MarkAll(ucASZMSelectorTreeView tv, bool bSelect) 
		{
            tv.SelectAllTreeNodes(bSelect);
		}

		private void frm_RefreshASZM()
		{ 
			RefreshASZM();
		}

		private void btnSelectAll_Click(object sender, System.EventArgs e)
		{
            MarkAll(tvGenerell, true);
		}

		private void btnSelectNo_Click(object sender, System.EventArgs e)
		{
            MarkAll(tvGenerell, false);
		}

		private void btnSelectAllSpecific_Click(object sender, System.EventArgs e)
		{
            MarkAll(tvSpecific, true);
		}

		private void btnSelectNoSpecific_Click(object sender, System.EventArgs e)
		{
            MarkAll(tvSpecific, false);
		}

		private void ultraTabPageControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den generellen TAB
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTab TAB_GENERELL
        {
            get
            {
                return tabASZM.Tabs[1];
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Spezifischen TAB
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTab TAB_SPECIFIC
        {
            get
            {
                return tabASZM.Tabs[0];
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Keinen TAB
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTab TAB_KEINE
        {
            get
            {
                return tabASZM.Tabs[2];
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüft ob in den Tvs Daten enthalten sind und blendet diese ggfs. aus
        /// und den Hinweistab ein.
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideTabs()
        {
            TAB_KEINE.Visible = !(tvGenerell.HASNODES || tvSpecific.HASNODES);

            TAB_GENERELL.Visible = tvGenerell.HASNODES;
            TAB_SPECIFIC.Visible = tvSpecific.HASNODES;

            pnlLegende.Visible = (TAB_SPECIFIC.Visible || TAB_GENERELL.Visible); // Neu nach 07.05.2007 MDA
            
            if (TAB_SPECIFIC.Visible)
            {
                tabASZM.SelectedTab = TAB_SPECIFIC;
                return;
            }

            if (TAB_GENERELL.Visible)
            {
                tabASZM.SelectedTab = TAB_GENERELL;
                return;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine nicht vorhandene ASZM soll in den Tree eingefügt werden
        /// MDA TODO: 
        /// Hinzufügebutton nur dann aktivieren wenn im Tree (entweder Abteilung oder Generell)
        /// eine A/S/Z/M oder ein Child davon ausgewählt ist.
        /// 
        /// In dieser Funktion je nach gewählter Node frmAdditionalASZMtoPDx mit den richtigen Werten im Konstruktor befüllen
        /// Der Event frm_ASZMtoPDx wird einmal vor dem Verlassen des Folgedialoges Aufgerufen.
        /// Je nach Parameter sollen 
        ///     1) Eine Treenode gemäß der Parameter hinzugefügt (grünen Haken nicht vergessen)
        ///     2) Wenn demStandardHinzufuegen == true dann für die Übergebenen Abteilungen über die Businesslogik 
        ///         Einträge in der Tabelle PDXEinträge generieren
        /// + Die Abteilung ist ab nun die des ausgewählten Klienten ==> Bezeichnungen in die konkrete Abteilung umbenennen (ENV.EnvPflegePlan.CurrentKlientenAbteilung)
        /// </summary>
        //----------------------------------------------------------------------------
        //Änderung nach 15.05.2007 MDA
        private void btnAddMissingASZM_Click(object sender, EventArgs e)
        {
            PDxSelectionArgs pdxSarg = null;
            KatalogEditModes editMode = KatalogEditModes.All;

            SetPDxKatalogEditModes(ref pdxSarg, ref editMode);

            if (pdxSarg != null && editMode != KatalogEditModes.All)
            {
                frmAdditionalASZMtoPDx frm = new frmAdditionalASZMtoPDx(editMode, pdxSarg.IDPDX);
                frm.ASZMtoPDx += new ASZMtoPDxDelegate(frm_ASZMtoPDx);
                frm.ShowDialog();
            }
        }

        //Neu nach 15.05.2007 MDA
        private void SetPDxKatalogEditModes(ref PDxSelectionArgs pdxSarg, ref KatalogEditModes editMode)
        {
            if (tabASZM.SelectedTab == TAB_SPECIFIC)
            {
                pdxSarg = tvSpecific.ActivePDx;
                editMode = tvSpecific.ActiveKatalogEditModes;
            }
            else if (tabASZM.SelectedTab == TAB_GENERELL)
            {
                pdxSarg = tvGenerell.ActivePDx;
                editMode = tvGenerell.ActiveKatalogEditModes;
            }
        }

        //Neu nach 15.05.2007 MDA
        private void SetBtnAddMissingASZMEnabled()
        {
            btnAddMissingASZM.Text = "+";
            btnAddMissingASZM.Enabled = false;
            PDxSelectionArgs pdxSarg = null;
            KatalogEditModes editMode = KatalogEditModes.All;

            SetPDxKatalogEditModes(ref pdxSarg, ref editMode);
            
            if (pdxSarg != null && editMode != KatalogEditModes.All)
            {
                btnAddMissingASZM.Text = editMode.ToString() + " +";
                btnAddMissingASZM.Enabled = true;
            }
        }

        //Neu nach 15.05.2007 MDA
        private ASZMSelectionArgs GetASZMArg(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe)
        {
            ASZMSelectionArgs arg = null;

            

            dsEintrag.EintragDataTable t1 = new Eintrag().Read(IDEintrag);

            if (t1.Rows.Count > 0)
            {
                dsEintrag.EintragRow r = t1[0];
                arg = new ASZMSelectionArgs();
                arg.IDEintrag       = IDEintrag;
                arg.IDAbteilung     = EnvPflegePlan.CurrentKlientenAbteilung;
                arg.IDPDX           = IDPdx;
                arg.IDLinkDokument  = r.IsIDLinkDokumentNull() ? Guid.Empty : r.IDLinkDokument;
                arg.Text            = r.IsTextNull() ? "" : r.Text;
                arg.Sicht           = r.IsSichtNull() ? "" : r.Sicht;
                arg.Warnhinweis     = r.IsWarnhinweisNull() ? "" : r.Warnhinweis;
                arg.EintragGruppe   = gruppe;
                arg.LokalisierungJN = false;							// Default für ASZ

                if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
                {
                    AddZusatzInfoToM(arg);
                }
            }

            return arg;
        }

        //Änderung nach 15.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// </summary>
        //----------------------------------------------------------------------------
        void frm_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            ASZMSelectionArgs arg = GetASZMArg(IDPdx, IDEintrag, gruppe);
            if (arg == null)
                return;

            bool exist = false;

            //Eitrag im TreeView hinzufügen
            if (tabASZM.SelectedTab == TAB_SPECIFIC)
            {
                exist = ExistPDxEintrag(GetASZMArgs(IDPdx, EnvPflegePlan.CurrentKlientenAbteilung, false), arg);
                if (!exist)
                    tvSpecific.AddNodeToCurrentASZMTreeNode(arg, true);
            }
            else if (tabASZM.SelectedTab == TAB_GENERELL)
            {
                exist = ExistPDxEintrag(GetASZMArgs(IDPdx, Guid.Empty, true), arg);
                if (!exist)
                    tvGenerell.AddNodeToCurrentASZMTreeNode(arg, true);
            }

            //Eintrag in der Tabelle PDxEintrag hinzufügen
            if (!exist && demStandardHinzufuegen)
            {
                _PDx.InsertPDXEintragZuordnung(IDEintrag, IDAbteilungen, IDPdx);
            }

            if (exist)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(arg.Text + " existert bereits daher kann nicht hinzugefügt werden.", "Eintrag existert bereits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Neu nach 15.05.2007 MDA
        private bool ExistPDxEintrag(ASZMSelectionArgs[] args, ASZMSelectionArgs arg)
        {
            foreach (ASZMSelectionArgs a in args)
            {
                if (a.Text.Trim() == arg.Text.Trim())
                    return true;
            }

            return false;
        }

        //Neu nach 15.05.2007 MDA
        private void tvSpecific_TreeviewAfterNodeSelectEventHandler(object sender, SelectEventArgs e)
        {
            SetBtnAddMissingASZMEnabled();
        }

        //Neu nach 15.05.2007 MDA
        private void tvGenerell_TreeviewAfterNodeSelectEventHandler(object sender, SelectEventArgs e)
        {
            SetBtnAddMissingASZMEnabled();
        }

        //Neu nach 15.05.2007 MDA
        private void tabASZM_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            SetBtnAddMissingASZMEnabled();
        }
	}
}
