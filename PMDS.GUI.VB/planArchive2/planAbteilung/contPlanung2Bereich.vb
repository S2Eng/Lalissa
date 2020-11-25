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
    Public WithEvents UltraToolbarsManagerMain As UltraToolbarsManager
    Public WithEvents UDateBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Public WithEvents UDateVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblAnd As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBeginntZwischen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpSearch As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents layErwSuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Public WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents ContextMenuTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PosteingangsServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelTop As Panel
    Friend WithEvents PanelCenter As Panel
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents lblBetreff As Infragistics.Win.Misc.UltraLabel
    Public WithEvents txtBetreff2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSearch As Infragistics.Win.Misc.UltraButton
    Public WithEvents optStatus As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents dropDownUsers As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopUpContBenutzer As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents uPopUpContPatienten As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents lblStatus As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblZuordnungen As Infragistics.Win.Misc.UltraLabel
    Public WithEvents lblFound As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents btnLayout_PatientBeginn As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnLayout_PatientKategorie As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents PanelButtonsLayout As Panel
    Private WithEvents btnLayout_Beginn As QS2.Desktop.ControlManagment.BaseButton
    Private WithEvents btnLayout_KategoriePatient As QS2.Desktop.ControlManagment.BaseButton
    Friend WithEvents btnPrint As UltraButton
    Friend WithEvents chkDatumFixieren As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents TimerSearch As Timer
    Private WithEvents ultraPopupControlContainerDekursEntwürfe As UltraPopupControlContainer
    Private WithEvents PanelDekursEntwürfe As QS2.Desktop.ControlManagment.BasePanel
    Public WithEvents btnDekursEntwurfErstellenAs As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents btnDekursEntwurfErstellen As QS2.Desktop.ControlManagment.BaseButton
    Public WithEvents uDropDownDekursEntwürfe As UltraDropDownButton
    Friend WithEvents btnDekursErstellen As UltraButton
    Friend WithEvents ContPlanungDataBereich1 As contPlanungDataBereich
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
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffStatusGesendet")
        Dim OptionSet2 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffSucheNach")
        Dim OptionSet3 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffStatus")
        Dim OptionSet4 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffAnsicht")
        Dim OptionSet5 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblDesignOnOff")
        Dim OptionSet6 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffDeleted")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar2")
        Dim StateButtonTool27 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtMonat", "lblOnOffAnsicht")
        Dim StateButtonTool28 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtWoche", "lblOnOffAnsicht")
        Dim StateButtonTool29 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTag", "lblOnOffAnsicht")
        Dim StateButtonTool30 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtListe", "lblOnOffAnsicht")
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffAnsicht")
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtMonat", "lblOnOffAnsicht")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtWoche", "lblOnOffAnsicht")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool7 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTag", "lblOnOffAnsicht")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool8 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtListe", "lblOnOffAnsicht")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contPlanung2Bereich))
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Neuen Planungseintrag erstellen", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grpSearch = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkDatumFixieren = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.PanelButtonsLayout = New System.Windows.Forms.Panel()
        Me.btnLayout_Beginn = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnLayout_KategoriePatient = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnLayout_PatientKategorie = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnLayout_PatientBeginn = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnSearch = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblFound = New Infragistics.Win.Misc.UltraLabel()
        Me.lblZuordnungen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.dropDownUsers = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.UDateBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDateVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtBetreff2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBetreff = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.lblBeginntZwischen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAnd = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraToolbarsManagerMain = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelDekursEntwürfe = New QS2.Desktop.ControlManagment.BasePanel()
        Me.btnDekursEntwurfErstellenAs = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnDekursEntwurfErstellen = New QS2.Desktop.ControlManagment.BaseButton()
        Me.btnPrint = New Infragistics.Win.Misc.UltraButton()
        Me.btnAdd2 = New Infragistics.Win.Misc.UltraButton()
        Me.btnDekursErstellen = New Infragistics.Win.Misc.UltraButton()
        Me.uDropDownDekursEntwürfe = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.ultraPopupControlContainerDekursEntwürfe = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.ContextMenuTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PosteingangsServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.layErwSuche = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.PanelCenter = New System.Windows.Forms.Panel()
        Me.uPopUpContBenutzer = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopUpContPatienten = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.TimerSearch = New System.Windows.Forms.Timer(Me.components)
        Me.ContPlanungDataBereich1 = New PMDS.GUI.VB.contPlanungDataBereich()
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        CType(Me.chkDatumFixieren, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButtonsLayout.SuspendLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBetreff2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDekursEntwürfe.SuspendLayout()
        Me.ContextMenuTree.SuspendLayout()
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.PanelCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.grpSearch.Appearance = Appearance1
        Me.grpSearch.Controls.Add(Me.chkDatumFixieren)
        Me.grpSearch.Controls.Add(Me.PanelButtonsLayout)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.UltraLabel1)
        Me.grpSearch.Controls.Add(Me.lblFound)
        Me.grpSearch.Controls.Add(Me.lblZuordnungen)
        Me.grpSearch.Controls.Add(Me.lblStatus)
        Me.grpSearch.Controls.Add(Me.optStatus)
        Me.grpSearch.Controls.Add(Me.dropDownUsers)
        Me.grpSearch.Controls.Add(Me.UDateBis)
        Me.grpSearch.Controls.Add(Me.UDateVon)
        Me.grpSearch.Controls.Add(Me.txtBetreff2)
        Me.grpSearch.Controls.Add(Me.lblBetreff)
        Me.grpSearch.Controls.Add(Me.dropDownCategories)
        Me.grpSearch.Controls.Add(Me.lblBeginntZwischen)
        Me.grpSearch.Controls.Add(Me.lblAnd)
        Me.grpSearch.Location = New System.Drawing.Point(7, 3)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(557, 196)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.Tag = "ResID.Search"
        Me.grpSearch.Text = "Suche"
        '
        'chkDatumFixieren
        '
        Me.chkDatumFixieren.Location = New System.Drawing.Point(373, 49)
        Me.chkDatumFixieren.Name = "chkDatumFixieren"
        Me.chkDatumFixieren.Size = New System.Drawing.Size(135, 17)
        Me.chkDatumFixieren.TabIndex = 1004
        Me.chkDatumFixieren.Tag = "ResID.DatumFixieren"
        Me.chkDatumFixieren.Text = "Datum fixieren"
        '
        'PanelButtonsLayout
        '
        Me.PanelButtonsLayout.BackColor = System.Drawing.Color.Transparent
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_Beginn)
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_KategoriePatient)
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_PatientKategorie)
        Me.PanelButtonsLayout.Controls.Add(Me.btnLayout_PatientBeginn)
        Me.PanelButtonsLayout.Location = New System.Drawing.Point(123, 156)
        Me.PanelButtonsLayout.Name = "PanelButtonsLayout"
        Me.PanelButtonsLayout.Size = New System.Drawing.Size(325, 23)
        Me.PanelButtonsLayout.TabIndex = 0
        '
        'btnLayout_Beginn
        '
        Me.btnLayout_Beginn.AcceptsFocus = False
        Appearance2.AlphaLevel = CType(255, Short)
        Appearance2.FontData.SizeInPoints = 8.0!
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance2.TextHAlignAsString = "Left"
        Me.btnLayout_Beginn.Appearance = Appearance2
        Me.btnLayout_Beginn.AutoSize = True
        Me.btnLayout_Beginn.AutoWorkLayout = False
        Me.btnLayout_Beginn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_Beginn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_Beginn.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_Beginn.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_Beginn.IsStandardControl = False
        Me.btnLayout_Beginn.Location = New System.Drawing.Point(182, 0)
        Me.btnLayout_Beginn.Name = "btnLayout_Beginn"
        Me.btnLayout_Beginn.ShowFocusRect = False
        Me.btnLayout_Beginn.ShowOutline = False
        Me.btnLayout_Beginn.Size = New System.Drawing.Size(40, 23)
        Me.btnLayout_Beginn.TabIndex = 3
        Me.btnLayout_Beginn.Tag = "ResID.Beginn"
        Me.btnLayout_Beginn.Text = "Beginn"
        Me.btnLayout_Beginn.UseAppStyling = False
        Me.btnLayout_Beginn.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_Beginn.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_Beginn.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnLayout_KategoriePatient
        '
        Me.btnLayout_KategoriePatient.AcceptsFocus = False
        Appearance3.AlphaLevel = CType(255, Short)
        Appearance3.FontData.SizeInPoints = 8.0!
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance3.TextHAlignAsString = "Left"
        Me.btnLayout_KategoriePatient.Appearance = Appearance3
        Me.btnLayout_KategoriePatient.AutoSize = True
        Me.btnLayout_KategoriePatient.AutoWorkLayout = False
        Me.btnLayout_KategoriePatient.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_KategoriePatient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_KategoriePatient.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_KategoriePatient.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_KategoriePatient.IsStandardControl = False
        Me.btnLayout_KategoriePatient.Location = New System.Drawing.Point(92, 0)
        Me.btnLayout_KategoriePatient.Name = "btnLayout_KategoriePatient"
        Me.btnLayout_KategoriePatient.ShowFocusRect = False
        Me.btnLayout_KategoriePatient.ShowOutline = False
        Me.btnLayout_KategoriePatient.Size = New System.Drawing.Size(90, 23)
        Me.btnLayout_KategoriePatient.TabIndex = 2
        Me.btnLayout_KategoriePatient.Tag = "ResID.KategoriePatient"
        Me.btnLayout_KategoriePatient.Text = "Kategorie/Patient"
        Me.btnLayout_KategoriePatient.UseAppStyling = False
        Me.btnLayout_KategoriePatient.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_KategoriePatient.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_KategoriePatient.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnLayout_PatientKategorie
        '
        Me.btnLayout_PatientKategorie.AcceptsFocus = False
        Appearance4.AlphaLevel = CType(255, Short)
        Appearance4.FontData.SizeInPoints = 8.0!
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance4.TextHAlignAsString = "Left"
        Me.btnLayout_PatientKategorie.Appearance = Appearance4
        Me.btnLayout_PatientKategorie.AutoSize = True
        Me.btnLayout_PatientKategorie.AutoWorkLayout = False
        Me.btnLayout_PatientKategorie.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_PatientKategorie.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_PatientKategorie.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_PatientKategorie.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_PatientKategorie.IsStandardControl = False
        Me.btnLayout_PatientKategorie.Location = New System.Drawing.Point(2, 0)
        Me.btnLayout_PatientKategorie.Name = "btnLayout_PatientKategorie"
        Me.btnLayout_PatientKategorie.ShowFocusRect = False
        Me.btnLayout_PatientKategorie.ShowOutline = False
        Me.btnLayout_PatientKategorie.Size = New System.Drawing.Size(90, 23)
        Me.btnLayout_PatientKategorie.TabIndex = 1
        Me.btnLayout_PatientKategorie.Tag = "ResID.PatientKategorie"
        Me.btnLayout_PatientKategorie.Text = "Patient/Kategorie"
        Me.btnLayout_PatientKategorie.UseAppStyling = False
        Me.btnLayout_PatientKategorie.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_PatientKategorie.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_PatientKategorie.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnLayout_PatientBeginn
        '
        Me.btnLayout_PatientBeginn.AcceptsFocus = False
        Appearance5.AlphaLevel = CType(255, Short)
        Appearance5.FontData.SizeInPoints = 8.0!
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance5.TextHAlignAsString = "Left"
        Me.btnLayout_PatientBeginn.Appearance = Appearance5
        Me.btnLayout_PatientBeginn.AutoSize = True
        Me.btnLayout_PatientBeginn.AutoWorkLayout = False
        Me.btnLayout_PatientBeginn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLayout_PatientBeginn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayout_PatientBeginn.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLayout_PatientBeginn.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnLayout_PatientBeginn.IsStandardControl = False
        Me.btnLayout_PatientBeginn.Location = New System.Drawing.Point(0, 0)
        Me.btnLayout_PatientBeginn.Name = "btnLayout_PatientBeginn"
        Me.btnLayout_PatientBeginn.ShowFocusRect = False
        Me.btnLayout_PatientBeginn.ShowOutline = False
        Me.btnLayout_PatientBeginn.Size = New System.Drawing.Size(2, 23)
        Me.btnLayout_PatientBeginn.TabIndex = 0
        Me.btnLayout_PatientBeginn.Tag = ""
        Me.btnLayout_PatientBeginn.UseAppStyling = False
        Me.btnLayout_PatientBeginn.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_PatientBeginn.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnLayout_PatientBeginn.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnSearch
        '
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSearch.Appearance = Appearance6
        Me.btnSearch.Location = New System.Drawing.Point(471, 147)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 34)
        Me.btnSearch.TabIndex = 100
        Me.btnSearch.Tag = "ResID.Search"
        Me.btnSearch.Text = "Suchen"
        '
        'UltraLabel1
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 159)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(63, 16)
        Me.UltraLabel1.TabIndex = 1002
        Me.UltraLabel1.Tag = "ResID.Layout"
        Me.UltraLabel1.Text = "Layout"
        '
        'lblFound
        '
        Me.lblFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.FontData.SizeInPoints = 7.0!
        Appearance8.TextHAlignAsString = "Right"
        Me.lblFound.Appearance = Appearance8
        Me.lblFound.AutoSize = True
        Me.lblFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFound.Location = New System.Drawing.Point(469, 181)
        Me.lblFound.Name = "lblFound"
        Me.lblFound.Size = New System.Drawing.Size(72, 12)
        Me.lblFound.TabIndex = 501
        Me.lblFound.Tag = ""
        Me.lblFound.Text = "Gefunden: 1345"
        '
        'lblZuordnungen
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblZuordnungen.Appearance = Appearance9
        Me.lblZuordnungen.Location = New System.Drawing.Point(9, 101)
        Me.lblZuordnungen.Name = "lblZuordnungen"
        Me.lblZuordnungen.Size = New System.Drawing.Size(89, 16)
        Me.lblZuordnungen.TabIndex = 499
        Me.lblZuordnungen.Tag = "ResID.Zuordnungen"
        Me.lblZuordnungen.Text = "Zuordnungen"
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
        ValueListItem4.DataValue = "Canceled"
        ValueListItem4.DisplayText = "Storniert"
        ValueListItem4.Tag = "ResID.Canceled"
        ValueListItem3.DataValue = "All"
        ValueListItem3.DisplayText = "Alle"
        ValueListItem3.Tag = "ResID.All"
        Me.optStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem4, ValueListItem3})
        Me.optStatus.Location = New System.Drawing.Point(125, 76)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(238, 16)
        Me.optStatus.TabIndex = 3
        Me.optStatus.Text = "Offen"
        '
        'dropDownUsers
        '
        Appearance11.BorderColor = System.Drawing.Color.Black
        Me.dropDownUsers.Appearance = Appearance11
        Me.dropDownUsers.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownUsers.Location = New System.Drawing.Point(125, 95)
        Me.dropDownUsers.Name = "dropDownUsers"
        Me.dropDownUsers.Size = New System.Drawing.Size(97, 22)
        Me.dropDownUsers.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownUsers.TabIndex = 5
        Me.dropDownUsers.Tag = "ResID.Benutzer"
        Me.dropDownUsers.Text = "Benutzer"
        '
        'UDateBis
        '
        Appearance12.BackColor = System.Drawing.Color.White
        Me.UDateBis.Appearance = Appearance12
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
        Appearance13.BackColor = System.Drawing.Color.White
        Me.UDateVon.Appearance = Appearance13
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
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackColorDisabled = System.Drawing.Color.White
        Appearance14.BackColorDisabled2 = System.Drawing.Color.White
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.ItalicAsString = "False"
        Appearance14.FontData.Name = "Microsoft Sans Serif"
        Appearance14.FontData.SizeInPoints = 8.25!
        Appearance14.FontData.StrikeoutAsString = "False"
        Appearance14.FontData.UnderlineAsString = "False"
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBetreff2.Appearance = Appearance14
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
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextVAlignAsString = "Middle"
        Me.lblBetreff.Appearance = Appearance15
        Me.lblBetreff.Location = New System.Drawing.Point(125, 22)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(38, 16)
        Me.lblBetreff.TabIndex = 0
        Me.lblBetreff.Tag = "ResID.Subject"
        Me.lblBetreff.Text = "Betreff"
        '
        'dropDownCategories
        '
        Appearance16.BorderColor = System.Drawing.Color.Black
        Appearance16.TextHAlignAsString = "Left"
        Me.dropDownCategories.Appearance = Appearance16
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(9, 19)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(110, 22)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 6
        Me.dropDownCategories.TabStop = False
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'lblBeginntZwischen
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextVAlignAsString = "Middle"
        Me.lblBeginntZwischen.Appearance = Appearance17
        Me.lblBeginntZwischen.Location = New System.Drawing.Point(9, 49)
        Me.lblBeginntZwischen.Name = "lblBeginntZwischen"
        Me.lblBeginntZwischen.Size = New System.Drawing.Size(100, 16)
        Me.lblBeginntZwischen.TabIndex = 390
        Me.lblBeginntZwischen.Tag = "ResID.BeginntZwischen"
        Me.lblBeginntZwischen.Text = "Beginnt zwischen"
        '
        'lblAnd
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        Me.lblAnd.Appearance = Appearance18
        Me.lblAnd.Location = New System.Drawing.Point(225, 49)
        Me.lblAnd.Name = "lblAnd"
        Me.lblAnd.Size = New System.Drawing.Size(35, 16)
        Me.lblAnd.TabIndex = 389
        Me.lblAnd.Tag = "ResID.und"
        Me.lblAnd.Text = "und"
        '
        'UltraToolbarsManagerMain
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Me.UltraToolbarsManagerMain.Appearance = Appearance19
        Me.UltraToolbarsManagerMain.DesignerFlags = 1
        Me.UltraToolbarsManagerMain.LockToolbars = True
        OptionSet1.AllowAllUp = False
        OptionSet2.AllowAllUp = False
        OptionSet3.AllowAllUp = False
        OptionSet4.AllowAllUp = False
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet1)
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet2)
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet3)
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet4)
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet5)
        Me.UltraToolbarsManagerMain.OptionSets.Add(OptionSet6)
        Me.UltraToolbarsManagerMain.ShowFullMenusDelay = 500
        Me.UltraToolbarsManagerMain.ShowQuickCustomizeButton = False
        Me.UltraToolbarsManagerMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        StateButtonTool27.Checked = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool27, StateButtonTool28, StateButtonTool29, StateButtonTool30})
        UltraToolbar1.Text = "UltraToolbar2"
        Me.UltraToolbarsManagerMain.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        LabelTool2.SharedPropsInternal.Caption = "lblOnOffAnsicht"
        StateButtonTool5.Checked = True
        StateButtonTool5.OptionSetKey = "lblOnOffAnsicht"
        Appearance20.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance20
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColorDisabled = System.Drawing.Color.White
        Appearance21.FontData.BoldAsString = "True"
        Appearance21.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool5.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance21
        StateButtonTool5.SharedPropsInternal.Caption = "Monat"
        StateButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool5.SharedPropsInternal.ToolTipText = "Darstellung Monatsansicht"
        StateButtonTool5.SharedPropsInternal.ToolTipTitle = "Monat"
        StateButtonTool5.Tag = "ResID.Month"
        StateButtonTool6.OptionSetKey = "lblOnOffAnsicht"
        Appearance22.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool6.SharedPropsInternal.AppearancesSmall.Appearance = Appearance22
        Appearance23.BackColor = System.Drawing.Color.White
        Appearance23.BackColorDisabled = System.Drawing.Color.White
        Appearance23.FontData.BoldAsString = "True"
        Appearance23.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool6.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance23
        StateButtonTool6.SharedPropsInternal.Caption = "Woche"
        StateButtonTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool6.SharedPropsInternal.ToolTipText = "Darstellung Wochenansicht"
        StateButtonTool6.SharedPropsInternal.ToolTipTitle = "Woche"
        StateButtonTool6.Tag = "ResID.Week"
        StateButtonTool7.OptionSetKey = "lblOnOffAnsicht"
        Appearance24.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance24
        Appearance25.BackColor = System.Drawing.Color.White
        Appearance25.BackColorDisabled = System.Drawing.Color.White
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool7.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance25
        StateButtonTool7.SharedPropsInternal.Caption = "Tag"
        StateButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool7.SharedPropsInternal.ToolTipText = "Darstellung Tagesansicht"
        StateButtonTool7.SharedPropsInternal.ToolTipTitle = "Tag"
        StateButtonTool7.Tag = "ResID.Day"
        StateButtonTool8.OptionSetKey = "lblOnOffAnsicht"
        Appearance26.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = Appearance26
        Appearance27.BackColor = System.Drawing.Color.White
        Appearance27.BackColorDisabled2 = System.Drawing.Color.White
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool8.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance27
        StateButtonTool8.SharedPropsInternal.Caption = "Liste"
        StateButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool8.SharedPropsInternal.ToolTipText = "Darstellung Tabellenansicht"
        StateButtonTool8.SharedPropsInternal.ToolTipTitle = "Liste"
        StateButtonTool8.Tag = "ResID.List"
        Me.UltraToolbarsManagerMain.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool2, StateButtonTool5, StateButtonTool6, StateButtonTool7, StateButtonTool8})
        Me.UltraToolbarsManagerMain.UseAppStyling = False
        '
        'PanelDekursEntwürfe
        '
        Me.PanelDekursEntwürfe.BackColor = System.Drawing.Color.Gainsboro
        Me.PanelDekursEntwürfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDekursEntwürfe.Controls.Add(Me.btnDekursEntwurfErstellenAs)
        Me.PanelDekursEntwürfe.Controls.Add(Me.btnDekursEntwurfErstellen)
        Me.PanelDekursEntwürfe.Location = New System.Drawing.Point(613, 66)
        Me.PanelDekursEntwürfe.Name = "PanelDekursEntwürfe"
        Me.PanelDekursEntwürfe.Size = New System.Drawing.Size(103, 54)
        Me.PanelDekursEntwürfe.TabIndex = 1006
        Me.PanelDekursEntwürfe.Visible = False
        '
        'btnDekursEntwurfErstellenAs
        '
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        Appearance28.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance28.TextHAlignAsString = "Left"
        Appearance28.TextVAlignAsString = "Middle"
        Me.btnDekursEntwurfErstellenAs.Appearance = Appearance28
        Me.btnDekursEntwurfErstellenAs.AutoWorkLayout = False
        Me.btnDekursEntwurfErstellenAs.IsStandardControl = False
        Me.btnDekursEntwurfErstellenAs.Location = New System.Drawing.Point(4, 27)
        Me.btnDekursEntwurfErstellenAs.Name = "btnDekursEntwurfErstellenAs"
        Me.btnDekursEntwurfErstellenAs.Size = New System.Drawing.Size(94, 24)
        Me.btnDekursEntwurfErstellenAs.TabIndex = 96
        Me.btnDekursEntwurfErstellenAs.Tag = "ResID.ErstellenAls"
        Me.btnDekursEntwurfErstellenAs.Text = "Erstellen als"
        '
        'btnDekursEntwurfErstellen
        '
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance29.TextHAlignAsString = "Left"
        Appearance29.TextVAlignAsString = "Middle"
        Me.btnDekursEntwurfErstellen.Appearance = Appearance29
        Me.btnDekursEntwurfErstellen.AutoWorkLayout = False
        Me.btnDekursEntwurfErstellen.IsStandardControl = False
        Me.btnDekursEntwurfErstellen.Location = New System.Drawing.Point(4, 3)
        Me.btnDekursEntwurfErstellen.Name = "btnDekursEntwurfErstellen"
        Me.btnDekursEntwurfErstellen.Size = New System.Drawing.Size(94, 24)
        Me.btnDekursEntwurfErstellen.TabIndex = 95
        Me.btnDekursEntwurfErstellen.Tag = "ResID.Erstellen"
        Me.btnDekursEntwurfErstellen.Text = "Erstellen"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnPrint.Appearance = Appearance30
        Me.btnPrint.Location = New System.Drawing.Point(1033, 150)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 31)
        Me.btnPrint.TabIndex = 1003
        Me.btnPrint.Tag = "ResID.Print"
        Me.btnPrint.Text = "Drucken"
        '
        'btnAdd2
        '
        Me.btnAdd2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.Cursor = System.Windows.Forms.Cursors.Default
        Appearance31.TextHAlignAsString = "Center"
        Appearance31.TextVAlignAsString = "Middle"
        Me.btnAdd2.Appearance = Appearance31
        Me.btnAdd2.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnAdd2.Location = New System.Drawing.Point(1086, 16)
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.Size = New System.Drawing.Size(30, 29)
        Me.btnAdd2.TabIndex = 200
        UltraToolTipInfo1.Tag = "ResID.AddPlan"
        UltraToolTipInfo1.ToolTipText = "Neuen Planungseintrag erstellen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd2, UltraToolTipInfo1)
        '
        'btnDekursErstellen
        '
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnDekursErstellen.Appearance = Appearance32
        Me.btnDekursErstellen.Location = New System.Drawing.Point(11, 1)
        Me.btnDekursErstellen.Name = "btnDekursErstellen"
        Me.btnDekursErstellen.Size = New System.Drawing.Size(101, 29)
        Me.btnDekursErstellen.TabIndex = 1007
        Me.btnDekursErstellen.Tag = "ResID.DekursErstellen"
        Me.btnDekursErstellen.Text = "Dekurs erstellen"
        '
        'uDropDownDekursEntwürfe
        '
        Appearance33.Image = CType(resources.GetObject("Appearance33.Image"), Object)
        Appearance33.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.uDropDownDekursEntwürfe.Appearance = Appearance33
        Me.uDropDownDekursEntwürfe.Location = New System.Drawing.Point(115, 2)
        Me.uDropDownDekursEntwürfe.Name = "uDropDownDekursEntwürfe"
        Me.uDropDownDekursEntwürfe.PopupItemKey = "PanelDekursEntwürfe"
        Me.uDropDownDekursEntwürfe.PopupItemProvider = Me.ultraPopupControlContainerDekursEntwürfe
        Me.uDropDownDekursEntwürfe.RightAlignPopup = Infragistics.Win.DefaultableBoolean.[False]
        Me.uDropDownDekursEntwürfe.Size = New System.Drawing.Size(122, 27)
        Me.uDropDownDekursEntwürfe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.uDropDownDekursEntwürfe.TabIndex = 1005
        Me.uDropDownDekursEntwürfe.Tag = "ResID.DekursEntwurf"
        Me.uDropDownDekursEntwürfe.Text = "Dekurs Entwurf"
        Me.uDropDownDekursEntwürfe.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.uDropDownDekursEntwürfe.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'ultraPopupControlContainerDekursEntwürfe
        '
        Me.ultraPopupControlContainerDekursEntwürfe.PopupControl = Me.PanelDekursEntwürfe
        '
        'ContextMenuTree
        '
        Me.ContextMenuTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PosteingangsServerToolStripMenuItem})
        Me.ContextMenuTree.Name = "ContextMenuTree"
        Me.ContextMenuTree.Size = New System.Drawing.Size(340, 26)
        '
        'PosteingangsServerToolStripMenuItem
        '
        Me.PosteingangsServerToolStripMenuItem.Name = "PosteingangsServerToolStripMenuItem"
        Me.PosteingangsServerToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.PosteingangsServerToolStripMenuItem.Tag = "ResID.ImportEMails"
        Me.PosteingangsServerToolStripMenuItem.Text = "E-Mails von einem Posteingangs-Server einspielen"
        '
        'layErwSuche
        '
        Me.layErwSuche.ExpandToFitHeight = True
        Me.layErwSuche.ExpandToFitWidth = True
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
        Me.PanelTop.Controls.Add(Me.PanelDekursEntwürfe)
        Me.PanelTop.Controls.Add(Me.btnAdd2)
        Me.PanelTop.Controls.Add(Me.grpSearch)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1125, 200)
        Me.PanelTop.TabIndex = 70
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnDekursErstellen)
        Me.PanelBottom.Controls.Add(Me.uDropDownDekursEntwürfe)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 556)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1125, 34)
        Me.PanelBottom.TabIndex = 71
        '
        'PanelCenter
        '
        Me.PanelCenter.BackColor = System.Drawing.Color.Transparent
        Me.PanelCenter.Controls.Add(Me.ContPlanungDataBereich1)
        Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCenter.Location = New System.Drawing.Point(0, 200)
        Me.PanelCenter.Name = "PanelCenter"
        Me.PanelCenter.Size = New System.Drawing.Size(1125, 356)
        Me.PanelCenter.TabIndex = 72
        '
        'TimerSearch
        '
        '
        'ContPlanungDataBereich1
        '
        Me.ContPlanungDataBereich1.BackColor = System.Drawing.Color.White
        Me.ContPlanungDataBereich1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContPlanungDataBereich1.Location = New System.Drawing.Point(0, 0)
        Me.ContPlanungDataBereich1.Name = "ContPlanungDataBereich1"
        Me.ContPlanungDataBereich1.Size = New System.Drawing.Size(1125, 356)
        Me.ContPlanungDataBereich1.TabIndex = 1
        '
        'contPlanung2Bereich
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelCenter)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.Name = "contPlanung2Bereich"
        Me.Size = New System.Drawing.Size(1125, 590)
        CType(Me.grpSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.chkDatumFixieren, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButtonsLayout.ResumeLayout(False)
        Me.PanelButtonsLayout.PerformLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBetreff2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDekursEntwürfe.ResumeLayout(False)
        Me.ContextMenuTree.ResumeLayout(False)
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public gen As New General
    Public PMDSMainWindow As Control = Nothing

    Public isLoaded As Boolean = False
    Public initFormDone As Boolean = False

    Public contSelectPatienten As New contSelectPatientenBenutzer()
    Public contSelectBenutzer As New contSelectPatientenBenutzer()

    Public lockToolbar As Boolean = False
    Public doUI1 As New doUI()

    Private TimerIntervalDateChange As Integer = 1000
    Private TimerIntervalTextChanged As Integer = 1000
    Private TimerIntervalViewChanged As Integer = 100
    Private TimerIntervalCategoryChanged As Integer = 100
    Private TimerIntervalClientChanged As Integer = 100
    Private TimerIntervalUserChanged As Integer = 100

    Public Enum eTypActionRow
        delete = 0
        erledigt = 1
        offen = 2
        save = 3
        send = 6
    End Enum
    Public IsInitializedVisible As Boolean = False
    Public contSelectSelListCategories As New contSelectSelList()
    Public b As New PMDS.db.PMDSBusiness()

    Public activeBackCol As System.Drawing.Color = System.Drawing.Color.SkyBlue
    Public activeForeCol As System.Drawing.Color = System.Drawing.Color.Black
    Public activeFrameCol As System.Drawing.Color = System.Drawing.Color.Transparent
    Public inactiveBackCol As System.Drawing.Color = System.Drawing.Color.Transparent
    Public hoverBackCol As System.Drawing.Color = System.Drawing.Color.Gainsboro

    Public _lastQuickbutton As String = ""











    Private Sub initControl()
        Try
            Me.lockToolbar = True

            Me.ContPlanungDataBereich1.mainWindow = Me

            Me.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)
            Me.btnAdd2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32)

            Me.btnLayout_PatientKategorie.Text = doUI.getRes("PatientKategorie")
            Me.btnLayout_PatientBeginn.Text = doUI.getRes("PatientBeginn")
            Me.btnLayout_KategoriePatient.Text = doUI.getRes("KategoriePatient")
            Me.btnLayout_Beginn.Text = doUI.getRes("Beginn")

            Me.showListenansicht()
            Me.contSelectBenutzer.initControl(contSelectPatientenBenutzer.eTypeUI.Users, False, False, Me.dropDownUsers)

            Me.contSelectPatienten.loadDataAbtBereiche()
            Me.contSelectBenutzer.loadDataAbtBereiche()

            'Me.contSelectBenutzer.MainPlanungGesamt = Me       'lthplan
            Me.uPopUpContBenutzer.PopupControl = Me.contSelectBenutzer
            Me.dropDownUsers.PopupItem = Me.uPopUpContBenutzer
            Me.contSelectBenutzer.popupContMainSearch = Me.uPopUpContBenutzer

            'Me.contSelectPatienten.MainPlanungGesamt = Me      'lthplan
            Me.uPopUpContPatienten.PopupControl = Me.contSelectPatienten
            Me.contSelectPatienten.popupContMainSearch = Me.uPopUpContPatienten

            'Me.contSelectSelListCategories.MainPlanSearch = Me     'lthplan
            Me.contSelectSelListCategories.initControl("PlanBereichCategory", True, False, Me.dropDownCategories, False, "Categories", "", True)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories

            Me.ContPlanungDataBereich1.initControl()

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.optStatus.CheckedIndex = 0
            Me.ContPlanungDataBereich1.SplitContainer1.Panel2Collapsed = True

            Me.resetLayoutButtons()
            Me.btnLayout_Beginn.Visible = False
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
            Me.setLayoutButton2(Me.btnLayout_PatientBeginn)

            Me.isLoaded = True
            Me.lockToolbar = False

        Catch ex As Exception
            Me.lockToolbar = False
            Throw New Exception("contPlanung2.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub showListenansicht()
        Try
            Dim statButt As StateButtonTool = Me.UltraToolbarsManagerMain.Tools("statButtListe")
            statButt.Checked = True
            Me.ContPlanungDataBereich1.resizeControl()

        Catch ex As Exception
            Throw New Exception("contPlanung2.showListenansicht: " + ex.ToString())
        End Try
    End Sub

    Public Sub initForm(IDArt As Integer, TypeUI As contPlanungData.eTypeUI, PlanArchive As contPlanungDataBereich.cPlanArchive, doInit As Boolean)
        Try
            Me.initFormDone = False

            If Not Me.isLoaded Then
                Me.initControl()
            End If

            Me.zurücksetzen(True, True)

            Me.chkDatumFixieren.Checked = clPlan.bDatumFixieren
            If clPlan.bDatumFixieren Then
                If clPlan.dVonFixiert = DateTime.MinValue Then
                    Me.UDateVon.Value = Nothing
                Else
                    Me.UDateVon.Value = clPlan.dVonFixiert
                End If
                If clPlan.dBisFixiert = DateTime.MinValue Then
                    Me.UDateBis.Value = Nothing
                Else
                    Me.UDateBis.Value = clPlan.dBisFixiert
                End If
            Else
                Me.UDateVon.Value = Now
                Me.UDateBis.Value = Now
            End If

            Me.ContPlanungDataBereich1._TypeUI = TypeUI
            Me.ContPlanungDataBereich1._IDArt = IDArt
            Me.ContPlanungDataBereich1._PlanArchive = PlanArchive

            If Me.ContPlanungDataBereich1._IDArt = clPlan.typPlan_EMailEmpfangen Or Me.ContPlanungDataBereich1._IDArt = clPlan.typPlan_EMailGesendet Then

            Else

            End If

            Me.contSelectPatienten.utreeAbtBereiche.Enabled = True
            Me.contSelectBenutzer.utreeAbtBereiche.Enabled = True
            PMDSBusinessComm.checkCommAsyncForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll)

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsrLoggedOn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)

                If Me.ContPlanungDataBereich1._TypeUI = eTypeUI.PlanKlienten Then
                    Dim IDFoundInTree2 As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(PMDS.Global.ENV.CurrentIDAbteilung, PMDS.Global.ENV.IDBereich, True, Nothing, True, TypeUI, IDFoundInTree2)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    'Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    IDFoundInTree2 = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(Nothing, Nothing, False, Nothing, True, TypeUI, IDFoundInTree2)

                    Me.resetLayoutButtons()
                    Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
                    Me.setLayoutButton2(Me.btnLayout_PatientBeginn)

                ElseIf Me.ContPlanungDataBereich1._TypeUI = eTypeUI.PlanMy Then
                    Dim IDFoundInTree2 As Boolean = False
                    'Me.contSelectPatienten.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(Nothing, Nothing, False, Nothing, True, TypeUI, IDFoundInTree2)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    'Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    Me.contSelectBenutzer.utreeAbtBereiche.Enabled = False
                    IDFoundInTree2 = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(Nothing, Nothing, False, rUsrLoggedOn.ID, False, TypeUI, IDFoundInTree2)

                    Me.resetLayoutButtons()
                    Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
                    Me.setLayoutButton2(Me.btnLayout_Beginn)

                ElseIf Me.ContPlanungDataBereich1._TypeUI = eTypeUI.PlansAll Then
                    'Me.contSelectPatienten.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    Dim IDFoundInTree2 As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(Nothing, Nothing, False, Nothing, True, TypeUI, IDFoundInTree2)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    'Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    IDFoundInTree2 = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(Nothing, Nothing, False, Nothing, True, TypeUI, IDFoundInTree2)

                    Me.resetLayoutButtons()
                    Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
                    Me.setLayoutButton2(Me.btnLayout_Beginn)

                ElseIf Me.ContPlanungDataBereich1._TypeUI = eTypeUI.IDKlient Then
                    'Me.contSelectPatienten.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    Me.contSelectPatienten.utreeAbtBereiche.Enabled = False
                    Dim IDFoundInTree2 As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(Nothing, Nothing, False, PMDS.Global.ENV.CurrentIDPatient, False, TypeUI, IDFoundInTree2)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    'Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing)
                    IDFoundInTree2 = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(Nothing, Nothing, False, Nothing, False, TypeUI, IDFoundInTree2)

                    Me.resetLayoutButtons()
                    Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
                    Me.setLayoutButton2(Me.btnLayout_Beginn)

                Else
                    Throw New Exception("contPlanung2.initForm: Me.ContPlanung1._TypeUI '" + Me.ContPlanungDataBereich1._TypeUI.ToString() + "' not allowed!")
                End If
            End Using

            Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()
            Me.contSelectSelListCategories.setSelectionOnOff(True)
            Me.contSelectSelListCategories.setLabelCount2()

            Me.ContPlanungDataBereich1.search(True, doInit, False, True)

            Me.initFormDone = True

        Catch ex As Exception
            Me.initFormDone = True
            Throw New Exception("contPlanung2.initForm: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManagerMain.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.lockToolbar Then Exit Sub
            Me.ContPlanungDataBereich1.resizeControl()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub zurücksetzen(ByVal alles As Boolean, clearHTMLBrowser As Boolean)
        Try
            Me.lockToolbar = True

            Me.txtBetreff2.Text = ""
            If alles Then
                Me.optStatus.CheckedIndex = 0
            End If

            Me.setAzahl_buttSuchen(0)
            Me.ContPlanungDataBereich1.DsPlanSearch1.Clear()
            Me.ContPlanungDataBereich1.clear(clearHTMLBrowser)

            If alles Then
                Me.contSelectPatienten.loadDataAbtBereiche()
                Me.contSelectBenutzer.loadDataAbtBereiche()

                Me.contSelectPatienten.loadBenutzerPatients(Nothing, Nothing, Nothing, False, True)
                Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing, False, True)
            End If
            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.lockToolbar = False

            Me.lblFound.Text = ""

        Catch ex As Exception
            Me.lockToolbar = False
            Throw New Exception("contPlanung2.zurücksetzen: " + ex.ToString())
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
                Case "canceled"
                    Return "Storniert"
                Case "completed"
                    Return "Erledigt"
                Case Else
                    Return ""
            End Select

        Catch ex As Exception
            Throw New Exception("contPlanung2.getStatus: " + ex.ToString())
        End Try
    End Function

    Public Sub setAzahl_buttSuchen(ByVal anz As Integer)
        Try

        Catch ex As Exception
            Throw New Exception("contPlanung2.setAzahl_buttSuchen: " + ex.ToString())
        End Try
    End Sub

    Public Sub setLayoutButton2(btn As UltraButton)
        Try
            PMDS.Global.UIGlobal.setAktiv(btn, -1, activeForeCol, activeFrameCol, activeBackCol)
            Me._lastQuickbutton = btn.Tag.ToString().Trim()

        Catch ex As Exception
            Throw New Exception("contPlanung2.setLayoutButton: " + ex.ToString())
        End Try
    End Sub
    Public Sub resetLayoutButtons()
        Try
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_PatientBeginn, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_PatientKategorie, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_KategoriePatient, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)
            PMDS.Global.UIGlobal.setAktivDisable(Me.btnLayout_Beginn, -1, Me.activeForeCol, Me.hoverBackCol, Me.activeFrameCol, Me.inactiveBackCol, Infragistics.Win.UIElementButtonStyle.Flat)

        Catch ex As Exception
            Throw New Exception("contPlanung2.resetLayoutButtons: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.newMsg(Now, Now)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub newMsg(ByVal Dat As Date, ByVal Time As Date)
        Try
            Me.ContPlanungDataBereich1._PlanArchive = New contPlanungDataBereich.cPlanArchive()
            Me.contSelectPatienten.getSelectedAbtBereich(Me.ContPlanungDataBereich1._PlanArchive.IDKlinik_Patienten, Me.ContPlanungDataBereich1._PlanArchive.IDAbteilung_Patienten, Me.ContPlanungDataBereich1._PlanArchive.IDBereich_Patienten, Nothing, True)
            Me.contSelectBenutzer.getSelectedAbtBereich(Me.ContPlanungDataBereich1._PlanArchive.IDKlinik_Benutzer, Me.ContPlanungDataBereich1._PlanArchive.IDAbteilung_Benutzer, Me.ContPlanungDataBereich1._PlanArchive.IDBereich_Benutzer, Nothing, True)

            'Dim frmNewPlan As frmNachricht3 = Me.gen.newMessage(Dat, Time, Me, Nothing, False, False, "", "", Nothing, False, False, Me.ContPlanung1._TypeUI, Me.ContPlanung1._PlanArchive)
            'frmNewPlan.IDArt = Me.ContPlanung1._IDArt
            'frmNewPlan.setUIAfterLoading()     'lthplan

        Catch ex As Exception
            Throw New Exception("contPlanung2.newMsg: " + ex.ToString())
        End Try
    End Sub

    Private Sub PosteingangsServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosteingangsServerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim frmMailInputSrv1 As New frmMailInputSrv()
            frmMailInputSrv1.Show()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function getStatMail() As General.eAuswahlStatusMail
        Try
            Return General.eAuswahlStatusMail.alle
            'Return General.eAuswahlStatusMail.gesendet
            ' Return General.eAuswahlStatusMail.entwürfe

        Catch ex As Exception
            Throw New Exception("contPlanung2.getStatMail: " + ex.ToString())
        End Try
    End Function

    Private Sub contPlanung_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
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
            Me.ContPlanungDataBereich1.search(False, False, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub chkPreview_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.SplitContainer1.Panel2Collapsed = False

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLayout_PatientBeginn_Click(sender As Object, e As EventArgs) Handles btnLayout_PatientBeginn.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsBeginn
            Me.setLayoutButton2(Me.btnLayout_PatientBeginn)
            Me.ContPlanungDataBereich1.search(False, False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnLayout_PatientKategorie_Click(sender As Object, e As EventArgs) Handles btnLayout_PatientKategorie.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.PatientsKategorie
            Me.setLayoutButton2(Me.btnLayout_PatientKategorie)
            Me.ContPlanungDataBereich1.search(False, False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnLayout_KategoriePatient_Click(sender As Object, e As EventArgs) Handles btnLayout_KategoriePatient.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.resetLayoutButtons()
            Me.ContPlanungDataBereich1._LayoutGrid = eLayoutGrid.KategoriePatient
            Me.setLayoutButton2(Me.btnLayout_KategoriePatient)
            Me.ContPlanungDataBereich1.search(False, False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnLayout_Beginn_Click(sender As Object, e As EventArgs) Handles btnLayout_Beginn.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Throw New Exception("btnLayout_Beginn_Click: Click not allowed!")
            'Me.resetLayoutButtons()
            'Me.ContPlanung1._LayoutGrid = eLayoutGrid.Beginn
            'Me.setLayoutButton2(Me.btnLayout_Beginn)
            'Me.ContPlanung1.search(False, False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dropDownPatienten_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownUsers_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownUsers.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

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

    Private Sub dropDownUsers_ClosedUp(sender As Object, e As EventArgs) Handles dropDownUsers.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalUserChanged
            Me.TimerSearch.Start()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownCategories_ClosedUp(sender As Object, e As EventArgs) Handles dropDownCategories.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.dropDownCategories.Text = Me.contSelectSelListCategories.setLabelCount2()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalCategoryChanged
            Me.TimerSearch.Start()
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

    Private Sub chkDatumFixieren_CheckedChanged(sender As Object, e As EventArgs) Handles chkDatumFixieren.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.chkDatumFixieren.Visible And Me.initFormDone Then
                clPlan.bDatumFixieren = Me.chkDatumFixieren.Checked
                If Me.chkDatumFixieren.Checked Then
                    clPlan.dVonFixiert = Me.UDateVon.Value
                    clPlan.dBisFixiert = Me.UDateBis.Value
                Else
                    clPlan.dVonFixiert = Nothing
                    clPlan.dBisFixiert = Nothing
                End If
            End If

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
                If Me.chkDatumFixieren.Checked Then
                    clPlan.dVonFixiert = Me.UDateVon.Value
                Else
                    clPlan.dVonFixiert = Nothing
                End If
            End If

            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalDateChange
            Me.TimerSearch.Start()


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
                If Me.chkDatumFixieren.Checked Then
                    clPlan.dBisFixiert = Me.UDateBis.Value
                Else
                    clPlan.dBisFixiert = Nothing
                End If
            End If

            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalDateChange
            Me.TimerSearch.Start()

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
                'Me.ContPlanung1.search(False, False, True, False)
            End If

            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalTextChanged
            Me.TimerSearch.Start()

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
                'Me.ContPlanung1.search(False, False, True, False)
            End If

            Me.TimerSearch.Stop()
            Me.TimerSearch.Interval = Me.TimerIntervalViewChanged
            Me.TimerSearch.Start()


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerSearch.Tick
        Try
            Me.TimerSearch.Stop()
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.search(False, False, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDekursErstellen_Click(sender As Object, e As EventArgs) Handles btnDekursErstellen.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.DekursErstellen(True, eTypeDekursErstellen.DekursErstellen)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnDekursEntwurfErstellen_Click(sender As Object, e As EventArgs) Handles btnDekursEntwurfErstellen.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.DekursErstellen(True, eTypeDekursErstellen.DekursEntwurfErstellen)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnDekursEntwurfErstellenAs_Click(sender As Object, e As EventArgs) Handles btnDekursEntwurfErstellenAs.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ContPlanungDataBereich1.DekursErstellen(True, eTypeDekursErstellen.DekursEntwurfErstellenAls)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dropDownCategories_Click(sender As Object, e As EventArgs) Handles dropDownCategories.Click

    End Sub
End Class
