using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    partial class ucZielEvaluierung
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucZielEvaluierung));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PflegePlan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer_Erstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer_Geaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OriginalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EndeDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LetztesDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LetzteEvaluierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Warnhinweis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErledigtGrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Intervall");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WochenTage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IntervallTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EvalTage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBerufsstand");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ParalellJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LokalisierungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinmaligJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErledigtJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GeloeschtJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lokalisierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LokalisierungSeite");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EintragGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDXJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RMOptionalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UntertaegigeJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SpenderAbgabeJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUntertaegigeGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLinkDokument");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NaechsteEvaluierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NaechsteEvaluierungBemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZuErledigenBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OhneZeitBezug");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WundeJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EintragFlag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NächstesDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDekurs");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PrivatJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDExtern");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("lstIDPDx");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("lstPDxBezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnmerkungRtf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBefund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BarcodeID", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LokalisierungsInfo", 1);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PflegeEintrag", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPflegePlan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zeitpunkt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IstDauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DurchgefuehrtJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EintragsTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Wichtig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBerufsstand");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDWichtig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEvaluierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EvalStatus");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PflegeplanText");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSollberufsstand");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPflegePlanBerufsstand");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Solldauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPflegeplanH");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PflegePlanDauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDekurs");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDExtern");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Startdatum_Neu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TextRtf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dekursherkunft");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgezeichnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgezeichnetIDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgezeichnetAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbzeichnenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HAGPflichtigJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBefund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LogInNameFrei");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpDate2 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dsPflegeEintrag1 = new PMDS.Data.PflegePlan.dsPflegeEintrag();
            this.dsPflegePlanPDx1 = new dsPflegePlanPDx();
            this.dsPDx1 = new dsPDx();
            this.gbEvaluierung = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanelAnmerkung = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.tbAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelStatusEingabe = new QS2.Desktop.ControlManagment.BasePanel();
            this.optEvaluierungsStatus2 = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.optEvaluierungsStatus1 = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.panelButtonsUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPflegePlan2 = new PMDS.Data.PflegePlan.dsPflegePlan();
            this.cballeZiele = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.dgHistorie = new QS2.Desktop.ControlManagment.BaseGrid();
            this.splitContainerUnten = new System.Windows.Forms.SplitContainer();
            this.dsPflegegeldstufe1 = new PMDS.Abrechnung.Global.dsPflegegeldstufe();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegeEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanPDx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbEvaluierung)).BeginInit();
            this.gbEvaluierung.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAnmerkung)).BeginInit();
            this.ultraGridBagLayoutPanelAnmerkung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).BeginInit();
            this.panelStatusEingabe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optEvaluierungsStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optEvaluierungsStatus1)).BeginInit();
            this.panelButtonsUnten.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlan2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cballeZiele)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUnten)).BeginInit();
            this.splitContainerUnten.Panel1.SuspendLayout();
            this.splitContainerUnten.Panel2.SuspendLayout();
            this.splitContainerUnten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegegeldstufe1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtpDate2
            // 
            this.dtpDate2.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate2.FormatString = "";
            this.errorProvider1.SetIconAlignment(this.dtpDate2, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.dtpDate2.Location = new System.Drawing.Point(7, 4);
            this.dtpDate2.MaskInput = "";
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.ownFormat = "";
            this.dtpDate2.ownMaskInput = "";
            this.dtpDate2.Size = new System.Drawing.Size(107, 24);
            this.dtpDate2.TabIndex = 6;
            this.dtpDate2.Value = null;
            this.dtpDate2.ValueChanged += new System.EventHandler(this.dtpDate2_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dsPflegeEintrag1
            // 
            this.dsPflegeEintrag1.DataSetName = "dsPflegeEintrag";
            this.dsPflegeEintrag1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsPflegeEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPflegePlanPDx1
            // 
            this.dsPflegePlanPDx1.DataSetName = "dsPflegePlanPDx";
            this.dsPflegePlanPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlanPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPDx1
            // 
            this.dsPDx1.DataSetName = "dsPDx";
            this.dsPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbEvaluierung
            // 
            this.gbEvaluierung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.gbEvaluierung.Appearance = appearance4;
            this.gbEvaluierung.Controls.Add(this.panel3);
            this.gbEvaluierung.Controls.Add(this.panelStatusEingabe);
            this.gbEvaluierung.Controls.Add(this.panelButtonsUnten);
            this.gbEvaluierung.Controls.Add(this.label1);
            this.gbEvaluierung.Location = new System.Drawing.Point(638, 25);
            this.gbEvaluierung.Name = "gbEvaluierung";
            this.gbEvaluierung.Size = new System.Drawing.Size(353, 328);
            this.gbEvaluierung.TabIndex = 3;
            this.gbEvaluierung.Text = "Evaluierungsstatus";
            this.gbEvaluierung.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraGridBagLayoutPanelAnmerkung);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 207);
            this.panel3.TabIndex = 30;
            // 
            // ultraGridBagLayoutPanelAnmerkung
            // 
            this.ultraGridBagLayoutPanelAnmerkung.Controls.Add(this.tbAnmerkung);
            this.ultraGridBagLayoutPanelAnmerkung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAnmerkung.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAnmerkung.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAnmerkung.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAnmerkung.Name = "ultraGridBagLayoutPanelAnmerkung";
            this.ultraGridBagLayoutPanelAnmerkung.Size = new System.Drawing.Size(347, 207);
            this.ultraGridBagLayoutPanelAnmerkung.TabIndex = 27;
            // 
            // tbAnmerkung
            // 
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanelAnmerkung.SetGridBagConstraint(this.tbAnmerkung, gridBagConstraint1);
            this.tbAnmerkung.Location = new System.Drawing.Point(5, 5);
            this.tbAnmerkung.MaxLength = 2048;
            this.tbAnmerkung.Multiline = true;
            this.tbAnmerkung.Name = "tbAnmerkung";
            this.ultraGridBagLayoutPanelAnmerkung.SetPreferredSize(this.tbAnmerkung, new System.Drawing.Size(377, 190));
            this.tbAnmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbAnmerkung.Size = new System.Drawing.Size(337, 197);
            this.tbAnmerkung.TabIndex = 26;
            // 
            // panelStatusEingabe
            // 
            this.panelStatusEingabe.Controls.Add(this.optEvaluierungsStatus2);
            this.panelStatusEingabe.Controls.Add(this.optEvaluierungsStatus1);
            this.panelStatusEingabe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatusEingabe.Location = new System.Drawing.Point(3, 19);
            this.panelStatusEingabe.Name = "panelStatusEingabe";
            this.panelStatusEingabe.Size = new System.Drawing.Size(347, 68);
            this.panelStatusEingabe.TabIndex = 29;
            // 
            // optEvaluierungsStatus2
            // 
            this.optEvaluierungsStatus2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "ASRZM ändern";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "weiter wie bisher";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "Pflegediagnose absetzen";
            this.optEvaluierungsStatus2.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optEvaluierungsStatus2.ItemSpacingHorizontal = 1;
            this.optEvaluierungsStatus2.ItemSpacingVertical = 2;
            this.optEvaluierungsStatus2.Location = new System.Drawing.Point(165, 5);
            this.optEvaluierungsStatus2.Name = "optEvaluierungsStatus2";
            this.optEvaluierungsStatus2.Size = new System.Drawing.Size(175, 57);
            this.optEvaluierungsStatus2.TabIndex = 4;
            this.optEvaluierungsStatus2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.optEvaluierungsStatus2.ValueChanged += new System.EventHandler(this.os1_ValueChanged);
            // 
            // optEvaluierungsStatus1
            // 
            this.optEvaluierungsStatus1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem4.DataValue = "Default Item";
            valueListItem4.DisplayText = "Ziel erreicht";
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "Ziel teilweise erreicht";
            valueListItem6.DataValue = "ValueListItem2";
            valueListItem6.DisplayText = "Ziel nicht erreicht";
            this.optEvaluierungsStatus1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.optEvaluierungsStatus1.ItemSpacingHorizontal = 1;
            this.optEvaluierungsStatus1.ItemSpacingVertical = 2;
            this.optEvaluierungsStatus1.Location = new System.Drawing.Point(10, 5);
            this.optEvaluierungsStatus1.Name = "optEvaluierungsStatus1";
            this.optEvaluierungsStatus1.Size = new System.Drawing.Size(144, 56);
            this.optEvaluierungsStatus1.TabIndex = 3;
            this.optEvaluierungsStatus1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.optEvaluierungsStatus1.ValueChanged += new System.EventHandler(this.os1_ValueChanged);
            // 
            // panelButtonsUnten
            // 
            this.panelButtonsUnten.Controls.Add(this.dtpDate2);
            this.panelButtonsUnten.Controls.Add(this.panelButtons);
            this.panelButtonsUnten.Controls.Add(this.ultraLabel3);
            this.panelButtonsUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsUnten.Location = new System.Drawing.Point(3, 294);
            this.panelButtonsUnten.Name = "panelButtonsUnten";
            this.panelButtonsUnten.Size = new System.Drawing.Size(347, 31);
            this.panelButtonsUnten.TabIndex = 28;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(155, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(192, 31);
            this.panelButtons.TabIndex = 22;
            // 
            // btnCancel
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance5;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(24, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.TabStop = false;
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance6;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DoOnClick = true;
            this.btnOk.Enabled = false;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(107, 1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 28);
            this.btnOk.TabIndex = 20;
            this.btnOk.TabStop = false;
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(6, 7);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(108, 14);
            this.ultraLabel3.TabIndex = 19;
            this.ultraLabel3.Text = "nächste Evaluierung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Anmerkung";
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = false;
            this.dgMain.DataMember = "PflegePlan";
            this.dgMain.DataSource = this.dsPflegePlan2;
            appearance2.BackColor = System.Drawing.Color.White;
            this.dgMain.DisplayLayout.Appearance = appearance2;
            this.dgMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn10.Header.Caption = "Abgesetzt am:";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn16.Header.Caption = "Ziel";
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn16.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(355, 0);
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 6;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.Width = 130;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 17;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 18;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 19;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 25;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 26;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn28.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 27;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn29.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 28;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 29;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn31.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 30;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn32.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 31;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 32;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn34.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 33;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn35.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 34;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn36.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 35;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn37.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn37.Header.Caption = "nächste Eval.";
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 36;
            ultraGridColumn37.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn37.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn37.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn37.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn37.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn38.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 37;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn39.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 38;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn40.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 39;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn41.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 40;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 41;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 42;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn70.Header.Editor = null;
            ultraGridColumn70.Header.VisiblePosition = 43;
            ultraGridColumn71.Header.Editor = null;
            ultraGridColumn71.Header.VisiblePosition = 45;
            ultraGridColumn72.Header.Editor = null;
            ultraGridColumn72.Header.VisiblePosition = 47;
            ultraGridColumn73.Header.Editor = null;
            ultraGridColumn73.Header.VisiblePosition = 48;
            ultraGridColumn74.Header.Editor = null;
            ultraGridColumn74.Header.VisiblePosition = 49;
            ultraGridColumn75.Header.Editor = null;
            ultraGridColumn75.Header.VisiblePosition = 50;
            ultraGridColumn76.Header.Editor = null;
            ultraGridColumn76.Header.VisiblePosition = 52;
            ultraGridColumn87.Header.Editor = null;
            ultraGridColumn87.Header.VisiblePosition = 51;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 44;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn45.Header.Caption = "Lokalisierung";
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 46;
            ultraGridColumn45.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn45.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn45.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(122, 0);
            ultraGridColumn45.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn45.RowLayoutColumnInfo.SpanY = 2;
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
            ultraGridColumn25,
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
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn87,
            ultraGridColumn44,
            ultraGridColumn45});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.dgMain.DisplayLayout.CaptionAppearance = appearance3;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgMain.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgMain.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(3, 25);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(629, 326);
            this.dgMain.TabIndex = 4;
            this.dgMain.Text = "Evaluierungen";
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.Click += new System.EventHandler(this.dgMain_Click);
            // 
            // dsPflegePlan2
            // 
            this.dsPflegePlan2.DataSetName = "dsPflegePlan";
            this.dsPflegePlan2.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlan2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cballeZiele
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.cballeZiele.Appearance = appearance1;
            this.cballeZiele.BackColor = System.Drawing.Color.Transparent;
            this.cballeZiele.BackColorInternal = System.Drawing.Color.Transparent;
            this.cballeZiele.Location = new System.Drawing.Point(6, 5);
            this.cballeZiele.Name = "cballeZiele";
            this.cballeZiele.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cballeZiele.Size = new System.Drawing.Size(199, 16);
            this.cballeZiele.TabIndex = 9;
            this.cballeZiele.Text = "Beendete Ziele anzeigen";
            this.cballeZiele.CheckedChanged += new System.EventHandler(this.cballeZiele_CheckedChanged);
            // 
            // dgHistorie
            // 
            this.dgHistorie.AutoWork = true;
            this.dgHistorie.ContextMenuStrip = this.contextMenuStrip1;
            this.dgHistorie.DataMember = "PflegeEintrag";
            this.dgHistorie.DataSource = this.dsPflegeEintrag1;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BorderColor = System.Drawing.Color.DarkGray;
            this.dgHistorie.DisplayLayout.Appearance = appearance7;
            this.dgHistorie.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridBand2.AutoPreviewMaxLines = 1;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 0;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 1;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 2;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn49.Header.Caption = "Benutzer";
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 3;
            ultraGridColumn49.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn49.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn49.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(123, 0);
            ultraGridColumn49.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn49.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 4;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 5;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn52.Header.Editor = null;
            ultraGridColumn52.Header.VisiblePosition = 6;
            ultraGridColumn52.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn52.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn52.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(118, 0);
            ultraGridColumn52.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn52.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn53.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn53.Header.Caption = "Anmerkung";
            ultraGridColumn53.Header.Editor = null;
            ultraGridColumn53.Header.VisiblePosition = 7;
            ultraGridColumn53.RowLayoutColumnInfo.OriginX = 7;
            ultraGridColumn53.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn53.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(382, 40);
            ultraGridColumn53.RowLayoutColumnInfo.SpanX = 5;
            ultraGridColumn53.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn54.Header.Editor = null;
            ultraGridColumn54.Header.VisiblePosition = 8;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn55.Header.Editor = null;
            ultraGridColumn55.Header.VisiblePosition = 9;
            ultraGridColumn55.Hidden = true;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn56.Header.Editor = null;
            ultraGridColumn56.Header.VisiblePosition = 10;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn57.Header.Editor = null;
            ultraGridColumn57.Header.VisiblePosition = 11;
            ultraGridColumn57.Hidden = true;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn58.Header.Editor = null;
            ultraGridColumn58.Header.VisiblePosition = 12;
            ultraGridColumn58.Hidden = true;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn59.Header.Editor = null;
            ultraGridColumn59.Header.VisiblePosition = 13;
            ultraGridColumn59.Hidden = true;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn60.Header.Editor = null;
            ultraGridColumn60.Header.VisiblePosition = 14;
            ultraGridColumn60.Hidden = true;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn61.Header.Caption = "Evaluierungs Status";
            ultraGridColumn61.Header.Editor = null;
            ultraGridColumn61.Header.VisiblePosition = 15;
            ultraGridColumn61.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn61.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn61.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(169, 0);
            ultraGridColumn61.RowLayoutColumnInfo.SpanX = 4;
            ultraGridColumn61.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn62.Header.Editor = null;
            ultraGridColumn62.Header.VisiblePosition = 16;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn63.Header.Editor = null;
            ultraGridColumn63.Header.VisiblePosition = 17;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn64.Header.Editor = null;
            ultraGridColumn64.Header.VisiblePosition = 18;
            ultraGridColumn64.Hidden = true;
            ultraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn65.Header.Editor = null;
            ultraGridColumn65.Header.VisiblePosition = 19;
            ultraGridColumn65.Hidden = true;
            ultraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn66.Header.Editor = null;
            ultraGridColumn66.Header.VisiblePosition = 20;
            ultraGridColumn66.Hidden = true;
            ultraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn67.Header.Editor = null;
            ultraGridColumn67.Header.VisiblePosition = 21;
            ultraGridColumn67.Hidden = true;
            ultraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn68.Header.Editor = null;
            ultraGridColumn68.Header.VisiblePosition = 22;
            ultraGridColumn68.Hidden = true;
            ultraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn69.Header.Editor = null;
            ultraGridColumn69.Header.VisiblePosition = 23;
            ultraGridColumn69.Hidden = true;
            ultraGridColumn77.Header.Editor = null;
            ultraGridColumn77.Header.VisiblePosition = 24;
            ultraGridColumn78.Header.Editor = null;
            ultraGridColumn78.Header.VisiblePosition = 25;
            ultraGridColumn79.Header.Editor = null;
            ultraGridColumn79.Header.VisiblePosition = 26;
            ultraGridColumn80.Header.Editor = null;
            ultraGridColumn80.Header.VisiblePosition = 27;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 28;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 29;
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 30;
            ultraGridColumn84.Header.Editor = null;
            ultraGridColumn84.Header.VisiblePosition = 31;
            ultraGridColumn85.Header.Editor = null;
            ultraGridColumn85.Header.VisiblePosition = 32;
            ultraGridColumn86.Header.Editor = null;
            ultraGridColumn86.Header.VisiblePosition = 33;
            ultraGridColumn88.Header.Editor = null;
            ultraGridColumn88.Header.VisiblePosition = 34;
            ultraGridColumn89.Header.Editor = null;
            ultraGridColumn89.Header.VisiblePosition = 35;
            ultraGridColumn90.Header.Editor = null;
            ultraGridColumn90.Header.VisiblePosition = 36;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
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
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgHistorie.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgHistorie.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.dgHistorie.DisplayLayout.CaptionAppearance = appearance8;
            this.dgHistorie.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            this.dgHistorie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHistorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgHistorie.Location = new System.Drawing.Point(0, 0);
            this.dgHistorie.Name = "dgHistorie";
            this.dgHistorie.Size = new System.Drawing.Size(994, 156);
            this.dgHistorie.TabIndex = 2;
            this.dgHistorie.Text = "Frühere Evaluierungen";
            this.dgHistorie.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgHistorie_InitializeLayout);
            this.dgHistorie.DoubleClick += new System.EventHandler(this.dgHistorie_DoubleClick);
            // 
            // splitContainerUnten
            // 
            this.splitContainerUnten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUnten.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerUnten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.splitContainerUnten.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUnten.Name = "splitContainerUnten";
            this.splitContainerUnten.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerUnten.Panel1
            // 
            this.splitContainerUnten.Panel1.Controls.Add(this.cballeZiele);
            this.splitContainerUnten.Panel1.Controls.Add(this.dgMain);
            this.splitContainerUnten.Panel1.Controls.Add(this.gbEvaluierung);
            // 
            // splitContainerUnten.Panel2
            // 
            this.splitContainerUnten.Panel2.Controls.Add(this.dgHistorie);
            this.splitContainerUnten.Size = new System.Drawing.Size(994, 516);
            this.splitContainerUnten.SplitterDistance = 356;
            this.splitContainerUnten.TabIndex = 8;
            // 
            // dsPflegegeldstufe1
            // 
            this.dsPflegegeldstufe1.DataSetName = "dsPflegegeldstufe";
            this.dsPflegegeldstufe1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegegeldstufe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucZielEvaluierung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.splitContainerUnten);
            this.Name = "ucZielEvaluierung";
            this.Size = new System.Drawing.Size(994, 516);
            this.VisibleChanged += new System.EventHandler(this.ucZielEvaluierung_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegeEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanPDx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbEvaluierung)).EndInit();
            this.gbEvaluierung.ResumeLayout(false);
            this.gbEvaluierung.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAnmerkung)).EndInit();
            this.ultraGridBagLayoutPanelAnmerkung.ResumeLayout(false);
            this.ultraGridBagLayoutPanelAnmerkung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).EndInit();
            this.panelStatusEingabe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optEvaluierungsStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optEvaluierungsStatus1)).EndInit();
            this.panelButtonsUnten.ResumeLayout(false);
            this.panelButtonsUnten.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlan2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cballeZiele)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorie)).EndInit();
            this.splitContainerUnten.Panel1.ResumeLayout(false);
            this.splitContainerUnten.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUnten)).EndInit();
            this.splitContainerUnten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegegeldstufe1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PMDS.Data.PflegePlan.dsPflegeEintrag dsPflegeEintrag1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private dsPflegePlanPDx dsPflegePlanPDx1;
        private dsPDx dsPDx1;
        private System.Windows.Forms.SplitContainer splitContainerUnten;
        private QS2.Desktop.ControlManagment.BaseCheckBox cballeZiele;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbAnmerkung;
        private QS2.Desktop.ControlManagment.BasePanel panelStatusEingabe;
        private QS2.Desktop.ControlManagment.BaseOptionSet optEvaluierungsStatus2;
        private QS2.Desktop.ControlManagment.BaseOptionSet optEvaluierungsStatus1;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        private QS2.Desktop.ControlManagment.BaseLableWin label1;
        private QS2.Desktop.ControlManagment.BaseGrid dgHistorie;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpDate2;
        public ucButton btnOk;
        public QS2.Desktop.ControlManagment.BaseGroupBox gbEvaluierung;
        private Abrechnung.Global.dsPflegegeldstufe dsPflegegeldstufe1;
        private Data.PflegePlan.dsPflegePlan dsPflegePlan2;
    }

}
