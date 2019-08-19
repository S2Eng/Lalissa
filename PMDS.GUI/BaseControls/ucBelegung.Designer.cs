using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    partial class ucBelegung
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
            dsBelegung dsBelegung1;
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Belegung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tag", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnzahlBetten");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Belegung");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.nBetten = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblBetten = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.cbAbteilung = new PMDS.GUI.BaseControls.AbteilungsCombo();
            this.grpAbteilungsauswahl = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.grpDatumsAuswahl = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.dtBis2 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtVon2 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.grpVorbelegen = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.btnAusfuellen2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUeberschreiben2 = new QS2.Desktop.ControlManagment.BaseButton();
            dsBelegung1 = new dsBelegung();
            ((System.ComponentModel.ISupportInitialize)(dsBelegung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBetten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAbteilungsauswahl)).BeginInit();
            this.grpAbteilungsauswahl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatumsAuswahl)).BeginInit();
            this.grpDatumsAuswahl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVorbelegen)).BeginInit();
            this.grpVorbelegen.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsBelegung1
            // 
            dsBelegung1.DataSetName = "dsBelegung";
            dsBelegung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nBetten
            // 
            this.nBetten.Location = new System.Drawing.Point(44, 20);
            this.nBetten.MaskInput = "nnn";
            this.nBetten.Name = "nBetten";
            this.nBetten.NullText = "0";
            this.nBetten.Size = new System.Drawing.Size(35, 21);
            this.nBetten.TabIndex = 7;
            // 
            // lblBetten
            // 
            this.lblBetten.AutoSize = true;
            this.lblBetten.Location = new System.Drawing.Point(6, 24);
            this.lblBetten.Name = "lblBetten";
            this.lblBetten.Size = new System.Drawing.Size(38, 13);
            this.lblBetten.TabIndex = 6;
            this.lblBetten.Text = "Betten";
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(136, 25);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(20, 13);
            this.lblBis.TabIndex = 5;
            this.lblBis.Text = "bis";
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(5, 25);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(26, 13);
            this.lblVon.TabIndex = 4;
            this.lblVon.Text = "Von";
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = dsBelegung1;
            appearance1.BackColor = System.Drawing.Color.White;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Abteilung";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance2.TextHAlignAsString = "Center";
            ultraGridColumn3.CellAppearance = appearance2;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(139, 0);
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance3;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn4.Header.Appearance = appearance4;
            ultraGridColumn4.Header.Caption = "Verfügbare Betten";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(199, 0);
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.Color.DarkGray;
            this.dgMain.DisplayLayout.CaptionAppearance = appearance5;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.Gainsboro;
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.Gainsboro;
            this.dgMain.DisplayLayout.Override.RowSelectorAppearance = appearance7;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(5, 62);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(764, 403);
            this.dgMain.TabIndex = 12;
            this.dgMain.Text = "Bettenkalender";
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbAbteilung.ENVAbteilung = false;
            this.cbAbteilung.Location = new System.Drawing.Point(10, 20);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.rKlinik = null;
            this.cbAbteilung.Size = new System.Drawing.Size(204, 21);
            this.cbAbteilung.TabIndex = 0;
            this.cbAbteilung.ValueChanged += new System.EventHandler(this.cbAbteilung_ValueChanged);
            // 
            // grpAbteilungsauswahl
            // 
            this.grpAbteilungsauswahl.Controls.Add(this.cbAbteilung);
            this.grpAbteilungsauswahl.Location = new System.Drawing.Point(5, 5);
            this.grpAbteilungsauswahl.Name = "grpAbteilungsauswahl";
            this.grpAbteilungsauswahl.Size = new System.Drawing.Size(224, 51);
            this.grpAbteilungsauswahl.TabIndex = 13;
            this.grpAbteilungsauswahl.Text = "Abteilungsauswahl";
            // 
            // grpDatumsAuswahl
            // 
            this.grpDatumsAuswahl.Controls.Add(this.dtBis2);
            this.grpDatumsAuswahl.Controls.Add(this.lblVon);
            this.grpDatumsAuswahl.Controls.Add(this.dtVon2);
            this.grpDatumsAuswahl.Controls.Add(this.lblBis);
            this.grpDatumsAuswahl.Location = new System.Drawing.Point(236, 5);
            this.grpDatumsAuswahl.Name = "grpDatumsAuswahl";
            this.grpDatumsAuswahl.Size = new System.Drawing.Size(270, 51);
            this.grpDatumsAuswahl.TabIndex = 14;
            this.grpDatumsAuswahl.Text = "Datumsauswahl";
            // 
            // dtBis2
            // 
            this.dtBis2.DateTime = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBis2.FormatString = "";
            this.dtBis2.Location = new System.Drawing.Point(161, 21);
            this.dtBis2.MaskInput = "";
            this.dtBis2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBis2.Name = "dtBis2";
            this.dtBis2.Size = new System.Drawing.Size(97, 21);
            this.dtBis2.TabIndex = 157;
            this.dtBis2.Value = null;
            this.dtBis2.ValueChanged += new System.EventHandler(this.dtBis2_ValueChanged);
            // 
            // dtVon2
            // 
            this.dtVon2.DateTime = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtVon2.FormatString = "";
            this.dtVon2.Location = new System.Drawing.Point(34, 21);
            this.dtVon2.MaskInput = "";
            this.dtVon2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtVon2.Name = "dtVon2";
            this.dtVon2.Size = new System.Drawing.Size(97, 21);
            this.dtVon2.TabIndex = 156;
            this.dtVon2.Value = null;
            this.dtVon2.ValueChanged += new System.EventHandler(this.dtVon2_ValueChanged);
            // 
            // grpVorbelegen
            // 
            this.grpVorbelegen.Controls.Add(this.nBetten);
            this.grpVorbelegen.Controls.Add(this.btnAusfuellen2);
            this.grpVorbelegen.Controls.Add(this.btnUeberschreiben2);
            this.grpVorbelegen.Controls.Add(this.lblBetten);
            this.grpVorbelegen.Location = new System.Drawing.Point(512, 5);
            this.grpVorbelegen.Name = "grpVorbelegen";
            this.grpVorbelegen.Size = new System.Drawing.Size(173, 51);
            this.grpVorbelegen.TabIndex = 14;
            this.grpVorbelegen.Text = "Vorbelegen";
            // 
            // btnAusfuellen2
            // 
            this.btnAusfuellen2.AutoWorkLayout = false;
            this.btnAusfuellen2.IsStandardControl = false;
            this.btnAusfuellen2.Location = new System.Drawing.Point(212, 20);
            this.btnAusfuellen2.Name = "btnAusfuellen2";
            this.btnAusfuellen2.Size = new System.Drawing.Size(45, 24);
            this.btnAusfuellen2.TabIndex = 16;
            this.btnAusfuellen2.Text = "Ausfüllen";
            this.btnAusfuellen2.Visible = false;
            this.btnAusfuellen2.Click += new System.EventHandler(this.btnAusfuellen2_Click);
            // 
            // btnUeberschreiben2
            // 
            this.btnUeberschreiben2.AutoWorkLayout = false;
            this.btnUeberschreiben2.IsStandardControl = false;
            this.btnUeberschreiben2.Location = new System.Drawing.Point(88, 17);
            this.btnUeberschreiben2.Name = "btnUeberschreiben2";
            this.btnUeberschreiben2.Size = new System.Drawing.Size(77, 26);
            this.btnUeberschreiben2.TabIndex = 15;
            this.btnUeberschreiben2.Text = "Ausfüllen";
            this.btnUeberschreiben2.Click += new System.EventHandler(this.btnUeberschreiben2_Click);
            // 
            // ucBelegung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.grpVorbelegen);
            this.Controls.Add(this.grpDatumsAuswahl);
            this.Controls.Add(this.grpAbteilungsauswahl);
            this.Controls.Add(this.dgMain);
            this.Name = "ucBelegung";
            this.Size = new System.Drawing.Size(774, 469);
            ((System.ComponentModel.ISupportInitialize)(dsBelegung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBetten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAbteilungsauswahl)).EndInit();
            this.grpAbteilungsauswahl.ResumeLayout(false);
            this.grpAbteilungsauswahl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatumsAuswahl)).EndInit();
            this.grpDatumsAuswahl.ResumeLayout(false);
            this.grpDatumsAuswahl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVorbelegen)).EndInit();
            this.grpVorbelegen.ResumeLayout(false);
            this.grpVorbelegen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblBis;
        private QS2.Desktop.ControlManagment.BaseLableWin lblVon;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private AbteilungsCombo cbAbteilung;
        private QS2.Desktop.ControlManagment.BaseNumericEditor nBetten;
        private QS2.Desktop.ControlManagment.BaseLableWin lblBetten;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpAbteilungsauswahl;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpDatumsAuswahl;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpVorbelegen;
        private QS2.Desktop.ControlManagment.BaseButton btnUeberschreiben2;
        private QS2.Desktop.ControlManagment.BaseButton btnAusfuellen2;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtVon2;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtBis2;
    }
}
