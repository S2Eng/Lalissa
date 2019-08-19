namespace PMDS.GUI.BaseControls
{
    partial class frmWundBilderScale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.optTypeUI = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraProgressBar1 = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.numWidthHeight = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblWidth = new Infragistics.Win.Misc.UltraLabel();
            this.lblInfo = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.optTypeUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidthHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance1;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(233, 167);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 28);
            this.btnSave.TabIndex = 36;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Durchführen";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // optTypeUI
            // 
            this.optTypeUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optTypeUI.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optTypeUI.CheckedIndex = 0;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "Scale";
            valueListItem1.DisplayText = "Wundbilder skalieren (unskalierte Bilder werden gesichert)";
            valueListItem2.DataValue = "ResetToOrig";
            valueListItem2.DisplayText = "Wundbild-Kopien wieder herstellen";
            valueListItem3.DataValue = "DeleteOrigPictures";
            valueListItem3.DisplayText = "Wundbild-Kopien löschen";
            this.optTypeUI.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optTypeUI.ItemSpacingVertical = 3;
            this.optTypeUI.Location = new System.Drawing.Point(12, 8);
            this.optTypeUI.Name = "optTypeUI";
            this.optTypeUI.Size = new System.Drawing.Size(328, 57);
            this.optTypeUI.TabIndex = 37;
            this.optTypeUI.Text = "Wundbilder skalieren (unskalierte Bilder werden gesichert)";
            // 
            // ultraProgressBar1
            // 
            this.ultraProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraProgressBar1.Location = new System.Drawing.Point(12, 198);
            this.ultraProgressBar1.Name = "ultraProgressBar1";
            this.ultraProgressBar1.Size = new System.Drawing.Size(328, 18);
            this.ultraProgressBar1.TabIndex = 38;
            this.ultraProgressBar1.Text = "[Formatted]";
            // 
            // numWidthHeight
            // 
            this.numWidthHeight.Location = new System.Drawing.Point(76, 83);
            this.numWidthHeight.MinValue = 1024;
            this.numWidthHeight.Name = "numWidthHeight";
            this.numWidthHeight.Size = new System.Drawing.Size(86, 21);
            this.numWidthHeight.TabIndex = 39;
            this.numWidthHeight.Value = 1200;
            // 
            // lblWidth
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.lblWidth.Appearance = appearance2;
            this.lblWidth.Location = new System.Drawing.Point(12, 83);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(85, 21);
            this.lblWidth.TabIndex = 40;
            this.lblWidth.Text = "Breite/Höhe";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(12, 114);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(308, 38);
            this.lblInfo.TabIndex = 41;
            this.lblInfo.Text = "Wundbilder skalieren kann nicht ausgeführt werden, da Bilder ohne eine WundePos-R" +
    "ow existieren. Bitte S2-Engineering kontaktieren";
            this.lblInfo.Visible = false;
            // 
            // frmWundBilderScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 219);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.numWidthHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.ultraProgressBar1);
            this.Controls.Add(this.optTypeUI);
            this.Controls.Add(this.btnSave);
            this.Name = "frmWundBilderScale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wundbilder skalieren";
            this.Load += new System.EventHandler(this.frmWundBilderScale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optTypeUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidthHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optTypeUI;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar ultraProgressBar1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numWidthHeight;
        private Infragistics.Win.Misc.UltraLabel lblWidth;
        private Infragistics.Win.Misc.UltraLabel lblInfo;
    }
}