namespace PMDS.GUI.Fortbildung
{
    partial class ucFortbildungBenutzerDetails
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
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.uceAnmeldedatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBeginn = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblStatus = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.optErfolg = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.uceAbgeschlossenAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.baseLabel6 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.uceZuErneuernAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblZuErneuernAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboStatus = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblDokumente = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAbgeschlossen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucDokumente1 = new PMDS.GUI.Fortbildung.ucDokumente();
            ((System.ComponentModel.ISupportInitialize)(this.uceAnmeldedatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optErfolg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAbgeschlossenAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceZuErneuernAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // uceAnmeldedatum
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceAnmeldedatum.Appearance = appearance1;
            this.uceAnmeldedatum.BackColor = System.Drawing.Color.White;
            this.uceAnmeldedatum.FormatString = "";
            this.uceAnmeldedatum.Location = new System.Drawing.Point(114, 42);
            this.uceAnmeldedatum.Margin = new System.Windows.Forms.Padding(4);
            this.uceAnmeldedatum.MaskInput = "dd.mm.yyyy";
            this.uceAnmeldedatum.Name = "uceAnmeldedatum";
            this.uceAnmeldedatum.ownFormat = "";
            this.uceAnmeldedatum.ownMaskInput = "";
            this.uceAnmeldedatum.Size = new System.Drawing.Size(129, 24);
            this.uceAnmeldedatum.TabIndex = 1;
            // 
            // lblBeginn
            // 
            this.lblBeginn.AutoSize = true;
            this.lblBeginn.Location = new System.Drawing.Point(4, 46);
            this.lblBeginn.Margin = new System.Windows.Forms.Padding(5);
            this.lblBeginn.Name = "lblBeginn";
            this.lblBeginn.Size = new System.Drawing.Size(48, 17);
            this.lblBeginn.TabIndex = 205;
            this.lblBeginn.Text = "Beginn";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 17);
            this.lblStatus.TabIndex = 212;
            this.lblStatus.Text = "Status";
            // 
            // txtAnmerkung
            // 
            this.txtAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Top";
            this.txtAnmerkung.Appearance = appearance2;
            this.txtAnmerkung.AutoSize = false;
            this.txtAnmerkung.Location = new System.Drawing.Point(113, 160);
            this.txtAnmerkung.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnmerkung.MaxLength = 0;
            this.txtAnmerkung.Multiline = true;
            this.txtAnmerkung.Name = "txtAnmerkung";
            this.txtAnmerkung.Size = new System.Drawing.Size(784, 135);
            this.txtAnmerkung.TabIndex = 5;
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.AutoSize = true;
            this.lblAnmerkung.Location = new System.Drawing.Point(3, 160);
            this.lblAnmerkung.Margin = new System.Windows.Forms.Padding(5);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(75, 17);
            this.lblAnmerkung.TabIndex = 214;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // optErfolg
            // 
            this.optErfolg.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "mit Erfolg";
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Ohne Erfolg";
            valueListItem4.DataValue = -1;
            valueListItem4.DisplayText = "Undefiniert";
            this.optErfolg.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.optErfolg.Location = new System.Drawing.Point(113, 84);
            this.optErfolg.Margin = new System.Windows.Forms.Padding(4);
            this.optErfolg.Name = "optErfolg";
            this.optErfolg.Size = new System.Drawing.Size(300, 21);
            this.optErfolg.TabIndex = 3;
            // 
            // uceAbgeschlossenAm
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.BackColorDisabled2 = System.Drawing.Color.White;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceAbgeschlossenAm.Appearance = appearance3;
            this.uceAbgeschlossenAm.BackColor = System.Drawing.Color.White;
            this.uceAbgeschlossenAm.FormatString = "";
            this.uceAbgeschlossenAm.Location = new System.Drawing.Point(324, 41);
            this.uceAbgeschlossenAm.Margin = new System.Windows.Forms.Padding(4);
            this.uceAbgeschlossenAm.MaskInput = "dd.mm.yyyy";
            this.uceAbgeschlossenAm.Name = "uceAbgeschlossenAm";
            this.uceAbgeschlossenAm.ownFormat = "";
            this.uceAbgeschlossenAm.ownMaskInput = "";
            this.uceAbgeschlossenAm.Size = new System.Drawing.Size(129, 24);
            this.uceAbgeschlossenAm.TabIndex = 2;
            // 
            // baseLabel6
            // 
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Location = new System.Drawing.Point(262, 44);
            this.baseLabel6.Margin = new System.Windows.Forms.Padding(5);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(37, 17);
            this.baseLabel6.TabIndex = 216;
            this.baseLabel6.Text = "Ende";
            // 
            // uceZuErneuernAm
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceZuErneuernAm.Appearance = appearance4;
            this.uceZuErneuernAm.BackColor = System.Drawing.Color.White;
            this.uceZuErneuernAm.FormatString = "";
            this.uceZuErneuernAm.Location = new System.Drawing.Point(113, 117);
            this.uceZuErneuernAm.Margin = new System.Windows.Forms.Padding(4);
            this.uceZuErneuernAm.MaskInput = "dd.mm.yyyy";
            this.uceZuErneuernAm.Name = "uceZuErneuernAm";
            this.uceZuErneuernAm.ownFormat = "";
            this.uceZuErneuernAm.ownMaskInput = "";
            this.uceZuErneuernAm.Size = new System.Drawing.Size(129, 24);
            this.uceZuErneuernAm.TabIndex = 4;
            // 
            // lblZuErneuernAm
            // 
            this.lblZuErneuernAm.AutoSize = true;
            this.lblZuErneuernAm.Location = new System.Drawing.Point(3, 121);
            this.lblZuErneuernAm.Margin = new System.Windows.Forms.Padding(5);
            this.lblZuErneuernAm.Name = "lblZuErneuernAm";
            this.lblZuErneuernAm.Size = new System.Drawing.Size(104, 17);
            this.lblZuErneuernAm.TabIndex = 218;
            this.lblZuErneuernAm.Text = "Zu Erneuern am";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = "Noch nicht begonnen";
            valueListItem5.DisplayText = "Noch nicht begonnen";
            valueListItem1.DataValue = "Abgeschlossen";
            valueListItem1.DisplayText = "Abgeschlossen";
            valueListItem6.DataValue = "Läuft derzeit";
            valueListItem6.DisplayText = "Läuft derzeit";
            valueListItem7.DataValue = "Undefiniert";
            valueListItem7.DisplayText = "Undefiniert";
            this.cboStatus.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem1,
            valueListItem6,
            valueListItem7});
            this.cboStatus.Location = new System.Drawing.Point(113, 4);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(339, 24);
            this.cboStatus.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 459);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(901, 41);
            this.panelBottom.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance5;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(768, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDokumente
            // 
            this.lblDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumente.AutoSize = true;
            this.lblDokumente.Location = new System.Drawing.Point(3, 308);
            this.lblDokumente.Margin = new System.Windows.Forms.Padding(5);
            this.lblDokumente.Name = "lblDokumente";
            this.lblDokumente.Size = new System.Drawing.Size(75, 17);
            this.lblDokumente.TabIndex = 220;
            this.lblDokumente.Text = "Dokumente";
            // 
            // lblAbgeschlossen
            // 
            this.lblAbgeschlossen.AutoSize = true;
            this.lblAbgeschlossen.Location = new System.Drawing.Point(3, 84);
            this.lblAbgeschlossen.Margin = new System.Windows.Forms.Padding(5);
            this.lblAbgeschlossen.Name = "lblAbgeschlossen";
            this.lblAbgeschlossen.Size = new System.Drawing.Size(98, 17);
            this.lblAbgeschlossen.TabIndex = 221;
            this.lblAbgeschlossen.Text = "Abgeschlossen";
            // 
            // ucDokumente1
            // 
            this.ucDokumente1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDokumente1.BackColor = System.Drawing.Color.Transparent;
            this.ucDokumente1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDokumente1.Location = new System.Drawing.Point(109, 304);
            this.ucDokumente1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDokumente1.Name = "ucDokumente1";
            this.ucDokumente1.Size = new System.Drawing.Size(786, 150);
            this.ucDokumente1.TabIndex = 6;
            // 
            // ucFortbildungBenutzerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAbgeschlossen);
            this.Controls.Add(this.lblDokumente);
            this.Controls.Add(this.ucDokumente1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.uceZuErneuernAm);
            this.Controls.Add(this.lblZuErneuernAm);
            this.Controls.Add(this.uceAbgeschlossenAm);
            this.Controls.Add(this.baseLabel6);
            this.Controls.Add(this.optErfolg);
            this.Controls.Add(this.txtAnmerkung);
            this.Controls.Add(this.lblAnmerkung);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.uceAnmeldedatum);
            this.Controls.Add(this.lblBeginn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucFortbildungBenutzerDetails";
            this.Size = new System.Drawing.Size(901, 500);
            this.Load += new System.EventHandler(this.ucFortbildungBenutzerDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uceAnmeldedatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optErfolg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceAbgeschlossenAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceZuErneuernAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceAnmeldedatum;
        public QS2.Desktop.ControlManagment.BaseLabel lblBeginn;
        public QS2.Desktop.ControlManagment.BaseLabel lblStatus;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtAnmerkung;
        public QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optErfolg;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceAbgeschlossenAm;
        public QS2.Desktop.ControlManagment.BaseLabel baseLabel6;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceZuErneuernAm;
        public QS2.Desktop.ControlManagment.BaseLabel lblZuErneuernAm;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboStatus;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panelBottom;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseLabel lblDokumente;
        private ucDokumente ucDokumente1;
        public QS2.Desktop.ControlManagment.BaseLabel lblAbgeschlossen;
    }
}
