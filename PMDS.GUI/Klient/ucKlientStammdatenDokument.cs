using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PMDS.Global;
using PMDS.DB;



namespace PMDS.GUI.Klient
{
    
    public partial class ucKlientStammdatenDokument : UserControl
    {

        public bool isInitialized = false;
        public string _NameDocument = "";
        public string _SqlColumnBlob = "";
        public string _SqlColumnFileType = "";
        public string _SqlTable = "";
        public string _IDKey = "";
        public string _docuDocumentFileTypePrefered = "";
        public string _docuDocumentFileTypeSaved = "";
        public byte[] _bytDocument = null;
      
        public bool _docuExists = false;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public PMDS.GUI.VB.clFolder clFolder = new PMDS.GUI.VB.clFolder();
        public PMDS.GUI.Klient.ucKlientStammdatenDokumente mainWindow = null;







        public ucKlientStammdatenDokument()
        {
            InitializeComponent();
            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
        }

        private void ucKlientStammdatenDokument_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument_Load: " + ex.ToString());
            }
        }

        public void initControl()
        {
            try
            {
                if (!this.isInitialized)
                {
                    this.btnAddDocument.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDeleteDocument.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument auswählen und speichern");
                    this.UltraToolTipManager1.SetUltraToolTip(this.btnAddDocument, info);                   

                    info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument löschen");
                    this.UltraToolTipManager1.SetUltraToolTip(this.btnDeleteDocument, info);

                    PMDS.Global.ENV.ENVPatientIDChanged += new PMDS.Global.ENVPatientIDChangedDelegate(this.PatientIDChanged);
                    this.setRightEdit();

                    this.isInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.initControl: " + ex.ToString());
            }
        }
        public void setRightEdit()
        {
            try
            {
                this.panelButtons.Visible = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.PatientenVerwalten) && !PMDS.Global.historie.HistorieOn; 
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.setRightEdit: " + ex.ToString());
            }
        }
        void PatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            try
            {
                this.showInfoDocument();

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.PatientIDChanged: " + ex.ToString());
            }
        }

        public void showInfoDocument()
        {
            try
            {
                this.initControl();
                this.checkIDs();
                this.setRightEdit();

                DataTable dt = new DataTable();
                if (this.b.checkDocumentKlientExists(PMDS.Global.ENV.CurrentIDPatient, this._SqlTable.Trim(), this.docuSqlColumnBlob.Trim(), this.docuSqlColumnFileType, this._IDKey.Trim(), ref dt))
                {
                    this.lblDocuStatus.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument öffnen");
                    this.btnDeleteDocument.Visible = true;
                    this.btnAddDocument.Visible = false;
                    
                   

                    DataRow rDocu = (DataRow)dt.Rows[0];
                    this._bytDocument = (byte[])rDocu[this._SqlColumnBlob.Trim()];
                    this._docuDocumentFileTypeSaved = rDocu[this._SqlColumnFileType.Trim()].ToString();

                    this._docuExists = true;
                }
                else
                {
                    this._docuExists = false;
                    this.lblDocuStatus.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein Dokument vorhanden");
                    this.btnDeleteDocument.Visible = false;
                    this.btnAddDocument.Visible = true;
                    this._bytDocument = null;
                    this._docuDocumentFileTypeSaved = "";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.showInfoDocument: " + ex.ToString());
            }
        }
        public void checkIDs()
        {
            try
            {
                if (this._IDKey.Trim() == "")
                {
                    throw new Exception("ucKlientStammdatenDokument_Load: _IDKey='' not allowed!");
                }
                if (this._SqlColumnBlob.Trim() == "")
                {
                    throw new Exception("ucKlientStammdatenDokument_Load: _SqlColumnBlob='' not allowed!");
                }
                if (this._SqlColumnFileType.Trim() == "")
                {
                    throw new Exception("ucKlientStammdatenDokument_Load: _SqlColumnFileType='' not allowed!");
                }
                if (this._SqlTable.Trim() == "")
                {
                    throw new Exception("ucKlientStammdatenDokument_Load: _SqlTable='' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.checkIDs: " + ex.ToString());
            }
        }
        

        public bool addDocument()
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                OpenFileDialog dialog = new OpenFileDialog();
                if (this.docuDocumentFileTypePrefered.Trim() != "")
                {
                    dialog.Filter = this.docuDocumentFileTypePrefered.Trim() + "|All files (*.*)|*.*";
                }
                else
                {
                    dialog.Filter = "pdf-files (*.pdf)|*.pdf|word-files (*.docx)|*.docx|All files (*.*)|*.*";
                }
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wählen Sie bitte eine Datei aus:");
                DialogResult DialogRes = dialog.ShowDialog();
                if (DialogRes == DialogResult.OK)
                {
                    if (System.IO.File.Exists(dialog.FileName))
                    {
                        string FileType = Path.GetExtension(dialog.FileName).Trim();
                        using (System.IO.FileStream fs = new FileStream(dialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            using (System.IO.BinaryReader r = new System.IO.BinaryReader(fs))
                            {
                                this._bytDocument = r.ReadBytes(System.Convert.ToInt32(fs.Length));
                            }
                        }

                        if (this.b.saveDocumentForKlient(PMDS.Global.ENV.CurrentIDPatient, this._SqlTable.Trim(), this._SqlColumnBlob.Trim(), this._SqlColumnFileType, this._IDKey.Trim(), this._bytDocument, FileType, false))
                        {
                            this.addPflegeeintrag();
                            this.showInfoDocument();
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.addDocument: " + ex.ToString());
            }
        }
        public void addPflegeeintrag()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //os191224
                    var rPatInfo = (from p in db.Patient
                                    where p.ID == ENV.CurrentIDPatient
                                    select new
                                    { p.Nachname, p.Vorname }
                                       ).First();
                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(Settings.CurrentIDPatient, db);
                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument für Klient '") + rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' hinterlegt");
                    PMDS.db.Entities.Benutzer rUsr = this.b.LogggedOnUser();

                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == PMDS.Global.ENV.IDAUFENTHALT);
                    PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                    PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.b.AddPflegeeintrag(db, sText, DateTime.Now, null, rAufenthalt.IDBereich,
                                                                    rAufenthalt.ID, null, PflegeEintragTyp.Klient,
                                                                    null, rAufenthalt.IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument für Klient"));

                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.b.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.addPflegeeintrag: " + ex.ToString());
            }
        }
        public bool deleteDocument()
        {
            try
            {
                if (this.b.saveDocumentForKlient(PMDS.Global.ENV.CurrentIDPatient, this._SqlTable.Trim(), this._SqlColumnBlob.Trim(), this._SqlColumnFileType, this._IDKey.Trim(), null, "", true))
                {
                    this.mainWindow.DisablePDFViewer();
                    this.showInfoDocument();
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.deleteDocument: " + ex.ToString());
            }
        }
        public bool showDocument()
        {
            try
            {
                MemoryStream ms = new MemoryStream(this._bytDocument);
                if (this._docuDocumentFileTypeSaved.Trim().Equals(".pdf", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.mainWindow.ShowPDFViewer(this._bytDocument);
                    Application.DoEvents();
                }
                else
                {
                    string sGuid = Guid.NewGuid().ToString();
                    if (this._docuDocumentFileTypeSaved.Trim() == "")
                    {
                        throw new Exception("showDocument: this._docuDocumentFileTypeSaved='' not allowed!");
                    }
                    //string FileTmp = PMDS.Global.Settings.path_Temp.Trim() + "\\" + sGuid.Trim() + "" + this._docuDocumentFileTypeSaved.Trim();
                    string FileTmp = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp.Trim(), sGuid.Trim() + this._docuDocumentFileTypeSaved.Trim());
                    using (FileStream file = new FileStream(FileTmp.Trim(), FileMode.Create, System.IO.FileAccess.Write))
                    {
                        byte[] bytes = new byte[ms.Length];
                        ms.Read(bytes, 0, (int)ms.Length);
                        file.Write(bytes, 0, bytes.Length);
                        ms.Close();
                    }
                    PMDS.GUI.VB.clFolder clFolder1 = new PMDS.GUI.VB.clFolder();
                    clFolder1.openFile(FileTmp.Trim(), false);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucKlientStammdatenDokument.showDocument: " + ex.ToString());
            }
        }
        
        public string docuNameDocument
        {
            get
            {
                return this._NameDocument.Trim();
            }
            set
            {
                this.lblDocuName.Text = value.ToString().Trim();
                this._NameDocument = value.ToString().Trim();
            }
        }
        public string docuSqlColumnBlob
        {
            get
            {
                return this._SqlColumnBlob;
            }
            set
            {
                this._SqlColumnBlob = value;
            }
        }
        public string docuSqlColumnFileType
        {
            get
            {
                return this._SqlColumnFileType;
            }
            set
            {
                this._SqlColumnFileType = value;
            }
        }
        public string docuSSqlTable
        {
            get
            {
                return this._SqlTable;
            }
            set
            {
                this._SqlTable = value;
            }
        }
        public string docuIDKey
        {
            get
            {
                return this._IDKey;
            }
            set
            {
                this._IDKey = value;
            }
        }
        public string docuDocumentFileTypePrefered
        {
            get
            {
                return this._docuDocumentFileTypePrefered;
            }
            set
            {
                this._docuDocumentFileTypePrefered = value;
            }
        }
        



        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addDocument();
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
        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.deleteDocument();
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
        private void lblDocuStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._docuExists)
                {
                    this.showDocument();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void ucKlientStammdatenDokument_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.showInfoDocument();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }

}
