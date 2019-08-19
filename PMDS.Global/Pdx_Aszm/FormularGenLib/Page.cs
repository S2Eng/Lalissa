using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Xml;
using System.Reflection;

namespace FormularGen
{
	public class Page
	{
		private PageFormat			_format = PageFormat.A4;
		private PageOrientation		_orientation = PageOrientation.Portrait;
		private Color				_backcolor = Color.White;

		private ArrayList			_aElement = new ArrayList();				// Speichert alle IPageElement in einem Array

		public Page()
		{
			
		}

		public PageFormat		FORMAT 			{ get {return _format;}			set{_format = value; }}
		public PageOrientation	ORIENTATION		{ get {return _orientation;}	set{_orientation = value;}}
		public Color			BACKCOLOR		{ get {return _backcolor;}		set{_backcolor = value;}}

		public enum PageFormat
		{
			A4,
			A3,
			A5
		}

		public enum PageOrientation
		{
			Portrait,
			Landscape
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die breite in Millimeter abhängig von der Größe und Ausrichtung
		/// </summary>
		//--------------------------------------------------------------------------------
		public float PAGEWIDTH
		{
			get 
			{
				switch(_format) 
				{
					case PageFormat.A3:
						if(_orientation == PageOrientation.Portrait)
							return 297;
						else
							return 420;
					case PageFormat.A4:
						if(_orientation == PageOrientation.Portrait)
							return 210;
						else
							return 297;

					case PageFormat.A5:
						if(_orientation == PageOrientation.Portrait)
							return 148;
						else
							return 210;
				}

				return 100;
			}

			
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die höhe in Millimeter abhängig von der Größe und Ausrichtung
		/// </summary>
		//--------------------------------------------------------------------------------
		public float PAGEHEIGHT
		{
			get 
			{
				switch(_format) 
				{
					case PageFormat.A3:
						if(_orientation == PageOrientation.Landscape)
							return 297;
						else
							return 420;
					case PageFormat.A4:
						if(_orientation == PageOrientation.Landscape)
							return 210;
						else
							return 297;
					case PageFormat.A5:
						if(_orientation == PageOrientation.Landscape)
							return 148;
						else
							return 210;
				}
				return 100;
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Summe aller Punkte der Seite
		/// </summary>
		//--------------------------------------------------------------------------------
		public float SUM_VALUE 
		{
			get
			{
				float f = 0;
				foreach(IPageElement e in _aElement)
					f += e.SUM_VALUE;
				return f;
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Hinzufügen eines Elementes
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddElement(IPageElement element) 
		{
			_aElement.Add(element);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Entfernen eines Elementes
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemoveElement(IPageElement element) 
		{
			ArrayList al = new ArrayList();
			for(int i=0; i<_aElement.Count; i++)			// Eleminieren durch Copy
			{
				if(!_aElement[i].Equals(element))
					al.Add(_aElement[i]);
			}
			_aElement = al;
		}

		public ArrayList	ELEMENTS
		{
			get 
			{
				return _aElement;
			}
		}
         
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Darstellungsroutine
		/// Alle Maßeinheiten in milimeter
		/// </summary>
		//--------------------------------------------------------------------------------
		public void PrintContent(Graphics g, float zoom, float xoffset, float yoffset) 
		{
			g.PageUnit = GraphicsUnit.Millimeter;
			SolidBrush b = new SolidBrush(_backcolor);
			Pen p = new Pen(Brushes.Black, 0.1f);

			g.FillRectangle(b,xoffset,yoffset, PAGEWIDTH*zoom, PAGEHEIGHT*zoom);

		}

		public void SavePage(XmlWriter w, int iPage)
		{
			w.WriteStartElement(string.Format("Page", iPage));
			w.WriteAttributeString("Pagenumber", iPage.ToString());
			w.WriteAttributeString("FORMAT", FORMAT.ToString());
			w.WriteAttributeString("ORIENTATION", ORIENTATION.ToString());
			w.WriteAttributeString("BACKCOLOR", BACKCOLOR.ToArgb().ToString());
			
			foreach(IPageElement e in _aElement)
				e.SaveElement(w);
 		
			w.WriteEndElement();
		}

		public void SavePageData(XmlWriter w, int iPage) 
		{
			w.WriteStartElement(string.Format("Page", iPage));
			w.WriteAttributeString("Pagenumber", iPage.ToString());
			foreach(IPageElement e in _aElement)
				e.SaveElementData(w);
 		
			w.WriteEndElement();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt die Seite auf basis einer Page XML Node
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadPage(XmlNode node) 
		{
			XmlNodeList childs = node.ChildNodes;
			
			foreach(XmlNode n in childs)
			{
				Object o =  Activator.CreateInstance(Type.GetType("FormularGen." + n.Name));
				IPageElement e = (IPageElement)o;
				e.LoadElement(n);
				this.AddElement(e);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt die Seite auf basis einer Page XML Node
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadElement(XmlNode node, float x, float y) 
		{
			XmlNodeList childs = node.ChildNodes;
			foreach(XmlNode n in childs)
			{
				Object o =  Activator.CreateInstance(Type.GetType("FormularGen." + n.Name));
				IPageElement e = (IPageElement)o;
				e.LoadElement(n);
				e.FIELDNAME = string.Format("Feld {0}", _aElement.Count + 1);
				e.LEFT	= x;
				e.TOP	= y;
				this.AddElement(e);
			}
		}

		private IPageElement FindElement(string sField)
		{
			foreach(IPageElement e in _aElement)
				if(e.FIELDNAME.ToUpper() == sField.ToUpper()) 
					return e;
			return null;
		}

		public void LoadPageData(XmlNode node) 
		{
            try
            {

                XmlNodeList childs = node.ChildNodes;
                foreach (XmlNode n in childs)
                {
                    string sField = PageElementBase.GetStringValue(n, "FIELDNAME");
                    IPageElement e = FindElement(sField);
                    if (e == null)
                        continue;
                    e.LoadElementData(n);
                }
            }
            catch
            {
               
            }

		}
	}

	public enum PageMode 
	{
		Design,
		Editable,
		Readonly
	}

	//--------------------------------------------------------------------------------
	/// <summary>
	/// Interface eines Pageelementes
	/// </summary>
	//--------------------------------------------------------------------------------
	public interface IPageElement 
	{
		void PrintContent(Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset);
		string		TEXT			{get;set;}			// Text des Elementes
		float		VALUE			{get;set;}			// Der zahlenwert
		float		SUM_VALUE		{get;set;}			// Der durch die ausgewählten Elemente representeirte Zahlenwert
		Color		BACKCOLOR		{get;set;}			// Hintergrundfarbe
		Color		FORECOLOR		{get;set;}			// Fordergrundfarbe
		string		FONT			{get;set;}			// der zu verwendende Font
		float		FONTEMSIZE		{get;set;}			// Die zu verwendende Größe
		string		STRINGVALUE 	{get;set;}			// Der Wert für die Textbox, rbSelection, PictureSelecion etc
		string		FIELDNAME		{get;set;}			// Der Feldname der auch in der DB verwendet werden soll
		string		DBFIELD			{get;}				// Liefert das für ein CreateTable notwendige Statement
		float		WIDTH			{get;set;}			// Die breite in mm
		float		HEIGHT			{get;set;}			// Die höhe in mm
		float		TOP				{get;set;}			// Die X in mm im übergeordneten Element
		float		LEFT			{get;set;}			// Die Y in mm im übergeordneten Element
		bool		BOLD			{get;set;}			// Bold
		bool		ITALIC			{get;set;}			// italic
		bool		BORDER			{get;set;}			// Border
		float		LINETHICKNESS	{get;set;}			// Die Dicke der Linie
		DashStyle	DASHSTYLE		{get;set;}			// Die Linienart

		void SaveElement(XmlWriter w);			// Das Element speichern
		void SaveElementData(XmlWriter w);		// Die Daten verspeichern
		void LoadElement(XmlNode node);			// Die Elemente aus basis einer XML Node laden
		void LoadElementData(XmlNode node);		// Element data auf basis einer Node laden
		Font GetFont(float zoom);				// Liefert den durch die Attribute representierten Font
	}
}
