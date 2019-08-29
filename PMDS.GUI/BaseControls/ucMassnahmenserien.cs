//----------------------------------------------------------------------------
/// <summary>
///	ucMassnahmenserien.cs
/// Erstellt am:	24.8.2005
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
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation der Massnamenserien
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucMassnahmenserien : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool	_valueChangeEnabled = true;
		private Massnahmenserien	_Serien;
		public event EventHandler ValueChanged;

		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnDel;
        private dsMassnahmenserien dsMassnahmenserien1;
		private QS2.Desktop.ControlManagment.BaseGrid dgSerien;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucMassnahmenserien()
		{
			InitializeComponent();
			Serien = new Massnahmenserien();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMassnahmenserien));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Massnahmenserien", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z0");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z6");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Z7");
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.dgSerien = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsMassnahmenserien1 = new dsMassnahmenserien();
            ((System.ComponentModel.ISupportInitialize)(this.dgSerien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMassnahmenserien1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance1;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(576, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 20);
            this.btnDel.TabIndex = 23;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(552, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 20);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgSerien
            // 
            this.dgSerien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSerien.AutoWork = true;
            this.dgSerien.DataSource = this.dsMassnahmenserien1.Massnahmenserien;
            this.dgSerien.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgSerien.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(239, 0);
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "hh:mm";
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "hh:mm";
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "hh:mm";
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.MaskInput = "hh:mm";
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.MaskInput = "hh:mm";
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.MaskInput = "hh:mm";
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.MaskInput = "hh:mm";
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.MaskInput = "hh:mm";
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(39, 0);
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
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
            ultraGridColumn10});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgSerien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgSerien.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgSerien.DisplayLayout.MaxColScrollRegions = 1;
            this.dgSerien.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgSerien.DisplayLayout.Override.NullText = "";
            this.dgSerien.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgSerien.Location = new System.Drawing.Point(8, 8);
            this.dgSerien.Name = "dgSerien";
            this.dgSerien.Size = new System.Drawing.Size(592, 200);
            this.dgSerien.TabIndex = 24;
            this.dgSerien.Text = "Maßnahmenserien";
            this.dgSerien.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgSerien_CellChange);
            this.dgSerien.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgSerien_BeforeExitEditMode);
            // 
            // dsMassnahmenserien1
            // 
            this.dsMassnahmenserien1.DataSetName = "dsMassnahmenserien";
            this.dsMassnahmenserien1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMassnahmenserien1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucMassnahmenserien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgSerien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucMassnahmenserien";
            this.Size = new System.Drawing.Size(608, 216);
            ((System.ComponentModel.ISupportInitialize)(this.dgSerien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMassnahmenserien1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// SERIEN setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public Massnahmenserien Serien
		{
			get	
			{	
				return _Serien;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Serien");

				_valueChangeEnabled = false;
				_Serien = value;
				dgSerien.DataSource = _Serien.Serien;
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
		private void dgSerien_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			OnValueChanged(sender, EventArgs.Empty);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// neue Serien erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Serien.AddSerie();
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählte Serie löschen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgSerien, false);
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
			btnDel.Enabled = (dgSerien.Rows.Count > 0);
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

			// Serien - keine Leeren zeilen erlaubt
			foreach(dsMassnahmenserien.MassnahmenserienRow r in _Serien.Serien)
			{
				if (r.RowState == DataRowState.Deleted)
					continue;

				GuiUtil.ValidateField(dgSerien, (r.Bezeichnung.Trim().Length > 0),
					ENV.String("GUI.E_NO_EMPTY_LINES"), ref bError, false, null);

				if (bError)
					break;
			}

			return !bError;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zeitpunkt korrigieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void dgSerien_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			// nur Z0 bis Z6 haben ein DateTime
			if (dgSerien.ActiveCell.Column.DataType == typeof(System.DateTime))
			{
				string text = dgSerien.ActiveCell.Text;
				if (text != "__:__")
				{
					// zeitpunkt korrigieren
					text = text.Replace("_", "0");
					int h = Convert.ToInt32(text.Substring(0, 2));
					int m = Convert.ToInt32(text.Substring(3, 2));
					text = string.Format("{0}:{1}", h, m);
					dgSerien.ActiveCell.Value = text;
				}
			}
		}
	}
}
