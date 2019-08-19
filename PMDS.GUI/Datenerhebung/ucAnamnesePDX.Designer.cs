namespace PMDS.GUI
{
    partial class ucAnamnesePDX
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.pnlRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlRButtom = new QS2.Desktop.ControlManagment.BasePanel();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbResourcen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnPDXPlanen = new QS2.Desktop.ControlManagment.BaseButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlRTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lvPDX)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlRButtom.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResourcen)).BeginInit();
            this.pnlRTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPDX
            // 
            this.lvPDX.Dock = System.Windows.Forms.DockStyle.None;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.lvPDX, gridBagConstraint1);
            appearance1.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPDX.ItemSettings.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPDX.ItemSettings.SelectedAppearance = appearance2;
            this.lvPDX.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvPDX.Location = new System.Drawing.Point(5, 5);
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.lvPDX, new System.Drawing.Size(351, 249));
            this.lvPDX.Size = new System.Drawing.Size(516, 406);
            this.lvPDX.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvPDX.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvPDX.ViewSettingsList.MultiColumn = false;
            this.lvPDX.ItemSelectionChanged += new Infragistics.Win.UltraWinListView.ItemSelectionChangedEventHandler(this.lvPDX_ItemSelectionChanged);
            this.lvPDX.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.lvPDX_ItemCheckStateChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlRButtom);
            this.pnlRight.Controls.Add(this.splitter2);
            this.pnlRight.Controls.Add(this.pnlRTop);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(529, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(251, 416);
            this.pnlRight.TabIndex = 3;
            // 
            // pnlRButtom
            // 
            this.pnlRButtom.AutoScroll = true;
            this.pnlRButtom.Controls.Add(this.panel3);
            this.pnlRButtom.Controls.Add(this.btnPDXPlanen);
            this.pnlRButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRButtom.Location = new System.Drawing.Point(0, 180);
            this.pnlRButtom.Name = "pnlRButtom";
            this.pnlRButtom.Size = new System.Drawing.Size(251, 236);
            this.pnlRButtom.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblInfo);
            this.panel3.Controls.Add(this.tbResourcen);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 163);
            this.panel3.TabIndex = 8;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(3, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(237, 36);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Ressourcen zu ...";
            // 
            // tbResourcen
            // 
            this.tbResourcen.AcceptsReturn = true;
            this.tbResourcen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbResourcen.Appearance = appearance3;
            this.tbResourcen.BackColor = System.Drawing.SystemColors.Window;
            this.tbResourcen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResourcen.Location = new System.Drawing.Point(5, 44);
            this.tbResourcen.MaxLength = 2048;
            this.tbResourcen.Multiline = true;
            this.tbResourcen.Name = "tbResourcen";
            this.tbResourcen.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbResourcen.Size = new System.Drawing.Size(238, 116);
            this.tbResourcen.TabIndex = 3;
            this.tbResourcen.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.tbResourcen.Leave += new System.EventHandler(this.tbResourcen_Leave);
            // 
            // btnPDXPlanen
            // 
            this.btnPDXPlanen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPDXPlanen.Enabled = false;
            this.btnPDXPlanen.Location = new System.Drawing.Point(5, 27);
            this.btnPDXPlanen.Name = "btnPDXPlanen";
            this.btnPDXPlanen.Size = new System.Drawing.Size(235, 30);
            this.btnPDXPlanen.TabIndex = 7;
            this.btnPDXPlanen.Text = "PD \"{0}\" jetzt planen";
            this.btnPDXPlanen.Visible = false;
            this.btnPDXPlanen.Click += new System.EventHandler(this.btnPDXPlanen_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 177);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(251, 3);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // pnlRTop
            // 
            this.pnlRTop.AutoScroll = true;
            this.pnlRTop.Controls.Add(this.lblBeschreibung);
            this.pnlRTop.Controls.Add(this.ultraLabel1);
            this.pnlRTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRTop.Location = new System.Drawing.Point(0, 0);
            this.pnlRTop.Name = "pnlRTop";
            this.pnlRTop.Size = new System.Drawing.Size(251, 177);
            this.pnlRTop.TabIndex = 5;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeschreibung.Location = new System.Drawing.Point(17, 17);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(214, 129);
            this.lblBeschreibung.TabIndex = 7;
            this.lblBeschreibung.Text = "PDx....";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(5, 3);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(55, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Definition:";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(526, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 416);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.lvPDX);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(526, 416);
            this.ultraGridBagLayoutPanel1.TabIndex = 5;
            // 
            // ucAnamnesePDX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlRight);
            this.Name = "ucAnamnesePDX";
            this.Size = new System.Drawing.Size(780, 416);
            this.Load += new System.EventHandler(this.ucAnamnesePDX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvPDX)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRButtom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResourcen)).EndInit();
            this.pnlRTop.ResumeLayout(false);
            this.pnlRTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlRight;
        private System.Windows.Forms.Splitter splitter1;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
        private QS2.Desktop.ControlManagment.BasePanel pnlRTop;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbResourcen;
        private QS2.Desktop.ControlManagment.BaseButton btnPDXPlanen;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private QS2.Desktop.ControlManagment.BasePanel pnlRButtom;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;




    }
}
