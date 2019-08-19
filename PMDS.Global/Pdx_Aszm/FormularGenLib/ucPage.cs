using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FormularGen
{
	/// <summary>
	/// Summary description for ucSeite.
	/// </summary>
	public class ucPage : System.Windows.Forms.UserControl, IUCPageElement
	{
		private Page			_page;
		private float			_zoom = 1.0f;
		private PageMode		_pagemode = PageMode.Editable;
		private PageEditMode	_pageeditmode = PageEditMode.None;
		private Control			_actualselectedcontrol = null;
		private int				_relx;						// Gibt dir rel. MausPosition zum Objekt an
		private int				_rely;
		private int				_deltax = 0;
		private int				_deltay = 0;				// Für Mousemove event da der permanent auch ohne Mausbewegung aufgerufe wird
		private int				_lastx;
		private int				_lasty;

		private System.Windows.Forms.ContextMenu mnuInsert;
		private System.Windows.Forms.MenuItem mnuInsertRB;
		private System.Windows.Forms.MenuItem mnuInsertLabel;
		private System.Windows.Forms.MenuItem mnuDeleteItem;
		private System.Windows.Forms.MenuItem mnuInsertSUM;
		private System.Windows.Forms.MenuItem mnuInsertPageNo;
		private System.Windows.Forms.MenuItem mnuInsetTextbox;
		private System.Windows.Forms.MenuItem mnucb3;
		private System.Windows.Forms.MenuItem mnucb4;
		private System.Windows.Forms.MenuItem mnucb5;
		private System.Windows.Forms.MenuItem mnucb6;
		private System.Windows.Forms.MenuItem mnucb2;
		private System.Windows.Forms.MenuItem mnucbJN;
		private System.Windows.Forms.MenuItem mnuEditText;
		private System.Windows.Forms.MenuItem mnuInsertRBAlone;
		private System.Windows.Forms.MenuItem mnuInsertLine;
		private System.Windows.Forms.MenuItem mnuBringToFront;
		private System.Windows.Forms.MenuItem mnuBringToBack;
		private System.Windows.Forms.MenuItem mnuDelimiter;
		private System.Windows.Forms.MenuItem mnuSaveElement;
		private System.Windows.Forms.MenuItem mnuLoadElement;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuInsertDateCreated;
		private System.Windows.Forms.MenuItem mnuInsertDateChanged;
		private System.Windows.Forms.MenuItem mnuInsertUserCreated;
        private System.Windows.Forms.MenuItem mnuInsertKlient;
        private System.Windows.Forms.MenuItem mnuInsertKlientGebDat;
        private System.Windows.Forms.MenuItem mniInsertUserChanged;
		private System.Windows.Forms.MenuItem mnuInsertTimeCreated;
		private System.Windows.Forms.MenuItem mnuInsertTimeChanged;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem mnuInsertPrintTime;
		private System.Windows.Forms.MenuItem mnuInsertPrintDate;
		private System.Windows.Forms.MenuItem mnuInsertImage;
		private System.Windows.Forms.MenuItem mnuSum1;
		private System.Windows.Forms.MenuItem mnuSum2;
		private System.Windows.Forms.MenuItem mnuSum3;
		private System.Windows.Forms.MenuItem mnuSum4;
		private System.Windows.Forms.MenuItem mnuSum5;
		private System.Windows.Forms.MenuItem mnuSum6;
		private System.Windows.Forms.MenuItem mnuSum7;
		private System.Windows.Forms.MenuItem mnuSum8;
		private System.Windows.Forms.MenuItem mnuSum9;
		private System.Windows.Forms.MenuItem mnuSum10;

		public event EventHandler	ContentChanged;
		

		private System.ComponentModel.Container components = null;

		public ucPage()
		{
			InitializeComponent();
		}

		public Page PAGE						{ get {return _page;}				set{_page= value; RecreateAll();}}
		public Page.PageFormat FORMAT 			{ get {return _page.FORMAT;}		set{_page.FORMAT = value; ResizePage();}}
		public Page.PageOrientation ORIENTATION	{ get {return _page.ORIENTATION;}	set{_page.ORIENTATION = value; ResizePage();}}
		public int ZOOM							{ get { return (int)(_zoom*100.0f);}set { _zoom = ((float)value) /100.0f; ResizePage();}}
		

		private void ContentChangedSignal() 
		{
			if(ContentChanged != null)
				ContentChanged(this, null);
		}

		private void ResizePage() 
		{
			Graphics g = this.CreateGraphics();
			float mm_pixelx = g.DpiX / 25.4f;			// Ergibt wieviele pixel pro mm
			float mm_pixely = g.DpiY / 25.4f;			// Ergibt wieviele pixel pro mm
			this.Width = (int)(_page.PAGEWIDTH * mm_pixelx * _zoom);
			this.Height = (int) (_page.PAGEHEIGHT * mm_pixely * _zoom);
			foreach(IUCPageElement e in this.Controls) 
			{
				e.ZOOM = this.ZOOM;
			}
		}

		private void RecreateAll()
		{
			if(_page == null)
				return;
			this.Controls.Clear();
			foreach(IPageElement e in _page.ELEMENTS)
			{
				if(e is RadioButtons)
					RecreateRadioButtons(e);
				else
				if(e is FormularLabel)
					RecreateFormularLabel(e);
				else
				if(e is FormularTextBox)
					RecreateFormularTextBox(e);
				else
				if(e is RadioButtonSingle)
					RecreateRadioButtonAlone(e);
				else
					if(e is FormularLine)
					RecreateLine(e);
				else
					if(e is FormularClickableImage)
					RecreateClickableImage(e);
			}
			ContentChangedSignal();
		}


		private void RecreateRadioButtonAlone(IPageElement e)
		{
			ucRadiButtonSingle ucb	= new ucRadiButtonSingle();
			ucb.ContentChanged += new EventHandler(Radiobuttons_ContentChanged);
			ucb.RADIOBUTTONSINGLE = (RadioButtonSingle)e;
			ucb.ZOOM			= this.ZOOM;
			ucb.PAGEMODE		= this.PAGEMODE;
			
			this.Controls.Add(ucb);
		}

		private void RecreateRadioButtons(IPageElement e)
		{
			ucRadioButtons ucb	= new ucRadioButtons();
			ucb.ContentChanged += new EventHandler(Radiobuttons_ContentChanged);
			ucb.RADIOBUTTONS	= (RadioButtons)e;
			ucb.ZOOM			= this.ZOOM;
			ucb.PAGEMODE		= this.PAGEMODE;
			
			this.Controls.Add(ucb);
		}

		private void RecreateFormularLabel(IPageElement e )
		{
			ucLabel lbl			= new ucLabel();
			lbl.FORMULARLABEL	= (FormularLabel)e;
			lbl.ZOOM			= this.ZOOM;
			lbl.PAGEMODE		= this.PAGEMODE;
			this.Controls.Add(lbl);
		}

		private void RecreateFormularTextBox(IPageElement e )
		{
			ucTextBox t			= new ucTextBox();
			t.FORMULARTEXTBOX	= (FormularTextBox)e;
			t.ZOOM				= this.ZOOM;
			t.PAGEMODE			= this.PAGEMODE;
			this.Controls.Add(t);
		}

		private void RecreateClickableImage(IPageElement e )
		{
			ucClickableImage i			= new ucClickableImage();
			i.FORMULARCLICKABLEIMAGE	= (FormularClickableImage)e;
			i.ZOOM						= this.ZOOM;
			i.PAGEMODE					= this.PAGEMODE;
			this.Controls.Add(i);
		}

		private void RecreateLine(IPageElement e )
		{
			ucLine l			= new ucLine();
			l.FORMULARLINE		= (FormularLine)e;
			l.ZOOM				= this.ZOOM;
			l.PAGEMODE			= this.PAGEMODE;
			this.Controls.Add(l);
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
			this.mnuInsert = new System.Windows.Forms.ContextMenu();
			this.mnuInsertRB = new System.Windows.Forms.MenuItem();
			this.mnucbJN = new System.Windows.Forms.MenuItem();
			this.mnucb2 = new System.Windows.Forms.MenuItem();
			this.mnucb3 = new System.Windows.Forms.MenuItem();
			this.mnucb4 = new System.Windows.Forms.MenuItem();
			this.mnucb5 = new System.Windows.Forms.MenuItem();
			this.mnucb6 = new System.Windows.Forms.MenuItem();
			this.mnuInsertRBAlone = new System.Windows.Forms.MenuItem();
			this.mnuInsertLabel = new System.Windows.Forms.MenuItem();
			this.mnuInsetTextbox = new System.Windows.Forms.MenuItem();
			this.mnuInsertLine = new System.Windows.Forms.MenuItem();
			this.mnuInsertImage = new System.Windows.Forms.MenuItem();
			this.mnuDelimiter = new System.Windows.Forms.MenuItem();
			this.mnuDeleteItem = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.mnuEditText = new System.Windows.Forms.MenuItem();
			this.mnuBringToFront = new System.Windows.Forms.MenuItem();
			this.mnuBringToBack = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuInsertSUM = new System.Windows.Forms.MenuItem();
			this.mnuInsertPageNo = new System.Windows.Forms.MenuItem();
			this.mnuInsertDateCreated = new System.Windows.Forms.MenuItem();
			this.mnuInsertDateChanged = new System.Windows.Forms.MenuItem();
			this.mnuInsertUserCreated = new System.Windows.Forms.MenuItem();
            this.mnuInsertKlient = new System.Windows.Forms.MenuItem();
            this.mnuInsertKlientGebDat = new System.Windows.Forms.MenuItem();
            this.mniInsertUserChanged = new System.Windows.Forms.MenuItem();
			this.mnuInsertTimeCreated = new System.Windows.Forms.MenuItem();
			this.mnuInsertTimeChanged = new System.Windows.Forms.MenuItem();
			this.mnuInsertPrintTime = new System.Windows.Forms.MenuItem();
			this.mnuInsertPrintDate = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuSaveElement = new System.Windows.Forms.MenuItem();
			this.mnuLoadElement = new System.Windows.Forms.MenuItem();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.mnuSum1 = new System.Windows.Forms.MenuItem();
			this.mnuSum2 = new System.Windows.Forms.MenuItem();
			this.mnuSum3 = new System.Windows.Forms.MenuItem();
			this.mnuSum4 = new System.Windows.Forms.MenuItem();
			this.mnuSum5 = new System.Windows.Forms.MenuItem();
			this.mnuSum6 = new System.Windows.Forms.MenuItem();
			this.mnuSum7 = new System.Windows.Forms.MenuItem();
			this.mnuSum8 = new System.Windows.Forms.MenuItem();
			this.mnuSum9 = new System.Windows.Forms.MenuItem();
			this.mnuSum10 = new System.Windows.Forms.MenuItem();
			// 
			// mnuInsert
			// 
			this.mnuInsert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuInsertRB,
																					  this.mnuInsertRBAlone,
																					  this.mnuInsertLabel,
																					  this.mnuInsetTextbox,
																					  this.mnuInsertLine,
																					  this.mnuInsertImage,
																					  this.mnuDelimiter,
																					  this.mnuDeleteItem,
																					  this.menuItem10,
																					  this.mnuEditText,
																					  this.mnuBringToFront,
																					  this.mnuBringToBack,
																					  this.menuItem3,
																					  this.menuItem2,
																					  this.mnuSaveElement,
																					  this.mnuLoadElement});
			// 
			// mnuInsertRB
			// 
			this.mnuInsertRB.Index = 0;
			this.mnuInsertRB.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnucbJN,
																						this.mnucb2,
																						this.mnucb3,
																						this.mnucb4,
																						this.mnucb5,
																						this.mnucb6});
			this.mnuInsertRB.Text = "Radiobuttons einfügen";
			// 
			// mnucbJN
			// 
			this.mnucbJN.Index = 0;
			this.mnucbJN.Text = "JA NEIN";
			this.mnucbJN.Click += new System.EventHandler(this.mnucbJN_Click);
			// 
			// mnucb2
			// 
			this.mnucb2.Index = 1;
			this.mnucb2.Text = "2 Elemente";
			this.mnucb2.Click += new System.EventHandler(this.mnucb2_Click);
			// 
			// mnucb3
			// 
			this.mnucb3.Index = 2;
			this.mnucb3.Text = "3 Elemente";
			this.mnucb3.Click += new System.EventHandler(this.mnucb3_Click);
			// 
			// mnucb4
			// 
			this.mnucb4.Index = 3;
			this.mnucb4.Text = "4 Elemente";
			this.mnucb4.Click += new System.EventHandler(this.mnucb4_Click);
			// 
			// mnucb5
			// 
			this.mnucb5.Index = 4;
			this.mnucb5.Text = "5 Elemente";
			this.mnucb5.Click += new System.EventHandler(this.mnucb5_Click);
			// 
			// mnucb6
			// 
			this.mnucb6.Index = 5;
			this.mnucb6.Text = "6 Elemente";
			this.mnucb6.Click += new System.EventHandler(this.mnucb6_Click);
			// 
			// mnuInsertRBAlone
			// 
			this.mnuInsertRBAlone.Index = 1;
			this.mnuInsertRBAlone.Text = "Radiobutton alleinstehend einfügen";
			this.mnuInsertRBAlone.Click += new System.EventHandler(this.mnuInsertRBAlone_Click);
			// 
			// mnuInsertLabel
			// 
			this.mnuInsertLabel.Index = 2;
			this.mnuInsertLabel.Text = "Label einfügen";
			this.mnuInsertLabel.Click += new System.EventHandler(this.mnuInsertLabel_Click);
			// 
			// mnuInsetTextbox
			// 
			this.mnuInsetTextbox.Index = 3;
			this.mnuInsetTextbox.Text = "Textbox einfügen";
			this.mnuInsetTextbox.Click += new System.EventHandler(this.mnuInsetTextbox_Click);
			// 
			// mnuInsertLine
			// 
			this.mnuInsertLine.Index = 4;
			this.mnuInsertLine.Text = "Linie einfügen";
			this.mnuInsertLine.Click += new System.EventHandler(this.mnuInsertLine_Click);
			// 
			// mnuInsertImage
			// 
			this.mnuInsertImage.Index = 5;
			this.mnuInsertImage.Text = "Bild einfügen";
			this.mnuInsertImage.Click += new System.EventHandler(this.mnuInsertImage_Click);
			// 
			// mnuDelimiter
			// 
			this.mnuDelimiter.Index = 6;
			this.mnuDelimiter.Text = "-";
			this.mnuDelimiter.Visible = false;
			// 
			// mnuDeleteItem
			// 
			this.mnuDeleteItem.Index = 7;
			this.mnuDeleteItem.Text = "Element löschen";
			this.mnuDeleteItem.Visible = false;
			this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 8;
			this.menuItem10.Text = "-";
			// 
			// mnuEditText
			// 
			this.mnuEditText.Index = 9;
			this.mnuEditText.Text = "Text bearbeiten";
			this.mnuEditText.Visible = false;
			this.mnuEditText.Click += new System.EventHandler(this.mnuEditText_Click);
			// 
			// mnuBringToFront
			// 
			this.mnuBringToFront.Index = 10;
			this.mnuBringToFront.Text = "In der Vordergrund";
			this.mnuBringToFront.Visible = false;
			this.mnuBringToFront.Click += new System.EventHandler(this.mnuBringToFront_Click);
			// 
			// mnuBringToBack
			// 
			this.mnuBringToBack.Index = 11;
			this.mnuBringToBack.Text = "In der Hintergrund";
			this.mnuBringToBack.Visible = false;
			this.mnuBringToBack.Click += new System.EventHandler(this.mnuBringToBack_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 12;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuInsertSUM,
																					  this.mnuInsertPageNo,
																					  this.mnuInsertDateCreated,
																					  this.mnuInsertDateChanged,
																					  this.mnuInsertUserCreated,
                                                                                      this.mnuInsertKlient,
                                                                                      this.mnuInsertKlientGebDat,
																					  this.mniInsertUserChanged,
																					  this.mnuInsertTimeCreated,
																					  this.mnuInsertTimeChanged,
																					  this.mnuInsertPrintTime,
																					  this.mnuInsertPrintDate});
			this.menuItem3.Text = "Spezielle Felder";
			// 
			// mnuInsertSUM
			// 
			this.mnuInsertSUM.Index = 0;
			this.mnuInsertSUM.Text = "Gesamtsumme Punkte einfügen";
			this.mnuInsertSUM.Click += new System.EventHandler(this.mnuInsertSUM_Click);
			// 
			// mnuInsertPageNo
			// 
			this.mnuInsertPageNo.Index = 1;
			this.mnuInsertPageNo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mnuSum1,
																							this.mnuSum2,
																							this.mnuSum3,
																							this.mnuSum4,
																							this.mnuSum5,
																							this.mnuSum6,
																							this.mnuSum7,
																							this.mnuSum8,
																							this.mnuSum9,
																							this.mnuSum10});
			this.mnuInsertPageNo.Text = "Seitensummen";
			this.mnuInsertPageNo.Click += new System.EventHandler(this.mnuInsertPageNo_Click);
			// 
			// mnuInsertDateCreated
			// 
			this.mnuInsertDateCreated.Index = 2;
			this.mnuInsertDateCreated.Text = "Erstellungsdatum";
			this.mnuInsertDateCreated.Click += new System.EventHandler(this.mnuInsertDateCreated_Click);
			// 
			// mnuInsertDateChanged
			// 
			this.mnuInsertDateChanged.Index = 3;
			this.mnuInsertDateChanged.Text = "Änderungsdatum";
			this.mnuInsertDateChanged.Click += new System.EventHandler(this.mnuInsertDateChanged_Click);
			// 
			// mnuInsertUserCreated
			// 
			this.mnuInsertUserCreated.Index = 4;
			this.mnuInsertUserCreated.Text = "Erstellungsbenutzer";
			this.mnuInsertUserCreated.Click += new System.EventHandler(this.mnuInsertUserCreated_Click);
            // 
            // mnuInsertKient
            // 
            this.mnuInsertKlient.Index = 5;
            this.mnuInsertKlient.Text = "Klient";
            this.mnuInsertKlient.Click += new System.EventHandler(this.mnuInsertKlient_Click);
            // 
            // mnuInsertKientGebDat
            // 
            this.mnuInsertKlientGebDat.Index = 6;
            this.mnuInsertKlientGebDat.Text = "Klient Geb.Dat.";
            this.mnuInsertKlientGebDat.Click += new System.EventHandler(this.mnuInsertKlientGebDat_Click);
            // 
			// mniInsertUserChanged
			// 
			this.mniInsertUserChanged.Index = 7;
			this.mniInsertUserChanged.Text = "Änderungsbenutzer";
			this.mniInsertUserChanged.Click += new System.EventHandler(this.mniInsertUserChanged_Click);
			// 
			// mnuInsertTimeCreated
			// 
			this.mnuInsertTimeCreated.Index = 8;
			this.mnuInsertTimeCreated.Text = "Erstellungszeit";
			this.mnuInsertTimeCreated.Click += new System.EventHandler(this.mnuInsertTimeCreated_Click);
			// 
			// mnuInsertTimeChanged
			// 
			this.mnuInsertTimeChanged.Index = 9;
			this.mnuInsertTimeChanged.Text = "Änderungszeit";
			this.mnuInsertTimeChanged.Click += new System.EventHandler(this.mnuInsertTimeChanged_Click);
			// 
			// mnuInsertPrintTime
			// 
			this.mnuInsertPrintTime.Index = 10;
			this.mnuInsertPrintTime.Text = "Druckzeit";
			this.mnuInsertPrintTime.Click += new System.EventHandler(this.mnuInsertPrintTime_Click);
			// 
			// mnuInsertPrintDate
			// 
			this.mnuInsertPrintDate.Index = 11;
			this.mnuInsertPrintDate.Text = "Druckdatum";
			this.mnuInsertPrintDate.Click += new System.EventHandler(this.mnuInsertPrintDate_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 13;
			this.menuItem2.Text = "-";
			// 
			// mnuSaveElement
			// 
			this.mnuSaveElement.Index = 14;
			this.mnuSaveElement.Text = "Element speichern";
			this.mnuSaveElement.Click += new System.EventHandler(this.mnuSaveElement_Click);
			// 
			// mnuLoadElement
			// 
			this.mnuLoadElement.Index = 15;
			this.mnuLoadElement.Text = "Element laden";
			this.mnuLoadElement.Click += new System.EventHandler(this.mnuLoadElement_Click);
			// 
			// dlgSave
			// 
			this.dlgSave.Filter = "Formularelementdateien|*.S2frmelement";
			// 
			// dlgOpen
			// 
			this.dlgOpen.CheckFileExists = false;
			this.dlgOpen.Filter = "Formularelementdateien|*.S2frmelement";
			// 
			// mnuSum1
			// 
			this.mnuSum1.Index = 0;
			this.mnuSum1.Text = "Seite 1";
			this.mnuSum1.Click += new System.EventHandler(this.mnuSum1_Click);
			// 
			// mnuSum2
			// 
			this.mnuSum2.Index = 1;
			this.mnuSum2.Text = "Seite 2";
			this.mnuSum2.Click += new System.EventHandler(this.mnuSum2_Click);
			// 
			// mnuSum3
			// 
			this.mnuSum3.Index = 2;
			this.mnuSum3.Text = "Seite 3";
			this.mnuSum3.Click += new System.EventHandler(this.mnuSum3_Click);
			// 
			// mnuSum4
			// 
			this.mnuSum4.Index = 3;
			this.mnuSum4.Text = "Seite 4";
			this.mnuSum4.Click += new System.EventHandler(this.mnuSum4_Click);
			// 
			// mnuSum5
			// 
			this.mnuSum5.Index = 4;
			this.mnuSum5.Text = "Seite 5";
			this.mnuSum5.Click += new System.EventHandler(this.mnuSum5_Click);
			// 
			// mnuSum6
			// 
			this.mnuSum6.Index = 5;
			this.mnuSum6.Text = "Seite 6 ";
			this.mnuSum6.Click += new System.EventHandler(this.mnuSum6_Click);
			// 
			// mnuSum7
			// 
			this.mnuSum7.Index = 6;
			this.mnuSum7.Text = "Seite 7";
			this.mnuSum7.Click += new System.EventHandler(this.mnuSum7_Click);
			// 
			// mnuSum8
			// 
			this.mnuSum8.Index = 7;
			this.mnuSum8.Text = "Seite 8";
			this.mnuSum8.Click += new System.EventHandler(this.mnuSum8_Click);
			// 
			// mnuSum9
			// 
			this.mnuSum9.Index = 8;
			this.mnuSum9.Text = "Seite 9";
			this.mnuSum9.Click += new System.EventHandler(this.mnuSum9_Click);
			// 
			// mnuSum10
			// 
			this.mnuSum10.Index = 9;
			this.mnuSum10.Text = "Seite 10";
			this.mnuSum10.Click += new System.EventHandler(this.mnuSum10_Click);
			// 
			// ucPage
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ContextMenu = this.mnuInsert;
			this.Name = "ucPage";
			this.Size = new System.Drawing.Size(552, 256);
			this.Enter += new System.EventHandler(this.ucPage_Enter);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucPage_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucPage_Paint);
			this.MouseEnter += new System.EventHandler(this.ucPage_MouseEnter);
			this.Leave += new System.EventHandler(this.ucPage_Leave);
			this.DoubleClick += new System.EventHandler(this.ucPage_DoubleClick);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucPage_MouseMove);
			this.MouseLeave += new System.EventHandler(this.ucPage_MouseLeave);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucPage_MouseDown);

		}
		#endregion


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Fügt einen Knopf hinzu. Die koordinaten sowie breite und Höhe sind in millimeter
		/// anzugeben
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddRadioButton(RadioButtons buttons, float x, float y, float width, float height, Color cBack, Color cFore) 
		{
			
			_page.AddElement(buttons);

			ucRadioButtons ucb	= new ucRadioButtons();
			ucb.ContentChanged +=new EventHandler(Radiobuttons_ContentChanged);
			buttons.TOP			= y;
			buttons.LEFT		= x;
			buttons.WIDTH		= width;
			buttons.HEIGHT		= height;
			buttons.BACKCOLOR	= cBack;
			buttons.FORECOLOR	= cFore;
			ucb.RADIOBUTTONS	= buttons;
			ucb.PAGEMODE		= _pagemode;
			ucb.ZOOM			= this.ZOOM;				// immer zum schluss aufrufen
			this.Controls.Add(ucb);
			ContentChangedSignal();

		}

		public void AddLabel(string text, float x, float y, float width, float height, Color cBack, Color cFore) 
		{
			FormularLabel l = new FormularLabel();
			l.TOP		= y;
			l.LEFT		= x;
			l.WIDTH		= width;
			l.HEIGHT	= height;
			l.BACKCOLOR	= cBack;
			l.FORECOLOR	= cFore;
			l.TEXT = text;

			_page.AddElement(l);

			ucLabel uclbl = new ucLabel();
			uclbl.FORMULARLABEL = l;
			uclbl.PAGEMODE = _pagemode;
			uclbl.ZOOM = this.ZOOM;
			this.Controls.Add(uclbl);
			ContentChangedSignal();
		}

		public void AddTextBox(float x, float y, float width, float height, Color cBack, Color cFore) 
		{
			FormularTextBox t = new FormularTextBox();
			t.TOP		= y;
			t.LEFT		= x;
			t.WIDTH		= width;
			t.HEIGHT	= height;
			t.BACKCOLOR	= cBack;
			t.FORECOLOR	= cFore;
			

			_page.AddElement(t);

			t.FIELDNAME = string.Format("Textbox{0}", GetElemetCount() + 1);

			ucTextBox uct		= new ucTextBox();
			uct.FORMULARTEXTBOX = t;
			uct.PAGEMODE		= _pagemode;
			uct.ZOOM			= this.ZOOM;
			this.Controls.Add(uct);
			ContentChangedSignal();
		}


		public void AddClickableImage(float x, float y, float width, float height, Color cBack, Color cFore) 
		{
			FormularClickableImage t = new FormularClickableImage();
			t.TOP		= y;
			t.LEFT		= x;
			t.WIDTH		= width;
			t.HEIGHT	= height;
			t.BACKCOLOR	= cBack;
			t.FORECOLOR	= cFore;
			

			_page.AddElement(t);

			t.FIELDNAME = string.Format("Image{0}", GetElemetCount() + 1);

			ucClickableImage uct		= new ucClickableImage();
			uct.FORMULARCLICKABLEIMAGE	= t;
			uct.PAGEMODE				= _pagemode;
			uct.ZOOM					= this.ZOOM;
			this.Controls.Add(uct);
			ContentChangedSignal();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Entfernt das angegebene Element
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RemoveElement(IUCPageElement element)
		{
			this.Controls.Remove((Control)element);
			_page.RemoveElement(element.IPAGEELEMENT);
			this.Focus();
			ContentChangedSignal();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Hintergrund zeichnen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ucPage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//e.Graphics.DrawRectangle(Pens.Red, 0,0,this.Width-1, this.Height-1);
			_page.PrintContent(e.Graphics, _zoom, 0,0);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// OnPaint
		/// </summary>
		//--------------------------------------------------------------------------------
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			Graphics g = e.Graphics;
			g.PageUnit = GraphicsUnit.Pixel;

			if(_selectbox && _pagemode == PageMode.Design)
				g.DrawRectangle(Pens.Blue, 0,0, this.Width-1, this.Height-1);

			Pen p = new Pen(Color.Black);
			p.Width = 1;
			g.DrawLine(p, 0, this.Height-1, this.Width -1, this.Height-1);
			
		}

		#region IUCPageElement Members

		public bool ReadOnly
		{
			get
			{
				return !this.Enabled;
			}
			set
			{
				this.Enabled = !value;
			}
		}

		public PageMode PAGEMODE 
		{
			get 
			{
				return _pagemode;
			}
			set 
			{
				_pagemode = value;
				foreach(IUCPageElement e in this.Controls)
					e.PAGEMODE = value;
				if(_pagemode != PageMode.Design)
					this.ContextMenu = null;
				else
					this.ContextMenu = mnuInsert;
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
			}
		}

		public IPageElement IPAGEELEMENT 
		{
			get 
			{
				if(_page!= null)
					return (IPageElement)_page;
				else
					return null;
			}
		}

		#endregion


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert true wenn das Control im rechten unteren Eck gecklickt wurde
		/// (4 Pixel Quadrat)
		/// </summary>
		//--------------------------------------------------------------------------------
		private bool CornerHit(Control c, int x, int y)
		{
			if(c.Left+c.Width-10 <= x && c.Left+c.Width >= x && c.Top+c.Height-10 <= y && c.Top + c.Height >= y)
				return true;
			else
				return false;
		}
		
		//--------------------------------------------------------------------------------
		/// <summary>
		/// Prüft auf treffer und liefert bei treffer das Control
		/// </summary>
		//--------------------------------------------------------------------------------
		private Control HitTest(int x, int y, ref bool bCornerHit) 
		{
			foreach(Control c in this.Controls)
				if(c.Left <= x && c.Left+c.Width >= x && c.Top <= y && c.Top + c.Height >= y)
				{
					bCornerHit = CornerHit(c, x, y);
					return c;
				}
			return null;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Rahmen entfernen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ResetSelectBoxes() 
		{
			foreach(IUCPageElement e in this.Controls)
				if(e.SELECTBOX)
					e.SELECTBOX = false;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// in den Page elementen ist die Position , höhe und breite in mm verspeichert
		/// bei veränderungen müssen diese Werte neu berechnet werden
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ReCalcPosActualPageElement() 
		{
			if(_actualselectedcontrol == null)
				return;
			IPageElement pe = ((IUCPageElement)_actualselectedcontrol).IPAGEELEMENT;
			
			if(_zoom == 0.0f)			// Dinide by Zero Error verhindern
				return;

			Control c = _actualselectedcontrol;

			using(Graphics g = this.CreateGraphics()) 
			{
				g.PageUnit = GraphicsUnit.Pixel;
				float pixelxmm = 25.4f / g.DpiX;			// Ergibt wieviele mm ein Pixel hat
				float pixelymm = 25.4f / g.DpiY;			// Ergibt wieviele mm ein Pixel hat
				pe.LEFT = ((float)c.Left) * pixelxmm / _zoom;
				pe.TOP	= ((float)c.Top) * pixelymm / _zoom;
				pe.WIDTH = ((float)c.Width) * pixelxmm / _zoom;
				pe.HEIGHT = ((float)c.Height) * pixelymm / _zoom;
			}

		}

		#region Maus Events
		
		private void ucPage_MouseEnter(object sender, System.EventArgs e)
		{
			if(_pagemode != PageMode.Design)
				return;
			SELECTBOX = true;
		}

		private void ucPage_MouseLeave(object sender, System.EventArgs e)
		{
			if(_pagemode != PageMode.Design)
				return;
			SELECTBOX = false;
		}

		private void ucPage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(_pagemode != PageMode.Design)
				return;

			_lastx = e.X;
			_lasty = e.Y;
			_deltax = 0;
			_deltay = 0;

			bool bCorner = false;
			
			_pageeditmode = PageEditMode.None;
			Control c = HitTest(e.X, e.Y, ref bCorner);
			ResetSelectBoxes();
			if(c!=null)
			{
				IUCPageElement el = (IUCPageElement)c;
				el.SELECTBOX = true;
				_actualselectedcontrol = c;
				if(bCorner)
					_pageeditmode = PageEditMode.ObjectSizeing;
				else
					_pageeditmode = PageEditMode.ObjectMoveing;

				_relx = e.X - _actualselectedcontrol.Left;
				_rely = e.Y - _actualselectedcontrol.Top;

				// Menü anpassen
				mnuDelimiter.Visible	= true;
				mnuDeleteItem.Visible	= true;
				mnuBringToBack.Visible	= true;
				mnuBringToFront.Visible	= true;
				if(c is ucLabel || c is ucRadiButtonSingle)
					mnuEditText.Visible		= true;
			}
			else 
			{
				mnuDelimiter.Visible	= false;
				mnuDeleteItem.Visible	= false;
				mnuEditText.Visible		= false;
				mnuBringToBack.Visible	= false;
				mnuBringToFront.Visible	= false;
			}

		}

		private void ucPage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(_pagemode != PageMode.Design)
				return;
			_pageeditmode = PageEditMode.None;
			_deltax = 0;
			_deltay = 0;

		}

		private void ucPage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(_pagemode != PageMode.Design)
				return;

			Control c = _actualselectedcontrol;
			if(c == null)
				return;

			try 
			{
				if(_lastx != e.X) 
				{
					_deltax = e.X - _lastx;
					_lastx = e.X;
				}

				if(_lasty != e.Y) 
				{
					_deltay = e.Y - _lasty;
					_lasty = e.Y;
				}

				if(_deltax == 0 && _deltay == 0)			// fucking Framework....
					return;


				if(_pageeditmode == PageEditMode.ObjectMoveing) 
				{
					c.Left = e.X - _relx;
					c.Top = e.Y - _rely;
					ReCalcPosActualPageElement();
					return;
				}

				if(_pageeditmode == PageEditMode.ObjectSizeing) 
				{
				
					int width = e.X - c.Left;
					int height = e.Y - c.Top ;
					if(width < 1 || height < 1)
						return;

					this.Invalidate(new Rectangle(c.Left, c.Top, c.Width, c.Height), true); // neu zeichnen veranlassen
					c.Width	 = width;
					c.Height = height;
					ReCalcPosActualPageElement();
					return;
				}
			}
			finally 
			{
				_deltax = 0;
				_deltay = 0;
			}
		}

		private void ucPage_Enter(object sender, System.EventArgs e)
		{
		}

		private void ucPage_Leave(object sender, System.EventArgs e)
		{
		}

		#endregion

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Pixel in mm umwandeln
		/// </summary>
		//--------------------------------------------------------------------------------
		private RectangleF ConvertToMM(Rectangle r) 
		{
			using(Graphics g = this.CreateGraphics()) 
			{
				if(_zoom == 0.0f)
					_zoom = 1;
				float mmPixelx = 25.4f / g.DpiX / _zoom;
				float mmPixely = 25.4f / g.DpiY / _zoom;
				RectangleF rf = new RectangleF(((float)r.Left) * mmPixelx, ((float)r.Top) * mmPixely, ((float)r.Width) * mmPixelx, ((float)r.Height) * mmPixely);
				return rf;
			}
		}

		private void EditActualControlText()
		{
			if(_actualselectedcontrol == null)
				return;

			IUCPageElement e = (IUCPageElement)_actualselectedcontrol;
			IPageElement pe = e.IPAGEELEMENT;
			frmEditText frm = new frmEditText();
			frm.TEXT = pe.TEXT;
			DialogResult res = frm.ShowDialog();
			if(res != DialogResult.OK)
				return;

			pe.TEXT = frm.TEXT;
			((Control)e).Refresh();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Anzahl der Elemente
		/// </summary>
		//--------------------------------------------------------------------------------
		private int GetElemetCount() 
		{
			return _page.ELEMENTS.Count;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// enen Rb in bestimmter Anzahl hinzufügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void AddRadioButtonsFromMenu(int iCount) 
		{
			ArrayList al = new ArrayList();
			int iMax = 5*(iCount -1);
			for(int i=0; i< iCount; i++) 
			{
				RadioButtonText t = new RadioButtonText(string.Format("Text {0}", i), (float)iMax );
				al.Add(t);
				iMax-=5;
			}
			RadioButtonText[] at = (RadioButtonText[])al.ToArray(typeof(RadioButtonText));
			RadioButtons rb = new RadioButtons(at);
			rb.FIELDNAME = string.Format("Feld{0}", GetElemetCount() + 1);
			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)200) * _zoom),(int)(((float)70) * _zoom)));
			AddRadioButton(rb, rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// einen JN Radiobutton hinzufügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void AddRadioButtonJN() 
		{
			RadioButtonText[] aText = {new RadioButtonText("Ja", 10), new RadioButtonText("Nein", 5)};
			RadioButtons rb = new RadioButtons(aText);
			rb.FIELDNAME = string.Format("Feld{0}", GetElemetCount() + 1);
			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)200) * _zoom),(int)(((float)70) * _zoom)));
			AddRadioButton(rb, rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// einen alleinstehenden Button einfügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void AddRadioButtonAlone() 
		{

			RadioButtonSingle rbs = new RadioButtonSingle();
			rbs.FIELDNAME = string.Format("Feld{0}", GetElemetCount() + 1);
			_page.AddElement(rbs);

			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)200) * _zoom),(int)(((float)70) * _zoom)));

			ucRadiButtonSingle ucb	= new ucRadiButtonSingle();
			ucb.ContentChanged +=new EventHandler(Radiobuttons_ContentChanged);
			rbs.TOP					= rf.Top;
			rbs.LEFT				= rf.Left;
			rbs.WIDTH				= rf.Width;
			rbs.HEIGHT				= rf.Height;
			rbs.TEXT				= "Text für RB";
			ucb.RADIOBUTTONSINGLE	= rbs;
			ucb.PAGEMODE			= _pagemode;
			ucb.ZOOM				= this.ZOOM;				// immer zum schluss aufrufen
		
			this.Controls.Add(ucb);
			ContentChangedSignal();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// einen alleinstehenden Button einfügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void AddLine() 
		{

			FormularLine	l = new FormularLine();
			_page.AddElement(l);

			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)200) * _zoom),(int)(((float)10) * _zoom)));

			ucLine ucl = new ucLine();
			l.TOP				= rf.Top;
			l.LEFT				= rf.Left;
			l.WIDTH				= rf.Width;
			l.HEIGHT			= rf.Height;
			ucl.FORMULARLINE	= l;
			ucl.PAGEMODE		= _pagemode;
			ucl.ZOOM			= this.ZOOM;				// immer zum schluss aufrufen
		
			this.Controls.Add(ucl);
			ContentChangedSignal();
		}

		private bool LoadElement() 
		{
			dlgOpen.InitialDirectory = ".\\";
			DialogResult res =  dlgOpen.ShowDialog();
			
			if(res != DialogResult.OK)
				return false;

			string sFile = dlgOpen.FileName;
			string sFileOnly = Path.GetFileNameWithoutExtension(sFile);

			XmlDocument d = new XmlDocument();
			d.Load(sFile);

			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, 10,10));
			XmlNodeList elements  = d.GetElementsByTagName("FORMULARELEMENT");
			foreach(XmlNode n in elements)
				this.PAGE.LoadElement(n, rf.Left,rf.Top);
			RecreateAll();
			ContentChangedSignal();
			return true;
		}

		private bool SaveElement() 
		{
			if(_actualselectedcontrol == null)
				return false;

			dlgSave.InitialDirectory = ".\\";
			DialogResult res =  dlgSave.ShowDialog();
			
			if(res != DialogResult.OK)
				return false;

			string sFile = dlgSave.FileName;
			string sFileOnly = Path.GetFileNameWithoutExtension(sFile);
			
			XmlTextWriter w = new XmlTextWriter(sFile, Encoding.UTF8);
			w.Formatting = Formatting.Indented;
			IUCPageElement uce = (IUCPageElement)_actualselectedcontrol;
			w.WriteStartDocument();
			w.WriteStartElement("FORMULARELEMENT");
			w.WriteAttributeString("NAME", "Element");
			uce.IPAGEELEMENT.SaveElement(w);
			w.WriteEndElement();
			w.WriteEndDocument();
			w.Close();
			return true;
		}

		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Die Labels zur Designtime aktualisieren
		/// </summary>
		//--------------------------------------------------------------------------------
		public void RefreshLabels(FormularGenENV env) 
		{
			foreach(Control c in this.Controls) 
				if(c is ucLabel) 
				{
					((ucLabel)c).ENV = env;
					c.Refresh();
				}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Element löschen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void mnuDeleteItem_Click(object sender, System.EventArgs e)
		{
			if(_actualselectedcontrol == null)
				return;

			RemoveElement((IUCPageElement)_actualselectedcontrol);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Einen Label einfügen
		/// </summary>
		//--------------------------------------------------------------------------------
		private void mnuInsertLabel_Click(object sender, System.EventArgs e)
		{
			RectangleF rf = GetNewLabelRect();
			AddLabel("Testlabel in gewünschter Größe", rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private RectangleF GetNewLabelRect() 
		{
			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)300) * _zoom),(int)(((float)40) * _zoom)));
			return rf;
		}

		private RectangleF GetNewRBAlone() 
		{
			RectangleF rf = ConvertToMM(new Rectangle(_lastx, _lasty, (int)(((float)40) * _zoom),(int)(((float)10) * _zoom)));
			return rf;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Objekteigenschaften bearbeiten
		/// </summary>
		//--------------------------------------------------------------------------------
		private void ucPage_DoubleClick(object sender, System.EventArgs e)
		{
			if(_actualselectedcontrol == null || PAGEMODE != PageMode.Design)
				return;

			if(_actualselectedcontrol is ucRadioButtons)
			{
				ucRadioButtons b = (ucRadioButtons)_actualselectedcontrol;
				RadioButtons bs = b.RADIOBUTTONS;
				frmPropertys frm = new frmPropertys(bs);
				frm.ShowDialog();
				b.RecreateControls();
				b.Refresh();
			}

			if(_actualselectedcontrol is ucLabel)
			{
				ucLabel l = (ucLabel)_actualselectedcontrol;
				FormularLabel fl = l.FORMULARLABEL;
				frmPropertys frm = new frmPropertys(fl);
				frm.ShowDialog();
				l.Refresh();
			}

			if(_actualselectedcontrol is ucTextBox)
			{
				ucTextBox t = (ucTextBox)_actualselectedcontrol;
				FormularTextBox tb = t.FORMULARTEXTBOX;
				frmPropertys frm = new frmPropertys(tb);
				frm.ShowDialog();
				t.Refresh();
			}

			if(_actualselectedcontrol is ucRadiButtonSingle)
			{
				ucRadiButtonSingle b = (ucRadiButtonSingle)_actualselectedcontrol;
				RadioButtonSingle rb = b.RADIOBUTTONSINGLE;
				frmPropertys frm = new frmPropertys(rb);
				frm.ShowDialog();
				b.Refresh();
			}

			if(_actualselectedcontrol is ucLine)
			{
				ucLine l = (ucLine)_actualselectedcontrol;
				FormularLine fl = l.FORMULARLINE;
				frmPropertys frm = new frmPropertys(fl);
				frm.ShowDialog();
				l.Refresh();
			}

			if(_actualselectedcontrol is ucClickableImage)
			{
				ucClickableImage l = (ucClickableImage)_actualselectedcontrol;
				FormularClickableImage fl = l.FORMULARCLICKABLEIMAGE;
				frmPropertys frm = new frmPropertys(fl);
				frm.ShowDialog();
				l.Refresh();
			}

			ContentChangedSignal();
		}

		private void mnuInsertSUM_Click(object sender, System.EventArgs e)
		{
			RectangleF rf = GetNewLabelRect();
			AddLabel("#SUM#", rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private void mnuInsertPageNo_Click(object sender, System.EventArgs e)
		{
			RectangleF rf = GetNewLabelRect();
			AddLabel("#PAGENO#", rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private void mnuInsetTextbox_Click(object sender, System.EventArgs e)
		{
			RectangleF rf = GetNewLabelRect();
			AddTextBox(rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private void Radiobuttons_ContentChanged(object sender, EventArgs e)
		{
			ContentChangedSignal();
		}

		private void mnucbJN_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonJN();
		}

		private void mnucb2_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonsFromMenu(2);
		}

		private void mnucb3_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonsFromMenu(3);
		}

		private void mnucb4_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonsFromMenu(4);
		}

		private void mnucb5_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonsFromMenu(5);
		}

		private void mnucb6_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonsFromMenu(6);
		}

		private void mnuEditText_Click(object sender, System.EventArgs e)
		{
			EditActualControlText();
		}

		private void mnuInsertRBAlone_Click(object sender, System.EventArgs e)
		{
			AddRadioButtonAlone();
		}

		private void mnuInsertLine_Click(object sender, System.EventArgs e)
		{
			AddLine();
		}

		private void mnuBringToFront_Click(object sender, System.EventArgs e)
		{
			if(_actualselectedcontrol == null)
				return;
			_actualselectedcontrol.BringToFront();

		}

		private void mnuBringToBack_Click(object sender, System.EventArgs e)
		{
			if(_actualselectedcontrol == null)
				return;
			_actualselectedcontrol.SendToBack();
		}

		private void mnuSaveElement_Click(object sender, System.EventArgs e)
		{
			SaveElement();
		}

		private void mnuLoadElement_Click(object sender, System.EventArgs e)
		{
			LoadElement();
		}

		private void AddLabel(string sLabel) 
		{
			RectangleF rf = GetNewLabelRect();
			AddLabel(sLabel, rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private void mnuInsertDateCreated_Click(object sender, System.EventArgs e)
		{
			AddLabel("#DATECREATED#");
		}


		private void mnuInsertDateChanged_Click(object sender, System.EventArgs e)
		{
			AddLabel("#DATECHANGED#");
		}

		private void mnuInsertUserCreated_Click(object sender, System.EventArgs e)
		{
			AddLabel("#USERCREATED#");
		}

        private void mnuInsertKlient_Click(object sender, System.EventArgs e)
        {
            AddLabel("#KLIENT#");
        }

        private void mnuInsertKlientGebDat_Click(object sender, System.EventArgs e)
        {
            AddLabel("#KLIENTGEBDAT#");
        }

        private void mniInsertUserChanged_Click(object sender, System.EventArgs e)
		{
			AddLabel("#USERCHANGED#");
		}

		private void mnuInsertTimeCreated_Click(object sender, System.EventArgs e)
		{
			AddLabel("#TIMECREATED#");
		}

		private void mnuInsertTimeChanged_Click(object sender, System.EventArgs e)
		{
			AddLabel("#TIMECHANGED#");
		}

		private void mnuInsertPrintTime_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PRINTTIME#");
		}

		private void mnuInsertPrintDate_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PRINTDATE#");
		}

		private void mnuInsertImage_Click(object sender, System.EventArgs e)
		{
			RectangleF rf = GetNewLabelRect();
			AddClickableImage( rf.Left,rf.Top,rf.Width,rf.Height, Color.White, Color.Black);
		}

		private void mnuSum1_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM1#");
		}

		private void mnuSum2_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM2#");
		}

		private void mnuSum3_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM3#");
		}

		private void mnuSum4_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM4#");
		}

		private void mnuSum5_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM5#");
		}

		private void mnuSum6_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM6#");
		}

		private void mnuSum7_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM7#");
		}	

		private void mnuSum8_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM8#");
		}

		private void mnuSum9_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM9#");
		}

		private void mnuSum10_Click(object sender, System.EventArgs e)
		{
			AddLabel("#PAGESUM10#");
		}
	}
	
	public enum PageEditMode
	{
		None,
		ObjectMoveing,
		ObjectSizeing
	}
}
