namespace PMDS.GUI.BaseControls
{
    partial class contEditMedizinischeTypen2
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MedizinischeTypen", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nummer", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Icon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IconOFF");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bVisible");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ico", 0, 779767563);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IcoOff", 1, 779767657);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(779767563);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(779767657);
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.uPictureBoxPreviewIconOFF = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.lblPreview = new Infragistics.Win.Misc.UltraLabel();
            this.uPictureBoxPreviewIcon = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblFound = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.gridMedTypen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iconHochladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.iconDeaktiviertHochladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconDeaktiviertLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.dsManage1 = new PMDS.Global.db.ERSystem.dsManage();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedTypen)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnDel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1098, 34);
            this.panelTop.TabIndex = 45;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnRefresh.Appearance = appearance1;
            this.btnRefresh.AutoWorkLayout = false;
            this.btnRefresh.IsStandardControl = false;
            this.btnRefresh.Location = new System.Drawing.Point(6, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 27);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Tag = "16";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(1032, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 27);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Tag = "16";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(1060, 4);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 27);
            this.btnDel.TabIndex = 14;
            this.btnDel.Tag = "17";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.uPictureBoxPreviewIconOFF);
            this.panelBottom.Controls.Add(this.lblPreview);
            this.panelBottom.Controls.Add(this.uPictureBoxPreviewIcon);
            this.panelBottom.Controls.Add(this.btnAbort);
            this.panelBottom.Controls.Add(this.lblFound);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 636);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1098, 37);
            this.panelBottom.TabIndex = 46;
            // 
            // uPictureBoxPreviewIconOFF
            // 
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            this.uPictureBoxPreviewIconOFF.Appearance = appearance4;
            this.uPictureBoxPreviewIconOFF.BorderShadowColor = System.Drawing.Color.Empty;
            this.uPictureBoxPreviewIconOFF.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uPictureBoxPreviewIconOFF.Location = new System.Drawing.Point(484, 4);
            this.uPictureBoxPreviewIconOFF.Name = "uPictureBoxPreviewIconOFF";
            this.uPictureBoxPreviewIconOFF.Size = new System.Drawing.Size(131, 65);
            this.uPictureBoxPreviewIconOFF.TabIndex = 107;
            this.uPictureBoxPreviewIconOFF.Visible = false;
            // 
            // lblPreview
            // 
            appearance5.TextHAlignAsString = "Right";
            this.lblPreview.Appearance = appearance5;
            this.lblPreview.Location = new System.Drawing.Point(281, 4);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(66, 14);
            this.lblPreview.TabIndex = 106;
            this.lblPreview.Text = "Vorschau:";
            this.lblPreview.Visible = false;
            // 
            // uPictureBoxPreviewIcon
            // 
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            this.uPictureBoxPreviewIcon.Appearance = appearance6;
            this.uPictureBoxPreviewIcon.BorderShadowColor = System.Drawing.Color.Empty;
            this.uPictureBoxPreviewIcon.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uPictureBoxPreviewIcon.Location = new System.Drawing.Point(349, 4);
            this.uPictureBoxPreviewIcon.Name = "uPictureBoxPreviewIcon";
            this.uPictureBoxPreviewIcon.Size = new System.Drawing.Size(131, 65);
            this.uPictureBoxPreviewIcon.TabIndex = 105;
            this.uPictureBoxPreviewIcon.Visible = false;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnAbort.Appearance = appearance7;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(1051, 2);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(32, 30);
            this.btnAbort.TabIndex = 104;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lblFound
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.lblFound.Appearance = appearance8;
            this.lblFound.Location = new System.Drawing.Point(6, 3);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(137, 16);
            this.lblFound.TabIndex = 103;
            this.lblFound.Text = "Gefunden: 12";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance9;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(967, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 30);
            this.btnSave.TabIndex = 102;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Controls.Add(this.gridMedTypen);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 34);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1098, 602);
            this.panelCenter.TabIndex = 47;
            // 
            // gridMedTypen
            // 
            this.gridMedTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMedTypen.AutoWork = true;
            this.gridMedTypen.contextMenuStrip1 = this.contextMenuStripGrid;
            this.gridMedTypen.DataMember = "MedizinischeTypen";
            this.gridMedTypen.DataSource = this.dsManage1;
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.FontData.SizeInPoints = 10F;
            this.gridMedTypen.DisplayLayout.Appearance = appearance10;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn20.Hidden = true;
            appearance11.TextHAlignAsString = "Center";
            ultraGridColumn2.CellAppearance = appearance11;
            appearance12.TextHAlignAsString = "Center";
            ultraGridColumn2.Header.Appearance = appearance12;
            ultraGridColumn2.Header.Caption = "Reihenfolge";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 84;
            appearance13.TextHAlignAsString = "Center";
            ultraGridColumn21.CellAppearance = appearance13;
            appearance14.TextHAlignAsString = "Center";
            ultraGridColumn21.Header.Appearance = appearance14;
            ultraGridColumn21.Header.Caption = "Medizinischer Typ";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 144;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 3;
            ultraGridColumn23.Width = 508;
            ultraGridColumn3.Header.Caption = "Icon Bytes";
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 7;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 101;
            ultraGridColumn4.Header.Caption = "Icon deaktiviert Bytes";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 8;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.Width = 105;
            ultraGridColumn28.Header.Caption = "Sichtbar";
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 4;
            ultraGridColumn28.Width = 78;
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn1.CellAppearance = appearance15;
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn1.Header.Appearance = appearance16;
            ultraGridColumn1.Header.Caption = "Icon";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 5;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn1.Width = 95;
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn5.CellAppearance = appearance17;
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn5.Header.Appearance = appearance18;
            ultraGridColumn5.Header.Caption = "Icon deaktiviert";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn5.Width = 104;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn20,
            ultraGridColumn2,
            ultraGridColumn21,
            ultraGridColumn23,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn28,
            ultraGridColumn1,
            ultraGridColumn5});
            this.gridMedTypen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridMedTypen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridMedTypen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridMedTypen.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridMedTypen.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridMedTypen.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridMedTypen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridMedTypen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridMedTypen.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.gridMedTypen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance19.BorderColor = System.Drawing.Color.White;
            this.gridMedTypen.DisplayLayout.Override.SummaryFooterAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.White;
            this.gridMedTypen.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridMedTypen.DisplayLayout.Override.SummaryValueAppearance = appearance21;
            this.gridMedTypen.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Ico";
            valueList2.Key = "IcoOff";
            this.gridMedTypen.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.gridMedTypen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridMedTypen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridMedTypen.Location = new System.Drawing.Point(3, 4);
            this.gridMedTypen.Margin = new System.Windows.Forms.Padding(4);
            this.gridMedTypen.Name = "gridMedTypen";
            this.gridMedTypen.Size = new System.Drawing.Size(1091, 594);
            this.gridMedTypen.TabIndex = 43;
            this.gridMedTypen.Text = "Dokumente";
            this.gridMedTypen.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridMedTypen_BeforeCellActivate);
            this.gridMedTypen.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridMedTypen_BeforeRowsDeleted);
            this.gridMedTypen.Click += new System.EventHandler(this.gridMedTypen_Click);
            this.gridMedTypen.DoubleClick += new System.EventHandler(this.gridMedTypen_DoubleClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconHochladenToolStripMenuItem,
            this.iconLöschenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.iconDeaktiviertHochladenToolStripMenuItem,
            this.iconDeaktiviertLöschenToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(206, 104);
            // 
            // iconHochladenToolStripMenuItem
            // 
            this.iconHochladenToolStripMenuItem.Name = "iconHochladenToolStripMenuItem";
            this.iconHochladenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.iconHochladenToolStripMenuItem.Text = "Bild zuordnen";
            this.iconHochladenToolStripMenuItem.Click += new System.EventHandler(this.iconHochladenToolStripMenuItem_Click);
            // 
            // iconLöschenToolStripMenuItem
            // 
            this.iconLöschenToolStripMenuItem.Name = "iconLöschenToolStripMenuItem";
            this.iconLöschenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.iconLöschenToolStripMenuItem.Text = "Bild löschen";
            this.iconLöschenToolStripMenuItem.Click += new System.EventHandler(this.iconLöschenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 6);
            // 
            // iconDeaktiviertHochladenToolStripMenuItem
            // 
            this.iconDeaktiviertHochladenToolStripMenuItem.Name = "iconDeaktiviertHochladenToolStripMenuItem";
            this.iconDeaktiviertHochladenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.iconDeaktiviertHochladenToolStripMenuItem.Text = "Bild deaktiviert zuordnen";
            this.iconDeaktiviertHochladenToolStripMenuItem.Click += new System.EventHandler(this.iconDeaktiviertHochladenToolStripMenuItem_Click);
            // 
            // iconDeaktiviertLöschenToolStripMenuItem
            // 
            this.iconDeaktiviertLöschenToolStripMenuItem.Name = "iconDeaktiviertLöschenToolStripMenuItem";
            this.iconDeaktiviertLöschenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.iconDeaktiviertLöschenToolStripMenuItem.Text = "Bild deaktiviert löschen";
            this.iconDeaktiviertLöschenToolStripMenuItem.Click += new System.EventHandler(this.iconDeaktiviertLöschenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 6);
            // 
            // dsManage1
            // 
            this.dsManage1.DataSetName = "dsManage";
            this.dsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contEditMedizinischeTypen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "contEditMedizinischeTypen2";
            this.Size = new System.Drawing.Size(1098, 673);
            this.Load += new System.EventHandler(this.contEditMedizinischeTypen2_Load);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMedTypen)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Infragistics.Win.Misc.UltraLabel lblFound;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private System.Windows.Forms.Panel panelCenter;
        public QS2.Desktop.ControlManagment.BaseGrid gridMedTypen;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnRefresh;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Global.db.ERSystem.dsManage dsManage1;
        private QS2.Desktop.ControlManagment.BaseButton btnAbort;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem iconHochladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iconDeaktiviertHochladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconDeaktiviertLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox uPictureBoxPreviewIcon;
        private Infragistics.Win.Misc.UltraLabel lblPreview;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox uPictureBoxPreviewIconOFF;
    }
}
