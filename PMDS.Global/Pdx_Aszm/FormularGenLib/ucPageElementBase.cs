using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucPageElementBase.
	/// </summary>
	public class ucPageElementBase : Control, IUCPageElement
	{
		public event EventHandler		ContentChanged;
		protected float					_zoom = 1.0f;

		protected float					mm_pixelx = 1;
		protected float					mm_pixely = 1;
		protected PageMode				_pagemode = PageMode.Editable;
		protected bool					_selectbox= false;
	

		public ucPageElementBase()
		{
			Graphics g = this.CreateGraphics();
			mm_pixelx = g.DpiX / 25.4f;			// Ergibt wieviele pixel pro mm
			mm_pixely = g.DpiY / 25.4f;			// Ergibt wieviele pixel pro mm
		}

		public virtual int ZOOM { get { return (int)(_zoom*100.0f);} set { _zoom = ((float)value) /100.0f; ResizeThis();}}

		protected virtual void ContentChangedSignal() 
		{
			if(ContentChanged != null)
				ContentChanged(this, null);
		}

		protected virtual void ResizeThis() 
		{
			if(IPAGEELEMENT == null)
				return;
			this.Width		= (int)(IPAGEELEMENT.WIDTH	* mm_pixelx * _zoom);
			this.Height		= (int)(IPAGEELEMENT.HEIGHT * mm_pixely * _zoom);
			this.Top		= (int)(IPAGEELEMENT.TOP	* mm_pixely * _zoom);
			this.Left		= (int)(IPAGEELEMENT.LEFT	* mm_pixely * _zoom);
			if(this.Width == 0)
				this.Width = 1;
			if(this.Height == 0)
				this.Height = 1;
		}

		public virtual IPageElement IPAGEELEMENT 
		{
			get
			{
				throw new Exception("IPAGEELEMENT muss überschrieben werden");
			}
		}

		public virtual bool ReadOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual PageMode PAGEMODE 
		{
			get 
			{
				return _pagemode;
			}
			set 
			{
				_pagemode = value;

				if(_pagemode == PageMode.Editable)
					this.Enabled = true;
				else
					this.Enabled = false;
			}

		}

		
		public bool SELECTBOX
		{
			get 
			{
				return _selectbox;
			}
			set 
			{
				_selectbox = value;
				this.Refresh();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			Graphics g = e.Graphics;
			
			if(_pagemode == PageMode.Design) 
			{
				g.PageUnit = GraphicsUnit.Pixel;
				Pen p = new Pen(IPAGEELEMENT.FORECOLOR);
				p.DashStyle = DashStyle.DashDot;
				g.DrawRectangle(p, 0,0,this.Width-1, this.Height-1);
			}

			if(_selectbox && _pagemode == PageMode.Design)
			{				
				g.PageUnit = GraphicsUnit.Pixel;
				Pen p = new Pen(Color.Blue);
				p.DashStyle = DashStyle.DashDot;
				g.DrawRectangle(p, 0,0, this.Width-1, this.Height-1);
				g.DrawLine(p, this.Width, this.Height - 10, this.Width-10, this.Height);
			}

			if(IPAGEELEMENT.BORDER) 
			{
				g.PageUnit = GraphicsUnit.Pixel;
				Pen p = new Pen(IPAGEELEMENT.FORECOLOR);
				p.DashStyle = IPAGEELEMENT.DASHSTYLE;
				g.DrawRectangle(p, 0,0, this.Width-1, this.Height-1);
			}

			
		}
		
	}
}
