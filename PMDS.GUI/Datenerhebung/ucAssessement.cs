using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;
using PMDS.Global.db.Global;
using System.IO;
using PMDS.DB;
using System.Linq;
using Syncfusion.XlsIO;
using Patagames.Pdf.Net;   
using Patagames.Pdf.Enums;
using Patagames.Pdf.Net.BasicTypes;
using Patagames.Pdf.Net.Controls.WinForms;
using System.Drawing.Printing;
using S2Extensions;




namespace PMDS.GUI
{

    public partial class ucAssessement : QS2.Desktop.ControlManagment.BaseControl
    {
                
        private dsFormular.FormularRow _row;

        private Guid _IDData = Guid.Empty;
        private dsFormularDaten.FormularDatenDataTable _data;
        private UltraExplorerBarGroup _group;
        private Guid _IDPatient = Guid.Empty;
        private Guid _IDFormular = Guid.Empty;

        public ucDatenErhebung MainWindowDatenerhebung = null;

        public static System.Collections.Generic.List<PMDS.GUI.Datenerhebung.frmAssessement> lstFormularDataundocked = new List<Datenerhebung.frmAssessement>();
        public bool LockPDFViewer = false;

        public System.Collections.Generic.List<PMDS.db.Entities.FormularDatenFelder> tFormularDatenFelderOrig = null;
        public static System.Collections.Generic.List<PMDS.db.Entities.AuswahlListe> tAuswahllisteFieldsDekurs = null;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        private QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
        private QS2.Desktop.Txteditor.contTXTField contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
        private QS2.Desktop.Txteditor.doBookmarks doBookmarks = new QS2.Desktop.Txteditor.doBookmarks();
        private eFormMode _FormMode = eFormMode.none;
        private bool bEditable;
        private uint iEditableHours = ENV.AssessmentModifyTime;

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

                this.btnPrint2.Visible = (value == eFormMode.pdf);
                this.btnAbdocken.Visible = false;
                //this.btnAbdocken.Visible = (value == eFormMode.pdf);
            }
        }

        private enum eFormMode
        {
            none = 0,
            pdf = 1,
            rtf = 2

        }

        public void valueChanged()
        {
            object o = new object();
            EventArgs ev = new EventArgs();
//            this.OnValueChanged(o, ev);
        }
//}

        private void BeschreibungKeyUp(object sender, KeyEventArgs e)
        {
            this.btnSave.Enabled = bEditable;
            this.btnAbbrechen.Enabled = bEditable;

            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F3)
                {
                    this.clickLoadTextbausteine();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        public ucAssessement()
        {
            InitializeComponent();

            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
            //this.pdfToolStripMain1.Items[0].Visible = false;
            //this.pdfToolStripMain1.Items[1].Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;

                if (IDFormular != Guid.Empty)
                    UpdateGUI();

                this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDFormular
        {
            get { return _IDFormular; }
            set
            {
                _IDFormular = value;

                if (IDPatient != Guid.Empty)
                    UpdateGUI();
            }
        }

        private void CreateNewEmptyFormular()
        {
            _IDData = Guid.Empty;
        }

        private void RefreshItems()
        {
            try
            {
                FormularDatenManager dm = new FormularDatenManager();
                _data = dm.Read(IDPatient, _row.Name);

                this.ucFormAsses1.ubMain.BeginUpdate();
                ClearItems();
                DataRow[] ra = _data.Select("", "DatumErstellt DESC");
                int anz = 0;
                foreach (dsFormularDaten.FormularDatenRow r in ra)
                {
                    string sDate = r.Datumerstellt.ToShortDateString();
                    string sTime = r.Datumerstellt.ToLongTimeString();
                    UltraExplorerBarItem item = _group.Items.Add(Guid.NewGuid().ToString(), sDate + " " + sTime);
                    item.Settings.Enabled = ENV.HasRight(UserRights.DatenerhebungAnzeigen) ? DefaultableBoolean.True : DefaultableBoolean.False;
                    item.Tag = r.ID;	
                    item.Settings.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                    anz += 1;
                }

                SetActiveItemBackground();
                //this.btnAbdocken.Visible = false;
                this.btnPrint2.Enabled = false;
                this.pdfToolStripViewModes1.Visible = false;
                this.pdfToolStripZoomEx1.Visible = false;
            }
            finally
            {
                this.ucFormAsses1.ubMain.EndUpdate();
            }
        }

        private void SetActiveItemBackground()
        {
            ResetItemBackGround();			
            if (_IDData != Guid.Empty)		
            {
                foreach (UltraExplorerBarItem i in _group.Items)
                {
                    if ((Guid)i.Tag == _IDData)
                        i.Settings.AppearancesSmall.Appearance.BackColor = Color.LightBlue;
                }
            }
        }

        private void UpdateGUI()
        {
            if (IDPatient != Guid.Empty && IDFormular != Guid.Empty)
            {
                this.tFormularDatenFelderOrig = new List<PMDS.db.Entities.FormularDatenFelder>();
                Patient p = new Patient(IDPatient);
                _group = this.ucFormAsses1.ubMain.Groups["VorhandeneFormulare"];

                FormularManager m = new FormularManager();
                dsFormular.FormularDataTable dt = m.Read(IDFormular);
                _row = dt[0];
                this.pdfViewer1.Visible = false;
                this.panelUnten.Visible = false;
                //this.btnAbdocken.Visible = false;
                this.pdfToolStripViewModes1.Visible = false;
                this.pdfToolStripZoomEx1.Visible = false;
                this.btnPrint2.Enabled = false;
                CreateNewEmptyFormular();
                FormularDatenManager dm = new FormularDatenManager();
                _data = dm.Read(IDPatient, _row.Name);
                RefreshItems();
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment ") + _row.Bezeichnung + QS2.Desktop.ControlManagment.ControlManagment.getRes(" des Patienten ") + p.FullInfo;
                this.lblTitle.Text = this._row.Bezeichnung.Trim();

                ProcessRights();            // Rechte
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(this._row.ID, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("UpdateGUI:tFormular.Count() == 0 for this._row.ID '" + this._row.ID.ToString() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();
                    if (rFormular.NeuanlageSperren)
                        this.btnNeu.Visible = false;
                }
                this.btnSave.Enabled = false;
                this.btnAbbrechen.Enabled = false;
                this.btnPrint2.Enabled = true;

                EnableDisableMenus();

                if (_group.Items.Count > 0)
                {
                    UltraExplorerBarItem item = _group.Items[0];
                    this.loadFormulardaten((Guid)item.Tag);
                }

                this.pdfViewer1.Focus();
                if (ucAssessement.tAuswahllisteFieldsDekurs == null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = this.b.GetAuswahlliste(db, "DAS", -100000, false);
                        ucAssessement.tAuswahllisteFieldsDekurs = new List<PMDS.db.Entities.AuswahlListe>();
                        ucAssessement.tAuswahllisteFieldsDekurs = tAuswahlliste.ToList();
                    }
                }
            }
        }

        private void loadFormulardaten(Guid IDFormularData)
        {
            try
            {
                this.LockPDFViewer = true;
                PdfForms formFDF = null;
                this.tFormularDatenFelderOrig = new List<PMDS.db.Entities.FormularDatenFelder>();

                Guid IDData = IDFormularData;
                if (_IDData != Guid.Empty)
                    ProcessSave(false);

                dsFormularDaten.FormularDatenRow r = _data.FindByID(IDData);

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(this._row.ID, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("ucFormAsses1_evClickEvent:tFormular.Count() == 0 for  r.FormularName '" + r.FormularName.Trim() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByID(r.ID, db);
                    PMDS.db.Entities.FormularDaten rFormularDaten = tFormularDaten.First();

                    if (this.checkFormExistsUndocked(rFormularDaten.ID))
                    {
                        this.abort();
                        return;
                    }

                    this.tFormularDatenFelderOrig = this.b.loadFormularDatenFelderForAssesstment(rFormularDaten.ID, db);

                    iEditableHours = (rFormular.EditHours < 0 ? iEditableHours = ENV.AssessmentModifyTime : (uint)rFormular.EditHours);
                    bEditable = ((r == null || r.Datumerstellt.AddHours(iEditableHours) > DateTime.Now && ENV.HasRight(UserRights.DatenerhebungAendern)) || ENV.adminSecure);

                    if (rFormular.Name.sEquals(".s2frm", S2Extensions.Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.pdf;
                        this.pdfViewer1.LoadDocument(rFormular.PDF_BLOP);
                        formFDF = pdfViewer1.Document.FormFill;
                        formFDF.InterForm.ImportFromFdf(FdfDocument.Load(rFormularDaten.PDF_BLOP));
                        this.pdfViewer1.Visible = true;
                        this.pdfToolStripViewModes1.Visible = true;
                        this.pdfToolStripZoomEx1.Visible = true;
                        this.pdfViewer1.Focus();
                        Application.DoEvents();
                    }
                    else if (rFormular.Name.sEquals(".s2frmRTF", S2Extensions.Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.rtf;
                        panelDoc.Controls.Clear();
                        this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
                        this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.FloatingText, false, true, false, true, true, true);
                        this.contTXTFieldBeschreibung.Dock = DockStyle.Fill;
                        this.panelDoc.Controls.Add(contTXTFieldBeschreibung);
                        Application.DoEvents();
                        this.contTXTFieldBeschreibung.TXTControlField.Load(rFormularDaten.PDF_BLOP, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                        this.contTXTFieldBeschreibung.delOnKeyUp += new QS2.Desktop.Txteditor.contTXTField.onKeyUp(this.BeschreibungKeyUp);
                    }
                }          

                _IDData = IDData;
                SetActiveItemBackground();

                this.panelUnten.Visible = true;
                EnableDisableMenus();
                this.btnAbbrechen.Enabled = false;
                this.btnPrint2.Enabled = true;
                this.LockPDFViewer = false;
            }
            catch (Exception ex)
            {
                this.LockPDFViewer = false;
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void ProcessSave(bool bRefreshItems)
        {
            try
            {
                if (!ISFORMULARTOSAVE)
                    return;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool IsNew = false;
                    PMDS.db.Entities.FormularDaten rFormularDaten = null;
                    System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByID(_IDData, db);
                    if (tFormularDaten.Count() == 0)
                    {
                        rFormularDaten = PMDS.Global.db.ERSystem.EFEntities.newFormularDaten(db);
                        db.FormularDaten.Add(rFormularDaten);
                        rFormularDaten.ID = Guid.NewGuid();
                        rFormularDaten.IDBenutzer_Erstellt = ENV.USERID;
                        rFormularDaten.Datumerstellt = DateTime.Now;
                        rFormularDaten.FormularName = this._row.Name;
                        rFormularDaten.IDREF = _IDPatient;
                        _IDData = rFormularDaten.ID;
                        IsNew = true;
                    }
                    else
                    {
                        rFormularDaten = tFormularDaten.First();
                    }

                    if (FormMode == eFormMode.pdf)
                    {
                        PdfForms form = pdfViewer1.Document.FormFill;
                        form.ForceToKillFocus();
                        FdfDocument fdfOut = form.InterForm.ExportToFdf("");
                        Byte[] bFDF = Encoding.Default.GetBytes(fdfOut.Content);
                        rFormularDaten.PDF_BLOP = bFDF;
                        this.pdfToolStripViewModes1.Visible = true;
                        this.pdfToolStripZoomEx1.Visible = true;
                    }
                    else if (FormMode == eFormMode.rtf)
                    {
                        this.contTXTFieldBeschreibung.TXTControlField.Save(out byte[] binaryData, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                        rFormularDaten.PDF_BLOP = binaryData;
                    }

                    db.SaveChanges();
                    if (FormMode == eFormMode.pdf)
                    {
                        this.saveFormualDataToDB(rFormularDaten);
                    }

                    RefreshItems();
                    btnSave.Enabled = false;
                    btnAbbrechen.Enabled = false;

                    EnableDisableMenus();
                    //this.btnAbdocken.Visible = (FormMode == eFormMode.pdf);
                    this.btnPrint2.Enabled = (FormMode == eFormMode.pdf);

                    this.b.writeDekursForAssesstment(rFormularDaten, db, this.tFormularDatenFelderOrig, ucAssessement.tAuswahllisteFieldsDekurs, IsNew);
                    this.tFormularDatenFelderOrig = this.b.loadFormularDatenFelderForAssesstment(rFormularDaten.ID, db);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucAssessement.ProcessSave: " + ex.ToString());
            }
        }

        public bool saveFormualDataToDB(PMDS.db.Entities.FormularDaten rFormularDaten)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();

                this.deleteFormularDataFromDB(rFormularDaten.ID);

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    using (PdfForms formFDF = new PdfForms())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(this._row.ID, db);
                        PMDS.db.Entities.Formular rFormular = tFormular.First();

                        FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(rFormularDaten.PDF_BLOP);
                        Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(rFormular.PDF_BLOP, formFDF);
                        formFDF.InterForm.ResetForm();
                        formFDF.InterForm.ImportFromFdf(docFDF);

                        foreach (var field in formFDF.InterForm.Fields)
                        {
                            PMDS.db.Entities.FormularDatenFelder rFormularDatenFelderNeu = new PMDS.db.Entities.FormularDatenFelder();
                            rFormularDatenFelderNeu.ID = Guid.NewGuid();
                            rFormularDatenFelderNeu.IDFormularDaten = rFormularDaten.ID;
                            rFormularDatenFelderNeu.Feldname = field.FullName;

                            if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                            {
                                rFormularDatenFelderNeu.Feldtyp = field.FieldType.ToString();
                                if (field.Value != null)
                                {
                                    rFormularDatenFelderNeu.Feldwert = field.Value.ToString();
                                }
                                else
                                    rFormularDatenFelderNeu.Feldwert = "<null>";
                            }
                            else if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_CHECKBOX)
                            {
                                rFormularDatenFelderNeu.Feldtyp = field.FieldType.ToString();
                                if (field.Controls.Count() == 1)
                                    rFormularDatenFelderNeu.Feldwert = field.Controls[0].IsChecked.ToString();
                                else
                                    rFormularDatenFelderNeu.Feldwert = field.Value.ToString();
                            }

                            db.FormularDatenFelder.Add(rFormularDatenFelderNeu);
                        }

                        db.SaveChanges();
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucAssessement.saveDataToDB: " + ex.ToString());
            }
        }

        public bool deleteFormularDataFromDB(Guid IDFormularData)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Data.Common.DbParameter[] pars = new System.Data.Common.DbParameter[] { };
                    string strSQl = "Delete from FormularDatenFelder where IDFormularDaten='" + IDFormularData.ToString() + "'";
                    db.Database.ExecuteSqlCommand(strSQl, pars);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucAssessement.deleteFormulardataFromDB: " + ex.ToString());
            }
        }

        private void NewFormular()
        {
            try
            {
                this.tFormularDatenFelderOrig = new List<PMDS.db.Entities.FormularDatenFelder>();
                this.LockPDFViewer = true;
                this.panelUnten.Visible = true;
                CreateNewEmptyFormular();
                this.btnSave.Enabled = true;
                this.bntLöschen.Enabled = false;
                this.pdfViewer1.Visible = true;
                EnableDisableMenus();

                //this.btnAbdocken.Visible = false;
                this.btnPrint2.Enabled = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByID(_row.ID, db);
                    if (tFormular.Count() != 1)
                    {
                        throw new Exception("NewFormular: tFormular.Count() == 0 for  r.FormularName '" + _row.ID.ToString() + "' not allowed!");
                    }
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    Patient pat = new Patient(_IDPatient);
                    string txt = "";
                    txt += rFormular.Name.ToUpper().Replace(".S2FRM", "");
                    txt += " / " + pat.Nachname + " " + pat.Vorname;
                    txt += " / " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                    DateTime GebDat = (DateTime)pat.Geburtsdatum;

                    if (rFormular.Name.sEquals(".s2frm", S2Extensions.Enums.eCompareMode.EndsWith))
                    {
                        this.pdfToolStripViewModes1.Visible = true;
                        this.pdfToolStripZoomEx1.Visible = true;

                        FormMode = eFormMode.pdf;
                        this.pdfViewer1.LoadDocument(rFormular.PDF_BLOP);
                        PdfForms form = pdfViewer1.Document.FormFill;

                        PMDS.Global.print.FDF fDF = new Global.print.FDF();
                        fDF.SetAllFDFFields(ENV.IDAUFENTHALT, form);
                        PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
                        frmPDF.SetValue("#KLIENT#", pat.Nachname + " " + pat.Vorname, form);
                        frmPDF.SetValue("#KLIENTGEBDAT#", GebDat.ToString("dd.MM.yyyy"), form);
                        frmPDF.SetValue("#BENUTZERERSTELLT#", ENV.LoginInNameFrei, form);
                        frmPDF.SetValue("#DATUMERSTELLT#", DateTime.Now.ToString("dd.MM.yyyy HH:mm"), form);
                        frmPDF.SetValue("#DATUMERSTELLTDATE#", DateTime.Now.ToString("dd.MM.yyyy"), form);
                        frmPDF.SetValue("#DOCINFO#", txt, form);
                        this.LockPDFViewer = false;
                        Application.DoEvents();
                    }
                    else if (rFormular.Name.sEquals(".s2frmRTF", S2Extensions.Enums.eCompareMode.EndsWith))
                    {
                        FormMode = eFormMode.rtf;
                        panelDoc.Controls.Clear();
                        this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
                        this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.FloatingText, false, true, true, true, true, true);
                        this.contTXTFieldBeschreibung.Dock = DockStyle.Fill;
                        this.panelDoc.Controls.Add(contTXTFieldBeschreibung);
                        Application.DoEvents();
                        this.contTXTFieldBeschreibung.TXTControlField.Load(rFormular.PDF_BLOP, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                        this.contTXTFieldBeschreibung.delOnKeyUp += new QS2.Desktop.Txteditor.contTXTField.onKeyUp(this.BeschreibungKeyUp);

                        //Felder ersetzen "[Feldname] laut Liste
                        TXTextControl.TextControl editor = this.contTXTFieldBeschreibung.TXTControlField;
                        SetAllRTFFields(ENV.IDAUFENTHALT, editor);
                    }
                }
            }
            catch (Exception ex)
            {
                this.LockPDFViewer = false;
                throw new Exception("ucAssessement.NewFormular: " + ex.ToString());
            }
        }

        private void DelFormular()
        {
            try
            {
                if (_IDData == Guid.Empty)
                    return;

                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEFORMULAR"), ENV.String("DIALOGTITLE_DELETEFORMULAR"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
                if (res != DialogResult.Yes)
                    return;

                DataRow r = _data.FindByID(_IDData);
                r.Delete();
                this.deleteFormularDataFromDB(this._IDData);

                Write();
                _IDData = Guid.Empty;

                this.tFormularDatenFelderOrig = new List<PMDS.db.Entities.FormularDatenFelder>();
                this.panelUnten.Visible = false;
                this.pdfViewer1.Visible = false;
                //this.btnAbdocken.Visible = false;
                this.btnPrint2.Enabled = false;
                this.pdfToolStripViewModes1.Visible = false;
                this.pdfToolStripZoomEx1.Visible = false;
                RefreshItems();
                FormMode = eFormMode.none;
            }
            catch (Exception ex)
            {
                throw new Exception("DelFormular: " + ex.ToString());
            }
        }

        private void SetHeader(string fldNew, string txt, PdfFieldCollections fields, string typ)
        {
            try
            {
                foreach (var field in fields)
                {
                    if (field.FullName.Equals(fldNew, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (typ.Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                            field.Value = txt;
                        else if (typ.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                            field.Value = txt;
                        else if (typ.Equals("Date", StringComparison.CurrentCultureIgnoreCase))
                            field.Value = txt;
                        else if (typ.Equals("DocInfo", StringComparison.CurrentCultureIgnoreCase))
                        {
                            field.Value = txt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetHeader: " + ex.ToString());
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



        private void EnableDisableMenus()
        {
            bool bPDF = this.pdfViewer1.Visible ? true : false;
            bool bRTF = this.contTXTFieldBeschreibung.Visible ? true : false;

            this.bntLöschen.Enabled = (bPDF || bRTF) && !btnSave.Enabled;
        }

        private void ProcessRights()
        {
            this.btnNeu.Visible = ENV.HasRight(UserRights.DatenerhebungAendern);
            this.bntLöschen.Visible = ENV.HasRight(UserRights.DatenerhebungLoeschen);
            this.btnSave.Visible = ENV.HasRight(UserRights.DatenerhebungAendern);
        }

        private void ClearItems()
        {
            _group.Items.Clear();
        }

        private void ResetItemBackGround()
        {
            foreach (UltraExplorerBarItem i in _group.Items)
                i.Settings.AppearancesSmall.Appearance.ResetBackColor();
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


        private DialogResult AskForSave()
        {
            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                    ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                    MessageBoxButtons.YesNoCancel,
                                                                                    MessageBoxIcon.Question, true);
            return res;
        }

        private void ProcessEnd()
        {
            DialogResult res = DialogResult.Yes;
            if (ISFORMULARTOSAVE)
            {
                if ((res = AskForSave()) == DialogResult.Yes)
                    ProcessSave(false);
                if (res == DialogResult.No)
                    btnSave.Enabled = false;
            }
        }

        private void Write()
        {
            FormularDatenManager dm = new FormularDatenManager();
            dm.Write(_data);
        }

        public bool ISFORMULARTOSAVE
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public void ProcessUndo()
        {
            btnSave.Enabled = false;
        }

        private void frmAssessment_Load(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmAssessment_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.ucFormAsses1.ubMain.Focus();
                DialogResult res = DialogResult.Yes;
                if (ISFORMULARTOSAVE)
                {
                    if ((res = AskForSave()) == DialogResult.Yes)
                        ProcessSave(false);
                }
                if (res == DialogResult.Cancel)
                    e.Cancel = true;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void ucFormular1_VisibleChanged(object sender, System.EventArgs e)
        {
            try
            {
                EnableDisableMenus();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void ucAssessement_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public bool checkFormExistsUndocked(Guid IDFormularData)
        {
            try
            {
                foreach (PMDS.GUI.Datenerhebung.frmAssessement frmAssessmentExists in ucAssessement.lstFormularDataundocked)
                {
                    if (frmAssessmentExists._IDFormulardata.Equals(IDFormularData))
                    {
                        frmAssessmentExists.WindowState = FormWindowState.Normal;
                        frmAssessmentExists.TopMost = true;
                        frmAssessmentExists.Show();
                        frmAssessmentExists.TopMost = false;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("checkFormExistsUndocked: " + ex.ToString());
            }
        }
        private void ucFormAsses1_evClickEvent2(object sender, ItemEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                Guid IDData = (Guid)e.Item.Tag;
                this.loadFormulardaten(IDData);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ProcessSave(true);
            }
            catch (Exception ex1)
            {
                ENV.HandleException(ex1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnNeu_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.NewFormular();
                this.bEditable = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bntLöschen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DelFormular();
                EnableDisableMenus();
                //this.bntLöschen.Enabled = false;
            }
            catch (Exception ex1)
            {
                ENV.HandleException(ex1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            panelObenRechts.Visible = !bOn;
            panelUntenRechts.Visible = !bOn;
        }
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.abort();
                if (!this._IDData.Equals(Guid.Empty))
                {
                    this.loadFormulardaten(this._IDData);
                }
                FormMode = eFormMode.none;
            }
            catch (Exception ex1)
            {
                ENV.HandleException(ex1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void abort()
        {
            try
            {
                //this.NewFormular();           
                this.pdfViewer1.Visible = false;
                EnableDisableMenus();
                this.panelUnten.Visible = false;
                this.RefreshItems();
                this.btnSave.Enabled = false;
                this.bntLöschen.Enabled = false;
                //this.btnAbdocken.Visible = false;
                this.btnPrint2.Enabled = false;
                this.pdfToolStripViewModes1.Visible = false;
                this.pdfToolStripZoomEx1.Visible = false;

            }
            catch (Exception ex1)
            {
                throw new Exception("abort: " + ex1.ToString());
            }
        }
        private void ucAssessement_Resize(object sender, EventArgs e)
        {
            try
            {
                panelButtonOben.Left = this.Width - panelButtonOben.Width;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.MainWindowDatenerhebung.loadMainSite();
                if (this.MainWindowDatenerhebung.IsExternControl)
                {
                    if (this.MainWindowDatenerhebung.mainWindowNotfall != null)
                    {
                        this.MainWindowDatenerhebung.mainWindowNotfall.SetUIDatenerhebung(false);
                    }
                    if (this.MainWindowDatenerhebung.mainWindowDatenerhebnungExtern != null)
                    {
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

        private void formularAlsDatasetSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.GUI.Datenerhebung.cAssessement cAssessement1 = new Datenerhebung.cAssessement();
                PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular = new PMDS.Global.db.ERSystem.UISitemaps.cParFormular();
                string ProtocolListAttribute = "";
                bool bOK = cAssessement1.genDatasetFromFormular(this._IDData, true, ref cParFormular, ref ProtocolListAttribute);
                string protSum = ProtocolListAttribute.Trim();
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

        private void ucAssessement_VisibleChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnSave_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.btnSave.Visible)
                {
                    //this.btnSave.ContextMenuStrip = this.contextMenuStripSave;
                    //this.btnAbbrechen.ContextMenuStrip = this.contextMenuStripSave;
                    //this.panelOben2.ContextMenuStrip = this.contextMenuStripSave;
                    this.panelUntenRechts.ContextMenuStrip = this.contextMenuStripSave;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void pdfViewer1_BeforeDocumentChanged(object sender, Patagames.Pdf.Net.EventArguments.DocumentClosingEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnAbdocken_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.checkFormExistsUndocked(this._IDData))
                {
                    this.abort();
                    return;
                }

                PMDS.GUI.Datenerhebung.frmAssessement frm = new Datenerhebung.frmAssessement();
                frm.mainWindow = this;
                frm.initControl();
                frm.loadData(this._row.ID, this._IDData, false, this.IDPatient);
                ucAssessement.lstFormularDataundocked.Add(frm);
                frm.Show();
                this.abort();

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

        private void pdfViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.LockPDFViewer)
            {
                dsFormularDaten.FormularDatenRow r = _data.FindByID(_IDData);
                this.btnSave.Enabled = bEditable;
                this.btnAbbrechen.Enabled = bEditable;
                this.btnPrint2.Enabled = false;
                //this.btnAbdocken.Visible = false;
            }            
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var printDoc = new PdfPrintDocument(pdfViewer1.Document);
                using (PrintDialog dlg = new PrintDialog())
                {
                    dlg.AllowCurrentPage = true;
                    dlg.AllowSomePages = true;
                    dlg.UseEXDialog = true;
                    dlg.Document = printDoc;
                    if (dlg.ShowDialog() == DialogResult.OK)
                        printDoc.Print();
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

        public void clickLoadTextbausteine()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmTextbausteinAuswahl frmTextbausteinAuswahl1 = new GUI.Main.frmTextbausteinAuswahl();
                frmTextbausteinAuswahl1.initControl();
                frmTextbausteinAuswahl1.ShowDialog(this);
                if (!frmTextbausteinAuswahl1.abort)
                {
                    this.contTXTFieldBeschreibung.TXTControlField.Selection.Text = frmTextbausteinAuswahl1.TextbausteinAsPlainText;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadTextbausteine: " + ex.ToString());
            }
        }

        public void SetAllRTFFields(Guid? IDAufenthalt, TXTextControl.TextControl editor)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    Guid IDPatient = Guid.Empty;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                    PMDS.db.Entities.Patient p = new PMDS.db.Entities.Patient();
                    PMDS.db.Entities.Aufenthalt a = new PMDS.db.Entities.Aufenthalt();
                    PMDS.db.Entities.Adresse adr = new PMDS.db.Entities.Adresse();
                    PMDS.db.Entities.Klinik kli = new PMDS.db.Entities.Klinik();
                    PMDS.db.Entities.Abteilung abt = new PMDS.db.Entities.Abteilung();
                    PMDS.db.Entities.Bereich ber = new PMDS.db.Entities.Bereich();

                    if (IDAufenthalt == null)
                    {
                        IDPatient = ENV.CurrentIDPatient;
                    }
                    else
                    {
                        a = PMDSBusiness1.getAufenthalt((Guid)IDAufenthalt, db);
                        IDPatient = (Guid)a.IDPatient;
                    }

                    p = PMDSBusiness1.getPatient(IDPatient, db);
                    Patient pat = new Patient(IDPatient);
                    a = PMDSBusiness1.getAufenthalt(pat.Aufenthalt.ID, db);

                    if (pat.Vorname != null) doBookmarks.setBookmark("[KLIENTVORNAME]", pat.Vorname, ref editor);
                    if (p.Nachname != null) doBookmarks.setBookmark("[KLIENTNACHNAME]", p.Nachname, ref editor);
                    if ((p.Vorname != null) && (p.Nachname != null)) doBookmarks.setBookmark("[KLIENT]", p.Nachname + " " + p.Vorname, ref editor);
                    if (p.Anrede != null) doBookmarks.setBookmark("[KLIENTANREDE]", p.Anrede, ref editor);

                    if (p.Geburtsdatum != null) doBookmarks.setBookmark("[KLIENTGEBDAT]", System.Convert.ToDateTime(p.Geburtsdatum).ToShortDateString(), ref editor);
                    if (p.SterbeDatum != null) doBookmarks.setBookmark("[KLIENTSTERBEDATUM]", System.Convert.ToDateTime(p.SterbeDatum).ToShortDateString(), ref editor);
                    doBookmarks.setBookmark("[KLIENTVERSTORBEN]", (p.Verstorben == true) ? "Ja" : "Nein", ref editor);
                    if (p.Klientennummer != null) doBookmarks.setBookmark("[KLIENTNUMMER]", p.Klientennummer, ref editor);
                    if (p.Titel != null) doBookmarks.setBookmark("[KLIENTTITEL]", p.Titel, ref editor);
                    if (p.TitelPost != null) doBookmarks.setBookmark("[KLIENTTITELPOST]", p.TitelPost, ref editor);
                    if (p.Kosename != null) doBookmarks.setBookmark("[KLIENTKOSENAME]", p.Kosename, ref editor);

                    if (p.Sexus != null) doBookmarks.setBookmark("[KLIENTGESCHLECHT]", p.Sexus, ref editor);
                    if (p.Familienstand != null) doBookmarks.setBookmark("[KLIENTFAMILIENSTAND]", p.Familienstand, ref editor);
                    if (p.Staatsb != null) doBookmarks.setBookmark("[KLIENTSTAATSBUERGERSCHAFT]", p.Staatsb, ref editor);
                    if (p.Klasse != null) doBookmarks.setBookmark("[KLIENTVERSICHERUNGKLASSE]", p.Klasse, ref editor);
                    if (p.KrankenKasse != null) doBookmarks.setBookmark("[KLIENTKRANKENKASSE]", p.KrankenKasse, ref editor);
                    if (p.BlutGruppe != null) doBookmarks.setBookmark("[KLIENTBLUTGRUPPE]", p.BlutGruppe, ref editor);
                    if (p.Resusfaktor != null) doBookmarks.setBookmark("[KLIENTRHESUSFAKTOR]", p.Resusfaktor, ref editor);
                    if (p.LedigerName != null) doBookmarks.setBookmark("[KLIENTLEDIGERNAME]", p.LedigerName, ref editor);
                    if (p.Geburtsort != null) doBookmarks.setBookmark("[KLIENTGEBORT]", p.Geburtsort, ref editor);
                    if (p.VersicherungsNr != null) doBookmarks.setBookmark("[KLIENTSVNR]", p.VersicherungsNr, ref editor);
                    if (p.Privatversicherung != null) doBookmarks.setBookmark("[KLIENTPRIVATVERSICHERUNG]", p.Privatversicherung, ref editor);
                    if (p.PrivPolNr != null) doBookmarks.setBookmark("[KLIENTPRIVATVERSICHERUNGPOLNR]", p.PrivPolNr, ref editor);

                    if (p.ErlernterBeruf != null) doBookmarks.setBookmark("[KLIENTERLERNTERBERUF]", p.ErlernterBeruf, ref editor);
                    if (p.Besonderheit != null) doBookmarks.setBookmark("[KLIENTBESONDERHEIT]", p.Besonderheit, ref editor);
                    if (p.SterbeRegel != null) doBookmarks.setBookmark("[KLIENTSTERBEREGELUNG]", p.SterbeRegel, ref editor);
                    doBookmarks.setBookmark("[KLIENTPFLEGEGELDANTRAG]", (p.PflegegeldantragJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.DatumPflegegeldantrag != null) doBookmarks.setBookmark("[KLIENTPFLEGEGELDANTRAGDATUM]", System.Convert.ToDateTime(p.DatumPflegegeldantrag).ToShortDateString(), ref editor);
                    doBookmarks.setBookmark("[KLIENTPENSIONSTEILUNGSANTRAG]", (p.PensionsteilungsantragJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.DatumPensionsteilungsantrag != null) doBookmarks.setBookmark("[KLIENTPFLEGEGELDANTRAGDATUM]", System.Convert.ToDateTime(p.DatumPensionsteilungsantrag).ToShortDateString(), ref editor);
                    if (p.Konfision != null) doBookmarks.setBookmark("[KLIENTKONFESSION]", p.Konfision, ref editor);
                    doBookmarks.setBookmark("[KLIENTANATOMIE]", (p.Anatomie == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTDNR]", (p.DNR == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTPALLIATIV]", (p.Palliativ == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTHOLOCAUST]", (p.KZUeberlebender == true) ? "Ja" : "Nein", ref editor);
                    if (p.PatientenverfuegungJN != null) doBookmarks.setBookmark("[KLIENTPATIENTENVERFÜGUNG]", (p.PatientenverfuegungJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.PatientenverfuegungBeachtlichJN != null) doBookmarks.setBookmark("[KLIENTPATIENTENVERFÜGUNGBEACHTLICH]", (p.PatientenverfuegungBeachtlichJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.PatientverfuegungDatum != null) doBookmarks.setBookmark("[KLIENTPATIENTENVERFÜGUNGDATUM]", System.Convert.ToDateTime(p.PatientverfuegungDatum).ToShortDateString(), ref editor);
                    if (p.PatientverfuegungAnmerkung != null) doBookmarks.setBookmark("[KLIENTPATIENTENVERFÜGUNGANMERKUNG]", p.PatientverfuegungAnmerkung, ref editor);

                    doBookmarks.setBookmark("[KLIENTMILIEUBETREUUNG]", (p.Milieubetreuung == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTDATENSCHUTZ]", (p.Datenschutz == true) ? "Ja" : "Nein", ref editor);
                    if (p.lstSprachen != null) doBookmarks.setBookmark("[KLIENTSPRACHEN]", p.lstSprachen, ref editor);

                    if (p.Haarfarbe != null) doBookmarks.setBookmark("[KLIENTHAARFARBE]", p.Haarfarbe, ref editor);
                    if (p.Augenfarbe != null) doBookmarks.setBookmark("[KLIENTAUGENFARBE]", p.Augenfarbe, ref editor);
                    if (p.Groesse != null) doBookmarks.setBookmark("[KLIENTGROESSE]", p.Groesse.ToString(), ref editor);
                    if (p.Statur != null) doBookmarks.setBookmark("[KLIENTSTATUR]", p.Statur.ToString(), ref editor);

                    doBookmarks.setBookmark("[KLIENTAMPUTATIONPROZENT]", p.Amputation_Prozent.ToString(), ref editor);
                    if (p.Kennwort != null) doBookmarks.setBookmark("[KLIENTKENNWORT]", p.Kennwort, ref editor);

                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNG]", (p.RezeptgebuehrbefreiungJN == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGREGO]", (p.RezGebBef_RegoJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.RezGebBef_RegoAb != null) doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGREGOAB]", System.Convert.ToDateTime(p.RezGebBef_RegoAb).ToShortDateString(), ref editor);
                    if (p.RezGebBef_RegoBis != null) doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGREGOBIS]", System.Convert.ToDateTime(p.RezGebBef_RegoBis).ToShortDateString(), ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTET]", (p.RezGebBef_BefristetJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.RezGebBef_BefristetAb != null) doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETAB]", System.Convert.ToDateTime(p.RezGebBef_BefristetAb).ToShortDateString(), ref editor);
                    if (p.RezGebBef_BefristetBis != null) doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETBIS]", System.Convert.ToDateTime(p.RezGebBef_BefristetBis).ToShortDateString(), ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGUNBEFRISTET]", (p.RezGebBef_UnbefristetJN == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUF]", (p.RezGebBef_WiderrufJN == true) ? "Ja" : "Nein", ref editor);
                    if (p.RezGebBef_WiderrufGrund != null) doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUFGRUND]", p.RezGebBef_WiderrufGrund, ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGSACHWALTER]", (p.RezGebBef_SachwalterJN == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTREZEPTGEBUEHRENBEFREIUNGANMERKUNG]", p.RezGebBef_Anmerkung, ref editor);

                    if (p.Betreuungsstufe != null) doBookmarks.setBookmark("[KLIENTBETREUUNGSSTUFE]", p.Betreuungsstufe, ref editor);
                    if (p.BetreuungsstufeAb != null) doBookmarks.setBookmark("[KLIENTBETREUUNGSSTUFEAB]", System.Convert.ToDateTime(p.BetreuungsstufeAb).ToShortDateString(), ref editor);
                    if (p.BetreuungsstufeBis != null) doBookmarks.setBookmark("[KLIENTBETREUUNGSSTUFEBIS]", System.Convert.ToDateTime(p.BetreuungsstufeBis).ToShortDateString(), ref editor);
                    doBookmarks.setBookmark("[KLIENTSOZIALCARD]", (p.Sozialcard == true) ? "Ja" : "Nein", ref editor);
                    doBookmarks.setBookmark("[KLIENTBEHINDERTENAUSWEIS]", (p.Behindertenausweis == true) ? "Ja" : "Nein", ref editor);

                    doBookmarks.setBookmark("[KLIENTWOHNUNGABGEMELDET]", (pat.WohnungAbgemeldetJN == true) ? "Ja" : "Nein", ref editor);

                    kli = PMDSBusiness1.getKlinik(pat.Aufenthalt.IDKlinik != null ? pat.Aufenthalt.IDKlinik : Guid.Empty, db);
                    if (!pat.WohnungAbgemeldetJN)
                    {
                        adr = PMDSBusiness1.getAdresse2(pat.Adresse.ID != null ? pat.IDAdresse : Guid.Empty, db);
                    }
                    else
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                    }
                    if (adr.Strasse != null) doBookmarks.setBookmark("[KLIENTADRESSESTRASSE]", adr.Strasse, ref editor);
                    if (adr.Plz != null) doBookmarks.setBookmark("[KLIENTADRESSEPLZ]", adr.Plz, ref editor);
                    if (adr.Ort != null) doBookmarks.setBookmark("[KLIENTADRESSEORT]", adr.Ort, ref editor);
                    if (adr.LandKZ != null) doBookmarks.setBookmark("[KLIENTADRESSELAND]", adr.LandKZ, ref editor);

                    if (pat.Aufenthalt.ID != null)
                    {
                        if (a.Aufnahmezeitpunkt != null) doBookmarks.setBookmark("[AUFENTHALTAUFNAHMEDATUM]", Convert.ToDateTime(a.Aufnahmezeitpunkt).ToShortDateString(), ref editor);
                        if (a.Fallnummer != null) doBookmarks.setBookmark("[AUFENTHALTFALLNUMMER]", a.Fallnummer.ToString(), ref editor);
                        if (a.Gruppenkennzahl != null) doBookmarks.setBookmark("[AUFENTHALTGRUPPENKENNZAHL]", a.Gruppenkennzahl, ref editor);
                        if (a.Postregelung != null) doBookmarks.setBookmark("[AUFENTHALTPOSTREGELUNG]", a.Postregelung, ref editor);
                    }

                    if (pat.Aufenthalt.IDKlinik != null)
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                        if (adr.Strasse != null) doBookmarks.setBookmark("[EINRICHTUNGADRESSESTRASSE]", adr.Strasse, ref editor);
                        if (adr.Plz != null) doBookmarks.setBookmark("[EINRICHTUNGADRESSEPLZ]", adr.Plz, ref editor);
                        if (adr.Ort != null) doBookmarks.setBookmark("[EINRICHTUNGADRESSEORT]", adr.Ort, ref editor);
                        if (adr.LandKZ != null) doBookmarks.setBookmark("[EINRICHTUNGADRESSELAND]", adr.LandKZ, ref editor);

                        if (kli.Bezeichnung != null) doBookmarks.setBookmark("[AUFENTHALTEINRICHTUNG]", kli.Bezeichnung, ref editor);
                        if (kli.Bezeichnung != null) doBookmarks.setBookmark("[EINRICHTUNGNAME]", kli.Bezeichnung, ref editor);
                    }

                    if (pat.Aufenthalt.IDAbteilung != null)
                    {
                        abt = PMDSBusiness1.getAbteilung(pat.Aufenthalt.IDAbteilung, db);
                        if (abt.Bezeichnung != null) doBookmarks.setBookmark("[AUFENTHALTABTEILUNG]", abt.Bezeichnung, ref editor);
                    }

                    if (pat.Aufenthalt.IDBereich != null)
                    {
                        ber = PMDSBusiness1.getBereich(pat.Aufenthalt.IDBereich, db);
                        if (ber.Bezeichnung != null) doBookmarks.setBookmark("[AUFENTHALTBEREICH]", ber.Bezeichnung, ref editor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in FDF.SetAllFDFFields:" + ex.ToString());
            }
        }
    }
}
