using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Syncfusion.XlsIO;
using Chilkat;
using Patagames.Pdf.Net;        //https://www.youtube.com/watch?v=IF9cKSUFon8
using Patagames.Pdf.Enums;
using Patagames.Pdf.Net.BasicTypes;
using PMDS.db.Entities;






namespace PMDS.GUI.Misc
{
    public partial class Convert_S2Frm_FDF : Form
    {
       public Convert_S2Frm_FDF()
        {
            InitializeComponent();
            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
        }

        private string sPath = "";
        private string xlsPath = "";
        private string pdfPath = "";
        private string xlsFile = "S2FormsMapping.xlsx";
        private ExcelEngine excelEngine = new ExcelEngine();
        private IWorkbook workbook = null;
        private string sLog = "";
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();





        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Hinweis: PDF ist empfindlich, wenn man allokierten Speicher nicht wieder freigibt, wenn man ihn nicht mehr braucht!!
                //Wenn nicht explizit disposed wird, stürzt die Anwendung mit Speicherfehler ab!

                pdfPath = PMDS.Global.ENV.pathForms;
                xlsPath = Path.Combine(PMDS.Global.ENV.pathForms, xlsFile).ToString();
                Byte[] bPDF = null;
                Byte[] bFDF = null;
                Chilkat.Xml xmlData = new Chilkat.Xml();
                int iCount = 0;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    //1. Konvertierungseinstellungen öffnen S2FormsMapping.xlsx (mit SyncFusion.Excel)
                    if (File.Exists(xlsPath))
                    {
                        workbook = excelEngine.Excel.Workbooks.Open(xlsPath, ExcelOpenType.Automatic);
                        foreach (IWorksheet worksheet in workbook.Worksheets)
                        {
                            //2. für Konvertierungsvorschriften (worksheets) 

                            //Hinweis: Sheet-Namen in Excel können nicht länger als 31 Zeichen. Wenn Formularname länger als 31 Zeichen ist, Formularname in Zelle 1,1 speichern statt Text "Seite"
                            string sFormName = worksheet.Name;
                            string sFormNameLong = worksheet.Range[1, 1].Value;
                            if (!sFormNameLong.Equals("Seite", StringComparison.CurrentCultureIgnoreCase))
                                sFormName = sFormNameLong;

                            System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByName(sFormName, db);
                            foreach (PMDS.db.Entities.FormularDaten rFormularDaten in tFormularDaten)
                            {
                                //if (!rFormularDaten.ID.ToString("D").Equals("D2E2AD45-A938-48E9-BFD3-D9BD76CBF6F8B", StringComparison.CurrentCultureIgnoreCase))
                                //    continue;

                                using (PMDS.db.Entities.ERModellPMDSEntities db1 = PMDS.DB.PMDSBusiness.getDBContext())
                                {
                                    OpenPDF(ref bPDF, b, db1, sFormName);  //Öffnet oder konvertiert das Formular in PDF (Auswahl nach Formularname)
                                    db1.SaveChanges();
                                }

                                //OpenPDF(ref bPDF, b, db, sFormName);  //Öffnet oder konvertiert das Formular in PDF (Auswahl nach Formularname)

                                PdfForms form = new PdfForms();

                                //3. Für alle Formulardaten des Formulars mit Konvertierungsanweisung und gefülltem XML
                                if (rFormularDaten.BLOP != "")
                                {
                                    var doc = PdfDocument.Load(bPDF, form);

                                    //XML-Daten für Formular öffnen
                                    bool success = xmlData.LoadXml2(rFormularDaten.BLOP.ToString(), true);
                                    if (success != true)
                                        throw new Exception("Kein korrektes XML gefunden.");

                                    //Prüfen, ob FDF in Formular Null ist, wenn ja, XML in FDF konvertieren und als Byte[] speichern                                            
                                    if (bPDF != null)
                                    {
                                        //Durch Konvertierungsvorschriften in Excel iterieren
                                        int iAktSeite = 2;
                                        string sSeite = worksheet.Range[2, 1].Value;
                                        string sFeldAlt = worksheet.Range[2, 2].Text.Replace("###", "");
                                        string SFeldNeu = worksheet.Range[2, 3].Text;
                                        string sFeldTyp = worksheet.Range[2, 4].Text;
                                        string sMapping = worksheet.Range[2, 5].Text;

                                        SetHeader("KLIENT", "#KLIENT#", ref xmlData, form.InterForm.Fields, "Text", rFormularDaten.IDREF);
                                        SetHeader("KLIENTGEBDAT", "#KLIENTGEBDAT#", ref xmlData, form.InterForm.Fields, "Text", rFormularDaten.IDREF);
                                        SetHeader("USERCREATED", "#BENUTZERERSTELLT#", ref xmlData, form.InterForm.Fields, "Text", rFormularDaten.IDREF);
                                        SetHeader("CREATED", "#DATUMERSTELLT#", ref xmlData, form.InterForm.Fields, "DateTime", rFormularDaten.IDREF);
                                        SetHeader("CREATED", "#DATUMERSTELLTDATE#", ref xmlData, form.InterForm.Fields, "Date", rFormularDaten.IDREF);
                                        SetHeader("", "#DOCINFO#", ref xmlData, form.InterForm.Fields, "DocInfo", rFormularDaten.IDREF);

                                        //Daten konvertieren
                                        while (sSeite != "")
                                        {
                                            Chilkat.Xml Page = xmlData.GetChildWithAttr("Page", "Pagenumber", sSeite);
                                            if (Page != null)
                                            {
                                                Chilkat.Xml xItem = Page.GetChildWithAttr("Value", "FIELDNAME", sFeldAlt);

                                                if (xItem != null)
                                                {
                                                    foreach (var field in form.InterForm.Fields)
                                                    {
                                                        if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                                                        {
                                                            if (field.FullName.Equals(SFeldNeu, StringComparison.CurrentCultureIgnoreCase))
                                                                if (field.Value == "")


                                                                {
                                                                    field.Value = xItem.Content;
                                                                }
                                                                else
                                                                    field.Value += "\r\n" + xItem.Content;

                                                        }

                                                        else if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_CHECKBOX)
                                                        {
                                                            if (field.FullName.Equals(SFeldNeu, StringComparison.CurrentCultureIgnoreCase))
                                                            {
                                                                List<String> lMappings;
                                                                lMappings = sMapping.Split(';').ToList();

                                                                for (int x = 0; x <= lMappings.Count - 1; x++)
                                                                {
                                                                    List<String> lMapping;
                                                                    lMapping = lMappings[x].Split('|').ToList();

                                                                    if (sFeldTyp.Equals("Radio", StringComparison.CurrentCultureIgnoreCase))
                                                                    {
                                                                        if (xItem.Content.ToString() == lMapping[0])
                                                                        {
                                                                            int selOption = 0;
                                                                            try
                                                                            {
                                                                                selOption = System.Convert.ToInt32(lMapping[1]);
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                int rri = 0;
                                                                            }

                                                                            for (int j = 0; j < field.Controls.Count(); j++)
                                                                            {
                                                                                //Vollständiger Vergleich
                                                                                if (field.Controls[j].ExportValue == selOption.ToString())
                                                                                {
                                                                                    field.CheckControl(j, true);
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                    else if (sFeldTyp.Equals("RadioMulti", StringComparison.CurrentCultureIgnoreCase))
                                                                    {
                                                                        //Bitweiser Vergleich
                                                                        int hex1 = Convert.ToInt32(lMapping[0], 2);
                                                                        int hex2 = Convert.ToInt32(xItem.Content, 2);
                                                                        int a = hex1 & hex2;
                                                                        if (a == hex1 && field.Controls[0].ExportValue.Equals(lMapping[1], StringComparison.CurrentCultureIgnoreCase))
                                                                        {
                                                                            field.CheckControl(0, true);
                                                                        }
                                                                        else
                                                                            field.CheckControl(0, false);

                                                                    }

                                                                    else if (sFeldTyp.Equals("ClickableImage2Radio", StringComparison.CurrentCultureIgnoreCase))
                                                                    {
                                                                        List<String> lBounderies;
                                                                        lBounderies = lMapping[0].Split('-').ToList();
                                                                        double von = double.Parse(lBounderies[0]);
                                                                        double bis = double.Parse(lBounderies[1]);

                                                                        List<String> lMarkers;
                                                                        lMarkers = xItem.Content.Split('#').ToList();
                                                                        for (int m = 0; m <= lMarkers.Count - 1; m++)
                                                                        {
                                                                            List<String> lMarker;
                                                                            lMarker = lMarkers[m].Split(';').ToList();
                                                                            if (lMarker.Count == 2)
                                                                            {
                                                                                double positionX = double.Parse(lMarker[0]);
                                                                                double positionY = double.Parse(lMarker[1]);

                                                                                if (positionX >= von && positionY <= bis)
                                                                                {
                                                                                    for (int j = 0; j < field.Controls.Count(); j++)
                                                                                    {
                                                                                        //Vollständiger Vergleich
                                                                                        int selOption = System.Convert.ToInt32(lMapping[1]);
                                                                                        if (field.Controls[j].ExportValue == selOption.ToString())
                                                                                        {
                                                                                            field.CheckControl(j, true);
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        throw new Exception("Radiobutton: unbekannter Feldtyp: " + sFeldTyp);
                                                                    }
                                                                }
                                                            }
                                                            //Kein Feldname ClickableImageMulti bearbeiten (Schmerz)
                                                            else if (sFeldTyp.Equals("ClickableImageMulti", StringComparison.CurrentCultureIgnoreCase))
                                                            {
                                                                //Image links oben
                                                                double breiteRadio = double.Parse(worksheet.Range[iAktSeite, 6].Value);
                                                                double hoeheRadio = double.Parse(worksheet.Range[iAktSeite, 7].Value);
                                                                double offsetX = double.Parse(worksheet.Range[iAktSeite, 8].Value) * -1;
                                                                double offsetY = double.Parse(worksheet.Range[iAktSeite, 9].Value) * -1;
                                                                double positionX = 0;
                                                                double positionY = 0;

                                                                List<String> lMarkers;
                                                                lMarkers = xItem.Content.Split('#').ToList();
                                                                for (int m = 0; m <= lMarkers.Count - 1; m++)
                                                                {
                                                                    try
                                                                    {
                                                                        List<String> lMarker;
                                                                        lMarker = lMarkers[m].Split(';').ToList();
                                                                        if (lMarker.Count() == 2)
                                                                        {
                                                                            positionX = double.Parse(lMarker[0]);
                                                                            positionY = double.Parse(lMarker[1]);

                                                                            double X = Math.Round(offsetX + (double.Parse(lMarker[0]) / breiteRadio), 0, MidpointRounding.AwayFromZero);
                                                                            double Y = Math.Round(offsetY + (double.Parse(lMarker[1]) / hoeheRadio), 0, MidpointRounding.AwayFromZero);

                                                                            if (field.FullName == SFeldNeu + "." + Y.ToString() + "." + X.ToString())
                                                                            {
                                                                                field.CheckControl(0, true);
                                                                                break;
                                                                            }
                                                                        }
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        int yy = 0;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Feld nicht gefunden
                                                }
                                            }
                                            else
                                            {
                                                //Page nicht gefunden
                                            }

                                            iAktSeite++;
                                            sSeite = worksheet.Range[iAktSeite, 1].Value;
                                            sFeldAlt = worksheet.Range[iAktSeite, 2].Text;
                                            if (sFeldAlt != null)
                                                sFeldAlt = sFeldAlt.Replace("###", "");
                                            SFeldNeu = worksheet.Range[iAktSeite, 3].Text;
                                            sFeldTyp = worksheet.Range[iAktSeite, 4].Text;
                                            sMapping = worksheet.Range[iAktSeite, 5].Text;
                                        }

                                        // und in BLOP_FDF speichern
                                        using (PMDS.db.Entities.ERModellPMDSEntities db1 = PMDS.DB.PMDSBusiness.getDBContext())
                                        {
                                            SaveFDF(ref bFDF, ref form, rFormularDaten, db);
                                            db1.SaveChanges();
                                        }
                                        //SaveFDF(ref bFDF, ref form, rFormularDaten, db);
                                        doc.Dispose();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Kein PDF gefunden: " + rFormularDaten.FormularName);
                                    }
                                }
                                else
                                {
                                    bFDF = rFormularDaten.PDF_BLOP;
                                }

                                sLog += rFormularDaten.FormularName + ": " + rFormularDaten.ID.ToString() + "\r\n";
                                //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\temp\s2frm2pdf.log"))
                                //{
                                //    file.WriteLine(sLog);
                                //}

                                //Anzeigen
                                pdfViewer1.LoadDocument(bPDF);
                                PdfForms formFDF = pdfViewer1.Document.FormFill;
                                formFDF.InterForm.ImportFromFdf(FdfDocument.Load(bFDF));
                                this.lblCountFDF.Text = iCount++.ToString();
                                Application.DoEvents();
                                form.Dispose();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datei " + xlsPath + " nicht vorhanden");
                    }
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.ToString());
            }

            finally
            {
                if (workbook != null)
                    workbook.Close();

                pdfViewer1.Dispose();
                lblCountFDF.Text = "";
            }

        }

        private void SetHeader(string fldOld, string fldNew, ref Chilkat.Xml xmlData, PdfFieldCollections fields, string typ, Guid IDREF)
        {
            try
            {
                foreach (var field in fields)
                {
                    if (field.FullName.Equals(fldNew, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                        {
                            if (xmlData.HasAttribute(fldOld))
                            {
                                if (typ.Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                                    field.Value = xmlData.GetAttrValue(fldOld);
                                else if (typ.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                                    field.Value = GetDateFromString(xmlData.GetAttrValue("CREATED")).ToString("dd.MM.yyyy HH:mm");
                                else if (typ.Equals("Date", StringComparison.CurrentCultureIgnoreCase))
                                    field.Value = GetDateFromString(xmlData.GetAttrValue("CREATED")).ToString("dd.MM.yyyy");
                            }
                            else
                            {
                                //Bei manchen Formulardaten fehlen die Kientennamen???
                                if (fldOld == "KLIENT")
                                {
                                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                                    {
                                        PMDS.db.Entities.Patient rPatienten = b.getPatient(IDREF, db);
                                        field.Value = rPatienten.Nachname + " " + rPatienten.Vorname;
                                    }
                                }
                            }

                            if (typ.Equals("DocInfo", StringComparison.CurrentCultureIgnoreCase))
                            {
                                string txt = "";
                                txt += xmlData.GetAttrValue("FORMULAR").ToUpper().Replace(".S2FRM", "");
                                txt += " / ID=" + xmlData.GetAttrValue("KEYREF").ToUpper();
                                txt += " / " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                                field.Value = txt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetHeader: " + ex.ToString());
            }
        }

        private DateTime GetDateFromString(string sDateTicks)
        {
            try
            {
                long ticks = (long)Convert.ToInt64(sDateTicks);
                DateTime t = new DateTime(ticks);
                return t;
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public void SaveFDF(ref Byte[] fdfByte, ref PdfForms form, PMDS.db.Entities.FormularDaten rFormularDaten, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                form.ForceToKillFocus();        //Letzte Eingabe sichern, wenn Feld nicht verlassen wurden
                FdfDocument fdfOut = form.InterForm.ExportToFdf("");
                Byte[] bFDF = Encoding.Default.GetBytes(fdfOut.Content);
                rFormularDaten.PDF_BLOP = bFDF;
                fdfByte = bFDF;
            }
            catch (Exception ex)
            {
                throw new Exception("SaveFDF: " + ex.ToString());
            }
        }


        public void OpenFDF(ref Byte[] bFDF, PMDS.DB.PMDSBusiness b, PMDS.db.Entities.ERModellPMDSEntities db, Guid ID)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByID(ID, db);
                if (tFormularDaten.Count() == 1)
                {
                    PMDS.db.Entities.FormularDaten rFormularDaten = tFormularDaten.First();
                    if (rFormularDaten.PDF_BLOP != null)
                    {
                        bFDF = rFormularDaten.PDF_BLOP;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Convert_S2Frm_FDF, OpenFDF: " + ex.ToString());
            }
        }


        public void OpenPDF (ref Byte[] bPDF, PMDS.DB.PMDSBusiness b, PMDS.db.Entities.ERModellPMDSEntities db, string sSearch)
        {
           //sSearch = Formularname ohne Extension oder ID (als String)
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = null;
                Guid newGuid;
                if ( Guid.TryParse(sSearch, out newGuid))
                    tFormular = b.getFormularByID(newGuid, db);
                else
                    tFormular = b.getFormularByName(sSearch, db);

                if (tFormular != null &&  tFormular.Count() == 1)
                {
                    PMDS.db.Entities.Formular rFormular = tFormular.First();
                    if (rFormular.PDF_BLOP == null) //Wenn das Formular noch nicht importiert wurde jetzt importieren
                    {
                        string pdfFile = Path.Combine(pdfPath, (Path.Combine(pdfPath, sSearch)) + ".pdf");
                        if (File.Exists(pdfFile))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                var form = new PdfForms();
                                var doc = PdfDocument.Load(pdfFile, form);
                                doc.Save(ms, SaveFlags.RemoveSecurity);
                                bPDF = ms.ToArray();
                                rFormular.PDF_BLOP = bPDF;
                            }
                        }
                        else
                        {
                            throw new Exception("Convert_S2Frm_FDF.Open_FDF.OpenPDF: Formular " + sSearch + " nicht vorhanden.");
                        }
                    }
                    else
                    {
                        bPDF = rFormular.PDF_BLOP;
                    }
                }
                else
                {
                    throw new Exception("Convert_S2Frm_FDF.Open_FDF.OpenPDF: Formular " + sSearch + " nicht in DB enthalten oder mehrdeutig!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Convert_S2Frm_FDF, OpenPD: " + ex.ToString());
            }
        }

        private void btnFDFDaten_Click(object sender, EventArgs e)
        {
            //Für alle FDFs in Formulardaten
            //  Löschen alle Einträge in FormularDatenFelder
            //  Für jedes Feld in Formulardaten.PDF_BLOP
            //      Eintrag in FormularDatenFelder schreiben
            //      Log

            try
            {
                int iCount = 0;
 
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    List<PMDS.db.Entities.FormularDaten> lFormularDaten = new List<PMDS.db.Entities.FormularDaten>();
                    lFormularDaten = b.getAllFormularDaten(db).ToList();
                        foreach (PMDS.db.Entities.FormularDaten rFormularDaten in lFormularDaten)
                    {

                        using (PMDS.db.Entities.ERModellPMDSEntities db1 = PMDS.DB.PMDSBusiness.getDBContext())
                        {

                            string strSQl = "Delete from FormularDatenFelder where IDFormulardaten=@IDFormularDaten";
                            System.Data.Common.DbParameter[] pars = new System.Data.Common.DbParameter[]
                            {
                                new System.Data.SqlClient.SqlParameter {ParameterName="IDFormularDaten", Value=rFormularDaten.ID, DbType= DbType.Guid, SourceColumn= "@IDFormularDaten"}
                            };
                            db1.Database.ExecuteSqlCommand(strSQl, pars);
                        }

                        System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByName(rFormularDaten.FormularName.Replace(".S2frm", ""), db);
                        if (tFormular.Count() == 1)
                        {
                            foreach (PMDS.db.Entities.Formular rFormular in tFormular)
                            {
                                byte[] bFDF = null;
                                OpenFDF(ref bFDF, b, db, rFormularDaten.ID);

                                if (bFDF == null || rFormular.PDF_BLOP == null)
                                {
                                    continue;
                                }

                                using (PdfForms formFDF = new PdfForms())
                                {
                                    FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(bFDF);
                                    Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(rFormular.PDF_BLOP, formFDF);
                                    formFDF.InterForm.ResetForm();
                                    formFDF.InterForm.ImportFromFdf(docFDF);

                                    using (PMDS.db.Entities.ERModellPMDSEntities db1 = PMDS.DB.PMDSBusiness.getDBContext())
                                    {
                                        iCount++;
                                        foreach (var field in formFDF.InterForm.Fields)
                                        {
                                            PMDS.db.Entities.FormularDatenFelder rFormularDatenFelderNeu = new FormularDatenFelder();
                                            rFormularDatenFelderNeu.ID = Guid.NewGuid();
                                            rFormularDatenFelderNeu.IDFormularDaten = rFormularDaten.ID;
                                            rFormularDatenFelderNeu.Feldname = field.FullName;
                                            rFormularDatenFelderNeu.Feldwert = field.Value;
                                            rFormularDatenFelderNeu.Feldtyp = field.FieldType.ToString();
                                            db.FormularDatenFelder.Add(rFormularDatenFelderNeu);
                                            this.lblProgress.Visible = true;
                                            this.lblProgress.Text = iCount.ToString() + ": " + rFormular.Name + " / " + rFormular.GUI.ToString() + " / " + rFormularDaten.Datumerstellt.ToString();
                                            Application.DoEvents();
                                        }
                                        db1.SaveChanges();
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;       //Biografien 
                        }
                        db.SaveChanges();
                    }
                        

                    db.Configuration.AutoDetectChangesEnabled = true;
                }
        
            }
            catch (Exception ex)
            {
                throw new Exception("Convert_S2Frm_FDF, btnFDFDaten_Click: " + ex.ToString());
            }
            finally
            {                
                this.lblProgress.Visible = false;
            }
        }
    }
}
