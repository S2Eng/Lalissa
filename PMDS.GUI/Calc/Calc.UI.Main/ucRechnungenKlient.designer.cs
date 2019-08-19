namespace PMDS.Calc.UI.Admin
{
    partial class ucRechnungenKlient
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelRechnungen = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucCalcs1 = new PMDS.Calc.UI.ucCalcs();
            this.tabMain = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl3.SuspendLayout();
            this.panelRechnungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.panelRechnungen);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(834, 387);
            // 
            // panelRechnungen
            // 
            this.panelRechnungen.Controls.Add(this.ucCalcs1);
            this.panelRechnungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRechnungen.Location = new System.Drawing.Point(0, 0);
            this.panelRechnungen.Name = "panelRechnungen";
            this.panelRechnungen.Size = new System.Drawing.Size(834, 387);
            this.panelRechnungen.TabIndex = 0;
            // 
            // ucCalcs1
            // 
            this.ucCalcs1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucCalcs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCalcs1.Location = new System.Drawing.Point(0, 0);
            this.ucCalcs1.Name = "ucCalcs1";
            this.ucCalcs1.Size = new System.Drawing.Size(834, 387);
            this.ucCalcs1.TabIndex = 0;
            // 
            // tabMain
            // 
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabMain.Appearance = appearance2;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabMain.Controls.Add(this.ultraTabPageControl3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabMain.Size = new System.Drawing.Size(838, 413);
            this.tabMain.TabIndex = 16;
            ultraTab3.Key = "LeistungenNeu";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Rechnungen";
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3});
            this.tabMain.UseAppStyling = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(834, 387);
            // 
            // ucRechnungenKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tabMain);
            this.Name = "ucRechnungenKlient";
            this.Size = new System.Drawing.Size(838, 413);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.panelRechnungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTabControl tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private QS2.Desktop.ControlManagment.BasePanel panelRechnungen;
        public PMDS.Calc.UI.ucCalcs ucCalcs1;

    }
}
