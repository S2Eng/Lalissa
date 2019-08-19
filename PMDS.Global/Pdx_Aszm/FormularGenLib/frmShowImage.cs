using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormularGenLib
{
	/// <summary>
	/// Summary description for frmShowImage.
	/// </summary>
	public class frmShowImage : System.Windows.Forms.Form
	{
		private float	_asp = 1.0f;

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuPrint;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowImage(Bitmap b)
		{
			InitializeComponent();
			pictureBox1.Left = 0;
			pictureBox1.Top = 0;
			pictureBox1.Image = b;
			if(b.Height > 0)
				_asp = (float)b.Height / (float)b.Width;
			AspectRatio();
			
		}

		private void AspectRatio()
		{
			pictureBox1.Width = this.Width;
			pictureBox1.Height =(int)(((float) this.Width) * _asp);
			if(pictureBox1.Height > panel1.Height) 
			{
				pictureBox1.Height = panel1.Height;
				pictureBox1.Width = (int)((float)panel1.Height / _asp);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Bild drucken 10x15 (Mit Druckdialog)
		/// </summary>
		//--------------------------------------------------------------------------------
		public void PrintImage()
		{
			PrintDocument d = new PrintDocument();
			PrintDialog dlg = new PrintDialog();
			d.PrintPage +=new PrintPageEventHandler(d_PrintPage);
			dlg.Document = d;
			DialogResult res = dlg.ShowDialog();
			if(res != DialogResult.OK)
				return;
			d.Print();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Seiten Event Drucken 2cm abstand links oben in 10x15 cm Format
		/// </summary>
		//--------------------------------------------------------------------------------
		private void d_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			Image i = pictureBox1.Image;
			g.PageUnit = GraphicsUnit.Millimeter;
			float w = 150.0f;
			float h = 100.0f;
			float asp = (float)((float)i.Height / (float)i.Width);
			if(asp >=1) 
			{
				w = 100.0f / asp;
				h = 100.0f;
			}
			else
			{
				w = 150.0f;
				h = 150.0f * asp;
			}
			g.DrawImage(i, 20.0f,20.0f, w, h);

			e.HasMorePages = false;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmShowImage));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuPrint = new System.Windows.Forms.MenuItem();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(288, 216);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(848, 569);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuPrint});
			this.menuItem1.Text = "Bild";
			// 
			// mnuPrint
			// 
			this.mnuPrint.Index = 0;
			this.mnuPrint.Text = "Drucken";
			this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
			// 
			// frmShowImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(848, 569);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "frmShowImage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bildbetrachter";
			this.Resize += new System.EventHandler(this.frmShowImage_Resize);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmShowImage_Resize(object sender, System.EventArgs e)
		{
			AspectRatio();
		}

		private void mnuPrint_Click(object sender, System.EventArgs e)
		{
			PrintImage();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
