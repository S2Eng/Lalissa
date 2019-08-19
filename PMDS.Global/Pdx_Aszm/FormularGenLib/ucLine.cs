using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucLabel.
	/// </summary>
	public class ucLine : ucPageElementBase
	{
		private FormularLine			_line;

		private System.ComponentModel.Container components = null;

		public ucLine()
		{
			InitializeComponent();
		}

		public FormularLine FORMULARLINE 
		{
			get 
			{
				return _line;
			}
			set 
			{
				_line = value;
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
			// 
			// ucLabel
			// 
			this.Size = new System.Drawing.Size(376, 32);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucLine_Paint);

		}
		#endregion

		private void ucLine_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if(_pagemode != PageMode.Editable)
				base.OnPaint(e);
			_line.PrintContent(e.Graphics, null, _zoom, 0,0);	
		}


		public override IPageElement IPAGEELEMENT
		{
			get
			{
				return (IPageElement)_line;
			}
		}

	}
}
