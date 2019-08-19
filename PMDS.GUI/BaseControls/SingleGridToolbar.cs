using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;

namespace PMDS.GUI.BaseControls
{
	/// <summary>
	/// Summary description for SingleGridToolbar.
	/// </summary>
	public class SingleGridToolbar : QS2.Desktop.ControlManagment.BaseControl
	{
		public event EventHandler Add;
		public event EventHandler Add2;
		public event EventHandler Delete;

		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private QS2.Desktop.ControlManagment.BasePanel SingleGridToolbar_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SingleGridToolbar_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SingleGridToolbar_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SingleGridToolbar_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SingleGridToolbar_Toolbars_Dock_Area_Bottom;
		private System.ComponentModel.IContainer components;

		public SingleGridToolbar()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		public ToolBase BUTTONADD2
		{
			get 
			{
				return ultraToolbarsManager1.Toolbars["tbMain"].Tools["Unterelementhinzufuegen"];
			}
		}

		public bool ShowAddUnterelement
		{
			get
			{
				return BUTTONADD2.SharedProps.Visible;
			}
			set 
			{
				BUTTONADD2.SharedProps.Visible = value;
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("tbMain");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("hinzufuegen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Unterelementhinzufuegen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("loeschen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("hinzufuegen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("loeschen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Unterelementhinzufuegen");
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.SingleGridToolbar_Fill_Panel = new QS2.Desktop.ControlManagment.BasePanel();
            this._SingleGridToolbar_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SingleGridToolbar_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SingleGridToolbar_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "tbMain";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool4.SharedPropsInternal.Caption = "hinzufügen";
            buttonTool4.SharedPropsInternal.ToolTipText = "hinzufügen";
            buttonTool5.SharedPropsInternal.Caption = "löschen";
            buttonTool5.SharedPropsInternal.ToolTipText = "entfernen";
            buttonTool6.SharedPropsInternal.Caption = "Unterelement hinzufügen";
            buttonTool6.SharedPropsInternal.ToolTipText = "UNterelement hinzufügen";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // SingleGridToolbar_Fill_Panel
            // 
            this.SingleGridToolbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SingleGridToolbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SingleGridToolbar_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.SingleGridToolbar_Fill_Panel.Name = "SingleGridToolbar_Fill_Panel";
            this.SingleGridToolbar_Fill_Panel.Size = new System.Drawing.Size(408, 0);
            this.SingleGridToolbar_Fill_Panel.TabIndex = 0;
            // 
            // _SingleGridToolbar_Toolbars_Dock_Area_Left
            // 
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.Name = "_SingleGridToolbar_Toolbars_Dock_Area_Left";
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 0);
            this._SingleGridToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SingleGridToolbar_Toolbars_Dock_Area_Right
            // 
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(408, 27);
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.Name = "_SingleGridToolbar_Toolbars_Dock_Area_Right";
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._SingleGridToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SingleGridToolbar_Toolbars_Dock_Area_Top
            // 
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.Name = "_SingleGridToolbar_Toolbars_Dock_Area_Top";
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(408, 27);
            this._SingleGridToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SingleGridToolbar_Toolbars_Dock_Area_Bottom
            // 
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 24);
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.Name = "_SingleGridToolbar_Toolbars_Dock_Area_Bottom";
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(408, 0);
            this._SingleGridToolbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // SingleGridToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.SingleGridToolbar_Fill_Panel);
            this.Controls.Add(this._SingleGridToolbar_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SingleGridToolbar_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SingleGridToolbar_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._SingleGridToolbar_Toolbars_Dock_Area_Top);
            this.Name = "SingleGridToolbar";
            this.Size = new System.Drawing.Size(408, 24);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "hinzufuegen":
					if(Add != null)
						Add(this, EventArgs.Empty);
					break;

				case "loeschen":
					if(Delete != null)
						Delete(this, EventArgs.Empty);
					break;
				case "Unterelementhinzufuegen":
					if(Add2 != null)
						Add2(this, EventArgs.Empty);
					break;


			}
		
		}
	}
}
