namespace PMDS.GUI.BaseControls
{
    partial class AuswahlGruppeComboMulti
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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popGruppen");
            this.dropDownGruppe = new Infragistics.Win.Misc.UltraDropDownButton();
            this.panelTree = new System.Windows.Forms.Panel();
            this.panelTree_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.treeGruppe = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelToolbar_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._panelToolbar_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.AuswahlGruppeComboMulti_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.panelTree.SuspendLayout();
            this.panelTree_Fill_Panel.ClientArea.SuspendLayout();
            this.panelTree_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panelToolbar_Fill_Panel.SuspendLayout();
            this.AuswahlGruppeComboMulti_Fill_Panel.ClientArea.SuspendLayout();
            this.AuswahlGruppeComboMulti_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropDownGruppe
            // 
            this.dropDownGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.dropDownGruppe.Appearance = appearance1;
            this.dropDownGruppe.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownGruppe.Location = new System.Drawing.Point(0, 0);
            this.dropDownGruppe.Name = "dropDownGruppe";
            this.dropDownGruppe.Size = new System.Drawing.Size(349, 22);
            this.dropDownGruppe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownGruppe.TabIndex = 0;
            // 
            // panelTree
            // 
            this.panelTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTree.Controls.Add(this.panelTree_Fill_Panel);
            this.panelTree.Location = new System.Drawing.Point(3, 26);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(346, 224);
            this.panelTree.TabIndex = 1;
            // 
            // panelTree_Fill_Panel
            // 
            // 
            // panelTree_Fill_Panel.ClientArea
            // 
            this.panelTree_Fill_Panel.ClientArea.Controls.Add(this.treeGruppe);
            this.panelTree_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTree_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.panelTree_Fill_Panel.Name = "panelTree_Fill_Panel";
            this.panelTree_Fill_Panel.Size = new System.Drawing.Size(346, 224);
            this.panelTree_Fill_Panel.TabIndex = 0;
            // 
            // treeGruppe
            // 
            this.treeGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGruppe.Location = new System.Drawing.Point(3, 3);
            this.treeGruppe.Name = "treeGruppe";
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            this.treeGruppe.Override = _override1;
            this.treeGruppe.Size = new System.Drawing.Size(340, 218);
            this.treeGruppe.TabIndex = 0;
            this.treeGruppe.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.treeGruppe_AfterCheck);
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this.panelToolbar;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupControlContainerTool1.ControlName = "panelTree";
            popupControlContainerTool1.SharedPropsInternal.Caption = "PopupControlContainerTool1";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupControlContainerTool1});
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.panelToolbar_Fill_Panel);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Left);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Right);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Bottom);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Top);
            this.panelToolbar.Location = new System.Drawing.Point(30, 268);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(183, 44);
            this.panelToolbar.TabIndex = 2;
            // 
            // panelToolbar_Fill_Panel
            // 
            this.panelToolbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelToolbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolbar_Fill_Panel.Location = new System.Drawing.Point(0, 17);
            this.panelToolbar_Fill_Panel.Name = "panelToolbar_Fill_Panel";
            this.panelToolbar_Fill_Panel.Size = new System.Drawing.Size(183, 27);
            this.panelToolbar_Fill_Panel.TabIndex = 0;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Left
            // 
            this._panelToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panelToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 17);
            this._panelToolbar_Toolbars_Dock_Area_Left.Name = "_panelToolbar_Toolbars_Dock_Area_Left";
            this._panelToolbar_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 27);
            this._panelToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Right
            // 
            this._panelToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panelToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(183, 17);
            this._panelToolbar_Toolbars_Dock_Area_Right.Name = "_panelToolbar_Toolbars_Dock_Area_Right";
            this._panelToolbar_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 27);
            this._panelToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Bottom
            // 
            this._panelToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 44);
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Name = "_panelToolbar_Toolbars_Dock_Area_Bottom";
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(183, 0);
            this._panelToolbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Top
            // 
            this._panelToolbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panelToolbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panelToolbar_Toolbars_Dock_Area_Top.Name = "_panelToolbar_Toolbars_Dock_Area_Top";
            this._panelToolbar_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(183, 17);
            this._panelToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // AuswahlGruppeComboMulti_Fill_Panel
            // 
            // 
            // AuswahlGruppeComboMulti_Fill_Panel.ClientArea
            // 
            this.AuswahlGruppeComboMulti_Fill_Panel.ClientArea.Controls.Add(this.panelToolbar);
            this.AuswahlGruppeComboMulti_Fill_Panel.ClientArea.Controls.Add(this.panelTree);
            this.AuswahlGruppeComboMulti_Fill_Panel.ClientArea.Controls.Add(this.dropDownGruppe);
            this.AuswahlGruppeComboMulti_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AuswahlGruppeComboMulti_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuswahlGruppeComboMulti_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.AuswahlGruppeComboMulti_Fill_Panel.Name = "AuswahlGruppeComboMulti_Fill_Panel";
            this.AuswahlGruppeComboMulti_Fill_Panel.Size = new System.Drawing.Size(349, 331);
            this.AuswahlGruppeComboMulti_Fill_Panel.TabIndex = 0;
            // 
            // AuswahlGruppeComboMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AuswahlGruppeComboMulti_Fill_Panel);
            this.Name = "AuswahlGruppeComboMulti";
            this.Size = new System.Drawing.Size(349, 331);
            this.Load += new System.EventHandler(this.AuswahlGruppeComboMulti_Load);
            this.panelTree.ResumeLayout(false);
            this.panelTree_Fill_Panel.ClientArea.ResumeLayout(false);
            this.panelTree_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar_Fill_Panel.ResumeLayout(false);
            this.AuswahlGruppeComboMulti_Fill_Panel.ClientArea.ResumeLayout(false);
            this.AuswahlGruppeComboMulti_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton dropDownGruppe;
        private System.Windows.Forms.Panel panelTree;
        private Infragistics.Win.UltraWinTree.UltraTree treeGruppe;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.Misc.UltraPanel AuswahlGruppeComboMulti_Fill_Panel;
        private Infragistics.Win.Misc.UltraPanel panelTree_Fill_Panel;
        private System.Windows.Forms.Panel panelToolbar;
        private Infragistics.Win.Misc.UltraPanel panelToolbar_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Top;
    }
}
