using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    partial class frmEditDynReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDynReports));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pnlParameters = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.ucBenutzerCheckList1 = new PMDS.GUI.BaseControls.ucBenutzerCheckList();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbAssembly = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbForm = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbDatasetAssembly = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bereichDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klasseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsDatenQuellen1 = new PMDS.Global.db.Global.dsDatenQuellen();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbUeberschrift = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.btnPlus = new QS2.Desktop.ControlManagment.BaseButtonWin();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButtonWin();
            this.pnlHeader = new QS2.Desktop.ControlManagment.BasePanel();
            this.pbImage = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.label2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.ultraTabControl1 = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.label3 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbAnzeigename = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatenQuellen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.pnlParameters);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(909, 509);
            // 
            // pnlParameters
            // 
            this.pnlParameters.AutoScroll = true;
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(909, 509);
            this.pnlParameters.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.cbAll);
            this.ultraTabPageControl2.Controls.Add(this.ucBenutzerCheckList1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(909, 509);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(2, 3);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(253, 17);
            this.cbAll.TabIndex = 2;
            this.cbAll.Text = "Den Zugriff auf folgende Benutzer einschränken";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // ucBenutzerCheckList1
            // 
            this.ucBenutzerCheckList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBenutzerCheckList1.Location = new System.Drawing.Point(0, 22);
            this.ucBenutzerCheckList1.Name = "ucBenutzerCheckList1";
            this.ucBenutzerCheckList1.SELECTED = ((System.Collections.Generic.List<System.Guid>)(resources.GetObject("ucBenutzerCheckList1.SELECTED")));
            this.ucBenutzerCheckList1.Size = new System.Drawing.Size(907, 486);
            this.ucBenutzerCheckList1.TabIndex = 0;
            this.ucBenutzerCheckList1.CheckedChanged += new System.EventHandler(this.ucBenutzerCheckList1_CheckedChanged);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl3.Controls.Add(this.tbAssembly);
            this.ultraTabPageControl3.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl3.Controls.Add(this.tbForm);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(909, 509);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(4, 53);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(692, 16);
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "Assembly wo die Form zu finden ist";
            // 
            // tbAssembly
            // 
            this.tbAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAssembly.Location = new System.Drawing.Point(3, 75);
            this.tbAssembly.Multiline = true;
            this.tbAssembly.Name = "tbAssembly";
            this.tbAssembly.Size = new System.Drawing.Size(646, 22);
            this.tbAssembly.TabIndex = 5;
            this.tbAssembly.TextChanged += new System.EventHandler(this.uc_Changed);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(3, 4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(692, 16);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "Formular (DynReportsForm) - Assembly.Namespace.Class zB.  PMDS.DynReportsForms.fr" +
    "mPrintPflegebegleitschreibenInfo";
            // 
            // tbForm
            // 
            this.tbForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbForm.Location = new System.Drawing.Point(2, 26);
            this.tbForm.Multiline = true;
            this.tbForm.Name = "tbForm";
            this.tbForm.Size = new System.Drawing.Size(646, 22);
            this.tbForm.TabIndex = 3;
            this.tbForm.TextChanged += new System.EventHandler(this.uc_Changed);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraLabel3);
            this.ultraTabPageControl4.Controls.Add(this.tbDatasetAssembly);
            this.ultraTabPageControl4.Controls.Add(this.dataGridView1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(909, 509);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(2, 3);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(692, 16);
            this.ultraLabel3.TabIndex = 8;
            this.ultraLabel3.Text = "Assembly wo die Datenquellen zu finden sind";
            // 
            // tbDatasetAssembly
            // 
            this.tbDatasetAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatasetAssembly.Location = new System.Drawing.Point(1, 25);
            this.tbDatasetAssembly.Multiline = true;
            this.tbDatasetAssembly.Name = "tbDatasetAssembly";
            this.tbDatasetAssembly.Size = new System.Drawing.Size(648, 22);
            this.tbDatasetAssembly.TabIndex = 7;
            this.tbDatasetAssembly.TextChanged += new System.EventHandler(this.uc_Changed);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bereichDataGridViewTextBoxColumn,
            this.klasseDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "DatenQuellen";
            this.dataGridView1.DataSource = this.dsDatenQuellen1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 438);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // bereichDataGridViewTextBoxColumn
            // 
            this.bereichDataGridViewTextBoxColumn.DataPropertyName = "Bereich";
            this.bereichDataGridViewTextBoxColumn.HeaderText = "Bereich";
            this.bereichDataGridViewTextBoxColumn.Name = "bereichDataGridViewTextBoxColumn";
            this.bereichDataGridViewTextBoxColumn.Width = 200;
            // 
            // klasseDataGridViewTextBoxColumn
            // 
            this.klasseDataGridViewTextBoxColumn.DataPropertyName = "Klasse";
            this.klasseDataGridViewTextBoxColumn.HeaderText = "Klasse";
            this.klasseDataGridViewTextBoxColumn.Name = "klasseDataGridViewTextBoxColumn";
            this.klasseDataGridViewTextBoxColumn.Width = 400;
            // 
            // dsDatenQuellen1
            // 
            this.dsDatenQuellen1.DataSetName = "dsDatenQuellen";
            this.dsDatenQuellen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Überschrift";
            // 
            // tbUeberschrift
            // 
            this.tbUeberschrift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUeberschrift.Location = new System.Drawing.Point(28, 18);
            this.tbUeberschrift.Multiline = true;
            this.tbUeberschrift.Name = "tbUeberschrift";
            this.tbUeberschrift.Size = new System.Drawing.Size(913, 32);
            this.tbUeberschrift.TabIndex = 0;
            this.tbUeberschrift.TextChanged += new System.EventHandler(this.uc_Changed);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlus.Location = new System.Drawing.Point(28, 622);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(31, 23);
            this.btnPlus.TabIndex = 3;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(65, 622);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(31, 23);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "-";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.Location = new System.Drawing.Point(28, 49);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(913, 25);
            this.pnlHeader.TabIndex = 12;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            this.pbImage.Appearance = appearance1;
            this.pbImage.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbImage.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.pbImage.Location = new System.Drawing.Point(947, 73);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(274, 543);
            this.pbImage.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(944, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Miniaturansicht";
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Location = new System.Drawing.Point(28, 81);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(913, 535);
            this.ultraTabControl1.TabIndex = 2;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Parameter";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Benutzer";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Formular";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "DatenQuellen";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(909, 509);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(943, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Anzeigename";
            // 
            // tbAnzeigename
            // 
            this.tbAnzeigename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnzeigename.Location = new System.Drawing.Point(945, 18);
            this.tbAnzeigename.Multiline = true;
            this.tbAnzeigename.Name = "tbAnzeigename";
            this.tbAnzeigename.Size = new System.Drawing.Size(267, 32);
            this.tbAnzeigename.TabIndex = 1;
            this.tbAnzeigename.TextChanged += new System.EventHandler(this.uc_Changed);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(991, 622);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 3;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance3;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(1095, 622);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditDynReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1224, 663);
            this.Controls.Add(this.tbAnzeigename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.tbUeberschrift);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "frmEditDynReports";
            this.Text = "Parameterdefinitionen des Reports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditDynReports_FormClosing);
            this.Load += new System.EventHandler(this.frmEditDynReports_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmEditDynReports_HelpRequested);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatenQuellen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlParameters;
        private QS2.Desktop.ControlManagment.BaseLableWin label1;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbUeberschrift;
        private QS2.Desktop.ControlManagment.BaseButtonWin btnPlus;
        private ucButton btnUndo;
        private ucButton btnSave;
        private QS2.Desktop.ControlManagment.BaseButtonWin btnDel;
        private QS2.Desktop.ControlManagment.BasePanel pnlHeader;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox pbImage;
        private QS2.Desktop.ControlManagment.BaseLableWin label2;
        private QS2.Desktop.ControlManagment.BaseTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private PMDS.GUI.BaseControls.ucBenutzerCheckList ucBenutzerCheckList1;
        private System.Windows.Forms.CheckBox cbAll;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbForm;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbAssembly;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsDatenQuellen dsDatenQuellen1;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbDatasetAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn bereichDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn klasseDataGridViewTextBoxColumn;
        private QS2.Desktop.ControlManagment.BaseLableWin label3;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbAnzeigename;

    }
}