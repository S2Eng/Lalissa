namespace PMDS.GUI.GUI.Main
{
    partial class frmFormularManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormularManager));
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.panelGird = new QS2.Desktop.ControlManagment.BasePanel();
            this.pdfToolStripViewModes1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes();
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripZoomEx1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.cboFormulare = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblFormulare = new Infragistics.Win.Misc.UltraLabel();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkInNotfallAnzeigenJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblFormularname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkGUI = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFormularname2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtBezeichnung2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPrint2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkNeuanlageSperren = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cboBerufsgruppen = new PMDS.GUI.Klient.cboAuswahllisteMulti();
            this.lblBerufsgruppen = new Infragistics.Win.Misc.UltraLabel();
            this.panelDoc = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormulare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInNotfallAnzeigenJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormularname2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNeuanlageSperren)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGird
            // 
            this.panelGird.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGird.Controls.Add(this.pdfToolStripViewModes1);
            this.panelGird.Controls.Add(this.pdfToolStripZoomEx1);
            this.panelGird.Controls.Add(this.pdfViewer1);
            this.panelGird.Location = new System.Drawing.Point(5, 178);
            this.panelGird.Margin = new System.Windows.Forms.Padding(4);
            this.panelGird.Name = "panelGird";
            this.panelGird.Size = new System.Drawing.Size(1112, 432);
            this.panelGird.TabIndex = 15;
            this.panelGird.Visible = false;
            // 
            // pdfToolStripViewModes1
            // 
            this.pdfToolStripViewModes1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripViewModes1.Location = new System.Drawing.Point(309, 4);
            this.pdfToolStripViewModes1.Name = "pdfToolStripViewModes1";
            this.pdfToolStripViewModes1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripViewModes1.Size = new System.Drawing.Size(177, 27);
            this.pdfToolStripViewModes1.TabIndex = 21;
            this.pdfToolStripViewModes1.Text = "pdfToolStripViewModes1";
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
            this.pdfViewer1.Location = new System.Drawing.Point(4, 38);
            this.pdfViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OptimizedLoadThreshold = 1000;
            this.pdfViewer1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
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
            this.pdfViewer1.Size = new System.Drawing.Size(1107, 392);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 4;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            this.pdfViewer1.BeforeDocumentChanged += new System.EventHandler<Patagames.Pdf.Net.EventArguments.DocumentClosingEventArgs>(this.pdfViewer1_BeforeDocumentChanged);
            this.pdfViewer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pdfViewer1_KeyPress);
            this.pdfViewer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseClick);
            // 
            // pdfToolStripZoomEx1
            // 
            this.pdfToolStripZoomEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoomEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.pdfToolStripZoomEx1.Location = new System.Drawing.Point(4, 4);
            this.pdfToolStripZoomEx1.Name = "pdfToolStripZoomEx1";
            this.pdfToolStripZoomEx1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoomEx1.Size = new System.Drawing.Size(214, 25);
            this.pdfToolStripZoomEx1.TabIndex = 5;
            this.pdfToolStripZoomEx1.Text = "pdfToolStripZoomEx1";
            this.pdfToolStripZoomEx1.ZoomLevel = new float[] {
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(986, 616);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 38);
            this.btnSave.TabIndex = 1001;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance1;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(1080, 140);
            this.btnDel.Margin = new System.Windows.Forms.Padding(5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(34, 29);
            this.btnDel.TabIndex = 101;
            this.btnDel.Tag = "";
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cboFormulare
            // 
            this.cboFormulare.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboFormulare.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboFormulare.Location = new System.Drawing.Point(165, 11);
            this.cboFormulare.Margin = new System.Windows.Forms.Padding(4);
            this.cboFormulare.Name = "cboFormulare";
            this.cboFormulare.Size = new System.Drawing.Size(601, 24);
            this.cboFormulare.TabIndex = 0;
            this.cboFormulare.ValueChanged += new System.EventHandler(this.cboFormulare_ValueChanged);
            // 
            // lblFormulare
            // 
            this.lblFormulare.Location = new System.Drawing.Point(20, 15);
            this.lblFormulare.Margin = new System.Windows.Forms.Padding(4);
            this.lblFormulare.Name = "lblFormulare";
            this.lblFormulare.Size = new System.Drawing.Size(104, 26);
            this.lblFormulare.TabIndex = 137;
            this.lblFormulare.Text = "Formular";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(1038, 140);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 29);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Tag = "";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkInNotfallAnzeigenJN
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.chkInNotfallAnzeigenJN.Appearance = appearance3;
            this.chkInNotfallAnzeigenJN.BackColor = System.Drawing.Color.Transparent;
            this.chkInNotfallAnzeigenJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkInNotfallAnzeigenJN.Location = new System.Drawing.Point(611, 148);
            this.chkInNotfallAnzeigenJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkInNotfallAnzeigenJN.Name = "chkInNotfallAnzeigenJN";
            this.chkInNotfallAnzeigenJN.Size = new System.Drawing.Size(155, 22);
            this.chkInNotfallAnzeigenJN.TabIndex = 13;
            this.chkInNotfallAnzeigenJN.Text = "Notfall anzeigen";
            // 
            // lblFormularname
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblFormularname.Appearance = appearance4;
            this.lblFormularname.AutoSize = true;
            this.lblFormularname.Location = new System.Drawing.Point(20, 44);
            this.lblFormularname.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.lblFormularname.Name = "lblFormularname";
            this.lblFormularname.Size = new System.Drawing.Size(92, 17);
            this.lblFormularname.TabIndex = 134;
            this.lblFormularname.Text = "Formularname";
            // 
            // chkGUI
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.chkGUI.Appearance = appearance5;
            this.chkGUI.BackColor = System.Drawing.Color.Transparent;
            this.chkGUI.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkGUI.Location = new System.Drawing.Point(165, 148);
            this.chkGUI.Margin = new System.Windows.Forms.Padding(4);
            this.chkGUI.Name = "chkGUI";
            this.chkGUI.Size = new System.Drawing.Size(225, 22);
            this.chkGUI.TabIndex = 12;
            this.chkGUI.Text = "Als Assessment anzeigen";
            // 
            // lblBezeichnung
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lblBezeichnung.Appearance = appearance6;
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(20, 76);
            this.lblBezeichnung.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(82, 17);
            this.lblBezeichnung.TabIndex = 136;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // txtFormularname2
            // 
            this.txtFormularname2.Location = new System.Drawing.Point(165, 41);
            this.txtFormularname2.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormularname2.Name = "txtFormularname2";
            this.txtFormularname2.ReadOnly = true;
            this.txtFormularname2.Size = new System.Drawing.Size(388, 24);
            this.txtFormularname2.TabIndex = 10;
            this.txtFormularname2.ValueChanged += new System.EventHandler(this.txtFormularname2_ValueChanged);
            // 
            // txtBezeichnung2
            // 
            this.txtBezeichnung2.Location = new System.Drawing.Point(165, 72);
            this.txtBezeichnung2.Margin = new System.Windows.Forms.Padding(4);
            this.txtBezeichnung2.Name = "txtBezeichnung2";
            this.txtBezeichnung2.Size = new System.Drawing.Size(388, 24);
            this.txtBezeichnung2.TabIndex = 11;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(878, 616);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(108, 38);
            this.btnAbort.TabIndex = 1000;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnPrint2
            // 
            this.btnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnPrint2.Appearance = appearance7;
            this.btnPrint2.AutoWorkLayout = false;
            this.btnPrint2.IsStandardControl = false;
            this.btnPrint2.Location = new System.Drawing.Point(999, 140);
            this.btnPrint2.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(32, 29);
            this.btnPrint2.TabIndex = 102;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // chkNeuanlageSperren
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.chkNeuanlageSperren.Appearance = appearance8;
            this.chkNeuanlageSperren.BackColor = System.Drawing.Color.Transparent;
            this.chkNeuanlageSperren.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkNeuanlageSperren.Location = new System.Drawing.Point(398, 148);
            this.chkNeuanlageSperren.Margin = new System.Windows.Forms.Padding(4);
            this.chkNeuanlageSperren.Name = "chkNeuanlageSperren";
            this.chkNeuanlageSperren.Size = new System.Drawing.Size(164, 22);
            this.chkNeuanlageSperren.TabIndex = 1002;
            this.chkNeuanlageSperren.Text = "Neuanlage sperren";
            // 
            // cboBerufsgruppen
            // 
            this.cboBerufsgruppen.Location = new System.Drawing.Point(165, 106);
            this.cboBerufsgruppen.Margin = new System.Windows.Forms.Padding(5);
            this.cboBerufsgruppen.Name = "cboBerufsgruppen";
            this.cboBerufsgruppen.Size = new System.Drawing.Size(601, 33);
            this.cboBerufsgruppen.TabIndex = 1004;
            // 
            // lblBerufsgruppen
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.lblBerufsgruppen.Appearance = appearance9;
            this.lblBerufsgruppen.Location = new System.Drawing.Point(20, 107);
            this.lblBerufsgruppen.Margin = new System.Windows.Forms.Padding(4);
            this.lblBerufsgruppen.Name = "lblBerufsgruppen";
            this.lblBerufsgruppen.Size = new System.Drawing.Size(135, 27);
            this.lblBerufsgruppen.TabIndex = 1003;
            this.lblBerufsgruppen.Text = "Berufsgruppen";
            // 
            // panelDoc
            // 
            this.panelDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDoc.BackColor = System.Drawing.Color.DarkGray;
            this.panelDoc.Location = new System.Drawing.Point(822, 11);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(292, 111);
            this.panelDoc.TabIndex = 1005;
            this.panelDoc.Visible = false;
            // 
            // frmFormularManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 661);
            this.Controls.Add(this.panelDoc);
            this.Controls.Add(this.cboBerufsgruppen);
            this.Controls.Add(this.lblBerufsgruppen);
            this.Controls.Add(this.chkNeuanlageSperren);
            this.Controls.Add(this.btnPrint2);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.txtBezeichnung2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFormularname2);
            this.Controls.Add(this.cboFormulare);
            this.Controls.Add(this.lblBezeichnung);
            this.Controls.Add(this.lblFormulare);
            this.Controls.Add(this.chkGUI);
            this.Controls.Add(this.lblFormularname);
            this.Controls.Add(this.chkInNotfallAnzeigenJN);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelGird);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFormularManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formularmanager";
            this.Load += new System.EventHandler(this.frmFormularManager_Load);
            this.panelGird.ResumeLayout(false);
            this.panelGird.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormulare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInNotfallAnzeigenJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormularname2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNeuanlageSperren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelGird;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes pdfToolStripViewModes1;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx pdfToolStripZoomEx1;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboFormulare;
        private Infragistics.Win.Misc.UltraLabel lblFormulare;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkInNotfallAnzeigenJN;
        public QS2.Desktop.ControlManagment.BaseLabel lblFormularname;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkGUI;
        public QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFormularname2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBezeichnung2;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        private QS2.Desktop.ControlManagment.BaseButton btnPrint2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkNeuanlageSperren;
        public Klient.cboAuswahllisteMulti cboBerufsgruppen;
        private Infragistics.Win.Misc.UltraLabel lblBerufsgruppen;
        private QS2.Desktop.ControlManagment.BasePanel panelDoc;
    }
}