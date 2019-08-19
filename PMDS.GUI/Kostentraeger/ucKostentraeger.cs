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

        public bool loadForIDKlinik = false;
		private bool _ForPatientExclusive = false;
        private bool _KostentraegerChenged = false;
        private bool _ValueChangedEnabled = true;
		private Guid _IDKostentraeger = Guid.Empty;
        private bool _ReadOnly = false;
        private bool _Filtergesetzt = false;
        private string _txtKostentraeger = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Kostenträger");

        private bool _refreshData = true;
        private bool _SaveBeforSetFilter = false;
        private dsKostentraeger.KostentraegerRow _CurrentRow = null;
        private bool _TransferKostentraegerJN = false;
        private bool _AddKlienten = true;
        public bool AssignToPatientKostenträger = true;

        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();

        public PMDSBusiness b = new PMDSBusiness();

        public bool bKlientenzuordnung = false;




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
        private QS2.Desktop.ControlManagment.BasePanel panelKostUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelObenAuswahl;
        private IContainer components;
        private dsPatientKostentraeger dsPatientKostentraeger1;
        public QS2.Desktop.ControlManagment.BaseButton btnExportExcel;
        private GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        private GUI.BaseControls.cboGridKostenträger cboGridKostenträger1;
        private Infragistics.Win.Misc.UltraButton btnKostPrüfenDB;
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
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Kostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Strasse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ort");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rechnungsempfaenger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rechnungsanschrift");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kontonr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bank");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FIBUKonto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErlagscheingebuehrJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TransferleistungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaschengeldJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zahlart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PatientbezogenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SammelabrechnungJN");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UIDNr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GSBG");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anrede");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraegerSub", -1, "dropDownKostenträger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatientIstZahler");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Tabelle nach Excel exportieren", Infragistics.Win.ToolTipImage.Default, "ExportE xcel", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Kostenträger hinzufügen", Infragistics.Win.ToolTipImage.Default, "Hinzufügen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientKostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraeger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("enumKostentraegerart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetragErrechnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VorauszahlungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungTyp");
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
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(954439811);
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
            this.panelKostUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelObenAuswahl = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonsOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.btnExportExcel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnKostentraeger = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnAddTrKt = new QS2.Desktop.ControlManagment.BaseButton();
            this.cbTransferKt = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnUpdateKlient = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelKlienten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddKlienten = new QS2.Desktop.ControlManagment.BaseButton();
            this.dgKlienten = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientKostentraeger1 = new PMDS.Global.db.Global.ds_abrechnung.dsPatientKostentraeger();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnKostPrüfenDB = new Infragistics.Win.Misc.UltraButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKostentraeger
            // 
            this.lblKostentraeger.Location = new System.Drawing.Point(3, 12);
            this.lblKostentraeger.Name = "lblKostentraeger";
            this.lblKostentraeger.Size = new System.Drawing.Size(34, 16);
            this.lblKostentraeger.TabIndex = 6;
            this.lblKostentraeger.Text = "Filter:";
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
            this.btnDel.Location = new System.Drawing.Point(336, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 24);
            this.btnDel.TabIndex = 6;
            ultraToolTipInfo6.ToolTipText = "Kostenträger entfernen";
            ultraToolTipInfo6.ToolTipTitle = "Entfernen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDel, ultraToolTipInfo6);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(44, 6);
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
            this.pnlSerch.Size = new System.Drawing.Size(941, 31);
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
            this.lblKonto.Location = new System.Drawing.Point(311, 9);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(66, 14);
            this.lblKonto.TabIndex = 152;
            this.lblKonto.Text = "Konto (Fibu)";
            // 
            // txtKonto
            // 
            this.txtKonto.Location = new System.Drawing.Point(383, 6);
            this.txtKonto.Name = "txtKonto";
            this.txtKonto.Size = new System.Drawing.Size(261, 21);
            this.txtKonto.TabIndex = 151;
            this.txtKonto.ValueChanged += new System.EventHandler(this.txtKonto_ValueChanged);
            // 
            // cbPatbezK
            // 
            appearance24.BorderColor = System.Drawing.Color.Black;
            this.cbPatbezK.Appearance = appearance24;
            this.cbPatbezK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.cbPatbezK.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.cbPatbezK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbPatbezK.Location = new System.Drawing.Point(142, 4);
            this.cbPatbezK.Name = "cbPatbezK";
            this.cbPatbezK.Size = new System.Drawing.Size(117, 29);
            this.cbPatbezK.TabIndex = 3;
            this.cbPatbezK.Text = "Klientenbezogene Kostenträger";
            this.cbPatbezK.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbPatbezK.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbAlgemein
            // 
            this.cbAlgemein.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(171)))), ((int)(((byte)(140)))));
            this.cbAlgemein.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(171)))), ((int)(((byte)(140)))));
            this.cbAlgemein.Location = new System.Drawing.Point(42, 4);
            this.cbAlgemein.Name = "cbAlgemein";
            this.cbAlgemein.Size = new System.Drawing.Size(95, 29);
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
            this.panelTop.Size = new System.Drawing.Size(941, 594);
            this.panelTop.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panelKostUnten);
            this.splitContainer1.Panel1.Controls.Add(this.panelObenAuswahl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdateKlient);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelKlienten);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddKlienten);
            this.splitContainer1.Panel2.Controls.Add(this.dgKlienten);
            this.splitContainer1.Size = new System.Drawing.Size(941, 594);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 95;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.pnlKostentraegerArt);
            this.panelGrid.Controls.Add(this.dgMain);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 37);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(941, 346);
            this.panelGrid.TabIndex = 97;
            // 
            // pnlKostentraegerArt
            // 
            this.pnlKostentraegerArt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlKostentraegerArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKostentraegerArt.Controls.Add(this.btnOk);
            this.pnlKostentraegerArt.Controls.Add(this.opAuswahl);
            this.pnlKostentraegerArt.Location = new System.Drawing.Point(704, 76);
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
            this.dgMain.DisplayLayout.Appearance = appearance3;
            ultraGridBand1.CardSettings.AllowLabelSizing = false;
            ultraGridBand1.CardSettings.LabelWidth = 140;
            ultraGridBand1.CardSettings.MaxCardAreaCols = 4;
            ultraGridBand1.CardSettings.MaxCardAreaRows = 2;
            ultraGridBand1.CardSettings.Width = 200;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(171, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Width = 163;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(130, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 142;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(48, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 51;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(129, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Width = 115;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Rechnungsempfänger";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(145, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "BIC";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(93, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Width = 71;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "IBAN";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(156, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(161, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Konto (FiBu)";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 10;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(146, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Width = 86;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "Erlagscheingebühr";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 11;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 24;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(126, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.Width = 100;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Caption = "Transferleistung";
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 13;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 26;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.Width = 87;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.Caption = "Depotgeld";
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 14;
            ultraGridColumn16.RowLayoutColumnInfo.OriginX = 30;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn16.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(111, 0);
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 15;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 36;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(172, 0);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.Caption = "Patientbezogen";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 16;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 28;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(85, 0);
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance4.TextHAlignAsString = "Center";
            ultraGridColumn19.CellAppearance = appearance4;
            appearance5.TextHAlignAsString = "Center";
            ultraGridColumn19.Header.Appearance = appearance5;
            ultraGridColumn19.Header.Caption = "Sammelabrechnung";
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 17;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 32;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(111, 0);
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.Caption = "UID Nr";
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 18;
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 34;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn21.CellAppearance = appearance6;
            ultraGridColumn21.Format = "###,###,##0.00";
            appearance7.TextHAlignAsString = "Right";
            ultraGridColumn21.Header.Appearance = appearance7;
            ultraGridColumn21.Header.Caption = "Zuschlag";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 19;
            ultraGridColumn21.RowLayoutColumnInfo.OriginX = 38;
            ultraGridColumn21.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn21.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn21.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 20;
            ultraGridColumn22.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn22.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(93, 0);
            ultraGridColumn22.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn22.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 21;
            ultraGridColumn23.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn23.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn23.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(110, 0);
            ultraGridColumn23.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn23.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn24.Header.Caption = "Einrichtung";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 22;
            ultraGridColumn24.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn24.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn24.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(158, 0);
            ultraGridColumn24.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn24.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn24.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn25.Header.Caption = "Rechnungsadresse für";
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 23;
            ultraGridColumn25.RowLayoutColumnInfo.OriginX = 40;
            ultraGridColumn25.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn25.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(165, 0);
            ultraGridColumn25.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn25.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 24;
            ultraGridColumn1.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
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
            ultraGridColumn25,
            ultraGridColumn1});
            ultraGridBand1.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraGridBand1.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraGridBand1.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.Color.DarkTurquoise;
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.CardCaptionAppearance = appearance8;
            ultraGridBand1.Override.CardSpacing = 5;
            ultraGridBand1.Override.CellSpacing = 0;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Override.HeaderAppearance = appearance9;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.GroupByBox.Hidden = true;
            this.dgMain.DisplayLayout.GroupByBox.Prompt = "Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.dgMain.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance16;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance18.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance19;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(941, 346);
            this.dgMain.TabIndex = 7;
            this.dgMain.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            this.dgMain.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_AfterCellUpdate);
            this.dgMain.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgMain_InitializeLayout);
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.AfterRowsDeleted += new System.EventHandler(this.dgMain_AfterRowsDeleted);
            this.dgMain.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_AfterRowUpdate);
            this.dgMain.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_BeforeRowActivate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.CellListSelect += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellListSelect);
            this.dgMain.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgMain_AfterSelectChange);
            this.dgMain.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.dgMain_BeforeSelectChange);
            this.dgMain.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgMain_BeforeCellActivate);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMain_KeyDown);
            // 
            // dsKostentraeger1
            // 
            this.dsKostentraeger1.DataSetName = "dsKostentraeger";
            this.dsKostentraeger1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKostentraeger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelKostUnten
            // 
            this.panelKostUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelKostUnten.Location = new System.Drawing.Point(0, 383);
            this.panelKostUnten.Name = "panelKostUnten";
            this.panelKostUnten.Size = new System.Drawing.Size(941, 34);
            this.panelKostUnten.TabIndex = 96;
            this.panelKostUnten.Visible = false;
            // 
            // panelObenAuswahl
            // 
            this.panelObenAuswahl.Controls.Add(this.btnKostPrüfenDB);
            this.panelObenAuswahl.Controls.Add(this.panelButtonsOben);
            this.panelObenAuswahl.Controls.Add(this.lblKostentraeger);
            this.panelObenAuswahl.Controls.Add(this.cbAlgemein);
            this.panelObenAuswahl.Controls.Add(this.cbTransferKt);
            this.panelObenAuswahl.Controls.Add(this.cbPatbezK);
            this.panelObenAuswahl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelObenAuswahl.Location = new System.Drawing.Point(0, 0);
            this.panelObenAuswahl.Name = "panelObenAuswahl";
            this.panelObenAuswahl.Size = new System.Drawing.Size(941, 37);
            this.panelObenAuswahl.TabIndex = 95;
            // 
            // panelButtonsOben
            // 
            this.panelButtonsOben.Controls.Add(this.ucKlinikDropDown1);
            this.panelButtonsOben.Controls.Add(this.btnExportExcel);
            this.panelButtonsOben.Controls.Add(this.btnKostentraeger);
            this.panelButtonsOben.Controls.Add(this.btnDel);
            this.panelButtonsOben.Controls.Add(this.btnAddTrKt);
            this.panelButtonsOben.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsOben.Location = new System.Drawing.Point(545, 0);
            this.panelButtonsOben.Name = "panelButtonsOben";
            this.panelButtonsOben.Size = new System.Drawing.Size(396, 37);
            this.panelButtonsOben.TabIndex = 95;
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(9, 8);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 162;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // btnExportExcel
            // 
            appearance21.Image = ((object)(resources.GetObject("appearance21.Image")));
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance21.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExportExcel.Appearance = appearance21;
            this.btnExportExcel.AutoWorkLayout = false;
            this.btnExportExcel.IsStandardControl = false;
            this.btnExportExcel.Location = new System.Drawing.Point(364, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(29, 24);
            this.btnExportExcel.TabIndex = 161;
            this.btnExportExcel.Tag = "P";
            ultraToolTipInfo1.ToolTipText = "Tabelle nach Excel exportieren";
            ultraToolTipInfo1.ToolTipTitle = "ExportE xcel";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportExcel, ultraToolTipInfo1);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnKostentraeger
            // 
            appearance22.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance22.BorderColor = System.Drawing.Color.DimGray;
            appearance22.Image = ((object)(resources.GetObject("appearance22.Image")));
            appearance22.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnKostentraeger.Appearance = appearance22;
            this.btnKostentraeger.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKostentraeger.Location = new System.Drawing.Point(128, 3);
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
            this.btnAddTrKt.Location = new System.Drawing.Point(218, 3);
            this.btnAddTrKt.Name = "btnAddTrKt";
            this.btnAddTrKt.Size = new System.Drawing.Size(140, 24);
            this.btnAddTrKt.TabIndex = 5;
            this.btnAddTrKt.Text = "Transfer Kostenträger";
            this.btnAddTrKt.Visible = false;
            this.btnAddTrKt.Click += new System.EventHandler(this.btnKostentraeger_Click);
            // 
            // cbTransferKt
            // 
            appearance23.BorderColor = System.Drawing.Color.Black;
            this.cbTransferKt.Appearance = appearance23;
            this.cbTransferKt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(231)))), ((int)(((byte)(147)))));
            this.cbTransferKt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(231)))), ((int)(((byte)(147)))));
            this.cbTransferKt.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbTransferKt.Location = new System.Drawing.Point(265, 4);
            this.cbTransferKt.Name = "cbTransferKt";
            this.cbTransferKt.Size = new System.Drawing.Size(91, 29);
            this.cbTransferKt.TabIndex = 4;
            this.cbTransferKt.Text = "Transfer Kostenträger";
            this.cbTransferKt.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbTransferKt.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // btnUpdateKlient
            // 
            this.btnUpdateKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance25.Image = ((object)(resources.GetObject("appearance25.Image")));
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateKlient.Appearance = appearance25;
            this.btnUpdateKlient.AutoWorkLayout = false;
            this.btnUpdateKlient.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateKlient.IsStandardControl = false;
            this.btnUpdateKlient.Location = new System.Drawing.Point(916, 5);
            this.btnUpdateKlient.Name = "btnUpdateKlient";
            this.btnUpdateKlient.Size = new System.Drawing.Size(22, 21);
            this.btnUpdateKlient.TabIndex = 11;
            ultraToolTipInfo3.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateKlient, ultraToolTipInfo3);
            this.btnUpdateKlient.Click += new System.EventHandler(this.btnUpdateKlient_Click);
            // 
            // btnDelKlienten
            // 
            this.btnDelKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance26.Image = ((object)(resources.GetObject("appearance26.Image")));
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelKlienten.Appearance = appearance26;
            this.btnDelKlienten.AutoWorkLayout = false;
            this.btnDelKlienten.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelKlienten.IsStandardControl = false;
            this.btnDelKlienten.Location = new System.Drawing.Point(894, 5);
            this.btnDelKlienten.Name = "btnDelKlienten";
            this.btnDelKlienten.Size = new System.Drawing.Size(22, 21);
            this.btnDelKlienten.TabIndex = 10;
            ultraToolTipInfo4.ToolTipText = "Entfernen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDelKlienten, ultraToolTipInfo4);
            this.btnDelKlienten.Click += new System.EventHandler(this.btnDelKlienten_Click);
            // 
            // btnAddKlienten
            // 
            this.btnAddKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance27.Image = ((object)(resources.GetObject("appearance27.Image")));
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddKlienten.Appearance = appearance27;
            this.btnAddKlienten.AutoWorkLayout = false;
            this.btnAddKlienten.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddKlienten.IsStandardControl = false;
            this.btnAddKlienten.Location = new System.Drawing.Point(872, 5);
            this.btnAddKlienten.Name = "btnAddKlienten";
            this.btnAddKlienten.Size = new System.Drawing.Size(22, 21);
            this.btnAddKlienten.TabIndex = 9;
            ultraToolTipInfo5.ToolTipText = "Hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAddKlienten, ultraToolTipInfo5);
            this.btnAddKlienten.Click += new System.EventHandler(this.btnAddKlienten_Click);
            // 
            // dgKlienten
            // 
            this.dgKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgKlienten.AutoWork = true;
            this.dgKlienten.DataMember = "PatientKostentraeger";
            this.dgKlienten.DataSource = this.dsPatientKostentraeger1;
            appearance28.BackColor = System.Drawing.Color.White;
            appearance28.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance28.BorderColor = System.Drawing.Color.Black;
            this.dgKlienten.DisplayLayout.Appearance = appearance28;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 0;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Caption = "Klient";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 1;
            ultraGridColumn27.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(186, 0);
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 2;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn40.Header.Caption = "Gültig ab";
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 3;
            ultraGridColumn41.Header.Caption = "Gültig bis";
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 4;
            ultraGridColumn42.Header.Caption = "Kostenträgerart";
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 5;
            ultraGridColumn42.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn43.Header.Caption = "Restzahler";
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 6;
            ultraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn70.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance29.TextHAlignAsString = "Right";
            appearance29.TextVAlignAsString = "Middle";
            ultraGridColumn70.CellAppearance = appearance29;
            ultraGridColumn70.Format = "###,###,##0.00";
            ultraGridColumn70.Header.Editor = null;
            ultraGridColumn70.Header.VisiblePosition = 7;
            ultraGridColumn70.MaskInput = "{double:-9.2}";
            ultraGridColumn70.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn70.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn70.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(52, 0);
            ultraGridColumn70.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn70.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn70.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn44.Header.Caption = "Erfasst am";
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 8;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.Caption = "Benutzer";
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 9;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn46.Header.Caption = "Abgerechnet bis";
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 10;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.Header.Caption = "Vorauszahlung";
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 11;
            ultraGridColumn48.Header.Caption = "Rechnung J/N";
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 12;
            ultraGridColumn49.Header.Caption = "Rechnungstyp";
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 13;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn70,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49});
            ultraGridBand2.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgKlienten.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgKlienten.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.GroupByBox.Appearance = appearance30;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKlienten.DisplayLayout.GroupByBox.BandLabelAppearance = appearance31;
            this.dgKlienten.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.GroupByBox.Prompt = "Einen Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance32.BackColor2 = System.Drawing.SystemColors.Control;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance32.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKlienten.DisplayLayout.GroupByBox.PromptAppearance = appearance32;
            this.dgKlienten.DisplayLayout.MaxColScrollRegions = 1;
            this.dgKlienten.DisplayLayout.MaxRowScrollRegions = 1;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgKlienten.DisplayLayout.Override.ActiveCellAppearance = appearance33;
            appearance34.BackColor = System.Drawing.SystemColors.Highlight;
            appearance34.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgKlienten.DisplayLayout.Override.ActiveRowAppearance = appearance34;
            this.dgKlienten.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance35.BackColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.Override.CardAreaAppearance = appearance35;
            appearance36.BackColor = System.Drawing.Color.White;
            appearance36.BorderColor = System.Drawing.Color.Silver;
            appearance36.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgKlienten.DisplayLayout.Override.CellAppearance = appearance36;
            this.dgKlienten.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgKlienten.DisplayLayout.Override.CellPadding = 0;
            appearance37.BackColor = System.Drawing.SystemColors.Control;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKlienten.DisplayLayout.Override.GroupByRowAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance38.TextHAlignAsString = "Left";
            this.dgKlienten.DisplayLayout.Override.HeaderAppearance = appearance38;
            this.dgKlienten.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgKlienten.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance39.BackColor = System.Drawing.SystemColors.Window;
            appearance39.BorderColor = System.Drawing.Color.Silver;
            this.dgKlienten.DisplayLayout.Override.RowAppearance = appearance39;
            this.dgKlienten.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgKlienten.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgKlienten.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgKlienten.DisplayLayout.Override.TemplateAddRowAppearance = appearance40;
            this.dgKlienten.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgKlienten.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgKlienten.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.dgKlienten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgKlienten.Location = new System.Drawing.Point(0, 26);
            this.dgKlienten.Name = "dgKlienten";
            this.dgKlienten.Size = new System.Drawing.Size(941, 140);
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
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnKostPrüfenDB
            // 
            this.btnKostPrüfenDB.Location = new System.Drawing.Point(473, 7);
            this.btnKostPrüfenDB.Name = "btnKostPrüfenDB";
            this.btnKostPrüfenDB.Size = new System.Drawing.Size(65, 22);
            this.btnKostPrüfenDB.TabIndex = 97;
            this.btnKostPrüfenDB.Text = "Prüfen";
            this.btnKostPrüfenDB.Click += new System.EventHandler(this.btnKostPrüfenDB_Click);
            // 
            // ucKostenträger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.pnlSerch);
            this.Name = "ucKostenträger";
            this.Size = new System.Drawing.Size(941, 625);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).EndInit();
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
                HideOrShowPatienTransferColumns();
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
                //Änderung nach 22.10.2008 MDA
                //else if (_IDPatient != Guid.Empty)
                //    _dt = _kostentraeger.GetAlgemeinPatientKostentraeger(_IDPatient);
                else
                    _dt = _kostentraeger.GetKostentraeger(cbAlgemein.Checked, cbPatbezK.Checked, cbTransferKt.Checked, false, System.Guid.Empty);
            }

            this.cboGridKostenträger1.loadData();

            HideOrShowPatienTransferColumns();
            dgMain.DataSource = _dt;
            RefreshValueLists();
            this._dsPatientKostentraeger = _PatientKostentraeger.Read2();
            //dgKlienten.Refresh();
            dgKlienten.DataSource = this._dsPatientKostentraeger;
            dgKlienten.DataMember = this._dsPatientKostentraeger.PatientKostentraeger.TableName;
            RefreshColors();

            SetFilter();
            _ValueChangedEnabled = true;

            dgMain.Selected.Rows.Clear();
            dgMain.ActiveRow = null;

            _KostentraegerChenged = false;
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

            //if ((cbAlgemein.Checked && !cbPatbezK.Checked && !cbTransferKt.Checked))
            //        {
            //            dgMain.DisplayLayout.Bands[0].Columns[_dt.SammelabrechnungJNColumn.ColumnName].Hidden = false;
            //        }
            //else
            //        {
            //            dgMain.DisplayLayout.Bands[0].Columns[_dt.SammelabrechnungJNColumn.ColumnName].Hidden = true;
            //        }

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

            //if (this.bKlientenzuordnung)
            //{
            //    bool bNoValidatePLZ = true;
            //}
            //else
            //{
                if (cell.Column.Key == dt.FIBUKontoColumn.ColumnName || cell.Column.Key == dt.NameColumn.ColumnName ||
                        cell.Column.Key == dt.StrasseColumn.ColumnName || cell.Column.Key == dt.PLZColumn.ColumnName ||
                        cell.Column.Key == dt.OrtColumn.ColumnName
                       )
                {
                    GuiUtil.ValidateField(dgMain, cell.Text.Trim().Length > 0,
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger") + " " + cell.Row.Cells["Name"].Value + " - " + cell.Column.Header.Caption.Trim() + ": " + ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                    if (bError)
                        r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                    if (!bError && cell.Column.Key == dt.FIBUKontoColumn.ColumnName)
                    {
                        //Fibu Konto muss eindeutig sein
                        Guid id = (Guid)cell.Row.Cells[dt.IDColumn.ColumnName].Value;
                        dsKostentraeger.KostentraegerRow[] kRows = (dsKostentraeger.KostentraegerRow[])dt.Select("ID <> '" + id.ToString() +
                                    "' and FIBUKonto = '" + cell.Text.Trim() + "'");

                        string msg = QS2.Desktop.ControlManagment.ControlManagment.getRes("Konto (FIBU): ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern.");
                        GuiUtil.ValidateField(dgMain, kRows.Length == 0, msg, ref bError, false, null);
                        if (bError)
                            r.SetColumnError(cell.Column.Index, msg);
                    }
                }
            //}

            if (!ForPatientExclusive && !cbAlgemein.Checked && cbPatbezK.Checked && !cbTransferKt.Checked && cell.Column.Key == dt.PatientbezogenJNColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (bool)cell.Value,
                                        ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
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
            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;

            PMDS.Calc.Admin.DB.DBPatientKostentraeger pk = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
            dsPatientKostentraeger.PatientKostentraegerDataTable dt;
            dsKostentraeger.KostentraegerRow rk;
            DataRowView v;
            //bool delete = true;
            StringBuilder sb = new StringBuilder();
            foreach (UltraGridRow row in ra)
            {
                v = (DataRowView)row.ListObject;
                //delete = true;

                rk = (dsKostentraeger.KostentraegerRow)v.Row;
                dt = pk.ReadByKostentraeger(rk.ID);

                if (dt.Count > 0)
                {
                    //delete = false;
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(rk.Name);
                }

                //if (delete)
                //{
                    row.Delete(false);
                    _KostentraegerChenged = true;
                    SetControlsEnabled(false);
                    if (ValueChanged != null)
                        ValueChanged(this, null);

                _dsPatientKostentraeger.PatientKostentraeger.Clear();
                    this.dgKlienten.Refresh();

                //}
            }

            //if (sb.Length > 0)
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Folgende Kostenträger (" + sb.ToString() + ") ist(sind) zu Klienten zugeordenet, Daher kann(können) nicht gelöscht werden.", "Kostenträger löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
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
            //this.dgMain.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            //dgMain.DisplayLayout.Bands[0].Override.CellClickAction = CellClickAction.RowSelect;

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
            //string sNewFIBUKonto = "";
            //this.getFIBUKontoAuto(ENV.IDKlinik, ref sNewFIBUKonto);

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
                //UltraGridTools.AddPatientenValueList(dgKlienten, "IDPatient");
                //PMDS.GUI.UltraGridTools.AddPatientenValueListFromAbteilungen(dgKlienten, "IDPatient", new List<Guid>().ToArray(), true);
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
                r.enumKostentraegerart = (int)Kostentraegerart.Transferleistung;

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgKlienten, "IDPatient");

            //frmKostentraegerKlienten frm = new frmKostentraegerKlienten(new Patient().AllEntries(), "TEXT", "ID");
            //dsPatientStation.PatientDataTable dt = Patient.ByFilter("", false, new List<Guid>().ToArray(), Guid.Empty, false);
            //DateTime datum = new DateTime(1900, 1, 1);
            //dsPatientStation.PatientDataTable dt = Patient.GetPatienten("", false, new List<Guid>().ToArray(), Guid.Empty,
            //    datum, datum, datum, datum);

            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();

            //frmKostentraegerKlienten frm = new frmKostentraegerKlienten(new Patient().AllEntries(), "TEXT", "ID");
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
            frm.initControl(dt, "Name", "ID");

            //UltraGridRow selctedGridRow = null;
            //dsKostentraeger.KostentraegerRow rKostSelected = this.getSelectedKostenträger(false, ref selctedGridRow);
            //if (rKostSelected == null)
            //{
            //    throw new Exception("KlientenZuordnen: No Kostenträger selected in Grid!");
            //}

            frm.neuanlage = true;
            frm.KostentraegerRow = ActivRow;
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
            //dsPatientStation.PatientDataTable dt = Patient.ByFilter("", false, new List<Guid>().ToArray(), Guid.Empty, false);
            //DateTime datum = new DateTime(1900, 1, 1);
            //dsPatientStation.PatientDataTable dt = Patient.GetPatienten("", false, new List<Guid>().ToArray(), Guid.Empty,
            //    datum, datum, datum, datum);

            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();

            //frmKostentraegerKlienten frm = new frmKostentraegerKlienten(new Patient().AllEntries(), "TEXT", "ID");
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
            frm.initControl(dt, "Name", "ID");

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
            //ArrayList al2xy = new ArrayList();
            bool del = false;
            //bool gefundenxy;
            DateTime guetigAb, gueltigBis;
            foreach (UltraGridRow r in ra)
            {
                //if (r.Cells[dt.AbgerechnetBisColumn.ColumnName].Value == DBNull.Value)
                //{
                    //Nur bei TransferLeistung:Ist der Kostenträger zur Tabelle PatientEinkommen zugeordenet?. Wenn ja nicht löschen
                    if (TransferKostentraegerJN)
                    {
                        guetigAb = (DateTime)r.Cells[dt.GueltigAbColumn.ColumnName].Value;
                        gueltigBis = (DateTime)r.Cells[dt.GueltigBisColumn.ColumnName].Value;
                        //gefunden = false;
                        //foreach (dsPatientEinkommen.PatientEinkommenRow pr in pedt)
                        //{
                        //    if (pr.IsIDKostentraegerNull() || pr.IDKostentraeger != (Guid)r.Cells["IDKostentraeger"].Value)
                        //        continue;
                        //    if (pr.IsGueltigBisNull())
                        //    {
                        //        if (pr.GueltigAb >= guetigAb && pr.GueltigAb <= gueltigBis)
                        //        {
                        //            gefunden = true;
                        //            break;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (!((pr.GueltigAb.Date < guetigAb.Date && pr.GueltigBis.Date < guetigAb.Date) || (pr.GueltigAb.Date > gueltigBis.Date && pr.GueltigBis.Date > gueltigBis.Date)))
                        //        {
                        //            gefunden = true;
                        //            break;
                        //        }
                        //    }
                        //}
                        //if (gefunden)
                        //    al2.Add(r);
                        //else
                        //{
                            r.Delete(false);
                            del = true;
                        //}
                    }
                    else
                    {
                        r.Delete(false);
                        del = true;
                    }
                //}
                //else
                //    al2.Add(r);
            }

            if (del)
            {
                _KostentraegerChenged = true;

                if (ValueChanged != null)
                    ValueChanged(this, null);
            }

            //ra = (UltraGridRow[])al2.ToArray(typeof(UltraGridRow));

            //StringBuilder sb = new StringBuilder();
            //sb.Append("Für folgende Datensätze sind Abrechnungen erstellt worden oder sind zu Transferleistungen des Klienten zugeordnet, daher können sie nicht gelöscht werden.\n\t");

            //foreach (UltraGridRow r in ra)
            //{
            //    sb.Append("- " + r.Cells[dt.IDPatientColumn.ColumnName].Text);
            //    sb.Append(", " + r.Cells[dt.GueltigAbColumn.ColumnName].Text);
            //    sb.Append(" - " + r.Cells[dt.GueltigBisColumn.ColumnName].Text);
            //    sb.Append(", " + r.Cells[dt.enumKostentraegerartColumn.ColumnName].Text + "\n\t");
            //}
            //if (ra.Length > 0)
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), "Löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!del) return;
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
        private void dgMain_CellListSelect(object sender, CellEventArgs e)
        {
            try
            {
                //if (e.Cell.Column.ToString() == "IDKlinik")
                //{
                //    this.dgMainIDKlinikChanged(e.Cell.Row);
                //}
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgMain_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                //if (e.Cell.Column.ToString() == "IDKlinik")
                //{
                //    this.dgMainIDKlinikChanged(e.Cell.Row);
                //}
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

                //Spalte RechnungJN nur für Klientbezogene Kostenträger anzeigen
                if (ActivRow != null)
                {
                    if (dgMain.ActiveRow != null)
                    {
                        if ((bool )dgMain.ActiveRow.Cells["TransferleistungJN"].Value == true )
                        {
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.enumKostentraegerartColumn .ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungJNColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungTypColumn.ColumnName].Hidden = false;
                        }
                        else if ((bool)dgMain.ActiveRow.Cells["TransferleistungJN"].Value == false && (bool)dgMain.ActiveRow.Cells["PatientbezogenJN"].Value == false)
                        {
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.enumKostentraegerartColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungJNColumn.ColumnName].Hidden = true;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungTypColumn.ColumnName].Hidden = true;

                            //Kostentraeger kost = new Kostentraeger();
                            //bool sammRechJN = kost.sammelabrechnungJN((System.Guid )dgMain.ActiveRow.Cells["ID"].Value);
                            //if (sammRechJN)
                            //{
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.BetragColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.enumKostentraegerartColumn.ColumnName].Hidden = true;
                            //}
                            //else
                            //{
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.BetragColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.enumKostentraegerartColumn.ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.RechnungJNColumn .ColumnName].Hidden = true;
                            //    dgKlienten.DisplayLayout.Bands[0].Columns[_dtPatientKostentraeger.RechnungTypColumn .ColumnName].Hidden = true;
                       
                            //}
                        }
                        else if ((bool)dgMain.ActiveRow.Cells["PatientbezogenJN"].Value == true)
                        {
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragErrechnetJNColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.BetragColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.VorauszahlungJNColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.enumKostentraegerartColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungJNColumn.ColumnName].Hidden = false;
                            dgKlienten.DisplayLayout.Bands[0].Columns[_dsPatientKostentraeger.PatientKostentraeger.RechnungTypColumn.ColumnName].Hidden = false;
                        }
                    }
                }
                if (AfterRowActivate != null)
                    AfterRowActivate(sender, e);

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
                    if (tbSearch.Text.Trim() != "")
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

        private void dgMain_BeforeRowActivate(object sender, RowEventArgs e)
        {
        }

        private void dgMain_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            if (!_ValueChangedEnabled || dgKlienten.ActiveRow == null) return;
            e.Cancel = !ValidateKlienten();
        }

        private void dgMain_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            //os: 140329: Was tut diese Funktion????
            //btnKlientenUebernehmen.Visible = dgMain.Selected.Rows.Count > 1;

            string name = "";
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgMain.Selected.Rows)
            {
                if (name == "")
                {
                    name = row.Cells["Name"].Value.ToString().Trim();
                }

                if (name != row.Cells["Name"].Value.ToString().Trim())
                {
                    break;
                }
            }
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
                    if (txtKonto.Text.Trim() != "")
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
            this.export.exportGrid(this.dgMain, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "");
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

        private void dgMain_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

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
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger wurden erfogreich geprüft!", "Kostenträger prüfen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
