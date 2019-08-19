using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.Win32;
using PMDS.DB;


namespace PMDS.Print.CR
{
    
    public class ReportManager
    {
               


        public static bool PrintDynamicReport(string sReportFile, bool PrintPreview, List<BerichtParameter> list, List<BerichtDatenquelle> listds,
                                                string KlientNameGebDat, string DB_USER,
                                                string DB_SERVER, string DB_DATABASE, string INTEGRATED_SECURITY, string DB_PASSWORD,
                                                PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular1, ref string sFileFullNameExported, bool ShowGroupTreeButton = true, string lstPatients = "", bool SaveToArchive = false)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            
            rpt.Load(sReportFile);

            TableLogOnInfo info = new TableLogOnInfo();
            info.ConnectionInfo.DatabaseName = DB_DATABASE;

            if (INTEGRATED_SECURITY == null || INTEGRATED_SECURITY == "0")
            {
                info.ConnectionInfo.IntegratedSecurity = false;
                info.ConnectionInfo.Password = DB_PASSWORD;
                info.ConnectionInfo.UserID = DB_USER;
            }
            else
            {
                info.ConnectionInfo.IntegratedSecurity = true;
                info.ConnectionInfo.Password = string.Empty;
                info.ConnectionInfo.UserID = string.Empty;
            }

            info.ConnectionInfo.ServerName = DB_SERVER;

            string sFile = Path.GetFileName(sReportFile).Trim();

            if (IsInList(listds, sFile))                            // Dynamsche Datenquellen wenn es die Hauptdatenquelle ist muss der Reportdateiname konfiguriert sein
            {
                try
                {
                    DataSet ds = GetDataSetFromList(listds, sFile);
                    rpt.SetDataSource(ds);
                }
                catch (Exception ex)
                {
                    throw new Exception("PrintDynamicReport: Error SetDataSource: " + ex.ToString());
                }
            }
            else
            {
                foreach (Table t in rpt.Database.Tables)
                {
                    t.ApplyLogOnInfo(info);

                }
            }
            if (cParFormular1 != null)
            {
                rpt.SetDataSource(cParFormular1.dsFormularAssessment);
            }

            foreach (Section s in rpt.ReportDefinition.Sections)                            // jeden Subreport eine Connection zuweisen
            {
                foreach (ReportObject o in s.ReportObjects)
                {
                    if (o.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject so = (SubreportObject)o;
                        ReportDocument doc = so.OpenSubreport(so.SubreportName);

                        if (IsInList(listds, so.SubreportName.Trim()))                      // Dynamische Datenquelle
                        {
                            doc.SetDataSource(GetDataSetFromList(listds, so.SubreportName.Trim()));
                        }
                        else
                        {
                            foreach (Table t in doc.Database.Tables)
                            {
                                t.ApplyLogOnInfo(info);
                            }

                        }
                    }
                }
            }

            if (info.ConnectionInfo.IntegratedSecurity == true)
            {
                rpt.SetDatabaseLogon(string.Empty, string.Empty, DB_SERVER, DB_DATABASE, true);
            }
            else
            {
                rpt.SetDatabaseLogon(DB_USER, DB_PASSWORD, DB_SERVER, DB_DATABASE, true);
            }
            rpt.Refresh();

            // 17.11.2010 - Steuerung des Ausdrucks mittels zusätzlicher Parameter
            // ReportRoot: wenn nicht leer -> Ausdrucken als PDF in <ReportRoot>\Nachname_Vorname_GebDatum\<Berichtsname>.pdf
            // PrintJN: wenn ja -> direkte Ausgabe auf den Drucker ohne Voransicht.

            String IDKlient = "";
            String ReportRoot = "";
            Boolean PrintJN = false;

            foreach (BerichtParameter p in list)  // Alle Berichtsparameter setzten
            {
                AddCrystalParameter(rpt, p.Name, (object)p.Value);

                if (p.Name == "IDKlient")
                {
                    IDKlient = p.Value.ToString();
                    IDKlient = IDKlient.Replace("{", "");
                    IDKlient = IDKlient.Replace("}", "");
                }
                if (p.Name == "ReportRoot") ReportRoot = p.Value.ToString();

                if (p.Name == "PrintJN") PrintJN = Convert.ToBoolean(p.Value.ToString());

            }

            if (PrintPreview && PrintJN == false && ReportRoot == "" && !SaveToArchive)
            {
                frmPrintPreview frm = new frmPrintPreview(rpt);
                frm.Show();       //!= System.Windows.Forms.DialogResult.OK;
                frm.crystalReportViewer1.ShowGroupTreeButton = ShowGroupTreeButton;
                frm.crystalReportViewer1.DisplayGroupTree = ShowGroupTreeButton;
                return true;
            }
            else if (SaveToArchive)
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                string tmpFullPath = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, "Pflegebegleitschreiben" + "_" + System.Guid.NewGuid().ToString() + ".pdf");
                CrDiskFileDestinationOptions.DiskFileName = tmpFullPath;
                CrExportOptions = rpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                rpt.Export();
                sFileFullNameExported = tmpFullPath;
                return true;
            }
            else
            { 
                // OS: Klientenbericht für Archivierung!!!
                // Wenn Archivpfad gesetzt ist -> 
                // Ausgabeverzeichnis ermitteln und Bericht als PDF rausschreiben.
                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                    string tmpFullPath = GetUniqueArchivFileName(KlientNameGebDat, ReportRoot, sReportFile);
                    if (tmpFullPath == "") return false;

                    CrDiskFileDestinationOptions.DiskFileName = tmpFullPath;
                    CrExportOptions = rpt.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    rpt.Export();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static void AddCrystalParameter(ReportDocument crReport, string ParameterName, object oParameterValue)
        {
            if (!HasParameter(crReport, ParameterName))
                return;

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = oParameterValue;
            crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[ParameterName];
            crParameterFieldDefinition.CurrentValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

        }
        public static void AddCrystalParameter(ReportDocument crReport, string ParameterName, string ParameterValue)
        {
            ParameterFieldDefinitions crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields;

            ParameterValues crParameterValues = new ParameterValues();
            ParameterFieldDefinition param = crParameterFieldDefinitions[ParameterName];
            crParameterValues = param.CurrentValues;

            ParameterDiscreteValue param_Val = new ParameterDiscreteValue();
            param_Val.Value = ParameterValue;
            crParameterValues.Add(param_Val);

            param.ApplyCurrentValues(crParameterValues);
        }
        private static bool HasParameter(ReportDocument crReport, string ParameterName)
        {
            foreach (ParameterField f in crReport.ParameterFields)
            {

                if (String.Compare(f.Name, ParameterName, true) == 0)
                    return true;
            }
            return false;
        }

        private static bool IsInList(List<BerichtDatenquelle> listds, string sCompareString)
        {
            if (listds == null)
                return false;
            foreach (BerichtDatenquelle q in listds)
            {
                if (q.Bereich.Trim().Equals(sCompareString, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        public static ReportDocument newReportDocumentxy(string sReportFile)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(sReportFile);

            return rpt;
        }

        private static DataSet GetDataSetFromList(List<BerichtDatenquelle> listds, string sCompareString)
        {
            if (listds == null)
                return null;
            foreach (BerichtDatenquelle q in listds)
            {
                if (q.Bereich.Trim().Equals(sCompareString.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    return q.DATASET;
            }
            return null;
        }


        public static bool setDataSource(System.Data.DataSet ds, string ReportFile, ReportDocument rpt)
        {
            rpt.SetDataSource(ds);
            return true;
        }
        public static bool setDataSource(System.Data.DataTable dt, string ReportFile, ReportDocument rpt)
        {
            rpt.SetDataSource(dt);
            return true;
        }

        public static string GetUniqueArchivFileName(string KlientenNameGebDat, string ReportRoot, string sReportFile)
        {
            try
            {

                string repPath =  System.IO.Path.Combine (ReportRoot, KlientenNameGebDat);
                System.IO.Directory.CreateDirectory(repPath);   // Pfad anlegen, wenn er nicht bereits besteht

                sReportFile = System.IO.Path.GetFileName(sReportFile);
                sReportFile = Regex.Replace(sReportFile, @"[^0-9a-zA-Z.äöüÄÖÜß]", string.Empty);
                sReportFile = System.IO.Path.Combine(repPath, sReportFile + "_" + System.Guid.NewGuid().ToString() + ".pdf");
                return sReportFile;
            }
            catch
            {
                return "";
            }
        }
      
    }

    public class cParFormular
    {
    }

    public class BerichtParameter
    {
        public enum BerichtParameterTyp
        {
            Abteilung = 0,      // Abteilungsauswahl (Default = aktueller)
            ASZMListe,          // Auswahlliste ASZM
            Auswahlliste,       // Auswahlliste
            Benutzer,           // Benutzerauswahl (Default = aktueller)
            Bereich,            // Bereichsauswahl (Default = aktueller)
            Boolean,            // Boolean
            Datum,              // Datum
            DatumZeit,          // Datum + Zeit
            Klient,             // Klientenauswahl (Default = aktueller)
            Text,               // einfacher Text
            Zahl,               // Integerwert
            Zeit,               // Nur Zeit
            SQL_GUID,           // Eine SQL Anweisung mit 2 Spalten ID und anzeigeText,
            GUID,               // GUID (für Klinik)
            SQL_GUID_NO_EMPTY,  // Eine SQL Anweisung mit 2 Spalten ID und AnzeigeText ohne leere Auswahloption,
            TextHidden,         // Versteckter Text
            ThreeStateCheckbox  // ThreeState (WAHR, FALSCH, UNDEFINIERT)
        }


        private string _description = "";
        private BerichtParameterTyp _typ;
        private string _Name;
        private string _Default;
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public BerichtParameterTyp Typ
        {
            get { return _typ; }
            set { _typ = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Default
        {
            get { return _Default; }
            set { _Default = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public BerichtParameter(string description, BerichtParameterTyp typ, string name, string sdefault)
        {
            _description = description;
            _typ = typ;
            _Name = name;
            _Default = sdefault;
        }



    }

    public class BerichtDatenquelle
    {
        private string _Bereich;
        private string _Klasse;
        private DataSet _dataset;

        public BerichtDatenquelle(string sBereich, string sKlasse)
        {
            _Bereich = sBereich;
            _Klasse = sKlasse;
        }

        public BerichtDatenquelle(string sBereich, DataSet oDataset)
        {
            _Bereich = sBereich;
            _dataset = oDataset;
        }

        public string Bereich
        {
            get { return _Bereich; }
            set { _Bereich = value; }
        }

        public string Klasse
        {
            get { return _Klasse; }
            set { _Klasse = value; }
        }

        public DataSet DATASET
        {
            get { return _dataset; }
            set { _dataset = value; }
        }

        public bool HasDataSet
        {
            get
            {
                return _dataset != null;
            }
        }

    }

}
