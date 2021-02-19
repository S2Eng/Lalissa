//----------------------------------------------------------------------------
/// <summary>
///	ucAufEntInfo.cs
/// Erstellt am:	12.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.GUI.Engines;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Bearbeitung eines Aufnahme
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucAufEntInfo : QS2.Desktop.ControlManagment.BaseControl
	{

		private Aufenthalt	_aufenthalt;
		private dsAufenthaltVerlauf dsAufenthaltVerlauf1;
        private dsUrlaubVerlauf dsUrlaubVerlauf1;
		private QS2.Desktop.ControlManagment.BaseTabControl ultraTabControlMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl9;
		private QS2.Desktop.ControlManagment.BaseGrid dgUrlaube;
		private QS2.Desktop.ControlManagment.BaseGrid dgVersetzung;
		private PMDS.GUI.ucEntlassung ucEntlassung1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private IContainer components;


		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucAufEntInfo()
		{
			InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;

			Aufenthalt = new Aufenthalt();

			UpdatePages();

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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Versetzungen", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Datum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung");
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UrlaubVerlauf", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EndeDatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer_Erstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer_Geaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            PMDS.BusinessLogic.Aufenthalt aufenthalt1 = new PMDS.BusinessLogic.Aufenthalt();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.dgVersetzung = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAufenthaltVerlauf1 = new dsAufenthaltVerlauf();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.dgUrlaube = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsUrlaubVerlauf1 = new dsUrlaubVerlauf();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucEntlassung1 = new PMDS.GUI.ucEntlassung();
            this.ultraTabControlMain = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVersetzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltVerlauf1)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUrlaube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUrlaubVerlauf1)).BeginInit();
            this.ultraTabPageControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlMain)).BeginInit();
            this.ultraTabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(564, 197);
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.ultraGridBagLayoutPanel2.Controls.Add(this.dgVersetzung);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(564, 197);
            this.ultraGridBagLayoutPanel2.TabIndex = 4;
            // 
            // dgVersetzung
            // 
            this.dgVersetzung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVersetzung.AutoWork = true;
            this.dgVersetzung.DataSource = this.dsAufenthaltVerlauf1.Versetzungen;
            this.dgVersetzung.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.Black;
            this.dgVersetzung.DisplayLayout.Appearance = appearance1;
            this.dgVersetzung.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.MaskInput = "dd.mm.yyyy hh:mm:ss";
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(136, 0);
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(384, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgVersetzung.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgVersetzung.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgVersetzung.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgVersetzung.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgVersetzung.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgVersetzung.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgVersetzung.DisplayLayout.Override.NullText = "";
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.dgVersetzung, gridBagConstraint1);
            this.dgVersetzung.Location = new System.Drawing.Point(0, 0);
            this.dgVersetzung.Name = "dgVersetzung";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.dgVersetzung, new System.Drawing.Size(280, 266));
            this.dgVersetzung.Size = new System.Drawing.Size(564, 197);
            this.dgVersetzung.TabIndex = 3;
            // 
            // dsAufenthaltVerlauf1
            // 
            this.dsAufenthaltVerlauf1.DataSetName = "dsAufenthaltVerlauf";
            this.dsAufenthaltVerlauf1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAufenthaltVerlauf1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(564, 197);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.ultraGridBagLayoutPanel1.Controls.Add(this.dgUrlaube);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(564, 197);
            this.ultraGridBagLayoutPanel1.TabIndex = 5;
            // 
            // dgUrlaube
            // 
            this.dgUrlaube.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUrlaube.AutoWork = true;
            this.dgUrlaube.DataSource = this.dsUrlaubVerlauf1.UrlaubVerlauf;
            this.dgUrlaube.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance2.BackColor = System.Drawing.Color.White;
            this.dgUrlaube.DisplayLayout.Appearance = appearance2;
            this.dgUrlaube.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "Start";
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Ende";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Beschreibung";
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(331, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 5;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 6;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 8;
            ultraGridColumn11.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgUrlaube.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgUrlaube.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgUrlaube.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgUrlaube.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgUrlaube.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgUrlaube.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgUrlaube.DisplayLayout.Override.NullText = "";
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.dgUrlaube, gridBagConstraint2);
            this.dgUrlaube.Location = new System.Drawing.Point(0, 0);
            this.dgUrlaube.Name = "dgUrlaube";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.dgUrlaube, new System.Drawing.Size(267, 229));
            this.dgUrlaube.Size = new System.Drawing.Size(564, 197);
            this.dgUrlaube.TabIndex = 4;
            // 
            // dsUrlaubVerlauf1
            // 
            this.dsUrlaubVerlauf1.DataSetName = "dsUrlaubVerlauf";
            this.dsUrlaubVerlauf1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsUrlaubVerlauf1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Controls.Add(this.ucEntlassung1);
            this.ultraTabPageControl9.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(564, 197);
            // 
            // ucEntlassung1
            // 
            aufenthalt1.AufnahmeArt = 0;
            aufenthalt1.Aufnahmezeitpunkt = new System.DateTime(2009, 6, 24, 11, 38, 7, 175);
            aufenthalt1.Ausgleichszahlung = 0D;
            aufenthalt1.BegleitungVon = "";
            aufenthalt1.Bermerkung = "";
            aufenthalt1.Besuchsregelung = "";
            aufenthalt1.Entlassungsbemerkung = "";
            aufenthalt1.Entlassungszeitpunkt = null;
            aufenthalt1.Erwartungen = "";
            aufenthalt1.Fallnummer = 0D;
            aufenthalt1.Gewicht = 0D;
            aufenthalt1.Gruppenkennzahl = "";
            aufenthalt1.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDAbteilung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDAufenthaltVerlauf = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDBenutzer_Aufnahme = new System.Guid("00000000-0000-0000-0000-000000000001");
            aufenthalt1.IDBenutzer_Entlassung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDBereich = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDEinrichtung_Aufnahme = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDEinrichtung_Entlassung = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDErstkontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDKlinik = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDPatient = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.IDUrlaub = new System.Guid("00000000-0000-0000-0000-000000000000");
            aufenthalt1.NaechsteEvaluierung = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.NaechsteEvaluierungBemerkung = "";
            aufenthalt1.Postregelung = "";
            aufenthalt1.PsychischeAuff = "";
            aufenthalt1.SofortMassnahmen = "";
            aufenthalt1.SomatischeAuff = "";
            aufenthalt1.SonstigeBesonderheiten = "";
            aufenthalt1.SonstigeRegelung = "";
            aufenthalt1.TaschegeldVortragDatum = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            aufenthalt1.TaschengeldSollstand = 0D;
            aufenthalt1.TaschengeldVortragBetrag = 0D;
            aufenthalt1.Verfuegungsdatum = null;
            aufenthalt1.VerhaltenAufnahme = "";
            this.ucEntlassung1.Aufenthalt = aufenthalt1;
            this.ucEntlassung1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucEntlassung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEntlassung1.Location = new System.Drawing.Point(0, 0);
            this.ucEntlassung1.Name = "ucEntlassung1";
            this.ucEntlassung1.ReadOnly = false;
            this.ucEntlassung1.Size = new System.Drawing.Size(564, 197);
            this.ucEntlassung1.TabIndex = 6;
            // 
            // ultraTabControlMain
            // 
            this.ultraTabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraTabControlMain.Appearance = appearance3;
            this.ultraTabControlMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControlMain.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControlMain.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControlMain.Controls.Add(this.ultraTabPageControl9);
            this.ultraTabControlMain.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControlMain.Name = "ultraTabControlMain";
            this.ultraTabControlMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControlMain.Size = new System.Drawing.Size(568, 223);
            this.ultraTabControlMain.TabIndex = 1;
            ultraTab6.Key = "Versetzungsverlauf";
            ultraTab6.TabPage = this.ultraTabPageControl3;
            ultraTab6.Text = "Verlegungsverlauf";
            ultraTab7.Key = "Urlaube";
            ultraTab7.TabPage = this.ultraTabPageControl2;
            ultraTab7.Text = "Abwesenheiten";
            ultraTab5.Key = "Entlassungsdaten";
            ultraTab5.TabPage = this.ultraTabPageControl9;
            ultraTab5.Text = "Entlassungsdaten";
            this.ultraTabControlMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab6,
            ultraTab7,
            ultraTab5});
            this.ultraTabControlMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControlMain.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.ultraTabControl1_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(564, 197);
            // 
            // ucAufEntInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ultraTabControlMain);
            this.Name = "ucAufEntInfo";
            this.Size = new System.Drawing.Size(568, 223);
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVersetzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltVerlauf1)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUrlaube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUrlaubVerlauf1)).EndInit();
            this.ultraTabPageControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlMain)).EndInit();
            this.ultraTabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufenthalt setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Aufenthalt Aufenthalt
		{
			get	
			{	
				return _aufenthalt;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Aufenthalt");

				_aufenthalt = value;
				UpdateGUI();
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control alle Elemente sperren/zugänglich machen
		/// </summary>
		//----------------------------------------------------------------------------
		private void EnableCtrl(UserControl ctrl, bool bEnabled)
		{
			// sollte nur ReadOnly sein
			if (ctrl is IReadOnly)
				((IReadOnly)ctrl).ReadOnly = !bEnabled;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// einzelne Reiter anzeigen oder verstecken
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdatePages()
		{

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{

				ucEntlassung1.Aufenthalt = Aufenthalt;


				dgVersetzung.DataSource = AufenthaltVerlauf.VersetzungByAufenthalt(Aufenthalt.ID);
				dgUrlaube.DataSource = UrlaubVerlauf.ByAufenthalt(Aufenthalt.ID);

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{

				ucEntlassung1.UpdateDATA();
		}


        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zusatzwerte speichern
		/// </summary>
		//----------------------------------------------------------------------------

	}
}
