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

namespace PMDS.Global
{
    public class FSWAbrechnung
    {
        private static string DateFormat = "yyyy-MM-dd";
        private static string DateTimeFormat = "yyyyMMddHHmmss";
        private string eZAUFID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
        private List<string> ListIDBillsFSW = new List<string>();                   //Sammelt die Rechungen des FSW

        //private List<PMDS.Global.db.cEBInterfaceDB.Invoice> lstRechnungen = new List<db.cEBInterfaceDB.Invoice>();
        private List<Guid> lstZeilen = new List<Guid>();

        //------------------------ ebInterface / Abrechnungsschittstelle zum FSW -----------------------------
        public void GenerateFSWStructure(Guid IDKlinik, List<string> ListIDBills, bool SetStatusOnly)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = calculation.delgetDBContext.Invoke())
                {
   
                    decimal ZahlungsbetragNetto = 0;
                    PMDS.Global.db.cEBInterfaceDB.Transaction Transaction = new db.cEBInterfaceDB.Transaction();
                    string MsgBoxTitle = SetStatusOnly ? "FSW-Status für Zahlungsaufforderung zurücksetzen" : "FSW-Zahlungsaufforderung erstellen und senden";


                    foreach (string IDBill in ListIDBills ?? new List<string>())
                    {
                        bills rBill = readBill(IDBill);
                        billHeader rHeader = readBillHeader(rBill.IDAbrechnung, IDKlinik);
                        using (dbCalc dbCalc = getDBCalc(rHeader.dbCalc))
                        {
                            //Prüfungen
                            if (!rBill.Freigegeben)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nicht freigegebene Rechnungen können nicht an den FSW gesendet werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            if (rBill.ExportiertJN && !SetStatusOnly)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereits gesendete Rechnungen können nicht nocheinmal gesendet werden.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            PMDS.Global.db.cEBInterfaceDB FSWRechnung = new db.cEBInterfaceDB();
                            PMDS.Global.db.cEBInterfaceDB.Invoice Invoice = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));

                            Invoice.InvoiceNumber = rBill.RechNr;
                            Invoice.InvoiceDate = (DateTime)rBill.RechDatum;
                            Invoice.Delivery.Period.FromDate = dbCalc.Monate[0].Beginn;
                            Invoice.Delivery.Period.ToDate = dbCalc.Monate[0].Ende;

                            if (rBill.RollungAnz == 0)
                                Invoice.Details.HeaderDescription = "Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                            else
                                Invoice.Details.HeaderDescription = "Korrektur zur Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");

                            int Zeile = 0;
                            foreach (dbCalc.KostenKostenträgerRow Rechnungszeile in dbCalc.KostenKostenträger)
                            {
                                //Prüfen, ob die Rechung an FSW oder Stellvertert geht (Kostenträger Sub in rBill) 
                                if (rBill.IDKost == Rechnungszeile.IDKost && FSWIsZahler(new Guid(Rechnungszeile.IDKost), ENV.FSW_IDIntern) && !lstZeilen.Contains(new Guid(Rechnungszeile.ID)))
                                {

                                    if (generic.sEquals(Rechnungszeile.Kennung, "LZ"))
                                    {
                                        //offen Basispreis aus DB holen (statt rechnen). Muss zwar das selbe rauskommen, aber ist sauberer.
                                        Zeile++;
                                        Invoice.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, Zeile, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl, Rechnungszeile.Netto / Rechnungszeile.Anzahl, Rechnungszeile.Netto));
                                        ZahlungsbetragNetto += Rechnungszeile.Netto;
                                        lstZeilen.Add(new Guid(Rechnungszeile.ID));
                                    }
                                    else if(generic.sEquals(Rechnungszeile.Kennung, "GSGB"))
                                    {
                                        Zeile++;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.BaseAmount = Rechnungszeile.Brutto / 0.04M;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Percentage = 4;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.Amount = Rechnungszeile.Brutto;
                                        Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount = 0;
                                        ZahlungsbetragNetto += Rechnungszeile.Brutto;
                                        lstZeilen.Add(new Guid(Rechnungszeile.ID));
                                    }
                                }
                            }
                            if (Zeile > 0)                     //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update)
                                ListIDBillsFSW.Add(IDBill);

                            Invoice.TotalGrossAmount = ZahlungsbetragNetto;
                            Invoice.PayableAmount = ZahlungsbetragNetto;
                            Invoice.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFID;
                            Transaction.ArDocument.AddInvoiceToList(Invoice);
                        }
                    }
                    //Transaction updaten
                    Transaction.SenderAdresse = ENV.FSW_SenderAdresse;
                    Transaction.TransactionID = eZAUFID;
                    Transaction.ArDocument.Referenz = eZAUFID;
                    Transaction.ArDocument.Rechnungsbetrag = ZahlungsbetragNetto;
                    Transaction.ArDocument.Anzahl_Rechnungen = ListIDBillsFSW.Count;

                    string ret = "";
                    if (ListIDBillsFSW.Count > 0)
                    {
                        if (!SetStatusOnly)
                        {
                            string Filepath = ENV.FSW_EZAUF;    //offen User nach Speicherort fragen
                            string Filename = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFID + "_" + Transaction.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xml";
                            string FQFileXML = Path.Combine(Filepath, Filename);

                            Chilkat.Global glob = new Chilkat.Global();
                            if (!glob.UnlockBundle("S2ENG.CB1032020_S2VwQSty6L2t"))
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("System-Fehler beim Erstellen der Zahlungsaufforderung:" + glob.LastErrorText, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            //Transaction -> XML
                            if (!MakeXML(Transaction, out Chilkat.Xml Xml, out string Msg))
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Konvertieren in Export-Format: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            //Speichern
                            if (!SaveXML(Xml, ref FQFileXML, out Msg))
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Exportdatei wurde nicht gespeichert: " + Msg, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            //Hochladen
                            ret = Upload(Filename, FQFileXML);
                            if (ret.Length > 0)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Hochladen der Zahlungsaufforderung:" + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            //Exportiert-Kennzeichen setzen
                            ret = SetExportiertJN(ListIDBillsFSW, true, db);
                            if (ret.Length == 0)
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zahlungsaufforderung für " + ListIDBillsFSW.Count.ToString() + " Rechnung(en) an FSW gesendet.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zahlungsaufforderung wurde gesendet. Fehler beim Sichern des ZAUF-Zustands: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            //Exportiert-Kennzeichen zurücksetzen
                            ret = SetExportiertJN(ListIDBillsFSW, false, db);
                            if (ret.Length == 0)
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status Zahlungsaufforderung für " + ListIDBillsFSW.Count.ToString() + " Rechnung(en) zurückgesetzt.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Zurücksetzen des ZAUF-Zustands: " + ret, MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Rechnungen für diese Akion qualifiziert.", MsgBoxTitle, System.Windows.Forms.MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.core.abrech.cs.FSWAbrechnung: " + ex.ToString());
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

        public static bool MakeXML(PMDS.Global.db.cEBInterfaceDB.Transaction Transaction, out Chilkat.Xml Xml, out string Message)
        {
            try
            {
                Message = "";
                Chilkat.Xml retXMl = null;
                using (Chilkat.Xml xTransaction = new Chilkat.Xml())
                {
                    NumberFormatInfo nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";
                    CultureInfo ci = new CultureInfo("de-DE");

                    xTransaction.Encoding = "utf-8";
                    xTransaction.Tag = "Transaction";
                    xTransaction.AddAttribute("SenderAdresse", Transaction.SenderAdresse);
                    xTransaction.AddAttribute("EmpfaengerAdresse", Transaction.EmfaengerAdresse);
                    xTransaction.AddAttribute("TransactionID", Transaction.TransactionID);

                    Chilkat.Xml xArDocument = xTransaction.NewChild("ArDocument", "");
                    xArDocument.AddAttribute("Referenz", Transaction.ArDocument.Referenz);
                    xArDocument.AddAttribute("User_Erstellung", Transaction.ArDocument.User_Erstellung);
                    xArDocument.AddAttribute("Datum_Erstellung", Transaction.ArDocument.Datum_Erstellung.ToString(DateTimeFormat, ci));
                    xArDocument.AddAttribute("Rechunungsbetrag", Transaction.ArDocument.Rechnungsbetrag.ToString(nfi));
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
                            Chilkat.Xml xInvoiceNumber = xInvoice.NewChild("InvoiceNumber", Invoice.InvoiceNumber);
                            Chilkat.Xml xInvoiceDate = xInvoice.NewChild("InvoiceDate", Invoice.InvoiceDate.ToString(DateFormat, ci));
                            Chilkat.Xml xAdditionalInformation = xInvoice.NewChild("AdditionalInformation", "");

                            Chilkat.Xml xDelivery = xInvoice.NewChild("Delilvery", "");
                            Chilkat.Xml xPeriod = xDelivery.NewChild("Period", "");
                            Chilkat.Xml xFromDate = xPeriod.NewChild("FromDate", Invoice.Delivery.Period.FromDate.ToString(DateFormat, ci));
                            Chilkat.Xml xToDate = xPeriod.NewChild("ToDate", Invoice.Delivery.Period.ToDate.ToString(DateFormat, ci));

                            Chilkat.Xml xBiller = xInvoice.NewChild("Biller", "");
                            Chilkat.Xml xBillerVATIdentificationNumber = xBiller.NewChild("VATIdentificationNumber", Invoice.Biller.VATIdentificationNumber);
                            Chilkat.Xml xBillerAdress = xBiller.NewChild("Adress", "");
                            Chilkat.Xml xBillerAdressName = xBillerAdress.NewChild("Name", Invoice.Biller.Adress.Name);
                            Chilkat.Xml xBillerAdressStreet = xBillerAdress.NewChild("Street", Invoice.Biller.Adress.Street);
                            Chilkat.Xml xBillerAdressPOBox = xBillerAdress.NewChild("POBox", "");
                            Chilkat.Xml xBillerAdressTown = xBillerAdress.NewChild("Town", Invoice.Biller.Adress.Town);
                            Chilkat.Xml xBillerAdressZIP = xBillerAdress.NewChild("ZIP", Invoice.Biller.Adress.ZIP);
                            Chilkat.Xml xBillerAdressCountry = xBillerAdress.NewChild("Country", Invoice.Biller.Adress.Country.Value);
                            Chilkat.Xml xBillerBillersInvoiceRecipientID = xBiller.NewChild("BillersInvoiceRecipientID", Invoice.Biller.InvoiceRecipientsBillerID);
                            xBillerAdressCountry.AddAttribute(Invoice.Biller.Adress.Country.AttributeName, Invoice.Biller.Adress.Country.AttributeValue);

                            Chilkat.Xml xInvoiceRecipient = xInvoice.NewChild("InvoiceRecipient", "");
                            Chilkat.Xml xInvoiceRecipientVATIdentificationNumber = xInvoiceRecipient.NewChild("VATIdentificationNumber", Invoice.InvoiceRecipient.VATIdentificationNumber);
                            Chilkat.Xml xFurtherIdentification = xInvoiceRecipient.NewChild("FurtherIdentification", Invoice.InvoiceRecipient.FurtherIdentification.Value);
                            xInvoiceRecipient.AddAttribute(Invoice.InvoiceRecipient.FurtherIdentification.AttributeName, Invoice.InvoiceRecipient.FurtherIdentification.AttributeValue);
                            Chilkat.Xml xInvoiceRecipientAdress = xInvoiceRecipient.NewChild("Adress", "");
                            Chilkat.Xml xInvoiceRecipientAdressName = xInvoiceRecipientAdress.NewChild("Name", Invoice.InvoiceRecipient.Adress.Name);
                            Chilkat.Xml xInvoiceRecipientAdressStreet = xInvoiceRecipientAdress.NewChild("Street", Invoice.InvoiceRecipient.Adress.Street);
                            Chilkat.Xml xInvoiceRecipientAdressPOBox = xInvoiceRecipientAdress.NewChild("POBox", "");
                            Chilkat.Xml xInvoiceRecipientAdressTown = xInvoiceRecipientAdress.NewChild("Town", Invoice.InvoiceRecipient.Adress.Town);
                            Chilkat.Xml xInvoiceRecipientAdressZIP = xInvoiceRecipientAdress.NewChild("ZIP", Invoice.InvoiceRecipient.Adress.ZIP);
                            Chilkat.Xml xInvoiceRecipientAdressCountry = xInvoiceRecipientAdress.NewChild("Country", Invoice.InvoiceRecipient.Adress.Country.Value);
                            xInvoiceRecipientAdressCountry.AddAttribute(Invoice.InvoiceRecipient.Adress.Country.AttributeName, Invoice.InvoiceRecipient.Adress.Country.AttributeValue);

                            Chilkat.Xml xDetails = xInvoice.NewChild("Details", "");
                            Chilkat.Xml xDetailsHeaderDescription = xDetails.NewChild("HeaderDescription", Invoice.Details.HeaderDescription);
                            Chilkat.Xml xDetailsItemList = xDetails.NewChild("ItemList", "");

                            foreach (db.cEBInterfaceDB.ListLineItem item in Invoice.Details.ItemList)
                            {
                                using (Chilkat.Xml xListLineItem = new Chilkat.Xml())
                                {
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
                                    Chilkat.Xml xListLineItemAmount = xListLineItem.NewChild("ItemAmount", item.LineItemAmount.ToString(nfi));
                                    xDetails.AddChildTree(xListLineItem);
                                }
                            }

                            Chilkat.Xml xReductionAndSurchargeDetails = xInvoice.NewChild("ReductionAndSurchargeDetails", "");
                            Chilkat.Xml xReductionAndSurchargeDetailsSurcharge = xReductionAndSurchargeDetails.NewChild("Surcharge", "");
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargeBaseAmount = xReductionAndSurchargeDetailsSurcharge.NewChild("BaseAmount", Invoice.ReductionAndSurchargeDetails.Surcharge.BaseAmount.ToString(nfi));
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargePercentage = xReductionAndSurchargeDetailsSurcharge.NewChild("Percentage", Invoice.ReductionAndSurchargeDetails.Surcharge.Percentage.ToString(nfi));
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargeAmount = xReductionAndSurchargeDetailsSurcharge.NewChild("Amount", Invoice.ReductionAndSurchargeDetails.Surcharge.Amount.ToString(nfi));
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItem = xReductionAndSurchargeDetailsSurcharge.NewChild("TaxItem", "");
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItemTaxableAmount = xReductionAndSurchargeDetailsSurchargeTaxItem.NewChild("TaxableAmount", Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount.ToString(nfi));
                            Chilkat.Xml xReductionAndSurchargeDetailsSurchargeTaxItemTaxPercent = xReductionAndSurchargeDetailsSurchargeTaxItem.NewChild("TaxPercent", Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.Value.ToString(nfi));
                            xReductionAndSurchargeDetailsSurchargeTaxItemTaxPercent.AddAttribute(Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.AttributeName, Invoice.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxPercent.AttributeValue);

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
                    Xml = xTransaction;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Xml = new Chilkat.Xml();
                Message = ex.Message;
                return false;
            }
        }

        public static bool SaveXML(Chilkat.Xml Xml, ref string FQFilename,  out string Message)
        {
            Message = "";
            string Filter = "";
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.InitialDirectory = ENV.FSW_EZAUF;
                    dlg.FileName = FQFilename;
                    dlg.Filter = "FSW-Zahlungsaufforderungen|*.xml";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        FQFilename = dlg.FileName;
                        Xml.SaveXml(dlg.FileName);
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
                    if (sftp.Connect("sftp.example.com", 22))
                        if (sftp.AuthenticatePw("myLogin", "myPassword"))
                            if (sftp.InitializeSftp())
                                if (sftp.UploadFileByName(RemoteFilename, LocalFQFilename))
                                {
                                    return sftp.LastErrorText;
                                }

                    return sftp.LastErrorText;
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
