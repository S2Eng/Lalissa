namespace PMDS.GUI
{

    partial class ucAssessement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAssessement));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Liste der gefundenen Einträge drucken", Infragistics.Win.ToolTipImage.Default, "Liste drucken", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panelUntenRechts = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAbbrechen = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.contextMenuStripSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formularAlsDatasetSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGird = new QS2.Desktop.ControlManagment.BasePanel();
            this.pdfToolStripViewModes1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes();
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripZoomEx1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelOben2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnPrint2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbdocken = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelObenRechts = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new PMDS.GUI.ucButton(this.components);
            this.btnNeu = new PMDS.GUI.ucButton(this.components);
            this.bntLöschen = new PMDS.GUI.ucButton(this.components);
            this.ucFormAsses1 = new PMDS.GUI.BaseControls.ucFormAsses();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelPdfViewer = new System.Windows.Forms.Panel();
            this.panelTree = new System.Windows.Forms.Panel();
            this.lblTitle = new Infragistics.Win.Misc.UltraLabel();
            this.panelPdfViewer2 = new System.Windows.Forms.Panel();
            this.panelUntenRechts.SuspendLayout();
            this.contextMenuStripSave.SuspendLayout();
            this.panelGird.SuspendLayout();
            this.panelUnten.SuspendLayout();
            this.panelOben2.SuspendLayout();
            this.panelButtonOben.SuspendLayout();
            this.panelObenRechts.SuspendLayout();
            this.panelPdfViewer.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.panelPdfViewer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUntenRechts
            // 
            this.panelUntenRechts.Controls.Add(this.btnAbbrechen);
            this.panelUntenRechts.Controls.Add(this.btnSave);
            this.panelUntenRechts.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUntenRechts.Location = new System.Drawing.Point(235, 0);
            this.panelUntenRechts.Name = "panelUntenRechts";
            this.panelUntenRechts.Size = new System.Drawing.Size(369, 36);
            this.panelUntenRechts.TabIndex = 3;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbbrechen.Appearance = appearance1;
            this.btnAbbrechen.AutoWorkLayout = false;
            this.btnAbbrechen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAbbrechen.DoOnClick = true;
            this.btnAbbrechen.IsStandardControl = true;
            this.btnAbbrechen.Location = new System.Drawing.Point(163, 1);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(89, 32);
            this.btnAbbrechen.TabIndex = 7;
            this.btnAbbrechen.TabStop = false;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnAbbrechen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.ContextMenuStrip = this.contextMenuStripSave;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(253, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.VisibleChanged += new System.EventHandler(this.btnSave_VisibleChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // contextMenuStripSave
            // 
            this.contextMenuStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularAlsDatasetSpeichernToolStripMenuItem});
            this.contextMenuStripSave.Name = "contextMenuStrip2";
            this.contextMenuStripSave.Size = new System.Drawing.Size(236, 26);
            // 
            // formularAlsDatasetSpeichernToolStripMenuItem
            // 
            this.formularAlsDatasetSpeichernToolStripMenuItem.Name = "formularAlsDatasetSpeichernToolStripMenuItem";
            this.formularAlsDatasetSpeichernToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.formularAlsDatasetSpeichernToolStripMenuItem.Text = "Formular als Dataset speichern";
            this.formularAlsDatasetSpeichernToolStripMenuItem.Click += new System.EventHandler(this.formularAlsDatasetSpeichernToolStripMenuItem_Click);
            // 
            // panelGird
            // 
            this.panelGird.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGird.Controls.Add(this.pdfToolStripViewModes1);
            this.panelGird.Controls.Add(this.pdfToolStripZoomEx1);
            this.panelGird.Controls.Add(this.pdfViewer1);
            this.panelGird.Location = new System.Drawing.Point(1, 38);
            this.panelGird.Name = "panelGird";
            this.panelGird.Size = new System.Drawing.Size(599, 404);
            this.panelGird.TabIndex = 14;
            // 
            // pdfToolStripViewModes1
            // 
            this.pdfToolStripViewModes1.BackColor = System.Drawing.Color.Transparent;
            this.pdfToolStripViewModes1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripViewModes1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripViewModes1.Location = new System.Drawing.Point(232, 3);
            this.pdfToolStripViewModes1.Name = "pdfToolStripViewModes1";
            this.pdfToolStripViewModes1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripViewModes1.Size = new System.Drawing.Size(133, 27);
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
            this.pdfViewer1.Location = new System.Drawing.Point(2, 32);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
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
            this.pdfViewer1.Size = new System.Drawing.Size(596, 370);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 4;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            this.pdfViewer1.BeforeDocumentChanged += new System.EventHandler<Patagames.Pdf.Net.EventArguments.DocumentClosingEventArgs>(this.pdfViewer1_BeforeDocumentChanged);
            this.pdfViewer1.Load += new System.EventHandler(this.pdfViewer1_Load);
            this.pdfViewer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseClick);
            // 
            // pdfToolStripZoomEx1
            // 
            this.pdfToolStripZoomEx1.BackColor = System.Drawing.Color.Transparent;
            this.pdfToolStripZoomEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoomEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripZoomEx1.Location = new System.Drawing.Point(3, 3);
            this.pdfToolStripZoomEx1.Name = "pdfToolStripZoomEx1";
            this.pdfToolStripZoomEx1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoomEx1.Size = new System.Drawing.Size(203, 23);
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
            // panelUnten
            // 
            this.panelUnten.Controls.Add(this.panelUntenRechts);
            this.panelUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUnten.Location = new System.Drawing.Point(0, 445);
            this.panelUnten.Name = "panelUnten";
            this.panelUnten.Size = new System.Drawing.Size(604, 36);
            this.panelUnten.TabIndex = 13;
            // 
            // panelOben2
            // 
            this.panelOben2.Controls.Add(this.panelButtonOben);
            this.panelOben2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben2.Location = new System.Drawing.Point(0, 0);
            this.panelOben2.Name = "panelOben2";
            this.panelOben2.Size = new System.Drawing.Size(604, 36);
            this.panelOben2.TabIndex = 2;
            // 
            // panelButtonOben
            // 
            this.panelButtonOben.Controls.Add(this.btnPrint2);
            this.panelButtonOben.Controls.Add(this.btnAbdocken);
            this.panelButtonOben.Controls.Add(this.panelObenRechts);
            this.panelButtonOben.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonOben.Location = new System.Drawing.Point(0, 0);
            this.panelButtonOben.Name = "panelButtonOben";
            this.panelButtonOben.Size = new System.Drawing.Size(604, 36);
            this.panelButtonOben.TabIndex = 17;
            // 
            // btnPrint2
            // 
            this.btnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnPrint2.Appearance = appearance3;
            this.btnPrint2.AutoWorkLayout = false;
            this.btnPrint2.IsStandardControl = false;
            this.btnPrint2.Location = new System.Drawing.Point(454, 4);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(38, 29);
            this.btnPrint2.TabIndex = 158;
            ultraToolTipInfo1.ToolTipText = "Liste der gefundenen Einträge drucken";
            ultraToolTipInfo1.ToolTipTitle = "Liste drucken";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPrint2, ultraToolTipInfo1);
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // btnAbdocken
            // 
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbdocken.Appearance = appearance5;
            this.btnAbdocken.AutoWorkLayout = false;
            this.btnAbdocken.IsStandardControl = false;
            this.btnAbdocken.Location = new System.Drawing.Point(6, 4);
            this.btnAbdocken.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbdocken.Name = "btnAbdocken";
            this.btnAbdocken.Size = new System.Drawing.Size(66, 29);
            this.btnAbdocken.TabIndex = 19;
            this.btnAbdocken.Tag = "";
            this.btnAbdocken.Text = "Abdocken";
            this.btnAbdocken.Click += new System.EventHandler(this.btnAbdocken_Click);
            // 
            // panelObenRechts
            // 
            this.panelObenRechts.Controls.Add(this.btnClose);
            this.panelObenRechts.Controls.Add(this.btnNeu);
            this.panelObenRechts.Controls.Add(this.bntLöschen);
            this.panelObenRechts.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelObenRechts.Location = new System.Drawing.Point(500, 0);
            this.panelObenRechts.Name = "panelObenRechts";
            this.panelObenRechts.Size = new System.Drawing.Size(104, 36);
            this.panelObenRechts.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance6;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DoOnClick = true;
            this.btnClose.ImageSize = new System.Drawing.Size(12, 12);
            this.btnClose.IsStandardControl = true;
            this.btnClose.Location = new System.Drawing.Point(69, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 29);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = false;
            this.btnClose.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnClose.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNeu
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.FontData.SizeInPoints = 14F;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnNeu.Appearance = appearance7;
            this.btnNeu.AutoWorkLayout = false;
            this.btnNeu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNeu.DoOnClick = true;
            this.btnNeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNeu.ImageSize = new System.Drawing.Size(12, 12);
            this.btnNeu.IsStandardControl = true;
            this.btnNeu.Location = new System.Drawing.Point(5, 4);
            this.btnNeu.Name = "btnNeu";
            this.btnNeu.Size = new System.Drawing.Size(29, 29);
            this.btnNeu.TabIndex = 5;
            this.btnNeu.TabStop = false;
            this.btnNeu.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnNeu.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnNeu.Click += new System.EventHandler(this.btnNeu_Click);
            // 
            // bntLöschen
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.bntLöschen.Appearance = appearance8;
            this.bntLöschen.AutoWorkLayout = false;
            this.bntLöschen.Cursor = System.Windows.Forms.Cursors.Default;
            this.bntLöschen.DoOnClick = true;
            this.bntLöschen.ImageSize = new System.Drawing.Size(12, 12);
            this.bntLöschen.IsStandardControl = true;
            this.bntLöschen.Location = new System.Drawing.Point(34, 4);
            this.bntLöschen.Name = "bntLöschen";
            this.bntLöschen.Size = new System.Drawing.Size(29, 29);
            this.bntLöschen.TabIndex = 6;
            this.bntLöschen.TabStop = false;
            this.bntLöschen.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.bntLöschen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.bntLöschen.Click += new System.EventHandler(this.bntLöschen_Click);
            // 
            // ucFormAsses1
            // 
            this.ucFormAsses1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFormAsses1.BackColor = System.Drawing.Color.Transparent;
            this.ucFormAsses1.Location = new System.Drawing.Point(3, 28);
            this.ucFormAsses1.Name = "ucFormAsses1";
            this.ucFormAsses1.Size = new System.Drawing.Size(220, 449);
            this.ucFormAsses1.TabIndex = 6;
            this.ucFormAsses1.evClickEvent += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.ucFormAsses1_evClickEvent2);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panelPdfViewer
            // 
            this.panelPdfViewer.BackColor = System.Drawing.Color.Transparent;
            this.panelPdfViewer.Controls.Add(this.panelUnten);
            this.panelPdfViewer.Controls.Add(this.panelGird);
            this.panelPdfViewer.Controls.Add(this.panelOben2);
            this.panelPdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPdfViewer.Location = new System.Drawing.Point(0, 0);
            this.panelPdfViewer.Name = "panelPdfViewer";
            this.panelPdfViewer.Size = new System.Drawing.Size(604, 481);
            this.panelPdfViewer.TabIndex = 13;
            // 
            // panelTree
            // 
            this.panelTree.BackColor = System.Drawing.Color.Transparent;
            this.panelTree.Controls.Add(this.lblTitle);
            this.panelTree.Controls.Add(this.ucFormAsses1);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTree.Location = new System.Drawing.Point(0, 0);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(226, 481);
            this.panelTree.TabIndex = 14;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.TextVAlignAsString = "Middle";
            this.lblTitle.Appearance = appearance4;
            this.lblTitle.Location = new System.Drawing.Point(9, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 16);
            this.lblTitle.TabIndex = 15;
            // 
            // panelPdfViewer2
            // 
            this.panelPdfViewer2.BackColor = System.Drawing.Color.Transparent;
            this.panelPdfViewer2.Controls.Add(this.panelPdfViewer);
            this.panelPdfViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPdfViewer2.Location = new System.Drawing.Point(226, 0);
            this.panelPdfViewer2.Name = "panelPdfViewer2";
            this.panelPdfViewer2.Size = new System.Drawing.Size(604, 481);
            this.panelPdfViewer2.TabIndex = 15;
            // 
            // ucAssessement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelPdfViewer2);
            this.Controls.Add(this.panelTree);
            this.Name = "ucAssessement";
            this.Size = new System.Drawing.Size(830, 481);
            this.Load += new System.EventHandler(this.ucAssessement_Load);
            this.VisibleChanged += new System.EventHandler(this.ucAssessement_VisibleChanged);
            this.Resize += new System.EventHandler(this.ucAssessement_Resize);
            this.panelUntenRechts.ResumeLayout(false);
            this.contextMenuStripSave.ResumeLayout(false);
            this.panelGird.ResumeLayout(false);
            this.panelGird.PerformLayout();
            this.panelUnten.ResumeLayout(false);
            this.panelOben2.ResumeLayout(false);
            this.panelButtonOben.ResumeLayout(false);
            this.panelObenRechts.ResumeLayout(false);
            this.panelPdfViewer.ResumeLayout(false);
            this.panelTree.ResumeLayout(false);
            this.panelPdfViewer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private PMDS.GUI.BaseControls.ucFormAsses ucFormAsses1;
        private QS2.Desktop.ControlManagment.BasePanel panelUntenRechts;
        private ucButton btnNeu;
        private ucButton btnSave;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonOben;
        private ucButton bntLöschen;
        private ucButton btnAbbrechen;
        private QS2.Desktop.ControlManagment.BasePanel panelOben2;
        private QS2.Desktop.ControlManagment.BasePanel panelGird;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelObenRechts;
        private ucButton btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSave;
        private System.Windows.Forms.ToolStripMenuItem formularAlsDatasetSpeichernToolStripMenuItem;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx pdfToolStripZoomEx1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes pdfToolStripViewModes1;
        private System.Windows.Forms.Panel panelPdfViewer;
        public QS2.Desktop.ControlManagment.BaseButton btnAbdocken;
        private QS2.Desktop.ControlManagment.BaseButton btnPrint2;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel panelPdfViewer2;
        private Infragistics.Win.Misc.UltraLabel lblTitle;
    }
}
