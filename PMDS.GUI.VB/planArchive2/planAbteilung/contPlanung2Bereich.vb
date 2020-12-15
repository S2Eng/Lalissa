Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms
Imports System.Drawing
Imports PMDS.GUI.VB.contPlanungData
Imports Infragistics.Win.Misc
Imports PMDS.db



Public Class contPlanung2Bereich
    Inherits System.Windows.Forms.UserControl


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
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
    Public WithEvents UDateBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Public WithEvents UDateVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblAnd As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBeginntZwischen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpSearch As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelTop As Panel
    Friend WithEvents PanelCenter As Panel
    Friend WithEvents lblBetreff As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtBetreff2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSearch As Infragistics.Win.Misc.UltraButton
    Public WithEvents optStatus As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblStatus As Infragistics.Win.Misc.UltraLabel
    Public WithEvents lblFound As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnLayout_AbtBereichPlan As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents PanelButtonsLayout As Panel
    Private WithEvents btnLayout_Plan As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnLayout_KatAbtBereichPlan As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents btnPrint As UltraButton
    Friend WithEvents ContPlanungDataBereich1 As contPlanungDataBereich
    Friend WithEvents dropDownAbteilungBereiche As UltraDropDownButton
    Friend WithEvents dropDownBerufsgruppen As UltraDropDownButton
    Private WithEvents uPopupContBerufsgruppen As UltraPopupControlContainer
    Private WithEvents uPopupAbteilungBereiche As UltraPopupControlContainer
    Friend WithEvents btnAdd2 As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Neuen Planungseintrag erstellen", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Me.grpSearch = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dropDownAbteilungBereiche = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.dropDownBerufsgruppen = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.PanelButtonsLayout = New System.Windows.Forms.Panel()
        Me.btnLayout_Plan = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnLayout_KatAbtBereichPlan = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnLayout_AbtBereichPlan = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnSearch = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblFound = New Infragistics.Win.Misc.UltraLabel()
        Me.lblStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.UDateBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDateVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtBetreff2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBetreff = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.lblBeginntZwischen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAnd = New Infragistics.Win.Misc.UltraLabel()
        Me.btnPrint = New Infragistics.Win.Misc.UltraButton()
        Me.btnAdd2 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelCenter = New System.Windows.Forms.Panel()
        Me.ContPlanungDataBereich1 = New PMDS.GUI.VB.contPlanungDataBereich()
        Me.uPopupContBerufsgruppen = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopupAbteilungBereiche = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        Me.PanelButtonsLayout.SuspendLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBetreff2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.grpSearch.Appearance = Appearance1
        Me.grpSearch.Controls.Add(Me.dropDownAbteilungBereiche)
        Me.grpSearch.Controls.Add(Me.dropDownBerufsgruppen)
        Me.grpSearch.Controls.Add(Me.PanelButtonsLayout)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.UltraLabel1)
        Me.grpSearch.Controls.Add(Me.lblFound)
        Me.grpSearch.Controls.Add(Me.lblStatus)
        Me.grpSearch.Controls.Add(Me.optStatus)
        Me.grpSearch.Controls.Add(Me.UDateBis)
        Me.grpSearch.Controls.Add(Me.UDateVon)
        Me.grpSearch.Controls.Add(Me.txtBetreff2)
        Me.grpSearch.Controls.Add(Me.lblBetreff)
        Me.grpSearch.Controls.Add(Me.dropDownCategories)
        Me.grpSearch.Controls.Add(Me.lblBeginntZwischen)
        Me.grpSearch.Controls.Add(Me.lblAnd)
        Me.grpSearch.Location = New System.Drawing.Point(7, 3)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(557, 171)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.Tag = "ResID.Search"
        Me.grpSearch.Text = "Suche"
        '
        'dropDownAbteilungBereiche
        '
        Appearance2.BorderColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Left"
        Me.dropDownAbteilungBereiche.Appearance = Appearance2
        Me.dropDownAbteilungBereiche.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownAbteilungBereiche.Location = New System.Drawing.Point(282, 97)
        Me.dropDownAbteilungBereiche.Name = "dropDownAbteilungBereiche"
        Me.dropDownAbteilungBereiche.Size = New System.Drawing.Size(165, 24)
        Me.dropDownAbteilungBereiche.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownAbteilungBereiche.TabIndex = 1006
        Me.dropDownAbteilungBereiche.TabStop = False
        Me.dropDownAbteilungBereiche.Tag = ""
        Me.dropDownAbteilungBereiche.Text = "Abteilungen-Bereiche"
        '
        'dropDownBerufsgruppen
        '
        Appearance3.BorderColor = System.Drawing.Color.Black
        Appearance3.TextHAlignAsString = "Left"
        Me.dropDownBerufsgruppen.Appearance = Appearance3
        Me.dropDownBerufsgruppen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownBerufsgruppen.Location = New System.Drawing.Point(125, 97)
        Me.dropDownBerufsgruppen.Name = "dropDownBerufsgruppen"
        Me.dropDownBerufsgruppen.Size = New System.Drawing.Size(154, 24)
        Me.dropDownBerufsgruppen.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownBerufsgruppen.TabIndex = 1005
        Me.dropDownBerufsgruppen.TabStop = False
        Me.dropDownBerufsgruppen.Tag = ""
        Me.dropDownBerufsgruppen.Text = "Berufsgruppen"
        '
        'PanelButtonsLayout
        '
        Me.PanelButtonsLayout.BackColor = System.Drawing.Color.Transparent
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_Plan)
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_KatAbtBereichPlan)
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_AbtBereichPlan)
        Me.PanelButtonsLayout.Location = New System.Drawing.Point(122, 124)
        Me.PanelButtonsLayout.Name = "PanelButtonsLayout"
        Me.PanelButtonsLayout.Size = New System.Drawing.Size(325, 23)
        Me.PanelButtonsLayout.TabIndex = 0
        '
        'btnLayout_Plan
        '
        Me.btnLayout_Plan.AcceptsFocus = False
        Appearance4.AlphaLevel = CType(255, Short)
        Appearance4.FontData.SizeInPoints = 8.0!
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance4.TextHAlignAsString = "Left"
        Me.btnLayout_Plan.Appearance = Appearance4
        Me.btnLayout_Plan.AutoSize = True
        Me.btnLayout_Plan.AutoWorkLayout = False
        Me.btnLayout_Plan.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_Plan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_Plan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_Plan.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_Plan.IsStandardControl = False
        Me.btnLayout_Plan.Location = New System.Drawing.Point(285, 0)
        Me.btnLayout_Plan.Name = "btnLayout_Plan"
        Me.btnLayout_Plan.ShowFocusRect = False
        Me.btnLayout_Plan.ShowOutline = False
        Me.btnLayout_Plan.Size = New System.Drawing.Size(28, 23)
        Me.btnLayout_Plan.TabIndex = 3
        Me.btnLayout_Plan.Tag = "Plan"
        Me.btnLayout_Plan.Text = "Plan"
        Me.btnLayout_Plan.UseAppStyling = False
        Me.btnLayout_Plan.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_Plan.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_Plan.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnLayout_KatAbtBereichPlan
        '
        Me.btnLayout_KatAbtBereichPlan.AcceptsFocus = False
        Appearance5.AlphaLevel = CType(255, Short)
        Appearance5.FontData.SizeInPoints = 8.0!
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance5.TextHAlignAsString = "Left"
        Me.btnLayout_KatAbtBereichPlan.Appearance = Appearance5
        Me.btnLayout_KatAbtBereichPlan.AutoSize = True
        Me.btnLayout_KatAbtBereichPlan.AutoWorkLayout = False
        Me.btnLayout_KatAbtBereichPlan.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_KatAbtBereichPlan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_KatAbtBereichPlan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_KatAbtBereichPlan.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_KatAbtBereichPlan.IsStandardControl = False
        Me.btnLayout_KatAbtBereichPlan.Location = New System.Drawing.Point(117, 0)
        Me.btnLayout_KatAbtBereichPlan.Name = "btnLayout_KatAbtBereichPlan"
        Me.btnLayout_KatAbtBereichPlan.ShowFocusRect = False
        Me.btnLayout_KatAbtBereichPlan.ShowOutline = False
        Me.btnLayout_KatAbtBereichPlan.Size = New System.Drawing.Size(168, 23)
        Me.btnLayout_KatAbtBereichPlan.TabIndex = 2
        Me.btnLayout_KatAbtBereichPlan.Tag = "KatAbtBereichPlan"
        Me.btnLayout_KatAbtBereichPlan.Text = "Kategorie/Abteilung/Bereich/Plan"
        Me.btnLayout_KatAbtBereichPlan.UseAppStyling = False
        Me.btnLayout_KatAbtBereichPlan.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_KatAbtBereichPlan.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_KatAbtBereichPlan.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnLayout_AbtBereichPlan
        '
        Me.btnLayout_AbtBereichPlan.AcceptsFocus = False
        Appearance6.AlphaLevel = CType(255, Short)
        Appearance6.FontData.SizeInPoints = 8.0!
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance6.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance6.TextHAlignAsString = "Left"
        Me.btnLayout_AbtBereichPlan.Appearance = Appearance6
        Me.btnLayout_AbtBereichPlan.AutoSize = True
        Me.btnLayout_AbtBereichPlan.AutoWorkLayout = False
        Me.btnLayout_AbtBereichPlan.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_AbtBereichPlan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_AbtBereichPlan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_AbtBereichPlan.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_AbtBereichPlan.IsStandardControl = False
        Me.btnLayout_AbtBereichPlan.Location = New System.Drawing.Point(0, 0)
        Me.btnLayout_AbtBereichPlan.Name = "btnLayout_AbtBereichPlan"
        Me.btnLayout_AbtBereichPlan.ShowFocusRect = False
        Me.btnLayout_AbtBereichPlan.ShowOutline = False
        Me.btnLayout_AbtBereichPlan.Size = New System.Drawing.Size(117, 23)
        Me.btnLayout_AbtBereichPlan.TabIndex = 1
        Me.btnLayout_AbtBereichPlan.Tag = "AbtBereichPlan"
        Me.btnLayout_AbtBereichPlan.Text = "Abteilung/Bereich/Plan"
        Me.btnLayout_AbtBereichPlan.UseAppStyling = False
        Me.btnLayout_AbtBereichPlan.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_AbtBereichPlan.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_AbtBereichPlan.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnSearch
        '
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSearch.Appearance = Appearance7
        Me.btnSearch.Location = New System.Drawing.Point(471, 118)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 34)
        Me.btnSearch.TabIndex = 100
        Me.btnSearch.Tag = "ResID.Search"
        Me.btnSearch.Text = "Suchen"
        '
        'UltraLabel1
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance8
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 127)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(63, 16)
        Me.UltraLabel1.TabIndex = 1002
        Me.UltraLabel1.Tag = "ResID.Layout"
        Me.UltraLabel1.Text = "Layout"
        '
        'lblFound
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.FontData.SizeInPoints = 7.0!
        Appearance9.TextHAlignAsString = "Right"
        Me.lblFound.Appearance = Appearance9
        Me.lblFound.AutoSize = True
        Me.lblFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFound.Location = New System.Drawing.Point(469, 155)
        Me.lblFound.Name = "lblFound"
        Me.lblFound.Size = New System.Drawing.Size(72, 12)
        Me.lblFound.TabIndex = 501
        Me.lblFound.Tag = ""
        Me.lblFound.Text = "Gefunden: 1345"
        '
        'lblStatus
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblStatus.Appearance = Appearance10
        Me.lblStatus.Location = New System.Drawing.Point(9, 76)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 16)
        Me.lblStatus.TabIndex = 498
        Me.lblStatus.Tag = "ResID.Status"
        Me.lblStatus.Text = "Status"
        '
        'optStatus
        '
        Me.optStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optStatus.CheckedIndex = 0
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = "Open"
        ValueListItem1.DisplayText = "Offen"
        ValueListItem1.Tag = "ResID.Openly"
        ValueListItem2.DataValue = "Completed"
        ValueListItem2.DisplayText = "Erledigt"
        ValueListItem2.Tag = "ResID.Completed"
        ValueListItem5.DataValue = "Failed"
        ValueListItem5.DisplayText = "Erfolglos"
        ValueListItem5.Tag = "ResID.Failed"
        ValueListItem4.DataValue = "Canceled"
        ValueListItem4.DisplayText = "Storniert"
        ValueListItem4.Tag = "ResID.Canceled"
        ValueListItem3.DataValue = "All"
        ValueListItem3.DisplayText = "Alle"
        ValueListItem3.Tag = "ResID.All"
        Me.optStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem5, ValueListItem4, ValueListItem3})
        Me.optStatus.Location = New System.Drawing.Point(125, 76)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(416, 15)
        Me.optStatus.TabIndex = 3
        Me.optStatus.Text = "Offen"
        '
        'UDateBis
        '
        Appearance11.BackColor = System.Drawing.Color.White
        Me.UDateBis.Appearance = Appearance11
        Me.UDateBis.BackColor = System.Drawing.Color.White
        Me.UDateBis.DateTime = New Date(2008, 11, 3, 0, 0, 0, 0)
        Me.UDateBis.Location = New System.Drawing.Point(272, 47)
        Me.UDateBis.Name = "UDateBis"
        Me.UDateBis.Size = New System.Drawing.Size(91, 21)
        Me.UDateBis.TabIndex = 2
        Me.UDateBis.Value = New Date(2008, 11, 3, 0, 0, 0, 0)
        '
        'UDateVon
        '
        Appearance12.BackColor = System.Drawing.Color.White
        Me.UDateVon.Appearance = Appearance12
        Me.UDateVon.BackColor = System.Drawing.Color.White
        Me.UDateVon.DateTime = New Date(2008, 11, 3, 0, 0, 0, 0)
        Me.UDateVon.Location = New System.Drawing.Point(125, 47)
        Me.UDateVon.Name = "UDateVon"
        Me.UDateVon.Size = New System.Drawing.Size(91, 21)
        Me.UDateVon.TabIndex = 1
        Me.UDateVon.Value = New Date(2008, 11, 3, 0, 0, 0, 0)
        '
        'txtBetreff2
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackColorDisabled = System.Drawing.Color.White
        Appearance13.BackColorDisabled2 = System.Drawing.Color.White
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.ItalicAsString = "False"
        Appearance13.FontData.Name = "Microsoft Sans Serif"
        Appearance13.FontData.SizeInPoints = 8.25!
        Appearance13.FontData.StrikeoutAsString = "False"
        Appearance13.FontData.UnderlineAsString = "False"
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBetreff2.Appearance = Appearance13
        Me.txtBetreff2.AutoSize = False
        Me.txtBetreff2.BackColor = System.Drawing.Color.White
        Me.txtBetreff2.Location = New System.Drawing.Point(168, 19)
        Me.txtBetreff2.MaxLength = 0
        Me.txtBetreff2.Name = "txtBetreff2"
        Me.txtBetreff2.Size = New System.Drawing.Size(375, 23)
        Me.txtBetreff2.TabIndex = 488
        Me.txtBetreff2.Tag = "Vorname"
        '
        'lblBetreff
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblBetreff.Appearance = Appearance14
        Me.lblBetreff.Location = New System.Drawing.Point(125, 22)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(38, 16)
        Me.lblBetreff.TabIndex = 0
        Me.lblBetreff.Tag = "ResID.Subject"
        Me.lblBetreff.Text = "Betreff"
        '
        'dropDownCategories
        '
        Appearance15.BorderColor = System.Drawing.Color.Black
        Appearance15.TextHAlignAsString = "Left"
        Me.dropDownCategories.Appearance = Appearance15
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(9, 18)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(110, 24)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 6
        Me.dropDownCategories.TabStop = False
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'lblBeginntZwischen
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextVAlignAsString = "Middle"
        Me.lblBeginntZwischen.Appearance = Appearance16
        Me.lblBeginntZwischen.Location = New System.Drawing.Point(9, 49)
        Me.lblBeginntZwischen.Name = "lblBeginntZwischen"
        Me.lblBeginntZwischen.Size = New System.Drawing.Size(100, 16)
        Me.lblBeginntZwischen.TabIndex = 390
        Me.lblBeginntZwischen.Tag = "ResID.BeginntZwischen"
        Me.lblBeginntZwischen.Text = "Beginnt zwischen"
        '
        'lblAnd
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Center"
        Appearance17.TextVAlignAsString = "Middle"
        Me.lblAnd.Appearance = Appearance17
        Me.lblAnd.Location = New System.Drawing.Point(225, 49)
        Me.lblAnd.Name = "lblAnd"
        Me.lblAnd.Size = New System.Drawing.Size(35, 16)
        Me.lblAnd.TabIndex = 389
        Me.lblAnd.Tag = "ResID.und"
        Me.lblAnd.Text = "und"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.ForeColor = System.Drawing.Color.Black
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnPrint.Appearance = Appearance18
        Me.btnPrint.Location = New System.Drawing.Point(1034, 140)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 31)
        Me.btnPrint.TabIndex = 1003
        Me.btnPrint.Tag = "ResID.Print"
        Me.btnPrint.Text = "Drucken"
        '
        'btnAdd2
        '
        Me.btnAdd2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.Cursor = System.Windows.Forms.Cursors.Default
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        Me.btnAdd2.Appearance = Appearance19
        Me.btnAdd2.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnAdd2.Location = New System.Drawing.Point(1086, 16)
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.Size = New System.Drawing.Size(30, 29)
        Me.btnAdd2.TabIndex = 200
        UltraToolTipInfo1.Tag = "ResID.AddPlan"
        UltraToolTipInfo1.ToolTipText = "Neuen Planungseintrag erstellen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd2, UltraToolTipInfo1)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.btnPrint)
        Me.PanelTop.Controls.Add(Me.btnAdd2)
        Me.PanelTop.Controls.Add(Me.grpSearch)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1125, 175)
        Me.PanelTop.TabIndex = 70
        '
        'PanelCenter
        '
        Me.PanelCenter.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenter.Controls.Add(Me.ContPlanungDataBereich1)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 175)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(1125, 415)
        Me.PanelCenter.TabIndex = 72
        '
        'ContPlanungDataBereich1
        '
        Me.ContPlanungDataBereich1.BackColor = System.Drawing.Color.White
        Me.ContPlanungDataBereich1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContPlanungDataBereich1.Location = New System.Drawing.Point(0, 0)
        Me.ContPlanungDataBereich1.Name = "ContPlanungDataBereich1"
        Me.ContPlanungDataBereich1.Size = New System.Drawing.Size(1125, 415)
        Me.ContPlanungDataBereich1.TabIndex = 1
        '
        'contPlanung2Bereich
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelCenter)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.Name = "contPlanung2Bereich"
        Me.Size = New System.Drawing.Size(1125, 590)
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.PanelButtonsLayout.ResumeLayout(False)
        Me.PanelButtonsLayout.PerformLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBetreff2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public isLoaded As Boolean = False
    Public initFormDone As Boolean = False
    Public IsInitializedVisible As Boolean = False
    Public _lastQuickbutton As String = ""

    Public gen As New General
    Public PMDSMainWindow As Control = Nothing
    Public doUI1 As New doUI()

    Public Enum eTypActionRow
        delete = 0
        erledigt = 1
        offen = 2
        save = 3
        send = 6
    End Enum

    Public contSelectSelListCategories As New contSelectSelList()
    Public contSelectSelListBerufsgruppen As New contSelectSelList()
    Public contSelectAbtBereiche As New contSelectAbteilBereiche()
    Public b As New PMDS.db.PMDSBusiness()

    Public activeBackCol As System.Drawing.Color = System.Drawing.Color.SkyBlue
    Public activeForeCol As System.Drawing.Color = System.Drawing.Color.Black
    Public activeFrameCol As System.Drawing.Color = System.Drawing.Color.Transparent
    Public inactiveBackCol As System.Drawing.Color = System.Drawing.Color.Transparent
    Public hoverBackCol As System.Drawing.Color = System.Drawing.Color.Gainsboro

    Public Enum eLayoutGrid
        AbtBereichPlan = 0
        KategorieAbtBereichPlan = 1
        Plan = 2
    End Enum

    Public hasRightToEdit As Boolean = False








    Private Sub initControl2()
        Try
            Me.ContPlanungDataBereich1.mainWindow = Me

            Me.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)
            Me.btnAdd2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32)

            Me.contSelectSelListCategories.MainPlanBereicheSearch = Me
            Me.contSelectSelListCategories.initControl("PlanBereichCategory", True, False, Me.dropDownCategories, False, "Categories", "", True)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories
            Me.contSelectSelListCategories.setLabelCount2()
            Me.contSelectSelListCategories.Editable(True)

            Me.contSelectAbtBereiche.MainPlanBereicheSearch = Me
            Me.contSelectAbtBereiche.initControl(Me.dropDownAbteilungBereiche)
            Me.uPopupAbteilungBereiche.PopupControl = Me.contSelectAbtBereiche
            Me.dropDownAbteilungBereiche.PopupItem = Me.uPopupAbteilungBereiche
            Me.contSelectAbtBereiche.popupContMainSearch = Me.uPopupAbteilungBereiche
            'Me.contSelectAbtBereiche.treeAbtBereiche.ExpandAll(True)
            Me.contSelectAbtBereiche.setLabelCount2()

            Me.contSelectSelListBerufsgruppen.MainPlanBereicheSearch = Me
            Me.contSelectSelListBerufsgruppen.initControl("BER", True, False, Me.dropDownBerufsgruppen, True, "Berufsgruppen", "", True)
            Me.uPopupContBerufsgruppen.PopupControl = Me.contSelectSelListBerufsgruppen
            Me.dropDownBerufsgruppen.PopupItem = Me.uPopupContBerufsgruppen
            Me.contSelectSelListBerufsgruppen.popupContMainSearch = Me.uPopupContBerufsgruppen
            Me.contSelectSelListBerufsgruppen.setLabelCount2()
            Me.contSelectSelListBerufsgruppen.Editable(True)

            Me.ContPlanungDataBereich1.initControl()

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.optStatus.CheckedIndex = 0
            'Me.ContPlanungDataBereich1.SplitContainer1.Panel2Collapsed = True

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.Plan
            Me.setLayoutButton2(Me.btnLayout_Plan)

            Me.contSelectSelListCategories.setLabelCount2()
            Me.contSelectAbtBereiche.setLabelCount2()
            Me.contSelectSelListBerufsgruppen.setLabelCount2()

            Me.hasRightToEdit = PMDS.Global.ENV.HasRight([Global].UserRights.PflegePlanungAendern)
            If Not Me.hasRightToEdit Then
                Me.btnAdd2.Visible = False
                Me.ContPlanungDataBereich1.LöschenToolStripMenuItem1.Visible = False
                Me.ContPlanungDataBereich1.TermineErledigenToolStripMenuItem.Visible = False
                Me.ContPlanungDataBereich1.TermineStornierenToolStripMenuItem.Visible = False
                Me.ContPlanungDataBereich1.ToolStripMenuItemSpace1.Visible = False
                Me.ContPlanungDataBereich1.ToolStripMenuItem3.Visible = False
            End If

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub initForm2(doInit As Boolean)
        Try
            Me.initFormDone = False

            If Not Me.isLoaded Then
                Me.initControl2()
            End If

            Me.zurücksetzen(True)

            Me.UDateVon.Value = Now
            Me.UDateBis.Value = Now

            PMDSBusinessComm.checkCommAsyncForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll)
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsrLoggedOn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)
                Dim IDFoundInTree2 As Boolean = False
                IDFoundInTree2 = False

                Me.resetLayoutButtons()
                Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.Plan
                Me.setLayoutButton2(Me.btnLayout_Plan)
            End Using

            Me.contSelectSelListCategories.setSelectionOnOff(True)
            Me.contSelectSelListCategories.setLabelCount2()

            Me.ContPlanungDataBereich1.search(doInit, False, True)

            If doInit Then
                Me.contSelectSelListCategories.setLabelCount2()
                Me.contSelectAbtBereiche.setLabelCount2()
                Me.contSelectSelListBerufsgruppen.setLabelCount2()
            End If

            Me.initFormDone = True

        Catch ex As Exception
            Me.initFormDone = True
            Throw New Exception("contPlanung2Bereich.initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub zurücksetzen(ByVal alles As Boolean)
        Try
            Me.txtBetreff2.Text = ""
            If alles Then
                Me.optStatus.CheckedIndex = 0
            End If

            Me.setAzahl_buttSuchen(0)
            Me.ContPlanungDataBereich1.DsPlanSearch1.Clear()
            Me.ContPlanungDataBereich1.clear()

            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.contSelectAbtBereiche.setSelectionOnOff(CheckState.Unchecked)
            Me.contSelectSelListBerufsgruppen.setSelectionOnOff(False)

            Me.lblFound.Text = ""

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.zurücksetzen: " + ex.ToString())
        End Try
    End Sub

    Private Sub contPlanungMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Function getStatus() As String
        Try

            Select Case Me.optStatus.Value.ToString().ToLower().Trim()
                Case "open"
                    Return "Offen"
                Case "completed"
                    Return "Erledigt"
                Case "failed"
                    Return "Erfolglos"
                Case "canceled"
                    Return "Storniert"
                Case Else
                    Return ""
            End Select

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.getStatus: " + ex.ToString())
        End Try
    End Function
    Public Sub setAzahl_buttSuchen(ByVal anz As Integer)
        Try


        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.setAzahl_buttSuchen: " + ex.ToString())
        End Try
    End Sub

    Public Sub setLayoutButton2(btn As UltraButton)
        Try
            PMDS.Global.UIGlobal.setAktiv(btn, -1, activeForeCol, activeFrameCol, activeBackCol)
            Me._lastQuickbutton = btn.Tag.ToString().Trim()

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.setLayoutButton: " + ex.ToString())
        End Try
    End Sub
    Public Sub resetLayoutButtons()
        Try
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_AbtBereichPlan, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_KatAbtBereichPlan, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_Plan, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.resetLayoutButtons: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.newPlan()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub newPlan()
        Try
            Dim frmNachrichtBereich1 As frmNachrichtBereich = Me.ContPlanungDataBereich1.getFreeFormPlanBereich()
            frmNachrichtBereich1.modalWindow = Me
            frmNachrichtBereich1.initControl()
            frmNachrichtBereich1.IsNew = True
            frmNachrichtBereich1.IDPlanBereich = Nothing
            frmNachrichtBereich1.Visible = True
            frmNachrichtBereich1.Show()

        Catch ex As Exception
            Throw New Exception("contPlanung2Bereich.newPlan: " + ex.ToString())
        End Try
    End Sub

    Private Sub contPlanung_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Me.ContPlanungDataBereich1.initTxtControl()

                Dim newRessourcesAdded As Integer = 0
                Me.ContPlanungDataBereich1.gridPlans.Rows.ExpandAll(True)
                'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
                Me.IsInitializedVisible = True
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.search(False, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dropDownCategories_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownCategories.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownCategories_ClosedUp(sender As Object, e As EventArgs) Handles dropDownCategories.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contSelectSelListCategories.setLabelCount2()
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.print()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UDateVon_ValueChanged(sender As Object, e As EventArgs) Handles UDateVon.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UDateVon.Visible And Me.initFormDone Then
                Me.ContPlanungDataBereich1.search(False, False, True)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UDateBis_ValueChanged(sender As Object, e As EventArgs) Handles UDateBis.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UDateBis.Visible And Me.initFormDone Then
                Me.ContPlanungDataBereich1.search(False, False, True)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtBetreff2_ValueChanged(sender As Object, e As EventArgs) Handles txtBetreff2.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.txtBetreff2.Focused Then
                Me.ContPlanungDataBereich1.search(False, False, True)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub optStatus_ValueChanged(sender As Object, e As EventArgs) Handles optStatus.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.optStatus.Focused Then
                Me.ContPlanungDataBereich1.search(False, False, True)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnLayout_AbtBereichPlan_Click(sender As Object, e As EventArgs) Handles btnLayout_AbtBereichPlan.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.AbtBereichPlan
            Me.setLayoutButton2(Me.btnLayout_AbtBereichPlan)
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnLayout_KatAbtBereichPlan_Click(sender As Object, e As EventArgs) Handles btnLayout_KatAbtBereichPlan.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.KategorieAbtBereichPlan
            Me.setLayoutButton2(Me.btnLayout_KatAbtBereichPlan)
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnLayout_Plan_Click(sender As Object, e As EventArgs) Handles btnLayout_Plan.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.Plan
            Me.setLayoutButton2(Me.btnLayout_Plan)
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownAbteilungBereiche_ClosedUp(sender As Object, e As EventArgs) Handles dropDownAbteilungBereiche.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contSelectAbtBereiche.setLabelCount2()
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownBerufsgruppen_ClosedUp(sender As Object, e As EventArgs) Handles dropDownBerufsgruppen.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contSelectSelListBerufsgruppen.setLabelCount2()
            Me.ContPlanungDataBereich1.search(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
