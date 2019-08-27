//----------------------------------------------------------------------------
/// <summary>
///	ucBereich.cs
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
using PMDS.Data.Global;
using PMDS.Data.Patient;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Patient;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation der Bereiche einer Klinik
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBereich : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool	_valueChangeEnabled = true;
		private KlinikBereiche	_Bereiche;
		public event EventHandler ValueChanged;

		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnDel;
		private dsBereich dsBereich1;
        private QS2.Desktop.ControlManagment.BaseGrid dgBereiche;
		private System.ComponentModel.IContainer components;

        public dsKlinik.KlinikRow rSelectedKlinik = null;
        public PMDSBusiness b = new PMDSBusiness();



        //----------------------------------------------------------------------------
        /// <summary>
        /// Default Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucBereich()
		{
			InitializeComponent();
			Bereiche = new KlinikBereiche();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBereich));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Bereich", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bereichstyp", -1, 273350626);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnzahlBetten");
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.dgBereiche = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsBereich1 = new PMDS.Global.db.Patient.dsBereich();
            ((System.ComponentModel.ISupportInitialize)(this.dgBereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBereich1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance1;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.HotTrackAppearance = appearance2;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(793, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShowFocusRect = false;
            this.btnAdd.ShowOutline = false;
            this.btnAdd.Size = new System.Drawing.Size(21, 21);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.grid;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDel.HotTrackAppearance = appearance4;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(814, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.ShowFocusRect = false;
            this.btnDel.ShowOutline = false;
            this.btnDel.Size = new System.Drawing.Size(21, 21);
            this.btnDel.TabIndex = 23;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.grid;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dgBereiche
            // 
            this.dgBereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBereiche.AutoWork = true;
            this.dgBereiche.DataSource = this.dsBereich1.Bereich;
            this.dgBereiche.DisplayLayout.AddNewBox.Prompt = "Add ...";
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Abteilung";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(205, 0);
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(219, 0);
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(191, 0);
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn7.Header.Caption = "Anzahl Betten";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(102, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgBereiche.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgBereiche.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgBereiche.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgBereiche.DisplayLayout.Override.NullText = "";
            this.dgBereiche.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgBereiche.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgBereiche.Location = new System.Drawing.Point(8, 8);
            this.dgBereiche.Name = "dgBereiche";
            this.dgBereiche.Size = new System.Drawing.Size(829, 394);
            this.dgBereiche.TabIndex = 24;
            this.dgBereiche.Text = "Bereiche";
            this.dgBereiche.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgBereiche_CellChange);
            // 
            // dsBereich1
            // 
            this.dsBereich1.DataSetName = "dsBereich";
            this.dsBereich1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsBereich1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucBereich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgBereiche);
            this.Name = "ucBereich";
            this.Size = new System.Drawing.Size(845, 410);
            this.Load += new System.EventHandler(this.ucBereich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBereich1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// BEREICHE setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public KlinikBereiche Bereiche
		{
			get	
			{	
				return _Bereiche;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Bereiche");

				_valueChangeEnabled = false;
				_Bereiche = value;
				dgBereiche.DataSource = _Bereiche.Bereiche;
				_valueChangeEnabled = true;
				UpdateButtons();
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI initialisieren und Abteilungs-Listen befüllen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucBereich_Load(object sender, System.EventArgs e)
		{
			try
			{
				InitCombo();
                this.BackColor = System.Drawing.Color.WhiteSmoke;
                this.dgBereiche.DisplayLayout.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
                this.dgBereiche .DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Combo-Box befüllen
		/// </summary>
		//----------------------------------------------------------------------------
		private void InitCombo()
		{
            try
            {
			    // Abteilungs-Combo initialisieren
                //ValueList v = new ValueList();
                //foreach (dsGUIDListe.IDListeRow r in KlinikAbteilungen.All())
                //{
                
                //    v.ValueListItems.Add(r.ID, r.TEXT);
                //}

                ValueList v = new ValueList();
                dsAbteilung dsAbteilung1 = new dsAbteilung ();
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(this.rSelectedKlinik.ID, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbtKlinik in dsAbteilung1.Abteilung)
                {
                    v.ValueListItems.Add(rAbtKlinik.ID, rAbtKlinik.Bezeichnung.Trim());
                }
			    UltraGridColumn c = dgBereiche.DisplayLayout.Bands[0].Columns["IDAbteilung"];
			    c.ValueList = v;
			    c.Style	 = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                v = new ValueList();
                this.dgBereiche.DisplayLayout.ValueLists.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    v = new ValueList();
                    IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = this.b.GetAuswahlliste(db, "BET", -100000, false);
                    foreach (PMDS.db.Entities.AuswahlListe rSelList in tAuswahlliste)
                    {
                       v.ValueListItems.Add(rSelList.Bezeichnung.Trim(), rSelList.Bezeichnung.Trim());
                    }
                }
                c = dgBereiche.DisplayLayout.Bands[0].Columns["Bereichstyp"];
                c.ValueList = v;
                c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;

                this.dgBereiche.DisplayLayout.Bands[0].Columns["Bezeichnung"].Width = 220;

            }
            catch (Exception ex)
            {
                throw new Exception("ucBereich.InitCombo: " + ex.ToString());
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
		private void dgBereiche_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
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
			Bereiche.AddBereichxy();
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
			UltraGridTools.DeleteCurrentSelectedRow(dgBereiche, false);
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
			btnDel.Enabled = (dgBereiche.Rows.Count > 0);
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

			// Bereiche - keine Leeren zeilen erlaubt
			foreach(dsBereich.BereichRow r in _Bereiche.Bereiche)
			{
				if (r.RowState == DataRowState.Deleted)
					continue;

				GuiUtil.ValidateField(dgBereiche, (r.Bezeichnung.Trim().Length > 0),
					ENV.String("GUI.E_NO_EMPTY_LINES"), ref bError, false, null);

				if (bError)
					break;
			}

			return !bError;
		}
	}
}
