using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Data.Global;
using PMDS.Print;
using System.Linq;




namespace PMDS.Calc.UI.Admin
{
    public partial class ucCalcKlienten : QS2.Desktop.ControlManagment.BaseControl
    {
        public ErfassungMode _currentMode = ErfassungMode.RechnungenKlient;
        public ErfassungMode _currentModePrev = ErfassungMode.RechnungenKlient;
        public ErfassungMode _currentModePrevKlient = ErfassungMode.LeistungenKlient;


        private bool dataChanged = false;
        public bool IsLoaded = false;


        private PMDS.GUI.ucAbrechAufenthKlient ucAbrechnungsdatenKlient1;
        private PMDS.Calc.UI.Admin.ucLeistungenKlient ucLeistungenKlient1;
        private ucAbwesenheitenKlient ucAbwesenheitKlient1;
        private ucManFreiBuch ucManBuch1;
        private PMDS.Calc.UI.Admin.ucTransferzahlKlient ucTransferzahlKlient1;
        private PMDS.Calc.UI.Admin.ucDepotgeldKlient ucDepotgeldkonto1;
        private ucManFreiBuch ucFreiRech1;
        public  PMDS.Calc.UI.Admin.ucRechnungenKlient ucRechnungenKlient1;
        private PMDS.Calc.UI.Admin.ucKlientenakt ucKlientenakt1;

        public ucCalcKlientenSelect mainWindow;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();



        public enum eAction
         { 
                undo = 0,
                save = 1,
                askForSave = 2,
                changeID = 3
         }



        public ucCalcKlienten()
        {
            InitializeComponent();
        }

        public void loadFormInit()
        {
            tabMainCalc.Style = UltraTabControlStyle.Wizard;
            this.setButtonsAktivDeaktiv(6);
        }
        private void enabDisButtonUnten()
        {
            btnSave.Enabled = this.dataChanged;
            btnUndo.Enabled = this.dataChanged;
            ucPrintStammDatenBlatt1.Visible = _currentMode == ErfassungMode.Klientenakt;
        }
        public bool SaveER(ref bool writeDekursSprachenChanged, ref bool abweseneheitBeendetChanged, ref string txtSprachenGeändert, Guid IDKlient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (this.b.checkPatientExists(IDKlient, db))
                    {
                        PMDS.db.Entities.Patient rPatient = this.b.getPatient(IDKlient, db);
                        rPatient.TageAbweseneheitOhneKuerzung = (int)this.ucAbrechnungsdatenKlient1.numTageAbweseneheitOhneKuerzung.Value;

                        if (this.ucAbrechnungsdatenKlient1.cmbBetreuungsstufe.Text != "")
                        {
                            rPatient.Betreuungsstufe = this.ucAbrechnungsdatenKlient1.cmbBetreuungsstufe.Text;
                        }
                        else
                        {
                            rPatient.Betreuungsstufe = "";
                        }
                        if (this.ucAbrechnungsdatenKlient1.udteBetreuungsstufeAb.Value != null)
                        {
                            rPatient.BetreuungsstufeAb = this.ucAbrechnungsdatenKlient1.udteBetreuungsstufeAb.DateTime;
                        }
                        else
                        {
                            rPatient.BetreuungsstufeAb = null;
                        }
                        if (this.ucAbrechnungsdatenKlient1.udteBetreuungsstufBis.Value != null)
                        {
                            rPatient.BetreuungsstufeBis = this.ucAbrechnungsdatenKlient1.udteBetreuungsstufBis.DateTime;
                        }
                        else
                        {
                            rPatient.BetreuungsstufeBis = null;
                        }

                        if (!this.ucAbrechnungsdatenKlient1._isAbrechnungControlAlone)
                        {
                            PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(IDKlient, false, db);
                        }

                        db.SaveChanges();
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucCalcKlienten.SaveER: " + ex.ToString());
            }
        }
        public  bool doAction(ErfassungMode typ, eAction action)
        {
            bool retValue = false;
            this.checkKlientIsSelected(this._currentMode);
            this.setUIHistorieOnOff();

            if ( this.getIDKlient() == System.Guid.Empty) return false  ;
            if (action == eAction.changeID)
            {
                this.setRights();
                setUIHistorieOnOff();
            }
            
            if (typ == ErfassungMode.AbrechnungsdatenKlient)
            {
                if (this.ucAbrechnungsdatenKlient1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucAbrechnungsdatenKlient1.abrechnungHasChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        Patient pat = new Patient(this.getIDKlient());
                        //this.ucAbrechnungsdatenKlient1.Klient = new KlientDetails(this.getIDKlient(), System.Guid .Empty);  // pat.Aufenthalt.ID
                        List<string> list = new List<string>();
                        list.Add(pat.ID.ToString());
                        ENV.selKlientenChanged(eSendMain.setIDSingleElement, list, false, null);
                    }
                    else if (action == eAction.save )
                    {
                        retValue = this.ucAbrechnungsdatenKlient1.save(false, true, false);

                        System.Guid IDKlient = this.getIDKlient();
                        string txtSprachenGeändert = "";
                        bool writeDekursSprachenChanged = false;
                        bool abweseneheitBeendetChanged = false;
                        this.SaveER(ref writeDekursSprachenChanged, ref abweseneheitBeendetChanged, ref txtSprachenGeändert, IDKlient);
                    }
                    else if (action == eAction.changeID)
                    {
                        System.Guid IDKlient = this.getIDKlient();
                        Patient pat = new Patient(IDKlient);
                        System.Guid IDAuf = pat.checkAufenthalt(IDKlient);
                        if (IDAuf != System.Guid.Empty)
                        {
                            this.ucAbrechnungsdatenKlient1.Klient = new KlientDetails(this.getIDKlient(), pat.Aufenthalt.ID);
                        }
                        else
                        {
                            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                            {
                                PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getLastAufenthaltEntlassen(this.getIDKlient(), db);
                                this.ucAbrechnungsdatenKlient1.Klient = new KlientDetails(this.getIDKlient(), rAufenthalt.ID);
                            }
                        }
                    }
                } 
            }
            else if (typ == ErfassungMode.LeistungenKlient)
            {
                if (this.ucLeistungenKlient1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucLeistungenKlient1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucLeistungenKlient1.IDPatient = this.getIDKlient();
                        //this.ucLeistungenKlient1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucLeistungenKlient1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucLeistungenKlient1.IDPatient = this.getIDKlient();
                    }
                }
            }
            else if (typ == ErfassungMode.AbwesenheitKlient)
            {
                if (this.ucAbwesenheitKlient1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucAbwesenheitKlient1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucAbwesenheitKlient1.IDPatient = this.getIDKlient();
                        //this.ucAbwesenheitKlient1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucAbwesenheitKlient1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucAbwesenheitKlient1.IDPatient = this.getIDKlient();
                    }
                }
            }
            else if (typ == ErfassungMode.manBuchungen)
            {
                if (this.ucManBuch1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucManBuch1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucManBuch1.IDPatient = this.getIDKlient();
                        //this.ucManBuch1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucManBuch1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucManBuch1.IDPatient = this.getIDKlient();
                    }
                }
            }
            else if (typ == ErfassungMode.Transferzahlungen)
            {
                if (this.ucTransferzahlKlient1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucTransferzahlKlient1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucTransferzahlKlient1.IDPatient = this.getIDKlient();
                        //this.ucTransferzahlKlient1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucTransferzahlKlient1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucTransferzahlKlient1.IDPatient = this.getIDKlient();
                    }
                }
            }
            else if (typ == ErfassungMode.freieRechnungen)
            {
                if (this.ucFreiRech1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucFreiRech1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucFreiRech1.IDPatient = this.getIDKlient();
                        //this.ucFreiRech1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucFreiRech1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucFreiRech1.IDPatient = this.getIDKlient();
                    }
                }
                    
            }
            else if (typ == ErfassungMode.RechnungenKlient)
            {
                string xy = "";
            }
            else if (typ == ErfassungMode.Klientenakt)
            {
                if (this.ucKlientenakt1 != null)
                {
                    if (action == eAction.askForSave)
                    {
                        retValue = this.ucKlientenakt1.IsChanged;
                    }
                    else if (action == eAction.undo)
                    {
                        this.ucKlientenakt1.IDPatient = this.getIDKlient();
                        //this.ucKlientenakt1.RefreshControl();
                    }
                    else if (action == eAction.save)
                    {
                        retValue = this.ucKlientenakt1.Save();
                    }
                    else if (action == eAction.changeID)
                    {
                        this.ucKlientenakt1.IDPatient = this.getIDKlient();
                    }
                }
            }

            if (action == eAction.undo || action == eAction.save || action == eAction.changeID)
            {
                if ((action == eAction.save && retValue) || action == eAction.undo )
                    this.dataChanged = false;
                enabDisButtonUnten();
            }
            return retValue;
        }


        public void setUIHistorieOnOff()
        {
            System.Drawing.Color backCol = new System.Drawing.Color();
            if (!PMDS.Global.historie.HistorieOn)
                backCol = System.Drawing.Color.WhiteSmoke;
            else
                backCol = System.Drawing.Color.DarkGray;

            this.BackColor = backCol;
            this.ucRechnungenKlient1.ucCalcs1.BackColor = backCol;
            this.ucRechnungenKlient1.ucCalcs1.setColBack(PMDS.Global.historie.HistorieOn);
            this.setColBack(PMDS.Global.historie.HistorieOn);
            this.ucRechnungenKlient1.BackColor = backCol;
            
            if ( this._currentMode == ErfassungMode.Klientenakt )
               {
                   this.pnlButtons.Visible = !PMDS.Global.historie.HistorieOn;
               }
               else if (this._currentMode == ErfassungMode.RechnungenKlient )
               {
                   this.pnlButtons.Visible = false;
               }
               else
               {
                   this.pnlButtons.Visible = true ;
              }
               Application.DoEvents();
        }

        private void uc_ValueChanged(object sender, EventArgs e)
        {
            this.dataChanged = true;
            this.enabDisButtonUnten();
        }

          
        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.undoClick();
        }

        private void undoClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.dataChanged = false;
                this.doAction(this._currentMode, eAction.undo);
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
                this.doAction(this._currentMode, eAction.save);
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
        public void setRights()
        {
            this.btnAbrechnungsdaten.Visible = ENV.HasRight(UserRights.abrechnungsdatenAnzeigen);
            this.btnLeistungen.Visible = ENV.HasRight(UserRights.klientLeistungen);
            this.btnTransferzahlungen2.Visible = ENV.HasRight(UserRights.klientTransferzahlungen);
        }

        private void ucPrintStammDatenBlatt1_btnPrintStammdatenKlicked(bool Freiheit, bool Versicherung, bool Med, bool Kontakt, bool Sachwalter, bool Arzt,bool Regelung,bool Pflegestufe,bool Kostentraeger,bool Verwahrung,bool Hilfsmittel,bool Dienstleister,bool Reha)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.Print.ReportManager.PrintStammdatenblatt(this.getIDKlient(), Guid.Empty, Freiheit, Versicherung, Med, Kontakt, Sachwalter, Arzt, Regelung, Pflegestufe, Kostentraeger, Verwahrung, Hilfsmittel, Dienstleister, Reha);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        public  System.Guid getIDKlient()
        {
            if (this.mainWindow.ucKlienten2.SavedSelectedTab == null) return System.Guid.Empty;
            return this.mainWindow.ucKlienten2.SavedSelectedTab.id;
        }
        
        private void tabMain_ActiveTabChanging(object sender, ActiveTabChangingEventArgs e)
        {
            if (!this.IsLoaded) return;
            if (!this.changingTab(this._currentModePrev))
            {
                this.setButtonsAktivDeaktiv((int)this._currentModePrev);
                e.Cancel = true;
            }
        }
        public bool  changingTab(ErfassungMode mod)
        {
            bool ret = false ;
            if (mod != ErfassungMode.RechnungenKlient)
            {
                if (this.doAction(mod, eAction.askForSave))
                {
                    DialogResult res = ENV.AskForSave();
                    if (res == DialogResult.No)
                    {
                        this.doAction(mod, eAction.undo);
                        return true;
                    }
                    else
                        ret = this.doAction(mod, eAction.save);
                }
                else
                {
                    ret = true;
                }
            }
            else
            {
                ret = true;
            }
            return ret;
        }
        public void setTabAktivFirst()
        {
            if (this.IsLoaded ) return;
            //if (ENV.HasRight(UserRights.abrechnungsdatenAnzeigen))
            //{
            //    {
                    tabMainCalc.ActiveTab = tabMainCalc.Tabs[(int)ErfassungMode.RechnungenKlient];
                    tabMainCalc.ActiveTab.Selected = true;
                    this.InitTabControl(ErfassungMode.RechnungenKlient);
            //    RechnungenKlient
            //}
        }

        public void clickButton(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int tg = Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag);
                this.activateControl(tg);
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
        public void activateControl(int ErfassungModeNr)
        {
            try
            {
                this._currentModePrev = this._currentMode;

                this._currentMode = (ErfassungMode)ErfassungModeNr;
                if (this._currentMode != ErfassungMode.RechnungenKlient)
                    this._currentModePrevKlient = this._currentMode;

                this.tabMainCalc.ActiveTab = this.tabMainCalc.Tabs[ErfassungModeNr];
                tabMainCalc.ActiveTab.Selected = true;
                tabMainCalc.SelectedTab = tabMainCalc.ActiveTab;
                if (ErfassungModeNr != System.Convert.ToInt32(tabMainCalc.ActiveTab.Index ))
                {
                    this._currentMode = (ErfassungMode)System.Convert.ToInt32(tabMainCalc.ActiveTab.Index);
                    return;
                }

                //this.setSelectionTyp((ErfassungMode)ErfassungModeNr);
                this.setButtonsAktivDeaktiv(ErfassungModeNr);

                if (this.checkKlientIsSelected((ErfassungMode)ErfassungModeNr))
                {
                    this.InitTabControl((ErfassungMode)ErfassungModeNr);
                    setUIHistorieOnOff();
                    this.doAction((ErfassungMode)ErfassungModeNr, eAction.undo);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public bool checkKlientIsSelected(ErfassungMode activMode)
        {
                if (this.mainWindow.ucKlienten2.SavedSelectedTab == null && activMode != ErfassungMode.RechnungenKlient)
                {
                    this.panelDaten.BorderStyle = BorderStyle.None;
                    this.tabMainCalc.Visible = false;
                    return false ;
                }
                else
                {
                    this.panelDaten.BorderStyle = BorderStyle.FixedSingle ;
                    this.tabMainCalc.Visible = true;
                    return true;
                }
        }

        public void setButtonsAktivDeaktiv(int aktivButton)
        {
            System.Drawing.Color foreCol = new System.Drawing.Color();
            foreCol = System.Drawing.Color.Black;
            System.Drawing.Color bordCol = new System.Drawing.Color();
            bordCol = System.Drawing.Color.Black;
            System.Drawing.Color backCol = new System.Drawing.Color();
            backCol = System.Drawing.Color.White;
            System.Drawing.Color hotTrackCol = new System.Drawing.Color();
            hotTrackCol = System.Drawing.Color.Orange;

            System.Drawing.Color backColDeakt = new System.Drawing.Color();
            backColDeakt = System.Drawing.Color.Transparent;

            Infragistics.Win.UIElementButtonStyle styleButt = new Infragistics.Win.UIElementButtonStyle();
            styleButt = Infragistics.Win.UIElementButtonStyle.Flat;

            if (aktivButton == 0) { PMDS.Global.UIGlobal.setAktiv(this.btnAbrechnungsdaten, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnAbrechnungsdaten, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 1) { PMDS.Global.UIGlobal.setAktiv(this.btnLeistungen, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnLeistungen, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 2) { PMDS.Global.UIGlobal.setAktiv(this.btnAbwesenheiten, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnAbwesenheiten, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 3) { PMDS.Global.UIGlobal.setAktiv(this.btnManBuchungen2, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnManBuchungen2, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 4) { PMDS.Global.UIGlobal.setAktiv(this.btnTransferzahlungen2, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnTransferzahlungen2, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 5) { PMDS.Global.UIGlobal.setAktiv(this.btnFreieRechnungen2, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnFreieRechnungen2, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }
            
            if (aktivButton == 6) { PMDS.Global.UIGlobal.setAktiv(this.btnRechnungen, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnRechnungen, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

            if (aktivButton == 7) { PMDS.Global.UIGlobal.setAktiv(this.btnKlientenakt, -1, foreCol, bordCol, backCol); }
            else { PMDS.Global.UIGlobal.setAktivDisable(this.btnKlientenakt, -1, foreCol, hotTrackCol, bordCol, backColDeakt, styleButt); }

        }

        public void InitTabControl(ErfassungMode mode)
        {
            switch (mode)
            {
                case ErfassungMode.RechnungenKlient:
                    if (this.ucRechnungenKlient1 == null) this.initRechnungenKlient();
                    break;
                case ErfassungMode.LeistungenKlient:
                    if (this.ucLeistungenKlient1 == null) this.initLeistungenKlient();
                    break;
                case ErfassungMode.Transferzahlungen:
                    if (this.ucTransferzahlKlient1 == null) this.initTransferzahlungen();
                    break;
                case ErfassungMode.AbwesenheitKlient:
                    if (this.ucAbwesenheitKlient1 == null) this.initAbwesenheitKlient();
                    break;
                case ErfassungMode.Klientenakt:
                    if (this.ucKlientenakt1 == null) this.initKlientenakt();
                    break;
                case ErfassungMode.AbrechnungsdatenKlient:
                    if (this.ucAbrechnungsdatenKlient1 == null) this.initAbrechnungsdatenKlient();
                    break;
                case ErfassungMode.manBuchungen:
                    if (this.ucManBuch1 == null) this.initManBuchungen();
                    break;
                case ErfassungMode.freieRechnungen:
                    if (this.ucFreiRech1 == null) this.initFreieRechnungen();
                    break;

                default:
                    throw new Exception("InitTabControl: Control does not exists in tbMain!");
            }
        }
        private void ucPatientErfassung_Resize(object sender, EventArgs e)
        {
            
        }

        private void initManBuchungen()
        {
            this.ucManBuch1 = new PMDS.Calc.UI.Admin.ucManFreiBuch();
            this.ucManBuch1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucManBuch1.typ = PMDS.Calc.Logic.eCalcRun.manBill ;
            this.ucManBuch1.Dock = DockStyle.Fill;
            this.ucManBuch1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelManBuchungen.Controls.Add(this.ucManBuch1);
            this.ucManBuch1.initControl();
            Application.DoEvents();
            this.panelManBuchungen.Visible = true;
        }
        private void initFreieRechnungen()
        {
            this.ucFreiRech1 = new PMDS.Calc.UI.Admin.ucManFreiBuch();
            this.ucFreiRech1.typ = PMDS.Calc.Logic.eCalcRun.freeBill ;
            this.ucFreiRech1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucFreiRech1.Dock = DockStyle.Fill;
            this.ucFreiRech1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelFreieRechnungen.Controls.Add(this.ucFreiRech1);
            this.ucFreiRech1.initControl();
            Application.DoEvents();
            this.panelFreieRechnungen.Visible = true;
        }

        private void initKlientenakt()
        {
            this.ucKlientenakt1 = new PMDS.Calc.UI.Admin.ucKlientenakt();
            this.ucKlientenakt1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucKlientenakt1.Dock = DockStyle.Fill;
            this.ucKlientenakt1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucKlientenakt1.initControl();
            //this.ucKlientenakt3.resizeUI(this.panelKlientenakt.Width, this.panelKlientenakt.Height);
            this.panelKlientenakt.Controls.Add(this.ucKlientenakt1);
            Application.DoEvents();
            this.panelKlientenakt.Visible = true;
            this.panelKlientenakt2.Visible = true;
        }
        private void initRechnungenKlient()
        {
            this.ucRechnungenKlient1 = new PMDS.Calc.UI.Admin.ucRechnungenKlient();
            this.ucRechnungenKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucRechnungenKlient1.Dock = DockStyle.Fill;
            this.ucRechnungenKlient1.initControl();
            this.panelAbrechnungen.Controls.Add(this.ucRechnungenKlient1);
            Application.DoEvents();
            this.panelAbrechnungen.Visible = true;
        }

        private void initTransferzahlungen()
        {
            this.ucTransferzahlKlient1 = new PMDS.Calc.UI.Admin.ucTransferzahlKlient();
            this.ucTransferzahlKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTransferzahlKlient1.Dock = DockStyle.Fill;
            this.ucTransferzahlKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelTransferzahlungen.Controls.Add(this.ucTransferzahlKlient1);
            this.ucTransferzahlKlient1.initControl();
            Application.DoEvents();
            this.panelTransferzahlungen.Visible = true;
        }
        private void initLeistungenKlient()
        {
            this.ucLeistungenKlient1 = new PMDS.Calc.UI.Admin.ucLeistungenKlient();
            this.ucLeistungenKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucLeistungenKlient1.Dock = DockStyle.Fill;
            this.ucLeistungenKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelLeistungen.Controls.Add(this.ucLeistungenKlient1);
            Application.DoEvents();
            this.panelLeistungen.Visible = true;
        }
        private void initAbrechnungsdatenKlient()
        {
            this.ucAbrechnungsdatenKlient1 = new PMDS.GUI.ucAbrechAufenthKlient();
            this.ucAbrechnungsdatenKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAbrechnungsdatenKlient1.Dock = DockStyle.Fill;
            this.ucAbrechnungsdatenKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucAbrechnungsdatenKlient1.initControl( true,false, false);
            this.panelAbrechnungsdaten.Controls.Add(this.ucAbrechnungsdatenKlient1);
            Application.DoEvents();
            this.panelAbrechnungsdaten.Visible = true;
        }
        private void initAbwesenheitKlient()
        {
            this.ucAbwesenheitKlient1 = new PMDS.Calc.UI.Admin.ucAbwesenheitenKlient();
            this.ucAbwesenheitKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAbwesenheitKlient1.Dock = DockStyle.Fill;
            this.ucAbwesenheitKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.panelAbwesenheiten.Controls.Add(this.ucAbwesenheitKlient1);
            this.ucAbwesenheitKlient1.initControl();
            Application.DoEvents();
            this.panelAbwesenheiten.Visible = true;
        }
       
        public void setSelectionTypxy(ErfassungMode mode)
        {
            //if (mode == ErfassungMode.RechnungenKlient)
            //{
            //    this.mainWindow.ucKlienten2.setSelectionTyp(false);
            //}
            //else if (mode != ErfassungMode.RechnungenKlient && this._currentModePrev == ErfassungMode.RechnungenKlient)
            //{
            //    this.mainWindow.ucKlienten2.setSelectionTyp(true);
            //}
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.undoClick();
        }

        private void tabMain_ActiveTabChanged(object sender, ActiveTabChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.IsLoaded) return;
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

        public void buttKlientOnOff(bool on, string  id )
        {
            this.panelHeaderDetail.Visible = on;
            this.panelButtKlient.Visible = on;
            this.panelButtCalc.Visible = true;
            this.line1.Visible = on;
            //this.line2.Visible = on;

            if (on)
            {



                Patient pat = new Patient (new System.Guid ( id));
                this.lblInfoKlientSingle.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gewählt: ") + pat.FullName + ", * " + ((DateTime)pat.Geburtsdatum).ToString("dd.MM.yyyy");

                if (pat.Verstorben)
                    this.lblInfoKlientSingle.Text += ", + ";

                if (pat.Todeszeitpunkt != null)
                    this.lblInfoKlientSingle.Text += pat.Todeszeitpunkt.Value.ToString("dd.MM.yyyy");
            }
            else
            {
                this.lblInfoKlientSingle.Text = "";
            }
        }
        public void setColBack(bool hist)
        {
            //if (!hist)
            //{
            //    this.uGroupBoxHeader.Appearance.BackColor  = System.Drawing.Color.Transparent;
            //    this.panelButtKlient.BackColor = System.Drawing.Color.Transparent;
            //    this.panelButtCalc.BackColor = System.Drawing.Color.Transparent;
            //}
            //else
            //{
            //    this.uGroupBoxHeader.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            //    this.panelButtKlient.BackColor = System.Drawing.Color.Gainsboro;
            //    this.panelButtCalc.BackColor = System.Drawing.Color.Gainsboro;
            //}
        }

        private void tabMain_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {

        } 

    }
}
