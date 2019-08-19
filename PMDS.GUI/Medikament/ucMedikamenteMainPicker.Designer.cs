namespace PMDS.GUI
{
    partial class ucMedikamenteMainPicker
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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panelKlienten = new System.Windows.Forms.Panel();
            this.panelKlientenInner = new System.Windows.Forms.Panel();
            this.treeKlienten = new Infragistics.Win.UltraWinTree.UltraTree();
            this.contextMenuKlientenPicker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.cbMehrfachSelection = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelMedikamenteStammdaten = new System.Windows.Forms.Panel();
            this.dsControls1 = new QS2.Desktop.ControlManagment.dsControls();
            this.lblinfoNoKlientSelected = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelKlienten.SuspendLayout();
            this.panelKlientenInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeKlienten)).BeginInit();
            this.contextMenuKlientenPicker.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMehrfachSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsControls1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelKlienten
            // 
            this.panelKlienten.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelKlienten.Controls.Add(this.panelKlientenInner);
            this.panelKlienten.Controls.Add(this.panelBottom);
            this.panelKlienten.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelKlienten.Location = new System.Drawing.Point(0, 0);
            this.panelKlienten.Name = "panelKlienten";
            this.panelKlienten.Size = new System.Drawing.Size(188, 609);
            this.panelKlienten.TabIndex = 2;
            // 
            // panelKlientenInner
            // 
            this.panelKlientenInner.BackColor = System.Drawing.Color.Transparent;
            this.panelKlientenInner.Controls.Add(this.treeKlienten);
            this.panelKlientenInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKlientenInner.Location = new System.Drawing.Point(0, 0);
            this.panelKlientenInner.Name = "panelKlientenInner";
            this.panelKlientenInner.Size = new System.Drawing.Size(188, 569);
            this.panelKlientenInner.TabIndex = 3;
            // 
            // treeKlienten
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.SizeInPoints = 10F;
            this.treeKlienten.Appearance = appearance1;
            this.treeKlienten.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.treeKlienten.ContextMenuStrip = this.contextMenuKlientenPicker;
            this.treeKlienten.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista;
            this.treeKlienten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeKlienten.ExpansionIndicatorSize = new System.Drawing.Size(-1, -5);
            this.treeKlienten.HideSelection = false;
            this.treeKlienten.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treeKlienten.Location = new System.Drawing.Point(0, 0);
            this.treeKlienten.Name = "treeKlienten";
            this.treeKlienten.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            _override1.HotTracking = Infragistics.Win.DefaultableBoolean.True;
            _override1.NodeSpacingBefore = 7;
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            _override1.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Show;
            this.treeKlienten.Override = _override1;
            this.treeKlienten.Size = new System.Drawing.Size(188, 569);
            this.treeKlienten.TabIndex = 1;
            this.treeKlienten.UseAppStyling = false;
            this.treeKlienten.Click += new System.EventHandler(this.treeKlienten_Click);
            this.treeKlienten.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeKlienten_MouseClick);
            // 
            // contextMenuKlientenPicker
            // 
            this.contextMenuKlientenPicker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleToolStripMenuItem,
            this.keineToolStripMenuItem});
            this.contextMenuKlientenPicker.Name = "contextMenuStrip1";
            this.contextMenuKlientenPicker.Size = new System.Drawing.Size(104, 48);
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
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.cbMehrfachSelection);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 569);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(188, 40);
            this.panelBottom.TabIndex = 2;
            // 
            // cbMehrfachSelection
            // 
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cbMehrfachSelection.Appearance = appearance2;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.UnderlineAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cbMehrfachSelection.HotTrackingAppearance = appearance3;
            this.cbMehrfachSelection.Location = new System.Drawing.Point(15, 18);
            this.cbMehrfachSelection.Name = "cbMehrfachSelection";
            this.cbMehrfachSelection.Size = new System.Drawing.Size(116, 16);
            this.cbMehrfachSelection.TabIndex = 13;
            this.cbMehrfachSelection.Text = "Mehrfachauswahl";
            this.cbMehrfachSelection.CheckedChanged += new System.EventHandler(this.cbMehrfachSelection_CheckedChanged);
            // 
            // panelMedikamenteStammdaten
            // 
            this.panelMedikamenteStammdaten.BackColor = System.Drawing.Color.Transparent;
            this.panelMedikamenteStammdaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMedikamenteStammdaten.Location = new System.Drawing.Point(188, 0);
            this.panelMedikamenteStammdaten.Name = "panelMedikamenteStammdaten";
            this.panelMedikamenteStammdaten.Size = new System.Drawing.Size(848, 609);
            this.panelMedikamenteStammdaten.TabIndex = 3;
            // 
            // dsControls1
            // 
            this.dsControls1.DataSetName = "dsControls";
            this.dsControls1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblinfoNoKlientSelected
            // 
            appearance4.ForeColor = System.Drawing.Color.Gray;
            this.lblinfoNoKlientSelected.Appearance = appearance4;
            this.lblinfoNoKlientSelected.AutoSize = true;
            this.lblinfoNoKlientSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblinfoNoKlientSelected.Location = new System.Drawing.Point(511, 275);
            this.lblinfoNoKlientSelected.Name = "lblinfoNoKlientSelected";
            this.lblinfoNoKlientSelected.Size = new System.Drawing.Size(202, 17);
            this.lblinfoNoKlientSelected.TabIndex = 163;
            this.lblinfoNoKlientSelected.Text = "Es wurde kein Klient ausgewählt";
            // 
            // ucMedikamenteMainPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelMedikamenteStammdaten);
            this.Controls.Add(this.lblinfoNoKlientSelected);
            this.Controls.Add(this.panelKlienten);
            this.Name = "ucMedikamenteMainPicker";
            this.Size = new System.Drawing.Size(1036, 609);
            this.Load += new System.EventHandler(this.ucMedikamenteMainPicker_Load);
            this.VisibleChanged += new System.EventHandler(this.ucMedikamenteMainPicker_VisibleChanged);
            this.panelKlienten.ResumeLayout(false);
            this.panelKlientenInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeKlienten)).EndInit();
            this.contextMenuKlientenPicker.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbMehrfachSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsControls1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelKlienten;
        private System.Windows.Forms.Panel panelKlientenInner;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMedikamenteStammdaten;
        private QS2.Desktop.ControlManagment.dsControls dsControls1;
        protected Infragistics.Win.UltraWinTree.UltraTree treeKlienten;
        private System.Windows.Forms.ContextMenuStrip contextMenuKlientenPicker;
        private QS2.Desktop.ControlManagment.BaseLabel lblinfoNoKlientSelected;
        public QS2.Desktop.ControlManagment.BaseCheckBox cbMehrfachSelection;
        public System.Windows.Forms.ToolStripMenuItem keineToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem alleToolStripMenuItem;
    }
}
