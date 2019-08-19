namespace PMDS.GUI.BaseControls
{
    partial class ucBigBereichsAuswahl
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
            this.btnBereich = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlAbtList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnBereich
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Bottom";
            this.btnBereich.Appearance = appearance1;
            this.btnBereich.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBereich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBereich.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBereich.Location = new System.Drawing.Point(0, 0);
            this.btnBereich.Name = "btnBereich";
            this.btnBereich.PopupItemKey = "pnlAbtList";
            this.btnBereich.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnBereich.ShowFocusRect = false;
            this.btnBereich.Size = new System.Drawing.Size(97, 94);
            this.btnBereich.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnBereich.TabIndex = 0;
            this.btnBereich.Text = "*********";
            this.btnBereich.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlAbtList;
            // 
            // pnlAbtList
            // 
            this.pnlAbtList.Location = new System.Drawing.Point(21, 49);
            this.pnlAbtList.Name = "pnlAbtList";
            this.pnlAbtList.Size = new System.Drawing.Size(367, 109);
            this.pnlAbtList.TabIndex = 1;
            this.pnlAbtList.Visible = false;
            // 
            // ucBigBereichsAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlAbtList);
            this.Controls.Add(this.btnBereich);
            this.Name = "ucBigBereichsAuswahl";
            this.Size = new System.Drawing.Size(97, 94);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton btnBereich;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private System.Windows.Forms.FlowLayoutPanel pnlAbtList;
    }
}
