namespace qs2.design.auto.workflowAssist.assist
{
    partial class contListElementDropDown
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool2 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("PopupControlContainerToolElement");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("PopupControlContainerToolElement");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contListElementDropDown));
            this.dropDownElementBottom = new Infragistics.Win.Misc.UltraDropDownButton();
            this.toolBarDropDown = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.panelToolbar = new System.Windows.Forms.Panel();
            this._panelToolbar_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.contListElementDropDown_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.panelDropDown = new System.Windows.Forms.Panel();
            this.panelSelListObj = new System.Windows.Forms.Panel();
            this.contSelListsObj1 = new qs2.sitemap.vb.contSelListsObj();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.toolBarDropDown)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.contListElementDropDown_Fill_Panel.ClientArea.SuspendLayout();
            this.contListElementDropDown_Fill_Panel.SuspendLayout();
            this.panelDropDown.SuspendLayout();
            this.panelSelListObj.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropDownElementBottom
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.dropDownElementBottom.Appearance = appearance1;
            this.dropDownElementBottom.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless;
            this.dropDownElementBottom.Location = new System.Drawing.Point(1, 1);
            this.dropDownElementBottom.Name = "dropDownElementBottom";
            this.dropDownElementBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dropDownElementBottom.ShowOutline = false;
            this.dropDownElementBottom.Size = new System.Drawing.Size(31, 15);
            this.dropDownElementBottom.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownElementBottom.TabIndex = 31;
            this.dropDownElementBottom.UseAppStyling = false;
            this.dropDownElementBottom.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.dropDownElementBottom.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dropDownElementBottom.Click += new System.EventHandler(this.dropDownElementBottom_Click);
            this.dropDownElementBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dropDownElementBottom_MouseUp);
            // 
            // toolBarDropDown
            // 
            this.toolBarDropDown.DesignerFlags = 1;
            this.toolBarDropDown.DockWithinContainer = this.panelToolbar;
            this.toolBarDropDown.LockToolbars = true;
            this.toolBarDropDown.ShowFullMenusDelay = 500;
            this.toolBarDropDown.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupControlContainerTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            this.toolBarDropDown.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupControlContainerTool1.ControlName = "panelDropDown";
            popupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.toolBarDropDown.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupControlContainerTool1});
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Left);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Right);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Bottom);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Top);
            this.panelToolbar.Location = new System.Drawing.Point(15, 289);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(64, 22);
            this.panelToolbar.TabIndex = 32;
            this.panelToolbar.Visible = false;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Left
            // 
            this._panelToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panelToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 23);
            this._panelToolbar_Toolbars_Dock_Area_Left.Name = "_panelToolbar_Toolbars_Dock_Area_Left";
            this._panelToolbar_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 0);
            this._panelToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolBarDropDown;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Right
            // 
            this._panelToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panelToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(64, 23);
            this._panelToolbar_Toolbars_Dock_Area_Right.Name = "_panelToolbar_Toolbars_Dock_Area_Right";
            this._panelToolbar_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._panelToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolBarDropDown;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Bottom
            // 
            this._panelToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 22);
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Name = "_panelToolbar_Toolbars_Dock_Area_Bottom";
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(64, 0);
            this._panelToolbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolBarDropDown;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Top
            // 
            this._panelToolbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panelToolbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panelToolbar_Toolbars_Dock_Area_Top.Name = "_panelToolbar_Toolbars_Dock_Area_Top";
            this._panelToolbar_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(64, 23);
            this._panelToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolBarDropDown;
            // 
            // contListElementDropDown_Fill_Panel
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.contListElementDropDown_Fill_Panel.Appearance = appearance2;
            // 
            // contListElementDropDown_Fill_Panel.ClientArea
            // 
            this.contListElementDropDown_Fill_Panel.ClientArea.Controls.Add(this.panelDropDown);
            this.contListElementDropDown_Fill_Panel.ClientArea.Controls.Add(this.panelToolbar);
            this.contListElementDropDown_Fill_Panel.ClientArea.Controls.Add(this.dropDownElementBottom);
            this.contListElementDropDown_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.contListElementDropDown_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contListElementDropDown_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.contListElementDropDown_Fill_Panel.Name = "contListElementDropDown_Fill_Panel";
            this.contListElementDropDown_Fill_Panel.Size = new System.Drawing.Size(845, 415);
            this.contListElementDropDown_Fill_Panel.TabIndex = 40;
            // 
            // panelDropDown
            // 
            this.panelDropDown.BackColor = System.Drawing.Color.Transparent;
            this.panelDropDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDropDown.Controls.Add(this.panelSelListObj);
            this.panelDropDown.Controls.Add(this.panelTop);
            this.panelDropDown.Controls.Add(this.panelBottom);
            this.panelDropDown.Location = new System.Drawing.Point(206, 33);
            this.panelDropDown.Name = "panelDropDown";
            this.panelDropDown.Size = new System.Drawing.Size(630, 278);
            this.panelDropDown.TabIndex = 33;
            // 
            // panelSelListObj
            // 
            this.panelSelListObj.BackColor = System.Drawing.Color.Transparent;
            this.panelSelListObj.Controls.Add(this.contSelListsObj1);
            this.panelSelListObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelListObj.Location = new System.Drawing.Point(0, 22);
            this.panelSelListObj.Name = "panelSelListObj";
            this.panelSelListObj.Size = new System.Drawing.Size(628, 232);
            this.panelSelListObj.TabIndex = 5;
            // 
            // contSelListsObj1
            // 
            this.contSelListsObj1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contSelListsObj1.BackColor = System.Drawing.Color.White;
            this.contSelListsObj1.Location = new System.Drawing.Point(-1, 2);
            this.contSelListsObj1.Name = "contSelListsObj1";
            this.contSelListsObj1.Size = new System.Drawing.Size(630, 227);
            this.contSelListsObj1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(628, 22);
            this.panelTop.TabIndex = 4;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 254);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(628, 22);
            this.panelBottom.TabIndex = 2;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // contListElementDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.contListElementDropDown_Fill_Panel);
            this.Name = "contListElementDropDown";
            this.Size = new System.Drawing.Size(845, 415);
            ((System.ComponentModel.ISupportInitialize)(this.toolBarDropDown)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.contListElementDropDown_Fill_Panel.ClientArea.ResumeLayout(false);
            this.contListElementDropDown_Fill_Panel.ResumeLayout(false);
            this.panelDropDown.ResumeLayout(false);
            this.panelSelListObj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.Misc.UltraDropDownButton dropDownElementBottom;
        internal Infragistics.Win.UltraWinToolbars.UltraToolbarsManager toolBarDropDown;
        private System.Windows.Forms.Panel panelToolbar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Top;
        private System.Windows.Forms.Panel panelDropDown;
        private System.Windows.Forms.Panel panelSelListObj;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public sitemap.vb.contSelListsObj contSelListsObj1;
        public Infragistics.Win.Misc.UltraPanel contListElementDropDown_Fill_Panel;
    }
}
