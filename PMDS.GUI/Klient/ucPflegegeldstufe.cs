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
using PMDS.Global;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global.ds_abrechnung;




namespace PMDS.Calc.UI.Admin
{


    public class ucPflegegeldstufe : QS2.Desktop.ControlManagment.BaseControl, ISave
	{
        private Pflegegeldstufe _pf = new Pflegegeldstufe();
        private dsPflegegeldstufe _ds;


        public event EventHandler ValueChanged;
        private bool _PflegeStufeChenged = false;
        

        

		private QS2.Desktop.ControlManagment.BasePanel ucPflegegeldstufe_Fill_Panel;
		private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private dsPflegegeldstufe dsPflegegeldstufe1;
		private QS2.Desktop.ControlManagment.BaseLabel lblPflegestufen;
		private QS2.Desktop.ControlManagment.BaseButton btnDel;
		private QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private dsPflegegeldstufe.PflegegeldstufeRow _newRow = null;
        private ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseButton btnAddBetrag;
        private IContainer components;



        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPflegegeldstufe));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Pflegegeldstufe", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StufeNr", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Divisor");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_Pflegegeldstufe_PflegegeldstufeGueltig");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_Pflegegeldstufe_PflegegeldstufeGueltig", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPflegegeldstufe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.ucPflegegeldstufe_Fill_Panel = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAddBetrag = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblPflegestufen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPflegegeldstufe1 = new PMDS.Abrechnung.Global.dsPflegegeldstufe();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucPflegegeldstufe_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegegeldstufe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucPflegegeldstufe_Fill_Panel
            // 
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.btnAddBetrag);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.btnDel);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.btnAdd);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.lblPflegestufen);
            this.ucPflegegeldstufe_Fill_Panel.Controls.Add(this.dgMain);
            this.ucPflegegeldstufe_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucPflegegeldstufe_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPflegegeldstufe_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.ucPflegegeldstufe_Fill_Panel.Name = "ucPflegegeldstufe_Fill_Panel";
            this.ucPflegegeldstufe_Fill_Panel.Size = new System.Drawing.Size(640, 416);
            this.ucPflegegeldstufe_Fill_Panel.TabIndex = 0;
            // 
            // btnAddBetrag
            // 
            this.btnAddBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAddBetrag.Appearance = appearance1;
            this.btnAddBetrag.AutoWorkLayout = false;
            this.btnAddBetrag.Enabled = false;
            this.btnAddBetrag.IsStandardControl = false;
            this.btnAddBetrag.Location = new System.Drawing.Point(315, 8);
            this.btnAddBetrag.Name = "btnAddBetrag";
            this.btnAddBetrag.Size = new System.Drawing.Size(156, 23);
            this.btnAddBetrag.TabIndex = 1;
            this.btnAddBetrag.Text = "Neuen Betrag erfassen";
            this.btnAddBetrag.Click += new System.EventHandler(this.btnAddBetrag_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDel.Appearance = appearance2;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Enabled = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(472, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(161, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Markierte Zeilen löschen";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAdd.Appearance = appearance3;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(127, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(187, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Neu Pflegegeldstufe erfassen";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblPflegestufen
            // 
            this.lblPflegestufen.Location = new System.Drawing.Point(13, 7);
            this.lblPflegestufen.Name = "lblPflegestufen";
            this.lblPflegestufen.Size = new System.Drawing.Size(176, 16);
            this.lblPflegestufen.TabIndex = 6;
            this.lblPflegestufen.Text = "Pflegegeldstufen";
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPflegegeldstufe1.Pflegegeldstufe;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Stufe";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(89, 0);
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(85, 0);
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(232, 0);
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridBand1.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Gültig ab";
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn9.CellAppearance = appearance5;
            ultraGridColumn9.Header.Caption = "Betrag / EH";
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn9.Width = 102;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand2.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.dgMain.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance15;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(14, 34);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(619, 375);
            this.dgMain.TabIndex = 3;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.AfterRowsDeleted += new System.EventHandler(this.dgMain_AfterRowsDeleted);
            this.dgMain.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_AfterRowUpdate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgMain_DoubleClickRow);
            this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMain_KeyDown);
            // 
            // dsPflegegeldstufe1
            // 
            this.dsPflegegeldstufe1.DataSetName = "dsPflegegeldstufe";
            this.dsPflegegeldstufe1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegegeldstufe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPflegegeldstufe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucPflegegeldstufe_Fill_Panel);
            this.Name = "ucPflegegeldstufe";
            this.Size = new System.Drawing.Size(640, 416);
            this.ucPflegegeldstufe_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegegeldstufe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		public ucPflegegeldstufe()
		{
			InitializeComponent();
			if(System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
				return;

            RefreshControl();
		}


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPflegegeldstufe.PflegegeldstufeRow PFLEGEGELDSTUFE_ROW
        {
            get { return _newRow; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Guid ACTIVE_ID
        {
            get
            {
                UltraGridRow r = dgMain.ActiveRow;
                if (r.ParentRow != null)
                    r = r.ParentRow;
                return (Guid)r.Cells["ID"].Value;
            }
        }

 
        public bool Save()
		{
            try
            {
                if (!ValidateFields())
                    return false;
                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                //_pf.Update(_ds, false);
                _pf.Update(_ds);

                if (_PflegeStufeChenged)
                {
                    _PflegeStufeChenged = false;
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
            _PflegeStufeChenged = false;
            RefreshControl();
        }

        public void RefreshControl()
        {
            _ds = _pf.Read();
            dgMain.DataSource = _ds;

            _ds.Pflegegeldstufe.BezeichnungColumn.AllowDBNull = true;
            _ds.Pflegegeldstufe.DivisorColumn.AllowDBNull = true;
            _ds.Pflegegeldstufe.StufeNrColumn.AllowDBNull = true;
            _ds.PflegegeldstufeGueltig.GueltigAbColumn.AllowDBNull = true;
            _ds.PflegegeldstufeGueltig.BetragColumn.AllowDBNull = true;
        }

        public bool IsChanged { get { return _PflegeStufeChenged; } }

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

                if (!bError)
                {
                    foreach (UltraGridChildBand cb in row.ChildBands)
                    {
                        foreach (UltraGridRow r in cb.Rows)
                        {
                            foreach (UltraGridCell c in r.Cells)
                            {
                                if (!ValidateField(c))
                                {
                                    bError = true;
                                    r.ParentRow.ExpandAll();
                                    break;
                                }
                            }

                            if (bError) break;
                        }

                        if (bError) break;
                    }
                }

                if (bError) break;
            }

            return !bError;
        }


        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;

            string colName = "";
            string error = "";
            
            if (v.Row is dsPflegegeldstufe.PflegegeldstufeRow)
            {

                dsPflegegeldstufe.PflegegeldstufeRow r = (dsPflegegeldstufe.PflegegeldstufeRow)v.Row;
                dsPflegegeldstufe.PflegegeldstufeDataTable dt = (dsPflegegeldstufe.PflegegeldstufeDataTable)r.Table;

                
                if (cell.Column.Key == dt.StufeNrColumn.ColumnName ||
                     cell.Column.Key == dt.DivisorColumn.ColumnName
                    )
                {
                    colName = cell.Column.Key;
                    GuiUtil.ValidateField(dgMain, IsValidValue(cell),
                            ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                }
                else if (cell.Column.Key == dt.BezeichnungColumn.ColumnName)
                {
                    colName = cell.Column.Key;
                    GuiUtil.ValidateField(dgMain, (cell.Text.Trim() != ""),
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

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
                                    error = "Die Pflegegeldstufe " + cell.Text.Trim() + " existiert bereits. Bitte ändern";
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
            }
            else
            {
                dsPflegegeldstufe.PflegegeldstufeGueltigRow r = (dsPflegegeldstufe.PflegegeldstufeGueltigRow)v.Row;
                dsPflegegeldstufe.PflegegeldstufeGueltigDataTable dt = (dsPflegegeldstufe.PflegegeldstufeGueltigDataTable)r.Table;
                r.SetColumnError(cell.Column.Key, "");

                if (cell.Column.Key == dt.GueltigAbColumn.ColumnName)
                {
                    colName = cell.Column.Key;
                    DateTime t = new DateTime(1900, 1, 1);
                    GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                    //Doppelte Einträge
                    if (!bError)
                    {
                        error = "";
                        foreach (UltraGridRow row in dgMain.Rows)
                        {
                            if (row != cell.Row.ParentRow) continue;
                            foreach (UltraGridChildBand cb in row.ChildBands)
                            {
                                foreach (UltraGridRow rr in cb.Rows)
                                {
                                    if (rr == cell.Row || r.RowState == DataRowState.Unchanged) continue;
                                    foreach (UltraGridCell c in rr.Cells)
                                    {
                                        if (c.Column.Key == dt.GueltigAbColumn.ColumnName)
                                        {
                                            error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig ab ") + cell.Text.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                                            GuiUtil.ValidateField(dgMain, c.Text.Trim() != cell.Text.Trim(), error, ref bError, false, null);
                                            if (bError)
                                                break;
                                        }
                                    }

                                    if (bError)
                                    {
                                        r.SetColumnError(dt.GueltigAbColumn.ColumnName, error);
                                        break;
                                    }
                                }

                                if (bError)
                                    break;
                            }
                        }
                    }
                }
                else if (cell.Column.Key == dt.BetragColumn.ColumnName)
                {
                    colName = cell.Column.Key;
                    GuiUtil.ValidateField(dgMain, IsValidValue(cell),
                            ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                }
            }

            if (colName != "")
            {
                error = (bError) ? ENV.String("GUI.E_NO_TEXT") : "";
                v.Row.SetColumnError(colName, error);
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

        private bool IsValidValue(UltraGridCell cell)
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

            return valid;
        }

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

        private void ExpandActiveRow()
        {
            if (dgMain.ActiveRow != null)
                dgMain.ActiveRow.ExpandAll();
        }

        private void EnableDisableButtons()
        {
            btnAddBetrag.Enabled = (dgMain.ActiveRow == null) ? false : true;
            btnDel.Enabled = (dgMain.ActiveRow == null) ? false : true;
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

            PatientPflegestufe pPs = new PatientPflegestufe();
            dsPatientPflegestufe.PatientPflegestufeDataTable dt;
            dsPatientPflegestufe.PatientPflegestufeRow[] ppRows;
            dsPflegegeldstufe.PflegegeldstufeRow rPs;
            dsPflegegeldstufe.PflegegeldstufeGueltigRow pgRow;
            DataRowView v;
            //Patient p;
            bool delete = true;
            StringBuilder sb = new StringBuilder();
            string bezeichnung;
            foreach (UltraGridRow row in ra)
            {
                v = (DataRowView)row.ListObject;
                delete = true;
                if (v.Row is dsPflegegeldstufe.PflegegeldstufeRow)
                {
                    rPs = (dsPflegegeldstufe.PflegegeldstufeRow)v.Row;
                    dt = pPs.ReadByPflegestufe(rPs.ID);
                    ppRows = (dsPatientPflegestufe.PatientPflegestufeRow[])dt.Select();
                    bezeichnung = rPs.Bezeichnung;
                }
                else
                {
                    pgRow = (dsPflegegeldstufe.PflegegeldstufeGueltigRow)v.Row;
                    rPs = (dsPflegegeldstufe.PflegegeldstufeRow)((DataRowView)row.ParentRow.ListObject).Row;
                    dt = pPs.ReadByPflegestufe(pgRow.IDPflegegeldstufe);
                    ppRows = (dsPatientPflegestufe.PatientPflegestufeRow[])dt.Select("GueltigAb <= #" + pgRow.GueltigAb.ToString("MM/dd/yyyy HH:mm:ss") + "#");
                    bezeichnung = rPs.Bezeichnung + " Gültig ab: " + pgRow.GueltigAb.ToString("dd.MM.yyyy");
                }

                if (ppRows.Length > 0)
                {
                    delete = false;
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(bezeichnung);

                    //Klienten anzeigen
                    //if (sb.Length > 0) sb.Append("\n");
                    //sb.Append("- " + rPs.Bezeichnung + " ist zu folgende Klienten zugeordnet:\n\t");

                    //foreach (dsPatientPflegestufe.PatientPflegestufeRow pRow in dt)
                    //{
                    //    p = new Patient(pRow.IDPatient);
                    //    if (dt.Rows.IndexOf(pRow) > 0)
                    //        sb.Append("\n\t");
                    //    sb.Append("- " + p.FullName);
                    //}
                }

                if (delete)
                {
                    if (_newRow != null && _newRow.ID == (Guid)row.Cells["ID"].Value)
                        _newRow = null;

                    row.Delete(false);
                    _PflegeStufeChenged = true;
                    if (ValueChanged != null)
                        ValueChanged(this, null);
                }
            }

            if (sb.Length > 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Pflegegeldstufe(n) (") + sb.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(") ist(sind) zu Klienten zugeordenet, Daher kann(können) nicht gelöscht werden."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegegeldstufe löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
            }

        }

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			_newRow = _pf.New(_ds);

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, ((dsPflegegeldstufe.PflegegeldstufeDataTable)_newRow.Table).BezeichnungColumn.ColumnName);
            _PflegeStufeChenged = true;

            if (ValueChanged != null)
                ValueChanged(this, e);
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
            HandleDelete();
       	}

        private void btnAddBetrag_Click(object sender, EventArgs e)
        {
            if (dgMain.ActiveRow == null)
                return;
            _pf.NewPflegegeldstufeGueltig(_ds, ACTIVE_ID, DateTime.Now.Date, 0); 
            ExpandActiveRow();

            _PflegeStufeChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void dgMain_AfterRowsDeleted(object sender, EventArgs e)
        {
            _PflegeStufeChenged = true;
            EnableDisableButtons();
        }

        private void dgMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
            {
                if (e.KeyCode == Keys.Delete && PMDS.Global.ENV.adminSecure)
                {
                    if (dgMain.ActiveCell != null && dgMain.ActiveCell.IsInEditMode)
                        return;
                    e.Handled = true;
                }
                HandleDelete();
            }
        }

        private void dgMain_AfterRowUpdate(object sender, RowEventArgs e)
        {
            _PflegeStufeChenged = true;
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            DataRowView v = (DataRowView)e.Cell.Row.ListObject;
            v.Row.SetColumnError(e.Cell.Column.Key, "");
            _PflegeStufeChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e.Row.IsExpanded)
                e.Row.Expanded = false;
            else
                e.Row.ExpandAll();
        }
	}
}
