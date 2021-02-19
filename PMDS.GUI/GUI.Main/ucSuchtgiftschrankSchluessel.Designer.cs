namespace PMDS.GUI.GUI.Main
{
    partial class ucSuchtgiftschrankSchlüssel
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
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblÜbernehmer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.uceAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblÜbergabeUm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtÜbergeber = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblÜbergeber = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtÜbernehmerPassword = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblÜbernehmerPassword = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboKlinik = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblKlinik = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboAbteilung = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblAbteilung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dropDownPatienten = new Infragistics.Win.Misc.UltraDropDownButton();
            this.uPopUpContUsers = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbergeber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbernehmerPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlinik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(278, 435);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 32);
            this.btnAbort.TabIndex = 11;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(194, 435);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblÜbernehmer
            // 
            this.lblÜbernehmer.AutoSize = true;
            this.lblÜbernehmer.Location = new System.Drawing.Point(23, 48);
            this.lblÜbernehmer.Margin = new System.Windows.Forms.Padding(5);
            this.lblÜbernehmer.Name = "lblÜbernehmer";
            this.lblÜbernehmer.Size = new System.Drawing.Size(67, 14);
            this.lblÜbernehmer.TabIndex = 212;
            this.lblÜbernehmer.Text = "Übernehmer";
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(23, 186);
            this.lblAnmerkung.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(62, 14);
            this.lblAnmerkung.TabIndex = 214;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // txtAnmerkung
            // 
            this.txtAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Top";
            this.txtAnmerkung.Appearance = appearance3;
            this.txtAnmerkung.AutoSize = false;
            this.txtAnmerkung.Location = new System.Drawing.Point(146, 188);
            this.txtAnmerkung.Margin = new System.Windows.Forms.Padding(5);
            this.txtAnmerkung.MaxLength = 0;
            this.txtAnmerkung.Multiline = true;
            this.txtAnmerkung.Name = "txtAnmerkung";
            this.txtAnmerkung.Size = new System.Drawing.Size(387, 239);
            this.txtAnmerkung.TabIndex = 6;
            // 
            // uceAm
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceAm.Appearance = appearance4;
            this.uceAm.BackColor = System.Drawing.Color.White;
            this.uceAm.FormatString = "";
            this.uceAm.Location = new System.Drawing.Point(146, 156);
            this.uceAm.Margin = new System.Windows.Forms.Padding(4);
            this.uceAm.MaskInput = "dd.mm.yyyy hh:mm";
            this.uceAm.Name = "uceAm";
            this.uceAm.ownFormat = "";
            this.uceAm.ownMaskInput = "";
            this.uceAm.Size = new System.Drawing.Size(124, 21);
            this.uceAm.TabIndex = 5;
            // 
            // lblÜbergabeUm
            // 
            this.lblÜbergabeUm.AutoSize = true;
            this.lblÜbergabeUm.Location = new System.Drawing.Point(23, 159);
            this.lblÜbergabeUm.Margin = new System.Windows.Forms.Padding(5);
            this.lblÜbergabeUm.Name = "lblÜbergabeUm";
            this.lblÜbergabeUm.Size = new System.Drawing.Size(73, 14);
            this.lblÜbergabeUm.TabIndex = 220;
            this.lblÜbergabeUm.Text = "Übergabe um";
            // 
            // txtÜbergeber
            // 
            this.txtÜbergeber.Location = new System.Drawing.Point(146, 19);
            this.txtÜbergeber.MaxLength = 25;
            this.txtÜbergeber.Name = "txtÜbergeber";
            this.txtÜbergeber.ReadOnly = true;
            this.txtÜbergeber.Size = new System.Drawing.Size(276, 21);
            this.txtÜbergeber.TabIndex = 0;
            // 
            // lblÜbergeber
            // 
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblÜbergeber.Appearance = appearance5;
            this.lblÜbergeber.Location = new System.Drawing.Point(23, 15);
            this.lblÜbergeber.Name = "lblÜbergeber";
            this.lblÜbergeber.Size = new System.Drawing.Size(81, 29);
            this.lblÜbergeber.TabIndex = 222;
            this.lblÜbergeber.Text = "Übergeber";
            // 
            // txtÜbernehmerPassword
            // 
            this.txtÜbernehmerPassword.Location = new System.Drawing.Point(146, 70);
            this.txtÜbernehmerPassword.MaxLength = 25;
            this.txtÜbernehmerPassword.Name = "txtÜbernehmerPassword";
            this.txtÜbernehmerPassword.PasswordChar = '*';
            this.txtÜbernehmerPassword.Size = new System.Drawing.Size(276, 21);
            this.txtÜbernehmerPassword.TabIndex = 2;
            // 
            // lblÜbernehmerPassword
            // 
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblÜbernehmerPassword.Appearance = appearance6;
            this.lblÜbernehmerPassword.Location = new System.Drawing.Point(23, 66);
            this.lblÜbernehmerPassword.Name = "lblÜbernehmerPassword";
            this.lblÜbernehmerPassword.Size = new System.Drawing.Size(121, 29);
            this.lblÜbernehmerPassword.TabIndex = 224;
            this.lblÜbernehmerPassword.Text = "Passwort Übernehmer";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboKlinik
            // 
            this.cboKlinik.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboKlinik.Location = new System.Drawing.Point(146, 98);
            this.cboKlinik.Margin = new System.Windows.Forms.Padding(4);
            this.cboKlinik.Name = "cboKlinik";
            this.cboKlinik.Size = new System.Drawing.Size(235, 21);
            this.cboKlinik.TabIndex = 3;
            this.cboKlinik.ValueChanged += new System.EventHandler(this.cboKlinik_ValueChanged);
            // 
            // lblKlinik
            // 
            this.lblKlinik.AutoSize = true;
            this.lblKlinik.Location = new System.Drawing.Point(23, 101);
            this.lblKlinik.Margin = new System.Windows.Forms.Padding(5);
            this.lblKlinik.Name = "lblKlinik";
            this.lblKlinik.Size = new System.Drawing.Size(31, 14);
            this.lblKlinik.TabIndex = 226;
            this.lblKlinik.Text = "Klinik";
            // 
            // cboAbteilung
            // 
            this.cboAbteilung.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboAbteilung.Location = new System.Drawing.Point(146, 123);
            this.cboAbteilung.Margin = new System.Windows.Forms.Padding(4);
            this.cboAbteilung.Name = "cboAbteilung";
            this.cboAbteilung.Size = new System.Drawing.Size(235, 21);
            this.cboAbteilung.TabIndex = 4;
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.Location = new System.Drawing.Point(23, 126);
            this.lblAbteilung.Margin = new System.Windows.Forms.Padding(5);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(52, 14);
            this.lblAbteilung.TabIndex = 228;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // dropDownPatienten
            // 
            appearance7.BorderColor = System.Drawing.Color.Black;
            this.dropDownPatienten.Appearance = appearance7;
            this.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownPatienten.Location = new System.Drawing.Point(146, 44);
            this.dropDownPatienten.Name = "dropDownPatienten";
            this.dropDownPatienten.Size = new System.Drawing.Size(276, 23);
            this.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownPatienten.TabIndex = 229;
            this.dropDownPatienten.Tag = "";
            this.dropDownPatienten.Text = "Empfänger";
            // 
            // ucSuchtgiftschrankSchlüssel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dropDownPatienten);
            this.Controls.Add(this.cboAbteilung);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.cboKlinik);
            this.Controls.Add(this.lblKlinik);
            this.Controls.Add(this.txtÜbernehmerPassword);
            this.Controls.Add(this.lblÜbernehmerPassword);
            this.Controls.Add(this.txtÜbergeber);
            this.Controls.Add(this.lblÜbergeber);
            this.Controls.Add(this.uceAm);
            this.Controls.Add(this.lblÜbergabeUm);
            this.Controls.Add(this.lblAnmerkung);
            this.Controls.Add(this.txtAnmerkung);
            this.Controls.Add(this.lblÜbernehmer);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Name = "ucSuchtgiftschrankSchlüssel";
            this.Size = new System.Drawing.Size(546, 474);
            this.Load += new System.EventHandler(this.ucSuchtgiftschrankSchlüssel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbergeber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbernehmerPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlinik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        public QS2.Desktop.ControlManagment.BaseLabel lblÜbernehmer;
        public QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtAnmerkung;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceAm;
        public QS2.Desktop.ControlManagment.BaseLabel lblÜbergabeUm;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtÜbergeber;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbergeber;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtÜbernehmerPassword;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbernehmerPassword;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboAbteilung;
        public QS2.Desktop.ControlManagment.BaseLabel lblAbteilung;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboKlinik;
        public QS2.Desktop.ControlManagment.BaseLabel lblKlinik;
        internal Infragistics.Win.Misc.UltraDropDownButton dropDownPatienten;
        private Infragistics.Win.Misc.UltraPopupControlContainer uPopUpContUsers;
    }
}
