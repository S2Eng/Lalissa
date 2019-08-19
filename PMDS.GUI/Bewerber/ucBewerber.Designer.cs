using PMDS.Global.db.Global;
namespace PMDS.GUI
{
    partial class ucBewerber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBewerber));
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Patient", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nachname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Geburtsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BewerbungaktivJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PflegeArt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BewerbungDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinzugswunschDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuszugswunschDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zimmerwunsch");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SonstigeWuensche");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BewerbungsGrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Prioritaet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BewerberBemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Titel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Sexus");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Familienstand");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klinik", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", 1);
            this.lblBewerbername = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtName = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBewerbungenVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBewVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBewBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblPriorität = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblPflegeart = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEinzBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBis2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEinzVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblEinzugGewünschtVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnBewStatus = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnBewDaten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPrint = new QS2.Desktop.ControlManagment.BaseButton();
            this.groupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblKlinik = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbKlinik = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cmbKonfession = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblKonfession = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbSexus = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblGeschl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboBereich = new PMDS.GUI.BaseControls.BereichsCombo();
            this.lblBereich = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbAbteilung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblAbteilung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            this.cmbPriortaet = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbPflegeart = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.dgBewerber2 = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientBewerber2 = new PMDS.Global.db.Global.dsPatientBewerber();
            this.dsKlinik1 = new PMDS.Global.db.Patient.dsKlinik();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBewVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBewBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEinzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEinzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriortaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPflegeart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBewerber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBewerber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBewerbername
            // 
            appearance1.FontData.SizeInPoints = 8F;
            this.lblBewerbername.Appearance = appearance1;
            this.lblBewerbername.AutoSize = true;
            this.lblBewerbername.Location = new System.Drawing.Point(14, 29);
            this.lblBewerbername.Name = "lblBewerbername";
            this.lblBewerbername.Size = new System.Drawing.Size(79, 14);
            this.lblBewerbername.TabIndex = 133;
            this.lblBewerbername.Text = "Bewerbername";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 26);
            this.txtName.MaxLength = 52;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(289, 21);
            this.txtName.TabIndex = 0;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblBewerbungenVon
            // 
            appearance2.FontData.SizeInPoints = 8F;
            this.lblBewerbungenVon.Appearance = appearance2;
            this.lblBewerbungenVon.AutoSize = true;
            this.lblBewerbungenVon.Location = new System.Drawing.Point(14, 60);
            this.lblBewerbungenVon.Name = "lblBewerbungenVon";
            this.lblBewerbungenVon.Size = new System.Drawing.Size(92, 14);
            this.lblBewerbungenVon.TabIndex = 135;
            this.lblBewerbungenVon.Text = "Bewerbungen von";
            // 
            // dtpBewVon
            // 
            this.dtpBewVon.DateTime = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpBewVon.FormatString = "";
            this.dtpBewVon.Location = new System.Drawing.Point(130, 56);
            this.dtpBewVon.MaskInput = "";
            this.dtpBewVon.Name = "dtpBewVon";
            this.dtpBewVon.ownFormat = "";
            this.dtpBewVon.ownMaskInput = "";
            this.dtpBewVon.Size = new System.Drawing.Size(128, 21);
            this.dtpBewVon.TabIndex = 2;
            this.dtpBewVon.Value = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpBewVon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblBis
            // 
            appearance3.FontData.SizeInPoints = 8F;
            this.lblBis.Appearance = appearance3;
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(264, 60);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(18, 14);
            this.lblBis.TabIndex = 137;
            this.lblBis.Text = "bis";
            // 
            // dtpBewBis
            // 
            this.dtpBewBis.DateTime = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpBewBis.FormatString = "";
            this.dtpBewBis.Location = new System.Drawing.Point(331, 57);
            this.dtpBewBis.MaskInput = "";
            this.dtpBewBis.Name = "dtpBewBis";
            this.dtpBewBis.ownFormat = "";
            this.dtpBewBis.ownMaskInput = "";
            this.dtpBewBis.Size = new System.Drawing.Size(131, 21);
            this.dtpBewBis.TabIndex = 3;
            this.dtpBewBis.Value = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpBewBis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblPriorität
            // 
            appearance4.FontData.SizeInPoints = 8F;
            this.lblPriorität.Appearance = appearance4;
            this.lblPriorität.AutoSize = true;
            this.lblPriorität.Location = new System.Drawing.Point(14, 105);
            this.lblPriorität.Name = "lblPriorität";
            this.lblPriorität.Size = new System.Drawing.Size(42, 14);
            this.lblPriorität.TabIndex = 140;
            this.lblPriorität.Text = "Priorität";
            // 
            // lblPflegeart
            // 
            appearance5.FontData.SizeInPoints = 8F;
            this.lblPflegeart.Appearance = appearance5;
            this.lblPflegeart.AutoSize = true;
            this.lblPflegeart.Location = new System.Drawing.Point(264, 105);
            this.lblPflegeart.Name = "lblPflegeart";
            this.lblPflegeart.Size = new System.Drawing.Size(48, 14);
            this.lblPflegeart.TabIndex = 142;
            this.lblPflegeart.Text = "Pflegeart";
            // 
            // dtpEinzBis
            // 
            this.dtpEinzBis.DateTime = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpEinzBis.FormatString = "";
            this.dtpEinzBis.Location = new System.Drawing.Point(331, 79);
            this.dtpEinzBis.MaskInput = "";
            this.dtpEinzBis.Name = "dtpEinzBis";
            this.dtpEinzBis.ownFormat = "";
            this.dtpEinzBis.ownMaskInput = "";
            this.dtpEinzBis.Size = new System.Drawing.Size(131, 21);
            this.dtpEinzBis.TabIndex = 5;
            this.dtpEinzBis.Value = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpEinzBis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblBis2
            // 
            appearance6.FontData.SizeInPoints = 8F;
            this.lblBis2.Appearance = appearance6;
            this.lblBis2.AutoSize = true;
            this.lblBis2.Location = new System.Drawing.Point(264, 82);
            this.lblBis2.Name = "lblBis2";
            this.lblBis2.Size = new System.Drawing.Size(18, 14);
            this.lblBis2.TabIndex = 145;
            this.lblBis2.Text = "bis";
            // 
            // dtpEinzVon
            // 
            this.dtpEinzVon.DateTime = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpEinzVon.FormatString = "";
            this.dtpEinzVon.Location = new System.Drawing.Point(130, 79);
            this.dtpEinzVon.MaskInput = "";
            this.dtpEinzVon.Name = "dtpEinzVon";
            this.dtpEinzVon.ownFormat = "";
            this.dtpEinzVon.ownMaskInput = "";
            this.dtpEinzVon.Size = new System.Drawing.Size(128, 21);
            this.dtpEinzVon.TabIndex = 4;
            this.dtpEinzVon.Value = new System.DateTime(2007, 6, 11, 0, 0, 0, 0);
            this.dtpEinzVon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblEinzugGewünschtVon
            // 
            appearance7.FontData.SizeInPoints = 8F;
            this.lblEinzugGewünschtVon.Appearance = appearance7;
            this.lblEinzugGewünschtVon.AutoSize = true;
            this.lblEinzugGewünschtVon.Location = new System.Drawing.Point(14, 83);
            this.lblEinzugGewünschtVon.Name = "lblEinzugGewünschtVon";
            this.lblEinzugGewünschtVon.Size = new System.Drawing.Size(114, 14);
            this.lblEinzugGewünschtVon.TabIndex = 143;
            this.lblEinzugGewünschtVon.Text = "Einzug gewünscht von";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDel.Appearance = appearance8;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Enabled = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(6, 466);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(122, 28);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "Bewerber löschen";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnBewStatus
            // 
            this.btnBewStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnBewStatus.Appearance = appearance9;
            this.btnBewStatus.AutoWorkLayout = false;
            this.btnBewStatus.Enabled = false;
            this.btnBewStatus.IsStandardControl = false;
            this.btnBewStatus.Location = new System.Drawing.Point(128, 466);
            this.btnBewStatus.Name = "btnBewStatus";
            this.btnBewStatus.Size = new System.Drawing.Size(184, 28);
            this.btnBewStatus.TabIndex = 11;
            this.btnBewStatus.Text = "Bewerberstatus zurücksetzen";
            this.btnBewStatus.Click += new System.EventHandler(this.btnBewStatus_Click);
            // 
            // btnBewDaten
            // 
            this.btnBewDaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnBewDaten.Appearance = appearance10;
            this.btnBewDaten.AutoWorkLayout = false;
            this.btnBewDaten.Enabled = false;
            this.btnBewDaten.IsStandardControl = false;
            this.btnBewDaten.Location = new System.Drawing.Point(312, 466);
            this.btnBewDaten.Name = "btnBewDaten";
            this.btnBewDaten.Size = new System.Drawing.Size(143, 28);
            this.btnBewDaten.TabIndex = 12;
            this.btnBewDaten.Text = "Klientdaten anzeigen";
            this.btnBewDaten.Click += new System.EventHandler(this.btnBewDaten_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.Image = ((object)(resources.GetObject("appearance11.Image")));
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnPrint.Appearance = appearance11;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.IsStandardControl = false;
            this.btnPrint.Location = new System.Drawing.Point(864, 466);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(143, 28);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Bewerberliste drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKlinik);
            this.groupBox1.Controls.Add(this.cbKlinik);
            this.groupBox1.Controls.Add(this.cmbKonfession);
            this.groupBox1.Controls.Add(this.lblKonfession);
            this.groupBox1.Controls.Add(this.cmbSexus);
            this.groupBox1.Controls.Add(this.lblGeschl);
            this.groupBox1.Controls.Add(this.cboBereich);
            this.groupBox1.Controls.Add(this.lblBereich);
            this.groupBox1.Controls.Add(this.cbAbteilung);
            this.groupBox1.Controls.Add(this.lblAbteilung);
            this.groupBox1.Controls.Add(this.lblBewerbername);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblBewerbungenVon);
            this.groupBox1.Controls.Add(this.dtpBewVon);
            this.groupBox1.Controls.Add(this.lblBis);
            this.groupBox1.Controls.Add(this.dtpBewBis);
            this.groupBox1.Controls.Add(this.dtpEinzBis);
            this.groupBox1.Controls.Add(this.cmbPriortaet);
            this.groupBox1.Controls.Add(this.lblBis2);
            this.groupBox1.Controls.Add(this.lblPriorität);
            this.groupBox1.Controls.Add(this.dtpEinzVon);
            this.groupBox1.Controls.Add(this.cmbPflegeart);
            this.groupBox1.Controls.Add(this.lblEinzugGewünschtVon);
            this.groupBox1.Controls.Add(this.lblPflegeart);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 153);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.Text = "Filterkriterien - geben Sie ein, wonach Sie suchen möchten und drücken Sie auf Su" +
    "chen (Eingabeaste):";
            // 
            // lblKlinik
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.lblKlinik.Appearance = appearance12;
            this.lblKlinik.AutoSize = true;
            this.lblKlinik.Location = new System.Drawing.Point(484, 60);
            this.lblKlinik.Name = "lblKlinik";
            this.lblKlinik.Size = new System.Drawing.Size(61, 14);
            this.lblKlinik.TabIndex = 154;
            this.lblKlinik.Text = "Einrichtung";
            // 
            // cbKlinik
            // 
            this.cbKlinik.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbKlinik.AutoSize = false;
            this.cbKlinik.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKlinik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbKlinik.Location = new System.Drawing.Point(548, 55);
            this.cbKlinik.Name = "cbKlinik";
            this.cbKlinik.Size = new System.Drawing.Size(233, 22);
            this.cbKlinik.TabIndex = 153;
            this.cbKlinik.TabStop = false;
            this.cbKlinik.ValueChanged += new System.EventHandler(this.cbKlinik_ValueChanged);
            // 
            // cmbKonfession
            // 
            this.cmbKonfession.AddEmptyEntry = false;
            this.cmbKonfession.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbKonfession.BerufsstandGruppeJNA = -1;
            this.cmbKonfession.Group = "KON";
            this.cmbKonfession.ID_PEP = -1;
            this.cmbKonfession.Location = new System.Drawing.Point(330, 125);
            this.cmbKonfession.MaxLength = 255;
            this.cmbKonfession.Name = "cmbKonfession";
            this.cmbKonfession.ShowAddButton = true;
            this.cmbKonfession.Size = new System.Drawing.Size(132, 21);
            this.cmbKonfession.TabIndex = 151;
            // 
            // lblKonfession
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.lblKonfession.Appearance = appearance13;
            this.lblKonfession.AutoSize = true;
            this.lblKonfession.Location = new System.Drawing.Point(264, 128);
            this.lblKonfession.Name = "lblKonfession";
            this.lblKonfession.Size = new System.Drawing.Size(60, 14);
            this.lblKonfession.TabIndex = 152;
            this.lblKonfession.Text = "Konfession";
            // 
            // cmbSexus
            // 
            this.cmbSexus.AddEmptyEntry = false;
            this.cmbSexus.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbSexus.BerufsstandGruppeJNA = -1;
            this.cmbSexus.Group = "SEX";
            this.cmbSexus.ID_PEP = -1;
            this.cmbSexus.Location = new System.Drawing.Point(130, 125);
            this.cmbSexus.MaxLength = 15;
            this.cmbSexus.Name = "cmbSexus";
            this.cmbSexus.ShowAddButton = true;
            this.cmbSexus.Size = new System.Drawing.Size(128, 21);
            this.cmbSexus.TabIndex = 149;
            // 
            // lblGeschl
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            this.lblGeschl.Appearance = appearance14;
            this.lblGeschl.AutoSize = true;
            this.lblGeschl.Location = new System.Drawing.Point(14, 128);
            this.lblGeschl.Name = "lblGeschl";
            this.lblGeschl.Size = new System.Drawing.Size(61, 14);
            this.lblGeschl.TabIndex = 150;
            this.lblGeschl.Text = "Geschlecht";
            // 
            // cboBereich
            // 
            this.cboBereich.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboBereich.Location = new System.Drawing.Point(548, 102);
            this.cboBereich.Name = "cboBereich";
            this.cboBereich.Size = new System.Drawing.Size(233, 21);
            this.cboBereich.TabIndex = 148;
            // 
            // lblBereich
            // 
            this.lblBereich.AutoSize = true;
            this.lblBereich.Location = new System.Drawing.Point(485, 105);
            this.lblBereich.Name = "lblBereich";
            this.lblBereich.Size = new System.Drawing.Size(43, 14);
            this.lblBereich.TabIndex = 147;
            this.lblBereich.Text = "Bereich";
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbAbteilung.Location = new System.Drawing.Point(548, 79);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(233, 21);
            this.cbAbteilung.TabIndex = 8;
            this.cbAbteilung.ValueChanged += new System.EventHandler(this.cbAbteilung_ValueChanged);
            this.cbAbteilung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // lblAbteilung
            // 
            appearance15.FontData.SizeInPoints = 8F;
            this.lblAbteilung.Appearance = appearance15;
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.Location = new System.Drawing.Point(485, 82);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(50, 14);
            this.lblAbteilung.TabIndex = 146;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // btnSearch
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance16;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(421, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearsh_Click);
            // 
            // cmbPriortaet
            // 
            this.cmbPriortaet.AddEmptyEntry = false;
            this.cmbPriortaet.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbPriortaet.BerufsstandGruppeJNA = -1;
            this.cmbPriortaet.Group = "PRI";
            this.cmbPriortaet.ID_PEP = -1;
            this.cmbPriortaet.Location = new System.Drawing.Point(130, 102);
            this.cmbPriortaet.MaxLength = 40;
            this.cmbPriortaet.Name = "cmbPriortaet";
            this.cmbPriortaet.ShowAddButton = true;
            this.cmbPriortaet.Size = new System.Drawing.Size(128, 21);
            this.cmbPriortaet.TabIndex = 6;
            this.cmbPriortaet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmbPflegeart
            // 
            this.cmbPflegeart.AddEmptyEntry = false;
            this.cmbPflegeart.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbPflegeart.BerufsstandGruppeJNA = -1;
            this.cmbPflegeart.Group = "PAR";
            this.cmbPflegeart.ID_PEP = -1;
            this.cmbPflegeart.Location = new System.Drawing.Point(331, 102);
            this.cmbPflegeart.MaxLength = 40;
            this.cmbPflegeart.Name = "cmbPflegeart";
            this.cmbPflegeart.ShowAddButton = true;
            this.cmbPflegeart.Size = new System.Drawing.Size(131, 21);
            this.cmbPflegeart.TabIndex = 7;
            this.cmbPflegeart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // dgBewerber2
            // 
            this.dgBewerber2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBewerber2.AutoWork = true;
            this.dgBewerber2.DataSource = this.dsPatientBewerber2;
            appearance17.BackColor = System.Drawing.Color.White;
            this.dgBewerber2.DisplayLayout.Appearance = appearance17;
            this.dgBewerber2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn20.Width = 98;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 132;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.Header.VisiblePosition = 4;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.Header.VisiblePosition = 5;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.Header.VisiblePosition = 6;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.Header.VisiblePosition = 7;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.Header.Caption = "Einzugswunsch";
            ultraGridColumn26.Header.VisiblePosition = 10;
            ultraGridColumn26.Width = 94;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.Header.VisiblePosition = 11;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn28.Header.VisiblePosition = 12;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn29.Header.VisiblePosition = 13;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.Header.VisiblePosition = 14;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn31.Header.Caption = "Priorität";
            ultraGridColumn31.Header.VisiblePosition = 15;
            ultraGridColumn31.Width = 72;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn32.Header.VisiblePosition = 16;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.Header.Caption = "Abteilung";
            ultraGridColumn33.Header.VisiblePosition = 17;
            ultraGridColumn33.Width = 145;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn34.Header.VisiblePosition = 3;
            ultraGridColumn34.Width = 90;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn35.Header.VisiblePosition = 8;
            ultraGridColumn35.Width = 88;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn36.Header.VisiblePosition = 9;
            ultraGridColumn36.Width = 88;
            ultraGridColumn1.Header.VisiblePosition = 18;
            ultraGridColumn1.Width = 171;
            ultraGridColumn2.DataType = typeof(System.Guid);
            ultraGridColumn2.Header.VisiblePosition = 19;
            ultraGridColumn2.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
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
            ultraGridColumn1,
            ultraGridColumn2});
            this.dgBewerber2.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgBewerber2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgBewerber2.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgBewerber2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgBewerber2.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgBewerber2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgBewerber2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgBewerber2.Location = new System.Drawing.Point(6, 160);
            this.dgBewerber2.Name = "dgBewerber2";
            this.dgBewerber2.Size = new System.Drawing.Size(1001, 303);
            this.dgBewerber2.TabIndex = 148;
            this.dgBewerber2.Text = "ultraGrid1";
            this.dgBewerber2.AfterRowActivate += new System.EventHandler(this.dgBewerber2_AfterRowActivate);
            this.dgBewerber2.DoubleClick += new System.EventHandler(this.dgBewerber2_DoubleClick);
            // 
            // dsPatientBewerber2
            // 
            this.dsPatientBewerber2.DataSetName = "dsPatientBewerber";
            this.dsPatientBewerber2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsKlinik1
            // 
            this.dsKlinik1.DataSetName = "dsKlinik";
            this.dsKlinik1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsKlinik1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucBewerber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgBewerber2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBewDaten);
            this.Controls.Add(this.btnBewStatus);
            this.Controls.Add(this.btnDel);
            this.Name = "ucBewerber";
            this.Size = new System.Drawing.Size(1012, 497);
            this.Load += new System.EventHandler(this.ucBewerber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBewVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBewBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEinzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEinzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonfession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSexus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriortaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPflegeart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBewerber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBewerber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblBewerbername;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtName;
        private QS2.Desktop.ControlManagment.BaseLabel lblBewerbungenVon;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBewVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBewBis;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbPriortaet;
        private QS2.Desktop.ControlManagment.BaseLabel lblPriorität;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegeart;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbPflegeart;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEinzBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis2;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEinzVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblEinzugGewünschtVon;
        private QS2.Desktop.ControlManagment.BaseButton btnDel;
        private QS2.Desktop.ControlManagment.BaseButton btnBewStatus;
        private QS2.Desktop.ControlManagment.BaseButton btnBewDaten;
        private QS2.Desktop.ControlManagment.BaseButton btnPrint;
        private ucButton btnSearch;
        private QS2.Desktop.ControlManagment.BaseGroupBox groupBox1;
        private QS2.Desktop.ControlManagment.BaseLabel lblAbteilung;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbAbteilung;
        private dsPatientBewerber dsPatientBewerber2;
        private QS2.Desktop.ControlManagment.BaseGrid dgBewerber2;
        public BaseControls.BereichsCombo cboBereich;
        private QS2.Desktop.ControlManagment.BaseLabel lblBereich;
        private BaseControls.AuswahlGruppeCombo cmbSexus;
        private QS2.Desktop.ControlManagment.BaseLabel lblGeschl;
        private BaseControls.AuswahlGruppeCombo cmbKonfession;
        private QS2.Desktop.ControlManagment.BaseLabel lblKonfession;
        private QS2.Desktop.ControlManagment.BaseLabel lblKlinik;
        public QS2.Desktop.ControlManagment.BaseComboEditor cbKlinik;
        private Global.db.Patient.dsKlinik dsKlinik1;
    }
}
