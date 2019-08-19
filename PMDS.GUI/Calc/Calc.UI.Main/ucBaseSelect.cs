using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Abrechnung.Global;
using PMDS.BusinessLogic.Abrechnung;
using Infragistics.Win.UltraWinTree;

namespace PMDS.Calc.UI.Admin
{
	/// <summary>
	/// Summary description for ucLeistungskatalogDragPicker.
	/// </summary>
	public class ucDragPickerBase : QS2.Desktop.ControlManagment.BaseControl
	{
		protected Infragistics.Win.UltraWinTree.UltraTree	tvMain;
		
		private  bool 										_SelectionHasChilds = true;
        protected QS2.Desktop.ControlManagment.BaseButton btnPush;
        protected QS2.Desktop.ControlManagment.BaseButton btnPull;
        private bool _ProcessSelected = true;
        private IContainer components;

        public event DragPickerSelectedDelegate		DragPickerSelected;
        public event DragPickerUnSelectedDelegate DragPickerUnSelected;

		public ucDragPickerBase()
		{
			InitializeComponent();
		}

		public bool SELECTIONHASCHILDS
		{
			get 
			{
				return _SelectionHasChilds;
			}
			set 
			{
				_SelectionHasChilds = value;
			}
		}

		public virtual void RefreshControl()
		{
			throw new Exception("RefreshControl nicht überschrieben");
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tvMain = new Infragistics.Win.UltraWinTree.UltraTree();
            this.btnPush = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPull = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMain.HideSelection = false;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(184, 424);
            this.tvMain.TabIndex = 0;
            this.tvMain.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.FreeForm;
            this.tvMain.DoubleClick += new System.EventHandler(this.tvMain_DoubleClick);
            this.tvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDown);
            // 
            // btnPush
            // 
            this.btnPush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPush.AutoWorkLayout = false;
            this.btnPush.IsStandardControl = false;
            this.btnPush.Location = new System.Drawing.Point(185, 40);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(24, 23);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = ">";
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnPull
            // 
            this.btnPull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPull.AutoWorkLayout = false;
            this.btnPull.IsStandardControl = false;
            this.btnPull.Location = new System.Drawing.Point(185, 64);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(24, 23);
            this.btnPull.TabIndex = 2;
            this.btnPull.Text = "<";
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // ucDragPickerBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.tvMain);
            this.Name = "ucDragPickerBase";
            this.Size = new System.Drawing.Size(216, 424);
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnPush_Click(object sender, System.EventArgs e)
		{
			ProcessSelected();
		}

		private void ProcessSelected()
		{
			if(tvMain.SelectedNodes.Count == 0)
				return;

			if(DragPickerSelected == null)
				return;

			UltraTreeNode n = tvMain.SelectedNodes[0];
			
			if(_SelectionHasChilds && n.Parent == null)							// Die erste ebenen ist die Gruppierung
				return;

			Guid id = (Guid)n.Tag;
			if(id == Guid.Empty)
				return;

			DragPickerSelected(id);
		}

		private void ProcessUnSelected()
		{
			if(DragPickerUnSelected == null)
				return;
			Guid idreturn = DragPickerUnSelected();
		}

		private void btnPull_Click(object sender, System.EventArgs e)
		{
			ProcessUnSelected();
		}

		private void tvMain_DoubleClick(object sender, System.EventArgs e)
		{
            if(_ProcessSelected)
			    ProcessSelected();
		}

        private void tvMain_MouseDown(object sender, MouseEventArgs e)
        {
            _ProcessSelected = true;
            if (tvMain.SelectedNodes.Count == 0)
                return;

            if (DragPickerSelected == null)
                return;

            UltraTreeNode n = tvMain.SelectedNodes[0];

            if (_SelectionHasChilds && n.Parent == null)							// Die erste ebenen ist die Gruppierung
                return;

            Guid id = (Guid)n.Tag;
            if (id == Guid.Empty)
                return;
            
            if(e.X >= n.Bounds.X && e.X <= (n.Bounds.X + n.Bounds.Width) && e.Y >= n.Bounds.Y && e.Y <= (n.Bounds.Y + n.Bounds.Height))
                _ProcessSelected = true;
            else
                _ProcessSelected = false;
        }
	}

	public delegate void DragPickerSelectedDelegate(Guid IDLeistungskatalog);
	public delegate Guid DragPickerUnSelectedDelegate();
}
