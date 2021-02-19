using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinTree;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    

    public partial class ucMedikamenteMainPicker: QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {

        public Guid                        _IDPatientMed = Guid.Empty;
        private Guid                        _IDAufenthalt = Guid.Empty;
        private bool                        _PatientChanged = false;

        public ucMedikamenteMain ucMedikamenteStammdaten1;
        public static PMDS.Global.eUITypeDekurs _UITypeDekurs = eUITypeDekurs.EinKlient;
        public static List<Guid> lstKlienten = new List<Guid>();
        public bool IsInitialized = false;
        public bool lockTree = false;

        public PMDS.UI.Sitemap.UIFct UIFct1 = new UI.Sitemap.UIFct();
        public event ucSiteMapTermine.PatientSelectionChangedDelegate PatientSelectionChanged;

        //Save Klienten-Picker
        public Guid _IDPatientSaved = System.Guid.Empty;
        public List<cTree> lstIDKlientenMehrfachauswahlSaved = new List<cTree>();
        public bool _MehrfachauswahlSaved = false;
        public MedikationMode _actTab = MedikationMode.MedVerschreiben1;

        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
        
        public class cTree
        {
            public bool bOn = false;
            public Nullable<Guid> IDPatient = null;
            public Nullable<Guid> IDAufenthalt = null;
        }

        public static bool FirstCallDoRefreshKlienten = true;
        public bool FirstTabChangeAfterChangeToBereichsansicht = true;

        public bool TreeClickLocked = false;










        public ucMedikamenteMainPicker()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
        }
        private void ucMedikamenteMainPicker_Load(object sender, EventArgs e)
        {

        }
        private void ucMedikamenteMainPicker_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        List<cTree> LstSelKlienten = new List<cTree>();
                        this.LoadData(this.cbMehrfachSelection.Checked, null, false, true, LstSelKlienten);
                    }
                    else
                    {
                        this.LoadData(false, null, false, false, null); 
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }




        public void InitControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
                    this.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(_SitemapTermine_PatientSelectionChanged);

                    this.cbMehrfachSelection.Visible = false;
                    this.alleToolStripMenuItem .Visible = false;
                    this.keineToolStripMenuItem.Visible = false;
                    
                    this.InitMedikamentenStammdaten();
                    this.ucMedikamenteStammdaten1.ucMedikamenteMainPickerMain = this;

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.InitControl:" + ex.ToString());
            }
        }
        public void InitMedikamentenStammdaten()
        {
            try
            {
                if (this.ucMedikamenteStammdaten1 == null)
                {
                    this.panelMedikamenteStammdaten.Controls.Clear();
                    this.ucMedikamenteStammdaten1 = new ucMedikamenteMain();
                    this.ucMedikamenteStammdaten1.Dock = DockStyle.Fill;
                    //this.ucMedikamenteStammdaten1.KlientenMehrfachAuswahl += new KlientenMehrfachAuswahlDelegate(ucMedikamenteStammdaten2_KlientenMehrfachAuswahl);
                    this.ucMedikamenteStammdaten1.ValueChanged += new System.EventHandler(this.OnValueChanged);
                    this.panelMedikamenteStammdaten.Controls.Add(this.ucMedikamenteStammdaten1);
                }                  
                this.panelKlienten.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.InitMedikamentenStammdaten: " + ex.ToString());
            }
        }




        public void ENV_ENVPatientIDChanged(Guid IdPatientToSelect, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            try
            {
                this._IDPatientMed = IdPatientToSelect;
                this._PatientChanged = true;

                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    return; 
                }
                if (this._IDPatientMed == null)
                {
                    throw new Exception("ucMedikamenteMainPicker.ENV_ENVPatientIDChanged: this._IDPatient == null not allowed!");
                }

                if (DataChanged)
                    AskForSave();

                if (this.Visible)
                {
                    this.LoadData(false, null, false, false, null);
                }
                else
                {
                    string xy = "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatientMed; }
            set
            {
                if (_IDPatientMed == value)
                {
                    return;  
                }
                _IDPatientMed = value;
                if (this._IDPatientMed == null)
                {
                    throw new Exception("ucMedikamenteMainPicker.IDPatient: this._IDPatientMed == null not allowed!");
                }
                _PatientChanged = true;
                if (this.Visible)
                {
                    this.LoadData(false, null, false, false, null); 
                } 
            }
        }




        public void GetSavedKlientenPickerAndLoadData(MedikationMode mode, bool RefreshControl, bool cbMehrfachONOFF, bool cbMehrfachSelectionVisible,
                                    bool OnlySave, bool SelectActivePatientFromTree)
        {
            try
            {
                this._actTab = mode;
                if (mode == MedikationMode.MedVerschreiben1 || mode == MedikationMode.Print || mode == MedikationMode.Dekurs)
                {
                    this.alleToolStripMenuItem.Visible = false;
                    this.keineToolStripMenuItem.Visible = false;

                    this.cbMehrfachSelection.Checked = false;
                    this.cbMehrfachSelection.Visible = false;
                    this.SetTreeKlientenOnOff(false);
                    if (this._IDPatientSaved != System.Guid.Empty)
                    {
                        this.SelectPatientInTree(this._IDPatientSaved);

                        Patient p = new Patient(this._IDPatientSaved);
                        this._IDAufenthalt = p.Aufenthalt.ID;
                        this.PatientSelectionChanged.Invoke(this._IDPatientSaved, this._IDAufenthalt);
                    }
                }
                else if (mode == MedikationMode.MedVorbereiten2 || mode == MedikationMode.MedVerabreichen3 ||
                        mode == MedikationMode.MedBestellen4 ||
                        mode == MedikationMode.DekursBereich)
                {
                    this.cbMehrfachSelection.Checked = this._MehrfachauswahlSaved;
                    this.cbMehrfachSelection.Visible = true;
                    this.alleToolStripMenuItem.Visible = this._MehrfachauswahlSaved;
                    this.keineToolStripMenuItem.Visible = this._MehrfachauswahlSaved;

                    this.SetTreeKlientenOnOff(false);
                    if (this.cbMehrfachSelection.Checked)
                    {
                        this.SelectListPatientInTree(this.lstIDKlientenMehrfachauswahlSaved);
                    }
                    else
                    {
                        this.SetTreeKlientenOnOff(false);
                        if (this._IDPatientSaved != System.Guid.Empty)
                        {
                            this.SelectPatientInTree(this._IDPatientSaved);
                            Patient p = new Patient(this._IDPatientSaved);
                            this._IDPatientMed = p.ID;
                            this._IDAufenthalt = p.Aufenthalt.ID;
                            this.PatientSelectionChanged.Invoke(this._IDPatientSaved, this._IDAufenthalt);
                        }
                    }
                }

                if (this._IDPatientMed != System.Guid.Empty)
                {
                    this.TreeSelectionChanged(false, this.cbMehrfachSelection.Checked, SelectActivePatientFromTree, false, this._IDPatientMed);
                }
                else
                {
                    this.TreeSelectionChanged(false, this.cbMehrfachSelection.Checked, SelectActivePatientFromTree, false, null);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.LoadData: " + ex.ToString());
            }
        }
        public void LoadData(bool Mehrfachauswahl, Nullable<System.Guid> IDPatientToSelect, bool ClickedFromTree, bool ChangeToBereichsansicht,
                                List<cTree> lstSelectedKlienten)
        {
            try
            {
                PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl = Mehrfachauswahl;
                PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten = new List<Guid>();
                PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt = new List<Guid>();
                ucMedikamenteMainPicker.lstKlienten = new List<Guid>();
                if (ucMedikamenteMainPicker.FirstCallDoRefreshKlienten)
                {
                    this._IDPatientSaved = System.Guid.Empty;
                    this.lstIDKlientenMehrfachauswahlSaved.Clear();
                }
                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    if (this._actTab == MedikationMode.DekursBereich)
                    {
                        this.ucMedikamenteStammdaten1._currentMode = MedikationMode.MedVerschreiben1;
                        this._actTab = MedikationMode.MedVerschreiben1;
                        if (this.ucMedikamenteStammdaten1._aControls[(int)this.ucMedikamenteStammdaten1._currentMode] == null)
                        {
                            this.ucMedikamenteStammdaten1.InitControl(this.ucMedikamenteStammdaten1._currentMode, false);
                        }
                        this.ucMedikamenteStammdaten1.tabMain.ActiveTab = this.ucMedikamenteStammdaten1.tabMain.Tabs[MedikationMode.MedVerschreiben1.ToString()];
                        this.ucMedikamenteStammdaten1.tabMain.SelectedTab = this.ucMedikamenteStammdaten1.tabMain.Tabs[MedikationMode.MedVerschreiben1.ToString()];
                    }

                    this.FirstTabChangeAfterChangeToBereichsansicht = false;
                    this.panelKlienten.Visible = false;
                    this.panelMedikamenteStammdaten.Visible = true;
                    if (_IDPatientMed == Guid.Empty)
                    {
                        throw new Exception("ucMedikamenteMainPicker.LoadData: _IDPatientMed == Guid.Empty !");
                        //return; 
                    }
                    Patient p = new Patient(this._IDPatientMed);
                    this._IDAufenthalt = p.Aufenthalt.ID;
                    PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Add(this._IDPatientMed);
                    ucMedikamenteMainPicker.lstKlienten = PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten;
                    PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Add(this._IDAufenthalt);
                    this.ucMedikamenteStammdaten1.IDAufenthalt = p.Aufenthalt.ID;
                }
                else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    if (ChangeToBereichsansicht)
                    {
                        if (!this.IsInModeMehrfachauswahl())
                        {
                            this.FirstTabChangeAfterChangeToBereichsansicht = ChangeToBereichsansicht;
                        }
                    }
                    if (this.IsInModeMehrfachauswahl() && !Mehrfachauswahl && !ClickedFromTree && ChangeToBereichsansicht)
                    {
                        Mehrfachauswahl = true;
                        PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl = true;
                        if (!this.cbMehrfachSelection.Checked)
                        {
                            this.cbMehrfachSelection.Checked = true;
                            this.ChangeMehrfachauswahl(this.cbMehrfachSelection.Checked);
                        }
                    }
                    this.panelKlienten.Visible = true;
                    if (ChangeToBereichsansicht)
                    {
                        if (ucMedikamenteMainPicker.FirstCallDoRefreshKlienten)
                        {
                            this.LoadTreeKlienten();
                            ucMedikamenteMainPicker.FirstCallDoRefreshKlienten = false;
                        }
                    }
                    if (Mehrfachauswahl)
                    {
                        if (ChangeToBereichsansicht)
                        {
                            lstSelectedKlienten = this.GetSelectedKlienten();
                            if (this._IDPatientMed != ENV.CurrentIDPatient)
                            {
                                this._IDPatientMed = ENV.CurrentIDPatient;
                            }
                            this._IDPatientSaved = this._IDPatientMed;
                            this.SetTreeKlientenOnOff(true);
                            lstSelectedKlienten = this.GetSelectedKlienten();

                            //this.cbMehrfachSelection.Checked = true;
                            this.cbMehrfachSelection.Visible = true;
                            //this._MehrfachauswahlSaved = true;
                        }

                        if (lstSelectedKlienten != null)
                        {
                            this.ClearSelectedPatient();
                            System.Guid NewGuid2 = System.Guid.NewGuid();
                            foreach (cTree tg in lstSelectedKlienten)
                            {
                                PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Add((Guid)tg.IDPatient);
                                PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Add((Guid)tg.IDAufenthalt);
                            }
                            ucMedikamenteMainPicker.lstKlienten = PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten;
                            PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Add(NewGuid2);
                            PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Add(NewGuid2); 
                            ucMedikamenteMainPicker.lstKlienten.Add(NewGuid2);

                            if (lstSelectedKlienten.Count == 0)
                            {
                                this.panelMedikamenteStammdaten.Visible = false;
                            }
                            else
                            {
                                this.panelMedikamenteStammdaten.Visible = true;
                                this.ucMedikamenteStammdaten1.LoadData(this._actTab);
                            }
                        }
                        else
                        {
                            this.panelMedikamenteStammdaten.Visible = false;
                        }
                    }
                    else
                    {
                        if (ChangeToBereichsansicht)
                        {
                            if (ucMedikamenteMainPicker.FirstCallDoRefreshKlienten)
                            {
                                this.LoadTreeKlienten();
                                ucMedikamenteMainPicker.FirstCallDoRefreshKlienten = false;
                            }
                            this.SetTreeKlientenOnOff(false);
                            this._IDPatientMed = ENV.CurrentIDPatient;
                            this._IDPatientSaved = this._IDPatientMed;
                            if (ENV.CurrentIDPatient != System.Guid.Empty)
                            {
                                this.SelectPatientInTree(this._IDPatientMed);
                            }
                            else if (this._IDPatientSaved != System.Guid.Empty)
                            {
                                //this._IDPatient = this._IDPatientSaved;
                                //this.SelectPatientInTree(this._IDPatient);
                            }
                        }
                        else
                        {
                            this._IDPatientMed = (Guid)IDPatientToSelect;
                            if (this._IDPatientMed != Guid.Empty)
                            {
                                Patient p = new Patient(this._IDPatientMed);
                                this._IDAufenthalt = p.Aufenthalt.ID;
                                PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Add(this._IDPatientMed);
                                ucMedikamenteMainPicker.lstKlienten = PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten;
                                PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Add(this._IDAufenthalt);

                                this.PatientSelectionChanged.Invoke(this._IDPatientMed, p.Aufenthalt.ID);
                            }
                        }

                        if (this._IDPatientMed == Guid.Empty)
                        {
                            //throw new Exception("ucMedikamenteMainPicker.LoadData: this._IDPatientMed == null not allowed!");
                            this.panelMedikamenteStammdaten.Visible = false;
                        }
                        else
                        {
                            if (ENV.CurrentIDPatient != System.Guid.Empty)
                            {
                                this.SelectPatientInTree(this._IDPatientMed);
                            }
                            this.panelMedikamenteStammdaten.Visible = true;
                            Patient p = new Patient(IDPatient);
                            this._IDAufenthalt = p.Aufenthalt.ID;

                            PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Clear();
                            PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Clear();

                            PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Add(this._IDPatientMed);
                            ucMedikamenteMainPicker.lstKlienten = PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten;
                            PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Add(this._IDAufenthalt);                         
                            this.ucMedikamenteStammdaten1.IDAufenthalt = p.Aufenthalt.ID;
                        } 
                    }

                }
                else
                {
                    throw new Exception("ucMedikamenteMainPicker.LoadData: ENV.AnsichtsModus '" + ENV.AnsichtsModus.ToString() + "' not allowed!");
                }               


                //if (tabKlientenxyxy.ActiveTab != null && tabKlientenxyxy.ActiveTab.Key != "")
                //{
                //    Patient p = new Patient(new Guid(tabKlientenxyxy.ActiveTab.Key));
                //    List<Guid> list = new List<Guid>();
                //    list.Add(p.ID);

                //    //ENV.CurrentIDPatient = p.ID;
                //    this.ucMedikamenteStammdaten1.SetModeUI(ucMedikamenteMainPicker._UITypeDekurs);
                //    if (!PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl && this.ucMedikamenteStammdaten1.IDAufenthalt != p.Aufenthalt.ID)
                //    {
                //        ENV.IDAUFENTHALT = this.ucMedikamenteStammdaten1.IDAufenthalt;
                //        if (ENV.doPatientFromTermineBereich && ENV.CurrentIDPatient != System.Guid.Empty)
                //        {
                //            //this.SelectPatient(ENV.CurrentIDPatient);
                //        }
                //        else
                //        {
                //            ENV.CurrentIDPatient = p.ID;
                //        }
                //        this.ucMedikamenteStammdaten1.IDAufenthalt = p.Aufenthalt.ID;
                //    }
                //    else
                //    {
                //        if (ENV.doPatientFromTermineBereich && ENV.CurrentIDPatient != System.Guid.Empty)
                //        {
                //            //this.SelectPatient(ENV.CurrentIDPatient);
                //        }
                //        else
                //        {
                //            ENV.CurrentIDPatient = p.ID;
                //        }
                //        this.ucMedikamenteStammdaten1.RefreshControl(list);
                //    }

                //    ENV.sendPatientChanged(eCurrentPatientChange.keiner);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.LoadData:" + ex.ToString());
            }
        }

        public void SaveKlientenPicker()
        {
            try
            {
                if (this.cbMehrfachSelection.Visible && this.cbMehrfachSelection.Checked)
                {
                    this._MehrfachauswahlSaved = this.cbMehrfachSelection.Checked;
                    this.lstIDKlientenMehrfachauswahlSaved.Clear();
                    this.lstIDKlientenMehrfachauswahlSaved = this.GetSelectedKlienten();
                }
                else if (this.cbMehrfachSelection.Visible && !this.cbMehrfachSelection.Checked)
                {
                    this._MehrfachauswahlSaved = this.cbMehrfachSelection.Checked;
                    this._IDPatientSaved = this._IDPatientMed;
                }
                else
                {
                    //this._MehrfachauswahlSaved = this.cbMehrfachSelection.Checked;
                    this._IDPatientSaved = this._IDPatientMed;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.SaveKlientenPicker: " + ex.ToString());
            }
        }

        public bool IsInModeMehrfachauswahl()
        {
            try
            {
                if (this._actTab == MedikationMode.MedVerschreiben1 || this._actTab == MedikationMode.Print || this._actTab == MedikationMode.Dekurs)
                {
                    return false;
                }
                else if (this._actTab == MedikationMode.MedVorbereiten2 || this._actTab == MedikationMode.MedVerabreichen3 ||
                        this._actTab == MedikationMode.MedBestellen4 ||
                        this._actTab == MedikationMode.DekursBereich)
                {
                    return true;
                }
                else
                {
                    throw new Exception("ucMedikamenteMainPicker.IsInModeMehrfachauswahl: this._LastTab '" + this._actTab.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.IsInModeMehrfachauswahl: " + ex.ToString());
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DataChanged
        {
            get 
            {
                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                    return this.ucMedikamenteStammdaten1.DataChanged; 
                else
                    return this.ucMedikamenteStammdaten1.DataChanged; 
            }
        }
        
        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ENV_UserLoggedOn: " + ex.ToString());
            }
        }
        void OnValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.OnValueChanged: " + ex.ToString());
            }
        }
        public void _SitemapTermine_PatientSelectionChanged(Guid IDPatient, Guid IDAufenthalt)
        {
            //ENV.IDAUFENTHALT = IDAufenthalt;
            System.Guid idAuf = PMDS.BusinessLogic.Aufenthalt.LastByPatient(IDPatient);
            ENV.setIDAUFENTHALT = idAuf;
            ENV.setCurrentIDPatient = IDPatient;
            ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, false);
            //if (PMDS.Global.historie.HistorieOn)
            //{
            //    PMDS.Global.historie.IDAufenthalt = ucPatientPicker1.CURRENT_IDAufenhalt;
            //}
        }



        #region IPMDSGUIObject Members
        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {
            // Do Nothing
        }
        public Control CONTROL
        {
            get { return this; }
        }
        public void Undo()
        {
            if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                this.ucMedikamenteStammdaten1.Undo();
            else
                this.ucMedikamenteStammdaten1.Undo();
        }
        public bool Save()
        {
            return true;
        }
        public string AREA
        {
            get { return ENV.String("GUI_AREA_SITEMAP_START"); }
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
                _framework.HEADER.action(false);
                _framework.HEADER.ShowOnlyHeader(true);  

                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);
            }
            catch (Exception ex)
            {
                _framework.HEADER.ShowControlAndHeader(true);
                ENV.HandleException(ex);
            }
            finally
            {
                _framework.HEADER.action(true);
            }
        }
        public void DetachFramework()
        {
            if (DataChanged)
            {

                AskForSave();
                return;
            }

            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);
        }
        public void ProcessKeyEvent(KeyEventArgs e)
        {

        }

        #endregion

        private void AskForSave()
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    Undo();
                }
                else
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                                ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                                MessageBoxButtons.YesNo,
                                                                                                MessageBoxIcon.Question, true);     

                    if (res == DialogResult.Yes)
                        ProcessSave();
                    else
                        Undo();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.AskForSave: " + ex.ToString());
            }
        }
        private void ProcessSave()
        {
            try
            {
                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                    this.ucMedikamenteStammdaten1.Save();
                else
                    this.ucMedikamenteStammdaten1.Save();

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ProcessSave: " + ex.ToString());
            }
        }

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.cbMehrfachSelection.Checked)
                {
                    throw new Exception("alleToolStripMenuItem_Click: !this.cbMehrfachSelection.Checked!");
                }
                this.TreeSelectionChanged(true, this.cbMehrfachSelection.Checked, false, true, null);

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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.cbMehrfachSelection.Checked)
                {
                    throw new Exception("keineToolStripMenuItem_Click: !this.cbMehrfachSelection.Checked!");
                }
                this.TreeSelectionChanged(true, this.cbMehrfachSelection.Checked, false, false, null);

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

        public void TreeSelectionChanged(bool MehrfachauswahlChanged, bool Mehrfachauswahl, bool SelectActivePatientFromTree,
                                         bool MehrfachauswahlAlleklientenONOFF, Nullable<Guid> IDPatientToSelect)
        {
            try
            {
                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    throw new Exception("TreeSelectionChanged: ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht not allowed!");
                }
                PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl = Mehrfachauswahl;

                if (MehrfachauswahlChanged && Mehrfachauswahl)
                {
                    this.SetTreeKlientenOnOff(MehrfachauswahlAlleklientenONOFF);
                    List<cTree> lstSelectedKlienten = this.GetSelectedKlienten();
                    this.LoadData(true, null, true, false, lstSelectedKlienten);
                }
                else if (!MehrfachauswahlChanged && Mehrfachauswahl)
                {
                    List<cTree> lstSelectedKlienten = this.GetSelectedKlienten();
                    this.LoadData(true, null, true, false, lstSelectedKlienten);
                }
                else if (!Mehrfachauswahl)
                {
                    System.Guid IDPatientTmp = System.Guid.Empty;
                    if (SelectActivePatientFromTree)
                    {
                        if (this.treeKlienten.ActiveNode != null)
                        {
                            cTree tg = (cTree)this.treeKlienten.ActiveNode.Tag;
                            IDPatientTmp = (Guid)tg.IDPatient;
                            this._IDPatientSaved = IDPatientTmp;
                        }
                        else
                        {
                            //throw new Exception("TreeSelectionChanged: this.treeKlienten.ActiveNode == null not allowed!");
                        }
                    }
                    else
                    {
                        
                    }
                    if (IDPatientToSelect != null)
                    {
                        IDPatientTmp = (Guid)IDPatientToSelect;
                    }
                    this.LoadData(false, IDPatientTmp, true, false, null);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.TreeSelectionChanged: " + ex.ToString());
            }
        }

        public void ChangeMehrfachauswahl(bool bMehrfachauswahlOn)
        {
            try
            {
                //bool MehrFachONOFF = !bMehrfachauswahlOn;
                //bool MehrFachVisibleONOFF = this.cbMehrfachSelection.Visible;
                //this.ChangeTab(this._LastTab, false, ref MehrFachONOFF, ref MehrFachVisibleONOFF, true);

                Nullable<Guid> IDPatientTmp = null;
                this.alleToolStripMenuItem.Visible = bMehrfachauswahlOn;
                this.keineToolStripMenuItem.Visible = bMehrfachauswahlOn;

                if (bMehrfachauswahlOn)
                {
                    this.SetTreeKlientenOnOff(true);
                    this.ClearSelectedPatient();
                }
                else
                {
                    this.SetTreeKlientenOnOff(false);
                    if (this._IDPatientSaved != System.Guid.Empty)
                    {
                        this._IDPatientMed = this._IDPatientSaved;
                        this.SelectPatientInTree(this._IDPatientMed);
                        IDPatientTmp = this._IDPatientMed;
                    }
                }
                if (bMehrfachauswahlOn)
                {
                    this.ucMedikamenteStammdaten1.SetModeUIBereich(eUITypeDekurs.MehereKlienten);
                }
                else
                {
                    this.ucMedikamenteStammdaten1.SetModeUIBereich(eUITypeDekurs.EinKlient);
                }
                this.TreeSelectionChanged(true, bMehrfachauswahlOn, false, bMehrfachauswahlOn, IDPatientTmp);

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ChangeMehrfauswahl: " + ex.ToString());
            }
        }

        private void treeKlienten_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    //if (this.UIFct1.evClickOKTree(ref sender, ref e, ref this.treeKlienten))
            //    //{
            //    //    this.treeKlientenClick();
            //    //}

            //}
            //catch (Exception ex)
            //{
            //    ENV.HandleException(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
        private void treeKlienten_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIFct1.evClickOKTreeMouse(ref sender, ref e, ref this.treeKlienten))
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        this.treeKlientenClick();
                    }
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
        public void treeKlientenClick()
        {
            try
            {
                if (this.treeKlienten.Focused)
                {
                    if (this.treeKlienten.ActiveNode != null)
                    {
                        this.treeClickedChanged(this.treeKlienten.ActiveNode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.treeKlientenClick: " + ex.ToString());
            }
        }

        public void treeClickedChanged(UltraTreeNode TreeNode)
        {
            try
            {
                if (this.TreeClickLocked)
                {
                    return;
                }

                this.TreeClickLocked = true;
                Guid IDPatientSel = new System.Guid(TreeNode.Key);
                if (this.cbMehrfachSelection.Checked)
                {
                    cTree tg = (cTree)this.treeKlienten.ActiveNode.Tag;
                    if (tg.bOn)
                    {
                        this.SetNodeOnOff(false, TreeNode);
                    }
                    else
                    {
                        this.SetNodeOnOff(true, TreeNode);
                    }
                }
                else
                {
                    this.SetTreeKlientenOnOff(false);
                    this.SetNodeOnOff(true, TreeNode);
                }
                this.TreeSelectionChanged(false, this.cbMehrfachSelection.Checked, true, false, null);
                this.TreeClickLocked = false;

            }
            catch (Exception ex)
            {
                this.TreeClickLocked = false;
                throw new Exception("ucMedikamenteMainPicker.treeKlienten_AfterCheck: " + ex.ToString());
            }
        }

        private void cbMehrfachSelection_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cbMehrfachSelection.Focused)
                {
                    this.ChangeMehrfachauswahl(this.cbMehrfachSelection.Checked);
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
                this._IDPatientMed = System.Guid.Empty;
                this._IDAufenthalt = System.Guid.Empty;
                this.PatientSelectionChanged.Invoke(ENV.CurrentIDPatient, ENV.IDAUFENTHALT);

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.ClearSelectedPatient: " + ex.ToString());
            }
        }


        #region Tree
        public void SelectPatientInTree(System.Guid IDPatientToSelect)
        {
            try
            {
                foreach (UltraTreeNode treeNode in this.treeKlienten.Nodes)
                {
                    cTree tg = (cTree)treeNode.Tag;
                    if (tg.IDPatient == IDPatientToSelect)
                    {
                        this.SetNodeOnOff(true, treeNode);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.SelectPatientInTree: " + ex.ToString());
            }
        }
        public void SelectListPatientInTree(List<cTree> lstPatientSelected)
        {
            try
            {
                foreach (UltraTreeNode treeNode in this.treeKlienten.Nodes)
                {
                    cTree tg = (cTree)treeNode.Tag;
                    foreach(cTree tgLstToSelect in lstPatientSelected)
                    {
                        if (tg.IDPatient == tgLstToSelect.IDPatient)
                        {
                            this.SetNodeOnOff(true, treeNode);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.SelectPatientInTree: " + ex.ToString());
            }
        }

        private void LoadTreeKlienten()
        {
            try
            {
                //if (ENV.AnsichtsModus != TerminlisteAnsichtsmodi.Bereichsansicht)
                //    return;

                //// mda:16.10.2007 
                //if ((ENV.CurrentAnsichtinfo.IDAbteilung != Guid.Empty && ENV.CurrentAnsichtinfo.IDAbteilung == _IDAbteilung &&
                //    ENV.CurrentAnsichtinfo.IDBereich == _IDBereich) || 
                //    (ENV.CurrentAnsichtinfo.IDAbteilung == Guid.Empty && ENV.CurrentUserAbteilungen.ToArray() == _listUserAbteilungen)
                //   )
                //{
                //    RefreshCurrentTab();        // mda:16.10.2007 
                //    SetMode();
                //    InitTabSelection(); //Alte Auswahl wiederherstellen
                //    ucMedikamenteStammdaten2.RefreshControl(GetSelectedTabs());
                //    return;
                //}
                PMDS.GUI.Medikament.cMedListKlienten._lIDKlienten.Clear();
                this.treeKlienten.Nodes.Clear();
                //_IDAbteilungxy = ENV.CurrentAnsichtinfo.IDAbteilung;
                //_IDBereichxy = ENV.CurrentAnsichtinfo.IDBereich;
                //_listUserAbteilungenxy = ENV.CurrentUserAbteilungen.ToArray();

                dsPatientStation.PatientDataTable t = GuiUtil.GetKlientenforCurrentSelection(false, PMDS.Global.ENV.IDKlinik);     // 18.10.2007 RBU: Routine von mda ausgelagert
                foreach (dsPatientStation.PatientRow r in t)
                {

                    if (ENV.CurrentAnsichtinfo.IDAbteilung.Equals(System.Guid.Empty) && ENV.CurrentAnsichtinfo.IDBereich.Equals(System.Guid.Empty))
                    {
                        AddTab(r);
                    }
                    else if (ENV.CurrentAnsichtinfo.IDAbteilung.Equals(System.Guid.Empty) && !ENV.CurrentAnsichtinfo.IDBereich.Equals(System.Guid.Empty))
                    {
                        if (r.IDBereich.Equals(ENV.CurrentAnsichtinfo.IDBereich))
                        {
                            AddTab(r);
                        }
                    }
                    else if (!ENV.CurrentAnsichtinfo.IDAbteilung.Equals(System.Guid.Empty) && !ENV.CurrentAnsichtinfo.IDBereich.Equals(System.Guid.Empty))
                    {
                        if (r.IDAbteilung.Equals(ENV.CurrentAnsichtinfo.IDAbteilung) && r.IDBereich.Equals(ENV.CurrentAnsichtinfo.IDBereich))
                        {
                            AddTab(r);
                        }
                    }
                    else if (!ENV.CurrentAnsichtinfo.IDAbteilung.Equals(System.Guid.Empty) && ENV.CurrentAnsichtinfo.IDBereich.Equals(System.Guid.Empty))
                    {
                        if (r.IDAbteilung.Equals(ENV.CurrentAnsichtinfo.IDAbteilung))
                        {
                            AddTab(r);
                        }
                    }

                }
        
                this.SetTreeKlientenOnOff(false);
                this.treeKlienten.ActiveNode = null;
                this.treeKlienten.SelectedNodes.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.LoadTreeKlienten: " + ex.ToString());
            }
        }
        
        public List<cTree> GetSelectedKlienten()
        {
            try
            {
                List<cTree> list = new List<cTree>();
                foreach (UltraTreeNode treeNode in this.treeKlienten.Nodes)
                {
                    cTree tg = (cTree)treeNode.Tag;
                    if (tg.bOn)
                    {
                        list.Add(tg); 
                    }
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.GetSelectedKlienten: " + ex.ToString());
            }
        }
        
        public void SetTreeKlientenOnOff(bool bOn)
        {
            try
            {
                foreach (UltraTreeNode treeNode in  this.treeKlienten.Nodes)
                {
                    if (bOn)
                    {
                        this.SetNodeOnOff(true, treeNode);
                    }
                    else
                    {
                        this.SetNodeOnOff(false, treeNode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.SetTreeKlientenOnOff: " + ex.ToString());
            }
        }

        private void AddTab(dsPatientStation.PatientRow r)
        {
            try
            {
                UltraTreeNode nodeTree = this.treeKlienten.Nodes.Add(r.ID.ToString(), r.Name.Trim());
                cTree tg = new cTree();
                tg.IDPatient = r.ID;
                Patient p = new Patient(r.ID);

                tg.IDAufenthalt = p.Aufenthalt.ID;
                tg.bOn = false;
                nodeTree.Tag = tg;

                this.SetNodeOnOff(false, nodeTree);
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.AddTab: " + ex.ToString());
            }
        }

        public void SetNodeOnOff(bool bOn, UltraTreeNode treeNode)
        {
            try
            {
                cTree tg = (cTree)treeNode.Tag;
                if (bOn)
                {
                    tg.bOn = true;
                    treeNode.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, QS2.Resources.getRes.ePicTyp.ico);
                    treeNode.Override.ActiveNodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, QS2.Resources.getRes.ePicTyp.ico);
                }
                else
                {
                    tg.bOn = false;
                    //treeNode.Override.NodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, QS2.Resources.getRes.ePicTyp.ico);
                    //treeNode.Override.ActiveNodeAppearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, QS2.Resources.getRes.ePicTyp.ico);
                    treeNode.Override.NodeAppearance.Image = null;
                    treeNode.Override.ActiveNodeAppearance.Image = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteMainPicker.SetNodeOnOff: " + ex.ToString());
            }
        }

        #endregion

    }
}
