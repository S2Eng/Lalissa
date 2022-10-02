using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.ERSystem;
using PMDS.DB;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.GUI.BaseControls;
using System.Linq;

using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;
using PMDS.Global.Remote;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Patagames.Pdf.Net;

using PMDS.GUI.ELGA;
using static PMDS.Global.db.ERSystem.ELGABusiness;
using Syncfusion.Pdf.Parsing;
using S2Extensions;

namespace PMDS.GUI
{

    public delegate void GuiActionDoneDelegate(SiteEvents ev);



	public class GuiAction
	{
        public static event GuiActionDoneDelegate GuiActionDone;      // Signalisiert dass eine Gewisse Aktion durchgef�hrt worden ist;

		public static Guid     LastAufnahmePatientID;
        public static Guid     LastVersetzungAbteilungID;
        public static Guid     LastVersetzungBereichID;
        public static string   LastVersetzungBereichText = "";
        public static frmPatientRueckmeldungLine frmRueckmedlungLine;
        private static bool bfrmRueckmedlungLineisinitialized = false;

        public static int _iPageCount;
        public static bool Schnellr�ckmeldungOpend = false;

        private class KlientInfoExport
        {
            public Guid ID;
            public string Vorname;
            public string Nachname;
            public Guid? IDKlinik;
            public string Adelstitel;
            public DateTime? Geburtsdatum;
        }

        private class AufenthaltInfoExport
        {
            public Guid ID;
            public DateTime? Aufnahmezeitpunkt;
            public DateTime? Entlassungszeitpunkt;
        }
        public GuiAction()
		{
		}

		public static bool PatientAufnahme()
		{
			frmPatientAufnahme auf = new frmPatientAufnahme();
            bool bOK = (auf.ShowDialog() == DialogResult.OK);

            if (bOK)
                ENV.SignalNeuerPatient(LastAufnahmePatientID);              // Sicherstellen dass alle vorprozesse mitbekommen dass ein neuer Klient da ist (zB f�r den Header Patientpicker)

            //if (bOK && GuiActionDone != null)
            //    GuiActionDone(SiteEvents.Aufnahme);

			return (bOK);
		}        	

        public static void archivTerminMail(bool gesamt, bool headerEin, bool ShowKlientenarchiv, bool ShowTermineBereich)
        {
            GuiWorkflow.ShowArchivPlanung(gesamt, headerEin, ShowKlientenarchiv, ShowTermineBereich);
        }

        public static bool Berichte()
        {
            frmDynReports frm = new frmDynReports(ENV.DynReportExtrasPath);
            
            frm.Show ();
            return true;
        }


        public static bool BerichteWunde()
        {
            frmDynReports frm = new frmDynReports(ENV.DynReportWundePath);
            frm.Show();
            return true;
        }

        public static bool MedizinischeDialoge()
        {
            frmMedizinischeDatenLayout frm = new frmMedizinischeDatenLayout();
            frm.Show();
            return true;
        }

        public static bool Standardprozeduren()
        {
            frmStandardProzeduren frm = new frmStandardProzeduren();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
                ENV.SignalNotfallChanged(frm, EventArgs.Empty);
            return true;
        }

        public static bool Bewerberverwaltung()
        {
            frmBewerber frm = new frmBewerber();
            frm.ShowDialog();
            GuiWorkflow.setHistorieOnOff();
            return true;
        }

		public static bool PatientVersetzung(Guid idPatient, dsKlinik.KlinikRow rKlinik)
		{
			Patient pat = new Patient(idPatient);

			frmVersetzung ver = new frmVersetzung(pat);
            ver.ucVersetzung1.rKlinik = rKlinik;
            ver.ucVersetzung1.UpdateGUI();
            DialogResult res = ver.ShowDialog();
            if (res == DialogResult.OK)
            {
                ENV.ABTEILUNG = ver.IDAbteilung;
                LastVersetzungAbteilungID = ver.IDAbteilung;
                if (GuiActionDone != null)
                    GuiActionDone(SiteEvents.Versetzen);
                return true;
            }
            return false;
		}

		public static bool PatientEntlassung2(Guid idPatient, ucMain mainWindow)
		{
            try
            {
                bool bOK = false;
                Patient pat = new Patient(idPatient);

			    // Hinweis bei Entlassung, wenn Patient abwesend ist
			    if (pat.Aufenthalt.HasUrlaub)
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.PATIENT_URLAUB"),ENV.String("GUI.DIALOGTITLE_PATIENT_URLAUB"), 
                                                                                    MessageBoxButtons.OK,MessageBoxIcon.Stop, true);

                if (GuiActionDone != null)
                {
                    try
                    {
                        Nullable<Guid> IDEinrichtungEmpf�nger = null;
                        Nullable<Guid> IDDokumenteneintrag = null;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            using (ucDynReportParameter ucDynReportParameter1 = new ucDynReportParameter())
                            {
                                ucDynReportParameter1.XMLFileAlternate = ENV.ReportConfigPath + @"\Pflegebegleitschreiben.config";
                                ucDynReportParameter1.REPORT_FILE = ENV.ReportPath + @"\Pflegebegleitschreiben.rpt";
                                ucDynReportParameter1._CurrentFormToShow = "PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo";
                                bool abortWindow = false;
                                bool bSaveToArchiv = ENV.SavePflegebegleitschreibenToArchiv;
                                ucDynReportParameter1.ProcessPreview(true, ENV.ReportPath + @"\Pflegebegleitschreiben.rpt", db, ref abortWindow, ref IDEinrichtungEmpf�nger, ref bSaveToArchiv, true, ref IDDokumenteneintrag);
                                if (abortWindow)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex3)
                    {
                        string sExcept = "GuidAction.PatientEntlassung2: Error genCDA() for IDPatient='" + idPatient.ToString() + "'" + "\r\n" + "\r\n" + ex3.ToString();
                        ENV.HandleException(new Exception(sExcept));
                    }
                }

                using (frmEntlassung ent = new frmEntlassung(pat))
                {
                    ent.mainWindow = mainWindow;
                    bOK = (ent.ShowDialog() == DialogResult.OK);
                }

                if (bOK)
                    GuiActionDone(SiteEvents.Entlassen);

                return (bOK);
            }
            catch (Exception ex)
            {
                throw new Exception("GuiAction.PatientEntlassung2: " + ex.ToString());
            }
        }

		public static bool PatientAufenthaltInfo(Guid idPatient)
		{
            PMDS.GUI.frmPatientHistorie auf = new PMDS.GUI.frmPatientHistorie(idPatient, false);
			return (auf.ShowDialog() == DialogResult.OK);
		}                              

        private static void DatenexportLog(PMDS.GUI.ucRichTextBox RTFLog, string Txt)
        {
            RTFLog.Text += "\n" + DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss ") + Txt;
            Application.DoEvents();
        }

        public static bool Datenarchivierung(System.Guid IDPatient, System.Guid IDKlinik, 
                            out bool DocuSuccessfullyGenerated, out string FileNamePDFDocumentBack, 
                            ENV.eKlientenberichtTyp KlientenberichtTyp, ENV.eDatenexportTyp DatenexportTyp,
                            ref PMDS.GUI.ucRichTextBox RTFLog,
                            bool chkPDFExport, bool chkXMLExport, bool chkPDFA,
                            ref QS2.Desktop.ControlManagment.BaseLabel lblKlient)   
        {
            //Aktuellen Standarddrucker merken
            //string Standarddrucker =  PMDS.Print.CR.PrinterSettings.GetDefaultPrinterName();            

            DocuSuccessfullyGenerated = false;
            FileNamePDFDocumentBack = "";
            List<KlientInfoExport> lKlientenInfoExport = new List<KlientInfoExport>();

            try
            {
                string tmpFullPath = "";
                string filenamePDFA = "";
                DocuSuccessfullyGenerated = false;
                FileNamePDFDocumentBack = "";
                int cntPDFExport = 0;
                int cntXMLExport = 0;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (IDPatient != Guid.Empty)
                    {
                        //ein spezieller
                        lKlientenInfoExport = (from a in db.vAufenthaltsliste
                                               join p in db.Patient on a.IDPatient equals p.ID
                                              where a.IDPatient == IDPatient
                                              select new KlientInfoExport { ID = (Guid)a.IDPatient, Vorname = a.Vorname, Nachname = a.Nachname, IDKlinik = a.IDKlinik, Adelstitel = p.Adelstitel, Geburtsdatum = p.Geburtsdatum })
                                            .ToList();
                    }
                    else
                    {
                        //alle mit aktivem Aufenthalt
                        if (DatenexportTyp == ENV.eDatenexportTyp.aktiv)
                        {
                            lKlientenInfoExport = (from a in db.Aufenthalt
                                                                         join p in db.Patient on a.IDPatient equals p.ID
                                                                         where a.Entlassungszeitpunkt == null && a.IDKlinik == IDKlinik
                                                                         select new KlientInfoExport { ID = (Guid)a.IDPatient, Vorname = p.Vorname, Nachname = p.Nachname, IDKlinik = a.IDKlinik, Adelstitel = p.Adelstitel, Geburtsdatum = p.Geburtsdatum })
                                                .Distinct()
                                                .OrderBy(p => p.Nachname).ThenBy(p => p.Vorname)
                                                .ToList();
                        }
                        //alle mit mindestens einem beendeten Aufenthalt
                        else if (DatenexportTyp == ENV.eDatenexportTyp.entlassen)
                        {
                            lKlientenInfoExport = (from a in db.Aufenthalt
                                                                         join p in db.Patient on a.IDPatient equals p.ID
                                                                         where a.Entlassungszeitpunkt != null && a.IDKlinik == IDKlinik
                                                                         select new KlientInfoExport { ID = (Guid)a.IDPatient, Vorname = p.Vorname, Nachname = p.Nachname, IDKlinik = a.IDKlinik, Adelstitel = p.Adelstitel, Geburtsdatum = p.Geburtsdatum })
                                                .Distinct()
                                                .OrderBy(p => p.Nachname).ThenBy(p => p.Vorname)
                                                .ToList();
                        }
                        else if (DatenexportTyp == ENV.eDatenexportTyp.alle)
                            //Alle
                            lKlientenInfoExport = (from a in db.Aufenthalt
                                                                         join p in db.Patient on a.IDPatient equals p.ID
                                                                         where a.IDKlinik == IDKlinik
                                                                         select new KlientInfoExport { ID = (Guid)a.IDPatient, Vorname = p.Vorname, Nachname = p.Nachname, IDKlinik = a.IDKlinik, Adelstitel = p.Adelstitel, Geburtsdatum = p.Geburtsdatum })
                                                .Distinct()
                                                .OrderBy(p => p.Nachname).ThenBy(p => p.Vorname)
                                                .ToList();
                    }
                }

                string KlientNameGebDat = "";
                foreach (KlientInfoExport r in lKlientenInfoExport)
                {
                    //Patient pat = new Patient(r.ID);

                    lblKlient.Text = r.Nachname.Trim() + " " + r.Vorname.Trim();
                    Application.DoEvents();

                    KlientNameGebDat = r.Nachname.Trim() + "_" + r.Vorname.Trim() + "_" + string.Format("{0:yyyyMMdd}", r.Geburtsdatum);

                    if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention)
                        KlientNameGebDat += DateTime.Now.ToString("_BPyyyyMMddHHmmss");
                    else if (KlientenberichtTyp == ENV.eKlientenberichtTyp.full)
                        KlientNameGebDat += DateTime.Now.ToString("_yyyyMMddHHmmss");


                    KlientNameGebDat =  Regex.Replace(KlientNameGebDat, @"[^0-9a-zA-Z.�������]\\", string.Empty);

                    tmpFullPath = PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, "Dummy.txt", "0");
                    if (String.IsNullOrWhiteSpace(tmpFullPath)) 
                        return false;

                    if (chkPDFExport)
                    {
                        DatenexportLog(RTFLog, "Starten PDF-Klientenbericht f�r " + r.Nachname.Trim() + "_" + r.Vorname.Trim());
                        string sFileFullNameExported = "";
                        PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, "Klientenbericht.rpt"), r.ID, Guid.Empty, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp, 0, out sFileFullNameExported);
                        FileInfo fiReport = new System.IO.FileInfo(sFileFullNameExported);
                        if (fiReport.Exists)
                        {
                            fiReport.MoveTo(Path.Combine(fiReport.DirectoryName, "0.Klientenbericht" + fiReport.Extension));
                        }

                        FileInfo[] pdfList;
                        DirectoryInfo di;

                        //Zus�tzliche Berichte einmal pro Klient
                        di = new DirectoryInfo(Path.GetDirectoryName(System.IO.Path.Combine(ENV.ReportPath, "*.*")));
                        pdfList = di.GetFiles("Klientenbericht.Sub.0*", SearchOption.TopDirectoryOnly);
                        foreach (FileInfo fiSub in pdfList)
                        {
                            PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, fiSub.Name), r.ID, Guid.Empty, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp, 0, out sFileFullNameExported);
                            FileInfo fiSubReport = new System.IO.FileInfo(sFileFullNameExported);
                            if (fiSubReport.Exists)
                            {
                                fiSubReport.MoveTo(Path.Combine(fiSubReport.DirectoryName, "0." + Path.GetFileNameWithoutExtension(fiSub.Name) + fiSubReport.Extension));
                            }
                        }

                        //------------------------- Anamnesen (einmal pro Patient) ---------------------  
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            //Alle OREM-Anamnesen lesen und drucken
                            var lOREM = (from orem in db.Anamnese_Orem
                                         where orem.IDPatient == r.ID
                                         orderby orem.ErstelltAm descending
                                         select new { ID = orem.ID, ErstelltAm = orem.ErstelltAm }).ToList();

                            if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention && lOREM.Count > 1)
                            {
                                lOREM.RemoveRange(1, lOREM.Count - 1);
                            }

                            foreach (var IDOREM in lOREM)
                            {
                                DatenexportLog(RTFLog, "OREM-Anamnese " + IDOREM.ErstelltAm.ToString("F"));
                                PMDS.Print.ReportManager.PrintAnamnese("OREM", System.IO.Path.Combine(ENV.ReportPath, "OREM1.rpt"), r.ID, ENV.ArchivPath, false, true, (Guid)IDOREM.ID, KlientNameGebDat, KlientenberichtTyp, out sFileFullNameExported);
                                FileInfo fiOREM = new System.IO.FileInfo(sFileFullNameExported);
                                if (fiOREM.Exists)
                                {
                                    fiOREM.MoveTo(Path.Combine(fiOREM.DirectoryName, "0.OREM." + IDOREM.ErstelltAm.ToString("yyyy-MM-dd HH.mm.ss.fff") + fiOREM.Extension));
                                }
                            }

                            //Alle Krohwinkel-Anamnesen lesen und drucken
                            var lKROHWINKEL = (from krohwinkel in db.Anamnese_Krohwinkel
                                               where krohwinkel.IDPatient == r.ID
                                               orderby krohwinkel.ErstelltAm descending
                                               select new { ID = krohwinkel.ID, ErstelltAm = krohwinkel.ErstelltAm }).ToList();

                            if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention && lKROHWINKEL.Count > 1)
                            {
                                lKROHWINKEL.RemoveRange(1, lKROHWINKEL.Count - 1);
                            }

                            foreach (var IDKROHWINKEL in lKROHWINKEL)
                            {
                                DateTime d = (DateTime)IDKROHWINKEL.ErstelltAm;
                                
                                DatenexportLog(RTFLog, "Krohwinkel-Anamnese " + d.ToString("F"));
                                PMDS.Print.ReportManager.PrintAnamnese("KROHWINKEL", System.IO.Path.Combine(ENV.ReportPath, "Krohwinkel.rpt"), r.ID, ENV.ArchivPath, false, true, (Guid)IDKROHWINKEL.ID, KlientNameGebDat, KlientenberichtTyp, out sFileFullNameExported);
                                FileInfo fiKROHWINKEL = new System.IO.FileInfo(sFileFullNameExported); 
                                if (fiKROHWINKEL.Exists)
                                {
                                    fiKROHWINKEL.MoveTo(Path.Combine(fiKROHWINKEL.DirectoryName, "0.KROHWINKEL." + d.ToString("yyyy-MM-dd HH.mm.ss.fff") + fiKROHWINKEL.Extension)); 
                                }
                            }

                            //Alle POP-Anamnesen lesen und drucken
                            var lPOP = (from pop in db.Anamnese_POP
                                        where pop.IDPatient == r.ID
                                        orderby pop.ErstelltAm descending
                                        select new { ID = pop.ID, ErstelltAm = pop.ErstelltAm }).ToList();

                            if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention && lPOP.Count > 1)
                            {
                                lPOP.RemoveRange(1, lPOP.Count - 1);
                            }

                            foreach (var IDPOP in lPOP)
                            {
                                DatenexportLog(RTFLog, "POP-Anamnese " + IDPOP.ErstelltAm.ToString("F"));
                                PMDS.Print.ReportManager.PrintAnamnese("POP", System.IO.Path.Combine(ENV.ReportPath, "POP.rpt"), r.ID, ENV.ArchivPath, false, true, (Guid)IDPOP.ID, KlientNameGebDat, KlientenberichtTyp, out sFileFullNameExported);
                                FileInfo fiPOP = new System.IO.FileInfo(sFileFullNameExported);
                                if (fiPOP.Exists)
                                {
                                    fiPOP.MoveTo(Path.Combine(fiPOP.DirectoryName, "0.POP." + IDPOP.ErstelltAm.ToString("yyyy-MM-dd HH.mm.ss.fff") + fiPOP.Extension));
                                }

                            }
                        }

                        if (KlientenberichtTyp == ENV.eKlientenberichtTyp.full)
                        {
                            //Biografie(n)
                            PMDS.GUI.VB.sqlBiografien dbBiografien = new PMDS.GUI.VB.sqlBiografien();
                            dbBiografien.DataTable.Rows.Clear();
                            dbBiografien.loadAlleVorhadenenBiografien(IDPatient);
                            QS2.Desktop.Txteditor.doEditor doEdit = new QS2.Desktop.Txteditor.doEditor();
                            foreach (DataRow rBio in dbBiografien.DataTable.Rows)
                            {
                                DateTime d = (DateTime)rBio["Datumerstellt"];
                                DatenexportLog(RTFLog, "Biografie " + d.ToString("F"));                                
                                tmpFullPath = PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, rBio["FormularName"].ToString(), "0", d.ToString("yyyy-MM-dd HH.mm.ss.fff"));

                                //txtEditor.Text = "";
                                //byte[] by = null;
                                //byte[] bPdf = null;
                                //doEdit.showText(rBio["BLOP"].ToString(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.PageView, txtEditor, ref by, ref bPdf);
                                //doEdit.saveDocument(tmpFullPath, TXTextControl.StreamType.AdobePDF, txtEditor);

                                using (Syncfusion.Pdf.PdfDocument doc = new Syncfusion.Pdf.PdfDocument())
                                {
                                    Syncfusion.Pdf.PdfPage page = doc.Pages.Add();
                                    System.Drawing.SizeF bounds = page.GetClientSize();
                                    string text = rBio["BLOP"].ToString();
                                    PdfMetafile imageMetafile = (PdfMetafile)PdfImage.FromRtf(text, bounds.Width, PdfImageType.Metafile);
                                    PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat
                                    {
                                        SplitTextLines = true
                                    };
                                    imageMetafile.Draw(page, 0, 0, format);
                                    doc.Save(tmpFullPath);
                                    doc.Close(true);
                                }
                            }

                            //Assessments (einmal pro Patient) //Abl�se des Formularmanagers durch PDF, os 171009
                            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                            PdfCommon.Initialize(ENV.PdfiumKey);

                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                            {
                                System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = b.getFormularDatenByIDPatient(r.ID, db);
                                foreach (PMDS.db.Entities.FormularDaten rFormularDaten in tFormularDaten)
                                {
                                    if (rFormularDaten.PDF_BLOP != null)
                                    {
                                        System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = b.getFormularByName(Path.GetFileNameWithoutExtension(rFormularDaten.FormularName), db);
                                        foreach (PMDS.db.Entities.Formular rFormular in tFormular)
                                        {
                                            if (rFormular.PDF_BLOP != null)
                                            {                                                
                                                //Mit Patagames - bleibt im Speicher h�ngen
                                                //using (PdfForms formFDF = new PdfForms())
                                                //{
                                                //    DateTime d = (DateTime)rFormularDaten.Datumerstellt;
                                                //    DatenexportLog(RTFLog, "Assessment " + rFormular.Name + " " + d.ToString("F"));
                                                //    FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(rFormularDaten.PDF_BLOP);
                                                //    Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(rFormular.PDF_BLOP, formFDF);
                                                //    formFDF.InterForm.ResetForm();
                                                //    formFDF.InterForm.ImportFromFdf(docFDF);
                                                //    docPDF.Save(PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, Settings.ArchivPath, rFormular.Name, "0", d.ToString("yyyy-MM-dd HH.mm.ss.fff")), Patagames.Pdf.Enums.SaveFlags.RemoveSecurity);
                                                //}
                                                //Mit Syncfusion - l�st sich auf
                                                {
                                                    DateTime d = (DateTime)rFormularDaten.Datumerstellt;
                                                    DatenexportLog(RTFLog, "0." + rFormular.Name + "." + d.ToString("F") + ".pdf");
                                                    using (PdfLoadedDocument doc = new PdfLoadedDocument(rFormular.PDF_BLOP))
                                                    {
                                                        PdfLoadedForm form = doc.Form;
                                                        using (MemoryStream stream = new MemoryStream(rFormularDaten.PDF_BLOP))
                                                        {
                                                            form.ImportDataFDF(stream, true);
                                                            doc.Save(PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, rFormular.Name, "0", d.ToString("yyyy-MM-dd HH.mm.ss.fff")));
                                                            doc.Close();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Aufenthaltsabh�ngige Berichte
                        int cntAufenthalt = 0;

                        List<AufenthaltInfoExport> lAufenthaltsInfoExport = new List<AufenthaltInfoExport>();

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            lAufenthaltsInfoExport = (from a in db.Aufenthalt
                                                      where a.IDPatient == r.ID
                                                      select new AufenthaltInfoExport { ID = a.ID, Aufnahmezeitpunkt = a.Aufnahmezeitpunkt, Entlassungszeitpunkt = a.Entlassungszeitpunkt })
                                                      .OrderBy(a => a.Aufnahmezeitpunkt)
                                                      .ToList();
                        }
                          
                        foreach (AufenthaltInfoExport auf in lAufenthaltsInfoExport)
                        {
                            cntAufenthalt++;
                            DateTime AufnZeitpunkt = (DateTime)auf.Aufnahmezeitpunkt;
                            DatenexportLog(RTFLog, "Aufenthalt " + cntAufenthalt.ToString() + " mit Beginn: " + AufnZeitpunkt.ToString("F"));

                            if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention && auf.Entlassungszeitpunkt == null || KlientenberichtTyp == ENV.eKlientenberichtTyp.full)
                            {
                                // Im Reportsdirectory alle Klientenbericht.0*.rpt suchen und nacheinander drucken
                                di = new DirectoryInfo(Path.GetDirectoryName(System.IO.Path.Combine(ENV.ReportPath, "*.*")));
                                pdfList = di.GetFiles("Klientenbericht.0*", SearchOption.TopDirectoryOnly);

                                foreach (FileInfo fi in pdfList)
                                {
                                    if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention &&
                                        (!fi.ToString().Contains("0011")) && !fi.ToString().Contains("0020") && !fi.ToString().Contains("0061") && !fi.ToString().Contains("0071") && !fi.ToString().Contains("0090"))
                                    //Liste Assessments, Aufenthaltsverlauf, Pflegebericht, Evaluierungen und WundDoku in BlackoutPr�vention nicht ausgeben.
                                    {
                                        DatenexportLog(RTFLog, "Detailbericht " + fi.Name);
                                        PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, fi.Name), r.ID, auf.ID, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp, cntAufenthalt, out sFileFullNameExported);
                                    }
                                    else if (KlientenberichtTyp == ENV.eKlientenberichtTyp.full)
                                    {
                                        DatenexportLog(RTFLog, "Detailbericht " + fi.Name);
                                        PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, fi.Name), r.ID, auf.ID, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp, cntAufenthalt, out sFileFullNameExported);
                                        FileInfo fiDetailReport = new System.IO.FileInfo(sFileFullNameExported);
                                        if (fiDetailReport.Exists)
                                        {
                                            string[] fName = sFileFullNameExported.Split('.');
                                            fiDetailReport.MoveTo(Path.Combine(fiDetailReport.DirectoryName, fName[0] + "." + fName[1] + "." + fName[2] + "." + fName[3] + "." + fName[5]));
                                        }
                                    }
                                }
                                DatenexportLog(RTFLog, "Warten auf Fertigstellen der Detail-Berichte f�r Aufenthalt " + cntAufenthalt.ToString() + " ....");
                            }
                        }

                        cntPDFExport++;
                        if (chkPDFA)
                        {
                            DatenexportLog(RTFLog, "PDF/A-Dokument erstellen ");

                            // Erstellen eines pdf/A-Files pro Klient
                            int iCountAufenthalte = 0;
                            List<string> lstSourceFiles = new List<string>();  //Array mit PDFs, die zusammenzufassen sind

                            // Alle pdfs des Verzeichnisses 
                            string KlientVerzeichnis = System.IO.Path.Combine(ENV.ArchivPath, KlientNameGebDat);
                            DirectoryInfo di1 = new DirectoryInfo(KlientVerzeichnis);

                            FileInfo[] pdfList1 = di1.GetFiles("Klientenbericht.rpt*.pdf");
                            foreach (FileInfo fi in pdfList1)
                            {
                                string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                                lstSourceFiles.Add(tmpFileName);

                                iCountAufenthalte++;
                            }

                            FileInfo[] pdfList1Sub = di1.GetFiles("Klientenbericht.Sub.0*.pdf");
                            foreach (FileInfo fi in pdfList1Sub)
                            {
                                string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                                lstSourceFiles.Add(tmpFileName);
                            }

                            //pro Aufenthalt in aufsteigender Reihenfolge
                            for (int i = 1; i <= cntAufenthalt; i++)
                            {
                                FileInfo[] pdfList1a = di1.GetFiles(i.ToString() + ".Klientenbericht.0*.pdf");
                                foreach (FileInfo fi in pdfList1a)
                                {
                                    string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                                    lstSourceFiles.Add(tmpFileName);
                                }
                            }

                            //Assessments hinzuf�gen (alle PDFs, die noch nicht hinzugef�gt sind)
                            FileInfo[] pdfList2 = di1.GetFiles("*.pdf");
                            foreach (FileInfo fi in pdfList2)
                            {
                                string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                                if (!lstSourceFiles.Any(s => s.Contains(tmpFileName)))
                                {
                                    lstSourceFiles.Add(tmpFileName);
                                }
                            }

                            filenamePDFA = System.IO.Path.Combine(ENV.ArchivPath, KlientNameGebDat + ".PDF");
                            using (Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument(PdfConformanceLevel.Pdf_A1B))
                            {
                                finalDoc.Compression = PdfCompressionLevel.Best;
                                Syncfusion.Pdf.PdfDocument.Merge(finalDoc, lstSourceFiles.ToArray());
                                finalDoc.Save(filenamePDFA);
                            }
                        }
                    }

                    //Datenexport im XML-Format
                    if (KlientenberichtTyp == ENV.eKlientenberichtTyp.full && chkXMLExport)
                    {
                        DatenexportLog(RTFLog, "XML-Datenexport ");
                        using (DatenExportXML export = new DatenExportXML())
                        {
                            bool result1 = export.Export(r.ID, ENV.ArchivPath, out string FileNameXMLDocumentBack, ref RTFLog);
                            if (result1)
                                cntXMLExport++;
                        }
                    }
                    DatenexportLog(RTFLog, "------------------------------------------------------------------\n");

                    //Log exportieren und Oberfl�che leeren
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(ENV.ArchivPath, KlientNameGebDat, "LOG.TXT")))
                    {
                            outputFile.Write(RTFLog.Text);
                    }
                    RTFLog.Text = "";
                    lblKlient.Text = "";
                    Application.DoEvents();

                }

                string sMsgBoxTranslate = "";

                if (cntPDFExport == 0)
                    sMsgBoxTranslate += "\nEs wurde kein Datenarchiv erstellt.";
                else if (cntPDFExport == 1)
                    sMsgBoxTranslate += "\nDatenarchiv wurde erstellt.";
                else if (cntPDFExport > 1)
                    sMsgBoxTranslate += "\nDatenarchiv f�r " + cntPDFExport.ToString() + " Klienten wurde erstellt.";

                if (cntXMLExport == 0)
                    sMsgBoxTranslate += "\nEs wurde kein Datenexport erstellt.";
                else if (cntXMLExport == 1)
                    sMsgBoxTranslate += "\nXML-Datenexport wurde erstellt.";
                else if (cntPDFExport > 1)
                    sMsgBoxTranslate += "\nDatenexport f�r " + cntXMLExport.ToString() + " Klienten wurde erstellt.";

                //sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, filenamePDFA.Trim());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Information");
                FileNamePDFDocumentBack = filenamePDFA.Trim();
                DocuSuccessfullyGenerated = true;

                return true;
            }
            catch (Exception e)
            {               
                throw new Exception("GuiAction.Datenarchivierung: " + e.ToString());
            }

            finally
            {
                //PatListe1?.Dispose();
            }
        }

		public static bool PatientRemark(Guid idPatient)
		{
			Patient pat = new Patient(idPatient);
            using (frmPatientBem bem = new frmPatientBem(pat, _typBemerkung.bemerkung))
            {
                System.Windows.Forms.DialogResult ret = bem.ShowDialog();
                return ret == DialogResult.OK;
            }
		}

        public static bool PatientVermerk(Guid idPatient, Nullable<Guid> IDExtern, eDekursherkunft Dekursherkunft, string DekursText, bool GegenzeichnenJN,
                                            bool IsEntwurf, Nullable<Guid> IDPEEntwurf, bool ShowAsDialog, string InfoExcept, bool ErstellenAs,
                                            string DekursTextRtfTemplate, System.Collections.Generic.List<PMDS.Global.ENV.cDekursinfo> lstPatients = null)
		{
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                Patient pat = new Patient(idPatient);

                Nullable<Guid> IDFuerUserErstellt = null;
                PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurf = null;
                if (IDPEEntwurf != null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        rPflegeEintragEntwurf = b.getPflegeEintragEntwurf(IDPEEntwurf.Value, db);
                        IDFuerUserErstellt = rPflegeEintragEntwurf.FuerUserErstellt;
                    }
                }
               
                if (IDPEEntwurf == null && ErstellenAs)
                {
                    frmUsers frmUsers1 = new frmUsers();
                    frmUsers1.initControl();
                    frmUsers1.ShowDialog();
                    if (!frmUsers1.abort)
                    {
                        IDFuerUserErstellt = (Guid)frmUsers1.cbBenutzer.Value;
                    }
                    else
                    {
                        return false;
                    }
                }

                frmPatientVermerk bem = new frmPatientVermerk(pat, DekursText, GegenzeichnenJN, IDFuerUserErstellt);
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (lstPatients != null && lstPatients.Count > 0)
                    {
                        foreach (PMDS.Global.ENV.cDekursinfo InfoDekurs in lstPatients)
                        {
                            PMDS.DB.PMDSBusiness.cMedTypDatenCopy newcMedTypDatenCopy = new DB.PMDSBusiness.cMedTypDatenCopy();
                            newcMedTypDatenCopy.SelectedNodes.IDKlient = InfoDekurs.ID;
                            PMDS.db.Entities.Aufenthalt rActAufenthalt = b.getAktuellerAufenthaltPatient(InfoDekurs.ID, false, db);
                            newcMedTypDatenCopy.SelectedNodes.IDAufenthalt = rActAufenthalt.ID;
                            newcMedTypDatenCopy.SelectedNodes.Txt = InfoDekurs.Txt;

                            bem.lstPatienteSelected2.Add(newcMedTypDatenCopy.SelectedNodes);
                        }

                        bem.btnKlientenMehrfachauswahl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl") + " (" + lstPatients.Count.ToString() + ")";
                        if (lstPatients.Count > 0)
                        {
                            bem.btnKlientenMehrfachauswahl.Appearance.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            bem.btnKlientenMehrfachauswahl.Appearance.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }

                bem.ucPflegeEintrag1.IsDekursEntwurf = IsEntwurf;
                bem.ucPflegeEintrag1.IDFuerUserErstellt = IDFuerUserErstellt;
                bem.ucPflegeEintrag1.IDPflegeeintragEntwurf = IDPEEntwurf;
                bem.ucPflegeEintrag1.DekursTextRtfTemplate = DekursTextRtfTemplate;
                bem.btnSaveDekursAsEntwurf.Visible = IsEntwurf;
                bem.ucPflegeEintrag1.initControl(true, false, false, Dekursherkunft);
                bem.ucPflegeEintrag1.IDExtern = IDExtern;
                if (ShowAsDialog)
                {
                    bem.ShowDialog();
                }
                else
                {
                    bem.Show();
                }

                return !bem.abort;

            }
            catch (Exception ex)
            {
                throw new Exception("GuiAction.PatientVermerk - InfoExcept:" + InfoExcept + "\r\n" + "\r\n" + ex.ToString());
            }
		}

        public static bool PatientNeuAufnahme()
        {
            return PatientAufnahmeWizard(Guid.Empty, true, false, false);           
        }

        private static bool PatientAufnahmeWizard(Guid idPatient, bool bNeuAufnahme, bool bWiederaufnahme, bool bChangeDataonly)
        {
            Patient pat = (bNeuAufnahme ? new Patient() : new Patient(idPatient));

            if (bNeuAufnahme || bWiederaufnahme)
                pat.NewAufenthalt(ENV.ABTEILUNG, ENV.USERID);

            using (frmWizard wizard = new frmWizard()) 
            {
                if (bNeuAufnahme)
                {
                    wizard.Text = ENV.String("GUI.NEW_PATIENT_AUFNAHME");
                }
                else
                {
                    wizard.Text = pat.FullInfo;
                    wizard.Description = "Aufnahme von " + pat.FullInfo;
                }

                ucPatientNew p0 = new ucPatientNew();
                wizard.ucPatientNew1 = p0;

                p0.Patient = pat;
                p0.MODIFYMODE = !bNeuAufnahme;

                if (!bNeuAufnahme)
                    p0.ReadOnly = true;

                string s = bNeuAufnahme ? ENV.String("GUI.NEW_PATIENT") : wizard.Description;
                wizard.AddPage(s, p0);

                wizard.Width = 590;
                wizard.Height = 730;

                if (ELGABusiness.checkELGASessionActive(false))     //&& ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPatientenSuchen, false)
                {
                    wizard.ucPatientNew1.chkKontaktbest�tigung.Visible = true;
                }
                else
                {
                    wizard.ucPatientNew1.chkKontaktbest�tigung.Visible = false;
                }

                wizard.TopMost = true;
                if (wizard.ShowDialog() != DialogResult.OK)
                    return false;

                if (!bNeuAufnahme)
                {
                    Guid g = Aufenthalt.LastByPatient(pat.ID);

                    if (g != Guid.Empty)
                    {
                        Aufenthalt a = new Aufenthalt(g);
                        if (a.Entlassungszeitpunkt == null)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist bereits aufgenommen", "Klient bereits aufgenommen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }
                }

                pat.Write();
                p0.UpdateDataER();  //Daten aus dem Control in die DB per EF �bertragen (f�r die die Datasets nicht erweitert wurden)
                LastAufnahmePatientID = pat.ID;

                PMDSBusinessUI bUI = new PMDSBusinessUI();
                bUI.SaveVersicherungsdaten(pat.ID, p0.ucVersichrungsdaten1);
                bUI.SaveVersicherungsdaten2(pat.ID, p0.ucVersichrungsdaten1);

                if (wizard.activePage.GetType() == typeof(ucPatientNew))
                {
                    if (((ucPatientNew)wizard.activePage).chkKontaktbest�tigung.Checked)
                    {
                        ELGABusiness bELGA = new ELGABusiness();
                        BenutzerDTOS1 ben = bELGA.getELGASettingsForUser(ENV.USERID);
                        if (ENV.lic_ELGA && ben.Elgaactive && !ben.IsGeneric)
                        {
                            using (frmELGAKlient frmELGAKlient1 = new frmELGAKlient())
                            {
                                frmELGAKlient1.initControl();
                                frmELGAKlient1.contELGAKlient1.loadData(pat.ID, pat.Aufenthalt.ID);
                                frmELGAKlient1.ShowDialog();
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static bool PatientMassnahme(Guid idPatient, eDekursherkunft Dekursherkunft, Nullable<Guid> IDEintrag, string PflegeplanText)
        {
            return PatientMassnahme(idPatient, false, Dekursherkunft, IDEintrag, PflegeplanText);
        }

        public static bool PatientMassnahme(Guid idPatient, bool bMedikation, eDekursherkunft Dekursherkunft, Nullable<Guid> IDEintragFromQuickbutton,
                                                string PflegeplanText)
		{
			Patient pat = new Patient(idPatient);

            frmPatientMassnahme bem = new frmPatientMassnahme(pat, bMedikation, IDEintragFromQuickbutton);
            if (Dekursherkunft == eDekursherkunft.UngeplanteMassnahmeR�ckmeldenAusIntervention)
            {
                bem.btnKlientenMehrfachauswahl.Visible = true;
            }
            else
            {
                bem.btnKlientenMehrfachauswahl.Visible = false;
            }
            bem.ucPflegeEintrag1.initControl(false, false, false, Dekursherkunft);
            bem.ShowDialog();
			return !bem.abort;
		}

        public static bool PatientRueckmeldungLine(System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> arall,
                                            ref ucSiteMapTermine SiteMap, ref bool Schnellr�ckmeldungAsProcessBack, int mainWindowLeft, int mainWindowTop, int mainWindowWidth, int mainWindowHeight, Control MainControl)
        {
            try
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellr�ckmeldung = true;
                // Alle die nur zum ansehen da sind wegrationalisieren
                List<Guid> lstInterventionenGuid = new List<Guid>();
                List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> ar = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                int iCounter = 0;
                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow r in arall)
                {
                    if (iCounter < frmPatientRueckmeldungLine.GetMaxLines())
                    {
                        //if (!r.Status)
                        //r.RMOptionalJN = true;
                        ar.Add(r);
                        lstInterventionenGuid.Add(r.IDPflegeplan);
                    }
                    iCounter += 1;
                }
                
                //if (Settings.Schnellr�ckmeldungAsProcess.Trim() == "1")
                //{
                //    if (GuiAction.Schnellr�ckmeldungOpend)
                //    {
                //        PMDS.GUI.GUI.Main.frmInfoSchnellrueckmeldungOpend frmInfoSchnellrueckmeldungOpend1 = new GUI.Main.frmInfoSchnellrueckmeldungOpend();
                //        frmInfoSchnellrueckmeldungOpend1.txtInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Schnellr�ckmeldung ist bereits ge�ffnet!");
                //        frmInfoSchnellrueckmeldungOpend1.TopMost = true;
                //        frmInfoSchnellrueckmeldungOpend1.ShowDialog(MainControl);
                //        return false;
                //    }
                //    else
                //    {
                //        remotingClient remotingClient1 = new remotingClient();
                //        cParComm cParComm1 = new cParComm();
                //        cParComm1.lstInterventionen = lstInterventionenGuid;
                //        remotingClient.cCallFctReturn CallFctReturn = null;
                //        if (arall.Count > frmPatientRueckmeldungLine.GetMaxLines())
                //        {
                //            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Es k�nnen max. ") + frmPatientRueckmeldungLine.GetMaxLines().ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen ausgew�hlt werden."), "", MessageBoxButtons.OK, true);
                //            //return false;
                //        }
                //        remotingSrv.openSchnellr�ckmeldungSave(cParComm1.lstInterventionen, mainWindowLeft, mainWindowTop, mainWindowWidth, mainWindowHeight);

                //        return remotingClient.CallFctReturn.bOK;
                //    }
                //}
 
                if (!bfrmRueckmedlungLineisinitialized)
                {
                    frmRueckmedlungLine = new frmPatientRueckmeldungLine();
                    bfrmRueckmedlungLineisinitialized = true;
                }

                frmRueckmedlungLine.SetData(ar);
                DialogResult ret = frmRueckmedlungLine.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    if (SiteMap != null)
                    {
                        SiteMap.RefreshTermin(false);
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
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellr�ckmeldung = false;
                throw new Exception("GuiAction.PatientRueckmeldungLine: " + ex.ToString());
            }
            finally
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellr�ckmeldung = false;
            }
        }

        public static bool PatientRueckmeldung(PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention, PMDS.Global.db.ERSystem.dsTermine.v�bergabeRow r�bergabe,
                                                PMDS.Global.eUITypeTermine UITypeTermine, 
                                                Infragistics.Win.UltraWinGrid.UltraGrid grd, System.Drawing.Image imgRowHeader,
                                                ucSiteMapTermine SiteMap, bool IsNew)
		{
            PMDS.BusinessLogic.PflegePlan dbPflegePlan = null;
            PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow r = null;
            PMDS.BusinessLogic.PflegeEintrag PflegeEintrag = null;

            bool bOptional = false;
            bool bReadOnly = false;
            Patient pat = null;
            DateTime dStartdatumTmp = DateTime.Now;
            if (rIntervention != null)
            {
                pat = new Patient(rIntervention.IDKlient);
                dbPflegePlan = new PflegePlan(rIntervention.IDAufenthalt);
                r = dbPflegePlan.GetRowByID(rIntervention.IDPflegeplan);
                //PflegeEintrag = new PflegeEintrag((System.Guid)rIntervention.IDEintrag);
                dStartdatumTmp = (DateTime)rIntervention.Startdatum;
                bReadOnly = false;
            }
            else if (r�bergabe != null)
            {
                pat = new Patient(r�bergabe.IDKlient);
                dbPflegePlan = new PflegePlan(r�bergabe.IDAufenthalt);
                r = dbPflegePlan.GetRowByID(r�bergabe.IDPflegeplan);
                //PflegeEintrag = new PflegeEintrag((System.Guid)r�bergabe.IDEintrag);
                dStartdatumTmp = (DateTime)r�bergabe.ZeitpunktDatum;
                bReadOnly = true;
            }
            else
            {
                throw new Exception("PatientRueckmeldung: rIntervention == null and r�bergabe == null !");
            }

			// Optionaler R�ckmeldetext verarbeiten

            frmPatientRueckmeldung frmR�cmeldung;
            DialogResult ret ;

            if (r.ID != null)
            {
                bOptional = PMDS.BusinessLogic.PflegePlan.IsRMOptional(r.ID) || ENV.ABTEILUNG_RMOPTIONAL; 
            } 

            PflegeEintrag pe = null;
            if (rIntervention != null)
            {
                pe = GuiAction.NewPflegeEintragByRow(r, (!r.OhneZeitBezug) ? dStartdatumTmp : DateTime.Now, PflegeEintrag);
            }
            else if (r�bergabe != null)
            {
                pe = new PflegeEintrag((System.Guid)r�bergabe.IDPflegeEintrag);
                bReadOnly = true;
            }

            //Pr�fung auf besonderen Berufsstand zur R�ckmeldung
            PMDS.DB.PMDSBusiness dbBusiness = new DB.PMDSBusiness();
            if (!dbBusiness.UserCanSign(r.IDBerufsstand))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("R�ckmelden nicht m�glich: Qualifikation nicht ausreichend, falscher Berufsstand oder kein Recht.");
                return false;
            }

            using (frmR�cmeldung = new frmPatientRueckmeldung(pat, pe, r.Text, r.EinmaligJN, bOptional, true, r.OhneZeitBezug, r.OhneZeitBezug, !r.IsIDBefundNull()))
            {
                frmR�cmeldung.ReadOnly = bReadOnly;
                frmR�cmeldung.SetucPflegeeEntragIsNew(IsNew);
                frmR�cmeldung.ucPflegeEintragInitControl(false, false, !r.IsIDBefundNull(), eDekursherkunft.MassnahmenR�ckmeldungAusIntervention);
                if (rIntervention != null)
                {
                    frmR�cmeldung.SetUIInterventionen(rIntervention);
                }
                if (r�bergabe != null)
                {
                    frmR�cmeldung.SetucPflegeEintrag1auswahlGruppeComboMulti1Visible(false);
                    frmR�cmeldung.SetUI�bergabe(r�bergabe);
                }
                frmR�cmeldung.BringToFront();
                
                ret = frmR�cmeldung.ShowDialog();
                bool abort = frmR�cmeldung.GetAbortStatus();
                if (!abort)
                {
                    if (SiteMap != null)
                    {
                        if (r�bergabe != null)
                        {
                            if (frmR�cmeldung.EintragDeleted)
                            {
                                r�bergabe.Delete();
                            }
                        }
                       //SiteMap.RefreshTermin(false);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

		public static bool PatientRueckmeldung(Guid IDPatient, Guid IDEintrag, Guid IDAufenthalt, bool bDateNow, bool MOhneZeitbezug,
                 PMDS.Global.eUITypeTermine UITypeTermine, Infragistics.Win.UltraWinGrid.UltraGrid grd, System.Drawing.Image imgRowHeader,
                     ucSiteMapTermine SiteMap, bool IsNew)
		{
			Patient pat = new Patient(IDPatient);

			// Optionaler R�ckmeldetext verarbeiten
			bool bOptional = false;
            DialogResult ret;

            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			pp.Read();

			Guid IDPflegeplan = Guid.Empty;
			dsPflegePlan.PflegePlanRow[] ar = pp.GetAllOpenEntriesFromIDEintrag(IDEintrag);
			if(ar.Length == 0)		// Kein Eintrag im PP ==> Meldung und raus
			{
                if (GuiAction.PatientMassnahme(IDPatient, eDekursherkunft.UngeplanteMassnahmeR�ckmeldenAusIntervention, IDEintrag, "Dekurs"))
                {
                    if (SiteMap != null)
                    {
                        SiteMap.RefreshTermin(false);
                    }
                    return true;
                }

                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(Settings.String("ERROR_MISSING_EINTRAG_IN_PP", DBUtil.GetEintragName(IDEintrag), pat.FullName)
                //    , Settings.String("DIALOGTITLE_MISSING_EINTRAG_IN_PP"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //return false;
			}
			else if(ar.Length == 1)						// Genau einer passt
			{
				IDPflegeplan = ar[0].ID;
			}
			else										// mehr als einer ==> Ausw�hlen lassen welcher (vermutlich lokalisiert)
			{
				frmSelectOnePPEntry frm = new frmSelectOnePPEntry(ar);
				DialogResult res =  frm.ShowDialog();
				if(res != DialogResult.OK)
					return false;
				IDPflegeplan = frm.SELECTED_ID;
			}

			if(IDPflegeplan == Guid.Empty)
				return false;

			dsPflegePlan.PflegePlanRow r=null;					// Ermittlung der gew�hlten f�r zusatzwerte
			foreach(dsPflegePlan.PflegePlanRow pfr in ar)
				if(pfr.ID == IDPflegeplan)
					r = pfr;

			bOptional = r.RMOptionalJN || ENV.ABTEILUNG_RMOPTIONAL;	// Optional setzen
						
			// neue R�ckmeldung erzeugen
			DateTime time = r.IsLetztesDatumNull() ? r.StartDatum : r.LetztesDatum;		// Wenn noch kein Letztes Datum gesetzt dann startdatum ohne Intervall nehmen
			if(!r.IsLetztesDatumNull())
				time = time.AddHours(r.Intervall);

			PflegeEintrag pe = PflegeEintrag.NewByPflegePlan(IDAufenthalt, IDPflegeplan, IDEintrag, time, false);

            using (frmPatientRueckmeldung frmR�cmeldung = new frmPatientRueckmeldung(pat, pe, r.Text, r.EinmaligJN, bOptional, true, r.OhneZeitBezug, r.OhneZeitBezug, !r.IsIDBefundNull()))
            {
                frmR�cmeldung.ucPflegeEintragInitControl(false, false, !r.IsIDBefundNull(), eDekursherkunft.MassnahmenR�ckmeldungAusIntervention);
                ret = frmR�cmeldung.ShowDialog();
                bool abort = frmR�cmeldung.GetAbortStatus();
                if (!abort)
                {
                    if (SiteMap != null)
                    {
                        SiteMap.RefreshTermin(false);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
		}
	    
        public static bool PatientUrlaub(Guid idPatient)
		{
            try
            {
                PMDSBusiness b = new PMDSBusiness();
                bool IsAbwesend = false;
                Nullable<Guid> IDEinrichtungEmpf�nger = null;
                Nullable<Guid> IDDokumenteneintrag = null;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IsAbwesend = b.KlientIsAbwesend(db, ENV.IDAUFENTHALT);
                }

                if (!IsAbwesend)            //if (Settings.lic_ELGA && !IsAbwesend)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        using (ucDynReportParameter ucDynReportParameter1 = new ucDynReportParameter())
                        {
                            ucDynReportParameter1.XMLFileAlternate = ENV.ReportConfigPath + @"\Pflegebegleitschreiben.config";
                            ucDynReportParameter1.REPORT_FILE = ENV.ReportPath + @"\Pflegebegleitschreiben.rpt";
                            ucDynReportParameter1._CurrentFormToShow = "PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo";
                            bool abortWindow = false;
                            bool bSaveToArchiv = ENV.SavePflegebegleitschreibenToArchiv;
                            ucDynReportParameter1.ProcessPreview(true, ENV.ReportPath + @"\Pflegebegleitschreiben.rpt", db, ref abortWindow, ref IDEinrichtungEmpf�nger, ref bSaveToArchiv, true, ref IDDokumenteneintrag);
                            if (abortWindow)
                            {
                                string ELGA_OrganizationOID = "";
                                if (IDEinrichtungEmpf�nger != null)
                                {
                                    ELGA_OrganizationOID = (from ein in db.Einrichtung
                                                            where ein.ID == IDEinrichtungEmpf�nger
                                                            select ein.ELGA_OrganizationOID).FirstOrDefault();

                                    if (!ELGA_OrganizationOID.sEquals("DischLoctn", S2Extensions.Enums.eCompareMode.Contains))
                                        return false;
                                }
                                else
                                {
                                    if (!ENV.AcceptNoPBS)
                                        return false;
                                }
                            }
                        }
                    }
                }

                using (GUI.Main.frmUrlaub2 frmUrlaub = new GUI.Main.frmUrlaub2())
                {
                    frmUrlaub.initControl(idPatient);
                    frmUrlaub.ucUrlaub21.loadData();
                    frmUrlaub.ShowDialog();
                    if (!frmUrlaub.ucUrlaub21.abort)
                    {
                        if (GuiActionDone != null)
                            GuiActionDone(SiteEvents.Urlaub);

                        if (frmUrlaub.ucUrlaub21.restartFrm)
                        {
                            return GuiAction.PatientUrlaub(idPatient);
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("GuiAction.PatientUrlaub: " + ex.ToString());
            }
		}

        public static void refreshGridPatientenStart()
        {
            try
            {
                if (GuiActionDone != null)
                    GuiActionDone(SiteEvents.Urlaub);

            }
            catch (Exception ex)
            {
                throw new Exception("refreshGridPatientenStart: " + ex.ToString());
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Patienten Bezugsperson
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool PatientBezugsperson(Guid idPatient)
		{
			Patient p = new Patient(idPatient);

			frmPatientBezug frm = new frmPatientBezug();
            frm.ucBenutzerBezug1.initControl(p.ID);
            frm.ShowDialog();

            return (!frm.abort);
		}

		

        ////----------------------------------------------------------------------------
        ///// <summary>
        ///// Patienten aktuellen Pflegebericht
        ///// </summary>
        ////----------------------------------------------------------------------------
        //public static void PrintPflegePlan(Guid IDAufenthalt, bool bBeendeteAnzeigen)
        //{
        //    ReportManager.PrintPflegePlan(IDAufenthalt, bBeendeteAnzeigen);
        //}

		private static void SetActiveFormEnabled(bool bEnabled) 
		{
            if (System.Windows.Forms.Form.ActiveForm != null)
            {
                if (bEnabled)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    System.Windows.Forms.Form.ActiveForm.Enabled = bEnabled;
                }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                }
            }
		}

        public static bool PreviewTerminliste(PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable dt, TerminlisteAnsichtsmodi Ansichtsinfo, eUITypeTermine UITypeTermine, bool ShowVitalzeichenJN)
		{
            return PMDS.Print.frmPrintPreview.PreviewTerminliste(ref dt, Ansichtsinfo, UITypeTermine, ShowVitalzeichenJN);
		}
        

        //Neu nach 09.10.2008 MDA
        public static bool ShowLinkDokument(Guid IDLinkDokument)
        {
            GuiUtil.ShowLinkDokument(IDLinkDokument);
            return true;
        }


		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen PflegeEintrag anhand einer PflegePlan Zeile erzeugen
		/// </summary>
		//----------------------------------------------------------------------------
        public static PflegeEintrag NewPflegeEintragByRow(PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow r, DateTime time,
                                                         PMDS.BusinessLogic.PflegeEintrag PflegeEintrag)
		{
            PflegeEintrag pe = null;   //lthxy

            if (PflegeEintrag != null)
            {
                //Sonderbehandlung f�r Termin/Medikament
                if (PflegeEintrag.EintragsTyp == PflegeEintragTyp.MEDIKAMENT)
                    pe = PflegeEintrag.NewMedikament(r.IDAufenthalt, r.ID, time);
                else if (PflegeEintrag.EintragsTyp == PflegeEintragTyp.TERMIN || r.IsIDEintragNull())
                    pe = PflegeEintrag.NewByTermin(r.IDAufenthalt, r.ID, time, false);
                else
                    pe = PflegeEintrag.NewByPflegePlan(r.IDAufenthalt, r.ID, r.IDEintrag, time, false);
            }
            else
            {
                if (r.IsIDEintragNull())
                {
                    pe = PflegeEintrag.NewByTermin(r.IDAufenthalt, r.ID, time, false);
                }
                else
                {
                    pe = PflegeEintrag.NewByPflegePlan(r.IDAufenthalt, r.ID, r.IDEintrag, time, false);
                } 
            }

			return pe;
		}


        public static bool InsertTermin(Guid IDAufenthalt, bool bUseTransaction, System.Windows.Forms.Form mainForm,
                                        ucSiteMapTermine SiteMap, Nullable<Guid> IDDekurs, Nullable<Guid> IDExtern) 
		{
            DateTime dt = DateTime.Now;

			ASZMSelectionArgs	args = new ASZMSelectionArgs();
			args.Dauer				= 0;
			args.EinmaligJN			= true;
			args.EintragGruppe		= EintragGruppe.T;
			args.EvalTage			= 0;
			args.IDAbteilung		= ENV.ABTEILUNG;
			args.IDBerufsstand		= ENV.BERUFID;
			args.IDEintrag			= Guid.Empty;
			args.IDPDX				= Guid.Empty;
			args.IDPDXEintrag		= Guid.Empty;
			args.Intervall			= 24;				// Ein Tag
			args.IntervallTyp		= 0;				// Kein Intervall
			args.ISPDX				= false;
			args.Klartext			= "";
			args.Lokalisierung		= "";
			args.LokalisierungJN	= false;
			args.LokalisierungSeite	= "";
			args.ParalellJN			= true;
			args.Sicht				= "";
            if (dt.Hour > 19)
                args.StartDatum = dt.Date.AddDays(1).AddHours(8);   //morgen, 8:00 Uhr
            else if (dt.Hour < 6)
                args.StartDatum = dt.Date.AddHours(8);              //heute, 8:00 Uhr
            else
                args.StartDatum = dt;                               //sofort

            args.Text				= "";
			args.Warnhinweis		= "";
			args.WochenTage			= 127;				            // MO - SO ausgew�hlt
            args.RMOptionalJN       = true;

            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			dsPflegePlan.PflegePlanRow  r       = pp.InsertTermin(args, ENV.USERID);			
			frmTerminEdit               frm     = new frmTerminEdit(r);
            frm.ucPflegePlanSingleEdit1.IsNew = true;
            frm.ucPflegePlanSingleEdit1.IDDekurs = IDDekurs;
            frm.ucPflegePlanSingleEdit1.IDExtern = IDExtern;
            DialogResult res;

            if (mainForm != null)         res = frm.ShowDialog(mainForm);
            else                          res = frm.ShowDialog();

			if(res == DialogResult.OK)
			{
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                pp.Write(ENV.USERID, bUseTransaction, false);
                if (frm.lstPatienteSelected.Count > 0)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        PMDSBusiness1.CopyAndAddPflegeplan(frm._row.ID, ref frm.lstPatienteSelected, db, frm._row.IDAufenthalt);
                    }
                }

                if (SiteMap != null)
                {
                    SiteMap.RefreshTermin(false);
                }
				return true;
			}

			return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einen Termin l�schen (Daten werden in die DB geschrieben)
		/// </summary>
		//----------------------------------------------------------------------------
        public static bool DeleteTermin(Guid IDAufenthalt, Guid IDPflegePlan, bool bUseTransaction ) 
		{
            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			dsPflegePlan.PflegePlanRow r = pp.GetRowByID(IDPflegePlan);
            if (r != null)
            {
                if (r.EintragGruppe == "T")
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    bool UserCanEdit = PMDSBusiness1.UserCanEdit(r.IDBenutzer_Erstellt, PflegeEintragTyp.TERMIN);
                    if (!UserCanEdit)
                    {
                        DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu l�schen!", "Termin l�schen", MessageBoxButtons.OK);
                        return false;
                    }

                    if (!r.IsLetztesDatumNull())
                    {
                        DialogResult res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abgezeichnete Termine k�nnen nicht gel�scht, sondern nur beendet werden!", "Termin l�schen", MessageBoxButtons.OK);
                        return false;
                    }
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Termin wirklich l�schen?", "Termin l�schen", MessageBoxButtons.YesNo);

                    if (res != DialogResult.Yes)
                        return false;

                    PMDSBusiness1.DeletePflegeplan(IDPflegePlan);
                    return true;
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgew�hlt!", "Termin l�schen");
                    return false;
                }
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgew�hlt!", "Termin l�schen");
                return false;
            }
		}

        public static bool EditTermin(Guid IDAufenthalt, Guid IDPflegePlan, bool bUseTransaction, System.Windows.Forms.Form mainForm,
                    Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid, System.Drawing.Image imgRowHeader, ucSiteMapTermine SiteMap) 
		{
            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			dsPflegePlan.PflegePlanRow r = pp.GetRowByID(IDPflegePlan);			
            //if(!r.IsLetztesDatumNull())
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(Settings.String("TERMIN_DONE"));
            //    return false;
            //}

            if (r != null)
            {
                if (r.EintragGruppe == "T")
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    bool UserCanEdit = PMDSBusiness1.UserCanEdit(r.IDBenutzer_Erstellt, PflegeEintragTyp.TERMIN);
                    if (!UserCanEdit)
                    {
                        DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu �ndern!", "Termin �ndern", MessageBoxButtons.OK);
                        return false;
                    }

                    frmTerminEdit frm = new frmTerminEdit(r);
                    DialogResult res;
                    frm.klientenmehrfachauswahlToolStripMenuItem.Visible = false;
                    if (mainForm != null) res = frm.ShowDialog(mainForm);
                    else res = frm.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        pp.Write(ENV.USERID, bUseTransaction, false);
                        if (SiteMap != null)
                        {
                            SiteMap.RefreshTermin(false); 
                        }
                        return true;
                    }
                    return false;
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgew�hlt!", "Termin editieren");
                    return false;
                }
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgew�hlt!", "Termin");
                return false;
            }
		}

		public static bool EndTermin(Guid IDAufenthalt, Guid IDPflegePlan, bool bUseTransaction) 
		{
            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
            dsPflegePlan.PflegePlanRow r = pp.GetRowByID(IDPflegePlan);
            if (r.EintragGruppe == "T")
            {

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                bool UserCanEdit = PMDSBusiness1.UserCanEdit(r.IDBenutzer_Erstellt, PflegeEintragTyp.TERMIN);
                if (!UserCanEdit)
                {
                    DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu beenden!", "Termin beenden", MessageBoxButtons.OK);
                    return false;
                }

                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Termin wirklich beenden?", "Termin beenden", MessageBoxButtons.YesNo);
                if (res != DialogResult.Yes)
                    return false;

                pp.EndPflegePlanID(IDPflegePlan);
                pp.Write(ENV.USERID, bUseTransaction, false);
                return true;
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgew�hlt!", "Termin editieren");
                return false;
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ASZM Verwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool ASZMVerwaltung() 
		{
            if (ENV.adminSecure)
            {
                new frmASZM().Show();
                return true;
            }
            else
            {
                new frmASZM().ShowDialog();
                return true;
            }
		}
        public static bool PDXZuordnung()
        {
            frmPDX2 frm = new frmPDX2();
            frm.ShowDialog(); 
            return true;
        }

	    //----------------------------------------------------------------------------
		/// <summary>
		/// Top 10 Liste
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Top10() 
		{
			// *** TBD **** Komplette Verwaltung umstricken..... 
			new frmTop10().ShowDialog();
			return true;
		}
        public static bool PatientAufnahme(Guid idPatient)
        {
            return PatientAufnahmeWizard(idPatient, false, true, false);

        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// Klinikverwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool KlinikVerwaltung() 
		{
			// �nderungen an der Abteilung werden
			// erst beim Login aktiv
			new frmKlinik().ShowDialog();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// EinrichtungVerwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool EinrichtungVerwaltung() 
		{
            frmEinrichtung frm = new frmEinrichtung();
            frm.initControl();
            frm.ShowDialog();

			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benutzerverwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool BenutzerVerwaltung(bool AlwaysModal) 
		{
            if (PMDS.Global.ENV.adminSecure && !AlwaysModal)
            {
                new frmBenutzer(false).Show();
            }
            else
            {
                new frmBenutzer(false).ShowDialog();
            }
			
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benutzerrechte
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Benutzerrechte() 
		{
			new frmBenutzerGruppe().ShowDialog();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppenrechte
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Gruppenrechte() 
		{
			new frmGruppe().ShowDialog();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auswahllisten
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Auswahllisten() 
		{
            using (frmAuswahl frm = new frmAuswahl())
            {
                frm.ShowDialog();
                return true;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzeintr�ge
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Zusatzeintraege() 
		{
			new frmZusatzEintrag().ShowDialog();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzeintr�ge Zuordnung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool ZusatzeintraegeZuordnung() 
		{
			new frmZusatz().ShowDialog();
			return true;
		}

	    //----------------------------------------------------------------------------
		/// <summary>
		/// Medikamenten Verwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool MedikamentenVerwaltung()
		{
            //new frmMedikamentenVerwaltung().ShowDialog();
            using (frmMedikamentenVerwaltung frm = new frmMedikamentenVerwaltung())
            {
                frm.ShowDialog();
                return true;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Massnahmenserien
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Massnahmenserien()
		{
			DialogResult res = new frmMassnahmenserien().ShowDialog();
			if(res == DialogResult.OK)
				return true;
			else
				return false;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// FormularVerwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool QuickFilter()
		{
            using (frmManageQuickFilter frm = new frmManageQuickFilter())
            {
                DialogResult res = frm.ShowDialog();
                return res == DialogResult.OK;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// FormularVerwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool QuickMeldung()
		{
			DialogResult res = new frmManageQuickMeldung().ShowDialog();
			if(res == DialogResult.OK)
				return true;
			else
				return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DienstzeitenVerwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool DienstZeiten()
		{
			DialogResult res = new frmManageDienstZeiten().ShowDialog();
			if(res == DialogResult.OK)
				return true;
			else
				return false;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Medizinische Typen Verwaltung
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool MedizinischeTypenVerwaltung()
        {
            frmEditMedizinischeTypen2 frmEditMedizinischeTypen21 = new frmEditMedizinischeTypen2();
            frmEditMedizinischeTypen21.initControl();
            frmEditMedizinischeTypen21.Show();
            if (!frmEditMedizinischeTypen21.contEditMedizinischeTypen21.abort)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Link DOkumenten Verwaltung
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool LinkDokumenteVerwaltung()
        {
            DialogResult res = new frmEditLinkDokumente().ShowDialog();
            return (res == DialogResult.OK);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Zeitbereich Verwaltung
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ZeitbereichVerwaltung()
        {
            DialogResult res = new frmZeitbereich().ShowDialog();
            return (res == DialogResult.OK);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ZeitbereichSerien Verwaltung
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ZeitbereichSerienVerwaltung()
        {
            DialogResult res = new frmZeitbereichSerien().ShowDialog();
            return (res == DialogResult.OK);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Text verschl�sseln
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool TextVerschluesseln()
        {
            DialogResult res = new frmTextVerschluesseln().ShowDialog();
            return (res == DialogResult.OK);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf der einzelnen Dialoge ohne Parameter
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ActionFromEvent(SiteEvents e) 
		{
            return ActionFromEvent(e, new SiteEventArgs(), null, null);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufruf der einzelnen Dialoge 
		/// </summary>
		//----------------------------------------------------------------------------
        public static bool ActionFromEvent(SiteEvents e, SiteEventArgs args,  dsKlinik.KlinikRow rKlinik, 
                                            ucSiteMapTermine SiteMap, ucMain mainWindow = null) 
		{
			switch(e) 
			{
				case SiteEvents.Entlassen:					return GuiAction.PatientEntlassung2(args.IDPatient, mainWindow);
				case SiteEvents.Aufnahme:					return GuiAction.PatientAufnahme();
				case SiteEvents.ASZMVerwaltung:				return GuiAction.ASZMVerwaltung();
                case SiteEvents.PDXZuordnung:               return GuiAction.PDXZuordnung();
				case SiteEvents.Top10:						return GuiAction.Top10();
                //case SiteEvents.AbteilungenVerwaltung:		return GuiAction.AbteilungVerwaltung();
                //case SiteEvents.BereicheVerwaltung:			return GuiAction.BereichVerwaltung();
				case SiteEvents.KlinikVerwaltung:			return GuiAction.KlinikVerwaltung();
				case SiteEvents.EinrichtungenVerwaltung:	return GuiAction.EinrichtungVerwaltung();
				case SiteEvents.BenutzerVerwaltung:			return GuiAction.BenutzerVerwaltung(false);
				case SiteEvents.Gruppenrechte:				return GuiAction.Gruppenrechte();
				case SiteEvents.Benutzerrechte:				return GuiAction.Benutzerrechte();

				case SiteEvents.Auswahllisten:				return GuiAction.Auswahllisten();
				case SiteEvents.Zusatzeintraege:			return GuiAction.Zusatzeintraege();
				case SiteEvents.ZusatzeintraegeZuordnung:	return GuiAction.ZusatzeintraegeZuordnung();
                case SiteEvents.Versetzen:                  return GuiAction.PatientVersetzung(args.IDPatient, rKlinik);
				case SiteEvents.Urlaub:						return GuiAction.PatientUrlaub(args.IDPatient);
				case SiteEvents.Historie:					return GuiAction.PatientAufenthaltInfo(args.IDPatient);
				case SiteEvents.Bemerkung:					return GuiAction.PatientRemark(args.IDPatient);
				case SiteEvents.Bezugsperson:				return GuiAction.PatientBezugsperson(args.IDPatient);
				case SiteEvents.Massnahme:					return GuiAction.PatientMassnahme(args.IDPatient, eDekursherkunft.MassnahmenR�ckmeldungAusIntervention, null, "Dekurs");
                case SiteEvents.BedarfsMedikationMelden: return GuiAction.PatientMassnahme(args.IDPatient, true, eDekursherkunft.BedarfsmedikamentationAusIntervention, null, "Dekurs");
				case SiteEvents.Vermerk:					return GuiAction.PatientVermerk(args.IDPatient, null,  eDekursherkunft.DekursAusMitBereich, "", false, false, null, true, "guiAction.ActionFromEvent()", false, "");

                case SiteEvents.TerminNew: return GuiAction.InsertTermin(args.IDAufenthalt, true, null, SiteMap, null, null);
				case SiteEvents.TerminEdit:					return GuiAction.EditTermin(args.IDAufenthalt, args.IDPflegeplan, true, null, null, null, null  );
				case SiteEvents.TerminDelete:				return GuiAction.DeleteTermin(args.IDAufenthalt, args.IDPflegeplan, true);
				case SiteEvents.TerminEnd:					return GuiAction.EndTermin(args.IDAufenthalt, args.IDPflegeplan, true);
                case SiteEvents.MedikamenteVerwalten:       return GuiAction.MedikamentenVerwaltung();										
                //case SiteEvents.DruckenPflegeplanPDx:		ReportManager.PrintPflegePlanPDxOrientated(args.IDAufenthalt, true);
                //                                            return true;
                //case SiteEvents.DruckenPflegeplanPDxOnlyOpen:	ReportManager.PrintPflegePlanPDxOrientated(args.IDAufenthalt, false);
                //                                            return true;
				case SiteEvents.Massnahmenserien:			return GuiAction.Massnahmenserien();
				
				case SiteEvents.QuickFilter:				return GuiAction.QuickFilter();
				case SiteEvents.QuickMeldung:				return GuiAction.QuickMeldung();
				case SiteEvents.DienstZeiten:				return GuiAction.DienstZeiten();
                case SiteEvents.MedizinischetypenVerwaltung:return GuiAction.MedizinischeTypenVerwaltung();
                case SiteEvents.LinkDokumenteVerwaltung:    return GuiAction.LinkDokumenteVerwaltung();
                case SiteEvents.Zeitbereich:                return GuiAction.ZeitbereichVerwaltung();
                case SiteEvents.Zeitbereichserien:          return GuiAction.ZeitbereichSerienVerwaltung();
                case SiteEvents.TextVerschluesseln:         return GuiAction.TextVerschluesseln();

				// rtf
				
                //Neu nach 09.10.2008 MDA
                case SiteEvents.PrintPflegestandard:        return GuiAction.ShowLinkDokument(args.IDLinkDokument);

				// TBD nicht verwendete SiteEvents
				default:
                    throw new Exception("Event: " + e.ToString() + " nicht definiert");
					//break;
			}

			//return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Passwort des angemeldeten Benutzers �ndern
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool ChangePassword(bool ELGAMode, bool NeedOldPassword)
		{
			Benutzer ben = new Benutzer(ENV.USERID);

            using (frmEditPassword frm = new frmEditPassword(ELGAMode, NeedOldPassword, ben))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return false;

                ben.Write();
            }            
			return true;			
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Standardprozeduren Bildschiem aufrufen
        /// erste GUID ist im Modus neu die IDStandardprozedur im Modus edit die bereitsd bestehende IDSP
        /// </summary>
        //----------------------------------------------------------------------------
        public static void Notfall(Guid IDStandardprozeduroderIDSP, Guid IDAufenthalt, BearbeitungsModus mode)
        {
            if (IDAufenthalt == Guid.Empty)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es ist kein Klient gew�hlt.\r\nBitte w�hlen Sie einen Klienten", "Klient nicht ausgew�hlt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmNotfall frm = new frmNotfall(IDAufenthalt, IDStandardprozeduroderIDSP, mode);
            if(frm.ShowDialog() == DialogResult.OK)
                ENV.SignalMedizinischerStateChanged(999);
        }
      
    }
}
