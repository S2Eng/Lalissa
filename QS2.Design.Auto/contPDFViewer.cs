using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patagames.Pdf.Net;
using QS2.Resources;
using System.IO;
using qs2.core.vb;

namespace qs2.design.auto
{
    public partial class contPDFViewer : UserControl
    {
        private string PDFFile { get; set; }
        private PdfDocument PDFDoc { get; set; }
        private PdfForms PDFForm { get; set; }
        private bool PDFShowBookmarks { get; set; } = true;
        private bool PDFShowOpenDialog { get; set; } = true;
        private bool PDFShowPrintDialog { get; set; } = true;
        private bool PDFShowSaveDialog { get; set; } = true;
        const int HSpace = 5;
        private static Point BookmarkViewerLeft = new Point(HSpace, 76);
        const string UserPrefix = "User_";

        public contPDFViewer()
        {
            InitializeComponent();
        }

        public bool Init(in string Filename, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport)
        {
            try
            {
                PdfCommon.Initialize(qs2.core.ENV.PdfiumKey);

                pdfToolStripZoom1.Items[0].Text = "";
                pdfToolStripZoom1.Items[2].Text = "";

                pdfToolStripMain1.Items[0].Text = "";
                pdfToolStripMain1.Items[0].Image = getRes.getIcon(getRes.Allgemein.ico_Oeffnen, 32, 32).ToBitmap();
                pdfToolStripMain1.Items[1].Text = "";
                pdfToolStripMain1.Items[1].Image = getRes.getIcon(getRes.Allgemein.ico_Drucken, 32, 32).ToBitmap();
                pdfToolStripMain1.Items[2].Text = "";
                pdfToolStripMain1.Items[2].Image = getRes.getIcon(getRes.Allgemein.ico_Speichern, 32, 32).ToBitmap();

                PDFFile = Filename;

                //bestehendes PDF einfach öffnen
                if ((InfoQuery == null || InfoReport == null) && File.Exists(PDFFile))
                {
                    LoadPDF(PDFFile);
                    ShowPDF();
                    return true;
                }
                else if (InfoQuery != null && InfoReport != null && File.Exists(PDFFile))
                {
                    //Pro Datensatz ein eigenes PDF erstellen und die FDFs darin ersetzen
                    string TableName = qs2.core.dbBase.tableNameQueries + InfoQuery.rSelListQry.IDRessource;

                    var mainForm = new PdfForms();
                    var mainDoc = PdfDocument.CreateNew(mainForm);
                    using (DataTable dt = InfoQuery.dsQryResult.Tables[TableName])
                    {
                        lblCount.Text = qs2.core.generic.TranslateEx("Found") + ": " + dt.Rows.Count.ToString();
                        if (LoadPDF(Filename))
                        {
                            qs2.core.generic.FrmProgressInit(0, dt.Rows.Count, "Init ...");

                            for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
                            {
                                //FDF-Felder ersetzen
                                SetFDFValuesFromActiveUser();
                                SetFDFValuesFromQueryRow(dt.Rows[RowCount]);
                                SetDocumentAutomatisation(dt.Rows[RowCount]);

                                mainDoc.Pages.ImportPages(PDFDoc, null, mainDoc.Pages.Count);
                                if (RowCount > 1)       //Wenn mehrere Dokumente konsolidiert werden -> PDF automatisch flatten
                                {
                                    mainDoc.Pages[RowCount - 1].FlattenPage(Patagames.Pdf.Enums.FlattenFlags.NormalDisplay);
                                    mainDoc.Pages[RowCount].FlattenPage(Patagames.Pdf.Enums.FlattenFlags.NormalDisplay);
                                }
                                qs2.core.generic.FrmProgressUpdate(RowCount, (RowCount + 1).ToString() + " / " + dt.Rows.Count.ToString());

                                // PDFDoc.Save(@"C:\Temp\" + Guid.NewGuid().ToString() + ".pdf", Patagames.Pdf.Enums.SaveFlags.NoIncremental);
                            }
                            qs2.core.generic.FrmProgressClose();
                        }
                    }

                    pdfViewer1.Document = mainDoc;
                    PDFDoc = mainDoc;
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("contPDFViewer.Init: " + ex.ToString());
            }
            finally
            {
                qs2.core.generic.FrmProgressClose();
            }
        }

        public void SetToolstrips (bool ShowBookmarks, bool ShowOpenDioalog, bool ShowPrintDialog, bool ShowSaveDialog)
        {
            PDFShowBookmarks = ShowBookmarks;
            PDFShowOpenDialog = ShowOpenDioalog;
            PDFShowPrintDialog = ShowPrintDialog;
            PDFShowSaveDialog = ShowSaveDialog;

            bookmarksViewer1.Visible = PDFShowBookmarks;
            pdfToolStripMain1.Items[0].Visible = PDFShowOpenDialog;
            pdfToolStripMain1.Items[1].Visible = PDFShowPrintDialog;
            pdfToolStripMain1.Items[2].Visible = PDFShowSaveDialog;

            if (PDFShowBookmarks)
            {
                bookmarksViewer1.Visible = true;
                pdfViewer1.Left = bookmarksViewer1.Left + bookmarksViewer1.Width + HSpace;
                pdfViewer1.Width = Width - pdfViewer1.Left - HSpace;
            }
            else
            {
                bookmarksViewer1.Visible = true;
                pdfViewer1.Left = HSpace;
                pdfViewer1.Width = Width - 2 * HSpace;
            }
        }

        private void ShowPDF()
        {
            this.pdfViewer1.Document = PDFDoc;
            Application.DoEvents();
        }

        private bool LoadPDF(string Filename)
        {
            try
            {
                if (File.Exists(Filename) && qs2.core.generic.sEquals(System.IO.Path.GetExtension(Filename),".PDF"))
                {
                    PDFForm = new PdfForms();
                    using (FileStream file = new FileStream(Filename, FileMode.Open, FileAccess.Read))
                    {
                        MemoryStream ms = new MemoryStream();
                        byte[] bytes = new byte[file.Length];
                        file.Read(bytes, 0, (int)file.Length);
                        ms.Write(bytes, 0, (int)file.Length);
                        PDFDoc = PdfDocument.Load(ms, PDFForm);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contPDFViewer, OpenPDF: " + ex.ToString());
            }
        }

        private bool LoadPDFFromByte(Byte[] bPDF)
        {
            try
            {
                if (bPDF != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PDFForm = new PdfForms();
                        PDFDoc = PdfDocument.Load(bPDF, PDFForm);
                        bPDF = ms.ToArray();
                        Application.DoEvents();
                        return true;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("contPDFViewer, OpenPDFFromByte: " + ex.ToString());
            }
        }

        private void SetFDFValueByFieldname(in string FieldName, in string FieldValue)
        {
            //Feld in Form suchen
            foreach (var field in PDFForm.InterForm.Fields)
            {
                if (qs2.core.generic.sEquals(field.FullName,FieldName))
                {
                    if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                    {
                        field.Value = FieldValue;
                        return;
                    }
                    else if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_CHECKBOX)
                    {
                        for (int j = 0; j < field.Controls.Count(); j++)
                        {
                            if (field.Controls[j].ExportValue == FieldValue.ToString())
                            {
                                field.CheckControl(j, true);
                                return;
                            }
                        }
                    }
                }
            }    
        }

        private void SetFDFValueByIndex(in int Fieldindex, in string FieldValue)
        {

            if (PDFForm.InterForm.Fields[Fieldindex].FieldType.Equals(Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD))
            {
                PDFForm.InterForm.Fields[Fieldindex].Value = FieldValue;
                return;
            }
            
            if (PDFForm.InterForm.Fields[Fieldindex].FieldType.Equals(Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_CHECKBOX))
            {
                for (int j = 0; j < PDFForm.InterForm.Fields[Fieldindex].Controls.Count(); j++)
                {
                    if (PDFForm.InterForm.Fields[Fieldindex].Controls[j].ExportValue == FieldValue.ToString())
                    {
                        PDFForm.InterForm.Fields[Fieldindex].CheckControl(j, true);
                        return;
                    }
                }
            }

            if (PDFForm.InterForm.Fields[Fieldindex].FieldType.Equals(Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_LISTBOX))
            {
                for (int j = 0; j < PDFForm.InterForm.Fields[Fieldindex].Options.Count(); j++)
                {
                    if (PDFForm.InterForm.Fields[Fieldindex].Options[j].Value == FieldValue.ToString())
                    {
                        PDFForm.InterForm.Fields[Fieldindex].SelectItem(j, true);
                        return;
                    }
                }
            }

        }

        private void SetFDFValuesFromUserClassification(string Classification)
        {
            //string Classification = qs2.core.vb.actUsr.rUsr.Classification;
            if (!string.IsNullOrWhiteSpace(Classification))
            {
                string[] AddEntries = Classification.Replace("\n", "").Replace("\r", "").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string AddEntry in AddEntries)
                {
                    string[] KeyPairs = AddEntry.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (KeyPairs.Length == 2)
                        SetFDFValueByFieldname(KeyPairs[0].Trim(), KeyPairs[1].Trim());
                }
            }
        }

        private void SetFDFValuesFromActiveUser()
        {            
            dsObjects.tblObjectRow actUser = qs2.core.vb.actUsr.rUsr;
            foreach (DataColumn c in actUser.Table.Columns) 
            {
                int FieldNr = 0;
                foreach (var field in PDFForm.InterForm.Fields)
                {
                    if (qs2.core.generic.sEquals(c.ColumnName,"Classification"))
                    {
                        SetFDFValuesFromUserClassification((string)actUser[c.ColumnName]);
                    }
                    else if (qs2.core.generic.sEquals(field.FullName,UserPrefix + c.ColumnName))
                    {
                        SetFDFValueByIndex(FieldNr, actUser[c.ColumnName].ToString());
                    }
                    FieldNr++;
                }                
            }
        }
       
        private void SetFDFValuesFromQueryRow(DataRow dataRow)
        {
            int FieldNr = 0;
            foreach (var field in PDFForm.InterForm.Fields)
            {
                foreach (DataColumn c in dataRow.Table.Columns)
                {
                    if (qs2.core.generic.sEquals(field.FullName,c.ColumnName))
                    {
                        SetFDFValueByIndex(FieldNr, dataRow[c.ColumnName].ToString());
                    }
                }
                FieldNr++;
            }
        }

        private void SetDocumentAutomatisation(DataRow dataRow)
        {
            qs2.design.auto.print.cRTFDocuments cRTF = new print.cRTFDocuments();
            List<KeyValuePair<string, string>> ListPrepDef = cRTF.PrepareDocumentValues(dataRow);

            foreach (KeyValuePair<string, string> kpv in ListPrepDef)
            {
                SetFDFValueByFieldname(kpv.Key, kpv.Value);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            core.vb.funct funct1 = new funct();
            string fileSelected = funct1.saveFile(false, qs2.core.vb.funct.pdfFileType, "", qs2.core.vb.funct.getFolder(Environment.SpecialFolder.Desktop));

            if (!String.IsNullOrWhiteSpace(fileSelected))
            {
                PDFDoc.Save(fileSelected, Patagames.Pdf.Enums.SaveFlags.Incremental);
            }
        }
    }
}
