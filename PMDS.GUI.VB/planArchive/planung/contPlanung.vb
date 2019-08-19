Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinSchedule
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Imports Infragistics.Win.UltraWinDock
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing




Public Class contPlanung
    Inherits System.Windows.Forms.UserControl


    Private gen As New GeneralArchiv

    Public mainWindow As contPlanungMain
    Private contTxtEditor As New QS2.Desktop.Txteditor.contTxtEditor()

    Public arrBenutzer As New ArrayList

    Public isLoaded As Boolean = False

    Public typPoseingangAusgang As New GeneralArchiv.InitApplicationAufgabenTermine

    Public tblAdminAufgaben As New sqlAufgaben

    Public Class cSelApp
        Public idaufgabe As System.Guid
        Public appoint As Appointment
    End Class





    Friend WithEvents PanelAnzeige As System.Windows.Forms.Panel
    Friend WithEvents PanelVorschau As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents layText As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents layOben As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents layKalender As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents PanelRechts As System.Windows.Forms.Panel
    Public WithEvents UltraGridAufgaben As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStripNeu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NeuesMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuerTerminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelUnten2 As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenVorschau As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenToolbar As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenToolbar_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelUntenToolbar_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UToolbarsManagerTextVorschau As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _PanelUntenToolbar_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelUntenToolbar_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelUntenToolbar_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraSchedulePrintDocument1 As Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents PanelRechts_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents UToolbarsManagerKalender As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents PanelRechts_Fill_Panel_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents PanelKalender As System.Windows.Forms.Panel



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
    Friend WithEvents UTabTable As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UTabPageGrid As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControlMonat As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControlWoche As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControlTag As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UMonthAufgabe As Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle
    Friend WithEvents UWeekAufgabe As Infragistics.Win.UltraWinSchedule.UltraWeekView
    Friend WithEvents UltraCalendarInfo As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents UltraCalendarLook As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
    Friend WithEvents UltraMonthViewMulti As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
    Friend WithEvents UDayAufgabe As Infragistics.Win.UltraWinSchedule.UltraDayView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contPlanung))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Heute")
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Heute")
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichern")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttExportieren")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttDrucken")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttDruckvorschau")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichern")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttExportieren")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttDrucken")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttDruckvorschau")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControlMonat = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UMonthAufgabe = New Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle()
        Me.UltraCalendarInfo = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.UltraCalendarLook = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
        Me.ContextMenuStripNeu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuesMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuerTerminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraTabPageControlWoche = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UWeekAufgabe = New Infragistics.Win.UltraWinSchedule.UltraWeekView()
        Me.UltraTabPageControlTag = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UDayAufgabe = New Infragistics.Win.UltraWinSchedule.UltraDayView()
        Me.UTabPageGrid = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridAufgaben = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraMonthViewMulti = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti()
        Me.UTabTable = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.PanelKalender = New System.Windows.Forms.Panel()
        Me.PanelRechts = New System.Windows.Forms.Panel()
        Me.PanelRechts_Fill_Panel = New System.Windows.Forms.Panel()
        Me.PanelRechts_Fill_Panel_Fill_Panel = New System.Windows.Forms.Panel()
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UToolbarsManagerKalender = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelAnzeige = New System.Windows.Forms.Panel()
        Me.PanelVorschau = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelUnten2 = New System.Windows.Forms.Panel()
        Me.PanelUntenVorschau = New System.Windows.Forms.Panel()
        Me.PanelUntenToolbar_Fill_Panel = New System.Windows.Forms.Panel()
        Me.PanelUntenToolbar = New System.Windows.Forms.Panel()
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UToolbarsManagerTextVorschau = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.layOben = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.layText = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.layKalender = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.UltraSchedulePrintDocument1 = New Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraTabPageControlMonat.SuspendLayout()
        CType(Me.UMonthAufgabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripNeu.SuspendLayout()
        Me.UltraTabPageControlWoche.SuspendLayout()
        CType(Me.UWeekAufgabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControlTag.SuspendLayout()
        CType(Me.UDayAufgabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabPageGrid.SuspendLayout()
        CType(Me.UltraGridAufgaben, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraMonthViewMulti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTabTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabTable.SuspendLayout()
        Me.PanelKalender.SuspendLayout()
        Me.PanelRechts.SuspendLayout()
        Me.PanelRechts_Fill_Panel.SuspendLayout()
        Me.PanelRechts_Fill_Panel_Fill_Panel.SuspendLayout()
        CType(Me.UToolbarsManagerKalender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAnzeige.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        Me.PanelUnten2.SuspendLayout()
        Me.PanelUntenVorschau.SuspendLayout()
        Me.PanelUntenToolbar_Fill_Panel.SuspendLayout()
        Me.PanelUntenToolbar.SuspendLayout()
        CType(Me.UToolbarsManagerTextVorschau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layOben, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layKalender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControlMonat
        '
        Me.UltraTabPageControlMonat.Controls.Add(Me.UMonthAufgabe)
        Me.UltraTabPageControlMonat.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabPageControlMonat.Name = "UltraTabPageControlMonat"
        Me.UltraTabPageControlMonat.Size = New System.Drawing.Size(543, 325)
        '
        'UMonthAufgabe
        '
        Me.UMonthAufgabe.AutoAppointmentDialog = False
        Me.UMonthAufgabe.CalendarInfo = Me.UltraCalendarInfo
        Me.UMonthAufgabe.CalendarLook = Me.UltraCalendarLook
        Me.UMonthAufgabe.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.UMonthAufgabe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UMonthAufgabe.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UMonthAufgabe.Location = New System.Drawing.Point(0, 0)
        Me.UMonthAufgabe.Name = "UMonthAufgabe"
        Me.UMonthAufgabe.Size = New System.Drawing.Size(543, 325)
        Me.UMonthAufgabe.TabIndex = 0
        Me.UMonthAufgabe.TimeDisplayStyle = Infragistics.Win.UltraWinSchedule.TimeDisplayStyleEnum.Time24Hour
        Me.UMonthAufgabe.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UMonthAufgabe.VisibleWeeks = 4
        Me.UMonthAufgabe.WeekHeaderDisplayStyle = Infragistics.Win.UltraWinSchedule.WeekHeaderDisplayStyle.WeekNumber
        '
        'UltraCalendarLook
        '
        Me.UltraCalendarLook.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2003
        '
        'ContextMenuStripNeu
        '
        Me.ContextMenuStripNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ContextMenuStripNeu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuesMailToolStripMenuItem, Me.NeuerTerminToolStripMenuItem, Me.LöschenToolStripMenuItem, Me.ToolStripMenuItem1, Me.DruckenToolStripMenuItem})
        Me.ContextMenuStripNeu.Name = "ContextMenuStripNeu"
        Me.ContextMenuStripNeu.Size = New System.Drawing.Size(151, 98)
        '
        'NeuesMailToolStripMenuItem
        '
        Me.NeuesMailToolStripMenuItem.Image = CType(resources.GetObject("NeuesMailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuesMailToolStripMenuItem.Name = "NeuesMailToolStripMenuItem"
        Me.NeuesMailToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.NeuesMailToolStripMenuItem.Text = "Neues Mail"
        '
        'NeuerTerminToolStripMenuItem
        '
        Me.NeuerTerminToolStripMenuItem.Image = CType(resources.GetObject("NeuerTerminToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuerTerminToolStripMenuItem.Name = "NeuerTerminToolStripMenuItem"
        Me.NeuerTerminToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.NeuerTerminToolStripMenuItem.Text = "Neuer Termin"
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Image = CType(resources.GetObject("LöschenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'DruckenToolStripMenuItem
        '
        Me.DruckenToolStripMenuItem.Image = CType(resources.GetObject("DruckenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
        Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DruckenToolStripMenuItem.Text = "Drucken"
        '
        'UltraTabPageControlWoche
        '
        Me.UltraTabPageControlWoche.Controls.Add(Me.UWeekAufgabe)
        Me.UltraTabPageControlWoche.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControlWoche.Name = "UltraTabPageControlWoche"
        Me.UltraTabPageControlWoche.Size = New System.Drawing.Size(543, 325)
        '
        'UWeekAufgabe
        '
        Me.UWeekAufgabe.AutoAppointmentDialog = False
        Me.UWeekAufgabe.BorderStyleDay = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UWeekAufgabe.BorderStyleDayHeader = Infragistics.Win.UIElementBorderStyle.Dashed
        Me.UWeekAufgabe.CalendarInfo = Me.UltraCalendarInfo
        Me.UWeekAufgabe.CalendarLook = Me.UltraCalendarLook
        Me.UWeekAufgabe.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.UWeekAufgabe.DayDisplayStyle = Infragistics.Win.UltraWinSchedule.DayDisplayStyleEnum.Full
        Me.UWeekAufgabe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UWeekAufgabe.Location = New System.Drawing.Point(0, 0)
        Me.UWeekAufgabe.Name = "UWeekAufgabe"
        Me.UWeekAufgabe.Size = New System.Drawing.Size(543, 325)
        Me.UWeekAufgabe.TabIndex = 0
        Me.UWeekAufgabe.TimeDisplayStyle = Infragistics.Win.UltraWinSchedule.TimeDisplayStyleEnum.Time24Hour
        Me.UWeekAufgabe.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraTabPageControlTag
        '
        Me.UltraTabPageControlTag.Controls.Add(Me.UDayAufgabe)
        Me.UltraTabPageControlTag.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControlTag.Name = "UltraTabPageControlTag"
        Me.UltraTabPageControlTag.Size = New System.Drawing.Size(543, 325)
        '
        'UDayAufgabe
        '
        Me.UDayAufgabe.AppointmentShadowVisible = Infragistics.Win.DefaultableBoolean.[True]
        Me.UDayAufgabe.AutoAppointmentDialog = False
        Me.UDayAufgabe.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UDayAufgabe.CalendarInfo = Me.UltraCalendarInfo
        Me.UDayAufgabe.CalendarLook = Me.UltraCalendarLook
        Me.UDayAufgabe.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.UDayAufgabe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UDayAufgabe.Location = New System.Drawing.Point(0, 0)
        Me.UDayAufgabe.Name = "UDayAufgabe"
        Me.UDayAufgabe.Size = New System.Drawing.Size(543, 325)
        Me.UDayAufgabe.TabIndex = 0
        Me.UDayAufgabe.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UTabPageGrid
        '
        Me.UTabPageGrid.Controls.Add(Me.UltraGridAufgaben)
        Me.UTabPageGrid.Location = New System.Drawing.Point(-10000, -10000)
        Me.UTabPageGrid.Name = "UTabPageGrid"
        Me.UTabPageGrid.Size = New System.Drawing.Size(543, 325)
        '
        'UltraGridAufgaben
        '
        Me.UltraGridAufgaben.ContextMenuStrip = Me.ContextMenuStripNeu
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.UltraGridAufgaben.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.UltraGridAufgaben.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridAufgaben.DisplayLayout.MaxRowScrollRegions = 1
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.Override.AddRowAppearance = Appearance4
        Me.UltraGridAufgaben.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.UltraGridAufgaben.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.DarkGray
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.UltraGridAufgaben.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.UltraGridAufgaben.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.UltraGridAufgaben.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridAufgaben.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridAufgaben.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridAufgaben.Name = "UltraGridAufgaben"
        Me.UltraGridAufgaben.Size = New System.Drawing.Size(543, 325)
        Me.UltraGridAufgaben.TabIndex = 0
        '
        'UltraMonthViewMulti
        '
        Me.UltraMonthViewMulti.BackColor = System.Drawing.SystemColors.Window
        Me.UltraMonthViewMulti.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraMonthViewMulti.CalendarInfo = Me.UltraCalendarInfo
        Me.UltraMonthViewMulti.CalendarLook = Me.UltraCalendarLook
        Me.UltraMonthViewMulti.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.UltraMonthViewMulti.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UltraMonthViewMulti.Location = New System.Drawing.Point(2, 5)
        Me.UltraMonthViewMulti.MonthDimensions = New System.Drawing.Size(1, 3)
        Me.UltraMonthViewMulti.Name = "UltraMonthViewMulti"
        Me.UltraMonthViewMulti.Size = New System.Drawing.Size(144, 374)
        Me.UltraMonthViewMulti.TabIndex = 2
        Me.UltraMonthViewMulti.TipStyle = CType(((Infragistics.Win.UltraWinSchedule.TipStyleDay.Appointments Or Infragistics.Win.UltraWinSchedule.TipStyleDay.Holidays) _
            Or Infragistics.Win.UltraWinSchedule.TipStyleDay.Notes), Infragistics.Win.UltraWinSchedule.TipStyleDay)
        '
        'UTabTable
        '
        Me.UTabTable.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UTabTable.Controls.Add(Me.UTabPageGrid)
        Me.UTabTable.Controls.Add(Me.UltraTabPageControlMonat)
        Me.UTabTable.Controls.Add(Me.UltraTabPageControlWoche)
        Me.UTabTable.Controls.Add(Me.UltraTabPageControlTag)
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 1
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.layOben.SetGridBagConstraint(Me.UTabTable, GridBagConstraint1)
        Me.UTabTable.Location = New System.Drawing.Point(5, 5)
        Me.UTabTable.Name = "UTabTable"
        Me.layOben.SetPreferredSize(Me.UTabTable, New System.Drawing.Size(476, 309))
        Me.UTabTable.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UTabTable.Size = New System.Drawing.Size(543, 325)
        Me.UTabTable.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
        Me.UTabTable.TabIndex = 0
        Appearance7.BorderColor = System.Drawing.Color.White
        UltraTab2.Appearance = Appearance7
        UltraTab2.Key = "Monatlich"
        UltraTab2.TabPage = Me.UltraTabPageControlMonat
        Appearance8.BorderColor = System.Drawing.Color.White
        UltraTab3.Appearance = Appearance8
        UltraTab3.Key = "Wöchentlich"
        UltraTab3.TabPage = Me.UltraTabPageControlWoche
        Appearance9.BorderColor = System.Drawing.Color.White
        UltraTab4.Appearance = Appearance9
        UltraTab4.Key = "Täglich"
        UltraTab4.TabPage = Me.UltraTabPageControlTag
        Appearance10.BorderColor = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance10
        UltraTab1.Key = "Tabelle"
        UltraTab1.TabPage = Me.UTabPageGrid
        Me.UTabTable.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab3, UltraTab4, UltraTab1})
        Me.UTabTable.TabStop = False
        Me.UTabTable.UseAppStyling = False
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(543, 325)
        '
        'PanelKalender
        '
        Me.PanelKalender.Controls.Add(Me.PanelRechts)
        Me.PanelKalender.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelKalender.Location = New System.Drawing.Point(553, 0)
        Me.PanelKalender.Name = "PanelKalender"
        Me.PanelKalender.Size = New System.Drawing.Size(148, 498)
        Me.PanelKalender.TabIndex = 388
        '
        'PanelRechts
        '
        Me.PanelRechts.BackColor = System.Drawing.Color.Transparent
        Me.PanelRechts.Controls.Add(Me.PanelRechts_Fill_Panel)
        Me.PanelRechts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRechts.Location = New System.Drawing.Point(0, 0)
        Me.PanelRechts.Name = "PanelRechts"
        Me.PanelRechts.Size = New System.Drawing.Size(148, 498)
        Me.PanelRechts.TabIndex = 373
        '
        'PanelRechts_Fill_Panel
        '
        Me.PanelRechts_Fill_Panel.Controls.Add(Me.PanelRechts_Fill_Panel_Fill_Panel)
        Me.PanelRechts_Fill_Panel.Controls.Add(Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left)
        Me.PanelRechts_Fill_Panel.Controls.Add(Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right)
        Me.PanelRechts_Fill_Panel.Controls.Add(Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom)
        Me.PanelRechts_Fill_Panel.Controls.Add(Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top)
        Me.PanelRechts_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelRechts_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRechts_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.PanelRechts_Fill_Panel.Name = "PanelRechts_Fill_Panel"
        Me.PanelRechts_Fill_Panel.Size = New System.Drawing.Size(148, 498)
        Me.PanelRechts_Fill_Panel.TabIndex = 0
        '
        'PanelRechts_Fill_Panel_Fill_Panel
        '
        Me.PanelRechts_Fill_Panel_Fill_Panel.BackColor = System.Drawing.Color.Transparent
        Me.PanelRechts_Fill_Panel_Fill_Panel.Controls.Add(Me.UltraMonthViewMulti)
        Me.PanelRechts_Fill_Panel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelRechts_Fill_Panel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRechts_Fill_Panel_Fill_Panel.Location = New System.Drawing.Point(0, 23)
        Me.PanelRechts_Fill_Panel_Fill_Panel.Name = "PanelRechts_Fill_Panel_Fill_Panel"
        Me.PanelRechts_Fill_Panel_Fill_Panel.Size = New System.Drawing.Size(148, 475)
        Me.PanelRechts_Fill_Panel_Fill_Panel.TabIndex = 0
        '
        '_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left
        '
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 23)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.Name = "_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left"
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 475)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UToolbarsManagerKalender
        '
        'UToolbarsManagerKalender
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Me.UToolbarsManagerKalender.Appearance = Appearance11
        Me.UToolbarsManagerKalender.DesignerFlags = 1
        Me.UToolbarsManagerKalender.DockWithinContainer = Me.PanelRechts_Fill_Panel
        Me.UToolbarsManagerKalender.LockToolbars = True
        Me.UToolbarsManagerKalender.ShowFullMenusDelay = 500
        Me.UToolbarsManagerKalender.ShowQuickCustomizeButton = False
        Me.UToolbarsManagerKalender.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool10})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UToolbarsManagerKalender.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        ButtonTool9.SharedPropsInternal.Caption = "Heute"
        ButtonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        Me.UToolbarsManagerKalender.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool9})
        '
        '_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right
        '
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(148, 23)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.Name = "_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right"
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 475)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UToolbarsManagerKalender
        '
        '_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom
        '
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 498)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.Name = "_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom"
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(148, 0)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UToolbarsManagerKalender
        '
        '_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top
        '
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.Name = "_PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top"
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(148, 23)
        Me._PanelRechts_Fill_Panel_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UToolbarsManagerKalender
        '
        'PanelAnzeige
        '
        Me.PanelAnzeige.BackColor = System.Drawing.Color.Transparent
        Me.PanelAnzeige.Controls.Add(Me.UTabTable)
        Me.PanelAnzeige.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAnzeige.Location = New System.Drawing.Point(0, 0)
        Me.PanelAnzeige.Name = "PanelAnzeige"
        Me.PanelAnzeige.Size = New System.Drawing.Size(553, 331)
        Me.PanelAnzeige.TabIndex = 392
        '
        'PanelVorschau
        '
        Me.PanelVorschau.BackColor = System.Drawing.Color.White
        Me.PanelVorschau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelVorschau.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVorschau.Location = New System.Drawing.Point(0, 0)
        Me.PanelVorschau.Name = "PanelVorschau"
        Me.PanelVorschau.Size = New System.Drawing.Size(543, 125)
        Me.PanelVorschau.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelAnzeige)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelUnten)
        Me.SplitContainer1.Size = New System.Drawing.Size(553, 498)
        Me.SplitContainer1.SplitterDistance = 331
        Me.SplitContainer1.TabIndex = 394
        '
        'PanelUnten
        '
        Me.PanelUnten.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelUnten.Controls.Add(Me.PanelUnten2)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUnten.Location = New System.Drawing.Point(0, 0)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(553, 163)
        Me.PanelUnten.TabIndex = 394
        '
        'PanelUnten2
        '
        Me.PanelUnten2.BackColor = System.Drawing.Color.Transparent
        Me.PanelUnten2.Controls.Add(Me.PanelUntenVorschau)
        Me.PanelUnten2.Controls.Add(Me.PanelUntenToolbar)
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 5
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.Insets.Top = 5
        Me.layText.SetGridBagConstraint(Me.PanelUnten2, GridBagConstraint2)
        Me.PanelUnten2.Location = New System.Drawing.Point(5, 5)
        Me.PanelUnten2.Name = "PanelUnten2"
        Me.layText.SetPreferredSize(Me.PanelUnten2, New System.Drawing.Size(338, 100))
        Me.PanelUnten2.Size = New System.Drawing.Size(543, 153)
        Me.PanelUnten2.TabIndex = 1
        '
        'PanelUntenVorschau
        '
        Me.PanelUntenVorschau.BackColor = System.Drawing.Color.White
        Me.PanelUntenVorschau.Controls.Add(Me.PanelUntenToolbar_Fill_Panel)
        Me.PanelUntenVorschau.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUntenVorschau.Location = New System.Drawing.Point(0, 28)
        Me.PanelUntenVorschau.Name = "PanelUntenVorschau"
        Me.PanelUntenVorschau.Size = New System.Drawing.Size(543, 125)
        Me.PanelUntenVorschau.TabIndex = 2
        '
        'PanelUntenToolbar_Fill_Panel
        '
        Me.PanelUntenToolbar_Fill_Panel.Controls.Add(Me.PanelVorschau)
        Me.PanelUntenToolbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelUntenToolbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUntenToolbar_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.PanelUntenToolbar_Fill_Panel.Name = "PanelUntenToolbar_Fill_Panel"
        Me.PanelUntenToolbar_Fill_Panel.Size = New System.Drawing.Size(543, 125)
        Me.PanelUntenToolbar_Fill_Panel.TabIndex = 0
        '
        'PanelUntenToolbar
        '
        Me.PanelUntenToolbar.BackColor = System.Drawing.Color.White
        Me.PanelUntenToolbar.Controls.Add(Me._PanelUntenToolbar_Toolbars_Dock_Area_Left)
        Me.PanelUntenToolbar.Controls.Add(Me._PanelUntenToolbar_Toolbars_Dock_Area_Right)
        Me.PanelUntenToolbar.Controls.Add(Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom)
        Me.PanelUntenToolbar.Controls.Add(Me._PanelUntenToolbar_Toolbars_Dock_Area_Top)
        Me.PanelUntenToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelUntenToolbar.Location = New System.Drawing.Point(0, 0)
        Me.PanelUntenToolbar.Name = "PanelUntenToolbar"
        Me.PanelUntenToolbar.Size = New System.Drawing.Size(543, 28)
        Me.PanelUntenToolbar.TabIndex = 1
        '
        '_PanelUntenToolbar_Toolbars_Dock_Area_Left
        '
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.WhiteSmoke
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.Name = "_PanelUntenToolbar_Toolbars_Dock_Area_Left"
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 1)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UToolbarsManagerTextVorschau
        '
        'UToolbarsManagerTextVorschau
        '
        Appearance12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.UToolbarsManagerTextVorschau.Appearance = Appearance12
        Me.UToolbarsManagerTextVorschau.DesignerFlags = 1
        Me.UToolbarsManagerTextVorschau.DockWithinContainer = Me.PanelUntenToolbar
        Me.UToolbarsManagerTextVorschau.LockToolbars = True
        Me.UToolbarsManagerTextVorschau.ShowFullMenusDelay = 500
        Me.UToolbarsManagerTextVorschau.ShowQuickCustomizeButton = False
        Me.UToolbarsManagerTextVorschau.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 0
        ButtonTool8.InstanceProps.IsFirstInGroup = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool6, ButtonTool7, ButtonTool8, ButtonTool5})
        UltraToolbar2.Text = "UltraToolbar1"
        Me.UToolbarsManagerTextVorschau.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar2})
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesLarge.Appearance = Appearance13
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        ButtonTool1.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        ButtonTool1.SharedPropsInternal.Caption = "Speichern"
        ButtonTool1.SharedPropsInternal.ToolTipText = "Dokument speichern (Rtf, Word, Excel, Text, etc)"
        ButtonTool1.SharedPropsInternal.ToolTipTitle = "Speichern"
        ButtonTool2.SharedPropsInternal.Caption = "Exportieren"
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool2.SharedPropsInternal.ToolTipText = "Dokument exportieren (Pfd)"
        ButtonTool2.SharedPropsInternal.ToolTipTitle = "Exportieren"
        Appearance15.Image = CType(resources.GetObject("Appearance15.Image"), Object)
        ButtonTool3.SharedPropsInternal.AppearancesLarge.Appearance = Appearance15
        Appearance16.Image = CType(resources.GetObject("Appearance16.Image"), Object)
        ButtonTool3.SharedPropsInternal.AppearancesSmall.Appearance = Appearance16
        ButtonTool3.SharedPropsInternal.Caption = "Drucken"
        ButtonTool3.SharedPropsInternal.ToolTipText = "Dokument drucken"
        ButtonTool3.SharedPropsInternal.ToolTipTitle = "Drucken"
        Appearance17.Image = CType(resources.GetObject("Appearance17.Image"), Object)
        ButtonTool4.SharedPropsInternal.AppearancesLarge.Appearance = Appearance17
        Appearance18.Image = CType(resources.GetObject("Appearance18.Image"), Object)
        ButtonTool4.SharedPropsInternal.AppearancesSmall.Appearance = Appearance18
        ButtonTool4.SharedPropsInternal.Caption = "Druckvorschau"
        ButtonTool4.SharedPropsInternal.ToolTipText = "Dokument Druckvorschau"
        ButtonTool4.SharedPropsInternal.ToolTipTitle = "Druckvorschau"
        Me.UToolbarsManagerTextVorschau.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4})
        '
        '_PanelUntenToolbar_Toolbars_Dock_Area_Right
        '
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.WhiteSmoke
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(543, 27)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.Name = "_PanelUntenToolbar_Toolbars_Dock_Area_Right"
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 1)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UToolbarsManagerTextVorschau
        '
        '_PanelUntenToolbar_Toolbars_Dock_Area_Bottom
        '
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 28)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.Name = "_PanelUntenToolbar_Toolbars_Dock_Area_Bottom"
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(543, 0)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UToolbarsManagerTextVorschau
        '
        '_PanelUntenToolbar_Toolbars_Dock_Area_Top
        '
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.WhiteSmoke
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.Name = "_PanelUntenToolbar_Toolbars_Dock_Area_Top"
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(543, 27)
        Me._PanelUntenToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UToolbarsManagerTextVorschau
        '
        'layOben
        '
        Me.layOben.ContainerControl = Me.PanelAnzeige
        Me.layOben.ExpandToFitHeight = True
        Me.layOben.ExpandToFitWidth = True
        '
        'layText
        '
        Me.layText.ContainerControl = Me.PanelUnten
        Me.layText.ExpandToFitHeight = True
        Me.layText.ExpandToFitWidth = True
        '
        'layKalender
        '
        Me.layKalender.ContainerControl = Me.PanelRechts_Fill_Panel
        Me.layKalender.ExpandToFitHeight = True
        Me.layKalender.ExpandToFitWidth = True
        '
        'UltraSchedulePrintDocument1
        '
        Me.UltraSchedulePrintDocument1.CalendarLook = Me.UltraCalendarLook
        Me.UltraSchedulePrintDocument1.PrintStyle = Infragistics.Win.UltraWinSchedule.SchedulePrintStyle.Monthly
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Document = Me.UltraSchedulePrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        Me.UltraPrintPreviewDialog1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.Grid = Me.UltraGridAufgaben
        '
        'contPlanung
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PanelKalender)
        Me.Name = "contPlanung"
        Me.Size = New System.Drawing.Size(701, 498)
        Me.UltraTabPageControlMonat.ResumeLayout(False)
        CType(Me.UMonthAufgabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripNeu.ResumeLayout(False)
        Me.UltraTabPageControlWoche.ResumeLayout(False)
        CType(Me.UWeekAufgabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControlTag.ResumeLayout(False)
        CType(Me.UDayAufgabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabPageGrid.ResumeLayout(False)
        CType(Me.UltraGridAufgaben, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraMonthViewMulti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTabTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabTable.ResumeLayout(False)
        Me.PanelKalender.ResumeLayout(False)
        Me.PanelRechts.ResumeLayout(False)
        Me.PanelRechts_Fill_Panel.ResumeLayout(False)
        Me.PanelRechts_Fill_Panel_Fill_Panel.ResumeLayout(False)
        CType(Me.UToolbarsManagerKalender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAnzeige.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUnten2.ResumeLayout(False)
        Me.PanelUntenVorschau.ResumeLayout(False)
        Me.PanelUntenToolbar_Fill_Panel.ResumeLayout(False)
        Me.PanelUntenToolbar.ResumeLayout(False)
        CType(Me.UToolbarsManagerTextVorschau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layOben, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layKalender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub AufgabeTerminÜbersicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub loadForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.loadEditoren()

            cMailTermine.anzNachrichten = 0

            Me.mainWindow.UOptionDatumErstelltGesendet2.Value = "ErstelltAm"

            Me.UDayAufgabe.CalendarInfo = Me.UltraCalendarInfo
            Me.UWeekAufgabe.CalendarInfo = Me.UltraCalendarInfo
            Me.UMonthAufgabe.CalendarInfo = Me.UltraCalendarInfo
            Me.UltraMonthViewMulti.CalendarInfo = Me.UltraCalendarInfo

            Me.UDayAufgabe.CalendarLook = Me.UltraCalendarLook
            Me.UWeekAufgabe.CalendarLook = Me.UltraCalendarLook
            Me.UMonthAufgabe.CalendarLook = Me.UltraCalendarLook
            Me.UltraMonthViewMulti.CalendarLook = Me.UltraCalendarLook

            'LabelAnzahl.Text = ""      'lth

            'tblAdminAufgaben.DataTable.Columns.Add("DateTime", System.Type.GetType("System.DateTime"))

            'Me.UMonthAufgabe.ScrollDayIntoView(System.DateTime.Today)
            Dim day As Infragistics.Win.UltraWinSchedule.Day
            day = Me.UltraCalendarInfo.GetDay(Date.Now, True)

            'Me.UltraCalendarInfo.GetDay(DateTime.Today, True)
            'Dim Day2 As Infragistics.Win.UltraWinSchedule.Day
            'Day2 = UDayAufgabe.CalendarInfo.ActiveDay()
            'Me.Selected_Date = Day.Date()

            UDayAufgabe.CalendarInfo.ActiveDay = day
            Me.UMonthAufgabe.CalendarInfo.ActiveDay = day
            Me.UWeekAufgabe.CalendarInfo.ActiveDay = day

            'Me.UMonthAufgabe.TimeDisplayStyle = TimeDisplayStyleEnum.Clock

            'If e.Button = MouseButtons.Right Then
            '    Dim day As Infragistics.Win.UltraWinSchedule.VisibleDay

            '    'If the user Right-clicked on a day, then make it the active time day
            '    day = UltraDayView1.GetVisibleDayFromPoint(e.X, e.Y)
            '    If Not day Is Nothing Then
            '        Dim DY As Infragistics.Win.UltraWinSchedule.Day = UltraCalendarInfo1.GetDay(day.Date, True)
            '        UltraCalendarInfo1.ActiveDay = DY
            '        If Not DY.Selected Then
            '            UltraCalendarInfo1.SelectedDateRanges.Clear()
            '            DY.Selected = True
            '        End If
            '    End If

            'Me.UMonthAufgabe.ScrollDayIntoView(System.DateTime.Today)
            'Me.UWeekAufgabe.ScrollDayIntoView(System.DateTime.Today)
            'Me.UMonthAufgabe.WeekNumbersVisible = True
            'Me.UltraMonthViewMulti.WeekNumbersVisible = True

            'Dim VisibleDay As VisibleDay
            'For Each VisibleDay In Me.UDayAufgabe.VisibleDays
            '    VisibleDay.Day.Activated = True
            '    VisibleDay.Day.Selected = True
            'Next

            If Me.mainWindow._typ = GeneralArchiv.eTypPlanung.termin Then
                Me.NeuesMailToolStripMenuItem.Visible = False
            Else
                Me.NeuerTerminToolStripMenuItem.Visible = False
            End If

            KalenderAufHeute()
            Me.initData()

            Me.isLoaded = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub KalenderAufHeute()
        Try
            ' Kalender auf heutiges Datum setzen
            Dim ActuellDayTime As DateTime = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                            DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)

            UltraCalendarInfo.SelectedAppointments.Clear()
            UltraCalendarInfo.SelectedDateRanges.Clear()
            UltraCalendarInfo.SelectedHolidays.Clear()
            UltraCalendarInfo.SelectedNotes.Clear()

            Dim DayActuell As Infragistics.Win.UltraWinSchedule.Day
            DayActuell = Me.UltraCalendarInfo.GetDay(ActuellDayTime, True)
            Me.UltraCalendarInfo.ActiveDay = DayActuell
            Me.UltraCalendarInfo.ActiveDay.Activated = True
            Me.UltraCalendarInfo.ActiveDay.Selected = True

        Catch ex As Exception
            Throw New Exception("KalenderAufHeute: " + ex.ToString())
        End Try
    End Sub
    Private Sub loadEditoren()
        Try
            Me.PanelVorschau.Controls.Add(Me.contTxtEditor)
            Me.contTxtEditor.loadForm(False, Nothing, False, False)
            Me.contTxtEditor.setControlTyp()
            Me.contTxtEditor.resizeControl(Me.PanelKalender.Width, Me.PanelKalender.Height)

        Catch ex As Exception
            Throw New Exception("loadEditoren: " + ex.ToString())
        End Try
    End Sub

    Public Function mailsTermineLaden() As Boolean
        Try
            Dim sqlStatusTermine As String = ""
            Dim sqlStatusMail As String = ""
            Dim sqlArt As String = " "

            If Me.mainWindow._typ = GeneralArchiv.eTypPlanung.termin Then
                sqlArt = " tblAufgabeArt.ID = '" + gen.IDTermin.ToString + "' or tblAufgabeArt.ID = '" + gen.IDTermin2.ToString + "' "
                If Me.mainWindow.getAuswahlStatusTermine_str = "Offen" Then
                    sqlStatusTermine = "  tblAufgaben.Status = 'Offen' or tblAufgaben.Status = 'Neu'  "
                ElseIf Me.mainWindow.getAuswahlStatusTermine_str = "Erledigt" Then
                    sqlStatusTermine = "  tblAufgaben.Status = 'Erledigt'  "
                End If
            ElseIf Me.mainWindow._typ = GeneralArchiv.eTypPlanung.mail Then
                sqlArt = " tblAufgabeArt.ID = '" + gen.IDMail.ToString + "' "
                If Me.mainWindow.getAuswahlStatusMail_str = GeneralArchiv.eAuswahlStatusMail.gesendet Then
                    sqlStatusMail = " tblAufgaben.WEBGesendet = 1 "
                ElseIf Me.mainWindow.getAuswahlStatusMail_str = GeneralArchiv.eAuswahlStatusMail.entwürfe Then
                    sqlStatusMail = " tblAufgaben.WEBGesendet = 0 or tblAufgaben.WEBGesendet Is null "
                End If
            End If

            Dim sqlPriorität As String = ""
            'sqlPriorität = "  tblAufgaben.Priorität = 'Niedrig' or tblAufgaben.Priorität = 'Mittel' or tblAufgaben.Priorität = 'Hoch'  "

            Dim pers As New ArrayList
            If Me.arrBenutzer.Count = 0 Then
                pers.Add(gen.actUser)
                'Me.LabelStatusAufgaben.Text = "Mein Postfach ..."       'lth
            Else
                For Each idPers As String In Me.arrBenutzer
                    pers.Add(idPers)
                Next
                'Me.LabelStatusAufgaben.Text = "Mehrere Postfächer ..."      'lth
            End If

            'If Me.typPoseingangAusgang = General.InitApplicationAufgabenTermine.Posteingang Then
            '    'Me.modalWindow.Text = Me.modalWindow.writeTitelWindow("Planungssystem - Posteingang ...")
            'ElseIf Me.typPoseingangAusgang = General.InitApplicationAufgabenTermine.Postausgang Then
            '    'Me.modalWindow.Text = Me.modalWindow.writeTitelWindow("Planungssystem - Gesendete Objekte ...")
            'ElseIf Me.typPoseingangAusgang = General.InitApplicationAufgabenTermine.PosteingangPostausgang Then
            '    'Me.modalWindow.Text = Me.modalWindow.writeTitelWindow("Planungssystem - Posteingang & Gesendete Objekte ...")
            'End If

            Me.loadData(Me.typPoseingangAusgang, pers, sqlArt, sqlStatusTermine, sqlPriorität, sqlStatusMail)

        Catch ex As Exception
            Throw New Exception("mailsTermineLaden: " + ex.ToString())
        End Try
    End Function
    Private Function loadData(ByVal typPost As GeneralArchiv.InitApplicationAufgabenTermine,
                                 ByVal Personen As ArrayList, ByVal sqlArtID As String,
                                 ByVal sqlStatusTermine As String, ByVal sqlPriorität As String,
                                 ByVal sqlStatusMail As String) As Boolean
        Try
            Me.clear()

            tblAdminAufgaben.termineMailsSuchen(typPost, sqlArtID, Personen, sqlStatusTermine, sqlPriorität,
                                                            Me.mainWindow.UDateVon.Value, Me.mainWindow.UDateBis.Value,
                                                            Me.mainWindow._typ, Me.mainWindow.getTextauswahl,
                                                            Me.mainWindow.sucheBetreffUndText, Me.mainWindow._id,
                                                            Me.mainWindow._isGesamt, sqlStatusMail,
                                                            Me.mainWindow.UCheckEditorImGesamtsystemSuchen.Checked,
                                                            Me.mainWindow.UOptionDatumErstelltGesendet2.Value)

            If Me.mainWindow._typ = GeneralArchiv.eTypPlanung.termin Then
                For Each r As DataRow In tblAdminAufgaben.tAufgaben.Rows
                    Dim datOrig As Date = r("StartDate")
                    Dim zeitOrig As Date = r("StartTime")
                    Dim dat As New DateTime(datOrig.Year, datOrig.Month, datOrig.Day, zeitOrig.Hour, zeitOrig.Minute, zeitOrig.Second)
                    r("StartDate") = dat

                    Dim DateAufgabe As Date = r("StartDate")
                    Dim TimeAufgabe As Date = r("StartTime")
                    Dim DateAufgabeEnd As Date = r("EndDate")
                    Dim TimeAufgabeEnd As Date = r("EndTime")

                    Dim DateAppStart As Date
                    DateAppStart = Format(DateAufgabe, "dd.MM.yyyy") + " " + Format(TimeAufgabe, "HH:mm")
                    r("DateTime") = Format(DateAppStart, "dd.MM.yyyy HH:mm")

                    Dim DateAppEnd As Date
                    DateAppEnd = Format(DateAufgabeEnd, "dd.MM.yyyy") + " " + Format(TimeAufgabeEnd, "HH:mm")

                    If DateAppEnd < DateAppStart Then
                        DateAppEnd = DateAppStart
                    End If
                    Dim datEnd As TimeSpan = DateAppEnd.Subtract(DateAppStart)
                    If datEnd.Hours > 1 Or (datEnd.Hours = 1 And datEnd.Minutes > 0) Or datEnd.Days > 0 Then
                        DateAppEnd = DateAppStart.AddHours(1)
                    End If
                    Dim appointment As Appointment = New Appointment(DateAppStart, DateAppEnd)

                    appointment.StartDateTime = DateAppStart
                    appointment.Subject = r("Betreff")
                    appointment.Tag = r("ID")

                    appointment.Description = vbNewLine + "Start: " + r("ErstelltAmFormat") + vbNewLine +
                                                "Ende: " + Format(r("EndDate"), "yyyy-MM-dd").ToString + " " + Format(r("EndTime"), "HH:mm").ToString + vbNewLine +
                                                "Erstellt: " + Format(r("ErstelltAm"), "yyyy-MM-dd HH:mm").ToString + vbNewLine + vbNewLine +
                                                "Status: " + r("Status") + vbNewLine + vbNewLine +
                                                IIf(r("Patient") <> "", "Patient: " + r("Patient") + vbNewLine, "") +
                                                "Für Pfleger: " + r("FürPfleger") + vbNewLine +
                                                "Von: " + r("ErstelltVon")

                    'Note.Date = DateAppStart
                    'Note.Description = Betreff
                    'Note.Locked = True
                    'Note.Tag = IDAufgabe

                    appointment.Appearance.BackColor = System.Drawing.Color.DarkGreen
                    appointment.Appearance.ForeColor = Color.White
                    appointment.Appearance.FontData.Bold = DefaultableBoolean.False

                    UMonthAufgabe.CalendarInfo.Appointments.Add(appointment)
                Next
            End If

            UltraGridAufgaben.Refresh()
            Me.initGrid()

            cMailTermine.anzNachrichten = Me.tblAdminAufgaben.tAufgaben.Rows.Count
            Me.mainWindow.setAzahl_buttSuchen(Me.tblAdminAufgaben.tAufgaben.Rows.Count)

            Return True

        Catch ex As Exception
            Throw New Exception("loadData: " + ex.ToString())
        End Try
    End Function

    Private Sub initData()
        Try
            UDayAufgabe.CalendarInfo.Appointments.Clear()
            UWeekAufgabe.CalendarInfo.Appointments.Clear()
            UMonthAufgabe.CalendarInfo.Appointments.Clear()
            UDayAufgabe.CalendarInfo.Notes.Clear()
            UWeekAufgabe.CalendarInfo.Notes.Clear()
            UMonthAufgabe.CalendarInfo.Notes.Clear()

            tblAdminAufgaben.termineMailsSuchen(GeneralArchiv.InitApplicationAufgabenTermine.PosteingangPostausgang,
                                                " tblAufgabeArt.ID = '" + System.Guid.NewGuid.ToString + "' ", New ArrayList, "", "",
                                                Nothing, Nothing, Me.mainWindow._typ, "",
                                                False, Me.mainWindow._id,
                                                Me.mainWindow._isGesamt, "", False, "ErstelltAm")

            UltraGridAufgaben.DataSource = Me.tblAdminAufgaben.tAufgaben
            UltraGridAufgaben.DataBind()
            Me.initGrid()
            cMailTermine.anzNachrichten = 0

        Catch ex As Exception
            Throw New Exception("initData: " + ex.ToString())
        End Try
    End Sub
    Private Function initGrid() As Boolean
        Try
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("EventAction").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("StartTime").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("EndTime").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("StartDate").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("EndDate").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Priorität").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("IDPerson").Hidden = True

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Dauer").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("EventAction").Hidden = True
            If Not Me.mainWindow._isGesamt Then UltraGridAufgaben.DisplayLayout.Bands(0).Columns("IDZuordnung").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Status").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").Hidden = False
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltVon").Hidden = False
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("MailCC").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("AlsHTML").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("IDArt").Hidden = True
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Abgeschlossen").Hidden = True

            If Me.mainWindow._typ = GeneralArchiv.eTypPlanung.mail Then
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("MailAn").Hidden = False
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").Hidden = False
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Status").Hidden = True
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("DateTime").Hidden = True
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Hidden = True
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("DateTime").Hidden = True

            ElseIf Me.mainWindow._typ = GeneralArchiv.eTypPlanung.termin Then
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("MailAn").Hidden = True
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").Hidden = True
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Status").Hidden = False
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("DateTime").Hidden = False
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Hidden = False
                UltraGridAufgaben.DisplayLayout.Bands(0).Columns("DateTime").Hidden = True

            End If

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Betreff").Width = 320
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Betreff").Header.Caption = "Betreff"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Width = 110
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").Header.Caption = "Start"
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").CellAppearance.TextHAlign = HAlign.Left
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAmFormat").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").Width = 100
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").Header.Caption = "Erstellt am"
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").DataType.GetType("System.DateTime")
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").CellAppearance.TextHAlign = HAlign.Center
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltAm").Format = "dd.MM.yyyy HH:mm"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Patient").Width = 200
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Patient").Header.Caption = "Klient"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").Width = 120
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").Header.Caption = "Gesendet am"
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").DataType.GetType("System.DateTime")
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").CellAppearance.TextHAlign = HAlign.Center
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gesendetAm").Format = "dd.MM.yyyy HH:mm"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("MailAn").Width = 150
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("MailAn").Header.Caption = "Mailadresse"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltVon").Width = 90
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("ErstelltVon").Header.Caption = "Von"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("FürPfleger").Width = 90
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("FürPfleger").Header.Caption = "Für Pfleger"

            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Status").Width = 65
            UltraGridAufgaben.DisplayLayout.Bands(0).Columns("Status").Header.Caption = "Status"

            'UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gueltigAb").Header.Caption = "Gültig ab"
            'UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gueltigAb").DataType.GetType("System.DateTime")
            'UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gueltigAb").CellAppearance.TextHAlign = HAlign.Center
            'UltraGridAufgaben.DisplayLayout.Bands(0).Columns("gueltigAb").Format = "dd.MM.yyyy HH:mm"


            ' Preview
            'Dim PrevBand As Infragistics.Win.UltraWinGrid.UltraGridBand = Me.UltraGridAufgaben.DisplayLayout.Bands(0)
            'PrevBand.AutoPreviewEnabled = True
            'PrevBand.AutoPreviewField = "Text"
            'PrevBand.AutoPreviewIndentation = 40
            'PrevBand.AutoPreviewMaxLines = 4
            'PrevBand.Override.RowPreviewAppearance.BackColor = Color.White
            'PrevBand.Override.RowPreviewAppearance.ForeColor = Color.Blue

            'If tblAdminAufgaben.DataTable.Rows.Count > 0 Then

            '    UltraGridAufgaben.DisplayLayout.Bands(0).HeaderVisible = False
            '    UltraGridAufgaben.DisplayLayout.Bands(0).ColHeadersVisible = True
            '    UltraGridAufgaben.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            '    UltraGridAufgaben.DisplayLayout.Bands(0).Override.RowAppearance.BorderColor = System.Drawing.Color.White

            '    'UltraGridAufgaben.DisplayLayout.Bands(0).Columns(2).Header.Appearance.Image = compImage.GetImageFromList(5)
            '    'UltraGridAufgaben.DisplayLayout.Bands(0).Columns(15).Header.Appearance.Image = compImage.GetImageFromList(7) 'Z
            '    'UltraGridAufgaben.DisplayLayout.Bands(0).Columns(17).Header.Appearance.Image = compImage.GetImageFromList(8) 'D
            '    'UltraGridAufgaben.DisplayLayout.Bands(0).Columns(5).CellAppearance.Image = compImage.GetImageFromList(6)

            '    For i As Integer = 0 To UltraGridAufgaben.Rows.Count - 1
            '        UGridRow = UltraGridAufgaben.Rows(i)

            '        If UGridRow.Cells("Priorität").Value = "Hoch" Then
            '            'UGridRow.Cells(4).Appearance.Image = compImage.GetImageFromList(6)
            '        End If
            '        ' UGridRow.Cells(2).Appearance.Image = compImage.GetImageFromList(12)

            '        'Dim tblAdminPerson As New tblAdminPerson
            '        'If tblAdminPerson.SelectRow(UGridRow.Cells("IDPerson").Value).SQLResult = General.ESQLResult.OK Then
            '        '    If tblAdminPerson.DataTable.Rows.Count = 1 Then
            '        '        Dim DataRowFürPerson As DataRow = tblAdminPerson.DataTable.Rows(0)
            '        '        If General.IsNull(DataRowFürPerson("Vorname")) And Not General.IsNull(DataRowFürPerson("Nachname")) Then
            '        '            UGridRow.Cells("FürPersonName").Value = DataRowFürPerson("Vorname") + " " + DataRowFürPerson("Nachname")
            '        '        Else
            '        '            UGridRow.Cells("FürPersonName").Value = DataRowFürPerson("Nachname")
            '        '        End If
            '        '    End If
            '        'End If

            '    Next
            'End If

            Me.UltraGridAufgaben.DisplayLayout.Appearance.BackColor = Color.White
            Me.UltraGridAufgaben.DisplayLayout.Appearance.BackColor2 = Color.White
            Me.UltraGridAufgaben.UseOsThemes = Infragistics.Win.DefaultableBoolean.True
            Me.UltraGridAufgaben.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White

        Catch ex As Exception
            Throw New Exception("initGrid: " + ex.ToString())
        End Try
    End Function
    Public Sub clear()
        Try
            tblAdminAufgaben.tAufgaben.Rows.Clear()
            UltraGridAufgaben.Refresh()

            Me.contTxtEditor.clearForm()

            UDayAufgabe.CalendarInfo.Appointments.Clear()
            UWeekAufgabe.CalendarInfo.Appointments.Clear()
            UMonthAufgabe.CalendarInfo.Appointments.Clear()
            UDayAufgabe.CalendarInfo.Notes.Clear()
            UWeekAufgabe.CalendarInfo.Notes.Clear()
            UMonthAufgabe.CalendarInfo.Notes.Clear()

            cMailTermine.anzNachrichten = 0

            Me.UMonthAufgabe.ScrollDayIntoView(System.DateTime.Today)
            Me.UWeekAufgabe.ScrollDayIntoView(System.DateTime.Today)

        Catch ex As Exception
            Throw New Exception("clear: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedDate() As Date
        Try
            Select Case Me.UTabTable.SelectedTab.Index
                Case 3
                    Dim actAppoint As Appointment
                    Dim actDay As Infragistics.Win.UltraWinSchedule.Day
                    actDay = Me.UltraCalendarInfo.ActiveDay
                    Dim selDat As New Date(actDay.Date.Year, actDay.Date.Month, actDay.Date.Day, Now.Hour, Now.Minute, 0)
                    Return selDat

                Case 0, 1, 2
                    Dim actDayDat As New Date(Now.Year, Now.Month, Now.Day, 9, 0, 0)
                    'If General.IsNull(Me.UDayAufgabe.SelectedTimeSlotRange) > 0 Then
                    Try
                        actDayDat = Me.UDayAufgabe.SelectedTimeSlotRange.StartDateTime
                    Catch ex As Exception
                    End Try
                    ' End If
                    Dim actAppoint As Appointment
                    Dim actDay As Infragistics.Win.UltraWinSchedule.Day
                    actDay = Me.UltraCalendarInfo.ActiveDay
                    Dim selDat As New Date(actDay.Date.Year, actDay.Date.Month, actDay.Date.Day, actDayDat.Hour, actDayDat.Minute, 0)
                    Return selDat
            End Select

        Catch ex As Exception
            Throw New Exception("getSelectedDate: " + ex.ToString())
        End Try
    End Function
    Public Function getSelected_idaufgabe() As cSelApp
        Try
            Dim ret As New cSelApp
            Select Case Me.UTabTable.SelectedTab.Index
                Case 3
                    If Not gen.IsNull(Me.UltraGridAufgaben.ActiveRow) Then
                        ret.appoint = Nothing
                        ret.idaufgabe = Me.UltraGridAufgaben.ActiveRow.Cells("ID").Value
                    End If
                    Return ret
                Case 0, 1, 2
                    Dim actAppoint As Appointment
                    Select Case Me.UTabTable.SelectedTab.Index
                        Case 0
                            If UMonthAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                actAppoint = UMonthAufgabe.CalendarInfo.SelectedAppointments(0)
                            End If
                        Case 1
                            If Me.UWeekAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                actAppoint = UMonthAufgabe.CalendarInfo.SelectedAppointments(0)
                            End If
                        Case 2
                            If Me.UDayAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                actAppoint = UMonthAufgabe.CalendarInfo.SelectedAppointments(0)
                            End If
                    End Select
                    If Not gen.IsNull(actAppoint) Then
                        ret.appoint = actAppoint
                        ret.idaufgabe = gen.StrToGuid(actAppoint.Tag.ToString)
                    End If
                    Return ret
            End Select

        Catch ex As Exception
            Throw New Exception("getSelected_idaufgabe: " + ex.ToString())
        End Try
    End Function

    Private Sub appointmentOpen(ByVal app As Appointment)
        Try
            Dim IDAufgabe As New System.Guid(app.Tag.ToString)
            Dim cl As New cMailTermine
            cl.nachrichtÖffnen(IDAufgabe, Me.mainWindow, IIf(gen.IsNull(Me.mainWindow._id), "", Me.mainWindow._id.ToString), Nothing)

            'Me.contTxtEditor.clearForm()

            'Me.UltraCalendarInfo.GetDay(DateTime.Today, True)
            'Dim Day As Infragistics.Win.UltraWinSchedule.Day
            'Day = UMonthAufgabe.CalendarInfo.ActiveDay()
            ''Me.Selected_Date = Day.Date()
            ''Dim NewDateTime As Date = New Date(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0)

            'Dim appointment As Infragistics.Win.UltraWinSchedule.Appointment
            'For Each appointment In UMonthAufgabe.CalendarInfo.SelectedAppointments
            '    Dim IDAufgabe As New System.Guid(appointment.Tag.ToString)
            '    Me.showVorschau(IDAufgabe)
            'Next

        Catch ex As Exception
            Throw New Exception("appointmentOpen: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub showVorschau(ByVal IDAufgabe As System.Guid)
        Try
            Dim text As String = ""
            Dim alsHTML As Boolean = False

            Dim tblAdminAufgaben As New sqlAufgaben
            tblAdminAufgaben.getAufgaben(IDAufgabe)
            For Each DataRow As DataRow In tblAdminAufgaben.tAufgaben.Rows
                text = DataRow("Text")
                alsHTML = DataRow("AlsHTML")
            Next
            If alsHTML Then
                Me.contTxtEditor.showText(text, TXTextControl.StreamType.HTMLFormat, False, TXTextControl.ViewMode.Normal)
            Else
                Me.contTxtEditor.showText(text, TXTextControl.StreamType.PlainText, False, TXTextControl.ViewMode.Normal)
            End If

        Catch ex As Exception
            Throw New Exception("showVorschau: " + ex.ToString())
        End Try
    End Sub

    Public Sub neuerTermin(ByVal dat As Date)
        Try
            Dim clATW As New cMailTermine
            clATW.Termin_Neu(dat, dat,
                             IIf(gen.IsNull(Me.mainWindow), "", gen.GuidToStr(Me.mainWindow._id)),
                             IIf(gen.IsNull(Me.mainWindow), "", Me.mainWindow._patient),
                             Me.mainWindow, Nothing)

        Catch ex As Exception
            Throw New Exception("neuerTermin: " + ex.ToString())
        End Try
    End Sub
    Public Sub neuesMail()
        Try
            Dim selDat As New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 0)

            Dim clATW As New cMailTermine
            clATW.Mail_Neu(selDat, selDat, IIf(gen.IsNull(Me.mainWindow), "", gen.GuidToStr(Me.mainWindow._id)),
                             IIf(gen.IsNull(Me.mainWindow), "", Me.mainWindow._patient),
                             Me.mainWindow, GeneralArchiv.eTypMail.an, Nothing)

        Catch ex As Exception
            Throw New Exception("neuesMail: " + ex.ToString())
        End Try
    End Sub

    Public Sub ShowTab(ByVal Tab As Integer)
        Try
            If Tab = 0 Then
                UTabTable.Tabs(0).TabPage.Visible = False
                UTabTable.Tabs(1).TabPage.Visible = False
                UTabTable.Tabs(2).TabPage.Visible = False
                UTabTable.Tabs(3).TabPage.Visible = False

                UTabTable.Tabs(0).TabPage.Show()
                UTabTable.Tabs(1).TabPage.Hide()
                UTabTable.Tabs(2).TabPage.Hide()
                UTabTable.Tabs(3).TabPage.Hide()
                UTabTable.SelectedTab = UTabTable.Tabs(0)
            ElseIf Tab = 1 Then
                UTabTable.Tabs(0).TabPage.Visible = False
                UTabTable.Tabs(1).TabPage.Visible = False
                UTabTable.Tabs(2).TabPage.Visible = False
                UTabTable.Tabs(3).TabPage.Visible = False

                UTabTable.Tabs(0).TabPage.Hide()
                UTabTable.Tabs(1).TabPage.Show()
                UTabTable.Tabs(2).TabPage.Hide()
                UTabTable.Tabs(3).TabPage.Hide()
                UTabTable.SelectedTab = UTabTable.Tabs(1)
            ElseIf Tab = 2 Then
                UTabTable.Tabs(0).TabPage.Visible = False
                UTabTable.Tabs(1).TabPage.Visible = False
                UTabTable.Tabs(2).TabPage.Visible = False
                UTabTable.Tabs(3).TabPage.Visible = False

                UTabTable.Tabs(0).TabPage.Hide()
                UTabTable.Tabs(1).TabPage.Hide()
                UTabTable.Tabs(2).TabPage.Show()
                UTabTable.Tabs(3).TabPage.Hide()
                UTabTable.SelectedTab = UTabTable.Tabs(2)
            ElseIf Tab = 3 Then
                UTabTable.Tabs(0).TabPage.Visible = False
                UTabTable.Tabs(1).TabPage.Visible = False
                UTabTable.Tabs(2).TabPage.Visible = False
                UTabTable.Tabs(3).TabPage.Visible = False

                UTabTable.Tabs(0).TabPage.Hide()
                UTabTable.Tabs(1).TabPage.Hide()
                UTabTable.Tabs(2).TabPage.Hide()
                UTabTable.Tabs(3).TabPage.Show()
                UTabTable.SelectedTab = UTabTable.Tabs(3)
            End If

        Catch ex As Exception
            Throw New Exception("ShowTab: " + ex.ToString())
        End Try
    End Sub
    Public Sub SetWidthHeigth(ByVal Width As Integer, ByVal Height As Integer)
        Try
            Me.Width = Width
            Me.Height = Height

            Me.contTxtEditor.resizeControl(Me.PanelVorschau.Width, Me.PanelVorschau.Height)

        Catch ex As Exception
            Throw New Exception("SetWidthHeigth: " + ex.ToString())
        Finally
        End Try
    End Sub


    Private Sub UltraGridAufgaben_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGridAufgaben.AfterCellActivate
        'If UltraGridAufgaben.ActiveCell.Column.ToString() = "xy" Then
        '    UltraGridAufgaben.ActiveCell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        'Else
        '    UltraGridAufgaben.ActiveCell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'End If
    End Sub
    Private Sub UltraGridAufgaben_BeforeRowActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGridAufgaben.BeforeRowActivate
    End Sub
    Private Sub UltraGridAufgaben_BeforeRowRegionScroll1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs) Handles UltraGridAufgaben.BeforeRowRegionScroll
    End Sub
    Private Sub UltraGridAufgaben_BeforeRowsDeleted1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGridAufgaben.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub UltraGridAufgaben_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGridAufgaben.Click
        Try
            If UltraGridAufgaben.Focused Then
                Me.Cursor = Cursors.WaitCursor

                '    If Not gen.IsNull(UltraGridAufgaben.ActiveRow) Then
                '        If Not gen.IsNull(UltraGridAufgaben.ActiveRow.Cells) Then
                '            If UltraGridAufgaben.ActiveRow.Cells.Exists("StartDate") And _
                '                    UltraGridAufgaben.ActiveRow.Cells.Exists("ID") Then

                '            End If
                '        End If
                '    End If

                Me.contTxtEditor.clearForm()
                Me.menüUI_OnOff()
                If Not gen.IsNull(UltraGridAufgaben.ActiveRow) Then
                    Dim IDAufgabe As New System.Guid(CStr(UltraGridAufgaben.ActiveRow.Cells("ID").Value.ToString))
                    Me.showVorschau(IDAufgabe)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraGridAufgaben_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGridAufgaben.DoubleClick
        Try
            'If Not gen.IsNull(UltraGridAufgaben.ActiveRow) And  sdf UltraGridTools.DoubleClickOnActiveRow(UltraGridAufgaben, UltraGridAufgaben.PointToClient(MousePosition)) Then

            Dim cl As New cMailTermine
            cl.nachrichtÖffnen(UltraGridAufgaben.ActiveRow.Cells("ID").Value, Me.mainWindow, _
                               IIf(gen.IsNull(Me.mainWindow._id), "", Me.mainWindow._id.ToString), Nothing)
            ' End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub


    Private Sub UMonthAufgabe_BeforeActivitiesDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeActivitiesDeletedEventArgs) Handles UMonthAufgabe.BeforeActivitiesDeleted
        e.Cancel = True
    End Sub
    Private Sub UMonthAufgabe_BeforeScroll(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeScrollEventArgs) Handles UMonthAufgabe.BeforeScroll
        'UMonthAufgabe.CalendarInfo.SelectedAppointments.Clear()
    End Sub
    Private Sub UMonthAufgabe_BeforeAppointmentEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeAppointmentEditEventArgs) Handles UMonthAufgabe.BeforeAppointmentEdit
        e.Cancel = True
    End Sub
    Private Sub UMonthAufgabe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UMonthAufgabe.Click
        Try
            Me.contTxtEditor.clearForm()
            Me.menüUI_OnOff()
            For Each appointment As Appointment In UMonthAufgabe.CalendarInfo.SelectedAppointments
                Dim IDAufgabe As New System.Guid(appointment.Tag.ToString)
                Me.showVorschau(IDAufgabe)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UMonthAufgabe_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UMonthAufgabe.DoubleClick
        Try
            For Each appointment As Appointment In UMonthAufgabe.CalendarInfo.SelectedAppointments
                Me.appointmentOpen(appointment)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub


    Private Sub UWeekAufgabe_BeforeActivitiesDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeActivitiesDeletedEventArgs) Handles UWeekAufgabe.BeforeActivitiesDeleted
        e.Cancel = True
    End Sub
    Private Sub UWeekAufgabe_BeforeScroll(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeScrollEventArgs) Handles UWeekAufgabe.BeforeScroll
    End Sub
    Private Sub UWeekAufgabe_BeforeAppointmentEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeAppointmentEditEventArgs) Handles UWeekAufgabe.BeforeAppointmentEdit
        e.Cancel = True
    End Sub
    Private Sub UWeekAufgabe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UWeekAufgabe.Click
        Try
            Me.contTxtEditor.clearForm()
            Me.menüUI_OnOff()
            For Each appointment As Appointment In UWeekAufgabe.CalendarInfo.SelectedAppointments
                Dim IDAufgabe As New System.Guid(appointment.Tag.ToString)
                Me.showVorschau(IDAufgabe)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UWeekAufgabe_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UWeekAufgabe.DoubleClick
        Try
            For Each appointment As Appointment In UWeekAufgabe.CalendarInfo.SelectedAppointments
                Me.appointmentOpen(appointment)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub


    Private Sub UDayAufgabe_BeforeAppointmentsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeAppointmentsDeletedEventArgs) Handles UDayAufgabe.BeforeAppointmentsDeleted
        e.Cancel = True
    End Sub
    Private Sub UDayAufgabe_BeforeScroll(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeDayViewScrollEventArgs) Handles UDayAufgabe.BeforeScroll
    End Sub
    Private Sub UDayAufgabe_BeforeAppointmentEdited(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinSchedule.CancelableAppointmentEventArgs) Handles UDayAufgabe.BeforeAppointmentEdited
        e.Cancel = True
    End Sub
    Private Sub UDayAufgabe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UDayAufgabe.Click
        Try
            Me.contTxtEditor.clearForm()
            Me.menüUI_OnOff()
            For Each appointment As Appointment In UDayAufgabe.CalendarInfo.SelectedAppointments
                Dim IDAufgabe As New System.Guid(appointment.Tag.ToString)
                Me.showVorschau(IDAufgabe)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UDayAufgabe_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UDayAufgabe.DoubleClick
        Try
            For Each appointment As Appointment In UDayAufgabe.CalendarInfo.SelectedAppointments
                Me.appointmentOpen(appointment)
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UDayAufgabe_BeforeTimeSlotSelectionChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeTimeSlotSelectionChangedEventArgs) Handles UDayAufgabe.BeforeTimeSlotSelectionChanged
    End Sub


    Private Sub UltraMonthViewMulti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraMonthViewMulti.Click
        Try
            Me.UltraCalendarInfo.GetDay(DateTime.Today, True)
            Dim Day As Infragistics.Win.UltraWinSchedule.Day
            Day = UWeekAufgabe.CalendarInfo.ActiveDay()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub

    Public Sub menüUI_OnOff()
        Try
            Me.LöschenToolStripMenuItem.Visible = False

            Dim ret As New cSelApp
            Select Case Me.UTabTable.SelectedTab.Index
                Case 3
                    If Not gen.IsNull(Me.UltraGridAufgaben.ActiveRow) Then
                        Me.LöschenToolStripMenuItem.Visible = True
                    End If

                Case 0, 1, 2
                    Dim actAppoint As Appointment
                    Select Case Me.UTabTable.SelectedTab.Index
                        Case 0
                            If UMonthAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                Me.LöschenToolStripMenuItem.Visible = True
                            End If
                        Case 1
                            If Me.UWeekAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                Me.LöschenToolStripMenuItem.Visible = True
                            End If
                        Case 2
                            If Me.UDayAufgabe.CalendarInfo.SelectedAppointments.Count > 0 Then
                                Me.LöschenToolStripMenuItem.Visible = True
                            End If
                    End Select
            End Select

        Catch ex As Exception
            Throw New Exception("menüUI_OnOff: " + ex.ToString())
        End Try
    End Sub
    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        Me.SetWidthHeigth(Me.Width, Me.Height)
    End Sub

    Private Sub NeuesMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuesMailToolStripMenuItem.Click
        Me.neuesMail()
    End Sub
    Private Sub NeuerTerminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuerTerminToolStripMenuItem.Click
        Me.neuerTermin(Me.getSelectedDate)
    End Sub


    Private Sub UToolbarsManagerTextVorschau_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UToolbarsManagerTextVorschau.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "buttSpeichern"
                    Me.contTxtEditor.speichernAls()
                Case "buttDrucken"
                    Me.contTxtEditor.Print()
                Case "buttExportieren"
                    Me.contTxtEditor.Export()
                Case "buttDruckvorschau"
                    Me.contTxtEditor.PrintPreview()
            End Select


        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ret As New cSelApp
            ret = Me.getSelected_idaufgabe
            If Not gen.IsNull(ret.idaufgabe) Then
                If MsgBox("Wollen Sie die Nachricht wirklich löschen?", MsgBoxStyle.YesNo, "Nachricht löschen") = MsgBoxResult.Yes Then
                    If Me.aufgabeLöschen(ret.idaufgabe) Then
                        ' ret.appoint.sdfsdf()
                    End If
                End If
            Else
                MsgBox("Keine Nachricht ausgewählt!", MsgBoxStyle.YesNo, "Nachricht löschen")
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Public Function aufgabeLöschen(ByVal idaufgabe As System.Guid) As Boolean
        Try
            Dim aufgabe As New sqlAufgaben
            aufgabe.DeleteRow(idaufgabe)
            Return True

        Catch ex As Exception
            Throw New Exception("aufgabeLöschen: " + ex.ToString())
        End Try
    End Function


    Private Sub DruckenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DruckenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.UTabTable.SelectedTab.Index
                Case 3
                    Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
                    Me.UltraPrintPreviewDialog1.ShowDialog(Me)

                Case 0, 1, 2
                    Me.UltraPrintPreviewDialog1.Document = Me.UltraSchedulePrintDocument1

                    If Not gen.IsNull(Me.mainWindow.UDateVon.Value) Then
                        Me.UltraSchedulePrintDocument1.StartDate = Me.mainWindow.UDateVon.Value
                    Else
                        Me.UltraSchedulePrintDocument1.StartDate = Nothing
                    End If
                    If Not gen.IsNull(Me.mainWindow.UDateBis.Value) Then
                        Me.UltraSchedulePrintDocument1.EndDate = Me.mainWindow.UDateBis.Value
                    Else
                        Me.UltraSchedulePrintDocument1.EndDate = Nothing
                    End If

                    Select Case Me.UTabTable.SelectedTab.Index
                        Case 0
                            Me.UltraSchedulePrintDocument1.PrintStyle = SchedulePrintStyle.Monthly
                            Me.UltraPrintPreviewDialog1.ShowDialog(Me)
                        Case 1
                            Me.UltraSchedulePrintDocument1.PrintStyle = SchedulePrintStyle.Weekly
                            Me.UltraPrintPreviewDialog1.ShowDialog(Me)
                        Case 2
                            Me.UltraSchedulePrintDocument1.PrintStyle = SchedulePrintStyle.Daily
                            Me.UltraPrintPreviewDialog1.ShowDialog(Me)
                    End Select
            End Select

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub aufHeute()
        Try
            Dim day As Infragistics.Win.UltraWinSchedule.Day = Me.UltraCalendarInfo.ActiveDay
            Dim _date As DateTime = IIf(Not day Is Nothing, day.Date, DateTime.Today)
            day = Me.UltraCalendarInfo.GetDay(DateTime.Today, True)
            Me.UltraCalendarInfo.ActiveDay = day

        Catch ex As Exception
            Throw New Exception("aufHeute: " + ex.ToString())
        End Try
    End Sub

    Private Sub UToolbarsManagerKalender_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UToolbarsManagerKalender.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "Heute"
                    Me.aufHeute()

            End Select

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraGridAufgaben_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGridAufgaben.InitializeLayout

    End Sub

End Class
