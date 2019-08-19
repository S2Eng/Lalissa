namespace PMDS.GUI.Arztabrechnung
{
    partial class contArztabrechnungDetail
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.contextMenuStripSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klientenmehrfachauswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.dteDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblDatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboBenutzer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPatient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lvLeistungen = new Infragistics.Win.UltraWinListView.UltraListView();
            this.lblLeistungen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFoundLeistungen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.contPatientUserPicker1 = new PMDS.GUI.PatientUserPicker.contPatientUserPicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.panelBottom.SuspendLayout();
            this.contextMenuStripSave.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvLeistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnAbort);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 608);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(958, 50);
            this.panelBottom.TabIndex = 100;
            // 
            // btnAbort
            // 
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance8;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(422, 7);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(119, 36);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.contextMenuStrip1 = this.contextMenuStripSave;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(542, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 36);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // contextMenuStripSave
            // 
            this.contextMenuStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klientenmehrfachauswahlToolStripMenuItem});
            this.contextMenuStripSave.Name = "contextMenuStripSave";
            this.contextMenuStripSave.Size = new System.Drawing.Size(212, 26);
            // 
            // klientenmehrfachauswahlToolStripMenuItem
            // 
            this.klientenmehrfachauswahlToolStripMenuItem.Name = "klientenmehrfachauswahlToolStripMenuItem";
            this.klientenmehrfachauswahlToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.klientenmehrfachauswahlToolStripMenuItem.Text = "Klientenmehrfachauswahl";
            this.klientenmehrfachauswahlToolStripMenuItem.Click += new System.EventHandler(this.klientenmehrfachauswahlToolStripMenuItem_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Controls.Add(this.dteDatum);
            this.panelCenter.Controls.Add(this.lblDatum);
            this.panelCenter.Controls.Add(this.cboBenutzer);
            this.panelCenter.Controls.Add(this.lblPatient);
            this.panelCenter.Controls.Add(this.lvLeistungen);
            this.panelCenter.Controls.Add(this.lblLeistungen);
            this.panelCenter.Controls.Add(this.lblAnmerkung);
            this.panelCenter.Controls.Add(this.txtAnmerkung);
            this.panelCenter.Controls.Add(this.lblBenutzer);
            this.panelCenter.Controls.Add(this.lblFoundLeistungen);
            this.panelCenter.Controls.Add(this.contPatientUserPicker1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(958, 608);
            this.panelCenter.TabIndex = 0;
            // 
            // dteDatum
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.dteDatum.Appearance = appearance1;
            this.dteDatum.BackColor = System.Drawing.Color.White;
            this.dteDatum.FormatString = "";
            this.dteDatum.Location = new System.Drawing.Point(489, 39);
            this.dteDatum.Margin = new System.Windows.Forms.Padding(4);
            this.dteDatum.MaskInput = "dd.mm.yyyy hh:mm";
            this.dteDatum.Name = "dteDatum";
            this.dteDatum.ownFormat = "";
            this.dteDatum.ownMaskInput = "";
            this.dteDatum.Size = new System.Drawing.Size(149, 24);
            this.dteDatum.TabIndex = 212;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(433, 43);
            this.lblDatum.Margin = new System.Windows.Forms.Padding(5);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(48, 17);
            this.lblDatum.TabIndex = 213;
            this.lblDatum.Text = "Beginn";
            // 
            // cboBenutzer
            // 
            this.cboBenutzer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = "Noch nicht begonnen";
            valueListItem5.DisplayText = "Noch nicht begonnen";
            valueListItem1.DataValue = "Abgeschlossen";
            valueListItem1.DisplayText = "Abgeschlossen";
            valueListItem6.DataValue = "Läuft derzeit";
            valueListItem6.DisplayText = "Läuft derzeit";
            valueListItem7.DataValue = "Undefiniert";
            valueListItem7.DisplayText = "Undefiniert";
            this.cboBenutzer.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem1,
            valueListItem6,
            valueListItem7});
            this.cboBenutzer.Location = new System.Drawing.Point(84, 9);
            this.cboBenutzer.Margin = new System.Windows.Forms.Padding(5);
            this.cboBenutzer.Name = "cboBenutzer";
            this.cboBenutzer.Size = new System.Drawing.Size(336, 24);
            this.cboBenutzer.TabIndex = 0;
            this.cboBenutzer.ValueChanged += new System.EventHandler(this.cboÄrzte_ValueChanged);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(433, 12);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(48, 17);
            this.lblPatient.TabIndex = 211;
            this.lblPatient.Text = "Patient";
            // 
            // lvLeistungen
            // 
            this.lvLeistungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.SizeInPoints = 10F;
            this.lvLeistungen.Appearance = appearance3;
            this.lvLeistungen.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvLeistungen.ItemSettings.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvLeistungen.ItemSettings.SelectedAppearance = appearance5;
            this.lvLeistungen.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvLeistungen.Location = new System.Drawing.Point(8, 69);
            this.lvLeistungen.Margin = new System.Windows.Forms.Padding(4);
            this.lvLeistungen.Name = "lvLeistungen";
            this.lvLeistungen.Size = new System.Drawing.Size(942, 351);
            this.lvLeistungen.TabIndex = 1;
            this.lvLeistungen.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvLeistungen.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvLeistungen.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvLeistungen.ItemCheckStateChanging += new Infragistics.Win.UltraWinListView.ItemCheckStateChangingEventHandler(this.lvLeistungen_ItemCheckStateChanging);
            this.lvLeistungen.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.lvLeistungen_ItemCheckStateChanged);
            this.lvLeistungen.Click += new System.EventHandler(this.lvLeistungen_Click);
            // 
            // lblLeistungen
            // 
            this.lblLeistungen.AutoSize = true;
            this.lblLeistungen.Location = new System.Drawing.Point(8, 49);
            this.lblLeistungen.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblLeistungen.Name = "lblLeistungen";
            this.lblLeistungen.Size = new System.Drawing.Size(72, 17);
            this.lblLeistungen.TabIndex = 209;
            this.lblLeistungen.Text = "Leistungen";
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(9, 447);
            this.lblAnmerkung.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(75, 17);
            this.lblAnmerkung.TabIndex = 208;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // txtAnmerkung
            // 
            this.txtAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Top";
            this.txtAnmerkung.Appearance = appearance6;
            this.txtAnmerkung.AutoSize = false;
            this.txtAnmerkung.Location = new System.Drawing.Point(8, 469);
            this.txtAnmerkung.Margin = new System.Windows.Forms.Padding(5);
            this.txtAnmerkung.MaxLength = 0;
            this.txtAnmerkung.Multiline = true;
            this.txtAnmerkung.Name = "txtAnmerkung";
            this.txtAnmerkung.Size = new System.Drawing.Size(942, 134);
            this.txtAnmerkung.TabIndex = 3;
            this.txtAnmerkung.ValueChanged += new System.EventHandler(this.txtAnmerkung_ValueChanged);
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(12, 12);
            this.lblBenutzer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(60, 17);
            this.lblBenutzer.TabIndex = 206;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // lblFoundLeistungen
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.FontData.SizeInPoints = 7.5F;
            this.lblFoundLeistungen.Appearance = appearance9;
            this.lblFoundLeistungen.AutoSize = true;
            this.lblFoundLeistungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFoundLeistungen.Location = new System.Drawing.Point(8, 421);
            this.lblFoundLeistungen.Margin = new System.Windows.Forms.Padding(4);
            this.lblFoundLeistungen.Name = "lblFoundLeistungen";
            this.lblFoundLeistungen.Size = new System.Drawing.Size(66, 13);
            this.lblFoundLeistungen.TabIndex = 132;
            this.lblFoundLeistungen.Text = "Gefunden: 10";
            // 
            // contPatientUserPicker1
            // 
            this.contPatientUserPicker1.BackColor = System.Drawing.Color.White;
            this.contPatientUserPicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contPatientUserPicker1.Location = new System.Drawing.Point(489, 6);
            this.contPatientUserPicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contPatientUserPicker1.Name = "contPatientUserPicker1";
            this.contPatientUserPicker1.Size = new System.Drawing.Size(461, 30);
            this.contPatientUserPicker1.TabIndex = 214;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contArztabrechnungDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "contArztabrechnungDetail";
            this.Size = new System.Drawing.Size(958, 658);
            this.Load += new System.EventHandler(this.contArztabrechnung_Load);
            this.VisibleChanged += new System.EventHandler(this.contArztabrechnungDetail_VisibleChanged);
            this.panelBottom.ResumeLayout(false);
            this.contextMenuStripSave.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvLeistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private QS2.Desktop.ControlManagment.BaseLabel lblFoundLeistungen;
        protected Infragistics.Win.UltraWinListView.UltraListView lvLeistungen;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboBenutzer;
        public QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        public QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtAnmerkung;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseLabel lblLeistungen;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        public QS2.Desktop.ControlManagment.BaseLabel lblPatient;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSave;
        private System.Windows.Forms.ToolStripMenuItem klientenmehrfachauswahlToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dteDatum;
        public QS2.Desktop.ControlManagment.BaseLabel lblDatum;
        private PatientUserPicker.contPatientUserPicker contPatientUserPicker1;
    }
}
