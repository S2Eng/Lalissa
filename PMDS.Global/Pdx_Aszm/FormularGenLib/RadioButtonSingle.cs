using System;
using System.Drawing;
using System.Xml;
using System.Text;

namespace FormularGen
{
	/// <summary>
	/// Summary description for RadioButtonSingle.
	/// </summary>
	public class RadioButtonSingle : PageElementBase
	{
		private RadioButtonSingleStyle		_style = RadioButtonSingleStyle.Circle;
		private bool						_drawvalue = true;

		public RadioButtonSingle()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private bool _selected = false;
		public bool SELECTED 
		{
			get 
			{
				return _selected;
			}
			set 
			{
				_selected = value;
			}
		}

		public override float SUM_VALUE
		{
			get
			{
				if(SELECTED)
					return this.VALUE;
				else
					return 0;
			}
			set
			{
			}
		}

		public RadioButtonSingleStyle RADIOBUTTONSINGLESTYLE {get {return _style;} set {_style = value;}	}
		public bool DRAWVALUE {get {return _drawvalue;} set {_drawvalue = value;}	}

		
		public override void SaveElementData(XmlWriter w)
		{
			StringBuilder sb = new StringBuilder();
			if(this.SELECTED)
				sb.Append("1");
			else
				sb.Append("0");
			STRINGVALUE = sb.ToString();
			base.SaveElementData (w);
		}

		public override void LoadElementData(XmlNode node)
		{
			base.LoadElementData (node);
			this.SELECTED = STRINGVALUE == "1" ? true : false;
		}
		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Den Button je nach Button Style zeichnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void DrawButton(System.Drawing.Graphics g, Pen p, float zoom, float xoffset, float yoffset)
		{
			switch(_style) 
			{
				case RadioButtonSingleStyle.Circle:
					g.DrawEllipse(p, (0.5f*zoom) + (xoffset*zoom), (0.5f*zoom) + (yoffset*zoom), 3*zoom, 3*zoom);
					break;
				case RadioButtonSingleStyle.Square:
					g.DrawRectangle(p, (0.5f*zoom) + (xoffset*zoom), (0.5f*zoom) + (yoffset*zoom), 3*zoom, 3*zoom);
					break;
			}
			
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Auswahl erzeugen (x für quadrat un nicht sichtbaren Rahmen, Kreis sonst)
		/// </summary>
		//--------------------------------------------------------------------------------
		private void DrawButtonSelected(System.Drawing.Graphics g, Brush b,  float zoom, float xoffset, float yoffset)
		{
			if(!_selected)
				return;

			switch(_style) 
			{
				case RadioButtonSingleStyle.Circle:
					g.FillEllipse(b, (1f*zoom) + (xoffset*zoom), (1f*zoom) + (yoffset*zoom), 2.0f*zoom, 2.0f*zoom);
					break;
				case RadioButtonSingleStyle.Square:
				case RadioButtonSingleStyle.NonVisibleBorder:
					Pen p = new Pen(_forecolor, 0.5f);
					g.DrawLine(p, (0.5f*zoom) + (xoffset*zoom), (0.5f*zoom) + (yoffset*zoom), 3.5f*zoom + (xoffset*zoom), 3.5f*zoom + (yoffset*zoom));
					g.DrawLine(p, (3.5f*zoom) + (xoffset*zoom) , (0.5f*zoom) + (yoffset*zoom), (0.5f*zoom) + (xoffset*zoom), 3.5f*zoom + (yoffset*zoom));
					break;
			}
			
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Texte zeichnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void DrawString(System.Drawing.Graphics g, Brush b,  string sText, float zoom, float xoffset, float yoffset) 
		{
			Font f = GetFont(zoom);
			float yFont = 1.75f - _fontemsize/2.0f;
		
			float xValue = 5.0f;
			float xText = 11.0f;

			if(DRAWVALUE) 
				g.DrawString(VALUE.ToString(), f, b, (xoffset*zoom) + (xValue*zoom), yFont*zoom + (yoffset*zoom));
			else
				xText = 5.0f;

			RectangleF rf = new RectangleF((xoffset*zoom) + (xText*zoom),  yFont*zoom + (yoffset*zoom), (WIDTH - xText)*zoom, (HEIGHT - yFont)*zoom);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Near;
			
			g.DrawString(sText, f, b, rf, sf);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Zeichnen
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{
			if(g.DpiX > 100)
				g.PageUnit = g.PageUnit;

			string sText;
			if(env == null)
				sText = _text;
			else
				sText = env.ReplaceStringElements(_text);

			g.PageUnit = GraphicsUnit.Millimeter;
			SolidBrush b = new SolidBrush(_forecolor);
			SolidBrush bback = new SolidBrush(_backcolor);
			Pen p = new Pen(_forecolor, 0.1f);

			if(_backcolor != Color.White)
				g.FillRectangle(bback, xoffset*zoom, yoffset*zoom, _width*zoom, _height*zoom);
			
			DrawButton(g,p, zoom, xoffset, yoffset);
			DrawString(g,b, sText, zoom, xoffset, yoffset);
			
			DrawButtonSelected(g,b, zoom, xoffset, yoffset);
		}

		public override void LoadElement(System.Xml.XmlNode node)
		{
			base.LoadElement (node);

			string sStyle = GetStringValue(node, "RADIOBUTTONSINGLESTYLE");
			if(sStyle.Length > 0)
				this.RADIOBUTTONSINGLESTYLE = (RadioButtonSingleStyle)Enum.Parse(typeof(RadioButtonSingleStyle), sStyle);
			this.DRAWVALUE = GetBoolValue(node, "DRAWVALUE");
		}

		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("RadioButtonSingle");
			base.SaveElement (w);
			w.WriteAttributeString("RADIOBUTTONSINGLESTYLE",		RADIOBUTTONSINGLESTYLE.ToString());
			w.WriteAttributeString("DRAWVALUE",						DRAWVALUE.ToString());
			w.WriteEndElement();

		}

	}

	public enum RadioButtonSingleStyle 
	{
		Circle,
		Square,
		NonVisibleBorder
	}
}
