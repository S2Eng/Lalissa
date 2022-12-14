using Patagames.Pdf.Enums;
using Patagames.Pdf.Net;
using Patagames.Pdf.Net.Controls.WinForms;
using PMDS.db.Entities;
using PMDS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using S2Extensions;


namespace PMDS.GUI.GUI.Main
{    


    public partial class frmFormularManager : Form
    {
        
        public bool IsNew = true;
        public bool PDFDocumentIsLocked = true;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        private QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
        private QS2.Desktop.Txteditor.contTXTField contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
        private eFormMode _FormMode;
        private eFormMode FormMode
        {
            get
            {
                return _FormMode;
            }
            set
            {
                _FormMode = value;
                this.panelDoc.Visible = _FormMode == eFormMode.rtf;
                this.panelGird.Visible = _FormMode == eFormMode.pdf;
                this.panelDoc.Left = panelGird.Left;
                this.panelDoc.Top = panelGird.Top;
                this.panelDoc.Width = panelGird.Width;
                this.panelDoc.Height = panelGird.Height;
            }
        }

        public frmFormularManager()
        {
            InitializeComponent();
            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
        }


        private void frmFormularManager_Load(object sender, EventArgs e)
        {
          
        }

        private enum eFormMode
        {
            none = 0,
            pdf = 1,
            rtf = 2
            
        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel .Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.clearUI();
                this.loadAllFormularFromDB(null);
                this.IsNew = true;

                this.btnAdd.Visible = true;
                this.btnDel.Visible = false;
                this.btnAbort.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnPrint2.Visible = false;
                this.cboFormulare.ReadOnly = false;

                this.cboBerufsgruppen.initControl("BER");
                this.cboBerufsgruppen.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtFormularname2.Text = "";
                this.txtBezeichnung2.Text = "";
                this.chkGUI.Checked = false;
                this.chkInNotfallAnzeigenJN.Checked = false;
                this.chkNeuanlageSperren.Checked = false;
                this.numEditHours.Value = -1;
                FormMode = eFormMode.none;
            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.clearUI: " + ex.ToString());
            }
        }

        public void loadAllFormularFromDB(Nullable<Guid> IDFormulaToSelect)
        {
            try
            {
                this.clearUI();
                this.cboFormulare.Items.Clear();
                this.cboFormulare.Value = null;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Formular> tFormular = db.Formular.OrderBy(o => o.Bezeichnung);
                    foreach (Formular rFormular in tFormular)
                    {
                        if (rFormular.PDF_BLOP != null)
                        {
                            this.cboFormulare.Items.Add(rFormular.ID, rFormular.Bezeichnung.Trim());
                        }
                    }
                }

                this.btnAdd.Visible = false;
                this.btnDel.Visible = false;
                this.btnAbort.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnPrint2.Visible = false;
                this.cboFormulare.ReadOnly = false;

                if (IDFormulaToSelect != null)
                {
                    foreach (Infragistics.Win.ValueListItem itm in this.cboFormulare.Items)
                    {
                        if (itm.DataValue.Equals(IDFormulaToSelect.Value))
                        {
                            this.cboFormulare.SelectedItem = itm;
                            this.loadFormular(IDFormulaToSelect.Value);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.loadAllFormularFromDB: " + ex.ToString());
            }
        }

        public void loadFormular(Guid IDFormular)
        {
            try
            {
                this.clearUI();
                this.IsNew = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(IDFormular, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("loadFormular: tFormular.Count() == 0 for  IDFormular '" + IDFormular.ToString().Trim() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    this.txtBezeichnung2.Text = rFormular.Bezeichnung.Trim();
                    this.txtFormularname2.Text = rFormular.Name.Trim();
                    this.chkGUI.Checked = rFormular.GUI;
                    this.chkInNotfallAnzeigenJN.Checked = rFormular.InNotfallAnzeigenJN;
                    this.chkNeuanlageSperren.Checked = rFormular.NeuanlageSperren;
                    this.numEditHours.Value = rFormular.EditHours;

                    if (rFormular.Name.sEquals(".s2frm", Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.pdf;
                        this.PDFDocumentIsLocked = false;
                        this.pdfViewer1.LoadDocument(rFormular.PDF_BLOP);
                    }
                    else if (rFormular.Name.sEquals(".s2frmRTF", Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.rtf;
                        panelDoc.Controls.Clear();
                        this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
                        this.contTXTFieldBeschreibung.TXTControlField.ZoomFactor = 150;
                        this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.PageView, true, true, false, false, true, false);
                        this.contTXTFieldBeschreibung.Dock = DockStyle.Fill;
                        this.panelDoc.Controls.Add(contTXTFieldBeschreibung);
                        Application.DoEvents();
                        this.contTXTFieldBeschreibung.TXTControlField.Load(rFormular.PDF_BLOP, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                    }

                    this.btnAdd.Visible = true;
                    this.btnDel.Visible = true;
                    this.btnAbort.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnPrint2.Visible = true;
                    this.cboFormulare.ReadOnly = false;
                    this.cboBerufsgruppen.setSelectedRowsID(rFormular.lstIDBerufsgruppe.Trim());
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                this.PDFDocumentIsLocked = true;
                throw new Exception("frmFormularManager.loadFormular: " + ex.ToString());
            }
        }

        public bool saveData(Nullable<Guid> IDFormular)
        {
            try
            {
                if (this.txtFormularname2.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formularname: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                if (this.txtBezeichnung2.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Formular rFormular = null;
                    if (this.IsNew)
                    {
                        rFormular = PMDS.Global.db.ERSystem.EFEntities.newFormular(db);
                        rFormular.ID = System.Guid.NewGuid();
                        rFormular.BLOP = "";
                        db.Formular.Add(rFormular);
                    }
                    else
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(IDFormular.Value, db);
                        if (tFormular.Count() != 1)
                        {
                            throw new Exception("loadFormular: tFormular.Count() == 0 for  IDFormular '" + IDFormular.Value.ToString().Trim() + "' not allowed!");
                        }
                        rFormular = tFormular.First();
                    }

                    rFormular.Name = this.txtFormularname2.Text.Trim();
                    rFormular.Bezeichnung = this.txtBezeichnung2.Text.Trim();
                    rFormular.InNotfallAnzeigenJN = this.chkInNotfallAnzeigenJN.Checked;
                    rFormular.GUI = this.chkGUI.Checked;
                    rFormular.NeuanlageSperren = this.chkNeuanlageSperren.Checked;
                    rFormular.EditHours = (int)this.numEditHours.Value;
                    rFormular.lstIDBerufsgruppe = this.cboBerufsgruppen.getSelectedRowsID();

                    System.Linq.IQueryable<Formular> tFormularCheck = db.Formular.Where(o => o.ID != rFormular.ID && o.Name == rFormular.Name.Trim());
                    if (tFormularCheck.Count() > 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formularname existiert bereits!", "", MessageBoxButtons.OK);
                        return false;
                    }

                    if (FormMode == eFormMode.pdf)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            this.pdfViewer1.Document.FormFill.InterForm.ResetForm();
                            this.pdfViewer1.Document.Save(ms, SaveFlags.RemoveSecurity);
                            Byte[] bPDF = ms.ToArray();
                            rFormular.PDF_BLOP = bPDF;
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            this.pdfViewer1.Document.Save(ms, SaveFlags.RemoveSecurity);
                            Byte[] bPDF = ms.ToArray();
                            rFormular.PDF_BLOP = bPDF;
                        }
                    }
                    else if (FormMode == eFormMode.rtf)
                    {
                        this.contTXTFieldBeschreibung.TXTControlField.Save(out byte[] binaryData, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                        rFormular.PDF_BLOP = binaryData;
                    }
                    db.SaveChanges();

                    this.clearUI();
                    this.loadAllFormularFromDB(rFormular.ID);
                    this.cboFormulare.ReadOnly = false;
                }
                
                ucDatenErhebung.AssesstmensHasChanged = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten wurden gesichert!", "", MessageBoxButtons.OK);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.saveData: " + ex.ToString());
            }
        }
        public bool addFormular()
        {
            try
            {
                this.openFileDialog1.Filter = "PDF-Dateien|*.pdf|RTF-Dateien|*.rtf";
                DialogResult result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName.Trim();
                    this.clearUI();
                    this.cboFormulare.Value = null;
                    this.IsNew = true;
                    this.pdfViewer1.Document = null;
                    this.pdfViewer1.ClearRenderBuffer();

                    this.btnAdd.Visible = false;
                    this.btnDel.Visible = false;
                    this.PDFDocumentIsLocked = false;

                    FileInfo info = new FileInfo(file);
                    FileAttributes attributes = info.Attributes;
                    string FileName = System.IO.Path.GetFileNameWithoutExtension(file);
                    string FileExtension = Path.GetExtension(file);

                    this.txtBezeichnung2.Text = FileName.Trim();

                    if (FileExtension.sEquals(".pdf"))
                    {
                        this.txtFormularname2.Text = FileName.Trim() + ".s2frm";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            var form = new PdfForms();
                            var docu = PdfDocument.Load(file, form);
                            docu.Save(ms, SaveFlags.RemoveSecurity);
                            this.pdfViewer1.Document = docu;
                            this.PDFDocumentIsLocked = true;
                            this.panelDoc.Visible = false;
                            this.panelGird.Visible = true;
                            this.pdfViewer1.Enabled = true;
                            FormMode = eFormMode.pdf;
                        }
                    }
                    else if (FileExtension.sEquals(".rtf", Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.rtf;
                        panelDoc.Controls.Clear();
                        this.txtFormularname2.Text = FileName.Trim() + ".s2frmRTF";

                        this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
                        this.contTXTFieldBeschreibung.TXTControlField.ZoomFactor = 150;
                        this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.PageView, true, true, false, false, true, false);
                        this.contTXTFieldBeschreibung.Dock = DockStyle.Fill;
                        this.panelDoc.Controls.Add(contTXTFieldBeschreibung);
                        Application.DoEvents();
                        this.contTXTFieldBeschreibung.TXTControlField.Load(file, TXTextControl.StreamType.RichTextFormat);
                    }

                    Application.DoEvents();

                    this.btnAbort.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnPrint2.Visible = (FormMode == eFormMode.pdf);
                    this.cboFormulare.ReadOnly = true;
                    Application.DoEvents();
                }
                return true;
            }
            catch (Exception ex)
            {
                this.PDFDocumentIsLocked = true;
                throw new Exception("frmFormularManager.addFormular: " + ex.ToString());
            }
        }
        public bool deleteFormular(Guid IDFormular)
        {
            try
            {
                DialogResult resDialog = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Datensatz wirklich löschen?", "", MessageBoxButtons.YesNo);
                if (resDialog == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(IDFormular, db);
                        if (tFormular.Count() != 1)
                        {
                            throw new Exception("ucFormAsses1_evClickEvent: tFormular.Count() == 0 for  IDFormular '" + IDFormular.ToString().Trim() + "' not allowed!");
                        }
                        PMDS.db.Entities.Formular rFormular = tFormular.First();

                        db.Formular.Remove(rFormular);
                        ucDatenErhebung.AssesstmensHasChanged = true;
                        db.SaveChanges();

                        this.clearUI();
                        this.PDFDocumentIsLocked = false;

                        if (FormMode == eFormMode.pdf)
                        {
                            this.pdfViewer1.Document = null;
                            this.pdfViewer1.ClearRenderBuffer();
                            this.pdfViewer1.Enabled = true;
                        }
                        else if (FormMode == eFormMode.rtf)
                        {
                            this.contTXTFieldBeschreibung.TXTControlField.Clear();
                        }

                        FormMode = eFormMode.none;
                        this.loadAllFormularFromDB(null);

                        this.btnAdd.Visible = true;
                        this.btnDel.Visible = false;
                        this.btnAbort.Enabled = false;
                        this.btnSave.Enabled = false;
                        this.btnPrint2.Visible = false;
                        this.PDFDocumentIsLocked = true;
                        this.cboFormulare.ReadOnly = false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                this.PDFDocumentIsLocked = true;
                throw new Exception("frmFormularManager.deleteFormular: " + ex.ToString());
            }
        }

        public Nullable<Guid> getSelectedFormular()
        {
            try
            {
                if (this.cboFormulare.Value == null)
                {
                    return null;
                }
                else
                {
                    return (Guid)this.cboFormulare.Value;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.getSelectedFormular: " + ex.ToString());
            }
        }

        public void print()
        {
            try
            {
                if (pdfViewer1.Document != null)
                {
                    var printDoc = new PdfPrintDocument(pdfViewer1.Document);

                    var dlg = new PrintDialog();
                    dlg.AllowCurrentPage = true;
                    dlg.AllowSomePages = true;
                    dlg.UseEXDialog = true;
                    dlg.Document = printDoc;
                    if (dlg.ShowDialog() == DialogResult.OK)
                        printDoc.Print();
                }
                else
                {
                    MessageBox.Show("No document loaded!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmFormularManager.print: " + ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDFormularSelected = this.getSelectedFormular();
                if (IDFormularSelected != null)
                {
                    this.saveData(IDFormularSelected);
                }
                else
                {
                    if (!this.IsNew)
                    {
                        throw new Exception("btnSave_Click: !this.IsNew not allowed!");
                    }
                    this.saveData(null);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDFormularSelected = this.getSelectedFormular();
                if (IDFormularSelected != null)
                {
                    this.deleteFormular(IDFormularSelected.Value);
                }
                else
                {
                    MessageBox.Show("No formula selected");
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addFormular();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboFormulare_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboFormulare.Focused)
                {
                    if (this.cboFormulare.Value != null && this.cboFormulare.Value.GetType().Equals(typeof(Guid)))
                    {
                        this.loadFormular((Guid)this.cboFormulare.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.PDFDocumentIsLocked = false;
                this.clearUI();

                if (FormMode == eFormMode.pdf)
                {
                    this.pdfViewer1.Document = null;
                    this.pdfViewer1.ClearRenderBuffer();
                }
                else
                {
                    this.contTXTFieldBeschreibung.TXTControlField.Clear();
                }
                FormMode = eFormMode.none;
                this.loadAllFormularFromDB(null);

                this.btnAdd.Visible = true;
                this.btnDel.Visible = false;
                this.btnAbort.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnPrint2.Visible = false;
                this.PDFDocumentIsLocked = true;
                this.cboFormulare.ReadOnly = false;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.PDFDocumentIsLocked = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.print();
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pdfViewer1_BeforeDocumentChanged(object sender, Patagames.Pdf.Net.EventArguments.DocumentClosingEventArgs e)
        {
            try
            {
                //e.Cancel = this.PDFDocumentIsLocked;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void pdfViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void pdfViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void txtFormularname2_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
