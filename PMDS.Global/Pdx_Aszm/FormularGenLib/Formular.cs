using System;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System.Drawing.Printing;

namespace FormularGen
{
	/// <summary>
	/// Summary description for Fromular.
	/// </summary>
	public class Formular
	{
	
		private FormularGenENV				_env			= new FormularGenENV();
		private ArrayList					_ap				= new ArrayList();
		private string						_FormularName	= "";
		private DateTime					_creationdate	= new DateTime(1900,1,1);
		private DateTime					_changedate		= new DateTime(1900,1,1);
		private string						_usercreated = "";
		private string						_klient = "";
        private string                      _klientgebdat = "";
        private string                      _userchanged = "";
		private bool						_addpicturesallowed = false;
		private ArrayList					_abitmap = new ArrayList();

		public Formular()
		{
           
        }

		public string FORMULARNAME { get {return _FormularName;} }
		public bool ADDPICTURESALLOWED { get {return _addpicturesallowed;} set {_addpicturesallowed = value;}}

		public FormularGenENV ENV { get {return _env;} }

		public Bitmap[] BITMAPS 
		{
			get 
			{
				return (Bitmap[])_abitmap.ToArray(typeof(Bitmap));
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Eine Seite aus einer Node
		/// </summary>
		//--------------------------------------------------------------------------------
		public Page AddPage(XmlNode n) 
		{
			string format		= PageElementBase.GetStringValue(n, "FORMAT");
			string orientation	= PageElementBase.GetStringValue(n, "ORIENTATION");
			Color  c			= PageElementBase.GetColorValue(n, "BACKCOLOR");
			
			Page p = new Page();

			p.BACKCOLOR			= c;
			try 
			{
				if(format.Length > 0)
					p.FORMAT = (Page.PageFormat)Enum.Parse(typeof(Page.PageFormat), format, true);
				if(orientation.Length > 0)
					p.ORIENTATION = (Page.PageOrientation)Enum.Parse(typeof(Page.PageOrientation), orientation, true);
			}
			catch{}
			_ap.Add(p);
			return p;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Eine Seite hinzufügen
		/// </summary>
		//--------------------------------------------------------------------------------
		public Page AddPage() 
		{
			Page p = new Page();
			_ap.Add(p);
			return p;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Eine Seite entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemovePage(Page p) 
		{
			ArrayList al = new ArrayList();
			for(int i=0; i<_ap.Count; i++)			// Eleminieren durch Copy
			{
				if(!_ap[i].Equals(p))
					al.Add(_ap[i]);
			}
			_ap = al;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Seiten als Array
		/// </summary>
		//--------------------------------------------------------------------------------
		public Page[] PAGES 
		{
			get 
			{
				return (Page[])_ap.ToArray(typeof(Page));
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Environment Variablen setzen für die Page
		/// </summary>
		//--------------------------------------------------------------------------------
		public void SetPageEnvironment(int iPage) 
		{
			Page p = (Page)_ap[iPage-1];
			_env.PAGENO = iPage;
			_env.AddSumPoints(p.SUM_VALUE);

			SetExternalKeysToEnvironment();
			SetActualPrintDateTime();
		}

		 

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Seite drucken
		/// </summary>
		//--------------------------------------------------------------------------------
		public void PrintPage(int iPage, Graphics g) 
		{
			if(iPage > _ap.Count)
				return;

			if(iPage == 1)
				SetActualPrintDateTime();
			
			g.PageUnit = GraphicsUnit.Millimeter;
			Page p = (Page)_ap[iPage-1];
			
			SetPageEnvironment(iPage);

			p.PrintContent(g, 1.0f, 0,0);			// Seite drucken
			foreach(IPageElement e in p.ELEMENTS) 
			{
				e.PrintContent(g,_env, 1.0f, e.LEFT, e.TOP);
			}
		}

		public void BeginPrinting() 
		{
			_env = new FormularGenENV();					// Neues Environment für neuen Druck
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert ein Formular als String im UTF8 Format
		/// </summary>
		//--------------------------------------------------------------------------------
		public string SaveFormularToString(string FormularName) 
		{
			MemoryStream ms = new MemoryStream();
			XmlTextWriter w = new XmlTextWriter(ms, Encoding.UTF8);
			SaveFormular(w, FormularName);
			w.Flush();
			byte[] ab = ms.GetBuffer();
			string s = new string(Encoding.UTF8.GetChars(ab, 1, (int)ms.Length-1));
            // 7.4.2008: RBU: Workaround für KB928365: Securityupdate .NET 2.0 produziert hier einen Fehler in den ersten 2 Bytes ??? bei GetBuffer......
            if (s[0] == 65533 && s[1] == 65533)
                s = s.Substring(2);
			return s;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Speichert ein Formular in einen XMLWriter
		/// </summary>
		//--------------------------------------------------------------------------------
		public void SaveFormular(XmlWriter w, string FormularName) 
		{
			w.WriteStartDocument();
			w.WriteStartElement("FORMULAR");
			w.WriteAttributeString("NAME", FormularName);
			w.WriteAttributeString("ADDPICTURESALLOWED", ADDPICTURESALLOWED.ToString());
			int iCount = 1;
			foreach(Page p in _ap)
			{
				p.SavePage(w, iCount++);
			}
			w.WriteEndElement();
			w.WriteEndDocument();
			this._FormularName = FormularName;
		}

		private string GetDateString(DateTime t)
		{
			return t.Ticks.ToString();
		}

		private DateTime GetDateFromString( string sDateTicks)
		{
			try 
			{
				long ticks = (long)Convert.ToInt64(sDateTicks);
				DateTime t = new DateTime(ticks);
				return t;
			}
			catch
			{
				return new DateTime(1900,1,1);
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert Die Formulardaten als String im UTF8 Format
		/// </summary>
		//--------------------------------------------------------------------------------
		public string SaveFormularDataToString(Guid KeyRef, string sUser, string sKlient, string sKlientGebDat) 
		{
			MemoryStream ms = new MemoryStream();
			XmlTextWriter w = new XmlTextWriter(ms, Encoding.UTF8);
			SaveFormularData(w, KeyRef, sUser, sKlient, sKlientGebDat);
            //SaveFormularData(w, KeyRef, sUser);
            w.Flush();
			byte[] ab = ms.GetBuffer();
			string s = new string(Encoding.UTF8.GetChars(ab, 1, (int)ms.Length-1));
            // 7.4.2008: RBU: Workaround für KB928365: Securityupdate .NET 2.0 produziert hier einen Fehler in den ersten 2 Bytes ???
            if (s[0] == 65533 && s[1] == 65533)
                s = s.Substring(2);
			return s;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Speichert die Formulardate in einen XMLWriter
		/// </summary>
		//--------------------------------------------------------------------------------
		public void SaveFormularData(XmlWriter w, Guid KeyRef, string sUser, string sKlient, string sKlientGebDat)
		{
			if(_creationdate.Year == 1900)
				_creationdate = DateTime.Now;
			_changedate = DateTime.Now;

			if(_usercreated == "")
				_usercreated = sUser;
			_userchanged = sUser;

			w.WriteStartDocument();
			w.WriteStartElement("FORMULARDATA");
			w.WriteAttributeString("FORMULAR", FORMULARNAME);
			w.WriteAttributeString("KEYREF", KeyRef.ToString());
			w.WriteAttributeString("USER", sUser);
			w.WriteAttributeString("CREATED", GetDateString(_creationdate));
			w.WriteAttributeString("CHANGED", GetDateString(_changedate));
			w.WriteAttributeString("USERCREATED", _usercreated);
            w.WriteAttributeString("KLIENT", sKlient);
            w.WriteAttributeString("KLIENTGEBDAT", sKlientGebDat);
			w.WriteAttributeString("USERCHANGED", _userchanged);

			int iCount = 1;
			foreach(Page p in _ap)
			{
				p.SavePageData(w, iCount++);
			}
			

			// Image Daten speichern
			
			foreach(Bitmap b in _abitmap)
			{
				w.WriteStartElement("IMAGEDATA");	
				ImageHelper.WriteBitmapToXmlWriter(b, w);
				w.WriteEndElement();
			}
			w.WriteEndElement();			
			w.WriteEndDocument();
			
		}
		
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt ein Formular aus einen UTF8 codierten String
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFromularFromString(string sFormularBlob)
		{
			byte[] ab = Encoding.UTF8.GetBytes(sFormularBlob);
			MemoryStream ms = new MemoryStream(ab);
			LoadFormular(ms);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt ein Formular aus einer übergebenen Datei
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFormular(string sFilename) 
		{
			using(FileStream s = new FileStream(sFilename, FileMode.Open)) 
			{
				LoadFormular(s);
			}
			
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt ein Formular aus einem Stream
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFormular(Stream s) 
		{

			XmlDocument d = new XmlDocument();
			d.Load(s);
			LoadAllPages(d);		
			XmlNodeList form = d.GetElementsByTagName("FORMULAR");
			XmlNode formular = form[0];
			string frmname = PageElementBase.GetStringValue(formular, "NAME");
			ADDPICTURESALLOWED = PageElementBase.GetBoolValue(formular, "ADDPICTURESALLOWED");
			this._FormularName = frmname;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten laden
		/// </summary>
		//--------------------------------------------------------------------------------
		private void LoadAllPages(XmlDocument d) 
		{
			XmlNodeList pages = d.GetElementsByTagName("Page");

			foreach(XmlNode n in pages)
			{
				Page p = this.AddPage(n);
				p.LoadPage(n);
			}

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten laden
		/// </summary>
		//--------------------------------------------------------------------------------
		private void LoadAllImagesData(XmlDocument d) 
		{
			XmlNodeList images = d.GetElementsByTagName("IMAGEDATA");

			foreach(XmlNode n in images)
			{
				_abitmap.Add( ImageHelper.GetBitmapFromSavedImageNode(n));				
			}

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Externe Keys ins Environment
		/// </summary>
		//--------------------------------------------------------------------------------
		private void SetExternalKeysToEnvironment() 
		{
			_env.SetExternalKey("#DATECREATED#", _creationdate.ToShortDateString());
			_env.SetExternalKey("#DATECHANGED#", _changedate.ToShortDateString());
			_env.SetExternalKey("#TIMECREATED#", _creationdate.ToShortTimeString());
			_env.SetExternalKey("#TIMECHANGED#", _changedate.ToShortTimeString());
			_env.SetExternalKey("#USERCHANGED#", _userchanged);
			_env.SetExternalKey("#USERCREATED#", _usercreated);
            _env.SetExternalKey("#KLIENT#", _klient);
            _env.SetExternalKey("#KLIENTGEBDAT#", _klientgebdat);
			int iCount = 1;
			foreach(Page p in _ap) 
			{
				_env.SetExternalKey(string.Format("#PAGESUM{0}#", iCount.ToString()), p.SUM_VALUE.ToString());
				iCount++;
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Aktuelle Datum / Uhrzeit ins Environment
		/// </summary>
		//--------------------------------------------------------------------------------
		private void SetActualPrintDateTime() 
		{
            
            _env.SetExternalKey("#PRINTDATE#", DateTime.Now.ToShortDateString());
			_env.SetExternalKey("#PRINTTIME#", DateTime.Now.ToShortTimeString());
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt ein Formular aus einen UTF8 codierten String
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFromularDataFromString(string sFormularDataBlob)
		{
			byte[] ab = Encoding.UTF8.GetBytes(sFormularDataBlob);
			MemoryStream ms = new MemoryStream(ab);
			LoadFormularData(ms);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt die Formulardaten aus einer übergebenen Datei
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFormularData(string sFileName)
		{
			using(FileStream s = new FileStream(sFileName, FileMode.Open))
			{
				LoadFormularData(s);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Lädt die Formulardaten aus einem Stream
		/// </summary>
		//--------------------------------------------------------------------------------
		public void LoadFormularData(Stream s)
		{
			_abitmap.Clear();							// eventuell vorhandene Bilder leeren

			XmlDocument d = new XmlDocument();
			d.Load(s);
			XmlNodeList pages = d.GetElementsByTagName("Page");
			XmlNodeList formulardata = d.GetElementsByTagName("FORMULARDATA");
			
			
			if(formulardata.Count == 0)
				throw new FormularLoadException("Der erwartete TAG FORMULARDATA ist nicht vorhanden");

			XmlNode formular = formulardata[0];
			string frmname = PageElementBase.GetStringValue(formular, "FORMULAR");
			if(frmname.ToUpper() != FORMULARNAME.ToUpper())
				throw new FormularLoadException(string.Format("Die Daten des Formulares sind die eines anderen Formulares {0} != {1}",frmname, FORMULARNAME ));

			string DateTicksCreated = PageElementBase.GetStringValue(formular, "CREATED");
			string DateTicksChanged = PageElementBase.GetStringValue(formular, "CHANGED");
			_usercreated			= PageElementBase.GetStringValue(formular, "USERCREATED");
            _klient                 = PageElementBase.GetStringValue(formular, "KLIENT");
            _klientgebdat           = PageElementBase.GetStringValue(formular, "KLIENTGEBDAT");
			_userchanged			= PageElementBase.GetStringValue(formular, "USERCHANGED");
			_changedate = GetDateFromString(DateTicksChanged);
			_creationdate = GetDateFromString(DateTicksCreated);

			
			SetExternalKeysToEnvironment();

			foreach(XmlNode n in pages)
			{
				int index = PageElementBase.GetIntValue(n, "Pagenumber") - 1;
				if(index < 0 || index > _ap.Count-1) 
					throw new FormularLoadException("Die Seitennummer der Daten stimmt nicht mit dem Formular überein");

				Page p = (Page)_ap[index];
				p.LoadPageData(n);
			}

			LoadAllImagesData(d);			// Imagedaten laden
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Fügt ein Image aus einer Datei dem Formular hinzu.
		/// Diese images werden in den Daten gespeichert
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddImage(string sFileName) 
		{
			try 
			{
				Bitmap bitmap = (Bitmap)Bitmap.FromFile(sFileName);
				_abitmap.Add(bitmap);
			}
			catch{}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Fügt ein Image aus einem Stream dem Formular hinzu.
		/// Diese images werden in den Daten gespeichert
		/// </summary>
		//--------------------------------------------------------------------------------
		private void AddImage(Stream s) 
		{
			Bitmap bitmap = (Bitmap)Bitmap.FromStream(s);
			_abitmap.Add(bitmap);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Entfernt die übergebene Bitmapreferenz
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemoveImage(Bitmap b)
		{
			_abitmap.Remove(b);
		}
	}

	public class FormularLoadException : Exception 
	{
		public FormularLoadException(string sText) : base(sText)
		{
		}
	}
}
