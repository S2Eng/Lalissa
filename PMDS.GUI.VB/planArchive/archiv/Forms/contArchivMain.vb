Imports System.Threading
Imports System.Reflection
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms


Public Class contArchivMain
    Inherits System.Windows.Forms.UserControl



#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        ' Me.SetCultureInfo()

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        Dim gen As New GeneralArchiv
        gen.ClearOrdnerTEMP()

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
    Friend WithEvents UToolbarsManagerMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents ContArchivSuch1 As contArchivSuch
    Friend WithEvents PanelToolbar2 As System.Windows.Forms.Panel
    Friend WithEvents PanelToolbar As System.Windows.Forms.Panel
    Friend WithEvents PanelToolbar1 As System.Windows.Forms.Panel
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents contArchivMain_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents PanelForm2 As System.Windows.Forms.Panel
    Friend WithEvents PanelToolbar_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents btnAdd2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelForm As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblAnsicht")
        Dim OptionSet2 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblSuchangaben")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpSuchkriterien")
        Dim TextBoxTool2 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("txtDokumentname")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Suchen")
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttZurücksetzen")
        Dim LabelTool4 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim PopupControlContainerTool1 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("Zwischenablage")
        Dim PopupMenuTool4 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAnsicht")
        Dim PopupMenuTool6 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpPapierkorb")
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxÖffnen")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PostboxAllgÖffnen")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool16 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PapierkorbÖffnen")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupControlContainerTool3 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("Zwischenablage")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool7 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpPapierkorb")
        Dim ButtonTool17 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PapierkorbÖffnen")
        Dim ButtonTool18 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("lblPapierkorbLeeren")
        Dim ButtonTool19 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("lblPapierkorbLeeren")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtSucheInOrdnern", "lblSuchangaben")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contArchivMain))
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtErweitert", "lblSuchangaben")
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtSchlagwort", "lblSuchangaben")
        Dim LabelTool6 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblSuchangaben")
        Dim PopupMenuTool8 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpSuchkriterien")
        Dim StateButtonTool16 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtErweitert", "lblSuchangaben")
        Dim StateButtonTool17 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtSucheInOrdnern", "lblSuchangaben")
        Dim StateButtonTool18 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtSchlagwort", "lblSuchangaben")
        Dim StateButtonTool19 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAusblenden", "lblSuchangaben")
        Dim PopupMenuTool9 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpAnsicht")
        Dim StateButtonTool20 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTabelle", "lblAnsicht")
        Dim StateButtonTool21 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtBaum", "lblAnsicht")
        Dim StateButtonTool22 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTabelle", "lblAnsicht")
        Dim StateButtonTool23 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtBaum", "lblAnsicht")
        Dim LabelTool7 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblAnsicht")
        Dim ButtonTool20 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Suchen")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool21 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttZurücksetzen")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim TextBoxTool3 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("txtDokumentname")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool24 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAusblenden", "lblSuchangaben")
        Dim LabelTool8 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Neues Dokument ins Archiv ablegen", Infragistics.Win.ToolTipImage.[Default], "Neues Dokument", Infragistics.Win.DefaultableBoolean.[Default])
        Me.UToolbarsManagerMain = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelToolbar1 = New System.Windows.Forms.Panel()
        Me._PanelToolbar1_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.ContArchivSuch1 = New contArchivSuch()
        Me.btnAdd2 = New Infragistics.Win.Misc.UltraButton()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelToolbar2 = New System.Windows.Forms.Panel()
        Me.PanelToolbar = New System.Windows.Forms.Panel()
        Me.PanelToolbar_Fill_Panel = New System.Windows.Forms.Panel()
        Me.contArchivMain_Fill_Panel = New System.Windows.Forms.Panel()
        Me.PanelForm2 = New System.Windows.Forms.Panel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.UToolbarsManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolbar1.SuspendLayout()
        Me.PanelForm.SuspendLayout()
        Me.PanelToolbar2.SuspendLayout()
        Me.PanelToolbar.SuspendLayout()
        Me.PanelToolbar_Fill_Panel.SuspendLayout()
        Me.contArchivMain_Fill_Panel.SuspendLayout()
        Me.PanelForm2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UToolbarsManagerMain
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UToolbarsManagerMain.Appearance = Appearance1
        Me.UToolbarsManagerMain.DesignerFlags = 1
        Me.UToolbarsManagerMain.DockWithinContainer = Me.PanelToolbar1
        Me.UToolbarsManagerMain.LockToolbars = True
        Me.UToolbarsManagerMain.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Fade
        Me.UToolbarsManagerMain.Office2007UICompatibility = False
        OptionSet1.AllowAllUp = False
        OptionSet2.AllowAllUp = False
        Me.UToolbarsManagerMain.OptionSets.Add(OptionSet1)
        Me.UToolbarsManagerMain.OptionSets.Add(OptionSet2)
        Me.UToolbarsManagerMain.ShowFullMenusDelay = 500
        Me.UToolbarsManagerMain.ShowQuickCustomizeButton = False
        Me.UToolbarsManagerMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        PopupMenuTool2.InstanceProps.IsFirstInGroup = True
        TextBoxTool2.InstanceProps.IsFirstInGroup = True
        PopupControlContainerTool1.InstanceProps.IsFirstInGroup = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool2, TextBoxTool2, ButtonTool3, ButtonTool11, LabelTool4, PopupControlContainerTool1, PopupMenuTool4, PopupMenuTool6})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UToolbarsManagerMain.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Me.UToolbarsManagerMain.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        Me.UToolbarsManagerMain.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool13.SharedPropsInternal.AppearancesLarge.Appearance = Appearance2
        Appearance3.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool13.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance3
        Appearance4.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool13.SharedPropsInternal.AppearancesSmall.HotTrackAppearanceOnMenu = Appearance4
        ButtonTool13.SharedPropsInternal.Caption = "Meine Postbox"
        ButtonTool13.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance5.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool14.SharedPropsInternal.AppearancesLarge.Appearance = Appearance5
        Appearance6.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool14.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance6
        Appearance7.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool14.SharedPropsInternal.AppearancesSmall.HotTrackAppearanceOnMenu = Appearance7
        ButtonTool14.SharedPropsInternal.Caption = "Allgem. Postbox"
        ButtonTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance8.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool16.SharedPropsInternal.AppearancesLarge.Appearance = Appearance8
        ButtonTool16.SharedPropsInternal.Caption = "Papierkorb öffnen"
        ButtonTool16.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        PopupControlContainerTool3.AllowTearaway = True
        PopupControlContainerTool3.SharedPropsInternal.AllowMultipleInstances = False
        Appearance9.Cursor = System.Windows.Forms.Cursors.Hand
        PopupControlContainerTool3.SharedPropsInternal.AppearancesLarge.Appearance = Appearance9
        PopupControlContainerTool3.SharedPropsInternal.Caption = "Zwischenablage"
        PopupControlContainerTool3.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        PopupControlContainerTool3.SharedPropsInternal.Visible = False
        PopupMenuTool7.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        PopupMenuTool7.SharedPropsInternal.Caption = "Papierkorb"
        PopupMenuTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        PopupMenuTool7.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool17, ButtonTool18})
        ButtonTool19.SharedPropsInternal.Caption = "Papierkorb leeren"
        StateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool4.OptionSetKey = "lblSuchangaben"
        Appearance10.Image = CType(resources.GetObject("Appearance10.Image"), Object)
        StateButtonTool4.SharedPropsInternal.AppearancesLarge.HotTrackAppearance = Appearance10
        StateButtonTool4.SharedPropsInternal.Caption = "Suche in Ordnern"
        StateButtonTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool5.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool5.OptionSetKey = "lblSuchangaben"
        StateButtonTool5.SharedPropsInternal.Caption = "Erweiterte Suchangaben"
        StateButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool6.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool6.OptionSetKey = "lblSuchangaben"
        StateButtonTool6.SharedPropsInternal.Caption = "Suche nach Schlagwörtern"
        StateButtonTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        LabelTool6.SharedPropsInternal.Caption = "Suchauswahl:"
        LabelTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        PopupMenuTool8.SharedPropsInternal.Caption = "Auswahl Suchkriterien"
        StateButtonTool16.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool17.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool18.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool19.Checked = True
        StateButtonTool19.InstanceProps.IsFirstInGroup = True
        StateButtonTool19.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool8.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool16, StateButtonTool17, StateButtonTool18, StateButtonTool19})
        PopupMenuTool9.SharedPropsInternal.Caption = "Ansicht"
        PopupMenuTool9.SharedPropsInternal.ToolTipTextFormatted = "&edsp;Tabellen- oder Baumansicht für die gefundenen Dokumente auswählen!"
        PopupMenuTool9.SharedPropsInternal.ToolTipTitle = "Ansicht"
        StateButtonTool20.Checked = True
        StateButtonTool20.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool21.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool9.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool20, StateButtonTool21})
        StateButtonTool22.Checked = True
        StateButtonTool22.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool22.OptionSetKey = "lblAnsicht"
        StateButtonTool22.SharedPropsInternal.Caption = "Tabelle"
        StateButtonTool23.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool23.OptionSetKey = "lblAnsicht"
        StateButtonTool23.SharedPropsInternal.Caption = "Baum"
        LabelTool7.SharedPropsInternal.Caption = "lblAnsicht"
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        ButtonTool20.SharedPropsInternal.AppearancesLarge.Appearance = Appearance11
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        ButtonTool20.SharedPropsInternal.AppearancesSmall.Appearance = Appearance12
        ButtonTool20.SharedPropsInternal.Caption = "Suchen"
        ButtonTool20.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool20.SharedPropsInternal.ToolTipTitle = "Suche durchführen"
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        ButtonTool21.SharedPropsInternal.AppearancesLarge.Appearance = Appearance13
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        ButtonTool21.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        ButtonTool21.SharedPropsInternal.Caption = "Zurücksetzen"
        ButtonTool21.SharedPropsInternal.ToolTipTextFormatted = "Zurücksetzen aller Such-Auswahlkriterien"
        ButtonTool21.SharedPropsInternal.ToolTipTitle = "Zurücksetzen"
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.BackColorDisabled = System.Drawing.Color.White
        Appearance15.BackColorDisabled2 = System.Drawing.Color.White
        Appearance15.BorderColor = System.Drawing.Color.Black
        Appearance15.BorderColor2 = System.Drawing.Color.Black
        Appearance15.FontData.ItalicAsString = "True"
        TextBoxTool3.EditAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BackColor2 = System.Drawing.Color.White
        TextBoxTool3.SharedPropsInternal.AppearancesLarge.Appearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.BackColor2 = System.Drawing.Color.White
        TextBoxTool3.SharedPropsInternal.AppearancesLarge.AppearanceOnRibbonGroup = Appearance17
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.BackColor2 = System.Drawing.Color.White
        TextBoxTool3.SharedPropsInternal.AppearancesLarge.AppearanceOnToolbar = Appearance18
        TextBoxTool3.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        TextBoxTool3.SharedPropsInternal.ToolTipTextFormatted = "Geben Sie einen Dokumentennamen ein und drücken Sie 'Enter' um nach diesen Dokume" & _
    "nt/en zu suchen!<br/>"
        TextBoxTool3.SharedPropsInternal.ToolTipTitle = "Schnellsuche "
        TextBoxTool3.SharedPropsInternal.Width = 200
        TextBoxTool3.Text = "Schnellsuche (Strg+S)"
        StateButtonTool24.Checked = True
        StateButtonTool24.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool24.OptionSetKey = "lblSuchangaben"
        StateButtonTool24.SharedPropsInternal.Caption = "Suchkriterien ausblenden"
        StateButtonTool24.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        LabelTool8.SharedPropsInternal.Width = 120
        Me.UToolbarsManagerMain.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool13, ButtonTool14, ButtonTool16, PopupControlContainerTool3, PopupMenuTool7, ButtonTool19, StateButtonTool4, StateButtonTool5, StateButtonTool6, LabelTool6, PopupMenuTool8, PopupMenuTool9, StateButtonTool22, StateButtonTool23, LabelTool7, ButtonTool20, ButtonTool21, TextBoxTool3, StateButtonTool24, LabelTool8})
        '
        'PanelToolbar1
        '
        Me.PanelToolbar1.Controls.Add(Me._PanelToolbar1_Toolbars_Dock_Area_Left)
        Me.PanelToolbar1.Controls.Add(Me._PanelToolbar1_Toolbars_Dock_Area_Right)
        Me.PanelToolbar1.Controls.Add(Me._PanelToolbar1_Toolbars_Dock_Area_Bottom)
        Me.PanelToolbar1.Controls.Add(Me._PanelToolbar1_Toolbars_Dock_Area_Top)
        Me.PanelToolbar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelToolbar1.Location = New System.Drawing.Point(0, 0)
        Me.PanelToolbar1.Name = "PanelToolbar1"
        Me.PanelToolbar1.Size = New System.Drawing.Size(748, 29)
        Me.PanelToolbar1.TabIndex = 66
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Left
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Name = "_PanelToolbar1_Toolbars_Dock_Area_Left"
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 2)
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UToolbarsManagerMain
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Right
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(748, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Name = "_PanelToolbar1_Toolbars_Dock_Area_Right"
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 2)
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UToolbarsManagerMain
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Bottom
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 29)
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Name = "_PanelToolbar1_Toolbars_Dock_Area_Bottom"
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(748, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UToolbarsManagerMain
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Top
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Name = "_PanelToolbar1_Toolbars_Dock_Area_Top"
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(748, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UToolbarsManagerMain
        '
        'PanelForm
        '
        Me.PanelForm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelForm.Controls.Add(Me.ContArchivSuch1)
        Me.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelForm.Location = New System.Drawing.Point(0, 0)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(1020, 485)
        Me.PanelForm.TabIndex = 59
        '
        'ContArchivSuch1
        '
        Me.ContArchivSuch1.BackColor = System.Drawing.Color.Transparent
        Me.ContArchivSuch1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ContArchivSuch1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContArchivSuch1.Location = New System.Drawing.Point(0, 0)
        Me.ContArchivSuch1.Name = "ContArchivSuch1"
        Me.ContArchivSuch1.Size = New System.Drawing.Size(1020, 485)
        Me.ContArchivSuch1.TabIndex = 0
        '
        'btnAdd2
        '
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        Me.btnAdd2.Appearance = Appearance19
        Me.btnAdd2.ImageList = Me.ImageList2
        Me.btnAdd2.Location = New System.Drawing.Point(6, 2)
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.Size = New System.Drawing.Size(26, 24)
        Me.btnAdd2.TabIndex = 3
        UltraToolTipInfo1.ToolTipText = "Neues Dokument ins Archiv ablegen"
        UltraToolTipInfo1.ToolTipTitle = "Neues Dokument"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAdd2, UltraToolTipInfo1)
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "ICO_plusNeu.ico")
        '
        'PanelToolbar2
        '
        Me.PanelToolbar2.Controls.Add(Me.btnAdd2)
        Me.PanelToolbar2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelToolbar2.Location = New System.Drawing.Point(979, 0)
        Me.PanelToolbar2.Name = "PanelToolbar2"
        Me.PanelToolbar2.Size = New System.Drawing.Size(41, 29)
        Me.PanelToolbar2.TabIndex = 65
        '
        'PanelToolbar
        '
        Me.PanelToolbar.Controls.Add(Me.PanelToolbar_Fill_Panel)
        Me.PanelToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelToolbar.Location = New System.Drawing.Point(0, 0)
        Me.PanelToolbar.Name = "PanelToolbar"
        Me.PanelToolbar.Size = New System.Drawing.Size(1020, 29)
        Me.PanelToolbar.TabIndex = 66
        '
        'PanelToolbar_Fill_Panel
        '
        Me.PanelToolbar_Fill_Panel.Controls.Add(Me.PanelToolbar1)
        Me.PanelToolbar_Fill_Panel.Controls.Add(Me.PanelToolbar2)
        Me.PanelToolbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelToolbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelToolbar_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.PanelToolbar_Fill_Panel.Name = "PanelToolbar_Fill_Panel"
        Me.PanelToolbar_Fill_Panel.Size = New System.Drawing.Size(1020, 29)
        Me.PanelToolbar_Fill_Panel.TabIndex = 0
        '
        'contArchivMain_Fill_Panel
        '
        Me.contArchivMain_Fill_Panel.Controls.Add(Me.PanelForm2)
        Me.contArchivMain_Fill_Panel.Controls.Add(Me.PanelToolbar)
        Me.contArchivMain_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.contArchivMain_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contArchivMain_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.contArchivMain_Fill_Panel.Name = "contArchivMain_Fill_Panel"
        Me.contArchivMain_Fill_Panel.Size = New System.Drawing.Size(1020, 514)
        Me.contArchivMain_Fill_Panel.TabIndex = 0
        '
        'PanelForm2
        '
        Me.PanelForm2.Controls.Add(Me.PanelForm)
        Me.PanelForm2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelForm2.Location = New System.Drawing.Point(0, 29)
        Me.PanelForm2.Name = "PanelForm2"
        Me.PanelForm2.Size = New System.Drawing.Size(1020, 485)
        Me.PanelForm2.TabIndex = 67
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contArchivMain
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.contArchivMain_Fill_Panel)
        Me.Name = "contArchivMain"
        Me.Size = New System.Drawing.Size(1020, 514)
        CType(Me.UToolbarsManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolbar1.ResumeLayout(False)
        Me.PanelForm.ResumeLayout(False)
        Me.PanelToolbar2.ResumeLayout(False)
        Me.PanelToolbar.ResumeLayout(False)
        Me.PanelToolbar_Fill_Panel.ResumeLayout(False)
        Me.contArchivMain_Fill_Panel.ResumeLayout(False)
        Me.PanelForm2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Shared oMainArchiv As contArchivMain

    '  Public ResManager As ResourceManager
    Private gen As New GeneralArchiv
    Private genMain As New GeneralArchiv
    Private ui As New UIElements()
    Public mainWindow As Object


    Private objects As New ArrayList
    Public patient As String = ""

    Public startTyp As New eStart
    Public Enum eStart
        Search = 0
        gesamtsystem = 2
    End Enum

    'Public contZwischenablage As contZwischenablage

    Public isloaded As Boolean = False

    Public Enum eSuchauswahl
        sucheInOrdnern = 0
        erweiterteSuche = 1
        schlagwort = 3
        keine = 10
    End Enum









    Private Sub UToolbarsManagerMain_AfterToolActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles UToolbarsManagerMain.AfterToolActivate
        Try
            Select Case e.Tool.Key
                Case "txtDokumentname"
                    Dim txtTool As TextBoxTool = e.Tool
                    If txtTool.Text = "Schnellsuche (Strg+S)" Then
                        txtTool.Text = ""
                        txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                    End If

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UToolbarsManagerMain_AfterToolDeactivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles UToolbarsManagerMain.AfterToolDeactivate
        Try
            Select Case e.Tool.Key
                Case "txtDokumentname"
                    Dim txtTool As TextBoxTool = e.Tool
                    If txtTool.Text = "" Then
                        txtTool.Text = "Schnellsuche (Strg+S)"
                        txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                    End If

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UToolbarsManagerMain_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UToolbarsManagerMain.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                'Case "Suchen"
                '    If Me.startTyp = eStart.gesamtsystem Then
                '        Me.LoadDokumenteSuchen(True)
                '    Else
                '        Me.LoadDokumenteSuchen(False)
                '    End If

                'Case "Ablegen"
                '    Me.LoadDokumenteAblegen()

                Case "PostboxÖffnen"
                    Dim frmPostbo As New FrmPostbox(FrmPostbox.eTyp.Benutzer)
                    frmPostbo.IDOrdner = Nothing
                    frmPostbo.Show()

                Case "PapierkorbÖffnen"
                    Me.ContArchivSuch1.DokumentSuchen(False, True, False)

                Case "lblPapierkorbLeeren"
                    Me.ContArchivSuch1.PapierkorbLeeren()

                    'Case "Zwischenablage"
                    '    Dim uiMenü As New clUIElements
                    '    Me.contZwischenablage.Dispose()
                    '    Me.contZwischenablage = New contZwischenablage
                    '    uiMenü.Menu_loadContainer(Me.UToolbarsManagerMain, 0, Me.contZwischenablage, "Zwischenablage")

                Case "statButtSucheInOrdnern"
                    Me.setSuchauwahlUI(eSuchauswahl.sucheInOrdnern)
                Case "statButtSchlagwort"
                    Me.setSuchauwahlUI(eSuchauswahl.schlagwort)
                Case "statButtErweitert"
                    Me.setSuchauwahlUI(eSuchauswahl.erweiterteSuche)

                Case "popUpAnsicht"
                    Me.showErgebniss_ansicht(0)
                Case "statButtTabelle"
                    Me.showErgebniss_ansicht(0)
                Case "statButtBaum"
                    Me.showErgebniss_ansicht(1)
                Case "statButtAusblenden"
                    Me.setSuchauwahlUI(eSuchauswahl.keine)

                Case "Suchen"
                    Me.ContArchivSuch1.DokumentSuchen(False, False, False)

                Case "buttZurücksetzen"
                    Me.ContArchivSuch1.resetForm()

                Case "txtDokumentname"

            End Select

            Me.resizeControl()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub showErgebniss_ansicht(ByVal iTyp As Integer)
        Try
            Me.ContArchivSuch1.showErgebniss_ansicht(iTyp)

            Select Case iTyp
                Case 0
                'Me.UToolbarsManagerMain.Tools("popUpAnsicht").SharedProps.Caption = "Ansicht Tabelle"
                Case 1
                    ' Me.UToolbarsManagerMain.Tools("popUpAnsicht").SharedProps.Caption = "Ansicht Baum"
            End Select

        Catch ex As Exception
            Throw New Exception("showErgebniss_ansicht: " + ex.ToString())
        End Try
    End Sub

    Public Sub setSuchauwahlUI(ByVal typ As eSuchauswahl)
        Try
            Select Case typ
                Case eSuchauswahl.sucheInOrdnern
                    Me.ContArchivSuch1.UltraGroupBoxSucheInOrdnern.Visible = True
                    Me.ContArchivSuch1.PanelErweiterteSuchangaben.Visible = False
                    Me.ContArchivSuch1.UltraGroupBoxSchlagwörter.Visible = False
                    Me.ContArchivSuch1.SplitContainer1.SplitterDistance = Me.ContArchivSuch1.SplitContainer1.Width - 300
                    Me.ContArchivSuch1.SplitContainer1.FixedPanel = False
                'Me.UToolbarsManagerMain.Tools("popUpSuchkriterien").SharedProps.Caption = "Suche in Ordnern"

                Case eSuchauswahl.erweiterteSuche
                    Me.ContArchivSuch1.UltraGroupBoxSucheInOrdnern.Visible = False
                    Me.ContArchivSuch1.PanelErweiterteSuchangaben.Visible = True
                    Me.ContArchivSuch1.UltraGroupBoxSchlagwörter.Visible = False
                    Me.ContArchivSuch1.SplitContainer1.SplitterDistance = Me.ContArchivSuch1.SplitContainer1.Width
                    Me.ContArchivSuch1.SplitContainer1.FixedPanel = False
                'Me.UToolbarsManagerMain.Tools("popUpSuchkriterien").SharedProps.Caption = "Erweiterte Suche"

                Case eSuchauswahl.schlagwort
                    Me.ContArchivSuch1.UltraGroupBoxSucheInOrdnern.Visible = False
                    Me.ContArchivSuch1.PanelErweiterteSuchangaben.Visible = False
                    Me.ContArchivSuch1.UltraGroupBoxSchlagwörter.Visible = True
                    Me.ContArchivSuch1.SplitContainer1.SplitterDistance = Me.ContArchivSuch1.SplitContainer1.Width - 300
                    Me.ContArchivSuch1.SplitContainer1.FixedPanel = False
                'Me.UToolbarsManagerMain.Tools("popUpSuchkriterien").SharedProps.Caption = "Suche nach Schlagwort"

                Case eSuchauswahl.keine
                    Me.ContArchivSuch1.UltraGroupBoxSucheInOrdnern.Visible = False
                    Me.ContArchivSuch1.PanelErweiterteSuchangaben.Visible = False
                    Me.ContArchivSuch1.UltraGroupBoxSchlagwörter.Visible = False
                    Me.ContArchivSuch1.SplitContainer1.SplitterDistance = Me.ContArchivSuch1.SplitContainer1.Width
                    Me.ContArchivSuch1.SplitContainer1.FixedPanel = False
                    'Me.UToolbarsManagerMain.Tools("popUpSuchkriterien").SharedProps.Caption = "Suchkriterien"

            End Select

        Catch ex As Exception
            Throw New Exception("setSuchauwahlUI: " + ex.ToString())
        End Try
    End Sub
    Private Sub FormDokuSys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub initArchiv()
        Dim General As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.btnAdd2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.setSuchauwahlUI(eSuchauswahl.keine)
            Me.showErgebniss_ansicht(0)

            'General.SetProcessingWorkSize()
            Me.startTyp = eStart.gesamtsystem
            Me.oMainArchiv = Me
            'Me.LoadStartWindow()

            Dim clArchiv As New cArchive
            Dim generalMain As New GeneralArchiv

            'Dim uiMenü As New clUIElements
            'Me.contZwischenablage = New contZwischenablage
            'uiMenü.Menu_loadContainer(Me.UToolbarsManagerMain, 0, Me.contZwischenablage, "Zwischenablage")
            Me.isloaded = True

        Catch ex As Exception
            Throw New Exception("initArchiv: " + ex.ToString())
        Finally
            Dim genMain As New GeneralArchiv
            genMain.GarbColl()
            Me.resizeControl()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub loadArchiv(ByVal typ As eStart, doInit As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not Me.isloaded Then Me.initArchiv()

            Me.startTyp = typ
            If Me.startTyp = eStart.Search Then
                Me.LoadDokumenteSuchen(False, doInit)
            ElseIf Me.startTyp = eStart.gesamtsystem Then
                Me.LoadDokumenteSuchen(True, doInit)
            Else
                Me.LoadDokumenteSuchen(True, doInit)
            End If

            Me.ContArchivSuch1.PanelBenutzerauswahl.Visible = False
            Me.ContArchivSuch1.cboSachbearbeiter.Value = Nothing
            Me.ContArchivSuch1.UCheckEditorImGesamtarchivSuchen.Checked = False

            If Me.startTyp = eStart.gesamtsystem Then
                'If PMDS.Global.ENV.HasRight([Global].UserRights.ArchivTerminMailSucheGesamt) Then
                '    Me.ContArchivSuch1.UCheckEditorImGesamtarchivSuchen.Visible = True
                'End If
                Me.ContArchivSuch1.UCheckEditorImGesamtarchivSuchen.Visible = True
            Else
                Me.ContArchivSuch1.UCheckEditorImGesamtarchivSuchen.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("loadArchiv: " + ex.ToString())
        Finally
            Dim o As New Object
            Dim evArg As New EventArgs
            Me.Main_Resize(o, evArg)

            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub setObjekts(ByVal arr As ArrayList)
        Try
            Me.objects.Clear()
            For Each ob As clObject In arr
                Me.objects.Add(ob)
            Next

        Catch ex As Exception
            Throw New Exception("setObjekts: " + ex.ToString())
        End Try
    End Sub
    Public Sub clearObjects()
        Try
            Me.objects.Clear()

        Catch ex As Exception
            Throw New Exception("setObjekts: " + ex.ToString())
        End Try
    End Sub
    Public Function writeTitel() As String
        Dim General As New GeneralArchiv
        Try
            If Me.startTyp = eStart.Search Then
                Return "Archivsystem"
            ElseIf Me.startTyp = eStart.gesamtsystem Then
                Return "Archivsystem gesamt"
            End If

        Catch ex As Exception
            Throw New Exception("writeTitel: " + ex.ToString())
        End Try
    End Function

    Public Sub LoadDokumenteSuchen(ByVal dummy As Boolean, doInit As Boolean)
        Try
            Me.ContArchivSuch1.objects = Me.objects
            Me.LoadForm()
            Me.ContArchivSuch1.mainWindow = Me
            Me.ContArchivSuch1.DokumenteSuchenMitObjects(Me.objects, dummy, doInit)
            Me.Text = Me.writeTitel + "  [Dokumente suchen]"

        Catch ex As Exception
            Throw New Exception("LoadDokumenteSuchen: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub initForm()
        Try

        Catch ex As Exception
            Throw New Exception("initForm: " + ex.ToString())
        End Try
    End Sub

    Private Sub LoadForm()
        Try
            ContArchivSuch1.initForm()

        Catch ex As Exception
            Throw New Exception("LoadForm: " + ex.ToString())
        End Try
    End Sub

    Private Sub ArchivMainArchivsystem_RegionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RegionChanged

    End Sub

    Private Sub Main_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            Me.resizeControl()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Public Sub resizeControl()
        Try
            Me.ContArchivSuch1.ResizeControl(Me.ContArchivSuch1.Height, Me.ContArchivSuch1.Width)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub


    Private Sub Zwischenablage_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Public Function logIn() As Boolean
        Dim general As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            'Dim BenutzerITSCont As New S2CoreSystem.BenutzerITSCont
            'Dim DOManagement As New S2UI.DOManagement
            'Dim DatabaseITSCont As New S2CoreSystemDatabase.DatabaseITSCont
            'Dim res As New S2CoreSystem.DatabaseITSContAdmin.StateConnect
            'Dim DatabaseITSContAdmin As New S2CoreSystem.DatabaseITSContAdmin
            'res = DatabaseITSContAdmin.ConnectAdminDB()

            'If res = DatabaseITSContAdmin.StateConnect.KeineAdminDatenbankXMLFile Then
            '    Dim Reg As New S2LogIn.Register
            '    DOManagement.ShowStart(False)
            '    Reg.typ = S2LogIn.Register.eTyp.nreReg
            '    Reg.ShowDialog()
            '    If Reg.apport Then Exit Function
            '    res = New S2CoreSystem.DatabaseITSContAdmin.StateConnect
            '    res = DatabaseITSContAdmin.ConnectAdminDB()

            '    If General.Check_ServerDatabase(DatabaseITSContAdmin.Admin_Server, DatabaseITSContAdmin.Admin_Database, DatabaseITSContAdmin.Admin_User, DatabaseITSContAdmin.Admin_Password) Then
            '        DatabaseITSContAdmin = New S2CoreSystem.DatabaseITSContAdmin
            '        DatabaseITSContAdmin.Connect()
            '        If Not General.IsNull(General.Country) Then
            '            BenutzerITSCont.SettingsSaveAll("DefaultCountry", DatabaseITSContAdmin.SettingsTyp.SText, CObj(General.Country))
            '            General.Country = BenutzerITSCont.SettingsReadAll("DefaultCountry", DatabaseITSContAdmin.SettingsTyp.SText)
            '        End If
            '    Else

            '        MsgBox("Datenbankverbindung zur Administrationsdatenbank kann nicht hergestellt werden!" + vbCr + _
            '                    "Bitte wenden Sie sich an ihren Systemadministrator ..." + vbCr + _
            '                    "ITSCont wird beendet!", MsgBoxStyle.Information, "ITSCont Datenbankanbindung ...")
            '        General.Start.CLOSE_App()
            '    End If

            'End If
            'If res = DatabaseITSContAdmin.StateConnect.Fehler Or res = DatabaseITSContAdmin.StateConnect.Verbindungsfehler Then
            '    MsgBox("Datenbankverbindung zur Administrationsdatenbank kann nicht hergestellt werden!" + vbCr + _
            '                "Bitte wenden Sie sich an ihren Systemadministrator ..." + vbCr + _
            '                "ITSCont wird beendet!", MsgBoxStyle.Information, "ITSCont Datenbankanbindung ...")
            '    General.Start.CLOSE_App()

            'ElseIf res = DatabaseITSContAdmin.StateConnect.OK Then
            '    Dim LoginModeR As New General.eLogin_Mode_ret
            '    LoginModeR = Me.OpenLogIn(General.eLogin_Mode.hochfahren)
            '    BenutzerITSCont.ReadBenutzerdaten(True)

            'End If

        Catch ex As Exception
            Throw New Exception("logIn: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.WaitCursor
        End Try
    End Function

    Private Sub UToolbarsManagerMain_ToolKeyPress(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolKeyPressEventArgs) Handles UToolbarsManagerMain.ToolKeyPress
        Dim general As New GeneralArchiv
        Try
            Select Case Asc(e.KeyChar)
                Case 13
                    If e.Tool.Key = "txtDokumentname" Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim txtTool As TextBoxTool = e.Tool
                        'If txtTool.Text <> "Schnellsuche (Strg+S)" And txtTool.Text <> "" Then
                        If txtTool.Text <> "Schnellsuche (Strg+S)" Then
                            Me.ContArchivSuch1.DokumentSuchen(False, False, False)
                        End If
                        Me.Cursor = Cursors.Default
                    End If

            End Select

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            IDOrdner = Me.ContArchivSuch1.contOrdnerErgebniss.GetSelectedOrd()
            Me.ContArchivSuch1.DokumentHinzufügen(IDOrdner)

            Me.resizeControl()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


End Class
