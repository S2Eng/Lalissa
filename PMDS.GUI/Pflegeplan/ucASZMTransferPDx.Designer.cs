namespace PMDS.GUI
{
    partial class ucASZMTransferPDx
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
            this.lblSterbedatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpStart = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlInfo = new QS2.Desktop.ControlManagment.BasePanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlStartEval = new QS2.Desktop.ControlManagment.BasePanel();
            this.dtpEvalStart = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblEvaluierungsdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbLokalisierung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblZusätzlicheLokalisierung = new System.Windows.Forms.LinkLabel();
            this.pnlLokalisierungJN = new QS2.Desktop.ControlManagment.BasePanel();
            this.groupBoxLokalisierung = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblSeite = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKörperteil = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbArea = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbSide = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlLokalisierung = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlStartEval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEvalStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).BeginInit();
            this.pnlLokalisierungJN.SuspendLayout();
            this.groupBoxLokalisierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).BeginInit();
            this.pnlLokalisierung.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSterbedatum
            // 
            this.lblSterbedatum.Location = new System.Drawing.Point(3, 41);
            this.lblSterbedatum.Name = "lblSterbedatum";
            this.lblSterbedatum.Size = new System.Drawing.Size(117, 16);
            this.lblSterbedatum.TabIndex = 29;
            this.lblSterbedatum.Text = "Startdatum";
            // 
            // dtpStart
            // 
            this.dtpStart.DateTime = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpStart.Location = new System.Drawing.Point(137, 35);
            this.dtpStart.MaskInput = "dd.mm.yyyy  hh:mm";
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(128, 24);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.Value = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.Value_Changed);
            // 
            // lblBezeichnung
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance1;
            this.lblBezeichnung.Location = new System.Drawing.Point(3, 10);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(104, 16);
            this.lblBezeichnung.TabIndex = 31;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // tbText
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.White;
            this.tbText.Appearance = appearance2;
            this.tbText.BackColor = System.Drawing.Color.White;
            this.tbText.Location = new System.Drawing.Point(137, 8);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.Size = new System.Drawing.Size(408, 24);
            this.tbText.TabIndex = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblBezeichnung);
            this.pnlInfo.Controls.Add(this.dtpStart);
            this.pnlInfo.Controls.Add(this.tbText);
            this.pnlInfo.Controls.Add(this.lblSterbedatum);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(567, 69);
            this.pnlInfo.TabIndex = 32;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlStartEval
            // 
            this.pnlStartEval.Controls.Add(this.dtpEvalStart);
            this.pnlStartEval.Controls.Add(this.lblEvaluierungsdatum);
            this.pnlStartEval.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStartEval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlStartEval.Location = new System.Drawing.Point(0, 177);
            this.pnlStartEval.Name = "pnlStartEval";
            this.pnlStartEval.Size = new System.Drawing.Size(567, 36);
            this.pnlStartEval.TabIndex = 36;
            // 
            // dtpEvalStart
            // 
            this.dtpEvalStart.DateTime = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpEvalStart.Location = new System.Drawing.Point(137, 5);
            this.dtpEvalStart.MaskInput = "dd.mm.yyyy  hh:mm";
            this.dtpEvalStart.Name = "dtpEvalStart";
            this.dtpEvalStart.Size = new System.Drawing.Size(128, 24);
            this.dtpEvalStart.TabIndex = 6;
            this.dtpEvalStart.Value = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            // 
            // lblEvaluierungsdatum
            // 
            this.lblEvaluierungsdatum.Location = new System.Drawing.Point(3, 9);
            this.lblEvaluierungsdatum.Name = "lblEvaluierungsdatum";
            this.lblEvaluierungsdatum.Size = new System.Drawing.Size(128, 16);
            this.lblEvaluierungsdatum.TabIndex = 31;
            this.lblEvaluierungsdatum.Text = "Evaluierungsdatum";
            // 
            // cbLokalisierung
            // 
            this.cbLokalisierung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbLokalisierung.Location = new System.Drawing.Point(137, -1);
            this.cbLokalisierung.Name = "cbLokalisierung";
            this.cbLokalisierung.Size = new System.Drawing.Size(118, 20);
            this.cbLokalisierung.TabIndex = 2;
            this.cbLokalisierung.Text = "Lokalisierung";
            this.cbLokalisierung.CheckedChanged += new System.EventHandler(this.cbLokalisierung_CheckedChanged);
            // 
            // lblZusätzlicheLokalisierung
            // 
            this.lblZusätzlicheLokalisierung.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.lblZusätzlicheLokalisierung.AutoSize = true;
            this.lblZusätzlicheLokalisierung.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblZusätzlicheLokalisierung.Location = new System.Drawing.Point(261, 2);
            this.lblZusätzlicheLokalisierung.Name = "lblZusätzlicheLokalisierung";
            this.lblZusätzlicheLokalisierung.Size = new System.Drawing.Size(278, 17);
            this.lblZusätzlicheLokalisierung.TabIndex = 3;
            this.lblZusätzlicheLokalisierung.TabStop = true;
            this.lblZusätzlicheLokalisierung.Text = "eine zusätzliche Lokalisierung ermöglichen";
            this.lblZusätzlicheLokalisierung.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.lblZusätzlicheLokalisierung.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnLabel_LinkClicked);
            // 
            // pnlLokalisierungJN
            // 
            this.pnlLokalisierungJN.Controls.Add(this.lblZusätzlicheLokalisierung);
            this.pnlLokalisierungJN.Controls.Add(this.cbLokalisierung);
            this.pnlLokalisierungJN.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLokalisierungJN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlLokalisierungJN.Location = new System.Drawing.Point(0, 69);
            this.pnlLokalisierungJN.Name = "pnlLokalisierungJN";
            this.pnlLokalisierungJN.Size = new System.Drawing.Size(567, 20);
            this.pnlLokalisierungJN.TabIndex = 33;
            // 
            // groupBoxLokalisierung
            // 
            this.groupBoxLokalisierung.Controls.Add(this.lblSeite);
            this.groupBoxLokalisierung.Controls.Add(this.lblKörperteil);
            this.groupBoxLokalisierung.Controls.Add(this.cbArea);
            this.groupBoxLokalisierung.Controls.Add(this.cbSide);
            this.groupBoxLokalisierung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxLokalisierung.Location = new System.Drawing.Point(8, 0);
            this.groupBoxLokalisierung.Name = "groupBoxLokalisierung";
            this.groupBoxLokalisierung.Size = new System.Drawing.Size(536, 80);
            this.groupBoxLokalisierung.TabIndex = 14;
            this.groupBoxLokalisierung.TabStop = false;
            this.groupBoxLokalisierung.Text = "Lokalisierung";
            // 
            // lblSeite
            // 
            this.lblSeite.Location = new System.Drawing.Point(24, 51);
            this.lblSeite.Name = "lblSeite";
            this.lblSeite.Size = new System.Drawing.Size(40, 16);
            this.lblSeite.TabIndex = 13;
            this.lblSeite.Text = "Seite";
            // 
            // lblKörperteil
            // 
            this.lblKörperteil.Location = new System.Drawing.Point(24, 24);
            this.lblKörperteil.Name = "lblKörperteil";
            this.lblKörperteil.Size = new System.Drawing.Size(80, 16);
            this.lblKörperteil.TabIndex = 12;
            this.lblKörperteil.Text = "Körperteil";
            // 
            // cbArea
            // 
            this.cbArea.AddEmptyEntry = false;
            this.cbArea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbArea.BerufsstandGruppeJNA = -1;
            this.cbArea.Group = "LOA";
            this.cbArea.ID_PEP = -1;
            this.cbArea.Location = new System.Drawing.Point(129, 21);
            this.cbArea.MaxLength = 50;
            this.cbArea.Name = "cbArea";
            this.cbArea.ShowAddButton = true;
            this.cbArea.Size = new System.Drawing.Size(264, 24);
            this.cbArea.TabIndex = 4;
            this.cbArea.ValueChanged += new System.EventHandler(this.Value_Changed);
            // 
            // cbSide
            // 
            this.cbSide.AddEmptyEntry = false;
            this.cbSide.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbSide.BerufsstandGruppeJNA = -1;
            this.cbSide.Group = "LOS";
            this.cbSide.ID_PEP = -1;
            this.cbSide.Location = new System.Drawing.Point(129, 48);
            this.cbSide.MaxLength = 50;
            this.cbSide.Name = "cbSide";
            this.cbSide.ShowAddButton = true;
            this.cbSide.Size = new System.Drawing.Size(264, 24);
            this.cbSide.TabIndex = 5;
            this.cbSide.ValueChanged += new System.EventHandler(this.Value_Changed);
            // 
            // pnlLokalisierung
            // 
            this.pnlLokalisierung.Controls.Add(this.groupBoxLokalisierung);
            this.pnlLokalisierung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLokalisierung.Location = new System.Drawing.Point(0, 89);
            this.pnlLokalisierung.Name = "pnlLokalisierung";
            this.pnlLokalisierung.Size = new System.Drawing.Size(567, 88);
            this.pnlLokalisierung.TabIndex = 35;
            // 
            // ucASZMTransferPDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlStartEval);
            this.Controls.Add(this.pnlLokalisierung);
            this.Controls.Add(this.pnlLokalisierungJN);
            this.Controls.Add(this.pnlInfo);
            this.Name = "ucASZMTransferPDx";
            this.Size = new System.Drawing.Size(567, 214);
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlStartEval.ResumeLayout(false);
            this.pnlStartEval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEvalStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).EndInit();
            this.pnlLokalisierungJN.ResumeLayout(false);
            this.pnlLokalisierungJN.PerformLayout();
            this.groupBoxLokalisierung.ResumeLayout(false);
            this.groupBoxLokalisierung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).EndInit();
            this.pnlLokalisierung.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblSterbedatum;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpStart;
        private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        private QS2.Desktop.ControlManagment.BasePanel pnlInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BasePanel pnlStartEval;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEvalStart;
        private QS2.Desktop.ControlManagment.BaseLabel lblEvaluierungsdatum;
        private QS2.Desktop.ControlManagment.BasePanel pnlLokalisierung;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin groupBoxLokalisierung;
        private QS2.Desktop.ControlManagment.BaseLabel lblSeite;
        private QS2.Desktop.ControlManagment.BaseLabel lblKörperteil;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbArea;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbSide;
        private QS2.Desktop.ControlManagment.BasePanel pnlLokalisierungJN;
        private System.Windows.Forms.LinkLabel lblZusätzlicheLokalisierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbLokalisierung;
    }
}
