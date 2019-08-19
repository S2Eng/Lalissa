using System;
using System.Drawing;

namespace FormularGen
{
	/// <summary>
	/// Summary description for FormularLabel.
	/// </summary>
	public class FormularTextBox: PageElementBase
	{
		public FormularTextBox()
		{
			
		}

		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{
		            
            g.PageUnit = GraphicsUnit.Millimeter;
			
			SolidBrush b = new SolidBrush(_forecolor);
			SolidBrush bback = new SolidBrush(_backcolor);
			Pen p = new Pen(_forecolor, 0.1f);
			Font f = GetFont(zoom);

            Point po = new Point((int)(xoffset * zoom), (int)(yoffset * zoom));
            Size sz = new Size((int)(_width * zoom), (int)(_height * zoom));
            Rectangle r = new Rectangle(po, sz);

            StringFormat fmt = new StringFormat(StringFormatFlags.FitBlackBox);

			g.FillRectangle(bback,r);
			g.DrawRectangle(p, r);
            g.DrawString(STRINGVALUE, f, b, r, fmt);

		}

		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("FormularTextBox");
			base.SaveElement (w);
			w.WriteEndElement();
		}

	}
}
