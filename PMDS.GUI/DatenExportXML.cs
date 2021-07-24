using PMDS.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Patagames.Pdf.Net;        //https://www.youtube.com/watch?v=IF9cKSUFon8
using Patagames.Pdf.Enums;
using System.Text.RegularExpressions;

namespace PMDS.GUI
{
    class DatenExportXML
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

        //public class MedikamenteDTO
        //{
        //    public Guid ID { get; set; }
        //    public string Bezeichnung { get; set; }
        //}


        public class PatientenfotoDTO
        {
            public Guid ID { get; set; }
            public byte[] Foto { get; set; }
        }

        public class AufenthaltDTO
        {
            public Guid ID { get; set; }
            public Guid IDAufenthalt { get; set; }
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

        private List<PMDS.db.Entities.Benutzer> tblBenutzer = new List<db.Entities.Benutzer>();
        private List<PMDS.db.Entities.Klinik> tblKliniken = new List<db.Entities.Klinik>();
        private List<PMDS.db.Entities.Abteilung> tblAbteilungen = new List<db.Entities.Abteilung>();
        private List<PMDS.db.Entities.Bereich> tblBereiche = new List<db.Entities.Bereich>();

        private Chilkat.Xml xml = new Chilkat.Xml();
        private string FileNameXMLDocumentBackTmp = "";

        public bool Export(Guid IDClient, System.Guid IDPatient, ref string ArchivPath, out string FileNameXMLDocumentBack, bool IsTest)
        {
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

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    FileNameXMLDocumentBack = "";

                    PMDS.db.Entities.Patient patDto = db.Patient.Where(o => o.ID == IDPatient).First();
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
                        ENV.check_Path(ExportPath, true);

                        //öfters benötigte Tabellen einmal einlesen
                        tblBenutzer = db.Benutzer.ToList();
                        tblKliniken = db.Klinik.ToList();
                        tblAbteilungen = db.Abteilung.ToList();
                        tblBereiche = db.Bereich.ToList(); 

                        string PathWundeBilder = Path.Combine(ExportPath, "Wundbilder");
                        ENV.check_Path(PathWundeBilder, true);

                        string PathKlientenBild = Path.Combine(ExportPath, "Klientenbild");
                        ENV.check_Path(PathKlientenBild, true);

                        string PathKlientenArchiv = Path.Combine(ExportPath, "Klientenarchiv");
                        ENV.check_Path(PathKlientenArchiv, true);

                        string PathKlientenFormulare = Path.Combine(ExportPath, "Formulare");
                        ENV.check_Path(PathKlientenFormulare, true);

                        string PathKlientenBiografien = Path.Combine(ExportPath, "Biografien");
                        ENV.check_Path(PathKlientenBiografien, true);

                        FileNameXMLDocumentBack = System.IO.Path.Combine(ExportPath, KlientNameGebDat + ".XML");
                        FileNameXMLDocumentBackTmp = FileNameXMLDocumentBack;

                        Chilkat.Xml nExportInfo = xml.NewChild("ExportInfo", "");
                        nExportInfo.AddAttribute("BeginnExport", dNow.ToString());
                        nExportInfo.AddAttribute("DBVersion", db.DBVersion.First().ScriptVersion);

                        SaveXML();

                        if (dOpt.AllgemeineStammdaten)
                        {
                            //----------------- Allgemeine Stammdaten ---------------- 
                            using (Chilkat.Xml nAllgemeineStammdaten = xml.NewChild("Allgemeine_Stammdaten", ""))
                            {

                                //List<Klinik> tblKliniken = db.Klinik.ToList();
                                Chilkat.Xml nKliniken = nAllgemeineStammdaten.NewChild("Kliniken", "");
                                AddNodes(tblKliniken, nKliniken, "Klinik", db, true);

                                //List<Abteilung> tblAbteilungen = db.Abteilung.ToList();
                                Chilkat.Xml nAbteilungen = nAllgemeineStammdaten.NewChild("Abteilungen", "");
                                AddNodes(tblAbteilungen, nAbteilungen, "Abteilung", db, true);

                                //List<Bereich> tblBereiche = db.Bereich.ToList();
                                Chilkat.Xml nBereiche = nAllgemeineStammdaten.NewChild("Bereiche", "");
                                AddNodes(tblBereiche, nBereiche, "Bereich", db, true);

                                Chilkat.Xml nAuswahlListenGruppen = nAllgemeineStammdaten.NewChild("AuswahlListenGruppen", "");
                                List<PMDS.db.Entities.AuswahlListeGruppe> tblAuswahlListenGruppen = db.AuswahlListeGruppe.ToList();
                                AddNodes(tblAuswahlListenGruppen, nAuswahlListenGruppen, "AuswahlListenGruppe", db, true);

                                Chilkat.Xml nAuswahlListen = nAllgemeineStammdaten.NewChild("AuswahlListen", "");
                                List<PMDS.db.Entities.AuswahlListe> tblAuswahlListen = db.AuswahlListe.OrderBy(l => l.IDAuswahlListeGruppe).ToList();
                                AddNodes(tblAuswahlListen, nAuswahlListen, "AuswahlListe", db, true);

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

                                List<PMDS.db.Entities.Dienstzeiten> tblDienstzeiten = db.Dienstzeiten.ToList();
                                Chilkat.Xml nDienstzeiten = nAllgemeineStammdaten.NewChild("Dienstzeiten", "");
                                AddNodes(tblDienstzeiten, nDienstzeiten, "Dienstzeit", db, false);

                                List<PMDS.db.Entities.Einrichtung> tblEinrichtungen = db.Einrichtung.ToList();
                                Chilkat.Xml nEinrichtungen = nAllgemeineStammdaten.NewChild("Einrichtungen", "");
                                AddNodes(tblEinrichtungen, nEinrichtungen, "Einrichtung", db, true);

                                List<PMDS.db.Entities.Formular> tblFormulare = db.Formular.ToList();
                                Chilkat.Xml nFormulare = nAllgemeineStammdaten.NewChild("Formulare", "");
                                AddNodes(tblFormulare, nFormulare, "Formular", db, true);

                                List<PMDS.db.Entities.Massnahmenserien> tblMassnahmenserien = db.Massnahmenserien.ToList();
                                Chilkat.Xml nMassnahmenserien = nAllgemeineStammdaten.NewChild("Maßnahmenserien", "");
                                AddNodes(tblMassnahmenserien, nMassnahmenserien, "Maßnahmenserie", db, true);

                                List<PMDS.db.Entities.MedizinischeTypen> tblMedizinischeTypen = db.MedizinischeTypen.ToList();
                                Chilkat.Xml nMedizinischeTypen = nAllgemeineStammdaten.NewChild("MedizinischeTypen", "");
                                AddNodes(tblMedizinischeTypen, nMedizinischeTypen, "MedizinischerTyp", db, true);

                                List<PMDS.db.Entities.Standardzeiten> tblStandardzeiten = db.Standardzeiten.ToList();
                                Chilkat.Xml nStandardzeiten = nAllgemeineStammdaten.NewChild("Standardzeiten", "");
                                AddNodes(tblStandardzeiten, nStandardzeiten, "Standardzeit", db, true);

                                List<PMDS.db.Entities.Zeitbereich> tblZeitbereiche = db.Zeitbereich.ToList();
                                Chilkat.Xml nZeitbereiche = nAllgemeineStammdaten.NewChild("Zeitbereiche", "");
                                AddNodes(tblZeitbereiche, nZeitbereiche, "Zeitbereich", db, false);

                                Chilkat.Xml nBenutzer = nAllgemeineStammdaten.NewChild("BenutzerListe", "");
                                AddNodes(tblBenutzer, nBenutzer, "Benutzer", db, true);

                                List<PMDS.db.Entities.Aerzte> tblAerzte = (from ae in db.Aerzte
                                                          join pae in db.PatientAerzte on ae.ID equals pae.IDAerzte
                                                          where
                                                            pae.IDPatient == patDto.ID
                                                          select ae)
                                                              .OrderBy(ae => ae.Nachname)
                                                              .OrderBy(ae => ae.Vorname)
                                                              .ToList();
                                Chilkat.Xml nAerzte = nAllgemeineStammdaten.NewChild("Ärzte", "");
                                AddNodes(tblAerzte, nAerzte, "Arzt", db, true);

                                //Pflegemodelle = nicht erforderlich
                                //Chilkat.Xml nAbrechnungStammdaten = xml.NewChild("Abrechnungsbezogene_Stammdaten", "");
                                //var tblKostentraeger = db.Kostentraeger.ToList();
                                //Chilkat.Xml nKostentraegers = nAbrechnungStammdaten.NewChild("Kostentraeger", "");
                                //AddNodes(tblKostentraeger, nKostentraegers, "Kostentraeger", db, true);
                                //Leistungskatalog, LeistungskatalogGueltig, Pflegegeldstufe, PflegegeldstufeGueltig, Sonderleistungskatalog, Taschengeld
                                //Pflegegeldstufe, PflegegeldstufeGueltig
                            }
                            SaveXML();
                        }

                        // ----------------- Klient ----------------------------
                        List<PMDS.db.Entities.Patient> tblKlienten = db.Patient.Where(p => p.ID == patDto.ID).ToList();
                        AddNodes(tblKlienten, xml, "Klient", db, true);

                        using (Chilkat.Xml nKlient = xml.GetChildWithAttr("Klient", "ID", patDto.ID.ToString()))
                        {
                            if (dOpt.Klientendaten)
                            {
                                List<PatientenfotoDTO> PatientBild = (from p in db.Patient
                                                                      where p.ID == patDto.ID
                                                                      select new PatientenfotoDTO { ID = p.ID, Foto = p.Foto }).ToList();
                                if (PatientBild.FirstOrDefault().Foto != null)
                                    ByteArrayToFile(Path.Combine(PathKlientenBild, KlientNameGebDat + ".jpg"), (Byte[])PatientBild.FirstOrDefault().Foto);

                                List<PMDS.db.Entities.Kontaktperson> tblKontaktpersonen = db.Kontaktperson.Where(kp => kp.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nKontaktpersonen = nKlient.NewChild("Kontaktpersonen", "");
                                AddNodes(tblKontaktpersonen, nKontaktpersonen, "Kontaktperson", db, true);

                                List<PMDS.db.Entities.PatientAerzte> tblPatientAerzte = db.PatientAerzte.Where(a => a.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nPatientAerzte = nKlient.NewChild("Ärzte", "");
                                AddNodes(tblPatientAerzte, nPatientAerzte, "Arzt", db, true);

                                List<PMDS.db.Entities.Sachwalter> tblSachwalters = db.Sachwalter.Where(sw => sw.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nSachwalters = nKlient.NewChild("Erwachsenenvertreter_Vorsorgebevollmächtigte", "");
                                AddNodes(tblSachwalters, nSachwalters, "Erwachsenenvertreter_Vorsorgebevollmächtigter", db, true);

                                List<PMDS.db.Entities.Anamnese_Krohwinkel> tblAnamnesenKrohwinkel = db.Anamnese_Krohwinkel.Where(anak => anak.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nAnamnesenKrohwinkel = nKlient.NewChild("AnamnesenKrohwinkel", "");
                                AddNodes(tblAnamnesenKrohwinkel, nAnamnesenKrohwinkel, "AnamneseKrohwinkel", db, true);

                                List<PMDS.db.Entities.Anamnese_Orem> tblAnamnesenOrem = db.Anamnese_Orem.Where(anao => anao.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nAnamnesenOrem = nKlient.NewChild("AnamnesenOrem", "");
                                AddNodes(tblAnamnesenOrem, nAnamnesenOrem, "AnamneseOrem", db, true);

                                List<PMDS.db.Entities.Anamnese_POP> tblAnamnesenPOP = db.Anamnese_POP.Where(anap => anap.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nAnamnesenPOP = nKlient.NewChild("AnamnesenPOP", "");
                                AddNodes(tblAnamnesenPOP, nAnamnesenPOP, "AnamnesePOP", db, true);

                                List<PMDS.db.Entities.Rehabilitation> tblRehabilitationen = db.Rehabilitation.Where(reha => reha.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nRehabilitationen = nKlient.NewChild("Rehabilitationen", "");
                                AddNodes(tblRehabilitationen, nRehabilitationen, "Rehabilitation", db, true);

                                List<PMDS.db.Entities.Arztabrechnung> tblArztabrechnungen = db.Arztabrechnung.Where(aa => aa.IDPatient == patDto.ID).OrderBy(aa => aa.Datum).ToList();
                                Chilkat.Xml nArztabrechnungen = nKlient.NewChild("Arztabrechnungen", "");
                                AddNodes(tblArztabrechnungen, nArztabrechnungen, "Arztabrechnung", db, true);

                                List<PMDS.db.Entities.PatientPflegestufe> tblPflegeStufen = db.PatientPflegestufe.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.GueltigAb).ToList();
                                Chilkat.Xml nPflegeStufen = nKlient.NewChild("PflegeStufen", "");
                                AddNodes(tblPflegeStufen, nPflegeStufen, "PflegeStufe", db, true);

                                List<PMDS.db.Entities.PatientenBemerkung> tblPatientBemerkungen = db.PatientenBemerkung.Where(pbem => pbem.IDPatient == patDto.ID).ToList();
                                Chilkat.Xml nPatientBemerkungen = nKlient.NewChild("PatientBemerkungen", "");
                                AddNodes(tblPatientBemerkungen, nPatientBemerkungen, "PatientBemerkung", db, true);

                                List<PMDS.db.Entities.MedizinischeDaten> tblMedizinischeDaten = db.MedizinischeDaten.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.Typ).OrderBy(ps => ps.Von).ToList();
                                Chilkat.Xml nMedizinischeDaten = nKlient.NewChild("MedizinischeDaten", "");
                                AddNodes(tblMedizinischeDaten, nMedizinischeDaten, "MedizinischesDatum", db, true);

                                List<PMDS.db.Entities.FormularDaten> tblFormularDaten = db.FormularDaten.Where(fd => fd.IDREF == patDto.ID && fd.PDF_BLOP != null).OrderBy(fd => fd.FormularName).OrderBy(fd => fd.Datumerstellt).ToList();
                                Chilkat.Xml nFormulardaten = nKlient.NewChild("Formulardaten", "");
                                AddNodes(tblFormularDaten, nFormulardaten, "Formular", db, true);
                                foreach (var fd in tblFormularDaten)
                                {
                                    ExportFDF(fd.ID, StripSpecialCharacters(fd.FormularName), fd.Datumerstellt, fd.PDF_BLOP, PathKlientenFormulare, KlientNameGebDat, db);
                                }

                                List<PMDS.db.Entities.FormularDaten> tblBiografien = db.FormularDaten.Where(bio => bio.IDREF == patDto.ID && bio.PDF_BLOP == null && (bio.BLOP.ToString().StartsWith(@"{\rtf1"))).OrderBy(az => az.FormularName).OrderBy(az => az.Datumerstellt).ToList();
                                Chilkat.Xml nBiografien = nKlient.NewChild("Biografien", "");
                                AddNodes(tblBiografien, nBiografien, "Biografie", db, true);
                                foreach (var fd in tblBiografien)
                                {
                                    string FileNameWundeBild = System.IO.Path.Combine(PathKlientenBiografien, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(StripSpecialCharacters(fd.FormularName)) + "_" + fd.Datumerstellt.ToString("yyyyMMddHHmmss") + "_" + fd.ID.ToString() + ".rtf");
                                    StringToFile(FileNameWundeBild, fd.BLOP);
                                }

                                if (dOpt.KlientenTermineArchiv)
                                {
                                    //Kliententermine
                                    List<PMDS.db.Entities.planObject> tblPlaene = db.planObject.Where(plan => plan.IDObject == patDto.ID).OrderBy(plan => plan.Status).ToList();
                                    Chilkat.Xml nPlaene = nKlient.NewChild("Kliententermine_Pläne", "");
                                    AddNodes(tblPlaene, nPlaene, "Kliententermin_Plan", db, true);

                                    //Archiv
                                    List<PMDS.db.Entities.tblDokumente> tblArchiv = (from dok in db.tblDokumente
                                                                    join dokein in db.tblDokumenteintrag on dok.IDDokumenteintrag equals dokein.ID
                                                                    join obj in db.tblObjekt on dokein.ID equals obj.IDDokumenteintrag
                                                                    where obj.ID_guid == patDto.ID
                                                                    select dok)
                                                        .OrderBy(dok => dok.ErstelltAm)
                                                        .ToList();
                                    Chilkat.Xml nArchiv = nKlient.NewChild("Archiveinträge", "");
                                    AddNodes(tblArchiv, nArchiv, "Archiveintrag", db, true);

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

                            List<AufenthaltDTO> tAufenthalte = (from Aufenthalte in db.Aufenthalt
                                                                  where Aufenthalte.IDPatient == patDto.ID
                                                                  select new AufenthaltDTO { ID = Aufenthalte.ID, Aufnahmezeitpunkt = (DateTime)Aufenthalte.Aufnahmezeitpunkt })
                                                    .OrderBy(o => o.Aufnahmezeitpunkt).ToList();

                            foreach (var rAufenthalt in tAufenthalte)
                            {
                                List<PMDS.db.Entities.Aufenthalt> tblAufenthalte = db.Aufenthalt.Where(a => a.ID == rAufenthalt.ID).OrderBy(a => a.Aufnahmezeitpunkt).ToList();
                                AddNodes(tblAufenthalte, nAufenthalte, "Aufenthalt", db, true);

                                Chilkat.Xml nAufenthalt = nAufenthalte.GetChildWithAttr("Aufenthalt", "ID", rAufenthalt.ID.ToString());

                                if (dOpt.Aufenthaltsdaten)
                                {
                                    List<PMDS.db.Entities.AufenthaltZusatz> tblAufenthaltzusatz = db.AufenthaltZusatz.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                                    AddNodes(tblAufenthaltzusatz, nAufenthalt, "Aufenthaltzusatz", db, true);

                                    List<PMDS.db.Entities.Gegenstaende> tblGegestaende = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == false).ToList();
                                    Chilkat.Xml nGegenstaende = nAufenthalt.NewChild("Gegenstände", "");
                                    AddNodes(tblGegestaende, nGegenstaende, "Gegenstand", db, true);

                                    List<PMDS.db.Entities.Gegenstaende> tblHilfsmittel = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == true).ToList();
                                    Chilkat.Xml nHilfsmitteln = nAufenthalt.NewChild("HilfsmittelListe", "");
                                    AddNodes(tblHilfsmittel, nHilfsmitteln, "Hilfsmittel", db, true);

                                    List<PMDS.db.Entities.Unterbringung> tblUnterbringungen = db.Unterbringung.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                                    Chilkat.Xml nUnterbringungen = nAufenthalt.NewChild("HAG_Meldungen", "");
                                    AddNodes(tblUnterbringungen, nUnterbringungen, "HAG_Meldung", db, true);

                                    List<PMDS.db.Entities.UrlaubVerlauf> tblUrlaubVerlauf = db.UrlaubVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.StartDatum).ToList();
                                    Chilkat.Xml nAbwesenheiten = nAufenthalt.NewChild("Abwesenheiten", "");
                                    AddNodes(tblUrlaubVerlauf, nAbwesenheiten, "Abwesenheit", db, true);

                                    List<PMDS.db.Entities.AufenthaltVerlauf> tblAufenthaltVerlauf = db.AufenthaltVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.Datum).ToList();
                                    Chilkat.Xml nVersetzungen = nAufenthalt.NewChild("AufenthaltsverlaufListe", "");
                                    AddNodes(tblAufenthaltVerlauf, nVersetzungen, "Aufenthaltsverlauf", db, true);
                                    SaveXML();

                                }

                                using (Chilkat.Xml nPflegeplan = nAufenthalt.NewChild("Pflegeplan", ""))
                                {
                                    if (dOpt.Pflegeplan)
                                    {
                                        List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsPP = db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == false).ToList();
                                        int iAufenthaltPDxPP = AddNodes(tblAufenthaltPDXsPP, nPflegeplan, "Aufenthalt_PDX", db, true);

                                        for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsPP.Count; iAPDX++)
                                        {
                                            Guid IDAufenthaltPDX = tblAufenthaltPDXsPP[iAPDX].ID;
                                            Guid IDPDX = (Guid)tblAufenthaltPDXsPP[iAPDX].IDPDX;

                                            List<PMDS.db.Entities.PflegePlanPDx> tblPflegeplanPDX = db.PflegePlanPDx.Where(az => az.IDAufenthaltPDx == IDAufenthaltPDX && az.IDPDX == IDPDX).ToList();

                                            Chilkat.Xml nPDX = nPflegeplan.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

                                            List<PMDS.db.Entities.PflegePlan> tblPflegeplaene = (from pp in db.PflegePlan
                                                                                join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                where
                                                                                    pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                    (pp.EintragGruppe == "A" || pp.EintragGruppe == "S" || pp.EintragGruppe == "R" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                                                    pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                    apdx.ID == IDAufenthaltPDX &&
                                                                                    pdx.ID == IDPDX
                                                                                select pp)
                                                                    .OrderBy(apdx => apdx.ErledigtJN)
                                                                    .OrderBy(ppdx => ppdx.ErledigtJN)
                                                                    .OrderBy(pp => pp.StartDatum)
                                                                    .ToList();

                                            if (tblPflegeplaene.Count() > 0)
                                            {
                                                Chilkat.Xml nAetiologien = nPDX.NewChild("Ätiologien_Risikofaktoren", "");
                                                List<PMDS.db.Entities.PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                                AddNodes(tblAetiologien, nAetiologien, "Ätiologie_Risikofaktor", db, true);

                                                Chilkat.Xml nSymptome = nPDX.NewChild("Symptome", "");
                                                List<PMDS.db.Entities.PflegePlan> tblSymptome = tblPflegeplaene.Where(pp => pp.EintragGruppe == "S").ToList();
                                                AddNodes(tblSymptome, nSymptome, "Symptom", db, true);

                                                Chilkat.Xml nRessourcen = nPDX.NewChild("Ressourcen", "");
                                                List<PMDS.db.Entities.PflegePlan> tblRessourcen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "R").ToList();
                                                AddNodes(tblRessourcen, nRessourcen, "Ressource", db, true);

                                                Chilkat.Xml nZiele = nPDX.NewChild("Ziele", "");
                                                List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                                AddNodes(tblZiele, nZiele, "Ziel", db, true);

                                                //Evaluierung zu Pflegeplan (Ziele)
                                                if (tblZiele.Count() > 0)
                                                {
                                                    foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                                    {
                                                        List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                                        if (tblEvaluierungen.Count > 0)
                                                        {
                                                            Chilkat.Xml nZiel = nZiele.GetChildWithAttr("Ziel", "ID", rZiel.ID.ToString());
                                                            if (nZiel != null)
                                                            {
                                                                Chilkat.Xml nPPZielEvaluierungen = nZiel.NewChild("Evaluierungen-Pflegeplan", "");
                                                                AddNodes(tblEvaluierungen, nPPZielEvaluierungen, "EvaluierungPflegeplan", db, false);
                                                            }
                                                        }
                                                    }
                                                }

                                                Chilkat.Xml nMassnahmen = nPDX.NewChild("Maßnahmen", "");
                                                List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                                AddNodes(tblMassnahmen, nMassnahmen, "Maßnahme", db, true);
                                            }
                                        }
                                        SaveXML();

                                    }

                                    if (dOpt.PflegeplanTermine)
                                    {
                                        using (Chilkat.Xml nTermine = nPflegeplan.NewChild("Termine", ""))
                                        {
                                            List<PMDS.db.Entities.PflegePlan> tblTermine = db.PflegePlan.Where(pp => pp.IDAufenthalt == rAufenthalt.ID && pp.EintragGruppe == "T").OrderBy(pp => pp.StartDatum).ToList();
                                            AddNodes(tblTermine, nTermine, "Termin", db, true);
                                        }
                                        SaveXML();

                                    }

                                    if (dOpt.PflegeplanHistorie)
                                    {
                                        using (Chilkat.Xml nPflegeplaeneH = nPflegeplan.NewChild("PflegepläneHistorie", ""))
                                        {
                                            List<PMDS.db.Entities.PflegePlanH> tblPflegeplanH = (from pph in db.PflegePlanH
                                                                                join e in db.Eintrag on pph.IDEintrag equals e.ID
                                                                                select pph)
                                                                                .Where(pp => pp.IDAufenthalt == rAufenthalt.ID)
                                                                                .OrderBy(e => e.Text)
                                                                                .OrderBy(pp => pp.DatumErstellt)
                                                                                .ToList();
                                            AddNodes(tblPflegeplanH, nPflegeplaeneH, "PflegeplanHistorie", db, true);
                                        }
                                        SaveXML();

                                    }
                                }

                                if (dOpt.PflegeDokumentation)
                                {
                                    using (Chilkat.Xml nPflegedokumentation = nAufenthalt.NewChild("Pflegedokumentation", ""))
                                    {
                                        List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp != 2).ToList();

                                        Chilkat.Xml nPE_NONE = nPflegedokumentation.NewChild("Ohne_Klassifizierungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == -1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NONE, "Doku_Ohne_Klassifizierung", db, false);
                                        Chilkat.Xml nPE_DEKURS = nPflegedokumentation.NewChild("Dekurse", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 0).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Dekurs", db, false);
                                        Chilkat.Xml nPE_MASSNAHME = nPflegedokumentation.NewChild("Maßnahmen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Maßnahme", db, false);
                                        Chilkat.Xml nPE_UNEXP_MASSNAHME = nPflegedokumentation.NewChild("Ungeplante_Maßnahmen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 3).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_UNEXP_MASSNAHME, "Doku_Ungeplante_Maßnahme", db, false);
                                        Chilkat.Xml nPE_TERMIN = nPflegedokumentation.NewChild("Termine", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 4).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_TERMIN, "Doku_Termin", db, false);
                                        Chilkat.Xml nPE_MEDIKAMENT = nPflegedokumentation.NewChild("Medikamente", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 5).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_MEDIKAMENT, "Doku_Medikament", db, false);
                                        Chilkat.Xml nPE_NOTFALL = nPflegedokumentation.NewChild("Notfälle", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 6).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NOTFALL, "Doku_Notfall", db, false);
                                        Chilkat.Xml nPE_PLANUNG = nPflegedokumentation.NewChild("Planungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 7).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_PLANUNG, "Doku_Planung", db, false);
                                        Chilkat.Xml nPE_WUNDE = nPflegedokumentation.NewChild("Wunden", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 8).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDE, "Doku_Wunde", db, false);
                                        Chilkat.Xml nPE_KLIENT = nPflegedokumentation.NewChild("Klienten", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 9).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_KLIENT, "Doku_Klient", db, false);
                                        Chilkat.Xml nPE_ASSESSMENT = nPflegedokumentation.NewChild("Assessments", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 10).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_ASSESSMENT, "Doku_Assessment", db, false);
                                        Chilkat.Xml nPE_VERORDNUNGEN = nPflegedokumentation.NewChild("Verordnungen", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 11).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_VERORDNUNGEN, "Doku_Verordnung", db, false);
                                        Chilkat.Xml nPE_WUNDVERLAUF = nPflegedokumentation.NewChild("Wundverläufe", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 12).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDVERLAUF, "Doku_Wundverlauf", db, false);
                                        Chilkat.Xml nPE_WUNDTHERAPIE = nPflegedokumentation.NewChild("Wundtherapien", "");
                                        AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 13).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDTHERAPIE, "Doku_Wundtherapie", db, false);
                                        SaveXML();

                                    }
                                }

                                if (dOpt.WundDokumentation)
                                {
                                    using (Chilkat.Xml nWunden = nAufenthalt.NewChild("Wunddokumentation", ""))
                                    {
                                        List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsW = db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == true).ToList();
                                        int iAufenthaltPDxW = AddNodes(tblAufenthaltPDXsW, nWunden, "Aufenthalt_PDX_Wunde", db, true);

                                        for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsW.Count; iAPDX++)
                                        {
                                            Guid IDAufenthaltPDX = tblAufenthaltPDXsW[iAPDX].ID;
                                            Guid IDPDX = (Guid)tblAufenthaltPDXsW[iAPDX].IDPDX;

                                            List<PMDS.db.Entities.PflegePlanPDx> tblPflegeplanPDX = db.PflegePlanPDx.Where(az => az.IDAufenthaltPDx == IDAufenthaltPDX && az.IDPDX == IDPDX).ToList();

                                            Chilkat.Xml nPDX_Wunde = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

                                            List<PMDS.db.Entities.PflegePlan> tblPflegeplaene = (from pp in db.PflegePlan
                                                                                join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                where
                                                                                    pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                    (pp.EintragGruppe == "A" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                                                    pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                    apdx.ID == IDAufenthaltPDX &&
                                                                                    pdx.ID == IDPDX
                                                                                select pp)
                                                                    .OrderBy(apdx => apdx.ErledigtJN)
                                                                    .OrderBy(ppdx => ppdx.ErledigtJN)
                                                                    .OrderBy(pp => pp.StartDatum)
                                                                    .ToList();

                                            if (tblPflegeplaene.Count > 0)
                                            {
                                                Chilkat.Xml nAetiologien = nPDX_Wunde.NewChild("BeeinflussendeFaktoren", "");
                                                List<PMDS.db.Entities.PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                                AddNodes(tblAetiologien, nAetiologien, "BeeinflussenderFaktor", db, true);

                                                Chilkat.Xml nZiele = nPDX_Wunde.NewChild("Ziele", "");
                                                List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                                AddNodes(tblZiele, nZiele, "Ziel", db, true);

                                                //Evaluierung zu Pflegeplan (Ziele)
                                                if (tblZiele.Count > 0)
                                                {
                                                    foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                                    {
                                                        List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                                        if (tblEvaluierungen.Count() > 0)
                                                        {
                                                            Chilkat.Xml nZiel = nZiele.GetChildWithAttr("Ziel", "ID", rZiel.ID.ToString());
                                                            if (nZiel != null)
                                                            {
                                                                Chilkat.Xml nWundeZielEvaluierungen = nZiel.NewChild("Evaluierungen-Wunde", "");
                                                                AddNodes(tblEvaluierungen, nWundeZielEvaluierungen, "EvaluierungWunde", db, true);
                                                            }
                                                        }
                                                    }
                                                }

                                                Chilkat.Xml nMassnahmen = nPDX_Wunde.NewChild("Maßnahmen", "");
                                                List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                                AddNodes(tblMassnahmen, nMassnahmen, "Maßnahme", db, true);

                                                Chilkat.Xml nPDX = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);
                                                List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(wk => wk.IDAufenthaltPDx == IDAufenthaltPDX).ToList();
                                                if (tblWundeKopf.Count > 0)
                                                {
                                                    AddNodes(tblWundeKopf, nPDX, "Wunde", db, true);
                                                    Chilkat.Xml nWunde = nPDX.GetChildWithTag("Wunde");

                                                    Guid IDWundeKopf = new Guid(nWunde.GetAttrValue("ID"));

                                                    Chilkat.Xml nWundeTherapien = nWunde.NewChild("Wundetherapien", "");
                                                    List<PMDS.db.Entities.WundeTherapie> tblWundeTherapie = db.WundeTherapie.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wt => wt.DatumErstellt).ToList();
                                                    AddNodes(tblWundeTherapie, nWundeTherapien, "Wundtherapie", db, true);

                                                    Chilkat.Xml nWundeVerlauefe = nWunde.NewChild("Wundeverläufe", "");
                                                    List<PMDS.db.Entities.WundePos> tblWundeVerlaufe = db.WundePos.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wv => wv.DatumErstellt).ToList();
                                                    AddNodes(tblWundeVerlaufe, nWundeVerlauefe, "Wundverlauf", db, true);

                                                    Chilkat.Xml nWundeBilder = nWunde.NewChild("Wundbilder", "");
                                                    List<PMDS.db.Entities.WundePosBilder> tblWundePosBilder = (from wb in db.WundePosBilder
                                                                                              join wp in db.WundePos on wb.IDWundePos equals wp.ID
                                                                                              where wp.IDWundeKopf == IDWundeKopf
                                                                                              select wb)
                                                                            .OrderBy(wb => wb.DatumErstellt)
                                                                            .ToList();
                                                    AddNodes(tblWundePosBilder, nWundeBilder, "Wundbild", db, true);

                                                    //Bilder auf Platte speichern
                                                    foreach (PMDS.db.Entities.WundePosBilder wb in tblWundePosBilder)
                                                    {
                                                        string FileNameWundeBild = System.IO.Path.Combine(PathWundeBilder, KlientNameGebDat + "_Wundbild_" + wb.ZeitpunktBild.ToString("yyyyMMddHHmmss") + "_" + wb.ID.ToString() + ".jpg");
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
                                        List<PMDS.db.Entities.Medikament> tblMedikamente = (from medikamente in db.Medikament
                                                                                 join re in db.RezeptEintrag on medikamente.ID equals re.IDMedikament
                                                                                 where re.IDAufenthalt == rAufenthalt.ID
                                                                                 select medikamente)
                                                                    //.Distinct()
                                                                    .ToList();

                                        List<PMDS.db.Entities.RezeptEintrag> tblRezepteintraege = (from re in db.RezeptEintrag 
                                                                                  where re.IDAufenthalt == rAufenthalt.ID
                                                                                  select re)
                                                                    .OrderBy(re => re.AbzugebenVon)
                                                                    .ToList();

                                        List<PMDS.db.Entities.MedikationAbgabe> tblMedikationAbgaben = (from re in db.RezeptEintrag
                                                                                       join medab in db.MedikationAbgabe on re.ID equals medab.IDRezeptEintrag
                                                                                       where re.IDAufenthalt == rAufenthalt.ID
                                                                                       select medab)
                                                                    .OrderBy(medab => medab.Zeitpunkt)
                                                                    .ToList();

                                        List<PMDS.db.Entities.RezeptBestellungPos> tblRezeptBestellungen = (from re in db.RezeptEintrag
                                                                                           join rebest in db.RezeptBestellungPos on re.ID equals rebest.IDRezeptEintrag
                                                                                           where re.IDAufenthalt == rAufenthalt.ID
                                                                                           select rebest)
                                                                    .OrderBy(rebest => rebest.RezeptAnforderungDatum)
                                                                    .ToList();

                                        AddNodes(tblMedikamente, nMedikamente, "Medikament", db, true);
                                        foreach (PMDS.db.Entities.Medikament Medikament in tblMedikamente)
                                        {
                                            Chilkat.Xml nRezepteintraege = nMedikamente.GetChildWithAttr("Medikament", "ID", Medikament.ID.ToString());
                                            if (nRezepteintraege != null)
                                            {
                                                List<PMDS.db.Entities.RezeptEintrag> tblre = (from re in tblRezepteintraege
                                                                             where re.IDMedikament == Medikament.ID
                                                                             select re).ToList();
                                                if (tblre.Count > 0)
                                                {
                                                    AddNodes(tblre, nRezepteintraege, "Rezepteintrag", db, true);

                                                    foreach (PMDS.db.Entities.RezeptEintrag re in tblre)
                                                    {
                                                        Chilkat.Xml nRezepteintrag = nRezepteintraege.GetChildWithAttr("Rezepteintrag", "ID", re.ID.ToString());
                                                        if (nRezepteintrag != null)
                                                        {
                                                            List<PMDS.db.Entities.MedikationAbgabe> tblMedAbg = (from medab in tblMedikationAbgaben
                                                                                                where medab.IDRezeptEintrag == re.ID
                                                                                                select medab).ToList();

                                                            if (tblMedAbg.Count > 0)
                                                            {
                                                                Chilkat.Xml nMedikamentenAbgaben = nRezepteintrag.NewChild("Medikamenentabgaben", "");
                                                                AddNodes(tblMedAbg, nMedikamentenAbgaben, "Medikamentenabgabe", db, false);
                                                            }

                                                            List<PMDS.db.Entities.RezeptBestellungPos> tblRezBest = (from rezbest in tblRezeptBestellungen
                                                                                                    where rezbest.IDRezeptEintrag == re.ID
                                                                                                    select rezbest).ToList();

                                                            if (tblRezBest.Count > 0)
                                                            {
                                                                Chilkat.Xml nRezeptbestellungen = nRezepteintrag.NewChild("Rezeptbestellungen", "");
                                                                AddNodes(tblRezBest, nRezeptbestellungen, "Rezeptbestellung", db, false);
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

                                        List<PMDS.db.Entities.StandardProzeduren> tblStandardProzeduren = (from sproz in db.StandardProzeduren
                                                                                          join sp in db.SP on sproz.ID equals sp.IDStandardProzeduren
                                                                                          where sp.IDAufenthalt == rAufenthalt.ID
                                                                                          select sproz)
                                                                                        .Distinct()
                                                                                        .OrderBy(sproz => sproz.Name)
                                                                                        .ToList();

                                        List<PMDS.db.Entities.SP> tblSp = (from sp in db.SP
                                                          where sp.IDAufenthalt == rAufenthalt.ID
                                                          select sp)
                                                        .OrderBy(sp => sp.Zeitpunkt)
                                                        .ToList();

                                        List<PMDS.db.Entities.SPPOS> tblSppos = (from sppos in db.SPPOS
                                                                join sp in db.SP on sppos.IDSP equals sp.ID
                                                                where sp.IDAufenthalt == rAufenthalt.ID
                                                                select sppos)
                                                        .OrderBy(sppos => sppos.DatumErstellt)
                                                        .ToList();

                                        List<PMDS.db.Entities.SPPE> tblSppe = (from sppe in db.SPPE
                                                              join sp in db.SP on sppe.IDSP equals sp.ID
                                                              where sp.IDAufenthalt == rAufenthalt.ID
                                                              select sppe)
                                                                .ToList();

                                        List<PMDS.db.Entities.StandardProzeduren> tblStandardprozeduren_SP = (from sproz in tblStandardProzeduren
                                                                                             select sproz)
                                                                                        .Where(sp => sp.NotfallJN == false)
                                                                                        .ToList();

                                        List<PMDS.db.Entities.StandardProzeduren> tblStandardprozeduren_N = (from sproz in tblStandardProzeduren
                                                                                            select sproz)
                                                                                        .Where(sp => sp.NotfallJN == true)
                                                                                        .ToList();

                                        //Standardprozeduren
                                        int nSProz_SP = AddNodes(tblStandardprozeduren_SP, nStandardprozeduren, "Standardprozedur", db, true);
                                        for (int iSProz_SP = 0; iSProz_SP < nSProz_SP; iSProz_SP++)
                                        {
                                            Chilkat.Xml nStandardProzedur = nStandardprozeduren.GetChild(iSProz_SP);
                                            Guid IDSProz_SP = new Guid(nStandardProzedur.GetAttrValue("ID"));
                                            List<PMDS.db.Entities.SP> tblSP_SP = (from sp in tblSp
                                                                 select sp)
                                                                  .Where(sp => sp.IDStandardProzeduren == IDSProz_SP)
                                                                  .OrderBy(sp => sp.Zeitpunkt)
                                                                  .ToList();
                                            int nSP_SP = AddNodes(tblSP_SP, nStandardProzedur, "Standardprozedur", db, true);

                                            for (int iSP_SP = 0; iSP_SP < nSP_SP; iSP_SP++)
                                            {
                                                Chilkat.Xml nStandardprozedurSP = nStandardProzedur.GetChild(iSP_SP);
                                                Guid IDSP_SP = new Guid(nStandardprozedurSP.GetAttrValue("ID"));
                                                List<PMDS.db.Entities.SPPOS> tblSPPOS_SP = (from sppos in tblSppos
                                                                           select sppos)
                                                                  .Where(sppos => sppos.IDSP == IDSP_SP)
                                                                  .OrderBy(sppos => sppos.DatumErstellt)
                                                                  .ToList();

                                                int nSPPos_SP = AddNodes(tblSPPOS_SP, nStandardprozedurSP, "Standardprozedur_Eintrag", db, true);
                                                for (int iSPPos_SP = 0; iSPPos_SP < nSPPos_SP; iSPPos_SP++)
                                                {
                                                    Chilkat.Xml nStandardprozedurSPPos = nStandardprozedurSP.GetChild(iSPPos_SP);
                                                    Guid IDEintrag_SP = new Guid(nStandardprozedurSPPos.GetAttrValue("IDEintrag"));
                                                    List<PMDS.db.Entities.Eintrag> tblEintrag_SP = (from e in db.Eintrag
                                                                                   select e)
                                                                                  .Where(e => e.ID == IDEintrag_SP)
                                                                                  .ToList();
                                                    AddNodes(tblEintrag_SP, nStandardprozedurSPPos, "Eintrag", db, true);
                                                }

                                                List<PMDS.db.Entities.SPPE> tblSPPE_SP = (from sppe in tblSppe
                                                                         select sppe)
                                                                      .Where(sppe => sppe.IDSP == IDSP_SP)
                                                                      .ToList();

                                                //int nSPPE_SP = tblSPPE_SP.Count;
                                                //for (int iSPPE_SP = 0; iSPPE_SP < nSPPE_SP; iSPPE_SP++)
                                                //{
                                                //    Guid IDPflegeeintrag = tblSPPE_SP[iSPPE_SP].IDPflegeEintrag;
                                                //    List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_SP = (from pe in db.PflegeEintrag
                                                //                                               join sppe in tblSPPE_SP on pe.ID equals sppe.IDPflegeEintrag
                                                //                                               select pe)
                                                //                                  .Where(pe => pe.ID == IDPflegeeintrag)
                                                //                                  .OrderBy(pe => pe.Zeitpunkt)
                                                //                                  .ToList();
                                                //    AddNodes(tblPflegeEintrag_SP, nStandardprozedurSP, "MaßnahmeMeldung", db, false);
                                                //}

                                                foreach (PMDS.db.Entities.SPPE sppe_sp in tblSPPE_SP)
                                                {
                                                    List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_SP = (from pe in db.PflegeEintrag
                                                                                                                select pe)
                                                                                  .Where(pe => pe.ID == sppe_sp.IDPflegeEintrag)
                                                                                  .OrderBy(pe => pe.Zeitpunkt)
                                                                                  .ToList();
                                                    AddNodes(tblPflegeEintrag_SP, nStandardprozedurSP, "MaßnahmeMeldung", db, false);
                                                }
                                            }

                                            //Notfälle
                                            Chilkat.Xml nNotfallprozeduren = nAufenthalt.NewChild("Notfallprozeduren", "");
                                            int nSProz_N = AddNodes(tblStandardprozeduren_N, nNotfallprozeduren, "Notfallprozedur", db, true);
                                            for (int iSProz_N = 0; iSProz_N < nSProz_N; iSProz_N++)
                                            {
                                                Chilkat.Xml nNotfallProzedur = nNotfallprozeduren.GetChild(iSProz_N);
                                                Guid IDSProz_N = new Guid(nNotfallProzedur.GetAttrValue("ID"));
                                                List<PMDS.db.Entities.SP> tblSP_N = (from sp in tblSp
                                                                    select sp)
                                                                      .Where(sp => sp.IDStandardProzeduren == IDSProz_N)
                                                                      .OrderBy(sp => sp.Zeitpunkt)
                                                                      .ToList();
                                                int nSP_N = AddNodes(tblSP_N, nNotfallProzedur, "Notfall", db, true);

                                                for (int iSP_N = 0; iSP_N < nSP_N; iSP_N++)
                                                {
                                                    Chilkat.Xml nNotfallSP = nNotfallProzedur.GetChild(iSP_N);
                                                    Guid IDSP_N = new Guid(nNotfallSP.GetAttrValue("ID"));
                                                    List<PMDS.db.Entities.SPPOS> tblSPPOS_N = (from sppos in tblSppos
                                                                              select sppos)
                                                                      .Where(sppos => sppos.IDSP == IDSP_N)
                                                                      .OrderBy(sppos => sppos.DatumErstellt)
                                                                      .ToList();

                                                    int nSPPos_N = AddNodes(tblSPPOS_N, nNotfallSP, "Notfall_Eintrag", db, true);
                                                    for (int iSPPos_N = 0; iSPPos_N < nSPPos_N; iSPPos_N++)
                                                    {
                                                        Chilkat.Xml nNotfallSPPos = nNotfallSP.GetChild(iSPPos_N);
                                                        Guid IDEintrag_N = new Guid(nNotfallSPPos.GetAttrValue("IDEintrag"));
                                                        List<PMDS.db.Entities.Eintrag> tblEintrag_N = (from e in db.Eintrag
                                                                                      select e)
                                                                                      .Where(e => e.ID == IDEintrag_N)
                                                                                      .ToList();
                                                        AddNodes(tblEintrag_N, nNotfallSPPos, "Eintrag", db, true);
                                                    }

                                                    List<PMDS.db.Entities.SPPE> tblSPPE_N = (from sppe in tblSppe
                                                                            select sppe)
                                                                          .Where(sppe => sppe.IDSP == IDSP_N)
                                                                          .ToList();

                                                    //int nSPPE_N = tblSPPE_N.Count;
                                                    //for (int iSPPE_N = 0; iSPPE_N < nSPPE_N; iSPPE_N++)
                                                    //{
                                                    //    Guid IDPflegeeintrag = tblSPPE_N[iSPPE_N].IDPflegeEintrag;
                                                    //    List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_N = (from pe in db.PflegeEintrag
                                                    //                                              join sppe in tblSPPE_N on pe.ID equals sppe.IDPflegeEintrag
                                                    //                                              select pe)
                                                    //                                  .Where(pe => pe.ID == IDPflegeeintrag)
                                                    //                                  .OrderBy(pe => pe.Zeitpunkt)
                                                    //                                  .ToList();
                                                    //    AddNodes(tblPflegeEintrag_N, nNotfallSP, "MaßnahmeMeldung", db, false);
                                                    //}

                                                    foreach (PMDS.db.Entities.SPPE sppe_sp in tblSPPE_N)
                                                    {
                                                        List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_N = (from pe in db.PflegeEintrag
                                                                                                                    select pe)
                                                                                      .Where(pe => pe.ID == sppe_sp.IDPflegeEintrag)
                                                                                      .OrderBy(pe => pe.Zeitpunkt)
                                                                                      .ToList();
                                                        AddNodes(tblPflegeEintrag_N, nNotfallSP, "MaßnahmeMeldung", db, false);
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
                                        List<PMDS.db.Entities.VO> tblVOs = db.VO.Where(vos => vos.IDAufenthalt == rAufenthalt.ID)
                                            .OrderBy(vos => vos.DatumVerordnetAb)
                                            .ToList();
                                        int mVOs = AddNodes(tblVOs, nVerordnungen, "Verordnung", db, true);

                                        for (int iVO = 0; iVO < mVOs; iVO++)
                                        {
                                            Chilkat.Xml nVO = nVerordnungen.GetChild(iVO);
                                            Guid IDVerordnung = new Guid(nVO.GetAttrValue("ID"));

                                            List<PMDS.db.Entities.VO_Bestelldaten> tblVOBestelldaten = db.VO_Bestelldaten
                                                        .Where(vobest => vobest.IDVerordnung == IDVerordnung)
                                                        .OrderBy(vobest => vobest.GueltigAb)
                                                        .ToList();
                                            int mBestelldaten = AddNodes(tblVOBestelldaten, nVO, "VO_Bestelldaten", db, false);

                                            for (int iBestelldaten = 0; iBestelldaten < mBestelldaten; iBestelldaten++)
                                            {
                                                Chilkat.Xml nVOBestelldaten = nVO.GetNthChildWithTag("VO_Bestelldaten", iBestelldaten);
                                                Guid IDBestelldaten = new Guid(nVOBestelldaten.GetAttrValue("ID"));
                                                List<PMDS.db.Entities.VO_Bestellpostitionen> tblVOBestellpositionen = db.VO_Bestellpostitionen
                                                    .Where(vobestpos => vobestpos.IDBestelldaten_VO == IDBestelldaten)
                                                    .OrderBy(vobestpos => vobestpos.DatumBestellung)
                                                    .ToList();

                                                AddNodes(tblVOBestellpositionen, nVOBestelldaten, "VO_Bestellposition", db, false);
                                            }

                                            List<PMDS.db.Entities.VO_Lager> tblVOLager = db.VO_Lager
                                                        .Where(volag => volag.IDVO == IDVerordnung)
                                                        .OrderBy(volag => volag.Seriennummer)
                                                        .ToList();
                                            AddNodes(tblVOLager, nVO, "VO_Lager", db, false);

                                            List<PMDS.db.Entities.VO_MedizinischeDaten> tblVoMedizinischeDaten = db.VO_MedizinischeDaten
                                                                            .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                            .OrderBy(vomed => vomed.DatumErstellt)
                                                                            .ToList();
                                            AddNodes(tblVoMedizinischeDaten, nVO, "VO_MedizinischeDaten", db, false);

                                            List<PMDS.db.Entities.VO_Wunde> tblVoWunden = db.VO_Wunde
                                                                            .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                            .OrderBy(vomed => vomed.DatumErstellt)
                                                                            .ToList();
                                            AddNodes(tblVoWunden, nVO, "VO_Wunde", db, false);

                                            List<PMDS.db.Entities.VO_PflegeplanPDX> tblVoPflegeplanPdx = db.VO_PflegeplanPDX
                                                                    .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                    .ToList();
                                            AddNodes(tblVoPflegeplanPdx, nVO, "VO_PflegeplanPDX", db, false);

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

            /*  Statt Benutzer zu jedem Node -> Benutzerliste in Stammdaten
            //Verschiedene Feldnamen in der DB für Suche in Benutzer-Tabelle, Adresstabelle usw.
            BenutzerFieldnames.Add("IDBENUTZER", "Benutzer");
            BenutzerFieldnames.Add("IDBENUTZER_ERSTELLT", "Benutzer_Erstellt");
            BenutzerFieldnames.Add("IDBENUTZERERSTELLT", "Benutzer_Erstellt");
            BenutzerFieldnames.Add("IDBENUTZER_BENDET", "Benutzer_Beendet");
            BenutzerFieldnames.Add("IDBENUTZER_AUFNAHME", "Benutzer_Aufnahme");
            BenutzerFieldnames.Add("IDBENUTZER_ENTLASSUNG", "Benutzer_Entlassung");
            BenutzerFieldnames.Add("IDBENUTZER_GEÄNDERT", "Benutzer_Geändert");
            BenutzerFieldnames.Add("IDBENUTZER_GEAENDERT", "Benutzer_Geändert");
            BenutzerFieldnames.Add("IDBENUTZERGEAENDERT", "Benutzer_Geändert");
            BenutzerFieldnames.Add("IDBENUTZERAUSGEGEBEN", "Benutzer_Ausgegeben");
            BenutzerFieldnames.Add("IDBENUTZERZURUECK", "Benutzer_Rücknahme");
            BenutzerFieldnames.Add("EDIBENUTZER", "EDI_Benutzer");
           */

            if (!AdresseFieldnames.ContainsKey("IDADRESSE"))
                AdresseFieldnames.Add("IDADRESSE", "Adresse");

            if (!AdresseFieldnames.ContainsKey("IDADRESSESUB"))
                AdresseFieldnames.Add("IDADRESSESUB", "AdresseSub");

            if (!KontaktFieldnames.ContainsKey("IDKONTAKT"))
                KontaktFieldnames.Add("IDKONTAKT", "Kontakt");

            if (!KontaktFieldnames.ContainsKey("IDKONTAKTSUB"))
                KontaktFieldnames.Add("IDKONTAKTSUB", "KontaktSub");

            if (!PflegegeldStufenFieldnames.ContainsKey("IDPFLEGEGELDSTUFE"))
                PflegegeldStufenFieldnames.Add("IDPFLEGEGELDSTUFE", "Pflegegeldstufe");

            if (!PflegegeldStufenFieldnames.ContainsKey("IDPFLEGEGELDSTUFEANTRAG"))
                PflegegeldStufenFieldnames.Add("IDPFLEGEGELDSTUFEANTRAG", "Pflegegeldstufe_Antrag");
        }

        private void ExportFDF(Guid ID, string FormularName, DateTime Datumerstellt, Byte[] fdfBlop, string PathKlientenFormulare, string KlientNameGebDat, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string ExportName = Path.Combine(PathKlientenFormulare, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(FormularName) + "_" + Datumerstellt.ToString("yyyyMMddHHmmss") + ".pdf");
                PMDS.db.Entities.Formular pdf = db.Formular.Where(f => f.Name == FormularName).FirstOrDefault();
                if (pdf != null)
                {
                    using (PdfForms formFDF = new PdfForms())
                    {
                        FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(fdfBlop);
                        Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(pdf.PDF_BLOP, formFDF);
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

        private int AddNodes<T>(List<T> tbl, Chilkat.Xml nParent, string ChildName, PMDS.db.Entities.ERModellPMDSEntities db, bool AutoAssignSubNodes)
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
                                && !generic.sEquals(vprop.Name, "RTF", Enums.eCompareMode.Contains)
                                && !generic .sEquals(vprop.Name, "BLOP", Enums.eCompareMode.Contains)
                            )
                        {
                            try
                            {
                                if (row.GetType().GetProperty(vprop.Name).GetValue(row, null) != null)
                                {
                                    nChild.AddAttribute(vprop.Name, row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                }
                                else
                                {
                                    nChild.AddAttribute(vprop.Name, "");
                                }
                            }
                            catch
                            {
                                nChild.AddAttribute(vprop.Name, "");
                            }
                        }

                        if (AutoAssignSubNodes && row.GetType().GetProperty(vprop.Name).GetValue(row, null) != null)
                        {

                            string NodeText = "";

                            if (generic.sEquals(vprop.Name, "IDKLINIK"))
                            {
                                Guid IDKlinik = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Klinik> tblKlinik = db.Klinik.Where(a => a.ID == IDKlinik).ToList();
                                AddNodes(tblKlinik, nChild, "Klinik", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDABTEILUNG"))
                            {
                                Guid IDAbteilung = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Abteilung> tblAbteilung = db.Abteilung.Where(a => a.ID == IDAbteilung).ToList();
                                AddNodes(tblAbteilung, nChild, "Abteilung", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDBEREICH"))
                            {
                                Guid IDBereich = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Bereich> tblBereich = db.Bereich.Where(a => a.ID == IDBereich).ToList();
                                AddNodes(tblBereich, nChild, "Bereich", db, false);
                            }

                            //Adressen
                            if (AdresseFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDAdresse = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Adresse> tblAdressen = db.Adresse.Where(a => a.ID == IDAdresse).ToList();
                                AddNodes(tblAdressen, nChild, NodeText, db, false);
                            }
                            //Kontakte
                            if (KontaktFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDKontakt = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Kontakt> tblKontakte = db.Kontakt.Where(a => a.ID == IDKontakt).ToList();
                                AddNodes(tblKontakte, nChild, NodeText, db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDBANK"))
                            {
                                Guid IDBank = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Bank> tblBanken = db.Bank.Where(a => a.ID == IDBank).ToList();
                                AddNodes(tblBanken, nChild, "Bank", db, false);
                            }
                            //Benutzer
                            if (BenutzerFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDBenutzer = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Benutzer> tblUsers = tblBenutzer.Where(a => a.ID == IDBenutzer).ToList();
                                AddNodes(tblUsers, nChild, NodeText, db, false);
                            }
                            //Pflegegeldstufen
                            if (PflegegeldStufenFieldnames.TryGetValue(vprop.Name.ToUpper(), out NodeText))
                            {
                                Guid IDPflegegeldStufe = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Pflegegeldstufe> tblPflegegeldStufen = db.Pflegegeldstufe.Where(a => a.ID == IDPflegegeldStufe).ToList();
                                AddNodes(tblPflegegeldStufen, nChild, NodeText, db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDPLAN"))
                            {
                                Guid IDPlan = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.plan> tblPlaene = db.plan.Where(a => a.ID == IDPlan).ToList();

                                //RTF in PlainText umsetzen
                                //System.Windows.Forms.RichTextBox rtBox = new RichTextBox();
                                //foreach (Plan pl in tblPlaene)
                                //{
                                //    rtBox.Rtf = pl.Text;
                                //    pl.Text = rtBox.Text;
                                //}
                                AddNodes(tblPlaene, nChild, "Plan", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDPDX"))
                            {
                                Guid IDPDX = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.PDX> tblPDXs = db.PDX.Where(a => a.ID == IDPDX).ToList();
                                AddNodes(tblPDXs, nChild, "PDX", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDMEDIKAMENT"))
                            {
                                Guid IDMedikament = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Medikament> tblMedikamente = db.Medikament.Where(med => med.ID == IDMedikament).ToList();
                                AddNodes(tblMedikamente, nChild, "Medikament_Heilbehelf", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDMEDIZINISCHEDATEN"))
                            {
                                Guid IDMedDaten = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.MedizinischeDaten> tblMedDaten = db.MedizinischeDaten.Where(med => med.ID == IDMedDaten).ToList();
                                AddNodes(tblMedDaten, nChild, "MedizinischeDaten", db, false);
                            }

                            if (generic.sEquals(vprop.Name, "IDWUNDEKOPF"))
                            {
                                Guid IDWundeKopf = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(med => med.ID == IDWundeKopf).ToList();
                                AddNodes(tblWundeKopf, nChild, "WundeKopf", db, false);
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
        }


    }
}
