using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucFormular.
	/// </summary>
	public class ucFormular : System.Windows.Forms.UserControl, IUCPageElement
	{
		
		private float			_zoom = 1.0f;
		private FormularStyle	_formularstyle = FormularStyle.Endless;
		private PageMode		_pagemode ;
		private ArrayList		_ap = new ArrayList();
		private Formular		_formular;

		private bool			_readonly = false;
        private int _iPageCount = 0;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private FormularGenLib.ucImageDocumentation ucImageDocumentation1;
        private Panel pnlMain;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager layBildDoku;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager layOben;
        private IContainer components;
        public Infragistics.Win.Misc.UltraExpandableGroupBox uExpanBilddokumentation;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Panel panelGesamt;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;

		public event EventHandler	ContentChanged;

        private int _lastSplitterDist = 600;
		
		
		public Formular		FORMULAR {get{return _formular;} set{_formular = value; RecreateAll();}}
		public bool ADDPICTURESALLOWED 
		{ 
			get 
			{
				bool bRet =_formular == null ? false : _formular.ADDPICTURESALLOWED;
				return bRet;
			} 
			set 
			{
				if(_formular == null)
					return;
				_formular.ADDPICTURESALLOWED = value;
				ShowHidePictures();
			}
        }

		public ucFormular()
		{
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.tabMain = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.layBildDoku = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.layOben = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.ucImageDocumentation1 = new FormularGenLib.ucImageDocumentation();
            this.uExpanBilddokumentation = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.panelGesamt = new System.Windows.Forms.Panel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layBildDoku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uExpanBilddokumentation)).BeginInit();
            this.uExpanBilddokumentation.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            this.panelGesamt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.ActiveTabAppearance = appearance3;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 64);
            this.tabMain.Name = "tabMain";
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabMain.ShowButtonSeparators = true;
            this.tabMain.Size = new System.Drawing.Size(727, 454);
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.TabHeaderAreaAppearance = appearance4;
            this.tabMain.TabIndex = 0;
            this.tabMain.Visible = false;
            this.tabMain.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.tabMain_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(723, 431);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(750, 64);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Visible = false;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // layBildDoku
            // 
            this.layBildDoku.ExpandToFitHeight = true;
            this.layBildDoku.ExpandToFitWidth = true;
            // 
            // layOben
            // 
            this.layOben.ExpandToFitHeight = true;
            this.layOben.ExpandToFitWidth = true;
            // 
            // ucImageDocumentation1
            // 
            this.ucImageDocumentation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageDocumentation1.FORMULAR = null;
            this.ucImageDocumentation1.Location = new System.Drawing.Point(0, 0);
            this.ucImageDocumentation1.Name = "ucImageDocumentation1";
            this.ucImageDocumentation1.Size = new System.Drawing.Size(200, 100);
            this.ucImageDocumentation1.TabIndex = 0;
            this.ucImageDocumentation1.Load += new System.EventHandler(this.ucImageDocumentation1_Load);
            // 
            // uExpanBilddokumentation
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.uExpanBilddokumentation.Appearance = appearance1;
            this.uExpanBilddokumentation.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.uExpanBilddokumentation.Dock = System.Windows.Forms.DockStyle.Right;
            this.uExpanBilddokumentation.Expanded = false;
            this.uExpanBilddokumentation.ExpandedSize = new System.Drawing.Size(222, 454);
            appearance2.FontData.SizeInPoints = 10F;
            this.uExpanBilddokumentation.HeaderAppearance = appearance2;
            this.uExpanBilddokumentation.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.RightOutsideBorder;
            this.uExpanBilddokumentation.Location = new System.Drawing.Point(727, 64);
            this.uExpanBilddokumentation.Name = "uExpanBilddokumentation";
            this.uExpanBilddokumentation.Size = new System.Drawing.Size(23, 454);
            this.uExpanBilddokumentation.TabIndex = 0;
            this.uExpanBilddokumentation.Text = "Bilddokumentation";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ucImageDocumentation1);
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(200, 100);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            this.ultraExpandableGroupBoxPanel1.Visible = false;
            // 
            // panelGesamt
            // 
            this.panelGesamt.Controls.Add(this.tabMain);
            this.panelGesamt.Controls.Add(this.uExpanBilddokumentation);
            this.panelGesamt.Controls.Add(this.pnlMain);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panelGesamt, gridBagConstraint1);
            this.panelGesamt.Location = new System.Drawing.Point(5, 5);
            this.panelGesamt.Name = "panelGesamt";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panelGesamt, new System.Drawing.Size(714, 484));
            this.panelGesamt.Size = new System.Drawing.Size(750, 518);
            this.panelGesamt.TabIndex = 1;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panelGesamt);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(760, 528);
            this.ultraGridBagLayoutPanel1.TabIndex = 2;
            // 
            // ucFormular
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucFormular";
            this.Size = new System.Drawing.Size(760, 528);
            this.Load += new System.EventHandler(this.ucFormular_Load);
            this.Resize += new System.EventHandler(this.ucFormular_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layBildDoku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uExpanBilddokumentation)).EndInit();
            this.uExpanBilddokumentation.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.panelGesamt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Bestimmt den Anzeigestil entweder als Karteireiter oder Endlos
		/// </summary>
		//--------------------------------------------------------------------------------
		public FormularStyle FORMULARSTYLE 
		{
			get
			{
				return _formularstyle;
			}
			set
			{
				try 
				{
					RemoveAllPages(); 
					_formularstyle = value; 
					tabMain.Visible = (_formularstyle == FormularStyle.Tab);
					RecreateAll();
				}
				catch{}
			}
		}

		public int			ZOOM 
		{ 
			get 
			{ return (int)(_zoom*100);
			} 
			set 
			{ 
				try 
				{
					int it = 0;
					if(tabMain.Tabs.Count > 0 && _formularstyle == FormularStyle.Tab) 
					{
						tabMain.BeginUpdate();
						it =  tabMain.SelectedTab.Index;
					}
					_zoom = ((float)value) /100.0f; 
					ReposAll();

					if(tabMain.Tabs.Count > 0 && _formularstyle == FormularStyle.Tab) 
						tabMain.SelectedTab = tabMain.Tabs[it];
				}
				finally
				{
					tabMain.EndUpdate();
				}

			}
		}

		private void FocusOnLastPage()
		{
			if(tabMain.Tabs.Count == 0)
				return;

			if(_formularstyle == FormularStyle.Tab)
				tabMain.Tabs[tabMain.Tabs.Count -1].Selected = true;
		}

		public void NewPage(Page.PageFormat format, Page.PageOrientation orientation) 
		{
			ucPage p = new ucPage();
			p.ContentChanged +=new EventHandler(page_ContentChanged);
			p.PAGE = _formular.AddPage();		// Format usw wird in usPage der Page zugewiesen
			p.FORMAT = format;
			p.ORIENTATION = orientation;
			p.ZOOM = this.ZOOM;
			_ap.Add(p);
			ReposAll();
			ContentChangedSignal();
			FocusOnLastPage();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Entfernt das angegebene Element
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemovePage(int iPageNumber)
		{
			if(iPageNumber > _ap.Count || iPageNumber == -1)
				return;

			Page p = ((ucPage)_ap[iPageNumber -1]).PAGE;
			Control c = (Control)_ap[iPageNumber -1];
			this.pnlMain.Controls.Remove(c);				// Aus der Oberfläche entfernen
			_formular.RemovePage(p);						// Aus dem Formular entfernen
			RemoveControlFromList(c);						// Aus der internen Liste entfernen
			ReposAll();
			ContentChangedSignal();
			FocusOnLastPage();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Entfernt eine ucPage von der internen Formularliste
		/// </summary>
		//--------------------------------------------------------------------------------
		private void RemoveControlFromList(Control c) 
		{
			ArrayList al = new ArrayList();
			foreach(Control cv in _ap)
				if(!cv.Equals(c))
					al.Add(cv);

			_ap = al;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Contentchanged Signal
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ContentChangedSignal() 
		{
			if(ContentChanged != null)
				ContentChanged(this, null);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Prüft auf treffer und liefert bei treffer das Control
		/// </summary>
		//--------------------------------------------------------------------------------
		private ucPage HitTest(int x, int y) 
		{
			foreach(ucPage c in this.pnlMain.Controls)
			{
				if(c.Left <= x && c.Left+c.Width >= x && c.Top <= y && c.Top + c.Height >= y)
				{
					return c;
				}
			}
			return null;
		}

		
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten im Endlessmodus entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void RemoveAllPagesEndless() 
		{
			foreach(ucPage p in _ap)
				this.pnlMain.Controls.Remove(p);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten im endlos Modus neu anordnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ReposAllEndless() 
		{
			RemoveAllPagesEndless();
			int x = 0;
			int y = 0;
			foreach(ucPage p in _ap) 
			{
				p.ZOOM = ZOOM;
				this.pnlMain.Controls.Add(p);
				p.Top = y;
				p.Left = x;
				y += p.Height;
			}

			this.Refresh();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten im endlos Modus neu anordnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ReposAllTab() 
		{
			foreach(ucPage p in _ap) 
				p.Parent = null;

			RemoveAllPagesTab();
			int iCount = 1;
			foreach(ucPage p in _ap) 
			{
				p.ZOOM = ZOOM;
				p.PAGEMODE = PAGEMODE;
				string s = iCount.ToString();
				UltraTab t = tabMain.Tabs.Add(s,s);
				Panel pnl = new Panel();
				pnl.Dock = DockStyle.Fill;
				pnl.AutoScroll = true;
				pnl.Controls.Add(p);
				t.TabPage.Controls.Add(pnl);
				iCount++;
			}

			this.Refresh();
		}

		private void RemoveAllPagesTab()
		{
			tabMain.Tabs.Clear();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Seiten entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void RemoveAllPages() 
		{
			if(_formularstyle == FormularStyle.Endless)
				RemoveAllPagesEndless();
			if(_formularstyle == FormularStyle.Tab)
				RemoveAllPagesTab();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		///	Alle Seiten neu anordnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ReposAll() 
		{
			if(_formularstyle == FormularStyle.Endless)
				ReposAllEndless();
			else if(_formularstyle == FormularStyle.Tab)
				ReposAllTab();

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alles neu erzeugen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void RecreateAll() 
		{
			if(_formular == null || _formular.PAGES == null)
				return;
			RemoveAllPages();
			_ap = new ArrayList();
			foreach(Page p in _formular.PAGES) 
			{
				ucPage ucp = new ucPage();
				ucp.ContentChanged +=new EventHandler(page_ContentChanged);
				ucp.PAGE = p;
				_ap.Add(ucp);
			}
			ReposAll();
			ucImageDocumentation1.FORMULAR = _formular;
			ShowHidePictures();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Labels aktualiseren
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RefreshLabels() 
		{
			if(PAGEMODE != PageMode.Editable && PAGEMODE != PageMode.Readonly)
				return;
			if(_formular == null)
				return;
			_formular.BeginPrinting();
			int iCount = 1;
			foreach(ucPage p in _ap)
			{
				_formular.SetPageEnvironment(iCount);
				p.RefreshLabels(_formular.ENV);
				iCount++;
			}

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// On paint
		/// </summary>
		//--------------------------------------------------------------------------------
		protected override void OnPaint(PaintEventArgs e)
		{
			if(_selectbox) 
			{
				Graphics g = e.Graphics;
				g.DrawRectangle(Pens.Blue, 0,0, this.Width-1, this.Height-1);
			}
				
			base.OnPaint (e);
			RefreshLabels();

		}



		#region IUCPageElement Members

		public bool ReadOnly
		{
			get
			{
				return _readonly;
			}
			set
			{
				_readonly = value;
				ucImageDocumentation1.Enabled = !_readonly;
			}
		}

		public FormularGen.PageMode PAGEMODE
		{
			get
			{
				return _pagemode;
			}
			set
			{
				_pagemode = value;
				foreach(ucPage p in _ap)
					p.PAGEMODE	= value;
				RefreshLabels();
			}
		}


		private bool			_selectbox= false;
		public bool SELECTBOX
		{
			get 
			{
				return _selectbox;
			}
			set 
			{
				_selectbox = value;
				this.Refresh();
			}
		}

		public IPageElement IPAGEELEMENT 
		{
			get 
			{
				return null;
			}
		}

	
		#endregion

		private void page_ContentChanged(object sender, EventArgs e)
		{
			ContentChangedSignal();
			if(PAGEMODE == PageMode.Editable || PAGEMODE == PageMode.Readonly)
				RefreshLabels();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Formular drucken (Mit Druckdialog)
		/// </summary>
		//--------------------------------------------------------------------------------
		public void PrintFormular()
		{
			if(FORMULAR.PAGES.Length == 0)
				return;
			Page.PageOrientation	orientation = FORMULAR.PAGES[0].ORIENTATION;
			Page.PageFormat			format		= FORMULAR.PAGES[0].FORMAT;

			PrintDocument d = new PrintDocument();
			PrintDialog dlg = new PrintDialog();
			
			FORMULAR.BeginPrinting();					// Environment rücksaetzen

			d.PrintPage +=new PrintPageEventHandler(d_PrintPage);
			dlg.Document = d;
			DialogResult res = dlg.ShowDialog();
			if(res != DialogResult.OK)
				return;

			_iPageCount = 1;
			d.Print();

		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Seiten Event
		/// </summary>
		//--------------------------------------------------------------------------------
		private void d_PrintPage(object sender, PrintPageEventArgs e)
		{
			Formular f = FORMULAR;
			if( _iPageCount+1 > f.PAGES.Length)
				e.HasMorePages = false;
			else
				e.HasMorePages = true;
			f.PrintPage(_iPageCount, e.Graphics);
			_iPageCount++;
		}

		private void tabMain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
		
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Picture Elemente zeigen / verstecken
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ShowHidePictures()
		{
            if (_formular.ADDPICTURESALLOWED)
            {
                this.uExpanBilddokumentation.Visible = true;
                this.uExpanBilddokumentation.Text = "Bilddokumentation";
            }
            else
            {
                this.uExpanBilddokumentation.Expanded  = false;
                this.uExpanBilddokumentation.Visible = false;
                this.uExpanBilddokumentation.Text  = "Keine Bilddokumentation möglich";
            }
            this.resizeBilddokumentation(this.uExpanBilddokumentation.Expanded);
       }

		public override void Refresh()
		{
			base.Refresh ();
			if(ADDPICTURESALLOWED)
				ucImageDocumentation1.FORMULAR = _formular;			// aktualisieren
		}

        private void ultraDockManager1_BeforeDockChange(object sender, Infragistics.Win.UltraWinDock.BeforeDockChangeEventArgs e)
        {

        }

        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {

        }

        private void ultraExplorerBar1_Resize(object sender, EventArgs e)
        {
            this.resizeBilddokumentation(this.uExpanBilddokumentation.Expanded);
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Control auf horizontal umgestaltet, neu gestaltet
        /// [lth]
        /// </summary>
        //--------------------------------------------------------------------------------
        private void resizeBilddokumentation(bool bOpen )
        {
            //if (this.splitContainer1.Height < 250) return;
            //            if (bOpen)
            //{
            //    if (this.splitContainer1.Height - this.splitContainer1.SplitterDistance <=  40) 
            //    {
            //       //this.splitContainer1.SplitterDistance = this.splitContainer1.Height /3;
            //        this.splitContainer1.SplitterDistance = this._lastSplitterDist;
            //    }
            //    this.ultraExplorerBar1.Groups[0].Settings.ContainerHeight = this.panelUnten.Height - 20;
            //    //this.layBildDoku .SetPreferredSize(Me.ultraExplorerBar1, New System.Drawing.Size(465, 24));
            //}
            //else
            //{
            //    this.ultraExplorerBar1.Groups[0].Settings.ContainerHeight = this.panelUnten.Height - 20;
            //    this.splitContainer1.SplitterDistance = this.splitContainer1.Height  -  38;
            //}
        }

        private void ucImageDocumentation1_Load(object sender, EventArgs e)
        {

        }

        private void ultraExplorerBar1_GroupClick(object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e)
        {
            this.resizeBilddokumentation(this.uExpanBilddokumentation.Expanded);
        }

        private void panelOben_Scroll(object sender, ScrollEventArgs e)
        {
            //this.resizeBilddokumentation(this.ultraExplorerBar1.Groups[0].Expanded);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //if (this.splitContainer1.Height < 250) return;
            //if (this.splitContainer1.SplitterDistance < 200) this.splitContainer1.SplitterDistance = 200;
            
            //if (this.ultraExplorerBar1.Groups[0].Expanded)
            //{
            //  this._lastSplitterDist = this.splitContainer1.SplitterDistance;
            //}
            //this.resizeBilddokumentation(this.ultraExplorerBar1.Groups[0].Expanded);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucFormular_Resize(object sender, EventArgs e)
        {
            //this._lastSplitterDist = this.splitContainer1.Height / 2;
        }

        private void ucFormular_Load(object sender, EventArgs e)
        {
            this.FORMULARSTYLE = FormularStyle.Tab;
        }
		
	}

	//--------------------------------------------------------------------------------
	/// <summary>
	/// Formularstyle
	/// </summary>
	//--------------------------------------------------------------------------------
	public enum FormularStyle
	{
		Endless,				// Seiten werden untereinander dargestellt
		Tab						// Seiten werden als Karteitreiter dargestellt
	}


	//--------------------------------------------------------------------------------
	/// <summary>
	/// Interface eines Pageelementes
	/// </summary>
	//--------------------------------------------------------------------------------
	public interface IUCPageElement 
	{
		bool ReadOnly{get;set;}				// Keine Eingabe möglich
		PageMode PAGEMODE {get;set;}		// Setzt den Modus
		int ZOOM {get;set;}					// Zoom faktor in %
		bool SELECTBOX {get;set;}			// True wenn eine Selectbox gezeichnet werden soll false sonst
		IPageElement IPAGEELEMENT {get;}	// Liefert das zugehörige Pageelement
		event EventHandler	ContentChanged;
		
	}
}
