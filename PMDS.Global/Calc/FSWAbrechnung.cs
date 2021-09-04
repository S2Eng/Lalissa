using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMDS.Calc.Logic;
using PMDS.DB;
using PMDS.db.Entities;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using Syncfusion.XlsIO;

namespace PMDS.Global
{
    public class FSWAbrechnung
    {
        private static string DateFormat = "yyyy-MM-dd";
        private static string DateTimeFormat = "yyyyMMddHHmmss";
        private string eZAUFID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
        private string eZAUFIDBW = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "BW";
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

        public bool UseUploadToFSW { get; set; } = true;
        private List<string> ListIDBillsFSW { get; set; } = new List<string>();                   //Sammelt die Rechungen des FSW
        private List<string> ListIDBillsFSWBW { get; set; } = new List<string>();                   //Sammelt die Rechungen des FSW für betreutes Wohnen

        private List<Leistungszeile> lstZeilen = new List<Leistungszeile>();
        private List<Chilkat.Xml> ListFSWXml = new List<Chilkat.Xml>();

        private db.cEBInterfaceDB.Transaction Transaction { get; set; } = db.cEBInterfaceDB.NewTransaction(true);
        private db.cEBInterfaceDB.Transaction TransactionBW { get; set; } = db.cEBInterfaceDB.NewTransaction(false);

        //private List<db.cEBInterfaceDB.Transaction> lTransactions = new List<db.cEBInterfaceDB.Transaction>();
        public bool UseXlsxExport { get; set; }
        private ExcelEngine _FSWXlsx = new ExcelEngine();

        private eAction _RunAction;

        public eAction RunAction
        {
            get { return _RunAction;  }
            set { _RunAction = value; }
        }

        //public Chilkat.Xml FSWXml
        //{
        //    get { return _FSWXml; }
        //    set { _FSWXml = value; }
        //}

        public ExcelEngine FSWXlsx
        {
            get { return _FSWXlsx; }
            set { _FSWXlsx = value; }
        }

        public enum eAction
        {
            fsw = 7,
            fswreset = 8,
            fswNoUpload = 9
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
                            MsgBoxTitle = "FSW-Status für Zahlungsaufforderung zurücksetzen";
                            break;
                    }

                    decimal Rechnungsbetrag = 0;
                    decimal RechnungsbetragBW = 0;

                    decimal Steuern = 0;
                    decimal SteuernBW = 0;

                    foreach (string IDBill in ListIDBills ?? new List<string>())
                    {
                        bills rBill = readBill(IDBill);
                        billHeader rHeader = readBillHeader(rBill.IDAbrechnung, IDKlinik);
                        using (dbCalc dbCalc = getDBCalc(rHeader.dbCalc))
                        {
                            //Prüfungen
                            if (!rBill.Freigegeben)
                            {
                                //Dieser Fall wird in der Oberfläche ausgeschlossen. Ist nur sicherheitshalber im Code.
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nicht freigegebene Rechnungen können nicht an den FSW gesendet werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            if (rBill.IDSR.Length > 0  && !rBill.IDSR.Any(c => Guid.TryParse(rBill.IDSR, out Guid guidID)) && RunAction == eAction.fsw)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereits gesendete Rechnungen können nicht nocheinmal gesendet werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            PMDS.Global.db.cEBInterfaceDB FSWRechnung = new db.cEBInterfaceDB();
                            PMDS.Global.db.cEBInterfaceDB.Invoice Invoice = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));
                            PMDS.Global.db.cEBInterfaceDB.Invoice InvoiceBW = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));

                            //Verhältnis Pflege / Betreuung auf der Rechnung ermitteln
                            decimal dPflegeNetto = 0;
                            decimal dBWNetto = 0;
                            decimal dMwSt = 0;
                            foreach (dbCalc.KostenKostenträgerRow Rechnungszeile in dbCalc.KostenKostenträger)
                            {
                                if (rBill.IDKost == Rechnungszeile.IDKost && FSWIsZahler(new Guid(Rechnungszeile.IDKost), ENV.FSW_IDIntern) && !LeistungszeileBereitsVerrechnet(new Guid(Rechnungszeile.ID), new Guid(rBill.ID)))
                                {
                                    if (generic.sEquals(Rechnungszeile.Kennung, "LZ"))
                                    {
                                        foreach (string sBW in lBW_Leistungen)
                                        {
                                            if (generic.sEquals(Rechnungszeile.Bezeichnung, sBW, Enums.eCompareMode.StartsWith))
                                            {
                                                dBWNetto += Rechnungszeile.Netto;
                                            }
                                            else
                                            {
                                                dPflegeNetto += Rechnungszeile.Netto;
                                            }
                                        }
                                    }
                                    else if (generic.sEquals(Rechnungszeile.Kennung, "MWstSatz"))   //zur Kontrolle
                                    {
                                        dMwSt += Rechnungszeile.Netto;
                                    }
                                }
                            }
                            decimal dPercentPflege = (dPflegeNetto != 0 ? (dPflegeNetto) / (dPflegeNetto + dBWNetto)  : 0);  //Aufteilungsschlüssel für MwsT, GSBG und Gesamt zwischen Pflege und Betreutes Wohnen

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

                            int Zeile = 0;
                            int ZeileBW = 0;

                            foreach (dbCalc.KostenKostenträgerRow Rechnungszeile in dbCalc.KostenKostenträger)
                            {
                                //Prüfen, ob die Rechung an FSW oder Stellvertert geht (Kostenträger Sub in rBill) 
                                //if (rBill.IDKost == Rechnungszeile.IDKost && FSWIsZahler(new Guid(Rechnungszeile.IDKost), ENV.FSW_IDIntern) && !lstZeilen.Contains(new Guid(Rechnungszeile.ID)))
                                if (rBill.IDKost == Rechnungszeile.IDKost && FSWIsZahler(new Guid(Rechnungszeile.IDKost), ENV.FSW_IDIntern) && !LeistungszeileBereitsVerrechnet(new Guid(Rechnungszeile.ID), new Guid(rBill.ID)))
                                {
                                    if (generic.sEquals(Rechnungszeile.Kennung, "LZ"))
                                    {
                                        bool bLZIsPflege = false;
                                        bool bLZIsBetreutesWohnen = false;
                                        foreach (string sBW in lBW_Leistungen)      //Art der Leistung ermitteln
                                        {
                                            if (generic.sEquals(Rechnungszeile.Bezeichnung, sBW, Enums.eCompareMode.StartsWith))
                                            {
                                                bLZIsBetreutesWohnen = bLZIsBetreutesWohnen || true;
                                                ZeileBW++;
                                            }
                                            else
                                            {
                                                bLZIsPflege = bLZIsPflege || true;
                                                Zeile++;
                                            }                                             
                                        }                                        

                                        if (rBill.Status == -10)    //Bei Storno Tage negativ angeben und Basipreis positiv
                                        {
                                            if (bLZIsPflege)
                                                Invoice.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, Zeile, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl * -1, Math.Abs(Rechnungszeile.Netto / Rechnungszeile.Anzahl), Rechnungszeile.Netto, Rechnungszeile.Netto, Rechnungszeile.MWSt));
                                            else if (bLZIsBetreutesWohnen)
                                                InvoiceBW.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, ZeileBW, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl * -1, Math.Abs(Rechnungszeile.Netto / Rechnungszeile.Anzahl), Rechnungszeile.Netto, Rechnungszeile.Netto, Rechnungszeile.MWSt));
                                        }
                                        else
                                        {
                                            if (bLZIsPflege)
                                                Invoice.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, Zeile, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl, Rechnungszeile.Netto / Rechnungszeile.Anzahl, Rechnungszeile.Netto, Rechnungszeile.Netto, Rechnungszeile.MWSt));
                                            else if (bLZIsBetreutesWohnen)
                                                InvoiceBW.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, ZeileBW, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl, Rechnungszeile.Netto / Rechnungszeile.Anzahl, Rechnungszeile.Netto, Rechnungszeile.Netto, Rechnungszeile.MWSt));
                                        }
                                        lstZeilen.Add(new Leistungszeile() { IDRechnungszeile = new Guid(Rechnungszeile.ID), IDRechnung = new Guid(rBill.ID) });      // new Guid(Rechnungszeile.ID), new Guid(rBill.ID));
                                    }

                                    else if (generic.sEquals(Rechnungszeile.Kennung, "MWstSatz"))
                                    {
                                        Invoice.Tax += Math.Round(Rechnungszeile.Netto * dPercentPflege, 2, MidpointRounding.AwayFromZero);
                                        InvoiceBW.Tax += Math.Round(Rechnungszeile.Netto * (1 - dPercentPflege), 2, MidpointRounding.AwayFromZero);
                                    }

                                    else if (generic.sEquals(Rechnungszeile.Kennung, "GSGB"))
                                    {
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.BaseAmount = dPflegeNetto;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Percentage = ENV.FSW_Prozent;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Amount = Math.Round(dPflegeNetto * (ENV.FSW_Prozent / 100), 2, MidpointRounding.AwayFromZero);
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount = Invoice.ReductionAndSurchargeDetails.Surcharge.Amount;

                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.BaseAmount = dBWNetto;
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.Percentage = ENV.FSW_Prozent;
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.Amount = Math.Round(dBWNetto * (ENV.FSW_Prozent / 100), 2, MidpointRounding.AwayFromZero);
                                        InvoiceBW.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount = InvoiceBW.ReductionAndSurchargeDetails.Surcharge.Amount;

                                        lstZeilen.Add(new Leistungszeile() { IDRechnungszeile = new Guid(Rechnungszeile.ID), IDRechnung = new Guid(rBill.ID) });      // new Guid(Rechnungszeile.ID), new Guid(rBill.ID));
                                    }
                                    
                                }
                            }
                            if (Zeile > 0)                     //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update)
                                ListIDBillsFSW.Add(IDBill);

                            if (ZeileBW > 0)                     //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update)
                                ListIDBillsFSWBW.Add(IDBill);


                            Invoice.TotalGrossAmount = Math.Round(rBill.betrag * dPercentPflege, 2, MidpointRounding.AwayFromZero);
                            Invoice.PayableAmount = Invoice.TotalGrossAmount;
                            Steuern += Invoice.Tax;
                            Rechnungsbetrag += Invoice.PayableAmount;
                            Invoice.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFID;
                            Transaction.ArDocument.AddInvoiceToList(Invoice);
 
                            InvoiceBW.TotalGrossAmount = Math.Round(rBill.betrag * (1 - dPercentPflege), 2, MidpointRounding.AwayFromZero);
                            InvoiceBW.PayableAmount = InvoiceBW.TotalGrossAmount;
                            SteuernBW += InvoiceBW.Tax;
                            RechnungsbetragBW += InvoiceBW.PayableAmount;
                            InvoiceBW.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFIDBW;
                            TransactionBW.ArDocument.AddInvoiceToList(InvoiceBW);
                        }
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

                    //lTransactions.Add(Transaction);
                    //lTransactions.Add(TransactionBW);

                    List<XMLInfo> ListXMLInfos = new List<XMLInfo>();
                    XMLInfo XMLInfoPflege = new XMLInfo() { Transaction = Transaction };
                    XMLInfo XMLInfoBW = new XMLInfo() { Transaction = TransactionBW };
                    ListXMLInfos.Add(XMLInfoPflege);
                    ListXMLInfos.Add(XMLInfoBW);

                    string ret = "";
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
                                if (!glob.UnlockBundle("S2ENGN.CB1032020_S4VwQSty6L2t"))
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
                                //FSWXml = _FSWXml;
                            }

                            if (RunAction == eAction.fswNoUpload)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ZAUF im XML-Export-Format wurde erstellt und gespeichert, aber nicht gesendet. ", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                            }

                            if (ENV.FSW_SaveXLSX)
                            {
                                //Transaction -> XLSX
                                if (!MakeXLSX(ref ListXMLInfos, ref _FSWXlsx, out Msg))
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Konvertieren in Excel (XLSX): " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                                if (!SaveXLSX(_FSWXlsx, ref FQFileXLSX, out Msg))   //Xlsx Speichern
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Exceldatei für ZAUF wurde nicht gespeichert: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            
                            if (RunAction == eAction.fsw)    //Hochladen. Wenn nein -> nur XML erstellen (z.B. für Test)
                            {
                                foreach(XMLInfo f in ListXMLInfos)
                                {
                                    if (!f.bIsvalid)
                                        continue;

                                    bool bIsPflegeZAUFF = f.Transaction.bIsPflegeZAUFF;
                                    FilenameXML = f.Transaction.bIsPflegeZAUFF ? FilenameXML : FilenameXLSXBW;
                                    ListIDs = f.Transaction.bIsPflegeZAUFF ? ListIDBillsFSW : ListIDBillsFSWBW;

                                    ret = Upload(FilenameXML, f.FQFileXML);
                                    if (ret.Length > 0)
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Hochladen der Zahlungsaufforderung: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                        return;
                                    }
                                    //Sammelrechnung-ID (ZAUF) setzen
                                    ret = SetIDSR(ListIDs, FilenameXML, db);
                                    if (ret.Length == 0)
                                    {
                                        string sBWExt = f.Transaction.bIsPflegeZAUFF ? "(BW)" : "";
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zahlungsaufforderung " + sBWExt + "für " + ListIDs.Count.ToString() + " Rechnung(en) an FSW gesendet.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zahlungsaufforderung wurde gesendet, aber beim Sichern des ZAUF-Zustands (Kennung Sammelrechnung) ist ein Fehler aufgetreten: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Sammelrechnung-ID (ZAUF) setzen
                            ret = SetIDSR(ListIDBills, "", db);
                            if (ret.Length == 0)
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status Zahlungsaufforderung für " + ListIDs.Count.ToString() + " Rechnung(en) zurückgesetzt.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Zurücksetzen des ZAUF-Zustands: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
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
                        else if (IDSR.Length == 58 )
                            res.IDSR = IDSR.Substring(IDSR.Length -18, 18);
                        else if (IDSR.Length == 61)
                            res.IDSR = IDSR.Substring(IDSR.Length - 22, 22);
                        else
                        {
                            return "Ungültige eZAUF-Nummer: " + IDSR;
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

        public static bool MakeXLSX(ref List<XMLInfo> lXMLInfos, ref ExcelEngine xlsxref, out string Message)
        {
            //https://help.syncfusion.com/file-formats/xlsio/overview

            xlsxref = new ExcelEngine();
            IApplication app = xlsxref.Excel;
            app.DefaultVersion = ExcelVersion.Xlsx;
            Message = ""; 

            try
            {
                int i = 1;
                foreach(XMLInfo XmlInfo in lXMLInfos)
                {
                    PMDS.Global.db.cEBInterfaceDB.Transaction Transaction = XmlInfo.Transaction;
                    IWorkbook workbook = app.Workbooks.Create(i);
                    IWorksheet sheetHeader = workbook.Worksheets.Create("Übersicht");
                    IWorksheet sheetZAUF = workbook.Worksheets.Create("Zahlungsaufforderung");
                    IWorksheet sheetZAUFKorr = workbook.Worksheets.Create("Korr. Zahlungsaufforderung");
                    sheetHeader.Range["A1"].Text = "Abrechnung FSW " + Transaction.TransactionID;
                }
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
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
                    db.cEBInterfaceDB.Transaction Transaction = Info.Transaction;

                    if (Transaction.ArDocument.Anzahl_Rechnungen == 0)  //Keine leeren Transactions
                    {
                        Info.bIsvalid = false;
                        continue;
                    }

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
                                    Chilkat.Xml xListLineItemTaxItemTaxPercent = xListLineItemTaxItem.NewChild("TaxPercent", item.TaxItem.TaxPercent.Value.ToString(nfi));
                                    xListLineItemTaxItemTaxPercent.AddAttribute(item.TaxItem.TaxPercent.AttributeName, item.TaxItem.TaxPercent.AttributeValue);
                                    Chilkat.Xml xListLineItemAmount = xListLineItem.NewChild("LineItemAmount", item.LineItemAmount.ToString(nfi));
                                    xDetailsItemList.AddChildTree(xListLineItem);
                                }
                            }

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

        public static bool SaveXLSX(ExcelEngine excelEngine, ref string FQFilename, out string Message)
        {
            Message = "";
            string Filter = "";
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.InitialDirectory = ENV.FSW_EZAUF;
                    dlg.FileName = FQFilename;
                    dlg.Filter = "FSW-Zahlungsaufforderungen|*.xlsx";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        FQFilename = dlg.FileName;
                        excelEngine.Excel.Workbooks[0].SaveAs(dlg.FileName);
                        return true;
                    }
                    else
                    {
                        throw new Exception("Speichern abgebrochen");
                    }
                }
            }
            catch (Exception ex)
            {
                FQFilename = "";
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
                            select kt).Where(kt => kt.ID == IDKostentraeger && kt.IDKostentraegerSub == IDFSW && kt.PatientbezogenJN == false).Any();

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

        private bool LeistungszeileBereitsVerrechnet(Guid IDRechnungszeile, Guid IDRechnung)
        {
            try
            {
                return (from z in lstZeilen
                          select z).Where(z => z.IDRechnungszeile == IDRechnungszeile && z.IDRechnung == IDRechnung).Any();
                /*
                foreach (Leistungszeile z in lstZeilen)
                {
                    if (z.IDRechnungszeile == IDRechnungszeile && z.IDRechnung == IDRechnung)
                    {
                        return true;
                    }
                }
                return false;
                */
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.getDBCalc: " + ex.Message);
            }
        }

        private static string Upload (string RemoteFilename, string LocalFQFilename)
        {
            try
            {
                bool success;
                using (Chilkat.SFtp sftp = new Chilkat.SFtp())
                {
                    sftp.ConnectTimeoutMs = 15000;
                    sftp.IdleTimeoutMs = 15000;
                    success = false;
                    using (Chilkat.SshKey sshKey = new Chilkat.SshKey())
                    {
                        sshKey.LoadText(ENV.FSW_FTPZertifikat);
                        if (sftp.Connect(ENV.FSW_FTPIP, ENV.FSW_FTPPort))
                            if (sftp.AuthenticatePk(ENV.FSW_FTPUser, sshKey))
                                if (sftp.InitializeSftp())
                                    if (sftp.UploadFileByName(RemoteFilename, LocalFQFilename))
                                    {
                                        return "";
                                    }
                                    else
                                    {
                                        return sftp.LastErrorText;
                                    }
                    }
                    return sftp.LastErrorText; ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FSWAbrechnung.cs.Upload: " + ex.Message);
            }
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
