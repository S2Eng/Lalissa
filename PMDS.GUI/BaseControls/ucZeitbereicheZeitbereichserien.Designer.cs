namespace PMDS.GUI.BaseControls
{
    partial class ucZeitbereicheZeitbereichserien
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Zeitbereich", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bis");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ZeitbereichSerien", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich0");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich6");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich7");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.dgZeitbereich = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dgZeitbereichserien = new QS2.Desktop.ControlManagment.BaseGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgZeitbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgZeitbereichserien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgZeitbereich
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZeitbereich.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(259, 0);
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "hh:mm";
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "hh:mm";
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            ultraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgZeitbereich.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance2.BackColor = System.Drawing.Color.DarkGray;
            this.dgZeitbereich.DisplayLayout.CaptionAppearance = appearance2;
            this.dgZeitbereich.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.dgZeitbereich.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            appearance3.BackColor = System.Drawing.Color.Gainsboro;
            this.dgZeitbereich.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.dgZeitbereich.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance4.BackColor = System.Drawing.Color.Gainsboro;
            this.dgZeitbereich.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            this.dgZeitbereich.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgZeitbereich.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgZeitbereich.Location = new System.Drawing.Point(0, 0);
            this.dgZeitbereich.Name = "dgZeitbereich";
            this.dgZeitbereich.Size = new System.Drawing.Size(828, 261);
            this.dgZeitbereich.TabIndex = 1;
            this.dgZeitbereich.Text = "Zeitbereiche";
            this.dgZeitbereich.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dgZeitbereich.AfterRowsDeleted += new System.EventHandler(this.dgZeitbereich_AfterRowsDeleted);
            this.dgZeitbereich.InitializeTemplateAddRow += new Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler(this.dgZeitbereich_InitializeTemplateAddRow);
            this.dgZeitbereich.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgZeitbereich_BeforeRowsDeleted);
            this.dgZeitbereich.Enter += new System.EventHandler(this.dgZeitbereich_Enter);
            this.dgZeitbereich.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgZeitbereich_AfterRowUpdate);
            // 
            // dgZeitbereichserien
            // 
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZeitbereichserien.DisplayLayout.Appearance = appearance5;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(168, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Header.Caption = "Z0";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Header.Caption = "Z1";
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Header.Caption = "Z2";
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.Header.Caption = "Z3";
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.Header.Caption = "Z4";
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 7;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Header.Caption = "Z5";
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.Header.Caption = "Z6";
            ultraGridColumn13.Header.VisiblePosition = 8;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 9;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.Header.Caption = "Z7";
            ultraGridColumn14.Header.VisiblePosition = 9;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgZeitbereichserien.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            appearance6.BackColor = System.Drawing.Color.DarkGray;
            this.dgZeitbereichserien.DisplayLayout.CaptionAppearance = appearance6;
            this.dgZeitbereichserien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            appearance7.BackColor = System.Drawing.Color.Gainsboro;
            this.dgZeitbereichserien.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.dgZeitbereichserien.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance8.BackColor = System.Drawing.Color.Gainsboro;
            this.dgZeitbereichserien.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.dgZeitbereichserien.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgZeitbereichserien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgZeitbereichserien.Location = new System.Drawing.Point(0, 261);
            this.dgZeitbereichserien.Name = "dgZeitbereichserien";
            this.dgZeitbereichserien.Size = new System.Drawing.Size(828, 261);
            this.dgZeitbereichserien.TabIndex = 2;
            this.dgZeitbereichserien.Text = "Zeitbereichserien";
            this.dgZeitbereichserien.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dgZeitbereichserien.AfterRowsDeleted += new System.EventHandler(this.dgZeitbereichserien_AfterRowsDeleted);
            this.dgZeitbereichserien.InitializeTemplateAddRow += new Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler(this.dgZeitbereichserien_InitializeTemplateAddRow);
            this.dgZeitbereichserien.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgZeitbereichserien_BeforeRowsDeleted);
            this.dgZeitbereichserien.Enter += new System.EventHandler(this.dgZeitbereichserien_Enter);
            this.dgZeitbereichserien.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgZeitbereichserien_AfterRowUpdate);
            // 
            // ucZeitbereicheZeitbereichserien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgZeitbereichserien);
            this.Controls.Add(this.dgZeitbereich);
            this.Name = "ucZeitbereicheZeitbereichserien";
            this.Size = new System.Drawing.Size(828, 522);
            ((System.ComponentModel.ISupportInitialize)(this.dgZeitbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgZeitbereichserien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseGrid dgZeitbereich;
        private QS2.Desktop.ControlManagment.BaseGrid dgZeitbereichserien;

    }
}
