using Infragistics.Win.UltraWinTabControl;
using PMDS.Global.db.Global;
using PMDS.GUI.Klient;
using PMDS.Klient;
using PMDSClient.Sitemap;
//using PMDS.GUI.VB;

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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Gemeinde, in der letzte Hauptwohnsitz gelegen ist.", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Bereichsspezifisches Personenkennzeichen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Bereichsspezifisches Personenkennzeichen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto öffnen", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientAerzte", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAerzte");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HausarztJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZuweiserJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufnahmearztJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BehandelnderFAJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_HausarztJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fachrichtung", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TelAdresse", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail", 3);
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Kontaktdelegation", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlientStammdaten));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Sachwalter", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAdresse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Belange");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BestimmtAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TelAdresse", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail", 1);
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            PMDS.DB.PMDSBusiness pmdsBusiness1 = new PMDS.DB.PMDSBusiness();
            PMDS.GUI.PMDSBusinessUI pmdsBusinessUI1 = new PMDS.GUI.PMDSBusinessUI();
            PMDS.Global.db.ERSystem.PMDSBusinessUI pmdsBusinessUI2 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
            PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();
            PMDS.GUI.PMDSBusinessUI pmdsBusinessUI3 = new PMDS.GUI.PMDSBusinessUI();
            PMDS.Global.UIGlobal uiGlobal1 = new PMDS.Global.UIGlobal();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab8 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab9 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab10 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab11 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab12 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBoxAdressdaten = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblVorhergendeBetreuungsformen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboVorherigeBetreuungsformenMulti = new PMDS.GUI.Klient.cboAuswahllisteMulti();
            this.cmbHaupwohnsitzgemeinde = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblHauptwohnsitzgemeinde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHausnummer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtHausnummer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasseOhneHausnummer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lift = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblLand = new QS2.Desktop.ControlManagment.BaseLabel();
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
            this.lblMobil = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtMobil = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtTelefon = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblTelefon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPLZ = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPLZ = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblStrasse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFax = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblFax = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblErstKontakt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBoxAdressdatenNWS = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.txtLandNWS = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblLandSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEMailSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtEmailNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblMobilSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtMobilNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtTelefonNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblTelefonSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblOrtSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtOrtNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPLZSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPLZNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasseNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblAdresse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFaxNWS = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblFaxSub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpAdmin = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblSTAMPSynonym = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSTAMPSynonym = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkELGAAbgemeldet = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelAufenthaltsdaten2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAbwesenheitsendeBestätigen = new Infragistics.Win.Misc.UltraButton();
            this.txtZimmerNr = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblZimNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGruppenKz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFallzahl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFallzahl = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtgruppenkennzahl = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkMilieubetreuung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkAbwesenheitBeendet = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtKennwort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKennwort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.baseLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtbPK = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraGroupBoxOben = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lbleMailKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMobilTelNrKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEMailPat = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTitelPost = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboTitelPost = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblMobilTel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelVerstorben = new System.Windows.Forms.Panel();
            this.dteTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkVerstorben = new QS2.Desktop.ControlManagment.BaseCheckBox();
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
            this.lblVorname2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAkdGrad = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGebDat = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGeschl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.gebDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.ultraGroupBoxAllgemein1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblDNRAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtDNRAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPatientenverfügung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkAnatomie = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkDatenschutz = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblSprachen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBeruf = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboSprachenMulti = new PMDS.GUI.Klient.cboAuswahllisteMulti();
            this.chkPalliativ = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtBeruf = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtGebOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGebOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtGebName = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkKZUeberlebender = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblGebName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkDNR = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblInitBer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtInitialBer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraGroupBoxPersonebescheibung = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.baseLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOpenPicture = new QS2.Desktop.ControlManagment.BaseButton();
            this.intAmputation_Prozent = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblAmputation_Prozent = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtGewicht = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtGroesse = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.cmbstatur = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbHaarFarbe = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbAugenFarbe = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblGewicht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAugenfarbe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnrede = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBesKennz = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblHaarFarbe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAeussKenz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKosename = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblStatur = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGroesse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.Namenstag = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblNamenstag = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pageControlAufenthalt = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelAufenthalt = new System.Windows.Forms.Panel();
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
            this.btnELGAKontakDelegation = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUpdateArzt = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelAerzte = new PMDS.GUI.ucButton(this.components);
            this.btnUpdateAerzte = new PMDS.GUI.ucButton(this.components);
            this.ultraGroupBoxSachverwalter = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraGridBagLayoutPanel3 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.gridSachwalter = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientSachwalter1 = new PMDS.GUI.Klient.dsKlientSachwalter();
            this.panelButtons2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnUpdateSachw = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelSachwalter = new PMDS.GUI.ucButton(this.components);
            this.btnAddSachw = new PMDS.GUI.ucButton(this.components);
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelBewerbungdsdaten = new System.Windows.Forms.Panel();
            this.txtStrasse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraTabControlMainAdresse = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.editorRezGebBef_Anmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseGroupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.chkRezGebBef_SachwalterJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.datRezGebBef_BefristetAb = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.datRezGebBef_BefristetBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.datRezGebBef_RegoBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cboRezGebBef_WiderrufGrund = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.datRezGebBef_RegoAb = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.baseLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkRezGebBef_BefristetJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkRezGebBef_WiderrufJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkRezGebBef_UnbefristetJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbRezeptGeb = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkRezGebBef_RegoJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelDokumente = new System.Windows.Forms.Panel();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelDienstübergabe = new System.Windows.Forms.Panel();
            this.splitContainerDienstübergabe = new System.Windows.Forms.SplitContainer();
            this.txtSofortmassnahmen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSofortmassnahmen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInfoDienstuebergabe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtInfoDienstuebergabe = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.lblBesonderheit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBesonderheit2 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucVOErfassen1 = new PMDS.GUI.Verordnungen.ucVOErfassen();
            this.ultraTabPageControl10 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.contELGAKlient1 = new PMDS.GUI.ELGA.contELGAKlient();
            this.ultraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pnlSTAMP = new Infragistics.Win.Misc.UltraPanel();
            this.ucSTAMPData1 = new PMDS.GUI.STAMP.ucSTAMPData();
            this.contextMenuStripÄrzte = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zusammenführenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabStammdaten = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdaten)).BeginInit();
            this.ultraGroupBoxAdressdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaupwohnsitzgemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHausnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseOhneHausnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLand)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).BeginInit();
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
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).BeginInit();
            this.grpAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTAMPSynonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAbgemeldet)).BeginInit();
            this.panelAufenthaltsdaten2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtZimmerNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgruppenkennzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMilieubetreuung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbwesenheitBeendet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKennwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxOben)).BeginInit();
            this.ultraGroupBoxOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitelPost)).BeginInit();
            this.panelVerstorben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteTodeszeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAkdGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gebDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAllgemein1)).BeginInit();
            this.ultraGroupBoxAllgemein1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNRAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnatomie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDatenschutz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalliativ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKZUeberlebender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxPersonebescheibung)).BeginInit();
            this.ultraGroupBoxPersonebescheibung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbstatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaarFarbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAugenFarbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesKennz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKosename)).BeginInit();
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
            this.panelBewerbungdsdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlMainAdresse)).BeginInit();
            this.ultraTabControlMainAdresse.SuspendLayout();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorRezGebBef_Anmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseGroupBox1)).BeginInit();
            this.baseGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_SachwalterJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_BefristetAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_BefristetBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_RegoBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRezGebBef_WiderrufGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_RegoAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_BefristetJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_WiderrufJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_UnbefristetJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRezeptGeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_RegoJN)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl8.SuspendLayout();
            this.panelDienstübergabe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDienstübergabe)).BeginInit();
            this.splitContainerDienstübergabe.Panel1.SuspendLayout();
            this.splitContainerDienstübergabe.Panel2.SuspendLayout();
            this.splitContainerDienstübergabe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSofortmassnahmen)).BeginInit();
            this.ultraTabPageControl9.SuspendLayout();
            this.ultraTabPageControl10.SuspendLayout();
            this.ultraTabPageControl11.SuspendLayout();
            this.pnlSTAMP.ClientArea.SuspendLayout();
            this.pnlSTAMP.SuspendLayout();
            this.contextMenuStripÄrzte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStammdaten)).BeginInit();
            this.tabStammdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGroupBoxAdressdaten);
            this.ultraTabPageControl4.Controls.Add(this.cmbBenutzer);
            this.ultraTabPageControl4.Controls.Add(this.lblErstKontakt);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(477, 592);
            // 
            // ultraGroupBoxAdressdaten
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBoxAdressdaten.Appearance = appearance1;
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblVorhergendeBetreuungsformen);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.cboVorherigeBetreuungsformenMulti);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.cmbHaupwohnsitzgemeinde);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblHauptwohnsitzgemeinde);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblHausnummer);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtHausnummer);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtStrasseOhneHausnummer);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lift);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtLand);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblLand);
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
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblMobil);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtMobil);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtTelefon);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblTelefon);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblOrt);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtOrt);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblPLZ);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtPLZ);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblStrasse);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.txtFax);
            this.ultraGroupBoxAdressdaten.Controls.Add(this.lblFax);
            this.ultraGroupBoxAdressdaten.Location = new System.Drawing.Point(6, 7);
            this.ultraGroupBoxAdressdaten.Name = "ultraGroupBoxAdressdaten";
            this.ultraGroupBoxAdressdaten.Size = new System.Drawing.Size(464, 551);
            this.ultraGroupBoxAdressdaten.TabIndex = 68;
            this.ultraGroupBoxAdressdaten.Text = "Adressdaten";
            // 
            // lblVorhergendeBetreuungsformen
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblVorhergendeBetreuungsformen.Appearance = appearance2;
            this.lblVorhergendeBetreuungsformen.AutoSize = true;
            this.lblVorhergendeBetreuungsformen.Location = new System.Drawing.Point(8, 156);
            this.lblVorhergendeBetreuungsformen.Name = "lblVorhergendeBetreuungsformen";
            this.lblVorhergendeBetreuungsformen.Size = new System.Drawing.Size(132, 17);
            this.lblVorhergendeBetreuungsformen.TabIndex = 225;
            this.lblVorhergendeBetreuungsformen.Text = "Vorherige Betreuung";
            // 
            // cboVorherigeBetreuungsformenMulti
            // 
            this.cboVorherigeBetreuungsformenMulti.Location = new System.Drawing.Point(160, 150);
            this.cboVorherigeBetreuungsformenMulti.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboVorherigeBetreuungsformenMulti.Name = "cboVorherigeBetreuungsformenMulti";
            this.cboVorherigeBetreuungsformenMulti.Size = new System.Drawing.Size(293, 32);
            this.cboVorherigeBetreuungsformenMulti.TabIndex = 224;
            this.cboVorherigeBetreuungsformenMulti.AfterCheck += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbHaupwohnsitzgemeinde
            // 
            this.cmbHaupwohnsitzgemeinde.AddEmptyEntry = false;
            appearance3.BackColor = System.Drawing.Color.White;
            this.cmbHaupwohnsitzgemeinde.Appearance = appearance3;
            this.cmbHaupwohnsitzgemeinde.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbHaupwohnsitzgemeinde.AutoOpenCBO = false;
            this.cmbHaupwohnsitzgemeinde.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbHaupwohnsitzgemeinde.BackColor = System.Drawing.Color.White;
            this.cmbHaupwohnsitzgemeinde.BerufsstandGruppeJNA = -1;
            this.cmbHaupwohnsitzgemeinde.ExactMatch = false;
            this.cmbHaupwohnsitzgemeinde.Group = "GKZ";
            this.cmbHaupwohnsitzgemeinde.IgnoreUnterdruecken = true;
            this.cmbHaupwohnsitzgemeinde.Location = new System.Drawing.Point(160, 117);
            this.cmbHaupwohnsitzgemeinde.MaxLength = 40;
            this.cmbHaupwohnsitzgemeinde.Name = "cmbHaupwohnsitzgemeinde";
            this.cmbHaupwohnsitzgemeinde.PflichtJN = false;
            this.cmbHaupwohnsitzgemeinde.SelectDistinct = false;
            this.cmbHaupwohnsitzgemeinde.ShowAddButton = true;
            this.cmbHaupwohnsitzgemeinde.Size = new System.Drawing.Size(292, 24);
            this.cmbHaupwohnsitzgemeinde.sys = false;
            this.cmbHaupwohnsitzgemeinde.TabIndex = 7;
            this.cmbHaupwohnsitzgemeinde.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblHauptwohnsitzgemeinde
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblHauptwohnsitzgemeinde.Appearance = appearance4;
            this.lblHauptwohnsitzgemeinde.AutoSize = true;
            this.lblHauptwohnsitzgemeinde.Location = new System.Drawing.Point(8, 121);
            this.lblHauptwohnsitzgemeinde.Name = "lblHauptwohnsitzgemeinde";
            this.lblHauptwohnsitzgemeinde.Size = new System.Drawing.Size(146, 17);
            this.lblHauptwohnsitzgemeinde.TabIndex = 223;
            this.lblHauptwohnsitzgemeinde.Text = "Letzte HWS-Gemeinde";
            ultraToolTipInfo7.ToolTipText = "Gemeinde, in der letzte Hauptwohnsitz gelegen ist.";
            this.ultraToolTipManager1.SetUltraToolTip(this.lblHauptwohnsitzgemeinde, ultraToolTipInfo7);
            // 
            // lblHausnummer
            // 
            appearance120.BackColor = System.Drawing.Color.Transparent;
            this.lblHausnummer.Appearance = appearance120;
            this.lblHausnummer.AutoSize = true;
            this.lblHausnummer.Location = new System.Drawing.Point(352, 31);
            this.lblHausnummer.Name = "lblHausnummer";
            this.lblHausnummer.Size = new System.Drawing.Size(23, 17);
            this.lblHausnummer.TabIndex = 124;
            this.lblHausnummer.Text = "Nr.";
            // 
            // txtHausnummer
            // 
            this.txtHausnummer.Location = new System.Drawing.Point(375, 27);
            this.txtHausnummer.MaxLength = 10;
            this.txtHausnummer.Name = "txtHausnummer";
            this.txtHausnummer.Size = new System.Drawing.Size(77, 24);
            this.txtHausnummer.TabIndex = 3;
            this.txtHausnummer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtStrasseOhneHausnummer
            // 
            this.txtStrasseOhneHausnummer.Location = new System.Drawing.Point(112, 27);
            this.txtStrasseOhneHausnummer.MaxLength = 60;
            this.txtStrasseOhneHausnummer.Name = "txtStrasseOhneHausnummer";
            this.txtStrasseOhneHausnummer.Size = new System.Drawing.Size(237, 24);
            this.txtStrasseOhneHausnummer.TabIndex = 2;
            this.txtStrasseOhneHausnummer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lift
            // 
            appearance121.BackColor = System.Drawing.Color.Transparent;
            this.lift.Appearance = appearance121;
            this.lift.BackColor = System.Drawing.Color.Transparent;
            this.lift.BackColorInternal = System.Drawing.Color.Transparent;
            this.lift.Location = new System.Drawing.Point(112, 410);
            this.lift.Name = "lift";
            this.lift.Size = new System.Drawing.Size(85, 20);
            this.lift.TabIndex = 14;
            this.lift.Text = "Lift";
            this.lift.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtLand
            // 
            this.txtLand.AddEmptyEntry = false;
            this.txtLand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.txtLand.AutoOpenCBO = false;
            this.txtLand.BerufsstandGruppeJNA = -1;
            this.txtLand.ExactMatch = false;
            this.txtLand.Group = "LND";
            this.txtLand.IgnoreUnterdruecken = true;
            this.txtLand.Location = new System.Drawing.Point(112, 87);
            this.txtLand.MaxLength = 20;
            this.txtLand.Name = "txtLand";
            this.txtLand.PflichtJN = false;
            this.txtLand.SelectDistinct = false;
            this.txtLand.ShowAddButton = true;
            this.txtLand.Size = new System.Drawing.Size(340, 24);
            this.txtLand.sys = false;
            this.txtLand.TabIndex = 6;
            this.txtLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblLand
            // 
            appearance122.BackColor = System.Drawing.Color.Transparent;
            this.lblLand.Appearance = appearance122;
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(8, 91);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(35, 17);
            this.lblLand.TabIndex = 121;
            this.lblLand.Text = "Land";
            // 
            // lblZustgStelle
            // 
            appearance123.BackColor = System.Drawing.Color.Transparent;
            this.lblZustgStelle.Appearance = appearance123;
            this.lblZustgStelle.AutoSize = true;
            this.lblZustgStelle.Location = new System.Drawing.Point(8, 433);
            this.lblZustgStelle.Name = "lblZustgStelle";
            this.lblZustgStelle.Size = new System.Drawing.Size(74, 17);
            this.lblZustgStelle.TabIndex = 70;
            this.lblZustgStelle.Text = "Zust. Stelle";
            // 
            // txtZustgStelle
            // 
            this.txtZustgStelle.AutoSize = false;
            this.txtZustgStelle.Location = new System.Drawing.Point(112, 433);
            this.txtZustgStelle.MaxLength = 25;
            this.txtZustgStelle.Name = "txtZustgStelle";
            this.txtZustgStelle.Size = new System.Drawing.Size(340, 21);
            this.txtZustgStelle.TabIndex = 15;
            this.txtZustgStelle.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblWohnSituation
            // 
            appearance124.BackColor = System.Drawing.Color.Transparent;
            this.lblWohnSituation.Appearance = appearance124;
            this.lblWohnSituation.AutoSize = true;
            this.lblWohnSituation.Location = new System.Drawing.Point(8, 354);
            this.lblWohnSituation.Name = "lblWohnSituation";
            this.lblWohnSituation.Size = new System.Drawing.Size(92, 17);
            this.lblWohnSituation.TabIndex = 68;
            this.lblWohnSituation.Text = "Wohnsituation";
            // 
            // txtWohnsituation
            // 
            this.txtWohnsituation.AutoSize = false;
            this.txtWohnsituation.Location = new System.Drawing.Point(112, 351);
            this.txtWohnsituation.MaxLength = 100;
            this.txtWohnsituation.Multiline = true;
            this.txtWohnsituation.Name = "txtWohnsituation";
            this.txtWohnsituation.Size = new System.Drawing.Size(340, 53);
            this.txtWohnsituation.TabIndex = 13;
            this.txtWohnsituation.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblHausTier
            // 
            appearance125.BackColor = System.Drawing.Color.Transparent;
            this.lblHausTier.Appearance = appearance125;
            this.lblHausTier.AutoSize = true;
            this.lblHausTier.Location = new System.Drawing.Point(8, 510);
            this.lblHausTier.Name = "lblHausTier";
            this.lblHausTier.Size = new System.Drawing.Size(73, 17);
            this.lblHausTier.TabIndex = 65;
            this.lblHausTier.Text = "Haustier(e)";
            // 
            // txtHaustier
            // 
            this.txtHaustier.Location = new System.Drawing.Point(112, 506);
            this.txtHaustier.MaxLength = 100;
            this.txtHaustier.Multiline = true;
            this.txtHaustier.Name = "txtHaustier";
            this.txtHaustier.Size = new System.Drawing.Size(340, 40);
            this.txtHaustier.TabIndex = 17;
            this.txtHaustier.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKlingel
            // 
            appearance126.BackColor = System.Drawing.Color.Transparent;
            this.lblKlingel.Appearance = appearance126;
            this.lblKlingel.Location = new System.Drawing.Point(8, 463);
            this.lblKlingel.Name = "lblKlingel";
            this.lblKlingel.Size = new System.Drawing.Size(93, 37);
            this.lblKlingel.TabIndex = 63;
            this.lblKlingel.Text = "Klingeln bei / Schlüssel bei";
            // 
            // txtKlingeln
            // 
            this.txtKlingeln.AutoSize = false;
            this.txtKlingeln.Location = new System.Drawing.Point(112, 460);
            this.txtKlingeln.MaxLength = 100;
            this.txtKlingeln.Multiline = true;
            this.txtKlingeln.Name = "txtKlingeln";
            this.txtKlingeln.Size = new System.Drawing.Size(340, 40);
            this.txtKlingeln.TabIndex = 16;
            this.txtKlingeln.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // WohnungAb
            // 
            appearance127.BackColor = System.Drawing.Color.Transparent;
            this.WohnungAb.Appearance = appearance127;
            this.WohnungAb.BackColor = System.Drawing.Color.Transparent;
            this.WohnungAb.BackColorInternal = System.Drawing.Color.Transparent;
            this.WohnungAb.Location = new System.Drawing.Point(112, 188);
            this.WohnungAb.Name = "WohnungAb";
            this.WohnungAb.Size = new System.Drawing.Size(162, 20);
            this.WohnungAb.TabIndex = 8;
            this.WohnungAb.Text = "Wohnung abgemeldet";
            this.WohnungAb.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblEmail
            // 
            appearance128.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Appearance = appearance128;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(8, 310);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 17);
            this.lblEmail.TabIndex = 60;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 306);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(340, 24);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblMobil
            // 
            appearance129.BackColor = System.Drawing.Color.Transparent;
            this.lblMobil.Appearance = appearance129;
            this.lblMobil.AutoSize = true;
            this.lblMobil.Location = new System.Drawing.Point(8, 250);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(38, 17);
            this.lblMobil.TabIndex = 58;
            this.lblMobil.Text = "Mobil";
            // 
            // txtMobil
            // 
            this.txtMobil.Location = new System.Drawing.Point(112, 246);
            this.txtMobil.MaxLength = 25;
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.Size = new System.Drawing.Size(341, 24);
            this.txtMobil.TabIndex = 10;
            this.txtMobil.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(112, 216);
            this.txtTelefon.MaxLength = 25;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(341, 24);
            this.txtTelefon.TabIndex = 9;
            this.txtTelefon.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblTelefon
            // 
            appearance130.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefon.Appearance = appearance130;
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(8, 220);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(51, 17);
            this.lblTelefon.TabIndex = 52;
            this.lblTelefon.Text = "Telefon";
            // 
            // lblOrt
            // 
            appearance131.BackColor = System.Drawing.Color.Transparent;
            this.lblOrt.Appearance = appearance131;
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(167, 61);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(24, 17);
            this.lblOrt.TabIndex = 50;
            this.lblOrt.Text = "Ort";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(202, 57);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(250, 24);
            this.txtOrt.TabIndex = 5;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPLZ
            // 
            appearance132.BackColor = System.Drawing.Color.Transparent;
            this.lblPLZ.Appearance = appearance132;
            this.lblPLZ.AutoSize = true;
            this.lblPLZ.Location = new System.Drawing.Point(8, 61);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(30, 17);
            this.lblPLZ.TabIndex = 48;
            this.lblPLZ.Text = "PLZ";
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(112, 57);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(48, 24);
            this.txtPLZ.TabIndex = 4;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStrasse
            // 
            appearance133.BackColor = System.Drawing.Color.Transparent;
            this.lblStrasse.Appearance = appearance133;
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Location = new System.Drawing.Point(8, 31);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(52, 17);
            this.lblStrasse.TabIndex = 46;
            this.lblStrasse.Text = "Strasse";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(112, 276);
            this.txtFax.MaxLength = 25;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(340, 24);
            this.txtFax.TabIndex = 11;
            this.txtFax.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblFax
            // 
            appearance134.BackColor = System.Drawing.Color.Transparent;
            this.lblFax.Appearance = appearance134;
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(8, 280);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(28, 17);
            this.lblFax.TabIndex = 54;
            this.lblFax.Text = "Fax";
            // 
            // cmbBenutzer
            // 
            this.cmbBenutzer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbBenutzer.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbBenutzer.Location = new System.Drawing.Point(119, 565);
            this.cmbBenutzer.Name = "cmbBenutzer";
            this.cmbBenutzer.Size = new System.Drawing.Size(340, 24);
            this.cmbBenutzer.TabIndex = 1;
            this.cmbBenutzer.Visible = false;
            this.cmbBenutzer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblErstKontakt
            // 
            appearance135.BackColor = System.Drawing.Color.Transparent;
            this.lblErstKontakt.Appearance = appearance135;
            this.lblErstKontakt.AutoSize = true;
            this.lblErstKontakt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Strikeout);
            this.lblErstKontakt.Location = new System.Drawing.Point(14, 569);
            this.lblErstKontakt.Name = "lblErstKontakt";
            this.lblErstKontakt.Size = new System.Drawing.Size(74, 17);
            this.lblErstKontakt.TabIndex = 56;
            this.lblErstKontakt.Text = "Erstkontakt";
            this.lblErstKontakt.Visible = false;
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.ultraGroupBoxAdressdatenNWS);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(477, 592);
            // 
            // ultraGroupBoxAdressdatenNWS
            // 
            appearance60.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBoxAdressdatenNWS.Appearance = appearance60;
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtLandNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblLandSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblEMailSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtEmailNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblMobilSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtMobilNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtTelefonNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblTelefonSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblOrtSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtOrtNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblPLZSub);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtPLZNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtStrasseNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblAdresse);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.txtFaxNWS);
            this.ultraGroupBoxAdressdatenNWS.Controls.Add(this.lblFaxSub);
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
            this.txtLandNWS.AutoOpenCBO = false;
            this.txtLandNWS.BerufsstandGruppeJNA = -1;
            this.txtLandNWS.ExactMatch = false;
            this.txtLandNWS.Group = "LND";
            this.txtLandNWS.IgnoreUnterdruecken = true;
            this.txtLandNWS.Location = new System.Drawing.Point(203, 89);
            this.txtLandNWS.MaxLength = 20;
            this.txtLandNWS.Name = "txtLandNWS";
            this.txtLandNWS.PflichtJN = false;
            this.txtLandNWS.SelectDistinct = false;
            this.txtLandNWS.ShowAddButton = true;
            this.txtLandNWS.Size = new System.Drawing.Size(250, 24);
            this.txtLandNWS.sys = false;
            this.txtLandNWS.TabIndex = 5;
            this.txtLandNWS.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblLandSub
            // 
            appearance61.BackColor = System.Drawing.Color.Transparent;
            this.lblLandSub.Appearance = appearance61;
            this.lblLandSub.AutoSize = true;
            this.lblLandSub.Location = new System.Drawing.Point(168, 93);
            this.lblLandSub.Name = "lblLandSub";
            this.lblLandSub.Size = new System.Drawing.Size(35, 17);
            this.lblLandSub.TabIndex = 121;
            this.lblLandSub.Text = "Land";
            // 
            // lblEMailSub
            // 
            appearance62.BackColor = System.Drawing.Color.Transparent;
            this.lblEMailSub.Appearance = appearance62;
            this.lblEMailSub.AutoSize = true;
            this.lblEMailSub.Location = new System.Drawing.Point(259, 179);
            this.lblEMailSub.Name = "lblEMailSub";
            this.lblEMailSub.Size = new System.Drawing.Size(39, 17);
            this.lblEMailSub.TabIndex = 60;
            this.lblEMailSub.Text = "Email";
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
            // lblMobilSub
            // 
            appearance63.BackColor = System.Drawing.Color.Transparent;
            this.lblMobilSub.Appearance = appearance63;
            this.lblMobilSub.AutoSize = true;
            this.lblMobilSub.Location = new System.Drawing.Point(259, 149);
            this.lblMobilSub.Name = "lblMobilSub";
            this.lblMobilSub.Size = new System.Drawing.Size(38, 17);
            this.lblMobilSub.TabIndex = 58;
            this.lblMobilSub.Text = "Mobil";
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
            // lblTelefonSub
            // 
            appearance64.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefonSub.Appearance = appearance64;
            this.lblTelefonSub.AutoSize = true;
            this.lblTelefonSub.Location = new System.Drawing.Point(15, 149);
            this.lblTelefonSub.Name = "lblTelefonSub";
            this.lblTelefonSub.Size = new System.Drawing.Size(51, 17);
            this.lblTelefonSub.TabIndex = 52;
            this.lblTelefonSub.Text = "Telefon";
            // 
            // lblOrtSub
            // 
            appearance65.BackColor = System.Drawing.Color.Transparent;
            this.lblOrtSub.Appearance = appearance65;
            this.lblOrtSub.AutoSize = true;
            this.lblOrtSub.Location = new System.Drawing.Point(168, 63);
            this.lblOrtSub.Name = "lblOrtSub";
            this.lblOrtSub.Size = new System.Drawing.Size(24, 17);
            this.lblOrtSub.TabIndex = 50;
            this.lblOrtSub.Text = "Ort";
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
            // lblPLZSub
            // 
            appearance66.BackColor = System.Drawing.Color.Transparent;
            this.lblPLZSub.Appearance = appearance66;
            this.lblPLZSub.AutoSize = true;
            this.lblPLZSub.Location = new System.Drawing.Point(14, 63);
            this.lblPLZSub.Name = "lblPLZSub";
            this.lblPLZSub.Size = new System.Drawing.Size(30, 17);
            this.lblPLZSub.TabIndex = 48;
            this.lblPLZSub.Text = "PLZ";
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
            // lblAdresse
            // 
            appearance67.BackColor = System.Drawing.Color.Transparent;
            this.lblAdresse.Appearance = appearance67;
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Location = new System.Drawing.Point(15, 33);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(52, 17);
            this.lblAdresse.TabIndex = 46;
            this.lblAdresse.Text = "Strasse";
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
            // lblFaxSub
            // 
            appearance68.BackColor = System.Drawing.Color.Transparent;
            this.lblFaxSub.Appearance = appearance68;
            this.lblFaxSub.AutoSize = true;
            this.lblFaxSub.Location = new System.Drawing.Point(15, 179);
            this.lblFaxSub.Name = "lblFaxSub";
            this.lblFaxSub.Size = new System.Drawing.Size(28, 17);
            this.lblFaxSub.TabIndex = 54;
            this.lblFaxSub.Text = "Fax";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.AutoScroll = true;
            this.ultraTabPageControl2.Controls.Add(this.grpAdmin);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxOben);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxAllgemein1);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBoxPersonebescheibung);
            this.ultraTabPageControl2.Controls.Add(this.lblVorname);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1028, 673);
            this.ultraTabPageControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.ultraTabPageControl2_Paint);
            // 
            // grpAdmin
            // 
            this.grpAdmin.Controls.Add(this.lblSTAMPSynonym);
            this.grpAdmin.Controls.Add(this.txtSTAMPSynonym);
            this.grpAdmin.Controls.Add(this.chkELGAAbgemeldet);
            this.grpAdmin.Controls.Add(this.panelAufenthaltsdaten2);
            this.grpAdmin.Controls.Add(this.chkMilieubetreuung);
            this.grpAdmin.Controls.Add(this.chkAbwesenheitBeendet);
            this.grpAdmin.Controls.Add(this.txtKennwort);
            this.grpAdmin.Controls.Add(this.lblKennwort);
            this.grpAdmin.Controls.Add(this.baseLabel4);
            this.grpAdmin.Controls.Add(this.txtbPK);
            this.grpAdmin.Location = new System.Drawing.Point(503, 410);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(519, 239);
            this.grpAdmin.TabIndex = 222;
            this.grpAdmin.Text = "Administrative Daten";
            // 
            // lblSTAMPSynonym
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.lblSTAMPSynonym.Appearance = appearance8;
            this.lblSTAMPSynonym.AutoSize = true;
            this.lblSTAMPSynonym.Location = new System.Drawing.Point(16, 153);
            this.lblSTAMPSynonym.Name = "lblSTAMPSynonym";
            this.lblSTAMPSynonym.Size = new System.Drawing.Size(71, 17);
            this.lblSTAMPSynonym.TabIndex = 216;
            this.lblSTAMPSynonym.Text = "STAMP-ID";
            ultraToolTipInfo1.ToolTipText = "Bereichsspezifisches Personenkennzeichen";
            this.ultraToolTipManager1.SetUltraToolTip(this.lblSTAMPSynonym, ultraToolTipInfo1);
            // 
            // txtSTAMPSynonym
            // 
            this.errorProvider1.SetIconAlignment(this.txtSTAMPSynonym, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtSTAMPSynonym.Location = new System.Drawing.Point(121, 149);
            this.txtSTAMPSynonym.MaxLength = 25;
            this.txtSTAMPSynonym.Name = "txtSTAMPSynonym";
            this.txtSTAMPSynonym.Size = new System.Drawing.Size(217, 24);
            this.txtSTAMPSynonym.TabIndex = 20;
            this.txtSTAMPSynonym.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkELGAAbgemeldet
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.chkELGAAbgemeldet.Appearance = appearance9;
            this.chkELGAAbgemeldet.BackColor = System.Drawing.Color.Transparent;
            this.chkELGAAbgemeldet.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkELGAAbgemeldet.Location = new System.Drawing.Point(358, 115);
            this.chkELGAAbgemeldet.Name = "chkELGAAbgemeldet";
            this.chkELGAAbgemeldet.Size = new System.Drawing.Size(137, 20);
            this.chkELGAAbgemeldet.TabIndex = 19;
            this.chkELGAAbgemeldet.Text = "ELGA abgemeldet";
            // 
            // panelAufenthaltsdaten2
            // 
            this.panelAufenthaltsdaten2.Controls.Add(this.btnAbwesenheitsendeBestätigen);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtZimmerNr);
            this.panelAufenthaltsdaten2.Controls.Add(this.lblZimNr);
            this.panelAufenthaltsdaten2.Controls.Add(this.lblGruppenKz);
            this.panelAufenthaltsdaten2.Controls.Add(this.lblFallzahl);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtFallzahl);
            this.panelAufenthaltsdaten2.Controls.Add(this.txtgruppenkennzahl);
            this.panelAufenthaltsdaten2.Location = new System.Drawing.Point(3, 18);
            this.panelAufenthaltsdaten2.Name = "panelAufenthaltsdaten2";
            this.panelAufenthaltsdaten2.Size = new System.Drawing.Size(509, 61);
            this.panelAufenthaltsdaten2.TabIndex = 14;
            // 
            // btnAbwesenheitsendeBestätigen
            // 
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.btnAbwesenheitsendeBestätigen.Appearance = appearance10;
            this.btnAbwesenheitsendeBestätigen.Location = new System.Drawing.Point(235, 35);
            this.btnAbwesenheitsendeBestätigen.Name = "btnAbwesenheitsendeBestätigen";
            this.btnAbwesenheitsendeBestätigen.Size = new System.Drawing.Size(270, 26);
            this.btnAbwesenheitsendeBestätigen.TabIndex = 17;
            this.btnAbwesenheitsendeBestätigen.Tag = "";
            this.btnAbwesenheitsendeBestätigen.Text = "Abwesenheitsende bestätigen";
            this.btnAbwesenheitsendeBestätigen.Click += new System.EventHandler(this.btnAbwesenheitsendeBestätigen_Click);
            // 
            // txtZimmerNr
            // 
            this.txtZimmerNr.Location = new System.Drawing.Point(119, 36);
            this.txtZimmerNr.MaxLength = 5;
            this.txtZimmerNr.Name = "txtZimmerNr";
            this.txtZimmerNr.Size = new System.Drawing.Size(97, 24);
            this.txtZimmerNr.TabIndex = 16;
            this.txtZimmerNr.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblZimNr
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.lblZimNr.Appearance = appearance11;
            this.lblZimNr.AutoSize = true;
            this.lblZimNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblZimNr.Location = new System.Drawing.Point(13, 40);
            this.lblZimNr.Name = "lblZimNr";
            this.lblZimNr.Size = new System.Drawing.Size(70, 17);
            this.lblZimNr.TabIndex = 101;
            this.lblZimNr.Text = "Zimmer.Nr";
            // 
            // lblGruppenKz
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.lblGruppenKz.Appearance = appearance12;
            this.lblGruppenKz.AutoSize = true;
            this.lblGruppenKz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGruppenKz.Location = new System.Drawing.Point(235, 10);
            this.lblGruppenKz.Name = "lblGruppenKz";
            this.lblGruppenKz.Size = new System.Drawing.Size(113, 17);
            this.lblGruppenKz.TabIndex = 97;
            this.lblGruppenKz.Text = "Gruppenkennzahl";
            // 
            // lblFallzahl
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.lblFallzahl.Appearance = appearance13;
            this.lblFallzahl.AutoSize = true;
            this.lblFallzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFallzahl.Location = new System.Drawing.Point(13, 11);
            this.lblFallzahl.Name = "lblFallzahl";
            this.lblFallzahl.Size = new System.Drawing.Size(53, 17);
            this.lblFallzahl.TabIndex = 25;
            this.lblFallzahl.Text = "Fallzahl";
            // 
            // txtFallzahl
            // 
            this.txtFallzahl.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtFallzahl.Location = new System.Drawing.Point(119, 7);
            this.txtFallzahl.Name = "txtFallzahl";
            this.txtFallzahl.NonAutoSizeHeight = 20;
            this.txtFallzahl.Size = new System.Drawing.Size(98, 23);
            this.txtFallzahl.TabIndex = 13;
            this.txtFallzahl.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtgruppenkennzahl
            // 
            this.txtgruppenkennzahl.Location = new System.Drawing.Point(355, 7);
            this.txtgruppenkennzahl.MaxLength = 20;
            this.txtgruppenkennzahl.Name = "txtgruppenkennzahl";
            this.txtgruppenkennzahl.Size = new System.Drawing.Size(150, 24);
            this.txtgruppenkennzahl.TabIndex = 14;
            this.txtgruppenkennzahl.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkMilieubetreuung
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.FontData.StrikeoutAsString = "True";
            appearance14.TextVAlignAsString = "Middle";
            this.chkMilieubetreuung.Appearance = appearance14;
            this.chkMilieubetreuung.BackColor = System.Drawing.Color.Transparent;
            this.chkMilieubetreuung.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkMilieubetreuung.Location = new System.Drawing.Point(13, 212);
            this.chkMilieubetreuung.Name = "chkMilieubetreuung";
            this.chkMilieubetreuung.Size = new System.Drawing.Size(124, 20);
            this.chkMilieubetreuung.TabIndex = 21;
            this.chkMilieubetreuung.Text = "Milieubetreuung";
            this.chkMilieubetreuung.Visible = false;
            this.chkMilieubetreuung.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkAbwesenheitBeendet
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.FontData.StrikeoutAsString = "True";
            appearance15.TextVAlignAsString = "Middle";
            this.chkAbwesenheitBeendet.Appearance = appearance15;
            this.chkAbwesenheitBeendet.BackColor = System.Drawing.Color.Transparent;
            this.chkAbwesenheitBeendet.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkAbwesenheitBeendet.Location = new System.Drawing.Point(171, 214);
            this.chkAbwesenheitBeendet.Name = "chkAbwesenheitBeendet";
            this.chkAbwesenheitBeendet.Size = new System.Drawing.Size(205, 18);
            this.chkAbwesenheitBeendet.TabIndex = 22;
            this.chkAbwesenheitBeendet.Text = "Abwesenheitsende bestätigen";
            this.chkAbwesenheitBeendet.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtKennwort
            // 
            this.txtKennwort.Location = new System.Drawing.Point(121, 84);
            this.txtKennwort.MaxLength = 20;
            this.txtKennwort.Name = "txtKennwort";
            this.txtKennwort.Size = new System.Drawing.Size(386, 24);
            this.txtKennwort.TabIndex = 15;
            this.txtKennwort.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKennwort
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.lblKennwort.Appearance = appearance16;
            this.lblKennwort.AutoSize = true;
            this.lblKennwort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKennwort.Location = new System.Drawing.Point(13, 88);
            this.lblKennwort.Name = "lblKennwort";
            this.lblKennwort.Size = new System.Drawing.Size(63, 17);
            this.lblKennwort.TabIndex = 100;
            this.lblKennwort.Text = "Kennwort";
            // 
            // baseLabel4
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel4.Appearance = appearance17;
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Location = new System.Drawing.Point(16, 118);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(44, 17);
            this.baseLabel4.TabIndex = 214;
            this.baseLabel4.Text = "bPK/S";
            ultraToolTipInfo2.ToolTipText = "Bereichsspezifisches Personenkennzeichen";
            this.ultraToolTipManager1.SetUltraToolTip(this.baseLabel4, ultraToolTipInfo2);
            // 
            // txtbPK
            // 
            this.errorProvider1.SetIconAlignment(this.txtbPK, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtbPK.Location = new System.Drawing.Point(121, 114);
            this.txtbPK.MaxLength = 25;
            this.txtbPK.Name = "txtbPK";
            this.txtbPK.Size = new System.Drawing.Size(217, 24);
            this.txtbPK.TabIndex = 20;
            this.txtbPK.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxOben
            // 
            this.ultraGroupBoxOben.Controls.Add(this.lbleMailKlient);
            this.ultraGroupBoxOben.Controls.Add(this.lblMobilTelNrKlient);
            this.ultraGroupBoxOben.Controls.Add(this.lblEMailPat);
            this.ultraGroupBoxOben.Controls.Add(this.lblTitelPost);
            this.ultraGroupBoxOben.Controls.Add(this.cboTitelPost);
            this.ultraGroupBoxOben.Controls.Add(this.lblMobilTel);
            this.ultraGroupBoxOben.Controls.Add(this.panelVerstorben);
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
            this.ultraGroupBoxOben.Controls.Add(this.lblVorname2);
            this.ultraGroupBoxOben.Controls.Add(this.lblTitel);
            this.ultraGroupBoxOben.Controls.Add(this.lblNachname);
            this.ultraGroupBoxOben.Controls.Add(this.lblAkdGrad);
            this.ultraGroupBoxOben.Controls.Add(this.lblGebDat);
            this.ultraGroupBoxOben.Controls.Add(this.lblGeschl);
            this.ultraGroupBoxOben.Controls.Add(this.gebDatum);
            this.ultraGroupBoxOben.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxOben.Location = new System.Drawing.Point(3, 5);
            this.ultraGroupBoxOben.Name = "ultraGroupBoxOben";
            this.ultraGroupBoxOben.Size = new System.Drawing.Size(494, 340);
            this.ultraGroupBoxOben.TabIndex = 90;
            this.ultraGroupBoxOben.Text = "Personendaten";
            // 
            // lbleMailKlient
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbleMailKlient.Appearance = appearance18;
            this.lbleMailKlient.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lbleMailKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbleMailKlient.Location = new System.Drawing.Point(90, 271);
            this.lbleMailKlient.Name = "lbleMailKlient";
            this.lbleMailKlient.Size = new System.Drawing.Size(392, 24);
            this.lbleMailKlient.TabIndex = 220;
            // 
            // lblMobilTelNrKlient
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            appearance19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMobilTelNrKlient.Appearance = appearance19;
            this.lblMobilTelNrKlient.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblMobilTelNrKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMobilTelNrKlient.Location = new System.Drawing.Point(90, 241);
            this.lblMobilTelNrKlient.Name = "lblMobilTelNrKlient";
            this.lblMobilTelNrKlient.Size = new System.Drawing.Size(392, 24);
            this.lblMobilTelNrKlient.TabIndex = 218;
            this.lblMobilTelNrKlient.Text = "                                                             ";
            // 
            // lblEMailPat
            // 
            appearance20.BackColor = System.Drawing.Color.Transparent;
            this.lblEMailPat.Appearance = appearance20;
            this.lblEMailPat.AutoSize = true;
            this.lblEMailPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEMailPat.Location = new System.Drawing.Point(18, 278);
            this.lblEMailPat.Name = "lblEMailPat";
            this.lblEMailPat.Size = new System.Drawing.Size(38, 17);
            this.lblEMailPat.TabIndex = 219;
            this.lblEMailPat.Text = "eMail";
            // 
            // lblTitelPost
            // 
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.lblTitelPost.Appearance = appearance21;
            this.lblTitelPost.AutoSize = true;
            this.lblTitelPost.Location = new System.Drawing.Point(235, 154);
            this.lblTitelPost.Name = "lblTitelPost";
            this.lblTitelPost.Size = new System.Drawing.Size(67, 17);
            this.lblTitelPost.TabIndex = 212;
            this.lblTitelPost.Text = "Titel nach.";
            // 
            // cboTitelPost
            // 
            this.cboTitelPost.AddEmptyEntry = false;
            this.cboTitelPost.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cboTitelPost.AutoOpenCBO = true;
            this.cboTitelPost.BerufsstandGruppeJNA = -1;
            this.cboTitelPost.ExactMatch = false;
            this.cboTitelPost.Group = "TTP";
            this.cboTitelPost.IgnoreUnterdruecken = true;
            this.cboTitelPost.Location = new System.Drawing.Point(309, 151);
            this.cboTitelPost.MaxLength = 40;
            this.cboTitelPost.Name = "cboTitelPost";
            this.cboTitelPost.PflichtJN = false;
            this.cboTitelPost.SelectDistinct = false;
            this.cboTitelPost.ShowAddButton = true;
            this.cboTitelPost.Size = new System.Drawing.Size(173, 24);
            this.cboTitelPost.sys = false;
            this.cboTitelPost.TabIndex = 8;
            this.cboTitelPost.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblMobilTel
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.lblMobilTel.Appearance = appearance22;
            this.lblMobilTel.AutoSize = true;
            this.lblMobilTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMobilTel.Location = new System.Drawing.Point(16, 246);
            this.lblMobilTel.Name = "lblMobilTel";
            this.lblMobilTel.Size = new System.Drawing.Size(65, 17);
            this.lblMobilTel.TabIndex = 217;
            this.lblMobilTel.Text = "Mobil-Tel.";
            // 
            // panelVerstorben
            // 
            this.panelVerstorben.BackColor = System.Drawing.Color.Transparent;
            this.panelVerstorben.Controls.Add(this.dteTodeszeitpunkt);
            this.panelVerstorben.Controls.Add(this.lblTodeszeitpunkt);
            this.panelVerstorben.Controls.Add(this.chkVerstorben);
            this.panelVerstorben.Location = new System.Drawing.Point(90, 301);
            this.panelVerstorben.Name = "panelVerstorben";
            this.panelVerstorben.Size = new System.Drawing.Size(392, 30);
            this.panelVerstorben.TabIndex = 13;
            // 
            // dteTodeszeitpunkt
            // 
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BackColor2 = System.Drawing.Color.White;
            appearance23.BackColorDisabled = System.Drawing.Color.White;
            appearance23.BackColorDisabled2 = System.Drawing.Color.White;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.dteTodeszeitpunkt.Appearance = appearance23;
            this.dteTodeszeitpunkt.BackColor = System.Drawing.Color.White;
            this.dteTodeszeitpunkt.DateTime = new System.DateTime(2017, 6, 19, 0, 0, 0, 0);
            this.dteTodeszeitpunkt.FormatString = "";
            this.dteTodeszeitpunkt.Location = new System.Drawing.Point(256, 4);
            this.dteTodeszeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dteTodeszeitpunkt.Name = "dteTodeszeitpunkt";
            this.dteTodeszeitpunkt.ownFormat = "";
            this.dteTodeszeitpunkt.ownMaskInput = "";
            this.dteTodeszeitpunkt.Size = new System.Drawing.Size(136, 24);
            this.dteTodeszeitpunkt.TabIndex = 2;
            this.dteTodeszeitpunkt.Value = new System.DateTime(2017, 6, 19, 0, 0, 0, 0);
            this.dteTodeszeitpunkt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblTodeszeitpunkt
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.lblTodeszeitpunkt.Appearance = appearance24;
            this.lblTodeszeitpunkt.AutoSize = true;
            this.lblTodeszeitpunkt.Location = new System.Drawing.Point(145, 8);
            this.lblTodeszeitpunkt.Name = "lblTodeszeitpunkt";
            this.lblTodeszeitpunkt.Size = new System.Drawing.Size(96, 17);
            this.lblTodeszeitpunkt.TabIndex = 108;
            this.lblTodeszeitpunkt.Text = "Todeszeitpunkt";
            // 
            // chkVerstorben
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.Appearance = appearance25;
            this.chkVerstorben.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkVerstorben.Location = new System.Drawing.Point(3, 7);
            this.chkVerstorben.Name = "chkVerstorben";
            this.chkVerstorben.Size = new System.Drawing.Size(87, 20);
            this.chkVerstorben.TabIndex = 1;
            this.chkVerstorben.Text = "Verstorben";
            this.chkVerstorben.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbStaatsB
            // 
            this.cmbStaatsB.AddEmptyEntry = false;
            this.cmbStaatsB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaatsB.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbStaatsB.AutoOpenCBO = true;
            this.cmbStaatsB.BerufsstandGruppeJNA = -1;
            this.cmbStaatsB.ExactMatch = false;
            this.cmbStaatsB.Group = "SBS";
            this.cmbStaatsB.IgnoreUnterdruecken = true;
            this.cmbStaatsB.Location = new System.Drawing.Point(309, 181);
            this.cmbStaatsB.MaxLength = 255;
            this.cmbStaatsB.Name = "cmbStaatsB";
            this.cmbStaatsB.PflichtJN = false;
            this.cmbStaatsB.SelectDistinct = false;
            this.cmbStaatsB.ShowAddButton = true;
            this.cmbStaatsB.Size = new System.Drawing.Size(173, 24);
            this.cmbStaatsB.sys = false;
            this.cmbStaatsB.TabIndex = 10;
            this.cmbStaatsB.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAkdGrad
            // 
            this.cmbAkdGrad.AddEmptyEntry = false;
            this.cmbAkdGrad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAkdGrad.AutoOpenCBO = true;
            this.cmbAkdGrad.BerufsstandGruppeJNA = -1;
            this.cmbAkdGrad.ExactMatch = false;
            this.cmbAkdGrad.Group = "TIT";
            this.cmbAkdGrad.IgnoreUnterdruecken = true;
            this.cmbAkdGrad.Location = new System.Drawing.Point(90, 151);
            this.cmbAkdGrad.MaxLength = 40;
            this.cmbAkdGrad.Name = "cmbAkdGrad";
            this.cmbAkdGrad.PflichtJN = false;
            this.cmbAkdGrad.SelectDistinct = false;
            this.cmbAkdGrad.ShowAddButton = true;
            this.cmbAkdGrad.Size = new System.Drawing.Size(139, 24);
            this.cmbAkdGrad.sys = false;
            this.cmbAkdGrad.TabIndex = 7;
            this.cmbAkdGrad.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbKonfession
            // 
            this.cmbKonfession.AddEmptyEntry = false;
            this.cmbKonfession.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbKonfession.AutoOpenCBO = true;
            this.cmbKonfession.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbKonfession.BerufsstandGruppeJNA = -1;
            this.cmbKonfession.ExactMatch = false;
            this.cmbKonfession.Group = "KON";
            this.cmbKonfession.IgnoreUnterdruecken = true;
            this.cmbKonfession.Location = new System.Drawing.Point(90, 211);
            this.cmbKonfession.MaxLength = 255;
            this.cmbKonfession.Name = "cmbKonfession";
            this.cmbKonfession.PflichtJN = false;
            this.cmbKonfession.SelectDistinct = false;
            this.cmbKonfession.ShowAddButton = true;
            this.cmbKonfession.Size = new System.Drawing.Size(392, 24);
            this.cmbKonfession.sys = false;
            this.cmbKonfession.TabIndex = 11;
            this.cmbKonfession.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAnrede
            // 
            this.cmbAnrede.AddEmptyEntry = false;
            this.cmbAnrede.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAnrede.AutoOpenCBO = true;
            this.cmbAnrede.BerufsstandGruppeJNA = -1;
            this.cmbAnrede.ExactMatch = false;
            this.cmbAnrede.Group = "ANR";
            this.cmbAnrede.IgnoreUnterdruecken = true;
            this.cmbAnrede.Location = new System.Drawing.Point(309, 89);
            this.cmbAnrede.MaxLength = 15;
            this.cmbAnrede.Name = "cmbAnrede";
            this.cmbAnrede.PflichtJN = false;
            this.cmbAnrede.SelectDistinct = false;
            this.cmbAnrede.ShowAddButton = true;
            this.cmbAnrede.Size = new System.Drawing.Size(173, 24);
            this.cmbAnrede.sys = false;
            this.cmbAnrede.TabIndex = 4;
            this.cmbAnrede.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStatsB
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsB.Appearance = appearance26;
            this.lblStatsB.AutoSize = true;
            this.lblStatsB.Location = new System.Drawing.Point(235, 185);
            this.lblStatsB.Name = "lblStatsB";
            this.lblStatsB.Size = new System.Drawing.Size(61, 17);
            this.lblStatsB.TabIndex = 94;
            this.lblStatsB.Text = "Staatsbg.";
            // 
            // cmbFAM
            // 
            this.cmbFAM.AddEmptyEntry = false;
            this.cmbFAM.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbFAM.AutoOpenCBO = false;
            this.cmbFAM.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbFAM.BerufsstandGruppeJNA = -1;
            this.cmbFAM.ExactMatch = false;
            this.cmbFAM.Group = "FAM";
            this.cmbFAM.IgnoreUnterdruecken = true;
            this.cmbFAM.Location = new System.Drawing.Point(90, 181);
            this.cmbFAM.MaxLength = 15;
            this.cmbFAM.Name = "cmbFAM";
            this.cmbFAM.PflichtJN = false;
            this.cmbFAM.SelectDistinct = false;
            this.cmbFAM.ShowAddButton = true;
            this.cmbFAM.Size = new System.Drawing.Size(139, 24);
            this.cmbFAM.sys = false;
            this.cmbFAM.TabIndex = 9;
            this.cmbFAM.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtVorname
            // 
            this.errorProvider1.SetIconAlignment(this.txtVorname, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtVorname.Location = new System.Drawing.Point(90, 59);
            this.txtVorname.MaxLength = 25;
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(392, 24);
            this.txtVorname.TabIndex = 2;
            this.txtVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblKonf
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.lblKonf.Appearance = appearance27;
            this.lblKonf.AutoSize = true;
            this.lblKonf.Location = new System.Drawing.Point(14, 215);
            this.lblKonf.Name = "lblKonf";
            this.lblKonf.Size = new System.Drawing.Size(71, 17);
            this.lblKonf.TabIndex = 95;
            this.lblKonf.Text = "Konfession";
            // 
            // cmbSexus
            // 
            this.cmbSexus.AddEmptyEntry = false;
            this.cmbSexus.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbSexus.AutoOpenCBO = true;
            this.cmbSexus.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbSexus.BerufsstandGruppeJNA = -1;
            this.cmbSexus.ExactMatch = false;
            this.cmbSexus.Group = "SEX";
            this.cmbSexus.IgnoreUnterdruecken = true;
            this.cmbSexus.Location = new System.Drawing.Point(90, 89);
            this.cmbSexus.MaxLength = 15;
            this.cmbSexus.Name = "cmbSexus";
            this.cmbSexus.PflichtJN = false;
            this.cmbSexus.SelectDistinct = false;
            this.cmbSexus.ShowAddButton = true;
            this.cmbSexus.Size = new System.Drawing.Size(139, 24);
            this.cmbSexus.sys = false;
            this.cmbSexus.TabIndex = 3;
            this.cmbSexus.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtNachname
            // 
            appearance28.FontData.BoldAsString = "True";
            appearance28.ForeColor = System.Drawing.Color.Red;
            this.txtNachname.Appearance = appearance28;
            this.errorProvider1.SetIconAlignment(this.txtNachname, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtNachname.Location = new System.Drawing.Point(90, 29);
            this.txtNachname.MaxLength = 25;
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(392, 24);
            this.txtNachname.TabIndex = 1;
            this.txtNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblFamiliensst
            // 
            appearance29.BackColor = System.Drawing.Color.Transparent;
            this.lblFamiliensst.Appearance = appearance29;
            this.lblFamiliensst.AutoSize = true;
            this.lblFamiliensst.Location = new System.Drawing.Point(14, 185);
            this.lblFamiliensst.Name = "lblFamiliensst";
            this.lblFamiliensst.Size = new System.Drawing.Size(74, 17);
            this.lblFamiliensst.TabIndex = 96;
            this.lblFamiliensst.Text = "Fam. Stand";
            // 
            // lblVorname2
            // 
            appearance30.BackColor = System.Drawing.Color.Transparent;
            this.lblVorname2.Appearance = appearance30;
            this.lblVorname2.AutoSize = true;
            this.lblVorname2.Location = new System.Drawing.Point(14, 63);
            this.lblVorname2.Name = "lblVorname2";
            this.lblVorname2.Size = new System.Drawing.Size(59, 17);
            this.lblVorname2.TabIndex = 94;
            this.lblVorname2.Text = "Vorname";
            // 
            // lblTitel
            // 
            appearance31.BackColor = System.Drawing.Color.Transparent;
            this.lblTitel.Appearance = appearance31;
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(235, 93);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(48, 17);
            this.lblTitel.TabIndex = 89;
            this.lblTitel.Text = "Anrede";
            // 
            // lblNachname
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.lblNachname.Appearance = appearance32;
            this.lblNachname.AutoSize = true;
            this.lblNachname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNachname.Location = new System.Drawing.Point(14, 29);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(70, 17);
            this.lblNachname.TabIndex = 91;
            this.lblNachname.Text = "Nachname";
            // 
            // lblAkdGrad
            // 
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.lblAkdGrad.Appearance = appearance33;
            this.lblAkdGrad.AutoSize = true;
            this.lblAkdGrad.Location = new System.Drawing.Point(16, 155);
            this.lblAkdGrad.Name = "lblAkdGrad";
            this.lblAkdGrad.Size = new System.Drawing.Size(56, 17);
            this.lblAkdGrad.TabIndex = 90;
            this.lblAkdGrad.Text = "Titel vor.";
            // 
            // lblGebDat
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.lblGebDat.Appearance = appearance34;
            this.lblGebDat.AutoSize = true;
            this.lblGebDat.Location = new System.Drawing.Point(14, 124);
            this.lblGebDat.Name = "lblGebDat";
            this.lblGebDat.Size = new System.Drawing.Size(62, 17);
            this.lblGebDat.TabIndex = 87;
            this.lblGebDat.Text = "Geb. Dat.";
            // 
            // lblGeschl
            // 
            appearance35.BackColor = System.Drawing.Color.Transparent;
            this.lblGeschl.Appearance = appearance35;
            this.lblGeschl.AutoSize = true;
            this.lblGeschl.Location = new System.Drawing.Point(14, 93);
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
            this.gebDatum.Location = new System.Drawing.Point(90, 120);
            this.gebDatum.MaskInput = "";
            this.gebDatum.Name = "gebDatum";
            this.gebDatum.ownFormat = "";
            this.gebDatum.ownMaskInput = "";
            this.gebDatum.Size = new System.Drawing.Size(139, 24);
            this.gebDatum.TabIndex = 5;
            this.gebDatum.Value = null;
            this.gebDatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxAllgemein1
            // 
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblDNRAnmerkung);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtDNRAnmerkung);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblPatientenverfügung);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.chkAnatomie);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.chkDatenschutz);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblSprachen);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblBeruf);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.cboSprachenMulti);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.chkPalliativ);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtBeruf);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtGebOrt);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblGebOrt);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtGebName);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.chkKZUeberlebender);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblGebName);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.chkDNR);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.lblInitBer);
            this.ultraGroupBoxAllgemein1.Controls.Add(this.txtInitialBer);
            this.ultraGroupBoxAllgemein1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxAllgemein1.Location = new System.Drawing.Point(503, 5);
            this.ultraGroupBoxAllgemein1.Name = "ultraGroupBoxAllgemein1";
            this.ultraGroupBoxAllgemein1.Size = new System.Drawing.Size(521, 397);
            this.ultraGroupBoxAllgemein1.TabIndex = 91;
            this.ultraGroupBoxAllgemein1.Text = "Zusätzliche Daten, Wünsche, Kenntnisse";
            // 
            // lblDNRAnmerkung
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            this.lblDNRAnmerkung.Appearance = appearance36;
            this.lblDNRAnmerkung.Location = new System.Drawing.Point(11, 274);
            this.lblDNRAnmerkung.Name = "lblDNRAnmerkung";
            this.lblDNRAnmerkung.Size = new System.Drawing.Size(104, 37);
            this.lblDNRAnmerkung.TabIndex = 216;
            this.lblDNRAnmerkung.Text = "DNR / Palliativ Anmerkung";
            // 
            // txtDNRAnmerkung
            // 
            this.txtDNRAnmerkung.AcceptsReturn = true;
            this.txtDNRAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDNRAnmerkung.Location = new System.Drawing.Point(121, 271);
            this.txtDNRAnmerkung.MaxLength = 2000;
            this.txtDNRAnmerkung.Multiline = true;
            this.txtDNRAnmerkung.Name = "txtDNRAnmerkung";
            this.txtDNRAnmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDNRAnmerkung.Size = new System.Drawing.Size(386, 93);
            this.txtDNRAnmerkung.TabIndex = 8;
            this.txtDNRAnmerkung.ValueChanged += new System.EventHandler(this.txtDNRAnmerkung_ValueChanged);
            // 
            // lblPatientenverfügung
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            appearance37.ForeColor = System.Drawing.Color.Red;
            this.lblPatientenverfügung.Appearance = appearance37;
            this.lblPatientenverfügung.AutoSize = true;
            this.lblPatientenverfügung.Location = new System.Drawing.Point(315, 248);
            this.lblPatientenverfügung.Name = "lblPatientenverfügung";
            this.lblPatientenverfügung.Size = new System.Drawing.Size(192, 17);
            this.lblPatientenverfügung.TabIndex = 97;
            this.lblPatientenverfügung.Text = "Patientenverfügung vorhanden!";
            this.lblPatientenverfügung.Click += new System.EventHandler(this.lblPatientenverfügung_Click);
            this.lblPatientenverfügung.MouseEnter += new System.EventHandler(this.lblPatientenverfügung_MouseEnter);
            this.lblPatientenverfügung.MouseLeave += new System.EventHandler(this.lblPatientenverfügung_MouseLeave);
            this.lblPatientenverfügung.MouseHover += new System.EventHandler(this.lblPatientenverfügung_MouseHover);
            // 
            // chkAnatomie
            // 
            appearance38.BackColor = System.Drawing.Color.Transparent;
            appearance38.TextVAlignAsString = "Middle";
            this.chkAnatomie.Appearance = appearance38;
            this.chkAnatomie.BackColor = System.Drawing.Color.Transparent;
            this.chkAnatomie.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkAnatomie.Location = new System.Drawing.Point(228, 373);
            this.chkAnatomie.Name = "chkAnatomie";
            this.chkAnatomie.Size = new System.Drawing.Size(87, 20);
            this.chkAnatomie.TabIndex = 10;
            this.chkAnatomie.Text = "Anatomie";
            this.chkAnatomie.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkDatenschutz
            // 
            appearance39.BackColor = System.Drawing.Color.Transparent;
            appearance39.TextVAlignAsString = "Middle";
            this.chkDatenschutz.Appearance = appearance39;
            this.chkDatenschutz.BackColor = System.Drawing.Color.Transparent;
            this.chkDatenschutz.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkDatenschutz.Location = new System.Drawing.Point(121, 373);
            this.chkDatenschutz.Name = "chkDatenschutz";
            this.chkDatenschutz.Size = new System.Drawing.Size(98, 20);
            this.chkDatenschutz.TabIndex = 9;
            this.chkDatenschutz.Text = "Datenschutz";
            this.chkDatenschutz.Visible = false;
            // 
            // lblSprachen
            // 
            appearance40.BackColor = System.Drawing.Color.Transparent;
            this.lblSprachen.Appearance = appearance40;
            this.lblSprachen.AutoSize = true;
            this.lblSprachen.Location = new System.Drawing.Point(11, 121);
            this.lblSprachen.Name = "lblSprachen";
            this.lblSprachen.Size = new System.Drawing.Size(62, 17);
            this.lblSprachen.TabIndex = 99;
            this.lblSprachen.Text = "Sprachen";
            // 
            // lblBeruf
            // 
            appearance41.BackColor = System.Drawing.Color.Transparent;
            this.lblBeruf.Appearance = appearance41;
            this.lblBeruf.AutoSize = true;
            this.lblBeruf.Location = new System.Drawing.Point(11, 88);
            this.lblBeruf.Name = "lblBeruf";
            this.lblBeruf.Size = new System.Drawing.Size(37, 17);
            this.lblBeruf.TabIndex = 21;
            this.lblBeruf.Text = "Beruf";
            // 
            // cboSprachenMulti
            // 
            this.cboSprachenMulti.Location = new System.Drawing.Point(121, 114);
            this.cboSprachenMulti.Margin = new System.Windows.Forms.Padding(4);
            this.cboSprachenMulti.Name = "cboSprachenMulti";
            this.cboSprachenMulti.Size = new System.Drawing.Size(387, 26);
            this.cboSprachenMulti.TabIndex = 4;
            this.cboSprachenMulti.AfterCheck += new System.EventHandler(this.OnValueChanged);
            // 
            // chkPalliativ
            // 
            appearance42.BackColor = System.Drawing.Color.Transparent;
            this.chkPalliativ.Appearance = appearance42;
            this.chkPalliativ.BackColor = System.Drawing.Color.Transparent;
            this.chkPalliativ.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkPalliativ.Location = new System.Drawing.Point(228, 248);
            this.chkPalliativ.Name = "chkPalliativ";
            this.chkPalliativ.Size = new System.Drawing.Size(87, 20);
            this.chkPalliativ.TabIndex = 7;
            this.chkPalliativ.Text = "Palliativ";
            this.chkPalliativ.CheckedChanged += new System.EventHandler(this.chkPalliativ_CheckedChanged);
            // 
            // txtBeruf
            // 
            this.txtBeruf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeruf.Location = new System.Drawing.Point(121, 83);
            this.txtBeruf.MaxLength = 50;
            this.txtBeruf.Name = "txtBeruf";
            this.txtBeruf.Size = new System.Drawing.Size(386, 24);
            this.txtBeruf.TabIndex = 3;
            this.txtBeruf.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtGebOrt
            // 
            this.txtGebOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGebOrt.Location = new System.Drawing.Point(121, 53);
            this.txtGebOrt.MaxLength = 50;
            this.txtGebOrt.Name = "txtGebOrt";
            this.txtGebOrt.Size = new System.Drawing.Size(386, 24);
            this.txtGebOrt.TabIndex = 2;
            this.txtGebOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebOrt
            // 
            appearance43.BackColor = System.Drawing.Color.Transparent;
            this.lblGebOrt.Appearance = appearance43;
            this.lblGebOrt.AutoSize = true;
            this.lblGebOrt.Location = new System.Drawing.Point(11, 58);
            this.lblGebOrt.Name = "lblGebOrt";
            this.lblGebOrt.Size = new System.Drawing.Size(68, 17);
            this.lblGebOrt.TabIndex = 20;
            this.lblGebOrt.Text = "Geburtsort";
            // 
            // txtGebName
            // 
            this.txtGebName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGebName.Location = new System.Drawing.Point(121, 23);
            this.txtGebName.MaxLength = 50;
            this.txtGebName.Name = "txtGebName";
            this.txtGebName.Size = new System.Drawing.Size(386, 24);
            this.txtGebName.TabIndex = 1;
            this.txtGebName.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkKZUeberlebender
            // 
            appearance44.BackColor = System.Drawing.Color.Transparent;
            appearance44.TextVAlignAsString = "Middle";
            this.chkKZUeberlebender.Appearance = appearance44;
            this.chkKZUeberlebender.BackColor = System.Drawing.Color.Transparent;
            this.chkKZUeberlebender.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkKZUeberlebender.Location = new System.Drawing.Point(357, 373);
            this.chkKZUeberlebender.Name = "chkKZUeberlebender";
            this.chkKZUeberlebender.Size = new System.Drawing.Size(88, 20);
            this.chkKZUeberlebender.TabIndex = 11;
            this.chkKZUeberlebender.Text = "Holocaust";
            this.chkKZUeberlebender.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebName
            // 
            appearance45.BackColor = System.Drawing.Color.Transparent;
            this.lblGebName.Appearance = appearance45;
            this.lblGebName.AutoSize = true;
            this.lblGebName.Location = new System.Drawing.Point(11, 28);
            this.lblGebName.Name = "lblGebName";
            this.lblGebName.Size = new System.Drawing.Size(86, 17);
            this.lblGebName.TabIndex = 19;
            this.lblGebName.Text = "Geburtsname";
            // 
            // chkDNR
            // 
            appearance46.BackColor = System.Drawing.Color.Transparent;
            this.chkDNR.Appearance = appearance46;
            this.chkDNR.BackColor = System.Drawing.Color.Transparent;
            this.chkDNR.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkDNR.Location = new System.Drawing.Point(121, 247);
            this.chkDNR.Name = "chkDNR";
            this.chkDNR.Size = new System.Drawing.Size(80, 20);
            this.chkDNR.TabIndex = 6;
            this.chkDNR.Text = "DNR";
            this.chkDNR.CheckedChanged += new System.EventHandler(this.chkDNR_CheckedChanged);
            // 
            // lblInitBer
            // 
            appearance47.BackColor = System.Drawing.Color.Transparent;
            this.lblInitBer.Appearance = appearance47;
            this.lblInitBer.Location = new System.Drawing.Point(11, 151);
            this.lblInitBer.Name = "lblInitBer";
            this.lblInitBer.Size = new System.Drawing.Size(104, 20);
            this.lblInitBer.TabIndex = 24;
            this.lblInitBer.Text = "Initialberührung";
            // 
            // txtInitialBer
            // 
            this.txtInitialBer.AcceptsReturn = true;
            this.txtInitialBer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialBer.Location = new System.Drawing.Point(121, 147);
            this.txtInitialBer.MaxLength = 255;
            this.txtInitialBer.Multiline = true;
            this.txtInitialBer.Name = "txtInitialBer";
            this.txtInitialBer.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInitialBer.Size = new System.Drawing.Size(386, 95);
            this.txtInitialBer.TabIndex = 5;
            this.txtInitialBer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxPersonebescheibung
            // 
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.baseLabel3);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.btnOpenPicture);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.intAmputation_Prozent);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblAmputation_Prozent);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtGewicht);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtGroesse);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbstatur);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbHaarFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.cmbAugenFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblGewicht);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblAugenfarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblAnrede);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtBesKennz);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblHaarFarbe);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblAeussKenz);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.txtKosename);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblStatur);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblGroesse);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.Namenstag);
            this.ultraGroupBoxPersonebescheibung.Controls.Add(this.lblNamenstag);
            this.ultraGroupBoxPersonebescheibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBoxPersonebescheibung.Location = new System.Drawing.Point(3, 351);
            this.ultraGroupBoxPersonebescheibung.Name = "ultraGroupBoxPersonebescheibung";
            this.ultraGroupBoxPersonebescheibung.Size = new System.Drawing.Size(494, 298);
            this.ultraGroupBoxPersonebescheibung.TabIndex = 10;
            this.ultraGroupBoxPersonebescheibung.Text = "Personenbeschreibung";
            // 
            // baseLabel3
            // 
            appearance48.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel3.Appearance = appearance48;
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Location = new System.Drawing.Point(322, 179);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(101, 17);
            this.baseLabel3.TabIndex = 512;
            this.baseLabel3.Text = "Foto (klicken ->)";
            // 
            // btnOpenPicture
            // 
            appearance49.TextHAlignAsString = "Center";
            this.btnOpenPicture.Appearance = appearance49;
            this.btnOpenPicture.AutoWorkLayout = false;
            this.btnOpenPicture.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.btnOpenPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenPicture.IsStandardControl = false;
            this.btnOpenPicture.Location = new System.Drawing.Point(430, 169);
            this.btnOpenPicture.Name = "btnOpenPicture";
            this.btnOpenPicture.Size = new System.Drawing.Size(38, 30);
            this.btnOpenPicture.TabIndex = 16;
            ultraToolTipInfo3.ToolTipText = "Klientenfoto öffnen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnOpenPicture, ultraToolTipInfo3);
            this.btnOpenPicture.Click += new System.EventHandler(this.btnOpenPicture_Click);
            // 
            // intAmputation_Prozent
            // 
            appearance50.TextHAlignAsString = "Right";
            this.intAmputation_Prozent.Appearance = appearance50;
            this.intAmputation_Prozent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.intAmputation_Prozent.Location = new System.Drawing.Point(430, 27);
            this.intAmputation_Prozent.MaxValue = 100;
            this.intAmputation_Prozent.MinValue = 0;
            this.intAmputation_Prozent.Name = "intAmputation_Prozent";
            this.intAmputation_Prozent.NonAutoSizeHeight = 20;
            this.intAmputation_Prozent.Size = new System.Drawing.Size(38, 22);
            this.intAmputation_Prozent.TabIndex = 2;
            this.intAmputation_Prozent.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblAmputation_Prozent
            // 
            appearance51.BackColor = System.Drawing.Color.Transparent;
            this.lblAmputation_Prozent.Appearance = appearance51;
            this.lblAmputation_Prozent.Location = new System.Drawing.Point(322, 30);
            this.lblAmputation_Prozent.Name = "lblAmputation_Prozent";
            this.lblAmputation_Prozent.Size = new System.Drawing.Size(105, 21);
            this.lblAmputation_Prozent.TabIndex = 511;
            this.lblAmputation_Prozent.Text = " Amputation (%)";
            // 
            // txtGewicht
            // 
            this.txtGewicht.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtGewicht.Location = new System.Drawing.Point(226, 27);
            this.txtGewicht.Name = "txtGewicht";
            this.txtGewicht.NonAutoSizeHeight = 20;
            this.txtGewicht.Size = new System.Drawing.Size(48, 22);
            this.txtGewicht.TabIndex = 1;
            this.txtGewicht.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtGroesse
            // 
            this.txtGroesse.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtGroesse.Location = new System.Drawing.Point(90, 27);
            this.txtGroesse.Name = "txtGroesse";
            this.txtGroesse.NonAutoSizeHeight = 20;
            this.txtGroesse.Size = new System.Drawing.Size(43, 22);
            this.txtGroesse.TabIndex = 0;
            this.txtGroesse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbstatur
            // 
            this.cmbstatur.AddEmptyEntry = false;
            this.cmbstatur.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbstatur.AutoOpenCBO = true;
            this.cmbstatur.BerufsstandGruppeJNA = -1;
            this.cmbstatur.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbstatur.ExactMatch = false;
            this.cmbstatur.Group = "STA";
            this.cmbstatur.IgnoreUnterdruecken = true;
            this.cmbstatur.Location = new System.Drawing.Point(137, 115);
            this.cmbstatur.MaxLength = 50;
            this.cmbstatur.Name = "cmbstatur";
            this.cmbstatur.PflichtJN = false;
            this.cmbstatur.SelectDistinct = false;
            this.cmbstatur.ShowAddButton = true;
            this.cmbstatur.Size = new System.Drawing.Size(169, 24);
            this.cmbstatur.sys = false;
            this.cmbstatur.TabIndex = 5;
            this.cmbstatur.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbHaarFarbe
            // 
            this.cmbHaarFarbe.AddEmptyEntry = false;
            this.cmbHaarFarbe.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbHaarFarbe.AutoOpenCBO = true;
            this.cmbHaarFarbe.BerufsstandGruppeJNA = -1;
            this.cmbHaarFarbe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbHaarFarbe.ExactMatch = false;
            this.cmbHaarFarbe.Group = "HFR";
            this.cmbHaarFarbe.IgnoreUnterdruecken = true;
            this.cmbHaarFarbe.Location = new System.Drawing.Point(137, 85);
            this.cmbHaarFarbe.MaxLength = 255;
            this.cmbHaarFarbe.Name = "cmbHaarFarbe";
            this.cmbHaarFarbe.PflichtJN = false;
            this.cmbHaarFarbe.SelectDistinct = false;
            this.cmbHaarFarbe.ShowAddButton = true;
            this.cmbHaarFarbe.Size = new System.Drawing.Size(169, 24);
            this.cmbHaarFarbe.sys = false;
            this.cmbHaarFarbe.TabIndex = 4;
            this.cmbHaarFarbe.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAugenFarbe
            // 
            this.cmbAugenFarbe.AddEmptyEntry = false;
            this.cmbAugenFarbe.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAugenFarbe.AutoOpenCBO = true;
            this.cmbAugenFarbe.BerufsstandGruppeJNA = -1;
            this.cmbAugenFarbe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbAugenFarbe.ExactMatch = false;
            this.cmbAugenFarbe.Group = "AFR";
            this.cmbAugenFarbe.IgnoreUnterdruecken = true;
            this.cmbAugenFarbe.Location = new System.Drawing.Point(137, 55);
            this.cmbAugenFarbe.MaxLength = 255;
            this.cmbAugenFarbe.Name = "cmbAugenFarbe";
            this.cmbAugenFarbe.PflichtJN = false;
            this.cmbAugenFarbe.SelectDistinct = false;
            this.cmbAugenFarbe.ShowAddButton = true;
            this.cmbAugenFarbe.Size = new System.Drawing.Size(169, 24);
            this.cmbAugenFarbe.sys = false;
            this.cmbAugenFarbe.TabIndex = 3;
            this.cmbAugenFarbe.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGewicht
            // 
            appearance52.BackColor = System.Drawing.Color.Transparent;
            this.lblGewicht.Appearance = appearance52;
            this.lblGewicht.AutoSize = true;
            this.lblGewicht.Location = new System.Drawing.Point(140, 30);
            this.lblGewicht.Name = "lblGewicht";
            this.lblGewicht.Size = new System.Drawing.Size(80, 17);
            this.lblGewicht.TabIndex = 104;
            this.lblGewicht.Text = "Gewicht (kg)";
            // 
            // lblAugenfarbe
            // 
            appearance53.BackColor = System.Drawing.Color.Transparent;
            this.lblAugenfarbe.Appearance = appearance53;
            this.lblAugenfarbe.AutoSize = true;
            this.lblAugenfarbe.Location = new System.Drawing.Point(14, 60);
            this.lblAugenfarbe.Name = "lblAugenfarbe";
            this.lblAugenfarbe.Size = new System.Drawing.Size(74, 17);
            this.lblAugenfarbe.TabIndex = 101;
            this.lblAugenfarbe.Text = "Augenfarbe";
            // 
            // lblAnrede
            // 
            appearance54.BackColor = System.Drawing.Color.Transparent;
            this.lblAnrede.Appearance = appearance54;
            this.lblAnrede.AutoSize = true;
            this.lblAnrede.Location = new System.Drawing.Point(15, 179);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(69, 17);
            this.lblAnrede.TabIndex = 22;
            this.lblAnrede.Text = "Kosename";
            // 
            // txtBesKennz
            // 
            this.txtBesKennz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBesKennz.Location = new System.Drawing.Point(137, 205);
            this.txtBesKennz.MaxLength = 100;
            this.txtBesKennz.Multiline = true;
            this.txtBesKennz.Name = "txtBesKennz";
            this.txtBesKennz.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBesKennz.Size = new System.Drawing.Size(345, 86);
            this.txtBesKennz.TabIndex = 23;
            this.txtBesKennz.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblHaarFarbe
            // 
            appearance55.BackColor = System.Drawing.Color.Transparent;
            this.lblHaarFarbe.Appearance = appearance55;
            this.lblHaarFarbe.AutoSize = true;
            this.lblHaarFarbe.Location = new System.Drawing.Point(14, 89);
            this.lblHaarFarbe.Name = "lblHaarFarbe";
            this.lblHaarFarbe.Size = new System.Drawing.Size(64, 17);
            this.lblHaarFarbe.TabIndex = 100;
            this.lblHaarFarbe.Text = "Haarfarbe";
            // 
            // lblAeussKenz
            // 
            appearance56.BackColor = System.Drawing.Color.Transparent;
            this.lblAeussKenz.Appearance = appearance56;
            this.lblAeussKenz.Location = new System.Drawing.Point(18, 208);
            this.lblAeussKenz.Name = "lblAeussKenz";
            this.lblAeussKenz.Size = new System.Drawing.Size(116, 21);
            this.lblAeussKenz.TabIndex = 23;
            this.lblAeussKenz.Text = "Bes. Kennzeichen";
            // 
            // txtKosename
            // 
            this.txtKosename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKosename.Location = new System.Drawing.Point(137, 175);
            this.txtKosename.MaxLength = 50;
            this.txtKosename.Name = "txtKosename";
            this.txtKosename.Size = new System.Drawing.Size(169, 24);
            this.txtKosename.TabIndex = 22;
            this.txtKosename.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStatur
            // 
            appearance57.BackColor = System.Drawing.Color.Transparent;
            this.lblStatur.Appearance = appearance57;
            this.lblStatur.AutoSize = true;
            this.lblStatur.Location = new System.Drawing.Point(14, 118);
            this.lblStatur.Name = "lblStatur";
            this.lblStatur.Size = new System.Drawing.Size(41, 17);
            this.lblStatur.TabIndex = 98;
            this.lblStatur.Text = "Statur";
            // 
            // lblGroesse
            // 
            appearance58.BackColor = System.Drawing.Color.Transparent;
            this.lblGroesse.Appearance = appearance58;
            this.lblGroesse.AutoSize = true;
            this.lblGroesse.Location = new System.Drawing.Point(14, 30);
            this.lblGroesse.Name = "lblGroesse";
            this.lblGroesse.Size = new System.Drawing.Size(73, 17);
            this.lblGroesse.TabIndex = 96;
            this.lblGroesse.Text = "Größe (cm)";
            // 
            // Namenstag
            // 
            this.Namenstag.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Namenstag.FormatString = "";
            this.Namenstag.Location = new System.Drawing.Point(137, 145);
            this.Namenstag.MaskInput = "dd.mm";
            this.Namenstag.Name = "Namenstag";
            this.Namenstag.ownFormat = "";
            this.Namenstag.ownMaskInput = "";
            this.Namenstag.Size = new System.Drawing.Size(73, 24);
            this.Namenstag.TabIndex = 6;
            this.Namenstag.Value = null;
            this.Namenstag.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNamenstag
            // 
            appearance59.BackColor = System.Drawing.Color.Transparent;
            this.lblNamenstag.Appearance = appearance59;
            this.lblNamenstag.AutoSize = true;
            this.lblNamenstag.Location = new System.Drawing.Point(14, 147);
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
            this.pageControlAufenthalt.Controls.Add(this.panelAufenthalt);
            this.pageControlAufenthalt.Location = new System.Drawing.Point(-10000, -10000);
            this.pageControlAufenthalt.Name = "pageControlAufenthalt";
            this.pageControlAufenthalt.Size = new System.Drawing.Size(1028, 673);
            // 
            // panelAufenthalt
            // 
            this.panelAufenthalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAufenthalt.Location = new System.Drawing.Point(0, 0);
            this.panelAufenthalt.Name = "panelAufenthalt";
            this.panelAufenthalt.Size = new System.Drawing.Size(1028, 673);
            this.panelAufenthalt.TabIndex = 0;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.splitContainer1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1028, 673);
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
            this.splitContainer1.Size = new System.Drawing.Size(1028, 673);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 22;
            // 
            // ultraGroupBoxAngehörige
            // 
            appearance69.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxAngehörige.Appearance = appearance69;
            this.ultraGroupBoxAngehörige.Controls.Add(this.ucKontaktPersonen1);
            this.ultraGroupBoxAngehörige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxAngehörige.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxAngehörige.Name = "ultraGroupBoxAngehörige";
            this.ultraGroupBoxAngehörige.Size = new System.Drawing.Size(1028, 155);
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
            this.ucKontaktPersonen1.Size = new System.Drawing.Size(1022, 133);
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
            this.splitContainer2.Size = new System.Drawing.Size(1028, 514);
            this.splitContainer2.SplitterDistance = 265;
            this.splitContainer2.TabIndex = 0;
            // 
            // ultraGroupBoxÄrtze
            // 
            appearance70.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxÄrtze.Appearance = appearance70;
            this.ultraGroupBoxÄrtze.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.ultraGroupBoxÄrtze.Controls.Add(this.panelButtons1);
            this.ultraGroupBoxÄrtze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxÄrtze.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxÄrtze.Name = "ultraGroupBoxÄrtze";
            this.ultraGroupBoxÄrtze.Size = new System.Drawing.Size(1028, 265);
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
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(987, 243);
            this.ultraGridBagLayoutPanel2.TabIndex = 7;
            // 
            // gridAerzte
            // 
            this.gridAerzte.AutoWork = true;
            this.gridAerzte.DataMember = "PatientAerzte";
            this.gridAerzte.DataSource = this.dsPatientAerzte1;
            appearance71.BackColor = System.Drawing.Color.White;
            appearance71.BorderColor = System.Drawing.Color.Black;
            this.gridAerzte.DisplayLayout.Appearance = appearance71;
            this.gridAerzte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 0;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(163, 0);
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.Caption = "Hausarzt";
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 3;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(52, 0);
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.Caption = "Zuweiser";
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 4;
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(53, 0);
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn41.Header.Caption = "Aufnahmearzt";
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 5;
            ultraGridColumn41.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn41.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn41.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn41.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn41.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn42.Header.Caption = "Facharzt";
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 6;
            ultraGridColumn42.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn42.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn42.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn42.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn42.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 8;
            ultraGridColumn43.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn43.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn43.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn43.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn43.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 7;
            ultraGridColumn44.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn44.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn44.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn44.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn44.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 9;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 10;
            ultraGridColumn48.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn48.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn48.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(163, 0);
            ultraGridColumn48.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn48.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 11;
            ultraGridColumn49.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn49.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn49.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(113, 0);
            ultraGridColumn49.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn49.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn50.Header.Caption = "Tel / Adresse";
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 12;
            ultraGridColumn50.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn50.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn50.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(286, 0);
            ultraGridColumn50.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn50.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn51.Header.Caption = "E-Mail";
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 13;
            ultraGridColumn51.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(188, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51});
            ultraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridAerzte.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridAerzte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance72.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.GroupByBox.Appearance = appearance72;
            appearance73.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.BandLabelAppearance = appearance73;
            this.gridAerzte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.GroupByBox.Hidden = true;
            appearance74.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance74.BackColor2 = System.Drawing.SystemColors.Control;
            appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance74.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.PromptAppearance = appearance74;
            this.gridAerzte.DisplayLayout.MaxRowScrollRegions = 1;
            appearance75.BackColor = System.Drawing.SystemColors.Window;
            appearance75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAerzte.DisplayLayout.Override.ActiveCellAppearance = appearance75;
            appearance76.BackColor = System.Drawing.SystemColors.Highlight;
            appearance76.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridAerzte.DisplayLayout.Override.ActiveRowAppearance = appearance76;
            this.gridAerzte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridAerzte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance77.BackColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.CardAreaAppearance = appearance77;
            appearance78.BackColor = System.Drawing.Color.White;
            appearance78.BorderColor = System.Drawing.Color.Silver;
            appearance78.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridAerzte.DisplayLayout.Override.CellAppearance = appearance78;
            this.gridAerzte.DisplayLayout.Override.CellPadding = 0;
            appearance79.BackColor = System.Drawing.SystemColors.Control;
            appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance79.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance79.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.GroupByRowAppearance = appearance79;
            appearance80.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance80.TextHAlignAsString = "Left";
            this.gridAerzte.DisplayLayout.Override.HeaderAppearance = appearance80;
            this.gridAerzte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridAerzte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance81.BackColor = System.Drawing.SystemColors.Window;
            appearance81.BorderColor = System.Drawing.Color.Silver;
            this.gridAerzte.DisplayLayout.Override.RowAppearance = appearance81;
            appearance82.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridAerzte.DisplayLayout.Override.TemplateAddRowAppearance = appearance82;
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
            this.gridAerzte.Size = new System.Drawing.Size(987, 243);
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
            this.panelButtons1.Controls.Add(this.btnELGAKontakDelegation);
            this.panelButtons1.Controls.Add(this.btnUpdateArzt);
            this.panelButtons1.Controls.Add(this.btnDelAerzte);
            this.panelButtons1.Controls.Add(this.btnUpdateAerzte);
            this.panelButtons1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons1.Location = new System.Drawing.Point(990, 19);
            this.panelButtons1.Name = "panelButtons1";
            this.panelButtons1.Size = new System.Drawing.Size(35, 243);
            this.panelButtons1.TabIndex = 6;
            // 
            // btnELGAKontakDelegation
            // 
            appearance83.Image = global::PMDS.GUI.Properties.Resources.Elga;
            appearance83.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance83.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnELGAKontakDelegation.Appearance = appearance83;
            this.btnELGAKontakDelegation.AutoWorkLayout = false;
            this.btnELGAKontakDelegation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnELGAKontakDelegation.IsStandardControl = false;
            this.btnELGAKontakDelegation.Location = new System.Drawing.Point(2, 91);
            this.btnELGAKontakDelegation.Name = "btnELGAKontakDelegation";
            this.btnELGAKontakDelegation.Size = new System.Drawing.Size(30, 28);
            this.btnELGAKontakDelegation.TabIndex = 6;
            ultraToolTipInfo4.ToolTipText = "Kontaktdelegation";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnELGAKontakDelegation, ultraToolTipInfo4);
            this.btnELGAKontakDelegation.Click += new System.EventHandler(this.btnELGAKontakDelegation_Click);
            // 
            // btnUpdateArzt
            // 
            appearance84.Image = ((object)(resources.GetObject("appearance84.Image")));
            appearance84.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance84.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateArzt.Appearance = appearance84;
            this.btnUpdateArzt.AutoWorkLayout = false;
            this.btnUpdateArzt.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateArzt.IsStandardControl = false;
            this.btnUpdateArzt.Location = new System.Drawing.Point(2, 61);
            this.btnUpdateArzt.Name = "btnUpdateArzt";
            this.btnUpdateArzt.Size = new System.Drawing.Size(30, 28);
            this.btnUpdateArzt.TabIndex = 5;
            ultraToolTipInfo5.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateArzt, ultraToolTipInfo5);
            this.btnUpdateArzt.Click += new System.EventHandler(this.btnUpdateArzt_Click);
            // 
            // btnDelAerzte
            // 
            appearance85.BackColor = System.Drawing.Color.Transparent;
            appearance85.Image = ((object)(resources.GetObject("appearance85.Image")));
            appearance85.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance85.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelAerzte.Appearance = appearance85;
            this.btnDelAerzte.AutoWorkLayout = false;
            this.btnDelAerzte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelAerzte.DoOnClick = true;
            this.btnDelAerzte.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelAerzte.IsStandardControl = true;
            this.btnDelAerzte.Location = new System.Drawing.Point(2, 31);
            this.btnDelAerzte.Name = "btnDelAerzte";
            this.btnDelAerzte.Size = new System.Drawing.Size(30, 28);
            this.btnDelAerzte.TabIndex = 4;
            this.btnDelAerzte.TabStop = false;
            this.btnDelAerzte.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelAerzte.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelAerzte.Click += new System.EventHandler(this.btnDelAerzte_Click);
            // 
            // btnUpdateAerzte
            // 
            appearance86.BackColor = System.Drawing.Color.Transparent;
            appearance86.Image = ((object)(resources.GetObject("appearance86.Image")));
            appearance86.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance86.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateAerzte.Appearance = appearance86;
            this.btnUpdateAerzte.AutoWorkLayout = false;
            this.btnUpdateAerzte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateAerzte.DoOnClick = true;
            this.btnUpdateAerzte.ImageSize = new System.Drawing.Size(12, 12);
            this.btnUpdateAerzte.IsStandardControl = true;
            this.btnUpdateAerzte.Location = new System.Drawing.Point(2, 1);
            this.btnUpdateAerzte.Name = "btnUpdateAerzte";
            this.btnUpdateAerzte.Size = new System.Drawing.Size(30, 28);
            this.btnUpdateAerzte.TabIndex = 3;
            this.btnUpdateAerzte.TabStop = false;
            this.btnUpdateAerzte.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnUpdateAerzte.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUpdateAerzte.Click += new System.EventHandler(this.btnUpdateAerzte_Click);
            // 
            // ultraGroupBoxSachverwalter
            // 
            appearance87.BackColor = System.Drawing.Color.White;
            this.ultraGroupBoxSachverwalter.Appearance = appearance87;
            this.ultraGroupBoxSachverwalter.Controls.Add(this.ultraGridBagLayoutPanel3);
            this.ultraGroupBoxSachverwalter.Controls.Add(this.panelButtons2);
            this.ultraGroupBoxSachverwalter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBoxSachverwalter.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBoxSachverwalter.Name = "ultraGroupBoxSachverwalter";
            this.ultraGroupBoxSachverwalter.Size = new System.Drawing.Size(1028, 245);
            this.ultraGroupBoxSachverwalter.TabIndex = 21;
            this.ultraGroupBoxSachverwalter.Text = "Erwachsenenvertreter / Vorsorgebevollmächtigte";
            // 
            // ultraGridBagLayoutPanel3
            // 
            this.ultraGridBagLayoutPanel3.Controls.Add(this.gridSachwalter);
            this.ultraGridBagLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel3.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel3.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.ultraGridBagLayoutPanel3.Name = "ultraGridBagLayoutPanel3";
            this.ultraGridBagLayoutPanel3.Size = new System.Drawing.Size(987, 223);
            this.ultraGridBagLayoutPanel3.TabIndex = 11;
            // 
            // gridSachwalter
            // 
            this.gridSachwalter.AutoWork = true;
            this.gridSachwalter.DataMember = "Sachwalter";
            this.gridSachwalter.DataSource = this.dsKlientSachwalter1;
            appearance88.BackColor = System.Drawing.Color.White;
            appearance88.BorderColor = System.Drawing.Color.Black;
            this.gridSachwalter.DisplayLayout.Appearance = appearance88;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn52.Header.Editor = null;
            ultraGridColumn52.Header.VisiblePosition = 0;
            ultraGridColumn52.Hidden = true;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn53.Header.Editor = null;
            ultraGridColumn53.Header.VisiblePosition = 1;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn54.Header.Editor = null;
            ultraGridColumn54.Header.VisiblePosition = 2;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn55.Header.Editor = null;
            ultraGridColumn55.Header.VisiblePosition = 3;
            ultraGridColumn55.Hidden = true;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn56.Header.Editor = null;
            ultraGridColumn56.Header.VisiblePosition = 4;
            ultraGridColumn56.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(184, 0);
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn57.Header.Editor = null;
            ultraGridColumn57.Header.VisiblePosition = 5;
            ultraGridColumn57.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(499, 0);
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn58.Header.Editor = null;
            ultraGridColumn58.Header.VisiblePosition = 6;
            ultraGridColumn58.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(109, 0);
            ultraGridColumn59.Header.Caption = "Telefon / Adresse";
            ultraGridColumn59.Header.Editor = null;
            ultraGridColumn59.Header.VisiblePosition = 7;
            ultraGridColumn59.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(198, 0);
            ultraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn60.Header.Caption = "E-Mail";
            ultraGridColumn60.Header.Editor = null;
            ultraGridColumn60.Header.VisiblePosition = 8;
            ultraGridColumn60.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(201, 0);
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridSachwalter.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridSachwalter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSachwalter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance89.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance89.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance89.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance89.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.GroupByBox.Appearance = appearance89;
            appearance90.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSachwalter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance90;
            this.gridSachwalter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSachwalter.DisplayLayout.GroupByBox.Hidden = true;
            appearance91.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance91.BackColor2 = System.Drawing.SystemColors.Control;
            appearance91.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance91.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSachwalter.DisplayLayout.GroupByBox.PromptAppearance = appearance91;
            appearance92.BackColor = System.Drawing.SystemColors.Window;
            appearance92.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSachwalter.DisplayLayout.Override.ActiveCellAppearance = appearance92;
            appearance93.BackColor = System.Drawing.SystemColors.Highlight;
            appearance93.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridSachwalter.DisplayLayout.Override.ActiveRowAppearance = appearance93;
            this.gridSachwalter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridSachwalter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance94.BackColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.Override.CardAreaAppearance = appearance94;
            appearance95.BorderColor = System.Drawing.Color.Silver;
            appearance95.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridSachwalter.DisplayLayout.Override.CellAppearance = appearance95;
            this.gridSachwalter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridSachwalter.DisplayLayout.Override.CellPadding = 0;
            appearance96.BackColor = System.Drawing.SystemColors.Control;
            appearance96.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance96.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance96.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance96.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSachwalter.DisplayLayout.Override.GroupByRowAppearance = appearance96;
            appearance97.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance97.TextHAlignAsString = "Left";
            this.gridSachwalter.DisplayLayout.Override.HeaderAppearance = appearance97;
            this.gridSachwalter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridSachwalter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance98.BackColor = System.Drawing.SystemColors.Window;
            appearance98.BorderColor = System.Drawing.Color.Silver;
            this.gridSachwalter.DisplayLayout.Override.RowAppearance = appearance98;
            this.gridSachwalter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance99.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridSachwalter.DisplayLayout.Override.TemplateAddRowAppearance = appearance99;
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
            this.gridSachwalter.Size = new System.Drawing.Size(987, 223);
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
            this.panelButtons2.Location = new System.Drawing.Point(990, 19);
            this.panelButtons2.Name = "panelButtons2";
            this.panelButtons2.Size = new System.Drawing.Size(35, 223);
            this.panelButtons2.TabIndex = 10;
            // 
            // btnUpdateSachw
            // 
            appearance100.Image = ((object)(resources.GetObject("appearance100.Image")));
            appearance100.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance100.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateSachw.Appearance = appearance100;
            this.btnUpdateSachw.AutoWorkLayout = false;
            this.btnUpdateSachw.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateSachw.IsStandardControl = false;
            this.btnUpdateSachw.Location = new System.Drawing.Point(2, 61);
            this.btnUpdateSachw.Name = "btnUpdateSachw";
            this.btnUpdateSachw.Size = new System.Drawing.Size(30, 28);
            this.btnUpdateSachw.TabIndex = 9;
            ultraToolTipInfo6.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateSachw, ultraToolTipInfo6);
            this.btnUpdateSachw.Click += new System.EventHandler(this.btnUpdateSachw_Click);
            // 
            // btnDelSachwalter
            // 
            appearance101.BackColor = System.Drawing.Color.Transparent;
            appearance101.Image = ((object)(resources.GetObject("appearance101.Image")));
            appearance101.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance101.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelSachwalter.Appearance = appearance101;
            this.btnDelSachwalter.AutoWorkLayout = false;
            this.btnDelSachwalter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelSachwalter.DoOnClick = true;
            this.btnDelSachwalter.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelSachwalter.IsStandardControl = true;
            this.btnDelSachwalter.Location = new System.Drawing.Point(2, 31);
            this.btnDelSachwalter.Name = "btnDelSachwalter";
            this.btnDelSachwalter.Size = new System.Drawing.Size(30, 28);
            this.btnDelSachwalter.TabIndex = 8;
            this.btnDelSachwalter.TabStop = false;
            this.btnDelSachwalter.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelSachwalter.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelSachwalter.Click += new System.EventHandler(this.btnDelSachw_Click);
            // 
            // btnAddSachw
            // 
            appearance102.BackColor = System.Drawing.Color.Transparent;
            appearance102.Image = ((object)(resources.GetObject("appearance102.Image")));
            appearance102.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance102.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddSachw.Appearance = appearance102;
            this.btnAddSachw.AutoWorkLayout = false;
            this.btnAddSachw.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddSachw.DoOnClick = true;
            this.btnAddSachw.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddSachw.IsStandardControl = true;
            this.btnAddSachw.Location = new System.Drawing.Point(2, 1);
            this.btnAddSachw.Name = "btnAddSachw";
            this.btnAddSachw.Size = new System.Drawing.Size(30, 28);
            this.btnAddSachw.TabIndex = 7;
            this.btnAddSachw.TabStop = false;
            this.btnAddSachw.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddSachw.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddSachw.Click += new System.EventHandler(this.btnAddSachw_Click);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.AutoScroll = true;
            this.ultraTabPageControl5.Controls.Add(this.panelBewerbungdsdaten);
            this.ultraTabPageControl5.Controls.Add(this.ultraTabControlMainAdresse);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(1028, 673);
            // 
            // panelBewerbungdsdaten
            // 
            this.panelBewerbungdsdaten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBewerbungdsdaten.BackColor = System.Drawing.Color.White;
            this.panelBewerbungdsdaten.Controls.Add(this.txtStrasse);
            this.panelBewerbungdsdaten.Location = new System.Drawing.Point(490, 9);
            this.panelBewerbungdsdaten.Name = "panelBewerbungdsdaten";
            this.panelBewerbungdsdaten.Size = new System.Drawing.Size(535, 619);
            this.panelBewerbungdsdaten.TabIndex = 18;
            // 
            // txtStrasse
            // 
            this.txtStrasse.Enabled = false;
            this.txtStrasse.Location = new System.Drawing.Point(-60, 86);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(340, 24);
            this.txtStrasse.TabIndex = 2;
            this.txtStrasse.Visible = false;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabControlMainAdresse
            // 
            this.ultraTabControlMainAdresse.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControlMainAdresse.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControlMainAdresse.Controls.Add(this.ultraTabPageControl6);
            this.ultraTabControlMainAdresse.Location = new System.Drawing.Point(6, 9);
            this.ultraTabControlMainAdresse.Name = "ultraTabControlMainAdresse";
            this.ultraTabControlMainAdresse.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControlMainAdresse.Size = new System.Drawing.Size(481, 619);
            this.ultraTabControlMainAdresse.TabIndex = 70;
            ultraTab6.Key = "Hauptwohnsitz";
            ultraTab6.TabPage = this.ultraTabPageControl4;
            ultraTab6.Text = "Hauptwohnsitz";
            ultraTab7.Key = "Nebenwohnsitz";
            ultraTab7.TabPage = this.ultraTabPageControl6;
            ultraTab7.Text = "Nebenwohnsitz";
            this.ultraTabControlMainAdresse.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab6,
            ultraTab7});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(477, 592);
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.lblAnmerkung);
            this.ultraTabPageControl7.Controls.Add(this.editorRezGebBef_Anmerkung);
            this.ultraTabPageControl7.Controls.Add(this.baseGroupBox1);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(1028, 673);
            // 
            // lblAnmerkung
            // 
            appearance103.BackColor = System.Drawing.Color.Transparent;
            this.lblAnmerkung.Appearance = appearance103;
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnmerkung.Location = new System.Drawing.Point(6, 229);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(73, 17);
            this.lblAnmerkung.TabIndex = 93;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // editorRezGebBef_Anmerkung
            // 
            this.editorRezGebBef_Anmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorRezGebBef_Anmerkung.Location = new System.Drawing.Point(6, 253);
            this.editorRezGebBef_Anmerkung.MaxLength = 500;
            this.editorRezGebBef_Anmerkung.Multiline = true;
            this.editorRezGebBef_Anmerkung.Name = "editorRezGebBef_Anmerkung";
            this.editorRezGebBef_Anmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.editorRezGebBef_Anmerkung.Size = new System.Drawing.Size(524, 198);
            this.editorRezGebBef_Anmerkung.TabIndex = 92;
            this.editorRezGebBef_Anmerkung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseGroupBox1
            // 
            this.baseGroupBox1.Controls.Add(this.chkRezGebBef_SachwalterJN);
            this.baseGroupBox1.Controls.Add(this.datRezGebBef_BefristetAb);
            this.baseGroupBox1.Controls.Add(this.datRezGebBef_BefristetBis);
            this.baseGroupBox1.Controls.Add(this.datRezGebBef_RegoBis);
            this.baseGroupBox1.Controls.Add(this.cboRezGebBef_WiderrufGrund);
            this.baseGroupBox1.Controls.Add(this.datRezGebBef_RegoAb);
            this.baseGroupBox1.Controls.Add(this.baseLabel2);
            this.baseGroupBox1.Controls.Add(this.chkRezGebBef_BefristetJN);
            this.baseGroupBox1.Controls.Add(this.baseLabel1);
            this.baseGroupBox1.Controls.Add(this.chkRezGebBef_WiderrufJN);
            this.baseGroupBox1.Controls.Add(this.chkRezGebBef_UnbefristetJN);
            this.baseGroupBox1.Controls.Add(this.cbRezeptGeb);
            this.baseGroupBox1.Controls.Add(this.chkRezGebBef_RegoJN);
            this.baseGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseGroupBox1.Location = new System.Drawing.Point(6, 8);
            this.baseGroupBox1.Name = "baseGroupBox1";
            this.baseGroupBox1.Size = new System.Drawing.Size(524, 206);
            this.baseGroupBox1.TabIndex = 91;
            // 
            // chkRezGebBef_SachwalterJN
            // 
            appearance104.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_SachwalterJN.Appearance = appearance104;
            this.chkRezGebBef_SachwalterJN.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_SachwalterJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkRezGebBef_SachwalterJN.Location = new System.Drawing.Point(33, 170);
            this.chkRezGebBef_SachwalterJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkRezGebBef_SachwalterJN.Name = "chkRezGebBef_SachwalterJN";
            this.chkRezGebBef_SachwalterJN.Size = new System.Drawing.Size(136, 25);
            this.chkRezGebBef_SachwalterJN.TabIndex = 11;
            this.chkRezGebBef_SachwalterJN.Text = "SachwalterJN";
            this.chkRezGebBef_SachwalterJN.CheckedChanged += new System.EventHandler(this.chkRezGebBef_SachwalterJN_CheckedChanged);
            // 
            // datRezGebBef_BefristetAb
            // 
            this.datRezGebBef_BefristetAb.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datRezGebBef_BefristetAb.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.datRezGebBef_BefristetAb, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.datRezGebBef_BefristetAb.Location = new System.Drawing.Point(176, 105);
            this.datRezGebBef_BefristetAb.MaskInput = "";
            this.datRezGebBef_BefristetAb.Name = "datRezGebBef_BefristetAb";
            this.datRezGebBef_BefristetAb.ownFormat = "";
            this.datRezGebBef_BefristetAb.ownMaskInput = "";
            this.datRezGebBef_BefristetAb.Size = new System.Drawing.Size(110, 24);
            this.datRezGebBef_BefristetAb.TabIndex = 7;
            this.datRezGebBef_BefristetAb.Value = null;
            this.datRezGebBef_BefristetAb.ValueChanged += new System.EventHandler(this.datRezGebBef_BefristetAb_ValueChanged);
            // 
            // datRezGebBef_BefristetBis
            // 
            this.datRezGebBef_BefristetBis.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datRezGebBef_BefristetBis.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.datRezGebBef_BefristetBis, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.datRezGebBef_BefristetBis.Location = new System.Drawing.Point(326, 105);
            this.datRezGebBef_BefristetBis.MaskInput = "";
            this.datRezGebBef_BefristetBis.Name = "datRezGebBef_BefristetBis";
            this.datRezGebBef_BefristetBis.ownFormat = "";
            this.datRezGebBef_BefristetBis.ownMaskInput = "";
            this.datRezGebBef_BefristetBis.Size = new System.Drawing.Size(110, 24);
            this.datRezGebBef_BefristetBis.TabIndex = 8;
            this.datRezGebBef_BefristetBis.Value = null;
            this.datRezGebBef_BefristetBis.ValueChanged += new System.EventHandler(this.datRezGebBef_BefristetBis_ValueChanged);
            // 
            // datRezGebBef_RegoBis
            // 
            this.datRezGebBef_RegoBis.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datRezGebBef_RegoBis.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.datRezGebBef_RegoBis, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.datRezGebBef_RegoBis.Location = new System.Drawing.Point(326, 38);
            this.datRezGebBef_RegoBis.MaskInput = "";
            this.datRezGebBef_RegoBis.Name = "datRezGebBef_RegoBis";
            this.datRezGebBef_RegoBis.ownFormat = "";
            this.datRezGebBef_RegoBis.ownMaskInput = "";
            this.datRezGebBef_RegoBis.Size = new System.Drawing.Size(110, 24);
            this.datRezGebBef_RegoBis.TabIndex = 4;
            this.datRezGebBef_RegoBis.Value = null;
            this.datRezGebBef_RegoBis.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cboRezGebBef_WiderrufGrund
            // 
            this.cboRezGebBef_WiderrufGrund.AddEmptyEntry = false;
            this.cboRezGebBef_WiderrufGrund.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cboRezGebBef_WiderrufGrund.AutoOpenCBO = false;
            this.cboRezGebBef_WiderrufGrund.BerufsstandGruppeJNA = -1;
            this.cboRezGebBef_WiderrufGrund.ExactMatch = false;
            this.cboRezGebBef_WiderrufGrund.Group = "RGW";
            this.cboRezGebBef_WiderrufGrund.IgnoreUnterdruecken = true;
            this.cboRezGebBef_WiderrufGrund.Location = new System.Drawing.Point(176, 138);
            this.cboRezGebBef_WiderrufGrund.MaxLength = 40;
            this.cboRezGebBef_WiderrufGrund.Name = "cboRezGebBef_WiderrufGrund";
            this.cboRezGebBef_WiderrufGrund.PflichtJN = false;
            this.cboRezGebBef_WiderrufGrund.SelectDistinct = false;
            this.cboRezGebBef_WiderrufGrund.ShowAddButton = true;
            this.cboRezGebBef_WiderrufGrund.Size = new System.Drawing.Size(331, 24);
            this.cboRezGebBef_WiderrufGrund.sys = false;
            this.cboRezGebBef_WiderrufGrund.TabIndex = 10;
            this.cboRezGebBef_WiderrufGrund.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // datRezGebBef_RegoAb
            // 
            this.datRezGebBef_RegoAb.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datRezGebBef_RegoAb.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.datRezGebBef_RegoAb, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.datRezGebBef_RegoAb.Location = new System.Drawing.Point(176, 38);
            this.datRezGebBef_RegoAb.MaskInput = "";
            this.datRezGebBef_RegoAb.Name = "datRezGebBef_RegoAb";
            this.datRezGebBef_RegoAb.ownFormat = "";
            this.datRezGebBef_RegoAb.ownMaskInput = "";
            this.datRezGebBef_RegoAb.Size = new System.Drawing.Size(110, 24);
            this.datRezGebBef_RegoAb.TabIndex = 3;
            this.datRezGebBef_RegoAb.Value = null;
            this.datRezGebBef_RegoAb.ValueChanged += new System.EventHandler(this.datRezGebBef_RegoAb_ValueChanged);
            this.datRezGebBef_RegoAb.Leave += new System.EventHandler(this.datRezGebBef_RegoAb_Leave);
            // 
            // baseLabel2
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel2.Appearance = appearance105;
            this.baseLabel2.Location = new System.Drawing.Point(295, 112);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(36, 20);
            this.baseLabel2.TabIndex = 210;
            this.baseLabel2.Text = "bis";
            // 
            // chkRezGebBef_BefristetJN
            // 
            appearance106.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_BefristetJN.Appearance = appearance106;
            this.chkRezGebBef_BefristetJN.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_BefristetJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkRezGebBef_BefristetJN.Location = new System.Drawing.Point(33, 104);
            this.chkRezGebBef_BefristetJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkRezGebBef_BefristetJN.Name = "chkRezGebBef_BefristetJN";
            this.chkRezGebBef_BefristetJN.Size = new System.Drawing.Size(179, 25);
            this.chkRezGebBef_BefristetJN.TabIndex = 6;
            this.chkRezGebBef_BefristetJN.Text = "befristet";
            this.chkRezGebBef_BefristetJN.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            this.chkRezGebBef_BefristetJN.CheckStateChanged += new System.EventHandler(this.chkRezGebBef_BefristetJN_CheckStateChanged);
            // 
            // baseLabel1
            // 
            appearance107.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel1.Appearance = appearance107;
            this.baseLabel1.Location = new System.Drawing.Point(295, 40);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(36, 20);
            this.baseLabel1.TabIndex = 209;
            this.baseLabel1.Text = "bis";
            // 
            // chkRezGebBef_WiderrufJN
            // 
            appearance108.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_WiderrufJN.Appearance = appearance108;
            this.chkRezGebBef_WiderrufJN.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_WiderrufJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkRezGebBef_WiderrufJN.Location = new System.Drawing.Point(33, 137);
            this.chkRezGebBef_WiderrufJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkRezGebBef_WiderrufJN.Name = "chkRezGebBef_WiderrufJN";
            this.chkRezGebBef_WiderrufJN.Size = new System.Drawing.Size(179, 25);
            this.chkRezGebBef_WiderrufJN.TabIndex = 9;
            this.chkRezGebBef_WiderrufJN.Text = "wegen";
            this.chkRezGebBef_WiderrufJN.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            this.chkRezGebBef_WiderrufJN.CheckStateChanged += new System.EventHandler(this.chkRezGebBef_WiderrufJN_CheckStateChanged);
            // 
            // chkRezGebBef_UnbefristetJN
            // 
            appearance109.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_UnbefristetJN.Appearance = appearance109;
            this.chkRezGebBef_UnbefristetJN.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_UnbefristetJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkRezGebBef_UnbefristetJN.Location = new System.Drawing.Point(33, 71);
            this.chkRezGebBef_UnbefristetJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkRezGebBef_UnbefristetJN.Name = "chkRezGebBef_UnbefristetJN";
            this.chkRezGebBef_UnbefristetJN.Size = new System.Drawing.Size(179, 25);
            this.chkRezGebBef_UnbefristetJN.TabIndex = 5;
            this.chkRezGebBef_UnbefristetJN.Text = "unbefristet";
            this.chkRezGebBef_UnbefristetJN.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            this.chkRezGebBef_UnbefristetJN.CheckStateChanged += new System.EventHandler(this.chkRezGebBef_UnbefristetJN_CheckStateChanged);
            // 
            // cbRezeptGeb
            // 
            appearance110.BackColor = System.Drawing.Color.Transparent;
            this.cbRezeptGeb.Appearance = appearance110;
            this.cbRezeptGeb.BackColor = System.Drawing.Color.Transparent;
            this.cbRezeptGeb.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbRezeptGeb.Location = new System.Drawing.Point(13, 9);
            this.cbRezeptGeb.Margin = new System.Windows.Forms.Padding(4);
            this.cbRezeptGeb.Name = "cbRezeptGeb";
            this.cbRezeptGeb.Size = new System.Drawing.Size(273, 25);
            this.cbRezeptGeb.TabIndex = 1;
            this.cbRezeptGeb.Text = "Rezeptgebührenbefreiung";
            this.cbRezeptGeb.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            this.cbRezeptGeb.CheckStateChanged += new System.EventHandler(this.cbRezeptGeb_CheckStateChanged);
            // 
            // chkRezGebBef_RegoJN
            // 
            appearance111.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_RegoJN.Appearance = appearance111;
            this.chkRezGebBef_RegoJN.BackColor = System.Drawing.Color.Transparent;
            this.chkRezGebBef_RegoJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkRezGebBef_RegoJN.Location = new System.Drawing.Point(33, 38);
            this.chkRezGebBef_RegoJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkRezGebBef_RegoJN.Name = "chkRezGebBef_RegoJN";
            this.chkRezGebBef_RegoJN.Size = new System.Drawing.Size(179, 25);
            this.chkRezGebBef_RegoJN.TabIndex = 2;
            this.chkRezGebBef_RegoJN.Text = "Rego ab";
            this.chkRezGebBef_RegoJN.CheckStateChanged += new System.EventHandler(this.chkRezGebBef_RegoJN_CheckStateChanged);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelDokumente);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1028, 673);
            // 
            // panelDokumente
            // 
            this.panelDokumente.BackColor = System.Drawing.Color.Transparent;
            this.panelDokumente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDokumente.Location = new System.Drawing.Point(0, 0);
            this.panelDokumente.Name = "panelDokumente";
            this.panelDokumente.Size = new System.Drawing.Size(1028, 673);
            this.panelDokumente.TabIndex = 0;
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.panelDienstübergabe);
            this.ultraTabPageControl8.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(1028, 673);
            // 
            // panelDienstübergabe
            // 
            this.panelDienstübergabe.BackColor = System.Drawing.Color.Transparent;
            this.panelDienstübergabe.Controls.Add(this.splitContainerDienstübergabe);
            this.panelDienstübergabe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDienstübergabe.Location = new System.Drawing.Point(0, 0);
            this.panelDienstübergabe.Name = "panelDienstübergabe";
            this.panelDienstübergabe.Size = new System.Drawing.Size(1028, 673);
            this.panelDienstübergabe.TabIndex = 1;
            // 
            // splitContainerDienstübergabe
            // 
            this.splitContainerDienstübergabe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDienstübergabe.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDienstübergabe.Name = "splitContainerDienstübergabe";
            this.splitContainerDienstübergabe.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDienstübergabe.Panel1
            // 
            this.splitContainerDienstübergabe.Panel1.Controls.Add(this.txtSofortmassnahmen);
            this.splitContainerDienstübergabe.Panel1.Controls.Add(this.lblSofortmassnahmen);
            this.splitContainerDienstübergabe.Panel1.Controls.Add(this.lblInfoDienstuebergabe);
            this.splitContainerDienstübergabe.Panel1.Controls.Add(this.txtInfoDienstuebergabe);
            // 
            // splitContainerDienstübergabe.Panel2
            // 
            this.splitContainerDienstübergabe.Panel2.Controls.Add(this.lblBesonderheit);
            this.splitContainerDienstübergabe.Panel2.Controls.Add(this.txtBesonderheit2);
            this.splitContainerDienstübergabe.Size = new System.Drawing.Size(1028, 673);
            this.splitContainerDienstübergabe.SplitterDistance = 389;
            this.splitContainerDienstübergabe.TabIndex = 212;
            // 
            // txtSofortmassnahmen
            // 
            this.txtSofortmassnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance112.FontData.BoldAsString = "False";
            appearance112.ForeColor = System.Drawing.Color.Black;
            this.txtSofortmassnahmen.Appearance = appearance112;
            this.errorProvider1.SetIconAlignment(this.txtSofortmassnahmen, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.txtSofortmassnahmen.Location = new System.Drawing.Point(141, 5);
            this.txtSofortmassnahmen.MaxLength = 255;
            this.txtSofortmassnahmen.Multiline = true;
            this.txtSofortmassnahmen.Name = "txtSofortmassnahmen";
            this.txtSofortmassnahmen.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtSofortmassnahmen.Size = new System.Drawing.Size(884, 54);
            this.txtSofortmassnahmen.TabIndex = 255;
            this.txtSofortmassnahmen.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblSofortmassnahmen
            // 
            appearance113.BackColor = System.Drawing.Color.Transparent;
            this.lblSofortmassnahmen.Appearance = appearance113;
            this.lblSofortmassnahmen.AutoSize = true;
            this.lblSofortmassnahmen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSofortmassnahmen.Location = new System.Drawing.Point(3, 9);
            this.lblSofortmassnahmen.Name = "lblSofortmassnahmen";
            this.lblSofortmassnahmen.Size = new System.Drawing.Size(142, 17);
            this.lblSofortmassnahmen.TabIndex = 215;
            this.lblSofortmassnahmen.Text = "Wichtige Informationen";
            // 
            // lblInfoDienstuebergabe
            // 
            appearance114.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoDienstuebergabe.Appearance = appearance114;
            this.lblInfoDienstuebergabe.Location = new System.Drawing.Point(3, 60);
            this.lblInfoDienstuebergabe.Name = "lblInfoDienstuebergabe";
            this.lblInfoDienstuebergabe.Size = new System.Drawing.Size(587, 17);
            this.lblInfoDienstuebergabe.TabIndex = 212;
            this.lblInfoDienstuebergabe.Text = "Dekurse für Dienstübergabe der letzten sieben Tage";
            // 
            // txtInfoDienstuebergabe
            // 
            this.txtInfoDienstuebergabe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance115.BackColor = System.Drawing.Color.White;
            this.txtInfoDienstuebergabe.Appearance = appearance115;
            this.txtInfoDienstuebergabe.Location = new System.Drawing.Point(3, 79);
            this.txtInfoDienstuebergabe.Name = "txtInfoDienstuebergabe";
            this.txtInfoDienstuebergabe.ReadOnly = true;
            this.txtInfoDienstuebergabe.Size = new System.Drawing.Size(1022, 309);
            this.txtInfoDienstuebergabe.TabIndex = 213;
            this.txtInfoDienstuebergabe.Value = "";
            // 
            // lblBesonderheit
            // 
            appearance116.BackColor = System.Drawing.Color.Transparent;
            this.lblBesonderheit.Appearance = appearance116;
            this.lblBesonderheit.Location = new System.Drawing.Point(3, 3);
            this.lblBesonderheit.Name = "lblBesonderheit";
            this.lblBesonderheit.Size = new System.Drawing.Size(457, 17);
            this.lblBesonderheit.TabIndex = 210;
            this.lblBesonderheit.Text = "Anmerkung zur Dienstübergabe";
            // 
            // txtBesonderheit2
            // 
            this.txtBesonderheit2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance117.BackColor = System.Drawing.Color.White;
            this.txtBesonderheit2.Appearance = appearance117;
            this.txtBesonderheit2.Location = new System.Drawing.Point(3, 22);
            this.txtBesonderheit2.Name = "txtBesonderheit2";
            this.txtBesonderheit2.Size = new System.Drawing.Size(1022, 255);
            this.txtBesonderheit2.TabIndex = 211;
            this.txtBesonderheit2.Value = "";
            this.txtBesonderheit2.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Controls.Add(this.ucVOErfassen1);
            this.ultraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(1028, 673);
            // 
            // ucVOErfassen1
            // 
            pmdsBusiness1.isinitialized = false;
            this.ucVOErfassen1.b = pmdsBusiness1;
            this.ucVOErfassen1.b2 = pmdsBusinessUI1;
            this.ucVOErfassen1.b3 = pmdsBusinessUI2;
            this.ucVOErfassen1.buildUI1 = buildUI1;
            this.ucVOErfassen1.contSelectPatientenBenutzer1 = null;
            this.ucVOErfassen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOErfassen1.Location = new System.Drawing.Point(0, 0);
            this.ucVOErfassen1.Margin = new System.Windows.Forms.Padding(4);
            this.ucVOErfassen1.Name = "ucVOErfassen1";
            this.ucVOErfassen1.PMDSBusinessUI2 = pmdsBusinessUI3;
            this.ucVOErfassen1.Size = new System.Drawing.Size(1028, 673);
            this.ucVOErfassen1.TabIndex = 0;
            this.ucVOErfassen1.UIGlobal1 = uiGlobal1;
            // 
            // ultraTabPageControl10
            // 
            this.ultraTabPageControl10.Controls.Add(this.contELGAKlient1);
            this.ultraTabPageControl10.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl10.Name = "ultraTabPageControl10";
            this.ultraTabPageControl10.Size = new System.Drawing.Size(1028, 673);
            // 
            // contELGAKlient1
            // 
            this.contELGAKlient1.BackColor = System.Drawing.Color.White;
            this.contELGAKlient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGAKlient1.IDAufenthalt = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.contELGAKlient1.IDKlient = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.contELGAKlient1.IsInitialized = false;
            this.contELGAKlient1.IsNeuaufnahme = false;
            this.contELGAKlient1.Location = new System.Drawing.Point(0, 0);
            this.contELGAKlient1.mainWindowAufnahme = null;
            this.contELGAKlient1.Margin = new System.Windows.Forms.Padding(4);
            this.contELGAKlient1.Name = "contELGAKlient1";
            this.contELGAKlient1.Size = new System.Drawing.Size(1028, 673);
            this.contELGAKlient1.TabIndex = 0;
            // 
            // ultraTabPageControl11
            // 
            this.ultraTabPageControl11.Controls.Add(this.pnlSTAMP);
            this.ultraTabPageControl11.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new System.Drawing.Size(1028, 673);
            // 
            // pnlSTAMP
            // 
            // 
            // pnlSTAMP.ClientArea
            // 
            this.pnlSTAMP.ClientArea.Controls.Add(this.ucSTAMPData1);
            this.pnlSTAMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSTAMP.Location = new System.Drawing.Point(0, 0);
            this.pnlSTAMP.Name = "pnlSTAMP";
            this.pnlSTAMP.Size = new System.Drawing.Size(1028, 673);
            this.pnlSTAMP.TabIndex = 1;
            // 
            // ucSTAMPData1
            // 
            this.ucSTAMPData1.AutoScroll = true;
            this.ucSTAMPData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSTAMPData1.IsDirty = false;
            this.ucSTAMPData1.Location = new System.Drawing.Point(0, 0);
            this.ucSTAMPData1.Name = "ucSTAMPData1";
            this.ucSTAMPData1.Size = new System.Drawing.Size(1028, 673);
            this.ucSTAMPData1.STAMPDataHasChanged = false;
            this.ucSTAMPData1.TabIndex = 0;
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
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.tabStammdaten.ActiveTabAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.Name = "Microsoft Sans Serif";
            appearance6.FontData.SizeInPoints = 10F;
            appearance6.FontData.UnderlineAsString = "False";
            this.tabStammdaten.Appearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.tabStammdaten.ClientAreaAppearance = appearance7;
            this.tabStammdaten.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl2);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl5);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl3);
            this.tabStammdaten.Controls.Add(this.pageControlAufenthalt);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl1);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl7);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl8);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl9);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl10);
            this.tabStammdaten.Controls.Add(this.ultraTabPageControl11);
            this.tabStammdaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.OriginX = 0;
            gridBagConstraint3.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.tabStammdaten, gridBagConstraint3);
            appearance118.BackColor = System.Drawing.Color.White;
            appearance118.FontData.BoldAsString = "True";
            appearance118.FontData.SizeInPoints = 10F;
            appearance118.FontData.UnderlineAsString = "False";
            appearance118.ForeColor = System.Drawing.Color.Black;
            this.tabStammdaten.HotTrackAppearance = appearance118;
            this.tabStammdaten.Location = new System.Drawing.Point(0, 0);
            this.tabStammdaten.Name = "tabStammdaten";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.tabStammdaten, new System.Drawing.Size(723, 468));
            this.tabStammdaten.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabStammdaten.Size = new System.Drawing.Size(1032, 700);
            appearance119.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStammdaten.TabHeaderAreaAppearance = appearance119;
            this.tabStammdaten.TabIndex = 1;
            ultraTab1.Key = "PersoenlicheDaten";
            ultraTab1.TabPage = this.ultraTabPageControl2;
            ultraTab1.Text = "Persönliche Daten";
            ultraTab4.Key = "Aufenthalt";
            ultraTab4.TabPage = this.pageControlAufenthalt;
            ultraTab4.Text = "Abrechnungsdaten";
            ultraTab3.Key = "Kontakte";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Kontakte";
            ultraTab2.Key = "Wohnsituation";
            ultraTab2.TabPage = this.ultraTabPageControl5;
            ultraTab2.Text = "Adress- und Bewerbungsdaten";
            ultraTab8.Key = "Rezeptgebührenbefreiung";
            ultraTab8.TabPage = this.ultraTabPageControl7;
            ultraTab8.Text = "Rezeptgebührenbefreiung";
            ultraTab5.Key = "Dokumente";
            ultraTab5.TabPage = this.ultraTabPageControl1;
            ultraTab5.Text = "Dokumente";
            ultraTab9.Key = "Dienstübergabe";
            ultraTab9.TabPage = this.ultraTabPageControl8;
            ultraTab9.Text = "Dienstübergabe";
            ultraTab10.Key = "VOErfassen";
            ultraTab10.TabPage = this.ultraTabPageControl9;
            ultraTab10.Text = "Verordnungen";
            ultraTab11.Key = "ELGA";
            ultraTab11.TabPage = this.ultraTabPageControl10;
            ultraTab11.Text = "ELGA";
            ultraTab12.Key = "STAMP";
            ultraTab12.TabPage = this.ultraTabPageControl11;
            ultraTab12.Text = "STAMP";
            this.tabStammdaten.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab4,
            ultraTab3,
            ultraTab2,
            ultraTab8,
            ultraTab5,
            ultraTab9,
            ultraTab10,
            ultraTab11,
            ultraTab12});
            this.tabStammdaten.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.tabStammdaten.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(1028, 673);
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
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(1032, 700);
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
            this.Size = new System.Drawing.Size(1032, 700);
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAdressdaten)).EndInit();
            this.ultraGroupBoxAdressdaten.ResumeLayout(false);
            this.ultraGroupBoxAdressdaten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaupwohnsitzgemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHausnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseOhneHausnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLand)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).EndInit();
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
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).EndInit();
            this.grpAdmin.ResumeLayout(false);
            this.grpAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTAMPSynonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAbgemeldet)).EndInit();
            this.panelAufenthaltsdaten2.ResumeLayout(false);
            this.panelAufenthaltsdaten2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtZimmerNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgruppenkennzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMilieubetreuung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbwesenheitBeendet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKennwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxOben)).EndInit();
            this.ultraGroupBoxOben.ResumeLayout(false);
            this.ultraGroupBoxOben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitelPost)).EndInit();
            this.panelVerstorben.ResumeLayout(false);
            this.panelVerstorben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteTodeszeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAkdGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gebDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxAllgemein1)).EndInit();
            this.ultraGroupBoxAllgemein1.ResumeLayout(false);
            this.ultraGroupBoxAllgemein1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNRAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnatomie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDatenschutz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalliativ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGebName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKZUeberlebender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxPersonebescheibung)).EndInit();
            this.ultraGroupBoxPersonebescheibung.ResumeLayout(false);
            this.ultraGroupBoxPersonebescheibung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbstatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHaarFarbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAugenFarbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesKennz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKosename)).EndInit();
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
            this.panelBewerbungdsdaten.ResumeLayout(false);
            this.panelBewerbungdsdaten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlMainAdresse)).EndInit();
            this.ultraTabControlMainAdresse.ResumeLayout(false);
            this.ultraTabPageControl7.ResumeLayout(false);
            this.ultraTabPageControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorRezGebBef_Anmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseGroupBox1)).EndInit();
            this.baseGroupBox1.ResumeLayout(false);
            this.baseGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_SachwalterJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_BefristetAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_BefristetBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_RegoBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRezGebBef_WiderrufGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRezGebBef_RegoAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_BefristetJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_WiderrufJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_UnbefristetJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRezeptGeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRezGebBef_RegoJN)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl8.ResumeLayout(false);
            this.panelDienstübergabe.ResumeLayout(false);
            this.splitContainerDienstübergabe.Panel1.ResumeLayout(false);
            this.splitContainerDienstübergabe.Panel1.PerformLayout();
            this.splitContainerDienstübergabe.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDienstübergabe)).EndInit();
            this.splitContainerDienstübergabe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSofortmassnahmen)).EndInit();
            this.ultraTabPageControl9.ResumeLayout(false);
            this.ultraTabPageControl10.ResumeLayout(false);
            this.ultraTabPageControl11.ResumeLayout(false);
            this.pnlSTAMP.ClientArea.ResumeLayout(false);
            this.pnlSTAMP.ResumeLayout(false);
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
        private QS2.Desktop.ControlManagment.BaseLabel lblVorname2;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVorname;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblAkdGrad;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitel;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxPersonebescheibung;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbHaarFarbe;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbAugenFarbe;
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
        private QS2.Desktop.ControlManagment.BaseLabel lblMobil;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtMobil;
        private QS2.Desktop.ControlManagment.BaseLabel lblErstKontakt;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtTelefon;
        private QS2.Desktop.ControlManagment.BaseLabel lblTelefon;
        private QS2.Desktop.ControlManagment.BaseLabel lblOrt;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtOrt;
        private QS2.Desktop.ControlManagment.BaseLabel lblPLZ;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtPLZ;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasse;
        private QS2.Desktop.ControlManagment.BaseLabel lblStrasse;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtFax;
        private QS2.Desktop.ControlManagment.BaseLabel lblFax;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAngehörige;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxÄrtze;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxSachverwalter;
        private QS2.Desktop.ControlManagment.BaseGrid gridSachwalter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbstatur;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbBenutzer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private dsKontaktpersonen dsKontaktpersonen1;
        private dsKlientSachwalter dsKlientSachwalter1;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtGewicht;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtGroesse;
        private ucKontaktPersonen ucKontaktPersonen1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo txtLand;
        private QS2.Desktop.ControlManagment.BaseLabel lblLand;
        private ucButton btnDelAerzte;
        private ucButton btnUpdateAerzte;
        private ucButton btnDelSachwalter;
        private ucButton btnAddSachw;
        private dsPatientAerzte dsPatientAerzte1;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdateArzt;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdateSachw;
        private ucBewerbungsdaten ucBewerbungsdaten1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BasePanel panelButtons1;
        public QS2.Desktop.ControlManagment.BasePanel panelButtons2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl pageControlAufenthalt;
        private QS2.Desktop.ControlManagment.BaseButton btnOpenPicture;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public QS2.Desktop.ControlManagment.BaseTabControl tabStammdaten;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel panelDokumente;
        private QS2.Desktop.ControlManagment.BaseLabel lblTodeszeitpunkt;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkDNR;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkVerstorben;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dteTodeszeitpunkt;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkKZUeberlebender;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkAnatomie;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkMilieubetreuung;
        private QS2.Desktop.ControlManagment.BaseLabel lblPatientenverfügung;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripÄrzte;
        private System.Windows.Forms.ToolStripMenuItem zusammenführenToolStripMenuItem;
        private UltraTabControl ultraTabControlMainAdresse;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private UltraTabPageControl ultraTabPageControl4;
        private UltraTabPageControl ultraTabPageControl6;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxAdressdatenNWS;
        private BaseControls.AuswahlGruppeCombo txtLandNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblLandSub;
        private QS2.Desktop.ControlManagment.BaseLabel lblEMailSub;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtEmailNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblMobilSub;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtMobilNWS;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtTelefonNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblTelefonSub;
        private QS2.Desktop.ControlManagment.BaseLabel lblOrtSub;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtOrtNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblPLZSub;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtPLZNWS;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasseNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblAdresse;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtFaxNWS;
        private QS2.Desktop.ControlManagment.BaseLabel lblFaxSub;
        public ucAbrechAufenthKlient ucAbrechAufenthKlient1;
        private QS2.Desktop.ControlManagment.BaseLabel lblSprachen;
        public cboAuswahllisteMulti cboSprachenMulti;
        private UltraTabPageControl ultraTabPageControl7;
        private QS2.Desktop.ControlManagment.BaseGroupBox baseGroupBox1;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        public QS2.Desktop.ControlManagment.BaseCheckBox cbRezeptGeb;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkRezGebBef_WiderrufJN;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkRezGebBef_BefristetJN;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkRezGebBef_UnbefristetJN;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor datRezGebBef_BefristetBis;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor datRezGebBef_RegoBis;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor datRezGebBef_RegoAb;
        public BaseControls.AuswahlGruppeCombo cboRezGebBef_WiderrufGrund;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkRezGebBef_RegoJN;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor datRezGebBef_BefristetAb;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel2;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkRezGebBef_SachwalterJN;
        private System.Windows.Forms.Panel panelVerstorben;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkAbwesenheitBeendet;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkDatenschutz;
        private UltraTabPageControl ultraTabPageControl8;
        private System.Windows.Forms.Panel panelDienstübergabe;
        private QS2.Desktop.ControlManagment.BaseLabel lblBesonderheit;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtBesonderheit2;
        private System.Windows.Forms.SplitContainer splitContainerDienstübergabe;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfoDienstuebergabe;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtInfoDienstuebergabe;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkPalliativ;
        private QS2.Desktop.ControlManagment.BaseMaskEdit intAmputation_Prozent;
        private QS2.Desktop.ControlManagment.BaseLabel lblAmputation_Prozent;
        private UltraTabPageControl ultraTabPageControl9;
        public Verordnungen.ucVOErfassen ucVOErfassen1;
        private QS2.Desktop.ControlManagment.BaseTextEditor editorRezGebBef_Anmerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSofortmassnahmen;
        private QS2.Desktop.ControlManagment.BaseLabel lblSofortmassnahmen;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel3;
        private System.Windows.Forms.Panel panelAufenthalt;
        private System.Windows.Forms.Panel panelBewerbungdsdaten;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitelPost;
        private BaseControls.AuswahlGruppeCombo cboTitelPost;
        public QS2.Desktop.ControlManagment.BaseGrid gridAerzte;
        private UltraTabPageControl ultraTabPageControl10;
        public ELGA.contELGAKlient contELGAKlient1;
        private QS2.Desktop.ControlManagment.BaseLabel lblDNRAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtDNRAnmerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lbleMailKlient;
        private QS2.Desktop.ControlManagment.BaseLabel lblEMailPat;
        private QS2.Desktop.ControlManagment.BaseLabel lblMobilTelNrKlient;
        private QS2.Desktop.ControlManagment.BaseLabel lblMobilTel;
        private QS2.Desktop.ControlManagment.BaseButton btnELGAKontakDelegation;
        private QS2.Desktop.ControlManagment.BaseLabel lblHausnummer;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtHausnummer;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasseOhneHausnummer;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpAdmin;
        private QS2.Desktop.ControlManagment.BasePanel panelAufenthaltsdaten2;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkELGAAbgemeldet;
        internal Infragistics.Win.Misc.UltraButton btnAbwesenheitsendeBestätigen;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtZimmerNr;
        private QS2.Desktop.ControlManagment.BaseLabel lblKennwort;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel4;
        private QS2.Desktop.ControlManagment.BaseLabel lblZimNr;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtbPK;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKennwort;
        private QS2.Desktop.ControlManagment.BaseLabel lblGruppenKz;
        private QS2.Desktop.ControlManagment.BaseLabel lblFallzahl;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtFallzahl;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtgruppenkennzahl;
        private UltraTabPageControl ultraTabPageControl11;
        private STAMP.ucSTAMPData ucSTAMPData1;
        private Infragistics.Win.Misc.UltraPanel pnlSTAMP;
        public BaseControls.AuswahlGruppeCombo cmbHaupwohnsitzgemeinde;
        private QS2.Desktop.ControlManagment.BaseLabel lblHauptwohnsitzgemeinde;
        private QS2.Desktop.ControlManagment.BaseLabel lblVorhergendeBetreuungsformen;
        public cboAuswahllisteMulti cboVorherigeBetreuungsformenMulti;
        private QS2.Desktop.ControlManagment.BaseLabel lblSTAMPSynonym;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSTAMPSynonym;
    }
}
