using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PMDS.Global.Other
{

    public class cConfig
    {


        public static string readConfig(string configFile, string sVarToSearch, bool searchAllDatabases, ref System.Collections.Generic.List<string> lstDatabasesActDeact)
        {
            try
            {
                string sValueFound = "";
                System.IO.StreamReader str = new System.IO.StreamReader(configFile);
                while (str.Peek() >= 0)
                {
                    string line = str.ReadLine().Trim();
                    if (line.Length > 2)
                    {
                        if ((!line.Trim().Substring(0, 2).Equals("//")) || searchAllDatabases)
                        {
                            int posEquals = line.IndexOf("=");
                            if (posEquals != -1)
                            {
                                string sVar = line.Substring(0, posEquals).Trim().ToLower();
                                string sValue = line.Substring(posEquals + 1, line.Length - (posEquals + 1)).Trim();
                                if (sVarToSearch.Trim() != "" && sVar.Trim().ToLower() == sVarToSearch.Trim().ToLower())
                                {
                                    sValueFound = sValue.Trim();
                                }

                                if (searchAllDatabases)
                                {
                                    string sVarTmp = sVar.Replace(" ", "");
                                    if (sVarTmp.Trim().ToLower() == ("DSNMain").Trim().ToLower())
                                    {
                                        lstDatabasesActDeact.Add(sVarTmp.ToUpper() + " = " + sValue.Trim());
                                    }
                                    else if (sVarTmp.Trim().ToLower() == ("//DSNMain").Trim().ToLower())
                                    {
                                        lstDatabasesActDeact.Add(sVarTmp.ToUpper() + " = " + sValue.Trim());
                                    }
                                }

                            }
                        }
                    }
                }

                str.Close();
                return sValueFound;
            }
            catch (Exception ex)
            {
                throw new Exception("cConfig.readConfig: " + ex.ToString());
            }
        }


    }

}
