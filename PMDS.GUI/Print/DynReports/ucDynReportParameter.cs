//----------------------------------------------------------------------------
/// <summary>
/// ucDynReportParameter.cs
/// Klasse für die Verarbeitung von DynReportParametern mit Druckfunktionalität
/// inkl. der Verarbeitung der Dynamischen Formen und Datenquellen
/// 
/// Erstellt am:    20.11.2007
/// Erstellt von:   RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PMDS.Global;
using System.Runtime.Remoting;
using PMDS.Print;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;
using PMDS.DB;
using PMDS.GUI.VB;
using System.Linq;


namespace PMDS.GUI
{
    public partial class ucDynReportParameter : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool _ucValueChangedInProgress = false;             // Signalisiert dass alle ucs informiert werden dass sich ein Abhängigkeitswert verändert hat
        public string _CurrentFormToShow = "";                     // Speichert die evtl. aufzurufende Form
        private string _CurrentAssemblyForForm = "";                // Speichert die evtl. aufzurufende Assembly wo die Form zu finden ist
        private string _CurrentAssemblyForDataSources = "";         // Speichert die evtl. aufzurufende Assembly wo die Datenquellen zu finden sind
        private string _CurrentReportFile = "";                     // Speichert die aktuelle Datei
        private string _CurrentReportInfo = "";                     // Speichert die aktuelle Info zum Report

        public event EventHandler ParameterChanged;                 // Wird aufgerufen wenn Parameter verändert wurden

        private BerichtParameterReplaceDelegate _delegate;

        private List<PMDS.Print.CR.BerichtDatenquelle> _CurrentBerichtDatenquellen = new List<PMDS.Print.CR.BerichtDatenquelle>();  // Die DatenquellenListen (Klasse/Bereich)
        public string XMLFileAlternate = "";

        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        





        public ucDynReportParameter()
        {
            InitializeComponent();
            _delegate = new BerichtParameterReplaceDelegate(ParameterHelper_ReplaceString);
            ParameterHelper.ReplaceString += _delegate;
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das aktuell gewählte Reportfile
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string REPORT_FILE
        {
            get
            {
                return _CurrentReportFile;
            }
            set
            {
                _CurrentReportFile = value;
                RefreshParameters();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert auf basis des Reportdateinamens den Namen der XML Datei zum Report
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string XMLFILE
        {
            get
            {
                if (this.XMLFileAlternate.Trim () == "")
                    return Path.Combine(ENV.ReportConfigPath, Path.GetFileNameWithoutExtension(REPORT_FILE) + ".config");     //<120118>
                else
                    return Path.Combine(ENV.ReportConfigPath, this.XMLFileAlternate);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert auf basis des Reportdateinamens den Namen der JPG Datei zum Report
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string JPGFILE
        {
            get
            {
                return Path.Combine(ENV.ReportPath, Path.GetFileNameWithoutExtension(REPORT_FILE) + ".JPG");    //<120118>
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert auf basis des Reportdateinamens den Namen der JPG Datei zum Report
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string REPORTINFO
        {
            get
            {
                return _CurrentReportInfo;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Voransicht anstoßen auf basis des aktuellen Reportfiles
        /// </summary>
        //----------------------------------------------------------------------------

        public void ProcessPreview(bool bPreview, string ReportFile, PMDS.db.Entities.ERModellPMDSEntities db, 
                                        ref bool abortWindow, ref Nullable<Guid> IDEinrichtungEmpfänger, ref bool bSaveToArchiv, ref Nullable<Guid> IDDokumenteneintrag)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                string extension = System.IO.Path.GetExtension(ReportFile).ToLower();
                if (extension == ".pdf")
                {
                    PMDS.Global.print.FDF fdf = new Global.print.FDF();
                    fdf.Print(ReportFile, null);

                    //os: 180615: FDF-Print in eingene Funktion ausgelagert (wird für VO-Schein auch benötigt)
                    //PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
                    //byte[] bPDF;
                    //if (frmPDF.OpenPDF(ReportFile, out bPDF))
                    //{
                    //    frmPDF.ShowBookmarks = true;
                    //    frmPDF.ShowOpenDialog = false;
                    //    frmPDF.ShowPrintDialog = true;
                        
                    //    if (ENV.CurrentIDPatient != Guid.Empty)
                    //    {
                    //        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    //        {
                    //            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                    //            PMDS.db.Entities.Patient p = new PMDS.db.Entities.Patient();
                    //            p = PMDSBusiness1.getPatient(ENV.CurrentIDPatient, db);

                    //            if (p.Vorname != null) frmPDF.SetValue("#KLIENTVORNAME#", p.Vorname);
                    //            if (p.Nachname != null) frmPDF.SetValue("#KLIENTNACHNAME#", p.Nachname);
                    //            if ((p.Vorname != null) && (p.Nachname != null)) frmPDF.SetValue("#KLIENT#", p.Nachname + " "+ p.Vorname );
                    //            if (p.Anrede != null) frmPDF.SetValue("#KLIENTANREDE#", p.Anrede);

                    //            if (p.Geburtsdatum != null) frmPDF.SetValue("#KLIENTGEBDAT#", System.Convert.ToDateTime(p.Geburtsdatum).ToShortDateString());
                    //            if (p.SterbeDatum != null)  frmPDF.SetValue("#KLIENTSTERBEDATUM#", System.Convert.ToDateTime(p.SterbeDatum).ToShortDateString());
                    //            frmPDF.SetValue("#KLIENTVERSTORBEN#", (p.Verstorben == true) ? "J" : "N");
                    //            if (p.Klientennummer != null) frmPDF.SetValue("#KLIENTNUMMER#", p.Klientennummer);
                    //            if (p.Titel != null) frmPDF.SetValue("#KLIENTTITEL#", p.Titel);
                    //            if (p.Kosename != null) frmPDF.SetValue("#KLIENTKOSENAME#", p.Kosename);

                    //            if (p.Sexus != null) frmPDF.SetValue("#KLIENTGESCHLECHT#", p.Sexus);
                    //            if (p.Familienstand != null) frmPDF.SetValue("#KLIENTFAMILIENSTAND#", p.Familienstand);
                    //            if (p.Staatsb != null) frmPDF.SetValue("#KLIENTSTAATSBUERGERSCHAFT#", p.Staatsb);
                    //            if (p.Klasse != null) frmPDF.SetValue("#KLIENTVERSICHERUNGKLASSE#", p.Klasse);
                    //            if (p.KrankenKasse != null) frmPDF.SetValue("#KLIENTKRANKENKASSE#", p.KrankenKasse);
                    //            if (p.BlutGruppe != null) frmPDF.SetValue("#KLIENTBLUTGRUPPE#", p.BlutGruppe);
                    //            if (p.Resusfaktor != null) frmPDF.SetValue("#KLIENTRHESUSFAKTOR#", p.Resusfaktor);
                    //            if (p.LedigerName != null) frmPDF.SetValue("#KLIENTLEDIGERNAME#", p.LedigerName);
                    //            if (p.Geburtsort != null) frmPDF.SetValue("#KLIENTGEBORT#", p.Geburtsort);
                    //            if (p.VersicherungsNr != null) frmPDF.SetValue("#KLIENTSVNR#", p.VersicherungsNr);
                    //            if (p.Privatversicherung != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNG#", p.Privatversicherung);
                    //            if (p.PrivPolNr != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNGPOLNR#", p.PrivPolNr);

                    //            if (p.ErlernterBeruf != null) frmPDF.SetValue("#KLIENTERLERNTERBERUF#", p.ErlernterBeruf);
                    //            if (p.Besonderheit != null) frmPDF.SetValue("#KLIENTBESONDERHEIT#", p.Besonderheit);
                    //            if (p.SterbeRegel != null) frmPDF.SetValue("#KLIENTSTERBEREGELUNG#", p.SterbeRegel);
                    //            frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAG#", (p.PflegegeldantragJN == true) ? "J" : "N");
                    //            if (p.DatumPflegegeldantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPflegegeldantrag).ToShortDateString());
                    //            frmPDF.SetValue("#KLIENTPENSIONSTEILUNGSANTRAG#", (p.PensionsteilungsantragJN == true) ? "J" : "N");
                    //            if (p.DatumPensionsteilungsantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPensionsteilungsantrag).ToShortDateString());
                    //            if (p.Konfision != null) frmPDF.SetValue("#KLIENTKONFESSION#", p.Konfision);
                    //            frmPDF.SetValue("#KLIENTANATOMIE#", (p.Anatomie == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTDNR#", (p.DNR == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTPALLIATIV#", (p.Palliativ == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTHOLOCAUST#", (p.KZUeberlebender == true) ? "J" : "N");
                    //            if (p.PatientenverfuegungJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNG#", (p.PatientenverfuegungJN == true) ? "J" : "N");
                    //            if (p.PatientenverfuegungBeachtlichJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGBEACHTLICH#", (p.PatientenverfuegungBeachtlichJN == true) ? "J" : "N");
                    //            if (p.PatientverfuegungDatum != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGDATUM#", System.Convert.ToDateTime(p.PatientverfuegungDatum).ToShortDateString());
                    //            if (p.PatientverfuegungAnmerkung != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGANMERKUNG#", p.PatientverfuegungAnmerkung);

                    //            frmPDF.SetValue("#KLIENTMILIEUBETREUUNG#", (p.Milieubetreuung == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTDATENSCHUTZ#", (p.Datenschutz == true) ? "J" : "N");
                    //            if (p.lstSprachen != null) frmPDF.SetValue("#KLIENTSPRACHEN#", p.lstSprachen);

                    //            if (p.Haarfarbe != null) frmPDF.SetValue("#KLIENTHAARFARBE#", p.Haarfarbe);
                    //            if (p.Augenfarbe != null) frmPDF.SetValue("#KLIENTAUGENFARBE#", p.Augenfarbe);
                    //            if (p.Groesse != null) frmPDF.SetValue("#KLIENTGROESSE#", p.Groesse.ToString());
                    //            if (p.Statur != null) frmPDF.SetValue("#KLIENTSTATUR#", p.Statur.ToString());

                    //            if (p.Amputation_Prozent != null) frmPDF.SetValue("#KLIENTAMPUTATIONPROZENT#", p.Amputation_Prozent.ToString());
                    //            if (p.Kennwort != null) frmPDF.SetValue("#KLIENTKENNWORT#", p.Kennwort);

                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNG#", (p.RezeptgebuehrbefreiungJN == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGO#", (p.RezGebBef_RegoJN == true) ? "J" : "N");
                    //            if (p.RezGebBef_RegoAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOAB#", System.Convert.ToDateTime(p.RezGebBef_RegoAb).ToShortDateString());
                    //            if (p.RezGebBef_RegoBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOBIS#", System.Convert.ToDateTime(p.RezGebBef_RegoBis).ToShortDateString());
                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTET#", (p.RezGebBef_BefristetJN == true) ? "J" : "N");
                    //            if (p.RezGebBef_BefristetAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETAB#", System.Convert.ToDateTime(p.RezGebBef_BefristetAb).ToShortDateString());
                    //            if (p.RezGebBef_BefristetBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETBIS#", System.Convert.ToDateTime(p.RezGebBef_BefristetBis).ToShortDateString());
                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGUNBEFRISTET#", (p.RezGebBef_UnbefristetJN == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUF#", (p.RezGebBef_WiderrufJN == true) ? "J" : "N");
                    //            if (p.RezGebBef_WiderrufGrund != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUFGRUND#", p.RezGebBef_WiderrufGrund);
                    //            frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGSACHWALTER#", (p.RezGebBef_SachwalterJN == true) ? "J" : "N");

                    //            if (p.Betreuungsstufe != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFE#", p.Betreuungsstufe);
                    //            if (p.BetreuungsstufeAb != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEAB#", System.Convert.ToDateTime(p.BetreuungsstufeAb).ToShortDateString());
                    //            if (p.BetreuungsstufeBis != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEBIS#", System.Convert.ToDateTime(p.BetreuungsstufeBis).ToShortDateString());
                    //            frmPDF.SetValue("#KLIENTSOZIALCARD#", (p.Sozialcard == true) ? "J" : "N");
                    //            frmPDF.SetValue("#KLIENTBEHINDERTENAUSWEIS#", (p.Behindertenausweis == true) ? "J" : "N");

                    //            Patient pat = new Patient(ENV.CurrentIDPatient);
                    //            if (pat.Aufenthalt.ID != null)
                    //            {
                    //                PMDS.db.Entities.Aufenthalt a = new PMDS.db.Entities.Aufenthalt();
                    //                a = PMDSBusiness1.getAufenthalt((Guid)pat.Aufenthalt.ID, db);
                    //                if (a.Aufnahmezeitpunkt != null) frmPDF.SetValue("#AUFENTHALTAUFNAHMEDATUM#", Convert.ToDateTime(a.Aufnahmezeitpunkt).ToShortDateString());
                    //                if (a.Fallnummer != null) frmPDF.SetValue("#AUFENTHALTFALLNUMMER#", a.Fallnummer.ToString());
                    //                if (a.Gruppenkennzahl != null) frmPDF.SetValue("#AUFENTHALTGRUPPENKENNZAHL#", a.Gruppenkennzahl);
                    //                if (a.Postregelung != null) frmPDF.SetValue("#AUFENTHALTPOSTREGELUNG#", a.Postregelung);
                    //            }

                    //            if (pat.Aufenthalt.IDKlinik != null)
                    //            {
                    //                PMDS.db.Entities.Klinik kli = new PMDS.db.Entities.Klinik();
                    //                kli = PMDSBusiness1.getKlinik(pat.Aufenthalt.IDKlinik, db);
                    //                if (kli.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTEEINRICHTUNG#", kli.Bezeichnung);
                    //            }

                    //            if (pat.Aufenthalt.IDAbteilung != null)
                    //            {
                    //                PMDS.db.Entities.Abteilung abt = new PMDS.db.Entities.Abteilung();
                    //                abt = PMDSBusiness1.getAbteilung(pat.Aufenthalt.IDAbteilung, db);
                    //                if (abt.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTABTEILUNG#", abt.Bezeichnung);
                    //            }

                    //            if (pat.Aufenthalt.IDBereich != null)
                    //            {
                    //                PMDS.db.Entities.Bereich ber = new PMDS.db.Entities.Bereich();
                    //                ber = PMDSBusiness1.getBereich(pat.Aufenthalt.IDBereich, db);
                    //                if (ber.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTBEREICH#", ber.Bezeichnung);
                    //            }
                    //        }
                    //    }

                    //    frmPDF.SetCaption = System.IO.Path.GetFileNameWithoutExtension(ReportFile);
                    //    frmPDF.Show();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei nicht gefunden."));
                    //}
                    return;
                }
                else if (extension != ".rpt")
                {
                    string DefaultApp = PMDS.Global.Tools.AssocQueryString(PMDS.Global.Tools.AssocStr.ASSOCSTR_EXECUTABLE, extension);

                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = DefaultApp;

                    myProcess.StartInfo.Arguments = ReportFile;
                    myProcess.Start();
                    return;
                }

                PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo frmPrintPflegebegleitschreibenInfo1 = null;
                // Dynamische Formularsteuerung ---------------------------------------------------------------------------------------------------
                if (_CurrentFormToShow != "")
                {
                    frmPrintPflegebegleitschreibenInfo1 = new PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo();
                    frmPrintPflegebegleitschreibenInfo1.saveToArchive = bSaveToArchiv;
                    //if (ENV.StartupTyp == "auswpep")
                    //{
                        frmPrintPflegebegleitschreibenInfo1.btnSaveToArchive.Visible = false;
                    //}
                    DialogResult res = frmPrintPflegebegleitschreibenInfo1.ShowDialog();
                    if (res != DialogResult.OK)
                    {
                        abortWindow = true;
                        return;
                    }
                    else
                    {
                        IDEinrichtungEmpfänger = (Guid)frmPrintPflegebegleitschreibenInfo1.cbETo.Value;
                    }
                }
                
                List<PMDS.Print.CR.BerichtParameter> lPars = BERICHTPARAMETER;                        // Berichtparameter können 1) von den Parametern und 2) von einer evtl. Form stammen. Diese gemeinsam den Report übergeben
                if (frmPrintPflegebegleitschreibenInfo1 != null)
                {
                    foreach (PMDS.Print.CR.BerichtParameter p in frmPrintPflegebegleitschreibenInfo1.GetBERICHTPARAMETER())
                    {
                        lPars.Add(p);
                    }
                }

                bool IsFormularBericht = false;
                PMDS.GUI.Datenerhebung.cAssessement cAssessement1 = new Datenerhebung.cAssessement();
                if (cAssessement1.checkNameParameter(ref lPars, ReportFile, "CheckFormulare"))
                {
                    IsFormularBericht = true;
                }
                // DynamischeDatenquellensteuerung ---------------------------------------------------------------------------------------------------
                if (_CurrentBerichtDatenquellen.Count > 0 && !IsFormularBericht)
                {
                    foreach (PMDS.Print.CR.BerichtDatenquelle q in _CurrentBerichtDatenquellen)
                    {
                        q.DATASET = PMDS.DynReportsForms.MedikamentenBlattDataSource.FilldsMBlatt(null, Guid.Empty, false);     //lthxy

                    }
                }

                if (ENV.StartupTyp == "auswpep")
                {
                    string sFileFullNameExported = "";
                    PMDS.Print.CR.ReportManager.PrintDynamicReport(ReportFile, bPreview, lPars, _CurrentBerichtDatenquellen, "",
                                                               ENV.DB_USER_PEP, ENV.DB_SERVER_PEP, ENV.DB_DATABASE_PEP, ENV.INTEGRATED_SECURITY_PEP, ENV.DB_PASSWORD_PEP, null, ref sFileFullNameExported);
                }
                else
                {
                    PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular = new PMDS.Global.db.ERSystem.UISitemaps.cParFormular();
                    if (IsFormularBericht)
                    {
                        cParFormular = cAssessement1.doReport(ref lPars, ReportFile);
                        Print.CR.BerichtDatenquelle NewBerichtDatenquelle = new Print.CR.BerichtDatenquelle("", cParFormular.dsFormularAssessment);
                        _CurrentBerichtDatenquellen.Add(NewBerichtDatenquelle);

                    }
                    string sFileFullNameExported = "";
                    string sFileNameExport = "";
                    if (frmPrintPflegebegleitschreibenInfo1 != null)
                    {
                        frmPrintPflegebegleitschreibenInfo1.saveToArchive = bSaveToArchiv;
                        sFileNameExport = sFileFullNameExported;
                    }
                    PMDS.Print.CR.ReportManager.PrintDynamicReport(ReportFile, !bSaveToArchiv, lPars, _CurrentBerichtDatenquellen, "",
                                                                    ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD, 
                                                                    cParFormular, ref sFileNameExport, true, "", bSaveToArchiv);

                    if (bSaveToArchiv && frmPrintPflegebegleitschreibenInfo1 != null)
                    {
                        VB.PMDSBusinessVB bVB = new VB.PMDSBusinessVB();
                        PMDS.db.Entities.Benutzer rUsrLoggedOn = b.LogggedOnUser();

                        //os191224
                        var rPatInfo = (from p in db.Patient
                                        where p.ID == ENV.CurrentIDPatient
                                        select new
                                        { p.Nachname, p.Vorname }
                                       ).First();
                        //PMDS.db.Entities.Patient rPatient = b.getPatient(ENV.CurrentIDPatient, db);
                        if (bVB.SaveFileToArchive(sFileNameExport, 
                                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegebegleitschreiben für") + " " + rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim(), 
                                                    "Pflegebegleitschreiben", ref IDDokumenteneintrag))
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Pflegebegleitschreiben wurde ins Archiv abgelegt!");

                            PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
                            byte[] bPDF;
                            if (frmPDF.OpenPDF(sFileNameExport, out bPDF))
                            {
                                frmPDF.ShowBookmarks = true;
                                frmPDF.ShowOpenDialog = false;
                                frmPDF.ShowPrintDialog = true;
                                frmPDF.SetCaption = System.IO.Path.GetFileNameWithoutExtension(ReportFile);
                                frmPDF.Show();
                            }
                        }
                    }

                    PMDS.db.Entities.Benutzer rUserLoggedIn = this.b.LogggedOnUser(db);
                    string ReportNameProt = System.IO.Path.GetFileName(ReportFile.Trim()); 
                    string UserName = rUserLoggedIn.Nachname.Trim() + " " + rUserLoggedIn.Vorname.Trim() + " (" + rUserLoggedIn.Benutzer1.Trim() + ")"; ;

                    string sParms = "";
                    foreach (Print.CR.BerichtParameter par in lPars)
                    {
                        sParms += par.Description.Trim() + ": ";
                        if (par.Value != null)
                        {
                            sParms += par.Value.ToString();
                        }
                        sParms +=  "\r\n";
                    }

                    string protTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} geöffnet");
                    protTitle = string.Format(protTitle, ReportNameProt);
                    string protTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} wurde von Benutzer {1} geöffnet");
                    protTxt = string.Format(protTxt, ReportNameProt, UserName);
                    protTxt +=  "\r\n" + "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Parameter") + ": " + "\r\n" + sParms;
                    this.b.saveProtocol(db, protTitle, protTxt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDynReportParameter.ProcessPreview: " + ex.ToString());
            }
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine Platzhalterersetzung wird von irgendjemanden angefordert
        /// </summary>
        //----------------------------------------------------------------------------
        public string ParameterHelper_ReplaceString(string StringToReplace)
        {
            string sRet = StringToReplace;

            // Vordefinierte Werte ersetzen
            if (StringToReplace.Contains("{{{IDKlient_current}}}"))
                sRet = sRet.Replace("{{{IDKlient_current}}}", ENV.CurrentIDPatient.ToString());

            if (StringToReplace.Contains("{{{IDUser_current}}}"))
                sRet = sRet.Replace("{{{IDUser_current}}}", ENV.USERID.ToString());

            if (StringToReplace.Contains("{{{IDAufenthalt_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAufenthalt_current}}}", p.Aufenthalt.ID.ToString());
            }

            if (StringToReplace.Contains("{{{IDAbteilung_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAbteilung_current}}}", p.Aufenthalt.IDAbteilung.ToString());
            }

            if (StringToReplace.Contains("{{{IDKlinik_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDKlinik_current}}}", p.Aufenthalt.IDKlinik.ToString());
            }

            // Alle Parameter iterieren
            foreach (IBerichtParameterGUI u in this.pnlParameter.Controls)
            {
                string sField = "{{{" + string.Format("{0}.Wert", u.BERICHTPARAMETER.Name) + "}}}";
                string sField1 = "{{{" + string.Format("{0}.Text", u.BERICHTPARAMETER.Name) + "}}}";
                if (StringToReplace.Contains(sField))
                {
                    try
                    {
                        sRet = sRet.Replace(sField, u.VALUE.ToString());
                    }
                    catch (Exception ex)
                    {
                        string sMsgTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der erforderliche Berichtsparameter '{0}' hat einen ungültigen Wert!\n\rBitte geben Sie einen gültigen Wert ein.");
                        sMsgTxt = string.Format(sMsgTxt, u.BERICHTPARAMETER.Name);
                        System.Windows.Forms.MessageBox.Show(sMsgTxt);
                    }
                }

                if (StringToReplace.Contains(sField1))
                {
                    try
                    {
                        sRet = sRet.Replace(sField1, u.VALUE_TEXT);
                    }
                    catch (Exception ex)
                    {
                        string sMsgTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der erforderliche Berichtsparameter '{0}' hat einen ungültigen Wert!\n\rBitte geben Sie einen gültigen Wert ein.");
                        sMsgTxt = string.Format(sMsgTxt, u.BERICHTPARAMETER.Name);
                        System.Windows.Forms.MessageBox.Show(sMsgTxt);
                    }
                }
            }
            return sRet;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die auszuwählenden Parameter aktualisieren / Image aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshParameters()
        {
            pnlParameter.Visible = false;
            try
            {
                _CurrentFormToShow = "";
                _CurrentAssemblyForForm = "";
                _CurrentAssemblyForDataSources = "";
                _CurrentReportInfo = "";
                _CurrentBerichtDatenquellen.Clear();
                pnlParameter.Controls.Clear();

                if (REPORT_FILE.Trim().Length == 0)
                    return;

                if (!File.Exists(XMLFILE))
                    return;

                DynReportDefinition def = new DynReportDefinition("");
                def.LoadFromConfig(XMLFILE);
                _CurrentReportInfo              = def.Reportinfo;
                _CurrentFormToShow              = def.FormToLoad;
                _CurrentAssemblyForForm         = def.FormAssembly;             // Dynamische Form
                _CurrentAssemblyForDataSources  = def.DatasetAssemly;
                _CurrentBerichtDatenquellen     = def.DataSources;              // Dynamische Datenquellen

                IBerichtParameterGUI uc = null;
                ucParameterDate ucd = null;
                foreach (PMDS.Print.CR.BerichtParameter p in def.PARAMTERS)
                {
                    switch (p.Typ)
                    {
                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text:
                            uc = new ucParameterText(false);
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Datum:
                            ucd = new ucParameterDate();
                            ucd.TYP = ucParameterDate.typ.Date;
                            uc = ucd;
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.DatumZeit:
                            ucd = new ucParameterDate();
                            ucd.TYP = ucParameterDate.typ.DateTime;
                            uc = ucd;
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Zeit:
                            ucd = new ucParameterDate();
                            ucd.TYP = ucParameterDate.typ.Time;
                            uc = ucd;
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Zahl:
                            uc = new ucParameterZahl();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean:
                            uc = new ucParameterBool(false);
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.ThreeStateCheckbox:
                            uc = new ucParameterBool(true);
                            break;


                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Klient:
                            uc = new ucParameterKlient();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Abteilung:
                            uc = new ucParameterAbteilung();
                            break;
                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.ASZMListe:
                            uc = new ucParameterASZM();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Bereich:
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Auswahlliste:
                            uc = new ucParameterAuswahlliste();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Benutzer:
                            uc = new ucParameterBenutzer();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.SQL_GUID:
                            uc = new ucParameterSQL_GUID();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.SQL_GUID_NO_EMPTY:
                            uc = new ucParameterSQL_GUID_NO_EMPTY();
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.TextHidden:
                            uc = new ucParameterText(true);
                            break;

                        default:
                            break;
                    }

                    if (uc == null)
                        continue;

                    uc.BERICHTPARAMETER = p;
                    uc.ValueChanged += new EventHandler(uc_ValueChanged);
                    AddUserControl(uc);
                    uc = null;
                }
            }
            finally
            {
                pnlParameter.Visible = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wird aufgerufen wenn sich im Parametercontrol ein Wert geändert hat
        /// Es werden alle der Reihenfolge nach informiert dass die sich gemäß
        /// der Abhängigkeit ändern sollen.
        /// Sinnvollerweise müssen Abhängigkeiten imm hintereinander gestaltet werden
        /// </summary>
        //----------------------------------------------------------------------------
        void uc_ValueChanged(object sender, EventArgs e)
        {
            if (_ucValueChangedInProgress)          // um zyklen zu vermeiden
                return;
            _ucValueChangedInProgress = true;
            try
            {
                foreach (IBerichtParameterGUI u in this.pnlParameter.Controls)
                {
                    if (u.Equals(sender))                                                           // denselben nicht nochmal informieren
                        continue;

                    u.AnotherValueChanged(((IBerichtParameterGUI)sender).BERICHTPARAMETER);        // Alle andern informieren 
                }
            }
            finally
            {
                _ucValueChangedInProgress = false;  // rücksetzen
            }
        }

        private void AddUserControl(IBerichtParameterGUI uc)
        {
            Control c = (Control)uc;
            pnlParameter.Controls.Add(c);
            c.Dock = DockStyle.Top;
            c.BringToFront();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Berichtsparameter inkl. den zugehörigen Value
        /// jedem Berichtsparameter wird ein _txt Parameter angehängt
        /// </summary>
        //----------------------------------------------------------------------------
        public List<PMDS.Print.CR.BerichtParameter> BERICHTPARAMETER
        {
            get
            {
                List<PMDS.Print.CR.BerichtParameter> l = new List<PMDS.Print.CR.BerichtParameter>();
                foreach (IBerichtParameterGUI u in this.pnlParameter.Controls)
                {
                    PMDS.Print.CR.BerichtParameter a = u.BERICHTPARAMETER;
                    if (u.GetType().Name == "ucParameterAuswahlliste" && ENV.StartupTyp == "auswpep")
                    {
                        a.Value = (object) ((ucParameterAuswahlliste)u).VALUE_PEP;
                    }
                    else
                    {
                        if (a.Typ == PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Datum)
                        {
                            if (u.VALUE == null || (System.DateTime)u.VALUE == System.DateTime.MinValue)
                            {
                                a.Value = DateTime.MinValue;
                            }
                            else
                            {
                                a.Value = u.VALUE;
                            }
                        }
                        else
                            a.Value = u.VALUE;

                    }

                    l.Add(a);
                    // ein _txt als Parameter anhängen
                    PMDS.Print.CR.BerichtParameter bn = new PMDS.Print.CR.BerichtParameter(a.Description, a.Typ, a.Name + "_txt", a.Default);

                    if (a.Default != "LEER" && u.VALUE != null)
                        bn.Value = u.VALUE_TEXT;
                    else
                        bn.Value = "";
                    l.Add(bn);
                }

                // Aktuell angemeldeter Benutzer        // für spätere Verwendung reserviert
                PMDS.Print.CR.BerichtParameter bnu = new PMDS.Print.CR.BerichtParameter("Aktueller User", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDUser_current", "");
                bnu.Value = "{" + ENV.USERID + "}";
                l.Add(bnu);

                // Aktuell gewählter Patient
                PMDS.Print.CR.BerichtParameter bnp = new PMDS.Print.CR.BerichtParameter("Aktueller Patient", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDKlient_current", "");
                bnp.Value = "{" + ENV.CurrentIDPatient + "}";
                l.Add(bnp);


                if (ENV.CurrentIDPatient != Guid.Empty)
                {
                    Patient p = new Patient(ENV.CurrentIDPatient);
                    // Aktuell gewählter Aufenthalt zum Patient
                    PMDS.Print.CR.BerichtParameter bna = new PMDS.Print.CR.BerichtParameter("Aktueller Aufenthalt", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDAufenthalt_current", "");
                    bna.Value = "{" + p.Aufenthalt.ID + "}";
                    l.Add(bna);

                    //<20120127>
                    //Aktuelle Klinik
                    PMDS.Print.CR.BerichtParameter bnkli = new PMDS.Print.CR.BerichtParameter("Aktuelle Klinik", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDKlinik_current", "");
                    bnkli.Value = "{" + p.Aufenthalt.IDKlinik + "}"; 
                    l.Add(bnkli);

                    // Aktuelle Abteilung
                    PMDS.Print.CR.BerichtParameter bnabt = new PMDS.Print.CR.BerichtParameter("Aktuelle Abteilung", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDAbteilung_current", "");
                    bnabt.Value = "{" + p.Aufenthalt.IDAbteilung + "}";  
                    l.Add(bnabt);

                    // Aktueller Bereich
                    PMDS.Print.CR.BerichtParameter bnber = new PMDS.Print.CR.BerichtParameter("Aktueller Bereich", PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, "IDBereich_current", "");
                    bnber.Value = "{" + p.Aufenthalt.IDBereich + "}"; 
                    l.Add(bnber);
                }

                return l;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Parameter anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void mnuShowParameter_Click(object sender, EventArgs e)
        {
            frmShowBerichtParameter frm = new frmShowBerichtParameter(BERICHTPARAMETER);
            frm.ShowDialog();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Parameter bearbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        private void konfigurationBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.REPORT_FILE.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keinen Bericht ausgewählt");
                return;
            }


            frmEditDynReports frm = new frmEditDynReports(this.XMLFileAlternate);
            frm.ShowDialog();
            RefreshParameters();
            SignalParameterChanged();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Parameteränderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void SignalParameterChanged()
        {
            if (ParameterChanged != null)
                ParameterChanged(this, EventArgs.Empty);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Entfernt das Replacerdelegate aus der Liste
        /// </summary>
        //----------------------------------------------------------------------------
        public void RemoveReplacerDelegate()
        {
            if (_delegate == null)
                return;

            ParameterHelper.ReplaceString -= _delegate;
        }

        private void pnlParameter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlParameter_VisibleChanged(object sender, EventArgs e)
        {
             this.pnlParameter .ContextMenuStrip = contextMenuStripParReport;

        }

    }
}
