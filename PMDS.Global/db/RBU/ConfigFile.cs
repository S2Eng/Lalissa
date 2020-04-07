using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.Text;



namespace RBU
{

    

    public class ConfigFile : System.Collections.Specialized.NameValueCollection
    {
        private string m_sConfigFile;
        private bool m_bIgnoreFileNotFound;




        public ConfigFile(string sConfigFile, bool bIgnoreFileNotFound)
        {
            m_bIgnoreFileNotFound = bIgnoreFileNotFound;
            m_sConfigFile = sConfigFile;
            ReadConfigFromFile();
        }

        public ConfigFile(string sConfigFile) : this(sConfigFile, false)
        {

        }

        public void ReadConfigFromFile()
        {
            if (m_bIgnoreFileNotFound)    
            {
                if (!File.Exists(m_sConfigFile))
                {
                    FileStream fhandle;
                    fhandle = File.Create(m_sConfigFile);
                    fhandle.Close();
                }
            }

            StreamReader r = new StreamReader(m_sConfigFile, Encoding.Default);
            int iCount = 0;
            string s;
            string[] sa;
            while (r.Peek() > -1)
            {
                iCount++;
                s = r.ReadLine().Trim();
                if (s.Length == 0)                                 
                {
                    this.Add(string.Format("LXXXX{0}", iCount.ToString()), "");
                    continue;
                }

                if (s.Trim().Substring(0, 1) == "/")                    
                {
                    this.Add(string.Format("LXXXX{0}", iCount.ToString()), s);
                    continue;
                }

                sa = s.Split('=');
                if (sa.Length == 2)
                {
                    this.Add(sa[0].Trim().Replace("\t", ""), sa[1].Trim());
                    continue;
                }
                else
                {
                    if (sa.Length > 2)                  
                    {
                        string sRest = s.Substring(s.IndexOf("=") + 1).Trim();
                        this.Add(sa[0].Trim().Replace("\t", ""), sRest);
                    }
                    else
                    {
                        this.Add(string.Format("LXXXX{0}", iCount.ToString()), s);
                        continue;
                    }
                }
            }
            r.Close();
        }

        public double GetDoubleValue(string sKey)
        {
            try
            {
                return RBUSF.ConvertStringToDouble(this[sKey]);
            }
            catch
            {
                return 0;
            }
        }

        public string GetStringValue(string sKey)
        {
            try
            {
                if (this[sKey] != null)
                    return this[sKey].ToString();
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

    }

}

