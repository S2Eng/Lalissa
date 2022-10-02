using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.IO;
using System.Diagnostics;
using PMDS.DB;




namespace PMDS.Global.UI.Befunde
{


    public partial class frmImportBefunde : Form
    {

        public DateTime dNow = DateTime.Now;
        public PMDS.db.Entities.ERModellPMDSEntities db = null;

        public enum eAction
        {
            AllNone = 0,
            ShowLaborJN = 1
        }

        public UIGlobal UIGlobal1 = new UIGlobal();

        public frmImportBefunde()
        {
            InitializeComponent();
        }
        private void frmImportBefunde_Load(object sender, EventArgs e)
        {
            this.ShowBefunde();

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, QS2.Resources.getRes.ePicTyp.ico);
                this.btnImport.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, QS2.Resources.getRes.ePicTyp.ico);

                this.contEdiFactViewer1.initControl("", null, false, "", null);

                this.CancelButton = this.btnClose;
                this.getKlienten();
                this.getAuswahlisteBefundImportLieferanten();


                this.ultraSpellChecker1.SpellOptions.LanguageParser = Infragistics.Win.UltraWinSpellChecker.LanguageType.German;
                //this.ultraSpellChecker1.SpellOptions.SuggestionMethod = Infragistics.Win.UltraWinSpellChecker.SuggestionsMethod.PhoneticSuggestions;
                //this.ultraSpellChecker1.Mode = Infragistics.Win.UltraWinSpellChecker.SpellCheckingMode.AsYouType;

            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.initControl: " + ex.ToString());
            }
        }
        public void ShowBefunde()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.contEdiFactViewer1.initControl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein Befund ausgewählt."), null, false,"", null);
                this.panelBefundDetail.Visible = false;

                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                this.dsEDIFACT1.Clear();
                this.lblCount.Text = "";
                this.dNow = DateTime.Now;
                string protocol = "";
                this.db = PMDS.DB.PMDSBusiness.getDBContext();

                int iCounterFilesImported = 0;
                int iCounterFilesImportedError = 0;

                EDIFact1.ReadBefunde(ENV.ImportBefundeVerzeichnis.Trim(), ENV.ImportBefundeArchivOrdner.Trim(),
                                                this.dsEDIFACT1, ref this.dNow, ref protocol,
                                                ref this.db, ref iCounterFilesImported, ref iCounterFilesImportedError);
                this.gridImportBefunde.Refresh();
                this.doAction(this.chkLaborJN.Checked, eAction.ShowLaborJN);
                this.doAction(true, eAction.AllNone);
//                this.lblCount.Text = "Zugeordnete Befunde: " + iCounterFilesImported.ToString();

                if (iCounterFilesImportedError > 0)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterFilesImportedError.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde/n nicht erfolgreich eingelesen."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Einlesen Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                }
                
                if (protocol.Trim() != "")
                {
                    QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                    QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                    frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                    frmEditor.ContTxtEditor1.LinealeOnOff(false);
                    frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                    frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                    frmEditor.Show();
                    frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll für Befunde einlesen"); 

                    byte[] b = null;
                    doEditor1.showText(protocol.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, frmEditor.ContTxtEditor1.textControl1,
                                        ref b, ref b);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.Import: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public bool SaveBefunde()
        {
            try
            {

                this.contEdiFactViewer1.textControl1.Text = "";
                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                int iCounter = 0;
                this.dNow = DateTime.Now;
                string protocol = "";

                int iCounterBefundeImported = 0;
                int iCounterBefundeImportedError = 0;

                EDIFact1.SaveBefundeToArchive(ref this.gridImportBefunde, iCounter, ref this.dNow, ref protocol,
                                                ref this.db, ref iCounterBefundeImported, ref iCounterBefundeImportedError);
                this.gridImportBefunde.Refresh();
                this.panelBefundDetail.Visible = false;

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Erfolgreich importiert: ") + iCounterBefundeImported.ToString() + "\r\n" +
                                                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht importiert (Ältere Version, Datei bereits im Archiv, nicht zuordenbar oder die Datei wurde vor dem Import gelöscht) : ") + iCounterBefundeImportedError.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);

                if (protocol.Trim() != "")
                {
                    QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                    QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                    frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                    frmEditor.ContTxtEditor1.LinealeOnOff(false);
                    frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                    frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                    frmEditor.Show();
                    frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll für Befunde speichern");  

                    byte[] b = null;
                    doEditor1.showText(protocol.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, frmEditor.ContTxtEditor1.textControl1,
                                        ref b, ref b);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.SaveBefunde: " + ex.ToString());
            }
        }

        public void doAction(bool bYes, eAction Action)
        {
            try
            {
                foreach (UltraGridRow gridRow in this.gridImportBefunde.Rows)
                {
                    DataRowView v = (DataRowView)gridRow.ListObject;
                    dsEDIFACT.EDIFACTRow rEdifact = (dsEDIFACT.EDIFACTRow)v.Row;
                    if (Action == eAction.AllNone)
                    {
                        gridRow.Cells["Select"].Value = bYes;
                    }
                    else if (Action == eAction.ShowLaborJN)
                    {
                        gridRow.Hidden = false;
                        if (!bYes && rEdifact.LaborJN)
                        {
                            gridRow.Hidden = true;
                        }
                    }
                    else
                    {
                        throw new Exception("EdiFactViewer.doAction: Action '" + Action .ToString()+ "' not allowed!");
                    }
                }

                this.gridImportBefunde.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.doAction: " + ex.ToString());
            }
        }

        public dsEDIFACT.EDIFACTRow getSelectedRow(bool msgBox)
        {
            try
            {
                if (this.gridImportBefunde.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.gridImportBefunde.ActiveRow.ListObject;
                    dsEDIFACT.EDIFACTRow rSelRow = (dsEDIFACT.EDIFACTRow)v.Row;
                    return rSelRow;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.getSelectedRow: " + ex.ToString());
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Befunde wirklich importieren?", "Befunde importieren", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                //{
                    this.ShowBefunde();
                //}
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
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

        private void viewerBefundeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EDIFact.frmEdiFactViewer frm = new EDIFact.frmEdiFactViewer();
                frm.initControl1("", null);
                frm.Show();
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

        private void importAuswahlisteVonExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                EDIFact1.ImportSelListBefundImportFromExcel();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SaveBefunde();

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

        private void gridImportBefunde_BeforeCellActivate_1(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().Equals((this.dsEDIFACT1.EDIFACT.SelectColumn.ColumnName).Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                    e.Cell.Column.ToString().Trim().Equals((this.dsEDIFACT1.EDIFACT.BeschreibungColumn.ColumnName).Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void gridImportBefunde_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridImportBefunde))
            //    {
            //        dsEDIFACT.EDIFACTRow rSelRow = this.getSelectedRow(false);
            //        if (rSelRow != null)
            //        {
            //            this.panelBefundDetail.Visible = true;
            //            EDIFact.EDIFact.cBefund Befund = (EDIFact.EDIFact.cBefund)rSelRow.obj;

            //            if (Befund.DateiType.Equals(Settings.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase) ||
            //                Befund.DateiType.Equals(Settings.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase)
            //                )
            //            {
            //                this.contEdiFactViewer1.initControl(Befund.txtEdiFactFilePrintable, null, false, Befund.DateiType, Befund);
            //            }
                        
            //            else if (Befund.DateiType.Equals(Settings.BefundTypText(eBefundTyp.PDF), StringComparison.CurrentCultureIgnoreCase))
            //                this.contEdiFactViewer1.initControl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem PDF-Viewer angezeigt."), null, false, Settings.BefundTypText(eBefundTyp.PDF), Befund);

            //            else if (Befund.DateiType.Equals(Settings.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase) ||
            //                Befund.IsDicomStudy)
            //                this.contEdiFactViewer1.initControl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem Dicom-Viewer angezeigt."), null, false, Settings.BefundTypText(eBefundTyp.DICOM), Befund);

            //            this.loadDetailBefund(rSelRow);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    PMDS.Global.Settings.HandleException(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        public void loadDetailBefund(dsEDIFACT.EDIFACTRow rSelRow)
        {
            try
            {
                EDIFact.EDIFact.cBefund Befund = (EDIFact.EDIFact.cBefund)rSelRow.obj;
                
                if (Befund.rAktAufenthalt != null)
                    this.cboKlienten.Value = Befund.rAktAufenthalt.ID;
                else
                    this.cboKlienten.Value = null;

                if (Befund.MailBoxNr != "")
                    this.cboMailBoxNr.Value = Befund.MailBoxNr;
                else
                    this.cboMailBoxNr.Value = "";

                if (Befund.DatumBefund > new DateTime(1, 1, 1))
                    this.dtpBefundDatum.Value = Befund.DatumBefund;
                else
                    this.dtpBefundDatum.Value = null;

                this.txtBefundID.Text = Befund.BefundID;

                this.txtBefundNummer.Text = Befund.BefundNummer;

                this.txtBeschreibung.Text = Befund.Hinweis;

                this.btnDetailOK.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("loadDetailBefund: " + ex.ToString());
            }
        }

        public void saveDetailBefund()
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                dsEDIFACT.EDIFACTRow rSelRow = this.getSelectedRow(true);
                if (rSelRow != null)
                {
                    string Gruppe = "";
                    string MailBoxNr = "";
                    string Befunddatum = "";
                    string SozVersNr = "";
                    string BefundID = "";
                    string BefundNummer = "";
                    
                    EDIFact.EDIFact.cBefund Befund = (EDIFact.EDIFact.cBefund)rSelRow.obj;
                    rSelRow.Beschreibung = this.txtBeschreibung.Text.Trim();
                    
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    if (this.cboKlienten.Value != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            Befund.rAktAufenthalt = b.getAufenthalt((System.Guid)this.cboKlienten.Value);
                            Befund.rPatient = b.getPatient((System.Guid)Befund.rAktAufenthalt.IDPatient, db);
                            Befund.IDPatient = (System.Guid)Befund.rAktAufenthalt.IDPatient;
                            SozVersNr = "_" + Befund.rPatient.VersicherungsNr.ToString();
                        }
                    }

                    if (this.cboMailBoxNr.Value != null)
                    {
                        Befund.MailBoxNr = (string)this.cboMailBoxNr.Value;
                        MailBoxNr = "_" + Befund.MailBoxNr;

                        PMDS.db.Entities.AuswahlListe rAuswahliste = EDIFact.EDIFact.CheckMailBoxNr(Befund.MailBoxNr.Trim(), ref Befund.Absender);
                        if (rAuswahliste != null)
                        {
                            Befund.NameAbsender = rAuswahliste.Beschreibung.Trim();
                            Gruppe = "_" + rAuswahliste.GehörtzuGruppe.Trim();
                        }
                    }

                    if (this.dtpBefundDatum.DateTime > this.dtpBefundDatum.MinDate)
                    {
                        Befund.DatumBefund = this.dtpBefundDatum.DateTime;
                        Befunddatum = "_" + Befund.DatumBefund.ToString("yyyy-MM-dd");
                    }
                    
                    if (this.txtBefundID.Value != null)
                    {
                        Befund.BefundID = (string)this.txtBefundID.Value;
                        BefundID = "_" + Befund.BefundID;
                    }

                    if (txtBefundNummer.Value != null)
                    {
                        Befund.BefundNummer = (string)this.txtBefundNummer.Value;
                        BefundNummer = "_" + Befund.BefundNummer;
                    }

                    if (Gruppe != "" && MailBoxNr != "" && Befunddatum != "" && SozVersNr != "" && BefundID != "" && BefundNummer != "")
                    {
                        rSelRow.NameBefund = ("Befund" + Gruppe + MailBoxNr + Befunddatum + SozVersNr + BefundID + BefundNummer).Replace(" ", ""); // NewBefund.BezeichnungFile;
                        Befund.BezeichnungFile = rSelRow.NameBefund;
                        if (Befund.rPatient != null)
                            rSelRow.Klient = Befund.rPatient.Nachname + " " + Befund.rPatient.Vorname;
                    }

                    if (txtBeschreibung.Value != null)
                        Befund.Hinweis = (string)this.txtBeschreibung.Value;

                    rSelRow.obj = Befund;

                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception("saveDetailBefund: " + ex.ToString());
            }
        }
        public void getKlienten()
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                this.cboKlienten.Items.Clear();
                Global.db.ERSystem.dsKlientenliste dsKlientenlisteAll = new db.ERSystem.dsKlientenliste();
                PMDS.Global.db.ERSystem.sqlManange sqlManangeWork = new Global.db.ERSystem.sqlManange();
                sqlManangeWork.getAllPatients(ref dsKlientenlisteAll, true);
                
                foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenlisteAll.vKlientenliste)
                {
                    PMDS.db.Entities.Aufenthalt rAufenthalt = PMDSBusiness1.getAufenthalt(rKlient.IDAufenthalt);

                    string strDatum = ", " + ((DateTime)rAufenthalt.Aufnahmezeitpunkt).ToString("dd.MM.yyyy");

                    if (rAufenthalt.Entlassungszeitpunkt != null)
                    {
                        strDatum += " - " + ((DateTime)rAufenthalt.Entlassungszeitpunkt).ToString("dd.MM.yyyy");
                    }

                    ValueListItem itm = this.cboKlienten.Items.Add(rKlient.IDAufenthalt, rKlient.PatientName.Trim() + strDatum);


                    itm.Tag = rKlient;

                }
                this.cboKlienten.SortStyle = ValueListSortStyle.Ascending;
                this.cboKlienten.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                this.cboKlienten.AutoSuggestFilterMode = AutoSuggestFilterMode.StartsWith;


            }
            catch (Exception ex)
            {
                throw new Exception("getKlienten: " + ex.ToString());
            }
        }
        public void getAuswahlisteBefundImportLieferanten()
        {
            try
            {
                this.cboMailBoxNr.Items.Clear();
                PMDS.BusinessLogic.AuswahlGruppe gr = new BusinessLogic.AuswahlGruppe("BIM");
                foreach(PMDS.Global.db.Global.dsAuswahlGruppe.AuswahlListeRow rAuswahlListe in gr.AuswahlListe)
                {
                    ValueListItem itm = this.cboMailBoxNr.Items.Add(rAuswahlListe.Bezeichnung, rAuswahlListe.Beschreibung.Trim());
                    itm.Tag = rAuswahlListe;
                }
                this.cboMailBoxNr.SortStyle = ValueListSortStyle.Ascending;
                this.cboMailBoxNr.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                this.cboMailBoxNr.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;

            }
            catch (Exception ex)
            {
                throw new Exception("getAuswahlisteBefundImportLieferanten: " + ex.ToString());
            }
        }
        private void gridImportBefunde_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridImportBefunde))
                {
                    dsEDIFACT.EDIFACTRow rSelRow = this.getSelectedRow(false);
                    if (rSelRow != null)
                    {
                        this.panelBefundDetail.Visible = true;
                        EDIFact.EDIFact.cBefund Befund = (EDIFact.EDIFact.cBefund)rSelRow.obj;

                        if (Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.BEFUND), StringComparison.CurrentCultureIgnoreCase) ||
                            Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.LABOR), StringComparison.CurrentCultureIgnoreCase)
                            )
                        {
                            this.contEdiFactViewer1.initControl(Befund.txtEdiFactFilePrintable, null, false, Befund.DateiType, Befund);
                        }

                        else if (Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.PDF), StringComparison.CurrentCultureIgnoreCase))
                            this.contEdiFactViewer1.initControl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem PDF-Viewer angezeigt."), null, false, ENV.BefundTypText(eBefundTyp.PDF), Befund);

                        else if (Befund.DateiType.Equals(ENV.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase) ||
                            Befund.IsDicomStudy)
                            this.contEdiFactViewer1.initControl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem Dicom-Viewer angezeigt."), null, false, ENV.BefundTypText(eBefundTyp.DICOM), Befund);

                        this.loadDetailBefund(rSelRow);
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
        private void chkLaborJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.chkLaborJN.Focused)
                {
                    this.doAction(this.chkLaborJN.Checked, eAction.ShowLaborJN);
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

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doAction(true, eAction.AllNone);
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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doAction(false, eAction.AllNone);
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

        private void befundverzeichnisÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (Directory.Exists(PMDS.Global.ENV.ImportBefundeVerzeichnis.Trim()))
                    Process.Start("explorer.exe", PMDS.Global.ENV.ImportBefundeVerzeichnis.Trim());
                else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Befundverzeichnis angegeben!", "Befundverzeichnis öffnen", MessageBoxButtons.OK);
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

        private void Field_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.btnDetailOK.Visible = true;
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

        private void btnDetailOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.saveDetailBefund();
                this.btnDetailOK.Visible = false;
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

        private void panelBefundDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (this.panelBefundDetail.Visible == false)
            {
                this.btnDetailOK.Visible = false;
            }
        }

    }
}
