namespace PMDS.Calc.UI.Admin
{
    partial class ucTransferzahlKlient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransferzahlKlient));
            this.ultraGroupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.grpPensionSonstiges = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPatientenEinkommen1 = new PMDS.Calc.UI.Admin.ucTransferzahlKlientGrid();
            this.grpTransferleistungen = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPatientenEinkommen2 = new PMDS.Calc.UI.Admin.ucTransferzahlKlientGrid();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblZeitraumVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpTo = new PMDS.GUI.dtCombo(this.components);
            this.dtpFrom = new PMDS.GUI.dtCombo(this.components);
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPensionSonstiges)).BeginInit();
            this.grpPensionSonstiges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTransferleistungen)).BeginInit();
            this.grpTransferleistungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Location = new System.Drawing.Point(2, 304);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(212, 78);
            this.ultraGroupBox1.TabIndex = 8;
            this.ultraGroupBox1.Text = "Pflegegeld";
            this.ultraGroupBox1.Visible = false;
            // 
            // grpPensionSonstiges
            // 
            this.grpPensionSonstiges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.grpPensionSonstiges.Appearance = appearance1;
            this.grpPensionSonstiges.Controls.Add(this.ultraLabel4);
            this.grpPensionSonstiges.Controls.Add(this.ucPatientenEinkommen1);
            this.grpPensionSonstiges.Location = new System.Drawing.Point(6, 0);
            this.grpPensionSonstiges.Name = "grpPensionSonstiges";
            this.grpPensionSonstiges.Size = new System.Drawing.Size(820, 197);
            this.grpPensionSonstiges.TabIndex = 6;
            this.grpPensionSonstiges.Text = "Pension / Sonstiges";
            // 
            // ultraLabel4
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.Location = new System.Drawing.Point(6, 17);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(645, 18);
            this.ultraLabel4.TabIndex = 8;
            this.ultraLabel4.Text = "Definieren Sie hier Zahlungsschemen für Kostenträger, die Beträge nach Rechnungsl" +
    "egung überweisen.";
            // 
            // ucPatientenEinkommen1
            // 
            this.ucPatientenEinkommen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPatientenEinkommen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPatientenEinkommen1.Location = new System.Drawing.Point(9, 17);
            this.ucPatientenEinkommen1.Name = "ucPatientenEinkommen1";
            this.ucPatientenEinkommen1.Size = new System.Drawing.Size(805, 174);
            this.ucPatientenEinkommen1.TabIndex = 7;
            this.ucPatientenEinkommen1.Transferleistung = false;
            this.ucPatientenEinkommen1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            // 
            // grpTransferleistungen
            // 
            this.grpTransferleistungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.grpTransferleistungen.Appearance = appearance3;
            this.grpTransferleistungen.Controls.Add(this.lblInfo);
            this.grpTransferleistungen.Controls.Add(this.ucPatientenEinkommen2);
            this.grpTransferleistungen.Location = new System.Drawing.Point(6, 0);
            this.grpTransferleistungen.Name = "grpTransferleistungen";
            this.grpTransferleistungen.Size = new System.Drawing.Size(820, 205);
            this.grpTransferleistungen.TabIndex = 4;
            this.grpTransferleistungen.Text = "Transferleistungen";
            // 
            // lblInfo
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Appearance = appearance4;
            this.lblInfo.Location = new System.Drawing.Point(9, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(504, 18);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Erfassen Sie hier alle Zahlungen von Stellen, die Beträge ohne Rechnungslegung übe" +
    "rweisen.";
            // 
            // ucPatientenEinkommen2
            // 
            this.ucPatientenEinkommen2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPatientenEinkommen2.BackColor = System.Drawing.Color.Transparent;
            this.ucPatientenEinkommen2.Location = new System.Drawing.Point(9, 16);
            this.ucPatientenEinkommen2.Name = "ucPatientenEinkommen2";
            this.ucPatientenEinkommen2.Size = new System.Drawing.Size(805, 183);
            this.ucPatientenEinkommen2.TabIndex = 6;
            this.ucPatientenEinkommen2.Transferleistung = true;
            this.ucPatientenEinkommen2.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            // 
            // btnSearch
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance5;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(272, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TabStop = false;
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(168, 5);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(19, 14);
            this.lblBis.TabIndex = 18;
            this.lblBis.Text = "bis";
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.AutoSize = true;
            this.lblZeitraumVon.Location = new System.Drawing.Point(11, 5);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(73, 14);
            this.lblZeitraumVon.TabIndex = 16;
            this.lblZeitraumVon.Text = "Zeitraum  von";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtpTo
            // 
            this.errorProvider1.SetIconAlignment(this.dtpTo, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.dtpTo.Location = new System.Drawing.Point(191, 2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(79, 21);
            this.dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.errorProvider1.SetIconAlignment(this.dtpFrom, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.dtpFrom.Location = new System.Drawing.Point(86, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(79, 21);
            this.dtpFrom.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 437);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.ultraGroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 412);
            this.panel2.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpTransferleistungen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.grpPensionSonstiges);
            this.splitContainer1.Size = new System.Drawing.Size(832, 412);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 10;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.dtpTo);
            this.panelTop.Controls.Add(this.dtpFrom);
            this.panelTop.Controls.Add(this.lblZeitraumVon);
            this.panelTop.Controls.Add(this.lblBis);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(832, 25);
            this.panelTop.TabIndex = 21;
            this.panelTop.Visible = false;
            // 
            // ucTransferzahlKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucTransferzahlKlient";
            this.Size = new System.Drawing.Size(832, 437);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPensionSonstiges)).EndInit();
            this.grpPensionSonstiges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTransferleistungen)).EndInit();
            this.grpTransferleistungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBox1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpPensionSonstiges;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpTransferleistungen;
        private ucTransferzahlKlientGrid ucPatientenEinkommen1;
        private ucTransferzahlKlientGrid ucPatientenEinkommen2;
        private PMDS.GUI.ucButton btnSearch;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitraumVon;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PMDS.GUI.dtCombo dtpTo;
        private PMDS.GUI.dtCombo dtpFrom;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BasePanel panel2;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
