using System;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Drawing.Imaging;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ImageHelper.
	/// </summary>
	public class ImageHelper
	{
		public ImageHelper()
		{
			
		}

		public static void WriteBitmapToXmlWriter(Bitmap b, XmlWriter w)
		{
			if(b == null)
				return;

			using(MemoryStream ms = new MemoryStream()) 
			{
				b.Save (ms, ImageFormat.Jpeg);
				
				byte[] bmpBytes = ms.GetBuffer();
				w.WriteBase64(bmpBytes, 0,  (int)ms.Length);
				ms.Close();
			}
		}

		public static Bitmap GetBitmapFromSavedImageNode(XmlNode node) 
		{
			if(node.InnerText.Length == 0)
				return null;
			byte[] ab = Convert.FromBase64String(node.InnerText);
			MemoryStream ms = new MemoryStream(ab);
			Bitmap b = (Bitmap) Bitmap.FromStream(ms);
			return b;
		}
	}
}
