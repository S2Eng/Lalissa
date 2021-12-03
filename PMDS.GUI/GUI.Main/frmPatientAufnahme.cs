//----------------------------------------------------------------------------
/// <summary>
///	frmPatientAufnahme.cs
/// Erstellt am:	17.1.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PMDS.Data.Patient;

using PMDS.BusinessLogic;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form zur Wieder-Auswahl eines Patienten
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmPatientAufnahme : QS2.Desktop.ControlManagment.baseForm 
	{
		private bool _canClose;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtSearch;
        private QS2.Desktop.ControlManagment.BaseLabel lblSuchbegriff;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseButton btnNeuaufnahme;
		private QS2.Desktop.ControlManagment.BaseButton btnHistorie;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private dsPatientNichtAufgenommen dsPatientNichtAufgenommen1;
        private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public frmPatientAufnahme()
		{
			InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            dgMain.DisplayLayout.Appearance.BorderColor = Color.Silver;
            dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            UltraGridTools.SetGridLayoutToWhiteSmoke(dgMain, Color.WhiteSmoke);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Form initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void frmPatientAufnahme_Load(object sender, System.EventArgs e)
		{
            if (DesignMode)
                return;

            btnNeuaufnahme.Visible = ENV.HasRight(UserRights.Neuaufnahme);
            RefreshList();
            dgMain.PerformAction(UltraGridAction.FirstRowInGrid);
            UpdateButtons();
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
                    if (txtSearch != null) txtSearch.Dispose();
                    if (lblSuchbegriff != null) lblSuchbegriff.Dispose();
                    if (btnCancel != null) btnCancel.Dispose();
                    if (btnOK != null) btnOK.Dispose();
                    if (btnNeuaufnahme != null) btnNeuaufnahme.Dispose();
                    if (btnHistorie != null) btnHistorie.Dispose();
                    if (labInfo != null) labInfo.Dispose();
                    if (dgMain != null) dgMain.Dispose();
                    if (splitContainer1 != null) splitContainer1.Dispose();
                    if (splitContainer2 != null) splitContainer2.Dispose();
                    if (dsPatientNichtAufgenommen1 != null) dsPatientNichtAufgenommen1.Dispose();
                    components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientAufnahme));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Patient", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nachname", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Geburtsdatum", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Sexus");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSuchbegriff = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnNeuaufnahme = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnHistorie = new QS2.Desktop.ControlManagment.BaseButton();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientNichtAufgenommen1 = new PMDS.Global.db.Patient.dsPatientNichtAufgenommen();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientNichtAufgenommen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(626, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Klientenaufnahme ...";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(151, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(468, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ValueChanged += new System.EventHandler(this.ctrlValueChanged);
            // 
            // lblSuchbegriff
            // 
            this.lblSuchbegriff.AutoSize = true;
            this.lblSuchbegriff.Location = new System.Drawing.Point(3, 3);
            this.lblSuchbegriff.Name = "lblSuchbegriff";
            this.lblSuchbegriff.Size = new System.Drawing.Size(142, 14);
            this.lblSuchbegriff.TabIndex = 1;
            this.lblSuchbegriff.Text = "Suchbegriff, min. 3 Zeichen";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(437, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(531, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNeuaufnahme
            // 
            this.btnNeuaufnahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNeuaufnahme.AutoWorkLayout = false;
            this.btnNeuaufnahme.IsStandardControl = false;
            this.btnNeuaufnahme.Location = new System.Drawing.Point(3, 8);
            this.btnNeuaufnahme.Name = "btnNeuaufnahme";
            this.btnNeuaufnahme.Size = new System.Drawing.Size(88, 32);
            this.btnNeuaufnahme.TabIndex = 5;
            this.btnNeuaufnahme.Text = "Neuaufnahme";
            this.btnNeuaufnahme.Click += new System.EventHandler(this.btnNeuaufnahme_Click);
            // 
            // btnHistorie
            // 
            this.btnHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistorie.AutoWorkLayout = false;
            this.btnHistorie.IsStandardControl = false;
            this.btnHistorie.Location = new System.Drawing.Point(97, 8);
            this.btnHistorie.Name = "btnHistorie";
            this.btnHistorie.Size = new System.Drawing.Size(88, 32);
            this.btnHistorie.TabIndex = 4;
            this.btnHistorie.Text = "Historie";
            this.btnHistorie.Click += new System.EventHandler(this.btnHistorie_Click);
            // 
            // dgMain
            // 
            this.dgMain.AutoWork = true;
            this.dgMain.DataMember = "Patient";
            this.dgMain.DataSource = this.dsPatientNichtAufgenommen1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgMain.DisplayLayout.Appearance = appearance4;
            ultraGridColumn110.Header.Editor = null;
            ultraGridColumn110.Header.VisiblePosition = 0;
            ultraGridColumn110.Hidden = true;
            ultraGridColumn111.Header.Editor = null;
            ultraGridColumn111.Header.VisiblePosition = 1;
            ultraGridColumn111.Width = 136;
            ultraGridColumn112.Header.Editor = null;
            ultraGridColumn112.Header.VisiblePosition = 2;
            ultraGridColumn112.Width = 136;
            ultraGridColumn113.Header.Editor = null;
            ultraGridColumn113.Header.VisiblePosition = 3;
            ultraGridColumn113.Width = 107;
            ultraGridColumn114.Header.Caption = "Geschlecht";
            ultraGridColumn114.Header.Editor = null;
            ultraGridColumn114.Header.VisiblePosition = 4;
            ultraGridColumn114.Width = 145;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn110,
            ultraGridColumn111,
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114});
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.dgMain.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.dgMain.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance11;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance14;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgMain.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(626, 475);
            this.dgMain.TabIndex = 1;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgMain_AfterSelectChange);
            // 
            // dsPatientNichtAufgenommen1
            // 
            this.dsPatientNichtAufgenommen1.DataSetName = "dsPatientNichtAufgenommen";
            this.dsPatientNichtAufgenommen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblSuchbegriff);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 557);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnNeuaufnahme);
            this.splitContainer2.Panel2.Controls.Add(this.btnOK);
            this.splitContainer2.Panel2.Controls.Add(this.btnHistorie);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer2.Size = new System.Drawing.Size(626, 522);
            this.splitContainer2.SplitterDistance = 475;
            this.splitContainer2.TabIndex = 0;
            // 
            // frmPatientAufnahme
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 605);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 584);
            this.Name = "frmPatientAufnahme";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Klientenaufnahme ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientAufnahme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientNichtAufgenommen1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Buttons aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateButtons()
		{
            bool bRow = UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, true).Length > 0;

			btnOK.Enabled				= 	bRow;
			btnHistorie.Enabled	= bRow;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bei Änderung neuAufbau
		/// </summary>
		//----------------------------------------------------------------------------
		private void ctrlValueChanged(object sender, System.EventArgs e)
		{
			RefreshFilter();
		}

        private void RefreshFilter()
        {
            dgMain.BeginUpdate();
            dgMain.Rows.ColumnFilters.ClearAllFilters();
            dgMain.Rows.ColumnFilters["Nachname"].FilterConditions.Add(FilterComparisionOperator.Like, "*" + txtSearch.Text + "*");
            dgMain.PerformAction(UltraGridAction.FirstRowInGrid);
            dgMain.EndUpdate();
            UpdateButtons();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liste aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshList()
		{
            //dgMain.DataMember = "";
            dgMain.DataSource = Patient.GetAlleNichtAufgenommenen();
            if (dgMain.Rows.Count > 0)
                dgMain.ActiveRow = dgMain.Rows[0];

            dgMain.Refresh();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktuelle Datenzeile ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		private dsPatientNichtAufgenommen.PatientRow CurrentRow
		{
			get
			{
				object o = UltraGridTools.CurrentSelectedRow(dgMain);
                if (o != null)
                    return (dsPatientNichtAufgenommen.PatientRow)o;
                return null;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
            // Fehler von Infragistics
            // Obwohl Butten.Enabled = false -> 
            // kann AccaptButton ausgeführt werden
            if (!btnOK.Enabled)
                return;

            if (!GuiAction.PatientAufnahme(CurrentRow.ID))
                return;

            _canClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
            this.Dispose(true);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Patient Aufnahme
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucPatientPicker1_DoubleClick(object sender, System.EventArgs e)
		{
			btnOK_Click(sender, e);

			DialogResult = btnOK.DialogResult;
			Close();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Patient NeuAufnahme
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnNeuaufnahme_Click(object sender, System.EventArgs e)
		{
            if (GuiAction.PatientNeuAufnahme())
            {
                _canClose = true;
                DialogResult = btnOK.DialogResult;
                Close();
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Historie anzeigen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnHistorie_Click(object sender, System.EventArgs e)
		{
			GuiAction.PatientAufenthaltInfo(CurrentRow.ID);
		}



        private void dgMain_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            UpdateButtons();
        }

        

        
	}
}
