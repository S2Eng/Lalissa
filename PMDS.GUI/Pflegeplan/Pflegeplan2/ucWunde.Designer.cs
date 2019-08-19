namespace PMDS.GUI
{
    partial class ucWunde
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucWunddoku1 = new PMDS.GUI.BaseControls.ucWunddoku();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucZielEvaluierung1 = new PMDS.GUI.ucZielEvaluierung();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabMain = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ucWunddoku1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(753, 513);
            // 
            // ucWunddoku1
            // 
            this.ucWunddoku1.BackColor = System.Drawing.Color.White;
            this.ucWunddoku1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWunddoku1.Location = new System.Drawing.Point(0, 0);
            this.ucWunddoku1.Name = "ucWunddoku1";
            this.ucWunddoku1.Size = new System.Drawing.Size(753, 513);
            this.ucWunddoku1.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.AutoScroll = true;
            this.ultraTabPageControl2.Controls.Add(this.ucZielEvaluierung1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(753, 513);
            // 
            // ucZielEvaluierung1
            // 
            this.ucZielEvaluierung1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucZielEvaluierung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucZielEvaluierung1.Location = new System.Drawing.Point(0, 0);
            this.ucZielEvaluierung1.Name = "ucZielEvaluierung1";
            this.ucZielEvaluierung1.Size = new System.Drawing.Size(753, 513);
            this.ucZielEvaluierung1.TabIndex = 0;
            this.ucZielEvaluierung1.Wundejn = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabMain
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabMain.ClientAreaAppearance = appearance1;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Controls.Add(this.ultraTabPageControl2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabMain.Size = new System.Drawing.Size(757, 539);
            this.tabMain.TabIndex = 0;
            ultraTab1.Key = "wunde";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Wunddokumentation";
            ultraTab2.Key = "evaluierung";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Evaluierung";
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.tabMain.VisibleChanged += new System.EventHandler(this.tabMain_VisibleChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(753, 513);
            // 
            // ucWunde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabMain);
            this.Name = "ucWunde";
            this.Size = new System.Drawing.Size(757, 539);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseTabControl tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private ucZielEvaluierung ucZielEvaluierung1;
        public BaseControls.ucWunddoku ucWunddoku1;
    }
}
