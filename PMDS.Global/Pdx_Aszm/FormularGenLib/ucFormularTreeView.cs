using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucFormularTreeView.
	/// </summary>
	public class ucFormularTreeView : System.Windows.Forms.UserControl
	{

		private Formular			_formular;

		private System.Windows.Forms.TreeView tvMain;
		private System.ComponentModel.Container components = null;

		public ucFormularTreeView()
		{
			InitializeComponent();
		}

		public Formular FORMULAR 
		{
			set 
			{
				_formular = value;
				RefreshTree();
			}
			get 
			{
				return _formular;
			}
		}

		private void RefreshTree()
		{
			
			try 
			{
				tvMain.BeginUpdate();
				tvMain.Nodes.Clear();
				
				if(_formular == null)
					return;

				int iCount = 1;
				foreach(Page p in _formular.PAGES)
				{
					TreeNode n = tvMain.Nodes.Add(string.Format("Seite {0}", iCount));
					n.Tag = iCount;
					foreach(IPageElement e in p.ELEMENTS)
					{
						string sInfo = e.FIELDNAME.Length == 0 ? e.TEXT : e.FIELDNAME;
						n.Nodes.Add(sInfo);
					}
					iCount++;
				}
				tvMain.ExpandAll();
			}
			finally
			{
				tvMain.EndUpdate();
			}
		}

		public int SELECTEDPAGE 
		{
			get 
			{
				TreeNode n = tvMain.SelectedNode;
				if(n == null)
					return -1;
				while(n.Parent != null)			// Root suchen
				{
					n = n.Parent;
				}
				return (int)n.Tag;				// Im Wurzelelement steckt die Seitennummer
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tvMain = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// tvMain
			// 
			this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvMain.HideSelection = false;
			this.tvMain.ImageIndex = -1;
			this.tvMain.Location = new System.Drawing.Point(0, 0);
			this.tvMain.Name = "tvMain";
			this.tvMain.SelectedImageIndex = -1;
			this.tvMain.Size = new System.Drawing.Size(312, 504);
			this.tvMain.TabIndex = 0;
			// 
			// ucFormularTreeView
			// 
			this.Controls.Add(this.tvMain);
			this.Name = "ucFormularTreeView";
			this.Size = new System.Drawing.Size(312, 504);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
