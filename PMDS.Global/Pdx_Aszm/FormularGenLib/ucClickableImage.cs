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
	public class ucClickableImage : ucPageElementBase
	{
		private FormularClickableImage			_clickableimage;
		private FormularGenENV			_env;

		private System.ComponentModel.Container components = null;

		public ucClickableImage()
		{
			InitializeComponent();
		}

		public FormularGenENV ENV 
		{
			set { _env = value; }
		}

		public FormularClickableImage FORMULARCLICKABLEIMAGE
		{
			get 
			{
				return _clickableimage;
			}
			set 
			{
				_clickableimage = value;
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
		private void InitializeComponent()
		{
			// 
			// ucClickableImage
			// 
			this.Size = new System.Drawing.Size(376, 32);
			this.DoubleClick += new System.EventHandler(this.ucClickableImage_DoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucClickableImage_MouseDown);

		}
		#endregion


		protected override void OnPaint(PaintEventArgs e)
		{
            if (DesignMode)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Black, new Rectangle(0,0,this.Width-1, this.Height-1));
                    g.DrawString("ucClickableImage", this.Font, Brushes.Black, 10, 10);
                }
                return;
            }

			base.OnPaint (e);

            
			_clickableimage.PrintContent(e.Graphics, null, _zoom, 0,0);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Pixel in mm umwandeln
		/// </summary>
		//--------------------------------------------------------------------------------
		private PointF ConvertToMM(Point p) 
		{
			using(Graphics g = this.CreateGraphics()) 
			{
				if(_zoom == 0.0f)
					_zoom = 1;
				float mmPixelx = 25.4f / g.DpiX / _zoom;
				float mmPixely = 25.4f / g.DpiY / _zoom;
				PointF pf = new PointF(((float)p.X) * mmPixelx, ((float)p.Y) * mmPixely);
				return pf;
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Punkte setzen / entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ucClickableImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(PAGEMODE != PageMode.Editable || _clickableimage.CLICKABLE == false || _clickableimage.CLICKABLEIMAGETYPE == ClickableImageType.Loadable)
				return;

			PointF pmouse = ConvertToMM(new Point(e.X, e.Y));
			PointF phit   = _clickableimage.HitPoint(pmouse);
			
			if(phit.X == -1f)			// kein Treffer ==> einfgen
				_clickableimage.AddPoint(pmouse);
			else 
				_clickableimage.RemovePoint(phit);

			this.Refresh();
			
		}

		private void ucClickableImage_DoubleClick(object sender, System.EventArgs e)
		{
			if(_clickableimage.CLICKABLEIMAGETYPE != ClickableImageType.Loadable)
				return;
			string sFile = GuiUtil.GetPictureFilename(".\\");
			if(sFile == "")
				return;
			_clickableimage.FILENAME = sFile;
			this.Refresh();
		}


		public override IPageElement IPAGEELEMENT
		{
			get
			{
				return (IPageElement)_clickableimage;
			}
		}

	}
}
