namespace PMDS.GUI.ELGA
{
    partial class contCDAViewer
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSaveDocuToELGA = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSaveIntoArchive = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1051, 41);
            this.panelTop.TabIndex = 0;
            this.panelTop.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnAbort);
            this.panelBottom.Controls.Add(this.btnSaveDocuToELGA);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.btnSaveIntoArchive);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 767);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1051, 39);
            this.panelBottom.TabIndex = 1;
            this.panelBottom.Visible = false;
            // 
            // btnSaveDocuToELGA
            // 
            this.btnSaveDocuToELGA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSaveDocuToELGA.Appearance = appearance2;
            this.btnSaveDocuToELGA.AutoWorkLayout = false;
            this.btnSaveDocuToELGA.IsStandardControl = false;
            this.btnSaveDocuToELGA.Location = new System.Drawing.Point(490, 4);
            this.btnSaveDocuToELGA.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveDocuToELGA.Name = "btnSaveDocuToELGA";
            this.btnSaveDocuToELGA.Size = new System.Drawing.Size(134, 30);
            this.btnSaveDocuToELGA.TabIndex = 132;
            this.btnSaveDocuToELGA.Tag = "";
            this.btnSaveDocuToELGA.Text = "In ELGA speichern";
            this.btnSaveDocuToELGA.Visible = false;
            this.btnSaveDocuToELGA.Click += new System.EventHandler(this.btnSaveDocuToELGA_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance3;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(999, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 131;
            this.btnClose.Tag = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveIntoArchive
            // 
            this.btnSaveIntoArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSaveIntoArchive.Appearance = appearance4;
            this.btnSaveIntoArchive.AutoWorkLayout = false;
            this.btnSaveIntoArchive.IsStandardControl = false;
            this.btnSaveIntoArchive.Location = new System.Drawing.Point(832, 4);
            this.btnSaveIntoArchive.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveIntoArchive.Name = "btnSaveIntoArchive";
            this.btnSaveIntoArchive.Size = new System.Drawing.Size(160, 30);
            this.btnSaveIntoArchive.TabIndex = 130;
            this.btnSaveIntoArchive.Tag = "";
            this.btnSaveIntoArchive.Text = "Ins Archiv herunterladen";
            this.btnSaveIntoArchive.Visible = false;
            this.btnSaveIntoArchive.Click += new System.EventHandler(this.btnSaveIntoArchive_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Controls.Add(this.webBrowser1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 41);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1051, 726);
            this.panelCenter.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1051, 726);
            this.webBrowser1.TabIndex = 2;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(398, 4);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(91, 30);
            this.btnAbort.TabIndex = 133;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // contCDAViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "contCDAViewer";
            this.Size = new System.Drawing.Size(1051, 806);
            this.VisibleChanged += new System.EventHandler(this.ContCDAViewer_VisibleChanged);
            this.panelBottom.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        public System.Windows.Forms.WebBrowser webBrowser1;
        public QS2.Desktop.ControlManagment.BaseButton btnSaveIntoArchive;
        public QS2.Desktop.ControlManagment.BaseButton btnClose;
        public QS2.Desktop.ControlManagment.BaseButton btnSaveDocuToELGA;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
    }
}
