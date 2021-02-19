using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using System.IO;



namespace PMDS.GUI
{
    public partial class ucZielEvaluierung : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _CurrentIDAufenthalt = Guid.Empty;
        private bool _wundejn = false;
        public UIGlobal UIGlobal1 = new UIGlobal();
        public bool IsInitialized = false;






        public ucZielEvaluierung()
        {
            InitializeComponent();

            if (!ENV.AppRunning)
                return;
                
            UltraGridTools.AddBenutzerValueList(dgHistorie, "IDBenutzer");
            UltraGridTools.AddZielEvaluierungsstatusValueList(dgHistorie, "EvalStatus");

        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	Bestimmt ob nur die Wundenevaluierung geladen werden soll oder nicht
        /// </summary>
        //----------------------------------------------------------------------------
        public bool Wundejn
        {
            get { return _wundejn; }
            set { _wundejn = value; }
        }

        public  void setUIGrids2()
        {

            this.dgMain.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgMain.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;
            this.dgHistorie.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgHistorie.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;

            this.dgMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.dgHistorie.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            //if (!this.dgMain.DisplayLayout.Bands[0].Columns.Exists("ID")) return;
                
            //this.dgMain.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDAufenthalt"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDEintrag"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDBenutzer_Erstellt"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDBerufsstand"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDBenutzer_Geaendert"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["OriginalJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["DatumErstellt"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["DatumGeaendert"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["StartDatum"].Hidden = true;
            ////this.dgMain.DisplayLayout.Bands[0].Columns["EndeDatum"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["LetztesDatum"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["LetzteEvaluierung"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Warnhinweis"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Intervall"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["WochenTage"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IntervallTyp"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["EvalTage"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDBerufsstand"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["ParalellJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["LokalisierungJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["EinmaligJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["ErledigtJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["GeloeschtJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Lokalisierung"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["UntertaegigeJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["LokalisierungSeite"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["SpenderAbgabeJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDUntertaegigeGruppe"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDLinkDokument"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["NaechsteEvaluierung"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["NaechsteEvaluierungBemerkung"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["LokalisierungSeite"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["IDZeitbereich"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["ZuErledigenBis"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["OhneZeitBezug"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["WundeJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["BarcodeID"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["RMOptionalJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["RMOptionalJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Anmerkung"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["ErledigtGrund"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["EintragGruppe"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["PDXJN"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["EintragFlag"].Hidden = true;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Dauer"].Hidden = true;

            ////this.dgMain.DisplayLayout.Bands[0].Columns["LokalisierungsInfo"].Hidden = false;
            //this.dgMain.DisplayLayout.Bands[0].Columns["NaechsteEvaluierung"].Hidden = false;
            //this.dgMain.DisplayLayout.Bands[0].Columns["Text"].Hidden = false;

            this.dgMain.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Eingabeelemente benutzen diesen Event
        /// </summary>
        //----------------------------------------------------------------------------
        private void os1_ValueChanged(object sender, EventArgs e)
        {
            EnableButtons(true);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Abbruck Eval setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearContent();
            EnableButtons(false);
            errorProvider1.SetError(optEvaluierungsStatus2, "");
            errorProvider1.SetError(dtpDate2, "");
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Buttons Enablen/Disablen
        /// </summary>
        //----------------------------------------------------------------------------
        private void EnableButtons(bool bEnabled)
        {
            btnOk.Enabled       = bEnabled;
            btnCancel.Enabled   = bEnabled;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eingaben löschen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearContent()
        {
            tbAnmerkung.Clear();
            optEvaluierungsStatus1.CheckedIndex        = -1;
            optEvaluierungsStatus2.CheckedIndex        = -1;
            dtpDate2.Value           = null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die zum Aufenthalt gehörenden Ziele aus dem PP darstellen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshZiele()
        {
            if (!this.IsInitialized)
            {
                this.setUIGrids2();

                this.dgMain.Name = "gridWundeZielEvaluierung";
                string defaultLayoutName = "lytWundeZielEvaluierung";
                QS2.Desktop.ControlManagment.BaseGrid baseGrid = (QS2.Desktop.ControlManagment.BaseGrid)this.dgMain;
                baseGrid.doBaseElements1.runControlManagmentBaseGridManual(baseGrid, defaultLayoutName);

                this.IsInitialized = true;
            }

            ClearContent();
            if (_CurrentIDAufenthalt == Guid.Empty)
            {
                dgMain.DataSource = null;
                return;
            }

            dgHistorie.DataSource = new dsPflegeEintrag();
            dgHistorie.Refresh();

            dsPflegePlan ds = PflegePlan.GetAllZiele(_CurrentIDAufenthalt, _wundejn, cballeZiele.Checked);
            dgMain.DataSource = ds;
            dgMain.DataBind();

            PMDS.DB.DBPflegePlan GetTexte = new PMDS.DB.DBPflegePlan();

            foreach (UltraGridRow rowGrid in this.dgMain.Rows)
            {
                    DataRowView v = (DataRowView)rowGrid.ListObject;
                    dsPflegePlan.PflegePlanRow rp = (dsPflegePlan.PflegePlanRow)v.Row;
                    rowGrid.ToolTipText = GetTexte.GetPDxZiele(rp.ID, rowGrid);
                    rowGrid.Cells[ds.PflegePlan.lstPDxBezeichnungColumn.ColumnName].Value = rowGrid.ToolTipText;
            }

            if (this._wundejn)
            {
                if (!ds.PflegePlan.Columns.Contains("LokalisierungsInfo")) ds.PflegePlan.Columns.Add("LokalisierungsInfo");
                // Lokalisierung aktualisieren
                foreach (UltraGridRow rGrid in this.dgMain.Rows)
                {
                    if (rGrid.IsGroupByRow)
                    {
                        this.showGrid_rek(rGrid, ref this.dsPflegePlan2);
                    }
                    else
                    {
                        dsPflegePlan.PflegePlanRow rPflegePlanSelected = null;
                        this.showGridRow(rGrid, ref this.dsPflegePlan2, ref rPflegePlanSelected, false);
                    }
                }

            }

            this.dgMain.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgHistorie.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;

            this.dgMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.dgHistorie.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            dgMain.Rows.Band.Columns["EndeDatum"].Hidden = !cballeZiele.Checked; //Gernot%% 

            this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

            dsPflegePlan.PflegePlanRow rPESelected = null;
            UltraGridRow rGridRowSelected = null;
            this.getSelectedRowPP(false, ref rGridRowSelected, ref rPESelected);
            if (rPESelected != null)
            {
                RefreshHistorie(rPESelected);
            }
        }

        public void showGrid_rek(UltraGridRow rFoundInGridParent, ref dsPflegePlan ds)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, ref ds);
                        }
                        else
                        {
                            dsPflegePlan.PflegePlanRow rPflegePlanSelected = null;
                            this.showGridRow(rFoundInGrid, ref ds, ref rPflegePlanSelected, false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucZielEvaluierung.showGrid_rek: " + ex.ToString());
            }
        }
        public void showGridRow(UltraGridRow rFoundInGrid, ref dsPflegePlan ds, ref dsPflegePlan.PflegePlanRow rPflegePlanSelected, bool SearchSelected)
        {
            try
            {
                if (!SearchSelected)
                {
                    DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                    dsPflegePlan.PflegePlanRow rp = (dsPflegePlan.PflegePlanRow)v.Row;

                    if (!rp.IsLokalisierungNull() && rp.Lokalisierung.Trim() != "")
                    {
                        string sInfo = rp.Lokalisierung.Trim();
                        if (!rp.IsLokalisierungSeiteNull() && rp.LokalisierungSeite.Trim() != "")
                            sInfo += ", " + rp.LokalisierungSeite.Trim();
                        rFoundInGrid.Cells["LokalisierungsInfo"].Value = sInfo;
                        rFoundInGrid.Update();
                    }
                }
                else
                {
                    if (rFoundInGrid.Activated)
                    {
                        DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                        dsPflegePlan.PflegePlanRow rp = (dsPflegePlan.PflegePlanRow)v.Row;

                        rPflegePlanSelected = rp;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucZielEvaluierung.showGridRow: " + ex.ToString());
            }
        }

        public void DoLayout()
        {
            if (!DesignMode && ENV.AppRunning)
            {
                qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                compLayout1.initControl();
                bool LayoutFound = false;
                //compLayout1.doLayoutGrid(this.dgMain, this.dgMain.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                //QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgMain);

                QS2.Desktop.ControlManagment.cLayoutManager2 cLayoutManager1 = new QS2.Desktop.ControlManagment.cLayoutManager2();
                cLayoutManager1.doLayoutGrid(this.dgMain, this.dgMain.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgMain);
            }

        }

        public bool getSelectedRowPP(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsPflegePlan.PflegePlanRow rPP)
        {
            try
            {
                if (this.dgMain.ActiveRow != null)
                {
                    if (this.dgMain.ActiveRow.IsGroupByRow || this.dgMain.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.dgMain.ActiveRow.ListObject;
                        dsPflegePlan.PflegePlanRow rSelRow = (dsPflegePlan.PflegePlanRow)v.Row;
                        gridRow = this.dgMain.ActiveRow;
                        rPP = rSelRow;
                        return true;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucZielEvaluierung.getSelectedRowPP: " + ex.ToString());
            }

        }
        public bool getSelectedRowHistorie(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref dsPflegeEintrag.PflegeEintragRow rPE)
        {
            try
            {
                if (this.dgHistorie.ActiveRow != null)
                {
                    if (this.dgHistorie.ActiveRow.IsGroupByRow || this.dgHistorie.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return false;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.dgHistorie.ActiveRow.ListObject;
                        dsPflegeEintrag.PflegeEintragRow rSelRow = (dsPflegeEintrag.PflegeEintragRow)v.Row;
                        gridRow = this.dgHistorie.ActiveRow;
                        rPE = rSelRow;
                        return true;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucZielEvaluierung.getSelectedRowHistorie: " + ex.ToString());
            }

        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// gesamten Inhalt aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshContent(Guid IDAufenthalt)
        {
            //if (_CurrentIDAufenthalt == IDAufenthalt)           // nichts zu tun ==> raus
            //    return;

            _CurrentIDAufenthalt = IDAufenthalt;
            
            RefreshZiele();
            this.DoLayout();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Anderes Ziel wurde gewählt
        /// </summary>
        //----------------------------------------------------------------------------
        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Evalstatus zeigen/verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideEvaluierungsstatus()
        {
            //splitContainerOben.Panel2Collapsed   = dgMain.Rows.Count == 0;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen sollen verspeichert werden
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            dsPflegePlan.PflegePlanRow rPESelected = null;
            UltraGridRow rGridRowSelected = null;
            this.getSelectedRowPP(true, ref rGridRowSelected, ref rPESelected);

            if (rPESelected != null)
            {
                string PflegeplanTextTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung");
                string TxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung für Ziel ") + rPESelected.Text.Trim();
                this.speichernPflegeeintrag(PflegeEintragTyp.EVALUIERUNG, PflegeplanTextTmp, TxtTmp, STATUS, rPESelected);
                if (this.dtpDate2.Value != null)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    dsPflegePlan.PflegePlanRow r = rPESelected;
                    PMDSBusiness1.updateNächsteEvaluierung(r.ID, this.dtpDate2.DateTime);
                    r.NaechsteEvaluierung = this.dtpDate2.DateTime.Date;
                    this.dgMain.Refresh();
                }

                ClearContent();
                EnableButtons(false);
                RefreshHistorie(rPESelected);
            }

        }

        public void speichernPflegeeintrag(PflegeEintragTyp typ,string PflegeplanText, string Txt, ZielEvaluierungsStatus Status2, dsPflegePlan.PflegePlanRow rPESelected)
        {
            dsPflegePlan.PflegePlanRow r = rPESelected;
            {
                PflegeEintrag pe = new PflegeEintrag();
                pe.New();
                pe.IDAufenthalt = r.IDAufenthalt;
                pe.IDBenutzer = ENV.USERID;
                pe.IDEintrag = r.IDEintrag;
                pe.IDEvaluierung = ENV.CurrentIDEvaluierung;
                pe.IDPflegePlan = r.ID;
                pe.DatumErstellt = DateTime.Now;
                pe.DurchgefuehrtJN = true;
                pe.EintragsTyp = typ;
                pe.EvalStatus = Status2;
                pe.PflegeplanText = PflegeplanText;    
                pe.Text = Txt + ": " + tbAnmerkung.Text.Trim();   
                pe.Wichtig = PflegeEintragWichtig.NONE;
                pe.Zeitpunkt = DateTime.Now;
                pe.IDWichtig = Guid.Empty;                   
                pe.IDBerufsstand = ENV.BERUFID;                 
                pe.Write();
            }
        }

        private void RefreshHistorie(dsPflegePlan.PflegePlanRow rPESelected)
        {
            if (_CurrentIDAufenthalt == Guid.Empty || dgMain.ActiveRow == null)
            {
                dgHistorie.DataSource = new dsPflegeEintrag();
                return;
            }
            
            dgHistorie.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie für: ") + rPESelected.Text;
            dsPflegeEintrag ds = PflegeEintrag.AllAufenthaltEvaluierung(_CurrentIDAufenthalt, rPESelected.ID); ;
            dgHistorie.DataSource = ds;

            this.dgMain.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgHistorie.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;

            this.dgMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.dgHistorie.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// liefert die aktuell selektierte Row
        /// </summary>
        //----------------------------------------------------------------------------
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this.panelStatusEingabe, bOn);

            PMDS.GUI.BaseControls.historie.OnOffControls(this.ultraGridBagLayoutPanelAnmerkung, bOn);
            //splitContainerOben.Panel2Collapsed =   bOn;
            if (!bOn) ShowHideEvaluierungsstatus();
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZielEvaluierungsStatus STATUS
        {
            get
            {
                return (ZielEvaluierungsStatus)((optEvaluierungsStatus1.CheckedIndex + 1) * 100 + optEvaluierungsStatus2.CheckedIndex + 1);
            }
            set
            {
                int status = (int)value;
                optEvaluierungsStatus1.CheckedIndex = (status / 100) - 1;
                optEvaluierungsStatus2.CheckedIndex = (status % 100) - 1;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüfen ob alles ausgefüllt ist
        /// </summary>
        //----------------------------------------------------------------------------
        private bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            bool bfalse = (optEvaluierungsStatus1.CheckedIndex != -1 || optEvaluierungsStatus2.CheckedIndex != -1) && (optEvaluierungsStatus1.CheckedIndex == -1 || optEvaluierungsStatus2.CheckedIndex == -1);
            bfalse |= ((tbAnmerkung.Text.Trim().Length > 0) && (optEvaluierungsStatus1.CheckedIndex == -1 || optEvaluierungsStatus2.CheckedIndex == -1));
            
            GuiUtil.ValidateField(optEvaluierungsStatus2, !bfalse, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte ausfüllen"), ref bError, bInfo, errorProvider1);
            
            if (dtpDate2.Value != null)
                GuiUtil.ValidateField(dtpDate2, !(DateTime.Now.Date > dtpDate2.DateTime.Date), QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum darf nicht in der Vergangenheit liegen"), ref bError, bInfo, errorProvider1);    

            return !bError;
        }

        private void ucZielEvaluierung_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dgHistorie_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void cballeZiele_CheckedChanged(object sender, EventArgs e)
        {
            RefreshZiele();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            EnableButtons(true);
        }

        private void dgHistorie_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgHistorie))
                {
                    dsPflegeEintrag.PflegeEintragRow rPE = null;
                    UltraGridRow rGridRow = null;
                    bool bRowSelected = this.getSelectedRowHistorie(false, ref rGridRow, ref rPE);
                    if (bRowSelected)
                    {
                        frmEditZiel frmEditZiel1 = new frmEditZiel();
                        frmEditZiel1.mainWindow = this;
                        frmEditZiel1.IDPE = rPE.ID;
                        frmEditZiel1.InitControl();
                        frmEditZiel1.ShowDialog(this);
                        if (!frmEditZiel1.abort)
                        {
                            dsPflegePlan.PflegePlanRow rPESelected = null;
                            UltraGridRow rGridRowSelected = null;
                            this.getSelectedRowPP(true, ref rGridRowSelected, ref rPESelected);
                            if (rPESelected != null)
                            {
                                this.RefreshHistorie(rPESelected);
                            }
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

        private void dgMain_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgMain))
                {
                    dsPflegePlan.PflegePlanRow rPESelected = null;
                    UltraGridRow rGridRowSelected = null;
                    this.getSelectedRowPP(false, ref rGridRowSelected, ref rPESelected);
                    if (rPESelected != null)
                    {
                        RefreshHistorie(rPESelected);
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
    }

}

