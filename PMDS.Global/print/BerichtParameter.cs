using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using PMDS.Print.CR;


namespace PMDS.Global
{

    //----------------------------------------------------------------------------
    /// <summary>
    /// XML ReportdefinitionManager
    /// Laden aus und speichern nach XML Datei
    /// </summary>
    //----------------------------------------------------------------------------
    public class DynReportDefinition
    {
        private string                      _Reportinfo     = "";
        List<BerichtParameter>              _list           = new List<BerichtParameter>();
        List<Guid>                          _BenutzerListe  = new List<Guid>();
        private string                      _FormToLoad     = "";
        private string                      _FormAssembly   = "";
        private string                      _DatasetAssemly = "";
        private List<BerichtDatenquelle>    _DataSources    = new List<BerichtDatenquelle>();
        private string                      _Displayname    = "";

        public DynReportDefinition(string ReportInfo)
        {
            _Reportinfo = ReportInfo;
        }

        public string Displayname
        {
            get { return _Displayname; }
            set { _Displayname = value; }
        }

        public string Reportinfo
        {
            get { return _Reportinfo; }
            set { _Reportinfo = value; }
        }

        public string FormToLoad
        {
            get { return _FormToLoad; }
            set { _FormToLoad = value; }
        }

        public string FormAssembly
        {
            get { return _FormAssembly; }
            set { _FormAssembly = value; }
        }

        public List<Guid> BenutzerListe
        {
            get { return _BenutzerListe; }
            set { _BenutzerListe = value; }
        }

        public string DatasetAssemly
        {
            get { return _DatasetAssemly; }
            set { _DatasetAssemly = value; }
        }

        public List<BerichtDatenquelle> DataSources
        {
            get { return _DataSources; }
            set { _DataSources = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert eine Liste alle Parameter
        /// </summary>
        //----------------------------------------------------------------------------
        public List<BerichtParameter> PARAMTERS
        {
            get
            {
                return _list;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert True wenn der übergebene Benutzer ein Recht hat den Report zu verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        public bool HasUserRight(Guid IDUser)
        {
            if (BenutzerListe.Count == 0)
                return true;
            foreach (Guid g in BenutzerListe)
                if (g == IDUser)
                    return true;
            return false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einen Parameter einfügen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddParameter(string description, BerichtParameter.BerichtParameterTyp typ, string name, string sdefault)
        {
            _list.Add(new BerichtParameter(description, typ, name, sdefault));
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aus einer Konfigurationsdatei laden
        /// </summary>
        //----------------------------------------------------------------------------
        public void LoadFromConfig(string ConfigFile)
        {
            _list.Clear();
            _DataSources.Clear();
            Reportinfo = "";
            bool bReadPermissonsFromFile = false;

            string sPermissionFile = Path.Combine(System.IO.Path.GetDirectoryName(ConfigFile), System.IO.Path.GetFileNameWithoutExtension(ConfigFile) + ".Permissions");
            if (File.Exists(sPermissionFile))
            {
                try
                {
                    XmlDocument dPermissions;
                    XmlNode nb;
                    dPermissions = new XmlDocument();
                    dPermissions.Load(sPermissionFile);

                    // Benutzerberechtigungen ---------------------------------------------------------------------
                    XmlNodeList lbenber = dPermissions.GetElementsByTagName("BerechtigeBenutzer");
                    nb = lbenber[0];
                    BenutzerListe.Clear();
                    if (nb != null)
                    {
                        string s = nb.InnerText;
                        string[] sa = s.Split(',');
                        foreach (string sid in sa)
                            if (sid.Length > 0)
                                BenutzerListe.Add(new Guid(sid));
                    }
                    bReadPermissonsFromFile = true;
                }
                finally
                {
                }
            }



            try
            {
                XmlDocument d;
                XmlNode ni, nb, nf, nd;
                d = new XmlDocument();
			    d.Load(ConfigFile);

                // Form die vor dem Druck geladen werden soll ---------------------------------------------------------------------
                XmlNodeList lForm = d.GetElementsByTagName("Form");
                nf = lForm[0];
                if (nf != null)
                {
                    FormToLoad = nf.InnerText;
                    if (nf.Attributes.Count > 0)
                        FormAssembly = nf.Attributes["Assembly"].Value;
                    else
                        FormAssembly = "";
                }
                else
                {
                    FormToLoad = "";
                    FormAssembly = "";
                }

                // Datenquellen die vor dem Druck geladen werden sollen ---------------------------------------------------------------------
                XmlNodeList lds = d.GetElementsByTagName("DatenQuellen");
                nf = lds[0];
                if (nf != null)
                {
                    GetSourcesFromString( nf.InnerText);                        // Datenquellenliste befüllen
                    if (nf.Attributes.Count > 0)
                        DatasetAssemly = nf.Attributes["Assembly"].Value;
                    else
                        DatasetAssemly = "";
                }
                else
                {
                    DatasetAssemly = "";
                }

                // Beschreibung ---------------------------------------------------------------------
                XmlNodeList ldes = d.GetElementsByTagName("Description");
                ni = ldes[0];
                Reportinfo = ni.InnerText;

                // Anzeigename ---------------------------------------------------------------------
                XmlNodeList ldisname = d.GetElementsByTagName("Displayname");
                nd = ldisname[0];
                if(nd != null)
                    Displayname = nd.InnerText;

                if (!bReadPermissonsFromFile)
                {
                    // Benutzerberechtigungen ---------------------------------------------------------------------
                    XmlNodeList lbenber = d.GetElementsByTagName("BerechtigeBenutzer");
                    nb = lbenber[0];
                    BenutzerListe.Clear();
                    if (nb != null)
                    {
                        string s = nb.InnerText;
                        string[] sa = s.Split(',');
                        foreach (string sid in sa)
                            if (sid.Length > 0)
                                BenutzerListe.Add(new Guid(sid));
                    }
                }

                XmlNodeList lp = d.GetElementsByTagName("Parameter");
                foreach (XmlNode n in lp)
                {
                    string              beschreibung    = n.Attributes["beschreibung"].Value;
                    BerichtParameter.BerichtParameterTyp t = (BerichtParameter.BerichtParameterTyp)Enum.Parse(typeof(BerichtParameter.BerichtParameterTyp), n.Attributes["typ"].Value);
                    string              name            = n.InnerText;
                    string              sdefault        = n.Attributes["default"].Value;
                    _list.Add(new BerichtParameter(beschreibung, t, name, sdefault));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Wir haben einen Konfigurationsfehler festgestellt.\n\rEin oder mehrere Berichte werden möglicherweise nicht angezeigt.\n\rBitte nehmen Sie mit S2-Engineering GmbH unter 07252 / 22080 Kontakt auf.\n\r\n\r" + ex.ToString());
//                throw new Exception("LoadFromConfig: " + ex.ToString());
            }
            finally
            {
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Datenquellen sind in der Form Bereich;Klasse|Bereich;Klasse .... gespeichert
        /// </summary>
        //----------------------------------------------------------------------------
        private void GetSourcesFromString(string p)
        {
            if (p.Length == 0)
                return;
            string[] sa = p.Split('|');
            foreach (string s in sa)
            {
                string[] sb = s.Split(';');
                if (sb.Length != 2)
                    continue;
                _DataSources.Add(new BerichtDatenquelle(sb[0].Trim(), sb[1].Trim()));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Parameter und Info in XML Datei schreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void WriteToConfigFile(string ConfigFile)
        {
            XmlWriter w = null;
            XmlWriter wPermission = null;
            try
            {
                string sFile = ConfigFile;
                string sPermissionFile = Path.Combine(System.IO.Path.GetDirectoryName(ConfigFile), System.IO.Path.GetFileNameWithoutExtension(ConfigFile) + ".Permissions");

                XmlWriterSettings s = new XmlWriterSettings();
                s.ConformanceLevel = ConformanceLevel.Document;
                s.Indent = true;

                XmlWriterSettings sPermissions = new XmlWriterSettings();
                sPermissions.ConformanceLevel = ConformanceLevel.Document;
                sPermissions.Indent = true;

                w = XmlWriter.Create(sFile, s);
                wPermission = XmlWriter.Create(sPermissionFile, sPermissions);

                w.WriteStartDocument();
                wPermission.WriteStartDocument();

                w.WriteStartElement("Reportdefinitionen");
                wPermission.WriteStartElement("Reportdefinitionen");

                // Form schreiben
                w.WriteStartElement("Form");
                w.WriteAttributeString("Assembly", FormAssembly);
                w.WriteString(FormToLoad);
                w.WriteEndElement();

                // Datenquellen schreiben
                w.WriteStartElement("DatenQuellen");
                w.WriteAttributeString("Assembly", DatasetAssemly);
                w.WriteString(GetDataSources());
                w.WriteEndElement();

                // Beschreibung schreiben
                w.WriteStartElement("Description");
                w.WriteString(Reportinfo);
                w.WriteEndElement();

                // Anzeigename schreiben
                w.WriteStartElement("Displayname");
                w.WriteString(Displayname);
                w.WriteEndElement();

                // Berechtigungen in xx.Perissions schreiben
                wPermission.WriteStartElement("BerechtigeBenutzer");
                StringBuilder sb = new StringBuilder();
                bool bFirst = true;
                foreach (Guid g in BenutzerListe)
                {
                    if (!bFirst)
                        sb.Append(",");
                    else 
                        bFirst = false;

                    sb.Append(g.ToString());
                }
                wPermission.WriteString(sb.ToString());
                wPermission.WriteEndElement();

                w.WriteStartElement("ParameterList");
                // Jeden eingetragenen Parameter in die XML Datei schreiben
                foreach (BerichtParameter p in _list)
                {
                    w.WriteStartElement("Parameter");
                    w.WriteAttributeString("typ", p.Typ.ToString());
                    w.WriteAttributeString("beschreibung", p.Description);
                    w.WriteAttributeString("default", p.Default);
                    w.WriteString(p.Name);
                    w.WriteEndElement();        // Parameter
                }
                w.WriteEndElement();            // Parameterlist

                w.WriteEndElement();            // Reportdefinitions
                w.WriteEndDocument();

                wPermission.WriteEndElement();            // Reportdefinitions
                wPermission.WriteEndDocument();

            }
            finally
            {
                if (w != null)
                {
                    w.Flush();
                    w.Close();

                    wPermission.Flush();
                    wPermission.Close();
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen String aus List<BerichtDatenquellen> ....
        /// </summary>
        //----------------------------------------------------------------------------
        private string GetDataSources()
        {
            StringBuilder sb = new StringBuilder();
            foreach (BerichtDatenquelle q in _DataSources)
            {
                if (sb.Length > 0)
                    sb.Append("|");
                sb.Append(q.Bereich);
                sb.Append(";");
                sb.Append(q.Klasse);
            }
            return sb.ToString();
        }
    }


}
