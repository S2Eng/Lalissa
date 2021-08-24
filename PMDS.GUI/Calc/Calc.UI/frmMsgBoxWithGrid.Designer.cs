namespace PMDS.GUI.Calc.Calc.UI
{
    partial class frmMsgBoxWithGrid
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rezepteintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dosierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRezeptEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedDatenWundeKopf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Therapie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beendigungsgrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obj");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kostenteilung", 1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(686348204);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(337493844);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridMsgBox = new QS2.Desktop.ControlManagment.BaseGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblTitle = new Infragistics.Win.Misc.UltraLabel();
            this.lblKostenteilungInfo = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridMsgBox)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
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
            this.btnAbort.Location = new System.Drawing.Point(1044, 392);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 28);
            this.btnAbort.TabIndex = 33;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(1120, 392);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 32;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridMsgBox
            // 
            this.gridMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMsgBox.AutoWork = false;
            this.gridMsgBox.ContextMenuStrip = this.contextMenuStripGrid;
            this.gridMsgBox.contextMenuStrip1 = this.contextMenuStripGrid;
            this.gridMsgBox.DataMember = "UI";
            this.gridMsgBox.DataSource = this.dsKlientenliste1;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.SizeInPoints = 10F;
            this.gridMsgBox.DisplayLayout.Appearance = appearance3;
            this.gridMsgBox.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 900;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 6;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 7;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 8;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 9;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 10;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 11;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 12;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 13;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 14;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 15;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 16;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 17;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn20.DataType = typeof(bool);
            ultraGridColumn20.Header.Caption = "Auswahl";
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn20.Width = 58;
            ultraGridColumn4.DataType = typeof(bool);
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 18;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn3,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn2,
            ultraGridColumn20,
            ultraGridColumn4});
            this.gridMsgBox.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridMsgBox.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridMsgBox.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridMsgBox.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridMsgBox.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridMsgBox.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridMsgBox.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridMsgBox.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridMsgBox.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridMsgBox.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance4.BorderColor = System.Drawing.Color.White;
            this.gridMsgBox.DisplayLayout.Override.SummaryFooterAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.White;
            this.gridMsgBox.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridMsgBox.DisplayLayout.Override.SummaryValueAppearance = appearance6;
            this.gridMsgBox.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Typ";
            valueList2.Key = "Lieferant";
            this.gridMsgBox.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.gridMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridMsgBox.Location = new System.Drawing.Point(4, 62);
            this.gridMsgBox.Margin = new System.Windows.Forms.Padding(4);
            this.gridMsgBox.Name = "gridMsgBox";
            this.gridMsgBox.Size = new System.Drawing.Size(1228, 329);
            this.gridMsgBox.TabIndex = 34;
            this.gridMsgBox.Text = "Dokumente";
            this.gridMsgBox.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridMsgBox_CellChange);
            this.gridMsgBox.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridVO_BeforeCellActivate);
            this.gridMsgBox.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridVO_BeforeRowsDeleted);
            this.gridMsgBox.Click += new System.EventHandler(this.gridVO_Click);
            this.gridMsgBox.DoubleClick += new System.EventHandler(this.gridVO_DoubleClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleToolStripMenuItem,
            this.keineToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(104, 48);
            // 
            // alleToolStripMenuItem
            // 
            this.alleToolStripMenuItem.Name = "alleToolStripMenuItem";
            this.alleToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.alleToolStripMenuItem.Text = "Alle";
            this.alleToolStripMenuItem.Click += new System.EventHandler(this.alleToolStripMenuItem_Click);
            // 
            // keineToolStripMenuItem
            // 
            this.keineToolStripMenuItem.Name = "keineToolStripMenuItem";
            this.keineToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.keineToolStripMenuItem.Text = "Keine";
            this.keineToolStripMenuItem.Click += new System.EventHandler(this.keineToolStripMenuItem_Click);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Location = new System.Drawing.Point(4, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1227, 34);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Titel";
            // 
            // lblKostenteilungInfo
            // 
            this.lblKostenteilungInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ForeColor = System.Drawing.Color.Red;
            this.lblKostenteilungInfo.Appearance = appearance7;
            this.lblKostenteilungInfo.Location = new System.Drawing.Point(4, 45);
            this.lblKostenteilungInfo.Name = "lblKostenteilungInfo";
            this.lblKostenteilungInfo.Size = new System.Drawing.Size(1227, 16);
            this.lblKostenteilungInfo.TabIndex = 36;
            this.lblKostenteilungInfo.Text = "Hinweis: Rechnungen mit Kostenteilung können nicht gerollt werden!";
            // 
            // frmMsgBoxWithGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 425);
            this.Controls.Add(this.lblKostenteilungInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridMsgBox);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Name = "frmMsgBoxWithGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prüfung";
            this.Load += new System.EventHandler(this.frmMsgBoxWithGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMsgBox)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseGrid gridMsgBox;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem alleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keineToolStripMenuItem;
        private Infragistics.Win.Misc.UltraLabel lblTitle;
        private Infragistics.Win.Misc.UltraLabel lblKostenteilungInfo;
    }
}