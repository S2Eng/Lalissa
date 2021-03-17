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

namespace PMDS.Global
{
    public class FSWAbrechnung
    {
        private string DateFormat = "yyyy-MM-dd";
        private string DateTimeFormat = "yyyyMMddHHmmss";
        private string eZAUFID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
        private List<string> ListIDBillsFSW = new List<string>();                   //Sammelt die Rechungen des FSW

        private List<PMDS.Global.db.cEBInterfaceDB.Rechnungsinhalt> lstRechnungen = new List<db.cEBInterfaceDB.Rechnungsinhalt>();
        private List<Guid> lstZeilen = new List<Guid>();

        //------------------------ ebInterface / Abrechnungsschittstelle zum FSW -----------------------------
        public void GenerateFSWStructure(Guid IDKlinik, List<string> ListIDBills)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = calculation.delgetDBContext.Invoke())
                {
   
                    decimal ZahlungsbetragNetto = 0;

                    foreach (string IDBill in ListIDBills ?? new List<string>())
                    {
                        bills rBill = readBill(IDBill);
                        billHeader rHeader = readBillHeader(rBill.IDAbrechnung, IDKlinik);
                        using (dbCalc dbCalc = getDBCalc(rHeader.dbCalc))
                        {
                            //Prüfungen
                            if (!rBill.Freigegeben)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nicht freigegebene Rechnungen können nicht an den FSW gesendet werden.", "FSW -Exportfile erstellen", System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            if (rBill.ExportiertJN)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereits gesednete Rechnungen können nicht nocheinmal gesendet werden.", "FSW -Exportfile erstellen", System.Windows.Forms.MessageBoxButtons.OK);
                                return;
                            }

                            PMDS.Global.db.cEBInterfaceDB FSWRechnung = new db.cEBInterfaceDB();
                            PMDS.Global.db.cEBInterfaceDB.Rechnungsinhalt Rechnung = PMDS.Global.db.cEBInterfaceDB.Init(IDKlinik, new Guid(rBill.IDKlient));

                            Rechnung.InvoiceNumber = rBill.RechNr;
                            Rechnung.InvoiceDate = (DateTime)rBill.RechDatum;
                            Rechnung.Delivery.Period.FromDate = dbCalc.Monate[0].Beginn;
                            Rechnung.Delivery.Period.ToDate = dbCalc.Monate[0].Ende;

                            if (rBill.RollungAnz == 0)
                                Rechnung.Details.HeaderDescription = "Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");
                            else
                                Rechnung.Details.HeaderDescription = "Korrektur zur Zahlungsaufforderung Zeitraum " + rBill.datum.ToString("MMMM") + " " + rBill.datum.ToString("yyyy");

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
                                        Rechnung.Details.ItemList.Add(FSWRechnung.MakeNewLineItem(rBill.RechNr, Zeile, Rechnungszeile.Bezeichnung, (decimal)Rechnungszeile.Anzahl, Rechnungszeile.Netto / Rechnungszeile.Anzahl, Rechnungszeile.Netto));
                                        ZahlungsbetragNetto += Rechnungszeile.Netto;
                                        lstZeilen.Add(new Guid(Rechnungszeile.ID));
                                    }
                                    else if(generic.sEquals(Rechnungszeile.Kennung, "GSGB"))
                                    {
                                        Zeile++;
                                        Rechnung.ReductionAndSurchargeDetails.Surcharge.BaseAmount = Rechnungszeile.Brutto / 0.04M;
                                        Rechnung.ReductionAndSurchargeDetails.Surcharge.Percentage = 4;
                                        Rechnung.ReductionAndSurchargeDetails.Surcharge.Amount = Rechnungszeile.Brutto;
                                        Rechnung.ReductionAndSurchargeDetails.Surcharge.TaxItem.TaxableAmount = 0;
                                        ZahlungsbetragNetto += Rechnungszeile.Brutto;
                                        lstZeilen.Add(new Guid(Rechnungszeile.ID));
                                    }
                                }
                            }
                            if (Zeile > 0)                     //Wenn mindestens eine Rechnungszeile vom FSW bezahlt wird -> Rechnungsnummer in neuer Liste merken (fürs Update)
                                ListIDBillsFSW.Add(IDBill);

                            Rechnung.TotalGrossAmount = ZahlungsbetragNetto;
                            Rechnung.PayableAmount = ZahlungsbetragNetto;
                            Rechnung.PaymentMethod.UniversalBankTransaction.PaymentReference = eZAUFID;
                            lstRechnungen.Add(Rechnung);
                        }
                    }

                    if (ListIDBillsFSW.Count > 0)
                    {
                        //Header erstellen
                        PMDS.Global.db.cEBInterfaceDB.Header Header = PMDS.Global.db.cEBInterfaceDB.MakeHeader();
                        Header.Transaction.SenderAdresse = ENV.FSW_SenderAdresse;
                        Header.Transaction.TransactionID = eZAUFID;
                        Header.ArDocument.Referenz = eZAUFID;
                        Header.ArDocument.Rechnungsbetrag = ZahlungsbetragNetto;
                        Header.ArDocument.Anzahl_Rechnungen = ListIDBillsFSW.Count;

                        
                        string Filepath = ENV.FSW_EZAUF;    //offen User nach Speicherort fragen
                        string Filename = "eZAUF_" + ENV.FSW_SenderAdresse + "_" + eZAUFID + "_" + Header.ArDocument.Datum_Erstellung.ToString(DateTimeFormat) + ".xml";
                        string FileXML = Path.Combine(Filepath, Filename);

                        Chilkat.Global glob = new Chilkat.Global();
                        bool success = glob.UnlockBundle("S2ENG.CB1032020_S2VwQSty6L2t");
                        if (success != true)
                        {
                            Debug.WriteLine(glob.LastErrorText);
                            return;
                        }

                        //offen XML-File erstellen
                        using (Chilkat.Xml xml = new Chilkat.Xml())
                        {

                        }

                        //Hochladen
                        string ret = Upload(Filename, FileXML);
                        if (ret.Length > 0)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Hochladen der Rechnungen:" + ret, "FSW -Exportfile erstellen", System.Windows.Forms.MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            //Kennzeichen Exportiert setzen
                            foreach (string IDBill in ListIDBillsFSW)
                            {
                                var res = db.bills.SingleOrDefault(bills => bills.ID == IDBill);
                                if (res != null)
                                {
                                    res.ExportiertJN = true;
                                }
                            }
                            db.SaveChanges();
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ListIDBillsFSW.Count.ToString() + " Rechnung(en) an FSW exportiert.", "FSW -Exportfile erstellen", System.Windows.Forms.MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Rechnungen für den FSW-Export qualifiziert. Funktion beendet.", "FSW -Exportfile erstellen", System.Windows.Forms.MessageBoxButtons.OK);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.core.abrech.cs.FSWAbrechnung: " + ex.ToString());
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
                System.Xml.XmlTextReader xmlTextReader = new System.Xml.XmlTextReader(new System.IO.StringReader(xml));
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

        private static string Upload (string Filename, string FileXML)
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
                                if (sftp.UploadFileByName(Filename, FileXML))
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
