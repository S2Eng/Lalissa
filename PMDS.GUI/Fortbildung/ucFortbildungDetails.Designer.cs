namespace PMDS.GUI.Fortbildung
{
    partial class ucFortbildungDetails
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
            this.txtBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBeginn = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEnde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.uceBeginn = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.uceEnde = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.iAnzahlStunden = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblAnzahlStunden = new QS2.Desktop.ControlManagment.BaseLabel();
            this.iAnzahlFreiePlätze = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblAnzahlfreiePlätze = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtZertifikat = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblZertifikat = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVortragender = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblVortragender = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVoraussetzungen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblVoraussetzungen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtVeranstaltungsort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblVeranstaltungsort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucDokumente1 = new PMDS.GUI.Fortbildung.ucDokumente();
            this.lblDokumente = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZertifikat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVortragender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoraussetzungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeranstaltungsort)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBeschreibung
            // 
            this.txtBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Top";
            this.txtBeschreibung.Appearance = appearance1;
            this.txtBeschreibung.AutoSize = false;
            this.txtBeschreibung.Location = new System.Drawing.Point(132, 287);
            this.txtBeschreibung.Margin = new System.Windows.Forms.Padding(4);
            this.txtBeschreibung.MaxLength = 0;
            this.txtBeschreibung.Multiline = true;
            this.txtBeschreibung.Name = "txtBeschreibung";
            this.txtBeschreibung.Size = new System.Drawing.Size(653, 99);
            this.txtBeschreibung.TabIndex = 9;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Location = new System.Drawing.Point(11, 288);
            this.lblBeschreibung.Margin = new System.Windows.Forms.Padding(5);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(89, 17);
            this.lblBeschreibung.TabIndex = 130;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.AutoSize = false;
            this.txtBezeichnung.Location = new System.Drawing.Point(132, 7);
            this.txtBezeichnung.Margin = new System.Windows.Forms.Padding(4);
            this.txtBezeichnung.MaxLength = 200;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Size = new System.Drawing.Size(599, 27);
            this.txtBezeichnung.TabIndex = 0;
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(11, 12);
            this.lblBezeichnung.Margin = new System.Windows.Forms.Padding(5);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(84, 17);
            this.lblBezeichnung.TabIndex = 129;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // lblBeginn
            // 
            this.lblBeginn.AutoSize = true;
            this.lblBeginn.Location = new System.Drawing.Point(11, 42);
            this.lblBeginn.Margin = new System.Windows.Forms.Padding(5);
            this.lblBeginn.Name = "lblBeginn";
            this.lblBeginn.Size = new System.Drawing.Size(48, 17);
            this.lblBeginn.TabIndex = 132;
            this.lblBeginn.Text = "Beginn";
            // 
            // lblEnde
            // 
            this.lblEnde.AutoSize = true;
            this.lblEnde.Location = new System.Drawing.Point(359, 42);
            this.lblEnde.Margin = new System.Windows.Forms.Padding(5);
            this.lblEnde.Name = "lblEnde";
            this.lblEnde.Size = new System.Drawing.Size(37, 17);
            this.lblEnde.TabIndex = 134;
            this.lblEnde.Text = "Ende";
            // 
            // uceBeginn
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.BackColorDisabled2 = System.Drawing.Color.White;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceBeginn.Appearance = appearance2;
            this.uceBeginn.BackColor = System.Drawing.Color.White;
            this.uceBeginn.FormatString = "";
            this.uceBeginn.Location = new System.Drawing.Point(132, 38);
            this.uceBeginn.Margin = new System.Windows.Forms.Padding(4);
            this.uceBeginn.MaskInput = "dd.mm.yyyy hh:mm";
            this.uceBeginn.Name = "uceBeginn";
            this.uceBeginn.Size = new System.Drawing.Size(164, 24);
            this.uceBeginn.TabIndex = 1;
            // 
            // uceEnde
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.BackColorDisabled2 = System.Drawing.Color.White;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceEnde.Appearance = appearance3;
            this.uceEnde.BackColor = System.Drawing.Color.White;
            this.uceEnde.FormatString = "";
            this.uceEnde.Location = new System.Drawing.Point(409, 38);
            this.uceEnde.Margin = new System.Windows.Forms.Padding(4);
            this.uceEnde.MaskInput = "dd.mm.yyyy hh:mm";
            this.uceEnde.Name = "uceEnde";
            this.uceEnde.Size = new System.Drawing.Size(164, 24);
            this.uceEnde.TabIndex = 2;
            // 
            // iAnzahlStunden
            // 
            this.iAnzahlStunden.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.iAnzahlStunden.Location = new System.Drawing.Point(132, 68);
            this.iAnzahlStunden.Margin = new System.Windows.Forms.Padding(4);
            this.iAnzahlStunden.Name = "iAnzahlStunden";
            this.iAnzahlStunden.NonAutoSizeHeight = 20;
            this.iAnzahlStunden.Size = new System.Drawing.Size(129, 23);
            this.iAnzahlStunden.TabIndex = 3;
            // 
            // lblAnzahlStunden
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblAnzahlStunden.Appearance = appearance4;
            this.lblAnzahlStunden.AutoSize = true;
            this.lblAnzahlStunden.Location = new System.Drawing.Point(11, 71);
            this.lblAnzahlStunden.Margin = new System.Windows.Forms.Padding(4);
            this.lblAnzahlStunden.Name = "lblAnzahlStunden";
            this.lblAnzahlStunden.Size = new System.Drawing.Size(102, 17);
            this.lblAnzahlStunden.TabIndex = 207;
            this.lblAnzahlStunden.Text = "Anzahl Stunden";
            // 
            // iAnzahlFreiePlätze
            // 
            this.iAnzahlFreiePlätze.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.iAnzahlFreiePlätze.Location = new System.Drawing.Point(409, 68);
            this.iAnzahlFreiePlätze.Margin = new System.Windows.Forms.Padding(4);
            this.iAnzahlFreiePlätze.Name = "iAnzahlFreiePlätze";
            this.iAnzahlFreiePlätze.NonAutoSizeHeight = 20;
            this.iAnzahlFreiePlätze.Size = new System.Drawing.Size(129, 23);
            this.iAnzahlFreiePlätze.TabIndex = 4;
            // 
            // lblAnzahlfreiePlätze
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblAnzahlfreiePlätze.Appearance = appearance5;
            this.lblAnzahlfreiePlätze.AutoSize = true;
            this.lblAnzahlfreiePlätze.Location = new System.Drawing.Point(277, 71);
            this.lblAnzahlfreiePlätze.Margin = new System.Windows.Forms.Padding(4);
            this.lblAnzahlfreiePlätze.Name = "lblAnzahlfreiePlätze";
            this.lblAnzahlfreiePlätze.Size = new System.Drawing.Size(119, 17);
            this.lblAnzahlfreiePlätze.TabIndex = 209;
            this.lblAnzahlfreiePlätze.Text = "Anzahl freie Plätze";
            // 
            // txtZertifikat
            // 
            this.txtZertifikat.AutoSize = false;
            this.txtZertifikat.Location = new System.Drawing.Point(132, 106);
            this.txtZertifikat.Margin = new System.Windows.Forms.Padding(4);
            this.txtZertifikat.MaxLength = 200;
            this.txtZertifikat.Name = "txtZertifikat";
            this.txtZertifikat.Size = new System.Drawing.Size(599, 27);
            this.txtZertifikat.TabIndex = 5;
            // 
            // lblZertifikat
            // 
            this.lblZertifikat.AutoSize = true;
            this.lblZertifikat.Location = new System.Drawing.Point(11, 111);
            this.lblZertifikat.Margin = new System.Windows.Forms.Padding(5);
            this.lblZertifikat.Name = "lblZertifikat";
            this.lblZertifikat.Size = new System.Drawing.Size(58, 17);
            this.lblZertifikat.TabIndex = 211;
            this.lblZertifikat.Text = "Zertifikat";
            // 
            // txtVortragender
            // 
            this.txtVortragender.AutoSize = false;
            this.txtVortragender.Location = new System.Drawing.Point(132, 136);
            this.txtVortragender.Margin = new System.Windows.Forms.Padding(4);
            this.txtVortragender.MaxLength = 200;
            this.txtVortragender.Name = "txtVortragender";
            this.txtVortragender.Size = new System.Drawing.Size(599, 27);
            this.txtVortragender.TabIndex = 6;
            // 
            // lblVortragender
            // 
            this.lblVortragender.AutoSize = true;
            this.lblVortragender.Location = new System.Drawing.Point(11, 142);
            this.lblVortragender.Margin = new System.Windows.Forms.Padding(5);
            this.lblVortragender.Name = "lblVortragender";
            this.lblVortragender.Size = new System.Drawing.Size(85, 17);
            this.lblVortragender.TabIndex = 213;
            this.lblVortragender.Text = "Vortragender";
            // 
            // txtVoraussetzungen
            // 
            this.txtVoraussetzungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Top";
            this.txtVoraussetzungen.Appearance = appearance6;
            this.txtVoraussetzungen.AutoSize = false;
            this.txtVoraussetzungen.Location = new System.Drawing.Point(132, 196);
            this.txtVoraussetzungen.Margin = new System.Windows.Forms.Padding(4);
            this.txtVoraussetzungen.MaxLength = 0;
            this.txtVoraussetzungen.Multiline = true;
            this.txtVoraussetzungen.Name = "txtVoraussetzungen";
            this.txtVoraussetzungen.Size = new System.Drawing.Size(653, 88);
            this.txtVoraussetzungen.TabIndex = 8;
            // 
            // lblVoraussetzungen
            // 
            this.lblVoraussetzungen.AutoSize = true;
            this.lblVoraussetzungen.Location = new System.Drawing.Point(11, 199);
            this.lblVoraussetzungen.Margin = new System.Windows.Forms.Padding(5);
            this.lblVoraussetzungen.Name = "lblVoraussetzungen";
            this.lblVoraussetzungen.Size = new System.Drawing.Size(112, 17);
            this.lblVoraussetzungen.TabIndex = 215;
            this.lblVoraussetzungen.Text = "Voraussetzungen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 536);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(793, 41);
            this.panelBottom.TabIndex = 100;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance7;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(665, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVeranstaltungsort
            // 
            this.txtVeranstaltungsort.AutoSize = false;
            this.txtVeranstaltungsort.Location = new System.Drawing.Point(132, 166);
            this.txtVeranstaltungsort.Margin = new System.Windows.Forms.Padding(4);
            this.txtVeranstaltungsort.MaxLength = 200;
            this.txtVeranstaltungsort.Name = "txtVeranstaltungsort";
            this.txtVeranstaltungsort.Size = new System.Drawing.Size(599, 27);
            this.txtVeranstaltungsort.TabIndex = 7;
            // 
            // lblVeranstaltungsort
            // 
            this.lblVeranstaltungsort.AutoSize = true;
            this.lblVeranstaltungsort.Location = new System.Drawing.Point(11, 172);
            this.lblVeranstaltungsort.Margin = new System.Windows.Forms.Padding(5);
            this.lblVeranstaltungsort.Name = "lblVeranstaltungsort";
            this.lblVeranstaltungsort.Size = new System.Drawing.Size(113, 17);
            this.lblVeranstaltungsort.TabIndex = 219;
            this.lblVeranstaltungsort.Text = "Veranstaltungsort";
            // 
            // ucDokumente1
            // 
            this.ucDokumente1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDokumente1.BackColor = System.Drawing.Color.Transparent;
            this.ucDokumente1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDokumente1.Location = new System.Drawing.Point(132, 390);
            this.ucDokumente1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDokumente1.Name = "ucDokumente1";
            this.ucDokumente1.Size = new System.Drawing.Size(656, 142);
            this.ucDokumente1.TabIndex = 220;
            // 
            // lblDokumente
            // 
            this.lblDokumente.AutoSize = true;
            this.lblDokumente.Location = new System.Drawing.Point(11, 426);
            this.lblDokumente.Margin = new System.Windows.Forms.Padding(5);
            this.lblDokumente.Name = "lblDokumente";
            this.lblDokumente.Size = new System.Drawing.Size(75, 17);
            this.lblDokumente.TabIndex = 221;
            this.lblDokumente.Text = "Dokumente";
            // 
            // ucFortbildungDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblDokumente);
            this.Controls.Add(this.ucDokumente1);
            this.Controls.Add(this.txtVeranstaltungsort);
            this.Controls.Add(this.lblVeranstaltungsort);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.txtVoraussetzungen);
            this.Controls.Add(this.lblVoraussetzungen);
            this.Controls.Add(this.txtVortragender);
            this.Controls.Add(this.lblVortragender);
            this.Controls.Add(this.txtZertifikat);
            this.Controls.Add(this.lblZertifikat);
            this.Controls.Add(this.iAnzahlFreiePlätze);
            this.Controls.Add(this.lblAnzahlfreiePlätze);
            this.Controls.Add(this.iAnzahlStunden);
            this.Controls.Add(this.lblAnzahlStunden);
            this.Controls.Add(this.uceEnde);
            this.Controls.Add(this.uceBeginn);
            this.Controls.Add(this.lblEnde);
            this.Controls.Add(this.lblBeginn);
            this.Controls.Add(this.txtBeschreibung);
            this.Controls.Add(this.lblBeschreibung);
            this.Controls.Add(this.txtBezeichnung);
            this.Controls.Add(this.lblBezeichnung);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucFortbildungDetails";
            this.Size = new System.Drawing.Size(793, 577);
            this.Load += new System.EventHandler(this.ucFortbildungDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZertifikat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVortragender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoraussetzungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtVeranstaltungsort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBeschreibung;
        public QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBezeichnung;
        public QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        public QS2.Desktop.ControlManagment.BaseLabel lblBeginn;
        public QS2.Desktop.ControlManagment.BaseLabel lblEnde;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceEnde;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceBeginn;
        private QS2.Desktop.ControlManagment.BaseMaskEdit iAnzahlStunden;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnzahlStunden;
        private QS2.Desktop.ControlManagment.BaseMaskEdit iAnzahlFreiePlätze;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnzahlfreiePlätze;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtZertifikat;
        public QS2.Desktop.ControlManagment.BaseLabel lblZertifikat;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVortragender;
        public QS2.Desktop.ControlManagment.BaseLabel lblVortragender;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVoraussetzungen;
        public QS2.Desktop.ControlManagment.BaseLabel lblVoraussetzungen;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panelBottom;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVeranstaltungsort;
        public QS2.Desktop.ControlManagment.BaseLabel lblVeranstaltungsort;
        public QS2.Desktop.ControlManagment.BaseLabel lblDokumente;
        private ucDokumente ucDokumente1;
    }
}
