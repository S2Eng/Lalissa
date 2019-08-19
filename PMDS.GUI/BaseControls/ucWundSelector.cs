using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace PMDS.GUI.BaseControls
{
    public partial class ucWundSelector : QS2.Desktop.ControlManagment.BaseControl
    {
        private List<Point> _points = new List<Point>();

        public event  EventHandler PointChanged;

        public ucWundSelector()
        {
            InitializeComponent();
        }


        private void ultraPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawPoints(e.Graphics);
        }

        private void DrawPoints(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2.0f);

            foreach (Point p in _points)
            {
                int x   = p.X - 10;
                int y   = p.Y - 10;
                int x1  = p.X + 10;
                int y1  = p.Y + 10;
                g.DrawLine(pen, x, y, x1, y1);


                x = p.X - 10;
                y = p.Y + 10;
                x1 = p.X + 10;
                y1 = p.Y - 10;
                g.DrawLine(pen, x, y, x1, y1);

            }
        }

        public List<Point> POINTS
        {
            get
            {
                return _points;
            }
        }

        public void SetPoint(Point p)
        {
            _points.Clear();
            if(p.X != -1)                   // -1 ist nicht gesetzt
                _points.Add(p);
            Invalidate();
            Refresh();
        }

        public void Clear()
        {
            _points.Clear();
            Invalidate();
            Refresh();
        }
        

        private void ultraPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _points.Clear();
            _points.Add(e.Location);
            ultraPictureBox1.Invalidate();
            if (PointChanged != null)
                PointChanged(this, EventArgs.Empty);
        }

        public MemoryStream IMAGEPOINTED
        {
            get
            {
                Bitmap b = (Bitmap)((Bitmap)ultraPictureBox1.Image).Clone();
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.PageUnit = GraphicsUnit.Millimeter;
                    foreach (Point p in _points)
                    {
                        float relx = ((float)p.X  /(float)ultraPictureBox1.Width);
                        float rely = ((float)p.Y / (float)ultraPictureBox1.Height);

                        float mmPixelx = 25.4f / g.DpiX;
				        float mmPixely = 25.4f / g.DpiY;
                        float W = (float)b.Width * mmPixelx;            // breite in mm des Image
                        float H = (float)b.Height * mmPixely;           // höhe in mm des Image
                        float X = W * relx;                             // Die zu setzenden Koordinaten X
                        float Y = H * rely;                             // Die zu setzenden Koordinaten Y
                        float x = X - 5.0f;
                        float y = Y - 5.0f;
                        float x1 = X + 5.0f;
                        float y1 = Y + 5.0f;
                        Pen pen = new Pen(Color.Black, 1.0f);
                        g.DrawLine(pen, x, y, x1, y1);

                        x = X - 5.0f;
                        y = Y + 5.0f;
                        x1 = X + 5.0f;
                        y1 = Y - 5.0f;
                        g.DrawLine(pen, x, y, x1, y1);
                    }
                }

                MemoryStream ms = new MemoryStream();
                b.Save(ms, ImageFormat.Jpeg);
                return ms;
            } 
        }
    }
}
