namespace PMDS.GUI
{
    partial class frmVerwahrung
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerwahrung));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblÜbernahmeAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lbklRückgabeAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblÜbernahmeDurch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblRückgabeDurch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbAusgegebenVon = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cmbRuecknahme = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.tbBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbNr = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbBeschreibungOrig = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblInventarNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHistorie = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAusgegebenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRuecknahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibungOrig)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBeschreibung.Location = new System.Drawing.Point(12, 29);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(89, 17);
            this.lblBeschreibung.TabIndex = 145;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 397);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel1.TabIndex = 146;
            this.ultraLabel1.Text = "Nummer";
            // 
            // lblÜbernahmeAm
            // 
            this.lblÜbernahmeAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblÜbernahmeAm.AutoSize = true;
            this.lblÜbernahmeAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblÜbernahmeAm.Location = new System.Drawing.Point(12, 393);
            this.lblÜbernahmeAm.Name = "lblÜbernahmeAm";
            this.lblÜbernahmeAm.Size = new System.Drawing.Size(99, 17);
            this.lblÜbernahmeAm.TabIndex = 147;
            this.lblÜbernahmeAm.Text = "Übernahme am";
            // 
            // dtpVon
            // 
            this.dtpVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpVon.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpVon.FormatString = "";
            this.dtpVon.Location = new System.Drawing.Point(117, 393);
            this.dtpVon.MaskInput = "";
            this.dtpVon.Name = "dtpVon";
            this.dtpVon.ownFormat = "";
            this.dtpVon.ownMaskInput = "";
            this.dtpVon.Size = new System.Drawing.Size(176, 21);
            this.dtpVon.TabIndex = 2;
            this.dtpVon.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lbklRückgabeAm
            // 
            this.lbklRückgabeAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbklRückgabeAm.AutoSize = true;
            this.lbklRückgabeAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbklRückgabeAm.Location = new System.Drawing.Point(12, 423);
            this.lbklRückgabeAm.Name = "lbklRückgabeAm";
            this.lbklRückgabeAm.Size = new System.Drawing.Size(90, 17);
            this.lbklRückgabeAm.TabIndex = 151;
            this.lbklRückgabeAm.Text = "Rückgabe am";
            // 
            // dtpBis
            // 
            this.dtpBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpBis.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpBis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpBis.FormatString = "";
            this.dtpBis.Location = new System.Drawing.Point(117, 419);
            this.dtpBis.MaskInput = "";
            this.dtpBis.Name = "dtpBis";
            this.dtpBis.ownFormat = "";
            this.dtpBis.ownMaskInput = "";
            this.dtpBis.Size = new System.Drawing.Size(176, 24);
            this.dtpBis.TabIndex = 4;
            this.dtpBis.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblÜbernahmeDurch
            // 
            this.lblÜbernahmeDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblÜbernahmeDurch.AutoSize = true;
            this.lblÜbernahmeDurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblÜbernahmeDurch.Location = new System.Drawing.Point(309, 396);
            this.lblÜbernahmeDurch.Name = "lblÜbernahmeDurch";
            this.lblÜbernahmeDurch.Size = new System.Drawing.Size(115, 17);
            this.lblÜbernahmeDurch.TabIndex = 153;
            this.lblÜbernahmeDurch.Text = "Übernahme durch";
            // 
            // lblRückgabeDurch
            // 
            this.lblRückgabeDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRückgabeDurch.AutoSize = true;
            this.lblRückgabeDurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRückgabeDurch.Location = new System.Drawing.Point(309, 424);
            this.lblRückgabeDurch.Name = "lblRückgabeDurch";
            this.lblRückgabeDurch.Size = new System.Drawing.Size(105, 17);
            this.lblRückgabeDurch.TabIndex = 154;
            this.lblRückgabeDurch.Text = "Rückgabe durch";
            // 
            // cmbAusgegebenVon
            // 
            this.cmbAusgegebenVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbAusgegebenVon.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbAusgegebenVon.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbAusgegebenVon.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbAusgegebenVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbAusgegebenVon.Location = new System.Drawing.Point(430, 389);
            this.cmbAusgegebenVon.Name = "cmbAusgegebenVon";
            this.cmbAusgegebenVon.Size = new System.Drawing.Size(270, 24);
            this.cmbAusgegebenVon.TabIndex = 3;
            // 
            // cmbRuecknahme
            // 
            this.cmbRuecknahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbRuecknahme.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbRuecknahme.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbRuecknahme.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbRuecknahme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbRuecknahme.Location = new System.Drawing.Point(430, 419);
            this.cmbRuecknahme.Name = "cmbRuecknahme";
            this.cmbRuecknahme.Size = new System.Drawing.Size(270, 24);
            this.cmbRuecknahme.TabIndex = 5;
            // 
            // tbBeschreibung
            // 
            this.tbBeschreibung.AcceptsReturn = true;
            this.tbBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbBeschreibung.Location = new System.Drawing.Point(117, 27);
            this.tbBeschreibung.MaxLength = 255;
            this.tbBeschreibung.Multiline = true;
            this.tbBeschreibung.Name = "tbBeschreibung";
            this.tbBeschreibung.Size = new System.Drawing.Size(839, 97);
            this.tbBeschreibung.TabIndex = 1;
            // 
            // tbNr
            // 
            this.tbNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNr.Location = new System.Drawing.Point(117, 449);
            this.tbNr.MaxLength = 155;
            this.tbNr.Name = "tbNr";
            this.tbNr.Size = new System.Drawing.Size(831, 24);
            this.tbNr.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(900, 483);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 29);
            this.btnOK.TabIndex = 8;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(810, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbBeschreibungOrig
            // 
            this.tbBeschreibungOrig.AcceptsReturn = true;
            this.tbBeschreibungOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.BackColorDisabled2 = System.Drawing.Color.White;
            this.tbBeschreibungOrig.Appearance = appearance3;
            this.tbBeschreibungOrig.Enabled = false;
            this.tbBeschreibungOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbBeschreibungOrig.Location = new System.Drawing.Point(117, 128);
            this.tbBeschreibungOrig.MaxLength = 255;
            this.tbBeschreibungOrig.Multiline = true;
            this.tbBeschreibungOrig.Name = "tbBeschreibungOrig";
            this.tbBeschreibungOrig.Size = new System.Drawing.Size(839, 255);
            this.tbBeschreibungOrig.TabIndex = 155;
            this.tbBeschreibungOrig.TabStop = false;
            // 
            // lblInventarNr
            // 
            this.lblInventarNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInventarNr.AutoSize = true;
            this.lblInventarNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInventarNr.Location = new System.Drawing.Point(12, 453);
            this.lblInventarNr.Name = "lblInventarNr";
            this.lblInventarNr.Size = new System.Drawing.Size(77, 17);
            this.lblInventarNr.TabIndex = 156;
            this.lblInventarNr.Text = "Inventar Nr.";
            this.lblInventarNr.Click += new System.EventHandler(this.baseLabel1_Click);
            // 
            // lblHistorie
            // 
            this.lblHistorie.AutoSize = true;
            this.lblHistorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHistorie.Location = new System.Drawing.Point(12, 131);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(52, 17);
            this.lblHistorie.TabIndex = 157;
            this.lblHistorie.Text = "Historie";
            // 
            // frmVerwahrung
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(969, 520);
            this.Controls.Add(this.lblHistorie);
            this.Controls.Add(this.lblInventarNr);
            this.Controls.Add(this.tbBeschreibungOrig);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbNr);
            this.Controls.Add(this.tbBeschreibung);
            this.Controls.Add(this.cmbRuecknahme);
            this.Controls.Add(this.cmbAusgegebenVon);
            this.Controls.Add(this.lblRückgabeDurch);
            this.Controls.Add(this.lblÜbernahmeDurch);
            this.Controls.Add(this.dtpBis);
            this.Controls.Add(this.lbklRückgabeAm);
            this.Controls.Add(this.dtpVon);
            this.Controls.Add(this.lblÜbernahmeAm);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.lblBeschreibung);
            this.KeyPreview = true;
            this.Name = "frmVerwahrung";
            this.Text = "Verwahrung";
            this.Load += new System.EventHandler(this.frmVerwahrung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAusgegebenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRuecknahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibungOrig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbernahmeAm;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpVon;
        private QS2.Desktop.ControlManagment.BaseLabel lbklRückgabeAm;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblÜbernahmeDurch;
        private QS2.Desktop.ControlManagment.BaseLabel lblRückgabeDurch;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbAusgegebenVon;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbRuecknahme;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeschreibung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbNr;
        private PMDS.GUI.ucButton btnOK;
        private PMDS.GUI.ucButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeschreibungOrig;
        private QS2.Desktop.ControlManagment.BaseLabel lblInventarNr;
        private QS2.Desktop.ControlManagment.BaseLabel lblHistorie;
    }
}