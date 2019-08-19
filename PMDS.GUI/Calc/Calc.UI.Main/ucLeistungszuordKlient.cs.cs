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
using PMDS.Calc.UI.Admin;
using PMDS.Global;
using PMDS.GUI;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;

namespace PMDS.Calc.UI.Admin
{


    public class ucLeistungszuordKlient : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh
	{

        private PatientLeistungsplan _plan = new PatientLeistungsplan();
        private dsPatientLeistungsplan.PatientLeistungsplanDataTable _dt = new dsPatientLeistungsplan.PatientLeistungsplanDataTable();
    
        public event EventHandler ValueChanged;
	    private Guid                                                    _IDPatient = Guid.Empty;
        private bool                                                    _DataChenged = false;
        private Patient _patient;



        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private PMDS.Abrechnung.Global.dsPatientLeistungsplan dsPatientLeistungsplan1;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private ErrorProvider errorProvider1;
        private ucLeistungskatalogAuswahl ucLeistungskatalogAuswahl1;
        private ucButton btnDel;
        private IContainer components;

        


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientLeistungsplan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLeistungskatalog", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImVorausJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StornoJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Satz", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientLeistungsplan1 = new PMDS.Abrechnung.Global.dsPatientLeistungsplan();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.ucLeistungskatalogAuswahl1 = new PMDS.Calc.UI.Admin.ucLeistungskatalogAuswahl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientLeistungsplan1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(5, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(176, 15);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "Verfügbare Leistungen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.DataSource = this.dsPatientLeistungsplan1.PatientLeistungsplan;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance3;
            this.dgMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Caption = "Leistung";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(177, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "Gültig ab";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(85, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Gültig bis";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(82, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Erfasst am";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(72, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Benutzer";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(98, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.Caption = "Abgerechnet bis";
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(88, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Storno";
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(41, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            ultraGridColumn12.CellAppearance = appearance1;
            ultraGridColumn12.DataType = typeof(double);
            ultraGridColumn12.Format = "###,###,##0.000";
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(67, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
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
            ultraGridColumn12});
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
            this.dgMain.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgMain.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(268, 25);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(572, 354);
            this.dgMain.TabIndex = 3;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgMain_BeforeExitEditMode);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.dgMain_Error);
            this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMain_KeyDown);
            // 
            // dsPatientLeistungsplan1
            // 
            this.dsPatientLeistungsplan1.DataSetName = "dsPatientLeistungsplan";
            this.dsPatientLeistungsplan1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientLeistungsplan1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.btnDel.Location = new System.Drawing.Point(817, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 21);
            this.btnDel.TabIndex = 12;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ucLeistungskatalogAuswahl1
            // 
            this.ucLeistungskatalogAuswahl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ucLeistungskatalogAuswahl1.BackColor = System.Drawing.Color.Transparent;
            this.ucLeistungskatalogAuswahl1.Location = new System.Drawing.Point(3, 24);
            this.ucLeistungskatalogAuswahl1.Name = "ucLeistungskatalogAuswahl1";
            this.ucLeistungskatalogAuswahl1.SELECTIONHASCHILDS = true;
            this.ucLeistungskatalogAuswahl1.Size = new System.Drawing.Size(268, 355);
            this.ucLeistungskatalogAuswahl1.TabIndex = 11;
            // 
            // ucLeistungszuordKlient
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgMain);
            this.Controls.Add(this.ucLeistungskatalogAuswahl1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "ucLeistungszuordKlient";
            this.Size = new System.Drawing.Size(845, 388);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientLeistungsplan1)).EndInit();
            this.ResumeLayout(false);

        }
        
        public ucLeistungszuordKlient()
		{
			InitializeComponent();
            this.initControl();
		}
        public void  initControl()
        {
            if (DesignMode || !ENV.AppRunning)
                return;

            ucLeistungskatalogAuswahl1.RefreshControl();
            ucLeistungskatalogAuswahl1.DragPickerSelected += new DragPickerSelectedDelegate(ucLeistungskatalogDragPicker1_LeistungskatalogSelected);
            ucLeistungskatalogAuswahl1.DragPickerUnSelected += new DragPickerUnSelectedDelegate(ucLeistungskatalogDragPicker1_LeistungskatalogUnSelected);
            RefreshLeistungskatalogValueList(false);
            RefreshUserList();
        }
               

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                _plan.Update(_dt);
                _DataChenged = false;
                return true;
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
                return false;
            }
        }

        public void Undo()
        {
            RefreshControl();
        }

        public bool IsChanged { get { return _DataChenged; } }

        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow row in dgMain.Rows)
            {
                if (row.Hidden) continue;
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

            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("IDLeistungskatalog", false);
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("GueltigAb", false);
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("GueltigBis", true);

            //os 140329: Was tut diese Funktion? Eigentlich gar nichts!
            bool newCheck = true;
            UltraGridRow rLast = null;
            foreach (UltraGridRow row in dgMain.Rows)
            {
                if (rLast != null)
                {
                    if ((System.Guid)row.Cells["IDLeistungskatalog"].Value != (System.Guid)rLast.Cells["IDLeistungskatalog"].Value)
                          newCheck = true;
                    else  newCheck = false;
                    //if (!newCheck  )
                    //{
                    //    DateTime bGueltigBisLast = new DateTime(2200, 1, 1);
                    //    if (rLast.Cells["GueltigBis"].Value.GetType().Name != "DBNull")
                    //        bGueltigBisLast = (DateTime)rLast.Cells["GueltigBis"].Value;

                    //    if (((DateTime)row.Cells["GueltigAb"].Value).Date  < bGueltigBisLast.Date )
                    //    {
                    //        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben für Leistungszuordnungen überschneidende Gültigskeitsbereiche eingegeben. Bitte korrigieren!", "Eingabefehler", MessageBoxButtons.OK);
                    //        dgMain.Selected.Rows.Clear();
                    //        row.Selected = true;
                    //        dgMain.ActiveRow = row;
                    //       // row.SetColumnError(row.Cells["GueltigAb"].Column.Index, "");
                    //        bError = true;
                    //        return !bError;
                    //    }
                    //}

                }
                rLast = row;
            }

            return !bError;
        }

        public void RefreshControl()
        {
            ucLeistungskatalogAuswahl1.RefreshControl();
          
            _DataChenged = false;
            _dt = _plan.Read(_IDPatient, ENV.IDKlinik);
            _dt.GueltigAbColumn.AllowDBNull = true;
            dgMain.DataSource = _dt;

            //foreach (UltraGridRow r in dgMain.Rows)
            //{
            //    SetLeistungskatalogSatz(r);
            //    r.Update();
            //}

            dgMain.Refresh();

            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("IDLeistungskatalog", false);
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("GueltigAb", false);
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("GueltigBis", true);

            RefreshLeistungskatalogValueList(true);
        }

        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                RefreshControl();
            }
        }

        private void RefreshLeistungskatalogValueList(bool refreshList)
        {
            try
            {
                dsPatientLeistungsplan.PatientLeistungsplanDataTable dt = new dsPatientLeistungsplan.PatientLeistungsplanDataTable();
                UltraGridTools.AddLeistungskatalogValueList(dgMain, dt.IDLeistungskatalogColumn.ColumnName, refreshList);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void RefreshUserList()
        {
            try
            {
                PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            if(cell.Column.Key == "Satz")
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsPatientLeistungsplan.PatientLeistungsplanRow r = (dsPatientLeistungsplan.PatientLeistungsplanRow)v.Row;
            dsPatientLeistungsplan.PatientLeistungsplanDataTable dt = (dsPatientLeistungsplan.PatientLeistungsplanDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");

            if (cell.Column.Key == dt.GueltigAbColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            //else if (cell.Column.Key == dt.GueltigBisColumn.ColumnName)
            //{
            //    DateTime t = new DateTime(1900, 1, 1);

            //    if (cell.Value != null && cell.Value != DBNull.Value)
            //        DateTime.TryParse(cell.Text.Trim(), out t);
            //    t = t == new DateTime(1900, 1, 1) ? abrech.GueltigBis : t;

            //    DateTime tGueltAb = new DateTime(1900, 1, 1);
            //    DateTime.TryParse(cell.Row.Cells[dt.GueltigAbColumn.ColumnName].Value.ToString(), out tGueltAb);

            //    if (!bError && tGueltAb != new DateTime(1900, 1, 1))
            //    {
            //        string txt = "Das Datum Gültig bis darf nicht vor dem " + tGueltAb.ToString("dd.MM.yyyy") + " liegen.";
            //        GuiUtil.ValidateField(dgMain, tGueltAb < t, txt, ref bError, false, null);

            //        if (bError)
            //            r.SetColumnError(cell.Column.Index, txt);
            //    }
            //}
            else if (cell.Column.Key == dt.ErfasstAmColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

		private void RemoveSelected() 
		{
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
            {
                if(!r.Hidden)
                    al.Add(r);
            }

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut && !dgMain.ActiveRow.Hidden)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;

            dsPatientLeistungsplan.PatientLeistungsplanDataTable dt = new dsPatientLeistungsplan.PatientLeistungsplanDataTable();

            ArrayList al2 = new ArrayList();
            foreach (UltraGridRow r in ra)
            {
                    r.Delete(false);
                    _DataChenged = true;
            }

            ra = (UltraGridRow[])al2.ToArray(typeof(UltraGridRow));

            StringBuilder sb = new StringBuilder();
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Datensätze sind Abrechnungen erstellt worden, daher können sie nicht gelöscht werden.\n\t"));

            foreach (UltraGridRow r in ra)
            {
                sb.Append("- " + r.Cells[dt.GueltigAbColumn.ColumnName].Text);
                if (r.Cells[dt.GueltigBisColumn.ColumnName].Value != DBNull.Value)
                    sb.Append(" - " + r.Cells[dt.GueltigBisColumn.ColumnName].Text);

                sb.Append("- " + r.Cells[dt.IDLeistungskatalogColumn.ColumnName].Text.Trim() + "\n\t");
            }

            if (ra.Length > 0)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);

            if (dgMain.Rows.Count > 0)
            {
                dgMain.ActiveRow = dgMain.Rows[0];
                dgMain.ActiveRow.Selected = true;
            }
            else
                dgMain.ActiveRow = null;

            if (_DataChenged && ValueChanged != null)
                ValueChanged(this, null);
		}
		private void AddElement(Guid IDLeistungskatalog) 
		{
            _plan.New(_dt, _IDPatient, IDLeistungskatalog, ENV.IDKlinik);
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "GueltigAb");

            //SetLeistungskatalogSatz(dgMain.ActiveRow);
            dgMain.Refresh();
            _DataChenged = true;
            
            if (ValueChanged != null)
                ValueChanged(this, null);
        }

        private void SetLeistungskatalogSatz(UltraGridRow r)
        {
            //DataRowView v = (DataRowView)r.ListObject;
            //dsPatientLeistungsplan.PatientLeistungsplanRow row = (dsPatientLeistungsplan.PatientLeistungsplanRow)v.Row;
            //dsPatientLeistungsplan.PatientLeistungsplanDataTable dt = (dsPatientLeistungsplan.PatientLeistungsplanDataTable)row.Table;

            //Guid IDLeistungskatalog = Guid.Empty;
            //UltraGridCell LeistungskatalogCell = r.Cells[dt.IDLeistungskatalogColumn.ColumnName];

            //if (LeistungskatalogCell.ValueListResolved.SelectedItemIndex != -1)
            //{
            //    IDLeistungskatalog = (Guid)LeistungskatalogCell.ValueListResolved.GetValue(LeistungskatalogCell.ValueListResolved.SelectedItemIndex);
            //}
            //else
            //{
            //    IDLeistungskatalog = (Guid)LeistungskatalogCell.Value;
            //}


            //if (IDLeistungskatalog == Guid.Empty)
            //    return;

            //LeistungsKatalog lk = new LeistungsKatalog();
            //dsLeistungskatalog ds = lk.ReadByID(IDLeistungskatalog);

            //DateTime datum = new DateTime(1900, 1, 1);
            //try
            //{
            //    datum = (r.Cells[dt.GueltigAbColumn.ColumnName].EditorResolved.IsInEditMode) ? (DateTime)r.Cells[dt.GueltigAbColumn.ColumnName].EditorResolved.Value : (DateTime)r.Cells[dt.GueltigAbColumn.ColumnName].Value;
            //    datum = new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 59);
            //}
            //catch
            //{
            //    return;
            //}

            //dsLeistungskatalog.LeistungskatalogGueltigRow[] rows = (dsLeistungskatalog.LeistungskatalogGueltigRow[])ds.LeistungskatalogGueltig.Select("GueltigAb <= #" + datum.ToString("MM/dd/yyyy HH:mm:ss") + "#", "GueltigAb DESC");
            
            //if (rows.Length == 0)
            //    return;
            //bool storno = (r.Cells[_dt.StornoJNColumn.ColumnName].EditorResolved.IsInEditMode) ? (bool)r.Cells[_dt.StornoJNColumn.ColumnName].EditorResolved.Value : (bool)r.Cells[_dt.StornoJNColumn.ColumnName].Value;
            //r.Cells["Satz"].Value = storno ? -rows[0].Betrag : rows[0].Betrag;
        }
		private void ucLeistungskatalogDragPicker1_LeistungskatalogSelected(Guid IDLeistungskatalog)
		{
			AddElement(IDLeistungskatalog);
		}
		
		private Guid ucLeistungskatalogDragPicker1_LeistungskatalogUnSelected()
		{
			RemoveSelected();
			Guid idret = Guid.Empty;
			return idret;
		}

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            //if (e.Cell.Column.Key == _dt.IDLeistungskatalogColumn.ColumnName || e.Cell.Column.Key == _dt.GueltigAbColumn.ColumnName || e.Cell.Column.Key == _dt.StornoJNColumn.ColumnName)
            //{
            //    SetLeistungskatalogSatz(dgMain.ActiveRow);
            //    dgMain.Refresh();
            //}
            
            _DataChenged = true;

            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            if (dgMain.ActiveCell != null &&
                (dgMain.ActiveCell.Column.Key == "GueltigAB" ||
                dgMain.ActiveCell.Column.Key == "GueltigBis" ||
                dgMain.ActiveCell.Column.Key == "ErfasstAm") && !dgMain.ActiveCell.EditorResolved.IsValid)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                dgMain.ActiveCell.Value = DBNull.Value;
                e.Cancel = true;
                dgMain.Select();
                dgMain.ActiveCell.Selected = true;
                dgMain.ActiveCell.Activate();
                dgMain.Focus();
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            Cursor = Cursors.Default;
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
            //    RemoveSelected();
            //}
        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            foreach (UltraGridCell cell in dgMain.ActiveRow.Cells)
            {
                if (cell.Column.Key == _dt.GueltigBisColumn.ColumnName) continue;
                cell.Activation =  Activation.AllowEdit;
            }
        }

        private void dgMain_Error(object sender, ErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

	}
}
