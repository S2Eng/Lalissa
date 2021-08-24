using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinTabControl;
using System.Linq;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    public partial class ucKlienten : QS2.Desktop.ControlManagment.BaseControl
    {

        private List<Guid> _lIDKlienten = new List<Guid>();
        private int anzKlienten = 0;
        public eSendMain typ = new eSendMain();
        public bool _singleSelect = false;
        public List<PMDS.GUI.BaseControls.ucKlientenElement > SavedSelectedTabsxy = new List<PMDS.GUI.BaseControls.ucKlientenElement >();
        public PMDS.GUI.BaseControls.ucKlientenElement SavedSelectedTab;

        public PMDS.GUI.BaseControls.ucKlientenElement lastElMousOver;

        public DataTable tControls = new DataTable();
        public string colControl = "Control";
        public string colKey = "Key";


        private string tmpSearchKlient = "";
        private Guid tmpSearchKostenträger = Guid.Empty;
        private bool tmpSearchSelbstzahler = false;
        private DateTime tmpSearchVon = DateTime.Today;
        private DateTime tmpSearchBis = DateTime.Today;

        public ucKlienten()
        {
            InitializeComponent();
            this.btnSearchKlienten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
        }

   

        public void setIcoActSelCombo( Infragistics.Win.ValueListItem selItem)
        {
           foreach (Infragistics.Win.ValueListItem itm in cbAllgemeineKostenträger.Items)
           {
               itm.Appearance.Image = null;
               itm.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False ;
               itm.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
               itm.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False;
               if (selItem != null )
                   if (itm.DataValue == selItem.DataValue)
                   {
                       itm.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                       itm.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                       itm.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False;
                       itm.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                   }
           }
        }
        public bool checkDoAction()
        {
            Infragistics.Win.ValueListItem item = cbAllgemeineKostenträger.SelectedItem;
            if (item == null) return false;
            if ((string)item.Tag == "AKL" || (string)item.Tag == "L")
                return false ;

            return true;
        }
   
        public void checkVonBis(bool init, bool firstToUltimo)
        {
            if (init)
            {
                this.dtVon.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                this.dtBis.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            }
            else if (!init)
            {
                if (firstToUltimo)
                {
                    this.dtVon.DateTime = new DateTime(this.dtVon.DateTime.Year, this.dtVon.DateTime.Month, this.dtVon.DateTime.Day, 0, 0, 0);
                    this.dtBis.DateTime = new DateTime(this.dtBis.DateTime.Year, this.dtBis.DateTime.Month, DateTime.DaysInMonth(this.dtBis.DateTime.Year, this.dtBis.DateTime.Month), 23, 59, 59);
                }
                else
                {
                    this.dtVon.DateTime = new DateTime(this.dtVon.DateTime.Year, this.dtVon.DateTime.Month, this.dtVon.DateTime.Day, 0, 0, 0);
                    this.dtBis.DateTime = new DateTime(this.dtBis.DateTime.Year, this.dtBis.DateTime.Month, this.dtBis.DateTime.Day, 23, 59, 59);
                }
            }
            tmpSearchVon = this.dtVon.DateTime;
            tmpSearchBis = this.dtBis.DateTime;
        }


        public void loadComboAuswahl()
        {
            Guid IDKostentraeger = Guid.Empty;
            if (cbAllgemeineKostenträger.SelectedItem != null)
                IDKostentraeger = (Guid)cbAllgemeineKostenträger.SelectedItem.DataValue;

            cbAllgemeineKostenträger.Items.Clear();
            
            Infragistics.Win.ValueListItem item;

            item = cbAllgemeineKostenträger.Items.Add(Guid.Empty, " ");
            item.Tag = "L";

            using (PMDS.DB.Global.DBKostentraeger k = new PMDS.DB.Global.DBKostentraeger())
            {
                PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerDataTable dt = k.GetOnlyAlgemeinKostentraeger(false, System.Guid.Empty, ENV.FSW_SupressSubKostentraeger);
                foreach (PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow r in dt)
                {
                    item = cbAllgemeineKostenträger.Items.Add(r.ID, "     " + r.Name);
                    item.Tag = "AK";
                    if (r.ID == IDKostentraeger)
                        cbAllgemeineKostenträger.SelectedItem = item;
                }
            }
        }

        public void setTabActive(dsPatientName ds, bool singleSelect)
        {
            try
            {
                int anzAkt = 0;
                dsPatientName.PatientRow[] rAll = (dsPatientName.PatientRow[])ds.Patient.Select("", "Name");
                foreach (dsPatientName.PatientRow r in ds.Patient )
                {
                    foreach (PMDS.GUI.BaseControls.ucKlientenElement el in this.panelButtons.Controls)
                    {
                        if (el.activiertForSearch  )
                        {
                            if (el.id.ToString() == r.ID.ToString() && !el.isOn )
                            {
                                SetTabSelected(el, false, singleSelect);
                                anzAkt += 1;
                            }
                        }
                    }
                }

                this.lblTitelKlienten.Text = "" + anzAkt.ToString() + "/" + anzKlienten.ToString() + "";

                //dsPatientName.PatientRow[] rAll = (dsPatientName.PatientRow[])ds.Patient.Select("", "Name");
                //foreach (dsPatientName.PatientRow r in rAll)
                //{
                //    Infragistics.Win.UltraWinTabControl.UltraTab ultraTab = tabKlienten.Tabs.Add(r.ID.ToString(), r.Name);
                //    ultraTab.Tag = false;
                //}
                //this.SetAllTabSelected();

           }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        public List <string>  getFilterStr( )
        {
            List<string> list = new List<string>();
            foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            {
                if (el.activiertForSearch)
                {
                    if (el.Visible)
                    {
                        if (el.isOn)
                        {
                            //string str = " [IDPatient] = '" + tab.Key.ToString() + "' ";

                            //if (this.strFilter == "")
                            //    this.strFilter += str;
                            //else
                            //    this.strFilter += " OR " + str;

                            string str = el.id.ToString();
                            list.Add(str);
                        }
                    }
                }
            }

            return list;
        }

        public void doVisibleAllTabs(bool singleSelect, bool isVisible)
        {
            this.uButtonAlleKeine.Text = "Keine";
            this.uButtonAlleKeine.Tag = "K";
            foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            {
                el.Visible = isVisible;
                el.isOn = false;
                el.isVisible = isVisible;
                el.activiertForSearch = true;
                SetTabNotSelected(el, singleSelect);
            }
        }

        public void SetAllTabSelected(bool singleSelect)
        {
            foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            {
                if (el.Visible)
                    SetTabSelected(el, false, singleSelect);
            }
        }
        public PMDS.GUI.BaseControls.ucKlientenElement SetFirstTabSelected(bool singleSelect)
        {
            this.SetAllTabaNotSelected(singleSelect);
            foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            {
                if (el.Visible)
                {
                    SetTabSelected(el, false, singleSelect);
                    return el;
                }
            }
            return null;
        }

        public void saveSelectedTabsxy(bool singleSelection )
        {
            //if (singleSelection)
            //{
            //    this.SavedSelectedTab = null;
            //}
            //else
            //{
            //    SavedSelectedTabs.Clear();
            //}

            //foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            //{
            //    if (el.isOn)
            //    {
            //        if (singleSelection)
            //        {
            //            this.SavedSelectedTab = el;
            //            return;
            //        }
            //        else
            //        {
            //            SavedSelectedTabs.Add(el);
            //        }
            //    }

            //}
        }
        public void setSavedTabsxy(bool singleSelection)
        {
            //this.SetAllTabaNotSelected(singleSelection);
            //if (!singleSelection)
            //{
            //    foreach (PMDS.GUI.BaseControls.ucKlientenElement el in SavedSelectedTabs)
            //    {
            //        this.SetTabSelected(el, false, singleSelection);
            //    }
            //}
            //else
            //{
            //    //if (this.SavedSelectedTab == null)
            //    //{
            //    //    PMDS.GUI.BaseControls.ucKlientenElement firstEl = this.SetFirstTabSelected();
            //    //    this.SavedSelectedTab = firstEl;
            //    //}
            //    if (this.SavedSelectedTab != null)
            //        this.SetTabSelected(this.SavedSelectedTab, false, singleSelection);
            //    return;
            //}
        }

        public void SetTabSelected(PMDS.GUI.BaseControls.ucKlientenElement el, bool deselectAll, bool  singleOnOff)
        {
            if (deselectAll)
                this.SetAllTabaNotSelected(singleOnOff);

            if (!singleOnOff)
            {
                el.isOn = true;
                PMDS.Global.UIGlobal.setAktivDisable(el.btnClick, anzKlienten, System.Drawing.Color.Black,
                                System.Drawing.Color.Gainsboro, System.Drawing.Color.Gainsboro,
                                System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.FlatBorderless);

                el.btnClick.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            }
            else
            {
                el.isOnSingle = true;
                el.picButtSingle.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);
                el.picButtSingle.Visible = true;
            }
        }

        public void SetAllTabaNotSelected(bool  singleOnOff )
        {
            foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
            {
                SetTabNotSelected(el, singleOnOff);
            }

        }
        public void SetTabNotSelected(PMDS.GUI.BaseControls.ucKlientenElement el, bool  singleOnOff )
        {
            if (!singleOnOff)
            {
                el.isOn = false;
                PMDS.Global.UIGlobal.setAktivDisable(el.btnClick, anzKlienten, System.Drawing.Color.Black,
                                System.Drawing.Color.Gainsboro, System.Drawing.Color.Gainsboro,
                                System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.FlatBorderless);
                el.btnClick.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);
            }
            else
            {
                el.isOnSingle = false;
                el.picButtSingle.Image = null;
                el.picButtSingle.Visible = false;
            }
                
       }
        public void buttAlleKeine( )
        {
                Cursor = Cursors.WaitCursor;

                if (this.uButtonAlleKeine.Tag.ToString() == "A")
                {
                    this.uButtonAlleKeine.Text = "Keine";
                    this.uButtonAlleKeine.Tag = "K";
                    this.SetAllTabSelected ( false);
                }
                else
                {
                    this.uButtonAlleKeine.Text = "Alle";
                    this.uButtonAlleKeine.Tag = "A";
                    this.SetAllTabaNotSelected (false );
                }

                ENV.selKlientenChanged(eSendMain.setIDMultiElement, this.getFilterStr(), false, null);
                
                Cursor = Cursors.Default;
        }

        public void elementClicked(PMDS.GUI.BaseControls.ucKlientenElement el)
        {
            try
            {
                    Cursor = Cursors.WaitCursor;

                    if (this._singleSelect)
                    {
                        //if (!ENV.selKlientenChanged(eSendMain.checkEdited, new List<string>(), true, false)) return;
                        //this.SetTabSelected(el, true);
                        //this.SavedSelectedTab = el;
                        elementClickedSingle(el, el.isOnSingle);
                    }
                    else
                    {
                        if (el.isOn)
                        {
                            SetTabSelected(el, false, false );
                        }
                        else
                        {
                            SetTabNotSelected(el, false );
                        }
                    }

                    ENV.selKlientenChanged(eSendMain.setIDMultiElement , this.getFilterStr(), false , null   );
                        //Klienten = GetSelectedTabs();

                        //if (KlientenSelectionChanged != null)
                        //    KlientenSelectionChanged(this, null);
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        public void elementClickedSingle(PMDS.GUI.BaseControls.ucKlientenElement el, bool on)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
               
                ENV.selKlientenChanged(eSendMain.singleElementActivated, new List<string>(), on, el.id );
                if (on)
                {
                    this.SetTabSelected(el, true, true);
                    this.SavedSelectedTab = el;
                }
                else
                {
                    this.SetTabNotSelected(el, true);
                    this.SavedSelectedTab = null;
                }      
                List<string> list = new List<string>();
                list.Add(el.id.ToString());
                ENV.selKlientenChanged(eSendMain.setIDSingleElement, list , false, null);
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        public  void historieChangedxy( )
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //if (chkHistorie.Focused)
                //{
                //    PMDS.Global.historie.HistorieOn = this.chkHistorie.Checked;
                //    ENV.selKlientenChanged(eSendMain.historieOnOff, new List<string>(), false, (object)chkHistorie.Checked);
                //    this.loadKlienten(true, new PMDS.Data.Patient.dsPatientStation.PatientDataTable(), true, true, chkHistorie.Checked);
                //}

            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void searchKlientxy()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (this.cbAllgemeineKostenträger.Focused)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    if (cbAllgemeineKostenträger.SelectedItem != null)
                        if (!this.checkDoAction()) return;

                    foreach (PMDS.GUI.BaseControls.ucKlientenElement el in panelButtons.Controls)
                    {
                        if (el.activiertForSearch)
                        {
                            if (this.cbAllgemeineKostenträger.Text.Trim() == "")
                            {
                                el.Visible = true;
                            }
                            else
                            {
                                if (el.btnClick.Text.ToLower().Contains(this.cbAllgemeineKostenträger.Text.Trim().ToLower()))
                                {
                                    el.Visible = true;
                                }
                                else
                                {
                                    el.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void uButtonAlleKeine2_Click(object sender, EventArgs e)
        {
            this.buttAlleKeine();
        }


        private void btnSearchKlienten_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                this.LoadListklienten();   
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void LoadListklienten()
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities DBContext = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    string sName = null;
                    if (!String.IsNullOrWhiteSpace(this.txtKlient.Text))
                        sName = this.txtKlient.Text.Trim();

                    Nullable<Guid> IDAllgKostenträger = null;
                    if (this.cbAllgemeineKostenträger.Value != null && (Guid)this.cbAllgemeineKostenträger.Value != System.Guid.Empty)
                        IDAllgKostenträger = (Guid)this.cbAllgemeineKostenträger.Value;

                    Nullable<int> NurSelbstzahlerJN = null;
                    if (this.chkNurSelbstzahlerJN.Checked)
                        NurSelbstzahlerJN = 1;
                
                    Nullable<DateTime> dVon = null;
                    if (this.dtVon.Value != null)
                        dVon = this.dtVon.DateTime.Date;

                    Nullable<DateTime> dBis = null;
                    if (this.dtBis.Value != null)
                        dBis = this.dtBis.DateTime.Date;

                    IQueryable<PMDS.db.Entities.s2_GetKlientenlisteAbrechnung_Result> ts2_GetKlientenlisteAbrechnung_Result = null;
                    ts2_GetKlientenlisteAbrechnung_Result = b.getKlientenlisteAbrechnung(ref sName, ref IDAllgKostenträger, ref dVon, ref dBis, ref NurSelbstzahlerJN, DBContext);

                    anzKlienten = 0;
                    this.doVisibleAllTabs(false, false);
                    this.doVisibleAllTabs(true, false);
                    foreach (PMDS.GUI.BaseControls.ucKlientenElement elExists in panelButtons.Controls)
                    {
                        elExists.Visible = false;
                    }

                    foreach (PMDS.db.Entities.s2_GetKlientenlisteAbrechnung_Result rS2_GetKlientenlisteAbrechnung_Result in ts2_GetKlientenlisteAbrechnung_Result)
                    {
                        PMDS.GUI.BaseControls.ucKlientenElement el;
                        if (anzKlienten < this.panelButtons.Controls.Count)
                        {
                            el = (PMDS.GUI.BaseControls.ucKlientenElement)panelButtons.Controls[anzKlienten];

                        }
                        else
                        {
                            el = new PMDS.GUI.BaseControls.ucKlientenElement();
                            el.mainContr = this;
                            el.btnClick.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);

                            el.Dock = DockStyle.Top;
                            el.Height = 31;
                            PMDS.Global.UIGlobal.setAktivDisable(el.btnClick, anzKlienten, System.Drawing.Color.Black,
                                            System.Drawing.Color.Gainsboro, System.Drawing.Color.Gainsboro,
                                            System.Drawing.Color.Transparent, Infragistics.Win.UIElementButtonStyle.FlatBorderless);
                            this.panelButtons.Controls.Add(el);
                        }

                        if (this.typ == eSendMain.abrechnung)
                            el.ContextMenuStrip = el.contextMenuStrip1;
                        else
                            el.ContextMenuStrip = null;

                        el.id = (Guid)rS2_GetKlientenlisteAbrechnung_Result.IDKlient;

                        string sGebDat = "";
                        if (rS2_GetKlientenlisteAbrechnung_Result.Geburtsdatum != null)
                        {
                            DateTime dGebDat = rS2_GetKlientenlisteAbrechnung_Result.Geburtsdatum.Value;
                            sGebDat = "\n\r       - " + dGebDat.ToString("dd.MM.yyyy");
                        }
                        el.btnClick.Text = rS2_GetKlientenlisteAbrechnung_Result.KlientName.Trim() + sGebDat;
                        el.activiertForSearch = true;
                        el.Visible = true;
                        el.isVisible = true;
                        el.isOn = false;

                        anzKlienten += 1;
                    }

                    this.lblTitelKlienten.Text = "";
                    this.SavedSelectedTab = null;
                    //this.setModusTxt(modusTxt, anzKlienten);

                    //if (doAllTabs)
                    //{
                    //    this.uButtonAlleKeine.Text = "Keine";
                    //    this.uButtonAlleKeine.Tag = "K";
                    //    this.SetAllTabSelected(false);
                    //    ENV.selKlientenChanged(eSendMain.setIDMultiElement, this.getFilterStr(), true, null);
                    //}
                    //else
                    //{
                    this.uButtonAlleKeine.Text = "Alle";
                    this.uButtonAlleKeine.Tag = "A";
                    //}

                    //this.doVisibleAllTabs(true, true);
                }

            }
            catch (Exception exch)
            {
                throw new Exception("LoadListklienten: " + exch.ToString());
            }
        }

        private void cbAllgemeineKostenträger_ValueChanged(object sender, EventArgs e)
        {
            if (this.cbAllgemeineKostenträger.Value != null && (Guid)this.cbAllgemeineKostenträger.Value != System.Guid.Empty)
                this.chkNurSelbstzahlerJN.Checked = false;

            this.timer1.Interval = 300;
            this.timer1.Stop();
            if ((Guid)this.cbAllgemeineKostenträger.Value != tmpSearchKostenträger)
                tmpSearchKostenträger = (Guid)this.cbAllgemeineKostenträger.Value;
            this.timer1.Start();

        }

        private void txtKlient_ValueChanged(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Stop();
            if (this.txtKlient.Text != tmpSearchKlient)
                tmpSearchKlient = this.txtKlient.Text;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool bNoSearch = true;
                bNoSearch = this.txtKlient.Text != tmpSearchKlient;

                if (tmpSearchKostenträger != Guid.Empty)
                {
                    bNoSearch = (Guid)this.cbAllgemeineKostenträger.Value != tmpSearchKostenträger;
                }

                if (!bNoSearch && ENV._IDKlinik != ENV._IDKlinikNoKlinikSelected)
                {
                    Cursor = Cursors.WaitCursor;
                    this.LoadListklienten();
                }
                this.timer1.Stop();
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void chkNurSelbstzahlerJN_CheckedChanged(object sender, EventArgs e)
        {
            this.timer1.Interval = 100;
            this.timer1.Stop();
            if (this.chkNurSelbstzahlerJN.Checked != tmpSearchSelbstzahler)
                tmpSearchSelbstzahler = this.chkNurSelbstzahlerJN.Checked;
            this.timer1.Start();
        }

        private void dtVon_ValueChanged(object sender, EventArgs e)
        {
            this.timer1.Interval = 300;
            this.timer1.Stop();
            if (dtVon.DateTime != tmpSearchVon)
                tmpSearchVon = dtVon.DateTime;
            this.timer1.Start();
        }

        private void dtBis_ValueChanged(object sender, EventArgs e)
        {
            this.timer1.Interval = 300;
            this.timer1.Stop();
            if (dtBis.DateTime != tmpSearchBis)
            {
                checkVonBis(false, true);
                tmpSearchBis = dtBis.DateTime;

            }
            this.timer1.Start();
        }
    }
}
