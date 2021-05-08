using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XlsIO;
using System.Reflection;
using System.Windows.Forms;

namespace PMDS.Global.db
{

    public class cELDAInterfaceDB
    {

        private bool HasError;
        private StringBuilder Log = new StringBuilder();

        private string Vertragspartnernummer = "1234567";       //Steuerung.C3
        private string DatenÜbernehmer = "14";                  //Oberösterreich     //fixer Wert
        private string DatenVerrechner = "16";                  //ÖGK-K      Steuerung.D3
        private string BundeslandDatenVerrechner = "6";
        private string UIDDatenverrechner = "ATU74552637";
        private string Abrechnungsstelle = "16";                //ÖGK-K      Steuerung.D4
        private string AbrechnungsstelleBundesland = "6";
        private int DatentraegerNummer = 1;
        private string AdressCode2 = "XX";
        private string AdressCode3 = "XXX";
        private string Datensatzversion = "17";                 //D.55, Version 2.2 gültig ab 10/2018 bzw. 01/2020
        private string DVAdresseLeistungserbringer = "00";
        private string FachgebietLeistungserbringer = "87";
        private string BundelandLeistungserbringer = "6";
        private string ZVR = "".PadRight(9, ' ');

        private Guid IDKlinik;
        private string KlinikBezeichnung;
        private string KlinikBank;
        private string KlinikBIC;
        private string KlinikIBAN;
        private string KlinikStrasse;
        private string KlinikOrt;
        private string KlinikPLZ;
        private string KlinikUID;

        private string Abrechnungsjahr = "";
        private string Abrechnungsmonat = "";
        private string Rechnungsnummer = "";
        private DateTime Rechnungsdatum = DateTime.Now;
        private string Verrechnungsart = "02";
        private double MwStSatz = 20;
        private string PositionText = "Inko-Pauschale";
        private string SubProjektCode = "HH";

        private Rechnung rechnung = new Rechnung();

        private DateTime Now { get; set; } = DateTime.Now;
        private int CountSaetze { get; set; }

        private class SART00Vorlauf
        {
            public List<Feld> Felder = new List<Feld>();
        }

        private class SART00Beginn
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
        }
        private class SART01
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
        }

        private class SART30
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
            public double Netto;
        }

        private class SART32
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
            public double Netto;
            public double Brutto;
        }

        private class SART34
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
            public double Netto;
            public double Brutto;
        }

        private class SART36
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
            public double Netto;
            public double Brutto;
        }

        private class SART39
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
        }

        private class SART99Ende
        {
            public Satzkopf Kopf = new Satzkopf();
            public List<Feld> Felder = new List<Feld>();
            public int Anzahl01;
            public int Anzahl02;
            public int Anzahl06;
            public int Anzahl30;
            public int Anzahl32;
            public int Anzahl34;
            public int Anzahl36;
            public int Anzahl39;
            public int Anzahl07;
            public int AnzahlDatenpakete = 1;
            public int Anzahl11;
            public int Anzahl85;
        }

        private class SART99Nachlauf
        {
            public List<Feld> Felder = new List<Feld>();
            public int AnzahlGesamt;
        }

        private class Rechnung
        {
            public SART00Vorlauf sART00Vorlauf = new SART00Vorlauf();
            public SART00Beginn sART00Beginn = new SART00Beginn();
            public List<VOSchein> VOScheine = new List<VOSchein>();
            public SART36 sART36 = new SART36();
            public List<SART39> Hinweise = new List<SART39>();
            public SART99Ende sART99Ende = new SART99Ende();
            public SART99Nachlauf sART99Nachlauf = new SART99Nachlauf();
        }

        private class VOSchein
        {
            public SART01 sART01 = new SART01();
            public List<Versorgunseinheit> Versorgungseinheiten = new List<Versorgunseinheit>();
            public SART34 sART34= new SART34();
        }

        private class Versorgunseinheit
        {
            public List<Position> Positionen = new List<Position>();
            public SART32 sART32 = new SART32();
            public List<SART39> Hinweise = new List<SART39>();
        }

        private class Position
        {
            public SART30 sART30 = new SART30();
            List<SART39> Hinweise = new List<SART39>();
        }

        private class Satzkopf
        {
            public List<Feld> Felder = new List<Feld>();
        }

        private class Feld
        {
            public dynamic value = "";
            public int lfdNr;
            public string feldname = "";
            public int von;
            public int bis;
            public int laenge = 0;
            public FeldTyp typ = FeldTyp.CharLinks;
            public Symbol symbol = Symbol.Muss;
        }

        private enum FeldTyp
        {
            CharLinks = 1,      //"".PadRight(7, ' ')
            CharRechts = 2,
            NumLinks = 3,
            NumRechts = 4,
            NumRechts0 = 5,
            Datum = 6,
            CentRechts0 = 7,
            DateTimeddMMyy = 8, //DateTime(Convert.ToInt32(Abrechnungsjahr), Convert.ToInt32(Abrechnungsmonat), 1).ToString("ddMMyy")
            DateTimeyy = 9,      //DateTime(Convert.ToInt32(Abrechnungsjahr), Convert.ToInt32(Abrechnungsmonat), 1).ToString("yy")
            DateTimeMM = 10,     //DateTime(Convert.ToInt32(Abrechnungsjahr), Convert.ToInt32(Abrechnungsmonat), 1).ToString("MM")
            DateTimeHHmmss = 11,
            DateTimeddMMyyyy = 12,
            DateEmpty000000 = 13
        }

        public enum Symbol
        {
            Muss = 1,
            Optional = 2
        }

        public bool Init(string XLSXFile, string TxtFile, ref List<string> Result)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rKlinik = (from k in db.Klinik
                                   join adr in db.Adresse on k.IDAdresse equals adr.ID
                                   join bank in db.Bank on k.IDBank equals bank.ID
                                   where k.ID == ENV.IDKlinik
                                   select new
                                   {
                                       IDKlinik = k.ID,
                                       Bezeichnung = k.Bezeichnung.Trim().Substring(0, 45),
                                       Bank = bank.Bezeichnung.Trim(),
                                       BIC = bank.BIC.Trim(),
                                       IBAN = bank.IBAN.Trim(),
                                       Strasse = adr.Strasse.Trim(),
                                       Ort = adr.Ort.Trim(),
                                       PLZ = adr.Plz.Trim().Substring(0, 7),
                                       UID = k.ZVR.Trim()
                                   }).First();

                    IDKlinik = (Guid)IDKlinik; 
                    KlinikBezeichnung = rKlinik.Bezeichnung;
                    KlinikBank = rKlinik.Bank;
                    KlinikBIC = rKlinik.BIC;
                    KlinikIBAN = rKlinik.IBAN;
                    KlinikStrasse = rKlinik.Strasse;
                    KlinikOrt = rKlinik.Ort;
                    KlinikPLZ = rKlinik.PLZ;
                    KlinikUID = rKlinik.UID;
                }

                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    //File temporär kopieren, damit es auch verwendet werden kann, wenn es in Excel geöffnet ist
                    string tmpXLSPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");
                    System.IO.File.Copy(XLSXFile, tmpXLSPath);

                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(tmpXLSPath);

                    //Steuerungsdaten einlesen
                    IWorksheet sheetControl = workbook.Worksheets["Steuerung"];
                    Vertragspartnernummer = sheetControl.Range["C2"].Value;
                    DatenVerrechner = sheetControl.Range["D3"].FormulaStringValue;
                    BundeslandDatenVerrechner = sheetControl.Range["D4"].FormulaStringValue;

                    Abrechnungsstelle = sheetControl.Range["D5"].FormulaStringValue;
                    DVAdresseLeistungserbringer = sheetControl.Range["C6"].Value;
                    FachgebietLeistungserbringer = sheetControl.Range["D7"].FormulaStringValue;
                    BundelandLeistungserbringer = sheetControl.Range["D8"].FormulaStringValue;
                    UIDDatenverrechner = sheetControl.Range["E3"].FormulaStringValue;
                    ZVR = sheetControl.Range["C9"].Value.Trim().PadRight(9, ' ');
                    AdressCode2 = sheetControl.Range["C10"].Value;
                    AdressCode3 = sheetControl.Range["C11"].Value;

                    string ZelleAbrechnungsjahr = sheetControl.Range["C19"].Value;
                    string ZelleAbrechnungsmonat = sheetControl.Range["C20"].Value;
                    string ZelleRechnungsnummer = sheetControl.Range["C23"].Value;
                    string ZelleRechnungsdatum = sheetControl.Range["C24"].Value;
                    Verrechnungsart = sheetControl.Range["D21"].FormulaStringValue;
                    MwStSatz = sheetControl.Range["C22"].Number;
                    SubProjektCode = sheetControl.Range["D25"].FormulaStringValue;

                    //Positionsdaten einlesen
                    int PosNr = 0;
                    string SVNr = "";
                    double Netto = 0;
                    string VPArzt = "";
                    string FamName = "";
                    string Vorname = "";
                    string KategorieCode = "";
                    int Row = 1;

                    int ColumnPos = 1;
                    int ColumnSVNr = 1;
                    int ColumnNetto = 1;
                    int ColumnVPArzt = 1;
                    int ColumnFamName = 1;
                    int ColumnVorname = 1;
                    int ColumnKategorieCode = 1;

                    IWorksheet sheetRechnung = workbook.Worksheets["Rechnung"];

                    Abrechnungsjahr = sheetRechnung.Range[ZelleAbrechnungsjahr].Value;
                    Abrechnungsmonat = sheetRechnung.Range[ZelleAbrechnungsmonat].FormulaStringValue;
                    Rechnungsnummer = sheetRechnung.Range[ZelleRechnungsnummer].Value;
                    Rechnungsdatum = sheetRechnung.Range[ZelleRechnungsdatum].DateTime;

                    IRange[] HeaderPos = sheetRechnung.FindAll(sheetControl.Range["C12"].Value, ExcelFindType.Values);
                    Row = HeaderPos[0].Cells[0].Row;
                    ColumnPos = HeaderPos[0].Cells[0].Column;

                    IRange[] HeaderSVNr = sheetRechnung.FindAll(sheetControl.Range["C13"].Value, ExcelFindType.Values);
                    ColumnSVNr = HeaderSVNr[0].Cells[0].Column;

                    IRange[] HeaderNetto = sheetRechnung.FindAll(sheetControl.Range["C14"].Value, ExcelFindType.Values);
                    ColumnNetto = HeaderNetto[0].Cells[0].Column;

                    IRange[] HeaderVPArzt = sheetRechnung.FindAll(sheetControl.Range["C15"].Value, ExcelFindType.Values);
                    ColumnVPArzt = HeaderVPArzt[0].Cells[0].Column;

                    IRange[] HeaderFamName = sheetRechnung.FindAll(sheetControl.Range["C16"].Value, ExcelFindType.Values);
                    ColumnFamName = HeaderFamName[0].Cells[0].Column;

                    IRange[] HeaderVorname = sheetRechnung.FindAll(sheetControl.Range["C17"].Value, ExcelFindType.Values);
                    ColumnVorname = HeaderVorname[0].Cells[0].Column;

                    IRange[] HeaderKategorieCode = sheetRechnung.FindAll(sheetControl.Range["C18"].Value, ExcelFindType.Values);
                    ColumnKategorieCode = HeaderKategorieCode[0].Cells[0].Column;

                    PosNr = Row;

                    do
                    {
                        Row++;

                        PosNr = (int) sheetRechnung.Range[Row, ColumnPos].Number;
                        SVNr = sheetRechnung.Range[Row, ColumnSVNr].Value;
                        Netto = sheetRechnung.Range[Row, ColumnNetto].Number;
                        VPArzt = sheetRechnung.Range[Row, ColumnVPArzt].Value;
                        FamName = sheetRechnung.Range[Row, ColumnFamName].Value;
                        Vorname = sheetRechnung.Range[Row, ColumnVorname].Value;
                        KategorieCode = sheetRechnung.Range[Row, ColumnKategorieCode].FormulaStringValue;

                        if (PosNr > 0)
                        {
                            //Verordnungsschein erzeugen und zu Abrechnung hinzufügen
                            rechnung.VOScheine.Add(MakeVOSchein(PosNr, FamName, Vorname, SVNr, VPArzt, Netto, KategorieCode));
                        }

                    } while (PosNr > 0);

                    workbook.Close();
                    System.IO.File.Delete(tmpXLSPath);
                }

                rechnung.sART00Vorlauf = MakeSART00Vorlauf();
                rechnung.sART00Beginn = MakeSART00Beginn();
                rechnung.sART36 = MakeSART36(rechnung.VOScheine);
                UpdateSART99Ende();
                UpdateSART99Nachlauf();

                string retLog = "";
                string resTxt = "";
                resTxt = FlushText(TxtFile, ref retLog);

                Result.Add(resTxt);
                Result.Add(retLog);
                return true;        
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.Init: " + ex.Message);
            }
        }

        private Satzkopf MakeSatzkopf()
        {
            try
            {
                CountSaetze++;
                Satzkopf Kopf = new Satzkopf();
                Kopf.Felder.Add(new Feld() { value = Abrechnungsstelle, feldname = "VSTRA", lfdNr = 1, von = 1, bis = 2, laenge = 2 });
                Kopf.Felder.Add(new Feld() { value = AbrechnungsstelleBundesland, feldname = "BLNDA", lfdNr = 2, von = 3, bis = 3, laenge = 1 });
                Kopf.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "BVPNR", lfdNr = 3, von = 4, bis = 9, laenge = 6 });
                Kopf.Felder.Add(new Feld() { value = AdressCode2, feldname = "VPADR", lfdNr = 4, von = 10, bis = 11, laenge = 2 });
                Kopf.Felder.Add(new Feld() { value = Abrechnungsjahr.Substring(2,2), feldname = "AJAHR", lfdNr = 5, von = 12, bis = 13, laenge = 2 });
                Kopf.Felder.Add(new Feld() { value = Abrechnungsmonat, feldname = "ABZR", lfdNr = 6, von = 14, bis = 15, laenge = 2 });
                Kopf.Felder.Add(new Feld() { value = CountSaetze, feldname = "SATNR", lfdNr = 7, von = 16, bis = 20, laenge = 5, typ = FeldTyp.NumRechts0 }); ;
                return Kopf;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSatzkopf: " + ex.Message);
            }
        }

        private SART00Vorlauf MakeSART00Vorlauf()
        {
            try
            {
                SART00Vorlauf sART00Vorlauf = new SART00Vorlauf();
                sART00Vorlauf.Felder.Add(new Feld() { value = "00", feldname = "SART", lfdNr = 1, von = 1, bis = 2, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 2, von = 3, bis = 9, laenge = 7 });
                sART00Vorlauf.Felder.Add(new Feld() { value = DatenÜbernehmer, feldname = "VSTRU", lfdNr = 3, von = 10, bis = 11, laenge = 2 });   //ÖGK-Kärnten
                sART00Vorlauf.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "OBUS", lfdNr = 4, von = 12, bis = 18, laenge = 7 });
                sART00Vorlauf.Felder.Add(new Feld() { value = DatenVerrechner, feldname = "VSTR", lfdNr = 5, von = 19, bis = 20, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "HH", feldname = "PROJ", lfdNr = 6, von = 21, bis = 22, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = SubProjektCode, feldname = "BEST", lfdNr = 7, von = 23, bis = 24, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = DatentraegerNummer, feldname = "DTNR", lfdNr = 8, von = 25, bis = 30, laenge = 6, typ = FeldTyp.NumRechts0 });
                sART00Vorlauf.Felder.Add(new Feld() { value = Now, feldname = "EDAT", lfdNr = 9, von = 31, bis = 38, laenge = 8, typ = FeldTyp.DateTimeddMMyyyy });
                sART00Vorlauf.Felder.Add(new Feld() { value = Now, feldname = "EZEIT", lfdNr = 10, von = 39, bis = 44, laenge = 6, typ = FeldTyp.DateTimeHHmmss });
                sART00Vorlauf.Felder.Add(new Feld() { value = KlinikBezeichnung, feldname = "HRST", lfdNr = 11, von = 45, bis = 89, laenge = 45 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "AUT", feldname = "HKFZ", lfdNr = 12, von = 90, bis = 92, laenge = 3 });
                sART00Vorlauf.Felder.Add(new Feld() { value = KlinikPLZ, feldname = "HPLZ", lfdNr = 13, von = 93, bis = 99, laenge = 7 });
                sART00Vorlauf.Felder.Add(new Feld() { value = Abrechnungsstelle, feldname = "VSTRA", lfdNr = 14, von = 100, bis = 101, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "", feldname = "ELDAS", lfdNr = 15, von = 102, bis = 107, laenge = 6 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "", feldname = "ELDAÜ", lfdNr = 16, von = 108, bis = 115, laenge = 8 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 17, von = 116, bis = 119, laenge = 4 });
                sART00Vorlauf.Felder.Add(new Feld() { value = Datensatzversion, feldname = "VERS", lfdNr = 18, von = 120, bis = 121, laenge = 2 });
                sART00Vorlauf.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 19, von = 122, bis = 128, laenge = 7 });
                
                rechnung.sART99Nachlauf.AnzahlGesamt++;
                return sART00Vorlauf;                
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART00Vorlauf: " + ex.Message);
            }
        }

        private SART00Beginn MakeSART00Beginn()
        {
            try
            {
                SART00Beginn sART00Beginn = new SART00Beginn();
                sART00Beginn.Kopf = MakeSatzkopf();
                sART00Beginn.Felder.Add(new Feld() { value = "00", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART00Beginn.Felder.Add(new Feld() { value = 1, feldname = "DPNR", lfdNr = 3, von = 23, bis = 24, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART00Beginn.Felder.Add(new Feld() { value = Now, feldname = "ERDAT", lfdNr = 4, von = 25, bis = 30, laenge = 6, typ = FeldTyp.DateTimeddMMyy });
                sART00Beginn.Felder.Add(new Feld() { value = Datensatzversion, feldname = "VERSD", lfdNr = 5, von = 31, bis = 32, laenge = 2 });
                sART00Beginn.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 6, von = 33, bis = 39, laenge = 7 });
                sART00Beginn.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "VPNRU", lfdNr = 7, von = 40, bis = 45, laenge = 6 });
                sART00Beginn.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "VPNRL", lfdNr = 8, von = 46, bis = 51, laenge = 6 });
                sART00Beginn.Felder.Add(new Feld() { value = DVAdresseLeistungserbringer, feldname = "VPADRL", lfdNr = 9, von = 52, bis = 53, laenge = 2 });
                sART00Beginn.Felder.Add(new Feld() { value = FachgebietLeistungserbringer, feldname = "FACHL", lfdNr = 10, von = 54, bis = 55, laenge = 2 });
                sART00Beginn.Felder.Add(new Feld() { value = BundelandLeistungserbringer, feldname = "BLLE", lfdNr = 11, von = 56, bis = 56, laenge = 1 });
                sART00Beginn.Felder.Add(new Feld() { value = KlinikUID, feldname = "UID", lfdNr = 12, von = 57, bis = 70, laenge = 14 });
                sART00Beginn.Felder.Add(new Feld() { value = UIDDatenverrechner, feldname = "UIDV", lfdNr = 13, von = 71, bis = 84, laenge = 14 });
                sART00Beginn.Felder.Add(new Feld() { value = ZVR, feldname = "ZVR", lfdNr = 14, von = 85, bis = 93, laenge = 9 });
                sART00Beginn.Felder.Add(new Feld() { value = "40", feldname = "UFACHL", lfdNr = 15, von = 94, bis = 95, laenge = 2 });
                sART00Beginn.Felder.Add(new Feld() { value = AdressCode3, feldname = "VPADR", lfdNr = 16, von = 96, bis = 98, laenge = 3 });
                sART00Beginn.Felder.Add(new Feld() { value = AdressCode3, feldname = "VPADRL", lfdNr = 17, von = 99, bis = 101, laenge = 3 });
                sART00Beginn.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 18, von = 102, bis = 128, laenge = 27 });
                
                rechnung.sART99Nachlauf.AnzahlGesamt++; 
                return sART00Beginn;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART00Beginn: " + ex.Message);
            }
        }

        private VOSchein MakeVOSchein(int PosNr, string FamName, string Vorname, string SVNr, string VPArzt, double Netto, string KategorieCode)
        {
            try
            {
                VOSchein voschein = new VOSchein();
                voschein.sART01 = MakeSART01(PosNr, FamName, Vorname, SVNr, VPArzt, KategorieCode);
                voschein.Versorgungseinheiten.Add(MakeVersorgungseinheiten(Netto));
                voschein.sART34 = MakeSART34(voschein.Versorgungseinheiten);
                return voschein;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeVOSchein: " + ex.Message);
            }
        }

        private Versorgunseinheit MakeVersorgungseinheiten(double Netto)
        {
            try
            {
                Versorgunseinheit versorgungeseinheit = new Versorgunseinheit();
                versorgungeseinheit.Positionen.Add(MakePosition(Netto));
                versorgungeseinheit.sART32 = MakeSART32(versorgungeseinheit.Positionen);
                return versorgungeseinheit;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeVersorgungseinheiten: " + ex.Message);
            }
        }

        private Position MakePosition(double Netto)
        {
            try
            {
                Position position = new Position();
                position.sART30 = MakeSART30(Netto);
                return position;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakePosition: " + ex.Message);
            }
        }

        private SART01 MakeSART01(int PosNr, string FamName, string Vorname, string SVNr, string VPArzt, string KategorieCode)
        {
            try
            {
                SART01 sART01 = new SART01();
                sART01.Kopf = MakeSatzkopf();
                sART01.Felder.Add(new Feld() { value = "01", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART01.Felder.Add(new Feld() { value = DatenVerrechner, feldname = "VSTRL", lfdNr = 3, von = 23, bis = 24, laenge = 2 });
                sART01.Felder.Add(new Feld() { value = BundeslandDatenVerrechner, feldname = "BLNDL", lfdNr = 4, von = 25, bis = 26, laenge = 2 });
                sART01.Felder.Add(new Feld() { value = PosNr, feldname = "VONR", lfdNr = 5, von = 26, bis = 30, laenge = 5, typ = FeldTyp.NumRechts0 });
                sART01.Felder.Add(new Feld() { value = "0", feldname = "EREIG", lfdNr = 6, von = 31, bis = 31, laenge = 1 });
                sART01.Felder.Add(new Feld() { value = "0", feldname = "FREM", lfdNr = 7, von = 32, bis = 32, laenge = 1 });
                sART01.Felder.Add(new Feld() { value = FamName, feldname = "ZUNVS", lfdNr = 8, von = 33, bis = 62, laenge = 30 });
                sART01.Felder.Add(new Feld() { value = Vorname, feldname = "VONVS", lfdNr = 9, von = 63, bis = 77, laenge = 15 });
                sART01.Felder.Add(new Feld() { value = KategorieCode, feldname = "KAT", lfdNr = 11, von = 88, bis = 90, laenge = 3 });
                sART01.Felder.Add(new Feld() { value = new DateTime(Convert.ToInt32(Abrechnungsjahr), Convert.ToInt32(Abrechnungsmonat), 1), feldname = "VDAT", lfdNr = 12, von = 91, bis = 96, laenge = 6, typ = FeldTyp.DateTimeddMMyy});
                sART01.Felder.Add(new Feld() { value = new DateTime(Convert.ToInt32(Abrechnungsjahr), Convert.ToInt32(Abrechnungsmonat), 1), feldname = "UDAT", lfdNr = 13, von = 97, bis = 102, laenge = 6, typ = FeldTyp.DateTimeddMMyy });
                sART01.Felder.Add(new Feld() { value = VPArzt, feldname = "VPNUW", lfdNr = 14, von = 103, bis = 108, laenge = 6 });
                sART01.Felder.Add(new Feld() { value = "0", feldname = "VOART", lfdNr = 15, von = 109, bis = 109, laenge = 1 });
                sART01.Felder.Add(new Feld() { value = "", feldname = "UNDAT", lfdNr = 16, von = 110, bis = 115, laenge = 6 });
                sART01.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "VPNRL", lfdNr = 17, von = 116, bis = 121, laenge = 6 });
                sART01.Felder.Add(new Feld() { value = AdressCode2, feldname = "VPADRL", lfdNr = 18, von = 122, bis = 123, laenge = 2 });
                sART01.Felder.Add(new Feld() { value = FachgebietLeistungserbringer, feldname = "FACHL", lfdNr = 19, von = 124, bis = 125, laenge = 2 });
                sART01.Felder.Add(new Feld() { value = BundelandLeistungserbringer, feldname = "BLLE", lfdNr = 20, von = 126, bis = 126, laenge = 1 });
                sART01.Felder.Add(new Feld() { value = "0", feldname = "VORZ", lfdNr = 21, von = 127, bis = 127, laenge = 1 });
                sART01.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 22, von = 128, bis = 128, laenge = 1 });

                rechnung.sART99Ende.Anzahl01++;
                rechnung.sART99Nachlauf.AnzahlGesamt++;
                return sART01;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART01: " + ex.Message);
            }
        }

        private SART30 MakeSART30(double Betrag)
        {
            try
            {
                //string sBetrag = Betrag.ToString("F2").Replace(".", "").Replace(";", "").PadLeft(6, '0');
                SART30 sART30 = new SART30();
                sART30.Kopf = MakeSatzkopf();
                sART30.Felder.Add(new Feld() { value = "30", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART30.Felder.Add(new Feld() { value = 0, feldname = "POSNR", lfdNr = 3, von = 23, bis = 40, laenge = 18, typ = FeldTyp.NumRechts0 });
                sART30.Felder.Add(new Feld() { value = "000100", feldname = "ANZ", lfdNr = 4, von = 41, bis = 46, laenge = 6 });
                sART30.Felder.Add(new Feld() { value = Betrag, feldname = "BETR", lfdNr = 5, von = 47, bis = 54, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART30.Felder.Add(new Feld() { value = Verrechnungsart, feldname = "VART", lfdNr = 6, von = 55, bis = 56, laenge = 2 });
                sART30.Felder.Add(new Feld() { value = MwStSatz, feldname = "UST", lfdNr = 7, von = 57, bis = 58, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART30.Felder.Add(new Feld() { value = "", feldname = "ABLG", lfdNr = 7, von = 59, bis = 61, laenge = 3 });
                sART30.Felder.Add(new Feld() { value = PositionText, feldname = "POSTXT", lfdNr = 8, von = 62, bis = 76, laenge = 15 });
                sART30.Felder.Add(new Feld() { value = "", feldname = "AUGEN", lfdNr = 9, von = 77, bis = 123, laenge = 47 });
                sART30.Felder.Add(new Feld() { value = "", feldname = "KART", lfdNr = 30, von = 124, bis = 124, laenge = 1 });
                sART30.Felder.Add(new Feld() { value = "0", feldname = "VORZ", lfdNr = 31, von = 125, bis = 125, laenge = 1 });
                sART30.Felder.Add(new Feld() { value = "", feldname = "KREG", lfdNr = 32, von = 126, bis = 126, laenge = 1 });
                sART30.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 33, von = 127, bis = 128, laenge = 2 });
                sART30.Netto = Betrag;

                rechnung.sART99Ende.Anzahl30++;
                rechnung.sART99Nachlauf.AnzahlGesamt++; 
                return sART30;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART30: " + ex.Message);
            }
        }

        private SART32 MakeSART32(List<Position> Positionen)
        {
            try
            {
                SART32 sART32 = new SART32();
                foreach (Position pos in Positionen)
                {
                    sART32.Netto += pos.sART30.Netto;
                }
                sART32.Brutto = Math.Round(sART32.Netto * ((100 + MwStSatz) / 100), 2, MidpointRounding.AwayFromZero);

                sART32.Kopf = MakeSatzkopf();
                sART32.Felder.Add(new Feld() { value = "32", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "PROZ", lfdNr = 3, von = 23, bis = 24, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART32.Felder.Add(new Feld() { value = sART32.Brutto, feldname = "KAL", lfdNr = 4, von = 25, bis = 34, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = sART32.Brutto - sART32.Netto, feldname = "KALUST", lfdNr = 4, von = 35, bis = 42, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "VANT", lfdNr = 5, von = 43, bis = 50, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "VANTUST", lfdNr = 6, von = 51, bis = 56, laenge = 6, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = sART32.Brutto, feldname = "GESUB", lfdNr = 8, von = 57, bis = 66, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = sART32.Netto, feldname = "GESUM", lfdNr = 9, von = 67, bis = 76, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = "", feldname = "DATE", lfdNr = 10, von = 77, bis = 82, laenge = 6, typ = FeldTyp.DateEmpty000000 });
                sART32.Felder.Add(new Feld() { value = "", feldname = "DATR", lfdNr = 11, von = 83, bis = 88, laenge = 6 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "REHA", lfdNr = 12, von = 89, bis = 90, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "ABLG", lfdNr = 13, von = 91, bis = 93, laenge = 3, typ = FeldTyp.NumRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "REZANZ", lfdNr = 14, von = 94, bis = 95, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART32.Felder.Add(new Feld() { value = "N", feldname = "BHKZ", lfdNr = 15, von = 96, bis = 96, laenge = 1 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "BEPROZ", lfdNr = 16, von = 97, bis = 104, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "AUFZAHL", lfdNr = 17, von = 105, bis = 110, laenge = 6, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = 0, feldname = "REZSUM", lfdNr = 18, von = 111, bis = 118, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART32.Felder.Add(new Feld() { value = "0", feldname = "VORZ", lfdNr = 19, von = 119, bis = 119, laenge = 1 });
                sART32.Felder.Add(new Feld() { value = "0", feldname = "VZV", lfdNr = 20, von = 120, bis = 120, laenge = 1 });
                sART32.Felder.Add(new Feld() { value = "0", feldname = "VZG", lfdNr = 21, von = 121, bis = 121, laenge = 1 });
                sART32.Felder.Add(new Feld() { value = "0", feldname = "VZR", lfdNr = 22, von = 122, bis = 122, laenge = 1 });
                sART32.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 23, von = 123, bis = 128, laenge = 6 });

                rechnung.sART99Ende.Anzahl32++;
                rechnung.sART99Nachlauf.AnzahlGesamt++; 
                return sART32;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART32: " + ex.Message);
            }
        }

        private SART34 MakeSART34(List<Versorgunseinheit> Versorgunseinheiten)
        {
            try
            {
                SART34 sART34 = new SART34();
                foreach (Versorgunseinheit versorgungseinheit  in Versorgunseinheiten)
                {
                    sART34.Netto += versorgungseinheit.sART32.Netto;
                }
                sART34.Brutto = Math.Round(sART34.Netto * ((100 + MwStSatz) / 100), 2, MidpointRounding.AwayFromZero);

                sART34.Kopf = MakeSatzkopf();
                sART34.Felder.Add(new Feld() { value = "34", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART34.Felder.Add(new Feld() { value = sART34.Brutto, feldname = "KAL", lfdNr = 3, von = 23, bis = 32, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = sART34.Brutto - sART34.Netto, feldname = "KALUST", lfdNr = 4, von = 33, bis = 40, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = 0, feldname = "VANT", lfdNr = 5, von = 41, bis = 48, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = 0, feldname = "VANTUST", lfdNr = 6, von = 49, bis = 54, laenge = 6, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = sART34.Brutto, feldname = "GESUB", lfdNr = 7, von = 55, bis = 64, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = sART34.Netto, feldname = "GESUM", lfdNr = 8, von = 65, bis = 74, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = 0, feldname = "BHG", lfdNr = 9, von = 75, bis = 84, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = "", feldname = "BEWNR", lfdNr = 10, von = 85, bis = 92, laenge = 8 });
                sART34.Felder.Add(new Feld() { value = 0, feldname = "REZANZ", lfdNr = 11, von = 93, bis = 94, laenge = 2, typ = FeldTyp.NumRechts0 });
                sART34.Felder.Add(new Feld() { value = 0, feldname = "REZSUM", lfdNr = 12, von = 95, bis = 102, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART34.Felder.Add(new Feld() { value = "0", feldname = "VZK", lfdNr = 13, von = 103, bis = 103, laenge = 1 });
                sART34.Felder.Add(new Feld() { value = "0", feldname = "VZV", lfdNr = 14, von = 104, bis = 104, laenge = 1 });
                sART34.Felder.Add(new Feld() { value = "0", feldname = "VZG", lfdNr = 15, von = 105, bis = 105, laenge = 1 });
                sART34.Felder.Add(new Feld() { value = "0", feldname = "VZR", lfdNr = 16, von = 106, bis = 106, laenge = 1 });
                sART34.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 17, von = 107, bis = 128, laenge = 22 });

                rechnung.sART99Ende.Anzahl34++;
                rechnung.sART99Nachlauf.AnzahlGesamt++; 
                return sART34;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART34: " + ex.Message);
            }
        }


        private SART36 MakeSART36(List<VOSchein> VOScheine)
        {
            try
            {
                SART36 sART36 = new SART36();
                foreach (VOSchein voschein in VOScheine)
                {
                    sART36.Netto += voschein.sART34.Netto;
                }
                sART36.Brutto = Math.Round(sART36.Netto * ((100 + MwStSatz) / 100), 2, MidpointRounding.AwayFromZero);

                sART36.Kopf = MakeSatzkopf();
                sART36.Felder.Add(new Feld() { value = "36", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                sART36.Felder.Add(new Feld() { value = Rechnungsnummer, feldname = "RENR", lfdNr = 3, von = 23, bis = 32, laenge = 10 });
                sART36.Felder.Add(new Feld() { value = Rechnungsdatum, feldname = "RDAT", lfdNr = 4, von = 33, bis = 38, laenge = 6 , typ = FeldTyp.DateTimeddMMyy});
                sART36.Felder.Add(new Feld() { value = sART36.Brutto, feldname = "KAL", lfdNr = 5, von = 39, bis = 48, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = sART36.Brutto - sART36.Netto, feldname = "KALUST", lfdNr = 6, von = 49, bis = 56, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "VANT", lfdNr = 7, von = 57, bis = 64, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "VANTUST", lfdNr = 8, von = 65, bis = 72, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "PSKO", lfdNr = 9, von = 73, bis = 76, laenge = 4, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "SKO", lfdNr = 10, von = 77, bis = 84, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "RAB", lfdNr = 11, von = 85, bis = 92, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "REZANZ", lfdNr = 12, von = 93, bis = 96, laenge = 4, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = 0, feldname = "REZSUM", lfdNr = 13, von = 97, bis = 104, laenge = 8, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = sART36.Brutto, feldname = "GESUB", lfdNr = 14, von = 105, bis = 114, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = sART36.Netto, feldname = "GESUM", lfdNr = 15, von = 115, bis = 124, laenge = 10, typ = FeldTyp.CentRechts0 });
                sART36.Felder.Add(new Feld() { value = "0", feldname = "VZK", lfdNr = 16, von = 125, bis = 125, laenge = 1 });
                sART36.Felder.Add(new Feld() { value = "0", feldname = "VZV", lfdNr = 17, von = 126, bis = 126, laenge = 1 });
                sART36.Felder.Add(new Feld() { value = "0", feldname = "VZG", lfdNr = 18, von = 127, bis = 127, laenge = 1 });
                sART36.Felder.Add(new Feld() { value = "0", feldname = "VZR", lfdNr = 19, von = 128, bis = 128, laenge = 1 });

                rechnung.sART99Ende.Anzahl36++;
                rechnung.sART99Nachlauf.AnzahlGesamt++; 
                return sART36;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART36: " + ex.Message);
            }
        }

        private void UpdateSART99Ende()
        {
            try
            {
                rechnung.sART99Ende.Kopf = MakeSatzkopf();
                rechnung.sART99Ende.Felder.Add(new Feld() { value = "99", feldname = "SART", lfdNr = 2, von = 21, bis = 22, laenge = 2 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl01, feldname = "ANZ01", lfdNr = 3, von = 23, bis = 27, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl02, feldname = "ANZ02", lfdNr = 4, von = 28, bis = 32, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl06, feldname = "ANZ06", lfdNr = 5, von = 33, bis = 37, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl30, feldname = "ANZ30", lfdNr = 6, von = 38, bis = 42, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl32, feldname = "ANZ32", lfdNr = 7, von = 43, bis = 47, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl34, feldname = "ANZ34", lfdNr = 8, von = 48, bis = 52, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl36, feldname = "ANZ36", lfdNr = 9, von = 53, bis = 57, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl39, feldname = "ANZ39", lfdNr = 10, von = 58, bis = 62, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl07, feldname = "ANZ07", lfdNr = 11, von = 63, bis = 67, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = 1, feldname = "ANDP", lfdNr = 12, von = 63, bis = 67, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl11, feldname = "ANZ11", lfdNr = 13, von = 70, bis = 74, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = rechnung.sART99Ende.Anzahl85, feldname = "ANZ85", lfdNr = 14, von = 75, bis = 79, laenge = 5, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Ende.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 15, von = 80, bis = 128, laenge = 49 });
                rechnung.sART99Nachlauf.AnzahlGesamt++;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART99Ende: " + ex.Message);
            }
        }

        private void UpdateSART99Nachlauf()
        {
            try
            {
                rechnung.sART99Nachlauf.AnzahlGesamt++;
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = "00", feldname = "SART", lfdNr = 1, von = 1, bis = 2, laenge = 2 });
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 2, von = 3, bis = 9, laenge = 7 });
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = DatenÜbernehmer, feldname = "VSTRU", lfdNr = 3, von = 10, bis = 11, laenge = 2 });   //ÖGK-Kärnten
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = Vertragspartnernummer, feldname = "OBUS", lfdNr = 4, von = 12, bis = 18, laenge = 7 });
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = DatenVerrechner, feldname = "VSTR", lfdNr = 5, von = 19, bis = 20, laenge = 2 });
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = rechnung.sART99Nachlauf.AnzahlGesamt, feldname = "SANZ", lfdNr = 6, von = 21, bis = 26, laenge = 6, typ = FeldTyp.NumRechts0 });
                rechnung.sART99Nachlauf.Felder.Add(new Feld() { value = "", feldname = "RES", lfdNr = 7, von = 27, bis = 128, laenge = 102 });
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeSART99Nachlauf: " + ex.Message);
            }
        }


        private string FlushText(string TxtFile, ref string retLog)
        {
            try
            {
                StringBuilder res = new StringBuilder();

                Log.Append("Start\n");
                res.Append(TextFromFelder(rechnung.sART00Vorlauf.Felder, typeof(SART00Vorlauf), null));
                Log.Append("Satzart 00 Vorlauf fertig.\n");
                res.Append(TextFromFelder(rechnung.sART00Beginn.Felder, typeof(SART00Beginn), rechnung.sART00Beginn.Kopf));
                Log.Append("Satzart 00 Datensatzbeginn fertig.\n");

                foreach (VOSchein voschein in rechnung.VOScheine)
                {
                    res.Append(TextFromFelder(voschein.sART01.Felder, typeof(SART01), voschein.sART01.Kopf));
                    Log.Append("Verordnungsschein für " + voschein.sART01.Felder[6].value + " " + voschein.sART01.Felder[7].value + "\n");
                    foreach (Versorgunseinheit versorgunseinheit in voschein.Versorgungseinheiten)
                    {
                        foreach(Position position in versorgunseinheit.Positionen)
                        {
                            res.Append(TextFromFelder(position.sART30.Felder, typeof(SART30), position.sART30.Kopf));
                        }
                        res.Append(TextFromFelder(versorgunseinheit.sART32.Felder, typeof(SART32), versorgunseinheit.sART32.Kopf));
                    }
                    res.Append(TextFromFelder(voschein.sART34.Felder, typeof(SART34), voschein.sART34.Kopf));
                }
                res.Append(TextFromFelder(rechnung.sART36.Felder, typeof(SART36), rechnung.sART36.Kopf));
                Log.Append("Satzart 36 fertig.\n");
                res.Append(TextFromFelder(rechnung.sART99Ende.Felder, typeof(SART99Ende), rechnung.sART99Ende.Kopf));
                Log.Append("Satzart 00 Datensatzende fertig.\n");
                res.Append(TextFromFelder(rechnung.sART99Nachlauf.Felder, typeof(SART99Nachlauf), null));
                Log.Append("Satzart 00 Nachlauf fertig.\n");

                if (!HasError)
                {
                    System.IO.File.WriteAllText(TxtFile, res.ToString());
                    Log.Append("Ausgabedatei erstellt: " +  TxtFile + "\n");
                }
                else
                {
                    MessageBox.Show("Es sind Fehler aufgetreten. Bitte prüfen Sie die Log-Information.", "Hinweis");
                }
                retLog = Log.ToString();
                return res.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.FlushText: " + ex.Message);
            }
        }

        private StringBuilder TextFromFelder(List<Feld> Felder, System.Type st, Satzkopf Kopf)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (Kopf != null)
                {
                    sb.Append(FelderToString(Kopf.Felder, true));        //Muss 20 Zeichen lang sein
                }
                sb.Append(FelderToString(Felder, false));           //Muss 128 Zeichen lang sein
                sb.Append("\r\n");
                return sb;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.TextFromFelder: " + ex.Message);
            }
        }

        private StringBuilder FelderToString(List<Feld> Felder, bool IsHeader)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (Feld f in Felder)
                {
                    TypeCode tc = Type.GetTypeCode(f.value.GetType());
                    string txt = "";

                    if (f.typ == FeldTyp.CharLinks && tc == TypeCode.String)
                    {
                        txt = f.value.ToString().Trim().PadRight(f.laenge, ' ');
                    }
                    else if (f.typ == FeldTyp.CharRechts && tc == TypeCode.String)
                    {
                        txt = f.value.ToString().Trim().PadLeft(f.laenge, ' ');
                    }
                    else if (f.typ == FeldTyp.NumLinks && (tc == TypeCode.Double || tc == TypeCode.Int32))
                    {
                        txt = f.value.ToString().Trim().PadRight(f.laenge, ' ');
                    }
                    else if (f.typ == FeldTyp.NumRechts && (tc == TypeCode.Double || tc == TypeCode.Int32))
                    {
                        txt = f.value.ToString().Trim().PadLeft(f.laenge, ' ');
                    }
                    else if (f.typ == FeldTyp.NumRechts0 && (tc == TypeCode.Double || tc == TypeCode.Int32))
                    {
                        txt = f.value.ToString().Trim().PadLeft(f.laenge, '0');
                    }
                    else if (f.typ == FeldTyp.CentRechts0 && tc == TypeCode.Int32)
                    {
                        txt = Convert.ToInt32(f.value).ToString("F2").Replace(",", "").Replace(".'", "").PadLeft(f.laenge, '0');
                    }
                    else if (f.typ == FeldTyp.CentRechts0 && tc == TypeCode.Double)
                    {
                        txt = Convert.ToDouble(f.value).ToString("F2").Replace(",", "").Replace(".'", "").PadLeft(f.laenge, '0');
                    }
                    else if (f.typ == FeldTyp.DateTimeddMMyy && tc == TypeCode.DateTime)
                    {
                        txt = Convert.ToDateTime(f.value).ToString("ddMMyy");
                    }
                    else if (f.typ == FeldTyp.DateTimeddMMyyyy && tc == TypeCode.DateTime)
                    {
                        txt = Convert.ToDateTime(f.value).ToString("ddMMyyyy");
                    }
                    else if (f.typ == FeldTyp.DateTimeHHmmss && tc == TypeCode.DateTime)
                    {
                        txt = Convert.ToDateTime(f.value).ToString("HHmmss");
                    }
                    else if (f.typ == FeldTyp.DateEmpty000000)
                    {
                        txt = "".PadRight(f.laenge, ' ');;
                    }
                    else
                    {
                        Log.Append("Error in Converting to Text:" + f.feldname);
                        HasError = true;
                        return sb;
                    }

                    if (f.laenge != txt.Length)
                    {
                        Log.Append("Error in length of Text:" + f.feldname);
                        HasError = true;
                        return sb;
                    }

                    if (f.bis - f.von != f.laenge - 1)
                    {
                        Log.Append("Error in definiton (von, bis length) of cell:" + f.feldname);
                        HasError = true;
                        return sb;
                    }

                    sb.Append(txt);
                }
                return sb;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.db.cELDAInterfaceDB.cs.MakeZeile: " + ex.Message);
            }
        }


    }
}