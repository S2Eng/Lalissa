using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI.Admin
{

    
    public partial class ucStammdaten : QS2.Desktop.ControlManagment.BaseControl 
    {
        private StammdatenMode _currentMode = StammdatenMode.Leistungskatalog ;
        private Control[] _aControls = { null, null, null, null, null };
        private UltraTab _CurrentTab;
        private bool _ContentChenged = false;
        
        private PMDS.UI.Sitemap.UIFct _sitemap = new PMDS.UI.Sitemap.UIFct();
        private List<PMDS.UI.Sitemap.cButt> listButt = new List<PMDS.UI.Sitemap.cButt>();
        private bool loaded = false;
        

        private ucLeistungskatalog  ucLeistungskatalog1;
        private ucSonderleistungsKatalog ucSonderleistungsKatalog1;
        private ucKostenträger ucKostentraeger1;
        private PMDS.GUI.BaseControls.ucBelegung ucBelegung1;
        private PMDS.GUI.BaseControls.ucEssen ucEssen1;
    



        public enum StammdatenMode
        {
            Leistungskatalog = 0,
            Sonderleistungen = 1,
            Kostentraeger = 2,
            Betten = 3,
            Essen = 4
        }

        public ucStammdaten()
        {
            InitializeComponent();
        }

        public void  initControl()
        {
            this.tabMain.Style = UltraTabControlStyle.Wizard;
            this.setUIButtons();
            SwitchTo(_currentMode);

            PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);
            this.loaded = true;
        }

        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {

        }

        public void Save(out bool retOK)
        {
            bool eRet1 = true;
            retOK = true;

            try
            {
                if (this.tabMain.ActiveTab.Key == "Essen")
                {
                    if (ucEssen1 != null)
                    {
                        ucEssen1.Write();
                        _ContentChenged = false;
                        EnableDisableButtons();
                    }
                }
                else if (this.tabMain.ActiveTab.Key == "Betten")
                {
                    if (ucBelegung1 != null)
                    {
                        ucBelegung1.Save();
                        _ContentChenged = false;
                        EnableDisableButtons();
                    }
                }
                else if (this.tabMain.ActiveTab.Key == "Kostentraeger")
                {
                    if (ucKostentraeger1  != null)
                    {
                        if (ucKostentraeger1.IsChanged)
                        {
                            if (ucKostentraeger1.Save())
                            {
                                _ContentChenged = false;
                                EnableDisableButtons();
                                retOK = true;
                            }
                            else
                            {
                                retOK = false;
                            }
                        }
                        else
                        {
                            _ContentChenged = false;
                            EnableDisableButtons();
                        }
                    }
                }
                else 
                {
                    foreach (Control c in _aControls)
                    {
                        if (c == null) continue;

                        if (c is ISave)
                        {
                            if (((ISave)c).IsChanged)
                                eRet1 = ((ISave)c).Save();
                        }

                        if (!eRet1) break;
                    }

                    if (eRet1)
                    {
                        _ContentChenged = false;
                        EnableDisableButtons();
                    }
                }
            }
            catch(Exception e)
            {
                ENV.HandleException(e);
            }
        }

        public void Undo()
        {
            _ContentChenged = false;

            if (this.tabMain.ActiveTab.Key == "Essen")
            {
                if (ucEssen1 != null)
                    ucEssen1.RefreshGrid();
            }
            else if (this.tabMain.ActiveTab.Key == "Betten")
            {
                if (ucBelegung1 != null)
                    ucBelegung1.RefreshGrid();
            }
            else if (this.tabMain.ActiveTab.Key == "Kostentraeger")
            {
                if (ucKostentraeger1 != null)
                    ucKostentraeger1.RefreshControl();
            }
            else
            {
                foreach (Control c in _aControls)
                {
                    if (c == null) continue;

                    if (c is ISave)
                    {
                        if (((ISave)c).IsChanged)
                            ((ISave)c).Undo();
                    }
                }
            }
            EnableDisableButtons();
        }

        public void RefreshControl()
        {
            _ContentChenged = false;

            if (this.tabMain.ActiveTab.Key == "Essen")
            {
                if (ucEssen1 != null)
                    ucEssen1.RefreshGrid();
            }
            else if (this.tabMain.ActiveTab.Key == "Betten")
            {
                if (ucBelegung1 != null)
                    ucBelegung1.RefreshGrid();
            }
            else
            {
                if (_currentMode == StammdatenMode.Kostentraeger)
                    this.ucKostentraeger1.RefreshControl();
                else if (_currentMode == StammdatenMode.Leistungskatalog)
                    this.ucLeistungskatalog1.RefreshControl();
                else if (_currentMode == StammdatenMode.Sonderleistungen)
                    this.ucSonderleistungsKatalog1.RefreshControl();
            }

            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            btnSave.Enabled = _ContentChenged;
            btnUndo.Enabled = _ContentChenged;
        }

        public void SwitchTo(StammdatenMode mode)
        {
            _currentMode = mode;
            tabMain.SelectedTab = tabMain.Tabs[mode.ToString()];
            _CurrentTab = tabMain.SelectedTab;

            if (_aControls[(int)_currentMode] == null)
                InitControl(mode);

        }

        private void InitControl(StammdatenMode mode)
        {
            switch (mode)
            {
                case StammdatenMode.Leistungskatalog:
                    if (this.ucLeistungskatalog1 == null) this.initLeistungskatalog();
                    _aControls[(int)mode] = ucLeistungskatalog1;
                    break;
                case StammdatenMode.Sonderleistungen:
                    if (this.ucSonderleistungsKatalog1 == null) this.initSonderleistungsKatalog();
                    _aControls[(int)mode] = ucSonderleistungsKatalog1;
                    break;
                case StammdatenMode.Kostentraeger:
                    if (this.ucKostentraeger1 == null) this.initKostentraeger();
                    _aControls[(int)mode] = ucKostentraeger1;
                    break;
                case StammdatenMode.Betten:
                    if (this.ucBelegung1 == null) this.initBelegung();
                    _aControls[(int)mode] = ucBelegung1;
                    break;
                case StammdatenMode.Essen:
                    if (this.ucEssen1 == null) this.initEssen();
                    _aControls[(int)mode] = ucEssen1;
                    break;
                default:
                    break;
            }
        }

        public void initLeistungskatalog()
        {
            this.ucLeistungskatalog1 = new  ucLeistungskatalog();
            this.ucLeistungskatalog1.Dock = DockStyle.Fill;
            this.ucLeistungskatalog1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelLeistungskatalog.Controls.Add(this.ucLeistungskatalog1);
            this.ucLeistungskatalog1.initControl();
        }
        public void initSonderleistungsKatalog()
        {
            this.ucSonderleistungsKatalog1 = new ucSonderleistungsKatalog();
            this.ucSonderleistungsKatalog1.Dock = DockStyle.Fill;
            this.ucSonderleistungsKatalog1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelSonderleistungen.Controls.Add(this.ucSonderleistungsKatalog1);
            this.ucSonderleistungsKatalog1.initControl();
        }
        public void initKostentraeger()
        {
            this.ucKostentraeger1 = new ucKostenträger();
            this.ucKostentraeger1.Dock = DockStyle.Fill;
            this.ucKostentraeger1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucKostentraeger1.stateToSaved += new System.EventHandler(this.uc_isSaved);
            this.panelKostenträger .Controls.Add(this.ucKostentraeger1);
            this.ucKostentraeger1.initControl();
        }
        public void initBelegung()
        {
            this.ucBelegung1 = new PMDS.GUI.BaseControls.ucBelegung ();
            this.ucBelegung1.Dock = DockStyle.Fill;
            this.ucBelegung1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucBelegung1.ValueSaved  += new System.EventHandler(this.uc_undo );
            this.ucBelegung1.initControl();
            this.panelBetten.Controls.Add(this.ucBelegung1);
        }
        public void initEssen()
        {
            this.ucEssen1 = new PMDS.GUI.BaseControls.ucEssen();
            this.ucEssen1.Dock = DockStyle.Fill;
            this.ucEssen1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucEssen1.ValueSaved += new System.EventHandler(this.uc_undo);
            this.ucEssen1.initControl();
            this.panelEssen.Controls.Add(this.ucEssen1);
        }

        private object CURRENTOBJECT
        {
            get
            {
                return _aControls[(int)_currentMode];
            }
        }

        private void tabMain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (!this.loaded) return;
            //Save();
            SwitchTo((StammdatenMode)Enum.Parse(typeof(StammdatenMode), tabMain.SelectedTab.Key));
        }

        private void tabMain_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
        {
            if (!this.loaded) return;
            //    if ((StammdatenMode)Enum.Parse(typeof(StammdatenMode), _CurrentTab.Key) == StammdatenMode.Essen)
            //        ucEssen1.Write();
            //    else if ((StammdatenMode)Enum.Parse(typeof(StammdatenMode), _CurrentTab.Key) == StammdatenMode.Betten)
            //        ucBelegung1.Save();
        }

        private void uc_ValueChanged(object sender, EventArgs e)
        {
            _ContentChenged = true;
            EnableDisableButtons();
        }
        private void uc_isSaved(object sender, EventArgs e)
        {
            _ContentChenged = false;
            EnableDisableButtons();
        }
        private void uc_undo(object sender, EventArgs e)
        {
            _ContentChenged = false;
            EnableDisableButtons();
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Undo();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Save(out bool retOK);
                if (retOK)
                {
                    this.RefreshControl();
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

       private void setUIButtons()
        {
            PMDS.UI.Sitemap.cButt itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnLeistungskatalog ;
            itm.nr = Convert.ToInt32(this.btnLeistungskatalog.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnSonderleistungen;
            itm.nr = Convert.ToInt32(this.btnSonderleistungen .Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnKostenträger ;
            itm.nr = Convert.ToInt32(this.btnKostenträger.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnBetten  ;
            itm.nr = Convert.ToInt32(this.btnBetten.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnEssen;
            itm.nr = Convert.ToInt32(this.btnEssen.Tag);
            this.listButt.Add(itm);

            this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(this.btnLeistungskatalog.Tag));
        }

        private void btnClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag));
                StammdatenMode modus = new StammdatenMode();
                modus = (StammdatenMode)Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag);
                this.SwitchTo(modus);
                Application.DoEvents();
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.RefreshControl();
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

        private void ucStammdaten_Load(object sender, EventArgs e)
        {
        }
    }
}
