namespace PMDS.GUI.GUI.Main
{
    partial class frmSys
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelAutoUpdateResFromITSCont = new System.Windows.Forms.Panel();
            this.txtResFileToImport = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtSourceDB = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnImportResFile = new Infragistics.Win.Misc.UltraButton();
            this.lblSourceDB = new Infragistics.Win.Misc.UltraLabel();
            this.lblResFileToImport = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.udteTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udteFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblTo = new Infragistics.Win.Misc.UltraLabel();
            this.lblFrom = new Infragistics.Win.Misc.UltraLabel();
            this.lblInfo = new Infragistics.Win.Misc.UltraLabel();
            this.btnUpdatePEBerufsstände = new Infragistics.Win.Misc.UltraButton();
            this.btnCheckVOAndUpdate = new Infragistics.Win.Misc.UltraButton();
            this.chkNoProtocol = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblInfoOperation = new Infragistics.Win.Misc.UltraLabel();
            this.btnUpdatePETest = new Infragistics.Win.Misc.UltraButton();
            this.btnUpdatePE = new Infragistics.Win.Misc.UltraButton();
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnMigrateOldMessages = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelAutoUpdateResFromITSCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtResFileToImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceDB)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoProtocol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelAutoUpdateResFromITSCont);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(921, 609);
            // 
            // panelAutoUpdateResFromITSCont
            // 
            this.panelAutoUpdateResFromITSCont.BackColor = System.Drawing.Color.Transparent;
            this.panelAutoUpdateResFromITSCont.Controls.Add(this.txtResFileToImport);
            this.panelAutoUpdateResFromITSCont.Controls.Add(this.txtSourceDB);
            this.panelAutoUpdateResFromITSCont.Controls.Add(this.btnImportResFile);
            this.panelAutoUpdateResFromITSCont.Controls.Add(this.lblSourceDB);
            this.panelAutoUpdateResFromITSCont.Controls.Add(this.lblResFileToImport);
            this.panelAutoUpdateResFromITSCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAutoUpdateResFromITSCont.Location = new System.Drawing.Point(0, 0);
            this.panelAutoUpdateResFromITSCont.Name = "panelAutoUpdateResFromITSCont";
            this.panelAutoUpdateResFromITSCont.Size = new System.Drawing.Size(921, 609);
            this.panelAutoUpdateResFromITSCont.TabIndex = 0;
            // 
            // txtResFileToImport
            // 
            this.txtResFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResFileToImport.Location = new System.Drawing.Point(76, 64);
            this.txtResFileToImport.Multiline = true;
            this.txtResFileToImport.Name = "txtResFileToImport";
            this.txtResFileToImport.Size = new System.Drawing.Size(836, 46);
            this.txtResFileToImport.TabIndex = 1;
            this.txtResFileToImport.Text = "H:\\develop\\PMDS\\Res.PMDSFromITSCont.txt";
            // 
            // txtSourceDB
            // 
            this.txtSourceDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDB.Location = new System.Drawing.Point(76, 12);
            this.txtSourceDB.Multiline = true;
            this.txtSourceDB.Name = "txtSourceDB";
            this.txtSourceDB.Size = new System.Drawing.Size(836, 46);
            this.txtSourceDB.TabIndex = 0;
            this.txtSourceDB.Text = "Initial Catalog=ITSContDev;Data Source=StySRV02v\\SQL2008R2;Trusted_Connection=Yes" +
    ";Provider=\"SQLOLEDB.1\";MARS Connection=True;";
            // 
            // btnImportResFile
            // 
            this.btnImportResFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportResFile.Location = new System.Drawing.Point(835, 117);
            this.btnImportResFile.Name = "btnImportResFile";
            this.btnImportResFile.Size = new System.Drawing.Size(68, 32);
            this.btnImportResFile.TabIndex = 100;
            this.btnImportResFile.Text = "Start";
            this.btnImportResFile.Click += new System.EventHandler(this.btnImportResFile_Click);
            // 
            // lblSourceDB
            // 
            this.lblSourceDB.Location = new System.Drawing.Point(13, 12);
            this.lblSourceDB.Name = "lblSourceDB";
            this.lblSourceDB.Size = new System.Drawing.Size(93, 18);
            this.lblSourceDB.TabIndex = 0;
            this.lblSourceDB.Text = "Source-DB";
            // 
            // lblResFileToImport
            // 
            this.lblResFileToImport.Location = new System.Drawing.Point(13, 67);
            this.lblResFileToImport.Name = "lblResFileToImport";
            this.lblResFileToImport.Size = new System.Drawing.Size(93, 18);
            this.lblResFileToImport.TabIndex = 3;
            this.lblResFileToImport.Text = "Res.File";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.btnMigrateOldMessages);
            this.ultraTabPageControl2.Controls.Add(this.udteTo);
            this.ultraTabPageControl2.Controls.Add(this.udteFrom);
            this.ultraTabPageControl2.Controls.Add(this.lblTo);
            this.ultraTabPageControl2.Controls.Add(this.lblFrom);
            this.ultraTabPageControl2.Controls.Add(this.lblInfo);
            this.ultraTabPageControl2.Controls.Add(this.btnUpdatePEBerufsstände);
            this.ultraTabPageControl2.Controls.Add(this.btnCheckVOAndUpdate);
            this.ultraTabPageControl2.Controls.Add(this.chkNoProtocol);
            this.ultraTabPageControl2.Controls.Add(this.lblInfoOperation);
            this.ultraTabPageControl2.Controls.Add(this.btnUpdatePETest);
            this.ultraTabPageControl2.Controls.Add(this.btnUpdatePE);
            this.ultraTabPageControl2.Controls.Add(this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(921, 609);
            // 
            // udteTo
            // 
            this.udteTo.Location = new System.Drawing.Point(200, 201);
            this.udteTo.Name = "udteTo";
            this.udteTo.Size = new System.Drawing.Size(94, 21);
            this.udteTo.TabIndex = 110;
            // 
            // udteFrom
            // 
            this.udteFrom.Location = new System.Drawing.Point(60, 201);
            this.udteFrom.Name = "udteFrom";
            this.udteFrom.Size = new System.Drawing.Size(94, 21);
            this.udteFrom.TabIndex = 109;
            // 
            // lblTo
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblTo.Appearance = appearance1;
            this.lblTo.Location = new System.Drawing.Point(169, 201);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(45, 21);
            this.lblTo.TabIndex = 112;
            this.lblTo.Text = "bis";
            // 
            // lblFrom
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.lblFrom.Appearance = appearance2;
            this.lblFrom.Location = new System.Drawing.Point(12, 201);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 21);
            this.lblFrom.TabIndex = 111;
            this.lblFrom.Text = "Von:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(8, 572);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(908, 34);
            this.lblInfo.TabIndex = 108;
            this.lblInfo.Text = "Info";
            // 
            // btnUpdatePEBerufsstände
            // 
            this.btnUpdatePEBerufsstände.Location = new System.Drawing.Point(11, 226);
            this.btnUpdatePEBerufsstände.Name = "btnUpdatePEBerufsstände";
            this.btnUpdatePEBerufsstände.Size = new System.Drawing.Size(394, 32);
            this.btnUpdatePEBerufsstände.TabIndex = 107;
            this.btnUpdatePEBerufsstände.Text = "PE - Update IDBerufsstand alle Datensätze wo Null";
            this.btnUpdatePEBerufsstände.Click += new System.EventHandler(this.btnUpdatePEBerufsstände_Click);
            // 
            // btnCheckVOAndUpdate
            // 
            this.btnCheckVOAndUpdate.Location = new System.Drawing.Point(9, 134);
            this.btnCheckVOAndUpdate.Name = "btnCheckVOAndUpdate";
            this.btnCheckVOAndUpdate.Size = new System.Drawing.Size(394, 38);
            this.btnCheckVOAndUpdate.TabIndex = 106;
            this.btnCheckVOAndUpdate.Text = "Alle VO\'s und VOBestelldaten prüfen ob Klient entlassen und falls ja VO.Bis auf E" +
    "ntlassungsdatum-1Day setzen";
            this.btnCheckVOAndUpdate.Click += new System.EventHandler(this.btnCheckVOAndUpdate_Click);
            // 
            // chkNoProtocol
            // 
            this.chkNoProtocol.BackColor = System.Drawing.Color.Transparent;
            this.chkNoProtocol.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkNoProtocol.Location = new System.Drawing.Point(350, 81);
            this.chkNoProtocol.Name = "chkNoProtocol";
            this.chkNoProtocol.Size = new System.Drawing.Size(108, 20);
            this.chkNoProtocol.TabIndex = 105;
            this.chkNoProtocol.Text = "No Protocol";
            // 
            // lblInfoOperation
            // 
            this.lblInfoOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.lblInfoOperation.Appearance = appearance3;
            this.lblInfoOperation.Location = new System.Drawing.Point(8, 581);
            this.lblInfoOperation.Name = "lblInfoOperation";
            this.lblInfoOperation.Size = new System.Drawing.Size(908, 25);
            this.lblInfoOperation.TabIndex = 104;
            // 
            // btnUpdatePETest
            // 
            this.btnUpdatePETest.Location = new System.Drawing.Point(9, 57);
            this.btnUpdatePETest.Name = "btnUpdatePETest";
            this.btnUpdatePETest.Size = new System.Drawing.Size(331, 32);
            this.btnUpdatePETest.TabIndex = 103;
            this.btnUpdatePETest.Text = "Patient und PE - Abteilungen und Bereiche prüfen";
            this.btnUpdatePETest.Click += new System.EventHandler(this.btnUpdatePETest_Click);
            // 
            // btnUpdatePE
            // 
            this.btnUpdatePE.Location = new System.Drawing.Point(9, 88);
            this.btnUpdatePE.Name = "btnUpdatePE";
            this.btnUpdatePE.Size = new System.Drawing.Size(331, 32);
            this.btnUpdatePE.TabIndex = 102;
            this.btnUpdatePE.Text = "Patient und PE - Abteilungen und Bereiche prüfen und updaten";
            this.btnUpdatePE.Click += new System.EventHandler(this.btnUpdatePE_Click);
            // 
            // btnCopyOldPlansIntoNewSystemAndDeleteOldPlans
            // 
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.Location = new System.Drawing.Point(9, 14);
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.Name = "btnCopyOldPlansIntoNewSystemAndDeleteOldPlans";
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.Size = new System.Drawing.Size(394, 32);
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.TabIndex = 101;
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.Text = "Alte Pläne ins neue Planungssystem übernhemen und alte Pläne löschen";
            this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans.Click += new System.EventHandler(this.btnCopyOldPlansIntoNewSystemAndDeleteOldPlans_Click);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(925, 635);
            this.ultraTabControl1.TabIndex = 0;
            ultraTab1.Key = "AutoUpdateResFromITSCont";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Auto-Update Res. from ITSCont";
            ultraTab2.Key = "PMDSAdministration";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "PMDS Administration";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(921, 609);
            // 
            // btnMigrateOldMessages
            // 
            this.btnMigrateOldMessages.Location = new System.Drawing.Point(11, 273);
            this.btnMigrateOldMessages.Name = "btnMigrateOldMessages";
            this.btnMigrateOldMessages.Size = new System.Drawing.Size(394, 32);
            this.btnMigrateOldMessages.TabIndex = 113;
            this.btnMigrateOldMessages.Text = "Alte Nachrichten überspielen";
            this.btnMigrateOldMessages.Click += new System.EventHandler(this.btnMigrateOldMessages_Click);
            // 
            // frmSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 635);
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "frmSys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Systemadministration";
            this.Load += new System.EventHandler(this.frmSys_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelAutoUpdateResFromITSCont.ResumeLayout(false);
            this.panelAutoUpdateResFromITSCont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtResFileToImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceDB)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoProtocol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblSourceDB;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSourceDB;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtResFileToImport;
        private Infragistics.Win.Misc.UltraLabel lblResFileToImport;
        private Infragistics.Win.Misc.UltraButton btnImportResFile;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel panelAutoUpdateResFromITSCont;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraButton btnCopyOldPlansIntoNewSystemAndDeleteOldPlans;
        private Infragistics.Win.Misc.UltraButton btnUpdatePE;
        private Infragistics.Win.Misc.UltraButton btnUpdatePETest;
        public Infragistics.Win.Misc.UltraLabel lblInfoOperation;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkNoProtocol;
        private Infragistics.Win.Misc.UltraButton btnCheckVOAndUpdate;
        private Infragistics.Win.Misc.UltraButton btnUpdatePEBerufsstände;
        private Infragistics.Win.Misc.UltraLabel lblInfo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFrom;
        private Infragistics.Win.Misc.UltraLabel lblTo;
        private Infragistics.Win.Misc.UltraLabel lblFrom;
        private Infragistics.Win.Misc.UltraButton btnMigrateOldMessages;
    }
}