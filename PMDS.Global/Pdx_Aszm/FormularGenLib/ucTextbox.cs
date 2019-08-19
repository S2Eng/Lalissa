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
	public class ucTextBox : ucPageElementBase
	{
		private FormularTextBox					_textbox;
		private System.Windows.Forms.TextBox	tbMain;

		private System.ComponentModel.Container components = null;

		public ucTextBox()
		{
			InitializeComponent();
		}

		public FormularTextBox FORMULARTEXTBOX  
		{
			get 
			{
				return _textbox;
			}
			set 
			{
				_textbox = value;
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
			this.tbMain = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbMain
			// 
			this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMain.Location = new System.Drawing.Point(0, 0);
			this.tbMain.Multiline = true;
			this.tbMain.Name = "tbMain";
			this.tbMain.Size = new System.Drawing.Size(376, 32);
			this.tbMain.TabIndex = 0;
			this.tbMain.Text = "";
			this.tbMain.Visible = false;
			this.tbMain.TextChanged += new System.EventHandler(this.tbMain_TextChanged);
			this.tbMain.Leave += new System.EventHandler(this.tbMain_Leave);
			// 
			// ucTextBox
			// 
			this.Controls.Add(this.tbMain);
			this.Size = new System.Drawing.Size(376, 32);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucTextBox_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		private void ucTextBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(tbMain.Visible) 
			{
				tbMain.Text = IPAGEELEMENT.STRINGVALUE;
				tbMain.Font = IPAGEELEMENT.GetFont(_zoom);
			}
			else 
			{
				_textbox.PrintContent(e.Graphics, null, _zoom, 0,0);
			}
		}

		private void tbMain_Leave(object sender, System.EventArgs e)
		{
			IPAGEELEMENT.STRINGVALUE = tbMain.Text;
		}

		private void tbMain_TextChanged(object sender, System.EventArgs e)
		{
			IPAGEELEMENT.STRINGVALUE = tbMain.Text;
		}

		public override IPageElement IPAGEELEMENT
		{
			get
			{
				return (IPageElement)_textbox;
			}
		}

		public override PageMode PAGEMODE
		{
			get
			{
				return base.PAGEMODE;
			}
			set
			{
				base.PAGEMODE = value;
				if(PAGEMODE == PageMode.Editable)
				{
					tbMain.Visible = true;
					tbMain.Text = IPAGEELEMENT.STRINGVALUE;
					tbMain.Font = IPAGEELEMENT.GetFont(_zoom);
				}
				else
					tbMain.Visible = false;
			}
		}

		public override int ZOOM
		{
			get
			{
				return base.ZOOM;
			}
			set
			{
				base.ZOOM = value;
				tbMain.Font = IPAGEELEMENT.GetFont(_zoom);
			}
		}



	}
}
