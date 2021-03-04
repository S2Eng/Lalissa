using System;
using System.Linq;
using System.Windows.Forms;
using Patagames.Pdf.Net;     
using System.IO;
using System.Collections.Generic;

namespace PMDS.GUI.BaseControls
{
    public partial class frmPDF : Form
    {


        public frmPDF()
        {
            InitializeComponent();
            Patagames.Pdf.Net.PdfCommon.Initialize("52433553494d50032923be84e16cd6ae0bce153446af7918d52303038286fd2b0597de34bf5bb65e2a161a268e74107bd7da7c1adb202edff3e8c55a13bff7afa38569c96e45ff0cdef48e36b8df77e907676788cae00126f52c5eaadbb3c424062e8e0e5feb6faf89900306ee469aa40664bdf84b2e4fce7497c19f3f9d2d877dc1be192cb695f4");
            pdfToolStripZoom1.Items[0].Text = "";
            pdfToolStripZoom1.Items[2].Text = "";
            pdfToolStripMain1.Items[0].Text = "";
            pdfToolStripMain1.Items[1].Text = "";
            pdfToolStripMain1.Items[2].Text = "";
        }

        public PdfDocument doc = null;
        public PdfForms form = null;

        private bool _showBookmarks;
        private bool _showOpenDialog;
        private bool _showPrintDialog;
        private bool _showSaveDialog;
        private string _frmCaption;
        public List<string> FileNamesToRemove { get; set; } = new List<string>();
        private bool _removeFileBeforeClose;
        private string sFileName;


        public bool ShowBookmarks
        {
            get { return _showBookmarks; }
            set
            {
                _showOpenDialog = value;
                bookmarksViewer1.Visible = _showBookmarks;
                int pdfVieweright = this.pdfViewer1.Right;
                if (_showBookmarks == false)
                    pdfViewer1.Left = bookmarksViewer1.Left;
                else
                    pdfViewer1.Left = bookmarksViewer1.Left + bookmarksViewer1.Width + 6;
                pdfViewer1.Width = pdfVieweright - pdfViewer1.Left;
            }
        }

        public bool ShowOpenDialog
        {
            get { return _showOpenDialog; }
            set
            {
                _showOpenDialog = value;
                pdfToolStripMain1.Items[0].Visible = _showOpenDialog;
            }
        }

        public bool ShowSaveDialog
        {
            get { return _showSaveDialog; }
            set
            {
                _showSaveDialog = value;
                pdfToolStripMain1.Items[2].Visible = _showSaveDialog;
            }
        }

        public bool ShowPrintDialog
        {
            get { return _showPrintDialog; }
            set
            {
                _showPrintDialog = value;
                pdfToolStripMain1.Items[1].Visible = _showPrintDialog;
            }
        }

        public string SetCaption
        {
            get { return _frmCaption; }
            set
            {
                _frmCaption = value;
                this.Text = _frmCaption;
            }
        }

        public bool RemoveFileBeforeClose
        {
            get { return _removeFileBeforeClose; }
            set
            {
                _removeFileBeforeClose = value;
            }
        }

        public bool OpenPDF(string pdfFile, out Byte[] bPDF)
        {
            try
            {
                if (File.Exists(pdfFile) && System.IO.Path.GetExtension(pdfFile).Equals(".PDF", StringComparison.CurrentCultureIgnoreCase) )
                {
                    sFileName = pdfFile;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        form = new PdfForms();
                        doc = PdfDocument.Load(pdfFile, form);
                        bPDF = ms.ToArray();
                        this.pdfViewer1.Document = doc;
                        Application.DoEvents();
                        return true;
                    }
                }
                else
                {
                    bPDF = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmPDF, OpenPDF: " + ex.ToString());
            }
        }

        public bool OpenPDFFromByte(Byte[] bPDF)
        {
            try
            {
                if (bPDF  != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        form = new PdfForms();
                        doc = PdfDocument.Load(bPDF, form);
                        bPDF = ms.ToArray();
                        this.pdfViewer1.Document = doc;
                        Application.DoEvents();
                        return true;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("frmPDF, OpenPDF: " + ex.ToString());
            }
        }

        public bool SetValue(string FieldName, string FieldValue, PdfForms form)
        {
            try
            {
                //Feld in Form suchen
                foreach (var field in form.InterForm.Fields)
                {
                    if (field.FullName.Equals(FieldName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                        {
                            field.Value = FieldValue;
                            return true;
                        }
                        else if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_CHECKBOX)
                        {
                            for (int j = 0; j < field.Controls.Count(); j++)
                            {
                                if (field.Controls[j].ExportValue == FieldValue.ToString())
                                {
                                    field.CheckControl(j, true);
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("frmPDF, SetValue: " + ex.ToString());
            }
        }

        private void pdfToolStripMain1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Adobe PDF|*.pdf";
                    if (dlg.ShowDialog() == DialogResult.OK)
                        pdfViewer1.Document.Save(dlg.FileName, Patagames.Pdf.Enums.SaveFlags.NoIncremental);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmPDF, Save_Click: " + ex.ToString());
            }
        }

        private void frmPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (string FileNameToRemove in FileNamesToRemove)
                if (RemoveFileBeforeClose && File.Exists(FileNameToRemove))
                {
                    File.Delete(FileNameToRemove);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmPDF, frmPDF_FormClosed: " + ex.ToString());
            }
        }
    }
}
