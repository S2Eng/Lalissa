namespace qs2.ui.print
{
    partial class contQryCrystRepViewer
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelViewer = new System.Windows.Forms.Panel();
            this.gridBagLayoutPanelViewer = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelReportViewer = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblProtocol = new Infragistics.Win.Misc.UltraLabel();
            this.btnClose = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openGeneratedSqlStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBagLayoutPanelViewer)).BeginInit();
            this.gridBagLayoutPanelViewer.SuspendLayout();
            this.panelReportViewer.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelViewer);
            this.ultraTabPageControl1.Controls.Add(this.panelBottom);
            this.ultraTabPageControl1.Controls.Add(this.panelTop);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(632, 471);
            // 
            // panelViewer
            // 
            this.panelViewer.Controls.Add(this.gridBagLayoutPanelViewer);
            this.panelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewer.Location = new System.Drawing.Point(0, 38);
            this.panelViewer.Name = "panelViewer";
            this.panelViewer.Size = new System.Drawing.Size(632, 400);
            this.panelViewer.TabIndex = 2;
            // 
            // gridBagLayoutPanelViewer
            // 
            this.gridBagLayoutPanelViewer.Controls.Add(this.panelReportViewer);
            this.gridBagLayoutPanelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBagLayoutPanelViewer.ExpandToFitHeight = true;
            this.gridBagLayoutPanelViewer.ExpandToFitWidth = true;
            this.gridBagLayoutPanelViewer.Location = new System.Drawing.Point(0, 0);
            this.gridBagLayoutPanelViewer.Name = "gridBagLayoutPanelViewer";
            this.gridBagLayoutPanelViewer.Size = new System.Drawing.Size(632, 400);
            this.gridBagLayoutPanelViewer.TabIndex = 1;
            // 
            // panelReportViewer
            // 
            this.panelReportViewer.BackColor = System.Drawing.Color.White;
            this.panelReportViewer.Controls.Add(this.crystalReportViewer1);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.gridBagLayoutPanelViewer.SetGridBagConstraint(this.panelReportViewer, gridBagConstraint1);
            this.panelReportViewer.Location = new System.Drawing.Point(0, 0);
            this.panelReportViewer.Name = "panelReportViewer";
            this.gridBagLayoutPanelViewer.SetPreferredSize(this.panelReportViewer, new System.Drawing.Size(632, 400));
            this.panelReportViewer.Size = new System.Drawing.Size(632, 400);
            this.panelReportViewer.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.CachedPageNumberPerDoc = 10;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(632, 400);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblProtocol);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 438);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(632, 33);
            this.panelBottom.TabIndex = 1;
            // 
            // lblProtocol
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Red;
            this.lblProtocol.Appearance = appearance1;
            this.lblProtocol.AutoSize = true;
            appearance2.FontData.UnderlineAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblProtocol.HotTrackAppearance = appearance2;
            this.lblProtocol.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProtocol.Location = new System.Drawing.Point(11, 9);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(42, 17);
            this.lblProtocol.TabIndex = 244;
            this.lblProtocol.Text = "Errors";
            this.lblProtocol.UseAppStyling = false;
            this.lblProtocol.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblProtocol.Visible = false;
            this.lblProtocol.Click += new System.EventHandler(this.lblProtocol_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance3;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(531, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.OwnAutoTextYN = false;
            this.btnClose.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnClose.OwnPictureTxt = "";
            this.btnClose.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnClose.OwnTooltipText = "";
            this.btnClose.OwnTooltipTitle = null;
            this.btnClose.Size = new System.Drawing.Size(88, 25);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(632, 38);
            this.panelTop.TabIndex = 0;
            this.panelTop.Visible = false;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(636, 497);
            this.ultraTabControl1.TabIndex = 2;
            ultraTab1.Key = "Viewer";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Viewer";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(632, 471);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGeneratedSqlStatementToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 26);
            // 
            // openGeneratedSqlStatementToolStripMenuItem
            // 
            this.openGeneratedSqlStatementToolStripMenuItem.Name = "openGeneratedSqlStatementToolStripMenuItem";
            this.openGeneratedSqlStatementToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.openGeneratedSqlStatementToolStripMenuItem.Text = "Open generated Sql-Statement";
            this.openGeneratedSqlStatementToolStripMenuItem.Click += new System.EventHandler(this.openGeneratedSqlStatementToolStripMenuItem_Click);
            // 
            // contQryCrystRepViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "contQryCrystRepViewer";
            this.Size = new System.Drawing.Size(636, 497);
            this.Load += new System.EventHandler(this.contQryCrystRepViewer_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBagLayoutPanelViewer)).EndInit();
            this.gridBagLayoutPanelViewer.ResumeLayout(false);
            this.panelReportViewer.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnClose;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel panelViewer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openGeneratedSqlStatementToolStripMenuItem;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel gridBagLayoutPanelViewer;
        private System.Windows.Forms.Panel panelReportViewer;
        public Infragistics.Win.Misc.UltraLabel lblProtocol;
    }
}
