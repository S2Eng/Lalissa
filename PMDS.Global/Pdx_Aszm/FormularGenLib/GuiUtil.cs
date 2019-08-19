using System;
using System.Windows.Forms;

namespace FormularGen
{
	/// <summary>
	/// Summary description for GuiUtil.
	/// </summary>
	public class GuiUtil
	{
		public GuiUtil()
		{
			
		}

		public static string GetPictureFilename(string sInitDir) 
		{
			string sOldDir = Environment.CurrentDirectory;
			OpenFileDialog dlgOpenPicture = new OpenFileDialog();
			dlgOpenPicture.Filter = "JPG|*.jpg|JPEG|*.jpeg|Bitmap|*.bmp|Gif|*.gif|TIF|*.tif";
			dlgOpenPicture.InitialDirectory = sInitDir;
			try 
			{
				dlgOpenPicture.InitialDirectory = ".\\";
				DialogResult res =  dlgOpenPicture.ShowDialog();
			
				if(res != DialogResult.OK)
					return "";

				string sFile = dlgOpenPicture.FileName;
				return sFile;
			}
			finally
			{
				Environment.CurrentDirectory = sOldDir;
			}
		}

	}
}
