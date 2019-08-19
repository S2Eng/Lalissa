using System;
using System.Drawing;

namespace FormularGen
{
	/// <summary>
	/// Summary description for FormularLabel.
	/// </summary>
	public class FormularLabel: PageElementBase
	{
		public FormularLabel()
		{
			
		}

		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{

			
			string sText;
			if(env == null)
				sText = _text;
			else
				sText = env.ReplaceStringElements(_text);

			if(STRINGVALUE.Length > 0)						// Wird bei special Fields von auﬂen gesetzt
				sText = STRINGVALUE;

			g.PageUnit = GraphicsUnit.Millimeter;
			
			SolidBrush b = new SolidBrush(_forecolor);
			SolidBrush bback = new SolidBrush(_backcolor);
			Pen p = new Pen(_forecolor, 0.1f);
			Font f = GetFont(zoom);
			g.FillRectangle(bback, xoffset*zoom, yoffset*zoom, _width*zoom, _height*zoom);
			
			base.PrintContent(g,env,zoom, xoffset, yoffset);
			
			RectangleF rf = new RectangleF((xoffset*zoom), (yoffset*zoom), this.WIDTH*zoom, this.HEIGHT*zoom);
			//g.DrawString(sText, f, b, (xoffset*zoom), (yoffset*zoom));
			StringFormat sf = new StringFormat();

			sf.Alignment = StringAlignment.Near;
			g.DrawString(sText, f, b, rf, sf);
		}

		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("FormularLabel");
			base.SaveElement (w);
			w.WriteEndElement();
		}

	}
}
