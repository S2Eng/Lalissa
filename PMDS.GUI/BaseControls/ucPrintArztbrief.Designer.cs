namespace PMDS.GUI.BaseControls
{
    partial class ucPrintArztbrief
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrintArztbrief));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.pnlPrintArztbrief = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkDiagnosenJN = new System.Windows.Forms.CheckBox();
            this.chkMedikamenteJN = new System.Windows.Forms.CheckBox();
            this.lblAusdruckVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnPrint = new PMDS.GUI.ucButton(this.components);
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnPrintSettings = new Infragistics.Win.Misc.UltraDropDownButton();
            this.pnlPrintArztbrief.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrintArztbrief
            // 
            this.pnlPrintArztbrief.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPrintArztbrief.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintArztbrief.Controls.Add(this.chkDiagnosenJN);
            this.pnlPrintArztbrief.Controls.Add(this.chkMedikamenteJN);
            this.pnlPrintArztbrief.Controls.Add(this.lblAusdruckVon);
            this.pnlPrintArztbrief.Controls.Add(this.btnPrint);
            this.pnlPrintArztbrief.Location = new System.Drawing.Point(4, 33);
            this.pnlPrintArztbrief.Name = "pnlPrintArztbrief";
            this.pnlPrintArztbrief.Size = new System.Drawing.Size(164, 119);
            this.pnlPrintArztbrief.TabIndex = 88;
            this.pnlPrintArztbrief.Visible = false;
            // 
            // chkDiagnosenJN
            // 
            this.chkDiagnosenJN.AutoSize = true;
            this.chkDiagnosenJN.Checked = true;
            this.chkDiagnosenJN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiagnosenJN.Location = new System.Drawing.Point(11, 27);
            this.chkDiagnosenJN.Name = "chkDiagnosenJN";
            this.chkDiagnosenJN.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkDiagnosenJN.Size = new System.Drawing.Size(103, 22);
            this.chkDiagnosenJN.TabIndex = 0;
            this.chkDiagnosenJN.Text = "Diagnosen J/N";
            this.chkDiagnosenJN.UseVisualStyleBackColor = true;
            // 
            // chkMedikamenteJN
            // 
            this.chkMedikamenteJN.AutoSize = true;
            this.chkMedikamenteJN.Checked = true;
            this.chkMedikamenteJN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMedikamenteJN.Location = new System.Drawing.Point(11, 49);
            this.chkMedikamenteJN.Name = "chkMedikamenteJN";
            this.chkMedikamenteJN.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkMedikamenteJN.Size = new System.Drawing.Size(116, 22);
            this.chkMedikamenteJN.TabIndex = 1;
            this.chkMedikamenteJN.Text = "Medikamente J/N";
            this.chkMedikamenteJN.UseVisualStyleBackColor = true;
            // 
            // lblAusdruckVon
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblAusdruckVon.Appearance = appearance1;
            this.lblAusdruckVon.AutoSize = true;
            this.lblAusdruckVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusdruckVon.Location = new System.Drawing.Point(14, 8);
            this.lblAusdruckVon.Name = "lblAusdruckVon";
            this.lblAusdruckVon.Size = new System.Drawing.Size(76, 14);
            this.lblAusdruckVon.TabIndex = 86;
            this.lblAusdruckVon.Text = "Ausdruck von:";
            // 
            // btnPrint
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance2;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrint.DoOnClick = true;
            this.btnPrint.IsStandardControl = true;
            this.btnPrint.Location = new System.Drawing.Point(79, 81);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 29);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.TabStop = false;
            this.btnPrint.TYPE = PMDS.GUI.ucButton.ButtonType.Print;
            this.btnPrint.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnPrint.Click += new System.EventHandler(this.btnPrintStammdaten_Click);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlPrintArztbrief;
            // 
            // btnPrintSettings
            // 
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintSettings.Appearance = appearance3;
            this.btnPrintSettings.Location = new System.Drawing.Point(0, 0);
            this.btnPrintSettings.Name = "btnPrintSettings";
            this.btnPrintSettings.PopupItemKey = "pnlPrintStammDatenBlatt";
            this.btnPrintSettings.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnPrintSettings.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.btnPrintSettings.Size = new System.Drawing.Size(131, 30);
            this.btnPrintSettings.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnPrintSettings.TabIndex = 89;
            this.btnPrintSettings.Text = "&Arztbrief drucken";
            this.btnPrintSettings.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrintSettings.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ucPrintArztbrief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrintSettings);
            this.Controls.Add(this.pnlPrintArztbrief);
            this.Name = "ucPrintArztbrief";
            this.Size = new System.Drawing.Size(174, 157);
            this.pnlPrintArztbrief.ResumeLayout(false);
            this.pnlPrintArztbrief.PerformLayout();
            this.ResumeLayout(false);

          }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlPrintArztbrief;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusdruckVon;
        private ucButton btnPrint;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private Infragistics.Win.Misc.UltraDropDownButton btnPrintSettings;
        public System.Windows.Forms.CheckBox chkDiagnosenJN;
        public System.Windows.Forms.CheckBox chkMedikamenteJN;
    }
}
