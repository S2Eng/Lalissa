Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms



Public Class contPlanungMain
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

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents PanelGesamt As System.Windows.Forms.Panel
    Friend WithEvents PanelErweiterteSuche As System.Windows.Forms.Panel
    Public WithEvents UDateBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Public WithEvents UDateVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBoxSucheInOrdner As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents layErwSuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UCheckEditorImGesamtsystemSuchen As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UGroupBoxDatum As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents PanelToolbar1 As System.Windows.Forms.Panel
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar1_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents PanelToolbar2 As System.Windows.Forms.Panel
    Friend WithEvents PanelToolbar As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents PanelAll As System.Windows.Forms.Panel
    Public WithEvents UOptionDatumErstelltGesendet2 As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnAdd2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelBenPostfächer As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffStatus")
        Dim OptionSet2 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffStatusGesendet")
        Dim OptionSet3 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffAnsicht")
        Dim OptionSet4 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffSucheNach")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim PopupMenuTool4 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpBetreff")
        Dim TextBoxTool2 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("txtSuchText")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSuchen")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttZurücksetzen")
        Dim StateButtonTool20 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("buttStatErweiterteSuche", "")
        Dim LabelTool6 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim PopupMenuTool5 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpStatus")
        Dim PopupMenuTool6 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpSendestatus")
        Dim LabelTool9 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space02")
        Dim StateButtonTool9 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtMonat", "lblOnOffAnsicht")
        Dim StateButtonTool10 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtWoche", "lblOnOffAnsicht")
        Dim StateButtonTool11 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTag", "lblOnOffAnsicht")
        Dim StateButtonTool12 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtListe", "lblOnOffAnsicht")
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffAnsicht")
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtMonat", "lblOnOffAnsicht")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtWoche", "lblOnOffAnsicht")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool7 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtTag", "lblOnOffAnsicht")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool8 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtListe", "lblOnOffAnsicht")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSuchen")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contPlanungMain))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim TextBoxTool1 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("txtSuchText")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpStatus")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtOffen", "lblOnOffStatus")
        Dim StateButtonTool13 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtErledigt", "lblOnOffStatus")
        Dim StateButtonTool14 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAlle", "lblOnOffStatus")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffStatus")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtOffen", "lblOnOffStatus")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtErledigt", "lblOnOffStatus")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAlle", "lblOnOffStatus")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttZurücksetzen")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool3 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpBetreff")
        Dim StateButtonTool17 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtBetreff", "lblOnOffSucheNach")
        Dim StateButtonTool18 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtText", "lblOnOffSucheNach")
        Dim StateButtonTool15 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtBetreff", "lblOnOffSucheNach")
        Dim StateButtonTool16 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtText", "lblOnOffSucheNach")
        Dim LabelTool4 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffSucheNach")
        Dim PopupControlContainerTool1 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContBenutzer")
        Dim StateButtonTool19 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("buttStatErweiterteSuche", "")
        Dim StateButtonTool21 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailGesendet", "lblOnOffStatusGesendet")
        Dim StateButtonTool22 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailEntwürfe", "lblOnOffStatusGesendet")
        Dim StateButtonTool23 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailAlle", "lblOnOffStatusGesendet")
        Dim LabelTool3 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffStatusGesendet")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpSendestatus")
        Dim StateButtonTool24 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailGesendet", "lblOnOffStatusGesendet")
        Dim StateButtonTool25 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailEntwürfe", "lblOnOffStatusGesendet")
        Dim StateButtonTool26 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButMailAlle", "lblOnOffStatusGesendet")
        Dim LabelTool5 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space01")
        Dim LabelTool8 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("space02")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelToolbar1 = New System.Windows.Forms.Panel()
        Me._PanelToolbar1_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar1_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelErweiterteSuche = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxSucheInOrdner = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UGroupBoxDatum = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UOptionDatumErstelltGesendet2 = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.UDateBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDateVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.UCheckEditorImGesamtsystemSuchen = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.btnAdd2 = New Infragistics.Win.Misc.UltraButton()
        Me.PanelGesamt = New System.Windows.Forms.Panel()
        Me.PanelBenPostfächer = New System.Windows.Forms.Panel()
        Me.layErwSuche = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.PanelToolbar2 = New System.Windows.Forms.Panel()
        Me.PanelToolbar = New System.Windows.Forms.Panel()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.PanelAll = New System.Windows.Forms.Panel()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolbar1.SuspendLayout()
        Me.PanelErweiterteSuche.SuspendLayout()
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSucheInOrdner.SuspendLayout()
        CType(Me.UGroupBoxDatum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UGroupBoxDatum.SuspendLayout()
        CType(Me.UOptionDatumErstelltGesendet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UCheckEditorImGesamtsystemSuchen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelGesamt.SuspendLayout()
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolbar2.SuspendLayout()
        Me.PanelToolbar.SuspendLayout()
        Me.PanelAll.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraToolbarsManager1
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraToolbarsManager1.Appearance = Appearance1
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me.PanelToolbar1
        Me.UltraToolbarsManager1.LockToolbars = True
        OptionSet1.AllowAllUp = False
        OptionSet2.AllowAllUp = False
        OptionSet3.AllowAllUp = False
        OptionSet4.AllowAllUp = False
        Me.UltraToolbarsManager1.OptionSets.Add(OptionSet1)
        Me.UltraToolbarsManager1.OptionSets.Add(OptionSet2)
        Me.UltraToolbarsManager1.OptionSets.Add(OptionSet3)
        Me.UltraToolbarsManager1.OptionSets.Add(OptionSet4)
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager1.ShowQuickCustomizeButton = False
        Me.UltraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        PopupMenuTool4.InstanceProps.IsFirstInGroup = True
        StateButtonTool20.InstanceProps.IsFirstInGroup = True
        StateButtonTool9.Checked = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool4, TextBoxTool2, ButtonTool2, ButtonTool4, StateButtonTool20, LabelTool6, PopupMenuTool5, PopupMenuTool6, LabelTool9, StateButtonTool9, StateButtonTool10, StateButtonTool11, StateButtonTool12})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        LabelTool2.SharedPropsInternal.Caption = "lblOnOffAnsicht"
        StateButtonTool5.Checked = True
        StateButtonTool5.OptionSetKey = "lblOnOffAnsicht"
        Appearance2.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColorDisabled = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool5.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance3
        StateButtonTool5.SharedPropsInternal.Caption = "Monat"
        StateButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool5.SharedPropsInternal.ToolTipText = "Darstellung Monatsansicht"
        StateButtonTool5.SharedPropsInternal.ToolTipTitle = "Monat"
        StateButtonTool6.OptionSetKey = "lblOnOffAnsicht"
        Appearance4.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool6.SharedPropsInternal.AppearancesSmall.Appearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColorDisabled = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool6.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance5
        StateButtonTool6.SharedPropsInternal.Caption = "Woche"
        StateButtonTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool6.SharedPropsInternal.ToolTipText = "Darstellung Wochenansicht"
        StateButtonTool6.SharedPropsInternal.ToolTipTitle = "Woche"
        StateButtonTool7.OptionSetKey = "lblOnOffAnsicht"
        Appearance6.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColorDisabled = System.Drawing.Color.White
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool7.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance7
        StateButtonTool7.SharedPropsInternal.Caption = "Tag"
        StateButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool7.SharedPropsInternal.ToolTipText = "Darstellung Tagesansicht"
        StateButtonTool7.SharedPropsInternal.ToolTipTitle = "Tag"
        StateButtonTool8.OptionSetKey = "lblOnOffAnsicht"
        Appearance8.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColorDisabled2 = System.Drawing.Color.White
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.ForeColor = System.Drawing.Color.RoyalBlue
        StateButtonTool8.SharedPropsInternal.AppearancesSmall.PressedAppearance = Appearance9
        StateButtonTool8.SharedPropsInternal.Caption = "Liste"
        StateButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool8.SharedPropsInternal.ToolTipText = "Darstellung Tabellenansicht"
        StateButtonTool8.SharedPropsInternal.ToolTipTitle = "Liste"
        Appearance10.Image = CType(resources.GetObject("Appearance10.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesLarge.Appearance = Appearance10
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesSmall.Appearance = Appearance11
        ButtonTool1.SharedPropsInternal.Caption = "Suchen"
        ButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool1.SharedPropsInternal.ToolTipText = "Suche durchführen"
        Appearance12.BackColor = System.Drawing.Color.White
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackColorDisabled = System.Drawing.Color.White
        Appearance12.BackColorDisabled2 = System.Drawing.Color.White
        Appearance12.FontData.ItalicAsString = "True"
        TextBoxTool1.EditAppearance = Appearance12
        TextBoxTool1.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        TextBoxTool1.SharedPropsInternal.Width = 165
        TextBoxTool1.Text = "Schnellsuche (Strg+S)"
        PopupMenuTool1.SharedPropsInternal.Caption = "Status"
        StateButtonTool4.Checked = True
        StateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool13.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool14.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool4, StateButtonTool13, StateButtonTool14})
        LabelTool1.SharedPropsInternal.Caption = "lblOnOffStatus"
        StateButtonTool1.Checked = True
        StateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool1.OptionSetKey = "lblOnOffStatus"
        StateButtonTool1.SharedPropsInternal.Caption = "Offen"
        StateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool2.OptionSetKey = "lblOnOffStatus"
        StateButtonTool2.SharedPropsInternal.Caption = "Erledigt"
        StateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool3.OptionSetKey = "lblOnOffStatus"
        StateButtonTool3.SharedPropsInternal.Caption = "Alle"
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        ButtonTool3.SharedPropsInternal.AppearancesLarge.Appearance = Appearance13
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        ButtonTool3.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        ButtonTool3.SharedPropsInternal.Caption = "Neu laden"
        PopupMenuTool3.SharedPropsInternal.Caption = "Betreff"
        StateButtonTool17.Checked = True
        StateButtonTool17.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool18.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool3.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool17, StateButtonTool18})
        StateButtonTool15.Checked = True
        StateButtonTool15.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool15.OptionSetKey = "lblOnOffSucheNach"
        StateButtonTool15.SharedPropsInternal.Caption = "Betreff"
        StateButtonTool16.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool16.OptionSetKey = "lblOnOffSucheNach"
        StateButtonTool16.SharedPropsInternal.Caption = "Text"
        LabelTool4.SharedPropsInternal.Caption = "lblOnOffSucheNach"
        PopupControlContainerTool1.ControlName = "PanelBenPostfächer"
        PopupControlContainerTool1.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.Standard
        PopupControlContainerTool1.SharedPropsInternal.Caption = "Benutzer"
        PopupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool19.SharedPropsInternal.Caption = "Erweiterte Suche"
        StateButtonTool19.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool21.Checked = True
        StateButtonTool21.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool21.OptionSetKey = "lblOnOffStatusGesendet"
        StateButtonTool21.SharedPropsInternal.Caption = "Gesendet"
        StateButtonTool22.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool22.OptionSetKey = "lblOnOffStatusGesendet"
        StateButtonTool22.SharedPropsInternal.Caption = "Entwürfe"
        StateButtonTool23.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool23.OptionSetKey = "lblOnOffStatusGesendet"
        StateButtonTool23.SharedPropsInternal.Caption = "Alle"
        LabelTool3.SharedPropsInternal.Caption = "lblOnOffStatusGesendet"
        PopupMenuTool2.SharedPropsInternal.Caption = "Status"
        StateButtonTool24.Checked = True
        StateButtonTool24.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool25.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool26.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool2.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool24, StateButtonTool25, StateButtonTool26})
        LabelTool5.SharedPropsInternal.Width = 110
        LabelTool8.SharedPropsInternal.Width = 130
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool2, StateButtonTool5, StateButtonTool6, StateButtonTool7, StateButtonTool8, ButtonTool1, TextBoxTool1, PopupMenuTool1, LabelTool1, StateButtonTool1, StateButtonTool2, StateButtonTool3, ButtonTool3, PopupMenuTool3, StateButtonTool15, StateButtonTool16, LabelTool4, PopupControlContainerTool1, StateButtonTool19, StateButtonTool21, StateButtonTool22, StateButtonTool23, LabelTool3, PopupMenuTool2, LabelTool5, LabelTool8})
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
        Me.PanelToolbar1.Size = New System.Drawing.Size(931, 27)
        Me.PanelToolbar1.TabIndex = 69
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Left
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Name = "_PanelToolbar1_Toolbars_Dock_Area_Left"
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Right
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(931, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Name = "_PanelToolbar1_Toolbars_Dock_Area_Right"
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Bottom
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Name = "_PanelToolbar1_Toolbars_Dock_Area_Bottom"
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(931, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolbar1_Toolbars_Dock_Area_Top
        '
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Name = "_PanelToolbar1_Toolbars_Dock_Area_Top"
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(931, 27)
        Me._PanelToolbar1_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'PanelErweiterteSuche
        '
        Me.PanelErweiterteSuche.BackColor = System.Drawing.Color.Transparent
        Me.PanelErweiterteSuche.Controls.Add(Me.UltraGroupBoxSucheInOrdner)
        Me.PanelErweiterteSuche.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelErweiterteSuche.Location = New System.Drawing.Point(0, 0)
        Me.PanelErweiterteSuche.Name = "PanelErweiterteSuche"
        Me.PanelErweiterteSuche.Size = New System.Drawing.Size(1053, 88)
        Me.PanelErweiterteSuche.TabIndex = 0
        Me.PanelErweiterteSuche.Visible = False
        '
        'UltraGroupBoxSucheInOrdner
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSucheInOrdner.Appearance = Appearance15
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UGroupBoxDatum)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UCheckEditorImGesamtsystemSuchen)
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.layErwSuche.SetGridBagConstraint(Me.UltraGroupBoxSucheInOrdner, GridBagConstraint1)
        Me.UltraGroupBoxSucheInOrdner.Location = New System.Drawing.Point(5, 5)
        Me.UltraGroupBoxSucheInOrdner.Name = "UltraGroupBoxSucheInOrdner"
        Me.layErwSuche.SetPreferredSize(Me.UltraGroupBoxSucheInOrdner, New System.Drawing.Size(797, 60))
        Me.UltraGroupBoxSucheInOrdner.Size = New System.Drawing.Size(1043, 78)
        Me.UltraGroupBoxSucheInOrdner.TabIndex = 0
        Me.UltraGroupBoxSucheInOrdner.Text = "Erweiterte Suchangaben"
        '
        'UGroupBoxDatum
        '
        Me.UGroupBoxDatum.Controls.Add(Me.UOptionDatumErstelltGesendet2)
        Me.UGroupBoxDatum.Controls.Add(Me.UDateBis)
        Me.UGroupBoxDatum.Controls.Add(Me.UDateVon)
        Me.UGroupBoxDatum.Controls.Add(Me.UltraLabel11)
        Me.UGroupBoxDatum.Controls.Add(Me.UltraLabel7)
        Me.UGroupBoxDatum.Location = New System.Drawing.Point(14, 21)
        Me.UGroupBoxDatum.Name = "UGroupBoxDatum"
        Me.UGroupBoxDatum.Size = New System.Drawing.Size(335, 49)
        Me.UGroupBoxDatum.TabIndex = 0
        Me.UGroupBoxDatum.Text = "Datum"
        '
        'UOptionDatumErstelltGesendet2
        '
        Me.UOptionDatumErstelltGesendet2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        ValueListItem3.DataValue = "ErstelltAm"
        ValueListItem3.DisplayText = "Erstellt"
        ValueListItem4.DataValue = "gesendetAm"
        ValueListItem4.DisplayText = "Gesendet"
        Me.UOptionDatumErstelltGesendet2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.UOptionDatumErstelltGesendet2.Location = New System.Drawing.Point(259, 15)
        Me.UOptionDatumErstelltGesendet2.Name = "UOptionDatumErstelltGesendet2"
        Me.UOptionDatumErstelltGesendet2.Size = New System.Drawing.Size(70, 28)
        Me.UOptionDatumErstelltGesendet2.TabIndex = 2
        Me.UOptionDatumErstelltGesendet2.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UDateBis
        '
        Appearance16.BackColor = System.Drawing.Color.White
        Me.UDateBis.Appearance = Appearance16
        Me.UDateBis.BackColor = System.Drawing.Color.White
        Me.UDateBis.DateTime = New Date(2008, 11, 3, 0, 0, 0, 0)
        Me.UDateBis.Location = New System.Drawing.Point(163, 19)
        Me.UDateBis.Name = "UDateBis"
        Me.UDateBis.Size = New System.Drawing.Size(91, 21)
        Me.UDateBis.TabIndex = 2
        Me.UDateBis.Value = New Date(2008, 11, 3, 0, 0, 0, 0)
        '
        'UDateVon
        '
        Appearance17.BackColor = System.Drawing.Color.White
        Me.UDateVon.Appearance = Appearance17
        Me.UDateVon.BackColor = System.Drawing.Color.White
        Me.UDateVon.DateTime = New Date(2008, 11, 3, 0, 0, 0, 0)
        Me.UDateVon.Location = New System.Drawing.Point(44, 19)
        Me.UDateVon.Name = "UDateVon"
        Me.UDateVon.Size = New System.Drawing.Size(91, 21)
        Me.UDateVon.TabIndex = 1
        Me.UDateVon.Value = New Date(2008, 11, 3, 0, 0, 0, 0)
        '
        'UltraLabel11
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance18
        Me.UltraLabel11.Location = New System.Drawing.Point(16, 22)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(76, 16)
        Me.UltraLabel11.TabIndex = 390
        Me.UltraLabel11.Text = "Von"
        '
        'UltraLabel7
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel7.Appearance = Appearance19
        Me.UltraLabel7.Location = New System.Drawing.Point(140, 22)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(24, 16)
        Me.UltraLabel7.TabIndex = 389
        Me.UltraLabel7.Text = "bis"
        '
        'UCheckEditorImGesamtsystemSuchen
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtsystemSuchen.Appearance = Appearance20
        Me.UCheckEditorImGesamtsystemSuchen.BackColor = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtsystemSuchen.BackColorInternal = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtsystemSuchen.Location = New System.Drawing.Point(368, 42)
        Me.UCheckEditorImGesamtsystemSuchen.Name = "UCheckEditorImGesamtsystemSuchen"
        Me.UCheckEditorImGesamtsystemSuchen.Size = New System.Drawing.Size(259, 18)
        Me.UCheckEditorImGesamtsystemSuchen.TabIndex = 1
        Me.UCheckEditorImGesamtsystemSuchen.Text = "Im gesamten System suchen"
        Me.UCheckEditorImGesamtsystemSuchen.Visible = False
        '
        'btnAdd2
        '
        Appearance21.Image = "ICO_plusNeu.ico"
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.btnAdd2.Appearance = Appearance21
        Me.btnAdd2.Location = New System.Drawing.Point(10, 2)
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.Size = New System.Drawing.Size(26, 24)
        Me.btnAdd2.TabIndex = 2
        '
        'PanelGesamt
        '
        Me.PanelGesamt.Controls.Add(Me.PanelBenPostfächer)
        Me.PanelGesamt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGesamt.Location = New System.Drawing.Point(0, 88)
        Me.PanelGesamt.Name = "PanelGesamt"
        Me.PanelGesamt.Size = New System.Drawing.Size(1053, 371)
        Me.PanelGesamt.TabIndex = 0
        '
        'PanelBenPostfächer
        '
        Me.PanelBenPostfächer.Location = New System.Drawing.Point(74, 78)
        Me.PanelBenPostfächer.Name = "PanelBenPostfächer"
        Me.PanelBenPostfächer.Size = New System.Drawing.Size(213, 244)
        Me.PanelBenPostfächer.TabIndex = 1
        '
        'layErwSuche
        '
        Me.layErwSuche.ContainerControl = Me.PanelErweiterteSuche
        Me.layErwSuche.ExpandToFitHeight = True
        Me.layErwSuche.ExpandToFitWidth = True
        '
        'PanelToolbar2
        '
        Me.PanelToolbar2.Controls.Add(Me.btnAdd2)
        Me.PanelToolbar2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelToolbar2.Location = New System.Drawing.Point(1008, 0)
        Me.PanelToolbar2.Name = "PanelToolbar2"
        Me.PanelToolbar2.Size = New System.Drawing.Size(45, 27)
        Me.PanelToolbar2.TabIndex = 68
        '
        'PanelToolbar
        '
        Me.PanelToolbar.Controls.Add(Me.PanelToolbar1)
        Me.PanelToolbar.Controls.Add(Me.PanelToolbar2)
        Me.PanelToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelToolbar.Location = New System.Drawing.Point(0, 0)
        Me.PanelToolbar.Name = "PanelToolbar"
        Me.PanelToolbar.Size = New System.Drawing.Size(1053, 27)
        Me.PanelToolbar.TabIndex = 69
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'PanelAll
        '
        Me.PanelAll.Controls.Add(Me.PanelGesamt)
        Me.PanelAll.Controls.Add(Me.PanelErweiterteSuche)
        Me.PanelAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAll.Location = New System.Drawing.Point(0, 27)
        Me.PanelAll.Name = "PanelAll"
        Me.PanelAll.Size = New System.Drawing.Size(1053, 459)
        Me.PanelAll.TabIndex = 70
        '
        'contPlanungMain
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelAll)
        Me.Controls.Add(Me.PanelToolbar)
        Me.Name = "contPlanungMain"
        Me.Size = New System.Drawing.Size(1053, 486)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolbar1.ResumeLayout(False)
        Me.PanelErweiterteSuche.ResumeLayout(False)
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSucheInOrdner.ResumeLayout(False)
        CType(Me.UGroupBoxDatum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UGroupBoxDatum.ResumeLayout(False)
        Me.UGroupBoxDatum.PerformLayout()
        CType(Me.UOptionDatumErstelltGesendet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UCheckEditorImGesamtsystemSuchen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelGesamt.ResumeLayout(False)
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolbar2.ResumeLayout(False)
        Me.PanelToolbar.ResumeLayout(False)
        Me.PanelAll.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public gen As New GeneralArchiv
    Public contBenPostfächer As New contBenPostfächer

    Public _id As New System.Guid
    Public _typ As New GeneralArchiv.eTypPlanung
    Public _patient As String = ""
    Public _isGesamt As Boolean = False

    Public contPlanung As New contPlanung
    Public isLoaded As Boolean = False

    Public mainWindow As Object






    Private Sub UltraToolbarsManager1_AfterToolActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles UltraToolbarsManager1.AfterToolActivate
        Try
            Select Case e.Tool.Key
                Case "txtSuchText"
                    Dim txtTool As TextBoxTool = e.Tool
                    If txtTool.Text = "Schnellsuche (Strg+S)" Then
                        txtTool.Text = ""
                        txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                        txtTool.SharedProps.AppearancesLarge.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                    End If

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UltraToolbarsManager1_AfterToolDeactivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles UltraToolbarsManager1.AfterToolDeactivate
        Try
            Select Case e.Tool.Key
                Case "txtSuchText"
                    Dim txtTool As TextBoxTool = e.Tool
                    If txtTool.Text = "" Then
                        txtTool.Text = "Schnellsuche (Strg+S)"
                        txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        txtTool.SharedProps.AppearancesLarge.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                    Else
                        txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                        txtTool.SharedProps.AppearancesLarge.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                    End If

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                'Case "Postausgang"
                '    exch.CallAppliction = General.InitApplicationAufgabenTermine.Postausgang
                '    ContPlanung1.InitForm(exch)

                'Case "Posteingang"
                '    exch.CallAppliction = General.InitApplicationAufgabenTermine.Posteingang
                '    ContPlanung1.InitForm(exch)

                'Case "Alle"
                '    exch.CallAppliction = General.InitApplicationAufgabenTermine.PosteingangPostausgang
                '    ContPlanung1.InitForm(exch)


                Case "statButtMonat"
                    Me.contPlanung.ShowTab(0)
                    Me.contPlanung.PanelKalender.Visible = True
                Case "statButtWoche"
                    Me.contPlanung.ShowTab(1)
                    Me.contPlanung.PanelKalender.Visible = True
                Case "statButtTag"
                    Me.contPlanung.ShowTab(2)
                    Me.contPlanung.PanelKalender.Visible = True
                Case "statButtListe"
                    Me.contPlanung.ShowTab(3)
                    Me.contPlanung.PanelKalender.Visible = False


                Case "buttSuchen"
                    contPlanung.mailsTermineLaden()

                Case "buttZurücksetzen"
                    Me.zurücksetzen(False)

                Case "buttStatErweiterteSuche"
                    Dim statButt As StateButtonTool = e.Tool
                    If statButt.Checked Then
                        Me.PanelErweiterteSuche.Visible = True
                    Else
                        Me.PanelErweiterteSuche.Visible = False
                    End If


                Case "popUpSendestatus"

                Case "statButMailGesendet"

                Case "statButMailAlle"

                Case "statButMailEntwürfe"


            End Select

            Me.resizeControl(Me.Width, Me.Height)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraToolbarsManager1_ToolKeyPress(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolKeyPressEventArgs) Handles UltraToolbarsManager1.ToolKeyPress
        Dim general As New GeneralArchiv
        Try
            'Select Case e.Tool.Key
            '    Case "buttStatErweiterteSuche"
            '        Dim statButt As StateButtonTool = e.Tool
            '        If statButt.Checked Then
            '            Me.PanelErweiterteSuche.Visible = True
            '        Else
            '            Me.PanelErweiterteSuche.Visible = False
            '        End If
            '        Exit Sub
            'End Select

            Select Case Asc(e.KeyChar)
                Case 13
                    If e.Tool.Key = "txtSuchText" Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim txtTool As TextBoxTool = e.Tool
                        'If txtTool.Text <> "Schnellsuche (Strg+S)" And txtTool.Text <> "" Then
                        If txtTool.Text <> "Schnellsuche (Strg+S)" Then
                            contPlanung.mailsTermineLaden()
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


    Public Sub zurücksetzen(ByVal alles As Boolean)
        Try
            Dim txtTool As TextBoxTool = Me.UltraToolbarsManager1.Tools("txtSuchText")
            txtTool.Text = "Schnellsuche (Strg+S)"
            txtTool.SharedProps.AppearancesSmall.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            txtTool.SharedProps.AppearancesLarge.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True

            Dim statButt As StateButtonTool
            If alles Then
                statButt = Me.UltraToolbarsManager1.Tools("statButtAlle")
                statButt.Checked = True
                statButt = Me.UltraToolbarsManager1.Tools("statButMailAlle")
                statButt.Checked = True
            End If

            If Me._isGesamt Then
                Me.UDateVon.Value = Now.AddMonths(-6)
                Me.PanelErweiterteSuche.Visible = True
                statButt = Me.UltraToolbarsManager1.Tools("buttStatErweiterteSuche")
                statButt.Checked = True
            Else
                Me.UDateVon.Value = Nothing
                Me.PanelErweiterteSuche.Visible = False
                statButt = Me.UltraToolbarsManager1.Tools("buttStatErweiterteSuche")
                statButt.Checked = False
            End If

            Me.UOptionDatumErstelltGesendet2.Value = "ErstelltAm"
            Me.UDateBis.Value = Nothing
            Me.setAzahl_buttSuchen(0)

            Me.contPlanung.tblAdminAufgaben.tAufgaben.Rows.Clear()
            Me.contPlanung.clear()

            Me.resizeControl(Me.Width, Me.Height)

        Catch ex As Exception
            Throw New Exception("zurücksetzen: " + ex.ToString())
        End Try
    End Sub


    Private Sub PersonSchäden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.btnAdd2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub contPlanungMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Me.resizeControl(Me.Width, Me.Height)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub loadForm()
        Try
            Me.PanelGesamt.Controls.Add(Me.contPlanung)
            Me.contPlanung.mainWindow = Me

            'General.SetProcessingWorkSize()

            Me.PanelBenPostfächer.Controls.Add(Me.contBenPostfächer)

            'Me.contBenPostfächer.loadBenutzerauswahl()
            'Me.contBenPostfächer.loadGewählteBenutzer()

            'Me.UltraExplorerBar1.Groups(0).Text = "Postfach von " + userArPl.userAct.ToString

            Me.contPlanung.loadForm()
            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("loadForm: " + ex.ToString())
        End Try
    End Sub
    Public Sub initForm(ByVal typ As GeneralArchiv.eTypPlanung)
        Try
            Me.Cursor = Cursors.WaitCursor

            Me._typ = typ
            If Not Me.isLoaded Then Me.loadForm()

            Me.UCheckEditorImGesamtsystemSuchen.Visible = False
            If Me._isGesamt Then
                'If PMDS.Global.ENV.HasRight([Global].UserRights.ArchivTerminMailSucheGesamt) Then
                '    Me.UCheckEditorImGesamtsystemSuchen.Visible = True
                'End If
                Me.UCheckEditorImGesamtsystemSuchen.Visible = True
            End If

            If Me._typ = GeneralArchiv.eTypPlanung.mail Then
                Me.UOptionDatumErstelltGesendet2.Visible = True
                Me.UltraToolbarsManager1.Tools("statButtMonat").SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools("statButtWoche").SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools("statButtTag").SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools("statButtListe").SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools("space02").SharedProps.Visible = False

                Me.contPlanung.ShowTab(3)
                Me.contPlanung.PanelKalender.Visible = False

                Me.UltraToolbarsManager1.Tools("popUpSendestatus").SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools("popUpStatus").SharedProps.Visible = False

                Me.UCheckEditorImGesamtsystemSuchen.Text = "Im gesamten Mailsystem suchen"

                Dim inf As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
                inf.ToolTipText = "Neues E-Mail erstellen"
                inf.ToolTipTitle = "Neues E-Mail"
                UltraToolTipManager1.SetUltraToolTip(Me.btnAdd2, inf)

            ElseIf Me._typ = GeneralArchiv.eTypPlanung.termin Then
                Me.UOptionDatumErstelltGesendet2.Visible = False
                Me.UltraToolbarsManager1.Tools("popUpStatus").SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools("popUpSendestatus").SharedProps.Visible = False

                Me.UCheckEditorImGesamtsystemSuchen.Text = "Im gesamten Terminsystem suchen"

                Dim inf As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
                inf.ToolTipText = "Neuen Termin erstellen"
                inf.ToolTipTitle = "Neuer Termin"
                UltraToolTipManager1.SetUltraToolTip(Me.btnAdd2, inf)


            End If

            Me.zurücksetzen(True)

            'ContPlanung1.bezeichnung = ""   'Me.bezeichnung

            If Not Me._isGesamt Then contPlanung.mailsTermineLaden()

        Catch ex As Exception
            Throw New Exception("initForm: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function getTextauswahl() As String
        Try
            Dim txtTool As TextBoxTool = Me.UltraToolbarsManager1.Tools("txtSuchText")
            If txtTool.Text = "Schnellsuche (Strg+S)" Then
                Return ""
            Else
                Return txtTool.Text
            End If

        Catch ex As Exception
            Throw New Exception("getTextauswahl: " + ex.ToString())
        End Try
    End Function
    Public Function getAuswahlStatusTermine_str() As String
        Try
            Dim statButt As StateButtonTool = Me.UltraToolbarsManager1.Tools("statButtOffen")
            If statButt.Checked Then Return "Offen"

            statButt = Me.UltraToolbarsManager1.Tools("statButtErledigt")
            If statButt.Checked Then Return "Erledigt"

            statButt = Me.UltraToolbarsManager1.Tools("statButtAlle")
            If statButt.Checked Then Return ""

        Catch ex As Exception
            Throw New Exception("getAuswahlStatusTermine_str: " + ex.ToString())
        End Try
    End Function
    Public Function getAuswahlStatusMail_str() As GeneralArchiv.eAuswahlStatusMail
        Try
            Dim statButt As StateButtonTool = Me.UltraToolbarsManager1.Tools("statButMailGesendet")
            If statButt.Checked Then Return GeneralArchiv.eAuswahlStatusMail.gesendet

            statButt = Me.UltraToolbarsManager1.Tools("statButMailAlle")
            If statButt.Checked Then Return GeneralArchiv.eAuswahlStatusMail.alle

            statButt = Me.UltraToolbarsManager1.Tools("statButMailEntwürfe")
            If statButt.Checked Then Return GeneralArchiv.eAuswahlStatusMail.entwürfe

        Catch ex As Exception
            Throw New Exception("getAuswahlStatusMail_str: " + ex.ToString())
        End Try
    End Function
    Public Function sucheBetreffUndText() As Boolean
        Try
            Dim statButt As StateButtonTool = Me.UltraToolbarsManager1.Tools("statButtText")
            If statButt.Checked Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("sucheBetreffUndText: " + ex.ToString())
        End Try
    End Function


    Public Sub refreshMailsTermine()
        Try
            Me.contPlanung.mailsTermineLaden()

        Catch ex As Exception
            Throw New Exception("refreshMailsTermine: " + ex.ToString())
        End Try
    End Sub
    Public Sub resizeControl(ByVal w As Double, ByVal h As Double)
        Try
            If Me.Visible Then
                Me.Width = w
                Me.Height = h
                If Not contPlanung Is Nothing Then contPlanung.SetWidthHeigth(Me.PanelGesamt.Width, PanelGesamt.Height)
            End If

        Catch ex As Exception
            Throw New Exception("resizeControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub setObjekt(ByVal id As String, ByVal patient As String)
        Try
            If id = "" Then
                Me._id = Nothing
            Else
                Me._id = gen.StrToGuid(id)
            End If
            Me._patient = patient

        Catch ex As Exception
            Throw New Exception("setObjekt: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadAuswahlPostfächer()
        Try

            Me.contPlanung.arrBenutzer = New ArrayList
            Dim bFound As Boolean = False
            For Each node As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.contBenPostfächer.UTreeBenutzer.Nodes
                If node.CheckedState = CheckState.Checked Then
                    Me.contPlanung.arrBenutzer.Add(node.Key)
                    bFound = True
                End If
            Next
            If bFound Then
                'Me.UltraExplorerBar1.Groups(0).Text = "Mehrere Postfächer ..."
            Else
                'Me.UltraExplorerBar1.Groups(0).Text = "Postfach von " + userArPl.userAct.ToString
            End If

        Catch ex As Exception
            Throw New Exception("loadAuswahlPostfächer: " + ex.ToString())
        End Try
    End Sub

    Public Sub setAzahl_buttSuchen(ByVal anz As Integer)
        Try
            Dim statButt As ButtonTool = Me.UltraToolbarsManager1.Tools("buttSuchen")
            If anz > 0 Then
                statButt.SharedProps.Caption = "Suchen (" + anz.ToString + ")"
            Else
                statButt.SharedProps.Caption = "Suchen"
            End If

        Catch ex As Exception
            Throw New Exception("setAzahl_buttSuchen: " + ex.ToString())
        End Try
    End Sub


    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me._typ = GeneralArchiv.eTypPlanung.mail Then
                Dim cl As New cMailTermine
                cl.Mail_Neu(Now, Now, IIf(gen.IsNull(Me), "", gen.GuidToStr(Me._id)),
                            IIf(gen.IsNull(Me), "", Me._patient),
                            Me, GeneralArchiv.eTypMail.an, Nothing)
            Else
                Me.contPlanung.neuerTermin(Me.contPlanung.getSelectedDate)
            End If

            Me.resizeControl(Me.Width, Me.Height)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
