using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

using PMDS.GUI;
using PMDS.DB;
using Patagames.Pdf.Net;

namespace PMDS
{
	/// <summary>
	/// Summary description for frmAbout.
	/// </summary>
	public class frmAbout : frmBase
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbInfo;
		private System.Windows.Forms.LinkLabel _lbWeb;
        private System.Windows.Forms.LinkLabel _lblemail;
        private QS2.Desktop.ControlManagment.BaseLabel lblVersion;
        private QS2.Desktop.ControlManagment.BaseLabel lblDatabase;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem styleNeuLadenToolStripMenuItem;
        private ToolStripMenuItem styleZurücksetzenToolStripMenuItem;
		private System.ComponentModel.IContainer components;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem testExceptionToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseButton btnHandbuch;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem checkSystemToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseButton btnNetViewer;
        private QS2.Desktop.ControlManagment.BaseButton btnTeamViewer;

        private FileInfo fiPMDS_Handbuch;
        private FileInfo fiNetViewer;
        private QS2.Desktop.ControlManagment.BaseButton btnWebMikogo;
        private ToolStripMenuItem runGACToolStripMenuItem;
        private ToolStripMenuItem formularDesignerToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem3;
        private FileInfo fiTeamViewer;
        private ToolStripMenuItem formulareInPDFKonvertierenToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem sytemAdministrationToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem loadAllDataIntoRAMToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseLabel lblVersionGuid;
        private Infragistics.Win.Misc.UltraPanel pnlPDF;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom pdfToolStripZoom1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes pdfToolStripViewModes1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch pdfToolStripSearch1;
        public Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain pdfToolStripMain1;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private ToolStripMenuItem eLDAAbrechnungToolStripMenuItem;
        private Infragistics.Win.AppStyling.Runtime.AppStylistRuntime appStylistRuntime1;
        private FileInfo fiMikogo;


        public frmAbout()
		{
            try
            {
                //
			    // Required for Windows Form Designer support
			    //
			    InitializeComponent();
                Patagames.Pdf.Net.PdfCommon.Initialize(Global.ENV.PdfiumKey);
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

                tbInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("S2 - Engineering GmbH\r\n\r\nIm Stadtgut A1\r\nA - 4407 Steyr - Gleink\r\nTel.: +43 7252 2208 0\r\nFax.: +43 7252 2208 30\r\neMail: office@s2-engineering.com\r\nWeb: www.s2-engineering.com");

                this.lblVersion.Text = PMDS.Global.ENV.getPmdsVersion();
                this.lblDatabase.Text = PMDS.Global.ENV.getPmdsDB;
                this.lblVersionGuid.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Versions-Nr") + ": " + PMDS.Global.ENV.VersionNr.ToString();

                fiNetViewer = new FileInfo(Path.Combine(Application.StartupPath, "FastViewer.exe"));
                this.btnNetViewer.Visible = fiNetViewer.Exists;

                fiTeamViewer = new FileInfo(Path.Combine(Application.StartupPath, "TeamViewer-S2-Client.exe"));
                this.btnTeamViewer.Visible = fiTeamViewer.Exists;

                fiMikogo = new FileInfo(Path.Combine(Application.StartupPath, "Mikogo.exe"));
                this.btnWebMikogo.Visible = fiMikogo.Exists;

                string HandbuchFile = PMDS.Global.ENV.StartupMode == "pmds" ? "PMDS_Handbuch.pdf" : "PMDS_Handbuch_Abrechnung.pdf";                
                fiPMDS_Handbuch = new FileInfo(Path.Combine(Application.StartupPath, HandbuchFile));
                if (!fiPMDS_Handbuch.Exists)
                {
                    if (Directory.Exists(Path.Combine(Global.ENV.sRootDir, "Doku")))
                    {
                        fiPMDS_Handbuch = new FileInfo(Path.Combine(Global.ENV.sRootDir, "Doku", HandbuchFile));
                    }
                }

                if (fiPMDS_Handbuch.Exists)
                {
                    pdfToolStripZoom1.Items[0].Text = "";
                    pdfToolStripZoom1.Items[2].Text = "";
                    pdfToolStripMain1.Items[0].Text = "";
                    pdfToolStripMain1.Items[1].Text = "";

                    pdfToolStripMain1.Items[0].Visible = false; //Open-Dialog
                    pdfToolStripMain1.Items[1].Visible = true;  //Print-Dialog

                    PdfForms form = new PdfForms();
                    PdfDocument doc = PdfDocument.Load(fiPMDS_Handbuch.FullName, form);
                    this.pdfViewer1.Document = doc;
                }
                this.pnlPDF.Visible = fiPMDS_Handbuch.Exists;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formularDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.styleNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleZurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.testExceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runGACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.formulareInPDFKonvertierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.sytemAdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.loadAllDataIntoRAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eLDAAbrechnungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.tbInfo = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this._lbWeb = new System.Windows.Forms.LinkLabel();
            this._lblemail = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDatabase = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHandbuch = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnNetViewer = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnTeamViewer = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnWebMikogo = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblVersionGuid = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlPDF = new Infragistics.Win.Misc.UltraPanel();
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripViewModes1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes();
            this.pdfToolStripMain1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain();
            this.pdfToolStripZoom1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom();
            this.pdfToolStripSearch1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch();
            this.appStylistRuntime1 = new Infragistics.Win.AppStyling.Runtime.AppStylistRuntime(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPDF.ClientArea.SuspendLayout();
            this.pnlPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularDesignerToolStripMenuItem,
            this.toolStripMenuItem4,
            this.styleNeuLadenToolStripMenuItem,
            this.styleZurücksetzenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.testExceptionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.checkSystemToolStripMenuItem,
            this.runGACToolStripMenuItem,
            this.toolStripMenuItem3,
            this.formulareInPDFKonvertierenToolStripMenuItem,
            this.toolStripMenuItem5,
            this.sytemAdministrationToolStripMenuItem,
            this.toolStripMenuItem6,
            this.loadAllDataIntoRAMToolStripMenuItem,
            this.eLDAAbrechnungToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 260);
            // 
            // formularDesignerToolStripMenuItem
            // 
            this.formularDesignerToolStripMenuItem.Name = "formularDesignerToolStripMenuItem";
            this.formularDesignerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.formularDesignerToolStripMenuItem.Text = "Formular-Designer";
            this.formularDesignerToolStripMenuItem.Click += new System.EventHandler(this.formularDesignerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(231, 6);
            // 
            // styleNeuLadenToolStripMenuItem
            // 
            this.styleNeuLadenToolStripMenuItem.Name = "styleNeuLadenToolStripMenuItem";
            this.styleNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.styleNeuLadenToolStripMenuItem.Text = "Style neu laden";
            this.styleNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.styleNeuLadenToolStripMenuItem_Click);
            // 
            // styleZurücksetzenToolStripMenuItem
            // 
            this.styleZurücksetzenToolStripMenuItem.Name = "styleZurücksetzenToolStripMenuItem";
            this.styleZurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.styleZurücksetzenToolStripMenuItem.Text = "Style zurücksetzen";
            this.styleZurücksetzenToolStripMenuItem.Click += new System.EventHandler(this.styleZurücksetzenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
            // 
            // testExceptionToolStripMenuItem
            // 
            this.testExceptionToolStripMenuItem.Name = "testExceptionToolStripMenuItem";
            this.testExceptionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.testExceptionToolStripMenuItem.Text = "Test Exception";
            this.testExceptionToolStripMenuItem.Click += new System.EventHandler(this.testExceptionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(231, 6);
            // 
            // checkSystemToolStripMenuItem
            // 
            this.checkSystemToolStripMenuItem.Name = "checkSystemToolStripMenuItem";
            this.checkSystemToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.checkSystemToolStripMenuItem.Text = "System-Check";
            this.checkSystemToolStripMenuItem.Click += new System.EventHandler(this.checkSystemToolStripMenuItem_Click);
            // 
            // runGACToolStripMenuItem
            // 
            this.runGACToolStripMenuItem.Name = "runGACToolStripMenuItem";
            this.runGACToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.runGACToolStripMenuItem.Text = "Run GAC";
            this.runGACToolStripMenuItem.Click += new System.EventHandler(this.runGACToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 6);
            // 
            // formulareInPDFKonvertierenToolStripMenuItem
            // 
            this.formulareInPDFKonvertierenToolStripMenuItem.Name = "formulareInPDFKonvertierenToolStripMenuItem";
            this.formulareInPDFKonvertierenToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.formulareInPDFKonvertierenToolStripMenuItem.Text = "Formulare in PDF konvertieren";
            this.formulareInPDFKonvertierenToolStripMenuItem.Click += new System.EventHandler(this.formulareInPDFKonvertierenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(231, 6);
            // 
            // sytemAdministrationToolStripMenuItem
            // 
            this.sytemAdministrationToolStripMenuItem.Name = "sytemAdministrationToolStripMenuItem";
            this.sytemAdministrationToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.sytemAdministrationToolStripMenuItem.Text = "System-Administration";
            this.sytemAdministrationToolStripMenuItem.Click += new System.EventHandler(this.sytemAdministrationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(231, 6);
            // 
            // loadAllDataIntoRAMToolStripMenuItem
            // 
            this.loadAllDataIntoRAMToolStripMenuItem.Name = "loadAllDataIntoRAMToolStripMenuItem";
            this.loadAllDataIntoRAMToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.loadAllDataIntoRAMToolStripMenuItem.Text = "Load all Data into RAM";
            this.loadAllDataIntoRAMToolStripMenuItem.Click += new System.EventHandler(this.loadAllDataIntoRAMToolStripMenuItem_Click);
            // 
            // eLDAAbrechnungToolStripMenuItem
            // 
            this.eLDAAbrechnungToolStripMenuItem.Name = "eLDAAbrechnungToolStripMenuItem";
            this.eLDAAbrechnungToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.eLDAAbrechnungToolStripMenuItem.Text = "ELDA-Abrechnung";
            this.eLDAAbrechnungToolStripMenuItem.Click += new System.EventHandler(this.eLDAAbrechnungToolStripMenuItem_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(1193, 747);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 31);
            this.btnOK.TabIndex = 8;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.FontData.Name = "Arial";
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbInfo.Appearance = appearance2;
            this.tbInfo.BackColor = System.Drawing.Color.White;
            this.tbInfo.Enabled = false;
            this.tbInfo.Location = new System.Drawing.Point(6, 270);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(317, 225);
            this.tbInfo.TabIndex = 10;
            this.tbInfo.Text = "S2-Engineering GmbH";
            // 
            // _lbWeb
            // 
            this._lbWeb.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this._lbWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lbWeb.LinkColor = System.Drawing.Color.RoyalBlue;
            this._lbWeb.Location = new System.Drawing.Point(3, 511);
            this._lbWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lbWeb.Name = "_lbWeb";
            this._lbWeb.Size = new System.Drawing.Size(192, 20);
            this._lbWeb.TabIndex = 11;
            this._lbWeb.TabStop = true;
            this._lbWeb.Text = "www.s2-engineering.com";
            this._lbWeb.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this._lbWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbWeb_LinkClicked);
            // 
            // _lblemail
            // 
            this._lblemail.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this._lblemail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblemail.LinkColor = System.Drawing.Color.RoyalBlue;
            this._lblemail.Location = new System.Drawing.Point(3, 531);
            this._lblemail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblemail.Name = "_lblemail";
            this._lblemail.Size = new System.Drawing.Size(245, 20);
            this._lblemail.TabIndex = 12;
            this._lblemail.TabStop = true;
            this._lblemail.Text = "eMail: office@s2-engineering.com";
            this._lblemail.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this._lblemail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblemail_LinkClicked);
            // 
            // lblVersion
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblVersion.Appearance = appearance3;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(6, 126);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(317, 20);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version:";
            // 
            // lblDatabase
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblDatabase.Appearance = appearance4;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.Location = new System.Drawing.Point(6, 152);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(317, 88);
            this.lblDatabase.TabIndex = 14;
            this.lblDatabase.Text = "Version:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnHandbuch
            // 
            this.btnHandbuch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnHandbuch.Appearance = appearance5;
            this.btnHandbuch.AutoWorkLayout = false;
            this.btnHandbuch.IsStandardControl = false;
            this.btnHandbuch.Location = new System.Drawing.Point(8, 676);
            this.btnHandbuch.Margin = new System.Windows.Forms.Padding(4);
            this.btnHandbuch.Name = "btnHandbuch";
            this.btnHandbuch.Size = new System.Drawing.Size(288, 31);
            this.btnHandbuch.TabIndex = 91;
            this.btnHandbuch.Text = "Handbuch öffnen";
            this.btnHandbuch.Click += new System.EventHandler(this.btnHandbuch_Click);
            // 
            // btnNetViewer
            // 
            this.btnNetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance6.ForeColor = System.Drawing.Color.Red;
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnNetViewer.Appearance = appearance6;
            this.btnNetViewer.AutoWorkLayout = false;
            this.btnNetViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnNetViewer.IsStandardControl = false;
            this.btnNetViewer.Location = new System.Drawing.Point(6, 560);
            this.btnNetViewer.Margin = new System.Windows.Forms.Padding(4);
            this.btnNetViewer.Name = "btnNetViewer";
            this.btnNetViewer.Size = new System.Drawing.Size(290, 31);
            this.btnNetViewer.TabIndex = 92;
            this.btnNetViewer.Text = "Online-Unterstützung 1 (FastViewer)";
            this.btnNetViewer.UseAppStyling = false;
            this.btnNetViewer.Click += new System.EventHandler(this.btnNetViewer_Click);
            // 
            // btnTeamViewer
            // 
            this.btnTeamViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance7.ForeColor = System.Drawing.Color.Blue;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnTeamViewer.Appearance = appearance7;
            this.btnTeamViewer.AutoWorkLayout = false;
            this.btnTeamViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnTeamViewer.IsStandardControl = false;
            this.btnTeamViewer.Location = new System.Drawing.Point(7, 599);
            this.btnTeamViewer.Margin = new System.Windows.Forms.Padding(4);
            this.btnTeamViewer.Name = "btnTeamViewer";
            this.btnTeamViewer.Size = new System.Drawing.Size(289, 31);
            this.btnTeamViewer.TabIndex = 93;
            this.btnTeamViewer.Text = "Online-Unterstützung 2 (TeamViewer)";
            this.btnTeamViewer.UseAppStyling = false;
            this.btnTeamViewer.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // btnWebMikogo
            // 
            this.btnWebMikogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance8.ForeColor = System.Drawing.Color.Green;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnWebMikogo.Appearance = appearance8;
            this.btnWebMikogo.AutoWorkLayout = false;
            this.btnWebMikogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnWebMikogo.IsStandardControl = false;
            this.btnWebMikogo.Location = new System.Drawing.Point(8, 637);
            this.btnWebMikogo.Margin = new System.Windows.Forms.Padding(4);
            this.btnWebMikogo.Name = "btnWebMikogo";
            this.btnWebMikogo.Size = new System.Drawing.Size(288, 31);
            this.btnWebMikogo.TabIndex = 94;
            this.btnWebMikogo.Text = "Online-Unterstützung 3 (Mikogo)";
            // 
            // lblVersionGuid
            // 
            appearance9.FontData.SizeInPoints = 9F;
            appearance9.TextVAlignAsString = "Middle";
            this.lblVersionGuid.Appearance = appearance9;
            this.lblVersionGuid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionGuid.Location = new System.Drawing.Point(6, 241);
            this.lblVersionGuid.Margin = new System.Windows.Forms.Padding(4);
            this.lblVersionGuid.Name = "lblVersionGuid";
            this.lblVersionGuid.Size = new System.Drawing.Size(317, 21);
            this.lblVersionGuid.TabIndex = 96;
            this.lblVersionGuid.Text = "Version: ";
            // 
            // pnlPDF
            // 
            this.pnlPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // pnlPDF.ClientArea
            // 
            this.pnlPDF.ClientArea.Controls.Add(this.pdfViewer1);
            this.pnlPDF.ClientArea.Controls.Add(this.pdfToolStripViewModes1);
            this.pnlPDF.Location = new System.Drawing.Point(332, 6);
            this.pnlPDF.Name = "pnlPDF";
            this.pnlPDF.Size = new System.Drawing.Size(956, 774);
            this.pnlPDF.TabIndex = 97;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer1.CurrentIndex = -1;
            this.pdfViewer1.CurrentPageHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.Document = null;
            this.pdfViewer1.FormHighlightColor = System.Drawing.Color.Transparent;
            this.pdfViewer1.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            this.pdfViewer1.LoadingIconText = "Loading...";
            this.pdfViewer1.Location = new System.Drawing.Point(0, 76);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OptimizedLoadThreshold = 1000;
            this.pdfViewer1.Padding = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pdfViewer1.PageAutoDispose = true;
            this.pdfViewer1.PageBackColor = System.Drawing.Color.White;
            this.pdfViewer1.PageBorderColor = System.Drawing.Color.Black;
            this.pdfViewer1.PageMargin = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageSeparatorColor = System.Drawing.Color.Gray;
            this.pdfViewer1.RenderFlags = ((Patagames.Pdf.Enums.RenderFlags)((Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH)));
            this.pdfViewer1.ShowCurrentPageHighlight = true;
            this.pdfViewer1.ShowLoadingIcon = true;
            this.pdfViewer1.ShowPageSeparator = true;
            this.pdfViewer1.Size = new System.Drawing.Size(956, 698);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 20;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            // 
            // pdfToolStripViewModes1
            // 
            this.pdfToolStripViewModes1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripViewModes1.Location = new System.Drawing.Point(185, 0);
            this.pdfToolStripViewModes1.Name = "pdfToolStripViewModes1";
            this.pdfToolStripViewModes1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripViewModes1.Size = new System.Drawing.Size(177, 27);
            this.pdfToolStripViewModes1.TabIndex = 16;
            this.pdfToolStripViewModes1.Text = "pdfToolStripViewModes1";
            // 
            // pdfToolStripMain1
            // 
            this.pdfToolStripMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfToolStripMain1.BackColor = System.Drawing.Color.Transparent;
            this.pdfToolStripMain1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripMain1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pdfToolStripMain1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripMain1.Location = new System.Drawing.Point(1127, 6);
            this.pdfToolStripMain1.Name = "pdfToolStripMain1";
            this.pdfToolStripMain1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripMain1.Size = new System.Drawing.Size(105, 58);
            this.pdfToolStripMain1.TabIndex = 17;
            this.pdfToolStripMain1.Text = "pdfToolStripMain1";
            // 
            // pdfToolStripZoom1
            // 
            this.pdfToolStripZoom1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoom1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripZoom1.Location = new System.Drawing.Point(332, 6);
            this.pdfToolStripZoom1.Name = "pdfToolStripZoom1";
            this.pdfToolStripZoom1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoom1.Size = new System.Drawing.Size(192, 73);
            this.pdfToolStripZoom1.TabIndex = 17;
            this.pdfToolStripZoom1.Text = "pdfToolStripZoom1";
            this.pdfToolStripZoom1.ZoomLevel = new float[] {
        8.33F,
        12.5F,
        25F,
        33.33F,
        50F,
        66.67F,
        75F,
        100F,
        125F,
        150F,
        200F,
        300F,
        400F,
        600F,
        800F};
            // 
            // pdfToolStripSearch1
            // 
            this.pdfToolStripSearch1.ActiveRecordColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfToolStripSearch1.CurrentRecord = 0;
            this.pdfToolStripSearch1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripSearch1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfToolStripSearch1.Location = new System.Drawing.Point(706, 6);
            this.pdfToolStripSearch1.Name = "pdfToolStripSearch1";
            this.pdfToolStripSearch1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripSearch1.SearchFlags = Patagames.Pdf.Enums.FindFlags.None;
            this.pdfToolStripSearch1.SearchText = "";
            this.pdfToolStripSearch1.Size = new System.Drawing.Size(232, 45);
            this.pdfToolStripSearch1.TabIndex = 18;
            this.pdfToolStripSearch1.Text = "pdfToolStripSearch1";
            // 
            // frmAbout
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(1296, 789);
            this.Controls.Add(this.pdfToolStripMain1);
            this.Controls.Add(this.pdfToolStripSearch1);
            this.Controls.Add(this.pdfToolStripZoom1);
            this.Controls.Add(this.pnlPDF);
            this.Controls.Add(this.lblVersionGuid);
            this.Controls.Add(this.btnWebMikogo);
            this.Controls.Add(this.btnTeamViewer);
            this.Controls.Add(this.btnNetViewer);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this._lblemail);
            this.Controls.Add(this._lbWeb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHandbuch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Über PMDS";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPDF.ClientArea.ResumeLayout(false);
            this.pnlPDF.ClientArea.PerformLayout();
            this.pnlPDF.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ProcessStart(string sText) 
		{
			try 
			{
				Process.Start(sText);
			}
			catch(Exception ex) 
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ex.Message, QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler beim Zugriff auf externe Programme"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
			}
		}

		private void lbWeb_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ProcessStart(_lbWeb.Text);
		}

		private void lblemail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ProcessStart("mailto:office@s2-engineering.com&subject=Informationsanforderung PMDS");
		}

        private void styleNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PMDS.Global.ENV.setStyleInfrag(true);
        }

        private void styleZurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PMDS.Global.ENV.setStyleInfrag(false );
        }

        private void testExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                throw new Exception("This is a test exception!");

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex, "", true, true, "Error in a Text-Function!");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnNetViewer_Click(object sender, EventArgs e)
        {
            PMDS.GUI.VB.clFolder clFold = new PMDS.GUI.VB.clFolder();
            if (File.Exists(Application.StartupPath + "\\FastViewer.exe"))
                clFold.runShell(Application.StartupPath + "\\FastViewer.exe");
            else
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Remoteunterstützung kann nicht gestartet werden.");
            this.Close();
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            PMDS.GUI.VB.clFolder clFold = new PMDS.GUI.VB.clFolder();
            if (File.Exists(Application.StartupPath + "\\TeamViewer-S2-Client.exe"))
                clFold.runShell(Application.StartupPath + "\\TeamViewer-S2-Client.exe");
            else
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Remoteunterstützung kann nicht gestartet werden.");
            this.Close();
        }

        private void btnHandbuch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(fiPMDS_Handbuch.FullName);
                this.Close();
            }

            catch (Exception ex)
            {
                var result = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kann Handbuch ") + fiPMDS_Handbuch.FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(" nicht öffnen. Ist ein PDF-Reader installiert?"), true);
            }
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.btnHandbuch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Help, 32, 32);
        }

        private void checkSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                string prot = "";
                int iErrorsFound = 0;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    bool OK = b.CheckDb(db, ref prot, ref iErrorsFound);

                    if (prot.Trim() == "")
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("System-Check: All OK!", "System-Check");
                    }
                    else
                    {
                        PMDS.Calc.UI.Admin.frmProtocoll frmProtocoll1 = new PMDS.Calc.UI.Admin.frmProtocoll();
                        frmProtocoll1.Text = "System-Check - " + iErrorsFound.ToString() + " Errors found!";
                        frmProtocoll1.txtProtocoll.Text = prot.Trim();
                        frmProtocoll1.Show();

                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void runGACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                System.GC.Collect();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void formularDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.GUI.GUI.Main.frmFormularManager frm = new GUI.GUI.Main.frmFormularManager();
                frm.initControl();
                frm.Show();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        

        private void formulareInPDFKonvertierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.GUI.Misc.Convert_S2Frm_FDF fConvert = new GUI.Misc.Convert_S2Frm_FDF();
                fConvert.Show();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void sytemAdministrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.GUI.GUI.Main.frmSys frmSys1 = new GUI.GUI.Main.frmSys();
                frmSys1.Show();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void loadAllDataIntoRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDSBusinessRAM bRAm = new PMDSBusinessRAM();
                bRAm.loadDataStart(false, true, true, false);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Threads Ready!", "");
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void eLDAAbrechnungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.GUI.ELDA.frmELDA frm = new PMDS.GUI.ELDA.frmELDA();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.Global.Calc.ELDAAbrechung.cs.Init: " + ex.Message);
            }
        }
    }
}
