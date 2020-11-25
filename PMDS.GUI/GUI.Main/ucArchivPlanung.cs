using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using System.Collections;
using System.IO;
using PMDS.BusinessLogic;



namespace PMDS.Itscont
{

     public partial class ucArchivPlanung : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
     {

        public PMDS.GUI.VB.contPlanungData.eTypeUI _TypeUI;
        public PMDS.GUI.VB.contPlanungData.cPlanArchive _PlanArchive = new GUI.VB.contPlanungData.cPlanArchive();
        public bool showKlientenarchiv = false;

        public bool IsFirstLoad = true;
        public int LastSelectedTab = -1;

        private int _lastAktivButton = 0;
        public bool _headerEin = false;
        private bool _ContentChanged = false;
        private bool isLoaded = false;
        private bool isLoadedArchive = false;

        private string infAuswahl = "";
        private Patient pat = new Patient();

        private PMDS.GUI.VB.GeneralArchiv _gen = new PMDS.GUI.VB.GeneralArchiv();
        private PMDS.GUI.VB.cArchive clArchiv = new PMDS.GUI.VB.cArchive();

        public PMDS.GUI.VB.contArchivMain contArchivMainOld = null;
        public GUI.VB.contArchMain contArchMain1 = null;
        public GUI.VB.contPlanung2 contPlanung211 = null;

        public bool IsInitializedPlanBereich = false;

        public GUI.VB.contPlanung2Bereich contPlanung2Bereich1 = null;












        public ucArchivPlanung()
        {
            InitializeComponent();

            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
        }
        



        public void initControls2(PMDS.GUI.VB.contPlanungData.eTypeUI TypeUI, PMDS.GUI.VB.contPlanungData.cPlanArchive PlanArchive)
        {
            try
            {
                this.btnTermineKlientenansicht.Visible = true;
                this.btnMyTermine.Visible = true;
                this.btnTermineAll.Visible = true;
                this.btnEMail.Visible = false;

                this.btnTermineKlientenansicht.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kliententermine");
                this.btnMyTermine.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Meine Termine");
                this.btnTermineAll.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle Termine");

                //////this.contArchivMainOld = new GUI.VB.contArchivMain();
                //////this.contArchivMainOld.Dock = DockStyle.Fill;
                //////this.panelArchiveOld.Controls.Add(this.contArchivMainOld);
                //////this.contArchivMainOld.mainWindow = this;

                //this.contArchMain1 = new GUI.VB.contArchMain();
                //this.contArchMain1.Dock = DockStyle.Fill;
                //this.panelArchiv2.Controls.Add(this.contArchMain1);

                this.contPlanung211 = new GUI.VB.contPlanung2();
                this.contPlanung211.Dock = DockStyle.Fill;
                this.panelPlan2.Controls.Add(this.contPlanung211);

                this.setButtonsAktivDeaktiv(1);
                //this.contArchMain1.PMDSMainWindow = (Control)this;
                this.contPlanung211.PMDSMainWindow = (Control)this;
       

                //////if (ENV.CurrentIDPatient != Guid.Empty)
                //////{
                //////    Patient p = new Patient(ENV.CurrentIDPatient);
                //////    Benutzer b = new Benutzer(ENV.USERID);
                //////    this.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv von {0} für {1} "), b.BenutzerName, p.FullInfo);
                //////}
                //////else
                //////{
                //////    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivsystem");
                //////}

                this.tabMain.Tabs[0].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv");
                this.tabMain.Tabs[1].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine");
                this.tabMain.Tabs[2].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("E-Mails");
                this.tabMain.Tabs[3].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv");
                this.tabMain.Tabs[4].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine");

                if (!ENV.adminSecure)
                {
                    this.btnTermineBereiche.Visible = false;
                }

                this.isLoaded = true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.initControls2: " + ex.ToString());
            }
        }
        public void initControlsArchiv(PMDS.GUI.VB.contPlanungData.eTypeUI TypeUI, PMDS.GUI.VB.contPlanungData.cPlanArchive PlanArchive)
        {
            try
            {
                this.contArchivMainOld = new GUI.VB.contArchivMain();
                this.contArchivMainOld.Dock = DockStyle.Fill;
                this.panelArchiveOld.Controls.Add(this.contArchivMainOld);
                this.contArchivMainOld.mainWindow = this;

                //this.contArchMain1 = new GUI.VB.contArchMain();
                //this.contArchMain1.Dock = DockStyle.Fill;
                //this.panelArchiv2.Controls.Add(this.contArchMain1);
                
                if (ENV.CurrentIDPatient != Guid.Empty)
                {
                    Patient p = new Patient(ENV.CurrentIDPatient);
                    Benutzer b = new Benutzer(ENV.USERID);
                    this.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv von {0} für {1} "), b.BenutzerName, p.FullInfo);
                }
                else
                {
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivsystem");
                }

                this.isLoadedArchive = true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.initControlsArchiv: " + ex.ToString());
            }
        }
        public void loadData(PMDS.GUI.VB.contPlanungData.eTypeUI TypeUI, PMDS.GUI.VB.contPlanungData.cPlanArchive PlanArchive)
        {
            try
            {
                this.Cursor = Cursors.Arrow;
                    
                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                this.btnArchiv.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Archiv, 32, 32);
                this.btnTermineAll.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_AlleTermine, 32, 32);
                this.btnMyTermine.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_MeineTermine, 32, 32);
                this.btnTermineKlientenansicht.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kliententermine, 32, 32);

                this.ultraToolTipManager1.SetUltraToolTip(this.btnArchiv, null);
                this.ultraToolTipManager1.SetUltraToolTip(this.btnTermineAll, null);
                this.ultraToolTipManager1.SetUltraToolTip(this.btnMyTermine, null);
                this.ultraToolTipManager1.SetUltraToolTip(this.btnTermineKlientenansicht, null);

                if (!this.isLoaded)
                {
                    this.initControls2(TypeUI, PlanArchive);
                }
                if (this.showKlientenarchiv)
                {
                    if (!this.isLoadedArchive)
                    {
                        this.initControlsArchiv(TypeUI, PlanArchive);
                    }
                }

                //Archivtype typArchiv = new Archivtype();
                //if (TypeUI == GUI.VB.contPlanungData.eTypeUI.PlansAll || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanMy)
                //{
                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnArchiv, inf);

                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnTermineKlientenansicht, inf);

                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnEMail, inf);

                //    //infAuswahl = "von Benutzer " + new Benutzer(ENV.USERID).FullName;

                //    //this.ultraToolbarsManager1.UseLargeImagesOnMenu = false;
                //    //this.ultraToolbarsManager1.UseLargeImagesOnToolbar = false;
                //}
                //else
                //{
                //    //typArchiv = Archivtype.Suchen;
                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnArchiv, inf);

                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnTermineKlientenansicht, inf);

                //    //inf = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                //    //inf.ToolTipText = "";
                //    //inf.ToolTipTitle = "";
                //    //this.ultraToolTipManager1.SetUltraToolTip(this.btnEMail, inf);

                //    //this.ultraToolbarsManager1.UseLargeImagesOnMenu = false;
                //    //this.ultraToolbarsManager1.UseLargeImagesOnToolbar = false;
                //}

                //if (TypeUI == GUI.VB.contPlanungData.eTypeUI.ArchiveAll || TypeUI == GUI.VB.contPlanungData.eTypeUI.ArchiveIDPatient || this.IsFirstLoad)
                //{
                //    this.initArchiv(TypeUI, PlanArchive, this.IsFirstLoad);
                //}
                if (this.showKlientenarchiv)
                {
                    this.initArchiv(TypeUI, PlanArchive, this.IsFirstLoad);
                    this.initTermineMails(TypeUI, PlanArchive, true, this.IsFirstLoad);
                    this.LastSelectedTab = 0;
                    this.setButtonsAktivDeaktiv(0);
                    this.showTab(0);
                }
                else
                {
                    if (TypeUI == GUI.VB.contPlanungData.eTypeUI.IDKlient || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanKlienten || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanMy || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlansAll || this.IsFirstLoad)
                    {
                        if (this.isLoadedArchive)
                        {
                            this.initArchiv(TypeUI, PlanArchive, this.IsFirstLoad);
                        }
                        this.initTermineMails(TypeUI, PlanArchive, true, this.IsFirstLoad);
                        //this.initTermineMails(TypeUI, lstIDs, null, false);
                        if (TypeUI == GUI.VB.contPlanungData.eTypeUI.IDKlient)
                        {
                            this.LastSelectedTab = 4;
                            this.showTab(4);
                        }
                        else
                        {
                            //this._lastAktivButton = 1;
                            this.LastSelectedTab = 4;
                            this.showTab(4);
                        }
                    }
                    else
                    {
                        throw new Exception("loadData: TypeUI '" + TypeUI.ToString() + "' not allowed!");
                    }
                    //this.initArchiv(ENV.DB_SERVER, ENV.DB_DATABASE, ENV.DB_USER, ENV.DB_PASSWORD, ENV.CurrentIDPatient, typArchiv);
                }

                this.setButtonsAktivDeaktiv(this._lastAktivButton);

                //clArchiv.checkSysOrdner_anhangPlanung();

                if (this.IsFirstLoad)
                {
                    if (this._headerEin)
                    {
                        this.showTab(4);
                    }
                    else
                    {

                    }

                    this.IsFirstLoad = false;
                }

                if (!this._headerEin)
                {
                    this.tabMain.Tabs[0].Visible = true;
                    this.tabMain.Tabs[1].Visible = false;
                    this.tabMain.Tabs[2].Visible = false;
                    this.tabMain.Tabs[3].Visible = false;
                    //this.tabMain.Tabs[3].Visible = true;
                    this.tabMain.Tabs[4].Visible = true;

                    if (this.LastSelectedTab == -1)
                        this.LastSelectedTab = 4;
                    //if (this.LastSelectedTab == -1)
                    //    this.LastSelectedTab = 3;

                    this.tabMain.SelectedTab = tabMain.Tabs[this.LastSelectedTab];
                }

                if (this._headerEin)
                {
                    this.panelOben.Visible = true;
                    this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                    this.tabMain.UseAppStyling = false;
                }
                else
                {
                    this.panelOben.Visible = false;
                    this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
                    this.tabMain.UseAppStyling = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.loadData: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void initArchiv(PMDS.GUI.VB.contPlanungData.eTypeUI TypeUI, PMDS.GUI.VB.contPlanungData.cPlanArchive PlanArchive, bool doInit)
        {
            try
            {
                //if (IDPatient != Guid.Empty)
                if (TypeUI == GUI.VB.contPlanungData.eTypeUI.IDKlient)
                {
                    this.contArchivMainOld.startTyp = PMDS.GUI.VB.contArchivMain.eStart.Search;
                    this.contArchivMainOld.patient = this.getPatientenName();

                    if (ENV.CurrentIDPatient == System.Guid.Empty)
                    {
                        throw new Exception("initArchiv: ENV.CurrentIDPatient=System.Guid.Empty not allowed!");
                    }
                    pat = new Patient(ENV.CurrentIDPatient);
                    infAuswahl = QS2.Desktop.ControlManagment.ControlManagment.getRes("für Klient ") + pat.FullName;
                    //this.lblInfo.Text = infAuswahl;

                    ArrayList al = new ArrayList();
                    PMDS.GUI.VB.clObject o = new PMDS.GUI.VB.clObject();
                    o.id = pat.ID.ToString();
                    o.bezeichnung = this.getPatientenName();
                    al.Add(o);
                    
                    this.contArchivMainOld.setObjekts(al);
                    this.contArchivMainOld.loadArchiv(GUI.VB.contArchivMain.eStart.Search, false);
                }
                else if (TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanKlienten || doInit)
                {
                    //this.lblInfo.Text = "";
                    this.contArchivMainOld.startTyp = PMDS.GUI.VB.contArchivMain.eStart.gesamtsystem;
                    this.contArchivMainOld.patient = "";
                    this.contArchivMainOld.clearObjects();
                    this.contArchivMainOld.loadArchiv(GUI.VB.contArchivMain.eStart.gesamtsystem, doInit);
                }
                else
                {
                    //throw new Exception("initArchiv: TypeUI '" + TypeUI.ToString() + "' not allowed!");
                }

                
                //ResizeControl();
                //if (_main != null)
                //    _main.resizeWindowExtern(pnlMain.Width, pnlMain.Height);


                //if (this._gesamt)
                //{
                //    this.contArchMain1.startTyp = GUI.VB.contArchMain.eStart.gesamtsystem;
                //    this.contArchMain1.patient = "";
                //    this.contArchMain1.ContArchivSuch1.tArchObjects = new GUI.VB.dbArchiv.archObjectDataTable();
                //    this.contArchMain1.loadArchiv(GUI.VB.contArchMain.eStart.gesamtsystem);
                //}
                //else
                //{
                //    this.contArchMain1.startTyp = GUI.VB.contArchMain.eStart.Search;
                //    this.contArchMain1.patient = this.getPatientenName();

                //    PMDS.GUI.VB.compDoku compDoku1 = new PMDS.GUI.VB.compDoku();
                //    GUI.VB.dbArchiv.archObjectDataTable tArchObjects = new GUI.VB.dbArchiv.archObjectDataTable();
                //    PMDS.GUI.VB.dbArchiv.archObjectRow rNewObj = compDoku1.getNewRowArchObject(tArchObjects);
                //    rNewObj.IDObject = IDPatient;
                //    this.contArchMain1.ContArchivSuch1.tArchObjects = tArchObjects;

                //    this.contArchMain1.loadArchiv(GUI.VB.contArchMain.eStart.Search);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.initArchiv: " + ex.ToString());
            }
        }
        public void initTermineMails(PMDS.GUI.VB.contPlanungData.eTypeUI TypeUI, PMDS.GUI.VB.contPlanungData.cPlanArchive PlanArchive,
                                        bool isTermin, bool doInit)
        {
            try
            {
                if (TypeUI == GUI.VB.contPlanungData.eTypeUI.IDKlient && !doInit)
                {
                    PMDS.GUI.VB.dsPlan dsPlan1 = new GUI.VB.dsPlan();
                    PMDS.GUI.VB.compPlan compPlan1 = new GUI.VB.compPlan();
                    PMDS.GUI.VB.dsPlan.planObjectRow rPlanObj = compPlan1.getNewRowPlanObject(dsPlan1.planObject);

                    //pat = new Patient(ENV.CurrentIDPatient);
                    //infAuswahl = QS2.Desktop.ControlManagment.ControlManagment.getRes("für Klient ") + pat.FullName;
                    //this.lblInfo.Text = infAuswahl;
                    //this.lblInfo.Text = "";

                    this.contPlanung211.initForm(PMDS.GUI.VB.clPlan.typPlan_AufgabeTermin, TypeUI, PlanArchive, doInit);
                }
                else if (TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanKlienten || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanMy || TypeUI == GUI.VB.contPlanungData.eTypeUI.PlansAll || doInit)
                {
                    if (TypeUI == GUI.VB.contPlanungData.eTypeUI.PlanMy)
                    {
                        //if (lstIDs.Count != 1)
                        //{
                        //    throw new Exception("initArchiv: lstIDs.Count != 1!");
                        //}
                    }
                    //this.lblInfo.Text = "";

                    PMDS.GUI.VB.dsPlan dsPlan1 = new GUI.VB.dsPlan();
                    if (isTermin)
                    {
                        this.contPlanung211.initForm(PMDS.GUI.VB.clPlan.typPlan_AufgabeTermin, TypeUI, PlanArchive, doInit);
                    }
                    else
                    {
                        throw new Exception("initArchiv: E.Mail not allowed!");
                        //this.contPlanung21.initForm(PMDS.GUI.VB.clPlan.typPlan_EMailEmpfangen, TypeUI, PlanArchive, doInit);
                    }
                }
                else
                {
                    throw new Exception("initTermineMails: TypeUI '" + TypeUI.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.initTermineMails: " + ex.ToString());
            }
        }

        private void initPlanBereich()
        {
            try
            {
                if (!this.IsInitializedPlanBereich)
                {
                    this.setButtonsAktivDeaktiv(5);

                    this.contPlanung2Bereich1 = new GUI.VB.contPlanung2Bereich();
                    this.contPlanung2Bereich1.initForm(-1, GUI.VB.contPlanungData.eTypeUI.PlansAll, new GUI.VB.contPlanungDataBereich.cPlanArchive(), true);
                    this.contPlanung2Bereich1.Dock = DockStyle.Fill;
                    this.panelPlanBereich.Controls.Add(this.contPlanung2Bereich1);

                    this.IsInitializedPlanBereich = true;
                }

                this.showTab(5);
            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.initPlanBereich: " + ex.ToString());
            }
        }

        public string getPatientenName()
        {
            try
            {
                PMDS.BusinessLogic.Patient pat = new PMDS.BusinessLogic.Patient(PMDS.Global.ENV.CurrentIDPatient);
                return pat.Vorname + " " + pat.Nachname;

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.getPatientenName: " + ex.ToString());
            }
        }
        
        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {
        }
        
        
        public Control CONTROL
        {
            get { return this; }
        }
        
        public void Undo()
        {
        }
        
        public bool Save()
        {
            return true;
        }
        

        public string AREA
        {
            get 
            {
                if (_headerEin)
                    return "SITEMAP_START";
                else
                    return "";
            }
        }
        
        private IPMDSMenuFramework _framework;
        

        public IPMDSMenuFramework FRAMEWORK
        {
            get { return _framework; }
            set { _framework = value; }
        }
        public void AttachFramework()
        {
            try
            {
                this._lastAktivButton = 1;
                this.loadData(this._TypeUI, this._PlanArchive);

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.AttachFramework: " + ex.ToString());
            }
        }
        void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            try
            {
                if (this.Visible)
                    this.loadData(this._TypeUI, this._PlanArchive);

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }
        public void DetachFramework()
        {
        }

        public void ProcessKeyEvent(KeyEventArgs e)
        {
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                if (this.tabMain.Focused)
                {
                    if (e.Tab.Index == 0)
                    {
                        if (this._TypeUI == GUI.VB.contPlanungData.eTypeUI.IDKlient)
                        {
                            this.showKlientenarchiv = true;
                        }
                        if (!this.isLoadedArchive)
                        {
                            this.initControlsArchiv(this._TypeUI, this._PlanArchive);
                        }
                        this.initArchiv(this._TypeUI, this._PlanArchive, this.IsFirstLoad);

                    }
                    else
                    {
                        this.showKlientenarchiv = false;
                    }

                    this.LastSelectedTab = e.Tab.Index;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.ultraTabControl1_SelectedTabChanged: " + ex.ToString());
            }
        }

        private void panelArchiv_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ucArchivPlanung_Resize(object sender, EventArgs e)
        {

        }
        
        private void showTab(int iTab)
        {
            try
            {
                if (iTab == 0)
                {
                    if (!this.isLoadedArchive)
                    {
                        this.initControlsArchiv(this._TypeUI, this._PlanArchive);
                    }
                    this.initArchiv(this._TypeUI, this._PlanArchive, this.IsFirstLoad);

                    this.tabMain.Tabs[0].TabPage.Visible = true;
                    this.tabMain.Tabs[1].TabPage.Visible = false;
                    this.tabMain.Tabs[2].TabPage.Visible = false;
                    this.tabMain.Tabs[3].TabPage.Visible = false;
                    this.tabMain.Tabs[4].TabPage.Visible = false;
                    this.tabMain.Tabs[5].TabPage.Visible = false;
                    this.tabMain.Tabs[0].TabPage.Show();
                    this.tabMain.Tabs[1].TabPage.Hide();
                    this.tabMain.Tabs[2].TabPage.Hide();
                    this.tabMain.Tabs[3].TabPage.Hide();
                    this.tabMain.Tabs[4].TabPage.Hide();
                    this.tabMain.Tabs[5].TabPage.Hide();
                    this.tabMain.SelectedTab = tabMain.Tabs[0];
                }
                else if (iTab == 1)
                {
                    this.tabMain.Tabs[0].TabPage.Visible = false;
                    this.tabMain.Tabs[1].TabPage.Visible = true;
                    this.tabMain.Tabs[2].TabPage.Visible = false;
                    this.tabMain.Tabs[3].TabPage.Visible = false;
                    this.tabMain.Tabs[4].TabPage.Visible = false;
                    this.tabMain.Tabs[5].TabPage.Visible = false;
                    this.tabMain.Tabs[0].TabPage.Hide();
                    this.tabMain.Tabs[1].TabPage.Show();
                    this.tabMain.Tabs[2].TabPage.Hide();
                    this.tabMain.Tabs[3].TabPage.Hide();
                    this.tabMain.Tabs[4].TabPage.Hide();
                    this.tabMain.Tabs[5].TabPage.Hide();
                    this.tabMain.SelectedTab = tabMain.Tabs[1];
                }
                else if (iTab == 2)
                {
                    this.tabMain.Tabs[0].TabPage.Visible = false;
                    this.tabMain.Tabs[1].TabPage.Visible = false;
                    this.tabMain.Tabs[2].TabPage.Visible = true;
                    this.tabMain.Tabs[3].TabPage.Visible = false;
                    this.tabMain.Tabs[4].TabPage.Visible = false;
                    this.tabMain.Tabs[5].TabPage.Visible = false;
                    this.tabMain.Tabs[0].TabPage.Hide();
                    this.tabMain.Tabs[1].TabPage.Hide();
                    this.tabMain.Tabs[2].TabPage.Show();
                    this.tabMain.Tabs[3].TabPage.Hide();
                    this.tabMain.Tabs[4].TabPage.Hide();
                    this.tabMain.Tabs[5].TabPage.Hide();
                    this.tabMain.SelectedTab = tabMain.Tabs[2];
                }
                else if (iTab == 3)
                {
                    this.tabMain.Tabs[0].TabPage.Visible = false;
                    this.tabMain.Tabs[1].TabPage.Visible = false;
                    this.tabMain.Tabs[2].TabPage.Visible = false;
                    this.tabMain.Tabs[3].TabPage.Visible = true;
                    this.tabMain.Tabs[4].TabPage.Visible = false;
                    this.tabMain.Tabs[5].TabPage.Visible = false;
                    this.tabMain.Tabs[0].TabPage.Hide();
                    this.tabMain.Tabs[1].TabPage.Hide();
                    this.tabMain.Tabs[2].TabPage.Hide();
                    this.tabMain.Tabs[3].TabPage.Show();
                    this.tabMain.Tabs[4].TabPage.Hide();
                    this.tabMain.Tabs[5].TabPage.Hide();

                    this.tabMain.SelectedTab = tabMain.Tabs[3];
                }
                else if (iTab == 4)
                {
                    this.tabMain.Tabs[0].TabPage.Visible = false;
                    this.tabMain.Tabs[1].TabPage.Visible = false;
                    this.tabMain.Tabs[2].TabPage.Visible = false;
                    this.tabMain.Tabs[3].TabPage.Visible = false;
                    this.tabMain.Tabs[4].TabPage.Visible = true;
                    this.tabMain.Tabs[5].TabPage.Visible = false;
                    this.tabMain.Tabs[0].TabPage.Hide();
                    this.tabMain.Tabs[1].TabPage.Hide();
                    this.tabMain.Tabs[2].TabPage.Hide();
                    this.tabMain.Tabs[3].TabPage.Hide();
                    this.tabMain.Tabs[4].TabPage.Show();
                    this.tabMain.Tabs[5].TabPage.Hide();

                    this.tabMain.SelectedTab = tabMain.Tabs[4];
                }
                else if (iTab == 5)
                {
                    this.tabMain.Tabs[0].TabPage.Visible = false;
                    this.tabMain.Tabs[1].TabPage.Visible = false;
                    this.tabMain.Tabs[2].TabPage.Visible = false;
                    this.tabMain.Tabs[3].TabPage.Visible = false;
                    this.tabMain.Tabs[4].TabPage.Visible = false;
                    this.tabMain.Tabs[5].TabPage.Visible = true;
                    this.tabMain.Tabs[0].TabPage.Hide();
                    this.tabMain.Tabs[1].TabPage.Hide();
                    this.tabMain.Tabs[2].TabPage.Hide();
                    this.tabMain.Tabs[3].TabPage.Hide();
                    this.tabMain.Tabs[4].TabPage.Hide();
                    this.tabMain.Tabs[5].TabPage.Show();

                    this.tabMain.SelectedTab = tabMain.Tabs[5];
                }
                else
                {
                    throw new Exception("ucArchivPlanung.showTab: iTab (=" + iTab.ToString() + ") not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.showTab: " + ex.ToString());
            }
        }

        public void setKlientenliste()
        {
            try
            {
                PMDS.GUI.GuiWorkflow.ShowKlienten();

            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.setKlientenliste: " + ex.ToString());
            }
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.GUI.GuiWorkflow.ShowKlienten();

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

        private void btnArchiv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setButtonsAktivDeaktiv(0);
                this.showTab(0);
                //this.showTab(3);

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

        private void btnTermine_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setButtonsAktivDeaktiv(1);
                this.showTab(4);
                this.loadData(GUI.VB.contPlanungData.eTypeUI.PlanKlienten, this._PlanArchive);

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
        private void btnMyTermine_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setButtonsAktivDeaktiv(2);
                this.showTab(4);
                this.loadData(GUI.VB.contPlanungData.eTypeUI.PlanMy, this._PlanArchive);

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
        private void btnTermineAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.setButtonsAktivDeaktiv(3);
                this.showTab(4);
                this.loadData(GUI.VB.contPlanungData.eTypeUI.PlansAll, this._PlanArchive);

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
        private void btnEMail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setButtonsAktivDeaktiv(4);

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



        public void setButtonsAktivDeaktiv(int aktivButton)
        {
            try
            {
                this._lastAktivButton = aktivButton;

                if (aktivButton == 0) 
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnArchiv, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">Archiv</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnArchiv, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }

                if (aktivButton == 1) 
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnTermineKlientenansicht, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">Termine</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnTermineKlientenansicht, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }

                if (aktivButton == 2) 
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnMyTermine, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">E-Mails</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnMyTermine, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }

                if (aktivButton == 3)
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnTermineAll, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">E-Mails</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnTermineAll, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }

                if (aktivButton == 4)
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnEMail, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">E-Mails</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnEMail, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }

                if (aktivButton == 5)
                {
                    PMDS.Global.UIGlobal.setAktiv(this.btnTermineBereiche, -1, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SkyBlue);
                    //this.lblInfo.Value = "<span style=" + (char)34 + "color:RoyalBlue; font-size:+7pt;" + (char)34 + ">E-Mails</span><br/><span style=" + (char)34 + "font-size:+2pt;" + (char)34 + ">" + infAuswahl + "</span><br/>";
                }
                else
                {
                    PMDS.Global.UIGlobal.setAktivDisable(this.btnTermineBereiche, -1, System.Drawing.Color.Black, System.Drawing.Color.Gainsboro, System.Drawing.Color.Black, System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.Flat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucArchivPlanung.setButtonsAktivDeaktiv: " + ex.ToString());
            }
        }

        private void btnTermineBereiche_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.initPlanBereich();

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

    }

}

