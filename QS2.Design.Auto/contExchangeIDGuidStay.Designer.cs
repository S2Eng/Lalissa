namespace qs2.ui
{
    partial class contExchangeIDGuidStay
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.pnlImport = new Infragistics.Win.Misc.UltraPanel();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.lblIDStayGuid = new Infragistics.Win.Misc.UltraLabel();
            this.txtIDStayGuid = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnAction = new Infragistics.Win.Misc.UltraButton();
            this.lblRecordInfo = new Infragistics.Win.Misc.UltraLabel();
            this.gbSource = new Infragistics.Win.Misc.UltraGroupBox();
            this.rbClipboard = new Infragistics.Win.UltraWinEditors.UltraRadioButton();
            this.rbFile = new Infragistics.Win.UltraWinEditors.UltraRadioButton();
            this.gbTarget = new Infragistics.Win.Misc.UltraGroupBox();
            this.rbAsParent = new Infragistics.Win.UltraWinEditors.UltraRadioButton();
            this.rbAsChild = new Infragistics.Win.UltraWinEditors.UltraRadioButton();
            this.pnlImport.ClientArea.SuspendLayout();
            this.pnlImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDStayGuid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSource)).BeginInit();
            this.gbSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbClipboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTarget)).BeginInit();
            this.gbTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbAsParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAsChild)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImport
            // 
            // 
            // pnlImport.ClientArea
            // 
            this.pnlImport.ClientArea.Controls.Add(this.gbTarget);
            this.pnlImport.ClientArea.Controls.Add(this.btnSave);
            this.pnlImport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlImport.Location = new System.Drawing.Point(0, 133);
            this.pnlImport.Name = "pnlImport";
            this.pnlImport.Size = new System.Drawing.Size(533, 49);
            this.pnlImport.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(392, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblIDStayGuid
            // 
            this.lblIDStayGuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDStayGuid.Location = new System.Drawing.Point(13, 67);
            this.lblIDStayGuid.Name = "lblIDStayGuid";
            this.lblIDStayGuid.Size = new System.Drawing.Size(165, 23);
            this.lblIDStayGuid.TabIndex = 2;
            this.lblIDStayGuid.Text = "IDStayGuid";
            // 
            // txtIDStayGuid
            // 
            this.txtIDStayGuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.BoldAsString = "True";
            this.txtIDStayGuid.Appearance = appearance3;
            this.txtIDStayGuid.Location = new System.Drawing.Point(184, 65);
            this.txtIDStayGuid.Name = "txtIDStayGuid";
            this.txtIDStayGuid.Size = new System.Drawing.Size(335, 21);
            this.txtIDStayGuid.TabIndex = 3;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(389, 6);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(127, 30);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Export";
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblRecordInfo
            // 
            this.lblRecordInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordInfo.Location = new System.Drawing.Point(6, 8);
            this.lblRecordInfo.Name = "lblRecordInfo";
            this.lblRecordInfo.Size = new System.Drawing.Size(513, 45);
            this.lblRecordInfo.TabIndex = 6;
            this.lblRecordInfo.Text = "Aufenthaltsdaten";
            // 
            // gbSource
            // 
            this.gbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.gbSource.Appearance = appearance4;
            this.gbSource.Controls.Add(this.rbFile);
            this.gbSource.Controls.Add(this.rbClipboard);
            this.gbSource.Controls.Add(this.btnAction);
            this.gbSource.Location = new System.Drawing.Point(3, 91);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(522, 43);
            this.gbSource.TabIndex = 7;
            // 
            // rbClipboard
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.FontData.SizeInPoints = 7F;
            this.rbClipboard.Appearance = appearance6;
            this.rbClipboard.Checked = true;
            this.rbClipboard.Location = new System.Drawing.Point(17, 11);
            this.rbClipboard.Name = "rbClipboard";
            this.rbClipboard.Size = new System.Drawing.Size(187, 21);
            this.rbClipboard.TabIndex = 0;
            this.rbClipboard.Text = "Clipboard";
            // 
            // rbFile
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.FontData.SizeInPoints = 7F;
            this.rbFile.Appearance = appearance5;
            this.rbFile.Location = new System.Drawing.Point(208, 11);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(164, 21);
            this.rbFile.TabIndex = 1;
            this.rbFile.TabStop = false;
            this.rbFile.Text = "File";
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.rbAsChild);
            this.gbTarget.Controls.Add(this.rbAsParent);
            this.gbTarget.Location = new System.Drawing.Point(6, 5);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(380, 33);
            this.gbTarget.TabIndex = 7;
            // 
            // rbAsParent
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.SizeInPoints = 7F;
            this.rbAsParent.Appearance = appearance2;
            this.rbAsParent.BackColor = System.Drawing.Color.Transparent;
            this.rbAsParent.Checked = true;
            this.rbAsParent.Location = new System.Drawing.Point(14, 6);
            this.rbAsParent.Name = "rbAsParent";
            this.rbAsParent.Size = new System.Drawing.Size(187, 21);
            this.rbAsParent.TabIndex = 6;
            this.rbAsParent.Text = "AsParent";
            // 
            // rbAsChild
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.SizeInPoints = 7F;
            this.rbAsChild.Appearance = appearance1;
            this.rbAsChild.BackColor = System.Drawing.Color.Transparent;
            this.rbAsChild.Location = new System.Drawing.Point(207, 6);
            this.rbAsChild.Name = "rbAsChild";
            this.rbAsChild.Size = new System.Drawing.Size(164, 21);
            this.rbAsChild.TabIndex = 6;
            this.rbAsChild.TabStop = false;
            this.rbAsChild.Text = "AsChild";
            // 
            // contExchangeIDGuidStay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.lblRecordInfo);
            this.Controls.Add(this.txtIDStayGuid);
            this.Controls.Add(this.lblIDStayGuid);
            this.Controls.Add(this.pnlImport);
            this.MinimumSize = new System.Drawing.Size(533, 182);
            this.Name = "contExchangeIDGuidStay";
            this.Size = new System.Drawing.Size(533, 182);
            this.pnlImport.ClientArea.ResumeLayout(false);
            this.pnlImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIDStayGuid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSource)).EndInit();
            this.gbSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbClipboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTarget)).EndInit();
            this.gbTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbAsParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAsChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel pnlImport;
        private Infragistics.Win.Misc.UltraLabel lblIDStayGuid;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtIDStayGuid;
        private Infragistics.Win.Misc.UltraButton btnAction;
        private Infragistics.Win.Misc.UltraLabel lblRecordInfo;
        private Infragistics.Win.Misc.UltraGroupBox gbSource;
        private Infragistics.Win.UltraWinEditors.UltraRadioButton rbFile;
        private Infragistics.Win.UltraWinEditors.UltraRadioButton rbClipboard;
        private Infragistics.Win.Misc.UltraGroupBox gbTarget;
        private Infragistics.Win.UltraWinEditors.UltraRadioButton rbAsChild;
        private Infragistics.Win.UltraWinEditors.UltraRadioButton rbAsParent;
    }
}
