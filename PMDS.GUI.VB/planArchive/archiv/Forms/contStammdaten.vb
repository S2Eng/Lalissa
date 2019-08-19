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
    Private dsSchr�nke As New dsPlanArchive
    Private dsF�cher As New dsPlanArchive
    Private dsOrdner As New dsPlanArchive

    Private db_ThemSchlag As New compSql
    Private dataThemen As New dsPlanArchive
    Private dataSchlagw�rter As New dsPlanArchive

    Private TypObjekt_NextID As Integer = 0

    Public mainForm As frmStammdaten
    Private usr As New GeneralArchiv



    Public tableActive_Schr�nkeF�cher As New TableIsActive_Schr�nkeF�cher
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblPfadAuswahlen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPostBoxErstellen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblGesamtesArchivL�schen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraButtonPfadSpeichern As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtPfad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UButtonSchr�nkeSpeichern2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonF�cherNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchr�nkeL�schen2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchr�nkeNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaSpeichern2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonSchlagw�rterNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaL�schen2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UButtonThemaNeu2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridBagLayoutPanel1 As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents ContOrdner1 As contOrdner
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Public Enum TableIsActive_Schr�nkeF�cher
        schr�nke = 0
        f�cher = 1
        keiner = 10
    End Enum

    Public tableActive_Schlagw�rter As New TableIsActive_Schlagw�rter
    Public Enum TableIsActive_Schlagw�rter
        schlagw�rter = 0
        thema = 1
        keiner = 10
    End Enum


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf�gen

    End Sub

    ' Die Form �berschreibt den L�schvorgang der Basisklasse, um Komponenten zu bereinigen.
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

    'HINWEIS: Die folgende Prozedur ist f�r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UTabPageSchrankFachOrdner As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UTabPageSchlagw�rter As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UTabStammdaten As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents DsThemenAnzeige1 As dsPlanArchive
    Friend WithEvents DsSchlagw�rterAnzeige1 As dsPlanArchive
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CMenuOrdner As System.Windows.Forms.ContextMenu
    Friend WithEvents MItemOrdnerNeu As System.Windows.Forms.MenuItem
    Friend WithEvents MItemOrdnerL�schen As System.Windows.Forms.MenuItem
    Friend WithEvents UGridSchr�nke As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridThemen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UGridSchlagw�rter As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DsSchrankAnzeigeSuche1 As dsPlanArchive
    Friend WithEvents UGridF�cher As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DsFachAnzeigeSuche1 As dsPlanArchive
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo7 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzuf�gen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contStammdaten))
        Dim UltraToolTipInfo8 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo9 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzuf�gen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
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
        Dim UltraToolTipInfo10 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzuf�gen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo11 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo12 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzuf�gen", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblSchlagw�rter", -1)
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
        Me.UButtonSchr�nkeSpeichern2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonF�cherNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchr�nkeL�schen2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchr�nkeNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UGridF�cher = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsFachAnzeigeSuche1 = New dsPlanArchive()
        Me.UGridSchr�nke = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsSchrankAnzeigeSuche1 = New dsPlanArchive()
        Me.UTabPageSchlagw�rter = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UButtonThemaSpeichern2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonSchlagw�rterNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonThemaL�schen2 = New Infragistics.Win.Misc.UltraButton()
        Me.UButtonThemaNeu2 = New Infragistics.Win.Misc.UltraButton()
        Me.UGridSchlagw�rter = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsSchlagw�rterAnzeige1 = New dsPlanArchive()
        Me.UGridThemen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsThemenAnzeige1 = New dsPlanArchive()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtPfad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraButtonPfadSpeichern = New Infragistics.Win.Misc.UltraButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPfadAuswahlen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPostBoxErstellen = New Infragistics.Win.Misc.UltraLabel()
        Me.lblGesamtesArchivL�schen = New Infragistics.Win.Misc.UltraLabel()
        Me.CMenuOrdner = New System.Windows.Forms.ContextMenu()
        Me.MItemOrdnerNeu = New System.Windows.Forms.MenuItem()
        Me.MItemOrdnerL�schen = New System.Windows.Forms.MenuItem()
        Me.UTabStammdaten = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridBagLayoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGridBagLayoutPanel1.SuspendLayout()
        Me.UTabPageSchrankFachOrdner.SuspendLayout()
        CType(Me.UGridF�cher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFachAnzeigeSuche1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UGridSchr�nke, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchrankAnzeigeSuche1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabPageSchlagw�rter.SuspendLayout()
        CType(Me.UGridSchlagw�rter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchlagw�rterAnzeige1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchr�nkeSpeichern2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonF�cherNeu2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchr�nkeL�schen2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UButtonSchr�nkeNeu2)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UGridF�cher)
        Me.UTabPageSchrankFachOrdner.Controls.Add(Me.UGridSchr�nke)
        Me.UTabPageSchrankFachOrdner.Location = New System.Drawing.Point(-10000, -10000)
        Me.UTabPageSchrankFachOrdner.Name = "UTabPageSchrankFachOrdner"
        Me.UTabPageSchrankFachOrdner.Size = New System.Drawing.Size(633, 452)
        '
        'UButtonSchr�nkeSpeichern2
        '
        Appearance72.Image = "ICO_speichern.ico"
        Appearance72.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.UButtonSchr�nkeSpeichern2.Appearance = Appearance72
        Me.UButtonSchr�nkeSpeichern2.Location = New System.Drawing.Point(442, 421)
        Me.UButtonSchr�nkeSpeichern2.Name = "UButtonSchr�nkeSpeichern2"
        Me.UButtonSchr�nkeSpeichern2.Size = New System.Drawing.Size(85, 27)
        Me.UButtonSchr�nkeSpeichern2.TabIndex = 238
        Me.UButtonSchr�nkeSpeichern2.Text = "Speichern"
        '
        'UButtonF�cherNeu2
        '
        Appearance73.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonF�cherNeu2.Appearance = Appearance73
        Me.UButtonF�cherNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonF�cherNeu2.Location = New System.Drawing.Point(501, 12)
        Me.UButtonF�cherNeu2.Name = "UButtonF�cherNeu2"
        Me.UButtonF�cherNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonF�cherNeu2.TabIndex = 237
        UltraToolTipInfo7.ToolTipText = "Hinzuf�gen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonF�cherNeu2, UltraToolTipInfo7)
        '
        'UButtonSchr�nkeL�schen2
        '
        Appearance74.Image = CType(resources.GetObject("Appearance74.Image"), Object)
        Appearance74.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonSchr�nkeL�schen2.Appearance = Appearance74
        Me.UButtonSchr�nkeL�schen2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchr�nkeL�schen2.Location = New System.Drawing.Point(314, 12)
        Me.UButtonSchr�nkeL�schen2.Name = "UButtonSchr�nkeL�schen2"
        Me.UButtonSchr�nkeL�schen2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchr�nkeL�schen2.TabIndex = 236
        UltraToolTipInfo8.ToolTipText = "Entfernen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchr�nkeL�schen2, UltraToolTipInfo8)
        '
        'UButtonSchr�nkeNeu2
        '
        Appearance75.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UButtonSchr�nkeNeu2.Appearance = Appearance75
        Me.UButtonSchr�nkeNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchr�nkeNeu2.Location = New System.Drawing.Point(292, 12)
        Me.UButtonSchr�nkeNeu2.Name = "UButtonSchr�nkeNeu2"
        Me.UButtonSchr�nkeNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchr�nkeNeu2.TabIndex = 235
        UltraToolTipInfo9.ToolTipText = "Hinzuf�gen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchr�nkeNeu2, UltraToolTipInfo9)
        '
        'UGridF�cher
        '
        Me.UGridF�cher.DataSource = Me.DsFachAnzeigeSuche1.tblFach
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridF�cher.DisplayLayout.Appearance = Appearance46
        Me.UGridF�cher.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 68
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn31.Header.Caption = "F�cher"
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
        Me.UGridF�cher.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.UGridF�cher.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridF�cher.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance48.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance48.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridF�cher.DisplayLayout.GroupByBox.Appearance = Appearance48
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridF�cher.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance49
        Me.UGridF�cher.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance50.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance50.BackColor2 = System.Drawing.SystemColors.Control
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridF�cher.DisplayLayout.GroupByBox.PromptAppearance = Appearance50
        Me.UGridF�cher.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridF�cher.DisplayLayout.MaxRowScrollRegions = 1
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridF�cher.DisplayLayout.Override.ActiveCellAppearance = Appearance51
        Appearance52.BackColor = System.Drawing.SystemColors.Highlight
        Appearance52.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridF�cher.DisplayLayout.Override.ActiveRowAppearance = Appearance52
        Me.UGridF�cher.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridF�cher.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Me.UGridF�cher.DisplayLayout.Override.CardAreaAppearance = Appearance53
        Appearance54.BorderColor = System.Drawing.Color.Silver
        Appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridF�cher.DisplayLayout.Override.CellAppearance = Appearance54
        Me.UGridF�cher.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridF�cher.DisplayLayout.Override.CellPadding = 0
        Appearance55.BackColor = System.Drawing.SystemColors.Control
        Appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridF�cher.DisplayLayout.Override.GroupByRowAppearance = Appearance55
        Appearance56.TextHAlignAsString = "Left"
        Me.UGridF�cher.DisplayLayout.Override.HeaderAppearance = Appearance56
        Me.UGridF�cher.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridF�cher.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance57.BackColor = System.Drawing.SystemColors.Window
        Appearance57.BorderColor = System.Drawing.Color.Silver
        Me.UGridF�cher.DisplayLayout.Override.RowAppearance = Appearance57
        Me.UGridF�cher.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance58.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridF�cher.DisplayLayout.Override.TemplateAddRowAppearance = Appearance58
        Me.UGridF�cher.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridF�cher.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridF�cher.Location = New System.Drawing.Point(345, 10)
        Me.UGridF�cher.Name = "UGridF�cher"
        Me.UGridF�cher.Size = New System.Drawing.Size(182, 410)
        Me.UGridF�cher.TabIndex = 1
        '
        'DsFachAnzeigeSuche1
        '
        Me.DsFachAnzeigeSuche1.DataSetName = "dsFachAnzeigeSuche"
        Me.DsFachAnzeigeSuche1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsFachAnzeigeSuche1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UGridSchr�nke
        '
        Me.UGridSchr�nke.DataSource = Me.DsSchrankAnzeigeSuche1.tblSchrank
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchr�nke.DisplayLayout.Appearance = Appearance59
        Me.UGridSchr�nke.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn36.Header.VisiblePosition = 1
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 103
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn37.Header.Caption = "Schr�nke"
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
        Me.UGridSchr�nke.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.UGridSchr�nke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchr�nke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance61.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchr�nke.DisplayLayout.GroupByBox.Appearance = Appearance61
        Appearance62.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchr�nke.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance62
        Me.UGridSchr�nke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance63.BackColor2 = System.Drawing.SystemColors.Control
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchr�nke.DisplayLayout.GroupByBox.PromptAppearance = Appearance63
        Me.UGridSchr�nke.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchr�nke.DisplayLayout.MaxRowScrollRegions = 1
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Appearance64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchr�nke.DisplayLayout.Override.ActiveCellAppearance = Appearance64
        Appearance65.BackColor = System.Drawing.SystemColors.Highlight
        Appearance65.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridSchr�nke.DisplayLayout.Override.ActiveRowAppearance = Appearance65
        Me.UGridSchr�nke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchr�nke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchr�nke.DisplayLayout.Override.CardAreaAppearance = Appearance66
        Appearance67.BorderColor = System.Drawing.Color.Silver
        Appearance67.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchr�nke.DisplayLayout.Override.CellAppearance = Appearance67
        Me.UGridSchr�nke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchr�nke.DisplayLayout.Override.CellPadding = 0
        Appearance68.BackColor = System.Drawing.SystemColors.Control
        Appearance68.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance68.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance68.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchr�nke.DisplayLayout.Override.GroupByRowAppearance = Appearance68
        Appearance69.TextHAlignAsString = "Left"
        Me.UGridSchr�nke.DisplayLayout.Override.HeaderAppearance = Appearance69
        Me.UGridSchr�nke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchr�nke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchr�nke.DisplayLayout.Override.RowAppearance = Appearance70
        Me.UGridSchr�nke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchr�nke.DisplayLayout.Override.TemplateAddRowAppearance = Appearance71
        Me.UGridSchr�nke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchr�nke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridSchr�nke.Location = New System.Drawing.Point(159, 10)
        Me.UGridSchr�nke.Name = "UGridSchr�nke"
        Me.UGridSchr�nke.Size = New System.Drawing.Size(182, 410)
        Me.UGridSchr�nke.TabIndex = 0
        '
        'DsSchrankAnzeigeSuche1
        '
        Me.DsSchrankAnzeigeSuche1.DataSetName = "dsSchrankAnzeigeSuche"
        Me.DsSchrankAnzeigeSuche1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsSchrankAnzeigeSuche1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UTabPageSchlagw�rter
        '
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UButtonThemaSpeichern2)
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UButtonSchlagw�rterNeu2)
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UButtonThemaL�schen2)
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UButtonThemaNeu2)
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UGridSchlagw�rter)
        Me.UTabPageSchlagw�rter.Controls.Add(Me.UGridThemen)
        Me.UTabPageSchlagw�rter.Location = New System.Drawing.Point(-10000, -10000)
        Me.UTabPageSchlagw�rter.Name = "UTabPageSchlagw�rter"
        Me.UTabPageSchlagw�rter.Size = New System.Drawing.Size(633, 452)
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
        'UButtonSchlagw�rterNeu2
        '
        Appearance77.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance77.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UButtonSchlagw�rterNeu2.Appearance = Appearance77
        Me.UButtonSchlagw�rterNeu2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonSchlagw�rterNeu2.Location = New System.Drawing.Point(501, 12)
        Me.UButtonSchlagw�rterNeu2.Name = "UButtonSchlagw�rterNeu2"
        Me.UButtonSchlagw�rterNeu2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonSchlagw�rterNeu2.TabIndex = 241
        UltraToolTipInfo10.ToolTipText = "Hinzuf�gen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonSchlagw�rterNeu2, UltraToolTipInfo10)
        '
        'UButtonThemaL�schen2
        '
        Appearance78.Image = CType(resources.GetObject("Appearance78.Image"), Object)
        Appearance78.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance78.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UButtonThemaL�schen2.Appearance = Appearance78
        Me.UButtonThemaL�schen2.ImageSize = New System.Drawing.Size(12, 12)
        Me.UButtonThemaL�schen2.Location = New System.Drawing.Point(314, 12)
        Me.UButtonThemaL�schen2.Name = "UButtonThemaL�schen2"
        Me.UButtonThemaL�schen2.Size = New System.Drawing.Size(22, 20)
        Me.UButtonThemaL�schen2.TabIndex = 240
        UltraToolTipInfo11.ToolTipText = "Entfernen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonThemaL�schen2, UltraToolTipInfo11)
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
        UltraToolTipInfo12.ToolTipText = "Hinzuf�gen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UButtonThemaNeu2, UltraToolTipInfo12)
        '
        'UGridSchlagw�rter
        '
        Me.UGridSchlagw�rter.DataSource = Me.DsSchlagw�rterAnzeige1.tblSchlagw�rter
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchlagw�rter.DisplayLayout.Appearance = Appearance8
        Me.UGridSchlagw�rter.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
        Me.UGridSchlagw�rter.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UGridSchlagw�rter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchlagw�rter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagw�rter.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagw�rter.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.UGridSchlagw�rter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagw�rter.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.UGridSchlagw�rter.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchlagw�rter.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchlagw�rter.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UGridSchlagw�rter.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.UGridSchlagw�rter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchlagw�rter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagw�rter.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchlagw�rter.DisplayLayout.Override.CellAppearance = Appearance15
        Me.UGridSchlagw�rter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchlagw�rter.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagw�rter.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.UGridSchlagw�rter.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.UGridSchlagw�rter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchlagw�rter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchlagw�rter.DisplayLayout.Override.RowAppearance = Appearance18
        Me.UGridSchlagw�rter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchlagw�rter.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.UGridSchlagw�rter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchlagw�rter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridSchlagw�rter.Location = New System.Drawing.Point(345, 10)
        Me.UGridSchlagw�rter.Name = "UGridSchlagw�rter"
        Me.UGridSchlagw�rter.Size = New System.Drawing.Size(182, 410)
        Me.UGridSchlagw�rter.TabIndex = 1
        Me.UGridSchlagw�rter.Text = "UltraGrid1"
        '
        'DsSchlagw�rterAnzeige1
        '
        Me.DsSchlagw�rterAnzeige1.DataSetName = "dsSchlagw�rterAnzeige"
        Me.DsSchlagw�rterAnzeige1.Locale = New System.Globalization.CultureInfo("de-DE")
        Me.DsSchlagw�rterAnzeige1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.UltraTabPageControl2.Controls.Add(Me.lblGesamtesArchivL�schen)
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
        Me.Label1.Text = "Archivpfad f�r Dokumentenablage am zentralen Server:"
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
        Me.lblPostBoxErstellen.Text = "Postbox f�r alle Benutzer erstellen"
        Me.lblPostBoxErstellen.UseAppStyling = False
        Me.lblPostBoxErstellen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.lblPostBoxErstellen.Visible = False
        '
        'lblGesamtesArchivL�schen
        '
        Appearance85.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance85.FontData.SizeInPoints = 9.0!
        Appearance85.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblGesamtesArchivL�schen.Appearance = Appearance85
        Me.lblGesamtesArchivL�schen.AutoSize = True
        Appearance86.FontData.UnderlineAsString = "True"
        Me.lblGesamtesArchivL�schen.HotTrackAppearance = Appearance86
        Me.lblGesamtesArchivL�schen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGesamtesArchivL�schen.Location = New System.Drawing.Point(17, 194)
        Me.lblGesamtesArchivL�schen.Name = "lblGesamtesArchivL�schen"
        Me.lblGesamtesArchivL�schen.Size = New System.Drawing.Size(144, 16)
        Me.lblGesamtesArchivL�schen.TabIndex = 1
        Me.lblGesamtesArchivL�schen.Text = "Gesamtes Archiv l�schen"
        Me.lblGesamtesArchivL�schen.UseAppStyling = False
        Me.lblGesamtesArchivL�schen.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.lblGesamtesArchivL�schen.Visible = False
        '
        'CMenuOrdner
        '
        Me.CMenuOrdner.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MItemOrdnerNeu, Me.MItemOrdnerL�schen})
        '
        'MItemOrdnerNeu
        '
        Me.MItemOrdnerNeu.Index = 0
        Me.MItemOrdnerNeu.Text = "Neuen Ordner ..."
        '
        'MItemOrdnerL�schen
        '
        Me.MItemOrdnerL�schen.Index = 1
        Me.MItemOrdnerL�schen.Text = "Ordner l�schen ..."
        '

        '
        'UTabStammdaten
        '
        Appearance3.BackColor = System.Drawing.Color.Gainsboro
        Me.UTabStammdaten.Appearance = Appearance3
        Me.UTabStammdaten.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UTabStammdaten.Controls.Add(Me.UTabPageSchrankFachOrdner)
        Me.UTabStammdaten.Controls.Add(Me.UTabPageSchlagw�rter)
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
        UltraTab2.TabPage = Me.UTabPageSchlagw�rter
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
        CType(Me.UGridF�cher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFachAnzeigeSuche1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UGridSchr�nke, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchrankAnzeigeSuche1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabPageSchlagw�rter.ResumeLayout(False)
        CType(Me.UGridSchlagw�rter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchlagw�rterAnzeige1, System.ComponentModel.ISupportInitialize).EndInit()
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
            Me.UButtonSchr�nkeNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.UButtonF�cherNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

            Me.UButtonSchlagw�rterNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.UButtonThemaNeu2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

            Me.UltraButtonPfadSpeichern.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.UButtonSchr�nkeSpeichern2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.UButtonThemaSpeichern2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub initForm()
        Try
            Me.LoadOrdnerIntoPanels()

            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.keiner
            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.keiner
            Me.UGridF�cher.Enabled = False

            Me.TabSchr�nkeLaden()
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



    Public Sub TabSchr�nkeLaden()
        Try
            Me.TabF�cherLeeren()
            Me.dsSchr�nke.Clear()
            Me.dsSchr�nke = Me.db_SchrFachOrd.LesenAlleSchr�nke()
            Me.UGridSchr�nke.DataSource = Me.dsSchr�nke.tblSchrank
            Me.UGridSchr�nke.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchr�nkeLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchr�nkeLeeren()
        Try

            Me.dsSchr�nke.Clear()
            Me.UGridSchr�nke.DataSource = Me.dsSchr�nke.tblSchrank
            Me.UGridSchr�nke.DataBind()
            Me.TabF�cherLeeren()

        Catch ex As Exception
            Throw New Exception("TabSchr�nkeLeeren: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabF�cherLaden()
        Try
            If gen.IsNull(Me.UGridSchr�nke.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value) Then Exit Sub

            Me.dsF�cher.Clear()
            Me.dsF�cher = Me.db_SchrFachOrd.LesenAlleF�cher(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value)
            Me.UGridF�cher.DataSource = Me.dsF�cher.tblFach
            Me.UGridF�cher.DataBind()

        Catch ex As Exception
            Throw New Exception("TabF�cherLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabF�cherLeeren()
        Try
            Me.dsF�cher.Clear()
            Me.UGridF�cher.DataSource = Me.dsF�cher.tblFach
            Me.UGridF�cher.DataBind()

        Catch ex As Exception
            Throw New Exception("TabF�cherLeeren: " + ex.ToString())
        End Try
    End Sub

    Public Sub TabThemenLaden()
        Try
            Me.TabSchlagw�rterLeeren()
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
            Me.TabSchlagw�rterLeeren()

        Catch ex As Exception
            Throw New Exception("TabThemenLeeren: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchlagw�rterLaden()
        Try
            If gen.IsNull(Me.UGridThemen.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then Exit Sub

            Me.dataSchlagw�rter.tblSchlagw�rter.Clear()
            Me.dataSchlagw�rter = Me.db_ThemSchlag.LesenAlleSchlagw�rter(Me.UGridThemen.ActiveRow.Cells("ID").Value)
            Me.UGridSchlagw�rter.DataSource = Me.dataSchlagw�rter.tblSchlagw�rter
            Me.UGridSchlagw�rter.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchlagw�rterLaden: " + ex.ToString())
        End Try
    End Sub
    Public Sub TabSchlagw�rterLeeren()
        Try
            Me.dataSchlagw�rter.Clear()
            Me.UGridSchlagw�rter.DataSource = Me.dataSchlagw�rter.tblSchlagw�rter
            Me.UGridSchlagw�rter.DataBind()

        Catch ex As Exception
            Throw New Exception("TabSchlagw�rterLeeren: " + ex.ToString())
        End Try
    End Sub

    Private Sub F�cherEinAus()
        Try
            Me.TabF�cherLeeren()

            If Not gen.IsNull(Me.UGridSchr�nke.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value) Then
                    If Me.db_SchrFachOrd.ExistiertSchrank(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value) Then
                        Me.UGridF�cher.Enabled = True
                        Me.TabF�cherLaden()
                    Else
                        Me.UGridF�cher.Enabled = False
                        Me.TabF�cherLeeren()
                    End If
                Else
                    Me.UGridF�cher.Enabled = False
                    Me.TabF�cherLeeren()
                End If
            Else
                Me.UGridF�cher.Enabled = False
                Me.TabF�cherLeeren()
            End If

        Catch ex As Exception
            Throw New Exception("F�cherEinAus: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub OrdnerEinAus()
        Try
            If Not gen.IsNull(Me.UGridF�cher.ActiveRow) Then
                If Not gen.IsNull(Me.UGridF�cher.ActiveRow.Cells("ID").Value) Then
                    If Me.db_SchrFachOrd.ExistiertFach(Me.UGridF�cher.ActiveRow.Cells("ID").Value) Then
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("OrdnerEinAus: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Schlagw�rterEinAus()
        Try
            Me.TabSchlagw�rterLeeren()

            If Not gen.IsNull(Me.UGridThemen.ActiveRow) Then
                If Not gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                    If Me.db_ThemSchlag.ExistiertThema(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                        Me.UGridSchlagw�rter.Enabled = True
                        Me.TabSchlagw�rterLaden()
                    Else
                        Me.UGridSchlagw�rter.Enabled = False
                        Me.TabSchlagw�rterLeeren()
                    End If
                Else
                    Me.UGridSchlagw�rter.Enabled = False
                    Me.TabSchlagw�rterLeeren()
                End If
            Else
                Me.UGridSchlagw�rter.Enabled = False
                Me.TabSchlagw�rterLeeren()
            End If

        Catch ex As Exception
            Throw New Exception("Schlagw�rterEinAus: " + ex.ToString())
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
            NewRow.IDFach = Me.UGridF�cher.ActiveRow.Cells("ID").Value
            Me.dsOrdner.tblOrdner.Rows.Add(NewRow)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UButtonOrdnerR�ckg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub UTabPageSchlagw�rter_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTabPageSchlagw�rter.Paint

    End Sub
    Private Sub PanelF�cher_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Private Sub UTabPageSchrankFachOrdner_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTabPageSchrankFachOrdner.Paint

    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl1.Paint

    End Sub


    Private Sub UGridSchr�nke_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridSchr�nke.InitializeLayout

    End Sub
    Private Sub UGridSchr�nke_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchr�nke.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.schr�nke
            Me.UGridSchr�nke.Selected.Rows.Clear()

            Me.UGridSchr�nke.Rows(Me.UGridSchr�nke.ActiveCell.Row.Index).Activated = True
            Me.UGridSchr�nke.ActiveRow.Selected = True
            Me.F�cherEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchr�nke_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchr�nke.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.schr�nke
            Me.F�cherEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchr�nke_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridSchr�nke.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub UGridF�cher_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridF�cher.InitializeLayout

    End Sub
    Private Sub UGridF�cher_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridF�cher.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.f�cher
            Me.UGridF�cher.Selected.Rows.Clear()

            Me.UGridF�cher.Rows(Me.UGridF�cher.ActiveCell.Row.Index).Activated = True
            Me.UGridF�cher.ActiveRow.Selected = True
            Me.OrdnerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridF�cher_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridF�cher.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.f�cher
            Me.OrdnerEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridF�cher_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridF�cher.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub UGridThemen_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridThemen.InitializeLayout

    End Sub
    Private Sub UGridThemen_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridThemen.AfterCellActivate
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.thema
            Me.UGridThemen.Selected.Rows.Clear()
            Me.UGridThemen.Rows(Me.UGridThemen.ActiveCell.Row.Index).Activated = True
            Me.UGridThemen.ActiveRow.Selected = True
            Me.Schlagw�rterEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridThemen_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridThemen.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.thema
            Me.Schlagw�rterEinAus()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridThemen_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridThemen.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub UGridSchlagw�rter_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridSchlagw�rter.InitializeLayout

    End Sub
    Private Sub UGridSchlagw�rter_AfterCellActivate1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UGridSchlagw�rter.AfterCellActivate
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.schlagw�rter
            Me.UGridSchlagw�rter.Selected.Rows.Clear()
            Me.UGridSchlagw�rter.Rows(Me.UGridSchlagw�rter.ActiveCell.Row.Index).Activated = True
            Me.UGridSchlagw�rter.ActiveRow.Selected = True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridSchlagw�rter_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UGridSchlagw�rter.BeforeRowsDeleted
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
            NewRow = Me.dsSchr�nke.tblSchrank.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Bezeichnung = ""
            NewRow.ErstelltAm = Now
            NewRow.Extern = False
            NewRow.ErstelltVon = usr.actUser
            Me.dsSchr�nke.tblSchrank.Rows.Add(NewRow)

            Me.UGridSchr�nke.ActiveRow = Me.UGridSchr�nke.Rows(Me.UGridSchr�nke.Rows.Count - 1)
            Me.UGridSchr�nke.ActiveRow.Cells("Bezeichnung").Activate()
            Me.UGridSchr�nke.ActiveRow.Cells("Bezeichnung").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schrank_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblSchrankRow In Me.dsSchr�nke.tblSchrank
                If gen.IsNull(r.Bezeichnung) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.Schr�nkeSpeichern(Me.dsSchr�nke)

            Me.TabF�cherLeeren()
            Me.TabSchr�nkeLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schrank_L�schen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridSchr�nke.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie den Schrank wirklich l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteSchrank(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value)
                        Me.TabSchr�nkeLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Der Schrank wurde gel�scht!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Schrank_L�schen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BUTT_Fach_Neu()
        Try

            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.UGridSchr�nke.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridSchr�nke.ActiveRow.Cells("ID").Value) Then Exit Sub

            Dim NewRow As dsPlanArchive.tblFachRow
            NewRow = Me.dsF�cher.tblFach.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Bezeichnung = ""
            NewRow.ErstelltAm = Now
            NewRow.Extern = False
            NewRow.IDSchrank = Me.UGridSchr�nke.ActiveRow.Cells("ID").Value
            NewRow.ErstelltVon = usr.actUser
            Me.dsF�cher.tblFach.Rows.Add(NewRow)

            Me.UGridF�cher.ActiveRow = Me.UGridF�cher.Rows(Me.UGridF�cher.Rows.Count - 1)
            Me.UGridF�cher.ActiveRow.Cells("Bezeichnung").Activate()
            Me.UGridF�cher.ActiveRow.Cells("Bezeichnung").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Fach_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblFachRow In Me.dsF�cher.tblFach
                If gen.IsNull(r.Bezeichnung) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.F�cherSpeichern(Me.dsF�cher)

            Me.TabF�cherLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Fach_L�schen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridF�cher.ActiveRow) Then
                If Not gen.IsNull(Me.UGridF�cher.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Fach wirklich l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteF�cher(Me.UGridF�cher.ActiveRow.Cells("ID").Value)
                        Me.TabF�cherLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte w�hlen Sie ein Fach aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Fach_L�schen: " + ex.ToString())
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

            Me.TabSchlagw�rterLeeren()
            Me.TabThemenLaden()

            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Thema_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Thema_L�schen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridThemen.ActiveRow) Then
                If Not gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Thema wirklich l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteThema(Me.UGridThemen.ActiveRow.Cells("ID").Value)
                        Me.TabThemenLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte w�hlen Sie ein Thema aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Thema_L�schen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BUTT_Schlagwort_Neu()
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.UGridThemen.ActiveRow) Then Exit Sub
            If gen.IsNull(Me.UGridThemen.ActiveRow.Cells("ID").Value) Then Exit Sub

            Dim NewRow As dsPlanArchive.tblSchlagw�rterRow
            NewRow = Me.dataSchlagw�rter.tblSchlagw�rter.NewRow

            NewRow.ID = System.Guid.NewGuid
            NewRow.Schlagwort = ""
            NewRow.ErstelltAm = Now
            NewRow.IDThema = Me.UGridThemen.ActiveRow.Cells("ID").Value
            NewRow.ErstelltVon = usr.actUser
            Me.dataSchlagw�rter.tblSchlagw�rter.Rows.Add(NewRow)

            Me.UGridSchlagw�rter.ActiveRow = Me.UGridSchlagw�rter.Rows(Me.UGridSchlagw�rter.Rows.Count - 1)
            Me.UGridSchlagw�rter.ActiveRow.Cells("Schlagwort").Activate()
            Me.UGridSchlagw�rter.ActiveRow.Cells("Schlagwort").IsInEditMode = True

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_Neu: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schlagwort_Speichern()
        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r As dsPlanArchive.tblSchlagw�rterRow In Me.dataSchlagw�rter.tblSchlagw�rter
                If gen.IsNull(r.Schlagwort) Then
                    MsgBox("Bitte geben Sie eine Bezeichnung ein!", MsgBoxStyle.Information, "Archivsystem")
                    Exit Sub
                End If
            Next

            Dim comp As New compSql
            comp.Schlagw�rterSpeichern(Me.dataSchlagw�rter)

            Me.TabSchlagw�rterLaden()
            Dim info As New Info
            info.showInfo(True, 1400, Me.mainForm, "")

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_Speichern: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BUTT_Schlagwort_L�schen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.UGridSchlagw�rter.ActiveRow) Then
                If Not gen.IsNull(Me.UGridSchlagw�rter.ActiveRow.Cells("ID").Value) Then
                    If MsgBox("Wollen Sie das Schlagwort wirklich l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Dim comp As New compSql
                        comp.deleteSchlagwort(Me.UGridSchlagw�rter.ActiveRow.Cells("ID").Value)
                        Me.TabSchlagw�rterLaden()
                        Dim info As New Info
                        info.showInfo(True, 1400, Me.mainForm, "")
                    End If
                End If
            Else
                MsgBox("Bitte w�hlen Sie ein Schlagwort aus!", MsgBoxStyle.Exclamation, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("BUTT_Schlagwort_L�schen: " + ex.ToString())
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





    Private Sub lblGesamtesArchivL�schen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGesamtesArchivL�schen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If MsgBox("Wollen Sie wirklich das gesamte Archivsystem l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                Dim cl As New cArchive()
                cl.ClearDatabaseArchiv()
                MsgBox("Das Archivsystem wurde gel�scht!", MsgBoxStyle.Information, "Archivsystem")
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

    Private Sub UButtonSchr�nkeSpeichern2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchr�nkeSpeichern2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.schr�nke Then
                Me.BUTT_Schrank_Speichern()
            ElseIf Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.f�cher Then
                Me.BUTT_Fach_Speichern()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchr�nkeNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchr�nkeNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.schr�nke
            Me.BUTT_Schrank_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchr�nkeL�schen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchr�nkeL�schen2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.schr�nke Then
                Me.BUTT_Schrank_L�schen()
            ElseIf Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.f�cher Then
                Me.BUTT_Fach_L�schen()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonF�cherNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonF�cherNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schr�nkeF�cher = TableIsActive_Schr�nkeF�cher.f�cher
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

            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.thema
            Me.BUTT_Thema_Neu()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonThemaL�schen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonThemaL�schen2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.thema Then
                Me.BUTT_Thema_L�schen()
            ElseIf Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.schlagw�rter Then
                Me.BUTT_Schlagwort_L�schen()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonSchlagw�rterNeu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonSchlagw�rterNeu2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.schlagw�rter
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

            If Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.thema Then
                Me.BUTT_Thema_Speichern()
            ElseIf Me.tableActive_Schlagw�rter = TableIsActive_Schlagw�rter.schlagw�rter Then
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
                        Me.ContOrdner1.Load_Schr�nkeF�cher(contOrdner.etyp.Verwaltung, Nothing)
                    Case 1
                        Me.TabSchr�nkeLaden()
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
