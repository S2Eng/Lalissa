
namespace PMDS.GUI.STAMP
{
    partial class ucSTAMPData
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
                if (_dt != null) _dt.Dispose();
                if (_db != null) _db.Dispose();
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSTAMPData));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.lblfinanzierung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtGueltigVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblGueltigVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblfinanzierungSonstige = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtFinanzierungSonstige = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGueltigBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtGueltigBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblSTAMP = new QS2.Desktop.ControlManagment.BaseLabel();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgKostentragungen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.pnlGemeinde = new Infragistics.Win.Misc.UltraPanel();
            this.lblGemeinde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbGemeinde = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlBundesland = new Infragistics.Win.Misc.UltraPanel();
            this.lblBundesland = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbBundesland = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlLand = new Infragistics.Win.Misc.UltraPanel();
            this.lblLand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlFinanzierungSonstige = new Infragistics.Win.Misc.UltraPanel();
            this.splitContainerSTAMP = new System.Windows.Forms.SplitContainer();
            this.splitContainerSTAMPOben = new System.Windows.Forms.SplitContainer();
            this.pnlHeader = new Infragistics.Win.Misc.UltraPanel();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.pnlMitte = new Infragistics.Win.Misc.UltraPanel();
            this.pnlUnten = new Infragistics.Win.Misc.UltraPanel();
            this.gbDetails = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.cmbFinanzierung = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinanzierungSonstige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKostentragungen)).BeginInit();
            this.pnlGemeinde.ClientArea.SuspendLayout();
            this.pnlGemeinde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGemeinde)).BeginInit();
            this.pnlBundesland.ClientArea.SuspendLayout();
            this.pnlBundesland.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBundesland)).BeginInit();
            this.pnlLand.ClientArea.SuspendLayout();
            this.pnlLand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLand)).BeginInit();
            this.pnlFinanzierungSonstige.ClientArea.SuspendLayout();
            this.pnlFinanzierungSonstige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSTAMP)).BeginInit();
            this.splitContainerSTAMP.Panel1.SuspendLayout();
            this.splitContainerSTAMP.Panel2.SuspendLayout();
            this.splitContainerSTAMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSTAMPOben)).BeginInit();
            this.splitContainerSTAMPOben.Panel1.SuspendLayout();
            this.splitContainerSTAMPOben.Panel2.SuspendLayout();
            this.splitContainerSTAMPOben.SuspendLayout();
            this.pnlHeader.ClientArea.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMitte.ClientArea.SuspendLayout();
            this.pnlMitte.SuspendLayout();
            this.pnlUnten.ClientArea.SuspendLayout();
            this.pnlUnten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetails)).BeginInit();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinanzierung)).BeginInit();
            this.SuspendLayout();
            // 
            // lblfinanzierung
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblfinanzierung.Appearance = appearance1;
            this.lblfinanzierung.Location = new System.Drawing.Point(6, 19);
            this.lblfinanzierung.Name = "lblfinanzierung";
            this.lblfinanzierung.Size = new System.Drawing.Size(100, 21);
            this.lblfinanzierung.TabIndex = 28;
            this.lblfinanzierung.Text = "Finanzierung";
            // 
            // dtGueltigVon
            // 
            this.dtGueltigVon.DateTime = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            this.dtGueltigVon.Location = new System.Drawing.Point(112, 46);
            this.dtGueltigVon.Name = "dtGueltigVon";
            this.dtGueltigVon.ownFormat = "";
            this.dtGueltigVon.ownMaskInput = "";
            this.dtGueltigVon.Size = new System.Drawing.Size(86, 21);
            this.dtGueltigVon.TabIndex = 30;
            this.dtGueltigVon.Value = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            this.dtGueltigVon.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGueltigVon
            // 
            this.lblGueltigVon.Location = new System.Drawing.Point(6, 46);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(100, 23);
            this.lblGueltigVon.TabIndex = 31;
            this.lblGueltigVon.Text = "Gültig von";
            // 
            // lblfinanzierungSonstige
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblfinanzierungSonstige.Appearance = appearance2;
            this.lblfinanzierungSonstige.Location = new System.Drawing.Point(0, 4);
            this.lblfinanzierungSonstige.Name = "lblfinanzierungSonstige";
            this.lblfinanzierungSonstige.Size = new System.Drawing.Size(84, 15);
            this.lblfinanzierungSonstige.TabIndex = 32;
            this.lblfinanzierungSonstige.Text = "Beschreibung";
            // 
            // txtFinanzierungSonstige
            // 
            this.txtFinanzierungSonstige.Location = new System.Drawing.Point(83, 0);
            this.txtFinanzierungSonstige.MaxLength = 50;
            this.txtFinanzierungSonstige.Name = "txtFinanzierungSonstige";
            this.txtFinanzierungSonstige.Size = new System.Drawing.Size(297, 21);
            this.txtFinanzierungSonstige.TabIndex = 33;
            this.txtFinanzierungSonstige.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Location = new System.Drawing.Point(6, 75);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(100, 23);
            this.lblGueltigBis.TabIndex = 37;
            this.lblGueltigBis.Text = "Gültig bis";
            // 
            // dtGueltigBis
            // 
            this.dtGueltigBis.DateTime = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            this.dtGueltigBis.Location = new System.Drawing.Point(112, 73);
            this.dtGueltigBis.Name = "dtGueltigBis";
            this.dtGueltigBis.NullText = "laufend";
            this.dtGueltigBis.ownFormat = "";
            this.dtGueltigBis.ownMaskInput = "";
            this.dtGueltigBis.Size = new System.Drawing.Size(86, 21);
            this.dtGueltigBis.TabIndex = 36;
            this.dtGueltigBis.Value = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            this.dtGueltigBis.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblSTAMP
            // 
            appearance3.FontData.BoldAsString = "True";
            this.lblSTAMP.Appearance = appearance3;
            this.lblSTAMP.Location = new System.Drawing.Point(3, 13);
            this.lblSTAMP.Name = "lblSTAMP";
            this.lblSTAMP.Size = new System.Drawing.Size(170, 21);
            this.lblSTAMP.TabIndex = 43;
            this.lblSTAMP.Text = "Kostentragungen (STAMP)";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(865, 539);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(264, 25);
            this.bindingNavigator1.TabIndex = 45;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Neu hinzufügen";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 22);
            this.bindingNavigatorCountItem.Text = "von {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente.";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Löschen";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Erste verschieben";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Vorherige verschieben";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuelle Position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Nächste verschieben";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Letzte verschieben";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dgKostentragungen
            // 
            this.dgKostentragungen.AutoWork = true;
            this.dgKostentragungen.DataSource = this.bindingSource;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgKostentragungen.DisplayLayout.Appearance = appearance4;
            this.dgKostentragungen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKostentragungen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKostentragungen.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKostentragungen.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.dgKostentragungen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgKostentragungen.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.dgKostentragungen.DisplayLayout.MaxColScrollRegions = 1;
            this.dgKostentragungen.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgKostentragungen.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgKostentragungen.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.dgKostentragungen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgKostentragungen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.dgKostentragungen.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgKostentragungen.DisplayLayout.Override.CellAppearance = appearance11;
            this.dgKostentragungen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgKostentragungen.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.dgKostentragungen.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.TextHAlignAsString = "Left";
            this.dgKostentragungen.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.dgKostentragungen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgKostentragungen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.dgKostentragungen.DisplayLayout.Override.RowAppearance = appearance14;
            this.dgKostentragungen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgKostentragungen.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgKostentragungen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgKostentragungen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgKostentragungen.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.dgKostentragungen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgKostentragungen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgKostentragungen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgKostentragungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKostentragungen.Location = new System.Drawing.Point(0, 0);
            this.dgKostentragungen.Name = "dgKostentragungen";
            this.dgKostentragungen.Size = new System.Drawing.Size(934, 189);
            this.dgKostentragungen.TabIndex = 46;
            this.dgKostentragungen.Text = "baseGrid1";
            this.dgKostentragungen.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.dgKostentragungen_ClickCell);
            // 
            // pnlGemeinde
            // 
            // 
            // pnlGemeinde.ClientArea
            // 
            this.pnlGemeinde.ClientArea.Controls.Add(this.lblGemeinde);
            this.pnlGemeinde.ClientArea.Controls.Add(this.cmbGemeinde);
            this.pnlGemeinde.Location = new System.Drawing.Point(325, 19);
            this.pnlGemeinde.Name = "pnlGemeinde";
            this.pnlGemeinde.Size = new System.Drawing.Size(430, 23);
            this.pnlGemeinde.TabIndex = 47;
            // 
            // lblGemeinde
            // 
            this.lblGemeinde.Location = new System.Drawing.Point(0, 4);
            this.lblGemeinde.Name = "lblGemeinde";
            this.lblGemeinde.Size = new System.Drawing.Size(72, 13);
            this.lblGemeinde.TabIndex = 34;
            this.lblGemeinde.Text = "Gemeinde";
            // 
            // cmbGemeinde
            // 
            this.cmbGemeinde.AddEmptyEntry = false;
            appearance16.BackColor = System.Drawing.Color.White;
            this.cmbGemeinde.Appearance = appearance16;
            this.cmbGemeinde.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbGemeinde.AutoOpenCBO = false;
            this.cmbGemeinde.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbGemeinde.BackColor = System.Drawing.Color.White;
            this.cmbGemeinde.BerufsstandGruppeJNA = -1;
            this.cmbGemeinde.ExactMatch = false;
            this.cmbGemeinde.Group = "GKZ";
            this.cmbGemeinde.ID_PEP = -1;
            this.cmbGemeinde.IgnoreUnterdruecken = true;
            this.cmbGemeinde.Location = new System.Drawing.Point(83, 1);
            this.cmbGemeinde.MaxLength = 40;
            this.cmbGemeinde.Name = "cmbGemeinde";
            this.cmbGemeinde.PflichtJN = false;
            this.cmbGemeinde.SelectDistinct = false;
            this.cmbGemeinde.ShowAddButton = true;
            this.cmbGemeinde.Size = new System.Drawing.Size(241, 21);
            this.cmbGemeinde.sys = false;
            this.cmbGemeinde.TabIndex = 38;
            this.cmbGemeinde.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // pnlBundesland
            // 
            // 
            // pnlBundesland.ClientArea
            // 
            this.pnlBundesland.ClientArea.Controls.Add(this.lblBundesland);
            this.pnlBundesland.ClientArea.Controls.Add(this.cmbBundesland);
            this.pnlBundesland.Location = new System.Drawing.Point(325, 47);
            this.pnlBundesland.Name = "pnlBundesland";
            this.pnlBundesland.Size = new System.Drawing.Size(430, 23);
            this.pnlBundesland.TabIndex = 48;
            // 
            // lblBundesland
            // 
            this.lblBundesland.Location = new System.Drawing.Point(0, 4);
            this.lblBundesland.Name = "lblBundesland";
            this.lblBundesland.Size = new System.Drawing.Size(77, 13);
            this.lblBundesland.TabIndex = 39;
            this.lblBundesland.Text = "Bundesland";
            // 
            // cmbBundesland
            // 
            this.cmbBundesland.AddEmptyEntry = false;
            appearance17.BackColor = System.Drawing.Color.White;
            this.cmbBundesland.Appearance = appearance17;
            this.cmbBundesland.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbBundesland.AutoOpenCBO = false;
            this.cmbBundesland.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbBundesland.BackColor = System.Drawing.Color.White;
            this.cmbBundesland.BerufsstandGruppeJNA = -1;
            this.cmbBundesland.ExactMatch = false;
            this.cmbBundesland.Group = "BLD";
            this.cmbBundesland.ID_PEP = -1;
            this.cmbBundesland.IgnoreUnterdruecken = true;
            this.cmbBundesland.Location = new System.Drawing.Point(83, 1);
            this.cmbBundesland.MaxLength = 40;
            this.cmbBundesland.Name = "cmbBundesland";
            this.cmbBundesland.PflichtJN = false;
            this.cmbBundesland.SelectDistinct = false;
            this.cmbBundesland.ShowAddButton = true;
            this.cmbBundesland.Size = new System.Drawing.Size(198, 21);
            this.cmbBundesland.sys = false;
            this.cmbBundesland.TabIndex = 40;
            this.cmbBundesland.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // pnlLand
            // 
            // 
            // pnlLand.ClientArea
            // 
            this.pnlLand.ClientArea.Controls.Add(this.lblLand);
            this.pnlLand.ClientArea.Controls.Add(this.cmbLand);
            this.pnlLand.Location = new System.Drawing.Point(325, 75);
            this.pnlLand.Name = "pnlLand";
            this.pnlLand.Size = new System.Drawing.Size(430, 23);
            this.pnlLand.TabIndex = 49;
            // 
            // lblLand
            // 
            this.lblLand.Location = new System.Drawing.Point(0, 4);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(77, 13);
            this.lblLand.TabIndex = 41;
            this.lblLand.Text = "Land";
            // 
            // cmbLand
            // 
            this.cmbLand.AddEmptyEntry = false;
            appearance18.BackColor = System.Drawing.Color.White;
            this.cmbLand.Appearance = appearance18;
            this.cmbLand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbLand.AutoOpenCBO = false;
            this.cmbLand.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbLand.BackColor = System.Drawing.Color.White;
            this.cmbLand.BerufsstandGruppeJNA = -1;
            this.cmbLand.ExactMatch = false;
            this.cmbLand.Group = "LND";
            this.cmbLand.ID_PEP = -1;
            this.cmbLand.IgnoreUnterdruecken = true;
            this.cmbLand.Location = new System.Drawing.Point(83, 0);
            this.cmbLand.MaxLength = 40;
            this.cmbLand.Name = "cmbLand";
            this.cmbLand.PflichtJN = false;
            this.cmbLand.SelectDistinct = false;
            this.cmbLand.ShowAddButton = true;
            this.cmbLand.Size = new System.Drawing.Size(337, 21);
            this.cmbLand.sys = false;
            this.cmbLand.TabIndex = 39;
            this.cmbLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // pnlFinanzierungSonstige
            // 
            // 
            // pnlFinanzierungSonstige.ClientArea
            // 
            this.pnlFinanzierungSonstige.ClientArea.Controls.Add(this.txtFinanzierungSonstige);
            this.pnlFinanzierungSonstige.ClientArea.Controls.Add(this.lblfinanzierungSonstige);
            this.pnlFinanzierungSonstige.Location = new System.Drawing.Point(325, 103);
            this.pnlFinanzierungSonstige.Name = "pnlFinanzierungSonstige";
            this.pnlFinanzierungSonstige.Size = new System.Drawing.Size(430, 22);
            this.pnlFinanzierungSonstige.TabIndex = 50;
            // 
            // splitContainerSTAMP
            // 
            this.splitContainerSTAMP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerSTAMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSTAMP.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSTAMP.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSTAMP.Name = "splitContainerSTAMP";
            this.splitContainerSTAMP.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSTAMP.Panel1
            // 
            this.splitContainerSTAMP.Panel1.Controls.Add(this.splitContainerSTAMPOben);
            // 
            // splitContainerSTAMP.Panel2
            // 
            this.splitContainerSTAMP.Panel2.Controls.Add(this.pnlUnten);
            this.splitContainerSTAMP.Size = new System.Drawing.Size(934, 457);
            this.splitContainerSTAMP.SplitterDistance = 238;
            this.splitContainerSTAMP.TabIndex = 51;
            // 
            // splitContainerSTAMPOben
            // 
            this.splitContainerSTAMPOben.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerSTAMPOben.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSTAMPOben.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSTAMPOben.IsSplitterFixed = true;
            this.splitContainerSTAMPOben.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSTAMPOben.Name = "splitContainerSTAMPOben";
            this.splitContainerSTAMPOben.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSTAMPOben.Panel1
            // 
            this.splitContainerSTAMPOben.Panel1.Controls.Add(this.pnlHeader);
            // 
            // splitContainerSTAMPOben.Panel2
            // 
            this.splitContainerSTAMPOben.Panel2.Controls.Add(this.pnlMitte);
            this.splitContainerSTAMPOben.Size = new System.Drawing.Size(934, 238);
            this.splitContainerSTAMPOben.SplitterDistance = 45;
            this.splitContainerSTAMPOben.TabIndex = 0;
            // 
            // pnlHeader
            // 
            appearance19.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Appearance = appearance19;
            // 
            // pnlHeader.ClientArea
            // 
            this.pnlHeader.ClientArea.Controls.Add(this.lblSTAMP);
            this.pnlHeader.ClientArea.Controls.Add(this.btnDel);
            this.pnlHeader.ClientArea.Controls.Add(this.btnAdd);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(934, 45);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.BackColor = System.Drawing.Color.Transparent;
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance20.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance20;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(731, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 26);
            this.btnDel.TabIndex = 26;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance21.BackColor = System.Drawing.Color.Transparent;
            appearance21.Image = ((object)(resources.GetObject("appearance21.Image")));
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance21.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance21;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(833, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 26);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlMitte
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.pnlMitte.Appearance = appearance22;
            // 
            // pnlMitte.ClientArea
            // 
            this.pnlMitte.ClientArea.Controls.Add(this.dgKostentragungen);
            this.pnlMitte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMitte.Location = new System.Drawing.Point(0, 0);
            this.pnlMitte.Name = "pnlMitte";
            this.pnlMitte.Size = new System.Drawing.Size(934, 189);
            this.pnlMitte.TabIndex = 47;
            // 
            // pnlUnten
            // 
            appearance23.BackColor = System.Drawing.Color.White;
            this.pnlUnten.Appearance = appearance23;
            // 
            // pnlUnten.ClientArea
            // 
            this.pnlUnten.ClientArea.Controls.Add(this.gbDetails);
            this.pnlUnten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnten.Location = new System.Drawing.Point(0, 0);
            this.pnlUnten.Name = "pnlUnten";
            this.pnlUnten.Size = new System.Drawing.Size(934, 215);
            this.pnlUnten.TabIndex = 0;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblfinanzierung);
            this.gbDetails.Controls.Add(this.cmbFinanzierung);
            this.gbDetails.Controls.Add(this.pnlFinanzierungSonstige);
            this.gbDetails.Controls.Add(this.pnlLand);
            this.gbDetails.Controls.Add(this.lblGueltigBis);
            this.gbDetails.Controls.Add(this.dtGueltigBis);
            this.gbDetails.Controls.Add(this.dtGueltigVon);
            this.gbDetails.Controls.Add(this.pnlGemeinde);
            this.gbDetails.Controls.Add(this.pnlBundesland);
            this.gbDetails.Controls.Add(this.lblGueltigVon);
            this.gbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetails.Location = new System.Drawing.Point(0, 0);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(934, 215);
            this.gbDetails.TabIndex = 51;
            this.gbDetails.Text = "Details zur Kostentragung";
            // 
            // cmbFinanzierung
            // 
            this.cmbFinanzierung.AddEmptyEntry = false;
            appearance24.BackColor = System.Drawing.Color.White;
            this.cmbFinanzierung.Appearance = appearance24;
            this.cmbFinanzierung.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbFinanzierung.AutoOpenCBO = false;
            this.cmbFinanzierung.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbFinanzierung.BackColor = System.Drawing.Color.White;
            this.cmbFinanzierung.BerufsstandGruppeJNA = -1;
            this.cmbFinanzierung.ExactMatch = false;
            this.cmbFinanzierung.Group = "SFI";
            this.cmbFinanzierung.ID_PEP = -1;
            this.cmbFinanzierung.IgnoreUnterdruecken = true;
            this.cmbFinanzierung.Location = new System.Drawing.Point(112, 19);
            this.cmbFinanzierung.MaxLength = 40;
            this.cmbFinanzierung.Name = "cmbFinanzierung";
            this.cmbFinanzierung.PflichtJN = false;
            this.cmbFinanzierung.SelectDistinct = false;
            this.cmbFinanzierung.ShowAddButton = true;
            this.cmbFinanzierung.Size = new System.Drawing.Size(207, 21);
            this.cmbFinanzierung.sys = false;
            this.cmbFinanzierung.TabIndex = 44;
            this.cmbFinanzierung.ValueChanged += new System.EventHandler(this.cmbFinanzierung_ValueChanged);
            // 
            // ucSTAMPData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainerSTAMP);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "ucSTAMPData";
            this.Size = new System.Drawing.Size(934, 457);
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinanzierungSonstige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKostentragungen)).EndInit();
            this.pnlGemeinde.ClientArea.ResumeLayout(false);
            this.pnlGemeinde.ClientArea.PerformLayout();
            this.pnlGemeinde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbGemeinde)).EndInit();
            this.pnlBundesland.ClientArea.ResumeLayout(false);
            this.pnlBundesland.ClientArea.PerformLayout();
            this.pnlBundesland.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBundesland)).EndInit();
            this.pnlLand.ClientArea.ResumeLayout(false);
            this.pnlLand.ClientArea.PerformLayout();
            this.pnlLand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLand)).EndInit();
            this.pnlFinanzierungSonstige.ClientArea.ResumeLayout(false);
            this.pnlFinanzierungSonstige.ClientArea.PerformLayout();
            this.pnlFinanzierungSonstige.ResumeLayout(false);
            this.splitContainerSTAMP.Panel1.ResumeLayout(false);
            this.splitContainerSTAMP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSTAMP)).EndInit();
            this.splitContainerSTAMP.ResumeLayout(false);
            this.splitContainerSTAMPOben.Panel1.ResumeLayout(false);
            this.splitContainerSTAMPOben.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSTAMPOben)).EndInit();
            this.splitContainerSTAMPOben.ResumeLayout(false);
            this.pnlHeader.ClientArea.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMitte.ClientArea.ResumeLayout(false);
            this.pnlMitte.ResumeLayout(false);
            this.pnlUnten.ClientArea.ResumeLayout(false);
            this.pnlUnten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbDetails)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinanzierung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucButton btnDel;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseLabel lblfinanzierung;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtGueltigVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblGueltigVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblfinanzierungSonstige;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtFinanzierungSonstige;
        private QS2.Desktop.ControlManagment.BaseLabel lblGueltigBis;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtGueltigBis;
        public BaseControls.AuswahlGruppeCombo cmbGemeinde;
        public BaseControls.AuswahlGruppeCombo cmbLand;
        public BaseControls.AuswahlGruppeCombo cmbBundesland;
        private QS2.Desktop.ControlManagment.BaseLabel lblSTAMP;
        public BaseControls.AuswahlGruppeCombo cmbFinanzierung;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private QS2.Desktop.ControlManagment.BaseGrid dgKostentragungen;
        private Infragistics.Win.Misc.UltraPanel pnlGemeinde;
        private QS2.Desktop.ControlManagment.BaseLabel lblGemeinde;
        private Infragistics.Win.Misc.UltraPanel pnlBundesland;
        private Infragistics.Win.Misc.UltraPanel pnlLand;
        private Infragistics.Win.Misc.UltraPanel pnlFinanzierungSonstige;
        private QS2.Desktop.ControlManagment.BaseLabel lblBundesland;
        private QS2.Desktop.ControlManagment.BaseLabel lblLand;
        private System.Windows.Forms.SplitContainer splitContainerSTAMP;
        private System.Windows.Forms.SplitContainer splitContainerSTAMPOben;
        private Infragistics.Win.Misc.UltraPanel pnlHeader;
        private Infragistics.Win.Misc.UltraPanel pnlMitte;
        private Infragistics.Win.Misc.UltraPanel pnlUnten;
        private QS2.Desktop.ControlManagment.BaseGroupBox gbDetails;
    }
}
