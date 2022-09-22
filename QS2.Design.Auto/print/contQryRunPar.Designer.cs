namespace qs2.ui.print
{
    partial class contQryRunPar
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpService");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpService");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageQueries");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInfoQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("openReportDirectory");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInfoQueries");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("openReportDirectory");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelService = new System.Windows.Forms.Panel();
            this.panelService_Fill_Panel = new System.Windows.Forms.Panel();
            this._panelService_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._panelService_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelService_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelService_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.contSelListQueries1 = new qs2.ui.print.contSelListQueries();
            this.menuStripManageQuerySubSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manageQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblQuerySub = new Infragistics.Win.Misc.UltraLabel();
            this.btnRunReport = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.contextMenuStripButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openResultsInTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSqlCommandForCommandLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlAdmin1 = new qs2.core.vb.sqlAdmin(this.components);
            this.panelParameters = new System.Windows.Forms.Panel();
            this.grpQueryParameter = new Infragistics.Win.Misc.UltraGroupBox();
            this.panelBottom.SuspendLayout();
            this.panelService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.menuStripManageQuerySubSelect.SuspendLayout();
            this.contextMenuStripButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpQueryParameter)).BeginInit();
            this.grpQueryParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.panelService);
            this.panelBottom.Controls.Add(this.contSelListQueries1);
            this.panelBottom.Controls.Add(this.lblQuerySub);
            this.panelBottom.Controls.Add(this.btnRunReport);
            this.panelBottom.Location = new System.Drawing.Point(10, 525);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(540, 64);
            this.panelBottom.TabIndex = 2;
            // 
            // panelService
            // 
            this.panelService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelService.Controls.Add(this.panelService_Fill_Panel);
            this.panelService.Controls.Add(this._panelService_Toolbars_Dock_Area_Left);
            this.panelService.Controls.Add(this._panelService_Toolbars_Dock_Area_Right);
            this.panelService.Controls.Add(this._panelService_Toolbars_Dock_Area_Bottom);
            this.panelService.Controls.Add(this._panelService_Toolbars_Dock_Area_Top);
            this.panelService.Location = new System.Drawing.Point(6, 33);
            this.panelService.Name = "panelService";
            this.panelService.Size = new System.Drawing.Size(77, 19);
            this.panelService.TabIndex = 0;
            // 
            // panelService_Fill_Panel
            // 
            this.panelService_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelService_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelService_Fill_Panel.Location = new System.Drawing.Point(0, 21);
            this.panelService_Fill_Panel.Name = "panelService_Fill_Panel";
            this.panelService_Fill_Panel.Size = new System.Drawing.Size(77, 0);
            this.panelService_Fill_Panel.TabIndex = 0;
            // 
            // _panelService_Toolbars_Dock_Area_Left
            // 
            this._panelService_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelService_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._panelService_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panelService_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelService_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 21);
            this._panelService_Toolbars_Dock_Area_Left.Name = "_panelService_Toolbars_Dock_Area_Left";
            this._panelService_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 0);
            this._panelService_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            this._panelService_Toolbars_Dock_Area_Left.UseAppStyling = false;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this.panelService;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3});
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool2.SharedPropsInternal.Caption = "Service";
            popupMenuTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            popupMenuTool5,
            buttonTool6,
            buttonTool5});
            buttonTool3.SharedPropsInternal.Caption = "InfoQueries";
            buttonTool3.SharedPropsInternal.Visible = false;
            popupMenuTool4.SharedPropsInternal.Caption = "Queries";
            buttonTool1.SharedPropsInternal.Caption = "ManageQueries";
            buttonTool4.SharedPropsInternal.Caption = "openReportExplorer";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2,
            buttonTool3,
            popupMenuTool4,
            buttonTool1,
            buttonTool4});
            this.ultraToolbarsManager1.UseAppStyling = false;
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _panelService_Toolbars_Dock_Area_Right
            // 
            this._panelService_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelService_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._panelService_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panelService_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelService_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(77, 21);
            this._panelService_Toolbars_Dock_Area_Right.Name = "_panelService_Toolbars_Dock_Area_Right";
            this._panelService_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._panelService_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            this._panelService_Toolbars_Dock_Area_Right.UseAppStyling = false;
            // 
            // _panelService_Toolbars_Dock_Area_Bottom
            // 
            this._panelService_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelService_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._panelService_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panelService_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelService_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 19);
            this._panelService_Toolbars_Dock_Area_Bottom.Name = "_panelService_Toolbars_Dock_Area_Bottom";
            this._panelService_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(77, 0);
            this._panelService_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            this._panelService_Toolbars_Dock_Area_Bottom.UseAppStyling = false;
            // 
            // _panelService_Toolbars_Dock_Area_Top
            // 
            this._panelService_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelService_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._panelService_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panelService_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelService_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panelService_Toolbars_Dock_Area_Top.Name = "_panelService_Toolbars_Dock_Area_Top";
            this._panelService_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(77, 21);
            this._panelService_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            this._panelService_Toolbars_Dock_Area_Top.UseAppStyling = false;
            // 
            // contSelListQueries1
            // 
            this.contSelListQueries1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contSelListQueries1.BackColor = System.Drawing.Color.Transparent;
            this.contSelListQueries1.ContextMenuStrip = this.menuStripManageQuerySubSelect;
            this.contSelListQueries1.Location = new System.Drawing.Point(122, 10);
            this.contSelListQueries1.Name = "contSelListQueries1";
            this.contSelListQueries1.Size = new System.Drawing.Size(283, 24);
            this.contSelListQueries1.TabIndex = 36;
            // 
            // menuStripManageQuerySubSelect
            // 
            this.menuStripManageQuerySubSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageQueryToolStripMenuItem});
            this.menuStripManageQuerySubSelect.Name = "contextMenuStrip1";
            this.menuStripManageQuerySubSelect.Size = new System.Drawing.Size(150, 26);
            // 
            // manageQueryToolStripMenuItem
            // 
            this.manageQueryToolStripMenuItem.Name = "manageQueryToolStripMenuItem";
            this.manageQueryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.manageQueryToolStripMenuItem.Text = "ManageQuery";
            this.manageQueryToolStripMenuItem.Click += new System.EventHandler(this.manageQueryToolStripMenuItem_Click);
            // 
            // lblQuerySub
            // 
            this.lblQuerySub.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQuerySub.Location = new System.Drawing.Point(6, 10);
            this.lblQuerySub.Name = "lblQuerySub";
            this.lblQuerySub.Size = new System.Drawing.Size(110, 24);
            this.lblQuerySub.TabIndex = 35;
            this.lblQuerySub.Text = "QuerySub";
            // 
            // btnRunReport
            // 
            this.btnRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnRunReport.Appearance = appearance1;
            this.btnRunReport.ContextMenuStrip = this.contextMenuStripButton;
            this.btnRunReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRunReport.Location = new System.Drawing.Point(408, 7);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.OwnAutoTextYN = false;
            this.btnRunReport.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnRunReport.OwnPictureTxt = "";
            this.btnRunReport.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnRunReport.OwnTooltipText = "";
            this.btnRunReport.OwnTooltipTitle = null;
            this.btnRunReport.Size = new System.Drawing.Size(128, 28);
            this.btnRunReport.TabIndex = 16;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // contextMenuStripButton
            // 
            this.contextMenuStripButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem,
            this.openResultsInTableToolStripMenuItem,
            this.generateSqlCommandForCommandLineToolStripMenuItem});
            this.contextMenuStripButton.Name = "contextMenuStripButton";
            this.contextMenuStripButton.Size = new System.Drawing.Size(291, 70);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // openResultsInTableToolStripMenuItem
            // 
            this.openResultsInTableToolStripMenuItem.Name = "openResultsInTableToolStripMenuItem";
            this.openResultsInTableToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.openResultsInTableToolStripMenuItem.Text = "OpenResultsInTable";
            // 
            // generateSqlCommandForCommandLineToolStripMenuItem
            // 
            this.generateSqlCommandForCommandLineToolStripMenuItem.Name = "generateSqlCommandForCommandLineToolStripMenuItem";
            this.generateSqlCommandForCommandLineToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.generateSqlCommandForCommandLineToolStripMenuItem.Text = "GenerateSqlCommandForCommandLine";
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.BackColor = System.Drawing.Color.Transparent;
            this.panelParameters.Location = new System.Drawing.Point(10, 21);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(540, 499);
            this.panelParameters.TabIndex = 9;
            this.panelParameters.VisibleChanged += new System.EventHandler(this.panelParameters_VisibleChanged);
            // 
            // grpQueryParameter
            // 
            this.grpQueryParameter.Controls.Add(this.panelParameters);
            this.grpQueryParameter.Controls.Add(this.panelBottom);
            this.grpQueryParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQueryParameter.Location = new System.Drawing.Point(0, 0);
            this.grpQueryParameter.Name = "grpQueryParameter";
            this.grpQueryParameter.Size = new System.Drawing.Size(560, 600);
            this.grpQueryParameter.TabIndex = 10;
            // 
            // contQryRunPar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpQueryParameter);
            this.Name = "contQryRunPar";
            this.Size = new System.Drawing.Size(560, 600);
            this.Load += new System.EventHandler(this.contQryRunPar_Load);
            this.VisibleChanged += new System.EventHandler(this.contQryRunPar_VisibleChanged);
            this.panelBottom.ResumeLayout(false);
            this.panelService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.menuStripManageQuerySubSelect.ResumeLayout(false);
            this.contextMenuStripButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpQueryParameter)).EndInit();
            this.grpQueryParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private sitemap.ownControls.inherit_Infrag.InfragButton btnRunReport;
        private System.Windows.Forms.Panel panelService;
        private System.Windows.Forms.Panel panelService_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelService_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelService_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelService_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelService_Toolbars_Dock_Area_Bottom;
        public Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.Misc.UltraLabel lblQuerySub;
        private qs2.core.vb.sqlAdmin sqlAdmin1;
        private System.Windows.Forms.ContextMenuStrip menuStripManageQuerySubSelect;
        private System.Windows.Forms.ToolStripMenuItem manageQueryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripButton;
        private System.Windows.Forms.ToolStripMenuItem openResultsInTableToolStripMenuItem;
        public contSelListQueries contSelListQueries1;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSqlCommandForCommandLineToolStripMenuItem;
        public System.Windows.Forms.Panel panelParameters;
        public Infragistics.Win.Misc.UltraGroupBox grpQueryParameter;
        public System.Windows.Forms.Panel panelBottom;
    }
}
