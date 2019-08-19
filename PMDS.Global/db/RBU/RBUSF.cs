using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;



namespace RBU
{

    public class RBUSF
    {

        public static User _user = new User();

        



        public RBUSF()
        {

        }




        public static string ConvertByteArrayToHEXString(byte[] b, long il)
        {
            StringBuilder sb = new StringBuilder();
            string s = "";
            for (long i = 0; i < il; i++)
            {
                s = Convert.ToString(b[i], 16);
                if (s.Length < 2)
                    sb.Append("0");
                sb.Append(s);
            }
            return sb.ToString().ToUpper();
        }

        public static byte[] ConvertHEXStringToByteArray(string s)
        {
            int il = s.Length / 2;                      
            if ((s.Length % 2) != 0)
            {                            
                throw new Exception("RBU::ConvertHEXStringToByteArray() - only even Count of Charactars allowed:");
            }
            byte[] b = new byte[il];
            for (int i = 0; i < il; i++)     
            {
                b[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }
            return b;
        }

        public static string DE(string sHEX, string keyIV)
        {
            string sIV;
            if (keyIV.Length == 0)
                sIV = "*FEHLER*";
            else
                sIV = keyIV;

            if (sIV.Length < 8)                   
            {
                int z = 8 - sIV.Length;
                for (int i = 0; i < z; i++)
                    sIV += "*";
            }

            byte[] b = RBUSF.ConvertHEXStringToByteArray(sHEX);   
            byte[] b1 = new Byte[2048];
            DESCryptoServiceProvider d1 = new DESCryptoServiceProvider();
            MemoryStream s1 = new MemoryStream(b1, 0, b1.Length);

            CryptoStream st = new CryptoStream(s1, d1.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes("*FEHLER*"), ASCIIEncoding.ASCII.GetBytes(sIV)), CryptoStreamMode.Write);
            st.Write(b, 0, b.Length);
            st.FlushFinalBlock();
            st.Flush();
            int pos = (int)s1.Position;
            st.Close();
            s1.Close();
            return ASCIIEncoding.ASCII.GetString(b1, 0, pos);
        }
        public static double ConvertStringToDouble(string sInput)
        {
            double dblRet = 0;
            try
            {
                dblRet = Convert.ToDouble(sInput);
            }
            catch
            {
                dblRet = 0;
            }
            return dblRet;
        }

        public static int ConvertStringToInt(string sInput)
        {
            int iRet = 0;
            try
            {
                iRet = Convert.ToInt32(sInput);
            }
            catch
            {
                iRet = 0;
            }
            return iRet;
        }

        public static string ConvertDoubleToString(double dblInput, int iPrecision)
        {
            string sRet;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{0:###,##0.");
                for (int f = 0; f < iPrecision; f++)
                    sb.Append("0");
                sb.Append("}");
                sRet = string.Format(sb.ToString(), dblInput);
                return sRet;
            }
            catch
            {
                return "0,00";
            }
        }

    }

}

