using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using UWG = Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;

using PMDS.Global.db.Global;
using System.Data.Entity.Infrastructure;

using PMDS.db.Entities;






namespace PMDS.GUI
{


	public class ucTermine : QS2.Desktop.ControlManagment.BaseControl
	{

		public event EventHandler	TerminDoubleClick;
		public event EventHandler	TerminSelected;
        public event MouseEventHandler Wheelspin;

        public ucTermineEx MainWindow = null;

        private System.ComponentModel.IContainer components = null;
        public QS2.Desktop.ControlManagment.BaseGrid dgTermine;

        public PMDS.UI.Sitemap.UIFct UIFct1 = new UI.Sitemap.UIFct();
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public string _SqlCommand = "";

        public PMDS.Global.db.ERSystem.dsTermine _ds = null;

        public static PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlisteStartGrid = new Global.db.ERSystem.dsKlientenliste();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();









		public ucTermine()
		{
            InitializeComponent();
		}      

		protected override void Dispose( bool disposing )
		{
			dgTermine.ActiveCell = null;

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.dgTermine = new QS2.Desktop.ControlManagment.BaseGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgTermine)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTermine
            // 
            this.dgTermine.AutoWork = false;
            appearance1.BackColor = System.Drawing.Color.White;
            this.dgTermine.DisplayLayout.Appearance = appearance1;
            this.dgTermine.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgTermine.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgTermine.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgTermine.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgTermine.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgTermine.DisplayLayout.MaxColScrollRegions = 1;
            this.dgTermine.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgTermine.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgTermine.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgTermine.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgTermine.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgTermine.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgTermine.DisplayLayout.Override.CellPadding = 0;
            appearance7.BackColor = System.Drawing.SystemColors.Control;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.BorderColor = System.Drawing.SystemColors.Window;
            this.dgTermine.DisplayLayout.Override.GroupByRowAppearance = appearance7;
            appearance8.TextHAlignAsString = "Left";
            this.dgTermine.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.dgTermine.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgTermine.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            this.dgTermine.DisplayLayout.Override.RowAppearance = appearance9;
            this.dgTermine.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgTermine.DisplayLayout.Override.RowSpacingAfter = 3;
            this.dgTermine.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgTermine.DisplayLayout.Override.TemplateAddRowAppearance = appearance10;
            this.dgTermine.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgTermine.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgTermine.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgTermine.Location = new System.Drawing.Point(113, 31);
            this.dgTermine.Name = "dgTermine";
            this.dgTermine.Size = new System.Drawing.Size(611, 357);
            this.dgTermine.TabIndex = 1;
            this.dgTermine.AfterCellActivate += new System.EventHandler(this.dgTermine2_AfterCellActivate);
            this.dgTermine.AfterRowActivate += new System.EventHandler(this.dgTermine2_AfterRowActivate);
            this.dgTermine.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgTermine2_BeforeRowActivate);
            this.dgTermine.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgTermine2_BeforeCellActivate);
            this.dgTermine.BeforeRowRegionScroll += new Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventHandler(this.dgTermine2_BeforeRowRegionScroll);
            this.dgTermine.Click += new System.EventHandler(this.dgTermine2_Click);
            this.dgTermine.DoubleClick += new System.EventHandler(this.dgTermine2_DoubleClick);
            // 
            // ucTermine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dgTermine);
            this.Name = "ucTermine";
            this.Size = new System.Drawing.Size(944, 457);
            this.Load += new System.EventHandler(this.ucTermine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTermine)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion






		private void ucTermine_Load(object sender, System.EventArgs e)
		{
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
			try 
			{

			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}


		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow CurTerminRowIntervention
		{
			get
			{
                UltraGridRow r = this.dgTermine.ActiveRow;
                if ((r == null) || (r.ListObject == null))
                    return null;

                DataRowView v = (DataRowView)r.ListObject;
                PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rSelected = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)v.Row;
                return rSelected;
			}
		}
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow CurTerminRow‹bergabe
        {
            get
            {
                UltraGridRow r = this.dgTermine.ActiveRow;
                if ((r == null) || (r.ListObject == null))
                    return null;

                DataRowView v = (DataRowView)r.ListObject;
                PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow rSelected = (PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow)v.Row;
                return rSelected;
            }
        }

		protected virtual void OnTerminDoubleClick(EventArgs args)
		{
			if (TerminDoubleClick != null)
				TerminDoubleClick(this, args);
		}

		protected virtual void OnTerminSelected(EventArgs args)
		{
			if (TerminSelected != null)
				TerminSelected(this, args);
		}

        public void SetSelection(bool bSelect)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgTermine, false ))
            {
                if (!IsInExpandedGroup(r))
                    continue;
                r.Cells["Auswahl"].Value = bSelect;
                r.Update();
            }
        }

        private bool IsInExpandedGroup(UltraGridRow r)
        {
            if (r.ParentRow == null)
                return true;

            return r.ParentRow.IsExpanded;
        }

        public void SELECTED_ROWS(ref System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen,
                                  ref System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow> lst‹bergabe)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgTermine, false))
            {
                if ((bool)r.Cells["Auswahl"].Value == true)
                {
                    if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        DataRowView v = (DataRowView)r.ListObject;
                        PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rAct = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)v.Row;
                        lstInterventionen.Add(rAct);
                    }
                    else if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs ||
                            this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.‹bergabe)
                    {
                        DataRowView v = (DataRowView)r.ListObject;
                        PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow rAct = (PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow)v.Row;
                        lst‹bergabe.Add(rAct);
                    }
                } 
            }
        }
        public void SELECTED_ROWS2(ref System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> lstInterventionen,
                          ref System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow> lst‹bergabe)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgTermine, false))
            {
                if (r.Selected)
                {
                    if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        DataRowView v = (DataRowView)r.ListObject;
                        PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rAct = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)v.Row;
                        lstInterventionen.Add(rAct);
                    }
                    else if (this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs ||
                            this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.‹bergabe)
                    {
                        DataRowView v = (DataRowView)r.ListObject;
                        PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow rAct = (PMDS.Global.db.ERSystem.dsTermine.v‹bergabeRow)v.Row;
                        lst‹bergabe.Add(rAct);
                    }
                }

            }
        }

        public virtual void getTermine(PMDS.Global.eUITypeTermine UITypeTermine, ref bool LayoutFound,
                                        bool ManualParamtersFromUser)
		{
            try
            {
                //this._ds.Clear();
                //this.dgTermine.Refresh();

                this.MainWindow.btnOpenBefundIntervention.Visible = false;
                this.MainWindow.btnOpenBefund‹bergabe.Visible = false;

                this.MainWindow.txtSearchInGrid.Text = "";
                this.funct1.clearAllFilter(this.dgTermine);

                this.MainWindow.panelLoading.BackColor = System.Drawing.Color.Gray;
                this.MainWindow.panelLoading.Left = this.Width / 2 - (this.MainWindow.panelLoading.Width / 2);
                this.MainWindow.panelLoading.Top = (this.Height / 2 - (this.MainWindow.panelLoading.Height / 2)) - 60;


                if (this.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht || PMDS.Global.historie.HistorieOn)
                {
                    this.MainWindow.ClearMedizinischeButtons();
                }
                else
                {
                    GuiWorkflow.mainWindow.showInfoStatusBar(true, "", true);
                }

                //this.MainWindow.quickFilterButtons1.setLastClickedButton(ref bQuick);
                if (!ManualParamtersFromUser)
                {
                    if (this.MainWindow.quickFilterButtons1.QButtonClicked != null && !this.MainWindow.quickFilterButtons1.ManuellFilterClicked)
                    {
                        this.MainWindow.getSettingsFromQuickFilter(this.MainWindow.quickFilterButtons1.QButtonClicked, this.MainWindow.actualSettings, ref ManualParamtersFromUser);
                        this.MainWindow.ShowFilterSettingsInUI(this.MainWindow.actualSettings, ref ManualParamtersFromUser);
                    }
                    else
                    {
                        string xy = "";
                    }
                }

                this.MainWindow.panelLoading.Visible = true;
                Application.DoEvents();

                // Set DbParameter for Where-Clausel                
                PMDS.DB.DBTerminePara dbPar = new PMDS.DB.DBTerminePara();

                dbPar.From = this.MainWindow.ucTerminTimePicker1.RangeFrom;
                dbPar.To = this.MainWindow.ucTerminTimePicker1.RangeTo;

                dbPar.BerufsstandJN = this.MainWindow.ucTerminFilterPicker1.ShowBerufsstand;
                dbPar.Berufsstand = this.MainWindow.ucTerminFilterPicker1.Berufsstand;

                dbPar.WichtigF¸rJN = this.MainWindow.ucTerminFilterPicker1.WichtigF¸rJN;
                dbPar.WichtigF¸r = this.MainWindow.ucTerminFilterPicker1.WichtigF¸r;

                dbPar.BezugJN = this.MainWindow.ucTerminFilterPicker1.ShowBezug;
                dbPar.IDBezug = this.MainWindow.ucTerminFilterPicker1.IDBezug;

                //setZeitfilter
                dbPar.IDMaﬂnahme = this.MainWindow.ucTerminFilterPicker1.IDMassnahme;
                dbPar.aIDMaﬂnahme = this.MainWindow.ucTerminFilterPicker1.MASSNAHMEN;

                dbPar.IDAbteilung = this.MainWindow._idAbteilungxy;
                dbPar.IDBereich = this.MainWindow._idBereich;
                
                dbPar.ShowCC = this.MainWindow.ucTerminFilterPicker1.ShowCC;
                dbPar.Abzeichnen = this.MainWindow.ucTerminFilterPicker1.Abzeichnen;
                dbPar.ZeitbezugJN = this.MainWindow.ucTerminFilterPicker1.ShowZeitbezugJN;
                dbPar.Zeitbezug = this.MainWindow.ucTerminFilterPicker1.ZeitbezugJNA;

                dbPar.PlanungsEintr‰geJN = this.MainWindow.ucTerminFilterPicker1.ShowPlanungsEintr‰geJN;
                dbPar.PlanungsEintr‰ge = this.MainWindow.ucTerminFilterPicker1.PlanungsEintr‰ge;

                dbPar.ZusatzwerteJN = this.MainWindow.ucTerminFilterPicker1.ShowZusatzwerte;
                dbPar.Zusatzwerte = this.MainWindow.ucTerminFilterPicker1.Zusatzwerte;

                dbPar.HerkunftPlanungsEintragJN = this.MainWindow.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag;
                dbPar.HerkunftPlanungsEintrag = this.MainWindow.ucTerminFilterPicker1.HerkunftPlanungsEintrag;

                if (this.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    dbPar.IDAufenthalt = Guid.Empty;
                }
                else if (this.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    dbPar.IDAufenthalt = PMDS.BusinessLogic.Aufenthalt.LastByPatient(this.MainWindow._idPatient);
                }

                this._ds.Clear();

                this.DoLayout(ref LayoutFound, this.MainWindow.quickFilterButtons1.QButtonClicked);

                dbPar.ansicht = this.MainWindow.ucSiteMapTermine1._ansichtmodi;
                Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgTermine;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    this._SqlCommand = "";

                    List<Guid> lstTmpKlienten = null;
                    if (this.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht &&
                        this.MainWindow.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs)
                    {
                        lstTmpKlienten = ucMedikamenteMainPicker.lstKlienten;
                    }
                    PMDSBusiness1.getTermine(ref UITypeTermine, ENV.IDKlinik, ref  this.MainWindow.ucSiteMapTermine1._ansichtmodi,
                                                ref dbPar, ref this._ds, ref this._SqlCommand, ref ucTermine.dsKlientenlisteStartGrid, ref lstTmpKlienten);
                    if (UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        grid.Refresh();

                        if (this.dgTermine.DisplayLayout.Bands[0].Columns[this._ds.vInterventionen.vonDatumColumn.ColumnName].Style == UWG.ColumnStyle.Default)
                        {
                            this.dgTermine.DisplayLayout.Bands[0].Columns[this._ds.vInterventionen.vonDatumColumn.ColumnName].Style = UWG.ColumnStyle.DateTime;  
                        }
                        if (this.dgTermine.DisplayLayout.Bands[0].Columns[this._ds.vInterventionen.bisDatumColumn.ColumnName].Style == UWG.ColumnStyle.Default)
                        {
                            this.dgTermine.DisplayLayout.Bands[0].Columns[this._ds.vInterventionen.bisDatumColumn.ColumnName].Style = UWG.ColumnStyle.DateTime;
                        }

                        //grid.DataSource = this._ds;
                        //grid.DataMember = this._ds.vInterventionen.TableName;
                        //dgTermine.DataBind();
                        //grid.DataSource = System.Linq.Enumerable.ToList(vInterventionen1);
                        //dgTermine.DataBind();
                    }
                    else if (UITypeTermine == eUITypeTermine.‹bergabe || UITypeTermine == eUITypeTermine.Dekurs)
                    {
                        grid.Refresh();
                    }
                    else
                    {
                        throw new Exception("ucTermine.UpdateTermine: " + "UITypeTermine '" + UITypeTermine.ToString() + "' not allowed!");
                    }

                    this.DoLayout(ref LayoutFound, this.MainWindow.quickFilterButtons1.QButtonClicked);
                    if (dgTermine.DisplayLayout.Rows.Count > 0)
                    {
                        //dgTermine.DisplayLayout.Rows[0].ExpandAll();
                    }
                    dgTermine.ActiveRow = null;
                }

                if (dbPar.ZeitbezugJN && dbPar.Zeitbezug.Count > 0)
                {
                    bool MitpflegediagnosAbzeichnenJa = false;
                    foreach (int IDZeitbezug in dbPar.Zeitbezug)
                    {
                        if (IDZeitbezug == (int)PMDS.Global.eModusTermine.MitPflegediagnoseAbzeichnen)
                        {
                            MitpflegediagnosAbzeichnenJa = true;
                        }
                    }
                    this.MainWindow.btnPDxR¸ckmelden.Visible = MitpflegediagnosAbzeichnenJa;
                }
                else
                {
                    this.MainWindow.btnPDxR¸ckmelden.Visible = false; 
                }

            }
            catch (Exception ex)
            {
                this.MainWindow.panelLoading.Visible = false;
                throw new Exception("ucTermine.getTermine: " + ex.ToString());
            }
            finally
            {
                this.showStatusBarFound();
                this.MainWindow.panelLoading.Visible = false;
            }
		}

        public void DoLayout(ref bool LayoutFound, QuickFilterButton bQuick)
        {
            qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
            compLayout1.initControl();

            if (bQuick != null)
            {
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)bQuick.Tag;
                this.MainWindow.quickFilterButtons1.doQuickFilterButton(bQuick, ref LayoutFound, this.MainWindow.UITypeTermine);
                if (!LayoutFound)
                {
                    compLayout1.doLayoutGrid(this.dgTermine, this.dgTermine.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgTermine);
                }
            }
            else
            {
                compLayout1.doLayoutGrid(this.dgTermine, this.dgTermine.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global .ENV .AutoAddNewRessources);
                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgTermine);
            }
        }

        public void PrintTermine(bool ShowVitalzeichenJN)
        {          
            try
            {
                PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable tTermineForPrint = new Global.db.ERSystem.dsTermine.vInterventionenDataTable();
                this.getExpandedGridNode(ref tTermineForPrint);

                if (tTermineForPrint.Rows.Count > 0)
                {
//#if DEBUG
//                    DataSet ds = new DataSet();
//                    ds.DataSetName = "Termin";
//                    ds.Tables.Add(tTermineForPrint);
//                    ds.WriteXml((System.IO.Path.Combine(ENV.ReportPath, "Termine.xml")), System.Data.XmlWriteMode.WriteSchema);
//                    ds.WriteXmlSchema((System.IO.Path.Combine(ENV.ReportPath, "Termine.xsd")));
//#endif
                    //DataTable dtForReport = PMDS.DB.BusinessHelp.ToDataTable(lstInterventionen);
                    GuiAction.PreviewTerminliste(tTermineForPrint, this.MainWindow.ucSiteMapTermine1._ansichtmodi, this.MainWindow.ucSiteMapTermine1._UITypeTermine, ShowVitalzeichenJN);
                }
                else
                {
                    this.MainWindow.uDropDownDrucken.CloseUp();
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Interventionen vorhanden", "Drucken", MessageBoxButtons.OK);

                    //System.Collections.Generic.List<PMDS.db.Entities.vInterventionen> lstTermine = new System.Collections.Generic.List<PMDS.db.Entities.vInterventionen>();
                    //lstTermine = (System.Collections.Generic.List<PMDS.db.Entities.vInterventionen>)this.dgTermine.DataSource;
                    //if (lstTermine.Count > 0)
                    //{
                    //    DataTable dtForReport = PMDS.DB.BusinessHelp.ToDataTable(lstTermine);
                    //    GuiAction.PreviewTerminliste(dtForReport, this.MainWindow.ucSiteMapTermine1._ansichtmodi, this.MainWindow.ucSiteMapTermine1._UITypeTermine);
                    //}
                    //else
                    //{
                    //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Interventionen vorhanden", "Drucken", MessageBoxButtons.OK);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermine.PrintTerminListe: " + ex.ToString());
            }
        }

        public void getExpandedGridNode(ref PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable tTermineForPrint)
        {
            try
            {
                foreach (UltraGridRow rFoundInGrid in this.dgTermine.Rows)
                {
                    if (rFoundInGrid.IsGroupByRow && rFoundInGrid.Expanded && !rFoundInGrid.IsFilteredOut)
                    {
                        this.getExpandedGridNode_rek(ref tTermineForPrint, rFoundInGrid);
                    }
                    if (!rFoundInGrid.IsGroupByRow && !rFoundInGrid.IsFilteredOut)
                    {
                        DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                        PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rSelected = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)v.Row;
                        PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow NewRowForPrint = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)tTermineForPrint.NewRow();
                        NewRowForPrint.ItemArray = rSelected.ItemArray;
                        tTermineForPrint.Rows.Add(NewRowForPrint);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermine.getExpandedGridNode: " + ex.ToString());
            }
        }
        public void getExpandedGridNode_rek(ref PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable tTermineForPrint, UltraGridRow rFoundInGridParent)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow && rFoundInGrid.Expanded && !rFoundInGrid.IsFilteredOut)
                        {
                            this.getExpandedGridNode_rek(ref tTermineForPrint, rFoundInGrid);
                        }
                        else if (!rFoundInGrid.IsGroupByRow && !rFoundInGrid.IsFilteredOut)
                        {
                            DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                            PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rSelected = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)v.Row;
                            PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow NewRowForPrint = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)tTermineForPrint.NewRow();
                            NewRowForPrint.ItemArray = rSelected.ItemArray;
                            tTermineForPrint.Rows.Add(NewRowForPrint);

                        }
                        else if (!rFoundInGrid.IsGroupByRow && rFoundInGrid.IsFilteredOut)
                        {
                            string xy = "";
                        }
                        else
                        {
                            string xy = "";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void showStatusBarFound()
        {
            try
            {
                if (dgTermine != null)
                    GuiWorkflow.mainWindow.showInfoStatusBar(false, "Gefunden: " + dgTermine.Rows.Count.ToString(), true);
                else
                    GuiWorkflow.mainWindow.showInfoStatusBar(false, "", true);
            }
            catch (Exception ex)
            {
                throw new Exception("ucTermine.showStatusBarFound: " + ex.ToString());
            }
        }

        private void dgTermine2_AfterCellActivate(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void dgTermine2_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                if (dgTermine.Focused)
                {
                    this.Cursor = Cursors.Default;
                    OnTerminSelected(EventArgs.Empty);
                    this.showStatusBarFound();
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
        private void dgTermine2_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().Equals("Auswahl", StringComparison.CurrentCultureIgnoreCase))
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                    //OnTerminSelected(EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void dgTermine2_BeforeRowActivate(object sender, RowEventArgs e)
        {
            try
            {
                this.showStatusBarFound();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void dgTermine2_BeforeRowRegionScroll(object sender, BeforeRowRegionScrollEventArgs e)
        {
            try
            {
                //if (dgTermine.DisplayLayout.UIElement.LastElementEntered != null)

                //    if (dgTermine.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                //         dgTermine.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                //         dgTermine.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement)
                //        && !dgTermine.Focused)

                //        e.Cancel = true;  
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void dgTermine2_Click(object sender, EventArgs e)
        {
            try
            {
                this.MainWindow.btnOpenBefundIntervention.Visible = false;
                this.MainWindow.btnOpenBefund‹bergabe.Visible = false;

                Infragistics.Win.UltraWinGrid.UltraGrid GridTmp = (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgTermine;
                if (this.UIFct1.evClickOK(ref sender, ref e, ref GridTmp))
                {
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        if (CurTerminRowIntervention != null)
                        {
                            if (!CurTerminRowIntervention.IsIDBefundNull())
                            {
                                this.MainWindow.btnOpenBefundIntervention.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (CurTerminRow‹bergabe != null)
                        {
                            if (!CurTerminRow‹bergabe.IsIDBefundNull())
                            {
                                this.MainWindow.btnOpenBefund‹bergabe.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void dgTermine2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIFct1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgTermine))
                {
                    if (this.MainWindow.UITypeTermine == eUITypeTermine.Interventionen)
                    {

                        if (CurTerminRowIntervention == null)
                            return;
                    }
                    else
                    {
                        if (CurTerminRow‹bergabe == null)
                            return;
                    }
                    OnTerminDoubleClick(EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }   
    
	}

}
