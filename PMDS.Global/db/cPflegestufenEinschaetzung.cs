using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XlsIO;
using System.IO;

namespace PMDS.Global.db
{
    public class cPflegestufenEinschaetzung
    {
        private const string PSEVorlage = "PSE.xlsm";

        public class PSEMeldung
        {
            public string KlientNachname { get; set; }
            public string KlientVorname { get; set; }
            public string Geburtsdatum {get;set;}
            public string Abteilung { get; set; }
            public DateTime Zeitpunkt { get; set; }
            public string Maßahme { get; set; }
            public string Dekurs { get; set; }
            public int IstDauer { get; set; }
            public int PflegePlanDauer { get; set; }
            public string PSEKlasse { get; set; }
            public string Benutzer { get; set; }
            public Guid? IDPflegeplan { get; set; }
            public Guid? IDEintrag { get; set; }
            public Guid IDAufenthalt { get; set; }
            public Guid? IDAbteilung { get; set; }
            public Guid? IDBereich { get; set; }
            public Guid IDKlient { get; set; }
        }
        public class PSEParams
        {
            public DateTime dtVon { get; set; }
            public DateTime dtBis { get; set; }
            public string KlientNachname { get; set; }
            public string KlientVorname { get; set; }
            public string Geburtsdatum { get; set; }
            public string Abteilung { get; set; }
            public string ErstelltVon { get; set; }
            public Guid IDAufenthalt { get; set; }
            public Guid IDAbteilung { get; set; }
            public Guid IDKlient { get; set; }
            public bool IsInit { get; set; }
            public bool HasData { get; set; }
            public bool LastResult { get; set; }
            public string ErrorText { get; set; }
            public List<PSEMeldung> Meldungen { get; set; } = new List<PSEMeldung>();
        }

        public static PSEParams Init(PSEParams p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rAufenthalt = (from a in db.vAufenthaltsliste
                                       where a.IDAufenthalt == p.IDAufenthalt
                                       select new
                                       {
                                           KlientNachname = a.Nachname.Trim(),
                                           KlientVorname = a.Vorname.Trim(),
                                           Geburtsdatum = a.Geburtsdatum,
                                           Abteilung = a.Abteilung.Trim(),
                                           IDAufenthalt = a.IDAufenthalt,
                                           IDAbteilung = a.IDAbteilung,
                                           IDKlient = a.IDPatient
                                       }).FirstOrDefault();
                    
                    var rErstelltVon = (from ben in db.Benutzer
                                        where ben.ID == ENV.USERID
                                        select new
                                        {
                                            ErstelltVon = (ben.Vorname.Trim() + " " + ben.Nachname.Trim()).Trim(),                                            
                                        }).FirstOrDefault();

                    if (rAufenthalt != null)
                    {
                        p.KlientNachname = rAufenthalt.KlientNachname;
                        p.KlientVorname = rAufenthalt.KlientVorname;
                        p.Geburtsdatum = rAufenthalt.Geburtsdatum;
                        p.Abteilung = rAufenthalt.Abteilung;
                        p.IDAbteilung = rAufenthalt.IDAbteilung == null ? Guid.Empty : (Guid)rAufenthalt.IDAbteilung;
                        p.IDKlient = rAufenthalt.IDKlient;

                        if (rErstelltVon != null)
                        {
                            p.ErstelltVon = rErstelltVon.ErstelltVon;
                            p.IsInit = true;
                            SetResult(ref p);
                        }
                        else
                        {
                            SetResult(ref p, false, "Init: Aktueller Benutzer nicht gefunden.");
                        }
                    }
                    else
                    {
                        SetResult(ref p, false, "Init: Aufenthalt nicht gefunden.");
                    }
                }
                return p;
            }
            catch (Exception ex)
            {
                p.IsInit = false;
                SetResult(ref p, false, "cPflegestufenEinschaetzung.Init: " + ex.ToString());
                return p;
            }
        }

        public static PSEParams LoadData(PSEParams p)
        {
            try
            {
                if (p.IsInit)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var tMeldungen = (from pe in db.PflegeEintrag
                                          join a in db.vAufenthaltsliste on pe.IDAufenthalt equals a.IDAufenthalt
                                          join ben in db.Benutzer on pe.IDBenutzer equals ben.ID
                                          where a.IDAufenthalt == p.IDAufenthalt && pe.DatumErstellt >= p.dtVon && pe.DatumErstellt <= p.dtBis && pe.PSEKlasse.Trim().Length > 0
                                          select new
                                          {
                                              KlientNachname = a.Nachname.Trim(),
                                              KlientVorname = a.Vorname.Trim(),
                                              Geburtsdatum = a.Geburtsdatum,
                                              Abteilung = a.Abteilung.Trim(),
                                              Zeitpunkt = (DateTime)pe.DatumErstellt,
                                              Maßahme = pe.PflegeplanText.Trim() ?? "",
                                              Dekurs = pe.Text.Trim(),
                                              pe.IstDauer,
                                              pe.PflegePlanDauer,
                                              pe.PSEKlasse,
                                              Benutzer = ben.Benutzer1.Trim(),

                                              IDPflegeplan = pe.IDPflegePlan,
                                              IDEintrag = pe.IDEintrag,
                                              IDAufenthalt = a.IDAufenthalt,
                                              IDAbteilung = a.IDAbteilung,
                                              IDBereich = a.IDBereich,
                                              IDKlient = a.IDPatient
                                          }).OrderBy(pe => pe.PSEKlasse).ThenBy(pe => pe.Zeitpunkt).ToList();

                        if (tMeldungen != null)
                        {
                            p.Meldungen.Clear();
                            p.HasData = false;
                            foreach(var m in tMeldungen)
                            {
                                PSEMeldung pseM = new PSEMeldung();
                                pseM.KlientNachname = m.KlientNachname;
                                pseM.KlientVorname = m.KlientVorname;
                                pseM.Geburtsdatum = m.Geburtsdatum;
                                pseM.Abteilung = m.Abteilung;
                                pseM.Zeitpunkt = m.Zeitpunkt;
                                pseM.Maßahme = m.Maßahme;
                                pseM.Dekurs = m.Dekurs;
                                pseM.IstDauer = m.IstDauer ?? 0;
                                pseM.PflegePlanDauer = m.PflegePlanDauer ?? 0;
                                pseM.Benutzer = m.Benutzer;
                                pseM.PSEKlasse = m.PSEKlasse;

                                pseM.IDPflegeplan = m.IDPflegeplan;
                                pseM.IDEintrag = m.IDEintrag;
                                pseM.IDAufenthalt = m.IDAufenthalt;
                                pseM.IDAbteilung = m.IDAbteilung;
                                pseM.IDBereich = m.IDBereich;
                                pseM.IDKlient = m.IDKlient;
                                p.Meldungen.Add(pseM);
                            }
                            p.HasData = true;
                            SetResult(ref p);
                        }
                        else
                        {
                            SetResult(ref p, false, "Init: Aufenthalt nicht gefunden.");
                        }
                    }

                    SetResult(ref p);
                }
                else
                {
                    p.HasData = false;
                    SetResult(ref p, false, "GetData: Klasse wurde noch nicht initialisiert.");
                }
                return p;
            }
            catch (Exception ex)
            {
                p.HasData = false;
                SetResult(ref p, false, "cPflegestufenEinschaetzung.GetData: " + ex.ToString());
                return p;
            }
        }

        public static PSEParams MakeExcel(PSEParams p)
        {
            try
            {
                //Vorlage PSE.xlsx aus ReportPath und ins User-Temp-Verzeichnis temporär kopieren
                //Kopie öffnen 
                //Daten in die passenden Worksheets eintragen (nicht passende Kategorien in Restklasse)
                //Neu berechnen
                //Prüfen, ob Excel verfügbar ist
                //wenn ja -> Mit Excel öffnen
                //wenn nein -> nach Speicherort fragen und speichern

                if (p == null)
                {
                    p = new PSEParams();
                }

                if (p.HasData)
                {
                    string xlsVorlage = Path.Combine(ENV.ReportPath, PSEVorlage);
                    string xlsWorking = System.IO.Path.Combine(System.IO.Path.GetTempPath(), DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + PSEVorlage);
                    if (File.Exists(xlsVorlage))
                    {
                        System.IO.File.Copy(xlsVorlage, xlsWorking);
                        if (File.Exists(xlsWorking))
                        {
                            using (ExcelEngine excelEngine = new ExcelEngine())
                            {

                                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(xlsWorking);

                                List<IWorksheet> worksheets = new List<IWorksheet>();
                                worksheets.Add(workbook.Worksheets["PSE"]);
                                worksheets.Add(workbook.Worksheets["K1"]);
                                worksheets.Add(workbook.Worksheets["K2"]);
                                worksheets.Add(workbook.Worksheets["K3"]);
                                worksheets.Add(workbook.Worksheets["K4"]);
                                worksheets.Add(workbook.Worksheets["K5"]);
                                worksheets.Add(workbook.Worksheets["K6"]);
                                worksheets.Add(workbook.Worksheets["K7"]);
                                worksheets.Add(workbook.Worksheets["K8"]);
                                worksheets.Add(workbook.Worksheets["K9"]);
                                worksheets.Add(workbook.Worksheets["K10"]);
                                worksheets.Add(workbook.Worksheets["K11"]);
                                worksheets.Add(workbook.Worksheets["K12"]);
                                worksheets.Add(workbook.Worksheets["K13"]);
                                worksheets.Add(workbook.Worksheets["K14"]);
                                worksheets.Add(workbook.Worksheets["K15"]);
                                worksheets.Add(workbook.Worksheets["K16"]);
                                worksheets.Add(workbook.Worksheets["K17"]);
                                worksheets.Add(workbook.Worksheets["K18"]);
                                worksheets.Add(workbook.Worksheets["K19"]);
                                worksheets.Add(workbook.Worksheets["K20"]);
                                worksheets.Add(workbook.Worksheets["K21"]);
                                worksheets.Add(workbook.Worksheets["K22"]);
                                worksheets.Add(workbook.Worksheets["K23"]);
                                worksheets.Add(workbook.Worksheets["KRest"]);

                                foreach (PSEMeldung m in p.Meldungen)
                                {
                                    //Reiter ermitteln
                                    //Aktuelle Anzahl der Meldungen lesen (D3)
                                    //Anzahl der Meldungen += 1
                                    //Bereich A7 - F7 in Bereich A 7+Anzahl - F 7+Anzahl kopieren
                                    //Spalten Zeitpunkt, Maßnahme, Dekurs, IstDauer, Pflegeplandauer, Benutzer in Ax - Fx schreiben
                                    //Formel in D4 =SUMME(A7:Ax) aktualisieren

                                    IWorksheet ws = worksheets[24];     //Standard, wenn keine passende Klasse gefunden wurde
                                    string[] strParts = m.PSEKlasse.Split('.');
                                    if (strParts.Length >= 2)
                                    {
                                        int iWs;
                                        if (int.TryParse(strParts[0], out iWs))
                                        {
                                            ws = worksheets[iWs];
                                        }

                                        int AnzahlMeldungen = Math.Max((int)ws.Range["D3"].Number,0);

                                        AnzahlMeldungen++;
                                        int iNewRow = 7 + AnzahlMeldungen;
                                        string sNewRow = iNewRow.ToString();
                                        ws.Range["D3"].Number = AnzahlMeldungen;
                                        IRange source = ws.Range["A7:F7"];
                                        IRange dest = ws.Range["A" + sNewRow + ":F" + sNewRow];
                                        source.CopyTo(dest, ExcelCopyRangeOptions.All);

                                        ws.Range["A" + sNewRow].DateTime = m.Zeitpunkt;
                                        ws.Range["B" + sNewRow].Value = m.Maßahme;
                                        ws.Range["C" + sNewRow].Value = m.Dekurs;
                                        ws.Range["D" + sNewRow].Number = m.IstDauer;
                                        ws.Range["E" + sNewRow].Number = m.PflegePlanDauer;
                                        ws.Range["F" + sNewRow].Value = m.Benutzer;

                                        ws.Range["D4"].Formula = "=Sum(D8:D" + sNewRow + ")/60";
                                    }
                                }

                                worksheets[0].Range["A2"].Value = "Klientenname: " + p.KlientVorname + " " + p.KlientNachname;
                                worksheets[0].Range["E2"].Value = "geb.: " + p.Geburtsdatum;
                                worksheets[0].Range["A3"].Value = "Erstellt von: " + p.ErstelltVon;
                                worksheets[0].Range["E3"].Value = "am: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                                workbook.Save();                                
                                if (IsExcelInstalled())
                                {
                                    System.Diagnostics.Process.Start(xlsWorking);
                                    SetResult(ref p);
                                }
                                else
                                {
                                    SetResult(ref p, false, "Datei wurde gespeichert (" + xlsWorking + "), kann aber nicht geöffnet werden, weil Excel nicht installiert ist.");
                                }
                            }                            
                        }
                        else
                        {
                            SetResult(ref p, false, "MakeExcel: Excel-Arbeitskopie " + xlsWorking + " kann nicht erstellt werden.");
                        }
                    }
                    else
                    {
                        SetResult(ref p, false, "MakeExcel: Excel-Vorlage " + PSEVorlage + "nicht gefunden.");
                    }
                }
                else
                {
                    SetResult(ref p, false, "MakeExcel: keine Daten für die Excel.-Datei verfügbar.");
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("cPflegestufenEinschaetzung.MakeExcel: " + ex.ToString());
            }
        }

        private static void SetResult(ref PSEParams p, bool result = true, string ErrorText = "")
        {
            try
            {
                p.LastResult = result;
                p.ErrorText = ErrorText;
            }
            catch (Exception ex)
            {
                throw new Exception("cPflegestufenEinschaetzung.SetResult: " + ex.ToString());
            }
        }

        private static bool IsExcelInstalled()
        {
            try
            {
                Type officeType = Type.GetTypeFromProgID("Excel.Application");
                return officeType != null;
            }
            catch (Exception ex)
            {
                throw new Exception("cPflegestufenEinschaetzung.IsExcelInstalled: " + ex.ToString());
            }
        }

    }
}
