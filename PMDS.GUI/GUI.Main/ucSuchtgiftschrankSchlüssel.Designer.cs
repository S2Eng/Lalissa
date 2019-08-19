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
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblÜbernehmer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboÜbernehmer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.uceAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblÜbergabeUm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtÜbergeber = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblÜbergeber = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtÜbernehmerPassword = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblÜbernehmerPassword = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboÜbernehmer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbergeber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbernehmerPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.btnAbort.Location = new System.Drawing.Point(278, 336);
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
            this.btnOK.Location = new System.Drawing.Point(194, 336);
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
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblÜbernehmer
            // 
            this.lblÜbernehmer.AutoSize = true;
            this.lblÜbernehmer.Location = new System.Drawing.Point(23, 47);
            this.lblÜbernehmer.Margin = new System.Windows.Forms.Padding(5);
            this.lblÜbernehmer.Name = "lblÜbernehmer";
            this.lblÜbernehmer.Size = new System.Drawing.Size(67, 14);
            this.lblÜbernehmer.TabIndex = 212;
            this.lblÜbernehmer.Text = "Übernehmer";
            // 
            // cboÜbernehmer
            // 
            this.cboÜbernehmer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboÜbernehmer.Location = new System.Drawing.Point(146, 44);
            this.cboÜbernehmer.Margin = new System.Windows.Forms.Padding(4);
            this.cboÜbernehmer.Name = "cboÜbernehmer";
            this.cboÜbernehmer.Size = new System.Drawing.Size(276, 21);
            this.cboÜbernehmer.TabIndex = 1;
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(23, 135);
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
            this.txtAnmerkung.Location = new System.Drawing.Point(144, 137);
            this.txtAnmerkung.Margin = new System.Windows.Forms.Padding(5);
            this.txtAnmerkung.MaxLength = 0;
            this.txtAnmerkung.Multiline = true;
            this.txtAnmerkung.Name = "txtAnmerkung";
            this.txtAnmerkung.Size = new System.Drawing.Size(387, 188);
            this.txtAnmerkung.TabIndex = 4;
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
            this.uceAm.Location = new System.Drawing.Point(146, 102);
            this.uceAm.Margin = new System.Windows.Forms.Padding(4);
            this.uceAm.MaskInput = "dd.mm.yyyy hh:mm";
            this.uceAm.Name = "uceAm";
            this.uceAm.Size = new System.Drawing.Size(124, 21);
            this.uceAm.TabIndex = 3;
            // 
            // lblÜbergabeUm
            // 
            this.lblÜbergabeUm.AutoSize = true;
            this.lblÜbergabeUm.Location = new System.Drawing.Point(23, 105);
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
            // ucSuchtgiftschrankSchlüssel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtÜbernehmerPassword);
            this.Controls.Add(this.lblÜbernehmerPassword);
            this.Controls.Add(this.txtÜbergeber);
            this.Controls.Add(this.lblÜbergeber);
            this.Controls.Add(this.uceAm);
            this.Controls.Add(this.lblÜbergabeUm);
            this.Controls.Add(this.cboÜbernehmer);
            this.Controls.Add(this.lblAnmerkung);
            this.Controls.Add(this.txtAnmerkung);
            this.Controls.Add(this.lblÜbernehmer);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Name = "ucSuchtgiftschrankSchlüssel";
            this.Size = new System.Drawing.Size(546, 373);
            this.Load += new System.EventHandler(this.ucSuchtgiftschrankSchlüssel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboÜbernehmer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbergeber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtÜbernehmerPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        public QS2.Desktop.ControlManagment.BaseLabel lblÜbernehmer;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboÜbernehmer;
        public QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtAnmerkung;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceAm;
        public QS2.Desktop.ControlManagment.BaseLabel lblÜbergabeUm;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtÜbergeber;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbergeber;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtÜbernehmerPassword;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbernehmerPassword;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
