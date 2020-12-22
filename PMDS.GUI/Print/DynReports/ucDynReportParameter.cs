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
using PMDS.Global.db.ERSystem;
using PMDSClient.Sitemap;

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

        private bool SavePBSToArchiv { set; get; } = true;          //Pflegebegleitschreiben auch ins Archiv ablegen
        private bool SavePSBToArchiv { set; get; } = false;         //Pflegesituationsbericht auch ins Archiv ablegen
        private MemoryStream msPSB = new MemoryStream();            //ELGA Pflegesituationsbericht 

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
                                        ref bool abortWindow, ref Nullable<Guid> IDEinrichtungEmpfänger, ref bool bSaveToArchiv, bool bSendToELGA, ref Nullable<Guid> IDDokumenteneintrag)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                string extension = System.IO.Path.GetExtension(ReportFile).ToLower();
                if (extension == ".pdf")
                {
                    PMDS.Global.print.FDF fdf = new Global.print.FDF();
                    fdf.Print(ReportFile, null);
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
                    SavePSBToArchiv = false;

                    bool ELGAAbgemeldet = false;
                    bool ELGASOOJN = false;

                    using (PMDS.db.Entities.ERModellPMDSEntities dbTemp = DB.PMDSBusiness.getDBContext())
                    {
                        var rKlient = (from pat in dbTemp.Patient
                                       join auf in dbTemp.Aufenthalt on pat.ID equals auf.IDPatient
                                       where auf.ID == ENV.IDAUFENTHALT
                                       select new
                                       {
                                           pat.ELGAAbgemeldet,
                                           auf.ELGASOOJN
                                       }
                                      ).First();
                        ELGAAbgemeldet = rKlient.ELGAAbgemeldet ?? false;
                        ELGASOOJN = rKlient.ELGASOOJN;
                    }

                    if ((((ENV.lic_ELGA && ENV.lic_ELGA_PSB) || PMDS.Global.db.ERSystem.PMDSBusinessUI.checkClientsS2()) && !ELGAAbgemeldet && !ELGASOOJN))  
                    {
                        PMDS.GUI.Print.frmELGAPrintPflegesituationsbericht PSB = new PMDS.GUI.Print.frmELGAPrintPflegesituationsbericht();
                        DialogResult resPSB = PSB.ShowDialog();
                        if (resPSB == DialogResult.OK)
                        {
                            msPSB = PSB.msPSB;
                            IDEinrichtungEmpfänger = (Guid)PSB.cbETo.Value;
                            SavePSBToArchiv = true;
                            SavePBSToArchiv = false;
                        }
                        else if (!PSB.ResumeWithPBS)
                        {
                            abortWindow = true;
                            return;
                        }
                    }

                    if (!SavePSBToArchiv)
                    {
                        SavePSBToArchiv = false;
                        frmPrintPflegebegleitschreibenInfo1 = new PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo();
                        DialogResult res = frmPrintPflegebegleitschreibenInfo1.ShowDialog();
                        if (res != DialogResult.OK)
                        {
                            abortWindow = true;   //Abwesenheitsprozess sofort beenden
                            return;
                        }
                        else
                        {
                            IDEinrichtungEmpfänger = (Guid)frmPrintPflegebegleitschreibenInfo1.cbETo.Value;
                            SavePBSToArchiv = frmPrintPflegebegleitschreibenInfo1.SavePBSToArchive;
                        }
                    }
                }
                
                List<PMDS.Print.CR.BerichtParameter> lPars = BERICHTPARAMETER;       // Berichtparameter können 1) von den Parametern und 2) von einer evtl. Form stammen. Diese gemeinsam den Report übergeben
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
                // Dynamische Datenquellensteuerung ---------------------------------------------------------------------------------------------------
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
                        PMDS.Print.CR.BerichtDatenquelle NewBerichtDatenquelle = new PMDS.Print.CR.BerichtDatenquelle("", cParFormular.dsFormularAssessment);
                        _CurrentBerichtDatenquellen.Add(NewBerichtDatenquelle);

                    }
                    string sFileFullNameExported = "";
                    string sFileNameExport = "";
                    if (frmPrintPflegebegleitschreibenInfo1 != null)
                    {
                        sFileNameExport = sFileFullNameExported;
                    }
                    Application.UseWaitCursor = true;
                    Application.DoEvents();

                    if (!SavePSBToArchiv)
                    {
                        if (frmPrintPflegebegleitschreibenInfo1 == null)
                            PMDS.Print.CR.ReportManager.PrintDynamicReport(ReportFile, true, lPars, _CurrentBerichtDatenquellen, "",
                                                                        ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD,
                                                                        cParFormular, ref sFileNameExport, true, "", false);
                        else
                            PMDS.Print.CR.ReportManager.PrintDynamicReport(ReportFile, !SavePBSToArchiv, lPars, _CurrentBerichtDatenquellen, "",
                                                                            ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD,
                                                                            cParFormular, ref sFileNameExport, true, "", SavePBSToArchiv);
                    }

                    VB.PMDSBusinessVB bVB = new VB.PMDSBusinessVB();
                    PMDS.db.Entities.Benutzer rUsrLoggedOn = b.LogggedOnUser();

                    var rPatInfo = (from p in db.Patient
                                    where p.ID == ENV.CurrentIDPatient
                                    select new
                                    { p.ID, p.Nachname, p.Vorname }
                                   ).FirstOrDefault();

                    Application.UseWaitCursor = false;
                    string ReportNameProt = System.IO.Path.GetFileName(ReportFile.Trim());
                    string protTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} geöffnet");
                    string protTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} wurde von Benutzer {1} geöffnet");

                    if (frmPrintPflegebegleitschreibenInfo1 != null && frmPrintPflegebegleitschreibenInfo1.SavePBSToArchive)  //Pflegebegleitschreiben in Archiv ablegen
                    {

                        if (bVB.SaveFileToArchive(sFileNameExport, 
                                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegebegleitschreiben für") + " " + rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim(), 
                                                    "Pflegebegleitschreiben", ref IDDokumenteneintrag))
                        {
                            if (File.Exists(sFileNameExport))
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
                                //File.Delete(sFileNameExport);
                                ReportNameProt = System.IO.Path.GetFileName(ReportFile.Trim());
                                protTitle = string.Format(protTitle, ReportNameProt);
                            }
                        }
                    }
                    else if (SavePSBToArchiv)    //Pflegesituationsbericht in Archiv ablegen
                    {

                        Guid? IDUrlaub = null;
                        List<Guid> retList = this.SavePSBMemStreamToArchive(msPSB, "Befunde",
                                        db, ENV.IDAUFENTHALT, rPatInfo.ID, rPatInfo.Nachname + " " + rPatInfo.Vorname, 
                                        IDUrlaub,
                                        Guid.NewGuid().ToString());

                        if (retList.Count == 2)
                        {
                            if (bSendToELGA)    //nur im Abwesenheitsworkflow
                            {
                                //PSB ins ELGA hochladen
                                ELGABusiness elgaBusiness = new ELGABusiness();
                                elgaBusiness.SendELGADocu(retList[0], retList[1]);
                            }
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Pflegesituationsbericht wurde ins Archiv abgelegt!");
                            }
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Achtung: Der Pflegesituationsbericht konnte nicht ins Archiv abgelegt werden.");
                        }
                        //string tmpPSB = "Pflegesituationsbericht";
                        //string tmpFile = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, tmpPSB + "_" + System.Guid.NewGuid().ToString() + ".xml");
                        //if (bVB.SaveFileToArchive(tmpFile,
                        //                            tmpPSB + " für " + " " + rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim(),
                        //                            "Pflegebegleitschreiben", 
                        //                            ref IDDokumenteneintrag,
                        //                            msPSB
                        //                          ))
                        //{
                        //    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                        //    string IDDokumenteintragReturn = "";
                        //    string Beschreibung = "Pflegesituatonsbericht";
                        //    bool WriteMedizinischeDaten = PMDSBusiness1.addMedizinischeDatenBefund(db, DateTime.Now, ENV.CurrentIDPatient, ref Beschreibung,
                        //                 IDDokumenteneintrag, "Pflegesituationsbericht", MedizinischerTyp.Befunde, "",
                        //                 IDDokumenteintragReturn, "", "");
                        //    db.SaveChanges();

                        //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(tmpPSB + " wurde ins Archiv abgelegt!");
                        //    if (File.Exists(tmpFile))
                        //    {
                        //        File.Delete(tmpFile);
                        //        ReportNameProt = tmpPSB;
                        //        protTitle = string.Format(tmpPSB, ReportNameProt);
                        //    }
                        //}
                    }

                    PMDS.db.Entities.Benutzer rUserLoggedIn = this.b.LogggedOnUser(db);
                    string UserName = rUserLoggedIn.Nachname.Trim() + " " + rUserLoggedIn.Vorname.Trim() + " (" + rUserLoggedIn.Benutzer1.Trim() + ")";

                    string sParms = "";
                    foreach (PMDS.Print.CR.BerichtParameter par in lPars)
                    {
                        sParms += par.Description.Trim() + ": ";
                        if (par.Value != null)
                        {
                            sParms += par.Value.ToString();
                        }
                        sParms +=  "\r\n";
                    }
                                     
                    protTxt = string.Format(protTxt, ReportNameProt, UserName);
                    protTxt +=  "\r\n" + "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Parameter") + ": " + "\r\n" + sParms;
                    this.b.saveProtocol(db, protTitle, protTxt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDynReportParameter.ProcessPreview: " + ex.ToString());
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        public List<Guid> SavePSBMemStreamToArchive(MemoryStream msPSB, string ArchivOrdner, 
                                                PMDS.db.Entities.ERModellPMDSEntities db,  
                                                Guid IDAufenthalt, 
                                                Guid IDPatient, string PatName,
                                                Nullable<Guid> IDUrlaub,
                                                string ELGAUniqueId)
        {
            try
            {

                List<Guid> retList = new List<Guid>();
                DateTime dNow = DateTime.Now;
                string PSBName = WCFServicePMDS.CDABAL.CDA.eTypeCDA.Pflegesituationsbericht.ToString();
                string sFileName = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, PSBName + "_" + System.Guid.NewGuid().ToString() + ".xml");
                msPSB.Position = 0;
                using (FileStream fs = new FileStream(sFileName, FileMode.Create))
                {
                    msPSB.CopyTo(fs);
                    fs.Flush();
                }

                Guid IDArchivOrdner;
                using (compSql comp = new compSql())
                {
                    IDArchivOrdner = comp.GetOrdnerBiografie(ArchivOrdner);  //"Befunde"
                }

                PMDSBusiness b = new PMDSBusiness();

                Guid IDDokumenteintragReturn = Guid.Empty;
                bool bDocuAdded = b.SaveDokumentinArchiv(System.IO.Path.GetFileName(sFileName), System.IO.Path.GetDirectoryName(sFileName), 
                                                            IDArchivOrdner,
                                                            PSBName, 
                                                            ".xml",
                                                            PSBName,
                                                            dNow, 
                                                            IDPatient, ref IDDokumenteintragReturn, "", true, "", ELGAUniqueId, true, 0,
                                                            IDAufenthalt, IDUrlaub);


                PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = EFEntities.newMedizinischeDaten(db);
                rMedizinischeDaten.ID = System.Guid.NewGuid();
                rMedizinischeDaten.MedizinischerTyp = 15;
                rMedizinischeDaten.IDPatient = IDPatient;
                rMedizinischeDaten.Von = dNow;
                rMedizinischeDaten.Bis = null;

                rMedizinischeDaten.Beschreibung = "";
                rMedizinischeDaten.Bemerkung = "";
                rMedizinischeDaten.Beendigungsgrund = "";
                rMedizinischeDaten.LetzteVersorgung = null;
                rMedizinischeDaten.NaechsteVersorgung = null;

                rMedizinischeDaten.Modell = "";
                rMedizinischeDaten.Handling = "";
                rMedizinischeDaten.Therapie = "";
                rMedizinischeDaten.ICDCode = "";
                rMedizinischeDaten.AufnahmediagnoseJN = false;
                rMedizinischeDaten.AntikoaguliertJN = false;
                rMedizinischeDaten.Typ = "";
                rMedizinischeDaten.Anzahl = 0;
                rMedizinischeDaten.NuechternJN = false;
                rMedizinischeDaten.Groesse = "";
                rMedizinischeDaten.IDBenutzergeaendert = ENV.USERID;

                rMedizinischeDaten.IDDocu = IDDokumenteintragReturn;
                rMedizinischeDaten.Beschreibung = PSBName;
                rMedizinischeDaten.Bemerkung = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Dokument");
                db.MedizinischeDaten.Add(rMedizinischeDaten);
                db.SaveChanges();

                string sProt2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Dokument {0} für Patient {1} wurde im Archiv abgelegt");
                sProt2 = string.Format(sProt2, PSBName, PatName);
                ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Dokument wurde im Archiv abgelegt"), null,
                                                ELGABusiness.eTypeProt.ELGADocumentSavedDB, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, IDPatient, IDAufenthalt, sProt2);

                retList.Add(IDDokumenteintragReturn);
                retList.Add(rMedizinischeDaten.ID);

                return retList;

                //PMDS.db.Entities.Aufenthalt rAufenthaltUpdate = db.Aufenthalt.Where(o => o.ID == this._IDAufenthalt).First();
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABusiness.saveMedDatenForELGADocu: " + ex.ToString());
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
