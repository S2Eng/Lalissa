namespace PMDS.GUI.Messenger
{
    partial class contMessenger
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tMessages", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDProtocoll");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Created", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Absender", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Title", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MessageTxt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Readed");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserFrom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserIDFrom");
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
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            this.textControlMessage = new TXTextControl.TextControl();
            this.txtTitle = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTitle = new Infragistics.Win.Misc.UltraLabel();
            this.dropDownPatienten = new Infragistics.Win.Misc.UltraDropDownButton();
            this.uPopUpContPatienten = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSend = new Infragistics.Win.Misc.UltraButton();
            this.optReaded = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.btnAnswerAll = new Infragistics.Win.Misc.UltraButton();
            this.btnAnswerSender = new Infragistics.Win.Misc.UltraButton();
            this.panelButtonsTop = new System.Windows.Forms.Panel();
            this.btnNewMessage = new Infragistics.Win.Misc.UltraButton();
            this.udteTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udteFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblTo = new Infragistics.Win.Misc.UltraLabel();
            this.lblFrom = new Infragistics.Win.Misc.UltraLabel();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.lblSender = new Infragistics.Win.Misc.UltraLabel();
            this.panelButtonsBottom = new System.Windows.Forms.Panel();
            this.panelButtonsBottomRight = new System.Windows.Forms.Panel();
            this.btnAbortSend = new Infragistics.Win.Misc.UltraButton();
            this.lblInfoMessageBottom = new Infragistics.Win.Misc.UltraLabel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelGridBottom = new System.Windows.Forms.Panel();
            this.gridMessages = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.panelSearchTop = new System.Windows.Forms.Panel();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.textControl1 = new TXTextControl.TextControl();
            this.lblNewMessages = new Infragistics.Win.Misc.UltraLabel();
            this.btnPrint = new QS2.Desktop.ControlManagment.BaseButton();
            this.optPostEinAusgang = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.btnDelete = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnRefresh = new QS2.Desktop.ControlManagment.BaseButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optReaded)).BeginInit();
            this.panelButtonsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).BeginInit();
            this.panelMessage.SuspendLayout();
            this.panelButtonsBottom.SuspendLayout();
            this.panelButtonsBottomRight.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.panelGridBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.panelSearchTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optPostEinAusgang)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControlMessage
            // 
            this.textControlMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControlMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textControlMessage.BorderStyle = TXTextControl.BorderStyle.FixedSingle;
            this.textControlMessage.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlMessage.ForeColor = System.Drawing.Color.Black;
            this.textControlMessage.Location = new System.Drawing.Point(41, 49);
            this.textControlMessage.Name = "textControlMessage";
            this.textControlMessage.Size = new System.Drawing.Size(953, 211);
            this.textControlMessage.TabIndex = 1;
            this.textControlMessage.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textControlMessage.UserNames = null;
            this.textControlMessage.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTitle.Appearance = appearance1;
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(41, 25);
            this.txtTitle.MaxLength = 120;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(756, 21);
            this.txtTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.lblTitle.Appearance = appearance2;
            this.lblTitle.Location = new System.Drawing.Point(7, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Titel";
            // 
            // dropDownPatienten
            // 
            this.dropDownPatienten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BorderColor = System.Drawing.Color.Black;
            this.dropDownPatienten.Appearance = appearance3;
            this.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownPatienten.Location = new System.Drawing.Point(803, 24);
            this.dropDownPatienten.Name = "dropDownPatienten";
            this.dropDownPatienten.Size = new System.Drawing.Size(189, 23);
            this.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownPatienten.TabIndex = 5;
            this.dropDownPatienten.Tag = "";
            this.dropDownPatienten.Text = "Empfänger";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(89, 1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 26);
            this.btnSend.TabIndex = 21;
            this.btnSend.Tag = "";
            this.btnSend.Text = "Senden";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // optReaded
            // 
            this.optReaded.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optReaded.CheckedIndex = 0;
            valueListItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem5.DataValue = "U";
            valueListItem5.DisplayText = "Ungelesen";
            valueListItem6.DataValue = "G";
            valueListItem6.DisplayText = "Gelesen";
            valueListItem7.DataValue = "A";
            valueListItem7.DisplayText = "Alle";
            this.optReaded.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.optReaded.Location = new System.Drawing.Point(9, 74);
            this.optReaded.Name = "optReaded";
            this.optReaded.Size = new System.Drawing.Size(235, 21);
            this.optReaded.TabIndex = 1;
            this.optReaded.Text = "Ungelesen";
            this.optReaded.ValueChanged += new System.EventHandler(this.optReaded_ValueChanged);
            // 
            // btnAnswerAll
            // 
            this.btnAnswerAll.Location = new System.Drawing.Point(220, 0);
            this.btnAnswerAll.Name = "btnAnswerAll";
            this.btnAnswerAll.Size = new System.Drawing.Size(129, 26);
            this.btnAnswerAll.TabIndex = 2;
            this.btnAnswerAll.Tag = "";
            this.btnAnswerAll.Text = "Allen antworten";
            this.btnAnswerAll.Click += new System.EventHandler(this.btnAnswerAll_Click);
            // 
            // btnAnswerSender
            // 
            this.btnAnswerSender.Location = new System.Drawing.Point(82, 0);
            this.btnAnswerSender.Name = "btnAnswerSender";
            this.btnAnswerSender.Size = new System.Drawing.Size(132, 26);
            this.btnAnswerSender.TabIndex = 1;
            this.btnAnswerSender.Tag = "";
            this.btnAnswerSender.Text = "Absender antworten";
            this.btnAnswerSender.Click += new System.EventHandler(this.btnAnswerSender_Click);
            // 
            // panelButtonsTop
            // 
            this.panelButtonsTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtonsTop.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsTop.Controls.Add(this.btnNewMessage);
            this.panelButtonsTop.Controls.Add(this.btnAnswerSender);
            this.panelButtonsTop.Controls.Add(this.btnAnswerAll);
            this.panelButtonsTop.Location = new System.Drawing.Point(525, 70);
            this.panelButtonsTop.Name = "panelButtonsTop";
            this.panelButtonsTop.Size = new System.Drawing.Size(392, 27);
            this.panelButtonsTop.TabIndex = 108;
            // 
            // btnNewMessage
            // 
            this.btnNewMessage.Location = new System.Drawing.Point(13, 0);
            this.btnNewMessage.Name = "btnNewMessage";
            this.btnNewMessage.Size = new System.Drawing.Size(59, 26);
            this.btnNewMessage.TabIndex = 0;
            this.btnNewMessage.Tag = "";
            this.btnNewMessage.Text = "Neu";
            this.btnNewMessage.Click += new System.EventHandler(this.btnNewMessage_Click);
            // 
            // udteTo
            // 
            this.udteTo.DateTime = new System.DateTime(2018, 12, 10, 0, 0, 0, 0);
            this.udteTo.Location = new System.Drawing.Point(418, 72);
            this.udteTo.Name = "udteTo";
            this.udteTo.Size = new System.Drawing.Size(85, 21);
            this.udteTo.TabIndex = 3;
            this.udteTo.Value = new System.DateTime(2018, 12, 10, 0, 0, 0, 0);
            this.udteTo.Leave += new System.EventHandler(this.udteTo_Leave);
            // 
            // udteFrom
            // 
            this.udteFrom.DateTime = new System.DateTime(2018, 12, 10, 0, 0, 0, 0);
            this.udteFrom.Location = new System.Drawing.Point(291, 72);
            this.udteFrom.Name = "udteFrom";
            this.udteFrom.Size = new System.Drawing.Size(85, 21);
            this.udteFrom.TabIndex = 2;
            this.udteFrom.Value = new System.DateTime(2018, 12, 10, 0, 0, 0, 0);
            this.udteFrom.Leave += new System.EventHandler(this.udteFrom_Leave);
            // 
            // lblTo
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.lblTo.Appearance = appearance25;
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(385, 76);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 14);
            this.lblTo.TabIndex = 112;
            this.lblTo.Text = "bis";
            // 
            // lblFrom
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.lblFrom.Appearance = appearance24;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(250, 76);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(24, 14);
            this.lblFrom.TabIndex = 111;
            this.lblFrom.Text = "Von";
            // 
            // panelMessage
            // 
            this.panelMessage.BackColor = System.Drawing.Color.Transparent;
            this.panelMessage.Controls.Add(this.lblSender);
            this.panelMessage.Controls.Add(this.txtTitle);
            this.panelMessage.Controls.Add(this.lblTitle);
            this.panelMessage.Controls.Add(this.textControlMessage);
            this.panelMessage.Controls.Add(this.dropDownPatienten);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessage.Location = new System.Drawing.Point(0, 0);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(1000, 263);
            this.panelMessage.TabIndex = 110;
            // 
            // lblSender
            // 
            this.lblSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.TextVAlignAsString = "Middle";
            this.lblSender.Appearance = appearance4;
            this.lblSender.Location = new System.Drawing.Point(7, 4);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(855, 17);
            this.lblSender.TabIndex = 12;
            this.lblSender.Text = "Von:";
            // 
            // panelButtonsBottom
            // 
            this.panelButtonsBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsBottom.Controls.Add(this.panelButtonsBottomRight);
            this.panelButtonsBottom.Controls.Add(this.lblInfoMessageBottom);
            this.panelButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsBottom.Location = new System.Drawing.Point(0, 263);
            this.panelButtonsBottom.Name = "panelButtonsBottom";
            this.panelButtonsBottom.Size = new System.Drawing.Size(1000, 30);
            this.panelButtonsBottom.TabIndex = 111;
            // 
            // panelButtonsBottomRight
            // 
            this.panelButtonsBottomRight.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsBottomRight.Controls.Add(this.btnAbortSend);
            this.panelButtonsBottomRight.Controls.Add(this.btnSend);
            this.panelButtonsBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsBottomRight.Location = new System.Drawing.Point(828, 0);
            this.panelButtonsBottomRight.Name = "panelButtonsBottomRight";
            this.panelButtonsBottomRight.Size = new System.Drawing.Size(172, 30);
            this.panelButtonsBottomRight.TabIndex = 23;
            // 
            // btnAbortSend
            // 
            this.btnAbortSend.Location = new System.Drawing.Point(12, 1);
            this.btnAbortSend.Name = "btnAbortSend";
            this.btnAbortSend.Size = new System.Drawing.Size(77, 26);
            this.btnAbortSend.TabIndex = 20;
            this.btnAbortSend.Tag = "";
            this.btnAbortSend.Text = "Abbrechen";
            this.btnAbortSend.Click += new System.EventHandler(this.btnAbortSend_Click);
            // 
            // lblInfoMessageBottom
            // 
            this.lblInfoMessageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.TextVAlignAsString = "Middle";
            this.lblInfoMessageBottom.Appearance = appearance5;
            this.lblInfoMessageBottom.Location = new System.Drawing.Point(35, 6);
            this.lblInfoMessageBottom.Name = "lblInfoMessageBottom";
            this.lblInfoMessageBottom.Size = new System.Drawing.Size(790, 17);
            this.lblInfoMessageBottom.TabIndex = 22;
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.Transparent;
            this.panelGrid.Controls.Add(this.panelGridBottom);
            this.panelGrid.Controls.Add(this.panelSearchTop);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1000, 407);
            this.panelGrid.TabIndex = 112;
            // 
            // panelGridBottom
            // 
            this.panelGridBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelGridBottom.Controls.Add(this.gridMessages);
            this.panelGridBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridBottom.Location = new System.Drawing.Point(0, 101);
            this.panelGridBottom.Name = "panelGridBottom";
            this.panelGridBottom.Size = new System.Drawing.Size(1000, 306);
            this.panelGridBottom.TabIndex = 111;
            // 
            // gridMessages
            // 
            this.gridMessages.DataMember = "tMessages";
            this.gridMessages.DataSource = this.dsKlientenliste1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridMessages.DisplayLayout.Appearance = appearance6;
            this.gridMessages.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            appearance7.TextHAlignAsString = "Center";
            ultraGridColumn2.CellAppearance = appearance7;
            appearance8.TextHAlignAsString = "Center";
            ultraGridColumn2.Header.Appearance = appearance8;
            ultraGridColumn2.Header.Caption = "Erstellt am";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn2.Width = 119;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Width = 156;
            ultraGridColumn4.Header.Caption = "Betreff";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 271;
            ultraGridColumn5.AutoSizeEdit = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn5.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            ultraGridColumn5.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FullEditorDisplay;
            ultraGridColumn5.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn5.Header.Caption = "Nachricht";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedText;
            ultraGridColumn5.Width = 213;
            ultraGridColumn6.Header.Caption = "Gelesen";
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn6.Width = 58;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand1.Override.DefaultRowHeight = 60;
            ultraGridBand1.Override.RowSizingAutoMaxLines = 10;
            this.gridMessages.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridMessages.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridMessages.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridMessages.DisplayLayout.GroupByBox.Appearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridMessages.DisplayLayout.GroupByBox.BandLabelAppearance = appearance10;
            this.gridMessages.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance11.BackColor2 = System.Drawing.SystemColors.Control;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridMessages.DisplayLayout.GroupByBox.PromptAppearance = appearance11;
            this.gridMessages.DisplayLayout.MaxColScrollRegions = 1;
            this.gridMessages.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridMessages.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance13.BackColor = System.Drawing.SystemColors.Highlight;
            appearance13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridMessages.DisplayLayout.Override.ActiveRowAppearance = appearance13;
            this.gridMessages.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridMessages.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            this.gridMessages.DisplayLayout.Override.CardAreaAppearance = appearance14;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridMessages.DisplayLayout.Override.CellAppearance = appearance15;
            this.gridMessages.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridMessages.DisplayLayout.Override.CellPadding = 0;
            appearance16.BackColor = System.Drawing.SystemColors.Control;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.gridMessages.DisplayLayout.Override.GroupByRowAppearance = appearance16;
            appearance17.TextHAlignAsString = "Left";
            this.gridMessages.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.gridMessages.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridMessages.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            this.gridMessages.DisplayLayout.Override.RowAppearance = appearance18;
            this.gridMessages.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridMessages.DisplayLayout.Override.TemplateAddRowAppearance = appearance19;
            this.gridMessages.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridMessages.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMessages.Location = new System.Drawing.Point(0, 0);
            this.gridMessages.Name = "gridMessages";
            this.gridMessages.Size = new System.Drawing.Size(1000, 306);
            this.gridMessages.TabIndex = 0;
            this.gridMessages.Text = "ultraGrid1";
            this.gridMessages.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridMessages_InitializeLayout);
            this.gridMessages.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridMessages_BeforeCellActivate);
            this.gridMessages.Click += new System.EventHandler(this.gridMessages_Click);
            this.gridMessages.DoubleClick += new System.EventHandler(this.gridMessages_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelSearchTop
            // 
            this.panelSearchTop.BackColor = System.Drawing.Color.Transparent;
            this.panelSearchTop.Controls.Add(this.panelEditor);
            this.panelSearchTop.Controls.Add(this.textControl1);
            this.panelSearchTop.Controls.Add(this.lblNewMessages);
            this.panelSearchTop.Controls.Add(this.btnPrint);
            this.panelSearchTop.Controls.Add(this.optPostEinAusgang);
            this.panelSearchTop.Controls.Add(this.panelButtonsTop);
            this.panelSearchTop.Controls.Add(this.btnDelete);
            this.panelSearchTop.Controls.Add(this.udteTo);
            this.panelSearchTop.Controls.Add(this.optReaded);
            this.panelSearchTop.Controls.Add(this.btnRefresh);
            this.panelSearchTop.Controls.Add(this.udteFrom);
            this.panelSearchTop.Controls.Add(this.lblFrom);
            this.panelSearchTop.Controls.Add(this.lblTo);
            this.panelSearchTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchTop.Location = new System.Drawing.Point(0, 0);
            this.panelSearchTop.Name = "panelSearchTop";
            this.panelSearchTop.Size = new System.Drawing.Size(1000, 101);
            this.panelSearchTop.TabIndex = 0;
            // 
            // panelEditor
            // 
            this.panelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEditor.Location = new System.Drawing.Point(929, 0);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(77, 45);
            this.panelEditor.TabIndex = 117;
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(929, 1);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(70, 40);
            this.textControl1.TabIndex = 116;
            this.textControl1.UserNames = null;
            this.textControl1.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // lblNewMessages
            // 
            appearance20.FontData.BoldAsString = "True";
            appearance20.FontData.SizeInPoints = 10F;
            appearance20.ForeColor = System.Drawing.Color.DarkGreen;
            appearance20.TextVAlignAsString = "Middle";
            this.lblNewMessages.Appearance = appearance20;
            this.lblNewMessages.Location = new System.Drawing.Point(255, 7);
            this.lblNewMessages.Name = "lblNewMessages";
            this.lblNewMessages.Size = new System.Drawing.Size(538, 18);
            this.lblNewMessages.TabIndex = 115;
            this.lblNewMessages.Text = "Neue Nachrichten erhalten. Zum Anzeigen auf Nachrichten aktualisieren klicken!";
            this.lblNewMessages.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance21.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance21;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.IsStandardControl = false;
            this.btnPrint.Location = new System.Drawing.Point(964, 70);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(28, 26);
            this.btnPrint.TabIndex = 101;
            this.btnPrint.Tag = "";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // optPostEinAusgang
            // 
            appearance22.FontData.SizeInPoints = 11F;
            this.optPostEinAusgang.Appearance = appearance22;
            this.optPostEinAusgang.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optPostEinAusgang.CheckedIndex = 0;
            valueListItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem3.DataValue = "E";
            valueListItem3.DisplayText = "Posteingang";
            valueListItem2.DataValue = "A";
            valueListItem2.DisplayText = "Postausgang";
            this.optPostEinAusgang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem2});
            this.optPostEinAusgang.Location = new System.Drawing.Point(9, 36);
            this.optPostEinAusgang.Name = "optPostEinAusgang";
            this.optPostEinAusgang.Size = new System.Drawing.Size(235, 24);
            this.optPostEinAusgang.TabIndex = 0;
            this.optPostEinAusgang.Text = "Posteingang";
            this.optPostEinAusgang.ValueChanged += new System.EventHandler(this.optPostEinAusgang_ValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance23;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.IsStandardControl = false;
            this.btnDelete.Location = new System.Drawing.Point(917, 71);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 26);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Tag = "";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoWorkLayout = false;
            this.btnRefresh.IsStandardControl = false;
            this.btnRefresh.Location = new System.Drawing.Point(7, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(203, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Tag = "";
            this.btnRefresh.Text = "Nachrichten aktualisieren";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelMessage);
            this.panel1.Controls.Add(this.panelButtonsBottom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 293);
            this.panel1.TabIndex = 113;
            // 
            // contMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelGrid);
            this.Name = "contMessenger";
            this.Size = new System.Drawing.Size(1000, 700);
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optReaded)).EndInit();
            this.panelButtonsTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).EndInit();
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.panelButtonsBottom.ResumeLayout(false);
            this.panelButtonsBottomRight.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelGridBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.panelSearchTop.ResumeLayout(false);
            this.panelSearchTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optPostEinAusgang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TXTextControl.TextControl textControlMessage;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTitle;
        private Infragistics.Win.Misc.UltraLabel lblTitle;
        internal Infragistics.Win.Misc.UltraDropDownButton dropDownPatienten;
        private Infragistics.Win.Misc.UltraPopupControlContainer uPopUpContPatienten;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal Infragistics.Win.Misc.UltraButton btnSend;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optReaded;
        public QS2.Desktop.ControlManagment.BaseButton btnRefresh;
        internal Infragistics.Win.Misc.UltraButton btnAnswerSender;
        internal Infragistics.Win.Misc.UltraButton btnAnswerAll;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Panel panelButtonsBottom;
        private System.Windows.Forms.Panel panelButtonsTop;
        internal Infragistics.Win.Misc.UltraButton btnAbortSend;
        internal Infragistics.Win.Misc.UltraButton btnNewMessage;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFrom;
        private Infragistics.Win.Misc.UltraLabel lblTo;
        private Infragistics.Win.Misc.UltraLabel lblFrom;
        private Infragistics.Win.Misc.UltraLabel lblSender;
        public QS2.Desktop.ControlManagment.BaseButton btnDelete;
        private Infragistics.Win.Misc.UltraLabel lblInfoMessageBottom;
        private System.Windows.Forms.Panel panelButtonsBottomRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelSearchTop;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridMessages;
        private System.Windows.Forms.Panel panelGridBottom;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optPostEinAusgang;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        public QS2.Desktop.ControlManagment.BaseButton btnPrint;
        public Infragistics.Win.Misc.UltraLabel lblNewMessages;
        private System.Windows.Forms.Panel panelEditor;
        private TXTextControl.TextControl textControl1;
    }
}
