namespace qs2.ui.pint
{
    partial class contQryRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contQryRun));
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reports");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAssignSubqueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ReportGroups");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Documents");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ReportGroups");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reports");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAssignSubqueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Documents");
            this.panelParAll = new System.Windows.Forms.Panel();
            this.panelParTop = new System.Windows.Forms.Panel();
            this.comboApplication1 = new qs2.sitemap.comboApplication();
            this.btnRefresh = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this._panelTopLeft_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.toolbarsManagerAdmin = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._panelTopLeft_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelTopLeft_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelTopLeft_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panelQueriesReports = new System.Windows.Forms.Panel();
            this.panelTabs2 = new System.Windows.Forms.Panel();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.dsAdmin1 = new qs2.core.vb.dsAdmin();
            this.sqlAdmin1 = new qs2.core.vb.sqlAdmin(this.components);
            this.panelParameters = new Infragistics.Win.Misc.UltraPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contQryRunPar1 = new qs2.ui.print.contQryRunPar();
            this.panelParAll.SuspendLayout();
            this.panelParTop.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManagerAdmin)).BeginInit();
            this.panelQueriesReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin1)).BeginInit();
            this.panelParameters.ClientArea.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelParAll
            // 
            this.panelParAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParAll.Controls.Add(this.contQryRunPar1);
            this.panelParAll.Controls.Add(this.panelParTop);
            this.panelParAll.Location = new System.Drawing.Point(10, 10);
            this.panelParAll.Name = "panelParAll";
            this.panelParAll.Size = new System.Drawing.Size(560, 730);
            this.panelParAll.TabIndex = 2;
            // 
            // panelParTop
            // 
            this.panelParTop.Controls.Add(this.comboApplication1);
            this.panelParTop.Controls.Add(this.btnRefresh);
            this.panelParTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParTop.Location = new System.Drawing.Point(0, 0);
            this.panelParTop.Name = "panelParTop";
            this.panelParTop.Size = new System.Drawing.Size(560, 29);
            this.panelParTop.TabIndex = 0;
            // 
            // comboApplication1
            // 
            this.comboApplication1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboApplication1.BackColor = System.Drawing.Color.Transparent;
            this.comboApplication1.Location = new System.Drawing.Point(324, 2);
            this.comboApplication1.Name = "comboApplication1";
            this.comboApplication1.OwnLabelVisible = false;
            this.comboApplication1.Size = new System.Drawing.Size(205, 22);
            this.comboApplication1.TabIndex = 23;
            this.comboApplication1.evOnChange += new qs2.sitemap.comboApplication.onChange(this.comboApplication1_evOnChange);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnRefresh.Appearance = appearance1;
            this.btnRefresh.Location = new System.Drawing.Point(531, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OwnAutoTextYN = false;
            this.btnRefresh.OwnPicture = QS2.Resources.getRes.Allgemein.ico_Aktualisieren;
            this.btnRefresh.OwnPictureTxt = "";
            this.btnRefresh.OwnSizeMode = qs2.core.Enums.eSize.small;
            this.btnRefresh.OwnTooltipText = "";
            this.btnRefresh.OwnTooltipTitle = null;
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Controls.Add(this._panelTopLeft_Toolbars_Dock_Area_Left);
            this.panelTopLeft.Controls.Add(this._panelTopLeft_Toolbars_Dock_Area_Right);
            this.panelTopLeft.Controls.Add(this._panelTopLeft_Toolbars_Dock_Area_Bottom);
            this.panelTopLeft.Controls.Add(this._panelTopLeft_Toolbars_Dock_Area_Top);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 725);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(622, 25);
            this.panelTopLeft.TabIndex = 4;
            // 
            // _panelTopLeft_Toolbars_Dock_Area_Left
            // 
            this._panelTopLeft_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelTopLeft_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._panelTopLeft_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panelTopLeft_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelTopLeft_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
            this._panelTopLeft_Toolbars_Dock_Area_Left.Name = "_panelTopLeft_Toolbars_Dock_Area_Left";
            this._panelTopLeft_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 0);
            this._panelTopLeft_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolbarsManagerAdmin;
            // 
            // toolbarsManagerAdmin
            // 
            this.toolbarsManagerAdmin.DesignerFlags = 1;
            this.toolbarsManagerAdmin.DockWithinContainer = this.panelTopLeft;
            this.toolbarsManagerAdmin.LockToolbars = true;
            this.toolbarsManagerAdmin.ShowFullMenusDelay = 500;
            this.toolbarsManagerAdmin.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(275, 241);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(124, 120);
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6,
            buttonTool4,
            buttonTool8,
            buttonTool3,
            buttonTool10});
            ultraToolbar1.Text = "UltraToolbar1";
            this.toolbarsManagerAdmin.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.toolbarsManagerAdmin.ToolbarSettings.Tag = "Queries";
            buttonTool1.SharedPropsInternal.Caption = "ReportGroups";
            buttonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool2.SharedPropsInternal.Caption = "Reports";
            buttonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedPropsInternal.Caption = "Manage Queries";
            buttonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedPropsInternal.Caption = "Assign Subqueries";
            buttonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool9.SharedPropsInternal.Caption = "Documents";
            buttonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            this.toolbarsManagerAdmin.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool5,
            buttonTool7,
            buttonTool9});
            this.toolbarsManagerAdmin.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.toolbarsManagerAdmin_ToolClick);
            // 
            // _panelTopLeft_Toolbars_Dock_Area_Right
            // 
            this._panelTopLeft_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelTopLeft_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent;
            this._panelTopLeft_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panelTopLeft_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelTopLeft_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(622, 25);
            this._panelTopLeft_Toolbars_Dock_Area_Right.Name = "_panelTopLeft_Toolbars_Dock_Area_Right";
            this._panelTopLeft_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._panelTopLeft_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolbarsManagerAdmin;
            // 
            // _panelTopLeft_Toolbars_Dock_Area_Bottom
            // 
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent;
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 25);
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.Name = "_panelTopLeft_Toolbars_Dock_Area_Bottom";
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(622, 0);
            this._panelTopLeft_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolbarsManagerAdmin;
            // 
            // _panelTopLeft_Toolbars_Dock_Area_Top
            // 
            this._panelTopLeft_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelTopLeft_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent;
            this._panelTopLeft_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panelTopLeft_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelTopLeft_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panelTopLeft_Toolbars_Dock_Area_Top.Name = "_panelTopLeft_Toolbars_Dock_Area_Top";
            this._panelTopLeft_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(622, 25);
            this._panelTopLeft_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolbarsManagerAdmin;
            // 
            // panelQueriesReports
            // 
            this.panelQueriesReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQueriesReports.BackColor = System.Drawing.Color.Transparent;
            this.panelQueriesReports.Controls.Add(this.splitContainer1);
            this.panelQueriesReports.Controls.Add(this.panelTopLeft);
            this.panelQueriesReports.Location = new System.Drawing.Point(0, 0);
            this.panelQueriesReports.Name = "panelQueriesReports";
            this.panelQueriesReports.Size = new System.Drawing.Size(622, 750);
            this.panelQueriesReports.TabIndex = 9;
            this.panelQueriesReports.Tag = "pnl_StayChapter_BackColor";
            // 
            // panelTabs2
            // 
            this.panelTabs2.BackColor = System.Drawing.Color.Transparent;
            this.panelTabs2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs2.Location = new System.Drawing.Point(0, 0);
            this.panelTabs2.Name = "panelTabs2";
            this.panelTabs2.Size = new System.Drawing.Size(622, 676);
            this.panelTabs2.TabIndex = 6;
            // 
            // panelGroups
            // 
            this.panelGroups.BackColor = System.Drawing.Color.Transparent;
            this.panelGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroups.Location = new System.Drawing.Point(0, 0);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(622, 39);
            this.panelGroups.TabIndex = 5;
            // 
            // dsAdmin1
            // 
            this.dsAdmin1.DataSetName = "dsAdmin";
            this.dsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // panelParameters.ClientArea
            // 
            this.panelParameters.ClientArea.Controls.Add(this.panelParAll);
            this.panelParameters.Location = new System.Drawing.Point(620, 0);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(580, 750);
            this.panelParameters.TabIndex = 10;
            this.panelParameters.Tag = "pnl_StayBackColor";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelGroups);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelTabs2);
            this.splitContainer1.Size = new System.Drawing.Size(622, 719);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 7;
            // 
            // contQryRunPar1
            // 
            this.contQryRunPar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contQryRunPar1.Location = new System.Drawing.Point(0, 29);
            this.contQryRunPar1.Name = "contQryRunPar1";
            this.contQryRunPar1.Size = new System.Drawing.Size(560, 701);
            this.contQryRunPar1.TabIndex = 0;
            // 
            // contQryRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.panelQueriesReports);
            this.Name = "contQryRun";
            this.Size = new System.Drawing.Size(1200, 750);
            this.Load += new System.EventHandler(this.contQueryRun_Load);
            this.VisibleChanged += new System.EventHandler(this.contQryRun_VisibleChanged);
            this.Resize += new System.EventHandler(this.contQryRun_Resize);
            this.panelParAll.ResumeLayout(false);
            this.panelParTop.ResumeLayout(false);
            this.panelTopLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManagerAdmin)).EndInit();
            this.panelQueriesReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin1)).EndInit();
            this.panelParameters.ClientArea.ResumeLayout(false);
            this.panelParameters.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelParAll;
        private System.Windows.Forms.Panel panelParTop;
        private core.vb.dsAdmin dsAdmin1;
        private core.vb.sqlAdmin sqlAdmin1;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnRefresh;
        private System.Windows.Forms.Panel panelTopLeft;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelTopLeft_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager toolbarsManagerAdmin;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelTopLeft_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelTopLeft_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelTopLeft_Toolbars_Dock_Area_Bottom;
        private sitemap.comboApplication comboApplication1;
        private System.Windows.Forms.Panel panelQueriesReports;
        public print.contQryRunPar contQryRunPar1;
        private Infragistics.Win.Misc.UltraPanel panelParameters;
        private System.Windows.Forms.Panel panelTabs2;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
