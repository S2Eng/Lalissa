using System;
using System.Collections.Specialized;



namespace RBU
{

    
    public class CommandLineCollection : NameValueCollection
    {



        public CommandLineCollection(string sDelimiter)
        {
            try
            {
                string[] sa = Environment.GetCommandLineArgs();

                string sKey = "";
                string sValues = "";
                foreach (string s in sa)                             
                {

                    if (s.StartsWith(sDelimiter))              
                    {
                        if (sKey.Length == 0)                       
                        {
                            sKey = s.Substring(sDelimiter.Length);
                            continue;
                        }
                        else                                      
                        {
                            this.Add(sKey.ToUpper(), sValues);
                            sKey = s.Substring(sDelimiter.Length);
                            sValues = "";
                        }
                    }
                    else
                    {
                        if (sKey.Length > 0)                                	
                            sValues += s + " ";

                    }
                }

                if (sKey.Length > 0)                                  
                {
                    this.Add(sKey.ToUpper(), sValues);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " CommandLineCollection::CommandLineCollection()", ex);
            }
        }

        public string Values(string sKey)
        {
            try
            {
                string sReturn = this[sKey.ToUpper()];

                if (sReturn == null)
                    return "";
                else
                    return sReturn.Trim();
            }
            catch
            {
                return "";
            }
        }

        public bool ExistKey(string sKey)
        {
            try
            {
                string sReturn = this[sKey.ToUpper()];
                if (sReturn == null)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
