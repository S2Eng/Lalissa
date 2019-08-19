using System;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Text;

namespace FormularGen
{
	public class RadioButtons: PageElementBase
	{
		private RadioButtonText[]		_aText;
		private RadioButtonSingle[]		_buttons = new RadioButtonSingle[0];
		private RadioButtonsOrientation	_radiobuttonsorientation = RadioButtonsOrientation.vertical;
		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Radiobuttons 
		/// </summary>
		//--------------------------------------------------------------------------------
		public RadioButtons()
		{
		}

		public RadioButtonsOrientation RADIOBUTTONSORIENTATION { get{return _radiobuttonsorientation;} set { _radiobuttonsorientation = value;}}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Radiobuttons 
		/// </summary>
		//--------------------------------------------------------------------------------
		public RadioButtons(RadioButtonText[] aText)
		{
			_aText = aText;
			ArrayList al = new ArrayList();
			foreach(RadioButtonText t in aText)
			{
				RadioButtonSingle rbs = new RadioButtonSingle();
				rbs.TEXT = t.TEXT;
				rbs.VALUE = t.VALUE;
				al.Add(rbs);
			}
			_buttons = (RadioButtonSingle[])al.ToArray(typeof(RadioButtonSingle));
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Einen einzelnen Button hinzufügen 
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddButton(IPageElement e) 
		{
			ArrayList al = new ArrayList();
			foreach(RadioButtonSingle r in _buttons)
				al.Add(r);
			al.Add(e);
			
			_buttons = (RadioButtonSingle[])al.ToArray(typeof(RadioButtonSingle));
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Zuweisung der einzelnen Buttons von außen
		/// </summary>
		//--------------------------------------------------------------------------------
		public RadioButtonSingle[] BUTTONS 
		{
			get 
			{
				return _buttons;
			}
			set 
			{
				_buttons = value;
			}
		}
		
		
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Ausgabe der Radiobuttons auf einen Context
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{
			
			g.PageUnit = GraphicsUnit.Millimeter;
			SolidBrush bback = new SolidBrush(_backcolor);

			if(_backcolor !=  Color.White)
				g.FillRectangle(bback, xoffset*zoom, yoffset*zoom, _width*zoom, _height*zoom);

			base.PrintContent(g, env, zoom, xoffset, yoffset);

			float deltay = 0;
			float deltax = 0;

			if(RADIOBUTTONSORIENTATION == RadioButtonsOrientation.vertical) 
			{
				foreach(RadioButtonSingle b in _buttons)
				{
					b.PrintContent(g, env, zoom, xoffset+2, yoffset+2+deltay);
					deltay += b.HEIGHT;
				}
			}
			else 
			{
				float iCount =  _buttons.Length;					// Anzahl der RBs
				float step = (this.WIDTH -1) / iCount;					// Abstand zwischen die Buttons
				foreach(RadioButtonSingle b in _buttons)
				{
					b.PrintContent(g, env, zoom, xoffset+0.5f+deltax, yoffset +0.5f);
					deltax += step;
				}
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Summe aller ausgewählten Elemente
		/// </summary>
		//--------------------------------------------------------------------------------
		public override float SUM_VALUE
		{
			get
			{
				float f  = 0;
				foreach(RadioButtonSingle b in _buttons)
				{
					if(b.SELECTED)
						f+= b.SUM_VALUE;
				}
				return f;
			}
			set
			{
			}
		}


		
		
		public override float FONTEMSIZE
		{
			get
			{
				return _fontemsize;
			}
			set
			{
				_fontemsize = value;
				foreach(RadioButtonSingle r in _buttons)
					r.FONTEMSIZE = value;
			}
		}

		public override string FONT 
		{
			get 
			{
				return _font;
			}
			set 
			{
				_font = value;
				foreach(RadioButtonSingle r in _buttons)
					r.FONT = value;
			}
		}

		public override Color BACKCOLOR
		{
			get
			{
				return _backcolor;
			}
			set
			{
				_backcolor = value;
				foreach(RadioButtonSingle r in _buttons)
					r.BACKCOLOR = value;
			}
		}

		public override Color FORECOLOR
		{
			get
			{
				return _forecolor;
			}
			set
			{
				_forecolor = value;
				foreach(RadioButtonSingle r in _buttons)
					r.FORECOLOR = value;
			}
		}

		public override float HEIGHT
		{
			get
			{
				return base.HEIGHT;
			}
			set
			{
				base.HEIGHT = value;
				foreach(RadioButtonSingle b in _buttons) 
				{
					if(RADIOBUTTONSORIENTATION == RadioButtonsOrientation.horizontal) 
						b.HEIGHT = this.HEIGHT - 2;
					else
						b.HEIGHT = 5;
				}
			}
		}

		public override float WIDTH
		{
			get
			{
				return base.WIDTH;
			}
			set
			{
				base.WIDTH = value;
				float iCount =  _buttons.Length;					// Anzahl der RBs
				float step = (this.WIDTH - 1) / iCount;					// Abstand zwischen die Buttons
				foreach(RadioButtonSingle b in _buttons) 
				{
					if(RADIOBUTTONSORIENTATION == RadioButtonsOrientation.horizontal) 
						b.WIDTH = step;
					else
						b.WIDTH = this.WIDTH - 2;
				}
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// RadioButtons als XML speichern
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("RadioButtons");
			base.SaveElement (w);
			w.WriteAttributeString("RADIOBUTTONSORIENTATION",			RADIOBUTTONSORIENTATION.ToString());
			foreach(RadioButtonSingle r in _buttons) 
			{
				r.SaveElement(w);
			}
			w.WriteEndElement();

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Radiobuttons als XML laden und die RadiobuttonSingle Elemente generieren
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void LoadElement(System.Xml.XmlNode node)
		{
			base.LoadElement (node);
			this.RADIOBUTTONSORIENTATION = GetRadioButtonsOrientation(node, "RADIOBUTTONSORIENTATION");
			XmlNodeList childs = node.ChildNodes;
			
			foreach(XmlNode n in childs)				// Radiobuttonssingle einfügen
			{
				Object o =  Activator.CreateInstance(Type.GetType("FormularGen." + n.Name));
				IPageElement e = (IPageElement)o;
				e.LoadElement(n);
				this.AddButton(e);
			}
		}

		public override void SaveElementData(XmlWriter w)
		{
			StringBuilder sb = new StringBuilder();
			foreach(RadioButtonSingle b in _buttons)
			{
				if(b.SELECTED)
					sb.Append("1");
				else
					sb.Append("0");
			}
			STRINGVALUE = sb.ToString();
			base.SaveElementData (w);
		}

		public override void LoadElementData(XmlNode node)
		{
			int iCount = 0;
			base.LoadElementData (node);
			foreach(char c in STRINGVALUE.ToCharArray())
			{
				if(iCount > _buttons.Length-1)
					break;
				_buttons[iCount].SELECTED = c == '1' ? true : false;
				iCount++;
			}
		}


	}

	public class RadioButtonText
	{
		public string TEXT;
		public float  VALUE;
		public RadioButtonText(string sText, float fValue)
		{
			TEXT = sText;
			VALUE = fValue;
		}
	}

	public enum RadioButtonsOrientation 
	{
		horizontal,
		vertical
	}
}
