namespace PMDS.Global
{
    partial class ucProtokoll
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Protokoll in die Zwischenablage kopieren", Infragistics.Win.ToolTipImage.Default, "Kopieren", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProtokoll));
            this.txtProtokoll = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.panelButtonsOK = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonsJaNein = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelUntenText = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtQuestion = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.panelButtonsJaNein2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnJa = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnNein = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButonsLinks = new QS2.Desktop.ControlManagment.BasePanel();
            this.UFormLinkZurücksetzen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelProt = new QS2.Desktop.ControlManagment.BasePanel();
            this.treeProtokoll = new Infragistics.Win.UltraWinTree.UltraTree();
            this.panelUnten2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucProtDetail1 = new PMDS.GUI.ucProtDetail();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelButtonsOK.SuspendLayout();
            this.panelUnten.SuspendLayout();
            this.panelButtonsJaNein.SuspendLayout();
            this.panelUntenText.SuspendLayout();
            this.panelButtonsJaNein2.SuspendLayout();
            this.panelButonsLinks.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelProt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeProtokoll)).BeginInit();
            this.panelUnten2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProtokoll
            // 
            this.txtProtokoll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtProtokoll.Appearance = appearance1;
            this.txtProtokoll.Location = new System.Drawing.Point(5, 4);
            this.txtProtokoll.Name = "txtProtokoll";
            this.txtProtokoll.ReadOnly = true;
            this.txtProtokoll.Size = new System.Drawing.Size(413, 195);
            this.txtProtokoll.TabIndex = 2;
            this.txtProtokoll.Value = "";
            // 
            // panelButtonsOK
            // 
            this.panelButtonsOK.Controls.Add(this.btnClose);
            this.panelButtonsOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsOK.Location = new System.Drawing.Point(350, 0);
            this.panelButtonsOK.Name = "panelButtonsOK";
            this.panelButtonsOK.Size = new System.Drawing.Size(74, 29);
            this.panelButtonsOK.TabIndex = 5;
            this.panelButtonsOK.Visible = false;
            // 
            // btnClose
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance2;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelUnten
            // 
            this.panelUnten.Controls.Add(this.panelButtonsJaNein);
            this.panelUnten.Controls.Add(this.panelButonsLinks);
            this.panelUnten.Controls.Add(this.panelButtonsOK);
            this.panelUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUnten.Location = new System.Drawing.Point(0, 1);
            this.panelUnten.Name = "panelUnten";
            this.panelUnten.Size = new System.Drawing.Size(424, 29);
            this.panelUnten.TabIndex = 7;
            // 
            // panelButtonsJaNein
            // 
            this.panelButtonsJaNein.Controls.Add(this.panelUntenText);
            this.panelButtonsJaNein.Controls.Add(this.panelButtonsJaNein2);
            this.panelButtonsJaNein.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonsJaNein.Location = new System.Drawing.Point(56, 0);
            this.panelButtonsJaNein.Name = "panelButtonsJaNein";
            this.panelButtonsJaNein.Size = new System.Drawing.Size(294, 29);
            this.panelButtonsJaNein.TabIndex = 8;
            // 
            // panelUntenText
            // 
            this.panelUntenText.Controls.Add(this.txtQuestion);
            this.panelUntenText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUntenText.Location = new System.Drawing.Point(0, 0);
            this.panelUntenText.Name = "panelUntenText";
            this.panelUntenText.Size = new System.Drawing.Size(192, 29);
            this.panelUntenText.TabIndex = 4;
            // 
            // txtQuestion
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BackColorDisabled = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtQuestion.ActiveLinkAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.txtQuestion.Appearance = appearance4;
            this.txtQuestion.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuestion.Enabled = false;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BackColorDisabled = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtQuestion.LinkAppearance = appearance5;
            this.txtQuestion.Location = new System.Drawing.Point(0, 0);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(192, 24);
            this.txtQuestion.TabIndex = 2;
            this.txtQuestion.Value = "Wollen Sie fortfahren?";
            // 
            // panelButtonsJaNein2
            // 
            this.panelButtonsJaNein2.Controls.Add(this.btnJa);
            this.panelButtonsJaNein2.Controls.Add(this.btnNein);
            this.panelButtonsJaNein2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsJaNein2.Location = new System.Drawing.Point(192, 0);
            this.panelButtonsJaNein2.Name = "panelButtonsJaNein2";
            this.panelButtonsJaNein2.Size = new System.Drawing.Size(102, 29);
            this.panelButtonsJaNein2.TabIndex = 3;
            // 
            // btnJa
            // 
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnJa.Appearance = appearance6;
            this.btnJa.AutoWorkLayout = false;
            this.btnJa.IsStandardControl = false;
            this.btnJa.Location = new System.Drawing.Point(3, 0);
            this.btnJa.Name = "btnJa";
            this.btnJa.Size = new System.Drawing.Size(48, 24);
            this.btnJa.TabIndex = 1;
            this.btnJa.Text = "Ja";
            this.btnJa.Click += new System.EventHandler(this.btnJa_Click);
            // 
            // btnNein
            // 
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnNein.Appearance = appearance7;
            this.btnNein.AutoWorkLayout = false;
            this.btnNein.IsStandardControl = false;
            this.btnNein.Location = new System.Drawing.Point(51, 0);
            this.btnNein.Name = "btnNein";
            this.btnNein.Size = new System.Drawing.Size(46, 24);
            this.btnNein.TabIndex = 0;
            this.btnNein.Text = "Nein";
            this.btnNein.Click += new System.EventHandler(this.btnNein_Click);
            // 
            // panelButonsLinks
            // 
            this.panelButonsLinks.Controls.Add(this.UFormLinkZurücksetzen);
            this.panelButonsLinks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelButonsLinks.Location = new System.Drawing.Point(0, 0);
            this.panelButonsLinks.Name = "panelButonsLinks";
            this.panelButonsLinks.Size = new System.Drawing.Size(56, 29);
            this.panelButonsLinks.TabIndex = 7;
            // 
            // UFormLinkZurücksetzen
            // 
            appearance8.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance8.FontData.SizeInPoints = 8F;
            appearance8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UFormLinkZurücksetzen.Appearance = appearance8;
            this.UFormLinkZurücksetzen.AutoSize = true;
            appearance9.FontData.UnderlineAsString = "True";
            this.UFormLinkZurücksetzen.HotTrackAppearance = appearance9;
            this.UFormLinkZurücksetzen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UFormLinkZurücksetzen.Location = new System.Drawing.Point(5, 1);
            this.UFormLinkZurücksetzen.Name = "UFormLinkZurücksetzen";
            this.UFormLinkZurücksetzen.Size = new System.Drawing.Size(48, 14);
            this.UFormLinkZurücksetzen.TabIndex = 3;
            this.UFormLinkZurücksetzen.Text = "Kopieren";
            ultraToolTipInfo1.ToolTipText = "Protokoll in die Zwischenablage kopieren";
            ultraToolTipInfo1.ToolTipTitle = "Kopieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.UFormLinkZurücksetzen, ultraToolTipInfo1);
            this.UFormLinkZurücksetzen.UseAppStyling = false;
            this.UFormLinkZurücksetzen.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UFormLinkZurücksetzen.Visible = false;
            this.UFormLinkZurücksetzen.Click += new System.EventHandler(this.UFormLinkZurücksetzen_Click_1);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblTitel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 26);
            this.panel2.TabIndex = 8;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.Location = new System.Drawing.Point(5, 6);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(414, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Information";
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAll.Controls.Add(this.panelProt);
            this.panelAll.Controls.Add(this.panelUnten2);
            this.panelAll.Controls.Add(this.panel2);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(424, 260);
            this.panelAll.TabIndex = 11;
            // 
            // panelProt
            // 
            this.panelProt.Controls.Add(this.treeProtokoll);
            this.panelProt.Controls.Add(this.txtProtokoll);
            this.panelProt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProt.Location = new System.Drawing.Point(0, 26);
            this.panelProt.Name = "panelProt";
            this.panelProt.Size = new System.Drawing.Size(424, 204);
            this.panelProt.TabIndex = 13;
            // 
            // treeProtokoll
            // 
            this.treeProtokoll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeProtokoll.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.treeProtokoll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treeProtokoll.Location = new System.Drawing.Point(5, 4);
            this.treeProtokoll.Name = "treeProtokoll";
            this.treeProtokoll.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance10.BorderColor = System.Drawing.Color.Black;
            appearance10.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BorderColor = System.Drawing.Color.Black;
            appearance11.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance11;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.treeProtokoll.Override = _override1;
            this.treeProtokoll.Size = new System.Drawing.Size(413, 195);
            this.treeProtokoll.TabIndex = 1;
            this.treeProtokoll.UseAppStyling = false;
            this.treeProtokoll.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.treeProtokoll.Visible = false;
            this.treeProtokoll.DoubleClick += new System.EventHandler(this.treeProtokoll_DoubleClick);
            // 
            // panelUnten2
            // 
            this.panelUnten2.Controls.Add(this.panelUnten);
            this.panelUnten2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUnten2.Location = new System.Drawing.Point(0, 230);
            this.panelUnten2.Name = "panelUnten2";
            this.panelUnten2.Size = new System.Drawing.Size(424, 30);
            this.panelUnten2.TabIndex = 12;
            // 
            // ucProtDetail1
            // 
            this.ucProtDetail1.BackColor = System.Drawing.Color.Silver;
            this.ucProtDetail1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucProtDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProtDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucProtDetail1.Name = "ucProtDetail1";
            this.ucProtDetail1.Size = new System.Drawing.Size(424, 260);
            this.ucProtDetail1.TabIndex = 12;
            this.ucProtDetail1.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ICO_abrechnung übernehmen.ico");
            this.imageList1.Images.SetKeyName(1, "ICO_abrechen3.ico");
            this.imageList1.Images.SetKeyName(2, "ICO_über.ico");
            this.imageList1.Images.SetKeyName(3, "ico_transparent.ico");
            // 
            // ucProtokoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.ucProtDetail1);
            this.Name = "ucProtokoll";
            this.Size = new System.Drawing.Size(424, 260);
            this.panelButtonsOK.ResumeLayout(false);
            this.panelUnten.ResumeLayout(false);
            this.panelButtonsJaNein.ResumeLayout(false);
            this.panelUntenText.ResumeLayout(false);
            this.panelButtonsJaNein2.ResumeLayout(false);
            this.panelButonsLinks.ResumeLayout(false);
            this.panelButonsLinks.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelProt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeProtokoll)).EndInit();
            this.panelUnten2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtQuestion;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsOK;
        private QS2.Desktop.ControlManagment.BasePanel panel2;
        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtProtokoll;
        private QS2.Desktop.ControlManagment.BasePanel panelButonsLinks;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsJaNein;
        private QS2.Desktop.ControlManagment.BasePanel panelUntenText;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsJaNein2;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten2;
        private QS2.Desktop.ControlManagment.BasePanel panelProt;
        public Infragistics.Win.UltraWinTree.UltraTree treeProtokoll;
        private System.Windows.Forms.ImageList imageList1;
        private PMDS.GUI.ucProtDetail ucProtDetail1;
        public QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BaseButton btnJa;
        private QS2.Desktop.ControlManagment.BaseButton btnNein;
        internal QS2.Desktop.ControlManagment.BaseLabel UFormLinkZurücksetzen;
        public QS2.Desktop.ControlManagment.BaseLabel lblTitel;
    }
}