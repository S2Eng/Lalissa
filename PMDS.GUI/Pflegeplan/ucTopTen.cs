//----------------------------------------------------------------------------
/// <summary>
///	ucTopTen.cs
/// Erstellt am:	5.10.2004
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{



    public class ucTopTen : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler infoChanged;
        private bool _ContentChanged = false;
        private PDx _PDx;
        private QS2.Desktop.ControlManagment.BasePanel ucPdx_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucPdx_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucPdx_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucPdx_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucPdx_Toolbars_Dock_Area_Bottom;
        private dsPDx dsPDx1;
        private QS2.Desktop.ControlManagment.BasePanel pnlPdxSearch;
        private dsIDTextBezeichnung dsIDTextBezeichnung1;
        private PMDS.GUI.ucButton btnDel;
        private QS2.Desktop.ControlManagment.BaseGrid dgPDXEntfern;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpFavoritenZugeordnetPDX;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private PMDS.GUI.AbteilungsAuswahlCombo cbAbteilung;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private QS2.Desktop.ControlManagment.BaseLableWin lblAbteilungsauwahl;
        private dsPDxGruppe dsPDxGruppe1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblFavoritenauswahl;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbTopTen;
        private QS2.Desktop.ControlManagment.BasePanel pnlButton;
        private PMDS.GUI.ucButton btnSave;
        private PMDS.GUI.ucButton btnUndo;
        private System.ComponentModel.IContainer components;

        private Guid _aktuellAbteilung;
        private ucButton btnDelete;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseButton btnUmbenennen;
        private QS2.Desktop.ControlManagment.BaseButton ultraButton1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblReihenfolge;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtReihenfolge;
        private Guid _aktuellTop;
       

        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucTopTen()
        {

            try
            {
                InitializeComponent();
                _PDx = new PDx();

                for (int i = 0; i < cbAbteilung.Rows.Count; i++)
                {
                    if ((cbAbteilung.Rows[i].Cells[0].Value).Equals(ENV.ABTEILUNG))
                        cbAbteilung.SelectedRow = cbAbteilung.Rows[i];
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }



        //----------------------------------------------------------------------------
        /// <summary> 
        /// Dispose
        /// </summary>
        //----------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public bool CONTENT_CHANGED
        {
            get
            {
                return _ContentChanged;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTopTen));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Table", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            this.ucPdx_Fill_Panel = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlPdxSearch = new QS2.Desktop.ControlManagment.BasePanel();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpFavoritenZugeordnetPDX = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.dgPDXEntfern = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsIDTextBezeichnung1 = new dsIDTextBezeichnung();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.pnlButton = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraButton1 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUmbenennen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblReihenfolge = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.txtReihenfolge = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblFavoritenauswahl = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblAbteilungsauwahl = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.cbAbteilung = new PMDS.GUI.AbteilungsAuswahlCombo();
            this.cbTopTen = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsPDxGruppe1 = new dsPDxGruppe();
            this._ucPdx_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucPdx_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucPdx_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucPdx_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.dsPDx1 = new dsPDx();
            this.ucPdx_Fill_Panel.SuspendLayout();
            this.pnlPdxSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpFavoritenZugeordnetPDX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPDXEntfern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTopTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxGruppe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucPdx_Fill_Panel
            // 
            this.ucPdx_Fill_Panel.Controls.Add(this.pnlPdxSearch);
            this.ucPdx_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucPdx_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPdx_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.ucPdx_Fill_Panel.Name = "ucPdx_Fill_Panel";
            this.ucPdx_Fill_Panel.Size = new System.Drawing.Size(517, 624);
            this.ucPdx_Fill_Panel.TabIndex = 0;
            this.ucPdx_Fill_Panel.TabStop = true;
            // 
            // pnlPdxSearch
            // 
            this.pnlPdxSearch.Controls.Add(this.panel1);
            this.pnlPdxSearch.Controls.Add(this.pnlButton);
            this.pnlPdxSearch.Controls.Add(this.panel3);
            this.pnlPdxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPdxSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlPdxSearch.Name = "pnlPdxSearch";
            this.pnlPdxSearch.Size = new System.Drawing.Size(517, 624);
            this.pnlPdxSearch.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpFavoritenZugeordnetPDX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 484);
            this.panel1.TabIndex = 15;
            // 
            // grpFavoritenZugeordnetPDX
            // 
            this.grpFavoritenZugeordnetPDX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFavoritenZugeordnetPDX.Controls.Add(this.btnSave);
            this.grpFavoritenZugeordnetPDX.Controls.Add(this.btnUndo);
            this.grpFavoritenZugeordnetPDX.Controls.Add(this.dgPDXEntfern);
            this.grpFavoritenZugeordnetPDX.Controls.Add(this.btnDel);
            this.grpFavoritenZugeordnetPDX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFavoritenZugeordnetPDX.Location = new System.Drawing.Point(8, 8);
            this.grpFavoritenZugeordnetPDX.Name = "grpFavoritenZugeordnetPDX";
            this.grpFavoritenZugeordnetPDX.Size = new System.Drawing.Size(497, 456);
            this.grpFavoritenZugeordnetPDX.TabIndex = 13;
            this.grpFavoritenZugeordnetPDX.TabStop = false;
            this.grpFavoritenZugeordnetPDX.Text = "Zu Favoriten zugeordnete PDX";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance1;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(389, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(285, 416);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 13;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // dgPDXEntfern
            // 
            this.dgPDXEntfern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPDXEntfern.AutoWork = true;
            this.dgPDXEntfern.DataSource = this.dsIDTextBezeichnung1._Table;
            this.dgPDXEntfern.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgPDXEntfern.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Pflegediagnose";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(381, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.Caption = "Beschreibung";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.DataType = typeof(bool);
            ultraGridColumn4.DefaultCellValue = false;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(59, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgPDXEntfern.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgPDXEntfern.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgPDXEntfern.DisplayLayout.MaxColScrollRegions = 1;
            this.dgPDXEntfern.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.dgPDXEntfern.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgPDXEntfern.DisplayLayout.Override.NullText = "";
            this.dgPDXEntfern.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgPDXEntfern.Location = new System.Drawing.Point(8, 24);
            this.dgPDXEntfern.Name = "dgPDXEntfern";
            this.dgPDXEntfern.Size = new System.Drawing.Size(477, 384);
            this.dgPDXEntfern.TabIndex = 10;
            this.dgPDXEntfern.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            this.dgPDXEntfern.Click += new System.EventHandler(this.dgPDXEntfern_Click);
            // 
            // dsIDTextBezeichnung1
            // 
            this.dsIDTextBezeichnung1.DataSetName = "dsIDTextBezeichnung";
            this.dsIDTextBezeichnung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsIDTextBezeichnung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.Enabled = false;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(8, 416);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(242, 32);
            this.btnDel.TabIndex = 12;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.ultraButton1);
            this.pnlButton.Controls.Add(this.btnUmbenennen);
            this.pnlButton.Controls.Add(this.btnDelete);
            this.pnlButton.Controls.Add(this.btnAdd);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 580);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(517, 44);
            this.pnlButton.TabIndex = 20;
            // 
            // ultraButton1
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.ultraButton1.Appearance = appearance4;
            this.ultraButton1.AutoWorkLayout = false;
            this.ultraButton1.Enabled = false;
            this.ultraButton1.IsStandardControl = false;
            this.ultraButton1.Location = new System.Drawing.Point(301, 3);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(108, 32);
            this.ultraButton1.TabIndex = 18;
            this.ultraButton1.Text = "PDX zuordnen";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnUmbenennen
            // 
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnUmbenennen.Appearance = appearance5;
            this.btnUmbenennen.AutoWorkLayout = false;
            this.btnUmbenennen.Enabled = false;
            this.btnUmbenennen.IsStandardControl = false;
            this.btnUmbenennen.Location = new System.Drawing.Point(202, 3);
            this.btnUmbenennen.Name = "btnUmbenennen";
            this.btnUmbenennen.Size = new System.Drawing.Size(98, 32);
            this.btnUmbenennen.TabIndex = 17;
            this.btnUmbenennen.Text = "Umbenennen";
            this.btnUmbenennen.Click += new System.EventHandler(this.btnUmbenennen_Click);
            // 
            // btnDelete
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance6;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(105, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 32);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Entfernen";
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance7;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblReihenfolge);
            this.panel3.Controls.Add(this.txtReihenfolge);
            this.panel3.Controls.Add(this.lblFavoritenauswahl);
            this.panel3.Controls.Add(this.lblAbteilungsauwahl);
            this.panel3.Controls.Add(this.cbAbteilung);
            this.panel3.Controls.Add(this.cbTopTen);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 96);
            this.panel3.TabIndex = 18;
            // 
            // lblReihenfolge
            // 
            this.lblReihenfolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblReihenfolge.Location = new System.Drawing.Point(358, 48);
            this.lblReihenfolge.Name = "lblReihenfolge";
            this.lblReihenfolge.Size = new System.Drawing.Size(71, 23);
            this.lblReihenfolge.TabIndex = 9;
            this.lblReihenfolge.Text = "Reihenfolge :";
            this.lblReihenfolge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReihenfolge
            // 
            appearance8.BackColorDisabled = System.Drawing.Color.White;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtReihenfolge.Appearance = appearance8;
            this.txtReihenfolge.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtReihenfolge.Enabled = false;
            this.txtReihenfolge.InputMask = "           nnnnn";
            this.txtReihenfolge.Location = new System.Drawing.Point(433, 50);
            this.txtReihenfolge.Name = "txtReihenfolge";
            this.txtReihenfolge.NonAutoSizeHeight = 20;
            this.txtReihenfolge.Size = new System.Drawing.Size(72, 20);
            this.txtReihenfolge.TabIndex = 5;
            this.txtReihenfolge.Text = "           ";
            this.txtReihenfolge.TextChanged += new System.EventHandler(this.txtReihenfolge_TextChanged);
            // 
            // lblFavoritenauswahl
            // 
            this.lblFavoritenauswahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFavoritenauswahl.Location = new System.Drawing.Point(16, 48);
            this.lblFavoritenauswahl.Name = "lblFavoritenauswahl";
            this.lblFavoritenauswahl.Size = new System.Drawing.Size(112, 23);
            this.lblFavoritenauswahl.TabIndex = 8;
            this.lblFavoritenauswahl.Text = "Favoritenauswahl :";
            this.lblFavoritenauswahl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAbteilungsauwahl
            // 
            this.lblAbteilungsauwahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbteilungsauwahl.Location = new System.Drawing.Point(16, 16);
            this.lblAbteilungsauwahl.Name = "lblAbteilungsauwahl";
            this.lblAbteilungsauwahl.Size = new System.Drawing.Size(112, 23);
            this.lblAbteilungsauwahl.TabIndex = 7;
            this.lblAbteilungsauwahl.Text = "Abteilungsauswahl :";
            this.lblAbteilungsauwahl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.AutoSize = false;
            ultraGridBand2.ColHeadersVisible = false;
            ultraGridColumn26.Header.VisiblePosition = 0;
            ultraGridColumn27.Header.VisiblePosition = 1;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.VisiblePosition = 2;
            ultraGridColumn28.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28});
            ultraGridBand2.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand2.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand3.ColHeadersVisible = false;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Hidden = true;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand3.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand3.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand3.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand4.ColHeadersVisible = false;
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn9.Header.VisiblePosition = 1;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 2;
            ultraGridColumn10.Hidden = true;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            ultraGridBand4.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand4.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand4.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand5.ColHeadersVisible = false;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.Hidden = true;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            ultraGridBand5.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand5.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand5.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand6.ColHeadersVisible = false;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.Hidden = true;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand6.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand6.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand6.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand7.ColHeadersVisible = false;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn19.Hidden = true;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            ultraGridBand7.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand7.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand7.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand8.ColHeadersVisible = false;
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn21.Header.VisiblePosition = 1;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 2;
            ultraGridColumn22.Hidden = true;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
            ultraGridBand8.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand8.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand8.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand9.ColHeadersVisible = false;
            ultraGridColumn23.Header.VisiblePosition = 0;
            ultraGridColumn24.Header.VisiblePosition = 1;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.VisiblePosition = 2;
            ultraGridColumn25.Hidden = true;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
            ultraGridBand9.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand9.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand9.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand10.AddButtonCaption = "Abteilung";
            ultraGridBand10.ColHeadersVisible = false;
            ultraGridBand10.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand10.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand10.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.cbAbteilung.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbAbteilung.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.cbAbteilung.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.cbAbteilung.DisplayMember = "Bezeichnung";
            this.cbAbteilung.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbAbteilung.Location = new System.Drawing.Point(136, 16);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(200, 21);
            this.cbAbteilung.TabIndex = 4;
            this.cbAbteilung.ValueMember = "ID";
            this.cbAbteilung.RowSelected += new Infragistics.Win.UltraWinGrid.RowSelectedEventHandler(this.cbAbteilung_RowSelected);
            // 
            // cbTopTen
            // 
            this.cbTopTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsPDxGruppe1, "PDXGruppe.Bezeichnung", true));
            this.cbTopTen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dsPDxGruppe1, "PDXGruppe.ID", true));
            this.cbTopTen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbTopTen.Location = new System.Drawing.Point(136, 48);
            this.cbTopTen.Name = "cbTopTen";
            this.cbTopTen.Nullable = false;
            this.cbTopTen.Size = new System.Drawing.Size(200, 21);
            this.cbTopTen.TabIndex = 5;
            this.cbTopTen.SelectionChanged += new System.EventHandler(this.cbTopTen_SelectionChanged);
            this.cbTopTen.ValueChanged += new System.EventHandler(this.cbTopTen_ValueChanged);
            this.cbTopTen.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.ultraComboEditor1_EditorButtonClick);
            // 
            // dsPDxGruppe1
            // 
            this.dsPDxGruppe1.DataSetName = "dsPDxGruppe";
            this.dsPDxGruppe1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _ucPdx_Toolbars_Dock_Area_Left
            // 
            this._ucPdx_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucPdx_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ucPdx_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucPdx_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._ucPdx_Toolbars_Dock_Area_Left.Name = "_ucPdx_Toolbars_Dock_Area_Left";
            this._ucPdx_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 624);
            // 
            // _ucPdx_Toolbars_Dock_Area_Right
            // 
            this._ucPdx_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucPdx_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ucPdx_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucPdx_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(517, 0);
            this._ucPdx_Toolbars_Dock_Area_Right.Name = "_ucPdx_Toolbars_Dock_Area_Right";
            this._ucPdx_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 624);
            // 
            // _ucPdx_Toolbars_Dock_Area_Top
            // 
            this._ucPdx_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucPdx_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ucPdx_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucPdx_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ucPdx_Toolbars_Dock_Area_Top.Name = "_ucPdx_Toolbars_Dock_Area_Top";
            this._ucPdx_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(517, 0);
            // 
            // _ucPdx_Toolbars_Dock_Area_Bottom
            // 
            this._ucPdx_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucPdx_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ucPdx_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucPdx_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 624);
            this._ucPdx_Toolbars_Dock_Area_Bottom.Name = "_ucPdx_Toolbars_Dock_Area_Bottom";
            this._ucPdx_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(517, 0);
            // 
            // dsPDx1
            // 
            this.dsPDx1.DataSetName = "dsPDx";
            this.dsPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucTopTen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucPdx_Fill_Panel);
            this.Controls.Add(this._ucPdx_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ucPdx_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ucPdx_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._ucPdx_Toolbars_Dock_Area_Bottom);
            this.Name = "ucTopTen";
            this.Size = new System.Drawing.Size(517, 624);
            this.Load += new System.EventHandler(this.ucPdx_Load);
            this.ucPdx_Fill_Panel.ResumeLayout(false);
            this.pnlPdxSearch.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpFavoritenZugeordnetPDX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPDXEntfern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTopTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxGruppe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Load Event
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPdx_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (this.DesignMode)
                    return;

                oninfoChanged();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Fügt eine neue Pdx ein (Wird automatisch in der DB aktualisiert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessAddNew()
        {
            RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
            frm.Text = ENV.String("DIALOGTITLE_NEWTOPTENGROP");
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK || frm.TEXT.Length < 1)
                return;

            bool found = false;
            Guid ID = Guid.NewGuid();
            foreach (ValueListItem i in cbTopTen.Items)
                if (i.DisplayText.Trim().Equals(frm.TEXT.Trim()))
                {
                    
                    found = true;
                }

            if (!found)
            {
                _PDx.PdxGruppeToDB(ID, cbAbteilung.ABTEILUNG, frm.TEXT, cbTopTen.Items.Count+1, false);

                cbTopTen.Items.Add(ID, frm.TEXT);
                cbTopTen.Value = (object)ID;
                //foreach(ValueListItem i in cbTopTen.Items)
                //{

                //    if(i.DataValue.Equals(ID))
                //        cbTopTen.SelectedItem = i;
                //}

                dgPDXEntfern.DataSource = _PDx.GetPDxFromPDxGruppeID((Guid)cbTopTen.Value);

                this.btnDelete.Enabled = true;
                this.btnUmbenennen.Enabled = true;
                //this.ultraButton1.Enabled = true;

                txtReihenfolge.Value = cbTopTen.Items.Count;
               

            }


        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisierungsverarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessRefresh()
        {
            _ContentChanged = false;
        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Löschen Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessDelete()
        {
            if (cbTopTen.Items.Count == 0)
            {
                return;
            }

            if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEPDXGRUPPE", cbTopTen.Text), ENV.String("DIALOGTITLE_DELETEPDXGRUPPE"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true) != DialogResult.Yes)
                return;


            _PDx.PdxGruppeToDB((Guid)cbTopTen.Value, cbAbteilung.ABTEILUNG, cbTopTen.Text, cbTopTen.SelectedIndex, true);

            RefreshcbTopTen();
            RefreshdgPDXEntfern();

            btnUndo.Enabled = false;
            btnSave.Enabled = false;

            this.btnDelete.Enabled = false;
            this.btnUmbenennen.Enabled = false;
            this.ultraButton1.Enabled = false;
            this.txtReihenfolge.Enabled = false;

        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Zuordnen der ausgewählten zu der aktuell ausgewählten PDx
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessAssign(UltraGridRow[] rc)
        {

            int c = 0;

            foreach (UltraGridRow r in rc)												// alle Selektierten
            {
                c = insert((Guid)r.Cells["ID"].Value, r.Cells["Klartext"].Value.ToString(), r.Cells["Definition"].Value.ToString());
            }

            if (c > 0)
            {
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
                _ContentChanged = true;

            }

        }


        private int insert(Guid ID, string Klartext, string Definition)
        {
            int i = 0;
            bool found = false;
            foreach (UltraGridRow rr in dgPDXEntfern.Rows)
            {
                if (ID.Equals(rr.Cells["ID"].Value))
                {
                    found = true;
                    break;
                }
            }

            if (found == false)										// Nicht gefunden also einfügen
            {
                i++;
                UltraGridRow addRow = dgPDXEntfern.DisplayLayout.Bands[0].AddNew();

                addRow.Cells["ID"].Value = ID;
                addRow.Cells["Text"].Value = Klartext;
                addRow.Cells["Bezeichnung"].Value = Definition;
            }
            return i;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Externer Zugriff aus Speichern
        /// </summary>
        //----------------------------------------------------------------------------
        public void Save()
        {
            ProcessSave();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Änderungen speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSave()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgPDXEntfern.Rows)			// Die einzelnen IDs als Array zusammenbauen
                al.Add((Guid)r.Cells["ID"].Value);

            _PDx.UpdatePDXGruppenEintrag((Guid[])al.ToArray(typeof(Guid)), _aktuellTop);

            _PDx.PdxGruppeToDB(_aktuellTop,cbAbteilung.ABTEILUNG, cbTopTen.Text ,(int)txtReihenfolge.Value,false);

            _aktuellAbteilung = cbAbteilung.ABTEILUNG;
            _aktuellTop = (Guid)cbTopTen.Value;


        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bearbeiten der aktuell selektierten PDx
        /// </summary>
        //----------------------------------------------------------------------------
        private void EditAvtivePDX()
        {
            if (cbTopTen.Text.ToString().Length < 1)
            {
                return;
            }

            int activeindex = cbTopTen.SelectedIndex;

            RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
            frm.TEXT = cbTopTen.Text;
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            _PDx.PdxGruppeToDB((Guid)cbTopTen.Value, cbAbteilung.ABTEILUNG, frm.TEXT, (int)txtReihenfolge.Value, false);
            RefreshcbTopTen();
            cbTopTen.SelectedItem = cbTopTen.Items[activeindex];

        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Abteilung ausgewählt
        /// </summary>
        //----------------------------------------------------------------------------
        private void cbAbteilung_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {


            if (btnSave.Enabled == true)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question, true);          
                if (res == DialogResult.No)
                {

                    _ContentChanged = false;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    dgPDXEntfern.DataSource = _PDx.GetPDxFromPDxGruppeID((Guid)cbTopTen.Value);


                }
                if (res == DialogResult.Yes)
                    ProcessSave();
            }
            _ContentChanged = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;


            RefreshcbTopTen();
            dgPDXEntfern.DataSource = dsIDTextBezeichnung1._Table;


            if (cbTopTen.Value == null)
            {
                this.btnDelete.Enabled = false;
                this.btnUmbenennen.Enabled = false;
                this.btnAdd.Enabled = true;
                this.ultraButton1.Enabled = false;
                this.btnDel.Enabled = false;
                this.txtReihenfolge.Enabled = false;
            }

            else
            {
                this.btnDelete.Enabled = true;
                this.btnUmbenennen.Enabled = true;
                this.btnAdd.Enabled = true;
                this.ultraButton1.Enabled = true;
                this.txtReihenfolge.Enabled = true;

            }


        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Combo neu befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshcbTopTen()
        {
            foreach (ValueListItem i in cbTopTen.Items)
                cbTopTen.Items.Remove(i);

            foreach (dsPDxGruppe.PDXGruppeRow r in _PDx.GetAllTopGruppen(cbAbteilung.ABTEILUNG))
            {
                cbTopTen.Items.Add(r.ID, r.Bezeichnung);
            }

            cbTopTen.Items.Clear();

            foreach (dsPDxGruppe.PDXGruppeRow r in _PDx.GetAllTopGruppen(cbAbteilung.ABTEILUNG))
            {
                cbTopTen.Items.Add(r.ID, r.Bezeichnung);
            }

            txtReihenfolge.Value = 0;

        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Löschen Klick verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (cbTopTen.Value == null)
                return;

            int c = 0;
            foreach (UltraGridRow rr in dgPDXEntfern.Rows)
            {
                rr.Selected = false;
                if (rr.Cells["Auswahl"].Value.Equals((bool)true))
                {
                    c++;
                    rr.Selected = true;
                }
            }

            dgPDXEntfern.DeleteSelectedRows(false);
            if (c > 0)
            {
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
                _ContentChanged = true;
            }

            btnDel.Enabled = false;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Fügt eine neue Pdx ein (Wird automatisch in der DB aktualisiert
        /// </summary>
        //----------------------------------------------------------------------------
        protected void oninfoChanged()
        {
            if (infoChanged != null)
                infoChanged(this, null);
        }

        private void ultraComboEditor1_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnAdd")
            {
                ProcessAddNew();
            }

            if (e.Button.Key == "btnDel")
            {
                if (cbTopTen.Value == null)
                    return;

                else
                {
                    ProcessDelete();
                    RefreshdgPDXEntfern();
                }

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// DataGrid dgPDXEntfern neu befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshdgPDXEntfern()
        {
            if (cbTopTen.Value != null)
            {
                dgPDXEntfern.DataSource = _PDx.GetPDxFromPDxGruppeID((Guid)cbTopTen.Value);
            }

            else
            {
                dgPDXEntfern.DataSource = dsIDTextBezeichnung1._Table;

            }
            btnDel.Enabled = false;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Neue TopTen ausgewählt
        /// </summary>
        //----------------------------------------------------------------------------
        private void cbTopTen_ValueChanged(object sender, EventArgs e)
        {
            if (cbTopTen.Value == null)
            {
                this.btnDelete.Enabled = false;
                this.btnUmbenennen.Enabled = false;
                //this.btnAdd.Enabled = false;
                this.ultraButton1.Enabled = false;
                this.btnDel.Enabled = false;
                this.txtReihenfolge.Value = 0;
                this.txtReihenfolge.Enabled = false; 
            }

            else
            {
                this.btnDelete.Enabled = true;
                this.btnUmbenennen.Enabled = true;
                this.btnAdd.Enabled = true;
                this.ultraButton1.Enabled = true;
                this.txtReihenfolge.Enabled = true; 
               

            }

            askForSave();


            if (cbTopTen.Value != null)
            {
                RefreshdgPDXEntfern();
                this.txtReihenfolge.Value = _PDx.GetAllTopGruppen(cbAbteilung.ABTEILUNG).FindByID((Guid)cbTopTen.Value).Reihenfolge;
               
                  
            }

            _aktuellAbteilung = cbAbteilung.ABTEILUNG;
            _aktuellTop = (Guid)cbTopTen.Value;

        }

        private void cbTopTen_SelectionChanged(object sender, System.EventArgs e)
        {



        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// btnUudo Klick verarbeiten 
        /// </summary>
        //----------------------------------------------------------------------------

        private void btnUndo_Click(object sender, System.EventArgs e)
        {
            RefreshdgPDXEntfern();
            btnUndo.Enabled = false;
            btnSave.Enabled = false;
            _ContentChanged = false;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            ProcessSave();
            _ContentChanged = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;

        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// "Auswahl" Checkbox setzten oder leeren 
        /// </summary>
        //----------------------------------------------------------------------------

        private void dgPDXEntfern_Click(object sender, System.EventArgs e)
        {

            bool found = false;

            if (dgPDXEntfern.ActiveCell != null)
            {
                if (dgPDXEntfern.ActiveCell == dgPDXEntfern.ActiveRow.Cells["Auswahl"])
                {

                    if ((bool)dgPDXEntfern.ActiveRow.Cells["Auswahl"].Value == false && (dgPDXEntfern.ActiveCell == dgPDXEntfern.ActiveRow.Cells["Auswahl"]))
                        dgPDXEntfern.ActiveRow.Cells["Auswahl"].Value = true;

                    else dgPDXEntfern.ActiveRow.Cells["Auswahl"].Value = false;

                    dgPDXEntfern.ActiveCell = null;

                    foreach (UltraGridRow r in dgPDXEntfern.Rows)
                    {
                        if ((bool)r.Cells["Auswahl"].Value == true)
                        {
                            found = true;
                            break;
                        }
                    }


                    if (found && cbTopTen.Value != null)
                        btnDel.Enabled = true;

                    else btnDel.Enabled = false;
                }
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// ultraExplorerBar1 ItemClick verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------

        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            if (e.Item.Key == "AddTOP")   //neue TopTen
            {

            }
            if (e.Item.Key == "DelTOP")			//Top Gruppe löschen
            {

            }
            if (e.Item.Key == "EditTOP")			//Top Gruppe bearbeiten
            {

            }
            if (e.Item.Key == "AddPDX")			//PDX hinzufügen
            {


            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// GridRow[] von ucAddPDxToTop übergeben
        /// </summary>
        //----------------------------------------------------------------------------	
        private void frm_UpdateZugeordnetGrid(UltraGridRow[] rc)
        {
            ProcessAssign(rc);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// nachfragen ob gespichert werden soll wenn btnSave = enabled
        /// </summary>
        //----------------------------------------------------------------------------	
        private void askForSave()
        {
            if (btnSave.Enabled == true)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question, true);           
                if (res == DialogResult.No)
                {
                    dgPDXEntfern.DataSource = _PDx.GetPDxFromPDxGruppeID((Guid)cbTopTen.Value);

                }
                if (res == DialogResult.Yes)
                    ProcessSave();

                _ContentChanged = false;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                
            }




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            askForSave();
            ProcessDelete();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            askForSave();
            ProcessAddNew();
        }

        private void btnUmbenennen_Click(object sender, EventArgs e)
        {
            askForSave();
            EditAvtivePDX();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            frmAddPDXToTop frm = new frmAddPDXToTop();
            frm.PDXToTOPSelected += new AddSelectedPDXToTOPDelegate(frm_UpdateZugeordnetGrid);

            frm.ShowDialog();
        }

        private void txtReihenfolge_TextChanged(object sender, EventArgs e)
        {
            if (txtReihenfolge.Focused && cbTopTen.Value != null)
                _PDx.PdxGruppeToDB((Guid)cbTopTen.Value, cbAbteilung.ABTEILUNG, cbTopTen.Text, (int)txtReihenfolge.Value, false);
        }
    }
}
