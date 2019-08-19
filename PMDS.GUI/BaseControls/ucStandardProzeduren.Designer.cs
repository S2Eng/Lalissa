namespace PMDS.GUI
{
    partial class ucStandardProzeduren
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("StandardProzeduren", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ShowPrintDialog");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NotfallJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StandardProzeduren_SPDynRep");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StandardProzeduren_EintragStandardprozeduren");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("StandardProzeduren_SPDynRep", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStandardProzeduren");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DynRep");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("StandardProzeduren_EintragStandardprozeduren", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStandardProzeduren");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.dsStandardProzeduren1 = new PMDS.Data.Global.dsStandardProzeduren();
            this.grid = new QS2.Desktop.ControlManagment.BaseGrid();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsStandardProzeduren1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // dsStandardProzeduren1
            // 
            this.dsStandardProzeduren1.DataSetName = "dsStandardProzeduren";
            this.dsStandardProzeduren1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.DataSource = this.dsStandardProzeduren1;
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Standardprozedur";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(483, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 9;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 9;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            appearance2.BackColor = System.Drawing.Color.Silver;
            ultraGridBand1.Header.Appearance = appearance2;
            ultraGridBand1.Header.Caption = "Standard Prozeduren";
            appearance3.BackColor = System.Drawing.Color.Silver;
            ultraGridBand1.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Silver;
            ultraGridBand1.Override.HotTrackHeaderAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.Silver;
            ultraGridBand1.Override.RowSelectorAppearance = appearance5;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Hidden = true;
            appearance6.BackColor = System.Drawing.Color.Gainsboro;
            ultraGridColumn9.Header.Appearance = appearance6;
            ultraGridColumn9.Header.Caption = "Dynamische Reports zur Standardprozedur";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(515, 0);
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand2.Header.Appearance = appearance7;
            ultraGridBand2.Header.Caption = "Dynamische Reports zu der Prozedur";
            ultraGridBand2.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            appearance8.BackColor = System.Drawing.Color.Gainsboro;
            ultraGridBand2.Override.RowSelectorAppearance = appearance8;
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.Caption = "Maßnahme";
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            appearance9.BackColor = System.Drawing.Color.DarkOliveGreen;
            ultraGridBand3.Header.Appearance = appearance9;
            ultraGridBand3.Header.Caption = "Maßnahmen zm Notfall";
            ultraGridBand3.HeaderVisible = true;
            appearance10.BackColor = System.Drawing.Color.DarkOliveGreen;
            ultraGridBand3.Override.HeaderAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.DarkOliveGreen;
            ultraGridBand3.Override.HotTrackHeaderAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.DarkOliveGreen;
            ultraGridBand3.Override.RowSelectorAppearance = appearance12;
            ultraGridBand3.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grid.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grid.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            appearance13.BackColor = System.Drawing.Color.Silver;
            this.grid.DisplayLayout.CaptionAppearance = appearance13;
            this.grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.FixedHeaderAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.HeaderAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.HotTrackHeaderAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.RowAlternateAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance19;
            this.grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.Location = new System.Drawing.Point(0, 26);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(986, 443);
            this.grid.TabIndex = 43;
            this.grid.Text = "Standardprozeduren";
            this.grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grid_ClickCellButton);
            this.grid.BeforeRowInsert += new Infragistics.Win.UltraWinGrid.BeforeRowInsertEventHandler(this.grid_BeforeRowInsert);
            this.grid.InitializeTemplateAddRow += new Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler(this.grid_InitializeTemplateAddRow);
            this.grid.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grid_BeforeRowsDeleted);
            this.grid.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.grid_AfterRowInsert);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.Image = 3;
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDel.Appearance = appearance20;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Location = new System.Drawing.Point(956, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(26, 20);
            this.btnDel.TabIndex = 42;
            this.btnDel.Text = "&-";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ucStandardProzeduren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnDel);
            this.Name = "ucStandardProzeduren";
            this.Size = new System.Drawing.Size(986, 469);
            this.Load += new System.EventHandler(this.ucStandardProzeduren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsStandardProzeduren1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.Data.Global.dsStandardProzeduren dsStandardProzeduren1;
        private ucButton btnDel;
        private QS2.Desktop.ControlManagment.BaseGrid grid;
    }
}
