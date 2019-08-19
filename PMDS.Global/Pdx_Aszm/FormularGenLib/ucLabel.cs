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
	public class ucLabel : ucPageElementBase
	{
		private FormularLabel			_label;
		private FormularGenENV			_env;

		private System.ComponentModel.Container components = null;

		public ucLabel()
		{
			InitializeComponent();
		}

		public FormularGenENV ENV 
		{
			set { _env = value; }
		}

		public FormularLabel FORMULARLABEL  
		{
			get 
			{
				return _label;
			}
			set 
			{
				_label = value;
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
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucLabel_Paint);

		}
		#endregion

		private void ucLabel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(PAGEMODE == PageMode.Editable || PAGEMODE == PageMode.Readonly)
				_label.PrintContent(e.Graphics, _env, _zoom, 0,0);
			else
				_label.PrintContent(e.Graphics, null, _zoom, 0,0);
		}

		public override IPageElement IPAGEELEMENT
		{
			get
			{
				return (IPageElement)_label;
			}
		}

	}
}
