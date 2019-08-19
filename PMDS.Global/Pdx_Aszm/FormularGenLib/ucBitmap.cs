using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace FormularGenLib
{
	/// <summary>
	/// Summary description for ucBitmap.
	/// </summary>
	public class ucBitmap : System.Windows.Forms.UserControl
	{

		public event ImageDeleteDelegate	ImageDelete;

		private Bitmap				_bitmap;
		
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuRotate90left;
		private System.Windows.Forms.MenuItem mnuRotate90rigth;
		private System.Windows.Forms.MenuItem mnuFlipHor;
		private System.Windows.Forms.MenuItem mnuFlipVer;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuDelImage;
		private System.Windows.Forms.MenuItem mnuShow;
        private System.Windows.Forms.MenuItem menuItem3;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager lay_control;
        private IContainer components;

		public ucBitmap()
		{
			InitializeComponent();
		}

		public Bitmap	BITMAP 
		{
			get 
			{
				return _bitmap;
			}

			set 
			{
				_bitmap = value;
			}
		}

		public bool SHOWCONTEXTMENU
		{
			set 
			{
				if(value)
					this.ContextMenu = contextMenu1;
				else
					this.ContextMenu = null;
			}
			get 
			{
				return ContextMenu == null ? false : true;
			}
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
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuRotate90left = new System.Windows.Forms.MenuItem();
            this.mnuRotate90rigth = new System.Windows.Forms.MenuItem();
            this.mnuFlipHor = new System.Windows.Forms.MenuItem();
            this.mnuFlipVer = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuShow = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuDelImage = new System.Windows.Forms.MenuItem();
            this.lay_control = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lay_control)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuRotate90left,
            this.mnuRotate90rigth,
            this.mnuFlipHor,
            this.mnuFlipVer,
            this.menuItem1,
            this.mnuShow,
            this.menuItem3,
            this.mnuDelImage});
            // 
            // mnuRotate90left
            // 
            this.mnuRotate90left.Index = 0;
            this.mnuRotate90left.Text = "Drehen 90° nach links";
            this.mnuRotate90left.Click += new System.EventHandler(this.mnuRotate90left_Click);
            // 
            // mnuRotate90rigth
            // 
            this.mnuRotate90rigth.Index = 1;
            this.mnuRotate90rigth.Text = "Drehen 90° nach rechts";
            this.mnuRotate90rigth.Click += new System.EventHandler(this.mnuRotate90rigth_Click);
            // 
            // mnuFlipHor
            // 
            this.mnuFlipHor.Index = 2;
            this.mnuFlipHor.Text = "Horizontal kippen";
            this.mnuFlipHor.Click += new System.EventHandler(this.mnuFlipHor_Click);
            // 
            // mnuFlipVer
            // 
            this.mnuFlipVer.Index = 3;
            this.mnuFlipVer.Text = "Vertikal kippen";
            this.mnuFlipVer.Click += new System.EventHandler(this.mnuFlipVer_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // mnuShow
            // 
            this.mnuShow.Index = 5;
            this.mnuShow.Text = "anzeigen";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // mnuDelImage
            // 
            this.mnuDelImage.Index = 7;
            this.mnuDelImage.Text = "löschen";
            this.mnuDelImage.Click += new System.EventHandler(this.mnuDelImage_Click);
            // 
            // lay_control
            // 
            this.lay_control.ContainerControl = this;
            this.lay_control.ExpandToFitHeight = true;
            this.lay_control.ExpandToFitWidth = true;
            // 
            // ucBitmap
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenu = this.contextMenu1;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucBitmap";
            this.Size = new System.Drawing.Size(153, 88);
            this.Load += new System.EventHandler(this.ucBitmap_Load);
            this.DoubleClick += new System.EventHandler(this.ucBitmap_DoubleClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucBitmap_Paint);
            this.Leave += new System.EventHandler(this.ucBitmap_Leave);
            this.Resize += new System.EventHandler(this.ucBitmap_Resize);
            this.Enter += new System.EventHandler(this.ucBitmap_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.lay_control)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Redraw(Graphics g) 
		{
			g.Clear(Color.White);
			if(_bitmap == null)
				return;

			// Aspektrate berücksichtigen
			int b = _bitmap.Width;
			int h = _bitmap.Height;
			
			float asp = (float)_bitmap.Height / (float)_bitmap.Width;
			this.Height = (int)((float)this.Width * asp);

			g.DrawImage(_bitmap, 0,0,this.Width, this.Height);
			DrawRect(g);
			
		}

		private void DrawRect(Graphics g) 
		{
			if(this.Focused) 
				g.DrawRectangle(Pens.Yellow, 0,0,this.Width-1, this.Height-1);
			else
				g.DrawRectangle(Pens.White, 0,0,this.Width-1, this.Height-1);

		}

		private void mnuRotate90left_Click(object sender, System.EventArgs e)
		{
			_bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
			this.Refresh();
		}

		private void mnuRotate90rigth_Click(object sender, System.EventArgs e)
		{
			_bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
			this.Refresh();
		}

		private void mnuFlipHor_Click(object sender, System.EventArgs e)
		{
			_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
			this.Refresh();
		}

		private void mnuFlipVer_Click(object sender, System.EventArgs e)
		{
			_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
			this.Refresh();
		}

		private void mnuDelImage_Click(object sender, System.EventArgs e)
		{
			if(ImageDelete != null)
				ImageDelete(_bitmap);
		}

		private void mnuShow_Click(object sender, System.EventArgs e)
		{
			ShowActualImage();
		}

		private void ShowActualImage()
		{
			frmShowImage frm = new frmShowImage(_bitmap);
			frm.ShowDialog();
		}


        private void ucBitmap_Load(object sender, EventArgs e)
        {

        }

        private void ucBitmap_DoubleClick(object sender, EventArgs e)
        {
            ShowActualImage();
        }

        private void ucBitmap_Enter(object sender, EventArgs e)
        {
            DrawRect(this.CreateGraphics());
        }

        private void ucBitmap_Leave(object sender, EventArgs e)
        {
            DrawRect(this.CreateGraphics());
        }

        private void ucBitmap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Redraw(g);
        }

        private void ucBitmap_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

	}

	public delegate void ImageDeleteDelegate(Bitmap b);
}
