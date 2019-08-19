namespace PMDS.GUI
{
    partial class ucProtDetail
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Protokoll in die Zwischenablage kopieren", Infragistics.Win.ToolTipImage.Default, "Kopieren", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zusätzlicheRechnungsfelderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrechungsprotokollTabellenansicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelText = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtProtokoll2 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.panelCenter = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.UFormLinkZurücksetzen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelBottomRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnZurück = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelText.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelUnten.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zusätzlicheRechnungsfelderToolStripMenuItem,
            this.abrechungsprotokollTabellenansicToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(272, 48);
            // 
            // zusätzlicheRechnungsfelderToolStripMenuItem
            // 
            this.zusätzlicheRechnungsfelderToolStripMenuItem.Name = "zusätzlicheRechnungsfelderToolStripMenuItem";
            this.zusätzlicheRechnungsfelderToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.zusätzlicheRechnungsfelderToolStripMenuItem.Text = "Zusätzliche Rechnungsfelder";
            this.zusätzlicheRechnungsfelderToolStripMenuItem.Click += new System.EventHandler(this.zusätzlicheRechnungsfelderToolStripMenuItem_Click);
            // 
            // abrechungsprotokollTabellenansicToolStripMenuItem
            // 
            this.abrechungsprotokollTabellenansicToolStripMenuItem.Name = "abrechungsprotokollTabellenansicToolStripMenuItem";
            this.abrechungsprotokollTabellenansicToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.abrechungsprotokollTabellenansicToolStripMenuItem.Text = "Abrechnungsprotokoll Tabellenansicht";
            this.abrechungsprotokollTabellenansicToolStripMenuItem.Click += new System.EventHandler(this.abrechungsprotokollTabellenansicToolStripMenuItem_Click);
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAll.Controls.Add(this.panelText);
            this.panelAll.Controls.Add(this.panelCenter);
            this.panelAll.Controls.Add(this.panelUnten);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(445, 276);
            this.panelAll.TabIndex = 4;
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.txtProtokoll2);
            this.panelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelText.Location = new System.Drawing.Point(0, 26);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(445, 221);
            this.panelText.TabIndex = 10;
            // 
            // txtProtokoll2
            // 
            this.txtProtokoll2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            this.txtProtokoll2.Appearance = appearance1;
            this.txtProtokoll2.ContextMenuStrip = this.contextMenuStrip1;
            this.txtProtokoll2.Location = new System.Drawing.Point(4, 2);
            this.txtProtokoll2.Name = "txtProtokoll2";
            this.txtProtokoll2.Size = new System.Drawing.Size(437, 216);
            this.txtProtokoll2.TabIndex = 1;
            this.txtProtokoll2.Value = "";
            this.txtProtokoll2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProtokoll2_KeyPress);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Controls.Add(this.lblTitel);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(445, 26);
            this.panelCenter.TabIndex = 9;
            // 
            // lblTitel
            // 
            this.lblTitel.Location = new System.Drawing.Point(5, 6);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(485, 14);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = " Detailiertes Protokoll zur Abrechnung";
            // 
            // panelUnten
            // 
            this.panelUnten.Controls.Add(this.UFormLinkZurücksetzen);
            this.panelUnten.Controls.Add(this.panelBottomRight);
            this.panelUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUnten.Location = new System.Drawing.Point(0, 247);
            this.panelUnten.Name = "panelUnten";
            this.panelUnten.Size = new System.Drawing.Size(445, 29);
            this.panelUnten.TabIndex = 3;
            // 
            // UFormLinkZurücksetzen
            // 
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.FontData.SizeInPoints = 8F;
            appearance2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UFormLinkZurücksetzen.Appearance = appearance2;
            this.UFormLinkZurücksetzen.AutoSize = true;
            appearance3.FontData.UnderlineAsString = "True";
            this.UFormLinkZurücksetzen.HotTrackAppearance = appearance3;
            this.UFormLinkZurücksetzen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UFormLinkZurücksetzen.Location = new System.Drawing.Point(5, 1);
            this.UFormLinkZurücksetzen.Name = "UFormLinkZurücksetzen";
            this.UFormLinkZurücksetzen.Size = new System.Drawing.Size(48, 14);
            this.UFormLinkZurücksetzen.TabIndex = 7;
            this.UFormLinkZurücksetzen.Text = "Kopieren";
            ultraToolTipInfo1.ToolTipText = "Protokoll in die Zwischenablage kopieren";
            ultraToolTipInfo1.ToolTipTitle = "Kopieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.UFormLinkZurücksetzen, ultraToolTipInfo1);
            this.UFormLinkZurücksetzen.UseAppStyling = false;
            this.UFormLinkZurücksetzen.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UFormLinkZurücksetzen.Click += new System.EventHandler(this.UFormLinkZurücksetzen_Click);
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.btnClose);
            this.panelBottomRight.Controls.Add(this.btnZurück);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBottomRight.Location = new System.Drawing.Point(203, 0);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(242, 29);
            this.panelBottomRight.TabIndex = 6;
            // 
            // btnClose
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance4;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(172, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 24);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnZurück
            // 
            this.btnZurück.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZurück.AutoWorkLayout = false;
            this.btnZurück.IsStandardControl = false;
            this.btnZurück.Location = new System.Drawing.Point(114, 1);
            this.btnZurück.Name = "btnZurück";
            this.btnZurück.Size = new System.Drawing.Size(57, 24);
            this.btnZurück.TabIndex = 5;
            this.btnZurück.Text = "Zurück";
            this.btnZurück.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucProtDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panelAll);
            this.Name = "ucProtDetail";
            this.Size = new System.Drawing.Size(445, 276);
            this.Load += new System.EventHandler(this.frmInfoProt_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelText.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelUnten.ResumeLayout(false);
            this.panelUnten.PerformLayout();
            this.panelBottomRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BasePanel panelBottomRight;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelText;
        private QS2.Desktop.ControlManagment.BasePanel panelCenter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrechungsprotokollTabellenansicToolStripMenuItem;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtProtokoll2;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        public QS2.Desktop.ControlManagment.BaseButton btnZurück;
        private System.Windows.Forms.ToolStripMenuItem zusätzlicheRechnungsfelderToolStripMenuItem;
        internal QS2.Desktop.ControlManagment.BaseLabel UFormLinkZurücksetzen;
        public QS2.Desktop.ControlManagment.BaseLabel lblTitel;
    }
}