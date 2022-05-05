namespace PMDS.GUI.Verordnungen
{
    partial class ucVOErfassen
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VO_Bestelldaten", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Typ", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedikament");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EigentumKlient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Menge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lieferant");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HinweisLieferant");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzergeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauerbestellung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumNaechsterAnspruch");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminEndetAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WiedWertJeden");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TagWochenMonat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("nTenMonat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Wochentage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinmaligeAnforderung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klient", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Medikament", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LieferantBeschreibung", 3);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(686348204);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(337493844);
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Add");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedikament");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Typ", -1, 686348204, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Menge");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Hinweis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumVerordnetAb", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumVerordnetBis");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BestaetigtVon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lieferant", -1, 337493844);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HinweisLieferant");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VO_VO_Bestelldaten1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klient", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Medikament", 1, null, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InfoMedDaten", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InfoPflegeplanPDx", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Krankenkasse", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SozVers", 6);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InfoWundeKopf", 7);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LieferantBeschreibung", 8);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BenutzerErstellt", 9);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BenutzerGeändert", 10);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VO_VO_Bestelldaten1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Typ", -1, 686348204, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedikament");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EigentumKlient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Menge");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lieferant", -1, 337493844);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HinweisLieferant");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn152 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn153 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn154 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn155 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzergeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn156 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn157 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn158 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauerbestellung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn159 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumNaechsterAnspruch");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn160 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminEndetAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn161 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn162 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WiedWertJeden");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn176 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TagWochenMonat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn177 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("nTenMonat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn178 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Wochentage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn179 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn180 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinmaligeAnforderung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn181 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klient", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn182 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Medikament", 1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList3 = new Infragistics.Win.ValueList(686348204);
            Infragistics.Win.ValueList valueList4 = new Infragistics.Win.ValueList(337493844);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            PMDS.DB.PMDSBusiness pmdsBusiness1 = new PMDS.DB.PMDSBusiness();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelVOBestelldatenGrid = new System.Windows.Forms.Panel();
            this.gridVOBestelldaten = new QS2.Desktop.ControlManagment.BaseGrid();
            this.contextMenuStripBestelldaten = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layoutmanagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsVO1 = new PMDS.Global.db.ERSystem.dsVO();
            this.btnAddVOBestelldatenEinmaligeAnforderung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddVOBestelldaten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelBestelldaten = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucLager1 = new PMDS.GUI.Verordnungen.ucLager();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddVO = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.contextMenuStripSys = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVOSchein = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddVOVerknüpfung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnWunde = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMedDaten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMedikamente = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.cboZustand = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblZustandLager = new Infragistics.Win.Misc.UltraLabel();
            this.udteVerordnetBis = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udteVerordnetAb = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblVerordnetBis = new Infragistics.Win.Misc.UltraLabel();
            this.lblVerordnetAb = new Infragistics.Win.Misc.UltraLabel();
            this.dropDownTyp = new Infragistics.Win.Misc.UltraDropDownButton();
            this.chkNurAktuelle = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.dropDownPatienten = new Infragistics.Win.Misc.UltraDropDownButton();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPrint = new QS2.Desktop.ControlManagment.BaseButton();
            this.contextMenuStripDrucken = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportDSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.grpPrint = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkPrintDetailsJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblFound = new Infragistics.Win.Misc.UltraLabel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.splitContainerCenter = new System.Windows.Forms.SplitContainer();
            this.panelVOGrid = new System.Windows.Forms.Panel();
            this.gridVO = new QS2.Desktop.ControlManagment.BaseGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSpace01 = new System.Windows.Forms.ToolStripSeparator();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtErweiternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtReduzierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uPopUpContPatienten = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uPopupContTyp = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.sqlVO1 = new PMDS.Global.db.ERSystem.sqlVO(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.panelVOBestelldatenGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVOBestelldaten)).BeginInit();
            this.contextMenuStripBestelldaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsVO1)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.contextMenuStripSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboZustand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteVerordnetBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteVerordnetAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktuelle)).BeginInit();
            this.contextMenuStripDrucken.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrint)).BeginInit();
            this.grpPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintDetailsJN)).BeginInit();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).BeginInit();
            this.splitContainerCenter.Panel1.SuspendLayout();
            this.splitContainerCenter.Panel2.SuspendLayout();
            this.splitContainerCenter.SuspendLayout();
            this.panelVOGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVO)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelVOBestelldatenGrid);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1063, 199);
            // 
            // panelVOBestelldatenGrid
            // 
            this.panelVOBestelldatenGrid.BackColor = System.Drawing.Color.White;
            this.panelVOBestelldatenGrid.Controls.Add(this.gridVOBestelldaten);
            this.panelVOBestelldatenGrid.Controls.Add(this.btnAddVOBestelldatenEinmaligeAnforderung);
            this.panelVOBestelldatenGrid.Controls.Add(this.btnAddVOBestelldaten);
            this.panelVOBestelldatenGrid.Controls.Add(this.btnDelBestelldaten);
            this.panelVOBestelldatenGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVOBestelldatenGrid.Location = new System.Drawing.Point(0, 0);
            this.panelVOBestelldatenGrid.Name = "panelVOBestelldatenGrid";
            this.panelVOBestelldatenGrid.Size = new System.Drawing.Size(1063, 199);
            this.panelVOBestelldatenGrid.TabIndex = 14;
            // 
            // gridVOBestelldaten
            // 
            this.gridVOBestelldaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVOBestelldaten.AutoWork = false;
            this.gridVOBestelldaten.ContextMenuStrip = this.contextMenuStripBestelldaten;
            this.gridVOBestelldaten.contextMenuStrip1 = this.contextMenuStripBestelldaten;
            this.gridVOBestelldaten.DataMember = "VO_Bestelldaten";
            this.gridVOBestelldaten.DataSource = this.dsVO1;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.SizeInPoints = 10F;
            this.gridVOBestelldaten.DisplayLayout.Appearance = appearance1;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 11;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 417;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Caption = "Gültig ab";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn23.Header.Caption = "Gültig bis";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 7;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 3;
            ultraGridColumn24.Width = 215;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 6;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Caption = "Eigentum Klient";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 8;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 9;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 12;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 13;
            ultraGridColumn30.Header.Caption = "Hinweis Lieferant";
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 15;
            ultraGridColumn30.Width = 180;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 10;
            ultraGridColumn31.Width = 261;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 18;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.Caption = "Login-Name frei erstellt";
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 20;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn35.Header.Caption = "Datum erstellt";
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 17;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 16;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.Caption = "Login-Name frei geändert";
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 25;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.Caption = "Datum geändert";
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 22;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 19;
            ultraGridColumn41.Header.Caption = "Datum nächster Anspruch";
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 21;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 23;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 24;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 26;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 27;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 28;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 30;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 31;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 29;
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 2;
            ultraGridColumn51.Width = 176;
            ultraGridColumn53.Header.Caption = "Verordnung";
            ultraGridColumn53.Header.Editor = null;
            ultraGridColumn53.Header.VisiblePosition = 4;
            ultraGridColumn53.Width = 337;
            ultraGridColumn54.DataType = typeof(bool);
            ultraGridColumn54.Header.Caption = "Auswahl";
            ultraGridColumn54.Header.Editor = null;
            ultraGridColumn54.Header.VisiblePosition = 0;
            ultraGridColumn54.Width = 67;
            ultraGridColumn55.Header.Caption = "Lieferant Beschreibung";
            ultraGridColumn55.Header.Editor = null;
            ultraGridColumn55.Header.VisiblePosition = 14;
            ultraGridColumn55.Width = 168;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn35,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55});
            this.gridVOBestelldaten.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridVOBestelldaten.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridVOBestelldaten.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridVOBestelldaten.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridVOBestelldaten.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridVOBestelldaten.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridVOBestelldaten.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridVOBestelldaten.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridVOBestelldaten.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance2.BorderColor = System.Drawing.Color.White;
            this.gridVOBestelldaten.DisplayLayout.Override.SummaryFooterAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.gridVOBestelldaten.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridVOBestelldaten.DisplayLayout.Override.SummaryValueAppearance = appearance4;
            this.gridVOBestelldaten.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Typ";
            valueList2.Key = "Lieferant";
            this.gridVOBestelldaten.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.gridVOBestelldaten.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridVOBestelldaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridVOBestelldaten.Location = new System.Drawing.Point(3, 29);
            this.gridVOBestelldaten.Margin = new System.Windows.Forms.Padding(4);
            this.gridVOBestelldaten.Name = "gridVOBestelldaten";
            this.gridVOBestelldaten.Size = new System.Drawing.Size(1058, 156);
            this.gridVOBestelldaten.TabIndex = 20;
            this.gridVOBestelldaten.Text = "Bestelldaten";
            this.gridVOBestelldaten.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridVOBestelldaten_BeforeCellActivate);
            this.gridVOBestelldaten.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridVOBestelldaten_BeforeRowsDeleted);
            this.gridVOBestelldaten.Click += new System.EventHandler(this.gridVOBestelldaten_Click);
            this.gridVOBestelldaten.DoubleClick += new System.EventHandler(this.gridVOBestelldaten_DoubleClick);
            // 
            // contextMenuStripBestelldaten
            // 
            this.contextMenuStripBestelldaten.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layoutmanagerToolStripMenuItem});
            this.contextMenuStripBestelldaten.Name = "contextMenuStripDrucken";
            this.contextMenuStripBestelldaten.Size = new System.Drawing.Size(158, 26);
            // 
            // layoutmanagerToolStripMenuItem
            // 
            this.layoutmanagerToolStripMenuItem.Name = "layoutmanagerToolStripMenuItem";
            this.layoutmanagerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.layoutmanagerToolStripMenuItem.Text = "Layoutmanager";
            this.layoutmanagerToolStripMenuItem.Click += new System.EventHandler(this.layoutmanagerToolStripMenuItem_Click);
            // 
            // dsVO1
            // 
            this.dsVO1.DataSetName = "dsVO";
            this.dsVO1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAddVOBestelldatenEinmaligeAnforderung
            // 
            this.btnAddVOBestelldatenEinmaligeAnforderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVOBestelldatenEinmaligeAnforderung.Appearance = appearance5;
            this.btnAddVOBestelldatenEinmaligeAnforderung.AutoWorkLayout = false;
            this.btnAddVOBestelldatenEinmaligeAnforderung.IsStandardControl = false;
            this.btnAddVOBestelldatenEinmaligeAnforderung.Location = new System.Drawing.Point(852, 1);
            this.btnAddVOBestelldatenEinmaligeAnforderung.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVOBestelldatenEinmaligeAnforderung.Name = "btnAddVOBestelldatenEinmaligeAnforderung";
            this.btnAddVOBestelldatenEinmaligeAnforderung.Size = new System.Drawing.Size(150, 27);
            this.btnAddVOBestelldatenEinmaligeAnforderung.TabIndex = 23;
            this.btnAddVOBestelldatenEinmaligeAnforderung.Tag = "";
            this.btnAddVOBestelldatenEinmaligeAnforderung.Text = "Einmalige Anforderung";
            this.btnAddVOBestelldatenEinmaligeAnforderung.Click += new System.EventHandler(this.btnAddVOBestelldatenEinmaligeAnforderung_Click);
            // 
            // btnAddVOBestelldaten
            // 
            this.btnAddVOBestelldaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVOBestelldaten.Appearance = appearance6;
            this.btnAddVOBestelldaten.AutoWorkLayout = false;
            this.btnAddVOBestelldaten.IsStandardControl = false;
            this.btnAddVOBestelldaten.Location = new System.Drawing.Point(1002, 1);
            this.btnAddVOBestelldaten.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVOBestelldaten.Name = "btnAddVOBestelldaten";
            this.btnAddVOBestelldaten.Size = new System.Drawing.Size(28, 27);
            this.btnAddVOBestelldaten.TabIndex = 10;
            this.btnAddVOBestelldaten.Tag = "";
            this.btnAddVOBestelldaten.Click += new System.EventHandler(this.btnAddVOBestelldaten_Click);
            // 
            // btnDelBestelldaten
            // 
            this.btnDelBestelldaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelBestelldaten.Appearance = appearance7;
            this.btnDelBestelldaten.AutoWorkLayout = false;
            this.btnDelBestelldaten.IsStandardControl = false;
            this.btnDelBestelldaten.Location = new System.Drawing.Point(1030, 1);
            this.btnDelBestelldaten.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelBestelldaten.Name = "btnDelBestelldaten";
            this.btnDelBestelldaten.Size = new System.Drawing.Size(28, 27);
            this.btnDelBestelldaten.TabIndex = 11;
            this.btnDelBestelldaten.Tag = "";
            this.btnDelBestelldaten.Click += new System.EventHandler(this.btnDelBestelldaten_Click);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ucLager1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1063, 207);
            // 
            // ucLager1
            // 
            this.ucLager1.BackColor = System.Drawing.Color.White;
            this.ucLager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLager1.Location = new System.Drawing.Point(0, 0);
            this.ucLager1.Name = "ucLager1";
            this.ucLager1.Size = new System.Drawing.Size(1063, 207);
            this.ucLager1.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance8;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(1031, 47);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 27);
            this.btnDel.TabIndex = 12;
            this.btnDel.Tag = "17";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddVO
            // 
            this.btnAddVO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVO.Appearance = appearance9;
            this.btnAddVO.AutoWorkLayout = false;
            this.btnAddVO.IsStandardControl = false;
            this.btnAddVO.Location = new System.Drawing.Point(1003, 47);
            this.btnAddVO.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVO.Name = "btnAddVO";
            this.btnAddVO.Size = new System.Drawing.Size(28, 27);
            this.btnAddVO.TabIndex = 11;
            this.btnAddVO.Tag = "16";
            this.btnAddVO.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance10;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(1020, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 20;
            this.btnClose.Tag = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.ContextMenuStrip = this.contextMenuStripSys;
            this.panelTop.Controls.Add(this.btnVOSchein);
            this.panelTop.Controls.Add(this.btnAddVOVerknüpfung);
            this.panelTop.Controls.Add(this.btnWunde);
            this.panelTop.Controls.Add(this.btnMedDaten);
            this.panelTop.Controls.Add(this.btnMedikamente);
            this.panelTop.Controls.Add(this.btnAddVO);
            this.panelTop.Controls.Add(this.grpSearch);
            this.panelTop.Controls.Add(this.btnDel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1067, 76);
            this.panelTop.TabIndex = 0;
            // 
            // contextMenuStripSys
            // 
            this.contextMenuStripSys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.contextMenuStripSys.Name = "contextMenuStripDrucken";
            this.contextMenuStripSys.Size = new System.Drawing.Size(272, 26);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(271, 22);
            this.toolStripMenuItem5.Text = "Alle Auswahllisten in VO aktualisieren";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // btnVOSchein
            // 
            this.btnVOSchein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnVOSchein.Appearance = appearance11;
            this.btnVOSchein.AutoWorkLayout = false;
            this.btnVOSchein.IsStandardControl = false;
            this.btnVOSchein.Location = new System.Drawing.Point(929, 47);
            this.btnVOSchein.Margin = new System.Windows.Forms.Padding(4);
            this.btnVOSchein.Name = "btnVOSchein";
            this.btnVOSchein.Size = new System.Drawing.Size(74, 27);
            this.btnVOSchein.TabIndex = 105;
            this.btnVOSchein.Tag = "";
            this.btnVOSchein.Text = "VO-Schein";
            this.btnVOSchein.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // btnAddVOVerknüpfung
            // 
            this.btnAddVOVerknüpfung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVOVerknüpfung.Appearance = appearance12;
            this.btnAddVOVerknüpfung.AutoWorkLayout = false;
            this.btnAddVOVerknüpfung.IsStandardControl = false;
            this.btnAddVOVerknüpfung.Location = new System.Drawing.Point(880, 47);
            this.btnAddVOVerknüpfung.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVOVerknüpfung.Name = "btnAddVOVerknüpfung";
            this.btnAddVOVerknüpfung.Size = new System.Drawing.Size(28, 27);
            this.btnAddVOVerknüpfung.TabIndex = 104;
            this.btnAddVOVerknüpfung.Tag = "15";
            this.btnAddVOVerknüpfung.Visible = false;
            this.btnAddVOVerknüpfung.Click += new System.EventHandler(this.btnAddVOVerknüpfung_Click);
            // 
            // btnWunde
            // 
            this.btnWunde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.btnWunde.Appearance = appearance13;
            this.btnWunde.AutoWorkLayout = false;
            this.btnWunde.IsStandardControl = false;
            this.btnWunde.Location = new System.Drawing.Point(852, 47);
            this.btnWunde.Name = "btnWunde";
            this.btnWunde.Size = new System.Drawing.Size(28, 27);
            this.btnWunde.TabIndex = 103;
            this.btnWunde.Tag = "13";
            this.btnWunde.Click += new System.EventHandler(this.btnWunde_Click);
            // 
            // btnMedDaten
            // 
            this.btnMedDaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.btnMedDaten.Appearance = appearance14;
            this.btnMedDaten.AutoWorkLayout = false;
            this.btnMedDaten.IsStandardControl = false;
            this.btnMedDaten.Location = new System.Drawing.Point(824, 47);
            this.btnMedDaten.Name = "btnMedDaten";
            this.btnMedDaten.Size = new System.Drawing.Size(28, 27);
            this.btnMedDaten.TabIndex = 102;
            this.btnMedDaten.Tag = "12";
            this.btnMedDaten.Click += new System.EventHandler(this.btnMedDaten_Click);
            // 
            // btnMedikamente
            // 
            this.btnMedikamente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.btnMedikamente.Appearance = appearance15;
            this.btnMedikamente.AutoWorkLayout = false;
            this.btnMedikamente.IsStandardControl = false;
            this.btnMedikamente.Location = new System.Drawing.Point(796, 47);
            this.btnMedikamente.Name = "btnMedikamente";
            this.btnMedikamente.Size = new System.Drawing.Size(28, 27);
            this.btnMedikamente.TabIndex = 101;
            this.btnMedikamente.Tag = "11";
            this.btnMedikamente.Click += new System.EventHandler(this.btnMedikamente_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpSearch.Controls.Add(this.cboZustand);
            this.grpSearch.Controls.Add(this.lblZustandLager);
            this.grpSearch.Controls.Add(this.udteVerordnetBis);
            this.grpSearch.Controls.Add(this.udteVerordnetAb);
            this.grpSearch.Controls.Add(this.lblVerordnetBis);
            this.grpSearch.Controls.Add(this.lblVerordnetAb);
            this.grpSearch.Controls.Add(this.dropDownTyp);
            this.grpSearch.Controls.Add(this.chkNurAktuelle);
            this.grpSearch.Controls.Add(this.dropDownPatienten);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(8, 2);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(781, 72);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.Text = "Suche";
            // 
            // cboZustand
            // 
            this.cboZustand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboZustand.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            appearance16.Image = global::PMDS.GUI.Properties.Resources.ico_Plus;
            editorButton1.Appearance = appearance16;
            editorButton1.Key = "Add";
            this.cboZustand.ButtonsRight.Add(editorButton1);
            this.cboZustand.Location = new System.Drawing.Point(518, 14);
            this.cboZustand.Name = "cboZustand";
            this.cboZustand.Size = new System.Drawing.Size(182, 21);
            this.cboZustand.TabIndex = 42;
            this.cboZustand.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cboZustand_EditorButtonClick);
            // 
            // lblZustandLager
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.lblZustandLager.Appearance = appearance17;
            this.lblZustandLager.AutoSize = true;
            this.lblZustandLager.Location = new System.Drawing.Point(435, 16);
            this.lblZustandLager.Name = "lblZustandLager";
            this.lblZustandLager.Size = new System.Drawing.Size(77, 14);
            this.lblZustandLager.TabIndex = 43;
            this.lblZustandLager.Text = "Lager Zustand";
            // 
            // udteVerordnetBis
            // 
            this.udteVerordnetBis.Location = new System.Drawing.Point(334, 44);
            this.udteVerordnetBis.Name = "udteVerordnetBis";
            this.udteVerordnetBis.Size = new System.Drawing.Size(92, 21);
            this.udteVerordnetBis.TabIndex = 3;
            // 
            // udteVerordnetAb
            // 
            this.udteVerordnetAb.Location = new System.Drawing.Point(334, 14);
            this.udteVerordnetAb.Name = "udteVerordnetAb";
            this.udteVerordnetAb.Size = new System.Drawing.Size(92, 21);
            this.udteVerordnetAb.TabIndex = 2;
            // 
            // lblVerordnetBis
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.lblVerordnetBis.Appearance = appearance18;
            this.lblVerordnetBis.AutoSize = true;
            this.lblVerordnetBis.Location = new System.Drawing.Point(241, 46);
            this.lblVerordnetBis.Name = "lblVerordnetBis";
            this.lblVerordnetBis.Size = new System.Drawing.Size(71, 14);
            this.lblVerordnetBis.TabIndex = 18;
            this.lblVerordnetBis.Text = "Verordnet bis";
            // 
            // lblVerordnetAb
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.lblVerordnetAb.Appearance = appearance19;
            this.lblVerordnetAb.AutoSize = true;
            this.lblVerordnetAb.Location = new System.Drawing.Point(241, 16);
            this.lblVerordnetAb.Name = "lblVerordnetAb";
            this.lblVerordnetAb.Size = new System.Drawing.Size(75, 14);
            this.lblVerordnetAb.TabIndex = 17;
            this.lblVerordnetAb.Text = "Verordnet von";
            // 
            // dropDownTyp
            // 
            appearance20.TextHAlignAsString = "Center";
            this.dropDownTyp.Appearance = appearance20;
            this.dropDownTyp.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownTyp.Location = new System.Drawing.Point(9, 13);
            this.dropDownTyp.Name = "dropDownTyp";
            this.dropDownTyp.Size = new System.Drawing.Size(126, 22);
            this.dropDownTyp.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownTyp.TabIndex = 13;
            this.dropDownTyp.TabStop = false;
            this.dropDownTyp.Tag = "";
            this.dropDownTyp.Text = "Typ";
            // 
            // chkNurAktuelle
            // 
            this.chkNurAktuelle.Location = new System.Drawing.Point(146, 15);
            this.chkNurAktuelle.Name = "chkNurAktuelle";
            this.chkNurAktuelle.Size = new System.Drawing.Size(97, 18);
            this.chkNurAktuelle.TabIndex = 4;
            this.chkNurAktuelle.Text = "Nur aktuelle";
            this.chkNurAktuelle.CheckedChanged += new System.EventHandler(this.chkNurAktuelle_CheckedChanged);
            // 
            // dropDownPatienten
            // 
            appearance21.TextHAlignAsString = "Center";
            this.dropDownPatienten.Appearance = appearance21;
            this.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownPatienten.Location = new System.Drawing.Point(9, 43);
            this.dropDownPatienten.Name = "dropDownPatienten";
            this.dropDownPatienten.Size = new System.Drawing.Size(126, 22);
            this.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownPatienten.TabIndex = 1;
            this.dropDownPatienten.Tag = "";
            this.dropDownPatienten.Text = "Klienten";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance22.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance22;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(705, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 54);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Tag = "";
            this.btnSearch.Text = "Suchen";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance23;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.ContextMenuStrip = this.contextMenuStripDrucken;
            this.btnPrint.contextMenuStrip1 = this.contextMenuStripDrucken;
            this.btnPrint.IsStandardControl = false;
            this.btnPrint.Location = new System.Drawing.Point(74, 12);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 28);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Tag = "";
            this.btnPrint.Text = "Drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // contextMenuStripDrucken
            // 
            this.contextMenuStripDrucken.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDSToolStripMenuItem});
            this.contextMenuStripDrucken.Name = "contextMenuStripDrucken";
            this.contextMenuStripDrucken.Size = new System.Drawing.Size(126, 26);
            // 
            // exportDSToolStripMenuItem
            // 
            this.exportDSToolStripMenuItem.Name = "exportDSToolStripMenuItem";
            this.exportDSToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exportDSToolStripMenuItem.Text = "Export DS";
            this.exportDSToolStripMenuItem.Click += new System.EventHandler(this.exportDSToolStripMenuItem_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.grpPrint);
            this.panelBottom.Controls.Add(this.btnAbort);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 525);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1067, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // grpPrint
            // 
            this.grpPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrint.Controls.Add(this.btnPrint);
            this.grpPrint.Controls.Add(this.chkPrintDetailsJN);
            this.grpPrint.Location = new System.Drawing.Point(631, 2);
            this.grpPrint.Name = "grpPrint";
            this.grpPrint.Size = new System.Drawing.Size(164, 43);
            this.grpPrint.TabIndex = 22;
            this.grpPrint.Text = "Drucken";
            // 
            // chkPrintDetailsJN
            // 
            this.chkPrintDetailsJN.Location = new System.Drawing.Point(11, 18);
            this.chkPrintDetailsJN.Name = "chkPrintDetailsJN";
            this.chkPrintDetailsJN.Size = new System.Drawing.Size(61, 18);
            this.chkPrintDetailsJN.TabIndex = 21;
            this.chkPrintDetailsJN.Text = "Details";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance24.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance24;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(828, 11);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(81, 30);
            this.btnAbort.TabIndex = 11;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance25;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(911, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance26.TextVAlignAsString = "Middle";
            this.lblFound.Appearance = appearance26;
            this.lblFound.Location = new System.Drawing.Point(6, 201);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(137, 16);
            this.lblFound.TabIndex = 22;
            this.lblFound.Text = "Gefunden: 12";
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.LightGray;
            this.panelCenter.Controls.Add(this.splitContainerCenter);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 76);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1067, 449);
            this.panelCenter.TabIndex = 111;
            // 
            // splitContainerCenter
            // 
            this.splitContainerCenter.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCenter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCenter.Name = "splitContainerCenter";
            this.splitContainerCenter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCenter.Panel1
            // 
            this.splitContainerCenter.Panel1.Controls.Add(this.panelVOGrid);
            // 
            // splitContainerCenter.Panel2
            // 
            this.splitContainerCenter.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerCenter.Panel2.Controls.Add(this.ultraTabControl1);
            this.splitContainerCenter.Size = new System.Drawing.Size(1067, 449);
            this.splitContainerCenter.SplitterDistance = 221;
            this.splitContainerCenter.SplitterWidth = 3;
            this.splitContainerCenter.TabIndex = 13;
            // 
            // panelVOGrid
            // 
            this.panelVOGrid.BackColor = System.Drawing.Color.White;
            this.panelVOGrid.Controls.Add(this.gridVO);
            this.panelVOGrid.Controls.Add(this.lblFound);
            this.panelVOGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVOGrid.Location = new System.Drawing.Point(0, 0);
            this.panelVOGrid.Name = "panelVOGrid";
            this.panelVOGrid.Size = new System.Drawing.Size(1067, 221);
            this.panelVOGrid.TabIndex = 13;
            // 
            // gridVO
            // 
            this.gridVO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVO.AutoWork = true;
            this.gridVO.ContextMenuStrip = this.contextMenuStripGrid;
            this.gridVO.contextMenuStrip1 = this.contextMenuStripGrid;
            this.gridVO.DataMember = "VO";
            this.gridVO.DataSource = this.dsVO1;
            appearance27.BackColor = System.Drawing.Color.White;
            appearance27.FontData.SizeInPoints = 10F;
            this.gridVO.DisplayLayout.Appearance = appearance27;
            ultraGridColumn56.Header.Editor = null;
            ultraGridColumn56.Header.VisiblePosition = 7;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn56.Width = 417;
            ultraGridColumn57.Header.Editor = null;
            ultraGridColumn57.Header.VisiblePosition = 1;
            ultraGridColumn57.Hidden = true;
            ultraGridColumn58.Header.Editor = null;
            ultraGridColumn58.Header.VisiblePosition = 2;
            ultraGridColumn58.Hidden = true;
            ultraGridColumn59.Header.Editor = null;
            ultraGridColumn59.Header.VisiblePosition = 4;
            ultraGridColumn59.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn59.Width = 247;
            appearance28.TextHAlignAsString = "Right";
            ultraGridColumn61.CellAppearance = appearance28;
            appearance29.TextHAlignAsString = "Right";
            ultraGridColumn61.Header.Appearance = appearance29;
            ultraGridColumn61.Header.Editor = null;
            ultraGridColumn61.Header.VisiblePosition = 10;
            ultraGridColumn61.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin;
            ultraGridColumn61.Width = 96;
            ultraGridColumn62.Header.Editor = null;
            ultraGridColumn62.Header.VisiblePosition = 5;
            ultraGridColumn64.Header.Editor = null;
            ultraGridColumn64.Header.VisiblePosition = 11;
            ultraGridColumn64.Width = 289;
            appearance30.TextHAlignAsString = "Center";
            ultraGridColumn66.CellAppearance = appearance30;
            appearance31.TextHAlignAsString = "Center";
            ultraGridColumn66.Header.Appearance = appearance31;
            ultraGridColumn66.Header.Caption = "Verordnet ab";
            ultraGridColumn66.Header.Editor = null;
            ultraGridColumn66.Header.VisiblePosition = 6;
            ultraGridColumn66.Width = 105;
            appearance32.TextHAlignAsString = "Center";
            ultraGridColumn70.CellAppearance = appearance32;
            appearance33.TextHAlignAsString = "Center";
            ultraGridColumn70.Header.Appearance = appearance33;
            ultraGridColumn70.Header.Caption = "Verordnet bis";
            ultraGridColumn70.Header.Editor = null;
            ultraGridColumn70.Header.VisiblePosition = 8;
            ultraGridColumn70.Width = 102;
            ultraGridColumn71.Header.Caption = "Bestätigt von";
            ultraGridColumn71.Header.Editor = null;
            ultraGridColumn71.Header.VisiblePosition = 12;
            ultraGridColumn71.Width = 172;
            ultraGridColumn72.Header.Caption = "Datum erstellt";
            ultraGridColumn72.Header.Editor = null;
            ultraGridColumn72.Header.VisiblePosition = 13;
            ultraGridColumn72.Hidden = true;
            ultraGridColumn73.Header.Editor = null;
            ultraGridColumn73.Header.VisiblePosition = 14;
            ultraGridColumn73.Hidden = true;
            ultraGridColumn74.Header.Caption = "Login-Name frei erstellt";
            ultraGridColumn74.Header.Editor = null;
            ultraGridColumn74.Header.VisiblePosition = 15;
            ultraGridColumn74.Hidden = true;
            ultraGridColumn75.Header.Caption = "Datum geändert";
            ultraGridColumn75.Header.Editor = null;
            ultraGridColumn75.Header.VisiblePosition = 16;
            ultraGridColumn75.Hidden = true;
            ultraGridColumn76.Header.Editor = null;
            ultraGridColumn76.Header.VisiblePosition = 18;
            ultraGridColumn76.Hidden = true;
            ultraGridColumn77.Header.Caption = "Login-Name frei geändert";
            ultraGridColumn77.Header.Editor = null;
            ultraGridColumn77.Header.VisiblePosition = 21;
            ultraGridColumn77.Hidden = true;
            ultraGridColumn78.Header.Editor = null;
            ultraGridColumn78.Header.VisiblePosition = 17;
            ultraGridColumn78.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn78.Width = 236;
            ultraGridColumn79.Header.Editor = null;
            ultraGridColumn79.Header.VisiblePosition = 20;
            ultraGridColumn80.Header.Editor = null;
            ultraGridColumn80.Header.VisiblePosition = 22;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 30;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 3;
            ultraGridColumn82.Width = 234;
            ultraGridColumn83.Header.Caption = "Verordnung";
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 9;
            ultraGridColumn83.Width = 337;
            ultraGridColumn84.DataType = typeof(bool);
            ultraGridColumn84.Header.Caption = "Auswahl";
            ultraGridColumn84.Header.Editor = null;
            ultraGridColumn84.Header.VisiblePosition = 0;
            ultraGridColumn84.Width = 67;
            ultraGridColumn85.Header.Caption = "Med.Daten";
            ultraGridColumn85.Header.Editor = null;
            ultraGridColumn85.Header.VisiblePosition = 23;
            ultraGridColumn85.Width = 300;
            ultraGridColumn86.Header.Caption = "Pflegeplan";
            ultraGridColumn86.Header.Editor = null;
            ultraGridColumn86.Header.VisiblePosition = 24;
            ultraGridColumn86.Width = 284;
            ultraGridColumn87.Header.Editor = null;
            ultraGridColumn87.Header.VisiblePosition = 26;
            ultraGridColumn87.Width = 177;
            ultraGridColumn88.Header.Caption = "SV-Nr";
            ultraGridColumn88.Header.Editor = null;
            ultraGridColumn88.Header.VisiblePosition = 27;
            ultraGridColumn88.Width = 141;
            ultraGridColumn89.Header.Caption = "Wunde";
            ultraGridColumn89.Header.Editor = null;
            ultraGridColumn89.Header.VisiblePosition = 25;
            ultraGridColumn89.Width = 270;
            ultraGridColumn90.Header.Caption = "Lieferant Beschreibung";
            ultraGridColumn90.Header.Editor = null;
            ultraGridColumn90.Header.VisiblePosition = 19;
            ultraGridColumn90.Width = 206;
            ultraGridColumn1.Header.Caption = "Benutzer erstellt";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 28;
            ultraGridColumn2.Header.Caption = "Benutzer geändert";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 29;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn64,
            ultraGridColumn66,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn1,
            ultraGridColumn2});
            ultraGridColumn91.Header.Editor = null;
            ultraGridColumn91.Header.VisiblePosition = 3;
            ultraGridColumn91.Hidden = true;
            ultraGridColumn92.Header.Editor = null;
            ultraGridColumn92.Header.VisiblePosition = 4;
            ultraGridColumn92.Hidden = true;
            appearance34.TextHAlignAsString = "Center";
            ultraGridColumn93.CellAppearance = appearance34;
            appearance35.TextHAlignAsString = "Center";
            ultraGridColumn93.Header.Appearance = appearance35;
            ultraGridColumn93.Header.Caption = "Gültig ab";
            ultraGridColumn93.Header.Editor = null;
            ultraGridColumn93.Header.VisiblePosition = 5;
            appearance36.TextHAlignAsString = "Center";
            ultraGridColumn94.CellAppearance = appearance36;
            appearance37.TextHAlignAsString = "Center";
            ultraGridColumn94.Header.Appearance = appearance37;
            ultraGridColumn94.Header.Caption = "Gültig bis";
            ultraGridColumn94.Header.Editor = null;
            ultraGridColumn94.Header.VisiblePosition = 6;
            ultraGridColumn95.Header.Editor = null;
            ultraGridColumn95.Header.VisiblePosition = 1;
            ultraGridColumn95.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn95.Width = 215;
            ultraGridColumn96.Header.Editor = null;
            ultraGridColumn96.Header.VisiblePosition = 7;
            ultraGridColumn96.Hidden = true;
            ultraGridColumn97.Header.Caption = "Eigentum Klient";
            ultraGridColumn97.Header.Editor = null;
            ultraGridColumn97.Header.VisiblePosition = 13;
            appearance38.TextHAlignAsString = "Right";
            ultraGridColumn98.CellAppearance = appearance38;
            appearance39.TextHAlignAsString = "Right";
            ultraGridColumn98.Header.Appearance = appearance39;
            ultraGridColumn98.Header.Editor = null;
            ultraGridColumn98.Header.VisiblePosition = 8;
            ultraGridColumn148.Header.Editor = null;
            ultraGridColumn148.Header.VisiblePosition = 9;
            ultraGridColumn148.Width = 114;
            ultraGridColumn149.Header.Editor = null;
            ultraGridColumn149.Header.VisiblePosition = 10;
            ultraGridColumn149.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn150.Header.Caption = "Hinweis Lieferant";
            ultraGridColumn150.Header.Editor = null;
            ultraGridColumn150.Header.VisiblePosition = 11;
            ultraGridColumn150.Hidden = true;
            ultraGridColumn151.Header.Editor = null;
            ultraGridColumn151.Header.VisiblePosition = 12;
            ultraGridColumn151.Width = 283;
            ultraGridColumn152.Header.Editor = null;
            ultraGridColumn152.Header.VisiblePosition = 14;
            ultraGridColumn152.Hidden = true;
            ultraGridColumn153.Header.Editor = null;
            ultraGridColumn153.Header.VisiblePosition = 15;
            ultraGridColumn153.Hidden = true;
            ultraGridColumn154.Header.Editor = null;
            ultraGridColumn154.Header.VisiblePosition = 16;
            ultraGridColumn154.Hidden = true;
            ultraGridColumn155.Header.Editor = null;
            ultraGridColumn155.Header.VisiblePosition = 17;
            ultraGridColumn155.Hidden = true;
            ultraGridColumn156.Header.Editor = null;
            ultraGridColumn156.Header.VisiblePosition = 18;
            ultraGridColumn156.Hidden = true;
            ultraGridColumn157.Header.Editor = null;
            ultraGridColumn157.Header.VisiblePosition = 19;
            ultraGridColumn157.Hidden = true;
            ultraGridColumn158.Header.Editor = null;
            ultraGridColumn158.Header.VisiblePosition = 20;
            ultraGridColumn158.Hidden = true;
            appearance40.TextHAlignAsString = "Center";
            ultraGridColumn159.CellAppearance = appearance40;
            appearance41.TextHAlignAsString = "Center";
            ultraGridColumn159.Header.Appearance = appearance41;
            ultraGridColumn159.Header.Caption = "Datum nächster Anspruch";
            ultraGridColumn159.Header.Editor = null;
            ultraGridColumn159.Header.VisiblePosition = 21;
            ultraGridColumn160.Header.Editor = null;
            ultraGridColumn160.Header.VisiblePosition = 22;
            ultraGridColumn160.Hidden = true;
            ultraGridColumn161.Header.Editor = null;
            ultraGridColumn161.Header.VisiblePosition = 23;
            ultraGridColumn161.Hidden = true;
            ultraGridColumn162.Header.Editor = null;
            ultraGridColumn162.Header.VisiblePosition = 24;
            ultraGridColumn162.Hidden = true;
            ultraGridColumn176.Header.Editor = null;
            ultraGridColumn176.Header.VisiblePosition = 25;
            ultraGridColumn176.Hidden = true;
            ultraGridColumn177.Header.Editor = null;
            ultraGridColumn177.Header.VisiblePosition = 26;
            ultraGridColumn177.Hidden = true;
            ultraGridColumn178.Header.Editor = null;
            ultraGridColumn178.Header.VisiblePosition = 27;
            ultraGridColumn178.Hidden = true;
            ultraGridColumn179.Header.Editor = null;
            ultraGridColumn179.Header.VisiblePosition = 29;
            ultraGridColumn179.Hidden = true;
            ultraGridColumn180.Header.Editor = null;
            ultraGridColumn180.Header.VisiblePosition = 28;
            ultraGridColumn181.Header.Editor = null;
            ultraGridColumn181.Header.VisiblePosition = 0;
            ultraGridColumn181.Width = 218;
            ultraGridColumn182.Header.Caption = "Verordnung";
            ultraGridColumn182.Header.Editor = null;
            ultraGridColumn182.Header.VisiblePosition = 2;
            ultraGridColumn182.Width = 244;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96,
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151,
            ultraGridColumn152,
            ultraGridColumn153,
            ultraGridColumn154,
            ultraGridColumn155,
            ultraGridColumn156,
            ultraGridColumn157,
            ultraGridColumn158,
            ultraGridColumn159,
            ultraGridColumn160,
            ultraGridColumn161,
            ultraGridColumn162,
            ultraGridColumn176,
            ultraGridColumn177,
            ultraGridColumn178,
            ultraGridColumn179,
            ultraGridColumn180,
            ultraGridColumn181,
            ultraGridColumn182});
            ultraGridBand3.Hidden = true;
            this.gridVO.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridVO.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.gridVO.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridVO.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridVO.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridVO.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridVO.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridVO.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridVO.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridVO.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridVO.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance42.BorderColor = System.Drawing.Color.White;
            this.gridVO.DisplayLayout.Override.SummaryFooterAppearance = appearance42;
            appearance43.BorderColor = System.Drawing.Color.White;
            this.gridVO.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridVO.DisplayLayout.Override.SummaryValueAppearance = appearance44;
            this.gridVO.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList3.Key = "Typ";
            valueList4.Key = "Lieferant";
            this.gridVO.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList3,
            valueList4});
            this.gridVO.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridVO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridVO.Location = new System.Drawing.Point(3, 3);
            this.gridVO.Margin = new System.Windows.Forms.Padding(4);
            this.gridVO.Name = "gridVO";
            this.gridVO.Size = new System.Drawing.Size(1061, 191);
            this.gridVO.TabIndex = 0;
            this.gridVO.Text = "Dokumente";
            this.gridVO.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridVOErfBestell_BeforeCellActivate);
            this.gridVO.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridVOErfBestell_BeforeRowsDeleted);
            this.gridVO.Click += new System.EventHandler(this.gridVOErfBestell_Click);
            this.gridVO.DoubleClick += new System.EventHandler(this.gridVOErfBestell_DoubleClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem,
            this.toolStripMenuItemSpace01,
            this.filterToolStripMenuItem,
            this.ansichtErweiternToolStripMenuItem,
            this.ansichtReduzierenToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStripGrid.Name = "contextMenuStripDrucken";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(273, 104);
            // 
            // verordnungsVerknüpfungHinzufügenToolStripMenuItem
            // 
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Name = "verordnungsVerknüpfungHinzufügenToolStripMenuItem";
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Text = "Verordnungsverknüpfung hinzufügen";
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Visible = false;
            this.verordnungsVerknüpfungHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.verordnungsVerknüpfungHinzufügenToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSpace01
            // 
            this.toolStripMenuItemSpace01.Name = "toolStripMenuItemSpace01";
            this.toolStripMenuItemSpace01.Size = new System.Drawing.Size(269, 6);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.CheckOnClick = true;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // ansichtErweiternToolStripMenuItem
            // 
            this.ansichtErweiternToolStripMenuItem.Name = "ansichtErweiternToolStripMenuItem";
            this.ansichtErweiternToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.ansichtErweiternToolStripMenuItem.Text = "Ansicht erweitern";
            this.ansichtErweiternToolStripMenuItem.Click += new System.EventHandler(this.ansichtErweiternToolStripMenuItem_Click);
            // 
            // ansichtReduzierenToolStripMenuItem
            // 
            this.ansichtReduzierenToolStripMenuItem.Name = "ansichtReduzierenToolStripMenuItem";
            this.ansichtReduzierenToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.ansichtReduzierenToolStripMenuItem.Text = "Ansicht reduzieren";
            this.ansichtReduzierenToolStripMenuItem.Click += new System.EventHandler(this.ansichtReduzierenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(269, 6);
            // 
            // ultraTabControl1
            // 
            appearance45.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.Appearance = appearance45;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(1067, 225);
            this.ultraTabControl1.TabIndex = 15;
            ultraTab1.Key = "Bestelldaten";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Bestelldaten";
            ultraTab2.Key = "Lager";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Lager";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1063, 199);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // sqlVO1
            // 
            pmdsBusiness1.isinitialized = false;
            this.sqlVO1.b = pmdsBusiness1;
            this.sqlVO1.IsInitialized = false;
            this.sqlVO1.SelVO = "";
            this.sqlVO1.SelVOBestelldaten = "";
            this.sqlVO1.SelVOBestellpostitionen = "";
            this.sqlVO1.SelVOLager = "";
            // 
            // ucVOErfassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "ucVOErfassen";
            this.Size = new System.Drawing.Size(1067, 575);
            this.Load += new System.EventHandler(this.ucVOErfassen_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelVOBestelldatenGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVOBestelldaten)).EndInit();
            this.contextMenuStripBestelldaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsVO1)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.contextMenuStripSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboZustand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteVerordnetBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteVerordnetAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktuelle)).EndInit();
            this.contextMenuStripDrucken.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPrint)).EndInit();
            this.grpPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintDetailsJN)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.splitContainerCenter.Panel1.ResumeLayout(false);
            this.splitContainerCenter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).EndInit();
            this.splitContainerCenter.ResumeLayout(false);
            this.panelVOGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVO)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridVO;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVO;
        public QS2.Desktop.ControlManagment.BaseButton btnClose;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        public QS2.Desktop.ControlManagment.BaseButton btnPrint;
        internal Infragistics.Win.Misc.UltraDropDownButton dropDownPatienten;
        private Infragistics.Win.Misc.UltraPopupControlContainer uPopUpContPatienten;
        private Global.db.ERSystem.dsVO dsVO1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteVerordnetBis;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteVerordnetAb;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        private Infragistics.Win.Misc.UltraLabel lblVerordnetBis;
        private Infragistics.Win.Misc.UltraLabel lblVerordnetAb;
        private Global.db.ERSystem.sqlVO sqlVO1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraLabel lblFound;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDrucken;
        private System.Windows.Forms.ToolStripMenuItem exportDSToolStripMenuItem;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkNurAktuelle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtErweiternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtReduzierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem verordnungsVerknüpfungHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSpace01;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVOBestelldaten;
        public QS2.Desktop.ControlManagment.BaseButton btnDelBestelldaten;
        public QS2.Desktop.ControlManagment.BaseGrid gridVOBestelldaten;
        internal Infragistics.Win.Misc.UltraDropDownButton dropDownTyp;
        private Infragistics.Win.Misc.UltraPopupControlContainer uPopupContTyp;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVOBestelldatenEinmaligeAnforderung;
        private System.Windows.Forms.Panel panelVOBestelldatenGrid;
        private System.Windows.Forms.Panel panelVOGrid;
        private System.Windows.Forms.SplitContainer splitContainerCenter;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkPrintDetailsJN;
        private Infragistics.Win.Misc.UltraGroupBox grpPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBestelldaten;
        private System.Windows.Forms.ToolStripMenuItem layoutmanagerToolStripMenuItem;
        public QS2.Desktop.ControlManagment.BaseButton btnMedikamente;
        public QS2.Desktop.ControlManagment.BaseButton btnMedDaten;
        public QS2.Desktop.ControlManagment.BaseButton btnWunde;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVOVerknüpfung;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private ucLager ucLager1;
        private Infragistics.Win.Misc.UltraLabel lblZustandLager;
        public System.Windows.Forms.Panel panelTop;
        public Infragistics.Win.Misc.UltraGroupBox grpSearch;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cboZustand;
        public QS2.Desktop.ControlManagment.BaseButton btnVOSchein;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSys;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}
