namespace PMDS.GUI
{
    partial class ucAdditionalASZMToPDx
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAdditionalASZMToPDx));
            this.lbAbteilungen = new System.Windows.Forms.CheckedListBox();
            this.lblFürAbteilungen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbDefinition = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.ucPicker1 = new PMDS.GUI.ucPicker();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.cbStandard = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbPflegeplan = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegeplan)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAbteilungen
            // 
            this.lbAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAbteilungen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAbteilungen.CheckOnClick = true;
            this.lbAbteilungen.Enabled = false;
            this.lbAbteilungen.FormattingEnabled = true;
            this.lbAbteilungen.Location = new System.Drawing.Point(8, 528);
            this.lbAbteilungen.MultiColumn = true;
            this.lbAbteilungen.Name = "lbAbteilungen";
            this.lbAbteilungen.Size = new System.Drawing.Size(358, 107);
            this.lbAbteilungen.TabIndex = 6;
            // 
            // lblFürAbteilungen
            // 
            this.lblFürAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFürAbteilungen.AutoSize = true;
            this.lblFürAbteilungen.Location = new System.Drawing.Point(5, 512);
            this.lblFürAbteilungen.Name = "lblFürAbteilungen";
            this.lblFürAbteilungen.Size = new System.Drawing.Size(98, 13);
            this.lblFürAbteilungen.TabIndex = 32;
            this.lblFürAbteilungen.Text = "Für die Abteilungen";
            // 
            // tbDefinition
            // 
            this.tbDefinition.AcceptsReturn = true;
            this.tbDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbDefinition.Appearance = appearance1;
            this.tbDefinition.BackColor = System.Drawing.SystemColors.Window;
            this.tbDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefinition.Location = new System.Drawing.Point(8, 30);
            this.tbDefinition.MaxLength = 2048;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.ReadOnly = true;
            this.tbDefinition.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbDefinition.Size = new System.Drawing.Size(358, 52);
            this.tbDefinition.TabIndex = 2;
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbText.Appearance = appearance2;
            this.tbText.BackColor = System.Drawing.SystemColors.Window;
            this.tbText.Location = new System.Drawing.Point(8, 7);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.Size = new System.Drawing.Size(358, 21);
            this.tbText.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancel
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance4;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(31, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance5;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DoOnClick = true;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(118, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 26);
            this.btnOk.TabIndex = 34;
            this.btnOk.TabStop = false;
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucPicker1
            // 
            this.ucPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPicker1.BackColor = System.Drawing.Color.Transparent;
            this.ucPicker1.DataSource = null;
            this.ucPicker1.DisplayMember = "";
            this.ucPicker1.Location = new System.Drawing.Point(7, 88);
            this.ucPicker1.Name = "ucPicker1";
            this.ucPicker1.Size = new System.Drawing.Size(358, 386);
            this.ucPicker1.TabIndex = 3;
            this.ucPicker1.Value = null;
            this.ucPicker1.ValueMember = "";
            this.ucPicker1.Selected += new PMDS.GUI.ucPicker.PickerSelectedDelegate(this.ucPicker1_Selected);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Location = new System.Drawing.Point(199, 642);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(168, 30);
            this.panelButtons.TabIndex = 37;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance3;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(367, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 22);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbStandard
            // 
            this.cbStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStandard.Location = new System.Drawing.Point(8, 480);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(176, 17);
            this.cbStandard.TabIndex = 40;
            this.cbStandard.Text = "in den Standard übernehmen";
            this.cbStandard.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbStandard.CheckedChanged += new System.EventHandler(this.cbStandard_CheckedChanged);
            // 
            // cbPflegeplan
            // 
            this.cbPflegeplan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPflegeplan.Checked = true;
            this.cbPflegeplan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPflegeplan.Location = new System.Drawing.Point(190, 480);
            this.cbPflegeplan.Name = "cbPflegeplan";
            this.cbPflegeplan.Size = new System.Drawing.Size(175, 17);
            this.cbPflegeplan.TabIndex = 41;
            this.cbPflegeplan.Text = "in den Pflegeplan übernehmen";
            this.cbPflegeplan.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbPflegeplan.CheckedChanged += new System.EventHandler(this.cbPflegeplan_CheckedChanged);
            // 
            // ucAdditionalASZMToPDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPflegeplan);
            this.Controls.Add(this.cbStandard);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.ucPicker1);
            this.Controls.Add(this.lbAbteilungen);
            this.Controls.Add(this.lblFürAbteilungen);
            this.Name = "ucAdditionalASZMToPDx";
            this.Size = new System.Drawing.Size(393, 675);
            this.Load += new System.EventHandler(this.ucAdditionalASZMToPDx_Load);
            this.VisibleChanged += new System.EventHandler(this.ucAdditionalASZMToPDx_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegeplan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lbAbteilungen;
        private QS2.Desktop.ControlManagment.BaseLableWin lblFürAbteilungen;
        private ucPicker ucPicker1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbDefinition;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucButton btnCancel;
        private ucButton btnOk;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbStandard;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbPflegeplan;
    }
}
