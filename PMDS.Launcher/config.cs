using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace Launcher
{

    
    public class config
    {

        public static string configFile  = "";
        public static dsConfig dsconfigAll;
        public static string configRootPath = "";

        

        public   config()
        {
            Launcher.config.dsconfigAll = new dsConfig();
            Launcher.config.configFile = System.IO.Path.Combine(Application.StartupPath,"Launcher.config"); 
        }


        public bool readAll()
        {
            if (!System.IO.File.Exists(Launcher.config.configFile))
            {
                MessageBox.Show("Launcher.config nicht gefunden. Bitte kontaktieren Sie Ihren Administrator.", "Launcher wird beendet!");
                return false;
            }
            else
            {
                StreamReader reader = NewMethod();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrWhiteSpace(line) || line.Substring(0, 2).Trim() == "//" || line.Substring(0, 1).Trim() == "[")                          // Leerzeile
                        continue;

                    string[] par = line.Split(new char[] { '=' }, 2);

                    if (par.Length < 2)
                    {
                        MessageBox.Show("Starteintrag in launcher.config ohne '=' gefunden: " + line.Trim(), "Launcher wird beendet!");
                        return false;
                    }

                    dsConfig.configRow rNew = (dsConfig.configRow)Launcher.config.dsconfigAll.config.NewRow();

                    rNew.key = par[0].Trim();
                    rNew.val = par[1].Trim();
                    Launcher.config.dsconfigAll.config.Rows.Add(rNew);
                }
                reader.Close();
                return true;
            }
        }

        private static StreamReader NewMethod()
        {
            return new System.IO.StreamReader(Launcher.config.configFile);
        }

        public string getKey (string keySearch)
        {
            dsConfig.configRow[] arrRow = (dsConfig.configRow[])Launcher.config.dsconfigAll.config.Select("key = '" + keySearch + "'");
            if (arrRow.Length > 0)
                return arrRow[0].val;
            else
                return "";
        }

        public string searchKeyArg(string keySearch, string args)
        {
            bool apport = false;
            int posLast = 0;
            int posLastLast = 0;

            keySearch = keySearch.ToUpper();
            args = args.ToUpper();

            while (!apport)
            {
                posLast = args.IndexOf("?", posLast);
                if (posLast == -1)
                    return "";

                posLastLast = args.IndexOf("?", posLast + 1);
                string defVar = args.Substring(posLast, posLastLast == -1 ? args.Length - posLast : posLastLast - posLast).Trim();

                int posEquals = defVar.IndexOf("=");
                if (posEquals == -1)
                    throw new Exception("Fehler Variable Argument in launcher.config ohne '='");
                else
                {
                    string key = ((string)defVar.Substring(0, posEquals)).Trim();
                    string val = ((string)defVar.Substring(posEquals + 1, defVar.Length - (posEquals + 1))).Trim();
                    if (key.Trim() == "?" + keySearch.Trim())
                        return val;
                }

                if (posLastLast == -1)
                    return "";
                else
                    posLast = posLastLast - 1;
            }
            return "";
        }

        public string getProgramRoot(string prgPath)
        {
            return prgPath.Substring(0, prgPath.LastIndexOf("\\"));
        }


        public string getProgramRootRoot(string prgPath)
        {
            string pathRoot = getProgramRoot(prgPath);
            return getProgramRoot(pathRoot);
        }
    }
}
