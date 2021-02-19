using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;



namespace PMDS.GUI
{
    
    public enum MedikationMode
    {
        MedVerschreiben1 = 0,
        MedVorbereiten2 = 1,
        MedVerabreichen3 = 2,
        MedBestellen4 = 3,
        Dekurs = 4,
        DekursBereich = 5,
        Print = 6
    }
    

    public partial class ucMedikamenteMain : QS2.Desktop.ControlManagment.BaseControl
    {

        public MedikationMode _currentMode = MedikationMode.MedVerschreiben1;
        private Guid                    _idaufenthalt   = Guid.Empty;
        public Control[] _aControls = { null, null, null, null, null, null, null };

        public event EventHandler ValueChanged;
        public event KlientenMehrfachAuswahlDelegate KlientenMehrfachAuswahl;
        
        public PMDS.GUI.ucSiteMapTermine _SitemapTermineDekurs = null;
        public PMDS.GUI.ucSiteMapTermine _SitemapTermineDekursBereich = null;

        public PMDS.GUI.Medikament.ucMed4Bestellen ucMedikamenteBestellen1  = null;
        public ucMedikamenteMainPicker ucMedikamenteMainPickerMain = null;
        public static bool LockActiveTabChanged = false;









        public ucMedikamenteMain()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                foreach (Infragistics.Win.UltraWinTabControl.UltraTab utc in tabMain.VisibleTabs)
                {
                    if (utc.Key == "MedikamentAbgeben")
                        utc.Text = ENV.MedikamenteAbgebenTabText;
                }
            }     
        }
        public void InitControl(MedikationMode mode, bool loadDekursBereich)
        {
            try
            {
                switch (mode)
                {
                    case MedikationMode.MedVerschreiben1:
                        _aControls[(int)mode] = new ucMed1Verschreiben();
                        ((ucMed1Verschreiben)_aControls[(int)mode]).ucMed1VerschreibenDetailAll.mainWindow = (ucMed1Verschreiben)_aControls[(int)mode];
                        _aControls[(int)mode].Dock = DockStyle.Fill;
                        ((ucMed1Verschreiben)_aControls[(int)mode]).ucMedikamenteStammdatenMain = this;
                        this.panelMedikamenteVerschreiben1.Controls.Add(_aControls[(int)mode]);
                        break;

                    case MedikationMode.MedVorbereiten2:
                        ucMed23VorbereitenVerabreichen ucM = new ucMed23VorbereitenVerabreichen();
                        //ucM.KlientenMehrfachAuswahl += new KlientenMehrfachAuswahlDelegate(uc_KlientenMehrfachAuswahl);
                        _aControls[(int)mode] = ucM;
                        ucM.ucMedikamenteStammdatenMain = this;
                        ucM.Dock = DockStyle.Fill;
                        this.panelMedikamenteVorbereiten2.Controls.Add(ucM);
                        break;

                    case MedikationMode.MedVerabreichen3:
                        ucMed23VorbereitenVerabreichen uc = new ucMed23VorbereitenVerabreichen();
                        uc.MODE = PMDS.BusinessLogic.MedikationListenMode.Abgabe;
                        _aControls[(int)mode] = uc;
                        uc.ucMedikamenteStammdatenMain = this;
                        uc.Dock = DockStyle.Fill;
                        this.panelMedikamenteVerabreichen3.Controls.Add(uc);
                        break;

                    case MedikationMode.MedBestellen4:
                        this.MedikamenteBestellen(mode);
                        break;

                    case MedikationMode.Dekurs:
                        this.initTermineDeskurs(mode, true);
                        break;

                    case MedikationMode.DekursBereich:
                        this.initTermineDeskurs(mode, true);
                        this.initTermineDeskursBereich(mode, loadDekursBereich);
                        break;

                    case MedikationMode.Print:
                        ucDynReports ucDynReports1 = new ucDynReports();
                        _aControls[(int)mode] = ucDynReports1;
                        _aControls[(int)mode].Dock = DockStyle.Fill;
                        ucDynReports1.Init(ENV.DYNREPORTMEDIKAMENTEPATH);
                        this.panelPrint.Controls.Add(_aControls[(int)mode]);
                        break;

                    default:
                        break;
                }

                //if (_aControls[(int)mode] != null)
                //{
                //    tabMain.Tabs[mode.ToString()].TabPage.Controls.Add(_aControls[(int)mode]);      // Dem Karteireiter hinzufügen
                //    _aControls[(int)mode].Dock = DockStyle.Fill;                                    // Alle Controls gedockt
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteStammdaten.InitControl: " + ex.ToString());
            }
        }

        public void MedikamenteBestellen(MedikationMode mode)
        {
            try
            {
                if (this.ucMedikamenteBestellen1 == null)
                {
                    this.ucMedikamenteBestellen1 = new Medikament.ucMed4Bestellen();
                    _aControls[(int)mode] = this.ucMedikamenteBestellen1;
                    _aControls[(int)mode].Dock = DockStyle.Fill;
                    this.ucMedikamenteBestellen1.ucMedikamenteStammdatenMain = this;
                    this.panelMedikamenteBestellen4.Controls.Add(this.ucMedikamenteBestellen1);
                    this.ucMedikamenteBestellen1.initControl();
                    //this.ucMedikamenteBestellen1.KlientenMehrfachAuswahl += new KlientenMehrfachAuswahlDelegate(uc_KlientenMehrfachAuswahl);
                }
                this.ucMedikamenteBestellen1.RefreshControl();
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteStammdaten.MedikamenteBestellen: " + ex.ToString());
            }
        }
        public void initTermineDeskurs(MedikationMode mode, bool doRefresh)
        {
            if (this._SitemapTermineDekurs == null)
            {
                this._SitemapTermineDekurs = new ucSiteMapTermine();

                PMDS.Global.eUITypeTermine UITypeTermine = new PMDS.Global.eUITypeTermine();
                UITypeTermine = PMDS.Global.eUITypeTermine.Dekurs;

                this._SitemapTermineDekurs.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi.Klientanansicht);
                this._SitemapTermineDekurs._TermineEx.ucMedikamenteStammdaten1 = this;

                this.ucMedikamenteMainPickerMain.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(this.ucMedikamenteMainPickerMain._SitemapTermine_PatientSelectionChanged);
                _aControls[(int)mode] = this._SitemapTermineDekurs._TermineEx;
                _aControls[(int)mode].Dock = DockStyle.Fill;
                this.panelDekurs.Controls.Add(this._SitemapTermineDekurs._TermineEx);
            }
            if (doRefresh)
            {
                this._SitemapTermineDekurs.RefreshTermin(false);
            }
        }
        public void initTermineDeskursBereich(MedikationMode mode, bool doRefresh)
        {
            if (this._SitemapTermineDekursBereich == null)
            {
                this._SitemapTermineDekursBereich = new ucSiteMapTermine( );

                PMDS.Global.eUITypeTermine UITypeTermine = new PMDS.Global.eUITypeTermine();
                UITypeTermine = PMDS.Global.eUITypeTermine.Dekurs;
                //GuiWorkflow.mainWindow.AddObject(this._SitemapTermineDekursBereich);
                
                this._SitemapTermineDekursBereich.initTermin(ref UITypeTermine, TerminlisteAnsichtsmodi.Bereichsansicht);
                this._SitemapTermineDekursBereich._TermineEx.ucMedikamenteStammdaten1 = this;

                this.ucMedikamenteMainPickerMain.PatientSelectionChanged += new ucSiteMapTermine.PatientSelectionChangedDelegate(this.ucMedikamenteMainPickerMain._SitemapTermine_PatientSelectionChanged);
                _aControls[(int)mode] = this._SitemapTermineDekursBereich._TermineEx;
                _aControls[(int)mode].Dock = DockStyle.Fill;
                this.panelDekursBereich.Controls.Add(this._SitemapTermineDekursBereich._TermineEx);
            }
            if (doRefresh)
            {
                this._SitemapTermineDekursBereich.RefreshTermin(false);
            }
        }

        



        private void tabMain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                if (tabMain.Focused)
                {
                    if (!ENV.AppRunning)
                    {
                        return;
                    }
                    if (ucMedikamenteMain.LockActiveTabChanged)
                    {
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;

                    ucMedikamenteMain.LockActiveTabChanged = true;
                    MedikationMode prevMode = this._currentMode;
                    MedikationMode actMode = (MedikationMode)Enum.Parse(typeof(MedikationMode), tabMain.SelectedTab.Key);
                    _currentMode = actMode;
                    this.ucMedikamenteMainPickerMain._actTab = actMode;
                    if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        this.ucMedikamenteMainPickerMain.SaveKlientenPicker();
                        if (!this.ucMedikamenteMainPickerMain.IsInModeMehrfachauswahl())
                        {
                            this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked = false;
                            this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Visible = false;
                            this.ucMedikamenteMainPickerMain.alleToolStripMenuItem.Visible = false;
                            this.ucMedikamenteMainPickerMain.keineToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            if (this.ucMedikamenteMainPickerMain.FirstTabChangeAfterChangeToBereichsansicht)
                            {
                                this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked = true;
                                this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Visible = true;
                                this.ucMedikamenteMainPickerMain._MehrfachauswahlSaved = true;

                                //this.ucMedikamenteMainPickerMain.ChangeMehrfachauswahl(this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked);
                                this.SetModeUIBereich(eUITypeDekurs.MehereKlienten);
                                this.ucMedikamenteMainPickerMain.SetTreeKlientenOnOff(true);
                                this.ucMedikamenteMainPickerMain.ClearSelectedPatient();
                                this.ucMedikamenteMainPickerMain.lstIDKlientenMehrfachauswahlSaved = this.ucMedikamenteMainPickerMain.GetSelectedKlienten();
                            }
                            else
                            {
                                this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked = this.ucMedikamenteMainPickerMain._MehrfachauswahlSaved;
                                this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Visible = true;

                                //this.ucMedikamenteMainPickerMain.ChangeMehrfachauswahl(this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked);
                                this.SetModeUIBereich(eUITypeDekurs.MehereKlienten);
                            }
                            this.ucMedikamenteMainPickerMain.alleToolStripMenuItem.Visible = true;
                            this.ucMedikamenteMainPickerMain.keineToolStripMenuItem.Visible = true;
                        }

                        this.ucMedikamenteMainPickerMain.GetSavedKlientenPickerAndLoadData(actMode, true, this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked, 
                                                                         this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Visible, false, false);
                    }
                    else
                    {
                        this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Checked = false;
                        this.ucMedikamenteMainPickerMain.cbMehrfachSelection.Visible = false;
                        //this.ucMedikamenteMainPickerMain.TreeSelectionChanged(false, false, true, false, this.ucMedikamenteMainPickerMain._IDPatient);
                        this.ucMedikamenteMainPickerMain.LoadData(false, null, true, false, null);
                    }

                    tabMain.SelectedTab = tabMain.Tabs[actMode.ToString()];
                    if (_aControls[(int)_currentMode] == null)
                    {
                        InitControl(actMode, false);
                    }
                    //this.LoadData(actMode);
                    this.ucMedikamenteMainPickerMain.FirstTabChangeAfterChangeToBereichsansicht = false;
                    ucMedikamenteMain.LockActiveTabChanged = false;
                }

            }
            catch (Exception ex)
            {
                ucMedikamenteMain.LockActiveTabChanged = false;
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void LoadData(MedikationMode actMode)
        {
            try
            {
                this.SwitchTo(actMode, true);

                //Neu nach 24.01.2008 MDA
                if (KlientenMehrfachAuswahl != null && ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    if (_currentMode == MedikationMode.MedVorbereiten2 || _currentMode == MedikationMode.MedVerabreichen3)
                        KlientenMehrfachAuswahl(PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl);
                    else
                        KlientenMehrfachAuswahl(false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("LoadData: " + ex.ToString());
            }
        }
        public void SwitchTo(MedikationMode mode, bool loadDekursBereich)
        {
            try
            {
                _currentMode = mode;
                this.SetModeUIBereich(ucMedikamenteMainPicker._UITypeDekurs);
                               
                if (_aControls[(int)_currentMode] == null)
                {
                    InitControl(mode, loadDekursBereich);
                }

                RefreshCurrentTab();
                this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                //this.SetModeUIBereich(ucMedikamenteMainPicker._UITypeDekurs);
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteStammdaten.SwitchTo: " + ex.ToString());
            }
        }
        public void RefreshCurrentTab()
        {
            try
            {
                if (CURRENTOBJECT == null)
                    return;

                if (this.ActiveControlIsReports())
                {
                    return;
                }
                if (this.ActiveControlIsMedikamenteBestellen())
                {
                    this.ucMedikamenteBestellen1.RefreshControl();
                    return;
                }
                if (this.ActiveControlIsDekurs())
                {
                    this._SitemapTermineDekurs.RefreshTermin(false);
                    return;
                }
                if (this.ActiveControlIsDekursBereich())
                {
                    this._SitemapTermineDekursBereich.RefreshTermin(false);
                    return;
                }

                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    ((IAufenthalt)CURRENTOBJECT).IDAufenthalt = _idaufenthalt;
                    this.setÄrtzDekursOnOff(true);
                }
                else
                {
                    if (CURRENTOBJECT.GetType().Equals(typeof(ucMed1Verschreiben)))
                    {
                        ucMed1Verschreiben ucMed1Verschreiben1 = (ucMed1Verschreiben)CURRENTOBJECT;
                        ucMed1Verschreiben1.IDAufenthalt = _idaufenthalt;
                        this.setÄrtzDekursOnOff(true);
                    }
                    else if (CURRENTOBJECT.GetType().Equals(typeof(ucMed23VorbereitenVerabreichen)))
                    {
                        ucMed23VorbereitenVerabreichen ucMed23VorbereitenVerabreichen1 = (ucMed23VorbereitenVerabreichen)CURRENTOBJECT;
                        ucMed23VorbereitenVerabreichen1.RefreshControl();
                        this.setÄrtzDekursOnOff(true);
                    }
                    else
                    {
                        throw new Exception("ucMedikamenteStammdaten.SwitchTo: CURRENTOBJECT.GetType() '" + CURRENTOBJECT.GetType().ToString() + "' not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteStammdaten.RefrechCurrentTab: " + ex.ToString());
            }
        }
        public void SetModeUIBereich(PMDS.Global.eUITypeDekurs UITypeDekurs)
        {
            try
            {
                ucMedikamenteMainPicker._UITypeDekurs = UITypeDekurs;
                Infragistics.Win.UltraWinTabControl.UltraTabControl tabTmp = (Infragistics.Win.UltraWinTabControl.UltraTabControl)this.tabMain;

                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Visible = true;
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()].Visible = true;
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs Einzel");

                    //if (ucMedikamenteMainPicker._UITypeDekurs == eUITypeDekurs.MehereKlienten)
                    //{
                    //    tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()].Visible = true;
                    //    if (tabTmp.ActiveTab == tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()])
                    //    {
                    //        tabTmp.ActiveTab = tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()];
                    //    }
                    //    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Visible = false;
                    //}
                    //else
                    //{
                    //    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Visible = true;
                    //    if (tabTmp.ActiveTab == tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()])
                    //    {
                    //        tabTmp.ActiveTab = tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()];
                    //    }
                    //    tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()].Visible = false;
                    //}
                }
                else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Visible = true;
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.DekursBereich.ToString()].Visible = false;
                    tabTmp.Tabs[PMDS.GUI.MedikationMode.Dekurs.ToString()].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedikamenteStammdaten.SetModeUIBereich: " + ex.ToString());
            }
        }
       
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
        {
            get { return _idaufenthalt; }
            set
            {
                _idaufenthalt = value;
                SwitchTo(_currentMode, false);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Undo()
        {
            if (CURRENTOBJECT == null)
                return;
            if (this.ActiveControlIsReports())
            {
                return;
            }
            ((ISave)CURRENTOBJECT).Undo();
        }
        public bool DataChanged
        {
            get
            {
                bool bSumChanged = false;
                //if (((ucRezeptEdit2)_aControls[(int)MedikationMode.Verordnungen]).IsChanged)
                //{
                //    bSumChanged = true;
                //}
                //if (((ucMedikation)_aControls[(int)MedikationMode.MedikamentVorbereiten]).IsChanged)
                //{

                //}
                //if (((ucMedikation)_aControls[(int)MedikationMode.MedikamentAbgeben]).IsChanged)
                //{

                //}

                if (CURRENTOBJECT == null)
                    return false;
                if (this.ActiveControlIsReports())
                {
                    return false;
                }
                if (((ISave)CURRENTOBJECT).IsChanged)
                {
                    bSumChanged = true;
                }

                return bSumChanged;
            }
        }
        

        public bool Save()
        {
            if (CURRENTOBJECT == null)
                return true;
            if (this.ActiveControlIsReports())
            {
                return true;
            }

            return ((ISave)CURRENTOBJECT).Save();
        }
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }
        

        
        void uc_KlientenMehrfachAuswahl(bool mehrfachauswahl)
        {
            if (KlientenMehrfachAuswahl != null)
            {
                KlientenMehrfachAuswahl(mehrfachauswahl); //Event weiterleiten
            }
        }
        public bool ActiveControlIsReports()
        {
            return CURRENTOBJECT.GetType().Name.ToString().Trim().Equals("ucDynReports", StringComparison.CurrentCultureIgnoreCase);
        }
        public bool ActiveControlIsMedikamenteBestellen()
        {
            if (this.tabMain.ActiveTab.Key.Trim().Equals(MedikationMode.MedBestellen4.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
                return false;
        }
        public bool ActiveControlIsDekurs()
        {
            if (this.tabMain.ActiveTab.Key.Trim().Equals(MedikationMode.Dekurs.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
                return false;
        }
        public bool ActiveControlIsDekursBereich()
        {
            if (this.tabMain.ActiveTab.Key.Trim().Equals(MedikationMode.DekursBereich.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
                return false;
        }
      
        private object CURRENTOBJECT
        {
            get
            {
                return _aControls[(int)_currentMode];
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            if (((ucMed1Verschreiben)_aControls[(int)MedikationMode.MedVerschreiben1]) != null)
                ((ucMed1Verschreiben)_aControls[(int)MedikationMode.MedVerschreiben1]).setControlsAktivDisable(bOn);
            if (((ucMed23VorbereitenVerabreichen)_aControls[(int)MedikationMode.MedVerabreichen3]) != null)
                ((ucMed23VorbereitenVerabreichen)_aControls[(int)MedikationMode.MedVerabreichen3]).setControlsAktivDisable(bOn);
            if (((ucMed23VorbereitenVerabreichen)_aControls[(int)MedikationMode.MedVorbereiten2]) != null)
                ((ucMed23VorbereitenVerabreichen)_aControls[(int)MedikationMode.MedVorbereiten2]).setControlsAktivDisable(bOn);
            //((ucRezeptEintrag)_aControls[(int)MedikationMode.RezeptAnfordern]).setControlsAktivDisable(bOn);
        }
        public  void setÄrtzDekursOnOff(bool onOff)
        {
            //tabMain.Tabs["Dekurs"].Visible = onOff;
        }

    }
}
