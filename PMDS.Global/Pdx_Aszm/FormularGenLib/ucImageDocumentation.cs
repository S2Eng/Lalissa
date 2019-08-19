using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using FormularGen;

namespace FormularGenLib
{
	//--------------------------------------------------------------------------------
	/// <summary>
	/// Klasse für Variable Bildelemente
	/// </summary>
	//--------------------------------------------------------------------------------
	public class ucImageDocumentation : System.Windows.Forms.UserControl
	{
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Splitter und ExplorerBar eingefügt! Auto Resize, Bildviewer erneuert
        /// [lth]
        /// </summary>
        //--------------------------------------------------------------------------------


		private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlPictures;
		
		private Formular				_formular;

		private ArrayList				_aImages = new ArrayList();
        private System.Windows.Forms.OpenFileDialog dlgOpenPicture;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucImageDocumentation_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucImageDocumentation_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucImageDocumentation_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucImageDocumentation_Toolbars_Dock_Area_Bottom;
        private IContainer components;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//--------------------------------------------------------------------------------
		public ucImageDocumentation()
		{
			InitializeComponent();
		}


		public Formular		FORMULAR {get{return _formular;} set{_formular = value; RecreateAll();}}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Elemente neu aufbauen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void RecreateAll() 
		{
			foreach(Control c in _aImages)					// Alle Elemente entfernen
				this.pnlPictures.Controls.Remove(c);			

			if(_formular == null)
				return;

			// Für jede Bitmap ein ucBitmap erzeugen und als Control einhängen
			foreach(Bitmap bm in _formular.BITMAPS)
			{
				ucBitmap b = new ucBitmap();
				b.ImageDelete +=new ImageDeleteDelegate(bitmap_ImageDelete);
				b.BITMAP	= bm;
				b.Dock		= DockStyle.Top;
				b.Height	= 200;
				_aImages.Add(b);
				pnlPictures.Controls.Add(b);
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//--------------------------------------------------------------------------------
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

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Neues Bild einfügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void NewPicture()
		{
			if(_formular == null)
				return;

			string sFile = GuiUtil.GetPictureFilename(".\\");
			if(sFile == "")
				return;
			_formular.AddImage(sFile);
			RecreateAll();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttBildHinzufügen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("buttBildHinzufügen");
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlPictures = new System.Windows.Forms.Panel();
            this.dlgOpenPicture = new System.Windows.Forms.OpenFileDialog();
            this._ucImageDocumentation_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ucImageDocumentation_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucImageDocumentation_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlPictures);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 48);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(863, 167);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlPictures
            // 
            this.pnlPictures.AutoScroll = true;
            this.pnlPictures.BackColor = System.Drawing.Color.White;
            this.pnlPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPictures.Location = new System.Drawing.Point(0, 0);
            this.pnlPictures.Name = "pnlPictures";
            this.pnlPictures.Size = new System.Drawing.Size(863, 167);
            this.pnlPictures.TabIndex = 1;
            this.pnlPictures.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPictures_Paint);
            // 
            // dlgOpenPicture
            // 
            this.dlgOpenPicture.Filter = "JPG|*.jpg|JPEG|*.jpeg|Bitmap|*.bmp|Gif|*.gif|TIF|*.tif";
            this.dlgOpenPicture.RestoreDirectory = true;
            // 
            // _ucImageDocumentation_Toolbars_Dock_Area_Left
            // 
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 48);
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.Name = "_ucImageDocumentation_Toolbars_Dock_Area_Left";
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 167);
            this._ucImageDocumentation_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
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
            buttonTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool1.SharedPropsInternal.Caption = "Bild hinzufügen";
            buttonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool1.SharedPropsInternal.ToolTipTextFormatted = "Benutzen Sie die rechte Maustaste über den Bildern um sie zu drehen, zu kippen,<b" +
    "r/>anzeigen/drucken(Doppelklick) und zu löschen!";
            buttonTool1.SharedPropsInternal.ToolTipTitle = "Bild hinzufügen";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _ucImageDocumentation_Toolbars_Dock_Area_Right
            // 
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(863, 48);
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.Name = "_ucImageDocumentation_Toolbars_Dock_Area_Right";
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 167);
            this._ucImageDocumentation_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucImageDocumentation_Toolbars_Dock_Area_Top
            // 
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.Name = "_ucImageDocumentation_Toolbars_Dock_Area_Top";
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(863, 48);
            this._ucImageDocumentation_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucImageDocumentation_Toolbars_Dock_Area_Bottom
            // 
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 215);
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.Name = "_ucImageDocumentation_Toolbars_Dock_Area_Bottom";
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(863, 0);
            this._ucImageDocumentation_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ucImageDocumentation
            // 
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this._ucImageDocumentation_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ucImageDocumentation_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ucImageDocumentation_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._ucImageDocumentation_Toolbars_Dock_Area_Top);
            this.Name = "ucImageDocumentation";
            this.Size = new System.Drawing.Size(863, 215);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void bitmap_ImageDelete(Bitmap b)
		{
			_formular.RemoveImage(b);
			RecreateAll();
		}

        private void pnlPictures_Paint(object sender, PaintEventArgs e)
        {
            //appearance16.Image = global::FormularGenLib.Properties.Resources.ICO_OrdnerLupe;    //lthxy
            //appearance17.Image = global::FormularGenLib.Properties.Resources.ICO_OrdnerLupe;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Toolbar eingefügt
        /// [lth]
        /// </summary>
        //--------------------------------------------------------------------------------
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "buttBildHinzufügen":
                    NewPicture();
                    break;
            }

        }

	}
}
