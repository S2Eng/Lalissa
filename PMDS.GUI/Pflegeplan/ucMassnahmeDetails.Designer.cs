namespace PMDS.GUI
{
    partial class ucMassnahmeDetails
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
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.lblBerufsstand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbDauer = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblDauer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbIntervall = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.osIntervall = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblIntervall = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblZeitpunkte = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbRMOptionalJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbParalell = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblHinweis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbWarnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lSicht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbSicht = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblDokument = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnShow = new QS2.Desktop.ControlManagment.BaseButton();
            this.cbBedarfsmedikation = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.grpSollwerte = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblAbzeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.eintragtypCombo1 = new PMDS.GUI.BaseControls.EintragtypCombo();
            this.cbSerie = new PMDS.GUI.BaseControls.MassnahmenSerienCombo2();
            this.cbZeitBereiche = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblZeitbereiche = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMin = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucWochenTage21 = new PMDS.GUI.ucWochenTage2();
            this.cbLinkDokument = new PMDS.GUI.BaseControls.LinkDokumenteCombo();
            this.cbBerufsstand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsmedikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSollwerte)).BeginInit();
            this.grpSollwerte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eintragtypCombo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitBereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBerufsstand
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblBerufsstand.Appearance = appearance1;
            this.lblBerufsstand.AutoSize = true;
            this.lblBerufsstand.Location = new System.Drawing.Point(6, 351);
            this.lblBerufsstand.Name = "lblBerufsstand";
            this.lblBerufsstand.Size = new System.Drawing.Size(65, 14);
            this.lblBerufsstand.TabIndex = 9;
            this.lblBerufsstand.Text = "Berufsstand";
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(77, 171);
            this.tbDauer.MaskInput = "nnnn";
            this.tbDauer.MaxValue = 9999;
            this.tbDauer.MinValue = 0;
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.PromptChar = ' ';
            this.tbDauer.Size = new System.Drawing.Size(51, 21);
            this.tbDauer.TabIndex = 3;
            this.tbDauer.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblDauer
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblDauer.Appearance = appearance2;
            this.lblDauer.AutoSize = true;
            this.lblDauer.Location = new System.Drawing.Point(7, 175);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(35, 14);
            this.lblDauer.TabIndex = 12;
            this.lblDauer.Text = "Dauer";
            // 
            // tbIntervall
            // 
            this.tbIntervall.Location = new System.Drawing.Point(77, 194);
            this.tbIntervall.MaskInput = "nnnn";
            this.tbIntervall.MaxValue = 9999;
            this.tbIntervall.MinValue = 0;
            this.tbIntervall.Name = "tbIntervall";
            this.tbIntervall.PromptChar = ' ';
            this.tbIntervall.Size = new System.Drawing.Size(51, 21);
            this.tbIntervall.TabIndex = 4;
            this.tbIntervall.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // osIntervall
            // 
            this.osIntervall.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "Tage";
            valueListItem6.DataValue = "ValueListItem2";
            valueListItem6.DisplayText = "Wochen";
            valueListItem1.DataValue = "ValueListItem3";
            valueListItem1.DisplayText = "Monate";
            this.osIntervall.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem1});
            this.osIntervall.ItemSpacingVertical = 2;
            this.osIntervall.Location = new System.Drawing.Point(134, 197);
            this.osIntervall.Name = "osIntervall";
            this.osIntervall.Size = new System.Drawing.Size(168, 18);
            this.osIntervall.TabIndex = 5;
            this.osIntervall.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblIntervall
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblIntervall.Appearance = appearance3;
            this.lblIntervall.AutoSize = true;
            this.lblIntervall.Location = new System.Drawing.Point(7, 198);
            this.lblIntervall.Name = "lblIntervall";
            this.lblIntervall.Size = new System.Drawing.Size(44, 14);
            this.lblIntervall.TabIndex = 15;
            this.lblIntervall.Text = "Intervall";
            // 
            // lblZeitpunkte
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblZeitpunkte.Appearance = appearance4;
            this.lblZeitpunkte.AutoSize = true;
            this.lblZeitpunkte.Location = new System.Drawing.Point(7, 303);
            this.lblZeitpunkte.Name = "lblZeitpunkte";
            this.lblZeitpunkte.Size = new System.Drawing.Size(57, 14);
            this.lblZeitpunkte.TabIndex = 28;
            this.lblZeitpunkte.Text = "Zeitpunkte";
            // 
            // cbRMOptionalJN
            // 
            this.cbRMOptionalJN.Location = new System.Drawing.Point(77, 395);
            this.cbRMOptionalJN.Name = "cbRMOptionalJN";
            this.cbRMOptionalJN.Size = new System.Drawing.Size(144, 20);
            this.cbRMOptionalJN.TabIndex = 11;
            this.cbRMOptionalJN.Text = "Bericht freiwillig";
            this.cbRMOptionalJN.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbParalell
            // 
            this.cbParalell.Location = new System.Drawing.Point(77, 395);
            this.cbParalell.Name = "cbParalell";
            this.cbParalell.Size = new System.Drawing.Size(136, 20);
            this.cbParalell.TabIndex = 12;
            this.cbParalell.Text = "Parallel durchführbar";
            this.cbParalell.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // lblBezeichnung
            // 
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance5;
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(6, 19);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(70, 14);
            this.lblBezeichnung.TabIndex = 32;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(7, 39);
            this.tbText.MaxLength = 255;
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(295, 50);
            this.tbText.TabIndex = 1;
            this.tbText.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblHinweis
            // 
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblHinweis.Appearance = appearance6;
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(7, 95);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(44, 14);
            this.lblHinweis.TabIndex = 35;
            this.lblHinweis.Text = "Hinweis";
            // 
            // tbWarnung
            // 
            this.tbWarnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarnung.Location = new System.Drawing.Point(7, 115);
            this.tbWarnung.MaxLength = 255;
            this.tbWarnung.Multiline = true;
            this.tbWarnung.Name = "tbWarnung";
            this.tbWarnung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWarnung.Size = new System.Drawing.Size(295, 50);
            this.tbWarnung.TabIndex = 2;
            this.tbWarnung.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lSicht
            // 
            this.lSicht.AutoSize = true;
            this.lSicht.Location = new System.Drawing.Point(7, 276);
            this.lSicht.Name = "lSicht";
            this.lSicht.Padding = new System.Drawing.Size(0, 4);
            this.lSicht.Size = new System.Drawing.Size(29, 22);
            this.lSicht.TabIndex = 37;
            this.lSicht.Text = "Sicht";
            // 
            // cbSicht
            // 
            this.cbSicht.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbSicht.Location = new System.Drawing.Point(77, 276);
            this.cbSicht.Name = "cbSicht";
            this.cbSicht.Size = new System.Drawing.Size(167, 21);
            this.cbSicht.TabIndex = 7;
            this.cbSicht.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblDokument
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.lblDokument.Appearance = appearance7;
            this.lblDokument.AutoSize = true;
            this.lblDokument.Location = new System.Drawing.Point(6, 441);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(50, 14);
            this.lblDokument.TabIndex = 38;
            this.lblDokument.Text = "Standard";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.AutoWorkLayout = false;
            this.btnShow.Enabled = false;
            this.btnShow.IsStandardControl = false;
            this.btnShow.Location = new System.Drawing.Point(248, 436);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(68, 23);
            this.btnShow.TabIndex = 15;
            this.btnShow.Text = "Anzeigen";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cbBedarfsmedikation
            // 
            this.cbBedarfsmedikation.Location = new System.Drawing.Point(77, 415);
            this.cbBedarfsmedikation.Name = "cbBedarfsmedikation";
            this.cbBedarfsmedikation.Size = new System.Drawing.Size(144, 20);
            this.cbBedarfsmedikation.TabIndex = 13;
            this.cbBedarfsmedikation.Text = "Einzelverordnung aktiv";
            this.cbBedarfsmedikation.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // grpSollwerte
            // 
            this.grpSollwerte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSollwerte.Controls.Add(this.lblAbzeichnung);
            this.grpSollwerte.Controls.Add(this.eintragtypCombo1);
            this.grpSollwerte.Controls.Add(this.cbSerie);
            this.grpSollwerte.Controls.Add(this.cbZeitBereiche);
            this.grpSollwerte.Controls.Add(this.lblZeitbereiche);
            this.grpSollwerte.Controls.Add(this.lblMin);
            this.grpSollwerte.Controls.Add(this.ucWochenTage21);
            this.grpSollwerte.Controls.Add(this.cbRMOptionalJN);
            this.grpSollwerte.Controls.Add(this.osIntervall);
            this.grpSollwerte.Controls.Add(this.lSicht);
            this.grpSollwerte.Controls.Add(this.cbParalell);
            this.grpSollwerte.Controls.Add(this.cbSicht);
            this.grpSollwerte.Controls.Add(this.lblZeitpunkte);
            this.grpSollwerte.Controls.Add(this.cbBedarfsmedikation);
            this.grpSollwerte.Controls.Add(this.btnShow);
            this.grpSollwerte.Controls.Add(this.cbLinkDokument);
            this.grpSollwerte.Controls.Add(this.lblDokument);
            this.grpSollwerte.Controls.Add(this.lblBerufsstand);
            this.grpSollwerte.Controls.Add(this.cbBerufsstand);
            this.grpSollwerte.Controls.Add(this.lblHinweis);
            this.grpSollwerte.Controls.Add(this.tbWarnung);
            this.grpSollwerte.Controls.Add(this.lblDauer);
            this.grpSollwerte.Controls.Add(this.tbDauer);
            this.grpSollwerte.Controls.Add(this.tbText);
            this.grpSollwerte.Controls.Add(this.lblBezeichnung);
            this.grpSollwerte.Controls.Add(this.lblIntervall);
            this.grpSollwerte.Controls.Add(this.tbIntervall);
            this.grpSollwerte.Location = new System.Drawing.Point(3, 3);
            this.grpSollwerte.Name = "grpSollwerte";
            this.grpSollwerte.Size = new System.Drawing.Size(322, 465);
            this.grpSollwerte.TabIndex = 45;
            this.grpSollwerte.Text = "Sollwerte";
            // 
            // lblAbzeichnung
            // 
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.lblAbzeichnung.Appearance = appearance8;
            this.lblAbzeichnung.AutoSize = true;
            this.lblAbzeichnung.Location = new System.Drawing.Point(7, 376);
            this.lblAbzeichnung.Name = "lblAbzeichnung";
            this.lblAbzeichnung.Size = new System.Drawing.Size(70, 14);
            this.lblAbzeichnung.TabIndex = 50;
            this.lblAbzeichnung.Text = "Abzeichnung";
            // 
            // eintragtypCombo1
            // 
            this.eintragtypCombo1.EintragTyp = PMDS.Global.EintragFlag.Einzelabzeichnung;
            this.eintragtypCombo1.Location = new System.Drawing.Point(77, 373);
            this.eintragtypCombo1.Name = "eintragtypCombo1";
            this.eintragtypCombo1.Size = new System.Drawing.Size(167, 21);
            this.eintragtypCombo1.TabIndex = 49;
            this.eintragtypCombo1.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // cbSerie
            // 
            this.cbSerie.DISPLAY_TEXT = "";
            this.cbSerie.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbSerie.Location = new System.Drawing.Point(77, 300);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.Size = new System.Drawing.Size(167, 21);
            this.cbSerie.TabIndex = 8;
            this.cbSerie.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // cbZeitBereiche
            // 
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            editorButton1.Appearance = appearance9;
            editorButton1.Text = "+";
            this.cbZeitBereiche.ButtonsRight.Add(editorButton1);
            this.cbZeitBereiche.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbZeitBereiche.Location = new System.Drawing.Point(77, 324);
            this.cbZeitBereiche.Name = "cbZeitBereiche";
            this.cbZeitBereiche.Size = new System.Drawing.Size(167, 21);
            this.cbZeitBereiche.TabIndex = 9;
            this.cbZeitBereiche.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.cbZeitBereiche.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cbZeitBereiche_EditorButtonClick);
            // 
            // lblZeitbereiche
            // 
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lblZeitbereiche.Appearance = appearance10;
            this.lblZeitbereiche.AutoSize = true;
            this.lblZeitbereiche.Location = new System.Drawing.Point(7, 327);
            this.lblZeitbereiche.Name = "lblZeitbereiche";
            this.lblZeitbereiche.Size = new System.Drawing.Size(67, 14);
            this.lblZeitbereiche.TabIndex = 48;
            this.lblZeitbereiche.Text = "Zeitbereiche";
            // 
            // lblMin
            // 
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.lblMin.Appearance = appearance11;
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(134, 175);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(22, 14);
            this.lblMin.TabIndex = 46;
            this.lblMin.Text = "min";
            // 
            // ucWochenTage21
            // 
            this.ucWochenTage21.Location = new System.Drawing.Point(72, 221);
            this.ucWochenTage21.Name = "ucWochenTage21";
            this.ucWochenTage21.Size = new System.Drawing.Size(149, 46);
            this.ucWochenTage21.TabIndex = 6;
            this.ucWochenTage21.WOCHENTAGE = 0;
            this.ucWochenTage21.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // cbLinkDokument
            // 
            this.cbLinkDokument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLinkDokument.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLinkDokument.IDLinkDokument = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbLinkDokument.Location = new System.Drawing.Point(77, 438);
            this.cbLinkDokument.Name = "cbLinkDokument";
            this.cbLinkDokument.Size = new System.Drawing.Size(167, 21);
            this.cbLinkDokument.TabIndex = 14;
            this.cbLinkDokument.ValueChanged += new System.EventHandler(this.cbLinkDokument_ValueChanged);
            // 
            // cbBerufsstand
            // 
            this.cbBerufsstand.AddEmptyEntry = false;
            this.cbBerufsstand.BerufsstandGruppeJNA = -1;
            this.cbBerufsstand.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBerufsstand.Group = "BER";
            this.cbBerufsstand.Location = new System.Drawing.Point(77, 348);
            this.cbBerufsstand.Name = "cbBerufsstand";
            this.cbBerufsstand.ShowAddButton = true;
            this.cbBerufsstand.Size = new System.Drawing.Size(167, 21);
            this.cbBerufsstand.TabIndex = 10;
            this.cbBerufsstand.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucMassnahmeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSollwerte);
            this.Name = "ucMassnahmeDetails";
            this.Size = new System.Drawing.Size(330, 473);
            this.Load += new System.EventHandler(this.ucMassnahmeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsmedikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSollwerte)).EndInit();
            this.grpSollwerte.ResumeLayout(false);
            this.grpSollwerte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eintragtypCombo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitBereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbBerufsstand;
        private QS2.Desktop.ControlManagment.BaseLabel lblBerufsstand;
        private QS2.Desktop.ControlManagment.BaseNumericEditor tbDauer;
        private QS2.Desktop.ControlManagment.BaseLabel lblDauer;
        private QS2.Desktop.ControlManagment.BaseNumericEditor tbIntervall;
        private QS2.Desktop.ControlManagment.BaseOptionSet osIntervall;
        private QS2.Desktop.ControlManagment.BaseLabel lblIntervall;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitpunkte;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbRMOptionalJN;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbParalell;
        private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        private QS2.Desktop.ControlManagment.BaseLabel lblHinweis;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbWarnung;
        private QS2.Desktop.ControlManagment.BaseLabel lSicht;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbSicht;
        private PMDS.GUI.BaseControls.LinkDokumenteCombo cbLinkDokument;
        private QS2.Desktop.ControlManagment.BaseLabel lblDokument;
        private QS2.Desktop.ControlManagment.BaseButton btnShow;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbBedarfsmedikation;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpSollwerte;
        private ucWochenTage2 ucWochenTage21;
        private QS2.Desktop.ControlManagment.BaseLabel lblMin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitbereiche;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbZeitBereiche;
        private PMDS.GUI.BaseControls.MassnahmenSerienCombo2 cbSerie;
        private PMDS.GUI.BaseControls.EintragtypCombo eintragtypCombo1;
        private QS2.Desktop.ControlManagment.BaseLabel lblAbzeichnung;
    }
}
