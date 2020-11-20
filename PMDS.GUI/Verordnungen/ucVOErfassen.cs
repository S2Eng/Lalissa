using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Global.db.ERSystem;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinToolTip;
using System.Data.OleDb;
using PMDS.GUI.VB;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOErfassen : UserControl
    {
        public Nullable<Guid> _IDAufenthalt = null;
        public Nullable<Guid> _IDPflegeplan = null;
        public Nullable<Guid> _IDMedDaten = null;
        public Nullable<Guid> _IDWundeKopf = null;
        
        List<Guid> _lstIDVONotShow = null;
        public bool _Einzelansicht = false;
        public bool _doVerknüpfungen = false;

        public bool abort = true;
        public bool IsInitialized = false;
        public PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI _TypeUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI();

        public frmVOErfassen mainWindow = null;
        public frmVOMain mainWindowVerwaltung = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();

        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;

        public string colKlient = "Klient";
        public string colMedikament = "Medikament";
        public string colTyp = "TypStr";
        public string colSignatur = "Signatur";
        public string colSelect = "Select";
        public string colInfoMedDaten = "InfoMedDaten";
        public string colInfoPflegeplanPDx = "InfoPflegeplanPDx";
        public string colInfoWundeKopf = "InfoWundeKopf";
        public string colKrankenkasse = "Krankenkasse";
        public string colSozVers = "SozVers";
        public string colLieferantBeschreibung = "LieferantBeschreibung";
        public string colBenutzerErstellt = "BenutzerErstellt";
        public string colBenutzerGeändert = "BenutzerGeändert";

        public bool _ModusChanged = true;

        public contSelectSelList contSelectSelListTyp = new contSelectSelList();
        public bool rightVOAdd  = false;
        public bool rightVODelete = false;
        public bool rightAddVOBestelldaten = false;
        public bool rightAddVOBestelldatenEinmaligeAnforderung = false;

        public List<PMDS.db.Entities.AuswahlListe> lstLieferanten = null;









        public ucVOErfassen()
        {
            InitializeComponent();
        }

        private void ucVOErfassen_Load(object sender, EventArgs e)
        {

        }

        public void initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI TypeUI, bool Einzelansicht, bool doVerknüpfungen, List<Guid> lstIDVONotShow)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                if (!this.IsInitialized)
                {
                    this._Einzelansicht = Einzelansicht;
                    this._TypeUI = TypeUI;
                    this._doVerknüpfungen = doVerknüpfungen;
                    this._lstIDVONotShow = lstIDVONotShow;

                    this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                    this.btnAddVO.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnAddVOVerknüpfung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verknüpfen_03, 32, 32);
                    this.btnAddVOBestelldaten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnAddVOBestelldatenEinmaligeAnforderung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                    this.btnDelBestelldaten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                    this.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                    this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verknüpfen_03, 32, 32);
                    this.layoutmanagerToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                    this.btnMedikamente.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Medikamente_01, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnMedDaten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Medizinische_Daten, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnWunde.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Wunden_02, QS2.Resources.getRes.ePicTyp.ico);

                    UltraToolTipInfo info2 = new UltraToolTipInfo();
                    info2.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verknüpfung hinzufügen");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnAddVOVerknüpfung, info2);

                    this.ucLager1.initControl(ucLager.eTypeUI.IDVO);

                    this.SelListChanged("", null, null);

                    if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten)
                    {
                        //int diff = 50;

                        //this.btnAddVO.Size = new Size(157, 27);
                        //this.btnAddVO.Location = new Point(870 - diff, 4);

                        //this.btnAddVOBestelldaten.Size = new Size(157, 27);
                        //this.btnAddVOBestelldaten.Location = new Point(870 - diff, 31);

                        //this.btnDel.Size = new Size(28, 27);
                        //this.btnDel.Location = new Point(1027 - diff, 4);

                        //this.btnPrint.Size = new Size(79, 27);
                        //this.btnPrint.Location = new Point(761 - diff, 31);

                        //this.btnAddVO.Appearance.FontData.SizeInPoints = 8;
                        //this.btnAddVOBestelldaten.Appearance.FontData.SizeInPoints = 8;
                        //this.btnDel.Appearance.FontData.SizeInPoints = 8;
                        //this.btnPrint.Appearance.FontData.SizeInPoints = 8;
                    }


                    this.sqlVO1.initControl();
                    this.sqlManange1.initControl();

                    UltraToolTipInfo info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung hinzufügen");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnAddVO, info);

                    info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestelldaten zur Verordnung hinzufügen");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnAddVOBestelldaten, info);

                    info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einmalige Anforderung zur Verordnung hinzufügen");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnAddVOBestelldatenEinmaligeAnforderung, info);

                    info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnMedikamente, info);

                    info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinische Daten");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnMedDaten, info);

                    info = new UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden");
                    this.ultraToolTipManager1.SetUltraToolTip(this.btnWunde, info);

                    this.gridVOBestelldaten.Name = "gridVObestellungenVerwaltung";
                    
                    this.btnMedikamente.Visible = false;
                    this.btnMedDaten.Visible = false;
                    this.btnWunde.Visible = false;
                    if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten)
                    {
                        this.gridVO.Name = "gridVOErfassenKlientStammdaten";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassenKlientStammdaten";
                        this.btnMedikamente.Visible = true;
                        this.btnMedDaten.Visible = true;
                        this.btnWunde.Visible = true;
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten)
                    {
                        this.gridVO.Name = "gridVOErfassungMedDaten";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassungMedDaten";
                        if (!this._doVerknüpfungen)
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu medizinische Daten");
                        else
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu medizinische Daten");
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2)
                    {
                        this.gridVO.Name = "gridVOErfassenPlanung";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassenPlanung";
                        if (!this._doVerknüpfungen)
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Maßnahme");
                        else
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Maßnahme");
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde)
                    {
                        this.gridVO.Name = "gridVOErfassenWunde";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassenWunde";
                        if (!this._doVerknüpfungen)
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Wunde");
                        else
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Wunde");
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                    {
                        this.gridVO.Name = "gridVOErfassenPlanungOnlyShow";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassenPlanungOnlyShow";
                        if (!this._doVerknüpfungen)
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Maßnahme");
                        else
                            this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Maßnahme");
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        this.gridVO.Name = "gridVOErfassenVerwaltung";
                        this.gridVOBestelldaten.Name = "gridVOBestelldatenErfassenVerwaltung";
                        this.mainWindowVerwaltung.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwaltung Verordnungen");
                    }
                    else
                    {
                        throw new Exception("ucVOErfassen.initControl: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                    }

                    if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2)
                    {
                        this.btnClose.Visible = false;
                    }

                    if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2 || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                    {
                        this.panelTop.Height = 61;
                        btnVOSchein.Top =  btnAddVOVerknüpfung.Top;
                        this.grpSearch.Visible = false;
                        if (!PMDS.Global.ENV.adminSecure)
                        {
                            //this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Hidden = true;
                        }
                    }
                    else if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        this.grpSearch.Visible = true;
                        btnVOSchein.Top = btnAddVO.Top;
                    }
                    else
                    {
                        throw new Exception("ucVOErfassen.initControl: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                    }

                    this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                    bool IsSearch = true;
                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients,  false,  isTxtTemplate, this.dropDownPatienten);
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatientenBenutzer1;
                    this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                    this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = true;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    bool IDFoundInTree2 = false;
                    this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(System.Guid.Empty, System.Guid.Empty, false, null, true, VB.contPlanungData.eTypeUI.PlansAll, ref IDFoundInTree2);
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    //if (this._Einzelansicht && this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    //{
                    //    if (ENV.CurrentIDPatient != System.Guid.Empty)
                    //    {
                    //        this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(ENV.CurrentIDPatient);
                    //        this.contSelectPatientenBenutzer1.setLabelCount2();
                    //    }
                    //}

                    //this.contSelectSelListTyp.MainPlanSearch = this;
                    this.contSelectSelListTyp.initControl("VOT", true, false, this.dropDownTyp, true, "Typ", "Typ wählen", false);
                    this.uPopupContTyp.PopupControl = this.contSelectSelListTyp;
                    this.dropDownTyp.PopupItem = this.uPopupContTyp;
                    this.contSelectSelListTyp.popupContMainSearch = this.uPopupContTyp;

                    this.rightVOAdd = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOHinzufügen);
                    this.rightVODelete = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOLöschen);
                    this.btnAddVO.Visible = this.rightVOAdd;
                    this.btnDel.Visible = this.rightVODelete;
                    this.btnDelBestelldaten.Visible = true;

                    this.rightAddVOBestelldaten = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOBestellung);
                    this.rightAddVOBestelldatenEinmaligeAnforderung = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOBestellungEinmalig);
                    if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                    {
                        this.ansichtErweiternToolStripMenuItem.Visible = true;
                        this.ansichtReduzierenToolStripMenuItem.Visible = true;
                        this.btnAddVOBestelldaten.Visible = this.rightAddVOBestelldaten;
                        this.btnAddVOBestelldatenEinmaligeAnforderung.Visible = this.rightAddVOBestelldatenEinmaligeAnforderung;
                    }
                    else
                    {
                        this.ansichtErweiternToolStripMenuItem.Visible = false;
                        this.ansichtReduzierenToolStripMenuItem.Visible = false;
                        this.btnAddVOBestelldaten.Visible = this.rightAddVOBestelldaten;
                        this.btnAddVOBestelldatenEinmaligeAnforderung.Visible = this.rightAddVOBestelldatenEinmaligeAnforderung;
                    }

                    if (!this._doVerknüpfungen && (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2 || this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde))
                    {
                        this.btnAddVOVerknüpfung.Visible = true;
                        this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Visible = false;
                        this.toolStripMenuItemSpace01.Visible = true;
                        this.splitContainerCenter.Panel2Collapsed = true;
                    }
                    else
                    {
                        this.btnAddVOVerknüpfung.Visible = false;
                        this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Visible = false;
                        this.toolStripMenuItemSpace01.Visible = false;
                    }

                    if (!this._doVerknüpfungen && (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten))
                    {
                    }
                    else
                    {
                    }

                    if (this._doVerknüpfungen)
                    {
                        this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                        this.contSelectPatientenBenutzer1.Visible = false;
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Hidden = false;
                        this.btnSave.Visible = true;
                        this.btnAbort.Visible = true;
                        this.btnClose.Visible = false;
                        this.btnAddVO.Visible = false;
                        this.btnAddVOBestelldaten.Visible = false;
                        this.btnAddVOBestelldatenEinmaligeAnforderung.Visible = false;
                        this.btnDel.Visible = false;
                        this.btnDelBestelldaten.Visible = false;
                        this.chkNurAktuelle.Checked = false;
                        this.chkNurAktuelle.Visible = false;
                        this.splitContainerCenter.Panel2Collapsed = true;
                        if (this.mainWindow != null)
                        {
                            this.mainWindow.Height -= 70;
                            this.mainWindow.Width -= 70;
                        }
                    }
                    else
                    {
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Hidden = true;
                        this.btnSave.Visible = false;
                        this.btnAbort.Visible = false;
                    }

                    if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                    {
                        this.btnAddVO.Visible = false;
                        this.btnAddVOBestelldaten.Visible = false;
                        this.btnAddVOBestelldatenEinmaligeAnforderung.Visible = false;
                        this.btnDel.Visible = false;
                        this.btnDelBestelldaten.Visible = false;
                    }

                    //this.chkBestelldaten2.Visible = false;
                    this.clearUI();
                    this.setUIGrid(false);
                    this.setUIGrid(true);

                    PMDSBusinessUI.dSelListChanged += new PMDSBusinessUI.SelListChanged(this.SelListChanged);

                    this.IsInitialized = true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.initControl: " + ex.ToString());
            }
        }

        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty2 = null;
                this.PMDSBusinessUI2.loadSelList("LAZ", this.cboZustand, null, null, ref lstEmpty2);

                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.PMDSBusinessUI2.loadSelList("VOT", null, this.gridVO.DisplayLayout.ValueLists["Typ"], null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("LFT", null, this.gridVO.DisplayLayout.ValueLists["Lieferant"], null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("VOT", null, this.gridVOBestelldaten.DisplayLayout.ValueLists["Typ"], null, ref lstEmpty);

                this.lstLieferanten = new List<AuswahlListe>();
                this.PMDSBusinessUI2.loadSelList("LFT", null, this.gridVO.DisplayLayout.ValueLists["Lieferant"], null, ref this.lstLieferanten);
                this.PMDSBusinessUI2.loadSelList("LFT", null, this.gridVOBestelldaten.DisplayLayout.ValueLists["Lieferant"], null, ref lstEmpty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.SelListChanged: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                if (this.contSelectPatientenBenutzer1 != null)
                {
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                }
                this.udteVerordnetAb.Value = null;
                this.udteVerordnetBis.Value = null;
                if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                {
                    this.udteVerordnetAb.DateTime = DateTime.Now.Date;
                    this.udteVerordnetBis.Value = DateTime.Now.Date.AddDays(7);
                    this.chkNurAktuelle.Checked = true;
                }
                else
                {
                    this.chkNurAktuelle.Checked = false;
                }
                this.setUIFromTo(this.chkNurAktuelle.Checked);

                this.contSelectSelListTyp.setSelectionOnOff(false);

                this.lblFound.Text = "";

                if (this._doVerknüpfungen)
                {
                    this.udteVerordnetAb.Value = null;
                    this.udteVerordnetBis.Value = null;
                }
                
                this.ultraTabControl1.Tabs["Lager"].Visible = ENV.lic_VOLager;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.clearUI: " + ex.ToString());
            }
        }
        public void setUIFromTo(bool NurAktuelle)
        {
            try
            {
                if (NurAktuelle)
                {
                    this.udteVerordnetAb.Enabled = false;
                    this.udteVerordnetBis.Enabled = false;
                }
                else
                {
                    this.udteVerordnetAb.Enabled = true;
                    this.udteVerordnetBis.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.setUIFromTo: " + ex.ToString());
            }
        }

        public void setUIGrid(bool doVOBestelldaten)
        {
            try
            {
                if (doVOBestelldaten)
                {
                    foreach (UltraGridColumn col in this.gridVO.DisplayLayout.Bands[0].Columns)
                    {
                        col.Hidden = true;
                    }
                    this.gridVO.DisplayLayout.Bands[1].Hidden = true;

                    this.lblVerordnetAb.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnet ab");
                    this.lblVerordnetBis.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnet bis");

                    if (this._doVerknüpfungen)
                    {
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Hidden = false;
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Width = 60;
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        this.gridVO.DisplayLayout.Bands[0].Columns[this.colSelect.Trim()].Header.VisiblePosition = 0;
                    }

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Width = 180;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Header.VisiblePosition = 1;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].Width = 200;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].ValueList = this.gridVO.DisplayLayout.ValueLists["Typ"];
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.TypColumn.ColumnName].Header.VisiblePosition = 2;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName].Width = 100;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName].Header.VisiblePosition = 3;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName].Width = 100;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName].Header.VisiblePosition = 4;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Width = 250;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Header.VisiblePosition = 5;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.MengeColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.MengeColumn.ColumnName].Width = 100;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.MengeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.MengeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.MengeColumn.ColumnName].Header.VisiblePosition = 6;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.HinweisColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.HinweisColumn.ColumnName].Width = 300;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.HinweisColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.HinweisColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.HinweisColumn.ColumnName].Header.VisiblePosition = 7;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Width = 150;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Header.VisiblePosition = 8;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Width = 150;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.BestaetigtVonColumn.ColumnName].Header.VisiblePosition = 8;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.LieferantColumn.ColumnName].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.LieferantColumn.ColumnName].Width = 150;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.LieferantColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.LieferantColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.dsVO1.VO.LieferantColumn.ColumnName].Header.VisiblePosition = 8;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Width = 120;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Header.VisiblePosition = 9;       

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoMedDaten.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoMedDaten.Trim()].Width = 250;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoMedDaten.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoMedDaten.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoMedDaten.Trim()].Header.VisiblePosition = 10;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoPflegeplanPDx.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoPflegeplanPDx.Trim()].Width = 250;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoPflegeplanPDx.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoPflegeplanPDx.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoPflegeplanPDx.Trim()].Header.VisiblePosition = 11;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoWundeKopf.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoWundeKopf.Trim()].Width = 250;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoWundeKopf.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoWundeKopf.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colInfoWundeKopf.Trim()].Header.VisiblePosition = 12;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKrankenkasse.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKrankenkasse.Trim()].Width = 150;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKrankenkasse.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKrankenkasse.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colKrankenkasse.Trim()].Header.VisiblePosition = 13;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colSozVers.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colSozVers.Trim()].Width = 120;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colSozVers.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colSozVers.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colSozVers.Trim()].Header.VisiblePosition = 14;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerErstellt.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerErstellt.Trim()].Width = 120;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerErstellt.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerErstellt.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerErstellt.Trim()].Header.VisiblePosition = 15;

                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerGeändert.Trim()].Hidden = false;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerGeändert.Trim()].Width = 120;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerGeändert.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerGeändert.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVO.DisplayLayout.Bands[0].Columns[this.colBenutzerGeändert.Trim()].Header.VisiblePosition = 16;


                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Add(this.colKlient.Trim(), true);
                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO.TypColumn.ColumnName, false);
                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO.DatumVerordnetAbColumn.ColumnName, true);
                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO.DatumVerordnetBisColumn.ColumnName, true);
                    this.gridVO.DisplayLayout.Bands[0].SortedColumns.Add(this.colMedikament.Trim(), true);

                    if (!this._doVerknüpfungen && this._TypeUI != PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                    {
                        this.btnAddVO.Visible = this.rightVOAdd;
                    }
                    if (this._TypeUI != PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                    {
                        this.btnAddVOBestelldaten.Visible = this.rightAddVOBestelldaten;
                        this.btnAddVOBestelldatenEinmaligeAnforderung.Visible = this.rightAddVOBestelldatenEinmaligeAnforderung;
                    }
                }
                else
                {
                    foreach (UltraGridColumn col in this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns)
                    {
                        col.Hidden = true;
                    }

                    //this.lblVerordnetAb.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig ab");
                    //this.lblVerordnetBis.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig bis");

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Width = 180;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colKlient.Trim()].Header.VisiblePosition = 0;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn .ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName].Width = 200;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName].ValueList = this.gridVOBestelldaten.DisplayLayout.ValueLists["Typ"];
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName].Header.VisiblePosition = 1;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Width = 250;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colMedikament.Trim()].Header.VisiblePosition = 2;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName].Width = 100;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName].Header.VisiblePosition = 3;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigBisColumn .ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigBisColumn.ColumnName].Width = 100;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigBisColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigBisColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.GueltigBisColumn.ColumnName].Header.VisiblePosition = 4;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.MengeColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.MengeColumn.ColumnName].Width = 100;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.MengeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.MengeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.MengeColumn.ColumnName].Header.VisiblePosition = 5;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EinheitColumn .ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EinheitColumn.ColumnName].Width = 100;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EinheitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EinheitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EinheitColumn.ColumnName].Header.VisiblePosition = 6;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].Width = 150;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].Header.VisiblePosition = 7;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.LieferantColumn.ColumnName].ValueList = this.gridVOBestelldaten.DisplayLayout.ValueLists["Lieferant"];

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Width = 120;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.colLieferantBeschreibung.Trim()].Header.VisiblePosition = 8;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DauerbestellungColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DauerbestellungColumn.ColumnName].Width = 150;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DauerbestellungColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DauerbestellungColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DauerbestellungColumn.ColumnName].Header.VisiblePosition = 9;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.AnmerkungColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.AnmerkungColumn.ColumnName].Width = 240;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.AnmerkungColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.AnmerkungColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.AnmerkungColumn.ColumnName].Header.VisiblePosition = 10;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EigentumKlientColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EigentumKlientColumn.ColumnName].Width = 100;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EigentumKlientColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EigentumKlientColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.EigentumKlientColumn.ColumnName].Header.VisiblePosition = 11;

                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].Hidden = false;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].Width = 190;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].Header.VisiblePosition = 12;
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].Columns[this.dsVO1.VO_Bestelldaten.DatumNaechsterAnspruchColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum nächster Anspruch");



                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Add(this.colKlient.Trim(), true);
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO_Bestelldaten.TypColumn.ColumnName, false);
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Add(this.colMedikament.Trim(), true);
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO_Bestelldaten.GueltigAbColumn.ColumnName, true);
                    this.gridVOBestelldaten.DisplayLayout.Bands[0].SortedColumns.Add(this.dsVO1.VO_Bestelldaten.GueltigBisColumn.ColumnName, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.setUIGrid: " + ex.ToString());
            }
        }

        public void doLayoutVO(ref bool LayoutFound)
        {
            try
            {
                Application.DoEvents();

                //qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                //compLayout1.initControl();
                //compLayout1.doLayoutGrid(this.gridVO, this.gridVO.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);

                QS2.Desktop.ControlManagment.cLayoutManager2 cLayoutManager1 = new QS2.Desktop.ControlManagment.cLayoutManager2();
                cLayoutManager1.doLayoutGrid(this.gridVO, this.gridVO.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                
                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.gridVO);
                this.gridVO.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.DoLayoutVO: " + ex.ToString());
            }
        }
        public void doLayoutVOBestelldaten(ref bool LayoutFound)
        {
            try
            {
                qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                compLayout1.initControl();

                QS2.Desktop.ControlManagment.cLayoutManager2 cLayoutManager1 = new QS2.Desktop.ControlManagment.cLayoutManager2();
                cLayoutManager1.doLayoutGrid(this.gridVOBestelldaten, this.gridVOBestelldaten.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);

                //compLayout1.doLayoutGrid(this.gridVOBestelldaten, this.gridVOBestelldaten.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                //QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.gridVOBestelldaten);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.doLayoutVOBestelldaten: " + ex.ToString());
            }
        }

        public void search2(Nullable<Guid> IDAufenthalt, Nullable<Guid> IDPflegeplan, Nullable<Guid> IDMedDaten, Nullable<Guid> IDWundeKopf)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                this._IDAufenthalt = IDAufenthalt;
                this._IDPflegeplan = IDPflegeplan;
                this._IDMedDaten = IDMedDaten;
                this._IDWundeKopf = IDWundeKopf;

                this.dsVO1.VO_Bestelldaten.Clear();
                this.gridVOBestelldaten.Refresh();

                this.dsVO1.VO.Clear();
                this.ucLager1.clearUIGrid();

                Nullable<DateTime> dFrom = null;
                if (this.udteVerordnetAb.Value != null)
                {
                    dFrom = this.udteVerordnetAb.DateTime.Date;
                }

                Nullable<DateTime> dTo = null;
                if (this.udteVerordnetBis.Value != null)
                {
                    dTo = this.udteVerordnetBis.DateTime.Date;
                }

                string sLagerZustand = "";
                if (this.cboZustand.Text.ToString().Trim() != "")
                {
                    sLagerZustand = this.cboZustand.Text.Trim();
                }

                System.Collections.Generic.List<Guid> lstSelectedTyp = new List<Guid>();
                this.contSelectSelListTyp.getSelectedIDs(ref lstSelectedTyp);

                List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();
                string sWherePatients = "";
                if (lstPatients.Count > 0)
                {
                    string sWherePatientsTmp = "";
                    foreach (Guid IDPatient in lstPatients)
                    {
                        sWherePatientsTmp += (sWherePatientsTmp.Trim() == "" ? "" : " or ") + " Aufenthalt.IDPatient='" + IDPatient.ToString() + "' ";
                    }
                    sWherePatients = " VO.IDAufenthalt IN (Select Aufenthalt.ID from Aufenthalt where Entlassungszeitpunkt is null and (" + sWherePatientsTmp + "))";
                    //sWherePatients = " VO_Bestelldaten.IDVerordnung IN (Select VO.ID from VO where VO.IDAufenthalt IN (Select Aufenthalt.ID from Aufenthalt where Entlassungszeitpunkt is null and (" + sWherePatientsTmp + ")))";
                }

                this.sqlVO1.getVO(null, sqlVO.eSelVO.Search, ref this.dsVO1, dFrom, dTo, null, sWherePatients, this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf, this.chkNurAktuelle.Checked, this._TypeUI, 
                                    this._doVerknüpfungen, ref lstSelectedTyp, ref this._lstIDVONotShow, sLagerZustand);
                this.gridVO.Refresh();
                
                string sWhereIDVO = "";
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                int iCounter = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (UltraGridRow rGrid in this.gridVO.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, true, ref da, ref cmd, false, db, ref iCounter);
                        }
                        else
                        {
                            this.showGridRow(rGrid, ref dt, ref sWhereIDVO, true, ref da, ref cmd, false, db, ref iCounter);
                        }
                    }
                }

                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsVO1.VO.Rows.Count.ToString();
                
                this.gridVO.Rows.ExpandAll(true);
                bool LayoutFound = false;

                this.doLayoutVO(ref LayoutFound);
                this._ModusChanged = false;


            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.search: " + ex.ToString());
            }
        }
        public void searchVOBestelldaten(Guid IDVO)
        {
            try
            {
                this.dsVO1.VO_Bestelldaten.Clear();

                System.Collections.Generic.List<Guid> lstTyp = new List<Guid>();
                string sWhereIDVO = "";
                this.sqlVO1.getVO_Bestelldaten(IDVO, sqlVO.eSelVO_Bestelldaten.IDVO, ref this.dsVO1, sWhereIDVO, null, null, null, "", this.chkNurAktuelle.Checked, this._IDAufenthalt, ref lstTyp);
                this.gridVOBestelldaten.Refresh();

                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter daSub = new OleDbDataAdapter();
                OleDbCommand cmdSub = new OleDbCommand();
                int iCounter = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (UltraGridRow rGrid in this.gridVOBestelldaten.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, false, ref daSub, ref cmdSub, false, db, ref iCounter);
                        }
                        else
                        {
                            this.showGridRow(rGrid, ref dt, ref sWhereIDVO, false, ref daSub, ref cmdSub, false, db, ref iCounter);
                        }
                    }
                }

                //this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsVO1.VO_Bestelldaten.Rows.Count.ToString();
       
                this.gridVOBestelldaten.Rows.ExpandAll(true);
                bool LayoutFound = false;
                this.doLayoutVOBestelldaten(ref LayoutFound);
                this._ModusChanged = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.search: " + ex.ToString());
            }
        }

        public void showGrid_rek(UltraGridRow rFoundInGridParent, ref DataTable dt, ref string sWhereIDVO, bool IsFirstBand, ref OleDbDataAdapter da, ref OleDbCommand cmd, bool SaveVerknüpfungen, PMDS.db.Entities.ERModellPMDSEntities db, ref int iCounter)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd, SaveVerknüpfungen, db, ref iCounter);
                        }
                        else
                        {
                            this.showGridRow(rFoundInGrid, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd, SaveVerknüpfungen, db, ref iCounter);
                            if (rFoundInGrid.ChildBands.Count > 0)
                            {
                                foreach (UltraGridChildBand bnd in rFoundInGrid.ChildBands)
                                {
                                    foreach (UltraGridRow rGridRowChild in bnd.Rows)
                                    {
                                        if (rFoundInGrid.IsGroupByRow)
                                        {
                                            this.showGrid_rek(rFoundInGrid, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd, SaveVerknüpfungen, db, ref iCounter);
                                        }
                                        else
                                        {
                                            this.showGridRow(rGridRowChild, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd, SaveVerknüpfungen, db, ref iCounter);
                                            //if (rGridRowChild.Band.Index == 0)
                                            //{
                                            //    this.showGridRow(rGridRowChild, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd, SaveVerknüpfungen, db);
                                            //}
                                            //else
                                            //{
                                            //    this.showGridRowChild(rGridRowChild, ref dt, ref sWhereIDVO, IsFirstBand, ref da, ref cmd);
                                            //}
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.showGrid_rek: " + ex.ToString());
            }
        }
        public void showGridRow(UltraGridRow rFoundInGrid, ref DataTable dt, ref string sWhereIDVO, bool IsFirstBand, ref OleDbDataAdapter da, ref OleDbCommand cmd, bool SaveVerknüpfungen, PMDS.db.Entities.ERModellPMDSEntities db, ref int iCounter)
        {
            try
            {
                if (!SaveVerknüpfungen)
                {
                    if (IsFirstBand)
                    {
                        DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                        dsVO.VORow rVOAct = (dsVO.VORow)v.Row;

                        Guid IDPatient = this.b3.getIDPatientForAufenthalt(ref dt, rVOAct.IDAufenthalt, ref da, ref cmd);
                        string Krankenkasse = "";
                        string VersicherungsNr = "";
                        rFoundInGrid.Cells[this.colKlient.Trim()].Value = this.b3.getPatientenData(ref dt, IDPatient, ref da, ref cmd, ref Krankenkasse, ref VersicherungsNr);
                        rFoundInGrid.Cells[this.colKrankenkasse.Trim()].Value = Krankenkasse.Trim();
                        rFoundInGrid.Cells[this.colSozVers.Trim()].Value = VersicherungsNr.Trim();
                        rFoundInGrid.Cells[this.colSozVers.Trim()].Value = "";
                        rFoundInGrid.Cells[this.colMedikament.Trim()].Value = this.b3.getMedikamentName(ref dt, rVOAct.IDMedikament, ref da, ref cmd);

                        rFoundInGrid.Cells[this.colInfoMedDaten.Trim()].Value = this.b3.getVOInfoMedDaten(ref dt, rVOAct.ID, ref da, ref cmd);
                        rFoundInGrid.Cells[this.colInfoPflegeplanPDx.Trim()].Value = this.b3.getVOInfoIDPflegeplanPDx(ref dt, rVOAct.ID, ref da, ref cmd);
                        rFoundInGrid.Cells[this.colInfoWundeKopf.Trim()].Value = this.b3.getVOInfoIDWundeKopf(ref dt, rVOAct.ID, ref da, ref cmd);

                        rFoundInGrid.Cells[this.colBenutzerErstellt.Trim()].Value = this.b3.getBenutzerData(ref dt, rVOAct.IDBenutzerErstellt, ref da, ref cmd);
                        rFoundInGrid.Cells[this.colBenutzerGeändert.Trim()].Value = this.b3.getBenutzerData(ref dt, rVOAct.IDBenutzerGeaendert, ref da, ref cmd);

                        if (!rVOAct.IsLieferantNull())
                        {
                            var tLieferantFound = lstLieferanten.Where(o => o.ID == rVOAct.Lieferant);
                            if (tLieferantFound.Count() > 0)
                            {
                                rFoundInGrid.Cells[this.colLieferantBeschreibung.Trim()].Value = lstLieferanten.Where(o => o.ID == rVOAct.Lieferant).First().Beschreibung.Trim();
                            }
                        }

                        //rFoundInGrid.Cells[this.colSignatur.Trim()].Value = this.b.getMedikamentName(ref dt, rVOAct.IDMedikament);   //lthxy
                        //sWhereIDVO += (sWhereIDVO.Trim() == "" ? "" : " or ") + " IDVerordnung='" + rVOAct.ID.ToString() + "'";
                    }
                    else
                    {
                        DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                        dsVO.VO_BestelldatenRow rVOActBestelldaten = (dsVO.VO_BestelldatenRow)v.Row;

                        Nullable<Guid> IDAufenthaltTmp = null;
                        Nullable<Guid> IDMedikamentTmp = null;
                        Nullable<Guid> Typ = null;
                        this.b3.getBestelldatenVO_IDs(ref dt, rVOActBestelldaten.ID, ref IDAufenthaltTmp, ref IDMedikamentTmp, ref Typ, ref da, ref cmd);
                        //rFoundInGrid.Cells[this.colTyp.Trim()].Value = Typ;

                        Guid IDPatient = this.b3.getIDPatientForAufenthalt(ref dt, IDAufenthaltTmp.Value, ref da, ref cmd);
                        string Krankenkasse = "";
                        string VersicherungsNr = "";
                        rFoundInGrid.Cells[this.colKlient.Trim()].Value = this.b3.getPatientenData(ref dt, IDPatient, ref da, ref cmd, ref Krankenkasse, ref VersicherungsNr);
                        rFoundInGrid.Cells[this.colMedikament.Trim()].Value = this.b3.getMedikamentName(ref dt, IDMedikamentTmp.Value, ref da, ref cmd);

                        if (!rVOActBestelldaten.IsLieferantNull())
                        {
                            var tLieferantFound = lstLieferanten.Where(o => o.ID == rVOActBestelldaten.Lieferant);
                            if (tLieferantFound.Count() > 0)
                            {
                                rFoundInGrid.Cells[this.colLieferantBeschreibung.Trim()].Value = lstLieferanten.Where(o => o.ID == rVOActBestelldaten.Lieferant).First().Beschreibung.Trim();
                            }
                        }

                        //rFoundInGrid.Cells[this.colSignatur.Trim()].Value = this.b.getMedikamentName(ref dt, rVOAct.IDMedikament);   //lthxy
                        //sWhereIDVO += (sWhereIDVO.Trim() == "" ? "" : " or ") + " IDVerordnung='" + rVOAct.ID.ToString() + "'";

                    }
                }
                else
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsVO.VORow rVOAct = (dsVO.VORow)v.Row;

                    if ((bool)rFoundInGrid.Cells[this.colSelect.Trim()].Value == true)
                    {
                        if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten && this._IDMedDaten != null)
                        {
                            IQueryable<PMDS.db.Entities.VO_MedizinischeDaten> tVO_MedizinischeDaten = db.VO_MedizinischeDaten.Where(o => o.IDMedizinischeDaten == this._IDMedDaten.Value && o.IDVerordnung == rVOAct.ID);
                            if (tVO_MedizinischeDaten.Count() == 0)
                            {
                                DateTime dNow = DateTime.Now;
                                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                                //PMDS.db.Entities.VO_MedizinischeDaten newVO_MedizinischeDaten = PMDS.Global.db.ERSystem.EFEntities.newVO_MedizinischeDaten(db);
                                PMDS.db.Entities.VO_MedizinischeDaten newVO_MedizinischeDaten = new VO_MedizinischeDaten();
                                newVO_MedizinischeDaten.ID = System.Guid.NewGuid();
                                newVO_MedizinischeDaten.IDVerordnung = rVOAct.ID;
                                newVO_MedizinischeDaten.IDMedizinischeDaten = this._IDMedDaten.Value;
                                newVO_MedizinischeDaten.DatumErstellt = dNow;
                                newVO_MedizinischeDaten.DatumGeaendert = dNow;
                                newVO_MedizinischeDaten.IDBenutzerErstellt = rBenutzer.ID;
                                newVO_MedizinischeDaten.IDBenutzerGeaendert = rBenutzer.ID;
                                newVO_MedizinischeDaten.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                                newVO_MedizinischeDaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                                db.VO_MedizinischeDaten.Add(newVO_MedizinischeDaten);
                                db.SaveChanges();
                            }
                        }
                        else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2 && this._IDPflegeplan != null)
                        {
                            PMDS.db.Entities.PflegePlan rPflegeplan = this.b.getPflegeplan(this._IDPflegeplan.Value, db);
                            IQueryable<PMDS.db.Entities.VO_PflegeplanPDX> tVO_PflegeplanPDX = db.VO_PflegeplanPDX.Where(o => o.IDUntertaegigeGruppe == rPflegeplan.IDUntertaegigeGruppe.Value && o.IDVerordnung == rVOAct.ID);
                            if (tVO_PflegeplanPDX.Count() == 0)
                            {
                                DateTime dNow = DateTime.Now;
                                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                                //PMDS.db.Entities.VO_PflegeplanPDX newVO_PflegeplanPDX = PMDS.Global.db.ERSystem.EFEntities.newVO_PflegeplanPDX(db);
                                PMDS.db.Entities.VO_PflegeplanPDX newVO_PflegeplanPDX = new VO_PflegeplanPDX();
                                newVO_PflegeplanPDX.ID = System.Guid.NewGuid();
                                newVO_PflegeplanPDX.IDVerordnung = rVOAct.ID;
                                newVO_PflegeplanPDX.IDUntertaegigeGruppe = rPflegeplan.IDUntertaegigeGruppe.Value;
                                newVO_PflegeplanPDX.DatumEsrstellt = dNow;
                                newVO_PflegeplanPDX.DatumGeaendert = dNow;
                                newVO_PflegeplanPDX.IDBenutzerErstellt = rBenutzer.ID;
                                newVO_PflegeplanPDX.IDBenutzerGeaendert = rBenutzer.ID;
                                newVO_PflegeplanPDX.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                                newVO_PflegeplanPDX.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                                db.VO_PflegeplanPDX.Add(newVO_PflegeplanPDX);
                                db.SaveChanges();
                            }
                        }
                        else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde && this._IDWundeKopf != null)
                        {
                            IQueryable<PMDS.db.Entities.VO_Wunde> tVO_Wunde = db.VO_Wunde.Where(o => o.IDWundeKopf == this._IDWundeKopf.Value && o.IDVerordnung == rVOAct.ID);
                            if (tVO_Wunde.Count() == 0)
                            {
                                DateTime dNow = DateTime.Now;
                                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);
                            
                                PMDS.db.Entities.VO_Wunde newVO_Wunde = PMDS.Global.db.ERSystem.EFEntities.newVO_Wunde(db);
                                //PMDS.db.Entities.VO_Wunde newVO_Wunde = new VO_Wunde();
                                newVO_Wunde.ID = System.Guid.NewGuid();
                                newVO_Wunde.IDVerordnung = rVOAct.ID;
                                newVO_Wunde.IDWundeKopf = this._IDWundeKopf.Value;
                                newVO_Wunde.DatumErstellt = dNow;
                                newVO_Wunde.DatumGeaendert = dNow;
                                newVO_Wunde.IDBenutzerErstellt = rBenutzer.ID;
                                newVO_Wunde.IDBenutzerGeaendert = rBenutzer.ID;
                                newVO_Wunde.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                                newVO_Wunde.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                                db.VO_Wunde.Add(newVO_Wunde);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            throw new Exception("ucVOErfassen.showGridRow: this._IDMedDaten=null and this._IDPflegeplan=null not allowed!");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.showGridRow: " + ex.ToString());
            }
        }
        public void showGridRowChild(UltraGridRow rFoundInGrid, ref DataTable dt, ref string sWhereIDVO, bool IsFirstBand, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                dsVO.VO_BestelldatenRow rVOActBestelldaten = (dsVO.VO_BestelldatenRow)v.Row;
 
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.showGridRowChild: " + ex.ToString());
            }
        }

        public bool validateData(ref string MessageTxt)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.validateData: " + ex.ToString());
            }
        }

        public bool saveDataVerknüpfungen()
        {
            try
            {
                string MessageTxt = "";
                if (!this.validateData(ref MessageTxt))
                {
                    return false;
                }

                string sWhereIDVO = "";
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter daSub = new OleDbDataAdapter();
                OleDbCommand cmdSub = new OleDbCommand();
                bool doDelete = false;
                int iCounter = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (UltraGridRow rGrid in this.gridVO.Rows)
                    {
                        if (rGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rGrid, ref dt, ref sWhereIDVO, false, ref daSub, ref cmdSub, true, db, ref iCounter);
                        }
                        else
                        {
                            this.showGridRow(rGrid, ref dt, ref sWhereIDVO, false, ref daSub, ref cmdSub, true, db, ref iCounter);
                        }
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.saveDataVerknüpfungen: " + ex.ToString());
            }
        }




        public bool addRowOpenVO(dsVO.VORow rSelRow, bool isNew)
        {
            try
            {
                bool WithPatientSelektor = false;
                if (this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                {
                    WithPatientSelektor = true;
                }
                bool bEditable = !(this._TypeUI == PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow);

                Nullable<Guid> TypDefault = null;
                System.Collections.Generic.List<Guid> lstSelectedTyp = new List<Guid>();
                this.contSelectSelListTyp.getSelectedIDs(ref lstSelectedTyp);
                if (lstSelectedTyp.Count == 1)
                {
                    TypDefault = lstSelectedTyp[0];
                }


                List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();

                frmVOErfassenDetail frmVOErfassenDetail1 = new frmVOErfassenDetail();
                if (isNew)
                {
                    frmVOErfassenDetail1.ucVOErfassenDetail1._bEditable = bEditable;
                    frmVOErfassenDetail1.initControl(this._TypeUI, true, null, this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf, WithPatientSelektor, this._Einzelansicht, TypDefault);
                }
                else
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    frmVOErfassenDetail1.ucVOErfassenDetail1._bEditable = PMDSBusiness1.UserCanEdit(ENV.USERID,PflegeEintragTyp.Verordnungen);
                    frmVOErfassenDetail1.initControl(this._TypeUI, false, rSelRow.ID, this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf, WithPatientSelektor, this._Einzelansicht, TypDefault);
                }

                if (lstPatients.Count == 1)
                {
                    if (frmVOErfassenDetail1.ucVOErfassenDetail1._WithPatientSelektor)
                    {
                        frmVOErfassenDetail1.ucVOErfassenDetail1.setPatientenpicker(lstPatients[0]);
                    }
                }

                frmVOErfassenDetail1.ShowDialog(this);
                if (!frmVOErfassenDetail1.ucVOErfassenDetail1.abort)
                {
                    //if (frmVOErfassenDetail1.ucVOErfassenDetail1._IsNew)
                    //{

                    //    frmVOErfassenDetail1.ucVOErfassenDetail1.
                    //}
                    //else
                    //{
                    //    frmVOErfassenDetail1.ucVOErfassenDetail1._r
                    //}
                    this.search2(this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.addRowOpen: " + ex.ToString());
            }
        }
        public bool addRowOpenVOBestelldaten(dsVO.VO_BestelldatenRow rSelRow, bool isNew, Nullable<Guid> IDVO, bool EinmaligeAnfoderung)
        {
            try
            {
                frmVOBestellungErfassenDetail frmVOErfassenDetail1 = new frmVOBestellungErfassenDetail();
                if (isNew)
                {
                    frmVOErfassenDetail1.initControl(true, null, IDVO, EinmaligeAnfoderung);
                }
                else
                {
                    frmVOErfassenDetail1.initControl(false, rSelRow.ID, null, EinmaligeAnfoderung);
                }

                frmVOErfassenDetail1.ShowDialog(this);
                if (!frmVOErfassenDetail1.ucVOBestellungErfassenDetail1.abort)
                {
                    if (isNew)
                    {
                        UltraGridRow rGridSel = null;
                        dsVO.VORow rVO = null;
                        bool RowSelected = this.getSelectedRow(false, ref rGridSel, ref rVO);
                        if (RowSelected)
                        {
                            this.searchVOBestelldaten(rVO.ID);
                        }
                        else
                        {
                            throw new Exception("addRowOpenVOBestelldaten: RowSelected==null not allowed!");
                        }
                    }
                    else
                    {
                        this.searchVOBestelldaten(rSelRow.IDVerordnung);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.addRowOpenVOBestelldaten: " + ex.ToString());
            }
        }

        public bool printVOSchein()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridVO, lstSelectedRows, true);
                if (lstSelectedRows.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                    {
                        DataRowView v = (DataRowView)rGrid.ListObject;
                        dsVO.VORow rSelRow = (dsVO.VORow)v.Row;

                        PMDS.Global.print.FDF fdf = new Global.print.FDF();

                        PMDS.Global.print.FDF.FreeFields ff = new PMDS.Global.print.FDF.FreeFields();

                        string CRLF = ((char)10).ToString() + ((char)13).ToString();
                        string formatDate = "dd.MM.yyyy";

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                            PMDS.db.Entities.Medikament rMedikament = PMDSBusiness1.GetMedikament(db, rSelRow.IDMedikament);
                            ff.FieldName = "#VERORDNUNG#";
                            ff.FieldValue = rMedikament.Bezeichnung.Trim() + CRLF;
                            ff.FieldValue += rSelRow.Menge.ToString() + " " + rSelRow.Einheit.Trim() + CRLF;
                            ff.FieldValue += "Verordnet ab: " + rSelRow.DatumVerordnetAb.Date.ToString("dd.MM.yyyy") + CRLF;
                            if (!rSelRow.IsDatumVerordnetBisNull())
                                ff.FieldValue += "Verordnet bis: " + rSelRow.DatumVerordnetBis.Date.ToString("dd.MM.yyyy") + CRLF;
                            if(rSelRow.Hinweis != "")
                                ff.FieldValue += "Hinweis: " + rSelRow.Hinweis + CRLF;
                        }

                        fdf.lstFreeFields.Add(ff);

                        ff.FieldName = "#ANMERKKUNG#";
                        ff.FieldValue = rSelRow.Anmerkung.Trim();
                        fdf.lstFreeFields.Add(ff);

                        ff.FieldName = "#DATUM#";
                        ff.FieldValue = DateTime.Now.Date.ToString(formatDate);
                        fdf.lstFreeFields.Add(ff);


                        fdf.Print(System.IO.Path.Combine(ENV.ReportPath, "Verordnungsschein.PDF"), rSelRow.IDAufenthalt);
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.printVOSchein: " + ex.ToString());
            }
        }


        public bool delRowsVO()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridVO, lstSelectedRows, true);
                if (lstSelectedRows.Count > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        string sMsgBoxInfoDelete = "";
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                        {
                            DataRowView v = (DataRowView)rGrid.ListObject;
                            dsVO.VORow rSelRow = (dsVO.VORow)v.Row;

                            if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten || this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                            {
                                sMsgBoxInfoDelete += this.PMDSBusinessUI2.checkDeleteVO(rSelRow.ID);
                            }
                        }

                        if (sMsgBoxInfoDelete.Trim() != "")
                        {
                            string sMsgBox = "";        //QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Beziehungen zu den gewählten Zeilen gefunden!");
                            string sMsgBox2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sätze trotzdem löschen?");
                            sMsgBoxInfoDelete = sMsgBox + "\r\n" + "\r\n" + sMsgBoxInfoDelete + "\r\n" + sMsgBox2;

                            PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox();
                            frmMessageBox1.initControl(sMsgBoxInfoDelete);
                            frmMessageBox1.ShowDialog(this);
                            if (frmMessageBox1.abort)
                            {
                                return false;
                            }
                        }

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                dsVO.VORow rSelRow = (dsVO.VORow)v.Row;                     

                                if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenKlientStammdaten || this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung)
                                {
                                    this.sqlVO1.delete_VO(rSelRow.ID);
                                }
                                else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassungMedDaten)
                                {
                                    this.sqlVO1.delete_VOMedDaten(rSelRow.ID, this._IDMedDaten.Value);
                                }
                                else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2)
                                {
                                    this.sqlVO1.delete_VOPflegeplanPDx(rSelRow.ID, this._IDPflegeplan.Value);
                                }
                                else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde)
                                {
                                    this.sqlVO1.delete_VOWundeKopf(rSelRow.ID, this._IDWundeKopf.Value);
                                }
                                else if (this._TypeUI == Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanungOnlyShow)
                                {
                                    throw new Exception("delRowsVO: Delete Vo for this._TypeUI=VOErfassenPlanungOnlyShow not allowed!");
                                }
                            }

                            if (sMsgBoxInfoDelete.Trim() != "")
                            {
                                this.b.saveProtocol(db, "Delete Verordnungen", sMsgBoxInfoDelete);
                            }

                            this.search2(this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.delRowsVO: " + ex.ToString());
            }
        }
        public bool delRowsVOBestelldaten()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridVOBestelldaten, lstSelectedRows, true);
                if (lstSelectedRows.Count > 0)
                {
                    int iNotDeletedNoRight = 0;
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                        dsVO.VORow rVO = null;
                        bool RowSelected = this.getSelectedRow(false, ref gridRow, ref rVO);
                        if (!RowSelected)
                        {
                            throw new Exception("ucVOErfassen.delRowsVOBestelldaten: !RowSelected not allowed!");
                        }

                        string sMsgBoxInfoDelete = "";
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                        {
                            DataRowView v = (DataRowView)rGrid.ListObject;
                            dsVO.VO_BestelldatenRow rSelRow = (dsVO.VO_BestelldatenRow)v.Row;
                            
                            sMsgBoxInfoDelete += this.b2.checkDeleteVO_Bestelldaten(rSelRow.ID, true);
                        }

                        if (sMsgBoxInfoDelete.Trim() != "")
                        {
                            string sMsgBox = "";    //QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Beziehungen zu den gewählten Zeilen gefunden!");
                            string sMsgBox2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sätze trotzdem löschen?");
                            sMsgBoxInfoDelete = sMsgBox + "\r\n" + "\r\n" + sMsgBoxInfoDelete + "\r\n" + sMsgBox2;

                            PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox();
                            frmMessageBox1.initControl(sMsgBoxInfoDelete);
                            frmMessageBox1.ShowDialog(this);
                            if (frmMessageBox1.abort)
                            {
                                return false;
                            }
                        }

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                dsVO.VO_BestelldatenRow rSelRow = (dsVO.VO_BestelldatenRow)v.Row;
                            
                                if (!rSelRow.EinmaligeAnforderung && this.rightAddVOBestelldaten)
                                {
                                    this.sqlVO1.delete_VOBestelldaten(rSelRow.ID);
                                }
                                else if (rSelRow.EinmaligeAnforderung && this.rightAddVOBestelldatenEinmaligeAnforderung)
                                {
                                    this.sqlVO1.delete_VOBestelldaten(rSelRow.ID);
                                }
                                else
                                {
                                    iNotDeletedNoRight += 1;
                                }
                            }

                            if (sMsgBoxInfoDelete.Trim() != "")
                            {
                                this.b.saveProtocol(db, "Delete Verordnungen", sMsgBoxInfoDelete);
                            }
                        }

                        this.searchVOBestelldaten(rVO.ID);
                        if (iNotDeletedNoRight > 0)
                        {
                            string sTxtMsgBoxTranslated = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Verordnungen können nicht gelöscht werden, da kein Recht vorhanden!");
                            sTxtMsgBoxTranslated = string.Format(sTxtMsgBoxTranslated, iNotDeletedNoRight.ToString());
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTxtMsgBoxTranslated, "", MessageBoxButtons.OK, true);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.delRowsVOBestelldaten: " + ex.ToString());
            }
        }

        public void VerordnungsVerknüpfungHinzufügen()
        {
            try
            {
                List<Guid> lstIDVONotShow = new List<Guid>();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridVO.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsVO.VORow rSelRow = (dsVO.VORow)v.Row;

                    lstIDVONotShow.Add(rSelRow.ID);
                }

                PMDS.GUI.Verordnungen.frmVOErfassen frmVOErfassen1 = new Verordnungen.frmVOErfassen();
                frmVOErfassen1.initControl(this._TypeUI, true, true, lstIDVONotShow);
                frmVOErfassen1.ucVOErfassen1.search2(this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf);
                frmVOErfassen1.ShowDialog(this);
                if (!frmVOErfassen1.ucVOErfassen1.abort)
                {
                    this.search2(this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.VerordnungsVerknüpfungHinzufügen: " + ex.ToString());
            }
        }

        public bool print(bool exportDS)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                    Nullable<DateTime> dFrom = null;
                    if (this.udteVerordnetAb.Value != null)
                    {
                        dFrom = this.udteVerordnetAb.DateTime.Date;
                    }

                    Nullable<DateTime> dTo = null;
                    if (this.udteVerordnetBis.Value != null)
                    {
                        dTo = this.udteVerordnetBis.DateTime.Date;
                    }

                    System.Collections.Generic.List<string> lstSelectedTyp = new List<string>();
                    string lTyp = this.contSelectSelListTyp.getSelectedData2(ref lstSelectedTyp);

                    string lstIDs = "";
                    foreach (dsVO.VORow rVO in this.dsVO1.VO)
                    {
                        lstIDs += rVO.ID.ToString() + ";";
                    }

                    dsVO dsVPToPrint = new dsVO();
                    dsVPToPrint = (dsVO)this.dsVO1.Copy();
                    dsVPToPrint.VO.Columns.Add("LieferantBeschreibung", typeof(string));
                    foreach (dsVO.VORow rVOToPrint in dsVPToPrint.VO)
                    {
                        rVOToPrint["LieferantBeschreibung"] = "";
                        if (!rVOToPrint.IsLieferantNull())
                        {
                            var tLieferantFound = lstLieferanten.Where(o => o.ID == rVOToPrint.Lieferant);
                            if (tLieferantFound.Count() > 0)
                            {
                                rVOToPrint["LieferantBeschreibung"] = lstLieferanten.Where(o => o.ID == rVOToPrint.Lieferant).First().Beschreibung.Trim();
                            }
                        }
                    }
            
                    PMDS.Print.ReportManager.PrintVOErfassen(dsVPToPrint, ENV.IDKlinik, ENV.CurrentIDAbteilung, dFrom, dTo,lTyp, ENV.LoginInNameFrei.Trim(), exportDS, this.chkPrintDetailsJN.Checked, lstIDs);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.print: " + ex.ToString());
            }
        }

        public bool getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsVO.VORow rVO)
        {
            try
            {
                if (this.gridVO.ActiveRow != null)
                {
                    if (this.gridVO.ActiveRow.IsGroupByRow || this.gridVO.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridVO.ActiveRow.ListObject;
                        dsVO.VORow rSelRow = (dsVO.VORow)v.Row;
                        gridRow = this.gridVO.ActiveRow;
                        rVO = rSelRow;
                        return true;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.getSelectedRow: " + ex.ToString());
            }
        }
        public bool getSelectedRowBestelldaten(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsVO.VO_BestelldatenRow rVOBestelldaten)
        {
            try
            {
                if (this.gridVOBestelldaten.ActiveRow != null)
                {
                    if (this.gridVOBestelldaten.ActiveRow.IsGroupByRow || this.gridVOBestelldaten.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridVOBestelldaten.ActiveRow.ListObject;
                        dsVO.VO_BestelldatenRow rSelRow = (dsVO.VO_BestelldatenRow)v.Row;
                        gridRow = this.gridVOBestelldaten.ActiveRow;
                        rVOBestelldaten = rSelRow;
                        return true;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.getSelectedRowBestelldaten: " + ex.ToString());
            }
        }
        public bool getParentVORow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsVO.VORow rVOParent)
        {
            try
            {
                if (this.gridVO.ActiveRow != null)
                {
                    if (this.gridVO.ActiveRow.IsGroupByRow || this.gridVO.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        if (this.gridVO.ActiveRow.Band.Index == 0)
                        {
                            DataRowView v = (DataRowView)this.gridVO.ActiveRow.ListObject;
                            dsVO.VORow rSelRow = (dsVO.VORow)v.Row;
                            gridRow = this.gridVO.ActiveRow;
                            rVOParent = rSelRow;
                            return true;
                        }
                        else
                        {
                            DataRowView v = (DataRowView)this.gridVO.ActiveRow.ParentRow.ListObject;
                            dsVO.VORow rSelRow = (dsVO.VORow)v.Row;
                            gridRow = this.gridVO.ActiveRow;
                            rVOParent = rSelRow;
                            return true;
                        }
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOErfassen.getParentVORow: " + ex.ToString());
            }
        }


        private void gridVOErfBestell_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVO))
                {
                    UltraGridRow rGridSel = null;
                    dsVO.VORow rVO = null;
                    bool RowSelected = this.getSelectedRow(false, ref rGridSel, ref rVO);
                    if (RowSelected)
                    {
                        this.searchVOBestelldaten(rVO.ID);

                        string sLagerZustand = "";
                        if (this.cboZustand.Text.ToString().Trim() != "")
                        {
                            sLagerZustand = this.cboZustand.Text.Trim();
                        }
                        this.ucLager1.loadData(rVO.ID, sLagerZustand);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOErfBestell_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVO))
                {
                    UltraGridRow rGridSel = null;
                    dsVO.VORow rVO = null;
                    bool RowSelected = this.getSelectedRow(false, ref rGridSel, ref rVO);
                    if (RowSelected)
                    {
                        this.addRowOpenVO(rVO, false);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridVOBestelldaten_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOBestelldaten_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOBestelldaten_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOBestelldaten))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVOBestelldaten_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVOBestelldaten))
                {
                    UltraGridRow rGridSel = null;
                    dsVO.VO_BestelldatenRow rVOBestelldaten = null;
                    bool RowSelected = this.getSelectedRowBestelldaten(false, ref rGridSel, ref rVOBestelldaten);
                    if (RowSelected)
                    {
                        this.addRowOpenVOBestelldaten(rVOBestelldaten, false, null, false);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRowOpenVO(null, true);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAddVOBestelldaten_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsVO.VORow rVO = null;
                bool RowSelected = this.getSelectedRow(true, ref gridRow, ref rVO);
                if (RowSelected)
                {
                    this.addRowOpenVOBestelldaten(null, true, rVO.ID, false);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAddVOBestelldatenEinmaligeAnforderung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsVO.VORow rVO = null;
                bool RowSelected = this.getSelectedRow(true, ref gridRow, ref rVO);
                if (RowSelected)
                {
                    this.addRowOpenVOBestelldaten(null, true, rVO.ID, true);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.delRowsVO();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDelBestelldaten_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.delRowsVOBestelldaten();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.print(false);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.mainWindow != null)
                {
                    this.mainWindow.Close();
                }
                if (this.mainWindowVerwaltung != null)
                {
                    this.mainWindowVerwaltung.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.search2(this._IDAufenthalt, this._IDPflegeplan, this._IDMedDaten, this._IDWundeKopf);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void exportDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.print(true);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chkNurAktuelle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkNurAktuelle.Focused)
                {
                    this.setUIFromTo(this.chkNurAktuelle.Checked);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.buildUI1.setFilterGridKomplex((Infragistics.Win.UltraWinGrid.UltraGrid)this.gridVO, this.filterToolStripMenuItem.Checked, true, false);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void ansichtErweiternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.gridVO.Rows.ExpandAll(true);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void ansichtReduzierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.gridVO.Rows.CollapseAll(true);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void verordnungsVerknüpfungHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.VerordnungsVerknüpfungHinzufügen();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveDataVerknüpfungen())
                {
                    this.abort = false;
                    this.mainWindow.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void layoutmanagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                QS2.Desktop.ControlManagment.ControlManagment.openLayoutmanager(ref this.gridVOBestelldaten, this.gridVOBestelldaten.Name);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnMedikamente_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsVO.VORow rVO = null;
                bool bSelected = this.getSelectedRow(true, ref gridRow, ref rVO);
                if (bSelected)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rVO.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        //string lstRezepteinträge = "";
                        //int NumberRezepteinträge = 0;
                        //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //{
                            //this.b2.saveAnzeigeGridMedDaten(rVO.ID, db, ref lstRezepteinträge, ref NumberRezepteinträge);
                            //db.SaveChanges();

                            //System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == rVO.ID);
                            //if (tRezeptEintragMedDaten.Count() > 0)
                            //{
                            //    foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                            //    {
                            //        string lstMedDaten = "";
                            //        int NumberMedDaten = 0;
                            //        string lstWunden = "";
                            //        int NumberWunden = 0;
                            //        this.b2.saveAnzeigeGridRezeptEintrag(rRezeptEintragMedDaten2.IDRezepteintrag, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                            //    }
                            //    db.SaveChanges();
                            //}
                        //}

                        //rSelRow.lstRezepteinträge = lstRezepteinträge;
                        //rSelRow.NumberRezepteinträge = NumberRezepteinträge;
                        //this.grid.Refresh();

                        //if (!rSelRow.IsBisNull())
                        //{
                        //    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //    {
                        //        this.b2.checkMedDatenAbgesetzt2(null, db, ENV.CurrentIDPatient, 0);
                        //    }
                        //}
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

        private void btnMedDaten_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsVO.VORow rVO = null;
                bool bSelected = this.getSelectedRow(true, ref gridRow, ref rVO);
                if (bSelected)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rVO.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        //string lstMedDaten = "";
                        //int NumberMedDaten = 0;
                        //string lstWunden = "";
                        //int NumberWunden = 0;
                        //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //{
                        //    this.b2.saveAnzeigeGridRezeptEintrag(rVO.ID, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                        //    db.SaveChanges();

                        //    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == rVO.ID);
                        //    if (tRezeptEintragMedDaten.Count() > 0)
                        //    {
                        //        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                        //        {
                        //            if (rRezeptEintragMedDaten2.IDMedDaten != null)
                        //            {
                        //                int NumberRezepteinträge = 0;
                        //                string lstRezepteinträge = "";
                        //                this.b2.saveAnzeigeGridMedDaten(rRezeptEintragMedDaten2.IDMedDaten.Value, db, ref lstRezepteinträge, ref NumberRezepteinträge);
                        //            }
                        //        }
                        //        db.SaveChanges();
                        //    }
                        //}

                        //rSelRow.NumberMedDaten = NumberMedDaten;
                        //rSelRow.lstMedDaten = lstMedDaten;
                        //rSelRow.NumberWunden = NumberWunden;
                        //rSelRow.lstWunden = lstWunden;
                        //this.ucMed1VerschreibenDetailAll.dgEintraege.Refresh();

                        ////if (rSelRow.AbzugebenBis.Year != 3000)
                        ////{
                        ////    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        ////    {
                        ////        b2.checkRezeptEintragAbgesetzt(rSelRow.ID, db);
                        ////    }
                        ////}
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
        private void btnWunde_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsVO.VORow rVO = null;
                bool bSelected = this.getSelectedRow(true, ref gridRow, ref rVO);
                if (bSelected)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rVO.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.VOToWunde);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        //string lstMedDaten = "";
                        //int NumberMedDaten = 0;
                        //string lstWunden = "";
                        //int NumberWunden = 0;
                        //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //{
                        //    this.b2.saveAnzeigeGridRezeptEintrag(rVO.ID, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                        //    db.SaveChanges();
                        //}

                        //rSelRow.NumberMedDaten = NumberMedDaten;
                        //rSelRow.lstMedDaten = lstMedDaten;
                        //rSelRow.NumberWunden = NumberWunden;
                        //rSelRow.lstWunden = lstWunden;
                        //this.ucMed1VerschreibenDetailAll.dgEintraege.Refresh();
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

        private void btnAddVOVerknüpfung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.VerordnungsVerknüpfungHinzufügen();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboZustand_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("LAZ");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("LAZ", this.cboZustand, null, this.cboZustand.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("LAZ", this.cboZustand, null);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.printVOSchein();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                PMDSBusinessUI.doSelListChanged("", null, null);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }

        }
    }

}
