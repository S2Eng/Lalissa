Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinSchedule
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinDock
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing



Public Class contPlanungDataBereich
    Inherits System.Windows.Forms.UserControl

    Public _LayoutGrid As eLayoutGrid

    Public Enum eLayoutGrid
        PatientsBeginn = 0
        PatientsKategorie = 1
        KategoriePatient = 2
    End Enum

    Public mainWindow As contPlanung2Bereich
    Public compPlan1 As New compPlan()
    Public isLoaded As Boolean = False
    Public IsInitializedVisible As Boolean = False

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()

    Public Class cSelEntries
        Public rowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow
        Public rPlanSel As dsPlanSearch.planRow
        Public rPlanBereichSel As dsPlanSearch.planBereichRow
        Public gridIsActive As Boolean = False
    End Class

    Private uiElem As New UI()
    Public lstColSmallViewGrid As New System.Collections.Generic.List(Of String)
    Public lstColBigViewGridDeaktivate As New System.Collections.Generic.List(Of String)
    Public ui1 As New UI()
    Public styleDropDown As Infragistics.Win.UltraWinGrid.ColumnStyle = UltraWinGrid.ColumnStyle.DropDown
    Public lockToolBarTxt As Boolean = False

    Public Enum eTypAction
        delete = 0
        selectAll = 100
        selectNone = 101
    End Enum
    Public compUserAccounts1 As New compUserAccounts()
    Public clPlan1 As New clPlan()
    Public doUI1 As New doUI()

    Public LayoutName As String = "Plans"
    Public lastTextPreview As String = ""
    Public doEditor1 As New QS2.Desktop.Txteditor.doEditor()
    Public SqlCommandReturn As String = ""
    Public sitemap1 As New PMDS.Global.UIGlobal()
    Private gen As New General()

    Public contTxtEditor1 As New QS2.Desktop.Txteditor.contTxtEditor()
    Public isFirstShow As Boolean = True

    Public b As New PMDS.db.PMDSBusiness()

    Public lNachrichtenBereichOpend As New System.Collections.Generic.List(Of Form)









    Friend WithEvents PanelAnzeige As System.Windows.Forms.Panel
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents gridPlans As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStripNeu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemSpace As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uPrintDocument1 As Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents DsPlanSearch1 As dsPlanSearch
    Friend WithEvents LöschenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllesAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswahälenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents PanelEditorToWork As System.Windows.Forms.Panel
    Friend WithEvents TextControlToWork As TXTextControl.TextControl
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents PanelTxtEditor As Panel
    Friend WithEvents TermineErledigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TermineStornierenToolStripMenuItem As ToolStripMenuItem


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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("planBereich", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff", -1, Nothing, 4, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BeginntAm", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EndetAm")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstAbteilungen", -1, Nothing, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstBereiche", -1, Nothing, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Category", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Folder")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Teilnehmer")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSerientermin")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TagWochenMonat")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("WiedWertJeden")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Wochentage")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nTenMonat")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminType")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GanzerTag")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsSerientermin")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminEndetAm")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedFrom")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedAt")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastChangeFrom")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastChangeAt")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lstBerufsgruppen")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(273914762)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(368799640)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(64791755)
        Dim ValueList4 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(82828532)
        Me.ContextMenuStripNeu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TermineErledigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermineStornierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllesAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswahälenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace = New System.Windows.Forms.ToolStripSeparator()
        Me.PanelAnzeige = New System.Windows.Forms.Panel()
        Me.gridPlans = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsPlanSearch1 = New PMDS.GUI.VB.dsPlanSearch()
        Me.PanelEditorToWork = New System.Windows.Forms.Panel()
        Me.TextControlToWork = New TXTextControl.TextControl()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanelTxtEditor = New System.Windows.Forms.Panel()
        Me.uPrintDocument1 = New Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.ContextMenuStripNeu.SuspendLayout()
        Me.PanelAnzeige.SuspendLayout()
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripNeu
        '
        Me.ContextMenuStripNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ContextMenuStripNeu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TermineErledigenToolStripMenuItem, Me.TermineStornierenToolStripMenuItem, Me.ToolStripMenuItem3, Me.LöschenToolStripMenuItem1, Me.ToolStripMenuItemSpace1, Me.AllesAuswählenToolStripMenuItem, Me.KeineAuswahälenToolStripMenuItem, Me.ToolStripMenuItemSpace4, Me.FilterToolStripMenuItem})
        Me.ContextMenuStripNeu.Name = "ContextMenuStripNeu"
        Me.ContextMenuStripNeu.Size = New System.Drawing.Size(179, 154)
        '
        'TermineErledigenToolStripMenuItem
        '
        Me.TermineErledigenToolStripMenuItem.Name = "TermineErledigenToolStripMenuItem"
        Me.TermineErledigenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TermineErledigenToolStripMenuItem.Tag = "ResID.TermineErledigen"
        Me.TermineErledigenToolStripMenuItem.Text = "Termine erledigen"
        '
        'TermineStornierenToolStripMenuItem
        '
        Me.TermineStornierenToolStripMenuItem.Name = "TermineStornierenToolStripMenuItem"
        Me.TermineStornierenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TermineStornierenToolStripMenuItem.Tag = "ResID.TermineStornieren"
        Me.TermineStornierenToolStripMenuItem.Text = "Termine stornieren"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(175, 6)
        '
        'LöschenToolStripMenuItem1
        '
        Me.LöschenToolStripMenuItem1.Name = "LöschenToolStripMenuItem1"
        Me.LöschenToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.LöschenToolStripMenuItem1.Tag = "ResID.Delete"
        Me.LöschenToolStripMenuItem1.Text = "Löschen"
        '
        'ToolStripMenuItemSpace1
        '
        Me.ToolStripMenuItemSpace1.Name = "ToolStripMenuItemSpace1"
        Me.ToolStripMenuItemSpace1.Size = New System.Drawing.Size(175, 6)
        '
        'AllesAuswählenToolStripMenuItem
        '
        Me.AllesAuswählenToolStripMenuItem.Name = "AllesAuswählenToolStripMenuItem"
        Me.AllesAuswählenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AllesAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AllesAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswahälenToolStripMenuItem
        '
        Me.KeineAuswahälenToolStripMenuItem.Name = "KeineAuswahälenToolStripMenuItem"
        Me.KeineAuswahälenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.KeineAuswahälenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswahälenToolStripMenuItem.Text = "Keine auswählen"
        '
        'ToolStripMenuItemSpace4
        '
        Me.ToolStripMenuItemSpace4.Name = "ToolStripMenuItemSpace4"
        Me.ToolStripMenuItemSpace4.Size = New System.Drawing.Size(175, 6)
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.CheckOnClick = True
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.FilterToolStripMenuItem.Tag = "ResID.Filter"
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'ToolStripMenuItemSpace
        '
        Me.ToolStripMenuItemSpace.Name = "ToolStripMenuItemSpace"
        Me.ToolStripMenuItemSpace.Size = New System.Drawing.Size(195, 6)
        '
        'PanelAnzeige
        '
        Me.PanelAnzeige.BackColor = System.Drawing.Color.Transparent
        Me.PanelAnzeige.Controls.Add(Me.gridPlans)
        Me.PanelAnzeige.Controls.Add(Me.PanelEditorToWork)
        Me.PanelAnzeige.Controls.Add(Me.TextControlToWork)
        Me.PanelAnzeige.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAnzeige.Location = New System.Drawing.Point(0, 0)
        Me.PanelAnzeige.Name = "PanelAnzeige"
        Me.PanelAnzeige.Size = New System.Drawing.Size(843, 226)
        Me.PanelAnzeige.TabIndex = 392
        '
        'gridPlans
        '
        Me.gridPlans.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.gridPlans.DataMember = "planBereich"
        Me.gridPlans.DataSource = Me.DsPlanSearch1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 9
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 346
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.Caption = "Beginnt am"
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn3.Width = 102
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn4.Width = 108
        UltraGridColumn5.Header.Caption = "Abteilung"
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.Width = 113
        UltraGridColumn6.Header.Caption = "Bereich"
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.Width = 121
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 100
        UltraGridColumn8.Header.Caption = "Kategorie"
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Width = 178
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 14
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 248
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 7
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.Editor = Nothing
        UltraGridColumn28.Header.VisiblePosition = 18
        UltraGridColumn28.Hidden = True
        UltraGridColumn37.Header.Editor = Nothing
        UltraGridColumn37.Header.VisiblePosition = 19
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.Editor = Nothing
        UltraGridColumn38.Header.VisiblePosition = 20
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.Editor = Nothing
        UltraGridColumn39.Header.VisiblePosition = 15
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.Header.Editor = Nothing
        UltraGridColumn40.Header.VisiblePosition = 16
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.Header.Editor = Nothing
        UltraGridColumn41.Header.VisiblePosition = 17
        UltraGridColumn41.Hidden = True
        UltraGridColumn42.Header.Editor = Nothing
        UltraGridColumn42.Header.VisiblePosition = 21
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.Editor = Nothing
        UltraGridColumn43.Header.VisiblePosition = 22
        UltraGridColumn43.Hidden = True
        UltraGridColumn44.Header.Editor = Nothing
        UltraGridColumn44.Header.VisiblePosition = 23
        UltraGridColumn44.Hidden = True
        UltraGridColumn45.Header.Editor = Nothing
        UltraGridColumn45.Header.VisiblePosition = 24
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.Editor = Nothing
        UltraGridColumn46.Header.VisiblePosition = 8
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.Caption = "Erstellt von"
        UltraGridColumn47.Header.Editor = Nothing
        UltraGridColumn47.Header.VisiblePosition = 10
        UltraGridColumn47.Width = 91
        UltraGridColumn48.Header.Caption = "Erstellt am"
        UltraGridColumn48.Header.Editor = Nothing
        UltraGridColumn48.Header.VisiblePosition = 11
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn48.Width = 111
        UltraGridColumn49.Header.Caption = "Letzte Änderung von"
        UltraGridColumn49.Header.Editor = Nothing
        UltraGridColumn49.Header.VisiblePosition = 12
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.Header.Caption = "Letzte Änderung am"
        UltraGridColumn50.Header.Editor = Nothing
        UltraGridColumn50.Header.VisiblePosition = 13
        UltraGridColumn50.Hidden = True
        UltraGridColumn50.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn51.Header.Editor = Nothing
        UltraGridColumn51.Header.VisiblePosition = 25
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn27, UltraGridColumn28, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51})
        Me.gridPlans.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Appearance2.BackColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.gridPlans.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.gridPlans.DisplayLayout.MaxColScrollRegions = 1
        Me.gridPlans.DisplayLayout.MaxRowScrollRegions = 1
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.AddRowAppearance = Appearance4
        Me.gridPlans.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridPlans.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Me.gridPlans.DisplayLayout.Override.RowSpacingAfter = 1
        Me.gridPlans.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance6.BackColor = System.Drawing.Color.DarkGray
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.gridPlans.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        ValueList1.Key = "IDArt"
        ValueList2.Key = "anhang"
        ValueList3.Key = "Folders"
        ValueList4.Key = "PlanCategory"
        Me.gridPlans.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3, ValueList4})
        Me.gridPlans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPlans.Location = New System.Drawing.Point(0, 0)
        Me.gridPlans.Name = "gridPlans"
        Me.gridPlans.Size = New System.Drawing.Size(843, 226)
        Me.gridPlans.TabIndex = 0
        '
        'DsPlanSearch1
        '
        Me.DsPlanSearch1.DataSetName = "dsPlanSearch"
        Me.DsPlanSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelEditorToWork
        '
        Me.PanelEditorToWork.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditorToWork.Location = New System.Drawing.Point(9, 7)
        Me.PanelEditorToWork.Name = "PanelEditorToWork"
        Me.PanelEditorToWork.Size = New System.Drawing.Size(43, 23)
        Me.PanelEditorToWork.TabIndex = 618
        '
        'TextControlToWork
        '
        Me.TextControlToWork.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextControlToWork.Location = New System.Drawing.Point(16, 10)
        Me.TextControlToWork.Name = "TextControlToWork"
        Me.TextControlToWork.PageMargins.Bottom = 79.03R
        Me.TextControlToWork.PageMargins.Left = 79.03R
        Me.TextControlToWork.PageMargins.Right = 79.03R
        Me.TextControlToWork.PageMargins.Top = 79.03R
        Me.TextControlToWork.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextControlToWork.Size = New System.Drawing.Size(26, 18)
        Me.TextControlToWork.TabIndex = 617
        Me.TextControlToWork.UserNames = Nothing
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelAnzeige)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelBody)
        Me.SplitContainer1.Size = New System.Drawing.Size(843, 550)
        Me.SplitContainer1.SplitterDistance = 226
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 394
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.Transparent
        Me.PanelBody.Controls.Add(Me.PanelTxtEditor)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 0)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(843, 319)
        Me.PanelBody.TabIndex = 3
        '
        'PanelTxtEditor
        '
        Me.PanelTxtEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelTxtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTxtEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelTxtEditor.Name = "PanelTxtEditor"
        Me.PanelTxtEditor.Size = New System.Drawing.Size(843, 319)
        Me.PanelTxtEditor.TabIndex = 5
        '
        'uPrintDocument1
        '
        Me.uPrintDocument1.PrintStyle = Infragistics.Win.UltraWinSchedule.SchedulePrintStyle.Monthly
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Document = Me.uPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        Me.UltraPrintPreviewDialog1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.Grid = Me.gridPlans
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contPlanungDataBereich
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "contPlanungDataBereich"
        Me.Size = New System.Drawing.Size(843, 550)
        Me.ContextMenuStripNeu.ResumeLayout(False)
        Me.PanelAnzeige.ResumeLayout(False)
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub AufgabeTerminÜbersicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            If Me.isLoaded Then
                Exit Sub
            End If

            Me.initTxtControl()

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
            Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)

            'Me.LöschenToolStripMenuItem1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.gridPlans.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Always
            Me.setUIContextSelectAlleKeine(True)

            Me.lstColSmallViewGrid.Clear()

            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName)
            'Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDStatusColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.FälligAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDArtColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.MailAnColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.PrioritätColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.StatusColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.FürColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.gesendetAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.wichtigColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.anzObjectsColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.anzAnhängeColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IsOwnerColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.FolderColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDFolderColumn.ColumnName)

            Me.uiElem.gridErwSicht(False, Me.gridPlans, lstColSmallViewGrid, Me.lstColBigViewGridDeaktivate)
            Me.ui1.setMergeStyle(Me.gridPlans, False, True)

            Dim dropDownStatus As New dropDownGridSelList()
            dropDownStatus.initControl()
            dropDownStatus.loadSelLists("STATPA", General.eKeyCol.IDStr)
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDStatusColumn.ColumnName).ValueList = dropDownStatus.dropDownSelList
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDStatusColumn.ColumnName).Style = Me.styleDropDown

            Dim dropDownTyp As New dropDownGridSelList()
            dropDownTyp.initControl()
            dropDownTyp.loadSelLists("TYPPA", General.eKeyCol.IDStr)
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName).ValueList = dropDownTyp.dropDownSelList
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName).Style = Me.styleDropDown

            Dim dsAuswahList As New dsAuswahllisten()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.gen.loadSelList(Me.gridPlans.DisplayLayout.ValueLists("IDArt"), Nothing, "PT", tSelListEntriesReturn, General.eKeyCol.IDNr, MaxIDSelListEntryReturn)

            'Me.LayoutManagerToolStripMenuItem.Image = ITSCont.core.SystemDb.getRes.getImage(getRes.ePicture.ico_selLists, getRes.ePicTyp.ico)
            If PMDS.Global.ENV.adminSecure Then

            Else

            End If

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.initControl: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub initTxtControl()
        Try
            Me.contTxtEditor1.Dock = DockStyle.Fill
            Me.PanelTxtEditor.Controls.Add(Me.contTxtEditor1)
            Me.contTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.onlyShow
            Me.contTxtEditor1.LinealeOnOff(True)
            Me.contTxtEditor1.SetUIReadOnOff(False)
            Me.contTxtEditor1.loadForm(False, Nothing, False, False)
            Me.contTxtEditor1.setControlTyp()
            Me.contTxtEditor1.buttonBar1.Visible = False
            Me.contTxtEditor1.FileNew(False, False)
            Me.contTxtEditor1.lockEingbe = True

            AddHandler Me.contTxtEditor1.textControl1_IsToSave, AddressOf Me.textControl1_IsToSave

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.initTxtControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub textControl1_IsToSave()
        Try


        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.initTxtControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUI(LayoutGrid As contPlanungData.eLayoutGrid)
        Try
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Clear()
            For Each col As UltraGridColumn In Me.gridPlans.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            'If iTyp = clPlan.typPlan_AufgabeTermin Then
            'Else
            'End If

            Dim colWidth_PatientName As Integer = 170
            Dim colWidth_BeginntAm As Integer = 120
            Dim colWidth_Betreff As Integer = 260
            Dim colWidth_Category As Integer = 280

            If LayoutGrid = eLayoutGrid.PatientsBeginn Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Header.VisiblePosition = 0
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Width = colWidth_PatientName
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Header.VisiblePosition = 1
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Width = colWidth_BeginntAm
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Header.VisiblePosition = 2
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Width = colWidth_Betreff
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Header.VisiblePosition = 3
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Width = colWidth_Category
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName, False, False)


            ElseIf LayoutGrid = eLayoutGrid.PatientsKategorie Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Header.VisiblePosition = 0
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Width = colWidth_PatientName
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Header.VisiblePosition = 1
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Width = colWidth_Category
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Header.VisiblePosition = 2
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Width = colWidth_BeginntAm
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Header.VisiblePosition = 3
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Width = colWidth_Betreff
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName, False, False)


            ElseIf LayoutGrid = eLayoutGrid.KategoriePatient Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Header.VisiblePosition = 0
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Width = colWidth_Category
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Header.VisiblePosition = 1
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Width = colWidth_PatientName
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Header.VisiblePosition = 2
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Width = colWidth_BeginntAm
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName, False, False)

                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Hidden = False
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Header.VisiblePosition = 3
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Width = colWidth_Betreff
                Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName, False, False)


                'ElseIf LayoutGrid = eLayoutGrid.Beginn Then
                '    Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical

                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Hidden = False
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Header.VisiblePosition = 0
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Width = colWidth_Category
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                '    Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.CategoryColumn.ColumnName, False, False)

                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Hidden = True
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Header.VisiblePosition = 1
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Width = colWidth_PatientName
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                '    Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.PatientNameColumn.ColumnName, False, False)

                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Hidden = False
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Header.VisiblePosition = 2
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Width = colWidth_BeginntAm
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
                '    Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName, False, False)

                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Hidden = False
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Header.VisiblePosition = 3
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Width = colWidth_Betreff
                '    Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                '    Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName, False, False)

            Else
                Throw New Exception("contPlanungDataBereich.setUI: LayoutGrid '" + LayoutGrid.ToString() + "' not allowed!")
            End If

            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.EndetAmColumn.ColumnName).Hidden = False
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.EndetAmColumn.ColumnName).Header.VisiblePosition = 100
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.EndetAmColumn.ColumnName).Width = 120
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.EndetAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.EndetAmColumn.ColumnName, False, False)

            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).Hidden = False
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).Header.VisiblePosition = 101
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).Width = 100
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).Header.Appearance.TextHAlign = HAlign.Center
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName).CellAppearance.TextHAlign = HAlign.Center
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.DauerStrColumn.ColumnName, False, False)

            If PMDS.Global.ENV.adminSecure Then
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).Hidden = False
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).Header.VisiblePosition = 101
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).Width = 100
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).Header.Appearance.TextHAlign = HAlign.Center
                'Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.DauerColumn.ColumnName).CellAppearance.TextHAlign = HAlign.Center
                'Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.DauerColumn.ColumnName, False, False)
            End If

            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.GanzerTagColumn.ColumnName).Hidden = False
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.GanzerTagColumn.ColumnName).Header.VisiblePosition = 102
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.GanzerTagColumn.ColumnName).Width = 85
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.GanzerTagColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.CheckBox
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.GanzerTagColumn.ColumnName, False, False)

            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName).Hidden = False
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName).Header.VisiblePosition = 103
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName).Width = 100
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.Default
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName, False, False)

            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName).Hidden = False
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName).Header.VisiblePosition = 104
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName).Width = 120
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName).Style = UltraWinGrid.ColumnStyle.DateTime
            Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName, False, False)

            Me.gridPlans.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
            Me.gridPlans.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.Beige

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.setUI: " + ex.ToString())
        End Try
    End Sub

    Public Function search(doInit As Boolean, userClicked As Boolean, ByRef SetUIGrid As Boolean) As Boolean
        Try
            Me.mainWindow.lockToolbar = False
            Me.mainWindow.lblFound.Text = ""

            Dim tDesign As Integer = 0
            If userClicked Then
                'If lstPatients.Count = 0 Then
                'doUI.doMessageBox2("NoPatientsSelected", "", "!")
                'Return False
            End If

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)

            Me.clear()

            Dim sqlErledigt As String = ""
            Dim sqlPriorität As String = ""

            Select Case Me.mainWindow.getStatus()
                Case "Erledigt"
                    sqlErledigt = " planObject_1.Status='Erledigt' "
                Case "Storniert"
                    sqlErledigt = " planObject_1.Status='Storniert' "
                Case "Offen"
                    sqlErledigt = " (planObject_1.Status<>'Erledigt' AND planObject_1.Status<>'Storniert') "
            End Select

            Dim sqlEMailGesendet As String = ""
            If Me.mainWindow.getStatMail = General.eAuswahlStatusMail.gesendet Then
                sqlEMailGesendet = " (not [plan].gesendetAm is null) "
            ElseIf Me.mainWindow.getStatMail = General.eAuswahlStatusMail.entwürfe Then
                sqlEMailGesendet = " ( [plan].gesendetAm is null) "
            End If

            Dim lstSelectedAbteilungen As New System.Collections.Generic.List(Of String)()
            Dim lstSelectedBereiche As New System.Collections.Generic.List(Of String)()
            Dim lstSelectedBerufsgruppen As New System.Collections.Generic.List(Of String)()

            Me.SqlCommandReturn = ""
            Dim suche As New suchePlan()
            suche.searchPlanBereich(Me.DsPlanSearch1, sqlPriorität, sqlErledigt, sqlEMailGesendet,
                            Me.mainWindow.UDateVon.Value, Me.mainWindow.UDateBis.Value,
                            Me.mainWindow.txtBetreff2.Text.Trim(), SqlCommandReturn,
                            lstSelectedCategories, lstSelectedAbteilungen, lstSelectedBereiche, lstSelectedBerufsgruppen,
                            Me._LayoutGrid, PMDS.Global.ENV.IDKlinik)


            'Dim lstPlansToDelete As New System.Collections.Generic.List(Of dsPlanSearch.planRow)
            'Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
            '    For Each rPlan As dsPlanSearch.planRow In Me.DsPlanSearch1.plan
            '        Dim sFormattedTimespan As String = ""
            '        Dim tEndetAmBeginntAm As TimeSpan = rPlan.EndetAm - rPlan.BeginntAm
            '        If tEndetAmBeginntAm.Days > 0 Then
            '            sFormattedTimespan = String.Format("{0:D}T {1:D2}:{2:D2}", tEndetAmBeginntAm.Days, tEndetAmBeginntAm.Hours, tEndetAmBeginntAm.Minutes)
            '            rPlan.DauerStr = sFormattedTimespan
            '        Else
            '            sFormattedTimespan = String.Format("{0:D2}:{1:D2}", tEndetAmBeginntAm.Hours, tEndetAmBeginntAm.Minutes)
            '            rPlan.DauerStr = sFormattedTimespan
            '        End If

            '        Dim bPatIsAbwesend As Boolean = False
            '        If Me._LayoutGrid = eLayoutGrid.PatientsBeginn Or Me._LayoutGrid = eLayoutGrid.PatientsKategorie Or Me._LayoutGrid = eLayoutGrid.KategoriePatient Then
            '        End If
            '    Next
            'End Using

            'For Each rPlanToDelete As dsPlanSearch.planRow In lstPlansToDelete
            '    rPlanToDelete.Delete()
            'Next
            Me.DsPlanSearch1.AcceptChanges()

            gridPlans.Refresh()
            clPlan.anzNachrichten = Me.DsPlanSearch1.plan.Rows.Count
            Me.mainWindow.setAzahl_buttSuchen(Me.DsPlanSearch1.plan.Rows.Count)

            Me.gridPlans.Selected.Rows.Clear()
            Me.gridPlans.ActiveRow = Nothing

            If SetUIGrid Then
                Me.setUI(Me._LayoutGrid)
            End If
            Me.gridPlans.Rows.ExpandAll(True)
            'doUI.doMessageBox2("PleaseSelectAPlanTypeInTheLeftNavigationAssistants", "Search", "!")
            Me.setUIAnzahl(Me.gridPlans.Rows.Count)
            Me.mainWindow.lockToolbar = False

            Return True

        Catch ex As Exception
            Me.mainWindow.lockToolbar = False
            Throw New Exception("contPlanungDataBereich.search3: " + ex.ToString())
        End Try
    End Function
    Public Sub setUIAnzahl(iFound As Integer)
        Try
            Me.mainWindow.lblFound.Text = doUI.getRes("Founded") + ": " + iFound.ToString()

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.setUIAnzahl: " + ex.ToString())
        End Try
    End Sub

    Public Sub clear()
        Try
            Me.DsPlanSearch1.Clear()
            gridPlans.Refresh()
            Me.contTxtEditor1.textControl1.Text = ""

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.clear: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedPlanungseinträge(ByRef gridIsInFront As Boolean) As System.Collections.Generic.List(Of cSelEntries)
        Try
            Dim ret As New System.Collections.Generic.List(Of cSelEntries)
            gridIsInFront = True
            If Not gen.IsNull(Me.gridPlans.ActiveRow) Then
                Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
                PMDS.Global.generic.getSelectedGridRows(Me.gridPlans, rSelected, False)
                If rSelected.Count > 0 Then
                    For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                        Dim v As DataRowView = rGrid.ListObject
                        Dim rPlanSel As dsPlanSearch.planBereichRow = v.Row

                        Dim cSelApp1 As New cSelEntries()
                        cSelApp1.rowGrid = rGrid
                        cSelApp1.rPlanBereichSel = rPlanSel
                        cSelApp1.gridIsActive = True
                        ret.Add(cSelApp1)
                    Next
                End If
            End If

            Return ret

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.getSelectedPlanungseinträge: " + ex.ToString())
        End Try
    End Function
    Public Sub selectAllNoneGrid(ByVal bOn As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As UltraGridRow In PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridPlans, False, True)
                If PMDS.Global.generic.IsInExpandedGroup(r) Then
                    r.Selected = bOn
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.selectAllNoneGrid: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub pläneÖffnen(ByVal withMsgBox As Boolean)
        Try
            Dim gridIsInFront As Boolean = False
            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseinträge(gridIsInFront)
            If selectedApp.Count > 0 Then
                For Each cSelEntries1 As cSelEntries In selectedApp
                    Me.planÖffnen(cSelEntries1.rPlanBereichSel.ID)
                Next
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.einträgeÖffnen: " + ex.ToString())
        End Try
    End Sub
    Private Sub planÖffnen(IDPlanBereich As Guid)
        Try
            Dim bFrmFound As Boolean = False
            For Each frmPlan As frmNachrichtBereich In lNachrichtenBereichOpend
                If Not frmPlan.IsOpend Then
                    frmPlan.IDPlanBereich = IDPlanBereich
                    frmPlan.IsNew = False
                    frmPlan.Visible = True
                    frmPlan.Show()
                End If
            Next

            If Not bFrmFound Then
                Dim frmNachrichtBereich1 As New frmNachrichtBereich()
                frmNachrichtBereich1.initControl()
                frmNachrichtBereich1.IDPlanBereich = IDPlanBereich
                frmNachrichtBereich1.IsNew = False
                frmNachrichtBereich1.Visible = True
                frmNachrichtBereich1.Show()

                Me.lNachrichtenBereichOpend.Add(frmNachrichtBereich1)
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.planÖffnen: " + ex.ToString())
        End Try
    End Sub
    Public Function getFreeFormPlanBereich() As frmNachrichtBereich
        Try
            Dim bFrmFound As Boolean = False
            For Each frmPlan As frmNachrichtBereich In lNachrichtenBereichOpend
                If Not frmPlan.IsOpend Then
                    Return frmPlan
                End If
            Next

            If Not bFrmFound Then
                Dim frmNachrichtBereich1 As New frmNachrichtBereich()
                Me.lNachrichtenBereichOpend.Add(frmNachrichtBereich1)
                Return frmNachrichtBereich1
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.getFreeFormPlanBereich: " + ex.ToString())
        End Try
    End Function

    Public Sub SetWidthHeigth(ByVal Width As Integer, ByVal Height As Integer)
        Try
            Me.Width = Width
            Me.Height = Height

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.SetWidthHeigth: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraGridAufgaben_BeforeRowsDeleted1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridPlans.BeforeRowsDeleted
        Try
            If Me.gridPlans.Focused Then
                e.Cancel = True
                'e.DisplayPromptMsg = False
                'If Not Me.deletePlansMenü() Then
                '    e.Cancel = True
                'End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UltraGridAufgaben_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPlans.Click
        Try
            If Me.sitemap1.evClickOK(sender, e, Me.gridPlans) Then
                If gridPlans.Focused Then
                    Me.Cursor = Cursors.WaitCursor

                    Me.doEditor1.showText("", TXTextControl.StreamType.PlainText, False, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)

                    If Not gen.IsNull(gridPlans.ActiveRow) Then
                        If Me.gridPlans.ActiveRow.IsGroupByRow Or Me.gridPlans.ActiveRow.IsFilterRow Then
                            Exit Sub
                        End If

                        Dim v As DataRowView = gridPlans.ActiveRow.ListObject
                        Dim rPlanBereich As dsPlanSearch.planBereichRow = v.Row

                        Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                            Dim rPlanBereichDb = (From o In db.planBereich
                                                  Where o.ID = rPlanBereich.ID
                                                  Select o.ID, o.Text).ToList().First()

                            Me.showPrieviewTXTControl(rPlanBereichDb.Text)
                        End Using
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraGridAufgaben_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPlans.DoubleClick
        Try
            If sitemap1.evDoubleClickOK(sender, e, Me.gridPlans) Then
                Me.pläneÖffnen(False)

                If Not gen.IsNull(gridPlans.ActiveRow) Then
                    If gridPlans.ActiveRow.IsGroupByRow Then
                        Exit Sub
                    End If
                    Dim v As DataRowView = gridPlans.ActiveRow.ListObject
                    Dim rPlan As dsPlanSearch.planBereichRow = v.Row
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub UMonthAufgabe_BeforeActivitiesDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeActivitiesDeletedEventArgs)
        Try
            e.Cancel = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UMonthAufgabe_BeforeAppointmentEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeAppointmentEditEventArgs)
        Try
            e.Cancel = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        Try
            Me.SetWidthHeigth(Me.Width, Me.Height)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UToolbarsManagerKalender_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "Heute"


            End Select

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraGridAufgaben_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridPlans.BeforeCellActivate
        Try
            If e.Cell.Row.IsFilterRow Then
                e.Cell.Activation = Activation.AllowEdit
            Else
                e.Cell.Activation = Activation.NoEdit
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Function doAction(ByVal typAction As eTypAction, ByVal withMsgBox As Boolean,
                              Optional ByVal bVal As Boolean = False, Optional ByVal txt As String = "",
                              Optional ByVal IDNrxy As Integer = -1, Optional Folder As String = "") As Boolean
        Try
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsrLoggedIn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)

                Dim bSendOnServer As Boolean = False
                Dim dsInteropPar1 As dsInteropPar
                Dim rUsrAccount As dsUserAccounts.tblUserAccountsRow = Nothing
                Dim protokollTitle As String = ""
                Dim protokollTxt As String = ""
                Dim msgBoxStr As String = ""
                Dim anzErr As Integer = 0
                Dim protokollSaveTxt As String = ""

                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                Dim gridIsInFront As Boolean = False
                Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseinträge(gridIsInFront)

                Dim lstPlansSelected As New System.Collections.Generic.List(Of General.cInfoPlan)
                Dim compPlanWork As New compPlan()
                Dim dsPlanWork As New dsPlan()
                Me.TextControlToWork.Text = ""
                Dim resSerientermineSeleteAll As DialogResult = False

                If selectedApp.Count = 0 Then
                    If withMsgBox Then
                        doUI.doMessageBox2("NoEntrySelected", "", "!")
                        Return False
                    End If
                End If

                Dim resMsgBox As MsgBoxResult = MsgBoxResult.Yes
                Dim txtMsg As String = ""
                If typAction = eTypAction.delete Then
                    txtMsg = doUI.getRes("DeletePlans") + "?"
                    txtMsg = String.Format(txtMsg, selectedApp.Count.ToString())
                    Dim txtMsgTitle As String = doUI.getRes("Delete")
                    resMsgBox = doUI.doMessageBoxTranslated(txtMsg, txtMsgTitle, MsgBoxStyle.YesNo)
                    protokollTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Löschen Termine")

                    Dim bSerienterminSelected As Boolean = False
                    For Each cSelAppActuell As cSelEntries In selectedApp
                        If Not cSelAppActuell.rPlanSel.IsIDSerienterminNull() Then
                            bSerienterminSelected = True
                        End If
                    Next

                    If bSerienterminSelected Then
                        Dim sMsgBoxTxt11 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Serientermine zum Löschen ausgewählt!")
                        Dim sMsgBoxTxt12 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen bei Serienterminen alle Termine gelöscht werden?")
                        resSerientermineSeleteAll = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTxt11 + vbNewLine + sMsgBoxTxt12, "", MessageBoxButtons.YesNo, True)
                    End If

                End If

                If resMsgBox = MsgBoxResult.Yes Then

                    anzErr = 0
                    Dim anz As Integer = 0
                    For Each cSelAppActuell As cSelEntries In selectedApp
                        If typAction = eTypAction.delete Then
                            Dim bDoDelete As Boolean = False
                            Dim tUser As IQueryable(Of PMDS.db.Entities.Benutzer) = Me.b.getUserByUserName2(cSelAppActuell.rPlanSel.ErstelltVon.Trim(), db)
                            If tUser.Count = 1 Then
                                Dim rUsr As PMDS.db.Entities.Benutzer = tUser.First
                                If ((Not rUsr.IDBerufsstand Is Nothing) AndAlso Me.b.UserCanSign(rUsr.IDBerufsstand.Value)) Or PMDS.Global.ENV.adminSecure Then
                                    bDoDelete = True
                                End If
                            Else
                                bDoDelete = True
                            End If
                            If bDoDelete Then
                                Dim IDPlan As System.Guid = cSelAppActuell.rPlanSel.ID
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} wurde gelöscht!")
                                sMsgBoxTxt = String.Format(sMsgBoxTxt, cSelAppActuell.rPlanSel.Betreff.Trim() + " (" + cSelAppActuell.rPlanSel.ErstelltAm.ToString("dd.MM.yyyy HH:mm:ss") + ")")
                                protokollSaveTxt += sMsgBoxTxt.Trim() + vbNewLine

                                'cOutlookWebAPI1.deleteOutlookItem(IDPlan, cSelAppActuell.rPlanSel.SendWithPostOfficeBoxForAll)
                                If resSerientermineSeleteAll = DialogResult.Yes Then
                                    If Not cSelAppActuell.rPlanSel.IsIDSerienterminNull() Then
                                        Me.compPlan1.deletePlanSerientermine(cSelAppActuell.rPlanSel.IDSerientermin)
                                    End If
                                End If
                                Me.compPlan1.deletePlan(cSelAppActuell.rPlanSel.ID, cSelAppActuell.rPlanSel.MessageId, cSelAppActuell.rPlanSel.Für, cSelAppActuell.rPlanSel.IDArt, cSelAppActuell.rPlanSel.Betreff)

                                If gridIsInFront Then
                                    cSelAppActuell.rPlanSel.Delete()
                                End If
                            Else
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} kann nicht gelöscht werden!")
                                sMsgBoxTxt = String.Format(sMsgBoxTxt, cSelAppActuell.rPlanSel.Betreff.Trim() + " (" + cSelAppActuell.rPlanSel.ErstelltAm.ToString("dd.MM.yyyy HH:mm:ss") + ")")
                                protokollTxt += sMsgBoxTxt.Trim() + vbNewLine
                            End If

                        ElseIf typAction = eTypAction.selectAll Then
                            If gridIsInFront Then
                                cSelAppActuell.rowGrid.Selected = True
                            End If

                        ElseIf typAction = eTypAction.selectNone Then
                            If gridIsInFront Then
                                cSelAppActuell.rowGrid.Selected = False
                            End If

                        End If
                    Next

                    If typAction = eTypAction.delete Then
                        If gridIsInFront Then
                            Me.search(False, True, False)
                            'Me.gridPlans.Refresh()
                        End If
                        If withMsgBox Then
                            Dim strText As String = doUI.getRes("ActivityPerformed2")
                            strText = String.Format(strText, selectedApp.Count.ToString())
                            doUI.doMessageBoxTranslated(strText, "", "!")
                        End If
                        If protokollTxt.Trim() <> "" Then
                            protokollTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Termine können nicht gelöscht werden da keine Berechtigung:") + vbNewLine + vbNewLine + protokollTxt
                        End If

                    End If

                    If protokollTxt.Trim() <> "" Then
                        Me.doProtokoll(protokollTxt, protokollTitle, anzErr)
                    End If
                    If protokollSaveTxt.Trim() <> "" Then
                        Dim sTxtTitleProt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine löschen")
                        Me.b.saveProtocol(db, sTxtTitleProt, protokollSaveTxt)
                    End If

                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.doAction: " + ex.ToString())
        End Try
    End Function
    Public Sub doProtokoll(ByRef protkoll As String, ByRef title As String, ByVal anzErr As Integer)
        Try
            If protkoll.Trim() <> "" Then
                Dim frmProt As New QS2.core.vb.frmProtocol()
                frmProt.initControl()
                frmProt.Show()
                frmProt.ContProtocol1.setText(protkoll.Trim())
                frmProt.Text = title
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.doProtokoll: " + ex.ToString())
        End Try
    End Sub

    Public Sub print()
        Try
            Dim callMainFctPlan As New PMDS.Global.ENV.eCallMainFctPlan()
            callMainFctPlan.ds = Me.DsPlanSearch1.Copy()

            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("IDAufenthalt", GetType(Guid))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Nachname", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Vorname", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Geschlecht", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Alter", GetType(Int32))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Abteilung", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Bereich", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("Klinik", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Columns.Add("IDUrlaub", GetType(Guid))

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rPlan As dsPlanSearch.planRow In callMainFctPlan.ds.Tables(Me.DsPlanSearch1.plan.TableName.Trim()).Rows
                    If rPlan.IDPatient <> System.Guid.Empty Then
                        If Not rPlan.IsIDPatientNull() Then
                            Dim rPatient As PMDS.db.Entities.Patient = Me.b.getPatient2(rPlan.IDPatient, db)
                            rPlan("Nachname") = rPatient.Nachname.Trim()
                            rPlan("Vorname") = rPatient.Vorname.Trim()
                            rPlan("Geschlecht") = rPatient.Sexus.Trim()
                            Dim iAlter As Integer = PMDS.db.PMDSBusiness.GetAgeFromDate(rPatient.Geburtsdatum)
                            rPlan("Alter") = iAlter

                            Dim rAufenthalt As PMDS.db.Entities.Aufenthalt = Me.b.getAktuellerAufenthaltPatient(rPlan.IDPatient, False, db)
                            rPlan("IDAufenthalt") = rAufenthalt.ID

                            If Not rAufenthalt.IDAbteilung Is Nothing Then
                                Dim rAbteilung As PMDS.db.Entities.Abteilung = Me.b.getAbteilung(rAufenthalt.IDAbteilung.Value, db)
                                rPlan("Abteilung") = rAbteilung.Bezeichnung.Trim()
                            End If
                            If Not rAufenthalt.IDBereich Is Nothing Then
                                Dim rBereich As PMDS.db.Entities.Bereich = Me.b.getBereich(rAufenthalt.IDBereich, db)
                                rPlan("Bereich") = rBereich.Bezeichnung.Trim()
                            End If
                            If Not rAufenthalt.IDUrlaub Is Nothing Then
                                rPlan("IDUrlaub") = rAufenthalt.IDUrlaub.Value
                            End If

                            Dim rKlinik As PMDS.db.Entities.Klinik = Me.b.getKlinik(PMDS.Global.ENV.IDKlinik, db)
                            rPlan("Klinik") = rKlinik.Bezeichnung.Trim()
                        End If
                    End If
                Next
            End Using

            callMainFctPlan.Title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Listenansicht")
            callMainFctPlan.ViewMode = "L"

            callMainFctPlan.IDKlinik = PMDS.Global.ENV.IDKlinik
            callMainFctPlan.IDAbteilung = PMDS.Global.ENV.CurrentIDAbteilung
            callMainFctPlan.IDBereich = PMDS.Global.ENV.CurrentIDBereich

            If Me.mainWindow.UDateVon.Value Is Nothing Then
                callMainFctPlan.dFrom = Nothing
            Else
                callMainFctPlan.dFrom = Me.mainWindow.UDateVon.DateTime.Date
            End If

            If Me.mainWindow.UDateBis.Value Is Nothing Then
                callMainFctPlan.dTo = Nothing
            Else
                callMainFctPlan.dTo = Me.mainWindow.UDateBis.DateTime.Date
            End If

            callMainFctPlan.UserLoggedOn = Me.gen.getLoggedInUser().Trim()
            Dim iCounter As Integer = 0
            'callMainFctPlan.lstKlients = Me.mainWindow.contSelectPatienten.getObjectInfo(True, False, iCounter)
            callMainFctPlan.Quickbutton = Me.mainWindow._lastQuickbutton.Trim()

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            callMainFctPlan.lstCategories = IDCategory

            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.PrintTermine, callMainFctPlan)

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.print: " + ex.ToString())
        End Try
    End Sub

    Private Sub UTabTable_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
        Try
            'Me.clearWebBrowserxy()
            Me.FilterToolStripMenuItem.Visible = True
            Me.setUIContextSelectAlleKeine(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub setUIContextSelectAlleKeine(ByVal bOn As Boolean)
        Try
            Me.AllesAuswählenToolStripMenuItem.Visible = bOn
            Me.KeineAuswahälenToolStripMenuItem.Visible = bOn
            Me.ToolStripMenuItemSpace4.Visible = bOn

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.setUIContextSelectAlleKeine: " + ex.ToString())
        End Try
    End Sub

    Public Sub showPrieviewTXTControl(ByVal text As String)
        Try
            Application.DoEvents()
            Dim typ As New TXTextControl.StringStreamType
            typ = TXTextControl.StringStreamType.PlainText
            Me.LoadTxtControl(TXTextControl.StringStreamType.PlainText, False, text)

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.showPrieviewTXTControl: " + ex.ToString())
        End Try
    End Sub
    Public Shared Sub ClearHTMLBrowser(ByRef winFormHtmlEditor As SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor)
        Try
            winFormHtmlEditor.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.HTML_Edit

            winFormHtmlEditor.Content.ClearContent()
            winFormHtmlEditor.DocumentHtml = ""
            winFormHtmlEditor.BodyHtml = ""
            winFormHtmlEditor.DocumentTitle = ""
            Application.DoEvents()
            winFormHtmlEditor.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
            Application.DoEvents()
            Dim gen As New General()
            gen.GarbColl()
            Application.DoEvents()

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.ClearHTMLBrowser: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadTxtControl(DefaultLoadTypes As TXTextControl.StringStreamType, all As Boolean, txt As String)
        Try
            Me.contTxtEditor1.textControl1.Text = ""

            If Not Me.isFirstShow Then
                Me.contTxtEditor1.textControl1.Text = ""
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.LoadTxtControl: " + ex.ToString())
        End Try
    End Sub


    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ui As New buildUI()
            ui.setFilterGridKomplex(Me.gridPlans, Me.FilterToolStripMenuItem.Checked, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub groupGrid(ByVal bOn As Boolean)
        Try
            If bOn Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            Else
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub AllesAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllesAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.selectAllNoneGrid(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub KeineAuswahälenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswahälenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.selectAllNoneGrid(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub contPlanung_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            Me.resizeControl()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub resizeControl()
        Try

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.resizeControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub contPlanungData_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Dim newRessourcesAdded As Integer = 0
                'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
                'Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)
                Me.IsInitializedVisible = True
                Me.isFirstShow = False
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub ultraDay_BeforeAppointmentsMoved(sender As Object, e As CancelableAppointmentsEventArgs)
        e.Cancel = True
    End Sub

    Private Sub TermineStornierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineStornierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub TermineErledigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineErledigenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub LöschenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.doAction(eTypAction.delete, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
