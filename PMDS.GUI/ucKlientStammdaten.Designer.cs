using Infragistics.Win.UltraWinTabControl;
using PMDS.Global.db.Global;
using PMDS.GUI.Klient;

namespace PMDS.GUI
{
    partial class ucKlientStammdaten
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
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
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Bild vergrößern", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Bild speichern nach ...", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Bild laden von ...", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientAerzte", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAerzte");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HausarztJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZuweiserJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufnahmearztJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BehandelnderFAJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fachrichtung", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TelAdresse", 2);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlientStammdaten));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Sachwalter", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAdresse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Belange");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BestimmtAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TelAdresse", 0);
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblBesonderheit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBesonderheit = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkKZUeberlebender = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkAnatomie = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkMilieubetreuung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.dteTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkDNR = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkVerstorben = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelAufenthaltsdaten2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKennwort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGruppenKz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFallzahl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFallzahl = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtgruppenkennzahl = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraGroupBoxOben = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblPatientenverfügung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbStaatsB = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbAkdGrad = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbKonfession = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbAnrede = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblStatsB = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbFAM = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.txtVorname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKonf = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbSexus = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.txtNachname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblFamiliensst = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAkdGrad = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGebDat = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGeschl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.gebDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.panelAufenthaltsdaten = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtKliNr = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtZimmerNr = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKlientNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblZimNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraGroupBoxAllgemein1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblBeruf = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBeruf = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtGebOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGebOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtGebName = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGebName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnrede = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKosename = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtBesKennz = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblAeussKenz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInitBer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtInitialBer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraGroupBoxPersonebescheibung = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.btnMagnify = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnPicClear = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicLoad = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtGewicht = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtGroesse = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.cmbstatur = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbHaarFarbe = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbAugenFarbe = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.foto = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.lblGewicht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAugenfarbe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHaarFarbe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblStatur = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGroesse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.Namenstag = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblNamenstag = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pageControlAufenthalt = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucAbrechAufenthKlient1 = new PMDS.GUI.ucAbrechAufenthKlient();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ultraGroupBoxAngehörige = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucKontaktPersonen1 = new PMDS.GUI.ucKontaktPersonen();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ultraGroupBoxÄrtze = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.gridAerzte = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientAerzte1 = new PMDS.Global.db.Global.dsPatientAerzte();
            this.panelButtons1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnUpdateArzt = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelAerzte = new PMDS.GUI.ucButton(this.components);
            this.btnUpdateAerzte = new PMDS.GUI.ucButton(this.components);
            this.ultraGroupBoxSachverwalter = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraGridBagLayoutPanel3 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.gridSachwalter = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientSachwalter1 = new PMDS.Klient.dsKlientSachwalter();
            this.panelButtons2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnUpdateSachw = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelSachwalter = new PMDS.GUI.ucButton(this.components);
            this.btnAddSachw = new PMDS.GUI.ucButton(this.components);
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBoxAdressdaten = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lift = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.ultraLabel7 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblZustgStelle = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtZustgStelle = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblWohnSituation = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtWohnsituation = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblHausTier = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtHaustier = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKlingel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKlingeln = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.WohnungAb = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblEmail = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtEmail = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel9 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtMobil = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblErstKontakt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtTelefon = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel8 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel6 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel5 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPLZ = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFax = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel10 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBoxAdressdatenNWS = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.txtLandNWS = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.baseLabel6 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtEmailNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel7 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtMobilNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtTelefonNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel9 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.baseLabel10 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtOrtNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel11 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPLZNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasseNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel12 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFaxNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel13 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucBewerbungsdaten1 = new PMDS.GUI.ucBewerbungsdaten();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelDokumente = new System.Windows.Forms.Panel();
            this.ucKlientStammdatenDokumente1 = new PMDS.GUI.Klient.ucKlientStammdatenDokumente();
            this.contextMenuStripÄrzte = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zusammenführenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabStammdaten = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesonderheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKZUeberlebender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnatomie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMilieubetreuung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTodeszeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).BeginInit();
            this.panelAufenthaltsdaten2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKennwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgruppenkennzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxOben)).BeginInit();
            this.ultraGroupBoxOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAkdGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gebDatum)).BeginInit();
            this.panelAufenthaltsdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKliNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZimmerNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAllgemein1)).BeginInit();
            this.ultraGroupBoxAllgemein1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKosename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesKennz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxPersonebescheibung)).BeginInit();
            this.ultraGroupBoxPersonebescheibung.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbstatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaarFarbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAugenFarbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Namenstag)).BeginInit();
            this.pageControlAufenthalt.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAngehörige)).BeginInit();
            this.ultraGroupBoxAngehörige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxÄrtze)).BeginInit();
            this.ultraGroupBoxÄrtze.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAerzte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAerzte1)).BeginInit();
            this.panelButtons1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxSachverwalter)).BeginInit();
            this.ultraGroupBoxSachverwalter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel3)).BeginInit();
            this.ultraGridBagLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSachwalter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientSachwalter1)).BeginInit();
            this.panelButtons2.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdaten)).BeginInit();
            this.ultraGroupBoxAdressdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZustgStelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaustier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlingeln)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WohnungAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdatenNWS)).BeginInit();
            this.ultraGroupBoxAdressdatenNWS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLandNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrtNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseNWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaxNWS)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelDokumente.SuspendLayout();
            this.contextMenuStripÄrzte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStammdaten)).BeginInit();
            this.tabStammdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.AutoScroll = true;
            this.ultraTabPageControl2.Controls.Add(this.lblBesonderheit);
            this.ultraTabPageControl2.Controls.Add(this.txtBesonderheit);
            this.ultraTabPageControl2.Controls.Add(this.chkKZUeberlebender);
            this.ultraTabPageControl2.Controls.Add(this.chkAnatomie);
            this.ultraTabPageControl2.Controls.Add(this.chkMilieubetreuung);
            this.ultraTabPageControl2.Controls.Add(this.dteTodeszeitpunkt);
            this.ultraTabPageControl2.Controls.Add(this.lblTodeszeitpunkt);
            this.ultraTabPageControl2.Controls.Add(this.chkDNR);
            this.ultraTabPageControl2.Controls.Add(this.chkVerstorben);
            this.ultraTabPageControl2.Controls.Add(this.panelAufenthaltsdaten2);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxOben);
            this.ultraTabPageControl2.Controls.Add(this.panelAufenthaltsdaten);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxAllgemein1);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxPersonebescheibung);
            this.ultraTabPageControl2.Controls.Add(this.lblVorname);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1004, 610);
            this.ultraTabPageControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.ultraTabPageControl2_Paint);
            // 
            // lblBesonderheit
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblBesonderheit.Appearance = appearance1;
            this.lblBesonderheit.Location = new System.Drawing.Point(17, 427);
            this.lblBesonderheit.Name = "lblBesonderheit";
            this.lblBesonderheit.Size = new System.Drawing.Size(276, 20);
            this.lblBesonderheit.TabIndex = 208;
            this.lblBesonderheit.Text = "Informationen für die Dienstübergabe";
            // 
            // txtBesonderheit
            // 
            this.txtBesonderheit.AcceptsReturn = true;
            this.txtBesonderheit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBesonderheit.Location = new System.Drawing.Point(17, 454);
            this.txtBesonderheit.MaxLength = 65655;
            this.txtBesonderheit.Multiline = true;
            this.txtBesonderheit.Name = "txtBesonderheit";
            this.txtBesonderheit.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBesonderheit.Size = new System.Drawing.Size(971, 144);
            this.txtBesonderheit.TabIndex = 25;
            this.txtBesonderheit.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkKZUeberlebender
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.chkKZUeberlebender.Appearance = appearance2;
            this.chkKZUeberlebender.BackColor = System.Drawing.Color.Transparent;
            this.chkKZUeberlebender.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkKZUeberlebender.Location = new System.Drawing.Point(693, 426);
            this.chkKZUeberlebender.Name = "chkKZUeberlebender";
            this.chkKZUeberlebender.Size = new System.Drawing.Size(137, 20);
            this.chkKZUeberlebender.TabIndex = 207;
            this.chkKZUeberlebender.Text = "Holocaust";
            this.chkKZUeberlebender.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkAnatomie
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.chkAnatomie.Appearance = appearance3;
            this.chkAnatomie.BackColor = System.Drawing.Color.Transparent;
            this.chkAnatomie.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkAnatomie.Location = new System.Drawing.Point(843, 426);
            this.chkAnatomie.Name = "chkAnatomie";
            this.chkAnatomie.Size = new System.Drawing.Size(137, 20);
            this.chkAnatomie.TabIndex = 206;
            this.chkAnatomie.Text = "Anatomie";
            this.chkAnatomie.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkMilieubetreuung
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.chkMilieubetreuung.Appearance = appearance4;
            this.chkMilieubetreuung.BackColor = System.Drawing.Color.Transparent;
            this.chkMilieubetreuung.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkMilieubetreuung.Location = new System.Drawing.Point(520, 426);
            this.chkMilieubetreuung.Name = "chkMilieubetreuung";
            this.chkMilieubetreuung.Size = new System.Drawing.Size(137, 20);
            this.chkMilieubetreuung.TabIndex = 204;
            this.chkMilieubetreuung.Text = "Milieubetreuung";
            this.chkMilieubetreuung.Visible = false;
            this.chkMilieubetreuung.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // dteTodeszeitpunkt
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.White;
            appearance5.BackColorDisabled2 = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.dteTodeszeitpunkt.Appearance = appearance5;
            this.dteTodeszeitpunkt.BackColor = System.Drawing.Color.White;
            this.dteTodeszeitpunkt.FormatString = "";
            this.dteTodeszeitpunkt.Location = new System.Drawing.Point(843, 256);
            this.dteTodeszeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dteTodeszeitpunkt.Name = "dteTodeszeitpunkt";
            this.dteTodeszeitpunkt.Size = new System.Drawing.Size(136, 24);
            this.dteTodeszeitpunkt.TabIndex = 203;
            this.dteTodeszeitpunkt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblTodeszeitpunkt
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lblTodeszeitpunkt.Appearance = appearance6;
            this.lblTodeszeitpunkt.AutoSize = true;
            this.lblTodeszeitpunkt.Location = new System.Drawing.Point(743, 262);
            this.lblTodeszeitpunkt.Name = "lblTodeszeitpunkt";
            this.lblTodeszeitpunkt.Size = new System.Drawing.Size(98, 17);
            this.lblTodeszeitpunkt.TabIndex = 108;
            this.lblTodeszeitpunkt.Text = "Todeszeitpunkt";
            // 
            // chkDNR
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.chkDNR.Appearance = appearance7;
            this.chkDNR.BackColor = System.Drawing.Color.Transparent;
            this.chkDNR.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkDNR.Location = new System.Drawing.Point(514, 259);
            this.chkDNR.Name = "chkDNR";
            this.chkDNR.Size = new System.Drawing.Size(80, 20);
            this.chkDNR.TabIndex = 202;
            this.chkDNR.Text = "DNR";
            this.chkDNR.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkVerstorben
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.Appearance = appearance8;
            this.chkVerstorben.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkVerstorben.Location = new System.Drawing.Point(639, 260);
            this.chkVerstorben.Name = "chkVerstorben";
            this.chkVerstorben.Size = new System.Drawing.Size(96, 20);
            this.chkVerstorben.TabIndex = 200;
            this.chkVerstorben.Text = "Verstorben";
            this.chkVerstorben.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // panelAufenthaltsdaten2
            // 
            this.panelAufenthaltsdaten2.Controls.Add(this.ultraLabel2);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtKennwort);
            this.panelAufenthaltsdaten2.Controls.Add(this.lblGruppenKz);
            this.panelAufenthaltsdaten2.Controls.Add(this.lblFallzahl);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtFallzahl);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtgruppenkennzahl);
            this.panelAufenthaltsdaten2.Location = new System.Drawing.Point(503, 290);
            this.panelAufenthaltsdaten2.Name = "panelAufenthaltsdaten2";
            this.panelAufenthaltsdaten2.Size = new System.Drawing.Size(485, 77);
            this.panelAufenthaltsdaten2.TabIndex = 104;
            // 
            // ultraLabel2
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance9;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraLabel2.Location = new System.Drawing.Point(11, 49);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(63, 17);
            this.ultraLabel2.TabIndex = 100;
            this.ultraLabel2.Text = "Kennwort";
            // 
            // txtKennwort
            // 
            this.txtKennwort.Location = new System.Drawing.Point(136, 45);
            this.txtKennwort.MaxLength = 20;
            this.txtKennwort.Name = "txtKennwort";
            this.txtKennwort.Size = new System.Drawing.Size(340, 24);
            this.txtKennwort.TabIndex = 27;
            this.txtKennwort.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGruppenKz
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.lblGruppenKz.Appearance = appearance10;
            this.lblGruppenKz.AutoSize = true;
            this.lblGruppenKz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGruppenKz.Location = new System.Drawing.Point(227, 13);
            this.lblGruppenKz.Name = "lblGruppenKz";
            this.lblGruppenKz.Size = new System.Drawing.Size(113, 17);
            this.lblGruppenKz.TabIndex = 97;
            this.lblGruppenKz.Text = "Gruppenkennzahl";
            // 
            // lblFallzahl
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.lblFallzahl.Appearance = appearance11;
            this.lblFallzahl.AutoSize = true;
            this.lblFallzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFallzahl.Location = new System.Drawing.Point(11, 13);
            this.lblFallzahl.Name = "lblFallzahl";
            this.lblFallzahl.Size = new System.Drawing.Size(53, 17);
            this.lblFallzahl.TabIndex = 25;
            this.lblFallzahl.Text = "Fallzahl";
            // 
            // txtFallzahl
            // 
            this.txtFallzahl.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtFallzahl.Location = new System.Drawing.Point(136, 13);
            this.txtFallzahl.Name = "txtFallzahl";
            this.txtFallzahl.NonAutoSizeHeight = 20;
            this.txtFallzahl.Size = new System.Drawing.Size(80, 23);
            this.txtFallzahl.TabIndex = 25;
            this.txtFallzahl.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtgruppenkennzahl
            // 
            this.txtgruppenkennzahl.Location = new System.Drawing.Point(340, 9);
            this.txtgruppenkennzahl.MaxLength = 20;
            this.txtgruppenkennzahl.Name = "txtgruppenkennzahl";
            this.txtgruppenkennzahl.Size = new System.Drawing.Size(136, 24);
            this.txtgruppenkennzahl.TabIndex = 26;
            this.txtgruppenkennzahl.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxOben
            // 
            this.ultraGroupBoxOben.Controls.Add(this.lblPatientenverfügung);
            this.ultraGroupBoxOben.Controls.Add(this.cmbStaatsB);
            this.ultraGroupBoxOben.Controls.Add(this.cmbAkdGrad);
            this.ultraGroupBoxOben.Controls.Add(this.cmbKonfession);
            this.ultraGroupBoxOben.Controls.Add(this.cmbAnrede);
            this.ultraGroupBoxOben.Controls.Add(this.lblStatsB);
            this.ultraGroupBoxOben.Controls.Add(this.cmbFAM);
            this.ultraGroupBoxOben.Controls.Add(this.txtVorname);
            this.ultraGroupBoxOben.Controls.Add(this.lblKonf);
            this.ultraGroupBoxOben.Controls.Add(this.cmbSexus);
            this.ultraGroupBoxOben.Controls.Add(this.txtNachname);
            this.ultraGroupBoxOben.Controls.Add(this.lblFamiliensst);
            this.ultraGroupBoxOben.Controls.Add(this.ultraLabel1);
            this.ultraGroupBoxOben.Controls.Add(this.lblTitel);
            this.ultraGroupBoxOben.Controls.Add(this.lblNachname);
            this.ultraGroupBoxOben.Controls.Add(this.lblAkdGrad);
            this.ultraGroupBoxOben.Controls.Add(this.lblGebDat);
            this.ultraGroupBoxOben.Controls.Add(this.lblGeschl);
            this.ultraGroupBoxOben.Controls.Add(this.gebDatum);
            this.ultraGroupBoxOben.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxOben.Location = new System.Drawing.Point(3, 5);
            this.ultraGroupBoxOben.Name = "ultraGroupBoxOben";
            this.ultraGroupBoxOben.Size = new System.Drawing.Size(494, 196);
            this.ultraGroupBoxOben.TabIndex = 90;
            // 
            // lblPatientenverfügung
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientenverfügung.Appearance = appearance12;
            this.lblPatientenverfügung.AutoSize = true;
            this.lblPatientenverfügung.Location = new System.Drawing.Point(309, 163);
            this.lblPatientenverfügung.Name = "lblPatientenverfügung";
            this.lblPatientenverfügung.Size = new System.Drawing.Size(121, 17);
            this.lblPatientenverfügung.TabIndex = 97;
            this.lblPatientenverfügung.Text = "Patientenverfügung";
            this.lblPatientenverfügung.MouseEnter += new System.EventHandler(this.lblPatientenverfügung_MouseEnter);
            this.lblPatientenverfügung.MouseLeave += new System.EventHandler(this.lblPatientenverfügung_MouseLeave);
            this.lblPatientenverfügung.MouseHover += new System.EventHandler(this.lblPatientenverfügung_MouseHover);
            // 
            // cmbStaatsB
            // 
            this.cmbStaatsB.AddEmptyEntry = false;
            this.cmbStaatsB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaatsB.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbStaatsB.BerufsstandGruppeJNA = -1;
            this.cmbStaatsB.Group = "SBS";
            this.cmbStaatsB.ID_PEP = -1;
            this.cmbStaatsB.Location = new System.Drawing.Point(90, 159);
            this.cmbStaatsB.MaxLength = 15;
            this.cmbStaatsB.Name = "cmbStaatsB";
            this.cmbStaatsB.ShowAddButton = true;
            this.cmbStaatsB.Size = new System.Drawing.Size(130, 24);
            this.cmbStaatsB.TabIndex = 9;
            this.cmbStaatsB.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAkdGrad
            // 
            this.cmbAkdGrad.AddEmptyEntry = false;
            this.cmbAkdGrad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAkdGrad.BerufsstandGruppeJNA = -1;
            this.cmbAkdGrad.Group = "TIT";
            this.cmbAkdGrad.ID_PEP = -1;
            this.cmbAkdGrad.Location = new System.Drawing.Point(309, 99);
            this.cmbAkdGrad.MaxLength = 40;
            this.cmbAkdGrad.Name = "cmbAkdGrad";
            this.cmbAkdGrad.ShowAddButton = true;
            this.cmbAkdGrad.Size = new System.Drawing.Size(173, 24);
            this.cmbAkdGrad.TabIndex = 6;
            this.cmbAkdGrad.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbKonfession
            // 
            this.cmbKonfession.AddEmptyEntry = false;
            this.cmbKonfession.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbKonfession.BerufsstandGruppeJNA = -1;
            this.cmbKonfession.Group = "KON";
            this.cmbKonfession.ID_PEP = -1;
            this.cmbKonfession.Location = new System.Drawing.Point(309, 129);
            this.cmbKonfession.MaxLength = 20;
            this.cmbKonfession.Name = "cmbKonfession";
            this.cmbKonfession.ShowAddButton = true;
            this.cmbKonfession.Size = new System.Drawing.Size(173, 24);
            this.cmbKonfession.TabIndex = 8;
            this.cmbKonfession.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAnrede
            // 
            this.cmbAnrede.AddEmptyEntry = false;
            this.cmbAnrede.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAnrede.BerufsstandGruppeJNA = -1;
            this.cmbAnrede.Group = "ANR";
            this.cmbAnrede.ID_PEP = -1;
            this.cmbAnrede.Location = new System.Drawing.Point(309, 68);
            this.cmbAnrede.MaxLength = 15;
            this.cmbAnrede.Name = "cmbAnrede";
            this.cmbAnrede.ShowAddButton = true;
            this.cmbAnrede.Size = new System.Drawing.Size(173, 24);
            this.cmbAnrede.TabIndex = 4;
            this.cmbAnrede.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStatsB
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsB.Appearance = appearance13;
            this.lblStatsB.AutoSize = true;
            this.lblStatsB.Location = new System.Drawing.Point(14, 163);
            this.lblStatsB.Name = "lblStatsB";
            this.lblStatsB.Size = new System.Drawing.Size(61, 17);
            this.lblStatsB.TabIndex = 94;
            this.lblStatsB.Text = "Staatsbg.";
            // 
            // cmbFAM
            // 
            this.cmbFAM.AddEmptyEntry = false;
            this.cmbFAM.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbFAM.BerufsstandGruppeJNA = -1;
            this.cmbFAM.Group = "FAM";
            this.cmbFAM.ID_PEP = -1;
            this.cmbFAM.Location = new System.Drawing.Point(90, 129);
            this.cmbFAM.MaxLength = 15;
            this.cmbFAM.Name = "cmbFAM";
            this.cmbFAM.ShowAddButton = true;
            this.cmbFAM.Size = new System.Drawing.Size(130, 24);
            this.cmbFAM.TabIndex = 7;
            this.cmbFAM.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtVorname
            // 
            this.errorProvider1.SetIconAlignment(this.txtVorname, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtVorname.Location = new System.Drawing.Point(90, 38);
            this.txtVorname.MaxLength = 25;
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(392, 24);
            this.txtVorname.TabIndex = 2;
            this.txtVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKonf
            // 
            appearance77.BackColor = System.Drawing.Color.Transparent;
            this.lblKonf.Appearance = appearance77;
            this.lblKonf.AutoSize = true;
            this.lblKonf.Location = new System.Drawing.Point(235, 133);
            this.lblKonf.Name = "lblKonf";
            this.lblKonf.Size = new System.Drawing.Size(71, 17);
            this.lblKonf.TabIndex = 95;
            this.lblKonf.Text = "Konfession";
            // 
            // cmbSexus
            // 
            this.cmbSexus.AddEmptyEntry = false;
            this.cmbSexus.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbSexus.BerufsstandGruppeJNA = -1;
            this.cmbSexus.Group = "SEX";
            this.cmbSexus.ID_PEP = -1;
            this.cmbSexus.Location = new System.Drawing.Point(90, 68);
            this.cmbSexus.MaxLength = 15;
            this.cmbSexus.Name = "cmbSexus";
            this.cmbSexus.ShowAddButton = true;
            this.cmbSexus.Size = new System.Drawing.Size(130, 24);
            this.cmbSexus.TabIndex = 3;
            this.cmbSexus.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtNachname
            // 
            appearance78.FontData.BoldAsString = "True";
            appearance78.ForeColor = System.Drawing.Color.Red;
            this.txtNachname.Appearance = appearance78;
            this.errorProvider1.SetIconAlignment(this.txtNachname, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtNachname.Location = new System.Drawing.Point(90, 8);
            this.txtNachname.MaxLength = 25;
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(392, 24);
            this.txtNachname.TabIndex = 1;
            this.txtNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblFamiliensst
            // 
            appearance79.BackColor = System.Drawing.Color.Transparent;
            this.lblFamiliensst.Appearance = appearance79;
            this.lblFamiliensst.AutoSize = true;
            this.lblFamiliensst.Location = new System.Drawing.Point(14, 133);
            this.lblFamiliensst.Name = "lblFamiliensst";
            this.lblFamiliensst.Size = new System.Drawing.Size(74, 17);
            this.lblFamiliensst.TabIndex = 96;
            this.lblFamiliensst.Text = "Fam. Stand";
            // 
            // ultraLabel1
            // 
            appearance80.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance80;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 43);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(59, 17);
            this.ultraLabel1.TabIndex = 94;
            this.ultraLabel1.Text = "Vorname";
            // 
            // lblTitel
            // 
            appearance81.BackColor = System.Drawing.Color.Transparent;
            this.lblTitel.Appearance = appearance81;
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(235, 72);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(48, 17);
            this.lblTitel.TabIndex = 89;
            this.lblTitel.Text = "Anrede";
            // 
            // lblNachname
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            this.lblNachname.Appearance = appearance82;
            this.lblNachname.AutoSize = true;
            this.lblNachname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNachname.Location = new System.Drawing.Point(14, 12);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(70, 17);
            this.lblNachname.TabIndex = 91;
            this.lblNachname.Text = "Nachname";
            // 
            // lblAkdGrad
            // 
            appearance83.BackColor = System.Drawing.Color.Transparent;
            this.lblAkdGrad.Appearance = appearance83;
            this.lblAkdGrad.AutoSize = true;
            this.lblAkdGrad.Location = new System.Drawing.Point(235, 103);
            this.lblAkdGrad.Name = "lblAkdGrad";
            this.lblAkdGrad.Size = new System.Drawing.Size(72, 17);
            this.lblAkdGrad.TabIndex = 90;
            this.lblAkdGrad.Text = "Akad. Grad";
            // 
            // lblGebDat
            // 
            appearance84.BackColor = System.Drawing.Color.Transparent;
            this.lblGebDat.Appearance = appearance84;
            this.lblGebDat.AutoSize = true;
            this.lblGebDat.Location = new System.Drawing.Point(14, 103);
            this.lblGebDat.Name = "lblGebDat";
            this.lblGebDat.Size = new System.Drawing.Size(62, 17);
            this.lblGebDat.TabIndex = 87;
            this.lblGebDat.Text = "Geb. Dat.";
            // 
            // lblGeschl
            // 
            appearance85.BackColor = System.Drawing.Color.Transparent;
            this.lblGeschl.Appearance = appearance85;
            this.lblGeschl.AutoSize = true;
            this.lblGeschl.Location = new System.Drawing.Point(14, 72);
            this.lblGeschl.Name = "lblGeschl";
            this.lblGeschl.Size = new System.Drawing.Size(72, 17);
            this.lblGeschl.TabIndex = 93;
            this.lblGeschl.Text = "Geschlecht";
            // 
            // gebDatum
            // 
            this.gebDatum.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.gebDatum.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.gebDatum, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.gebDatum.Location = new System.Drawing.Point(90, 99);
            this.gebDatum.MaskInput = "";
            this.gebDatum.Name = "gebDatum";
            this.gebDatum.Size = new System.Drawing.Size(130, 24);
            this.gebDatum.TabIndex = 5;
            this.gebDatum.Value = null;
            this.gebDatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // panelAufenthaltsdaten
            // 
            this.panelAufenthaltsdaten.Controls.Add(this.txtKliNr);
            this.panelAufenthaltsdaten.Controls.Add(this.txtZimmerNr);
            this.panelAufenthaltsdaten.Controls.Add(this.lblKlientNr);
            this.panelAufenthaltsdaten.Controls.Add(this.lblZimNr);
            this.panelAufenthaltsdaten.Location = new System.Drawing.Point(503, 375);
            this.panelAufenthaltsdaten.Name = "panelAufenthaltsdaten";
            this.panelAufenthaltsdaten.Size = new System.Drawing.Size(485, 36);
            this.panelAufenthaltsdaten.TabIndex = 103;
            // 
            // txtKliNr
            // 
            this.txtKliNr.Location = new System.Drawing.Point(136, 5);
            this.txtKliNr.MaxLength = 20;
            this.txtKliNr.Name = "txtKliNr";
            this.txtKliNr.Size = new System.Drawing.Size(81, 24);
            this.txtKliNr.TabIndex = 28;
            this.txtKliNr.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtZimmerNr
            // 
            this.txtZimmerNr.Location = new System.Drawing.Point(340, 5);
            this.txtZimmerNr.MaxLength = 5;
            this.txtZimmerNr.Name = "txtZimmerNr";
            this.txtZimmerNr.Size = new System.Drawing.Size(136, 24);
            this.txtZimmerNr.TabIndex = 29;
            this.txtZimmerNr.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKlientNr
            // 
            appearance86.BackColor = System.Drawing.Color.Transparent;
            this.lblKlientNr.Appearance = appearance86;
            this.lblKlientNr.AutoSize = true;
            this.lblKlientNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKlientNr.Location = new System.Drawing.Point(11, 7);
            this.lblKlientNr.Name = "lblKlientNr";
            this.lblKlientNr.Size = new System.Drawing.Size(73, 17);
            this.lblKlientNr.TabIndex = 102;
            this.lblKlientNr.Text = "Klienten.Nr";
            // 
            // lblZimNr
            // 
            appearance87.BackColor = System.Drawing.Color.Transparent;
            this.lblZimNr.Appearance = appearance87;
            this.lblZimNr.AutoSize = true;
            this.lblZimNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblZimNr.Location = new System.Drawing.Point(237, 9);
            this.lblZimNr.Name = "lblZimNr";
            this.lblZimNr.Size = new System.Drawing.Size(70, 17);
            this.lblZimNr.TabIndex = 101;
            this.lblZimNr.Text = "Zimmer.Nr";
            // 
            // ultraGroupBoxAllgemein1
            // 
            this.ultraGroupBoxAllgemein1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblBeruf);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtBeruf);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtGebOrt);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblGebOrt);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtGebName);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblGebName);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblAnrede);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtKosename);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtBesKennz);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblAeussKenz);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblInitBer);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtInitialBer);
            this.ultraGroupBoxAllgemein1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxAllgemein1.Location = new System.Drawing.Point(503, 5);
            this.ultraGroupBoxAllgemein1.Name = "ultraGroupBoxAllgemein1";
            this.ultraGroupBoxAllgemein1.Size = new System.Drawing.Size(498, 246);
            this.ultraGroupBoxAllgemein1.TabIndex = 91;
            // 
            // lblBeruf
            // 
            appearance88.BackColor = System.Drawing.Color.Transparent;
            this.lblBeruf.Appearance = appearance88;
            this.lblBeruf.AutoSize = true;
            this.lblBeruf.Location = new System.Drawing.Point(11, 72);
            this.lblBeruf.Name = "lblBeruf";
            this.lblBeruf.Size = new System.Drawing.Size(37, 17);
            this.lblBeruf.TabIndex = 21;
            this.lblBeruf.Text = "Beruf";
            // 
            // txtBeruf
            // 
            this.txtBeruf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeruf.Location = new System.Drawing.Point(133, 68);
            this.txtBeruf.MaxLength = 50;
            this.txtBeruf.Name = "txtBeruf";
            this.txtBeruf.Size = new System.Drawing.Size(350, 24);
            this.txtBeruf.TabIndex = 21;
            this.txtBeruf.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtGebOrt
            // 
            this.txtGebOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGebOrt.Location = new System.Drawing.Point(133, 38);
            this.txtGebOrt.MaxLength = 50;
            this.txtGebOrt.Name = "txtGebOrt";
            this.txtGebOrt.Size = new System.Drawing.Size(350, 24);
            this.txtGebOrt.TabIndex = 20;
            this.txtGebOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebOrt
            // 
            appearance89.BackColor = System.Drawing.Color.Transparent;
            this.lblGebOrt.Appearance = appearance89;
            this.lblGebOrt.AutoSize = true;
            this.lblGebOrt.Location = new System.Drawing.Point(11, 42);
            this.lblGebOrt.Name = "lblGebOrt";
            this.lblGebOrt.Size = new System.Drawing.Size(68, 17);
            this.lblGebOrt.TabIndex = 20;
            this.lblGebOrt.Text = "Geburtsort";
            // 
            // txtGebName
            // 
            this.txtGebName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGebName.Location = new System.Drawing.Point(133, 8);
            this.txtGebName.MaxLength = 50;
            this.txtGebName.Name = "txtGebName";
            this.txtGebName.Size = new System.Drawing.Size(350, 24);
            this.txtGebName.TabIndex = 19;
            this.txtGebName.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebName
            // 
            appearance90.BackColor = System.Drawing.Color.Transparent;
            this.lblGebName.Appearance = appearance90;
            this.lblGebName.AutoSize = true;
            this.lblGebName.Location = new System.Drawing.Point(11, 12);
            this.lblGebName.Name = "lblGebName";
            this.lblGebName.Size = new System.Drawing.Size(86, 17);
            this.lblGebName.TabIndex = 19;
            this.lblGebName.Text = "Geburtsname";
            // 
            // lblAnrede
            // 
            appearance91.BackColor = System.Drawing.Color.Transparent;
            this.lblAnrede.Appearance = appearance91;
            this.lblAnrede.AutoSize = true;
            this.lblAnrede.Location = new System.Drawing.Point(11, 103);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(69, 17);
            this.lblAnrede.TabIndex = 22;
            this.lblAnrede.Text = "Kosename";
            // 
            // txtKosename
            // 
            this.txtKosename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKosename.Location = new System.Drawing.Point(133, 99);
            this.txtKosename.MaxLength = 50;
            this.txtKosename.Name = "txtKosename";
            this.txtKosename.Size = new System.Drawing.Size(350, 24);
            this.txtKosename.TabIndex = 22;
            this.txtKosename.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtBesKennz
            // 
            this.txtBesKennz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBesKennz.Location = new System.Drawing.Point(133, 130);
            this.txtBesKennz.MaxLength = 100;
            this.txtBesKennz.Multiline = true;
            this.txtBesKennz.Name = "txtBesKennz";
            this.txtBesKennz.Size = new System.Drawing.Size(350, 50);
            this.txtBesKennz.TabIndex = 23;
            this.txtBesKennz.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblAeussKenz
            // 
            appearance92.BackColor = System.Drawing.Color.Transparent;
            this.lblAeussKenz.Appearance = appearance92;
            this.lblAeussKenz.Location = new System.Drawing.Point(11, 133);
            this.lblAeussKenz.Name = "lblAeussKenz";
            this.lblAeussKenz.Size = new System.Drawing.Size(124, 21);
            this.lblAeussKenz.TabIndex = 23;
            this.lblAeussKenz.Text = "Bes. Kennzeichen";
            // 
            // lblInitBer
            // 
            appearance93.BackColor = System.Drawing.Color.Transparent;
            this.lblInitBer.Appearance = appearance93;
            this.lblInitBer.Location = new System.Drawing.Point(11, 190);
            this.lblInitBer.Name = "lblInitBer";
            this.lblInitBer.Size = new System.Drawing.Size(122, 20);
            this.lblInitBer.TabIndex = 24;
            this.lblInitBer.Text = "Initialberührung";
            // 
            // txtInitialBer
            // 
            this.txtInitialBer.AcceptsReturn = true;
            this.txtInitialBer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialBer.Location = new System.Drawing.Point(133, 186);
            this.txtInitialBer.MaxLength = 255;
            this.txtInitialBer.Multiline = true;
            this.txtInitialBer.Name = "txtInitialBer";
            this.txtInitialBer.Size = new System.Drawing.Size(350, 50);
            this.txtInitialBer.TabIndex = 24;
            this.txtInitialBer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxPersonebescheibung
            // 
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.btnMagnify);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.panelButtons);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtGewicht);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtGroesse);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbstatur);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbHaarFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbAugenFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.foto);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblGewicht);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblAugenfarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblHaarFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblStatur);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblGroesse);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.Namenstag);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblNamenstag);
            this.ultraGroupBoxPersonebescheibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxPersonebescheibung.Location = new System.Drawing.Point(3, 207);
            this.ultraGroupBoxPersonebescheibung.Name = "ultraGroupBoxPersonebescheibung";
            this.ultraGroupBoxPersonebescheibung.Size = new System.Drawing.Size(494, 204);
            this.ultraGroupBoxPersonebescheibung.TabIndex = 10;
            this.ultraGroupBoxPersonebescheibung.Text = "Personenbeschreibung";
            // 
            // btnMagnify
            // 
            appearance94.Image = global::PMDS.GUI.Properties.Resources.ico_Vergrößern;
            appearance94.TextHAlignAsString = "Left";
            this.btnMagnify.Appearance = appearance94;
            this.btnMagnify.AutoWorkLayout = false;
            this.btnMagnify.IsStandardControl = false;
            this.btnMagnify.Location = new System.Drawing.Point(421, 169);
            this.btnMagnify.Name = "btnMagnify";
            this.btnMagnify.Size = new System.Drawing.Size(25, 25);
            this.btnMagnify.TabIndex = 19;
            ultraToolTipInfo3.ToolTipText = "Bild vergrößern";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnMagnify, ultraToolTipInfo3);
            this.btnMagnify.Click += new System.EventHandler(this.btnMagnify_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnPicClear);
            this.panelButtons.Controls.Add(this.btnPicSave);
            this.panelButtons.Controls.Add(this.btnPicLoad);
            this.panelButtons.Location = new System.Drawing.Point(326, 168);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(89, 25);
            this.panelButtons.TabIndex = 108;
            // 
            // btnPicClear
            // 
            appearance95.Image = ((object)(resources.GetObject("appearance95.Image")));
            appearance95.TextHAlignAsString = "Left";
            this.btnPicClear.Appearance = appearance95;
            this.btnPicClear.AutoWorkLayout = false;
            this.btnPicClear.IsStandardControl = false;
            this.btnPicClear.Location = new System.Drawing.Point(0, 0);
            this.btnPicClear.Name = "btnPicClear";
            this.btnPicClear.Size = new System.Drawing.Size(25, 25);
            this.btnPicClear.TabIndex = 16;
            this.btnPicClear.Click += new System.EventHandler(this.btnPicClear2_Click);
            // 
            // btnPicSave
            // 
            appearance96.Image = ((object)(resources.GetObject("appearance96.Image")));
            appearance96.TextHAlignAsString = "Left";
            this.btnPicSave.Appearance = appearance96;
            this.btnPicSave.AutoWorkLayout = false;
            this.btnPicSave.IsStandardControl = false;
            this.btnPicSave.Location = new System.Drawing.Point(62, 1);
            this.btnPicSave.Name = "btnPicSave";
            this.btnPicSave.Size = new System.Drawing.Size(25, 25);
            this.btnPicSave.TabIndex = 18;
            this.btnPicSave.Text = "Bild speichern nach ...";
            ultraToolTipInfo4.ToolTipText = "Bild speichern nach ...";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicSave, ultraToolTipInfo4);
            this.btnPicSave.Click += new System.EventHandler(this.btnPicSave_Click);
            // 
            // btnPicLoad
            // 
            appearance97.Image = global::PMDS.GUI.Properties.Resources.ico_Aufnahme;
            appearance97.TextHAlignAsString = "Left";
            this.btnPicLoad.Appearance = appearance97;
            this.btnPicLoad.AutoWorkLayout = false;
            this.btnPicLoad.IsStandardControl = false;
            this.btnPicLoad.Location = new System.Drawing.Point(31, 0);
            this.btnPicLoad.Name = "btnPicLoad";
            this.btnPicLoad.Size = new System.Drawing.Size(25, 25);
            this.btnPicLoad.TabIndex = 17;
            ultraToolTipInfo5.ToolTipText = "Bild laden von ...";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicLoad, ultraToolTipInfo5);
            this.btnPicLoad.Click += new System.EventHandler(this.btnPicLoad_Click);
            // 
            // txtGewicht
            // 
            this.txtGewicht.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtGewicht.Location = new System.Drawing.Point(90, 50);
            this.txtGewicht.Name = "txtGewicht";
            this.txtGewicht.NonAutoSizeHeight = 20;
            this.txtGewicht.Size = new System.Drawing.Size(97, 22);
            this.txtGewicht.TabIndex = 11;
            this.txtGewicht.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtGroesse
            // 
            this.txtGroesse.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtGroesse.Location = new System.Drawing.Point(90, 22);
            this.txtGroesse.Name = "txtGroesse";
            this.txtGroesse.NonAutoSizeHeight = 20;
            this.txtGroesse.Size = new System.Drawing.Size(97, 22);
            this.txtGroesse.TabIndex = 10;
            this.txtGroesse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbstatur
            // 
            this.cmbstatur.AddEmptyEntry = false;
            this.cmbstatur.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbstatur.BerufsstandGruppeJNA = -1;
            this.cmbstatur.Group = "STA";
            this.cmbstatur.ID_PEP = -1;
            this.cmbstatur.Location = new System.Drawing.Point(90, 138);
            this.cmbstatur.MaxLength = 50;
            this.cmbstatur.Name = "cmbstatur";
            this.cmbstatur.ShowAddButton = true;
            this.cmbstatur.Size = new System.Drawing.Size(200, 24);
            this.cmbstatur.TabIndex = 14;
            this.cmbstatur.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbHaarFarbe
            // 
            this.cmbHaarFarbe.AddEmptyEntry = false;
            this.cmbHaarFarbe.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbHaarFarbe.BerufsstandGruppeJNA = -1;
            this.cmbHaarFarbe.Group = "HFR";
            this.cmbHaarFarbe.ID_PEP = -1;
            this.cmbHaarFarbe.Location = new System.Drawing.Point(90, 108);
            this.cmbHaarFarbe.MaxLength = 20;
            this.cmbHaarFarbe.Name = "cmbHaarFarbe";
            this.cmbHaarFarbe.ShowAddButton = true;
            this.cmbHaarFarbe.Size = new System.Drawing.Size(200, 24);
            this.cmbHaarFarbe.TabIndex = 13;
            this.cmbHaarFarbe.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAugenFarbe
            // 
            this.cmbAugenFarbe.AddEmptyEntry = false;
            this.cmbAugenFarbe.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAugenFarbe.BerufsstandGruppeJNA = -1;
            this.cmbAugenFarbe.Group = "AFR";
            this.cmbAugenFarbe.ID_PEP = -1;
            this.cmbAugenFarbe.Location = new System.Drawing.Point(90, 78);
            this.cmbAugenFarbe.MaxLength = 20;
            this.cmbAugenFarbe.Name = "cmbAugenFarbe";
            this.cmbAugenFarbe.ShowAddButton = true;
            this.cmbAugenFarbe.Size = new System.Drawing.Size(200, 24);
            this.cmbAugenFarbe.TabIndex = 12;
            this.cmbAugenFarbe.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // foto
            // 
            appearance98.BorderColor = System.Drawing.Color.LightGray;
            this.foto.Appearance = appearance98;
            this.foto.BackColor = System.Drawing.Color.White;
            this.foto.BorderShadowColor = System.Drawing.Color.Empty;
            this.foto.BorderShadowDepth = ((byte)(2));
            this.foto.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.foto.Location = new System.Drawing.Point(326, 22);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(125, 141);
            this.foto.TabIndex = 107;
            this.foto.ImageChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGewicht
            // 
            appearance99.BackColor = System.Drawing.Color.Transparent;
            this.lblGewicht.Appearance = appearance99;
            this.lblGewicht.AutoSize = true;
            this.lblGewicht.Location = new System.Drawing.Point(14, 54);
            this.lblGewicht.Name = "lblGewicht";
            this.lblGewicht.Size = new System.Drawing.Size(80, 17);
            this.lblGewicht.TabIndex = 104;
            this.lblGewicht.Text = "Gewicht (kg)";
            // 
            // lblAugenfarbe
            // 
            appearance100.BackColor = System.Drawing.Color.Transparent;
            this.lblAugenfarbe.Appearance = appearance100;
            this.lblAugenfarbe.AutoSize = true;
            this.lblAugenfarbe.Location = new System.Drawing.Point(14, 83);
            this.lblAugenfarbe.Name = "lblAugenfarbe";
            this.lblAugenfarbe.Size = new System.Drawing.Size(74, 17);
            this.lblAugenfarbe.TabIndex = 101;
            this.lblAugenfarbe.Text = "Augenfarbe";
            // 
            // lblHaarFarbe
            // 
            appearance101.BackColor = System.Drawing.Color.Transparent;
            this.lblHaarFarbe.Appearance = appearance101;
            this.lblHaarFarbe.AutoSize = true;
            this.lblHaarFarbe.Location = new System.Drawing.Point(14, 112);
            this.lblHaarFarbe.Name = "lblHaarFarbe";
            this.lblHaarFarbe.Size = new System.Drawing.Size(64, 17);
            this.lblHaarFarbe.TabIndex = 100;
            this.lblHaarFarbe.Text = "Haarfarbe";
            // 
            // lblStatur
            // 
            appearance102.BackColor = System.Drawing.Color.Transparent;
            this.lblStatur.Appearance = appearance102;
            this.lblStatur.AutoSize = true;
            this.lblStatur.Location = new System.Drawing.Point(14, 141);
            this.lblStatur.Name = "lblStatur";
            this.lblStatur.Size = new System.Drawing.Size(41, 17);
            this.lblStatur.TabIndex = 98;
            this.lblStatur.Text = "Statur";
            // 
            // lblGroesse
            // 
            appearance103.BackColor = System.Drawing.Color.Transparent;
            this.lblGroesse.Appearance = appearance103;
            this.lblGroesse.AutoSize = true;
            this.lblGroesse.Location = new System.Drawing.Point(14, 25);
            this.lblGroesse.Name = "lblGroesse";
            this.lblGroesse.Size = new System.Drawing.Size(73, 17);
            this.lblGroesse.TabIndex = 96;
            this.lblGroesse.Text = "Größe (cm)";
            // 
            // Namenstag
            // 
            this.Namenstag.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Namenstag.FormatString = "";
            this.Namenstag.Location = new System.Drawing.Point(90, 168);
            this.Namenstag.MaskInput = "dd.mm";
            this.Namenstag.Name = "Namenstag";
            this.Namenstag.Size = new System.Drawing.Size(73, 24);
            this.Namenstag.TabIndex = 15;
            this.Namenstag.Value = null;
            this.Namenstag.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNamenstag
            // 
            appearance104.BackColor = System.Drawing.Color.Transparent;
            this.lblNamenstag.Appearance = appearance104;
            this.lblNamenstag.AutoSize = true;
            this.lblNamenstag.Location = new System.Drawing.Point(14, 170);
            this.lblNamenstag.Name = "lblNamenstag";
            this.lblNamenstag.Size = new System.Drawing.Size(73, 17);
            this.lblNamenstag.TabIndex = 93;
            this.lblNamenstag.Text = "Namenstag";
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(12, 201);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(0, 0);
            this.lblVorname.TabIndex = 8;
            // 
            // pageControlAufenthalt
            // 
            this.pageControlAufenthalt.Controls.Add(this.ucAbrechAufenthKlient1);
            this.pageControlAufenthalt.Location = new System.Drawing.Point(-10000, -10000);
            this.pageControlAufenthalt.Name = "pageControlAufenthalt";
            this.pageControlAufenthalt.Size = new System.Drawing.Size(1004, 610);
            // 
            // ucAbrechAufenthKlient1
            // 
            this.ucAbrechAufenthKlient1.BackColor = System.Drawing.Color.Transparent;
            this.ucAbrechAufenthKlient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAbrechAufenthKlient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucAbrechAufenthKlient1.Location = new System.Drawing.Point(0, 0);
            this.ucAbrechAufenthKlient1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAbrechAufenthKlient1.Name = "ucAbrechAufenthKlient1";
            this.ucAbrechAufenthKlient1.Size = new System.Drawing.Size(1004, 610);
            this.ucAbrechAufenthKlient1.TabIndex = 0;
            this.ucAbrechAufenthKlient1.ValueChanged += new System.EventHandler(this.ucAbrechAufenthKlient1_ValueChanged);
            this.ucAbrechAufenthKlient1.VisibleChanged += new System.EventHandler(this.ucAbrechAufenthKlient1_VisibleChanged);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.splitContainer1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1004, 610);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ultraGroupBoxAngehörige);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 610);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.TabIndex = 22;
            // 
            // ultraGroupBoxAngehörige
            // 
            appearance42.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxAngehörige.Appearance = appearance42;
            this.ultraGroupBoxAngehörige.Controls.Add(this.ucKontaktPersonen1);
            this.ultraGroupBoxAngehörige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxAngehörige.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxAngehörige.Name = "ultraGroupBoxAngehörige";
            this.ultraGroupBoxAngehörige.Size = new System.Drawing.Size(1004, 141);
            this.ultraGroupBoxAngehörige.TabIndex = 19;
            this.ultraGroupBoxAngehörige.Text = "Angehörige und sonstige Kontaktpersonen";
            // 
            // ucKontaktPersonen1
            // 
            this.ucKontaktPersonen1.BackColor = System.Drawing.Color.White;
            this.ucKontaktPersonen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKontaktPersonen1.ExternerDienstleister = false;
            this.ucKontaktPersonen1.Location = new System.Drawing.Point(3, 19);
            this.ucKontaktPersonen1.Margin = new System.Windows.Forms.Padding(5);
            this.ucKontaktPersonen1.Name = "ucKontaktPersonen1";
            this.ucKontaktPersonen1.Size = new System.Drawing.Size(998, 119);
            this.ucKontaktPersonen1.TabIndex = 1;
            this.ucKontaktPersonen1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.ucKontaktPersonen1.Load += new System.EventHandler(this.ucKontaktPersonen1_Load);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ultraGroupBoxÄrtze);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ultraGroupBoxSachverwalter);
            this.splitContainer2.Size = new System.Drawing.Size(1004, 465);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // ultraGroupBoxÄrtze
            // 
            appearance43.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxÄrtze.Appearance = appearance43;
            this.ultraGroupBoxÄrtze.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.ultraGroupBoxÄrtze.Controls.Add(this.panelButtons1);
            this.ultraGroupBoxÄrtze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxÄrtze.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxÄrtze.Name = "ultraGroupBoxÄrtze";
            this.ultraGroupBoxÄrtze.Size = new System.Drawing.Size(1004, 144);
            this.ultraGroupBoxÄrtze.TabIndex = 20;
            this.ultraGroupBoxÄrtze.Text = "Ärzte";
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Controls.Add(this.gridAerzte);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(972, 122);
            this.ultraGridBagLayoutPanel2.TabIndex = 7;
            // 
            // gridAerzte
            // 
            this.gridAerzte.AutoWork = true;
            this.gridAerzte.DataMember = "PatientAerzte";
            this.gridAerzte.DataSource = this.dsPatientAerzte1;
            appearance44.BackColor = System.Drawing.Color.White;
            appearance44.BorderColor = System.Drawing.Color.Black;
            this.gridAerzte.DisplayLayout.Appearance = appearance44;
            this.gridAerzte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn21.Header.VisiblePosition = 0;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(163, 0);
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn23.Header.VisiblePosition = 2;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.Header.Caption = "Hausarzt";
            ultraGridColumn24.Header.VisiblePosition = 3;
            ultraGridColumn24.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn24.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn24.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(52, 0);
            ultraGridColumn24.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn24.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.Header.Caption = "Zuweiser";
            ultraGridColumn25.Header.VisiblePosition = 4;
            ultraGridColumn25.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn25.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn25.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(53, 0);
            ultraGridColumn25.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn25.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.Header.Caption = "Aufnahmearzt";
            ultraGridColumn26.Header.VisiblePosition = 5;
            ultraGridColumn26.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn26.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn26.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn26.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn26.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.Header.Caption = "Facharzt";
            ultraGridColumn27.Header.VisiblePosition = 6;
            ultraGridColumn27.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn27.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn27.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn27.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn27.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn28.Header.VisiblePosition = 7;
            ultraGridColumn28.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn28.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn28.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn28.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn28.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn29.Header.VisiblePosition = 8;
            ultraGridColumn29.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn29.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn29.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn29.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn29.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn30.Header.VisiblePosition = 9;
            ultraGridColumn30.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn30.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(163, 0);
            ultraGridColumn30.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn30.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn31.Header.VisiblePosition = 10;
            ultraGridColumn31.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn31.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn31.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(113, 0);
            ultraGridColumn31.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn31.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn32.Header.Caption = "Tel / Adresse";
            ultraGridColumn32.Header.VisiblePosition = 11;
            ultraGridColumn32.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn32.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn32.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(286, 0);
            ultraGridColumn32.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn32.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32});
            ultraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridAerzte.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridAerzte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance45.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.GroupByBox.Appearance = appearance45;
            appearance46.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.BandLabelAppearance = appearance46;
            this.gridAerzte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.GroupByBox.Hidden = true;
            appearance47.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance47.BackColor2 = System.Drawing.SystemColors.Control;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance47.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.PromptAppearance = appearance47;
            this.gridAerzte.DisplayLayout.MaxRowScrollRegions = 1;
            appearance48.BackColor = System.Drawing.SystemColors.Window;
            appearance48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAerzte.DisplayLayout.Override.ActiveCellAppearance = appearance48;
            appearance49.BackColor = System.Drawing.SystemColors.Highlight;
            appearance49.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridAerzte.DisplayLayout.Override.ActiveRowAppearance = appearance49;
            this.gridAerzte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridAerzte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.CardAreaAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.White;
            appearance51.BorderColor = System.Drawing.Color.Silver;
            appearance51.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridAerzte.DisplayLayout.Override.CellAppearance = appearance51;
            this.gridAerzte.DisplayLayout.Override.CellPadding = 0;
            appearance52.BackColor = System.Drawing.SystemColors.Control;
            appearance52.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance52.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance52.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.GroupByRowAppearance = appearance52;
            appearance53.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance53.TextHAlignAsString = "Left";
            this.gridAerzte.DisplayLayout.Override.HeaderAppearance = appearance53;
            this.gridAerzte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridAerzte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance54.BackColor = System.Drawing.SystemColors.Window;
            appearance54.BorderColor = System.Drawing.Color.Silver;
            this.gridAerzte.DisplayLayout.Override.RowAppearance = appearance54;
            appearance55.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridAerzte.DisplayLayout.Override.TemplateAddRowAppearance = appearance55;
            this.gridAerzte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridAerzte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridAerzte.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridAerzte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAerzte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.gridAerzte, gridBagConstraint1);
            this.gridAerzte.Location = new System.Drawing.Point(0, 0);
            this.gridAerzte.Name = "gridAerzte";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.gridAerzte, new System.Drawing.Size(243, 74));
            this.gridAerzte.Size = new System.Drawing.Size(972, 122);
            this.gridAerzte.TabIndex = 2;
            this.gridAerzte.Text = "ultraGrid2";
            this.gridAerzte.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridAerzte_CellChange);
            this.gridAerzte.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.gridAerzte_DoubleClickCell);
            this.gridAerzte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridAerzte_KeyDown);
            // 
            // dsPatientAerzte1
            // 
            this.dsPatientAerzte1.DataSetName = "dsPatientAerzte";
            this.dsPatientAerzte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelButtons1
            // 
            this.panelButtons1.Controls.Add(this.btnUpdateArzt);
            this.panelButtons1.Controls.Add(this.btnDelAerzte);
            this.panelButtons1.Controls.Add(this.btnUpdateAerzte);
            this.panelButtons1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons1.Location = new System.Drawing.Point(975, 19);
            this.panelButtons1.Name = "panelButtons1";
            this.panelButtons1.Size = new System.Drawing.Size(26, 122);
            this.panelButtons1.TabIndex = 6;
            // 
            // btnUpdateArzt
            // 
            appearance56.Image = ((object)(resources.GetObject("appearance56.Image")));
            appearance56.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance56.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateArzt.Appearance = appearance56;
            this.btnUpdateArzt.AutoWorkLayout = false;
            this.btnUpdateArzt.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateArzt.IsStandardControl = false;
            this.btnUpdateArzt.Location = new System.Drawing.Point(1, 39);
            this.btnUpdateArzt.Name = "btnUpdateArzt";
            this.btnUpdateArzt.Size = new System.Drawing.Size(22, 21);
            this.btnUpdateArzt.TabIndex = 5;
            ultraToolTipInfo1.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateArzt, ultraToolTipInfo1);
            this.btnUpdateArzt.Click += new System.EventHandler(this.btnUpdateArzt_Click);
            // 
            // btnDelAerzte
            // 
            appearance57.BackColor = System.Drawing.Color.Transparent;
            appearance57.Image = ((object)(resources.GetObject("appearance57.Image")));
            appearance57.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance57.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelAerzte.Appearance = appearance57;
            this.btnDelAerzte.AutoWorkLayout = false;
            this.btnDelAerzte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelAerzte.DoOnClick = true;
            this.btnDelAerzte.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelAerzte.IsStandardControl = true;
            this.btnDelAerzte.Location = new System.Drawing.Point(1, 19);
            this.btnDelAerzte.Name = "btnDelAerzte";
            this.btnDelAerzte.Size = new System.Drawing.Size(22, 21);
            this.btnDelAerzte.TabIndex = 4;
            this.btnDelAerzte.TabStop = false;
            this.btnDelAerzte.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelAerzte.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelAerzte.Click += new System.EventHandler(this.btnDelAerzte_Click);
            // 
            // btnUpdateAerzte
            // 
            appearance58.BackColor = System.Drawing.Color.Transparent;
            appearance58.Image = ((object)(resources.GetObject("appearance58.Image")));
            appearance58.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance58.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateAerzte.Appearance = appearance58;
            this.btnUpdateAerzte.AutoWorkLayout = false;
            this.btnUpdateAerzte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateAerzte.DoOnClick = true;
            this.btnUpdateAerzte.ImageSize = new System.Drawing.Size(12, 12);
            this.btnUpdateAerzte.IsStandardControl = true;
            this.btnUpdateAerzte.Location = new System.Drawing.Point(1, -1);
            this.btnUpdateAerzte.Name = "btnUpdateAerzte";
            this.btnUpdateAerzte.Size = new System.Drawing.Size(22, 21);
            this.btnUpdateAerzte.TabIndex = 3;
            this.btnUpdateAerzte.TabStop = false;
            this.btnUpdateAerzte.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnUpdateAerzte.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUpdateAerzte.Click += new System.EventHandler(this.btnUpdateAerzte_Click);
            // 
            // ultraGroupBoxSachverwalter
            // 
            appearance59.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxSachverwalter.Appearance = appearance59;
            this.ultraGroupBoxSachverwalter.Controls.Add(this.ultraGridBagLayoutPanel3);
            this.ultraGroupBoxSachverwalter.Controls.Add(this.panelButtons2);
            this.ultraGroupBoxSachverwalter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxSachverwalter.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxSachverwalter.Name = "ultraGroupBoxSachverwalter";
            this.ultraGroupBoxSachverwalter.Size = new System.Drawing.Size(1004, 317);
            this.ultraGroupBoxSachverwalter.TabIndex = 21;
            this.ultraGroupBoxSachverwalter.Text = "Sachwalter / Vorsorgebevollmächtigte";
            // 
            // ultraGridBagLayoutPanel3
            // 
            this.ultraGridBagLayoutPanel3.Controls.Add(this.gridSachwalter);
            this.ultraGridBagLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel3.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel3.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.ultraGridBagLayoutPanel3.Name = "ultraGridBagLayoutPanel3";
            this.ultraGridBagLayoutPanel3.Size = new System.Drawing.Size(972, 295);
            this.ultraGridBagLayoutPanel3.TabIndex = 11;
            // 
            // gridSachwalter
            // 
            this.gridSachwalter.AutoWork = true;
            this.gridSachwalter.DataMember = "Sachwalter";
            this.gridSachwalter.DataSource = this.dsKlientSachwalter1;
            appearance60.BackColor = System.Drawing.Color.White;
            appearance60.BorderColor = System.Drawing.Color.Black;
            this.gridSachwalter.DisplayLayout.Appearance = appearance60;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn33.Header.VisiblePosition = 0;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn34.Header.VisiblePosition = 1;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn35.Header.VisiblePosition = 2;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn36.Header.VisiblePosition = 3;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn37.Header.VisiblePosition = 4;
            ultraGridColumn37.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(184, 0);
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn38.Header.VisiblePosition = 5;
            ultraGridColumn38.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(499, 0);
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn39.Header.VisiblePosition = 6;
            ultraGridColumn39.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(109, 0);
            ultraGridColumn40.Header.Caption = "Telefon / Adresse";
            ultraGridColumn40.Header.VisiblePosition = 7;
            ultraGridColumn40.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(198, 0);
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridSachwalter.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridSachwalter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSachwalter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.GroupByBox.Appearance = appearance61;
            appearance62.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSachwalter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance62;
            this.gridSachwalter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSachwalter.DisplayLayout.GroupByBox.Hidden = true;
            appearance63.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance63.BackColor2 = System.Drawing.SystemColors.Control;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance63.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSachwalter.DisplayLayout.GroupByBox.PromptAppearance = appearance63;
            appearance64.BackColor = System.Drawing.SystemColors.Window;
            appearance64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSachwalter.DisplayLayout.Override.ActiveCellAppearance = appearance64;
            appearance65.BackColor = System.Drawing.SystemColors.Highlight;
            appearance65.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridSachwalter.DisplayLayout.Override.ActiveRowAppearance = appearance65;
            this.gridSachwalter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridSachwalter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance66.BackColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.Override.CardAreaAppearance = appearance66;
            appearance67.BorderColor = System.Drawing.Color.Silver;
            appearance67.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridSachwalter.DisplayLayout.Override.CellAppearance = appearance67;
            this.gridSachwalter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridSachwalter.DisplayLayout.Override.CellPadding = 0;
            appearance68.BackColor = System.Drawing.SystemColors.Control;
            appearance68.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance68.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance68.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.Override.GroupByRowAppearance = appearance68;
            appearance69.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance69.TextHAlignAsString = "Left";
            this.gridSachwalter.DisplayLayout.Override.HeaderAppearance = appearance69;
            this.gridSachwalter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridSachwalter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance70.BackColor = System.Drawing.SystemColors.Window;
            appearance70.BorderColor = System.Drawing.Color.Silver;
            this.gridSachwalter.DisplayLayout.Override.RowAppearance = appearance70;
            this.gridSachwalter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance71.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridSachwalter.DisplayLayout.Override.TemplateAddRowAppearance = appearance71;
            this.gridSachwalter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridSachwalter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridSachwalter.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridSachwalter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSachwalter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            this.ultraGridBagLayoutPanel3.SetGridBagConstraint(this.gridSachwalter, gridBagConstraint2);
            this.gridSachwalter.Location = new System.Drawing.Point(0, 0);
            this.gridSachwalter.Name = "gridSachwalter";
            this.ultraGridBagLayoutPanel3.SetPreferredSize(this.gridSachwalter, new System.Drawing.Size(378, 85));
            this.gridSachwalter.Size = new System.Drawing.Size(972, 295);
            this.gridSachwalter.TabIndex = 6;
            this.gridSachwalter.Text = "ultraGrid4";
            this.gridSachwalter.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.gridSachwalter_DoubleClickCell);
            this.gridSachwalter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridSachwalter_KeyDown);
            // 
            // dsKlientSachwalter1
            // 
            this.dsKlientSachwalter1.DataSetName = "dsKlientSachwalter";
            this.dsKlientSachwalter1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelButtons2
            // 
            this.panelButtons2.Controls.Add(this.btnUpdateSachw);
            this.panelButtons2.Controls.Add(this.btnDelSachwalter);
            this.panelButtons2.Controls.Add(this.btnAddSachw);
            this.panelButtons2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons2.Location = new System.Drawing.Point(975, 19);
            this.panelButtons2.Name = "panelButtons2";
            this.panelButtons2.Size = new System.Drawing.Size(26, 295);
            this.panelButtons2.TabIndex = 10;
            // 
            // btnUpdateSachw
            // 
            appearance72.Image = ((object)(resources.GetObject("appearance72.Image")));
            appearance72.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance72.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateSachw.Appearance = appearance72;
            this.btnUpdateSachw.AutoWorkLayout = false;
            this.btnUpdateSachw.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateSachw.IsStandardControl = false;
            this.btnUpdateSachw.Location = new System.Drawing.Point(1, 40);
            this.btnUpdateSachw.Name = "btnUpdateSachw";
            this.btnUpdateSachw.Size = new System.Drawing.Size(22, 21);
            this.btnUpdateSachw.TabIndex = 9;
            ultraToolTipInfo2.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateSachw, ultraToolTipInfo2);
            this.btnUpdateSachw.Click += new System.EventHandler(this.btnUpdateSachw_Click);
            // 
            // btnDelSachwalter
            // 
            appearance73.BackColor = System.Drawing.Color.Transparent;
            appearance73.Image = ((object)(resources.GetObject("appearance73.Image")));
            appearance73.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance73.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelSachwalter.Appearance = appearance73;
            this.btnDelSachwalter.AutoWorkLayout = false;
            this.btnDelSachwalter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelSachwalter.DoOnClick = true;
            this.btnDelSachwalter.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelSachwalter.IsStandardControl = true;
            this.btnDelSachwalter.Location = new System.Drawing.Point(1, 20);
            this.btnDelSachwalter.Name = "btnDelSachwalter";
            this.btnDelSachwalter.Size = new System.Drawing.Size(22, 21);
            this.btnDelSachwalter.TabIndex = 8;
            this.btnDelSachwalter.TabStop = false;
            this.btnDelSachwalter.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelSachwalter.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelSachwalter.Click += new System.EventHandler(this.btnDelSachw_Click);
            // 
            // btnAddSachw
            // 
            appearance74.BackColor = System.Drawing.Color.Transparent;
            appearance74.Image = ((object)(resources.GetObject("appearance74.Image")));
            appearance74.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance74.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddSachw.Appearance = appearance74;
            this.btnAddSachw.AutoWorkLayout = false;
            this.btnAddSachw.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddSachw.DoOnClick = true;
            this.btnAddSachw.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddSachw.IsStandardControl = true;
            this.btnAddSachw.Location = new System.Drawing.Point(1, 0);
            this.btnAddSachw.Name = "btnAddSachw";
            this.btnAddSachw.Size = new System.Drawing.Size(22, 21);
            this.btnAddSachw.TabIndex = 7;
            this.btnAddSachw.TabStop = false;
            this.btnAddSachw.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddSachw.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddSachw.Click += new System.EventHandler(this.btnAddSachw_Click);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.ultraTabControl1);
            this.ultraTabPageControl5.Controls.Add(this.ucBewerbungsdaten1);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(1004, 610);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl6);
            this.ultraTabControl1.Location = new System.Drawing.Point(6, 9);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(481, 529);
            this.ultraTabControl1.TabIndex = 70;
            ultraTab6.Key = "Hauptwohnsitz";
            ultraTab6.TabPage = this.ultraTabPageControl4;
            ultraTab6.Text = "Hauptwohnsitz";
            ultraTab7.Key = "Nebenwohnsitz";
            ultraTab7.TabPage = this.ultraTabPageControl6;
            ultraTab7.Text = "Nebenwohnsitz";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab6,
            ultraTab7});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(477, 502);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGroupBoxAdressdaten);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(477, 502);
            // 
            // ultraGroupBoxAdressdaten
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBoxAdressdaten.Appearance = appearance17;
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lift);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtLand);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel7);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.cmbBenutzer);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblZustgStelle);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtZustgStelle);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblWohnSituation);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtWohnsituation);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblHausTier);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtHaustier);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblKlingel);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtKlingeln);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.WohnungAb);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblEmail);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtEmail);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel9);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtMobil);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblErstKontakt);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtTelefon);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel8);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel6);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtOrt);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel5);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtPLZ);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtStrasse);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel3);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtFax);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.ultraLabel10);
            this.ultraGroupBoxAdressdaten.Location = new System.Drawing.Point(6, 3);
            this.ultraGroupBoxAdressdaten.Name = "ultraGroupBoxAdressdaten";
            this.ultraGroupBoxAdressdaten.Size = new System.Drawing.Size(464, 407);
            this.ultraGroupBoxAdressdaten.TabIndex = 68;
            this.ultraGroupBoxAdressdaten.Text = "Adressdaten";
            // 
            // lift
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            this.lift.Appearance = appearance18;
            this.lift.BackColor = System.Drawing.Color.Transparent;
            this.lift.BackColorInternal = System.Drawing.Color.Transparent;
            this.lift.Location = new System.Drawing.Point(305, 149);
            this.lift.Name = "lift";
            this.lift.Size = new System.Drawing.Size(85, 20);
            this.lift.TabIndex = 7;
            this.lift.Text = "Lift";
            this.lift.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtLand
            // 
            this.txtLand.AddEmptyEntry = false;
            this.txtLand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.txtLand.BerufsstandGruppeJNA = -1;
            this.txtLand.Group = "SBS";
            this.txtLand.ID_PEP = -1;
            this.txtLand.Location = new System.Drawing.Point(203, 119);
            this.txtLand.MaxLength = 20;
            this.txtLand.Name = "txtLand";
            this.txtLand.ShowAddButton = true;
            this.txtLand.Size = new System.Drawing.Size(250, 24);
            this.txtLand.TabIndex = 5;
            this.txtLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel7
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel7.Appearance = appearance19;
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Location = new System.Drawing.Point(168, 123);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(35, 17);
            this.ultraLabel7.TabIndex = 121;
            this.ultraLabel7.Text = "Land";
            // 
            // cmbBenutzer
            // 
            this.cmbBenutzer.Location = new System.Drawing.Point(114, 29);
            this.cmbBenutzer.Name = "cmbBenutzer";
            this.cmbBenutzer.Size = new System.Drawing.Size(340, 24);
            this.cmbBenutzer.TabIndex = 1;
            this.cmbBenutzer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblZustgStelle
            // 
            appearance20.BackColor = System.Drawing.Color.Transparent;
            this.lblZustgStelle.Appearance = appearance20;
            this.lblZustgStelle.AutoSize = true;
            this.lblZustgStelle.Location = new System.Drawing.Point(15, 293);
            this.lblZustgStelle.Name = "lblZustgStelle";
            this.lblZustgStelle.Size = new System.Drawing.Size(74, 17);
            this.lblZustgStelle.TabIndex = 70;
            this.lblZustgStelle.Text = "Zust. Stelle";
            // 
            // txtZustgStelle
            // 
            this.txtZustgStelle.AutoSize = false;
            this.txtZustgStelle.Location = new System.Drawing.Point(114, 293);
            this.txtZustgStelle.MaxLength = 25;
            this.txtZustgStelle.Name = "txtZustgStelle";
            this.txtZustgStelle.Size = new System.Drawing.Size(340, 21);
            this.txtZustgStelle.TabIndex = 13;
            this.txtZustgStelle.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblWohnSituation
            // 
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.lblWohnSituation.Appearance = appearance21;
            this.lblWohnSituation.AutoSize = true;
            this.lblWohnSituation.Location = new System.Drawing.Point(15, 238);
            this.lblWohnSituation.Name = "lblWohnSituation";
            this.lblWohnSituation.Size = new System.Drawing.Size(92, 17);
            this.lblWohnSituation.TabIndex = 68;
            this.lblWohnSituation.Text = "Wohnsituation";
            // 
            // txtWohnsituation
            // 
            this.txtWohnsituation.AutoSize = false;
            this.txtWohnsituation.Location = new System.Drawing.Point(114, 235);
            this.txtWohnsituation.MaxLength = 100;
            this.txtWohnsituation.Multiline = true;
            this.txtWohnsituation.Name = "txtWohnsituation";
            this.txtWohnsituation.Size = new System.Drawing.Size(340, 52);
            this.txtWohnsituation.TabIndex = 12;
            this.txtWohnsituation.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblHausTier
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.lblHausTier.Appearance = appearance22;
            this.lblHausTier.AutoSize = true;
            this.lblHausTier.Location = new System.Drawing.Point(15, 370);
            this.lblHausTier.Name = "lblHausTier";
            this.lblHausTier.Size = new System.Drawing.Size(56, 17);
            this.lblHausTier.TabIndex = 65;
            this.lblHausTier.Text = "Haustier";
            // 
            // txtHaustier
            // 
            this.txtHaustier.Location = new System.Drawing.Point(114, 366);
            this.txtHaustier.MaxLength = 100;
            this.txtHaustier.Name = "txtHaustier";
            this.txtHaustier.Size = new System.Drawing.Size(340, 24);
            this.txtHaustier.TabIndex = 15;
            this.txtHaustier.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKlingel
            // 
            appearance23.BackColor = System.Drawing.Color.Transparent;
            this.lblKlingel.Appearance = appearance23;
            this.lblKlingel.Location = new System.Drawing.Point(15, 323);
            this.lblKlingel.Name = "lblKlingel";
            this.lblKlingel.Size = new System.Drawing.Size(93, 37);
            this.lblKlingel.TabIndex = 63;
            this.lblKlingel.Text = "Klingeln bei / Schlüssel bei";
            // 
            // txtKlingeln
            // 
            this.txtKlingeln.AutoSize = false;
            this.txtKlingeln.Location = new System.Drawing.Point(114, 320);
            this.txtKlingeln.MaxLength = 100;
            this.txtKlingeln.Multiline = true;
            this.txtKlingeln.Name = "txtKlingeln";
            this.txtKlingeln.Size = new System.Drawing.Size(340, 40);
            this.txtKlingeln.TabIndex = 14;
            this.txtKlingeln.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // WohnungAb
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.WohnungAb.Appearance = appearance24;
            this.WohnungAb.BackColor = System.Drawing.Color.Transparent;
            this.WohnungAb.BackColorInternal = System.Drawing.Color.Transparent;
            this.WohnungAb.Location = new System.Drawing.Point(113, 146);
            this.WohnungAb.Name = "WohnungAb";
            this.WohnungAb.Size = new System.Drawing.Size(162, 20);
            this.WohnungAb.TabIndex = 6;
            this.WohnungAb.Text = "Wohnung abgemeldet";
            this.WohnungAb.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblEmail
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Appearance = appearance25;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(259, 209);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 17);
            this.lblEmail.TabIndex = 60;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(305, 205);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(148, 24);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel9
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel9.Appearance = appearance26;
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.Location = new System.Drawing.Point(259, 179);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(38, 17);
            this.ultraLabel9.TabIndex = 58;
            this.ultraLabel9.Text = "Mobil";
            // 
            // txtMobil
            // 
            this.txtMobil.Location = new System.Drawing.Point(305, 175);
            this.txtMobil.MaxLength = 25;
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.Size = new System.Drawing.Size(148, 24);
            this.txtMobil.TabIndex = 9;
            this.txtMobil.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblErstKontakt
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.lblErstKontakt.Appearance = appearance27;
            this.lblErstKontakt.AutoSize = true;
            this.lblErstKontakt.Location = new System.Drawing.Point(15, 33);
            this.lblErstKontakt.Name = "lblErstKontakt";
            this.lblErstKontakt.Size = new System.Drawing.Size(74, 17);
            this.lblErstKontakt.TabIndex = 56;
            this.lblErstKontakt.Text = "Erstkontakt";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(114, 175);
            this.txtTelefon.MaxLength = 25;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(128, 24);
            this.txtTelefon.TabIndex = 8;
            this.txtTelefon.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel8
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel8.Appearance = appearance28;
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Location = new System.Drawing.Point(15, 179);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(51, 17);
            this.ultraLabel8.TabIndex = 52;
            this.ultraLabel8.Text = "Telefon";
            // 
            // ultraLabel6
            // 
            appearance29.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel6.Appearance = appearance29;
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Location = new System.Drawing.Point(168, 93);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(24, 17);
            this.ultraLabel6.TabIndex = 50;
            this.ultraLabel6.Text = "Ort";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(203, 89);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(250, 24);
            this.txtOrt.TabIndex = 4;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel5
            // 
            appearance30.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel5.Appearance = appearance30;
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Location = new System.Drawing.Point(14, 93);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(30, 17);
            this.ultraLabel5.TabIndex = 48;
            this.ultraLabel5.Text = "PLZ";
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(114, 89);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(48, 24);
            this.txtPLZ.TabIndex = 3;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtStrasse
            // 
            this.txtStrasse.Location = new System.Drawing.Point(114, 59);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(340, 24);
            this.txtStrasse.TabIndex = 2;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel3
            // 
            appearance31.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance31;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(15, 63);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(52, 17);
            this.ultraLabel3.TabIndex = 46;
            this.ultraLabel3.Text = "Strasse";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(114, 205);
            this.txtFax.MaxLength = 25;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(128, 24);
            this.txtFax.TabIndex = 10;
            this.txtFax.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel10
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel10.Appearance = appearance32;
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Location = new System.Drawing.Point(15, 209);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(28, 17);
            this.ultraLabel10.TabIndex = 54;
            this.ultraLabel10.Text = "Fax";
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.ultraGroupBoxAdressdatenNWS);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(477, 502);
            // 
            // ultraGroupBoxAdressdatenNWS
            // 
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBoxAdressdatenNWS.Appearance = appearance33;
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtLandNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel1);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel6);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtEmailNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel7);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtMobilNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtTelefonNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel9);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel10);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtOrtNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel11);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtPLZNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtStrasseNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel12);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtFaxNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.baseLabel13);
            this.ultraGroupBoxAdressdatenNWS.Location = new System.Drawing.Point(6, 3);
            this.ultraGroupBoxAdressdatenNWS.Name = "ultraGroupBoxAdressdatenNWS";
            this.ultraGroupBoxAdressdatenNWS.Size = new System.Drawing.Size(465, 407);
            this.ultraGroupBoxAdressdatenNWS.TabIndex = 71;
            this.ultraGroupBoxAdressdatenNWS.Text = "Adressdaten";
            // 
            // txtLandNWS
            // 
            this.txtLandNWS.AddEmptyEntry = false;
            this.txtLandNWS.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.txtLandNWS.BerufsstandGruppeJNA = -1;
            this.txtLandNWS.Group = "SBS";
            this.txtLandNWS.ID_PEP = -1;
            this.txtLandNWS.Location = new System.Drawing.Point(203, 89);
            this.txtLandNWS.MaxLength = 20;
            this.txtLandNWS.Name = "txtLandNWS";
            this.txtLandNWS.ShowAddButton = true;
            this.txtLandNWS.Size = new System.Drawing.Size(250, 24);
            this.txtLandNWS.TabIndex = 5;
            this.txtLandNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel1
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel1.Appearance = appearance34;
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Location = new System.Drawing.Point(168, 93);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(35, 17);
            this.baseLabel1.TabIndex = 121;
            this.baseLabel1.Text = "Land";
            // 
            // baseLabel6
            // 
            appearance35.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel6.Appearance = appearance35;
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Location = new System.Drawing.Point(259, 179);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(39, 17);
            this.baseLabel6.TabIndex = 60;
            this.baseLabel6.Text = "Email";
            // 
            // txtEmailNWS
            // 
            this.txtEmailNWS.Location = new System.Drawing.Point(305, 175);
            this.txtEmailNWS.MaxLength = 50;
            this.txtEmailNWS.Name = "txtEmailNWS";
            this.txtEmailNWS.Size = new System.Drawing.Size(148, 24);
            this.txtEmailNWS.TabIndex = 11;
            this.txtEmailNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel7
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel7.Appearance = appearance36;
            this.baseLabel7.AutoSize = true;
            this.baseLabel7.Location = new System.Drawing.Point(259, 149);
            this.baseLabel7.Name = "baseLabel7";
            this.baseLabel7.Size = new System.Drawing.Size(38, 17);
            this.baseLabel7.TabIndex = 58;
            this.baseLabel7.Text = "Mobil";
            // 
            // txtMobilNWS
            // 
            this.txtMobilNWS.Location = new System.Drawing.Point(305, 145);
            this.txtMobilNWS.MaxLength = 25;
            this.txtMobilNWS.Name = "txtMobilNWS";
            this.txtMobilNWS.Size = new System.Drawing.Size(148, 24);
            this.txtMobilNWS.TabIndex = 9;
            this.txtMobilNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtTelefonNWS
            // 
            this.txtTelefonNWS.Location = new System.Drawing.Point(114, 145);
            this.txtTelefonNWS.MaxLength = 25;
            this.txtTelefonNWS.Name = "txtTelefonNWS";
            this.txtTelefonNWS.Size = new System.Drawing.Size(128, 24);
            this.txtTelefonNWS.TabIndex = 8;
            this.txtTelefonNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel9
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel9.Appearance = appearance37;
            this.baseLabel9.AutoSize = true;
            this.baseLabel9.Location = new System.Drawing.Point(15, 149);
            this.baseLabel9.Name = "baseLabel9";
            this.baseLabel9.Size = new System.Drawing.Size(51, 17);
            this.baseLabel9.TabIndex = 52;
            this.baseLabel9.Text = "Telefon";
            // 
            // baseLabel10
            // 
            appearance38.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel10.Appearance = appearance38;
            this.baseLabel10.AutoSize = true;
            this.baseLabel10.Location = new System.Drawing.Point(168, 63);
            this.baseLabel10.Name = "baseLabel10";
            this.baseLabel10.Size = new System.Drawing.Size(24, 17);
            this.baseLabel10.TabIndex = 50;
            this.baseLabel10.Text = "Ort";
            // 
            // txtOrtNWS
            // 
            this.txtOrtNWS.Location = new System.Drawing.Point(203, 59);
            this.txtOrtNWS.MaxLength = 50;
            this.txtOrtNWS.Name = "txtOrtNWS";
            this.txtOrtNWS.Size = new System.Drawing.Size(250, 24);
            this.txtOrtNWS.TabIndex = 4;
            this.txtOrtNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel11
            // 
            appearance39.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel11.Appearance = appearance39;
            this.baseLabel11.AutoSize = true;
            this.baseLabel11.Location = new System.Drawing.Point(14, 63);
            this.baseLabel11.Name = "baseLabel11";
            this.baseLabel11.Size = new System.Drawing.Size(30, 17);
            this.baseLabel11.TabIndex = 48;
            this.baseLabel11.Text = "PLZ";
            // 
            // txtPLZNWS
            // 
            this.txtPLZNWS.Location = new System.Drawing.Point(114, 59);
            this.txtPLZNWS.MaxLength = 6;
            this.txtPLZNWS.Name = "txtPLZNWS";
            this.txtPLZNWS.Size = new System.Drawing.Size(48, 24);
            this.txtPLZNWS.TabIndex = 3;
            this.txtPLZNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtStrasseNWS
            // 
            this.txtStrasseNWS.Location = new System.Drawing.Point(114, 29);
            this.txtStrasseNWS.MaxLength = 50;
            this.txtStrasseNWS.Name = "txtStrasseNWS";
            this.txtStrasseNWS.Size = new System.Drawing.Size(340, 24);
            this.txtStrasseNWS.TabIndex = 2;
            this.txtStrasseNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel12
            // 
            appearance40.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel12.Appearance = appearance40;
            this.baseLabel12.AutoSize = true;
            this.baseLabel12.Location = new System.Drawing.Point(15, 33);
            this.baseLabel12.Name = "baseLabel12";
            this.baseLabel12.Size = new System.Drawing.Size(52, 17);
            this.baseLabel12.TabIndex = 46;
            this.baseLabel12.Text = "Strasse";
            // 
            // txtFaxNWS
            // 
            this.txtFaxNWS.Location = new System.Drawing.Point(114, 175);
            this.txtFaxNWS.MaxLength = 25;
            this.txtFaxNWS.Name = "txtFaxNWS";
            this.txtFaxNWS.Size = new System.Drawing.Size(128, 24);
            this.txtFaxNWS.TabIndex = 10;
            this.txtFaxNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel13
            // 
            appearance41.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel13.Appearance = appearance41;
            this.baseLabel13.AutoSize = true;
            this.baseLabel13.Location = new System.Drawing.Point(15, 179);
            this.baseLabel13.Name = "baseLabel13";
            this.baseLabel13.Size = new System.Drawing.Size(28, 17);
            this.baseLabel13.TabIndex = 54;
            this.baseLabel13.Text = "Fax";
            // 
            // ucBewerbungsdaten1
            // 
            this.ucBewerbungsdaten1.BackColor = System.Drawing.Color.Transparent;
            this.ucBewerbungsdaten1.BewerberReadOnly = false;
            this.ucBewerbungsdaten1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ucBewerbungsdaten1.Location = new System.Drawing.Point(496, 9);
            this.ucBewerbungsdaten1.Margin = new System.Windows.Forms.Padding(5);
            this.ucBewerbungsdaten1.Name = "ucBewerbungsdaten1";
            this.ucBewerbungsdaten1.Size = new System.Drawing.Size(479, 529);
            this.ucBewerbungsdaten1.TabIndex = 69;
            this.ucBewerbungsdaten1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelDokumente);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1004, 610);
            // 
            // panelDokumente
            // 
            this.panelDokumente.BackColor = System.Drawing.Color.Transparent;
            this.panelDokumente.Controls.Add(this.ucKlientStammdatenDokumente1);
            this.panelDokumente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDokumente.Location = new System.Drawing.Point(0, 0);
            this.panelDokumente.Name = "panelDokumente";
            this.panelDokumente.Size = new System.Drawing.Size(1004, 610);
            this.panelDokumente.TabIndex = 0;
            // 
            // ucKlientStammdatenDokumente1
            // 
            this.ucKlientStammdatenDokumente1.BackColor = System.Drawing.Color.Transparent;
            this.ucKlientStammdatenDokumente1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKlientStammdatenDokumente1.Location = new System.Drawing.Point(0, 0);
            this.ucKlientStammdatenDokumente1.Margin = new System.Windows.Forms.Padding(4);
            this.ucKlientStammdatenDokumente1.Name = "ucKlientStammdatenDokumente1";
            this.ucKlientStammdatenDokumente1.Size = new System.Drawing.Size(1004, 610);
            this.ucKlientStammdatenDokumente1.TabIndex = 0;
            // 
            // contextMenuStripÄrzte
            // 
            this.contextMenuStripÄrzte.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zusammenführenToolStripMenuItem});
            this.contextMenuStripÄrzte.Name = "contextMenuStripÄrzte";
            this.contextMenuStripÄrzte.Size = new System.Drawing.Size(170, 26);
            // 
            // zusammenführenToolStripMenuItem
            // 
            this.zusammenführenToolStripMenuItem.Name = "zusammenführenToolStripMenuItem";
            this.zusammenführenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zusammenführenToolStripMenuItem.Text = "Zusammenführen";
            this.zusammenführenToolStripMenuItem.Click += new System.EventHandler(this.zusammenführenToolStripMenuItem_Click);
            // 
            // tabStammdaten
            // 
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.BorderColor = System.Drawing.Color.Black;
            appearance14.FontData.BoldAsString = "True";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.tabStammdaten.ActiveTabAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.White;
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.Name = "Microsoft Sans Serif";
            appearance15.FontData.SizeInPoints = 10F;
            appearance15.FontData.UnderlineAsString = "False";
            this.tabStammdaten.Appearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.tabStammdaten.ClientAreaAppearance = appearance16;
            this.tabStammdaten.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl2);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl5);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl3);
            this.tabStammdaten.Controls.Add(this.pageControlAufenthalt);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl1);
            this.tabStammdaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.OriginX = 0;
            gridBagConstraint3.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.tabStammdaten, gridBagConstraint3);
            appearance75.BackColor = System.Drawing.Color.White;
            appearance75.FontData.BoldAsString = "True";
            appearance75.FontData.SizeInPoints = 10F;
            appearance75.FontData.UnderlineAsString = "False";
            appearance75.ForeColor = System.Drawing.Color.Black;
            this.tabStammdaten.HotTrackAppearance = appearance75;
            this.tabStammdaten.Location = new System.Drawing.Point(0, 0);
            this.tabStammdaten.Name = "tabStammdaten";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.tabStammdaten, new System.Drawing.Size(723, 468));
            this.tabStammdaten.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabStammdaten.Size = new System.Drawing.Size(1008, 637);
            appearance76.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStammdaten.TabHeaderAreaAppearance = appearance76;
            this.tabStammdaten.TabIndex = 1;
            ultraTab1.Key = "PersoenlicheDaten";
            ultraTab1.TabPage = this.ultraTabPageControl2;
            ultraTab1.Text = "Persönliche Daten";
            ultraTab4.Key = "Aufenthalt";
            ultraTab4.TabPage = this.pageControlAufenthalt;
            ultraTab4.Text = "Aufenthalt";
            ultraTab3.Key = "Kontakte";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Kontakte";
            ultraTab2.Key = "Wohnsituation";
            ultraTab2.TabPage = this.ultraTabPageControl5;
            ultraTab2.Text = "Adress- und Bewerbungsdaten";
            ultraTab5.Key = "Dokumente";
            ultraTab5.TabPage = this.ultraTabPageControl1;
            ultraTab5.Text = "Dokumente";
            this.tabStammdaten.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab4,
            ultraTab3,
            ultraTab2,
            ultraTab5});
            this.tabStammdaten.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.tabStammdaten.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(1004, 610);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = resources.GetString("openFileDialog1.Filter");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = resources.GetString("saveFileDialog1.Filter");
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.tabStammdaten);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(1008, 637);
            this.ultraGridBagLayoutPanel1.TabIndex = 2;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucKlientStammdaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.errorProvider1.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucKlientStammdaten";
            this.Size = new System.Drawing.Size(1008, 637);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesonderheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKZUeberlebender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnatomie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMilieubetreuung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTodeszeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).EndInit();
            this.panelAufenthaltsdaten2.ResumeLayout(false);
            this.panelAufenthaltsdaten2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKennwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgruppenkennzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxOben)).EndInit();
            this.ultraGroupBoxOben.ResumeLayout(false);
            this.ultraGroupBoxOben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAkdGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gebDatum)).EndInit();
            this.panelAufenthaltsdaten.ResumeLayout(false);
            this.panelAufenthaltsdaten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKliNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZimmerNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAllgemein1)).EndInit();
            this.ultraGroupBoxAllgemein1.ResumeLayout(false);
            this.ultraGroupBoxAllgemein1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKosename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesKennz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxPersonebescheibung)).EndInit();
            this.ultraGroupBoxPersonebescheibung.ResumeLayout(false);
            this.ultraGroupBoxPersonebescheibung.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbstatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaarFarbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAugenFarbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Namenstag)).EndInit();
            this.pageControlAufenthalt.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAngehörige)).EndInit();
            this.ultraGroupBoxAngehörige.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxÄrtze)).EndInit();
            this.ultraGroupBoxÄrtze.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAerzte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAerzte1)).EndInit();
            this.panelButtons1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxSachverwalter)).EndInit();
            this.ultraGroupBoxSachverwalter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel3)).EndInit();
            this.ultraGridBagLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSachwalter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientSachwalter1)).EndInit();
            this.panelButtons2.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdaten)).EndInit();
            this.ultraGroupBoxAdressdaten.ResumeLayout(false);
            this.ultraGroupBoxAdressdaten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZustgStelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaustier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlingeln)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WohnungAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            this.ultraTabPageControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdatenNWS)).EndInit();
            this.ultraGroupBoxAdressdatenNWS.ResumeLayout(false);
            this.ultraGroupBoxAdressdatenNWS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLandNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrtNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseNWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaxNWS)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelDokumente.ResumeLayout(false);
            this.contextMenuStripÄrzte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabStammdaten)).EndInit();
            this.tabStammdaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAllgemein1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbStaatsB;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbKonfession;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbFAM;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbSexus;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeruf;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBeruf;
        private QS2.Desktop.ControlManagment.BaseLabel lblFamiliensst;
        private QS2.Desktop.ControlManagment.BaseLabel lblKonf;
        private QS2.Desktop.ControlManagment.BaseLabel lblStatsB;
        private QS2.Desktop.ControlManagment.BaseLabel lblGeschl;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtGebOrt;
        private QS2.Desktop.ControlManagment.BaseLabel lblGebOrt;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtGebName;
        private QS2.Desktop.ControlManagment.BaseLabel lblGebName;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor gebDatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblGebDat;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxOben;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbAnrede;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbAkdGrad;
        private QS2.Desktop.ControlManagment.BaseLabel lblFallzahl;
        private QS2.Desktop.ControlManagment.BaseLabel lblGruppenKz;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtgruppenkennzahl;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVorname;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblAkdGrad;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitel;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxPersonebescheibung;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbHaarFarbe;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbAugenFarbe;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox foto;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKosename;
        private QS2.Desktop.ControlManagment.BaseLabel lblGewicht;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBesKennz;
        private QS2.Desktop.ControlManagment.BaseLabel lblAeussKenz;
        private QS2.Desktop.ControlManagment.BaseLabel lblAugenfarbe;
        private QS2.Desktop.ControlManagment.BaseLabel lblHaarFarbe;
        private QS2.Desktop.ControlManagment.BaseLabel lblStatur;
        private QS2.Desktop.ControlManagment.BaseLabel lblGroesse;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtInitialBer;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor Namenstag;
        private QS2.Desktop.ControlManagment.BaseLabel lblNamenstag;
        private QS2.Desktop.ControlManagment.BaseLabel lblInitBer;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnrede;
        private QS2.Desktop.ControlManagment.BaseLabel lblVorname;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAdressdaten;
        private QS2.Desktop.ControlManagment.BaseLabel lblZustgStelle;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtZustgStelle;
        private QS2.Desktop.ControlManagment.BaseLabel lblWohnSituation;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtWohnsituation;
        private QS2.Desktop.ControlManagment.BaseCheckBox lift;
        private QS2.Desktop.ControlManagment.BaseLabel lblHausTier;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtHaustier;
        private QS2.Desktop.ControlManagment.BaseLabel lblKlingel;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKlingeln;
        private QS2.Desktop.ControlManagment.BaseCheckBox WohnungAb;
        private QS2.Desktop.ControlManagment.BaseLabel lblEmail;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtEmail;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel9;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtMobil;
        private QS2.Desktop.ControlManagment.BaseLabel lblErstKontakt;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtTelefon;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel8;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel6;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtOrt;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel5;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtPLZ;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasse;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtFax;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel10;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAngehörige;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxÄrtze;
        private QS2.Desktop.ControlManagment.BaseGrid gridAerzte;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxSachverwalter;
        private QS2.Desktop.ControlManagment.BaseGrid gridSachwalter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbstatur;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbBenutzer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private QS2.Desktop.ControlManagment.BaseButton btnPicSave;
        private QS2.Desktop.ControlManagment.BaseButton btnPicLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private  dsKontaktpersonen dsKontaktpersonen1;
        private PMDS.Klient.dsKlientSachwalter dsKlientSachwalter1;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtFallzahl;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtGewicht;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtGroesse;
        private ucKontaktPersonen ucKontaktPersonen1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo txtLand;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel7;
        private ucButton btnDelAerzte;
        private ucButton btnUpdateAerzte;
        private ucButton btnDelSachwalter;
        private ucButton btnAddSachw;
        private dsPatientAerzte dsPatientAerzte1;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdateArzt;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdateSachw;
        private ucBewerbungsdaten ucBewerbungsdaten1;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKliNr;
        private QS2.Desktop.ControlManagment.BaseLabel lblKlientNr;
        private QS2.Desktop.ControlManagment.BaseLabel lblZimNr;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtZimmerNr;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BasePanel panelButtons1;
        public QS2.Desktop.ControlManagment.BasePanel panelButtons2;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl pageControlAufenthalt;
        private QS2.Desktop.ControlManagment.BaseButton btnPicClear;
        private QS2.Desktop.ControlManagment.BasePanel panelAufenthaltsdaten;
        private QS2.Desktop.ControlManagment.BasePanel panelAufenthaltsdaten2;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKennwort;
        private ucAbrechAufenthKlient ucAbrechAufenthKlient1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public QS2.Desktop.ControlManagment.BaseTabControl tabStammdaten;
        private QS2.Desktop.ControlManagment.BaseButton btnMagnify;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel panelDokumente;
        private Klient.ucKlientStammdatenDokumente ucKlientStammdatenDokumente1;
        private QS2.Desktop.ControlManagment.BaseLabel lblTodeszeitpunkt;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkDNR;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkVerstorben;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dteTodeszeitpunkt;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkKZUeberlebender;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkAnatomie;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkMilieubetreuung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBesonderheit;
        private QS2.Desktop.ControlManagment.BaseLabel lblBesonderheit;
        private QS2.Desktop.ControlManagment.BaseLabel lblPatientenverfügung;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripÄrzte;
        private System.Windows.Forms.ToolStripMenuItem zusammenführenToolStripMenuItem;
        private UltraTabControl ultraTabControl1;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private UltraTabPageControl ultraTabPageControl4;
        private UltraTabPageControl ultraTabPageControl6;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAdressdatenNWS;
        private BaseControls.AuswahlGruppeCombo txtLandNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel6;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtEmailNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel7;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtMobilNWS;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtTelefonNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel9;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel10;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtOrtNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel11;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtPLZNWS;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasseNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel12;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtFaxNWS;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel13;
    }
}
