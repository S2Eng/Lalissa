
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;


using System.Xml;

namespace PMDS.GUI
{
    public class DatenExportXML : IDisposable
    {
        private IntPtr? _pointer = IntPtr.Zero;
        private IList<IDisposable> _disposableObjects = new List<IDisposable>();
        private bool disposedValue;

        private static int iFlush = 200;
        private static PMDS.db.Entities.ERModellPMDSEntities db;
        private static string FileNameXMLDocumentBackTmp = "";
        private static XmlWriter writer;        

        private class cSubNodeInfo
        {
            public string Name = "";
            public Guid ID = Guid.Empty;
        }

        private static List<object> lSubNodeNames = new List<object>() { "IDKLINIK", "IDABTEILUNG", "IDBEREICH", "IDADRESSE", "IDADRESSESUB", "IDKONTAKT", "IDKONTAKTSUB",
                                                                  "IDBANK", "IDPFLEGEGELDSTUFE", "IDPFLEGEGELDSTUFEANTRAG", "IDPLAN", "IDPDX", "IDMEDIKAMENT",
                                                                  "IDMEDIZINISCHEDATEN", "IDWUNDEKOPF"};

        public DatenExportXML()
        {

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in _disposableObjects)
                    {
                        item?.Dispose();
                    }
                }

                // release _pointer
                _pointer = null;

                disposedValue = true;
            }
        }

        private enum eDataTable
        {
            Kliniken = 1,
            Abteilung = 2,
            Bereich = 3,
            Adresse = 4,
            Kontakt = 5
        }

        private class PatientenfotoDTO
        {
            public Guid ID { get; set; }
            public byte[] Foto { get; set; }
        }

        private class AufenthaltDTO
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

        private static List<PMDS.db.Entities.Benutzer> tblBenutzer = new List<db.Entities.Benutzer>();
        private static List<PMDS.db.Entities.Klinik> tblKliniken = new List<db.Entities.Klinik>();
        private static List<PMDS.db.Entities.Abteilung> tblAbteilungen = new List<db.Entities.Abteilung>();
        private static List<PMDS.db.Entities.Bereich> tblBereiche = new List<db.Entities.Bereich>();



        private static void DatenexportLog(PMDS.GUI.ucRichTextBox RTFLog, string Txt)
        {
            RTFLog.Text += "\n" + DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss ") + Txt;
            System.Windows.Forms.Application.DoEvents();
        }

        //public bool Export(System.Guid IDPatient, string ArchivPath, out string FileNameXMLDocumentBack)
        public bool Export(System.Guid IDPatient, string ArchivPath, out string FileNameXMLDocumentBack, ref PMDS.GUI.ucRichTextBox RTFLog)
        {
            FileNameXMLDocumentBack = "";
            _disposableObjects.Add(writer);
            _disposableObjects.Add(db);

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
                    tblBenutzer = (from ben in db.Benutzer select ben)
                                    .OrderBy(e => e.Nachname)
                                    .ToList();

                    tblKliniken = (from kli in db.Klinik select kli)
                                    .OrderBy(e => e.Bezeichnung)
                                    .ToList();

                    tblAbteilungen = (from abt in db.Abteilung select abt)
                                    .OrderBy(e => e.Bezeichnung)
                                    .ToList();

                    tblBereiche = (from ber in db.Bereich select ber)
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


                    //Test für XML-Writer

                    var sts = new XmlWriterSettings()
                    {
                        Indent = true,
                        Encoding = System.Text.Encoding.UTF8,
                        ConformanceLevel = ConformanceLevel.Fragment,
                    };

                    writer = XmlWriter.Create(FileNameXMLDocumentBack, sts);
                    //writer.WriteStartDocument();

                    writer.WriteStartElement("DatenExport");
                    writer.WriteStartElement("ExportInfo");
                    writer.WriteAttributeString("BeginnExport", dNow.ToString());
                    writer.WriteAttributeString("DBVersion", db.DBVersion.First().ScriptVersion);
                    writer.Flush();
                    writer.WriteEndElement();   //ExportInfo

                    if (dOpt.AllgemeineStammdaten)
                    {
                        DatenexportLog(RTFLog, "XML-Export: Allgemeine Stammdaten erstellen");
                        //----------------- Allgemeine Stammdaten ---------------- 

                        writer.WriteStartElement("Allgemeine_Stammdaten");

                        writer.WriteStartElement("Kliniken");
                        XMLAddNodes(tblKliniken, "Klinik", true);
                        writer.Flush();
                        writer.WriteEndElement();   //Kliniken                       

                        //List<Abteilung> tblAbteilungen = db.Abteilung.ToList();
                        writer.WriteStartElement("Abteilungen");
                        XMLAddNodes(tblAbteilungen, "Abteilung", true);
                        writer.Flush();
                        writer.WriteEndElement();

                        //List<Bereich> tblBereiche = db.Bereich.ToList();
                        writer.WriteStartElement("Bereiche");
                        XMLAddNodes(tblBereiche,  "Bereich", true);
                        writer.Flush();
                        writer.WriteEndElement();

                        List<PMDS.db.Entities.AuswahlListeGruppe> tblAuswahlListenGruppen = db.AuswahlListeGruppe.ToList();
                        writer.WriteStartElement("AuswahlListenGruppen");
                        XMLAddNodes(tblAuswahlListenGruppen, "AuswahlListenGruppe", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblAuswahlListenGruppen = null;

                        List<PMDS.db.Entities.AuswahlListe> tblAuswahlListen = db.AuswahlListe.OrderBy(l => l.IDAuswahlListeGruppe).ToList();
                        writer.WriteStartElement("AuswahlListen");
                        XMLAddNodes(tblAuswahlListen,  "AuswahlListe", true);
                        writer.Flush();
                        writer.WriteEndElement();
  //                      tblAuswahlListen = null;

                        List<PMDS.db.Entities.Dienstzeiten> tblDienstzeiten = db.Dienstzeiten.ToList();
                        writer.WriteStartElement("Dienstzeiten");
                        XMLAddNodes(tblDienstzeiten, "Dienstzeit", false);
                        writer.Flush();
                        writer.WriteEndElement();
    //                    tblDienstzeiten = null;

                        List<PMDS.db.Entities.Einrichtung> tblEinrichtungen = db.Einrichtung.ToList();
                        writer.WriteStartElement("Einrichtungen");
                        XMLAddNodes(tblEinrichtungen, "Einrichtung", true);
                        writer.Flush();
                        writer.WriteEndElement();
                        //tblEinrichtungen = null;

                        var tblFormulare = (from frm in db.Formular
                                            select new { frm.ID, frm.Name, frm.Bezeichnung, frm.GUI, frm.InNotfallAnzeigenJN, frm.NeuanlageSperren, frm.lstIDBerufsgruppe}).ToList();
                        writer.WriteStartElement("Formulare");
                        XMLAddNodes(tblFormulare, "Formular", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblFormulare = null;

                        var tblFormulareExport = (from frm in db.Formular
                                            select new { frm.Name, frm.PDF_BLOP })
                                            .Where(frm => frm.PDF_BLOP != null).ToList();

                        //Formulare als PDF auf die Platte schreiben
                        foreach (var rFormular in tblFormulareExport)
                        {
                            string ExportName = Path.Combine(PathKlientenFormulare, Path.GetFileNameWithoutExtension(rFormular.Name) + ".pdf");
                            File.WriteAllBytes(ExportName, rFormular.PDF_BLOP);
                        }
//                        tblFormulareExport = null;

                        List<PMDS.db.Entities.Massnahmenserien> tblMassnahmenserien = db.Massnahmenserien.ToList();
                        writer.WriteStartElement("Maßnahmenserien");
                        XMLAddNodes(tblMassnahmenserien,  "Maßnahmenserie", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblMassnahmenserien = null;

                        List<PMDS.db.Entities.MedizinischeTypen> tblMedizinischeTypen = db.MedizinischeTypen.ToList();
                        writer.WriteStartElement("MedizinischeTypen");
                        XMLAddNodes(tblMedizinischeTypen, "MedizinischerTyp", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblMedizinischeTypen = null;

                        List<PMDS.db.Entities.Standardzeiten> tblStandardzeiten = db.Standardzeiten.ToList();
                        writer.WriteStartElement("Standardzeiten");
                        XMLAddNodes(tblStandardzeiten, "Standardzeit", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblStandardzeiten = null;

                        List<PMDS.db.Entities.Zeitbereich> tblZeitbereiche = db.Zeitbereich.ToList();
                        writer.WriteStartElement("Zeitbereiche");
                        XMLAddNodes(tblZeitbereiche, "Zeitbereich", false);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblZeitbereiche = null;

                        writer.WriteStartElement("BenutzerListe");
                        XMLAddNodes(tblBenutzer, "Benutzer", true);
                        writer.Flush();
                        writer.WriteEndElement();

                        List<PMDS.db.Entities.Aerzte> tblAerzte = (from ae in db.Aerzte
                                                                    join pae in db.PatientAerzte on ae.ID equals pae.IDAerzte
                                                                    where
                                                                    pae.IDPatient == patDto.ID
                                                                    select ae)
                                                        .OrderBy(ae => ae.Nachname)
                                                        .OrderBy(ae => ae.Vorname)
                                                        .ToList();
                        writer.WriteStartElement("Ärzte");
                        XMLAddNodes(tblAerzte, "Arzt", true);
                        writer.Flush();
                        writer.WriteEndElement();
//                        tblAerzte = null;

                        //Pflegemodelle = nicht erforderlich
                        //nAbrechnungStammdaten = xml.NewChild("Abrechnungsbezogene_Stammdaten", "");
                        //var tblKostentraeger = db.Kostentraeger.ToList();
                        //nKostentraegers = nAbrechnungStammdaten.NewChild("Kostentraeger", "");
                        //AddNodes(tblKostentraeger, nKostentraegers, "Kostentraeger", db, true);
                        //Leistungskatalog, LeistungskatalogGueltig, Pflegegeldstufe, PflegegeldstufeGueltig, Sonderleistungskatalog, Taschengeld
                        //Pflegegeldstufe, PflegegeldstufeGueltig
                        writer.Flush();
                        writer.WriteEndElement();   //Allgemeine Stammdaten
                    }


                    // ----------------- Klient ----------------------------
                    DatenexportLog(RTFLog, "XML-Export: Klientendaten erstellen");

                    List<PMDS.db.Entities.Patient> tblKlienten = db.Patient.Where(p => p.ID == patDto.ID).ToList();
                    XMLAddNodes(tblKlienten, "Klient", true, false);

                    List<PatientenfotoDTO> PatientBild = (from p in db.Patient
                                                            where p.ID == patDto.ID
                                                            select new PatientenfotoDTO { ID = p.ID, Foto = p.Foto }).ToList();
                    if (PatientBild.FirstOrDefault().Foto != null)
                        ByteArrayToFile(Path.Combine(PathKlientenBild, KlientNameGebDat + ".jpg"), (Byte[])PatientBild.FirstOrDefault().Foto);
//                    PatientBild = null;

                    List<PMDS.db.Entities.Kontaktperson> tblKontaktpersonen = db.Kontaktperson.Where(kp => kp.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("Kontaktpersonen");
                    XMLAddNodes(tblKontaktpersonen, "Kontaktperson", true);
                    writer.WriteEndElement();
//                    tblKontaktpersonen = null;

                    List<PMDS.db.Entities.PatientAerzte> tblPatientAerzte = db.PatientAerzte.Where(a => a.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("Ärzte");
                    XMLAddNodes(tblPatientAerzte, "Arzt", true);
                    writer.WriteEndElement();
//                    tblPatientAerzte = null;

                    List<PMDS.db.Entities.Sachwalter> tblSachwalters = db.Sachwalter.Where(sw => sw.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("Erwachsenenvertreter_Vorsorgebevollmächtigte");
                    XMLAddNodes(tblSachwalters, "Erwachsenenvertreter_Vorsorgebevollmächtigter", true);
                    writer.WriteEndElement();
//                    tblSachwalters = null;

                    List<PMDS.db.Entities.Anamnese_Krohwinkel> tblAnamnesenKrohwinkel = db.Anamnese_Krohwinkel.Where(anak => anak.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("AnamnesenKrohwinkel");
                    XMLAddNodes(tblAnamnesenKrohwinkel, "AnamneseKrohwinkel", true);
                    writer.WriteEndElement();
//                    tblAnamnesenKrohwinkel = null;

                    List<PMDS.db.Entities.Anamnese_Orem> tblAnamnesenOrem = db.Anamnese_Orem.Where(anao => anao.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("AnamnesenOrem");
                    XMLAddNodes(tblAnamnesenOrem, "AnamneseOrem", true);
                    writer.WriteEndElement();
//                    tblAnamnesenOrem = null;

                    List<PMDS.db.Entities.Anamnese_POP> tblAnamnesenPOP = db.Anamnese_POP.Where(anap => anap.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("AnamnesenPOP");
                    XMLAddNodes(tblAnamnesenPOP, "AnamnesePOP", true);
                    writer.WriteEndElement();
//                    tblAnamnesenPOP = null;

                    List<PMDS.db.Entities.Rehabilitation> tblRehabilitationen = db.Rehabilitation.Where(reha => reha.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("Rehabilitationen");
                    XMLAddNodes(tblRehabilitationen, "Rehabilitation", true);
                    writer.WriteEndElement();
//                    tblRehabilitationen = null;

                    List<PMDS.db.Entities.Arztabrechnung> tblArztabrechnungen = db.Arztabrechnung.Where(aa => aa.IDPatient == patDto.ID).OrderBy(aa => aa.Datum).ToList();
                    writer.WriteStartElement("Arztabrechnungen");
                    XMLAddNodes(tblArztabrechnungen, "Arztabrechnung", true);
                    writer.WriteEndElement();
//                    tblArztabrechnungen = null;

                    List<PMDS.db.Entities.PatientPflegestufe> tblPflegeStufen = db.PatientPflegestufe.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.GueltigAb).ToList();
                    writer.WriteStartElement("PflegeStufen");
                    XMLAddNodes(tblPflegeStufen, "PflegeStufe", true);
                    writer.WriteEndElement();
//                    tblPflegeStufen = null;

                    List<PMDS.db.Entities.PatientenBemerkung> tblPatientBemerkungen = db.PatientenBemerkung.Where(pbem => pbem.IDPatient == patDto.ID).ToList();
                    writer.WriteStartElement("PatientBemerkungen");
                    XMLAddNodes(tblPatientBemerkungen, "PatientBemerkung", true);
                    writer.WriteEndElement();
//                    tblPatientBemerkungen = null;

                    List<PMDS.db.Entities.MedizinischeDaten> tblMedizinischeDaten = db.MedizinischeDaten.Where(ps => ps.IDPatient == patDto.ID).OrderBy(ps => ps.Typ).OrderBy(ps => ps.Von).ToList();
                    writer.WriteStartElement("MedizinischeDaten");
                    XMLAddNodes(tblMedizinischeDaten, "MedizinischesDatum", true);
                    writer.WriteEndElement();
//                    tblMedizinischeDaten = null;

                    List<PMDS.db.Entities.FormularDaten> tblFormularDaten = db.FormularDaten.Where(fd => fd.IDREF == patDto.ID && fd.PDF_BLOP != null).OrderBy(fd => fd.FormularName).OrderBy(fd => fd.Datumerstellt).ToList();
                    writer.WriteStartElement("Formulardaten");
                    XMLAddNodes(tblFormularDaten, "Formular", true);
                    foreach (var fd in tblFormularDaten)
                    {
                        ExportFDF(StripSpecialCharacters(fd.FormularName), fd.Datumerstellt, fd.PDF_BLOP, PathKlientenFormulare, KlientNameGebDat);
                    }
                    writer.WriteEndElement();
//                    tblFormularDaten = null;

                    List<PMDS.db.Entities.FormularDaten> tblBiografien = db.FormularDaten.Where(bio => bio.IDREF == patDto.ID && bio.PDF_BLOP == null && (bio.BLOP.ToString().StartsWith(@"{\rtf1"))).OrderBy(az => az.FormularName).OrderBy(az => az.Datumerstellt).ToList();
                    writer.WriteStartElement("Biografien");
                    XMLAddNodes(tblBiografien, "Biografie", true);
                    foreach (var fd in tblBiografien)
                    {
                        string FileNameWundeBild = System.IO.Path.Combine(PathKlientenBiografien, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(StripSpecialCharacters(fd.FormularName)) + "_" + fd.Datumerstellt.ToString("yyyyMMddHHmmss") + "_" + fd.ID.ToString() + ".rtf");
                        StringToFile(FileNameWundeBild, fd.BLOP);
                    }
                    writer.WriteEndElement();
//                    tblFormularDaten = null;

                    DatenexportLog(RTFLog, "XML-Export: Termine exportieren");
                    //Kliententermine
                    List<PMDS.db.Entities.planObject> tblPlaene = db.planObject.Where(plan => plan.IDObject == patDto.ID).OrderBy(plan => plan.Status).ToList();
                    writer.WriteStartElement("Kliententermine_Pläne");
                    XMLAddNodes(tblPlaene, "Kliententermin_Plan", true);
                    writer.WriteEndElement();
//                    tblPlaene = null;

                    DatenexportLog(RTFLog, "XML-Export: Klientenarchiv exportieren");
                    //Archiv
                    List<PMDS.db.Entities.tblDokumente> tblArchiv = (from dok in db.tblDokumente
                                                        join dokein in db.tblDokumenteintrag on dok.IDDokumenteintrag equals dokein.ID
                                                        join obj in db.tblObjekt on dokein.ID equals obj.IDDokumenteintrag
                                                        where obj.ID_guid == patDto.ID
                                                        select dok)
                                            .OrderBy(dok => dok.ErstelltAm)
                                            .ToList();
                    writer.WriteStartElement("Archiveinträge");
                    XMLAddNodes(tblArchiv, "Archiveintrag", true);
                    writer.WriteEndElement();

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
//                    tblArchiv = null;

                    //Abrechungsdaten - checken, ob wir die brauchen (eher nein, Buchhaltung muss sich ohnehin die Rechnungen aufheben. Das reicht.)
                    //bills, billHeader, Bookings, PatientAbwesenheit, PatientLeistungsplan, PatientEinkommen, PatientKostentraeger,
                    //PatientSonderleistung, PatientTaschengeldKostentraeger

                    //---------------------- Aufenthalte ---------------------------------------------------------------------------

                    writer.WriteStartElement("Aufenthalte"); 

                    List<AufenthaltDTO> tAufenthalte = (from Aufenthalte in db.Aufenthalt
                                                            where Aufenthalte.IDPatient == patDto.ID
                                                            select new AufenthaltDTO { ID = Aufenthalte.ID, Aufnahmezeitpunkt = (DateTime)Aufenthalte.Aufnahmezeitpunkt })
                                            .OrderBy(o => o.Aufnahmezeitpunkt).ToList();

                    foreach (var rAufenthalt in tAufenthalte)
                    {
                        List<PMDS.db.Entities.Aufenthalt> tblAufenthalt = db.Aufenthalt.Where(a => a.ID == rAufenthalt.ID).OrderBy(a => a.Aufnahmezeitpunkt).ToList();
                        XMLAddNodes(tblAufenthalt, "Aufenthalt", true, false);
//                        tblAufenthalt = null;

                        //Aufenthaltsdaten -------------------------
                        DatenexportLog(RTFLog, "XML-Export: Aufenthaltsdaten exportieren (" + rAufenthalt.Aufnahmezeitpunkt.ToString("yyyy-MM-dd HH:mm:ss"));
                        List<PMDS.db.Entities.AufenthaltZusatz> tblAufenthaltzusatz = db.AufenthaltZusatz.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                        writer.WriteStartElement("Aufenthaltszusätze");
                        XMLAddNodes(tblAufenthaltzusatz, "Aufenthaltzusatz", true);
                        writer.WriteEndElement();
//                        tblAufenthaltzusatz = null;

                        List<PMDS.db.Entities.Gegenstaende> tblGegestaende = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == false).ToList();
                        writer.WriteStartElement("Gegenstände");
                        XMLAddNodes(tblGegestaende, "Gegenstand", true);
                        writer.WriteEndElement();
//                        tblGegestaende = null;

                        List<PMDS.db.Entities.Gegenstaende> tblHilfsmittel = db.Gegenstaende.Where(az => az.IDAufenthalt == rAufenthalt.ID && az.HilfesmittelJN == true).ToList();
                        writer.WriteStartElement("HilfsmittelListe");
                        XMLAddNodes(tblHilfsmittel, "Hilfsmittel", true);
                        writer.WriteEndElement();
//                        tblHilfsmittel = null;

                        List<PMDS.db.Entities.Unterbringung> tblUnterbringungen = db.Unterbringung.Where(az => az.IDAufenthalt == rAufenthalt.ID).ToList();
                        writer.WriteStartElement("HAG_Meldungen");
                        XMLAddNodes(tblUnterbringungen, "HAG_Meldung", true);
                        writer.WriteEndElement();
//                        tblUnterbringungen = null;

                        List<PMDS.db.Entities.UrlaubVerlauf> tblUrlaubVerlauf = db.UrlaubVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.StartDatum).ToList();
                        writer.WriteStartElement("Abwesenheiten");
                        XMLAddNodes(tblUrlaubVerlauf, "Abwesenheit", true);
                        writer.WriteEndElement();
//                        tblUrlaubVerlauf = null;

                        List<PMDS.db.Entities.AufenthaltVerlauf> tblAufenthaltVerlauf = db.AufenthaltVerlauf.Where(az => az.IDAufenthalt == rAufenthalt.ID).OrderBy(az => az.Datum).ToList();
                        writer.WriteStartElement("AufenthaltsverlaufListe");
                        XMLAddNodes(tblAufenthaltVerlauf, "Aufenthaltsverlauf", true);
                        writer.WriteEndElement();
//                        tblAufenthaltVerlauf = null;

                        //Pflegeplan --------------------
                        if (dOpt.Pflegeplan)
                        {
                            DatenexportLog(RTFLog, "XML-Export: Pflegeplan exportieren");
                            writer.WriteStartElement("Pflegeplan");

                            List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltePDXsPP = db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == false).ToList();
                            foreach (var AufenthaltePDXsPP in tblAufenthaltePDXsPP)
                            {
                                List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsPP = new List<db.Entities.AufenthaltPDx>();       //jede Aufenthalt-PDX in eine Liste umwandeln für Parameterübergabe
                                tblAufenthaltPDXsPP.Add(AufenthaltePDXsPP);

                                XMLAddNodes(tblAufenthaltPDXsPP, "Aufenthalt_PDX", false, false);

                                Guid IDAufenthaltPDX = tblAufenthaltPDXsPP[0].ID;
                                Guid IDPDX = (Guid)tblAufenthaltPDXsPP[0].IDPDX;
//                                tblAufenthaltPDXsPP = null;

                                List<PMDS.db.Entities.PDX> tblPDX = db.PDX.Where(pdx => pdx.ID == IDPDX).ToList();
                                XMLAddNodes(tblPDX, "PDX", true, false);
//                                tblPDX = null;

                                List<PMDS.db.Entities.PflegePlan> tblAetiologien = (from pp in db.PflegePlan
                                                                                        join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                        join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                        join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                        where
                                                                                            pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                            (pp.EintragGruppe == "A") &&
                                                                                            pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                            apdx.ID == IDAufenthaltPDX &&
                                                                                            pdx.ID == IDPDX
                                                                                        select pp)
                                            .OrderBy(apdx => apdx.ErledigtJN)
                                            .OrderBy(ppdx => ppdx.ErledigtJN)
                                            .OrderBy(pp => pp.StartDatum)
                                            .ToList();
                                writer.WriteStartElement("Ätiologien_Risikofaktoren");
                                XMLAddNodes(tblAetiologien, "Ätiologie_Risikofaktor", false);
                                writer.WriteEndElement();
//                                tblAetiologien = null;

                                List<PMDS.db.Entities.PflegePlan> tblSymptome = (from pp in db.PflegePlan
                                                                                    join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                    join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                    join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                    where
                                                                                        pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                        (pp.EintragGruppe == "S") &&
                                                                                        pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                        apdx.ID == IDAufenthaltPDX &&
                                                                                        pdx.ID == IDPDX
                                                                                    select pp).OrderBy(apdx => apdx.ErledigtJN)
                                            .OrderBy(ppdx => ppdx.ErledigtJN)
                                            .OrderBy(pp => pp.StartDatum)
                                            .ToList();
                                writer.WriteStartElement("Symptome");
                                XMLAddNodes(tblSymptome, "Symptom", false);
                                writer.WriteEndElement();
//                                tblSymptome = null;

                                //List<PMDS.db.Entities.PflegePlan> tblRessourcen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "R").ToList();
                                List<PMDS.db.Entities.PflegePlan> tblRessourcen = (from pp in db.PflegePlan
                                                                                    join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                    join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                    join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                    where
                                                                                        pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                        (pp.EintragGruppe == "R") &&
                                                                                        pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                        apdx.ID == IDAufenthaltPDX &&
                                                                                        pdx.ID == IDPDX
                                                                                    select pp).OrderBy(apdx => apdx.ErledigtJN)
                                                .OrderBy(ppdx => ppdx.ErledigtJN)
                                                .OrderBy(pp => pp.StartDatum)
                                                .ToList();
                                writer.WriteStartElement("Ressourcen");
                                XMLAddNodes(tblRessourcen, "Ressource", false);
                                writer.WriteEndElement();
//                                tblRessourcen = null;

                                //List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                List<PMDS.db.Entities.PflegePlan> tblZiele = (from pp in db.PflegePlan
                                                                                    join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                    join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                    join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                    where
                                                                                        pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                        (pp.EintragGruppe == "Z") &&
                                                                                        pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                        apdx.ID == IDAufenthaltPDX &&
                                                                                        pdx.ID == IDPDX
                                                                                    select pp).OrderBy(apdx => apdx.ErledigtJN)
                                                .OrderBy(ppdx => ppdx.ErledigtJN)
                                                .OrderBy(pp => pp.StartDatum)
                                                .ToList();
                                writer.WriteStartElement("Ziele");
                                if (tblZiele.Count > 0)
                                {
                                    foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                    {
                                        List<PMDS.db.Entities.PflegePlan> tblZiel = new List<db.Entities.PflegePlan> { rZiel };
                                        XMLAddNodes(tblZiel, "Ziel", false, false);

                                        //Evaluierungen zu Ziel
                                        List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                        if (tblEvaluierungen.Count > 0)
                                        {
                                            foreach (var Eval in tblEvaluierungen)
                                            {
                                                List<PMDS.db.Entities.PflegeEintrag> tblEvaluierung = new List<db.Entities.PflegeEintrag>();
                                                tblEvaluierung.Add(Eval);
                                                XMLAddNodes(tblEvaluierung, "EvaluierungPflegeplan", false);
                                            }
                                        }
                                        writer.WriteEndElement();   //Ziel
                                    }
                                }
                                writer.WriteEndElement();   //Ziele

                                //List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                List<PMDS.db.Entities.PflegePlan> tblMassnahmen = (from pp in db.PflegePlan
                                                                                join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                where
                                                                                    pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                    (pp.EintragGruppe == "M") &&
                                                                                    pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                    apdx.ID == IDAufenthaltPDX &&
                                                                                    pdx.ID == IDPDX
                                                                                select pp).OrderBy(apdx => apdx.ErledigtJN)
                                                .OrderBy(ppdx => ppdx.ErledigtJN)
                                                .OrderBy(pp => pp.StartDatum)
                                                .ToList();
                                writer.WriteStartElement("Maßnahmen");
                                XMLAddNodes(tblMassnahmen, "Maßnahme", false);
                                writer.WriteEndElement();   //Maßnahme
//                                tblMassnahmen = null;

                                writer.WriteEndElement();       //PDX
                                writer.WriteEndElement();   // Aufenthalt_PDX
                            }

                            DatenexportLog(RTFLog, "XML-Export: Pflegeplantermine exportieren");
                            //List<PMDS.db.Entities.PflegePlan> tblTermine = db.PflegePlan.Where(pp => pp.IDAufenthalt == rAufenthalt.ID && pp.EintragGruppe == "T").OrderBy(pp => pp.StartDatum).ToList();
                            List<PMDS.db.Entities.PflegePlan> tblTermine = (from pp in db.PflegePlan
                                                                               where
                                                                                   pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                   (pp.EintragGruppe == "T")
                                                                               select pp).OrderBy(apdx => apdx.ErledigtJN)
                                                    .OrderBy(pp => pp.StartDatum)
                                                    .ToList();
                            writer.WriteStartElement("Termine");
                            XMLAddNodes(tblTermine, "Termin", true);
                            writer.WriteEndElement();   // Termine
//                            tblTermine = null;

                            DatenexportLog(RTFLog, "XML-Export: Pflegeplanhistorie exportieren");
                            List<PMDS.db.Entities.PflegePlanH> tblPflegeplanH = (from pph in db.PflegePlanH
                                                                                 join e in db.Eintrag on pph.IDEintrag equals e.ID
                                                                                 select pph)
                                                                .Where(pp => pp.IDAufenthalt == rAufenthalt.ID)
                                                                .OrderBy(e => e.Text)
                                                                .OrderBy(pp => pp.DatumErstellt)
                                                                .ToList();
                            writer.WriteStartElement("PflegepläneHistorie");
                            XMLAddNodes(tblPflegeplanH, "PflegeplanHistorie", true);
                            writer.WriteEndElement();   // Pflegplanhistorie
//                            tblPflegeplanH = null;

                            writer.WriteEndElement();       //Pflegeplan
                        }

                        //---------------- Dokumentation -----------------------------------------------------
                        if (dOpt.PflegeDokumentation)
                        {
                            int iTake = 1000;

                            DatenexportLog(RTFLog, "XML-Export: Pflegedokumentation exportieren");
                            writer.WriteStartElement("Pflegedokumentation");

                            //List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp != 2).ToList();
                            List<db.Entities.PflegeEintrag> lMaßnahmen = new List<db.Entities.PflegeEintrag>();
                            List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = new List<db.Entities.PflegeEintrag>();

                            writer.WriteStartElement("Ohne_Klassifizierungen");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == -1).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Ohne_Klassifizierung", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Dekurse");
                            int cntRec = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 0).Count();
                            for (int iSkip = 0; iSkip <= cntRec; iSkip += iTake)
                            {
                                lMaßnahmen = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 0).OrderBy(s => s.DatumErstellt).Skip(iSkip).Take(iTake).ToList();
                                XMLAddNodes(lMaßnahmen, "Doku_Dekurs", false);
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("Maßnahmen");
                            cntRec = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 1).Count();
                            for (int iSkip = 0; iSkip <= cntRec; iSkip+=iTake)
                            {
                                lMaßnahmen = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 1).OrderBy(s => s.DatumErstellt).Skip(iSkip).Take(iTake).ToList();
                                XMLAddNodes(lMaßnahmen, "Doku_Maßnahme", false);
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("Ungeplante_Maßnahmen");
                            cntRec = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 3).Count();
                            for (int iSkip = 0; iSkip <= cntRec; iSkip += iTake)
                            {
                                lMaßnahmen = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 3).OrderBy(s => s.DatumErstellt).Skip(iSkip).Take(iTake).ToList();
                                XMLAddNodes(lMaßnahmen, "Doku_Ungeplante_Maßnahme", false);
                            }
                            writer.WriteEndElement();
                            writer.Flush();

                            writer.WriteStartElement("Termine");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 4).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Termin", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Medikamente");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 5).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Medikament", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Notfälle");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 6).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Notfall", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Planungen");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 7).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Planung", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Wunden");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 8).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Wunde", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Klientendaten");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 9).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Klient", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Assessments");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 10).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Assessment", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Verordnungen");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 11).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Verordnung", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Wundverläufe");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 12).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Wundverlauf", false);
                            writer.WriteEndElement();

                            writer.WriteStartElement("Wundtherapien");
                            tblPflegeeintraege = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.EintragsTyp == 13).ToList();
                            XMLAddNodes(tblPflegeeintraege, "Doku_Wundtherapie", false);
                            writer.WriteEndElement();

                            writer.WriteEndElement();       //Pflegedokumentation
//                            tblPflegeeintraege = null;

                        }

                        if (dOpt.WundDokumentation)
                        {
                            //--------------Wunden  ---------------------------------------------------
                            DatenexportLog(RTFLog, "XML-Export: Wunddoku exportieren");
                            writer.WriteStartElement("Wunddokumentation");
                            List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsWs= db.AufenthaltPDx.Where(apdx => apdx.IDAufenthalt == rAufenthalt.ID && apdx.wundejn == true).ToList();
                            foreach (var AufenthaltePDXsW in tblAufenthaltPDXsWs)
                            {
                                List<PMDS.db.Entities.AufenthaltPDx> tblAufenthaltPDXsW = new List<db.Entities.AufenthaltPDx>() { AufenthaltePDXsW };     //jede Aufenthalt-PDX in eine Liste umwandeln für Parameterübergabe

                                XMLAddNodes(tblAufenthaltPDXsW, "Aufenthalt_PDX_Wunde", false, false);

                                Guid IDAufenthaltPDXW = tblAufenthaltPDXsW[0].ID;
                                Guid IDPDXW = (Guid)tblAufenthaltPDXsW[0].IDPDX;

                                List<PMDS.db.Entities.PDX> tblPDX = db.PDX.Where(pdx => pdx.ID == IDPDXW).ToList();
                                XMLAddNodes(tblPDX, "PDX_Wunde", true, false);

                                List<PMDS.db.Entities.PflegePlan> tblPflegeplaene = (from pp in db.PflegePlan
                                                                                     join ppdx in db.PflegePlanPDx on pp.ID equals ppdx.IDPflegePlan
                                                                                     join pdx in db.PDX on ppdx.IDPDX equals pdx.ID
                                                                                     join apdx in db.AufenthaltPDx on ppdx.IDAufenthaltPDx equals apdx.ID
                                                                                     where
                                                                                         pp.IDAufenthalt == rAufenthalt.ID &&
                                                                                         (pp.EintragGruppe == "A" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                                                         pp.IDUntertaegigeGruppe == ppdx.IDUntertaegigeGruppe &&
                                                                                         apdx.ID == IDAufenthaltPDXW &&
                                                                                         pdx.ID == IDPDXW
                                                                                     select pp)
                                                             .OrderBy(apdx => apdx.ErledigtJN)
                                                             .OrderBy(ppdx => ppdx.ErledigtJN)
                                                             .OrderBy(pp => pp.StartDatum)
                                                             .ToList();
                                if (tblPflegeplaene.Any())
                                {
                                    List<PMDS.db.Entities.PflegePlan> tblAetiologien = tblPflegeplaene.Where(pp => pp.EintragGruppe == "A").ToList();
                                    writer.WriteStartElement("BeeinflussendeFaktoren");
                                    XMLAddNodes(tblAetiologien, "BeeinflussenderFaktor", false);
                                    writer.WriteEndElement();

                                    List<PMDS.db.Entities.PflegePlan> tblZiele = tblPflegeplaene.Where(pp => pp.EintragGruppe == "Z").ToList();
                                    writer.WriteStartElement("Ziele");
                                    if (tblZiele.Count > 0)
                                    {
                                        foreach (PMDS.db.Entities.PflegePlan rZiel in tblZiele)
                                        {
                                            List<PMDS.db.Entities.PflegePlan> tblZiel = new List<db.Entities.PflegePlan> { rZiel };
                                            XMLAddNodes(tblZiel, "Ziel", false, false);

                                            //Evaluierungen zu Ziel
                                            List<PMDS.db.Entities.PflegeEintrag> tblEvaluierungen = db.PflegeEintrag.Where(pe => pe.EintragsTyp == 2 && pe.IDPflegePlan == rZiel.ID).OrderBy(pe => pe.DatumErstellt).ToList();
                                            if (tblEvaluierungen.Count > 0)
                                            {
                                                foreach (var Eval in tblEvaluierungen)
                                                {
                                                    List<PMDS.db.Entities.PflegeEintrag> tblEvaluierung = new List<db.Entities.PflegeEintrag>();
                                                    tblEvaluierung.Add(Eval);
                                                    XMLAddNodes(tblEvaluierung, "EvaluierungWunde", false);
                                                }
                                            }
                                            writer.WriteEndElement();   //Ziel
                                        }
                                    }
                                    writer.WriteEndElement();   //Ziele

                                    List<PMDS.db.Entities.PflegePlan> tblMassnahmen = tblPflegeplaene.Where(pp => pp.EintragGruppe == "M").ToList();
                                    writer.WriteStartElement("Maßnahmen");
                                    XMLAddNodes(tblMassnahmen, "Maßnahme", false);
                                    writer.WriteEndElement();   //Maßnahme

                                    List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(wk => wk.IDAufenthaltPDx == IDAufenthaltPDXW).ToList();
                                    if (tblWundeKopf.Count == 1)
                                    {
                                        XMLAddNodes(tblWundeKopf, "Wunde", false, false);
                                        Guid IDWundeKopf = new Guid(tblWundeKopf[0].ID.ToString());

                                        List<PMDS.db.Entities.WundeTherapie> tblWundeTherapie = db.WundeTherapie.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wt => wt.DatumErstellt).ToList();
                                        writer.WriteStartElement("Wundetherapien");
                                        XMLAddNodes(tblWundeTherapie, "Wundtherapie", false);
                                        writer.WriteEndElement();
//                                        tblWundeTherapie = null;

                                        List<PMDS.db.Entities.WundePos> tblWundeVerlaufe = db.WundePos.Where(wv => wv.IDWundeKopf == IDWundeKopf).OrderBy(wv => wv.DatumErstellt).ToList();
                                        writer.WriteStartElement("Wundeverläufe");
                                        XMLAddNodes(tblWundeVerlaufe, "Wundverlauf", false);
                                        writer.WriteEndElement();
//                                        tblWundeVerlaufe = null;

                                        var tblWundePosBilder = (from wb in db.WundePosBilder
                                                                 join wp in db.WundePos on wb.IDWundePos equals wp.ID
                                                                 where wp.IDWundeKopf == IDWundeKopf
                                                                 select new { wb.ID, wb.IDWundePos, wb.Reihenfolge, wb.druckenJN, wb.Beschreibung, wb.ZeitpunktBild, wb.IDBenutzer_Erstellt, wb.IDBenutzer_Geaendert,
                                                                    wb.DatumErstellt, wb.DatumGeaendert })
                                                                .OrderBy(wb => wb.ZeitpunktBild)
                                                                .ToList();
                                        writer.WriteStartElement("Wundbilder");
                                        XMLAddNodes(tblWundePosBilder, "Wundbild", false);
                                        writer.WriteEndElement();   //Wundbild
//                                        tblWundePosBilder = null;

                                        writer.WriteEndElement();   //WundeKopf

                                        var tblWundePosBilderExport = (from wb in db.WundePosBilder
                                                                 join wp in db.WundePos on wb.IDWundePos equals wp.ID
                                                                 where wp.IDWundeKopf == IDWundeKopf
                                                                 select new
                                                                 {
                                                                     ID = (Guid) wb.ID,
                                                                     ZeitpunktBild = (DateTime) wb.ZeitpunktBild,
                                                                     wb.Bild
                                                                 })
                                                                .OrderBy(wb => wb.ZeitpunktBild)
                                                                .ToList();
                                        //Bilder auf Platte speichern
                                        foreach (var wb in tblWundePosBilderExport)
                                        {
                                            if (wb.Bild != null)
                                            {
                                                string FileNameWundeBild = System.IO.Path.Combine(PathWundeBilder, KlientNameGebDat + "_Wundbild_" + wb.ZeitpunktBild.ToString("yyyyMMddHHmmss") + "_" + wb.ID.ToString() + ".jpg");
                                                ByteArrayToFile(FileNameWundeBild, wb.Bild);
                                            }
                                            else
                                            {
                                                string FileNameWundeBild = System.IO.Path.Combine(PathWundeBilder, KlientNameGebDat + "_Wundbild_" + wb.ZeitpunktBild.ToString("yyyyMMddHHmmss") + "_" + wb.ID.ToString() + ".txt");
                                                File.WriteAllText(FileNameWundeBild, "Keine Bildinfotmation gefunden.");
                                            }
                                        }
//                                        tblWundePosBilderExport = null;
                                    }
                                }
                                writer.WriteEndElement();       //PDX_Wunde
                                writer.WriteEndElement();   // Aufenthalt_PDX_Wunde
                            }
                            writer.WriteEndElement();       //Wunddokumentation
                        }

                        if (dOpt.Medikamente)
                        {
                            //-------------- Medikamente ---------------------------------------------------
                            DatenexportLog(RTFLog, "XML-Export: Medikation exportieren");
                            writer.WriteStartElement("Medikamente");

                            //Daten auf einmal lesen
                            List<PMDS.db.Entities.Medikament> tblMedikamenteAll = (from medikamente in db.Medikament
                                                                                   join re in db.RezeptEintrag on medikamente.ID equals re.IDMedikament
                                                                                   where re.IDAufenthalt == rAufenthalt.ID
                                                                                   select medikamente)
                                                        .ToList();

                            List<PMDS.db.Entities.Medikament> tblMedikamente = new List<db.Entities.Medikament>();
                            foreach (var med in tblMedikamenteAll)
                            {
                                if (!tblMedikamente.Where(m => m.ID == med.ID).Any())
                                {
                                    tblMedikamente.Add(med);
                                }
                            }
//                            tblMedikamenteAll = null;

                            List<PMDS.db.Entities.RezeptEintrag> tblRezepteintraege = (from re in db.RezeptEintrag
                                                                                       where re.IDAufenthalt == rAufenthalt.ID
                                                                                       select re)
                                                        .OrderBy(re => re.AbzugebenVon)
                                                        .ToList();



                            List<PMDS.db.Entities.RezeptBestellungPos> tblRezeptBestellungen = (from re in db.RezeptEintrag
                                                                                                join rebest in db.RezeptBestellungPos on re.ID equals rebest.IDRezeptEintrag
                                                                                                where re.IDAufenthalt == rAufenthalt.ID
                                                                                                select rebest)
                                                        .OrderBy(rebest => rebest.RezeptAnforderungDatum)
                                                        .ToList();

                            foreach (var Medikament in tblMedikamente)
                            {
                                List<PMDS.db.Entities.Medikament> tblMedikament = new List<db.Entities.Medikament>() { Medikament };
                                XMLAddNodes(tblMedikament, "Medikament", false, false);

                                List<PMDS.db.Entities.RezeptEintrag> tblRezeptEintraege = (from re in tblRezepteintraege
                                                                                           where re.IDMedikament == Medikament.ID
                                                                                           select re).ToList();

                                foreach (var re in tblRezeptEintraege)
                                {
                                    List<PMDS.db.Entities.RezeptEintrag> tblRezeptEintrag = new List<db.Entities.RezeptEintrag>() { re };
                                    XMLAddNodes(tblRezeptEintrag, "Rezepteintrag", false, false);
                                    writer.WriteStartElement("Medikmentenabgaben");                     //Können zig-tausend sein. Daher pro Medikament und in 500er-Tranchen. 

                                    int cntRec = (from reEin in db.RezeptEintrag
                                                  join medab in db.MedikationAbgabe on reEin.ID equals medab.IDRezeptEintrag
                                                  where re.IDAufenthalt == rAufenthalt.ID
                                                  select medab)
                                                .Where(medab => medab.IDRezeptEintrag == re.ID)
                                                .OrderBy(medab => medab.Zeitpunkt).Count();

                                    int iTake = 500;
                                    for (int iSkip = 0; iSkip <= cntRec; iSkip += iTake)
                                    {
                                        List<PMDS.db.Entities.MedikationAbgabe> tblMedAbgaben = (from reEin in db.RezeptEintrag
                                                                                                 join medab in db.MedikationAbgabe on reEin.ID equals medab.IDRezeptEintrag
                                                                                                 where re.IDAufenthalt == rAufenthalt.ID
                                                                                                 select medab)
                                                                                                 .Where(medab => medab.IDRezeptEintrag == re.ID)
                                                                                                 .OrderBy(medab => medab.Zeitpunkt)
                                                                                                 .Skip(iSkip).Take(iTake)
                                                                                                 .ToList();
                                        XMLAddNodes(tblMedAbgaben, "Medikamentenabgabe", false);
//                                        tblMedAbgaben = null;
                                    }
                                    writer.WriteEndElement();

                                    List<PMDS.db.Entities.RezeptBestellungPos> tblRezBest = (from rezbest in tblRezeptBestellungen
                                                                                             where rezbest.IDRezeptEintrag == re.ID
                                                                                             select rezbest).ToList();
                                    writer.WriteStartElement("Rezeptbestellungen");
                                    XMLAddNodes(tblRezBest, "Rezeptbestellung", false);
                                    writer.WriteEndElement();       //Rezeptbestellungen

                                    writer.WriteEndElement();       //Rezepteintrag
                                }
                                writer.WriteEndElement();       //Medikament
                            }
                            writer.WriteEndElement();       //Medikamente
                        }

                        //--------------- Stsnadardprozeduren und Notfälle
                        if (dOpt.Standardprozeduren)
                        {
                            //Standardprozeduren
                            DatenexportLog(RTFLog, "XML-Export: Standardprozeduren und Notfälle exportieren");

                            List<PMDS.db.Entities.SP> tblSPs = (from sproz in db.StandardProzeduren
                                                                join sp in db.SP on sproz.ID equals sp.IDStandardProzeduren
                                                                where sp.IDAufenthalt == rAufenthalt.ID && sproz.NotfallJN == false
                                                                select sp)
                                                            .Distinct()
                                                            .OrderBy(sp => sp.Zeitpunkt)
                                                            .ToList();

                            List<PMDS.db.Entities.SP> tblNFs = (from sproz in db.StandardProzeduren
                                                                                      join sp in db.SP on sproz.ID equals sp.IDStandardProzeduren
                                                                                      where sp.IDAufenthalt == rAufenthalt.ID && sproz.NotfallJN == true
                                                                                      select sp)
                                                            .Distinct()
                                                            .OrderBy(sp => sp.Zeitpunkt)
                                                            .ToList();

                            writer.WriteStartElement("Standardprozeduren");
                            foreach (var SP in tblSPs)
                            {
                                List<PMDS.db.Entities.SP> tblSP = new List<db.Entities.SP>() { SP };
                                XMLAddNodes(tblSP, "Standardprozedur", true, false);

                                List<PMDS.db.Entities.StandardProzeduren> tblStandardprozedur = (from standardprozedur in db.StandardProzeduren
                                                                                                 where standardprozedur.ID == SP.IDStandardProzeduren
                                                                                                 select standardprozedur)
                                                                                                 .ToList();
                                XMLAddNodes(tblStandardprozedur, "Standardprozedur_Info", false);

                                List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = (from pe in db.PflegeEintrag
                                                                                           join sppe in db.SPPE on pe.ID equals sppe.IDPflegeEintrag
                                                                                           join sp in db.SP on sppe.IDSP equals sp.ID
                                                                                           where sp.ID == SP.ID
                                                                                           select pe)
                                                                                          .ToList();
                                XMLAddNodes(tblPflegeeintraege, "Pflegeeintrag", false);
                                writer.WriteEndElement();   //Standardprozedur                            
                            }
                            writer.WriteEndElement();       //Standardprozeduren


                            //Notfälle
                            writer.WriteStartElement("Notfälle");
                            foreach (var NF in tblNFs)
                            {
                                List<PMDS.db.Entities.SP> tblNF = new List<db.Entities.SP>() { NF };
                                XMLAddNodes(tblNF, "Notfall", true, false);

                                List<PMDS.db.Entities.StandardProzeduren> tblStandardprozedur = (from standardprozedur in db.StandardProzeduren
                                                                                                 where standardprozedur.ID == NF.IDStandardProzeduren
                                                                                                 select standardprozedur)
                                                                                                .ToList();
                                XMLAddNodes(tblStandardprozedur, "Notfall_Info", false);

                                List<PMDS.db.Entities.PflegeEintrag> tblPflegeeintraege = (from pe in db.PflegeEintrag
                                                                                           join sppe in db.SPPE on pe.ID equals sppe.IDPflegeEintrag
                                                                                           join sp in db.SP on sppe.IDSP equals sp.ID
                                                                                           where sp.ID == NF.ID
                                                                                           select pe)
                                                                                          .ToList();
                                XMLAddNodes(tblPflegeeintraege, "Pflegeeintrag", false);
                                writer.WriteEndElement();   //Notfall                            
                            }
                            writer.WriteEndElement();       //Notfälle
                        }


                        //--------------- Verordnungen
                        if (dOpt.Verordnungen)
                        {
                            DatenexportLog(RTFLog, "XML-Export: Verordnungen exportieren");
                            writer.WriteStartElement("Verordnungen");

                            List<PMDS.db.Entities.VO> tblVOs = db.VO.Where(vos => vos.IDAufenthalt == rAufenthalt.ID)
                                .OrderBy(vos => vos.DatumVerordnetAb)
                                .ToList();

                            int iVO = XMLAddNodes(tblVOs, "Verordnung", true, false);

                            foreach (var VO in tblVOs)
                            {
                                Guid IDVerordnung = VO.ID;

                                List<PMDS.db.Entities.VO_Bestelldaten> tblVOBestelldaten = db.VO_Bestelldaten
                                            .Where(vobest => vobest.IDVerordnung == IDVerordnung)
                                            .OrderBy(vobest => vobest.GueltigAb)
                                            .ToList();
                                foreach (var VOBestelldatum in tblVOBestelldaten)
                                {
                                    List<PMDS.db.Entities.VO_Bestelldaten> tblVOBestelldatum = new List<db.Entities.VO_Bestelldaten>() { VOBestelldatum };
                                    XMLAddNodes(tblVOBestelldatum, "VO_Bestelldaten", false, false);
                                    Guid IDBestelldaten = VOBestelldatum.ID;
                                    List<PMDS.db.Entities.VO_Bestellpostitionen> tblVOBestellpositionen = db.VO_Bestellpostitionen
                                        .Where(vobestpos => vobestpos.IDBestelldaten_VO == IDBestelldaten)
                                        .OrderBy(vobestpos => vobestpos.DatumBestellung)
                                        .ToList();

                                    XMLAddNodes(tblVOBestellpositionen, "VO_Bestellposition", false);
                                    writer.WriteEndElement();   //VO_Bestelldaten
                                }

                                List<PMDS.db.Entities.VO_Lager> tblVOLager = db.VO_Lager
                                            .Where(volag => volag.IDVO == IDVerordnung)
                                            .OrderBy(volag => volag.Seriennummer)
                                            .ToList();
                                XMLAddNodes(tblVOLager, "VO_Lager", false);

                                List<PMDS.db.Entities.VO_MedizinischeDaten> tblVoMedizinischeDaten = db.VO_MedizinischeDaten
                                                                .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                .OrderBy(vomed => vomed.DatumErstellt)
                                                                .ToList();
                                XMLAddNodes(tblVoMedizinischeDaten, "VO_MedizinischeDaten", false);

                                List<PMDS.db.Entities.VO_Wunde> tblVoWunden = db.VO_Wunde
                                                                .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                                .OrderBy(vomed => vomed.DatumErstellt)
                                                                .ToList();
                                XMLAddNodes(tblVoWunden, "VO_Wunde", false);

                                List<PMDS.db.Entities.VO_PflegeplanPDX> tblVoPflegeplanPdx = db.VO_PflegeplanPDX
                                                        .Where(vomed => vomed.IDVerordnung == IDVerordnung)
                                                        .ToList();
                                XMLAddNodes(tblVoPflegeplanPdx, "VO_PflegeplanPDX", false);
                            }
                            if (iVO > 0) 
                                writer.WriteEndElement();       //Verordnung
                            writer.WriteEndElement();       //Verordnungen
                        }

                        writer.WriteEndElement();   //Aufenthalt
                    }
                    writer.WriteEndElement(); //Aufenthalte
                    writer.WriteEndElement();   //Klient
                    writer.WriteEndElement();   //DatenExport

                    //writer.WriteEndDocument();
                    writer.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatenExportXML.Export: " + ex.ToString());
            }
            finally
            {
                writer?.Dispose();
            }
        }

        //private bool SaveXML()
        //{
        //    try
        //    {
        //        xml.SaveXml(FileNameXMLDocumentBackTmp);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("DatenExportXML.SaveXML: " + ex.ToString());
        //    }
        //}

        private static string StripSpecialCharacters(string s)
        {
            try
            {
                return Regex.Replace(s, @"[^0-9a-zA-Z.äöüÄÖÜß]\\", string.Empty);

            }
            catch (Exception ex)
            {
                throw new Exception("DatenExportXML.StripSpecialCharacters: " + ex.ToString());
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
                throw new Exception("DatenExportXML.ByteArrayToFile: " + ex.ToString());
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
                throw new Exception("DatenExportXML.StringToFile: " + ex.ToString());
            }
        }

        private static void ExportFDF(string FormularName, DateTime Datumerstellt, Byte[] fdfBlop, string PathKlientenFormulare, string KlientNameGebDat)
        {
            try
            {
                string ExportName = Path.Combine(PathKlientenFormulare, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(FormularName) + "_" + Datumerstellt.ToString("yyyyMMddHHmmss") + ".fdf");
                PMDS.db.Entities.Formular pdf = db.Formular.Where(f => f.Name == FormularName).FirstOrDefault();
                if (fdfBlop != null)
                {
                    File.WriteAllBytes(ExportName, fdfBlop);
                }
                else   //Wenn das Formular nicht mehr in der Datenbank ist, den FDF-Wert speichern
                {
                    ExportName = Path.Combine(PathKlientenFormulare, KlientNameGebDat + "_" + Path.GetFileNameWithoutExtension(FormularName) + "_" + Datumerstellt.ToString("yyyyMMddHHmmss") + ".txt");
                    File.WriteAllText(ExportName, "Keine FDF-Daten gefunden");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatenExportXML.ExportFDF: " + ex.ToString());
            }
        }

        private static int XMLAddDetailNode<T>(List<T> tbl, string ChildName)
        {
            try
            {
                int i = 0;
                foreach (var row in tbl)
                {                    
                    writer.WriteStartElement(ChildName.Replace(" ", "_"));
                    i++;

                    PropertyInfo[] properties = row.GetType().GetProperties();

                    foreach (PropertyInfo vprop in properties)
                    {
                        Type vpropPropertyType = vprop.PropertyType;
                        string pName = vprop.Name;
                        if (//vprop.CanWrite &&
                                (
                                    vpropPropertyType == typeof(string) ||
                                    vpropPropertyType == typeof(bool) ||
                                    vpropPropertyType == typeof(Guid) ||
                                    vpropPropertyType == typeof(short) ||
                                    vpropPropertyType == typeof(int) ||
                                    vpropPropertyType == typeof(long) ||
                                    vpropPropertyType == typeof(DateTime) ||
                                    vpropPropertyType == typeof(TimeSpan) ||
                                    vpropPropertyType == typeof(decimal) ||
                                    vpropPropertyType == typeof(double) ||
                                    vpropPropertyType == typeof(float) ||
                                    vpropPropertyType == typeof(char) ||
                                    vpropPropertyType == typeof(byte) ||
                                    vpropPropertyType == typeof(byte[]) ||
                                    vpropPropertyType == typeof(sbyte) ||

                                    vpropPropertyType == typeof(Nullable<bool>) ||
                                    vpropPropertyType == typeof(Nullable<Guid>) ||
                                    vpropPropertyType == typeof(Nullable<DateTime>) ||
                                    vpropPropertyType == typeof(Nullable<TimeSpan>) ||
                                    vpropPropertyType == typeof(Nullable<byte>) ||
                                    vpropPropertyType == typeof(Nullable<sbyte>)
                                )
                                && !generic.sEquals(pName, "RTF", Enums.eCompareMode.Contains)
                                && !generic.sEquals(pName, "BLOP", Enums.eCompareMode.Contains)
                            )
                        {
                            object o = row.GetType().GetProperty(pName).GetValue(row, null);
                            if (o != null)
                            {
                                string pValue = o.ToString();
                                writer.WriteAttributeString(pName, pValue);
                            }
                            else
                            {
                                writer.WriteAttributeString(pName, "");
                            }
//                            o = null;
                        }
                    }
//                    properties = null;
                    writer.WriteEndElement();
                }
                return i;
            }
            catch (Exception ex)
            {
                throw new Exception("DatenExportXML.AddDetailNode: " + ex.ToString());
            }
        }


        private static int XMLAddNodes<T>(List<T> tbl, string ChildName, bool AutoAssignSubNodes, bool AutoCloseNode = true)
        {
            try
            {
                int i = 0;

                List<cSubNodeInfo> lSubNodeInfos = new List<cSubNodeInfo>();                //Hält die Liste der Detailnodes, die erst nach den Attributes geschrieben werden dürfen

                foreach (var row in tbl)
                {
                    lSubNodeInfos = new List<cSubNodeInfo>();                //Hält die Liste der Detailnodes, die erst nach den Attributes geschrieben werden dürfen
                    writer.WriteStartElement(ChildName.Replace(" ", "_"));
                    i++;

                    PropertyInfo[] properties = row.GetType().GetProperties();

                    foreach (PropertyInfo vprop in properties)
                    {

                        Type vpropPropertyType = vprop.PropertyType;
                        string pName = vprop.Name;

                        if (//vprop.CanWrite &&
                                (
                                    vpropPropertyType == typeof(string) ||
                                    vpropPropertyType == typeof(bool) ||
                                    vpropPropertyType == typeof(Guid) ||
                                    vpropPropertyType == typeof(short) ||
                                    vpropPropertyType == typeof(int) ||
                                    vpropPropertyType == typeof(long) ||
                                    vpropPropertyType == typeof(DateTime) ||
                                    vpropPropertyType == typeof(TimeSpan) ||
                                    vpropPropertyType == typeof(decimal) ||
                                    vpropPropertyType == typeof(double) ||
                                    vpropPropertyType == typeof(float) ||
                                    vpropPropertyType == typeof(char) ||
                                    vpropPropertyType == typeof(byte) ||
                                    vpropPropertyType == typeof(byte[]) ||
                                    vpropPropertyType == typeof(sbyte) ||

                                    vpropPropertyType == typeof(Nullable<bool>) ||
                                    vpropPropertyType == typeof(Nullable<Guid>) ||
                                    vpropPropertyType == typeof(Nullable<DateTime>) ||
                                    vpropPropertyType == typeof(Nullable<TimeSpan>) ||
                                    vpropPropertyType == typeof(Nullable<byte>) ||
                                    vpropPropertyType == typeof(Nullable<sbyte>)
                                )
                                && !generic.sEquals(pName, "RTF", Enums.eCompareMode.Contains)
                                && !generic.sEquals(pName, "BLOP", Enums.eCompareMode.Contains)
                            )
                        {
                            object o = row.GetType().GetProperty(pName).GetValue(row, null);
                            if (o != null)
                            {
                                string pValue = o.ToString().Trim();
                                writer.WriteAttributeString(pName, pValue);

                                if (AutoAssignSubNodes)
                                {
                                    if (generic.sEquals(vprop.Name, lSubNodeNames))
                                    {
                                        lSubNodeInfos.Add(new cSubNodeInfo() { Name = pName, ID = new Guid(pValue) } );     //Value muss ein Guid sein
                                    }
                                }
                            }
                            else
                            {
                                writer.WriteAttributeString(pName, "");
                            }
//                            o = null;                            
                        }                        
                    }

                    if (i % iFlush == 0)
                    {
                        //writer.Flush();
                    }
//                    properties = null;

                    //Subnodes schreiben
                    foreach (cSubNodeInfo SubNodeInfo in lSubNodeInfos)
                    {

                        string propName = SubNodeInfo.Name;
                            
                        if (generic.sEquals(propName, "IDKLINIK"))
                        {
                            List<PMDS.db.Entities.Klinik> tblKlinik = db.Klinik.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblKlinik, "Klinik");
//                            tblKlinik = null;
                        }

                        else if (generic.sEquals(propName, "IDABTEILUNG")) //IDAbteilung_Von, IDAbteilung_Nach
                        {
                            List<PMDS.db.Entities.Abteilung> tblAbteilung = db.Abteilung.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblAbteilung, "Abteilung");
//                            tblAbteilung = null;
                        }

                        else if (generic.sEquals(propName, "IDBEREICH"))
                        {
                            List<PMDS.db.Entities.Bereich> tblBereich = db.Bereich.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblBereich, "Bereich");
//                            tblBereich = null;
                        }

                        //Adressen
                        else if (generic.sEquals(propName, "IDADRESSE") || generic.sEquals(propName, "IDADRESSESUB"))
                        {
                            List<PMDS.db.Entities.Adresse> tblAdressen = db.Adresse.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblAdressen, SubNodeInfo.Name);
//                            tblAdressen = null;
                        }

                        //Kontakte
                        else if (generic.sEquals(propName, "IDKONTAKT") || generic.sEquals(propName, "IDKONTAKTSUB"))
                        {
                            List<PMDS.db.Entities.Kontakt> tblKontakte = db.Kontakt.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblKontakte, SubNodeInfo.Name);
//                            tblKontakte = null;
                        }

                        else if (generic.sEquals(propName, "IDBANK"))
                        {
                            List<PMDS.db.Entities.Bank> tblBanken = db.Bank.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblBanken, "Bank");
//                            tblBanken = null;
                        }

                        //Details zu den Benutzern NICHT zu jedem Node hinzufügen. ID reicht, man kann im Benutzernode nach der ID suchen.
                        //Benutzer
                        //if (generic.sEquals(propName, "IDBENUTZER"))
                        //{
                        //    Guid IDBenutzer = new Guid(row.GetType().GetProperty(propName).GetValue(row, null).ToString().Trim());
                        //    List<PMDS.db.Entities.Benutzer> tblUsers = tblBenutzer.Where(a => a.ID == IDBenutzer).ToList();
                        //    XMLAddNodes(tblUsers, propName, false);
                        //}

                        //if (BenutzerFieldnames.TryGetValue(vprop.Name.ToUpper(), out string NodeText))
                        //{
                        //    Guid IDBenutzer = new Guid(row.GetType().GetProperty(vprop.Name).GetValue(row, null).ToString().Trim());
                        //    List<PMDS.db.Entities.Benutzer> tblUsers = tblBenutzer.Where(a => a.ID == IDBenutzer).ToList();
                        //    AddNodes(tblUsers, nChild, NodeText, false);
                        //}

                        //Pflegegeldstufen
                        else if (generic.sEquals(propName, "IDPFLEGEGELDSTUFE") || generic.sEquals(propName, "IDPFLEGEGELDSTUFEANTRAG"))
                        {
                            List<PMDS.db.Entities.Pflegegeldstufe> tblPflegegeldStufen = db.Pflegegeldstufe.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblPflegegeldStufen, SubNodeInfo.Name);
//                            tblPflegegeldStufen = null;
                        }

                        else if (generic.sEquals(propName, "IDPLAN"))
                        {
                            List<PMDS.db.Entities.plan> tblPlaene = db.plan.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblPlaene, "Plan");
//                            tblPlaene = null;
                        }

                        else if (generic.sEquals(propName, "IDPDX"))
                        {
                            List<PMDS.db.Entities.PDX> tblPDXs = db.PDX.Where(a => a.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblPDXs, "PDX");
//                            tblPDXs = null;
                        }

                        else if (generic.sEquals(propName, "IDMEDIKAMENT"))
                        {
                            List<PMDS.db.Entities.Medikament> tblMedikamente = db.Medikament.Where(med => med.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblMedikamente, "Medikament_Heilbehelf");
//                            tblMedikamente = null;
                        }

                        else if (generic.sEquals(propName, "IDMEDIZINISCHEDATEN"))
                        {
                            List<PMDS.db.Entities.MedizinischeDaten> tblMedDaten = db.MedizinischeDaten.Where(med => med.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblMedDaten, "MedizinischeDaten");
//                            tblMedDaten = null;
                        }

                        else if (generic.sEquals(propName, "IDWUNDEKOPF"))
                        {
                            List<PMDS.db.Entities.WundeKopf> tblWundeKopf = db.WundeKopf.Where(med => med.ID == SubNodeInfo.ID).ToList();
                            XMLAddDetailNode(tblWundeKopf, "WundeKopf");
//                            tblWundeKopf = null;
                        }                        
                    }
                    if (AutoCloseNode)
                    {
                        writer.WriteEndElement();
                    }
                    writer.Flush();
                }
                return i;
            }
            catch (Exception ex)
            {
                throw new Exception("DatenExportXML.AddNode: " + ex.ToString());
            }
        }
    }
}
