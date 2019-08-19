using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using System.Text;

namespace FormularGen
{
	/// <summary>
	/// Summary description for FormularLabel.
	/// </summary>
	public class FormularClickableImage: PageElementBase
	{
		private Bitmap				_bitmap;
		private string  			_filename			= "";
		private bool				_clickable			= true;
		private ClickableImageType	_clickableimagetype = ClickableImageType.Clickable;
		private bool				_sizetofit			= true;				// Das bild wird in die verfügbare Größe angepasst

		private ArrayList		_points = new ArrayList();

		public FormularClickableImage()
		{
			
		}

		public string FILENAME 
		{
			get {return _filename;} set {_filename = value; ReloadImage();}
		}

		public bool CLICKABLE
		{
			get {return _clickable;} set {_clickable = value; }
		}

		public bool SIZETOFIT
		{
			get {return _sizetofit;} set {_sizetofit = value; }
		}

		public ClickableImageType CLICKABLEIMAGETYPE
		{
			get {return _clickableimagetype;} set {_clickableimagetype = value; CLICKABLE = CLICKABLEIMAGETYPE == ClickableImageType.Clickable;}
		}



		public Bitmap BITMAP 
		{
			get 
			{
				return _bitmap;
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Punkt in die Liste einfügen
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddPoint(PointF point)
		{
			_points.Add(point);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Punkt aus der Liste entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemovePoint(PointF point)
		{
			_points.Remove(point);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert den Punkt bei Hit oder -1,-1 bei keinem Treffer
		/// </summary>
		//--------------------------------------------------------------------------------
		public PointF HitPoint(PointF point) 
		{
			foreach(PointF p in _points)
			{
				if(point.X >= p.X-2 && point.X <= p.X + 2) 
				{
					if(point.Y >= p.Y-2 && point.Y <= p.Y + 2)
						return p;
				}
			}

			return new PointF(-1,-1);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Image neu laden
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ReloadImage()
		{
			try 
			{
				_bitmap = (Bitmap)Bitmap.FromFile(_filename);
			}
			catch{}
		}

		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Ausgabe
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void PrintContent(System.Drawing.Graphics g, FormularGenENV env, float zoom, float xoffset, float yoffset)
		{
			if(_bitmap == null) 
			{
				g.DrawString(TEXT, GetFont(zoom), Brushes.Black, xoffset, yoffset);
				return;
			}

			g.PageUnit = GraphicsUnit.Millimeter;

			float w = WIDTH;
			float h = HEIGHT;
			
			if(!SIZETOFIT)			// unter Berücksichtigung des verhältnisses das Bild drucken
			{
				float asp = (float)_bitmap.Height / (float)_bitmap.Width;
				if(asp >=1)
					w = h / asp;
				else
					h = w * asp;

				if(h > HEIGHT) 
				{
					h = HEIGHT;
					w = h / asp;
				}
				if(w > WIDTH) 
				{
					w = WIDTH;
					h = w * asp;
				}
			}
			
			g.DrawImage(_bitmap, xoffset, yoffset, w*zoom, h*zoom);

			Pen pen = new Pen(_forecolor, LINETHICKNESS*zoom);
					
			// Punkte zeichnen
			float x=0;
			float y=0;
			float x1=0;
			float y1=0;
			foreach(PointF p in _points)
			{
				x = p.X - 2;
				y = p.Y - 2;
				x1 = p.X + 2;
				y1 = p.Y + 2;
				g.DrawLine(pen, (x*zoom) + (xoffset*zoom), (y*zoom) + (yoffset*zoom), x1*zoom + (xoffset*zoom), y1*zoom + (yoffset*zoom));

				x = p.X + 2;
				y = p.Y - 2;
				x1 = p.X - 2;
				y1 = p.Y + 2;
				g.DrawLine(pen, (x*zoom) + (xoffset*zoom), (y*zoom) + (yoffset*zoom), x1*zoom + (xoffset*zoom), y1*zoom + (yoffset*zoom));
			}

			base.PrintContent(g, env, zoom, xoffset, yoffset);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Element speichern
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void SaveElement(System.Xml.XmlWriter w)
		{
			w.WriteStartElement("FormularClickableImage");
			base.SaveElement (w);
			w.WriteAttributeString("CLICKABLE", CLICKABLE.ToString());
			w.WriteAttributeString("CLICKABLEIMAGETYPE", CLICKABLEIMAGETYPE.ToString());
			w.WriteAttributeString("SIZETOFIT", SIZETOFIT.ToString());
			if(_bitmap != null) 
				ImageHelper.WriteBitmapToXmlWriter(_bitmap, w);
			w.WriteEndElement();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Element laden - im InnerText der Node müssen die Bilddaten verspeichert sein
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void LoadElement(System.Xml.XmlNode node)
		{
			base.LoadElement (node);
			CLICKABLE	= GetBoolValue(node, "CLICKABLE");
			SIZETOFIT	= GetBoolValue(node, "SIZETOFIT");
			string clit	= GetStringValue(node, "CLICKABLEIMAGETYPE");
			if(clit.Length > 0)
				CLICKABLEIMAGETYPE = (ClickableImageType)Enum.Parse(typeof(ClickableImageType), clit, true);
			_bitmap = ImageHelper.GetBitmapFromSavedImageNode(node);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen PointString im der Form X;Y#X;Y.......
		/// </summary>
		//--------------------------------------------------------------------------------
		private string GetPointAsString() 
		{
			StringBuilder sb = new StringBuilder();
			bool bFirst = true;
			foreach(PointF p in _points)
			{
				if(!bFirst) 
					sb.Append("#");
				bFirst = false;
				sb.Append(p.X.ToString());
				sb.Append(";");
				sb.Append(p.Y.ToString());
			}
			return sb.ToString();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Daten sichern
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void SaveElementData(System.Xml.XmlWriter w)
		{
			STRINGVALUE = GetPointAsString();

			w.WriteStartElement("Value");
			w.WriteAttributeString("FIELDNAME",	_fieldname);
			if(CLICKABLEIMAGETYPE == ClickableImageType.Clickable)
				w.WriteString(STRINGVALUE);
			else
				ImageHelper.WriteBitmapToXmlWriter(_bitmap, w);
			w.WriteEndElement();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen PointString im der Form X;Y#X;Y.......
		/// </summary>
		//--------------------------------------------------------------------------------
		public override void LoadElementData(System.Xml.XmlNode node)
		{
			try 
			{
				_points.Clear();

				if(CLICKABLEIMAGETYPE == ClickableImageType.Clickable) 
				{
					base.LoadElementData (node);
					string[] sb;
					string[] sa = STRINGVALUE.Split('#');
					foreach(string s in sa)
					{	
						if(s == "")			// Leere Elemente abfangen
							continue;
						sb = s.Split(';');
						PointF  p = new PointF( (float)Convert.ToDouble(sb[0]) , (float)Convert.ToDouble(sb[1])); 
						_points.Add(p);
					}
				}
				else 
				{
					_bitmap = ImageHelper.GetBitmapFromSavedImageNode(node);
				}
			}
			catch(Exception ex) {System.Windows.Forms.MessageBox.Show(ex.ToString());}
		}

	}

	public enum ClickableImageType
	{
		Clickable,
		Loadable
	}
}
