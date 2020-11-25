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

    Public _IDArt As Integer = 3
    Public _TypeUI As eTypeUI
    Public _LayoutGrid As eLayoutGrid


    Public Enum eTypeUI
        PlanKlienten = 0
        PlanMy = 1
        PlansAll = 2
        IDKlient = 3
    End Enum
    Public _PlanArchive As New cPlanArchive()
    Public Class cPlanArchive
        Public IDKlinik_Patienten As Guid = Nothing
        Public IDAbteilung_Patienten As Guid = Nothing
        Public IDBereich_Patienten As Guid = Nothing

        Public IDKlinik_Benutzer As Guid = Nothing
        Public IDAbteilung_Benutzer As Guid = Nothing
        Public IDBereich_Benutzer As Guid = Nothing
    End Class
    Public Enum eLayoutGrid
        PatientsBeginn = 0
        PatientsKategorie = 1
        KategoriePatient = 2
        'Beginn = 3
    End Enum


    Public mainWindow As contPlanung2Bereich
    Public compPlan1 As New compPlan()
    Public isLoaded As Boolean = False

    Public maxSuche As Integer = 5000
    Public IsInitializedVisible As Boolean = False

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()

    Public Class cSelEntries
        Public appoint As Appointment
        Public rowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow
        Public rPlanSel As dsPlanSearch.planRow
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

        DekursErstellen = 16
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

    Public Enum eTypeDekursErstellen
        DekursErstellen = 0
        DekursEntwurfErstellen = 1
        DekursEntwurfErstellenAls = 2
        ErledigtSetzenUndDekursErstellen = 3
        ErledigtSetzen = 4
        StorniertSetzen = 5
    End Enum








    Friend WithEvents PanelAnzeige As System.Windows.Forms.Panel
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents gridPlans As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStripNeu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemSpace As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uPrintDocument1 As Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents DsPlanSearch1 As dsPlanSearch
    Friend WithEvents L�schenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllesAusw�hlenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswah�lenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSpace4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents PanelEditorToWork As System.Windows.Forms.Panel
    Friend WithEvents TextControlToWork As TXTextControl.TextControl
    Friend WithEvents OpenSqlCommandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents PanelTxtEditor As Panel
    Friend WithEvents TermineErledigenUndDekursSchreibenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TermineErledigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ListeLeerenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TermineStornierenToolStripMenuItem As ToolStripMenuItem


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf�gen

    End Sub

    'UserControl �berschreibt den L�schvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F�r Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("plan", -1)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Betreff")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BeginntAm")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("F�lligAm")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDArt", -1, 273914762)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Priorit�t")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Text")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Zusatz")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailAn")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailCC")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("html")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("F�r")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("gesendetAm")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembJN")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("remembMinut")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("wichtig")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Teilnehmer")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDActivity")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStatus")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTyp")
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KommStatus")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("db")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("deleted")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzObjects")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("design")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailBcc")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUserAccount")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MailFrom")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("readed")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("empfangenAm", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MessageId")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzAnh�nge", -1, 368799640)
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPlanMain")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReplyTxt")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsOwner")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AwaitingResponse")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDFolder", -1, 64791755)
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SendWithPostOfficeBoxForAll")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OutlookAPI")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConversationID")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDoutlook")
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDoutlookTicks")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Category")
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Folder")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastChangeITSCont")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LastSyncToExchange")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Wochentage")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nTenMonat")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminType")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSerientermin")
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TagWochenMonat")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("WiedWertJeden")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EndetAm")
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer")
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GanzerTag")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsSerientermin")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SerienterminEndetAm")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatientName")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("WithPatients")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DauerStr")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObjectStatus")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(273914762)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(368799640)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(64791755)
        Dim ValueList4 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(82828532)
        Dim DictionaryFileInfo1 As SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo = New SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo()
        Me.gridPlans = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStripNeu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TermineErledigenUndDekursSchreibenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermineErledigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermineStornierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.L�schenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllesAusw�hlenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswah�lenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpace4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSqlCommandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListeLeerenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsPlanSearch1 = New PMDS.GUI.VB.dsPlanSearch()
        Me.ToolStripMenuItemSpace = New System.Windows.Forms.ToolStripSeparator()
        Me.PanelAnzeige = New System.Windows.Forms.Panel()
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
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripNeu.SuspendLayout()
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAnzeige.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridPlans
        '
        Me.gridPlans.ContextMenuStrip = Me.ContextMenuStripNeu
        Me.gridPlans.DataMember = "plan"
        Me.gridPlans.DataSource = Me.DsPlanSearch1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Appearance = Appearance1
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn24.Header.Editor = Nothing
        UltraGridColumn24.Header.VisiblePosition = 10
        UltraGridColumn24.Width = 412
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.Header.Caption = "Beginnt am"
        UltraGridColumn25.Header.Editor = Nothing
        UltraGridColumn25.Header.VisiblePosition = 3
        UltraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn25.Width = 111
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.Header.Caption = "F�llig am"
        UltraGridColumn26.Header.Editor = Nothing
        UltraGridColumn26.Header.VisiblePosition = 4
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown
        UltraGridColumn26.Width = 111
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.Header.Caption = "Art"
        UltraGridColumn27.Header.Editor = Nothing
        UltraGridColumn27.Header.VisiblePosition = 28
        UltraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn27.Width = 154
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn28.Header.Editor = Nothing
        UltraGridColumn28.Header.VisiblePosition = 32
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn29.Header.Editor = Nothing
        UltraGridColumn29.Header.VisiblePosition = 13
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn30.Header.Editor = Nothing
        UltraGridColumn30.Header.VisiblePosition = 14
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn31.Header.Editor = Nothing
        UltraGridColumn31.Header.VisiblePosition = 15
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance2.TextHAlignAsString = "Left"
        UltraGridColumn32.CellAppearance = Appearance2
        Appearance3.TextHAlignAsString = "Left"
        UltraGridColumn32.Header.Appearance = Appearance3
        UltraGridColumn32.Header.Caption = "An (E-Mail Adresse)"
        UltraGridColumn32.Header.Editor = Nothing
        UltraGridColumn32.Header.VisiblePosition = 8
        UltraGridColumn32.Width = 187
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn33.Header.Editor = Nothing
        UltraGridColumn33.Header.VisiblePosition = 16
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn34.Header.Editor = Nothing
        UltraGridColumn34.Header.VisiblePosition = 17
        UltraGridColumn34.Hidden = True
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn36.Header.Caption = "An Sachb."
        UltraGridColumn36.Header.Editor = Nothing
        UltraGridColumn36.Header.VisiblePosition = 11
        UltraGridColumn36.Width = 140
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn37.Format = ""
        UltraGridColumn37.Header.Caption = "Gesendet am"
        UltraGridColumn37.Header.Editor = Nothing
        UltraGridColumn37.Header.VisiblePosition = 6
        UltraGridColumn37.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown
        UltraGridColumn37.Width = 107
        UltraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn38.Header.Editor = Nothing
        UltraGridColumn38.Header.VisiblePosition = 18
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn39.Header.Editor = Nothing
        UltraGridColumn39.Header.VisiblePosition = 19
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn40.Header.Caption = "Wichtig"
        UltraGridColumn40.Header.Editor = Nothing
        UltraGridColumn40.Header.VisiblePosition = 20
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn41.Header.Editor = Nothing
        UltraGridColumn41.Header.VisiblePosition = 21
        UltraGridColumn41.Hidden = True
        UltraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn81.Header.Caption = "Erstellt Von"
        UltraGridColumn81.Header.Editor = Nothing
        UltraGridColumn81.Header.VisiblePosition = 33
        UltraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn82.Format = ""
        UltraGridColumn82.Header.Caption = "Erstellt am"
        UltraGridColumn82.Header.Editor = Nothing
        UltraGridColumn82.Header.VisiblePosition = 9
        UltraGridColumn82.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown
        UltraGridColumn82.Width = 110
        UltraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn83.Header.Editor = Nothing
        UltraGridColumn83.Header.VisiblePosition = 22
        UltraGridColumn83.Hidden = True
        UltraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn84.Header.Editor = Nothing
        UltraGridColumn84.Header.VisiblePosition = 23
        UltraGridColumn84.Hidden = True
        UltraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn85.Header.Caption = "Fortschritt"
        UltraGridColumn85.Header.Editor = Nothing
        UltraGridColumn85.Header.VisiblePosition = 24
        UltraGridColumn85.Width = 148
        UltraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn86.Header.Caption = "Typ"
        UltraGridColumn86.Header.Editor = Nothing
        UltraGridColumn86.Header.VisiblePosition = 25
        UltraGridColumn86.Hidden = True
        UltraGridColumn86.Width = 148
        UltraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn87.Header.Caption = "Kom.Status"
        UltraGridColumn87.Header.Editor = Nothing
        UltraGridColumn87.Header.VisiblePosition = 26
        UltraGridColumn87.Width = 141
        UltraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn88.Header.Editor = Nothing
        UltraGridColumn88.Header.VisiblePosition = 34
        UltraGridColumn88.Hidden = True
        UltraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn89.Header.Editor = Nothing
        UltraGridColumn89.Header.VisiblePosition = 35
        UltraGridColumn89.Hidden = True
        UltraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn90.Header.Caption = "Anz. Beziehungen"
        UltraGridColumn90.Header.Editor = Nothing
        UltraGridColumn90.Header.VisiblePosition = 27
        UltraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn91.Header.Editor = Nothing
        UltraGridColumn91.Header.VisiblePosition = 36
        UltraGridColumn91.Hidden = True
        UltraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn92.Header.Caption = "Mail Bcc"
        UltraGridColumn92.Header.Editor = Nothing
        UltraGridColumn92.Header.VisiblePosition = 12
        UltraGridColumn92.Hidden = True
        UltraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn93.Header.Editor = Nothing
        UltraGridColumn93.Header.VisiblePosition = 37
        UltraGridColumn93.Hidden = True
        UltraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn94.Header.Caption = "E-Mail von"
        UltraGridColumn94.Header.Editor = Nothing
        UltraGridColumn94.Header.VisiblePosition = 7
        UltraGridColumn94.Width = 205
        UltraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn95.Header.Caption = "Gelesen"
        UltraGridColumn95.Header.Editor = Nothing
        UltraGridColumn95.Header.VisiblePosition = 0
        UltraGridColumn95.Width = 51
        UltraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn96.Format = "dd.MM.yyyy HH:mm:ss"
        UltraGridColumn96.Header.Caption = "Empfangen Am"
        UltraGridColumn96.Header.Editor = Nothing
        UltraGridColumn96.Header.VisiblePosition = 5
        UltraGridColumn96.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown
        UltraGridColumn96.Width = 154
        UltraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn97.Header.Editor = Nothing
        UltraGridColumn97.Header.VisiblePosition = 38
        UltraGridColumn97.Hidden = True
        UltraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn98.Header.Caption = ""
        UltraGridColumn98.Header.Editor = Nothing
        UltraGridColumn98.Header.VisiblePosition = 1
        UltraGridColumn98.Width = 20
        UltraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn99.Header.Editor = Nothing
        UltraGridColumn99.Header.VisiblePosition = 39
        UltraGridColumn99.Hidden = True
        UltraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn100.Header.Editor = Nothing
        UltraGridColumn100.Header.VisiblePosition = 40
        UltraGridColumn100.Hidden = True
        UltraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn101.Header.Caption = "Besitzer"
        UltraGridColumn101.Header.Editor = Nothing
        UltraGridColumn101.Header.VisiblePosition = 2
        UltraGridColumn101.Width = 56
        UltraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn102.Header.Editor = Nothing
        UltraGridColumn102.Header.VisiblePosition = 41
        UltraGridColumn102.Hidden = True
        UltraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn103.Header.Editor = Nothing
        UltraGridColumn103.Header.VisiblePosition = 31
        UltraGridColumn103.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn103.Width = 296
        UltraGridColumn104.Header.Editor = Nothing
        UltraGridColumn104.Header.VisiblePosition = 42
        UltraGridColumn105.Header.Editor = Nothing
        UltraGridColumn105.Header.VisiblePosition = 43
        UltraGridColumn106.Header.Editor = Nothing
        UltraGridColumn106.Header.VisiblePosition = 44
        UltraGridColumn107.Header.Editor = Nothing
        UltraGridColumn107.Header.VisiblePosition = 45
        UltraGridColumn108.Header.Editor = Nothing
        UltraGridColumn108.Header.VisiblePosition = 46
        UltraGridColumn109.Header.Editor = Nothing
        UltraGridColumn109.Header.VisiblePosition = 30
        UltraGridColumn109.Width = 162
        UltraGridColumn110.Header.Editor = Nothing
        UltraGridColumn110.Header.VisiblePosition = 29
        UltraGridColumn110.Width = 248
        UltraGridColumn111.Header.Editor = Nothing
        UltraGridColumn111.Header.VisiblePosition = 47
        UltraGridColumn112.Header.Editor = Nothing
        UltraGridColumn112.Header.VisiblePosition = 48
        UltraGridColumn113.Header.Editor = Nothing
        UltraGridColumn113.Header.VisiblePosition = 49
        UltraGridColumn114.Header.Editor = Nothing
        UltraGridColumn114.Header.VisiblePosition = 50
        UltraGridColumn115.Header.Editor = Nothing
        UltraGridColumn115.Header.VisiblePosition = 51
        UltraGridColumn116.Header.Editor = Nothing
        UltraGridColumn116.Header.VisiblePosition = 52
        UltraGridColumn117.Header.Editor = Nothing
        UltraGridColumn117.Header.VisiblePosition = 53
        UltraGridColumn118.Header.Editor = Nothing
        UltraGridColumn118.Header.VisiblePosition = 54
        UltraGridColumn119.Header.Editor = Nothing
        UltraGridColumn119.Header.VisiblePosition = 55
        UltraGridColumn120.Header.Editor = Nothing
        UltraGridColumn120.Header.VisiblePosition = 56
        UltraGridColumn121.Header.Editor = Nothing
        UltraGridColumn121.Header.VisiblePosition = 57
        UltraGridColumn122.Header.Editor = Nothing
        UltraGridColumn122.Header.VisiblePosition = 58
        UltraGridColumn123.Header.Editor = Nothing
        UltraGridColumn123.Header.VisiblePosition = 59
        UltraGridColumn124.Header.Editor = Nothing
        UltraGridColumn124.Header.VisiblePosition = 60
        UltraGridColumn125.Header.Editor = Nothing
        UltraGridColumn125.Header.VisiblePosition = 61
        UltraGridColumn126.Header.Editor = Nothing
        UltraGridColumn126.Header.VisiblePosition = 62
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 63
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 64
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn1, UltraGridColumn2})
        Me.gridPlans.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Appearance4.BackColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.GroupByBox.Appearance = Appearance4
        Me.gridPlans.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren m�chten."
        Appearance5.BackColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.gridPlans.DisplayLayout.MaxColScrollRegions = 1
        Me.gridPlans.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.Color.DarkGray
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.AddRowAppearance = Appearance6
        Me.gridPlans.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridPlans.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.RowAlternateAppearance = Appearance7
        Me.gridPlans.DisplayLayout.Override.RowSpacingAfter = 1
        Me.gridPlans.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance8.BackColor = System.Drawing.Color.DarkGray
        Appearance8.ForeColor = System.Drawing.Color.White
        Me.gridPlans.DisplayLayout.Override.SelectedRowAppearance = Appearance8
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
        'ContextMenuStripNeu
        '
        Me.ContextMenuStripNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ContextMenuStripNeu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TermineErledigenUndDekursSchreibenToolStripMenuItem, Me.TermineErledigenToolStripMenuItem, Me.TermineStornierenToolStripMenuItem, Me.ToolStripMenuItem3, Me.L�schenToolStripMenuItem1, Me.ToolStripMenuItemSpace1, Me.AllesAusw�hlenToolStripMenuItem, Me.KeineAuswah�lenToolStripMenuItem, Me.ToolStripMenuItemSpace4, Me.FilterToolStripMenuItem, Me.OpenSqlCommandToolStripMenuItem, Me.ToolStripMenuItem1, Me.ListeLeerenToolStripMenuItem})
        Me.ContextMenuStripNeu.Name = "ContextMenuStripNeu"
        Me.ContextMenuStripNeu.Size = New System.Drawing.Size(292, 226)
        '
        'TermineErledigenUndDekursSchreibenToolStripMenuItem
        '
        Me.TermineErledigenUndDekursSchreibenToolStripMenuItem.Name = "TermineErledigenUndDekursSchreibenToolStripMenuItem"
        Me.TermineErledigenUndDekursSchreibenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.TermineErledigenUndDekursSchreibenToolStripMenuItem.Tag = "ResID.TermineErledigenUndDekursErstellen"
        Me.TermineErledigenUndDekursSchreibenToolStripMenuItem.Text = "Termine erledigen und Dekurs erstellen"
        '
        'TermineErledigenToolStripMenuItem
        '
        Me.TermineErledigenToolStripMenuItem.Name = "TermineErledigenToolStripMenuItem"
        Me.TermineErledigenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.TermineErledigenToolStripMenuItem.Tag = "ResID.TermineErledigen"
        Me.TermineErledigenToolStripMenuItem.Text = "Termine erledigen"
        '
        'TermineStornierenToolStripMenuItem
        '
        Me.TermineStornierenToolStripMenuItem.Name = "TermineStornierenToolStripMenuItem"
        Me.TermineStornierenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.TermineStornierenToolStripMenuItem.Tag = "ResID.TermineStornieren"
        Me.TermineStornierenToolStripMenuItem.Text = "Termine stornieren"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(288, 6)
        '
        'L�schenToolStripMenuItem1
        '
        Me.L�schenToolStripMenuItem1.Name = "L�schenToolStripMenuItem1"
        Me.L�schenToolStripMenuItem1.Size = New System.Drawing.Size(291, 22)
        Me.L�schenToolStripMenuItem1.Tag = "ResID.Delete"
        Me.L�schenToolStripMenuItem1.Text = "L�schen"
        '
        'ToolStripMenuItemSpace1
        '
        Me.ToolStripMenuItemSpace1.Name = "ToolStripMenuItemSpace1"
        Me.ToolStripMenuItemSpace1.Size = New System.Drawing.Size(288, 6)
        '
        'AllesAusw�hlenToolStripMenuItem
        '
        Me.AllesAusw�hlenToolStripMenuItem.Name = "AllesAusw�hlenToolStripMenuItem"
        Me.AllesAusw�hlenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.AllesAusw�hlenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AllesAusw�hlenToolStripMenuItem.Text = "Alle ausw�hlen"
        '
        'KeineAuswah�lenToolStripMenuItem
        '
        Me.KeineAuswah�lenToolStripMenuItem.Name = "KeineAuswah�lenToolStripMenuItem"
        Me.KeineAuswah�lenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.KeineAuswah�lenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswah�lenToolStripMenuItem.Text = "Keine ausw�hlen"
        '
        'ToolStripMenuItemSpace4
        '
        Me.ToolStripMenuItemSpace4.Name = "ToolStripMenuItemSpace4"
        Me.ToolStripMenuItemSpace4.Size = New System.Drawing.Size(288, 6)
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.CheckOnClick = True
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.FilterToolStripMenuItem.Tag = "ResID.Filter"
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'OpenSqlCommandToolStripMenuItem
        '
        Me.OpenSqlCommandToolStripMenuItem.Name = "OpenSqlCommandToolStripMenuItem"
        Me.OpenSqlCommandToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.OpenSqlCommandToolStripMenuItem.Tag = "ResID.OpenSqlCommand"
        Me.OpenSqlCommandToolStripMenuItem.Text = "Open Sql-Command"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(288, 6)
        '
        'ListeLeerenToolStripMenuItem
        '
        Me.ListeLeerenToolStripMenuItem.Name = "ListeLeerenToolStripMenuItem"
        Me.ListeLeerenToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.ListeLeerenToolStripMenuItem.Text = "Liste leeren"
        '
        'DsPlanSearch1
        '
        Me.DsPlanSearch1.DataSetName = "dsPlanSearch"
        Me.DsPlanSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema

        DictionaryFileInfo1.AffixFilePath = Nothing
        DictionaryFileInfo1.DictionaryFilePath = Nothing
        DictionaryFileInfo1.EnableUserDictionary = True
        DictionaryFileInfo1.UserDictionaryFilePath = Nothing
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
        CType(Me.gridPlans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripNeu.ResumeLayout(False)
        CType(Me.DsPlanSearch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAnzeige.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub AufgabeTermin�bersicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

            'Me.L�schenToolStripMenuItem1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.ListeLeerenToolStripMenuItem.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste leeren")

            clPlan.anzNachrichten = 0

            Me.gridPlans.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Always
            Me.ContexMen�Items(False)
            Me.setUIContextSelectAlleKeine(True)

            Me.initData()

            Me.lstColSmallViewGrid.Clear()

            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.ErstelltAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.ErstelltVonColumn.ColumnName)
            'Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDStatusColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.BeginntAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.F�lligAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.IDArtColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.MailAnColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.Priorit�tColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.StatusColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.F�rColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.gesendetAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.wichtigColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.anzObjectsColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsPlanSearch1.plan.anzAnh�ngeColumn.ColumnName)
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

            If PMDS.Global.ENV.adminSecure Then
                Me.OpenSqlCommandToolStripMenuItem.Visible = True
            Else
                Me.OpenSqlCommandToolStripMenuItem.Visible = False
            End If

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contPlanungData.initControl: " + ex.ToString())
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
            Throw New Exception("contPlanungData.initTxtControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub textControl1_IsToSave()
        Try


        Catch ex As Exception
            Throw New Exception("contPlanungData.initTxtControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUI(ByRef iTyp As Integer, LayoutGrid As contPlanungData.eLayoutGrid)
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
                Throw New Exception("contPlanungData.setUI: LayoutGrid '" + LayoutGrid.ToString() + "' not allowed!")
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
            Throw New Exception("contPlanungData.setUI: " + ex.ToString())
        End Try
    End Sub

    Public Function search(ClearHTMLBrowser As Boolean, doInit As Boolean, userClicked As Boolean, ByRef SetUIGrid As Boolean) As Boolean
        Try
            Me.mainWindow.lockToolbar = False
            Me.mainWindow.lblFound.Text = ""

            Dim tDesign As Integer = 0
            Dim lstPatients As System.Collections.Generic.List(Of Guid) = Me.mainWindow.contSelectPatienten.getList()
            Dim lstUsers As System.Collections.Generic.List(Of Guid) = Me.mainWindow.contSelectBenutzer.getList()

            If userClicked Then
                If Me._TypeUI = eTypeUI.PlanKlienten Then
                    If lstPatients.Count = 0 Then
                        'doUI.doMessageBox2("NoPatientsSelected", "", "!")
                        'Return False
                    End If
                End If
            End If

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)

            Me.clear(ClearHTMLBrowser)

            Dim sqlErledigt As String = ""
            Dim sqlPriorit�t As String = ""

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
            ElseIf Me.mainWindow.getStatMail = General.eAuswahlStatusMail.entw�rfe Then
                sqlEMailGesendet = " ( [plan].gesendetAm is null) "
            End If

            Me.SqlCommandReturn = ""
            Dim suche As New suchePlan()
            'suche.searchPlan(Me.DsPlanSearch1, sqlPriorit�t, sqlErledigt, sqlEMailGesendet,
            '                Me.mainWindow.UDateVon.Value, Me.mainWindow.UDateBis.Value,
            '                Me.mainWindow.txtBetreff2.Text.Trim(), -1, Me._IDArt, SqlCommandReturn, lstSelectedCategories,
            '                lstPatients, lstUsers, doInit, Me._PlanArchive, Me._TypeUI, Me._LayoutGrid, PMDS.Global.ENV.IDKlinik)
            'lthplan

            If Me.DsPlanSearch1.plan.Count > Me.maxSuche Then
                Dim resTitleTranslated As String = doUI.getRes("AutoSwitchToTableView")
                Dim resTextTranslated As String = doUI.getRes("NoteItWillChangeToTheListView") + "!" + vbNewLine + vbNewLine + doUI.getRes("TheOtherViewsRemainEmpty")
                    resTextTranslated = String.Format(resTextTranslated, Me.maxSuche.ToString())

                    doUI.doMessageBoxTranslated(resTextTranslated, resTitleTranslated, MsgBoxStyle.Information)

                    Me.mainWindow.lockToolbar = True
                    Me.mainWindow.showListenansicht()
                    Me.mainWindow.lockToolbar = False
                    Application.DoEvents()
                End If

                If Me.DsPlanSearch1.plan.Count <= Me.maxSuche Then
                Dim lstPlansToDelete As New System.Collections.Generic.List(Of dsPlanSearch.planRow)
                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim countNotReadedEMails As Integer = 0
                    Dim dt As New DataTable()
                    For Each rPlan As dsPlanSearch.planRow In Me.DsPlanSearch1.plan
                        Dim sFormattedTimespan As String = ""
                        Dim tEndetAmBeginntAm As TimeSpan = rPlan.EndetAm - rPlan.BeginntAm
                        If tEndetAmBeginntAm.Days > 0 Then
                            sFormattedTimespan = String.Format("{0:D}T {1:D2}:{2:D2}", tEndetAmBeginntAm.Days, tEndetAmBeginntAm.Hours, tEndetAmBeginntAm.Minutes)
                            rPlan.DauerStr = sFormattedTimespan
                        Else
                            sFormattedTimespan = String.Format("{0:D2}:{1:D2}", tEndetAmBeginntAm.Hours, tEndetAmBeginntAm.Minutes)
                            rPlan.DauerStr = sFormattedTimespan
                        End If

                        Dim bPatIsAbwesend As Boolean = False
                        If Me._LayoutGrid = eLayoutGrid.PatientsBeginn Or Me._LayoutGrid = eLayoutGrid.PatientsKategorie Or Me._LayoutGrid = eLayoutGrid.KategoriePatient Then
                            If Not rPlan.IsIDPatientNull() Then
                                dt.Clear()
                                Dim PatientHasNoAktAufenthalt As Boolean = False
                                bPatIsAbwesend = Me.b.PatientIstAbwesend2(dt, rPlan.IDPatient, PatientHasNoAktAufenthalt)
                            End If
                        End If

                        If Not bPatIsAbwesend Then
                            'Dim bEMailNotReaded As Boolean = False
                            'If rPlan.IDArt = 1 Then
                            '    If Not rPlan.readed Then
                            '        Dim gridRow As UltraGridRow = Me.gridPlans.Rows.GetRowWithListIndex(Me.DsPlanSearch1.plan.Rows.IndexOf(rPlan))
                            '        gridRow.Appearance.FontData.Bold = DefaultableBoolean.True
                            '        bEMailNotReaded = True
                            '        countNotReadedEMails += 1
                            '    End If
                            'End If

                            Dim dEndetAm As Date = Nothing
                            Dim appointment As Appointment = Nothing

                            If rPlan.IDArt = clPlan.typPlan_EMailEmpfangen Then
                                Dim empfangenAmTmp As Date = Nothing
                                If Not rPlan.IsempfangenAmNull() Then
                                    empfangenAmTmp = rPlan.empfangenAm
                                Else
                                    empfangenAmTmp = Now
                                End If
                                dEndetAm = empfangenAmTmp.AddMinutes(30)
                                appointment = New Appointment(empfangenAmTmp, dEndetAm)
                                appointment.StartDateTime = empfangenAmTmp
                                appointment.Description = vbNewLine + "Start: " + empfangenAmTmp.ToString("dd.MM.yyyy HH:mm") + " " +
                                                                doUI.getRes("Subject") + ": " + rPlan.Betreff + " " +
                                                                doUI.getRes("GeneratedFrom") + ": " + rPlan.ErstelltVon

                                appointment.Appearance.FontData.Bold = DefaultableBoolean.False
                                'If bEMailNotReaded Then
                                '    appointment.Appearance.FontData.Bold = DefaultableBoolean.True
                                'Else
                                '    appointment.Appearance.FontData.Bold = DefaultableBoolean.False
                                'End If
                                appointment.Subject = rPlan.Betreff
                            Else
                                Dim dNewBeginntAm As Date
                                dNewBeginntAm = rPlan.BeginntAm
                                'If rPlan.IsBeginntAmNull() Then
                                '    dNewBeginntAm = rPlan.ErstelltAm
                                'Else
                                '    dNewBeginntAm = rPlan.BeginntAm
                                'End If
                                If Not rPlan.IsEndetAmNull() Then
                                    If rPlan.EndetAm <= rPlan.BeginntAm Then
                                        dEndetAm = dNewBeginntAm.AddMinutes(15)
                                    Else
                                        Dim datDiff As TimeSpan = rPlan.EndetAm.Subtract(dNewBeginntAm)
                                        dEndetAm = rPlan.EndetAm
                                        'If datDiff.Hours > 1 Or (datDiff.Hours = 1 And datDiff.Minutes > 0) Or datDiff.Days > 0 Then
                                        '    dEndetAm = dNewBeginntAm
                                        '    dEndetAm = dF�lligAm.AddHours(1)
                                        'Else
                                        '    dEndetAm = rPlan.F�lligAm
                                        'End If
                                    End If
                                Else
                                    dEndetAm = dNewBeginntAm.AddMinutes(30)
                                End If

                                appointment = New Appointment(dNewBeginntAm, dEndetAm)
                                appointment.StartDateTime = dNewBeginntAm

                                Dim sEndetAm As String = dEndetAm.ToString("dd.MM.yyyy HH:mm").ToString()
                                If Not rPlan.IsEndetAmNull() Then _
                                      sEndetAm = rPlan.EndetAm.ToString("dd.MM.yyyy HH:mm").ToString()
                                Dim sPatientInfo As String = ""
                                If Not rPlan.IsPatientNameNull() Then
                                    sPatientInfo = "Klient: " + rPlan.PatientName.Trim() + " "
                                End If
                                If sPatientInfo.Trim() <> "" Then
                                    sPatientInfo += vbNewLine
                                End If
                                Dim sCategory As String = rPlan.Category.Trim()
                                If sCategory.Trim() <> "" Then
                                    sCategory = "Kategorie: " + sCategory + vbNewLine
                                End If
                                appointment.Description = sPatientInfo + sCategory
                                appointment.Subject = rPlan.Betreff + "    " + sPatientInfo + sCategory

                                appointment.Appearance.BackColor = System.Drawing.Color.DarkGreen
                                appointment.Appearance.ForeColor = Color.White
                                appointment.Appearance.FontData.Bold = DefaultableBoolean.False
                                'If bEMailNotReaded Then
                                '    appointment.Appearance.FontData.Bold = DefaultableBoolean.True
                                'Else
                                '    appointment.Appearance.FontData.Bold = DefaultableBoolean.False
                                'End If
                            End If

                            If rPlan.IDArt = 1 Or rPlan.IDArt = 2 Then
                                appointment.Appearance.BackColor = System.Drawing.Color.Yellow
                                appointment.Appearance.ForeColor = Color.Black
                            End If

                            appointment.Tag = rPlan
                            appointment.Locked = True
                        Else
                            lstPlansToDelete.Add(rPlan)
                        End If
                    Next
                End Using

                For Each rPlanToDelete As dsPlanSearch.planRow In lstPlansToDelete
                    rPlanToDelete.Delete()
                Next
                Me.DsPlanSearch1.AcceptChanges()
            End If

            gridPlans.Refresh()
            clPlan.anzNachrichten = Me.DsPlanSearch1.plan.Rows.Count
            Me.mainWindow.setAzahl_buttSuchen(Me.DsPlanSearch1.plan.Rows.Count)

            Me.gridPlans.Selected.Rows.Clear()
            Me.gridPlans.ActiveRow = Nothing

            Me.ContexMen�Items(False)
            If SetUIGrid Then
                Me.setUI(Me._IDArt, Me._LayoutGrid)
            End If
            Me.gridPlans.Rows.ExpandAll(True)
            'doUI.doMessageBox2("PleaseSelectAPlanTypeInTheLeftNavigationAssistants", "Search", "!")
            Me.setUIAnzahl(Me.gridPlans.Rows.Count)
            Me.mainWindow.lockToolbar = False

            Return True

        Catch ex As Exception
            Me.mainWindow.lockToolbar = False
            Throw New Exception("contPlanungData.search3: " + ex.ToString())
        End Try
    End Function
    Public Sub setUIAnzahl(iFound As Integer)
        Try
            Me.mainWindow.lblFound.Text = doUI.getRes("Founded") + ": " + iFound.ToString()

        Catch ex As Exception
            Throw New Exception("contPlanungData.setUIAnzahl: " + ex.ToString())
        End Try
    End Sub

    Private Sub initData()
        Try
            clPlan.anzNachrichten = 0

        Catch ex As Exception
            Throw New Exception("contPlanungData.initData: " + ex.ToString())
        End Try
    End Sub
    Public Sub clear(clearHTMLBrowser As Boolean)
        Try
            Me.DsPlanSearch1.Clear()
            gridPlans.Refresh()
            Me.contTxtEditor1.textControl1.Text = ""

            clPlan.anzNachrichten = 0

        Catch ex As Exception
            Throw New Exception("contPlanungData.clear: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedPlanungseintr�ge(ByRef gridIsInFront As Boolean) As System.Collections.Generic.List(Of cSelEntries)
        Try
            Dim ret As New System.Collections.Generic.List(Of cSelEntries)
            gridIsInFront = True
            If Not gen.IsNull(Me.gridPlans.ActiveRow) Then
                Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
                PMDS.Global.generic.getSelectedGridRows(Me.gridPlans, rSelected, False)
                If rSelected.Count > 0 Then
                    For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                        Dim v As DataRowView = rGrid.ListObject
                        Dim rPlanSel As dsPlanSearch.planRow = v.Row

                        Dim cSelApp1 As New cSelEntries()
                        cSelApp1.appoint = Nothing
                        cSelApp1.rowGrid = rGrid
                        cSelApp1.rPlanSel = rPlanSel
                        cSelApp1.gridIsActive = True
                        ret.Add(cSelApp1)
                    Next
                End If
            End If

            Return ret

        Catch ex As Exception
            Throw New Exception("contPlanungData.getSelectedPlanungseintr�ge: " + ex.ToString())
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
            Throw New Exception("contPlanungData.selectAllNoneGrid: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub eintr�geSaveHtml(ByVal withMsgBox As Boolean)
        Try
            Dim clFolder As New clFolder()
            Dim gridIsInFront As Boolean = False
            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseintr�ge(gridIsInFront)
            If selectedApp.Count > 0 Then
                Dim fileSelected As String = clFolder.SaveFileDialog("Html-Files (*.html)|*.html", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                If Not gen.IsNull(fileSelected) Then
                    Dim iCounter As Integer = 1
                    For Each cSelEntries1 As cSelEntries In selectedApp
                        Dim filenameToSaveTmp As String = iCounter.ToString() + "_" + fileSelected.Trim()
                        If selectedApp.Count = 1 Then
                            filenameToSaveTmp = fileSelected.Trim()
                        Else
                            filenameToSaveTmp = iCounter.ToString() + "_" + fileSelected.Trim()
                        End If
                        Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(filenameToSaveTmp, True)
                        sw.Write(cSelEntries1.rPlanSel.Text.Trim())
                        sw.Close()
                        sw.Dispose()
                        iCounter += 1
                    Next
                    Dim sTitle As String = doUI.getRes("Save")
                    Dim sText As String = doUI.getRes("DataSaved")
                    doUI.doMessageBoxTranslated(sText, sTitle, MsgBoxStyle.OkOnly)
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.eintr�geSaveHtml: " + ex.ToString())
        End Try
    End Sub
    Public Sub DekursErstellen(ByVal withMsgBox As Boolean, ByRef TypeDekursErstellen As eTypeDekursErstellen)
        Try
            Dim anz As Integer = 0
            Dim lstPlansSelected As New System.Collections.Generic.List(Of General.cInfoPlan)
            Dim gridIsInFront As Boolean = False
            Me.TextControlToWork.Text = ""

            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseintr�ge(gridIsInFront)
            If selectedApp.Count > 0 Then
                Dim doEditor1 As New QS2.Desktop.Txteditor.doEditor()

                For Each cSelEntries1 As cSelEntries In selectedApp
                    If TypeDekursErstellen = eTypeDekursErstellen.DekursErstellen Or
                        TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellen Or
                        TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellenAls Or
                        TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then

                        If Not cSelEntries1.rPlanSel.IsIDPatientNull() AndAlso (Not cSelEntries1.rPlanSel.IDPatient.Equals(System.Guid.Empty)) Then
                            Dim NewInfoPlan As New General.cInfoPlan()
                            NewInfoPlan.ID = cSelEntries1.rPlanSel.IDPatient
                            Dim loadSettings1 As New TXTextControl.LoadSettings()
                            If cSelEntries1.rPlanSel.html Then
                                Me.TextControlToWork.Load(cSelEntries1.rPlanSel.Text, TXTextControl.StringStreamType.HTMLFormat, loadSettings1)
                            Else
                                Me.TextControlToWork.Load(cSelEntries1.rPlanSel.Text, TXTextControl.StringStreamType.PlainText, loadSettings1)
                            End If

                            Dim sTxtTmp As String = ""
                            If cSelEntries1.rPlanSel.Category.Trim() = "" Then
                                Throw New Exception("doAction: cSelAppActuell.rPlanSel.Category.Trim()='' not allowed for IDPlan '" + cSelEntries1.rPlanSel.ID.ToString() + "'!")
                            End If
                            If cSelEntries1.rPlanSel.Betreff.Trim() <> "" And cSelEntries1.rPlanSel.Category.Trim() <> cSelEntries1.rPlanSel.Betreff.Trim() Then
                                sTxtTmp = cSelEntries1.rPlanSel.Category.Trim() + " (" + cSelEntries1.rPlanSel.Betreff.Trim() + ")"
                            Else
                                sTxtTmp = cSelEntries1.rPlanSel.Category.Trim() + ""
                            End If
                            NewInfoPlan.Txt += "Termin " + sTxtTmp + " vom " + cSelEntries1.rPlanSel.BeginntAm.ToString("dd.MM.yyyy HH:mm") + ""

                            If TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then
                                NewInfoPlan.Txt += " (Termin wurde erledigt)"
                            End If
                            lstPlansSelected.Add(NewInfoPlan)

                            If TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then
                                If cSelEntries1.rPlanSel.IsIDPatientNull() Then
                                    Me.compPlan1.updatePlanStatus(cSelEntries1.rPlanSel.ID, "Erledigt")
                                Else
                                    Me.compPlan1.updatePlanObjectStatus(cSelEntries1.rPlanSel.ID, cSelEntries1.rPlanSel.IDPatient, "Erledigt")
                                End If
                                'Me.compPlan1.updatePlanStatus(cSelEntries1.rPlanSel.ID, "Erledigt")
                                anz += 1
                            End If
                            anz += 1
                        End If

                    ElseIf TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzen Then
                        If cSelEntries1.rPlanSel.IsIDPatientNull() Then
                            Me.compPlan1.updatePlanStatus(cSelEntries1.rPlanSel.ID, "Erledigt")
                        Else
                            Me.compPlan1.updatePlanObjectStatus(cSelEntries1.rPlanSel.ID, cSelEntries1.rPlanSel.IDPatient, "Erledigt")
                        End If
                        anz += 1

                    ElseIf TypeDekursErstellen = eTypeDekursErstellen.StorniertSetzen Then
                        If cSelEntries1.rPlanSel.IsIDPatientNull() Then
                            Me.compPlan1.updatePlanStatus(cSelEntries1.rPlanSel.ID, "Storniert")
                        Else
                            Me.compPlan1.updatePlanObjectStatus(cSelEntries1.rPlanSel.ID, cSelEntries1.rPlanSel.IDPatient, "Storniert")
                        End If
                        anz += 1
                    End If
                Next

                If TypeDekursErstellen = eTypeDekursErstellen.DekursErstellen Or
                    TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellen Or
                    TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellenAls Or
                    TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then

                    If lstPlansSelected.Count > 0 Then
                        Dim callMainFctPlan As New PMDS.Global.ENV.eCallMainFctPlan()
                        For Each InfoPlan As General.cInfoPlan In lstPlansSelected
                            Dim Dekursinfo As New PMDS.Global.ENV.cDekursinfo()
                            Dekursinfo.ID = InfoPlan.ID
                            Dekursinfo.Txt = InfoPlan.Txt.Trim()
                            callMainFctPlan.lstDekursInfo.Add(Dekursinfo)
                        Next
                        If TypeDekursErstellen = eTypeDekursErstellen.DekursErstellen Or
                            TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then
                            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.Dekurs, callMainFctPlan)

                        ElseIf TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellen Then
                            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.DekursErstellen, callMainFctPlan)

                        ElseIf TypeDekursErstellen = eTypeDekursErstellen.DekursEntwurfErstellenAls Then
                            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.DekursErstellenAls, callMainFctPlan)

                        Else
                            Throw New Exception("TypeDekursErstellen '" + TypeDekursErstellen.ToString() + "' not allowed!")
                        End If

                        If TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen Then
                            Me.search(True, False, True, False)
                        End If
                    Else
                        doUI.doMessageBox2("NoEntrySelected", "", "!")
                    End If

                ElseIf TypeDekursErstellen = eTypeDekursErstellen.ErledigtSetzen Then
                    Dim strText As String = doUI.getRes("ActivityPerformed2")
                    strText = String.Format(strText, anz.ToString())
                    doUI.doMessageBoxTranslated(strText, "", "!")
                    Me.search(True, False, True, False)

                ElseIf TypeDekursErstellen = eTypeDekursErstellen.StorniertSetzen Then
                    Dim strText As String = doUI.getRes("ActivityPerformed2")
                    strText = String.Format(strText, anz.ToString())
                    doUI.doMessageBoxTranslated(strText, "", "!")
                    Me.search(True, False, True, False)
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.DekursErstellen: " + ex.ToString())
        End Try
    End Sub
    Private Sub eintr�ge�ffnen(ByVal withMsgBox As Boolean)
        Try
            Dim gridIsInFront As Boolean = False
            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseintr�ge(gridIsInFront)
            If selectedApp.Count > 0 Then
                For Each cSelEntries1 As cSelEntries In selectedApp
                    Me.eintrag�ffnen(cSelEntries1.rPlanSel)
                Next
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.eintr�ge�ffnen: " + ex.ToString())
        End Try
    End Sub
    Private Sub eintrag�ffnen(ByRef rPlanSearch As dsPlanSearch.planRow)
        Try
            Dim clManagePlans1 As New UI()
            'clManagePlans1.openMessage(rPlanSearch.ID, Me.mainWindow, False, Me._TypeUI, Me._PlanArchive)
            'lthplan

        Catch ex As Exception
            Throw New Exception("contPlanungData.eintrag�ffnen: " + ex.ToString())
        End Try
    End Sub

    Public Sub neuesObjekt(ByVal dat As Date)
        Try
            Me.mainWindow.newMsg(dat, dat)

        Catch ex As Exception
            Throw New Exception("contPlanungData.neuesObjekt: " + ex.ToString())
        End Try
    End Sub

    Public Sub SetWidthHeigth(ByVal Width As Integer, ByVal Height As Integer)
        Try
            Me.Width = Width
            Me.Height = Height

        Catch ex As Exception
            Throw New Exception("contPlanungData.SetWidthHeigth: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraGridAufgaben_BeforeRowsDeleted1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridPlans.BeforeRowsDeleted
        Try
            If Me.gridPlans.Focused Then
                e.Cancel = True
                'e.DisplayPromptMsg = False
                'If Not Me.deletePlansMen�() Then
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
                    Me.setContextMen�Auto()

                    If Not gen.IsNull(gridPlans.ActiveRow) Then
                        If Me.gridPlans.ActiveRow.IsGroupByRow Or Me.gridPlans.ActiveRow.IsFilterRow Then
                            Exit Sub
                        End If

                        Dim v As DataRowView = gridPlans.ActiveRow.ListObject
                        Dim rPlan As dsPlanSearch.planRow = v.Row
                        Me.showPrieviewTXTControl(rPlan.Text, rPlan.html, rPlan.html, False)

                        If Not rPlan Is Nothing Then
                            If Not rPlan.IsIDArtNull() Then
                                If rPlan.IDArt = 1 Then
                                    If Not rPlan.readed Then
                                        Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                                    End If
                                Else
                                End If
                            End If
                        End If
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
                Me.eintr�ge�ffnen(False)
                'If Not gen.IsNull(gridPlans.ActiveRow) Then
                '    If gridPlans.ActiveRow.IsGroupByRow Then Exit Sub
                '    Dim v As DataRowView = gridPlans.ActiveRow.ListObject
                '    Dim rPlan As dsPlanSearch.planRow = v.Row
                '    Dim clManagePlans1 As New clManagePlans
                '    clManagePlans1.objekt�ffnen(rPlan.ID, Me.mainWindow, Nothing, False)
                'End If
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

    Private Sub L�schenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L�schenToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.doAction(eTypAction.delete, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
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
                Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseintr�ge(gridIsInFront)

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
                    protokollTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("L�schen Termine")

                    Dim bSerienterminSelected As Boolean = False
                    For Each cSelAppActuell As cSelEntries In selectedApp
                        If Not cSelAppActuell.rPlanSel.IsIDSerienterminNull() Then
                            bSerienterminSelected = True
                        End If
                    Next

                    If bSerienterminSelected Then
                        Dim sMsgBoxTxt11 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Serientermine zum L�schen ausgew�hlt!")
                        Dim sMsgBoxTxt12 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen bei Serienterminen alle Termine gel�scht werden?")
                        resSerientermineSeleteAll = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTxt11 + vbNewLine + sMsgBoxTxt12, "", MessageBoxButtons.YesNo, True)
                    End If

                ElseIf typAction = eTypAction.DekursErstellen Then

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
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} wurde gel�scht!")
                                sMsgBoxTxt = String.Format(sMsgBoxTxt, cSelAppActuell.rPlanSel.Betreff.Trim() + " (" + cSelAppActuell.rPlanSel.ErstelltAm.ToString("dd.MM.yyyy HH:mm:ss") + ")")
                                protokollSaveTxt += sMsgBoxTxt.Trim() + vbNewLine

                                'cOutlookWebAPI1.deleteOutlookItem(IDPlan, cSelAppActuell.rPlanSel.SendWithPostOfficeBoxForAll)
                                If resSerientermineSeleteAll = DialogResult.Yes Then
                                    If Not cSelAppActuell.rPlanSel.IsIDSerienterminNull() Then
                                        Me.compPlan1.deletePlanSerientermine(cSelAppActuell.rPlanSel.IDSerientermin)
                                    End If
                                End If
                                Me.compPlan1.deletePlan(cSelAppActuell.rPlanSel.ID, cSelAppActuell.rPlanSel.MessageId, cSelAppActuell.rPlanSel.F�r, cSelAppActuell.rPlanSel.IDArt, cSelAppActuell.rPlanSel.Betreff)

                                If gridIsInFront Then
                                    cSelAppActuell.rPlanSel.Delete()
                                End If
                            Else
                                Dim sMsgBoxTxt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} kann nicht gel�scht werden!")
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

                        ElseIf typAction = eTypAction.DekursErstellen Then
                            If Not cSelAppActuell.rPlanSel.IsIDPatientNull() AndAlso (Not cSelAppActuell.rPlanSel.IDPatient.Equals(System.Guid.Empty)) Then
                                Dim NewInfoPlan As New General.cInfoPlan()
                                NewInfoPlan.ID = cSelAppActuell.rPlanSel.IDPatient
                                Dim loadSettings1 As New TXTextControl.LoadSettings()
                                If cSelAppActuell.rPlanSel.html Then
                                    Me.TextControlToWork.Load(cSelAppActuell.rPlanSel.Text, TXTextControl.StringStreamType.HTMLFormat, loadSettings1)
                                Else
                                    Me.TextControlToWork.Load(cSelAppActuell.rPlanSel.Text, TXTextControl.StringStreamType.PlainText, loadSettings1)
                                End If

                                Dim txtPlainTxt As String = ""
                                Me.TextControlToWork.Save(txtPlainTxt, TXTextControl.StringStreamType.PlainText)
                                Dim sTxtTmp As String = ""
                                sTxtTmp = ""
                                If cSelAppActuell.rPlanSel.Category.Trim() = "" Then
                                    Throw New Exception("doAction: cSelAppActuell.rPlanSel.Category.Trim()='' not allowed for IDPlan '" + cSelAppActuell.rPlanSel.ID.ToString() + "'!")
                                End If
                                If cSelAppActuell.rPlanSel.Betreff.Trim() <> "" And cSelAppActuell.rPlanSel.Category.Trim() <> cSelAppActuell.rPlanSel.Betreff.Trim() Then
                                    sTxtTmp = cSelAppActuell.rPlanSel.Category.Trim() + " (" + cSelAppActuell.rPlanSel.Betreff.Trim() + ")"
                                Else
                                    sTxtTmp = cSelAppActuell.rPlanSel.Category.Trim() + ""
                                End If
                                NewInfoPlan.Txt += "Termin " + sTxtTmp + " vom " + cSelAppActuell.rPlanSel.BeginntAm.ToString("dd.MM.yyyy HH:mm") + ""

                                lstPlansSelected.Add(NewInfoPlan)
                                anz += 1
                            End If
                        End If
                    Next

                    If typAction = eTypAction.delete Then
                        If gridIsInFront Then
                            Me.search(True, False, True, False)
                            'Me.gridPlans.Refresh()
                        End If
                        If withMsgBox Then
                            Dim strText As String = doUI.getRes("ActivityPerformed2")
                            strText = String.Format(strText, selectedApp.Count.ToString())
                            doUI.doMessageBoxTranslated(strText, "", "!")
                        End If
                        If protokollTxt.Trim() <> "" Then
                            protokollTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Termine k�nnen nicht gel�scht werden da keine Berechtigung:") + vbNewLine + vbNewLine + protokollTxt
                        End If

                    ElseIf typAction = eTypAction.DekursErstellen Then
                        If lstPlansSelected.Count > 0 Then
                            Dim callMainFctPlan As New PMDS.Global.ENV.eCallMainFctPlan()
                            For Each InfoPlan As General.cInfoPlan In lstPlansSelected
                                Dim Dekursinfo As New PMDS.Global.ENV.cDekursinfo()
                                Dekursinfo.ID = InfoPlan.ID
                                Dekursinfo.Txt = InfoPlan.Txt.Trim()
                                callMainFctPlan.lstDekursInfo.Add(Dekursinfo)
                            Next
                            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.Dekurs, callMainFctPlan)
                        Else
                            doUI.doMessageBox2("NoEntrySelected", "", "!")
                        End If

                    End If

                    If protokollTxt.Trim() <> "" Then
                        Me.doProtokoll(protokollTxt, protokollTitle, anzErr)
                    End If
                    If protokollSaveTxt.Trim() <> "" Then
                        Dim sTxtTitleProt As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine l�schen")
                        Me.b.saveProtocol(db, sTxtTitleProt, protokollSaveTxt)
                    End If

                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("contPlanungData.doAction: " + ex.ToString())
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
            Throw New Exception("contPlanungData.doProtokoll: " + ex.ToString())
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
            callMainFctPlan.lstKlients = Me.mainWindow.contSelectPatienten.getObjectInfo(True, False, iCounter)
            iCounter = 0
            callMainFctPlan.lstUsers = Me.mainWindow.contSelectBenutzer.getObjectInfo(False, True, iCounter)
            callMainFctPlan.Quickbutton = Me.mainWindow._lastQuickbutton.Trim()

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim IDCategory As String = Me.mainWindow.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            callMainFctPlan.lstCategories = IDCategory

            Me.gen.callMainFctPMDS([Global].ENV.eFctCallMainFctPlan.PrintTermine, callMainFctPlan)

        Catch ex As Exception
            Throw New Exception("contPlanungData.print: " + ex.ToString())
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
            Me.AllesAusw�hlenToolStripMenuItem.Visible = bOn
            Me.KeineAuswah�lenToolStripMenuItem.Visible = bOn
            Me.ToolStripMenuItemSpace4.Visible = bOn

        Catch ex As Exception
            Throw New Exception("contPlanungData.setUIContextSelectAlleKeine: " + ex.ToString())
        End Try
    End Sub


    Private Sub doPreviewTxt(ByVal autoTypeToShow As Boolean, ByVal browser As Boolean)
        Try
            Me.doEditor1.showText("", TXTextControl.StreamType.PlainText, False, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)

            Dim gridIsInFront As Boolean = False
            Dim selectedApp As System.Collections.Generic.List(Of cSelEntries) = Me.getSelectedPlanungseintr�ge(gridIsInFront)
            If selectedApp.Count > 0 Then
                Dim rPlanSearch As dsPlanSearch.planRow = selectedApp(selectedApp.Count - 1).rPlanSel
                If Not rPlanSearch Is Nothing Then
                    Dim txt As String = rPlanSearch(Me.DsPlanSearch1.plan.TextColumn.ColumnName, DataRowVersion.Original)
                    Dim isHtml As Boolean = rPlanSearch(Me.DsPlanSearch1.plan.htmlColumn.ColumnName, DataRowVersion.Original)
                    If autoTypeToShow Then
                        Me.showPrieviewTXTControl(txt, isHtml, isHtml, False)
                    Else
                        Me.showPrieviewTXTControl(txt, isHtml, browser, True)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.doPreviewTxt: " + ex.ToString())
        End Try
    End Sub
    Public Sub showPrieviewTXTControl(ByVal text As String, ByVal html As Boolean, ByVal browser As Boolean, ByVal doIntEditorHtml As Boolean)
        Try
            Application.DoEvents()
            Dim typ As New TXTextControl.StringStreamType
            If html Then
                typ = TXTextControl.StringStreamType.HTMLFormat
                Me.LoadTxtControl(TXTextControl.StreamType.HTMLFormat, False, text)
            Else
                typ = TXTextControl.StringStreamType.PlainText
                Me.LoadTxtControl(TXTextControl.StringStreamType.PlainText, False, text)
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.showPrieviewTXTControl: " + ex.ToString())
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
            Throw New Exception("contPlanungData.ClearHTMLBrowser: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadTxtControl(DefaultLoadTypes As TXTextControl.StringStreamType, all As Boolean, txt As String)
        Try
            Me.contTxtEditor1.textControl1.Text = ""

            If Not Me.isFirstShow Then
                Me.contTxtEditor1.textControl1.Text = ""
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.LoadTxtControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub setContextMen�Auto()
        Try
            Me.ContexMen�Items(False)

            Dim ret As New cSelEntries
            Me.setContextMen�ForGrid(gridPlans.ActiveRow)

        Catch ex As Exception
            Throw New Exception("contPlanungData.setContextMen�Auto: " + ex.ToString())
        End Try
    End Sub
    Private Sub setContextMen�ForGrid(ByVal actRow As Infragistics.Win.UltraWinGrid.UltraGridRow)
        Try
            If Not gen.IsNull(actRow) Then
                If actRow.IsGroupByRow Or actRow.IsFilterRow Then
                    Me.ContexMen�Items(False)
                Else
                    Me.ContexMen�Items(True)
                End If
            Else
                Me.ContexMen�Items(False)
            End If

        Catch ex As Exception
            Throw New Exception("contPlanungData.setContextMen�ForGrid: " + ex.ToString())
        End Try
    End Sub
    Public Sub ContexMen�Items(ByVal bOn As Boolean)
        Try
            Me.L�schenToolStripMenuItem1.Visible = True
            Me.ToolStripMenuItemSpace1.Visible = True

        Catch ex As Exception
            Throw New Exception("contPlanungData.ContexMen�Items: " + ex.ToString())
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


    Private Sub AllesAusw�hlenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllesAusw�hlenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.selectAllNoneGrid(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub KeineAuswah�lenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswah�lenToolStripMenuItem.Click
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
            Throw New Exception("contPlanungData.resizeControl: " + ex.ToString())
        End Try
    End Sub


    Private Sub OpenSqlCommandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSqlCommandToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim frmProt As New QS2.core.vb.frmProtocol()
            frmProt.initControl()
            frmProt.Show()
            frmProt.ContProtocol1.setText(Me.SqlCommandReturn.Trim())
            frmProt.Text = "Sql-Command plan-system"

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Shared Sub reloadHTMLControl(ByRef PanelTxtEditor As Panel, ByRef htmlControlToSet As SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor)
        Try
            PanelTxtEditor.Controls.Clear()
            htmlControlToSet = Nothing
            Dim gen As New General()
            gen.GarbColl()
            Application.DoEvents()

            Dim htmlControl As New SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor()
            htmlControl.Dock = DockStyle.Fill
            htmlControl.AutoScrollMargin = New System.Drawing.Size(0, 0)
            htmlControl.AutoScrollMinSize = New System.Drawing.Size(0, 0)
            htmlControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            htmlControl.BackgroundImagePath = ""
            htmlControl.BaseUrl = ""
            htmlControl.BodyColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            htmlControl.BodyCSSClassName = Nothing
            htmlControl.BodyHtml = ""
            htmlControl.BodyStyle = ""
            htmlControl.Charset = "utf-8"
            htmlControl.DefaultForeColor = System.Drawing.Color.Black
            htmlControl.Dock = System.Windows.Forms.DockStyle.Fill
            htmlControl.DocumentCSSFilePath = ""
            htmlControl.DocumentHtml = "<!DOCTYPE html><html></html>"
            htmlControl.DocumentTitle = ""
            htmlControl.EditorContextMenuStrip = Nothing
            htmlControl.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
            htmlControl.HeaderStyleContent = ""
            htmlControl.HeaderStyleContentElementID = "page_style"
            htmlControl.HorizontalScroll = Nothing
            htmlControl.Location = New System.Drawing.Point(0, 0)
            htmlControl.Name = "winFormHtmlEditor1"
            htmlControl.Options.ConvertFileUrlsToLocalPaths = True
            htmlControl.Options.CustomDOCTYPE = Nothing
            htmlControl.Options.FooterTagNavigatorFont = Nothing
            htmlControl.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal
            htmlControl.Options.FTPSettingsForRemoteResources.ConnectionMode = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.FTPSettings.ConnectionModes.Active
            htmlControl.Options.FTPSettingsForRemoteResources.Host = Nothing
            htmlControl.Options.FTPSettingsForRemoteResources.Password = Nothing
            htmlControl.Options.FTPSettingsForRemoteResources.Port = Nothing
            htmlControl.Options.FTPSettingsForRemoteResources.RemoteFolderPath = Nothing
            htmlControl.Options.FTPSettingsForRemoteResources.Timeout = 4000
            htmlControl.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = Nothing
            htmlControl.Options.FTPSettingsForRemoteResources.UserName = Nothing
            htmlControl.Options.DefaultHtmlType = SpiceLogic.HtmlEditorControl.Domain.BOs.HtmlContentTypes.DocumentHtml
            htmlControl.ScrollBarSetting = SpiceLogic.HtmlEditorControl.Domain.BOs.ScrollBarVisibility.[Default]
            htmlControl.Size = New System.Drawing.Size(691, 268)
            htmlControl.SpellCheckOptions.CurlyUnderlineImageFilePath = Nothing
            htmlControl.SpellCheckOptions.CustomSpellCheckerEngine = Nothing
            htmlControl.SpellCheckOptions.DictionaryFile = New SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo(Nothing, Nothing, True, Nothing)
            htmlControl.SpellCheckOptions.WaitAlertMessage = "Searching next messpelled word..... (please wait)"
            htmlControl.TabIndex = 4

            htmlControl.Toolbar1.Location = New System.Drawing.Point(0, 0)
            htmlControl.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1"
            htmlControl.Toolbar1.Size = New System.Drawing.Size(691, 29)
            htmlControl.Toolbar1.TabIndex = 0

            htmlControl.Toolbar2.Location = New System.Drawing.Point(0, 29)
            htmlControl.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2"
            htmlControl.Toolbar2.Size = New System.Drawing.Size(691, 29)
            htmlControl.Toolbar2.TabIndex = 0
            htmlControl.ToolbarContextMenuStrip = Nothing

            htmlControl.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            htmlControl.ToolbarFooter.Location = New System.Drawing.Point(0, 243)
            htmlControl.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter"
            htmlControl.ToolbarFooter.Size = New System.Drawing.Size(691, 25)
            htmlControl.ToolbarFooter.TabIndex = 7
            htmlControl.VerticalScroll = Nothing
            htmlControl.z__ignore = False

            PanelTxtEditor.Controls.Add(htmlControl)
            htmlControlToSet = htmlControl

        Catch ex As Exception
            Throw New Exception("contPlanungData.reloadHTMLControl: " + ex.ToString())
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

    Private Sub TermineErledigenUndDekursSchreibenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineErledigenUndDekursSchreibenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DekursErstellen(True, eTypeDekursErstellen.ErledigtSetzenUndDekursErstellen)
            'Me.doAction(eTypAction.DekursErstellen, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub TermineErledigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineErledigenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DekursErstellen(True, eTypeDekursErstellen.ErledigtSetzen)
            'Me.doAction(eTypAction.DekursErstellen, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TermineStornierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermineStornierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DekursErstellen(True, eTypeDekursErstellen.StorniertSetzen)
            'Me.doAction(eTypAction.DekursErstellen, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ListeLeerenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeLeerenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.mainWindow.zur�cksetzen(False, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
