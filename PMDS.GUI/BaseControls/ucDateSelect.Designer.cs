namespace PMDS.GUI
{
    partial class ucDateSelect
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAUswahlZeit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAUswahlZeit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttJetzt");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttVorEinerStunde");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttJetzt");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDateSelect));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttVorEinerStunde");
            this.uButtAuswahlZeit = new Infragistics.Win.Misc.UltraDropDownButton();
            this._ucDateSelect_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ucDateSelect_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucDateSelect_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucDateSelect_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // uButtAuswahlZeit
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButtAuswahlZeit.Appearance = appearance1;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            this.ultraGridBagLayoutManager1.SetGridBagConstraint(this.uButtAuswahlZeit, gridBagConstraint1);
            this.uButtAuswahlZeit.Location = new System.Drawing.Point(0, 0);
            this.uButtAuswahlZeit.Name = "uButtAuswahlZeit";
            this.ultraGridBagLayoutManager1.SetPreferredSize(this.uButtAuswahlZeit, new System.Drawing.Size(35, 22));
            this.uButtAuswahlZeit.Size = new System.Drawing.Size(68, 54);
            this.uButtAuswahlZeit.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uButtAuswahlZeit.TabIndex = 0;
            this.uButtAuswahlZeit.Click += new System.EventHandler(this.uButtAuswahlZeit_Click);
            // 
            // _ucDateSelect_Toolbars_Dock_Area_Left
            // 
            this._ucDateSelect_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucDateSelect_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ucDateSelect_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ucDateSelect_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucDateSelect_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 21);
            this._ucDateSelect_Toolbars_Dock_Area_Left.Name = "_ucDateSelect_Toolbars_Dock_Area_Left";
            this._ucDateSelect_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 33);
            this._ucDateSelect_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool1.SharedPropsInternal.Caption = "Auswahl Zeit";
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool5});
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            buttonTool1.SharedPropsInternal.AppearancesLarge.Appearance = appearance2;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            buttonTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance3;
            buttonTool1.SharedPropsInternal.Caption = "Jetzt";
            buttonTool3.SharedPropsInternal.Caption = "Vor einer Stunde";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            buttonTool1,
            buttonTool3});
            this.ultraToolbarsManager1.Visible = false;
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _ucDateSelect_Toolbars_Dock_Area_Right
            // 
            this._ucDateSelect_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucDateSelect_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ucDateSelect_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ucDateSelect_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucDateSelect_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(68, 21);
            this._ucDateSelect_Toolbars_Dock_Area_Right.Name = "_ucDateSelect_Toolbars_Dock_Area_Right";
            this._ucDateSelect_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 33);
            this._ucDateSelect_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucDateSelect_Toolbars_Dock_Area_Top
            // 
            this._ucDateSelect_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucDateSelect_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ucDateSelect_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ucDateSelect_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucDateSelect_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ucDateSelect_Toolbars_Dock_Area_Top.Name = "_ucDateSelect_Toolbars_Dock_Area_Top";
            this._ucDateSelect_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(68, 21);
            this._ucDateSelect_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucDateSelect_Toolbars_Dock_Area_Bottom
            // 
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 54);
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.Name = "_ucDateSelect_Toolbars_Dock_Area_Bottom";
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(68, 0);
            this._ucDateSelect_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraGridBagLayoutManager1
            // 
            this.ultraGridBagLayoutManager1.ContainerControl = this;
            this.ultraGridBagLayoutManager1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutManager1.ExpandToFitWidth = true;
            // 
            // ucDateSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uButtAuswahlZeit);
            this.Controls.Add(this._ucDateSelect_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ucDateSelect_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ucDateSelect_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._ucDateSelect_Toolbars_Dock_Area_Top);
            this.Name = "ucDateSelect";
            this.Size = new System.Drawing.Size(68, 54);
            this.Load += new System.EventHandler(this.ucDateSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton uButtAuswahlZeit;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucDateSelect_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucDateSelect_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucDateSelect_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucDateSelect_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
    }
}
