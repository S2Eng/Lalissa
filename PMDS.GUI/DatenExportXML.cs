#define EXPORTDETAILS

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
using System.Windows.Forms;

namespace PMDS.GUI
{
    class DatenExportXML
    {
        private PMDS.db.Entities.ERModellPMDSEntities db;

        private enum eDataTable
        {
            Kliniken = 1,
            Abteilung = 2,
            Bereich = 3,
            Adresse = 4,
            Kontakt = 5
        }

        //private static Dictionary<string, string> BenutzerFieldnames = new Dictionary<string, string>();
        //private static Dictionary<string, string> KontaktFieldnames = new Dictionary<string, string>();
        //private static Dictionary<string, string> AdresseFieldnames = new Dictionary<string, string>();
        //private static Dictionary<string, string> PflegegeldStufenFieldnames = new Dictionary<string, string>();

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

        private string FileNameXMLDocumentBackTmp = "";

        private Chilkat.Xml xml = new Chilkat.Xml();
        private Chilkat.Xml nExportInfo;
        private Chilkat.Xml nKliniken;
        private Chilkat.Xml nAbteilungen;
        private Chilkat.Xml nBereiche;
        private Chilkat.Xml nAuswahlListenGruppen;
        private Chilkat.Xml nAuswahlListen;
        private Chilkat.Xml nDienstzeiten;
        private Chilkat.Xml nEinrichtungen;
        private Chilkat.Xml nFormulare;
        private Chilkat.Xml nFormulardaten;
        private Chilkat.Xml nMassnahmenserien;
        private Chilkat.Xml nMedizinischeTypen;
        private Chilkat.Xml nStandardzeiten;
        private Chilkat.Xml nZeitbereiche;
        private Chilkat.Xml nBenutzer;
        private Chilkat.Xml nAerzte;
        private Chilkat.Xml nKontaktpersonen;
        private Chilkat.Xml nPatientAerzte;
        private Chilkat.Xml nSachwalters;
        private Chilkat.Xml nAnamnesenKrohwinkel;
        private Chilkat.Xml nAnamnesenOrem;
        private Chilkat.Xml nAnamnesenPOP;
        private Chilkat.Xml nRehabilitationen;
        private Chilkat.Xml nArztabrechnungen;
        private Chilkat.Xml nPflegeStufen;
        private Chilkat.Xml nPatientBemerkungen;
        private Chilkat.Xml nMedizinischeDaten;
        private Chilkat.Xml nBiografien;
        private Chilkat.Xml nPlaene;
        private Chilkat.Xml nArchiv;
        private Chilkat.Xml nAufenthalte;
        private Chilkat.Xml nAufenthalt;
        private Chilkat.Xml nGegenstaende;
        private Chilkat.Xml nHilfsmitteln;
        private Chilkat.Xml nAbwesenheiten;
        private Chilkat.Xml nUnterbringungen;
        private Chilkat.Xml nVersetzungen;
        private Chilkat.Xml nPDX;
        private Chilkat.Xml nAetiologien;
        private Chilkat.Xml nSymptome;
        private Chilkat.Xml nRessourcen;
        private Chilkat.Xml nZiele;
        private Chilkat.Xml nZiel;
        private Chilkat.Xml nPPZielEvaluierungen;
        private Chilkat.Xml nMassnahmen;
        private Chilkat.Xml nTermine;
        private Chilkat.Xml nPflegeplaeneH;
        private Chilkat.Xml nPE_NONE;
        private Chilkat.Xml nPE_DEKURS;
        private Chilkat.Xml nPE_MASSNAHME;
        private Chilkat.Xml nPE_UNEXP_MASSNAHME;
        private Chilkat.Xml nPE_TERMIN;
        private Chilkat.Xml nPE_MEDIKAMENT;
        private Chilkat.Xml nPE_NOTFALL;
        private Chilkat.Xml nPE_PLANUNG;
        private Chilkat.Xml nPE_WUNDE;
        private Chilkat.Xml nPE_KLIENT;
        private Chilkat.Xml nPE_ASSESSMENT;
        private Chilkat.Xml nPE_VERORDNUNGEN;
        private Chilkat.Xml nPE_WUNDVERLAUF;
        private Chilkat.Xml nPE_WUNDTHERAPIE;
        private Chilkat.Xml nPDX_Wunde;
        private Chilkat.Xml nAetiologienWunde;
        private Chilkat.Xml nZieleWunde;
        private Chilkat.Xml nZielWunde;
        private Chilkat.Xml nWundeZielEvaluierungen;
        private Chilkat.Xml nMassnahmenWunde;
        private Chilkat.Xml nPDXWunde;
        private Chilkat.Xml nWunde;
        private Chilkat.Xml nWundeTherapien;
        private Chilkat.Xml nWundeVerlauefe;
        private Chilkat.Xml nWundeBilder;
        private Chilkat.Xml nRezepteintraege;
        private Chilkat.Xml nRezepteintrag;
        private Chilkat.Xml nMedikamentenAbgaben;
        private Chilkat.Xml nRezeptbestellungen;
        private Chilkat.Xml nStandardProzedur;
        private Chilkat.Xml nStandardprozedurSP;
        private Chilkat.Xml nStandardprozedurSPPos;
        private Chilkat.Xml nNotfallprozeduren;
        private Chilkat.Xml nNotfallProzedur;
        private Chilkat.Xml nNotfallSP;
        private Chilkat.Xml nNotfallSPPos;
        private Chilkat.Xml nVO;
        private Chilkat.Xml nVOBestelldaten;
        private Chilkat.Xml nChild;

        private static void DatenexportLog(PMDS.GUI.ucRichTextBox RTFLog, string Txt)
        {
            RTFLog.Text += "\n" + DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss ") + Txt;
            System.Windows.Forms.Application.DoEvents();
        }

        //public bool Export(System.Guid IDPatient, string ArchivPath, out string FileNameXMLDocumentBack)
        public bool Export(System.Guid IDPatient, string ArchivPath, out string FileNameXMLDocumentBack, ref PMDS.GUI.ucRichTextBox RTFLog)
        {
            FileNameXMLDocumentBack = "";

            try
            {
                DevOptions dOpt = new DevOptions();
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

//                xml.AddStyleSheet("<?xml-stylesheet href = \"PMDSExport.xsl\" type = \"text/xsl\"?>");
                xml.Encoding = "ISO-8859-1";
                xml.Standalone = true;
                xml.Tag = "PMDS-Datenexport";

                string KlientNameGebDat;
                string ExportPath;

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                db = PMDS.DB.PMDSBusiness.getDBContext();
                FileNameXMLDocumentBack = "";
                DatenexportLog(RTFLog, "XML-Export: Basisdaten und Verzeichnisse erstellen");

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

                    //wiederholt benötigte Tabellen einmal einlesen
                    List<PMDS.db.Entities.Benutzer> tblBenutzer = (from ben in db.Benutzer select ben)
                                    .OrderBy(e => e.Nachname)
                                    .ToList();

                    List<PMDS.db.Entities.Klinik> tblKlinik = (from kli in db.Klinik select kli)
                                    .OrderBy(e => e.Bezeichnung)
                                    .ToList();
 
                    List<PMDS.db.Entities.Abteilung> tblAbteilungen = (from abt in db.Abteilung select abt)
                                    .OrderBy(e => e.Bezeichnung)
                                    .ToList();

                    List<PMDS.db.Entities.Bereich> tblBereiche = (from ber in db.Bereich select ber)
                                    .OrderBy(e => e.Bezeichnung)
                                    .ToList();

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

                    nExportInfo = xml.NewChild("ExportInfo", "");
                    nExportInfo.AddAttribute("BeginnExport", dNow.ToString());
                    nExportInfo.AddAttribute("DBVersion", db.DBVersion.First().ScriptVersion);

                    SaveXML();

                    if (dOpt.AllgemeineStammdaten)
                    {
                        DatenexportLog(RTFLog, "XML-Export: Allgemeine Stammdaten erstellen");
                        //----------------- Allgemeine Stammdaten ---------------- 
                        using (Chilkat.Xml nAllgemeineStammdaten = xml.NewChild("Allgemeine_Stammdaten", ""))
                        {

                            //List<Klinik> tblKliniken = db.Klinik.ToList();
                            nKliniken = nAllgemeineStammdaten.NewChild("Kliniken", "");
                            AddNodes(tblKliniken, nKliniken, "Klinik", true);

                            //List<Abteilung> tblAbteilungen = db.Abteilung.ToList();
                            nAbteilungen = nAllgemeineStammdaten.NewChild("Abteilungen", "");
                            AddNodes(tblAbteilungen, nAbteilungen, "Abteilung", true);                     

                            //List<Bereich> tblBereiche = db.Bereich.ToList();
                            nBereiche = nAllgemeineStammdaten.NewChild("Bereiche", "");
                            AddNodes(tblBereiche, nBereiche, "Bereich", true);

                            nAuswahlListenGruppen = nAllgemeineStammdaten.NewChild("AuswahlListenGruppen", "");
                            List<PMDS.db.Entities.AuswahlListeGruppe> tblAuswahlListenGruppen = db.AuswahlListeGruppe.ToList();
                            AddNodes(tblAuswahlListenGruppen, nAuswahlListenGruppen, "AuswahlListenGruppe", true);

                            nAuswahlListen = nAllgemeineStammdaten.NewChild("AuswahlListen", "");
                            List<PMDS.db.Entities.AuswahlListe> tblAuswahlListen = db.AuswahlListe.OrderBy(l => l.IDAuswahlListeGruppe).ToList();
                            AddNodes(tblAuswahlListen, nAuswahlListen, "AuswahlListe", true);

                            List<PMDS.db.Entities.Dienstzeiten> tblDienstzeiten = db.Dienstzeiten.ToList();
                            nDienstzeiten = nAllgemeineStammdaten.NewChild("Dienstzeiten", "");
                            AddNodes(tblDienstzeiten, nDienstzeiten, "Dienstzeit", false);

                            List<PMDS.db.Entities.Einrichtung> tblEinrichtungen = db.Einrichtung.ToList();
                            nEinrichtungen = nAllgemeineStammdaten.NewChild("Einrichtungen", "");
                            AddNodes(tblEinrichtungen, nEinrichtungen, "Einrichtung", true);

                            List<PMDS.db.Entities.Formular> tblFormulare = db.Formular.ToList();
                            nFormulare = nAllgemeineStammdaten.NewChild("Formulare", "");
                            AddNodes(tblFormulare, nFormulare, "Formular", true);

                            List<PMDS.db.Entities.Massnahmenserien> tblMassnahmenserien = db.Massnahmenserien.ToList();
                            nMassnahmenserien = nAllgemeineStammdaten.NewChild("Maßnahmenserien", "");
                            AddNodes(tblMassnahmenserien, nMassnahmenserien, "Maßnahmenserie", true);

                            List<PMDS.db.Entities.MedizinischeTypen> tblMedizinischeTypen = db.MedizinischeTypen.ToList();
                            nMedizinischeTypen = nAllgemeineStammdaten.NewChild("MedizinischeTypen", "");
                            AddNodes(tblMedizinischeTypen, nMedizinischeTypen, "MedizinischerTyp", true);

                            List<PMDS.db.Entities.Standardzeiten> tblStandardzeiten = db.Standardzeiten.ToList();
                            nStandardzeiten = nAllgemeineStammdaten.NewChild("Standardzeiten", "");
                            AddNodes(tblStandardzeiten, nStandardzeiten, "Standardzeit", true);

                            List<PMDS.db.Entities.Zeitbereich> tblZeitbereiche = db.Zeitbereich.ToList();
                            nZeitbereiche = nAllgemeineStammdaten.NewChild("Zeitbereiche", "");
                            AddNodes(tblZeitbereiche, nZeitbereiche, "Zeitbereich", false);

                            nBenutzer = nAllgemeineStammdaten.NewChild("BenutzerListe", "");
                            AddNodes(tblBenutzer, nBenutzer, "Benutzer", true);

                            List<PMDS.db.Entities.Aerzte> tblAerzte = (from ae in db.Aerzte
                                                        join pae in db.PatientAerzte on ae.ID equals pae.IDAerzte
                                                        where
                                                        pae.IDPatient == patDto.ID
                                                        select ae)
                                                            .OrderBy(ae => ae.Nachname)
                                                            .OrderBy(ae => ae.Vorname)
                                                            .ToList();
                            nAerzte = nAllgemeineStammdaten.NewChild("Ärzte", "");
                            AddNodes(tblAerzte, nAerzte, "Arzt", true);

                            //Pflegemodelle = nicht erforderlich
                            //nAbrechnungStammdaten = xml.NewChild("Abrechnungsbezogene_Stammdaten", "");
                            //var tblKostentraeger = db.Kostentraeger.ToList();
                            //nKostentraegers = nAbrechnungStammdaten.NewChild("Kostentraeger", "");
                            //AddNodes(tblKostentraeger, nKostentraegers, "Kostentraeger", db, true);
                            //Leistungskatalog, LeistungskatalogGueltig, Pflegegeldstufe, PflegegeldstufeGueltig, Sonderleistungskatalog, Taschengeld
                            //Pflegegeldstufe, PflegegeldstufeGueltig
                        }
                        SaveXML();
                    }

                    // ----------------- Klient ----------------------------
                    List<PMDS.db.Entities.Patient> tblKlienten = db.Patient.Where(p => p.ID == patDto.ID).ToList();
                    AddNodes(tblKlienten, xml, "Klient", true);

                    using (Chilkat.Xml nKlient = xml.GetChildWithAttr("Klient", "ID", patDto.ID.ToString()))
                    {
                        if (dOpt.Klientendaten)
                        {
                            DatenexportLog(RTFLog, "XML-Export: Klientendaten erstellen");
                            List<PatientenfotoDTO> PatientBild = (from p in db.Patient
                                                                    where p.ID == patDto.ID
                                                                    select new PatientenfotoDTO { ID = p.ID, Foto = p.Foto }).ToList();
                            if (PatientBild.FirstOrDefault().Foto != null)
                                ByteArrayToFile(Path.Combine(PathKlientenBild, KlientNameGebDat + ".jpg"), (Byte[])PatientBild.FirstOrDefault().Foto);

                            List<PMDS.db.Entities.Kontaktperson> tblKontaktpersonen = db.Kontaktperson.Where(kp => kp.IDPatient == patDto.ID).ToList();
                            nKontaktpersonen = nKlient.NewChild("Kontaktpersonen", "");
                            AddNodes(tblKontaktpersonen, nKontaktpersonen, "Kontaktperson", true);

                            List<PMDS.db.Entities.PatientAerzte> tblPatientAerzte = db.PatientAerzte.Where(a => a.IDPatient == patDto.ID).ToList();
                            nPatientAerzte = nKlient.NewChild("Ärzte", "");
                            AddNodes(tblPatientAerzte, nPatientAerzte, "Arzt", true);

                            List<PMDS.db.Entities.Sachwalter> tblSachwalters = db.Sachwalter.Where(sw => sw.IDPatient == patDto.ID).ToList();
                            nSachwalters = nKlient.NewChild("Erwachsenenvertreter_Vorsorgebevollmächtigte", "");
                            AddNodes(tblSachwalters, nSachwalters, "Erwachsenenvertreter_Vorsorgebevollmächtigter", true);

                            List<PMDS.db.Entities.Anamnese_Krohwinkel> tblAnamnesenKrohwinkel = db.Anamnese_Krohwinkel.Where(anak => anak.IDPatient == patDto.ID).ToList();
                            nAnamnesenKrohwinkel = nKlient.NewChild("AnamnesenKrohwinkel", "");
                            AddNodes(tblAnamnesenKrohwinkel, nAnamnesenKrohwinkel, "AnamneseKrohwinkel", true);

                            List<PMDS.db.Entities.Anamnese_Orem> tblAnamnesenOrem = db.Anamnese_Orem.Where(anao => anao.IDPatient == patDto.ID).ToList();
                            nAnamnesenOrem = nKlient.NewChild("AnamnesenOrem", "");
                            AddNodes(tblAnamnesenOrem, nAnamnesenOrem, "AnamneseOrem", true);

                            List<PMDS.db.Entities.Anamnese_POP> tblAnamnesenPOP = db.Anamnese_POP.Where(anap => anap.IDPatient == patDto.ID).ToList();
                            nAnamnesenPOP = nKlient.NewChild("AnamnesenPOP", "");
                            AddNodes(tblAnamnesenPOP, nAnamnesenPOP, "AnamnesePOP", true);

                            List<PMDS.db.Entities.Rehabilitation> tblRehabilitationen = db.Rehabilitation.Where(reha => reha.IDPatient == patDto.ID).ToList();
                            nRehabilitationen = nKlient.NewChild("Rehabilitationen", "");
                            AddNodes(tblRehabilitationen, nRehabilitationen, "Rehabilitation", true);

                            List<PMDS.db.Entities.Arztabrechnung> tblArztabrechnungen = db.Arztabrechnung.Where(aa => aa.IDPatient == patDto.ID).OrderBy(aa => aa.Datum).ToList();
                            nArztabrechnungen = nKlient.NewChild("Arztabrechnungen", "");
                            AddNodes(tblArztabrechnungen, nArztabrechnungen, "Arztabrechnung", true);

                            List<PMDS.db.Entities.PatientPflegestufe> tblPflegeStufen = db.PatientPflegestufe.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.GueltigAb).ToList();
                            nPflegeStufen = nKlient.NewChild("PflegeStufen", "");
                            AddNodes(tblPflegeStufen, nPflegeStufen, "PflegeStufe", true);

                            List<PMDS.db.Entities.PatientenBemerkung> tblPatientBemerkungen = db.PatientenBemerkung.Where(pbem => pbem.IDPatient == patDto.ID).ToList();
                            nPatientBemerkungen = nKlient.NewChild("PatientBemerkungen", "");
                            AddNodes(tblPatientBemerkungen, nPatientBemerkungen, "PatientBemerkung", true);

                            List<PMDS.db.Entities.MedizinischeDaten> tblMedizinischeDaten = db.MedizinischeDaten.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.Typ).OrderBy(ps => ps.Von).ToList();
                            nMedizinischeDaten = nKlient.NewChild("MedizinischeDaten", "");
                            AddNodes(tblMedizinischeDaten, nMedizinischeDaten, "MedizinischesDatum", true);

                            List<PMDS.db.Entities.FormularDaten> tblFormularDaten = db.FormularDaten.Where(fd => fd.IDREF == patDto.ID && fd.PDF_BLOP != null).OrderBy(fd => fd.FormularName).OrderBy(fd => fd.Datumerstellt).ToList();
                            nFormulardaten = nKlient.NewChild("Formulardaten", "");
                            AddNodes(tblFormularDaten, nFormulardaten, "Formular", true);
                            foreach (var fd in tblFormularDaten)
                            {
                                ExportFDF(fd.ID, StripSpecialCharacters(fd.FormularName), fd.Datumerstellt, fd.PDF_BLOP, PathKlientenFormulare, KlientNameGebDat);
                            }

                            List<PMDS.db.Entities.FormularDaten> tblBiografien = db.FormularDaten.Where(bio => bio.IDREF == patDto.ID && bio.PDF_BLOP == null && (bio.BLOP.ToString().StartsWith(@"{\rtf1"))).OrderBy(az => az.FormularName).OrderBy(az => az.Datumerstellt).ToList();
                            nBiografien = nKlient.NewChild("Biografien", "");
                            AddNodes(tblBiografien, nBiografien, "Biografie", true);
                            foreach (var fd in tblBiografien)
                            {
                                string FileNameWundeBild = System.IO.Path.Combine(PathKlientenBiografien, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(StripSpecialCharacters(fd.FormularName)) + "_" + fd.Datumerstellt.ToString("yyyyMMddHHmmss") + "_" + fd.ID.ToString() + ".rtf");
                                StringToFile(FileNameWundeBild, fd.BLOP);
                            }

                            if (dOpt.KlientenTermineArchiv)
                            {
                                DatenexportLog(RTFLog, "XML-Export: Termine und Archiv exportieren");
                                //Kliententermine
                                List<PMDS.db.Entities.planObject> tblPlaene = db.planObject.Where(plan => plan.IDObject == patDto.ID).OrderBy(plan => plan.Status).ToList();
                                nPlaene = nKlient.NewChild("Kliententermine_Pläne", "");
                                AddNodes(tblPlaene, nPlaene, "Kliententermin_Plan", true);

                                //Archiv
                                List<PMDS.db.Entities.tblDokumente> tblArchiv = (from dok in db.tblDokumente
                                                                join dokein in db.tblDokumenteintrag on dok.IDDokumenteintrag equals dokein.ID
                                                                join obj in db.tblObjekt on dokein.ID equals obj.IDDokumenteintrag
                                                                where obj.ID_guid == patDto.ID
                                                                select dok)
                                                    .OrderBy(dok => dok.ErstelltAm)
                                                    .ToList();
                                nArchiv = nKlient.NewChild("Archiveinträge", "");
                                AddNodes(tblArchiv, nArchiv, "Archiveintrag", true);

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
                        nAufenthalte = nKlient.NewChild("Aufenthalte", "");

                        List<AufenthaltDTO> tAufenthalte = (from Aufenthalte in db.Aufenthalt
                                                                where Aufenthalte.IDPatient == patDto.ID
                                                                select new AufenthaltDTO { ID = Aufenthalte.ID, Aufnahmezeitpunkt = (DateTime)Aufenthalte.Aufnahmezeitpunkt })
                                                .OrderBy(o => o.Aufnahmezeitpunkt).ToList();

                        foreach (var rAufenthalt in tAufenthalte)
                        {
                            List<PMDS.db.Entities.Aufenthalt> tblAufenthalte = db.Aufenthalt.Where(a => a.ID == rAufenthalt.ID).OrderBy(a => a.Aufnahmezeitpunkt).ToList();
                            AddNodes(tblAufenthalte, nAufenthalte, "Aufenthalt", true);

                            nAufenthalt = nAufenthalte.GetChildWithAttr("Aufenthalt", "ID", rAufenthalt.ID.ToString());

                            if (dOpt.Aufenthaltsdaten)
                            {
                                DatenexportLog(RTFLog, "XML-Export: Aufenthaltsdaten exportieren (" + rAufenthalt.Aufnahmezeitpunkt.ToString("yyyy-MM-dd HH:mm:ss"));
                                List<PMDS.db.Entities.AufenthaltZusatz> tblAufenthaltzusatz = db.AufenthaltZusatz.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                                AddNodes(tblAufenthaltzusatz, nAufenthalt, "Aufenthaltzusatz", true);

                                List<PMDS.db.Entities.Gegenstaende> tblGegestaende = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == false).ToList();
                                nGegenstaende = nAufenthalt.NewChild("Gegenstände", "");
                                AddNodes(tblGegestaende, nGegenstaende, "Gegenstand", true);

                                List<PMDS.db.Entities.Gegenstaende> tblHilfsmittel = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == true).ToList();
                                nHilfsmitteln = nAufenthalt.NewChild("HilfsmittelListe", "");
                                AddNodes(tblHilfsmittel, nHilfsmitteln, "Hilfsmittel", true);

                                List<PMDS.db.Entities.Unterbringung> tblUnterbringungen = db.Unterbringung.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                                nUnterbringungen = nAufenthalt.NewChild("HAG_Meldungen", "");
                                AddNodes(tblUnterbringungen, nUnterbringungen, "HAG_Meldung", true);

                                List<PMDS.db.Entities.UrlaubVerlauf> tblUrlaubVerlauf = db.UrlaubVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.StartDatum).ToList();
                                nAbwesenheiten = nAufenthalt.NewChild("Abwesenheiten", "");
                                AddNodes(tblUrlaubVerlauf, nAbwesenheiten, "Abwesenheit", true);

                                List<PMDS.db.Entities.AufenthaltVerlauf> tblAufenthaltVerlauf = db.AufenthaltVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.Datum).ToList();
                                nVersetzungen = nAufenthalt.NewChild("AufenthaltsverlaufListe", "");
                                AddNodes(tblAufenthaltVerlauf, nVersetzungen, "Aufenthaltsverlauf", true);
                                SaveXML();

                            }

                            using (Chilkat.Xml nPflegeplan = nAufenthalt.NewChild("Pflegeplan", ""))
                            {
                                if (dOpt.Pflegeplan)
                                {
                                    DatenexportLog(RTFLog, "XML-Export: Pflegeplan exportieren");
                                    List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsPP = db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == false).ToList();
                                    int iAufenthaltPDxPP = AddNodes(tblAufenthaltPDXsPP, nPflegeplan, "Aufenthalt_PDX", true);

                                    for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsPP.Count; iAPDX++)
                                    {
                                        Guid IDAufenthaltPDX = tblAufenthaltPDXsPP[iAPDX].ID;
                                        Guid IDPDX = (Guid)tblAufenthaltPDXsPP[iAPDX].IDPDX;

                                        List<PMDS.db.Entities.PflegePlanPDx> tblPflegeplanPDX = db.PflegePlanPDx.Where(az => az.IDAufenthaltPDx == IDAufenthaltPDX && az.IDPDX == IDPDX).ToList();

                                        nPDX = nPflegeplan.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

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
                                            nAetiologien = nPDX.NewChild("Ätiologien_Risikofaktoren", "");
                                            List<PMDS.db.Entities.PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                            AddNodes(tblAetiologien, nAetiologien, "Ätiologie_Risikofaktor", true);

                                            nSymptome = nPDX.NewChild("Symptome", "");
                                            List<PMDS.db.Entities.PflegePlan> tblSymptome = tblPflegeplaene.Where(pp => pp.EintragGruppe == "S").ToList();
                                            AddNodes(tblSymptome, nSymptome, "Symptom", true);

                                            nRessourcen = nPDX.NewChild("Ressourcen", "");
                                            List<PMDS.db.Entities.PflegePlan> tblRessourcen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "R").ToList();
                                            AddNodes(tblRessourcen, nRessourcen, "Ressource", true);

                                            nZiele = nPDX.NewChild("Ziele", "");
                                            List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                            AddNodes(tblZiele, nZiele, "Ziel", true);

                                            //Evaluierung zu Pflegeplan (Ziele)
                                            if (tblZiele.Count > 0)
                                            {
                                                foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                                {
                                                    List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                                    if (tblEvaluierungen.Count > 0)
                                                    {
                                                        nZiel = nZiele.GetChildWithAttr("Ziel", "ID", rZiel.ID.ToString());
                                                        if (nZiel != null)
                                                        {
                                                            nPPZielEvaluierungen = nZiel.NewChild("Evaluierungen-Pflegeplan", "");
                                                            AddNodes(tblEvaluierungen, nPPZielEvaluierungen, "EvaluierungPflegeplan", false);
                                                        }
                                                    }
                                                }
                                            }

                                            nMassnahmen = nPDX.NewChild("Maßnahmen", "");
                                            List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                            AddNodes(tblMassnahmen, nMassnahmen, "Maßnahme", true);
                                        }
                                    }
                                    SaveXML();

                                }

                                if (dOpt.PflegeplanTermine)
                                {
                                    DatenexportLog(RTFLog, "XML-Export: Pflegeplantermine exportieren");

                                    using (Chilkat.Xml nTermine = nPflegeplan.NewChild("Termine", ""))
                                    {
                                        List<PMDS.db.Entities.PflegePlan> tblTermine = db.PflegePlan.Where(pp => pp.IDAufenthalt == rAufenthalt.ID && pp.EintragGruppe == "T").OrderBy(pp => pp.StartDatum).ToList();
                                        AddNodes(tblTermine, nTermine, "Termin", true);
                                    }
                                    SaveXML();

                                }

                                if (dOpt.PflegeplanHistorie)
                                {
                                    using (Chilkat.Xml nPflegeplaeneH = nPflegeplan.NewChild("PflegepläneHistorie", ""))
                                    {
                                        DatenexportLog(RTFLog, "XML-Export: Pflegeplanhistorie exportieren");
                                        List<PMDS.db.Entities.PflegePlanH> tblPflegeplanH = (from pph in db.PflegePlanH
                                                                            join e in db.Eintrag on pph.IDEintrag equals e.ID
                                                                            select pph)
                                                                            .Where(pp => pp.IDAufenthalt == rAufenthalt.ID)
                                                                            .OrderBy(e => e.Text)
                                                                            .OrderBy(pp => pp.DatumErstellt)
                                                                            .ToList();
                                        AddNodes(tblPflegeplanH, nPflegeplaeneH, "PflegeplanHistorie", true);
                                    }
                                    SaveXML();

                                }
                            }

                            if (dOpt.PflegeDokumentation)
                            {
                                using (Chilkat.Xml nPflegedokumentation = nAufenthalt.NewChild("Pflegedokumentation", ""))
                                {
                                    DatenexportLog(RTFLog, "XML-Export: Pflegedokumentation exportieren");
                                    List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp != 2).ToList();

                                    nPE_NONE = nPflegedokumentation.NewChild("Ohne_Klassifizierungen", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == -1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NONE, "Doku_Ohne_Klassifizierung", false);
                                    nPE_DEKURS = nPflegedokumentation.NewChild("Dekurse", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 0).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Dekurs", false);
                                    nPE_MASSNAHME = nPflegedokumentation.NewChild("Maßnahmen", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 1).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_DEKURS, "Doku_Maßnahme", false);
                                    nPE_UNEXP_MASSNAHME = nPflegedokumentation.NewChild("Ungeplante_Maßnahmen", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 3).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_UNEXP_MASSNAHME, "Doku_Ungeplante_Maßnahme", false);
                                    nPE_TERMIN = nPflegedokumentation.NewChild("Termine", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 4).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_TERMIN, "Doku_Termin", false);
                                    nPE_MEDIKAMENT = nPflegedokumentation.NewChild("Medikamente", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 5).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_MEDIKAMENT, "Doku_Medikament", false);
                                    nPE_NOTFALL = nPflegedokumentation.NewChild("Notfälle", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 6).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_NOTFALL, "Doku_Notfall", false);
                                    nPE_PLANUNG = nPflegedokumentation.NewChild("Planungen", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 7).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_PLANUNG, "Doku_Planung", false);
                                    nPE_WUNDE = nPflegedokumentation.NewChild("Wunden", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 8).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDE, "Doku_Wunde", false);
                                    nPE_KLIENT = nPflegedokumentation.NewChild("Klienten", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 9).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_KLIENT, "Doku_Klient", false);
                                    nPE_ASSESSMENT = nPflegedokumentation.NewChild("Assessments", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 10).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_ASSESSMENT, "Doku_Assessment", false);
                                    nPE_VERORDNUNGEN = nPflegedokumentation.NewChild("Verordnungen", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 11).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_VERORDNUNGEN, "Doku_Verordnung", false);
                                    nPE_WUNDVERLAUF = nPflegedokumentation.NewChild("Wundverläufe", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 12).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDVERLAUF, "Doku_Wundverlauf", false);
                                    nPE_WUNDTHERAPIE = nPflegedokumentation.NewChild("Wundtherapien", "");
                                    AddNodes(tblPflegeeintraege.Where(pe => pe.EintragsTyp == 13).OrderBy(pe => pe.Zeitpunkt).ToList(), nPE_WUNDTHERAPIE, "Doku_Wundtherapie", false);
                                    SaveXML();

                                }
                            }

                            if (dOpt.WundDokumentation)
                            {
                                using (Chilkat.Xml nWunden = nAufenthalt.NewChild("Wunddokumentation", ""))
                                {
                                    DatenexportLog(RTFLog, "XML-Export: Wunddoku exportieren");
                                    List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsW = db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == true).ToList();
                                    int iAufenthaltPDxW = AddNodes(tblAufenthaltPDXsW, nWunden, "Aufenthalt_PDX_Wunde", true);

                                    for (int iAPDX = 0; iAPDX < tblAufenthaltPDXsW.Count; iAPDX++)
                                    {
                                        Guid IDAufenthaltPDX = tblAufenthaltPDXsW[iAPDX].ID;
                                        Guid IDPDX = (Guid)tblAufenthaltPDXsW[iAPDX].IDPDX;

                                        List<PMDS.db.Entities.PflegePlanPDx> tblPflegeplanPDX = db.PflegePlanPDx.Where(az => az.IDAufenthaltPDx == IDAufenthaltPDX && az.IDPDX == IDPDX).ToList();

                                        nPDX_Wunde = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);

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
                                            nAetiologienWunde = nPDX_Wunde.NewChild("BeeinflussendeFaktoren", "");
                                            List<PMDS.db.Entities.PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                            AddNodes(tblAetiologien, nAetiologienWunde, "BeeinflussenderFaktor", true);

                                            nZieleWunde = nPDX_Wunde.NewChild("Ziele", "");
                                            List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                            AddNodes(tblZiele, nZieleWunde, "Ziel", true);

                                            //Evaluierung zu Pflegeplan (Ziele)
                                            if (tblZiele.Count > 0)
                                            {
                                                foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                                {
                                                    List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                                    if (tblEvaluierungen.Count > 0)
                                                    {
                                                        nZielWunde = nZiele.GetChildWithAttr("Ziel", "ID", rZiel.ID.ToString());
                                                        if (nZielWunde != null)
                                                        {
                                                            nWundeZielEvaluierungen = nZielWunde.NewChild("Evaluierungen-Wunde", "");
                                                            AddNodes(tblEvaluierungen, nWundeZielEvaluierungen, "EvaluierungWunde", true);
                                                        }
                                                    }
                                                }
                                            }

                                            nMassnahmenWunde = nPDX_Wunde.NewChild("Maßnahmen", "");
                                            List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                            AddNodes(tblMassnahmen, nMassnahmenWunde, "Maßnahme", true);

                                            nPDXWunde = nWunden.GetChild(iAPDX).GetNthChildWithTag("PDX", 0);
                                            List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(wk => wk.IDAufenthaltPDx == IDAufenthaltPDX).ToList();
                                            if (tblWundeKopf.Count > 0)
                                            {
                                                AddNodes(tblWundeKopf, nPDXWunde, "Wunde", true);
                                                nWunde = nPDXWunde.GetChildWithTag("Wunde");

                                                Guid IDWundeKopf = new Guid(nWunde.GetAttrValue("ID"));

                                                nWundeTherapien = nWunde.NewChild("Wundetherapien", "");
                                                List<PMDS.db.Entities.WundeTherapie> tblWundeTherapie = db.WundeTherapie.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wt => wt.DatumErstellt).ToList();
                                                AddNodes(tblWundeTherapie, nWundeTherapien, "Wundtherapie", true);

                                                nWundeVerlauefe = nWunde.NewChild("Wundeverläufe", "");
                                                List<PMDS.db.Entities.WundePos> tblWundeVerlaufe = db.WundePos.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wv => wv.DatumErstellt).ToList();
                                                AddNodes(tblWundeVerlaufe, nWundeVerlauefe, "Wundverlauf", true);

                                                nWundeBilder = nWunde.NewChild("Wundbilder", "");
                                                List<PMDS.db.Entities.WundePosBilder> tblWundePosBilder = (from wb in db.WundePosBilder
                                                                                            join wp in db.WundePos on wb.IDWundePos equals wp.ID
                                                                                            where wp.IDWundeKopf == IDWundeKopf
                                                                                            select wb)
                                                                        .OrderBy(wb => wb.DatumErstellt)
                                                                        .ToList();
                                                AddNodes(tblWundePosBilder, nWundeBilder, "Wundbild", true);

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
                                    DatenexportLog(RTFLog, "XML-Export: Medikation exportieren");
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

                                    AddNodes(tblMedikamente, nMedikamente, "Medikament", true);
                                    foreach (PMDS.db.Entities.Medikament Medikament in tblMedikamente)
                                    {
                                        nRezepteintraege = nMedikamente.GetChildWithAttr("Medikament", "ID", Medikament.ID.ToString());
                                        if (nRezepteintraege != null)
                                        {
                                            List<PMDS.db.Entities.RezeptEintrag> tblre = (from re in tblRezepteintraege
                                                                            where re.IDMedikament == Medikament.ID
                                                                            select re).ToList();
                                            if (tblre.Count > 0)
                                            {
                                                AddNodes(tblre, nRezepteintraege, "Rezepteintrag", true);

                                                foreach (PMDS.db.Entities.RezeptEintrag re in tblre)
                                                {
                                                    nRezepteintrag = nRezepteintraege.GetChildWithAttr("Rezepteintrag", "ID", re.ID.ToString());
                                                    if (nRezepteintrag != null)
                                                    {
                                                        List<PMDS.db.Entities.MedikationAbgabe> tblMedAbg = (from medab in tblMedikationAbgaben
                                                                                            where medab.IDRezeptEintrag == re.ID
                                                                                            select medab).ToList();

                                                        if (tblMedAbg.Count > 0)
                                                        {
                                                            nMedikamentenAbgaben = nRezepteintrag.NewChild("Medikamenentabgaben", "");
                                                            AddNodes(tblMedAbg, nMedikamentenAbgaben, "Medikamentenabgabe", false);
                                                        }

                                                        List<PMDS.db.Entities.RezeptBestellungPos> tblRezBest = (from rezbest in tblRezeptBestellungen
                                                                                                where rezbest.IDRezeptEintrag == re.ID
                                                                                                select rezbest).ToList();

                                                        if (tblRezBest.Count > 0)
                                                        {
                                                            nRezeptbestellungen = nRezepteintrag.NewChild("Rezeptbestellungen", "");
                                                            AddNodes(tblRezBest, nRezeptbestellungen, "Rezeptbestellung", false);
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
                                    DatenexportLog(RTFLog, "XML-Export: Standardprozeduren und Notfälle exportieren");
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
                                    int nSProz_SP = AddNodes(tblStandardprozeduren_SP, nStandardprozeduren, "Standardprozedur", true);
                                    for (int iSProz_SP = 0; iSProz_SP < nSProz_SP; iSProz_SP++)
                                    {
                                        nStandardProzedur = nStandardprozeduren.GetChild(iSProz_SP);
                                        Guid IDSProz_SP = new Guid(nStandardProzedur.GetAttrValue("ID"));
                                        List<PMDS.db.Entities.SP> tblSP_SP = (from sp in tblSp
                                                                select sp)
                                                                .Where(sp => sp.IDStandardProzeduren == IDSProz_SP)
                                                                .OrderBy(sp => sp.Zeitpunkt)
                                                                .ToList();
                                        int nSP_SP = AddNodes(tblSP_SP, nStandardProzedur, "Standardprozedur", true);

                                        for (int iSP_SP = 0; iSP_SP < nSP_SP; iSP_SP++)
                                        {
                                            nStandardprozedurSP = nStandardProzedur.GetChild(iSP_SP);
                                            Guid IDSP_SP = new Guid(nStandardprozedurSP.GetAttrValue("ID"));
                                            List<PMDS.db.Entities.SPPOS> tblSPPOS_SP = (from sppos in tblSppos
                                                                        select sppos)
                                                                .Where(sppos => sppos.IDSP == IDSP_SP)
                                                                .OrderBy(sppos => sppos.DatumErstellt)
                                                                .ToList();

                                            int nSPPos_SP = AddNodes(tblSPPOS_SP, nStandardprozedurSP, "Standardprozedur_Eintrag", true);
                                            for (int iSPPos_SP = 0; iSPPos_SP < nSPPos_SP; iSPPos_SP++)
                                            {
                                                nStandardprozedurSPPos = nStandardprozedurSP.GetChild(iSPPos_SP);
                                                Guid IDEintrag_SP = new Guid(nStandardprozedurSPPos.GetAttrValue("IDEintrag"));
                                                List<PMDS.db.Entities.Eintrag> tblEintrag_SP = (from e in db.Eintrag
                                                                                select e)
                                                                                .Where(e => e.ID == IDEintrag_SP)
                                                                                .ToList();
                                                AddNodes(tblEintrag_SP, nStandardprozedurSPPos, "Eintrag", true);
                                            }

                                            List<PMDS.db.Entities.SPPE> tblSPPE_SP = (from sppe in tblSppe
                                                                        select sppe)
                                                                    .Where(sppe => sppe.IDSP == IDSP_SP)
                                                                    .ToList();

                                            foreach (PMDS.db.Entities.SPPE sppe_sp in tblSPPE_SP)
                                            {
                                                List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_SP = (from pe in db.PflegeEintrag
                                                                                                            select pe)
                                                                                .Where(pe => pe.ID == sppe_sp.IDPflegeEintrag)
                                                                                .OrderBy(pe => pe.Zeitpunkt)
                                                                                .ToList();
                                                AddNodes(tblPflegeEintrag_SP, nStandardprozedurSP, "MaßnahmeMeldung", false);
                                            }
                                        }

                                        //Notfälle
                                        nNotfallprozeduren = nAufenthalt.NewChild("Notfallprozeduren", "");
                                        int nSProz_N = AddNodes(tblStandardprozeduren_N, nNotfallprozeduren, "Notfallprozedur", true);
                                        for (int iSProz_N = 0; iSProz_N < nSProz_N; iSProz_N++)
                                        {
                                            nNotfallProzedur = nNotfallprozeduren.GetChild(iSProz_N);
                                            Guid IDSProz_N = new Guid(nNotfallProzedur.GetAttrValue("ID"));
                                            List<PMDS.db.Entities.SP> tblSP_N = (from sp in tblSp
                                                                select sp)
                                                                    .Where(sp => sp.IDStandardProzeduren == IDSProz_N)
                                                                    .OrderBy(sp => sp.Zeitpunkt)
                                                                    .ToList();
                                            int nSP_N = AddNodes(tblSP_N, nNotfallProzedur, "Notfall", true);

                                            for (int iSP_N = 0; iSP_N < nSP_N; iSP_N++)
                                            {
                                                nNotfallSP = nNotfallProzedur.GetChild(iSP_N);
                                                Guid IDSP_N = new Guid(nNotfallSP.GetAttrValue("ID"));
                                                List<PMDS.db.Entities.SPPOS> tblSPPOS_N = (from sppos in tblSppos
                                                                            select sppos)
                                                                    .Where(sppos => sppos.IDSP == IDSP_N)
                                                                    .OrderBy(sppos => sppos.DatumErstellt)
                                                                    .ToList();

                                                int nSPPos_N = AddNodes(tblSPPOS_N, nNotfallSP, "Notfall_Eintrag", true);
                                                for (int iSPPos_N = 0; iSPPos_N < nSPPos_N; iSPPos_N++)
                                                {
                                                    nNotfallSPPos = nNotfallSP.GetChild(iSPPos_N);
                                                    Guid IDEintrag_N = new Guid(nNotfallSPPos.GetAttrValue("IDEintrag"));
                                                    List<PMDS.db.Entities.Eintrag> tblEintrag_N = (from e in db.Eintrag
                                                                                    select e)
                                                                                    .Where(e => e.ID == IDEintrag_N)
                                                                                    .ToList();
                                                    AddNodes(tblEintrag_N, nNotfallSPPos, "Eintrag", true);
                                                }

                                                List<PMDS.db.Entities.SPPE> tblSPPE_N = (from sppe in tblSppe
                                                                        select sppe)
                                                                        .Where(sppe => sppe.IDSP == IDSP_N)
                                                                        .ToList();

                                                foreach (PMDS.db.Entities.SPPE sppe_sp in tblSPPE_N)
                                                {
                                                    List<PMDS.db.Entities.PflegeEintrag> tblPflegeEintrag_N = (from pe in db.PflegeEintrag
                                                                                                                select pe)
                                                                                    .Where(pe => pe.ID == sppe_sp.IDPflegeEintrag)
                                                                                    .OrderBy(pe => pe.Zeitpunkt)
                                                                                    .ToList();
                                                    AddNodes(tblPflegeEintrag_N, nNotfallSP, "MaßnahmeMeldung", false);
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
                                    DatenexportLog(RTFLog, "XML-Export: Verordnungen exportieren");
                                    List<PMDS.db.Entities.VO> tblVOs = db.VO.Where(vos => vos.IDAufenthalt == rAufenthalt.ID)
                                        .OrderBy(vos => vos.DatumVerordnetAb)
                                        .ToList();
                                    int mVOs = AddNodes(tblVOs, nVerordnungen, "Verordnung", true);

                                    for (int iVO = 0; iVO < mVOs; iVO++)
                                    {
                                        nVO = nVerordnungen.GetChild(iVO);
                                        Guid IDVerordnung = new Guid(nVO.GetAttrValue("ID"));

                                        List<PMDS.db.Entities.VO_Bestelldaten> tblVOBestelldaten = db.VO_Bestelldaten
                                                    .Where(vobest => vobest.IDVerordnung == IDVerordnung)
                                                    .OrderBy(vobest => vobest.GueltigAb)
                                                    .ToList();
                                        int mBestelldaten = AddNodes(tblVOBestelldaten, nVO, "VO_Bestelldaten", false);

                                        for (int iBestelldaten = 0; iBestelldaten < mBestelldaten; iBestelldaten++)
                                        {
                                            nVOBestelldaten = nVO.GetNthChildWithTag("VO_Bestelldaten", iBestelldaten);
                                            Guid IDBestelldaten = new Guid(nVOBestelldaten.GetAttrValue("ID"));
                                            List<PMDS.db.Entities.VO_Bestellpostitionen> tblVOBestellpositionen = db.VO_Bestellpostitionen
                                                .Where(vobestpos => vobestpos.IDBestelldaten_VO == IDBestelldaten)
                                                .OrderBy(vobestpos => vobestpos.DatumBestellung)
                                                .ToList();

                                            AddNodes(tblVOBestellpositionen, nVOBestelldaten, "VO_Bestellposition", false);
                                        }

                                        List<PMDS.db.Entities.VO_Lager> tblVOLager = db.VO_Lager
                                                    .Where(volag => volag.IDVO == IDVerordnung)
                                                    .OrderBy(volag => volag.Seriennummer)
                                                    .ToList();
                                        AddNodes(tblVOLager, nVO, "VO_Lager", false);

                                        List<PMDS.db.Entities.VO_MedizinischeDaten> tblVoMedizinischeDaten = db.VO_MedizinischeDaten
                                                                        .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                        .OrderBy(vomed => vomed.DatumErstellt)
                                                                        .ToList();
                                        AddNodes(tblVoMedizinischeDaten, nVO, "VO_MedizinischeDaten", false);

                                        List<PMDS.db.Entities.VO_Wunde> tblVoWunden = db.VO_Wunde
                                                                        .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                        .OrderBy(vomed => vomed.DatumErstellt)
                                                                        .ToList();
                                        AddNodes(tblVoWunden, nVO, "VO_Wunde", false);

                                        List<PMDS.db.Entities.VO_PflegeplanPDX> tblVoPflegeplanPdx = db.VO_PflegeplanPDX
                                                                .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                .ToList();
                                        AddNodes(tblVoPflegeplanPdx, nVO, "VO_PflegeplanPDX", false);

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
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.Export: " + ex.ToString());
            }
            finally
            {
                nExportInfo?.Dispose();
                nKliniken?.Dispose(); 
                nAbteilungen?.Dispose();
                nBereiche?.Dispose();
                nAuswahlListenGruppen?.Dispose();
                nAuswahlListen?.Dispose();
                nDienstzeiten?.Dispose();
                nEinrichtungen?.Dispose();
                nFormulare?.Dispose();
                nMedizinischeTypen?.Dispose();
                nStandardzeiten?.Dispose();
                nZeitbereiche?.Dispose();
                nBenutzer?.Dispose();
                nAerzte?.Dispose();
                nKontaktpersonen?.Dispose();
                nPatientAerzte?.Dispose();
                nSachwalters?.Dispose();
                nAnamnesenKrohwinkel?.Dispose();
                nAnamnesenOrem?.Dispose();
                nAnamnesenPOP?.Dispose();
                nRehabilitationen?.Dispose();
                nArztabrechnungen?.Dispose();
                nPflegeStufen?.Dispose();
                nPatientBemerkungen?.Dispose();
                nMedizinischeDaten?.Dispose();
                nBiografien?.Dispose();
                nPlaene?.Dispose();
                nArchiv?.Dispose();
                nAufenthalte?.Dispose();
                nAufenthalt?.Dispose();
                nGegenstaende?.Dispose();
                nHilfsmitteln?.Dispose();
                nAbwesenheiten?.Dispose();
                nUnterbringungen?.Dispose();
                nVersetzungen?.Dispose();
                nPDX?.Dispose();
                nAetiologien?.Dispose();
                nSymptome?.Dispose();
                nRessourcen?.Dispose();
                nZiele?.Dispose();
                nZiel?.Dispose();
                nPPZielEvaluierungen?.Dispose();
                nMassnahmen?.Dispose();
                nTermine?.Dispose();
                nPflegeplaeneH?.Dispose();
                nPE_NONE?.Dispose();
                nPE_DEKURS?.Dispose();
                nPE_MASSNAHME?.Dispose();
                nPE_UNEXP_MASSNAHME?.Dispose();
                nPE_TERMIN?.Dispose();
                nPE_MEDIKAMENT?.Dispose();
                nPE_NOTFALL?.Dispose();
                nPE_PLANUNG?.Dispose();
                nPE_WUNDE?.Dispose();
                nPE_KLIENT?.Dispose();
                nPE_ASSESSMENT?.Dispose();
                nPE_VERORDNUNGEN?.Dispose();
                nPE_WUNDVERLAUF?.Dispose();
                nPE_WUNDTHERAPIE?.Dispose();
                nPDX_Wunde?.Dispose();
                nAetiologienWunde?.Dispose();
                nWundeZielEvaluierungen?.Dispose();
                nZieleWunde?.Dispose();
                nZielWunde?.Dispose();
                nMassnahmenWunde?.Dispose();
                nPDXWunde?.Dispose();
                nWunde?.Dispose();
                nWundeTherapien?.Dispose();
                nWundeVerlauefe?.Dispose();
                nWundeBilder?.Dispose();
                nRezepteintraege?.Dispose();
                nRezepteintrag?.Dispose();
                nMedikamentenAbgaben?.Dispose();
                nRezeptbestellungen?.Dispose();
                nStandardProzedur?.Dispose();
                nStandardprozedurSP?.Dispose();
                nStandardprozedurSPPos?.Dispose();
                nNotfallprozeduren?.Dispose();
                nNotfallProzedur?.Dispose();
                nNotfallSP?.Dispose();
                nNotfallSPPos?.Dispose();
                nVO?.Dispose();
                nVOBestelldaten?.Dispose();
                nChild?.Dispose();
                xml?.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
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

        private static bool ByteArrayToFile(string fileName, byte[] byteArray)
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

        private static bool StringToFile(string fileName, string Content)
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

        private void ExportFDF(Guid ID, string FormularName, DateTime Datumerstellt, Byte[] fdfBlop, string PathKlientenFormulare, string KlientNameGebDat)
        {
            try
            {
                string ExportName = Path.Combine(PathKlientenFormulare, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(FormularName) + "_" + Datumerstellt.ToString("yyyyMMddHHmmss") + ".pdf");
                PMDS.db.Entities.Formular pdf = db.Formular.Where(f => f.ID == ID).FirstOrDefault();
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

        private int AddDetailNode<T>(List<T> tbl, Chilkat.Xml nParent, string ChildName)
        {
            try
            {
                int i = 0;
#if EXPORTDETAILS
                foreach (var row in tbl)
                {
                    nChild = nParent.NewChild(ChildName, "AnzahlDetails=" + tbl.Count.ToString()); ;
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
                                && !generic.sEquals(vprop.Name, "BLOP", Enums.eCompareMode.Contains)
                            )
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
                    }
                }
#endif
                return i;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DatenExportXMLBAL.DatenExportXML.AddDetailNode: " + ex.ToString());
            }
        }

        private int AddNodes<T>(List<T> tbl, Chilkat.Xml nParent, string ChildName, bool AutoAssignSubNodes)
        {
            try
            {
                int i = 0;
                foreach (var row in tbl)
                {                  
                    nChild = nParent.NewChild(ChildName, "Anzahl=" + tbl.Count.ToString());
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
                            
                            if (row.GetType().GetProperty(vprop.Name).GetValue(row, null) != null)
                            {
                                nChild.AddAttribute(vprop.Name, row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                            }
                            else
                            {
                                nChild.AddAttribute(vprop.Name, "");
                            }                            
                        }

                        if (AutoAssignSubNodes && row.GetType().GetProperty(vprop.Name).GetValue(row, null) != null)
                        {
                            if (generic.sEquals(vprop.Name, "IDKLINIK"))
                            {
                                Guid IDKlinik = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Klinik> tblKlinik = db.Klinik.Where(a => a.ID == IDKlinik).ToList();
                                AddDetailNode(tblKlinik, nChild, "Klinik");
                            }

                            else if (generic.sEquals(vprop.Name, "IDABTEILUNG")) //IDAbteilung_Von, IDAbteilung_Nach
                            {
                                Guid IDAbteilung = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Abteilung> tblAbteilung = db.Abteilung.Where(a => a.ID == IDAbteilung).ToList();
                                AddDetailNode(tblAbteilung, nChild, "Abteilung");
                            }

                            else if (generic.sEquals(vprop.Name, "IDBEREICH"))  
                            {
                                Guid IDBereich = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Bereich> tblBereich = db.Bereich.Where(a => a.ID == IDBereich).ToList();
                                AddDetailNode(tblBereich, nChild, "Bereich");
                            }

                            //Adressen
                            else if (generic.sEquals(vprop.Name, "IDADRESSE") || generic.sEquals(vprop.Name, "IDADRESSESUB"))
                            {
                                Guid IDAdresse = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Adresse> tblAdressen = db.Adresse.Where(a => a.ID == IDAdresse).ToList();
                                AddDetailNode(tblAdressen, nChild, vprop.Name);
                            }

                            //Kontakte
                            else if (generic.sEquals(vprop.Name, "IDKONTAKT") || generic.sEquals(vprop.Name, "IDKONTAKTSUB"))
                            {
                                Guid IDKontakt = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Kontakt> tblKontakte = db.Kontakt.Where(a => a.ID == IDKontakt).ToList();
                                AddDetailNode(tblKontakte, nChild, vprop.Name);
                            }

                            else if (generic.sEquals(vprop.Name, "IDBANK"))
                            {
                                Guid IDBank = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Bank> tblBanken = db.Bank.Where(a => a.ID == IDBank).ToList();
                                AddDetailNode(tblBanken, nChild, "Bank");
                            }

                            //Details zu den Benutzern NICHT zu jedem Node hinzufügen. ID reicht, man kann im Benutzernode nach der ID suchen.
                            //Benutzer
                            //if (generic.sEquals(vprop.Name, "IDBENUTZER"))
                            //{
                            //    Guid IDBenutzer = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                            //    List<PMDS.db.Entities.Benutzer> tblUsers = tblBenutzer.Where(a => a.ID == IDBenutzer).ToList();
                            //    AddNodes(tblUsers, nChild, vprop.Name, false);
                            //}

                            //if (BenutzerFieldnames.TryGetValue(vprop.Name.ToUpper(), out string NodeText))
                            //{
                            //    Guid IDBenutzer = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                            //    List<PMDS.db.Entities.Benutzer> tblUsers = tblBenutzer.Where(a => a.ID == IDBenutzer).ToList();
                            //    AddNodes(tblUsers, nChild, NodeText, false);
                            //}

                            //Pflegegeldstufen
                            else if (generic.sEquals(vprop.Name, "IDPFLEGEGELDSTUFE") || generic.sEquals(vprop.Name, "IDPFLEGEGELDSTUFEANTRAG"))
                            {
                                Guid IDPflegegeldStufe = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Pflegegeldstufe> tblPflegegeldStufen = db.Pflegegeldstufe.Where(a => a.ID == IDPflegegeldStufe).ToList();
                                AddDetailNode(tblPflegegeldStufen, nChild, vprop.Name);
                            }

                            else if (generic.sEquals(vprop.Name, "IDPLAN"))
                            {
                                Guid IDPlan = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.plan> tblPlaene = db.plan.Where(a => a.ID == IDPlan).ToList();
                                AddDetailNode(tblPlaene, nChild, "Plan");
                            }

                            else if (generic.sEquals(vprop.Name, "IDPDX"))
                            {
                                Guid IDPDX = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.PDX> tblPDXs = db.PDX.Where(a => a.ID == IDPDX).ToList();
                                AddDetailNode(tblPDXs, nChild, "PDX");
                            }

                            else if (generic.sEquals(vprop.Name, "IDMEDIKAMENT"))
                            {
                                Guid IDMedikament = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.Medikament> tblMedikamente = db.Medikament.Where(med => med.ID == IDMedikament).ToList();
                                AddDetailNode(tblMedikamente, nChild, "Medikament_Heilbehelf");
                            }

                            else if (generic.sEquals(vprop.Name, "IDMEDIZINISCHEDATEN"))
                            {
                                Guid IDMedDaten = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.MedizinischeDaten> tblMedDaten = db.MedizinischeDaten.Where(med => med.ID == IDMedDaten).ToList();
                                AddDetailNode(tblMedDaten, nChild, "MedizinischeDaten");
                            }

                            else if (generic.sEquals(vprop.Name, "IDWUNDEKOPF"))
                            {
                                Guid IDWundeKopf = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                                List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(med => med.ID == IDWundeKopf).ToList();
                                AddDetailNode(tblWundeKopf, nChild, "WundeKopf");
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
