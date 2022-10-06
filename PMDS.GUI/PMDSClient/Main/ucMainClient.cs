using System;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Patient;
using PMDS.DB;
using PMDS.GUI.Messenger;


namespace PMDS.GUI.PMDSClient
{

    public delegate void AttachedDelegate(bool bAttached);

    public partial class ucMainClient : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {
        private bool _FrameworkAttached = false;
        private bool _LoadInProgress = true;

        public frmMain mainWindow;
        public bool _showFirst = true;
        public PMDS.DB.DBKlinik _DBKlinik = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
        public PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
        public frmMessenger frmMessenger1 = null;
        public bool bcheckIPCCallToClientDone = false;

        public event SiteMapDelegate SiteMapEvent;

        public ucMainClient()
        {
            InitializeComponent();

            this._DBKlinik = new PMDS.DB.DBKlinik();

            this.setButtonsAktivDeaktiv(SiteEvents.NONE);
            this.panelButtonleisteUnten.Visible = false;
            this.btnKlient.Visible = false;
            btnBereich.Visible = false;
            this.btnDokumenteBenutzer.Visible = false;
            this.btnDokumenteBenutzer.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Oeffnen, QS2.Resources.getRes.ePicTyp.ico);
            this.btnKliententermineArchive.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_AlleTermine, QS2.Resources.getRes.ePicTyp.ico);
            this.btnKliententermineArchive.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_MeineTermine, QS2.Resources.getRes.ePicTyp.ico);
            this.btnMessages.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, QS2.Resources.getRes.ePicTyp.ico);

            GuiAction.GuiActionDone += new GuiActionDoneDelegate(GuiAction_GuiActionDone);

            //Neu nach 03.07.2007 MDA
            ENV.ENVPatientDatenChanged += new ENVPatientDatenChangedDelegate(ENV_ENVPatientDatenChanged);

            pflegerCombo1.Value = ENV.USERID; //{{{eng}}} 04.10.2007
            pflegerCombo1.Enabled = false;    //{{{eng}}} 04.10.2007

            pflegerCombo1.Visible = ENV.BezugspersonenJN;
            BezugspersonfilterONOFF.Visible = ENV.BezugspersonenJN;

            if (ENV.HasRight(UserRights.NurBezugspflege) && !ENV.adminSecure)
            {
                BezugspersonfilterONOFF.Visible = true;
                BezugspersonfilterONOFF.Checked = true;
                BezugspersonfilterONOFF.Enabled = false;
                pflegerCombo1.Visible = true;
                pflegerCombo1.Enabled = false;
            }

            this.setRightButtonleisteUnten();

            this.ucPatientPicker1.isStartGrid = true;
            //this.ucPatientGroup1.mainWindow = this;   //lthNew

            this.btnReports.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);
            PMDS.Global.UIGlobal.setUIButton(this.btnReports, false);

            this.btnBereich.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenliste.ico_Bereichsuebersicht, QS2.Resources.getRes.ePicTyp.ico);
            PMDS.Global.UIGlobal.setUIButton(this.btnBereich, false);

            this.btnAufnahmexyxy.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_ArchivTerminemail, QS2.Resources.getRes.ePicTyp.ico);
            //QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenliste.ico_Aufnahme, QS2.Resources.getRes.ePicTyp.ico);
        }

        /// <summary>
        /// mda
        /// </summary>
        /// <param name="IDPatient"></param>
        void ENV_ENVPatientDatenChanged(Guid IDPatient)
        {
            if (_LoadInProgress)
                return;
            Guid id = ENV.CurrentIDPatient;
            RefreshPatientSearch(false);
            //ucPatientPicker1.SetIDPatient(id);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wird aufgerufen wenn irgendwo eine GuiAction aufgetreten ist.
        /// (GuiAction wurde mit OK beendet)
        /// </summary>
        //----------------------------------------------------------------------------
        void GuiAction_GuiActionDone(SiteEvents ev)
        {
            RefreshPatientSearch(true);

            //switch (ev)
            //{
            //    case SiteEvents.Entlassen:
            //        RefreshPatientSearch(true);
            //        break;
            //    case SiteEvents.Aufnahme:
            //        //ucPatientPicker1.RefreshList(GuiAction.LastAufnahmePatientID, Settings.CurrentUserAbteilungen.ToArray());      // Liste aktualisieren und auf ID Positionieren
            //        //Settings.CurrentIDPatient = GuiAction.LastAufnahmePatientID;
            //        //Settings.sendPatientChanged(eCurrentPatientChange.keiner  );
            //        //break;
            //        RefreshPatientSearch(true);
            //        break;
            //    case SiteEvents.Bereichsversetzung:
            //        //ucPatientPicker1.SetActiveBereich(GuiAction.LastVersetzungBereichText);
            //        //break;
            //        RefreshPatientSearch(true);
            //        break;
            //    case SiteEvents.Versetzen:
            //        //ucPatientPicker1.SetActiveAbteilung(GuiAction.LastVersetzungAbteilungID);
            //        //break;
            //        RefreshPatientSearch(true);
            //        break;
            //}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Genereller Handler
        /// </summary>
        //----------------------------------------------------------------------------
        private void commonHandler(PMDSMenuEntry sender)
        {
            switch (sender.SiteEvent)
            {

                // Arbeitsstation sperren
                case SiteEvents.Lock:
                    frmLoginLocked.ProcessLocked();
                    break;

                // neu anloggen
                case SiteEvents.LogOn:
                    frmLogin.ProcessLogin();
                    break;

                // Passwort ändern
                case SiteEvents.Password:
                    GuiAction.ChangePassword(false, true);
                    break;

                case SiteEvents.About:
                    new frmAbout().Show();
                    break;

                // Programm beenden
                case SiteEvents.End:
                    Form.ActiveForm.Close();
                    break;

                case SiteEvents.Patient:        // gar nichts machen wird von außen verarbeitet
                    SignalPatientenaktion();
                    break;

                //case SiteEvents.Stammdaten:
                //    GuiWorkflow.ShowStartPage();
                //    break;

                // Witerleiten
                default:
                    GuiAction.ActionFromEvent(sender.SiteEvent);
                    break;
            }
        }
        #region IPMDSGUIObject Members


        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf von außen verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {
            switch (e)
            {
                case SiteEvents.Klientenuebersicht:
                    FRAMEWORK.BringOnTop(this);
                    used = true;
                    break;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Benachrichtigen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void SignalPatientenaktion()
        {
            SignalEvent(SiteEvents.Patient);
        }

        protected void SignalEvent(SiteEvents ev)
        {
            if (SiteMapEvent == null)
                return;

            bool used = false;
            SiteMapEvent(ev, ref used);
        }

        public void loadKlientenStammdaten()
        {
            ENV.AnsichtsModus = TerminlisteAnsichtsmodi.Klientanansicht;
            ENV.CurrentAnsichtinfo.IDAbteilung = System.Guid.Empty;
            ENV.CurrentAnsichtinfo.IDBereich = System.Guid.Empty;
            if (PMDS.Global.historie.HistorieOn)
            {
                PMDS.Global.historie hist = new PMDS.Global.historie();
                hist.IDAufenthalt = ucPatientPicker1.CURRENT_IDAufenhaltxy;
            }
            ENV.setIDAUFENTHALT = ucPatientPicker1.CURRENT_IDAufenhaltxy;
            ENV.setCurrentIDPatient = ucPatientPicker1.CURRENT_IDPATIENTxy;

            ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, false);
            SignalEvent(SiteEvents.KlientenDetails);

            PMDS.GUI.GuiWorkflow._guiworkflow._SitemapKlientenDetails.ucKlient1._sitemap.aktivateButton(PMDS.GUI.GuiWorkflow._guiworkflow._SitemapKlientenDetails.ucKlient1.listButt, 2);
            PMDS.GUI.GuiWorkflow._guiworkflow._SitemapKlientenDetails.ucKlient1.SwitchTo(ucKlient.eModeKlient.KlientStammdaten);
            PMDS.GUI.GuiWorkflow._guiworkflow._SitemapKlientenDetails.ucKlient1.tabKlientenakt.SelectedTab = PMDS.GUI.GuiWorkflow._guiworkflow._SitemapKlientenDetails.ucKlient1.tabKlientenakt.Tabs["Regelungen"];

            //PMDS.GUI.GuiWorkflow GuiWorkflow1 = new GuiWorkflow();
            //GuiWorkflow1.loadKlientenStammdaten();

            //if (bLastGrup)
            //    SignalEvent(SiteEvents.KlientenDetailsLastSelectedGroup);
            //else

        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// CONTROL
        /// </summary>
        //----------------------------------------------------------------------------
        public Control CONTROL
        {
            get { return this; }
        }

        public void Undo()
        {
            // Do Nothing
        }

        public bool Save()
        {
            return true;		// Do Nothing
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// AREA
        /// </summary>
        //----------------------------------------------------------------------------
        public string AREA
        {
            get { return "SITEMAP_START"; }
        }

        private IPMDSMenuFramework _framework;

        //----------------------------------------------------------------------------
        /// <summary>
        /// FRAMEWORK
        /// </summary>
        //----------------------------------------------------------------------------
        public IPMDSMenuFramework FRAMEWORK
        {
            get { return _framework; }
            set { _framework = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// in Framework einhängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AttachFramework()
        {
            try
            {
                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                UpdateActions();
                _FrameworkAttached = true;

                EnableDisableBereichsbutton(ucPatientGroup1.CurrentSelection, false);

                btnAufnahmexyxy.Visible = ENV.ShowAufnahmeButton;
                SetFinishLoading();
                this.setButtonsAktivDeaktiv(SiteEvents.NONE);

                if (!this._showFirst) _framework.HEADER.ShowOnlyHeader(false);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                _framework.HEADER.action(false);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// aus Framework aushängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void DetachFramework()
        {
            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Keyboard Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        public void ProcessKeyEvent(KeyEventArgs e)
        {
            //			switch(e.KeyCode) 
            //			{
            //				case Keys.L:								
            //					HandleLabelEvent(SiteEvents.Terminliste);
            //					e.Handled = true;
            //					break;
            //			}
        }

        #endregion

        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            UpdateActions();
            txtSearch.Clear();
            RefreshPatientSearch(false);
            RefreshGroupTree();

            if (!PMDS.Global.historie.HistorieOn)
            {
                this.setRightButtonleisteUnten();
            }
            else
            {
                this.setRightButtonleisteUntenHistorie();
            }
            GuiWorkflow._guiworkflow.initKlintenakt(true);
            EnableDisableBereichsbutton(ucPatientGroup1.CurrentSelection, true);
            GuiWorkflow.ShowKlienten();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Abteilungen aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshGroupTree()
        {
            ucPatientGroup1.RefreshGUI(ENV.CurrentUserAbteilungen, this.ucPatientGroup1.allKliniken, this.ucPatientGroup1.onlyKlinikenUsr, false, this.ucPatientGroup1._adminModusAlleKliniken);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// erlaubte Aktionen ein/ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateActions()
        {

        }

        public void RefreshPatientSearch(bool bUseGroupInfo)
        {
            ucPatientPicker1.Abteilung = Guid.Empty;
            ucPatientPicker1.Bereich = Guid.Empty;

            if (bUseGroupInfo)
            {
                ucPatientPicker1.Abteilung = ucPatientGroup1.CurrentSelection.Abteilung;
                ucPatientPicker1.Bereich = ucPatientGroup1.CurrentSelection.Bereich;
            }

            //{{{eng}}} 04.10.2007
            if (BezugspersonfilterONOFF.Checked == true)
                if (pflegerCombo1.Visible)
                {
                    string Pfleger = pflegerCombo1.Value.ToString();
                    ENV.CurrentIDBezugsPfleger = new Guid(Pfleger);
                }
                else ENV.CurrentIDBezugsPfleger = Guid.Empty;

            if (bUseGroupInfo && !(ucPatientPicker1.Abteilung == Guid.Empty))
            {
                ucPatientPicker1.RefreshList();
            }
            else
            {
                ucPatientPicker1.RefreshList();
            }
            ShowHideButtons();

            this.checkIPCCallToClient();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn keine Klienten in der Liste sind dann auch kein wechsel zu den anderen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideButtons()
        {
            btnBereich.Visible = !ucPatientPicker1.IsEmpty();
        }

        private void txtSearch_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ucPatientPicker1.ClearFilter();
                if (this.txtSearch.Text.Trim() != "")
                {
                    this.ucPatientPicker1.SetFilter(Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or, "PatientName", (object)this.txtSearch.Text.Trim());
                    this.panelButtonleisteUnten.Visible = false;
                    this.mainWindow.ultraToolbarsManager1.Tools["btnPatientAufenthalteLöschen"].SharedProps.Visible = false;
                    this.ClearSelectedPatient();
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void ClearSelectedPatient()
        {
            try
            {
                ENV.setCurrentIDPatient = System.Guid.Empty;
                ENV.setIDAUFENTHALT = System.Guid.Empty;
                ENV.setIDBereich = System.Guid.Empty;
                ENV.setCurrentIDAbteilung = System.Guid.Empty;
                ENV.setCurrentIDBereich = System.Guid.Empty;
                //Settings.sendPatientChanged(eCurrentPatientChange.keiner, true);
                this.ucPatientPicker1.dgEintrag.Selected.Rows.Clear();
                this.ucPatientPicker1.dgEintrag.ActiveRow = null;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ClearSelectedPatient: " + ex.ToString());
            }
        }
        
        private void ucPatientGroup1_SelectionChanged(object sender, PatientGroupSelection args)
        {
            try
            {

                if (_LoadInProgress)
                    return;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    txtSearch.Clear();
                    RefreshPatientSearch(true);
                    ENV.setCurrentIDAbteilung = args.Abteilung;
                    ENV.setCurrentIDBereich = args.Bereich;
                    EnableDisableBereichsbutton(args, true);
                    this.doDokumenteBenutzer();
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void EnableDisableBereichsbutton(PatientGroupSelection args, bool newInit)
        {
            if (newInit)
            {
                this.panelButtonleisteUnten.Visible = false;
                this.btnKlient.Visible = false;
                this.mainWindow.ultraToolbarsManager1.Tools["btnPatientAufenthalteLöschen"].SharedProps.Visible = false;
            }
        }

        private void ProcessAufnahme()
        {
            GuiAction.ActionFromEvent(SiteEvents.Aufnahme);
        }

        private void ucPatientPicker1_RowChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (PMDS.Global.historie.HistorieOn)
                {
                    PMDS.Global.historie hist = new PMDS.Global.historie();
                    hist.IDAufenthalt = ucPatientPicker1.CURRENT_IDAufenhaltxy;
                }
                ENV.setIDAUFENTHALT = Aufenthalt.LastByPatient(ucPatientPicker1.CURRENT_IDPATIENTxy);
                ENV.setCurrentIDPatient = ucPatientPicker1.CURRENT_IDPATIENTxy;
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

        private void ucPatientPicker1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.panelButtonleisteUnten.Visible = true;
                this.mainWindow.ultraToolbarsManager1.Tools["btnPatientAufenthalteLöschen"].SharedProps.Visible = ENV.HasRight(UserRights.deleteKlient) || ENV.adminSecure;
                this.btnKlient.Visible = true;
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
        private void ucPatientPicker1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ENV.AnsichtsModus = TerminlisteAnsichtsmodi.Klientanansicht;
                ENV.CurrentAnsichtinfo.IDAbteilung = System.Guid.Empty;
                ENV.CurrentAnsichtinfo.IDBereich = System.Guid.Empty;
                if (PMDS.Global.historie.HistorieOn)
                {
                    PMDS.Global.historie hist = new PMDS.Global.historie();
                    hist.IDAufenthalt = ucPatientPicker1.CURRENT_IDAufenhaltxy;
                }
                // osxy: Warum LastByPatient? Fehlerursache für Wiederaufnahme bei Hauser vom 12.12.2014, weil Datum bei Wiederaufnahme früher eingegeben wurde!!!!
                // Aufenthalt.LastByPatient(ucPatientPicker1.CURRENT_IDPATIENTxy);
                ENV.setIDAUFENTHALT = ucPatientPicker1.CURRENT_IDAufenhaltxy;
                ENV.setCurrentIDPatient = ucPatientPicker1.CURRENT_IDPATIENTxy;

                if (!PMDS.Global.historie.HistorieOn)
                {
                    PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                    b.checkIDUrlaubAufenthalt(ENV.IDAUFENTHALT);
                }

                ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, false);

                ProcessKlientenClick(true);         //os-Performance ->
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

        private void btnKlient_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!rowSelected(true)) return;

                if (!this.checkPatientHasActAufenthalt(ENV.CurrentIDPatient))
                {
                    return;
                }


                ProcessKlientenClick(false);
                ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, false);

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

        private void ProcessKlientenClick(bool bLastGrup)
        {
            this.setButtonsAktivDeaktiv(SiteEvents.KlientenauswahlKlientenliste);
            if (bLastGrup)
                SignalEvent(SiteEvents.KlientenDetailsLastSelectedGroup);
            else
                SignalEvent(SiteEvents.KlientenDetails);
        }

        private void btnBereich_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //System.Data.Entity.DbSet<PMDS.db.Entities.Kostentraeger> dbKost = null;
                //PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                //PMDSBusiness1.getAllKostenträger(ref dbKost);

                //               if (!Settings.HasRight(UserRights.KlickOnGroupPickerRootNode) && ucPatientGroup1.CurrentSelection.Abteilung.Equals(Guid.Empty)) return;

                this.setButtonsAktivDeaktiv(SiteEvents.BereichsauswahlKlientenliste);
                ENV.CurrentAnsichtinfo.IDAbteilung = ucPatientGroup1.CurrentSelection.Abteilung;
                ENV.CurrentAnsichtinfo.IDBereich = ucPatientGroup1.CurrentSelection.Bereich;
                ENV.CurrentAnsichtinfo.IDKlinik = ENV.IDKlinik;
                ENV.AnsichtsModus = TerminlisteAnsichtsmodi.Bereichsansicht;
                ucSiteMapTermine.FirstCallDoRefreshKlienten = true;
                ucMedikamenteMainPicker.FirstCallDoRefreshKlienten = true;

                //System.Guid IDAbteilungGesamtesHaus = System.Guid.Empty;
                //if (IDAbteilungGesamtesHaus.Equals(Settings.CurrentAnsichtinfo.IDAbteilung))
                //{
                //    if (!this.PMDSBusiness1.UserHasRechtAufGesamteshaus(Settings.USERID))
                //    {
                //        return;
                //    }
                //}

                SignalEvent(SiteEvents.Bereichsansicht);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Wunsch Oskar, dass das Panel zentriert plaziert wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSiteMapStart_Resize(object sender, EventArgs e)
        {
            try
            {
                //panel1.Top = 0;                 // nach oben ausrichten
                //panel1.Height = this.Height;    // selbe höhe

                //if (panel1.Width >= this.Width)
                //{
                //    panel1.Left = 0;
                //    return;
                //}

                //panel1.Left = ((this.Width - panel1.Width) / 2);
                //this.panelOben.Left = panel1.Left;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void setWidthHeigtSiteMapStart(int w, int h)
        {
            //this.Width = w;
            //this.Height = h;
        }

        public void SetFinishLoading()
        {
            _LoadInProgress = false;
        }

        private void ucSiteMapStart_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;

                txtSearch.Focus();
                //this.setTitleForm();
                //RefreshGroupTree();          
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        public void setTitleForm(dsKlinik.KlinikRow rKlinik)
        {
            this.lblHeim.Text = "PMDS - Pflegemanagement- und Dokumentationssystem " + (rKlinik != null ? "für " + rKlinik.Bezeichnung.Trim() : "");
        }


        private void ucPatientGroup1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //if (btnBereich.Visible)
                btnBereich_Click(this, EventArgs.Empty);

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


        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn nicht auf Bezugspersin gefiltert wird wird Settings-currentidbezugsperson Guidempty //{{{eng}}} 04.10.2007         
        /// </summary>
        //----------------------------------------------------------------------------
        private void pflegerCombo1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_LoadInProgress)
                    return;
                if (BezugspersonfilterONOFF.Checked == true)
                {
                    if (pflegerCombo1.Value != null && pflegerCombo1.Value.GetType() == typeof(Guid))
                    {
                        Guid newGuid;
                        if (pflegerCombo1.Value != null && Guid.TryParse(pflegerCombo1.Value.ToString(), out newGuid))
                        {
                            ENV.CurrentIDBezugsPfleger = (Guid)pflegerCombo1.Value;
                            RefreshPatientSearch(true);
                            ucPatientGroup1.Focus();
                        }
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bei checken von Bezugsfiltercheckbox wird Settings Bezugspfleger gesetzt //{{{eng}}} 04.10.2007         
        /// </summary>
        //----------------------------------------------------------------------------
        private void BezugspersonfilterONOFF_AfterCheckStateChanged(object sender, EventArgs e)
        {
            if (_LoadInProgress)
                return;
            if (BezugspersonfilterONOFF.Checked == true)
            {
                pflegerCombo1.Enabled = true;
                if (pflegerCombo1.Value != null)
                {
                    ENV.CurrentIDBezugsPfleger = (Guid)pflegerCombo1.Value;
                }
                else
                {
                    pflegerCombo1.Value = ENV.USERID;
                    ENV.CurrentIDBezugsPfleger = (Guid)pflegerCombo1.Value;
                }

                if (ENV.HasRight(UserRights.NurBezugspflege) && !ENV.adminSecure)
                    pflegerCombo1.Enabled = false;
            }
            else
            {
                pflegerCombo1.Enabled = false;
                ENV.CurrentIDBezugsPfleger = Guid.Empty;
            }

            RefreshPatientSearch(true);
            ucPatientGroup1.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOben_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ultraGridBagLayoutPanelMitte_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool rowSelected(bool withMsgBox)
        {
            if (this.ucPatientPicker1.GRID.ActiveRow != null)
            {
                return true;
            }
            else
            {
                if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Klienten ausgewählt!", "Auswahl");
                return false;
            }
        }

        public bool checkPatientHasActAufenthalt(Guid IDKlient)
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Aufenthalt rActAuf = PMDSBusiness1.getAktuellerAufenthaltPatient(IDKlient, true, db);
                if (rActAuf == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist nicht mehr in der Liste der aktuellen Klienten!", "PMDS");
                    return false;
                }
                else
                    return true;
            }
        }

        private void btnEntlassen_Click(object sender, EventArgs e)
        {
            if (!rowSelected(true)) return;

            if (!this.checkPatientHasActAufenthalt(ENV.CurrentIDPatient))
            {
                return;
            }

            SiteEventArgs args = new SiteEventArgs();
            args.IDPatient = ENV.CurrentIDPatient;
            args.IDAufenthalt = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);
            this.setButtonsAktivDeaktiv(SiteEvents.Entlassen);
            //GuiAction.ActionFromEvent(SiteEvents.Entlassen, args, this.ucPatientGroup1.getSelKlinikRow(), null, this);        //lthNew
            this.setButtonsAktivDeaktiv(SiteEvents.NONE);
        }

        private void btnVersetzen_Click(object sender, EventArgs e)
        {
            if (!rowSelected(true)) return;

            if (!this.checkPatientHasActAufenthalt(ENV.CurrentIDPatient))
            {
                return;
            }

            SiteEventArgs args = new SiteEventArgs();
            args.IDPatient = ENV.CurrentIDPatient;
            args.IDAufenthalt = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);
            this.setButtonsAktivDeaktiv(SiteEvents.Versetzen);
            GuiAction.ActionFromEvent(SiteEvents.Versetzen, args, this.ucPatientGroup1.getSelKlinikRow(), null);
            this.setButtonsAktivDeaktiv(SiteEvents.NONE);
        }

        private void btnAbwesenheiten_Click(object sender, EventArgs e)
        {
            if (!rowSelected(true)) return;

            if (!this.checkPatientHasActAufenthalt(ENV.CurrentIDPatient))
            {
                return;
            }

            SiteEventArgs args = new SiteEventArgs();
            args.IDPatient = ENV.CurrentIDPatient;
            args.IDAufenthalt = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);
            this.setButtonsAktivDeaktiv(SiteEvents.Urlaub);
            GuiAction.ActionFromEvent(SiteEvents.Urlaub, args, this.ucPatientGroup1.getSelKlinikRow(), null);
            this.setButtonsAktivDeaktiv(SiteEvents.NONE);
        }

        private void btnBezugspersonen_Click(object sender, EventArgs e)
        {
            if (!rowSelected(true)) return;

            if (!this.checkPatientHasActAufenthalt(ENV.CurrentIDPatient))
            {
                return;
            }

            SiteEventArgs args = new SiteEventArgs();
            args.IDPatient = ENV.CurrentIDPatient;
            args.IDAufenthalt = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);
            this.setButtonsAktivDeaktiv(SiteEvents.Bezugsperson);
            GuiAction.ActionFromEvent(SiteEvents.Bezugsperson, args, this.ucPatientGroup1.getSelKlinikRow(), null);
            this.setButtonsAktivDeaktiv(SiteEvents.NONE);
        }



        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                SiteEventArgs args = new SiteEventArgs();
                args.IDPatient = ENV.CurrentIDPatient;
                args.IDAufenthalt = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);

                GuiAction.ActionFromEvent((SiteEvents)Enum.Parse(typeof(SiteEvents), e.Tool.Key, true), args, this.ucPatientGroup1.getSelKlinikRow(), null);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
            
        public void setButtonsAktivDeaktiv(SiteEvents aktivButton)
        {
            PMDS.Global.UIGlobal.setUIButton(this.btnEntlassen, aktivButton == SiteEvents.Entlassen);
            PMDS.Global.UIGlobal.setUIButton(this.btnVersetzen, aktivButton == SiteEvents.Versetzen);
            PMDS.Global.UIGlobal.setUIButton(this.btnAbwesenheiten, aktivButton == SiteEvents.Urlaub);
            PMDS.Global.UIGlobal.setUIButton(this.btnBezugspersonen, aktivButton == SiteEvents.Bezugsperson);
            PMDS.Global.UIGlobal.setUIButton(this.btnBereich, aktivButton == SiteEvents.BereichsauswahlKlientenliste);
            PMDS.Global.UIGlobal.setUIButton(this.btnKlient, aktivButton == SiteEvents.KlientenauswahlKlientenliste);
            PMDS.Global.UIGlobal.setUIButton(this.btnKliententermineArchive, aktivButton == SiteEvents.listeOffeneTermine);
            PMDS.Global.UIGlobal.setUIButton(this.btnAufnahmexyxy, aktivButton == SiteEvents.listeOffeneTermine);
        }

        private void setRightButtonleisteUnten()
        {
            //this.btnEntlassen.Visible = Settings.HasRight(UserRights.Entlassung);
            this.btnEntlassen.Visible = ENV.HasRight(UserRights.KlientEntlassen);
            this.btnAbwesenheiten.Visible = ENV.HasRight(UserRights.AbwesenheitErfassen);
            this.btnVersetzen.Visible = ENV.HasRight(UserRights.Versetzung);
            this.btnBezugspersonen.Visible = (ENV.HasRight(UserRights.BezugspersonAendern) && ENV.BezugspersonenJN) || ENV.HasRight(UserRights.NurBezugspflege);
            this.chkHistorie.Visible = ENV.HasRight(UserRights.historie);
        }
        private void setRightButtonleisteUntenHistorie()
        {
            this.btnEntlassen.Visible = false;
            this.btnVersetzen.Visible = false;
            this.btnAbwesenheiten.Visible = false;
            this.btnBezugspersonen.Visible = false;
        }

        private void btnOffeneTermine_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setButtonsAktivDeaktiv(SiteEvents.listeOffeneTermine);
                GuiAction.archivTerminMail(true, true, false, false);

            }
            catch (Exception ex)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chkHistorie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkHistorie.Focused)
                {
                    setHistorieOnOff();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void setHistorieOnOff()
        {

            //PMDSBusiness b = new PMDSBusiness();
            //b.testObjectApplications();


            PMDS.Global.historie.HistorieOn = this.chkHistorie.Checked;

            ucPatientPicker1.ShowEntlassene = this.chkHistorie.Checked;
            this.panelBereichsauswahl.Visible = !this.chkHistorie.Checked;
            BezugspersonfilterONOFF.Checked = ENV.HasRight(UserRights.NurBezugspflege);
            //SiteEventArgs args = new SiteEventArgs();
            //args.IDPatient = Settings.CurrentIDPatient;
            //args.IDAufenthalt = Aufenthalt.LastByPatient(Settings.CurrentIDPatient);

            //System.Guid gid = new System.Guid();

            //if (ucPatientPicker1.CURRENT_IDPATIENT == Guid.Empty)
            //    return;
            //Settings.CurrentIDPatient = ucPatientPicker1.CURRENT_IDPATIENT;
            //Settings.IDAUFENTHALT = Aufenthalt.LastByPatient(Settings.CurrentIDPatient);
            // ProcessKlientenClick(false);

            txtSearch.Clear();
            ucPatientGroup1.SetCurrentToRoot();
            ucPatientGroup1.Refresh();



            RefreshPatientSearch(true);
            //Settings.CurrentIDAbteilung = args.Abteilung;
            //Settings.CurrentIDBereich = args.Bereich;
            this.btnDokumenteBenutzer.Visible = false;

            EnableDisableBereichsbutton(ucPatientGroup1.CurrentSelection, true);
            lblS2.Visible = false;

            if (!PMDS.Global.historie.HistorieOn)
            {
                this.setRightButtonleisteUnten();
                this.BackColor = System.Drawing.Color.Silver;
                this.lblHeim.Appearance.ForeColor = System.Drawing.Color.White;
                this.lblS2.Appearance.ForeColor = System.Drawing.Color.White;
                lblInfoHistorie.Visible = false;
                pflegerCombo1.Visible = ENV.BezugspersonenJN;
                BezugspersonfilterONOFF.Visible = ENV.BezugspersonenJN;


                lblHeim.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblInfoHistorie.Visible = true;
                this.setRightButtonleisteUntenHistorie();
                this.BackColor = System.Drawing.Color.Gray;
                this.lblHeim.Appearance.ForeColor = System.Drawing.Color.White;
                this.lblS2.Appearance.ForeColor = System.Drawing.Color.White;
                BezugspersonfilterONOFF.Visible = false;
                pflegerCombo1.Visible = false;
                lblHeim.Appearance.ForeColor = System.Drawing.Color.White;
            }

            if (ENV.HasRight(UserRights.NurBezugspflege) && !ENV.adminSecure)
            {
                BezugspersonfilterONOFF.Visible = true;
                BezugspersonfilterONOFF.Checked = true;
                BezugspersonfilterONOFF.Enabled = false;
                pflegerCombo1.Visible = true;
                pflegerCombo1.Enabled = false;
            }

            Application.DoEvents();

            //this.ucPatientPicker1.dgEintrag.ActiveRow = null;
            //this.ucPatientPicker1.dgEintrag.Selected.Rows.Clear();
            GuiWorkflow.mainWindow.setHeaderUI(false);

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeim_Click(object sender, EventArgs e)
        {

        }

        private void ucSiteMapStart_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {

                    //this.ucPatientGroup1.loadEinrichtungen();
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void ucPatientGroup1_klinikHasChanged(dsKlinik.KlinikRow rKlinik)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (rKlinik == null)
                    this.ucPatientPicker1.clearData();
                else
                    this.setTitleForm(rKlinik);

                this.btnDokumenteBenutzer.Visible = false;

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

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ENV.setCurrentIDPatient = System.Guid.Empty;   //Benutzer zurücksetzen -> damit IDKlinik_current, IDAbteilung_current auf Empt gesetzt werden.
                GuiAction.Berichte();


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAufnahme_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProcessAufnahme();

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

        private void checkUserActivity(object sender, EventArgs e)
        {
            if (this.mainWindow.Visible == true)
            {
                uint idleSekunden = PMDS.Global.Tools.GetIdleTime() / 1000;
                uint RestSekunden = 0;
                if (idleSekunden / 60 == ENV.MaxIdleTime - 1)           //Idletime in Minuten - Sperrwarung in einer Minute
                {
                    RestSekunden = ENV.MaxIdleTime * 60 - idleSekunden;
                    this.lblSperre.Text = "Automatische Sperre in ";
                    if (RestSekunden == 1)
                        this.lblSperre.Text += "einer Sekunde!";
                    else
                        this.lblSperre.Text += RestSekunden.ToString() + " Sekunden!";

                    this.lblSperre.Visible = true;
                    this.pbSperre.Value = (int)RestSekunden;
                    this.pbSperre.Visible = true;
                    this.mainWindow.Text = ENV.MainCaption + " - " + this.lblSperre.Text;
                }
                else if (PMDS.Global.Tools.GetIdleTime() / 1000 / 60 == ENV.MaxIdleTime)      //Idletime in Minuten - Sperre
                {
                    this.pbSperre.Visible = false;
                    this.lblSperre.Visible = false;
                    this.mainWindow.Visible = false;
                    PMDS.GUI.frmLock frmLock1 = new frmLock();
                    frmLock1.ShowDialog(this.mainWindow);
                    if (frmLock1.TimeOutElapsed)
                    {
                        this.mainWindow.Close();
                    }
                    frmLock1.Dispose();
                    this.mainWindow.Visible = true;
                    this.mainWindow.WindowState = FormWindowState.Normal;
                    this.mainWindow.BringToFront();
                    Application.DoEvents();
                    this.mainWindow.Activate();
                }
                else
                {
                    this.lblSperre.Visible = false;
                    this.pbSperre.Visible = false;
                    this.mainWindow.Text = ENV.MainCaption;
                }
            }
        }

        public void doDokumenteBenutzer()
        {
            try
            {
                if (ENV.CurrentIDAbteilung == null)   // || Settings.CurrentIDAbteilung == System.Guid.Empty
                {
                    PMDS.Global.UIGlobal.setUIButton(this.btnDokumenteBenutzer, false);
                    this.btnDokumenteBenutzer.Visible = false;
                }
                else
                {
                    PMDS.Global.UIGlobal.setUIButton(this.btnDokumenteBenutzer, true);
                    this.dsKlientenliste1.Clear();
                    Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
                    sqlManange1.initControl();
                    sqlManange1.loadDokumenteBenutzer(ref this.dsKlientenliste1, ENV.CurrentIDAbteilung);
                    if (this.dsKlientenliste1.Dokumente2.Rows.Count > 0)
                    {
                        this.btnDokumenteBenutzer.Text = "Anleitungen (" + this.dsKlientenliste1.Dokumente2.Rows.Count.ToString() + ")";
                        this.btnDokumenteBenutzer.Visible = true;
                    }
                    else
                    {
                        this.btnDokumenteBenutzer.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doDokumenteBenutzer: " + ex.ToString());
            }
        }
        private void btnDokumenteBenutzer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.GUI.GUI.Main.frmDocumentsSelect frmDocumentsSelect1 = new GUI.Main.frmDocumentsSelect();
                frmDocumentsSelect1.initControl(ENV.CurrentIDAbteilung, ref this.dsKlientenliste1);
                frmDocumentsSelect1.Show();
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

        private void btnMessages_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openMessenger();

            }
            catch (Exception ex)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void openMessenger()
        {
            try
            {
                if (this.frmMessenger1 == null)
                {
                    this.frmMessenger1 = new frmMessenger();
                    this.frmMessenger1.initControl();
                }

                this.frmMessenger1.Show();
                this.frmMessenger1.Visible = true;
                this.frmMessenger1.TopMost = true;
                if (this.frmMessenger1.WindowState == FormWindowState.Minimized)
                {
                    this.frmMessenger1.WindowState = FormWindowState.Normal;
                }
                this.frmMessenger1.TopMost = false;
                this.frmMessenger1.contMessenger1.refreshTree();

            }
            catch (Exception ex)
            {
                throw new Exception("openMessenger: " + ex.ToString());
            }
        }

        public void checkIPCCallToClient()
        {
            try
            {
                if (!this.bcheckIPCCallToClientDone)
                {
                    //if (Settings.SchnellrückmeldungAsProcess.Trim() == "1")
                    //{
                    //    while (!remotingSrv.LoggedIn2)
                    //    {
                    //        qs2.core.generic.WaitMilli(10);
                    //    }

                    //    remotingClient remotingClient1 = new remotingClient();
                    //    cParComm cParComm1 = new cParComm();
                    //    remotingClient.cCallFctReturn CallFctReturn = null;
                    //    remotingClient1.callFct(ICommunicationService.eTypeCallTo.ClientPMDS, ICommunicationService.eTypeFct.TestCallToClient, cParComm1, ref CallFctReturn);
                    //    if (!CallFctReturn.bOK)
                    //    {
                    //        throw new Exception("ucMain.checkIPCCallToClient: CallFctReturn.bOK=false not allowed!");
                    //    }
                    //}
                }

                this.bcheckIPCCallToClientDone = true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucMain.checkIPCCallToClient: " + ex.ToString());
            }
        }
    }
}
