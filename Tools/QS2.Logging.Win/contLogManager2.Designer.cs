namespace QS2.Logging.Win
{
    partial class contLogManager2
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tblLog2", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Time", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MachineName", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAdress", -1, null, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("User", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", -1, null, 4, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Type");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FileName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.gridLogs = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsLog21 = new QS2.Logging.Win.dsLog2();
            this.btnSelectPath = new Infragistics.Win.Misc.UltraButton();
            this.btnSaveAsXML2 = new Infragistics.Win.Misc.UltraLabel();
            this.lblInfo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.chkTooltip = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLog21)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLogs
            // 
            this.gridLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLogs.DataMember = "tblLog2";
            this.gridLogs.DataSource = this.dsLog21;
            appearance1.BackColor = System.Drawing.Color.White;
            this.gridLogs.DisplayLayout.Appearance = appearance1;
            ultraGridColumn7.Format = "yyyy-MM-dd HH:mm:ss";
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn7.Width = 133;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Width = 131;
            ultraGridColumn1.Header.VisiblePosition = 3;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn9.Width = 114;
            ultraGridColumn10.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedTextEditor;
            ultraGridColumn10.Width = 1229;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Width = 110;
            ultraGridColumn2.Header.VisiblePosition = 5;
            ultraGridColumn2.Width = 148;
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn1,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn2,
            ultraGridColumn12});
            this.gridLogs.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridLogs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridLogs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridLogs.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.gridLogs.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.gridLogs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridLogs.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.gridLogs.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridLogs.DisplayLayout.Override.RowPreviewAppearance = appearance2;
            this.gridLogs.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.gridLogs.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.gridLogs.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLogs.Location = new System.Drawing.Point(5, 33);
            this.gridLogs.Name = "gridLogs";
            this.gridLogs.Size = new System.Drawing.Size(832, 572);
            this.gridLogs.TabIndex = 1;
            this.gridLogs.Text = "Log";
            this.gridLogs.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridLogs_BeforeCellActivate);
            this.gridLogs.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridLogs_BeforeRowsDeleted);
            this.gridLogs.Click += new System.EventHandler(this.gridLogs_Click);
            this.gridLogs.DoubleClick += new System.EventHandler(this.gridLogs_DoubleClick);
            // 
            // dsLog21
            // 
            this.dsLog21.DataSetName = "dsLog2";
            this.dsLog21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(11, 5);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(83, 23);
            this.btnSelectPath.TabIndex = 9;
            this.btnSelectPath.Text = "Select path";
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnSaveAsXML2
            // 
            this.btnSaveAsXML2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance5.FontData.SizeInPoints = 8F;
            appearance5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAsXML2.Appearance = appearance5;
            this.btnSaveAsXML2.AutoSize = true;
            appearance6.FontData.UnderlineAsString = "True";
            this.btnSaveAsXML2.HotTrackAppearance = appearance6;
            this.btnSaveAsXML2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveAsXML2.Location = new System.Drawing.Point(754, 11);
            this.btnSaveAsXML2.Name = "btnSaveAsXML2";
            this.btnSaveAsXML2.Size = new System.Drawing.Size(73, 14);
            this.btnSaveAsXML2.TabIndex = 11;
            this.btnSaveAsXML2.Text = "Export to XML";
            this.btnSaveAsXML2.UseAppStyling = false;
            this.btnSaveAsXML2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSaveAsXML2.Click += new System.EventHandler(this.btnSaveAsXML2_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(99, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(197, 16);
            this.lblInfo.TabIndex = 12;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 30000;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // chkTooltip
            // 
            this.chkTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTooltip.AutoSize = true;
            this.chkTooltip.Location = new System.Drawing.Point(663, 10);
            this.chkTooltip.Name = "chkTooltip";
            this.chkTooltip.Size = new System.Drawing.Size(58, 17);
            this.chkTooltip.TabIndex = 13;
            this.chkTooltip.Text = "Tooltip";
            this.chkTooltip.UseVisualStyleBackColor = true;
            // 
            // contLogManager2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkTooltip);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSaveAsXML2);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.gridLogs);
            this.Name = "contLogManager2";
            this.Size = new System.Drawing.Size(842, 609);
            this.Load += new System.EventHandler(this.contLogManager2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLog21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridLogs;
        private dsLog2 dsLog21;
        private Infragistics.Win.Misc.UltraButton btnSelectPath;
        internal Infragistics.Win.Misc.UltraLabel btnSaveAsXML2;
        private Infragistics.Win.Misc.UltraLabel lblInfo;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.CheckBox chkTooltip;
    }
}
