using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
	/// <summary>
	/// Zusammenfassung für ucAddPDXToTop.
	/// </summary>
	public class ucAddPDXToTop : QS2.Desktop.ControlManagment.BaseControl
	{
		public event AddSelectedPDXToTOPDelegate PDXToTOPSelected;

		private PDx								_PDx;

		private QS2.Desktop.ControlManagment.BasePanel panel2;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpPDXKatalog;
		private QS2.Desktop.ControlManagment.BaseLabel lblSuchePDX;
		private QS2.Desktop.ControlManagment.BaseGrid dgPDx;
		private PMDS.GUI.ucButton btnAdd;
		private dsPDx dsPDx1;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSearch;
		private System.ComponentModel.IContainer components;
		private bool contentChanged = false;

		public ucAddPDXToTop()
		{
			// Dieser Aufruf ist für den Windows Form-Designer erforderlich.
			InitializeComponent();

			// TODO: Initialisierungen nach dem Aufruf von InitializeComponent hinzufügen

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

		public bool CONTENTCHANGED
		{
			get {	return contentChanged;	}
		}

				

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PDX", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klartext");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Code");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThematischeID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EntferntJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Definition");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Gruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LokalisierungsTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WundeJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDXKuerzel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddPDXToTop));
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpPDXKatalog = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblSuchePDX = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dgPDx = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPDx1 = new dsPDx();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.panel2.SuspendLayout();
            this.grpPDXKatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpPDXKatalog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 304);
            this.panel2.TabIndex = 17;
            // 
            // grpPDXKatalog
            // 
            this.grpPDXKatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPDXKatalog.Controls.Add(this.lblSuchePDX);
            this.grpPDXKatalog.Controls.Add(this.txtSearch);
            this.grpPDXKatalog.Controls.Add(this.dgPDx);
            this.grpPDXKatalog.Controls.Add(this.btnAdd);
            this.grpPDXKatalog.Location = new System.Drawing.Point(8, 16);
            this.grpPDXKatalog.Name = "grpPDXKatalog";
            this.grpPDXKatalog.Size = new System.Drawing.Size(916, 285);
            this.grpPDXKatalog.TabIndex = 14;
            this.grpPDXKatalog.TabStop = false;
            this.grpPDXKatalog.Text = "PDX Katalog";
            // 
            // lblSuchePDX
            // 
            this.lblSuchePDX.Location = new System.Drawing.Point(8, 24);
            this.lblSuchePDX.Name = "lblSuchePDX";
            this.lblSuchePDX.Padding = new System.Drawing.Size(18, 3);
            this.lblSuchePDX.Size = new System.Drawing.Size(152, 20);
            this.lblSuchePDX.TabIndex = 28;
            this.lblSuchePDX.Text = "Suchen in allen PDX :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(160, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.ValueChanged += new System.EventHandler(this.txtSearch_ValueChanged);
            // 
            // dgPDx
            // 
            this.dgPDx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPDx.AutoWork = true;
            this.dgPDx.DataSource = this.dsPDx1.PDX;
            this.dgPDx.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Pflegediagnose";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(484, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "Beschreibung";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(356, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.DataType = typeof(bool);
            ultraGridColumn11.DefaultCellValue = false;
            ultraGridColumn11.Header.VisiblePosition = 7;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(55, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
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
            this.dgPDx.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgPDx.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.dgPDx.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.dgPDx.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgPDx.Location = new System.Drawing.Point(8, 24);
            this.dgPDx.Name = "dgPDx";
            this.dgPDx.Size = new System.Drawing.Size(897, 213);
            this.dgPDx.TabIndex = 6;
            this.dgPDx.Text = "PDX";
            this.dgPDx.Click += new System.EventHandler(this.dgPDx_Click);
            // 
            // dsPDx1
            // 
            this.dsPDx1.DataSetName = "dsPDx";
            this.dsPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance1;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.Enabled = false;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 245);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(216, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucAddPDXToTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panel2);
            this.Name = "ucAddPDXToTop";
            this.Size = new System.Drawing.Size(936, 304);
            this.Load += new System.EventHandler(this.ucAddPDXToTop_Load);
            this.panel2.ResumeLayout(false);
            this.grpPDXKatalog.ResumeLayout(false);
            this.grpPDXKatalog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void txtSearch_ValueChanged(object sender, System.EventArgs e)
		{	
			
			if(txtSearch.Text.Length > 0 )
			{ 
				foreach (UltraGridRow r in dgPDx.Rows)
					r.Hidden = false;
					
			}
			else 
			{
				foreach (UltraGridRow r in dgPDx.Rows)
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
		/// Setzt den Filter für den Text
		/// </summary>
		//----------------------------------------------------------------------------
		public string TEXTFILTER 
		{
			set 
			{
				if(value == null || value.Length == 0)
					dgPDx.DisplayLayout.Bands[0].ColumnFilters["Klartext"].FilterConditions.Clear();

				else if(txtSearch.Text.StartsWith("%%%"))
					dgPDx.DisplayLayout.Bands[0].ColumnFilters["Klartext"].FilterConditions.Clear();
				
				else 
				{
					string s = "*" + value + "*";
					if(dgPDx.DisplayLayout.Bands[0].ColumnFilters["Klartext"].FilterConditions.Count == 0)
						dgPDx.DisplayLayout.Bands[0].ColumnFilters["Klartext"].FilterConditions.Add(FilterComparisionOperator.Like, s);
					else
						dgPDx.DisplayLayout.Bands[0].ColumnFilters["Klartext"].FilterConditions[0].CompareValue = s;
				}
				dgPDx.Refresh();
			}
		}


		private void btnAdd_Click(object sender, System.EventArgs e)
		{						
			 AddToTop();			
		}

		public void AddToTop()
		{
			ArrayList al = new ArrayList();
			
			int i = 0 ;
			foreach(UltraGridRow r in dgPDx.Rows)
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

			if(PDXToTOPSelected != null)
				PDXToTOPSelected(rc);


			foreach(UltraGridRow r in dgPDx.Rows)
			{
				r.Cells["Auswahl"].Value = false;
			}
			btnAdd.Enabled = false;
			contentChanged = false;
		}


		private void dgPDx_Click(object sender, System.EventArgs e)
		{
			bool found = false;
			if(dgPDx.ActiveCell != null)
			{
				if(dgPDx.ActiveCell == dgPDx.ActiveRow.Cells["Auswahl"])
				{

					if((bool) dgPDx.ActiveRow.Cells["Auswahl"].Value == false)// && (dgPDx.ActiveCell == dgPDx.ActiveRow.Cells["Auswahl"]))
						dgPDx.ActiveRow.Cells["Auswahl"].Value = true;

					else  dgPDx.ActiveRow.Cells["Auswahl"].Value = false;

					dgPDx.ActiveCell = null;

					foreach(UltraGridRow r in  dgPDx.Rows)
					{ 
						if((bool)r.Cells["Auswahl"].Value == true)
						{
							found = true;
							break;
						}
					}
			

					if(found)
					{
						btnAdd.Enabled = true;
						contentChanged = true;
					}
					else
					{
						btnAdd.Enabled = false;
						contentChanged = false;
					}
				}
			}
		}

		public void FocusOntxtSearch()
		{
			txtSearch.Focus();
		}



		private void ucAddPDXToTop_Load(object sender, System.EventArgs e)
		{
			try
			{			
				_PDx = new PDx();
				dgPDx.DataSource	= _PDx.PDXEINTRAEGE;

				foreach (UltraGridRow r in dgPDx.Rows)
					r.Hidden = true;
				
			}
		
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}



	}
}
