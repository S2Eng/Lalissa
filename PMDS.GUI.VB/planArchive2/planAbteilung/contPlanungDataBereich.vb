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
        AbtBereichPlan = 0
        KatAbtBereichPlan = 1
        Plan = 2
    End Enum

    Public mainWindow As contPlanung2Bereich
    Public isLoaded As Boolean = False
    Public IsInitializedVisible As Boolean = False

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()

    Public Class cSelEntries
        Public rowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow
        Public rPlanBereichSel As dsPlanSearch.planBereichRow
        Public gridIsActive As Boolean = False
    End Class

    Private uiElem As New UI()
    Public ui1 As New UI()
    Public styleDropDown As Infragistics.Win.UltraWinGrid.ColumnStyle = UltraWinGrid.ColumnStyle.DropDown

    Public Enum eTypAction
        delete = 0
        Erledigen = 102
        Stornieren = 103
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

    'Public contTxtEditor11 As QS2.Desktop.Txteditor.contTxtEditor = Nothing

    Public b As New PMDS.db.PMDSBusiness()

    Public lNachrichtenBereichOpend As New System.Collections.Generic.List(Of Form)

    Public colAbteilung As String = "Abteilung"
    Public colBereich As String = "Bereich"
    Public suchePlan1 As New suchePlan()








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
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents PanelEditorToWork As System.Windows.Forms.Panel
    Friend WithEvents TextControlToWork As TXTextControl.TextControl
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents TermineErledigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DsManage1 As QS2.Desktop.Txteditor.dsManage
    Friend WithEvents txtBody As UltraWinEditors.UltraTextEditor
    Friend WithEvents CompPlanSearch As compPlan
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
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPlanMain")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBereich")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung", 0)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bereich", 1)
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
        Me.txtBody = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.uPrintDocument1 = New Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.DsManage1 = New QS2.Desktop.Txteditor.dsManage()
        Me.CompPlanSearch = New PMDS.GUI.VB.compPlan(Me.components)
        Me.ContextMenuStripNeu.SuspendLayout()
        Me.PanelAnzeige.SuspendLayout()
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.txtBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsManage1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        UltraGridColumn1.Header.VisiblePosition = 12
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 7
        UltraGridColumn2.Width = 296
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.Caption = "Beginnt am"
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn3.Width = 125
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 8
        UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn4.Width = 119
        UltraGridColumn5.Header.Caption = "Abteilung"
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 113
        UltraGridColumn6.Header.Caption = "Bereich"
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 121
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Width = 100
        UltraGridColumn8.Header.Caption = "Kategorie"
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Width = 305
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 17
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 248
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 10
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.Editor = Nothing
        UltraGridColumn28.Header.VisiblePosition = 21
        UltraGridColumn28.Hidden = True
        UltraGridColumn37.Header.Editor = Nothing
        UltraGridColumn37.Header.VisiblePosition = 22
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.Editor = Nothing
        UltraGridColumn38.Header.VisiblePosition = 23
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.Editor = Nothing
        UltraGridColumn39.Header.VisiblePosition = 18
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.Header.Editor = Nothing
        UltraGridColumn40.Header.VisiblePosition = 19
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.Header.Editor = Nothing
        UltraGridColumn41.Header.VisiblePosition = 20
        UltraGridColumn41.Hidden = True
        UltraGridColumn42.Header.Editor = Nothing
        UltraGridColumn42.Header.VisiblePosition = 24
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.Editor = Nothing
        UltraGridColumn43.Header.VisiblePosition = 25
        UltraGridColumn43.Hidden = True
        UltraGridColumn44.Header.Editor = Nothing
        UltraGridColumn44.Header.VisiblePosition = 26
        UltraGridColumn44.Hidden = True
        UltraGridColumn45.Header.Editor = Nothing
        UltraGridColumn45.Header.VisiblePosition = 28
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.Editor = Nothing
        UltraGridColumn46.Header.VisiblePosition = 11
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.Caption = "Erstellt von"
        UltraGridColumn47.Header.Editor = Nothing
        UltraGridColumn47.Header.VisiblePosition = 13
        UltraGridColumn47.Width = 91
        UltraGridColumn48.Header.Caption = "Erstellt am"
        UltraGridColumn48.Header.Editor = Nothing
        UltraGridColumn48.Header.VisiblePosition = 14
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn48.Width = 111
        UltraGridColumn49.Header.Caption = "Letzte Änderung von"
        UltraGridColumn49.Header.Editor = Nothing
        UltraGridColumn49.Header.VisiblePosition = 15
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.Header.Caption = "Letzte Änderung am"
        UltraGridColumn50.Header.Editor = Nothing
        UltraGridColumn50.Header.VisiblePosition = 16
        UltraGridColumn50.Hidden = True
        UltraGridColumn50.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn51.Header.Caption = "Berufsgruppen"
        UltraGridColumn51.Header.Editor = Nothing
        UltraGridColumn51.Header.VisiblePosition = 6
        UltraGridColumn51.Width = 315
        UltraGridColumn12.Header.Editor = Nothing
        UltraGridColumn12.Header.VisiblePosition = 27
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Editor = Nothing
        UltraGridColumn13.Header.VisiblePosition = 29
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.Editor = Nothing
        UltraGridColumn14.Header.VisiblePosition = 30
        UltraGridColumn14.Hidden = True
        UltraGridColumn10.Header.Editor = Nothing
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Width = 117
        UltraGridColumn11.Header.Editor = Nothing
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Width = 121
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn27, UltraGridColumn28, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn10, UltraGridColumn11})
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtBody)
        Me.SplitContainer1.Size = New System.Drawing.Size(843, 550)
        Me.SplitContainer1.SplitterDistance = 226
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 394
        '
        'txtBody
        '
        Me.txtBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBody.Location = New System.Drawing.Point(0, 0)
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(843, 319)
        Me.txtBody.TabIndex = 1
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
        'DsManage1
        '
        Me.DsManage1.DataSetName = "dsManage"
        Me.DsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.txtBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsManage1, System.ComponentModel.ISupportInitialize).EndInit()
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

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
            Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)

            Me.LöschenToolStripMenuItem1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            'Me.gridPlans.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Always
            'Me.ui1.setMergeStyle(Me.gridPlans, False, True)

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
            'Me.ContTxtEditor1 = New QS2.Desktop.Txteditor.contTxtEditor()
            'Me.ContTxtEditor1.Dock = DockStyle.Fill
            'Me.PanelTxtEditor.Controls.Add(Me.ContTxtEditor1)

            'Me.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.onlyShow
            'Me.ContTxtEditor1.LinealeOnOff(True)
            'Me.ContTxtEditor1.SetUIReadOnOff(False)
            'Me.ContTxtEditor1.loadForm(False, Nothing, False, False)
            'Me.ContTxtEditor1.setControlTyp()
            'Me.ContTxtEditor1.buttonBar1.Visible = False
            'Me.ContTxtEditor1.FileNew(False, False)
            'Me.ContTxtEditor1.lockEingbe = True

            'AddHandler Me.ContTxtEditor1.textControl1_IsToSave, AddressOf Me.textControl1_IsToSave

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

            If LayoutGrid = eLayoutGrid.Plan Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical

                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BeginntAmColumn.ColumnName, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BetreffColumn.ColumnName, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.CategoryColumn.ColumnName, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colAbteilung, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colBereich, False, False)

            ElseIf LayoutGrid = eLayoutGrid.AbtBereichPlan Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colAbteilung, False, True)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colBereich, False, True)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BeginntAmColumn.ColumnName, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BetreffColumn.ColumnName, False, False)

            ElseIf LayoutGrid = eLayoutGrid.KatAbtBereichPlan Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.CategoryColumn.ColumnName, False, True)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colAbteilung, False, True)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.colBereich, False, True)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BeginntAmColumn.ColumnName, False, False)
                Me.gridPlans.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsPlanSearch1.planBereich.BetreffColumn.ColumnName, False, False)

            Else
                Throw New Exception("contPlanungDataBereich.setUI: LayoutGrid '" + LayoutGrid.ToString() + "' not allowed!")
            End If

            If PMDS.Global.ENV.adminSecure Then
            End If

            Me.gridPlans.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
            Me.gridPlans.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.Beige

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.setUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub setGridColText()
        Try
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.BeginntAmColumn.ColumnName).Header.Caption = "Beginnt am"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.CategoryColumn.ColumnName).Header.Caption = "Kategorie"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.colAbteilung).Header.Caption = "Abteilung"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.colBereich).Header.Caption = "Bereich"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.lstBerufsgruppenColumn.ColumnName).Header.Caption = "Berufsgruppen"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.BetreffColumn.ColumnName).Header.Caption = "Betreff"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.EndetAmColumn.ColumnName).Header.Caption = "Endet am"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.StatusColumn.ColumnName).Header.Caption = "Status"
            Me.gridPlans.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.planBereich.CreatedFromColumn.ColumnName).Header.Caption = "Erstellt von"

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.setGridColText: " + ex.ToString())
        End Try
    End Sub

    Public Function search(doInit As Boolean, userClicked As Boolean, ByRef SetUIGrid As Boolean) As Boolean
        Try
            Me.mainWindow.lblFound.Text = ""
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim tDesign As Integer = 0
                If userClicked Then
                    'If lstPatients.Count = 0 Then
                    'doUI.doMessageBox2("NoPatientsSelected", "", "!")
                    'Return False
                End If

                Me.clear()

                Dim sqlStatus As String = ""
                Select Case Me.mainWindow.getStatus()
                    Case "Erledigt"
                        sqlStatus = " [planBereich].Status='Erledigt' "
                    Case "Storniert"
                        sqlStatus = " [planBereich].Status='Storniert' "
                    Case "Offen"
                        sqlStatus = " ([planBereich].Status<>'Erledigt' AND [planBereich].Status<>'Storniert') "
                End Select

                Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
                Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)

                Dim lstSelectedAbt As New System.Collections.Generic.List(Of Guid)()
                Me.mainWindow.contSelectAbtBereiche.getSelectedIDs(lstSelectedAbt, True)

                Dim lstSelectedBereiche As New System.Collections.Generic.List(Of Guid)()
                Me.mainWindow.contSelectAbtBereiche.getSelectedIDs(lstSelectedBereiche, False)

                Dim lstSelectedBerufsgruppen As New System.Collections.Generic.List(Of String)()
                Me.mainWindow.contSelectSelListBerufsgruppen.getSelectedData2(lstSelectedBerufsgruppen)

                Dim lAllBerufsstandGruppe As New System.Collections.Generic.List(Of String)()
                lAllBerufsstandGruppe = clPlan1.getAllUsersFromBerufsgruppe(db)

                Me.SqlCommandReturn = ""
                Me.suchePlan1.searchPlanBereich(Me.DsPlanSearch1, Me.CompPlanSearch, sqlStatus,
                                Me.mainWindow.UDateVon.Value, Me.mainWindow.UDateBis.Value,
                                Me.mainWindow.txtBetreff2.Text.Trim(), SqlCommandReturn,
                                lstSelectedCategories, lstSelectedAbt, lstSelectedBereiche, lstSelectedBerufsgruppen, lAllBerufsstandGruppe,
                                Me._LayoutGrid, PMDS.Global.ENV.IDKlinik)
            End Using

            gridPlans.Refresh()
            Me.setGridColText()
            Me.mainWindow.setAzahl_buttSuchen(Me.DsPlanSearch1.plan.Rows.Count)
            Me.gridPlans.Selected.Rows.Clear()
            Me.gridPlans.ActiveRow = Nothing

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False

                Dim rUsrLoggedIn = (From o In db.Benutzer
                                    Where o.ID = PMDS.Global.ENV.USERID
                                    Select o.ID, o.Benutzer1, o.IDBerufsstand).ToList().First()

                Dim rSelListBerufsstandLoggedIn = (From o In db.AuswahlListe
                                                   Where o.ID = rUsrLoggedIn.IDBerufsstand And o.IstGruppe = False And o.IDAuswahlListeGruppe = "BER"
                                                   Select o.ID, o.Bezeichnung, o.GehörtzuGruppe, o.Hierarche).ToList().First()

                Dim lPlanBereichDelete As New System.Collections.Generic.List(Of dsPlanSearch.planBereichRow)()
                For Each rGrid In Me.gridPlans.Rows
                    If Not rGrid.IsFilterRow Then
                        If rGrid.IsGroupByRow Then
                            Me.showGrid_rek(rGrid, lPlanBereichDelete, rSelListBerufsstandLoggedIn.Hierarche, db)
                        Else
                            Me.showGridRow(rGrid, lPlanBereichDelete, rSelListBerufsstandLoggedIn.Hierarche, db)
                        End If

                        For Each rPlanBereichDelete As dsPlanSearch.planBereichRow In lPlanBereichDelete
                            rPlanBereichDelete.Delete()
                        Next
                    End If
                Next
            End Using

            Me.gridPlans.Refresh()
            Me.gridPlans.Rows.ExpandAll(True)
            Me.setUIAnzahl(Me.gridPlans.Rows.Count)

            If SetUIGrid Then
                Me.setUI(Me._LayoutGrid)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.search3: " + ex.ToString())
        End Try
    End Function
    Public Function showGrid_rek(rGridParent As UltraGridRow, ByRef lPlanBereichDelete As System.Collections.Generic.List(Of dsPlanSearch.planBereichRow),
                                    ByRef SelListBerufsstandLoggedInHierarche As Integer,
                                    db As PMDS.db.Entities.ERModellPMDSEntities) As Boolean
        Try
            For Each childBand As UltraGridChildBand In rGridParent.ChildBands
                For Each rGrid As UltraGridRow In childBand.Rows
                    If rGrid.IsGroupByRow Then
                        Me.showGrid_rek(rGrid, lPlanBereichDelete, SelListBerufsstandLoggedInHierarche, db)
                    Else
                        Me.showGridRow(rGrid, lPlanBereichDelete, SelListBerufsstandLoggedInHierarche, db)
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.search3: " + ex.ToString())
        End Try
    End Function
    Public Function showGridRow(rGrid As UltraGridRow, ByRef lPlanBereichDelete As System.Collections.Generic.List(Of dsPlanSearch.planBereichRow),
                                 SelListBerufsstandLoggedInHierarche As Integer,
                                 ByRef db As PMDS.db.Entities.ERModellPMDSEntities) As Boolean
        Try
            Dim v As DataRowView = rGrid.ListObject
            Dim rPlanSel As dsPlanSearch.planBereichRow = v.Row

            Dim rUsrPlanCreated = (From o In db.Benutzer
                                   Where o.Benutzer1 = rPlanSel.CreatedFrom
                                   Select o.ID, o.Benutzer1, o.IDBerufsstand).ToList().First()

            Dim rSelListBerufsstandUsrCreated = (From o In db.AuswahlListe
                                                 Where o.ID = rUsrPlanCreated.IDBerufsstand And o.IstGruppe = False And o.IDAuswahlListeGruppe = "BER"
                                                 Select o.ID, o.Bezeichnung, o.GehörtzuGruppe, o.Hierarche).ToList().First()

            If rSelListBerufsstandUsrCreated.Hierarche < SelListBerufsstandLoggedInHierarche Then
                lPlanBereichDelete.Add(rPlanSel)
            End If

            If Not rPlanSel.IsIDAbteilungNull() Then
                Dim rAbteilung = (From o In db.Abteilung
                                  Where o.ID = rPlanSel.IDAbteilung
                                  Select o.ID, o.Bezeichnung).ToList().First()

                rGrid.Cells(Me.colAbteilung).Value = rAbteilung.Bezeichnung.Trim()
            End If

            If Not rPlanSel.IsIDBereichNull() Then
                Dim rBereich = (From o In db.Bereich
                                Where o.ID = rPlanSel.IDBereich
                                Select o.ID, o.Bezeichnung).ToList().First()

                rGrid.Cells(Me.colBereich).Value = rBereich.Bezeichnung.Trim()
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.showGridRow: " + ex.ToString())
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
            'Me.EditorTmp1.Text = ""
            Me.txtBody.Text = ""

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.clear: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedPlanungseinträge() As System.Collections.Generic.List(Of cSelEntries)
        Try
            Dim ret As New System.Collections.Generic.List(Of cSelEntries)
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
            For Each r As UltraGridRow In PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridPlans, False, True)
                If PMDS.Global.generic.IsInExpandedGroup(r) Then
                    r.Selected = bOn
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.selectAllNoneGrid: " + ex.ToString())
        End Try
    End Sub

    Private Sub pläneÖffnen(ByVal withMsgBox As Boolean)
        Try
            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseinträge()
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
            For Each frmPlan As frmNachrichtBereich In lNachrichtenBereichOpend
                If Not frmPlan.IsOpend Then
                    frmPlan.IDPlanBereich = IDPlanBereich
                    frmPlan.IsNew = False
                    frmPlan.PanelBottom.Visible = Me.mainWindow.hasRightToEdit
                    frmPlan.Visible = True
                    frmPlan.Show()
                    Exit Sub
                End If
            Next

            Dim frmNachrichtBereich1 As New frmNachrichtBereich()
            frmNachrichtBereich1.modalWindow = Me.mainWindow
            frmNachrichtBereich1.initControl()
            frmNachrichtBereich1.IDPlanBereich = IDPlanBereich
            frmNachrichtBereich1.IsNew = False
            frmNachrichtBereich1.PanelBottom.Visible = Me.mainWindow.hasRightToEdit
            frmNachrichtBereich1.Visible = True
            frmNachrichtBereich1.Show()

            Me.lNachrichtenBereichOpend.Add(frmNachrichtBereich1)

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

                    Me.txtBody.Text = ""
                    'Me.doEditor1.showText("", TXTextControl.StreamType.PlainText, False, TXTextControl.ViewMode.PageView, Me.EditorTmp1)

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

    Private Function doAction(ByVal typAction As eTypAction, ByVal withMsgBox As Boolean) As Boolean
        Try
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsrLoggedIn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)

                Dim protokollTitle As String = ""
                Dim protokollTxt As String = ""
                Dim msgBoxStr As String = ""
                Dim anzErr As Integer = 0
                Dim protokollSaveTxt As String = ""

                Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseinträge()

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
                        If Not cSelAppActuell.rPlanBereichSel.IsIDSerienterminNull() Then
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
                            Dim bDoDelete As Boolean = True
                            'Dim tUser As IQueryable(Of PMDS.db.Entities.Benutzer) = b.getUserByUserName2(cSelAppActuell.rPlanBereichSel.CreatedFrom.Trim(), db)
                            'If tUser.Count = 1 Then
                            '    Dim rUsr As PMDS.db.Entities.Benutzer = tUser.First
                            '    If ((Not rUsr.IDBerufsstand Is Nothing) AndAlso Me.b.UserCanSign(rUsr.IDBerufsstand.Value)) Or PMDS.Global.ENV.adminSecure Then
                            '        bDoDelete = True
                            '    End If
                            'Else
                            '    bDoDelete = True
                            'End If
                            If bDoDelete Then
                                Dim IDPlan As System.Guid = cSelAppActuell.rPlanBereichSel.ID
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} wurde gelöscht!")
                                sMsgBoxTxt = String.Format(sMsgBoxTxt, cSelAppActuell.rPlanBereichSel.Betreff.Trim() + " (" + cSelAppActuell.rPlanBereichSel.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss") + ")")
                                protokollSaveTxt += sMsgBoxTxt.Trim() + vbNewLine

                                If resSerientermineSeleteAll = DialogResult.Yes Then
                                    If Not cSelAppActuell.rPlanBereichSel.IsIDSerienterminNull() Then
                                        Me.CompPlanSearch.deletePlanSerientermine(cSelAppActuell.rPlanBereichSel.IDSerientermin)
                                    End If
                                End If
                                Me.CompPlanSearch.deletePlanBereich(cSelAppActuell.rPlanBereichSel.ID)
                                cSelAppActuell.rPlanBereichSel.Delete()
                            Else
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} kann nicht gelöscht werden!")
                                sMsgBoxTxt = String.Format(sMsgBoxTxt, cSelAppActuell.rPlanBereichSel.Betreff.Trim() + " (" + cSelAppActuell.rPlanBereichSel.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss") + ")")
                                protokollTxt += sMsgBoxTxt.Trim() + vbNewLine
                            End If

                        ElseIf typAction = eTypAction.Stornieren Then
                            compPlanWork.updatePlanBereichStatus(cSelAppActuell.rPlanBereichSel.ID, "Storniert")
                        ElseIf typAction = eTypAction.Erledigen Then
                            compPlanWork.updatePlanBereichStatus(cSelAppActuell.rPlanBereichSel.ID, "Erledigt")
                        End If
                    Next

                    If typAction = eTypAction.delete Then
                        Me.search(False, True, False)
                        'Me.gridPlans.Refresh()
                        If withMsgBox Then
                            Dim strText As String = doUI.getRes("ActivityPerformed2")
                            strText = String.Format(strText, selectedApp.Count.ToString())
                            doUI.doMessageBoxTranslated(strText, "", "!")
                        End If
                        If protokollTxt.Trim() <> "" Then
                            protokollTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Termine können nicht gelöscht werden da keine Berechtigung:") + vbNewLine + vbNewLine + protokollTxt
                        End If

                    ElseIf typAction = eTypAction.Stornieren Then
                        Me.search(False, True, False)

                    ElseIf typAction = eTypAction.Erledigen Then
                        Me.search(False, True, False)

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

            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Abteilung", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Bereich", GetType(String))
            callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Klinik", GetType(String))


            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("ID", GetType(Guid))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Betreff", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("BeginntAm", GetType(DateTime))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("EndetAm", GetType(DateTime))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Status", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Category", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("IDSerientermin", GetType(Guid))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("IDKlinik", GetType(Guid))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Abteilung", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("Bereich", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("lstBerufsgruppen", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("CreatedAt", GetType(DateTime))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("CreatedFrom", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("LastChangeAt", GetType(DateTime))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("LastChangeFrom", GetType(String))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("IDAbteilung", GetType(Guid))
            'callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Columns.Add("IDBereich", GetType(Guid))

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rPlan As dsPlanSearch.planBereichRow In callMainFctPlan.ds.Tables(Me.DsPlanSearch1.planBereich.TableName.Trim()).Rows
                    Dim rKlinik As PMDS.db.Entities.Klinik = Me.b.getKlinik(rPlan.IDKlinik, db)
                    rPlan("Klinik") = rKlinik.Bezeichnung.Trim()
                Next
            End Using

            callMainFctPlan.Title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Listenansicht")
            callMainFctPlan.ViewMode = "L"

            callMainFctPlan.IDKlinik = PMDS.Global.ENV.IDKlinik

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
            callMainFctPlan.Quickbutton = Me.mainWindow._lastQuickbutton.Trim()

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            callMainFctPlan.lstCategories = IDCategory

            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.PrintTermineBereich, callMainFctPlan)

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.print: " + ex.ToString())
        End Try
    End Sub

    Public Sub showPrieviewTXTControl(ByVal text As String)
        Try
            Me.txtBody.Text = ""
            'Me.EditorTmp1.Text = ""

        Catch ex As Exception
            Throw New Exception("contPlanungDataBereich.showPrieviewTXTControl: " + ex.ToString())
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

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub contPlanungData_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Me.IsInitializedVisible = True
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub TermineStornierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineStornierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.doAction(eTypAction.Stornieren, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub TermineErledigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineErledigenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.doAction(eTypAction.Erledigen, True)

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
