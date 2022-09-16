using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.Global.db.Global;



namespace PMDS.GUI.BaseControls
{


	public class QuickFilterButtons : QS2.Desktop.ControlManagment.BaseControl
	{
		public event QuickFilterButtonPressDelegate QuickFilterButtonClick;

		private QuickFilterManager		_manager = new QuickFilterManager();

        private QS2.Desktop.ControlManagment.BasePanel pnlMain;
		private System.ComponentModel.IContainer components;

        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager toolTip1;
        public Infragistics.Win.UltraWinGrid.UltraGrid _gridxy = null;


        public PMDS.GUI.BaseControls.QuickFilterButton QButtonClicked = null;

        public ucTermineEx _MainWindow = null;

        public bool RefreshButtons = false;

        public PMDS.Global.eUITypeTermine _UITypeTermine = eUITypeTermine.None;

        public int _wMainWindow = -1;
        public PMDS.DB.DBQuickFilter DBQuickFilter1 = new DB.DBQuickFilter();
        
        public bool ManuellFilterClicked = false;
        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();

        








        public QuickFilterButtons()
		{
			InitializeComponent();

		    pnlMain.BorderStyle = BorderStyle.None;
			if(!ENV.AppRunning)
				return;

            ENV.dMainWindowResized += new ENV.dMainWindowResizedDelegate(this.MainWindowResizedDelegate);
		}

        public void MainWindowResizedDelegate(Size sMainWindow)
        {
            this.ReposButtons(sMainWindow.Width); 
        }
		public void drawButtons(Infragistics.Win.UltraWinGrid.UltraGrid gridTmp,
                                    ucTermineEx MainWindow, ref PMDS.Global.eUITypeTermine UITypeTermine)
		{
            try
            {
                this._UITypeTermine = UITypeTermine;
                this._MainWindow = MainWindow;

     		    Font f = new Font("Arial", 10);
                this.clearQuickhButtons();

                this._gridxy = gridTmp;

			    dsQuickFilter.QuickFilterDataTable dt = new dsQuickFilter.QuickFilterDataTable();

                dt = _manager.ReadAll(ENV.CurrentIDAbteilung, ENV.IDKlinik);
                
                int y = pnlMain.Width;

                this._MainWindow.IDKlinikLast = ENV.IDKlinik;
                this._MainWindow.IDAbteilungLast = ENV.CurrentIDAbteilung;

                int anz = 0;
			    using (Graphics g = this.CreateGraphics()) 
			    {
				    g.PageUnit = GraphicsUnit.Pixel;
				    foreach(dsQuickFilter.QuickFilterRow r in dt)
                    {
                        QuickFilterButton b;
                        if (anz < this.pnlMain.Controls.Count)
                        {
                            b = (QuickFilterButton)pnlMain.Controls[anz];                       
                        }
                        else
                        {
                            b = new  QuickFilterButton();
                            b.Click += new EventHandler(button_Click);

                            b.UseAppStyling = true;

                            PMDS.Global.UIGlobal.setUIButton(b, false);
                            b.initControl();
                            pnlMain.Controls.Add(b);
                        }

                        b.MainWindow = this;

                        string sBezeichnungTmp = "";
                        sBezeichnungTmp = r.Bezeichnung;
                        if (ENV.adminSecure)
                        {
                            //sBezeichnungTmp += " [Key:" + r.KeyQuickFilter + ", Layout:" + r.KeyLayout + "]";
                        }

                        SizeF sf = g.MeasureString(sBezeichnungTmp, f);
                        int iW = (int)sf.Width + 9;
                        
                        bool DrawButton = false;
                        if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
                        {
                            if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                            {
                                if (r.BenutzenInInterventionJN)
                                {
                                    DrawButton = true;
                                }
                            }
                            else if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                            {
                                if (r.BereichIntervention)
                                {
                                    DrawButton = true;
                                }
                            }
                        }
                        else if (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe)
                        {
                            if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                            {
                                if (r.BenutzenInEvaluierungJN)
                                {
                                    DrawButton = true;
                                }
                            }
                            else if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                            {
                                if (r.BereichÜbergabe)
                                {
                                    DrawButton = true;
                                }
                            }
                        }
                        else if (UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs)
                        {
                            if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                            {
                                if (r.BenutzenInDekursJN)
                                {
                                    DrawButton = true;
                                }
                            }
                            else if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                            {
                                if (r.BereichDekurs)
                                {
                                    DrawButton = true;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("drawButtons: UITypeTermine '" + UITypeTermine.ToString() + "' not allowed!");
                        }

                        bool BerufsstandUserOK = false;
                        if (r.LstBSQuickfilter.Trim() == "")
                        {
                            BerufsstandUserOK = true;
                        }
                        else
                        {
                            System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                            this.UISitemaps1.getListGuidFromString(r.LstBSQuickfilter.Trim(), ref lstGuid);
                            PMDS.db.Entities.Benutzer rBenutzer = this.PMDSBusiness1.LogggedOnUser();
                            foreach (Guid IDBerufsstandQuickButton in lstGuid)
                            {
                                if (IDBerufsstandQuickButton.Equals(rBenutzer.IDBerufsstand))
                                {
                                    BerufsstandUserOK = true;
                                }
                            }
                        }

                        //if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                        //{
                        //    if ((UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen && r.BenutzenInInterventionJN && !r.BereichIntervention) ||
                        //        (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe && r.BenutzenInEvaluierungJN && !r.BereichÜbergabe) ||
                        //        (UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs && r.BenutzenInDekursJN && !r.BereichDekurs))
                        //    {
                        //    }
                        //}
                        //else if (this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                        //{
                        //    if ((UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen && r.BenutzenInInterventionJN && r.BereichIntervention) ||
                        //        (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe && r.BenutzenInEvaluierungJN && r.BereichÜbergabe) ||
                        //        (UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs && r.BenutzenInDekursJN && r.BereichDekurs))
                        //    {
                        //    }
                        //}
                        //else
                        //{
                        //    throw new Exception("drawButtons: _ansichtmodi '" + this._MainWindow.MainWindow.ucSiteMapTermine1._ansichtmodi.ToString() + "' not allowed!");
                        //}
                        if (DrawButton && BerufsstandUserOK)
                        {
                            anz += 1;

                            b.Visible = true;

                            b.Enabled = true;
                            b.Width = iW;
                            b.Top = 1;
                            b.Text = sBezeichnungTmp;

                            QS2.Desktop.ControlManagment.BaseButton baseButt = (QS2.Desktop.ControlManagment.BaseButton)b;
                            b.doBaseElements1.InfoControl._IsQuickFilter = true;
                            baseButt.AutoWorkLayout = false;
                            b.SetGrid((QS2.Desktop.ControlManagment.BaseGrid)gridTmp);

                            if (baseButt.doBaseElements1.ControlManagment1.delOnSaveLayoutClick != null)
                            {
                                foreach (Delegate d in baseButt.doBaseElements1.ControlManagment1.delOnSaveLayoutClick.GetInvocationList())
                                {
                                    baseButt.doBaseElements1.ControlManagment1.delOnSaveLayoutClick -= (QS2.Desktop.ControlManagment.ControlManagment.onSaveLayoutClick)d;
                                } 
                            }
                            //b.onSaveLayoutClick += new QS2.Desktop.ControlManagment.ControlManagment.onSaveLayoutClick(b.OnLayoutSaved);
                            baseButt.doBaseElements1.ControlManagment1.delOnSaveLayoutClick += new QS2.Desktop.ControlManagment.ControlManagment.onSaveLayoutClick(this.OnLayoutSaved);
                            
                            QuickFilterButtonArgs args = new QuickFilterButtonArgs();
                            args.IDQuickFilter = r.ID;
                            args.BezugspersonJN = r.BezugspersonJN;
                            args.IDBenutzer = r.IsIDBenutzerNull() ? Guid.Empty : r.IDBenutzer;
                            args.IDEintrag = r.IsIDEintragNull() ? Guid.Empty : r.IDEintrag;
                            args.MassnahmeJN = r.MassnahmeJN;
                            args.RueckgemeldeteTermineJN = r.RueckgemeldeteTermineJN;
                            args.TageNachher = r.Tagenachher;
                            args.TageVorher = r.Tagevorher;
                            args.ZeitraumJN = r.ZeitraumJN;
                            args.Massnahmen = r.Massnahmen;
                            args.OhneZeitBezug = r.OhneZeitBezug;

                            args.LstErstelltVonBerufgruppe = r.LstErstelltVonBerufgruppe.Trim();
                            args.LstWichtigFürBerufsgruppe = r.LstWichtigFürBerufsgruppe.Trim();

                            args.LstZusatzwerte = r.LstZusatzwerte;
                            args.lstZeitbezugxy = r.LstZeitbezug;
                            args.ShowCC = r.ShowCC;
                            args.Abzeichnen = r.AbzeichnenJN;
                            args.LstPlanungseinträge = r.LstInterventionsTyp;
                            args.lstHerkunftPlanungsEintrag = r.LstHerkunftPlanungsEintrag;

                            args.ToolTip = r.Tooltip;
                            args.rQuickFilter = r;
                            args.IsVisible = true;

                            baseButt.doBaseElements1.InfoControl.QuickFilterKey = args.rQuickFilter.KeyQuickFilter.Trim();
                            baseButt.doBaseElements1.InfoControl.IDQuickfilterToSave = args.rQuickFilter.ID;

                            b.Name = r.KeyQuickFilter.Trim() + "_" + System.Guid.NewGuid().ToString();
                            b.Tag = args;

                            baseButt.AutoWorkLayout = false;
                            baseButt.doBaseElements1.InfoControl.defaultLayoutNamexy = "Quickfilter " + r.Bezeichnung.Trim();
                            baseButt.doBaseElements1.InfoControl.QuickFilterKey = r.KeyQuickFilter.Trim();
                            baseButt.doBaseElements1.InfoControl.KeyLayoutFromQuickfilter = args.rQuickFilter.KeyLayout;

                            //b.BringToFront();              

                            //if ((string)toolTip1.GetToolTip(b)!= (string)r.Tooltip) 
                            //{           

                            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                            ToolTipInfo.ToolTipTitle = "";
                            ToolTipInfo.ToolTipText = r.Tooltip;
                            toolTip1.SetUltraToolTip(b, ToolTipInfo);

                            bool DoIDResAuto = false;
                            baseButt.rRes = null;
                            baseButt.IDRes = r.KeyQuickFilter.Trim();
                            baseButt.IsLoaded = false;
                            bool IsStandardControl = false;
                            bool doContextMenü = true;
                            baseButt.contextMenuStrip1.Items.Clear();
                            baseButt.doBaseElements1.runControlManagment(ref baseButt.IDRes, baseButt, baseButt.contextMenuStrip1,
                                                                            ref baseButt.IsLoaded, ref baseButt.rRes, ref doContextMenü,
                                                                            ref IsStandardControl, ref DoIDResAuto);

                            if (r.IsStandard && this.QButtonClicked == null)
                            {
                                this.QButtonClicked = b;
                            }

                            //baseButt.doBaseElements1.InfoControl.dGetLastClickedQuickfilter += new QS2.Desktop.ControlManagment.doBaseElements.cInfoControl.GetLastClickedQuickfilter(this._MainWindow.MainWindow.ucSiteMapTermine1.getLastClickedQuickfilter);
                            //}
                            anz += 1;
                        }
                        else
                        {
                            b.Visible = false;
                        }
                    }
			    }
                this.RefreshButtons = true;
                this.ReposButtons(this._wMainWindow);
            }
            catch (Exception ex)
            {
                throw new Exception("RefreshButtonsxy: " + ex.ToString());
            }
		}

        public void OnLayoutSaved(System.Guid IDQuickFilter, qs2.core.vb.dsLayout.LayoutRow rLayout)
        {
            try
            {
                //string IDResReturnGrid = "";
                //string IDResDescriptionGrid = "";
                //QS2.Desktop.ControlManagment.ControlManagment.getIDREsForControl(grid, ref IDResReturnGrid, ref IDResDescriptionGrid);
                //string KeyReturn = KeyQuickfilter.Trim() + "_" + IDResReturnGrid.Trim();
                //return KeyReturn;

                QuickFilterButtonArgs QuickFilterButtonArgs1 = (QuickFilterButtonArgs)this.Tag;
                this.DBQuickFilter1.UpdateLayout(IDQuickFilter, rLayout.Key.Trim());

                //this.MainWindow.RefreshButtons();

                //this.MainWindow.ClickQuickFilterButton(this, ref LayoutFound);
                
                this.drawButtons(this._gridxy, this._MainWindow, ref this._UITypeTermine);

            }
            catch (Exception ex)
            {
                throw new Exception("QuickFilterButton.OnLayoutSaved: " + ex.ToString());
            }
        }
        public void clearQuickhButtons( )
        {
            foreach (QuickFilterButton b in pnlMain.Controls)
            {
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)b.Tag;
                if (args != null)
                {
                    args.IsVisible = false;
                }
                b.Visible = false;
            } 
        }
        
		public void ReposButtons(int wMainWindow)
		{
            this._wMainWindow = wMainWindow;

            if (this._MainWindow.UITypeTermine == eUITypeTermine.Dekurs && this._MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht &&
                    ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
            {
                wMainWindow = wMainWindow - 10;
            }
            else if (this._MainWindow.UITypeTermine == eUITypeTermine.Dekurs && this._MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht &&
                    ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
            {
                wMainWindow = wMainWindow - 203;
            }
            else if (this._MainWindow.UITypeTermine == eUITypeTermine.Dekurs && this._MainWindow.ucSiteMapTermine1._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht &&
                    ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
            {
                wMainWindow = wMainWindow - 203;
            }

            int HeigthOneZeile = 20;
            int HeigthOneButton = 20;
            int SpaceBetweenButtons = 2;
            bool OnlyOneZeile = false;
            if (wMainWindow < 200)
            {
                //OnlyOneZeile = true;
            }
            int LastWidthButton = 0;
            int iTop = 0;
            int iZeilenxy = 0;
            this._MainWindow.panelLeisteQuickButtons.Height = 26;
			int Sumw = 0;
			foreach(Control c in pnlMain.Controls)
			{
                QuickFilterButton bQuickButt = (QuickFilterButton)c;
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)bQuickButt.Tag;
                if (args != null && args.IsVisible)
                {
                    if (((Sumw + 27 + c.Width) > wMainWindow) && !OnlyOneZeile)
                    {
                        this._MainWindow.panelLeisteQuickButtons.Height += HeigthOneZeile;
                        Sumw = 0;
                        iZeilenxy += 1;
                        iTop += (HeigthOneZeile) + SpaceBetweenButtons;
                    }

                    c.Visible = true;
                    c.Top = iTop;
                    c.Left = wMainWindow - Sumw - (c.Width + SpaceBetweenButtons) - 24;
                    c.Height = HeigthOneButton;
                    Sumw += c.Width + SpaceBetweenButtons;
                    LastWidthButton = c.Width;
                }
			}
		}

		protected override void Dispose( bool disposing )
		{
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
            this.pnlMain = new QS2.Desktop.ControlManagment.BasePanel();
            this.toolTip1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(424, 32);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Resize += new System.EventHandler(this.pnlMain_Resize);
            // 
            // toolTip1
            // 
            this.toolTip1.ContainingControl = this;
            this.toolTip1.InitialDelay = 0;
            // 
            // QuickFilterButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuickFilterButtons";
            this.Size = new System.Drawing.Size(424, 32);
            this.VisibleChanged += new System.EventHandler(this.QuickFilterButtons_VisibleChanged);
            this.ResumeLayout(false);

		}
		#endregion

		private void pnlMain_Resize(object sender, System.EventArgs e)
		{
            //ReposButtons(this.Width);
		}

		private void button_Click(object sender, EventArgs e)
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool LayoutFound = false;
                QuickFilterButton bQuickFilter = (QuickFilterButton)sender;
                
                //this.ClickQuickFilterButtonxy((QuickFilterButton)sender, ref LayoutFound);
                //this._MainWindow.RefreshAll(false);

                this.QButtonClicked = bQuickFilter;
                this.ManuellFilterClicked = false;
                this._MainWindow.MainWindow.getTermine(this._MainWindow.MainWindow.UITypeTermine, ref LayoutFound, false);

            }
            catch( Exception ex )
            {
                ENV.HandleException(ex);
            }
            finally 
            {
                this.Cursor = Cursors.Default;
            }
		}
        public void doQuickFilterButton(QuickFilterButton bQuickFilter, ref bool LayoutFound,
                                            PMDS.Global.eUITypeTermine UITypeTermine)
        {
            try
            {
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)bQuickFilter.Tag;
                SetButtonClickedColor(((QuickFilterButtonArgs)bQuickFilter.Tag).IDQuickFilter); 

                bool doLayout = true;
                //this.CheckLayout("", ref LayoutFound, ref  bQuickFilter, ref  UITypeTermine, ref args, ref  doLayout);
                if (doLayout)
                {
                    if (args.rQuickFilter.KeyLayout.Trim() != "")
                    {
                        this.DoLayout(args.rQuickFilter.KeyLayout.Trim(), ref LayoutFound, bQuickFilter, ref  UITypeTermine, args, doLayout);
                    }
                    else
                    {
                        string IDResReturnGrid = args.rQuickFilter.KeyQuickFilter.Trim();    //PMDS.DB.DBQuickFilter.getLayoutKeyForQuickFilter(args.IDQuickFilter, args.rQuickFilter.KeyLayout.Trim(), this._grid);
                        this.DoLayout(IDResReturnGrid, ref LayoutFound, bQuickFilter, ref UITypeTermine, args, doLayout);
                    }
                }

                if (!LayoutFound)
                {
                    qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                    compLayout1.doLayoutGrid(bQuickFilter._grid, bQuickFilter._grid.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    if (!LayoutFound)
                    {
                        if (this._gridxy != null)
                        {
                            qs2.core.vb.compLayout co = new qs2.core.vb.compLayout();
                            co.resetLayoutGrid(this._gridxy);
                        }
                    }
                    QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(bQuickFilter._grid);
                }

                //if (QuickFilterButtonClick == null)
                //    return;
                //QuickFilterButtonClick((QuickFilterButtonArgs)bQuickFilter.Tag);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public void DoLayout(string sKey, ref bool LayoutFound, QuickFilterButton bQuickFilter, ref PMDS.Global.eUITypeTermine UITypeTermine,
                            QuickFilterButtonArgs args, bool doLayout)
        {
            try
            {
                qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                compLayout1.initControl();
                compLayout1.doLayoutGrid(bQuickFilter._grid, sKey.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                //QS2.Desktop.ControlManagment.cLayoutManager2 cLayoutManager1 = new QS2.Desktop.ControlManagment.cLayoutManager2();
                //cLayoutManager1.doLayoutGrid(bQuickFilter._grid, sKey.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);

                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(bQuickFilter._grid);
            }
            catch (Exception ex)
            {
                throw new Exception("QuickFilterButtons.DoLayout: " + ex.ToString());
            }
        }
        public void CheckLayout(string sKey, ref bool LayoutFound, ref QuickFilterButton bQuickFilter, ref PMDS.Global.eUITypeTermine UITypeTermine,
                                            ref QuickFilterButtonArgs args, ref bool doLayout)
        {

            doLayout = true;

            //if (args.rQuickFilter.BereichIntervention && !args.rQuickFilter.BereichÜbergabe && UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
            //{
            //    doLayoutBereichIntervention = true;
            //}
            //else if (!args.rQuickFilter.BereichIntervention && args.rQuickFilter.BereichÜbergabe && UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe)
            //{
            //    doLayoutBereichIntervention = true;
            //}
            //else if (args.rQuickFilter.BereichIntervention && args.rQuickFilter.BereichÜbergabe)
            //{
            //    doLayoutBereichIntervention = true;
            //}
            //else
            //{
            //    string xy = "";
            //}
        }

        public void SetButtonClickedColor(System.Guid  IDQuickFilter)
        {
            foreach (QuickFilterButton b in pnlMain.Controls)
            {
                if (!b.Visible)
                    continue;

                QuickFilterButtonArgs args;
                args = (QuickFilterButtonArgs)b.Tag;

                b.UseAppStyling = true;
                if (args.IDQuickFilter == IDQuickFilter)
                {
                    PMDS.Global.UIGlobal.setUIButton(b, true);
                    //b.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
                    b.HotTrackAppearance.BackColor = ENVCOLOR.hoverBackCol;
                }
                else
                {
                    PMDS.Global.UIGlobal.setUIButton(b, false);
                }
                b.HotTrackAppearance.BackColor = ENVCOLOR.hoverBackCol;

            }
        }

        public void setLastClickedButtonxyxy(ref QuickFilterButton bQuick)
        {
            if (bQuick != null)
            {
                QuickFilterButtonArgs args = (QuickFilterButtonArgs)bQuick.Tag;
                SetButtonClickedColor(args.IDQuickFilter);
            } 
        }

        private void QuickFilterButtons_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //this.setLastClickedButton();
                } 
            }
            catch(Exception ex)
            {
                throw new Exception("QuickFilterButtons_VisibleChanged: " + ex.ToString());
            }
        }       
		
	}

	public class QuickFilterButtonArgs 
	{
        public Guid IDQuickFilter               = Guid.Empty;                
		public bool MassnahmeJN					= false;
		public Guid IDEintrag					= Guid.Empty;
		public bool BezugspersonJN				= false;
		public Guid IDBenutzer 					= Guid.Empty;
		public bool ZeitraumJN 					= false;
		public int  TageVorher					= 0;
		public int  TageNachher					= 0;
		public bool RueckgemeldeteTermineJN		= false;
		public string Massnahmen				= "";
		public string ToolTip					= "";
        public int OhneZeitBezug                = 2;
        public dsQuickFilter.QuickFilterRow rQuickFilter = null;
        public bool IsVisible = false;

        public string LstErstelltVonBerufgruppe = "";
        public string LstWichtigFürBerufsgruppe = "";

        public int ShowCC = -1;
        public string LstPlanungseinträge = "";
        public string LstZusatzwerte = "";
        public string lstZeitbezugxy = "";
        public int Abzeichnen= -1;
        public string lstHerkunftPlanungsEintrag = "";

		public QuickFilterButtonArgs() 
		{

		}
	}

	public delegate void QuickFilterButtonPressDelegate(QuickFilterButton bQuick);
}
