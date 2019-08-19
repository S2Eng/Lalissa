using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Reflection;

namespace FormularGen
{
	/// <summary>
	/// Summary description for PageElementBase.
	/// </summary>
	public class PageElementBase : IPageElement
	{

		protected string				_text="";
		protected float					_value;
		protected Color					_backcolor = Color.White;
		protected Color					_forecolor = Color.Black;
		protected bool					_bold;
		protected bool					_italic;
		protected string				_font = "Arial";
		protected float					_fontemsize = 3.5f;		// millimeter
		protected float					_width;
		protected float					_height;
		protected float					_left;
		protected float					_top;
		protected string				_stringvalue = "";
		protected string				_fieldname = "";
		protected bool					_border = false;
		protected float					_lineThickness = 0.1f;
		protected DashStyle				_dashstyle = DashStyle.Solid;

		public PageElementBase()
		{
		
		}

		public virtual bool			ReadOnly		{ get {return false;}			set	{}}
		public virtual string		TEXT			{ get {return _text;}			set {_text = value;	}}
		public virtual float		VALUE			{ get {return _value;}			set {_value = value;}}
		public virtual bool			BOLD			{ get {return _bold;}			set	{_bold = value;}}
		public virtual bool			ITALIC			{ get {return _italic;}			set	{_italic = value;}}
		public virtual float		SUM_VALUE		{ get {return 0;}				set {}}
		public virtual float		FONTEMSIZE		{ get {return _fontemsize;}		set {_fontemsize = value;}}
		public virtual string		FONT			{ get {return _font;}			set {_font = value;}}
		public virtual Color		BACKCOLOR		{ get {return _backcolor;}		set {_backcolor = value;}}
		public virtual Color		FORECOLOR		{ get {return _forecolor;}		set {_forecolor = value;}}
		public virtual string		STRINGVALUE		{ get {return _stringvalue;}	set {_stringvalue = value;}}
		public virtual string		FIELDNAME		{ get {return _fieldname;}		set {_fieldname = value;}}
		public virtual string		DBFIELD			{ get {return null;}}
		public virtual float		WIDTH			{ get {return _width;}			set {_width = value;}}			/// Breite in millimeter
		public virtual float		HEIGHT			{ get {return _height;}			set {_height = value;}}			/// Höhe in millimeter
		public virtual float		TOP				{ get {return _top;}			set {_top = value;}}			/// TOP in millimeter
		public virtual float		LEFT			{ get {return _left;}			set {_left = value;}}			/// Left in  millimeter
		public virtual bool			BORDER			{ get {return _border;}			set	{_border = value;}}			// Rahmen JN
		public virtual float		LINETHICKNESS	{ get {return _lineThickness;}	set {_lineThickness = value;}}	/// Stärke der Linie in mm
		public virtual DashStyle	DASHSTYLE		{ get {return _dashstyle ;}		set {_dashstyle = value;}}	/// Strichart


		//--------------------------------------------------------------------------------
		/// <summary>
		/// PrintContent muss überschrieben werden sonst exception
		/// </summary>
		//--------------------------------------------------------------------------------
		public virtual void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{
			if(BORDER)
			{
				Pen p = new Pen(FORECOLOR, LINETHICKNESS);
				p.DashStyle = DASHSTYLE;
				g.DrawRectangle(p, xoffset*zoom, yoffset*zoom, (WIDTH-LINETHICKNESS)*zoom, (HEIGHT-LINETHICKNESS)*zoom);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Grundsätzliche Elemente sichern
		/// </summary>
		//--------------------------------------------------------------------------------
		public virtual void SaveElement(XmlWriter w)
		{
			w.WriteAttributeString("TEXT",			TEXT.ToString());
			w.WriteAttributeString("VALUE",			VALUE.ToString());
			w.WriteAttributeString("BACKCOLOR", 	BACKCOLOR.ToArgb().ToString());
			w.WriteAttributeString("FORECOLOR", 	FORECOLOR.ToArgb().ToString());
			w.WriteAttributeString("FONT",			FONT.ToString());
			w.WriteAttributeString("FONTEMSIZE",	FONTEMSIZE.ToString());
			w.WriteAttributeString("FIELDNAME",		FIELDNAME.ToString());
			w.WriteAttributeString("WIDTH",			WIDTH.ToString());
			w.WriteAttributeString("HEIGHT",		HEIGHT.ToString());
			w.WriteAttributeString("TOP",			TOP.ToString());
			w.WriteAttributeString("LEFT",			LEFT.ToString());
			w.WriteAttributeString("BOLD",			BOLD.ToString());
			w.WriteAttributeString("ITALIC",		ITALIC.ToString());
			w.WriteAttributeString("BORDER",		BORDER.ToString());
			w.WriteAttributeString("LINETHICKNESS",	LINETHICKNESS.ToString());
			w.WriteAttributeString("DASHSTYLE",		DASHSTYLE.ToString());
		}

		public virtual void SaveElementData(XmlWriter w) 
		{
			if(_fieldname == "")
				return;
			w.WriteStartElement("Value");
			w.WriteAttributeString("FIELDNAME",	_fieldname);
			w.WriteString(STRINGVALUE);
			w.WriteEndElement();
		}

		public static int GetIntValue(XmlNode node, string sKey) 
		{
			try 
			{
				return (int)Convert.ToInt64( node.Attributes[sKey].Value);
			}
			catch
			{
				return 0;
			}
		}

		public static bool GetBoolValue(XmlNode node, string sKey) 
		{
			try 
			{
				bool bRet = node.Attributes[sKey].Value.ToUpper() == "TRUE" ? true : false;
				return bRet;
			}
			catch
			{
				return false;
			}
		}

		public static float GetFloatValue(XmlNode node, string sKey) 
		{
			try 
			{
				return (float)Convert.ToDouble( node.Attributes[sKey].Value);
			}
			catch
			{
				return 0.0f;
			}
		}

		public static string GetStringValue(XmlNode node, string sKey) 
		{
			try 
			{
				return node.Attributes[sKey].Value;
			}
			catch
			{
				return "";
			}
		}

		public static Color GetColorValue(XmlNode node, string sKey) 
		{
			return Color.FromArgb( GetIntValue(node, sKey));
		}

		public static DashStyle GetDashStyle(XmlNode node, string sKey) 
		{
			try 
			{
				string s = GetStringValue(node, sKey);
				DashStyle st = (DashStyle)Enum.Parse(typeof(DashStyle), s, true);
				return st;
			}
			catch
			{
				return DashStyle.Solid;
			}
		}

		public static RadioButtonsOrientation GetRadioButtonsOrientation(XmlNode node, string sKey) 
		{
			try 
			{
				string s = GetStringValue(node, sKey);
				RadioButtonsOrientation ro = (RadioButtonsOrientation)Enum.Parse(typeof(RadioButtonsOrientation), s, true);
				return ro;
			}
			catch
			{
				return RadioButtonsOrientation.vertical;
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Grundsätzliche Elemente laden
		/// </summary>
		//--------------------------------------------------------------------------------
		public virtual void LoadElement(XmlNode node) 
		{
			XmlAttributeCollection c = node.Attributes;
			this.TEXT			= GetStringValue	(node, "TEXT");
			this.VALUE			= GetFloatValue		(node, "VALUE");
			this.BACKCOLOR		= GetColorValue		(node, "BACKCOLOR");
			this.FORECOLOR		= GetColorValue		(node, "FORECOLOR");
			this.FONT			= GetStringValue	(node, "FONT");
			this.FONTEMSIZE		= GetFloatValue		(node, "FONTEMSIZE");
			this.FIELDNAME		= GetStringValue	(node, "FIELDNAME");
			this.WIDTH			= GetFloatValue		(node, "WIDTH");
			this.HEIGHT			= GetFloatValue		(node, "HEIGHT");
			this.TOP			= GetFloatValue		(node, "TOP");
			this.LEFT			= GetFloatValue		(node, "LEFT");
			this.BOLD			= GetBoolValue		(node, "BOLD");
			this.ITALIC			= GetBoolValue		(node, "ITALIC");
			this.BORDER			= GetBoolValue		(node, "BORDER");
			this.LINETHICKNESS	= GetFloatValue		(node, "LINETHICKNESS");
			this.DASHSTYLE		= GetDashStyle		(node, "DASHSTYLE");

		}

		public virtual void LoadElementData(XmlNode node) 
		{
			
			STRINGVALUE =  node.InnerText == null ? "" : node.InnerText;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert den Font aus den Properties
		/// </summary>
		//--------------------------------------------------------------------------------
		public virtual Font GetFont(float zoom)
		{
			try 
			{
				FontStyle s = FontStyle.Regular;
				if(BOLD)
					s |= FontStyle.Bold;
				if(ITALIC)
					s |= FontStyle.Italic;
				Font f = new Font(FONT, FONTEMSIZE*zoom, s, GraphicsUnit.Millimeter);
				return f;
			}
			catch
			{
				return new Font("Arial", 3, GraphicsUnit.Millimeter);
			}
		}

	}
}
