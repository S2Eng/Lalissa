namespace PMDS.GUI
{
    partial class frmHilfsmittel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHilfsmittel));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.tbNr = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cmbRuecknahme = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cmbAusgegebenVon = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblRücknahmeDurch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAusgabeDurch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblZurückgenommen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblAusgegeben = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInventarNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkEigentumKlinikJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkEigentumKlientJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkMieteJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblLetzteUeberpruefungAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtLetzteUeberpruefungAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblNächsteÜberprüfung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtNaechsteUeberpruefungAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.tbEigentuemer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.tbNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRuecknahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAusgegebenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigentumKlinikJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigentumKlientJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMieteJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLetzteUeberpruefungAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNaechsteUeberpruefungAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEigentuemer)).BeginInit();
            this.SuspendLayout();
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
            this.btnOK.Location = new System.Drawing.Point(862, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
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
            this.btnCancel.Location = new System.Drawing.Point(768, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // tbNr
            // 
            this.tbNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNr.Location = new System.Drawing.Point(126, 112);
            this.tbNr.MaxLength = 155;
            this.tbNr.Name = "tbNr";
            this.tbNr.Size = new System.Drawing.Size(784, 24);
            this.tbNr.TabIndex = 2;
            // 
            // tbBeschreibung
            // 
            this.tbBeschreibung.AcceptsReturn = true;
            this.tbBeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbBeschreibung.Location = new System.Drawing.Point(126, 26);
            this.tbBeschreibung.MaxLength = 255;
            this.tbBeschreibung.Multiline = true;
            this.tbBeschreibung.Name = "tbBeschreibung";
            this.tbBeschreibung.Size = new System.Drawing.Size(784, 80);
            this.tbBeschreibung.TabIndex = 1;
            // 
            // cmbRuecknahme
            // 
            this.cmbRuecknahme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbRuecknahme.Location = new System.Drawing.Point(425, 358);
            this.cmbRuecknahme.Name = "cmbRuecknahme";
            this.cmbRuecknahme.Size = new System.Drawing.Size(485, 24);
            this.cmbRuecknahme.TabIndex = 12;
            // 
            // cmbAusgegebenVon
            // 
            this.cmbAusgegebenVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbAusgegebenVon.Location = new System.Drawing.Point(425, 142);
            this.cmbAusgegebenVon.Name = "cmbAusgegebenVon";
            this.cmbAusgegebenVon.Size = new System.Drawing.Size(485, 24);
            this.cmbAusgegebenVon.TabIndex = 4;
            // 
            // lblRücknahmeDurch
            // 
            this.lblRücknahmeDurch.AutoSize = true;
            this.lblRücknahmeDurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRücknahmeDurch.Location = new System.Drawing.Point(308, 362);
            this.lblRücknahmeDurch.Name = "lblRücknahmeDurch";
            this.lblRücknahmeDurch.Size = new System.Drawing.Size(116, 17);
            this.lblRücknahmeDurch.TabIndex = 168;
            this.lblRücknahmeDurch.Text = "Rücknahme durch";
            // 
            // lblAusgabeDurch
            // 
            this.lblAusgabeDurch.AutoSize = true;
            this.lblAusgabeDurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAusgabeDurch.Location = new System.Drawing.Point(308, 146);
            this.lblAusgabeDurch.Name = "lblAusgabeDurch";
            this.lblAusgabeDurch.Size = new System.Drawing.Size(97, 17);
            this.lblAusgabeDurch.TabIndex = 167;
            this.lblAusgabeDurch.Text = "Ausgabe durch";
            // 
            // dtpBis
            // 
            this.dtpBis.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpBis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpBis.FormatString = "";
            this.dtpBis.Location = new System.Drawing.Point(126, 358);
            this.dtpBis.MaskInput = "";
            this.dtpBis.Name = "dtpBis";
            this.dtpBis.Size = new System.Drawing.Size(176, 24);
            this.dtpBis.TabIndex = 11;
            this.dtpBis.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblZurückgenommen
            // 
            this.lblZurückgenommen.AutoSize = true;
            this.lblZurückgenommen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblZurückgenommen.Location = new System.Drawing.Point(8, 362);
            this.lblZurückgenommen.Name = "lblZurückgenommen";
            this.lblZurückgenommen.Size = new System.Drawing.Size(116, 17);
            this.lblZurückgenommen.TabIndex = 165;
            this.lblZurückgenommen.Text = "Zurückgenommen";
            // 
            // dtpVon
            // 
            this.dtpVon.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpVon.FormatString = "";
            this.dtpVon.Location = new System.Drawing.Point(126, 142);
            this.dtpVon.MaskInput = "";
            this.dtpVon.Name = "dtpVon";
            this.dtpVon.Size = new System.Drawing.Size(176, 24);
            this.dtpVon.TabIndex = 3;
            this.dtpVon.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblAusgegeben
            // 
            this.lblAusgegeben.AutoSize = true;
            this.lblAusgegeben.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAusgegeben.Location = new System.Drawing.Point(8, 146);
            this.lblAusgegeben.Name = "lblAusgegeben";
            this.lblAusgegeben.Size = new System.Drawing.Size(82, 17);
            this.lblAusgegeben.TabIndex = 163;
            this.lblAusgegeben.Text = "Ausgegeben";
            // 
            // lblInventarNr
            // 
            this.lblInventarNr.AutoSize = true;
            this.lblInventarNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInventarNr.Location = new System.Drawing.Point(8, 116);
            this.lblInventarNr.Name = "lblInventarNr";
            this.lblInventarNr.Size = new System.Drawing.Size(77, 17);
            this.lblInventarNr.TabIndex = 162;
            this.lblInventarNr.Text = "Inventar Nr.";
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBeschreibung.Location = new System.Drawing.Point(8, 28);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(89, 17);
            this.lblBeschreibung.TabIndex = 161;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // chkEigentumKlinikJN
            // 
            appearance3.FontData.SizeInPoints = 10F;
            this.chkEigentumKlinikJN.Appearance = appearance3;
            this.chkEigentumKlinikJN.Location = new System.Drawing.Point(126, 195);
            this.chkEigentumKlinikJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkEigentumKlinikJN.Name = "chkEigentumKlinikJN";
            this.chkEigentumKlinikJN.Size = new System.Drawing.Size(176, 22);
            this.chkEigentumKlinikJN.TabIndex = 5;
            this.chkEigentumKlinikJN.Text = "Eigentum des Hauses";
            this.chkEigentumKlinikJN.CheckedChanged += new System.EventHandler(this.chkEigentumKlinikJN_CheckedChanged);
            // 
            // chkEigentumKlientJN
            // 
            appearance4.FontData.SizeInPoints = 10F;
            this.chkEigentumKlientJN.Appearance = appearance4;
            this.chkEigentumKlientJN.Location = new System.Drawing.Point(308, 195);
            this.chkEigentumKlientJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkEigentumKlientJN.Name = "chkEigentumKlientJN";
            this.chkEigentumKlientJN.Size = new System.Drawing.Size(176, 22);
            this.chkEigentumKlientJN.TabIndex = 6;
            this.chkEigentumKlientJN.Text = "Eigentum des Kienten";
            this.chkEigentumKlientJN.CheckedChanged += new System.EventHandler(this.chkEigentumKlientJN_CheckedChanged);
            // 
            // chkMieteJN
            // 
            appearance5.FontData.SizeInPoints = 10F;
            this.chkMieteJN.Appearance = appearance5;
            this.chkMieteJN.Location = new System.Drawing.Point(125, 222);
            this.chkMieteJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkMieteJN.Name = "chkMieteJN";
            this.chkMieteJN.Size = new System.Drawing.Size(176, 22);
            this.chkMieteJN.TabIndex = 7;
            this.chkMieteJN.Text = "Gemietet von ";
            this.chkMieteJN.CheckedChanged += new System.EventHandler(this.chkMieteJN_CheckedChanged);
            // 
            // lblLetzteUeberpruefungAm
            // 
            this.lblLetzteUeberpruefungAm.AutoSize = true;
            this.lblLetzteUeberpruefungAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLetzteUeberpruefungAm.Location = new System.Drawing.Point(125, 277);
            this.lblLetzteUeberpruefungAm.Name = "lblLetzteUeberpruefungAm";
            this.lblLetzteUeberpruefungAm.Size = new System.Drawing.Size(145, 17);
            this.lblLetzteUeberpruefungAm.TabIndex = 172;
            this.lblLetzteUeberpruefungAm.Text = "Letzte Überprüfung am ";
            // 
            // dtLetzteUeberpruefungAm
            // 
            this.dtLetzteUeberpruefungAm.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtLetzteUeberpruefungAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtLetzteUeberpruefungAm.FormatString = "";
            this.dtLetzteUeberpruefungAm.Location = new System.Drawing.Point(308, 273);
            this.dtLetzteUeberpruefungAm.MaskInput = "";
            this.dtLetzteUeberpruefungAm.Name = "dtLetzteUeberpruefungAm";
            this.dtLetzteUeberpruefungAm.Size = new System.Drawing.Size(176, 24);
            this.dtLetzteUeberpruefungAm.TabIndex = 9;
            this.dtLetzteUeberpruefungAm.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblNächsteÜberprüfung
            // 
            this.lblNächsteÜberprüfung.AutoSize = true;
            this.lblNächsteÜberprüfung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNächsteÜberprüfung.Location = new System.Drawing.Point(125, 307);
            this.lblNächsteÜberprüfung.Name = "lblNächsteÜberprüfung";
            this.lblNächsteÜberprüfung.Size = new System.Drawing.Size(158, 17);
            this.lblNächsteÜberprüfung.TabIndex = 174;
            this.lblNächsteÜberprüfung.Text = "Nächste Überprüfung am ";
            // 
            // dtNaechsteUeberpruefungAm
            // 
            this.dtNaechsteUeberpruefungAm.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtNaechsteUeberpruefungAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtNaechsteUeberpruefungAm.FormatString = "";
            this.dtNaechsteUeberpruefungAm.Location = new System.Drawing.Point(308, 303);
            this.dtNaechsteUeberpruefungAm.MaskInput = "";
            this.dtNaechsteUeberpruefungAm.Name = "dtNaechsteUeberpruefungAm";
            this.dtNaechsteUeberpruefungAm.Size = new System.Drawing.Size(176, 24);
            this.dtNaechsteUeberpruefungAm.TabIndex = 10;
            this.dtNaechsteUeberpruefungAm.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // tbEigentuemer
            // 
            this.tbEigentuemer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbEigentuemer.Location = new System.Drawing.Point(308, 224);
            this.tbEigentuemer.MaxLength = 155;
            this.tbEigentuemer.Name = "tbEigentuemer";
            this.tbEigentuemer.Size = new System.Drawing.Size(601, 24);
            this.tbEigentuemer.TabIndex = 8;
            this.tbEigentuemer.Visible = false;
            // 
            // frmHilfsmittel
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(924, 445);
            this.Controls.Add(this.tbEigentuemer);
            this.Controls.Add(this.dtNaechsteUeberpruefungAm);
            this.Controls.Add(this.lblNächsteÜberprüfung);
            this.Controls.Add(this.dtLetzteUeberpruefungAm);
            this.Controls.Add(this.lblLetzteUeberpruefungAm);
            this.Controls.Add(this.chkMieteJN);
            this.Controls.Add(this.chkEigentumKlientJN);
            this.Controls.Add(this.chkEigentumKlinikJN);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbNr);
            this.Controls.Add(this.tbBeschreibung);
            this.Controls.Add(this.cmbRuecknahme);
            this.Controls.Add(this.cmbAusgegebenVon);
            this.Controls.Add(this.lblRücknahmeDurch);
            this.Controls.Add(this.lblAusgabeDurch);
            this.Controls.Add(this.dtpBis);
            this.Controls.Add(this.lblZurückgenommen);
            this.Controls.Add(this.dtpVon);
            this.Controls.Add(this.lblAusgegeben);
            this.Controls.Add(this.lblInventarNr);
            this.Controls.Add(this.lblBeschreibung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmHilfsmittel";
            this.Text = "Hilfsmittel";
            ((System.ComponentModel.ISupportInitialize)(this.tbNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRuecknahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAusgegebenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigentumKlinikJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigentumKlientJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMieteJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLetzteUeberpruefungAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNaechsteUeberpruefungAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEigentuemer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PMDS.GUI.ucButton btnOK;
        private PMDS.GUI.ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbNr;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeschreibung;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbRuecknahme;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbAusgegebenVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblRücknahmeDurch;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusgabeDurch;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblZurückgenommen;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusgegeben;
        private QS2.Desktop.ControlManagment.BaseLabel lblInventarNr;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkEigentumKlinikJN;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkEigentumKlientJN;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkMieteJN;
        private QS2.Desktop.ControlManagment.BaseLabel lblLetzteUeberpruefungAm;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtLetzteUeberpruefungAm;
        private QS2.Desktop.ControlManagment.BaseLabel lblNächsteÜberprüfung;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtNaechsteUeberpruefungAm;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbEigentuemer;
    }
}