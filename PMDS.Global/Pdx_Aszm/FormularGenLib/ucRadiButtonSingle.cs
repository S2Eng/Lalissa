using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucRadiButtonSingle.
	/// </summary>
	public class ucRadiButtonSingle : ucPageElementBase
	{

		private RadioButtonSingle		_button;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucRadiButtonSingle()
		{
			InitializeComponent();
		}


		public RadioButtonSingle	RADIOBUTTONSINGLE 
		{
			get 
			{
				return _button;
			}
			set 
			{
				_button = value;
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
			// ucRadiButtonSingle
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Name = "ucRadiButtonSingle";
			this.Size = new System.Drawing.Size(496, 32);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ucRadiButtonSingle_KeyPress);
			this.Click += new System.EventHandler(this.ucRadiButtonSingle_Click);
			this.Enter += new System.EventHandler(this.ucRadiButtonSingle_Enter);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucRadiButtonSingle_Paint);
			this.Leave += new System.EventHandler(this.ucRadiButtonSingle_Leave);

		}
		#endregion

		private void ucRadiButtonSingle_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			_button.PrintContent(e.Graphics, null, _zoom, 0,0);
		}

		private void ucRadiButtonSingle_Enter(object sender, System.EventArgs e)
		{
			RedrawRectangle(true);
		}

		private void ucRadiButtonSingle_Leave(object sender, System.EventArgs e)
		{
			RedrawRectangle(false);
		}

		private void RedrawRectangle(bool bFocus) 
		{
			using(Graphics g = this.CreateGraphics()) 
			{
				Pen p;
				if(bFocus) 
					p = Pens.Blue;
				else
					p = Pens.White;

				g.DrawRectangle(p, 0,0, this.Width-1, this.Height-1);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Toggle Selection
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ucRadiButtonSingle_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == ' ')
				ToggleSelection();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
		}

		private void ToggleSelection() 
		{
			if(PAGEMODE != PageMode.Editable)
				return;
			_button.SELECTED = !_button.SELECTED;
			this.Refresh();
			ContentChangedSignal();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Toggle Selection
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ucRadiButtonSingle_Click(object sender, System.EventArgs e)
		{
			ToggleSelection();
		}

		


		public override IPageElement IPAGEELEMENT 
		{
			get 
			{
				if(_button != null)
					return (IPageElement)_button;
				else
					return null;
			}
		}
	}
}
