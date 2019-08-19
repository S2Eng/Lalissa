using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucRB.
	/// </summary>
	public class ucRadioButtons : ucPageElementBase
	{
		private RadioButtons			_buttons;
		

	

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucRadioButtons()
		{
			InitializeComponent();
		}

		protected override void ResizeThis() 
		{
			if(_buttons == null)
				return;

			
			base.ResizeThis();
			foreach(IUCPageElement e in this.Controls)
				e.ZOOM = this.ZOOM;
		}

		public RadioButtons RADIOBUTTONS 
		{
			get
			{
				return _buttons;
			}
			set 
			{
				_buttons = value;
				RecreateControls();
			}
		}

		public void RecreateControls() 
		{
			this.Controls.Clear();

			if(RADIOBUTTONS == null)
				return;
			
			float x = 2;
			float y = 2;

			// Für jedes Element ein Control generieren und den singleButton zuweisen
			if(RADIOBUTTONS.RADIOBUTTONSORIENTATION == RadioButtonsOrientation.vertical) 
			{
				foreach(RadioButtonSingle r in _buttons.BUTTONS)
				{
					ucRadiButtonSingle b = new ucRadiButtonSingle();
					b.RADIOBUTTONSINGLE = r;
					b.ContentChanged +=new EventHandler(radiobuttons_ContentChanged);
					r.WIDTH			= _buttons.WIDTH -2;
					r.HEIGHT		= 5.0f;
					r.TOP			= y;
					r.LEFT			= x;
					this.Controls.Add(b);	// ab in die Liste
					b.ZOOM = this.ZOOM;		// immer zum schluss

					y+=5;
				}
			}
			else 
			{
				x=0.5f; y=0.5f;
				float iCount = _buttons.BUTTONS.Length;					// Anzahl der RBs
				float step = (this.RADIOBUTTONS.WIDTH -1) / iCount;			// Abstand zwischen die Buttons

				foreach(RadioButtonSingle r in _buttons.BUTTONS)
				{
					ucRadiButtonSingle b = new ucRadiButtonSingle();
					b.RADIOBUTTONSINGLE = r;
					b.ContentChanged +=new EventHandler(radiobuttons_ContentChanged);
					r.WIDTH			= (step);
					r.HEIGHT		= _buttons.HEIGHT - 1;
					r.TOP			= y;
					r.LEFT			= x;
					this.Controls.Add(b);	// ab in die Liste
					b.ZOOM = this.ZOOM;		// immer zum schluss

					x+=step;
				}
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
			// ucRadioButtons
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Name = "ucRadioButtons";
			this.Size = new System.Drawing.Size(640, 104);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucRadioButtons_Paint);

		}
		#endregion

		private void ucRadioButtons_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(_buttons == null)
				return;

			//_buttons.PrintContent(e.Graphics, null, _zoom, 0,0);
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
				foreach(IUCPageElement e in this.Controls)
					e.PAGEMODE = value;

				if(_pagemode == PageMode.Editable)
					this.Enabled = true;
				else
					this.Enabled = false;
			}

		}

		public override IPageElement IPAGEELEMENT 
		{
			get 
			{
				if(_buttons != null)
					return (IPageElement)_buttons;
				else
					return null;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
		}


		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged (e);
			RecreateControls();
		}



		private void radiobuttons_ContentChanged(object sender, EventArgs e)
		{
			ContentChangedSignal();
		}
	}

	
}
