//----------------------------------------------------------------------------
/// <summary>
///	ucAbteilungen.cs
/// Erstellt am:	07.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation der Abteilungen einer Klinik
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucAbteilungen : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool	_valueChangeEnabled = true;
		private KlinikAbteilungen	_Abteilungen;
		public event EventHandler ValueChanged;

		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnDel;
		private QS2.Desktop.ControlManagment.BaseGrid dgAbteilungen;
		private dsAbteilung dsAbteilung1;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucAbteilungen()
		{
			InitializeComponent();
			Abteilungen = new KlinikAbteilungen();
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAbteilungen));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Mobil");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Andere");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Email");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ansprechpartner");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RMOptionalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Basisabteilung");
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.dgAbteilungen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAbteilung1 = new PMDS.Global.db.Patient.dsAbteilung();
            ((System.ComponentModel.ISupportInitialize)(this.dgAbteilungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance1;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(720, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 20);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance2;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(744, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 20);
            this.btnDel.TabIndex = 23;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dgAbteilungen
            // 
            this.dgAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAbteilungen.AutoWork = true;
            this.dgAbteilungen.DataSource = this.dsAbteilung1.Abteilung;
            this.dgAbteilungen.DisplayLayout.AddNewBox.Prompt = "Add ...";
            ultraGridBand1.AddButtonCaption = "AuswahlListeGruppe";
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(185, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(86, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Stationsleitung";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(124, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(76, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "FiBu-Konto";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Caption = "Bericht freiwillig";
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(87, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(68, 0);
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 15;
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
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgAbteilungen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgAbteilungen.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgAbteilungen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgAbteilungen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgAbteilungen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgAbteilungen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            this.dgAbteilungen.DisplayLayout.Override.NullText = "";
            this.dgAbteilungen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgAbteilungen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgAbteilungen.Location = new System.Drawing.Point(8, 8);
            this.dgAbteilungen.Name = "dgAbteilungen";
            this.dgAbteilungen.Size = new System.Drawing.Size(760, 352);
            this.dgAbteilungen.TabIndex = 24;
            this.dgAbteilungen.Text = "Abteilungen";
            this.dgAbteilungen.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgAbteilungen_CellChange);
            // 
            // dsAbteilung1
            // 
            this.dsAbteilung1.DataSetName = "dsAbteilung";
            this.dsAbteilung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsAbteilung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucAbteilungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgAbteilungen);
            this.Name = "ucAbteilungen";
            this.Size = new System.Drawing.Size(776, 368);
            this.Load += new System.EventHandler(this.ucAbteilungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAbteilungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// ABTEILUNGEN setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public KlinikAbteilungen Abteilungen
		{
			get	
			{	
				return _Abteilungen;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Abteilungen");

				_valueChangeEnabled = false;
				_Abteilungen = value;
				dgAbteilungen.DataSource = _Abteilungen.Abteilungen;
				_valueChangeEnabled = true;
				UpdateButtons();
			}
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
		private void dgAbteilungen_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			OnValueChanged(sender, EventArgs.Empty);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// neue Abteilung erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Abteilungen.AddAbteilung();
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählte Abteilung löschen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgAbteilungen, false);
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Buttons aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateButtons()
		{
			btnDel.Enabled = (dgAbteilungen.Rows.Count > 0);
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
			bool bError = false;

			// Abteilungen - keine Leeren zeilen erlaubt
			foreach(dsAbteilung.AbteilungRow r in _Abteilungen.Abteilungen)
			{
				if (r.RowState == DataRowState.Deleted)
					continue;

				GuiUtil.ValidateField(dgAbteilungen, (r.Bezeichnung.Trim().Length > 0),
					ENV.String("GUI.E_NO_EMPTY_LINES"), ref bError, false, null);

				if (bError)
					break;
			}

			return !bError;
		}

        private void ucAbteilungen_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgAbteilungen.DisplayLayout.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgAbteilungen.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
        }
	}
}
