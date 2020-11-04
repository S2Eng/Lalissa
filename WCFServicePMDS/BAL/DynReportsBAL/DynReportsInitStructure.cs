using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.BAL.Main;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.Models.DB;
using System.Reflection;
using System.IO;

namespace WCFServicePMDS.DynReportsBAL
{
    class DynReportsInitStructure : IDynReportsInitStructure
    {

        private List<string> lstDynReports = new List<string>
        {
            "Dynreports",
            "DynreportsAbrechnung",
            "DynreportsDatenerhebung",
            "DynreportsExtras",
            "DynreportsMedikamente",
            "DynreportsPep",
            "DynreportsProzeduren",
            "DynreportsWunde"
        };

        public bool DynReportsInitStruct(ref string RootPath, Guid IDClient)
        {
            try
            {
                /*
                1. Löschen aller Auswahllisteneinträge 'DYR'
                2. Rekursive Suche in RootPath für die Pfade in lstDynReports
                3. Für jede gefundene .config-Datei einen Eintrag in DYR anlegen:
                    Bezeichnung = 1. Zeile der Config.Datei (Filename des Reports), durch Semikolon getrennt die zweite Zeile der .config-datei (wenn vorhanden)
                    GehörtZuGruppe = oberstes Verzeichnis (aus der Liste oben)
                    Beschreibung = Pfad unterhalb des obersten Verzeichnisses 
                */
                using (WCFServicePMDS.Repository.RepositoryWrapper repo = new Repository.RepositoryWrapper(IDClient))
                {
                    List<AuswahlListe> delRows = repo.dbcontext.AuswahlListe.Where(aus => aus.IdauswahlListeGruppe == "DYR").ToList();
                    foreach (AuswahlListe aus in delRows)
                    {
                        repo.AuswahlListe.Delete(aus);
                    }

                    foreach (string DynReportRoot in lstDynReports)
                    {
                        if (Directory.Exists(Path.Combine(RootPath, DynReportRoot)))
                        {
                            foreach (string f in Directory.GetFiles(Path.Combine(RootPath, DynReportRoot), "*.dynreportlink", SearchOption.AllDirectories))
                            {
                                string Bezeichnung = "";
                                string Beschreibung = f.ToUpper().Replace(Path.GetFileName(f).ToUpper(), "").TrimEnd(Path.DirectorySeparatorChar);
                                Beschreibung = f.Substring(Beschreibung.IndexOf(DynReportRoot.ToUpper()) + DynReportRoot.Length + 1).Replace(Path.GetFileName(f), "").TrimEnd(Path.DirectorySeparatorChar);

                                string[] lines = File.ReadAllText(f).Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                for (int i = 0; i < lines.Count(); i++)
                                {
                                    Bezeichnung = Bezeichnung + lines[i].Replace("\n", "").Replace("\r", "") + ";";
                                }

                                //Add new Auswahlliste-Eintrag
                                AuswahlListe alRow = new AuswahlListe();
                                alRow.Id = Guid.NewGuid();
                                alRow.Bezeichnung = Bezeichnung;
                                alRow.GehörtzuGruppe = DynReportRoot;
                                alRow.Beschreibung = Beschreibung;
                                alRow.Reihenfolge = 0;
                                alRow.IdauswahlListeGruppe = "DYR";
                                alRow.Hierarche = Beschreibung.Split('\\').Length; ;
                                alRow.IstGruppe = false;
                                repo.dbcontext.AuswahlListe.Add(alRow);
                            }
                        }
                    }
                    repo.dbcontext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DynReportsBAL.DynReportsInitStructure.DynReportsInitStruct: " + ex.ToString());
            }
        }
    }
}

