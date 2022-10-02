using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.Global.UI.Befunde;
using System.Drawing;
using PMDS.DB;



namespace EDIFact
{

    public class EDIFact
    {

        public string TypeBefund = QS2.Desktop.ControlManagment.ControlManagment.getRes("Befunde") + "(*.bef)|*.bef| " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle Befundarten") + "(*.bef, *.pdf, *.dcm)|*.bef;*.pdf;*.dcm";
        //public string TypeBefund2 = "*.bef";
        public string TypeBefund2 = "*.*";
        
        public class cBefund
        {
            public string Dateiname = "";
            public string Verzeichnis = "";
            public Guid IDOrdnerArchiv = System.Guid.Empty;
            public string BezeichnungFile = "";
            public string DateiType = "";
            public long SizeDoku = 0;
            public Guid IDPatient = System.Guid.Empty;
            public string ArchivePath = "";
            public string sTextForPE = "";
            public PMDS.db.Entities.Patient rPatient = null;
            public PMDS.db.Entities.Aufenthalt rAktAufenthalt = null;

            public string ImportFile = "";
            public string txtEdiFactFile = "";          //Für EDIFACT-Daten
            public string txtEdiFactFilePrintable = "";

            public byte[] byteEdiFactFile;              //Für PDF-Files, einzelne DICOM-Files und erstes Image einer DICOM-Serie
            public byte[] byteDicomSeriesFile;          //Für DICOM-Studies (Zip aller zusammengehörender DICOM-Files)

            public bool IsDicomStudy = false;

            public bool VersionOk = false;

            public string SozVersNr = "";
            public Nullable<DateTime> GeburtsdatumPatient = null;
            public String MailBoxNr = "";
            public String NameAbsender = "";
            public String Absender = "";
            public DateTime DatumBefund = DateTime.MinValue;
            public String NamePatientAusBefundDatei = "";
            public String Version = "";

            public String BefundID = "";           //Eindeutige Befundkennung vom Absender
            public String BefundNummer = "";       //Laufende Befundnummer
            public String Hinweis = "";

            public string TrennzeichenImFeld = ":";
            public string TrennzeichenZwischenFeldern = "+";
            public string Dezimalzeichen = ".";
            public string Auflösungszeichen = "?";
        }
 
        public struct Befundliste
        {
            public string Absender;
            public string BefundID;
            public string BefundNummer;
            public cBefund Befund;
            public string BefundName;
            public string SozVersNummer;
        }

        public bool ReadBefunde(string FolderImport, string Archivordner, PMDS.Global.UI.Befunde.dsEDIFACT dsEDIFACT1,
                                        ref DateTime dNow, ref string protocol,
                                        ref PMDS.db.Entities.ERModellPMDSEntities db,ref int iCounterFilesImported, ref int iCounterFilesImportedError)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                
                if (!System.IO.Directory.Exists(FolderImport.Trim()))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Import-Verzeichnis '") + FolderImport.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                    return false;
                }

                string ErrorText = "";
                Nullable<Guid> IDOrdnerArchiv = null;
                if (!PMDSBusiness1.checkArchivordner(Archivordner, ref ErrorText, ref IDOrdnerArchiv))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ErrorText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                    return false;
                }

                string ArchivePath = "";
                if (!PMDSBusiness1.checkArchivePath(ref ArchivePath))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Archivpfad fürs Archivsystem angegeben", "Import Befunde", System.Windows.Forms.MessageBoxButtons.OK);
                    return false;
                }
                if (!System.IO.Directory.Exists(ArchivePath))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivpfad '") + ArchivePath .Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                    return false;
                }

                List<Befundliste> list = new List<Befundliste>();

                string[] FilesFound = Directory.GetFiles(FolderImport.Trim(), this.TypeBefund2);
                foreach (string FileFound in FilesFound)
                {
                    FileAttributes attributes = File.GetAttributes(FileFound);

                    if ((attributes & FileAttributes.Directory) != FileAttributes.Directory 
                        && (attributes & FileAttributes.Hidden) != FileAttributes.Hidden 
                        && (attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        cBefund NewBefund = ReadBefundFile(FileFound, false);
                        Befundliste structNewBefund = new Befundliste();
                        structNewBefund.Absender = NewBefund.MailBoxNr;             
                        structNewBefund.BefundID = NewBefund.BefundID;
                        structNewBefund.BefundNummer = NewBefund.BefundNummer;
                        structNewBefund.SozVersNummer = NewBefund.SozVersNr;
                        structNewBefund.Befund = NewBefund;
                        list.Add(structNewBefund);           
                    }
                }

                string[] DirectoriesFound = Directory.GetDirectories(FolderImport.Trim(), this.TypeBefund2);
                foreach (string DirectoryFound in DirectoriesFound)
                {
                    //Prüfen, ob eine DICOMDIR-Datei vorhanden ist. 

                    
                    string[] DICOMDIRFound = Directory.GetFiles(DirectoryFound, "DICOMDIR");
                    if (DICOMDIRFound.Length == 1)
                    {
                        string DICOMDIR = (System.IO.Path.Combine(DirectoryFound, "DICOMDIR"));
                        cBefund NewBefund = ReadBefundFile(DICOMDIR, true);
                        Befundliste structNewBefund = new Befundliste();
                        structNewBefund.Absender = NewBefund.MailBoxNr;
                        structNewBefund.BefundID = NewBefund.BefundID;
                        structNewBefund.BefundNummer = NewBefund.BefundNummer;
                        structNewBefund.SozVersNummer = NewBefund.SozVersNr;
                        structNewBefund.Befund = NewBefund;
                        list.Add(structNewBefund);

                        /*
                        System.IO.File.Delete(System.IO.Path.Combine(DirectoryFound, "DICOMDIR"));
                        string[] FilesNoExtensionFound = Directory.GetFiles(DirectoryFound, "*.");

                        foreach (string FileNoExtensionFound in FilesNoExtensionFound)   //.dcm anhängen
                        {
                            System.IO.File.Move(System.IO.Path.Combine(DirectoryFound, FileNoExtensionFound), System.IO.Path.Combine(DirectoryFound, FileNoExtensionFound + Settings.BefundTypText(eBefundTyp.DICOM)));
                        }
                        */
                    }

                    /*
                    FileAttributes attributes = File.GetAttributes(DirectoryFound);
                    if ((attributes & FileAttributes.Directory) == FileAttributes.Directory
                        && (attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                        && (attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        //Prüfen, ob eine DCM-Datei enthalten ist 
                        string[] DCMFilesFound = Directory.GetFiles(DirectoryFound, this.TypeBefund2);
                        foreach (string DCMFileFound in DCMFilesFound)
                        {
                            if (DICOMStructure == false)
                            {
                                cBefund NewBefund = ReadBefundFile(DCMFileFound, true);
                                Befundliste structNewBefund = new Befundliste();
                                structNewBefund.Absender = NewBefund.MailBoxNr;
                                structNewBefund.BefundID = NewBefund.BefundID;
                                structNewBefund.BefundNummer = NewBefund.BefundNummer;
                                structNewBefund.Befund = NewBefund;

                                if (System.IO.Path.GetExtension(DCMFileFound).Equals(Settings.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    list.Add(structNewBefund);
                                    DICOMStructure = true;
                                }
                            }
                        }
                    }
                    */
                }

                List<Befundliste> listSort = list.OrderBy(order=>order.Absender).ThenBy(order => order.SozVersNummer).ThenBy(order => order.BefundID).ThenByDescending(order => order.BefundNummer).ToList();

                string aktBefundID = "";
                string aktAbsender = "";
                string aktBefundSozVersNr = "";

                foreach (Befundliste bef in listSort)                    
                {
                    cBefund NewBefund = bef.Befund;

                    dsEDIFACT.EDIFACTRow rNewEdifact = (dsEDIFACT.EDIFACTRow)dsEDIFACT1.EDIFACT.NewRow();
                    rNewEdifact.NameBefund = NewBefund.BezeichnungFile;
                    rNewEdifact.Beschreibung = "";
                    rNewEdifact.obj = NewBefund;
                    rNewEdifact.ID = System.Guid.NewGuid();
                    rNewEdifact.Select = false;
                    rNewEdifact.LaborJN = false;
                    rNewEdifact.Hinweis = "";
                    rNewEdifact.Klient = "";
                    
                    NewBefund.IDOrdnerArchiv = (Guid)IDOrdnerArchiv;
                    NewBefund.ArchivePath = ArchivePath;
                    NewBefund.sTextForPE = NewBefund.BezeichnungFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" eingelesen");   //TxtReturned  -> BefundText pro Datei wenn gewünscht

                    if (NewBefund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase) ||
                        NewBefund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase))   //Hier können wir schon die Informationen prüfen, weil die Struktur vorhanden ist.
                    {
                        //Nur den ersten Befund einer BefundID einlesen (Rest aus Inbox löschen) 2014-07-24
                        if ((NewBefund.BefundID != aktBefundID || NewBefund.SozVersNr != aktBefundSozVersNr) || NewBefund.MailBoxNr != aktAbsender)
                        {
                            aktBefundID = NewBefund.BefundID;
                            aktAbsender = NewBefund.MailBoxNr;
                            aktBefundSozVersNr = NewBefund.SozVersNr;

                            if (NewBefund.VersionOk)
                            {
                                PMDS.db.Entities.AuswahlListe rAuswahliste = CheckMailBoxNr(NewBefund.MailBoxNr.Trim(), ref NewBefund.Absender);
                                if (rAuswahliste != null)
                                {
                                    if (rAuswahliste.GehörtzuGruppe.Trim().Equals("LAB", StringComparison.CurrentCultureIgnoreCase) ||
                                        rAuswahliste.GehörtzuGruppe.Trim().Equals("LG", StringComparison.CurrentCultureIgnoreCase))
                                        rNewEdifact.LaborJN = true;
                                }

                                if (NewBefund.rPatient != null && rAuswahliste.GehörtzuGruppe.Trim() != "" && NewBefund.MailBoxNr != "" && NewBefund.SozVersNr.ToString() != "")
                                {
                                    rNewEdifact.NameBefund = "Befund_" + rAuswahliste.GehörtzuGruppe.Trim() + "_" + NewBefund.MailBoxNr + "_" + NewBefund.DatumBefund.ToString("yyyy-MM-dd") + "_" + NewBefund.SozVersNr.ToString() + "_" + NewBefund.BefundID.ToString() + "_" + NewBefund.BefundNummer.ToString(); // NewBefund.BezeichnungFile;
                                    rNewEdifact.Klient = NewBefund.rPatient.Nachname + " " + NewBefund.rPatient.Vorname;
                                    iCounterFilesImported += 1;
                                }

                                dsEDIFACT1.EDIFACT.Rows.Add(rNewEdifact);
                            }
                            else
                            {
                                protocol += QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + NewBefund.Dateiname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" für SozVers.Nr: ") + NewBefund.SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" kann wegen fehlerhafter Version nicht geladen werden!") + "\r\n" + "\r\n";
                                iCounterFilesImportedError += 1;
                            }
                        }
                        else
                        {
                            if (!PMDS.Global.ENV.adminSecure)
                            {
                                protocol += QS2.Desktop.ControlManagment.ControlManagment.getRes("Ältere Version der Datei ") + NewBefund.Dateiname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" für SozVers.Nr: ") + NewBefund.SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird übersprungen!") + "\r\n" + "\r\n";
                                System.IO.File.Delete(NewBefund.ImportFile.Trim());
                            }
                        }
                    }
                    else
                    {
                        //Übernehmen in Liste ohne Informationen zum Absender und Bewohner bei NICHT-Befunden 
                        //rNewEdifact.Hinweis = "Nicht zugeordnet!";
                        dsEDIFACT1.EDIFACT.Rows.Add(rNewEdifact);
                    }
                }     
                
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("EDIFact.ReadBefunde: " + ex.ToString());
            }
        }


        public static void ParseBefund(cBefund NewBefund, string BefundType)
        {

            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                NewBefund.txtEdiFactFilePrintable = "";
                string sDateiname = Path.Combine(NewBefund.ArchivePath, NewBefund.Dateiname + ": ");

                if (BefundType.Equals(ENV.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] Befundzeilen = NewBefund.txtEdiFactFile.Split(new string[] { "'" }, StringSplitOptions.None);

                    foreach (string Befundzeile in Befundzeilen)
                    {
                        if (Befundzeile.Trim() == "" || Befundzeile.Trim().Length < 3)
                            continue;

                        string SegmentName = Befundzeile.Substring(0, 3);

                        string tmpBefundzeile = ReplaceSpecialCharacters(Befundzeile, false, NewBefund.TrennzeichenImFeld, NewBefund.TrennzeichenZwischenFeldern, NewBefund.Dezimalzeichen, NewBefund.Auflösungszeichen);
                        string[] Felder = tmpBefundzeile.Split(new string[] { NewBefund.TrennzeichenZwischenFeldern }, StringSplitOptions.None);

                        if (SegmentName == "UNA")
                        {
                            NewBefund.TrennzeichenImFeld = Befundzeile.Substring(3, 1);
                            NewBefund.TrennzeichenZwischenFeldern = Befundzeile.Substring(4, 1);
                            NewBefund.Dezimalzeichen = Befundzeile.Substring(5, 1);
                            NewBefund.Auflösungszeichen = Befundzeile.Substring(6, 1);
                        }

                        else if (SegmentName == "UNB")   //
                        {
                            string CodePage = Felder[1];
                            NewBefund.MailBoxNr = Felder[2];

                            if (Felder[4].Length != 6)
                                throw new Exception(sDateiname + "Sended date is not six digits.");

                            if (Felder[5].Length != 4)
                                throw new Exception(sDateiname + "The transmission time is not four-digit.");

                            DateTime Sendedatum = new DateTime(System.Convert.ToInt32(Felder[4].Substring(0, 2)) + 2000,
                                                                System.Convert.ToInt32(Felder[4].Substring(2, 2)),
                                                                System.Convert.ToInt32(Felder[4].Substring(4, 2)),
                                                                System.Convert.ToInt32(Felder[5].Substring(0, 2)),
                                                                System.Convert.ToInt32(Felder[5].Substring(2, 2)),
                                                                0);

                            NewBefund.BefundNummer = Sendedatum.Ticks.ToString();
                            //DateTime x = new DateTime(Sendedatum.Ticks);


                            PMDS.db.Entities.AuswahlListe rAuswahliste = CheckMailBoxNr(NewBefund.MailBoxNr.Trim(), ref NewBefund.Absender);
                            if (rAuswahliste != null)
                                NewBefund.NameAbsender = rAuswahliste.Beschreibung;
                        }

                        else if (SegmentName == "UNH")
                        {
                            NewBefund.BefundID = Felder[1];
                            NewBefund.Version = Felder[2];
                            //Bei Befund
                            if (NewBefund.Version.Trim().Equals("MEDRPT:1:901:UN", StringComparison.CurrentCultureIgnoreCase))
                                NewBefund.VersionOk = true;

                            //Bei Labor
                            if (NewBefund.Version.Trim().Equals("MEDRPT:D.95A:ME:BEFAT1", StringComparison.CurrentCultureIgnoreCase))
                                NewBefund.VersionOk = true;
                        }

                        else if (SegmentName == "BGM")   //
                        {
                            if (Felder[4].Length != 8)
                                throw new Exception(sDateiname + "Date of diagnosis " + Felder[4] + " Is not eight digits.");
                            else
                                NewBefund.DatumBefund = new DateTime(System.Convert.ToInt32(Felder[4].Substring(0, 4)),
                                        System.Convert.ToInt32(Felder[4].Substring(4, 2)),
                                        System.Convert.ToInt32(Felder[4].Substring(6, 2)));

                            if (Felder[6].Length != 4)
                            {
                                if (Felder[6].Length > 4)
                                    Felder[6] = Felder[6].Substring(0, 4);
                            }

                            if (Felder[6].Length == 4)              //Sozialversicherungsnummer
                                NewBefund.SozVersNr = Felder[6];

                            if (Felder[7].Length == 8)              //Geburtsdatum
                                NewBefund.GeburtsdatumPatient = new DateTime(System.Convert.ToInt32(Felder[7].Substring(0, 4)),
                                                                    System.Convert.ToInt32(Felder[7].Substring(4, 2)),
                                                                    System.Convert.ToInt32(Felder[7].Substring(6, 2)));
                        }

                        else if (SegmentName == "NAD")
                        {
                            NewBefund.NamePatientAusBefundDatei = Felder[3];
                        }

                        else if (SegmentName == "UNT")   //
                        {
                            continue;
                        }

                        else if (SegmentName == "FTX")
                        {
                            if (!Felder[3].ToUpper().Contains("ZUSTELLUNG&&&DOPPELPUNKT&&&"))
                                NewBefund.txtEdiFactFilePrintable += Felder[3].Replace(NewBefund.TrennzeichenImFeld, "").TrimEnd() + "\r\n";
                            int iii = Felder[3].Replace(NewBefund.TrennzeichenImFeld, "").Length;
                        }

                        else if (SegmentName == "UNT")
                            continue;

                        else if (SegmentName == "UNZ")
                            continue;
                    }
                }
                else if (BefundType.Equals(ENV.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase))

                {
                    string[] Befundzeilen = NewBefund.txtEdiFactFile.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    foreach (string Befundzeile in Befundzeilen)
                    {
                        if (Befundzeile.Trim() == "" || Befundzeile.Trim().Length < 3)      //Leerzeilen überspringen
                            continue;

                        if (Befundzeile.Substring(0,3).Equals("UNB", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] Felder = Befundzeile.Split(new string[] { NewBefund.TrennzeichenZwischenFeldern }, StringSplitOptions.None);
                            string CodePage = Felder[1];
                            NewBefund.MailBoxNr = Felder[2];
                            NewBefund.VersionOk = true;

                            if (Felder[4].Length != 6)
                                throw new Exception(sDateiname + "Sended date is not six digits.");

                            if (Felder[5].Length != 4)
                                throw new Exception(sDateiname + "Sended date is not four digits.");

                            DateTime Sendedatum = new DateTime(System.Convert.ToInt32(Felder[4].Substring(0, 2)) + 2000,
                                                                System.Convert.ToInt32(Felder[4].Substring(2, 2)),
                                                                System.Convert.ToInt32(Felder[4].Substring(4, 2)),
                                                                System.Convert.ToInt32(Felder[5].Substring(0, 2)),
                                                                System.Convert.ToInt32(Felder[5].Substring(2, 2)),
                                                                0);

                            NewBefund.BefundNummer = Sendedatum.Ticks.ToString();

                            PMDS.db.Entities.AuswahlListe rAuswahliste = CheckMailBoxNr(NewBefund.MailBoxNr.Trim(), ref NewBefund.Absender);
                            if (rAuswahliste != null)
                                NewBefund.NameAbsender = rAuswahliste.Beschreibung;

                        }

                        if (Befundzeile.Substring(0,3).Equals("UNZ", StringComparison.CurrentCultureIgnoreCase))
                        {
                            continue;
                        }

                        if (Befundzeile.Substring(0,1).Equals("H", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] Felder = Befundzeile.Split(new string[] { "`" }, StringSplitOptions.None);

                            if (Felder[4].Length != 10)
                                throw new Exception(sDateiname + "Date of birth " + Felder[4] + " is not ten digits.");
                            else
                                NewBefund.GeburtsdatumPatient = new DateTime(System.Convert.ToInt32(Felder[4].Substring(6, 4)),
                                        System.Convert.ToInt32(Felder[4].Substring(3, 2)),
                                        System.Convert.ToInt32(Felder[4].Substring(0, 2)));

                            if (Felder[7].Length != 6)
                                throw new Exception(sDateiname + "Date of diagnosis " + Felder[7] + " is not ten digits.");
                            else
                                NewBefund.DatumBefund = new DateTime(System.Convert.ToInt32(Felder[7].Substring(0, 2)) + 2000,
                                        System.Convert.ToInt32(Felder[7].Substring(2, 2)),
                                        System.Convert.ToInt32(Felder[7].Substring(4, 2)));

                            if (Felder[9].Length == 4)              //Sozialversicherungsnummer
                                NewBefund.SozVersNr = Felder[9];

                            NewBefund.NamePatientAusBefundDatei = Felder[1] + ":" + Felder[2];
                            NewBefund.BefundID = Felder[5];
                            NewBefund.Version = Felder[6];
                        }

                        if (Befundzeile.Substring(0,1).Equals("E", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] Felder = Befundzeile.Split(new string[] { "`" }, StringSplitOptions.None);
                            NewBefund.txtEdiFactFilePrintable += (Felder[2] + " (" + Felder[6] + ")".PadRight(30)).Substring(0,30);
                            NewBefund.txtEdiFactFilePrintable += Felder[5].PadLeft(15) + "  ";
                            NewBefund.txtEdiFactFilePrintable += (Felder[3].PadRight(2)).Substring(0,2);
                            NewBefund.txtEdiFactFilePrintable += (Felder[4].PadRight(5)).Substring(0,5);
                            NewBefund.txtEdiFactFilePrintable += (Felder[7].PadRight(15)).Substring(0,15);
                            NewBefund.txtEdiFactFilePrintable = NewBefund.txtEdiFactFilePrintable.Trim() + "\n\r";
                        }
                    }
                }

                //-------------------------- Patienten, Aufenthalt, Absender eruieren ---------------------------------
                if ((NewBefund.SozVersNr.Trim().Length == 4 || NewBefund.GeburtsdatumPatient != null) && NewBefund.DatumBefund != DateTime.MinValue)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahliste = CheckMailBoxNr(NewBefund.MailBoxNr.Trim(), ref NewBefund.Absender);
                    if (rAuswahliste != null)
                    {
                        string ErrorTextBackSozVersNr = "";
                        Nullable<Guid> IDPatient = null;
                        NewBefund.NameAbsender = rAuswahliste.Beschreibung.Trim();

                        DateTime SozVersNrDatePart = NewBefund.GeburtsdatumPatient.Value;
                        NewBefund.SozVersNr += SozVersNrDatePart.ToString("ddMMyy");

                        NewBefund.BezeichnungFile = "Befund_" + rAuswahliste.GehörtzuGruppe.Trim() + "_" + NewBefund.MailBoxNr.Trim() + "_" +
                        NewBefund.DatumBefund.ToString("yyyy-MM-dd") + "_" + NewBefund.SozVersNr.Trim() + "_" +
                        NewBefund.BefundID.Trim() + "_" + NewBefund.BefundNummer.Trim();

                        if (PMDSBusiness1.getIDPatientForSozVersNr(ref IDPatient, NewBefund.SozVersNr.Trim(), (DateTime)NewBefund.GeburtsdatumPatient,
                                            ref ErrorTextBackSozVersNr, NewBefund.NamePatientAusBefundDatei.Trim()))
                        {
                            //-----------------------------------------------------------------------------
                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                            {
                                PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient((Guid)IDPatient, db);
                                PMDS.db.Entities.Aufenthalt rAktAufenthalt = PMDSBusiness1.getAktuellerAufenthaltPatient((Guid)IDPatient, true, null);

                                NewBefund.IDPatient = (Guid)IDPatient;
                                NewBefund.rPatient = rPatient;
                                NewBefund.rAktAufenthalt = rAktAufenthalt;
                                string Trenner = "".PadRight(78, '=');
                                string Absender = "  Absender   : " + NewBefund.NameAbsender;
                                string Befunddatum = "  Befunddatum: " + NewBefund.DatumBefund.ToString("dd.MM.yyyy");
                                string Patient = "  Patient    : " + NewBefund.rPatient.Nachname + " " + NewBefund.rPatient.Vorname;
                                string SVNr = "  SV-Nr      : " + NewBefund.SozVersNr;

                                //Für Anzeige in der Vorschau
                                NewBefund.txtEdiFactFilePrintable = Trenner + "\n\n\r" +
                                                            Absender + "\n\r" +
                                                            Befunddatum + "\n\r" +
                                                            Patient + "\n\r" +
                                                            SVNr + "\n\r" +
                                                            Trenner + "\n\r" +
                                                            NewBefund.txtEdiFactFilePrintable;
                            }
                        }
                        else
                        {
                            string Trenner = "".PadRight(78, '=');
                            string Absender = "  Absender   : " + NewBefund.NameAbsender;
                            string Befunddatum = "  Befunddatum: " + NewBefund.DatumBefund.ToString("dd.MM.yyyy");
                            string Patient = "  Patient    : " + NewBefund.NamePatientAusBefundDatei;
                            string SVNr = "  SV-Nr      : " + NewBefund.SozVersNr;

                            //Für Anzeige in der Vorschau
                            NewBefund.txtEdiFactFilePrintable = "---- Patient nicht in der Datenbank gefunden ----\n\r" +
                                                        Trenner + "\n\n\r" +
                                                        Absender + "\n\r" +
                                                        Befunddatum + "\n\r" +
                                                        Patient + "\n\r" +
                                                        SVNr + "\n\r" +
                                                        Trenner + "\n\r" +
                                                        NewBefund.txtEdiFactFilePrintable;

                        }


                    }
                    else
                    {
                        NewBefund.BezeichnungFile = "Unbekannte Mailbox-Nummer '" + NewBefund.MailBoxNr.Trim() + "'. Bitte Auswahlliste BIM überprüfen";
                    }

                }
                NewBefund.txtEdiFactFilePrintable = ReplaceSpecialCharacters(NewBefund.txtEdiFactFilePrintable, true, NewBefund.TrennzeichenImFeld, NewBefund.TrennzeichenZwischenFeldern, NewBefund.Dezimalzeichen, NewBefund.Auflösungszeichen);
            }

            catch (Exception ex)
            {
                throw new Exception("GetPrintableBefundText: " + ex.ToString());
            }

        }

        public static string ReplaceSpecialCharacters(string sInput, bool bReverse, string TrennzeichenImFeld, string TrennzeichenZwischenFeldern, string Dezimalpunkt, string Auflösungszeichen)
        {

            try
            {
                string sReturn = "";

                string sTmpPlus = "&&&PLUS&&&";
                string sTmpPunkt = "&&&PUNKT&&&";
                string sTmpDoppelpunkt = "&&&DOPPELPUNKT&&&";
                string sTmpFragezeichen = "&&&FRAGEZEICHEN&&&";

                string sPlus = TrennzeichenZwischenFeldern;
                string sPunkt = Dezimalpunkt;
                string sDoppelpunkt = TrennzeichenImFeld;
                string sFragezeichen = Auflösungszeichen;

                if (!bReverse)
                {
                    // Steuerzeichen vorübergehend durch andere Zeichen ersetzen
                    sReturn = sInput.Replace(Auflösungszeichen + "+", sTmpPlus);
                    sReturn = sReturn.Replace(Auflösungszeichen + ".", sTmpPunkt);
                    sReturn = sReturn.Replace(Auflösungszeichen + ":", sTmpDoppelpunkt);
                    sReturn = sReturn.Replace(Auflösungszeichen + "?", sTmpFragezeichen);
                }
                else
                {
                    // Steuerzeichen vorübergehend durch andere Zeichen ersetzen
                    sReturn = sInput.Replace(sTmpPlus, sPlus);
                    sReturn = sReturn.Replace(sTmpPunkt, sPunkt);
                    sReturn = sReturn.Replace(sTmpDoppelpunkt, sDoppelpunkt);
                    sReturn = sReturn.Replace(sTmpFragezeichen, sFragezeichen);
                }
                return sReturn;
            }

            catch (Exception e)
            {
                throw new Exception("ReplaceSpecialCharacters: " + e.ToString());
            }
        }



        public bool SaveBefundeToArchive(ref UltraGrid gridImportBefunde, int iCounter, ref DateTime dNow, ref string protocol,
                                   ref PMDS.db.Entities.ERModellPMDSEntities db, ref int iCounterBefundeImported, ref int iCounterFilesImportedError)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                System.Collections.Generic.List<dsEDIFACT.EDIFACTRow> lstToDelete = new List<dsEDIFACT.EDIFACTRow>();
                foreach (UltraGridRow gridRow in gridImportBefunde.Rows)
                {
                    DataRowView v = (DataRowView)gridRow.ListObject;
                    dsEDIFACT.EDIFACTRow rEdifact = (dsEDIFACT.EDIFACTRow)v.Row;
                    cBefund Befund = (cBefund)rEdifact.obj;
                    if ((bool)gridRow.Cells["Select"].Value == true)
                    {
                        Guid IDDokumenteintragReturn = System.Guid.Empty;

                        if (Befund.IDPatient != System.Guid.Empty)
                        {
                            string BezeichnungFile = Befund.BezeichnungFile + (Befund.Hinweis != null ? "_" + Befund.Hinweis : "");
                            string Dateiname = Befund.Dateiname;

                            foreach (char c in new string(Path.GetInvalidFileNameChars()) )
                            {
                                BezeichnungFile = BezeichnungFile.Replace(c.ToString(), "");
                                Dateiname = Dateiname.Replace(c.ToString(), "");
                            }

                            //Bei Dicom-Serie: die Serie als Zip speichern
                            string FileIn = System.IO.Path.Combine(Befund.Verzeichnis, Dateiname);
                            if (Befund.IsDicomStudy)
                            {
                                FileIn = System.IO.Path.Combine(Befund.Verzeichnis, Befund.BezeichnungFile);
                                using (Chilkat.Zip zip = new Chilkat.Zip())
                                {
                                    zip.UnlockComponent(ENV.ChilkatKey);
                                    FileInfo fi = new FileInfo(FileIn);
                                    //Befund.DateiType = Settings.BefundTypText(eBefundTyp.ZIP);    //os 150998 warum?
                                    Befund.SizeDoku = Befund.byteDicomSeriesFile.Length;
                                    Dateiname = fi.Name + ENV.BefundTypText(eBefundTyp.DICOMDIR) + ENV.BefundTypText(eBefundTyp.ZIP);
                                    BezeichnungFile += ENV.BefundTypText(eBefundTyp.DICOM);
                                    string FileOut = System.IO.Path.Combine(fi.DirectoryName, Dateiname);
                                    zip.NewZip(FileOut);
                                    zip.OpenFromByteData(Befund.byteDicomSeriesFile);
                                    zip.WriteZipAndClose();
                                }
                            }

                            string tmpDateiType = Befund.IsDicomStudy ? ENV.BefundTypText(eBefundTyp.ZIP) : Befund.DateiType;

                            bool bAddNewBefund = PMDSBusiness1.SaveDokumentinArchiv(Dateiname,Befund.Verzeichnis, Befund.IDOrdnerArchiv, BezeichnungFile, tmpDateiType, "",
                                        dNow, Befund.IDPatient, ref IDDokumenteintragReturn, Befund.NameAbsender.Trim(), false);

                            if (bAddNewBefund)          //Nur wenn der Befund neu ist
                            {
                                if (Befund.rAktAufenthalt != null)   // wenn der Klient nicht entlassen ist -> Termin erstellen
                                {
                                    //string Bezeichnung = sBezeichnungFileTmp.Trim();
                                    bool WriteMedizinischeDaten = PMDSBusiness1.addMedizinischeDatenBefund(db, dNow, (Guid)Befund.rAktAufenthalt.IDPatient,
                                                                             ref Befund.BezeichnungFile, IDDokumenteintragReturn, "Befund",
                                                                             PMDS.Global.MedizinischerTyp.Befunde, Befund.NameAbsender,
                                                                             Befund.BefundID, Befund.BefundNummer, Befund.Hinweis);

                                    if (WriteMedizinischeDaten) //Wenn die aktuelle Version größer ist, als eine vorhanden (oder neu ist) und medizinische Daten eingefügt wurden
                                    {
                                        iCounterBefundeImported++;

                                        System.Collections.Generic.List<Guid> lstIDWichtig = PMDS.Global.Tools.GetWichtigFuerDefaults(eDekursDefaults.BefundimportTermin.ToString());
                                        if (lstIDWichtig.Count() == 0)        //Keine Berufsgruppe ausgewählt
                                        {
                                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Befundimport. Kein Berufsgruppen-Eintrag in Auswahlliste BefundimportTermin gefunden! Kann keinen Termin erstellen. Befund wurde trotzdem im Archiv abgelegt.");
                                        }
                                        else
                                        {
                                            foreach (Guid IDWichtig in lstIDWichtig)

                                            {
                                                string TerminText = (Befund.BezeichnungFile + " " + Befund.Hinweis).Trim();
                                                PMDS.db.Entities.PflegePlan rPflegePlan = PMDSBusiness1.addPflegeplan(db, dNow, Befund.rAktAufenthalt.ID, null, TerminText,
                                                                                        IDWichtig, PMDS.Global.EintragGruppe.T, IDDokumenteintragReturn, 3, Befund.NameAbsender);
                                                rPflegePlan.IDBenutzer_Geaendert = ENV.USERID;

                                            }
                                        }
                                    }
                                    else
                                    {
                                        //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kann keinen Eintrag in die Medizinsche Daten schreiben: " + Befund.BezeichnungFile);
                                        iCounterFilesImportedError++;
                                    }
                                }

                                lstToDelete.Add(rEdifact);

                                if (Befund.IsDicomStudy)
                                {
                                    //gesamtes Unterverzeichnis aus Befundimport-Verzeichnis löschen - wenn möglich
                                    System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(Befund.Verzeichnis);
                                    foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                                    {
                                        if (File.Exists(file.FullName))
                                        {
                                            if (!PMDS.Global.Tools.IsFileLocked(file))
                                                file.Delete();
                                        }
                                    }

                                    foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                                    {
                                            dir.Delete(true);
                                    }

                                    if (!Directory.EnumerateFiles(Befund.Verzeichnis).Any())
                                        Directory.Delete(Befund.Verzeichnis);
                                    else
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Verzeichnis ") + Befund.Verzeichnis + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist in Verwendung. Bitte händisch löschen."), true);
                                }
                                else
                                {
                                    FileInfo file = new FileInfo(Befund.ImportFile);
                                    if (File.Exists(file.FullName))
                                    {
                                        if (!PMDS.Global.Tools.IsFileLocked(file))
                                            file.Delete();
                                        else
                                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + Befund.ImportFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist in Verwendung. Bitte händisch löschen."), true);
                                    }
                                    else
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + Befund.ImportFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde in der Zwischenzeit gelöscht."));
                                    }
                                }

                            }
                            else
                            {
                                //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kann Befund nicht in Archiv ablegen." + Befund.BezeichnungFile);
                                iCounterFilesImportedError++;
                            }
                        }
                        else
                        {
                            //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Im Befund angegebener Patient nicht gefunden." + Befund.BezeichnungFile);
                            iCounterFilesImportedError++;
                        }                        
                        db.SaveChanges();                       
                    }
                }

                foreach (dsEDIFACT.EDIFACTRow rEdifactToDelete in lstToDelete)
                {
                    rEdifactToDelete.Table.Rows.Remove(rEdifactToDelete);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.SaveBefundeToArchive: " + ex.ToString());
            }
        }


        public static PMDS.db.Entities.AuswahlListe CheckMailBoxNr(string MailBoxNr, ref string AbsenderReturn)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.AuswahlListe rAuswahliste = PMDSBusiness1.GetAuswahlliste(db, "BIM", MailBoxNr);
                    if (rAuswahliste != null)
                    {
                        AbsenderReturn = rAuswahliste.GehörtzuGruppe;
                        return rAuswahliste;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.CheckMailBoxNr: " + ex.ToString());
            }
        }

        public void openBefund(ref TXTextControl.TextControl editorToShow)
        {
            try
            {
                editorToShow.Text = "";
                QS2.functions.vb.FileFunctions funct1 = new QS2.functions.vb.FileFunctions();
                string selectedFile = funct1.selectFile(this.TypeBefund, System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                if (selectedFile != null)
                {
                    Font font = new Font("lucida console", 8.0f);
                    editorToShow.Font = font;

                    cBefund Befund = ReadBefundFile(selectedFile, false);       //osBefund
                    EDIFact.show(editorToShow, Befund);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.openBefund: " + ex.ToString());
            }
        }

        public void openBefund(Guid IDDokument)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                PMDS.db.Entities.tblDokumenteintrag rDokumenteintrag = null;
                PMDS.db.Entities.tblDokumente rDokumente = null;
                PMDSBusiness1.getDocumentFromArchive(IDDokument, ref rDokumenteintrag, ref rDokumente);

                if (rDokumente != null)
                {
                    PMDSBusiness b = new PMDS.DB.PMDSBusiness();
                    string dateiArchiv = System.IO.Path.Combine(b.getPfadArchiv(), rDokumente.Archivordner, rDokumente.DateinameArchiv);

                    cBefund Befund = new cBefund();
                    Befund = ReadBefundFile(dateiArchiv, false);        //osBefund

                    frmEdiFactViewer frm = new frmEdiFactViewer();
                    frm.initControl1(Befund.txtEdiFactFilePrintable, Befund);
                    frm.Show();
                    if (!Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase) &&
                        !Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase))
                    {
                        frm.Close();
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ID des gewählten Dokuments nicht gefunden!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.OpenBefund: " + ex.ToString());
            }
        }

        public static cBefund ReadBefundFile(string Datei, bool DicomSeries)
        {
            try
            {
                cBefund Befund = new cBefund();
                //Chilkat.Zip zip = new Chilkat.Zip();
                //zip.UnlockComponent("S2ENGN.CB1022023_XfLzJ7t36L5K");

                if (System.IO.Path.GetExtension(Datei).Equals(ENV.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase) ||
                    System.IO.Path.GetExtension(Datei).Equals(ENV.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase))
                {

                    // Korrekt: 1. Zeile lesen, Segement UNB, Feld 1.1 suchen und Codierung auslesen.
                    // Danach Datei mit entsprechender Codierung nochmals öffnen und Text übernehmen, wenn nicht ANSI:1

                    string CodePage = "";
                    Befund.txtEdiFactFile = System.IO.File.ReadAllText(Datei, Encoding.GetEncoding("iso-8859-1"));
                    string[] Befundzeilen = Befund.txtEdiFactFile.Split(new string[] { "'" }, StringSplitOptions.None);

                    foreach (string Befundzeile in Befundzeilen)
                    {
                        if (Befundzeile.Trim() == "" || Befundzeile.Trim().Length < 3)
                            continue;

                        string SegmentName = Befundzeile.Substring(0, 3);
                        string tmpBefundzeile = ReplaceSpecialCharacters(Befundzeile, false, Befund.TrennzeichenImFeld, Befund.TrennzeichenZwischenFeldern, Befund.Dezimalzeichen, Befund.Auflösungszeichen);
                        string[] Felder = tmpBefundzeile.Split(new string[] { Befund.TrennzeichenZwischenFeldern }, StringSplitOptions.None);

                        if (SegmentName != "UNB")
                            continue;
                        else
                        {
                            CodePage = Felder[1];
                            break;
                        }
                    }

                    if (CodePage.ToUpper().Trim() == "IBM861:1" || CodePage.ToUpper().Trim() == "IBMA:1")
                        Befund.txtEdiFactFile = System.IO.File.ReadAllText(Datei, Encoding.GetEncoding("ibm861"));        //osxy: Labor Müller-Speiser ab Juni 2015??

                    Befund.byteEdiFactFile = null;
                    Befund.byteDicomSeriesFile = null;
                    ParseBefund(Befund, System.IO.Path.GetExtension(Datei));
                    Befund.DateiType = System.IO.Path.GetExtension(Datei).ToLower();
                    Befund.Verzeichnis = System.IO.Path.GetDirectoryName(Datei);
                    Befund.ImportFile = Datei;

                }

                else if (System.IO.Path.GetExtension(Datei).Equals(ENV.BefundTypText(eBefundTyp.PDF), StringComparison.CurrentCultureIgnoreCase))
                {
                    Befund.txtEdiFactFile = "";
                    Befund.byteEdiFactFile = PMDS.Global.Tools.GetBytesFromFile(Datei);
                    Befund.byteDicomSeriesFile = null;
                    Befund.BezeichnungFile = "PDF-Datei";   
                    Befund.DateiType = System.IO.Path.GetExtension(Datei).ToLower();
                    Befund.Verzeichnis = System.IO.Path.GetDirectoryName(Datei);
                    Befund.ImportFile = Datei;

                }
                else if (System.IO.Path.GetExtension(Datei).Equals(ENV.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase) || DicomSeries)
                {
                    Befund.txtEdiFactFile = "";
                    Befund.DateiType = ENV.BefundTypText(eBefundTyp.DICOM);     //Damit man nach dem Entzippen die DICOMDIR mit Dicom-Viewer öffnen kann!
                    Befund.Verzeichnis = System.IO.Path.GetDirectoryName(Datei);
                    Befund.ImportFile = Datei;

                    if (DicomSeries)
                    {
                        using (Chilkat.Zip zip = new Chilkat.Zip())
                        {
                            //Verzeichnis inkl. Unterverzeichnisse in Zip-File speichern
                            zip.UnlockComponent(ENV.ChilkatKey);
                            zip.NewZip("not_used.zip");
                            FileInfo fi = new FileInfo(Datei);
                            zip.AppendFiles(System.IO.Path.Combine(fi.DirectoryName, "*.*"), true);
                            Befund.byteDicomSeriesFile = zip.WriteToMemory();
                        }
                            
                        Befund.byteEdiFactFile = null;
                        Befund.BezeichnungFile = "DICOM-Study";
                        Befund.SizeDoku = Befund.byteDicomSeriesFile.Length;
                        Befund.IsDicomStudy = true;
                    }
                    else
                    {
                        //einzelne Dicom-Datei                        
                        Befund.byteDicomSeriesFile = null;
                        Befund.byteEdiFactFile = PMDS.Global.Tools.GetBytesFromFile(Datei);
                        Befund.BezeichnungFile = "DICOM-Datei";
                        Befund.SizeDoku = Befund.byteEdiFactFile.Length;
                        Befund.IsDicomStudy = false;
                    }
                }
                else if (System.IO.Path.GetExtension(Datei).Equals(ENV.BefundTypText(eBefundTyp.ZIP), StringComparison.CurrentCultureIgnoreCase))   //gezippte Dicom-Serie wieder öffnen
                {

                    string tmpDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "DICOMDIR");
                    System.IO.DirectoryInfo tmpDirInfo = new DirectoryInfo(System.IO.Path.GetTempPath());
                    string searchPattern = "DICOMDIR";

                    foreach (DirectoryInfo dirInfo in tmpDirInfo.GetDirectories())
                    {
                        try
                        {
                            if (dirInfo.Name == searchPattern)
                                dirInfo.Delete(true);
                        }
                        catch (IOException)
                        {
                            //the file is unavailable because it is:
                            //still being written to
                            //or being processed by another thread
                            //or does not exist (has already been processed)
                        }
                    }

                    //ZIP temporär entpacken
                    using (Chilkat.Zip zip = new Chilkat.Zip())
                    {
                        zip.UnlockComponent(ENV.ChilkatKey);
                        zip.OpenZip(Datei);
                        zip.Unzip(tmpDir);
                    }

                    Befund.DateiType = ENV.BefundTypText(eBefundTyp.DICOM);
                    Befund.Verzeichnis = tmpDir;

                    //DICOMDIR einlesen
                    DirectoryInfo dir = new DirectoryInfo(tmpDir);
                    foreach (FileInfo file in dir.EnumerateFiles(searchPattern))
                    {
                        Befund.txtEdiFactFile = "";
                        Befund.byteEdiFactFile = PMDS.Global.Tools.GetBytesFromFile(file.FullName);
                        Befund.BezeichnungFile = "DICOM-Study";
                        Befund.Verzeichnis = tmpDir;
                        using (Chilkat.Zip zip = new Chilkat.Zip())
                        {
                            zip.AppendFiles(System.IO.Path.Combine(tmpDir, searchPattern), true);
                            Befund.byteDicomSeriesFile = zip.WriteToMemory();
                        }
                        Befund.ImportFile = file.FullName;
                        Befund.IsDicomStudy = true;
                    }
                }

                FileInfo infoFile = new FileInfo(Datei.Trim());
                FileAttributes attributesFile = infoFile.Attributes;

                Befund.SizeDoku = infoFile.Length;
                Befund.Dateiname = System.IO.Path.GetFileName(Datei);
                return Befund;
            }

            catch (Exception ex)
            {
                throw new Exception("EDIFact.OpenBefund: " + ex.ToString());
            }
        }


        
        public static void show(TXTextControl.TextControl textControl1, EDIFact.cBefund Befund)
        {
            try
            {
                Font font = new Font("lucida console", 8.0f);
                textControl1.Font = font;
                textControl1.Text = "";

                string BefundType = Befund.DateiType;
                byte[] bFile = Befund.byteEdiFactFile;
                string txt = Befund.txtEdiFactFilePrintable;


                if (BefundType.Equals(ENV.BefundTypText(eBefundTyp.BEFUND)) || BefundType.Equals(ENV.BefundTypText(eBefundTyp.LABOR)))
                {
                    textControl1.Load(txt, TXTextControl.StringStreamType.PlainText);
                    textControl1.SelectAll();
                    textControl1.Selection.FontName = "lucida console";
                    textControl1.Selection.FontSize = 160;      //twips (200 twips = 10 OPunkt)
                }

                else 
                {

                    // Prüfen, ob eine Standard-Anwendung definiert ist
                    string DefaultApp = PMDS.Global.Tools.AssocQueryString(PMDS.Global.Tools.AssocStr.ASSOCSTR_EXECUTABLE, BefundType);

                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = DefaultApp; 
                    //myProcess.StartInfo.Arguments = "/A \"page=2=OpenActions\" C:\\example.pdf";

                    if (BefundType.Equals(ENV.BefundTypText(eBefundTyp.PDF), StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Alte Befunde von der Platte löschen, wenn sie nicht gerade verwendet werden.
                        foreach (FileInfo f in new DirectoryInfo(System.IO.Path.GetTempPath()).GetFiles("tmpBefund*" + BefundType))
                        {
                            if (!PMDS.Global.Tools.IsFileLocked(f))
                                f.Delete();
                        }

                        string tmpFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "tmpBefund" + System.Guid.NewGuid().ToString("N") + BefundType);
                        myProcess.StartInfo.Arguments = tmpFile;
                        File.WriteAllBytes(tmpFile, bFile);
                    }
                    else if (BefundType.Equals(ENV.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (Befund.IsDicomStudy)         //Dicom_Serie soll angezeigt werden
                        {
                            if (!ENV.DicomViewerFileOnly && Befund.byteDicomSeriesFile != null)
                                myProcess.StartInfo.Arguments = Befund.ImportFile;          //DicomDir-File als Startparamter
                            else
                            {
                                //Ansicht nur mit lizensiertem Viewer möglich, daher ohne Parameter die Standard-Anwendung öffnen.
                                myProcess.StartInfo.Arguments = "";
                            }
                        }

                        else
                        {
                            string tmpFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "tmpBefund" + System.Guid.NewGuid().ToString("N") + BefundType);
                            myProcess.StartInfo.Arguments = tmpFile;
                            File.WriteAllBytes(tmpFile, bFile);
                        }
                    }
                    myProcess.Start();
                    //var proc = System.Diagnostics.Process.Start(DefaultApp, Befund.ImportFile);

                    textControl1.Load("Dokument wird in externem Viewer angezeigt.", TXTextControl.StringStreamType.PlainText);
                }


            }

            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.showText: " + ex.ToString());
            }
        }



        public bool ImportSelListBefundImportFromExcel()
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Excel-Files (*.xls)|*.xls|Excel-Files (*.xlsx)|*.xlsx";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Title = "Wählen Sie bitte eine Excel-Datei aus:";
                DialogResult DialogRes = dialog.ShowDialog();
                if (DialogRes == DialogResult.OK)
                {
                    Infragistics.Documents.Excel.Workbook WB = Infragistics.Documents.Excel.Workbook.Load(dialog.FileName.Trim());

                    System.Collections.Generic.List<String> lstGroups = new List<string>();
                    int index = 1;
                    bool LineFound = true;
                    int iCounter = 0;
                    while (LineFound)
                    {
                        if (WB.Worksheets[0].Rows[index].Cells[0].Value != null)
                        {
                            string sFach = WB.Worksheets[0].Rows[index].Cells[0].Value.ToString().Trim();
                            if (sFach.Trim() != "")
                            {
                                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                                {
                                    if (WB.Worksheets[0].Rows[index].Cells[4].Value != null)
                                    {
                                        string Bezeichnung = WB.Worksheets[0].Rows[index].Cells[4].Value.ToString().Trim();
                                        PMDS.db.Entities.AuswahlListe rAuswahlListeCheck = PMDSBusiness1.getSelList(Bezeichnung.Trim(), "BIM", db);
                                        if (rAuswahlListeCheck == null)
                                        {
                                            PMDS.db.Entities.AuswahlListe rAuswahlListe = new PMDS.db.Entities.AuswahlListe();
                                            rAuswahlListe.ID = System.Guid.NewGuid();
                                            rAuswahlListe.IDAuswahlListeGruppe = "BIM";
                                            rAuswahlListe.Bezeichnung = Bezeichnung.Trim();
                                            rAuswahlListe.Beschreibung = WB.Worksheets[0].Rows[index].Cells[1].Value.ToString().Trim();
                                            rAuswahlListe.IstGruppe = false;
                                            rAuswahlListe.GehörtzuGruppe = WB.Worksheets[0].Rows[index].Cells[0].Value.ToString().Trim();
                                            rAuswahlListe.Reihenfolge = -1;
                                            rAuswahlListe.Hierarche = -1;
                                            //If != LAB -> Nicht auflisten in Grid  Standard nicht optional

                                            //newRow["Fach"] = WB.Worksheets[0].Rows[index].Cells[0].Value.ToString().Trim();
                                            //newRow["PLZ"] = WB.Worksheets[0].Rows[index].Cells[2].Value.ToString().Trim();
                                            this.addGroupToList(ref lstGroups, rAuswahlListe.GehörtzuGruppe.Trim());
                                            db.AuswahlListe.Add(rAuswahlListe);
                                            db.SaveChanges();
                                            iCounter += 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                LineFound = false;  
                            }
                        }
                        else
                        {
                            LineFound = false;
                        }
                        index += 1;
                    }
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        foreach (string GroupdToFound in lstGroups)
                        {
                            PMDS.db.Entities.AuswahlListe rAuswahlListeCheck = PMDSBusiness1.getSelList(GroupdToFound.Trim(), "MEF", db);
                            if (rAuswahlListeCheck == null)
                            {
                                PMDS.db.Entities.AuswahlListe rAuswahlListe = new PMDS.db.Entities.AuswahlListe();
                                rAuswahlListe.ID = System.Guid.NewGuid();
                                rAuswahlListe.IDAuswahlListeGruppe = "MEF";
                                rAuswahlListe.Bezeichnung = GroupdToFound.ToString();
                                rAuswahlListe.Beschreibung = "";
                                rAuswahlListe.IstGruppe = false;
                                rAuswahlListe.GehörtzuGruppe = "";
                                rAuswahlListe.Reihenfolge = -1;
                                rAuswahlListe.Hierarche = -1;

                                db.AuswahlListe.Add(rAuswahlListe);
                                db.SaveChanges();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.ImportSelListBefundImportFromExcel:" + ex.ToString());
            }
        }

        public void addGroupToList(ref System.Collections.Generic.List<String> lstGroups, string GroupToCheck)
        {
            try
            {
                bool bExists = false;
                foreach (string GroupToFound in lstGroups)
                {
                    if (GroupToFound.Trim().Equals(GroupToCheck.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        bExists = true;
                    }
                }
                if (!bExists)
                {
                    lstGroups.Add(GroupToCheck);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.addGroupToList: " + ex.ToString());
            }
        }
    }
    
}
