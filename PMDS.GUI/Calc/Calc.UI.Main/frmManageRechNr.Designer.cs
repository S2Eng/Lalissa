namespace PMDS.GUI.Calc.Calc.UI.Main
{
    partial class frmManageRechNr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("rechNr", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("typ", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("nr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("year", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(686348204);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(337493844);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridRechNr = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsManage1 = new PMDS.Global.db.ERSystem.dsManage();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.sqlManange2 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblRechnungsnummern = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridRechNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(148, 301);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 28);
            this.btnAbort.TabIndex = 33;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(224, 301);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 28);
            this.btnSave.TabIndex = 32;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridRechNr
            // 
            this.gridRechNr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRechNr.AutoWork = false;
            this.gridRechNr.DataMember = "rechNr";
            this.gridRechNr.DataSource = this.dsManage1;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.SizeInPoints = 10F;
            this.gridRechNr.DisplayLayout.Appearance = appearance3;
            this.gridRechNr.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Caption = "Typ";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 155;
            ultraGridColumn2.Header.Caption = "Nr";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 136;
            ultraGridColumn3.Header.Caption = "Jahr";
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 112;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.gridRechNr.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridRechNr.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridRechNr.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridRechNr.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridRechNr.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridRechNr.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridRechNr.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridRechNr.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridRechNr.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridRechNr.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance4.BorderColor = System.Drawing.Color.White;
            this.gridRechNr.DisplayLayout.Override.SummaryFooterAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.White;
            this.gridRechNr.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridRechNr.DisplayLayout.Override.SummaryValueAppearance = appearance6;
            this.gridRechNr.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Typ";
            valueList2.Key = "Lieferant";
            this.gridRechNr.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.gridRechNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridRechNr.Location = new System.Drawing.Point(6, 32);
            this.gridRechNr.Margin = new System.Windows.Forms.Padding(4);
            this.gridRechNr.Name = "gridRechNr";
            this.gridRechNr.Size = new System.Drawing.Size(433, 265);
            this.gridRechNr.TabIndex = 35;
            this.gridRechNr.Text = "Dokumente";
            this.gridRechNr.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridMsgBox_BeforeCellActivate);
            this.gridRechNr.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridMsgBox_BeforeRowsDeleted);
            this.gridRechNr.Click += new System.EventHandler(this.gridMsgBox_Click);
            this.gridRechNr.DoubleClick += new System.EventHandler(this.gridMsgBox_DoubleClick);
            // 
            // dsManage1
            // 
            this.dsManage1.DataSetName = "dsManage";
            this.dsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(61, 4);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance7;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(383, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 27);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Tag = "";
            this.btnAdd.Click += new System.EventHandler(this.btnAddVO_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance8;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(411, 4);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 27);
            this.btnDel.TabIndex = 37;
            this.btnDel.Tag = "";
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblRechnungsnummern
            // 
            this.lblRechnungsnummern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRechnungsnummern.Location = new System.Drawing.Point(7, 8);
            this.lblRechnungsnummern.Name = "lblRechnungsnummern";
            this.lblRechnungsnummern.Size = new System.Drawing.Size(370, 18);
            this.lblRechnungsnummern.TabIndex = 38;
            this.lblRechnungsnummern.Text = "Letzte verwendete Rechnungsnummern";
            // 
            // frmManageRechNr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 333);
            this.Controls.Add(this.lblRechnungsnummern);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.gridRechNr);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Name = "frmManageRechNr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verwaltung Rechnungs-Nr";
            this.Load += new System.EventHandler(this.frmManageRechNr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRechNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseGrid gridRechNr;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        private Global.db.ERSystem.dsManage dsManage1;
        private Global.db.ERSystem.sqlManange sqlManange2;
        private QS2.Desktop.ControlManagment.BaseLabel lblRechnungsnummern;
    }
}