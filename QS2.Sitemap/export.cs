using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;



namespace qs2.sitemap
{


    public partial class export : UserControl
    {


        public enum eTypExport
        {
            excel = 56100,
            word = 56101,
            pdf = 56102,
            xml = 56103,
            csv = 56104
        }

        public export()
        {
            InitializeComponent();
        }

        private void export_Load(object sender, EventArgs e)
        {

        }
        
        public void doExport(UltraGrid grid, Environment.SpecialFolder toFolder, eTypExport typExport, System.Data.DataSet dsToExport,
                            string TitleDocument, string DescriptionDocument, System.Collections.Generic.Dictionary<string, string> lstColsTableTranslated)
        {
            try
            {
                qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
                string fileSelected = "";

                if (typExport == eTypExport.excel)
                    fileSelected = funct1.saveFile(false, qs2.core.vb.funct.excelFileType, "", qs2.core.vb.funct.getFolder(toFolder));
                else if (typExport == eTypExport.word)
                    fileSelected = funct1.saveFile(false, qs2.core.vb.funct.wordFileType, "", qs2.core.vb.funct.getFolder(toFolder));
                else if (typExport == eTypExport.pdf)
                    fileSelected = funct1.saveFile(false, qs2.core.vb.funct.pdfFileType, "", qs2.core.vb.funct.getFolder(toFolder));
                else if (typExport == eTypExport.xml)
                    fileSelected = funct1.saveFile(false, qs2.core.vb.funct.xmlFileType, "", qs2.core.vb.funct.getFolder(toFolder));
                else if (typExport == eTypExport.csv)
                    fileSelected = funct1.saveFile(false, qs2.core.vb.funct.CsvFileType, "", qs2.core.vb.funct.getFolder(toFolder));

                if (fileSelected != null)
                {
                    if (System.IO.File.Exists(fileSelected))
                    {
                        try
                        {
                            System.IO.File.Delete(fileSelected);
                        }
                        catch (Exception ex)
                        {
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FielCanNotReplacedPleaseSelectAnOtherFileName") + "?", MessageBoxButtons.OK, "");
                            return;
                        }
                    }

                    if (typExport == eTypExport.excel)
                    {
                        this.ultraGridExcelExporter1.Export(grid, fileSelected);
                    }
                    else if (typExport == eTypExport.word)
                    {
                        Infragistics.Documents.Word.WordDocumentWriter wordDocWriter = Infragistics.Documents.Word.WordDocumentWriter.Create(fileSelected);
                        Infragistics.Documents.Word.Font font = wordDocWriter.CreateFont();
                        wordDocWriter.StartDocument();
                        wordDocWriter.StartParagraph();
                        font.Bold = true;
                        if (TitleDocument.Trim() != "")
                        {
                            wordDocWriter.AddTextRun(TitleDocument, font);
                            wordDocWriter.AddNewLine();
                        }
                        font.Reset();
                        if (DescriptionDocument.Trim() != "")
                        {
                            wordDocWriter.AddTextRun(DescriptionDocument);
                        }
                        wordDocWriter.EndParagraph();
                        wordDocWriter.AddEmptyParagraph();
                        this.ultraGridWordWriter1.Export(grid, wordDocWriter);
                        wordDocWriter.EndDocument();
                        wordDocWriter.Close();
                    }
                    else if (typExport == eTypExport.pdf)
                    {
                        this.ultraGridDocumentExporter1.Export(grid, fileSelected, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF);
                    }
                    else if (typExport == eTypExport.xml)
                    {
                        dsToExport.WriteXml(fileSelected);
                    }
                    else if (typExport == eTypExport.csv)
                    {
                        this.doCSV(grid, toFolder, typExport, dsToExport, fileSelected, ref lstColsTableTranslated);
                    }

                    if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("OpenFileYN") + "?", MessageBoxButtons.YesNo, "") == DialogResult.Yes)
                        funct1.openFile(fileSelected, "", false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("export.doExport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool doCSV(UltraGrid grid, Environment.SpecialFolder toFolder, eTypExport typExport, System.Data.DataSet dsToExport, string fileSelected, 
                             ref System.Collections.Generic.Dictionary<string, string> lstColsTableTranslated)
        {
            try
            {
                string Separator = qs2.core.language.sqlLanguage.getRes("SeparatorCSV");
                string resultCsv = "";

                foreach (DataTable table in dsToExport.Tables)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        string txtToTranslate = col.ColumnName;
                        if (txtToTranslate.Trim().Contains(qs2.core.generic.prefixColAutoTranslate))
                        {
                            txtToTranslate = txtToTranslate.Substring(qs2.core.generic.prefixColAutoTranslate.Length, txtToTranslate.Length - qs2.core.generic.prefixColAutoTranslate.Length);
                        }
                        if (lstColsTableTranslated.ContainsKey(txtToTranslate))
                        {
                            string sTransCol = lstColsTableTranslated[txtToTranslate];
                            resultCsv += sTransCol + Separator;
                        }
                        else
                        {
                            resultCsv += col.ColumnName + Separator;
                        }
                    }
                    resultCsv += qs2.core.generic.lineBreak;
                    foreach (System.Data.DataRow r in table.Rows)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            resultCsv += r[col.ColumnName] + Separator;
                        }
                        resultCsv += qs2.core.generic.lineBreak;
                    }
                }

                System.IO.FileStream FileStream1 = new System.IO.FileStream(fileSelected, System.IO.FileMode.CreateNew);
                System.IO.StreamWriter StreamWriter1 = new System.IO.StreamWriter(FileStream1, Encoding.UTF8);
                StreamWriter1.Write(resultCsv);
                StreamWriter1.Close();
                FileStream1.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("export.doCSV:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        private void ultraGridWordWriter1_ExportStarted(object sender, Infragistics.Win.UltraWinGrid.WordWriter.ExportStartedEventArgs e)
        {

        }
    }
}
