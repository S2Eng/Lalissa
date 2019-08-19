using Patagames.Pdf.Net;
using Patagames.Pdf.Net.Controls.WinForms;
using PMDS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI.Datenerhebung
{



    public partial class frmAssessement : Form
    {
        public Guid _IDFormular;
        public Guid _IDFormulardata;
        public Guid _IDPatient;
        public bool _IsNew = false;
        public bool abort = true;

        public ucAssessement mainWindow = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();






        public frmAssessement()
        {
            InitializeComponent();
        }

        private void frmAssessement_Load(object sender, EventArgs e)
        {
            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
        }




        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                

            }
            catch (Exception ex)
            {
                throw new Exception("frmAssessement.initControl: " + ex.ToString());
            }
        }

        public void loadData(Guid IDFormular, Guid IDFormulardata, bool IsNew, Guid IDPatient)
        {
            try
            {
                this._IDFormular = IDFormular;
                this._IDFormulardata = IDFormulardata;
                this._IsNew = IsNew;
                this._IDPatient = IDPatient;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(this._IDFormular, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("ucFormAsses1_evClickEvent:tFormular.Count() == 0 for  r.FormularName '" + this._IDFormular.ToString().Trim() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByID(this._IDFormulardata, db);
                    PMDS.db.Entities.FormularDaten rFormularDaten = tFormularDaten.First();

                    PMDS.db.Entities.Patient rPatient = b.getPatient(this._IDPatient, db);
                    this.Text = rFormular.Bezeichnung .Trim () + " " +  QS2.Desktop.ControlManagment.ControlManagment.getRes("vom") + " " + rFormularDaten.Datumerstellt.ToString("dd.MM.yyyy HH:mm:ss") + " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("für") + " " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + "";

                    this.pdfViewer1.LoadDocument(rFormular.PDF_BLOP);
                    PdfForms formFDF = pdfViewer1.Document.FormFill;
                    formFDF.InterForm.ImportFromFdf(FdfDocument.Load(rFormularDaten.PDF_BLOP));
                    Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmAssessement.saveData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(this._IDFormular, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("ucFormAsses1_evClickEvent:tFormular.Count() == 0 for  r.FormularName '" + this._IDFormular.ToString().Trim() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    PMDS.db.Entities.FormularDaten rFormularDaten = null;
                    System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByID(this._IDFormulardata, db);
                    if (tFormularDaten.Count() == 0)
                    {
                        rFormularDaten = PMDS.Global.db.ERSystem.EFEntities.newFormularDaten(db);
                        db.FormularDaten.Add(rFormularDaten);
                        rFormularDaten.ID = Guid.NewGuid();
                        rFormularDaten.IDBenutzer_Erstellt = PMDS.Global.ENV.USERID;
                        rFormularDaten.Datumerstellt = DateTime.Now;
                        rFormularDaten.FormularName = rFormular.Name;
                        rFormularDaten.IDREF = _IDPatient;
                        this._IDFormulardata = rFormularDaten.ID;
                    }
                    else
                    {
                        rFormularDaten = tFormularDaten.First();
                    }

                    PdfForms form = this.pdfViewer1.Document.FormFill;
                    form.ForceToKillFocus();
                    FdfDocument fdfOut = form.InterForm.ExportToFdf("");
                    Byte[] bFDF = Encoding.Default.GetBytes(fdfOut.Content);
                    rFormularDaten.PDF_BLOP = bFDF;
                
                    db.SaveChanges();

                    this.mainWindow.saveFormualDataToDB(rFormularDaten);
                }
            

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("frmAssessement.saveData: " + ex.ToString());
            }
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
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

        private void frmAssessement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ucAssessement.lstFormularDataundocked.Remove(this);

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

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var printDoc = new PdfPrintDocument(this.pdfViewer1.Document);

                var dlg = new PrintDialog();
                dlg.AllowCurrentPage = true;
                dlg.AllowSomePages = true;
                dlg.UseEXDialog = true;
                dlg.Document = printDoc;
                if (dlg.ShowDialog() == DialogResult.OK)
                    printDoc.Print();

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

    }
}
