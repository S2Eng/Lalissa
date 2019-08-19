namespace PMDS.GUI.Verordnungen
{
    partial class ucVOMain
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucVOErfassen1 = new PMDS.GUI.Verordnungen.ucVOErfassen();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucVOBestellvorschläge1 = new PMDS.GUI.Verordnungen.ucVOBestellvorschlaege();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucVOLieferung1 = new PMDS.GUI.Verordnungen.ucVOBestellvorschlaege();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucLager1 = new PMDS.GUI.Verordnungen.ucLager();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ucVOErfassen1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1271, 663);
            // 
            // ucVOErfassen1
            // 
            this.ucVOErfassen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOErfassen1.Location = new System.Drawing.Point(0, 0);
            this.ucVOErfassen1.Name = "ucVOErfassen1";
            this.ucVOErfassen1.Size = new System.Drawing.Size(1271, 663);
            this.ucVOErfassen1.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ucVOBestellvorschläge1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1060, 663);
            // 
            // ucVOBestellvorschläge1
            // 
            this.ucVOBestellvorschläge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOBestellvorschläge1.Location = new System.Drawing.Point(0, 0);
            this.ucVOBestellvorschläge1.Name = "ucVOBestellvorschläge1";
            this.ucVOBestellvorschläge1.Size = new System.Drawing.Size(1060, 663);
            this.ucVOBestellvorschläge1.TabIndex = 0;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ucVOLieferung1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1060, 663);
            // 
            // ucVOLieferung1
            // 
            this.ucVOLieferung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOLieferung1.Location = new System.Drawing.Point(0, 0);
            this.ucVOLieferung1.Name = "ucVOLieferung1";
            this.ucVOLieferung1.Size = new System.Drawing.Size(1060, 663);
            this.ucVOLieferung1.TabIndex = 1;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ucLager1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(1060, 663);
            // 
            // ucLager1
            // 
            this.ucLager1.BackColor = System.Drawing.Color.White;
            this.ucLager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLager1.Location = new System.Drawing.Point(0, 0);
            this.ucLager1.Name = "ucLager1";
            this.ucLager1.Size = new System.Drawing.Size(1060, 663);
            this.ucLager1.TabIndex = 0;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(1275, 689);
            this.ultraTabControl1.TabIndex = 1;
            ultraTab1.Key = "Erfassung";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Erfassung";
            ultraTab2.Key = "Bestellvorschläge";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Bestellvorschläge";
            ultraTab3.Key = "Bestellungen";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Bestellungen";
            ultraTab4.Key = "Lager";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "Lager";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4});
            this.ultraTabControl1.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.ultraTabControl1_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1271, 663);
            // 
            // ucVOMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "ucVOMain";
            this.Size = new System.Drawing.Size(1275, 689);
            this.Load += new System.EventHandler(this.ucVOMain_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        public ucVOErfassen ucVOErfassen1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        public ucVOBestellvorschlaege ucVOBestellvorschläge1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        public ucVOBestellvorschlaege ucVOLieferung1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private ucLager ucLager1;
    }
}
