namespace PMDS.GUI
{
    partial class ucDatenErhebungMain
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelDatenerhebung = new System.Windows.Forms.Panel();
            this.ucDatenErhebung1 = new PMDS.GUI.ucDatenErhebung();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelDynReports = new System.Windows.Forms.Panel();
            this.ucDynReports1 = new PMDS.GUI.ucDynReports();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2.SuspendLayout();
            this.panelDatenerhebung.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelDynReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.panelDatenerhebung);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(747, 431);
            // 
            // panelDatenerhebung
            // 
            this.panelDatenerhebung.BackColor = System.Drawing.Color.Transparent;
            this.panelDatenerhebung.Controls.Add(this.ucDatenErhebung1);
            this.panelDatenerhebung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatenerhebung.Location = new System.Drawing.Point(0, 0);
            this.panelDatenerhebung.Name = "panelDatenerhebung";
            this.panelDatenerhebung.Size = new System.Drawing.Size(747, 431);
            this.panelDatenerhebung.TabIndex = 0;
            // 
            // ucDatenErhebung1
            // 
            this.ucDatenErhebung1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucDatenErhebung1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucDatenErhebung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDatenErhebung1.FRAMEWORK = null;
            this.ucDatenErhebung1.Location = new System.Drawing.Point(0, 0);
            this.ucDatenErhebung1.Name = "ucDatenErhebung1";
            this.ucDatenErhebung1.Size = new System.Drawing.Size(747, 431);
            this.ucDatenErhebung1.TabIndex = 0;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelDynReports);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(747, 431);
            // 
            // panelDynReports
            // 
            this.panelDynReports.BackColor = System.Drawing.Color.Transparent;
            this.panelDynReports.Controls.Add(this.ucDynReports1);
            this.panelDynReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDynReports.Location = new System.Drawing.Point(0, 0);
            this.panelDynReports.Name = "panelDynReports";
            this.panelDynReports.Size = new System.Drawing.Size(747, 431);
            this.panelDynReports.TabIndex = 1;
            // 
            // ucDynReports1
            // 
            this.ucDynReports1.BackColor = System.Drawing.Color.Transparent;
            this.ucDynReports1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDynReports1.Location = new System.Drawing.Point(0, 0);
            this.ucDynReports1.Name = "ucDynReports1";
            this.ucDynReports1.Size = new System.Drawing.Size(747, 431);
            this.ucDynReports1.TabIndex = 0;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(751, 457);
            this.ultraTabControl1.TabIndex = 0;
            ultraTab2.Key = "Anamnesen, Biografie und Assessments";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Anamnesen, Biografie und Assessments";
            ultraTab1.Key = "Dokumente und Berichte";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Dokumente und Berichte";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab2,
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(747, 431);
            // 
            // ucDatenErhebungMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "ucDatenErhebungMain";
            this.Size = new System.Drawing.Size(751, 457);
            this.Load += new System.EventHandler(this.ucDatenErhebungMain_Load);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.panelDatenerhebung.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelDynReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.Panel panelDatenerhebung;
        private System.Windows.Forms.Panel panelDynReports;
        private ucDynReports ucDynReports1;
        public ucDatenErhebung ucDatenErhebung1;
    }
}
