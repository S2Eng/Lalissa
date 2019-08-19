using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;


namespace PMDS.GUI
{
	/// <summary>
	/// Zusammenfassung f�r ucAddASZM.
	/// </summary>
	public class ucAddASZM : QS2.Desktop.ControlManagment.BaseControl
	{
		public event AddSelectedASZMToPDXDelegate ASZMToPDXSelected;

		private QS2.Desktop.ControlManagment.BasePanel panelAll;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpASZMKatalog;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSearch;
		private QS2.Desktop.ControlManagment.BaseLabel lblSuche;
		private QS2.Desktop.ControlManagment.BaseGrid dgEintr�ge;
		private PMDS.GUI.ucButton btnHinzuf�gen;
		private dsEintrag dsEintrag1;
		private System.ComponentModel.IContainer components;
		private bool contentChanged = false;

		private PDx   _PDx;
		private ArrayList EintragGruppen;
		private string ASZMAuswahl;

		public ucAddASZM()
		{
			// Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
			InitializeComponent();

		}

		/// <summary> 
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode f�r die Designerunterst�tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("flag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLinkDokument");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BedarfsMedikationJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OhneZeitBezug");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddASZM));
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpASZMKatalog = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSuche = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dgEintr�ge = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            this.btnHinzuf�gen = new PMDS.GUI.ucButton(this.components);
            this.panelAll.SuspendLayout();
            this.grpASZMKatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEintr�ge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.grpASZMKatalog);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1008, 328);
            this.panelAll.TabIndex = 26;
            // 
            // grpASZMKatalog
            // 
            this.grpASZMKatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpASZMKatalog.Controls.Add(this.txtSearch);
            this.grpASZMKatalog.Controls.Add(this.lblSuche);
            this.grpASZMKatalog.Controls.Add(this.dgEintr�ge);
            this.grpASZMKatalog.Controls.Add(this.btnHinzuf�gen);
            this.grpASZMKatalog.Location = new System.Drawing.Point(8, 16);
            this.grpASZMKatalog.Name = "grpASZMKatalog";
            this.grpASZMKatalog.Size = new System.Drawing.Size(992, 307);
            this.grpASZMKatalog.TabIndex = 0;
            this.grpASZMKatalog.TabStop = false;
            this.grpASZMKatalog.Text = "ASRZM Katalog";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(184, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(416, 21);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.ValueChanged += new System.EventHandler(this.txtSearch_ValueChanged);
            // 
            // lblSuche
            // 
            this.lblSuche.Location = new System.Drawing.Point(8, 24);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Padding = new System.Drawing.Size(4, 3);
            this.lblSuche.Size = new System.Drawing.Size(296, 20);
            this.lblSuche.TabIndex = 27;
            this.lblSuche.Text = "Geben Sie hier den Suchtext ein:";
            // 
            // dgEintr�ge
            // 
            this.dgEintr�ge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEintr�ge.AutoWork = true;
            this.dgEintr�ge.DataSource = this.dsEintrag1.Eintrag;
            this.dgEintr�ge.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(33, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(37, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(55, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "ASRZM";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(232, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.DataType = typeof(bool);
            ultraGridColumn7.DefaultCellValue = false;
            ultraGridColumn7.Header.VisiblePosition = 10;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(25, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn7});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgEintr�ge.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgEintr�ge.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgEintr�ge.Location = new System.Drawing.Point(8, 24);
            this.dgEintr�ge.Name = "dgEintr�ge";
            this.dgEintr�ge.Size = new System.Drawing.Size(973, 236);
            this.dgEintr�ge.TabIndex = 26;
            this.dgEintr�ge.Text = "ASRZM";
            this.dgEintr�ge.Click += new System.EventHandler(this.dgEintr�ge_Click);
            // 
            // dsEintrag1
            // 
            this.dsEintrag1.DataSetName = "dsEintrag";
            this.dsEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnHinzuf�gen
            // 
            this.btnHinzuf�gen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnHinzuf�gen.Appearance = appearance1;
            this.btnHinzuf�gen.AutoWorkLayout = false;
            this.btnHinzuf�gen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHinzuf�gen.DoOnClick = true;
            this.btnHinzuf�gen.Enabled = false;
            this.btnHinzuf�gen.IsStandardControl = true;
            this.btnHinzuf�gen.Location = new System.Drawing.Point(8, 267);
            this.btnHinzuf�gen.Name = "btnHinzuf�gen";
            this.btnHinzuf�gen.Size = new System.Drawing.Size(288, 32);
            this.btnHinzuf�gen.TabIndex = 24;
            this.btnHinzuf�gen.TabStop = false;
            this.btnHinzuf�gen.Text = "Hinzuf�gen";
            this.btnHinzuf�gen.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnHinzuf�gen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnHinzuf�gen.Click += new System.EventHandler(this.btnHinzuf�gen_Click);
            // 
            // ucAddASZM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelAll);
            this.Name = "ucAddASZM";
            this.Size = new System.Drawing.Size(1008, 328);
            this.Load += new System.EventHandler(this.ucAddASZM_Load);
            this.panelAll.ResumeLayout(false);
            this.grpASZMKatalog.ResumeLayout(false);
            this.grpASZMKatalog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEintr�ge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		public bool CONTENTCHANGED
		{
			get { return contentChanged;}
		}
				



		public ArrayList EINTRAGGRUPPEN
		{
			get
			{ 
				return EintragGruppen;
			}
			set
			{
				EintragGruppen = value;
				
			}
		}

		public string ASZMAUSWAHL
		{
			get
			{
				return ASZMAuswahl;
			}
			set
			{
				ASZMAuswahl = value;
			}
		}

	private void txtSearch_ValueChanged(object sender, System.EventArgs e)
{	
			
	if(txtSearch.Text.Length > 0 )
{ 
	foreach (UltraGridRow r in dgEintr�ge.Rows)
	r.Hidden = false;
					
}
	else 
{
	foreach (UltraGridRow r in dgEintr�ge.Rows)
	r.Hidden = true;
					
}
	Setfilter();
}

	private void Setfilter()
{
			
	this.TEXTFILTER = txtSearch.Text.Trim();
}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Setzt den Filter f�r den Text
	/// </summary>
	//----------------------------------------------------------------------------
	public string TEXTFILTER 
{
	set 
{
				
	if(value == null || value.Length == 0)
{
	dgEintr�ge.Rows.ColumnFilters["Text"].FilterConditions.Clear();
	txtSearch.Clear();
}
				else if(txtSearch.Text.StartsWith("%%%"))
					dgEintr�ge.Rows.ColumnFilters["Text"].FilterConditions.Clear();
				else 
				{	
					string s = "*" + value + "*";
					if(dgEintr�ge.Rows.ColumnFilters["Text"].FilterConditions.Count == 0)
						dgEintr�ge.Rows.ColumnFilters["Text"].FilterConditions.Add(FilterComparisionOperator.Like, s);
					else
						dgEintr�ge.Rows.ColumnFilters["Text"].FilterConditions[0].CompareValue = s;
				}
				dgEintr�ge.Refresh();
				if(dgEintr�ge.Rows.Count > 0)
					dgEintr�ge.ActiveRowScrollRegion.FirstRow = dgEintr�ge.Rows[0];
				
			}
		}
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// ASZM Filter setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public void HideEintragGruppe(string group)
		{
			dgEintr�ge.Rows.ColumnFilters["EintragGruppe"].FilterConditions.Add(FilterComparisionOperator.NotEquals, group);
		
		}

		private void btnHinzuf�gen_Click(object sender, System.EventArgs e)
		{
			AddToPDX();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gew�hlte ASZM zur PDX zuf�gen �ber delegate ASZMToPDXSelected([])
		/// </summary>
		//----------------------------------------------------------------------------
		public void AddToPDX()
		{
			ArrayList al = new ArrayList();
			
			int i = 0 ;
			foreach(UltraGridRow r in dgEintr�ge.Rows)
				if((bool)r.Cells["Auswahl"].Value == true && !r.IsFilteredOut)
				{
					al.Add(r);
					i++;
				}

			UltraGridRow[] rc = new UltraGridRow[al.Count];
			int j = 0;
			foreach(object o in al)
			{
				rc[j] = (UltraGridRow)o;
				j++;
			}

			if(ASZMToPDXSelected != null)
				ASZMToPDXSelected(rc);


			foreach(UltraGridRow r in dgEintr�ge.Rows)
			{
				r.Cells["Auswahl"].Value = false;
			}
			btnHinzuf�gen.Enabled = false;
			contentChanged = false;

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auswahl Checkbox setzen 
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgEintr�ge_Click(object sender, System.EventArgs e)
		{
			bool found = false;
			if(dgEintr�ge.ActiveCell != null)
			{
				if(dgEintr�ge.ActiveCell == dgEintr�ge.ActiveRow.Cells["Auswahl"])
				{

					if((bool)dgEintr�ge.ActiveRow.Cells["Auswahl"].Value == false)// && (dgEintr�ge.ActiveCell == dgEintr�ge.ActiveRow.Cells["Auswahl"]))
					{
						dgEintr�ge.ActiveRow.Cells["Auswahl"].Value = true;
						
					}

					else
					{
						dgEintr�ge.ActiveRow.Cells["Auswahl"].Value = false;
					}

					dgEintr�ge.ActiveCell = null;
					

					foreach(UltraGridRow r in dgEintr�ge.Rows)
					{ 
						if((bool)r.Cells["Auswahl"].Value == true)
						{
							found = true;
							break;
						}
					}
			

					if(found)
					{
						btnHinzuf�gen.Enabled = true;
						contentChanged = true;
					}
					else
					{
						btnHinzuf�gen.Enabled = false;
						contentChanged = false;
					}
				}
			}
		}

		

		private void ucAddASZM_Load(object sender, System.EventArgs e)
		{
			try
			{
			
			
				_PDx = new PDx();

				Katalog k				= new Katalog('X');					// Alle
				
				this.Cursor = Cursors.Arrow;
				
				k.Read(false);
				dgEintr�ge.DataSource = k.EINTRAEGE; 
				foreach (UltraGridRow r in dgEintr�ge.Rows)
					r.Hidden = true;
				
				string strA = "A";
				string strS = "S";
				string strZ = "Z";
				string strM = "M";

				foreach(string s in EINTRAGGRUPPEN)
				{
					HideEintragGruppe(s);
				}
				if(!EINTRAGGRUPPEN[0].Equals("A"))  strA = "A";		else strA="";
				if(!EINTRAGGRUPPEN[1].Equals("S"))  strS = "S";		else strS="";				
				if(!EINTRAGGRUPPEN[2].Equals("Z"))  strZ = "Z";		else strZ="";
				if(!EINTRAGGRUPPEN[3].Equals("M"))  strM = "M";		else strM="";
			
				lblSuche.Text = ENV.String("INPUT_SEARCH_STING");
				dgEintr�ge.Text = strA+strS+strZ+strM;
				grpASZMKatalog.Text = ENV.String("KATALOG_LIMITED",ASZMAUSWAHL);
				if(strA != "" && strS != "" && strZ != "" && strM != "")
					grpASZMKatalog.Text = ENV.String("KATALOG_UNLIMITED");


			}
		
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		public void FocusOntxtSearch()
		{
			txtSearch.Focus();
		}





	}
}
