using PMDS.GUI.Klient;
namespace PMDS.GUI
{
    partial class ucRegelungen
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
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Unterbringung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Grund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beginn");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AngeordnetVon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AngeordnetAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufgehobenAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GefahrFuerLebenGesundheitJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EingriffUnerlaesslichJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufgehobenVon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TatsaechlicheEnde");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aktion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VoraussichtlicheDauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zeitraum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PsychischekrankheitJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GeistigeBehinderungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedDiagnICD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischeDiagnose");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErheblicheSelbstgefaehrdungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErheblicheFremdgefaehrdungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EingriffUnerlaesslichBeschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einrichtungsleiter");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ElektronischesUeberwachungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZurueckhaltensandrohungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VerschlosseneTuerJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DrehknopfJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CodierungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LabyrinthJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BaulicheMassnahmen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn109 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhlGurtenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhTischJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhTherapietischJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhl");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelGurtenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelTischJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn115 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelTherapietischJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn116 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelegenheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn117 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettSeitenteilenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn118 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettGurtenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn119 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBettVerlassen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn120 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedikFreihBeschraenkungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn121 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedikBezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn122 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GesendetAnBewohnervertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn123 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GesendetAnGesetzVertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn124 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GesendetAnSelbstGewVertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn125 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GesendetAnVertrauenspersonJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn126 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KlientZustimmungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn128 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufgehobeneMassnahmeInfo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Berufsgruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn130 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn131 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEBerufsgruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn132 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEAngeordnetVon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn133 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEGesendetAnBewohnervertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn134 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEGesendetAnGesetzVertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn136 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEGesendetAnSelbstGewVertreterJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn135 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ENDEGesendetAnVertrauenspersonJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn129 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VoraussichtlichesEnde", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn127 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Info");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn137 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlDokumentArt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn143 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlDokumentArzt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn138 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlDokumentDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn139 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhlBremsenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn140 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernRollstuhlSitzhoseJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn141 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettHandmanschettenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn142 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TatsaechlicheEndeGrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn144 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlDokumentArztTitel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn145 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlDokumentArztVorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn146 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AngeordnetVonTitel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn147 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AngeordnetVonVorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufgehobenVonTitel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AufgehobenVonVorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelSitzhoseJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EDI_Datum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn152 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EDI_Benutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn153 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinrichtungsleiterTitel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn154 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinrichtungsleiterVorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn155 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EDI_Protokoll");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnmerkungGutachten_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnmerkungVerhalten_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettHandArmgurte_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettFussBeingurte_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettAndereJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettBauchgurtJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernVerlassenBettElektronischJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelHandArmgurte_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelFussBeingurte_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelAndereJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelBauchgurtJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernSitzgelBrustgurtJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichFesthaltenJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichBarriereJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichVersperrterBereichJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichVersperrtesZimmerJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichHinderAmFortbewegenJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HindernBereichAndereJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinzelfallmedikationJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einzelfallmedikation_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DauermedikationJN_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauermedikation_2016");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EDI_BenutzerGesendet", 0);
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRegelungen));
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Auswahl zur Ansicht öffnen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtPatVerf = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.grpHeimaufenthaltsges = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.gridUnterbringung = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsUnterbringungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsUnterbringung = new PMDS.GUI.Klient.dsUnterbringung();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSendenUnterbringung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelUnterbringung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnVerlaeng = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPreview = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddUnterbringung = new PMDS.GUI.ucButton(this.components);
            this.btnHistorie = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpPatientverfügung = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.optBeachtlich = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVerfAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbpatVerf = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.ultraGroupBoxRelgiöseWünsche = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblAnmerkung2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbkrakSalbung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbKommunion = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtReligioneWuen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.grpRegelungen = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtSonstRegel = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtBesRegelung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtSterbeRegelung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSonstige = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblSterberegelung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbPostregel = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblPostregelung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBesuchsregelung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel3 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPatVerf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeimaufenthaltsges)).BeginInit();
            this.grpHeimaufenthaltsges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnterbringung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringungBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringung)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPatientverfügung)).BeginInit();
            this.grpPatientverfügung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optBeachtlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerfAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbpatVerf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxRelgiöseWünsche)).BeginInit();
            this.ultraGroupBoxRelgiöseWünsche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbkrakSalbung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKommunion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligioneWuen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRegelungen)).BeginInit();
            this.grpRegelungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstRegel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesRegelung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSterbeRegelung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostregel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            this.panelOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel3)).BeginInit();
            this.ultraGridBagLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtPatVerf
            // 
            appearance24.BackColorDisabled = System.Drawing.Color.White;
            this.dtPatVerf.Appearance = appearance24;
            this.dtPatVerf.DateTime = new System.DateTime(2006, 12, 14, 0, 0, 0, 0);
            this.dtPatVerf.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.dtPatVerf, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.dtPatVerf.Location = new System.Drawing.Point(79, 46);
            this.dtPatVerf.MaskInput = "";
            this.dtPatVerf.Name = "dtPatVerf";
            this.dtPatVerf.ownFormat = "";
            this.dtPatVerf.ownMaskInput = "";
            this.dtPatVerf.Size = new System.Drawing.Size(102, 24);
            this.dtPatVerf.TabIndex = 2;
            this.dtPatVerf.Value = new System.DateTime(2006, 12, 14, 0, 0, 0, 0);
            this.dtPatVerf.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpHeimaufenthaltsges
            // 
            this.grpHeimaufenthaltsges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.grpHeimaufenthaltsges.Appearance = appearance1;
            this.grpHeimaufenthaltsges.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.grpHeimaufenthaltsges.Controls.Add(this.panelButtons);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            this.ultraGridBagLayoutPanel3.SetGridBagConstraint(this.grpHeimaufenthaltsges, gridBagConstraint2);
            this.grpHeimaufenthaltsges.Location = new System.Drawing.Point(5, 0);
            this.grpHeimaufenthaltsges.Name = "grpHeimaufenthaltsges";
            this.ultraGridBagLayoutPanel3.SetPreferredSize(this.grpHeimaufenthaltsges, new System.Drawing.Size(258, 158));
            this.grpHeimaufenthaltsges.Size = new System.Drawing.Size(1090, 307);
            this.grpHeimaufenthaltsges.TabIndex = 156;
            this.grpHeimaufenthaltsges.Text = "Heimaufenthalts- / Unterbringungsgesetz";
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.gridUnterbringung);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(3, 49);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(1084, 255);
            this.ultraGridBagLayoutPanel1.TabIndex = 40;
            // 
            // gridUnterbringung
            // 
            this.gridUnterbringung.AutoWork = true;
            this.gridUnterbringung.DataMember = "Unterbringung";
            this.gridUnterbringung.DataSource = this.dsUnterbringungBindingSource;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.gridUnterbringung.DisplayLayout.Appearance = appearance2;
            ultraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn78.Header.Editor = null;
            ultraGridColumn78.Header.VisiblePosition = 0;
            ultraGridColumn78.Hidden = true;
            ultraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn79.Header.Editor = null;
            ultraGridColumn79.Header.VisiblePosition = 1;
            ultraGridColumn79.Hidden = true;
            ultraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn80.Header.Editor = null;
            ultraGridColumn80.Header.VisiblePosition = 2;
            ultraGridColumn80.Hidden = true;
            ultraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 3;
            ultraGridColumn81.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn81.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn81.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(106, 0);
            ultraGridColumn81.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn81.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn81.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 4;
            ultraGridColumn82.Hidden = true;
            ultraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 5;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn84.Header.Editor = null;
            ultraGridColumn84.Header.VisiblePosition = 6;
            ultraGridColumn84.Hidden = true;
            ultraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn85.Header.Caption = "Aufgehoben am";
            ultraGridColumn85.Header.Editor = null;
            ultraGridColumn85.Header.VisiblePosition = 7;
            ultraGridColumn85.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn85.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn85.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn85.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn85.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn85.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn87.Header.Editor = null;
            ultraGridColumn87.Header.VisiblePosition = 9;
            ultraGridColumn87.Hidden = true;
            ultraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn88.Header.Editor = null;
            ultraGridColumn88.Header.VisiblePosition = 10;
            ultraGridColumn88.Hidden = true;
            ultraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn89.Header.Editor = null;
            ultraGridColumn89.Header.VisiblePosition = 11;
            ultraGridColumn89.Hidden = true;
            ultraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn90.Header.Editor = null;
            ultraGridColumn90.Header.VisiblePosition = 12;
            ultraGridColumn90.Hidden = true;
            ultraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn91.Header.Editor = null;
            ultraGridColumn91.Header.VisiblePosition = 13;
            ultraGridColumn91.Hidden = true;
            ultraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn92.Header.Editor = null;
            ultraGridColumn92.Header.VisiblePosition = 14;
            ultraGridColumn92.Hidden = true;
            ultraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn93.Header.Editor = null;
            ultraGridColumn93.Header.VisiblePosition = 15;
            ultraGridColumn93.Hidden = true;
            ultraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn94.Header.Editor = null;
            ultraGridColumn94.Header.VisiblePosition = 16;
            ultraGridColumn94.Hidden = true;
            ultraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn95.Header.Editor = null;
            ultraGridColumn95.Header.VisiblePosition = 17;
            ultraGridColumn95.Hidden = true;
            ultraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn96.Header.Editor = null;
            ultraGridColumn96.Header.VisiblePosition = 18;
            ultraGridColumn96.Hidden = true;
            ultraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn97.Header.Editor = null;
            ultraGridColumn97.Header.VisiblePosition = 19;
            ultraGridColumn97.Hidden = true;
            ultraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn98.Header.Editor = null;
            ultraGridColumn98.Header.VisiblePosition = 20;
            ultraGridColumn98.Hidden = true;
            ultraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn99.Header.Editor = null;
            ultraGridColumn99.Header.VisiblePosition = 21;
            ultraGridColumn99.Hidden = true;
            ultraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn100.Header.Editor = null;
            ultraGridColumn100.Header.VisiblePosition = 22;
            ultraGridColumn100.Hidden = true;
            ultraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn101.Header.Editor = null;
            ultraGridColumn101.Header.VisiblePosition = 23;
            ultraGridColumn101.Hidden = true;
            ultraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn102.Header.Editor = null;
            ultraGridColumn102.Header.VisiblePosition = 24;
            ultraGridColumn102.Hidden = true;
            ultraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn103.Header.Editor = null;
            ultraGridColumn103.Header.VisiblePosition = 25;
            ultraGridColumn103.Hidden = true;
            ultraGridColumn104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn104.Header.Editor = null;
            ultraGridColumn104.Header.VisiblePosition = 26;
            ultraGridColumn104.Hidden = true;
            ultraGridColumn105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn105.Header.Editor = null;
            ultraGridColumn105.Header.VisiblePosition = 27;
            ultraGridColumn105.Hidden = true;
            ultraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn106.Header.Editor = null;
            ultraGridColumn106.Header.VisiblePosition = 28;
            ultraGridColumn106.Hidden = true;
            ultraGridColumn107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn107.Header.Editor = null;
            ultraGridColumn107.Header.VisiblePosition = 29;
            ultraGridColumn107.Hidden = true;
            ultraGridColumn108.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn108.Header.Editor = null;
            ultraGridColumn108.Header.VisiblePosition = 30;
            ultraGridColumn108.Hidden = true;
            ultraGridColumn109.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn109.Header.Editor = null;
            ultraGridColumn109.Header.VisiblePosition = 31;
            ultraGridColumn109.Hidden = true;
            ultraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn110.Header.Editor = null;
            ultraGridColumn110.Header.VisiblePosition = 32;
            ultraGridColumn110.Hidden = true;
            ultraGridColumn111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn111.Header.Editor = null;
            ultraGridColumn111.Header.VisiblePosition = 33;
            ultraGridColumn111.Hidden = true;
            ultraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn112.Header.Editor = null;
            ultraGridColumn112.Header.VisiblePosition = 34;
            ultraGridColumn112.Hidden = true;
            ultraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn113.Header.Editor = null;
            ultraGridColumn113.Header.VisiblePosition = 35;
            ultraGridColumn113.Hidden = true;
            ultraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn114.Header.Editor = null;
            ultraGridColumn114.Header.VisiblePosition = 36;
            ultraGridColumn114.Hidden = true;
            ultraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn115.Header.Editor = null;
            ultraGridColumn115.Header.VisiblePosition = 37;
            ultraGridColumn115.Hidden = true;
            ultraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn116.Header.Editor = null;
            ultraGridColumn116.Header.VisiblePosition = 38;
            ultraGridColumn116.Hidden = true;
            ultraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn117.Header.Editor = null;
            ultraGridColumn117.Header.VisiblePosition = 39;
            ultraGridColumn117.Hidden = true;
            ultraGridColumn118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn118.Header.Editor = null;
            ultraGridColumn118.Header.VisiblePosition = 40;
            ultraGridColumn118.Hidden = true;
            ultraGridColumn119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn119.Header.Editor = null;
            ultraGridColumn119.Header.VisiblePosition = 41;
            ultraGridColumn119.Hidden = true;
            ultraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn120.Header.Editor = null;
            ultraGridColumn120.Header.VisiblePosition = 42;
            ultraGridColumn120.Hidden = true;
            ultraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn121.Header.Editor = null;
            ultraGridColumn121.Header.VisiblePosition = 43;
            ultraGridColumn121.Hidden = true;
            ultraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn122.Header.Editor = null;
            ultraGridColumn122.Header.VisiblePosition = 44;
            ultraGridColumn122.Hidden = true;
            ultraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn123.Header.Editor = null;
            ultraGridColumn123.Header.VisiblePosition = 45;
            ultraGridColumn123.Hidden = true;
            ultraGridColumn124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn124.Header.Editor = null;
            ultraGridColumn124.Header.VisiblePosition = 46;
            ultraGridColumn124.Hidden = true;
            ultraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn125.Header.Editor = null;
            ultraGridColumn125.Header.VisiblePosition = 47;
            ultraGridColumn125.Hidden = true;
            ultraGridColumn126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn126.Header.Editor = null;
            ultraGridColumn126.Header.VisiblePosition = 48;
            ultraGridColumn126.Hidden = true;
            ultraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn128.Header.Editor = null;
            ultraGridColumn128.Header.VisiblePosition = 50;
            ultraGridColumn128.Hidden = true;
            ultraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn86.Header.Editor = null;
            ultraGridColumn86.Header.VisiblePosition = 8;
            ultraGridColumn86.Hidden = true;
            ultraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn130.Header.Editor = null;
            ultraGridColumn130.Header.VisiblePosition = 52;
            ultraGridColumn130.RowLayoutColumnInfo.OriginX = 7;
            ultraGridColumn130.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn130.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(418, 0);
            ultraGridColumn130.RowLayoutColumnInfo.SpanX = 10;
            ultraGridColumn130.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn130.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn131.Header.Editor = null;
            ultraGridColumn131.Header.VisiblePosition = 53;
            ultraGridColumn131.Hidden = true;
            ultraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn132.Header.Editor = null;
            ultraGridColumn132.Header.VisiblePosition = 54;
            ultraGridColumn132.Hidden = true;
            ultraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn133.Header.Editor = null;
            ultraGridColumn133.Header.VisiblePosition = 55;
            ultraGridColumn133.Hidden = true;
            ultraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn134.Header.Editor = null;
            ultraGridColumn134.Header.VisiblePosition = 56;
            ultraGridColumn134.Hidden = true;
            ultraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn136.Header.Editor = null;
            ultraGridColumn136.Header.VisiblePosition = 57;
            ultraGridColumn136.Hidden = true;
            ultraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn135.Header.Editor = null;
            ultraGridColumn135.Header.VisiblePosition = 58;
            ultraGridColumn135.Hidden = true;
            ultraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn129.Header.Caption = "Voraussichtliches Ende";
            ultraGridColumn129.Header.Editor = null;
            ultraGridColumn129.Header.VisiblePosition = 51;
            ultraGridColumn129.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn129.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn129.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn129.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn129.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn127.Header.Editor = null;
            ultraGridColumn127.Header.VisiblePosition = 49;
            ultraGridColumn127.Hidden = true;
            ultraGridColumn137.Header.Editor = null;
            ultraGridColumn137.Header.VisiblePosition = 59;
            ultraGridColumn137.Hidden = true;
            ultraGridColumn137.HiddenWhenGroupBy = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn143.Header.Editor = null;
            ultraGridColumn143.Header.VisiblePosition = 65;
            ultraGridColumn143.Hidden = true;
            ultraGridColumn138.Header.Editor = null;
            ultraGridColumn138.Header.VisiblePosition = 60;
            ultraGridColumn138.Hidden = true;
            ultraGridColumn139.Header.Editor = null;
            ultraGridColumn139.Header.VisiblePosition = 61;
            ultraGridColumn139.Hidden = true;
            ultraGridColumn140.Header.Editor = null;
            ultraGridColumn140.Header.VisiblePosition = 62;
            ultraGridColumn140.Hidden = true;
            ultraGridColumn141.Header.Editor = null;
            ultraGridColumn141.Header.VisiblePosition = 63;
            ultraGridColumn141.Hidden = true;
            ultraGridColumn142.Header.Editor = null;
            ultraGridColumn142.Header.VisiblePosition = 64;
            ultraGridColumn142.Hidden = true;
            ultraGridColumn144.Header.Editor = null;
            ultraGridColumn144.Header.VisiblePosition = 66;
            ultraGridColumn145.Header.Editor = null;
            ultraGridColumn145.Header.VisiblePosition = 67;
            ultraGridColumn146.Header.Editor = null;
            ultraGridColumn146.Header.VisiblePosition = 68;
            ultraGridColumn147.Header.Editor = null;
            ultraGridColumn147.Header.VisiblePosition = 69;
            ultraGridColumn148.Header.Editor = null;
            ultraGridColumn148.Header.VisiblePosition = 70;
            ultraGridColumn149.Header.Editor = null;
            ultraGridColumn149.Header.VisiblePosition = 71;
            ultraGridColumn150.Header.Editor = null;
            ultraGridColumn150.Header.VisiblePosition = 72;
            ultraGridColumn151.Header.Editor = null;
            ultraGridColumn151.Header.VisiblePosition = 73;
            ultraGridColumn152.Header.Editor = null;
            ultraGridColumn152.Header.VisiblePosition = 74;
            ultraGridColumn153.Header.Editor = null;
            ultraGridColumn153.Header.VisiblePosition = 75;
            ultraGridColumn154.Header.Editor = null;
            ultraGridColumn154.Header.VisiblePosition = 76;
            ultraGridColumn155.Header.Editor = null;
            ultraGridColumn155.Header.VisiblePosition = 77;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 78;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 79;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 80;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 81;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 82;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 83;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 84;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 85;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 86;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 87;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 88;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 89;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 90;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 91;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 92;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 93;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 94;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 95;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 96;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 97;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 98;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 99;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 100;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96,
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn99,
            ultraGridColumn100,
            ultraGridColumn101,
            ultraGridColumn102,
            ultraGridColumn103,
            ultraGridColumn104,
            ultraGridColumn105,
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108,
            ultraGridColumn109,
            ultraGridColumn110,
            ultraGridColumn111,
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114,
            ultraGridColumn115,
            ultraGridColumn116,
            ultraGridColumn117,
            ultraGridColumn118,
            ultraGridColumn119,
            ultraGridColumn120,
            ultraGridColumn121,
            ultraGridColumn122,
            ultraGridColumn123,
            ultraGridColumn124,
            ultraGridColumn125,
            ultraGridColumn126,
            ultraGridColumn128,
            ultraGridColumn86,
            ultraGridColumn130,
            ultraGridColumn131,
            ultraGridColumn132,
            ultraGridColumn133,
            ultraGridColumn134,
            ultraGridColumn136,
            ultraGridColumn135,
            ultraGridColumn129,
            ultraGridColumn127,
            ultraGridColumn137,
            ultraGridColumn143,
            ultraGridColumn138,
            ultraGridColumn139,
            ultraGridColumn140,
            ultraGridColumn141,
            ultraGridColumn142,
            ultraGridColumn144,
            ultraGridColumn145,
            ultraGridColumn146,
            ultraGridColumn147,
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151,
            ultraGridColumn152,
            ultraGridColumn153,
            ultraGridColumn154,
            ultraGridColumn155,
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
            ultraGridColumn23});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridUnterbringung.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridUnterbringung.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridUnterbringung.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.gridUnterbringung.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridUnterbringung.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridUnterbringung.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridUnterbringung.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridUnterbringung.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.gridUnterbringung.DisplayLayout.MaxColScrollRegions = 1;
            this.gridUnterbringung.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridUnterbringung.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridUnterbringung.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.gridUnterbringung.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridUnterbringung.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.gridUnterbringung.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridUnterbringung.DisplayLayout.Override.CellAppearance = appearance9;
            this.gridUnterbringung.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.gridUnterbringung.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.TextHAlignAsString = "Left";
            this.gridUnterbringung.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.gridUnterbringung.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridUnterbringung.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.gridUnterbringung.DisplayLayout.Override.RowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridUnterbringung.DisplayLayout.Override.RowSelectorAppearance = appearance13;
            this.gridUnterbringung.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridUnterbringung.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.gridUnterbringung.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridUnterbringung.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridUnterbringung.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridUnterbringung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 2;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.gridUnterbringung, gridBagConstraint1);
            this.gridUnterbringung.Location = new System.Drawing.Point(5, 2);
            this.gridUnterbringung.Name = "gridUnterbringung";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.gridUnterbringung, new System.Drawing.Size(291, 117));
            this.gridUnterbringung.Size = new System.Drawing.Size(1074, 248);
            this.gridUnterbringung.TabIndex = 12;
            this.gridUnterbringung.Text = "ultraGrid22";
            this.gridUnterbringung.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridUnterbringung_AfterCellUpdate);
            this.gridUnterbringung.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridUnterbringung_InitializeLayout);
            this.gridUnterbringung.AfterRowActivate += new System.EventHandler(this.gridUnterbringung_AfterRowActivate);
            this.gridUnterbringung.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridUnterbringung_CellChange);
            this.gridUnterbringung.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.gridUnterbringung_DoubleClickCell);
            this.gridUnterbringung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridUnterbringung_KeyDown);
            // 
            // dsUnterbringungBindingSource
            // 
            this.dsUnterbringungBindingSource.DataSource = this.dsUnterbringung;
            this.dsUnterbringungBindingSource.Position = 0;
            // 
            // dsUnterbringung
            // 
            this.dsUnterbringung.DataSetName = "dsUnterbringung";
            this.dsUnterbringung.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSendenUnterbringung);
            this.panelButtons.Controls.Add(this.btnDelUnterbringung);
            this.panelButtons.Controls.Add(this.btnVerlaeng);
            this.panelButtons.Controls.Add(this.btnPreview);
            this.panelButtons.Controls.Add(this.btnAddUnterbringung);
            this.panelButtons.Controls.Add(this.btnHistorie);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(3, 19);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1084, 30);
            this.panelButtons.TabIndex = 39;
            // 
            // btnSendenUnterbringung
            // 
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSendenUnterbringung.Appearance = appearance15;
            this.btnSendenUnterbringung.AutoWorkLayout = false;
            this.btnSendenUnterbringung.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSendenUnterbringung.IsStandardControl = false;
            this.btnSendenUnterbringung.Location = new System.Drawing.Point(6, 1);
            this.btnSendenUnterbringung.Name = "btnSendenUnterbringung";
            this.btnSendenUnterbringung.Size = new System.Drawing.Size(80, 25);
            this.btnSendenUnterbringung.TabIndex = 40;
            this.btnSendenUnterbringung.Text = "Senden";
            this.btnSendenUnterbringung.Click += new System.EventHandler(this.btnSendenUnterbringung_Click);
            // 
            // btnDelUnterbringung
            // 
            this.btnDelUnterbringung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDelUnterbringung.Appearance = appearance16;
            this.btnDelUnterbringung.AutoWorkLayout = false;
            this.btnDelUnterbringung.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelUnterbringung.IsStandardControl = false;
            this.btnDelUnterbringung.Location = new System.Drawing.Point(696, 1);
            this.btnDelUnterbringung.Name = "btnDelUnterbringung";
            this.btnDelUnterbringung.Size = new System.Drawing.Size(103, 26);
            this.btnDelUnterbringung.TabIndex = 39;
            this.btnDelUnterbringung.Text = "Beenden";
            this.btnDelUnterbringung.Click += new System.EventHandler(this.btnDelUnterbringung_Click);
            // 
            // btnVerlaeng
            // 
            this.btnVerlaeng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnVerlaeng.Appearance = appearance17;
            this.btnVerlaeng.AutoWorkLayout = false;
            this.btnVerlaeng.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnVerlaeng.ImageSize = new System.Drawing.Size(12, 12);
            this.btnVerlaeng.IsStandardControl = false;
            this.btnVerlaeng.Location = new System.Drawing.Point(802, 1);
            this.btnVerlaeng.Name = "btnVerlaeng";
            this.btnVerlaeng.Size = new System.Drawing.Size(103, 26);
            this.btnVerlaeng.TabIndex = 16;
            this.btnVerlaeng.Text = "Verlängern";
            this.btnVerlaeng.Click += new System.EventHandler(this.btnVerlaeng_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnPreview.Appearance = appearance18;
            this.btnPreview.AutoWorkLayout = false;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPreview.IsStandardControl = false;
            this.btnPreview.Location = new System.Drawing.Point(997, 1);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(83, 26);
            this.btnPreview.TabIndex = 38;
            this.btnPreview.Text = "Drucken";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnAddUnterbringung
            // 
            this.btnAddUnterbringung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance19.BackColor = System.Drawing.Color.Transparent;
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddUnterbringung.Appearance = appearance19;
            this.btnAddUnterbringung.AutoWorkLayout = false;
            this.btnAddUnterbringung.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddUnterbringung.DoOnClick = true;
            this.btnAddUnterbringung.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddUnterbringung.IsStandardControl = true;
            this.btnAddUnterbringung.Location = new System.Drawing.Point(664, 1);
            this.btnAddUnterbringung.Name = "btnAddUnterbringung";
            this.btnAddUnterbringung.Size = new System.Drawing.Size(26, 26);
            this.btnAddUnterbringung.TabIndex = 14;
            this.btnAddUnterbringung.TabStop = false;
            this.btnAddUnterbringung.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddUnterbringung.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddUnterbringung.Click += new System.EventHandler(this.btnAddUnterbringung_Click);
            // 
            // btnHistorie
            // 
            this.btnHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnHistorie.Appearance = appearance20;
            this.btnHistorie.AutoWorkLayout = false;
            this.btnHistorie.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHistorie.IsStandardControl = false;
            this.btnHistorie.Location = new System.Drawing.Point(907, 1);
            this.btnHistorie.Name = "btnHistorie";
            this.btnHistorie.Size = new System.Drawing.Size(87, 26);
            this.btnHistorie.TabIndex = 37;
            this.btnHistorie.Text = "Öffnen";
            ultraToolTipInfo1.ToolTipText = "Auswahl zur Ansicht öffnen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnHistorie, ultraToolTipInfo1);
            this.btnHistorie.Click += new System.EventHandler(this.btnHistorie_Click);
            // 
            // grpPatientverfügung
            // 
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.grpPatientverfügung.Appearance = appearance21;
            this.grpPatientverfügung.Controls.Add(this.optBeachtlich);
            this.grpPatientverfügung.Controls.Add(this.lblAnmerkung);
            this.grpPatientverfügung.Controls.Add(this.ultraLabel1);
            this.grpPatientverfügung.Controls.Add(this.dtPatVerf);
            this.grpPatientverfügung.Controls.Add(this.txtVerfAnmerkung);
            this.grpPatientverfügung.Controls.Add(this.cbpatVerf);
            this.grpPatientverfügung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpPatientverfügung.Location = new System.Drawing.Point(7, 2);
            this.grpPatientverfügung.Name = "grpPatientverfügung";
            this.grpPatientverfügung.Size = new System.Drawing.Size(511, 130);
            this.grpPatientverfügung.TabIndex = 157;
            this.grpPatientverfügung.Text = "Patientenverfügung";
            // 
            // optBeachtlich
            // 
            this.optBeachtlich.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = true;
            valueListItem1.DisplayText = "Beachtlich";
            valueListItem2.DataValue = false;
            valueListItem2.DisplayText = "Verbindlich";
            this.optBeachtlich.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.optBeachtlich.Location = new System.Drawing.Point(79, 78);
            this.optBeachtlich.Name = "optBeachtlich";
            this.optBeachtlich.Size = new System.Drawing.Size(89, 40);
            this.optBeachtlich.TabIndex = 2;
            this.optBeachtlich.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblAnmerkung
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.lblAnmerkung.Appearance = appearance22;
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(186, 22);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(75, 17);
            this.lblAnmerkung.TabIndex = 148;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // ultraLabel1
            // 
            appearance23.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance23;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(28, 50);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(45, 17);
            this.ultraLabel1.TabIndex = 147;
            this.ultraLabel1.Text = "Datum";
            // 
            // txtVerfAnmerkung
            // 
            this.txtVerfAnmerkung.AutoSize = false;
            this.txtVerfAnmerkung.Location = new System.Drawing.Point(186, 44);
            this.txtVerfAnmerkung.MaxLength = 255;
            this.txtVerfAnmerkung.Multiline = true;
            this.txtVerfAnmerkung.Name = "txtVerfAnmerkung";
            this.txtVerfAnmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtVerfAnmerkung.Size = new System.Drawing.Size(319, 81);
            this.txtVerfAnmerkung.TabIndex = 4;
            this.txtVerfAnmerkung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbpatVerf
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            appearance25.BackColorDisabled = System.Drawing.Color.White;
            this.cbpatVerf.Appearance = appearance25;
            this.cbpatVerf.BackColor = System.Drawing.Color.Transparent;
            this.cbpatVerf.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbpatVerf.Location = new System.Drawing.Point(6, 22);
            this.cbpatVerf.Name = "cbpatVerf";
            this.cbpatVerf.Size = new System.Drawing.Size(149, 20);
            this.cbpatVerf.TabIndex = 1;
            this.cbpatVerf.Text = "Patientenverfügung";
            this.cbpatVerf.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraGroupBoxRelgiöseWünsche
            // 
            appearance31.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBoxRelgiöseWünsche.Appearance = appearance31;
            this.ultraGroupBoxRelgiöseWünsche.Controls.Add(this.lblAnmerkung2);
            this.ultraGroupBoxRelgiöseWünsche.Controls.Add(this.cbkrakSalbung);
            this.ultraGroupBoxRelgiöseWünsche.Controls.Add(this.cbKommunion);
            this.ultraGroupBoxRelgiöseWünsche.Controls.Add(this.txtReligioneWuen);
            this.ultraGroupBoxRelgiöseWünsche.Location = new System.Drawing.Point(7, 134);
            this.ultraGroupBoxRelgiöseWünsche.Name = "ultraGroupBoxRelgiöseWünsche";
            this.ultraGroupBoxRelgiöseWünsche.Size = new System.Drawing.Size(511, 100);
            this.ultraGroupBoxRelgiöseWünsche.TabIndex = 158;
            this.ultraGroupBoxRelgiöseWünsche.Text = "Religiöse Wünsche";
            // 
            // lblAnmerkung2
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.lblAnmerkung2.Appearance = appearance32;
            this.lblAnmerkung2.AutoSize = true;
            this.lblAnmerkung2.Location = new System.Drawing.Point(186, 20);
            this.lblAnmerkung2.Name = "lblAnmerkung2";
            this.lblAnmerkung2.Size = new System.Drawing.Size(75, 17);
            this.lblAnmerkung2.TabIndex = 149;
            this.lblAnmerkung2.Text = "Anmerkung";
            // 
            // cbkrakSalbung
            // 
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.cbkrakSalbung.Appearance = appearance33;
            this.cbkrakSalbung.BackColor = System.Drawing.Color.Transparent;
            this.cbkrakSalbung.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbkrakSalbung.Location = new System.Drawing.Point(6, 45);
            this.cbkrakSalbung.Name = "cbkrakSalbung";
            this.cbkrakSalbung.Size = new System.Drawing.Size(145, 20);
            this.cbkrakSalbung.TabIndex = 6;
            this.cbkrakSalbung.Text = "Krankensalbung";
            this.cbkrakSalbung.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbKommunion
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.cbKommunion.Appearance = appearance34;
            this.cbKommunion.BackColor = System.Drawing.Color.Transparent;
            this.cbKommunion.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbKommunion.Location = new System.Drawing.Point(6, 22);
            this.cbKommunion.Name = "cbKommunion";
            this.cbKommunion.Size = new System.Drawing.Size(104, 20);
            this.cbKommunion.TabIndex = 5;
            this.cbKommunion.Text = "Kommunion";
            this.cbKommunion.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtReligioneWuen
            // 
            this.txtReligioneWuen.AutoSize = false;
            this.txtReligioneWuen.Location = new System.Drawing.Point(186, 42);
            this.txtReligioneWuen.MaxLength = 255;
            this.txtReligioneWuen.Multiline = true;
            this.txtReligioneWuen.Name = "txtReligioneWuen";
            this.txtReligioneWuen.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtReligioneWuen.Size = new System.Drawing.Size(319, 50);
            this.txtReligioneWuen.TabIndex = 7;
            this.txtReligioneWuen.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpRegelungen
            // 
            this.grpRegelungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.grpRegelungen.Appearance = appearance26;
            this.grpRegelungen.Controls.Add(this.panel3);
            this.grpRegelungen.Controls.Add(this.txtSonstRegel);
            this.grpRegelungen.Controls.Add(this.txtBesRegelung);
            this.grpRegelungen.Controls.Add(this.txtSterbeRegelung);
            this.grpRegelungen.Controls.Add(this.lblSonstige);
            this.grpRegelungen.Controls.Add(this.lblSterberegelung);
            this.grpRegelungen.Controls.Add(this.cmbPostregel);
            this.grpRegelungen.Controls.Add(this.lblPostregelung);
            this.grpRegelungen.Controls.Add(this.lblBesuchsregelung);
            this.grpRegelungen.Location = new System.Drawing.Point(524, 2);
            this.grpRegelungen.Name = "grpRegelungen";
            this.grpRegelungen.Size = new System.Drawing.Size(554, 232);
            this.grpRegelungen.TabIndex = 158;
            this.grpRegelungen.Text = "Regelungen";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(13, 197);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 28);
            this.panel3.TabIndex = 158;
            // 
            // txtSonstRegel
            // 
            this.txtSonstRegel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSonstRegel.AutoSize = false;
            this.txtSonstRegel.Location = new System.Drawing.Point(111, 177);
            this.txtSonstRegel.MaxLength = 255;
            this.txtSonstRegel.Multiline = true;
            this.txtSonstRegel.Name = "txtSonstRegel";
            this.txtSonstRegel.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtSonstRegel.Size = new System.Drawing.Size(434, 48);
            this.txtSonstRegel.TabIndex = 11;
            this.txtSonstRegel.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtBesRegelung
            // 
            this.txtBesRegelung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBesRegelung.AutoSize = false;
            this.txtBesRegelung.Location = new System.Drawing.Point(111, 81);
            this.txtBesRegelung.MaxLength = 255;
            this.txtBesRegelung.Multiline = true;
            this.txtBesRegelung.Name = "txtBesRegelung";
            this.txtBesRegelung.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtBesRegelung.Size = new System.Drawing.Size(434, 54);
            this.txtBesRegelung.TabIndex = 9;
            this.txtBesRegelung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtSterbeRegelung
            // 
            this.txtSterbeRegelung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSterbeRegelung.AutoSize = false;
            this.txtSterbeRegelung.Location = new System.Drawing.Point(111, 20);
            this.txtSterbeRegelung.Multiline = true;
            this.txtSterbeRegelung.Name = "txtSterbeRegelung";
            this.txtSterbeRegelung.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtSterbeRegelung.Size = new System.Drawing.Size(434, 54);
            this.txtSterbeRegelung.TabIndex = 8;
            this.txtSterbeRegelung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblSonstige
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.lblSonstige.Appearance = appearance27;
            this.lblSonstige.AutoSize = true;
            this.lblSonstige.Location = new System.Drawing.Point(6, 178);
            this.lblSonstige.Name = "lblSonstige";
            this.lblSonstige.Size = new System.Drawing.Size(58, 17);
            this.lblSonstige.TabIndex = 157;
            this.lblSonstige.Text = "Sonstige";
            // 
            // lblSterberegelung
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.lblSterberegelung.Appearance = appearance28;
            this.lblSterberegelung.AutoSize = true;
            this.lblSterberegelung.Location = new System.Drawing.Point(6, 22);
            this.lblSterberegelung.Name = "lblSterberegelung";
            this.lblSterberegelung.Size = new System.Drawing.Size(99, 17);
            this.lblSterberegelung.TabIndex = 156;
            this.lblSterberegelung.Text = "Sterberegelung";
            // 
            // cmbPostregel
            // 
            this.cmbPostregel.AddEmptyEntry = false;
            this.cmbPostregel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPostregel.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbPostregel.AutoOpenCBO = false;
            this.cmbPostregel.BerufsstandGruppeJNA = -1;
            this.cmbPostregel.ExactMatch = false;
            this.cmbPostregel.Group = "PRG";
            this.cmbPostregel.IgnoreUnterdruecken = true;
            this.cmbPostregel.Location = new System.Drawing.Point(111, 145);
            this.cmbPostregel.MaxLength = 255;
            this.cmbPostregel.Name = "cmbPostregel";
            this.cmbPostregel.PflichtJN = false;
            this.cmbPostregel.SelectDistinct = false;
            this.cmbPostregel.ShowAddButton = true;
            this.cmbPostregel.Size = new System.Drawing.Size(434, 24);
            this.cmbPostregel.sys = false;
            this.cmbPostregel.TabIndex = 10;
            this.cmbPostregel.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPostregelung
            // 
            appearance29.BackColor = System.Drawing.Color.Transparent;
            this.lblPostregelung.Appearance = appearance29;
            this.lblPostregelung.AutoSize = true;
            this.lblPostregelung.Location = new System.Drawing.Point(6, 144);
            this.lblPostregelung.Name = "lblPostregelung";
            this.lblPostregelung.Size = new System.Drawing.Size(86, 17);
            this.lblPostregelung.TabIndex = 155;
            this.lblPostregelung.Text = "Postregelung";
            // 
            // lblBesuchsregelung
            // 
            appearance30.BackColor = System.Drawing.Color.Transparent;
            this.lblBesuchsregelung.Appearance = appearance30;
            this.lblBesuchsregelung.AutoSize = true;
            this.lblBesuchsregelung.Location = new System.Drawing.Point(6, 84);
            this.lblBesuchsregelung.Name = "lblBesuchsregelung";
            this.lblBesuchsregelung.Size = new System.Drawing.Size(111, 17);
            this.lblBesuchsregelung.TabIndex = 154;
            this.lblBesuchsregelung.Text = "Besuchsregelung";
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.ultraGridBagLayoutPanel2.Controls.Add(this.panelOben);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(1100, 251);
            this.ultraGridBagLayoutPanel2.TabIndex = 160;
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.grpPatientverfügung);
            this.panelOben.Controls.Add(this.grpRegelungen);
            this.panelOben.Controls.Add(this.ultraGroupBoxRelgiöseWünsche);
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.Insets.Bottom = 5;
            gridBagConstraint3.Insets.Left = 5;
            gridBagConstraint3.Insets.Right = 5;
            gridBagConstraint3.Insets.Top = 5;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.panelOben, gridBagConstraint3);
            this.panelOben.Location = new System.Drawing.Point(5, 5);
            this.panelOben.Name = "panelOben";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.panelOben, new System.Drawing.Size(198, 98));
            this.panelOben.Size = new System.Drawing.Size(1090, 241);
            this.panelOben.TabIndex = 0;
            // 
            // ultraGridBagLayoutPanel3
            // 
            this.ultraGridBagLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGridBagLayoutPanel3.Controls.Add(this.grpHeimaufenthaltsges);
            this.ultraGridBagLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel3.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel3.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraGridBagLayoutPanel3.Location = new System.Drawing.Point(0, 251);
            this.ultraGridBagLayoutPanel3.Name = "ultraGridBagLayoutPanel3";
            this.ultraGridBagLayoutPanel3.Size = new System.Drawing.Size(1100, 312);
            this.ultraGridBagLayoutPanel3.TabIndex = 161;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucRegelungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraGridBagLayoutPanel3);
            this.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucRegelungen";
            this.Size = new System.Drawing.Size(1100, 563);
            this.Load += new System.EventHandler(this.ucRegelungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPatVerf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeimaufenthaltsges)).EndInit();
            this.grpHeimaufenthaltsges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnterbringung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringungBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringung)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPatientverfügung)).EndInit();
            this.grpPatientverfügung.ResumeLayout(false);
            this.grpPatientverfügung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optBeachtlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerfAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbpatVerf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxRelgiöseWünsche)).EndInit();
            this.ultraGroupBoxRelgiöseWünsche.ResumeLayout(false);
            this.ultraGroupBoxRelgiöseWünsche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbkrakSalbung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKommunion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligioneWuen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRegelungen)).EndInit();
            this.grpRegelungen.ResumeLayout(false);
            this.grpRegelungen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstRegel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBesRegelung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSterbeRegelung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostregel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            this.panelOben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel3)).EndInit();
            this.ultraGridBagLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpHeimaufenthaltsges;
        private ucButton btnAddUnterbringung;
        private QS2.Desktop.ControlManagment.BaseGrid gridUnterbringung;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpPatientverfügung;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtPatVerf;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVerfAnmerkung;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbpatVerf;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxRelgiöseWünsche;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbkrakSalbung;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbKommunion;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtReligioneWuen;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpRegelungen;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSonstRegel;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBesRegelung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSterbeRegelung;
        private QS2.Desktop.ControlManagment.BaseLabel lblSonstige;
        private QS2.Desktop.ControlManagment.BaseLabel lblSterberegelung;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbPostregel;
        private QS2.Desktop.ControlManagment.BaseLabel lblPostregelung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBesuchsregelung;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung2;
        private QS2.Desktop.ControlManagment.BaseButton btnVerlaeng;
        private QS2.Desktop.ControlManagment.BaseButton btnHistorie;
        private QS2.Desktop.ControlManagment.BaseButton btnPreview;
        private System.Windows.Forms.BindingSource dsUnterbringungBindingSource;
        private dsUnterbringung dsUnterbringung;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel3;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseButton btnDelUnterbringung;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        public QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BaseOptionSet optBeachtlich;
        private QS2.Desktop.ControlManagment.BaseButton btnSendenUnterbringung;
    }
}
