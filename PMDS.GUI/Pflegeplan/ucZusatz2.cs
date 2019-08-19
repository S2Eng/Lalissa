//----------------------------------------------------------------------------
/// <summary>
///	ucZusatz2.cs
/// Erstellt am:	04.8.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zum Bearbeiten einer ZusatzGruppen für Maßnahmen.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucZusatz2 : PMDS.GUI.ucZusatz
	{
		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnSave;
		private PMDS.GUI.ucButton btnNew;
		private PMDS.GUI.ucButton btnDelete;
		private bool contentChanged = false;
		private System.ComponentModel.IContainer components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucZusatz2()
		{
			InitializeComponent();
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnNew = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEintrag
            // 
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
            this.dgEintrag.DisplayLayout.GroupByBox.Hidden = true;
            this.dgEintrag.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgEintrag.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgEintrag.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgEintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgEintrag.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgEintrag.DisplayLayout.Override.NullText = "";
            this.dgEintrag.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgEintrag.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgEintrag.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgEintrag.Location = new System.Drawing.Point(0, 0);
            this.dgEintrag.Size = new System.Drawing.Size(462, 158);
            this.dgEintrag.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgEintrag_CellChange);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(417, 0);
            this.btnAdd.Size = new System.Drawing.Size(24, 20);
            this.btnAdd.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(441, 0);
            this.btnDel.Size = new System.Drawing.Size(24, 20);
            this.btnDel.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.Image = 2;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnNew.Appearance = appearance1;
            this.btnNew.Location = new System.Drawing.Point(6, 160);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 32);
            this.btnNew.TabIndex = 21;
            this.btnNew.Text = "&Hinzufügen";
            this.btnNew.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = 1;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(265, 160);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 23;
            this.btnUndo.Text = "&Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = 0;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSave.Appearance = appearance3;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(362, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "&Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.Image = 3;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDelete.Appearance = appearance4;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(103, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 32);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "&Entfernen";
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucZusatz2
            // 
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Name = "ucZusatz2";
            this.Size = new System.Drawing.Size(465, 197);
            this.Load += new System.EventHandler(this.ucZusatz2_Load);
            this.Controls.SetChildIndex(this.dgEintrag, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnUndo, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	

		public bool CONTENT_CHANGED
		{
			get
			{
				return contentChanged;
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			base.Add();
			btnUndo.Enabled = true;
			btnSave.Enabled = true;
			contentChanged = true;
			UpdateButtons();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			base.Del();
			btnUndo.Enabled = true;
			btnSave.Enabled = true;
			contentChanged = true;
			UpdateButtons();
		}

		private void btnUndo_Click(object sender, System.EventArgs e)
		{
			this.Read();
			btnUndo.Enabled = false;
			btnSave.Enabled = false;
			contentChanged = false;
			UpdateButtons();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.Write();
			btnUndo.Enabled = false;
			btnSave.Enabled = false;
			contentChanged = false;
			UpdateButtons();
		}

		
		private void dgEintrag_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			btnUndo.Enabled = true;
			btnSave.Enabled = true;
			btnSave.Enabled = true;
			UpdateButtons();
		}

		private void UpdateButtons()
		{
			btnDelete.Enabled = (dgEintrag.Rows.Count > 0);
		}

		private void ucZusatz2_Load(object sender, System.EventArgs e)
		{
			UpdateButtons();
		}

	}
}

