using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    partial class ucPdx2
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPdx2));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Search");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.tabPageAlleAbteilungen = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucPdxVerwAlgemein = new PMDS.GUI.ucPdxVerwaltung();
            this.panel4 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.tabPDX = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnDelASZM = new PMDS.GUI.ucButton(this.components);
            this.btnAddASZM = new PMDS.GUI.ucButton(this.components);
            this.pnlButton = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.legZ = new PMDS.GUI.BaseControls.Legend();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.legS = new PMDS.GUI.BaseControls.Legend();
            this.legM = new PMDS.GUI.BaseControls.Legend();
            this.legA = new PMDS.GUI.BaseControls.Legend();
            this.panel5 = new QS2.Desktop.ControlManagment.BasePanel();
            this.optActiveJN = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.btnUpdate = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.cbPDX = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblAuswahl = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.dsPDxEintrag1 = new PMDS.Global.db.Pflegeplan.dsPDxEintrag();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tabPageAlleAbteilungen.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPDX)).BeginInit();
            this.tabPDX.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActiveJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintrag1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageAlleAbteilungen
            // 
            this.tabPageAlleAbteilungen.Controls.Add(this.ucPdxVerwAlgemein);
            this.tabPageAlleAbteilungen.Location = new System.Drawing.Point(1, 23);
            this.tabPageAlleAbteilungen.Name = "tabPageAlleAbteilungen";
            this.tabPageAlleAbteilungen.Size = new System.Drawing.Size(979, 563);
            // 
            // ucPdxVerwAlgemein
            // 
            this.ucPdxVerwAlgemein.BackColor = System.Drawing.Color.Transparent;
            this.ucPdxVerwAlgemein.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPdxVerwAlgemein.Location = new System.Drawing.Point(0, 0);
            this.ucPdxVerwAlgemein.Name = "ucPdxVerwAlgemein";
            this.ucPdxVerwAlgemein.Size = new System.Drawing.Size(979, 563);
            this.ucPdxVerwAlgemein.TabIndex = 0;
            this.ucPdxVerwAlgemein.ValueChanged += new System.EventHandler(this.ucPdxVerwaltung_ValueChanged);
            this.ucPdxVerwAlgemein.ASZMtoPDx += new PMDS.Global.ASZMtoPDxDelegate(this.ucPdxVerwaltung_ASZMtoPDx);
            this.ucPdxVerwAlgemein.ZuordnungChanged += new PMDS.Global.ZuordnungUpdateDelegate(this.ucPdxVerwaltung_ZuordnungChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.panel4.Controls.Add(this.btnDelASZM);
            this.panel4.Controls.Add(this.btnAddASZM);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(993, 599);
            this.panel4.TabIndex = 30;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.tabPDX);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(993, 599);
            this.ultraGridBagLayoutPanel1.TabIndex = 33;
            // 
            // tabPDX
            // 
            this.tabPDX.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabPDX.Controls.Add(this.tabPageAlleAbteilungen);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.tabPDX, gridBagConstraint1);
            this.tabPDX.Location = new System.Drawing.Point(5, 5);
            this.tabPDX.Name = "tabPDX";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.tabPDX, new System.Drawing.Size(983, 585));
            this.tabPDX.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabPDX.Size = new System.Drawing.Size(983, 589);
            this.tabPDX.TabIndex = 4;
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            ultraTab1.ClientAreaAppearance = appearance1;
            ultraTab1.Key = "AlleAbteilungen";
            ultraTab1.TabPage = this.tabPageAlleAbteilungen;
            ultraTab1.Tag = 0;
            ultraTab1.Text = "Für alle Abteilungen";
            this.tabPDX.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.tabPDX.Visible = false;
            this.tabPDX.ActiveTabChanging += new Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventHandler(this.tabPDX_ActiveTabChanging);
            this.tabPDX.ActiveTabChanged += new Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventHandler(this.tabPDX_ActiveTabChanged);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(979, 563);
            // 
            // btnDelASZM
            // 
            this.btnDelASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelASZM.Appearance = appearance2;
            this.btnDelASZM.AutoWorkLayout = false;
            this.btnDelASZM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelASZM.DoOnClick = true;
            this.btnDelASZM.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelASZM.IsStandardControl = true;
            this.btnDelASZM.Location = new System.Drawing.Point(964, 1);
            this.btnDelASZM.Name = "btnDelASZM";
            this.btnDelASZM.Size = new System.Drawing.Size(26, 19);
            this.btnDelASZM.TabIndex = 32;
            this.btnDelASZM.TabStop = false;
            this.btnDelASZM.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelASZM.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelASZM.Visible = false;
            this.btnDelASZM.Click += new System.EventHandler(this.btnDelASZM_Click);
            // 
            // btnAddASZM
            // 
            this.btnAddASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddASZM.Appearance = appearance3;
            this.btnAddASZM.AutoWorkLayout = false;
            this.btnAddASZM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddASZM.DoOnClick = true;
            this.btnAddASZM.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddASZM.IsStandardControl = true;
            this.btnAddASZM.Location = new System.Drawing.Point(937, 1);
            this.btnAddASZM.Name = "btnAddASZM";
            this.btnAddASZM.Size = new System.Drawing.Size(26, 19);
            this.btnAddASZM.TabIndex = 31;
            this.btnAddASZM.TabStop = false;
            this.btnAddASZM.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddASZM.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddASZM.Visible = false;
            this.btnAddASZM.Click += new System.EventHandler(this.btnAddASZM_Click);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnSave);
            this.pnlButton.Controls.Add(this.legZ);
            this.pnlButton.Controls.Add(this.btnUndo);
            this.pnlButton.Controls.Add(this.legS);
            this.pnlButton.Controls.Add(this.legM);
            this.pnlButton.Controls.Add(this.legA);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 632);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(993, 40);
            this.pnlButton.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance4;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(889, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 23;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // legZ
            // 
            this.legZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legZ.COLOR = System.Drawing.Color.Silver;
            this.legZ.LEGEND = "Ziele";
            this.legZ.Location = new System.Drawing.Point(243, 13);
            this.legZ.Name = "legZ";
            this.legZ.Size = new System.Drawing.Size(56, 12);
            this.legZ.TabIndex = 16;
            this.legZ.Visible = false;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance5;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(792, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 22;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // legS
            // 
            this.legS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legS.COLOR = System.Drawing.Color.Silver;
            this.legS.LEGEND = "Symptome";
            this.legS.Location = new System.Drawing.Point(142, 13);
            this.legS.Name = "legS";
            this.legS.Size = new System.Drawing.Size(89, 12);
            this.legS.TabIndex = 17;
            this.legS.Visible = false;
            // 
            // legM
            // 
            this.legM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legM.COLOR = System.Drawing.Color.Silver;
            this.legM.LEGEND = "Maßnahmen";
            this.legM.Location = new System.Drawing.Point(334, 13);
            this.legM.Name = "legM";
            this.legM.Size = new System.Drawing.Size(88, 12);
            this.legM.TabIndex = 15;
            this.legM.Visible = false;
            // 
            // legA
            // 
            this.legA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legA.AutoSize = true;
            this.legA.COLOR = System.Drawing.Color.Silver;
            this.legA.LEGEND = "Ätiol./Ris.Fakt.";
            this.legA.Location = new System.Drawing.Point(11, 11);
            this.legA.Name = "legA";
            this.legA.Size = new System.Drawing.Size(125, 14);
            this.legA.TabIndex = 18;
            this.legA.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.optActiveJN);
            this.panel5.Controls.Add(this.btnUpdate);
            this.panel5.Controls.Add(this.btnDel);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Controls.Add(this.cbPDX);
            this.panel5.Controls.Add(this.lblAuswahl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(993, 33);
            this.panel5.TabIndex = 31;
            // 
            // optActiveJN
            // 
            this.optActiveJN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optActiveJN.BackColor = System.Drawing.Color.Transparent;
            this.optActiveJN.BackColorInternal = System.Drawing.Color.Transparent;
            this.optActiveJN.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optActiveJN.CheckedIndex = 0;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = -1;
            valueListItem1.DisplayText = "Alle";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Nur Aktive";
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Nur Entfernte";
            this.optActiveJN.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optActiveJN.Location = new System.Drawing.Point(663, 10);
            this.optActiveJN.Name = "optActiveJN";
            this.optActiveJN.Size = new System.Drawing.Size(202, 15);
            this.optActiveJN.TabIndex = 167;
            this.optActiveJN.Text = "Alle";
            this.optActiveJN.ValueChanged += new System.EventHandler(this.optActiveJN_ValueChanged);
            // 
            // btnUpdate
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdate.Appearance = appearance6;
            this.btnUpdate.AutoWorkLayout = false;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.DoOnClick = true;
            this.btnUpdate.ImageSize = new System.Drawing.Size(12, 12);
            this.btnUpdate.IsStandardControl = true;
            this.btnUpdate.Location = new System.Drawing.Point(616, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(26, 22);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.TYPE = PMDS.GUI.ucButton.ButtonType.edit;
            this.btnUpdate.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance7;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(591, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(26, 22);
            this.btnDel.TabIndex = 30;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance8;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(566, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 22);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbPDX
            // 
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            editorButton1.Appearance = appearance9;
            editorButton1.Key = "Search";
            this.cbPDX.ButtonsRight.Add(editorButton1);
            this.cbPDX.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbPDX.Location = new System.Drawing.Point(149, 6);
            this.cbPDX.Name = "cbPDX";
            this.cbPDX.Size = new System.Drawing.Size(416, 21);
            this.cbPDX.TabIndex = 20;
            this.cbPDX.ValueChanged += new System.EventHandler(this.cbPDX_ValueChanged);
            this.cbPDX.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cbPDX_EditorButtonClick);
            // 
            // lblAuswahl
            // 
            this.lblAuswahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuswahl.Location = new System.Drawing.Point(5, 6);
            this.lblAuswahl.Name = "lblAuswahl";
            this.lblAuswahl.Size = new System.Drawing.Size(141, 23);
            this.lblAuswahl.TabIndex = 19;
            this.lblAuswahl.Text = "Pflegediagnosen Auswahl :";
            this.lblAuswahl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dsPDxEintrag1
            // 
            this.dsPDxEintrag1.DataSetName = "dsPDxEintrag";
            this.dsPDxEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1012, 621);
            // 
            // ucPdx2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.panel5);
            this.Name = "ucPdx2";
            this.Size = new System.Drawing.Size(993, 672);
            this.Load += new System.EventHandler(this.ucPdx2_Load);
            this.tabPageAlleAbteilungen.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPDX)).EndInit();
            this.tabPDX.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActiveJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintrag1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panel4;
        private ucButton btnSave;
        private ucButton btnUndo;
        private QS2.Desktop.ControlManagment.BasePanel pnlButton;
        private PMDS.GUI.BaseControls.Legend legZ;
        private PMDS.GUI.BaseControls.Legend legS;
        private PMDS.GUI.BaseControls.Legend legM;
        private PMDS.GUI.BaseControls.Legend legA;
        private QS2.Desktop.ControlManagment.BasePanel panel5;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbPDX;
        private QS2.Desktop.ControlManagment.BaseLableWin lblAuswahl;
        private dsPDxEintrag dsPDxEintrag1;
        private ucButton btnDel;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseTabControl tabPDX;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private ucButton btnDelASZM;
        private ucButton btnAddASZM;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl tabPageAlleAbteilungen;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private ucPdxVerwaltung ucPdxVerwAlgemein;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private ucButton btnUpdate;
        public Infragistics.Win.UltraWinEditors.UltraOptionSet optActiveJN;
    }
}
