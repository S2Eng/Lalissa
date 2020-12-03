Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win
Imports PMDS.Global.db.ERSystem


Public Class frmNachrichtBereich
    Inherits System.Windows.Forms.Form

    Public IsNew As Boolean = True
    Public IDPlanBereich As Nullable(Of Guid) = Nothing
    Public isLoaded As Boolean = False
    Public abort As Boolean = True
    Public rPlan As dsPlan.planRow

    Public isEditable As Boolean = False


    Public compPlan1 As New compPlan()
    Public dsPlan1 As New dsPlan()

    Private General As New General
    Public modalWindow As contPlanung2

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public genMain As New General()

    Public clPlan1 As New clPlan()
    Public doUI1 As New doUI()

    Public doEditor1 As New QS2.Desktop.Txteditor.doEditor()
    Public b As New PMDS.db.PMDSBusiness()
    Public contTxtEditor1 As New QS2.Desktop.Txteditor.contTxtEditor()


    Public contSelectSelListCategories As New contSelectSelList()






#Region "initCodeAuto"
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents cboPriorität As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents toolbarsManagerText As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents lblStartAt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblErstelltVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblErstelltAm As Infragistics.Win.Misc.UltraLabel
    Public WithEvents optStatus As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents dteEndetAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblEndAt As Infragistics.Win.Misc.UltraLabel
    Public WithEvents iNTenMonat As QS2.Desktop.ControlManagment.BaseMaskEdit
    Private WithEvents lblTagWochenMonatnTen As QS2.Desktop.ControlManagment.BaseLabel
    Public WithEvents iWiedWertJeden As QS2.Desktop.ControlManagment.BaseMaskEdit
    Public WithEvents chkGanzerTag As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents grpSerientermin As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpWochentage As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents cboDauer As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents chkIsSerientermin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents optSerienterminType As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents opTagWochenMonat As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents cbSo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbSa As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbFr As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbDo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbMi As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbDi As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbMo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents dteSerienterminEndetAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblSerienterminEnde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblStatus As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbkPriorität As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboDauerSerientermin As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents PanelDescription As Panel
    Friend WithEvents PanelBetreff As Panel
    Public WithEvents txtBetreff As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblBetreff As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelBody As Panel
    Friend WithEvents PanelTxtEditor As Panel
    Friend WithEvents PanelSerientermineUISub As Panel
    Friend WithEvents EditorTmp1 As TXTextControl.TextControl
    Friend WithEvents PanelEditor As Panel



#End Region

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
    Public WithEvents dteBeginntAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffEditor")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffEditor")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.toolbarsManagerText = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.lblStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.chkIsSerientermin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cboDauer = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.grpSerientermin = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelSerientermineUISub = New System.Windows.Forms.Panel()
        Me.optSerienterminType = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.iNTenMonat = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.lblTagWochenMonatnTen = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.grpWochentage = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cbSo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbSa = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbFr = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.iWiedWertJeden = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.opTagWochenMonat = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.cboDauerSerientermin = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.dteSerienterminEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblSerienterminEnde = New Infragistics.Win.Misc.UltraLabel()
        Me.chkGanzerTag = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.dteEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblEndAt = New Infragistics.Win.Misc.UltraLabel()
        Me.lblErstelltVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblErstelltAm = New Infragistics.Win.Misc.UltraLabel()
        Me.dteBeginntAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblStartAt = New Infragistics.Win.Misc.UltraLabel()
        Me.cboPriorität = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lbkPriorität = New Infragistics.Win.Misc.UltraLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.PanelBetreff = New System.Windows.Forms.Panel()
        Me.txtBetreff = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBetreff = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelDescription = New System.Windows.Forms.Panel()
        Me.PanelEditor = New System.Windows.Forms.Panel()
        Me.EditorTmp1 = New TXTextControl.TextControl()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanelTxtEditor = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSerientermin.SuspendLayout()
        Me.PanelSerientermineUISub.SuspendLayout()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpWochentage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpWochentage.SuspendLayout()
        CType(Me.cbSo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.opTagWochenMonat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDauerSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelBetreff.SuspendLayout()
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDescription.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraPanel1)
        Me.Panel1.Location = New System.Drawing.Point(766, 177)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 30)
        Me.Panel1.TabIndex = 0
        '
        'UltraPanel1
        '
        Me.UltraPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(562, 30)
        Me.UltraPanel1.TabIndex = 0
        '
        'toolbarsManagerText
        '
        Me.toolbarsManagerText.DesignerFlags = 1
        Me.toolbarsManagerText.LockToolbars = True
        Me.toolbarsManagerText.OptionSets.Add(OptionSet1)
        Me.toolbarsManagerText.ShowFullMenusDelay = 500
        Me.toolbarsManagerText.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        StateButtonTool4.Checked = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool3, StateButtonTool4})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.toolbarsManagerText.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        StateButtonTool1.OptionSetKey = "lblOnOffEditor"
        StateButtonTool1.SharedPropsInternal.Caption = "Texteditor"
        StateButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool1.Tag = "ResID.Texteditor"
        StateButtonTool2.Checked = True
        StateButtonTool2.OptionSetKey = "lblOnOffEditor"
        StateButtonTool2.SharedPropsInternal.Caption = "Browser"
        StateButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool2.Tag = "ResID.Browser"
        LabelTool1.SharedPropsInternal.Caption = "lblOnOffEditor"
        Me.toolbarsManagerText.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool1, StateButtonTool2, LabelTool1})
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblStatus.Appearance = Appearance1
        Me.lblStatus.Location = New System.Drawing.Point(903, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(77, 17)
        Me.lblStatus.TabIndex = 504
        Me.lblStatus.Tag = "ResID.Status"
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'dropDownCategories
        '
        Appearance2.TextHAlignAsString = "Left"
        Me.dropDownCategories.Appearance = Appearance2
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(9, 7)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(154, 22)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 12
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'optStatus
        '
        Me.optStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optStatus.CheckedIndex = 0
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = 0
        ValueListItem1.DisplayText = "Offen"
        ValueListItem1.Tag = "ResID.Openly"
        ValueListItem2.DataValue = "Completed"
        ValueListItem2.DisplayText = "Erledigt"
        ValueListItem2.Tag = "ResID.Completed"
        Me.optStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optStatus.Location = New System.Drawing.Point(951, 98)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(108, 17)
        Me.optStatus.TabIndex = 4
        Me.optStatus.Text = "Offen"
        Me.optStatus.Visible = False
        '
        'chkIsSerientermin
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkIsSerientermin.Appearance = Appearance3
        Me.chkIsSerientermin.BackColor = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIsSerientermin.Location = New System.Drawing.Point(421, 7)
        Me.chkIsSerientermin.Name = "chkIsSerientermin"
        Me.chkIsSerientermin.Size = New System.Drawing.Size(90, 11)
        Me.chkIsSerientermin.TabIndex = 20
        Me.chkIsSerientermin.Tag = "ResID.Serientermin"
        Me.chkIsSerientermin.Text = "Serientermin"
        UltraToolTipInfo2.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo2.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkIsSerientermin, UltraToolTipInfo2)
        Me.chkIsSerientermin.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkIsSerientermin.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'cboDauer
        '
        Me.cboDauer.Location = New System.Drawing.Point(219, 40)
        Me.cboDauer.Name = "cboDauer"
        Me.cboDauer.Size = New System.Drawing.Size(103, 21)
        Me.cboDauer.TabIndex = 3
        '
        'grpSerientermin
        '
        Me.grpSerientermin.Controls.Add(Me.PanelSerientermineUISub)
        Me.grpSerientermin.Controls.Add(Me.cboDauerSerientermin)
        Me.grpSerientermin.Controls.Add(Me.dteSerienterminEndetAm)
        Me.grpSerientermin.Controls.Add(Me.lblSerienterminEnde)
        Me.grpSerientermin.Location = New System.Drawing.Point(412, 19)
        Me.grpSerientermin.Name = "grpSerientermin"
        Me.grpSerientermin.Size = New System.Drawing.Size(457, 96)
        Me.grpSerientermin.TabIndex = 21
        Me.grpSerientermin.Tag = ""
        Me.grpSerientermin.Visible = False
        '
        'PanelSerientermineUISub
        '
        Me.PanelSerientermineUISub.BackColor = System.Drawing.Color.Transparent
        Me.PanelSerientermineUISub.Controls.Add(Me.optSerienterminType)
        Me.PanelSerientermineUISub.Controls.Add(Me.iNTenMonat)
        Me.PanelSerientermineUISub.Controls.Add(Me.lblTagWochenMonatnTen)
        Me.PanelSerientermineUISub.Controls.Add(Me.grpWochentage)
        Me.PanelSerientermineUISub.Controls.Add(Me.iWiedWertJeden)
        Me.PanelSerientermineUISub.Controls.Add(Me.opTagWochenMonat)
        Me.PanelSerientermineUISub.Location = New System.Drawing.Point(8, 30)
        Me.PanelSerientermineUISub.Name = "PanelSerientermineUISub"
        Me.PanelSerientermineUISub.Size = New System.Drawing.Size(443, 60)
        Me.PanelSerientermineUISub.TabIndex = 506
        '
        'optSerienterminType
        '
        Me.optSerienterminType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optSerienterminType.CheckedIndex = 0
        ValueListItem3.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem3.DataValue = 1
        ValueListItem3.DisplayText = "täglich"
        ValueListItem3.Tag = "ResID.täglich"
        ValueListItem4.DataValue = 2
        ValueListItem4.DisplayText = "alle"
        ValueListItem4.Tag = "ResID.alle6"
        ValueListItem5.DataValue = 3
        ValueListItem5.DisplayText = "jeden"
        ValueListItem5.Tag = "ResID.jeden"
        Me.optSerienterminType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4, ValueListItem5})
        Me.optSerienterminType.ItemSpacingVertical = 4
        Me.optSerienterminType.Location = New System.Drawing.Point(2, 1)
        Me.optSerienterminType.Name = "optSerienterminType"
        Me.optSerienterminType.Size = New System.Drawing.Size(55, 55)
        Me.optSerienterminType.TabIndex = 1
        Me.optSerienterminType.Text = "täglich"
        '
        'iNTenMonat
        '
        Appearance11.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.iNTenMonat.Appearance = Appearance11
        Me.iNTenMonat.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iNTenMonat.InputMask = "nnn"
        Me.iNTenMonat.Location = New System.Drawing.Point(75, 37)
        Me.iNTenMonat.MaxValue = CType(31, Short)
        Me.iNTenMonat.MinValue = CType(1, Short)
        Me.iNTenMonat.Name = "iNTenMonat"
        Me.iNTenMonat.NonAutoSizeHeight = 20
        Me.iNTenMonat.Size = New System.Drawing.Size(35, 20)
        Me.iNTenMonat.TabIndex = 4
        Me.iNTenMonat.Text = "                   "
        '
        'lblTagWochenMonatnTen
        '
        Appearance12.FontData.SizeInPoints = 8.0!
        Me.lblTagWochenMonatnTen.Appearance = Appearance12
        Me.lblTagWochenMonatnTen.AutoSize = True
        Me.lblTagWochenMonatnTen.Location = New System.Drawing.Point(116, 41)
        Me.lblTagWochenMonatnTen.Name = "lblTagWochenMonatnTen"
        Me.lblTagWochenMonatnTen.Size = New System.Drawing.Size(82, 14)
        Me.lblTagWochenMonatnTen.TabIndex = 500
        Me.lblTagWochenMonatnTen.Tag = "ResID.TenDesMonats"
        Me.lblTagWochenMonatnTen.Text = ".ten des Monats"
        '
        'grpWochentage
        '
        Appearance13.BackColorDisabled = System.Drawing.Color.White
        Me.grpWochentage.Appearance = Appearance13
        Me.grpWochentage.Controls.Add(Me.cbSo)
        Me.grpWochentage.Controls.Add(Me.cbSa)
        Me.grpWochentage.Controls.Add(Me.cbFr)
        Me.grpWochentage.Controls.Add(Me.cbDo)
        Me.grpWochentage.Controls.Add(Me.cbMi)
        Me.grpWochentage.Controls.Add(Me.cbDi)
        Me.grpWochentage.Controls.Add(Me.cbMo)
        Me.grpWochentage.Location = New System.Drawing.Point(288, 2)
        Me.grpWochentage.Name = "grpWochentage"
        Me.grpWochentage.Size = New System.Drawing.Size(153, 57)
        Me.grpWochentage.TabIndex = 5
        Me.grpWochentage.Tag = "ResID.Wochentage"
        Me.grpWochentage.Text = "Wochentage"
        Me.grpWochentage.UseAppStyling = False
        '
        'cbSo
        '
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.cbSo.Appearance = Appearance14
        Me.cbSo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSo.Location = New System.Drawing.Point(126, 16)
        Me.cbSo.Name = "cbSo"
        Me.cbSo.Size = New System.Drawing.Size(24, 34)
        Me.cbSo.TabIndex = 13
        Me.cbSo.Text = "So"
        '
        'cbSa
        '
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.cbSa.Appearance = Appearance15
        Me.cbSa.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSa.Location = New System.Drawing.Point(106, 16)
        Me.cbSa.Name = "cbSa"
        Me.cbSa.Size = New System.Drawing.Size(24, 34)
        Me.cbSa.TabIndex = 12
        Me.cbSa.Text = "Sa"
        '
        'cbFr
        '
        Appearance16.TextHAlignAsString = "Center"
        Appearance16.TextVAlignAsString = "Middle"
        Me.cbFr.Appearance = Appearance16
        Me.cbFr.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbFr.Location = New System.Drawing.Point(86, 16)
        Me.cbFr.Name = "cbFr"
        Me.cbFr.Size = New System.Drawing.Size(24, 34)
        Me.cbFr.TabIndex = 11
        Me.cbFr.Text = "Fr"
        '
        'cbDo
        '
        Appearance17.TextHAlignAsString = "Center"
        Appearance17.TextVAlignAsString = "Middle"
        Me.cbDo.Appearance = Appearance17
        Me.cbDo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDo.Location = New System.Drawing.Point(66, 16)
        Me.cbDo.Name = "cbDo"
        Me.cbDo.Size = New System.Drawing.Size(24, 34)
        Me.cbDo.TabIndex = 10
        Me.cbDo.Text = "Do"
        '
        'cbMi
        '
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        Me.cbMi.Appearance = Appearance18
        Me.cbMi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMi.Location = New System.Drawing.Point(46, 16)
        Me.cbMi.Name = "cbMi"
        Me.cbMi.Size = New System.Drawing.Size(24, 34)
        Me.cbMi.TabIndex = 9
        Me.cbMi.Text = "Mi"
        '
        'cbDi
        '
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        Me.cbDi.Appearance = Appearance19
        Me.cbDi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDi.Location = New System.Drawing.Point(26, 16)
        Me.cbDi.Name = "cbDi"
        Me.cbDi.Size = New System.Drawing.Size(24, 34)
        Me.cbDi.TabIndex = 8
        Me.cbDi.Text = "Di"
        '
        'cbMo
        '
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        Me.cbMo.Appearance = Appearance20
        Me.cbMo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMo.Location = New System.Drawing.Point(6, 16)
        Me.cbMo.Name = "cbMo"
        Me.cbMo.Size = New System.Drawing.Size(24, 34)
        Me.cbMo.TabIndex = 7
        Me.cbMo.Text = "Mo"
        '
        'iWiedWertJeden
        '
        Appearance21.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Me.iWiedWertJeden.Appearance = Appearance21
        Me.iWiedWertJeden.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iWiedWertJeden.InputMask = "nnn"
        Me.iWiedWertJeden.Location = New System.Drawing.Point(75, 16)
        Me.iWiedWertJeden.MaxValue = 1000
        Me.iWiedWertJeden.MinValue = 1
        Me.iWiedWertJeden.Name = "iWiedWertJeden"
        Me.iWiedWertJeden.NonAutoSizeHeight = 20
        Me.iWiedWertJeden.Size = New System.Drawing.Size(35, 20)
        Me.iWiedWertJeden.TabIndex = 2
        Me.iWiedWertJeden.Text = "                 "
        '
        'opTagWochenMonat
        '
        Appearance22.BackColorDisabled = System.Drawing.Color.White
        Me.opTagWochenMonat.Appearance = Appearance22
        Me.opTagWochenMonat.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.opTagWochenMonat.CheckedIndex = 0
        ValueListItem6.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem6.DataValue = 0
        ValueListItem6.DisplayText = "Tage"
        ValueListItem6.Tag = "ResID.Tage"
        ValueListItem7.DataValue = 1
        ValueListItem7.DisplayText = "Wochen"
        ValueListItem7.Tag = "ResID.Wochen"
        ValueListItem8.DataValue = 2
        ValueListItem8.DisplayText = "Monate"
        ValueListItem8.Tag = "ResID.Monate"
        Me.opTagWochenMonat.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem6, ValueListItem7, ValueListItem8})
        Me.opTagWochenMonat.Location = New System.Drawing.Point(116, 19)
        Me.opTagWochenMonat.Name = "opTagWochenMonat"
        Me.opTagWochenMonat.Size = New System.Drawing.Size(168, 15)
        Me.opTagWochenMonat.TabIndex = 3
        Me.opTagWochenMonat.Text = "Tage"
        '
        'cboDauerSerientermin
        '
        Me.cboDauerSerientermin.Location = New System.Drawing.Point(180, 7)
        Me.cboDauerSerientermin.Name = "cboDauerSerientermin"
        Me.cboDauerSerientermin.Size = New System.Drawing.Size(93, 21)
        Me.cboDauerSerientermin.TabIndex = 506
        '
        'dteSerienterminEndetAm
        '
        Appearance23.BackColor = System.Drawing.Color.White
        Appearance23.BackColor2 = System.Drawing.Color.White
        Appearance23.BackColorDisabled = System.Drawing.Color.White
        Appearance23.BackColorDisabled2 = System.Drawing.Color.White
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.FontData.ItalicAsString = "False"
        Appearance23.FontData.Name = "Microsoft Sans Serif"
        Appearance23.FontData.SizeInPoints = 8.25!
        Appearance23.FontData.StrikeoutAsString = "False"
        Appearance23.FontData.UnderlineAsString = "False"
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteSerienterminEndetAm.Appearance = Appearance23
        Me.dteSerienterminEndetAm.BackColor = System.Drawing.Color.White
        Me.dteSerienterminEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteSerienterminEndetAm.Location = New System.Drawing.Point(81, 7)
        Me.dteSerienterminEndetAm.MaskInput = "{date}"
        Me.dteSerienterminEndetAm.Name = "dteSerienterminEndetAm"
        Me.dteSerienterminEndetAm.Size = New System.Drawing.Size(93, 21)
        Me.dteSerienterminEndetAm.TabIndex = 0
        Me.dteSerienterminEndetAm.Value = Nothing
        '
        'lblSerienterminEnde
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.ForeColorDisabled = System.Drawing.Color.Black
        Appearance24.TextVAlignAsString = "Middle"
        Me.lblSerienterminEnde.Appearance = Appearance24
        Me.lblSerienterminEnde.Location = New System.Drawing.Point(8, 9)
        Me.lblSerienterminEnde.Name = "lblSerienterminEnde"
        Me.lblSerienterminEnde.Size = New System.Drawing.Size(67, 17)
        Me.lblSerienterminEnde.TabIndex = 505
        Me.lblSerienterminEnde.Tag = "ResID.plan.EndetAm"
        Me.lblSerienterminEnde.Text = "Endet am"
        '
        'chkGanzerTag
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Appearance26.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance26.ForeColor = System.Drawing.Color.Black
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Appearance26.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkGanzerTag.Appearance = Appearance26
        Me.chkGanzerTag.BackColor = System.Drawing.Color.Transparent
        Me.chkGanzerTag.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGanzerTag.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGanzerTag.Location = New System.Drawing.Point(220, 14)
        Me.chkGanzerTag.Name = "chkGanzerTag"
        Me.chkGanzerTag.Size = New System.Drawing.Size(88, 18)
        Me.chkGanzerTag.TabIndex = 1
        Me.chkGanzerTag.Tag = "ResID.GanzerTag"
        Me.chkGanzerTag.Text = "Ganzer Tag"
        UltraToolTipInfo1.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo1.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkGanzerTag, UltraToolTipInfo1)
        Me.chkGanzerTag.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkGanzerTag.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'dteEndetAm
        '
        Appearance27.BackColor = System.Drawing.Color.White
        Appearance27.BackColor2 = System.Drawing.Color.White
        Appearance27.BackColorDisabled = System.Drawing.Color.White
        Appearance27.BackColorDisabled2 = System.Drawing.Color.White
        Appearance27.FontData.BoldAsString = "False"
        Appearance27.FontData.ItalicAsString = "False"
        Appearance27.FontData.Name = "Microsoft Sans Serif"
        Appearance27.FontData.SizeInPoints = 8.25!
        Appearance27.FontData.StrikeoutAsString = "False"
        Appearance27.FontData.UnderlineAsString = "False"
        Appearance27.ForeColor = System.Drawing.Color.Black
        Appearance27.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteEndetAm.Appearance = Appearance27
        Me.dteEndetAm.BackColor = System.Drawing.Color.White
        Me.dteEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteEndetAm.Location = New System.Drawing.Point(93, 40)
        Me.dteEndetAm.MaskInput = "{date} {time}"
        Me.dteEndetAm.Name = "dteEndetAm"
        Me.dteEndetAm.Size = New System.Drawing.Size(120, 21)
        Me.dteEndetAm.TabIndex = 2
        Me.dteEndetAm.Value = Nothing
        '
        'lblEndAt
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.ForeColor = System.Drawing.Color.Black
        Appearance25.ForeColorDisabled = System.Drawing.Color.Black
        Appearance25.TextVAlignAsString = "Middle"
        Me.lblEndAt.Appearance = Appearance25
        Me.lblEndAt.Location = New System.Drawing.Point(7, 43)
        Me.lblEndAt.Name = "lblEndAt"
        Me.lblEndAt.Size = New System.Drawing.Size(78, 17)
        Me.lblEndAt.TabIndex = 503
        Me.lblEndAt.Tag = "ResID.plan.EndetAm"
        Me.lblEndAt.Text = "Endet am"
        '
        'lblErstelltVon
        '
        Me.lblErstelltVon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.FontData.SizeInPoints = 7.5!
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblErstelltVon.Appearance = Appearance10
        Me.lblErstelltVon.AutoSize = True
        Me.lblErstelltVon.Location = New System.Drawing.Point(961, 15)
        Me.lblErstelltVon.Name = "lblErstelltVon"
        Me.lblErstelltVon.Size = New System.Drawing.Size(90, 13)
        Me.lblErstelltVon.TabIndex = 421
        Me.lblErstelltVon.Tag = ""
        Me.lblErstelltVon.Text = "Erstellt von: Admin"
        Me.lblErstelltVon.Visible = False
        '
        'lblErstelltAm
        '
        Me.lblErstelltAm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.FontData.SizeInPoints = 7.5!
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblErstelltAm.Appearance = Appearance9
        Me.lblErstelltAm.AutoSize = True
        Me.lblErstelltAm.Location = New System.Drawing.Point(961, 30)
        Me.lblErstelltAm.Name = "lblErstelltAm"
        Me.lblErstelltAm.Size = New System.Drawing.Size(154, 13)
        Me.lblErstelltAm.TabIndex = 493
        Me.lblErstelltAm.Tag = ""
        Me.lblErstelltAm.Text = "Erstellt am: 2017-08-23 12:23:21"
        Me.lblErstelltAm.Visible = False
        '
        'dteBeginntAm
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackColorDisabled = System.Drawing.Color.White
        Appearance8.BackColorDisabled2 = System.Drawing.Color.White
        Appearance8.FontData.BoldAsString = "False"
        Appearance8.FontData.ItalicAsString = "False"
        Appearance8.FontData.Name = "Microsoft Sans Serif"
        Appearance8.FontData.SizeInPoints = 8.25!
        Appearance8.FontData.StrikeoutAsString = "False"
        Appearance8.FontData.UnderlineAsString = "False"
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteBeginntAm.Appearance = Appearance8
        Me.dteBeginntAm.BackColor = System.Drawing.Color.White
        Me.dteBeginntAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteBeginntAm.Location = New System.Drawing.Point(93, 13)
        Me.dteBeginntAm.MaskInput = "{date} {time}"
        Me.dteBeginntAm.Name = "dteBeginntAm"
        Me.dteBeginntAm.Size = New System.Drawing.Size(121, 21)
        Me.dteBeginntAm.TabIndex = 0
        Me.dteBeginntAm.Value = Nothing
        '
        'lblStartAt
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblStartAt.Appearance = Appearance4
        Me.lblStartAt.Location = New System.Drawing.Point(7, 15)
        Me.lblStartAt.Name = "lblStartAt"
        Me.lblStartAt.Size = New System.Drawing.Size(78, 17)
        Me.lblStartAt.TabIndex = 382
        Me.lblStartAt.Tag = "ResID.plan.BeginntAm"
        Me.lblStartAt.Text = "Beginnt am"
        '
        'cboPriorität
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackColorDisabled = System.Drawing.Color.White
        Appearance6.BackColorDisabled2 = System.Drawing.Color.White
        Appearance6.FontData.Name = "Microsoft Sans Serif"
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.Appearance = Appearance6
        Me.cboPriorität.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboPriorität.AutoSize = False
        Me.cboPriorität.BackColor = System.Drawing.Color.White
        Me.cboPriorität.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboPriorität.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColorDisabled = System.Drawing.Color.White
        Appearance7.BorderColor = System.Drawing.Color.Black
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.ItemAppearance = Appearance7
        Me.cboPriorität.Location = New System.Drawing.Point(93, 67)
        Me.cboPriorität.Name = "cboPriorität"
        Me.cboPriorität.Size = New System.Drawing.Size(81, 20)
        Me.cboPriorität.TabIndex = 5
        '
        'lbkPriorität
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Appearance5.TextVAlignAsString = "Middle"
        Me.lbkPriorität.Appearance = Appearance5
        Me.lbkPriorität.Location = New System.Drawing.Point(7, 69)
        Me.lbkPriorität.Name = "lbkPriorität"
        Me.lbkPriorität.Size = New System.Drawing.Size(77, 17)
        Me.lbkPriorität.TabIndex = 420
        Me.lbkPriorität.Tag = "ResID.Priority"
        Me.lbkPriorität.Text = "Priorität"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnAbort)
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Controls.Add(Me.btnDel)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 694)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1122, 39)
        Me.PanelBottom.TabIndex = 100
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnAbort.Appearance = Appearance30
        Me.btnAbort.Location = New System.Drawing.Point(930, 6)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(84, 26)
        Me.btnAbort.TabIndex = 103
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.ForeColor = System.Drawing.Color.Black
        Appearance31.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSave.Appearance = Appearance31
        Me.btnSave.Location = New System.Drawing.Point(1014, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 26)
        Me.btnSave.TabIndex = 104
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance32.Cursor = System.Windows.Forms.Cursors.Default
        Appearance32.TextHAlignAsString = "Center"
        Appearance32.TextVAlignAsString = "Middle"
        Me.btnDel.Appearance = Appearance32
        Me.btnDel.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnDel.Location = New System.Drawing.Point(893, 6)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(30, 26)
        Me.btnDel.TabIndex = 102
        '
        'PanelBetreff
        '
        Me.PanelBetreff.BackColor = System.Drawing.Color.Transparent
        Me.PanelBetreff.Controls.Add(Me.txtBetreff)
        Me.PanelBetreff.Controls.Add(Me.lblBetreff)
        Me.PanelBetreff.Controls.Add(Me.dropDownCategories)
        Me.PanelBetreff.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBetreff.Location = New System.Drawing.Point(0, 0)
        Me.PanelBetreff.Name = "PanelBetreff"
        Me.PanelBetreff.Size = New System.Drawing.Size(1122, 33)
        Me.PanelBetreff.TabIndex = 1
        '
        'txtBetreff
        '
        Me.txtBetreff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.BackColor2 = System.Drawing.Color.White
        Appearance28.BackColorDisabled = System.Drawing.Color.White
        Appearance28.BackColorDisabled2 = System.Drawing.Color.White
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.ItalicAsString = "False"
        Appearance28.FontData.Name = "Microsoft Sans Serif"
        Appearance28.FontData.SizeInPoints = 8.25!
        Appearance28.FontData.StrikeoutAsString = "False"
        Appearance28.FontData.UnderlineAsString = "False"
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBetreff.Appearance = Appearance28
        Me.txtBetreff.AutoSize = False
        Me.txtBetreff.BackColor = System.Drawing.Color.White
        Me.txtBetreff.Location = New System.Drawing.Point(208, 6)
        Me.txtBetreff.MaxLength = 0
        Me.txtBetreff.Name = "txtBetreff"
        Me.txtBetreff.Size = New System.Drawing.Size(808, 23)
        Me.txtBetreff.TabIndex = 0
        Me.txtBetreff.Tag = "Vorname"
        '
        'lblBetreff
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Appearance29.ForeColor = System.Drawing.Color.Black
        Appearance29.ForeColorDisabled = System.Drawing.Color.Black
        Appearance29.TextVAlignAsString = "Middle"
        Me.lblBetreff.Appearance = Appearance29
        Me.lblBetreff.Location = New System.Drawing.Point(167, 9)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(77, 17)
        Me.lblBetreff.TabIndex = 421
        Me.lblBetreff.Tag = "ResID.Subject"
        Me.lblBetreff.Text = "Betreff"
        '
        'PanelDescription
        '
        Me.PanelDescription.BackColor = System.Drawing.Color.Transparent
        Me.PanelDescription.Controls.Add(Me.optStatus)
        Me.PanelDescription.Controls.Add(Me.PanelEditor)
        Me.PanelDescription.Controls.Add(Me.EditorTmp1)
        Me.PanelDescription.Controls.Add(Me.lblStartAt)
        Me.PanelDescription.Controls.Add(Me.lbkPriorität)
        Me.PanelDescription.Controls.Add(Me.lblStatus)
        Me.PanelDescription.Controls.Add(Me.cboPriorität)
        Me.PanelDescription.Controls.Add(Me.dteBeginntAm)
        Me.PanelDescription.Controls.Add(Me.lblErstelltAm)
        Me.PanelDescription.Controls.Add(Me.chkIsSerientermin)
        Me.PanelDescription.Controls.Add(Me.lblErstelltVon)
        Me.PanelDescription.Controls.Add(Me.cboDauer)
        Me.PanelDescription.Controls.Add(Me.grpSerientermin)
        Me.PanelDescription.Controls.Add(Me.lblEndAt)
        Me.PanelDescription.Controls.Add(Me.chkGanzerTag)
        Me.PanelDescription.Controls.Add(Me.dteEndetAm)
        Me.PanelDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDescription.Location = New System.Drawing.Point(0, 33)
        Me.PanelDescription.Name = "PanelDescription"
        Me.PanelDescription.Size = New System.Drawing.Size(1122, 120)
        Me.PanelDescription.TabIndex = 2
        '
        'PanelEditor
        '
        Me.PanelEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditor.Location = New System.Drawing.Point(1064, 69)
        Me.PanelEditor.Name = "PanelEditor"
        Me.PanelEditor.Size = New System.Drawing.Size(54, 46)
        Me.PanelEditor.TabIndex = 507
        '
        'EditorTmp1
        '
        Me.EditorTmp1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditorTmp1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.EditorTmp1.Location = New System.Drawing.Point(1064, 71)
        Me.EditorTmp1.Name = "EditorTmp1"
        Me.EditorTmp1.Size = New System.Drawing.Size(51, 44)
        Me.EditorTmp1.TabIndex = 506
        Me.EditorTmp1.Text = "TextControl1"
        Me.EditorTmp1.UserNames = Nothing
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.Transparent
        Me.PanelBody.Controls.Add(Me.PanelTxtEditor)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 153)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1122, 541)
        Me.PanelBody.TabIndex = 2
        '
        'PanelTxtEditor
        '
        Me.PanelTxtEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelTxtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTxtEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelTxtEditor.Name = "PanelTxtEditor"
        Me.PanelTxtEditor.Size = New System.Drawing.Size(1122, 541)
        Me.PanelTxtEditor.TabIndex = 7
        '
        'frmNachrichtBereich
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1122, 733)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelDescription)
        Me.Controls.Add(Me.PanelBetreff)
        Me.Controls.Add(Me.PanelBottom)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(1022, 600)
        Me.Name = "frmNachrichtBereich"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planungseintrag"
        Me.Panel1.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSerientermin.ResumeLayout(False)
        Me.grpSerientermin.PerformLayout()
        Me.PanelSerientermineUISub.ResumeLayout(False)
        Me.PanelSerientermineUISub.PerformLayout()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpWochentage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpWochentage.ResumeLayout(False)
        CType(Me.cbSo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.opTagWochenMonat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDauerSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBetreff.ResumeLayout(False)
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDescription.ResumeLayout(False)
        Me.PanelDescription.PerformLayout()
        Me.PanelBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.loadRes()

            'Me.btnTeilnehmer.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_persons, 32, 32)
            'Me.btnSendAnswer.Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(core.SystemDb.getRes.ePicture.ico_send, core.SystemDb.getRes.ePicTyp.ico)

            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing

            Me.initTxtControl()

            'Me.clObjects.loadAuswahlliste(Nothing, Me.cboArt, "PT", dsAuswahListSelLists, "", "", core.SystemDb.Enums.eKeyCol.IDNr)
            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing
            Me.genMain.loadSelList(Nothing, Me.cboPriorität, "PRT", tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntryReturn)

            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing

            'Me.contSelectSelListCategories.MainMessage = Me        'lthplan
            Me.contSelectSelListCategories.initControl("PlanCategory", False, False, Me.dropDownCategories, False, "Categories", "", False)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories

            Me.loadCboDauer()
            Me.loadCboDauerSerientermin()

            If PMDS.Global.ENV.adminSecure Then
            Else
            End If

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            'Me.AcceptButton = Me.btnSave
            Me.CancelButton = Me.btnAbort

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.initControl: " + ex.ToString())
        Finally
            Me.txtBetreff.Focus()
        End Try
    End Sub

    Public Sub initTxtControl()
        Try
            Me.contTxtEditor1.Dock = DockStyle.Fill
            Me.PanelTxtEditor.Controls.Add(Me.contTxtEditor1)
            Me.contTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
            Me.contTxtEditor1.LinealeOnOff(True)
            Me.contTxtEditor1.SetUIReadOnOff(False)
            Me.contTxtEditor1.loadForm(False, Nothing, False, False)
            Me.contTxtEditor1.setControlTyp()
            Me.contTxtEditor1.buttonBar1.Visible = False
            Me.contTxtEditor1.FileNew(False, False)

            AddHandler Me.contTxtEditor1.textControl1_IsToSave, AddressOf Me.textControl1_IsToSave

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.initTxtControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub textControl1_IsToSave()
        Try


        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.initTxtControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)

            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.txtBetreff.Focus()

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.loadRes: " + ex.ToString())
        Finally
            Me.txtBetreff.Focus()
        End Try
    End Sub

    Public Sub loadCboDauer()
        Try
            Me.cboDauer.Clear()

            Me.cboDauer.Items.Add(15, doUI.getRes("15Minutes"))
            Me.cboDauer.Items.Add(30, doUI.getRes("30Minutes"))
            Me.cboDauer.Items.Add(45, doUI.getRes("45Minutes"))
            Me.cboDauer.Items.Add(60, doUI.getRes("1Hour"))
            Me.cboDauer.Items.Add(90, doUI.getRes("11/2Hour"))
            Me.cboDauer.Items.Add(120, doUI.getRes("2Hour"))
            Me.cboDauer.Items.Add(150, doUI.getRes("21/2Hour"))
            Me.cboDauer.Items.Add(180, doUI.getRes("3Hour"))
            Me.cboDauer.Items.Add(240, doUI.getRes("4Hour"))
            Me.cboDauer.Items.Add(300, doUI.getRes("5Hour"))
            Me.cboDauer.Items.Add(360, doUI.getRes("6Hour"))
            Me.cboDauer.Items.Add(420, doUI.getRes("7Hour"))
            Me.cboDauer.Items.Add(480, doUI.getRes("8Hour"))
            Me.cboDauer.Items.Add(540, doUI.getRes("9Hour"))
            Me.cboDauer.Items.Add(600, doUI.getRes("10Hour"))
            Me.cboDauer.Items.Add(660, doUI.getRes("11Hour"))
            Me.cboDauer.Items.Add(720, doUI.getRes("12Hour"))

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.loadCboDauer: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadCboDauerSerientermin()
        Try
            Me.cboDauerSerientermin.Clear()

            Dim itm As ValueListItem = Me.cboDauerSerientermin.Items.Add(7, doUI.getRes("1Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(14, doUI.getRes("2Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(21, doUI.getRes("3Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(28, doUI.getRes("4Week"))
            itm.Tag = "W"

            itm = Me.cboDauerSerientermin.Items.Add(1, doUI.getRes("1Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(2, doUI.getRes("2Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(3, doUI.getRes("3Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(4, doUI.getRes("4Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(5, doUI.getRes("5Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(6, doUI.getRes("6Month"))
            itm.Tag = "M"

            itm = Me.cboDauerSerientermin.Items.Add(1, doUI.getRes("1Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(2, doUI.getRes("2Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(3, doUI.getRes("3Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(4, doUI.getRes("4Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(5, doUI.getRes("5Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(10, doUI.getRes("10Year"))
            itm.Tag = "Y"

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.loadCboDauerSerientermin: " + ex.ToString())
        End Try
    End Sub

    Private Sub AufgabeTerminNeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub AufgabeTerminNeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Visible = False
            e.Cancel = True

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub AufgabeTerminNeu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

#Region "Funktion"

    Public Function clear() As Boolean
        Try
            Me.txtBetreff.Text = ""
            Me.dteBeginntAm.Value = Nothing
            Me.chkGanzerTag.Checked = False
            Me.dteEndetAm.Value = Nothing
            Me.cboDauer.Value = Nothing
            Me.setUIEndetAm(False, False)
            Me.setUISerientermine("", "")
            Me.cboDauerSerientermin.Value = Nothing

            Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
            Me.setErstelltVon(UserLoggedIn.Trim(), Now)
            Me.IsNew = False
            Me.IDPlanBereich = Nothing

            Me.optStatus.CheckedIndex = 0

            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.contSelectSelListCategories.txtSearch.Text = ""
            Me.contSelectSelListCategories.clearFilterSearch()

            Me.lblErstelltVon.Text = ""
            Me.lblErstelltAm.Text = ""
            Me.clearSerientermineUI()

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.clear: " + ex.ToString())
        End Try
    End Function
    Public Sub clearSerientermineUI()
        Try
            Me.chkIsSerientermin.Checked = False
            Me.dteSerienterminEndetAm.Value = Nothing
            Me.grpSerientermin.Visible = False

            Me.optSerienterminType.CheckedIndex = 0
            Me.iWiedWertJeden.Value = Nothing
            Me.opTagWochenMonat.CheckedIndex = 0
            Me.opTagWochenMonat.Enabled = True
            Me.iNTenMonat.Value = Nothing

            Me.cbMo.Checked = False
            Me.cbDi.Checked = False
            Me.cbMi.Checked = False
            Me.cbDo.Checked = False
            Me.cbFr.Checked = False
            Me.cbSa.Checked = False
            Me.cbSo.Checked = False

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.clearSerientermineUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub setUISerientermine(SerienterminType As String, TagWochenMonat As String)
        Try
            If SerienterminType.Trim() <> "" Then
                Dim iSerienterminType As Integer = System.Convert.ToInt32(SerienterminType.Trim())
                If iSerienterminType = 1 Then
                    Me.iWiedWertJeden.Enabled = False
                    Me.opTagWochenMonat.Enabled = False
                    Me.iNTenMonat.Enabled = False
                    Me.grpWochentage.Enabled = False
                    Me.setWochentageAllOnOff(True)

                ElseIf iSerienterminType = 2 Then
                    Me.iWiedWertJeden.Enabled = True
                    Me.opTagWochenMonat.Enabled = True
                    Me.iNTenMonat.Enabled = False
                    Me.grpWochentage.Enabled = False

                    If TagWochenMonat.Trim() <> "" Then
                        Dim iTagWochenMonat As Integer = System.Convert.ToInt32(TagWochenMonat.Trim())
                        If iTagWochenMonat = 1 Then
                            Me.grpWochentage.Enabled = True
                        Else
                            Me.grpWochentage.Enabled = False
                        End If
                    Else
                        Me.grpWochentage.Enabled = False
                    End If

                ElseIf iSerienterminType = 3 Then
                    Me.iWiedWertJeden.Enabled = False
                    Me.opTagWochenMonat.Enabled = False
                    Me.iNTenMonat.Enabled = True
                    Me.grpWochentage.Enabled = False

                End If
            Else
                Me.iWiedWertJeden.Enabled = False
                Me.opTagWochenMonat.Enabled = False
                Me.iNTenMonat.Enabled = False
                Me.grpWochentage.Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setUISerientermine: " + ex.ToString())
        End Try
    End Sub

    Public Function Init() As Boolean
        Try
            Me.clear()

            If Not IsNew Then
                Me.dsPlan1 = New dsPlan()
                Me.compPlan1 = New compPlan()
                Me.compPlan1.getPlan(IDPlanBereich, compPlan.eTypSelPlan.id, Me.dsPlan1)
                Me.rPlan = Me.dsPlan1.plan.Rows(0)
                Me.loadData()

                Me.doEditor1.showText(Text, TXTextControl.StreamType.PlainText, True, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)

                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim tUser As IQueryable(Of PMDS.db.Entities.Benutzer) = Me.b.getUserByUserName2(Me.rPlan.ErstelltVon.Trim(), db)
                    If tUser.Count = 1 Then
                        Dim rUsr As PMDS.db.Entities.Benutzer = tUser.First
                        If Not rUsr.IDBerufsstand Is Nothing Then
                            If Me.b.UserCanSign(rUsr.IDBerufsstand.Value) Then
                                Me.lockUnlock(True)
                            Else
                                Me.lockUnlock(False)
                            End If
                        Else
                            Dim rUsrLoggedIn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)
                            If Me.rPlan.ErstelltVon.Trim() = "" Then
                                Throw New Exception("Init: Me.rPlan.ErstelltVon='' not allowed for IDPlan '" + Me.rPlan.ID.ToString() + "'!")
                            End If
                            If rUsrLoggedIn.Benutzer1.Trim().ToLower().Equals(Me.rPlan.ErstelltVon.Trim().ToLower()) Then
                                Me.lockUnlock(True)
                            Else
                                Me.lockUnlock(False)
                            End If
                        End If

                    ElseIf tUser.Count = 0 Then
                        Me.lockUnlock(False)
                    Else
                        Throw New Exception("frmNachricht.Init: tUser.Count>0 for Usr '" + Me.rPlan.ErstelltVon.Trim() + "' not allowed!")
                    End If
                End Using

                If Not Me.rPlan.IsIDSerienterminNull() Then
                    Me.PanelSerientermineUISub.Enabled = False
                Else
                    Me.PanelSerientermineUISub.Enabled = True
                End If

                Me.optStatus.Visible = False
                Me.lblStatus.Visible = False
                Me.contSelectSelListCategories.setLabelCount2()

                If Me.rPlan.IsIDSerienterminNull() Then
                    Me.chkIsSerientermin.Visible = False
                End If

            Else
                Me.setDBForNewPlan()
                Dim dNow As DateTime = Now
                Me.dteBeginntAm.DateTime = dNow
                Me.dteEndetAm.DateTime = dNow.AddMinutes(30)
                Me.cboDauer.Value = 30

                Me.optStatus.Visible = False
                Me.lblStatus.Visible = False

                Me.contTxtEditor1.textControl1.Load("", TXTextControl.StreamType.HTMLFormat)

                Me.PanelSerientermineUISub.Enabled = True
                Me.lockUnlock(True)

                Me.contSelectSelListCategories.setLabelCount2()

            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.Init: " + ex.ToString())
        End Try
    End Function

    Public Function loadData() As Boolean
        Try
            'Dim rPlanAct As dsPlan.planRow = Me.dsPlan1.plan.Rows(0)
            'If Me.loadAllActivities Then
            '    Me.ContComboActivities1.loadAllActivities("", -1, -1, -1, -1)
            'Else
            '    Me.ContComboActivities1.loadAllActivities("", -1, -1, -1, -1)
            '    'Me.ContComboActivities1.loadAllActivities("", 0, 0, 0, -1)
            'End If

            Me.txtBetreff.Text = Me.rPlan.Betreff

            If Me.rPlan.Status.Trim() <> "" Then
                If Me.rPlan.Status.Trim().ToLower().Equals(("Offen").Trim().ToLower()) Then
                    Me.optStatus.CheckedIndex = 0
                ElseIf Me.rPlan.Status.Trim().ToLower().Equals(("Erledigt").Trim().ToLower()) Then
                    Me.optStatus.CheckedIndex = 1
                Else
                    Throw New Exception("frmNachrichtBereich.loadData: Me.rPlan.Status='" + Me.rPlan.Status.Trim() + "' not allowed!")
                End If
            Else
                Me.optStatus.Value = Nothing
            End If

            If Not Me.rPlan.IsBeginntAmNull() Then
                Me.dteBeginntAm.Value = Me.rPlan.BeginntAm
            Else
                Me.dteBeginntAm.Value = Nothing
            End If
            Me.cboPriorität.Text = Me.rPlan.Priorität

            Me.contSelectSelListCategories.loadDataColl(Me.rPlan.Category.Trim())

            'Me.textAnzeigenxy(Me.rPlan.Text, Me.rPlan.html, Me.rPlan.IDArt)
            'Me.cboFür.Text = rPlan.Für
            'rPlan.Zusatz = ""
            'rPlan.objectName = Me.patient

            If Not Me.rPlan.IsIDActivityNull() Then
            Else
            End If


            If Me.rPlan.IsEndetAmNull() Then
                Me.dteEndetAm.Value = Nothing
            Else
                Me.dteEndetAm.DateTime = Me.rPlan.EndetAm
            End If
            If Me.rPlan.Dauer = -1 Then
                Me.cboDauer.Value = Nothing
            Else
                Me.cboDauer.Value = rPlan.Dauer
            End If
            Me.chkGanzerTag.Checked = Me.rPlan.GanzerTag
            Me.setUIEndetAm(Me.rPlan.GanzerTag, False)

            Me.chkIsSerientermin.Checked = Me.rPlan.IsSerientermin
            Me.grpSerientermin.Visible = Me.rPlan.IsSerientermin
            If Me.rPlan.IsSerienterminEndetAmNull() Then
                Me.dteSerienterminEndetAm.Value = Nothing
            Else
                Me.dteSerienterminEndetAm.Value = Me.rPlan.SerienterminEndetAm.Date
            End If

            If Me.rPlan.SerienterminType.Trim() <> "" Then
                If Me.rPlan.SerienterminType.Trim() = "1" Then
                    Me.optSerienterminType.CheckedIndex = 0
                ElseIf Me.rPlan.SerienterminType.Trim() = "2" Then
                    Me.optSerienterminType.CheckedIndex = 1
                ElseIf Me.rPlan.SerienterminType.Trim() = "3" Then
                    Me.optSerienterminType.CheckedIndex = 2
                End If
            Else
                Me.optSerienterminType.CheckedIndex = 0
            End If
            If Me.rPlan.IsWiedWertJedenNull() Then
                Me.iWiedWertJeden.Value = Nothing
            Else
                Me.iWiedWertJeden.Value = Me.rPlan.WiedWertJeden
            End If
            If Me.rPlan.TagWochenMonat.Trim() <> "" Then
                If Me.rPlan.TagWochenMonat.Trim() = "0" Then
                    Me.opTagWochenMonat.CheckedIndex = 0
                ElseIf Me.rPlan.TagWochenMonat.Trim() = "1" Then
                    Me.opTagWochenMonat.CheckedIndex = 1
                ElseIf Me.rPlan.TagWochenMonat.Trim() = "2" Then
                    Me.opTagWochenMonat.CheckedIndex = 2
                End If
            Else
                Me.opTagWochenMonat.CheckedIndex = 0
            End If
            If Me.rPlan.IsnTenMonatNull() Then
                Me.iNTenMonat.Value = Nothing
            Else
                Me.iNTenMonat.Value = Me.rPlan.nTenMonat
            End If

            Me.setWochentage(Me.rPlan.Wochentage.Trim())
            Me.setErstelltVon(Me.rPlan.ErstelltVon, Me.rPlan.ErstelltAm)

            General.GarbColl()

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.loadData: " + ex.ToString())
        End Try
    End Function

    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.txtBetreff, "")
            Me.ErrorProvider1.SetError(Me.dteBeginntAm, "")
            Me.ErrorProvider1.SetError(Me.dteEndetAm, "")
            Me.ErrorProvider1.SetError(Me.cboDauer, "")

            Me.ErrorProvider1.SetError(Me.chkIsSerientermin, "")
            Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, "")
            Me.ErrorProvider1.SetError(Me.grpSerientermin, "")
            Me.ErrorProvider1.SetError(Me.optSerienterminType, "")
            Me.ErrorProvider1.SetError(Me.iWiedWertJeden, "")
            Me.ErrorProvider1.SetError(Me.opTagWochenMonat, "")
            Me.ErrorProvider1.SetError(Me.iNTenMonat, "")
            Me.ErrorProvider1.SetError(Me.grpWochentage, "")

            Me.ErrorProvider1.SetError(Me.cbMo, "")
            Me.ErrorProvider1.SetError(Me.cbDi, "")
            Me.ErrorProvider1.SetError(Me.cbMi, "")
            Me.ErrorProvider1.SetError(Me.cbDo, "")
            Me.ErrorProvider1.SetError(Me.cbFr, "")
            Me.ErrorProvider1.SetError(Me.cbSa, "")
            Me.ErrorProvider1.SetError(Me.cbSo, "")

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.clearErrorProvider: " + ex.ToString())
        End Try
    End Sub
    Public Function checkInput() As Boolean
        Try
            Me.clearErrorProvider()

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim sCategoriesSelected As String = Me.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            If sCategoriesSelected.Trim() = "" Then
                Dim txt As String = doUI.getRes("CategorySelectionRequired")
                Me.ErrorProvider1.SetError(Me.txtBetreff, txt)
                doUI.doMessageBox2("CategorySelectionRequired", "", "!")
                txtBetreff.Focus()
                Return False
            End If

            If sCategoriesSelected.Trim() = "" And General.IsNull(Me.txtBetreff.Text) Then
                Dim txt As String = doUI.getRes("SubjectInputRequired")
                Me.ErrorProvider1.SetError(Me.txtBetreff, txt)
                doUI.doMessageBox2("SubjectInputRequired", "", "!")
                txtBetreff.Focus()
                Return False
            End If

            Dim ui1 As New UI()
            If Not Me.genMain.checkComboBox(Me.cboPriorität, False) Then Return False

            If General.IsNull(Me.dteBeginntAm.Value) Then
                Dim txt As String = doUI.getRes("BeginsAtInputRequired")
                Me.ErrorProvider1.SetError(Me.dteBeginntAm, txt)
                doUI.doMessageBox2("BeginsAtInputRequired", "", "!")
                dteBeginntAm.Focus()
                Return False
            End If

            If Not Me.chkGanzerTag.Checked Then
                If General.IsNull(Me.dteEndetAm.Value) Then
                    Dim txt As String = doUI.getRes("EndsAtInputRequired")
                    Me.ErrorProvider1.SetError(Me.dteEndetAm, txt)
                    doUI.doMessageBox2("EndsAtInputRequired", "", "!")
                    Me.dteEndetAm.Focus()
                    Return False
                Else
                    If Me.dteEndetAm.DateTime <= Me.dteBeginntAm.DateTime Then
                        Dim txt As String = doUI.getRes("EndetAmMussGrösserAlsBeginntAmSein")
                        Me.ErrorProvider1.SetError(Me.dteEndetAm, txt)
                        doUI.doMessageBox2("EndetAmMussGrösserAlsBeginntAmSein", "", "!")
                        Me.dteEndetAm.Focus()
                        Return False
                    End If
                End If
            End If

            If Me.chkIsSerientermin.Checked Then
                If General.IsNull(Me.dteSerienterminEndetAm.Value) Then
                    Dim txt As String = doUI.getRes("SerienterminEndetAmInputRequired")
                    Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, txt)
                    doUI.doMessageBox2("SerienterminEndetAmInputRequired", "", "!")
                    dteSerienterminEndetAm.Focus()
                    Return False
                Else
                    If Me.dteSerienterminEndetAm.DateTime.Date <= Me.dteBeginntAm.DateTime.Date Then
                        Dim txt As String = doUI.getRes("SerienterminMussGrösserAlsBeginntAmSein")
                        Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, txt)
                        doUI.doMessageBox2("SerienterminMussGrösserAlsBeginntAmSein", "", "!")
                        Me.dteSerienterminEndetAm.Focus()
                        Return False
                    End If
                End If

                Dim iSerientermintype As Integer = System.Convert.ToInt32(Me.optSerienterminType.Value.ToString().Trim())
                If iSerientermintype = 1 Then
                    Dim sWochentage As String = Me.getWochentage()
                    If sWochentage.Trim() = "" Then
                        Dim txt As String = doUI.getRes("WochentageSelectionRequired")
                        Me.ErrorProvider1.SetError(Me.grpWochentage, txt)
                        doUI.doMessageBox2("WochentageSelectionRequired", "", "!")
                        Me.grpWochentage.Focus()
                        Return False
                    End If

                ElseIf iSerientermintype = 2 Then
                    If Me.iWiedWertJeden.Value Is System.DBNull.Value Then
                        Dim txt As String = doUI.getRes("WiedWertJedenInputRequired")
                        Me.ErrorProvider1.SetError(Me.iWiedWertJeden, txt)
                        doUI.doMessageBox2("WiedWertJedenInputRequired", "", "!")
                        Me.iWiedWertJeden.Focus()
                        Return False
                    End If

                    Dim iTagWochenMonat As Integer = System.Convert.ToInt32(Me.opTagWochenMonat.Value.ToString().Trim())
                    If iTagWochenMonat = 1 Then
                        Dim sWochentage As String = Me.getWochentage()
                        If sWochentage.Trim() = "" Then
                            Dim txt As String = doUI.getRes("WochentageSelectionRequired")
                            Me.ErrorProvider1.SetError(Me.grpWochentage, txt)
                            doUI.doMessageBox2("WochentageSelectionRequired", "", "!")
                            Me.grpWochentage.Focus()
                            Return False
                        End If
                    End If

                ElseIf iSerientermintype = 3 Then
                    If Me.iNTenMonat.Value Is System.DBNull.Value Then
                        Dim txt As String = doUI.getRes("NTenMonatInputRequired")
                        Me.ErrorProvider1.SetError(Me.iNTenMonat, txt)
                        doUI.doMessageBox2("NTenMonatInputRequired", "", "!")
                        Me.iNTenMonat.Focus()
                        Return False
                    End If
                End If
            End If

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                'Dim lstPatientsSelected As System.Collections.Generic.List(Of Guid) = Me.contSelectPatienten.getList()
                'If lstPatientsSelected.Count = 0 Then
                '    doUI.doMessageBox2("NoPatientsSelected", "", "!")
                '    Return False
                'End If
            End Using

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.checkInput: " + ex.ToString())
        End Try
    End Function

    Public Function savePlan2(ByRef rSelUserAccountReturn As dsUserAccounts.tblUserAccountsRow) As Boolean
        Dim sInfoKlientPatients As String = ""
        Dim protokollOk As String = ""
        Dim protokollErr As String = ""
        Try
            Dim bSendOnServer As Boolean = False
            Dim dsInteropPar1 As New dsInteropPar()
            Dim rUsrAccount As dsUserAccounts.tblUserAccountsRow
            Dim anzPläne As Integer = 0
            Dim anzEMails As Integer = 0
            Dim anzErr As Integer = 0

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            Dim UsrExchangeKto As String = ""

            ' Save for Producer
            Dim Producer As String = ""
            If Me.IsNew Then
                Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
                Producer = UserLoggedIn.Trim()
            End If

            Dim EndetAmSerientermin As Nullable(Of Date) = Nothing
            If Not Me.IsNew And (Not rPlan.IsIDSerienterminNull()) Then
                EndetAmSerientermin = rPlan.SerienterminEndetAm
            End If
            Dim IDSerientermin As Nullable(Of Guid) = Nothing
            Dim lstSerientermineResult As New System.Collections.Generic.List(Of General.cSerientermine)
            If Me.chkIsSerientermin.Checked Then
                If Not Me.IsNew Then
                    If Not Me.rPlan.IsIDSerienterminNull() Then
                        IDSerientermin = Me.rPlan.IDSerientermin
                    Else
                        IDSerientermin = System.Guid.NewGuid()
                    End If
                Else
                    IDSerientermin = System.Guid.NewGuid()
                End If

                Dim sWochentage As String = Me.getWochentage()
                Dim iWiedWertJedenTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iWiedWertJeden.Value Is Nothing) AndAlso (Not Me.iWiedWertJeden.Value Is System.DBNull.Value) Then
                    iWiedWertJedenTmp = Me.iWiedWertJeden.Value
                End If
                Dim iNTenMonatTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iNTenMonat.Value Is Nothing) AndAlso (Not Me.iNTenMonat.Value Is System.DBNull.Value) Then
                    iNTenMonatTmp = Me.iNTenMonat.Value
                End If

                Me.genMain.calcDateStartEnd(Me.dteBeginntAm.Value, Me.dteEndetAm.Value, Me.chkGanzerTag.Checked, Me.chkIsSerientermin.Checked,
                                            Me.optSerienterminType.Value.ToString().Trim(), iWiedWertJedenTmp, Me.opTagWochenMonat.Value, iNTenMonatTmp, sWochentage,
                                            lstSerientermineResult, Me.dteSerienterminEndetAm.Value, IDSerientermin)

                If lstSerientermineResult.Count = 0 Then
                    doUI.doMessageBox2("KeineSerientermineGeneriert", "", "!")
                    Return False
                    'Throw New Exception("frmNachrichtBereich.savePlan2: lstSerientermineResult.Count = 0 not allowed!")
                End If
            Else
                Me.clearSerientermineUI()
            End If

            Dim STVerlängerung As Boolean = False
            Dim STKürzung As Boolean = False
            Dim ownerSucessfullySaved As Boolean = False
            Dim rPlanOwner As dsPlan.planRow = Me.dsPlan1.plan.Rows(0)
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                If Me.setPlanRowTemp(rPlanOwner, Producer, Nothing, IDSerientermin) Then
                    db.Configuration.LazyLoadingEnabled = False
                    Dim rPlanOrigDB As PMDS.db.Entities.plan = Nothing
                    If Not Me.IsNew Then
                        rPlanOrigDB = Me.b.getPlan(rPlanOwner.ID, db)
                    End If

                    Dim iCounterKlientPatients As Integer = 0
                    If UsrExchangeKto.Trim() <> "" Then
                        rPlanOwner.Für = UsrExchangeKto.Trim()
                        rSelUserAccountReturn = rSelUserAccount
                    End If
                    rPlanOwner.IsOwner = True

                    If Me.chkIsSerientermin.Checked Then
                        If Me.IsNew Then
                            ownerSucessfullySaved = True
                        Else ownerSucessfullySaved = True
                            If Me.dteSerienterminEndetAm.Value.Equals(EndetAmSerientermin) Then
                                If Me.saveNachrichtToDb2() Then
                                    ownerSucessfullySaved = True
                                    protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                    If Me.chkIsSerientermin.Checked Then
                                        Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                    End If
                                    Return True
                                End If
                            Else
                                Dim MsggResult As MsgBoxResult = MsgBoxResult.No
                                If Me.dteSerienterminEndetAm.DateTime > EndetAmSerientermin.Value Then
                                    MsggResult = doUI.doMessageBox3("SerienterminChangedVerlängern  ", "", MsgBoxStyle.YesNo, "?")
                                    If MsggResult = MsgBoxResult.Yes Then
                                        STVerlängerung = True
                                    End If

                                ElseIf Me.dteSerienterminEndetAm.DateTime < EndetAmSerientermin.Value Then
                                    MsggResult = doUI.doMessageBox3("SerienterminChangedVerkürzen", "", MsgBoxStyle.YesNo, "?")
                                    If MsggResult = MsgBoxResult.Yes Then
                                        STKürzung = True
                                    End If
                                End If

                                If MsggResult = MsgBoxResult.Yes Then
                                    If STKürzung Then
                                        'Me.compPlan1.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, Me.rPlan.IDArt, Me.rPlan.Betreff)
                                        If Me.saveNachrichtToDb2() Then
                                            Me.compPlan1.updatePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                                            Me.compPlan1.deletePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                                            ownerSucessfullySaved = True
                                            If Me.chkIsSerientermin.Checked Then
                                                Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                            End If
                                            protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                            Return True
                                        End If
                                    End If
                                Else
                                    If Me.saveNachrichtToDb2() Then
                                        ownerSucessfullySaved = True
                                        If Me.chkIsSerientermin.Checked Then
                                            Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                        End If
                                        protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                        Return True
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If Me.saveNachrichtToDb2() Then
                            ownerSucessfullySaved = True
                            protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                            Return True
                        End If
                    End If
                Else
                    Throw New Exception("frmNachrichtBereich.savePlan: Error saving E-Mail!")
                End If
            End Using

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False
                Dim rPlanOrigDB As PMDS.db.Entities.plan = Nothing
                If Not Me.IsNew Then
                    rPlanOrigDB = Me.b.getPlan(rPlanOwner.ID, db)
                End If

                If ownerSucessfullySaved Then
                    'Me.setPlanRowTemp(rPlanTemp, saveClicked, "", Nothing)

                    If Me.rPlan.IDArt = clPlan.typPlan_AufgabeTermin Then
                        ' Save Users
                        'Dim lstUsers As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(Me.rPlan.Teilnehmer.Trim())
                        'If lstUsers.Count > 0 Then
                        If lstSerientermineResult.Count > 0 And (Not STKürzung) Then
                            Dim dsPlanNew As New dsPlan()
                            Dim compPlanNew As New compPlan()

                            For Each SerientermineAct As General.cSerientermine In lstSerientermineResult
                                Dim b As New PMDS.db.PMDSBusiness()

                                'Dim rUsr As PMDS.db.Entities.Benutzer = b.getUserByUserName(usr.Trim(), db)
                                Dim bWritePlan As Boolean = False
                                If Not Me.IsNew Then
                                    If SerientermineAct.dFrom.Date >= Me.rPlan.BeginntAm.Date Then
                                        bWritePlan = True
                                    End If
                                Else
                                    bWritePlan = True
                                End If

                                If STVerlängerung Then
                                    Dim rPlan As PMDS.db.Entities.plan = b.getPlan(Me.rPlan.ID, db)
                                    Dim STEndetAmOrig As Date = Nothing
                                    If Not rPlan.IDSerientermin Is Nothing Then
                                        If SerientermineAct.dFrom.Date <= rPlan.SerienterminEndetAm.Value.Date Then
                                            bWritePlan = False
                                        End If
                                    Else
                                        bWritePlan = True
                                    End If
                                End If

                                If bWritePlan Then
                                    dsPlanNew.Clear()
                                    compPlanNew.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlanNew)
                                    compPlanNew.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.idPlan, dsPlanNew)
                                    compPlanNew.getPlanObject(System.Guid.NewGuid, compPlan.eTypSelPlanObject.id, dsPlanNew)

                                    Dim rPlanNew As dsPlan.planRow = Me.compPlan1.getNewRowPlan(dsPlanNew)
                                    rPlanNew.ItemArray = rPlanOwner.ItemArray
                                    rPlanNew.ID = System.Guid.NewGuid()
                                    rPlanNew.IDKlinik = PMDS.Global.ENV.IDKlinik
                                    'rPlanNew.Für = usr
                                    rPlanNew.IDPlanMain = rPlanOwner.ID
                                    rPlanNew.BeginntAm = SerientermineAct.dFrom
                                    rPlanNew.EndetAm = SerientermineAct.dTo

                                    compPlanNew.daPlan.Update(dsPlanNew.plan)
                                    compPlanNew.daPlanAnhang.Update(dsPlanNew.planAnhang)
                                    compPlanNew.daPlanObject.Update(dsPlanNew.planObject)

                                    anzPläne += 1
                                End If
                            Next

                            If STVerlängerung Then
                                Me.compPlan1.updatePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                            End If

                            If Not Me.IsNew Then
                                If Me.chkIsSerientermin.Checked Then
                                    Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                End If
                            End If

                            Dim txt As String = doUI.getRes("PlansSaved")
                            txt += " (" + anzPläne.ToString() + ")"
                            protokollOk = txt + vbNewLine + protokollOk
                        End If
                    End If

                    dsInteropPar1 = New dsInteropPar()
                    Return True
                End If
            End Using

            Throw New Exception("frmNachrichtBereich.savePlan: Error saving Plan!")
            Return False

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.savePlan2: " + ex.ToString())
        Finally
            If Not protokollOk.Trim() = "" Then
                MsgBox(protokollOk + sInfoKlientPatients, MsgBoxStyle.Information, doUI.getRes("Save"))
            End If
            Me.doProtokoll(protokollErr, doUI.getRes("SavePlan"))
        End Try
    End Function

    Public Sub updateSerientermine(ByRef rPlanOrig As dsPlan.planRow, ByRef rPlanOrigDB As PMDS.db.Entities.plan, db As PMDS.db.Entities.ERModellPMDSEntities)
        Try
            Dim tPlansST As IQueryable(Of PMDS.db.Entities.plan) = Me.b.getPlansSerientermin5(rPlanOrig.IDSerientermin, db)
            If tPlansST.Count() > 0 Then
                Dim frmInputDate1 As New frmInputDate()
                frmInputDate1.initControl(frmInputDate.eTypUI.SerientermineSaveChanged)
                frmInputDate1.ShowDialog(Me)
                If Not frmInputDate1.abort Then
                    Dim lstPlanIDToUpdate As New System.Collections.Generic.List(Of Guid)()
                    For Each rPlanToUpdate As PMDS.db.Entities.plan In tPlansST
                        'If rPlanToUpdate.BeginntAm.Value.Date >= rPlanOrig.BeginntAm.Date Then
                        If rPlanToUpdate.BeginntAm.Value >= frmInputDate1.udteDateAt.DateTime Then
                            If rPlanToUpdate.ID = rPlanOrig.ID Then
                                Dim bStop As Boolean = True
                            Else
                                rPlanToUpdate.Betreff = rPlanOrig.Betreff.Trim()
                                rPlanToUpdate.Text = rPlanOrig.Text
                                rPlanToUpdate.html = rPlanOrig.html
                                rPlanToUpdate.Priorität = rPlanOrig.Priorität
                                rPlanToUpdate.Status = rPlanOrig.Status
                                rPlanToUpdate.Category = rPlanOrig.Category
                                'rPlanToUpdate.Dauer = rPlanOrig.Dauer
                                'rPlanToUpdate.GanzerTag = rPlanOrig.GanzerTag
                                'rPlanToUpdate.EndetAm = rPlanOrig.EndetAm
                            End If
                            lstPlanIDToUpdate.Add(rPlanToUpdate.ID)
                        Else
                            Dim bOldTermin As Boolean = True
                        End If

                        'If resUpdateStatusÜbernehmen = DialogResult.Yes Then
                        '    rPlanToUpdate.Status = rPlanOrig.Status.Trim()
                        'Else
                        '    rPlanToUpdate.Status = "Offen"
                        'End If
                    Next
                    db.SaveChanges()

                    For Each IDPlanToUpdate As Guid In lstPlanIDToUpdate
                        'If Not IDPlanToUpdate.Equals(rPlanOrig.ID) Then
                        Dim lstObjectsInPlan As New System.Collections.Generic.List(Of Guid)()
                        Dim tPlansObjectST As IQueryable(Of PMDS.db.Entities.planObject) = Me.b.getPlanObjects(IDPlanToUpdate, db)
                        For Each rPlanObjectUpdate As PMDS.db.Entities.planObject In tPlansObjectST
                            lstObjectsInPlan.Add(rPlanObjectUpdate.IDObject)

                            'If resUpdateStatusÜbernehmen = DialogResult.Yes Then
                            '    If rPlanOrig.Status.Trim().ToLower().Equals(("Offen").Trim.ToLower()) Then
                            '        rPlanObjectUpdate.Status = ""
                            '    Else
                            '        rPlanObjectUpdate.Status = rPlanOrig.Status.Trim()
                            '    End If
                            'Else
                            '    rPlanObjectUpdate.Status = ""
                            'End If
                        Next

                        db.SaveChanges()
                        'End If
                    Next
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.updateSerientermine: " + ex.ToString())
        End Try
    End Sub

    Public Function setPlanRowTemp(ByRef rPlanToSet As dsPlan.planRow,
                                    ByRef Usr As String, ByRef IDPlanMain As System.Guid,
                                    ByRef IDSerientermin As Nullable(Of Guid)) As Boolean
        Try
            rPlanToSet.Betreff = Me.txtBetreff.Text
            If General.IsNull(Me.dteBeginntAm.Value) Then
                rPlanToSet.SetBeginntAmNull()
            Else
                rPlanToSet.BeginntAm = Me.dteBeginntAm.Value
            End If

            rPlanToSet.Priorität = Me.cboPriorität.Text
            If (Not Me.optStatus.Value Is Nothing) Then
                If Me.optStatus.CheckedIndex = 0 Then
                    rPlanToSet.Status = "Offen"
                ElseIf Me.optStatus.CheckedIndex = 1 Then
                    rPlanToSet.Status = "Erledigt"
                Else
                    Throw New Exception("setPlanRowTemp: Me.optStatus.CheckedIndex '" + Me.optStatus.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.Status = "Offen"
            End If

            If Not Me.General.IsNull(IDPlanMain) Then
                rPlanToSet.IDPlanMain = IDPlanMain
            Else
                rPlanToSet.SetIDPlanMainNull()
            End If

            rPlanToSet.SetIDActivityNull()
            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            rPlanToSet.Category = Me.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            If rPlanToSet.Betreff.Trim() = "" Then
                rPlanToSet.Betreff = rPlanToSet.Category.Trim()
            End If

            Dim text As String = ""
            Dim typTxt As New TXTextControl.StreamType
            typTxt = TXTextControl.StreamType.PlainText

            Me.contTxtEditor1.textControl1.Save(text, TXTextControl.StringStreamType.PlainText)

            If Not General.IsNull(text) Then
                rPlanToSet.Text = text
                rPlanToSet.html = False
            Else
                rPlanToSet.Text = ""
                rPlanToSet.html = False
            End If

            If Usr.Trim() <> "" Then
                rPlanToSet.Für = Usr
            End If

            rPlanToSet.Zusatz = ""
            rPlanToSet.IsgesendetAmNull()

            If Me.dteEndetAm.Value Is Nothing Then
                rPlanToSet.SetEndetAmNull()
            Else
                rPlanToSet.EndetAm = Me.dteEndetAm.DateTime
            End If
            If Me.cboDauer.Value Is Nothing OrElse Me.cboDauer.Value Is System.DBNull.Value OrElse Me.cboDauer.Value = -1 Then
                rPlanToSet.Dauer = -1
            Else
                rPlanToSet.Dauer = Me.cboDauer.Value
            End If
            rPlanToSet.GanzerTag = Me.chkGanzerTag.Checked

            If rPlanToSet.GanzerTag Then
                If Not Me.dteEndetAm.Value Is Nothing Then
                    Dim EndetAmEndeTmp As Date = New Date(Me.dteEndetAm.DateTime.Year, Me.dteEndetAm.DateTime.Month, Me.dteEndetAm.DateTime.Day, 0, 0, 0)
                    'EndetAmEndeTmp = EndetAmEndeTmp.AddDays(1)
                    rPlanToSet.EndetAm = EndetAmEndeTmp.Date
                Else
                    Dim EndetAmEndeTmp As Date = New Date(rPlanToSet.BeginntAm.Date.Year, rPlanToSet.BeginntAm.Date.Month, rPlanToSet.BeginntAm.Date.Day, 0, 0, 0)
                    EndetAmEndeTmp = EndetAmEndeTmp.AddDays(1)
                    rPlanToSet.EndetAm = EndetAmEndeTmp
                End If
            End If

            'Dim diffBeginnEndDate As TimeSpan = rPlanToSet.EndetAm - rPlanToSet.BeginntAm
            Me.rPlan.Dauer = DateDiff(DateInterval.Minute, rPlanToSet.BeginntAm, rPlanToSet.EndetAm)
            'Me.rPlan.Dauer = diffBeginnEndDate.TotalMinutes
            'Me.rPlan.Dauer = DateDiff(DateInterval.Minute, rPlanToSet.BeginntAm, rPlanToSet.EndetAm)

            rPlanToSet.IsSerientermin = Me.chkIsSerientermin.Checked
            If IDSerientermin Is Nothing Then
                rPlanToSet.SetIDSerienterminNull()
            Else
                rPlanToSet.IDSerientermin = IDSerientermin.Value
            End If

            If Me.dteSerienterminEndetAm.Value Is Nothing Then
                rPlanToSet.SetSerienterminEndetAmNull()
            Else
                rPlanToSet.SerienterminEndetAm = Me.dteSerienterminEndetAm.DateTime.Date
            End If

            If (Not Me.optSerienterminType.Value Is Nothing) Then
                If Me.optSerienterminType.CheckedIndex = 0 Then
                    rPlanToSet.SerienterminType = "1"
                ElseIf Me.optSerienterminType.CheckedIndex = 1 Then
                    rPlanToSet.SerienterminType = "2"
                ElseIf Me.optSerienterminType.CheckedIndex = 2 Then
                    rPlanToSet.SerienterminType = "3"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.optSerienterminType.CheckedIndex '" + Me.optSerienterminType.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.SerienterminType = ""
            End If

            If Me.iWiedWertJeden.Value Is System.DBNull.Value Then
                rPlanToSet.SetWiedWertJedenNull()
            Else
                rPlanToSet.WiedWertJeden = Me.iWiedWertJeden.Value
            End If

            If (Not Me.opTagWochenMonat.Value Is Nothing) Then
                If Me.opTagWochenMonat.CheckedIndex = 0 Then
                    rPlanToSet.TagWochenMonat = "0"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 1 Then
                    rPlanToSet.TagWochenMonat = "1"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 2 Then
                    rPlanToSet.TagWochenMonat = "2"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.opTagWochenMonat.CheckedIndex '" + Me.opTagWochenMonat.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.TagWochenMonat = ""
            End If

            If Me.iNTenMonat.Value Is System.DBNull.Value Then
                rPlanToSet.SetnTenMonatNull()
            Else
                rPlanToSet.nTenMonat = Me.iNTenMonat.Value
            End If

            rPlanToSet.Wochentage = Me.getWochentage()

            If rPlanToSet.IDArt = 2 Then
                If Me.IsNew Then
                    rPlanToSet.design = True
                End If
            Else
                rPlanToSet.design = False
            End If

            If Me.IsNew Then
                Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
                rPlanToSet.ErstelltVon = UserLoggedIn.Trim()
                rPlanToSet.ErstelltAm = Now
            End If

            rPlanToSet.LastChangeITSCont = Now
            rPlanToSet.LastSyncToExchange = Now

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setPlanRowTemp: " + ex.ToString())
        End Try
    End Function
    Public Function saveNachrichtToDb2() As Boolean
        Try
            Me.compPlan1.daPlan.Update(Me.dsPlan1.plan)
            Return True

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.saveNachrichtToDb2: " + ex.ToString())
        End Try
    End Function

    Public Function getWochentage() As String
        Try
            Dim sWochentage As String = ""

            If Me.cbMo.Checked Then
                sWochentage += "Mo;"
            End If
            If Me.cbDi.Checked Then
                sWochentage += "Di;"
            End If
            If Me.cbMi.Checked Then
                sWochentage += "Mi;"
            End If
            If Me.cbDo.Checked Then
                sWochentage += "Do;"
            End If
            If Me.cbFr.Checked Then
                sWochentage += "Fr;"
            End If
            If Me.cbSa.Checked Then
                sWochentage += "Sa;"
            End If
            If Me.cbSo.Checked Then
                sWochentage += "So;"
            End If

            Return sWochentage.Trim()

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.getWochentage: " + ex.ToString())
        End Try
    End Function
    Public Sub setWochentage(ByRef sWochentage As String)
        Try
            If sWochentage.Trim().Contains(("Mo;")) Then
                Me.cbMo.Checked = True
            Else
                Me.cbMo.Checked = False
            End If
            If sWochentage.Trim().Contains(("Di;")) Then
                Me.cbDi.Checked = True
            Else
                Me.cbDi.Checked = False
            End If
            If sWochentage.Trim().Contains(("Mi;")) Then
                Me.cbMi.Checked = True
            Else
                Me.cbMi.Checked = False
            End If
            If sWochentage.Trim().Contains(("Do;")) Then
                Me.cbDo.Checked = True
            Else
                Me.cbDo.Checked = False
            End If
            If sWochentage.Trim().Contains(("Fr;")) Then
                Me.cbFr.Checked = True
            Else
                Me.cbFr.Checked = False
            End If
            If sWochentage.Trim().Contains(("Sa;")) Then
                Me.cbSa.Checked = True
            Else
                Me.cbSa.Checked = False
            End If
            If sWochentage.Trim().Contains(("So;")) Then
                Me.cbSo.Checked = True
            Else
                Me.cbSo.Checked = False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setWochentage: " + ex.ToString())
        End Try
    End Sub
    Public Sub setWochentageAllOnOff(ByRef bOn As Boolean)
        Try
            Me.cbMo.Checked = bOn
            Me.cbDi.Checked = bOn
            Me.cbMi.Checked = bOn
            Me.cbDo.Checked = bOn
            Me.cbFr.Checked = bOn
            Me.cbSa.Checked = bOn
            Me.cbSo.Checked = bOn

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setWochentageAllOnOff: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIEndetAm(IsGanzerTag As Boolean, bSetEndetAm As Boolean)
        Try
            If IsGanzerTag Then
                'Me.dteEndetAm.Value = Nothing
                Me.cboDauer.Value = Nothing
                Me.dteEndetAm.Visible = True
                Me.lblEndAt.Visible = True
                Me.cboDauer.Visible = False
                If Not Me.dteBeginntAm.Value Is Nothing Then
                    Me.dteBeginntAm.DateTime = New Date(Me.dteBeginntAm.DateTime.Year, Me.dteBeginntAm.DateTime.Month, Me.dteBeginntAm.DateTime.Day, 0, 0, 0)
                End If
                If bSetEndetAm Then
                    If Not Me.dteEndetAm.Value Is Nothing Then
                        Dim dEndetAmTmp As Date = New Date(Me.dteEndetAm.DateTime.Year, Me.dteEndetAm.DateTime.Month, Me.dteEndetAm.DateTime.Day, 0, 0, 0)
                        dEndetAmTmp = dEndetAmTmp.AddDays(1)
                        Me.dteEndetAm.DateTime = dEndetAmTmp
                    End If
                End If
            Else
                Me.dteEndetAm.Visible = True
                Me.lblEndAt.Visible = True
                Me.cboDauer.Visible = True
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setUIEndetAm: " + ex.ToString())
        End Try
    End Sub

    Public Sub SerienterminTypeOrTagWochenMonat_ValueChanged()
        Try
            Dim sSerienterminType As String = ""
            If (Not Me.optSerienterminType.Value Is Nothing) Then
                sSerienterminType = Me.optSerienterminType.Value.ToString().Trim()
            End If
            Dim sTagWochenMonat As String = ""
            If (Not Me.opTagWochenMonat.Value Is Nothing) Then
                sTagWochenMonat = Me.opTagWochenMonat.Value.ToString().Trim()
            End If

            Me.setUISerientermine(sSerienterminType, sTagWochenMonat)

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.SerienterminTypeOrTagWochenMonat_ValueChanged: " + ex.ToString())
        End Try
    End Sub

    Public Function setDBForNewPlan() As Boolean
        Try
            Me.dsPlan1 = New dsPlan()
            Me.compPlan1 = New compPlan()
            Me.compPlan1.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, Me.dsPlan1)
            Me.rPlan = Me.compPlan1.getNewRowPlan(Me.dsPlan1)
            Me.rPlan.IDKlinik = PMDS.Global.ENV.IDKlinik

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.setDBForNewPlan: " + ex.ToString())
        End Try
    End Function

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.isEditable = bEdit

            Me.btnSave.Enabled = bEdit

            Dim styleButtDropDown As New Infragistics.Win.ButtonDisplayStyle
            If bEdit Then
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.Always
            Else
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
            End If

            Dim ui As New UI()
            ui.lockUnlockOneControl(Me.PanelDescription, bEdit)
            ui.lockUnlockOneControl(Me.PanelBetreff, bEdit)
            Me.contTxtEditor1.lockEingbe = Not bEdit

            Me.dteBeginntAm.DropDownButtonDisplayStyle = styleButtDropDown
            Me.cboPriorität.DropDownButtonDisplayStyle = styleButtDropDown

            If Not Me.IsNew Then
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Public Sub doProtokoll(ByRef protkoll As String, ByRef title As String)
        Try
            If protkoll.Trim() <> "" Then
                Dim frmProt As New QS2.core.vb.frmProtocol()
                frmProt.initControl()
                frmProt.Show()
                frmProt.ContProtocol1.setText(protkoll.Trim())
                frmProt.Text = title
            End If

        Catch ex As Exception
            Throw New Exception("frmNachrichtBereich.doProtokoll: " + ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub setErstelltVon(ByVal ErstelltVon As String, ByVal ErstelltAm As Date)
        Try
            Me.lblErstelltAm.Text = doUI.getRes("Generated") + ": " + Format(ErstelltAm, "dd.MM.yyyy HH:mm").ToString
            Me.lblErstelltVon.Text = doUI.getRes("GeneratedFrom") + ": " + ErstelltVon

        Catch ex As Exception
            Throw New Exception("frmNachricht.setErstelltVon: " + ex.ToString())
        End Try
    End Sub

    Private Sub UDtDateBeginnt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dteBeginntAm.Enter
        Try
            dteBeginntAm.SelectionStart = 0
            dteBeginntAm.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub frmNachricht_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.Visible Then
                Me.Init()
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                'cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
                Me.abort = False
                If Not Me.modalWindow Is Nothing Then
                    Me.modalWindow.ContPlanung1.search(False, False, False, False)
                End If
                Me.Close()
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkGanzerTag_CheckedChanged(sender As Object, e As EventArgs) Handles chkGanzerTag.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.setUIEndetAm(Me.chkGanzerTag.Checked, True)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cboDauer_ValueChanged(sender As Object, e As EventArgs) Handles cboDauer.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.cboDauer.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauer.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauer.Value.ToString().Trim())
                    Try
                        Me.dteEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMinutes(Me.cboDauer.Value)
                    Catch ex As Exception
                    End Try
                End If
            Else
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkIsSerientermin_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsSerientermin.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.chkIsSerientermin.Checked Then
                Me.grpSerientermin.Visible = True
                Me.SerienterminTypeOrTagWochenMonat_ValueChanged()
            Else
                Me.clearSerientermineUI()
                Me.grpSerientermin.Visible = False
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub optSerienterminType_ValueChanged(sender As Object, e As EventArgs) Handles optSerienterminType.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub opTagWochenMonat_ValueChanged(sender As Object, e As EventArgs) Handles opTagWochenMonat.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.clPlan1.deletePlan(Me.rPlan, Me.abort, Me.modalWindow, Me)      'lthplan

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboDauerSerientermin_ValueChanged(sender As Object, e As EventArgs) Handles cboDauerSerientermin.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.cboDauerSerientermin.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauerSerientermin.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauerSerientermin.Value.ToString().Trim())
                    Try
                        Try
                            If Me.cboDauerSerientermin.SelectedItem Is Nothing Then
                                Try
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(iDauer)
                                Catch ex As Exception
                                End Try
                            Else
                                Dim sTypeTime As String = Me.cboDauerSerientermin.SelectedItem.Tag.ToString()
                                If sTypeTime.Trim().ToLower().Equals(("W").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddDays(Me.cboDauerSerientermin.Value)
                                ElseIf sTypeTime.Trim().ToLower().Equals(("M").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(Me.cboDauerSerientermin.Value)
                                ElseIf sTypeTime.Trim().ToLower().Equals(("Y").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddYears(Me.cboDauerSerientermin.Value)
                                Else
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(iDauer)
                                End If
                            End If

                        Catch ex2 As Exception
                            Throw New Exception("cboDauerSerientermin_ValueChanged: " + ex2.ToString())
                        End Try

                    Catch ex As Exception
                    End Try
                End If
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dropDownPatienten_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dropDownCategories_ClosedUp(sender As Object, e As EventArgs) Handles dropDownCategories.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.dropDownCategories.Text = Me.contSelectSelListCategories.setLabelCount2()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dteBeginntAm_ValueChanged(sender As Object, e As EventArgs) Handles dteBeginntAm.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dteBeginntAm.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauer.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauer.Value.ToString().Trim())
                    Try
                        Me.dteEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMinutes(Me.cboDauer.Value)
                    Catch ex As Exception
                    End Try
                End If
            Else
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dteBeginntAm_AfterCloseUp(sender As Object, e As EventArgs) Handles dteBeginntAm.AfterCloseUp
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dteBeginntAm.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauer.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauer.Value.ToString().Trim())
                    Try
                        Me.dteEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMinutes(Me.cboDauer.Value)
                    Catch ex As Exception
                    End Try
                End If
            Else
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
