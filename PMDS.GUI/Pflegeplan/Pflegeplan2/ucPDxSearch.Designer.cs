using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    partial class ucPDxSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPDxSearch));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tvSpecific = new PMDS.GUI.ucASZMSelectorTreeView2();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.pnlLegende = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblLegende = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pbHaken = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.btnSelectNo = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSelectAll = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tvGenerell = new PMDS.GUI.ucASZMSelectorTreeView2();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblSearch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbTop10 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cbTop10Allgemein = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cbAnamnesen = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tbSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tabASZM = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAddMissingASZM = new QS2.Desktop.ControlManagment.BaseButton();
            this.dsPdxBezeichnung = new dsIDTextBezeichnung();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dsPDxEintragSpecific = new dsPDxEintrag();
            this.dsPDxEintragGenerell = new dsPDxEintrag();
            this.ultraTabPageControl2.SuspendLayout();
            this.pnlLegende.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10Allgemein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnamnesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabASZM)).BeginInit();
            this.tabASZM.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPdxBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragSpecific)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragGenerell)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.tvSpecific);
            this.ultraTabPageControl2.Controls.Add(this.btnCancel);
            this.ultraTabPageControl2.Controls.Add(this.btnOk);
            this.ultraTabPageControl2.Controls.Add(this.pnlLegende);
            this.ultraTabPageControl2.Controls.Add(this.btnSelectNo);
            this.ultraTabPageControl2.Controls.Add(this.btnSelectAll);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(411, 292);
            this.ultraTabPageControl2.Tag = "Dontpatch";
            // 
            // tvSpecific
            // 
            this.tvSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSpecific.Location = new System.Drawing.Point(3, 3);
            this.tvSpecific.Name = "tvSpecific";
            this.tvSpecific.Size = new System.Drawing.Size(405, 238);
            this.tvSpecific.TabIndex = 3;
            this.tvSpecific.TreeviewAfterNodeSelectEventHandler += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_TreeviewAfterNodeSelectEventHandler);
            this.tvSpecific.TreeviewBeforeNodeSelectEventArgs += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.tv_TreeviewBeforeNodeSelectEventArgs);
            this.tvSpecific.TreeviewBeforeNodeChangedEventHandler += new Infragistics.Win.UltraWinTree.BeforeNodeChangedEventHandler(this.tv_TreeviewBeforeNodeChangedEventHandler);
            this.tvSpecific.TreeviewBeforeCheckEventHandler += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.tv_TreeviewBeforeCheckEventHandler);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(266, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 24);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance2;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DoOnClick = true;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(359, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 24);
            this.btnOk.TabIndex = 18;
            this.btnOk.TabStop = false;
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlLegende
            // 
            this.pnlLegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLegende.BackColor = System.Drawing.Color.Transparent;
            this.pnlLegende.Controls.Add(this.lblLegende);
            this.pnlLegende.Controls.Add(this.pbHaken);
            this.pnlLegende.Location = new System.Drawing.Point(1, 244);
            this.pnlLegende.Name = "pnlLegende";
            this.pnlLegende.Size = new System.Drawing.Size(373, 20);
            this.pnlLegende.TabIndex = 10;
            // 
            // lblLegende
            // 
            this.lblLegende.AutoSize = true;
            this.lblLegende.Location = new System.Drawing.Point(23, 3);
            this.lblLegende.Name = "lblLegende";
            this.lblLegende.Size = new System.Drawing.Size(264, 14);
            this.lblLegende.TabIndex = 8;
            this.lblLegende.Text = "Bereits im Pflegeplan enthaltene Pflegedefinitionen.";
            // 
            // pbHaken
            // 
            this.pbHaken.AutoSize = true;
            this.pbHaken.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbHaken.Image = ((object)(resources.GetObject("pbHaken.Image")));
            this.pbHaken.Location = new System.Drawing.Point(5, 4);
            this.pbHaken.Name = "pbHaken";
            this.pbHaken.Size = new System.Drawing.Size(12, 12);
            this.pbHaken.TabIndex = 7;
            // 
            // btnSelectNo
            // 
            this.btnSelectNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNo.AutoWorkLayout = false;
            this.btnSelectNo.IsStandardControl = false;
            this.btnSelectNo.Location = new System.Drawing.Point(97, 266);
            this.btnSelectNo.Name = "btnSelectNo";
            this.btnSelectNo.Size = new System.Drawing.Size(101, 24);
            this.btnSelectNo.TabIndex = 5;
            this.btnSelectNo.Text = "Keine auswählen";
            this.btnSelectNo.Click += new System.EventHandler(this.btnSelectNo_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.AutoWorkLayout = false;
            this.btnSelectAll.IsStandardControl = false;
            this.btnSelectAll.Location = new System.Drawing.Point(0, 266);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(94, 24);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "Alle auswählen";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.tvGenerell);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(411, 292);
            // 
            // tvGenerell
            // 
            this.tvGenerell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvGenerell.Location = new System.Drawing.Point(3, 2);
            this.tvGenerell.Name = "tvGenerell";
            this.tvGenerell.Size = new System.Drawing.Size(399, 233);
            this.tvGenerell.TabIndex = 3;
            this.tvGenerell.TreeviewAfterNodeSelectEventHandler += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_TreeviewAfterNodeSelectEventHandler);
            this.tvGenerell.TreeviewBeforeNodeSelectEventArgs += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.tv_TreeviewBeforeNodeSelectEventArgs);
            this.tvGenerell.TreeviewBeforeNodeChangedEventHandler += new Infragistics.Win.UltraWinTree.BeforeNodeChangedEventHandler(this.tv_TreeviewBeforeNodeChangedEventHandler);
            this.tvGenerell.TreeviewBeforeCheckEventHandler += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.tv_TreeviewBeforeCheckEventHandler);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.label2);
            this.ultraTabPageControl5.Controls.Add(this.label1);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(411, 292);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Treffen Sie eine andere Auswahl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Es wurden keine Einträge gefunden";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(38, 14);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "xxxxxx";
            // 
            // cbTop10
            // 
            this.cbTop10.DisplayMember = "Text";
            this.cbTop10.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbTop10.Location = new System.Drawing.Point(2, 18);
            this.cbTop10.Name = "cbTop10";
            this.cbTop10.Size = new System.Drawing.Size(222, 22);
            this.cbTop10.TabIndex = 13;
            this.cbTop10.ValueMember = "ID";
            this.cbTop10.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbTop10.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            // 
            // cbTop10Allgemein
            // 
            this.cbTop10Allgemein.DisplayMember = "Text";
            this.cbTop10Allgemein.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbTop10Allgemein.Location = new System.Drawing.Point(18, 14);
            this.cbTop10Allgemein.Name = "cbTop10Allgemein";
            this.cbTop10Allgemein.Size = new System.Drawing.Size(33, 22);
            this.cbTop10Allgemein.TabIndex = 14;
            this.cbTop10Allgemein.ValueMember = "ID";
            this.cbTop10Allgemein.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbTop10Allgemein.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            // 
            // cbAnamnesen
            // 
            this.cbAnamnesen.DisplayMember = "Text";
            this.cbAnamnesen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbAnamnesen.Location = new System.Drawing.Point(57, 14);
            this.cbAnamnesen.Name = "cbAnamnesen";
            this.cbAnamnesen.Size = new System.Drawing.Size(38, 22);
            this.cbAnamnesen.TabIndex = 15;
            this.cbAnamnesen.ValueMember = "ID";
            this.cbAnamnesen.AfterCloseUp += new System.EventHandler(this.cbTop10_AfterCloseUp);
            this.cbAnamnesen.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTop10_BeforeDropDown);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(101, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(58, 21);
            this.tbSearch.TabIndex = 17;
            this.tbSearch.WordWrap = false;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // tabASZM
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tabASZM.ActiveTabAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabASZM.Appearance = appearance4;
            this.tabASZM.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabASZM.Controls.Add(this.ultraTabPageControl1);
            this.tabASZM.Controls.Add(this.ultraTabPageControl2);
            this.tabASZM.Controls.Add(this.ultraTabPageControl5);
            this.tabASZM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabASZM.Location = new System.Drawing.Point(0, 0);
            this.tabASZM.Name = "tabASZM";
            this.tabASZM.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.btnCancel,
            this.btnOk,
            this.pnlLegende,
            this.btnSelectNo,
            this.btnSelectAll});
            this.tabASZM.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabASZM.Size = new System.Drawing.Size(415, 318);
            this.tabASZM.TabIndex = 19;
            ultraTab1.Key = "Abteilung";
            ultraTab1.TabPage = this.ultraTabPageControl2;
            ultraTab1.Tag = "Abteilung: {0}";
            ultraTab1.Text = "Abteilung: {0}";
            ultraTab2.Key = "Generell";
            ultraTab2.TabPage = this.ultraTabPageControl1;
            ultraTab2.Tag = "Für alle Abteilungen ({0} Elemente)";
            ultraTab2.Text = "Für alle Abteilungen";
            ultraTab3.Key = "keine";
            ultraTab3.TabPage = this.ultraTabPageControl5;
            ultraTab3.Text = "Keine Einträge gefunden";
            this.tabASZM.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3});
            this.tabASZM.Tag = "";
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.btnCancel);
            this.ultraTabSharedControlsPage1.Controls.Add(this.btnOk);
            this.ultraTabSharedControlsPage1.Controls.Add(this.pnlLegende);
            this.ultraTabSharedControlsPage1.Controls.Add(this.btnSelectNo);
            this.ultraTabSharedControlsPage1.Controls.Add(this.btnSelectAll);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(411, 292);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.cbTop10Allgemein);
            this.panel1.Controls.Add(this.cbAnamnesen);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.cbTop10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 42);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddMissingASZM);
            this.panel2.Controls.Add(this.tabASZM);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 318);
            this.panel2.TabIndex = 21;
            // 
            // btnAddMissingASZM
            // 
            this.btnAddMissingASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAddMissingASZM.Appearance = appearance5;
            this.btnAddMissingASZM.AutoWorkLayout = false;
            this.btnAddMissingASZM.IsStandardControl = false;
            this.btnAddMissingASZM.Location = new System.Drawing.Point(356, 0);
            this.btnAddMissingASZM.Name = "btnAddMissingASZM";
            this.btnAddMissingASZM.Size = new System.Drawing.Size(56, 22);
            this.btnAddMissingASZM.TabIndex = 28;
            this.btnAddMissingASZM.Text = "+";
            this.btnAddMissingASZM.Visible = false;
            this.btnAddMissingASZM.Click += new System.EventHandler(this.btnAddMissingASZM_Click);
            // 
            // dsPdxBezeichnung
            // 
            this.dsPdxBezeichnung.DataSetName = "dsIDTextBezeichnung";
            this.dsPdxBezeichnung.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPdxBezeichnung.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dsPDxEintragSpecific
            // 
            this.dsPDxEintragSpecific.DataSetName = "dsPDxEintrag";
            this.dsPDxEintragSpecific.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintragSpecific.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPDxEintragGenerell
            // 
            this.dsPDxEintragGenerell.DataSetName = "dsPDxEintrag";
            this.dsPDxEintragGenerell.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintragGenerell.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucPDxSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPDxSearch";
            this.Size = new System.Drawing.Size(415, 360);
            this.Load += new System.EventHandler(this.ucPDxSearch_Load);
            this.VisibleChanged += new System.EventHandler(this.ucPDxSearch_VisibleChanged);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.pnlLegende.ResumeLayout(false);
            this.pnlLegende.PerformLayout();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTop10Allgemein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnamnesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabASZM)).EndInit();
            this.tabASZM.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsPdxBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragSpecific)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintragGenerell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblSearch;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbTop10;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbTop10Allgemein;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbAnamnesen;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbSearch;
        private ucButton btnOk;
        private QS2.Desktop.ControlManagment.BaseTabControl tabASZM;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private PMDS.GUI.ucASZMSelectorTreeView2 tvGenerell;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectNo;
        private QS2.Desktop.ControlManagment.BaseButton btnSelectAll;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private QS2.Desktop.ControlManagment.BaseLableWin label2;
        private QS2.Desktop.ControlManagment.BaseLableWin label1;
        private QS2.Desktop.ControlManagment.BasePanel pnlLegende;
        private QS2.Desktop.ControlManagment.BaseLabel lblLegende;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox pbHaken;
        private dsIDTextBezeichnung dsPdxBezeichnung;
        private dsPDxEintrag dsPDxEintragSpecific;
        private dsPDxEintrag dsPDxEintragGenerell;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BasePanel panel2;
        private QS2.Desktop.ControlManagment.BaseButton btnAddMissingASZM;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public ucASZMSelectorTreeView2 tvSpecific;
    }
}
