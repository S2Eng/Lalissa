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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Pflegeplan;



namespace PMDS.GUI
{



	public class ucKatalog : QS2.Desktop.ControlManagment.BaseControl
	{
		private Katalog					_Katalog;
		public event EventHandler		SelectionChanged;					// Wird ausgelöst wenn sich die Auswahl im Katalog verändert hat
		public event EventHandler		DoubleClickOnGrid;					// Wird ausgelöst wenn ein Doppelklick ausgeführt wird
		public event EventHandler		MouseUpOnGridRight;					// Wird ausgelöst wenn ein MouseUp ausgeführt wird
		public event EventHandler		ValueChanged;						// Wird ausgelöst wenn sich im Datagrid was ändert inkl. hinzufügen, entfernen
		public event CancelEventHandler BeforeRowDeactivate;				// Wird ausgelöst bovor sich eine Zeile ändert
		public event EventHandler       Editorempty;

        private dsEintrag dsEintrag1;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbSearch;
		private QS2.Desktop.ControlManagment.BaseLabel lblSuche;
        private IContainer components;
        private QS2.Desktop.ControlManagment.BaseGrid dgKatalog;
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucKatalog()
		{
			InitializeComponent();
			//ultraLabel1.DataBindings[
			if(!DesignMode) 
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
				//if(!dgKatalog.ActiveRow.IsFilteredOut ||dgKatalog.ActiveRow.Hidden == false)
				 return dgKatalog.Rows.VisibleRowCount;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt den Filter für den Text
		/// </summary>
		//----------------------------------------------------------------------------
		public string TEXTFILTER 
		{
			set 
			{
				if(value == null || value.Length == 0 )
				{
					dgKatalog.DisplayLayout.Bands[0].ColumnFilters["Text"].FilterConditions.Clear();
					tbSearch.Clear();
				}

				else if(tbSearch.Text.StartsWith("%%%"))
					dgKatalog.DisplayLayout.Bands[0].ColumnFilters["Text"].FilterConditions.Clear();
				
				else 
				{
					string s = value + "*";
					if(dgKatalog.DisplayLayout.Bands[0].ColumnFilters["Text"].FilterConditions.Count == 0)
						dgKatalog.DisplayLayout.Bands[0].ColumnFilters["Text"].FilterConditions.Add(FilterComparisionOperator.Like, s);
					else
						dgKatalog.DisplayLayout.Bands[0].ColumnFilters["Text"].FilterConditions[0].CompareValue = s;
				}
				dgKatalog.Refresh();
				if(dgKatalog.Rows.Count > 0)
					dgKatalog.ActiveRowScrollRegion.FirstRow = dgKatalog.Rows[0];
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zeigt oder versteckt die Group by Box
		/// </summary>
		//----------------------------------------------------------------------------
		public bool SHOW_GROUP_BOX 
		{
			get 
			{
				if(dgKatalog.DisplayLayout.ViewStyleBand == ViewStyleBand.OutlookGroupBy)
					return true;
				else
					return false;
			}
			set 
			{
				if(value == true)
					dgKatalog.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
				else
					dgKatalog.DisplayLayout.ResetViewStyle();

			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Support Themes
		/// </summary>
		//----------------------------------------------------------------------------
		public bool SHOW_GROUP
		{
			get 
			{
				return !dgKatalog.DisplayLayout.Bands[0].Columns["EintragGruppe"].Hidden;
			}
			set 
			{
				dgKatalog.DisplayLayout.Bands[0].Columns["EintragGruppe"].Hidden = !value;
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
				dgKatalog.DataSource	= _Katalog.EINTRAEGE;
				TEXT					= _Katalog.KatalogTitel;
				
				foreach (UltraGridRow r in dgKatalog.Rows)
					r.Hidden = true;
				
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Signalisiert das eine Row gelöscht werden darf oder nicht
		/// </summary>
		//----------------------------------------------------------------------------
		public bool	ROW_DELETE_ALLOWED
		{
			set 
			{
				if(value)
					dgKatalog.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
				else
					dgKatalog.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
			}
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
				lblSuche.BackColor = value;
                //dgKatalog.DisplayLayout.Appearance.BackColor = value;
				//dgKatalog.DisplayLayout.Bands[0].Columns["TEXT"].CellAppearance.BackColor = value;
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
		/// Setzt den Eingabefocus auf den Texteditor
		/// </summary>
		//----------------------------------------------------------------------------
		public void focus()
		{ 
			tbSearch.Focus();
			tbSearch.Text = null;
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
				if(((string)r.Cells["Text"].Value).Trim().Length == 0)
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
				_Katalog.Write();
				tbSearch.Text = null;
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
			_Katalog.Read(false);
			foreach (UltraGridRow r in dgKatalog.Rows)
				r.Hidden = true;

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
		/// Fügt einen neuen Eintrag hinzu
		/// </summary>
		//----------------------------------------------------------------------------
		public void AddNew() 
		{
			_Katalog.AddNew();
			ScrollToEnd();
			dgKatalog.Focus();
			dgKatalog.PerformAction(UltraGridAction.LastRowInGrid);
			if(dgKatalog.ActiveRow != null) 
			{
				dgKatalog.ActiveCell = dgKatalog.ActiveRow.Cells["Text"];
				dgKatalog.PerformAction(UltraGridAction.EnterEditMode);
			}
			
			CellUpdated();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Löscht den aktuell markierten Eintrag (Markiert EntferntJN)
		/// </summary>
		//----------------------------------------------------------------------------
		public void DeleteCurrent() 
		{

			// Statt entfernen nur markieren UltraGridTools.DeleteCurrentSelectedRow(dgKatalog);
			UltraGridRow r = dgKatalog.ActiveRow;
			if((r == null) || (r.ListObject == null))
				return;

			
			int iIndex = Math.Min(dgKatalog.ActiveRow.VisibleIndex, dgKatalog.Rows.Count-2);
			UltraGridRow rnext = dgKatalog.Rows.GetRowAtVisibleIndex(iIndex+1);
			r.Cells["EntferntJN"].Value = 1;
			dgKatalog.PerformAction(UltraGridAction.NextRowByTab);
			dgKatalog.DataBind();
			//if(rnext!=null)
			//	dgKatalog.ActiveRow = rnext;
			foreach (UltraGridRow rr in dgKatalog.Rows)
				rr.Hidden = true;
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
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            this.dgKatalog = new QS2.Desktop.ControlManagment.BaseGrid();
            this.tbSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSuche = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).BeginInit();
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
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(26, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.MaxLength = 20;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 153;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.MaxLength = 255;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(214, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 184;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "ASRZM";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.MaxLength = 255;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(443, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Width = 300;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.ColSpan = ((short)(0));
            ultraGridColumn11.DataType = typeof(bool);
            ultraGridColumn11.DefaultCellValue = false;
            ultraGridColumn11.Header.VisiblePosition = 3;
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
            this.dgKatalog.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.dgKatalog.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.dgKatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKatalog.Location = new System.Drawing.Point(0, 0);
            this.dgKatalog.Name = "dgKatalog";
            this.dgKatalog.Size = new System.Drawing.Size(664, 240);
            this.dgKatalog.TabIndex = 0;
            this.dgKatalog.Text = "** Katalog **";
            this.dgKatalog.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgKatalog_AfterCellUpdate);
            this.dgKatalog.AfterRowActivate += new System.EventHandler(this.dgKatalog_AfterRowActivate);
            this.dgKatalog.AfterRowsDeleted += new System.EventHandler(this.dgKatalog_AfterRowsDeleted);
            this.dgKatalog.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgKatalog_CellChange);
            this.dgKatalog.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.dgKatalog_BeforeRowDeactivate);
            this.dgKatalog.DoubleClick += new System.EventHandler(this.dgKatalog_DoubleClick);
            this.dgKatalog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgKatalog_MouseUp);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(88, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(168, 21);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.ValueChanged += new System.EventHandler(this.tbSearch_ValueChanged);
            // 
            // lblSuche
            // 
            this.lblSuche.Location = new System.Drawing.Point(1, 1);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Padding = new System.Drawing.Size(19, 3);
            this.lblSuche.Size = new System.Drawing.Size(87, 20);
            this.lblSuche.TabIndex = 4;
            this.lblSuche.Text = "Suchen :";
            // 
            // ucKatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lblSuche);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgKatalog);
            this.Name = "ucKatalog";
            this.Size = new System.Drawing.Size(664, 240);
            this.Load += new System.EventHandler(this.ucKatalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
		/// Rechtsklick im Datengrid nach oben geleitet
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgKatalog_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(MouseUpOnGridRight != null) 
			{
				if(e.Button == MouseButtons.Right)
					MouseUpOnGridRight(sender, e);
			}
		}

		private void ucKatalog_Load(object sender, System.EventArgs e)
		{
			
		}

		private void SetFilter()
		{
			this.TEXTFILTER = tbSearch.Text.Trim();
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
		}

		private void dgKatalog_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
		}

		private void dgKatalog_AfterRowsDeleted(object sender, System.EventArgs e)
		{
			CellUpdated();
		}

		private void dgKatalog_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
		}

		private void tbSearch_ValueChanged(object sender, System.EventArgs e)
		{
			if(tbSearch.Text.Length > 0 )
			{ 
				foreach (UltraGridRow r in dgKatalog.Rows)
				{
					r.Hidden = false;
				}								
			}
			else 
			{
				foreach (UltraGridRow r in dgKatalog.Rows)
					r.Hidden = true;

				if(Editorempty != null) // damit in ucKatalogEdit die EintragZusätze ausgeblendet werden können wenn keine sichtbare Maßnahme selektiert ist 
					Editorempty(this,null);
			}

			SetFilter();
			
		}

		private void dgKatalog_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(BeforeRowDeactivate != null)			
				BeforeRowDeactivate(sender, e);
		}

		
	}
}
