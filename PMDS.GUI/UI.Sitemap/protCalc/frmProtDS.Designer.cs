namespace PMDS.Global
{
    partial class frmProtDS
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Spalte kopieren", Infragistics.Win.ToolTipImage.Default, "Kopieren", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panel5 = new QS2.Desktop.ControlManagment.BasePanel();
            this.cboDB = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSpalteKopieren = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel6 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panel4 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraGrid1 = new QS2.Desktop.ControlManagment.BaseGrid();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboDB);
            this.panel5.Controls.Add(this.ultraLabel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(311, 29);
            this.panel5.TabIndex = 17;
            // 
            // cboDB
            // 
            this.cboDB.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboDB.Location = new System.Drawing.Point(106, 5);
            this.cboDB.Name = "cboDB";
            this.cboDB.Size = new System.Drawing.Size(197, 21);
            this.cboDB.TabIndex = 12;
            this.cboDB.ValueChanged += new System.EventHandler(this.cboDB_ValueChanged);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(6, 9);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(197, 16);
            this.ultraLabel3.TabIndex = 11;
            this.ultraLabel3.Text = "Tabelle auswählen";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSpalteKopieren);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 37);
            this.panel2.TabIndex = 1;
            // 
            // btnSpalteKopieren
            // 
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 8F;
            appearance1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSpalteKopieren.Appearance = appearance1;
            this.btnSpalteKopieren.AutoSize = true;
            appearance2.FontData.UnderlineAsString = "True";
            this.btnSpalteKopieren.HotTrackAppearance = appearance2;
            this.btnSpalteKopieren.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSpalteKopieren.Location = new System.Drawing.Point(7, 11);
            this.btnSpalteKopieren.Name = "btnSpalteKopieren";
            this.btnSpalteKopieren.Size = new System.Drawing.Size(48, 14);
            this.btnSpalteKopieren.TabIndex = 8;
            this.btnSpalteKopieren.Text = "Kopieren";
            ultraToolTipInfo1.ToolTipText = "Spalte kopieren";
            ultraToolTipInfo1.ToolTipTitle = "Kopieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnSpalteKopieren, ultraToolTipInfo1);
            this.btnSpalteKopieren.UseAppStyling = false;
            this.btnSpalteKopieren.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSpalteKopieren.Click += new System.EventHandler(this.btnSpalteKopieren_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnClose2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(670, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(120, 37);
            this.panel6.TabIndex = 7;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.Location = new System.Drawing.Point(45, 6);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(70, 24);
            this.btnClose2.TabIndex = 6;
            this.btnClose2.Text = "Schließen";
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 488);
            this.panel3.TabIndex = 2;
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.panel4);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(800, 488);
            this.ultraGridBagLayoutPanelAll.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.panel4, gridBagConstraint2);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.panel4, new System.Drawing.Size(492, 328));
            this.panel4.Size = new System.Drawing.Size(790, 478);
            this.panel4.TabIndex = 2;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGrid1);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(790, 412);
            this.ultraGridBagLayoutPanel1.TabIndex = 0;
            // 
            // ultraGrid1
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Appearance = appearance3;
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 1;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGrid1, gridBagConstraint1);
            this.ultraGrid1.Location = new System.Drawing.Point(5, 1);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGrid1, new System.Drawing.Size(550, 80));
            this.ultraGrid1.Size = new System.Drawing.Size(780, 406);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "Tabellenname";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // frmProtDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(816, 524);
            this.Name = "frmProtDS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Abrechnung";
            this.Load += new System.EventHandler(this.frmProtDS_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BasePanel panel2;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BaseGrid ultraGrid1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        private QS2.Desktop.ControlManagment.BasePanel panel4;
        private QS2.Desktop.ControlManagment.BasePanel panel5;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboDB;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        private QS2.Desktop.ControlManagment.BaseButton btnClose2;
        private QS2.Desktop.ControlManagment.BasePanel panel6;
        internal Infragistics.Win.Misc.UltraLabel btnSpalteKopieren;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}