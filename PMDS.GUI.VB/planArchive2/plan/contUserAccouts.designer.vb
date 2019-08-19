<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contUserAccouts
    Inherits System.Windows.Forms.UserControl

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eintrag hinzufügen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählten Eintrag löschen", Infragistics.Win.ToolTipImage.[Default], "Löschen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblUserAccounts", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usr", -1, 172816239, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typ")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Name")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AdrFrom")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AdrTo")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Server")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UsrAuthentication")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PwdAuthentication")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Port")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SSL")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAccount", -1, 339300303)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lastReceive")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PostOfficeBoxForAll")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PreferPostOfficeBoxForAll")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OutlookWebAPI")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(172816239)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(339300303)
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Me.txtPwd = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PanelOben = New System.Windows.Forms.Panel()
        Me.cboTyp = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblTyp = New Infragistics.Win.Misc.UltraLabel()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.PanelButtEditUserAccounts = New System.Windows.Forms.Panel()
        Me.btnApport = New Infragistics.Win.Misc.UltraButton()
        Me.dropDownEdit = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.gridUserAccounts = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsUserAccounts1 = New dsUserAccounts()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupervisorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.CompUserAccounts1 = New compUserAccounts(Me.components)
        CType(Me.txtPwd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelOben.SuspendLayout()
        CType(Me.cboTyp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnten.SuspendLayout()
        Me.PanelButtEditUserAccounts.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        CType(Me.gridUserAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUserAccounts1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPwd
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackColorDisabled = System.Drawing.Color.White
        Appearance1.BackColorDisabled2 = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.ItalicAsString = "False"
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.FontData.StrikeoutAsString = "False"
        Appearance1.FontData.UnderlineAsString = "False"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtPwd.Appearance = Appearance1
        Me.txtPwd.AutoSize = False
        Me.txtPwd.BackColor = System.Drawing.Color.White
        Me.txtPwd.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.txtPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPwd.Location = New System.Drawing.Point(358, 3)
        Me.txtPwd.MaxLength = 200
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(167, 23)
        Me.txtPwd.TabIndex = 124
        Me.txtPwd.Tag = ""
        Me.txtPwd.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.txtPwd.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.txtPwd.Visible = False
        '
        'PanelOben
        '
        Me.PanelOben.Controls.Add(Me.txtPwd)
        Me.PanelOben.Controls.Add(Me.cboTyp)
        Me.PanelOben.Controls.Add(Me.lblTyp)
        Me.PanelOben.Controls.Add(Me.btnAdd)
        Me.PanelOben.Controls.Add(Me.btnDel)
        Me.PanelOben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelOben.Location = New System.Drawing.Point(0, 0)
        Me.PanelOben.Name = "PanelOben"
        Me.PanelOben.Size = New System.Drawing.Size(883, 28)
        Me.PanelOben.TabIndex = 0
        '
        'cboTyp
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColorDisabled = System.Drawing.Color.White
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboTyp.Appearance = Appearance2
        Me.cboTyp.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboTyp.AutoSize = False
        Me.cboTyp.BackColor = System.Drawing.Color.White
        Me.cboTyp.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboTyp.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboTyp.ItemAppearance = Appearance3
        Me.cboTyp.Location = New System.Drawing.Point(64, 4)
        Me.cboTyp.Name = "cboTyp"
        Me.cboTyp.Size = New System.Drawing.Size(97, 21)
        Me.cboTyp.TabIndex = 122
        Me.cboTyp.Tag = "AutoFill"
        Me.cboTyp.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.cboTyp.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTyp
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblTyp.Appearance = Appearance4
        Me.lblTyp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTyp.Location = New System.Drawing.Point(10, 7)
        Me.lblTyp.Name = "lblTyp"
        Me.lblTyp.Size = New System.Drawing.Size(50, 15)
        Me.lblTyp.TabIndex = 123
        Me.lblTyp.Tag = "ResID.Type"
        Me.lblTyp.Text = "Typ"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAdd.Appearance = Appearance5
        Me.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdd.Location = New System.Drawing.Point(826, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(23, 22)
        Me.btnAdd.TabIndex = 121
        UltraToolTipInfo1.ToolTipText = "Eintrag hinzufügen"
        UltraToolTipInfo1.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd, UltraToolTipInfo1)
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance20.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDel.Appearance = Appearance20
        Me.btnDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDel.Location = New System.Drawing.Point(849, 5)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(23, 22)
        Me.btnDel.TabIndex = 120
        UltraToolTipInfo2.ToolTipText = "Ausgewählten Eintrag löschen"
        UltraToolTipInfo2.ToolTipTitle = "Löschen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDel, UltraToolTipInfo2)
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.lblCount)
        Me.PanelUnten.Controls.Add(Me.PanelButtEditUserAccounts)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 341)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(883, 39)
        Me.PanelUnten.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCount.Location = New System.Drawing.Point(9, 4)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(72, 13)
        Me.lblCount.TabIndex = 224
        Me.lblCount.Text = "Gefunden: 12"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelButtEditUserAccounts
        '
        Me.PanelButtEditUserAccounts.Controls.Add(Me.btnApport)
        Me.PanelButtEditUserAccounts.Controls.Add(Me.dropDownEdit)
        Me.PanelButtEditUserAccounts.Controls.Add(Me.btnSave)
        Me.PanelButtEditUserAccounts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelButtEditUserAccounts.Location = New System.Drawing.Point(635, 0)
        Me.PanelButtEditUserAccounts.Name = "PanelButtEditUserAccounts"
        Me.PanelButtEditUserAccounts.Size = New System.Drawing.Size(248, 39)
        Me.PanelButtEditUserAccounts.TabIndex = 13
        '
        'btnApport
        '
        Appearance18.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnApport.Appearance = Appearance18
        Me.btnApport.Enabled = False
        Me.btnApport.Location = New System.Drawing.Point(81, 4)
        Me.btnApport.Name = "btnApport"
        Me.btnApport.Size = New System.Drawing.Size(71, 29)
        Me.btnApport.TabIndex = 11
        Me.btnApport.Tag = "ResID.Abort"
        Me.btnApport.Text = "Abbrechen"
        '
        'dropDownEdit
        '
        Me.dropDownEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dropDownEdit.Location = New System.Drawing.Point(8, 4)
        Me.dropDownEdit.Name = "dropDownEdit"
        Me.dropDownEdit.Size = New System.Drawing.Size(72, 29)
        Me.dropDownEdit.TabIndex = 10
        Me.dropDownEdit.Tag = "ResID.Edit"
        Me.dropDownEdit.Text = "Editieren"
        '
        'btnSave
        '
        Appearance19.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.btnSave.Appearance = Appearance19
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(153, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 29)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'PanelGrid
        '
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 28)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(883, 313)
        Me.PanelGrid.TabIndex = 2
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.gridUserAccounts)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(883, 313)
        Me.UltraGridBagLayoutPanel1.TabIndex = 0
        '
        'gridUserAccounts
        '
        Me.gridUserAccounts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridUserAccounts.DataMember = "tblUserAccounts"
        Me.gridUserAccounts.DataSource = Me.DsUserAccounts1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridUserAccounts.DisplayLayout.Appearance = Appearance6
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.Caption = "Benutzer"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn2.Width = 135
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.Caption = "Name Postfach"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 203
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.Caption = "E-Mail Adresse Absender"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 227
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.Caption = "E-Mail Adresse Empfänger"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 231
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 173
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.Caption = "Benutzer-Authentifizierung"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Width = 165
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.EditorComponent = Me.txtPwd
        UltraGridColumn9.Header.Caption = "Pwd.-Authentifizierung"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Width = 66
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.Caption = "Smtp-Postfächer"
        UltraGridColumn12.Header.VisiblePosition = 4
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn12.Width = 199
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.Caption = "Letzter Empfang"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn13.Width = 134
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16})
        Me.gridUserAccounts.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridUserAccounts.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridUserAccounts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.gridUserAccounts.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridUserAccounts.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.gridUserAccounts.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridUserAccounts.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridUserAccounts.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.gridUserAccounts.DisplayLayout.MaxColScrollRegions = 1
        Me.gridUserAccounts.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridUserAccounts.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.SystemColors.Highlight
        Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridUserAccounts.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.gridUserAccounts.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridUserAccounts.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.gridUserAccounts.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridUserAccounts.DisplayLayout.Override.CellAppearance = Appearance13
        Me.gridUserAccounts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridUserAccounts.DisplayLayout.Override.CellPadding = 0
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.gridUserAccounts.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.TextHAlignAsString = "Left"
        Me.gridUserAccounts.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.gridUserAccounts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridUserAccounts.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.gridUserAccounts.DisplayLayout.Override.RowAppearance = Appearance16
        Me.gridUserAccounts.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        Me.gridUserAccounts.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridUserAccounts.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.gridUserAccounts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridUserAccounts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Users"
        ValueList2.Key = "SMTPAccounts"
        Me.gridUserAccounts.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2})
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.gridUserAccounts, GridBagConstraint1)
        Me.gridUserAccounts.Location = New System.Drawing.Point(5, 0)
        Me.gridUserAccounts.Name = "gridUserAccounts"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.gridUserAccounts, New System.Drawing.Size(550, 80))
        Me.gridUserAccounts.Size = New System.Drawing.Size(873, 313)
        Me.gridUserAccounts.TabIndex = 0
        Me.gridUserAccounts.Text = "Kalkulationsdaten"
        '
        'DsUserAccounts1
        '
        Me.DsUserAccounts1.DataSetName = "dsUserAccounts"
        Me.DsUserAccounts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleAuswählenToolStripMenuItem, Me.KeineAuswählenToolStripMenuItem, Me.SupervisorToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(163, 92)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AlleAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswählenToolStripMenuItem
        '
        Me.KeineAuswählenToolStripMenuItem.Name = "KeineAuswählenToolStripMenuItem"
        Me.KeineAuswählenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.KeineAuswählenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswählenToolStripMenuItem.Text = "Keine auswählen"
        '
        'SupervisorToolStripMenuItem
        '
        Me.SupervisorToolStripMenuItem.Name = "SupervisorToolStripMenuItem"
        Me.SupervisorToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SupervisorToolStripMenuItem.Tag = "ResID.Supervisor"
        Me.SupervisorToolStripMenuItem.Text = "Supervisor"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contUserAccouts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelGrid)
        Me.Controls.Add(Me.PanelUnten)
        Me.Controls.Add(Me.PanelOben)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(572, 250)
        Me.Name = "contUserAccouts"
        Me.Size = New System.Drawing.Size(883, 380)
        CType(Me.txtPwd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelOben.ResumeLayout(False)
        CType(Me.cboTyp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUnten.PerformLayout()
        Me.PanelButtEditUserAccounts.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        CType(Me.gridUserAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUserAccounts1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelOben As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents gridUserAccounts As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents dropDownEdit As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents btnApport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelButtEditUserAccounts As System.Windows.Forms.Panel
    Public WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents DsUserAccounts1 As dsUserAccounts
    Friend WithEvents CompUserAccounts1 As compUserAccounts
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Public WithEvents cboTyp As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblTyp As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtPwd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents SupervisorToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
