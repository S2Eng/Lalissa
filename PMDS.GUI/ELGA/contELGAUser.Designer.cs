namespace PMDS.GUI.ELGA
{
    partial class contELGAUser
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.contELGASettings1 = new PMDS.GUI.ELGA.ManageSettings.contELGASettings();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.contELGARights1 = new PMDS.GUI.ELGA.ManageSettings.contELGARights();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.contELGAProtocoll1 = new PMDS.GUI.ELGA.contELGAProtocoll();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.contELGASettings1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(655, 425);
            // 
            // contELGASettings1
            // 
            this.contELGASettings1.BackColor = System.Drawing.Color.White;
            this.contELGASettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGASettings1.Location = new System.Drawing.Point(0, 0);
            this.contELGASettings1.Name = "contELGASettings1";
            this.contELGASettings1.Size = new System.Drawing.Size(655, 425);
            this.contELGASettings1.TabIndex = 0;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.contELGARights1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(655, 425);
            // 
            // contELGARights1
            // 
            this.contELGARights1.BackColor = System.Drawing.Color.Transparent;
            this.contELGARights1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGARights1.Location = new System.Drawing.Point(0, 0);
            this.contELGARights1.Name = "contELGARights1";
            this.contELGARights1.Size = new System.Drawing.Size(655, 425);
            this.contELGARights1.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.contELGAProtocoll1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(655, 425);
            // 
            // contELGAProtocoll1
            // 
            this.contELGAProtocoll1.BackColor = System.Drawing.Color.Transparent;
            this.contELGAProtocoll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGAProtocoll1.Location = new System.Drawing.Point(0, 0);
            this.contELGAProtocoll1.Name = "contELGAProtocoll1";
            this.contELGAProtocoll1.Size = new System.Drawing.Size(655, 425);
            this.contELGAProtocoll1.TabIndex = 0;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(659, 451);
            this.ultraTabControl1.TabIndex = 0;
            ultraTab3.Key = "tabELGASettings";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Einstellungen";
            ultraTab1.Key = "tabELGARights";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Rechte";
            ultraTab2.Key = "tabELGAProtocoll";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Protokoll";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(655, 425);
            // 
            // contELGAUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "contELGAUser";
            this.Size = new System.Drawing.Size(659, 451);
            this.Load += new System.EventHandler(this.contELGAUserAdmin_Load);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        public ManageSettings.contELGARights contELGARights1;
        public contELGAProtocoll contELGAProtocoll1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        public ManageSettings.contELGASettings contELGASettings1;
    }
}
