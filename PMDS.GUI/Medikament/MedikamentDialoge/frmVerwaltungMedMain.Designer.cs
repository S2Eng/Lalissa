namespace PMDS.GUI
{
    partial class frmMedikamentenVerwaltung
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
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            this.btnImport = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.cboImportType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnDeleteMedikamenteNotUsed = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblStatus = new Infragistics.Win.Misc.UltraLabel();
            this.chkELGATranslate = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboMonat = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblImportTyp = new Infragistics.Win.Misc.UltraLabel();
            this.lblMonat = new Infragistics.Win.Misc.UltraLabel();
            this.pnlMonat = new Infragistics.Win.Misc.UltraPanel();
            this.ucVerwaltungMedTabelle1 = new PMDS.GUI.ucVerwaltungMedTabelle();
            this.pnlImport = new Infragistics.Win.Misc.UltraPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cboImportType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGATranslate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonat)).BeginInit();
            this.pnlMonat.ClientArea.SuspendLayout();
            this.pnlMonat.SuspendLayout();
            this.pnlImport.ClientArea.SuspendLayout();
            this.pnlImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.AutoWorkLayout = false;
            this.btnImport.IsStandardControl = false;
            this.btnImport.Location = new System.Drawing.Point(735, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 33);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "Importieren";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(1095, 523);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(94, 33);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Text = "Rückgängig";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(1195, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 33);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnClose.Appearance = appearance1;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(1304, 523);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 33);
            this.btnClose.TabIndex = 14;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // cboImportType
            // 
            this.cboImportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboImportType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem6.DataValue = "APGDA.001";
            valueListItem6.DisplayText = "Gesamtdaten";
            valueListItem6.Tag = true;
            valueListItem7.DataValue = "APVDA.001";
            valueListItem7.DisplayText = "Veränderungsdaten";
            valueListItem7.Tag = false;
            this.cboImportType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.cboImportType.Location = new System.Drawing.Point(76, 10);
            this.cboImportType.Name = "cboImportType";
            this.cboImportType.Size = new System.Drawing.Size(182, 21);
            this.cboImportType.TabIndex = 15;
            // 
            // btnDeleteMedikamenteNotUsed
            // 
            this.btnDeleteMedikamenteNotUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMedikamenteNotUsed.AutoWorkLayout = false;
            this.btnDeleteMedikamenteNotUsed.IsStandardControl = false;
            this.btnDeleteMedikamenteNotUsed.Location = new System.Drawing.Point(845, 523);
            this.btnDeleteMedikamenteNotUsed.Name = "btnDeleteMedikamenteNotUsed";
            this.btnDeleteMedikamenteNotUsed.Size = new System.Drawing.Size(144, 33);
            this.btnDeleteMedikamenteNotUsed.TabIndex = 17;
            this.btnDeleteMedikamenteNotUsed.Text = "Veraltete Einträge löschen";
            this.btnDeleteMedikamenteNotUsed.Click += new System.EventHandler(this.btnDeleteMedikamenteNotUsed_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(90, 562);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1177, 17);
            this.lblStatus.TabIndex = 18;
            // 
            // chkELGATranslate
            // 
            this.chkELGATranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkELGATranslate.Location = new System.Drawing.Point(575, 12);
            this.chkELGATranslate.Name = "chkELGATranslate";
            this.chkELGATranslate.Size = new System.Drawing.Size(137, 19);
            this.chkELGATranslate.TabIndex = 19;
            this.chkELGATranslate.Text = "ELGA-MEH benutzen";
            // 
            // cboMonat
            // 
            this.cboMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMonat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Aktuelles Monat";
            valueListItem1.Tag = 0;
            valueListItem2.DataValue = -1;
            valueListItem2.DisplayText = "Vormonat";
            valueListItem2.Tag = 0;
            valueListItem3.DataValue = -2;
            valueListItem3.DisplayText = "Vor zwei Monaten";
            valueListItem4.DataValue = -3;
            valueListItem4.DisplayText = "Vor drei Monaten";
            valueListItem5.DataValue = -4;
            valueListItem5.DisplayText = "Vor vier Monaten";
            this.cboMonat.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.cboMonat.Location = new System.Drawing.Point(68, 2);
            this.cboMonat.Name = "cboMonat";
            this.cboMonat.Size = new System.Drawing.Size(216, 21);
            this.cboMonat.TabIndex = 20;
            // 
            // lblImportTyp
            // 
            this.lblImportTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImportTyp.Location = new System.Drawing.Point(3, 14);
            this.lblImportTyp.Name = "lblImportTyp";
            this.lblImportTyp.Size = new System.Drawing.Size(67, 17);
            this.lblImportTyp.TabIndex = 16;
            this.lblImportTyp.Text = "Import-Typ";
            // 
            // lblMonat
            // 
            this.lblMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMonat.Location = new System.Drawing.Point(5, 6);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(47, 17);
            this.lblMonat.TabIndex = 21;
            this.lblMonat.Text = "Monat";
            // 
            // pnlMonat
            // 
            this.pnlMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // pnlMonat.ClientArea
            // 
            this.pnlMonat.ClientArea.Controls.Add(this.cboMonat);
            this.pnlMonat.ClientArea.Controls.Add(this.lblMonat);
            this.pnlMonat.Location = new System.Drawing.Point(273, 9);
            this.pnlMonat.Name = "pnlMonat";
            this.pnlMonat.Size = new System.Drawing.Size(287, 27);
            this.pnlMonat.TabIndex = 22;
            // 
            // ucVerwaltungMedTabelle1
            // 
            this.ucVerwaltungMedTabelle1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVerwaltungMedTabelle1.BackColor = System.Drawing.Color.White;
            this.ucVerwaltungMedTabelle1.Location = new System.Drawing.Point(2, 3);
            this.ucVerwaltungMedTabelle1.Name = "ucVerwaltungMedTabelle1";
            this.ucVerwaltungMedTabelle1.Size = new System.Drawing.Size(1349, 511);
            this.ucVerwaltungMedTabelle1.TabIndex = 0;
            // 
            // pnlImport
            // 
            // 
            // pnlImport.ClientArea
            // 
            this.pnlImport.ClientArea.Controls.Add(this.lblImportTyp);
            this.pnlImport.ClientArea.Controls.Add(this.pnlMonat);
            this.pnlImport.ClientArea.Controls.Add(this.btnImport);
            this.pnlImport.ClientArea.Controls.Add(this.chkELGATranslate);
            this.pnlImport.ClientArea.Controls.Add(this.cboImportType);
            this.pnlImport.Location = new System.Drawing.Point(12, 519);
            this.pnlImport.Name = "pnlImport";
            this.pnlImport.Size = new System.Drawing.Size(829, 38);
            this.pnlImport.TabIndex = 23;
            // 
            // frmMedikamentenVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1353, 583);
            this.Controls.Add(this.pnlImport);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDeleteMedikamenteNotUsed);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.ucVerwaltungMedTabelle1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(867, 556);
            this.Name = "frmMedikamentenVerwaltung";
            this.Text = "Medikamentenverwaltung";
            this.Load += new System.EventHandler(this.frmMedikamentenVerwaltung2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboImportType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGATranslate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonat)).EndInit();
            this.pnlMonat.ClientArea.ResumeLayout(false);
            this.pnlMonat.ClientArea.PerformLayout();
            this.pnlMonat.ResumeLayout(false);
            this.pnlImport.ClientArea.ResumeLayout(false);
            this.pnlImport.ClientArea.PerformLayout();
            this.pnlImport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucVerwaltungMedTabelle ucVerwaltungMedTabelle1;
        private QS2.Desktop.ControlManagment.BaseButton btnImport;
        private QS2.Desktop.ControlManagment.BaseButton btnAbort;
        private QS2.Desktop.ControlManagment.BaseButton btnSave;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboImportType;
        private QS2.Desktop.ControlManagment.BaseButton btnDeleteMedikamenteNotUsed;
        public Infragistics.Win.Misc.UltraLabel lblStatus;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkELGATranslate;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboMonat;
        private Infragistics.Win.Misc.UltraLabel lblImportTyp;
        private Infragistics.Win.Misc.UltraLabel lblMonat;
        private Infragistics.Win.Misc.UltraPanel pnlMonat;
        private Infragistics.Win.Misc.UltraPanel pnlImport;
    }
}