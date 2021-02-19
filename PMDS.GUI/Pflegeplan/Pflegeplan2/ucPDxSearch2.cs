using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTree;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucPDxSearch2 : QS2.Desktop.ControlManagment.BaseControl
    {
        public event PDXSelectedDelegate PDXSelected;
        public event evPflegeplanÄndern pflegeplanÄndern;

        public ucPflegeplan2 mainWindow;

        private SearchCondition _condition = SearchCondition.AND;
        private SearchIN _searchIN = SearchIN.Pflegediagnosen;
        private PDx _PDx;
        private PDXAnamnese _pdxAnamnese = new PDXAnamnese();
        private string _abteilungText = "";
        private Guid _SelectedPDX = Guid.Empty;
        private bool _RefreshFromAnanemnese = false;
        private PMDS.BusinessLogic.PflegePlan _pflegePlan;
        private PDxSelectionArgs[] _pdxSeArgs;
        private KatalogEditModes _KatalogEditModes = KatalogEditModes.All;

        public event Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler TreeviewBeforeNodeSelectEventArgs;
        public event Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler TreeviewAfterNodeSelectEventHandler;

        private PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;
        private bool _PDxEntferntJN = false;
        private dsPDxEintraege _dsPDxEintraegeGenerel = new dsPDxEintraege();
        private dsPDxEintraege _dsPDxEintraegeSpecefic = new dsPDxEintraege();
        private PDxSelectionArgs[] _PflegeplanPDXSelArgs = null;

        public delegate void AddNewASZMToPDXDelegaete(Guid IDPDX, KatalogEditModes editMode);
        public event AddNewASZMToPDXDelegaete AddNewASZM;

        private bool _usePopupToAddASZM = false;
        private bool _Suchmode = true;
        
        public ucPDxSearch2()
        {
            InitializeComponent();
            if (DesignMode || !ENV.AppRunning) return;
            
            InitializeComboBoxDesigns();
            ShowHideTabs();
            EnvPflegePlan.EnvPflegePlanKlientenAbteilungChanged += new EnvPflegePlanKlientenAbteilungChangedDelegate(EnvPflegePlan_EnvPflegePlanKlientenAbteilungChanged);
            ENV.ZusatzeintragChanged += new ZusatzeintragChangedDelegate(ENV_ZusatzeintragChanged);
        }

        void ENV_ZusatzeintragChanged(bool changed)
        {
            if (!Visible) return;
           // btnAddMissingASZM2.Enabled = !changed;
            btnCancel.Enabled = !changed;
            btnOk.Enabled = !changed;
        }

        void EnvPflegePlan_EnvPflegePlanKlientenAbteilungChanged()
        {
            InitSaershControls();
            if (Visible)
                RefreshControl();
        }

        #region UsePopupToAddASZM
        /// <summary>
        /// Beim Addieren von ASZM's ein Popupfenster anzeigen Ja/Nein
        /// </summary>
        /// [Browsable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UsePopupToAddASZM
        {
            get { return _usePopupToAddASZM; }
            set { _usePopupToAddASZM = value; }
        }
        #endregion
        #region PDX_SELARGS
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
            set
            {
                _pdxSeArgs = value;
                RefreshASZMToPDXSELARGS();

                if (_pdxSeArgs == null)
                {
                    cbTop10.SelectedRow = null;
                    cbTop10.ActiveRow = null;
                    cbTop10Allgemein.SelectedRow = null;
                    cbTop10Allgemein.ActiveRow = null;
                    cbAnamnesen.SelectedRow = null;
                    cbAnamnesen.ActiveRow = null;
                    tbSearch.Text = "";
                }
            }
        }
        #endregion
        #region Suchmode
        /// <summary>
        /// Wenn Suchmode = true, dann Obertste Reiter verstecken, sonst anzeigen
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Suchmode
        {
            get { return _Suchmode; }
            set 
            { 
                _Suchmode = value;
                SwitchToSuchmode();
            }
        }
        #endregion
        #region KatalogEditMode
        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KatalogEditModes KatalogEditMode
        {
            get { return _KatalogEditModes; }
            set { _KatalogEditModes = value; }
        }
        #endregion
        #region PFLEGEPLAN
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.BusinessLogic.PflegePlan PFLEGEPLAN
        {
            get { return _pflegePlan; }
            set
            {
                _pflegePlan = value;
                tvGenerell.PflegePlan = value;
                tvSpecific.PflegePlan = value;
            }
        }
        #endregion
        #region PflegeplanPDXSelArgs
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs[] PflegeplanPDXSelArgs
        {
            get { return _PflegeplanPDXSelArgs; }
            set
            {
                _PflegeplanPDXSelArgs = value;
                tvSpecific.PflegeplanPDXSelArgs = value;
                tvGenerell.PflegeplanPDXSelArgs = value;
            }
        }
        #endregion
        #region Suchart
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDXSuchArt Suchart
        {
            get 
            {
                if (TabMain.SelectedTab == TabMain.Tabs["Favoriten"])
                    return PDXSuchArt.Favoriten;
                else if (TabMain.SelectedTab == TabMain.Tabs["Pflegeanamnese"])
                    return PDXSuchArt.Pflegeanamnesen;
                else
                    return PDXSuchArt.Suchen;
            }
        }
        #endregion
        #region Condition
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SearchCondition Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }
        #endregion
        #region SearchIN
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SearchIN SearchIN
        {
            get { return _searchIN; }
            set { _searchIN = value; }
        }
        #endregion
        #region PFLEGEPLANMODUS
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set
            {
                _PflegePlanModus = value;
                tvSpecific.PDX_SELARGS = null;
                tvGenerell.PDX_SELARGS = null;
                tvSpecific.PFLEGEPLANMODUS = value;
                tvGenerell.PFLEGEPLANMODUS = value;
                TabMain.Tabs["Pflegeanamnese"].Visible = _PflegePlanModus == PflegePlanModus.Normal;
            }
        }
        #endregion
        #region SEARCHIN_PDX
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert True wenn PDX Suche ausgewählt ist
        /// </summary>
        //----------------------------------------------------------------------------
        private bool SEARCHIN_PDX
        {
            get
            {
                if (_searchIN == SearchIN.Pflegediagnosen)
                    return true;
                else
                    return false;
            }
        }
        #endregion
        #region TAB_GENERELL
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
        #endregion
        #region TAB_SPECIFIC
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
        #endregion
        #region TAB_KEINE
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
        #endregion
        #region CurrentTreeView
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ITreeview CurrentTreeView
        {
            get
            {
                if (tabASZM.ActiveTab == TAB_SPECIFIC)
                    return (ITreeview)tvSpecific;
                else if (tabASZM.ActiveTab == TAB_GENERELL)
                    return (ITreeview)tvGenerell;
                else
                    return null;
            }
        }
        #endregion
        #region ActivTreeView
        public ucASZMSelectorTreeView2 ActivTreeView
        {
            get
            {
                if (tabASZM.ActiveTab == TAB_SPECIFIC)
                    return tvSpecific;
                else if (tabASZM.ActiveTab == TAB_GENERELL)
                    return tvGenerell;
                else
                    return null;
            }
        }
        #endregion
        #region InitializeComboBoxDesigns
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
        #endregion
        #region SwitchToSuchmode
        private void SwitchToSuchmode()
        {
            if (_Suchmode)
                TabMain.Style = UltraTabControlStyle.PropertyPageSelected ;
            else
                TabMain.Style = UltraTabControlStyle.Wizard;

            HideSearchPanels();
        }
        #endregion
        #region RefreshTop10Combo
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisiert den INhalt der Combo
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshTop10Combo()
        {
            if (_PDx == null) return;
            cbTop10.DataSource = _PDx.GetAllPDxGruppeFromAbteilung(EnvPflegePlan.CurrentKlientenAbteilung,PFLEGEPLANMODUS == PflegePlanModus.Wunde);
            cbTop10Allgemein.DataSource = _PDx.GetAllPDxGruppeFromAbteilung(Guid.Empty,PFLEGEPLANMODUS == PflegePlanModus.Wunde);        // Generelle Abteilung

            if (cbTop10.Rows.Count > 0)
                cbTop10.ActiveRow = cbTop10.Rows[0];

            if (cbTop10.ActiveRow == null && cbTop10Allgemein.Rows.Count > 0)
                cbTop10Allgemein.ActiveRow = cbTop10Allgemein.Rows[0];

            cbAnamnesen.DataSource = _pdxAnamnese.GetAllAnamnesen(ENV.CurrentIDPatient);
            if (cbAnamnesen.Rows.Count > 0)
            { cbAnamnesen.ActiveRow = cbAnamnesen.Rows[0]; }  //??
        }
        #endregion
        #region GetUnterttaegigPoints
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
        #endregion
        #region GetZeitbereichPoints
        private Guid[] GetZeitbereichPoints(Guid IDZeitbereichserien)
        {
            ZeitbereichSerien zb = new ZeitbereichSerien();
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = zb.Read();
            return zb.GetPoints(dt, IDZeitbereichserien);
        }
        #endregion
        #region ShowHideTabs
        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüft ob in den Tvs Daten enthalten sind und blendet diese ggfs. aus
        /// und den Hinweistab ein.
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideTabs()
        {
            if (ENV.OnlyOneFavoritenComboinPlanung)
            {
                panelAllgemeineFavoriten.Visible = false;
                lblAbteilung.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Favoriten");
            }
            
            TAB_KEINE.Visible = !(tvGenerell.HASNODES || tvSpecific.HASNODES);

            TAB_GENERELL.Visible = tvGenerell.HASNODES;
            TAB_SPECIFIC.Visible = Suchart != PDXSuchArt.AllgemeineFavoriten && tvSpecific.HASNODES;


            HideOrShowSelectButtons();

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

            if (TAB_KEINE.Visible)
            {
                tabASZM.SelectedTab = TAB_KEINE;
                return;
            }
        }
        #endregion
        #region RefreshTabText
        //----------------------------------------------------------------------------
        /// <summary>
        /// Reiter Text entsprechend gefundener Elemente anpassen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshTabText()
        {
            //Änderung nach 04.09.2008 MDA: Abteilungsbezeichnung im Tab anzeigen
            //Anzahl der Elemente nicht mehr anzeigen.
            if (lblAbteilung.Text != "Favoriten")
                lblAbteilung.Text = string.Format((string)lblAbteilung.Tag, _abteilungText);

            tabASZM.Tabs["Abteilung"].Text = string.Format((string)tabASZM.Tabs["Abteilung"].Tag, _abteilungText);
            //tabASZM.Tabs["Generell"].Text = string.Format((string)tabASZM.Tabs["Generell"].Tag, tvGenerell.GetTreeNodesCount());
        }
        #endregion
        #region RefreshControl
        bool RefreshTopcombo = true;
        public void RefreshControl()
        {
            if (DesignMode || !ENV.AppRunning) return;
            InitErrorProvider();

            tvSpecific.ListIDPDX = null;
            tvSpecific.PDX_SELARGS = null;
            tvGenerell.ListIDPDX = null;
            tvGenerell.PDX_SELARGS = null;
            this.mainWindow.pnlAddPlDef3.Visible = false;
            this.mainWindow.btnAddMissingASZM3.Visible = false;

            Abteilung abteilung = new Abteilung();
            _abteilungText = abteilung.GetAbteilungstext(EnvPflegePlan.CurrentKlientenAbteilung);

            _pdxAnamnese.Read();

            if(RefreshTopcombo)
                RefreshTop10Combo();

            RefreshTopcombo = true;

            switch (Suchart)
            {
                case PDXSuchArt.Favoriten:
                case PDXSuchArt.AllgemeineFavoriten:
                    if (cbTop10.ActiveRow != null)
                    {
                        _SelectedPDX = (Guid)cbTop10.ActiveRow.Cells["ID"].Value;
                        RefreshASZM();
                    }
                    else if (cbTop10Allgemein.ActiveRow != null)
                    {
                        _SelectedPDX = (Guid)cbTop10Allgemein.ActiveRow.Cells["ID"].Value;
                        RefreshASZM();
                    }
                    else
                    {
                        RefreshTabText();
                        ShowHideTabs();
                    }
                    break;
                case PDXSuchArt.Pflegeanamnesen:
                    cbAnamnesen.Focus();
                    
                    if (cbAnamnesen.ActiveRow != null)
                        RefreshASZMFromAnamnese();
                    else
                    {
                        RefreshTabText();
                        ShowHideTabs();
                    }
                    break;
                case PDXSuchArt.Suchen:
                    tbSearch.Focus();

                    if (tbSearch.Text.Trim() != "")
                    {
                        if (!ValidateFields()) return;
                        RefreshASZMSearch();
                    }
                    else
                    {
                        RefreshTabText();
                        ShowHideTabs();
                    }
                    break;
            }
        }
        #endregion
        #region RefreshASZM
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

                dsPdxBezeichnung.Clear();
                dsPdxBezeichnung = _PDx.GetPDxFromPDxGruppeID(_SelectedPDX, _PflegePlanModus);
                RefreshPDxList();
                RefreshTabText();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion
        #region RefreshASZMFromAnamnese
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
                    string[] names = Enum.GetNames(typeof(PflegeModelle));

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

                        //PDx nach ID (Eindeutig) suchen
                        if ((_PflegePlanModus == PflegePlanModus.Normal && !_PDXRow.WundeJN) ||
                            (_PflegePlanModus == PflegePlanModus.Wunde && _PDXRow.WundeJN))
                            dsPdxBezeichnung = _PDx.GetPDxByID(_PDXRow.ID);

                        InsertListPDX(listSearchSpecific, listSearchGenerell);
                    }

                    //Ressource zu ASZMSelectionArg hinzufügen
                    AddRessourceToASZMSelectionArg(listSearchSpecific, rows);
                    AddRessourceToASZMSelectionArg(listSearchGenerell, rows);

                    tvSpecific.ListIDPDX = listIDPDX;
                    tvSpecific.PDX_SELARGS = listSearchSpecific.ToArray();

                    tvGenerell.ListIDPDX = listIDPDX;
                    tvGenerell.PDX_SELARGS = listSearchGenerell.ToArray();

                    //Alle Abteilungsspecefische Pflegedefinitionen aus der Generellen Pflegedefinitionen entfernen.
                    tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());

                    SetFilter();
                    dsPdxBezeichnung.Clear();
                }
            }
            finally
            {
                ShowHideTabs();
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion
        #region AddRessourceToASZMSelectionArg
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
                        if (!r.IsResourceklientNull())
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
        #endregion
        #region RefreshASZMSearch
        //----------------------------------------------------------------------------
        /// <summary>
        /// Suchmodus: Hier müssen alle ASZM dargestellt werden welche das kriterim 
        /// erfüllen (Je nach Modus auch die PDx)
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshASZMSearch()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (SEARCHIN_PDX)										// In den PDx suchen
                {
                    dsPdxBezeichnung.Clear();
                    dsPdxBezeichnung = _PDx.GetPDxFromSearchText(tbSearch.Text.Trim(), _condition, _PflegePlanModus, _PDxEntferntJN);
                    _dsPDxEintraegeGenerel = _PDx.GetPDxZuordnugenFromSearchText(tbSearch.Text.Trim(), _condition, _PflegePlanModus, Guid.Empty, _PDxEntferntJN);
                    _dsPDxEintraegeSpecefic = _PDx.GetPDxZuordnugenFromSearchText(tbSearch.Text.Trim(), _condition, _PflegePlanModus, EnvPflegePlan.CurrentKlientenAbteilung, _PDxEntferntJN);
                    RefreshPDxList();
                }
                else
                {
                    dsPDxEintrag.PDXEintragDataTable t = null;
                    t = _PDx.GetPDxEintragFromSearchText(tbSearch.Text.Trim(), _condition, Guid.Empty); // Suche über generelle Abteilungen in der PDXEintragszuordnung
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion
        #region GetWunden
        //----------------------------------------------------------------------------
        /// <summary>
        /// Suchmodus: Hier müssen alle ASZM dargestellt werden welche das kriterim 
        /// erfüllen (Je nach Modus auch die PDx)
        /// </summary>
        //----------------------------------------------------------------------------
        private void GetWunden()
        {
            if (_PDx == null) return;
            try
            {
                Cursor = Cursors.WaitCursor;
                dsPdxBezeichnung.Clear();
                dsPdxBezeichnung = _PDx.GetPDxWunden();
                _dsPDxEintraegeGenerel = _PDx.GetWundenZuordnugen(Guid.Empty);
                _dsPDxEintraegeSpecefic = _PDx.GetWundenZuordnugen(EnvPflegePlan.CurrentKlientenAbteilung);

                List<PDxSelectionArgs> listSpecific = new List<PDxSelectionArgs>();
                List<PDxSelectionArgs> listGenerell = new List<PDxSelectionArgs>();



                InsertListPDXFromSearchText(listSpecific, listGenerell, null);

                tvSpecific.ListIDPDX = null;
                tvSpecific.PDX_SELARGS = listSpecific.ToArray();
                tvSpecific.SelectAllTreeNodes(false);

                tvGenerell.ListIDPDX = null;
                tvGenerell.PDX_SELARGS = listGenerell.ToArray();
                tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());
                tvGenerell.SelectAllTreeNodes(false);
                ShowHideTabs();
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion
        #region HideOrShowSelectButtons
        private void HideOrShowSelectButtons()
        {
            //btnSelectAll.Visible = tvSpecific.HASNODES || tvGenerell.HASNODES;
            //btnSelectNo.Visible = tvSpecific.HASNODES || tvGenerell.HASNODES;
        }
        #endregion
        #region ValidateFields
        private bool ValidateFields()
        {
            bool bError = false;

            string Error = "Bitte mindestens 3 Zeichen eingeben";

            if (tbSearch.Text.Trim().Length < 3)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(Error);
                errorProvider1.SetError(tbSearch, Error);
                bError = true;
                tbSearch.Focus();
            }

            return !bError;
        }
        #endregion
        #region InitErrorProvider
        private void InitErrorProvider()
        {
            errorProvider1.SetError(tbSearch, "");
        }
        #endregion
        #region RefreshPDxList
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


            if (Suchart != PDXSuchArt.Suchen)
                InsertListPDX(listSpecific, listGenerell);
            else
                InsertListPDXFromSearchText(listSpecific, listGenerell);

            tvSpecific.ListIDPDX = null;
            tvSpecific.PDX_SELARGS = listSpecific.ToArray();
            tvSpecific.SelectAllTreeNodes(false);

            tvGenerell.ListIDPDX = null;
            tvGenerell.PDX_SELARGS = listGenerell.ToArray();
            tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());//Neu nach 18.05.2007 MDA
            tvGenerell.SelectAllTreeNodes(false);
            ShowHideTabs();
        }
        #endregion
        #region UpdateFilters
        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Filter entsprechende den Checkboxen setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateFilters(bool hide)
        {
            HideOrShowEintragGruppe("A", hide);
            HideOrShowEintragGruppe("S", hide);
            HideOrShowEintragGruppe("Z", hide);
            HideOrShowEintragGruppe("M", hide);
        }
        #endregion
        #region HideOrShowEintragGruppe
        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Filter setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void HideOrShowEintragGruppe(string group, bool hide)
        {
            tvSpecific.HideOrShowEintragGruppe(group, hide);
            tvGenerell.HideOrShowEintragGruppe(group, hide);
        }
        #endregion
        #region InsertListPDX
        private void InsertListPDX(List<PDxSelectionArgs> listSpecific, List<PDxSelectionArgs> listGenerell)
        {
            InsertListPDX(listSpecific, listGenerell, null);
        }

        private void InsertListPDX(List<PDxSelectionArgs> listSpecific, List<PDxSelectionArgs> listGenerell, PDxSelectionArgs pdxArg)
        {
            PDxSelectionArgs specificPdxArg, generellPdxArg;

            foreach (dsIDTextBezeichnung._TableRow r in dsPdxBezeichnung._Table)
            {
                specificPdxArg = new PDxSelectionArgs();
                specificPdxArg.StartDatum = DateTime.Now.Date;
                specificPdxArg.IDPDX = r.ID;
                specificPdxArg.Klartext = r.Text;
                specificPdxArg.ARGS = GetASZMArgs(r.ID, EnvPflegePlan.CurrentKlientenAbteilung, false);

                if (specificPdxArg.ARGS != null && specificPdxArg.ARGS.Length > 0)
                {
                    if (pdxArg != null)
                    {
                        specificPdxArg.LokalisierungJN = pdxArg.LokalisierungJN;
                        specificPdxArg.Lokalisierung = pdxArg.Lokalisierung;
                        specificPdxArg.LokalisierungSeite = pdxArg.LokalisierungSeite;
                    }

                    listSpecific.Add(specificPdxArg);
                }

                generellPdxArg = new PDxSelectionArgs();
                generellPdxArg.StartDatum = DateTime.Now.Date;
                generellPdxArg.IDPDX = r.ID;
                generellPdxArg.Klartext = r.Text;
                generellPdxArg.ARGS = GetASZMArgs(r.ID, Guid.Empty, true);

                if (generellPdxArg.ARGS != null && generellPdxArg.ARGS.Length > 0)
                {
                    if (pdxArg != null)
                    {
                        generellPdxArg.LokalisierungJN = pdxArg.LokalisierungJN;
                        generellPdxArg.Lokalisierung = pdxArg.Lokalisierung;
                        generellPdxArg.LokalisierungSeite = pdxArg.LokalisierungSeite;
                    }

                    listGenerell.Add(generellPdxArg);
                }
            }
        }
        #endregion
        #region InsertListPDXFromSearchText
        private void InsertListPDXFromSearchText(List<PDxSelectionArgs> listSpecific, List<PDxSelectionArgs> listGenerell)
        {
            InsertListPDXFromSearchText(listSpecific, listGenerell, null);
        }
        private void InsertListPDXFromSearchText(List<PDxSelectionArgs> listSpecific, List<PDxSelectionArgs> listGenerell, PDxSelectionArgs pdxArg)
        {
            PDxSelectionArgs specificPdxArg, generellPdxArg;
            dsPDxEintraege.PDXEintraegeRow[] rows;

            foreach (dsIDTextBezeichnung._TableRow r in dsPdxBezeichnung._Table)
            {
                if (_dsPDxEintraegeSpecefic.PDXEintraege.Count > 0)
                {
                    rows = (dsPDxEintraege.PDXEintraegeRow[])_dsPDxEintraegeSpecefic.PDXEintraege.Select("IDPDx = '" + r.ID.ToString() + "'");
                    if (rows.Length > 0)
                    {
                        specificPdxArg = new PDxSelectionArgs();
                        specificPdxArg.StartDatum = DateTime.Now.Date;
                        specificPdxArg.IDPDX = r.ID;
                        specificPdxArg.Klartext = r.Text;
                        if (pdxArg != null)
                        {
                            specificPdxArg.LokalisierungJN = pdxArg.LokalisierungJN;
                            specificPdxArg.Lokalisierung = pdxArg.Lokalisierung;
                            specificPdxArg.LokalisierungSeite = pdxArg.LokalisierungSeite;
                        }
                        listSpecific.Add(specificPdxArg);
                    }
                }

                if (_dsPDxEintraegeGenerel.PDXEintraege.Count > 0)
                {
                    rows = (dsPDxEintraege.PDXEintraegeRow[])_dsPDxEintraegeGenerel.PDXEintraege.Select("IDPDx = '" + r.ID.ToString() + "'");
                    if (rows.Length > 0)
                    {
                        generellPdxArg = new PDxSelectionArgs();
                        generellPdxArg.StartDatum = DateTime.Now.Date;
                        generellPdxArg.IDPDX = r.ID;
                        generellPdxArg.Klartext = r.Text;

                        if (pdxArg != null)
                        {
                            generellPdxArg.LokalisierungJN = pdxArg.LokalisierungJN;
                            generellPdxArg.Lokalisierung = pdxArg.Lokalisierung;
                            generellPdxArg.LokalisierungSeite = pdxArg.LokalisierungSeite;
                        }
                        listGenerell.Add(generellPdxArg);
                    }
                }
            }
        }
        #endregion
        #region GetASZMArgs
        //----------------------------------------------------------------------------
        /// <summary>
        /// Gibt alle ASZM's die zu eine bestimmte PDx gehören
        /// </summary>
        //----------------------------------------------------------------------------
        private ASZMSelectionArgs[] GetASZMArgs(Guid idPdx, Guid idAbteilung, bool bGeneral)
        {
            ASZMSelectionArgs[] args = null;
            ArrayList list = new ArrayList();
            dsPDxEintrag.PDXEintragDataTable t1 = _PDx.GetZuordnungen(idPdx, idAbteilung, false);//Entfernte Einträge nicht anzeigen.
            ASZMSelectionArgs arg;

            //neu nach 25.06.2007 MDA
            Eintrag eint = new Eintrag();
            dsEintrag.EintragDataTable eintragDataTable;
            bool ohneZeitBezug;
            foreach (dsPDxEintrag.PDXEintragRow r in t1)
            {
                arg = new ASZMSelectionArgs();

                int flag = 0;
                ohneZeitBezug = false;
                //neu nach 25.06.2007 MDA: Entfernte Einträge nicht anzeigen.
                eintragDataTable = eint.Read(r.IDEintrag);
                if (eintragDataTable.Count > 0)
                {
                    //PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    //{
                        //PMDS.db.Entities.Eintrag rEintrag = b.GetEintrag(db, r.IDEintrag);
                    //ohneZeitBezug = eintragDataTable[0].OhneZeitBezug;
                    //}
                    
                    if (eintragDataTable[0].EntferntJN)
                        continue;
                    ohneZeitBezug = eintragDataTable[0].OhneZeitBezug;
                    flag = eintragDataTable[0].flag;                //lthxy
                    arg.EintragFlag = eintragDataTable[0].flag;
                }
                
                arg.StartDatum = DateTime.Now.Date;
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

                arg.Text = r.IsTextNull() ? "" : r.Text;
                arg.Klartext = r.IsKlartextNull() ? "" : r.Klartext;
                arg.Sicht = r.IsSichtNull() ? "" : r.Sicht;
                arg.Warnhinweis = r.IsWarnhinweisNull() ? "" : r.Warnhinweis;

                arg.EintragGruppe = PDx.GetEintragGruppeFromChar(r.EintragGruppe[0]);
                arg.LokalisierungJN = false;							// Default für ASZ
                arg.OhneZeitBezug = ohneZeitBezug;
                arg.EintragFlag = flag;       //lthxy

                if (arg.EintragGruppe == EintragGruppe.Z)
                    arg.EvalStartDatum = DateTime.Now.AddDays(7);

                if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
                    AddZusatzInfoToM(arg);
                list.Add(arg);
            }
            args = (ASZMSelectionArgs[])list.ToArray(typeof(ASZMSelectionArgs));

            return args;
        }
        #endregion
        #region AddASZMToPDx
        private void AddASZMToPDx(PDxSelectionArgs pdxArg, bool generel)
        {
            dsPDxEintraege.PDXEintraegeRow[] rows;

            if (generel)
                rows = (dsPDxEintraege.PDXEintraegeRow[])_dsPDxEintraegeGenerel.PDXEintraege.Select("IDPDx = '" + pdxArg.IDPDX.ToString() + "'");
            else
                rows = (dsPDxEintraege.PDXEintraegeRow[])_dsPDxEintraegeSpecefic.PDXEintraege.Select("IDPDx = '" + pdxArg.IDPDX.ToString() + "'");

            if (rows != null)
            {
                ASZMSelectionArgs arg;
                List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();

                foreach (dsPDxEintraege.PDXEintraegeRow row in rows)
                {
                    arg = new ASZMSelectionArgs();
                    arg.StartDatum = DateTime.Now.Date;
                    arg.IDEintrag = row.IDEintrag;

                    if (!row.IsIDAbteilungNull())
                        arg.IDAbteilung = row.IDAbteilung;
                    else
                        arg.IDAbteilung = EnvPflegePlan.CurrentKlientenAbteilung; // Für den Fall das Einträge gesucht werden default mäßig mit der gewählten Abteilung die Zusatzwerte holen

                    arg.IDPDX = row.IDPDx;

                    arg.IDPDXEintrag = row.IDPDXEintrag;

                    if (!row.IsIDLinkDokumentNull())
                        arg.IDLinkDokument = row.IDLinkDokument;
                    else
                        arg.IDLinkDokument = Guid.Empty;

                    arg.Text = row.IsEintragTextNull() ? "" : row.EintragText;
                    arg.Klartext = row.IsTEXTNull() ? "" : row.TEXT;
                    arg.Sicht = row.IsSichtNull() ? "" : row.Sicht;
                    arg.Warnhinweis = row.IsWarnhinweisNull() ? "" : row.Warnhinweis;

                    arg.EintragGruppe = PDx.GetEintragGruppeFromChar(row.EintragGruppe[0]);
                    arg.LokalisierungJN = false;							// Default für ASZ
                    arg.OhneZeitBezug = row.OhneZeitBezug;

                    if (arg.EintragGruppe == EintragGruppe.Z)
                        arg.EvalStartDatum = DateTime.Now.AddDays(7);

                    if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
                        AddZusatzInfoToM(arg);
                    
                    Eintrag eint = new Eintrag();
                    dsEintrag.EintragDataTable eintragDataTable;
                    eintragDataTable = eint.Read(row.IDEintrag);
                    if (eintragDataTable.Count > 0)
                    {
                        if (eintragDataTable[0].EntferntJN)
                            continue;

                        arg.EintragFlag = eintragDataTable[0].flag;
                    }

                    list.Add(arg);
                }

                pdxArg.ARGS = list.ToArray();
            }
        }

        /// <summary>
        /// Eine Ätiologie, Symptom, Maßnahme oder ein Ziel zu eine PDX zuordnen 
        /// </summary>
        /// <param name="IDPdx"></param>
        /// <param name="IDEintrag"></param>
        /// <param name="gruppe"></param>
        /// <param name="demStandardHinzufuegen"></param>
        /// <param name="IDAbteilungen"></param>
        public void AddASZMToPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
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
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(arg.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existert bereits daher kann nicht hinzugefügt werden."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Eintrag existert bereits"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
        
        }
        #endregion
        #region AddZusatzInfoToM
        //----------------------------------------------------------------------------
        /// <summary>
        /// Füllt bei einem ASZMSelectionArgs die Maßnahmen Zusatzwerte auf
        /// </summary>
        //----------------------------------------------------------------------------
        private void AddZusatzInfoToM(ASZMSelectionArgs args)
        {
            if (args.EintragGruppe == EintragGruppe.M)					// Nur zu den Maßnahmen gibts Zusatzinfos
            {
                EintragZusatz ez = new EintragZusatz();

                dsEintragZusatz.EintragZusatzRow rz;
                rz = ez.Read(args.IDEintrag, args.IDAbteilung);		// Den zugehörigen ZusatzEinrag lesen mit der richtigen Abteilung
                if (rz == null)
                    rz = ez.Read(args.IDEintrag, Guid.Empty);			// Wenn keine Abteilung gefungen wurde dann mit der default lesen gehen

                if (rz == null)
                    throw new Exception(string.Format("Application Error: Cannot found EintragZusatz for IDEintrag {0} - IDAbteilung {1}", args.IDEintrag.ToString(), args.IDAbteilung.ToString()));

                args.Dauer = (!rz.IsDauerNull()) ? rz.Dauer : 0;
                args.EinmaligJN = (!rz.IsEinmaligJNNull()) ? rz.EinmaligJN : false;
                args.Intervall = (!rz.IsIntervallNull()) ? rz.Intervall : 0;
                args.EvalTage = (!rz.IsEvalTageNull()) ? rz.EvalTage : 0;
                args.IDBerufsstand = (!rz.IsIDBerufsstandNull()) ? rz.IDBerufsstand : Guid.Empty;
                args.IntervallTyp = (!rz.IsIntervallTypNull()) ? rz.IntervallTyp : 0;
                args.LokalisierungJN = (!rz.IsLokalisierungJNNull()) ? rz.LokalisierungJN : false;
                args.ParalellJN = (!rz.IsParalellJNNull()) ? rz.ParalellJN : false;

                if (!rz.IsWochenTageNull())
                    args.WochenTage = rz.WochenTage;
                args.RMOptionalJN = rz.RMOptionalJN;

                if (!rz.IsIDMassnahmenserienNull())
                {
                    args.UntertaegigBenutzerdefiniertJN = rz.IDMassnahmenserien == Guid.Empty ? true : false;			// signalisiert eine Benutzerdefinierte Eingabe
                    if (args.UntertaegigBenutzerdefiniertJN == false)
                    {
                        args.UNTERTAEGIG = GetUnterttaegigPoints(rz.IDMassnahmenserien);				// Die einzelnen Punkte verspeichern
                        args.ZEITBEREICH = null;
                    }
                }

                if (!rz.IsIDZeitbereichSerienNull())
                {
                    args.UntertaegigBenutzerdefiniertJN = rz.IDZeitbereichSerien == Guid.Empty ? true : false;			// signalisiert eine Benutzerdefinierte Eingabe

                    if (args.UntertaegigBenutzerdefiniertJN == false)
                    {
                        args.ZEITBEREICH = GetZeitbereichPoints(rz.IDZeitbereichSerien);				// Die einzelnen Punkte verspeichern
                        args.UNTERTAEGIG = null;
                    }

                }
                else if (!rz.IsIDZeitbereichNull())
                {
                    args.UntertaegigBenutzerdefiniertJN = rz.IDZeitbereich == Guid.Empty ? true : false;
                    if (args.UntertaegigBenutzerdefiniertJN == false)
                    {
                        args.ZEITBEREICH = new Guid[1];
                        args.ZEITBEREICH[0] = rz.IDZeitbereich;				// Die einzelnen Punkte verspeichern
                        args.UNTERTAEGIG = null;
                    }
                }
            }
        }
        #endregion

        #region RefreshASZMToPDXSELARGS
        private void RefreshASZMToPDXSELARGS()
        {
            if (_pdxSeArgs == null)
            {
                tvSpecific.PDX_SELARGS = null;
                tvGenerell.PDX_SELARGS = null;
                return;
            }

            List<PDxSelectionArgs> listSearchSpecific = new List<PDxSelectionArgs>();
            List<PDxSelectionArgs> listSearchGenerell = new List<PDxSelectionArgs>();

            List<Guid> listIDPDX = new List<Guid>();

            foreach (PDxSelectionArgs pdxARG in PDX_SELARGS)
            {
                listIDPDX.Add(pdxARG.IDPDX);

                dsPdxBezeichnung.Clear();
                dsPdxBezeichnung = _PDx.GetPDxFromSearchText(pdxARG.Klartext.Trim(), Condition);
                //Lokalisierung ünernehmen
                InsertListPDX(listSearchSpecific, listSearchGenerell, pdxARG);
            }

            tvSpecific.ListIDPDX = listIDPDX;
            tvSpecific.PDX_SELARGS = listSearchSpecific.ToArray();
            tvSpecific.ExpendAllTreeNodes();

            tvGenerell.ListIDPDX = listIDPDX;
            tvGenerell.PDX_SELARGS = listSearchGenerell.ToArray();
            tvGenerell.RemovePDxNodes(tvSpecific.GetPDxNodes());//Neu nach 18.05.2007 MDA
            tvGenerell.ExpendAllTreeNodes();
            SetFilter();
            ShowHideTabs();
        }
        #endregion
        #region HideSearchPanels
        private void HideSearchPanels()
        {
            pnlFavoriten.Visible = _Suchmode;
            pnlAnamnesen.Visible = _Suchmode;
            pnlSuche.Visible = _Suchmode;
            this.TabMain.Visible = _Suchmode;

            if (!_Suchmode)
            {
            }
            else
            {
                tabASZM.Width = ultraTabPageControl1.Width - (2 * tabASZM.Location.X);
                tabASZM.Height = ultraTabPageControl1.Height - pnlFavoriten.Height - 4;
            }
        }
        #endregion
        #region SetFilter
        private void SetFilter()
        {
            switch (KatalogEditMode)
            {
                case KatalogEditModes.All:
                    UpdateFilters(false);
                    break;
                case KatalogEditModes.A:
                    HideOrShowEintragGruppe("A", false);
                    HideOrShowEintragGruppe("S", true);
                    HideOrShowEintragGruppe("R", true);
                    HideOrShowEintragGruppe("Z", true);
                    HideOrShowEintragGruppe("M", true);
                    break;
                case KatalogEditModes.S:
                    HideOrShowEintragGruppe("A", true);
                    HideOrShowEintragGruppe("S", false);
                    HideOrShowEintragGruppe("R", true);
                    HideOrShowEintragGruppe("Z", true);
                    HideOrShowEintragGruppe("M", true);
                    break;
                case KatalogEditModes.R:
                    HideOrShowEintragGruppe("A", true);
                    HideOrShowEintragGruppe("S", true);
                    HideOrShowEintragGruppe("R", false);
                    HideOrShowEintragGruppe("Z", true);
                    HideOrShowEintragGruppe("M", true);
                    break;
                case KatalogEditModes.Z:
                    HideOrShowEintragGruppe("A", true);
                    HideOrShowEintragGruppe("S", true);
                    HideOrShowEintragGruppe("R", true);
                    HideOrShowEintragGruppe("Z", false);
                    HideOrShowEintragGruppe("M", true);
                    break;
                case KatalogEditModes.M:
                    HideOrShowEintragGruppe("A", true);
                    HideOrShowEintragGruppe("S", true);
                    HideOrShowEintragGruppe("R", true);
                    HideOrShowEintragGruppe("Z", true);
                    HideOrShowEintragGruppe("M", false);
                    break;
            }
        }
        #endregion
        #region MarkAll
        private void MarkAll(bool bSelect)
        {
            try
            {
                Cursor = Cursors.WaitCursor ;
            if (tabASZM.SelectedTab == TAB_SPECIFIC)
                tvSpecific.SelectAllTreeNodes(bSelect);
            else if (tabASZM.SelectedTab == TAB_GENERELL)
                tvGenerell.SelectAllTreeNodes(bSelect);


                        }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion
        #region SetBtnAddMissingASZMEnabled
        private void SetBtnAddMissingASZMEnabled()
        {
            ucASZMSelectorTreeView2 uc = null;
            if (tabASZM.ActiveTab == TAB_SPECIFIC)
                uc = tvSpecific;
            else if (tabASZM.ActiveTab == TAB_GENERELL)
                uc = tvGenerell;
            if (uc == null || uc.ActiveKatalogEditModes == KatalogEditModes.All)
            {
                this.mainWindow.pnlAddPlDef3.Visible = false;
                    this.mainWindow.btnAddMissingASZM3.Visible = false;
                return;
            }

            this.mainWindow.btnAddMissingASZM3.Text = uc.ActiveKatalogEditModes.ToString() + " +";
            this.mainWindow.pnlAddPlDef3.Visible = true;
            this.mainWindow.btnAddMissingASZM3.Visible = true;
        }
        #endregion
        #region SetPDxKatalogEditModes
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
        #endregion
        #region EnableOkCancelButtons
        public void EnableOkCancelButtons(bool enabled)
        {
            btnOk.Enabled = enabled;
            btnCancel.Enabled = enabled;
        }
        #endregion
        #region ExistPDxEintrag
        private bool ExistPDxEintrag(ASZMSelectionArgs[] args, ASZMSelectionArgs arg)
        {
            foreach (ASZMSelectionArgs a in args)
            {
                if (a.Text.Trim() == arg.Text.Trim())
                    return true;
            }

            return false;
        }
        #endregion
        #region GetASZMArg
        private ASZMSelectionArgs GetASZMArg(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe)
        {
            ASZMSelectionArgs arg = null;
            dsEintrag.EintragDataTable t1 = new Eintrag().Read(IDEintrag);

            if (t1.Rows.Count > 0)
            {
                dsEintrag.EintragRow r = t1[0];
                arg = new ASZMSelectionArgs();
                arg.IDEintrag = IDEintrag;
                arg.IDAbteilung = EnvPflegePlan.CurrentKlientenAbteilung;
                arg.IDPDX = IDPdx;
                arg.IDLinkDokument = r.IsIDLinkDokumentNull() ? Guid.Empty : r.IDLinkDokument;
                arg.Text = r.IsTextNull() ? "" : r.Text;
                arg.Sicht = r.IsSichtNull() ? "" : r.Sicht;
                arg.Warnhinweis = r.IsWarnhinweisNull() ? "" : r.Warnhinweis;
                arg.EintragGruppe = gruppe;
                arg.LokalisierungJN = false;							// Default für ASZ
                arg.OhneZeitBezug = r.OhneZeitBezug;
                arg.EintragFlag = r.flag;

                if (arg.EintragGruppe == EintragGruppe.M)			   // Nur zu den Maßnahmen gibts Zusatzinfos
                {
                    AddZusatzInfoToM(arg);
                }

                if (arg.EintragGruppe == EintragGruppe.Z)
                    arg.EvalStartDatum = DateTime.Now.AddDays(7);

                arg.EintragFlag     = r.flag;
            }

            return arg;
        }
        #endregion
        #region AddASZMToTreeNode
        private void AddASZMToTreeNode(UltraTreeNode tn)
        {
            ucASZMSelectorTreeView2 uc = null;
            if (tabASZM.ActiveTab == TAB_SPECIFIC)
                uc = tvSpecific;
            else if (tabASZM.ActiveTab == TAB_GENERELL)
                uc = tvGenerell;

            if (tn.Tag != null && tn.Tag is PDxSelectionArgs)
            {
                PDxSelectionArgs pdxArg = (PDxSelectionArgs)tn.Tag;

                if (pdxArg.ARGS == null || pdxArg.ARGS.Length == 0)
                {
                    AddASZMToPDx(pdxArg, tabASZM.ActiveTab == TAB_GENERELL);
                    uc.RefreshPDxTreeNode(tn);
                }
            }
        }
        #endregion
        #region UpdateActivPDxTreeNodeImage
        public void UpdateActivPDxTreeNodeImage()
        {
            if (tabASZM.ActiveTab == TAB_SPECIFIC)
                tvSpecific.UpdateActivPDxTreeNodeImage();
            else if (tabASZM.ActiveTab == TAB_GENERELL)
                tvGenerell.UpdateActivPDxTreeNodeImage();
        }
        #endregion
        #region InitSaershControls
        private void InitSaershControls()
        {
            cbTop10.ActiveRow = null;
            cbTop10Allgemein.ActiveRow = null;
            cbAnamnesen.ActiveRow = null;
            tbSearch.Clear();
        }
        #endregion

        #region Events
        private void cbTop10_AfterCloseUp(object sender, EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning) return;
            UltraCombo c = (UltraCombo)sender;
            if (c.ActiveRow == null) return;
            
            if (c.Equals(cbTop10Allgemein) || c.Equals(cbAnamnesen))
            {
                tabASZM.SelectedTab = tabASZM.Tabs["Generell"];

                if (c.Equals(cbTop10Allgemein))
                {
                    cbTop10.ActiveRow = null;
                    cbTop10.Value = null;
                }
            }
            else
            {
                tabASZM.SelectedTab = tabASZM.Tabs["Abteilung"];
                cbTop10Allgemein.ActiveRow = null;
                cbTop10Allgemein.Value = null;
            }


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

        private void cbTop10_BeforeDropDown(object sender, CancelEventArgs e)
        {
            UltraCombo c = (UltraCombo)sender;
            c.DisplayLayout.Bands[0].Columns[c.DisplayMember].Width = c.Width;
            c.DisplayLayout.Bands[0].ColHeadersVisible = false;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.F3) && tbSearch.Text.Trim() != "")
            {
                InitErrorProvider();

                if (ValidateFields())
//                    _PflegePlanModus = PflegePlanModus.NormalAktiv;
                    RefreshASZMSearch();
            }
        }



        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            MarkAll(true);
        }

        private void btnSelectNo_Click(object sender, EventArgs e)
        {
            MarkAll(false);
        }

        private void ucPDxSearch2_Load(object sender, EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning) return;

            _PDx = new PDx();
            _pdxAnamnese.Read();
            cbTop10.DisplayLayout.Bands[0].ColHeadersVisible = false;
            cbTop10.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            cbTop10Allgemein.DisplayLayout.Bands[0].ColHeadersVisible = false;
            cbTop10Allgemein.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;

            cbAnamnesen.DisplayLayout.Bands[0].ColHeadersVisible = false;
            cbAnamnesen.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;

            RefreshTop10Combo();
        }

        private void tv_TreeviewAfterNodeSelectEventHandler(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            SetBtnAddMissingASZMEnabled();
            if (TreeviewAfterNodeSelectEventHandler != null)
                TreeviewAfterNodeSelectEventHandler(this, e);
        }

        private void tv_TreeviewBeforeNodeSelectEventArgs(object sender, Infragistics.Win.UltraWinTree.BeforeSelectEventArgs e)
        {
            if (TreeviewBeforeNodeSelectEventArgs != null)
                TreeviewBeforeNodeSelectEventArgs(this, e);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// </summary>
        //----------------------------------------------------------------------------
        void frm_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            AddASZMToPDx(IDPdx, IDEintrag, gruppe, demStandardHinzufuegen, IDAbteilungen);

        }

        private void ucPDxSearch_VisibleChanged(object sender, EventArgs e)
        {
            InitSaershControls();
        }

        private void tv_TreeviewBeforeNodeChangedEventHandler(object sender, Infragistics.Win.UltraWinTree.CancelableNodeEventArgs e)
        {
            AddASZMToTreeNode(e.TreeNode);
        }

        private void tv_TreeviewBeforeCheckEventHandler(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
        {
            AddASZMToTreeNode(e.TreeNode);
        }

        private void TabMain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            //if (DesignMode || !ENV.AppRunning) return;
            RefreshTopcombo = false;
             RefreshControl();
        }

        private void tabASZM_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (DesignMode || !ENV.AppRunning) return;
            UltraTreeNode tn;

            if (tabASZM.SelectedTab == TAB_SPECIFIC)
            {
                tn = tvSpecific.AktivNode;
                tn.Selected = false;
                tvSpecific.AktivNode = null;
                tvSpecific.AktivNode = tn;
                tvSpecific.AktivNode.Selected = true;
            }
            else if (tabASZM.SelectedTab == TAB_GENERELL)
            {
                tn = tvGenerell.AktivNode;
                tn.Selected = false;
                tvGenerell.AktivNode = null;
                tvGenerell.AktivNode = tn;
                tvGenerell.AktivNode.Selected = true;
            }
        }
        #endregion
        
        private void tbSearch_ValueChanged(object sender, EventArgs e)
        {

        }
        private void btnPDx_Click(object sender, EventArgs e)
        {
            if (pflegeplanÄndern != null)
                this.pflegeplanÄndern("N");
        }
        private void btnEndPDx_Click(object sender, EventArgs e)
        {
            if (pflegeplanÄndern != null)
                this.pflegeplanÄndern("ASZM_Löschen");
        }
        public  void btnAddMissingASZM2()
        {
            this.Cursor = Cursors.WaitCursor;

            PDxSelectionArgs pdxSarg = null;
            KatalogEditModes editMode = KatalogEditModes.All;

            SetPDxKatalogEditModes(ref pdxSarg, ref editMode);

            if (UsePopupToAddASZM)
            {
                if (pdxSarg != null && editMode != KatalogEditModes.All)
                {
                    frmAdditionalASZMtoPDx frm = new frmAdditionalASZMtoPDx(editMode, pdxSarg.IDPDX);
                    frm.ASZMtoPDx += new ASZMtoPDxDelegate(frm_ASZMtoPDx);
                    frm.ShowDialog();
                }
            }
            else if (AddNewASZM != null)
                {AddNewASZM(pdxSarg.IDPDX, editMode);}
            
            this.Cursor = Cursors.Default;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (PDXSelected == null)
                                return;
                        PDxSelectionArgs[] pdxArgs = null;

                if (tabASZM.SelectedTab == TAB_SPECIFIC)
                        pdxArgs = tvSpecific.GetSelectedPDxSelectionArgs();
                    else if (tabASZM.SelectedTab == TAB_GENERELL)
                        pdxArgs = tvGenerell.GetSelectedPDxSelectionArgs();

                    if (pdxArgs == null || pdxArgs.Length == 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Einträge ausgewählt.");
                        return;
                    }
                    else if (_PflegePlanModus == PflegePlanModus.Wunde)
                    {
                        List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
                        foreach (PDxSelectionArgs arg in pdxArgs)
                        {
                            if (arg.Lokalisierung == null || arg.Lokalisierung.Trim() == "" ||
                            arg.LokalisierungSeite == null || arg.LokalisierungSeite.Trim() == "")
                            list.Add(arg);
                    }

                    if (list.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Lokalisierung und Lokalisierungseite für folgende PDx'en hinzufügen.\n\t"));
                        foreach (PDxSelectionArgs arg in list)
                            sb.Append("- " + arg.Klartext + "\n\t");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), true);
                        return;
                    }
             }
            
             if (PDXSelected != null)
                    { PDXSelected(pdxArgs); }
             this.mainWindow.panelButtonsRechtsUnten.Visible = true;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (PDXSelected != null)
                    { PDXSelected(null); }
                this.mainWindow.panelButtonsRechtsUnten.Visible = true;
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


    }
}
