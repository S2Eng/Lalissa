using PMDS.GUI.Klient;

namespace PMDS.GUI
{
    partial class ucKontaktPersonen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKontaktPersonen));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Kontaktperson", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAdresse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VerstaendigenJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kontaktart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Adresse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Verwandtschaft");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.btnUpdateKP = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelButtonsKP2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAddKP = new PMDS.GUI.ucButton(this.components);
            this.btnDelKP = new PMDS.GUI.ucButton(this.components);
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.gridKontaktpersonen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKontaktpersonen1 = new PMDS.GUI.Klient.dsKontaktpersonen();
            this.panelButtonsKP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKontaktpersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktpersonen1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateKP
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdateKP.Appearance = appearance1;
            this.btnUpdateKP.AutoWorkLayout = false;
            this.btnUpdateKP.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateKP.IsStandardControl = false;
            this.btnUpdateKP.Location = new System.Drawing.Point(1, 40);
            this.btnUpdateKP.Name = "btnUpdateKP";
            this.btnUpdateKP.Size = new System.Drawing.Size(22, 21);
            this.btnUpdateKP.TabIndex = 33;
            ultraToolTipInfo1.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdateKP, ultraToolTipInfo1);
            this.btnUpdateKP.Click += new System.EventHandler(this.btnUpdateKP_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panelButtonsKP2
            // 
            this.panelButtonsKP2.Controls.Add(this.btnAddKP);
            this.panelButtonsKP2.Controls.Add(this.btnUpdateKP);
            this.panelButtonsKP2.Controls.Add(this.btnDelKP);
            this.panelButtonsKP2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsKP2.Location = new System.Drawing.Point(661, 0);
            this.panelButtonsKP2.Name = "panelButtonsKP2";
            this.panelButtonsKP2.Size = new System.Drawing.Size(26, 133);
            this.panelButtonsKP2.TabIndex = 34;
            // 
            // btnAddKP
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddKP.Appearance = appearance14;
            this.btnAddKP.AutoWorkLayout = false;
            this.btnAddKP.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddKP.DoOnClick = true;
            this.btnAddKP.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddKP.IsStandardControl = true;
            this.btnAddKP.Location = new System.Drawing.Point(1, 0);
            this.btnAddKP.Name = "btnAddKP";
            this.btnAddKP.Size = new System.Drawing.Size(22, 21);
            this.btnAddKP.TabIndex = 31;
            this.btnAddKP.TabStop = false;
            this.btnAddKP.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddKP.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddKP.Click += new System.EventHandler(this.btnAddKP_Click);
            // 
            // btnDelKP
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelKP.Appearance = appearance15;
            this.btnDelKP.AutoWorkLayout = false;
            this.btnDelKP.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelKP.DoOnClick = true;
            this.btnDelKP.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelKP.IsStandardControl = true;
            this.btnDelKP.Location = new System.Drawing.Point(1, 20);
            this.btnDelKP.Name = "btnDelKP";
            this.btnDelKP.Size = new System.Drawing.Size(22, 21);
            this.btnDelKP.TabIndex = 32;
            this.btnDelKP.TabStop = false;
            this.btnDelKP.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelKP.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelKP.Click += new System.EventHandler(this.btnDelKP_Click);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.gridKontaktpersonen);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(661, 133);
            this.ultraGridBagLayoutPanel1.TabIndex = 35;
            // 
            // gridKontaktpersonen
            // 
            this.gridKontaktpersonen.AutoWork = true;
            this.gridKontaktpersonen.DataMember = "Kontaktperson";
            this.gridKontaktpersonen.DataSource = this.dsKontaktpersonen1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.gridKontaktpersonen.DisplayLayout.Appearance = appearance2;
            this.gridKontaktpersonen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Vertrauensperson";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(87, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 1;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(207, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(187, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.Caption = "Telefon / Adresse";
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(385, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn19.Header.VisiblePosition = 9;
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
            ultraGridColumn19});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridKontaktpersonen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridKontaktpersonen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridKontaktpersonen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.gridKontaktpersonen.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridKontaktpersonen.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridKontaktpersonen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridKontaktpersonen.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridKontaktpersonen.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.gridKontaktpersonen.DisplayLayout.MaxColScrollRegions = 1;
            this.gridKontaktpersonen.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridKontaktpersonen.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridKontaktpersonen.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.gridKontaktpersonen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridKontaktpersonen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.gridKontaktpersonen.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridKontaktpersonen.DisplayLayout.Override.CellAppearance = appearance9;
            this.gridKontaktpersonen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridKontaktpersonen.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.gridKontaktpersonen.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.TextHAlignAsString = "Left";
            this.gridKontaktpersonen.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.gridKontaktpersonen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridKontaktpersonen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.gridKontaktpersonen.DisplayLayout.Override.RowAppearance = appearance12;
            this.gridKontaktpersonen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridKontaktpersonen.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.gridKontaktpersonen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridKontaktpersonen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridKontaktpersonen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridKontaktpersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKontaktpersonen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.gridKontaktpersonen, gridBagConstraint1);
            this.gridKontaktpersonen.Location = new System.Drawing.Point(0, 0);
            this.gridKontaktpersonen.Name = "gridKontaktpersonen";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.gridKontaktpersonen, new System.Drawing.Size(471, 95));
            this.gridKontaktpersonen.Size = new System.Drawing.Size(661, 133);
            this.gridKontaktpersonen.TabIndex = 3;
            this.gridKontaktpersonen.Text = "ultraGrid1";
            this.gridKontaktpersonen.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.gridKontaktpersonen_DoubleClickCell);
            this.gridKontaktpersonen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridKontaktpersonen_KeyDown);
            // 
            // dsKontaktpersonen1
            // 
            this.dsKontaktpersonen1.DataSetName = "dsKontaktpersonen";
            this.dsKontaktpersonen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucKontaktPersonen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.panelButtonsKP2);
            this.Name = "ucKontaktPersonen";
            this.Size = new System.Drawing.Size(687, 133);
            this.Load += new System.EventHandler(this.ucKontaktPersonen_Load);
            this.panelButtonsKP2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKontaktpersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktpersonen1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseGrid gridKontaktpersonen;
        private dsKontaktpersonen dsKontaktpersonen1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsKP2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        public QS2.Desktop.ControlManagment.BaseButton btnUpdateKP;
        public ucButton btnDelKP;
        public ucButton btnAddKP;
    }
}
