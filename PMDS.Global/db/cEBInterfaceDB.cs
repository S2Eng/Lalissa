using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.Global.db
{
    public class cEBInterfaceDB
    {
        public static DateTime Now { get; set; } = DateTime.Now;
        public Guid IDFSW { get; set; } = ENV.FSW_IDIntern;

        public class cAttribute
        {
            public string AttributeValue { get; set; } = "";
            public string AttributeName { get; set; } = "";
        }

        public class AttributedValue
        {
            public string AttributeValue { get; set; } = "";
            public string AttributeName { get; set; } = "";
            public string Value { get; set; } = "";
        }

        public class AttributedValueDecimal
        {
            public string AttributeValue { get; set; } = "";
            public string AttributeName { get; set; } = "";
            public decimal Value { get; set; } = 0;
        }

        public class Transaction
        {
            public string SenderAdresse { get; set; } = "";
            public string EmfaengerAdresse { get; set; } = "1000101";
            public string TransactionID { get; set; }
            public ArDocument ArDocument { get; set; } = new ArDocument();
        }

        public class ArDocument
        {
            public string Referenz { get; set; } = "";
            public string User_Erstellung { get; set; } = ENV.ActiveUser.Vorname + " " + ENV.ActiveUser.Nachname;
            public DateTime Datum_Erstellung { get; set; } = Now;
            public decimal Rechnungsbetrag { get; set; }
            public int Anzahl_Rechnungen { get; set; }
            public List<Invoice> lstInvoices { get; } = new List<Invoice>();
            public void AddInvoiceToList(Invoice Invoice)
            {
                lstInvoices.Add(Invoice);
            }
        }

        public class Invoice
        {
            public List<cAttribute> Attributes { get; } = new List<cAttribute>();
            public void AddAtributeToList (cAttribute Attribute)
            {
                Attributes.Add(Attribute);
            }
            public string InvoiceNumber { get; set; } = "";
            public DateTime InvoiceDate { get; set; } = Now;
            public Delivery Delivery { get; set; } = new Delivery();
            public Biller Biller { get; set; } = new Biller();
            public InvoiceRecipient InvoiceRecipient { get; set; } = new InvoiceRecipient();
            public Details Details { get; set; } = new Details();
            public ReductionAndSurchargeDetails ReductionAndSurchargeDetails { get; set; } = new ReductionAndSurchargeDetails();
            public string Tax { get; set; } = "";
            public decimal TotalGrossAmount { get; set; } = 0;
            public decimal PayableAmount { get; set; } = 0;
            public PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();
        }

        public class Period
        {
            public DateTime FromDate { get; set; } = Now;
            public DateTime ToDate { get; set; } = Now;
        }

        public class Delivery
        {
            public Period Period { get; set; } = new Period();
        }

        public class Adress
        {
            public string Name { get; set; } = "";
            public string Street { get; set; } = "";
            public string POBox { get; set; } = "";
            public string Town { get; set; } = "";
            public string ZIP { get; set; } = "";
            public AttributedValue Country { get; set; } = new AttributedValue() { AttributeName = "CountryCode", AttributeValue = "AT", Value = "Österreich" };
            public string CountryCode { get; set; } = "AT";
        }

        public class Biller
        {
            public string VATIdentificationNumber { get; set; } = "";
            public Adress Adress { get; set; } = new Adress();
            public string InvoiceRecipientsBillerID { get; set; } = "";
        }

        public class InvoiceRecipient
        {
            public string VATIdentificationNumber { get; set; } = "";
            public AttributedValue FurtherIdentification { get; set; } = new AttributedValue() { AttributeName = "IdentificationType", AttributeValue = "Payer", Value = "" };
            public Adress Adress { get; set; } = new Adress();
            public string BillersInvoiceRecipientID { get; set; } = "";
        }

        public class BillersOrderReferenz
        {
            public string OrderID { get; set; } = "";
        }

        public class TaxItem
        {
            public decimal TaxableAmount { get; set; }
            public AttributedValueDecimal TaxPercent { get; set; } = new AttributedValueDecimal() { AttributeName = "TaxCategoryCode", AttributeValue = "O", Value = 0 };            
        }
        public class ListLineItem
        {
            public int PositionNumber { get; set; } = 0;
            public string Description { get; set; } = "";
            public string ArticleNumber { get; set; } = "";

            public AttributedValueDecimal Quantity { get; set; } = new AttributedValueDecimal() { AttributeName = "Unit", AttributeValue = "Day", Value = 0 };
            public AttributedValueDecimal UnitPrice { get; set; } = new AttributedValueDecimal() { AttributeName = "BaseQuantity", AttributeValue = "1", Value = 0 };
            public BillersOrderReferenz BillersOrderReferenz { get; set; } = new BillersOrderReferenz();
            public TaxItem TaxItem { get; set; } = new TaxItem();
            public decimal LineItemAmount { get; set; } = 0;
        }

        public class Details
        {
            public string HeaderDescription { get; set; } = "Zahlungsaufforderung Zeitraum ";
            public string HeaderDescriptionKorrektur { get; set; } = "Korrektur zur Zahlungsaufforderung Zeitraum ";
            public List<ListLineItem> ItemList { get; set; } = new List<ListLineItem>();
        }

        public class Surcharge
        {
            public decimal BaseAmount { get; set; } = 0;
            public decimal Percentage { get; set; } = 4;
            public decimal Amount { get; set; } = 0;
            public string Comment { get; } = "";
            public TaxItem TaxItem { get; set; } = new TaxItem();
        }

        public class ReductionAndSurchargeDetails
        {
            public Surcharge Surcharge { get; set; } = new Surcharge();
        }

        public class BeneficiaryAccount
        {
            public string BankName { get; set; } = "";
            public AttributedValue BankCode { get; set; } = new AttributedValue() { AttributeName = "BankCodeType", AttributeValue = "AT", Value = "" };
            public string BIC { get; set; } = "";
            public string BankAccountNr { get; set; } = "";
            public string IBAN { get; set; } = "";
            public string BankAccountOwner { get; set; } = "";
        }

        public class UniversalBankTransaction
        {
            public string AttributeValue { get; set; } = "";
            public string AttributeName { get; set; } = "";
            public BeneficiaryAccount BeneficiaryAccount { get; set; } = new BeneficiaryAccount();
            public string PaymentReference { get; set; } = "";
        }

        public class PaymentMethod
        {
            public string Comment { get; set; } = "";
            public UniversalBankTransaction UniversalBankTransaction { get; set; } = new UniversalBankTransaction() { AttributeName = "ConsolidatorPayable", AttributeValue = "false" };
        }

        //-------------------------------------------------------------------------------------------
        public static Invoice Init(Guid IDKlinik, Guid IDKlient)
        {
            try
            {
                Now = DateTime.Now;
                Invoice ret = new Invoice();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rKlinik = (from k in db.Klinik
                                   join adr in db.Adresse on k.IDAdresse equals adr.ID
                                   join bank in db.Bank on k.IDBank equals bank.ID
                                   where k.ID == IDKlinik
                                   select new
                                   {
                                       IDKlinik = k.ID,
                                       Bezeichnung = k.Bezeichnung.Trim(),
                                       Bank = bank.Bezeichnung.Trim(),
                                       BIC = bank.BIC.Trim(),
                                       IBAN = bank.IBAN.Trim(),
                                       Strasse = adr.Strasse.Trim(),
                                       Ort = adr.Ort.Trim(),
                                       PLZ = adr.Plz.Trim(),
                                       UID = k.ZVR.Trim()
                                   }).First();

                    var rKlient = (from p in db.Patient
                                   join adr in db.Adresse on p.IDAdresse equals adr.ID
                                   where p.ID == IDKlient
                                   select new
                                   {
                                       IDPatient = p.ID,
                                       Name = (p.Titel.Trim() + " " + p.Vorname.Trim() + " " + p.Nachname.Trim() + " " + p.TitelPost.Trim()).Trim(),
                                       Strasse = adr.Strasse,
                                       PLZ = adr.Plz,
                                       Ort = adr.Ort,
                                       WohnungAbgemeldet = p.WohnungAbgemeldetJN,
                                       BillersInvoiceRecipientID = p.FIBUKonto.Trim(),
                                       SVNr = p.VersicherungsNr
                                   }
                                   ).First();

                    ret.AddAtributeToList(new cAttribute() { AttributeName = "xmlns", AttributeValue = @"http://wwww.ebinterface.at/schema/5p0/" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "xmns:xsi", AttributeValue = @"http://www.w3.org/2001/XMLSchema" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "GeneratigSystem", AttributeValue = "PMDS" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "DocumentType", AttributeValue = "Invoice" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "InvoiceCurrency", AttributeValue = "EUR" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "DocumentTitle", AttributeValue = "EBInterface" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "Language", AttributeValue = "ger" });
                    ret.AddAtributeToList(new cAttribute() { AttributeName = "xsi:schemaLocation", AttributeValue = @"http://www.ebinterface.at/schema/5p0/ ../Invoice.xsd" });

                    ret.Biller.VATIdentificationNumber = (rKlinik.UID.Substring(rKlinik.UID.ToUpper().IndexOf("ATU"))).Replace(" ", "");
                    ret.Biller.Adress.Name = rKlinik.Bezeichnung;
                    ret.Biller.Adress.Street = rKlinik.Strasse;
                    ret.Biller.Adress.Town = rKlinik.Ort;

                    ret.InvoiceRecipient.FurtherIdentification.Value = rKlient.SVNr;
                    ret.InvoiceRecipient.Adress.Name = rKlient.Name;
                    ret.InvoiceRecipient.Adress.Street = (rKlient.WohnungAbgemeldet ?? false) ? rKlient.Strasse : rKlinik.Strasse;
                    ret.InvoiceRecipient.Adress.ZIP = (rKlient.WohnungAbgemeldet ?? false) ? rKlient.PLZ : rKlinik.PLZ;
                    ret.InvoiceRecipient.Adress.Town = (rKlient.WohnungAbgemeldet ?? false) ? rKlient.Ort : rKlinik.Ort;
                    ret.InvoiceRecipient.BillersInvoiceRecipientID = String.IsNullOrWhiteSpace(rKlient.BillersInvoiceRecipientID) ? rKlient.SVNr : rKlient.BillersInvoiceRecipientID;

                    ret.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BankName = rKlinik.Bank;
                    ret.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.IBAN = rKlinik.IBAN;
                    ret.PaymentMethod.UniversalBankTransaction.BeneficiaryAccount.BIC = rKlinik.BIC;
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.core.db.cEEBInterfaceDB.cs. init: " + ex.Message);
            }
        }

        public ListLineItem MakeNewLineItem(string Rechnungsnummer, int PositionNumber, string Description, decimal Quantity, decimal PreisProEinheit, decimal Netto, decimal TaxableAmount, decimal TaxPercent)
        {
            try
            {
                ListLineItem NewLine = new ListLineItem();
                NewLine.PositionNumber = PositionNumber;
                NewLine.Description = Description;
                NewLine.Quantity.Value = Quantity;
                NewLine.UnitPrice.Value = PreisProEinheit;
                NewLine.BillersOrderReferenz.OrderID = Rechnungsnummer + PositionNumber.ToString();
                NewLine.LineItemAmount = Netto;
                NewLine.TaxItem.TaxableAmount = TaxableAmount;
                NewLine.TaxItem.TaxPercent.Value = TaxPercent;
                return NewLine;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.core.db.cEEBInterfaceDB.cs.MakeNewLineItem: " + ex.Message);
            }
        }
    }
}
