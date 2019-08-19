<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contSelectPatientenBenutzer
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cboBerufsgruppen = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblBerufsgruppen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblSelectNone = New qs2.Desktop.ControlManagment.BaseLabel()
        Me.lblSelectAll = New qs2.Desktop.ControlManagment.BaseLabel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnSelectSave = New qs2.Desktop.ControlManagment.BaseButton()
        Me.PanelCenter = New System.Windows.Forms.Panel()
        Me.chkShowNotActiveUsers = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lblSelected = New Infragistics.Win.Misc.UltraLabel()
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.treeBenutzerPatientsSelected = New Infragistics.Win.UltraWinListView.UltraListView()
        Me.ContextMenuStripObjectsSelected = New System.Windows.Forms.ContextMenuStrip()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.utreeAbtBereiche = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.treeBenutzerPatients = New Infragistics.Win.UltraWinListView.UltraListView()
        Me.lblSearch = New Infragistics.Win.Misc.UltraLabel()
        Me.chkShowOnlyAnwesendePatienten = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.DsPlan1 = New PMDS.GUI.VB.dsPlan()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.CompPlan1 = New PMDS.GUI.VB.compPlan()
        CType(Me.cboBerufsgruppen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        CType(Me.chkShowNotActiveUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.treeBenutzerPatientsSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripObjectsSelected.SuspendLayout()
        CType(Me.utreeAbtBereiche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.treeBenutzerPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowOnlyAnwesendePatienten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlan1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboBerufsgruppen
        '
        Me.cboBerufsgruppen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboBerufsgruppen.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cboBerufsgruppen.Location = New System.Drawing.Point(591, 5)
        Me.cboBerufsgruppen.Name = "cboBerufsgruppen"
        Me.cboBerufsgruppen.Size = New System.Drawing.Size(216, 21)
        Me.cboBerufsgruppen.TabIndex = 0
        '
        'lblBerufsgruppen
        '
        Me.lblBerufsgruppen.Location = New System.Drawing.Point(511, 8)
        Me.lblBerufsgruppen.Name = "lblBerufsgruppen"
        Me.lblBerufsgruppen.Size = New System.Drawing.Size(81, 15)
        Me.lblBerufsgruppen.TabIndex = 1
        Me.lblBerufsgruppen.Text = "Berufsgruppen"
        '
        'lblSelectNone
        '
        Me.lblSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance1.FontData.SizeInPoints = 8.0!
        Appearance1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSelectNone.Appearance = Appearance1
        Me.lblSelectNone.AutoSize = True
        Appearance2.FontData.UnderlineAsString = "True"
        Me.lblSelectNone.HotTrackAppearance = Appearance2
        Me.lblSelectNone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectNone.Location = New System.Drawing.Point(1087, 8)
        Me.lblSelectNone.Margin = New System.Windows.Forms.Padding(4)
        Me.lblSelectNone.Name = "lblSelectNone"
        Me.lblSelectNone.Size = New System.Drawing.Size(32, 14)
        Me.lblSelectNone.TabIndex = 17
        Me.lblSelectNone.Tag = "Res.ID.SelectNone"
        Me.lblSelectNone.Text = "Keine"
        Me.lblSelectNone.UseAppStyling = False
        Me.lblSelectNone.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblSelectAll
        '
        Me.lblSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance3.FontData.SizeInPoints = 8.0!
        Appearance3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSelectAll.Appearance = Appearance3
        Me.lblSelectAll.AutoSize = True
        Appearance4.FontData.UnderlineAsString = "True"
        Me.lblSelectAll.HotTrackAppearance = Appearance4
        Me.lblSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectAll.Location = New System.Drawing.Point(1062, 8)
        Me.lblSelectAll.Margin = New System.Windows.Forms.Padding(4)
        Me.lblSelectAll.Name = "lblSelectAll"
        Me.lblSelectAll.Size = New System.Drawing.Size(23, 14)
        Me.lblSelectAll.TabIndex = 16
        Me.lblSelectAll.Tag = "Res.ID.SelectAll"
        Me.lblSelectAll.Text = "Alle"
        Me.lblSelectAll.UseAppStyling = False
        Me.lblSelectAll.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.btnSelectSave)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 691)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1129, 33)
        Me.PanelBottom.TabIndex = 3
        '
        'btnSelectSave
        '
        Me.btnSelectSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSelectSave.Appearance = Appearance5
        Me.btnSelectSave.AutoWorkLayout = False
        Me.btnSelectSave.IsStandardControl = False
        Me.btnSelectSave.Location = New System.Drawing.Point(1046, 2)
        Me.btnSelectSave.Name = "btnSelectSave"
        Me.btnSelectSave.Size = New System.Drawing.Size(74, 27)
        Me.btnSelectSave.TabIndex = 10
        Me.btnSelectSave.Tag = "ResID.OK"
        Me.btnSelectSave.Text = "OK"
        '
        'PanelCenter
        '
        Me.PanelCenter.Controls.Add(Me.chkShowNotActiveUsers)
        Me.PanelCenter.Controls.Add(Me.lblSelected)
        Me.PanelCenter.Controls.Add(Me.txtSearch)
        Me.PanelCenter.Controls.Add(Me.cboBerufsgruppen)
        Me.PanelCenter.Controls.Add(Me.treeBenutzerPatientsSelected)
        Me.PanelCenter.Controls.Add(Me.lblSelectNone)
        Me.PanelCenter.Controls.Add(Me.utreeAbtBereiche)
        Me.PanelCenter.Controls.Add(Me.lblSelectAll)
        Me.PanelCenter.Controls.Add(Me.treeBenutzerPatients)
        Me.PanelCenter.Controls.Add(Me.lblSearch)
        Me.PanelCenter.Controls.Add(Me.lblBerufsgruppen)
        Me.PanelCenter.Controls.Add(Me.chkShowOnlyAnwesendePatienten)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 0)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(1129, 691)
        Me.PanelCenter.TabIndex = 1
        '
        'chkShowNotActiveUsers
        '
        Me.chkShowNotActiveUsers.Location = New System.Drawing.Point(592, 28)
        Me.chkShowNotActiveUsers.Name = "chkShowNotActiveUsers"
        Me.chkShowNotActiveUsers.Size = New System.Drawing.Size(215, 17)
        Me.chkShowNotActiveUsers.TabIndex = 429
        Me.chkShowNotActiveUsers.Text = "Nicht aktive Benutzer anzeigen"
        '
        'lblSelected
        '
        Me.lblSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblSelected.Appearance = Appearance6
        Me.lblSelected.Location = New System.Drawing.Point(815, 7)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(111, 17)
        Me.lblSelected.TabIndex = 427
        Me.lblSelected.Tag = ""
        Me.lblSelected.Text = "Ausgewählt"
        '
        'txtSearch
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackColorDisabled = System.Drawing.Color.White
        Appearance7.BackColorDisabled2 = System.Drawing.Color.White
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.ItalicAsString = "False"
        Appearance7.FontData.Name = "Microsoft Sans Serif"
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.FontData.StrikeoutAsString = "False"
        Appearance7.FontData.UnderlineAsString = "False"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtSearch.Appearance = Appearance7
        Me.txtSearch.AutoSize = False
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(292, 5)
        Me.txtSearch.MaxLength = 0
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(209, 21)
        Me.txtSearch.TabIndex = 424
        Me.txtSearch.Tag = "Vorname"
        '
        'treeBenutzerPatientsSelected
        '
        Me.treeBenutzerPatientsSelected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackColorDisabled = System.Drawing.Color.White
        Appearance8.BackColorDisabled2 = System.Drawing.Color.White
        Appearance8.FontData.SizeInPoints = 10.0!
        Me.treeBenutzerPatientsSelected.Appearance = Appearance8
        Me.treeBenutzerPatientsSelected.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.treeBenutzerPatientsSelected.ContextMenuStrip = Me.ContextMenuStripObjectsSelected
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Me.treeBenutzerPatientsSelected.ItemSettings.ActiveAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Me.treeBenutzerPatientsSelected.ItemSettings.SelectedAppearance = Appearance10
        Me.treeBenutzerPatientsSelected.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.[Single]
        Me.treeBenutzerPatientsSelected.Location = New System.Drawing.Point(815, 48)
        Me.treeBenutzerPatientsSelected.MainColumn.AllowSorting = Infragistics.Win.DefaultableBoolean.[True]
        Me.treeBenutzerPatientsSelected.MainColumn.Sorting = Infragistics.Win.UltraWinListView.Sorting.Ascending
        Me.treeBenutzerPatientsSelected.Name = "treeBenutzerPatientsSelected"
        Me.treeBenutzerPatientsSelected.Size = New System.Drawing.Size(310, 642)
        Me.treeBenutzerPatientsSelected.TabIndex = 426
        Me.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List
        Me.treeBenutzerPatientsSelected.ViewSettingsList.ImageSize = New System.Drawing.Size(0, 0)
        '
        'ContextMenuStripObjectsSelected
        '
        Me.ContextMenuStripObjectsSelected.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LöschenToolStripMenuItem})
        Me.ContextMenuStripObjectsSelected.Name = "ContextMenuStripObjectsSelected"
        Me.ContextMenuStripObjectsSelected.Size = New System.Drawing.Size(119, 26)
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'utreeAbtBereiche
        '
        Me.utreeAbtBereiche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.utreeAbtBereiche.Location = New System.Drawing.Point(3, 48)
        Me.utreeAbtBereiche.Name = "utreeAbtBereiche"
        Me.utreeAbtBereiche.Size = New System.Drawing.Size(245, 642)
        Me.utreeAbtBereiche.TabIndex = 18
        '
        'treeBenutzerPatients
        '
        Me.treeBenutzerPatients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.FontData.SizeInPoints = 10.0!
        Me.treeBenutzerPatients.Appearance = Appearance11
        Me.treeBenutzerPatients.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Me.treeBenutzerPatients.ItemSettings.ActiveAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Me.treeBenutzerPatients.ItemSettings.SelectedAppearance = Appearance13
        Me.treeBenutzerPatients.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.[Single]
        Me.treeBenutzerPatients.Location = New System.Drawing.Point(251, 48)
        Me.treeBenutzerPatients.Name = "treeBenutzerPatients"
        Me.treeBenutzerPatients.Size = New System.Drawing.Size(561, 642)
        Me.treeBenutzerPatients.TabIndex = 1
        Me.treeBenutzerPatients.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List
        Me.treeBenutzerPatients.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox
        Me.treeBenutzerPatients.ViewSettingsList.ImageSize = New System.Drawing.Size(0, 0)
        '
        'lblSearch
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblSearch.Appearance = Appearance14
        Me.lblSearch.Location = New System.Drawing.Point(251, 7)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(49, 17)
        Me.lblSearch.TabIndex = 425
        Me.lblSearch.Tag = "ResID.Search"
        Me.lblSearch.Text = "Suche"
        Me.lblSearch.Visible = False
        '
        'chkShowOnlyAnwesendePatienten
        '
        Me.chkShowOnlyAnwesendePatienten.Checked = True
        Me.chkShowOnlyAnwesendePatienten.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowOnlyAnwesendePatienten.Location = New System.Drawing.Point(508, 5)
        Me.chkShowOnlyAnwesendePatienten.Name = "chkShowOnlyAnwesendePatienten"
        Me.chkShowOnlyAnwesendePatienten.Size = New System.Drawing.Size(145, 20)
        Me.chkShowOnlyAnwesendePatienten.TabIndex = 428
        Me.chkShowOnlyAnwesendePatienten.Text = "Nur anwesende Klienten"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Left"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 724)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(1129, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Right"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 724)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Top"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(1129, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom
        '
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Gainsboro
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 724)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Name = "_contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom"
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(1129, 0)
        Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'DsPlan1
        '
        Me.DsPlan1.DataSetName = "dsPlan"
        Me.DsPlan1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'contSelectPatientenBenutzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PanelCenter)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._contSelectPatientenBenutzer_Toolbars_Dock_Area_Top)
        Me.Name = "contSelectPatientenBenutzer"
        Me.Size = New System.Drawing.Size(1129, 724)
        CType(Me.cboBerufsgruppen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        Me.PanelCenter.PerformLayout()
        CType(Me.chkShowNotActiveUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.treeBenutzerPatientsSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripObjectsSelected.ResumeLayout(False)
        CType(Me.utreeAbtBereiche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.treeBenutzerPatients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowOnlyAnwesendePatienten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlan1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelCenter As Windows.Forms.Panel
    Public WithEvents btnSelectSave As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents cboBerufsgruppen As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblBerufsgruppen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _contSelectPatientenBenutzer_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Public WithEvents treeBenutzerPatients As Infragistics.Win.UltraWinListView.UltraListView
    Friend WithEvents lblSelectNone As QS2.Desktop.ControlManagment.BaseLabel
    Friend WithEvents lblSelectAll As QS2.Desktop.ControlManagment.BaseLabel
    Friend WithEvents CompPlan1 As compPlan
    Friend WithEvents DsPlan1 As dsPlan
    Public WithEvents utreeAbtBereiche As Infragistics.Win.UltraWinTree.UltraTree
    Public WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblSearch As Infragistics.Win.Misc.UltraLabel
    Public WithEvents treeBenutzerPatientsSelected As Infragistics.Win.UltraWinListView.UltraListView
    Public WithEvents PanelBottom As Windows.Forms.Panel
    Friend WithEvents chkShowOnlyAnwesendePatienten As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkShowNotActiveUsers As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ContextMenuStripObjectsSelected As Windows.Forms.ContextMenuStrip
    Friend WithEvents LöschenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Public WithEvents lblSelected As Infragistics.Win.Misc.UltraLabel
End Class
