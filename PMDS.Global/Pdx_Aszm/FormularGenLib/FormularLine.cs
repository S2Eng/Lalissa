using System;
using System.Drawing;

namespace FormularGen
{
	/// <summary>
	/// Summary description for FormularLabel.
	/// </summary>
	public class FormularLine: PageElementBase
	{
		public FormularLine()
		{
			
		}

		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{

			g.PageUnit = GraphicsUnit.Millimeter;

			base.PrintContent(g, env, zoom, xoffset, yoffset);
			
			Pen p = new Pen(_forecolor, LINETHICKNESS);
			if(WIDTH > HEIGHT)
				g.DrawLine(p, xoffset*zoom, yoffset*zoom, (xoffset + WIDTH)*zoom, yoffset*zoom);
			else
				g.DrawLine(p, xoffset*zoom, yoffset*zoom, xoffset*zoom, (yoffset + HEIGHT) *zoom);

		}

		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("FormularLine");
			base.SaveElement (w);
			w.WriteEndElement();
		}

	}
}
