namespace PMDS.GUI
{
    partial class ucSiteMapBewerber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSiteMapBewerber));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControlAufnahme = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnNext = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucBewerberAufnahme1 = new PMDS.GUI.ucBewerberAufnahme();
            this.ultraTabPageControlBewerber = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucBewerber1 = new PMDS.GUI.ucBewerber();
            this.tabBewerber = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage3 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraTabPageControlAufnahme.SuspendLayout();
            this.ultraTabPageControlBewerber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabBewerber)).BeginInit();
            this.tabBewerber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControlAufnahme
            // 
            this.ultraTabPageControlAufnahme.Controls.Add(this.btnNext);
            this.ultraTabPageControlAufnahme.Controls.Add(this.ucBewerberAufnahme1);
            this.ultraTabPageControlAufnahme.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControlAufnahme.Name = "ultraTabPageControlAufnahme";
            this.ultraTabPageControlAufnahme.Size = new System.Drawing.Size(770, 454);
            // 
            // btnNext
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnNext.Appearance = appearance1;
            this.btnNext.AutoWorkLayout = false;
            this.btnNext.IsStandardControl = false;
            this.btnNext.Location = new System.Drawing.Point(269, 23);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(73, 24);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Weiter";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucBewerberAufnahme1
            // 
            this.ucBewerberAufnahme1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBewerberAufnahme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBewerberAufnahme1.Location = new System.Drawing.Point(0, 0);
            this.ucBewerberAufnahme1.Name = "ucBewerberAufnahme1";
            this.ucBewerberAufnahme1.Size = new System.Drawing.Size(770, 454);
            this.ucBewerberAufnahme1.TabIndex = 0;
            this.ucBewerberAufnahme1.BewebungsdatenDetailsDelegate += new PMDS.GUI.BewebungsdatenDetailsDelegate(this.ucBewerberAufnahme1_BewebungsdatenDetailsDelegate);
            // 
            // ultraTabPageControlBewerber
            // 
            this.ultraTabPageControlBewerber.Controls.Add(this.ucBewerber1);
            this.ultraTabPageControlBewerber.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControlBewerber.Name = "ultraTabPageControlBewerber";
            this.ultraTabPageControlBewerber.Size = new System.Drawing.Size(770, 454);
            // 
            // ucBewerber1
            // 
            this.ucBewerber1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBewerber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBewerber1.Location = new System.Drawing.Point(0, 0);
            this.ucBewerber1.Name = "ucBewerber1";
            this.ucBewerber1.Size = new System.Drawing.Size(770, 454);
            this.ucBewerber1.TabIndex = 0;
            this.ucBewerber1.PatientDetailsDelegate += new PMDS.GUI.PatientDetailsDelegate(this.PatientDetailsDelegate);
            this.ucBewerber1.PatientDeletedDelegate += new PMDS.GUI.PatientDeletedDelegate(this.ucBewerber1_PatientDeletedDelegate);
            this.ucBewerber1.BewerberstatusChangedDelegate += new PMDS.GUI.BewerberstatusChangedDelegate(this.ucBewerber1_BewerberstatusChangedDelegate);
            // 
            // tabBewerber
            // 
            appearance2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabBewerber.Appearance = appearance2;
            this.tabBewerber.Controls.Add(this.ultraTabSharedControlsPage3);
            this.tabBewerber.Controls.Add(this.ultraTabPageControlAufnahme);
            this.tabBewerber.Controls.Add(this.ultraTabPageControlBewerber);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.tabBewerber, gridBagConstraint1);
            this.tabBewerber.Location = new System.Drawing.Point(5, 5);
            this.tabBewerber.Name = "tabBewerber";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.tabBewerber, new System.Drawing.Size(784, 490));
            this.tabBewerber.SharedControlsPage = this.ultraTabSharedControlsPage3;
            this.tabBewerber.Size = new System.Drawing.Size(774, 480);
            this.tabBewerber.TabIndex = 2;
            ultraTab1.Key = "Aufnahme";
            ultraTab1.TabPage = this.ultraTabPageControlAufnahme;
            ultraTab1.Text = "Aufnahme";
            ultraTab2.Key = "Bewerberliste";
            ultraTab2.TabPage = this.ultraTabPageControlBewerber;
            ultraTab2.Text = "Bewerberliste";
            this.tabBewerber.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.tabBewerber.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.tabBewerber.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.tabBewerber_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage3
            // 
            this.ultraTabSharedControlsPage3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage3.Name = "ultraTabSharedControlsPage3";
            this.ultraTabSharedControlsPage3.Size = new System.Drawing.Size(770, 454);
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.tabBewerber);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(784, 490);
            this.ultraGridBagLayoutPanelAll.TabIndex = 3;
            // 
            // ucSiteMapBewerber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.Name = "ucSiteMapBewerber";
            this.Size = new System.Drawing.Size(784, 490);
            this.ultraTabPageControlAufnahme.ResumeLayout(false);
            this.ultraTabPageControlBewerber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabBewerber)).EndInit();
            this.tabBewerber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTabControl tabBewerber;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControlAufnahme;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControlBewerber;
        private ucBewerber ucBewerber1;
        private ucBewerberAufnahme ucBewerberAufnahme1;
        private QS2.Desktop.ControlManagment.BaseButton btnNext;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
    }
}
