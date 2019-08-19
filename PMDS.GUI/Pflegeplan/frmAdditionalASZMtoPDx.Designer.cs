namespace PMDS.GUI
{
    partial class frmAdditionalASZMtoPDx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdditionalASZMtoPDx));
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblAuswahlInfo = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lbAbteilungen = new System.Windows.Forms.CheckedListBox();
            this.cbStandard = new System.Windows.Forms.CheckBox();
            this.lblFürAbteilungen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblMainInfo = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.btnExit = new PMDS.GUI.ucButton(this.components);
            this.cbASZM = new PMDS.GUI.BaseControls.ASZMCombo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbPflegeplan = new System.Windows.Forms.CheckBox();
            this.btnCancelHidden = new QS2.Desktop.ControlManagment.BaseButtonWin();
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(575, 76);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAuswahlInfo
            // 
            this.lblAuswahlInfo.AutoSize = true;
            this.lblAuswahlInfo.Location = new System.Drawing.Point(19, 60);
            this.lblAuswahlInfo.Name = "lblAuswahlInfo";
            this.lblAuswahlInfo.Size = new System.Drawing.Size(24, 13);
            this.lblAuswahlInfo.TabIndex = 23;
            this.lblAuswahlInfo.Text = "info";
            // 
            // lbAbteilungen
            // 
            this.lbAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAbteilungen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAbteilungen.CheckOnClick = true;
            this.lbAbteilungen.Enabled = false;
            this.lbAbteilungen.FormattingEnabled = true;
            this.lbAbteilungen.Location = new System.Drawing.Point(22, 151);
            this.lbAbteilungen.MultiColumn = true;
            this.lbAbteilungen.Name = "lbAbteilungen";
            this.lbAbteilungen.Size = new System.Drawing.Size(364, 107);
            this.lbAbteilungen.TabIndex = 1;
            // 
            // cbStandard
            // 
            this.cbStandard.AutoSize = true;
            this.cbStandard.Location = new System.Drawing.Point(22, 103);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(163, 17);
            this.cbStandard.TabIndex = 0;
            this.cbStandard.Text = "in den Standard übernehmen";
            this.cbStandard.UseVisualStyleBackColor = true;
            this.cbStandard.CheckedChanged += new System.EventHandler(this.cbStandard_CheckedChanged);
            // 
            // lblFürAbteilungen
            // 
            this.lblFürAbteilungen.AutoSize = true;
            this.lblFürAbteilungen.Location = new System.Drawing.Point(19, 135);
            this.lblFürAbteilungen.Name = "lblFürAbteilungen";
            this.lblFürAbteilungen.Size = new System.Drawing.Size(98, 13);
            this.lblFürAbteilungen.TabIndex = 26;
            this.lblFürAbteilungen.Text = "Für die Abteilungen";
            // 
            // lblMainInfo
            // 
            this.lblMainInfo.Location = new System.Drawing.Point(19, 9);
            this.lblMainInfo.Name = "lblMainInfo";
            this.lblMainInfo.Size = new System.Drawing.Size(547, 51);
            this.lblMainInfo.TabIndex = 27;
            this.lblMainInfo.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExit.Appearance = appearance1;
            this.btnExit.AutoWorkLayout = false;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.DoOnClick = true;
            this.btnExit.IsStandardControl = true;
            this.btnExit.Location = new System.Drawing.Point(527, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 32);
            this.btnExit.TabIndex = 26;
            this.btnExit.TabStop = false;
            this.btnExit.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnExit.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbASZM
            // 
            this.cbASZM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbASZM.DISPLAY_TEXT = "GUI.SEARCH_MASSNAHME";
            this.cbASZM.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbASZM.GROUP = PMDS.Global.EintragGruppe.A;
            this.cbASZM.Location = new System.Drawing.Point(22, 76);
            this.cbASZM.MaxDropDownItems = 30;
            this.cbASZM.Name = "cbASZM";
            this.cbASZM.Size = new System.Drawing.Size(547, 21);
            this.cbASZM.TabIndex = 20;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbPflegeplan
            // 
            this.cbPflegeplan.AutoSize = true;
            this.cbPflegeplan.Checked = true;
            this.cbPflegeplan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPflegeplan.Location = new System.Drawing.Point(403, 103);
            this.cbPflegeplan.Name = "cbPflegeplan";
            this.cbPflegeplan.Size = new System.Drawing.Size(170, 17);
            this.cbPflegeplan.TabIndex = 28;
            this.cbPflegeplan.Text = "in den Pflegeplan übernehmen";
            this.cbPflegeplan.UseVisualStyleBackColor = true;
            this.cbPflegeplan.CheckedChanged += new System.EventHandler(this.cbPflegeplan_CheckedChanged);
            // 
            // btnCancelHidden
            // 
            this.btnCancelHidden.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelHidden.Location = new System.Drawing.Point(570, 232);
            this.btnCancelHidden.Name = "btnCancelHidden";
            this.btnCancelHidden.Size = new System.Drawing.Size(27, 23);
            this.btnCancelHidden.TabIndex = 29;
            this.btnCancelHidden.Text = "button1";
            this.btnCancelHidden.UseVisualStyleBackColor = true;
            // 
            // frmAdditionalASZMtoPDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancelHidden;
            this.ClientSize = new System.Drawing.Size(609, 277);
            this.Controls.Add(this.lbAbteilungen);
            this.Controls.Add(this.lblFürAbteilungen);
            this.Controls.Add(this.cbPflegeplan);
            this.Controls.Add(this.cbStandard);
            this.Controls.Add(this.lblMainInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbASZM);
            this.Controls.Add(this.lblAuswahlInfo);
            this.Controls.Add(this.btnCancelHidden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdditionalASZMtoPDx";
            this.ShowInTaskbar = false;
            this.Text = "***";
            this.Load += new System.EventHandler(this.frmAdditionalASZMtoPDx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbASZM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PMDS.GUI.BaseControls.ASZMCombo cbASZM;
        private QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseLableWin lblAuswahlInfo;
        private System.Windows.Forms.CheckBox cbStandard;
        private QS2.Desktop.ControlManagment.BaseLableWin lblFürAbteilungen;
        private System.Windows.Forms.CheckedListBox lbAbteilungen;
        private ucButton btnExit;
        private QS2.Desktop.ControlManagment.BaseLableWin lblMainInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox cbPflegeplan;
        private QS2.Desktop.ControlManagment.BaseButtonWin btnCancelHidden;
    }
}