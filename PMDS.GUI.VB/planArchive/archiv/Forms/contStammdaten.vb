Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms
Imports System.IO
Imports System.Web



Public Class contStammdaten
    Inherits System.Windows.Forms.UserControl


    Private gen As New GeneralArchiv
    Private ui As New UIElements()

    Private db_SchrFachOrd As New compSql
    Private dsSchränke As New dsPlanArchive
    Private dsFächer As New dsPlanArchive
    Private dsOrdner As New dsPlanArchive

    Private db_ThemSchlag As New compSql
    Private dataThemen As New dsPlanArchive
    Private dataSchlagwörter As New dsPlanArchive

    Private TypObjekt_NextID As Integer = 0

    Public mainForm As frmStammdaten
    Private usr As New GeneralArchiv



    Public tableActive_SchränkeFächer As New TableIsActive_SchränkeFächer
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblPfadAuswahlen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPostBoxErstellen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblGesamtesArchivLöschen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraButtonPfadSpeichern As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtPfad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UButtonSchränkeSpeichern2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonFächerNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchränkeLöschen2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchränkeNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaSpeichern2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchlagwörterNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaLöschen2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents ContOrdner1 As contOrdner
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public Enum TableIsActive_SchränkeFächer
        schränke = 0
        fächer = 1
        keiner = 10
    End Enum

    Public tableActive_Schlagwörter As New TableIsActive_Schlagwörter
    Public Enum TableIsActive_Schlagwörter
        schlagwörter = 0
        thema = 1
        keiner = 10
    End Enum


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
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UTabPageSchrankFachOrdner As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UTabPageSchlagwörter As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UTabStammdaten As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents DsThemenAnzeige1 As dsPlanArchive
    Friend WithEvents DsSchlagwörterAnzeige1 As dsPlanArchive
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CMenuOrdner As System.Windows.Forms.ContextMenu
    Friend WithEvents MItemOrdnerNeu As System.Windows.Forms.MenuItem
    Friend WithEvents MItemOrdnerLöschen As System.Windows.Forms.MenuItem
    Friend WithEvents UGridSchränke As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridThemen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridSchlagwörter As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DsSchrankAnzeigeSuche1 As dsPlanArchive
    Friend WithEvents UGridFächer As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsFachAnzeigeSuche1 As dsPlanArchive
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo7 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contStammdaten))
        Dim UltraToolTipInfo8 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo9 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblFach", -1)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSchrank")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSchrank", -1)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Extern")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo10 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo11 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo12 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSchlagwörter", -1)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDThema")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Schlagwort", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblThemen", -1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Thema", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridBagLayoutPanel1 = New Infragistics.Win.Misc.UltraGridBagLayoutPanel()
        Me.ContOrdner1 = New contOrdner()
        Me.UTabPageSchrankFachOrdner = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UButtonSchränkeSpeichern2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonFächerNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchränkeLöschen2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchränkeNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UGridFächer = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsFachAnzeigeSuche1 = New dsPlanArchive()
        Me.UGridSchränke = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsSchrankAnzeigeSuche1 = New dsPlanArchive()
        Me.UTabPageSchlagwörter = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UButtonThemaSpeichern2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchlagwörterNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonThemaLöschen2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonThemaNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UGridSchlagwörter = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsSchlagwörterAnzeige1 = New dsPlanArchive()
        Me.UGridThemen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsThemenAnzeige1 = New dsPlanArchive()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtPfad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraButtonPfadSpeichern = New Infragistics.Win.Misc.UltraButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPfadAuswahlen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPostBoxErstellen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGesamtesArchivLöschen = New Infragistics.Win.Misc.UltraLabel()
        Me.CMenuOrdner = New System.Windows.Forms.ContextMenu()
        Me.MItemOrdnerNeu = New System.Windows.Forms.MenuItem()
        Me.MItemOrdnerLöschen = New System.Windows.Forms.MenuItem()
        Me.UTabStammdaten = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.UTabPageSchrankFachOrdner.SuspendLayout()
        CType(Me.UGridFächer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFachAnzeigeSuche1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UGridSchränke, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchrankAnzeigeSuche1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabPageSchlagwörter.SuspendLayout()
        CType(Me.UGridSchlagwörter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchlagwörterAnzeige1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UGridThemen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsThemenAnzeige1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.txtPfad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTabStammdaten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabStammdaten.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridBagLayoutPanel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(633, 452)
        '
        'UltraGridBagLayoutPanel1
        '
        Me.UltraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.UltraGridBagLayoutPanel1.Controls.Add(Me.ContOrdner1)
        Me.UltraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridBagLayoutPanel1.ExpandToFitHeight = True
        Me.UltraGridBagLayoutPanel1.ExpandToFitWidth = True
        Me.UltraGridBagLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridBagLayoutPanel1.Name = "UltraGridBagLayoutPanel1"
        Me.UltraGridBagLayoutPanel1.Size = New System.Drawing.Size(633, 452)
        Me.UltraGridBagLayoutPanel1.TabIndex = 230
        '
        'ContOrdner1
        '
        Me.ContOrdner1.BackColor = System.Drawing.Color.White
        Me.ContOrdner1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContOrdner1.Cursor = System.Windows.Forms.Cursors.Default
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 5
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.Insets.Top = 5
        GridBagConstraint2.OriginX = 0
        GridBagConstraint2.OriginY = 0
        Me.UltraGridBagLayoutPanel1.SetGridBagConstraint(Me.ContOrdner1, GridBagConstraint2)
        Me.ContOrdner1.Location = New System.Drawing.Point(5, 5)
        Me.ContOrdner1.Name = "ContOrdner1"
        Me.UltraGridBagLayoutPanel1.SetPreferredSize(Me.ContOrdner1, New System.Drawing.Size(532, 235))
        Me.ContOrdner1.Size = New System.Drawing.Size(623, 442)
        Me.ContOrdner1.TabIndex = 229
        '
        'UTabPageSchrankFachOrdner
        '
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchränkeSpeichern2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonFächerNeu2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchränkeLöschen2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchränkeNeu2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UGridFächer)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UGridSchränke)
        Me.UTabPageSchrankFachOrdner.Location = New System.Drawing.Point(-10000, -10000)
        Me.UTabPageSchrankFachOrdner.Name = "UTabPageSchrankFachOrdner"
        Me.UTabPageSchrankFachOrdner.Size = New System.Drawing.Size(633, 452)
        '
        'UButtonSchränkeSpeichern2
        '
        Appearance72.Image = "ICO_speichern.ico"
        Appearance72.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.UButtonSchränkeSpeichern2.Appearance = Appearance72
        Me.UButtonSchränkeSpeichern2.Location = New System.Drawing.Point(442, 421)
        Me.UButtonSchränkeSpeichern2.Name = "UButtonSchränkeSpeichern2"
        Me.UButtonSchränkeSpeichern2.Size = New System.Drawing.Size(85, 27)
        Me.UButtonSchränkeSpeichern2.TabIndex = 238
        Me.UButtonSchränkeSpeichern2.Text = "Speichern"
        '
        'UButtonFächerNeu2
        '
        Appearance73.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonFächerNeu2.Appearance = Appearance73
        Me.UButtonFächerNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonFächerNeu2.Location = New System.Drawing.Point(501, 12)
        Me.UButtonFächerNeu2.Name = "UButtonFächerNeu2"
        Me.UButtonFächerNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonFächerNeu2.TabIndex = 237
        UltraToolTipInfo7.ToolTipText = "Hinzufügen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonFächerNeu2, UltraToolTipInfo7)
        '
        'UButtonSchränkeLöschen2
        '
        Appearance74.Image = CType(resources.GetObject("Appearance74.Image"), Object)
        Appearance74.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonSchränkeLöschen2.Appearance = Appearance74
        Me.UButtonSchränkeLöschen2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchränkeLöschen2.Location = New System.Drawing.Point(314, 12)
        Me.UButtonSchränkeLöschen2.Name = "UButtonSchränkeLöschen2"
        Me.UButtonSchränkeLöschen2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchränkeLöschen2.TabIndex = 236
        UltraToolTipInfo8.ToolTipText = "Entfernen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchränkeLöschen2, UltraToolTipInfo8)
        '
        'UButtonSchränkeNeu2
        '
        Appearance75.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonSchränkeNeu2.Appearance = Appearance75
        Me.UButtonSchränkeNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchränkeNeu2.Location = New System.Drawing.Point(292, 12)
        Me.UButtonSchränkeNeu2.Name = "UButtonSchränkeNeu2"
        Me.UButtonSchränkeNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchränkeNeu2.TabIndex = 235
        UltraToolTipInfo9.ToolTipText = "Hinzufügen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchränkeNeu2, UltraToolTipInfo9)
        '
        'UGridFächer
        '
        Me.UGridFächer.DataSource = Me.DsFachAnzeigeSuche1.tblFach
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridFächer.DisplayLayout.Appearance = Appearance46
        Me.UGridFächer.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 68
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn31.Header.Caption = "Fächer"
        UltraGridColumn31.Header.VisiblePosition = 1
        UltraGridColumn31.Width = 144
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn32.Header.VisiblePosition = 2
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 102
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn33.Header.VisiblePosition = 3
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 71
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn34.Header.VisiblePosition = 4
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 115
        UltraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance47.BackColor = System.Drawing.Color.Red
        Appearance47.BackColor2 = System.Drawing.Color.Red
        Appearance47.ForeColor = System.Drawing.Color.White
        UltraGridColumn35.Header.Appearance = Appearance47
        UltraGridColumn35.Header.Caption = "Extern J/N"
        UltraGridColumn35.Header.VisiblePosition = 5
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 69
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35})
        Me.UGridFächer.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.UGridFächer.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridFächer.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance48.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance48.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridFächer.DisplayLayout.GroupByBox.Appearance = Appearance48
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridFächer.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance49
        Me.UGridFächer.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance50.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance50.BackColor2 = System.Drawing.SystemColors.Control
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridFächer.DisplayLayout.GroupByBox.PromptAppearance = Appearance50
        Me.UGridFächer.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridFächer.DisplayLayout.MaxRowScrollRegions = 1
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridFächer.DisplayLayout.Override.ActiveCellAppearance = Appearance51
        Appearance52.BackColor = System.Drawing.SystemColors.Highlight
        Appearance52.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridFächer.DisplayLayout.Override.ActiveRowAppearance = Appearance52
        Me.UGridFächer.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridFächer.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Me.UGridFächer.DisplayLayout.Override.CardAreaAppearance = Appearance53
        Appearance54.BorderColor = System.Drawing.Color.Silver
        Appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridFächer.DisplayLayout.Override.CellAppearance = Appearance54
        Me.UGridFächer.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridFächer.DisplayLayout.Override.CellPadding = 0
        Appearance55.BackColor = System.Drawing.SystemColors.Control
        Appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridFächer.DisplayLayout.Override.GroupByRowAppearance = Appearance55
        Appearance56.TextHAlignAsString = "Left"
        Me.UGridFächer.DisplayLayout.Override.HeaderAppearance = Appearance56
        Me.UGridFächer.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridFächer.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance57.BackColor = System.Drawing.SystemColors.Window
        Appearance57.BorderColor = System.Drawing.Color.Silver
        Me.UGridFächer.DisplayLayout.Override.RowAppearance = Appearance57
        Me.UGridFächer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance58.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridFächer.DisplayLayout.Override.TemplateAddRowAppearance = Appearance58
        Me.UGridFächer.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridFächer.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridFächer.Location = New System.Drawing.Point(345, 10)
        Me.UGridFächer.Name = "UGridFächer"
        Me.UGridFächer.Size = New System.Drawing.Size(182, 410)
        Me.UGridFächer.TabIndex = 1
        '
        'DsFachAnzeigeSuche1
        '
        Me.DsFachAnzeigeSuche1.DataSetName = "dsFachAnzeigeSuche"
        Me.DsFachAnzeigeSuche1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsFachAnzeigeSuche1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UGridSchränke
        '
        Me.UGridSchränke.DataSource = Me.DsSchrankAnzeigeSuche1.tblSchrank
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchränke.DisplayLayout.Appearance = Appearance59
        Me.UGridSchränke.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn36.Header.VisiblePosition = 1
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 103
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn37.Header.Caption = "Schränke"
        UltraGridColumn37.Header.VisiblePosition = 0
        UltraGridColumn37.Width = 144
        UltraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn38.Header.VisiblePosition = 2
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 72
        UltraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn39.Header.VisiblePosition = 3
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.Width = 92
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance60.BackColor = System.Drawing.Color.Red
        Appearance60.BackColor2 = System.Drawing.Color.Red
        Appearance60.ForeColor = System.Drawing.Color.White
        Appearance60.TextHAlignAsString = "Center"
        Appearance60.TextVAlignAsString = "Middle"
        UltraGridColumn40.Header.Appearance = Appearance60
        UltraGridColumn40.Header.Caption = "Extern J/N"
        UltraGridColumn40.Header.VisiblePosition = 4
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 65
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
        Me.UGridSchränke.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.UGridSchränke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchränke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance61.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchränke.DisplayLayout.GroupByBox.Appearance = Appearance61
        Appearance62.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchränke.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance62
        Me.UGridSchränke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance63.BackColor2 = System.Drawing.SystemColors.Control
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchränke.DisplayLayout.GroupByBox.PromptAppearance = Appearance63
        Me.UGridSchränke.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchränke.DisplayLayout.MaxRowScrollRegions = 1
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Appearance64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchränke.DisplayLayout.Override.ActiveCellAppearance = Appearance64
        Appearance65.BackColor = System.Drawing.SystemColors.Highlight
        Appearance65.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridSchränke.DisplayLayout.Override.ActiveRowAppearance = Appearance65
        Me.UGridSchränke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchränke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchränke.DisplayLayout.Override.CardAreaAppearance = Appearance66
        Appearance67.BorderColor = System.Drawing.Color.Silver
        Appearance67.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchränke.DisplayLayout.Override.CellAppearance = Appearance67
        Me.UGridSchränke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchränke.DisplayLayout.Override.CellPadding = 0
        Appearance68.BackColor = System.Drawing.SystemColors.Control
        Appearance68.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance68.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance68.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchränke.DisplayLayout.Override.GroupByRowAppearance = Appearance68
        Appearance69.TextHAlignAsString = "Left"
        Me.UGridSchränke.DisplayLayout.Override.HeaderAppearance = Appearance69
        Me.UGridSchränke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchränke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchränke.DisplayLayout.Override.RowAppearance = Appearance70
        Me.UGridSchränke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchränke.DisplayLayout.Override.TemplateAddRowAppearance = Appearance71
        Me.UGridSchränke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchränke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridSchränke.Location = New System.Drawing.Point(159, 10)
        Me.UGridSchränke.Name = "UGridSchränke"
        Me.UGridSchränke.Size = New System.Drawing.Size(182, 410)
        Me.UGridSchränke.TabIndex = 0
        '
        'DsSchrankAnzeigeSuche1
        '
        Me.DsSchrankAnzeigeSuche1.DataSetName = "dsSchrankAnzeigeSuche"
        Me.DsSchrankAnzeigeSuche1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsSchrankAnzeigeSuche1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UTabPageSchlagwörter
        '
        Me.UTabPageSchlagwörter.Controls.Add(Me.UButtonThemaSpeichern2)
        Me.UTabPageSchlagwörter.Controls.Add(Me.UButtonSchlagwörterNeu2)
        Me.UTabPageSchlagwörter.Controls.Add(Me.UButtonThemaLöschen2)
        Me.UTabPageSchlagwörter.Controls.Add(Me.UButtonThemaNeu2)
        Me.UTabPageSchlagwörter.Controls.Add(Me.UGridSchlagwörter)
        Me.UTabPageSchlagwörter.Controls.Add(Me.UGridThemen)
        Me.UTabPageSchlagwörter.Location = New System.Drawing.Point(-10000, -10000)
        Me.UTabPageSchlagwörter.Name = "UTabPageSchlagwörter"
        Me.UTabPageSchlagwörter.Size = New System.Drawing.Size(633, 452)
        '
        'UButtonThemaSpeichern2
        '
        Appearance76.Image = "ICO_speichern.ico"
        Appearance76.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.UButtonThemaSpeichern2.Appearance = Appearance76
        Me.UButtonThemaSpeichern2.Location = New System.Drawing.Point(442, 421)
        Me.UButtonThemaSpeichern2.Name = "UButtonThemaSpeichern2"
        Me.UButtonThemaSpeichern2.Size = New System.Drawing.Size(85, 27)
        Me.UButtonThemaSpeichern2.TabIndex = 242
        Me.UButtonThemaSpeichern2.Text = "Speichern"
        '
        'UButtonSchlagwörterNeu2
        '
        Appearance77.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance77.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UButtonSchlagwörterNeu2.Appearance = Appearance77
        Me.UButtonSchlagwörterNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchlagwörterNeu2.Location = New System.Drawing.Point(501, 12)
        Me.UButtonSchlagwörterNeu2.Name = "UButtonSchlagwörterNeu2"
        Me.UButtonSchlagwörterNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchlagwörterNeu2.TabIndex = 241
        UltraToolTipInfo10.ToolTipText = "Hinzufügen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchlagwörterNeu2, UltraToolTipInfo10)
        '
        'UButtonThemaLöschen2
        '
        Appearance78.Image = CType(resources.GetObject("Appearance78.Image"), Object)
        Appearance78.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance78.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UButtonThemaLöschen2.Appearance = Appearance78
        Me.UButtonThemaLöschen2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonThemaLöschen2.Location = New System.Drawing.Point(314, 12)
        Me.UButtonThemaLöschen2.Name = "UButtonThemaLöschen2"
        Me.UButtonThemaLöschen2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonThemaLöschen2.TabIndex = 240
        UltraToolTipInfo11.ToolTipText = "Entfernen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonThemaLöschen2, UltraToolTipInfo11)
        '
        'UButtonThemaNeu2
        '
        Appearance79.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance79.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UButtonThemaNeu2.Appearance = Appearance79
        Me.UButtonThemaNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonThemaNeu2.Location = New System.Drawing.Point(292, 12)
        Me.UButtonThemaNeu2.Name = "UButtonThemaNeu2"
        Me.UButtonThemaNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonThemaNeu2.TabIndex = 239
        UltraToolTipInfo12.ToolTipText = "Hinzufügen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonThemaNeu2, UltraToolTipInfo12)
        '
        'UGridSchlagwörter
        '
        Me.UGridSchlagwörter.DataSource = Me.DsSchlagwörterAnzeige1.tblSchlagwörter
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchlagwörter.DisplayLayout.Appearance = Appearance8
        Me.UGridSchlagwörter.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn21.Header.VisiblePosition = 0
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 40
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn22.Header.VisiblePosition = 1
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 126
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn23.Header.VisiblePosition = 2
        UltraGridColumn23.Width = 144
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn24.Header.VisiblePosition = 3
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 59
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn25.Header.VisiblePosition = 4
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 72
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        Me.UGridSchlagwörter.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UGridSchlagwörter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchlagwörter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwörter.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwörter.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.UGridSchlagwörter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwörter.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.UGridSchlagwörter.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchlagwörter.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchlagwörter.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridSchlagwörter.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.UGridSchlagwörter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchlagwörter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwörter.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchlagwörter.DisplayLayout.Override.CellAppearance = Appearance15
        Me.UGridSchlagwörter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchlagwörter.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwörter.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.UGridSchlagwörter.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.UGridSchlagwörter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchlagwörter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchlagwörter.DisplayLayout.Override.RowAppearance = Appearance18
        Me.UGridSchlagwörter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchlagwörter.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.UGridSchlagwörter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchlagwörter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridSchlagwörter.Location = New System.Drawing.Point(345, 10)
        Me.UGridSchlagwörter.Name = "UGridSchlagwörter"
        Me.UGridSchlagwörter.Size = New System.Drawing.Size(182, 410)
        Me.UGridSchlagwörter.TabIndex = 1
        Me.UGridSchlagwörter.Text = "UltraGrid1"
        '
        'DsSchlagwörterAnzeige1
        '
        Me.DsSchlagwörterAnzeige1.DataSetName = "dsSchlagwörterAnzeige"
        Me.DsSchlagwörterAnzeige1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsSchlagwörterAnzeige1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UGridThemen
        '
        Me.UGridThemen.DataSource = Me.DsThemenAnzeige1.tblThemen
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridThemen.DisplayLayout.Appearance = Appearance20
        Me.UGridThemen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 81
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.Width = 144
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn28.Header.VisiblePosition = 2
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 33
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn29.Header.VisiblePosition = 3
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 36
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29})
        Me.UGridThemen.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.UGridThemen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridThemen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridThemen.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridThemen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.UGridThemen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridThemen.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.UGridThemen.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridThemen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridThemen.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridThemen.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.UGridThemen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridThemen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.UGridThemen.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridThemen.DisplayLayout.Override.CellAppearance = Appearance27
        Me.UGridThemen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridThemen.DisplayLayout.Override.CellPadding = 0
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridThemen.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.TextHAlignAsString = "Left"
        Me.UGridThemen.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.UGridThemen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridThemen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.UGridThemen.DisplayLayout.Override.RowAppearance = Appearance30
        Me.UGridThemen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridThemen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.UGridThemen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridThemen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridThemen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UGridThemen.Location = New System.Drawing.Point(159, 10)
        Me.UGridThemen.Name = "UGridThemen"
        Me.UGridThemen.Size = New System.Drawing.Size(182, 410)
        Me.UGridThemen.TabIndex = 0
        '
        'DsThemenAnzeige1
        '
        Me.DsThemenAnzeige1.DataSetName = "dsThemenAnzeige"
        Me.DsThemenAnzeige1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsThemenAnzeige1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtPfad)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraButtonPfadSpeichern)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.lblPfadAuswahlen)
        Me.UltraTabPageControl2.Controls.Add(Me.lblPostBoxErstellen)
        Me.UltraTabPageControl2.Controls.Add(Me.lblGesamtesArchivLöschen)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(633, 452)
        '
        'txtPfad
        '
        Appearance32.BackColor = System.Drawing.Color.White
        Me.txtPfad.Appearance = Appearance32
        Me.txtPfad.BackColor = System.Drawing.Color.White
        Me.txtPfad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPfad.Location = New System.Drawing.Point(17, 39)
        Me.txtPfad.Multiline = True
        Me.txtPfad.Name = "txtPfad"
        Me.txtPfad.Size = New System.Drawing.Size(602, 58)
        Me.txtPfad.TabIndex = 0
        '
        'UltraButtonPfadSpeichern
        '
        Appearance80.Image = "ICO_speichern.ico"
        Appearance80.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.UltraButtonPfadSpeichern.Appearance = Appearance80
        Me.UltraButtonPfadSpeichern.Location = New System.Drawing.Point(512, 101)
        Me.UltraButtonPfadSpeichern.Name = "UltraButtonPfadSpeichern"
        Me.UltraButtonPfadSpeichern.Size = New System.Drawing.Size(107, 27)
        Me.UltraButtonPfadSpeichern.TabIndex = 2
        Me.UltraButtonPfadSpeichern.Text = "Pfad speichern"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 13)
        Me.Label1.TabIndex = 516
        Me.Label1.Text = "Archivpfad für Dokumentenablage am zentralen Server:"
        '
        'lblPfadAuswahlen
        '
        Appearance81.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance81.FontData.SizeInPoints = 9.0!
        Appearance81.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblPfadAuswahlen.Appearance = Appearance81
        Me.lblPfadAuswahlen.AutoSize = True
        Appearance82.FontData.UnderlineAsString = "True"
        Me.lblPfadAuswahlen.HotTrackAppearance = Appearance82
        Me.lblPfadAuswahlen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPfadAuswahlen.Location = New System.Drawing.Point(17, 101)
        Me.lblPfadAuswahlen.Name = "lblPfadAuswahlen"
        Me.lblPfadAuswahlen.Size = New System.Drawing.Size(73, 16)
        Me.lblPfadAuswahlen.TabIndex = 1
        Me.lblPfadAuswahlen.Text = "Pfad suchen"
        Me.lblPfadAuswahlen.UseAppStyling = False
        Me.lblPfadAuswahlen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblPostBoxErstellen
        '
        Appearance83.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance83.FontData.SizeInPoints = 9.0!
        Appearance83.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblPostBoxErstellen.Appearance = Appearance83
        Me.lblPostBoxErstellen.AutoSize = True
        Appearance84.FontData.UnderlineAsString = "True"
        Me.lblPostBoxErstellen.HotTrackAppearance = Appearance84
        Me.lblPostBoxErstellen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPostBoxErstellen.Location = New System.Drawing.Point(17, 216)
        Me.lblPostBoxErstellen.Name = "lblPostBoxErstellen"
        Me.lblPostBoxErstellen.Size = New System.Drawing.Size(192, 16)
        Me.lblPostBoxErstellen.TabIndex = 2
        Me.lblPostBoxErstellen.Text = "Postbox für alle Benutzer erstellen"
        Me.lblPostBoxErstellen.UseAppStyling = False
        Me.lblPostBoxErstellen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.lblPostBoxErstellen.Visible = False
        '
        'lblGesamtesArchivLöschen
        '
        Appearance85.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance85.FontData.SizeInPoints = 9.0!
        Appearance85.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblGesamtesArchivLöschen.Appearance = Appearance85
        Me.lblGesamtesArchivLöschen.AutoSize = True
        Appearance86.FontData.UnderlineAsString = "True"
        Me.lblGesamtesArchivLöschen.HotTrackAppearance = Appearance86
        Me.lblGesamtesArchivLöschen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGesamtesArchivLöschen.Location = New System.Drawing.Point(17, 194)
        Me.lblGesamtesArchivLöschen.Name = "lblGesamtesArchivLöschen"
        Me.lblGesamtesArchivLöschen.Size = New System.Drawing.Size(144, 16)
        Me.lblGesamtesArchivLöschen.TabIndex = 1
        Me.lblGesamtesArchivLöschen.Text = "Gesamtes Archiv löschen"
        Me.lblGesamtesArchivLöschen.UseAppStyling = False
        Me.lblGesamtesArchivLöschen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.lblGesamtesArchivLöschen.Visible = False
        '
        'CMenuOrdner
        '
        Me.CMenuOrdner.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MItemOrdnerNeu, Me.MItemOrdnerLöschen})
        '
        'MItemOrdnerNeu
        '
        Me.MItemOrdnerNeu.Index = 0
        Me.MItemOrdnerNeu.Text = "Neuen Ordner ..."
        '
        'MItemOrdnerLöschen
        '
        Me.MItemOrdnerLöschen.Index = 1
        Me.MItemOrdnerLöschen.Text = "Ordner löschen ..."
        '

        '
        'UTabStammdaten
        '
        Appearance3.BackColor = System.Drawing.Color.Gainsboro
        Me.UTabStammdaten.Appearance = Appearance3
        Me.UTabStammdaten.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UTabStammdaten.Controls.Add(Me.UTabPageSchrankFachOrdner)
        Me.UTabStammdaten.Controls.Add(Me.UTabPageSchlagwörter)
        Me.UTabStammdaten.Controls.Add(Me.UltraTabPageControl1)
        Me.UTabStammdaten.Controls.Add(Me.UltraTabPageControl2)
        Me.UTabStammdaten.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UTabStammdaten.Location = New System.Drawing.Point(0, 0)
        Me.UTabStammdaten.Name = "UTabStammdaten"
        Me.UTabStammdaten.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UTabStammdaten.Size = New System.Drawing.Size(637, 475)
        Me.UTabStammdaten.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UTabStammdaten.TabIndex = 5
        Appearance40.BackColor = System.Drawing.Color.WhiteSmoke
        UltraTab4.ClientAreaAppearance = Appearance40
        UltraTab4.Key = "Ordner"
        UltraTab4.TabPage = Me.UltraTabPageControl1
        UltraTab4.Text = "Ordner"
        Appearance41.BackColor = System.Drawing.Color.WhiteSmoke
        UltraTab1.ClientAreaAppearance = Appearance41
        UltraTab1.TabPage = Me.UTabPageSchrankFachOrdner
        UltraTab1.Text = "Schrank/Fach"
        Appearance42.BackColor = System.Drawing.Color.WhiteSmoke
        UltraTab2.ClientAreaAppearance = Appearance42
        UltraTab2.TabPage = Me.UTabPageSchlagwörter
        UltraTab2.Text = "Schlagwortkatolog"
        Appearance43.BackColor = System.Drawing.Color.WhiteSmoke
        UltraTab5.ClientAreaAppearance = Appearance43
        UltraTab5.Key = "Laufwerk"
        UltraTab5.TabPage = Me.UltraTabPageControl2
        UltraTab5.Text = "Archivpafad"
        Me.UTabStammdaten.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab4, UltraTab1, UltraTab2, UltraTab5})
        Me.UTabStammdaten.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(633, 452)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contStammdaten
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.UTabStammdaten)
        Me.Name = "contStammdaten"
        Me.Size = New System.Drawing.Size(637, 475)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGridBagLayoutPanel1.ResumeLayout(False)
        Me.UTabPageSchrankFachOrdner.ResumeLayout(False)
        CType(Me.UGridFächer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFachAnzeigeSuche1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UGridSchränke, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchrankAnzeigeSuche1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabPageSchlagwörter.ResumeLayout(False)
        CType(Me.UGridSchlagwörter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchlagwörterAnzeige1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UGridThemen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsThemenAnzeige1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.txtPfad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTabStammdaten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabStammdaten.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Stammdaten_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.UButtonSchränkeNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.UButtonFächerNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

            Me.UButtonSchlagwörterNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.UButtonThemaNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

            Me.UltraButtonPfadSpeichern.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.UButtonSchränkeSpeichern2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.UButtonThemaSpeichern2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub initForm()
        Try
            Me.LoadOrdnerIntoPanels()

            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.keiner
            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.keiner
            Me.UGridFächer.Enabled = False

            Me.TabSchränkeLaden()
            Me.TabThemenLaden()
            Me.pfadLesen()

        Catch ex As Exception
            Throw New Exception("initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdnerIntoPanels()
        Try
            Me.ContOrdner1.LoadOrdnerbaum(contOrdner.etyp.Verwaltung, Nothing)
            Me.ContOrdner1.resizeForVerwaltung()

        Catch ex As Exception
            Throw New Exception("LoadOrdnerIntoPanels: " + ex.ToString())
        End Try
    End Sub



    Public Sub TabSchränkeLaden()
        Try
            Me.TabFächerLeeren()
            Me.dsSchränke.Clear()
            Me.dsSchränke = Me.db_SchrFachOrd.LesenAlleSchränke()
            Me.UGridSchränke.DataSource = Me.dsSchränke.tblSchrank
            Me.UGridSchränke.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchränkeLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchränkeLeeren()
        Try

            Me.dsSchränke.Clear()
            Me.UGridSchränke.DataSource = Me.dsSchränke.tblSchrank
            Me.UGridSchränke.DataBind()
            Me.TabFächerLeeren()

        Catch ex As Exception
            Throw New Exception("TabSchränkeLeeren: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabFächerLaden()
        Try
            If gen.IsNull(Me.UGridSchränke.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridSchränke.ActiveRow.Cells("ID").Value) Then Exit Sub

            Me.dsFächer.Clear()
            Me.dsFächer = Me.db_SchrFachOrd.LesenAlleFächer(Me.UGridSchränke.ActiveRow.Cells("ID").Value)
            Me.UGridFächer.DataSource = Me.dsFächer.tblFach
            Me.UGridFächer.DataBind()

        Catch ex As Exception
            Throw New Exception("TabFächerLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabFächerLeeren()
        Try
            Me.dsFächer.Clear()
            Me.UGridFächer.DataSource = Me.dsFächer.tblFach
            Me.UGridFächer.DataBind()

        Catch ex As Exception
            Throw New Exception("TabFächerLeeren: " + ex.ToString())
        End Try
    End Sub

    Public Sub TabThemenLaden()
        Try
            Me.TabSchlagwörterLeeren()
            Me.dataThemen.tblThemen.Clear()
            Me.dataThemen = Me.db_ThemSchlag.LesenAllerThemen
            Me.UGridThemen.DataSource = Me.dataThemen.tblThemen
            Me.UGridThemen.DataBind()

        Catch ex As Exception
            Throw New Exception("TabThemenLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabThemenLeeren()
        Try
            Me.dataThemen.tblThemen.Clear()
            Me.UGridThemen.DataSource = Me.dataThemen.tblThemen
            Me.UGridThemen.DataBind()
            Me.TabSchlagwörterLeeren()

        Catch ex As Exception
            Throw New Exception("TabThemenLeeren: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchlagwörterLaden()
        Try
            If gen.IsNull(Me.UGridThemen.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then Exit Sub

            Me.dataSchlagwörter.tblSchlagwörter.Clear()
            Me.dataSchlagwörter = Me.db_ThemSchlag.LesenAlleSchlagwörter(Me.UGridThemen.ActiveRow.Cells("ID").Value)
            Me.UGridSchlagwörter.DataSource = Me.dataSchlagwörter.tblSchlagwörter
            Me.UGridSchlagwörter.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchlagwörterLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchlagwörterLeeren()
        Try
            Me.dataSchlagwörter.Clear()
            Me.UGridSchlagwörter.DataSource = Me.dataSchlagwörter.tblSchlagwörter
            Me.UGridSchlagwörter.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchlagwörterLeeren: " + ex.ToString())
        End Try
    End Sub

    Private Sub FächerEinAus()
        Try
            Me.TabFächerLeeren()

            If Not gen.IsNull(Me.UGridSchränke.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchränke.ActiveRow.Cells("ID").Value) Then
                    If Me.db_SchrFachOrd.ExistiertSchrank(Me.UGridSchränke.ActiveRow.Cells("ID").Value) Then
                        Me.UGridFächer.Enabled = True
                        Me.TabFächerLaden()
                    Else
                        Me.UGridFächer.Enabled = False
                        Me.TabFächerLeeren()
                    End If
                Else
                    Me.UGridFächer.Enabled = False
                    Me.TabFächerLeeren()
                End If
            Else
                Me.UGridFächer.Enabled = False
                Me.TabFächerLeeren()
            End If

        Catch ex As Exception
            Throw New Exception("FächerEinAus: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub OrdnerEinAus()
        Try
            If Not gen.IsNull(Me.UGridFächer.ActiveRow) Then
                If Not gen.IsNull(Me.UGridFächer.ActiveRow.Cells("ID").Value) Then
                    If Me.db_SchrFachOrd.ExistiertFach(Me.UGridFächer.ActiveRow.Cells("ID").Value) Then
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("OrdnerEinAus: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub SchlagwörterEinAus()
        Try
            Me.TabSchlagwörterLeeren()

            If Not gen.IsNull(Me.UGridThemen.ActiveRow) Then
                If Not gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                    If Me.db_ThemSchlag.ExistiertThema(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                        Me.UGridSchlagwörter.Enabled = True
                        Me.TabSchlagwörterLaden()
                    Else
                        Me.UGridSchlagwörter.Enabled = False
                        Me.TabSchlagwörterLeeren()
                    End If
                Else
                    Me.UGridSchlagwörter.Enabled = False
                    Me.TabSchlagwörterLeeren()
                End If
            Else
                Me.UGridSchlagwörter.Enabled = False
                Me.TabSchlagwörterLeeren()
            End If

        Catch ex As Exception
            Throw New Exception("SchlagwörterEinAus: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonOrdnerNeu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim NewRow As dsPlanArchive.tblOrdnerRow
            NewRow = Me.dsOrdner.tblOrdner.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Bezeichnung = ""
            NewRow.ErstelltAm = Now
            NewRow.ErstelltVon = usr.actUser
            NewRow.IDFach = Me.UGridFächer.ActiveRow.Cells("ID").Value
            Me.dsOrdner.tblOrdner.Rows.Add(NewRow)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UButtonOrdnerRückg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dsOrdner.tblOrdner.RejectChanges()
            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub UGridOrdner_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub
    Private Sub UTabPageSchlagwörter_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTabPageSchlagwörter.Paint

    End Sub
    Private Sub PanelFächer_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Private Sub UTabPageSchrankFachOrdner_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTabPageSchrankFachOrdner.Paint

    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl1.Paint

    End Sub


    Private Sub UGridSchränke_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridSchränke.InitializeLayout

    End Sub
    Private Sub UGridSchränke_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchränke.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.schränke
            Me.UGridSchränke.Selected.Rows.Clear()

            Me.UGridSchränke.Rows(Me.UGridSchränke.ActiveCell.Row.Index).Activated = True
            Me.UGridSchränke.ActiveRow.Selected = True
            Me.FächerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchränke_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchränke.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.schränke
            Me.FächerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchränke_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridSchränke.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub UGridFächer_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridFächer.InitializeLayout

    End Sub
    Private Sub UGridFächer_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridFächer.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.fächer
            Me.UGridFächer.Selected.Rows.Clear()

            Me.UGridFächer.Rows(Me.UGridFächer.ActiveCell.Row.Index).Activated = True
            Me.UGridFächer.ActiveRow.Selected = True
            Me.OrdnerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridFächer_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridFächer.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.fächer
            Me.OrdnerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridFächer_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridFächer.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub UGridThemen_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridThemen.InitializeLayout

    End Sub
    Private Sub UGridThemen_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridThemen.AfterCellActivate
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.thema
            Me.UGridThemen.Selected.Rows.Clear()
            Me.UGridThemen.Rows(Me.UGridThemen.ActiveCell.Row.Index).Activated = True
            Me.UGridThemen.ActiveRow.Selected = True
            Me.SchlagwörterEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridThemen_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridThemen.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.thema
            Me.SchlagwörterEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridThemen_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridThemen.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub UGridSchlagwörter_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridSchlagwörter.InitializeLayout

    End Sub
    Private Sub UGridSchlagwörter_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchlagwörter.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.schlagwörter
            Me.UGridSchlagwörter.Selected.Rows.Clear()
            Me.UGridSchlagwörter.Rows(Me.UGridSchlagwörter.ActiveCell.Row.Index).Activated = True
            Me.UGridSchlagwörter.ActiveRow.Selected = True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchlagwörter_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridSchlagwörter.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub UTreeOrdner_AfterSelect_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs)
        Try

            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_AfterLabelEdit1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(e.TreeNode) Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = e.TreeNode.Tag

            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UTreeOrdner_BeforeLabelEdit1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.CancelableNodeEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(e.TreeNode) Then
                Dim clTag As New clTagSchrankFachOrdner
                clTag = e.TreeNode.Tag
                If clTag.typ <> clTagSchrankFachOrdner.eTyp.typOrdner Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub UltraTabPageControl2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl2.Paint

    End Sub

    Private Sub Stammdaten_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim gen As New GeneralArchiv
        Try

            'Me.ResizeControl(Me.Height, Me.Width)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Public Sub ResizeControlxy(ByVal h As Double, ByVal w As Double)
        Dim gen As New GeneralArchiv
        Try


        Catch ex As Exception
            Throw New Exception("ResizeControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub BUTT_Schrank_Neu()
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim NewRow As dsPlanArchive.tblSchrankRow
            NewRow = Me.dsSchränke.tblSchrank.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Bezeichnung = ""
            NewRow.ErstelltAm = Now
            NewRow.Extern = False
            NewRow.ErstelltVon = usr.actUser
            Me.dsSchränke.tblSchrank.Rows.Add(NewRow)

            Me.UGridSchränke.ActiveRow = Me.UGridSchränke.Rows(Me.UGridSchränke.Rows.Count - 1)
            Me.UGridSchränke.ActiveRow.Cells("Bezeichnung").Activate()
            Me.UGridSchränke.ActiveRow.Cells("Bezeichnung").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schrank_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblSchrankRow In Me.dsSchränke.tblSchrank
                If gen.IsNull(r.Bezeichnung) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.SchränkeSpeichern(Me.dsSchränke)

            Me.TabFächerLeeren()
            Me.TabSchränkeLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schrank_Löschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridSchränke.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchränke.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie den Schrank wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteSchrank(Me.UGridSchränke.ActiveRow.Cells("ID").Value)
                        Me.TabSchränkeLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Der Schrank wurde gelöscht!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_Löschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BUTT_Fach_Neu()
        Try

            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.UGridSchränke.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridSchränke.ActiveRow.Cells("ID").Value) Then Exit Sub

            Dim NewRow As dsPlanArchive.tblFachRow
            NewRow = Me.dsFächer.tblFach.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Bezeichnung = ""
            NewRow.ErstelltAm = Now
            NewRow.Extern = False
            NewRow.IDSchrank = Me.UGridSchränke.ActiveRow.Cells("ID").Value
            NewRow.ErstelltVon = usr.actUser
            Me.dsFächer.tblFach.Rows.Add(NewRow)

            Me.UGridFächer.ActiveRow = Me.UGridFächer.Rows(Me.UGridFächer.Rows.Count - 1)
            Me.UGridFächer.ActiveRow.Cells("Bezeichnung").Activate()
            Me.UGridFächer.ActiveRow.Cells("Bezeichnung").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Fach_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblFachRow In Me.dsFächer.tblFach
                If gen.IsNull(r.Bezeichnung) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.FächerSpeichern(Me.dsFächer)

            Me.TabFächerLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Fach_Löschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridFächer.ActiveRow) Then
                If Not gen.IsNull(Me.UGridFächer.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Fach wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteFächer(Me.UGridFächer.ActiveRow.Cells("ID").Value)
                        Me.TabFächerLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte wählen Sie ein Fach aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_Löschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub




    Private Sub BUTT_Thema_Neu()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim NewRow As dsPlanArchive.tblThemenRow
            NewRow = Me.dataThemen.tblThemen.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Thema = ""
            NewRow.ErstelltAm = Now
            NewRow.ErstelltVon = usr.actUser
            Me.dataThemen.tblThemen.Rows.Add(NewRow)

            Me.UGridThemen.ActiveRow = Me.UGridThemen.Rows(Me.UGridThemen.Rows.Count - 1)
            Me.UGridThemen.ActiveRow.Cells("Thema").Activate()
            Me.UGridThemen.ActiveRow.Cells("Thema").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Thema_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Thema_Speichern()
        Try

            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblThemenRow In Me.dataThemen.tblThemen
                If gen.IsNull(r.Thema) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.ThemaSpeichern(Me.dataThemen)

            Me.TabSchlagwörterLeeren()
            Me.TabThemenLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Thema_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Thema_Löschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridThemen.ActiveRow) Then
                If Not gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Thema wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteThema(Me.UGridThemen.ActiveRow.Cells("ID").Value)
                        Me.TabThemenLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte wählen Sie ein Thema aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Thema_Löschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BUTT_Schlagwort_Neu()
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.UGridThemen.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then Exit Sub

            Dim NewRow As dsPlanArchive.tblSchlagwörterRow
            NewRow = Me.dataSchlagwörter.tblSchlagwörter.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Schlagwort = ""
            NewRow.ErstelltAm = Now
            NewRow.IDThema = Me.UGridThemen.ActiveRow.Cells("ID").Value
            NewRow.ErstelltVon = usr.actUser
            Me.dataSchlagwörter.tblSchlagwörter.Rows.Add(NewRow)

            Me.UGridSchlagwörter.ActiveRow = Me.UGridSchlagwörter.Rows(Me.UGridSchlagwörter.Rows.Count - 1)
            Me.UGridSchlagwörter.ActiveRow.Cells("Schlagwort").Activate()
            Me.UGridSchlagwörter.ActiveRow.Cells("Schlagwort").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schlagwort_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblSchlagwörterRow In Me.dataSchlagwörter.tblSchlagwörter
                If gen.IsNull(r.Schlagwort) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.SchlagwörterSpeichern(Me.dataSchlagwörter)

            Me.TabSchlagwörterLaden()
            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schlagwort_Löschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridSchlagwörter.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchlagwörter.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Schlagwort wirklich löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteSchlagwort(Me.UGridSchlagwörter.ActiveRow.Cells("ID").Value)
                        Me.TabSchlagwörterLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte wählen Sie ein Schlagwort aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_Löschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub PanelOrdnerStammdaten_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PanelOrdnerStammdaten_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Private Sub PanelOrdnerStammdaten_Resize(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub





    Private Sub lblGesamtesArchivLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGesamtesArchivLöschen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If MsgBox("Wollen Sie wirklich das gesamte Archivsystem löschen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                Dim cl As New cArchive()
                cl.ClearDatabaseArchiv()
                MsgBox("Das Archivsystem wurde gelöscht!", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lblPostBoxErstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPostBoxErstellen.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Dim genMain As New General
            'genMain.PostboxAlleBenutzerErstellen()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub pfadLesen()
        Try
            Dim comp As New compSql
            Me.txtPfad.Text = comp.pfadLesen()

        Catch ex As Exception
            Throw New Exception("pfadLesen: " + ex.ToString())
        Finally
        End Try
    End Sub
    Private Sub UltraButtonPfadSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonPfadSpeichern.Click
        Try
            Dim comp As New compSql
            If Not gen.IsNull(Me.txtPfad.Text) Then
                comp.WritePfad(Me.txtPfad.Text)
                MsgBox("Der Pfad wurde gespeichert!", MsgBoxStyle.Information, "Archivsystem")
            Else
                MsgBox("Es wurde kein Pfad angebenen!", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Private Sub lblPfadAuswahlen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPfadAuswahlen.Click
        Try

            FolderBrowserDialog.ShowDialog()
            If Not gen.IsNull(FolderBrowserDialog.SelectedPath) Then
                Dim comp As New compSql
                If Not gen.IsNull(FolderBrowserDialog.SelectedPath) Then
                    Me.txtPfad.Text = FolderBrowserDialog.SelectedPath
                Else
                    MsgBox("Es wurde kein Pfad angebenen!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Private Sub UButtonSchränkeSpeichern2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchränkeSpeichern2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.schränke Then
                Me.BUTT_Schrank_Speichern()
            ElseIf Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.fächer Then
                Me.BUTT_Fach_Speichern()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchränkeNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchränkeNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.schränke
            Me.BUTT_Schrank_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchränkeLöschen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchränkeLöschen2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.schränke Then
                Me.BUTT_Schrank_Löschen()
            ElseIf Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.fächer Then
                Me.BUTT_Fach_Löschen()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonFächerNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonFächerNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_SchränkeFächer = TableIsActive_SchränkeFächer.fächer
            Me.BUTT_Fach_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonThemaNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonThemaNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.thema
            Me.BUTT_Thema_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonThemaLöschen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonThemaLöschen2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.thema Then
                Me.BUTT_Thema_Löschen()
            ElseIf Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.schlagwörter Then
                Me.BUTT_Schlagwort_Löschen()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchlagwörterNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchlagwörterNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.schlagwörter
            Me.BUTT_Schlagwort_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonThemaSpeichern2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonThemaSpeichern2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.thema Then
                Me.BUTT_Thema_Speichern()
            ElseIf Me.tableActive_Schlagwörter = TableIsActive_Schlagwörter.schlagwörter Then
                Me.BUTT_Schlagwort_Speichern()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UTabStammdaten_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UTabStammdaten.SelectedTabChanged
        Try
            If Me.UTabStammdaten.Focused Then
                Me.Cursor = Cursors.WaitCursor

                Select Case e.Tab.Index
                    Case 0
                        Me.ContOrdner1.Load_SchränkeFächer(contOrdner.etyp.Verwaltung, Nothing)
                    Case 1
                        Me.TabSchränkeLaden()
                    Case 2
                        Me.TabThemenLaden()
                    Case 3
                        Me.pfadLesen()
                End Select

            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
