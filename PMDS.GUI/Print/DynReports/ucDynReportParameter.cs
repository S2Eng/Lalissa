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
using System.Data;
using System.Windows.Forms;
using System.IO;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;
using PMDS.DB;
using PMDS.GUI.VB;
using System.Linq;
using PMDS.Global.db.ERSystem;
using S2Extensions;
using System.Data.OleDb;
using Infragistics.Documents.Excel;
using SqlKata;
using SqlKata.Compilers;

namespace PMDS.GUI
{
    public partial class ucDynReportParameter : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool _ucValueChangedInProgress = false;             // Signalisiert dass alle ucs informiert werden dass sich ein Abhängigkeitswert verändert hat
        private string _CurrentReportFile = "";                     // Speichert die aktuelle Datei
        private string _CurrentReportInfo = "";                     // Speichert die aktuelle Info zum Report
        private BerichtParameterReplaceDelegate _delegate;
        private List<PMDS.Print.CR.BerichtDatenquelle> _CurrentBerichtDatenquellen = new List<PMDS.Print.CR.BerichtDatenquelle>();  // Die DatenquellenListen (Klasse/Bereich)

        private bool SavePBSToArchiv { set; get; } = true;          //Pflegebegleitschreiben auch ins Archiv ablegen
        private bool SavePSBToArchiv { set; get; }                  //Pflegesituationsbericht auch ins Archiv ablegen
        private MemoryStream msPSB = new MemoryStream();            //ELGA Pflegesituationsbericht 

        public event EventHandler ParameterChanged;                 // Wird aufgerufen wenn Parameter verändert wurden
        public string _CurrentFormToShow = "";                      // Speichert die evtl. aufzurufende Form
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
                                        ref bool abortWindow, ref Nullable<Guid> IDEinrichtungEmpfänger, ref bool bSaveToArchiv, bool bSendToELGA, ref Nullable<Guid> IDDokumenteneintrag)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                string extension = System.IO.Path.GetExtension(ReportFile).ToLower();
                if (extension.sEquals(".pdf"))
                {
                    PMDS.Global.print.FDF fdf = new Global.print.FDF();
                    fdf.Print(ReportFile, null);
                    return;
                }
                else if (extension.sEquals(".qry"))
                {
                    //qry-File öffnen
                    //Parameter anwenden
                    //SQL ausführen und Ergebnis in Excel öffnen

                    var compiler = new SqlServerCompiler();
                    var query = new Query("Anmeldungen")
                        .Select("Vorname", "Nachname", "Benutzer", "LogInNameFrei", "LogInDatum", "LogOutDatum")
                        .WhereDate("LoginDatum", ">=", "2021-01-01")
                        .WhereDate("LoginDatum", "<=", "2022-12-31")
                        .WhereLike("Benutzer", "%");

                    //SqlKata.AbstractClause c = query.Clauses[7];

                    //var qx = new Query();
                    //SqlKata.Clause cFrom =  new SqlKata.AbstractClause();

                    //qx.Clauses.Add(cFrom);
                        //.Where("Vorname", "Sandra")
                        //.Where("Entlassen",0)
                        //.WhereDate("Aufnahmedatum", "<", DateTime.Now).Where(q => q.WhereRaw("1 = ?", 1).OrWhereTrue("RezeptgebuehrbefreiungJN").OrWhereTrue("Sozialhilfebescheid"));

                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                    OleDbConnection conn = new OleDbConnection(RBU.DataBase.CONNECTION.ConnectionString);
                    conn.Open();
                    cmd = new OleDbCommand(compiler.Compile(query).ToString(), conn);
                    OleDbDataReader r = cmd.ExecuteReader();

                    var dataTable = new DataTable();
                    dataTable.Load(r);
                    Workbook workbook1 = new Workbook();
                    Worksheet worksheet1 = workbook1.Worksheets.Add("Sheet 1");

                    for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                    {
                        worksheet1.Rows[0].Cells[columnIndex].Value = dataTable.Columns[columnIndex].ColumnName;
                    }

                    int rowIndex = 1;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        Infragistics.Documents.Excel.WorksheetRow row = worksheet1.Rows[rowIndex++];
                        for (int columnIndex = 0; columnIndex < dataRow.ItemArray.Length; columnIndex++)
                        {
                            row.Cells[columnIndex].Value = dataRow.ItemArray[columnIndex];
                        }
                    }

                    workbook1.Save("C:\\Temp\\Workbook1.xls");
                    

                    conn.Close();
                    string DefaultApp = PMDS.Global.Tools.AssocQueryString(PMDS.Global.Tools.AssocStr.ASSOCSTR_EXECUTABLE, ".xls");

                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = DefaultApp;

                    myProcess.StartInfo.Arguments = "C:\\Temp\\Workbook1.xls";
                    myProcess.Start();

                    return;
                }
                else if (!extension.sEquals(".rpt"))
                {
                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = PMDS.Global.Tools.AssocQueryString(PMDS.Global.Tools.AssocStr.ASSOCSTR_EXECUTABLE, extension);
                    myProcess.StartInfo.Arguments = ReportFile;
                    myProcess.Start();
                    return;
                }

                PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo frmPrintPflegebegleitschreibenInfo1 = null;
                // Dynamische Formularsteuerung ---------------------------------------------------------------------------------------------------
                if (!String.IsNullOrWhiteSpace(_CurrentFormToShow))
                {
                    SavePSBToArchiv = false;

                    bool ELGAAbgemeldet;
                    bool ELGASOOJN;

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
                        using (PMDS.GUI.Print.frmELGAPrintPflegesituationsbericht PSB = new PMDS.GUI.Print.frmELGAPrintPflegesituationsbericht())
                        {
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
                                if  (PSB.cbETo.Value != null) 
                                    IDEinrichtungEmpfänger = (Guid)PSB.cbETo.Value;
                                abortWindow = true;
                                return;
                            }
                        }
                    }

                    if (!SavePSBToArchiv)
                    {
                        SavePSBToArchiv = false;
                        frmPrintPflegebegleitschreibenInfo1 = new PMDS.DynReportsForms.frmPrintPflegebegleitschreibenInfo();
                        DialogResult res = frmPrintPflegebegleitschreibenInfo1.ShowDialog();
                        if (res != DialogResult.OK)
                        {
                            if (frmPrintPflegebegleitschreibenInfo1.cbETo.Value != null)
                                IDEinrichtungEmpfänger = (Guid)frmPrintPflegebegleitschreibenInfo1.cbETo.Value;
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
                    frmPrintPflegebegleitschreibenInfo1.Dispose();
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

                        Guid IDAufenthalt_current = Guid.Empty;
                        bool vabgesetzteMed = false;

                        if (lPars != null)
                        {
                            foreach (PMDS.Print.CR.BerichtParameter p in lPars)  // Alle Berichtsparameter setzten
                            {
                                if (p.Name == "IDAufenthalt_current")
                                    IDAufenthalt_current = new Guid(p.Value.ToString());

                                if (p.Name == "vabgesetzeMed")
                                    vabgesetzteMed = (bool)p.Value;
                            }
                        }
                        q.DATASET = PMDS.DynReportsForms.MedikamentenBlattDataSource.FilldsMBlatt(null, IDAufenthalt_current, !vabgesetzteMed);     //lthxy
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
                            PMDS.Print.CR.ReportManager.PrintDynamicReport(ReportFile, bPreview, lPars, _CurrentBerichtDatenquellen, "",
                                                                            ENV.DB_USER, ENV.DB_SERVER, ENV.DB_DATABASE, ENV.INTEGRATED_SECURITY, ENV.DB_PASSWORD,
                                                                            cParFormular, ref sFileNameExport, true, "", SavePBSToArchiv);
                    }

                    VB.PMDSBusinessVB bVB = new VB.PMDSBusinessVB();
                    //PMDS.db.Entities.Benutzer rUsrLoggedOn = b.LogggedOnUser();

                    var rPatInfo = (from p in db.Patient
                                    where p.ID == ENV.CurrentIDPatient
                                    select new
                                    { p.ID, Nachname = p.Nachname.Trim(), Vorname = p.Vorname.Trim() }
                                   ).FirstOrDefault();

                    Application.UseWaitCursor = false;
                    string ReportNameProt = System.IO.Path.GetFileName(ReportFile.Trim());
                    string protTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} geöffnet");
                    string protTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} wurde von Benutzer {1} geöffnet");

                    if (frmPrintPflegebegleitschreibenInfo1 != null && frmPrintPflegebegleitschreibenInfo1.SavePBSToArchive)  //Pflegebegleitschreiben in Archiv ablegen
                    {

                        if (bVB.SaveFileToArchive(sFileNameExport, 
                                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegebegleitschreiben für") + " " + rPatInfo.Nachname + " " + rPatInfo.Vorname, 
                                                    "Pflegebegleitschreiben", ref IDDokumenteneintrag))
                        {
                            if (File.Exists(sFileNameExport))
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Pflegebegleitschreiben wurde ins Archiv abgelegt!");

                                using (PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF())
                                {
                                    byte[] bPDF;
                                    if (frmPDF.OpenPDF(sFileNameExport, out bPDF))
                                    {
                                        frmPDF.ShowBookmarks = true;
                                        frmPDF.ShowOpenDialog = false;
                                        frmPDF.ShowPrintDialog = true;
                                        frmPDF.SetCaption = System.IO.Path.GetFileName(ReportFile);
                                        frmPDF.Show();
                                    }
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
                                if (ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGADokumenteSenden, true))
                                {
                                    ELGABusiness elgaBusiness = new ELGABusiness();
                                    elgaBusiness.SendELGADocu(retList[0], retList[1]);
                                }
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
                    }

                    string UserName = ENV.ActiveUser.Nachname.Trim() + " " + ENV.ActiveUser.Vorname.Trim() + " (" + ENV.ActiveUser.Benutzer1.Trim() + ")";

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
                                                Guid? IDUrlaub,
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
            if (StringToReplace.sContains("{{{IDKlient_current}}}"))
                sRet = sRet.Replace("{{{IDKlient_current}}}", ENV.CurrentIDPatient.ToString());

            if (StringToReplace.sContains("{{{IDUser_current}}}"))
                sRet = sRet.Replace("{{{IDUser_current}}}", ENV.USERID.ToString());

            if (StringToReplace.sContains("{{{IDAufenthalt_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAufenthalt_current}}}", p.Aufenthalt.ID.ToString());
            }

            if (StringToReplace.sContains("{{{IDAbteilung_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAbteilung_current}}}", p.Aufenthalt.IDAbteilung.ToString());
            }

            if (StringToReplace.sContains("{{{IDKlinik_current}}}"))
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
                        if (u.BERICHTPARAMETER.Typ.sEquals("Datum"))
                        {
                            string sTemp = "=== PARSE('" + u.VALUE_TEXT + "' AS DATE USING '" + System.Globalization.CultureInfo.CurrentCulture  + "') ===";
                            sRet = sRet.Replace(sField1, sTemp);
                            sRet = sRet.Replace("'===", "").Replace("==='", "");
                        }
                        else if (u.BERICHTPARAMETER.Typ.sEquals("DatumZeit"))
                        {

                            string sTemp = "=== PARSE('" + u.VALUE_TEXT + "' AS DATETIME USING '" + System.Globalization.CultureInfo.CurrentCulture + "') ===";
                            sRet = sRet.Replace(sField1, sTemp);
                            sRet = sRet.Replace("'===", "").Replace("==='", "");
                        }
                        else
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
            c.Height = 30;
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
            using (frmShowBerichtParameter frm = new frmShowBerichtParameter(BERICHTPARAMETER))
            {
                frm.ShowDialog();
            }
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


            using (frmEditDynReports frm = new frmEditDynReports(this.XMLFileAlternate))
            {
                frm.ShowDialog();
            }
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
