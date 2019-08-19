<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class contPlansQuickInfo
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
        Me.components = New System.ComponentModel.Container()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim PopupControlContainerTool2 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpInfo")
        Dim PopupControlContainerTool1 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpInfo")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnMarkAsErledigt")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("plan", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BeginntAm")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FälligAm")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDArt")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Priorität")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailAn")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailCC")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("html")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Für")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("gesendetAm")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembJN")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembMinut")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("wichtig")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Teilnehmer")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDActivity")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStatus")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTyp")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KommStatus")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("db")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("deleted")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzObjects")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activity")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("design")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailBcc")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUserAccount")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailFrom")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("readed")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("empfangenAm")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MessageId")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzAnhänge")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPlanMain")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReplyTxt")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsOwner")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AwaitingResponse")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDFolder")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("typeTxt", 0)
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(255817788)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(21779674)
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAddPlan")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnMarkAsDone")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAddPlan")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnMarkAsDone")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelToolBar = New System.Windows.Forms.Panel()
        Me.PanelToolBar_Fill_Panel = New System.Windows.Forms.Panel()
        Me._PanelToolBar_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolBar_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolBar_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanelAll = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.grpInfo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.UltraGridBagLayoutPanelGrid = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel = New System.Windows.Forms.Panel()
        Me.gridPlansQuick = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlsErledigtMarkierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsPlanSearch1 = New dsPlanSearch()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me._PanelTop_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.toolbarQuickPlans = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelTop_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelTop_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelTop_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.dropDownInfo = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.contInfoBundles_Fill_Panel = New System.Windows.Forms.Panel()
        Me.CompPlan1 = New compPlan(Me.components)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelAll.SuspendLayout()
        CType(Me.grpInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInfo.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanelGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanelGrid.SuspendLayout()
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.SuspendLayout()
        CType(Me.gridPlansQuick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.toolbarQuickPlans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contInfoBundles_Fill_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 2800
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip
        Me.UltraToolTipManager1.InitialDelay = 0
        Me.UltraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me.PanelToolBar
        Me.UltraToolbarsManager1.LockToolbars = True
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager1.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupControlContainerTool2})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        PopupControlContainerTool1.ControlName = "PanelInfo"
        PopupControlContainerTool1.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.Standard
        PopupControlContainerTool1.SharedPropsInternal.Caption = "Info"
        PopupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool1.SharedPropsInternal.Caption = "Planungseinträge als erledigt markieren"
        ButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupControlContainerTool1, ButtonTool1})
        '
        'PanelToolBar
        '
        Me.PanelToolBar.Controls.Add(Me.PanelToolBar_Fill_Panel)
        Me.PanelToolBar.Controls.Add(Me._PanelToolBar_Toolbars_Dock_Area_Left)
        Me.PanelToolBar.Controls.Add(Me._PanelToolBar_Toolbars_Dock_Area_Right)
        Me.PanelToolBar.Controls.Add(Me._PanelToolBar_Toolbars_Dock_Area_Bottom)
        Me.PanelToolBar.Controls.Add(Me._PanelToolBar_Toolbars_Dock_Area_Top)
        Me.PanelToolBar.Location = New System.Drawing.Point(13, 167)
        Me.PanelToolBar.Name = "PanelToolBar"
        Me.PanelToolBar.Size = New System.Drawing.Size(171, 40)
        Me.PanelToolBar.TabIndex = 15
        Me.PanelToolBar.Visible = False
        '
        'PanelToolBar_Fill_Panel
        '
        Me.PanelToolBar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelToolBar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelToolBar_Fill_Panel.Location = New System.Drawing.Point(0, 23)
        Me.PanelToolBar_Fill_Panel.Name = "PanelToolBar_Fill_Panel"
        Me.PanelToolBar_Fill_Panel.Size = New System.Drawing.Size(171, 17)
        Me.PanelToolBar_Fill_Panel.TabIndex = 0
        '
        '_PanelToolBar_Toolbars_Dock_Area_Left
        '
        Me._PanelToolBar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolBar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolBar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelToolBar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolBar_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 23)
        Me._PanelToolBar_Toolbars_Dock_Area_Left.Name = "_PanelToolBar_Toolbars_Dock_Area_Left"
        Me._PanelToolBar_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 17)
        Me._PanelToolBar_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolBar_Toolbars_Dock_Area_Right
        '
        Me._PanelToolBar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolBar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolBar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelToolBar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolBar_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(171, 23)
        Me._PanelToolBar_Toolbars_Dock_Area_Right.Name = "_PanelToolBar_Toolbars_Dock_Area_Right"
        Me._PanelToolBar_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 17)
        Me._PanelToolBar_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolBar_Toolbars_Dock_Area_Top
        '
        Me._PanelToolBar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolBar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolBar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelToolBar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolBar_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelToolBar_Toolbars_Dock_Area_Top.Name = "_PanelToolBar_Toolbars_Dock_Area_Top"
        Me._PanelToolBar_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(171, 23)
        Me._PanelToolBar_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_PanelToolBar_Toolbars_Dock_Area_Bottom
        '
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 40)
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.Name = "_PanelToolBar_Toolbars_Dock_Area_Bottom"
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(171, 0)
        Me._PanelToolBar_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'PanelInfo
        '
        Me.PanelInfo.BackColor = System.Drawing.Color.DarkGray
        Me.PanelInfo.Controls.Add(Me.UltraGridBagLayoutPanelAll)
        Me.PanelInfo.Location = New System.Drawing.Point(225, 12)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(543, 238)
        Me.PanelInfo.TabIndex = 5
        '
        'UltraGridBagLayoutPanelAll
        '
        Me.UltraGridBagLayoutPanelAll.Controls.Add(Me.grpInfo)
        Me.UltraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelAll.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelAll.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelAll.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelAll.Name = "UltraGridBagLayoutPanelAll"
        Me.UltraGridBagLayoutPanelAll.Size = New System.Drawing.Size(543, 238)
        Me.UltraGridBagLayoutPanelAll.TabIndex = 1
        '
        'grpInfo
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Me.grpInfo.Appearance = Appearance2
        Me.grpInfo.Controls.Add(Me.PanelGrid)
        Me.grpInfo.Controls.Add(Me.PanelBottom)
        Me.grpInfo.Controls.Add(Me.PanelTop)
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 1
        GridBagConstraint2.Insets.Left = 1
        GridBagConstraint2.Insets.Right = 1
        GridBagConstraint2.Insets.Top = 1
        Me.UltraGridBagLayoutPanelAll.SetGridBagConstraint(Me.grpInfo, GridBagConstraint2)
        Me.grpInfo.Location = New System.Drawing.Point(1, 1)
        Me.grpInfo.Name = "grpInfo"
        Me.UltraGridBagLayoutPanelAll.SetPreferredSize(Me.grpInfo, New System.Drawing.Size(335, 128))
        Me.grpInfo.Size = New System.Drawing.Size(541, 236)
        Me.grpInfo.TabIndex = 0
        Me.grpInfo.Tag = "ResID.InfoBundle"
        Me.grpInfo.Text = "Wichtige Planungen"
        '
        'PanelGrid
        '
        Me.PanelGrid.BackColor = System.Drawing.Color.Transparent
        Me.PanelGrid.Controls.Add(Me.UltraGridBagLayoutPanelGrid)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(3, 44)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(535, 171)
        Me.PanelGrid.TabIndex = 3
        '
        'UltraGridBagLayoutPanelGrid
        '
        Me.UltraGridBagLayoutPanelGrid.Controls.Add(Me.UltraGridBagLayoutPanelGrid_Fill_Panel)
        Me.UltraGridBagLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanelGrid.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanelGrid.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelGrid.Name = "UltraGridBagLayoutPanelGrid"
        Me.UltraGridBagLayoutPanelGrid.Size = New System.Drawing.Size(535, 171)
        Me.UltraGridBagLayoutPanelGrid.TabIndex = 1
        '
        'UltraGridBagLayoutPanelGrid_Fill_Panel
        '
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Controls.Add(Me.gridPlansQuick)
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        Me.UltraGridBagLayoutPanelGrid.SetGridBagConstraint(Me.UltraGridBagLayoutPanelGrid_Fill_Panel, GridBagConstraint1)
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Name = "UltraGridBagLayoutPanelGrid_Fill_Panel"
        Me.UltraGridBagLayoutPanelGrid.SetPreferredSize(Me.UltraGridBagLayoutPanelGrid_Fill_Panel, New System.Drawing.Size(496, 146))
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.Size = New System.Drawing.Size(535, 171)
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.TabIndex = 0
        '
        'gridPlansQuick
        '
        Me.gridPlansQuick.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridPlansQuick.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridPlansQuick.DataMember = "plan"
        Me.gridPlansQuick.DataSource = Me.DsPlanSearch1
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.Black
        Me.gridPlansQuick.DisplayLayout.Appearance = Appearance3
        Me.gridPlansQuick.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 243
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn2.Width = 109
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn3.Width = 107
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.Header.VisiblePosition = 20
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.Header.VisiblePosition = 21
        UltraGridColumn21.Hidden = True
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.Header.VisiblePosition = 22
        UltraGridColumn22.Hidden = True
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.Header.VisiblePosition = 23
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.Header.VisiblePosition = 24
        UltraGridColumn24.Hidden = True
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.Header.VisiblePosition = 25
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.Header.VisiblePosition = 26
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.Header.VisiblePosition = 27
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn28.Header.VisiblePosition = 28
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.Header.VisiblePosition = 29
        UltraGridColumn29.Hidden = True
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.Header.VisiblePosition = 30
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn31.Header.VisiblePosition = 31
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn32.Header.VisiblePosition = 32
        UltraGridColumn32.Hidden = True
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn33.Header.VisiblePosition = 33
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn34.Header.VisiblePosition = 34
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn35.Header.VisiblePosition = 35
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn36.Header.VisiblePosition = 36
        UltraGridColumn36.Hidden = True
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn37.Header.VisiblePosition = 37
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn38.Header.VisiblePosition = 38
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn39.Header.VisiblePosition = 39
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn40.Header.VisiblePosition = 40
        UltraGridColumn40.Hidden = True
        UltraGridColumn42.Header.VisiblePosition = 41
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn41.Header.Caption = "Typ"
        UltraGridColumn41.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn42, UltraGridColumn41})
        Me.gridPlansQuick.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Appearance4.BackColor = System.Drawing.Color.Gainsboro
        Me.gridPlansQuick.DisplayLayout.CaptionAppearance = Appearance4
        Me.gridPlansQuick.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.gridPlansQuick.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridPlansQuick.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.gridPlansQuick.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridPlansQuick.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridPlansQuick.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.gridPlansQuick.DisplayLayout.MaxColScrollRegions = 1
        Me.gridPlansQuick.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridPlansQuick.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance9.ForeColor = System.Drawing.Color.Blue
        Me.gridPlansQuick.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.gridPlansQuick.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridPlansQuick.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.gridPlansQuick.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridPlansQuick.DisplayLayout.Override.CellAppearance = Appearance11
        Me.gridPlansQuick.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridPlansQuick.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.gridPlansQuick.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Me.gridPlansQuick.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridPlansQuick.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gridPlansQuick.DisplayLayout.Override.RowAlternateAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.gridPlansQuick.DisplayLayout.Override.RowAppearance = Appearance14
        Me.gridPlansQuick.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridPlansQuick.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        ValueList1.Key = "Users"
        ValueList2.Key = "Typ"
        Me.gridPlansQuick.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2})
        Me.gridPlansQuick.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gridPlansQuick.Location = New System.Drawing.Point(4, 4)
        Me.gridPlansQuick.Name = "gridPlansQuick"
        Me.gridPlansQuick.Size = New System.Drawing.Size(527, 167)
        Me.gridPlansQuick.TabIndex = 2
        Me.gridPlansQuick.Tag = "ResID.Bundle"
        Me.gridPlansQuick.Text = "Bundle"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÖffnenToolStripMenuItem, Me.AlsErledigtMarkierenToolStripMenuItem, Me.ToolStripMenuItem1, Me.AlleAuswählenToolStripMenuItem, Me.KeineAuswählenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(190, 98)
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ÖffnenToolStripMenuItem.Tag = "ResID.Open"
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen"
        '
        'AlsErledigtMarkierenToolStripMenuItem
        '
        Me.AlsErledigtMarkierenToolStripMenuItem.Name = "AlsErledigtMarkierenToolStripMenuItem"
        Me.AlsErledigtMarkierenToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AlsErledigtMarkierenToolStripMenuItem.Tag = "ResID.MarkTheSelectedPlanEntriesAsDone"
        Me.AlsErledigtMarkierenToolStripMenuItem.Text = "Als Erledigt markieren"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AlleAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswählenToolStripMenuItem
        '
        Me.KeineAuswählenToolStripMenuItem.Name = "KeineAuswählenToolStripMenuItem"
        Me.KeineAuswählenToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.KeineAuswählenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswählenToolStripMenuItem.Text = "Keine auswählen"
        '
        'DsPlanSearch1
        '
        Me.DsPlanSearch1.DataSetName = "dsPlanSearch"
        Me.DsPlanSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.lblCount)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(3, 215)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(535, 18)
        Me.PanelBottom.TabIndex = 2
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCount.Location = New System.Drawing.Point(4, 1)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(72, 13)
        Me.lblCount.TabIndex = 224
        Me.lblCount.Text = "Gefunden: 12"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me._PanelTop_Toolbars_Dock_Area_Left)
        Me.PanelTop.Controls.Add(Me._PanelTop_Toolbars_Dock_Area_Right)
        Me.PanelTop.Controls.Add(Me._PanelTop_Toolbars_Dock_Area_Bottom)
        Me.PanelTop.Controls.Add(Me._PanelTop_Toolbars_Dock_Area_Top)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(3, 16)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(535, 28)
        Me.PanelTop.TabIndex = 1
        '
        '_PanelTop_Toolbars_Dock_Area_Left
        '
        Me._PanelTop_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTop_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelTop_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelTop_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTop_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelTop_Toolbars_Dock_Area_Left.Name = "_PanelTop_Toolbars_Dock_Area_Left"
        Me._PanelTop_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 1)
        Me._PanelTop_Toolbars_Dock_Area_Left.ToolbarsManager = Me.toolbarQuickPlans
        '
        'toolbarQuickPlans
        '
        Me.toolbarQuickPlans.DesignerFlags = 1
        Me.toolbarQuickPlans.DockWithinContainer = Me.PanelTop
        Me.toolbarQuickPlans.LockToolbars = True
        Me.toolbarQuickPlans.ShowFullMenusDelay = 500
        Me.toolbarQuickPlans.ShowQuickCustomizeButton = False
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 0
        ButtonTool3.InstanceProps.IsFirstInGroup = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool8, ButtonTool3, ButtonTool6})
        UltraToolbar2.Text = "UltraToolbar1"
        Me.toolbarQuickPlans.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar2})
        ButtonTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool4.SharedPropsInternal.ToolTipText = "Planungseintrag hinzufügen"
        ButtonTool4.Tag = "ResID.NewNotice"
        ButtonTool2.SharedPropsInternal.Caption = "Ausgewählte Planungseinträge als erledigt markieren"
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool2.Tag = "ResID.MarkTheSelectedPlanEntriesAsDone"
        ButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool5.Tag = "ResID.Delete"
        Me.toolbarQuickPlans.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4, ButtonTool2, ButtonTool5})
        '
        '_PanelTop_Toolbars_Dock_Area_Right
        '
        Me._PanelTop_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTop_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelTop_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelTop_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTop_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(535, 27)
        Me._PanelTop_Toolbars_Dock_Area_Right.Name = "_PanelTop_Toolbars_Dock_Area_Right"
        Me._PanelTop_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 1)
        Me._PanelTop_Toolbars_Dock_Area_Right.ToolbarsManager = Me.toolbarQuickPlans
        '
        '_PanelTop_Toolbars_Dock_Area_Top
        '
        Me._PanelTop_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTop_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelTop_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelTop_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTop_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelTop_Toolbars_Dock_Area_Top.Name = "_PanelTop_Toolbars_Dock_Area_Top"
        Me._PanelTop_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(535, 27)
        Me._PanelTop_Toolbars_Dock_Area_Top.ToolbarsManager = Me.toolbarQuickPlans
        '
        '_PanelTop_Toolbars_Dock_Area_Bottom
        '
        Me._PanelTop_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelTop_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelTop_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelTop_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelTop_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 28)
        Me._PanelTop_Toolbars_Dock_Area_Bottom.Name = "_PanelTop_Toolbars_Dock_Area_Bottom"
        Me._PanelTop_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(535, 0)
        Me._PanelTop_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.toolbarQuickPlans
        '
        'dropDownInfo
        '
        Me.dropDownInfo.AllowDrop = True
        Me.dropDownInfo.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor2 = System.Drawing.Color.White
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance1.TextHAlignAsString = "Center"
        Me.dropDownInfo.Appearance = Appearance1
        Me.dropDownInfo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Me.dropDownInfo.ImageSize = New System.Drawing.Size(20, 20)
        Me.dropDownInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dropDownInfo.Location = New System.Drawing.Point(2, 1)
        Me.dropDownInfo.Name = "dropDownInfo"
        Me.dropDownInfo.ShowFocusRect = False
        Me.dropDownInfo.ShowOutline = False
        Me.dropDownInfo.Size = New System.Drawing.Size(60, 29)
        Me.dropDownInfo.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownInfo.TabIndex = 10
        Me.dropDownInfo.TabStop = False
        Me.dropDownInfo.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.dropDownInfo.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.dropDownInfo.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'contInfoBundles_Fill_Panel
        '
        Me.contInfoBundles_Fill_Panel.Controls.Add(Me.PanelToolBar)
        Me.contInfoBundles_Fill_Panel.Controls.Add(Me.dropDownInfo)
        Me.contInfoBundles_Fill_Panel.Controls.Add(Me.PanelInfo)
        Me.contInfoBundles_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.contInfoBundles_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contInfoBundles_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.contInfoBundles_Fill_Panel.Name = "contInfoBundles_Fill_Panel"
        Me.contInfoBundles_Fill_Panel.Size = New System.Drawing.Size(796, 373)
        Me.contInfoBundles_Fill_Panel.TabIndex = 0
        '
        'contPlansQuickInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.contInfoBundles_Fill_Panel)
        Me.DoubleBuffered = True
        Me.Name = "contPlansQuickInfo"
        Me.Size = New System.Drawing.Size(796, 373)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar.ResumeLayout(False)
        Me.PanelInfo.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelAll.ResumeLayout(False)
        CType(Me.grpInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInfo.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanelGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanelGrid.ResumeLayout(False)
        Me.UltraGridBagLayoutPanelGrid_Fill_Panel.ResumeLayout(False)
        CType(Me.gridPlansQuick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.toolbarQuickPlans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contInfoBundles_Fill_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents grpInfo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents UltraGridBagLayoutPanelGrid As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Public WithEvents gridPlansQuick As Infragistics.Win.UltraWinGrid.UltraGrid
    Public WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents UltraGridBagLayoutPanelAll As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents PanelToolBar As System.Windows.Forms.Panel
    Friend WithEvents PanelToolBar_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelToolBar_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolBar_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolBar_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelToolBar_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents contInfoBundles_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents toolbarQuickPlans As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents UltraGridBagLayoutPanelGrid_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelTop_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelTop_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelTop_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelTop_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CompPlan1 As compPlan
    Friend WithEvents ÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DsPlanSearch1 As dsPlanSearch
    Public WithEvents dropDownInfo As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents AlsErledigtMarkierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AlleAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
