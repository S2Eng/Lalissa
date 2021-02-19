using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;



namespace PMDS.Calc.UI.Admin
{



    public class ucSonderleistungsKatalog : QS2.Desktop.ControlManagment.BaseControl, ISave, IRefresh
	{

        private SonderleistungsKatalog _katalog = new SonderleistungsKatalog();
        private dsSonderleistungsKatalog.SonderleistungsKatalogDataTable _dt;
        private PatientSonderleistung ps = new PatientSonderleistung();

        public event EventHandler ValueChanged;
        private bool _LeistungChenged = false;
        private System.Collections.ArrayList arrToDelete = new System.Collections.ArrayList();


		private QS2.Desktop.ControlManagment.BasePanel ucPflegegeldstufe_Fill_Panel;
		private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private QS2.Desktop.ControlManagment.BaseLabel lblSonderleistungen;
        private dsSonderleistungsKatalog dsSonderleistungsKatalog1;
        private ErrorProvider errorProvider1;
        private ucButton btnAdd;
        private ucButton btnDel2;
        private GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        private IContainer components;

        public bool isLoaded = false;






        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SonderleistungsKatalog", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Mwst");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FIBU");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSonderleistungsKatalog));
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsSonderleistungsKatalog1 = new PMDS.Abrechnung.Global.dsSonderleistungsKatalog();
            this.ucPflegegeldstufe_Fill_Panel = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel2 = new PMDS.GUI.ucButton(this.components);
            this.lblSonderleistungen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSonderleistungsKatalog1)).BeginInit();
            this.ucPflegegeldstufe_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsSonderleistungsKatalog1.SonderleistungsKatalog;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(223, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance2;
            ultraGridColumn3.Format = "###,###,##0.00";
            ultraGridColumn3.Header.Caption = "Betrag / EH";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{double:-9.2}";
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(106, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance3;
            ultraGridColumn4.Format = "###,###,##0";
            ultraGridColumn4.Header.Caption = "MWSt";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaxValue = 99;
            ultraGridColumn4.MinValue = 0;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn5.Header.Caption = "Einrichtung";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(226, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn6.Header.Caption = "FiBu";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(184, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand1.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.dgMain.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance10;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance13;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(8, 26);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(749, 266);
            this.dgMain.TabIndex = 0;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_AfterRowUpdate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMain_KeyDown);
            // 
            // dsSonderleistungsKatalog1
            // 
            this.dsSonderleistungsKatalog1.DataSetName = "dsSonderleistungsKatalog";
            this.dsSonderleistungsKatalog1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsSonderleistungsKatalog1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucPflegegeldstufe_Fill_Panel
            // 
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.ucKlinikDropDown1);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.btnAdd);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.btnDel2);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.dgMain);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.lblSonderleistungen);
            this.ucPflegegeldstufe_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucPflegegeldstufe_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPflegegeldstufe_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.ucPflegegeldstufe_Fill_Panel.Name = "ucPflegegeldstufe_Fill_Panel";
            this.ucPflegegeldstufe_Fill_Panel.Size = new System.Drawing.Size(765, 300);
            this.ucPflegegeldstufe_Fill_Panel.TabIndex = 0;
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(404, 4);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 164;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance15.TextVAlignAsString = "Middle";
            this.btnAdd.Appearance = appearance15;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(708, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 22);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel2
            // 
            this.btnDel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance16.TextVAlignAsString = "Middle";
            this.btnDel2.Appearance = appearance16;
            this.btnDel2.AutoWorkLayout = false;
            this.btnDel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel2.DoOnClick = true;
            this.btnDel2.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel2.IsStandardControl = true;
            this.btnDel2.Location = new System.Drawing.Point(733, 3);
            this.btnDel2.Name = "btnDel2";
            this.btnDel2.Size = new System.Drawing.Size(25, 22);
            this.btnDel2.TabIndex = 11;
            this.btnDel2.TabStop = false;
            this.btnDel2.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel2.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel2.Click += new System.EventHandler(this.btnDel2_Click);
            // 
            // lblSonderleistungen
            // 
            this.lblSonderleistungen.Location = new System.Drawing.Point(8, 7);
            this.lblSonderleistungen.Name = "lblSonderleistungen";
            this.lblSonderleistungen.Size = new System.Drawing.Size(148, 15);
            this.lblSonderleistungen.TabIndex = 6;
            this.lblSonderleistungen.Text = "Sonderleistungsvorlagen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucSonderleistungsKatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucPflegegeldstufe_Fill_Panel);
            this.Name = "ucSonderleistungsKatalog";
            this.Size = new System.Drawing.Size(765, 300);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSonderleistungsKatalog1)).EndInit();
            this.ucPflegegeldstufe_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        
		public ucSonderleistungsKatalog()
		{
			InitializeComponent();
			if(System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
				return;
		}

        public void initControl()
        {
            if (this.isLoaded)
                return;

            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();
            RefreshControl();

            this.isLoaded = true;
        }

        public bool Save()
		{
            try
            {
                if (!ValidateFields())
                    return false;

                //foreach (System.Guid  id  in arrToDelete)
                //    ps.deletePatientSonderleistung(id);

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                _katalog.Update(_dt);

                if (_LeistungChenged)
                {
                    _LeistungChenged = false;
                }
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
		}
        public void Undo()
        {
            _LeistungChenged = false;
            RefreshControl();
        }

        public bool IsChanged { get { return _LeistungChenged; } }
        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow row in dgMain.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (!ValidateField(cell))
                    {
                        bError = true;
                        break;
                    }
                }

                if (bError) break;
            }

            return !bError;
        }

        public void RefreshControl()
        {
            this.arrToDelete.Clear();
            _dt = _katalog.Read();
            _dt.BezeichnungColumn.AllowDBNull = true;
            _dt.BetragColumn.AllowDBNull = true;
            _dt.MwstColumn.AllowDBNull = true;
            dgMain.DataSource = _dt;
        }

        private bool ValidateRow(UltraGridRow r)
        {
            bool bError = false;

            if(r == null || r.ListObject == null)
                return !bError;

            foreach (UltraGridCell cell in r.Cells)
            {
                if (!ValidateField(cell))
                {
                    bError = true;
                    break;
                }
            }

            return !bError;
        }
        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsSonderleistungsKatalog.SonderleistungsKatalogRow r = (dsSonderleistungsKatalog.SonderleistungsKatalogRow)v.Row;
            dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt = (dsSonderleistungsKatalog.SonderleistungsKatalogDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");
            string error = "";

            if (cell.Column.Key == dt.BezeichnungColumn.ColumnName)
            {

                GuiUtil.ValidateField(dgMain, (cell.Text.Trim() != ""),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                //Doppelte Einträge
                if (!bError)
                {
                    error = "";
                    foreach (UltraGridRow row in dgMain.Rows)
                    {
                        if (row == cell.Row || r.RowState == DataRowState.Unchanged) continue;
                        foreach (UltraGridCell c in row.Cells)
                        {
                            if (c.Column.Key == dt.BezeichnungColumn.ColumnName)
                            {
                                error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Leistungskatalog ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                                GuiUtil.ValidateField(dgMain, c.Text.Trim() != cell.Text.Trim(), error, ref bError, false, null);
                                if (bError)
                                    break;
                            }
                        }
                        if (bError)
                        {
                            r.SetColumnError(dt.BezeichnungColumn.ColumnName, error);
                            break;
                        }
                    }
                }
            }
            else if (cell.Column.Key == dt.BetragColumn.ColumnName || cell.Column.Key == dt.MwstColumn.ColumnName)
            {
                bool valid;

                try
                {
                    valid = cell.EditorResolved.IsValid;
                }
                catch
                {
                    valid = cell.Value.ToString().Trim() != "";
                }

                GuiUtil.ValidateField(dgMain, valid,
                        ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                if (bError)
                {
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
                }
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }

            return !bError;
        }

        private void HandleDelete()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;

            //PatientSonderleistung ps = new PatientSonderleistung();
            dsSonderleistungsKatalog.SonderleistungsKatalogRow rSl;

            DataRowView v;
            //Patient p;
            //bool delete = true;
            StringBuilder sb = new StringBuilder();
            foreach (UltraGridRow row in ra)
            {
                v = (DataRowView)row.ListObject;
                ////delete = true;
                rSl = (dsSonderleistungsKatalog.SonderleistungsKatalogRow)v.Row;
                //ps.deletePatientSonderleistung(rSl.ID);

                //dt = ps.ReadBySonderleistung(rSl.ID);

                //if (dt.Count > 0)
                //{
                //    delete = false;
                //    if (sb.Length > 0) sb.Append(", ");
                //    sb.Append(rSl.Bezeichnung);

                //    //Klienten anzeigen
                //    //if(sb.Length > 0) sb.Append("\n");
                //    //sb.Append("- " + rSl.Bezeichnung + " ist zu folgende Klienten zugeordnet:\n\t");

                //    //foreach(dsPatientSonderleistung.PatientSonderleistungRow pRow in dt)
                //    //{
                //    //    p = new Patient(pRow.IDPatient);
                //    //    if (dt.Rows.IndexOf(pRow) > 0)
                //    //        sb.Append("\n\t");
                //    //    sb.Append("- " + p.FullName);
                //    //}

                //}

                //if (delete)
                //{
                arrToDelete.Add(rSl.ID);
                row.Delete(false);
                _LeistungChenged = true;

                if (ValueChanged != null)
                    ValueChanged(this, null);
                //}
            }

            //if (sb.Length > 0)
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Folgende Sonderleistung(en) (" + sb.ToString() + ") ist(sind) zu Klienten zugeordenet, Daher kann(können) nicht gelöscht werden.", "Sonderleistungen löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
      
        }

        private void dgMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (dgMain.ActiveCell != null && dgMain.ActiveCell.IsInEditMode)
            //            return;
            //        e.Handled = true;
            //    }
            //    HandleDelete();
            //}
        }

        private void dgMain_AfterRowUpdate(object sender, RowEventArgs e)
        {
            _LeistungChenged = true;
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            _LeistungChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        private void btnDel2_Click(object sender, EventArgs e)
        {
            HandleDelete();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _katalog.New(_dt);
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "Bezeichnung");
            _LeistungChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }
	}
}
