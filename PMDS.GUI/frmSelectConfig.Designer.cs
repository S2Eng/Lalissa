namespace PMDS.GUI
{
    partial class frmSelectConfig
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.Default, "Reload", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.cboConfigFiles = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblConfigFiles = new Infragistics.Win.Misc.UltraLabel();
            this.txtConfigPath = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.lblConfigPath = new Infragistics.Win.Misc.UltraLabel();
            this.lblDatabases2 = new Infragistics.Win.Misc.UltraLabel();
            this.lblOpenConfig = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnRefresh = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.lblOpenQS2Config = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtConfigFile = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cboConfigFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigFile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(824, 471);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 27);
            this.btnOK.TabIndex = 100;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(741, 471);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 27);
            this.btnAbort.TabIndex = 101;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // cboConfigFiles
            // 
            this.cboConfigFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConfigFiles.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboConfigFiles.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
            this.cboConfigFiles.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboConfigFiles.Location = new System.Drawing.Point(83, 37);
            this.cboConfigFiles.Name = "cboConfigFiles";
            this.cboConfigFiles.Size = new System.Drawing.Size(699, 21);
            this.cboConfigFiles.TabIndex = 0;
            this.cboConfigFiles.ValueChanged += new System.EventHandler(this.cboConfigFiles_ValueChanged);
            // 
            // lblConfigFiles
            // 
            this.lblConfigFiles.Location = new System.Drawing.Point(9, 40);
            this.lblConfigFiles.Name = "lblConfigFiles";
            this.lblConfigFiles.Size = new System.Drawing.Size(95, 15);
            this.lblConfigFiles.TabIndex = 105;
            this.lblConfigFiles.Text = "Config-files";
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.txtConfigPath.Appearance = appearance3;
            this.txtConfigPath.Location = new System.Drawing.Point(83, 12);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.ReadOnly = true;
            this.txtConfigPath.Size = new System.Drawing.Size(806, 21);
            this.txtConfigPath.TabIndex = 107;
            this.txtConfigPath.Value = "";
            // 
            // lblConfigPath
            // 
            this.lblConfigPath.Location = new System.Drawing.Point(9, 14);
            this.lblConfigPath.Name = "lblConfigPath";
            this.lblConfigPath.Size = new System.Drawing.Size(106, 15);
            this.lblConfigPath.TabIndex = 108;
            this.lblConfigPath.Text = "Config-path";
            // 
            // lblDatabases2
            // 
            this.lblDatabases2.Location = new System.Drawing.Point(9, 63);
            this.lblDatabases2.Name = "lblDatabases2";
            this.lblDatabases2.Size = new System.Drawing.Size(108, 18);
            this.lblDatabases2.TabIndex = 109;
            this.lblDatabases2.Text = "Selected file";
            // 
            // lblOpenConfig
            // 
            this.lblOpenConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 8F;
            appearance4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblOpenConfig.Appearance = appearance4;
            this.lblOpenConfig.AutoSize = true;
            appearance5.FontData.UnderlineAsString = "True";
            this.lblOpenConfig.HotTrackAppearance = appearance5;
            this.lblOpenConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOpenConfig.Location = new System.Drawing.Point(786, 40);
            this.lblOpenConfig.Margin = new System.Windows.Forms.Padding(4);
            this.lblOpenConfig.Name = "lblOpenConfig";
            this.lblOpenConfig.Size = new System.Drawing.Size(74, 14);
            this.lblOpenConfig.TabIndex = 110;
            this.lblOpenConfig.Text = "Open in Editor";
            this.lblOpenConfig.UseAppStyling = false;
            this.lblOpenConfig.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblOpenConfig.Click += new System.EventHandler(this.lblOpenConfig_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnRefresh.Appearance = appearance6;
            this.btnRefresh.AutoWorkLayout = false;
            this.btnRefresh.IsStandardControl = false;
            this.btnRefresh.Location = new System.Drawing.Point(864, 35);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 24);
            this.btnRefresh.TabIndex = 111;
            this.btnRefresh.Tag = "";
            ultraToolTipInfo1.ToolTipTitle = "Reload";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnRefresh, ultraToolTipInfo1);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager1.InitialDelay = 50000;
            // 
            // lblOpenQS2Config
            // 
            this.lblOpenQS2Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance7.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance7.FontData.SizeInPoints = 8F;
            appearance7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblOpenQS2Config.Appearance = appearance7;
            this.lblOpenQS2Config.AutoSize = true;
            appearance8.FontData.UnderlineAsString = "True";
            this.lblOpenQS2Config.HotTrackAppearance = appearance8;
            this.lblOpenQS2Config.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOpenQS2Config.Location = new System.Drawing.Point(83, 477);
            this.lblOpenQS2Config.Margin = new System.Windows.Forms.Padding(4);
            this.lblOpenQS2Config.Name = "lblOpenQS2Config";
            this.lblOpenQS2Config.Size = new System.Drawing.Size(131, 14);
            this.lblOpenQS2Config.TabIndex = 112;
            this.lblOpenQS2Config.Text = "Open QS2.config in Editor";
            this.lblOpenQS2Config.UseAppStyling = false;
            this.lblOpenQS2Config.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblOpenQS2Config.Click += new System.EventHandler(this.lblOpenQS2Config_Click);
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigFile.AutoSize = false;
            this.txtConfigFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigFile.Location = new System.Drawing.Point(83, 64);
            this.txtConfigFile.Multiline = true;
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtConfigFile.Size = new System.Drawing.Size(806, 400);
            this.txtConfigFile.TabIndex = 113;
            // 
            // frmSelectConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 502);
            this.Controls.Add(this.txtConfigFile);
            this.Controls.Add(this.lblOpenQS2Config);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.cboConfigFiles);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblOpenConfig);
            this.Controls.Add(this.lblDatabases2);
            this.Controls.Add(this.lblConfigPath);
            this.Controls.Add(this.lblConfigFiles);
            this.Name = "frmSelectConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMDS - Auswahl Config.-Datei";
            this.Load += new System.EventHandler(this.frmSelectConfig_Load);
            this.VisibleChanged += new System.EventHandler(this.frmSelectConfig_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cboConfigFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cboConfigFiles;
        internal Infragistics.Win.Misc.UltraLabel lblConfigFiles;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtConfigPath;
        internal Infragistics.Win.Misc.UltraLabel lblConfigPath;
        internal Infragistics.Win.Misc.UltraLabel lblDatabases2;
        internal QS2.Desktop.ControlManagment.BaseLabel lblOpenConfig;
        public QS2.Desktop.ControlManagment.BaseButton btnRefresh;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        internal QS2.Desktop.ControlManagment.BaseLabel lblOpenQS2Config;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtConfigFile;
    }
}