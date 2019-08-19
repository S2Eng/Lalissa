//----------------------------------------------------------------------------------------------
//	ucKatalog.cs
//  Verwaltung eines Kataloges
//  Erstellt am:	15.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Pflegeplan;



namespace PMDS.GUI
{


	public class ucKatalogTabelle : QS2.Desktop.ControlManagment.BaseControl
	{
		private Katalog					_Katalog;
		public event EventHandler		SelectionChanged;					// Wird ausgelöst wenn sich die Auswahl im Katalog verändert hat
		public event EventHandler		DoubleClickOnGrid;					// Wird ausgelöst wenn ein Doppelklick ausgeführt wird
		public event EventHandler		ValueChanged;						// Wird ausgelöst wenn sich im Datagrid was ändert inkl. hinzufügen, entfernen
		public event CancelEventHandler BeforeRowDeactivate;				// Wird ausgelöst bovor sich eine Zeile ändert
		public event EventHandler       LastRowdeleted;
		private bool					Changes = false;
		public event EventHandler       ucKatalogTabelleSaved;
		public event EventHandler		ucKatalogTabelleUndo;
		private bool					_preventRowDeleteEffect = false;

        private dsEintrag dsEintrag1;
		private QS2.Desktop.ControlManagment.BasePanel pnlFilter;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpFilterkriterien;
		private QS2.Desktop.ControlManagment.BaseButton btnClearMask;
		private QS2.Desktop.ControlManagment.BaseLabel lblSicht;
		private QS2.Desktop.ControlManagment.BaseLabel lblHinweis;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbASZM;
		private PMDS.GUI.ucButton btnSearch;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
		private System.ComponentModel.IContainer components;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbWarnhinweis;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbSicht;
		private QS2.Desktop.ControlManagment.BaseGrid dgKatalog;
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucKatalogTabelle()
		{
			InitializeComponent();
			
			if(!DesignMode && ENV.AppRunning) 
			{
				UltraGridTools.SetAppearanceAndDisplayStyle(dgKatalog);				// Keyaction und aussehen setzen
				ValueListsCollection vlc = dgKatalog.DisplayLayout.ValueLists;
				ValueList vl = vlc.Add("SICHT");
				vl.ValueListItems.Add(ENV.String("CBPatient"));
				vl.ValueListItems.Add(ENV.String("CBPfleger"));
                vl.ValueListItems.Add(ENV.String("CBArzt"));
				vl.ValueListItems.Add("");
				UltraGridColumn c = dgKatalog.DisplayLayout.Bands[0].Columns["Sicht"];
				c.ValueList = vl;
				c.Style		= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
				
				
				// Die entfernten Filtern
				dgKatalog.DisplayLayout.Bands[0].ColumnFilters["EntferntJN"].FilterConditions.Add(FilterComparisionOperator.Equals, 0);


				cbSicht.Items.Add(ENV.String("CBPatient"));
				cbSicht.Items.Add(ENV.String("CBPfleger"));
                cbSicht.Items.Add(ENV.String("CBArzt"));

                UltraGridTools.AddLinkDokumentValueList(dgKatalog, "IDLinkDokument");
                UltraGridTools.AddEintragFlagValueList(dgKatalog, "flag");
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Support Themes
		/// </summary>
		//----------------------------------------------------------------------------
		public bool SUPPORT_THEMES 
		{
			get 
			{
				if (dgKatalog.UseOsThemes == DefaultableBoolean.False)
					return false;
				else
					return true;
			}
			set 
			{
				if (value)
					dgKatalog.UseOsThemes = DefaultableBoolean.True;
				else
					dgKatalog.UseOsThemes = DefaultableBoolean.False;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Anzahl der ausgewählten Elemente
		/// </summary>
		//----------------------------------------------------------------------------
		public int SELECTED_COUNT 
		{
			get 
			{		
				return dgKatalog.Selected.Rows.Count;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert eine Sammlung der ausgweählten Zeilen
		/// </summary>
		//----------------------------------------------------------------------------
		public SelectedRowsCollection SELECTED_ROWS 
		{
			get 
			{	
				int z = SELECTED_COUNT;
				return dgKatalog.Selected.Rows;
			}

			set
			{	
				if(value == null)
					foreach(UltraGridRow rr in dgKatalog.Rows.All)
					{
						rr.Selected = false;						
					}
			}
		}

		public int VISIBLEROWCOUNT
		{
			get 
			{	
				return dgKatalog.Rows.VisibleRowCount;
			}
		}



		//----------------------------------------------------------------------------
		/// <summary>
		/// Der Datatable für den Katalog
		/// </summary>
		//----------------------------------------------------------------------------
		public Katalog KATALOG 
		{
			get 
			{
				return _Katalog;
			}
			set 
			{
				if(value == null)
					return;
				_Katalog				= value;
				dgKatalog.DataSource	= dsEintrag1.Eintrag;
				TEXT					= _Katalog.KatalogTitel;
                ShowHideFields();
							
			}
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Spalten anzeigen/verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideFields()
        {
            bool bA = _Katalog.GROUP == 'A';
            UltraGridTools.EnableColumn(dgKatalog, "flag", bA);
        }


		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die aktuelle ID der markierten Datenzeile
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid CURRENT_ID 
		{
			get
			{
				if(dgKatalog.ActiveRow == null)
					return Guid.Empty;
				else
					return (Guid)dgKatalog.ActiveRow.Cells["ID"].Value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert den aktuellen Text der markierten Datenzeile
		/// </summary>
		//----------------------------------------------------------------------------
		public string CURRENT_TEXT
		{
			get
			{
				if(dgKatalog.ActiveRow == null)
					return "";
				else
					return (string)dgKatalog.ActiveRow.Cells["TEXT"].Value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert den aktuellen Text der markierten Datenzeile
		/// </summary>
		//----------------------------------------------------------------------------
		public string CURRENT_SICHT
		{
			get
			{
				if(dgKatalog.ActiveRow == null)
					return "";
				else
					return (string)dgKatalog.ActiveRow.Cells["SICHT"].Value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert den aktuellen Text der markierten Datenzeile
		/// </summary>
		//----------------------------------------------------------------------------
		public string CURRENT_WARNHINWEIS
		{
			get
			{
				if(dgKatalog.ActiveRow == null)
					return "";
				else
					return (string)dgKatalog.ActiveRow.Cells["WARNHINWEIS"].Value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest oder setzt die aktuelle Caption Farbe
		/// </summary>
		//----------------------------------------------------------------------------
		public Color HEADER_BACK_COLOR 
		{
			get 
			{
				return dgKatalog.DisplayLayout.CaptionAppearance.BackColor;
			}
			set  
			{
				dgKatalog.DisplayLayout.CaptionAppearance.BackColor = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt die Textbreite
		/// </summary>
		//----------------------------------------------------------------------------
		public int TEXT_COLUMN_WIDTH
		{
			get
			{
				return dgKatalog.DisplayLayout.Bands[0].Columns["Text"].Width;
			}
			set 
			{
				dgKatalog.DisplayLayout.Bands[0].Columns["Text"].Width = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Speichert die Änderungen
		/// liefert false wenn ein Fehler aufgetreten ist
		/// </summary>
		//----------------------------------------------------------------------------
		public bool Save() 
		{
			bool bError = false;

			foreach(UltraGridRow r in dgKatalog.Rows)						// Alle Fehlerhaften markieren
			{
				if( (r.Cells["Text"].Value == System.Convert.DBNull))//((string)r.Cells["Text"].Value).Trim().Length == 0
				{
					bError = true;
					r.Cells["Text"].Appearance.BackColor = ENVCOLOR.ERROR_BACK_COLOR;
					r.Cells["Text"].Appearance.ForeColor = ENVCOLOR.ERROR_FORE_COLOR;
				}
				else 
				{
					r.Cells["Text"].Appearance.BackColor = Color.White;
					r.Cells["Text"].Appearance.ForeColor = Color.Black;
				}
			}

			if(bError) 
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_NO_TEXT"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
				CellUpdated();				// Signal nach außen das was schief gegangen ist
				return false;
			}
			else 
			{
				_Katalog.writeQuery((dsEintrag.EintragDataTable)dgKatalog.DataSource);	
				Changes = false;
				if (LastRowdeleted != null) 
					LastRowdeleted(this,null);
				return true;
			}

			
		
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Editable Grid EIN / AUS
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ENABLED 
		{
			set 
			{
				UltraGridTools.EnableColumns(dgKatalog, value);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest den aktuellen Stand wieder ein
		/// </summary>
		//----------------------------------------------------------------------------
		public void Undo() 
		{
			Changes = false;
			ProcessSearch();

		}
		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Caption Text des Datengrids
		/// </summary>
		//----------------------------------------------------------------------------
		public string TEXT 
		{
			set 
			{
				dgKatalog.Text = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zum ende scrollen
		/// </summary>
		//----------------------------------------------------------------------------
		public void ScrollToEnd() 
		{
			dgKatalog.ActiveRowScrollRegion.Scroll(RowScrollAction.Bottom);		// ans ende mit mir
		}
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Löscht den aktuell markierten Eintrag (Markiert EntferntJN)
		/// </summary>
		//----------------------------------------------------------------------------
		public void DeleteCurrent() 
		{
			if(dgKatalog.Rows.VisibleRowCount >0)
			{	string art;
				if(_Katalog.GROUP.ToString() =="Z" || _Katalog.GROUP.ToString()=="S")
				 art = ENV.String("DAS");
				else art = ENV.String("DIE");
				string ASZM = art+ " "+ENV.String(_Katalog.GROUP.ToString()+"Single");
				if(QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEASZM", ASZM, dgKatalog.ActiveRow.Cells["Text"].Value.ToString()), ENV.String("DIALOGTITLE_DELETEASZM", ENV.String(_Katalog.GROUP.ToString()+"Single")), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true) != DialogResult.Yes)
				{ 
					return;
				}

				// Statt entfernen nur markieren UltraGridTools.DeleteCurrentSelectedRow(dgKatalog);
				UltraGridRow r = dgKatalog.ActiveRow;
				if((r == null) || (r.ListObject == null))
					return;

				Guid g;

				foreach(dsEintrag.EintragRow rr in _Katalog.EINTRAEGE.Rows)
				{
					g = (Guid)rr.ID;
					if((g.Equals((Guid)dgKatalog.ActiveRow.Cells["ID"].Value))   )

					{					
						_Katalog.EINTRAEGE.FindByID(g).EntferntJN = true;
						_Katalog.Write();
						ProcessSearch();
						if(dgKatalog.Rows.VisibleRowCount ==0) //wenn gerade die letzte Reihe gelöscht wurde
							if (LastRowdeleted != null) LastRowdeleted(this,null);
						return;					
					}
				}
			} 
		}

		//----------------------------------------------------------------------------
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Eintrag", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EintragGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EntferntJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Sicht");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Warnhinweis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("flag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLinkDokument");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BedarfsMedikationJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OhneZeitBezug");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKatalogTabelle));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            this.dgKatalog = new QS2.Desktop.ControlManagment.BaseGrid();
            this.pnlFilter = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpFilterkriterien = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.cbSicht = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.btnClearMask = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblSicht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbWarnhinweis = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblHinweis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbASZM = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKatalog)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.grpFilterkriterien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnhinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbASZM)).BeginInit();
            this.SuspendLayout();
            // 
            // dsEintrag1
            // 
            this.dsEintrag1.DataSetName = "dsEintrag";
            this.dsEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgKatalog
            // 
            this.dgKatalog.AutoWork = true;
            this.dgKatalog.DataSource = this.dsEintrag1.Eintrag;
            this.dgKatalog.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgKatalog.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "G";
            ultraGridColumn2.Header.VisiblePosition = 4;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(138, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.MaxLength = 20;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 153;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.MaxLength = 255;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(214, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 184;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "ASRZM";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.MaxLength = 255;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(443, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Width = 300;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Typ";
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Dokument";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.ColSpan = ((short)(0));
            ultraGridColumn11.DataType = typeof(bool);
            ultraGridColumn11.DefaultCellValue = false;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(49, 0);
            ultraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgKatalog.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgKatalog.DisplayLayout.GroupByBox.Prompt = "Schieben Sie hier eine Spalte hinein welche Sie gruppieren möchten";
            this.dgKatalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.dgKatalog.DisplayLayout.Override.NullText = "";
            this.dgKatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKatalog.Location = new System.Drawing.Point(5, 93);
            this.dgKatalog.Name = "dgKatalog";
            this.dgKatalog.Size = new System.Drawing.Size(830, 382);
            this.dgKatalog.TabIndex = 0;
            this.dgKatalog.Text = "** Katalog **";
            this.dgKatalog.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgKatalog_AfterCellUpdate);
            this.dgKatalog.AfterRowsDeleted += new System.EventHandler(this.dgKatalog_AfterRowsDeleted);
            this.dgKatalog.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgKatalog_CellChange);
            this.dgKatalog.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.dgKatalog_BeforeRowDeactivate);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilterkriterien);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(5, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(830, 88);
            this.pnlFilter.TabIndex = 5;
            // 
            // grpFilterkriterien
            // 
            this.grpFilterkriterien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilterkriterien.Controls.Add(this.cbSicht);
            this.grpFilterkriterien.Controls.Add(this.btnClearMask);
            this.grpFilterkriterien.Controls.Add(this.lblSicht);
            this.grpFilterkriterien.Controls.Add(this.tbWarnhinweis);
            this.grpFilterkriterien.Controls.Add(this.lblHinweis);
            this.grpFilterkriterien.Controls.Add(this.tbASZM);
            this.grpFilterkriterien.Controls.Add(this.btnSearch);
            this.grpFilterkriterien.Controls.Add(this.lblBezeichnung);
            this.grpFilterkriterien.Location = new System.Drawing.Point(0, 0);
            this.grpFilterkriterien.Name = "grpFilterkriterien";
            this.grpFilterkriterien.Size = new System.Drawing.Size(830, 88);
            this.grpFilterkriterien.TabIndex = 0;
            this.grpFilterkriterien.TabStop = false;
            this.grpFilterkriterien.Text = "Filterkriterien - geben Sie ein wonach Sie suchen möchten und drücken Sie auf \"Su" +
    "chen\" (Alt + U)";
            // 
            // cbSicht
            // 
            this.cbSicht.Location = new System.Drawing.Point(101, 50);
            this.cbSicht.Name = "cbSicht";
            this.cbSicht.Size = new System.Drawing.Size(168, 21);
            this.cbSicht.TabIndex = 13;
            // 
            // btnClearMask
            // 
            this.btnClearMask.AutoWorkLayout = false;
            this.btnClearMask.IsStandardControl = false;
            this.btnClearMask.Location = new System.Drawing.Point(549, 48);
            this.btnClearMask.Name = "btnClearMask";
            this.btnClearMask.Size = new System.Drawing.Size(120, 24);
            this.btnClearMask.TabIndex = 5;
            this.btnClearMask.Text = "Suchmaske &löschen";
            this.btnClearMask.Click += new System.EventHandler(this.btnClearMask_Click);
            // 
            // lblSicht
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblSicht.Appearance = appearance1;
            this.lblSicht.Location = new System.Drawing.Point(6, 48);
            this.lblSicht.Name = "lblSicht";
            this.lblSicht.Size = new System.Drawing.Size(87, 21);
            this.lblSicht.TabIndex = 7;
            this.lblSicht.Text = "Sicht";
            // 
            // tbWarnhinweis
            // 
            this.tbWarnhinweis.Location = new System.Drawing.Point(357, 24);
            this.tbWarnhinweis.MaxLength = 50;
            this.tbWarnhinweis.Name = "tbWarnhinweis";
            this.tbWarnhinweis.Size = new System.Drawing.Size(168, 21);
            this.tbWarnhinweis.TabIndex = 1;
            // 
            // lblHinweis
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblHinweis.Appearance = appearance2;
            this.lblHinweis.Location = new System.Drawing.Point(277, 24);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(72, 21);
            this.lblHinweis.TabIndex = 8;
            this.lblHinweis.Text = "Hinweis";
            // 
            // tbASZM
            // 
            this.tbASZM.Location = new System.Drawing.Point(101, 24);
            this.tbASZM.MaxLength = 50;
            this.tbASZM.Name = "tbASZM";
            this.tbASZM.Size = new System.Drawing.Size(168, 21);
            this.tbASZM.TabIndex = 0;
            // 
            // btnSearch
            // 
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance3;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(549, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Speichern";
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBezeichnung
            // 
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance4;
            this.lblBezeichnung.Location = new System.Drawing.Point(6, 24);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(87, 21);
            this.lblBezeichnung.TabIndex = 6;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // ucKatalogTabelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dgKatalog);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ucKatalogTabelle";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(840, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKatalog)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.grpFilterkriterien.ResumeLayout(false);
            this.grpFilterkriterien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnhinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbASZM)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Doppelklick am Datagrid
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgKatalog_DoubleClick(object sender, System.EventArgs e)
		{
			if(DoubleClickOnGrid != null)
				DoubleClickOnGrid(sender, e);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgKatalog_AfterRowActivate(object sender, System.EventArgs e)
		{
			if(SelectionChanged != null)
				SelectionChanged(this, null);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Signalisiert das sich was geändert hat
		/// </summary>
		//----------------------------------------------------------------------------
		private void CellUpdated() 
		{
			if(ValueChanged != null)
				ValueChanged(this, null);

			Changes = true;
		}

		private void dgKatalog_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
		}

		private void dgKatalog_AfterRowsDeleted(object sender, System.EventArgs e)
		{
			if(_preventRowDeleteEffect == false)
			CellUpdated();
		}

		private void dgKatalog_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
		}

		private void dgKatalog_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(BeforeRowDeactivate != null)			
				BeforeRowDeactivate(sender, e);
		}



		//----------------------------------------------------------------------------
		/// <summary>
		/// Startet Suchabfrage
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			if(Changes == true)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);    
                if (res == DialogResult.Yes)
				{	
					if(ucKatalogTabelleSaved != null)
						ucKatalogTabelleSaved(this,null);					
				}
					
				if(res == DialogResult.No)
				{
					if(ucKatalogTabelleUndo != null)
						ucKatalogTabelleUndo(this,null);
				}
							

				if(res == DialogResult.Cancel)
					return;
			}

			ProcessSearch();
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// leitet Suchanfrage weiter ans Buisnessobject
		/// </summary>
		//----------------------------------------------------------------------------
		private void ProcessSearch()
        {
			string t;

			if(cbSicht.SelectedItem == null)  t = "";			
			else t = cbSicht.Text.Trim();

			DataTable dt = _Katalog.ReadQuery(tbASZM.Text.Trim(),t, tbWarnhinweis.Text.Trim());
			dgKatalog.DataSource = dt;
			if(dgKatalog.Rows.VisibleRowCount >0)
			{
				dgKatalog.ActiveRow = dgKatalog.Rows[0];
				dgKatalog.PerformAction(UltraGridAction.FirstRowInBand);
			}
			
			if (LastRowdeleted != null) 
				LastRowdeleted(this,null);
			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Speichern verarbeiten
		/// </summary>
		//----------------------------------------------------------------------------
		private bool ProcessSave() 
		{
	
			_Katalog.writeQuery((dsEintrag.EintragDataTable)dgKatalog.DataSource);
			Changes = false;
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Suchmaske leeren
		/// </summary>
		//----------------------------------------------------------------------------	
		private void btnClearMask_Click(object sender, System.EventArgs e)
		{
			if(Changes == true)
			{
				DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
                                                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);  
                if (res == DialogResult.Yes)
				{	
					if(ucKatalogTabelleSaved != null)
						ucKatalogTabelleSaved(this,null);					
				}
					
				if(res == DialogResult.No)
				{
					if(ucKatalogTabelleUndo != null)
						ucKatalogTabelleUndo(this,null);
				}
							

				if(res == DialogResult.Cancel)
					return;
			}

			

			tbASZM.Text = "";
			cbSicht.SelectedItem = null;
			tbWarnhinweis.Text = "";
			dgKatalog.DataSource = dsEintrag1.Eintrag;

			
			if (LastRowdeleted != null) // alle Reihen weg --> ITEM "Löschen" in uc KatalogEdit muß invisible gesetzte werden,( sonst visible)
				LastRowdeleted(this,null);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// setzt den EingabeFocus auf die Textbox
		/// </summary>
		//----------------------------------------------------------------------------
		public void FocusOnASZMtb()
		{
			tbASZM.Clear();
			tbASZM.Focus();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///Löscht alle GridRows, damit beim Umstieg auf Einzelansicht die ASZMCombo richtig funktioniert
		/// </summary>
		//----------------------------------------------------------------------------
		public void ClearGrid()
		{
			_preventRowDeleteEffect = true;
			dgKatalog.DataSource = dsEintrag1.Eintrag;		
			_preventRowDeleteEffect = false;
		}

		
	}
}
