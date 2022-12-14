using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMDS.Calc.Logic;
using PMDS.DB;
using PMDS.db.Entities;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using S2Extensions;
using Infragistics.Documents.Excel;
using ScintillaNET.Demo;

namespace PMDS.Global
{
    public class FSWAbrechnung
    {
        private static string DateFormat = "yyyy-MM-dd";
        private static string DateTimeFormat = "yyyyMMddHHmmss";
        private string eZAUFID = DateTime.Now.ToString("yyMMddHHmmss");
        private string eZAUFIDBW = DateTime.Now.ToString("yyMMddHHmmss") + "BW";
        private string Msg = "";

        private class Leistungszeile
        {
            public Guid IDRechnung;
            public Guid IDRechnungszeile;
        }

        public class XMLInfo
        {
            public Chilkat.Xml Xml { get; set; } = new Chilkat.Xml();
            public db.cEBInterfaceDB.Transaction Transaction { get; set; }  = new db.cEBInterfaceDB.Transaction();
            public string FQFileXML { get; set; } = "";
            public string FQFileXLSX { get; set; } = "";
            public bool bIsvalid { get; set; }= true;
        }

        private List<string> ListIDBillsFSW { get; set; } = new List<string>();                   //Sammelt die Rechungen des FSW
        private List<string> ListIDBillsFSWBW { get; set; } = new List<string>();                 //Sammelt die Rechungen des FSW für betreutes Wohnen
        private List<Chilkat.Xml> ListFSWXml = new List<Chilkat.Xml>();
       
        private db.cEBInterfaceDB.Transaction Transaction { get; set; } = db.cEBInterfaceDB.NewTransaction(true);
        private db.cEBInterfaceDB.Transaction TransactionBW { get; set; } = db.cEBInterfaceDB.NewTransaction(false);
        //private ExcelEngine _FSWXlsx = new ExcelEngine();
        private List<xlsxWorkbook> _FSWXlsx = new List<xlsxWorkbook>();

        public class  xlsxWorkbook
        {
            public Workbook wb;
            public string Filename;
        }

        private eAction _RunAction;
        private List<XlsVorschauZeile> lstXlsVorschauZeilen = new List<XlsVorschauZeile>();

        private class XlsVorschauZeile
        {
            public string Nachname;
            public string Vorname;
            public string Text;
            public double Netto;
            public double MwStSatz;
            public int Anzahl;
            public string FiBu;
            public DateTime ReDatum;
            public DateTime Monat;
            public string SVNr;
            public bool bIsPflege;
        }

        private List<TmpLineItem> lTmpLineItems = new List<TmpLineItem>();

        private class TmpLineItem
        {
            public string Rechungsnummer = "";
            public string Description = "";
            public int Quantity = 0;
            public decimal PreisProEinheit = 0;
            public int TaxPercent = 0;
            public decimal LineItemAmount = 0;
            public decimal TaxableAmount = 0;
            public decimal Tax = 0;
            public bool bIsPflege = true;
            public string IDLeistung = "";
            public bool bIsStorno = false;
            public bool bIsReduziert = false;
            public string FiBu = "";
        }


        public eAction RunAction
        {
            get { return _RunAction;  }
            set { _RunAction = value; }
        }

        public enum eAction
        {
            fsw = 7,
            fswreset = 8,
            fswNoUpload = 9,
            fswXlsVorschau = 10,
            fswsFTPOnly = 11
        }

        //------------------------ ebInterface / Abrechnungsschittstelle zum FSW -----------------------------
        public void GenerateFSWStructure(Guid IDKlinik, List<string> ListIDBills, eAction Action)
        {
            try
            {
                RunAction = Action;

                using (PMDS.db.Entities.ERModellPMDSEntities db = calculation.delgetDBContext.Invoke())
                {
                    List<string> lBW_Leistungen = new List<string>();                                       //Liste der Leistungen für Betreutes Wohnen
                    using (PMDS.db.Entities.ERModellPMDSEntities db1 = DB.PMDSBusiness.getDBContext())
                    {
                        lBW_Leistungen = (from aw in db.AuswahlListe
                                          where aw.IDAuswahlListeGruppe == "FSW"
                                          select aw.Bezeichnung.Trim() ).ToList();
                    }

                    string ret = "";
                    string MsgBoxTitle = "";
                    
                    switch (Action)
                    {
                        case eAction.fsw:
                            MsgBoxTitle = "FSW-Zahlungsaufforderung erstellen und senden";
                            break;
                        case eAction.fswNoUpload:
                            MsgBoxTitle = "FSW-Zahlungsaufforderung erstellen und NICHT senden";
                            break;
                        case eAction.fswreset:
                            //Sammelrechnung-ID (eZAUFF) zurücksetzen
                            if (ListIDBills.Count() > 0)
                            {
                                MsgBoxTitle = "FSW-Status für Zahlungsaufforderung zurücksetzen";
                                ret = SetIDSR(ListIDBills, "", db);
                                if (ret.Length == 0)
                                {
                                    string sTxt = ListIDBills.Count().sIntToWords("e") + " Rechnung".sMehrzahlText(ListIDBills.Count(), "en"); 

                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der eZAUFF-Zustatus wurde für " + sTxt + " zurückgesetzt.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                }
                                else
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Zurücksetzen des eZAUFF-Status: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Rechnungen ausgewählt. Es wurde nichts zurückgesetzt.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                            }
                            return;

                        case eAction.fswXlsVorschau:
                            MsgBoxTitle = "Excel-Vorschau für FSW-Abrechnung erstellen";
                            break;

                        case eAction.fswsFTPOnly:
                            OpenFileDialog fd = new OpenFileDialog();
                            fd.InitialDirectory = ENV.FSW_EZAUF;
                            fd.Title = "Bitte wählen Sie eine XML-Datei für das Hochladen per SFTP an den FSW aus";
                            fd.Filter = "eZAUFF-Files|*.xml";
                            fd.CheckFileExists = true;
                            fd.CheckPathExists = true;
                            fd.Multiselect = false;

                            if (fd.ShowDialog() == DialogResult.OK)
                            {
                                if (File.Exists(fd.FileName))
                                {
                                    string retsFTP = Upload(Path.GetFileNameWithoutExtension(fd.FileName) + Path.GetExtension(fd.FileName)  , fd.FileName, out string Log);
                                    if (retsFTP.Length > 0)
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Hochladen der Zahlungsaufforderung: " + retsFTP, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zielumgebung = " + ENV.FSW_FTPMode + "\nDie eZAUFF wurde per sFTP hochgeladen: " + fd.FileName, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    }
                                }
                            }
                            return;
                    }

                    decimal Rechnungsbetrag = 0;
                    decimal Steuern = 0;
                    decimal RechnungsbetragBW = 0;
                    decimal SteuernBW = 0;

                    foreach (string IDBill in ListIDBills ?? new List<string>())
                    {
                        bills rBill = readBill(IDBill);
                        billHeader rHeader = readBillHeader(rBill.IDAbrechnung, IDKlinik);
                        using (dbCalc dbCalc = getDBCalc(rHeader.dbCalc))
                        {
                            if (rBill.IDSR.Length > 0  && !rBill.IDSR.Any(c => Guid.TryParse(rBill.IDSR, out Guid guidID)) && RunAction == eAction.fsw)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereits gesendete Rechnungen können nicht nocheinmal gesendet werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            string VersicherungsNr = "";
                            using (PMDS.db.Entities.ERModellPMDSEntities db2 = calculation.delgetDBContext.Invoke())
                            {
                                using (PMDS.db.Entities.ERModellPMDSEntities db3 = DB.PMDSBusiness.getDBContext())
                                {
                                    Guid IDKlient = new Guid((from kl in dbCalc.Klient select kl).FirstOrDefault().ID.ToString());
                                    VersicherungsNr = (from kl in db3.Patient where kl.ID == IDKlient select kl.VersicherungsNr).FirstOrDefault().ToString();
                                }
                            }
                            PMDS.Global.db.cEBInterfaceDB FSWRechnung = new db.cEBInterfaceDB();
                            PMDS.Global.db.cEBInterfaceDB.Invoice Invoice = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));
                            PMDS.Global.db.cEBInterfaceDB.Invoice InvoiceBW = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));


                            // ----------------- Leistungen für den FSW ermitteln  --------------------
                            lTmpLineItems = new List<TmpLineItem>();

                            List<dbCalc.KostenträgerRow> lKostenträger = new List<dbCalc.KostenträgerRow>();
                            List<dbCalc.ZahlerRow> lZahlungenFSW = new List<dbCalc.ZahlerRow>();
                            List<dbCalc.ZahlerRow> lZahlungenNoFSW = new List<dbCalc.ZahlerRow>();
                            List<string> lSplitLeistungen = new List<string>();
                            List<dbCalc.TagesleistungenRow> lTagesleistungenNichtReduziert = new List<dbCalc.TagesleistungenRow>();
                            List<dbCalc.TagesleistungenRow> lTagesleistungenReduziert = new List<dbCalc.TagesleistungenRow>();

                            //Alle Zahler ermitteln, für die der FSW direkt oder indirekt zahlt
                            foreach (dbCalc.ZahlerRow z in dbCalc.Zahler)
                            {
                                Guid IDKostIntern = new Guid(z.IDKostIntern);
                                dbCalc.KostenträgerRow rKost = (from kt in dbCalc.Kostenträger
                                                               where kt.IDKostIntern == IDKostIntern.ToString()
                                                               select kt).First();

                                if (FSWIsZahler(new Guid(rKost.IDKost.ToString()), ENV.FSW_IDIntern))
                                {
                                    lZahlungenFSW.Add(z);      //Leistungen, bei denen der FSW zahlt
                                    lKostenträger.Add(rKost);
                                }
                                else
                                {
                                    lZahlungenNoFSW.Add(z);    //Leistungen, bei denen der FSW NICHT zahlt
                                }
                            }

                            foreach (dbCalc.ZahlerRow z in lZahlungenFSW)
                            {
                                foreach (dbCalc.ZahlerRow nz in lZahlungenNoFSW)
                                {
                                    if (z.IDLeistung == nz.IDLeistung)
                                    {
                                        lSplitLeistungen.Add(z.IDLeistung);     //Leistungen, bei den der FSW mitzahlt
                                    }
                                }
                            }

                            //Alle Leistungen ermitteln, für die der FSW zahlt
                            foreach (dbCalc.LeistungenRow l in dbCalc.Leistungen)
                            {
                                foreach (dbCalc.ZahlerRow zFSW in lZahlungenFSW.Where(lZ => lZ.IDLeistung == l.ID))
                                {
                                    bool bIsStorno = rBill.Status == -10 || rBill.RechNr.sEquals("ForStorno;");
                                    decimal dStornoFaktor = (bIsStorno ? -1 : 1);

                                    foreach (dbCalc.TagesleistungenRow tl in dbCalc.Tagesleistungen.Where(tl => tl.IDLeistung == l.ID))
                                    {

                                        foreach (dbCalc.KostenträgerRow rKost in lKostenträger)
                                        {
                                            if (tl.Datum.Date < rKost.von || tl.Datum.Date > rKost.bis)
                                                continue;

                                            if (!tl.ReduziertJN)
                                            {
                                                lTagesleistungenNichtReduziert.Add(tl);
                                                break;                                      //Einmal bezahlt reicht.
                                            }
                                            else
                                            {
                                                lTagesleistungenReduziert.Add(tl);
                                                break;
                                            }
                                        }
                                    }

                                    //Leistungen können im Zeitablauf andere Preise haben. Anzahl der Tage pro Leistung und Preis ermitteln
                                    //für nicht reduzierte Leistungen
                                    var lTagespreise = lTagesleistungenNichtReduziert.Where(lp => lp.IDLeistung == l.ID).GroupBy(lp => lp.IDLeistung, lp => lp.TagespreisNetto,
                                                    (key, g) => new { ID = key, Tagespreise = g.ToList() });

                                    foreach (var r in lTagespreise)
                                    {
                                        TmpLineItem lz = new TmpLineItem
                                        {
                                            Rechungsnummer = rBill.RechNr,
                                            Description = l.LeistungBezeichnung,
                                            Quantity = lTagesleistungenNichtReduziert.Where(tl => tl.TagespreisNetto == r.Tagespreise[0]).Count() * (int)dStornoFaktor,
                                            PreisProEinheit = r.Tagespreise[0],
                                            TaxPercent = l.MWStSatz,
                                            LineItemAmount = (decimal)r.Tagespreise.Count() * r.Tagespreise[0] * dStornoFaktor,
                                            TaxableAmount = (decimal)r.Tagespreise.Count() * r.Tagespreise[0] * dStornoFaktor,
                                            Tax = Math.Round((decimal)r.Tagespreise.Count() * r.Tagespreise[0] * dStornoFaktor * (decimal)l.MWStSatz / 100, 2, MidpointRounding.AwayFromZero),
                                            bIsPflege = CheckIsPflege(l.LeistungBezeichnung, lBW_Leistungen),
                                            IDLeistung = l.ID,
                                            bIsStorno = bIsStorno,
                                            bIsReduziert = false,
                                            FiBu = l.FIBU
                                        };
                                        lTmpLineItems.Add(lz);
                                    }

                                    //für reduzierte Leistungen
                                    var lTagespreiseNR = lTagesleistungenReduziert.Where(lp => lp.IDLeistung == l.ID).GroupBy(lp => lp.IDLeistung, lp => lp.TagespreisReduziertNetto,
                                                    (key, g) => new { ID = key, TagespreisReduziertNetto = g.ToList() });

                                    foreach (var r in lTagespreiseNR)
                                    {
                                        TmpLineItem lz = new TmpLineItem
                                        {
                                            Rechungsnummer = rBill.RechNr,
                                            Description = l.LeistungBezeichnung,
                                            Quantity = lTagesleistungenReduziert.Where(tl => tl.TagespreisReduziertNetto == r.TagespreisReduziertNetto[0]).Count() * (int)dStornoFaktor,
                                            PreisProEinheit = r.TagespreisReduziertNetto[0],
                                            TaxPercent = l.MWStSatz,
                                            LineItemAmount = (decimal)r.TagespreisReduziertNetto.Count() * r.TagespreisReduziertNetto[0] * dStornoFaktor,
                                            TaxableAmount = (decimal)r.TagespreisReduziertNetto.Count() * r.TagespreisReduziertNetto[0] * dStornoFaktor,
                                            Tax = Math.Round((decimal)r.TagespreisReduziertNetto.Count() * r.TagespreisReduziertNetto[0] * dStornoFaktor * (decimal)l.MWStSatz / 100, 2, MidpointRounding.AwayFromZero),
                                            bIsPflege = CheckIsPflege(l.LeistungBezeichnung, lBW_Leistungen),
                                            IDLeistung = l.ID,
                                            bIsStorno = bIsStorno,
                                            bIsReduziert = true,
                                            FiBu = l.FIBU
                                        };
                                        lTmpLineItems.Add(lz);
                                    }
                                }
                            }

                            Invoice.InvoiceNumber = rBill.RechNr;
                            Invoice.InvoiceDate = (DateTime)rBill.RechDatum;
                            Invoice.Delivery.Period.FromDate = dbCalc.Monate[0].Beginn;
                            Invoice.Delivery.Period.ToDate = dbCalc.Monate[0].Ende;

                            InvoiceBW.InvoiceNumber = rBill.RechNr;
                            InvoiceBW.InvoiceDate = (DateTime)rBill.RechDatum;
                            InvoiceBW.Delivery.Period.FromDate = dbCalc.Monate[0].Beginn;
                            InvoiceBW.Delivery.Period.ToDate = dbCalc.Monate[0].Ende;


                            if (rBill.RollungAnz > 0 || rBill.Status == -10 || rBill.IDBillsGerollt.Length > 0)
                            {
                                Invoice.Details.HeaderDescription = "Korrektur zur Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                                InvoiceBW.Details.HeaderDescription = "Korrektur zur Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                            }
                            else
                            {
                                Invoice.Details.HeaderDescription = "Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                                InvoiceBW.Details.HeaderDescription = "Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                            }

                            // ------------------------------------------------------------------------------------------
                            int PositionNumber = 0;
                            int PositionNumberBW = 0;

                            foreach (TmpLineItem lz in lTmpLineItems)
                            {
                                    if (lz.bIsPflege)
                                    {
                                        PositionNumber++;           //Muss bei jeder Rechnung mit 1 beginnen (unabhängig von der Orginal-Zeilennummer) 
                                        Invoice.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, PositionNumber, lz.Description + (lz.bIsReduziert ? " (reduziert)" : ""), lz.Quantity, lz.PreisProEinheit, lz.LineItemAmount, lz.TaxableAmount, lz.TaxPercent));

                                        Invoice.ReductionAndSurchargeDetails.Surcharge.BaseAmount += lz.LineItemAmount;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Percentage = lz.TaxPercent;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Amount += lz.Tax;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount += lz.TaxableAmount;

                                        Invoice.TotalGrossAmount += lz.LineItemAmount + lz.Tax;
                                        Invoice.PayableAmount = Invoice.TotalGrossAmount;
                                        Invoice.Tax = lz.Tax;

                                        Invoice.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFID;
                                    }
                                    else
                                    {
                                        PositionNumberBW++;           //Muss bei jeder Rechnung mit 1 beginnen (unabhängig von der Orginal-Zeilennummer) 
                                        InvoiceBW.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, PositionNumberBW, lz.Description + (lz.bIsReduziert ? " (reduziert)" : ""), lz.Quantity, lz.PreisProEinheit, lz.LineItemAmount, lz.TaxableAmount, lz.TaxPercent));

                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.BaseAmount += lz.LineItemAmount;
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.Percentage = lz.TaxPercent;
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.Amount += lz.Tax;
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount += lz.TaxableAmount;

                                        InvoiceBW.TotalGrossAmount += lz.LineItemAmount + lz.Tax;
                                        InvoiceBW.PayableAmount = InvoiceBW.TotalGrossAmount;
                                        Invoice.Tax = lz.Tax;

                                        InvoiceBW.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFIDBW;
                                    }

                                    lstXlsVorschauZeilen.Add(new XlsVorschauZeile()
                                    {
                                        Nachname = rBill.KlientName,
                                        Vorname = "",
                                        Text = lz.Description + (lz.bIsReduziert ? " (reduziert)" : ""),
                                        Netto = (double)lz.TaxableAmount,
                                        MwStSatz = lz.TaxPercent,
                                        Anzahl = lz.Quantity,
                                        FiBu = lz.FiBu,
                                        ReDatum = (DateTime)rBill.RechDatum,
                                        Monat = rBill.datum,
                                        SVNr = VersicherungsNr,
                                        bIsPflege = lz.bIsPflege
                                    });                                   
                               
                            }

                            if (Invoice.Details.ItemList.Count > 0)                      //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update){
                            {
                                ListIDBillsFSW.Add(IDBill);
                                Steuern += Invoice.Tax;
                                Rechnungsbetrag += Invoice.PayableAmount;
                                Transaction.ArDocument.AddInvoiceToList(Invoice);
                            }

                            if (InvoiceBW.Details.ItemList.Count > 0)                     //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update)
                            {
                                ListIDBillsFSWBW.Add(IDBill);
                                SteuernBW += InvoiceBW.Tax;
                                RechnungsbetragBW += InvoiceBW.PayableAmount;
                                TransactionBW.ArDocument.AddInvoiceToList(InvoiceBW);
                            }
                        }
                    }

                    if (Action == eAction.fswXlsVorschau && lstXlsVorschauZeilen.Count > 0)
                    {
                        string xlsWorking = System.IO.Path.Combine(ENV.FSW_EZAUF, "FSW_Vorschau_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx");

                        Infragistics.Documents.Excel.Workbook wb = new Infragistics.Documents.Excel.Workbook(WorkbookFormat.Excel2007);
                        Infragistics.Documents.Excel.Worksheet ws = wb.Worksheets.Add("Übersicht FSW-Abrechnung");
                        ws.Rows[0].Cells[0].Value = "Name";
                        ws.Rows[0].Cells[1].Value = "SV-Nr";
                        ws.Rows[0].Cells[2].Value = "Leistung";
                        ws.Rows[0].Cells[3].Value = "Netto Pflege";
                        ws.Rows[0].Cells[4].Value = "Netto BW";
                        ws.Rows[0].Cells[5].Value = "MwSt-Satz";
                        ws.Rows[0].Cells[6].Value = "Anzahl Tage";
                        ws.Rows[0].Cells[7].Value = "FiBu";
                        ws.Rows[0].Cells[8].Value = "Datum erstellt";
                        ws.Rows[0].Cells[9].Value = "Monat/Jahr";

                        ws.Columns[0].Width = 7000;
                        ws.Columns[0].CellFormat.WrapText = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                        ws.Columns[1].Width = 3000;
                        ws.Columns[2].Width = 14000;
                        ws.Columns[2].CellFormat.WrapText = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                        ws.Columns[3].Width = 3000;
                        ws.Columns[4].Width = 3000;
                        ws.Columns[5].Width = 3000;
                        ws.Columns[6].Width = 3000;
                        ws.Columns[7].Width = 3000;
                        ws.Columns[8].Width = 4000;
                        ws.Columns[9].Width = 3000;

                        for (int c = 0; c <= 9; c++)
                        {
                            ws.Rows[0].Cells[c].CellFormat.Fill = CellFill.CreateSolidFill(Color.LightSalmon);
                            ws.Rows[0].Cells[c].CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin;
                            ws.Rows[0].Cells[c].CellFormat.RightBorderStyle = CellBorderLineStyle.Thin;
                        }

                        int z = 0;
                        var dec = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var thousend = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
                        var curency = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                        string EuroString = "#" + thousend + "##0" + dec + "00 [$€-x-euro2]; -#" + thousend + "##" + dec + "00 [$€-x-euro2]; 0,00 [$€-x-euro2]";

                        foreach (XlsVorschauZeile lz in lstXlsVorschauZeilen)
                        {
                            z++;
                            ws.Rows[z].Cells[0].Value = lz.Nachname;
                            ws.Rows[z].Cells[1].Value = lz.SVNr;
                            ws.Rows[z].Cells[2].Value = lz.Text;
                            ws.Rows[z].Cells[2].CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True;

                            if (lz.bIsPflege)
                            {
                                ws.Rows[z].Cells[3].Value = lz.Netto;
                                ws.Rows[z].Cells[3].CellFormat.FormatString = EuroString;
                                ws.Rows[z].Cells[4].CellFormat.FormatString = EuroString;
                                ws.Rows[z].Cells[4].Value = "";
                            }
                            else
                            {
                                ws.Rows[z].Cells[4].Value = lz.Netto;
                                ws.Rows[z].Cells[4].CellFormat.FormatString = EuroString;
                                ws.Rows[z].Cells[3].CellFormat.FormatString = EuroString;
                                ws.Rows[z].Cells[3].Value = "";
                            }
                            ws.Rows[z].Cells[5].Value = lz.MwStSatz;
                            ws.Rows[z].Cells[6].Value = lz.Anzahl;
                            ws.Rows[z].Cells[7].Value = lz.FiBu;


                            ws.Rows[z].Cells[8].Value = lz.ReDatum.Date;
                            ws.Rows[z].Cells[8].CellFormat.FormatString = "dd.MM.yyyy";

                            ws.Rows[z].Cells[9].Value = lz.Monat.Date;
                            ws.Rows[z].Cells[9].CellFormat.FormatString = "MM-yyyy";
                        }

                        //Summen einfügen
                        ws.Rows[z + 2].Cells[2].Value = "Summen";

                        Infragistics.Documents.Excel.Formula SummePflege = Infragistics.Documents.Excel.Formula.Parse("=SUM($D$1:$D$" + (z + 1).ToString() + ")", Infragistics.Documents.Excel.CellReferenceMode.A1);
                        SummePflege.ApplyTo(ws.Rows[z + 2].Cells[3]);
                        ws.Rows[z + 2].Cells[3].CellFormat.FormatString = EuroString;

                        Infragistics.Documents.Excel.Formula SummeBW = Infragistics.Documents.Excel.Formula.Parse("=SUM($E$1:$E$" + (z + 1).ToString() + ")", Infragistics.Documents.Excel.CellReferenceMode.A1);
                        SummeBW.ApplyTo(ws.Rows[z + 2].Cells[4]);
                        ws.Rows[z + 2].Cells[4].CellFormat.FormatString = EuroString;

                        ws.Rows[z + 4].Cells[2].Value = "GESAMTSUMME";
                        Infragistics.Documents.Excel.Formula Summe = Infragistics.Documents.Excel.Formula.Parse("=$D$" + (z + 3).ToString() + " + $E$" + (z + 3).ToString(), Infragistics.Documents.Excel.CellReferenceMode.A1);
                        Summe.ApplyTo(ws.Rows[z + 4].Cells[3]);
                        ws.Rows[z + 4].Cells[3].CellFormat.FormatString = EuroString;

                        wb.Save(xlsWorking);
                        if (File.Exists(xlsWorking))
                        {
                            if (generic.IsExcelInstalled())
                            {
                                System.Diagnostics.Process.Start(xlsWorking);
                                return;
                            }
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datei wurde gespeichert (" + xlsWorking + "), kann aber nicht geöffnet werden, weil Excel nicht installiert ist.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datei " + xlsWorking + "konnte nicht gespeichert werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }
                    else if (lstXlsVorschauZeilen.Count == 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Leistungen mit FSW als Zahler gefunden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                        return;
                    }

                    //Transactions updaten
                    Transaction.SenderAdresse = ENV.FSW_SenderAdresse;
                    Transaction.TransactionID = eZAUFID;
                    Transaction.ArDocument.Referenz = eZAUFID;
                    Transaction.ArDocument.Rechnungsbetrag = Rechnungsbetrag;
                    Transaction.ArDocument.Anzahl_Rechnungen = ListIDBillsFSW.Count;

                    TransactionBW.SenderAdresse = ENV.FSW_SenderAdresse;
                    TransactionBW.TransactionID = eZAUFIDBW;
                    TransactionBW.ArDocument.Referenz = eZAUFIDBW;
                    TransactionBW.ArDocument.Rechnungsbetrag = RechnungsbetragBW;
                    TransactionBW.ArDocument.Anzahl_Rechnungen = ListIDBillsFSWBW.Count;

                    List<XMLInfo> ListXMLInfos = new List<XMLInfo>();
                    XMLInfo XMLInfoPflege = new XMLInfo() { Transaction = Transaction };
                    XMLInfoPflege.bIsvalid = Transaction.ArDocument.Anzahl_Rechnungen > 0;
                    ListXMLInfos.Add(XMLInfoPflege);

                    XMLInfo XMLInfoBW = new XMLInfo() { Transaction = TransactionBW };
                    XMLInfoBW.bIsvalid = TransactionBW.ArDocument.Anzahl_Rechnungen > 0;
                    ListXMLInfos.Add(XMLInfoBW);

                    if (ListIDBillsFSW.Count > 0 || ListIDBillsFSWBW.Count > 0)
                    {
                        List<string> ListIDs = new List<string>();
                        if (RunAction == eAction.fsw || RunAction == eAction.fswNoUpload)
                        {
                            string Filepath = ENV.FSW_EZAUF;    //User nach Speicherort fragen

                            string FilenameXML = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFID + "_" + Transaction.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xml";
                            string FilenameXLSX = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFID + "_" + Transaction.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xlsx";
                            string FQFileXML = Path.Combine(Filepath, FilenameXML);
                            string FQFileXLSX = Path.Combine(Filepath, FilenameXLSX);

                            ListXMLInfos[0].FQFileXML = FQFileXML;
                            ListXMLInfos[0].FQFileXLSX = FQFileXLSX;

                            string FilenameXMLBW = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFIDBW + "_" + TransactionBW.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xml";
                            string FilenameXLSXBW = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFIDBW + "_" + TransactionBW.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xlsx";
                            string FQFileXMLBW = Path.Combine(Filepath, FilenameXMLBW);
                            string FQFileXLSXBW = Path.Combine(Filepath, FilenameXLSXBW);

                            ListXMLInfos[1].FQFileXML = FQFileXMLBW;
                            ListXMLInfos[1].FQFileXLSX = FQFileXLSXBW;

                            using (Chilkat.Global glob = new Chilkat.Global())
                            {
                                if (!glob.UnlockBundle(ENV.ChilkatKey))
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("System-Fehler beim Erstellen der Zahlungsaufforderung:" + glob.LastErrorText, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                                
                                //Transaction -> XML
                                if (!MakeXML(ref ListXMLInfos, out Msg))
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Konvertieren in XML-Export-Format: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }

                                if (!SaveXML(ref ListXMLInfos, out Msg))   //Transaction(s) speichern
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("XML-Exportdatei wurde nicht gespeichert: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                            }

                            if (RunAction == eAction.fswNoUpload)
                            {
                                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("eZAUFF im XML-Export-Format wurde erstellt und gespeichert, aber nicht gesendet.\n\nWollen Sie die Dateien anzeigen?", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.YesNo);
                                if (res == DialogResult.Yes)
                                {
                                    string resShow = ShowXMLContent(ListXMLInfos);
                                    if (!String.IsNullOrWhiteSpace(resShow))
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Anzeigen der Dateiinhalte:\n" + resShow, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    }
                                }
                            }

                            if (ENV.FSW_SaveXLSX)
                            {
                                //Transaction -> XLSX
                                if (!MakeXLSX(ref ListXMLInfos, ref _FSWXlsx, out Msg))
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Konvertieren in Excel (XLSX): " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                                if (!SaveXLSX(_FSWXlsx, out Msg))   //Xlsx Speichern
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Exceldatei für eZAUFF wurde nicht gespeichert: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                            }

                            int iRechnungen = 0;
                            if (RunAction == eAction.fsw)    //Hochladen. Wenn nein -> nur XML erstellen (z.B. für Test)
                            {
                                string Log = "";
                                foreach(XMLInfo f in ListXMLInfos)
                                {
                                    if (!f.bIsvalid)
                                        continue;

                                    bool bIsPflegeZAUFF = f.Transaction.bIsPflegeZAUFF;
                                    FilenameXML = f.Transaction.bIsPflegeZAUFF ? FilenameXML : FilenameXMLBW;
                                    ListIDs = f.Transaction.bIsPflegeZAUFF ? ListIDBillsFSW : ListIDBillsFSWBW;
                                    iRechnungen += ListIDs.Count();
                                    ret = Upload(FilenameXML, f.FQFileXML, out string LogsFTP);
                                    Log += "\n" + LogsFTP;

                                    if (ret.Length > 0)
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Hochladen der Zahlungsaufforderung: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                        return;
                                    }
                                    
                                    ret = SetIDSR(ListIDs, FilenameXML, db);    //Sammelrechnung-ID (ZAUF) setzen
                                    if (ret.Length != 0)
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zahlungsaufforderung wurde gesendet, aber beim Sichern des eZAUFF-Zustands (Kennung Sammelrechnung) ist ein Fehler aufgetreten: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                        return;
                                    }
                                }

                                string sTXTZielumgebung = "Zielumgebung = " + ENV.FSW_FTPMode + "\n";
                                string sTxtZAUFFS = ListXMLInfos.Count().sIntToWords("e ", true) + " Zahlungsaufforderung".sMehrzahlText(ListXMLInfos.Count(), "en");
                                string sTxtRechnungen = iRechnungen.sIntToWords("e") + " Rechnung".sMehrzahlText(iRechnungen, "en") + " wurde".sMehrzahlText(iRechnungen, "n");
                                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTXTZielumgebung + sTxtZAUFFS + " für " + sTxtRechnungen + " an den FSW gesendet.\n\nWollen Sie die Dateien anzeigen?", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.YesNo);
                                if (res == DialogResult.Yes)
                                {
                                    string resShow = ShowXMLContent(ListXMLInfos, Log);
                                    if (!String.IsNullOrWhiteSpace(resShow))
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Anzeigen der Dateiinhalte:\n" + resShow, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Rechnung für diese Akion qualifiziert.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.core.abrech.cs.FSWAbrechnung: " + ex.ToString());
            }
            finally
            {
                
            }
        }

        public string ShowXMLContent(List<XMLInfo> ListXMLInfos, string Log = "")
        {
            try
            {
                StringBuilder sbFileContent = new StringBuilder();

                int ieZAUFFs = (from aw in ListXMLInfos
                         where aw.bIsvalid == true
                         select aw.bIsvalid).ToList().Count();

                sbFileContent.Append("Diese Datei enthält " + ieZAUFFs.sIntToWords("e") + " eZAUFF".sMehrzahlText(ieZAUFFs, "s"));


                if (!String.IsNullOrWhiteSpace(Log))
                {
                    sbFileContent.Append(" und eine Log-Datei für die SFTP-Übertragung\n");

                    sbFileContent.Append("<<<<< BEGINN sFTP-Log-File >>>>>\n");
                    sbFileContent.Append(Log);
                    sbFileContent.Append("<<<<< ENDE sFTP-Log-File >>>>>");
                }

                foreach (XMLInfo xmlInfo in ListXMLInfos)
                {
                    if (xmlInfo.bIsvalid)
                    {
                        sbFileContent.Append("\n\n<<<<< BEGINN von " + xmlInfo.FQFileXML + " >>>>>\n");
                        sbFileContent.Append(xmlInfo.Xml.ToString());
                        sbFileContent.Append("<<<<< ENDE von " + xmlInfo.FQFileXML + ">>>>>");
                    }
                }

                TextEditMainForm frm = new TextEditMainForm("eZAUFF-Export Übersicht", sbFileContent);
                frm.Show();

                //using (QS2.Desktop.Txteditor.frmTxtEditorField frmEditor = new QS2.Desktop.Txteditor.frmTxtEditorField())
                //{
                //    Font font = new Font(
                //       new FontFamily("Courier New"),
                //       12,
                //       FontStyle.Regular,
                //       GraphicsUnit.Point);

                //    frmEditor.ContTXTField1.initControl(TXTextControl.ViewMode.FloatingText, true, true, true, true, false, false);
                //    frmEditor.WindowState = FormWindowState.Maximized;
                //    frmEditor.ContTXTField1.TXTControlField.ViewMode = TXTextControl.ViewMode.FloatingText;
                //    frmEditor.ContTXTField1.TXTControlField.EditMode = TXTextControl.EditMode.ReadOnly;
                //    frmEditor.ContTXTField1.TXTControlField.Font = font;
                //    frmEditor.ContTXTField1.TXTControlField.Text = sbFileContent.ToString();
                //    frmEditor.Text = "FSW-eZAUFF - Anzeige";
                //    frmEditor.ShowDialog();
                //}
                Application.DoEvents();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SetExportiertJN(List<string> lstBillsToUpdate, bool Status, ERModellPMDSEntities db)
        {
            try
            {
                foreach (string IDBill in ListIDBillsFSW)
                {
                    var res = db.bills.SingleOrDefault(bills => bills.ID == IDBill);
                    if (res != null)
                    {
                        res.ExportiertJN = Status;
                    }
                }
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SetIDSR(List<string> lstBillsToUpdate, string IDSR, ERModellPMDSEntities db)
        {
            try
            {
                foreach (string IDBill in lstBillsToUpdate)
                {
                    var res = db.bills.SingleOrDefault(bills => bills.ID == IDBill);
                    if (res != null)
                    {
                        if (IDSR.Length == 0)
                            res.IDSR = "";
                        else if (IDSR.Length == 47 )
                            res.IDSR = IDSR.Substring(IDSR.Length -18, 18);
                        else if (IDSR.Length == 49)
                            res.IDSR = IDSR.Substring(IDSR.Length - 21, 21);
                        else
                        {
                            return "Ungültige eZAUFF-Nummer: " + IDSR;
                        }
                    }
                }
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool MakeXLSX(ref List<XMLInfo> lXMLInfos, ref List<xlsxWorkbook> xlsxref, out string message)
        {
            message = "";
            try
            {
                xlsxref.Clear();
                foreach(XMLInfo XmlInfo in lXMLInfos)
                {
                    Workbook workbook1 = new Workbook(WorkbookFormat.Excel2007);
                    Worksheet worksheet1 = workbook1.Worksheets.Add("Übersicht");
                    worksheet1.Rows[0].Cells[0].Value = "Abrechnung FSW " + XmlInfo.Transaction.TransactionID;
                    xlsxWorkbook wb = new xlsxWorkbook();
                    wb.Filename = "eZAUF_" + XmlInfo.Transaction.TransactionID + (XmlInfo.Transaction.bIsPflegeZAUFF ? "" : "BW") + ".xlsx";
                    wb.wb = workbook1;
                    xlsxref.Add(wb);
                }
                return true;
            }
            catch (Exception ex) 
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool MakeXML(ref List<XMLInfo> lTransactions, out string Message)
        {
            try
            {
                Message = "";
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                CultureInfo ci = new CultureInfo("de-DE");

                foreach (XMLInfo Info in lTransactions)
                {
                    if (!Info.bIsvalid)     //Keine leeren Transactions
                        continue;

                    db.cEBInterfaceDB.Transaction Transaction = Info.Transaction;

                    Info.Xml.Clear();
                    Info.Xml.Encoding = "utf-8";
                    Info.Xml.Tag = "Transaction";
                    Info.Xml.AddAttribute("SenderAdresse", Transaction.SenderAdresse);
                    Info.Xml.AddAttribute("EmpfaengerAdresse", Transaction.EmfaengerAdresse);
                    Info.Xml.AddAttribute("TransactionID", Transaction.TransactionID);

                    Chilkat.Xml xArDocument = Info.Xml.NewChild("ArDocument", "");
                    xArDocument.AddAttribute("Referenz", Transaction.ArDocument.Referenz);
                    xArDocument.AddAttribute("User_Erstellung", Transaction.ArDocument.User_Erstellung);
                    xArDocument.AddAttribute("Datum_Erstellung", Transaction.ArDocument.Datum_Erstellung.ToString(DateTimeFormat, ci));
                    xArDocument.AddAttribute("Rechnungsbetrag", Transaction.ArDocument.Rechnungsbetrag.ToString(nfi));
                    xArDocument.AddAttribute("Anzahl_Rechnung", Transaction.ArDocument.Anzahl_Rechnungen.ToString(nfi));

                    foreach (PMDS.Global.db.cEBInterfaceDB.Invoice Invoice in Transaction.ArDocument.lstInvoices)
                    {
                        //Leere Invoices mit Rechnungssumme 0 überspringen
                        if (Invoice.Details.ItemList.Count == 0)
                            continue;

                        using (Chilkat.Xml xInvoice = new Chilkat.Xml())
                        {
                            xInvoice.Tag = "Invoice";
                            foreach (db.cEBInterfaceDB.cAttribute att in Invoice.Attributes)
                            {
                                xInvoice.AddAttribute(att.AttributeName, att.AttributeValue);
                            }

                            // InvoiceNumber muss bei Splittung Pfelge und BW eindeutig sein. Extension PF / BW an Rechungsnummer anhängen, wenn zwei gültige eZAUFFS vorhanden sind.
                            string InvoiceExt = ""; 
                            if (lTransactions.Where(p => p.bIsvalid == true).Count() == 2)
                            {
                                InvoiceExt = " " + (Info.Transaction.bIsPflegeZAUFF ? "(PF)" : "(BW)");
                            }
                            Chilkat.Xml xInvoiceNumber = xInvoice.NewChild("InvoiceNumber", Invoice.InvoiceNumber + InvoiceExt);
                            Chilkat.Xml xInvoiceDate = xInvoice.NewChild("InvoiceDate", Invoice.InvoiceDate.ToString(DateFormat, ci));
                            Chilkat.Xml xAdditionalInformation = xInvoice.NewChild("AdditionalInformation", "");

                            Chilkat.Xml xDelivery = xInvoice.NewChild("Delivery", "");
                            Chilkat.Xml xPeriod = xDelivery.NewChild("Period", "");
                            Chilkat.Xml xFromDate = xPeriod.NewChild("FromDate", Invoice.Delivery.Period.FromDate.ToString(DateFormat, ci));
                            Chilkat.Xml xToDate = xPeriod.NewChild("ToDate", Invoice.Delivery.Period.ToDate.ToString(DateFormat, ci));

                            Chilkat.Xml xBiller = xInvoice.NewChild("Biller", "");
                            Chilkat.Xml xBillerVATIdentificationNumber = xBiller.NewChild("VATIdentificationNumber", Invoice.Biller.VATIdentificationNumber);
                            Chilkat.Xml xBillerAddress = xBiller.NewChild("Address", "");
                            Chilkat.Xml xBillerAddressName = xBillerAddress.NewChild("Name", Invoice.Biller.Address.Name);
                            Chilkat.Xml xBillerAddressStreet = xBillerAddress.NewChild("Street", Invoice.Biller.Address.Street);
                            Chilkat.Xml xBillerAddressPOBox = xBillerAddress.NewChild("POBox", "");
                            Chilkat.Xml xBillerAddressTown = xBillerAddress.NewChild("Town", Invoice.Biller.Address.Town);
                            Chilkat.Xml xBillerAddressZIP = xBillerAddress.NewChild("ZIP", Invoice.Biller.Address.ZIP);
                            Chilkat.Xml xBillerAddressCountry = xBillerAddress.NewChild("Country", Invoice.Biller.Address.Country.Value);
                            Chilkat.Xml xBillerBillersInvoiceRecipientID = xBiller.NewChild("InvoiceRecipientsBillerID", Invoice.Biller.InvoiceRecipientsBillerID);
                            xBillerAddressCountry.AddAttribute(Invoice.Biller.Address.Country.AttributeName, Invoice.Biller.Address.Country.AttributeValue);

                            Chilkat.Xml xInvoiceRecipient = xInvoice.NewChild("InvoiceRecipient", "");
                            Chilkat.Xml xInvoiceRecipientVATIdentificationNumber = xInvoiceRecipient.NewChild("VATIdentificationNumber", Invoice.InvoiceRecipient.VATIdentificationNumber);
                            Chilkat.Xml xFurtherIdentification = xInvoiceRecipient.NewChild("FurtherIdentification", Invoice.InvoiceRecipient.FurtherIdentification.Value);
                            xFurtherIdentification.AddAttribute(Invoice.InvoiceRecipient.FurtherIdentification.AttributeName, Invoice.InvoiceRecipient.FurtherIdentification.AttributeValue);
                            Chilkat.Xml xInvoiceRecipientAddress = xInvoiceRecipient.NewChild("Address", "");
                            Chilkat.Xml xInvoiceRecipientAddressName = xInvoiceRecipientAddress.NewChild("Name", Invoice.InvoiceRecipient.Address.Name);
                            Chilkat.Xml xInvoiceRecipientAddressStreet = xInvoiceRecipientAddress.NewChild("Street", Invoice.InvoiceRecipient.Address.Street);
                            //Chilkat.Xml xInvoiceRecipientAddressPOBox = xInvoiceRecipientAddress.NewChild("POBox", "");
                            Chilkat.Xml xInvoiceRecipientAddressTown = xInvoiceRecipientAddress.NewChild("Town", Invoice.InvoiceRecipient.Address.Town);
                            Chilkat.Xml xInvoiceRecipientAddressZIP = xInvoiceRecipientAddress.NewChild("ZIP", Invoice.InvoiceRecipient.Address.ZIP);
                            Chilkat.Xml xInvoiceRecipientAddressCountry = xInvoiceRecipientAddress.NewChild("Country", Invoice.InvoiceRecipient.Address.Country.Value);
                            xInvoiceRecipientAddressCountry.AddAttribute(Invoice.InvoiceRecipient.Address.Country.AttributeName, Invoice.InvoiceRecipient.Address.Country.AttributeValue);
                            Chilkat.Xml xBillersInvoiceRecipientID = xInvoiceRecipient.NewChild("BillersInvoiceRecipientID", Invoice.InvoiceRecipient.BillersInvoiceRecipientID);

                            Chilkat.Xml xDetails = xInvoice.NewChild("Details", "");
                            Chilkat.Xml xDetailsHeaderDescription = xDetails.NewChild("HeaderDescription", Invoice.Details.HeaderDescription);
                            Chilkat.Xml xDetailsItemList = xDetails.NewChild("ItemList", "");

                            foreach (db.cEBInterfaceDB.ListLineItem item in Invoice.Details.ItemList)
                            {
                                using (Chilkat.Xml xListLineItem = new Chilkat.Xml())
                                {
                                    xListLineItem.Tag = "ListLineItem";
                                    Chilkat.Xml xListLineItemPositionNumber = xListLineItem.NewChild("PositionNumber", item.PositionNumber.ToString());
                                    Chilkat.Xml xListLineItemDescription = xListLineItem.NewChild("Description", item.Description);
                                    Chilkat.Xml xListLineItemArticleNumber = xListLineItem.NewChild("ArticleNumber", "");
                                    Chilkat.Xml xListLineItemQuantitiy = xListLineItem.NewChild("Quantity", item.Quantity.Value.ToString());
                                    xListLineItemQuantitiy.AddAttribute(item.Quantity.AttributeName, item.Quantity.AttributeValue);
                                    Chilkat.Xml xListLineItemUnitPrice = xListLineItem.NewChild("UnitPrice", item.UnitPrice.Value.ToString(nfi));
                                    xListLineItemUnitPrice.AddAttribute(item.UnitPrice.AttributeName, item.UnitPrice.AttributeValue);
                                    Chilkat.Xml xListLineItemBillerOrdersReference = xListLineItem.NewChild("BillersOrderReference", "");
                                    Chilkat.Xml xListLineItemBillerOrdersReferenceOrderID = xListLineItemBillerOrdersReference.NewChild("OrderID", item.BillersOrderReferenz.OrderID);
                                    Chilkat.Xml xListLineItemTaxItem = xListLineItem.NewChild("TaxItem", "");
                                    Chilkat.Xml xListLineItemTaxItemTaxableAmount = xListLineItemTaxItem.NewChild("TaxableAmount", item.TaxItem.TaxableAmount.ToString(nfi));
                                    string TaxPercentage = item.TaxItem.TaxPercent.AttributeValue == "O" ? "0": item.TaxItem.TaxPercent.Value.ToString(nfi);
                                    Chilkat.Xml xListLineItemTaxItemTaxPercent = xListLineItemTaxItem.NewChild("TaxPercent", TaxPercentage);
                                    xListLineItemTaxItemTaxPercent.AddAttribute(item.TaxItem.TaxPercent.AttributeName, item.TaxItem.TaxPercent.AttributeValue);
                                    Chilkat.Xml xListLineItemAmount = xListLineItem.NewChild("LineItemAmount", item.LineItemAmount.ToString(nfi));
                                    xDetailsItemList.AddChildTree(xListLineItem);
                                }
                            }
                            if (Invoice.ReductionAndSurchargeDetails.Surcharge.Amount != 0)
                            {
                                Chilkat.Xml xReductionAndSurchargeDetails = xInvoice.NewChild("ReductionAndSurchargeDetails", "");
                                Chilkat.Xml xReductionAndSurchargeDetailsSurcharge = xReductionAndSurchargeDetails.NewChild("Surcharge", "");
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeBaseAmount = xReductionAndSurchargeDetailsSurcharge.NewChild("BaseAmount", Invoice.ReductionAndSurchargeDetails.Surcharge.BaseAmount.ToString(nfi));
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargePercentage = xReductionAndSurchargeDetailsSurcharge.NewChild("Percentage", Invoice.ReductionAndSurchargeDetails.Surcharge.Percentage.ToString(nfi));
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeAmount = xReductionAndSurchargeDetailsSurcharge.NewChild("Amount", Invoice.ReductionAndSurchargeDetails.Surcharge.Amount.ToString(nfi));
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeComment = xReductionAndSurchargeDetailsSurcharge.NewChild("Comment", Invoice.ReductionAndSurchargeDetails.Surcharge.Comment);
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItem = xReductionAndSurchargeDetailsSurcharge.NewChild("TaxItem", "");
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItemTaxableAmount = xReductionAndSurchargeDetailsSurchargeTaxItem.NewChild("TaxableAmount", Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount.ToString(nfi));
                                Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItemTaxPercent = xReductionAndSurchargeDetailsSurchargeTaxItem.NewChild("TaxPercent", Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.Value.ToString(nfi));
                                xReductionAndSurchargeDetailsSurchargeTaxItemTaxPercent.AddAttribute(Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.AttributeName, Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.AttributeValue);
                            }

                            //Chilkat.Xml xTax = xInvoice.NewChild("Tax", Invoice.Tax.ToString(nfi));
                            Chilkat.Xml xTax = xInvoice.NewChild("Tax", "");
                            Chilkat.Xml xTotalGrossAmount = xInvoice.NewChild("TotalGrossAmount", Invoice.TotalGrossAmount.ToString(nfi));
                            Chilkat.Xml xPayableAmount = xInvoice.NewChild("PayableAmount", Invoice.PayableAmount.ToString(nfi));

                            Chilkat.Xml xPaymentMethod = xInvoice.NewChild("PaymentMethod", "");
                            Chilkat.Xml xPaymentMethodComment = xPaymentMethod.NewChild("Comment", "");
                            Chilkat.Xml xUniversalBankTransaction = xPaymentMethod.NewChild("UniversalBankTransaction", "");
                            xUniversalBankTransaction.AddAttribute(Invoice.PaymentMethod.UniversalBankTransaction.AttributeName, Invoice.PaymentMethod.UniversalBankTransaction.AttributeValue);
                            Chilkat.Xml xBeneficiaryAccount = xUniversalBankTransaction.NewChild("BeneficiaryAccount", "");
                            Chilkat.Xml xBankName = xBeneficiaryAccount.NewChild("BankName", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankName);
                            Chilkat.Xml xBankCode = xBeneficiaryAccount.NewChild("BankCode", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankCode.Value);
                            xBankCode.AddAttribute(Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankCode.AttributeName, Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankCode.AttributeValue);
                            Chilkat.Xml xBIC = xBeneficiaryAccount.NewChild("BIC", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BIC);
                            Chilkat.Xml xBankAccountNr = xBeneficiaryAccount.NewChild("BankAccountNr", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankAccountNr);
                            Chilkat.Xml xIBAN = xBeneficiaryAccount.NewChild("IBAN", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.IBAN);
                            Chilkat.Xml xBankAccountOwner = xBeneficiaryAccount.NewChild("BankAccountOwner", Invoice.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankAccountOwner);

                            xArDocument.AddChildTree(xInvoice);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false; 
            }
        }

        public static bool SaveXML(ref List<XMLInfo> ListXMLInfos, out string Message)
        {
            Message = "";

            try
            {
                foreach (XMLInfo XmlInfo in ListXMLInfos)
                {
                    if (!XmlInfo.bIsvalid)
                        continue;

                    using (SaveFileDialog dlg = new SaveFileDialog())
                    {
                        dlg.InitialDirectory = ENV.FSW_EZAUF;
                        dlg.FileName = XmlInfo.FQFileXML;
                        dlg.Filter = "FSW-Zahlungsaufforderungen|*.xml";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            XmlInfo.FQFileXML = dlg.FileName;

                            if (!XmlInfo.Xml.SaveXml(dlg.FileName))
                            {
                                throw new Exception("Fehler beim Speichern der Zahlungsaufforderung: " + XmlInfo.Xml.LastErrorText);
                            }
                        }
                        else
                        {
                            throw new Exception("Speichern abgebrochen");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public static bool SaveXLSX(List<xlsxWorkbook> lstWorkbooks, out string Message)
        {
            Message = "";
            try
            {
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.SelectedPath = ENV.FSW_EZAUF;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        foreach (xlsxWorkbook workbook in lstWorkbooks)
                        {
                            workbook.wb.Save(Path.Combine(dlg.SelectedPath, workbook.Filename));
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }


        private static PMDS.db.Entities.bills readBill(string IDBill)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    return (from b in db.bills
                                  select b).Where(b => b.ID == IDBill).First(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.readBill: " + ex.Message);
            }
        }

        private static PMDS.db.Entities.billHeader readBillHeader(string IDBill, Guid IDKlinik)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    return (from bh in db.billHeader
                            select bh).Where(bh => bh.ID == IDBill && bh.IDKlinik == IDKlinik).First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.readBillHeader: " + ex.Message);
            }
        }

        private static dbCalc getDBCalc(string xml)
        {
            try
            {
                dbCalc dbCalc = new dbCalc();
                /*
                using (System.Xml.XmlTextReader xmlTextReader = (System.Xml.XmlTextReader)System.Xml.XmlReader.Create(new StringReader(xml), new System.Xml.XmlReaderSettings() { DtdProcessing = System.Xml.DtdProcessing.Prohibit }))
                {
                    dbCalc.ReadXml(xmlTextReader);
                    xmlTextReader.Close();
                    return dbCalc;
                }
                */

                System.Xml.XmlTextReader xmlTextReader = new System.Xml.XmlTextReader(new StringReader(xml));
                dbCalc.ReadXml(xmlTextReader);
                xmlTextReader.Close();
                return dbCalc;
                
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.getDBCalc: " + ex.Message);
            }
        }

        private bool FSWIsZahler (Guid IDKostentraeger, Guid IDFSW)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool b =  (from kt in db.Kostentraeger
                            select kt).Where(kt => kt.ID == IDKostentraeger && (kt.IDKostentraegerSub == IDFSW || kt.ID == IDFSW)).Any();

                    if (b)
                    {
                        string x = "";
                    }

                    return b;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.getDBCalc: " + ex.Message);
            }
        }

        private static string Upload (string RemoteFilename, string LocalFQFilename, out string Log)
        {
            try
            {
                Log = "";
                bool success;
                using (Chilkat.SFtp sftp = new Chilkat.SFtp())
                {
                    sftp.ConnectTimeoutMs = 15000;
                    sftp.IdleTimeoutMs = 15000;
                    success = false;
                    using (Chilkat.SshKey puttyKey = new Chilkat.SshKey())
                    {
                        string ppkText = puttyKey.LoadText(ENV.FSW_FTPZertifikat);
                        puttyKey.Password = "Yaw2Xse3Cdr4";
                        puttyKey.FromPuttyPrivateKey(ppkText);

                        if (sftp.Connect(ENV.FSW_FTPIP, ENV.FSW_FTPPort))
                            if (sftp.AuthenticatePk(ENV.FSW_FTPUser, puttyKey))
                                if (sftp.InitializeSftp())
//                                    if (sftp.UploadFileByName(RemoteFilename, LocalFQFilename))
                                    if (sftp.UploadFileByName( ENV.FSW_FTPMode.ToLower() + "/put/" + RemoteFilename, LocalFQFilename))
                                    {
                                        //WriteLogToFile(sftp.LastErrorText);
                                        if (sftp.LastErrorXml.Contains("failed status"))
                                        {
                                            WriteLogToFile(sftp.LastErrorText);
                                            return sftp.LastErrorText;
                                        }
                                        else
                                        {
                                            WriteLogToFile(sftp.LastErrorText);
                                            Log = sftp.LastErrorText;
                                            return "";
                                        }
                                    }
                                    else
                                    {
                                        WriteLogToFile(sftp.LastErrorText);
                                        return sftp.LastErrorText;
                                    }
                                else
                                {
                                    WriteLogToFile(sftp.LastErrorText);
                                    return "sFTP-Client-Initialisierung fehlgeschlagen: " + sftp.LastErrorText;
                                }
                            else
                            {
                                WriteLogToFile(sftp.LastErrorText);
                                return "sFTP-Client-Authentifizierung fehlgeschlagen: " + sftp.LastErrorText;
                            }
                        else
                        {
                            WriteLogToFile(sftp.LastErrorText);
                            return "sFTP-Client-Connect fehlgeschlagen: " + sftp.LastErrorText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.Upload: " + ex.Message);
            }
        }

        private static void WriteLogToFile(string txtLog)
        {
            try
            {
                string sLogFile = Path.Combine(ENV.FSW_EZAUF, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".LOG");
                if (!File.Exists(sLogFile))
                {
                    File.WriteAllText(sLogFile, txtLog);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.WriteLogToFile: " + ex.Message);
            }

        }

        private bool CheckIsPflege(string LeistungBezeichnung, List<string> lBW_Leistungen)
        {
            bool bLZIsPflege = false;
            bool bLZIsBetreutesWohnen = false;
            foreach (string sBW in lBW_Leistungen)      //Art der Leistung ermitteln
            {
                if (LeistungBezeichnung.sEquals(sBW, S2Extensions.Enums.eCompareMode.StartsWith))
                {
                    bLZIsBetreutesWohnen = bLZIsBetreutesWohnen || true;
                }
                else
                {
                    bLZIsPflege = bLZIsPflege || true;
                }
            }
            return bLZIsPflege;
        }

        private static string CopyXSLT(string sFileName)
        {
            try
            {
                string[] stylesheets = Directory.GetFiles(ENV.pathConfig, "*.xsl");

                foreach (string stylesheet in stylesheets)
                {
                    string nXSLT = Path.GetFileName(stylesheet);
                    string fXSLT = Path.Combine(ENV.pathConfig, nXSLT);
                    string dDest = System.IO.Path.GetDirectoryName(sFileName);
                    string fDest = Path.Combine(dDest, nXSLT);

                    FileInfo fiSource = new FileInfo(fXSLT);
                    FileInfo fiDest = new FileInfo(fDest);

                    //Prüfen, ob Stylesheet kopiert oder aktualisert werden muss
                    if (!fiDest.Exists || fiDest.Length != fiSource.Length)
                    {
                        File.Copy(fXSLT, fDest, true);
                        //Prüfen, ob Kopieren / Ersetzen erfolgreich war
                        fiDest = new FileInfo(fDest);
                        if (!fiDest.Exists || fiDest.Length != fiSource.Length)
                            return "Fehler beim Kopieren des Stylesheets " + nXSLT + ": Konnte nicht kopiert werden.";
                    }
                }
                return "";
            }
            catch (UnauthorizedAccessException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (PathTooLongException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (DirectoryNotFoundException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (FileNotFoundException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (IOException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (NotSupportedException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CopyXSLT: " + ex.ToString());
            }
        }
    }
}
