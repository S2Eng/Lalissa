namespace PMDS.GUI
{
    partial class ucKlienten
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
            this.cbAllgemeineKostenträger = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblTitelKlienten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelUntenButt = new QS2.Desktop.ControlManagment.BasePanel();
            this.uButtonAlleKeine = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelSuche = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkNurSelbstzahlerJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnSearchKlienten = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblNameKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKlient = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dtBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAllgemeineKostenträger = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbAllgemeineKostenträger)).BeginInit();
            this.panelUntenButt.SuspendLayout();
            this.panelSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurSelbstzahlerJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAllgemeineKostenträger
            // 
            this.cbAllgemeineKostenträger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllgemeineKostenträger.AutoSize = false;
            this.cbAllgemeineKostenträger.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
            this.cbAllgemeineKostenträger.Location = new System.Drawing.Point(7, 57);
            this.cbAllgemeineKostenträger.Name = "cbAllgemeineKostenträger";
            this.cbAllgemeineKostenträger.Size = new System.Drawing.Size(277, 21);
            this.cbAllgemeineKostenträger.TabIndex = 0;
            this.cbAllgemeineKostenträger.ValueChanged += new System.EventHandler(this.cbAllgemeineKostenträger_ValueChanged);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(292, 396);
            // 
            // lblTitelKlienten
            // 
            this.lblTitelKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.TextHAlignAsString = "Right";
            this.lblTitelKlienten.Appearance = appearance1;
            this.lblTitelKlienten.Location = new System.Drawing.Point(185, 8);
            this.lblTitelKlienten.Name = "lblTitelKlienten";
            this.lblTitelKlienten.Size = new System.Drawing.Size(99, 14);
            this.lblTitelKlienten.TabIndex = 0;
            // 
            // panelUntenButt
            // 
            this.panelUntenButt.BackColor = System.Drawing.Color.Transparent;
            this.panelUntenButt.Controls.Add(this.uButtonAlleKeine);
            this.panelUntenButt.Controls.Add(this.lblTitelKlienten);
            this.panelUntenButt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUntenButt.Location = new System.Drawing.Point(0, 297);
            this.panelUntenButt.Name = "panelUntenButt";
            this.panelUntenButt.Size = new System.Drawing.Size(289, 28);
            this.panelUntenButt.TabIndex = 8;
            // 
            // uButtonAlleKeine
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButtonAlleKeine.Appearance = appearance2;
            this.uButtonAlleKeine.AutoWorkLayout = false;
            this.uButtonAlleKeine.IsStandardControl = false;
            this.uButtonAlleKeine.Location = new System.Drawing.Point(3, 3);
            this.uButtonAlleKeine.Name = "uButtonAlleKeine";
            this.uButtonAlleKeine.Size = new System.Drawing.Size(46, 20);
            this.uButtonAlleKeine.TabIndex = 48;
            this.uButtonAlleKeine.Tag = "A";
            this.uButtonAlleKeine.Text = "Alle";
            this.uButtonAlleKeine.Click += new System.EventHandler(this.uButtonAlleKeine2_Click);
            // 
            // panelSuche
            // 
            this.panelSuche.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSuche.Controls.Add(this.chkNurSelbstzahlerJN);
            this.panelSuche.Controls.Add(this.btnSearchKlienten);
            this.panelSuche.Controls.Add(this.lblNameKlient);
            this.panelSuche.Controls.Add(this.txtKlient);
            this.panelSuche.Controls.Add(this.dtBis);
            this.panelSuche.Controls.Add(this.dtVon);
            this.panelSuche.Controls.Add(this.lblBis);
            this.panelSuche.Controls.Add(this.lblVon);
            this.panelSuche.Controls.Add(this.cbAllgemeineKostenträger);
            this.panelSuche.Controls.Add(this.lblAllgemeineKostenträger);
            this.panelSuche.Controls.Add(this.ultraLabel3);
            this.panelSuche.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuche.Location = new System.Drawing.Point(0, 0);
            this.panelSuche.Name = "panelSuche";
            this.panelSuche.Size = new System.Drawing.Size(289, 161);
            this.panelSuche.TabIndex = 14;
            // 
            // chkNurSelbstzahlerJN
            // 
            this.chkNurSelbstzahlerJN.Location = new System.Drawing.Point(7, 84);
            this.chkNurSelbstzahlerJN.Name = "chkNurSelbstzahlerJN";
            this.chkNurSelbstzahlerJN.Size = new System.Drawing.Size(127, 14);
            this.chkNurSelbstzahlerJN.TabIndex = 164;
            this.chkNurSelbstzahlerJN.Text = "Nur Selbstzahler";
            this.chkNurSelbstzahlerJN.CheckedChanged += new System.EventHandler(this.chkNurSelbstzahlerJN_CheckedChanged);
            // 
            // btnSearchKlienten
            // 
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearchKlienten.Appearance = appearance3;
            this.btnSearchKlienten.AutoWorkLayout = false;
            this.btnSearchKlienten.IsStandardControl = false;
            this.btnSearchKlienten.Location = new System.Drawing.Point(116, 109);
            this.btnSearchKlienten.Name = "btnSearchKlienten";
            this.btnSearchKlienten.Size = new System.Drawing.Size(65, 34);
            this.btnSearchKlienten.TabIndex = 10;
            this.btnSearchKlienten.Tag = "";
            this.btnSearchKlienten.Text = "Suche";
            this.btnSearchKlienten.Visible = false;
            this.btnSearchKlienten.Click += new System.EventHandler(this.btnSearchKlienten_Click);
            // 
            // lblNameKlient
            // 
            this.lblNameKlient.AutoSize = true;
            this.lblNameKlient.Location = new System.Drawing.Point(5, 4);
            this.lblNameKlient.Name = "lblNameKlient";
            this.lblNameKlient.Size = new System.Drawing.Size(115, 14);
            this.lblNameKlient.TabIndex = 154;
            this.lblNameKlient.Text = "Klient (Familienname)";
            // 
            // txtKlient
            // 
            this.txtKlient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKlient.Location = new System.Drawing.Point(7, 19);
            this.txtKlient.Name = "txtKlient";
            this.txtKlient.Size = new System.Drawing.Size(277, 21);
            this.txtKlient.TabIndex = 1;
            this.txtKlient.ValueChanged += new System.EventHandler(this.txtKlient_ValueChanged);
            // 
            // dtBis
            // 
            appearance4.TextHAlignAsString = "Center";
            this.dtBis.Appearance = appearance4;
            this.dtBis.DateTime = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtBis.Location = new System.Drawing.Point(33, 126);
            this.dtBis.MaskInput = "{LOC}mm.yyyy";
            this.dtBis.Name = "dtBis";
            this.dtBis.ownFormat = "";
            this.dtBis.ownMaskInput = "";
            this.dtBis.Size = new System.Drawing.Size(76, 21);
            this.dtBis.TabIndex = 3;
            this.dtBis.Value = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtBis.ValueChanged += new System.EventHandler(this.dtBis_ValueChanged);
            // 
            // dtVon
            // 
            appearance5.TextHAlignAsString = "Center";
            this.dtVon.Appearance = appearance5;
            this.dtVon.DateTime = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtVon.Location = new System.Drawing.Point(33, 103);
            this.dtVon.MaskInput = "{LOC}mm.yyyy";
            this.dtVon.Name = "dtVon";
            this.dtVon.ownFormat = "";
            this.dtVon.ownMaskInput = "";
            this.dtVon.Size = new System.Drawing.Size(76, 21);
            this.dtVon.TabIndex = 2;
            this.dtVon.Value = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtVon.ValueChanged += new System.EventHandler(this.dtVon_ValueChanged);
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(7, 129);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(27, 15);
            this.lblBis.TabIndex = 8;
            this.lblBis.Text = "bis";
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(7, 107);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(27, 15);
            this.lblVon.TabIndex = 7;
            this.lblVon.Text = "von";
            // 
            // lblAllgemeineKostenträger
            // 
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.lblAllgemeineKostenträger.Appearance = appearance6;
            this.lblAllgemeineKostenträger.Location = new System.Drawing.Point(3, 41);
            this.lblAllgemeineKostenträger.Name = "lblAllgemeineKostenträger";
            this.lblAllgemeineKostenträger.Size = new System.Drawing.Size(192, 13);
            this.lblAllgemeineKostenträger.TabIndex = 3;
            this.lblAllgemeineKostenträger.Text = "Allgemeine Kostenträger";
            this.lblAllgemeineKostenträger.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(201, -14);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(82, 20);
            this.ultraLabel3.TabIndex = 1;
            this.ultraLabel3.Text = "ultraLabel3";
            // 
            // panelButtons
            // 
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 161);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(289, 136);
            this.panelButtons.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucKlienten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelSuche);
            this.Controls.Add(this.panelUntenButt);
            this.Name = "ucKlienten";
            this.Size = new System.Drawing.Size(289, 325);
            ((System.ComponentModel.ISupportInitialize)(this.cbAllgemeineKostenträger)).EndInit();
            this.panelUntenButt.ResumeLayout(false);
            this.panelSuche.ResumeLayout(false);
            this.panelSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurSelbstzahlerJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitelKlienten;
        private QS2.Desktop.ControlManagment.BasePanel panelUntenButt;
        private QS2.Desktop.ControlManagment.BasePanel panelSuche;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        public QS2.Desktop.ControlManagment.BaseButton uButtonAlleKeine;
        private QS2.Desktop.ControlManagment.BaseLabel lblAllgemeineKostenträger;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbAllgemeineKostenträger;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtBis;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblNameKlient;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtKlient;
        public QS2.Desktop.ControlManagment.BaseButton btnSearchKlienten;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkNurSelbstzahlerJN;
        private System.Windows.Forms.Timer timer1;
    }
}
