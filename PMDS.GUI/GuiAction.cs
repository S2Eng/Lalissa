//----------------------------------------------------------------------------
/// <summary>
///	GuiAction.cs
/// Erstellt am:	16.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.GUI.BaseControls;
using System.Linq;
using System.Linq.Expressions;

using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;

//using PdfSharp.Pdf; 
//using PdfSharp.Pdf.IO;

using Syncfusion.Pdf;
using Syncfusion.Compression;
using Patagames.Pdf.Net;
using PMDS.Global.Remote;
using PMDS.GUI.Quickfilter;

namespace PMDS.GUI
{

    public delegate void GuiActionDoneDelegate(SiteEvents ev);

	//----------------------------------------------------------------------------
	/// <summary>
	/// Allgemeine nützliche Abläufe
	/// </summary>
	//----------------------------------------------------------------------------
	public class GuiAction
	{
        public static event GuiActionDoneDelegate GuiActionDone;      // Signalisiert dass eine Gewisse Aktion durchgeführt worden ist;

		public static Guid     LastAufnahmePatientID;
        public static Guid     LastVersetzungAbteilungID;
        public static Guid     LastVersetzungBereichID;
        public static string   LastVersetzungBereichText = "";
        public static frmPatientRueckmeldungLine frmRueckmedlungLine;
        private static bool bfrmRueckmedlungLineisinitialized = false;

        public static int _iPageCount;
        public static bool SchnellrückmeldungOpend = false;





		public GuiAction()
		{
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Patienten Aufnahme mit Picker
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool PatientAufnahme()
		{
			frmPatientAufnahme auf = new frmPatientAufnahme();
            bool bOK = (auf.ShowDialog() == DialogResult.OK);

            if (bOK)
                ENV.SignalNeuerPatient(LastAufnahmePatientID);              // Sicherstellen dass alle vorprozesse mitbekommen dass ein neuer Klient da ist (zB für den Header Patientpicker)

            //if (bOK && GuiActionDone != null)
            //    GuiActionDone(SiteEvents.Aufnahme);

			return (bOK);
		}
        	
        //----------------------------------------------------------------------------
        /// <summary>
        /// Terminsystem
        /// Guid.Empty == Gesamtterminsystem
        /// </summary>
        //----------------------------------------------------------------------------
        public static void archivTerminMail(bool gesamt, bool headerEin, bool ShowKlientenarchiv)
        {
            GuiWorkflow.ShowArchivPlanung(gesamt, headerEin, ShowKlientenarchiv);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Berichte
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool Berichte()
        {
            frmDynReports frm = new frmDynReports(ENV.DynReportExtrasPath);
            
            frm.Show ();
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Berichte
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool BerichteWunde()
        {
            frmDynReports frm = new frmDynReports(ENV.DynReportWundePath);
            frm.Show();
            return true;
        }

        //Neu nach 08.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Formular für Medizinischedaten Layout anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool MedizinischeDialoge()
        {
            frmMedizinischeDatenLayout frm = new frmMedizinischeDatenLayout();
            frm.Show();
            return true;
        }

        //Neu nach 11.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Formular für Standardprozeduren anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool Standardprozeduren()
        {
            frmStandardProzeduren frm = new frmStandardProzeduren();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
                ENV.SignalNotfallChanged(frm, EventArgs.Empty);
            return true;
        }

        //Neu nach 26.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Formular für Bewerberverwaltung anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool Bewerberverwaltung()
        {
            frmBewerber frm = new frmBewerber();
            frm.ShowDialog();
            GuiWorkflow.setHistorieOnOff();
            return true;
        }

        //Neu nach 28.09.2007 MDA
		//----------------------------------------------------------------------------
		/// <summary>
		/// Patienten Versetzung
		/// </summary>
		//----------------------------------------------------------------------------
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// Patienten Entlassung
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool PatientEntlassung2(Guid idPatient, ucMain mainWindow)
		{
			Patient pat = new Patient(idPatient);

			// Hinweis bei Entlassung, wenn Patient im Urlaub
			if (pat.Aufenthalt.HasUrlaub)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.PATIENT_URLAUB"),ENV.String("GUI.DIALOGTITLE_PATIENT_URLAUB"), 
                                                                                MessageBoxButtons.OK,MessageBoxIcon.Stop, true);

			frmEntlassung ent = new frmEntlassung(pat);
            ent.mainWindow = mainWindow;
            bool bOK = (ent.ShowDialog() == DialogResult.OK);
            
            if (bOK && GuiActionDone != null)
                GuiActionDone(SiteEvents.Entlassen);
			
            return (bOK);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Patienten Aufenthalts informationen
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool PatientAufenthaltInfo(Guid idPatient)
		{
            PMDS.GUI.frmPatientHistorie auf = new PMDS.GUI.frmPatientHistorie(idPatient, false);
			return (auf.ShowDialog() == DialogResult.OK);
		}                              

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klientenbericht drucken
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool Datenarchivierung(TXTextControl.TextControl  txtEditor)   // für alle Klienten
        {
            bool DocuSuccessfullyGenerated = false;
            string FileNamePDFDocument = "";
            System.Guid g = Guid.Empty;
            return Datenarchivierung(g, txtEditor, ENV.IDKlinik, ref DocuSuccessfullyGenerated, ref FileNamePDFDocument, ENV.eKlientenberichtTyp.full);
        }

        public static bool Datenarchivierung(System.Guid IDPatient,   TXTextControl.TextControl  txtEditor, System.Guid IDKlinik, ref bool DocuSuccessfullyGenerated, ref string FileNamePDFDocumentBack, ENV.eKlientenberichtTyp KlientenberichtTyp)    //für einen Klienten
        {
            //Aktuellen Standarddrucker merken
            //string Standarddrucker =  PMDS.Print.CR.PrinterSettings.GetDefaultPrinterName();
            
            try
            {
                //Für alle Patienten
                string tmpFullPath = "";
                string filenamePDFA = "";

                System.Guid[] arrAbteilung = null;
 
                dsPatientStation.PatientDataTable PatListe1 = new dsPatientStation.PatientDataTable();

                if (IDPatient == Guid.Empty)            //Alle Patienten
                {
                    dsPatientStation.PatientDataTable PatListe2 = new dsPatientStation.PatientDataTable();
                    PatListe1 = GuiUtil.GetKlientenforCurrentSelectionAbrech(false, IDKlinik);  // aktive
                    PatListe2 = GuiUtil.GetKlientenforCurrentSelectionAbrech(true, IDKlinik);   // entlassene

                    // Listen zusammenführen, dabei Mehrfachaufenthalte herausfiltern
                    foreach (dsPatientStation.PatientRow r2 in PatListe2)
                    {
                        dsPatientStation.PatientRow[] arrAktiv = (dsPatientStation.PatientRow[])PatListe1.Select("ID='" + r2.ID.ToString() + "'");
                        if (arrAktiv.Length == 0)
                        {
                            dsPatientStation.PatientRow rnew = (dsPatientStation.PatientRow)PatListe1.NewRow();
                            rnew.ItemArray = r2.ItemArray;
                            PatListe1.Rows.Add(rnew);
                        }
                    }
                }
                else                                    //Ein bestimmter Patient
                {
                    Patient pat = new Patient(IDPatient);
                    //<20120202-2>
                    DBPatient dbPat = new DBPatient();
                    PatListe1 = dbPat.GetPatienten(pat.Nachname + " " + pat.Vorname, false, arrAbteilung, System.Guid.Empty, new DateTime(1901, 1, 1), new DateTime(3000, 1, 1), new DateTime(2000, 1, 1), new DateTime(3000, 1, 1), ENV.IDKlinik);

                    if (PatListe1.Rows.Count > 1)           // Mehrfach-Aufenthalte löschen
                    {
                        for (int i = 1; i < PatListe1.Rows.Count; i++)
                        {
                            PatListe1.Rows[i].Delete();
                        }
                    }
                }

                dbQueries_os myQuery = new dbQueries_os();

                string KlientNameGebDat = "";

                foreach (dsPatientStation.PatientRow r in PatListe1.Rows)
                {
                    Patient pat = new Patient(r.ID);
                    KlientNameGebDat = pat.Nachname.Trim() + "_" + pat.Vorname.Trim() + "_" + string.Format("{0:yyyyMMdd}", pat.Geburtsdatum);

                    if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention)
                        KlientNameGebDat += DateTime.Now.ToString("_BPyyyyMMddHHmmss");

                    KlientNameGebDat =  Regex.Replace(KlientNameGebDat, @"[^0-9a-zA-Z.äöüÄÖÜß]\\", string.Empty);

                    if (r.RowState == System.Data.DataRowState.Deleted) break;  //gelöschte nicht behandeln

                    tmpFullPath = PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, "Dummy.txt");
                    if (tmpFullPath == "") return false;

                    //Klientenbericht ausgeben (für jeden Aufenthalt des Klienten einmal)
                    dsAufenthalt.AufenthaltDataTable Aufenthalte = Aufenthalt.ByPatient(r.ID);


                    foreach (dsAufenthalt.AufenthaltRow auf in Aufenthalte)
                    {

                        if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention && auf.IsEntlassungszeitpunktNull() || KlientenberichtTyp == ENV.eKlientenberichtTyp.full)
                        {
                            PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, "Klientenbericht.rpt"), r.ID, auf.ID, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp);
                            // Im Reportsdirectory alle Klientenbericht.0*.rpt suchen und nacheinander drucken
                            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(System.IO.Path.Combine(ENV.ReportPath, "*.*")));
                            FileInfo[] pdfList = di.GetFiles("Klientenbericht.0*", SearchOption.TopDirectoryOnly);

                            foreach (FileInfo fi in pdfList)
                            {
                                if (KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention &&
                                    (!fi.ToString().Contains("0010")) && !fi.ToString().Contains("0020") && !fi.ToString().Contains("0060") && !fi.ToString().Contains("0070") && !fi.ToString().Contains("0090"))
                                //Liste Assessments, Aufenthaltsverlauf, Pflegebericht, Evaluierunge und WundDoku in BlackoutPrävention nicht ausgeben.
                                {
                                    PMDS.Print.ReportManager.PrintKlientenbericht(System.IO.Path.Combine(ENV.ReportPath, fi.Name), r.ID, auf.ID, ENV.ArchivPath, false, KlientNameGebDat, KlientenberichtTyp);
                                }
                            }
                        }
                    }

                    //Anamnesen (einmal pro Patient)
                    PMDS.Global.db.Patient.dsAnamnesen.AnamnesenProPatientDataTable dtAna = myQuery.GetAllAnamnesenProPatient(r.ID);
                    foreach (PMDS.Global.db.Patient.dsAnamnesen.AnamnesenProPatientRow ana in dtAna)
                    {
                        if (ana.AnamneseTyp.ToUpper() == "OREM")
                        {
                            //Alle OREM-Anamnesen lesen und drucken
                            PMDS.Print.ReportManager.PrintAnamnese("OREM", System.IO.Path.Combine(ENV.ReportPath, "OREM1.rpt"), r.ID, ENV.ArchivPath, false, true, System.Guid.Empty, KlientNameGebDat, KlientenberichtTyp);
                        }
                        else if (ana.AnamneseTyp.ToUpper() == "KROHWINKEL")
                        {
                            //Alle Krohwinkel-Anamnesen lesen und drucken
                            PMDS.Print.ReportManager.PrintAnamnese("KROHWINKEL", System.IO.Path.Combine(ENV.ReportPath, "Krohwinkel.rpt"), r.ID, ENV.ArchivPath, false, true, System.Guid.Empty, KlientNameGebDat, KlientenberichtTyp);
                        }
                        else if (ana.AnamneseTyp.ToUpper() == "POP")
                        {
                            //Alle POP-Anamnesen lesen und drucken
                            PMDS.Print.ReportManager.PrintAnamnese("POP", System.IO.Path.Combine(ENV.ReportPath, "POP.rpt"), r.ID, ENV.ArchivPath, false, true, System.Guid.Empty, KlientNameGebDat, KlientenberichtTyp);
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
                            tmpFullPath = PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, rBio["FormularName"].ToString());
                            txtEditor.Text = "";
                            byte[] by = null;
                            byte[] bPdf = null;
                            doEdit.showText(rBio["BLOP"].ToString(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.PageView, txtEditor, ref by, ref bPdf);
                            doEdit.saveDocument(tmpFullPath, TXTextControl.StreamType.AdobePDF, txtEditor);
                        }

                        //Assessments (einmal pro Patient) //Ablöse des Formularmanagers durch PDF, os 171009
                        PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                        PdfCommon.Initialize("52433553494d50032923be84e16cd6ae0bce153446af7918d52303038286fd2b0597de34bf5bb65e2a161a268e74107bd7da7c1adb202edff3e8c55a13bff7afa38569c96e45ff0cdef48e36b8df77e907676788cae00126f52c5eaadbb3c424062e8e0e5feb6faf89900306ee469aa40664bdf84b2e4fce7497c19f3f9d2d877dc1be192cb695f4");

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
                                            //Mit Patagames
                                            using (PdfForms formFDF = new PdfForms())
                                            {
                                                FdfDocument docFDF = Patagames.Pdf.Net.FdfDocument.Load(rFormularDaten.PDF_BLOP);
                                                Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(rFormular.PDF_BLOP, formFDF);
                                                formFDF.InterForm.ResetForm();
                                                formFDF.InterForm.ImportFromFdf(docFDF);
                                                docPDF.Save(PMDS.Print.CR.ReportManager.GetUniqueArchivFileName(KlientNameGebDat, ENV.ArchivPath, rFormular.Name), Patagames.Pdf.Enums.SaveFlags.RemoveSecurity);
                                            }
                                        }
                                        else
                                        {
                                            //Biografien sind in den Assessments enthalten, haben aber kein FDF. Ist kein Fehler.
                                            //throw new Exception("Kein Formular gefunden für " + rFormularDaten.FormularName);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Erstellen eines pdf/A-Files pro Klient und löschen der temp. PDFs
                    int iCountAufenthalte = 0;
                    Syncfusion.Pdf.PdfDocument outputDocument = new Syncfusion.Pdf.PdfDocument();
                    List<string> lstSourceFiles = new List<string>();  //Array mit PDFs, die zusammenzufassen sind

                    // Alle pdfs des Verzeichnisses 
                    string KlientVerzeichnis = System.IO.Path.Combine (ENV.ArchivPath, KlientNameGebDat);
                    DirectoryInfo di1 = new DirectoryInfo(KlientVerzeichnis);

                    FileInfo[] pdfList1 = di1.GetFiles("Klientenbericht.rpt*.pdf");
                    foreach (FileInfo fi in pdfList1)
                    {
                        string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                        lstSourceFiles.Add(tmpFileName);
                        //File.Delete(tmpFileName);

                        iCountAufenthalte++;
                    }

                    FileInfo[] pdfList1a = di1.GetFiles("Klientenbericht.0*.pdf");
                    foreach (FileInfo fi in pdfList1a)
                    {
                        string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                        lstSourceFiles.Add(tmpFileName);
                        //File.Delete(tmpFileName);
                    }                    

                    FileInfo[] pdfList2 = di1.GetFiles("*.pdf");
                    foreach (FileInfo fi in pdfList2)
                    {
                        string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                        lstSourceFiles.Add(tmpFileName);
                        //File.Delete(tmpFileName);
                    }

                    filenamePDFA = System.IO.Path.Combine(ENV.ArchivPath, KlientNameGebDat + ".PDF");          
                    Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument(PdfConformanceLevel.Pdf_A1B);
                    finalDoc.Compression = PdfCompressionLevel.Best;
                    Syncfusion.Pdf.PdfDocument.Merge(finalDoc, lstSourceFiles.ToArray());
                    finalDoc.Save(filenamePDFA);
                    Directory.Delete(KlientVerzeichnis, true);
                }

                string sMsgBoxTranslate = "Datenarchiv wurde als {0} erstellt.";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, filenamePDFA.Trim());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Information");
                FileNamePDFDocumentBack = filenamePDFA.Trim();
                DocuSuccessfullyGenerated = true;

                return true;
            }

            catch (Exception e)
            {
                throw new Exception("GuiAction.Datenarchivierung: " + e.ToString());
            }
        }

		public static bool PatientRemark(Guid idPatient)
		{
			Patient pat = new Patient(idPatient);

			frmPatientBem bem = new frmPatientBem(pat, _typBemerkung.bemerkung  );
			return (bem.ShowDialog() == DialogResult.OK);
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

            frmWizard wizard = new frmWizard();

            // Titelzeile für Wizard
            if (bNeuAufnahme)
            {
                wizard.Text = ENV.String("GUI.NEW_PATIENT_AUFNAHME");
            }
            else
            {
                wizard.Text = pat.FullInfo;
                wizard.Description = "Aufnahme von " + pat.FullInfo;
            }

            // Wizard Pages erzeugen
            ucPatientNew p0 = new ucPatientNew();

            // Einzelne Pages mit Daten verknüpfen
            p0.Patient = pat;
            p0.MODIFYMODE = !bNeuAufnahme;

            // Pages einhängen
            if (!bNeuAufnahme)
                p0.ReadOnly = true;

            string s = bNeuAufnahme ? ENV.String("GUI.NEW_PATIENT") : wizard.Description;
            wizard.AddPage(s, p0);
                     
            // Wizard starten
            if (wizard.ShowDialog() != DialogResult.OK)
                return false;

            if (!bNeuAufnahme)          // Sicherheitsabfrage wegen ungereimtheiten in der Aufnahmeliste
            {
                Guid g = Aufenthalt.LastByPatient(pat.ID);

                //Neu nach 02.07.2007 MDA.
                //Wenn ein Patient zu keinem Aufenthalt zugeornet ist wird ein Guid.Empty zuruckgegeben
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

            LastAufnahmePatientID = pat.ID;
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
            if (Dekursherkunft == eDekursherkunft.UngeplanteMassnahmeRückmeldenAusIntervention)
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
                                            ref ucSiteMapTermine SiteMap, ref bool SchnellrückmeldungAsProcessBack, int mainWindowLeft, int mainWindowTop, int mainWindowWidth, int mainWindowHeight, Control MainControl)
        {
            try
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = true;
                // Alle die nur zum ansehen da sind wegrationalisieren
                List<Guid> lstInterventionenGuid = new List<Guid>();
                List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> ar = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                int iCounter = 0;
                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow r in arall)
                {
                    if (iCounter < frmPatientRueckmeldungLine.maxLinesSR)
                    {
                        //if (!r.Status)
                        ar.Add(r);
                        lstInterventionenGuid.Add(r.IDPflegeplan);
                    }
                    iCounter += 1;
                }
                
                if (ENV.SchnellrückmeldungAsProcess.Trim() == "1")
                {
                    if (GuiAction.SchnellrückmeldungOpend)
                    {
                        PMDS.GUI.GUI.Main.frmInfoSchnellrueckmeldungOpend frmInfoSchnellrueckmeldungOpend1 = new GUI.Main.frmInfoSchnellrueckmeldungOpend();
                        frmInfoSchnellrueckmeldungOpend1.txtInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Schnellrückmeldung ist bereits geöffnet!");
                        frmInfoSchnellrueckmeldungOpend1.TopMost = true;
                        frmInfoSchnellrueckmeldungOpend1.ShowDialog(MainControl);
                        return false;
                    }
                    else
                    {
                        remotingClient remotingClient1 = new remotingClient();
                        cParComm cParComm1 = new cParComm();
                        cParComm1.lstInterventionen = lstInterventionenGuid;
                        remotingClient.cCallFctReturn CallFctReturn = null;

                        ////Test getInterventionen
                        //PMDSBusiness b = new PMDSBusiness();
                        //PMDS.Global.db.ERSystem.dsTermine dsTermine = null;
                        //b.getInterventionenByIDs(ref lstInterventionenGuid, true, ref dsTermine);

                        //remotingSrv remotingSrv1 = new remotingSrv();
                        //remotingSrv1.run(remotingSrv.PortMainPMDS.Trim(), remotingSrv.UriMainPMDS.Trim(), remotingSrv.varsToCall.SrvNr, false, false);

                        if (arall.Count > frmPatientRueckmeldungLine.maxLinesSR)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Es können max. ") + frmPatientRueckmeldungLine.maxLinesSR.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen ausgewählt werden."), "", MessageBoxButtons.OK, true);
                            //return false;
                        }

                        remotingSrv.openSchnellrückmeldungSave(cParComm1.lstInterventionen, mainWindowLeft, mainWindowTop, mainWindowWidth, mainWindowHeight);

                        //remotingSrv.SiteMap = SiteMap;
                        //remotingClient1.callFct(ICommunicationService.eTypeCallTo.ClientPMDS, ICommunicationService.eTypeFct.StartSchnellrückmeldung, cParComm1, ref CallFctReturn);
                        //SchnellrückmeldungAsProcessBack = true;
                        ////return false;

                        if (remotingClient.CallFctReturn.bOK)
                        {
                            //if (remotingSrv.SiteMap != null)
                            //{
                            //    remotingSrv.SiteMap.RefreshTermin(false);
                            //}
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (!bfrmRueckmedlungLineisinitialized)
                    {
                        frmRueckmedlungLine = new frmPatientRueckmeldungLine();
                        bfrmRueckmedlungLineisinitialized = true;
                    }

                    frmRueckmedlungLine._ar = ar;
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
                //PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = false;

            }
            catch (Exception ex)
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = false;
                throw new Exception("GuiAction.PatientRueckmeldungLine: " + ex.ToString());
            }
            finally
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = false;
            }
        }

        public static bool PatientRueckmeldung(PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention, PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow rÜbergabe,
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
            else if (rÜbergabe != null)
            {
                pat = new Patient(rÜbergabe.IDKlient);
                dbPflegePlan = new PflegePlan(rÜbergabe.IDAufenthalt);
                r = dbPflegePlan.GetRowByID(rÜbergabe.IDPflegeplan);
                //PflegeEintrag = new PflegeEintrag((System.Guid)rÜbergabe.IDEintrag);
                dStartdatumTmp = (DateTime)rÜbergabe.ZeitpunktDatum;
                bReadOnly = true;
            }
            else
            {
                throw new Exception("PatientRueckmeldung: rIntervention == null and rÜbergabe == null !");
            }

			// Optionaler Rückmeldetext verarbeiten

            frmPatientRueckmeldung frmRücmeldung;
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
            else if (rÜbergabe != null)
            {
                pe = new PflegeEintrag((System.Guid)rÜbergabe.IDPflegeEintrag);
                bReadOnly = true;
            }

            //Prüfung auf besonderen Berufsstand zur Rückmeldung
            PMDS.DB.PMDSBusiness dbBusiness = new DB.PMDSBusiness();
            if (!dbBusiness.UserCanSign(r.IDBerufsstand))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rückmelden nicht möglich: Qualifikation nicht ausreichend, falscher Berufsstand oder kein Recht.");
                return false;
            }


            frmRücmeldung = new frmPatientRueckmeldung(pat, pe, r.Text, r.EinmaligJN, bOptional, true, r.OhneZeitBezug, r.OhneZeitBezug, !r.IsIDBefundNull());
            frmRücmeldung.ReadOnly = bReadOnly;
            frmRücmeldung.ucPflegeEintrag1.IsNew = IsNew;
            frmRücmeldung.ucPflegeEintrag1.initControl(false, false, !r.IsIDBefundNull(), eDekursherkunft.MassnahmenRückmeldungAusIntervention);
            if (rIntervention != null)
            {
                frmRücmeldung.SetUIInterventionen(rIntervention);
            }
            if (rÜbergabe != null)
            {
                frmRücmeldung.ucPflegeEintrag1.auswahlGruppeComboMulti1.Visible = false;
                frmRücmeldung.SetUIÜbergabe(rÜbergabe);
            }

            ret = frmRücmeldung.ShowDialog();

            if (!frmRücmeldung.abort)
            {
                if (SiteMap != null)
                {
                    if (rÜbergabe != null)
                    {
                        if (frmRücmeldung.EintragDeleted)
                        {
                            rÜbergabe.Delete();
                        }
                    }
                    SiteMap.RefreshTermin(false); 
                }
                return true;
            }
            else
            {
                return false;
            }
		}

		public static bool PatientRueckmeldung(Guid IDPatient, Guid IDEintrag, Guid IDAufenthalt, bool bDateNow, bool MOhneZeitbezug,
                 PMDS.Global.eUITypeTermine UITypeTermine, Infragistics.Win.UltraWinGrid.UltraGrid grd, System.Drawing.Image imgRowHeader,
                     ucSiteMapTermine SiteMap, bool IsNew)
		{
			Patient pat = new Patient(IDPatient);

			// Optionaler Rückmeldetext verarbeiten
			bool bOptional = false;
            DialogResult ret;

            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			pp.Read();

			Guid IDPflegeplan = Guid.Empty;
			dsPflegePlan.PflegePlanRow[] ar = pp.GetAllOpenEntriesFromIDEintrag(IDEintrag);
			if(ar.Length == 0)		// Kein Eintrag im PP ==> Meldung und raus
			{
                if (GuiAction.PatientMassnahme(IDPatient, eDekursherkunft.UngeplanteMassnahmeRückmeldenAusIntervention, IDEintrag, "Dekurs"))
                {
                    if (SiteMap != null)
                    {
                        SiteMap.RefreshTermin(false);
                    }
                    return true;
                }

                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSING_EINTRAG_IN_PP", DBUtil.GetEintragName(IDEintrag), pat.FullName)
                //    , ENV.String("DIALOGTITLE_MISSING_EINTRAG_IN_PP"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //return false;
			}
			else if(ar.Length == 1)						// Genau einer passt
			{
				IDPflegeplan = ar[0].ID;
			}
			else										// mehr als einer ==> Auswählen lassen welcher (vermutlich lokalisiert)
			{
				frmSelectOnePPEntry frm = new frmSelectOnePPEntry(ar);
				DialogResult res =  frm.ShowDialog();
				if(res != DialogResult.OK)
					return false;
				IDPflegeplan = frm.SELECTED_ID;
			}

			if(IDPflegeplan == Guid.Empty)
				return false;

			dsPflegePlan.PflegePlanRow r=null;					// Ermittlung der gewählten für zusatzwerte
			foreach(dsPflegePlan.PflegePlanRow pfr in ar)
				if(pfr.ID == IDPflegeplan)
					r = pfr;

			bOptional = r.RMOptionalJN || ENV.ABTEILUNG_RMOPTIONAL;	// Optional setzen
						
			// neue Rückmeldung erzeugen
			DateTime time = r.IsLetztesDatumNull() ? r.StartDatum : r.LetztesDatum;		// Wenn noch kein Letztes Datum gesetzt dann startdatum ohne Intervall nehmen
			if(!r.IsLetztesDatumNull())
				time = time.AddHours(r.Intervall);

			PflegeEintrag pe = PflegeEintrag.NewByPflegePlan(IDAufenthalt, IDPflegeplan, IDEintrag, time, false);

            frmPatientRueckmeldung frmRücmeldung = new frmPatientRueckmeldung(pat, pe, r.Text, r.EinmaligJN, bOptional, true, r.OhneZeitBezug, r.OhneZeitBezug, !r.IsIDBefundNull());
            frmRücmeldung.ucPflegeEintrag1.initControl(false, false, !r.IsIDBefundNull(), eDekursherkunft.MassnahmenRückmeldungAusIntervention);
            ret = frmRücmeldung.ShowDialog();

            if (!frmRücmeldung.abort)
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
	    
        public static bool PatientUrlaub(Guid idPatient)
		{
            try
            {
                GUI.Main.frmUrlaub2 frmUrlaub = new GUI.Main.frmUrlaub2();
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

                if (frmUrlaub.ucUrlaub21.restartFrm)
                {
                    return GuiAction.PatientUrlaub(idPatient);
                }
                else
                {
                    return false;
                }


                //Patient pat = new Patient(idPatient);
                //frmUrlaub urlaub = new frmUrlaub(pat);			
                //DialogResult res = urlaub.ShowDialog();

                //if (res == DialogResult.OK)
                //{
                //   if (GuiActionDone != null)
                //       GuiActionDone(SiteEvents.Urlaub);
                //   return true;
                //}
                //return false;

            }
            catch (Exception ex)
            {
                throw new Exception("PatientUrlaub: " + ex.ToString());
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
                //Sonderbehandlung für Termin/Medikament
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
			args.WochenTage			= 127;				            // MO - SO ausgewählt
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
		/// Einen Termin löschen (Daten werden in die DB geschrieben)
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
                        DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu löschen!", "Termin löschen", MessageBoxButtons.OK);
                        return false;
                    }

                    if (!r.IsLetztesDatumNull())
                    {
                        DialogResult res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abgezeichnete Termine können nicht gelöscht, sondern nur beendet werden!", "Termin löschen", MessageBoxButtons.OK);
                        return false;
                    }
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Termin wirklich löschen?", "Termin löschen", MessageBoxButtons.YesNo);

                    if (res != DialogResult.Yes)
                        return false;

                    PMDSBusiness1.DeletePflegeplan(IDPflegePlan);
                    return true;
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin löschen");
                    return false;
                }
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin löschen");
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
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("TERMIN_DONE"));
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
                        DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu ändern!", "Termin ändern", MessageBoxButtons.OK);
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
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin editieren");
                    return false;
                }
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin");
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
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin editieren");
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
			// Änderungen an der Abteilung werden
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
			new frmAuswahl().ShowDialog();
			return true;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzeinträge
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Zusatzeintraege() 
		{
			new frmZusatzEintrag().ShowDialog();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzeinträge Zuordnung
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
            new frmMedikamentenVerwaltung().ShowDialog(); // Neu nach 21.05.2007 MDA
			return true;
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

            //frmQuickfilter2 frmQuickfilter21 = new frmQuickfilter2();
            //frmQuickfilter21.initControl();
            //frmQuickfilter21.Show();
            //return true;

            DialogResult res = new frmManageQuickFilter().ShowDialog();
            if (res == DialogResult.OK)
            {
                //ENV.SignalQuickfilterChanged(null);
                return true;
            }
            else
                return false;
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
        /// Text verschlüsseln
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
				case SiteEvents.Massnahme:					return GuiAction.PatientMassnahme(args.IDPatient, eDekursherkunft.MassnahmenRückmeldungAusIntervention, null, "Dekurs");
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
		/// Passwort des angemeldeten Benutzers ändern
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool ChangePassword()
		{
			Benutzer ben = new Benutzer(ENV.USERID);

			frmChangePassword frm = new frmChangePassword(ben);
			if (frm.ShowDialog() != DialogResult.OK)
				return false;

			ben.Write();
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
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es ist kein Klient gewählt.\r\nBitte wählen Sie einen Klienten", "Klient nicht ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmNotfall frm = new frmNotfall(IDAufenthalt, IDStandardprozeduroderIDSP, mode);
            if(frm.ShowDialog() == DialogResult.OK)
                ENV.SignalMedizinischerStateChanged(999);
        }
      
    }
}
