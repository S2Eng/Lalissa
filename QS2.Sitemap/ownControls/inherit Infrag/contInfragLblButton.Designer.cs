namespace qs2.sitemap.ownControls.inherit_Infrag
{
    partial class contInfragLblButton
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
            this.lblButton = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SuspendLayout();
            // 
            // lblButton
            // 
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblButton.Appearance = appearance1;
            this.lblButton.AutoSize = true;
            this.lblButton.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance2.FontData.UnderlineAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblButton.HotTrackAppearance = appearance2;
            this.lblButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblButton.Location = new System.Drawing.Point(0, 0);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(136, 17);
            this.lblButton.TabIndex = 242;
            this.lblButton.Text = "History";
            this.lblButton.UseAppStyling = false;
            this.lblButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblButton.Click += new System.EventHandler(this.lblButton_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 10000;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // contInfragLblButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblButton);
            this.Name = "contInfragLblButton";
            this.Size = new System.Drawing.Size(136, 17);
            this.Load += new System.EventHandler(this.contInfragLblButton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblButton;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
