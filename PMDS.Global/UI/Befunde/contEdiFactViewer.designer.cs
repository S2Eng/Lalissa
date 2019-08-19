namespace EDIFact
{
    partial class contEdiFactViewer
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Befund öffnen", Infragistics.Win.ToolTipImage.Default, "Öffnen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Schließen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Text kopieren", Infragistics.Win.ToolTipImage.Default, "Kopieren", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnOpenBefund = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.UltraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.btnCopyText = new Infragistics.Win.Misc.UltraButton();
            this.btnPrint = new Infragistics.Win.Misc.UltraButton();
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            this.textControl1 = new TXTextControl.TextControl();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            this.SuspendLayout();
            // 
            // btnOpenBefund
            // 
            this.btnOpenBefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOpenBefund.Appearance = appearance1;
            this.btnOpenBefund.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenBefund.Location = new System.Drawing.Point(703, 2);
            this.btnOpenBefund.Name = "btnOpenBefund";
            this.btnOpenBefund.Size = new System.Drawing.Size(27, 25);
            this.btnOpenBefund.TabIndex = 0;
            this.btnOpenBefund.Tag = "";
            ultraToolTipInfo3.ToolTipText = "Befund öffnen";
            ultraToolTipInfo3.ToolTipTitle = "Öffnen";
            this.UltraToolTipManager1.SetUltraToolTip(this.btnOpenBefund, ultraToolTipInfo3);
            this.btnOpenBefund.Click += new System.EventHandler(this.btnOpenBefund_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BorderColor = System.Drawing.Color.Black;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance3;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(730, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 25);
            this.btnClose.TabIndex = 20;
            this.btnClose.Tag = "";
            ultraToolTipInfo2.ToolTipText = "Schließen";
            this.UltraToolTipManager1.SetUltraToolTip(this.btnClose, ultraToolTipInfo2);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UltraToolTipManager1
            // 
            this.UltraToolTipManager1.ContainingControl = this;
            this.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.UltraToolTipManager1.InitialDelay = 0;
            this.UltraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            // 
            // btnCopyText
            // 
            this.btnCopyText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCopyText.Appearance = appearance2;
            this.btnCopyText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyText.Location = new System.Drawing.Point(730, 2);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(27, 25);
            this.btnCopyText.TabIndex = 1;
            this.btnCopyText.Tag = "";
            ultraToolTipInfo1.ToolTipText = "Text kopieren";
            ultraToolTipInfo1.ToolTipTitle = "Kopieren";
            this.UltraToolTipManager1.SetUltraToolTip(this.btnCopyText, ultraToolTipInfo1);
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BorderColor = System.Drawing.Color.Black;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance4;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(670, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(27, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Tag = "";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(3, 31);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(761, 574);
            this.textControl1.TabIndex = 21;
            this.textControl1.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // contEdiFactViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.btnCopyText);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnOpenBefund);
            this.Name = "contEdiFactViewer";
            this.Size = new System.Drawing.Size(769, 633);
            this.VisibleChanged += new System.EventHandler(this.contEdiFactViewer_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.Misc.UltraButton btnOpenBefund;
        internal Infragistics.Win.Misc.UltraButton btnClose;
        internal Infragistics.Win.UltraWinToolTip.UltraToolTipManager UltraToolTipManager1;
        internal Infragistics.Win.Misc.UltraButton btnCopyText;
        internal Infragistics.Win.Misc.UltraButton btnPrint;
        public TXTextControl.TextControl textControl1;
    }
}

