using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;

using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Patient;
using PMDS.DB;

namespace PMDS.Calc.UI.Admin
{


    public class ucKostenträger : QS2.Desktop.ControlManagment.BaseControl
    {
        private dsKostentraeger.KostentraegerDataTable _dt;
        private PMDS.DB.Global.DBKostentraeger _kostentraeger = new PMDS.DB.Global.DBKostentraeger();
        private PMDS.Calc.Admin.DB.DBPatientKostentraeger _PatientKostentraeger = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
        private dsPatientKostentraeger _dsPatientKostentraeger = new dsPatientKostentraeger();

        public event EventHandler ValueChanged;
        public event EventHandler stateToSaved;
        public event EventHandler AfterRowActivate;
        public event Action KostentraegerRowChanged = delegate{};

        public Infragistics.Win.UltraWinGrid.UltraGridRow KostenträgerRowSelected { get; set; }

        public bool loadForIDKlinik;
		private bool _ForPatientExclusive;
        private bool _KostentraegerChenged;
        private bool _ValueChangedEnabled = true;
		private Guid _IDKostentraeger = Guid.Empty;
        private bool _ReadOnly;
        private bool _Filtergesetzt;
        private string _txtKostentraeger = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Kostenträger");

        private bool _refreshData = true;
        private bool _SaveBeforSetFilter;
        private dsKostentraeger.KostentraegerRow _CurrentRow;
        private bool _TransferKostentraegerJN;
        private bool _AddKlienten = true;
        public bool AssignToPatientKostenträger = true;

        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();

        public PMDSBusiness b = new PMDSBusiness();

        public bool bKlientenzuordnung { get; set; }

        private dsKostentraeger dsKostentraeger1;
		private QS2.Desktop.ControlManagment.BaseGrid dgMain;
		private QS2.Desktop.ControlManagment.BaseLabel lblKostentraeger;
        private QS2.Desktop.ControlManagment.BaseButton btnDel;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbSearch;
        private QS2.Desktop.ControlManagment.BaseLabel lblName;
        private QS2.Desktop.ControlManagment.BasePanel pnlSerch;
        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbPatbezK;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbAlgemein;
        private ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbTransferKt;
        private QS2.Desktop.ControlManagment.BasePanel pnlKostentraegerArt;
        private QS2.Desktop.ControlManagment.BaseOptionSet opAuswahl;
        private ucButton btnOk;
        private Infragistics.Win.Misc.UltraDropDownButton btnKostentraeger;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private QS2.Desktop.ControlManagment.BaseButton btnAddTrKt;
        private SplitContainer splitContainer1;
        private QS2.Desktop.ControlManagment.BaseGrid dgKlienten;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdateKlient;
        private QS2.Desktop.ControlManagment.BaseButton btnDelKlienten;
        private QS2.Desktop.ControlManagment.BaseButton btnAddKlienten;
        private QS2.Desktop.ControlManagment.BaseLabel lblKonto;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKonto;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid;
        private QS2.Desktop.ControlManagment.BasePanel panelObenAuswahl;
        private IContainer components;
        private dsPatientKostentraeger dsPatientKostentraeger1;
        public QS2.Desktop.ControlManagment.BaseButton btnExportExcel;
        private GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        private GUI.BaseControls.cboGridKostenträger cboGridKostenträger1;
        private Infragistics.Win.Misc.UltraButton btnKostPrüfenDB;
        private QS2.Desktop.ControlManagment.BasePanel basePanel2;
        private QS2.Desktop.ControlManagment.BasePanel basePanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsOben;


        

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKostenträger));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Kostenträger entfernen", Infragistics.Win.ToolTipImage.Default, "Entfernen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Kostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FIBUKonto", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anrede");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Strasse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ort");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rechnungsanschrift");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rechnungsempfaenger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraegerSub", -1, "dropDownKostenträger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UIDNr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SammelabrechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GSBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zahlart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErlagscheingebuehrJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bank");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kontonr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaschengeldJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PatientbezogenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TransferleistungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatientIstZahler");
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Tabelle nach Excel exportieren", Infragistics.Win.ToolTipImage.Default, "ExportE xcel", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Kostenträger hinzufügen", Infragistics.Win.ToolTipImage.Default, "Hinzufügen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientKostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraeger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("enumKostentraegerart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetragErrechnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VorauszahlungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatientIstZahler");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungsdruckTyp");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(954439811);
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            this.lblKostentraeger = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.tbSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlSerch = new QS2.Desktop.ControlManagment.BasePanel();
            this.cboGridKostenträger1 = new PMDS.GUI.BaseControls.cboGridKostenträger();
            this.lblKonto = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKonto = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbPatbezK = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbAlgemein = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelGrid = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlKostentraegerArt = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.opAuswahl = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKostentraeger1 = new PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger();
            this.panelObenAuswahl = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonsOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnKostPrüfenDB = new Infragistics.Win.Misc.UltraButton();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.btnExportExcel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnKostentraeger = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnAddTrKt = new QS2.Desktop.ControlManagment.BaseButton();
            this.cbTransferKt = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.basePanel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.dgKlienten = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientKostentraeger1 = new PMDS.Global.db.Global.ds_abrechnung.dsPatientKostentraeger();
            this.basePanel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAddKlienten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUpdateKlient = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelKlienten = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).BeginInit();
            this.pnlSerch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatbezK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlgemein)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.pnlKostentraegerArt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKostentraeger1)).BeginInit();
            this.panelObenAuswahl.SuspendLayout();
            this.panelButtonsOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTransferKt)).BeginInit();
            this.basePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).BeginInit();
            this.basePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKostentraeger
            // 
            this.lblKostentraeger.Location = new System.Drawing.Point(3, 12);
            this.lblKostentraeger.Name = "lblKostentraeger";
            this.lblKostentraeger.Size = new System.Drawing.Size(34, 16);
            this.lblKostentraeger.TabIndex = 6;
            this.lblKostentraeger.Text = "Filter";
            // 
            // btnDel
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance1;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(336, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 6;
            ultraToolTipInfo6.ToolTipText = "Kostenträger entfernen";
            ultraToolTipInfo6.ToolTipTitle = "Entfernen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDel, ultraToolTipInfo6);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(65, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(261, 21);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.ValueChanged += new System.EventHandler(this.tbSearch_ValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(34, 14);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name";
            // 
            // pnlSerch
            // 
            this.pnlSerch.Controls.Add(this.cboGridKostenträger1);
            this.pnlSerch.Controls.Add(this.lblKonto);
            this.pnlSerch.Controls.Add(this.txtKonto);
            this.pnlSerch.Controls.Add(this.lblName);
            this.pnlSerch.Controls.Add(this.tbSearch);
            this.pnlSerch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSerch.Location = new System.Drawing.Point(0, 0);
            this.pnlSerch.Name = "pnlSerch";
            this.pnlSerch.Size = new System.Drawing.Size(1252, 31);
            this.pnlSerch.TabIndex = 15;
            // 
            // cboGridKostenträger1
            // 
            this.cboGridKostenträger1.Location = new System.Drawing.Point(894, 7);
            this.cboGridKostenträger1.Name = "cboGridKostenträger1";
            this.cboGridKostenträger1.Size = new System.Drawing.Size(35, 16);
            this.cboGridKostenträger1.TabIndex = 153;
            this.cboGridKostenträger1.Visible = false;
            // 
            // lblKonto
            // 
            this.lblKonto.AutoSize = true;
            this.lblKonto.Location = new System.Drawing.Point(371, 9);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(66, 14);
            this.lblKonto.TabIndex = 152;
            this.lblKonto.Text = "Konto (Fibu)";
            // 
            // txtKonto
            // 
            this.txtKonto.Location = new System.Drawing.Point(463, 6);
            this.txtKonto.Name = "txtKonto";
            this.txtKonto.Size = new System.Drawing.Size(155, 21);
            this.txtKonto.TabIndex = 151;
            this.txtKonto.ValueChanged += new System.EventHandler(this.txtKonto_ValueChanged);
            // 
            // cbPatbezK
            // 
            appearance19.BorderColor = System.Drawing.Color.Black;
            appearance19.FontData.Name = "Segoe UI";
            appearance19.FontData.SizeInPoints = 10F;
            this.cbPatbezK.Appearance = appearance19;
            this.cbPatbezK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.cbPatbezK.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.cbPatbezK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbPatbezK.Location = new System.Drawing.Point(187, 4);
            this.cbPatbezK.Name = "cbPatbezK";
            this.cbPatbezK.Size = new System.Drawing.Size(140, 36);
            this.cbPatbezK.TabIndex = 3;
            this.cbPatbezK.Text = "Klientenbezogene Kostenträger";
            this.cbPatbezK.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbPatbezK.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbAlgemein
            // 
            appearance17.FontData.Name = "Segoe UI";
            appearance17.FontData.SizeInPoints = 10F;
            this.cbAlgemein.Appearance = appearance17;
            this.cbAlgemein.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAlgemein.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAlgemein.Location = new System.Drawing.Point(67, 4);
            this.cbAlgemein.Name = "cbAlgemein";
            this.cbAlgemein.Size = new System.Drawing.Size(111, 36);
            this.cbAlgemein.TabIndex = 2;
            this.cbAlgemein.Text = "Allgemeine Kostenträger";
            this.cbAlgemein.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbAlgemein.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbAlgemein.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.splitContainer1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 31);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1252, 594);
            this.panelTop.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panelObenAuswahl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.basePanel2);
            this.splitContainer1.Panel2.Controls.Add(this.basePanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1252, 594);
            this.splitContainer1.SplitterDistance = 932;
            this.splitContainer1.TabIndex = 95;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.pnlKostentraegerArt);
            this.panelGrid.Controls.Add(this.dgMain);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 48);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(932, 546);
            this.panelGrid.TabIndex = 97;
            // 
            // pnlKostentraegerArt
            // 
            this.pnlKostentraegerArt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlKostentraegerArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKostentraegerArt.Controls.Add(this.btnOk);
            this.pnlKostentraegerArt.Controls.Add(this.opAuswahl);
            this.pnlKostentraegerArt.Location = new System.Drawing.Point(432, 118);
            this.pnlKostentraegerArt.Name = "pnlKostentraegerArt";
            this.pnlKostentraegerArt.Size = new System.Drawing.Size(184, 87);
            this.pnlKostentraegerArt.TabIndex = 93;
            this.pnlKostentraegerArt.Visible = false;
            // 
            // btnOk
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance2;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DoOnClick = true;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(129, 58);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // opAuswahl
            // 
            this.opAuswahl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.opAuswahl.CheckedIndex = 0;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Allgemeine Kostenträger";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Klientenbezogene Kostenträger";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Transfer Kostenträger";
            this.opAuswahl.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.opAuswahl.ItemSpacingVertical = 2;
            this.opAuswahl.Location = new System.Drawing.Point(4, 4);
            this.opAuswahl.Name = "opAuswahl";
            this.opAuswahl.Size = new System.Drawing.Size(179, 56);
            this.opAuswahl.TabIndex = 87;
            this.opAuswahl.Text = "Allgemeine Kostenträger";
            this.opAuswahl.ValueChanged += new System.EventHandler(this.opAuswahl_ValueChanged);
            // 
            // dgMain
            // 
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsKostentraeger1.Kostentraeger;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Black;
            appearance3.FontData.SizeInPoints = 10F;
            this.dgMain.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "FiBu-Konto";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.Caption = "Anrede/Titel";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.Caption = "eMail";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.Header.Caption = "Rechnungsempfänger";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn11.Header.Caption = "Kostenträger für";
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn12.Header.Caption = "UID / VRN";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn13.Header.Caption = "Einrichtung";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn14.Header.Caption = "Sammelabrechnung J/N";
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn17.Header.Caption = "Erlagscheingebühr J/N";
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 17;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 18;
            ultraGridColumn20.Header.Caption = "IBAN";
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 19;
            ultraGridColumn21.Header.Caption = "BIC";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn22.Header.Caption = "Taschengeld J/N";
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn23.Header.Caption = "Patientbezogen J/N";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn24.Header.Caption = "Transferleistung J/N";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn25.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.GroupByBox.Hidden = true;
            this.dgMain.DisplayLayout.GroupByBox.Prompt = "Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.dgMain.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance10;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            this.dgMain.DisplayLayout.Override.DefaultRowHeight = 22;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance13;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(932, 546);
            this.dgMain.TabIndex = 7;
            this.dgMain.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            this.dgMain.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgMain_InitializeLayout_1);
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.AfterRowsDeleted += new System.EventHandler(this.dgMain_AfterRowsDeleted);
            this.dgMain.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_AfterRowUpdate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgMain_AfterSelectChange);
            this.dgMain.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.dgMain_BeforeSelectChange);
            this.dgMain.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgMain_BeforeCellActivate);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.VisibleChanged += new System.EventHandler(this.dgMain_VisibleChanged);
            // 
            // dsKostentraeger1
            // 
            this.dsKostentraeger1.DataSetName = "dsKostentraeger";
            this.dsKostentraeger1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKostentraeger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelObenAuswahl
            // 
            this.panelObenAuswahl.Controls.Add(this.panelButtonsOben);
            this.panelObenAuswahl.Controls.Add(this.lblKostentraeger);
            this.panelObenAuswahl.Controls.Add(this.cbAlgemein);
            this.panelObenAuswahl.Controls.Add(this.cbTransferKt);
            this.panelObenAuswahl.Controls.Add(this.cbPatbezK);
            this.panelObenAuswahl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelObenAuswahl.Location = new System.Drawing.Point(0, 0);
            this.panelObenAuswahl.Name = "panelObenAuswahl";
            this.panelObenAuswahl.Size = new System.Drawing.Size(932, 48);
            this.panelObenAuswahl.TabIndex = 95;
            // 
            // panelButtonsOben
            // 
            this.panelButtonsOben.Controls.Add(this.btnKostPrüfenDB);
            this.panelButtonsOben.Controls.Add(this.ucKlinikDropDown1);
            this.panelButtonsOben.Controls.Add(this.btnExportExcel);
            this.panelButtonsOben.Controls.Add(this.btnKostentraeger);
            this.panelButtonsOben.Controls.Add(this.btnDel);
            this.panelButtonsOben.Controls.Add(this.btnAddTrKt);
            this.panelButtonsOben.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsOben.Location = new System.Drawing.Point(536, 0);
            this.panelButtonsOben.Name = "panelButtonsOben";
            this.panelButtonsOben.Size = new System.Drawing.Size(396, 48);
            this.panelButtonsOben.TabIndex = 95;
            // 
            // btnKostPrüfenDB
            // 
            this.btnKostPrüfenDB.Location = new System.Drawing.Point(48, 9);
            this.btnKostPrüfenDB.Name = "btnKostPrüfenDB";
            this.btnKostPrüfenDB.Size = new System.Drawing.Size(74, 24);
            this.btnKostPrüfenDB.TabIndex = 97;
            this.btnKostPrüfenDB.Text = "Prüfen";
            this.btnKostPrüfenDB.Click += new System.EventHandler(this.btnKostPrüfenDB_Click);
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(9, 14);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 162;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // btnExportExcel
            // 
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExportExcel.Appearance = appearance15;
            this.btnExportExcel.AutoWorkLayout = false;
            this.btnExportExcel.IsStandardControl = false;
            this.btnExportExcel.Location = new System.Drawing.Point(364, 9);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExportExcel.TabIndex = 161;
            this.btnExportExcel.Tag = "P";
            ultraToolTipInfo1.ToolTipText = "Tabelle nach Excel exportieren";
            ultraToolTipInfo1.ToolTipTitle = "ExportE xcel";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportExcel, ultraToolTipInfo1);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnKostentraeger
            // 
            appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance16.BorderColor = System.Drawing.Color.DimGray;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnKostentraeger.Appearance = appearance16;
            this.btnKostentraeger.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKostentraeger.Location = new System.Drawing.Point(128, 9);
            this.btnKostentraeger.Name = "btnKostentraeger";
            this.btnKostentraeger.PopupItemKey = "pnlKostentraegerArt";
            this.btnKostentraeger.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnKostentraeger.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.btnKostentraeger.ShowOutline = false;
            this.btnKostentraeger.Size = new System.Drawing.Size(206, 24);
            this.btnKostentraeger.TabIndex = 5;
            this.btnKostentraeger.Text = "{0}  Kostenträger";
            ultraToolTipInfo2.ToolTipText = "Kostenträger hinzufügen";
            ultraToolTipInfo2.ToolTipTitle = "Hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnKostentraeger, ultraToolTipInfo2);
            this.btnKostentraeger.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnKostentraeger.DroppingDown += new System.ComponentModel.CancelEventHandler(this.btnKostentraeger_DroppingDown);
            this.btnKostentraeger.Click += new System.EventHandler(this.btnKostentraeger_Click);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlKostentraegerArt;
            // 
            // btnAddTrKt
            // 
            this.btnAddTrKt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrKt.AutoWorkLayout = false;
            this.btnAddTrKt.IsStandardControl = false;
            this.btnAddTrKt.Location = new System.Drawing.Point(218, 9);
            this.btnAddTrKt.Name = "btnAddTrKt";
            this.btnAddTrKt.Size = new System.Drawing.Size(140, 24);
            this.btnAddTrKt.TabIndex = 5;
            this.btnAddTrKt.Text = "Transfer Kostenträger";
            this.btnAddTrKt.Visible = false;
            this.btnAddTrKt.Click += new System.EventHandler(this.btnKostentraeger_Click);
            // 
            // cbTransferKt
            // 
            appearance18.BorderColor = System.Drawing.Color.Black;
            appearance18.FontData.Name = "Segoe UI";
            appearance18.FontData.SizeInPoints = 10F;
            this.cbTransferKt.Appearance = appearance18;
            this.cbTransferKt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(231)))), ((int)(((byte)(147)))));
            this.cbTransferKt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(231)))), ((int)(((byte)(147)))));
            this.cbTransferKt.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbTransferKt.Location = new System.Drawing.Point(335, 4);
            this.cbTransferKt.Name = "cbTransferKt";
            this.cbTransferKt.Size = new System.Drawing.Size(106, 36);
            this.cbTransferKt.TabIndex = 4;
            this.cbTransferKt.Text = "Transfer Kostenträger";
            this.cbTransferKt.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbTransferKt.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // basePanel2
            // 
            this.basePanel2.Controls.Add(this.dgKlienten);
            this.basePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePanel2.Location = new System.Drawing.Point(0, 48);
            this.basePanel2.Name = "basePanel2";
            this.basePanel2.Size = new System.Drawing.Size(316, 546);
            this.basePanel2.TabIndex = 13;
            // 
            // dgKlienten
            // 
            this.dgKlienten.AutoWork = true;
            this.dgKlienten.DataMember = "PatientKostentraeger";
            this.dgKlienten.DataSource = this.dsPatientKostentraeger1;
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance20.BorderColor = System.Drawing.Color.Black;
            appearance20.FontData.SizeInPoints = 10F;
            this.dgKlienten.DisplayLayout.Appearance = appearance20;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 0;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Caption = "Klient";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 1;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 2;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Caption = "Gültig ab";
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 3;
            ultraGridColumn30.Header.Caption = "Gültig bis";
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 4;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 5;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 6;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 7;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 8;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 9;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 10;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 11;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 12;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 13;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 14;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 15;
            ultraGridColumn41.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41});
            this.dgKlienten.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgKlienten.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.GroupByBox.Appearance = appearance21;
            appearance22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKlienten.DisplayLayout.GroupByBox.BandLabelAppearance = appearance22;
            this.dgKlienten.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.GroupByBox.Prompt = "Einen Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance23.BackColor2 = System.Drawing.SystemColors.Control;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKlienten.DisplayLayout.GroupByBox.PromptAppearance = appearance23;
            this.dgKlienten.DisplayLayout.MaxColScrollRegions = 1;
            this.dgKlienten.DisplayLayout.MaxRowScrollRegions = 1;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgKlienten.DisplayLayout.Override.ActiveCellAppearance = appearance24;
            appearance25.BackColor = System.Drawing.SystemColors.Highlight;
            appearance25.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgKlienten.DisplayLayout.Override.ActiveRowAppearance = appearance25;
            this.dgKlienten.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.Override.CardAreaAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.White;
            appearance27.BorderColor = System.Drawing.Color.Silver;
            appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgKlienten.DisplayLayout.Override.CellAppearance = appearance27;
            this.dgKlienten.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgKlienten.DisplayLayout.Override.CellPadding = 0;
            appearance28.BackColor = System.Drawing.SystemColors.Control;
            appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance28.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.Override.GroupByRowAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance29.TextHAlignAsString = "Left";
            this.dgKlienten.DisplayLayout.Override.HeaderAppearance = appearance29;
            this.dgKlienten.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgKlienten.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            appearance30.BorderColor = System.Drawing.Color.Silver;
            this.dgKlienten.DisplayLayout.Override.RowAppearance = appearance30;
            this.dgKlienten.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgKlienten.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgKlienten.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgKlienten.DisplayLayout.Override.TemplateAddRowAppearance = appearance31;
            this.dgKlienten.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgKlienten.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgKlienten.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.dgKlienten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKlienten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgKlienten.Location = new System.Drawing.Point(0, 0);
            this.dgKlienten.Name = "dgKlienten";
            this.dgKlienten.Size = new System.Drawing.Size(316, 546);
            this.dgKlienten.TabIndex = 8;
            this.dgKlienten.Text = "ultraGrid1";
            this.dgKlienten.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgKlienten_BeforeRowsDeleted);
            this.dgKlienten.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgKlienten_DoubleClickRow);
            this.dgKlienten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgKlienten_KeyDown);
            // 
            // dsPatientKostentraeger1
            // 
            this.dsPatientKostentraeger1.DataSetName = "dsPatientKostentraeger";
            this.dsPatientKostentraeger1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientKostentraeger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // basePanel1
            // 
            this.basePanel1.Controls.Add(this.btnAddKlienten);
            this.basePanel1.Controls.Add(this.btnUpdateKlient);
            this.basePanel1.Controls.Add(this.btnDelKlienten);
            this.basePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.basePanel1.Location = new System.Drawing.Point(0, 0);
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(316, 48);
            this.basePanel1.TabIndex = 12;
            // 
            // btnAddKlienten
            // 
            this.btnAddKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance32.Image = ((object)(resources.GetObject("appearance32.Image")));
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddKlienten.Appearance = appearance32;
            this.btnAddKlienten.AutoWorkLayout = false;
            this.btnAddKlienten.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddKlienten.IsStandardControl = false;
            this.btnAddKlienten.Location = new System.Drawing.Point(227, 10);
            this.btnAddKlienten.Name = "btnAddKlienten";
            this.btnAddKlienten.Size = new System.Drawing.Size(24, 24);
            this.btnAddKlienten.TabIndex = 9;
            ultraToolTipInfo3.ToolTipText = "Hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAddKlienten, ultraToolTipInfo3);
            this.btnAddKlienten.Click += new System.EventHandler(this.btnAddKlienten_Click);
            // 
            // btnUpdateKlient
            // 
            this.btnUpdateKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance33.Image = ((object)(resources.GetObject("appearance33.Image")));
            appearance33.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance33.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateKlient.Appearance = appearance33;
            this.btnUpdateKlient.AutoWorkLayout = false;
            this.btnUpdateKlient.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateKlient.IsStandardControl = false;
            this.btnUpdateKlient.Location = new System.Drawing.Point(285, 10);
            this.btnUpdateKlient.Name = "btnUpdateKlient";
            this.btnUpdateKlient.Size = new System.Drawing.Size(24, 24);
            this.btnUpdateKlient.TabIndex = 11;
            ultraToolTipInfo4.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateKlient, ultraToolTipInfo4);
            this.btnUpdateKlient.Click += new System.EventHandler(this.btnUpdateKlient_Click);
            // 
            // btnDelKlienten
            // 
            this.btnDelKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance34.Image = ((object)(resources.GetObject("appearance34.Image")));
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance34.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelKlienten.Appearance = appearance34;
            this.btnDelKlienten.AutoWorkLayout = false;
            this.btnDelKlienten.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelKlienten.IsStandardControl = false;
            this.btnDelKlienten.Location = new System.Drawing.Point(256, 10);
            this.btnDelKlienten.Name = "btnDelKlienten";
            this.btnDelKlienten.Size = new System.Drawing.Size(24, 24);
            this.btnDelKlienten.TabIndex = 10;
            ultraToolTipInfo5.ToolTipText = "Entfernen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDelKlienten, ultraToolTipInfo5);
            this.btnDelKlienten.Click += new System.EventHandler(this.btnDelKlienten_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucKostenträger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.pnlSerch);
            this.Name = "ucKostenträger";
            this.Size = new System.Drawing.Size(1252, 625);
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).EndInit();
            this.pnlSerch.ResumeLayout(false);
            this.pnlSerch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatbezK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlgemein)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.pnlKostentraegerArt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKostentraeger1)).EndInit();
            this.panelObenAuswahl.ResumeLayout(false);
            this.panelButtonsOben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbTransferKt)).EndInit();
            this.basePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).EndInit();
            this.basePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
                

        public ucKostenträger()
		{
			InitializeComponent();
	    }

        public void initControl()
        {
            PMDS.GUI.UltraGridTools.AddZahlartValueList(dgMain, "Zahlart");
            sitemap.fillEnumBillTyp(this.dgKlienten.DisplayLayout.ValueLists[0], false);

            //PMDS.GUI.UltraGridTools.AddKostentraegerValueList(Guid IDPatient, dgMain, "IDKlinik", Settings.IDKlinik);


            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();

            UpdateBtnKostenttraegerAuswahlText();
            this.RefreshControl();
        }

        public dsKostentraeger.KostentraegerRow ActivRow
        {
            get
            {
                if (dgMain.ActiveRow == null)
                    return null;
                return (dsKostentraeger.KostentraegerRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgMain);
            }
        }

        public bool TransferKostentraegerJN
        {
            get { return _TransferKostentraegerJN; }
            set
            {
                _ValueChangedEnabled = false;
                _TransferKostentraegerJN = value;
                cbTransferKt.Checked = _TransferKostentraegerJN;
                cbAlgemein.Checked = !_TransferKostentraegerJN;
                cbPatbezK.Checked = !_TransferKostentraegerJN;
                opAuswahl.Value = _TransferKostentraegerJN ? 2 : 0;
                cbTransferKt.Visible = false;
                opAuswahl.Height = 32;
                lblKostentraeger.Visible = !_TransferKostentraegerJN;
                cbAlgemein.Visible = !_TransferKostentraegerJN;
                cbPatbezK.Visible = !_TransferKostentraegerJN;
                btnAddTrKt.Visible = _TransferKostentraegerJN;
                btnKostentraeger.Visible = !_TransferKostentraegerJN;
                SetKostentraegerArtFilter();
                _ValueChangedEnabled = true;
            }
        }

        public bool AddKlienten
        {
            get { return _AddKlienten; }
            set
            {
                _AddKlienten = value;
                splitContainer1.Panel2Collapsed = !_AddKlienten;
            }
        }

        public bool Save()
		{
            try
            {
                if (_dt == null)
                    return true;

                if (!_KostentraegerChenged)
                    return true;

                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);

                //Gelöschte Kostenträger wegen Referenzielleintegrität ganz am ende löschen
                List<dsKostentraeger.KostentraegerRow> aK = new List<dsKostentraeger.KostentraegerRow>();

                foreach (dsKostentraeger.KostentraegerRow r in _dt)
                {
                    if (r.RowState != DataRowState.Deleted) continue;
                    r.RejectChanges();
                    aK.Add(r);
                }
                _kostentraeger.Update(_dt);

                foreach (var r in _dsPatientKostentraeger.PatientKostentraeger)
                {
                    if (r.RowState != DataRowState.Deleted && !r.IsIDPatientIstZahlerNull())
                    {
                        r.SetIDPatientIstZahlerNull();
                    }
                }
                _PatientKostentraeger.Update(_dsPatientKostentraeger.PatientKostentraeger);

                //Gelöschte Kostenträger löschen
                foreach (dsKostentraeger.KostentraegerRow r in aK)
                {
                    _PatientKostentraeger.deletePatientKostenträger(r.ID);
                    r.Delete();
                }
                   
                _kostentraeger.Update(_dt);

                _KostentraegerChenged = false;
                SelectCurrentRow();
                _CurrentRow = null;
                SetControlsEnabled(true);
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
		}

        public bool IsChanged { get { return _KostentraegerChenged; } }

        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow row in dgMain.Rows)
            {
                if (row.IsGroupByRow || row.IsDeleted) continue;
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (!ValidateField(cell))
                    {
                        bError = true;
                        break;
                    }
                }

                if (bError) break;
            }

            //Kliente Prüfen
            if (!bError)
            {
                bError = !ValidateKlienten();
            }

            return !bError;
        }

        public void RefreshControl()
        {
            this.dsPatientKostentraeger1.Clear();
            _ValueChangedEnabled = false;

            if (loadForIDKlinik)
            {
                _dt = _kostentraeger.GetKostentraeger(cbAlgemein.Checked, cbPatbezK.Checked, cbTransferKt.Checked, true, ENV.IDKlinik);
            }
            else
            {
                if (_ForPatientExclusive)
                    _dt = _kostentraeger.ReadForPatient(true,false, System.Guid.Empty);
                else
                    _dt = _kostentraeger.GetKostentraeger(cbAlgemein.Checked, cbPatbezK.Checked, cbTransferKt.Checked, false, System.Guid.Empty);
            }

            this.cboGridKostenträger1.loadData();

            dgMain.DataSource = _dt;
            RefreshValueLists();
            this._dsPatientKostentraeger = _PatientKostentraeger.Read2();

            dgKlienten.DataSource = this._dsPatientKostentraeger;
            dgKlienten.DataMember = this._dsPatientKostentraeger.PatientKostentraeger.TableName;
            RefreshColors();

            SetFilter();
            _ValueChangedEnabled = true;

            dgMain.Selected.Rows.Clear();
            dgMain.ActiveRow = null;

            _KostentraegerChenged = false;

            HideOrShowPatienTransferColumns();
            //dgMainSetColumnOrder();
        }

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                InitializeGridLayout();
            }
        }
       	
        private bool ValidateKlienten()
        {
            bool bError = false;
            foreach (UltraGridRow row in dgKlienten.Rows)
            {
                if (row.IsFilteredOut) continue;
                if (!ValidateField(row))
                {
                    bError = true;
                    break;
                }
            }
            return !bError;
        }

        private void SelectCurrentRow()
        {
            if (_CurrentRow == null || _CurrentRow.RowState == DataRowState.Detached || _CurrentRow.RowState == DataRowState.Deleted) return;

            foreach (UltraGridRow r in dgMain.Rows)
            {
                if (r.Hidden || r.IsFilteredOut || r.IsDeleted) continue;
                if ((Guid)r.Cells["ID"].Value == _CurrentRow.ID)
                {
                    dgMain.ActiveRow = r;
                    r.Selected = true;
                    break;
                }
            }
        }

        private void RefreshColors()
        {
            foreach (UltraGridRow r in dgMain.Rows)
                RefreshColors(r);
        }

        private void RefreshColors(UltraGridRow r)
        {
            if (!(bool)r.Cells[_dt.TransferleistungJNColumn.ColumnName].Value &&
               !(bool)r.Cells[_dt.PatientbezogenJNColumn.ColumnName].Value
                )
            {
                r.Appearance.BackColor = cbAlgemein.BackColor;
            }
            else if ((bool)r.Cells[_dt.PatientbezogenJNColumn.ColumnName].Value)
                r.Appearance.BackColor = cbPatbezK.BackColor;
            else if ((bool)r.Cells[_dt.TransferleistungJNColumn.ColumnName].Value)
                r.Appearance.BackColor = cbTransferKt.BackColor;
        }

        private void HideOrShowPatienTransferColumns()
        {
            bool hidePatient = false;
            bool hideTransfer = false;
            
            if((cbAlgemein.Checked && !cbPatbezK.Checked && !cbTransferKt.Checked) ||
               (!cbAlgemein.Checked && !cbPatbezK.Checked && cbTransferKt.Checked) ||
               (cbAlgemein.Checked && !cbPatbezK.Checked && cbTransferKt.Checked) ||
               (!cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked)
              )
                hidePatient = true;

            if ((cbAlgemein.Checked && !cbPatbezK.Checked && !cbTransferKt.Checked) ||
                (!cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked) ||
                (cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked) ||
                (!cbAlgemein.Checked && !cbPatbezK.Checked && cbTransferKt.Checked)
               )
                hideTransfer = true;

            if ((!cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked))
            {
                dgMain.DisplayLayout.Bands[0].Columns[_dt.TaschengeldJNColumn.ColumnName].Hidden = false ;
            }
            else
            {
                dgMain.DisplayLayout.Bands[0].Columns[_dt.TaschengeldJNColumn.ColumnName].Hidden = true;
            }
            dgMain.DisplayLayout.Bands[0].Columns[_dt.PatientbezogenJNColumn.ColumnName].Hidden = hidePatient;
          
            dgMain.DisplayLayout.Bands[0].Columns[_dt.TransferleistungJNColumn.ColumnName].Hidden = hideTransfer;

            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Clear();
            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Add(FilterComparisionOperator.Equals, Guid.Empty);

            dgMain.Selected.Rows.Clear();
            dgMain.ActiveRow = null;
        }

        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsKostentraeger.KostentraegerRow r = (dsKostentraeger.KostentraegerRow)v.Row;
            dsKostentraeger.KostentraegerDataTable dt = (dsKostentraeger.KostentraegerDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");

            if (cell.Column.Key == dt.FIBUKontoColumn.ColumnName || cell.Column.Key == dt.NameColumn.ColumnName ||
                    cell.Column.Key == dt.StrasseColumn.ColumnName || cell.Column.Key == dt.PLZColumn.ColumnName ||
                    cell.Column.Key == dt.OrtColumn.ColumnName
                    )
            {
                GuiUtil.ValidateField(dgMain, cell.Text.Trim().Length > 0,
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger") + " " + cell.Row.Cells["Name"].Value + " - " + cell.Column.Header.Caption.Trim() + ": " + ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                if (!bError && cell.Column.Key == dt.FIBUKontoColumn.ColumnName && ENV.ForceUniqueFiBu)  //Fibu Konto muss eindeutig sein, wenn ForceUniqueFiBu gesetzt ist (=Standard)
                {
                    Guid id = (Guid)cell.Row.Cells[dt.IDColumn.ColumnName].Value;
                    dsKostentraeger.KostentraegerRow[] kRows = (dsKostentraeger.KostentraegerRow[])dt.Select("ID <> '" + id.ToString() + "' and FIBUKonto = '" + cell.Text.Trim() + "'");

                    string msg = QS2.Desktop.ControlManagment.ControlManagment.getRes("Konto (FIBU): ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern.");
                    GuiUtil.ValidateField(dgMain, kRows.Length == 0, msg, ref bError, false, null);
                    if (bError)
                        r.SetColumnError(cell.Column.Index, msg);
                }
            }

            if (!ForPatientExclusive && !cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked && cell.Column.Key == dt.PatientbezogenJNColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (bool)cell.Value, ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

        private void HandleDelete()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PMDS.GUI.UltraGridTools.AskRowDelete("Wollen Sie Kostenträgerzeile(n) wirklich löschen?\n\nHinweis: Damit werden auch alle Klientenverknüpungen gelöscht.") != DialogResult.Yes)
                return;

            using (PMDS.Calc.Admin.DB.DBPatientKostentraeger pk = new PMDS.Calc.Admin.DB.DBPatientKostentraeger())
            {
                dsPatientKostentraeger.PatientKostentraegerDataTable dt;
                dsKostentraeger.KostentraegerRow rk;
                DataRowView v;
                //bool delete = true;
                StringBuilder sb = new StringBuilder();
                foreach (UltraGridRow row in ra)
                {
                    v = (DataRowView)row.ListObject;

                    rk = (dsKostentraeger.KostentraegerRow)v.Row;
                    dt = pk.ReadByKostentraeger(rk.ID);

                    if (dt.Count > 0)
                    {
                        if (sb.Length > 0) sb.Append(", ");
                        sb.Append(rk.Name);
                    }

                    row.Delete(false);
                    _KostentraegerChenged = true;
                    SetControlsEnabled(false);
                    if (ValueChanged != null)
                        ValueChanged(this, null);

                    _dsPatientKostentraeger.PatientKostentraeger.Clear();
                    this.dgKlienten.Refresh();
                }
            }
        }

        public void SelectKostentraeger(Guid idKostentraeger)
        {
            if (idKostentraeger != Guid.Empty)
            {
                IDKostentraeger = idKostentraeger;
                _Filtergesetzt = true;
                if (_dt.Count > 0)
                {
                    _ValueChangedEnabled = false;
                    tbSearch.Text = _dt[0].Name;
                    _ValueChangedEnabled = true;
                }
            }
        }
        public void notEditable( )
        {
            panelButtonsOben.Visible = false;
        }

        private void InitializeGridLayout()
        {
            dgMain.DisplayLayout.Bands[0].Override.CellClickAction = ReadOnly ? CellClickAction.RowSelect : CellClickAction.EditAndSelectText;

            foreach (UltraGridColumn c in dgMain.DisplayLayout.Bands[0].Columns)
            {
                c.CellActivation = ReadOnly ? Activation.NoEdit : Activation.AllowEdit;
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            tbSearch.Enabled = true;
            cbAlgemein.Enabled = true;
            cbPatbezK.Enabled = true;
            cbTransferKt.Enabled = true;
        }

        private void AddKostentraeger()
        {
            tbSearch.Text = "";
            dsKostentraeger.KostentraegerRow r = null;
            switch ((int)opAuswahl.Value)
            {
                case 0:
                    cbAlgemein.Checked = true;
                    cbPatbezK.Checked = false;
                    cbTransferKt.Checked = false;
                    r = _kostentraeger.New(_dt);
                    break;
                case 1:
                    cbAlgemein.Checked = false;
                    cbPatbezK.Checked = true;
                    cbTransferKt.Checked = false;
                    r = _kostentraeger.NewPatientBetzogeneKostentraeger(_dt);
                    break;
                case 2:
                    cbAlgemein.Checked = false;
                    cbPatbezK.Checked = false;
                    cbTransferKt.Checked = true;
                    r = _kostentraeger.New(_dt);
                    r.TransferleistungJN = true;
                     break;
            }

            r.FIBUKonto = "";   //sNewFIBUKonto;
            _CurrentRow = r;
            dgMain.Focus();
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, _dt.FIBUKontoColumn.ColumnName);
            
            _KostentraegerChenged = true;
            SetControlsEnabled(false);
            
            if(dgMain.ActiveRow != null)
                RefreshColors(dgMain.ActiveRow);
            if (ValueChanged != null)
                ValueChanged(this, null);
        }

        public string getFIBUKontoAuto(System.Guid IDKlinik, ref string sNewFIBUKonto, string Bereich)
        {
            try
            {
                if (Bereich.Trim() != "")
                {
                    dsKlinik dsKlinik1 = new dsKlinik();
                    PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(IDKlinik, true);

                    int nNewFIBUKonto = -1;
                    PMDS.Klient.UIKostenträger.cKostenträger cKostenträger1 = new PMDS.Klient.UIKostenträger.cKostenträger();

                    cKostenträger1.newFIBUKonto(this._dt, ref sNewFIBUKonto, ref nNewFIBUKonto, Bereich);

                    string sNewFIBUKontoDb = "";
                    int nNewFIBUKontoDb = -1;
                    dsKostentraeger.KostentraegerDataTable tKostenträgerDb;
                    tKostenträgerDb = _kostentraeger.GetKostentraeger(true, true, true, this.loadForIDKlinik, ENV.IDKlinik);
                    cKostenträger1.newFIBUKonto(tKostenträgerDb, ref sNewFIBUKontoDb, ref nNewFIBUKontoDb, Bereich);

                    if (nNewFIBUKontoDb > nNewFIBUKonto)
                        sNewFIBUKonto = sNewFIBUKontoDb;
                }

                return sNewFIBUKonto;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return "";
            }
        }

        private void UpdateBtnKostenttraegerAuswahlText()
        {
            switch ((int)opAuswahl.Value)
            {
                case 0:
                    btnKostentraeger.Text = string.Format(_txtKostentraeger, QS2.Desktop.ControlManagment.ControlManagment.getRes("Allgemeine"));
                    break;
                case 1:
                    btnKostentraeger.Text = string.Format(_txtKostentraeger, QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientenbezogene"));
                    break;
                case 2:
                    btnKostentraeger.Text = string.Format(_txtKostentraeger, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transfer"));
                    break;
            }

        }

        private void btnDel_Click(object sender, System.EventArgs e)
		{
            HandleDelete();
		}

		private void dgMain_AfterRowUpdate(object sender, RowEventArgs e)
		{
            _KostentraegerChenged = true;
        }

		private void dgMain_AfterRowsDeleted(object sender, EventArgs e)
		{
            _KostentraegerChenged = true;
		}

        public Guid IDKostentraeger
        {
            get { return _IDKostentraeger; }
            set
            {
                _IDKostentraeger = value;
                _dt = _kostentraeger.GetKostentraeger(_IDKostentraeger);
                dgMain.DataSource = _dt;
                RefreshColors();
            }
        }

		public bool ForPatientExclusive
		{
			get { return _ForPatientExclusive; }
			set 
			{ 
				_ForPatientExclusive = value;
                RefreshControl();
                _ValueChangedEnabled = false;
                
				if (_ForPatientExclusive)
				{
                    pnlSerch.Visible = false;
                    lblKostentraeger.Visible = false;
					cbAlgemein.Visible = false;
                    cbAlgemein.Checked = false;
					cbPatbezK.Visible = false;
                    cbPatbezK.Checked = true;
                    cbTransferKt.Visible = false;
                    cbTransferKt.Checked = false;
                }
				else
				{
                    pnlSerch.Visible = true;
                    lblKostentraeger.Visible = true;
					cbAlgemein.Visible = true;
                    cbAlgemein.Checked = false;
                    cbPatbezK.Visible = true;
                    cbPatbezK.Checked = false;
                    cbTransferKt.Visible = true;
                    cbTransferKt.Checked = false;
                }

                _ValueChangedEnabled = true;
			} 	
		}

        public bool ShowButtons
        {
            get { return btnKostentraeger.Visible; }
            set
            {
                btnKostentraeger.Visible = value;
                btnDel.Visible = value;
            }
        }

        public bool SaveBeforSetFilter
        {
            get { return _SaveBeforSetFilter; }
            set { _SaveBeforSetFilter = value; }
        }

        private void SetFilter()
        {
            dgMain.BeginUpdate();
            dgMain.Rows.ColumnFilters.ClearAllFilters();

            if (tbSearch.Text.Trim().Length > 0)
                dgMain.Rows.ColumnFilters["Name"].FilterConditions.Add(FilterComparisionOperator.Contains, tbSearch.Text.Trim());
            else if(txtKonto.Text.Trim().Length > 0)
                dgMain.Rows.ColumnFilters["FIBUKonto"].FilterConditions.Add(FilterComparisionOperator.Contains, txtKonto.Text.Trim());
            dgMain.EndUpdate();

            if (dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
            {
                dgMain.ActiveRow.Selected = true;
                return;
            }

            foreach (UltraGridRow r in dgMain.Rows)
            {
                if (!r.IsFilteredOut)
                {
                    dgMain.ActiveRow = r;
                    dgMain.ActiveRow.Selected = true;
                    break;
                }
            }
        }

        private void MessageSaveBevore()
        {
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
        }

        private void dgMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (dgMain.ActiveCell != null && dgMain.ActiveCell.IsInEditMode)
            //            return;
            //        e.Handled = true;
            //    }
            //    HandleDelete();
            //}
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cbAlgemein.Focused || this.cbPatbezK.Focused || this.cbTransferKt.Focused)
                {
                    if (!_ValueChangedEnabled)
                        return;

                    UltraCheckEditor chkCont = ((UltraCheckEditor)sender);
                    if (this.IsChanged)
                    {
                        if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Änderungen gespeichert werden??", "Speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (!this.Save())
                            {
                                _ValueChangedEnabled = false;
                                chkCont.Checked = !chkCont.Checked;
                                _ValueChangedEnabled = true;

                                return;
                            }
                            else
                            {
                                if (stateToSaved != null)
                                    stateToSaved(this, null);

                                SetKostentraegerArtFilter();
                            }
                        }
                        else
                        {
                            this.RefreshControl();

                            if (stateToSaved != null)
                                    stateToSaved(this, null);
                            return;
                        }
                    }
                    else
                    {
                        SetKostentraegerArtFilter();
                    }
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

        private void SetKostentraegerArtFilter()
        {
            if (_refreshData && !_Filtergesetzt)
            {
                _dt = _kostentraeger.GetKostentraeger(cbAlgemein.Checked, cbPatbezK.Checked, cbTransferKt.Checked, this.loadForIDKlinik, ENV.IDKlinik);
                dgMain.DataSource = _dt;
                RefreshColors();
            }
            HideOrShowPatienTransferColumns();
        }

        private void RefreshValueLists()
        {
            try
            {
                dgKlienten.DisplayLayout.ValueLists.Clear();
                GuiTools.AddKostentraegerArtValueList(dgKlienten, "enumKostentraegerart");
                PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgKlienten, "IDBenutzer");
                PMDS.UI.Sitemap.UIFct.getAllPatientsFromAllKliniken(dgKlienten, "IDPatient");
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }

        private void InitKlienten()
        {
            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Clear();
            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Add(FilterComparisionOperator.Equals, Guid.Empty);

            if (splitContainer1.Panel2Collapsed) return;
            if (ActivRow == null) return;

            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Clear();
            dgKlienten.DisplayLayout.Bands[0].ColumnFilters["IDKostentraeger"].FilterConditions.Add(FilterComparisionOperator.Equals, ActivRow.ID);


            dgKlienten.Selected.Rows.Clear();
            dgKlienten.ActiveRow = null;
        }

        private void KlientenZuordnen(  )
        {
            dsPatientKostentraeger.PatientKostentraegerRow r = _PatientKostentraeger.New(_dsPatientKostentraeger.PatientKostentraeger, Guid.Empty, ActivRow.ID);

            if (ActivRow.TransferleistungJN)
            {
                r.enumKostentraegerart = (int)Kostentraegerart.Transferleistung;
                r.RechnungTyp = (int)PMDS.Calc.Logic.eBillTyp.Zahlungsbestätigung;
                r.SetIDPatientIstZahlerNull();
            }

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgKlienten, "IDPatient");

            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
            frmKostenträgerKlienten frm = new frmKostenträgerKlienten();
            if (!ActivRow.IsIDKlinikNull())
            {
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(ActivRow.IDKlinik, true);
                frm.rKlinikActuell = rKlinikActuell;
                dt = this.sitemap.loadAllKlientenProdHist(true, rKlinikActuell.ID, dt);
            }
            else
            {
                frm.rKlinikActuell = null;
                dt = this.sitemap.loadAllKlientenProdHistAllKliniken(true);
            }

            UltraGridRow selctedGridRow = null;
            dsKostentraeger.KostentraegerRow rKostSelected = this.getSelectedKostenträger(false, ref selctedGridRow);

            frm.KostentraegerRow = ActivRow;
            frm.neuanlage = true;
            frm.initControl(dt, "Name", "ID", rKostSelected);

            frm.PatientKostentraegerRow = r;
            frm.KostentraegerDataTable = _dsPatientKostentraeger.PatientKostentraeger;
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {                
                ValidateField(dgKlienten.ActiveRow);
                _KostentraegerChenged = true;
                if (ValueChanged != null)
                    ValueChanged(this, null);
            }
            else
                r.Delete();
        }

        private void UpdateKlientdaten()
        {
            dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgKlienten);

            if (r == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Satz ausgewählt.", "Klient zu Kostenträger zuordnen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
            frmKostenträgerKlienten frm = new frmKostenträgerKlienten();
            if (!ActivRow.IsIDKlinikNull())
            {
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(ActivRow.IDKlinik, true);
                frm.rKlinikActuell = rKlinikActuell;
                dt = this.sitemap.loadAllKlientenProdHist(true, rKlinikActuell.ID, dt);
            }
            else
            {
                frm.rKlinikActuell = null;
                dt = this.sitemap.loadAllKlientenProdHistAllKliniken(true);
            }
            UltraGridRow selctedGridRow = null;

            dsKostentraeger.KostentraegerRow rKostSelected = this.getSelectedKostenträger(false, ref selctedGridRow);
            frm.initControl(dt, "Name", "ID", rKostSelected);

            frm.KostentraegerRow = ActivRow;
            frm.PatientKostentraegerRow = r;
            frm.IDKlient = (System.Guid ) dgKlienten.ActiveRow.Cells["IDPatient"].Value ;

            if (dgKlienten.ActiveRow != null)
                frm.Filter = dgKlienten.ActiveRow.Cells["IDPatient"].Text.Trim();
            frm.KostentraegerDataTable = _dsPatientKostentraeger.PatientKostentraeger;

            DialogResult res = frm.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                _KostentraegerChenged = true;
                ValidateField(dgKlienten.ActiveRow);
                if (ValueChanged != null)
                    ValueChanged(this, null);
            }
        }

        private bool ValidateField(UltraGridRow row)
        {
            //bool bError = false;

            //if (row == null || row.ListObject == null)
            //    return !bError;

            //DataRowView v = (DataRowView)row.ListObject;
            //dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)v.Row;

            //r.SetColumnError(_dtPatientKostentraeger.GueltigAbColumn, "");
            //r.SetColumnError(_dtPatientKostentraeger.GueltigBisColumn, "");

            //DateTime ab = r.GueltigAb;
            //DateTime bis = r.IsGueltigBisNull() ? abrech.GueltigBis : r.GueltigBis;
            //StringBuilder sb;
            //DateTime prBis;
            //foreach (dsPatientKostentraeger.PatientKostentraegerRow pr in _dtPatientKostentraeger)
            //{
            //    if (pr.RowState == DataRowState.Deleted) continue;

            //    if (pr.ID == (Guid)row.Cells[_dt.IDColumn.ColumnName].Value) continue;
            //    prBis = (pr.IsGueltigBisNull()) ? abrech.GueltigBis : pr.GueltigBis;

            //    if (pr.IDKostentraeger != r.IDKostentraeger) continue;
            //    if (pr.IDPatient != r.IDPatient) continue;

            //    sb = new StringBuilder();
            //    sb.Append("Klient " + row.Cells[_dtPatientKostentraeger.IDPatientColumn.ColumnName].Text + ":Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //    if (!r.IsGueltigBisNull())
            //        sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //    sb.Append(" existiert bereits der gleiche Kostenträger. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");

            //    GuiUtil.ValidateField(dgMain, (bis.Date < prBis.Date || ab.Date > prBis.Date),
            //                         sb.ToString(), ref bError, false, null);

            //    if (bError)
            //    {
            //        r.SetColumnError(_dtPatientKostentraeger.GueltigAbColumn, sb.ToString());

            //        if(!r.IsGueltigBisNull())
            //            r.SetColumnError(_dtPatientKostentraeger.GueltigBisColumn, sb.ToString());
            //        break;
            //    }
            //}

            return true;
        }

        private void RemoveSelectedKlienten()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgKlienten.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgKlienten.ActiveRow != null && !dgKlienten.ActiveRow.IsFilteredOut)
                al.Add(dgKlienten.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;
            
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            bool del = false;
            DateTime guetigAb, gueltigBis;
            foreach (UltraGridRow r in ra)
            {
                if (TransferKostentraegerJN)
                {
                    guetigAb = (DateTime)r.Cells[dt.GueltigAbColumn.ColumnName].Value;
                    gueltigBis = (DateTime)r.Cells[dt.GueltigBisColumn.ColumnName].Value;
                    r.Delete(false);
                    del = true;
                }
                else
                {
                    r.Delete(false);
                    del = true;
                }
            }

            if (del)
            {
                _KostentraegerChenged = true;

                if (ValueChanged != null)
                    ValueChanged(this, null);
            }

            if (!del) 
                return;
            
            if (dgKlienten.Rows.GetFilteredInNonGroupByRows().Length > 0)
            {
                dgKlienten.ActiveRow = dgKlienten.Rows.GetFilteredInNonGroupByRows()[0];
                dgKlienten.ActiveRow.Selected = true;
            }
            else
                dgKlienten.ActiveRow = null;
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                _KostentraegerChenged = true;

                if (e.Cell.Column.ToString() == "IDKlinik")
                {
                    this.dgMainIDKlinikChanged(e.Cell.Row);
                }

                SetControlsEnabled(false);
                if (ValueChanged != null)
                    ValueChanged(this, e);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void dgMainIDKlinikChanged(Infragistics.Win.UltraWinGrid.UltraGridRow GridRow)
        {
            try
            {
                this.dgMain.UpdateData();

                dsKostentraeger.KostentraegerRow rKostSelected = (dsKostentraeger.KostentraegerRow)((System.Data.DataRowView)GridRow.ListObject).Row;
                if (!rKostSelected.IsIDKlinikNull())
                {
                    dsKlinik dsKlinik1 = new dsKlinik();
                    PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(rKostSelected.IDKlinik, true);

                    if (rKostSelected.FIBUKonto.Trim() == "")
                    {
                        string sNewFIBUKonto = "";
                        if (rKlinikActuell.Bereich.Trim() == "")
                            rKlinikActuell.Bereich = "0";
                        this.getFIBUKontoAuto(rKostSelected.IDKlinik, ref sNewFIBUKonto, rKlinikActuell.Bereich.Trim());
                        rKostSelected.FIBUKonto = sNewFIBUKonto;
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public dsKostentraeger.KostentraegerRow getSelectedKostenträger(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                this.dgMain.UpdateData();

                if (this.dgMain.ActiveRow.IsGroupByRow || this.dgMain.ActiveRow.IsFilterRow)
                {
                    if (withMsgBox)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!");
                    }
                    return null; 
                }
                else
                {
                    if (this.dgMain.ActiveRow != null)
                    {
                        dsKostentraeger.KostentraegerRow rKostSelected = (dsKostentraeger.KostentraegerRow)((System.Data.DataRowView)this.dgMain.ActiveRow.ListObject).Row;
                        gridRow = this.dgMain.ActiveRow;
                        return rKostSelected;
                    }
                    else
                    {
                        if (withMsgBox)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!");
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return null;
            }
        }
        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            if (dgMain.Focused)
            {
                InitKlienten();

                if (AfterRowActivate != null)
                    AfterRowActivate(sender, e);

                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.enumKostentraegerartColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungJNColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungTypColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.IDPatientIstZahlerColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungsdruckTypColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.ErfasstAmColumn.ColumnName].Hidden = true;
                dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.IDBenutzerColumn.ColumnName].Hidden = true;
            }
        }

        private void tbSearch_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_ValueChangedEnabled)
                {
                    if (!String.IsNullOrWhiteSpace(tbSearch.Text))
                        txtKonto.Text = "";
                    if (_Filtergesetzt)
                        RefreshControl();
                    _Filtergesetzt = false;
                    SetFilter();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            AddKostentraeger();
        }

        private void opAuswahl_ValueChanged(object sender, EventArgs e)
        {
            UpdateBtnKostenttraegerAuswahlText();
        }

        private void btnKostentraeger_DroppingDown(object sender, CancelEventArgs e)
        {
            if (SaveBeforSetFilter && IsChanged)
            {
                e.Cancel = !Save();
            }
            else
            {
                e.Cancel = IsChanged;

                if (IsChanged)
                    MessageSaveBevore();
            }
        }

        private void btnKostentraeger_Click(object sender, EventArgs e)
        {
            AddKostentraeger();
        }

        private void btnAddKlienten_Click(object sender, EventArgs e)
        {
            if (ActivRow == null) return;
            KlientenZuordnen();
        }

        private void btnDelKlienten_Click(object sender, EventArgs e)
        {
            RemoveSelectedKlienten();
        }

        private void btnUpdateKlient_Click(object sender, EventArgs e)
        {
            if (ReadOnly || ActivRow == null) return;
            UpdateKlientdaten();
        }

        private void dgMain_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            if (!_ValueChangedEnabled || dgKlienten.ActiveRow == null) return;
            e.Cancel = !ValidateKlienten();
        }

        private void dgMain_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            string name = "";
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgMain.Selected.Rows)
            {
                if (String.IsNullOrWhiteSpace(name))
                {
                    name = row.Cells["Name"].Value.ToString().Trim();
                }

                if (name != row.Cells["Name"].Value.ToString().Trim())
                {
                    break;
                }
            }

            //Aktuelle KostenträgerRow veröffentlichen
            if (dgMain.Selected.Rows.Count == 1)
            {
                KostenträgerRowSelected = dgMain.Selected.Rows[0];
            }
            else
            {
                KostenträgerRowSelected = null;
            }
            KostentraegerRowChanged();
        }

        private void dgKlienten_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
            //{
            //    if (ReadOnly) return;
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (dgKlienten.ActiveCell != null && dgKlienten.ActiveCell.IsInEditMode)
            //            return;
            //        e.Handled = true;
            //    }
            //    RemoveSelectedKlienten();
            //}
        }

        private void dgKlienten_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (ActivRow == null || ReadOnly) return;
            UpdateKlientdaten();
        }

        private void txtKonto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_ValueChangedEnabled)
                {
                    if (!String.IsNullOrEmpty(txtKonto.Text))
                        tbSearch.Text = "";
                    if (_Filtergesetzt)
                        RefreshControl();
                    _Filtergesetzt = false;
                    SetFilter();
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

        private void dgMain_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.export.exportGrid(this.dgMain, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

        private void dgKlienten_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgKlienten.Focused)
                e.Cancel = true;
        }

        private void btnKostPrüfenDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    string msgTransReturn = "";
                    if (!this.b.validateKostenträgerForSave(ref msgTransReturn, this.dgMain, ref this.dsKostentraeger1, db))
                    {
                        string TitleTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger prüfen");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgTransReturn, TitleTxt, MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger wurden erfolgreich geprüft!", "Kostenträger prüfen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void dgMain_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            dgMain.SuspendLayout();
            dgMain.DisplayLayout.Bands[0].Columns["FIBUKonto"].Header.VisiblePosition = 0;
            dgMain.DisplayLayout.Bands[0].Columns["Name"].Header.VisiblePosition = 1;
            dgMain.DisplayLayout.Bands[0].Columns["Vorname"].Header.VisiblePosition = 2;
            dgMain.DisplayLayout.Bands[0].Columns["Anrede"].Header.VisiblePosition = 3;
            dgMain.DisplayLayout.Bands[0].Columns["Strasse"].Header.VisiblePosition = 4;
            dgMain.DisplayLayout.Bands[0].Columns["PLZ"].Header.VisiblePosition = 5;
            dgMain.DisplayLayout.Bands[0].Columns["Ort"].Header.VisiblePosition = 6;
            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsanschrift"].Header.VisiblePosition = 7;
            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsempfaenger"].Header.VisiblePosition = 8;
            dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Header.VisiblePosition = 9;
            dgMain.DisplayLayout.Bands[0].Columns["UIDNr"].Header.VisiblePosition = 10;

            dgMain.DisplayLayout.Bands[0].Columns["IDKlinik"].Header.VisiblePosition = 11;

            dgMain.DisplayLayout.Bands[0].Columns["SammelabrechnungJN"].Header.VisiblePosition = 12;
            dgMain.DisplayLayout.Bands[0].Columns["GSBG"].Header.VisiblePosition = 13;
            dgMain.DisplayLayout.Bands[0].Columns["Zahlart"].Header.VisiblePosition = 14;
            dgMain.DisplayLayout.Bands[0].Columns["ErlagscheingebuehrJN"].Header.VisiblePosition = 15;
            dgMain.DisplayLayout.Bands[0].Columns["Betrag"].Header.VisiblePosition = 16;

            dgMain.DisplayLayout.Bands[0].Columns["Bank"].Header.VisiblePosition = 17;
            dgMain.DisplayLayout.Bands[0].Columns["Kontonr"].Header.VisiblePosition = 18;
            dgMain.DisplayLayout.Bands[0].Columns["BLZ"].Header.VisiblePosition = 19;
            dgMain.DisplayLayout.Bands[0].Columns["TaschengeldJN"].Header.VisiblePosition = 20;

            dgMain.DisplayLayout.Bands[0].Columns["PatientbezogenJN"].Header.VisiblePosition = 21;
            dgMain.DisplayLayout.Bands[0].Columns["TransferleistungJN"].Header.VisiblePosition = 22;

            dgMain.DisplayLayout.Bands[0].Columns["FIBUKonto"].Width = 80;
            dgMain.DisplayLayout.Bands[0].Columns["Name"].Width = 200;
            dgMain.DisplayLayout.Bands[0].Columns["Vorname"].Width = 80;
            dgMain.DisplayLayout.Bands[0].Columns["Anrede"].Width = 80;
            dgMain.DisplayLayout.Bands[0].Columns["Strasse"].Width = 150;
            dgMain.DisplayLayout.Bands[0].Columns["PLZ"].Width = 60;
            dgMain.DisplayLayout.Bands[0].Columns["Ort"].Width = 150;
            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsanschrift"].Width = 130;
            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsempfaenger"].Width = 300;
            dgMain.DisplayLayout.Bands[0].Columns["IDKostentraegerSub"].Width = 150;
            dgMain.DisplayLayout.Bands[0].Columns["UIDNr"].Width = 150;

            dgMain.DisplayLayout.Bands[0].Columns["IDKlinik"].Width = 120;

            dgMain.DisplayLayout.Bands[0].Columns["SammelabrechnungJN"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["GSBG"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["Zahlart"].Width = 100;
            dgMain.DisplayLayout.Bands[0].Columns["ErlagscheingebuehrJN"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["Betrag"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["Bank"].Width = 150;
            dgMain.DisplayLayout.Bands[0].Columns["Kontonr"].Width = 150;
            dgMain.DisplayLayout.Bands[0].Columns["BLZ"].Width = 150;

            dgMain.DisplayLayout.Bands[0].Columns["TaschengeldJN"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["PatientbezogenJN"].Width = 50;
            dgMain.DisplayLayout.Bands[0].Columns["TransferleistungJN"].Width = 50;

            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsanschrift"].Header.Caption = "eMail";
            dgMain.DisplayLayout.Bands[0].Columns["Rechnungsanschrift"].Hidden = false;
            dgMain.ResumeLayout();
        }

        private void dgMain_VisibleChanged(object sender, EventArgs e)
        {
            UltraGridLayout ugl = new UltraGridLayout();
            InitializeLayoutEventArgs en = new InitializeLayoutEventArgs(ugl);
            dgMain_InitializeLayout_1(sender, en);
        }
    }
}
