//----------------------------------------------------------------------------
/// <summary>
///	ucZusatz.cs
/// Erstellt am:	04.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zum Bearbeiten einer ZusatzGruppen.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucZusatz : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private ZusatzGruppe _ZusatzGruppe;
		private bool _valueChangeEnabled = true;
		public event EventHandler ValueChanged;

		private dsZusatzGruppeEintrag dsZusatzGruppeEintrag1;
		protected Infragistics.Win.UltraWinGrid.UltraGrid dgEintrag;
		protected PMDS.GUI.ucButton btnAdd;
		protected PMDS.GUI.ucButton btnDel;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucZusatz()
		{
			InitializeComponent();
			New();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ZusatzGruppeEintrag", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZusatzGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZusatzEintrag", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObjekt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDFilter");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OptionalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DruckenJN");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.dsZusatzGruppeEintrag1 = new dsZusatzGruppeEintrag();
            this.dgEintrag = new QS2.Desktop.ControlManagment.BaseGrid();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppeEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).BeginInit();
            this.SuspendLayout();
            // 
            // dsZusatzGruppeEintrag1
            // 
            this.dsZusatzGruppeEintrag1.DataSetName = "dsZusatzGruppeEintrag";
            this.dsZusatzGruppeEintrag1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsZusatzGruppeEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgEintrag
            // 
            this.dgEintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEintrag.DataSource = this.dsZusatzGruppeEintrag1.ZusatzGruppeEintrag;
            this.dgEintrag.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgEintrag.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Caption = "Eintrag";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaxLength = 6;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(158, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "Abteilung";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(106, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Optional";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(59, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Drucken";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(61, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgEintrag.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgEintrag.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgEintrag.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgEintrag.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgEintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgEintrag.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgEintrag.DisplayLayout.Override.NullText = "";
            this.dgEintrag.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgEintrag.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgEintrag.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgEintrag.Location = new System.Drawing.Point(8, 32);
            this.dgEintrag.Name = "dgEintrag";
            this.dgEintrag.Size = new System.Drawing.Size(424, 304);
            this.dgEintrag.TabIndex = 18;
            this.dgEintrag.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgEintrag_CellChange);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = 2;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance1;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.Location = new System.Drawing.Point(384, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "&+";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = 3;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance2;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.Location = new System.Drawing.Point(408, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 20;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "&-";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ucZusatz
            // 
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dgEintrag);
            this.Name = "ucZusatz";
            this.Size = new System.Drawing.Size(440, 344);
            this.Load += new System.EventHandler(this.ucZusatz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppeEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// ZUSATZGRUPPE setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public ZusatzGruppe ZusatzGruppe
		{
			get	
			{	
				return _ZusatzGruppe;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("ZusatzGruppe");

				_valueChangeEnabled = false;
				_ZusatzGruppe = value;
				dgEintrag.DataSource = _ZusatzGruppe.ZusatzEintraege;
				_valueChangeEnabled = true;
				UpdateButtons();
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI initialisieren und ZusatzGruppen-Listen befüllen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucZusatz_Load(object sender, System.EventArgs e)
		{
			try
			{
				InitCombo();
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Combo-Boxen befüllen
		/// </summary>
		//----------------------------------------------------------------------------
		public void InitCombo()
		{
			// Eintrag-Combo initialisieren
			ValueList vl = new ValueList();
			foreach(dsIDListe.IDListeRow r in ZusatzEintrag.All())
				vl.ValueListItems.Add(r.ID, r.TEXT);

			UltraGridColumn c = dgEintrag.DisplayLayout.Bands[0].Columns["IDZusatzEintrag"];
			c.ValueList = vl;
			c.Style		= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

			// Abteilungs-Combo initialisieren
			ValueList v2 = new ValueList();
			foreach(dsGUIDListe.IDListeRow r in KlinikAbteilungen.All())
				v2.ValueListItems.Add(r.ID, r.TEXT);

			UltraGridColumn c2 = dgEintrag.DisplayLayout.Bands[0].Columns["IDObjekt"];
			c2.ValueList = v2;
			c2.Style	 = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element
		/// </summary>
		//----------------------------------------------------------------------------
		public bool New()
		{
			ZusatzGruppe = new ZusatzGruppe();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(object id)
		{
			ZusatzGruppe obj = new ZusatzGruppe((string)id);
			ZusatzGruppe = obj;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read()
		{
			ZusatzGruppe.Read();
			ZusatzGruppe = ZusatzGruppe;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten schreiben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
			try
			{
				ZusatzGruppe.Write();
			}
			catch(Exception ex)
			{
				GuiUtil.MarkErrorRows(dgEintrag);

				// bestimmte Exception dem Benutzer anzeigen
				ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten löschen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Delete()
		{
			ZusatzGruppe.Delete();
			New();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs im Grid signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgEintrag_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			OnValueChanged(sender, EventArgs.Empty);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Listeneintrag
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			ZusatzGruppe.AddEntry();
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		public void Add()
		{
			ZusatzGruppe.AddEntry();
			//OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Listeneintrag entfernen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgEintrag, false);
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		public void Del()
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgEintrag, true);
			//OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Buttons aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateButtons()
		{
			btnDel.Enabled = (dgEintrag.Rows.Count > 0);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			// KEINE Felder für Übertragung
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			// KEINE Felder zum validieren
			return true;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// alle Reihen verstecken beim Start von ucKatalogEdit wenn keine sichtbare Maßnahme selektiert
		/// </summary>
		//----------------------------------------------------------------------------
		public void HideRows(bool hide)
		{
			foreach(UltraGridRow r in dgEintrag.Rows)
				r.Hidden = hide;

		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return ZusatzGruppe.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return ZusatzGruppe;					}
			set	{	ZusatzGruppe = (ZusatzGruppe)value;	}
		}

		#endregion
	}
}
