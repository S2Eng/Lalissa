using System;
using System.Windows.Forms;
using PMDS.Global;
using PMDSClient.Sitemap;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Konfigurationsmangement durchführen
	/// </summary>
	//----------------------------------------------------------------------------
	public class GuiWorkflow
	{
        public static frmMain mainWindow;

		public 	IPMDSMenuFramework	            _framework;
		//private ucSiteMap			            _Sitemap;

        public ucSiteMapTermine _SitemapTermineInterventionen = null;
        public ucSiteMapTermine _SitemapTermineÜbergabe = null;

        public ucSiteMapTermine _SitemapTermineInterventionenBereich = null;
        public ucSiteMapTermine _SitemapTermineÜbergabeBereich = null;

        public ucMain _SitemapStart;
        public ucSiteMapKlientenDetails        _SitemapKlientenDetails;
        public ucMedikamenteMainPicker _SitemapMedikamenteStammdaten;
        private ucSiteMapPflegePlan2 _SitemapPflegePlan2;
        private ucSiteMapPflegePlan2            _SiteMapWunde;
        //private ucSiteMapAssesment            _SitemapAssesment;
        private ucDatenErhebungMain _datenErhebung;
        private ucSiteMapBerichte               _SitemapBerichte;
        private ucSiteMapEvaluierung1           _SiteMapEvaluierung;
        //private ucSiteMapEvaluierung            _SiteMapEvaluierungOld;
        private PMDS.Itscont.ucArchivPlanung    _ArchivPlanung;

        public static GuiWorkflow _guiworkflow = null;
        private static string                   _LastGroupSelectd = "";

        public static eUITypeTermine _LastBereichsansicht = eUITypeTermine.Interventionen;


        public static ucHeader HeaderMain = null;






        //----------------------------------------------------------------------------
		/// <summary>
		/// Workflow initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool Init(IPMDSMenuFramework framework)
		{

            if (!frmLogin.ProcessLogin())
            {
                return false;
            }
			

            frmInfo info = new frmInfo();
            try
            {
                if (ENV.COMMANDLINE_bshowSplash)
                {
                    info.StartPosition = FormStartPosition.CenterScreen;
                    info.Show();
                }
                new GuiWorkflow(framework);
                GuiWorkflow.HeaderMain = ((frmMain)framework).ucHeader1;
                return true;
            }

            finally
            {
                info.Close();               
            }
        }

        public static bool Init( )
        {
            if (!frmLogin.ProcessLogin())
                return false;
            frmInfo info = new frmInfo();
            try
            {
                if (ENV.COMMANDLINE_bshowSplash)
                {
                    info.StartPosition = FormStartPosition.CenterScreen;
                    info.Show();
                }
                return true;
            }
            finally
            {
                info.Close();
            }
        }


        //----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor (Workflow initialisieren, Menüs einhängen)
		/// </summary>
		//----------------------------------------------------------------------------
		private GuiWorkflow(IPMDSMenuFramework framework)
		{
            ENV._InitInProgress = true;
            // _Sitemap = new ucSiteMap();
            _SitemapStart           = new ucMain();
            
            this._SitemapStart.mainWindow = GuiWorkflow.mainWindow;

            //_SitemapAssesment       = new ucSiteMapAssesment();
            //_datenErhebung          = new ucDatenErhebung();
 
			_framework	= framework;
			_guiworkflow = this;
			
			// Header initialisieren
			framework.HEADER.LEFTINFO	= "";
			framework.HEADER.MIDDLEINFO = "";
			framework.HEADER.RIGHTINFO	= "";
            //GuiWorkflow._sitem
            
			// usercontrols einhängen
			//framework.AddObject(_Sitemap);
			
            framework.AddObject(_SitemapStart);
           
            //initInterventionsliste();

            //framework.AddObject(_SitemapAssesment);
            //framework.AddObject(_datenErhebung);

			// Sitemap Feuert Events welche in SitemapPatient und PatientTermine abgefangen werden
			// ist es nun der Event dass die Controls selbst angezeigt werden sollen dann teilen die das dem Framework mit.
            //_Sitemap.SiteMapEvent += new SiteMapDelegate(_SitemapTermine.ExternSiteMapEventHandler);

            //_SitemapStart.SiteMapEvent += new SiteMapDelegate(_SitemapKlientenDetails.ExternSiteMapEventHandler);
            //_SitemapStart.SiteMapEvent += new SiteMapDelegate(_SitemapStart_SiteMapEvent);
           
            _SitemapStart.SiteMapEvent +=new SiteMapDelegate(_SitemapStart_SiteMapEvent);

            GuiWorkflow.mainWindow.panelStart.Controls.Add(this._SitemapStart);

			// Startseite angezeigen
            ENV._InitInProgress = false;
			framework.BringOnTop(_SitemapStart);
		}
        public GuiWorkflow()
        {
        }

        public void initDatenerhebung( )
        {
            if (_datenErhebung == null)
            {
                _datenErhebung = new ucDatenErhebungMain();
                GuiWorkflow.mainWindow.AddObject(_datenErhebung);
                _datenErhebung.AttachFramework();
                _datenErhebung.ucDatenErhebung1.AttachFramework();
                _datenErhebung.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner , true, false);   
            }
        }

        public void initMedikamentierungsbereich()
        {
            if (_SitemapMedikamenteStammdaten == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SitemapMedikamenteStammdaten = new ucMedikamenteMainPicker();
                _SitemapMedikamenteStammdaten.InitControl();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SitemapMedikamenteStammdaten);
                _SitemapMedikamenteStammdaten.AttachFramework();
                _SitemapMedikamenteStammdaten.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner, true, false);     
            }
        }

        public void initWunddoku()
        {
            if (_SiteMapWunde == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SiteMapWunde = new ucSiteMapPflegePlan2();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SiteMapWunde.PFLEGEPLANMODUS = PflegePlanModus.Wunde;              // Wunde ist Pflegeplan im eigenen Modus
                GuiWorkflow.mainWindow.AddObject(_SiteMapWunde);
                _SiteMapWunde.AttachFramework();
                _SiteMapWunde.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner , true, false);
            }

        }

        public void initBerichte()
        {
            if (_SitemapBerichte == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SitemapBerichte = new ucSiteMapBerichte();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SitemapBerichte);
                _SitemapBerichte.AttachFramework();
            }
        }
        public void initPflegeplanung2()
        {
            if (_SitemapPflegePlan2 == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SitemapPflegePlan2 = new ucSiteMapPflegePlan2();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SitemapPflegePlan2);
                _SitemapPflegePlan2.AttachFramework();
                _SitemapPflegePlan2.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner, true, false);
            }
        }



        public void initKlintenakt( bool neuerInitUnbedingt )
        {
            bool initdone = false;
            if (_SitemapKlientenDetails == null )
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SitemapKlientenDetails = new ucSiteMapKlientenDetails();
                _SitemapKlientenDetails.initControl();          //os-Performance (2.7)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SitemapKlientenDetails);
                _SitemapKlientenDetails.AttachFramework();
                _SitemapKlientenDetails.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner, true, false);       //os-Performance (1.3)
                initdone = true;
            }

            if (neuerInitUnbedingt && !initdone)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SitemapKlientenDetails = new ucSiteMapKlientenDetails();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SitemapKlientenDetails);
                _SitemapKlientenDetails.initControl();
                //_SitemapKlientenDetails.AttachFramework();
                //_SitemapKlientenDetails.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner);
                initdone = true;
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Handler der eine Änderung des Patienten in der Terminliste registriert
        /// </summary>
        //----------------------------------------------------------------------------
        void _SitemapTermine_PatientSelectionChanged(Guid IDPatient, Guid IDAufenthalt)
        {
            //ENV.IDAUFENTHALT = IDAufenthalt;
            ENV.setIDAUFENTHALT = IDAufenthalt;
            System.Guid idAuf = PMDS.BusinessLogic.Aufenthalt.LastByPatient(IDPatient);
            ENV.setIDAUFENTHALT = idAuf;
            ENV.setCurrentIDPatient = IDPatient;
            ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, true);
            //if (PMDS.Global.historie.HistorieOn)
            //{
            //    PMDS.Global.historie.IDAufenthalt = ucPatientPicker1.CURRENT_IDAufenhalt;
            //}
        }

        public ucHeader HEADER
        {
            get
            {
                return ((frmMain)_framework).ucHeader1;
            }
        }

        #region Einzelne Seiten in den Vordergrund
        //public static void ShowStartPage()
        //{
        //    _guiworkflow._framework.BringOnTop(_guiworkflow._Sitemap);
        //}

        public static void ShowEvaluierung()
        {
            _guiworkflow._framework.BringOnTop(_guiworkflow._SiteMapEvaluierung);   
            _LastGroupSelectd = "ShowEvaluierung";
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void ShowKlientenDetails()
        {
            GuiWorkflow._guiworkflow.initKlintenakt (false );
            _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapKlientenDetails);
            _LastGroupSelectd = "ShowKlientenDetails";
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void ShowWunde()
        {
            _guiworkflow._framework.BringOnTop(_guiworkflow._SiteMapWunde);
            _LastGroupSelectd = "ShowWunde";
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public void initArchivTerminsystem()
        {
            if (_ArchivPlanung == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _ArchivPlanung = new PMDS.Itscont.ucArchivPlanung();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_ArchivPlanung);
            }
        }
        public static void ShowArchivPlanung( bool gesamt ,bool headerEin, bool showKlientenarchiv, bool ShowTermineBereich)
        {
            _guiworkflow.initArchivTerminsystem();
            _guiworkflow._ArchivPlanung._headerEin = headerEin;
            _guiworkflow._ArchivPlanung.showKlientenarchiv = false;
            _LastGroupSelectd = "ShowArchivPlanung";
            _guiworkflow._ArchivPlanung._ShowTermineBereich = ShowTermineBereich;
            if (showKlientenarchiv)
            {
                _guiworkflow._ArchivPlanung._TypeUI = VB.contPlanungData.eTypeUI.IDKlient;
                _guiworkflow._ArchivPlanung._PlanArchive = new VB.contPlanungData.cPlanArchive();
                _guiworkflow._ArchivPlanung.showKlientenarchiv = true;
                _guiworkflow._framework.BringOnTop(_guiworkflow._ArchivPlanung);
            }
            else
            {
                if (gesamt)
                {
                    _guiworkflow._ArchivPlanung._TypeUI = VB.contPlanungData.eTypeUI.PlanKlienten;
                    _guiworkflow._ArchivPlanung._PlanArchive = new VB.contPlanungData.cPlanArchive();
                }
                else
                {
                    _guiworkflow._ArchivPlanung._TypeUI = VB.contPlanungData.eTypeUI.IDKlient;
                    _guiworkflow._ArchivPlanung._PlanArchive = new VB.contPlanungData.cPlanArchive();
                }
                _guiworkflow._framework.BringOnTop(_guiworkflow._ArchivPlanung);
            }

            if (gesamt || headerEin)
                _guiworkflow._framework.HEADER.ShowGesamtarchiv(true);
            else
                _guiworkflow._framework.HEADER.ShowControlAndHeader(true);

            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }
        //Neu nach 30.07.2007 MDA
        public static void ShowMedikamenteStammdaten()
        {
             _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapMedikamenteStammdaten);
             _LastGroupSelectd = "ShowMedikamenteStammdaten";
             GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void ShowKlienten()
        {
            _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapStart);
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void checkUserAcitvity()
        {
            if (ENV.MaxIdleTime > 0 && !ENV.IgnoreMaxIdleTime)
            {
                _guiworkflow._SitemapStart.timer2.Enabled = true;
                _guiworkflow._SitemapStart.timer2.Start();
            }
            else
            {
                _guiworkflow._SitemapStart.timer2.Stop();
            }
        }

        public static void setHistorieOnOff()
        {
            _guiworkflow._SitemapStart.setHistorieOnOff();
        }
        public static void ShowPflegePlan()
        {
           //if(ENV._USE_PP_0)
           //{
           //     _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapPflegePlan);
           //}
           //else
           // {
                _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapPflegePlan2);       //Neu nach 09.06.2008 MDA
            //}
           _LastGroupSelectd = "ShowPflegePlan";
           GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void ShowAssesment()
        {
            //_guiworkflow._framework.BringOnTop(_guiworkflow._SitemapAssesment);
            _guiworkflow._framework.BringOnTop(_guiworkflow._datenErhebung);
            _LastGroupSelectd = "ShowAssesment";
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }

        public static void ShowBerichte()
        {
            _guiworkflow._framework.BringOnTop(_guiworkflow._SitemapBerichte);
            _LastGroupSelectd = "ShowBerichte";
            GuiWorkflow.mainWindow.showInfoStatusBar(false, "", false);
        }


        public  void ShowLastGroup()
        {
            Application.DoEvents();

            if (PMDS.Global.historie.HistorieOn && (_LastGroupSelectd == "ShowTerminListe" || _LastGroupSelectd == "ShowTerminBereichsListe"))
            {
                _LastGroupSelectd = "ShowUebergabe";
            }
            
            switch (_LastGroupSelectd)
            {
                case "ShowTerminListe":
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Durchführung);
                    Application.DoEvents();
                    ShowInterventionen(true);

                    break;
                case "ShowUebergabe":
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Uebergabe);
                    Application.DoEvents();
                    ShowÜbergabe(true);
                 
                    break;
                case "ShowTerminBereichsListe":
                    ShowInterventionenBereich();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Durchführung);
                    break;
                case "ShowEvalTerminListe":
                    //Application.DoEvents();

                    //GuiWorkflow._guiworkflow.initEvaluierung();
                    //GuiWorkflow.ShowEvaluierung();

                    //ShowEvalTerminListe();
                    //HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Evaluierung);
                    string xy = "";
                    break;

                case "ShowAssesment":
                    ShowAssesment();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Anamnese);
                    break;
                case "ShowPflegePlan":
                    ShowPflegePlan();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Planung);
                    break;
                case "ShowKlientenDetails":
                    ShowKlientenDetails();                                              //os-Performance ->
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Details);       
                    break;
                case "ShowWunde":
                    ShowWunde();//ShowKlientenDetails(); //Gernot%%
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Wunde);
                    break;
                case "ShowMedikamenteStammdaten"://Neu nach 30.07.2007 MDA
                    ShowMedikamenteStammdaten();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Medikamente);
                    break;
                case "ShowBerichte":
                    ShowBerichte();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Berichte);
                    break;
                case "ShowEvaluierung":
                    ShowEvaluierung();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Evaluierung);
                    break;
                default:
                    ShowKlientenDetails();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Details);
                    break;
            }
        }
        public   void setWidthHeigtSiteMapStart(int w, int h)
        {
        }

        public void initEvaluierung()
        {
            if (_SiteMapEvaluierung == null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SiteMapEvaluierung = new ucSiteMapEvaluierung1();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                GuiWorkflow.mainWindow.AddObject(_SiteMapEvaluierung);
                _SiteMapEvaluierung.AttachFramework();
                _SiteMapEvaluierung.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient, eCurrentPatientChange.keiner, true, false);
            }
        }




        // Intervention und Übergabe - Steuerung
        public void initInterventionen(eUITypeTermine UITypeTermine, TerminlisteAnsichtsmodi TerminlisteAnsichtsmodi)
        {
            if (this._SitemapTermineInterventionen == null)
            {
                this._SitemapTermineInterventionen = new ucSiteMapTermine();
                this._SitemapTermineInterventionen.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(_SitemapTermine_PatientSelectionChanged);
                GuiWorkflow._guiworkflow._SitemapTermineInterventionen.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi);

                GuiWorkflow.mainWindow.AddObject(this._SitemapTermineInterventionen);
                this._SitemapTermineInterventionen.AttachFramework();
                //_SitemapTermine.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient);
            }
        }
        public static void ShowInterventionen(bool refreshData)
        {
            _LastGroupSelectd = "ShowTerminListe";
            GuiWorkflow._guiworkflow.initInterventionen(eUITypeTermine.Interventionen, TerminlisteAnsichtsmodi.Klientanansicht);
            if (refreshData)
            {
                GuiWorkflow._guiworkflow._SitemapTermineInterventionen.RefreshTermin(false);
            }
        }
        public void initÜbergabe(eUITypeTermine UITypeTermine, TerminlisteAnsichtsmodi TerminlisteAnsichtsmodi)
        {
            if (this._SitemapTermineÜbergabe == null)
            {
                this._SitemapTermineÜbergabe = new ucSiteMapTermine();
                this._SitemapTermineÜbergabe.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(_SitemapTermine_PatientSelectionChanged);
                GuiWorkflow._guiworkflow._SitemapTermineÜbergabe.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi);

                GuiWorkflow.mainWindow.AddObject(this._SitemapTermineÜbergabe);
                this._SitemapTermineÜbergabe.AttachFramework();
                //_SitemapTermine.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient);
                
            }
        }
        public static void ShowÜbergabe(bool refreshData)
        {
            _LastGroupSelectd = "ShowUebergabe";
            GuiWorkflow._guiworkflow.initÜbergabe(eUITypeTermine.Übergabe, TerminlisteAnsichtsmodi.Klientanansicht);
            if (refreshData)
            {
                GuiWorkflow._guiworkflow._SitemapTermineÜbergabe.RefreshTermin(false);
            }
        }
        public void initInterventionenBereich(eUITypeTermine UITypeTermine, TerminlisteAnsichtsmodi TerminlisteAnsichtsmodi)
        {
            if (this._SitemapTermineInterventionenBereich == null)
            {
                this._SitemapTermineInterventionenBereich = new ucSiteMapTermine();
                this._SitemapTermineInterventionenBereich.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(_SitemapTermine_PatientSelectionChanged);
                GuiWorkflow._guiworkflow._SitemapTermineInterventionenBereich.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi);

                GuiWorkflow.mainWindow.AddObject(this._SitemapTermineInterventionenBereich);
                this._SitemapTermineInterventionenBereich.AttachFramework();
                //_SitemapTermine.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient);
               
            }
        }
        public static void ShowInterventionenBereich()
        {
            _LastGroupSelectd = "ShowTerminBereichsListe";

            if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
            {
                GuiWorkflow._guiworkflow.initInterventionen(eUITypeTermine.Interventionen, TerminlisteAnsichtsmodi.Klientanansicht);
                GuiWorkflow._guiworkflow._SitemapTermineInterventionen.RefreshTermin(false);
            }
            else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
            {
                GuiWorkflow.HeaderMain.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, true, eTypePatientenUserPickerChanged.MainPickerLeftTop);
                GuiWorkflow.HeaderMain.contPatientUserPicker1.resetPicker(false, true);
                GuiWorkflow.HeaderMain.clearPatientInfo();
                GuiWorkflow.HeaderMain.RefreshPatientInfo(true, true, false);

                GuiWorkflow._guiworkflow.initInterventionenBereich(eUITypeTermine.Interventionen, TerminlisteAnsichtsmodi.Bereichsansicht);
                GuiWorkflow._guiworkflow._SitemapTermineInterventionenBereich.RefreshTermin(false);
                GuiWorkflow._LastBereichsansicht = eUITypeTermine.Interventionen;
            }
            else
            {
                throw new Exception("ShowInterventionenBereich: ENV.AnsichtsModus '" + ENV.AnsichtsModus.ToString() + "' not allowed!");
            }
        }
        public void initÜbergabeBereich(eUITypeTermine UITypeTermine, TerminlisteAnsichtsmodi TerminlisteAnsichtsmodi)
        {
            if (this._SitemapTermineÜbergabeBereich == null)
            {
                this._SitemapTermineÜbergabeBereich = new ucSiteMapTermine();
                this._SitemapTermineÜbergabeBereich.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(_SitemapTermine_PatientSelectionChanged);
                GuiWorkflow._guiworkflow._SitemapTermineÜbergabeBereich.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi);

                GuiWorkflow.mainWindow.AddObject(this._SitemapTermineÜbergabeBereich);
                this._SitemapTermineÜbergabeBereich.AttachFramework();
                //_SitemapTermine.ENV_ENVPatientIDChanged(ENV.CurrentIDPatient);
                
            }
        }
        public static void ShowÜbergabeBereich()
        {
            GuiWorkflow._guiworkflow.initÜbergabeBereich(eUITypeTermine.Übergabe, TerminlisteAnsichtsmodi.Bereichsansicht);
            _LastGroupSelectd = "ShowTerminListe";
            GuiWorkflow._guiworkflow._SitemapTermineÜbergabeBereich.RefreshTermin(false);
            GuiWorkflow._LastBereichsansicht = eUITypeTermine.Übergabe;
        }


        void _SitemapStart_SiteMapEvent(SiteEvents e, ref bool used)
        {
            switch (e)
            {
                case SiteEvents.Bereichsansicht:
                    if (GuiWorkflow._LastBereichsansicht == eUITypeTermine.Interventionen)
                    {
                        ucHeader.lastButtonClicked = ucHeader.HeaderButtons.Durchführung;
                        GuiWorkflow.ShowInterventionenBereich();
                        HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Durchführung);
                        break;
                    }
                    else if (GuiWorkflow._LastBereichsansicht == eUITypeTermine.Übergabe)
                    {
                        ucHeader.lastButtonClicked = ucHeader.HeaderButtons.Uebergabe;  
                        GuiWorkflow.ShowÜbergabeBereich();
                        HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Uebergabe);
                        break;
                    }
                    else
                    {
                        ucHeader.lastButtonClicked = ucHeader.HeaderButtons.Durchführung;
                        GuiWorkflow.ShowInterventionenBereich();
                        HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Durchführung);
                        break;
                    }

                case SiteEvents.KlientenDetails:
                    ucHeader.lastButtonClicked = ucHeader.HeaderButtons.Details;
                    _guiworkflow.initKlintenakt(false);
                    ENV.AnsichtsModus = TerminlisteAnsichtsmodi.Klientanansicht;
                    GuiWorkflow.ShowKlientenDetails();
                    HEADER.ProcessButton1_5((int)ucHeader.HeaderButtons.Details);
                    break;

                case SiteEvents.KlientenDetailsLastSelectedGroup:
                    ucHeader.lastButtonClicked = ucHeader.HeaderButtons.Details;
                    _guiworkflow.initKlintenakt(false);
                    ShowLastGroup();            //os-Performance ->
                    break;

            }
        }

        #endregion

    }
}
