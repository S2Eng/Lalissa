Imports System.Windows.Forms
Imports System.IO
Imports System.Web

Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars

Imports qs2.core.vb
Imports qs2.core
Imports qs2.Resources
Imports S2Extensions


Public Class contAdjust
    Inherits System.Windows.Forms.UserControl


    Public actUsr1 As New actUsr()
    Public ui1 As New qs2.core.ui()
    Public loadVarsSettings As System.Collections.Generic.List(Of ENV.cVarsSettings) = Nothing

    Friend WithEvents ImageListRechner As System.Windows.Forms.ImageList
    Friend WithEvents ImageListButton3D As System.Windows.Forms.ImageList
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StyleNeuLadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StyleAusschlatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraTabControlAdjust As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStripAllSettings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteAllLayoutsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents txtControlOpenStayTypeRoles As UltraWinEditors.UltraTextEditor
    Friend WithEvents lblControlOpenStayTypeRoles As Misc.UltraLabel
    Friend WithEvents lblControlOpenStayType As Misc.UltraLabel
    Friend WithEvents iControlOpenStayType As UltraWinEditors.UltraNumericEditor
    Friend WithEvents grpStayUIStartType As Misc.UltraGroupBox
    Friend WithEvents optStayUIStartType As UltraWinEditors.UltraOptionSet
    Friend WithEvents btnAdd As Misc.UltraButton
    Friend WithEvents btnDel As Misc.UltraButton
    Friend WithEvents DsHelper1 As dsHelper
    Friend WithEvents SqlHelper1 As sqlHelper
    Friend WithEvents gridSettings As UltraWinGrid.UltraGrid
    Friend WithEvents chkOpenFormStayUI As UltraWinEditors.UltraCheckEditor
    Friend WithEvents PanelTotalSettings As System.Windows.Forms.Panel


    Public Enum eAction
        deleteRows = 0

    End Enum




#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'UserControl überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSettings", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Variable", -1, 440897313, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Value", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("validFor", -1, 440955047)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDParticipant", -1, 73244594, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Product", -1, 71388516)
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
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(440897313)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(440955047)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(73244594)
        Dim ValueList4 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(71388516)
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelTotalSettings = New System.Windows.Forms.Panel()
        Me.ContextMenuStripAllSettings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteAllLayoutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridSettings = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsHelper1 = New qs2.core.vb.dsHelper()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.grpStayUIStartType = New Infragistics.Win.Misc.UltraGroupBox()
        Me.optStayUIStartType = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.txtControlOpenStayTypeRoles = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblControlOpenStayTypeRoles = New Infragistics.Win.Misc.UltraLabel()
        Me.lblControlOpenStayType = New Infragistics.Win.Misc.UltraLabel()
        Me.iControlOpenStayType = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ImageListButton3D = New System.Windows.Forms.ImageList(Me.components)
        Me.StyleNeuLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StyleAusschlatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ImageListRechner = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraTabControlAdjust = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SqlHelper1 = New qs2.core.vb.sqlHelper(Me.components)
        Me.chkOpenFormStayUI = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.PanelTotalSettings.SuspendLayout()
        Me.ContextMenuStripAllSettings.SuspendLayout()
        CType(Me.gridSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsHelper1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpStayUIStartType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStayUIStartType.SuspendLayout()
        CType(Me.optStayUIStartType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtControlOpenStayTypeRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iControlOpenStayType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControlAdjust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControlAdjust.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.chkOpenFormStayUI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.PanelTotalSettings)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(694, 275)
        '
        'PanelTotalSettings
        '
        Me.PanelTotalSettings.ContextMenuStrip = Me.ContextMenuStripAllSettings
        Me.PanelTotalSettings.Controls.Add(Me.chkOpenFormStayUI)
        Me.PanelTotalSettings.Controls.Add(Me.gridSettings)
        Me.PanelTotalSettings.Controls.Add(Me.btnAdd)
        Me.PanelTotalSettings.Controls.Add(Me.btnDel)
        Me.PanelTotalSettings.Controls.Add(Me.grpStayUIStartType)
        Me.PanelTotalSettings.Controls.Add(Me.txtControlOpenStayTypeRoles)
        Me.PanelTotalSettings.Controls.Add(Me.lblControlOpenStayTypeRoles)
        Me.PanelTotalSettings.Controls.Add(Me.lblControlOpenStayType)
        Me.PanelTotalSettings.Controls.Add(Me.iControlOpenStayType)
        Me.PanelTotalSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTotalSettings.Location = New System.Drawing.Point(0, 0)
        Me.PanelTotalSettings.Name = "PanelTotalSettings"
        Me.PanelTotalSettings.Size = New System.Drawing.Size(694, 275)
        Me.PanelTotalSettings.TabIndex = 377
        '
        'ContextMenuStripAllSettings
        '
        Me.ContextMenuStripAllSettings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteAllLayoutsToolStripMenuItem})
        Me.ContextMenuStripAllSettings.Name = "ContextMenuStripAllSettings"
        Me.ContextMenuStripAllSettings.Size = New System.Drawing.Size(163, 26)
        '
        'DeleteAllLayoutsToolStripMenuItem
        '
        Me.DeleteAllLayoutsToolStripMenuItem.Name = "DeleteAllLayoutsToolStripMenuItem"
        Me.DeleteAllLayoutsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.DeleteAllLayoutsToolStripMenuItem.Text = "DeleteAllLayouts"
        '
        'gridSettings
        '
        Me.gridSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridSettings.DataMember = "tblSettings"
        Me.gridSettings.DataSource = Me.DsHelper1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSettings.DisplayLayout.Appearance = Appearance1
        Me.gridSettings.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn5.Width = 206
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridColumn6.Width = 216
        UltraGridColumn7.Header.Caption = "valid for"
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn7.Width = 117
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn8.Width = 129
        UltraGridColumn2.Header.VisiblePosition = 5
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        UltraGridColumn2.Width = 100
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn2})
        Me.gridSettings.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSettings.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSettings.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSettings.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSettings.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gridSettings.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSettings.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gridSettings.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSettings.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridSettings.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridSettings.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gridSettings.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSettings.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridSettings.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSettings.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridSettings.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSettings.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSettings.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gridSettings.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gridSettings.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSettings.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gridSettings.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSettings.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gridSettings.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSettings.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Variables"
        ValueList2.Key = "ValidFor"
        ValueList3.Key = "IDParticipant"
        ValueList4.Key = "IDApplications"
        Me.gridSettings.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3, ValueList4})
        Me.gridSettings.Location = New System.Drawing.Point(11, 86)
        Me.gridSettings.Name = "gridSettings"
        Me.gridSettings.Size = New System.Drawing.Size(672, 182)
        Me.gridSettings.TabIndex = 595
        Me.gridSettings.Text = "UltraGrid1"
        '
        'DsHelper1
        '
        Me.DsHelper1.DataSetName = "dsHelper"
        Me.DsHelper1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnAdd.Appearance = Appearance13
        Me.btnAdd.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdd.Location = New System.Drawing.Point(633, 63)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(22, 21)
        Me.btnAdd.TabIndex = 593
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnDel.Appearance = Appearance14
        Me.btnDel.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnDel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDel.Location = New System.Drawing.Point(655, 63)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(22, 21)
        Me.btnDel.TabIndex = 594
        '
        'grpStayUIStartType
        '
        Me.grpStayUIStartType.Controls.Add(Me.optStayUIStartType)
        Me.grpStayUIStartType.Location = New System.Drawing.Point(11, 9)
        Me.grpStayUIStartType.Name = "grpStayUIStartType"
        Me.grpStayUIStartType.Size = New System.Drawing.Size(158, 69)
        Me.grpStayUIStartType.TabIndex = 56
        Me.grpStayUIStartType.Text = "Start-Type Stay-UI "
        '
        'optStayUIStartType
        '
        Me.optStayUIStartType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optStayUIStartType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        ValueListItem1.DataValue = "Single"
        ValueListItem1.DisplayText = "Single"
        ValueListItem2.DataValue = "Thread"
        ValueListItem2.DisplayText = "Thread"
        ValueListItem3.DataValue = "Process"
        ValueListItem3.DisplayText = "Process"
        Me.optStayUIStartType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optStayUIStartType.Location = New System.Drawing.Point(14, 20)
        Me.optStayUIStartType.Name = "optStayUIStartType"
        Me.optStayUIStartType.Size = New System.Drawing.Size(84, 47)
        Me.optStayUIStartType.TabIndex = 55
        '
        'txtControlOpenStayTypeRoles
        '
        Me.txtControlOpenStayTypeRoles.Location = New System.Drawing.Point(364, 44)
        Me.txtControlOpenStayTypeRoles.Name = "txtControlOpenStayTypeRoles"
        Me.txtControlOpenStayTypeRoles.Size = New System.Drawing.Size(123, 21)
        Me.txtControlOpenStayTypeRoles.TabIndex = 23
        '
        'lblControlOpenStayTypeRoles
        '
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.FontData.SizeInPoints = 10.0!
        Me.lblControlOpenStayTypeRoles.Appearance = Appearance15
        Me.lblControlOpenStayTypeRoles.Location = New System.Drawing.Point(178, 45)
        Me.lblControlOpenStayTypeRoles.Name = "lblControlOpenStayTypeRoles"
        Me.lblControlOpenStayTypeRoles.Size = New System.Drawing.Size(183, 18)
        Me.lblControlOpenStayTypeRoles.TabIndex = 26
        Me.lblControlOpenStayTypeRoles.Text = "ControlOpenStayTypeRoles"
        '
        'lblControlOpenStayType
        '
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.FontData.SizeInPoints = 10.0!
        Me.lblControlOpenStayType.Appearance = Appearance16
        Me.lblControlOpenStayType.Location = New System.Drawing.Point(178, 22)
        Me.lblControlOpenStayType.Name = "lblControlOpenStayType"
        Me.lblControlOpenStayType.Size = New System.Drawing.Size(183, 18)
        Me.lblControlOpenStayType.TabIndex = 25
        Me.lblControlOpenStayType.Text = "ControlOpenStayType"
        '
        'iControlOpenStayType
        '
        Me.iControlOpenStayType.Location = New System.Drawing.Point(364, 21)
        Me.iControlOpenStayType.Name = "iControlOpenStayType"
        Me.iControlOpenStayType.Size = New System.Drawing.Size(123, 21)
        Me.iControlOpenStayType.TabIndex = 54
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(9, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 23)
        Me.Label9.TabIndex = 563
        Me.Label9.Text = "Min. Versicherungen"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(228, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 23)
        Me.Label11.TabIndex = 565
        Me.Label11.Text = "Min. Vermittler"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(414, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 23)
        Me.Label10.TabIndex = 564
        Me.Label10.Text = "Min. Verträge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(228, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 23)
        Me.Label8.TabIndex = 562
        Me.Label8.Text = "Max. Vermittler"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(414, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 561
        Me.Label7.Text = "Max. Verträge"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(9, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 23)
        Me.Label6.TabIndex = 560
        Me.Label6.Text = "Max. Versicherungen"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageListButton3D
        '
        Me.ImageListButton3D.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListButton3D.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListButton3D.TransparentColor = System.Drawing.Color.Transparent
        '
        'StyleNeuLadenToolStripMenuItem
        '
        Me.StyleNeuLadenToolStripMenuItem.Name = "StyleNeuLadenToolStripMenuItem"
        Me.StyleNeuLadenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StyleNeuLadenToolStripMenuItem.Text = "Style neu laden"
        '
        'StyleAusschlatenToolStripMenuItem
        '
        Me.StyleAusschlatenToolStripMenuItem.Name = "StyleAusschlatenToolStripMenuItem"
        Me.StyleAusschlatenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StyleAusschlatenToolStripMenuItem.Text = "Style ausschalten"
        '
        'ImageListRechner
        '
        Me.ImageListRechner.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListRechner.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListRechner.TransparentColor = System.Drawing.Color.Transparent
        '
        'UltraTabControlAdjust
        '
        Me.UltraTabControlAdjust.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControlAdjust.Controls.Add(Me.UltraTabPageControl1)
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.OriginX = 0
        GridBagConstraint1.OriginY = 0
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.UltraTabControlAdjust, GridBagConstraint1)
        Me.UltraTabControlAdjust.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControlAdjust.Name = "UltraTabControlAdjust"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.UltraTabControlAdjust, New System.Drawing.Size(270, 146))
        Me.UltraTabControlAdjust.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControlAdjust.Size = New System.Drawing.Size(698, 301)
        Me.UltraTabControlAdjust.TabIndex = 378
        UltraTab1.Key = "totalSettings"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Total Settings"
        Me.UltraTabControlAdjust.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(694, 275)
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.UltraTabControlAdjust)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(698, 301)
        Me.UltraGridBagLayoutPanel1.TabIndex = 379
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(698, 301)
        Me.Panel1.TabIndex = 382
        '
        'chkOpenFormStayUI
        '
        Me.chkOpenFormStayUI.Location = New System.Drawing.Point(506, 23)
        Me.chkOpenFormStayUI.Name = "chkOpenFormStayUI"
        Me.chkOpenFormStayUI.Size = New System.Drawing.Size(121, 17)
        Me.chkOpenFormStayUI.TabIndex = 596
        Me.chkOpenFormStayUI.Text = "Stay-UI Open Form"
        '
        'contAdjust
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Name = "contAdjust"
        Me.Size = New System.Drawing.Size(698, 301)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.PanelTotalSettings.ResumeLayout(False)
        Me.PanelTotalSettings.PerformLayout()
        Me.ContextMenuStripAllSettings.ResumeLayout(False)
        CType(Me.gridSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsHelper1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpStayUIStartType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStayUIStartType.ResumeLayout(False)
        CType(Me.optStayUIStartType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtControlOpenStayTypeRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iControlOpenStayType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControlAdjust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControlAdjust.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.chkOpenFormStayUI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub EinstellungenITSCont_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl()
        Try
            Me.loadRes()
            Me.readRights()

            Me.optStayUIStartType.Enabled = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()
            Me.iControlOpenStayType.Enabled = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()
            Me.txtControlOpenStayTypeRoles.Enabled = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()

            Me.gridSettings.DisplayLayout.ValueLists("Variables").ValueListItems.Clear()
            Dim b As New qs2.core.vb.businessFramework()
            Me.loadVarsSettings = b.loadVarsSettings()
            For Each sett As ENV.cVarsSettings In Me.loadVarsSettings
                Dim itm As ValueListItem = Me.gridSettings.DisplayLayout.ValueLists("Variables").ValueListItems.Add(sett.VarDef.Trim(), sett.VarDef.Trim())
            Next

            Me.gridSettings.DisplayLayout.ValueLists("ValidFor").ValueListItems.Clear()
            For Each sett As ENV.cVarsSettings In Me.loadVarsSettings
                Dim itm As ValueListItem = Me.gridSettings.DisplayLayout.ValueLists("ValidFor").ValueListItems.Add(sqlAdmin.eTypSelAdjust.all.ToString(), sqlAdmin.eTypSelAdjust.all.ToString())
                itm = Me.gridSettings.DisplayLayout.ValueLists("ValidFor").ValueListItems.Add(sqlAdmin.eTypSelAdjust.forUsr.ToString(), sqlAdmin.eTypSelAdjust.forUsr.ToString())
                itm = Me.gridSettings.DisplayLayout.ValueLists("ValidFor").ValueListItems.Add(sqlAdmin.eTypSelAdjust.forClient.ToString(), sqlAdmin.eTypSelAdjust.forClient.ToString())
            Next

            Me.gridSettings.DisplayLayout.ValueLists("IDParticipant").ValueListItems.Clear()
            For Each rParticipant As qs2.core.license.dsLicense.ParticipantRow In qs2.core.license.doLicense._dsLicenseAct.Participant
                Dim itm As ValueListItem = Me.gridSettings.DisplayLayout.ValueLists("IDParticipant").ValueListItems.Add(rParticipant.IDParticipant.Trim(), rParticipant.IDParticipant.Trim())
            Next

            Me.gridSettings.DisplayLayout.ValueLists("IDApplications").ValueListItems.Clear()
            Dim itmApp As ValueListItem = Me.gridSettings.DisplayLayout.ValueLists("IDApplications").ValueListItems.Add(qs2.core.license.doLicense.eApp.CARDIAC.ToString(), qs2.core.license.doLicense.eApp.CARDIAC.ToString())
            itmApp = Me.gridSettings.DisplayLayout.ValueLists("IDApplications").ValueListItems.Add(qs2.core.license.doLicense.eApp.VASCULAR.ToString(), qs2.core.license.doLicense.eApp.VASCULAR.ToString())
            itmApp = Me.gridSettings.DisplayLayout.ValueLists("IDApplications").ValueListItems.Add(qs2.core.license.doLicense.eApp.NC.ToString(), qs2.core.license.doLicense.eApp.NC.ToString())
            itmApp = Me.gridSettings.DisplayLayout.ValueLists("IDApplications").ValueListItems.Add(qs2.core.license.doLicense.eApp.QTH.ToString(), qs2.core.license.doLicense.eApp.QTH.ToString())

        Catch ex As Exception
            Throw New Exception("contAdjust.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.UltraTabControlAdjust.Tabs(0).Text = qs2.core.language.sqlLanguage.getRes("TotalSettings")
            Me.DeleteAllLayoutsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("DeleteAllLayouts")
            Me.DeleteAllLayoutsToolStripMenuItem.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.grpStayUIStartType.Text = qs2.core.language.sqlLanguage.getRes("StartTypeStayUI")

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.DeleteAllLayoutsToolStripMenuItem.Visible = True
            Else
                Me.DeleteAllLayoutsToolStripMenuItem.Visible = False
            End If

            Me.btnAdd.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDel.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

        Catch ex As Exception
            Throw New Exception("contAdjust.loadRes: " + ex.ToString())
        End Try
    End Sub

    Public Sub readRights()
        Try
            Me.UltraTabControlAdjust.VisibleTabs(0).Visible = True

        Catch ex As Exception
            Throw New Exception("contAdjust.readRights: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData()
        Try
            Dim b As New qs2.core.vb.businessFramework()
            Dim sStartTypeStayUIReturn As String = ""
            b.loadENVFromAdjustment(Me.iControlOpenStayType.Value, Me.txtControlOpenStayTypeRoles.Text, True, sStartTypeStayUIReturn)
            Me.optStayUIStartType.Value = sStartTypeStayUIReturn.Trim()

            Dim oOpenFormStayUI As Object = actUsr.adjustRead("", sqlAdmin.eAdjust.StayUIOpenForm, sqlAdmin.eTypSelAdjust.all, "")
            If Not oOpenFormStayUI Is Nothing Then
                Me.chkOpenFormStayUI.Checked = oOpenFormStayUI
            Else
                Me.chkOpenFormStayUI.Checked = False
            End If

            Me.loadGridSettings()
            Me.gridSettings.Refresh()

        Catch ex As Exception
            Throw New Exception("contAdjust.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadGridSettings()
        Try
            Me.DsHelper1.Clear()
            Me.gridSettings.Refresh()

            Dim dsAdminRead As New dsAdmin()
            Dim sqlAdminRead As New sqlAdmin()
            sqlAdminRead.initControl()
            sqlAdminRead.getAdjust("", sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant, dsAdminRead, sqlAdmin.eTypSelAdjust.allGrid, "")

            For Each rAdjust As dsAdmin.tblAdjustRow In dsAdminRead.tblAdjust
                Dim lstVars As System.Collections.Generic.List(Of String) = qs2.core.generic.getVarsBy(rAdjust.str.Trim(), "_")

                If rAdjust.setting.sEquals(New List(Of Object) From
                                                   {sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant,
                                                    sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant,
                                                    sqlAdmin.eAdjust.UploadPrintAllChapters
                                                   }) Then

                    Dim rNewSetting As dsHelper.tblSettingsRow = Me.SqlHelper1.getNewRowSettings(Me.DsHelper1)
                    Dim IDParticipant As String = lstVars(0).Trim()
                    Dim iControlOpenStayType As String = lstVars(1).Trim()
                    Dim IDGuid As System.Guid = New Guid(lstVars(2).Trim())

                    Dim Product As String = ""
                    If lstVars.Count > 3 Then
                        Product = lstVars(3).Trim()
                    End If

                    rNewSetting.Variable = rAdjust.setting.Trim()              'sqlAdmin.eAdjust.ControlOpenStayTypeIDPartidipant.ToString()
                    rNewSetting.IDParticipant = IDParticipant.Trim()
                    rNewSetting.Value = iControlOpenStayType.ToString().Trim()
                    rNewSetting.Product = Product.Trim()
                Else
                    Throw New Exception("loadGridSettings: rAdjust.Variable '" + rAdjust.setting.Trim() + "' not allowed!")
                End If
            Next

            Me.gridSettings.Refresh()

        Catch ex As Exception
            Throw New Exception("contAdjust.loadGridSettings: " + ex.ToString())
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            For Each rGrid As UltraWinGrid.UltraGridRow In Me.gridSettings.Rows
                Dim vBefore As DataRowView = rGrid.ListObject
                Dim rSetting As dsHelper.tblSettingsRow = vBefore.Row

                If rSetting.RowState <> DataRowState.Deleted Then
                    If rSetting.Variable.Trim().Equals("") Then
                        Dim txt As String = "Variable : Input required" + "!"
                        rSetting.SetColumnError(rGrid.Cells(Me.DsHelper1.tblSettings.VariableColumn.ColumnName).Column.Index, txt)
                        qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "")
                        rGrid.Selected = True
                        Return False
                    Else
                        If Not rSetting.Variable.sEquals(New List(Of Object) From
                                                   {sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant.ToString(),
                                                    sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant.ToString(),
                                                    sqlAdmin.eAdjust.UploadPrintAllChapters.ToString()
                                                   }) Then

                            Dim txt As String = "Variable " + rSetting.Variable.ToString() + " : Input is wrong!"
                            rSetting.SetColumnError(rGrid.Cells(Me.DsHelper1.tblSettings.VariableColumn.ColumnName).Column.Index, txt)
                            qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "")
                            rGrid.Selected = True
                            Return False
                        End If
                    End If

                        If rSetting.Value.Trim().Equals("") Then
                        Dim txt As String = "Value: Input required" + "!"
                        rSetting.SetColumnError(rGrid.Cells(Me.DsHelper1.tblSettings.ValueColumn.ColumnName).Column.Index, txt)
                        qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "")
                        rGrid.Selected = True
                        Return False
                    End If

                    If String.IsNullOrWhiteSpace(rSetting.IDParticipant) Then
                        Dim txt As String = "IDParticipant: Input required" + "!"
                        rSetting.SetColumnError(rGrid.Cells(Me.DsHelper1.tblSettings.IDParticipantColumn.ColumnName).Column.Index, txt)
                        qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "")
                        rGrid.Selected = True
                        Return False
                    End If

                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contAdjust.validateData: " + ex.ToString())
        End Try
    End Function

    Public Sub saveSettings2()
        Try
            actUsr.adjustSave("", sqlAdmin.eAdjust.ControlOpenStayType, sqlAdmin.eTypSelAdjust.all, Me.iControlOpenStayType.Value)
            actUsr.adjustSave("", sqlAdmin.eAdjust.ControlOpenStayTypeRoles, sqlAdmin.eTypSelAdjust.all, Me.txtControlOpenStayTypeRoles.Text.Trim())

            If String.IsNullOrWhiteSpace(Me.optStayUIStartType.Value) Then
                Throw New Exception("saveSettings2: Me.optStayUIStartType.Value.Trim()='' not allowed!")
            End If
            actUsr.adjustSave("", sqlAdmin.eAdjust.StartTypeStayUI, sqlAdmin.eTypSelAdjust.all, Me.optStayUIStartType.Value.ToString())
            actUsr.adjustSave("", sqlAdmin.eAdjust.StayUIOpenForm, sqlAdmin.eTypSelAdjust.all, Me.chkOpenFormStayUI.Checked)

            Me.saveGridSettings()

            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PleaseRestartTheSystem") + "!", Windows.Forms.MessageBoxButtons.OK, "")

        Catch ex As Exception
            Throw New Exception("contAdjust.saveSettings2: " + ex.ToString())
        End Try
    End Sub

    Public Sub saveGridSettings()
        Try
            Dim sqlAdminDelete As New sqlAdmin()
            sqlAdminDelete.initControl()
            sqlAdminDelete.deleteAdjustment(sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant.ToString())
            sqlAdminDelete.deleteAdjustment(sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant.ToString())
            sqlAdminDelete.deleteAdjustment(sqlAdmin.eAdjust.UploadPrintAllChapters.ToString())

            For Each rSettingsGrid As UltraWinGrid.UltraGridRow In Me.gridSettings.Rows
                Dim vBefore As DataRowView = rSettingsGrid.ListObject
                Dim rSetting As dsHelper.tblSettingsRow = vBefore.Row

                If rSetting.Variable.sEquals(New List(Of Object) From
                                                   {sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant,
                                                    sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant,
                                                    sqlAdmin.eAdjust.UploadPrintAllChapters
                                                   }) Then

                    Dim adjust As sqlAdmin.eAdjust = Nothing
                    If rSetting.Variable.sEquals(sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant) Then
                        adjust = sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant
                    ElseIf rSetting.Variable.sEquals(sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant) Then
                        adjust = sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant
                    ElseIf rSetting.Variable.sEquals(sqlAdmin.eAdjust.UploadPrintAllChapters) Then
                        adjust = sqlAdmin.eAdjust.UploadPrintAllChapters
                    End If

                    Dim dsAdminUpdate As New dsAdmin()
                    Dim sqlAdminUpdate As New sqlAdmin()
                    sqlAdminUpdate.initControl()
                    sqlAdminUpdate.getAdjust(System.Guid.NewGuid().ToString(), sqlAdmin.eAdjust.ControlOpenStayType, dsAdminUpdate, sqlAdmin.eTypSelAdjust.forUsr, "")

                    Dim IDGuid As System.Guid = System.Guid.NewGuid()
                    Dim sValue As String = rSetting.IDParticipant.Trim() + "_" + rSetting.Value.Trim() + "_" + IDGuid.ToString() + "_" + rSetting.Product.Trim()
                    Dim rNew As dsAdmin.tblAdjustRow = sqlAdminUpdate.newRowAdjustment(dsAdminUpdate)
                    rNew.setting = adjust.ToString()
                    rNew.client = sqlAdmin.eTypSelAdjust.allGrid.ToString() + "_" + IDGuid.ToString()
                    rNew.usrSetting = False
                    rNew.type = sValue.GetType().ToString()
                    rNew.str = sValue.Trim()
                    rNew.dbl = 0
                    rNew.bool = False
                    rNew.SetdatNull()
                    rNew.SetbytNull()

                    sqlAdminUpdate.daAdjust.Update(dsAdminUpdate.tblAdjust)

                Else
                    Throw New Exception("saveGridSettings: rSetting.Variable '" + rSetting.Variable.Trim() + "' not allowed!")
                End If
            Next

            Me.loadGridSettings()

        Catch ex As Exception
            Throw New Exception("contAdjust.saveSettings2: " + ex.ToString())
        End Try
    End Sub

    Public Sub Loadstyle()
        Try
            Me.Cursor = Cursors.WaitCursor
            qs2.core.vb.ui.loadStyleInfrag(True, "Light", "Usermanaagment")

        Catch ex As Exception
            Throw New Exception("contAdjust.Loadstyle: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub noStyle()
        Try
            Me.Cursor = Cursors.WaitCursor
            qs2.core.vb.ui.loadStyleInfrag(False, "", "Usermanaagment")

        Catch ex As Exception
            Throw New Exception("contAdjust.noStyle: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DeleteAllLayoutsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteAllLayoutsToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouReallyWantToDeleteAllLayouts") + "?",
                                            Windows.Forms.MessageBoxButtons.YesNo, "") = MsgBoxResult.Yes Then
                Dim compLayoutGrid1 As New compLayout()
                compLayoutGrid1.sys_deleteAllLayouts()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function addRowSetting() As Boolean
        Try
            Dim rNew As dsHelper.tblSettingsRow = Me.SqlHelper1.getNewRowSettings(Me.DsHelper1)
            Me.gridSettings.Refresh()

        Catch ex As Exception
            Throw New Exception("contAdjust.addRowSetting: " + ex.ToString())
        End Try
    End Function

    Public Function delRowSetting() As Boolean
        Try
            Me.doAction(False, eAction.deleteRows)

        Catch ex As Exception
            Throw New Exception("contAdjust.delRowSetting: " + ex.ToString())
        End Try
    End Function

    Public Function doAction(ByVal msgBox As Boolean, ByRef action As eAction) As Boolean
        Try
            Dim lstSel As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)()
            qs2.core.ui.getSelectedGridRows(Me.gridSettings, lstSel, True)
            If lstSel.Count > 0 Then
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In lstSel
                    Dim v As DataRowView = row.ListObject
                    Dim rSelSetting As dsHelper.tblSettingsRow = v.Row

                    If action = eAction.deleteRows Then
                        row.Delete(False)
                    End If
                Next

            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contAdjust.doAction: " + ex.ToString())
        End Try
    End Function


    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsHelper.tblSettingsRow
        Try
            If Not Me.gridSettings.ActiveRow Is Nothing Then
                If Me.gridSettings.ActiveRow.IsGroupByRow Or Me.gridSettings.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    Dim v As DataRowView = Me.gridSettings.ActiveRow.ListObject
                    Dim rSelObj As dsHelper.tblSettingsRow = v.Row
                    selRowGrid = Me.gridSettings.ActiveRow
                    Return rSelObj
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contAdjust.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Private Sub gridSettings_BeforeCellActivate(sender As Object, e As UltraWinGrid.CancelableCellEventArgs) Handles gridSettings.BeforeCellActivate
        Try
            If e.Cell.Column.sEquals(New List(Of Object) From
                                   {Me.DsHelper1.tblSettings.VariableColumn.ColumnName,
                                    Me.DsHelper1.tblSettings.ValueColumn.ColumnName,
                                    Me.DsHelper1.tblSettings.validForColumn.ColumnName,
                                    Me.DsHelper1.tblSettings.ProductColumn.ColumnName,
                                    Me.DsHelper1.tblSettings.IDParticipantColumn.ColumnName
                                   }) Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSettings_BeforeRowsDeleted(sender As Object, e As UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridSettings.BeforeRowsDeleted
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSettings_Click(sender As Object, e As EventArgs) Handles gridSettings.Click
        Try
            If Me.ui1.evClickOK(sender, e, Me.gridSettings) Then

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSettings_DoubleClick(sender As Object, e As EventArgs) Handles gridSettings.DoubleClick
        Try
            If Me.ui1.evDoubleClickOK(sender, e, Me.gridSettings) Then

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.addRowSetting()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.delRowSetting()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
