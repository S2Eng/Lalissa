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

using Patagames.Pdf.Net;        //https://www.youtube.com/watch?v=IF9cKSUFon8
using Patagames.Pdf.Enums;
using Patagames.Pdf.Net.BasicTypes;
using System.Windows.Forms;

namespace WCFServicePMDS.DatenExportXMLBAL
{
    //prüfen kommentrar
    public class DatenExportXML : IDatenExportXML
    {

        private enum eDataTable
        {
            Kliniken = 1,
            Abteilung = 2,
            Bereich = 3,
            Adresse = 4,
            Kontakt = 5
        }


        private Dictionary<string, string> BenutzerFieldnames = new Dictionary<string, string>();
        private Dictionary<string, string> KontaktFieldnames = new Dictionary<string, string>();
        private Dictionary<string, string> AdresseFieldnames = new Dictionary<string, string>();
        private Dictionary<string, string> PflegegeldStufenFieldnames = new Dictionary<string, string>();

        private int iFlush = 200;

        public class MedikamenteDTO
        {
            public Guid Id { get; set; }
            public string Bezeichnung { get; set; }
        }


        public class PatientenfotoDTO
        {
            public Guid Id { get; set; }
            public byte[] Foto { get; set; }
        }

        public class AufenthaltDTO
        {
            public Guid Id { get; set; }
            public Guid IdAufenthalt { get; set; }
            public DateTime Aufnahmezeitpunkt { get; set; }
        }


        private class DevOptions
        {
            public Boolean IsTest { get; set; }
            public Boolean AllgemeineStammdaten { get; set; }
            public Boolean Klientendaten { get; set; }
            public Boolean KlientenTermineArchiv { get; set; }
            public Boolean Aufenthaltsdaten { get; set; }
            public Boolean Pflegeplan { get; set; }
            public Boolean PflegeplanTermine { get; set; }
            public Boolean PflegeplanHistorie { get; set; }
            public Boolean PflegeDokumentation { get; set; }
            public Boolean WundDokumentation { get; set; }
            public Boolean Medikamente { get; set; }
            public Boolean Standardprozeduren { get; set; }
            public Boolean Verordnungen { get; set; }


        }

        private List<Benutzer> tblBenutzer;
        private List<Klinik> tblKliniken;
        private List<Abteilung> tblAbteilungen;
        private List<Bereich> tblBereiche;

        private Chilkat.Xml xml = new Chilkat.Xml();
        private string FileNameXMLDocumentBackTmp = "";

        public bool Export(Guid IDClient, System.Guid IDPatient, ref string ArchivPath, out string FileNameXMLDocumentBack, bool IsTest)
        {
            FileNameXMLDocumentBack = "";
            return false;
            /*
            try
            {

                DevOptions dOpt = new DevOptions();
                dOpt.IsTest = IsTest;
                dOpt.AllgemeineStammdaten = true;
                dOpt.Klientendaten = true;
                dOpt.KlientenTermineArchiv = true;
                dOpt.Aufenthaltsdaten = true;
                dOpt.Pflegeplan = true;
                dOpt.PflegeplanTermine = true;
                dOpt.PflegeplanHistorie = true;
                dOpt.PflegeDokumentation = true;
                dOpt.WundDokumentation = true;
                dOpt.Medikamente = true;
                dOpt.Standardprozeduren = true;
                dOpt.Verordnungen = true;

                if (dOpt.IsTest)
                {
                    //IDPatient = new Guid("439A9BFC-9FB5-4739-9F1E-B58B5B3CCB1E");
                    IDPatient = new Guid("FE9839D7-C1F3-43CE-AE6C-616E3E8A77F6");   //Abramova MZ                    
                }

                Init();

                xml.AddStyleSheet("<?xml-stylesheet href = \"PMDSExport.xsl\" type = \"text/xsl\"?>");
                xml.Encoding = "ISO-8859-1";
                xml.Standalone = true;
                xml.Tag = "PMDS-Datenexport";

                string KlientNameGebDat;
                string ExportPath;

                using (WCFServicePMDS.Repository.RepositoryWrapper repo = new Repository.RepositoryWrapper(IDClient))
                {
                    FileNameXMLDocumentBack = "";

                    IPatient pat = new PatientDAL(repo);
                    PatientS1DTO patDto = pat.PatientS1(IDPatient);
                    if (patDto != null)
                    {
                        DateTime dNow = DateTime.Now;

                        KlientNameGebDat = patDto.Nachname.Trim() + "_" + patDto.Vorname.Trim() + "_" + string.Format("{0:yyyyMMdd}", patDto.Geburtsdatum);
                        KlientNameGebDat = StripSpecialCharacters(KlientNameGebDat);

                        if (dOpt.IsTest)
                        {
                            ArchivPath = @"C:\PMDS\PMDS_Config\PMDS\Archiv\";
                            ExportPath = System.IO.Path.Combine(ArchivPath, "_" + KlientNameGebDat + "_Export");
                        }
                        else
                        {
                            ExportPath = System.IO.Path.Combine(ArchivPath, "_" + KlientNameGebDat + "_Export_" + dNow.ToString("yyyyMMddHHmmss"));
                        }
                        ENV.checkDirectory(ExportPath);

                        //öfters benötigte Tabellen einmal einlesen
                        tblBenutzer = repo.dbcontext.Benutzer.ToList();
                        tblKliniken = repo.dbcontext.Klinik.ToList();
                        tblAbteilungen = repo.dbcontext.Abteilung.ToList();
                        tblBereiche = repo.dbcontext.Bereich.ToList();


                        string PathWundeBilder = Path.Combine(ExportPath, "Wundbilder");
                        ENV.checkDirectory(PathWundeBilder);

                        string PathKlientenBild = Path.Combine(ExportPath, "Klientenbild");
                        ENV.checkDirectory(PathKlientenBild);

                        string PathKlientenArchiv = Path.Combine(ExportPath, "Klientenarchiv");
                        ENV.checkDirectory(PathKlientenArchiv);

                        string PathKlientenFormulare = Path.Combine(ExportPath, "Formulare");
                        ENV.checkDirectory(PathKlientenFormulare);

                        string PathKlientenBiografien = Path.Combine(ExportPath, "Biografien");
                        ENV.checkDirectory(PathKlientenBiografien);

                        FileNameXMLDocumentBack = System.IO.Path.Combine(ExportPath, KlientNameGebDat + ".XML");
                        FileNameXMLDocumentBackTmp = FileNameXMLDocumentBack;

                        Chilkat.Xml nExportInfo = xml.NewChild("ExportInfo", "");
                        nExportInfo.AddAttribute("BeginnExport", dNow.ToString());
                        List<Dbversion> rDBVersion = repo.dbcontext.Dbversion.ToList();
                        nExportInfo.AddAttribute("DBVersion", rDBVersion.FirstOrDefault().ScriptVersion);

                        SaveXML();

                        if (dOpt.AllgemeineStammdaten)
                        {
                            //----------------- Allgemeine Stammdaten ---------------- 
                            using (Chilkat.Xml nAllgemeineStammdaten = xml.NewChild("Allgemeine_Stammdaten", ""))
                            {

                                //List<Klinik> tblKliniken = repo.dbcontext.Klinik.ToList();
                                Chilkat.Xml nKliniken = nAllgemeineStammdaten.NewChild("Kliniken", "");
                                AddNodes(tblKliniken, nKliniken, "Klinik", repo, true);

                                //List<Abteilung> tblAbteilungen = repo.dbcontext.Abteilung.ToList();
                                Chilkat.Xml nAbteilungen = nAllgemeineStammdaten.NewChild("Abteilungen", "");
                                AddNodes(tblAbteilungen, nAbteilungen, "Abteilung", repo, true);

                                //List<Bereich> tblBereiche = repo.dbcontext.Bereich.ToList();
                                Chilkat.Xml nBereiche = nAllgemeineStammdaten.NewChild("Bereiche", "");
                                AddNodes(tblBereiche, nBereiche, "Bereich", repo, true);

                                Chilkat.Xml nAuswahlListenGruppen = nAllgemeineStammdaten.NewChild("AuswahlListenGruppen", "");
                                List<AuswahlListeGruppe> tblAuswahlListenGruppen = repo.dbcontext.AuswahlListeGruppe.ToList();
                                AddNodes(tblAuswahlListenGruppen, nAuswahlListenGruppen, "AuswahlListenGruppe", repo, true);

                                Chilkat.Xml nAuswahlListen = nAllgemeineStammdaten.NewChild("AuswahlListen", "");
                                List<AuswahlListe> tblAuswahlListen = repo.dbcontext.AuswahlListe.OrderBy(l => l.IdauswahlListeGruppe).ToList();
                                AddNodes(tblAuswahlListen, nAuswahlListen, "AuswahlListe", repo, true);

                                //Chilkat.Xml nPflegeEintragTypen = nAllgemeineStammdaten.NewChild("PflegeEintragTypen", "");
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "NONE", -1);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "DEKURS", 0);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "MASSNAHME", 1);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "EVALUIERUNG", 2);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "UNEXP_MASSNAHME", 3);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "TERMIN", 4);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "MEDIKAMENT", 5);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "NOTFALL", 6);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "PLANUNG", 7);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "WUNDEN", 8);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "KLIENT", 9);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "ASSESSMENT", 10);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "VERORDNUNGEN", 11);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "WUNDVERLAUF", 12);
                                //AddPflegeEintragTypNode(nPflegeEintragTypen, "WUNDTHERAPIE", 13);

                                List<Dienstzeiten> tblDienstzeiten = repo.dbcontext.Dienstzeiten.ToList();
                                Chilkat.Xml nDienstzeiten = nAllgemeineStammdaten.NewChild("Dienstzeiten", "");
                                AddNodes(tblDienstzeiten, nDienstzeiten, "Dienstzeit", repo, false);

                                List<Einrichtung> tblEinrichtungen = repo.dbcontext.Einrichtung.ToList();
                                Chilkat.Xml nEinrichtungen = nAllgemeineStammdaten.NewChild("Einrichtungen", "");
                                AddNodes(tblEinrichtungen, nEinrichtungen, "Einrichtung", repo, true);

                                List<Formular> tblFormulare = repo.dbcontext.Formular.ToList();
                                Chilkat.Xml nFormulare = nAllgemeineStammdaten.NewChild("Formulare", "");
                                AddNodes(tblFormulare, nFormulare, "Formular", repo, true);

                                List<Massnahmenserien> tblMassnahmenserien = repo.dbcontext.Massnahmenserien.ToList();
                                Chilkat.Xml nMassnahmenserien = nAllgemeineStammdaten.NewChild("Maßnahmenserien", "");
                                AddNodes(tblMassnahmenserien, nMassnahmenserien, "Maßnahmenserie", repo, true);

                                List<MedizinischeTypen> tblMedizinischeTypen = repo.dbcontext.MedizinischeTypen.ToList();
                                Chilkat.Xml nMedizinischeTypen = nAllgemeineStammdaten.NewChild("MedizinischeTypen", "");
                                AddNodes(tblMedizinischeTypen, nMedizinischeTypen, "MedizinischerTyp", repo, true);

                                List<Standardzeiten> tblStandardzeiten = repo.dbcontext.Standardzeiten.ToList();
                                Chilkat.Xml nStandardzeiten = nAllgemeineStammdaten.NewChild("Standardzeiten", "");
                                AddNodes(tblStandardzeiten, nStandardzeiten, "Standardzeit", repo, true);

                                List<Zeitbereich> tblZeitbereiche = repo.dbcontext.Zeitbereich.ToList();
                                Chilkat.Xml nZeitbereiche = nAllgemeineStammdaten.NewChild("Zeitbereiche", "");
                                AddNodes(tblZeitbereiche, nZeitbereiche, "Zeitbereich", repo, false);

                                Chilkat.Xml nBenutzer = nAllgemeineStammdaten.NewChild("BenutzerListe", "");
                                AddNodes(tblBenutzer, nBenutzer, "Benutzer", repo, true);

                                List<Aerzte> tblAerzte = (from ae in repo.dbcontext.Aerzte
                                                          join pae in repo.dbcontext.PatientAerzte on ae.Id equals pae.Idaerzte
                                                          where
                                                            pae.Idpatient == patDto.Id
                                                          select ae)
                                                              .OrderBy(ae => ae.Nachname)
                                                              .OrderBy(ae => ae.Vorname)
                                                              .ToList();
                                Chilkat.Xml nAerzte = nAllgemeineStammdaten.NewChild("Ärzte", "");
                                AddNodes(tblAerzte, nAerzte, "Arzt", repo, true);

                                //Pflegemodelle = nicht erforderlich
                                //Chilkat.Xml nAbrechnungStammdaten = xml.NewChild("Abrechnungsbezogene_Stammdaten", "");
                                //var tblKostentraeger = repo.dbcontext.Kostentraeger.ToList();
                                //Chilkat.Xml nKostentraegers = nAbrechnungStammdaten.NewChild("Kostentraeger", "");
                                //AddNodes(tblKostentraeger, nKostentraegers, "Kostentraeger", repo, true);
                                //Leistungskatalog, LeistungskatalogGueltig, Pflegegeldstufe, PflegegeldstufeGueltig, Sonderleistungskatalog, Taschengeld
                                //Pflegegeldstufe, PflegegeldstufeGueltig
                            }
                            SaveXML();
                        }

                        // ----------------- Klient ----------------------------
                        List<Patient> tblKlienten = repo.dbcontext.Patient.Where(p => p.Id == patDto.Id).ToList();
                        AddNodes(tblKlienten, xml, "Klient", repo, true);

                        using (Chilkat.Xml nKlient = xml.GetChildWithAttr("Klient", "Id", patDto.Id.ToString()))
                        {
                            if (dOpt.Klientendaten)
                            {
                                List<PatientenfotoDTO> PatientBild = (from p in repo.dbcontext.Patient
                                                                      where p.Id == patDto.Id
                                                                      select new PatientenfotoDTO { Id = p.Id, Foto = p.Foto }).ToList();
                                if (PatientBild.FirstOrDefault().Foto != null)
                                    ByteArrayToFile(Path.Combine(PathKlientenBild, KlientNameGebDat + ".jpg"), (Byte[])PatientBild.FirstOrDefault().Foto);

                                List<Kontaktperson> tblKontaktpersonen = repo.dbcontext.Kontaktperson.Where(kp => kp.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nKontaktpersonen = nKlient.NewChild("Kontaktpersonen", "");
                                AddNodes(tblKontaktpersonen, nKontaktpersonen, "Kontaktperson", repo, true);

                                List<PatientAerzte> tblPatientAerzte = repo.dbcontext.PatientAerzte.Where(a => a.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nPatientAerzte = nKlient.NewChild("Ärzte", "");
                                AddNodes(tblPatientAerzte, nPatientAerzte, "Arzt", repo, true);

                                List<Sachwalter> tblSachwalters = repo.dbcontext.Sachwalter.Where(sw => sw.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nSachwalters = nKlient.NewChild("Erwachsenenvertreter_Vorsorgebevollmächtigte", "");
                                AddNodes(tblSachwalters, nSachwalters, "Erwachsenenvertreter_Vorsorgebevollmächtigter", repo, true);

                                List<AnamneseKrohwinkel> tblAnamnesenKrohwinkel = repo.dbcontext.AnamneseKrohwinkel.Where(anak => anak.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nAnamnesenKrohwinkel = nKlient.NewChild("AnamnesenKrohwinkel", "");
                                AddNodes(tblAnamnesenKrohwinkel, nAnamnesenKrohwinkel, "AnamneseKrohwinkel", repo, true);

                                List<AnamneseOrem> tblAnamnesenOrem = repo.dbcontext.AnamneseOrem.Where(anao => anao.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nAnamnesenOrem = nKlient.NewChild("AnamnesenOrem", "");
                                AddNodes(tblAnamnesenOrem, nAnamnesenOrem, "AnamneseOrem", repo, true);

                                List<AnamnesePop> tblAnamnesenPOP = repo.dbcontext.AnamnesePop.Where(anap => anap.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nAnamnesenPOP = nKlient.NewChild("AnamnesenPOP", "");
                                AddNodes(tblAnamnesenPOP, nAnamnesenPOP, "AnamnesePOP", repo, true);

                                List<Rehabilitation> tblRehabilitationen = repo.dbcontext.Rehabilitation.Where(reha => reha.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nRehabilitationen = nKlient.NewChild("Rehabilitationen", "");
                                AddNodes(tblRehabilitationen, nRehabilitationen, "Rehabilitation", repo, true);

                                List<Arztabrechnung> tblArztabrechnungen = repo.dbcontext.Arztabrechnung.Where(aa => aa.Idpatient == patDto.Id).OrderBy(aa => aa.Datum).ToList();
                                Chilkat.Xml nArztabrechnungen = nKlient.NewChild("Arztabrechnungen", "");
                                AddNodes(tblArztabrechnungen, nArztabrechnungen, "Arztabrechnung", repo, true);

                                List<PatientPflegestufe> tblPflegeStufen = repo.dbcontext.PatientPflegestufe.Where(ps => ps.Idpatient == patDto.Id).OrderBy(ps => ps.GueltigAb).ToList();
                                Chilkat.Xml nPflegeStufen = nKlient.NewChild("PflegeStufen", "");
                                AddNodes(tblPflegeStufen, nPflegeStufen, "PflegeStufe", repo, true);

                                List<PatientenBemerkung> tblPatientBemerkungen = repo.dbcontext.PatientenBemerkung.Where(pbem => pbem.Idpatient == patDto.Id).ToList();
                                Chilkat.Xml nPatientBemerkungen = nKlient.NewChild("PatientBemerkungen", "");
                                AddNodes(tblPatientBemerkungen, nPatientBemerkungen, "PatientBemerkung", repo, true);

                                List<MedizinischeDaten> tblMedizinischeDaten = repo.dbcontext.MedizinischeDaten.Where(ps => ps.Idpatient == patDto.Id).OrderBy(ps => ps.Typ).OrderBy(ps => ps.Von).ToList();
                                Chilkat.Xml nMedizinischeDaten = nKlient.NewChild("MedizinischeDaten", "");
                                AddNodes(tblMedizinischeDaten, nMedizinischeDaten, "MedizinischesDatum", repo, true);

                                List<FormularDaten> tblFormularDaten = repo.dbcontext.FormularDaten.Where(fd => fd.Idref == patDto.Id && fd.PdfBlop != null).OrderBy(fd => fd.FormularName).OrderBy(fd => fd.Datumerstellt).ToList();
                                Chilkat.Xml nFormulardaten = nKlient.NewChild("Formulardaten", "");
                                AddNodes(tblFormularDaten, nFormulardaten, "Formular", repo, true);
                                foreach (var fd in tblFormularDaten)
                                {
                                    ExportFDF(fd.Id, StripSpecialCharacters(fd.FormularName), fd.Datumerstellt, fd.PdfBlop, PathKlientenFormulare, KlientNameGebDat, repo);
                                }

                                List<FormularDaten> tblBiografien = repo.dbcontext.FormularDaten.Where(bio => bio.Idref == patDto.Id && bio.PdfBlop == null && (bio.Blop.ToString().StartsWith(@"{\rtf1"))).OrderBy(az => az.FormularName).OrderBy(az => az.Datumerstellt).ToList();
                                Chilkat.Xml nBiografien = nKlient.NewChild("Biografien", "");
                                AddNodes(tblBiografien, nBiografien, "Biografie", repo, true);
                                foreach (var fd in tblBiografien)
                                {
                                    string FileNameWundeBild = System.IO.Path.Combine(PathKlientenBiografien, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(StripSpecialCharacters(fd.FormularName)) + "_" + fd.Datumerstellt.ToString("yyyyMMddHHmmss") + "_" + fd.Id.ToString() + ".rtf");
                                    StringToFile(FileNameWundeBild, fd.Blop);
                                }

                                if (dOpt.KlientenTermineArchiv)
                                {
                                    //Kliententermine
                                    List<PlanObject> tblPlaene = repo.dbcontext.PlanObject.Where(plan => plan.Idobject == patDto.Id).OrderBy(plan => plan.Status).ToList();
                                    Chilkat.Xml nPlaene = nKlient.NewChild("Kliententermine_Pläne", "");
                                    AddNodes(tblPlaene, nPlaene, "Kliententermin_Plan", repo, true);

                                    //Archiv
                                    List<TblDokumente> tblArchiv = (from dok in repo.dbcontext.TblDokumente
                                                                    join dokein in repo.dbcontext.TblDokumenteintrag on dok.Iddokumenteintrag equals dokein.Id
                                                                    join obj in repo.dbcontext.TblObjekt on dokein.Id equals obj.Iddokumenteintrag
                                                                    where obj.IdGuid == patDto.Id
                                                                    select dok)
                                                        .OrderBy(dok => dok.ErstelltAm)
                                                        .ToList();
                                    Chilkat.Xml nArchiv = nKlient.NewChild("Archiveinträge", "");
                                    AddNodes(tblArchiv, nArchiv, "Archiveintrag", repo, true);

                                    //Archiv-Files auf Platte schreiben
                                    foreach (var rArchiv in tblArchiv)
                                    {
                                        string FileArchiv = Path.Combine(ArchivPath, rArchiv.Archivordner, rArchiv.DateinameArchiv);
                                        string FileKopie = Path.Combine(PathKlientenArchiv, rArchiv.DateinameOrig);
                                        if (File.Exists(FileArchiv))
                                        {
                                            File.Copy(FileArchiv, FileKopie, true);
                                        }
                                        else
                                        {
                                            System.IO.File.WriteAllText(FileKopie + ".NOTFOUND", "");
                                        }
                                    }
                                }

                                SaveXML();

                                //Abrechungsdaten - checken, ob wir die brauchen (eher nein, Buchhaltung muss sich ohnehin die Rechnungen aufheben. Das reicht.)
                                //bills, billHeader, Bookings, PatientAbwesenheit, PatientLeistungsplan, PatientEinkommen, PatientKostentraeger,
                                //PatientSonderleistung, PatientTaschengeldKostentraeger
                            }

                            //---------------------- Aufenthalte ---------------------------------------------------------------------------
                            Chilkat.Xml nAufenthalte = nKlient.NewChild("Aufenthalte", "");

                            List<AufenthaltDTO> tIDAufenthalte = (from Idaufenthalte in repo.dbcontext.Aufenthalt
                                                                  where Idaufenthalte.Idpatient == patDto.Id
                                                                  select new AufenthaltDTO { Id = Idaufenthalte.Id, Aufnahmezeitpunkt = (DateTime)Idaufenthalte.Aufnahmezeitpunkt })
                                                    .OrderBy(o => o.Aufnahmezeitpunkt).ToList();

                            foreach (var rAufenthalt in tIDAufenthalte)
                            {
                                List<Aufenthalt> tblAufenthalte = repo.dbcontext.Aufenthalt.Where(a => a.Id == rAufenthalt.Id).OrderBy(a => a.Aufnahmezeitpunkt).ToList();
                                AddNodes(tblAufenthalte, nAufenthalte, "Aufenthalt", repo, true);

                                Chilkat.Xml nAufenthalt = nAufenthalte.GetChildWithAttr("Aufenthalt", "Id", rAufenthalt.Id.ToString());

                                if (dOpt.Aufenthaltsdaten)
                                {
                                    List<AufenthaltZusatz> tblAufenthaltzusatz = repo.dbcontext.AufenthaltZusatz.Where(az => az.Idaufenthalt == rAufenthalt.Id).ToList();
                                    AddNodes(tblAufenthaltzusatz, nAufenthalt, "Aufenthaltzusatz", repo, true);

                                    List<Gegenstaende> tblGegestaende = repo.dbcontext.Gegenstaende.Where(az => az.Idaufenthalt == rAufenthalt.Id && az.HilfesmittelJn == false).ToList();
                                    Chilkat.Xml nGegenstaende = nAufenthalt.NewChild("Gegenstände", "");
                                    AddNodes(tblGegestaende, nGegenstaende, "Gegenstand", repo, true);

                                    List<Gegenstaende> tblHilfsmittel = repo.dbcontext.Gegenstaende.Where(az => az.Idaufenthalt == rAufenthalt.Id && az.HilfesmittelJn == true).ToList();
                                    Chilkat.Xml nHilfsmitteln = nAufenthalt.NewChild("HilfsmittelListe", "");
                                    AddNodes(tblHilfsmittel, nHilfsmitteln, "Hilfsmittel", repo, true);

                                    List<Unterbringung> tblUnterbringungen = repo.dbcontext.Unterbringung.Where(az => az.Idaufenthalt == rAufenthalt.Id).ToList();
                                    Chilkat.Xml nUnterbringungen = nAufenthalt.NewChild("HAG_Meldungen", "");
                                    AddNodes(tblUnterbringungen, nUnterbringungen, "HAG_Meldung", repo, true);

                                    List<UrlaubVerlauf> tblUrlaubVerlauf = repo.dbcontext.UrlaubVerlauf.Where(az => az.Idaufenthalt == rAufenthalt.Id).OrderBy(az => az.StartDatum).ToList();
                                    Chilkat.Xml nAbwesenheiten = nAufenthalt.NewChild("Abwesenheiten", "");
                                    AddNodes(tblUrlaubVerlauf, nAbwesenheiten, "Abwesenheit", repo, true);

                                    List<AufenthaltVerlauf> tblAufenthaltVerlauf = repo.dbcontext.AufenthaltVerlauf.Where(az => az.Idaufenthalt == rAufenthalt.Id).OrderBy(az => az.Datum).ToList();
                                    Chilkat.Xml nVersetzungen = nAufenthalt.NewChild("AufenthaltsverlaufListe", "");
                                    AddNodes(tblAufenthaltVerlauf, nVersetzungen, "Aufenthaltsverlauf", repo, true);
                                    SaveXML();

                                }

                                using (Chilkat.Xml nPflegeplan = nAufenthalt.NewChild("Pflegeplan", ""))
                                {
                                    if (dOpt.Pflegeplan)
                                    {
                                        List<AufenthaltPdx> tblAufenthaltPDXsPP = repo.dbcontext.AufenthaltPdx.Where(apdx => apdx.Idaufenthalt == rAufenthalt.Id && apdx.Wundejn == false).ToList();
                                        int iAufenthaltPDxPP = AddNodes(tblAufenthaltPDXsPP, nPflegeplan, "Aufenthalt_PDX", repo, true);

                                        for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsPP.Count; iAPDX++)
                                        {
                                            Guid IDAufenthaltPDX = tblAufenthaltPDXsPP[iAPDX].Id;
                                            Guid IDPDX = (Guid)tblAufenthaltPDXsPP[iAPDX].Idpdx;

                                            List<PflegePlanPdx> tblPflegeplanPDX = repo.dbcontext.PflegePlanPdx.Where(az => az.IdaufenthaltPdx == IDAufenthaltPDX && az.Idpdx == IDPDX).ToList();

                                            Chilkat.Xml nPDX = nPflegeplan.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

                                            List<PflegePlan> tblPflegeplaene = (from pp in repo.dbcontext.PflegePlan
                                                                                join ppdx in repo.dbcontext.PflegePlanPdx on pp.Id equals ppdx.IdpflegePlan
                                                                                join pdx in repo.dbcontext.Pdx on ppdx.Idpdx equals pdx.Id
                                                                                join apdx in repo.dbcontext.AufenthaltPdx on ppdx.IdaufenthaltPdx equals apdx.Id
                                                                                where
                                                                                    pp.Idaufenthalt == rAufenthalt.Id &&
                                                                                    (pp.EintragGruppe == "A" || pp.EintragGruppe == "S" || pp.EintragGruppe == "R" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                                                    pp.IduntertaegigeGruppe == ppdx.IduntertaegigeGruppe &&
                                                                                    apdx.Id == IDAufenthaltPDX &&
                                                                                    pdx.Id == IDPDX
                                                                                select pp)
                                                                    .OrderBy(apdx => apdx.ErledigtJn)
                                                                    .OrderBy(ppdx => ppdx.ErledigtJn)
                                                                    .OrderBy(pp => pp.StartDatum)
                                                                    .ToList();

                                            if (tblPflegeplaene.Count() > 0)
                                            {
                                                Chilkat.Xml nAetiologien = nPDX.NewChild("Ätiologien_Risikofaktoren", "");
                                                List<PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                                AddNodes(tblAetiologien, nAetiologien, "Ätiologie_Risikofaktor", repo, true);

                                                Chilkat.Xml nSymptome = nPDX.NewChild("Symptome", "");
                                                List<PflegePlan> tblSymptome = tblPflegeplaene.Where(pp => pp.EintragGruppe == "S").ToList();
                                                AddNodes(tblSymptome, nSymptome, "Symptom", repo, true);

                                                Chilkat.Xml nRessourcen = nPDX.NewChild("Ressourcen", "");
                                                List<PflegePlan> tblRessourcen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "R").ToList();
                                                AddNodes(tblRessourcen, nRessourcen, "Ressource", repo, true);

                                                Chilkat.Xml nZiele = nPDX.NewChild("Ziele", "");
                                                List<PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                                AddNodes(tblZiele, nZiele, "Ziel", repo, true);

                                                //Evaluierung zu Pflegeplan (Ziele)
                                                if (tblZiele.Count() > 0)
                                                {
                                                    foreach (PflegePlan rZiel in tblZiele)
                                                    {
                                                        List<PflegeEintrag> tblEvaluierungen = repo.dbcontext.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IdpflegePlan == rZiel.Id).OrderBy(pe => pe.DatumErstellt).ToList();
                                                        if (tblEvaluierungen.Count() > 0)
                                                        {
                                                            Chilkat.Xml nZiel = nZiele.GetChildWithAttr("Ziel", "Id", rZiel.Id.ToString());
                                                            if (nZiel != null)
                                                            {
                                                                Chilkat.Xml nPPZielEvaluierungen = nZiel.NewChild("Evaluierungen-Pflegeplan", "");
                                                                AddNodes(tblEvaluierungen, nPPZielEvaluierungen, "EvaluierungPflegeplan", repo, false);
                                                            }
                                                        }
                                                    }
                                                }

                                                Chilkat.Xml nMassnahmen = nPDX.NewChild("Maßnahmen", "");
                                                List<PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                                AddNodes(tblMassnahmen, nMassnahmen, "Maßnahme", repo, true);
                                            }
                                        }
                                        SaveXML();

                                    }

                                    if (dOpt.PflegeplanTermine)
                                    {
                                        using (Chilkat.Xml nTermine = nPflegeplan.NewChild("Termine", ""))
                                        {
                                            List<PflegePlan> tblTermine = repo.dbcontext.PflegePlan.Where(pp => pp.Idaufenthalt == rAufenthalt.Id && pp.EintragGruppe == "T").OrderBy(pp => pp.StartDatum).ToList();
                                            AddNodes(tblTermine, nTermine, "Termin", repo, true);
                                        }
                                        SaveXML();

                                    }

                                    if (dOpt.PflegeplanHistorie)
                                    {
                                        using (Chilkat.Xml nPflegeplaeneH = nPflegeplan.NewChild("PflegepläneHistorie", ""))
                                        {
                                            List<PflegePlanH> tblPflegeplanH = (from pph in repo.dbcontext.PflegePlanH
                                                                                join e in repo.dbcontext.Eintrag on pph.Ideintrag equals e.Id
                                                                                select pph)
                                                                                .Where(pp => pp.Idaufenthalt == rAufenthalt.Id)
                                                                                .OrderBy(e => e.Text)
                                                                                .OrderBy(pp => pp.DatumErstellt)
                                                                                .ToList();
                                            AddNodes(tblPflegeplanH, nPflegeplaeneH, "PflegeplanHistorie", repo, true);
                                        }
                                        SaveXML();

                                    }
                                }

                                if (dOpt.PflegeDokumentation)
                                {
                                    using (Chilkat.Xml nPflegedokumentation = nAufenthalt.NewChild("Pflegedokumentation", ""))
                                    {
                                        List<PflegeEintrag> tblPflegeeintraege = repo.dbcontext.PflegeEintrag.Where(pe => pe.Idaufenthalt == rAufenthalt.Id && pe.EintragsTyp != 2).ToList();

                                        Chilkat.Xml nPE_NONE = nPflegedokumentation.NewChild("Ohne_Klassifizierungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == -1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NONE, "Doku_Ohne_Klassifizierung", repo, false);
                                        Chilkat.Xml nPE_DEKURS = nPflegedokumentation.NewChild("Dekurse", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 0).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Dekurs", repo, false);
                                        Chilkat.Xml nPE_MASSNAHME = nPflegedokumentation.NewChild("Maßnahmen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Maßnahme", repo, false);
                                        Chilkat.Xml nPE_UNEXP_MASSNAHME = nPflegedokumentation.NewChild("Ungeplante_Maßnahmen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 3).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_UNEXP_MASSNAHME, "Doku_Ungeplante_Maßnahme", repo, false);
                                        Chilkat.Xml nPE_TERMIN = nPflegedokumentation.NewChild("Termine", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 4).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_TERMIN, "Doku_Termin", repo, false);
                                        Chilkat.Xml nPE_MEDIKAMENT = nPflegedokumentation.NewChild("Medikamente", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 5).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_MEDIKAMENT, "Doku_Medikament", repo, false);
                                        Chilkat.Xml nPE_NOTFALL = nPflegedokumentation.NewChild("Notfälle", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 6).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NOTFALL, "Doku_Notfall", repo, false);
                                        Chilkat.Xml nPE_PLANUNG = nPflegedokumentation.NewChild("Planungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 7).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_PLANUNG, "Doku_Planung", repo, false);
                                        Chilkat.Xml nPE_WUNDE = nPflegedokumentation.NewChild("Wunden", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 8).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDE, "Doku_Wunde", repo, false);
                                        Chilkat.Xml nPE_KLIENT = nPflegedokumentation.NewChild("Klienten", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 9).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_KLIENT, "Doku_Klient", repo, false);
                                        Chilkat.Xml nPE_ASSESSMENT = nPflegedokumentation.NewChild("Assessments", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 10).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_ASSESSMENT, "Doku_Assessment", repo, false);
                                        Chilkat.Xml nPE_VERORDNUNGEN = nPflegedokumentation.NewChild("Verordnungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 11).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_VERORDNUNGEN, "Doku_Verordnung", repo, false);
                                        Chilkat.Xml nPE_WUNDVERLAUF = nPflegedokumentation.NewChild("Wundverläufe", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 12).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDVERLAUF, "Doku_Wundverlauf", repo, false);
                                        Chilkat.Xml nPE_WUNDTHERAPIE = nPflegedokumentation.NewChild("Wundtherapien", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 13).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDTHERAPIE, "Doku_Wundtherapie", repo, false);
                                        SaveXML();

                                    }
                                }

                                if (dOpt.WundDokumentation)
                                {
                                    using (Chilkat.Xml nWunden = nAufenthalt.NewChild("Wunddokumentation", ""))
                                    {
                                        List<AufenthaltPdx> tblAufenthaltPDXsW = repo.dbcontext.AufenthaltPdx.Where(apdx => apdx.Idaufenthalt == rAufenthalt.Id && apdx.Wundejn == true).ToList();
                                        int iAufenthaltPDxW = AddNodes(tblAufenthaltPDXsW, nWunden, "Aufenthalt_PDX_Wunde", repo, true);

                                        for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsW.Count; iAPDX++)
                                        {
                                            Guid IDAufenthaltPDX = tblAufenthaltPDXsW[iAPDX].Id;
                                            Guid IDPDX = (Guid)tblAufenthaltPDXsW[iAPDX].Idpdx;

                                            List<PflegePlanPdx> tblPflegeplanPDX = repo.dbcontext.PflegePlanPdx.Where(az => az.IdaufenthaltPdx == IDAufenthaltPDX && az.Idpdx == IDPDX).ToList();

                                            Chilkat.Xml nPDX_Wunde = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

                                            List<PflegePlan> tblPflegeplaene = (from pp in repo.dbcontext.PflegePlan
                                                                                join ppdx in repo.dbcontext.PflegePlanPdx on pp.Id equals ppdx.IdpflegePlan
                                                                                join pdx in repo.dbcontext.Pdx on ppdx.Idpdx equals pdx.Id
                                                                                join apdx in repo.dbcontext.AufenthaltPdx on ppdx.IdaufenthaltPdx equals apdx.Id
                                                                                where
                                                                                    pp.Idaufenthalt == rAufenthalt.Id &&
                                                                                    (pp.EintragGruppe == "A" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                                                    pp.IduntertaegigeGruppe == ppdx.IduntertaegigeGruppe &&
                                                                                    apdx.Id == IDAufenthaltPDX &&
                                                                                    pdx.Id == IDPDX
                                                                                select pp)
                                                                    .OrderBy(apdx => apdx.ErledigtJn)
                                                                    .OrderBy(ppdx => ppdx.ErledigtJn)
                                                                    .OrderBy(pp => pp.StartDatum)
                                                                    .ToList();

                                            if (tblPflegeplaene.Count() > 0)
                                            {
                                                Chilkat.Xml nAetiologien = nPDX_Wunde.NewChild("BeeinflussendeFaktoren", "");
                                                List<PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                                AddNodes(tblAetiologien, nAetiologien, "BeeinflussenderFaktor", repo, true);

                                                Chilkat.Xml nZiele = nPDX_Wunde.NewChild("Ziele", "");
                                                List<PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                                AddNodes(tblZiele, nZiele, "Ziel", repo, true);

                                                //Evaluierung zu Pflegeplan (Ziele)
                                                if (tblZiele.Count() > 0)
                                                {
                                                    foreach (PflegePlan rZiel in tblZiele)
                                                    {
                                                        List<PflegeEintrag> tblEvaluierungen = repo.dbcontext.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IdpflegePlan == rZiel.Id).OrderBy(pe => pe.DatumErstellt).ToList();
                                                        if (tblEvaluierungen.Count() > 0)
                                                        {
                                                            Chilkat.Xml nZiel = nZiele.GetChildWithAttr("Ziel", "Id", rZiel.Id.ToString());
                                                            if (nZiel != null)
                                                            {
                                                                Chilkat.Xml nWundeZielEvaluierungen = nZiel.NewChild("Evaluierungen-Wunde", "");
                                                                AddNodes(tblEvaluierungen, nWundeZielEvaluierungen, "EvaluierungWunde", repo, true);
                                                            }
                                                        }
                                                    }
                                                }

                                                Chilkat.Xml nMassnahmen = nPDX_Wunde.NewChild("Maßnahmen", "");
                                                List<PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                                AddNodes(tblMassnahmen, nMassnahmen, "Maßnahme", repo, true);

                                                Chilkat.Xml nPDX = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);
                                                List<WundeKopf> tblWundeKopf = repo.dbcontext.WundeKopf.Where(wk => wk.IdaufenthaltPdx == IDAufenthaltPDX).ToList();
                                                if (tblWundeKopf.Count() > 0)
                                                {
                                                    AddNodes(tblWundeKopf, nPDX, "Wunde", repo, true);
                                                    Chilkat.Xml nWunde = nPDX.GetChildWithTag("Wunde");

                                                    Guid IDWundeKopf = new Guid(nWunde.GetAttrValue("Id"));

                                                    Chilkat.Xml nWundeTherapien = nWunde.NewChild("Wundetherapien", "");
                                                    List<WundeTherapie> tblWundeTherapie = repo.dbcontext.WundeTherapie.Where(wv => wv.IdwundeKopf == IDWundeKopf).OrderBy(wt => wt.DatumErstellt).ToList();
                                                    AddNodes(tblWundeTherapie, nWundeTherapien, "Wundtherapie", repo, true);

                                                    Chilkat.Xml nWundeVerlauefe = nWunde.NewChild("Wundeverläufe", "");
                                                    List<WundePos> tblWundeVerlaufe = repo.dbcontext.WundePos.Where(wv => wv.IdwundeKopf == IDWundeKopf).OrderBy(wv => wv.DatumErstellt).ToList();
                                                    AddNodes(tblWundeVerlaufe, nWundeVerlauefe, "Wundverlauf", repo, true);

                                                    Chilkat.Xml nWundeBilder = nWunde.NewChild("Wundbilder", "");
                                                    List<WundePosBilder> tblWundePosBilder = (from wb in repo.dbcontext.WundePosBilder
                                                                                              join wp in repo.dbcontext.WundePos on wb.IdwundePos equals wp.Id
                                                                                              where wp.IdwundeKopf == IDWundeKopf
                                                                                              select wb)
                                                                            .OrderBy(wb => wb.DatumErstellt)
                                                                            .ToList();
                                                    AddNodes(tblWundePosBilder, nWundeBilder, "Wundbild", repo, true);

                                                    //Bilder auf Platte speichern
                                                    foreach (WundePosBilder wb in tblWundePosBilder)
                                                    {
                                                        string FileNameWundeBild = System.IO.Path.Combine(PathWundeBilder, KlientNameGebDat + "_Wundbild_" + wb.ZeitpunktBild.ToString("yyyyMMddHHmmss") + "_" + wb.Id.ToString() + ".jpg");
                                                        ByteArrayToFile(FileNameWundeBild, wb.Bild);
                                                    }
                                                }
                                            }
                                        }
                                        SaveXML();

                                    }
                                }

                                if (dOpt.Medikamente)
                                {
                                    using (Chilkat.Xml nMedikamente = nAufenthalt.NewChild("Medikamente", ""))
                                    {
                                        //Mitverantwortlicher Bereich (Medikamente) -----------------------------------------------------------------------
                                        //Daten auf einmal lesen
                                        List<MedikamenteDTO> tblIDMedikamente = (from medikamente in repo.dbcontext.Medikament
                                                                                 join re in repo.dbcontext.RezeptEintrag on medikamente.Id equals re.Idmedikament
                                                                                 where
                                                                                 re.Idaufenthalt == rAufenthalt.Id
                                                                                 select new MedikamenteDTO { Id = medikamente.Id, Bezeichnung = medikamente.Bezeichnung })
                                                                    .Distinct()
                                                                    .ToList();

                                        List<Medikament> tblMedikamente = (from med02 in repo.dbcontext.Medikament
                                                                           join tlstIDMed in tblIDMedikamente on med02.Id equals tlstIDMed.Id
                                                                           select med02).Distinct().ToList();

                                        List<RezeptEintrag> tblRezepteintraege = (from med1 in repo.dbcontext.Medikament
                                                                                  join re in repo.dbcontext.RezeptEintrag on med1.Id equals re.Idmedikament
                                                                                  where
                                                                                  re.Idaufenthalt == rAufenthalt.Id
                                                                                  select re)
                                                                .OrderBy(re => re.AbzugebenVon)
                                                                .ToList();

                                        List<MedikationAbgabe> tblMedikationAbgaben = (from re in repo.dbcontext.RezeptEintrag
                                                                                       join medab in repo.dbcontext.MedikationAbgabe on re.Id equals medab.IdrezeptEintrag
                                                                                       where
                                                                                           re.Idaufenthalt == rAufenthalt.Id
                                                                                       select medab)
                                                                    .OrderBy(medab => medab.Zeitpunkt)
                                                                    .ToList();

                                        List<RezeptBestellungPos> tblRezeptBestellungen = (from re in repo.dbcontext.RezeptEintrag
                                                                                           join rebest in repo.dbcontext.RezeptBestellungPos on re.Id equals rebest.IdrezeptEintrag
                                                                                           where re.Idaufenthalt == rAufenthalt.Id
                                                                                           select rebest)
                                        .OrderBy(rebest => rebest.RezeptAnforderungDatum)
                                        .ToList();

                                        AddNodes(tblMedikamente, nMedikamente, "Medikament", repo, true);
                                        foreach (Medikament Medikament in tblMedikamente)
                                        {
                                            Chilkat.Xml nRezepteintraege = nMedikamente.GetChildWithAttr("Medikament", "Id", Medikament.Id.ToString());
                                            if (nRezepteintraege != null)
                                            {
                                                List<RezeptEintrag> tblre = (from re in tblRezepteintraege
                                                                             where re.Idmedikament == Medikament.Id
                                                                             select re).ToList();
                                                if (tblre.Count() > 0)
                                                {
                                                    AddNodes(tblre, nRezepteintraege, "Rezepteintrag", repo, true);

                                                    foreach (RezeptEintrag re in tblre)
                                                    {
                                                        Chilkat.Xml nRezepteintrag = nRezepteintraege.GetChildWithAttr("Rezepteintrag", "Id", re.Id.ToString());
                                                        if (nRezepteintrag != null)
                                                        {
                                                            List<MedikationAbgabe> tblMedAbg = (from medab in tblMedikationAbgaben
                                                                                                where medab.IdrezeptEintrag == re.Id
                                                                                                select medab).ToList();

                                                            if (tblMedAbg.Count() > 0)
                                                            {
                                                                Chilkat.Xml nMedikamentenAbgaben = nRezepteintrag.NewChild("Medikamenentabgaben", "");
                                                                AddNodes(tblMedAbg, nMedikamentenAbgaben, "Medikamentenabgabe", repo, false);
                                                            }

                                                            List<RezeptBestellungPos> tblRezBest = (from rezbest in tblRezeptBestellungen
                                                                                                    where rezbest.IdrezeptEintrag == re.Id
                                                                                                    select rezbest).ToList();

                                                            if (tblRezBest.Count() > 0)
                                                            {
                                                                Chilkat.Xml nRezeptbestellungen = nRezepteintrag.NewChild("Rezeptbestellungen", "");
                                                                AddNodes(tblRezBest, nRezeptbestellungen, "Rezeptbestellung", repo, false);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        SaveXML();

                                    }
                                }

                                if (dOpt.Standardprozeduren)
                                {
                                    //Standardprozeduren
                                    using (Chilkat.Xml nStandardprozeduren = nAufenthalt.NewChild("Standardprozeduren", ""))
                                    {

                                        List<StandardProzeduren> tblStandardProzeduren = (from sproz in repo.dbcontext.StandardProzeduren
                                                                                          join sp in repo.dbcontext.Sp on sproz.Id equals sp.IdstandardProzeduren
                                                                                          where sp.Idaufenthalt == rAufenthalt.Id
                                                                                          select sproz)
                                                                                        .Distinct()
                                                                                        .OrderBy(sproz => sproz.Name)
                                                                                        .ToList();

                                        List<Sp> tblSp = (from sp in repo.dbcontext.Sp
                                                          where sp.Idaufenthalt == rAufenthalt.Id
                                                          select sp)
                                                        .OrderBy(sp => sp.Zeitpunkt)
                                                        .ToList();

                                        List<Sppos> tblSppos = (from sppos in repo.dbcontext.Sppos
                                                                join sp in repo.dbcontext.Sp on sppos.Idsp equals sp.Id
                                                                where sp.Idaufenthalt == rAufenthalt.Id
                                                                select sppos)
                                                        .OrderBy(sppos => sppos.DatumErstellt)
                                                        .ToList();

                                        List<Sppe> tblSppe = (from sppe in repo.dbcontext.Sppe
                                                              join sp in repo.dbcontext.Sp on sppe.Idsp equals sp.Id
                                                              where sp.Idaufenthalt == rAufenthalt.Id
                                                              select sppe)
                                                                .ToList();

                                        List<StandardProzeduren> tblStandardprozeduren_SP = (from sproz in tblStandardProzeduren
                                                                                             select sproz)
                                                                                        .Where(sp => sp.NotfallJn == false)
                                                                                        .ToList();

                                        List<StandardProzeduren> tblStandardprozeduren_N = (from sproz in tblStandardProzeduren
                                                                                            select sproz)
                                                                                        .Where(sp => sp.NotfallJn == true)
                                                                                        .ToList();

                                        //Standardprozeduren
                                        int nSProz_SP = AddNodes(tblStandardprozeduren_SP, nStandardprozeduren, "Standardprozedur", repo, true);
                                        for (int iSProz_SP = 0; iSProz_SP < nSProz_SP; iSProz_SP++)
                                        {
                                            Chilkat.Xml nStandardProzedur = nStandardprozeduren.GetChild(iSProz_SP);
                                            Guid IdSProz_SP = new Guid(nStandardProzedur.GetAttrValue("Id"));
                                            List<Sp> tblSP_SP = (from sp in tblSp
                                                                 select sp)
                                                                  .Where(sp => sp.IdstandardProzeduren == IdSProz_SP)
                                                                  .OrderBy(sp => sp.Zeitpunkt)
                                                                  .ToList();
                                            int nSP_SP = AddNodes(tblSP_SP, nStandardProzedur, "Standardprozedur", repo, true);

                                            for (int iSP_SP = 0; iSP_SP < nSP_SP; iSP_SP++)
                                            {
                                                Chilkat.Xml nStandardprozedurSP = nStandardProzedur.GetChild(iSP_SP);
                                                Guid IdSP_SP = new Guid(nStandardprozedurSP.GetAttrValue("Id"));
                                                List<Sppos> tblSPPOS_SP = (from sppos in tblSppos
                                                                           select sppos)
                                                                  .Where(sppos => sppos.Idsp == IdSP_SP)
                                                                  .OrderBy(sppos => sppos.DatumErstellt)
                                                                  .ToList();

                                                int nSPPos_SP = AddNodes(tblSPPOS_SP, nStandardprozedurSP, "Standardprozedur_Eintrag", repo, true);
                                                for (int iSPPos_SP = 0; iSPPos_SP < nSPPos_SP; iSPPos_SP++)
                                                {
                                                    Chilkat.Xml nStandardprozedurSPPos = nStandardprozedurSP.GetChild(iSPPos_SP);
                                                    Guid IdEintrag_SP = new Guid(nStandardprozedurSPPos.GetAttrValue("Ideintrag"));
                                                    List<Eintrag> tblEintrag_SP = (from e in repo.dbcontext.Eintrag
                                                                                   select e)
                                                                                  .Where(e => e.Id == IdEintrag_SP)
                                                                                  .ToList();
                                                    AddNodes(tblEintrag_SP, nStandardprozedurSPPos, "Eintrag", repo, true);
                                                }

                                                List<Sppe> tblSPPE_SP = (from sppe in tblSppe
                                                                         select sppe)
                                                                      .Where(sppe => sppe.Idsp == IdSP_SP)
                                                                      .ToList();

                                                int nSPPE_SP = tblSPPE_SP.Count();
                                                for (int iSPPE_SP = 0; iSPPE_SP < nSPPE_SP; iSPPE_SP++)
                                                {
                                                    Guid IdPflegeeintrag = tblSPPE_SP[iSPPE_SP].IdpflegeEintrag;
                                                    List<PflegeEintrag> tblPflegeEintrag_SP = (from pe in repo.dbcontext.PflegeEintrag
                                                                                               join sppe in tblSPPE_SP on pe.Id equals sppe.IdpflegeEintrag
                                                                                               select pe)
                                                                                  .Where(pe => pe.Id == IdPflegeeintrag)
                                                                                  .OrderBy(pe => pe.Zeitpunkt)
                                                                                  .ToList();
                                                    AddNodes(tblPflegeEintrag_SP, nStandardprozedurSP, "MaßnahmeMeldung", repo, false);
                                                }
                                            }


                                            //Notfälle
                                            Chilkat.Xml nNotfallprozeduren = nAufenthalt.NewChild("Notfallprozeduren", "");
                                            int nSProz_N = AddNodes(tblStandardprozeduren_N, nNotfallprozeduren, "Notfallprozedur", repo, true);
                                            for (int iSProz_N = 0; iSProz_N < nSProz_N; iSProz_N++)
                                            {
                                                Chilkat.Xml nNotfallProzedur = nNotfallprozeduren.GetChild(iSProz_N);
                                                Guid IdSProz_N = new Guid(nNotfallProzedur.GetAttrValue("Id"));
                                                List<Sp> tblSP_N = (from sp in tblSp
                                                                    select sp)
                                                                      .Where(sp => sp.IdstandardProzeduren == IdSProz_N)
                                                                      .OrderBy(sp => sp.Zeitpunkt)
                                                                      .ToList();
                                                int nSP_N = AddNodes(tblSP_N, nNotfallProzedur, "Notfall", repo, true);

                                                for (int iSP_N = 0; iSP_N < nSP_N; iSP_N++)
                                                {
                                                    Chilkat.Xml nNotfallSP = nNotfallProzedur.GetChild(iSP_N);
                                                    Guid IdSP_N = new Guid(nNotfallSP.GetAttrValue("Id"));
                                                    List<Sppos> tblSPPOS_N = (from sppos in tblSppos
                                                                              select sppos)
                                                                      .Where(sppos => sppos.Idsp == IdSP_N)
                                                                      .OrderBy(sppos => sppos.DatumErstellt)
                                                                      .ToList();

                                                    int nSPPos_N = AddNodes(tblSPPOS_N, nNotfallSP, "Notfall_Eintrag", repo, true);
                                                    for (int iSPPos_N = 0; iSPPos_N < nSPPos_N; iSPPos_N++)
                                                    {
                                                        Chilkat.Xml nNotfallSPPos = nNotfallSP.GetChild(iSPPos_N);
                                                        Guid IdEintrag_N = new Guid(nNotfallSPPos.GetAttrValue("Ideintrag"));
                                                        List<Eintrag> tblEintrag_N = (from e in repo.dbcontext.Eintrag
                                                                                      select e)
                                                                                      .Where(e => e.Id == IdEintrag_N)
                                                                                      .ToList();
                                                        AddNodes(tblEintrag_N, nNotfallSPPos, "Eintrag", repo, true);
                                                    }

                                                    List<Sppe> tblSPPE_N = (from sppe in tblSppe
                                                                            select sppe)
                                                                          .Where(sppe => sppe.Idsp == IdSP_N)
                                                                          .ToList();

                                                    int nSPPE_N = tblSPPE_N.Count();
                                                    for (int iSPPE_N = 0; iSPPE_N < nSPPE_N; iSPPE_N++)
                                                    {
                                                        Guid IdPflegeeintrag = tblSPPE_N[iSPPE_N].IdpflegeEintrag;
                                                        List<PflegeEintrag> tblPflegeEintrag_N = (from pe in repo.dbcontext.PflegeEintrag
                                                                                                  join sppe in tblSPPE_N on pe.Id equals sppe.IdpflegeEintrag
                                                                                                  select pe)
                                                                                      .Where(pe => pe.Id == IdPflegeeintrag)
                                                                                      .OrderBy(pe => pe.Zeitpunkt)
                                                                                      .ToList();
                                                        AddNodes(tblPflegeEintrag_N, nNotfallSP, "MaßnahmeMeldung", repo, false);
                                                    }
                                                }
                                            }
                                        }
                                        SaveXML();

                                    }
                                }

                                if (dOpt.Verordnungen)
                                {
                                    using (Chilkat.Xml nVerordnungen = nAufenthalt.NewChild("Verordnungen", ""))
                                    {
                                        List<Vo> tblVOs = repo.dbcontext.Vo.Where(vos => vos.Idaufenthalt == rAufenthalt.Id)
                                            .OrderBy(vos => vos.DatumVerordnetAb)
                                            .ToList();
                                        int mVOs = AddNodes(tblVOs, nVerordnungen, "Verordnung", repo, true);

                                        for (int iVO = 0; iVO < mVOs; iVO++)
                                        {
                                            Chilkat.Xml nVO = nVerordnungen.GetChild(iVO);
                                            Guid IDVerordnung = new Guid(nVO.GetAttrValue("Id"));

                                            List<VoBestelldaten> tblVOBestelldaten = repo.dbcontext.VoBestelldaten
                                                        .Where(vobest => vobest.Idverordnung == IDVerordnung)
                                                        .OrderBy(vobest => vobest.GueltigAb)
                                                        .ToList();
                                            int mBestelldaten = AddNodes(tblVOBestelldaten, nVO, "VO_Bestelldaten", repo, false);

                                            for (int iBestelldaten = 0; iBestelldaten < mBestelldaten; iBestelldaten++)
                                            {
                                                Chilkat.Xml nVOBestelldaten = nVO.GetNthChildWithTag("VO_Bestelldaten", iBestelldaten);
                                                Guid IDBestelldaten = new Guid(nVOBestelldaten.GetAttrValue("Id"));
                                                List<VoBestellpostitionen> tblVOBestellpositionen = repo.dbcontext.VoBestellpostitionen
                                                    .Where(vobestpos => vobestpos.IdbestelldatenVo == IDBestelldaten)
                                                    .OrderBy(vobestpos => vobestpos.DatumBestellung)
                                                    .ToList();

                                                AddNodes(tblVOBestellpositionen, nVOBestelldaten, "VO_Bestellposition", repo, false);
                                            }

                                            List<VoLager> tblVOLager = repo.dbcontext.VoLager
                                                        .Where(volag => volag.Idvo == IDVerordnung)
                                                        .OrderBy(volag => volag.Seriennummer)
                                                        .ToList();
                                            AddNodes(tblVOLager, nVO, "VO_Lager", repo, false);

                                            List<VoMedizinischeDaten> tblVoMedizinischeDaten = repo.dbcontext.VoMedizinischeDaten
                                                                            .Where(vomed => vomed.Idverordnung == IDVerordnung)
                                                                            .OrderBy(vomed => vomed.DatumErstellt)
                                                                            .ToList();
                                            AddNodes(tblVoMedizinischeDaten, nVO, "VO_MedizinischeDaten", repo, false);

                                            List<VoWunde> tblVoWunden = repo.dbcontext.VoWunde
                                                                            .Where(vomed => vomed.Idverordnung == IDVerordnung)
                                                                            .OrderBy(vomed => vomed.DatumErstellt)
                                                                            .ToList();
                                            AddNodes(tblVoWunden, nVO, "VO_Wunde", repo, false);

                                            List<VoPflegeplanPdx> tblVoPflegeplanPdx = repo.dbcontext.VoPflegeplanPdx
                                                                    .Where(vomed => vomed.Idverordnung == IDVerordnung)
                                                                    .ToList();
                                            AddNodes(tblVoPflegeplanPdx, nVO, "VO_PflegeplanPDX", repo, false);

                                        }
                                        SaveXML();

                                    }

                                }
                            }
                        }
                        nExportInfo.AddAttribute("EndeExport", DateTime.Now.ToString());

                        SaveXML();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.Export: " + ex.ToString());
            }
        }

        private bool SaveXML()
        {
            try
            {
                xml.SaveXml(FileNameXMLDocumentBackTmp);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.SaveXML: " + ex.ToString());
            }
        }


        private string StripSpecialCharacters(string s)
        {
            try
            {
                return Regex.Replace(s, @"[^0-9a-zA-Z.äöüÄÖÜß]\\", string.Empty);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.StripSpecialCharacters: " + ex.ToString());
            }
        }
        private bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.ByteArrayToFile: " + ex.ToString());
            }
        }

        private bool StringToFile(string fileName, string Content)
        {
            try
            {
                System.IO.File.WriteAllText(fileName, Content);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.StringToFile: " + ex.ToString());
            }
        }

        private void Init()
        {
            //ENV.initPDFIum();

            AdresseFieldnames.Add("IDADRESSE", "Adresse");
            AdresseFieldnames.Add("IDADRESSESUB", "AdresseSub");

            KontaktFieldnames.Add("IDKONTAKT", "Kontakt");
            KontaktFieldnames.Add("IDKONTAKTSUB", "KontaktSub");

            PflegegeldStufenFieldnames.Add("IDPFLEGEGELDSTUFE", "Pflegegeldstufe");
            PflegegeldStufenFieldnames.Add("IDPFLEGEGELDSTUFEANTRAG", "Pflegegeldstufe_Antrag");
        }

        private void ExportFDF(Guid id, string FormularName, DateTime Datumerstellt, Byte[] fdfBlop, string PathKlientenFormulare, string KlientNameGebDat, WCFServicePMDS.Repository.RepositoryWrapper repo)
        {
            try
            {
                string ExportName = Path.Combine(PathKlientenFormulare, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(FormularName) + "_" + Datumerstellt.ToString("yyyyMMddHHmmss") + ".pdf");
                Formular pdf = repo.dbcontext.Formular.Where(f => f.Name == FormularName).FirstOrDefault();
                if (pdf != null)
                {
                    using (PdfForms formFDF = new PdfForms())
                    {
                        FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(fdfBlop);
                        Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(pdf.PdfBlop, formFDF);
                        formFDF.InterForm.ResetForm();
                        formFDF.InterForm.ImportFromFdf(docFDF);

                        foreach (PdfPage p in docPDF.Pages)
                        {
                            p.FlattenPage(FlattenFlags.FlatPrint);
                        }
                        docPDF.Save(ExportName, SaveFlags.NoIncremental);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.ExportFDF: " + ex.ToString());
            }
        }


        private object GetData(eDataTable TableType, WCFServicePMDS.Repository.RepositoryWrapper repo)
        {
            try
            {
                if (TableType == eDataTable.Kliniken)
                    return repo.dbcontext.Klinik.ToList();

                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.GetData: " + ex.ToString());
            }
        }

        private void AddPflegeEintragTypNode(Chilkat.Xml nParent, string nName, int nValue)
        {
            try
            {
                Chilkat.Xml nPflegeEintragTypN = nParent.NewChild("PflegeEintragTyp", nName);
                nPflegeEintragTypN.AddAttribute("Id", nValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.AddPflegeEintragTypNode: " + ex.ToString());
            }
        }

        private int AddNodes<T>(List<T> tbl, Chilkat.Xml nParent, string ChildName, WCFServicePMDS.Repository.RepositoryWrapper repo, bool AutoAssignSubNodes)
        {
            try
            {
                int i = 0;
                foreach (var row in tbl)
                {
                    Chilkat.Xml nChild = nParent.NewChild(ChildName, "");
                    i++;

                    PropertyInfo[] properties = row.GetType().GetProperties();

                    foreach (PropertyInfo vprop in properties)
                    {
                        if (//vprop.CanWrite &&
                                (
                                    vprop.PropertyType == typeof(string) ||
                                    vprop.PropertyType == typeof(bool) ||
                                    vprop.PropertyType == typeof(Guid) ||
                                    vprop.PropertyType == typeof(short) ||
                                    vprop.PropertyType == typeof(int) ||
                                    vprop.PropertyType == typeof(long) ||
                                    vprop.PropertyType == typeof(DateTime) ||
                                    vprop.PropertyType == typeof(TimeSpan) ||
                                    vprop.PropertyType == typeof(decimal) ||
                                    vprop.PropertyType == typeof(double) ||
                                    vprop.PropertyType == typeof(float) ||
                                    vprop.PropertyType == typeof(char) ||
                                    vprop.PropertyType == typeof(byte) ||
                                    vprop.PropertyType == typeof(byte[]) ||
                                    vprop.PropertyType == typeof(sbyte) ||

                                    vprop.PropertyType == typeof(Nullable<bool>) ||
                                    vprop.PropertyType == typeof(Nullable<Guid>) ||
                                    vprop.PropertyType == typeof(Nullable<DateTime>) ||
                                    vprop.PropertyType == typeof(Nullable<TimeSpan>) ||
                                    vprop.PropertyType == typeof(Nullable<byte>) ||
                                    vprop.PropertyType == typeof(Nullable<sbyte>)
                                )
                                && !vprop.Name.ToUpper().Contains("RTF")
                                && !vprop.Name.ToUpper().Contains("BLOP")
                            )
                        {
                            try
                            {
                                nChild.AddAttribute(vprop.Name, row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                            }
                            catch
                            {
                                nChild.AddAttribute(vprop.Name, "");
                            }
                        }

                        if (AutoAssignSubNodes && row.GetType().GetProperty(vprop.Name).GetValue(row, null) != null)
                        {

                            string NodeText = "";

                            if (vprop.Name.ToUpper() == "IDKLINIK")
                            {
                                Guid IDKlinik = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Klinik> tblKlinik = tblKliniken.Where(a => a.Id == IDKlinik).ToList();
                                AddNodes(tblKlinik, nChild, "Klinik", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDABTEILUNG")
                            {
                                Guid IDAbteilung = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Abteilung> tblAbteilung = tblAbteilungen.Where(a => a.Id == IDAbteilung).ToList();
                                AddNodes(tblAbteilung, nChild, "Abteilung", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDBEREICH")
                            {
                                Guid IDBereich = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Bereich> tblBereich = tblBereiche.Where(a => a.Id == IDBereich).ToList();
                                AddNodes(tblBereich, nChild, "Bereich", repo, false);
                            }

                            //Adressen
                            if (AdresseFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDAdresse = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Adresse> tblAdressen = repo.dbcontext.Adresse.Where(a => a.Id == IDAdresse).ToList();
                                AddNodes(tblAdressen, nChild, NodeText, repo, false);
                            }
                            //Kontakte
                            if (KontaktFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDKontakt = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Kontakt> tblKontakte = repo.dbcontext.Kontakt.Where(a => a.Id == IDKontakt).ToList();
                                AddNodes(tblKontakte, nChild, NodeText, repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDBANK")
                            {
                                Guid IDBank = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Bank> tblBanken = repo.dbcontext.Bank.Where(a => a.Id == IDBank).ToList();
                                AddNodes(tblBanken, nChild, "Bank", repo, false);
                            }
                            //Benutzer
                            if (BenutzerFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDBenutzer = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Benutzer> tblUsers = tblBenutzer.Where(a => a.Id == IDBenutzer).ToList();
                                AddNodes(tblUsers, nChild, NodeText, repo, false);
                            }
                            //Pflegegeldstufen
                            if (PflegegeldStufenFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDPflegegeldStufe = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Pflegegeldstufe> tblPflegegeldStufen = repo.dbcontext.Pflegegeldstufe.Where(a => a.Id == IDPflegegeldStufe).ToList();
                                AddNodes(tblPflegegeldStufen, nChild, NodeText, repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDPLAN")
                            {
                                Guid IDPlan = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Plan> tblPlaene = repo.dbcontext.Plan.Where(a => a.Id == IDPlan).ToList();

                                //RTF in PlainText umsetzen
                                //System.Windows.Forms.RichTextBox rtBox = new RichTextBox();
                                //foreach (Plan pl in tblPlaene)
                                //{
                                //    rtBox.Rtf = pl.Text;
                                //    pl.Text = rtBox.Text;
                                //}
                                AddNodes(tblPlaene, nChild, "Plan", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDPDX")
                            {
                                Guid IDPDX = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Pdx> tblPDXs = repo.dbcontext.Pdx.Where(a => a.Id == IDPDX).ToList();
                                AddNodes(tblPDXs, nChild, "PDX", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDMEDIKAMENT")
                            {
                                Guid IDMedikament = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<Medikament> tblMedikamente = repo.dbcontext.Medikament.Where(med => med.Id == IDMedikament).ToList();
                                AddNodes(tblMedikamente, nChild, "Medikament_Heilbehelf", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDMEDIZINISCHEDATEN")
                            {
                                Guid IDMedDaten = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<MedizinischeDaten> tblMedDaten = repo.dbcontext.MedizinischeDaten.Where(med => med.Id == IDMedDaten).ToList();
                                AddNodes(tblMedDaten, nChild, "MedizinischeDaten", repo, false);
                            }

                            if (vprop.Name.ToUpper() == "IDWUNDEKOPF")
                            {
                                Guid IDWundeKopf = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<WundeKopf> tblWundeKopf = repo.dbcontext.WundeKopf.Where(med => med.Id == IDWundeKopf).ToList();
                                AddNodes(tblWundeKopf, nChild, "WundeKopf", repo, false);
                            }
                        }
                    }
                    if (i % iFlush == 0)
                    {
                        SaveXML();
                    }

                }
                return i;

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.AddNode: " + ex.ToString());
            }
            */
        }
    }

}

