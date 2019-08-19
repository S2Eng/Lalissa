namespace PMDS.GUI.Klient
{
    partial class cboAuswahllisteMulti
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
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popSelList");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AuswahlListe", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAuswahlListeGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IstGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GehörtzuGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Hierarche");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Unterdruecken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuswahlListeGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Benutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Benutzer", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelToolbar2 = new Infragistics.Win.Misc.UltraPanel();
            this._panelToolbar_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panelToolbar_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panelControl = new System.Windows.Forms.Panel();
            this.gridAuswahllisten = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.auswahlListeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dropDownSelList = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panelToolbar2.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuswahllisten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlListeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.SuspendLayout();
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
            popupControlContainerTool1.ControlName = "panelControl";
            popupControlContainerTool1.SharedPropsInternal.Caption = "PopupControlContainerTool1";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupControlContainerTool1});
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.Transparent;
            this.panelToolbar.Controls.Add(this.panelToolbar2);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Left);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Right);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Bottom);
            this.panelToolbar.Controls.Add(this._panelToolbar_Toolbars_Dock_Area_Top);
            this.panelToolbar.Location = new System.Drawing.Point(17, 343);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(239, 46);
            this.panelToolbar.TabIndex = 12;
            // 
            // panelToolbar2
            // 
            this.panelToolbar2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelToolbar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolbar2.Location = new System.Drawing.Point(0, 17);
            this.panelToolbar2.Name = "panelToolbar2";
            this.panelToolbar2.Size = new System.Drawing.Size(239, 29);
            this.panelToolbar2.TabIndex = 0;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Left
            // 
            this._panelToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panelToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 17);
            this._panelToolbar_Toolbars_Dock_Area_Left.Name = "_panelToolbar_Toolbars_Dock_Area_Left";
            this._panelToolbar_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 29);
            this._panelToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Right
            // 
            this._panelToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panelToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(239, 17);
            this._panelToolbar_Toolbars_Dock_Area_Right.Name = "_panelToolbar_Toolbars_Dock_Area_Right";
            this._panelToolbar_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 29);
            this._panelToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _panelToolbar_Toolbars_Dock_Area_Bottom
            // 
            this._panelToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 46);
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Name = "_panelToolbar_Toolbars_Dock_Area_Bottom";
            this._panelToolbar_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(239, 0);
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
            this._panelToolbar_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(239, 17);
            this._panelToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.Transparent;
            this.panelControl.Controls.Add(this.gridAuswahllisten);
            this.panelControl.Location = new System.Drawing.Point(17, 51);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(418, 225);
            this.panelControl.TabIndex = 2;
            // 
            // gridAuswahllisten
            // 
            this.gridAuswahllisten.DataSource = this.auswahlListeBindingSource;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 1;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 2;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 3;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 4;
            ultraGridColumn17.Width = 280;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 5;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 6;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 7;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 8;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 9;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 10;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 11;
            ultraGridColumn24.DataType = typeof(bool);
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 0;
            ultraGridColumn24.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn24.Width = 80;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn1,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn25.Width = 61;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26});
            ultraGridBand2.Hidden = true;
            this.gridAuswahllisten.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridAuswahllisten.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridAuswahllisten.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridAuswahllisten.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridAuswahllisten.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridAuswahllisten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuswahllisten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAuswahllisten.Location = new System.Drawing.Point(0, 0);
            this.gridAuswahllisten.Name = "gridAuswahllisten";
            this.gridAuswahllisten.Size = new System.Drawing.Size(418, 225);
            this.gridAuswahllisten.TabIndex = 0;
            this.gridAuswahllisten.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridAuswahllisten_CellChange);
            this.gridAuswahllisten.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridAuswahllisten_BeforeCellActivate);
            this.gridAuswahllisten.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridAuswahllisten_BeforeRowsDeleted);
            // 
            // auswahlListeBindingSource
            // 
            this.auswahlListeBindingSource.DataSource = typeof(PMDS.db.Entities.AuswahlListe);
            // 
            // dropDownSelList
            // 
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.dropDownSelList.Appearance = appearance1;
            this.dropDownSelList.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownSelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropDownSelList.Location = new System.Drawing.Point(0, 0);
            this.dropDownSelList.Name = "dropDownSelList";
            this.dropDownSelList.Size = new System.Drawing.Size(514, 40);
            this.dropDownSelList.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownSelList.TabIndex = 11;
            // 
            // cboAuswahllisteMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.dropDownSelList);
            this.Name = "cboAuswahllisteMulti";
            this.Size = new System.Drawing.Size(514, 40);
            this.Load += new System.EventHandler(this.cboSprachenMulti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar2.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuswahllisten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlListeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private System.Windows.Forms.Panel panelToolbar;
        private Infragistics.Win.Misc.UltraPanel panelToolbar2;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panelToolbar_Toolbars_Dock_Area_Top;
        private System.Windows.Forms.Panel panelControl;
        private Infragistics.Win.Misc.UltraDropDownButton dropDownSelList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridAuswahllisten;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        private System.Windows.Forms.BindingSource auswahlListeBindingSource;
    }
}
