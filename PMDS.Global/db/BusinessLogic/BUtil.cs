using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.IO;

using PMDS.DB;
using PMDS.Global;



namespace PMDS.BusinessLogic
{


	public class BUtil
	{
		static BUtil()
		{
		}



		public static string CryptString(string str)
		{
			MD5CryptoServiceProvider prov = new MD5CryptoServiceProvider();
			byte[] data = Encoding.ASCII.GetBytes(str);
			byte[] b = prov.ComputeHash(data);
			return RBU.RBUSF.ConvertByteArrayToHEXString(b, b.Length);
		}

        public static string EncryptString(string str)
        {
            qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
            return Encryption1.StringEncrypt(str, "*engineering_");  //nicht ändern!! Texte in der DB und Config sind damit verschlüsselt
        }

        public static string DecryptString(string str)
        {
            qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
            return Encryption1.StringDecrypt(str,"*engineering_"); //nicht ändern!! Texte in der DB und Config sind damit verschlüsselt
        }

        public static Image ImageFromArray(byte[] bImage, bool bGCCollect)
		{
            //MemoryStream s = new MemoryStream(date);
            //return Image.FromStream(s);

            try
            {
                Image image;

                if (bImage != null)
                {
                    if (bGCCollect)
                    {
                        System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.WaitForFullGCComplete();
                        GC.Collect();
                    }

                    using (MemoryStream s = new MemoryStream(bImage))
                    {
                        image = (Image) Image.FromStream(s);
                        return image;
                    }
                }
                else
                    return null;

            }
            catch (OutOfMemoryException)
            {
                //nach einer Garbage-Collection nocheinmal probieren
                //wenn es weiter nicht klappt -> Exception
                System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.WaitForFullGCComplete();
                GC.Collect();

                Image image;
                if (bImage != null)
                {
                    using (MemoryStream s = new MemoryStream(bImage))
                    {
                        image = Image.FromStream(s);
                        return image;
                    }
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
		}

		public static byte[] ImageToArray(Image i)
		{
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(i, typeof(byte[]));


   //         MemoryStream s = new MemoryStream();
			//i.Save(s, i.RawFormat);
			//return s.ToArray();
		}

        public static bool CheckLicense (string strCheck)
        {
            //#Param1#Param2#Param3
            strCheck = "#" + strCheck.Trim().ToLower() + "#";
            return (ENV.License.ToLower().Contains(strCheck));
        }

        public static string GetLicenseValues(string strCheck)
        {
            //#Parm1=10#Param2=ja#Param3=2018-04-23 00:00:00#
            string[] aParam = ENV.License.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sParam in aParam)
            {
                string[] vParam = sParam.Split(new char[] { '=' }, 2);
                if (vParam.Length == 2)
                {
                    if (vParam[0].Equals(strCheck, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return vParam[1];
                    }
                }
            }
            return "";
        }
    }
}
